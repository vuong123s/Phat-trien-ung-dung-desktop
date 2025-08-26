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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnXL_Click(object sender, EventArgs e)
        {
            double dlt = double.Parse(txtDiemLT.Text);
            double dth = double.Parse(txtDiemTH.Text);
            double dtb = (dlt + dth) / 2;
            if (dlt > 10 && dth > 10)
            {
                MessageBox.Show("Điểm lý thuyết hoặc thực hành lớn hơn 10");
                txtDiemLT.Text = "";
                txtDiemTH.Text = "";
            }

            else
            {
                if (dlt < 5 || dth < 5)
                    lblXL.Text = "Yếu";
                else if (dtb < 7)
                    lblXL.Text = "Trung Bình";
                else if (dtb < 8) lblXL.Text = "Khá";
                else if (dtb < 9) lblXL.Text = "Giỏi";
                else lblXL.Text = "Xuất sắc";
            }
        }
    }
}
