CREATE VIEW [dbo].[get_dept_list] AS SELECT
dbo.tblDepartmentProfile.departmentNo as No,
dbo.tblDepartmentProfile.department as Department,
0 as Count
FROM
dbo.tblDepartmentProfile