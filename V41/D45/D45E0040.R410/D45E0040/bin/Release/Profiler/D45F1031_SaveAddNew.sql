Select Top 1 1 From D45T1030 Where SRoutingID = 'A'
go
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;BEGIN TRANSACTION
go
Insert Into D45T1030(SRoutingID, SRoutingName, PreparedDate, PreparerID, Note, Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate) Values('A', 'b', '03/19/2008', 'DH00000001', 'c', 0, 'LEMONADMIN', GetDate(), 'LEMONADMIN', GetDate())
Insert Into D45T1031(SRoutingID, StageID, OrderNo) Values('A', 'TH', 1)

go
COMMIT TRANSACTION
go
