using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNorthwind.Model
{
    public class EmployeeCard
    {
        public int EmployeeCardID { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string CardHolder { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
