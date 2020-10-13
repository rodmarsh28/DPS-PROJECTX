CREATE PROCEDURE [dbo].[get_item_inventoriable]
@command int,
@SEARCH_VALUE VARCHAR(255)
AS
BEGIN
SELECT itemNo, itemdesc, unit, unitcost, qty, COSTOFSALESACC,incomeacc,assetacc,PC_QTY
                FROM InventoryListAllView 
                where itemno like '%' + @SEARCH_VALUE + '%' and INVENTORABLE = '1'  or  itemdesc like '%'+@SEARCH_VALUE+'%'  and INVENTORABLE = '1' 
END