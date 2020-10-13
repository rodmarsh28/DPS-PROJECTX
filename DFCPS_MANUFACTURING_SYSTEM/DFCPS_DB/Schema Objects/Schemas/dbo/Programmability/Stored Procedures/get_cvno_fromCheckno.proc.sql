CREATE PROCEDURE [dbo].[get_cvno_fromCheckno]
@command int,
@searchValue varchar(255)
AS
BEGIN
 if @command = 0 begin
SELECT
distinct
tblCheckVOUCHER.checkVoucherNo,CHECKNO
FROM
dbo.tblCheckVoucher
INNER JOIN dbo.tblAccEntry ON dbo.tblCheckVoucher.checkVoucherNo = dbo.tblAccEntry.refno
INNER JOIN dbo.tblCardsProfile ON dbo.tblCheckVoucher.cardID = dbo.tblCardsProfile.cardID
left JOIN dbo.tblCheckTransaction ON dbo.tblCheckVoucher.checkVoucherNo = dbo.tblCheckTransaction.[NO] 
INNER  JOIN tblCheckbook ON tblCheckTransaction.CHECKBOOKID = tblCheckbook.checkbookID
INNER JOIN tblBank on tblCheckbook.bankID = tblBank.bankID
inner join tblCOA on tblAccEntry.accno = tblcoa.accno
where tblCheckVOUCHER.CheckVoucherNo = @searchvalue 
end 
END