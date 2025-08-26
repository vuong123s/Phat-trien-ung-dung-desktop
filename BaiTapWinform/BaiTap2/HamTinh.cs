using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap2
{
    internal class HamTinh
    {
        public static void NoiChuoi(string ho, string ten, ref string s)
        {
            s = string.Format("{0} {1}", ho, ten);
        }

        public static long GiaiThua(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            else
                return n * GiaiThua(n - 1);
        }
    }
}
