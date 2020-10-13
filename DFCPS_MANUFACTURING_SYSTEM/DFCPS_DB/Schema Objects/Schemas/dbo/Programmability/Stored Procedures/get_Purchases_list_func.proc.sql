CREATE PROCEDURE [dbo].[get_Purchases_list_func]
@searchValue varchar(255),
@purchasesType varchar(255)
AS
BEGIN
select * from get_sales_list
where [No] like '%' + @searchValue + '%' and Type = @purchasesType or Customer like '%' + @searchValue + '%' and Type = @purchasesType 
END