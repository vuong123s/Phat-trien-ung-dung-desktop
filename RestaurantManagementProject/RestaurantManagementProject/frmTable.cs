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
    public partial class frmTable : Form
    {
        private TableBL tableBL = new TableBL();
        private List<DataAccess.Table> listTables = new List<DataAccess.Table>();
        private DataAccess.Table currentTable = new DataAccess.Table();

        public frmTable()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadStatusComboBox();
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            LoadTableData();
        }

        private void SetupDataGridView()
        {
            dgvTables.AutoGenerateColumns = false;
            dgvTables.Columns.Clear();

            // Cột Mã bàn
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "ID";
            colID.HeaderText = "MÃ BÀN";
            colID.Width = 80;
            colID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTables.Columns.Add(colID);

            // Cột Tên bàn
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "Name";
            colName.HeaderText = "TÊN BÀN";
            colName.Width = 120;
            colName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTables.Columns.Add(colName);

            // Cột Sức chứa
            DataGridViewTextBoxColumn colCapacity = new DataGridViewTextBoxColumn();
            colCapacity.DataPropertyName = "Capacity";
            colCapacity.HeaderText = "SỨC CHỨA";
            colCapacity.Width = 80;
            colCapacity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCapacity.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTables.Columns.Add(colCapacity);

            // Cột Trạng thái
            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.HeaderText = "TRẠNG THÁI";
            colStatus.Width = 100;
            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStatus.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTables.Columns.Add(colStatus);

            // Cột Mô tả trạng thái
            DataGridViewTextBoxColumn colStatusDesc = new DataGridViewTextBoxColumn();
            colStatusDesc.HeaderText = "MÔ TẢ";
            colStatusDesc.Width = 150;
            colStatusDesc.ReadOnly = true;
            dgvTables.Columns.Add(colStatusDesc);

            // Định dạng DataGridView
            dgvTables.RowHeadersVisible = false;
            dgvTables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTables.MultiSelect = false;
            dgvTables.AllowUserToAddRows = false;
            dgvTables.AllowUserToDeleteRows = false;
            dgvTables.ReadOnly = true;
            dgvTables.BackgroundColor = Color.White;
            dgvTables.BorderStyle = BorderStyle.Fixed3D;
            dgvTables.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
        }

        private void dgvTables_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvTables.Rows.Count)
            {
                // Định dạng cột Trạng thái
                if (dgvTables.Columns[e.ColumnIndex].HeaderText == "TRẠNG THÁI")
                {
                    DataAccess.Table table = dgvTables.Rows[e.RowIndex].DataBoundItem as DataAccess.Table;
                    if (table != null)
                    {
                        e.Value = GetStatusText(table.Status);

                        // Đặt màu theo trạng thái
                        switch (table.Status)
                        {
                            case 0: // Trống
                                e.CellStyle.BackColor = Color.LightGreen;
                                e.CellStyle.ForeColor = Color.DarkGreen;
                                break;
                            case 1: // Đang dùng
                                e.CellStyle.BackColor = Color.LightCoral;
                                e.CellStyle.ForeColor = Color.DarkRed;
                                break;
                            case 2: // Đã đặt
                                e.CellStyle.BackColor = Color.LightYellow;
                                e.CellStyle.ForeColor = Color.DarkGoldenrod;
                                break;
                        }
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                }

                // Định dạng cột Mô tả
                if (dgvTables.Columns[e.ColumnIndex].HeaderText == "MÔ TẢ")
                {
                    DataAccess.Table table = dgvTables.Rows[e.RowIndex].DataBoundItem as DataAccess.Table;
                    if (table != null)
                    {
                        e.Value = GetStatusDescription(table.Status);
                    }
                }

                // Định dạng màu cho hàng được chọn
                if (dgvTables.Rows[e.RowIndex].Selected)
                {
                    e.CellStyle.SelectionBackColor = Color.SteelBlue;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private string GetStatusText(int status)
        {
            switch (status)
            {
                case 0: return "TRỐNG";
                case 1: return "ĐANG DÙNG";
                case 2: return "ĐÃ ĐẶT";
                default: return "KHÔNG XĐ";
            }
        }

        private string GetStatusDescription(int status)
        {
            switch (status)
            {
                case 0: return "Bàn trống, sẵn sàng phục vụ";
                case 1: return "Đang có khách sử dụng";
                case 2: return "Đã được đặt trước";
                default: return "Trạng thái không xác định";
            }
        }

        private void LoadStatusComboBox()
        {
            cbbStatus.Items.Clear();
            cbbStatus.Items.Add(new { Text = "🟢 Trống", Value = 0 });
            cbbStatus.Items.Add(new { Text = "🔴 Đang dùng", Value = 1 });
            cbbStatus.Items.Add(new { Text = "🟡 Đã đặt", Value = 2 });
            cbbStatus.DisplayMember = "Text";
            cbbStatus.ValueMember = "Value";
            cbbStatus.SelectedIndex = 0;
        }

        private void LoadTableData()
        {
            try
            {
                listTables = tableBL.GetAll(); // listTables is now List<DataAccess.Table>
                dgvTables.DataSource = listTables;
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusBar()
        {
            int emptyCount = listTables.Count(t => t.Status == 0);
            int usingCount = listTables.Count(t => t.Status == 1);
            int reservedCount = listTables.Count(t => t.Status == 2);

            this.Text = $"Quản lý bàn ăn - Tổng: {listTables.Count} bàn | " +
                       $"Trống: {emptyCount} | Đang dùng: {usingCount} | Đã đặt: {reservedCount}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên bàn!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                DataAccess.Table table = new DataAccess.Table();
                table.Name = txtName.Text.Trim();
                table.Capacity = (int)nudCapacity.Value;
                table.Status = (int)((dynamic)cbbStatus.SelectedItem).Value;

                int result = tableBL.Insert(table);
                if (result > 0)
                {
                    MessageBox.Show("Thêm bàn thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTableData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm bàn thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm bàn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentTable == null || currentTable.ID == 0)
                {
                    MessageBox.Show("Vui lòng chọn bàn để cập nhật!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên bàn!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                currentTable.Name = txtName.Text.Trim();
                currentTable.Capacity = (int)nudCapacity.Value;
                currentTable.Status = (int)((dynamic)cbbStatus.SelectedItem).Value;

                int result = tableBL.Update(currentTable);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật bàn thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTableData();
                }
                else
                {
                    MessageBox.Show("Cập nhật bàn thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật bàn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentTable == null || currentTable.ID == 0)
                {
                    MessageBox.Show("Vui lòng chọn bàn để xóa!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa bàn '{currentTable.Name}'?\n\n" +
                    $"Lưu ý: Không thể xóa bàn đang có khách sử dụng hoặc đã được đặt trước!",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    int deleteResult = tableBL.Delete(currentTable.ID);
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa bàn thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTableData();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa bàn thất bại! Có thể bàn đang được sử dụng.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa bàn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txtName.Text = "";
            nudCapacity.Value = 4;
            cbbStatus.SelectedIndex = 0;
            currentTable = new DataAccess.Table();
            txtName.Focus();
        }

        private void dgvTables_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTables.CurrentRow != null && dgvTables.CurrentRow.DataBoundItem != null)
            {
                currentTable = (DataAccess.Table)dgvTables.CurrentRow.DataBoundItem;
                DisplayTableInfo(currentTable);
            }
        }

        private void DisplayTableInfo(DataAccess.Table table)
        {
            txtName.Text = table.Name;
            nudCapacity.Value = table.Capacity;

            // Chọn đúng status trong combobox
            for (int i = 0; i < cbbStatus.Items.Count; i++)
            {
                dynamic item = cbbStatus.Items[i];
                if ((int)item.Value == table.Status)
                {
                    cbbStatus.SelectedIndex = i;
                    break;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadTableData();
                }
                else
                {
                    var searchResult = tableBL.Find(keyword);
                    dgvTables.DataSource = searchResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (currentTable.ID == 0)
                    btnAdd.PerformClick();
                else
                    btnUpdate.PerformClick();
            }
        }

        private void nudCapacity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (currentTable.ID == 0)
                    btnAdd.PerformClick();
                else
                    btnUpdate.PerformClick();
            }
        }

        private void cbbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (currentTable.ID == 0)
                    btnAdd.PerformClick();
                else
                    btnUpdate.PerformClick();
            }
        }

        private void UpdateTableStatus(int tableID, int newStatus)
        {
            try
            {
                int result = tableBL.UpdateStatus(tableID, newStatus);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật trạng thái bàn thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTableData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật trạng thái: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}