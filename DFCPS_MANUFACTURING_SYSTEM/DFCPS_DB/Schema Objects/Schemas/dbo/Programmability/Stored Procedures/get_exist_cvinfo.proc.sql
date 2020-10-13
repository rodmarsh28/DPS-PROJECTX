CREATE PROCEDURE [dbo].[get_exist_cvinfo]
@searchValue as varchar(255)
AS
BEGIN
select checkVoucherNo,accNo,debit from tblCheckvoucher
inner join tblAccEntry on tblAccEntry.refno = tblCheckVoucher.checkVoucherNo
where tblCheckVoucher.refno = @searchValue and tblAccEntry.credit = 0
END