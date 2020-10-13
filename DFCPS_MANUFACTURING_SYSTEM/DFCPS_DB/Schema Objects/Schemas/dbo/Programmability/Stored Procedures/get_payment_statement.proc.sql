CREATE PROCEDURE [dbo].[get_payment_statement]
AS
BEGIN

select CARDID,DATETR AS TRANSACTION_DATE,REFNO AS TRANSACTION_NO, MEMO,AMOUNT,AMNT_PAID

FROM
(SELECT
	tblAccEntry.entryID,
	tblAccEntry.cardID as CARDID,
	tblAccEntry.refno,
	tblAccEntry.dateTrans AS DATETR,
	tblAccEntry.memo AS memo,
	tblAccEntry.debit-[Sales Invoice].totalDiscount as amount,
	0 as Amnt_Paid
from
	dbo.tblAccEntry INNER JOIN [Sales Invoice] on [Sales Invoice].[No] = tblAccEntry.refNo
	WHERE  tblAccEntry.memo like 'Receivable%' and tblAccEntry.debit > 0
union all
SELECT
	tblAccEntry.entryID,
	tblAccEntry.cardID as CARDID,
	tblAccEntry.refNo AS refno,
	tblAccEntry.dateTrans AS DATETR,
	tblAccEntry.memo AS memo,
	-+tblAccEntry.debit as amount,
	0 as Amnt_Paid
from
	dbo.tblAccEntry
	WHERE tblAccEntry.debit > 0 and tblAccEntry.memo like 'Discount%'
	union all
SELECT
	tblAccEntry.entryID,
	tblAccEntry.cardID as CARDID,
	tblAccEntry.refNo AS refno,
	tblAccEntry.dateTrans AS DATETR,
	tblAccEntry.memo AS memo,
	0 as amount,
  tblAccEntry.debit as Amnt_Paid
from
	dbo.tblAccEntry
	WHERE  tblAccEntry.memo like 'Amount Received%' and tblAccEntry.debit > 0 ) AS S
order by entryID
	
END