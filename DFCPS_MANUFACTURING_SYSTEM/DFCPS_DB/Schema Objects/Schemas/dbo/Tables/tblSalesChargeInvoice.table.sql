CREATE TABLE [dbo].[tblSalesChargeInvoice] (
    [salesChargeInvoiceNo] VARCHAR (255)   NOT NULL,
    [transDate]            DATETIME2 (7)   NULL,
    [refNo]                VARCHAR (255)   NULL,
    [cardID]               VARCHAR (255)   NULL,
    [totalFullAmount]      DECIMAL (20, 2) NULL,
    [totalDiscount]        DECIMAL (20, 2) NULL,
    [totalAmount]          DECIMAL (20, 2) NULL,
    [userID]               VARCHAR (255)   NULL,
    [status]               VARCHAR (255)   NULL,
    [notimesedit]          INT             NULL,
    [lastdateedit]         DATETIME2 (7)   NULL
);

