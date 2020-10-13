CREATE PROCEDURE [dbo].[delete_exst_dtrRecord]
@transDate datetime2
AS
BEGIN
	DELETE tblDTRrecord WHERE convert(varchar,dtrDate,111) = convert(varchar,@transDate,111)
END