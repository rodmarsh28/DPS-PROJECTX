CREATE TABLE [dbo].[tblDesciplinaryAction] (
    [descActionNo]       VARCHAR (255) COLLATE Latin1_General_CI_AS NOT NULL,
    [date]               DATETIME2 (7) NULL,
    [employeeID]         VARCHAR (255) COLLATE Latin1_General_CI_AS NULL,
    [infractionID]       INT           NULL,
    [specOffenseID]      INT           NULL,
    [OffenseID]          INT           NULL,
    [occurrenceTimes]    INT           NULL,
    [dateofOffense]      VARCHAR (255) COLLATE Latin1_General_CI_AS NULL,
    [writtenExplanation] VARCHAR (255) COLLATE Latin1_General_CI_AS NULL,
    [witness]            VARCHAR (255) NULL,
    [userID]             VARCHAR (255) NULL
);

