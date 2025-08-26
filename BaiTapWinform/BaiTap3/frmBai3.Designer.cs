namespace BaiTap3
{
    partial class frmBai3
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
            this.label5 = new System.Windows.Forms.Label();
            this.lblKQ = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSoN1 = new System.Windows.Forms.TextBox();
            this.txtSoN2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdTachChuoi = new System.Windows.Forms.RadioButton();
            this.rdThuTu = new System.Windows.Forms.RadioButton();
            this.btnThucThi = new System.Windows.Forms.Button();
            this.lblKQ1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số n1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số n2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kết quả: ";
            // 
            // lblKQ
            // 
            this.lblKQ.AutoSize = true;
            this.lblKQ.Location = new System.Drawing.Point(388, 295);
            this.lblKQ.Name = "lblKQ";
            this.lblKQ.Size = new System.Drawing.Size(10, 16);
            this.lblKQ.TabIndex = 5;
            this.lblKQ.Text = ".";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(251, 32);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(100, 22);
            this.txtHoTen.TabIndex = 6;
            // 
            // txtSoN1
            // 
            this.txtSoN1.Location = new System.Drawing.Point(251, 78);
            this.txtSoN1.Name = "txtSoN1";
            this.txtSoN1.Size = new System.Drawing.Size(100, 22);
            this.txtSoN1.TabIndex = 7;
            // 
            // txtSoN2
            // 
            this.txtSoN2.Location = new System.Drawing.Point(251, 124);
            this.txtSoN2.Name = "txtSoN2";
            this.txtSoN2.Size = new System.Drawing.Size(100, 22);
            this.txtSoN2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdThuTu);
            this.groupBox1.Controls.Add(this.rdTachChuoi);
            this.groupBox1.Location = new System.Drawing.Point(391, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 138);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn công việc";
            // 
            // rdTachChuoi
            // 
            this.rdTachChuoi.AutoSize = true;
            this.rdTachChuoi.Checked = true;
            this.rdTachChuoi.Location = new System.Drawing.Point(21, 40);
            this.rdTachChuoi.Name = "rdTachChuoi";
            this.rdTachChuoi.Size = new System.Drawing.Size(94, 20);
            this.rdTachChuoi.TabIndex = 0;
            this.rdTachChuoi.TabStop = true;
            this.rdTachChuoi.Text = "Tách chuỗi";
            this.rdTachChuoi.UseVisualStyleBackColor = true;
            // 
            // rdThuTu
            // 
            this.rdThuTu.AutoSize = true;
            this.rdThuTu.Location = new System.Drawing.Point(21, 85);
            this.rdThuTu.Name = "rdThuTu";
            this.rdThuTu.Size = new System.Drawing.Size(109, 20);
            this.rdThuTu.TabIndex = 1;
            this.rdThuTu.Text = "Kiếm tra thứ tự";
            this.rdThuTu.UseVisualStyleBackColor = true;
            // 
            // btnThucThi
            // 
            this.btnThucThi.Location = new System.Drawing.Point(277, 204);
            this.btnThucThi.Name = "btnThucThi";
            this.btnThucThi.Size = new System.Drawing.Size(139, 47);
            this.btnThucThi.TabIndex = 11;
            this.btnThucThi.Text = "Thực Thi";
            this.btnThucThi.UseVisualStyleBackColor = true;
            this.btnThucThi.Click += new System.EventHandler(this.btnThucThi_Click);
            // 
            // lblKQ1
            // 
            this.lblKQ1.AutoSize = true;
            this.lblKQ1.Location = new System.Drawing.Point(388, 331);
            this.lblKQ1.Name = "lblKQ1";
            this.lblKQ1.Size = new System.Drawing.Size(10, 16);
            this.lblKQ1.TabIndex = 12;
            this.lblKQ1.Text = ".";
            // 
            // frmBai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 374);
            this.Controls.Add(this.lblKQ1);
            this.Controls.Add(this.btnThucThi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSoN2);
            this.Controls.Add(this.txtSoN1);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblKQ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBai3";
            this.Text = "Bài 3";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblKQ;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSoN1;
        private System.Windows.Forms.TextBox txtSoN2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdThuTu;
        private System.Windows.Forms.RadioButton rdTachChuoi;
        private System.Windows.Forms.Button btnThucThi;
        private System.Windows.Forms.Label lblKQ1;
    }
}