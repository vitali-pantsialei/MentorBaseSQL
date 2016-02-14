if not exists (select * from sys.objects
	where OBJECT_ID = OBJECT_ID(N'[dbo].[Regions]'))
begin
	exec sp_rename [Region], [Regions];
end

if not exists (select * from sys.columns
	where OBJECT_ID = OBJECT_ID(N'[dbo].[Customers]') and name = 'FoundationDate')
begin
	alter table dbo.Customers
		add FoundationDate datetime;
end