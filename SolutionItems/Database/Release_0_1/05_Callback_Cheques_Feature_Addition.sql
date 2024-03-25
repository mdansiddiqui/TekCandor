--select * from feature where ModuleId=15;
--select * from Module;
DECLARE @ModuleId BIGINT
DECLARE @FeatureId BIGINT
DECLARE @CreateFeatureActionId BIGINT
DECLARE @ReadFeatureActionId BIGINT
DECLARE @UpdateFeatureActionId BIGINT
DECLARE @DeleteFeatureActionId BIGINT
-- This file is depicting an addition of Cheque Clearing Feature in Monitoring Module (New)
-- get ModuleId

SET @ModuleId = (SELECT TOP 1 Id FROM Module WHERE [Name] = 'Monitoring')

-- First add the feature against a respective module with its moduleID and display order

INSERT INTO feature
(
Description,
DisplayOrder,
ModuleId,
Name,
IsNew,
IsDeleted,
CreatedUser,
CreatedDateTime,
EntityType,
WorkflowEnabled,
ImportEnabled,
Version,
AuditTrailEnabled)
VALUES
(
'CallBack Cheques',
1,
@ModuleId,
'CallBack Cheques',
0,
0,
'system',
GETDATE(),
'ChequeDepositInformation',
0,
0,
1,
0);
SET @FeatureId = @@IDENTITY
--select * from feature where ModuleId=7;
-- All the feature actions like create,read,update,delete must be added in feature action table

INSERT INTO featureaction
(
Description,
DisplayOrder,
FeatureId,
Name,
IsNew,
IsDeleted,
CreatedUser,
CreatedDateTime,
ModifiedUser,
ModifiedDateTime,
Version)
VALUES
(
'Create',
1,
@FeatureId,
'Create',
0,
0,
'milldol',
'2019-11-22 03:17:23',
'milldol',
'2019-11-22 03:17:23',
0);
SET @CreateFeatureActionId = @@IDENTITY

INSERT INTO featureaction
(
Description,
DisplayOrder,
FeatureId,
Name,
IsNew,
IsDeleted,
CreatedUser,
CreatedDateTime,
ModifiedUser,
ModifiedDateTime,
Version)
VALUES
(
'Read',
2,
@FeatureId,
'Read',
0,
0,
'milldol',
'2019-11-22 03:17:23',
'milldol',
'2019-11-22 03:17:23',
0);
SET @ReadFeatureActionId = @@IDENTITY

INSERT INTO featureaction
(
Description,
DisplayOrder,
FeatureId,
Name,
IsNew,
IsDeleted,
CreatedUser,
CreatedDateTime,
ModifiedUser,
ModifiedDateTime,
Version)
VALUES
(
'Update',
3,
@FeatureId,
'Update',
0,
0,
'milldol',
'2019-11-22 03:17:23',
'milldol',
'2019-11-22 03:17:23',
0);
SET @UpdateFeatureActionId = @@IDENTITY

INSERT INTO featureaction
(
Description,
DisplayOrder,
FeatureId,
Name,
IsNew,
IsDeleted,
CreatedUser,
CreatedDateTime,
ModifiedUser,
ModifiedDateTime,
Version)
VALUES
(
'Delete',
4,
@FeatureId,
'Delete',
0,
0,
'milldol',
'2019-11-22 03:17:23',
'milldol',
'2019-11-22 03:17:23',
0);
SET @DeleteFeatureActionId = @@IDENTITY

--select * from featureaction where FeatureId=65;
-- Now Insert all the feature actions in permission record ModuleID, FeatureID, FeatureActionId inorder to get access

INSERT INTO permissionrecord
(
ModuleId,
FeatureId,
FeatureActionId,
Name,
IsNew,
IsDeleted,
CreatedUser,
CreatedDateTime,
ModifiedUser,
ModifiedDateTime,
Version)
VALUES
(
@ModuleId,
@FeatureId,
@CreateFeatureActionId,
'CallBackCheques.Create',
0,
0,
'milldol',
'2019-11-22 04:36:44',
'milldol',
'2019-11-22 04:36:44',
0);

INSERT INTO permissionrecord
(
ModuleId,
FeatureId,
FeatureActionId,
Name,
IsNew,
IsDeleted,
CreatedUser,
CreatedDateTime,
ModifiedUser,
ModifiedDateTime,
Version)
VALUES
(@ModuleId,
@FeatureId,
@ReadFeatureActionId,
'CallBackCheques.Read',
0,
0,
'milldol',
'2019-11-22 04:36:44',
'milldol',
'2019-11-22 04:36:44',
0);

INSERT INTO permissionrecord
(
ModuleId,
FeatureId,
FeatureActionId,
Name,
IsNew,
IsDeleted,
CreatedUser,
CreatedDateTime,
ModifiedUser,
ModifiedDateTime,
Version)
VALUES
(
@ModuleId,
@FeatureId,
@UpdateFeatureActionId,
'CallBackCheques.Update',
0,
0,
'milldol',
'2019-11-22 04:36:44',
'milldol',
'2019-11-22 04:36:44',
0);

INSERT INTO permissionrecord
(
ModuleId,
FeatureId,
FeatureActionId,
Name,
IsNew,
IsDeleted,
CreatedUser,
CreatedDateTime,
ModifiedUser,
ModifiedDateTime,
Version)
VALUES
(
@ModuleId,
@FeatureId,
@DeleteFeatureActionId,
'CallBackCheques.Delete',
0,
0,
'milldol',
'2019-11-22 04:36:44',
'milldol',
'2019-11-22 04:36:44',
0);

--select * from permissionrecord where moduleid = 15