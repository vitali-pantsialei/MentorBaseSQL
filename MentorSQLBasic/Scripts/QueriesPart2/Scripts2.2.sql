select year(OrderDate) as Year, count(*) as Total from dbo.Orders
	group by year(OrderDate);

select count(*) as Totals from dbo.Orders;

/*----------------------------------*/

select (e.LastName + ' & ' + e.FirstName) as Seller, count(o.EmployeeID) as Amount from dbo.Orders o
	inner join dbo.Employees e
	on o.EmployeeID = e.EmployeeID
	where o.EmployeeID is not null
	group by o.EmployeeID, e.LastName, e.FirstName
	order by count(o.EmployeeID) desc;

select o.EmployeeID, o.CustomerID, count(*) from dbo.Orders o
	where year(o.OrderDate) = 1998
	group by o.EmployeeID, o.CustomerID;

select e.FirstName, c.ContactName, e.City from dbo.Employees e, dbo.Customers c
	where e.City = c.City;
	
select count(c.CustomerID) as [Customer Count], c.City from dbo.Customers c
	group by c.City;

select e.FirstName as Employee, (select distinct e1.FirstName from Employees e1 where e1.EmployeeID = e.ReportsTo) as [Reports To] from Employees e;