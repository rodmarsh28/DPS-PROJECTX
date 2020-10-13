CREATE VIEW [dbo].[subheader_acc_view] AS SELECT
		tblAccSubHeader.accSubHeaderNo,
		tblAccSubHeader.accHeaderNo,
		tblAccSubHeader.subHeader,
		ISNULL(SUM ( balance ), 0) AS SUBHEADER_BALANCE 
	FROM
		(
		SELECT
			tblAccDepartment.AccDepartmentNo,
			accSubHeaderNo,
			accDepartment,
			SUM ( balance ) AS balance 
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
		) AS c
		RIGHT JOIN tblAccSubHeader ON tblAccSubHeader.accSubHeaderNo = c.accSubHeaderNo 
	GROUP BY
		tblAccSubHeader.accSubHeaderNo,
		tblAccSubHeader.accHeaderNo,
		tblAccSubHeader.subHeader