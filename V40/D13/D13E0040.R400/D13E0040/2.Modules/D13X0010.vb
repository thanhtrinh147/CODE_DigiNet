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
End Module

