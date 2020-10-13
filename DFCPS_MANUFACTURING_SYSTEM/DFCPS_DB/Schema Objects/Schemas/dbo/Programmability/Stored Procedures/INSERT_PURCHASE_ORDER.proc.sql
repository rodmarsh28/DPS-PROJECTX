CREATE PROCEDURE [dbo].[INSERT_PURCHASE_ORDER]
@COMMAND int,
@TRANSNO varchar(255),
@refNo varchar(255),
@CARDID decimal(20,2),
@ITEMNO decimal(20,2),
@QTY decimal(20,2),
@UPRICE varchar(255),
@AMOUNT varchar(255),
@TAX varchar(255),
@userid varchar(255),
@status varchar(255)
AS
BEGIN
if  @COMMAND = 0 begin
INSERT INTO tblPurchaseOrder values(@TRANSNO,GETDATE(),@refNo,@cardID,@userid,@ITEMNO,@QTY,@UPRICE,@AMOUNT,@TAX,@status,0,GETDATE())
end
END