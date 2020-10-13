CREATE VIEW [dbo].[LEDGER_VIEW] AS SELECT
dbo.tblCOA.accNo,
dbo.tblCOA.accountName,
a.refNo,
a.src,
a.dateTrans,
a.memo,
case when a.accno like '1%' or  a.accno like '5%' or a.accno like '6%' then
(select ISNULL((select sum (d.debit) - sum(d.credit) from tblAccEntry d where d.accno = a.accno ), 0))
when a.accno like '2%' or  a.accno like '3%' or a.accno like '4%' then
(select ISNULL((select - + sum (d.debit) + sum(d.credit) from tblAccEntry d where d.accno = a.accno ), 0))
end
as BEGINNING_BALANCE,
ISNULL(a.debit,0) as debit,
ISNULL(a.credit,0) as credit,
case when a.accno like '1%' or  a.accno like '5%' or a.accno like '6%' then
(select  sum(b.debit) - sum(b.credit) from dbo.tblAccEntry b where b.entryID <= a.entryID and b.accno = a.accno)
when a.accno like '2%' or  a.accno like '3%' or a.accno like '4%' then
(select  sum(b.credit) - sum(b.debit) from dbo.tblAccEntry b where b.entryID <= a.entryID and b.accno = a.accno) 
end
as ENDING_BALANCE
FROM
dbo.tblAccEntry a
RIGHT JOIN dbo.tblCOA ON a.accNo = dbo.tblCOA.accNo