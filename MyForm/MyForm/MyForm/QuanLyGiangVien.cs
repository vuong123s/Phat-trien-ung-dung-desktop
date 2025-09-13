using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    public enum KieuTim
    {
        TheoMa,
        TheoHoTen,
        TheoSDT
    }

    public class QuanLyGiangVien
    {
        public List<GiangVien> dsGiangVien;

        
        public GiangVien this[int index]
        {
            get { return dsGiangVien[index]; }
            set { dsGiangVien[index] = value; }
        }

        
        public QuanLyGiangVien()
        {
            dsGiangVien = new List<GiangVien>();

            GiangVien gv1 = new GiangVien(
                "GV001",
                "Nguyễn Văn An",
                new DateTime(1980, 3, 12),
                new DanhSachHocPhan(),
                "Nam",
                new string[] { "Tiếng Anh" },
                "0912345678",
                "an.nguyen@dlu.edu.vn"
            );


            GiangVien gv2 = new GiangVien(
                "GV002",
                "Trần Thị Bình",
                new DateTime(1985, 7, 25),
                new DanhSachHocPhan(),
                "Nữ",
                new string[] { "Tiếng Pháp" },
                "0987654321",
                "binh.tran@dlu.edu.vn"
            );


            GiangVien gv3 = new GiangVien(
                "GV003",
                "Lê Hoàng Cường",
                new DateTime(1978, 11, 5),
                new DanhSachHocPhan(),
                "Nam",
                new string[] { "Tiếng Nhật", "Tiếng Anh" },
                "0905123456",
                "cuong.le@dlu.edu.vn"
            );


            GiangVien gv4 = new GiangVien(
                "GV004",
                "Phạm Thị Dung",
                new DateTime(1990, 1, 17),
                new DanhSachHocPhan(),
                "Nữ",
                new string[] { "Tiếng Anh", "Tiếng Trung" },
                "0932123456",
                "dung.pham@dlu.edu.vn"
            );


            GiangVien gv5 = new GiangVien(
                "GV005",
                "Đỗ Minh Tuấn",
                new DateTime(1983, 9, 9),
                new DanhSachHocPhan(),
                "Nam",
                new string[] { "Tiếng Anh" },
                "0977123456",
                "tuan.do@dlu.edu.vn"
            );


            dsGiangVien.Add(gv1);
            dsGiangVien.Add(gv2);
            dsGiangVien.Add(gv3);
            dsGiangVien.Add(gv4);
            dsGiangVien.Add(gv5);
        }

        
        public bool Them(GiangVien gv)
        {
            foreach (var item in dsGiangVien)
            {
                if (item.MaSo == gv.MaSo) return false; 
            }
            dsGiangVien.Add(gv);
            return true;
        }

        
        public GiangVien Tim(object temp, SoSanh ss)
        {
            foreach (var gv in dsGiangVien)
            {
                if (ss(gv, temp) == 0)
                {
                    return gv;
                }
            }
            return null;
        }

        
        public GiangVien Xoa(object temp, SoSanh ss)
        {
            for (int i = 0; i < dsGiangVien.Count; i++)
            {
                if (ss(dsGiangVien[i], temp) == 0)
                {
                    GiangVien gv = dsGiangVien[i];
                    dsGiangVien.RemoveAt(i);
                    return gv;
                }
            }
            return null;
        }

        
        public void SapXep(SoSanh ss)
        {
            dsGiangVien.Sort((gv1, gv2) => ss(gv1, gv2));
        }
    }
}
