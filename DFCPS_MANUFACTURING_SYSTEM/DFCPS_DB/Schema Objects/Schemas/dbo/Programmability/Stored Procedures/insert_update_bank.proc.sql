CREATE PROCEDURE [dbo].[insert_update_bank]
@command as int,
@bankID as varchar(255),
@bankDesc as varchar(255),
@accountName as varchar(255),
@accNo as varchar(255),
@status as varchar(255)
AS
BEGIN
if @command = 0 begin
insert into tblBank values (@bankID,@bankDesc,@accountName,@accNo,@status,0,GETDATE())
end
else if @command = 1 begin
update tblBank set bankDesc = @bankDesc, AccountName = @accountName, accNo = @accNo, status = @status, notimesedit += 1, lastdateedit = GETDATE()
where bankID = @bankID
end
END