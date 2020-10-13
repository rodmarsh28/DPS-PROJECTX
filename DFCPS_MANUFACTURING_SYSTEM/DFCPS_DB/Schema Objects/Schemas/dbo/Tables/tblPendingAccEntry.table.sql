CREATE TABLE [dbo].[tblPendingAccEntry] (
    [ID]     INT             IDENTITY (1, 1) NOT NULL,
    [refno]  VARCHAR (255)   NOT NULL,
    [accno]  VARCHAR (255)   NULL,
    [memo]   VARCHAR (255)   NULL,
    [debit]  DECIMAL (20, 2) NULL,
    [credit] DECIMAL (20, 2) NULL,
    [status] VARCHAR (255)   NULL
);

