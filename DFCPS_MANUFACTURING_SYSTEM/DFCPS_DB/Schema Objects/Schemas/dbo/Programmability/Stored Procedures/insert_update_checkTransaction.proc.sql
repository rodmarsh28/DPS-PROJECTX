CREATE PROCEDURE [dbo].[insert_update_checkTransaction]
@command as int,
@transNo as varchar(255),
@checkbookID as varchar(255),
@cardID as varchar(255),
@checkNo as varchar(255),
@amount as varchar(255),
@CHECKDATE as DATETIME2,
@status as varchar(255),
@USERID AS VARCHAR(255)

AS
BEGIN
if @command = 0 begin
insert into tblCheckTransaction values(@transno,getdate(),@checkbookID,@checkNo,@cardID,@Amount,@CHECKDATE,@status,@userID)
update tblCheckbook set lastCheckNoUsed = @checkNo where checkbookID = @checkbookID
end
else if @command = 1 begin
update tblCheckTransaction set checkNo = @checkno, cardID = @cardID, amount = @amount,checkdate = @CHECKDATE, status = @status,userid = @userid
where [NO] = @transNo
end
END