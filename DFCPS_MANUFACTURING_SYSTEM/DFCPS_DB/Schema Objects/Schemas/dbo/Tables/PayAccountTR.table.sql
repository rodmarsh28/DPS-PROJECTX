CREATE TABLE [dbo].[PayAccountTR] (
    [No]            VARCHAR (255)   NOT NULL,
    [refNo]         VARCHAR (255)   NULL,
    [amount]        DECIMAL (20, 2) NULL,
    [discount]      DECIMAL (20, 2) NULL,
    [amountOwed]    DECIMAL (20, 2) NULL,
    [amountApplied] DECIMAL (20, 2) NULL
);

