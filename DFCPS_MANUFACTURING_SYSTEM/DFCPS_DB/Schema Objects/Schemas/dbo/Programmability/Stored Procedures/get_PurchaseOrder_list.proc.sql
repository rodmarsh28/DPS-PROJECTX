CREATE PROCEDURE [dbo].[get_PurchaseOrder_list]
@searchValue as varchar(255)
AS
BEGIN
SELECT DISTINCT
convert(varchar,[transDate],111) AS [Date],
dbo.tblPurchaseOrder.purchaseOrderNo AS PurchaseOrder_No,
case when tblApprovedTransaction.approved = 1
then 'Approved'
else
'Pending for Approval'
end as Status
FROM
dbo.tblPurchaseOrder
left JOIN dbo.tblApprovedTransaction ON dbo.tblPurchaseOrder.purchaseOrderNo = dbo.tblApprovedTransaction.refNo
where purchaseOrderNo like '%' + @searchValue + '%' and status <> 'Received'
END