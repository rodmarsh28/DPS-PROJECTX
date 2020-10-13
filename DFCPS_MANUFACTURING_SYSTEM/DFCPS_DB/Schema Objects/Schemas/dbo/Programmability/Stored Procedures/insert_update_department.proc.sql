CREATE PROCEDURE [dbo].[insert_update_department]
@Mode as varchar(255),
@departmentNo as varchar(255),
@department as varchar(255),
@sssAccount as varchar(255),
@hdmfAccount as varchar(255),
@phAccount as varchar(255),
@taxAccount as varchar(255),
@costBenefitsAccount as varchar(255),
@costAccount as varchar(255),
@status as varchar(255)
AS
BEGIN
if @Mode = 'Add'
insert into tblDepartmentProfile values(@departmentNo,@department,@sssAccount,@hdmfAccount,@phAccount,@taxAccount,@costBenefitsAccount,@costAccount,@status)
else if  @Mode = 'Save'
update tblDepartmentProfile set department = @department,
sssAccount = @sssAccount,
hdmfAccount = @hdmfAccount,
phAccount = @phAccount,
taxAccount = @taxAccount,
costBenefitsAccount = @costBenefitsAccount,
costAccount = @costAccount,
status = @status
where departmentNo = @departmentNo
END