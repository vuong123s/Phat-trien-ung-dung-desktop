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
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void frmBai1_Load(object sender, EventArgs e)
        {
            ThietBi tb1 = new ThietBi("TB01", "Điện thoại", "Hàn Quốc", 5000000, 2);
            lblThongTinTT.Text = tb1.HienThi();
        }

        private void lblThongTinTT_Click(object sender, EventArgs e)
        {

        }
    }
}
