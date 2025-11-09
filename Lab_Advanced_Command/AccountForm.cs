using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
    public partial class AccountForm : Form
    {
        private DataTable accountsTable;

        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            ClearForm();
        }

        private void LoadAccounts()
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "GetAllAccounts";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    accountsTable = new DataTable();

                    conn.Open();
                    adapter.Fill(accountsTable);

                    dgvAccounts.DataSource = accountsTable;
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách tài khoản: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dgvAccounts.Columns.Count > 0)
            {
                dgvAccounts.Columns["AccountName"].HeaderText = "Tài khoản";
                dgvAccounts.Columns["FullName"].HeaderText = "Họ và tên";
                dgvAccounts.Columns["Email"].HeaderText = "Email";
                dgvAccounts.Columns["Tell"].HeaderText = "SĐT";
                dgvAccounts.Columns["DateCreated"].HeaderText = "Ngày tạo";

                if (dgvAccounts.Columns["DateCreated"] != null)
                    dgvAccounts.Columns["DateCreated"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        private void ClearForm()
        {
            txtAccountName.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtTell.Clear();
            txtAccountName.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnResetPassword.Enabled = false;
        }

        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAccounts.SelectedRows[0];
                txtAccountName.Text = selectedRow.Cells["AccountName"].Value.ToString();
                txtFullName.Text = selectedRow.Cells["FullName"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"]?.Value?.ToString() ?? "";
                txtTell.Text = selectedRow.Cells["Tell"]?.Value?.ToString() ?? "";

                txtAccountName.Enabled = false;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnResetPassword.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản, mật khẩu và họ tên", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "InsertAccount";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = txtAccountName.Text.Trim();
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = txtPassword.Text;
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000).Value = txtFullName.Text.Trim();
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 1000).Value = txtEmail.Text.Trim();
                    cmd.Parameters.Add("@Tell", SqlDbType.NVarChar, 200).Value = txtTell.Text.Trim();

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Thêm tài khoản thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAccounts();
                        ClearForm();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Primary key violation
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Lỗi SQL: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UpdateAccount";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = txtAccountName.Text.Trim();
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000).Value = txtFullName.Text.Trim();
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 1000).Value = txtEmail.Text.Trim();
                    cmd.Parameters.Add("@Tell", SqlDbType.NVarChar, 200).Value = txtTell.Text.Trim();

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật tài khoản thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAccounts();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để reset mật khẩu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "ResetPassword";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = txtAccountName.Text.Trim();
                    cmd.Parameters.Add("@NewPassword", SqlDbType.NVarChar, 200).Value = txtPassword.Text;

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Reset mật khẩu thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAccounts.SelectedRows[0];
                string accountName = selectedRow.Cells["AccountName"].Value.ToString();
                string fullName = selectedRow.Cells["FullName"].Value.ToString();

                RoleForm roleForm = new RoleForm(accountName, fullName);
                roleForm.ShowDialog();
            }
        }

        private void viewActivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAccounts.SelectedRows[0];
                string accountName = selectedRow.Cells["AccountName"].Value.ToString();
                string fullName = selectedRow.Cells["FullName"].Value.ToString();

                ActivityForm activityForm = new ActivityForm(accountName, fullName);
                activityForm.ShowDialog();
            }
        }

        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnResetPassword.PerformClick();
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            // Form thêm vai trò mới (có thể implement sau)
            MessageBox.Show("Chức năng thêm vai trò mới sẽ được implement", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}