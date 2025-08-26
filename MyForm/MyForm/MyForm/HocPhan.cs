using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    public class HocPhan
    {
        public int ID { get; set; }
        public int SoTC { get; set; }
        public string TenHP { get; set; }

        public HocPhan() { }
        public HocPhan(string ten)
        {
            TenHP = ten;
        }

        public HocPhan(int id, string ten, int tc)
        {
            ID = id;
            SoTC = tc;
            TenHP = ten;
        }

        public override string ToString()
        {
            return TenHP;
        }
    }
}