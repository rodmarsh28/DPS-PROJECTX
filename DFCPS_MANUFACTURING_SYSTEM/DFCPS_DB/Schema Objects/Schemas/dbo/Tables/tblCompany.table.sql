CREATE TABLE [dbo].[tblCompany] (
    [companyID]      INT           IDENTITY (1, 1) NOT NULL,
    [companyName]    VARCHAR (255) COLLATE Latin1_General_CI_AS NULL,
    [companyAddress] VARCHAR (255) COLLATE Latin1_General_CI_AS NULL,
    [companyHeader]  IMAGE         NULL,
    [companyLogo]    IMAGE         NULL
);

