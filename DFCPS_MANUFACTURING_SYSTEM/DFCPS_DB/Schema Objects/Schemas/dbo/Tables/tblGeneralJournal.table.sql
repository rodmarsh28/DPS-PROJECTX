CREATE TABLE [dbo].[tblGeneralJournal] (
    [GJNO]         VARCHAR (255) NOT NULL,
    [datetrans]    DATETIME2 (7) NULL,
    [cardID]       VARCHAR (255) NULL,
    [status]       VARCHAR (255) NULL,
    [notimesedit]  INT           NULL,
    [lastdateedit] DATETIME2 (7) NULL
);

