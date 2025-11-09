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
    public partial class frmAccountRoles : Form
    {
        private string accountName;
        private RoleBL roleBL = new RoleBL();
        private List<RoleAccount> accountRoles = new List<RoleAccount>();
        private List<Role> allRoles = new List<Role>();

        public frmAccountRoles(string accountName)
        {
            InitializeComponent();
            this.accountName = accountName;
            SetupDataGridView();
        }

        private void frmAccountRoles_Load(object sender, EventArgs e)
        {
            LoadAccountInfo();
            LoadRolesData();
        }

        private void SetupDataGridView()
        {
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.Columns.Clear();

            // Cột Checkbox cho chọn vai trò
            DataGridViewCheckBoxColumn colSelected = new DataGridViewCheckBoxColumn();
            colSelected.DataPropertyName = "Actived";
            colSelected.HeaderText = "CHỌN";
            colSelected.Width = 60;
            colSelected.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSelected.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRoles.Columns.Add(colSelected);

            // Cột Mã vai trò
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "RoleID";
            colID.HeaderText = "MÃ VAI TRÒ";
            colID.Width = 100;
            colID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRoles.Columns.Add(colID);

            // Cột Tên vai trò
            DataGridViewTextBoxColumn colRoleName = new DataGridViewTextBoxColumn();
            colRoleName.HeaderText = "TÊN VAI TRÒ";
            colRoleName.Width = 200;
            colRoleName.ReadOnly = true;
            dgvRoles.Columns.Add(colRoleName);

            // Cột Mô tả
            DataGridViewTextBoxColumn colNotes = new DataGridViewTextBoxColumn();
            colNotes.HeaderText = "MÔ TẢ";
            colNotes.Width = 200;
            colNotes.ReadOnly = true;
            dgvRoles.Columns.Add(colNotes);

            // Định dạng DataGridView
            dgvRoles.RowHeadersVisible = false;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.MultiSelect = false;
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.BackgroundColor = Color.White;
            dgvRoles.BorderStyle = BorderStyle.Fixed3D;
            dgvRoles.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;

            // Cho phép chỉnh sửa checkbox
            dgvRoles.ReadOnly = false;
            foreach (DataGridViewColumn column in dgvRoles.Columns)
            {
                if (column.HeaderText != "CHỌN")
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void LoadAccountInfo()
        {
            lblAccountInfo.Text = $"Tài khoản: {accountName}";
            this.Text = $"Phân quyền tài khoản - {accountName}";
        }

        private void LoadRolesData()
        {
            try
            {
                // Lấy tất cả vai trò
                allRoles = roleBL.GetAll();

                // Lấy vai trò của tài khoản
                accountRoles = roleBL.GetAccountRoles(accountName);

                // Nếu chưa có dữ liệu phân quyền, tạo mới
                if (accountRoles.Count == 0)
                {
                    foreach (var role in allRoles)
                    {
                        accountRoles.Add(new RoleAccount
                        {
                            RoleID = role.ID,
                            AccountName = accountName,
                            Actived = false,
                            Notes = role.Notes
                        });
                    }
                }

                // Hiển thị lên DataGridView
                dgvRoles.DataSource = accountRoles;
                UpdateStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu vai trò: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRoles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvRoles.Rows.Count)
            {
                // Hiển thị tên vai trò
                if (dgvRoles.Columns[e.ColumnIndex].HeaderText == "TÊN VAI TRÒ")
                {
                    RoleAccount roleAccount = dgvRoles.Rows[e.RowIndex].DataBoundItem as RoleAccount;
                    if (roleAccount != null)
                    {
                        var role = allRoles.FirstOrDefault(r => r.ID == roleAccount.RoleID);
                        e.Value = role?.RoleName ?? "Không xác định";
                    }
                }

                // Hiển thị mô tả
                if (dgvRoles.Columns[e.ColumnIndex].HeaderText == "MÔ TẢ")
                {
                    RoleAccount roleAccount = dgvRoles.Rows[e.RowIndex].DataBoundItem as RoleAccount;
                    if (roleAccount != null)
                    {
                        var role = allRoles.FirstOrDefault(r => r.ID == roleAccount.RoleID);
                        e.Value = role?.Notes ?? "Không có mô tả";
                    }
                }

                // Định dạng màu cho hàng được chọn
                if (dgvRoles.Rows[e.RowIndex].Selected)
                {
                    e.CellStyle.SelectionBackColor = Color.SteelBlue;
                    e.CellStyle.SelectionForeColor = Color.White;
                }

                // Định dạng màu theo trạng thái chọn
                RoleAccount currentRole = dgvRoles.Rows[e.RowIndex].DataBoundItem as RoleAccount;
                if (currentRole != null && currentRole.Actived)
                {
                    e.CellStyle.BackColor = Color.Honeydew;
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void UpdateStatus()
        {
            int totalRoles = accountRoles.Count;
            int selectedRoles = accountRoles.Count(r => r.Actived);

            lblStatus.Text = $"Tổng số: {totalRoles} vai trò | Đã chọn: {selectedRoles} vai trò";

            if (selectedRoles > 0)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Font = new Font(lblStatus.Font, FontStyle.Bold);
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Font = new Font(lblStatus.Font, FontStyle.Regular);
            }
        }

        private void dgvRoles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Chỉ xử lý khi thay đổi checkbox
            {
                try
                {
                    RoleAccount roleAccount = dgvRoles.Rows[e.RowIndex].DataBoundItem as RoleAccount;
                    if (roleAccount != null)
                    {
                        // Cập nhật trạng thái
                        bool newValue = (bool)dgvRoles.Rows[e.RowIndex].Cells[0].Value;
                        roleAccount.Actived = newValue;

                        UpdateStatus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật vai trò: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvRoles.Rows)
                {
                    row.Cells[0].Value = true;
                }

                // Cập nhật dữ liệu
                foreach (var role in accountRoles)
                {
                    role.Actived = true;
                }

                UpdateStatus();
                MessageBox.Show("Đã chọn tất cả vai trò!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn tất cả: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvRoles.Rows)
                {
                    row.Cells[0].Value = false;
                }

                // Cập nhật dữ liệu
                foreach (var role in accountRoles)
                {
                    role.Actived = false;
                }

                UpdateStatus();
                MessageBox.Show("Đã bỏ chọn tất cả vai trò!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi bỏ chọn tất cả: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có thay đổi không
                var originalRoles = roleBL.GetAccountRoles(accountName);
                bool hasChanges = !accountRoles.SequenceEqual(originalRoles, new RoleAccountComparer());

                if (!hasChanges)
                {
                    MessageBox.Show("Không có thay đổi để lưu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Hiển thị xác nhận
                int selectedCount = accountRoles.Count(r => r.Actived);
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn lưu phân quyền cho tài khoản '{accountName}'?\n\n" +
                    $"Số vai trò được chọn: {selectedCount}/{accountRoles.Count}",
                    "Xác nhận lưu phân quyền",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    // Lưu phân quyền
                    roleBL.UpdateAllAccountRoles(accountName, accountRoles);

                    MessageBox.Show("Lưu phân quyền thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu phân quyền: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có thay đổi chưa lưu không
            var originalRoles = roleBL.GetAccountRoles(accountName);
            bool hasChanges = !accountRoles.SequenceEqual(originalRoles, new RoleAccountComparer());

            if (hasChanges)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có thay đổi chưa lưu. Bạn có chắc chắn muốn đóng?\n\n" +
                    "Các thay đổi sẽ bị mất!",
                    "Có thay đổi chưa lưu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvRoles_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Commit ngay lập tức khi checkbox thay đổi
            if (dgvRoles.IsCurrentCellDirty)
            {
                dgvRoles.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý click trên checkbox
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                dgvRoles.EndEdit();
            }
        }

        // Class so sánh RoleAccount
        private class RoleAccountComparer : IEqualityComparer<RoleAccount>
        {
            public bool Equals(RoleAccount x, RoleAccount y)
            {
                if (x == null && y == null) return true;
                if (x == null || y == null) return false;

                return x.RoleID == y.RoleID && x.Actived == y.Actived;
            }

            public int GetHashCode(RoleAccount obj)
            {
                return obj.RoleID.GetHashCode() ^ obj.Actived.GetHashCode();
            }
        }

        private void lblAccountInfo_Click(object sender, EventArgs e)
        {

        }
    }
}