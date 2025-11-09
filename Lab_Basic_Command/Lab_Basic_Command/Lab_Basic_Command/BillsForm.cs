using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab_Basic_Command
{
    public partial class BillsForm : Form
    {
        private string connectionString = "server=.; database=RestaurantManagement; Integrated Security=True;";

        public BillsForm()
        {
            InitializeComponent();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {
            // Set default date range (last 30 days)
            dtpFromDate.Value = DateTime.Now.AddDays(-30);
            dtpToDate.Value = DateTime.Now;

            LoadBills();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadBills();
        }

        // Phương thức hiển thị danh sách hóa đơn
        private void LoadBills()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            b.ID,
                            b.Name AS BillName,
                            b.TableID,
                            t.Name AS TableName,
                            b.CheckoutDate,
                            b.Status,
                            b.Discount,
                            b.Amount AS TotalAmount,
                            b.Amount * ISNULL(b.Discount, 0) AS DiscountAmount,
                            b.Amount * (1 - ISNULL(b.Discount, 0)) AS FinalAmount,
                            b.Account
                        FROM Bills b
                        JOIN [Table] t ON b.TableID = t.ID
                        WHERE b.CheckoutDate BETWEEN @FromDate AND @ToDate
                        ORDER BY b.CheckoutDate DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                    cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date.AddDays(1).AddSeconds(-1));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvBills.DataSource = dt;

                    // Tính tổng
                    CalculateTotals(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức tính tổng các số tiền
        private void CalculateTotals(DataTable dt)
        {
            decimal totalAmount = 0;
            decimal totalDiscount = 0;
            decimal totalFinal = 0;

            foreach (DataRow row in dt.Rows)
            {
                totalAmount += row["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(row["TotalAmount"]) : 0;
                totalDiscount += row["DiscountAmount"] != DBNull.Value ? Convert.ToDecimal(row["DiscountAmount"]) : 0;
                totalFinal += row["FinalAmount"] != DBNull.Value ? Convert.ToDecimal(row["FinalAmount"]) : 0;
            }

            txtTotalAmount.Text = totalAmount.ToString("N0");
            txtTotalDiscount.Text = totalDiscount.ToString("N0");
            txtFinalAmount.Text = totalFinal.ToString("N0");
        }

        // Xử lý double click để mở BillDetailsForm
        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvBills.Rows.Count)
            {
                int billId = Convert.ToInt32(dgvBills.Rows[e.RowIndex].Cells["ID"].Value);

                BillDetailsForm detailsForm = new BillDetailsForm(billId);
                detailsForm.ShowDialog();
            }
        }
    }
}