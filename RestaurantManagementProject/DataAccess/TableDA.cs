using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TableDA
    {
        public List<Table> GetAll()
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM [Table] ORDER BY Name";

                SqlDataReader reader = command.ExecuteReader();
                List<Table> list = new List<Table>();

                while (reader.Read())
                {
                    Table table = new Table();
                    table.ID = Convert.ToInt32(reader["ID"]);
                    table.Name = reader["Name"].ToString();
                    table.Status = Convert.ToInt32(reader["Status"]);
                    table.Capacity = Convert.ToInt32(reader["Capacity"]);
                    list.Add(table);
                }

                sqlConn.Close();
                return list;
            }
        }

        public int Insert(Table table)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO [Table] (Name, Status, Capacity) VALUES (@Name, @Status, @Capacity)";

                command.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = table.Name;
                command.Parameters.Add("@Status", SqlDbType.Int).Value = table.Status;
                command.Parameters.Add("@Capacity", SqlDbType.Int).Value = table.Capacity;

                int result = command.ExecuteNonQuery();
                return result;
            }
        }

        public int Update(Table table)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE [Table] SET Name = @Name, Status = @Status, Capacity = @Capacity WHERE ID = @ID";

                command.Parameters.Add("@ID", SqlDbType.Int).Value = table.ID;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = table.Name;
                command.Parameters.Add("@Status", SqlDbType.Int).Value = table.Status;
                command.Parameters.Add("@Capacity", SqlDbType.Int).Value = table.Capacity;

                int result = command.ExecuteNonQuery();
                return result;
            }
        }

        public int Delete(int tableID)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM [Table] WHERE ID = @ID";

                command.Parameters.Add("@ID", SqlDbType.Int).Value = tableID;

                int result = command.ExecuteNonQuery();
                return result;
            }
        }

        public int UpdateStatus(int tableID, int status)
        {
            using (SqlConnection sqlConn = new SqlConnection(Utilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE [Table] SET Status = @Status WHERE ID = @ID";

                command.Parameters.Add("@ID", SqlDbType.Int).Value = tableID;
                command.Parameters.Add("@Status", SqlDbType.Int).Value = status;

                int result = command.ExecuteNonQuery();
                return result;
            }
        }
    }
}