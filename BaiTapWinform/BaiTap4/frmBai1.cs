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
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void frmBai1_Load(object sender, EventArgs e)
        {
            SanPham sp1 = new SanPham("SP01", "Sữa tắm", "Vệ sinh", DateTime.Parse("12/01/2023"));

            lblThongTin.Text = sp1.HienThi();
        }
    }
}
