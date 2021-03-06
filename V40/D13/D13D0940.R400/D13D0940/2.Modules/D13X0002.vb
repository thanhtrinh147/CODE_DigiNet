''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D13X0002


    '    ''' <summary>
    '    ''' Thông báo dữ liệu đang được sử dụng , không cho xóa
    '    ''' </summary>
    '    Public Function MsgNotDeleteData() As String
    '        Dim sMsg As String = ""
    '        sMsg = rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_xoa")
    '        Return sMsg
    '    End Function
    '
    '    Public Function InsertFormat(ByVal sStrFormat As String) As String
    '        If IsNumeric(sStrFormat) Then
    '            Return ("#,##0" & InsertZero(Convert.ToInt16(sStrFormat)))
    '        Else
    '            Return ("#,##0" & InsertZero(0))
    '        End If
    '    End Function
    '
    '    Private Function InsertZero(ByVal NumZero As Integer) As String
    '        Dim sRet As String = ""
    '        If NumZero = 0 Then
    '            sRet = ""
    '        Else
    '            sRet = "."
    '            For i As Integer = 0 To NumZero - 1
    '                sRet = sRet & "0"
    '            Next i
    '        End If
    '        Return sRet
    '    End Function
    '
    '    Public Function Round(ByVal Number As Double, ByVal NumZero As Integer) As Double
    '        Dim dNumber As Double = CType(Number, Double)
    '        If NumZero >= 0 Then
    '            Return Math.Round(dNumber, NumZero)
    '        End If
    '        NumZero = -NumZero
    '        Dim d As Double = Math.Pow(10, NumZero)
    '        dNumber = Math.Round(dNumber) / d
    '        Return (Math.Round(dNumber) * d)
    '    End Function
    '
    '    Public Function Round(ByVal Number As Object, ByVal NumZero As Object) As Double
    '        Dim dNumber As Double = CType(Number, Double)
    '        Dim iNumZero As Integer = CType(NumZero, Integer)
    '        If iNumZero >= 0 Then
    '            Return Math.Round(dNumber, iNumZero)
    '        End If
    '        iNumZero = -iNumZero
    '        Dim d As Double = Math.Pow(10, iNumZero)
    '        dNumber = Math.Round(dNumber) / d
    '        Return (Math.Round(dNumber) * d)
    '    End Function
    '
    '#Region "Màn hình chọn đường dẫn báo cáo"
    '    Public Function GetReportPath(ByVal ReportTypeID As String, ByVal ReportName As String, ByVal CustomReport As String, ByRef ReportPath As String, Optional ByRef ReportTitle As String = "", Optional ByVal ModuleID As String = "13") As String
    '        Dim bShowReportPath As Boolean
    '        Dim iReportLanguage As Byte
    '        'Lấy giá trị PARA_ModuleID từ module gọi đến
    '        'Nếu là exe chính (không có biến PARA_ModuleID) thì lấy Dxx 
    '        bShowReportPath = CType(D99C0007.GetModulesSetting("D" & PARA_ModuleID, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
    '        iReportLanguage = CType(D99C0007.GetModulesSetting("D" & PARA_ModuleID, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
    '        'Lấy đường dẫn báo cáo từ module D99X0004
    '        ReportPath = UnicodeGetReportPath(gbUnicode, iReportLanguage, "")
    '        If bShowReportPath Then 'Hiển thị màn hình chọn đường dẫn báo cáo
    '            Dim frm As New D99F6666
    '            With frm
    '                .ModuleID = ModuleID '2 ký tự, tùy theo từng module có thể lấy theo module gốc chứa exe con hoặc module gọi đến.
    '                .ReportTypeID = ReportTypeID
    '                .ReportName = ReportName
    '                .CustomReport = CustomReport
    '                .ReportPath = ReportPath
    '                .ReportTitle = ReportTitle
    '                .ShowDialog()
    '                ReportName = .ReportName
    '                ReportPath = .ReportPath
    '                gsReportPath = ReportPath 'biến toàn cục đang dùng 
    '                ReportTitle = .ReportTitle
    '                SaveOptionReport(.ShowReportPath)
    '                .Dispose()
    '            End With
    '        Else 'Không hiển thị thì lấy theo Loại nghiệp vụ (nếu có)
    '            If CustomReport <> "" Then
    '                ReportPath = Application.StartupPath & "\XCustom\"
    '                ReportName = CustomReport
    '            End If
    '        End If
    '        ReportPath = ReportPath & ReportName & ".rpt"
    '        Return ReportName
    '    End Function
    '    'Tùy thuộc từng module có biến lưu dưới Registry
    '    Public Sub SaveOptionReport(ByVal bShowReportPath As Boolean)
    '        'D99C0007.SaveModulesSetting("D" & PARA_ModuleID, ModuleOption.lmOptions, "ShowReportPath", bShowReportPath)
    '        If "D" & PARA_ModuleID = D13 Then 'Module gốc
    '            'Nếu module nào có thêm code VB6 thì lưu thêm nhánh VB6
    '            'SaveSetting("Lemon3_D05", "Options", "NotShowDirectory", (Not bShowReportPath).ToString) 'Nhánh VB6
    '            D13Options.ShowReportPath = bShowReportPath 'Biến Tùy chọn
    '        End If
    '    End Sub
    '#End Region

    Public Sub SetImageButton(ByVal btnSave As Button, ByVal btnNotSave As Button, ByVal btnNext As Button, ByVal imgButton As ImageList)
        btnSave.Size = New System.Drawing.Size(76, 27)
        btnNext.Size = New System.Drawing.Size(130, 27)
        btnNotSave.Size = New System.Drawing.Size(100, 27)

        btnSave.ImageList = imgButton
        btnSave.ImageIndex = 0
        btnSave.ImageAlign = ContentAlignment.MiddleLeft

        btnNext.ImageList = imgButton
        btnNext.ImageIndex = 1
        btnNext.ImageAlign = ContentAlignment.MiddleLeft

        btnNotSave.ImageList = imgButton
        btnNotSave.ImageIndex = 2
        btnNotSave.ImageAlign = ContentAlignment.MiddleLeft

        btnNotSave.Text = rl3("_Khong_luu")
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
    End Sub

#Region "Audit log"
    'Duyen sua
    Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, Optional ByVal sDesc1 As String = "", Optional ByVal sDesc2 As String = "", Optional ByVal sDesc3 As String = "", Optional ByVal sDesc4 As String = "", Optional ByVal sDesc5 As String = "", Optional ByVal iIsAuditDetail As Integer = 0, Optional ByVal sAuditItemID As String = "")
        'sEventID = 1:Thêm mới;  = 2: Sửa;  = 3: Xóa;  = 4: In   

        'Module này có dùng Auditlog không
        'If Not gbUseAudit Then Exit Sub
        'Mã AuditCode này có sử dụng không
        'If Not CheckUseAuditCode(sAuditCode) Then Exit Sub

        'Ghi Audit cho mỗi nghiệp vụ
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9106 "
        sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("03") & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc5) & COMMA 'Desc5, varchar[250], NOT NULL
        sSQL &= SQLNumber(iIsAuditDetail) & COMMA 'IsAuditDetail, tinyint, NOT NULL
        sSQL &= SQLString(sAuditItemID) 'AuditItemID, varchar[50], NOT NULL
        ExecuteSQLNoTransaction(sSQL)

    End Sub

    'Duyen sua
    Private Function CheckUseAuditCode(ByVal AuditCode As String) As Boolean
        Dim sSQL As String
        sSQL = "Select 1 From D91T9200 WITH(NOLOCK) Where  Audit =1 And ModuleID= '03' And AuditCode= " & SQLString(AuditCode)
        Return ExistRecord(sSQL)
    End Function
#End Region

End Module
