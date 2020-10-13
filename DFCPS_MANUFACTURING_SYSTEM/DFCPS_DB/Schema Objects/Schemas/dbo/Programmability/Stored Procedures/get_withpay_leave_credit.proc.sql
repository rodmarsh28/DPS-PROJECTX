CREATE PROCEDURE [dbo].[get_withpay_leave_credit]
@command varchar(255),
@searchValue varchar(255),
@yearNow datetime2
AS
BEGIN
SELECT leaveTypeID AS NO,
leaveType AS LEAVE_DESC,
days as TOTAL_APPROVE_DAYS,
sum(totalDays) as TOTAL_USED_CREDIT,
days - sum(totalDays) as REMAINING_CREDIT 
FROM
(SELECT
dbo.tblLeaveType.leaveTypeID,
dbo.tblLeaveType.leaveType,
dbo.tblLeaveType.days,
tblLeave.employeeID,
ISNULL(sum(dbo.tblLeave.totalDays), 0) as totalDays
FROM
dbo.tblLeaveType
LEFT JOIN dbo.tblLeave ON dbo.tblLeaveType.leaveTypeID = dbo.tblLeave.leaveTypeID AND  tblLeave.employeeID = @searchValue 
AND withpay = 'Yes' 
left join tblEmployeesInfo on tblEmployeesInfo.employeeID = tblLeave.employeeID
group by
dbo.tblLeaveType.leaveTypeID,
dbo.tblLeaveType.leaveType,
dbo.tblLeaveType.days,
tblLeave.employeeID) AS SUBT

GROUP BY
leaveTypeID,
leaveType,
days

END