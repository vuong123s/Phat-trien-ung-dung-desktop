using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
    public partial class OrderDetailsForm : Form
    {
        private int billID;
        private string billName;

        public OrderDetailsForm(int billID, string billName)
        {
            InitializeComponent();
            this.billID = billID;
            this.billName = billName;
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            lblBillInfo.Text = $"Hóa đơn: {billName} (Mã: {billID})";
            LoadBillDetails();
        }

        private void LoadBillDetails()
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "GetBillDetails";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BillID", SqlDbType.Int).Value = billID;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

                    // Bind to DataGridView
                    dgvBillDetails.DataSource = dt;

                    // Format columns
                    FormatDataGridView();

                    // Calculate totals
                    CalculateTotals(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dgvBillDetails.Columns.Count > 0)
            {
                dgvBillDetails.Columns["FoodName"].HeaderText = "Tên món ăn";
                dgvBillDetails.Columns["CategoryName"].HeaderText = "Nhóm";
                dgvBillDetails.Columns["Quantity"].HeaderText = "Số lượng";
                dgvBillDetails.Columns["Price"].HeaderText = "Đơn giá";
                dgvBillDetails.Columns["TotalPrice"].HeaderText = "Thành tiền";
                dgvBillDetails.Columns["Unit"].HeaderText = "Đơn vị";

                // Format currency columns
                if (dgvBillDetails.Columns["Price"] != null)
                    dgvBillDetails.Columns["Price"].DefaultCellStyle.Format = "N0";
                if (dgvBillDetails.Columns["TotalPrice"] != null)
                    dgvBillDetails.Columns["TotalPrice"].DefaultCellStyle.Format = "N0";
            }
        }

        private void CalculateTotals(DataTable dt)
        {
            int totalQuantity = 0;
            decimal totalAmount = 0;

            foreach (DataRow row in dt.Rows)
            {
                totalQuantity += Convert.ToInt32(row["Quantity"]);
                totalAmount += Convert.ToDecimal(row["TotalPrice"]);
            }

            lblTotalQuantity.Text = totalQuantity.ToString();
            lblTotalAmount.Text = totalAmount.ToString("N0") + " đ";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}