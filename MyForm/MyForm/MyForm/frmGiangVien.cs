using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyForm
{
    public partial class frmGiangVien : Form
    {
        public frmGiangVien()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        QuanLyGiangVien ds = new QuanLyGiangVien();
        private void ThemGV(GiangVien gv)
        {
            string ngoaiNgu = string.Join(", ", gv.NgoaiNgu.Where(x => !string.IsNullOrEmpty(x)));

            ListViewItem item = new ListViewItem(gv.MaSo);
            item.SubItems.Add(gv.HoTen);
            item.SubItems.Add(gv.NgaySinh.ToShortDateString());
            item.SubItems.Add(gv.GioiTinh);
            item.SubItems.Add(gv.SoDT);
            item.SubItems.Add(gv.Mail);
            item.SubItems.Add(ngoaiNgu);

            lvGiangVien.Items.Add(item);
        }
        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            string lienHe = "https://cntt.dlu.edu.vn";
            this.linklbLienHe.Links.Add(0, lienHe.Length, lienHe);
            //this.cboMaSo.SelectedItem = this.cboMaSo.Items[0];


            

            foreach (GiangVien gv in ds.dsGiangVien)
            {
                ThemGV(gv);
            }

        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i = this.lbDanhSachHP.SelectedItems.Count - 1;
            while(i >= 0)
            {
                this.lbHocPhanDay.Items.Add(lbDanhSachHP.SelectedItems[i]);
                this.lbDanhSachHP.Items.Remove(lbDanhSachHP.SelectedItems[i]);
                i--;
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        public void Reset()
        {
            this.cboMaSo.Text = "";
            this.txtHoTen.Text = "";
            
            this.txtMail.Text = "";
            this.mtxtSoDT.Text = "";
            this.rdNam.Checked = true;
            for(int i = 0; i < this.chklbNgoaiNgu.Items.Count; i++)
            {
                this.chklbNgoaiNgu.SetItemChecked(i, false);
            }
            foreach(object item in this.lbHocPhanDay.Items)
            {
                this.lbDanhSachHP.Items.Add(item);
            }
            this.lbHocPhanDay.Items.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = this.lbHocPhanDay.SelectedItems.Count - 1;
            while (i >= 0)
            {
                this.lbDanhSachHP.Items.Add(lbHocPhanDay.SelectedItems[i]);
                this.lbHocPhanDay.Items.Remove(lbHocPhanDay.SelectedItems[i]);
                i--;
            }
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            frmTBGiangVien f = new frmTBGiangVien();
            f.SetText(GetGiangVien().ToString());
            f.ShowDialog();
        }

        

        public GiangVien GetGiangVien()
        {
            string gt = "Nam";
            if (rdNu.Checked)
                gt = "Nữ";
            GiangVien gv = new GiangVien();
            gv.MaSo = this.cboMaSo.Text;
            gv.GioiTinh = gt;
            gv.HoTen = this.txtHoTen.Text;
            gv.NgaySinh = this.dtpNgaySinh.Value;
            gv.Mail = this.txtMail.Text;
            gv.SoDT = this.mtxtSoDT.Text;
            string ngoaiNgu = "";
            for (int i = 0; i < chklbNgoaiNgu.Items.Count; i++)
                if (chklbNgoaiNgu.GetItemChecked(i))
                    ngoaiNgu += chklbNgoaiNgu.Items[i] + ";";
            gv.NgoaiNgu = ngoaiNgu.Split(';');
            DanhSachHocPhan dshp = new DanhSachHocPhan();
            foreach (object hp in lbHocPhanDay.Items)
                dshp.Them(new HocPhan(hp.ToString()));
            gv.dsHocPhan = dshp;
            return gv;
        }

        public GiangVien LayData(ListViewItem lvitem)
        {
            GiangVien gv = new GiangVien();

            gv.MaSo = lvitem.SubItems[0].Text;
            gv.HoTen = lvitem.SubItems[1].Text;
            gv.NgaySinh = DateTime.Parse(lvitem.SubItems[2].Text);
            gv.GioiTinh = lvitem.SubItems[3].Text;
            gv.SoDT = lvitem.SubItems[4].Text;
            gv.Mail = lvitem.SubItems[5].Text;

            List<string> dsNgoaiNgu = new List<string>();
            string[] arrNgoaiNgu = lvitem.SubItems[6].Text.Split(',');
            foreach (string nn in arrNgoaiNgu)
            {
                if (!string.IsNullOrWhiteSpace(nn))
                    dsNgoaiNgu.Add(nn.Trim());
            }
            gv.NgoaiNgu = dsNgoaiNgu.ToArray();

            return gv;
        }


        private void linklbLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = e.Link.LinkData.ToString();
            Process.Start(s);
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            GiangVien gv = new GiangVien();
            gv.MaSo = cboMaSo.Text;
            gv.HoTen = txtHoTen.Text;
            gv.NgaySinh = dtpNgaySinh.Value;
            gv.GioiTinh = rdNam.Checked ? "Nam" : "Nữ";
            gv.SoDT = mtxtSoDT.Text;
            gv.Mail = txtMail.Text;

            List<string> nn = new List<string>();
            foreach (CheckBox chk in chklbNgoaiNgu.Controls.OfType<CheckBox>())
            {
                if (chk.Checked)
                    nn.Add(chk.Text);
            }
            gv.NgoaiNgu = nn.ToArray();

            
            if (ds.Them(gv))
            {
                ThemGV(gv); 
            }
            else
            {
                MessageBox.Show("Mã giảng viên đã tồn tại!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void lvGiangVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvGiangVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvGiangVien.SelectedItems[0];
                
                ThietLapThongTin(LayData(lvitem));
            }
        }

        public void ThietLapThongTin(GiangVien gv)
        {
            this.cboMaSo.Text = gv.MaSo;
            this.txtHoTen.Text = gv.HoTen;
            this.dtpNgaySinh.Value = gv.NgaySinh;

            if (gv.GioiTinh.Equals("Nam", StringComparison.OrdinalIgnoreCase))
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;

            this.mtxtSoDT.Text = gv.SoDT;
            this.txtMail.Text = gv.Mail;

            for (int i = 0; i < this.chklbNgoaiNgu.Items.Count; i++)
            {
                this.chklbNgoaiNgu.SetItemChecked(i, false);
            }

            foreach (string nn in gv.NgoaiNgu)
            {
                for (int i = 0; i < this.chklbNgoaiNgu.Items.Count; i++)
                {
                    if (nn.Trim().Equals(this.chklbNgoaiNgu.Items[i].ToString().Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        this.chklbNgoaiNgu.SetItemChecked(i, true);
                    }
                }
            }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void mtxtSoDT_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lbHocPhanDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbDanhSachHP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cboMaSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
