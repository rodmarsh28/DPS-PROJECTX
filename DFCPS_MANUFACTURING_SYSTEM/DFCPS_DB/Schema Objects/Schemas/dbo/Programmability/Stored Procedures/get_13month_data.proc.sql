CREATE PROCEDURE [dbo].[get_13month_data]
@command varchar(255),
@yearValue as datetime2
AS
BEGIN
select DATEPART(year, tbl13month.[year]) as [year],
tbl13month.empID as empid,
tblEmployeesInfo.lastname + ', ' + tblEmployeesInfo.firstname + '. ' +tblEmployeesInfo.middlename as name,
tbl13month.asd,
tbl13month.[13month] as [13m]
from tbl13month
INNER JOIN tblEmployeesInfo on tblEmployeesInfo.employeeID = tbl13month.empid
where DATEPART(year, tbl13month.[year]) = DATEPART(year, @yearValue)
END