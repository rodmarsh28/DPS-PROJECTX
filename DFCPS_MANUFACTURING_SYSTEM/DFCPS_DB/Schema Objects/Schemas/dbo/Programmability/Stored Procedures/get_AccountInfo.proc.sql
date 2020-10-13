CREATE PROCEDURE [dbo].[get_AccountInfo]
@searchValue VARCHAR(255)
AS
BEGIN select * from viewAllAcounts where accNo = @searchValue
END