CREATE PROCEDURE [dbo].[get_unit_info]
@Searchvalue nvarchar(max)
AS
BEGIN
DECLARE @PivotColumns AS NVARCHAR(MAX)
	DECLARE @PivotColumnsSum as NVARCHAR(MAX)
DECLARE   @SQLQuery AS NVARCHAR(MAX)
DECLARE @DROPDB AS NVARCHAR(MAX)
SELECT   @PivotColumns= COALESCE(@PivotColumns + ',','') + QUOTENAME(unit_desc)


FROM (SELECT DISTINCT unit_desc FROM tblInvtry
 INNER JOIN dbo.tblItem_units on dbo.tblItem_units.itemcode = tblInvtry.itemno  ) AS PivotExample

SELECT   @PivotColumnsSum= COALESCE(@PivotColumnsSum + ',','') +'sum'+ QUOTENAME(unit_desc,'()') + 'as ' + unit_desc
FROM (SELECT DISTINCT unit_desc FROM tblInvtry
 INNER JOIN dbo.tblItem_units on dbo.tblItem_units.itemcode = tblInvtry.itemno ) AS PivotSum



SET @SQLQuery = N'SELECT ITEMNO,ITEMDESC,STATUS,
 ' +   @PivotColumnsSum + ' into ##Temp
 
FROM tblInvtry
 INNER JOIN dbo.tblItem_units on dbo.tblItem_units.itemcode = tblInvtry.itemno
	
PIVOT ( SUM(MINQTY) FOR unit_desc IN  (' + @PivotColumns + ') ) as PVT

GROUP BY itemno
,ITEMDESC,STATUS
' 
exec sp_executesql @SQLQuery

Select * from ##Temp 
DROP TABLE ##Temp


END