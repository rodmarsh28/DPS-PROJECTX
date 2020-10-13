CREATE PROCEDURE [dbo].[checkInventoryInfo]
@itemNo varchar(255)
AS
BEGIN
select  buyable,sellable,INVENTORABLE,COSTOFSALESACC,INCOMEACC,ASSETACC,UNITCOST,status
from InventoryListAllView
WHERE itemno=@itemNo
END