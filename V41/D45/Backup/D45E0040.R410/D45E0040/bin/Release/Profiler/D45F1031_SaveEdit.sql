SET TRANSACTION ISOLATION LEVEL READ COMMITTED;BEGIN TRANSACTION
go
Update D45T1030 Set SRoutingName = 'b', PreparedDate = '03/19/2008', PreparerID = 'DH00000001', Note = 'c', Disabled = 0, LastModifyUserID = 'LEMONADMIN', LastModifyDate = GetDate() Where SRoutingID = 'A'
Delete From D45T1031 Where SRoutingID = 'A'
Insert Into D45T1031(SRoutingID, StageID, OrderNo) Values('A', 'TH', 1)
Insert Into D45T1031(SRoutingID, StageID, OrderNo) Values('A', 'K', 2)

go
COMMIT TRANSACTION
go
