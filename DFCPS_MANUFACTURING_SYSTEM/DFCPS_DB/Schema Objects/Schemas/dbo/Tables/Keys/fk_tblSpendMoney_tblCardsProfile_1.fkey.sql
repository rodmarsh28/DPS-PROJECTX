ALTER TABLE [dbo].[tblSpendMoney]
    ADD CONSTRAINT [fk_tblSpendMoney_tblCardsProfile_1] FOREIGN KEY ([cardID]) REFERENCES [dbo].[tblCardsProfile] ([cardID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

