CREATE VIEW [dbo].[general_acc_view] AS SELECT
	header_acc_view.accHeaderNo, 
	header_acc_view.accHeader, 
	header_acc_view.Header_Balance, 
	subheader_acc_view.subHeader, 
	subheader_acc_view.SUBHEADER_BALANCE, 
	subheader_acc_view.accSubHeaderNo, 
	dept_acc_view.AccDepartmentNo, 
	dept_acc_view.accDepartment, 
	dept_acc_view.BALANCE_DEPARTMENT, 
	acc_view.accNo, 
	acc_view.accountName, 
	acc_view.ACC_BALANCE
FROM
	header_acc_view
	INNER JOIN
	subheader_acc_view
	ON 
		header_acc_view.accHeaderNo = subheader_acc_view.accHeaderNo
	INNER JOIN
	dept_acc_view
	ON 
		subheader_acc_view.accSubHeaderNo = dept_acc_view.accSubHeaderNo
	INNER JOIN
	acc_view
	ON 
		dept_acc_view.AccDepartmentNo = acc_view.accDepartmentNo