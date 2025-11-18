using HR.DAL;
using HR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.BLL
{
    public class EmployeeBLL
    {
        EmployeeDAL ObjEmployeeDAL;
        public void AddEmployee(Employee objEmployee)
        {
            ObjEmployeeDAL = new EmployeeDAL();
            

            ObjEmployeeDAL.InsertEmployee(objEmployee);
        }

        internal void RemoveEmployee(string employeeID)
        {
            ObjEmployeeDAL = new EmployeeDAL();
            ObjEmployeeDAL.DeleteEmployee(employeeID);
        }
    }
}