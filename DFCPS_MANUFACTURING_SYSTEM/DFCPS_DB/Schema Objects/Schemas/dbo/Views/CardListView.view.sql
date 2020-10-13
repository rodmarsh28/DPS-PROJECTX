CREATE VIEW [dbo].[CardListView] AS SELECT
dbo.tblCardsProfile.cardID,
dbo.tblCardsProfile.cardName,
dbo.tblCardsProfile.cardCN,
dbo.tblCardsProfile.cardType,
ISNULL(SUM(dbo.tblCardsBalance.balanceDebit) - SUM(dbo.tblCardsBalance.balanceCredit),0) as  balance
FROM
dbo.tblCardsBalance
FULL OUTER JOIN dbo.tblCardsProfile ON dbo.tblCardsProfile.cardID = dbo.tblCardsBalance.cardID
GROUP BY
dbo.tblCardsProfile.cardID,
dbo.tblCardsProfile.cardName,
dbo.tblCardsProfile.cardAddress,
dbo.tblCardsProfile.cardCN,
dbo.tblCardsProfile.cardType