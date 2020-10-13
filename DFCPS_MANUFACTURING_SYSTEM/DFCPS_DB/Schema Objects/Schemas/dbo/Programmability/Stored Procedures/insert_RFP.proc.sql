CREATE PROCEDURE [dbo].[insert_RFP]
@command as int,
@TRANSNO AS VARCHAR(255),
@SRC AS VARCHAR(255),
@AMOUNT AS DECIMAL(20,2),
@USERID AS VARCHAR(255),
@status AS VARCHAR(255)
AS
BEGIN
if @command = 0 begin 
INSERT INTO TBLRFP VALUES(@TRANSNO,@SRC,CONVERT(VARCHAR,GETDATE(),111),@AMOUNT,@USERID,@status)
end 
else if @command = 1 begin
update tblRFP set amount = @amount, userid = @userid,
status = @status where [NO] = @TRANSNO
end
else if @command = 2 begin
update tblRFP set status = @status where [NO] = @TRANSNO
end
END