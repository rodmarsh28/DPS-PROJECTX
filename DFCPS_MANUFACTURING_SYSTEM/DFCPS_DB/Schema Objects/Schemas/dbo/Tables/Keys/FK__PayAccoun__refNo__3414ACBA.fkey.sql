ALTER TABLE [dbo].[PayAccount]
    ADD CONSTRAINT [FK__PayAccoun__refNo__3414ACBA] FOREIGN KEY ([refNo]) REFERENCES [dbo].[Accounts_Payable] ([refNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

