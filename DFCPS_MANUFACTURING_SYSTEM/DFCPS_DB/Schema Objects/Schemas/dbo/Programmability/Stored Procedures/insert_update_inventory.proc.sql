CREATE PROCEDURE [dbo].[insert_update_inventory]
@pcQTY as DECIMAL(20,2),
@REF as varchar(255),
@command as varchar(255),
@itemNo as varchar(255),
@itemdesc as varchar(255),
@unitCost as decimal(20,2),
@unit as varchar(255),
@unitprice as decimal(20,2),
@buy as varchar(255),
@sell as varchar(255),
@inv as varchar(255),
@accCost as varchar(255),
@accIncome as varchar(255),
@accAsset as varchar(255),
@minStock as decimal(20,1),
@status as varchar(255),
@balanceQty as decimal(20,1),
@src as VARCHAR(255)
AS
BEGIN
if @command = 'Add' begin
insert into tblInvtry values(@itemNo ,
@itemdesc,
@buy,
@sell,
@inv,
@accCost,
@accIncome,
@accAsset,
@status)
insert into tblItemTransaction values(GETDATE(),@REF,
@src,
@itemNo ,
@unitCost,
@balanceqty,'',@pcQTY)
insert into tblSales_price values(
@itemNo ,
@unitprice,
GETDATE(),@REF)
insert into tblItem_units values(
@itemNo ,
@unit,
@minStock)
end
else if @command = 'Update' begin
update  tblInvtry set ITEMDESC = @itemdesc,
BUYABLE = @buy,
SELLABLE = @sell,
INVENTORABLE = @inv,
COSTOFSALESACC = @accCost,
INCOMEACC = @accIncome,
ASSETACC = @accAsset,
STATUS = @status
where  ITEMNO = @itemno

insert into tblItemTransaction values(GETDATE(),@REF,
@src,
@itemNo ,
@unitCost,
@balanceqty,'',@pcQTY)

insert into tblSales_price values(
@itemNo ,
@unitprice,
GETDATE(),@REF)
update  tblItem_units set 
unit_desc = @unit,
minQTY = @minStock
where  ITEMCODE = @itemNo 
end
END