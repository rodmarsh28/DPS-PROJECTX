CREATE TABLE [dbo].[tblRollPrintingTR] (
    [PRINTINGNO] INT             IDENTITY (1, 1) NOT NULL,
    [PRNO]       VARCHAR (255)   NULL,
    [CUSTOMER]   VARCHAR (255)   NULL,
    [MESH]       VARCHAR (255)   NULL,
    [ROLLNO]     VARCHAR (255)   NULL,
    [LOOMNO]     VARCHAR (255)   NULL,
    [WIDTH]      VARCHAR (255)   NULL,
    [COLOR]      VARCHAR (255)   NULL,
    [INPUTL]     DECIMAL (18, 2) NULL,
    [INPUTWT]    DECIMAL (18, 2) NULL,
    [OUTPUTL]    DECIMAL (18, 2) NULL,
    [OUTPUTW]    DECIMAL (18, 2) NULL,
    [INKCONS]    DECIMAL (18, 1) NULL
);

