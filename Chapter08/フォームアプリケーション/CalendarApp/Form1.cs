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
            tbMessage.Text = timespan.Days.ToString();
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
    }
}
