ALTER TABLE [dbo].[tblCardsBalance]
    ADD CONSTRAINT [FK__tblCardsB__cardI__770B9E7A] FOREIGN KEY ([cardID]) REFERENCES [dbo].[tblCardsProfile] ([cardID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

