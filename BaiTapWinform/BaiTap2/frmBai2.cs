using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap2
{
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnKQ_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtSoThuNhat.Text);
            int b = int.Parse(txtSoThuHai.Text);
            double kq;
            if (rdCong.Checked)
                kq = a + b;
            else if (rdTru.Checked)
                kq = a - b;
            else if (rdNhan.Checked)
                kq = a * b;
            else
                kq = (double)a / b;
            lblKetQua.Text = kq.ToString();

        }
    }
}
