using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNorthwind.Model
{
    public class EmployeeTerritory
    {
        [ForeignKey("Employee")]
        public int? EmployeeID { get; set; }
        [ForeignKey("Territory")]
        public string TerritoryID { get; set; }
        public Employee Employee { get; set; }
        public Territory Territory { get; set; }
    }
}
