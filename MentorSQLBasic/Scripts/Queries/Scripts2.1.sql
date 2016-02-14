select OrderId, ShippedDate, ShipVia from Orders
	where ShippedDate >= CONVERT(datetime, '06.05.1998', 104) and ShipVia >= 2;

select OrderID, 
	case
		when ShippedDate is null then 'Not shipped'
	end as [Shipped Date]
	from Orders
	where ShippedDate is null;

select OrderID as [Order Number],
	case
		when ShippedDate is null then 'Not Shipped'
		else CONVERT(varchar(25), ShippedDate)
	end as [Shipped Date]
	from Orders
	where (ShippedDate is null) or (ShippedDate >= CONVERT(datetime, '06.05.1998', 104));