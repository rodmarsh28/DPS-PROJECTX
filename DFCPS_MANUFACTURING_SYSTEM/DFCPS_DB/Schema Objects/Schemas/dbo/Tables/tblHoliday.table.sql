﻿CREATE TABLE [dbo].[tblHoliday] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [HOLIDAYDATE] DATETIME2 (7) NULL,
    [HOLIDAYDESC] VARCHAR (255) NULL,
    [HOLIDAYTYPE] VARCHAR (255) NULL
);

