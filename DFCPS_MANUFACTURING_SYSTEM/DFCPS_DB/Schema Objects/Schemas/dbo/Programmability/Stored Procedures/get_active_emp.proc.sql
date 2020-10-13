CREATE PROCEDURE [dbo].[get_active_emp]
@command varchar(255),
@dateTrans datetime2
AS
BEGIN 
if @command = 0 begin
select distinct 
b.employeeID,b.lastname + ', ' + b.firstname + ' ' + b.middlename AS NAME,
'0',
'0',
'0',
'0',
'0',
'0',
'0',
'0',
'0',
'0',
ISNULL(c.remarks, ''),
ISNULL(c.dtrRecordNo, '')
from 
tblEmployeesInfo bleft join tblDTRrecord c on c.empid = b.employeeID and CONVERT(varchar,c.dtrDate,111) = CONVERT(varchar,@dateTrans,111)
 where b.workingStatus	<> 'Inactive' AND ISNULL(CONVERT(varchar,c.dtrDate,111), '') = '' and b.department <> 'ADMIN' 
end
else if @command = 1 begin
select distinct 
b.employeeID,b.lastname + ', ' + b.firstname + ' ' + b.middlename AS NAME,
SUM(workedHours) as wh,
SUM(absentHours) as absent,
SUM(rhCounted) as rhc,
SUM(nwhCounted) as nwhc,
SUM(rhHoursReported) as rh,
SUM(nwhHoursReported) as nwh,
SUM(otHours) as oth,
SUM(otnHours) as otnh,
SUM(rdrHours) as rdrh,
SUM(lateUtMins) as lateut,
ISNULL(c.remarks, '') as remarks,
ISNULL(c.dtrRecordNo, '') as dtrRecordNo
from 
tblEmployeesInfo b
left join tblDTRrecord c on c.empid = b.employeeID and CONVERT(varchar,c.dtrDate,111) = CONVERT(varchar,@dateTrans,111)
 where   ISNULL(CONVERT(varchar,c.dtrDate,111), '') <> '' 
 GROUP BY
 b.employeeID,b.lastname + ', ' + b.firstname + ' ' + b.middlename,
 ISNULL(c.remarks, ''),
ISNULL(c.dtrRecordNo, '')
 end
 ELSE IF @command = 2 begin
 select distinct 
 CONVERT(varchar,c.dtrDate,111) as Date,
b.employeeID,
b.lastname + ', ' + b.firstname + ' ' + b.middlename AS NAME,
SUM(workedHours) as wh,
SUM(absentHours) as absent,
SUM(rhCounted) as rhc,
SUM(nwhCounted) as nwhc,
SUM(rhHoursReported) as rh,
SUM(nwhHoursReported) as nwh,
SUM(otHours) as oth,
SUM(otnHours) as otnh,
SUM(rdrHours) as rdrh,
SUM(lateUtMins) as lateut,
ISNULL(c.remarks, '') as remarks,
ISNULL(c.dtrRecordNo, '') as dtrRecordNo
from 
tblEmployeesInfo b
left join tblDTRrecord c on c.empid = b.employeeID and CONVERT(varchar,c.dtrDate,111) = CONVERT(varchar,@dateTrans,111)
 where   ISNULL(CONVERT(varchar,c.dtrDate,111), '') <> '' 
 GROUP BY
 CONVERT(varchar,c.dtrDate,111),
 b.employeeID,b.lastname + ', ' + b.firstname + ' ' + b.middlename,
 ISNULL(c.remarks, ''),
ISNULL(c.dtrRecordNo, '')
 end
END