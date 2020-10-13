CREATE PROCEDURE [dbo].[get_sssloan_summary]
@monthNo as int
AS
BEGIN
select department,sssNo,'Salary Loan',tblPayrollofEmployees.employeeID,lastname + ', ' + firstname + ' ' + middlename + '.',sssLoans
from tblPayrollofEmployees
INNER JOIN tblEmployeesInfo on tblEmployeesInfo.employeeID = tblPayrollofEmployees.employeeID
inner join tblPayroll on tblPayrollofEmployees.payrollID = tblPayroll.payrollID
where sssLoans <> 0 and  month(dbo.tblPayroll.dateTo) = @monthNo
END