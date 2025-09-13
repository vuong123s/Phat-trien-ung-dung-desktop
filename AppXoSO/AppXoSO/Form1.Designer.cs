namespace AppXoSO
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cbVung;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSo;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.ComboBox cboDai;
        private System.Windows.Forms.Button btnKiemTra;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cbVung = new System.Windows.Forms.ComboBox();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.cboDai = new System.Windows.Forms.ComboBox();
            this.txtSo = new System.Windows.Forms.TextBox();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbVung
            // 
            this.cbVung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVung.Items.AddRange(new object[] {
            "Miền Bắc",
            "Miền Trung",
            "Miền Nam"});
            this.cbVung.Location = new System.Drawing.Point(3, 21);
            this.cbVung.Name = "cbVung";
            this.cbVung.Size = new System.Drawing.Size(177, 24);
            this.cbVung.TabIndex = 2;
            this.cbVung.SelectedIndexChanged += new System.EventHandler(this.cbVung_SelectedIndexChanged);
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.ColumnHeadersHeight = 29;
            this.dgvKetQua.Location = new System.Drawing.Point(210, 12);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersWidth = 51;
            this.dgvKetQua.Size = new System.Drawing.Size(762, 538);
            this.dgvKetQua.TabIndex = 0;
            this.dgvKetQua.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQua_CellContentClick);
            this.dgvKetQua.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQua_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKiemTra);
            this.groupBox1.Controls.Add(this.cboDai);
            this.groupBox1.Controls.Add(this.txtSo);
            this.groupBox1.Controls.Add(this.dtNgay);
            this.groupBox1.Controls.Add(this.cbVung);
            this.groupBox1.Location = new System.Drawing.Point(15, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 260);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(44, 193);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(100, 25);
            this.btnKiemTra.TabIndex = 11;
            this.btnKiemTra.Text = "Dò số";
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // cboDai
            // 
            this.cboDai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDai.Location = new System.Drawing.Point(3, 62);
            this.cboDai.Name = "cboDai";
            this.cboDai.Size = new System.Drawing.Size(177, 24);
            this.cboDai.TabIndex = 10;
            this.cboDai.SelectedIndexChanged += new System.EventHandler(this.cboDai_SelectedIndexChanged);
            // 
            // txtSo
            // 
            this.txtSo.Location = new System.Drawing.Point(3, 146);
            this.txtSo.Name = "txtSo";
            this.txtSo.Size = new System.Drawing.Size(177, 22);
            this.txtSo.TabIndex = 5;
            // 
            // dtNgay
            // 
            this.dtNgay.CustomFormat = "dd/MM/yyyy";
            this.dtNgay.Location = new System.Drawing.Point(3, 102);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(177, 22);
            this.dtNgay.TabIndex = 6;
            this.dtNgay.Value = new System.DateTime(2025, 9, 10, 0, 0, 0, 0);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvKetQua);
            this.Name = "Form1";
            this.Text = "Ứng dụng Xổ số";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
