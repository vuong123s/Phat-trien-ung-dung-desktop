using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
    public partial class ActivityForm : Form
    {
        private string accountName;
        private string fullName;
        private DataTable billsTable;
        private Dictionary<string, int> billDateMapping;

        public ActivityForm(string accountName, string fullName)
        {
            InitializeComponent();
            this.accountName = accountName;
            this.fullName = fullName;
            this.billDateMapping = new Dictionary<string, int>();
        }

        private void ActivityForm_Load(object sender, EventArgs e)
        {
            lblAccountInfo.Text = $"Tài khoản: {accountName} - Họ tên: {fullName}";
            LoadAccountActivity();
        }

        private void LoadAccountActivity()
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "GetAccountActivity";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    billsTable = new DataTable();

                    conn.Open();
                    adapter.Fill(billsTable);

                    // Load vào ListBox
                    LoadBillsToListBox();

                    // Tính tổng kết
                    CalculateSummary();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải nhật ký hoạt động: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBillsToListBox()
        {
            lstBills.Items.Clear();
            billDateMapping.Clear();

            if (billsTable.Rows.Count > 0)
            {
                foreach (DataRow row in billsTable.Rows)
                {
                    int billID = Convert.ToInt32(row["ID"]);
                    string billName = row["BillName"].ToString();
                    DateTime checkoutDate = Convert.ToDateTime(row["CheckoutDate"]);
                    decimal totalAmount = Convert.ToDecimal(row["TotalAmount"]);

                    string displayText = $"{checkoutDate:dd/MM/yyyy HH:mm} - {billName} - {totalAmount:N0} đ";
                    string key = $"{billID}_{checkoutDate:yyyyMMddHHmm}";

                    lstBills.Items.Add(displayText);
                    billDateMapping[displayText] = billID;
                }

                if (lstBills.Items.Count > 0)
                    lstBills.SelectedIndex = 0;
            }
            else
            {
                lstBills.Items.Add("Không có hóa đơn nào");
            }
        }

        private void CalculateSummary()
        {
            if (billsTable.Rows.Count > 0)
            {
                int totalBills = billsTable.Rows.Count;
                decimal totalAmount = 0;

                foreach (DataRow row in billsTable.Rows)
                {
                    totalAmount += Convert.ToDecimal(row["TotalAmount"]);
                }

                lblTotalBills.Text = totalBills.ToString();
                lblTotalAmount.Text = totalAmount.ToString("N0") + " đ";
            }
            else
            {
                lblTotalBills.Text = "0";
                lblTotalAmount.Text = "0 đ";
            }
        }

        private void lstBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBills.SelectedIndex >= 0 && lstBills.SelectedIndex < lstBills.Items.Count)
            {
                string selectedItem = lstBills.SelectedItem.ToString();
                if (billDateMapping.ContainsKey(selectedItem))
                {
                    int billID = billDateMapping[selectedItem];
                    LoadBillDetails(billID);
                }
            }
        }

        private void LoadBillDetails(int billID)
        {
            try
            {
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "GetBillDetailsForActivity";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BillID", SqlDbType.Int).Value = billID;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

                    dgvBillDetails.DataSource = dt;
                    FormatBillDetailsGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatBillDetailsGrid()
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}