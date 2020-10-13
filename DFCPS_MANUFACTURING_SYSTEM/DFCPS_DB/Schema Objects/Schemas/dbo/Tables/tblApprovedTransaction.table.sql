CREATE TABLE [dbo].[tblApprovedTransaction] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [refNo]        VARCHAR (255) NULL,
    [checked]      INT           NULL,
    [dateChecked]  DATETIME2 (7) NULL,
    [approved]     INT           NULL,
    [dateApproved] DATETIME2 (7) NULL
);

