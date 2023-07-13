using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> carReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvCarReports.DataSource = carReports;
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReports.Columns[5].Visible = false;   //画像項目非表示
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
            
            CarReport carReport = new CarReport() {
                Date = dtpDate.Value.Date,
                Author = cbAuthor.Text,
                Maker = getSelectedMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image,
            };
            carReports.Add(carReport);
            if (!cbAuthor.Items.Contains(cbAuthor.Text)) {
                cbAuthor.Items.Add(cbAuthor.Text);
            }
            if (!cbCarName.Items.Contains(cbCarName.Text)) {
                cbCarName.Items.Add(cbCarName.Text);
            }

            ClearInfo();
        }

        private void btDeleteReport_Click(object sender, EventArgs e) {
            dgvCarReports.Rows.RemoveAt(dgvCarReports.CurrentRow.Index);
            ClearInfo();
        }

        private void dgvCarReports_Click(object sender, EventArgs e) {
            ButtonEnabled();
            if (dgvCarReports.CurrentCell != null) {
                var data = dgvCarReports.CurrentCell.RowIndex;
                dtpDate.Value = carReports[data].Date;
                cbAuthor.Text = carReports[data].Author;
                getSelectedMaker(carReports[data].Maker);
                cbCarName.Text = carReports[data].CarName;
                tbReport.Text = carReports[data].Report;
                pbCarImage.Image = carReports[data].CarImage;

            } else ButtonDisabled();
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
            int select = dgvCarReports.CurrentCell.RowIndex;
            carReports[select] = new CarReport() {
                Date = dtpDate.Value.Date,
                Author = cbAuthor.Text,
                Maker = getSelectedMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image,
            };
            dgvCarReports.Refresh();    //一覧更新
            if (!cbAuthor.Items.Contains(cbAuthor.Text)) {
                cbAuthor.Items.Add(cbAuthor.Text);
            }
            if (!cbCarName.Items.Contains(cbCarName.Text)) {
                cbCarName.Items.Add(cbCarName.Text);
            }
            ClearInfo();
        }

        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }

        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
        }

        //指定したラジオボタンのメーカーをセット
        private CarReport.MakerGroup getSelectedMaker() {
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
        private void getSelectedMaker(object makerGroup) {
            switch (makerGroup) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.スズキ:
                    rbSuzuki.Checked = true;
                    break;
                case CarReport.MakerGroup.ダイハツ:
                    rbDaihatsu.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImported.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
                default:
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
            dgvCarReports.CurrentCell = null;
            dtpDate.Value = DateTime.Now.Date;
            cbAuthor.Text = null;
            rbOther.Checked = true;
            cbCarName.Text = null;
            tbReport.Text = null;
            pbCarImage.Image = null;
            ButtonDisabled();
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog();        //モーダルダイアログとして表示
        }
    }
}
