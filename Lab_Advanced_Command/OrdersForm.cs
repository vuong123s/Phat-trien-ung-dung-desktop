using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadAllBills();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadBills();
        }
        private void LoadAllBills()
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "GetAllBills";  // Gọi stored procedure lấy TẤT CẢ
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

                    // Bind to DataGridView
                    dgvBills.DataSource = dt;

                    // Format columns
                    FormatDataGridView();

                    // Calculate totals
                    CalculateTotals(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadBills()
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();

                    // Kiểm tra nếu date range quá rộng thì dùng GetAllBills
                    if (dtpFromDate.Value <= new DateTime(2000, 1, 1) && dtpToDate.Value >= DateTime.Today.AddYears(10))
                    {
                        cmd.CommandText = "GetAllBills";
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    else
                    {
                        cmd.CommandText = "GetBillsByDateRange";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = dtpFromDate.Value;
                        cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = dtpToDate.Value;
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

                    // Bind to DataGridView
                    dgvBills.DataSource = dt;

                    // Format columns
                    FormatDataGridView();

                    // Calculate totals
                    CalculateTotals(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void FormatDataGridView()
        {
            if (dgvBills.Columns.Count > 0)
            {
                dgvBills.Columns["ID"].HeaderText = "Mã HĐ";
                dgvBills.Columns["BillName"].HeaderText = "Tên hóa đơn";
                dgvBills.Columns["TableName"].HeaderText = "Bàn";
                dgvBills.Columns["TotalAmount"].HeaderText = "Tổng tiền";
                dgvBills.Columns["Discount"].HeaderText = "Giảm giá";
                dgvBills.Columns["ActualAmount"].HeaderText = "Thực thu";
                dgvBills.Columns["CheckoutDate"].HeaderText = "Ngày thanh toán";
                dgvBills.Columns["AccountName"].HeaderText = "Nhân viên";

                // Format currency columns
                if (dgvBills.Columns["TotalAmount"] != null)
                    dgvBills.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                if (dgvBills.Columns["ActualAmount"] != null)
                    dgvBills.Columns["ActualAmount"].DefaultCellStyle.Format = "N0";
                if (dgvBills.Columns["Discount"] != null)
                    dgvBills.Columns["Discount"].DefaultCellStyle.Format = "P2";

                // Format datetime
                if (dgvBills.Columns["CheckoutDate"] != null)
                    dgvBills.Columns["CheckoutDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        private void CalculateTotals(DataTable dt)
        {
            decimal totalAmount = 0;
            decimal totalDiscount = 0;
            decimal totalActual = 0;

            foreach (DataRow row in dt.Rows)
            {
                totalAmount += Convert.ToDecimal(row["TotalAmount"]);
                totalDiscount += Convert.ToDecimal(row["TotalAmount"]) * Convert.ToDecimal(row["Discount"]);
                totalActual += Convert.ToDecimal(row["ActualAmount"]);
            }

            lblTotalAmount.Text = totalAmount.ToString("N0") + " đ";
            lblTotalDiscount.Text = totalDiscount.ToString("N0") + " đ";
            lblTotalActual.Text = totalActual.ToString("N0") + " đ";
        }

        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvBills.RowCount)
            {
                ViewBillDetails();
            }
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBillDetails();
        }

        private void ViewBillDetails()
        {
            if (dgvBills.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvBills.SelectedRows[0];
                int billID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                string billName = selectedRow.Cells["BillName"].Value.ToString();

                OrderDetailsForm detailsForm = new OrderDetailsForm(billID, billName);
                detailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void viewDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewBillDetails();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dgvBills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}