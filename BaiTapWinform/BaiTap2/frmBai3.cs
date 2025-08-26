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
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            string s = "";
            if (rdNoiChuoi.Checked)
            {
                HamTinh.NoiChuoi(txtHo.Text, txtTen.Text, ref s);

                lblKQ.Text = s;
            }
            if (rdGiaiThua.Checked)
            {
                int n = int.Parse(txtSoN.Text);
                lblKQ.Text = HamTinh.GiaiThua(n).ToString();
            }
                
        }
    }
}

