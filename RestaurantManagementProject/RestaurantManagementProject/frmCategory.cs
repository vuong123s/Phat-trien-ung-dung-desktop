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
    public partial class frmCategory : Form
    {
        private CategoryBL categoryBL = new CategoryBL();
        private List<Category> listCategory = new List<Category>();
        private Category currentCategory = new Category();

        public frmCategory()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            LoadCategoryData();
        }

        private void SetupDataGridView()
        {
            dgvCategory.AutoGenerateColumns = false;
            dgvCategory.Columns.Clear();

            // Cột ID
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "ID";
            colID.HeaderText = "MÃ";
            colID.Width = 60;
            colID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCategory.Columns.Add(colID);

            // Cột Tên danh mục
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "Name";
            colName.HeaderText = "TÊN DANH MỤC";
            colName.Width = 250;
            dgvCategory.Columns.Add(colName);

            // Cột Loại
            DataGridViewTextBoxColumn colType = new DataGridViewTextBoxColumn();
            colType.DataPropertyName = "Type";
            colType.HeaderText = "LOẠI";
            colType.Width = 100;
            colType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colType.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCategory.Columns.Add(colType);

            // Cột Mô tả loại
            DataGridViewTextBoxColumn colTypeDesc = new DataGridViewTextBoxColumn();
            colTypeDesc.HeaderText = "MÔ TẢ";
            colTypeDesc.Width = 150;
            colTypeDesc.ReadOnly = true;
            dgvCategory.Columns.Add(colTypeDesc);

            // Định dạng DataGridView
            dgvCategory.RowHeadersVisible = false;
            dgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategory.MultiSelect = false;
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.AllowUserToDeleteRows = false;
            dgvCategory.ReadOnly = true;
            dgvCategory.BackgroundColor = Color.White;
            dgvCategory.BorderStyle = BorderStyle.Fixed3D;
            dgvCategory.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
        }

        private void dgvCategory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCategory.Rows.Count)
            {
                // Định dạng cột Mô tả loại
                if (dgvCategory.Columns[e.ColumnIndex].HeaderText == "MÔ TẢ")
                {
                    Category category = dgvCategory.Rows[e.RowIndex].DataBoundItem as Category;
                    if (category != null)
                    {
                        e.Value = GetTypeDescription(category.Type);
                    }
                }

                // Định dạng màu cho hàng được chọn
                if (dgvCategory.Rows[e.RowIndex].Selected)
                {
                    e.CellStyle.SelectionBackColor = Color.SteelBlue;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private string GetTypeDescription(int type)
        {
            switch (type)
            {
                case 0: return "Đồ uống";
                case 1: return "Thức ăn";
                case 2: return "Khai vị";
                case 3: return "Tráng miệng";
                default: return "Khác";
            }
        }

        private void LoadCategoryData()
        {
            try
            {
                listCategory = categoryBL.GetAll();
                dgvCategory.DataSource = listCategory;
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
            // Có thể thêm status bar nếu cần
            this.Text = $"Quản lý danh mục - Tổng số: {listCategory.Count} danh mục";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên danh mục!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                Category category = new Category();
                category.Name = txtName.Text.Trim();
                category.Type = string.IsNullOrWhiteSpace(txtType.Text) ? 0 : int.Parse(txtType.Text);

                int result = categoryBL.Insert(category);
                if (result > 0)
                {
                    MessageBox.Show("Thêm danh mục thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategoryData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm danh mục thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Loại phải là số nguyên!", "Lỗi định dạng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtType.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm danh mục: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentCategory == null || currentCategory.ID == 0)
                {
                    MessageBox.Show("Vui lòng chọn danh mục để cập nhật!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên danh mục!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                currentCategory.Name = txtName.Text.Trim();
                currentCategory.Type = string.IsNullOrWhiteSpace(txtType.Text) ? 0 : int.Parse(txtType.Text);

                int result = categoryBL.Update(currentCategory);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật danh mục thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategoryData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật danh mục thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Loại phải là số nguyên!", "Lỗi định dạng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtType.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật danh mục: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentCategory == null || currentCategory.ID == 0)
                {
                    MessageBox.Show("Vui lòng chọn danh mục để xóa!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa danh mục '{currentCategory.Name}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    int deleteResult = categoryBL.Delete(currentCategory);
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa danh mục thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategoryData();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa danh mục thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa danh mục: " + ex.Message, "Lỗi",
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
            txtType.Text = "0";
            currentCategory = new Category();
            txtName.Focus();
        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategory.CurrentRow != null && dgvCategory.CurrentRow.DataBoundItem != null)
            {
                currentCategory = (Category)dgvCategory.CurrentRow.DataBoundItem;
                DisplayCategoryInfo(currentCategory);
            }
        }

        private void DisplayCategoryInfo(Category category)
        {
            txtName.Text = category.Name;
            txtType.Text = category.Type.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadCategoryData();
                }
                else
                {
                    var searchResult = categoryBL.Find(keyword);
                    dgvCategory.DataSource = searchResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtType_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (currentCategory.ID == 0)
                    btnAdd.PerformClick();
                else
                    btnUpdate.PerformClick();
            }
        }
    }
}