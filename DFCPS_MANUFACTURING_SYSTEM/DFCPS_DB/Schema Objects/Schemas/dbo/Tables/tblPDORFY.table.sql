CREATE TABLE [dbo].[tblPDORFY] (
    [FYRNO]     VARCHAR (255)   NOT NULL,
    [dFrom]     DATETIME2 (7)   NULL,
    [dTo]       DATETIME2 (7)   NULL,
    [Mesh]      VARCHAR (255)   NULL,
    [WasteYarn] DECIMAL (20, 2) NULL,
    [time1]     DATETIME2 (7)   NULL,
    [time2]     DATETIME2 (7)   NULL,
    [time3]     DATETIME2 (7)   NULL,
    [time4]     DATETIME2 (7)   NULL,
    [Customer]  VARCHAR (255)   NULL,
    [Operator]  VARCHAR (255)   NULL,
    [Visor]     VARCHAR (255)   NULL,
    [Remakrs]   VARCHAR (255)   NULL
);

