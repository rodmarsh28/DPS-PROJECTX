CREATE PROCEDURE [dbo].[insert_update_sales]
@processCount int,
@salesMode varchar(255),
@salesno varchar(255),
@refNo varchar(255),
@cardID varchar(255),
@totFAmnt decimal(20,2),
@totDis decimal(20,2),
@totalAmount decimal(20,2),
@userid varchar(255),
@status varchar(255),

@itemNo varchar(255),
@qty int,
@uprice decimal(20,2),
@amount decimal(20,2),
@discount decimal(20,2),
@pcQTY decimal(20,2),
@cost decimal(20,2)

AS
BEGIN

if  @salesMode = 'QUOTATION' and @processCount = '0' BEGIN
INSERT INTO tblSalesQuotation values(@salesno,GETDATE(),@cardID,@totalAmount,@userid,@status,0,GETDATE())
end
else IF @salesMode = 'SALES ORDER' and @processCount = '0' BEGIN 
INSERT INTO tblSalesOrder values(@salesno,GETDATE(),@refNo,@cardID,@totalAmount,@userid,@status,0,GETDATE())
END
else IF @salesMode = 'SALES CASH INVOICE' and @processCount = '0' BEGIN
INSERT INTO tblSalesCashInvoice values(@salesno,GETDATE(),@refNo,@cardID,@totFAmnt,@totDis,@totalAmount,@userid,@status,0,GETDATE())
END
else IF @salesMode = 'SALES CHARGE INVOICE' and @processCount = '0' BEGIN
INSERT INTO tblSalesChargeInvoice values(@salesno,GETDATE(),@refNo,@cardID,@totFAmnt,@totDis,@totalAmount,@userid,@status,0,GETDATE())
END
else IF @salesMode = 'SALES DELIVER' and @processCount = '0' BEGIN
INSERT INTO tblSalesDeliver values(@salesno,GETDATE(),@refNo,@cardID,@totalAmount,@userid,@status,0,GETDATE())
END

INSERT INTO tblSalesItemsTR values(@salesno,@itemNo,@qty,@uprice,@discount,@amount,@cost,@pcQTY)

end