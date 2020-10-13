CREATE PROCEDURE [dbo].[get_invoice_list] @searchValue VARCHAR(255),
@recvaccNo  varchar(255)
AS
BEGIN
select cardid,invoice_no,transdate,amount,case
	when amnt_Discount< 0 then
	0
	else
	amnt_Discount
end as amnt_Discount,Amnt_Paid
from
(SELECT subt.CARDID,subt.refNo as INVOICE_NO,C.transDate,
sum(subt.amount) as amount,c.totalDiscount - ISNULL(sum(subt.Amnt_Discount), 0) as amnt_Discount, ISNULL(sum(subt.Amnt_Paid), 0) as Amnt_Paid, sum(subt.amount)-sum(subt.Amnt_Paid) as Amnt_Bal
from(
SELECT
	tblAccEntry.cardID as CARDID,
	tblAccEntry.refno,
	tblAccEntry.dateTrans AS DATETR,
	tblAccEntry.debit as amount,
	0 as Amnt_Discount,
	0 as Amnt_Paid
from
	dbo.tblAccEntry
	WHERE  tblAccEntry.accNo = @recvaccNo and tblAccEntry.debit > 0
union all
SELECT
	tblAccEntry.cardID as CARDID,
	tblAccEntry.src AS refno,
	tblAccEntry.dateTrans AS DATETR,
	0 as amount,
	tblAccEntry.debit as Amnt_Discount,
	0 as Amnt_Paid
from
	dbo.tblAccEntry
	WHERE    tblAccEntry.debit > 0 and tblAccEntry.memo like 'Discount%'
union all
SELECT
	tblAccEntry.cardID as CARDID,
	tblAccEntry.src AS refno,
	tblAccEntry.dateTrans AS DATETR,
	0 as amount,
	0 as Amnt_Discount,
  tblAccEntry.credit as Amnt_Paid

from
	dbo.tblAccEntry
	WHERE   tblAccEntry.accNo = @recvaccNo and tblAccEntry.credit > 0
) as subt
 RIGHT JOIN tblSalesChargeInvoice as c on c.salesChargeInvoiceNo = subt.refno
 
group by
subt.CARDID,subt.refNo,c.transDate,c.totalDiscount
union all
SELECT subt.CARDID,subt.refNo as INVOICE_NO,C.transDate,
sum(subt.amount) as amount,c.totalDiscount - ISNULL(sum(subt.Amnt_Discount), 0) as amnt_Discount, ISNULL(sum(subt.Amnt_Paid), 0) as Amnt_Paid, sum(subt.amount)-sum(subt.Amnt_Paid) as Amnt_Bal
from(
SELECT
	tblAccEntry.cardID as CARDID,
	tblAccEntry.refno,
	tblAccEntry.dateTrans AS DATETR,
	tblAccEntry.debit as amount,
	0 as Amnt_Discount,
	0 as Amnt_Paid
from
	dbo.tblAccEntry
	WHERE  tblAccEntry.accNo = @recvaccNo and tblAccEntry.debit > 0
union all
SELECT
	tblAccEntry.cardID as CARDID,
	tblAccEntry.src AS refno,
	tblAccEntry.dateTrans AS DATETR,
	0 as amount,
	tblAccEntry.debit as Amnt_Discount,
	0 as Amnt_Paid
from
	dbo.tblAccEntry
	WHERE    tblAccEntry.debit > 0 and tblAccEntry.memo like 'Discount%'
union all
SELECT
	tblAccEntry.cardID as CARDID,
	tblAccEntry.src AS refno,
	tblAccEntry.dateTrans AS DATETR,
	0 as amount,
	0 as Amnt_Discount,
  tblAccEntry.credit as Amnt_Paid

from
	dbo.tblAccEntry
	WHERE   tblAccEntry.accNo = @recvaccNo and tblAccEntry.credit > 0
) as subt
 RIGHT JOIN tblSalesCashInvoice as c on c.salesCashInvoiceNo = subt.refno
 
group by
subt.CARDID,subt.refNo,c.transDate,c.totalDiscount) as s
where CARDID like '%'+ @searchValue + '%'
END