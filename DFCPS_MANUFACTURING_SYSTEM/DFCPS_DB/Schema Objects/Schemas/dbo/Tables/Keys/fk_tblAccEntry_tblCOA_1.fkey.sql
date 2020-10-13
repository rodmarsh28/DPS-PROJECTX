ALTER TABLE [dbo].[tblAccEntry]
    ADD CONSTRAINT [fk_tblAccEntry_tblCOA_1] FOREIGN KEY ([accNo]) REFERENCES [dbo].[tblCOA] ([accNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

