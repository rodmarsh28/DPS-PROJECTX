CREATE TABLE [dbo].[tblLoomSectionTR] (
    [LTRNO]      INT             IDENTITY (1, 1) NOT NULL,
    [CLSNO]      VARCHAR (255)   NULL,
    [LOOMSNO]    VARCHAR (255)   NULL,
    [MESH]       VARCHAR (255)   NULL,
    [WIDTH]      VARCHAR (255)   NULL,
    [RPM]        VARCHAR (255)   NULL,
    [BEGINNING]  VARCHAR (255)   NULL,
    [ENDING]     VARCHAR (255)   NULL,
    [rollNo]     VARCHAR (255)   NULL,
    [DOFFEDL]    DECIMAL (20, 2) NULL,
    [DOFFEDWT]   DECIMAL (20, 2) NULL,
    [COLOR]      VARCHAR (255)   NULL,
    [PRODUCTION] DECIMAL (20, 2) NULL,
    [EFFIENCY]   DECIMAL (20, 2) NULL,
    [BIONO]      VARCHAR (255)   NULL,
    [WASTE]      DECIMAL (20, 3) NULL,
    [REMARKS]    VARCHAR (255)   NULL
);

