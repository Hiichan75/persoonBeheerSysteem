using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personBeheerSysteem.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentID { get; set; }

        public Department Department { get; set; }
        public List<Absence> Absences { get; set; }
    }
}
