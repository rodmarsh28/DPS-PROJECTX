CREATE TABLE [dbo].[tblReceivedTR] (
    [RITEMNO]   INT             IDENTITY (1, 1) NOT NULL,
    [RCODE]     VARCHAR (255)   NULL,
    [ITEMCODE]  VARCHAR (255)   NULL,
    [RMT]       VARCHAR (255)   NULL,
    [RMC]       VARCHAR (255)   NULL,
    [UNIT]      VARCHAR (255)   NULL,
    [QTY]       INT             NULL,
    [UNITPRICE] DECIMAL (20, 2) NULL,
    [AMOUNT]    DECIMAL (20, 2) NULL
);

