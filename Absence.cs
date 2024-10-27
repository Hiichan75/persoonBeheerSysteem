using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personBeheerSysteem.Models
{
    public class Absence
    {
        public int AbsenceID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }

        public Employee Employee { get; set; }
    }
}
