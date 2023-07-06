
namespace CalendarApp {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btDayCalc = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btForwardYear = new System.Windows.Forms.Button();
            this.btForwardMonth = new System.Windows.Forms.Button();
            this.btForwardDay = new System.Windows.Forms.Button();
            this.btBeforeYear = new System.Windows.Forms.Button();
            this.btBeforeMonth = new System.Windows.Forms.Button();
            this.btBeforeDay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.btOld = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "日付：";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate.Location = new System.Drawing.Point(104, 7);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 31);
            this.dtpDate.TabIndex = 1;
            // 
            // btDayCalc
            // 
            this.btDayCalc.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btDayCalc.Location = new System.Drawing.Point(12, 44);
            this.btDayCalc.Name = "btDayCalc";
            this.btDayCalc.Size = new System.Drawing.Size(123, 34);
            this.btDayCalc.TabIndex = 2;
            this.btDayCalc.Text = "日数計算";
            this.btDayCalc.UseVisualStyleBackColor = true;
            this.btDayCalc.Click += new System.EventHandler(this.btDayCalc_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbMessage.Location = new System.Drawing.Point(310, 12);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(494, 315);
            this.tbMessage.TabIndex = 3;
            // 
            // btForwardYear
            // 
            this.btForwardYear.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btForwardYear.Location = new System.Drawing.Point(22, 118);
            this.btForwardYear.Name = "btForwardYear";
            this.btForwardYear.Size = new System.Drawing.Size(76, 40);
            this.btForwardYear.TabIndex = 4;
            this.btForwardYear.Text = "-年";
            this.btForwardYear.UseVisualStyleBackColor = true;
            this.btForwardYear.Click += new System.EventHandler(this.btForwardYear_Click);
            // 
            // btForwardMonth
            // 
            this.btForwardMonth.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btForwardMonth.Location = new System.Drawing.Point(22, 185);
            this.btForwardMonth.Name = "btForwardMonth";
            this.btForwardMonth.Size = new System.Drawing.Size(76, 40);
            this.btForwardMonth.TabIndex = 4;
            this.btForwardMonth.Text = "-月";
            this.btForwardMonth.UseVisualStyleBackColor = true;
            this.btForwardMonth.Click += new System.EventHandler(this.btForwardMonth_Click);
            // 
            // btForwardDay
            // 
            this.btForwardDay.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btForwardDay.Location = new System.Drawing.Point(22, 255);
            this.btForwardDay.Name = "btForwardDay";
            this.btForwardDay.Size = new System.Drawing.Size(76, 40);
            this.btForwardDay.TabIndex = 4;
            this.btForwardDay.Text = "-日";
            this.btForwardDay.UseVisualStyleBackColor = true;
            this.btForwardDay.Click += new System.EventHandler(this.btForwardDay_Click);
            // 
            // btBeforeYear
            // 
            this.btBeforeYear.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btBeforeYear.Location = new System.Drawing.Point(158, 118);
            this.btBeforeYear.Name = "btBeforeYear";
            this.btBeforeYear.Size = new System.Drawing.Size(76, 40);
            this.btBeforeYear.TabIndex = 4;
            this.btBeforeYear.Text = "+年";
            this.btBeforeYear.UseVisualStyleBackColor = true;
            this.btBeforeYear.Click += new System.EventHandler(this.btBeforeYear_Click);
            // 
            // btBeforeMonth
            // 
            this.btBeforeMonth.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btBeforeMonth.Location = new System.Drawing.Point(158, 185);
            this.btBeforeMonth.Name = "btBeforeMonth";
            this.btBeforeMonth.Size = new System.Drawing.Size(76, 40);
            this.btBeforeMonth.TabIndex = 4;
            this.btBeforeMonth.Text = "+月";
            this.btBeforeMonth.UseVisualStyleBackColor = true;
            this.btBeforeMonth.Click += new System.EventHandler(this.btBeforeMonth_Click);
            // 
            // btBeforeDay
            // 
            this.btBeforeDay.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btBeforeDay.Location = new System.Drawing.Point(158, 255);
            this.btBeforeDay.Name = "btBeforeDay";
            this.btBeforeDay.Size = new System.Drawing.Size(76, 40);
            this.btBeforeDay.TabIndex = 4;
            this.btBeforeDay.Text = "+日";
            this.btBeforeDay.UseVisualStyleBackColor = true;
            this.btBeforeDay.Click += new System.EventHandler(this.btBeforeDay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "現在時刻：";
            // 
            // tbTime
            // 
            this.tbTime.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbTime.Location = new System.Drawing.Point(162, 393);
            this.tbTime.Multiline = true;
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(229, 29);
            this.tbTime.TabIndex = 3;
            // 
            // btOld
            // 
            this.btOld.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btOld.Location = new System.Drawing.Point(58, 317);
            this.btOld.Name = "btOld";
            this.btOld.Size = new System.Drawing.Size(143, 39);
            this.btOld.TabIndex = 5;
            this.btOld.Text = "年齢計算";
            this.btOld.UseVisualStyleBackColor = true;
            this.btOld.Click += new System.EventHandler(this.btOld_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 450);
            this.Controls.Add(this.btOld);
            this.Controls.Add(this.btBeforeDay);
            this.Controls.Add(this.btForwardDay);
            this.Controls.Add(this.btBeforeMonth);
            this.Controls.Add(this.btForwardMonth);
            this.Controls.Add(this.btBeforeYear);
            this.Controls.Add(this.btForwardYear);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btDayCalc);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "カレンダーアプリ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btDayCalc;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btForwardYear;
        private System.Windows.Forms.Button btForwardMonth;
        private System.Windows.Forms.Button btForwardDay;
        private System.Windows.Forms.Button btBeforeYear;
        private System.Windows.Forms.Button btBeforeMonth;
        private System.Windows.Forms.Button btBeforeDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Button btOld;
    }
}

