CREATE TABLE [dbo].[tblFPITR] (
    [fpiItemNo]    INT             IDENTITY (1, 1) NOT NULL,
    [fpiNo]        VARCHAR (255)   NULL,
    [CSRITEMNO]    INT             NULL,
    [Width]        VARCHAR (255)   NULL,
    [baglength]    DECIMAL (20, 2) NULL,
    [Color]        VARCHAR (255)   NULL,
    [sewnType]     VARCHAR (255)   NULL,
    [inputQTY]     DECIMAL (20, 2) NULL,
    [weavReject]   DECIMAL (20, 2) NULL,
    [wrWt]         DECIMAL (20, 2) NULL,
    [printReject]  DECIMAL (20, 2) NULL,
    [prWt]         DECIMAL (20, 2) NOT NULL,
    [sewingReject] DECIMAL (20, 2) NULL,
    [srWt]         DECIMAL (20, 2) NULL,
    [grossQTY]     DECIMAL (20, 2) NULL,
    [netQTY]       DECIMAL (20, 2) NULL,
    [remarks]      VARCHAR (255)   NULL
);

