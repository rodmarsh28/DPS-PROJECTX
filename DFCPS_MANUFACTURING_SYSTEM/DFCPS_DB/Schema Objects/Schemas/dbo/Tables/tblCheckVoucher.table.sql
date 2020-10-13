CREATE TABLE [dbo].[tblCheckVoucher] (
    [checkVoucherNo]   VARCHAR (255)   NOT NULL,
    [refNo]            VARCHAR (255)   NULL,
    [date_transaction] DATETIME2 (7)   NULL,
    [type]             VARCHAR (255)   NULL,
    [tinNo]            VARCHAR (255)   NULL,
    [cardID]           VARCHAR (255)   NULL,
    [address]          VARCHAR (255)   NULL,
    [totalAmount]      DECIMAL (20, 2) NULL,
    [amountInwords]    VARCHAR (255)   NULL,
    [remarks]          VARCHAR (255)   NULL,
    [userid]           VARCHAR (255)   NULL,
    [status]           VARCHAR (255)   NULL,
    [notimesedit]      INT             NULL,
    [lastdateedit]     DATETIME2 (7)   NULL
);

