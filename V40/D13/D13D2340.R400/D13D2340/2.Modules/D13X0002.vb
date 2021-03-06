''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D13X0002


    ''' <summary>
    ''' Thông báo dữ liệu đang được sử dụng , không cho xóa
    ''' </summary>
    Public Function MsgNotDeleteData() As String
        Dim sMsg As String = ""
        sMsg = rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_xoa")
        Return sMsg
    End Function

    Public Function InsertFormat(ByVal sStrFormat As String) As String
        If IsNumeric(sStrFormat) Then
            Return ("#,##0" & InsertZero(Convert.ToInt16(sStrFormat)))
        Else
            Return ("#,##0" & InsertZero(0))
        End If
    End Function

    Private Function InsertZero(ByVal NumZero As Integer) As String
        Dim sRet As String = ""
        If NumZero = 0 Then
            sRet = ""
        Else
            sRet = "."
            For i As Integer = 0 To NumZero - 1
                sRet = sRet & "0"
            Next i
        End If
        Return sRet
    End Function

    Public Function Round(ByVal Number As Double, ByVal NumZero As Integer) As Double
        Dim dNumber As Double = CType(Number, Double)
        If NumZero >= 0 Then
            Return Math.Round(dNumber, NumZero)
        End If
        NumZero = -NumZero
        Dim d As Double = Math.Pow(10, NumZero)
        dNumber = Math.Round(dNumber) / d
        Return (Math.Round(dNumber) * d)
    End Function

    Public Function Round(ByVal Number As Object, ByVal NumZero As Object) As Double
        Dim dNumber As Double = CType(Number, Double)
        Dim iNumZero As Integer = CType(NumZero, Integer)
        If iNumZero >= 0 Then
            Return Math.Round(dNumber, iNumZero)
        End If
        iNumZero = -iNumZero
        Dim d As Double = Math.Pow(10, iNumZero)
        dNumber = Math.Round(dNumber) / d
        Return (Math.Round(dNumber) * d)
    End Function

#Region "Màn hình chọn đường dẫn báo cáo"
    Public Function GetReportPath(ByVal ReportTypeID As String, ByVal ReportName As String, ByVal CustomReport As String, ByRef ReportPath As String, Optional ByRef ReportTitle As String = "", Optional ByVal ModuleID As String = "13") As String
        Dim bShowReportPath As Boolean
        Dim iReportLanguage As Byte
        'Lấy giá trị PARA_ModuleID từ module gọi đến
        'Nếu là exe chính (không có biến PARA_ModuleID) thì lấy Dxx 
        bShowReportPath = CType(D99C0007.GetModulesSetting("D" & PARA_ModuleID, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
        iReportLanguage = CType(D99C0007.GetModulesSetting("D" & PARA_ModuleID, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
        'Lấy đường dẫn báo cáo từ module D99X0004
        ReportPath = UnicodeGetReportPath(gbUnicode, iReportLanguage, "")
        If bShowReportPath Then 'Hiển thị màn hình chọn đường dẫn báo cáo
            Dim frm As New D99F6666
            With frm
                .ModuleID = ModuleID '2 ký tự, tùy theo từng module có thể lấy theo module gốc chứa exe con hoặc module gọi đến.
                .ReportTypeID = ReportTypeID
                .ReportName = ReportName
                .CustomReport = CustomReport
                .ReportPath = ReportPath
                .ReportTitle = ReportTitle
                .ShowDialog()
                ReportName = .ReportName
                ReportPath = .ReportPath
                gsReportPath = ReportPath 'biến toàn cục đang dùng 
                ReportTitle = .ReportTitle
                SaveOptionReport(.ShowReportPath)
                .Dispose()
            End With
        Else 'Không hiển thị thì lấy theo Loại nghiệp vụ (nếu có)
            If CustomReport <> "" Then
                ReportPath = Application.StartupPath & "\XCustom\"
                ReportName = CustomReport
            End If
        End If
        ReportPath = ReportPath & ReportName & ".rpt"
        Return ReportName
    End Function
    'Tùy thuộc từng module có biến lưu dưới Registry
    Public Sub SaveOptionReport(ByVal bShowReportPath As Boolean)
        'D99C0007.SaveModulesSetting("D" & PARA_ModuleID, ModuleOption.lmOptions, "ShowReportPath", bShowReportPath)
        If "D" & PARA_ModuleID = D13 Then 'Module gốc
            'Nếu module nào có thêm code VB6 thì lưu thêm nhánh VB6
            'SaveSetting("Lemon3_D05", "Options", "NotShowDirectory", (Not bShowReportPath).ToString) 'Nhánh VB6
            D13Options.ShowReportPath = bShowReportPath 'Biến Tùy chọn
        End If
    End Sub
#End Region

End Module
