CREATE PROCEDURE [dbo].[insert_update_cashRequistion]
@command as int,
@transNo as varchar(255),
@cardID as varchar(255),
@particulars as varchar(255),
@amount as decimal(20,2),
@amountApplied as decimal(20,2),
@remarks as varchar(255),
@totalAmount as decimal(20,2),
@totalamountApplied as decimal(20,2),
@userid as varchar(255),
@status as varchar(255),
@notimesedit as int,
@count as int

AS
BEGIN
if @command = 0 begin
insert into tblCashRequisition values(@transno,GETDATE(),@cardID,@particulars,@amount,@amountApplied,@remarks,@totalAmount,@totalAmountApplied,@userid,@status,0,GETDATE())
end
else if @command = 1 begin
update tblCashRequisition set cardID = @cardID,particulars = @particulars,amount = @amount,amountApplied = @amountApplied,remarks = @remarks,totalAmount = @totalAmount,totalAmountApplied = @totalAmountApplied,userId = @userid,status = @status,notimesedit += 1,lastdateedit = getdate()
where CRSNO = @transNo
end
else if @command = 2 begin
if @count = 0 begin
delete tblCashRequisition where CRSNO = @transno
end
insert into tblCashRequisition values(@transno,GETDATE(),@cardID,@particulars,@amount,@amountApplied,@remarks,@totalAmount,@totalAmountApplied,@userid,@status,@notimesedit,GETDATE())
end
END