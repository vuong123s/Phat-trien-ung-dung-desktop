using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    internal class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public float HeSoLuong { get; set; }
        public float HeSoPhuCap { get; set; }
        public NhanVien()
        {

        }

        public NhanVien(string maNV, string tenNV, DateTime ngaySinh, float heSoLuong, float heSoPhuCap)
        {
            MaNV = maNV;
            TenNV = tenNV;
            NgaySinh = ngaySinh;
            HeSoLuong = heSoLuong;
            HeSoPhuCap = heSoPhuCap;
        }

        public float TongLuong()
        {
            return (HeSoLuong + HeSoPhuCap) * 1150000;
        }

        public string HienThi()
        {
            return String.Format($"Mã NV: {MaNV}, Tên NV: {TenNV}, Ngày sinh: {NgaySinh.ToShortDateString()}, Hệ số lương: {HeSoLuong}, Hệ số phụ cấp: {HeSoPhuCap}, Tổng lương: {TongLuong()}");
        }
    }
}