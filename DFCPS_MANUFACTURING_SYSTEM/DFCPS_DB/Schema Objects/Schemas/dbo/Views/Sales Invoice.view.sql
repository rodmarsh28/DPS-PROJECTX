CREATE VIEW [dbo].[Sales Invoice] AS SELECT
	SCI.salesCashInvoiceNo as No,
	SCI.transDate,
	sci.refNo,
	sci.cardID,
	sci.totalFullAmount,
	sci.totalDiscount,
	sci.totalAmount,
	sci.userID,
	sci.status,
	sci.notimesedit,
	sci.lastdateedit 
FROM
	tblSalesCashInvoice SCI UNION ALL
SELECT
	SCRI.salesChargeInvoiceNo as No,
	SCRI.transDate,
	SCRI.refNo,
	SCRI.cardID,
	SCRI.totalFullAmount,
	SCRI.totalDiscount,
	SCRI.totalAmount,
	SCRI.userID,
	SCRI.status,
	SCRI.notimesedit,
	SCRI.lastdateedit 
FROM
	tblSalesChargeInvoice SCRI