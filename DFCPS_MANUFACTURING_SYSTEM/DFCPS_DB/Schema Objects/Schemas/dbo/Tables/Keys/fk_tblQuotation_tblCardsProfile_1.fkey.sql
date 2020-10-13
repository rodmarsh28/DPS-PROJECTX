ALTER TABLE [dbo].[tblSalesQuotation]
    ADD CONSTRAINT [fk_tblQuotation_tblCardsProfile_1] FOREIGN KEY ([cardID]) REFERENCES [dbo].[tblCardsProfile] ([cardID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

