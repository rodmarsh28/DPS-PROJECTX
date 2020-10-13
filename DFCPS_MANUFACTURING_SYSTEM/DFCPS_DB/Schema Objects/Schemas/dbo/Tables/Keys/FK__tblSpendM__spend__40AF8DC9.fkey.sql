ALTER TABLE [dbo].[tblSpendMoney_Inv]
    ADD CONSTRAINT [FK__tblSpendM__spend__40AF8DC9] FOREIGN KEY ([spendMoneyNo]) REFERENCES [dbo].[tblSpendMoney] ([spendMoneyNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

