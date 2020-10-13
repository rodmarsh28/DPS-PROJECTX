CREATE PROCEDURE [dbo].[GET_SALESORDER_LIST]
@searchValue as varchar(255)
AS
BEGIN
SELECT
CONVERT(VARCHAR,dbo.tblSalesOrder.transDate,101) as DATE,
dbo.tblSalesOrder.salesOrderNo as No,
dbo.tblCardsProfile.cardName as Card_Name,
dbo.tblSalesOrder.totalAmount Total_Amount
FROM
dbo.tblSalesOrder
INNER JOIN dbo.tblCardsProfile ON dbo.tblSalesOrder.cardID = dbo.tblCardsProfile.cardID
WHERE salesOrderNo LIKE '%' + @searchValue + '%'
END