using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap4
{
    internal class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string LoaiSP { get; set; }
        public DateTime NgaySanXuat{ get; set; }
        public SanPham()
        {
            
        }

        public SanPham(string maSP, string tenSP, string loaiSP, DateTime ngaySanXuat)
        {
            MaSP = maSP;
            TenSP = tenSP;
            LoaiSP = loaiSP;
            NgaySanXuat = ngaySanXuat;
        }

        public int NamHetHan()
        {
            int namSX = NgaySanXuat.Year;
            int namHH = namSX + 3;
            int namHT = DateTime.Now.Year;
            return namHH - namHT;
        }

        public string HienThi()
        {
            return String.Format($"Mã SP: {MaSP}, Tên SP: {TenSP}, Loại SP: {LoaiSP}, Ngày sản xuất: {NgaySanXuat.ToShortDateString()}, Năm hết hạn: {NamHetHan()}");
        }
    }
}
