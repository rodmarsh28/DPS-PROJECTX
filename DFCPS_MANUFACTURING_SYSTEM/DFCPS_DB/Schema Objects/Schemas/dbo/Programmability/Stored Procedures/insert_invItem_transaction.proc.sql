CREATE PROCEDURE [dbo].[insert_invItem_transaction]
@itemNo varchar(255),
@refNo varchar(255),
@src varchar(255),
@unitCost decimal(20,2),
@qty decimal(20,1),
@job varchar(255),
@pcQty decimal(20,2)
AS
BEGIN
insert into tblItemTransaction values(getdate(),@refNo ,
@src,
@itemNo,
@unitCost,
@qty,
@job,
@pcQty)
END