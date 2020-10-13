CREATE PROCEDURE [dbo].[GET_ACC_BALANCE]
@searchValue as varchar(255)
AS
BEGIN
	select ACC_NO,
CASE 
	WHEN place = 'SUB' THEN
		'    '+ACC_NO+'  '+ACC_NAME 
	WHEN place = 'DEPT' THEN
		'        '+ACC_NO+'  '+ACC_NAME 
	WHEN place = 'ACC' THEN
		'            '+ACC_NO+'  '+ACC_NAME 
	ELSE
		ACC_NO+'  '+ACC_NAME
END AS ACC_NAME,
ACC_BALANCE
from (SELECT
	CONVERT(VARCHAR(255),header_acc_view.accHeaderNo) as ACC_NO, 
	header_acc_view.accHeader AS ACC_NAME, 
	header_acc_view.Header_Balance AS ACC_BALANCE,
	'HEADER' AS place
FROM
	header_acc_view
	union all
SELECT
	subheader_acc_view.accSubHeaderNo as ACC_NO, 
	subheader_acc_view.subHeader as ACC_NAME, 
	subheader_acc_view.SUBHEADER_BALANCE as ACC_BALANCE,
	'SUB' AS place
FROM
	subheader_acc_view
	where subheader_acc_view.subHeader <> ''
	union all
	SELECT
	dept_acc_view.AccDepartmentNo as ACC_NO, 
	dept_acc_view.accDepartment as ACC_NAME, 
	dept_acc_view.BALANCE_DEPARTMENT as ACC_BALANCE,
	'DEPT' AS place
FROM
	dept_acc_view
	where dept_acc_view.accDepartment <> ''
	union all
	SELECT
	acc_view.accNo as ACC_NO, 
	acc_view.accountName as ACC_NAME, 
	acc_view.ACC_BALANCE as ACC_BALANCE,
	'ACC' AS place
FROM
	acc_view) as s
WHERE ACC_NO like @searchValue + '%'
	ORDER BY ACC_NO
END