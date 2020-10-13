CREATE VIEW [dbo].[ACCOUNT_BALANCE] AS SELECT
	s.accNo,
	s.accountName,
	ISNULL(case when s.accno like '1%' or  s.accno like '5%' or s.accno like '6%' then
	sum(ts.debit) - sum(ts.credit)
	when s.accno like '2%' or  s.accno like '3%' or s.accno like '4%' then
	-sum(ts.debit) + sum(ts.credit)
	end ,0)
	as balance
FROM
	tblcoa s
	LEFT JOIN tblAccEntry ts ON s.accno = ts.accno 
GROUP BY
	s.accNo,
	s.accountName