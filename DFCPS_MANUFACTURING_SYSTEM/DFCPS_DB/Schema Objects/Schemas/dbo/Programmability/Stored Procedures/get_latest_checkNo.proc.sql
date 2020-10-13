CREATE PROCEDURE [dbo].[get_latest_checkNo]
@command int,
@searchValue as VARCHAR(255)
AS
BEGIN
	select lastcheckNoUsed+1 from tblCheckbook
	where checkbookID = @searchvalue
END