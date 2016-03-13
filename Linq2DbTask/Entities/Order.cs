using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DbTask.Entities
{
    [Table("Orders")]
    public class Order
    {
        [PrimaryKey, Identity]
        public int OrderID { get; set; }
        [Association(Storage="_customer", ThisKey="CustomerID", OtherKey="CustomerID")]
        public Customer Customer
        {
            get { return _customer.Entity; }
            set { _customer.Entity = value; }
        }
        [Association(Storage = "_employee", ThisKey = "EmployeeID", OtherKey="EmployeeID")]
        public Employee Employee
        {
            get { return _employee.Entity; }
            set { _employee.Entity = value; }
        }
        [Column, Nullable]
        public DateTime OrderDate { get; set; }
        [Column, Nullable]
        public DateTime RequiredDate { get; set; }
        [Column, Nullable]
        public DateTime ShippedDate { get; set; }
        [Association(Storage = "_shipper", ThisKey = "ShipVia", OtherKey="ShipperID")]
        public Shipper Shipper
        {
            get { return _shipper.Entity; }
            set { _shipper.Entity = value; }
        }
        [Column, Nullable]
        public decimal Freight { get; set; }
        [Column, Nullable]
        public string ShipName { get; set; }
        [Column, Nullable]
        public string ShipAddress { get; set; }
        [Column, Nullable]
        public string ShipCity { get; set; }
        [Column, Nullable]
        public string ShipRegion { get; set; }
        [Column, Nullable]
        public string ShipPostalCode { get; set; }
        [Column, Nullable]
        public string ShipCountry { get; set; }

        private EntityRef<Customer> _customer = new EntityRef<Customer>();
        private EntityRef<Employee> _employee = new EntityRef<Employee>();
        private EntityRef<Shipper> _shipper = new EntityRef<Shipper>();
        [Column, Nullable]
        public string CustomerID;
        [Column, Nullable]
        public int? EmployeeID;
        [Column, Nullable]
        public int? ShipVia;
    }
}
