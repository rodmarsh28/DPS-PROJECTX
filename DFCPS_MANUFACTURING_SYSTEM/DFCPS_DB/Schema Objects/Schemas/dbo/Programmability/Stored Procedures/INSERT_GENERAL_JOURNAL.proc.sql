CREATE PROCEDURE [dbo].[INSERT_GENERAL_JOURNAL]
@command int,
@GJNO varchar(255),
@dateTrans datetime2,
@userid varchar(255),
@status varchar(255)
AS
BEGIN
insert into tblGeneralJournal values(@GJNO,@DATETRANS,@userid,@status,0,GETDATE())
END