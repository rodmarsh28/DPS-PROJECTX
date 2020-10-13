CREATE PROCEDURE [dbo].[get_dtr_record_summary]
@dfrom datetime2,
@dto datetime2
AS
BEGIN
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
left join tblDTRrecord c on c.empid = b.employeeID and CONVERT(varchar,c.dtrDate,111) BETWEEN CONVERT(varchar,@dfrom,111) and CONVERT(varchar,@dto,111)
 where   ISNULL(CONVERT(varchar,c.dtrDate,111), '') <> '' 
 GROUP BY
 CONVERT(varchar,c.dtrDate,111),
 b.employeeID,b.lastname + ', ' + b.firstname + ' ' + b.middlename,
 
 ISNULL(c.remarks, ''),
ISNULL(c.dtrRecordNo, '')
ORDER BY b.lastname + ', ' + b.firstname + ' ' + b.middlename asc
END