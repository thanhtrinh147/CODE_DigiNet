 SELECT D01.DepartmentID,D01.TeamID,  D01.TeamName
 FROM  D09T0227 D01 
 INNER JOIN D91T0012 D02 On D02.DepartmentID = D01.DepartmentID 
 WHERE D01.Disabled = 0 AND DivisionID = 'QT'
 UNION 
 SELECT '%' As DepartmentID,'%' As TeamID,'Taát caû' As TeamName
 ORDER BY	D01.TeamID
go
Select DepartmentID, DepartmentName
 FROM 	D91T0012 
 WHERE	DivisionID = 'QT' And Disabled = 0
 UNION  
 SELECT '%' As DepartmentID,  'Taát caû' As DepartmentName 
 ORDER BY 	DepartmentID
go
 SELECT DepartmentID,TeamID,EmployeeID ,  Isnull(LastName,'')+' '+Isnull(MiddleName,'')+' ' +  Isnull(FirstName,'') As EmployeeName
 FROM	D09T0201 
 WHERE	Disabled = 0
 UNION
 SELECT '%'  As DepartmentID,'%' As TeamID,'%' As EmployeeID ,'Taát caû' As EmployeeName
 ORDER BY	EmployeeID
go
 SELECT ProductID, ShortName as ProductName FROM 	D45T1000 WHERE	Disabled = 0 ORDER BY	ProductID
go
 SELECT D01.ProductID,D01.StageID, D10.StageName
 FROM 	D45T1001 D01
 INNER JOIN	D45T1010 D10 On D10.StageID = D01.StageID
 WHERE	D10.Disabled = 0 And D01.ProductID='0102090'
 ORDER BY 	D01.OrderNo
go
Exec D45P2006 'QT', '%', '%', '%', '0102090', 'K', 9, 2007, '45PV0Z000000012', '',0, ''
go
Select Code, ShortName, Disabled From D45T0010 Where Type = 'QTY' Order by Code
go
