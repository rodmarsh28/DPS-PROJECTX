CREATE TABLE [dbo].[tblDYTR] (
    [DYRITEMNO]   INT             IDENTITY (1, 1) NOT NULL,
    [DYNO]        VARCHAR (255)   NULL,
    [TIME]        DATETIME2 (7)   NULL,
    [DOFFEDNO]    INT             NULL,
    [NOOFBOBBINS] DECIMAL (20, 2) NULL,
    [NOOFBAG]     DECIMAL (20, 2) NULL,
    [WTPERBAG]    DECIMAL (20, 2) NULL,
    [GROSSWT]     DECIMAL (20, 2) NULL,
    [NETWT]       DECIMAL (20, 2) NULL
);

