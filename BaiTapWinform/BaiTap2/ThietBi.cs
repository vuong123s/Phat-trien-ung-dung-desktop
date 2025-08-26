using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap2
{
    internal class ThietBi
    {
        public string MaTB { get; set; }
        public string TenTB { get; set; }
        public string NuocSX { get; set; }
        public int DonGia { get; set; }
        public int SoLuong { get; set; }

        public ThietBi(string maTB, string tenTB, string nuocSX, int donGia, int soLuong)
        {
            MaTB = maTB;
            TenTB = tenTB;
            NuocSX = nuocSX;
            DonGia = donGia;
            SoLuong = soLuong;
        }
        public ThietBi()
        {
            
        }

        public int ThanhTien()
        {
            return DonGia * SoLuong;
        }   
        public string HienThi()
        {
            return String.Format($"Mã TB: {MaTB}, Tên TB: {TenTB}, Nước SX: {NuocSX}, Đơn giá: {DonGia}, Số lượng: {SoLuong}, Thành tiền: {ThanhTien()}");
        }
    }
}
