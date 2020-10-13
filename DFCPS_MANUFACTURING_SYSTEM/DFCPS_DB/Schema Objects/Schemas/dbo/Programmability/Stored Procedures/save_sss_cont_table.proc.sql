CREATE PROCEDURE [dbo].[save_sss_cont_table]
@countx as int,
@salaryF as decimal(20,2),
@salaryT as decimal(20,2),
@salary as decimal(20,2),
@ER as decimal(20,2),
@EE as decimal(20,2),
@EC as decimal(20,2),
@TOTAL as decimal(20,2)
AS
BEGIN
if @countx = 0 begin
delete tblSSS_cont_table
end
	INSERT INTO tblSSS_cont_table VALUES(@salaryF,@salaryT,@salary,@ER,@EE,@EC,@TOTAL)
END