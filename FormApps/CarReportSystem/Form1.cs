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

            if (rbToyota.Checked) return CarReport.MakerGroup.トヨタ;

            if (rbNissan.Checked) return CarReport.MakerGroup.日産;

            if (rbHonda.Checked) return CarReport.MakerGroup.ホンダ;

            if (rbSubaru.Checked) return CarReport.MakerGroup.スバル;

            if (rbSuzuki.Checked) return CarReport.MakerGroup.スズキ;

            if (rbDaihatsu.Checked) return CarReport.MakerGroup.ダイハツ;

            if (rbImported.Checked) return CarReport.MakerGroup.輸入車;

            return CarReport.MakerGroup.その他;
        }
    }
}
