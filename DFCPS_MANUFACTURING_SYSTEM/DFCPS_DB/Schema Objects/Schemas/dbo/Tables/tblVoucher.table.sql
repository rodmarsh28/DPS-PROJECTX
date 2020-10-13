CREATE TABLE [dbo].[tblVoucher] (
    [VoucherNo]    VARCHAR (255)   NOT NULL,
    [date]         DATETIME2 (7)   NULL,
    [ref]          VARCHAR (255)   NULL,
    [cardID]       VARCHAR (255)   NULL,
    [amount]       DECIMAL (20, 2) NULL,
    [remarks]      VARCHAR (255)   NULL,
    [userid]       VARCHAR (255)   NULL,
    [status]       VARCHAR (255)   NULL,
    [notimesedit]  INT             NULL,
    [lastdateedit] DATETIME2 (7)   NULL
);

