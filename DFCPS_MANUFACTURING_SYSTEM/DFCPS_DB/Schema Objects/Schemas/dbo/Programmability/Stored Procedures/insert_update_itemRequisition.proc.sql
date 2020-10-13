CREATE PROCEDURE [dbo].[insert_update_itemRequisition]
@requisitionNo as varchar(255),
@departmentNo as varchar(255),
@remarks as varchar(255),
@userID as varchar(255),
@itemCode as varchar(255),
@description as varchar(255),
@unit as varchar(255),
@onhand as int,
@qty as int
AS
BEGIN
insert into Item_Requisition values(@requisitionNo,GETDATE(),@departmentNo,@remarks,@userID,@itemCode,@description,@unit,@onhand,@qty,'')
END