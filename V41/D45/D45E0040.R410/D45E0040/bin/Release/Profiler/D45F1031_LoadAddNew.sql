 Select  ObjectID as PreparerID,  IsNull(ObjectName,'') As PreparerName From 	Object Where Disabled = 0 And ObjectTypeID = 'NV' Order by 	ObjectID
go
Select StageID, StageName From D45T1010 Where Disabled = 0 Order by StageID
go
 Select D31.StageID, D10.StageName, D31.OrderNo From 	D45T1031 D31 Inner join D45T1010 D10 On D10.StageID = D31.StageID Where	D31. SRoutingID = '' Order by	OrderNo
go
