CREATE TABLE [dbo].[tblSpendMoneyInvoice_Serv] (
    [spendMoneyInvoiceNo] INT             NULL,
    [description]         VARCHAR (255)   NULL,
    [accNo]               VARCHAR (255)   NULL,
    [memo]                VARCHAR (255)   NULL,
    [amount]              DECIMAL (20, 2) NULL,
    [debit]               DECIMAL (20, 2) NULL,
    [credit]              DECIMAL (20, 2) NULL
);

