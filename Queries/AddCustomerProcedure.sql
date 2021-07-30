CREATE PROC uspAddCustomer
@customerName varchar(50),
@customerNumber int,
@customerAddress varchar(100),
@customerVisitCount int
as
begin
begin try
  insert into Customer VALUES(@customerName,@customerNumber,@customerAddress,@customerVisitCount);
end try
begin catch
  select ERROR_MESSAGE() as ErrorMessage;
end catch
end



