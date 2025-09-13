using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    public class DanhSachSinhVien
    {
        public ArrayList dsSinhVien;

        public DanhSachSinhVien()
        {
            dsSinhVien = new ArrayList();
        }

        public void Them(SinhVien sv)
        {
            dsSinhVien.Add(sv);
        }

        public void DocTuFile(string filename)
        {
            string t;
            string[] s;
            SinhVien sv;
            using (StreamReader sr = new StreamReader(
                new FileStream(filename, FileMode.Open)))
            {
                while ((t = sr.ReadLine()) != null)
                {
                    s = t.Split(',');
                    if (s.Length < 9) continue; 

                    sv = new SinhVien();
                    sv.MaSo = s[0];
                    sv.HoTen = s[1];
                    DateTime ngaySinh;
                    if (!DateTime.TryParse(s[2], out ngaySinh))
                        ngaySinh = DateTime.Now;
                    sv.NgaySinh = ngaySinh;
                    sv.DiaChi = s[3];
                    sv.Lop = s[4];
                    sv.Hinh = s[5];
                    sv.Email = s[6];
                    sv.GioiTinh = s[7] == "1";
                    sv.SDT = s[8];

                    this.Them(sv);
                }
            }
        }

        public SinhVien this[int index]
        {
            get { return dsSinhVien[index] as SinhVien; }
            set { dsSinhVien[index] = value; }
        }
    }
}
