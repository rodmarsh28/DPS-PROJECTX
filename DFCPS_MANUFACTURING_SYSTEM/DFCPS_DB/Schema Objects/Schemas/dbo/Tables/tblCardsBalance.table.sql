CREATE TABLE [dbo].[tblCardsBalance] (
    [cardBalNo]     INT             NOT NULL,
    [cardID]        VARCHAR (255)   NULL,
    [dateOfBalance] DATETIME2 (7)   NULL,
    [balanceDebit]  DECIMAL (20, 2) NULL,
    [balanceCredit] DECIMAL (20, 2) NULL
);

