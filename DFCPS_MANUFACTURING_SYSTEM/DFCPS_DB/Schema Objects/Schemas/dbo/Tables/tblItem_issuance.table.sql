CREATE TABLE [dbo].[tblItem_issuance] (
    [issuanceNo]      VARCHAR (255)   NOT NULL,
    [refNo]           VARCHAR (255)   NULL,
    [transDate]       DATETIME2 (7)   NULL,
    [totalItemCount]  VARCHAR (255)   NULL,
    [totalCost]       DECIMAL (20, 2) NULL,
    [chargeToAccount] VARCHAR (255)   NULL,
    [userID]          VARCHAR (255)   NULL,
    [status]          VARCHAR (255)   NULL,
    [notimesedit]     INT             NULL,
    [lastdateedit]    DATETIME2 (7)   NULL
);

