using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Order
    {
        public enum OrderStatuses
        {
            New,
            InProgress,
            Complete
        }
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public OrderStatuses OrderStatus
        {
            get 
            {
                if (this.OrderDate == null)
                    return OrderStatuses.New;
                else if (this.ShippedDate == null)
                    return OrderStatuses.InProgress;
                else
                    return OrderStatuses.Complete;
            }
        }
    }
}
