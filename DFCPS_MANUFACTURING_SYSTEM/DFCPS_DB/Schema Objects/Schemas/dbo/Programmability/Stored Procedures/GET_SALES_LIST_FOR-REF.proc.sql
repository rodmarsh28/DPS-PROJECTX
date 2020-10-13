CREATE PROCEDURE [dbo].[GET_SALES_LIST_FOR-REF]
@command as varchar(255),
@cardid as varchar(255),
@searchValue as varchar(255)
AS
BEGIN
IF  @command = 'QUOTATION' BEGIN
SELECT
CONVERT(VARCHAR,dbo.tblSalesQuotation.transDate,101) as DATE,
dbo.tblSalesQuotation.quoteNo as No,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesQuotation.totalAmount Total_Amount
FROM
dbo.tblSalesQuotation
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesQuotation.cardID = dbo.tblCardsProfile.cardID
WHERE quoteNo LIKE '%' + @searchValue + '%' and status = '' and tblSalesQuotation.cardID like '%'+@cardid+'%'
END
ELSE if @command = 'SALES ORDER' BEGIN
SELECT
CONVERT(VARCHAR,dbo.tblSalesOrder.transDate,101) as DATE,
dbo.tblSalesOrder.salesOrderNo as No,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesOrder.totalAmount Total_Amount
FROM
dbo.tblSalesOrder
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesOrder.cardID = dbo.tblCardsProfile.cardID
WHERE salesOrderNo LIKE '%' + @searchValue + '%' and status = '' and tblSalesOrder.cardID like '%'+@cardid+'%'
END
ELSE if @command = 'SALES CASH INVOICE' BEGIN
SELECT
CONVERT(VARCHAR,dbo.tblSalesCashInvoice.transDate,101) as DATE,
dbo.tblSalesCashInvoice.salesCashInvoiceNo as No,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesCashInvoice.totalAmount Total_Amount
FROM
dbo.tblSalesCashInvoice
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesCashInvoice.cardID = dbo.tblCardsProfile.cardID
WHERE salesCashInvoiceNo LIKE '%' + @searchValue + '%' and status = '' and tblSalesCashInvoice.cardID like '%'+@cardid+'%'
END
ELSE if @command = 'SALES CHARGE INVOICE' BEGIN
SELECT
CONVERT(VARCHAR,dbo.tblSalesChargeInvoice.transDate,101) as DATE,
dbo.tblSalesChargeInvoice.salesChargeInvoiceNo as No,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesChargeInvoice.totalAmount Total_Amount
FROM
dbo.tblSalesChargeInvoice
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesChargeInvoice.cardID = dbo.tblCardsProfile.cardID
WHERE salesChargeInvoiceNo LIKE '%' + @searchValue + '%' and status = '' and tblSalesChargeInvoice.cardID like '%'+@cardid+'%'
END
ELSE if @command = 'SALES DELIVER' BEGIN
SELECT
CONVERT(VARCHAR,dbo.tblSalesDeliver.transDate,101) as DATE,
dbo.tblSalesDeliver.salesDeliverNo as No,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesDeliver.totalAmount Total_Amount
FROM
dbo.tblSalesDeliver
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesDeliver.cardID = dbo.tblCardsProfile.cardID
WHERE salesDeliverNo LIKE '%' + @searchValue + '%' and status = '' and tblSalesDeliver.cardID like '%'+@cardid+'%'
END
ELSE if @command = 'SALES INVOICE' BEGIN
select * from(
SELECT
CONVERT(VARCHAR,dbo.tblSalesCashInvoice.transDate,101) as DATE,
dbo.tblSalesCashInvoice.salesCashInvoiceNo as No,
dbo.tblSalesCashInvoice.CARDID as CARD_ID,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesCashInvoice.totalAmount Total_Amount,
tblSalesCashInvoice.STATUS
FROM
dbo.tblSalesCashInvoice
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesCashInvoice.cardID = dbo.tblCardsProfile.cardID
WHERE salesCashInvoiceNo LIKE '%' + @searchValue + '%'
UNION ALL
SELECT
CONVERT(VARCHAR,dbo.tblSalesChargeInvoice.transDate,101) as DATE,
dbo.tblSalesChargeInvoice.salesChargeInvoiceNo as No,
dbo.tblSalesChargeInvoice.CARDID as CARD_ID,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesChargeInvoice.totalAmount Total_Amount,
tblSalesChargeInvoice.STATUS
FROM
dbo.tblSalesChargeInvoice
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesChargeInvoice.cardID = dbo.tblCardsProfile.cardID
WHERE salesChargeInvoiceNo LIKE '%' + @searchValue + '%') AS s 
where STATUS = '' and CARD_ID like '%'+@cardid+'%'
ORDER BY No
END
else if @command = 'Job' Begin
select * from tblJobOrder
where tblJobOrder.remarks = ''
end
END