''' <summary>
''' Module này dùng để chưá các hàm AuditLog
''' </summary>
Module D13X0010

    ''' <summary>
    ''' Kiểm tra có dùng mã AuditCode không
    ''' </summary>
    Enum StatusAuditCode
        ''' <summary>
        ''' Chưa kiểm tra
        ''' </summary>
        None = 0
        ''' <summary>
        ''' Kiểm tra có dùng
        ''' </summary>
        Use = 1
        ''' <summary>
        ''' Kiểm tra không dùng
        ''' </summary>
        NoUse = 2
    End Enum

    Public geCloseBook As StatusAuditCode = StatusAuditCode.None ' Kiểm tra có dùng Audit Khóa sổ
    Public geOpenBook As StatusAuditCode = StatusAuditCode.None  ' Kiểm tra có dùng Audit Mở sổ

    Public gePITBalanceVoucher As StatusAuditCode = StatusAuditCode.None
    Public gePITVoucher As StatusAuditCode = StatusAuditCode.None
    Public geMasterSalaryFile As StatusAuditCode = StatusAuditCode.None
    Public geAttendanceTypes As StatusAuditCode = StatusAuditCode.None
    Public gePITObjects As StatusAuditCode = StatusAuditCode.None
    Public geSeniorityBonuses As StatusAuditCode = StatusAuditCode.None
    Public geEvaluationTypes As StatusAuditCode = StatusAuditCode.None
    Public geSalaryGrades As StatusAuditCode = StatusAuditCode.None
    Public geSalaryTemplates As StatusAuditCode = StatusAuditCode.None
    Public geSalaryLevels As StatusAuditCode = StatusAuditCode.None
    Public gePayrollAnalCode As StatusAuditCode = StatusAuditCode.None
    Public geResultRecTable As StatusAuditCode = StatusAuditCode.None
    Public geSalaryCalTrans As StatusAuditCode = StatusAuditCode.None
    Public geTimeSheetRecTrans As StatusAuditCode = StatusAuditCode.None

    Public Const AuditCodeCloseBook As String = "CloseBook13" 'Khóa sổ 
    Public Const AuditCodeOpenBook As String = "OpenBook13" 'Mở sổ 

    Public Const AuditCodePITBalanceVoucher As String = "PITBalanceVoucher"
    Public Const AuditCodePITVoucher As String = "PITVoucher"
    Public Const AuditCodeMasterSalaryFile As String = "MasterPayrollFiles"
    Public Const AuditCodeAttendanceTypes As String = "AttendanceTypes"
    Public Const AuditCodePITObjects As String = "PITObjects"
    Public Const AuditCodeSeniorityBonuses As String = "SeniorityBonuses"
    Public Const AuditCodeEvaluationTypes As String = "EvaluationTypes"
    Public Const AuditCodeSalaryGrades As String = "SalaryGrades"
    Public Const AuditCodeSalaryTemplates As String = "SalaryTemplates"
    Public Const AuditCodeSalaryLevels As String = "SalaryLevels"
    Public Const AuditCodePayrollAnalCode As String = "PayrollAnalCode"
    Public Const AuditCodeResultRecTable As String = "ResultRecTable"
    Public Const AuditCodeSalaryCalTrans As String = "SalaryCalTrans"
    Public Const AuditCodeTimeSheetRecTrans As String = "TimeSheetRecTrans"

    Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, Optional ByVal sDesc1 As String = "", Optional ByVal sDesc2 As String = "", Optional ByVal sDesc3 As String = "", Optional ByVal sDesc4 As String = "", Optional ByVal sDesc5 As String = "")
        'sEventID = 1: Thêm mới; = 2: Sửa; = 3: Xóa; = 4: In   

        ''Module này có dùng Auditlog không
        'If Not gbUseAudit Then Exit Sub
        ''Mã AuditCode này có sử dụng không
        'If Not CheckUseAuditCode(sAuditCode) Then Exit Sub

        'Ghi Audit cho mỗi nghiệp vụ
        'Dim sSQL As String = ""
        'sSQL &= "Exec D91P9106 "
        'sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        'sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        'sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        'sSQL &= SQLString(L3Right(D13, 2)) & COMMA 'ModuleID, varchar[2], NOT NULL
        'sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        'sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        'sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL

        'ExecuteSQLNoTransaction(sSQL)

        Lemon3.D91.RunAuditLog("13", sAuditCode, sEventID, sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

    End Sub
    Private Function ExistRecordAuditCode(ByVal AuditCode As String) As Boolean
        Dim sSQL As String
        sSQL = "Select 1 From D91T9200  WITH (NOLOCK) Where  Audit =1 And ModuleID= '" & L3Right(D13, 2) & "' And AuditCode= " & SQLString(AuditCode)
        Return ExistRecord(sSQL)
    End Function

End Module

