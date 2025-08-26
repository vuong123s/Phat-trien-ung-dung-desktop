namespace BaiTap4
{
    partial class frmBai2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblXL = new System.Windows.Forms.Label();
            this.txtDiemLT = new System.Windows.Forms.TextBox();
            this.txtDiemTH = new System.Windows.Forms.TextBox();
            this.btnXL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập điểm lý thuyết";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập điểm thực hành";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kết quả:";
            // 
            // lblXL
            // 
            this.lblXL.AutoSize = true;
            this.lblXL.Location = new System.Drawing.Point(348, 295);
            this.lblXL.Name = "lblXL";
            this.lblXL.Size = new System.Drawing.Size(10, 16);
            this.lblXL.TabIndex = 3;
            this.lblXL.Text = ".";
            // 
            // txtDiemLT
            // 
            this.txtDiemLT.Location = new System.Drawing.Point(319, 72);
            this.txtDiemLT.Name = "txtDiemLT";
            this.txtDiemLT.Size = new System.Drawing.Size(148, 22);
            this.txtDiemLT.TabIndex = 4;
            // 
            // txtDiemTH
            // 
            this.txtDiemTH.Location = new System.Drawing.Point(319, 130);
            this.txtDiemTH.Name = "txtDiemTH";
            this.txtDiemTH.Size = new System.Drawing.Size(148, 22);
            this.txtDiemTH.TabIndex = 5;
            // 
            // btnXL
            // 
            this.btnXL.Location = new System.Drawing.Point(258, 215);
            this.btnXL.Name = "btnXL";
            this.btnXL.Size = new System.Drawing.Size(75, 23);
            this.btnXL.TabIndex = 6;
            this.btnXL.Text = "Xếp loại";
            this.btnXL.UseVisualStyleBackColor = true;
            this.btnXL.Click += new System.EventHandler(this.btnXL_Click);
            // 
            // frmBai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 450);
            this.Controls.Add(this.btnXL);
            this.Controls.Add(this.txtDiemTH);
            this.Controls.Add(this.txtDiemLT);
            this.Controls.Add(this.lblXL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBai2";
            this.Text = "Bài 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblXL;
        private System.Windows.Forms.TextBox txtDiemLT;
        private System.Windows.Forms.TextBox txtDiemTH;
        private System.Windows.Forms.Button btnXL;
    }
}