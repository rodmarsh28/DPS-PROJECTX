CREATE PROCEDURE [dbo].[get_dept_list_func]
@searchValue varchar(255)
AS
BEGIN
select * from get_dept_list 
where [No] like '%' + @searchValue + '%' or department like '%' + @searchValue + '%' 
END