using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarApp {
    public partial class Form1 : Form {
        private Timer moveTimer;
        public Form1() {
            InitializeComponent();
            moveTimer = new Timer();
            moveTimer.Interval = 1;     //タイマーのインターバル(ms)
            moveTimer.Tick += MoveTimer_Tick;       //デリゲート登録
            moveTimer.Start();
        }

        private void MoveTimer_Tick(object sender, EventArgs e) {
            tbTime.Text = DateTime.Now.ToString();
        }

        private void btDayCalc_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            TimeSpan timespan = DateTime.Now - dtp;
            string str = "入力した日付から"+timespan.Days.ToString()+"日経過";
            tbMessage.Text = str;
        }

        private void btForwardYear_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            dtpDate.Value = dtp.AddYears(-1);
            
        }

        private void btBeforeYear_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            dtpDate.Value = dtp.AddYears(1);
        }

        private void btForwardMonth_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            dtpDate.Value = dtp.AddMonths(-1);
        }

        private void btBeforeMonth_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            dtpDate.Value = dtp.AddMonths(1);
        }

        private void btForwardDay_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            dtpDate.Value = dtp.AddDays(-1);
        }

        private void btBeforeDay_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            dtpDate.Value = dtp.AddDays(1);
        }

        private void btOld_Click(object sender, EventArgs e) {
            int oldYear = DateTime.Now.Year - dtpDate.Value.Year;
            int oldMonth = DateTime.Now.Month - dtpDate.Value.Month;
            int oldDay = DateTime.Now.Day - dtpDate.Value.Day;
            if (oldMonth < 0) {
                oldYear--;
            } else if (oldMonth == 0 && oldDay < 0) {
                oldYear--;
            }
            tbMessage.Text = "現在の年齢："+oldYear+"歳";
        }
    }
}
