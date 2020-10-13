CREATE TABLE [dbo].[tblAdjustmentTR] (
    [ADJITEMNO] INT             IDENTITY (1, 1) NOT NULL,
    [ADJNO]     VARCHAR (255)   NULL,
    [WIDTH]     DECIMAL (20, 2) NULL,
    [LENGTH]    DECIMAL (20, 2) NULL,
    [COLOR]     VARCHAR (255)   NULL,
    [SEWNTYPE]  VARCHAR (255)   NULL,
    [PRINTED]   VARCHAR (255)   NULL,
    [QTY]       INT             NULL
);

