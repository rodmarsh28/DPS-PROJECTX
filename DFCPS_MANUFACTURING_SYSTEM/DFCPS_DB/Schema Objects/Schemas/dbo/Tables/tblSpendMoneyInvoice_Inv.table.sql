CREATE TABLE [dbo].[tblSpendMoneyInvoice_Inv] (
    [spendMoneyInvoiceNo] INT             NULL,
    [itemNo]              VARCHAR (255)   NULL,
    [unit]                VARCHAR (255)   NULL,
    [qty]                 INT             NULL,
    [unitprice]           DECIMAL (20, 2) NULL,
    [discount]            DECIMAL (20, 2) NULL,
    [amount]              DECIMAL (20, 2) NULL
);

