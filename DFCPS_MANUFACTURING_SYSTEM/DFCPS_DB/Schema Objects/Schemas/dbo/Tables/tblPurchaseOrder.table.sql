CREATE TABLE [dbo].[tblPurchaseOrder] (
    [purchaseOrderNo] VARCHAR (255)   NOT NULL,
    [transDate]       DATETIME2 (7)   NULL,
    [refNo]           VARCHAR (255)   NULL,
    [cardID]          VARCHAR (255)   NULL,
    [userID]          VARCHAR (255)   NULL,
    [itemNo]          VARCHAR (255)   NULL,
    [qty]             INT             NULL,
    [uprice]          DECIMAL (20, 2) NULL,
    [amount]          DECIMAL (20, 2) NULL,
    [tax]             DECIMAL (20, 2) NULL,
    [status]          VARCHAR (255)   NULL,
    [notimesedit]     INT             NULL,
    [lastdateedit]    DATETIME2 (7)   NULL
);

