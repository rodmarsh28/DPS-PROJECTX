CREATE TABLE [dbo].[tblBuildInventory] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [buildInvNo] NCHAR (10)    NULL,
    [dateBuild]  DATETIME2 (7) NULL,
    [itemcode]   NCHAR (10)    NULL,
    [qty]        INT           NULL,
    [remarks]    NCHAR (10)    NULL
);

