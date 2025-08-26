using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap4
{
    internal class HamTinh
    {
        public static void ChaoHoi(string hoten, bool gioitinh)
        {
            if (gioitinh) MessageBox.Show("Chào ông " + hoten);
            else MessageBox.Show("Chào bà " + hoten);
        }

        public static int UCLN(int m, int n)
        {
            while (n != 0)
            {
                int temp = n;
                n = m % n;
                m = temp;
            }
            return Math.Abs(m);
        }
    }
}
