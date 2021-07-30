CREATE PROC uspDeleteCustomer
@customerNumber int
as
begin
begin try
  DELETE Customer where customerNumber = @customerNumber;
end try
begin catch
  select ERROR_MESSAGE() as ErrorMessage;
end catch
end



