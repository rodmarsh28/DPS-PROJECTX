CREATE TABLE [dbo].[tempAccCosting] (
    [id]          INT           NOT NULL,
    [dateTrans]   DATETIME2 (7) NULL,
    [refNo]       VARCHAR (255) NULL,
    [card_emp_id] VARCHAR (255) NULL,
    [accno]       VARCHAR (255) NULL,
    [particulars] VARCHAR (255) NULL,
    [debit]       VARCHAR (255) NULL,
    [credit]      VARCHAR (255) NULL,
    [userid]      VARCHAR (255) NULL,
    [status]      VARCHAR (255) NULL
);

