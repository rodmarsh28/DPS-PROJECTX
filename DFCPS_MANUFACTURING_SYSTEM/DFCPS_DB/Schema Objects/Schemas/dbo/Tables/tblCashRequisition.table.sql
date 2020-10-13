CREATE TABLE [dbo].[tblCashRequisition] (
    [CRSNO]              VARCHAR (255)   NOT NULL,
    [TRANSDATE]          DATETIME2 (7)   NULL,
    [CARDID]             VARCHAR (255)   NULL,
    [particulars]        VARCHAR (255)   NULL,
    [amount]             DECIMAL (20, 2) NULL,
    [amountApplied]      DECIMAL (20, 2) NULL,
    [REMARKS]            VARCHAR (255)   NULL,
    [TOTALAMOUNT]        DECIMAL (20, 2) NULL,
    [TOTALAMOUNTAPPLIED] DECIMAL (20, 2) NULL,
    [userid]             VARCHAR (255)   NULL,
    [status]             VARCHAR (255)   NULL,
    [notimesedit]        INT             NULL,
    [lastdateedit]       DATETIME2 (7)   NULL
);

