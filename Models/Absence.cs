using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persoonBeheerSysteem.Models
{
    public class Absence
    {
        public int AbsenceID { get; set; } //PK
        public int EmployeeID { get; set; } // FOREIGN KEY -> employee
        public DateTime Date { get; set; }
        public string Reason { get; set; }

        public Employee Employee { get; set; }
    }
}
