CREATE proc uspUpdateMenu
@itemId varchar(50),
@itemName varchar(50),
@itemDescription varchar(50),
@itemTax int,
@itemPrice int,
@itemDiscount int
as
begin
begin try
  update MENU SET itemName=@itemName, itemDescription=@itemDescription, itemTax=@itemTax, itemPrice=@itemPrice, itemDiscount=@itemDiscount WHERE itemId=@itemId;
end try
begin catch
  select ERROR_MESSAGE() as ErrorMessage;
end catch
end

