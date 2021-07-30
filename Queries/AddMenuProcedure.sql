CREATE proc uspAddMenu
@itemId varchar(50),
@itemName varchar(50),
@itemDescription varchar(50),
@itemTax int,
@itemPrice int,
@itemDiscount int
as
begin
begin try
  insert into MENU VALUES(@itemId,@itemName,@itemDescription,@itemTax,@itemPrice,@itemDiscount);
end try
begin catch
  select ERROR_MESSAGE() as ErrorMessage;
end catch
end