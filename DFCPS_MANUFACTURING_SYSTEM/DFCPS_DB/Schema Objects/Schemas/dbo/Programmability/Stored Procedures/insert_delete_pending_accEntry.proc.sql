CREATE PROCEDURE [dbo].[insert_delete_pending_accEntry]
@command as varchar(255),
@transNo as varchar(255),
@accno as varchar(255),
@memo as varchar(255),
@debit as decimal(20,2),
@credit as decimal(20,2),
@status as varchar(255),
@count as int
AS
BEGIN
if @command = 0 begin
insert into tblPendingAccEntry values(@transNo,@accno,@memo,@debit,@credit,@status)
end
else if @command = 1 begin
if @count = 0 begin
delete tblPendingAccEntry where refno = @transNo
end
insert into tblPendingAccEntry values(@transNo,@accno,@memo,@debit,@credit,@status)
end
END