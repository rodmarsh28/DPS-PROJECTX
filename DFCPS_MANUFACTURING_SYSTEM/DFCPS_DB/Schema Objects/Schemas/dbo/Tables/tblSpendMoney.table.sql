CREATE TABLE [dbo].[tblSpendMoney] (
    [spendMoneyNo] VARCHAR (255)   NOT NULL,
    [date_trans]   DATETIME2 (7)   NULL,
    [refNo]        VARCHAR (255)   NULL,
    [cardID]       VARCHAR (255)   NULL,
    [totalAmount]  DECIMAL (20, 2) NULL,
    [userID]       VARCHAR (255)   NULL,
    [status]       VARCHAR (255)   NULL
);

