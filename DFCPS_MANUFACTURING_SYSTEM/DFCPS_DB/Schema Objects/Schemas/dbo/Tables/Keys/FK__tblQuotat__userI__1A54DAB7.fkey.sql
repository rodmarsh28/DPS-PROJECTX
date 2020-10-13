ALTER TABLE [dbo].[tblSalesQuotation]
    ADD CONSTRAINT [FK__tblQuotat__userI__1A54DAB7] FOREIGN KEY ([userID]) REFERENCES [dbo].[tblUsers] ([userID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

