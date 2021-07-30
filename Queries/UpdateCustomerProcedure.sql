CREATE PROC uspUpdateCustomer
@customerName varchar(50),
@customerNumber int,
@customerAddress varchar(100),
@customerVisitCount int
as
begin
begin try
  update Customer SET customerName=@customerName, customerNumber=@customerNumber, customerAddress=@customerAddress, customerVisitCount=@customerVisitCount where customerNumber=@customerNumber
end try
begin catch
  select ERROR_MESSAGE() as ErrorMessage;
end catch
end



