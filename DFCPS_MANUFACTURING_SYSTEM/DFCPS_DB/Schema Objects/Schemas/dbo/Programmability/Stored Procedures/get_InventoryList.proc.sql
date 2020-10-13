CREATE PROCEDURE [dbo].[get_InventoryList]
@command int,
@SearchValue VARCHAR(255)
AS
BEGIN 
if @command = 0 begin
SELECT * FROM InventoryListAllView where itemno like '%' + @searchValue + '%' or  itemdesc like '%' + @searchValue + '%' 
end
else if @command = 1 begin
SELECT
dbo.InventoryListAllView.ITEMNO,
dbo.InventoryListAllView.ITEMDESC,
dbo.InventoryListAllView.UNIT,
sum(dbo.tblItemTransaction.UNITCOST) / COUNT(tblItemTransaction.ITEMNO) AS UNITCOST,
dbo.InventoryListAllView.UNITPRICE,
- + SUM(dbo.tblItemTransaction.qty) AS QTY,
dbo.InventoryListAllView.BUYABLE,
dbo.InventoryListAllView.SELLABLE,
dbo.InventoryListAllView.INVENTORABLE,
dbo.InventoryListAllView.COSTOFSALESACC,
dbo.InventoryListAllView.INCOMEACC,
dbo.InventoryListAllView.ASSETACC,
- + SUM(dbo.tblItemTransaction.PC) as PC_QTY

FROM
dbo.InventoryListAllView
INNER JOIN dbo.tblItemTransaction ON dbo.tblItemTransaction.itemNo = dbo.InventoryListAllView.ITEMNO
WHERE
tblItemTransaction.itemno like '%' + @searchValue + '%' and dbo.tblItemTransaction.refNo LIKE 'DR-%'
or  InventoryListAllView.itemdesc like '%' + @searchValue + '%' and dbo.tblItemTransaction.refNo LIKE 'DR-%'

GROUP BY
dbo.InventoryListAllView.ITEMNO,
dbo.InventoryListAllView.ITEMDESC,
dbo.InventoryListAllView.UNIT,
dbo.InventoryListAllView.UNITPRICE,
dbo.InventoryListAllView.BUYABLE,
dbo.InventoryListAllView.SELLABLE,
dbo.InventoryListAllView.INVENTORABLE,
dbo.InventoryListAllView.COSTOFSALESACC,
dbo.InventoryListAllView.INCOMEACC,
dbo.InventoryListAllView.ASSETACC,
dbo.InventoryListAllView.PC_QTY
end
else if @command = 2 begin
SELECT
dbo.InventoryListAllView.ITEMNO,
dbo.InventoryListAllView.ITEMDESC,
dbo.InventoryListAllView.UNIT,
sum(dbo.tblItemTransaction.UNITCOST) / COUNT(tblItemTransaction.ITEMNO) AS UNITCOST,
dbo.InventoryListAllView.UNITPRICE,
SUM(dbo.tblItemTransaction.qty)AS QTY,
dbo.InventoryListAllView.BUYABLE,
dbo.InventoryListAllView.SELLABLE,
dbo.InventoryListAllView.INVENTORABLE,
dbo.InventoryListAllView.COSTOFSALESACC,
dbo.InventoryListAllView.INCOMEACC,
dbo.InventoryListAllView.ASSETACC,
- + SUM(dbo.tblItemTransaction.PC) as PC_QTY

FROM
dbo.InventoryListAllView
INNER JOIN dbo.tblItemTransaction ON dbo.tblItemTransaction.itemNo = dbo.InventoryListAllView.ITEMNO
WHERE
tblItemTransaction.itemno like '%' + @searchValue + '%' and dbo.tblItemTransaction.refNo LIKE 'RMW-%' or 
tblItemTransaction.itemno like '%' + @searchValue + '%' and dbo.tblItemTransaction.refNo LIKE 'RMP-%' or 
InventoryListAllView.itemdesc like '%' + @searchValue + '%' and dbo.tblItemTransaction.refNo LIKE 'RMW-%' or
InventoryListAllView.itemdesc like '%' + @searchValue + '%' and dbo.tblItemTransaction.refNo LIKE 'RMP-%' 

GROUP BY
dbo.InventoryListAllView.ITEMNO,
dbo.InventoryListAllView.ITEMDESC,
dbo.InventoryListAllView.UNIT,
dbo.InventoryListAllView.UNITPRICE,
dbo.InventoryListAllView.BUYABLE,
dbo.InventoryListAllView.SELLABLE,
dbo.InventoryListAllView.INVENTORABLE,
dbo.InventoryListAllView.COSTOFSALESACC,
dbo.InventoryListAllView.INCOMEACC,
dbo.InventoryListAllView.ASSETACC,
dbo.InventoryListAllView.PC_QTY
end
END