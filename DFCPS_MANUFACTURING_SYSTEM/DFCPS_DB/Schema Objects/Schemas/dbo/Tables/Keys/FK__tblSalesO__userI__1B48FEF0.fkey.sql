ALTER TABLE [dbo].[tblSalesOrder]
    ADD CONSTRAINT [FK__tblSalesO__userI__1B48FEF0] FOREIGN KEY ([userID]) REFERENCES [dbo].[tblUsers] ([userID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

