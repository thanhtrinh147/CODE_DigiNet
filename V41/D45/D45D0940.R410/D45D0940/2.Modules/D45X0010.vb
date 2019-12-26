Module D35X0010
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
    Public geIncreaseLeave As StatusAuditCode = StatusAuditCode.None  ' Kiểm tra có dùng Audit Tăng phép
    Public geLeaveTransactions As StatusAuditCode = StatusAuditCode.None  ' Kiểm tra có dùng Audit Chấm phép
    Public geLeaveAssignment As StatusAuditCode = StatusAuditCode.None  ' Kiểm tra có dùng Audit cấp phép năm
    Public geLeaveMasterFiles As StatusAuditCode = StatusAuditCode.None
    Public geLeaveTypes As StatusAuditCode = StatusAuditCode.None
    Public geInquiryFormat As StatusAuditCode = StatusAuditCode.None
    Public geInquiryCriteria As StatusAuditCode = StatusAuditCode.None
    Public geLeaveObjects As StatusAuditCode = StatusAuditCode.None

    'Các AuditCode của AuditLog
    Public AuditCode As String = ""
    'Khóa sổ
    Public Const AuditCodeCloseBook As String = "CloseBook15"
    'Mở sổ
    Public Const AuditCodeOpenBook As String = "OpenBook15"
    'Tăng phép
    Public Const AuditCodeIncreaseLeave As String = "IncreaseLeave"
    'Chấm phép
    Public Const AuditCodeLeaveTransactions As String = "LeaveTransactions"
    'Cấp phép năm
    Public Const AuditCodeLeaveAssignment As String = "LeaveAssignment"
    Public Const AuditCodeLeaveMasterFiles As String = "LeaveMasterFiles"
    Public Const AuditCodeLeaveTypes As String = "LeaveTypes"
    Public Const AuditCodeInquiryFormat As String = "InquiryFormat"
    Public Const AuditCodeInquiryCriteria As String = "InquiryCriteria"
    Public Const AuditCodeLeaveObjects As String = "LeaveObjects"
    'Các biến toàn cục cho Audit
    'Public gbUseAudit As Boolean ' Module này có sử dụng Audit hay không
    Public gsAuditForm As String ' Mã và Tên Form cho in báo cáo (Font VNI)
    Public gsAuditReport As String 'Mã và Tên Report in báo cáo (Font VNI)


    Public geQuantityUnitPrice As StatusAuditCode = StatusAuditCode.None
    Public geProducts As StatusAuditCode = StatusAuditCode.None
    Public geQCVoucher As StatusAuditCode = StatusAuditCode.None
    Public geStages As StatusAuditCode = StatusAuditCode.None
    Public gePriceLists As StatusAuditCode = StatusAuditCode.None
    Public geStandardRoutings As StatusAuditCode = StatusAuditCode.None
    Public geTransactionTypes As StatusAuditCode = StatusAuditCode.None
    Public gePieceworkVouchers45 As StatusAuditCode = StatusAuditCode.None
    Public geDetailPiecework As StatusAuditCode = StatusAuditCode.None
    Public geSystemSetup As StatusAuditCode = StatusAuditCode.None



    'Các AuditCode của AuditLog
    Public Const AuditCodeProducts As String = "Products"
    Public Const AuditCodeStages As String = "Stages"
    Public Const AuditCodeQuantityUnitPrice As String = "Quantity/UnitPrice"
    Public Const AuditCodeQCVoucher As String = "QCVoucher"
    Public Const AuditCodeDetailPiecework As String = "DetailPiecework"
    Public Const AuditCodeSystemSetup As String = "SystemSetup"
    Public Const AuditCodePSalaryCalculation As String = "PSalaryCalculation"
    Public Const AuditCodePSalaryResultDeletion As String = "PSalaryResultDeletion"
    Public Const AuditCodePieceworkVouchers45 As String = "PieceworkVouchers45"
    Public Const AuditCodeStandardRoutings As String = "StandardRoutings"
    Public Const AuditCodeTransactionTypes As String = "TransactionTypes"
    Public Const AuditCodePriceLists As String = "PriceLists"

    'Các biến toàn cục cho Audit

    'Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, Optional ByVal sDesc1 As String = "", Optional ByVal sDesc2 As String = "", Optional ByVal sDesc3 As String = "", Optional ByVal sDesc4 As String = "", Optional ByVal sDesc5 As String = "")
    '    'sEventID = 1: Thêm mới; = 2: Sửa; = 3: Xóa; = 4: In   

    '    ''Module này có dùng Auditlog không
    '    'If Not gbUseAudit Then Exit Sub
    '    ''Mã AuditCode này có sử dụng không
    '    'If Not CheckUseAuditCode(sAuditCode) Then Exit Sub

    '    'Ghi Audit cho mỗi nghiệp vụ
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D91P9106 "
    '    sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
    '    sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLString("15") & COMMA 'ModuleID, varchar[2], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL
    '    ExecuteSQLNoTransaction(sSQL)
    'End Sub

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

            Case AuditCodeIncreaseLeave
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geIncreaseLeave = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geIncreaseLeave = StatusAuditCode.Use
                    Else
                        geIncreaseLeave = StatusAuditCode.NoUse
                    End If
                End If
                Return geIncreaseLeave = StatusAuditCode.Use

            Case AuditCodeLeaveTransactions
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geLeaveTransactions = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geLeaveTransactions = StatusAuditCode.Use
                    Else
                        geLeaveTransactions = StatusAuditCode.NoUse
                    End If
                End If
                Return geLeaveTransactions = StatusAuditCode.Use

            Case AuditCodeLeaveAssignment
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geLeaveAssignment = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geLeaveAssignment = StatusAuditCode.Use
                    Else
                        geLeaveAssignment = StatusAuditCode.NoUse
                    End If
                End If
                Return geLeaveAssignment = StatusAuditCode.Use

            Case AuditCodeLeaveMasterFiles
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geLeaveMasterFiles = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geLeaveMasterFiles = StatusAuditCode.Use
                    Else
                        geLeaveMasterFiles = StatusAuditCode.NoUse
                    End If
                End If
                Return geLeaveMasterFiles = StatusAuditCode.Use

            Case AuditCodeLeaveTypes
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geLeaveTypes = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geLeaveTypes = StatusAuditCode.Use
                    Else
                        geLeaveTypes = StatusAuditCode.NoUse
                    End If
                End If
                Return geLeaveTypes = StatusAuditCode.Use

            Case AuditCodeInquiryFormat
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geInquiryFormat = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geInquiryFormat = StatusAuditCode.Use
                    Else
                        geInquiryFormat = StatusAuditCode.NoUse
                    End If
                End If
                Return geInquiryFormat = StatusAuditCode.Use

            Case AuditCodeInquiryCriteria
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geInquiryCriteria = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geInquiryCriteria = StatusAuditCode.Use
                    Else
                        geInquiryCriteria = StatusAuditCode.NoUse
                    End If
                End If
                Return geInquiryCriteria = StatusAuditCode.Use

            Case AuditCodeLeaveObjects
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geLeaveObjects = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geLeaveObjects = StatusAuditCode.Use
                    Else
                        geLeaveObjects = StatusAuditCode.NoUse
                    End If
                End If
                Return geLeaveObjects = StatusAuditCode.Use
        End Select

    End Function

    Private Function ExistRecordAuditCode(ByVal AuditCode As String) As Boolean
        Dim sSQL As String
        sSQL = "Select 1 From D91T9200  WITH(NOLOCK) Where  Audit =1 And ModuleID= '15'And AuditCode= " & SQLString(AuditCode)
        Return ExistRecord(sSQL)
    End Function


End Module
