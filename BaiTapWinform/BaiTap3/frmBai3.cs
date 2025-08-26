using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap3
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnThucThi_Click(object sender, EventArgs e)
        {
            if (rdTachChuoi.Checked)
            {
                string ho = "", ten = "";
                HamTinh.TachChuoi(txtHoTen.Text, ref ho, ref ten);
                lblKQ.Text = "Họ: " + ho;
                lblKQ1.Text = "Tên: " + ten;
            }
            else
            {
                lblKQ1.Text = "";
                int n1 = int.Parse(txtSoN1.Text);
                int n2 = int.Parse(txtSoN2.Text);
                lblKQ.Text = HamTinh.ThuTu(n1, n2) ? "Đúng" : "Sai";
            }
        }
    }
}
