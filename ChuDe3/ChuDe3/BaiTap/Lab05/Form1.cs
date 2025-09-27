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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTXT_Click(object sender, EventArgs e)
        {
            Form f1 = new Form2();
            f1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            Form f1 = new Form2("XML");
            f1.ShowDialog();
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            Form f1 = new Form2("JSON");    
            f1.ShowDialog();
        }
    }
}
