CREATE TABLE [dbo].[tblLeave] (
    [leaveNo]     VARCHAR (255)   COLLATE Latin1_General_CI_AS NOT NULL,
    [dateFilled]  DATETIME2 (7)   NULL,
    [employeeID]  VARCHAR (255)   COLLATE Latin1_General_CI_AS NULL,
    [leaveTypeID] INT             NULL,
    [reason]      VARCHAR (255)   COLLATE Latin1_General_CI_AS NULL,
    [dateFrom]    DATETIME2 (7)   NULL,
    [dateTo]      DATETIME2 (7)   NULL,
    [totalDays]   DECIMAL (20, 2) NULL,
    [withpay]     VARCHAR (255)   COLLATE Latin1_General_CI_AS NULL,
    [remarks]     VARCHAR (255)   COLLATE Latin1_General_CI_AS NULL
);

