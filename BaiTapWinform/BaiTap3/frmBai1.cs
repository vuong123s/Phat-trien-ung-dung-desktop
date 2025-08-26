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
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void frmBai1_Load(object sender, EventArgs e)
        {
            NhanVien nv1 = new NhanVien("NV01", "Nguyễn Văn A", DateTime.Parse("20/10/2005"), 0.85f, 0.2f);
            lblThongTinNV.Text = nv1.HienThi();
        }
    }
}
