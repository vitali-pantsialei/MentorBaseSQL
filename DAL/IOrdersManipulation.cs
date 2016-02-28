using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrdersManipulation
    {
        IList<Order> GetOrders();
        OrderDetails GetOrderDetails(Order order);
        void CreateOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(Order order);
        bool SetInProgress(Order order, DateTime? orderDate);
        void SetComplete(Order order, DateTime? shippedDate);
        IList<CustomerOrderHist> GetCustomerOrdersHistory(string customerId);
        IList<CustomerOrdersDetail> GetCustomerOrdersDetail(int orderId);
    }
}
