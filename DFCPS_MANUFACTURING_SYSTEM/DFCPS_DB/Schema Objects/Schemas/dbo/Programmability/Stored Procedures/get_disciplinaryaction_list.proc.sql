CREATE PROCEDURE [dbo].[get_disciplinaryaction_list]
@command varchar(255),
@searchValue varchar(255)
AS
BEGIN
SELECT
dbo.tblDesciplinaryAction.descActionNo,
convert(varchar,dbo.tblDesciplinaryAction.[date],111) as dateFilled,
dbo.tblInfractions.infractionDesc,
dbo.tblOccurrence.correctiveActions,
convert(varchar,dbo.tblDesciplinaryAction.dateofOffense,111) as dateofOffense

FROM
dbo.tblDesciplinaryAction
INNER JOIN dbo.tblInfractions ON dbo.tblDesciplinaryAction.infractionID = dbo.tblInfractions.infractionID
INNER JOIN dbo.tblOccurrence ON dbo.tblDesciplinaryAction.occurrenceTimes = dbo.tblOccurrence.occurrenceTimes AND dbo.tblOccurrence.offenseID = dbo.tblDesciplinaryAction.OffenseID

 where employeeID like '%'+ @searchvalue + '%'
END