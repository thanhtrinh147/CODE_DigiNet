''' <summary>
''' Module này dùng để chưá các hàm AuditLog
''' </summary>
Module D45X0010

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

    'Các biến toàn cục cho Audit
    'Public gbUseAudit As Boolean ' Module này có sử dụng Audit hay không
    Public gsAuditForm As String ' Mã và Tên Form cho in báo cáo (Font VNI)
    Public gsAuditReport As String 'Mã và Tên Report in báo cáo (Font VNI)

    Public geCloseBook As StatusAuditCode = StatusAuditCode.None ' Kiểm tra có dùng Audit Khóa sổ
    Public geOpenBook As StatusAuditCode = StatusAuditCode.None  ' Kiểm tra có dùng Audit Mở sổ
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

    'Khóa sổ 
    Public Const AuditCodeCloseBook As String = "CloseBook45"
    'Mở sổ 
    Public Const AuditCodeOpenBook As String = "OpenBook45"

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
    '    sSQL &= SQLString(ModuleID) & COMMA 'ModuleID, varchar[2], NOT NULL
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
            Case AuditCodeQuantityUnitPrice
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geQuantityUnitPrice = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geQuantityUnitPrice = StatusAuditCode.Use
                    Else
                        geQuantityUnitPrice = StatusAuditCode.NoUse
                    End If
                End If
                Return geQuantityUnitPrice = StatusAuditCode.Use
            Case AuditCodeProducts
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geProducts = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geProducts = StatusAuditCode.Use
                    Else
                        geProducts = StatusAuditCode.NoUse
                    End If
                End If
                Return geProducts = StatusAuditCode.Use
            Case AuditCodeQCVoucher
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geQCVoucher = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geQCVoucher = StatusAuditCode.Use
                    Else
                        geQCVoucher = StatusAuditCode.NoUse
                    End If
                End If
                Return geQCVoucher = StatusAuditCode.Use
            Case AuditCodeStages
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geStages = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geStages = StatusAuditCode.Use
                    Else
                        geStages = StatusAuditCode.NoUse
                    End If
                End If
                Return geStages = StatusAuditCode.Use
            Case AuditCodePriceLists
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If gePriceLists = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        gePriceLists = StatusAuditCode.Use
                    Else
                        gePriceLists = StatusAuditCode.NoUse
                    End If
                End If
                Return gePriceLists = StatusAuditCode.Use
            Case AuditCodeStandardRoutings
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geStandardRoutings = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geStandardRoutings = StatusAuditCode.Use
                    Else
                        geStandardRoutings = StatusAuditCode.NoUse
                    End If
                End If
                Return geStandardRoutings = StatusAuditCode.Use
            Case AuditCodeTransactionTypes
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geTransactionTypes = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geTransactionTypes = StatusAuditCode.Use
                    Else
                        geTransactionTypes = StatusAuditCode.NoUse
                    End If
                End If
                Return geTransactionTypes = StatusAuditCode.Use
            Case AuditCodePieceworkVouchers45
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If gePieceworkVouchers45 = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        gePieceworkVouchers45 = StatusAuditCode.Use
                    Else
                        gePieceworkVouchers45 = StatusAuditCode.NoUse
                    End If
                End If
                Return gePieceworkVouchers45 = StatusAuditCode.Use
            Case AuditCodeDetailPiecework
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geDetailPiecework = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geDetailPiecework = StatusAuditCode.Use
                    Else
                        geDetailPiecework = StatusAuditCode.NoUse
                    End If
                End If
                Return geDetailPiecework = StatusAuditCode.Use
                Return gePieceworkVouchers45 = StatusAuditCode.Use
            Case AuditCodeSystemSetup
                'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
                If geSystemSetup = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geSystemSetup = StatusAuditCode.Use
                    Else
                        geSystemSetup = StatusAuditCode.NoUse
                    End If
                End If
                Return geSystemSetup = StatusAuditCode.Use
        End Select

    End Function

    Private Function ExistRecordAuditCode(ByVal AuditCode As String) As Boolean
        Dim sSQL As String
        sSQL = "Select 1 From D91T9200  WITH(NOLOCK) Where  Audit =1 And ModuleID= '" & ModuleID & "' And AuditCode= " & SQLString(AuditCode)
        Return ExistRecord(sSQL)
    End Function

End Module

