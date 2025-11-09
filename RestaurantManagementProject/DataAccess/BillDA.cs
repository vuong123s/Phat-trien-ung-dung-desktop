using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class BillDA
    {
        public List<Bill> GetAll()
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"
            SELECT 
                b.ID,
                b.Name,
                b.TableID,
                b.Amount,
                b.Discount,
                b.Tax,
                b.Status,
                b.CheckoutDate,
                b.Account,
                t.Name as TableName,
                CASE 
                    WHEN b.Status = 1 THEN 'Đã thanh toán'
                    ELSE 'Chưa thanh toán'
                END as StatusText,
                (b.Amount - (b.Amount * ISNULL(b.Discount, 0))) as ActualAmount
            FROM Bills b
            LEFT JOIN [Table] t ON b.TableID = t.ID
            ORDER BY b.CheckoutDate DESC";

                SqlDataReader reader = command.ExecuteReader();
                List<Bill> list = new List<Bill>();

                while (reader.Read())
                {
                    Bill bill = new Bill();
                    bill.ID = Convert.ToInt32(reader["ID"]);
                    bill.Name = reader["Name"]?.ToString() ?? "Hóa đơn";
                    bill.TableID = Convert.ToInt32(reader["TableID"]);
                    bill.TableName = reader["TableName"]?.ToString() ?? "Không xác định";
                    bill.Amount = Convert.ToInt32(reader["Amount"]);
                    bill.Discount = reader["Discount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Discount"]);
                    bill.Tax = reader["Tax"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Tax"]);
                    bill.Status = reader["Status"] == DBNull.Value ? false : Convert.ToBoolean(reader["Status"]);
                    bill.StatusText = reader["StatusText"]?.ToString() ?? "Không xác định";
                    bill.CheckoutDate = reader["CheckoutDate"] as DateTime?;
                    bill.Account = reader["Account"]?.ToString() ?? "Không xác định";
                    bill.ActualAmount = reader["ActualAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ActualAmount"]);
                    list.Add(bill);
                }

                sqlConn.Close();
                return list;
            }
        }

        public Bill GetCurrentBillByTable(int tableID)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"
            SELECT TOP 1 
                b.ID,
                b.Name,
                b.TableID,
                b.Amount,
                b.Discount,
                b.Tax,
                b.Status,
                b.CheckoutDate,
                b.Account,
                t.Name as TableName,
                CASE 
                    WHEN b.Status = 1 THEN 'Đã thanh toán'
                    ELSE 'Chưa thanh toán'
                END as StatusText,
                (b.Amount - (b.Amount * ISNULL(b.Discount, 0))) as ActualAmount
            FROM Bills b
            LEFT JOIN [Table] t ON b.TableID = t.ID
            WHERE b.TableID = @TableID AND b.Status = 0
            ORDER BY b.ID DESC";

                command.Parameters.Add("@TableID", SqlDbType.Int).Value = tableID;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Bill bill = new Bill();
                    bill.ID = Convert.ToInt32(reader["ID"]);
                    bill.Name = reader["Name"]?.ToString() ?? "Hóa đơn";
                    bill.TableID = Convert.ToInt32(reader["TableID"]);
                    bill.TableName = reader["TableName"]?.ToString() ?? "Không xác định";
                    bill.Amount = Convert.ToInt32(reader["Amount"]);
                    bill.Discount = reader["Discount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Discount"]);
                    bill.Tax = reader["Tax"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Tax"]);
                    bill.Status = reader["Status"] == DBNull.Value ? false : Convert.ToBoolean(reader["Status"]);
                    bill.StatusText = reader["StatusText"]?.ToString() ?? "Không xác định";
                    bill.CheckoutDate = reader["CheckoutDate"] as DateTime?;
                    bill.Account = reader["Account"]?.ToString() ?? "Không xác định";
                    bill.ActualAmount = reader["ActualAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ActualAmount"]);
                    return bill;
                }

                sqlConn.Close();
                return null;
            }
        }

        public List<BillDetail> GetBillDetails(int billID)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"
            SELECT 
                bd.ID,
                f.Name as FoodName,
                bd.Quantity,
                f.Price,
                (bd.Quantity * f.Price) as TotalPrice,
                f.Unit,
                c.Name as CategoryName
            FROM BillDetails bd
            JOIN Food f ON bd.FoodID = f.ID
            JOIN Category c ON f.FoodCategoryID = c.ID
            WHERE bd.InvoiceID = @BillID
            ORDER BY bd.ID";

                command.Parameters.Add("@BillID", SqlDbType.Int).Value = billID;

                SqlDataReader reader = command.ExecuteReader();
                List<BillDetail> list = new List<BillDetail>();

                while (reader.Read())
                {
                    BillDetail detail = new BillDetail();
                    detail.ID = Convert.ToInt32(reader["ID"]);
                    detail.FoodName = reader["FoodName"]?.ToString() ?? "Không xác định";
                    detail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    detail.Price = reader["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Price"]);
                    detail.TotalPrice = reader["TotalPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TotalPrice"]);
                    detail.Unit = reader["Unit"]?.ToString() ?? "";
                    detail.CategoryName = reader["CategoryName"]?.ToString() ?? "Không xác định";
                    list.Add(detail);
                }

                sqlConn.Close();
                return list;
            }
        }

        public int CreateBill(Bill bill, List<BillDetail> details)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                using (SqlTransaction transaction = sqlConn.BeginTransaction())
                {
                    try
                    {
                        // Insert Bill - ensure Account is never NULL
                        using (SqlCommand cmd = sqlConn.CreateCommand())
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = @"
                                INSERT INTO dbo.Bills ([Name], TableID, Amount, Discount, Tax, [Status], CheckoutDate, [Account])
                                VALUES (@Name, @TableID, @Amount, @Discount, @Tax, @Status, @CheckoutDate, @Account);
                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = (object)bill.Name ?? DBNull.Value;
                            cmd.Parameters.Add("@TableID", SqlDbType.Int).Value = bill.TableID;
                            cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = bill.Amount;
                            cmd.Parameters.Add("@Discount", SqlDbType.Float).Value = bill.Discount;
                            cmd.Parameters.Add("@Tax", SqlDbType.Float).Value = bill.Tax;
                            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = bill.Status;
                            cmd.Parameters.Add("@CheckoutDate", SqlDbType.SmallDateTime).Value = bill.CheckoutDate.HasValue ? (object)bill.CheckoutDate.Value : DBNull.Value;

                            // IMPORTANT: ensure a non-null value is sent for Account (DB column is NOT NULL)
                            // Use bill.Account if provided, otherwise use a safe default like "system"
                            string accountValue = string.IsNullOrWhiteSpace(bill.Account) ? "system" : bill.Account;
                            cmd.Parameters.Add("@Account", SqlDbType.NVarChar, 100).Value = accountValue;

                            var res = cmd.ExecuteScalar();
                            if (res == null || res == DBNull.Value)
                                throw new Exception("Không thể lấy ID của hóa đơn mới.");

                            int billID = Convert.ToInt32(res);

                            // Insert Bill Details
                            if (details != null)
                            {
                                foreach (var detail in details)
                                {
                                    if (detail == null) continue;

                                    using (SqlCommand cmdDetail = sqlConn.CreateCommand())
                                    {
                                        cmdDetail.Transaction = transaction;
                                        cmdDetail.CommandType = CommandType.Text;
                                        cmdDetail.CommandText = @"
                                            INSERT INTO dbo.BillDetails (InvoiceID, FoodID, Quantity)
                                            VALUES (@InvoiceID, @FoodID, @Quantity);";

                                        cmdDetail.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = billID;
                                        cmdDetail.Parameters.Add("@FoodID", SqlDbType.Int).Value = detail.FoodID;
                                        cmdDetail.Parameters.Add("@Quantity", SqlDbType.Int).Value = detail.Quantity;

                                        cmdDetail.ExecuteNonQuery();
                                    }
                                }
                            }

                            // Update Table Status
                            using (SqlCommand cmdUpdate = sqlConn.CreateCommand())
                            {
                                cmdUpdate.Transaction = transaction;
                                cmdUpdate.CommandType = CommandType.Text;
                                cmdUpdate.CommandText = "UPDATE dbo.[Table] SET Status = 1 WHERE ID = @TableID";
                                cmdUpdate.Parameters.Add("@TableID", SqlDbType.Int).Value = bill.TableID;
                                cmdUpdate.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return billID;
                        }
                    }
                    catch
                    {
                        try { transaction.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }
    }
}