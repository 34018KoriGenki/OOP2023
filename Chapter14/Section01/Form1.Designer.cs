
namespace Section01 {
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
            this.btRunNotepad = new System.Windows.Forms.Button();
            this.btRunAndWaitNotePad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btRunNotepad
            // 
            this.btRunNotepad.Location = new System.Drawing.Point(12, 12);
            this.btRunNotepad.Name = "btRunNotepad";
            this.btRunNotepad.Size = new System.Drawing.Size(348, 81);
            this.btRunNotepad.TabIndex = 0;
            this.btRunNotepad.Text = "RunNotepad";
            this.btRunNotepad.UseVisualStyleBackColor = true;
            this.btRunNotepad.Click += new System.EventHandler(this.btRunNotepad_Click);
            // 
            // btRunAndWaitNotePad
            // 
            this.btRunAndWaitNotePad.Location = new System.Drawing.Point(12, 115);
            this.btRunAndWaitNotePad.Name = "btRunAndWaitNotePad";
            this.btRunAndWaitNotePad.Size = new System.Drawing.Size(348, 80);
            this.btRunAndWaitNotePad.TabIndex = 1;
            this.btRunAndWaitNotePad.Text = "RunAndWaitNotepad";
            this.btRunAndWaitNotePad.UseVisualStyleBackColor = true;
            this.btRunAndWaitNotePad.Click += new System.EventHandler(this.btRunAndWaitNotePad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 207);
            this.Controls.Add(this.btRunAndWaitNotePad);
            this.Controls.Add(this.btRunNotepad);
            this.Name = "Form1";
            this.Text = "14章1節";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRunNotepad;
        private System.Windows.Forms.Button btRunAndWaitNotePad;
    }
}

