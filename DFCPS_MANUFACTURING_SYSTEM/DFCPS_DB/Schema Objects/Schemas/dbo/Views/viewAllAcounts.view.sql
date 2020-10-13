CREATE VIEW [dbo].[viewAllAcounts] AS SELECT
	dbo.tblCOA.accNo,
	dbo.tblAccHeader.accHeader,
	dbo.tblAccSubHeader.subHeader,
	dbo.tblAccDepartment.accDepartment,
	dbo.tblCOA.accountName 
FROM
	dbo.tblAccHeader
	INNER JOIN dbo.tblAccSubHeader ON dbo.tblAccHeader.accHeaderNo = dbo.tblAccSubHeader.accHeaderno
	INNER JOIN dbo.tblAccDepartment ON dbo.tblAccSubHeader.accSubHeaderNo = dbo.tblAccDepartment.accSubHeaderNo
	INNER JOIN dbo.tblCOA ON dbo.tblAccDepartment.AccDepartmentNo = dbo.tblCOA.accDepartmentNo