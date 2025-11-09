using System;
using System.Drawing;
using System.Windows.Forms;

namespace RestaurantManagementProject
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private Label label1;
        private Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnExit = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new Point(30, 30);
            this.label1.Text = "Tên đăng nhập:";

            // txtUsername
            this.txtUsername.Location = new Point(130, 27);
            this.txtUsername.Size = new Size(200, 20);

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new Point(30, 70);
            this.label2.Text = "Mật khẩu:";

            // txtPassword
            this.txtPassword.Location = new Point(130, 67);
            this.txtPassword.Size = new Size(200, 20);
            this.txtPassword.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Location = new Point(130, 110);
            this.btnLogin.Size = new Size(90, 30);
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // btnExit
            this.btnExit.Location = new Point(240, 110);
            this.btnExit.Size = new Size(90, 30);
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new EventHandler(this.btnExit_Click);

            // Form
            this.ClientSize = new Size(384, 161);
            this.Controls.AddRange(new Control[] {
            this.label1, this.txtUsername, this.label2, this.txtPassword,
            this.btnLogin, this.btnExit});
            this.Text = "Đăng nhập hệ thống";
            this.ResumeLayout(false);
        }
    }
}