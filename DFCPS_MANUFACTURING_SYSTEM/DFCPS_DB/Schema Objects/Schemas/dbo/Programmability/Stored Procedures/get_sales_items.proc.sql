CREATE PROCEDURE [dbo].[get_sales_items]
@command varchar(255),
@searchValue varchar(255)
AS
BEGIN
if @command = 'Quotation' begin
SELECT
dbo.tblSalesQuotation.quoteNo,
dbo.tblSalesQuotation.cardID,
tblCardsProfile.cardname,
dbo.tblSalesItemsTR.itemNo,
tblInvtry.itemdesc,
u.unit_desc,
dbo.tblSalesItemsTR.qty,
dbo.tblSalesItemsTR.uPrice,
dbo.tblSalesItemsTR.discount,
dbo.tblSalesItemsTR.amount,
dbo.tblSalesItemsTR.cost,
dbo.tblSalesItemsTR.pc
FROM
dbo.tblSalesQuotation
INNER JOIN dbo.tblSalesItemsTR ON dbo.tblSalesQuotation.quoteNo = dbo.tblSalesItemsTR.transNo
INNER JOIN tblCardsProfile on tblSalesQuotation.cardID = tblCardsProfile.cardID
inner join tblInvtry on tblSalesItemsTR.itemNo = tblInvtry.ITEMNO
inner join dbo.tblItem_units u on u.itemcode = tblInvtry.itemNo 
where dbo.tblSalesQuotation.quoteNo = @searchValue
end
else if  @command = 'Sales Order' begin
SELECT
dbo.tblSalesOrder.salesOrderNo,
dbo.tblSalesOrder.cardID,
tblCardsProfile.cardname,
dbo.tblSalesItemsTR.itemNo,
tblInvtry.itemdesc,
u.unit_desc,
dbo.tblSalesItemsTR.qty,
dbo.tblSalesItemsTR.uPrice,
dbo.tblSalesItemsTR.discount,
dbo.tblSalesItemsTR.amount,
dbo.tblSalesItemsTR.cost,
dbo.tblSalesItemsTR.pc
FROM
dbo.tblSalesOrder
INNER JOIN dbo.tblSalesItemsTR ON dbo.tblSalesOrder.salesOrderNo = dbo.tblSalesItemsTR.transNo
INNER JOIN tblCardsProfile on tblSalesOrder.cardID = tblCardsProfile.cardID
inner join tblInvtry on tblSalesItemsTR.itemNo = tblInvtry.ITEMNO
inner join dbo.tblItem_units u on u.itemcode = tblInvtry.itemNo 
where dbo.tblSalesOrder.salesOrderNo = @searchValue
end
else if  @command = 'Sales Invoice' begin
SELECT
	SALESNO,
	CARD_ID,
	NAME,
	ITEMNO,
	ITEMDESC,
	UNIT,
	QTY,
	UPRICE,
	DISCOUNT,
	COST,
	SUM ( PC ) AS PC 
FROM
	(
	SELECT
		dbo.tblSalesCashInvoice.salesCashInvoiceNo AS SALESNO,
		dbo.tblSalesCashInvoice.transDate AS DATE_TR,
		dbo.tblSalesCashInvoice.cardID AS CARD_ID,
		tblCardsProfile.cardname AS NAME,
		dbo.tblSalesItemsTR.itemNo AS ITEMNO,
		tblInvtry.itemdesc AS ITEMDESC,
		u.unit_desc AS UNIT,
		dbo.tblSalesItemsTR.qty AS QTY,
		dbo.tblSalesItemsTR.uPrice AS UPRICE,
		dbo.tblSalesItemsTR.discount AS DISCOUNT,
		dbo.tblSalesItemsTR.amount AS AMOUNT,
		dbo.tblSalesItemsTR.cost AS COST,
		dbo.tblSalesItemsTR.pc AS PC 
	FROM
		dbo.tblSalesCashInvoice
		INNER JOIN dbo.tblSalesItemsTR ON dbo.tblSalesCashInvoice.salesCashInvoiceNo = dbo.tblSalesItemsTR.transNo
		INNER JOIN tblCardsProfile ON tblSalesCashInvoice.cardID = tblCardsProfile.cardID
		INNER JOIN tblInvtry ON tblSalesItemsTR.itemNo = tblInvtry.ITEMNO
		INNER JOIN dbo.tblItem_units u ON u.itemcode = tblInvtry.itemNo 
	WHERE
		salesCashInvoiceNo = @searchValue UNION ALL
	SELECT
		dbo.tblSalesChargeInvoice.salesChargeInvoiceNo AS SALESNO,
		dbo.tblSalesChargeInvoice.transDate AS DATE_TR,
		dbo.tblSalesChargeInvoice.cardID AS CARD_ID,
		tblCardsProfile.cardname AS NAME,
		dbo.tblSalesItemsTR.itemNo AS ITEMNO,
		tblInvtry.itemdesc AS ITEMDESC,
		u.unit_desc AS UNIT,
		dbo.tblSalesItemsTR.qty AS QTY,
		dbo.tblSalesItemsTR.uPrice AS UPRICE,
		dbo.tblSalesItemsTR.discount AS DISCOUNT,
		dbo.tblSalesItemsTR.amount AS AMOUNT,
		dbo.tblSalesItemsTR.cost AS COST,
		dbo.tblSalesItemsTR.pc AS PC 
	FROM
		dbo.tblSalesChargeInvoice
		INNER JOIN dbo.tblSalesItemsTR ON dbo.tblSalesChargeInvoice.salesChargeInvoiceNo = dbo.tblSalesItemsTR.transNo
		INNER JOIN tblCardsProfile ON tblSalesChargeInvoice.cardID = tblCardsProfile.cardID
		INNER JOIN tblInvtry ON tblSalesItemsTR.itemNo = tblInvtry.ITEMNO
		INNER JOIN dbo.tblItem_units u ON u.itemcode = tblInvtry.itemNo 
	WHERE
		salesChargeInvoiceNo = @searchValue 
		UNION ALL
	SELECT
		dbo.tblSalesDeliver.REFNO AS SALESNO,
		NULL AS DATE_TR,
		dbo.tblSalesDeliver.cardID AS CARD_ID,
		tblCardsProfile.cardname AS NAME,
		dbo.tblSalesItemsTR.itemNo AS ITEMNO,
		tblInvtry.itemdesc AS ITEMDESC,
		u.unit_desc AS UNIT,
		0 AS QTY,
		dbo.tblSalesItemsTR.uPrice AS UPRICE,
		dbo.tblSalesItemsTR.discount AS DISCOUNT,
		dbo.tblSalesItemsTR.amount AS AMOUNT,
		dbo.tblSalesItemsTR.cost AS COST,
		- + dbo.tblSalesItemsTR.pc AS PC 
	FROM
		dbo.tblSalesDeliver
		INNER JOIN dbo.tblSalesItemsTR ON dbo.tblSalesDeliver.salesDeliverNo = dbo.tblSalesItemsTR.transNo
		INNER JOIN tblCardsProfile ON tblSalesDeliver.cardID = tblCardsProfile.cardID
		INNER JOIN tblInvtry ON tblSalesItemsTR.itemNo = tblInvtry.ITEMNO
		INNER JOIN dbo.tblItem_units u ON u.itemcode = tblInvtry.itemNo 
	WHERE
		refno = @searchValue 
	) AS B 
GROUP BY
	SALESNO,
	CARD_ID,
	NAME,
	ITEMNO,
	ITEMDESC,
	UNIT,
	QTY,
	UPRICE,
	DISCOUNT,
	COST
end
else if  @command = 'Sales Deliver' begin
SELECT
dbo.tblSalesDeliver.salesDeliverNo,
dbo.tblSalesDeliver.cardID,
tblCardsProfile.cardname,
dbo.tblSalesItemsTR.itemNo,
tblInvtry.itemdesc,
u.unit_desc,
dbo.tblSalesItemsTR.qty,
dbo.tblSalesItemsTR.uPrice,
dbo.tblSalesItemsTR.discount,
dbo.tblSalesItemsTR.amount,
dbo.tblSalesItemsTR.cost,
dbo.tblSalesItemsTR.pc
FROM
dbo.tblSalesDeliver
INNER JOIN dbo.tblSalesItemsTR ON dbo.tblSalesDeliver.salesDeliverNo = dbo.tblSalesItemsTR.transNo
INNER JOIN tblCardsProfile on tblSalesDeliver.cardID = tblCardsProfile.cardID
inner join tblInvtry on tblSalesItemsTR.itemNo = tblInvtry.ITEMNO
inner join dbo.tblItem_units u on u.itemcode = tblInvtry.itemNo 
where salesDeliverNo = @searchValue
end
END