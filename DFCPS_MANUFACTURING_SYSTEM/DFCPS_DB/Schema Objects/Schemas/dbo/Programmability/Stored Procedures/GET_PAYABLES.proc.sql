CREATE PROCEDURE [dbo].[GET_PAYABLES]
@SEARCHVALUE AS VARCHAR(255)
AS
BEGIN
SELECT CONVERT(VARCHAR,dbo.tblAccEntry.dateTrans,111) AS DATE,
dbo.tblAccEntry.refNo AS [NO],
dbo.tblAccEntry.memo AS MEMO,
dbo.tblAccEntry.credit - dbo.tblAccEntry.DEBIT as AMOUNT
FROM
dbo.tblAccEntry
WHERE ACCNO IN (select accNo from tblArPrSettings where TYPE = 'AP') AND CREDIT > DEBIT AND REFNO LIKE '%'+ @SEARCHVALUE + '%'
END