using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HR.Models
{
    public class EmployeeDAL
    {
        public void InsertEmployee( Employee objEmployee)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["dberpbatch2connection"].ToString();
            const string sql = @"INSERT INTO [dbo].[Employee] ([Name], [Email], [MobileNo]) VALUES (@Name, @Email, @MobileNo);";

            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            {

                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = (object)objEmployee.Name ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Value = (object)objEmployee.Email ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@MobileNo", SqlDbType.NVarChar, 15) { Value = (object)objEmployee.MobileNo ?? DBNull.Value });

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}