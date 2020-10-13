CREATE TABLE [dbo].[General Journal] (
    [GJNO]        VARCHAR (255) NOT NULL,
    [date]        DATETIME2 (7) NULL,
    [refNo]       VARCHAR (255) NULL,
    [cardID]      VARCHAR (255) NULL,
    [memo]        VARCHAR (255) NULL,
    [totalDebit]  VARCHAR (255) NULL,
    [totalCredit] VARCHAR (255) NULL,
    [remarks]     VARCHAR (255) NULL,
    [status]      VARCHAR (255) NULL
);

