using HR.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewEmployee(Employee objEmployee)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            objEmployeeDAL.InsertEmployee(objEmployee);
            return View();
        }

        public ActionResult ShowEmployee()
        {
            return View();
        }


    }
}