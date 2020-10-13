CREATE TABLE [dbo].[tblRecycleOutputTR] (
    [RROUTPUTNO]  INT             IDENTITY (1, 1) NOT NULL,
    [RRNO]        VARCHAR (255)   NULL,
    [OUTPUTNO]    INT             NULL,
    [ITEMCODE]    VARCHAR (255)   NULL,
    [TYPE]        VARCHAR (255)   NULL,
    [DESCRIPTION] VARCHAR (255)   NULL,
    [UNIT]        VARCHAR (255)   NULL,
    [WT]          DECIMAL (20, 2) NULL
);

