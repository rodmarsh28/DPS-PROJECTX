CREATE VIEW [dbo].[InventoryListAllView] AS SELECT
	ITEMNO as ITEMNO,
	ITEMDESC,
	UNIT,
	AVG(UNITCOST) AS UNITCOST,
	UNITPRICE,
	SUM ( QTY ) AS QTY,
	BUYABLE,
	SELLABLE,
	INVENTORABLE,
	COSTOFSALESACC,
	INCOMEACC,
	ASSETACC,
	MINQTY,
	 SUM(PC_QTY) AS PC_QTY,
	STATUS
FROM
	(
	/*SELECT
		b.ITEMNO,
		b.ITEMDESC,
		b.UNIT,
		b.UNITCOST AS UNITCOST,
		0 AS QTY,
		b.UNITPRICE ,
		buyable,
		sellable,
		INVENTORABLE,
		COSTOFSALESACC,
		INCOMEACC,
		ASSETACC,
		status 
	FROM
		b UNION ALL*/
	SELECT 
		b.ITEMNO,
		b.ITEMDESC,
		u.unit_desc as unit,
		dbo.tblItemTransaction.UNITCOST AS UNITCOST,
		dbo.tblItemTransaction.QTY AS QTY,
		(select price from tblSales_price sp1 
		where sp1.price_id = (select max(price_id) 
		from tblSales_price sp where sp.itemcode = b.itemno)) AS UNITPRICE,
		buyable,
		sellable,
		INVENTORABLE,
		COSTOFSALESACC,
		INCOMEACC,
		ASSETACC,
		status,
		u.minQty AS MINQTY,
		dbo.tblItemTransaction.pc as PC_QTY 
	FROM
		dbo.tblInvtry b
		INNER JOIN dbo.tblItemTransaction ON b.ITEMNO = dbo.tblItemTransaction.itemNo 
		inner join dbo.tblItem_units u on u.itemcode = tblItemTransaction.itemNo 
		
	
						
	) AS SUBT 
	
GROUP BY
	ITEMNO,
	ITEMDESC,
	UNIT,
 UNITPRICE,
	BUYABLE,
	SELLABLE,
	INVENTORABLE,
	COSTOFSALESACC,
	INCOMEACC,
	ASSETACC,
	MINQTY,
	STATUS