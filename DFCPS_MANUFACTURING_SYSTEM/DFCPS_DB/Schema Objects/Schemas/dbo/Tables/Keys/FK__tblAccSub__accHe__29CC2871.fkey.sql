ALTER TABLE [dbo].[tblAccSubHeader]
    ADD CONSTRAINT [FK__tblAccSub__accHe__29CC2871] FOREIGN KEY ([accHeaderno]) REFERENCES [dbo].[tblAccHeader] ([accHeaderNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

