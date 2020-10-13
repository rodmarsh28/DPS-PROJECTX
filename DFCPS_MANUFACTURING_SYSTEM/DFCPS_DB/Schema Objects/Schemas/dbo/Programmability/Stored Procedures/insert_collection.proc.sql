CREATE PROCEDURE [dbo].[insert_collection]
@command int,
@collectionNo varchar(255),
@refNo varchar(255)
AS
BEGIN
if @command = 0 begin
insert into tblCollection values (@collectionNo,@refNo)
end
END