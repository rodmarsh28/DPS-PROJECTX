CREATE TABLE [dbo].[tblManualPrintingTR] (
    [PRINTMANUALNO] INT             IDENTITY (1, 1) NOT NULL,
    [PRNO]          VARCHAR (255)   NULL,
    [CUSTOMER]      VARCHAR (255)   NULL,
    [MESH]          VARCHAR (255)   NULL,
    [ROLLNO]        VARCHAR (255)   NULL,
    [WIDTH]         VARCHAR (255)   NULL,
    [BAGL]          DECIMAL (20, 2) NULL,
    [BAGCOLOR]      VARCHAR (255)   NULL,
    [SEWNTYPE]      VARCHAR (255)   NULL,
    [INPUTQTY]      INT             NULL,
    [DEFECT]        INT             NULL,
    [DEFECTWT]      DECIMAL (20, 1) NULL,
    [OUTPUTQTY]     INT             NULL,
    [INKCONS]       DECIMAL (18, 1) NULL
);

