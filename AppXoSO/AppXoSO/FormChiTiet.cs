using System;
using System.Windows.Forms;

namespace AppXoSO
{
    public partial class FormChiTiet : Form
    {
        public FormChiTiet(string title, string description, string pubDate)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblPubDate.Text = "Ngày: " + pubDate;
            txtDescription.Text = description; // giữ nguyên format description
        }
    }
}
