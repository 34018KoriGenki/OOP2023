﻿using System;
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
        Settings settings = new Settings();

        public Form1() {
            InitializeComponent();
            dgvCarReports.DataSource = carReports;
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
            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);
            ClearInfo();
        }

        private void dgvCarReports_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (dgvCarReports.CurrentCell != null) {
                var data = dgvCarReports.CurrentCell.RowIndex;
                dtpDate.Value = carReports[data].Date;
                cbAuthor.Text = carReports[data].Author;
                getSelectedMaker(carReports[data].Maker);
                cbCarName.Text = carReports[data].CarName;
                tbReport.Text = carReports[data].Report;
                pbCarImage.Image = carReports[data].CarImage;
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

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            if(sfdCarRepoSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリデータ型式でシリアル化
                    var bf = new BinaryFormatter();
                    using (FileStream fs = File.Open(sfdCarRepoSave.FileName,FileMode.Create)) {
                        bf.Serialize(fs, carReports);
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ofdCarRepoOpen.ShowDialog() == DialogResult.OK) {
                try {
                    var bf = new BinaryFormatter();
                    using (FileStream fs = File.Open(ofdCarRepoOpen.FileName, FileMode.Open,FileAccess.Read)) {
                        carReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                dgvCarReports.DataSource = null;
                dgvCarReports.DataSource = carReports;
                cbAuthor.Items.Clear();
                cbCarName.Items.Clear();
                foreach (var item in carReports) {
                    setCbAuthor(item.Author);
                    setCbCarName(item.CarName);
                }
                dgvCarReports.Columns[5].Visible = false;
                ClearInfo();
            }
        }
    }
}