﻿ALTER TABLE [dbo].[tblSalesOrder]
    ADD CONSTRAINT [fk_tblSalesOrder_tblCardsProfile_1] FOREIGN KEY ([cardID]) REFERENCES [dbo].[tblCardsProfile] ([cardID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

