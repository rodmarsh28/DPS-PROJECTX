CREATE PROCEDURE [dbo].[get_leave_record]
@command varchar(255),
@dfrom datetime2,
@dto datetime2,
@searchValue varchar(255)
AS
BEGIN
if @command = '0' begin
select employeeID,
name,
sum(Leave_Without_Pay) as Leave_Without_Pay,
sum(Leave_With_Pay) as Leave_With_Pay
from
(SELECT
dbo.tblLeave.employeeID,tblEmployeesInfo.lastname + ', ' + tblEmployeesInfo.firstname + ' ' + tblEmployeesInfo.middlename AS NAME,
case when dbo.tblLeave.withpay = 'No' then
dbo.tblLeave.totalDays 
else
0 
end as Leave_Without_Pay,
case when dbo.tblLeave.withpay = 'Yes' then
dbo.tblLeave.totalDays 
else
0 
end as Leave_With_Pay
FROM
dbo.tblLeave
inner JOIN dbo.tblLeaveType ON dbo.tblLeave.leaveTypeID = dbo.tblLeaveType.leaveTypeID
INNER JOIN dbo.tblEmployeesInfo ON dbo.tblLeave.employeeID = dbo.tblEmployeesInfo.employeeID
where 
CONVERT(varchar,dateFrom,111) BETWEEN CONVERT(varchar,@dfrom,111) and CONVERT(varchar,@dto,111)) as s
GROUP BY
employeeID,
name
end
END