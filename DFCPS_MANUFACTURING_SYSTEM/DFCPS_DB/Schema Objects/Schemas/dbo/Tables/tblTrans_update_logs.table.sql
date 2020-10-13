CREATE TABLE [dbo].[tblTrans_update_logs] (
    [UPDATE_LOG_ID]    VARCHAR (255) NOT NULL,
    [SRC]              VARCHAR (255) NULL,
    [TR_NO]            VARCHAR (255) NULL,
    [DATE_OF_ACTION]   DATETIME2 (0) NULL,
    [REASON_OF_ACTION] VARCHAR (255) NULL,
    [REMARKS]          VARCHAR (255) NULL
);

