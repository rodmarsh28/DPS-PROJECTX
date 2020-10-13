ALTER TABLE [dbo].[tblAccDepartment]
    ADD CONSTRAINT [FK__tblAccDep__accSu__2AC04CAA] FOREIGN KEY ([accSubHeaderNo]) REFERENCES [dbo].[tblAccSubHeader] ([accSubHeaderNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

