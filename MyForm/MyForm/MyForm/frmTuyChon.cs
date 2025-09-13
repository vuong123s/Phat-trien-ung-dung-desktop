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
    public partial class frmTuyChon : Form
    {
        public frmTuyChon()
        {
            InitializeComponent();
        }

        public enum TuyChon
        {
            MaSV,
            HoTen,
            NgaySinh
        }

        QuanLySinhVien ql;

        private void frmTuyChon_Load(object sender, EventArgs e)
        {
            ql = new QuanLySinhVien();
            ql.DocTuFile("DanhSachSV.txt");
        }

        

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            
            
            TuyChon tuyChonDuocChon = TuyChon.MaSV;
            if (rdSV.Checked)
                tuyChonDuocChon = TuyChon.MaSV;
            else if (rdHoTen.Checked)
                tuyChonDuocChon = TuyChon.HoTen;
            else if (rdNgaySinh.Checked)
                tuyChonDuocChon = TuyChon.NgaySinh;


            switch (tuyChonDuocChon)
            {
                case TuyChon.MaSV:
                    ql.dsSinhVien.Sort((sv1, sv2) => sv1.MaSo.CompareTo(sv2.MaSo));
                    break;
                case TuyChon.HoTen:
                    ql.dsSinhVien.Sort((sv1, sv2) => sv1.HoTen.CompareTo(sv2.HoTen));
                    break;
                case TuyChon.NgaySinh:
                    ql.dsSinhVien.Sort((sv1, sv2) => sv1.NgaySinh.CompareTo(sv2.NgaySinh));
                    break;
            }

            frmDSSV frm = new frmDSSV(ql);
            frm.ShowDialog();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTim.Text.Trim();
            List<SinhVien> ketQua = new List<SinhVien>();

            if (rdSV.Checked)
            {
                ketQua = ql.dsSinhVien
                    .Where(sv => sv.MaSo.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
            else if (rdHoTen.Checked)
            {
                ketQua = ql.dsSinhVien
                    .Where(sv => sv.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
            else if (rdNgaySinh.Checked)
            {
                ketQua = ql.dsSinhVien
                    .Where(sv => sv.NgaySinh.ToShortDateString().IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            if (ketQua.Count > 0)
            {
                QuanLySinhVien qlKetQua = new QuanLySinhVien();
                foreach (var sv in ketQua)
                    qlKetQua.Them(sv);
                frmDSSV frm = new frmDSSV(qlKetQua);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
