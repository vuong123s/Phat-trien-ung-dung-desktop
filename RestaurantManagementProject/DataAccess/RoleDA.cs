using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleDA
    {
        public List<Role> GetAll()
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Role ORDER BY RoleName";

                SqlDataReader reader = command.ExecuteReader();
                List<Role> list = new List<Role>();

                while (reader.Read())
                {
                    Role role = new Role();
                    role.ID = Convert.ToInt32(reader["ID"]);
                    role.RoleName = reader["RoleName"].ToString();
                    role.Path = reader["Path"]?.ToString();
                    role.Notes = reader["Notes"]?.ToString();
                    list.Add(role);
                }

                sqlConn.Close();
                return list;
            }
        }

        public List<RoleAccount> GetAccountRoles(string accountName)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Utilities.GetAccountRoles;

                command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;

                SqlDataReader reader = command.ExecuteReader();
                List<RoleAccount> list = new List<RoleAccount>();

                while (reader.Read())
                {
                    RoleAccount roleAccount = new RoleAccount();
                    roleAccount.RoleID = Convert.ToInt32(reader["ID"]);
                    roleAccount.AccountName = accountName;
                    roleAccount.Actived = Convert.ToBoolean(reader["IsAssigned"]);
                    list.Add(roleAccount);
                }

                sqlConn.Close();
                return list;
            }
        }

        public int UpdateAccountRoles(string accountName, int roleID, bool isAssigned)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Utilities.UpdateAccountRoles;

                command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                command.Parameters.Add("@IsAssigned", SqlDbType.Bit).Value = isAssigned;

                int result = command.ExecuteNonQuery();
                return result;
            }
        }
    }
}