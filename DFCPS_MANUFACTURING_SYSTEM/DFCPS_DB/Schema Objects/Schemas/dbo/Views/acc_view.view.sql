CREATE VIEW [dbo].[acc_view] AS SELECT
				tblCOA.accNo,
				tblCOA.accDepartmentNo,
				tblCOA.accountName,
				ISNULL(SUM ( tblAccEntry.debit- tblAccEntry.credit ), 0) AS ACC_BALANCE 
			FROM
				tblCOA
				LEFT JOIN tblAccEntry ON tblCOA.accNo = tblAccEntry.accNo 
			GROUP BY
				tblCOA.accNo,
				tblCOA.accDepartmentNo,
				tblCOA.accountName