SET TRANSACTION ISOLATION LEVEL READ COMMITTED;BEGIN TRANSACTION
go
Delete From D45T1031 Where SRoutingID = 'A'
Delete From D45T1030 Where SRoutingID = 'A'
go
COMMIT TRANSACTION
go
 Select SRoutingID, SRoutingName,  PreparedDate, ISNULL(OB.ObjectName, '') as PreparerName, D30.Disabled,D30.CreateUserID, D30.CreateDate, D30.LastModifyUserID, D30.LastModifyDate
 From 	D45T1030 D30
 Left Join	Object OB On OB.ObjectID = D30.PreparerID And OB.ObjectTypeID = 'NV'
 Order by	SRoutingID,PreparedDate
go
Select Permission From D00V0001 Where ScreenID = 'D45F1030' And UserID = 'LEMONADMIN' And CompanyID = 'DRD06' And ModuleID = 'D45'
go
