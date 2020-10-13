CREATE PROCEDURE [dbo].[get_sales_list_func]
@searchValue varchar(255),
@salesType varchar(255)
AS
BEGIN
select * from get_sales_list
where [No] like '%' + @searchValue + '%' and Type = @salesType or Customer like '%' + @searchValue + '%' and Type = @salesType 
END