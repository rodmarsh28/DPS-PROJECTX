CREATE PROCEDURE [dbo].[insert_update_payables]
@command as varchar(255),
@refNo as varchar(255),
@src as varchar(255),
@payment as varchar(255),
@dueDate as datetime2,
@amount as decimal(20,2),
@status as varchar(255)
AS
BEGIN
if @command = 0 begin
insert into tblPayable values(@refno,@src,@payment,@duedate,@amount,@status)
end 
else if @command = 1 begin
update tblPayable set src = @src,payment = @payment,duedate = @duedate,amount = @amount,status = @status
end
END