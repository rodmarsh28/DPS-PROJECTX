CREATE TABLE [dbo].[tblDTRrecord] (
    [dtrRecordNo]      INT             NOT NULL,
    [dtrDate]          DATETIME2 (7)   NULL,
    [empID]            VARCHAR (255)   COLLATE Latin1_General_CI_AS NULL,
    [workedHours]      DECIMAL (20, 2) NULL,
    [absentHours]      DECIMAL (20, 2) NULL,
    [rhCounted]        DECIMAL (20, 2) NULL,
    [nwhCounted]       DECIMAL (20, 2) NULL,
    [rhHoursReported]  DECIMAL (20, 2) NULL,
    [nwhHoursReported] DECIMAL (20, 2) NULL,
    [otHours]          DECIMAL (20, 2) NULL,
    [otnHours]         DECIMAL (20, 2) NULL,
    [rdrHours]         DECIMAL (20, 2) NULL,
    [lateUtMins]       DECIMAL (20, 2) NULL,
    [remarks]          VARCHAR (255)   NULL,
    [userid]           INT             NULL
);

