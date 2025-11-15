using HR.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.BLL
{
    public class EmployeeBLL
    {
        EmployeeDAL ObjEmployeeDAL;
        public void AddEmployee(string name, string email, string mobile)
        {
            ObjEmployeeDAL = new EmployeeDAL();

            ObjEmployeeDAL.InsertEmployee( name, email, mobile);
        }

        internal void RemoveEmployee(string employeeID)
        {
            ObjEmployeeDAL = new EmployeeDAL();
            ObjEmployeeDAL.DeleteEmployee(employeeID);
        }
    }
}