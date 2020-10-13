CREATE PROCEDURE [dbo].[update_yearRes]
AS

declare @datehired as datetime2
declare @yearRes as int
declare @yearnow as INT
BEGIN
set @yearnow = DATEPART(YEAR, GETDATE())
select @datehired = dateHired,
@yearRes = DATEPART(year, yearRes)
from tblEmployeesInfo

END