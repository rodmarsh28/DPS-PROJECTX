CREATE PROCEDURE [dbo].[T3EST]
AS
BEGIN
	DECLARE   @PivotColumns AS NVARCHAR(MAX)
	DECLARE @PivotColumnsSum as NVARCHAR(MAX)
DECLARE   @SQLQuery AS NVARCHAR(MAX)
SELECT   @PivotColumns= COALESCE(@PivotColumns + ',','') + QUOTENAME(unit_desc)
FROM (SELECT DISTINCT unit_desc FROM tblItem_units) AS PivotExample

SELECT   @PivotColumnsSum= COALESCE(@PivotColumns + ',','') + QUOTENAME(unit_desc)
FROM (SELECT DISTINCT unit_desc FROM tblItem_units) AS PivotSum


SET @SQLQuery = N'SELECT 
 ' +   @PivotColumnsSum + ', ITEMNO
FROM
dbo.tblItem_units 
PIVOT ( SUM(MINQTY) FOR UNIT IN  (' + @PivotColumns + ')) as PVT'
EXEC sp_executesql @SQLQuery
select @SQLQuery
END