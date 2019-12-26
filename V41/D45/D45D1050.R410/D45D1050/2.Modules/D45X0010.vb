''' <summary>
''' Module này dùng để chưá các hàm AuditLog
''' </summary>
Module D45X0010

    '''' <summary>
    '''' Kiểm tra có dùng mã AuditCode không
    '''' </summary>
    'Enum StatusAuditCode
    '    ''' <summary>
    '    ''' Chưa kiểm tra
    '    ''' </summary>
    '    None = 0
    '    ''' <summary>
    '    ''' Kiểm tra có dùng
    '    ''' </summary>
    '    Use = 1
    '    ''' <summary>
    '    ''' Kiểm tra không dùng
    '    ''' </summary>
    '    NoUse = 2
    'End Enum
    'Public geCloseBook As StatusAuditCode = StatusAuditCode.None ' Kiểm tra có dùng Audit Khóa sổ
    'Public geOpenBook As StatusAuditCode = StatusAuditCode.None  ' Kiểm tra có dùng Audit Mở sổ
    'Public geImposePrice As StatusAuditCode = StatusAuditCode.None
    'Public geCalculation As StatusAuditCode = StatusAuditCode.None
    'Public geRILocations As StatusAuditCode = StatusAuditCode.None
    'Public geStockProvisions As StatusAuditCode = StatusAuditCode.None
    ''Các AuditCode của AuditLog
    ''   Public AuditCode As String = ""
    ''Khóa sổ
    'Public Const AuditCodeCloseBook As String = "CloseBook07"
    ''Mở sổ
    'Public Const AuditCodeOpenBook As String = "OpenBook07"

    'Public Const AuditCodeImposePrices As String = "ImposePrices"

    'Public Const AuditCodeCalculation As String = "MEACostCalculation"
    'Public Const AuditCodeStockProvisions As String = "StockProvisions"

    'Public Const AuditCodeRILocations As String = "RILocations"

    ''Các biến toàn cục cho Audit
    ''Public gbUseAudit As Boolean ' Module này có sử dụng Audit hay không
    'Public gsAuditForm As String ' Mã và Tên Form cho in báo cáo (Font VNI)
    'Public gsAuditReport As String 'Mã và Tên Report in báo cáo (Font VNI)
    'Public giModuleAdmin As Int16 ' kiểm tra có ModuleAdmin không (1: có; 0: không).

    ''Public Sub UseAuditLog()
    ''    '#------------------------------------------------------
    ''    '#CreateUser:   Nguyen Thi Minh Hoa
    ''    '#CreateDate:   21/11/2007
    ''    '#ModifiedUser: Nguyen Thi Minh Hoa
    ''    '#ModifiedDate: 21/11/2007
    ''    '#Description: Kiểm tra module này có dùng Audit không? Có trả ra = True, không = False
    ''    '#------------------------------------------------------
    ''    Dim sSQL As String = ""
    ''    sSQL = "Select top 1 1 From D91T9200 Where Audit=1 And ModuleID= '07'"
    ''    gbUseAudit = ExistRecord(sSQL)

    ''End Sub

    'Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, ByVal sDesc1 As String, ByVal sDesc2 As String, Optional ByVal sDesc3 As String = "", Optional ByVal sDesc4 As String = "", Optional ByVal sDesc5 As String = "")
    '    'Module này có dùng Auditlog không
    '    'MsgBox(gbUseAudit)
    '    'If Not gbUseAudit Then Exit Sub
    '    ''Mã AuditCode này có sử dụng không
    '    ''MsgBox(sAuditCode)
    '    'If Not CheckUseAuditCode(sAuditCode) Then Exit Sub
    '    ' MsgBox("D91P9106")
    '    'Ghi Audit cho mỗi nghiệp vụ
    '    Dim sSQL As String = ""
    '    sSQL = "declare @now as datetime set @now=Getdate()" & vbCrLf
    '    sSQL &= "Exec D91P9106 "
    '    sSQL &= "@now" & COMMA 'AuditDate, datetime, NOT NULL
    '    sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLString("07") & COMMA 'ModuleID, varchar[2], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL

    '    ExecuteSQLNoTransaction(sSQL)

    'End Sub

    'Private Function CheckUseAuditCode(ByVal AuditCode As String) As Boolean
    '    Select Case AuditCode
    '        Case AuditCodeCloseBook
    '            'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
    '            If geCloseBook = StatusAuditCode.None Then
    '                If ExistRecordAuditCode(AuditCode) Then
    '                    geCloseBook = StatusAuditCode.Use
    '                Else
    '                    geCloseBook = StatusAuditCode.NoUse
    '                End If
    '            End If
    '            Return geCloseBook = StatusAuditCode.Use

    '        Case AuditCodeOpenBook
    '            'Nếu đã 1 lần kiểm tra mã Audit Code thì lần sau không kiểm tra
    '            If geOpenBook = StatusAuditCode.None Then
    '                If ExistRecordAuditCode(AuditCode) Then
    '                    geOpenBook = StatusAuditCode.Use
    '                Else
    '                    geOpenBook = StatusAuditCode.NoUse
    '                End If
    '            End If
    '            Return geOpenBook = StatusAuditCode.Use

    '        Case AuditCodeImposePrices
    '            If geImposePrice = StatusAuditCode.None Then
    '                If ExistRecordAuditCode(AuditCode) Then
    '                    geImposePrice = StatusAuditCode.Use
    '                Else
    '                    geImposePrice = StatusAuditCode.NoUse
    '                End If
    '            End If
    '            Return geImposePrice = StatusAuditCode.Use

    '        Case AuditCodeCalculation
    '            If geCalculation = StatusAuditCode.None Then
    '                If ExistRecordAuditCode(AuditCode) Then
    '                    geCalculation = StatusAuditCode.Use
    '                Else
    '                    geCalculation = StatusAuditCode.NoUse
    '                End If
    '            End If
    '            Return geCalculation = StatusAuditCode.Use

    '        Case AuditCodeRILocations
    '            If geRILocations = StatusAuditCode.None Then
    '                If ExistRecordAuditCode(AuditCode) Then
    '                    geRILocations = StatusAuditCode.Use
    '                Else
    '                    geRILocations = StatusAuditCode.NoUse
    '                End If
    '            End If
    '            Return geRILocations = StatusAuditCode.Use
    '        Case AuditCodeStockProvisions
    '            If geStockProvisions = StatusAuditCode.None Then
    '                If ExistRecordAuditCode(AuditCode) Then
    '                    geStockProvisions = StatusAuditCode.Use
    '                Else
    '                    geStockProvisions = StatusAuditCode.NoUse
    '                End If
    '            End If
    '            Return geStockProvisions = StatusAuditCode.Use
    '    End Select

    'End Function

    'Private Function ExistRecordAuditCode(ByVal AuditCode As String) As Boolean
    '    Dim sSQL As String
    '    sSQL = "Select 1 From D91T9200 Where  Audit =1 And ModuleID= '07' And AuditCode= " & SQLString(AuditCode)
    '    Return ExistRecord(sSQL)
    'End Function

End Module
