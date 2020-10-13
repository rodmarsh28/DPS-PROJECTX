ALTER TABLE [dbo].[tblSpendMoneyInvoice_Serv]
    ADD CONSTRAINT [FK__tblSpendM__spend__27AED5D5] FOREIGN KEY ([spendMoneyInvoiceNo]) REFERENCES [dbo].[tblSpendMoneyInvoice] ([spendMoneyInvoiceNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

