CREATE PROCEDURE [dbo].[get_checkIssued_list]
@command int,
@searchValue varchar(255)
AS
BEGIN
select convert(varchar, transdate,101) as Transaction_Date,cardName as Payee,bankDesc as Bank,checkNo as Check_No,convert(varchar,CHECKDATE,101) as Check_Date,amount as Check_Amount,tblCheckTransaction.STATUS as Status from tblCheckTransaction
inner join tblCheckbook on tblCheckTransaction.checkbookID = tblCheckbook.checkbookID
INNER join tblbank on tblCheckbook.bankID = tblBank.bankID
inner join tblCardsProfile on tblCheckTransaction.cardid = tblCardsProfile.CARDID
where cardname like '%' + @searchValue + '%' or bankDesc like '%' + @searchValue + '%' or checkNo like '%' + @searchValue + '%'
END