CREATE PROCEDURE [dbo].[get_infraction_offense_list]
@command varchar(255),
@searchValue varchar(255)
AS
BEGIN
if @command = 'offense' begin
	SELECT
dbo.tblOffenses.offenseID,
dbo.tblOffenses.typeOfOffenses,
dbo.tblOccurrence.occurrenceTimes,
dbo.tblOccurrence.correctiveActions
FROM dbo.tblOffenses INNER JOIN dbo.tblOccurrence ON dbo.tblOffenses.offenseID = dbo.tblOccurrence.offenseID
where tblOffenses.offenseID like '%' + @searchValue + '%'
end
else if @command = 'infraction' begin
SELECT
dbo.tblInfractions.infractionID,
dbo.tblInfractions.infractionDesc,
dbo.tblSpecOffense.specOffenseID,
dbo.tblSpecOffense.specOffenseDesc,
dbo.tblSpecOffense.offenseID
FROM
dbo.tblInfractions
INNER JOIN dbo.tblSpecOffense ON dbo.tblInfractions.infractionID = dbo.tblSpecOffense.infractionID

end
END