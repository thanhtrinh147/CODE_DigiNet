SET TRANSACTION ISOLATION LEVEL READ COMMITTED;BEGIN TRANSACTION
go
Delete From D45T2001
Where DivisionID = 'QT' AND TranMonth = 9 AND TranYear = 2007 AND ProductVoucherID = '45PV0Z000000012' AND TransID IN ('45DT0000000000033', '45DT0000000000034' )
Insert Into D45T2001(DivisionID, TranMonth, TranYear, ProductVoucherID, PayrollVoucherID, DepartmentID, TeamID, EmployeeID, ProductID, StageID, Quantity01, Quantity02, Quantity03, Quantity04, Quantity05,IsLocked,TransID ) Values('QT', 9, 2007, '45PV0Z000000012', '13PV0Z000000012', 'BGD', 'PGD', 'TVH', '1001C13', 'K', 0, 0, 0, 0, 0, 0, '45DT0000000000033')
Insert Into D45T2001(DivisionID, TranMonth, TranYear, ProductVoucherID, PayrollVoucherID, DepartmentID, TeamID, EmployeeID, ProductID, StageID, Quantity01, Quantity02, Quantity03, Quantity04, Quantity05,IsLocked,TransID ) Values('QT', 9, 2007, '45PV0Z000000012', '13PV0Z000000012', 'BTC', 'TCCTNN', 'TLN', '1001C13', 'K', 1, 1, 0, 0, 0, 0, '45DT0000000000034')

go
