CREATE TABLE [dbo].[tblPayable] (
    [PaymentbillNo] INT             IDENTITY (1, 1) NOT NULL,
    [refNo]         VARCHAR (255)   NULL,
    [src]           VARCHAR (255)   NULL,
    [payment]       VARCHAR (255)   NULL,
    [dueDate]       DATETIME2 (7)   NULL,
    [amount]        DECIMAL (20, 2) NULL,
    [status]        VARCHAR (255)   NULL
);

