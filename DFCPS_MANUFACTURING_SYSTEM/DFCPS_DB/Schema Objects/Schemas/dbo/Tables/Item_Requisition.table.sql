CREATE TABLE [dbo].[Item_Requisition] (
    [requisition_no]         VARCHAR (255) NOT NULL,
    [item_requisistion_date] DATETIME2 (7) NULL,
    [departmentNo]           VARCHAR (255) NULL,
    [remarks]                VARCHAR (255) NULL,
    [userid]                 VARCHAR (255) NULL,
    [itemno]                 VARCHAR (255) NULL,
    [desc]                   VARCHAR (255) NULL,
    [unit]                   VARCHAR (255) NULL,
    [onhand_qty]             INT           NULL,
    [req_qty]                INT           NULL,
    [status]                 VARCHAR (255) NULL
);

