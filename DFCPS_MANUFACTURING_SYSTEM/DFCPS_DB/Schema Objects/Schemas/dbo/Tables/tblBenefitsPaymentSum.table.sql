CREATE TABLE [dbo].[tblBenefitsPaymentSum] (
    [premsID]           INT          IDENTITY (1, 1) NOT NULL,
    [payrollID]         VARCHAR (50) COLLATE Latin1_General_CI_AS NULL,
    [empPayrollTransNo] INT          NULL,
    [erSSS]             MONEY        NULL,
    [erPI]              MONEY        NULL,
    [erPH]              MONEY        NULL
);

