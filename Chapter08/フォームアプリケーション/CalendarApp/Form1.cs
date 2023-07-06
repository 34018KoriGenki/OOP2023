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
        
        public Form1() {
            InitializeComponent();
        }

        private void btDayCalc_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            TimeSpan timespan = DateTime.Now - dtp;
            string str = "入力した日付から" + timespan.Days.ToString() + "日経過";
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
            var age = GetAge(dtpDate.Value, DateTime.Now);
            tbMessage.Text = "現在の年齢：" + age + "歳";
        }

        private static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        private void tmTimeDisp_Tick(object sender, EventArgs e) {
            tbTime.Text = DateTime.Now.ToString("yyyy年MM月dd日(dddd)  HH時mm分ss秒");
        }

        //実行時に一度だけ実行される
        private void Form1_Load(object sender, EventArgs e) {
            tmTimeDisp.Start();
        }
    }
}
