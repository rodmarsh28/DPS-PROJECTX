CREATE TABLE [dbo].[tblStockOutTR] (
    [STOITEMNO] INT             IDENTITY (1, 1) NOT NULL,
    [STONO]     VARCHAR (255)   NULL,
    [WIDTH]     DECIMAL (20, 2) NULL,
    [BAGLENTH]  DECIMAL (20, 2) NULL,
    [COLOR]     VARCHAR (255)   NULL,
    [SEWNTYPE]  VARCHAR (255)   NULL,
    [PRINTED]   VARCHAR (255)   NULL,
    [QTY]       INT             NULL
);

