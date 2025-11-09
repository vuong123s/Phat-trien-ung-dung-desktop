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
    public partial class frmAccount : Form
    {
        private AccountBL accountBL = new AccountBL();
        private RoleBL roleBL = new RoleBL();
        private List<Account> listAccounts = new List<Account>();
        private Account currentAccount = new Account();

        public frmAccount()
        {
            InitializeComponent();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            LoadAccountData();
            SetupDataGridView();
        }

        private void LoadAccountData()
        {
            try
            {
                listAccounts = accountBL.GetAll();
                dgvAccounts.DataSource = listAccounts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvAccounts.AutoGenerateColumns = false;
            dgvAccounts.Columns.Clear();

            // Cấu hình các cột
            string[] columns = { "Tài khoản", "Họ tên", "Email", "Điện thoại", "Ngày tạo" };
            string[] properties = { "AccountName", "FullName", "Email", "Tell", "DateCreated" };
            int[] widths = { 120, 200, 150, 100, 120 };

            for (int i = 0; i < columns.Length; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = columns[i];
                col.DataPropertyName = properties[i];
                col.Width = widths[i];
                dgvAccounts.Columns.Add(col);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Account account = new Account();
                account.AccountName = txtAccountName.Text.Trim();
                account.Password = txtPassword.Text;
                account.FullName = txtFullName.Text.Trim();
                account.Email = txtEmail.Text.Trim();
                account.Tell = txtTell.Text.Trim();

                int result = accountBL.Insert(account);
                if (result > 0)
                {
                    MessageBox.Show("Thêm tài khoản thành công!", "Thành công");
                    LoadAccountData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm tài khoản: " + ex.Message, "Lỗi");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(currentAccount.AccountName))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản để cập nhật!", "Cảnh báo");
                    return;
                }

                currentAccount.FullName = txtFullName.Text.Trim();
                currentAccount.Email = txtEmail.Text.Trim();
                currentAccount.Tell = txtTell.Text.Trim();

                int result = accountBL.Update(currentAccount);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thành công");
                    LoadAccountData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật tài khoản: " + ex.Message, "Lỗi");
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(currentAccount.AccountName))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản!", "Cảnh báo");
                    return;
                }

                string newPassword = "123456"; // Mật khẩu mặc định
                int result = accountBL.ResetPassword(currentAccount.AccountName, newPassword);
                if (result > 0)
                {
                    MessageBox.Show($"Reset mật khẩu thành công! Mật khẩu mới: {newPassword}", "Thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reset mật khẩu: " + ex.Message, "Lỗi");
            }
        }

        private void btnManageRoles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentAccount.AccountName))
            {
                MessageBox.Show("Vui lòng chọn tài khoản!", "Cảnh báo");
                return;
            }

            frmAccountRoles rolesForm = new frmAccountRoles(currentAccount.AccountName);
            rolesForm.ShowDialog();
        }



        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow != null)
            {
                currentAccount = (Account)dgvAccounts.CurrentRow.DataBoundItem;
                DisplayAccountInfo(currentAccount);
            }
        }

        private void DisplayAccountInfo(Account account)
        {
            txtAccountName.Text = account.AccountName;
            txtFullName.Text = account.FullName;
            txtEmail.Text = account.Email;
            txtTell.Text = account.Tell;
        }

        private void ClearForm()
        {
            txtAccountName.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtTell.Text = "";
            currentAccount = new Account();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadAccountData();
                }
                else
                {
                    var searchResult = accountBL.Find(keyword);
                    dgvAccounts.DataSource = searchResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi");
            }
        }
        private bool IsDataChanged()
        {
            // Kiểm tra nếu có bất kỳ trường nào có dữ liệu
            return !string.IsNullOrEmpty(txtAccountName.Text.Trim()) ||
                   !string.IsNullOrEmpty(txtPassword.Text.Trim()) ||
                   !string.IsNullOrEmpty(txtFullName.Text.Trim()) ||
                   !string.IsNullOrEmpty(txtEmail.Text.Trim()) ||
                   !string.IsNullOrEmpty(txtTell.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (IsDataChanged())
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa tất cả dữ liệu đã nhập?",
                    "Xác nhận làm mới",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ClearForm();
                }
            }
            else
            {
                ClearForm();
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.IsMdiChild)
            {
                this.Close();
            }
            else
            {
                Application.Exit(); // Nếu là form chính
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}