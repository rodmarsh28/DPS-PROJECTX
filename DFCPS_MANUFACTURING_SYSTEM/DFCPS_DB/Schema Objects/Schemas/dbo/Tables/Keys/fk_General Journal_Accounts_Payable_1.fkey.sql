ALTER TABLE [dbo].[General Journal]
    ADD CONSTRAINT [fk_General Journal_Accounts_Payable_1] FOREIGN KEY ([GJNO]) REFERENCES [dbo].[Accounts_Payable] ([refNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

