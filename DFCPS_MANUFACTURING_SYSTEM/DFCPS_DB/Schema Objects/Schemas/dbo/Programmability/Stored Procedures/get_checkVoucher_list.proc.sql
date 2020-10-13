CREATE PROCEDURE [dbo].[get_checkVoucher_list]
@command as int,
@searchValue as varchar(255)
AS
BEGIN
if @command = 0 begin
select convert(varchar,date_transaction,111) AS Date,checkVoucherNo as No,CARDID as Card_ID,totalAmount as Total_Amount,status as Status from tblCheckVoucher
where convert(varchar,date_transaction,111) like '%' + @searchValue + '%' or  checkvoucherNo like '%' + @searchValue + '%'
end
else if @command = 1 begin
select tblCheckVoucher.checkVoucherNo,tblCheckVoucher.refNo,tblCheckVoucher.type,tblCheckVoucher.tinNo,tblCheckVoucher.cardid,tblCardsProfile.cardName,tblCardsProfile.cardAddress,tblCheckVoucher.remarks,tblCheckVoucher.totalAmount,tblCVParticulars.voucherNo,tblCVParticulars.PARTICULARS,tblCVParticulars.AMOUNTVALUE,tblCVParticulars.APPLIEDVALUE,tblPendingAccEntry.accno,tblCheckVoucher.amountInwords 
from tblCheckVoucher 
inner join tblCVParticulars on tblCheckVoucher.checkVoucherNo = tblCVParticulars.checkVoucherNo 
inner join tblCardsProfile on tblCheckVoucher.cardID = tblCardsProfile.cardID 
inner join tblPendingAccEntry on tblCheckVoucher.checkVoucherNo = tblPendingAccEntry.refno where tblCheckVoucher.checkVoucherNo = @searchValue
end
else if @command = 2 begin
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
where CHECKNO =@searchvalue 
end 
END