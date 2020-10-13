CREATE TABLE [dbo].[tblSalesDeliver] (
    [salesDeliverNo] VARCHAR (255)   NOT NULL,
    [transDate]      DATETIME2 (7)   NULL,
    [refNo]          VARCHAR (255)   NULL,
    [cardID]         VARCHAR (255)   NULL,
    [totalAmount]    DECIMAL (20, 2) NULL,
    [userID]         VARCHAR (255)   NULL,
    [status]         VARCHAR (255)   NULL,
    [notimesedit]    INT             NULL,
    [lastdateedit]   DATETIME2 (7)   NULL
);

