CREATE VIEW [dbo].[get_Banklist] AS select bankID as ID , bankdesc as Description,accountname,accNo as Account_Asset_No,status,sum(balance) as balance
from(SELECT
dbo.tblBank.bankID,
dbo.tblBank.bankDesc,
dbo.tblBank.AccountName,
dbo.tblBank.accNo,
ISNULL(case when s.accno like '1%' or  s.accno like '5%' or s.accno like '6%' then
	sum(ts.debit) - sum(ts.credit)
	when s.accno like '2%' or  s.accno like '3%' or s.accno like '4%' then
	-sum(ts.debit) + sum(ts.credit)
	end ,0) AS balance,
dbo.tblBank.status

FROM
dbo.tblcoa AS s
INNER JOIN dbo.tblAccEntry AS ts ON s.accno= ts.accNo
INNER JOIN dbo.tblBank ON dbo.tblBank.accNo = ts.accNo

GROUP BY
s.accno,
dbo.tblBank.bankID,
dbo.tblBank.bankDesc,
dbo.tblBank.AccountName,
dbo.tblBank.accNo,
dbo.tblBank.status
union all
SELECT
dbo.tblBank.bankID,
dbo.tblBank.bankDesc,
dbo.tblBank.AccountName,
dbo.tblBank.accNo,
sum(cast(dbo.tblCheckTransaction.AMOUNT as decimal(20,2))),
dbo.tblBank.status

FROM
dbo.tblCheckTransaction
INNER JOIN dbo.tblCheckbook ON dbo.tblCheckTransaction.CHECKBOOKID = dbo.tblCheckbook.checkbookID
INNER JOIN dbo.tblBank ON dbo.tblCheckbook.bankID = dbo.tblBank.bankID
where tblCheckTransaction.status = 'Outstanding Check' and tblCheckTransaction.status <> 'Cancelled'
GROUP BY
dbo.tblBank.bankID,
dbo.tblBank.bankDesc,
dbo.tblBank.AccountName,
dbo.tblBank.accNo,
dbo.tblBank.status) as subt
GROUP BY
bankID , bankdesc,accountname,status,accNo