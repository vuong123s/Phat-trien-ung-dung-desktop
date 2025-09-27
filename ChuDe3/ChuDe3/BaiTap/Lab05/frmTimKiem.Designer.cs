
namespace Lab05
{
    partial class frmTimKiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbTimTheo = new System.Windows.Forms.GroupBox();
            this.rdTimLop = new System.Windows.Forms.RadioButton();
            this.rdTimTen = new System.Windows.Forms.RadioButton();
            this.rdTimMSSV = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.gbTimTheo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTimTheo
            // 
            this.gbTimTheo.Controls.Add(this.rdTimLop);
            this.gbTimTheo.Controls.Add(this.rdTimTen);
            this.gbTimTheo.Controls.Add(this.rdTimMSSV);
            this.gbTimTheo.Location = new System.Drawing.Point(65, 15);
            this.gbTimTheo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTimTheo.Name = "gbTimTheo";
            this.gbTimTheo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTimTheo.Size = new System.Drawing.Size(525, 86);
            this.gbTimTheo.TabIndex = 0;
            this.gbTimTheo.TabStop = false;
            this.gbTimTheo.Text = "Tim theo";
            // 
            // rdTimLop
            // 
            this.rdTimLop.AutoSize = true;
            this.rdTimLop.Location = new System.Drawing.Point(356, 37);
            this.rdTimLop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdTimLop.Name = "rdTimLop";
            this.rdTimLop.Size = new System.Drawing.Size(51, 20);
            this.rdTimLop.TabIndex = 0;
            this.rdTimLop.TabStop = true;
            this.rdTimLop.Text = "Lop";
            this.rdTimLop.UseVisualStyleBackColor = true;
            // 
            // rdTimTen
            // 
            this.rdTimTen.AutoSize = true;
            this.rdTimTen.Location = new System.Drawing.Point(200, 37);
            this.rdTimTen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdTimTen.Name = "rdTimTen";
            this.rdTimTen.Size = new System.Drawing.Size(52, 20);
            this.rdTimTen.TabIndex = 0;
            this.rdTimTen.TabStop = true;
            this.rdTimTen.Text = "Ten";
            this.rdTimTen.UseVisualStyleBackColor = true;
            // 
            // rdTimMSSV
            // 
            this.rdTimMSSV.AutoSize = true;
            this.rdTimMSSV.Checked = true;
            this.rdTimMSSV.Location = new System.Drawing.Point(24, 37);
            this.rdTimMSSV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdTimMSSV.Name = "rdTimMSSV";
            this.rdTimMSSV.Size = new System.Drawing.Size(66, 20);
            this.rdTimMSSV.TabIndex = 0;
            this.rdTimMSSV.TabStop = true;
            this.rdTimMSSV.Text = "MSSV";
            this.rdTimMSSV.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tim kiem";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(65, 142);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(393, 22);
            this.txtTimKiem.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(469, 137);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 28);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tim";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 239);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbTimTheo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTimKiem";
            this.Text = "TimKiem";
            this.Load += new System.EventHandler(this.frmTimKiem_Load);
            this.gbTimTheo.ResumeLayout(false);
            this.gbTimTheo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTimTheo;
        private System.Windows.Forms.RadioButton rdTimLop;
        private System.Windows.Forms.RadioButton rdTimTen;
        private System.Windows.Forms.RadioButton rdTimMSSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
    }
}