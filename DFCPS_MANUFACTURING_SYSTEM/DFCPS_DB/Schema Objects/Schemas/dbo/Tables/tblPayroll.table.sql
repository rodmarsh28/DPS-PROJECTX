CREATE TABLE [dbo].[tblPayroll] (
    [payrollID]      VARCHAR (255) COLLATE Latin1_General_CI_AS NOT NULL,
    [dateCreated]    DATETIME2 (7) NULL,
    [dateFrom]       DATETIME2 (7) NULL,
    [dateTo]         DATETIME2 (7) NULL,
    [totalEmployees] INT           NULL,
    [totalOvertime]  MONEY         NULL,
    [totalGrossPay]  MONEY         NULL,
    [totalDeduction] MONEY         NULL,
    [totalNetpay]    MONEY         NULL,
    [preparedBy]     VARCHAR (255) COLLATE Latin1_General_CI_AS NULL,
    [remarks]        VARCHAR (255) COLLATE Latin1_General_CI_AS NULL
);

