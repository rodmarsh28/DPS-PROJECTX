CREATE VIEW [dbo].[paymentsView] AS SELECT CARDID,
CARDNAME,
INVOICENO,
CASE WHEN sum(TOTALAMOUNT)- sum(AMOUNTPAID) <= 0 then 'CLOSE' ELSE 'OPEN' END AS STATUS,
[DATE],
SUM(TOTALAMOUNT) AS TOTALAMOUNT,
SUM(TOTALDISCOUNT) AS TOTALDISCOUNT,
SUM(AMOUNTPAID) AS AMOUNTPAID
FROM(
SELECT
dbo.tblCardsProfile.cardID as CARDID,
dbo.tblCardsProfile.cardName AS CARDNAME,
dbo.tblsalesChargeInvoice.salesChargeInvoiceNo AS INVOICENO,
convert(varchar, dbo.tblsalesChargeInvoice.transDate, 101) AS [DATE],
dbo.tblsalesChargeInvoice.totalDiscount as TOTALDISCOUNT,
dbo.tblsalesChargeInvoice.totalAmount AS TOTALAMOUNT,
0 AMOUNTPAID
FROM
dbo.tblCardsProfile
INNER JOIN dbo.tblsalesChargeInvoice ON dbo.tblCardsProfile.cardID = dbo.tblsalesChargeInvoice.cardID
GROUP BY
dbo.tblCardsProfile.cardID,
dbo.tblCardsProfile.cardName,
dbo.tblsalesChargeInvoice.salesChargeInvoiceNo,
dbo.tblsalesChargeInvoice.transDate,
dbo.tblsalesChargeInvoice.totalDiscount,
dbo.tblsalesChargeInvoice.totalAmount
UNION ALL
SELECT
dbo.tblCardsProfile.cardID as CARDID,
dbo.tblCardsProfile.cardName AS CARDNAME,
dbo.tblsalesChargeInvoice.salesChargeInvoiceNo AS INVOICENO,
convert(varchar, dbo.tblsalesChargeInvoice.transDate, 101) AS [DATE],
Sum(dbo.tblPaymentsReceived.amountDiscount) AS TOTALDISCOUNT,
0 AS TOTALAMOUNT,
Sum(dbo.tblPaymentsReceived.amountApplied) AS AMOUNTPAID
FROM
dbo.tblCardsProfile
INNER JOIN dbo.tblsalesChargeInvoice ON dbo.tblCardsProfile.cardID = dbo.tblsalesChargeInvoice.cardID
INNER JOIN dbo.tblPaymentsReceived ON dbo.tblsalesChargeInvoice.salesChargeInvoiceNo = dbo.tblPaymentsReceived.invoiceNo
GROUP BY
dbo.tblCardsProfile.cardID,
dbo.tblCardsProfile.cardName,
dbo.tblsalesChargeInvoice.salesChargeInvoiceNo,
dbo.tblsalesChargeInvoice.transDate,
dbo.tblsalesChargeInvoice.totalAmount
) AS SUBT
GROUP BY
CARDID,CARDNAME,INVOICENO,[DATE]