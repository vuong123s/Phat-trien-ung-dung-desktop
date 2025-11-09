using System;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "HỆ THỐNG QUẢN LÝ NHÀ HÀNG";
            lblVersion.Text = "Phiên bản 1.0";
        }

        // Quản lý món ăn
        private void btnFoodManagement_Click(object sender, EventArgs e)
        {
            FoodForm foodForm = new FoodForm();
            foodForm.ShowDialog();
        }

        // Quản lý hóa đơn
        private void btnOrderManagement_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.ShowDialog();
        }

        // Quản lý tài khoản
        private void btnAccountManagement_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm();
            accountForm.ShowDialog();
        }

        // Thông tin hóa đơn (BillsForm)
        private void btnBills_Click(object sender, EventArgs e)
        {
            // Nếu bạn có BillsForm trong project này
            // BillsForm billsForm = new BillsForm();
            // billsForm.ShowDialog();
            MessageBox.Show("Chức năng Quản lý Hóa đơn", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Thoát ứng dụng
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Menu strip items
        private void foodManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFoodManagement.PerformClick();
        }

        private void orderManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOrderManagement.PerformClick();
        }

        private void accountManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAccountManagement.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExit.PerformClick();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hệ thống Quản lý Nhà hàng\nPhiên bản 1.0\n© 2024",
                "Thông tin ứng dụng",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}