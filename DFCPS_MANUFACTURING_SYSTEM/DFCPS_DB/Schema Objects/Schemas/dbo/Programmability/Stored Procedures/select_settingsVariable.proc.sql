CREATE PROCEDURE [dbo].[select_settingsVariable]
@settingsName varchar(255),
@settingsValue varchar(255)
AS
begin SELECT settingsValue
								from viewSettingsName
                WHERE settingsName = @settingsName
end