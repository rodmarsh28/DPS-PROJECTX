CREATE PROCEDURE [dbo].[insert_update_checkbook]
@command as int,
@checkbookID as varchar(255),
@bankID as varchar(255),
@startCheckNo as int,
@endCheckNo as int,
@lastCheckNo as int,
@status as varchar(255)
AS
BEGIN
if @command = 0 begin
insert into tblCheckbook values (@checkbookID,@bankID,@startCheckNo,@endCheckNo,@lastCheckNo,GETDATE(),@status,0,GETDATE())
end
else if @command = 1 begin
update tblCheckbook set bankID = @bankID, startCheckNo = @startCheckNo, endCheckNo = @endCheckNo, status = @status, notimesedit += 1, lastdateedit = GETDATE()
where checkbookID = @checkbookID
end
END