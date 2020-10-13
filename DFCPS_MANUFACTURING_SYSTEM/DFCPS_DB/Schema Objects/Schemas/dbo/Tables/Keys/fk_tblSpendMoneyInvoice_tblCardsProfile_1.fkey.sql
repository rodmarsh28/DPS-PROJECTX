ALTER TABLE [dbo].[tblSpendMoneyInvoice]
    ADD CONSTRAINT [fk_tblSpendMoneyInvoice_tblCardsProfile_1] FOREIGN KEY ([cardID]) REFERENCES [dbo].[tblCardsProfile] ([cardID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

