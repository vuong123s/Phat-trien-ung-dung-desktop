using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantManagementProject
{
    public partial class frmMain : Form
    {
        private TableBL tableBL = new TableBL();
        private FoodBL foodBL = new FoodBL();
        private CategoryBL categoryBL = new CategoryBL();
        private BillBL billBL = new BillBL();

        private List<Table> tables = new List<Table>();
        private List<Food> foods = new List<Food>();
        private List<Category> categories = new List<Category>();
        private List<OrderItem> currentOrder = new List<OrderItem>();

        private int selectedTableID = 0;
        private string selectedTableName = "";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
            SetupDataGridViews();

            LoadTables();
            LoadCategories();
            LoadFoods();
            ClearOrder();
        }

        private void LoadUserInfo()
        {
            if (frmLogin.CurrentAccount != null)
            {
                lblWelcome.Text = $"Xin chào: {frmLogin.CurrentAccount.FullName}";
                lblAccountInfo.Text = $"Tài khoản: {frmLogin.CurrentAccount.AccountName}";
            }
        }

        private void LoadTables()
        {
            try
            {
                tables = tableBL.GetAll();
                DisplayTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách bàn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFoods()
        {
            try
            {
                foods = foodBL.GetAll();
                DisplayFoods();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách món ăn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                categories = categoryBL.GetAll();
                cboCategory.DataSource = categories;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "ID";
                cboCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayTables()
        {
            flpTables.Controls.Clear();

            foreach (var table in tables)
            {
                Button btnTable = new Button();
                btnTable.Size = new Size(90, 90);
                btnTable.Tag = table;
                btnTable.Text = $"{table.Name}\nSức chứa: {table.Capacity}\n{GetTableStatusText(table.Status)}";
                btnTable.Font = new Font("Arial", 9, FontStyle.Bold);
                btnTable.TextAlign = ContentAlignment.MiddleCenter;

                // Set màu theo trạng thái
                switch (table.Status)
                {
                    case 0: // Trống
                        btnTable.BackColor = Color.LightGreen;
                        btnTable.ForeColor = Color.Black;
                        break;
                    case 1: // Đang dùng
                        btnTable.BackColor = Color.LightCoral;
                        btnTable.ForeColor = Color.White;
                        break;
                    case 2: // Đã đặt
                        btnTable.BackColor = Color.LightYellow;
                        btnTable.ForeColor = Color.Black;
                        break;
                    default:
                        btnTable.BackColor = Color.LightGray;
                        btnTable.ForeColor = Color.Black;
                        break;
                }

                btnTable.Click += BtnTable_Click;
                flpTables.Controls.Add(btnTable);
            }
        }

        private string GetTableStatusText(int status)
        {
            return tableBL.GetStatusText(status);
        }

        private void DisplayFoods()
        {
            var foodList = foods.Select(f => new
            {
                f.ID,  // Thêm ID vào danh sách
                f.Name,
                Price = f.Price.ToString("N0"),
                f.Unit,
                Category = GetCategoryName(f.FoodCategoryID)
            }).ToList();

            dgvFoods.DataSource = foodList;
        }
        private string GetCategoryName(int categoryID)
        {
            var category = categories.FirstOrDefault(c => c.ID == categoryID);
            return category?.Name ?? "Không xác định";
        }

        private void SetupDataGridViews()
        {
            // Setup Foods DataGridView
            dgvFoods.AutoGenerateColumns = false;
            dgvFoods.Columns.Clear();

            // Thêm cột ID (ẩn) - set Name so Cells["ID"] works
            DataGridViewTextBoxColumn colFoodID = new DataGridViewTextBoxColumn();
            colFoodID.Name = "ID";
            colFoodID.HeaderText = "ID";
            colFoodID.DataPropertyName = "ID";
            colFoodID.Visible = false;
            dgvFoods.Columns.Add(colFoodID);

            // Các cột hiển thị (set Name = DataPropertyName)
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Name = "Name";
            colName.HeaderText = "Tên món";
            colName.DataPropertyName = "Name";
            colName.Width = 200;
            dgvFoods.Columns.Add(colName);

            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.Name = "Price";
            colPrice.HeaderText = "Giá";
            colPrice.DataPropertyName = "Price";
            colPrice.Width = 100;
            dgvFoods.Columns.Add(colPrice);

            DataGridViewTextBoxColumn colUnit = new DataGridViewTextBoxColumn();
            colUnit.Name = "Unit";
            colUnit.HeaderText = "Đơn vị";
            colUnit.DataPropertyName = "Unit";
            colUnit.Width = 80;
            dgvFoods.Columns.Add(colUnit);

            DataGridViewTextBoxColumn colCategory = new DataGridViewTextBoxColumn();
            colCategory.Name = "Category";
            colCategory.HeaderText = "Danh mục";
            colCategory.DataPropertyName = "Category";
            colCategory.Width = 120;
            dgvFoods.Columns.Add(colCategory);

            // Định dạng grid
            dgvFoods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFoods.AllowUserToAddRows = false;
            dgvFoods.AllowUserToDeleteRows = false;
            dgvFoods.BackgroundColor = Color.White;
            dgvFoods.BorderStyle = BorderStyle.Fixed3D;
            dgvFoods.MultiSelect = false;

            // Setup Order Details DataGridView
            dgvOrderDetails.AutoGenerateColumns = false;
            dgvOrderDetails.Columns.Clear();

            DataGridViewTextBoxColumn colOrderFoodName = new DataGridViewTextBoxColumn();
            colOrderFoodName.Name = "FoodName";
            colOrderFoodName.HeaderText = "Tên món";
            colOrderFoodName.DataPropertyName = "FoodName";
            colOrderFoodName.Width = 150;
            dgvOrderDetails.Columns.Add(colOrderFoodName);

            DataGridViewTextBoxColumn colQuantity = new DataGridViewTextBoxColumn();
            colQuantity.Name = "Quantity";
            colQuantity.HeaderText = "Số lượng";
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.Width = 80;
            dgvOrderDetails.Columns.Add(colQuantity);

            DataGridViewTextBoxColumn colOrderPrice = new DataGridViewTextBoxColumn();
            colOrderPrice.Name = "UnitPrice";
            colOrderPrice.HeaderText = "Đơn giá";
            colOrderPrice.DataPropertyName = "UnitPrice";
            colOrderPrice.Width = 100;
            colOrderPrice.DefaultCellStyle.Format = "N0";
            dgvOrderDetails.Columns.Add(colOrderPrice);

            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "TotalPrice";
            colTotal.HeaderText = "Thành tiền";
            colTotal.DataPropertyName = "TotalPrice";
            colTotal.Width = 120;
            colTotal.DefaultCellStyle.Format = "N0";
            dgvOrderDetails.Columns.Add(colTotal);

            DataGridViewButtonColumn colDelete = new DataGridViewButtonColumn();
            colDelete.Name = "Delete";
            colDelete.HeaderText = "Xóa";
            colDelete.Text = "X";
            colDelete.Width = 50;
            colDelete.UseColumnTextForButtonValue = true;
            dgvOrderDetails.Columns.Add(colDelete);
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Table selectedTable = btn.Tag as Table;

            if (selectedTable != null)
            {


                if (selectedTable.Status == 1) // Đang dùng
                {

                    LoadOrderForTable(selectedTable.ID);

                }
                else
                {
                    ClearOrder();
                    EnableOrderControls(true);
                }
                selectedTableID = selectedTable.ID;

                selectedTableName = selectedTable.Name;
                lblCurrentTable.Text = $"Bàn: {selectedTable.Name} - {GetTableStatusText(selectedTable.Status)}";

            }

        }

        private void LoadOrderForTable(int tableID)
        {
            try
            {
                // Tìm hóa đơn chưa thanh toán cho bàn này
                var bills = billBL.GetAll();
                var currentBill = bills.FirstOrDefault(b => b.TableID == tableID && !b.Status);

                if (currentBill != null)
                {
                    var billDetails = billBL.GetBillDetails(currentBill.ID);
                    currentOrder.Clear();

                    foreach (var detail in billDetails)
                    {
                        var food = foods.FirstOrDefault(f => f.ID == detail.FoodID);
                        if (food != null)
                        {
                            currentOrder.Add(new OrderItem
                            {
                                FoodID = food.ID,
                                FoodName = food.Name,
                                Quantity = detail.Quantity,
                                UnitPrice = food.Price,
                                TotalPrice = food.Price * detail.Quantity
                            });
                        }
                    }

                    DisplayOrderDetails();
                    EnableOrderControls(false);
                }
                else
                {
                    ClearOrder();
                    EnableOrderControls(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải order: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (selectedTableID == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvFoods.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = dgvFoods.CurrentRow;

                // Lấy ID từ cột ẩn (column Name set in SetupDataGridViews)
                int foodID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                string foodName = selectedRow.Cells["Name"].Value.ToString();
                decimal unitPrice = decimal.Parse(selectedRow.Cells["Price"].Value.ToString().Replace(",", ""));
                int quantity = (int)nudQuantity.Value;

                if (quantity <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra và thêm/cập nhật món vào order
                var existingItem = currentOrder.FirstOrDefault(x => x.FoodID == foodID);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                    existingItem.TotalPrice = existingItem.UnitPrice * existingItem.Quantity;
                }
                else
                {
                    currentOrder.Add(new OrderItem
                    {
                        FoodID = foodID,
                        FoodName = foodName,
                        UnitPrice = unitPrice,
                        Quantity = quantity,
                        TotalPrice = unitPrice * quantity
                    });
                }

                DisplayOrderDetails();

                // Reset số lượng về 1
                nudQuantity.Value = 1;

                MessageBox.Show($"Đã thêm {quantity} {foodName} vào order!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm món: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOrderDetails()
        {
            dgvOrderDetails.DataSource = null;
            dgvOrderDetails.DataSource = currentOrder.ToList();
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal subtotal = currentOrder.Sum(x => x.TotalPrice);
            decimal discount = string.IsNullOrEmpty(txtDiscount.Text) ? 0 : decimal.Parse(txtDiscount.Text);
            decimal tax = string.IsNullOrEmpty(txtTax.Text) ? 0 : decimal.Parse(txtTax.Text);

            decimal finalTotal = subtotal - (subtotal * discount / 100) + (subtotal * tax / 100);

            lblSubTotal.Text = subtotal.ToString("N0");
            lblFinalTotal.Text = finalTotal.ToString("N0");
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (selectedTableID == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentOrder.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm món ăn vào order!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Use logged-in account when available; otherwise fallback to default account 'lgcong'
                string accountName = frmLogin.CurrentAccount?.AccountName;
                if (string.IsNullOrWhiteSpace(accountName))
                {
                    // Informative message (optional)
                    DialogResult dlg = MessageBox.Show(
                        "Bạn chưa đăng nhập. Sử dụng tài khoản mặc định 'Lê Gia Công' để tạo order?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dlg != DialogResult.Yes)
                        return;

                    accountName = "lgcong"; // must match AccountName in DB
                }

                int billID = billBL.CreateBill(selectedTableID, currentOrder, accountName);

                // update table status and UI
                tableBL.UpdateStatus(selectedTableID, 1);

                MessageBox.Show($"Tạo order thành công! Mã hóa đơn: {billID}", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableOrderControls(false);
                LoadTables(); // refresh tables
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo order: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   

        private void EnableOrderControls(bool enable)
        {
            btnCreateOrder.Enabled = enable;
            btnAddFood.Enabled = enable;
            nudQuantity.Enabled = enable;
        }

        private void dgvOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5) // Cột Xóa
            {
                currentOrder.RemoveAt(e.RowIndex);
                DisplayOrderDetails();
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterFoods();
        }

        private void txtSearchFood_TextChanged(object sender, EventArgs e)
        {
            FilterFoods();
        }

        private void FilterFoods()
        {
            var filteredFoods = foods.AsEnumerable();

            if (cboCategory.SelectedValue != null && int.TryParse(cboCategory.SelectedValue.ToString(), out int categoryId))
            {
                filteredFoods = filteredFoods.Where(f => f.FoodCategoryID == categoryId);
            }

            if (!string.IsNullOrEmpty(txtSearchFood.Text))
            {
                filteredFoods = filteredFoods.Where(f => f.Name.ToLower().Contains(txtSearchFood.Text.ToLower()));
            }

            dgvFoods.DataSource = filteredFoods.Select(f => new
            {
                f.ID,
                f.Name,
                Price = f.Price.ToString("N0"),
                f.Unit,
                Category = GetCategoryName(f.FoodCategoryID)
            }).ToList();
        }

        private void ClearOrder()
        {
            currentOrder.Clear();
            selectedTableID = 0;
            selectedTableName = "";
            DisplayOrderDetails();
            lblCurrentTable.Text = "Bàn: --";
            txtDiscount.Text = "0";
            txtTax.Text = "0";
            EnableOrderControls(false);
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void menuAccountManagement_Click(object sender, EventArgs e)
        {
            frmAccount accountForm = new frmAccount();
            accountForm.MdiParent = this;
            accountForm.Show();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frmLogin.CurrentAccount = null;
                this.Close();

                // Mở lại form đăng nhập
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            if (currentOrder.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ order?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ClearOrder();
                }
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flpTables_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvFoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccount frmAccount = new frmAccount();
            frmAccount.ShowDialog();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBill frmBill = new frmBill();
            frmBill.ShowDialog();
        }

        private void quảnLýLoạiMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frmCategory = new frmCategory();
            frmCategory.ShowDialog();
        }

        private void quảnLýMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFood frmFood = new frmFood();
            frmFood.ShowDialog();
        }

        private void quảnLýBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTable frmTable = new frmTable();
            frmTable.ShowDialog();
        }
    }
}