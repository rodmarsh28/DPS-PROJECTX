CREATE PROCEDURE [dbo].[get_RFP_list]
@searchValue as varchar(255)
AS
BEGIN
SELECT DISTINCT
convert(varchar,[transDate],111) AS [Date],
[NO] AS [NO],
amount as Amount,
 STATUS as Status
FROM
tblRFP
where [NO] like '%' + @searchValue + '%' and status <> '%Prepared'
END