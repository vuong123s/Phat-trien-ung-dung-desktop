using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDA
    {
        private bool HasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (string.Equals(reader.GetName(i), columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public List<Account> GetAll()
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Utilities.GetAllAccounts;

                SqlDataReader reader = command.ExecuteReader();
                List<Account> list = new List<Account>();

                while (reader.Read())
                {
                    Account account = new Account();
                    if (HasColumn(reader, "AccountName")) account.AccountName = reader["AccountName"]?.ToString();
                    if (HasColumn(reader, "Password")) account.Password = reader["Password"]?.ToString();
                    if (HasColumn(reader, "FullName")) account.FullName = reader["FullName"]?.ToString();
                    if (HasColumn(reader, "Email")) account.Email = reader["Email"]?.ToString();
                    if (HasColumn(reader, "Tell")) account.Tell = reader["Tell"]?.ToString();
                    if (HasColumn(reader, "DateCreated")) account.DateCreated = reader["DateCreated"] as DateTime?;
                    // If Role column exists in SP, read it
                    if (HasColumn(reader, "Role")) account.Role = reader["Role"]?.ToString();

                    list.Add(account);
                }

                sqlConn.Close();
                return list;
            }
        }

        public int Insert(Account account)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Utilities.InsertAccount;

                command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = account.AccountName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = account.Password;
                command.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000).Value = account.FullName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 1000).Value = account.Email ?? "";
                command.Parameters.Add("@Tell", SqlDbType.NVarChar, 200).Value = account.Tell ?? "";

                int result = command.ExecuteNonQuery();
                return result;
            }
        }

        public int Update(Account account)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Utilities.UpdateAccount;

                command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = account.AccountName;
                command.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000).Value = account.FullName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 1000).Value = account.Email ?? "";
                command.Parameters.Add("@Tell", SqlDbType.NVarChar, 200).Value = account.Tell ?? "";

                int result = command.ExecuteNonQuery();
                return result;
            }
        }
        public Account Login(string accountName, string password)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LoginAccount"; // Tên stored procedure

                command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = password;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Account account = new Account();
                    if (HasColumn(reader, "AccountName")) account.AccountName = reader["AccountName"]?.ToString();
                    if (HasColumn(reader, "Password")) account.Password = reader["Password"]?.ToString();
                    if (HasColumn(reader, "FullName")) account.FullName = reader["FullName"]?.ToString();
                    if (HasColumn(reader, "Email")) account.Email = reader["Email"]?.ToString();
                    if (HasColumn(reader, "Tell")) account.Tell = reader["Tell"]?.ToString();
                    if (HasColumn(reader, "DateCreated")) account.DateCreated = reader["DateCreated"] as DateTime?;
                    if (HasColumn(reader, "Role")) account.Role = reader["Role"]?.ToString();
                    return account;
                }

                return null; // Không tìm thấy account
            }
        }

        public int ResetPassword(string accountName, string newPassword)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Utilities.ResetPassword;

                command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;
                command.Parameters.Add("@NewPassword", SqlDbType.NVarChar, 200).Value = newPassword;

                int result = command.ExecuteNonQuery();
                return result;
            }
        }
    }
}