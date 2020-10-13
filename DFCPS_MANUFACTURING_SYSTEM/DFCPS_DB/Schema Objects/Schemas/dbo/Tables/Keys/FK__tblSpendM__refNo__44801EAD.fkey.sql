ALTER TABLE [dbo].[tblSpendMoneyInvoice]
    ADD CONSTRAINT [FK__tblSpendM__refNo__44801EAD] FOREIGN KEY ([refNo]) REFERENCES [dbo].[tblSpendMoney] ([spendMoneyNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

