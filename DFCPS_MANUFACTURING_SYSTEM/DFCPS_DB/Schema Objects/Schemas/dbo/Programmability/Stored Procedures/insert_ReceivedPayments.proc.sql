CREATE PROCEDURE [dbo].[insert_ReceivedPayments]
@paymentNo varchar(255),
@paymethod varchar(255),
@cardID varchar(255),
@userid varchar(255),
@checkno varchar(255),
@checkdate date,
@amountReceived decimal(20,2),
@invoiceNo varchar(255),
@amountDiscount decimal(20,2),
@amountApplied decimal(20,2),
@outOFBalance decimal(20,2),
@overAllBalance decimal(20,2),
@depositToAccount VARCHAR(255)
AS
BEGIN
INSERT INTO tblPaymentsReceived values(@paymentNo,GETDATE(),@cardID,@paymethod,@amountReceived,@outOFBalance,
@overAllBalance,@invoiceNo,@amountDiscount,@amountApplied,@depositToAccount,@userid)

if @paymethod = 'Check' BEGIN
INSERT INTO tblCheckReceivedTransaction values(@paymentNo,getdate(),@checkno,@cardID,@amountReceived,@checkdate,'Undeposited Check',@userid)
end
end