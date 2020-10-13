CREATE PROCEDURE [dbo].[GET_CHECK_VOUCHER_FORPRINT]
@COMMAND AS INT,
@SEARCHVALUE AS VARCHAR(255)
AS
begin
if @command = 0 begin /*FOR CHECKVOUCHER ISSUANCE*/
SELECT
tblCheckVOUCHER.checkVoucherNo,date_transaction,TblCheckVOUCHER.refno,TblCheckVOUCHER.type,TblCheckVOUCHER.tinNo,TblCheckVOUCHER.cardID,cardName,cardAddress,bankDesc,CHECKNO,totalAmount,remarks,tblPendingAccEntry.memo,tblPendingAccEntry.accno,tblcoa.accountName,tblPendingAccEntry.debit,tblPendingAccEntry.credit
FROM
dbo.tblCheckVoucher
INNER JOIN dbo.tblPendingAccEntry ON dbo.tblCheckVoucher.checkVoucherNo = dbo.tblPendingAccEntry.refno
INNER JOIN dbo.tblCardsProfile ON dbo.tblCheckVoucher.cardID = dbo.tblCardsProfile.cardID
LEFT JOIN dbo.tblCheckTransaction ON dbo.tblCheckVoucher.checkVoucherNo = dbo.tblCheckTransaction.[NO]
LEFT  JOIN tblCheckbook ON tblCheckTransaction.CHECKBOOKID = tblCheckbook.checkbookID
LEFT JOIN tblBank on tblCheckbook.bankID = tblBank.bankID
inner join tblCOA on tblPendingAccEntry.accno = tblcoa.accno
where tblCheckVOUCHER.CheckVoucherNo = @searchvalue
end
ELSE if @command = 1 begin /*FOR CHECKVOUCHER ISSUANCE WITH PREPARED CHECK*/
SELECT
tblCheckVOUCHER.checkVoucherNo,date_transaction,TblCheckVOUCHER.refno,TblCheckVOUCHER.type,TblCheckVOUCHER.tinNo,TblCheckVOUCHER.cardID,cardName,cardAddress,bankDesc,CHECKNO,totalAmount,remarks,tblAccEntry.memo,tblCOA.accNo,tblCOA.accountName,tblAccEntry.debit,tblAccEntry.credit
FROM
dbo.tblCheckVoucher
INNER JOIN dbo.tblAccEntry ON dbo.tblCheckVoucher.checkVoucherNo = dbo.tblAccEntry.refno
INNER JOIN dbo.tblCardsProfile ON dbo.tblCheckVoucher.cardID = dbo.tblCardsProfile.cardID
left JOIN dbo.tblCheckTransaction ON dbo.tblCheckVoucher.checkVoucherNo = dbo.tblCheckTransaction.[NO] and tblCheckTransaction.status <> 'Cancelled'
INNER  JOIN tblCheckbook ON tblCheckTransaction.CHECKBOOKID = tblCheckbook.checkbookID
INNER JOIN tblBank on tblCheckbook.bankID = tblBank.bankID
inner join tblCOA on tblAccEntry.accno = tblcoa.accno
where tblCheckVOUCHER.CheckVoucherNo = @searchvalue
end
else if @command = 2 begin
SELECT
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
else if @command = 3 begin
SELECT
tblCheckVOUCHER.checkVoucherNo,date_transaction,TblCheckVOUCHER.refno,TblCheckVOUCHER.type,TblCheckVOUCHER.tinNo,TblCheckVOUCHER.cardID,cardName,cardAddress,bankDesc,CHECKNO,totalAmount,remarks,tblAccEntry.memo,tblCOA.accno,tblcoa.accountName,tblAccEntry.debit,tblAccEntry.credit
FROM
dbo.tblCheckVoucher
INNER JOIN dbo.tblAccEntry ON dbo.tblCheckVoucher.checkVoucherNo = dbo.tblAccEntry.refno
INNER JOIN dbo.tblCardsProfile ON dbo.tblCheckVoucher.cardID = dbo.tblCardsProfile.cardID
LEFT JOIN dbo.tblCheckTransaction ON dbo.tblCheckVoucher.checkVoucherNo = dbo.tblCheckTransaction.[NO]
LEFT  JOIN tblCheckbook ON tblCheckTransaction.CHECKBOOKID = tblCheckbook.checkbookID
LEFT JOIN tblBank on tblCheckbook.bankID = tblBank.bankID
inner join tblCOA on tblAccEntry.accno = tblcoa.accno
where tblCheckVOUCHER.CheckVoucherNo = @searchvalue
end 
END