CREATE VIEW [dbo].[header_acc_view] AS SELECT
	tblAccHeader.accHeaderNo,
	tblAccHeader.accHeader,
	ISNULL(SUM ( balance ), 0) AS Header_Balance
FROM
	(
	SELECT
		tblAccSubHeader.accSubHeaderNo,
		tblAccSubHeader.accHeaderNo,
		tblAccSubHeader.subHeader,
		SUM ( balance ) AS BALANCE 
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
	) AS b
	RIGHT JOIN tblAccHeader ON tblAccHeader.accHeaderNo = b.accHeaderNo 
GROUP BY
	tblAccHeader.accHeaderNo,
	tblAccHeader.accHeader