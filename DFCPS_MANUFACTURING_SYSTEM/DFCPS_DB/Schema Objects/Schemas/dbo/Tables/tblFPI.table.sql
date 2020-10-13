CREATE TABLE [dbo].[tblFPI] (
    [fpiNo]      VARCHAR (255) NOT NULL,
    [dFrom]      DATETIME2 (7) NULL,
    [dTo]        DATETIME2 (7) NULL,
    [itemCount]  VARCHAR (255) NULL,
    [inspector]  VARCHAR (255) NULL,
    [supervisor] VARCHAR (255) NULL,
    [remarks]    VARCHAR (255) NULL
);

