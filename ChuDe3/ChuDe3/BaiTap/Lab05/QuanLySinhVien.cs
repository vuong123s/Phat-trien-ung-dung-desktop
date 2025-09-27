using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Lab05
{
    public delegate int SoSanh(object obj1, object obj2);
    public enum TuyChon
    {
        MSSV,
        Ten,
        Lop
    }
    class QuanLySinhVien
    {
        public List<SinhVien> DanhSach;
        public QuanLySinhVien()
        {
            DanhSach = new List<SinhVien>();
        }
        public SinhVien this[int index]
        {
            get
            {
                return DanhSach[index];
            }
            set
            {
                DanhSach[index] = value;
            }
        }
        public void Them(SinhVien sv)
        {
            this.DanhSach.Add(sv);
        }
        public void Xoa(object obj, SoSanh ss)
        {
            for(int i = DanhSach.Count - 1; i >= 0; i--)
            {
                if (ss(obj, this[i]) == 0)
                    this.DanhSach.RemoveAt(i);
            }
        }
        public SinhVien Tim(object obj, SoSanh ss )
        {
            SinhVien result = null;
            foreach(SinhVien sv in DanhSach)
            {
                if (ss(obj, sv) == 0)
                {
                    result = sv;
                    break;
                }
            }
            return result;
        } 
        public List<SinhVien> TimKiemSV_TheoTuyChon(string searchterm, TuyChon tc)
        {
            List<SinhVien> dssv = new List<SinhVien>();
            if(tc == TuyChon.MSSV)
            {
                foreach (SinhVien sv in DanhSach)
                {
                    if (sv.MSSV.Contains(searchterm))
                    {
                        dssv.Add(sv);
                    }
                }
            }
            if (tc == TuyChon.Ten)
            {
                foreach (SinhVien sv in DanhSach)
                {
                    if (sv.Ten.Contains(searchterm))
                    {
                        dssv.Add(sv);
                    }
                }
            }
            if (tc == TuyChon.Lop)
            {
                foreach (SinhVien sv in DanhSach)
                {
                    if (sv.Lop.Contains(searchterm))
                    {
                        dssv.Add(sv);
                    }
                }
            }
            return dssv;
        }
        public bool Sua(SinhVien svsua,  object obj, SoSanh ss)
        {
            bool kq = false;
            for(int i = 0; i < DanhSach.Count; i++)
            {
                if(ss(obj, this[i]) == 0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            }
            return kq;
        }
        
        public void DocFileTXT(string filename)
        {
            string t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader(
            new FileStream(filename, FileMode.Open));
            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split('*');
                bool gt = false;
                sv = new SinhVien();
                sv.MSSV = s[0];
                sv.HoLot = s[1];
                sv.Ten = s[2];
                if (s[3] == "Nam")
                    gt = true;
                sv.GioiTinh = gt;
                sv.NgaySinh = DateTime.Parse(s[4]);
                sv.Lop = s[5];
                sv.CMND = s[6];
                sv.SoDT = s[7];
                sv.DiaChi = s[8];
                string[] mhdk = s[9].Split(',');
                List<string> monhocdk = new List<string>();
                foreach (string m in mhdk)
                    monhocdk.Add(m);
                sv.MonHocDK = monhocdk;
                this.Them(sv);
            }
            sr.Close();
        }
        public void DocFileXML(string filePath)
        {
            if (!File.Exists(filePath)) return;

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            DanhSach = new List<SinhVien>();

            foreach (XmlNode node in doc.DocumentElement.SelectNodes("Student"))
            {
                string mssv = node["MSSV"]?.InnerText;
                string hoLot = node["HoLot"]?.InnerText;
                string ten = node["Ten"]?.InnerText;

                bool gioiTinh = false;
                if (node["GioiTinh"] != null)
                    gioiTinh = node["GioiTinh"].InnerText.Trim().ToLower() == "nam";

                DateTime ngaySinh = DateTime.Parse(node["NgaySinh"]?.InnerText);
                string lop = node["Lop"]?.InnerText;
                string cmnd = node["CMND"]?.InnerText;
                string soDT = node["SoDT"]?.InnerText;
                string diaChi = node["DiaChi"]?.InnerText;
                List<string> monHoc = new List<string>();
                if (node["MonHocDK"] != null)
                {
                    monHoc = node["MonHocDK"].InnerText
                                .Split(',')
                                .Select(m => m.Trim())
                                .ToList();
                }
                SinhVien sv = new SinhVien(mssv, hoLot, ten, gioiTinh, ngaySinh, lop, cmnd, soDT, diaChi, monHoc);
                DanhSach.Add(sv);
            }
        }





        public void DocFileJSON(string filePath)
        {
            if (!File.Exists(filePath)) return;

            string jsonData = File.ReadAllText(filePath);

            DanhSach = JsonConvert.DeserializeObject<List<SinhVien>>(jsonData);

            if (DanhSach == null)
                DanhSach = new List<SinhVien>();
        }

    }
}
