using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab05
{
    [XmlRoot("Student")]
    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoLot { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string CMND { get; set; }
        public string SoDT { get; set; }
        public string DiaChi { get; set; }
        public List<string> MonHocDK { get; set; }

        public SinhVien()
        {

        }
        public SinhVien(string mssv, string holot, string ten, bool gt, DateTime ngaysinh, string lop, string cmnd, string sodt, string diachi, List<string> mhdk)
        {
            this.MSSV = mssv;
            this.HoLot = holot;
            this.Ten = ten;
            this.GioiTinh = gt;
            this.NgaySinh = ngaysinh;
            this.Lop = lop;
            this.CMND = cmnd;
            this.SoDT = sodt;
            this.DiaChi = diachi;
            this.MonHocDK = mhdk;
        }
    }
}
