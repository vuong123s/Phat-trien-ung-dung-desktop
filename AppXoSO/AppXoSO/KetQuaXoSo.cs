using System;
using System.Collections.Generic;

namespace AppXoSO
{
    public class KetQuaXoSo
    {
        public string Tinh { get; set; } = "";
        public DateTime? Ngay { get; set; } = null;

        public List<string> GiaiDB { get; set; } = new List<string>();
        public List<string> Giai1 { get; set; } = new List<string>();
        public List<string> Giai2 { get; set; } = new List<string>();
        public List<string> Giai3 { get; set; } = new List<string>();
        public List<string> Giai4 { get; set; } = new List<string>();
        public List<string> Giai5 { get; set; } = new List<string>();
        public List<string> Giai6 { get; set; } = new List<string>();
        public List<string> Giai7 { get; set; } = new List<string>();

        // Optional: raw text for debugging
        public string Raw { get; set; } = "";

        public override string ToString()
        {
            return $"{Tinh} (DB:{string.Join(",", GiaiDB)})";
        }
    }
}
