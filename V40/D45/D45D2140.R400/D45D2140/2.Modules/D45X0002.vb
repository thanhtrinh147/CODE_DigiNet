''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D45X0002
    Public Sub SetImageButton(ByVal btnSave As Button, ByVal btnNotSave As Button, ByVal imgButton As ImageList)
        btnSave.Size = New System.Drawing.Size(76, 27)
        btnNotSave.Size = New System.Drawing.Size(100, 27)

        btnSave.ImageList = imgButton
        btnSave.ImageIndex = 0
        btnSave.ImageAlign = ContentAlignment.MiddleLeft

        btnNotSave.ImageList = imgButton
        btnNotSave.ImageIndex = 1
        btnNotSave.ImageAlign = ContentAlignment.MiddleLeft

        btnSave.Text = rL3("_Luu") '&Lưu
        btnNotSave.Text = rL3("_Khong_luu")
    End Sub
    Public Sub IsUseBlock()
        Dim sSQL As String = "Select IsUseBlock From D09T0000 WITH(NOLOCK) "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            D45Systems.IsUseBlock = Convert.ToBoolean(dt.Rows(0).Item("IsUseBlock"))
        Else
            D45Systems.IsUseBlock = False
        End If
    End Sub

#Region "KeyboardCues"

    Private Declare Function SystemParametersInfoSet Lib "user32.dll" Alias "SystemParametersInfoW" (ByVal action As Integer, ByVal param As Integer, ByVal value As Integer, ByVal winini As Boolean) As Boolean
    Private Const SPI_SETKEYBOARDCUES As Integer = &H100B

    Public Sub KeyboardCues()
        SystemParametersInfoSet(SPI_SETKEYBOARDCUES, 0, 1, False)
    End Sub
#End Region

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
    'Public Sub ClearTag(ByVal ctrl As Control)
    '    If TypeOf (ctrl) Is C1.Win.C1Input.C1DateEdit Then
    '        CType(ctrl, C1.Win.C1Input.C1DateEdit).Tag = ""
    '    ElseIf TypeOf (ctrl) Is C1.Win.C1Input.C1NumericEdit Then
    '        CType(ctrl, C1.Win.C1Input.C1NumericEdit).Tag = ""
    '    ElseIf (TypeOf (ctrl) Is TextBox Or TypeOf (ctrl) Is C1.Win.C1List.C1Combo) Then
    '        'Update 15/08/2013: Filter Bar trên lưới có TypeOf là TextBox nên chạy vào điều kiện này
    '        'ctrl.Text = ""
    '        If ctrl.Name <> "" Then ctrl.Tag = ""
    '    End If

    '    For Each childControl As Control In ctrl.Controls
    '        ClearTag(childControl)
    '    Next
    'End Sub
End Module
