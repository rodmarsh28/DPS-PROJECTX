CREATE TABLE [dbo].[tblChildrenInfo] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [employeeID] VARCHAR (255) COLLATE Latin1_General_CI_AS NULL,
    [lastname]   VARCHAR (255) COLLATE Latin1_General_CI_AS NULL,
    [firstname]  VARCHAR (255) COLLATE Latin1_General_CI_AS NULL,
    [middlename] VARCHAR (255) COLLATE Latin1_General_CI_AS NULL
);

