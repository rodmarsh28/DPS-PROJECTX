CREATE TABLE [dbo].[tblAttendance] (
    [ATTNO]           INT             IDENTITY (1, 1) NOT NULL,
    [BIONO]           INT             NULL,
    [ATTDATE]         DATETIME2 (7)   NULL,
    [AM_IN]           DATETIME2 (7)   NULL,
    [AM_OUT]          DATETIME2 (7)   NULL,
    [PM_IN]           DATETIME2 (7)   NULL,
    [PM_OUT]          DATETIME2 (7)   NULL,
    [NOOFWORKEDHOURS] DECIMAL (18)    NULL,
    [LATE_MINS]       DECIMAL (20, 2) NULL
);

