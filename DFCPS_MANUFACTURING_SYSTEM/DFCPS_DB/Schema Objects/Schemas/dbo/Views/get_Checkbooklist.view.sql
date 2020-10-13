CREATE VIEW [dbo].[get_Checkbooklist] AS SELECT
dbo.tblCheckbook.checkbookID AS Checkbook_ID,
dbo.tblBank.bankID AS Bank_ID,
dbo.tblBank.bankDesc AS Bank_Description,
dbo.tblCheckbook.startCheckNo AS Checkno_Start,
dbo.tblCheckbook.endCheckNo AS Checkno_End,
dbo.tblCheckbook.lastCheckNoUsed AS Checkno_LastUsed,
dbo.tblCheckbook.date_registered AS Date_Registered,
dbo.tblCheckbook.status AS Status,
dbo.tblBank.accNo

FROM
dbo.tblCheckbook
INNER JOIN dbo.tblBank ON dbo.tblCheckbook.bankID = dbo.tblBank.bankID