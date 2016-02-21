select sum(UnitPrice*Quantity*(1-Discount)) as Totals from dbo.[Order Details];

select count(ShippedDate) from dbo.Orders;

select count(p.CustomerID) from 
	(select distinct CustomerID from dbo.Orders) as p;