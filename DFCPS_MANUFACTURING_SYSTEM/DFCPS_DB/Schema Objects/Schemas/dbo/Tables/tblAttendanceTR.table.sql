CREATE TABLE [dbo].[tblAttendanceTR] (
    [ATTNO]     INT           IDENTITY (1, 1) NOT NULL,
    [BIONO]     INT           NULL,
    [CHECKTIME] DATETIME2 (7) NULL,
    [CHECKTYPE] VARCHAR (255) NULL
);

