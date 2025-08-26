using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapThietKeForm
{
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnChonHang_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            
            listBox2.Items.Add(item);

        }

        private void btnBoHang_Click(object sender, EventArgs e)
        {
            var item = listBox2.SelectedItem;

            listBox2.Items.Remove(item);
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            int tongTien = 0;
            foreach(var i in listBox2.Items)
            {
                switch(i)
                {
                    case "Chuột":
                        tongTien += 100000;
                        break;
                    case "Bàn phím":
                        tongTien += 150000;
                        break;
                    case "Máy in":
                        tongTien += 2000000;
                        break;
                    case "USB Kingmax":
                        tongTien += 200000;
                        break;
                    default:
                        break;
                }
                lblTongTien.Text = tongTien.ToString() + " đồng";
            }
        }
    }
}
