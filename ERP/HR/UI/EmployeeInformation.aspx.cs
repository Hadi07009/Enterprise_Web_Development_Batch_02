using HR.BLL;
using HR.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR.UI
{
    public partial class EmployeeInformation : System.Web.UI.Page
    {
        EmployeeBLL ObjEmployeeBLL;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Employee objEmployee = new Employee();
                objEmployee._name = txtEmployeeName.Text;
                objEmployee._email = txtEmail.Text;
                objEmployee._mobileNo = txtMobileNo.Text;
                objEmployee._tinNo = "";
                ObjEmployeeBLL = new EmployeeBLL();
                ObjEmployeeBLL.AddEmployee(objEmployee);                
                ClearControl();
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeName = txtEmployeeName.Text;
                string employeeEmail = txtEmail.Text;
                string employeeMobileNo = txtMobileNo.Text;
                int employeeID = Convert.ToInt32( txtID.Text);

                string sql = @"UPDATE [dbo].[Employee]
                               SET[Name] = @Name
                                  ,[Email] = @Email
                                  ,[MobileNo] = @MobileNo
                            WHERE ID=@ID";

                string connectionString = ConfigurationManager.ConnectionStrings["dberpbatch2connection"].ToString();

                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@Name", employeeName);
                        cmd.Parameters.AddWithValue("@Email", employeeEmail);
                        cmd.Parameters.AddWithValue("@MobileNo", employeeMobileNo);
                        cmd.Parameters.AddWithValue("@ID", employeeID);

                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                ClearControl();
            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int employeeID = Convert.ToInt32(txtID.Text);
                string sql = @"DELETE FROM [dbo].[Employee]
                                WHERE ID=@ID";

                string connectionString = ConfigurationManager.ConnectionStrings["dberpbatch2connection"].ToString();

                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@ID", employeeID);

                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                ClearControl();
            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        private static void ExecuteSql(string sql)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dberpbatch2connection"].ToString();
                var myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                new SqlCommand(sql, myConnection).ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ClearControl()
        {
            
            txtEmployeeName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtID.Text = string.Empty;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowEmployee();

        }

        private void ShowEmployee()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dberpbatch2connection"].ToString();
                DataTable dtEmployee = new DataTable();
                string query = @"SELECT [Name]
                              ,[Email]
                              ,[MobileNo]
                              ,[ID]
                          FROM[dbo].[Employee]";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter daAdapter = new SqlDataAdapter(cmd))
                {
                    daAdapter.Fill(dtEmployee);
                }

                grdEmployee.DataSource = dtEmployee;
                grdEmployee.DataBind();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
             

            string employeeID = ((Label)grdEmployee.Rows[selectedIndex].FindControl("lblID")).Text;
            

            if (e.CommandName.Equals("Select"))
            {
                txtEmployeeName.Text = ((Label)grdEmployee.Rows[selectedIndex].FindControl("lblEmployeeName")).Text;
                txtEmail.Text = ((Label)grdEmployee.Rows[selectedIndex].FindControl("lblEmail")).Text;
                txtMobileNo.Text= ((Label)grdEmployee.Rows[selectedIndex].FindControl("lblMobileNo")).Text;
                txtID.Text= ((Label)grdEmployee.Rows[selectedIndex].FindControl("lblID")).Text;



            }
            else if (e.CommandName.Equals("Delete"))
            {
                ObjEmployeeBLL = new EmployeeBLL();
                ObjEmployeeBLL.RemoveEmployee(employeeID);                
                ShowEmployee();
            }

        }

        protected void grdEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}