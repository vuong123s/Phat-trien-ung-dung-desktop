using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Lab05
{
    public partial class Form2 : Form
    {
        QuanLySinhVien qlsv;
        bool dsSinhVienDaChinhSua = false;
        string loai = "";
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string type)
        {
            InitializeComponent();
            loai = type;
        }
        #region phuong thuc bo tro
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = false;
            List<string> mhdk = new List<string>();
            sv.MSSV = mtbMSSV.Text;
            sv.HoLot = txtHoLot.Text;
            sv.Ten = txtTen.Text;
            if (rdNam.Checked)
                gt = true;
            sv.GioiTinh = gt;
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.Lop = cbbLop.Text;
            sv.CMND = mtbCMND.Text;
            sv.SoDT = mtbSoDT.Text;
            sv.DiaChi = txtDiaChi.Text;
            for(int i = 0; i < this.clbMonHocDK.Items.Count; i++)
            {
                if (clbMonHocDK.GetItemChecked(i))
                    mhdk.Add(clbMonHocDK.Items[i].ToString());
            }
            sv.MonHocDK = mhdk;
            return sv;
        }
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = lvitem.SubItems[0].Text;
            sv.HoLot = lvitem.SubItems[1].Text;
            sv.Ten = lvitem.SubItems[2].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[3].Text == "Nam")
                sv.GioiTinh = true;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[4].Text);
            sv.Lop = lvitem.SubItems[5].Text;
            sv.CMND = lvitem.SubItems[6].Text;
            sv.SoDT = lvitem.SubItems[7].Text;
            sv.DiaChi = lvitem.SubItems[8].Text;
            List<string> mhdk = new List<string>();
            string[] s = lvitem.SubItems[9].Text.Split(',');
            foreach(string i in s) 
                mhdk.Add(i);
            sv.MonHocDK = mhdk;
            return sv;
        }
        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtbMSSV.Text = sv.MSSV;
            this.txtHoLot.Text = sv.HoLot;
            this.txtTen.Text = sv.Ten;
            if (sv.GioiTinh == true)
                rdNam.Checked = true;
            else rdNu.Checked = true;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.cbbLop.Text = sv.Lop;
            this.mtbCMND.Text = sv.CMND;
            this.mtbSoDT.Text = sv.SoDT;
            this.txtDiaChi.Text = sv.DiaChi;
            for (int i = 0; i < clbMonHocDK.Items.Count; i++)
                this.clbMonHocDK.SetItemChecked(i, false);
            foreach(string s in sv.MonHocDK)
            {
                for (int i = 0; i < clbMonHocDK.Items.Count; i++)
                {
                    if (s.CompareTo(clbMonHocDK.Items[i]) == 0)
                        this.clbMonHocDK.SetItemChecked(i, true);
                }
            }
        }
        private void ThemSinhVienVaoLV(SinhVien sv)
        {
            ListViewItem item = new ListViewItem(sv.MSSV);
            item.SubItems.Add(sv.HoLot);
            item.SubItems.Add(sv.Ten);
            string gt = "Nam";
            if (!sv.GioiTinh)
                gt = "Nữ";
            item.SubItems.Add(gt);
            item.SubItems.Add(sv.NgaySinh.ToShortDateString());
            item.SubItems.Add(sv.Lop);
            item.SubItems.Add(sv.CMND);
            item.SubItems.Add(sv.SoDT);
            item.SubItems.Add(sv.DiaChi);
            string mhdk = "";
            if (sv.MonHocDK.Count != 0)
            {
                foreach (string s in sv.MonHocDK)
                    mhdk += s + ",";
                mhdk = mhdk.Substring(0, mhdk.Length - 1);
            }
            item.SubItems.Add(mhdk);
            lvDSSV.Items.Add(item);
        }
        private void LoadListView(List<SinhVien> ds)
        {
            this.lvDSSV.Items.Clear();
            foreach (SinhVien sv in ds)
            {
                ThemSinhVienVaoLV(sv);
            }
        }
        private void LuuVaoFile(string filename)
        {
            SinhVien sv;
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    foreach (ListViewItem lvitem in lvDSSV.Items)
                    {
                        sv = GetSinhVienLV(lvitem);
                        string gt = "Nữ";
                        if (sv.GioiTinh == true)
                            gt = "Nam";
                        string mhdk = "";
                        if (sv.MonHocDK.Count != 0)
                        {
                            foreach (string s in sv.MonHocDK)
                                mhdk += s + ",";
                            mhdk = mhdk.Substring(0, mhdk.Length - 1);
                        }
                        sw.WriteLine($"{sv.MSSV}*{sv.HoLot}*{sv.Ten}*{gt}*{sv.NgaySinh}*{sv.Lop}*{sv.CMND}*{sv.SoDT}*{sv.DiaChi}*{mhdk}*");
                    }

                }
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show($"Xảy ra lỗi khi lưu file: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GhiFileJSON(string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(qlsv.DanhSach, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, json);
                MessageBox.Show("Đã ghi danh sách sinh viên ra file JSON thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file JSON: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GhiFileXML(string filePath)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8
            };

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ArrayOfSudents");

                foreach (var sv in qlsv.DanhSach)
                {
                    writer.WriteStartElement("Student");

                    writer.WriteElementString("MSSV", sv.MSSV);
                    writer.WriteElementString("HoLot", sv.HoLot);
                    writer.WriteElementString("Ten", sv.Ten);
                    writer.WriteElementString("GioiTinh", sv.GioiTinh ? "Nam" : "Nu");
                    writer.WriteElementString("NgaySinh", sv.NgaySinh.ToString("M/d/yyyy hh:mm:ss tt"));
                    writer.WriteElementString("Lop", sv.Lop);
                    writer.WriteElementString("CMND", sv.CMND);
                    writer.WriteElementString("SoDT", sv.SoDT);
                    writer.WriteElementString("DiaChi", sv.DiaChi);
                    string monHocStr = (sv.MonHocDK != null && sv.MonHocDK.Count > 0)
                        ? string.Join(",", sv.MonHocDK)
                        : "";
                    writer.WriteElementString("MonHocDK", monHocStr);

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        #endregion
        #region su kien
        private void Form2_Load(object sender, EventArgs e)
        {
            if(loai == "XML")
            {
                qlsv = new QuanLySinhVien();
                qlsv.DocFileXML("DSSV.xml");
                LoadListView(qlsv.DanhSach);
            }
            else if(loai == "JSON")
            {
                qlsv = new QuanLySinhVien();
                qlsv.DocFileJSON("DSSV.json");
                LoadListView(qlsv.DanhSach);
            }
            else
            {
                qlsv = new QuanLySinhVien();
                qlsv.DocFileTXT("DSSV.txt");
                LoadListView(qlsv.DanhSach);
            }
        }

        private void lvDDSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvDSSV.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvDSSV.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTinNhap()) return;
            dsSinhVienDaChinhSua = true;
            SinhVien sv = GetSinhVien();
            SinhVien kq = qlsv.Tim(sv.MSSV, SoSanhTheoMa);
            if (kq != null)
            {
                MessageBox.Show("Sinh vien da ton tai", "Insert data error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                qlsv.Them(sv);
                this.LoadListView(qlsv.DanhSach);
            }

        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = (SinhVien)obj2;
            return sv.MSSV.CompareTo(obj1);
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dsSinhVienDaChinhSua)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu danh sách sinh viên đã thay đổi?", "Lưu danh sách", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    if(loai == "XML")
                    {
                        GhiFileXML("DSSV.xml");
                    }
                    else if(loai == "JSON")
                    {
                        GhiFileJSON("DSSV.json");
                    }
                    else
                    {
                        LuuVaoFile("DSSV.txt");
                    }
                }
            }
        }

        private bool KiemTraThongTinNhap()
        {
            
            if (string.IsNullOrWhiteSpace(mtbMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbMSSV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoLot.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ lót!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoLot.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return false;
            }

            if (!rdNam.Checked && !rdNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpNgaySinh.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbbLop.Text))
            {
                MessageBox.Show("Vui lòng chọn Lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(mtbCMND.Text))
            {
                MessageBox.Show("Vui lòng nhập CMND!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbCMND.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(mtbSoDT.Text))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbSoDT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            bool coMonHoc = false;
            foreach (int i in clbMonHocDK.CheckedIndices)
            {
                coMonHoc = true;
                break;
            }
            if (!coMonHoc)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một môn học đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTinNhap()) return;
            dsSinhVienDaChinhSua = true;
            SinhVien sv = GetSinhVien();
            bool kqsua;
            kqsua = qlsv.Sua(sv, sv.MSSV, SoSanhTheoMa);
            if (kqsua)
                LoadListView(qlsv.DanhSach);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var frm = new frmTimKiem();
            
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var searchTerm = frm.ChuoiTimKiem;
                var chon = frm.chon;
                

                var dssv = qlsv.TimKiemSV_TheoTuyChon(searchTerm, chon);

                if (dssv.Count == 0)
                {
                    MessageBox.Show("Khong tim thay sinh vien", "Thong bao");
                }
                else
                {
                    LoadListView(dssv);
                    
                }
            }
        }

       

        private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dsSinhVienDaChinhSua = true;
            ListViewItem lvitem;
            for(int i = lvDSSV.Items.Count - 1; i >= 0; i--)
            {
                lvitem = lvDSSV.Items[i];
                if(lvitem.Checked == true)
                {
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
                }
            }
            this.LoadListView(qlsv.DanhSach);
        }
        #endregion

        private void clbMonHocDK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
