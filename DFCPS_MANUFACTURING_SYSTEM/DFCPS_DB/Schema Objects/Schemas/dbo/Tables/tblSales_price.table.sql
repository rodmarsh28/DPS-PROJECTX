CREATE TABLE [dbo].[tblSales_price] (
    [price_id] INT             IDENTITY (1, 1) NOT NULL,
    [itemcode] VARCHAR (255)   NULL,
    [price]    DECIMAL (20, 2) NULL,
    [date_set] DATETIME2 (0)   NULL,
    [ref]      VARCHAR (255)   NULL
);

