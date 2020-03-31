﻿''' <summary>
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
