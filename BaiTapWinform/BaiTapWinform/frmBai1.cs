using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapWinform
{
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void frmBai1_Load(object sender, EventArgs e)
        {
            HangHoa hh1 = new HangHoa();
            hh1.MaHang = "MH01";
            hh1.TenHang = "Bút bi Thiên Long";
            hh1.DVT = "Cây";
            hh1.SoLuong = 100;
            hh1.DonGia = 5000;

            lblThongTinHH.Text = hh1.HienThi();
        }
    }
}
