using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagementProject
{
    public partial class frmLogin : Form
    {
        public static Account CurrentAccount { get; set; }  // Đổi User -> Account

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                AccountBL accountBL = new AccountBL();  // Đổi UserBL -> AccountBL
                Account account = accountBL.Login(txtUsername.Text, txtPassword.Text);  // Đổi User -> Account

                if (account != null)
                {
                    CurrentAccount = account;  // Đổi CurrentUser -> CurrentAccount
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}