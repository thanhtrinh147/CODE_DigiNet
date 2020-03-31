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
    'Khóa sổ 
    Public Const AuditCodeCloseBook As String = "CloseBook13"
    'Mở sổ 
    Public Const AuditCodeOpenBook As String = "OpenBook13"

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

    Public Const AuditCodeMasterSalaryFile As String = "MasterSalaryFile"
    Public Const AuditCodeAttendanceTypes As String = "AttendanceTypes"
    Public Const AuditCodePITObjects As String = "PITObjects"
    Public Const AuditCodeSeniorityBonuses As String = "SeniorityBonuses"
    Public Const AuditCodeEvaluationTypes As String = "EvaluationTypes"
    Public Const AuditCodeSalaryGrades As String = "SalaryGrades"
    Public Const AuditCodeSalaryTemplates As String = "SalaryTemplates"
    Public Const AuditCodeSalaryLevels As String = "SalaryLevels"
    Public Const AuditCodePayrollAnalCode As String = "PayrollAnalCode"
    Public Const AuditCodeResultRecTable As String = "ResultRecTable"

    'Public Sub UseAuditLog()
    '    '#------------------------------------------------------
    '    '#CreateUser:   Nguyen Thi Minh Hoa
    '    '#CreateDate:   21/11/2007
    '    '#ModifiedUser: Nguyen Thi Minh Hoa
    '    '#ModifiedDate: 21/11/2007
    '    '#Description: Kiểm tra module này có dùng Audit không? Có trả ra = True, không = False
    '    '#------------------------------------------------------
    '    Dim sSQL As String
    '    sSQL = "Select top 1 1 From D91T9200 Where Audit=1 And ModuleID= '" & ModuleID & "'"
    '    gbUseAudit = ExistRecord(sSQL)

    'End Sub

    Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, Optional ByVal sDesc1 As String = "", Optional ByVal sDesc2 As String = "", Optional ByVal sDesc3 As String = "", Optional ByVal sDesc4 As String = "", Optional ByVal sDesc5 As String = "")
        'sEventID = 1: Thêm mới; = 2: Sửa; = 3: Xóa; = 4: In   

        ''Module này có dùng Auditlog không
        'If Not gbUseAudit Then Exit Sub
        ''Mã AuditCode này có sử dụng không
        'If Not CheckUseAuditCode(sAuditCode) Then Exit Sub

        'Ghi Audit cho mỗi nghiệp vụ
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9106 "
        sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ModuleID) & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL

        ExecuteSQLNoTransaction(sSQL)

    End Sub

    Private Function CheckUseAuditCode(ByVal AuditCode As String) As Boolean
        Select Case AuditCode
            Case AuditCodeCloseBook
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geCloseBook = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geCloseBook = StatusAuditCode.Use
                    Else
                        geCloseBook = StatusAuditCode.NoUse
                    End If
                End If
                Return geCloseBook = StatusAuditCode.Use

            Case AuditCodeOpenBook
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geOpenBook = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geOpenBook = StatusAuditCode.Use
                    Else
                        geOpenBook = StatusAuditCode.NoUse
                    End If
                End If
                Return geOpenBook = StatusAuditCode.Use

            Case AuditCodeMasterSalaryFile
                If geMasterSalaryFile = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geMasterSalaryFile = StatusAuditCode.Use
                    Else
                        geMasterSalaryFile = StatusAuditCode.NoUse
                    End If
                End If
                Return geMasterSalaryFile = StatusAuditCode.Use

            Case AuditCodeAttendanceTypes
                If geAttendanceTypes = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geAttendanceTypes = StatusAuditCode.Use
                    Else
                        geAttendanceTypes = StatusAuditCode.NoUse
                    End If
                End If
                Return geAttendanceTypes = StatusAuditCode.Use

            Case AuditCodePITObjects
                If gePITObjects = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        gePITObjects = StatusAuditCode.Use
                    Else
                        gePITObjects = StatusAuditCode.NoUse
                    End If
                End If
                Return gePITObjects = StatusAuditCode.Use

            Case AuditCodeSeniorityBonuses
                If geSeniorityBonuses = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geSeniorityBonuses = StatusAuditCode.Use
                    Else
                        geSeniorityBonuses = StatusAuditCode.NoUse
                    End If
                End If
                Return geSeniorityBonuses = StatusAuditCode.Use

            Case AuditCodeEvaluationTypes
                If geEvaluationTypes = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geEvaluationTypes = StatusAuditCode.Use
                    Else
                        geEvaluationTypes = StatusAuditCode.NoUse
                    End If
                End If
                Return geEvaluationTypes = StatusAuditCode.Use

            Case AuditCodeSalaryGrades
                If geSalaryGrades = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geSalaryGrades = StatusAuditCode.Use
                    Else
                        geSalaryGrades = StatusAuditCode.NoUse
                    End If
                End If
                Return geSalaryGrades = StatusAuditCode.Use

            Case AuditCodeSalaryTemplates
                If geSalaryTemplates = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geSalaryTemplates = StatusAuditCode.Use
                    Else
                        geSalaryTemplates = StatusAuditCode.NoUse
                    End If
                End If
                Return geSalaryTemplates = StatusAuditCode.Use

            Case AuditCodeSalaryLevels
                If geSalaryLevels = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geSalaryLevels = StatusAuditCode.Use
                    Else
                        geSalaryLevels = StatusAuditCode.NoUse
                    End If
                End If
                Return geSalaryLevels = StatusAuditCode.Use

            Case AuditCodePayrollAnalCode
                If gePayrollAnalCode = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        gePayrollAnalCode = StatusAuditCode.Use
                    Else
                        gePayrollAnalCode = StatusAuditCode.NoUse
                    End If
                End If
                Return gePayrollAnalCode = StatusAuditCode.Use

            Case AuditCodeResultRecTable
                If geResultRecTable = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geResultRecTable = StatusAuditCode.Use
                    Else
                        geResultRecTable = StatusAuditCode.NoUse
                    End If
                End If
                Return geResultRecTable = StatusAuditCode.Use

        End Select

    End Function

    Private Function ExistRecordAuditCode(ByVal AuditCode As String) As Boolean
        Dim sSQL As String
        sSQL = "Select 1 From D91T9200  WITH(NOLOCK)  Where  Audit =1 And ModuleID= '" & ModuleID & "' And AuditCode= " & SQLString(AuditCode)
        Return ExistRecord(sSQL)
    End Function


    ''' <summary>
    ''' Kiểm tra thiết lập Audit
    ''' </summary>
    ''' <param name="sWhere">Chuỗi điều kiện lấy audit</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckAudit(ByVal sWhere As String) As Boolean
        Dim sSQL As String = ""
        sSQL &= "Select Audit From D91T9200  WITH(NOLOCK) Where AuditCode = " & SQLString(sWhere)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Function
        If Convert.ToInt16(dt.Rows(0).Item("Audit")) = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9106
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 06/03/2007 09:59:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD91P9106(ByVal sAuditCode As String, ByVal sModuleID As String, ByVal sEventID As String, ByVal sDesc1 As String, ByVal sDesc2 As String, ByVal sDesc3 As String, ByVal sDesc4 As String, ByVal sDesc5 As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9106 "
        sSQL &= SQLDateSave(Date.Today) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sModuleID) & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL
        Return sSQL
    End Function

End Module

