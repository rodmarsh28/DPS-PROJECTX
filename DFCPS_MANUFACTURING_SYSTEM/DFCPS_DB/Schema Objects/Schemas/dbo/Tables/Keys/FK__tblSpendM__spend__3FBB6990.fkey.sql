ALTER TABLE [dbo].[tblSpendMoney_Serv]
    ADD CONSTRAINT [FK__tblSpendM__spend__3FBB6990] FOREIGN KEY ([spendMoneyNo]) REFERENCES [dbo].[tblSpendMoney] ([spendMoneyNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

