using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapWinform
{
    internal class HangHoa
    {
        public string MaHang { get; set; }

        public string TenHang { get; set; }
        public string DVT { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }

        public HangHoa()
        {
            
        }

        public string HienThi()
        {
            return String.Format("{0,-10} {1,-20} {2,-10} {3,10} {4,15}", MaHang, TenHang, DVT, SoLuong, DonGia);
        }
    }
}
