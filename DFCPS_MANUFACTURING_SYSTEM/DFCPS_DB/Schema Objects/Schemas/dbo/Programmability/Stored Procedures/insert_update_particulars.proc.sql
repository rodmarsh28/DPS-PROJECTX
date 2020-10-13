CREATE PROCEDURE [dbo].[insert_update_particulars]
@command as int,
@transNo as varchar(255),
@particulars as varchar(255),
@amountValue as decimal(20,2),
@appliedValue as decimal(20,2),
@voucherNo as varchar(255),
@count as int
AS
BEGIN
if @command = 0
insert into tblCVParticulars values(@transNo,@particulars,@amountValue,@appliedValue,@voucherNo)
else if @command = 1
if @count = 0 begin
delete tblCVParticulars where CheckVoucherNo = @transNo
end
insert into tblCVParticulars values(@transNo,@particulars,@amountValue,@appliedValue,@voucherNo)
END