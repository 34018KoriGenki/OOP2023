using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> carReports = new BindingList<CarReport>();
        int mode = 0;
        //設定情報保存用オブジェクト
        Settings settings = Settings.getInstance();


        public Form1() {
            InitializeComponent();
            //dgvCarReports.DataSource = carReports;
        }

        private void Form1_Load(object sender, EventArgs e) {

            Timer timer = new Timer();
            label8.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            try {
                using (var setting = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(int));
                    BackColor = Color.FromArgb((int)serializer.Deserialize(setting));
                }
            } catch (FileNotFoundException) {
                BackColor = DefaultBackColor;
            }
            label8.BackColor = DefaultBackColor;
            tsInfoText.BackColor = DefaultBackColor;

            timer.Start();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            //dgvCarReports.RowsDefaultCellStyle.BackColor = Color.LightGray; //全体に色を設定
            dgvCarReports.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;  //奇数行の色を上書き設定

            dgvCarReports.Columns[6].Visible = false;   //画像項目非表示
            ButtonDisabled();
        }

        //ステータスラベルのテキスト表示・非表示(引数なしはメッセージ非表示)
        private void statasLavelDisp(string msg = "") {
            tsInfoText.Text = msg;
        }

        //追加ボタンがクリックされた時のイベントハンドラ
        private void btAddReport_Click(object sender, EventArgs e) {
            statasLavelDisp();
            if (cbAuthor.Text == "") {
                statasLavelDisp("記録者が設定されていません");
                return;
            }
            if (cbCarName.Text == "") {
                statasLavelDisp("車名が設定されていません");
                return;
            }
            DataRow newRow = infosys202329DataSet.CarReportTable.NewRow();

            newRow[1] = dtpDate.Value.Date;
            newRow[2] = cbAuthor.Text;
            newRow[3] = GetSelectedMaker();
            newRow[4] = cbCarName.Text;
            newRow[5] = tbReport.Text;
            newRow[6] = ImageToByteArray(pbCarImage.Image);

            infosys202329DataSet.CarReportTable.Rows.Add(newRow);
            this.carReportTableTableAdapter.Update(infosys202329DataSet.CarReportTable);
            //CarReport carReport = new CarReport() {
            //    Date = dtpDate.Value.Date,
            //    Author = cbAuthor.Text,
            //    Maker = GetSelectedMaker(),
            //    CarName = cbCarName.Text,
            //    Report = tbReport.Text,
            //    CarImage = pbCarImage.Image,
            //};
            //carReports.Add(carReport);
            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);

            ClearInfo();
        }

        private void btDeleteReport_Click(object sender, EventArgs e) {
            dgvCarReports.Rows.RemoveAt(dgvCarReports.CurrentCell.RowIndex);

            this.carReportTableTableAdapter.Update(infosys202329DataSet.CarReportTable); ClearInfo();

        }

        private void btModifyReport_Click(object sender, EventArgs e) {
            statasLavelDisp();
            if (cbAuthor.Text == "") {
                statasLavelDisp("記録者が設定されていません");
                return;
            }
            if (cbCarName.Text == "") {
                statasLavelDisp("車名が設定されていません");
                return;
            }
            var cells = dgvCarReports.CurrentRow.Cells;
            cells[1].Value = dtpDate.Value.Date;
            cells[2].Value = cbAuthor.Text;
            cells[3].Value = GetSelectedMaker();
            cells[4].Value = cbCarName.Text;
            cells[5].Value = tbReport.Text;
            cells[6].Value = pbCarImage.Image;

            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202329DataSet);
            dgvCarReports.Refresh();    //一覧更新
            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);
            ClearInfo();
        }

        private void dgvCarReports_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (dgvCarReports.CurrentCell != null) {
                var data = dgvCarReports.CurrentCell.RowIndex;
                var table = carReportTableTableAdapter.GetData().Rows[data];
                dtpDate.Value = table.Field<DateTime>("Date");
                cbAuthor.Text = table.Field<string>("Author");
                GetSelectedMaker(table.Field<string>("Maker"));
                cbCarName.Text = table.Field<string>("CarName");
                tbReport.Text = table.Field<string>("Report");

                pbCarImage.Image = ByteArrayToImage(table.Field<byte[]>("Image"));
                ButtonEnabled();
            }
        }

        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author)) cbAuthor.Items.Add(author);
        }

        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) cbCarName.Items.Add(carName);
        }

        private void btImageOpen_Click(object sender, EventArgs e) {
            if (ofdImageFileOpen.ShowDialog() == DialogResult.OK) {
                pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
            }
        }

        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
        }

        //指定したラジオボタンのメーカーをセット
        private CarReport.MakerGroup GetSelectedMaker() {
            int num = 0;
            foreach (RadioButton rb in gbMaker.Controls) {
                if (rb.Checked) {
                    num = int.Parse(rb.Tag.ToString());
                    break;
                }
            }
            return (CarReport.MakerGroup)num;
        }

        //指定したメーカーのラジオボタンをセット
        private void GetSelectedMaker(string makerGroup) {
            switch (makerGroup) {
                case "トヨタ":
                    rbToyota.Checked = true;
                    break;
                case "日産":
                    rbNissan.Checked = true;
                    break;
                case "ホンダ":
                    rbHonda.Checked = true;
                    break;
                case "スバル":
                    rbSubaru.Checked = true;
                    break;
                case "スズキ":
                    rbSuzuki.Checked = true;
                    break;
                case "ダイハツ":
                    rbDaihatsu.Checked = true;
                    break;
                case "輸入車":
                    rbImported.Checked = true;
                    break;
                case "その他":
                    rbOther.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }

        private void ButtonDisabled() {
            btModifyReport.Enabled = false;
            btDeleteReport.Enabled = false;
        }

        private void ButtonEnabled() {
            btModifyReport.Enabled = true;
            btDeleteReport.Enabled = true;
        }

        private void ClearInfo() {
            dgvCarReports.ClearSelection();
            dgvCarReports.CurrentCell = null;
            dtpDate.Value = DateTime.Now.Date;
            cbAuthor.Text = null;
            rbOther.Checked = true;
            cbCarName.Text = null;
            tbReport.Text = null;
            pbCarImage.Image = null;
            ButtonDisabled();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            label8.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog();        //モーダルダイアログとして表示
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            cdColor.CustomColors = new int[] {
                0xffffff, 0xffffff, 0xffffff, 0xffffff, 0xffffff, 0xffffff,
                0xffffff, 0xffffff, 0xffffff, 0xffffff, 0xffffff,
                0xffffff, 0xffffff, 0xffffff, 0xffffff, 0xffffff
            };
            if (cdColor.ShowDialog() == DialogResult.OK) {
                //選択された色の取得
                BackColor = cdColor.Color;
                settings.MainFormColor = BackColor.ToArgb();
                label8.BackColor = DefaultBackColor;
                tsInfoText.BackColor = DefaultBackColor;
            }
        }

        private void btScaleChange_Click(object sender, EventArgs e) {
            mode = mode < 4 ? (mode == 1) ? 3 : ++mode : 0;     //AutoSize(2)を除外
            pbCarImage.SizeMode = (PictureBoxSizeMode)mode;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルのシリアル化
            settings.MainFormColor = BackColor.ToArgb();
            using (var setting = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.MainFormColor.GetType());
                serializer.Serialize(setting, settings.MainFormColor);
            }
        }

        private void 接続ToolStripMenuItem_Click(object sender, EventArgs e) {
            dbAccess();
        }

        private void carReportTableBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202329DataSet);
        }

        private void dbAccess() {
            // TODO: このコード行はデータを 'infosys202329DataSet.CarReportTable' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.carReportTableTableAdapter.Fill(this.infosys202329DataSet.CarReportTable);
            dgvCarReports.ClearSelection();     //選択解除
            foreach (var item in this.infosys202329DataSet.CarReportTable) {
                setCbAuthor(item.Author);
                setCbCarName(item.CarName);
            }
        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            ImageConverter imgconv = new ImageConverter();
            //Image img = (Image)imgconv.ConvertFrom(b);
            if (b == null || b.All(n => n == 0x0)) {
                return null;
            }
            return (Image)imgconv.ConvertFrom(b);
        }

        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter();
            return (byte[])imgconv.ConvertTo(img, typeof(byte[]));
        }

        private void btAuthorSearch_Click(object sender, EventArgs e) {
            carReportTableTableAdapter.FillByContainAuthor(this.infosys202329DataSet.CarReportTable,tbAuthor.Text);
        }

        private void btCarName_Click(object sender, EventArgs e) {
            carReportTableTableAdapter.FillByContainCarName(this.infosys202329DataSet.CarReportTable, tbCarName.Text);
        }

        private void btDateSearch_Click(object sender, EventArgs e) {
            carReportTableTableAdapter.FillByDate(this.infosys202329DataSet.CarReportTable, dtpStartSearchDate.Text, dtpEndSearchDate.Text);
        }

        private void btReset_Click(object sender, EventArgs e) {
            tbAuthor.Text = null;
            tbCarName.Text = null;
        }
    }
}