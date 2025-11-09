using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
    public partial class RoleForm : Form
    {
        private string accountName;
        private string fullName;
        private DataTable rolesTable;

        public RoleForm(string accountName, string fullName)
        {
            InitializeComponent();
            this.accountName = accountName;
            this.fullName = fullName;
        }

        private void RoleForm_Load(object sender, EventArgs e)
        {
            lblAccountInfo.Text = $"Tài khoản: {accountName} - Họ tên: {fullName}";
            LoadRoles();
        }

        private void LoadRoles()
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "GetAccountRoles";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    rolesTable = new DataTable();

                    conn.Open();
                    adapter.Fill(rolesTable);

                    dgvRoles.DataSource = rolesTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách vai trò: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvRoles.Rows)
                    {
                        if (row.Cells["colIsAssigned"].Value != null)
                        {
                            int roleID = Convert.ToInt32(row.Cells["colRoleID"].Value);
                            bool isAssigned = Convert.ToBoolean(row.Cells["colIsAssigned"].Value);

                            SqlCommand cmd = conn.CreateCommand();
                            cmd.CommandText = "UpdateAccountRoles";
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;
                            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                            cmd.Parameters.Add("@IsAssigned", SqlDbType.Bit).Value = isAssigned;

                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }

                    MessageBox.Show("Cập nhật vai trò thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật vai trò: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // Form thêm vai trò mới (có thể implement sau)
            MessageBox.Show("Chức năng thêm vai trò mới sẽ được implement", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}