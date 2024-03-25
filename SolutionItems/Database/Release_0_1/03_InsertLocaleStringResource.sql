SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE InsertLocaleStringResource
	@ResourceName nvarchar(200),
	@ResourceValue nvarchar(500)
AS
BEGIN
	
	IF NOT EXISTS(SELECT * FROM LocaleStringResource WHERE LocaleStringResource.ResourceName = @ResourceName)
	BEGIN
		INSERT INTO localestringresource (LanguageId, ResourceName, ResourceValue, IsNew, IsDeleted, CreatedUser, CreatedDateTime, ModifiedUser, ModifiedDateTime, Version) 
		VALUES ('1', @ResourceName, @ResourceValue, '0', '0', 'system', GETDATE(), 'system', GETDATE(), 1)
	END
END
GO
