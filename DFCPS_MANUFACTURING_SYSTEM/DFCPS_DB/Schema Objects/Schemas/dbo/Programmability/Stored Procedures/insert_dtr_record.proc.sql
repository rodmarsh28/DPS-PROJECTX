CREATE PROCEDURE [dbo].[insert_dtr_record]
@command INT,
@transNo varchar(255),
@transDate datetime2,
@empid varchar(255),
@wH decimal(20,2),
@aH decimal(20,2),
@rhC decimal(20,2),
@nwhC decimal(20,2),
@rhH decimal(20,2),
@nwhH decimal(20,2),
@otH decimal(20,2),
@otnH decimal(20,2),
@rdrH decimal(20,2),
@lateMins decimal(20,2),
@remarks varchar(255),
@userid varchar(255)
AS
BEGIN
	insert into tblDTRrecord values(@transNo,@transDate,@empid,@wH,@aH,@rhC,@nwhC,@rhH,@nwhH,@otH,@otnH,@rdrH,@lateMins,@remarks,@userid)
END