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
    public partial class frmBill : Form
    {
        private BillBL billBL = new BillBL();
        private List<Bill> listBills = new List<Bill>();
        private Bill currentBill = new Bill();

        public frmBill()
        {
            InitializeComponent();
            SetupDataGridViews();
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            LoadBillData();
        }

        private void SetupDataGridViews()
        {
            SetupBillsDataGridView();
            SetupBillDetailsDataGridView();
        }

        private void SetupBillsDataGridView()
        {
            dgvBills.AutoGenerateColumns = false;
            dgvBills.Columns.Clear();

            // Cột Mã HD
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "ID";
            colID.HeaderText = "MÃ HD";
            colID.Width = 70;
            colID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBills.Columns.Add(colID);

            // Cột Tên hóa đơn
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "Name";
            colName.HeaderText = "TÊN HÓA ĐƠN";
            colName.Width = 150;
            dgvBills.Columns.Add(colName);

            // Cột Bàn
            DataGridViewTextBoxColumn colTable = new DataGridViewTextBoxColumn();
            colTable.DataPropertyName = "TableName";
            colTable.HeaderText = "BÀN";
            colTable.Width = 80;
            colTable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTable.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBills.Columns.Add(colTable);

            // Cột Tổng tiền
            DataGridViewTextBoxColumn colAmount = new DataGridViewTextBoxColumn();
            colAmount.DataPropertyName = "Amount";
            colAmount.HeaderText = "TỔNG TIỀN";
            colAmount.Width = 100;
            colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAmount.DefaultCellStyle.Format = "N0";
            dgvBills.Columns.Add(colAmount);

            // Cột Giảm giá
            DataGridViewTextBoxColumn colDiscount = new DataGridViewTextBoxColumn();
            colDiscount.DataPropertyName = "Discount";
            colDiscount.HeaderText = "GIẢM GIÁ";
            colDiscount.Width = 80;
            colDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDiscount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDiscount.DefaultCellStyle.Format = "P0";
            dgvBills.Columns.Add(colDiscount);

            // Cột Thực thu
            DataGridViewTextBoxColumn colActualAmount = new DataGridViewTextBoxColumn();
            colActualAmount.DataPropertyName = "ActualAmount";
            colActualAmount.HeaderText = "THỰC THU";
            colActualAmount.Width = 100;
            colActualAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colActualAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colActualAmount.DefaultCellStyle.Format = "N0";
            dgvBills.Columns.Add(colActualAmount);

            // Cột Trạng thái
            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.DataPropertyName = "StatusText";
            colStatus.HeaderText = "TRẠNG THÁI";
            colStatus.Width = 100;
            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStatus.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBills.Columns.Add(colStatus);

            // Cột Ngày
            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.DataPropertyName = "CheckoutDate";
            colDate.HeaderText = "NGÀY";
            colDate.Width = 120;
            colDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDate.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvBills.Columns.Add(colDate);

            // Cột Nhân viên
            DataGridViewTextBoxColumn colAccount = new DataGridViewTextBoxColumn();
            colAccount.DataPropertyName = "Account";
            colAccount.HeaderText = "NHÂN VIÊN";
            colAccount.Width = 100;
            dgvBills.Columns.Add(colAccount);

            // Định dạng DataGridView
            dgvBills.RowHeadersVisible = false;
            dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.MultiSelect = false;
            dgvBills.AllowUserToAddRows = false;
            dgvBills.AllowUserToDeleteRows = false;
            dgvBills.ReadOnly = true;
            dgvBills.BackgroundColor = Color.White;
            dgvBills.BorderStyle = BorderStyle.Fixed3D;
            dgvBills.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
        }

        private void SetupBillDetailsDataGridView()
        {
            dgvBillDetails.AutoGenerateColumns = false;
            dgvBillDetails.Columns.Clear();

            // Cột Tên món
            DataGridViewTextBoxColumn colFoodName = new DataGridViewTextBoxColumn();
            colFoodName.DataPropertyName = "FoodName";
            colFoodName.HeaderText = "TÊN MÓN";
            colFoodName.Width = 150;
            dgvBillDetails.Columns.Add(colFoodName);

            // Cột Số lượng
            DataGridViewTextBoxColumn colQuantity = new DataGridViewTextBoxColumn();
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "SỐ LƯỢNG";
            colQuantity.Width = 80;
            colQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colQuantity.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBillDetails.Columns.Add(colQuantity);

            // Cột Đơn giá
            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "ĐƠN GIÁ";
            colPrice.Width = 100;
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colPrice.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPrice.DefaultCellStyle.Format = "N0";
            dgvBillDetails.Columns.Add(colPrice);

            // Cột Thành tiền
            DataGridViewTextBoxColumn colTotalPrice = new DataGridViewTextBoxColumn();
            colTotalPrice.DataPropertyName = "TotalPrice";
            colTotalPrice.HeaderText = "THÀNH TIỀN";
            colTotalPrice.Width = 120;
            colTotalPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTotalPrice.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTotalPrice.DefaultCellStyle.Format = "N0";
            dgvBillDetails.Columns.Add(colTotalPrice);

            // Cột Đơn vị
            DataGridViewTextBoxColumn colUnit = new DataGridViewTextBoxColumn();
            colUnit.DataPropertyName = "Unit";
            colUnit.HeaderText = "ĐƠN VỊ";
            colUnit.Width = 80;
            colUnit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colUnit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBillDetails.Columns.Add(colUnit);

            // Cột Danh mục
            DataGridViewTextBoxColumn colCategory = new DataGridViewTextBoxColumn();
            colCategory.DataPropertyName = "CategoryName";
            colCategory.HeaderText = "DANH MỤC";
            colCategory.Width = 100;
            dgvBillDetails.Columns.Add(colCategory);

            // Định dạng DataGridView
            dgvBillDetails.RowHeadersVisible = false;
            dgvBillDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillDetails.MultiSelect = false;
            dgvBillDetails.AllowUserToAddRows = false;
            dgvBillDetails.AllowUserToDeleteRows = false;
            dgvBillDetails.ReadOnly = true;
            dgvBillDetails.BackgroundColor = Color.White;
            dgvBillDetails.BorderStyle = BorderStyle.Fixed3D;
            dgvBillDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
        }

        private void LoadBillData()
        {
            try
            {
                listBills = billBL.GetAll();
                dgvBills.DataSource = listBills;
                UpdateStatusBar();
                ClearBillInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusBar()
        {
            this.Text = $"Quản lý hóa đơn - Tổng số: {listBills.Count} hóa đơn";
        }

        private void ClearBillInfo()
        {
            lblBillInfo.Text = "Vui lòng chọn một hóa đơn để xem thông tin chi tiết...";
            dgvBillDetails.DataSource = null;
            lblTotal.Text = "Tổng tiền: 0 đ";
        }

        private void dgvBills_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBills.CurrentRow != null && dgvBills.CurrentRow.DataBoundItem != null)
            {
                currentBill = (Bill)dgvBills.CurrentRow.DataBoundItem;
                DisplayBillInfo(currentBill);
                LoadBillDetails(currentBill.ID);
            }
        }

        private void DisplayBillInfo(Bill bill)
        {
            string statusColor = bill.Status ? "🟢" : "🔴";
            string statusText = bill.Status ? "ĐÃ THANH TOÁN" : "CHƯA THANH TOÁN";

            string billInfo = $@"{statusColor} THÔNG TIN HÓA ĐƠN {statusColor}

Mã hóa đơn: {bill.ID}
Tên hóa đơn: {bill.Name}
Bàn: {bill.TableName}
Tổng tiền: {bill.Amount:N0} đ
Giảm giá: {bill.Discount:P0}
Thực thu: {bill.ActualAmount:N0} đ
Trạng thái: {statusText}
Ngày: {(bill.CheckoutDate?.ToString("dd/MM/yyyy HH:mm") ?? "Chưa thanh toán")}
Nhân viên: {bill.Account}";

            lblBillInfo.Text = billInfo;
            lblBillInfo.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void LoadBillDetails(int billID)
        {
            try
            {
                var details = billBL.GetBillDetails(billID);
                dgvBillDetails.DataSource = details;

                // Tính tổng tiền
                decimal total = details.Sum(d => d.TotalPrice);
                lblTotal.Text = $"Tổng tiền: {total:N0} đ";

                // Định dạng màu cho tổng tiền
                lblTotal.ForeColor = total > 0 ? Color.Red : Color.Black;
                lblTotal.Font = new Font(lblTotal.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (currentBill == null || currentBill.ID == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadBillDetails(currentBill.ID);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (currentBill == null || currentBill.ID == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintBill(currentBill.ID);
        }

        private void PrintBill(int billID)
        {
            try
            {
                var bill = listBills.FirstOrDefault(b => b.ID == billID);
                var details = billBL.GetBillDetails(billID);

                if (bill == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin hóa đơn!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StringBuilder billContent = new StringBuilder();
                billContent.AppendLine("╔══════════════════════════════════╗");
                billContent.AppendLine("║        HÓA ĐƠN NHÀ HÀNG         ║");
                billContent.AppendLine("╚══════════════════════════════════╝");
                billContent.AppendLine();
                billContent.AppendLine($"Mã HD: {bill.ID}");
                billContent.AppendLine($"Bàn: {bill.TableName}");
                billContent.AppendLine($"Ngày: {bill.CheckoutDate:dd/MM/yyyy HH:mm}");
                billContent.AppendLine($"Nhân viên: {bill.Account}");
                billContent.AppendLine();
                billContent.AppendLine("┌──────────────────────────────────┐");
                billContent.AppendLine("│           CHI TIẾT MÓN          │");
                billContent.AppendLine("└──────────────────────────────────┘");

                foreach (var detail in details)
                {
                    billContent.AppendLine($"{detail.FoodName}");
                    billContent.AppendLine($"  {detail.Quantity} x {detail.Price:N0} = {detail.TotalPrice:N0} đ");
                }

                billContent.AppendLine();
                billContent.AppendLine("┌──────────────────────────────────┐");
                billContent.AppendLine($"│ Tổng tiền: {bill.ActualAmount,20:N0} đ │");
                billContent.AppendLine("└──────────────────────────────────┘");
                billContent.AppendLine();
                billContent.AppendLine("      Cảm ơn quý khách!");
                billContent.AppendLine("   Hẹn gặp lại!");

                // Hiển thị hóa đơn trong message box
                MessageBox.Show(billContent.ToString(), $"HÓA ĐƠN #{bill.ID}",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBillData();
            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadBillData();
                }
                else
                {
                    var searchResult = billBL.Find(keyword);
                    dgvBills.DataSource = searchResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvBills.Rows.Count)
            {
                // Định dạng màu theo trạng thái
                if (dgvBills.Columns[e.ColumnIndex].HeaderText == "TRẠNG THÁI")
                {
                    Bill bill = dgvBills.Rows[e.RowIndex].DataBoundItem as Bill;
                    if (bill != null)
                    {
                        if (bill.Status)
                        {
                            e.CellStyle.BackColor = Color.PaleGreen;
                            e.CellStyle.ForeColor = Color.DarkGreen;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.LightCoral;
                            e.CellStyle.ForeColor = Color.DarkRed;
                        }
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                }

                // Định dạng màu cho các cột tiền tệ
                string[] moneyColumns = { "TỔNG TIỀN", "THỰC THU" };
                if (moneyColumns.Contains(dgvBills.Columns[e.ColumnIndex].HeaderText))
                {
                    e.CellStyle.ForeColor = Color.Blue;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }

                // Định dạng màu cho hàng được chọn
                if (dgvBills.Rows[e.RowIndex].Selected)
                {
                    e.CellStyle.SelectionBackColor = Color.SteelBlue;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private void dgvBillDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvBillDetails.Rows.Count)
            {
                // Định dạng màu cho các cột tiền tệ
                string[] moneyColumns = { "ĐƠN GIÁ", "THÀNH TIỀN" };
                if (moneyColumns.Contains(dgvBillDetails.Columns[e.ColumnIndex].HeaderText))
                {
                    e.CellStyle.ForeColor = Color.Blue;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }

                // Định dạng màu cho hàng được chọn
                if (dgvBillDetails.Rows[e.RowIndex].Selected)
                {
                    e.CellStyle.SelectionBackColor = Color.SteelBlue;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private void dgvBills_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Hiển thị số thứ tự
            var grid = sender as DataGridView;
            if (grid != null)
            {
                var rowIndex = (e.RowIndex + 1).ToString();
                var centerFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top,
                    grid.RowHeadersWidth, e.RowBounds.Height);
                e.Graphics.DrawString(rowIndex, this.Font, SystemBrushes.ControlText,
                    headerBounds, centerFormat);
            }
        }

        private void ExportToExcel()
        {
            try
            {
                if (listBills.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Xuất dữ liệu hóa đơn";
                saveFileDialog.FileName = $"HoaDon_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Trong thực tế, bạn sẽ sử dụng thư viện như EPPlus hoặc ClosedXML
                    // Ở đây tôi chỉ minh họa thông báo
                    MessageBox.Show($"Đã xuất {listBills.Count} hóa đơn ra file Excel!\nFile: {saveFileDialog.FileName}",
                        "Xuất Excel thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        // Thêm nút Export Excel vào grpAction (cần thêm trong Designer)
        private void InitializeAdditionalComponents()
        {
            // Thêm nút Export Excel
            Button btnExportExcel = new Button();
            btnExportExcel.BackColor = Color.LightGreen;
            btnExportExcel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
            btnExportExcel.Location = new Point(10, 75);
            btnExportExcel.Size = new Size(130, 30);
            btnExportExcel.TabIndex = 4;
            btnExportExcel.Text = "Xuất Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += new EventHandler(this.btnExportExcel_Click);

            // Thêm vào grpAction
            grpAction.Controls.Add(btnExportExcel);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}