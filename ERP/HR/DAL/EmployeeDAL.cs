using HR.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HR.DAL
{
    public class EmployeeDAL
    {
        private readonly string _connectionString;


        public EmployeeDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["dberpbatch2connection"].ToString();
        }

        public void InsertEmployee(Employee objEmployee)
        {
            try
            {
                const string sql = @"INSERT INTO [dbo].[Employee] ([Name], [Email], [MobileNo]) VALUES (@Name, @Email, @MobileNo);";

                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(sql, con))
                {

                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = (object)objEmployee._name ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Value = (object)objEmployee._email ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", SqlDbType.NVarChar, 15) { Value = (object)objEmployee._mobileNo ?? DBNull.Value });

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        public void UpdateEmployee(int id, string name, string email, string mobile)
        {
            const string sql = @"
            UPDATE Employee
            SET Name = @Name, Email = @Email, MobileNo = @MobileNo
            WHERE EmployeeID = @ID;";

            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = id });
                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = (object)name ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Value = (object)email ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@MobileNo", SqlDbType.NVarChar, 15) { Value = (object)mobile ?? DBNull.Value });

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(string employeeID)
        {
            try
            {
                string sql = @"DELETE FROM [dbo].[Employee]
                                WHERE ID=@ID";

                using (SqlConnection myConnection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@ID", employeeID);

                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}