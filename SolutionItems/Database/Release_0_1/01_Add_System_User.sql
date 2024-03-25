-- INSERT LANGUAGE
DECLARE @LanguageId INT
IF NOT EXISTS(SELECT * FROM [Language])
BEGIN
	INSERT INTO [dbo].[Language]
           ([LanguageCulture]
           ,[FlagImageFileName]
           ,[Published]
           ,[DisplayOrder]
           ,[Name]
           ,[IsNew]
           ,[IsDeleted]
           ,[CreatedUser]
           ,[CreatedDateTime]
           ,[ModifiedUser]
           ,[ModifiedDateTime]
           ,[Version])
     VALUES
           ('en-US'
           ,'us.png'
           ,1
           ,1
           ,'English'
           ,0
           ,0
           ,'system'
           ,getDate()
           ,NULL
           ,NULL
           ,1)
	SET @LanguageId = @@IDENTITY
END
ELSE
BEGIN
	SET @LanguageId = (SELECT TOP 1 Id FROM [Language])
END

-- CREATE SYSTEM ACCOUNT
DECLARE @OrganizationId INT

IF NOT EXISTS(SELECT * FROM [Organization])
BEGIN
	INSERT INTO [dbo].[Organization]
           ([Description]
           ,[Name]
           ,[IsNew]
           ,[IsDeleted]
           ,[CreatedUser]
           ,[CreatedDateTime]
           ,[ModifiedUser]
           ,[ModifiedDateTime]
           ,[Version])
    VALUES
           ('GALAXY BANK LIMITED'
           ,'GALAXY BANK LIMITED'
           ,0
           ,0
           ,'system'
           ,getDate()
           ,NULL
           ,NULL
           ,1)
	SET @OrganizationId = @@IDENTITY
END
ELSE
BEGIN
	SET @OrganizationId = (SELECT TOP 1 Id FROM [Organization])
END

IF NOT EXISTS(SELECT * FROM [User] WHERE IsSystemAccount = 1)
	BEGIN
INSERT INTO [dbo].[User]
           ([UserGuid]
           ,[LoginName]
           ,[LoginPassword]
           ,[Email]
           ,[PasswordFormatId]
           ,[PasswordFormat]
           ,[PasswordSalt]
           ,[Active]
           ,[IsSystemAccount]
           ,[DateOfBirth]
           ,[AddressCountry]
           ,[AddressState]
           ,[AddressCity]
           ,[Address]
           ,[Phone]
           ,[Cellphone]
           ,[Fax]
           ,[IsPasswordChangeRequired]
           ,[PasswordLastChanged]
           ,[FailedLoginAttempts]
           ,[IsBanned]
           ,[BannedDateFrom]
           ,[IsActiveDirectoryUser]
           ,[ActiveDirectoryDomain]
           ,[LastLoginTime]
           ,[LastIpAddress]
           ,[WebApiEnabled]
           ,[PublicKey]
           ,[SecretKey]
           ,[LastApiRequest]
           ,[SupervisorId]
           ,[LanguageId]
           ,[Name]
           ,[Description]
           ,[IsNew]
           ,[IsDeleted]
           ,[CreatedUser]
           ,[CreatedDateTime]
           ,[ModifiedUser]
           ,[ModifiedDateTime]
           ,[TimeZoneId]
           ,[Number]
           ,[AssignmentId]
           ,[CreatedUserId]
           ,[Version]
           ,[POApprovalLimit]
           ,[DefaultSiteId]
           ,[UserType]
		   ,[OrganizationId]
		   ,[Priority]
		)
     VALUES
           (NEWID()
           ,'system'
           ,'B3BAB2FBA08AD6DB32379BF5D40A10C35592170F'
           ,'support@teknoloje.com'
           ,1
           ,1
           ,'CMGDfgw='
           ,1
           ,1
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,0
           ,NULL
           ,NULL
           ,0
           ,NULL
           ,0
           ,NULL
           ,NULL
		   ,NULL
           ,1
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,@LanguageId
           ,'System Support'
          ,'System Support User'
           ,0
           ,0
           ,'system'
           ,getDate()
           ,NULL
           ,NULL
           ,'Pakistan Standard Time'
           ,NULL
           ,NULL
           ,NULL
           ,1
           ,NULL
           ,NULL
           ,1
           ,@OrganizationId
		   ,1
		   )
	END

-- CREATE ADMIN USER ACCOUNT

IF NOT EXISTS(SELECT * FROM [User] WHERE LoginName = 'admin')
	BEGIN
INSERT INTO [dbo].[User]
           ([UserGuid]
           ,[LoginName]
           ,[LoginPassword]
           ,[Email]
           ,[PasswordFormatId]
           ,[PasswordFormat]
           ,[PasswordSalt]
           ,[Active]
           ,[IsSystemAccount]
           ,[DateOfBirth]
           ,[AddressCountry]
           ,[AddressState]
           ,[AddressCity]
           ,[Address]
           ,[Phone]
           ,[Cellphone]
           ,[Fax]
           ,[IsPasswordChangeRequired]
           ,[PasswordLastChanged]
           ,[FailedLoginAttempts]
           ,[IsBanned]
           ,[BannedDateFrom]
           ,[IsActiveDirectoryUser]
           ,[ActiveDirectoryDomain]
           ,[LastLoginTime]
           ,[LastIpAddress]
           ,[WebApiEnabled]
           ,[PublicKey]
           ,[SecretKey]
           ,[LastApiRequest]
           ,[SupervisorId]
           ,[LanguageId]
           ,[Name]
           ,[Description]
           ,[IsNew]
           ,[IsDeleted]
           ,[CreatedUser]
           ,[CreatedDateTime]
           ,[ModifiedUser]
           ,[ModifiedDateTime]
           ,[TimeZoneId]
           ,[Number]
           ,[AssignmentId]
           ,[CreatedUserId]
           ,[Version]
           ,[POApprovalLimit]
           ,[DefaultSiteId]
           ,[UserType]
		   ,[OrganizationId]
		   ,[Priority]
           )
     VALUES
           (NEWID()
           ,'admin'
           ,'B3BAB2FBA08AD6DB32379BF5D40A10C35592170F'
           ,'info@teknoloje.com'
           ,1
           ,1
           ,'CMGDfgw='
           ,1
           ,0
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,'03312345678'
           ,'03312345678'
           ,'03312345678'
           ,0
           ,NULL
           ,NULL
           ,0
           ,NULL
           ,0
           ,NULL
           ,NULL
		   ,NULL
           ,1
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,@LanguageId
           ,'Administrator'
           ,'Administrator User'
           ,0
           ,0
           ,'system'
           ,getDate()
           ,NULL
           ,NULL
           ,'Pakistan Standard Time'
           ,NULL
           ,NULL
           ,NULL
           ,1
           ,NULL
           ,NULL
           ,0
		   ,@OrganizationId           
		   ,1
	)
	END
GO