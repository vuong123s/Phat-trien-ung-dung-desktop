﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public partial class frmDSSV : Form
    {
        QuanLySinhVien ql;
        public frmDSSV()
        {
            InitializeComponent();
            ql = new QuanLySinhVien();
        }

        public frmDSSV(QuanLySinhVien qlsv)
        {
            InitializeComponent();
            ql = qlsv;
        }


        private void groupboxDSSV_Enter(object sender, EventArgs e)
        {

        }

        public void SapXep(QuanLySinhVien ds)
        {

        }

        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.HoTen);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Lop);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            string cn = "";
            foreach (string s in sv.ChuyenNganh)
                cn += s + " ,";
            cn = cn.Substring(0, cn.Length - 1);
            lvitem.SubItems.Add(cn);
            lvitem.SubItems.Add(sv.Hinh);
            this.lvSinhVien.Items.Add(lvitem);
        }
        

        private void LoadListView(QuanLySinhVien qlsv)
        {
            this.lvSinhVien.Items.Clear();

            foreach (SinhVien sv in qlsv.dsSinhVien)
            {
                ThemSV(sv);
            }
        }

        private void frmDSSV_Load(object sender, EventArgs e)
        {
            LoadListView(ql);
            
        }
    }
}
