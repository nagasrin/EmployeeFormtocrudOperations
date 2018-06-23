using System;
using System.Collections.Generic;

namespace Test_Employee.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
