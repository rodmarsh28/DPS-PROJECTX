CREATE PROCEDURE [dbo].[insert_update_voucher]
@command as int,
@No as varchar(255),
@ref as varchar(255),
@cardID as varchar(255),
@amount as DECIMAL(20,2),
@remarks as varchar(255),
@userid as varchar(255),
@status as varchar(255)

AS
BEGIN
if @command = 0 begin
insert into tblVoucher values(@No,getdate(),@ref,@cardID,@amount,@remarks,@userid,@status,0,GETDATE())
end
else if @command = 1 begin
update tblVoucher set VoucherNo = @No,ref = @ref,cardid = @cardID,amount = @amount,remarks = @remarks,userId = @userid,status = @status,notimesedit += 1,lastdateedit = getdate()
where VoucherNo = @No
end
END