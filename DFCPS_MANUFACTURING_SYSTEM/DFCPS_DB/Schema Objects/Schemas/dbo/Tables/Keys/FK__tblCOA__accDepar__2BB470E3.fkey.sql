ALTER TABLE [dbo].[tblCOA]
    ADD CONSTRAINT [FK__tblCOA__accDepar__2BB470E3] FOREIGN KEY ([accDepartmentNo]) REFERENCES [dbo].[tblAccDepartment] ([AccDepartmentNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;

