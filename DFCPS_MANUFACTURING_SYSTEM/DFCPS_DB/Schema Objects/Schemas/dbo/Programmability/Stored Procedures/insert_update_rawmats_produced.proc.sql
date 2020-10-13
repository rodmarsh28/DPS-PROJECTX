CREATE PROCEDURE [dbo].[insert_update_rawmats_produced]
@command int,
@transNo as varchar(255),
@transDate as varchar(255),
@remarks as varchar(255),
@userid as varchar(255),
@status as varchar(255)
AS
BEGIN
if @command = 0 begin
insert into tblRMP values(@transno,@transdate,@remarks,
@userid,@status,0,GETDATE())
end
END