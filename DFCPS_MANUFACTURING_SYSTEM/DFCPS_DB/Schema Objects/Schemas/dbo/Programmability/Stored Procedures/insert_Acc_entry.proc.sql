CREATE PROCEDURE [dbo].[insert_Acc_entry]
@refno varchar(255),
@src varchar(255),
@accNo varchar(255),
@memo varchar(255),
@debit decimal(20,2),
@credit decimal(20,2),
@userID varchar(255),
@job varchar(255),
@cardID varchar(255)
AS
BEGIN
insert into tblAccEntry values(getdate(),@refno,@src,@accNo,@memo,@debit,@credit,
@userID,@job,@cardID)
END