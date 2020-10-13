CREATE PROCEDURE [dbo].[GET_JO_HISTORY]
AS
BEGIN
SELECT [DATE],JONO,SALESNO,CUSTOMER,SUM(QTY) AS QTY,SUM(RELEASED) AS RELEASED,
CASE WHEN SUM(QTY)>SUM(RELEASED) THEN
'UNRELEASED'
ELSE
'RELEASED'
END
AS STATUS
FROM(SELECT
	dbo.tblJobOrder.[DATE],
	dbo.tblJobOrder.JONO,
	dbo.tblJobOrder.SALESNO,
	dbo.tblJobOrder.CUSTOMER,
	SUM ( dbo.tblJobOrderTR.QTY ) AS QTY,
	0 AS RELEASED 
FROM
	dbo.tblJobOrder
inner JOIN dbo.tblJobOrderTR ON dbo.tblJobOrder.JONO = dbo.tblJobOrderTR.JONO

GROUP BY
	dbo.tblJobOrder.JONO,
	dbo.tblJobOrder.[DATE],
	dbo.tblJobOrder.SALESNO,
	dbo.tblJobOrder.CUSTOMER 

	UNION ALL
	SELECT
	dbo.tblJobOrder.[DATE],
	dbo.tblJobOrder.JONO,
	dbo.tblJobOrder.SALESNO,
	dbo.tblJobOrder.CUSTOMER,
0 AS QTY,
	SUM ( dbo.tblOrderReleasedTR.RELEASED ) AS RELEASED 
FROM
	dbo.tblJobOrder
	RIGHT  JOIN dbo.tblOrderReleasedTR ON dbo.tblJobOrder.JONO = dbo.tblOrderReleasedTR.JONO 
GROUP BY
	dbo.tblJobOrder.JONO,
	dbo.tblJobOrder.[DATE],
	dbo.tblJobOrder.SALESNO,
	dbo.tblJobOrder.CUSTOMER ) AS SUBT
	 GROUP BY
	 [DATE],JONO,SALESNO,CUSTOMER
	 ORDER BY [date] desc
	
END