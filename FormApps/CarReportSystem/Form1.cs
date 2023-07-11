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

        //追加ボタンがクリックされた時のイベントハンドラ
        private void btAddReport_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport() {
                Date = dtpDate.Value.Date,
                Author = cbAuthor.Text,
                Maker = getSelectedMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image,
            };
            carReports.Add(carReport);
        }

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

        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReports.Columns[5].Visible = false;   //画像項目非表示
        }

        private void btDeleteReport_Click(object sender, EventArgs e) {
            if (dgvCarReports.SelectedRows.Count != 0)
                dgvCarReports.Rows.RemoveAt(dgvCarReports.CurrentRow.Index);
        }
    }
}
