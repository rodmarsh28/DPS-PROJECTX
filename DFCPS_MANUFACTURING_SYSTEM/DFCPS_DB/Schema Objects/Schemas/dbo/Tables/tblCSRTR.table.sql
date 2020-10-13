CREATE TABLE [dbo].[tblCSRTR] (
    [CSRITEMNO]     INT             IDENTITY (1, 1) NOT NULL,
    [CSRNO]         VARCHAR (255)   NULL,
    [customer]      VARCHAR (255)   NULL,
    [rollNo]        VARCHAR (255)   NULL,
    [inputLength]   DECIMAL (20, 2) NULL,
    [outputQty]     DECIMAL (20, 2) NULL,
    [badLength]     DECIMAL (20, 2) NULL,
    [balanceLength] DECIMAL (20, 2) NULL,
    [timeStart]     VARCHAR (255)   NULL,
    [timeEnd]       VARCHAR (255)   NULL,
    [remarks]       VARCHAR (255)   NULL,
    [status]        VARCHAR (255)   NULL
);

