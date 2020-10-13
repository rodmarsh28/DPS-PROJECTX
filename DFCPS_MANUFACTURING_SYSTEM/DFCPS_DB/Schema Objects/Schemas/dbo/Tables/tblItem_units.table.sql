CREATE TABLE [dbo].[tblItem_units] (
    [unit_id]   INT           IDENTITY (1, 1) NOT NULL,
    [itemcode]  VARCHAR (255) NOT NULL,
    [unit_desc] VARCHAR (255) NOT NULL,
    [minQty]    INT           NOT NULL
);

