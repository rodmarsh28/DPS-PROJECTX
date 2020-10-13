CREATE TABLE [dbo].[tblPaymentsReceived] (
    [paymentNo]        VARCHAR (255)   NOT NULL,
    [dateOfPayment]    DATETIME2 (7)   NULL,
    [cardID]           VARCHAR (255)   NULL,
    [paymentMethod]    VARCHAR (255)   NULL,
    [outOFBalance]     DECIMAL (20, 2) NULL,
    [overAllBalance]   DECIMAL (20, 2) NULL,
    [amountReceived]   DECIMAL (20, 2) NULL,
    [invoiceNo]        VARCHAR (255)   NULL,
    [amountDiscount]   DECIMAL (20, 2) NULL,
    [amountApplied]    DECIMAL (20, 2) NULL,
    [depositToAccount] VARCHAR (255)   NULL,
    [userID]           VARCHAR (255)   NULL
);

