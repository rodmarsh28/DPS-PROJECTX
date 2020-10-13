CREATE PROCEDURE [dbo].[insert_update_checkVoucher]
@command as int,
@transNo as varchar(255),
@refno as varchar(255),
@transdate as datetime2,
@type as varchar(255),
@tinNo as varchar(255),
@payee as varchar(255),
@address as varchar(255),
@totalAmount as decimal(20,2),
@amountInwords as varchar(255),
@remarks as varchar(255),
@userid as varchar(255),
@status as varchar(255)

AS
BEGIN
if @command = 0 begin
insert into tblCheckVoucher values(@transno,@refno,@transdate,@type,@tinNo,@payee,@address,@totalAmount,@amountinWords,@remarks,@userid,@status,0,GETDATE())
end
else if @command = 1 begin
update tblCheckVoucher set date_transaction = @transdate,type = @type,tinNo = @tinNo,CARDID = @payee,address = @address,totalAmount = @totalAmount,amountInwords = @amountInWords,remarks = @remarks,userId = @userid,status = @status,notimesedit += 1,lastdateedit = getdate()
where checkVoucherNo = @transNo
end
END