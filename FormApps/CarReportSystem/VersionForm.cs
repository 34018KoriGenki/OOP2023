﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class VersionForm : Form {
        public VersionForm() {
            InitializeComponent();
        }


        private void VersionForm_Load(object sender, EventArgs e) {
            string imageRuntimeVersion = System.Reflection.Assembly.GetExecutingAssembly().ImageRuntimeVersion;
            label1.Text = imageRuntimeVersion;
        }

        private void btOk_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
