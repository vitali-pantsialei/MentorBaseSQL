using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNorthwind.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        [ForeignKey("Customer")]
        public string CustomerID { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        [ForeignKey("Shipper")]
        public int? ShipVia { get; set; }
        public Shipper Shipper { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }
}
