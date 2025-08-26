using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap4
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnThucThi_Click(object sender, EventArgs e)
        {
            
            if (rdThongBao.Checked)
            {
                string hoten = txtHoTen.Text;
                bool gioitinh = rdNam.Checked;
                HamTinh.ChaoHoi(hoten, gioitinh);
            }
            else
            {
                int m = int.Parse(txtSoM.Text);
                int n = int.Parse(txtSoN.Text);
                label5.Text = HamTinh.UCLN(m, n).ToString();
            }
        }
    }
}
