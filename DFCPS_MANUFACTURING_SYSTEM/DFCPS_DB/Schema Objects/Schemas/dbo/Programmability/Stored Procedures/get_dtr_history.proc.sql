CREATE PROCEDURE [dbo].[get_dtr_history]
@command varchar(255),
@dateTrans datetime2,
@searchValue varchar(255)
AS
BEGIN
if @command = 'DTR_RECORD' begin
SELECT
dbo.tblDTRrecord.dtrRecordNo as RECORD_NO,
CONVERT(varchar,dbo.tblDTRrecord.dtrDate,111)  AS DATE,
count(dbo.tblDTRrecord.empID) as EMPLOYEES_RECORD_COUNT,
dbo.tblDTRrecord.remarks AS REMARKS
FROM
dbo.tblDTRrecord
where dtrRecordNo like '%'+@searchValue+'%'
GROUP BY
dbo.tblDTRrecord.dtrRecordNo,
dbo.tblDTRrecord.dtrDate,
dbo.tblDTRrecord.remarks
end

END