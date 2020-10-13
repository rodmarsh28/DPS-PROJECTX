CREATE TABLE [dbo].[tblCheckbook] (
    [checkbookID]     VARCHAR (255) NOT NULL,
    [bankID]          VARCHAR (255) NULL,
    [startCheckNo]    VARCHAR (255) NULL,
    [endCheckNo]      VARCHAR (255) NULL,
    [lastCheckNoUsed] VARCHAR (255) NULL,
    [date_registered] DATETIME2 (7) NULL,
    [status]          VARCHAR (255) NULL,
    [notimesedit]     INT           NULL,
    [lastdateedit]    DATETIME2 (7) NULL
);


GO
ALTER TABLE [dbo].[tblCheckbook] SET (LOCK_ESCALATION = AUTO);

