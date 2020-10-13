CREATE PROCEDURE [dbo].[get_item_sellable]
@command int,
@SEARCH_VALUE VARCHAR(255)
AS
BEGIN
SELECT itemNo, itemdesc, unit, unitprice, qty , COSTOFSALESACC,incomeacc,assetacc,unitcost,PC_QTY
                FROM InventoryListAllView 
                where itemno like '%' + @SEARCH_VALUE + '%' and SELLABLE = '1'  or  itemdesc like '%'+@SEARCH_VALUE+'%'  and SELLABLE = '1'
END