CREATE PROCEDURE [dbo].[insert_settingsVariable]
@settingsName varchar(255),
@settingsValue varchar(255)
AS
IF NOT EXISTS(SELECT settingsName
								from viewSettingsName
                WHERE settingsName = @settingsName)  
begin INSERT INTO tblSettingsVariable VALUES(@settingsName,@settingsValue)
END
else
begin UPDATE tblSettingsVariable SET tblSettingsVariable.settingsValue = @settingsValue where tblSettingsVariable.settingsName = @settingsName
end