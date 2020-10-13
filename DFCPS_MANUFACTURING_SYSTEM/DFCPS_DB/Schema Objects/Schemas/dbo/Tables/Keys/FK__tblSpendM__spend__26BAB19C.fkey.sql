ALTER TABLE [dbo].[tblSpendMoneyInvoice_Inv]
    ADD CONSTRAINT [FK__tblSpendM__spend__26BAB19C] FOREIGN KEY ([spendMoneyInvoiceNo]) REFERENCES [dbo].[tblSpendMoneyInvoice] ([spendMoneyInvoiceNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

