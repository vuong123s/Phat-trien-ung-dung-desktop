using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    internal class HamTinh
    {
        public static void TachChuoi(string hoTen, ref string ho, ref string ten)
        {
            string[] parts = hoTen.Trim().Split(' ');
            ho = parts[0];
            ten = parts[parts.Length - 1];
        }

        public static bool ThuTu(int n1, int n2)
        {
             if(n2 == n1 + 1)
                return true;
            else
                return false;
        }

    }
}
