using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public partial class frmTimGV : Form
    {
        public frmTimGV()
        {
            InitializeComponent();
        }
        QuanLyGiangVien ds;
        private void frmTimGV_Load(object sender, EventArgs e)
        {
            ds = new QuanLyGiangVien();
            
        }

        private void lblLoaiTim_Click(object sender, EventArgs e)
        {

        }

        private void rdHoTen_CheckedChanged(object sender, EventArgs e)
        {
            lblLoaiTim .Text = "Họ Tên";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rdGV_CheckedChanged(object sender, EventArgs e)
        {
            lblLoaiTim.Text = "Mã GV";
        }

        private void rdSDT_CheckedChanged(object sender, EventArgs e)
        {
            lblLoaiTim.Text = "Số Điện Thoại";
        }

        // So sánh theo mã
        public int SoSanhTheoMa(object a, object b)
        {
            GiangVien gv = a as GiangVien;
            string ma = b as string;
            return string.Compare(gv.MaSo, ma, true);
        }

        // So sánh theo họ tên
        public int SoSanhTheoHoTen(object a, object b)
        {
            GiangVien gv = a as GiangVien;
            string ten = b as string;
            return string.Compare(gv.HoTen, ten, true);
        }

        // So sánh theo số điện thoại
        public int SoSanhTheoSDT(object a, object b)
        {
            GiangVien gv = a as GiangVien;
            string sdt = b as string;
            return string.Compare(gv.SoDT, sdt, true);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string key = txtTim.Text.Trim(); 
            GiangVien kq = null;
            if (rdHoTen.Checked)
            {
                kq = ds.Tim(key, SoSanhTheoHoTen);
            }
            else if (rdGV.Checked)
            {
                kq = ds.Tim(key, SoSanhTheoMa);
            }
            else if (rdSDT.Checked)
            {
                kq = ds.Tim(key, SoSanhTheoSDT);
            }

            if (kq != null)
            {
                frmTBGiangVien frm = new frmTBGiangVien(kq);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy giảng viên!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
