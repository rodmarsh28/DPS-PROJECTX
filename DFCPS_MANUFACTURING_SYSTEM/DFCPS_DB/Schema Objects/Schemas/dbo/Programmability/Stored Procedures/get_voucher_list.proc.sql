CREATE PROCEDURE [dbo].[get_voucher_list]
@status as varchar(255),
@searchValue as varchar(255)
AS
BEGIN
if @status = 'All' BEGIN
SELECT DISTINCT
convert(varchar,dbo.tblVoucher.[date],111) AS [Date],
dbo.tblVoucher.VoucherNo,
dbo.tblVoucher.cardID,
dbo.tblCardsProfile.cardName,
CONVERT(varchar, CAST(tblVoucher.AMOUNT AS money), 1) AS Amount,
dbo.tblVoucher.status
FROM
dbo.tblVoucher
INNER JOIN dbo.tblCardsProfile ON dbo.tblCardsProfile.cardID = dbo.tblVoucher.cardID
where [Date] like '%' + @searchValue + '%' or VoucherNo like '%' + @searchValue + '%' or tblVoucher.cardID like '%' + @searchValue + '%' or cardName like '%' + @searchValue + '%'
end 
else if @status = 'Open' begin
SELECT DISTINCT
convert(varchar,dbo.tblVoucher.[date],111) AS [Date],
dbo.tblVoucher.VoucherNo,
dbo.tblVoucher.cardID,
dbo.tblCardsProfile.cardName,
CONVERT(varchar, CAST(tblVoucher.AMOUNT AS money), 1) as Amount,
dbo.tblVoucher.status
FROM
dbo.tblVoucher
INNER JOIN dbo.tblCardsProfile ON dbo.tblCardsProfile.cardID = dbo.tblVoucher.cardID
where [Date] like '%' + @searchValue + '%' and status = 'Open' or VoucherNo like '%' + @searchValue + '%' and status = 'Open' or tblVoucher.cardID like '%' + @searchValue + '%' and status = 'Open' or cardName like '%' + @searchValue + '%' and status = 'Open'
end
END