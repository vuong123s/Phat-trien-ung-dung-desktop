using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab_Basic_Command
{
    public partial class BillDetailsForm : Form
    {
        private string connectionString = "server=.; database=RestaurantManagement; Integrated Security=True;";
        private int billId;

        public BillDetailsForm(int billId)
        {
            InitializeComponent();
            this.billId = billId;
        }

        private void BillDetailsForm_Load(object sender, EventArgs e)
        {
            LoadBillDetails();
            LoadBillInfo();
        }

        // Phương thức hiển thị thông tin chi tiết hóa đơn
        private void LoadBillDetails()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            f.Name AS FoodName,
                            bd.Quantity,
                            f.Price,
                            (bd.Quantity * f.Price) AS TotalAmount,
                            f.Unit
                        FROM BillDetails bd
                        JOIN Food f ON bd.FoodID = f.ID
                        WHERE bd.InvoiceID = @BillId
                        ORDER BY f.Name";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BillId", billId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvBillDetails.DataSource = dt;

                    // Tính tổng tiền
                    decimal total = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        total += row["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(row["TotalAmount"]) : 0;
                    }

                    lblTotal.Text = $"Tổng tiền: {total:N0}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức hiển thị thông tin chung của hóa đơn
        private void LoadBillInfo()
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
                        WHERE b.ID = @BillId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BillId", billId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        this.Text = $"Chi tiết hóa đơn #{reader["ID"]} - {reader["BillName"]}";

                        // Xử lý ngày checkout (có thể null)
                        object checkoutDateObj = reader["CheckoutDate"];
                        DateTime? checkoutDate = checkoutDateObj != DBNull.Value ? Convert.ToDateTime(checkoutDateObj) : (DateTime?)null;

                        decimal totalAmount = reader["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(reader["TotalAmount"]) : 0;
                        decimal discount = reader["Discount"] != DBNull.Value ? Convert.ToDecimal(reader["Discount"]) : 0;
                        decimal discountAmount = reader["DiscountAmount"] != DBNull.Value ? Convert.ToDecimal(reader["DiscountAmount"]) : 0;
                        decimal finalAmount = reader["FinalAmount"] != DBNull.Value ? Convert.ToDecimal(reader["FinalAmount"]) : 0;
                        string status = reader["Status"] != DBNull.Value && Convert.ToBoolean(reader["Status"]) ? "Đã thanh toán" : "Chưa thanh toán";

                        lblBillInfo.Text = $@"Hóa đơn: #{reader["ID"]} - {reader["BillName"]}
Bàn: {reader["TableName"]}
Trạng thái: {status}
Ngày thanh toán: {(checkoutDate.HasValue ? checkoutDate.Value.ToString("dd/MM/yyyy HH:mm") : "Chưa thanh toán")}
Tài khoản: {reader["Account"]}
Giảm giá: {discount:P2}
Tổng tiền: {totalAmount:N0}
Giảm giá: {discountAmount:N0}
Thực thu: {finalAmount:N0}";
                    }
                    else
                    {
                        lblBillInfo.Text = "Không tìm thấy thông tin hóa đơn";
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}