using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DbTask.Entities
{
    [Table("EmployeeTerritories")]
    public class EmployeeTerritory
    {
        [Association(Storage = "_employee", ThisKey = "EmployeeID", OtherKey="EmployeeID")]
        public Employee Employee
        {
            get { return _employee.Entity; }
            set { _employee.Entity = value; }
        }
        [Association(Storage="_territory", ThisKey="TerritoryID", OtherKey="TerritoryID")]
        public Territory Territory
        {
            get { return _territory.Entity; }
            set { _territory.Entity = value; }
        }

        private EntityRef<Employee> _employee = new EntityRef<Employee>();
        private EntityRef<Territory> _territory = new EntityRef<Territory>();
        [Column, NotNull, PrimaryKey]
        public int? EmployeeID;
        [Column, NotNull, PrimaryKey]
        public string TerritoryID;
    }
}
