CREATE TABLE [dbo].[tblSpendMoney_Inv] (
    [spendMoneyNo] VARCHAR (255)   NULL,
    [itemNo]       INT             NULL,
    [unit]         VARCHAR (255)   NULL,
    [qty]          INT             NULL,
    [unitprice]    DECIMAL (20, 2) NULL,
    [discount]     DECIMAL (20, 2) NULL,
    [amount]       DECIMAL (20, 2) NULL
);

