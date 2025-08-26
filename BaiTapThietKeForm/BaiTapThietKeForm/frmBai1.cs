using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapThietKeForm
{
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rdDo_CheckedChanged(object sender, EventArgs e)
        {
            if(rdDo.Checked) 
                txtDonGia.Text = "21000";
        }

        private void rdXanh_CheckedChanged(object sender, EventArgs e)
        {
            if (rdXanh.Checked)
                txtDonGia.Text = "22000";
        }

        private void rdTrang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTrang.Checked)
                txtDonGia.Text = "20000";
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            lblTongTien.Text  = (Convert.ToInt64(txtSoLuong.Text) * Convert.ToInt64(txtDonGia.Text)).ToString();
        }
    }
}
