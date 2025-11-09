using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_Basic_Command
{
    public partial class MainForm : Form
    {
        private string connectionString = "server=.; database = RestaurantManagement; Integrated Security = True; ";
        private int selectedTableId = -1;

        public MainForm()
        {
            InitializeComponent();
            LoadTableList();
            LoadCategoryList();
        }

        // ---------------- HIỂN THỊ DANH SÁCH BÀN ----------------
        private void LoadTableList()
        {
            flowLayoutPanelTables.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID, Name, Status FROM [Table]";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Button btn = new Button()
                    {
                        Width = 100,
                        Height = 60,
                        Text = reader["Name"].ToString() + Environment.NewLine + reader["Status"].ToString(),
                        Tag = reader["ID"],
                        BackColor = reader["Status"].ToString() == "Có người" ? Color.LightPink : Color.Aqua
                    };
                    btn.Click += TableButton_Click;
                    flowLayoutPanelTables.Controls.Add(btn);
                }
            }
        }

        // ---------------- CLICK VÀO BÀN ----------------
        private void TableButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            selectedTableId = (int)btn.Tag;
            ShowBill(selectedTableId);
        }

        // ---------------- HIỂN THỊ HÓA ĐƠN ----------------
        private void ShowBill(int tableId)
        {
            dataGridViewBill.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT f.Name, bd.Quantity, f.Price, (f.Price * bd.Quantity) AS Total
                    FROM BillDetails bd
                    JOIN Bills b ON bd.InvoiceID = b.ID
                    JOIN Food f ON bd.FoodID = f.ID
                    WHERE b.TableID = @TableID AND b.Status = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TableID", tableId);

                SqlDataReader reader = cmd.ExecuteReader();
                double totalPrice = 0;

                while (reader.Read())
                {
                    double total = Convert.ToDouble(reader["Total"]);
                    totalPrice += total;
                    dataGridViewBill.Rows.Add(reader["Name"], reader["Quantity"], reader["Price"], total);
                }

                txtTotal.Text = totalPrice.ToString("N0");
            }
        }

        // ---------------- HIỂN THỊ DANH MỤC MÓN ----------------
        private void LoadCategoryList()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Category";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboCategory.DisplayMember = "Name";
                comboCategory.ValueMember = "ID";
                comboCategory.DataSource = dt;
            }
        }

        // ---------------- KHI CHỌN LOẠI MÓN ----------------
        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCategory.SelectedValue != null)
                LoadFoodListByCategory((int)comboCategory.SelectedValue);
        }

        private void LoadFoodListByCategory(int categoryId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Food WHERE FoodCategoryID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", categoryId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboFood.DisplayMember = "Name";
                comboFood.ValueMember = "ID";
                comboFood.DataSource = dt;
            }
        }

        // ---------------- THÊM MÓN ----------------
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn!");
                return;
            }

            int foodId = (int)comboFood.SelectedValue;
            int quantity = (int)numericQuantity.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra có hóa đơn chưa thanh toán chưa
                string queryBill = "SELECT ID FROM Bills WHERE TableID = @tableId AND Status = 0";
                SqlCommand cmdBill = new SqlCommand(queryBill, conn);
                cmdBill.Parameters.AddWithValue("@tableId", selectedTableId);

                object result = cmdBill.ExecuteScalar();
                int billId;

                if (result == null)
                {
                    // Tạo hóa đơn mới
                    string insertBill = "INSERT INTO Bills (TableID, DateCheckIn, Status) VALUES (@tableId, GETDATE(), 0); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdInsert = new SqlCommand(insertBill, conn);
                    cmdInsert.Parameters.AddWithValue("@tableId", selectedTableId);
                    billId = Convert.ToInt32(cmdInsert.ExecuteScalar());
                }
                else
                {
                    billId = Convert.ToInt32(result);
                }

                // Thêm chi tiết món
                string insertDetail = @"
                    INSERT INTO BillDetails (InvoiceID, FoodID, Quantity)
                    VALUES (@billId, @foodId, @quantity)";
                SqlCommand cmdDetail = new SqlCommand(insertDetail, conn);
                cmdDetail.Parameters.AddWithValue("@billId", billId);
                cmdDetail.Parameters.AddWithValue("@foodId", foodId);
                cmdDetail.Parameters.AddWithValue("@quantity", quantity);
                cmdDetail.ExecuteNonQuery();

                MessageBox.Show("Đã thêm món vào bàn!");
                ShowBill(selectedTableId);
            }
        }

        // ---------------- THANH TOÁN ----------------
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Bills SET Status = 1, DateCheckOut = GETDATE() WHERE TableID = @tableId AND Status = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tableId", selectedTableId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thanh toán thành công!");
                LoadTableList();
                ShowBill(selectedTableId);
            }
        }
    }
}
