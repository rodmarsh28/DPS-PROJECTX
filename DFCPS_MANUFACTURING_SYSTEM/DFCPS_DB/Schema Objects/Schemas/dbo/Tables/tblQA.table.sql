CREATE TABLE [dbo].[tblQA] (
    [QANO]       VARCHAR (255) NOT NULL,
    [dFrom]      DATETIME2 (7) NULL,
    [dTo]        DATETIME2 (7) NULL,
    [QA]         VARCHAR (255) NULL,
    [MESH]       VARCHAR (255) COLLATE Latin1_General_CI_AS NULL,
    [CUSTOMER]   VARCHAR (255) NULL,
    [SUPERVISOR] VARCHAR (255) NULL,
    [AVGD1]      VARCHAR (255) NULL,
    [AVGT1]      VARCHAR (255) NULL,
    [RPM1]       VARCHAR (255) NULL,
    [AVGD2]      VARCHAR (255) NULL,
    [AVGT2]      VARCHAR (255) NULL,
    [RPM2]       VARCHAR (255) COLLATE Latin1_General_CI_AS NULL,
    [AVGD3]      VARCHAR (255) NULL,
    [AVGT3]      VARCHAR (255) NULL,
    [RPM3]       VARCHAR (255) NULL,
    [REMARKS]    VARCHAR (255) NULL
);

