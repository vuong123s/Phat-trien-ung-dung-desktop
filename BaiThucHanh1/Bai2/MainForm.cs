using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void rdNam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNam.Checked) 
                MessageBox.Show("Bạn đã chọn giới tính Nam", "Thông báo");
        }

        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNu.Checked)
                MessageBox.Show("Bạn đã chọn giới tính Nữ", "Thông báo");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(rdDo.Checked)
                this.txtHopMau.BackColor = Color.Red;
            else if(rdXanh.Checked)
                this.txtHopMau.BackColor = Color.Blue;
        }
    }
}
