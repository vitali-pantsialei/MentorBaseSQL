using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DbTask.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [PrimaryKey, Identity]
        public int EmployeeID { get; set; }
        [Column, NotNull]
        public string LastName { get; set; }
        [Column, NotNull]
        public string FirstName { get; set; }
        [Column, Nullable]
        public string Title { get; set; }
        [Column, Nullable]
        public string TitleOfCourtesy { get; set; }
        [Column, Nullable]
        public DateTime BirthDate { get; set; }
        [Column, Nullable]
        public DateTime HireDate { get; set; }
        [Column, Nullable]
        public string Address { get; set; }
        [Column, Nullable]
        public string City { get; set; }
        [Column, Nullable]
        public string Region { get; set; }
        [Column, Nullable]
        public string PostalCode { get; set; }
        [Column, Nullable]
        public string Country { get; set; }
        [Column, Nullable]
        public string HomePhone { get; set; }
        [Column, Nullable]
        public string Extension { get; set; }
        [Column, Nullable]
        public byte[] Photo { get; set; }
        [Column, Nullable]
        public string Notes { get; set; }
        [Association(Storage="_customer", ThisKey="ReportsTo", OtherKey="EmployeeID")]
        public Employee GetEmployee
        {
            get { return _reportsTo.Entity; }
            set { _reportsTo.Entity = value; }
        }
        [Column, Nullable]
        public string PhotoPath { get; set; }

        private EntityRef<Employee> _reportsTo = new EntityRef<Employee>();
        [Column, Nullable]
        public int? ReportsTo;
    }
}
