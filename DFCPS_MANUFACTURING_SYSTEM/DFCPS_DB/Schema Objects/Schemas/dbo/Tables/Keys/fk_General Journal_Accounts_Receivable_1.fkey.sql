ALTER TABLE [dbo].[General Journal]
    ADD CONSTRAINT [fk_General Journal_Accounts_Receivable_1] FOREIGN KEY ([GJNO]) REFERENCES [dbo].[Accounts_Receivable] ([refNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

