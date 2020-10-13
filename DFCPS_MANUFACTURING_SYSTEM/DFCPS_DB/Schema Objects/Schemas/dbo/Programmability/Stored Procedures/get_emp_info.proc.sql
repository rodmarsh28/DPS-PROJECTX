CREATE PROCEDURE [dbo].[get_emp_info]
@command varchar(255),
@searchValue varchar(255)
AS
BEGIN
if @command = 0 /* default */ BEGIN
SELECT
dbo.tblEmployeesInfo.employeeID,
dbo.tblEmployeesInfo.lastname,
dbo.tblEmployeesInfo.firstname,
dbo.tblEmployeesInfo.middlename,
dbo.tblEmployeesInfo.rate,
dbo.tblEmployeesInfo.[position],
dbo.tblEmployeesInfo.department,
dbo.tblEmployeesInfo.division,
dbo.tblEmployeesInfo.dateHired
FROM
dbo.tblEmployeesInfo
where employeeID = @searchValue
end
else if @command = 1 /* All */ BEGIN
SELECT
dbo.tblEmployeesInfo.employeeID,
dbo.tblEmployeesInfo.lastname,
dbo.tblEmployeesInfo.firstname,
dbo.tblEmployeesInfo.middlename,
dbo.tblEmployeesInfo.rate,
dbo.tblEmployeesInfo.[position],
dbo.tblEmployeesInfo.department,
dbo.tblEmployeesInfo.division,
dbo.tblEmployeesInfo.dateHired,
workingStatus
FROM
dbo.tblEmployeesInfo
where employeeID like '%'+@searchValue+'%'
end
else if @command = 2 /* Active */ BEGIN
SELECT
dbo.tblEmployeesInfo.employeeID,
dbo.tblEmployeesInfo.lastname,
dbo.tblEmployeesInfo.firstname,
dbo.tblEmployeesInfo.middlename,
dbo.tblEmployeesInfo.rate,
dbo.tblEmployeesInfo.[position],
dbo.tblEmployeesInfo.department,
dbo.tblEmployeesInfo.division,
dbo.tblEmployeesInfo.dateHired,
workingStatus
FROM
dbo.tblEmployeesInfo
where employeeID like '%'+@searchValue+'%' and workingStatus <> 'Inactive'
end
else if @command = 3 /* Inactive */ BEGIN
SELECT
dbo.tblEmployeesInfo.employeeID,
dbo.tblEmployeesInfo.lastname,
dbo.tblEmployeesInfo.firstname,
dbo.tblEmployeesInfo.middlename,
dbo.tblEmployeesInfo.rate,
dbo.tblEmployeesInfo.[position],
dbo.tblEmployeesInfo.department,
dbo.tblEmployeesInfo.division,
dbo.tblEmployeesInfo.dateHired,
workingStatus
FROM
dbo.tblEmployeesInfo
where employeeID like '%'+@searchValue+'%' and workingStatus = 'Inactive'
end
END