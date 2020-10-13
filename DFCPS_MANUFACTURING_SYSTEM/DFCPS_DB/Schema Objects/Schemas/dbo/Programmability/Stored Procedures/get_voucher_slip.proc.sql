CREATE PROCEDURE [dbo].[get_voucher_slip]
@transNo as varchar(255)
AS
BEGIN
SELECT
dbo.tblVoucher.VoucherNo,
dbo.tblVoucher.[date],
dbo.tblVoucher.cardID,
dbo.tblCardsProfile.cardname,
dbo.tblVoucher.remarks,
dbo.tblAccEntry.accNo,
dbo.tblCOA.accountName,
dbo.tblAccEntry.debit,
dbo.tblAccEntry.credit,
ISNULL(dbo.tblUsers.name, '')

FROM
dbo.tblAccEntry
INNER JOIN dbo.tblVoucher ON dbo.tblVoucher.VoucherNo = dbo.tblAccEntry.refNo
INNER JOIN dbo.tblCOA ON dbo.tblAccEntry.accNo = dbo.tblCOA.accNo AND dbo.tblCOA.accNo = dbo.tblAccEntry.accNo
left JOIN dbo.tblUsers ON dbo.tblVoucher.userid = dbo.tblUsers.userID
inner join dbo.tblCardsProfile on tblvoucher.cardid = tblCardsProfile.cardid

where dbo.tblVoucher.VoucherNo = @transNo
ORDER BY DEBIT DESC
END