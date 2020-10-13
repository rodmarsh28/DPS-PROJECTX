CREATE TABLE [dbo].[tblAccEntry] (
    [entryID]   INT             IDENTITY (1, 1) NOT NULL,
    [dateTrans] DATETIME2 (7)   NULL,
    [refNo]     VARCHAR (255)   NULL,
    [src]       VARCHAR (255)   NULL,
    [accNo]     VARCHAR (255)   NULL,
    [memo]      VARCHAR (255)   NULL,
    [debit]     DECIMAL (20, 2) NULL,
    [credit]    DECIMAL (20, 2) NULL,
    [userID]    VARCHAR (255)   NULL,
    [job]       VARCHAR (255)   NULL,
    [cardID]    VARCHAR (255)   NULL
);

