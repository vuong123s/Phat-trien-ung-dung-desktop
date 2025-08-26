using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    public class GiangVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public DanhSachHocPhan dsHocPhan;
        public string GioiTinh;
        public string[] NgoaiNgu;
        public string SoDT;
        public string Mail;
        public GiangVien() { 
            dsHocPhan = new DanhSachHocPhan();
            NgoaiNgu = new string[20];
        }

        public GiangVien (string maSo, string hoTen, DateTime ngaySinh, DanhSachHocPhan dsHocPhan, string gioiTinh, 
            string[] ngoaiNgu, string soDT, string mail)
        {
            MaSo = maSo;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            this.dsHocPhan = dsHocPhan;
            GioiTinh = gioiTinh;
            NgoaiNgu = ngoaiNgu;
            SoDT = soDT;
            Mail = mail;
        }

        public override string ToString()
        {
            string s = "Mã số: " + MaSo + "\n"
                +"Họ Tên: "+ HoTen + "\n"
                +"Ngày Sinh: "+ NgaySinh + "\n"
                +"Giới tính: " + GioiTinh + "\n"
                +"Số DT: "+ SoDT + "\n"
                +"Mail: "+ Mail + "\n";
            string sngoaingu = "Ngoại ngữ: ";
            foreach(string t in NgoaiNgu)
            {
                sngoaingu += t + ";";
            }

            string monDay = "Danh sách môn dạy: ";

            foreach(HocPhan hp in dsHocPhan.ds)
            {
                monDay += hp + ";";
            }
            s += "\n" + sngoaingu + "\n" + monDay;
            return s;

        }
    }
}
