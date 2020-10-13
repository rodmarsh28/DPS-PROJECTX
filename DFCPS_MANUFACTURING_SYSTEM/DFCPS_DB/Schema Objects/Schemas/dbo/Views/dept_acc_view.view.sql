CREATE VIEW [dbo].[dept_acc_view] AS SELECT
			tblAccDepartment.AccDepartmentNo,
			accSubHeaderNo,
			accDepartment,
			ISNULL(SUM ( balance ), 0) AS BALANCE_DEPARTMENT 
		FROM
			(
			SELECT
				tblCOA.accNo,
				tblCOA.accDepartmentNo,
				tblCOA.accountName,
				SUM ( tblAccEntry.debit- tblAccEntry.credit ) AS BALANCE 
			FROM
				tblCOA
				RIGHT JOIN tblAccEntry ON tblCOA.accNo = tblAccEntry.accNo 
			GROUP BY
				tblCOA.accNo,
				tblCOA.accDepartmentNo,
				tblCOA.accountName 
			) AS d
			RIGHT JOIN tblAccDepartment ON tblAccDepartment.AccDepartmentNo = d.AccDepartmentNo 
		GROUP BY
			tblAccDepartment.AccDepartmentNo,
			accSubHeaderNo,
			accDepartment