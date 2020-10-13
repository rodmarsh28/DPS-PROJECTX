CREATE PROCEDURE [dbo].[get_card_info]
@searchValue as varchar(255)
AS
BEGIN
select * from tblCardsProfile where cardID = @searchValue
END