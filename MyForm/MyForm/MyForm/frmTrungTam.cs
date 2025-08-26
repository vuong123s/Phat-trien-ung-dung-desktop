using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MyForm
{
    public partial class frmTrungTam : Form
    {
        public frmTrungTam()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            int s = 0;
            if (chbTiengAnhA.Checked) s += int.Parse(lblTiengAnhA.Text.Split('.')[0]);
            if (chbTiengAnhB.Checked) s += int.Parse(lblTiengAnhB.Text.Split('.')[0]);

            if (chbTinHocA.Checked) s += int.Parse(lblTinHocA.Text.Split('.')[0]);

            if (chbTinHocB.Checked) s += int.Parse(lblTinHocB.Text.Split('.')[0]);

            this.txtTongTien.Text = s + ".000 đồng";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Reset()
        {
            this.cboMaHV.Text = "";
            this.txtHoTen.Text = "";
            this.dtpNgayDangKi.Value = DateTime.Now;
            this.rdNam.Checked = true;
            this.chbTinHocA.Checked = false;
            this.chbTinHocB.Checked = false;
            this.chbTiengAnhA.Checked = false;
            this.chbTiengAnhB.Checked = false;
            this.txtTongTien.Text = "";
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Reset();
        }
    }
}
