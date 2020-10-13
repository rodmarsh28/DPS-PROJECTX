CREATE PROCEDURE [dbo].[GET_SALES_LIST]
@command as varchar(255),
@searchValue as varchar(255)
AS
BEGIN
IF  @command = 'QUOTATION' BEGIN
SELECT
CONVERT(VARCHAR,dbo.tblSalesQuotation.transDate,101) as DATE,
dbo.tblSalesQuotation.quoteNo as No,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesQuotation.totalAmount Total_Amount,
status
FROM
dbo.tblSalesQuotation
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesQuotation.cardID = dbo.tblCardsProfile.cardID
WHERE quoteNo LIKE '%' + @searchValue + '%'
END
ELSE if @command = 'SALES ORDER' BEGIN
SELECT
CONVERT(VARCHAR,dbo.tblSalesOrder.transDate,101) as DATE,
dbo.tblSalesOrder.salesOrderNo as No,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesOrder.totalAmount Total_Amount,
status
FROM
dbo.tblSalesOrder
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesOrder.cardID = dbo.tblCardsProfile.cardID
WHERE salesOrderNo LIKE '%' + @searchValue + '%'
END
ELSE if @command = 'SALES CASH INVOICE' BEGIN
SELECT
CONVERT(VARCHAR,dbo.tblSalesCashInvoice.transDate,101) as DATE,
dbo.tblSalesCashInvoice.salesCashInvoiceNo as No,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesCashInvoice.totalAmount Total_Amount,
status
FROM
dbo.tblSalesCashInvoice
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesCashInvoice.cardID = dbo.tblCardsProfile.cardID
WHERE salesCashInvoiceNo LIKE '%' + @searchValue + '%'
END
ELSE if @command = 'SALES CHARGE INVOICE' BEGIN
SELECT
CONVERT(VARCHAR,dbo.tblSalesChargeInvoice.transDate,101) as DATE,
dbo.tblSalesChargeInvoice.salesChargeInvoiceNo as No,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesChargeInvoice.totalAmount Total_Amount,
status
FROM
dbo.tblSalesChargeInvoice
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesChargeInvoice.cardID = dbo.tblCardsProfile.cardID
WHERE salesChargeInvoiceNo LIKE '%' + @searchValue + '%'
END
ELSE if @command = 'SALES DELIVER' BEGIN
SELECT
CONVERT(VARCHAR,dbo.tblSalesDeliver.transDate,101) as DATE,
dbo.tblSalesDeliver.salesDeliverNo as No,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesDeliver.totalAmount Total_Amount,
status
FROM
dbo.tblSalesDeliver
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesDeliver.cardID = dbo.tblCardsProfile.cardID
WHERE salesDeliverNo LIKE '%' + @searchValue + '%'
END
ELSE if @command = 'JOB ORDER' BEGIN
SELECT distinct
	CONVERT(VARCHAR,tblJobOrder.[DATE],101) AS DATE, 
	tblJobOrder.JONO JOB_NO, 
	tblJobOrder.JONO REFNO, 
	tblCardsProfile.cardid AS CARD_ID,
	tblCardsProfile.cardName AS CUSTOMER,
	tblJobOrder.remarks AS REMARKS
FROM
	tblJobOrder
	INNER JOIN
	tblCardsProfile
	ON 
		tblJobOrder.CARDID = tblCardsProfile.cardID
	WHERE JONO LIKE '%' + @searchValue + '%'
END
END