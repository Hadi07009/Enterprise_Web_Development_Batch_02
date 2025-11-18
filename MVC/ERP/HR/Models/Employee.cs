using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Models
{
    public class Employee
    {
        string _name;
        string _email;
        string _mobileNo;

        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string MobileNo { get => _mobileNo; set => _mobileNo = value; }

    }
}