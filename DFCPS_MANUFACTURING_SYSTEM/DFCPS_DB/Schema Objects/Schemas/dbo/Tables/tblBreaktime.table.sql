CREATE TABLE [dbo].[tblBreaktime] (
    [No]      INT           IDENTITY (1, 1) NOT NULL,
    [biono]   INT           NULL,
    [date]    DATETIME2 (7) NULL,
    [timeOut] DATETIME2 (7) NULL,
    [timeIn]  DATETIME2 (7) NULL,
    [late]    INT           NULL,
    [remarks] VARCHAR (255) NULL,
    [pair]    INT           NULL
);

