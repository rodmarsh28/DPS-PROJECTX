CREATE PROCEDURE [dbo].[get_system_db_mod]
AS
BEGIN
	select top 1 last_row_changes from tblLastrowchanges
order by last_row_changes desc
END