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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnKQ_Click(object sender, EventArgs e)
        {
            int tong = 0;
            long giaiThua = 1;
            int n = int.Parse(txtSoN.Text);
            if (rdTong.Checked)
            {
                for (int i = 1; i <= n; i++)
                    tong += i;
                lblKQ.Text = tong.ToString();
            }
            else
            {
                for (int i = 1; i <= n; i++)
                    giaiThua *= i;
                lblKQ.Text = giaiThua.ToString();
            }
        }
    }
}
