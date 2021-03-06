''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D45X0002
    Public Const AuditCodeProducts As String = "Products"
    Public Const AuditCodeStages As String = "Stages"
    Public Const AuditCodePriceLists As String = "PriceLists"
    Public Const AuditCodeStandardRoutings As String = "StandardRoutings"
    Public Const AuditCodeTransactionTypes As String = "TransactionTypes"
    Public Const AuditCodePieceworkVouchers45 As String = "PieceworkVouchers45"
    Public Const AuditCodePieceworkCalMethodID As String = "PieceworkCalMethodID"
    '#Region "Màn hình chọn đường dẫn báo cáo"

    '    Public Function GetReportPath(ByVal ReportTypeID As String, ByVal ReportName As String, ByVal CustomReport As String, ByRef ReportPath As String, Optional ByRef ReportTitle As String = "", Optional ByVal ModuleID As String = "45") As String
    '        Dim bShowReportPath As Boolean
    '        Dim iReportLanguage As Byte
    '        bShowReportPath = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
    '        iReportLanguage = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
    '        'Lấy đường dẫn báo cáo từ module D99X0004
    '        ReportPath = UnicodeGetReportPath(gbUnicode, iReportLanguage, "")
    '        'Hiển thị màn hình chọn đường dẫn báo cáo
    '        If bShowReportPath Then

    '            Dim frm As New D99F6666
    '            With frm
    '                .ModuleID = ModuleID '2 ký tự
    '                .ReportTypeID = ReportTypeID
    '                .ReportName = ReportName
    '                .CustomReport = CustomReport
    '                .ReportPath = ReportPath
    '                .ReportTitle = ReportTitle
    '                .ShowDialog()
    '                ReportName = .ReportName
    '                ReportPath = .ReportPath
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
    '        'D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", bShowReportPath)
    '        D45Options.ShowReportPath = bShowReportPath 'Biến Tùy chọn
    '    End Sub

    '#End Region

    'Public Sub IsUseBlock()
    '    Dim sSQL As String = ""
    '    sSQL = "Select IsUseBlock From D09T0000 WITH(NOLOCK) "
    '    Dim dt As DataTable = ReturnDataTable(sSQL)
    '    If dt.Rows.Count > 0 Then
    '        bIsUseBlock = Convert.ToBoolean(dt.Rows(0).Item("IsUseBlock"))
    '    Else
    '        bIsUseBlock = False
    '    End If
    'End Sub

    'Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, Optional ByVal sDesc1 As String = "", Optional ByVal sDesc2 As String = "", Optional ByVal sDesc3 As String = "", Optional ByVal sDesc4 As String = "", Optional ByVal sDesc5 As String = "", Optional ByVal ModuleID As String = "45")
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

    '    'Gán caption của 5 combo mã pt
    Public Sub LoadTDBComboAnaCaption(ByVal lblS01ID As Label, ByVal lblS02ID As Label, ByVal lblS03ID As Label, ByVal lblS04ID As Label, ByVal lblS05ID As Label, ByVal tdbcS01ID As C1.Win.C1List.C1Combo, ByVal tdbcS02ID As C1.Win.C1List.C1Combo, ByVal tdbcS03ID As C1.Win.C1List.C1Combo, ByVal tdbcS04ID As C1.Win.C1List.C1Combo, ByVal tdbcS05ID As C1.Win.C1List.C1Combo, Optional ByVal bUnicode As Boolean = False)
        Dim bUseAna As Boolean = False

        Dim sSQL As String = "Select AnaCategoryID, AnaCategoryShort" & UnicodeJoin(bUnicode) & " as AnaCategoryShort, AnaCategoryName" & UnicodeJoin(bUnicode) & " as AnaCategoryName, AnaCategoryStatus, UseD45" & vbCrLf
        sSQL &= "From D91T0050  WITH(NOLOCK) Where AnaTypeID = 'M' Order by AnaCategoryID"
        Dim dt As New DataTable
        dt = ReturnDataTable(sSQL)
        Dim i As Integer
        Dim sValue As String = "", sName As String = ""
        If dt.Rows.Count > 0 Then
            For i = 0 To 4
                sValue = dt.Rows(i).Item("AnaCategoryShort").ToString
                sName = dt.Rows(i).Item("AnaCategoryName").ToString
                Select Case i
                    Case 0
                        lblS01ID.Text = sValue
                        lblS01ID.Tag = sName
                        tdbcS01ID.ReadOnly = Not (Convert.ToBoolean(dt.Rows(i).Item("UseD45")) And Convert.ToBoolean(dt.Rows(i).Item("AnaCategoryStatus")))
                        tdbcS01ID.TabStop = Not tdbcS01ID.ReadOnly
                        If sValue <> "" Then
                            lblS01ID.Font = FontUnicode(bUnicode)
                        End If
                    Case 1
                        lblS02ID.Text = sValue
                        lblS02ID.Tag = sName
                        tdbcS02ID.ReadOnly = Not (Convert.ToBoolean(dt.Rows(i).Item("UseD45")) And Convert.ToBoolean(dt.Rows(i).Item("AnaCategoryStatus")))
                        tdbcS02ID.TabStop = Not tdbcS02ID.ReadOnly
                        If sValue <> "" Then
                            lblS02ID.Font = FontUnicode(bUnicode)
                        End If
                    Case 2
                        lblS03ID.Text = sValue
                        lblS03ID.Tag = sName
                        tdbcS03ID.ReadOnly = Not (Convert.ToBoolean(dt.Rows(i).Item("UseD45")) And Convert.ToBoolean(dt.Rows(i).Item("AnaCategoryStatus")))
                        tdbcS03ID.TabStop = Not tdbcS03ID.ReadOnly
                        If sValue <> "" Then
                            lblS03ID.Font = FontUnicode(bUnicode)
                        End If
                    Case 3
                        lblS04ID.Text = sValue
                        lblS04ID.Tag = sName
                        tdbcS04ID.ReadOnly = Not (Convert.ToBoolean(dt.Rows(i).Item("UseD45")) And Convert.ToBoolean(dt.Rows(i).Item("AnaCategoryStatus")))
                        tdbcS04ID.TabStop = Not tdbcS04ID.ReadOnly
                        If sValue <> "" Then
                            lblS04ID.Font = FontUnicode(bUnicode)
                        End If
                    Case 4
                        lblS05ID.Text = sValue
                        lblS05ID.Tag = sName
                        tdbcS05ID.ReadOnly = Not (Convert.ToBoolean(dt.Rows(i).Item("UseD45")) And Convert.ToBoolean(dt.Rows(i).Item("AnaCategoryStatus")))
                        tdbcS05ID.TabStop = Not tdbcS05ID.ReadOnly
                        If sValue <> "" Then
                            lblS05ID.Font = FontUnicode(bUnicode)
                        End If
                End Select
            Next
        End If
        dt = Nothing
    End Sub

    Public Sub LockTab(ByVal Tab As TabControl, ByVal bEnableCbo As Boolean)

        For Each ctl As Control In Tab.Controls
            If ctl.HasChildren Then
                For Each ctl1 As Control In ctl.Controls
                    If ctl1.GetType.Name = "C1Combo" Then
                        If bEnableCbo = False Then
                            If CType(ctl1, C1.Win.C1List.C1Combo).Enabled = True Or CType(ctl1, C1.Win.C1List.C1Combo).ReadOnly = False Then
                                CType(ctl1, C1.Win.C1List.C1Combo).Tag = False
                            Else
                                CType(ctl1, C1.Win.C1List.C1Combo).AutoDropDown = bEnableCbo
                                CType(ctl1, C1.Win.C1List.C1Combo).Enabled = bEnableCbo
                                CType(ctl1, C1.Win.C1List.C1Combo).Tag = True
                            End If
                        Else
                            If CBool(CType(ctl1, C1.Win.C1List.C1Combo).Tag) = True Then
                                CType(ctl1, C1.Win.C1List.C1Combo).AutoDropDown = bEnableCbo
                                CType(ctl1, C1.Win.C1List.C1Combo).Enabled = bEnableCbo
                            End If

                        End If
                        ctl1.Text = ctl1.Text
                    End If
                Next
                Application.DoEvents()
            Else
                If ctl.GetType.Name = "C1Combo" Then
                    If bEnableCbo = False Then
                        If CType(ctl, C1.Win.C1List.C1Combo).Enabled = True Or CType(ctl, C1.Win.C1List.C1Combo).ReadOnly = False Then
                            CType(ctl, C1.Win.C1List.C1Combo).Tag = False
                        Else
                            CType(ctl, C1.Win.C1List.C1Combo).AutoDropDown = bEnableCbo
                            CType(ctl, C1.Win.C1List.C1Combo).Enabled = bEnableCbo
                            CType(ctl, C1.Win.C1List.C1Combo).Tag = True
                        End If
                    Else
                        If CBool(CType(ctl, C1.Win.C1List.C1Combo).Tag) = True Then
                            CType(ctl, C1.Win.C1List.C1Combo).AutoDropDown = bEnableCbo
                            CType(ctl, C1.Win.C1List.C1Combo).Enabled = bEnableCbo
                        End If

                    End If

                    ctl.Text = ctl.Text
                End If
                Application.DoEvents()
            End If
        Next
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho 5 mã pt
    ''' </summary>
    ''' <remarks>Truyền 5 mã pt cần đổ nguồn vào</remarks>
    Public Sub LoadTDComboAna(ByVal tdbcS01ID As C1.Win.C1List.C1Combo, ByVal tdbcS02ID As C1.Win.C1List.C1Combo, ByVal tdbcS03ID As C1.Win.C1List.C1Combo, ByVal tdbcS04ID As C1.Win.C1List.C1Combo, ByVal tdbcS05ID As C1.Win.C1List.C1Combo, Optional ByVal bUnicode As Boolean = False)
        Dim dt As DataTable

        Dim sSQL As String = ""
        sSQL = "Select D50.AnaCategoryID, D51.AnaID, D51.AnaName" & UnicodeJoin(bUnicode) & " as AnaName" & vbCrLf
        sSQL &= "From D91T0051 D51  WITH(NOLOCK) Inner Join D91T0050 D50  WITH(NOLOCK) On D51.AnaCategoryID = D50.AnaCategoryID" & vbCrLf
        sSQL &= "Where Disabled = 0 And D50.AnaTypeID ='M'" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select '' As AnaCategoryID, '+' As AnaID, " & NewName & " As AnaName" & vbCrLf
        sSQL &= "Order by D51.AnaID"
        dt = ReturnDataTable(sSQL)


        LoadDataSource(tdbcS01ID, ReturnTableFilter(dt, "AnaCategoryID='M01' Or AnaID='+'"), bUnicode)
        LoadDataSource(tdbcS02ID, ReturnTableFilter(dt, "AnaCategoryID='M02' Or AnaID='+'"), bUnicode)
        LoadDataSource(tdbcS03ID, ReturnTableFilter(dt, "AnaCategoryID='M03' Or AnaID='+'"), bUnicode)
        LoadDataSource(tdbcS04ID, ReturnTableFilter(dt, "AnaCategoryID='M04' Or AnaID='+'"), bUnicode)
        LoadDataSource(tdbcS05ID, ReturnTableFilter(dt, "AnaCategoryID='M05' Or AnaID='+'"), bUnicode)

    End Sub

    Public Sub LoadTDComboAna(ByVal tdbc As C1.Win.C1List.C1Combo, Optional ByVal bUnicode As Boolean = False)
        Dim sSQL As String = ""
        Dim sWhere As String = ""

        If tdbc.Name = "tdbcS01ID" Then
            sWhere = "M01"
        ElseIf tdbc.Name = "tdbcS02ID" Then
            sWhere = "M02"
        ElseIf tdbc.Name = "tdbcS03ID" Then
            sWhere = "M03"
        ElseIf tdbc.Name = "tdbcS04ID" Then
            sWhere = "M04"
        ElseIf tdbc.Name = "tdbcS05ID" Then
            sWhere = "M05"
        End If

        sSQL = "Select D50.AnaCategoryID, D51.AnaID, D51.AnaName" & UnicodeJoin(bUnicode) & " as AnaName" & vbCrLf
        sSQL &= "From D91T0051 D51  WITH(NOLOCK) Inner Join D91T0050 D50  WITH(NOLOCK) On D51.AnaCategoryID = D50.AnaCategoryID" & vbCrLf
        sSQL &= "Where Disabled = 0 And D50.AnaCategoryID = " & SQLString(sWhere) & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select '' As AnaCategoryID, '+' As AnaID, " & NewName & " As AnaName" & vbCrLf
        sSQL &= "Order by D51.AnaID"
        LoadDataSource(tdbc, sSQL, bUnicode)
    End Sub

    '    'Ktra dữ liệu trùng trên lưới
    '    ''' <param name="c1Grid">luoi can ktra</param>
    '    ''' <param name="iCol">cot du lieu can ktra trung</param>
    '    ''' <param name="sValue">Gia tri can ktra</param>
    '    ''' <param name="iRow">dong dang dung</param>
    '    ''' <remarks>Gọi hàm tại sự kiện KeyDown của lưới </remarks>
    Public Function ExitsValue(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As Integer, ByVal sValue As String, ByVal iRow As Int32) As Boolean
        For i As Integer = 0 To c1Grid.RowCount - 1
            If i <> iRow And c1Grid.Item(i, iCol).ToString = sValue Then
                Return True
            End If
        Next
        Return False
    End Function

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

End Module
