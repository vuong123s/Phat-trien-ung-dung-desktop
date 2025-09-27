using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05
{
    public partial class frmTimKiem : Form
    {
        public string ChuoiTimKiem = "";
        public TuyChon chon;
        public frmTimKiem()
        {
            InitializeComponent();
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ChuoiTimKiem = txtTimKiem.Text;
            chon= TuyChon.MSSV;
            if (rdTimLop.Checked)
                chon = TuyChon.Lop;
            else if (rdTimTen.Checked)
                chon = TuyChon.Ten;
            if (!string.IsNullOrEmpty(ChuoiTimKiem))
                this.DialogResult = DialogResult.OK;

        }

        private void frmTimKiem_Load(object sender, EventArgs e)
        {

        }
    }
}
