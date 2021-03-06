''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D45X0002

#Region "Màn hình chọn đường dẫn báo cáo"

    Public Function GetReportPath(ByVal ReportTypeID As String, ByVal ReportName As String, ByVal CustomReport As String, ByRef ReportPath As String, Optional ByRef ReportTitle As String = "", Optional ByVal ModuleID As String = "45") As String
        Dim bShowReportPath As Boolean
        Dim iReportLanguage As Byte
        bShowReportPath = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
        iReportLanguage = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
        'Lấy đường dẫn báo cáo từ module D99X0004
        ReportPath = UnicodeGetReportPath(gbUnicode, iReportLanguage, "")
        'Hiển thị màn hình chọn đường dẫn báo cáo
        If bShowReportPath Then

            Dim frm As New D99F6666
            With frm
                .ModuleID = ModuleID '2 ký tự
                .ReportTypeID = ReportTypeID
                .ReportName = ReportName
                .CustomReport = CustomReport
                .ReportPath = ReportPath
                .ReportTitle = ReportTitle
                .ShowDialog()
                ReportName = .ReportName
                ReportPath = .ReportPath
                ReportTitle = .ReportTitle
                SaveOptionReport(.ShowReportPath)
                .Dispose()
            End With
        Else 'Không hiển thị thì lấy theo Loại nghiệp vụ (nếu có)
            If CustomReport <> "" Then
                ReportPath = gsApplicationSetup & "\XCustom\"
                ReportName = CustomReport
            End If
        End If
        ReportPath = ReportPath & ReportName & ".rpt"
        Return ReportName
    End Function

    'Tùy thuộc từng module có biến lưu dưới Registry
    Public Sub SaveOptionReport(ByVal bShowReportPath As Boolean)
        'D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", bShowReportPath)
        D45Options.ShowReportPath = bShowReportPath 'Biến Tùy chọn
    End Sub

#End Region

    Public Function CbVal(ByVal tdbc As C1.Win.C1List.C1Combo) As String
        If tdbc.SelectedValue Is Nothing OrElse tdbc.Text = "" Then
            Return ""
        End If
        Return tdbc.SelectedValue.ToString
    End Function

    'Public Sub GetPieceWorkMethod()
    '    Dim sSQL As String = ""
    '    sSQL = "Select D45.PieceWorkMethod From D45T5550 D45  WITH(NOLOCK) Where UserID=" & SQLString(gsUserID)
    '    Dim dt As DataTable = ReturnDataTable(sSQL)
    '    If dt.Rows.Count > 0 Then
    '        iPieceWorkMethod = L3Int(dt.Rows(0).Item("PieceWorkMethod").ToString)
    '    Else
    '        iPieceWorkMethod = 1
    '    End If

    'End Sub
End Module
