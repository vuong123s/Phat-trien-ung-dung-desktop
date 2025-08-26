namespace MyForm
{
    partial class frmTrungTam
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTinHocA = new System.Windows.Forms.Label();
            this.lblTinHocB = new System.Windows.Forms.Label();
            this.lblTiengAnhA = new System.Windows.Forms.Label();
            this.lblTiengAnhB = new System.Windows.Forms.Label();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cboMaHV = new System.Windows.Forms.ComboBox();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.chbTinHocA = new System.Windows.Forms.CheckBox();
            this.chbTinHocB = new System.Windows.Forms.CheckBox();
            this.chbTiengAnhA = new System.Windows.Forms.CheckBox();
            this.chbTiengAnhB = new System.Windows.Forms.CheckBox();
            this.dtpNgayDangKi = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Fuchsia;
            this.label1.Location = new System.Drawing.Point(129, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "TÍNH TIỀN HỌC TRUNG TÂM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(72, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Học Viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(362, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giới Tính";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(72, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Học Tên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(72, 231);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ngày Đăng Kí";
            // 
            // lblTinHocA
            // 
            this.lblTinHocA.AutoSize = true;
            this.lblTinHocA.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblTinHocA.Location = new System.Drawing.Point(421, 279);
            this.lblTinHocA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTinHocA.Name = "lblTinHocA";
            this.lblTinHocA.Size = new System.Drawing.Size(85, 16);
            this.lblTinHocA.TabIndex = 11;
            this.lblTinHocA.Text = "300.000 đồng";
            this.lblTinHocA.Click += new System.EventHandler(this.label12_Click);
            // 
            // lblTinHocB
            // 
            this.lblTinHocB.AutoSize = true;
            this.lblTinHocB.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblTinHocB.Location = new System.Drawing.Point(421, 314);
            this.lblTinHocB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTinHocB.Name = "lblTinHocB";
            this.lblTinHocB.Size = new System.Drawing.Size(85, 16);
            this.lblTinHocB.TabIndex = 12;
            this.lblTinHocB.Text = "500.000 đồng";
            this.lblTinHocB.Click += new System.EventHandler(this.label13_Click);
            // 
            // lblTiengAnhA
            // 
            this.lblTiengAnhA.AutoSize = true;
            this.lblTiengAnhA.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblTiengAnhA.Location = new System.Drawing.Point(421, 354);
            this.lblTiengAnhA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTiengAnhA.Name = "lblTiengAnhA";
            this.lblTiengAnhA.Size = new System.Drawing.Size(85, 16);
            this.lblTiengAnhA.TabIndex = 13;
            this.lblTiengAnhA.Text = "400.000 đồng";
            this.lblTiengAnhA.Click += new System.EventHandler(this.label14_Click);
            // 
            // lblTiengAnhB
            // 
            this.lblTiengAnhB.AutoSize = true;
            this.lblTiengAnhB.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblTiengAnhB.Location = new System.Drawing.Point(421, 395);
            this.lblTiengAnhB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTiengAnhB.Name = "lblTiengAnhB";
            this.lblTiengAnhB.Size = new System.Drawing.Size(85, 16);
            this.lblTiengAnhB.TabIndex = 14;
            this.lblTiengAnhB.Text = "600.000 đồng";
            this.lblTiengAnhB.Click += new System.EventHandler(this.label15_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhTien.ForeColor = System.Drawing.Color.Blue;
            this.btnTinhTien.Location = new System.Drawing.Point(135, 462);
            this.btnTinhTien.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(113, 34);
            this.btnTinhTien.TabIndex = 10;
            this.btnTinhTien.Text = "Tính Tiền";
            this.btnTinhTien.UseVisualStyleBackColor = true;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancle.ForeColor = System.Drawing.Color.Red;
            this.btnCancle.Location = new System.Drawing.Point(286, 461);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(114, 35);
            this.btnCancle.TabIndex = 11;
            this.btnCancle.Text = "Cancle";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Blue;
            this.btnExit.Location = new System.Drawing.Point(424, 462);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 34);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboMaHV
            // 
            this.cboMaHV.FormattingEnabled = true;
            this.cboMaHV.Location = new System.Drawing.Point(180, 120);
            this.cboMaHV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboMaHV.Name = "cboMaHV";
            this.cboMaHV.Size = new System.Drawing.Size(109, 23);
            this.cboMaHV.TabIndex = 0;
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.Location = new System.Drawing.Point(440, 121);
            this.rdNam.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(52, 20);
            this.rdNam.TabIndex = 1;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            this.rdNam.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.Location = new System.Drawing.Point(511, 122);
            this.rdNu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(43, 20);
            this.rdNu.TabIndex = 2;
            this.rdNu.TabStop = true;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(180, 175);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(374, 23);
            this.txtHoTen.TabIndex = 3;
            // 
            // chbTinHocA
            // 
            this.chbTinHocA.AutoSize = true;
            this.chbTinHocA.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.chbTinHocA.Location = new System.Drawing.Point(145, 273);
            this.chbTinHocA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chbTinHocA.Name = "chbTinHocA";
            this.chbTinHocA.Size = new System.Drawing.Size(82, 20);
            this.chbTinHocA.TabIndex = 5;
            this.chbTinHocA.Text = "Tin học A";
            this.chbTinHocA.UseVisualStyleBackColor = true;
            this.chbTinHocA.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chbTinHocB
            // 
            this.chbTinHocB.AutoSize = true;
            this.chbTinHocB.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.chbTinHocB.Location = new System.Drawing.Point(145, 314);
            this.chbTinHocB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chbTinHocB.Name = "chbTinHocB";
            this.chbTinHocB.Size = new System.Drawing.Size(82, 20);
            this.chbTinHocB.TabIndex = 6;
            this.chbTinHocB.Text = "Tin học B";
            this.chbTinHocB.UseVisualStyleBackColor = true;
            this.chbTinHocB.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chbTiengAnhA
            // 
            this.chbTiengAnhA.AutoSize = true;
            this.chbTiengAnhA.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.chbTiengAnhA.Location = new System.Drawing.Point(145, 354);
            this.chbTiengAnhA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chbTiengAnhA.Name = "chbTiengAnhA";
            this.chbTiengAnhA.Size = new System.Drawing.Size(94, 20);
            this.chbTiengAnhA.TabIndex = 7;
            this.chbTiengAnhA.Text = "Tiếng anh A";
            this.chbTiengAnhA.UseVisualStyleBackColor = true;
            this.chbTiengAnhA.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // chbTiengAnhB
            // 
            this.chbTiengAnhB.AutoSize = true;
            this.chbTiengAnhB.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.chbTiengAnhB.Location = new System.Drawing.Point(145, 395);
            this.chbTiengAnhB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chbTiengAnhB.Name = "chbTiengAnhB";
            this.chbTiengAnhB.Size = new System.Drawing.Size(94, 20);
            this.chbTiengAnhB.TabIndex = 8;
            this.chbTiengAnhB.Text = "Tiếng anh B";
            this.chbTiengAnhB.UseVisualStyleBackColor = true;
            this.chbTiengAnhB.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // dtpNgayDangKi
            // 
            this.dtpNgayDangKi.Location = new System.Drawing.Point(180, 225);
            this.dtpNgayDangKi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpNgayDangKi.Name = "dtpNgayDangKi";
            this.dtpNgayDangKi.Size = new System.Drawing.Size(374, 23);
            this.dtpNgayDangKi.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(177, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(293, 426);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(213, 23);
            this.txtTongTien.TabIndex = 9;
            // 
            // frmTrungTam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 520);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpNgayDangKi);
            this.Controls.Add(this.chbTiengAnhB);
            this.Controls.Add(this.chbTiengAnhA);
            this.Controls.Add(this.chbTinHocB);
            this.Controls.Add(this.chbTinHocA);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.rdNu);
            this.Controls.Add(this.rdNam);
            this.Controls.Add(this.cboMaHV);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.lblTiengAnhB);
            this.Controls.Add(this.lblTiengAnhA);
            this.Controls.Add(this.lblTinHocB);
            this.Controls.Add(this.lblTinHocA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmTrungTam";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTinHocA;
        private System.Windows.Forms.Label lblTinHocB;
        private System.Windows.Forms.Label lblTiengAnhA;
        private System.Windows.Forms.Label lblTiengAnhB;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cboMaHV;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.CheckBox chbTinHocA;
        private System.Windows.Forms.CheckBox chbTinHocB;
        private System.Windows.Forms.CheckBox chbTiengAnhA;
        private System.Windows.Forms.CheckBox chbTiengAnhB;
        private System.Windows.Forms.DateTimePicker dtpNgayDangKi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

