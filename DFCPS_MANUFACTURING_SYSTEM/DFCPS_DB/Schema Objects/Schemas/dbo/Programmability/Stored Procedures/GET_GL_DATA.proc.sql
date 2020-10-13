CREATE PROCEDURE [dbo].[GET_GL_DATA]
@DFROM AS DATETIME2,
@DTO AS DATETIME2,
@searchType as varchar(255)
as
BEGIN
if @searchType = 'All Accounts' begin
SELECT
dbo.tblCOA.accNo,
dbo.tblCOA.accountName,
a.refNo,
a.src,
a.dateTrans,
a.memo,
case when a.accno like '1%' or  a.accno like '5%' or a.accno like '6%' then
(select ISNULL((select sum (d.debit) - sum(d.credit) from tblAccEntry d where d.accno = a.accno and d.dateTrans < @dfrom), 0))
when a.accno like '2%' or  a.accno like '3%' or a.accno like '4%' then
(select ISNULL((select - + sum (d.debit) + sum(d.credit) from tblAccEntry d where d.accno = a.accno and d.dateTrans < @dfrom), 0))
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
RIGHT JOIN dbo.tblCOA ON a.accNo = dbo.tblCOA.accNo and a.datetrans between @dfrom and @dto
ORDER BY a.dateTrans asc

end

else if @searchType = 'Include in this list' begin
SELECT
dbo.tblCOA.accNo,
dbo.tblCOA.accountName,
a.refNo,
a.src,
a.dateTrans,
a.memo,
case when a.accno like '1%' or  a.accno like '5%' or a.accno like '6%' then
(select  sum(b.debit) - sum(b.credit) from dbo.tblAccEntry b where b.entryID <= a.entryID and b.accno = a.accno)
when a.accno like '2%' or  a.accno like '3%' or a.accno like '4%' then
(select  sum(b.credit) - sum(b.debit) from dbo.tblAccEntry b where b.entryID <= a.entryID and b.accno = a.accno) 
end
as BEGINNING_BALANCE,
ISNULL(a.debit,0) as debit,
ISNULL(a.credit,0) as credit,
case when a.accno like '1%' or  a.accno like '5%' or a.accno like '6%' then
(select ISNULL((select sum (d.debit) - sum(d.credit) from tblAccEntry d where d.accno = a.accno and d.dateTrans < @dfrom), 0) + sum(b.debit) - sum(b.credit) from dbo.tblAccEntry b where b.entryID <= a.entryID and b.accno = a.accno)
when a.accno like '2%' or  a.accno like '3%' or a.accno like '4%' then
(select ISNULL((select - + sum (d.debit) + sum(d.credit) from tblAccEntry d where d.accno = a.accno and d.dateTrans < @dfrom), 0) - sum(b.debit) + sum(b.credit) from dbo.tblAccEntry b where b.entryID <= a.entryID and b.accno = a.accno) 
end
as ENDING_BALANCE
FROM
dbo.tblAccEntry a
INNER JOIN dbo.tblCOA ON a.accNo = dbo.tblCOA.accNo 
INNER JOIN ACCOUNT_BALANCE c ON a.accNo = c.accNo 
where a.datetrans between @dfrom and @dto and a.accNo in (select accno from TEMPACCNOLIST)
order by a.dateTrans asc
end

else if @searchType = 'Except in this list' begin
SELECT
dbo.tblCOA.accNo,
dbo.tblCOA.accountName,
a.refNo,
a.src,
a.dateTrans,
a.memo,
case when a.accno like '1%' or  a.accno like '5%' or a.accno like '6%' then
(select ISNULL((select sum (d.debit) - sum(d.credit) from tblAccEntry d where d.accno = a.accno and d.dateTrans < @dfrom), 0))
when a.accno like '2%' or  a.accno like '3%' or a.accno like '4%' then
(select ISNULL((select - + sum (d.debit) + sum(d.credit) from tblAccEntry d where d.accno = a.accno and d.dateTrans < @dfrom), 0))
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
right  JOIN dbo.tblCOA ON a.accNo = dbo.tblCOA.accNo and a.datetrans between @dfrom and @dto and a.accNo  not in (select accno from TEMPACCNOLIST)
order by a.dateTrans asc
END
end