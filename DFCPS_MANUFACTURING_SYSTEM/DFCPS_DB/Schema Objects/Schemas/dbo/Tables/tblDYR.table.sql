CREATE TABLE [dbo].[tblDYR] (
    [DYNO]        VARCHAR (255)   NOT NULL,
    [dFrom]       DATETIME2 (7)   NULL,
    [dTo]         DATETIME2 (7)   NULL,
    [DOFFEDCOUNT] INT             NULL,
    [TOTALNETWT]  DECIMAL (20, 2) NULL,
    [OPERATOR]    VARCHAR (255)   NULL,
    [VISOR]       VARCHAR (255)   NULL,
    [REMARKS]     VARCHAR (255)   NULL,
    [timeStart]   DATETIME2 (7)   NULL,
    [timeEnd]     DATETIME2 (7)   NULL
);

