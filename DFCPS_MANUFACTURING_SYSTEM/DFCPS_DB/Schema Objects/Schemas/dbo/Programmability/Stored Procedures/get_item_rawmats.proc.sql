CREATE PROCEDURE [dbo].[get_item_rawmats]
@command int,
@SEARCH_VALUE varchar(255)
AS
BEGIN
SELECT itemNo, itemdesc, unit, unitcost, qty, COSTOFSALESACC,incomeacc,assetacc,unitcost
                FROM InventoryListAllView 
                where itemno like '%' + @SEARCH_VALUE + '%' and itemno like 'WIP-%'  
								OR itemno like '%' + @SEARCH_VALUE + '%' and itemno like 'RM-%'  
								or  itemdesc like '%'+@SEARCH_VALUE+'%'  and itemno like 'WP-%' 
								or  itemdesc like '%'+@SEARCH_VALUE+'%'  and itemno like 'RM-%'  
END