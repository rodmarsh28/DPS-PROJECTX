CREATE TABLE [dbo].[tblItemTransaction] (
    [dateTrans] DATETIME2 (7)   NULL,
    [refNo]     VARCHAR (255)   NULL,
    [src]       VARCHAR (255)   NULL,
    [itemNo]    VARCHAR (255)   NULL,
    [UNITCOST]  DECIMAL (20, 2) NULL,
    [qty]       DECIMAL (20)    NULL,
    [job]       VARCHAR (255)   NULL,
    [pc]        INT             NULL
);

