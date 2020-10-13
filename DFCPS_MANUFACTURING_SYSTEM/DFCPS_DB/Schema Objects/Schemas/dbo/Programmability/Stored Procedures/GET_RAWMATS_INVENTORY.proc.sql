CREATE PROCEDURE [dbo].[GET_RAWMATS_INVENTORY]
@SEARCHVALUE AS VARCHAR(255)
AS
BEGIN
 WITH SUBT AS (SELECT
dbo.tblRMInventoryTrans.REFNO,
dbo.tblRMInventory.ITEMCODE,
dbo.tblRMInventory.RMT,
dbo.tblRMInventory.RMC,
dbo.tblRMInventory.UNIT,
sum(dbo.tblRMInventoryTrans.QTY) as [IN],
0 AS OUT,
dbo.tblRMInventoryTrans.UNITPRICE


FROM
dbo.tblRMInventory
INNER JOIN dbo.tblRMInventoryTrans ON dbo.tblRMInventory.ITEMCODE = dbo.tblRMInventoryTrans.ITEMCODE
WHERE tblRMInventoryTrans.REFNO LIKE 'RCV-%' OR tblRMInventoryTrans.REFNO LIKE 'RR-%'
GROUP BY 
dbo.tblRMInventoryTrans.REFNO,
dbo.tblRMInventory.ITEMCODE,
dbo.tblRMInventory.RMT,
dbo.tblRMInventory.RMC,
dbo.tblRMInventory.UNIT,
dbo.tblRMInventoryTrans.UNITPRICE
UNION ALL
SELECT
dbo.tblRMInventoryTrans.REFNO,
dbo.tblRMInventory.ITEMCODE,
dbo.tblRMInventory.RMT,
dbo.tblRMInventory.RMC,
dbo.tblRMInventory.UNIT,
0 AS [IN],
sum(dbo.tblRMInventoryTrans.QTY) as OUT,
dbo.tblRMInventoryTrans.UNITPRICE

FROM
dbo.tblRMInventory
INNER JOIN dbo.tblRMInventoryTrans ON dbo.tblRMInventory.ITEMCODE = dbo.tblRMInventoryTrans.ITEMCODE
WHERE tblRMInventoryTrans.REFNO not LIKE 'RCV-%' AND tblRMInventoryTrans.REFNO NOT LIKE 'RR-%'
GROUP BY 
dbo.tblRMInventoryTrans.REFNO,
dbo.tblRMInventory.ITEMCODE,
dbo.tblRMInventory.RMT,
dbo.tblRMInventory.RMC,
dbo.tblRMInventory.UNIT,
dbo.tblRMInventoryTrans.UNITPRICE) 
SELECT ITEMCODE,RMT as DESCRIPTION,RMC AS TYPE,UNIT,SUM([IN]) AS [IN],-+SUM(OUT) AS OUT,SUM([IN])+SUM(OUT) AS REMAINING,CAST(SUM(UNITPRICE)/COUNT(UNITPRICE) AS DECIMAL(20,2)) AS UNIT_PRICE
FROM SUBT
WHERE ITEMCODE LIKE '%'+@SEARCHVALUE + '%' OR RMT LIKE '%'+@SEARCHVALUE + '%' OR RMC LIKE '%'+@SEARCHVALUE + '%'
GROUP BY
ITEMCODE,RMT,RMC,UNIT

END