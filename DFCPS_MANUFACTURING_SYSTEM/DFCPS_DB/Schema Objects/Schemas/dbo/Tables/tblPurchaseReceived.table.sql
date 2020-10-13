CREATE TABLE [dbo].[tblPurchaseReceived] (
    [purchaseReceivingNo] VARCHAR (255)   NOT NULL,
    [transDate]           DATETIME2 (7)   NULL,
    [refNo]               VARCHAR (255)   NULL,
    [invoiceNo]           VARCHAR (255)   NULL,
    [cardID]              VARCHAR (255)   NULL,
    [itemNo]              VARCHAR (255)   NULL,
    [qty]                 VARCHAR (255)   NULL,
    [uprice]              DECIMAL (20, 2) NULL,
    [amount]              VARCHAR (255)   NULL,
    [vat]                 DECIMAL (20, 2) NULL,
    [vatexempt]           INT             NULL,
    [userID]              VARCHAR (255)   NULL,
    [status]              VARCHAR (255)   NULL,
    [notimesedit]         INT             NULL,
    [lastdateedit]        DATETIME2 (7)   NULL
);

