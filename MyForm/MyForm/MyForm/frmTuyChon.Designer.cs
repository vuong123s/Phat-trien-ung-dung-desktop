namespace MyForm
{
    partial class frmTuyChon
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
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.lblLoaiTim = new System.Windows.Forms.Label();
            this.gbTuychon = new System.Windows.Forms.GroupBox();
            this.rdNgaySinh = new System.Windows.Forms.RadioButton();
            this.rdHoTen = new System.Windows.Forms.RadioButton();
            this.rdSV = new System.Windows.Forms.RadioButton();
            this.btnSapXep = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gbTuychon.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(414, 126);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 7;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(154, 126);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(221, 22);
            this.txtTim.TabIndex = 6;
            // 
            // lblLoaiTim
            // 
            this.lblLoaiTim.AutoSize = true;
            this.lblLoaiTim.Location = new System.Drawing.Point(50, 129);
            this.lblLoaiTim.Name = "lblLoaiTim";
            this.lblLoaiTim.Size = new System.Drawing.Size(98, 16);
            this.lblLoaiTim.TabIndex = 5;
            this.lblLoaiTim.Text = "Nhập thông tin: ";
            // 
            // gbTuychon
            // 
            this.gbTuychon.Controls.Add(this.rdNgaySinh);
            this.gbTuychon.Controls.Add(this.rdHoTen);
            this.gbTuychon.Controls.Add(this.rdSV);
            this.gbTuychon.Location = new System.Drawing.Point(22, 12);
            this.gbTuychon.Name = "gbTuychon";
            this.gbTuychon.Size = new System.Drawing.Size(517, 102);
            this.gbTuychon.TabIndex = 4;
            this.gbTuychon.TabStop = false;
            this.gbTuychon.Text = "Tìm theo";
            // 
            // rdNgaySinh
            // 
            this.rdNgaySinh.AutoSize = true;
            this.rdNgaySinh.Location = new System.Drawing.Point(381, 49);
            this.rdNgaySinh.Name = "rdNgaySinh";
            this.rdNgaySinh.Size = new System.Drawing.Size(88, 20);
            this.rdNgaySinh.TabIndex = 2;
            this.rdNgaySinh.Text = "Ngày sinh";
            this.rdNgaySinh.UseVisualStyleBackColor = true;
            // 
            // rdHoTen
            // 
            this.rdHoTen.AutoSize = true;
            this.rdHoTen.Location = new System.Drawing.Point(209, 49);
            this.rdHoTen.Name = "rdHoTen";
            this.rdHoTen.Size = new System.Drawing.Size(73, 20);
            this.rdHoTen.TabIndex = 1;
            this.rdHoTen.Text = "Họ Tên";
            this.rdHoTen.UseVisualStyleBackColor = true;
            // 
            // rdSV
            // 
            this.rdSV.AutoSize = true;
            this.rdSV.Checked = true;
            this.rdSV.Location = new System.Drawing.Point(54, 49);
            this.rdSV.Name = "rdSV";
            this.rdSV.Size = new System.Drawing.Size(68, 20);
            this.rdSV.TabIndex = 0;
            this.rdSV.TabStop = true;
            this.rdSV.Text = "Mã SV";
            this.rdSV.UseVisualStyleBackColor = true;
            // 
            // btnSapXep
            // 
            this.btnSapXep.Location = new System.Drawing.Point(154, 170);
            this.btnSapXep.Name = "btnSapXep";
            this.btnSapXep.Size = new System.Drawing.Size(98, 47);
            this.btnSapXep.TabIndex = 8;
            this.btnSapXep.Text = "Sắp xếp";
            this.btnSapXep.UseVisualStyleBackColor = true;
            this.btnSapXep.Click += new System.EventHandler(this.btnSapXep_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(295, 170);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(102, 47);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmTuyChon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 229);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSapXep);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.lblLoaiTim);
            this.Controls.Add(this.gbTuychon);
            this.Name = "frmTuyChon";
            this.Text = "Tùy chọn";
            this.Load += new System.EventHandler(this.frmTuyChon_Load);
            this.gbTuychon.ResumeLayout(false);
            this.gbTuychon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label lblLoaiTim;
        private System.Windows.Forms.GroupBox gbTuychon;
        private System.Windows.Forms.RadioButton rdNgaySinh;
        private System.Windows.Forms.RadioButton rdHoTen;
        private System.Windows.Forms.RadioButton rdSV;
        private System.Windows.Forms.Button btnSapXep;
        private System.Windows.Forms.Button btnThoat;
    }
}