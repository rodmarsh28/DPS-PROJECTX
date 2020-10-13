CREATE PROCEDURE [dbo].[get_employees_leave_list]
@command varchar(255),
@searchValue varchar(255)
AS
BEGIN
select dbo.tblLeave.leaveNo,
convert(varchar,dbo.tblLeave.dateFilled,111) as dateFilled,
dbo.tblLeave.employeeID,
tblLeaveType.leaveType,
dbo.tblLeave.reason,
convert(varchar,dbo.tblLeave.dateFrom,111) as dateFrom,
convert(varchar,dbo.tblLeave.dateTo,111) as dateTo,
dbo.tblLeave.totalDays,
dbo.tblLeave.withpay,
dbo.tblLeave.remarks from tblLeave 
INNER JOIN tblLeaveType on tblLeaveType.leaveTypeID = tblLeave.leaveTypeID
where employeeID like '%'+ @searchvalue + '%'
END