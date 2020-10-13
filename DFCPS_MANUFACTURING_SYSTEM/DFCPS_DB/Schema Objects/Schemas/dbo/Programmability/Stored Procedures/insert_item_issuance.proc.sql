CREATE PROCEDURE [dbo].[insert_item_issuance]
@COMMAND AS int,
@issuanceNo as varchar(255),
@refNo as varchar(255),
@transDate as date,
@totalItemCount as int,
@totalCost as decimal(20,2),
@chargeToAccount as varchar(255),
@remarks as varchar(255),
@userID as varchar(255),
@status as varchar(255)
AS
BEGIN
if @command = 0 begin
insert into tblItem_Issuance values(@issuanceNo,@refNo,@transDate,@totalItemCount,@totalCost,@chargeToAccount,@userID,@status,0,CONVERT(VARCHAR,GETDATE(),111))
end
else if @command = 1 begin
update tblItem_Issuance set totalItemCount = @totalItemCount, totalCost=@totalCost,chargeToAccount=@chargeToAccount,USERID=@userid,status = @status, notimesedit = notimesedit + 1 , lastdateedit = CONVERT(VARCHAR,GETDATE(),111)
end
END