using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NorthwindOrders : IOrdersManipulation
    {
        private string connectionName = "NorthwindConnection";
        private DbConnection connection;

        public NorthwindOrders()
        {
            ConfigureConnection(ConfigurationManager.ConnectionStrings[this.connectionName].ConnectionString, ConfigurationManager.ConnectionStrings[this.connectionName].ProviderName);
        }

        public NorthwindOrders(string connectionName)
        {
            this.connectionName = connectionName;
            ConfigureConnection(ConfigurationManager.ConnectionStrings[this.connectionName].ConnectionString, ConfigurationManager.ConnectionStrings[this.connectionName].ProviderName);
        }

        public NorthwindOrders(string connectionString, string providerName = "System.Data.SqlClient")
        {
            ConfigureConnection(connectionString, providerName);
        }

        public IList<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            DbCommand command = this.connection.CreateCommand();
            command.CommandText = "select * from Orders";
            connection.Open();

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    DateTime date1, date2, date3;
                    bool date1B = DateTime.TryParse(reader["OrderDate"].ToString(), out date1);
                    bool date2B = DateTime.TryParse(reader["RequiredDate"].ToString(), out date2);
                    bool date3B = DateTime.TryParse(reader["ShippedDate"].ToString(), out date3);
                    Order order = new Order()
                    {
                        CustomerID = ConvertFromDbVal<string>(reader["CustomerID"]),
                        EmployeeID = ConvertFromDbVal<int?>(reader["EmployeeID"]),
                        Freight = ConvertFromDbVal<decimal?>(reader["Freight"]),
                        OrderDate = date1B ? date1 : (DateTime?)null,
                        OrderID = ConvertFromDbVal<int>(reader["OrderID"]),
                        RequiredDate = date2B ? date2 : (DateTime?)null,
                        ShipAddress = ConvertFromDbVal<string>(reader["ShipAddress"]),
                        ShipCity = ConvertFromDbVal<string>(reader["ShipCity"]),
                        ShipCountry = ConvertFromDbVal<string>(reader["ShipCountry"]),
                        ShipName = ConvertFromDbVal<string>(reader["ShipName"]),
                        ShippedDate = date3B ? date3 : (DateTime?)null,
                        ShipPostalCode = ConvertFromDbVal<string>(reader["ShipPostalCode"]),
                        ShipRegion = ConvertFromDbVal<string>(reader["ShipRegion"]),
                        ShipVia = ConvertFromDbVal<int?>(reader["ShipVia"])
                    };
                    orders.Add(order);
                }
            }
            connection.Close();
            return orders;
        }

        public OrderDetails GetOrderDetails(Order order)
        {
            OrderDetails orderDetails = null;
            DbCommand command = this.connection.CreateCommand();
            command.CommandText = String.Format("select od.OrderID, od.ProductID, od.UnitPrice, od.Quantity, od.Discount, p.ProductName from dbo.[Order Details] od inner join dbo.Products p on od.ProductID = p.ProductID where od.OrderID = {0}", order.OrderID);
            connection.Open();

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    orderDetails = new OrderDetails()
                    {
                        Discount = ConvertFromDbVal<Single>(reader["Discount"]),
                        OrderID = ConvertFromDbVal<int>(reader["OrderID"]),
                        ProductID = ConvertFromDbVal<int>(reader["ProductID"]),
                        ProductName = ConvertFromDbVal<string>(reader["ProductName"]),
                        Quantity = ConvertFromDbVal<Int16>(reader["Quantity"]),
                        UnitPrice = ConvertFromDbVal<decimal>(reader["UnitPrice"])
                    };
                }
            }
            connection.Close();
            return orderDetails;
        }

        public void CreateOrder(Order order)
        {
            DbCommand command = this.connection.CreateCommand();
            command.CommandText = String.Format("insert into Orders(CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) values ('{0}', {1}, '{2}', '{3}', '{4}', {5}, {6}, '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')",
                order.CustomerID, order.EmployeeID, order.OrderDate.HasValue ? order.OrderDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.RequiredDate.HasValue ? order.RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.ShippedDate.HasValue ? order.ShippedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.ShipVia, order.Freight, order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion, order.ShipPostalCode, order.ShipCountry);
            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public bool UpdateOrder(Order order)
        {
            if (order.OrderStatus == Order.OrderStatuses.New)
            {
                DbCommand command = this.connection.CreateCommand();
                command.CommandText = String.Format("update Orders set CustomerID='{0}', EmployeeID={1}, RequiredDate='{2}', ShipVia={3}, Freight={4}, ShipName='{5}', ShipAddress='{6}', ShipCity='{7}', ShipRegion='{8}', ShipPostalCode='{9}', ShipCountry='{10}' where OrderID = {11}",
                    order.CustomerID, order.EmployeeID, order.RequiredDate.HasValue ? order.RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.ShipVia, order.Freight, order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion, order.ShipPostalCode, order.ShipCountry, order.OrderID);
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
                return true;
            }
            else
                return false;
        }

        public bool DeleteOrder(Order order)
        {
            if (order.OrderStatus == Order.OrderStatuses.New || order.OrderStatus == Order.OrderStatuses.InProgress)
            {
                DbCommand command = this.connection.CreateCommand();
                command.CommandText = String.Format("delete from Orders where OrderID = {0}", order.OrderID);
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
                return true;
            }
            else
                return false;
        }

        public bool SetInProgress(Order order, DateTime? orderDate)
        {
            if (order.OrderStatus == Order.OrderStatuses.New)
            {
                DbCommand command = this.connection.CreateCommand();
                command.CommandText = String.Format("update Orders set OrderDate='{0}' where OrderID = {1}",
                    orderDate.HasValue ? orderDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.OrderID);
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
                return true;
            }
            else
                return false;
        }

        public void SetComplete(Order order, DateTime? shippedDate)
        {
            DbCommand command = this.connection.CreateCommand();
            command.CommandText = String.Format("update Orders set ShippedDate='{0}' where OrderID = {1}",
                shippedDate.HasValue ? shippedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.OrderID);
            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public IList<CustomerOrderHist> GetCustomerOrdersHistory(string customerId)
        {
            List<CustomerOrderHist> orders = new List<CustomerOrderHist>();
            DbCommand command = this.connection.CreateCommand();
            command.CommandText = "CustOrderHist";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                new SqlParameter()
                {
                    ParameterName = "@CustomerID",
                    Direction = ParameterDirection.Input,
                    Value = customerId
                });

            connection.Open();

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CustomerOrderHist custHist = new CustomerOrderHist()
                    {
                        ProductName = ConvertFromDbVal<string>(reader["ProductName"]),
                        Total = ConvertFromDbVal<int>(reader["Total"])
                    };
                    orders.Add(custHist);
                }
            }

            connection.Close();
            return orders;
        }

        public IList<CustomerOrdersDetail> GetCustomerOrdersDetail(int orderId)
        {
            List<CustomerOrdersDetail> orders = new List<CustomerOrdersDetail>();
            DbCommand command = this.connection.CreateCommand();
            command.CommandText = "CustOrdersDetail";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                new SqlParameter()
                {
                    ParameterName = "@OrderID",
                    Direction = ParameterDirection.Input,
                    Value = orderId
                });

            connection.Open();

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CustomerOrdersDetail custDetails = new CustomerOrdersDetail()
                    {
                        Discount = ConvertFromDbVal<double>(reader["Discount"]),
                        ExtendedPrice = ConvertFromDbVal<double>(reader["ExtendedPrice"]),
                        ProductName = ConvertFromDbVal<string>(reader["ProductName"]),
                        Quantity = ConvertFromDbVal<int>(reader["Quantity"]),
                        UnitPrice = ConvertFromDbVal<decimal>(reader["UnitPrice"])
                    };
                    orders.Add(custDetails);
                }
            }

            connection.Close();
            return orders;
        }

        private void ConfigureConnection(string connectionString, string providerName)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

            this.connection = factory.CreateConnection();
            this.connection.ConnectionString = connectionString;
        }

        private static T ConvertFromDbVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(T);
            else
                return (T)obj;
        }
    }
}
