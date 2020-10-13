CREATE PROCEDURE [dbo].[get_piloan_summary]
@monthNo as int
AS
BEGIN
select department,piNo,'Salary Loan',tblPayrollofEmployees.employeeID,lastname + ', ' + firstname + ' ' + middlename + '.',piLoans
from tblPayrollofEmployees
INNER JOIN tblEmployeesInfo on tblEmployeesInfo.employeeID = tblPayrollofEmployees.employeeID
inner join tblpayroll on tblPayrollofEmployees.payrollID = tblPayroll.payrollID
where piLoans <> 0 and month(dbo.tblPayroll.dateTo) = @monthNo
END