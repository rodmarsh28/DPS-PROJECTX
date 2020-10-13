CREATE PROCEDURE [dbo].[get_requisition_data]
@command as varchar(255),
@searchValue as varchar(255)
AS
BEGIN
select distinct convert(varchar,item_requisistion_date,111) as DATE,requisition_no as Requisition_No 
from Item_Requisition
full outer join tblitem_issuance on tblitem_issuance.refno = Item_Requisition.requisition_no
where  requisition_no like '%' + @searchValue + '%' 
END