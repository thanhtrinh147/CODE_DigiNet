Imports System.Data
Imports System
Imports System.Windows.Forms
'#-------------------------------------------------------------------------------------
'# Title: D09U2223
'# Created User: Nguyễn Hoàng Long
'# Created Date: 15/07/2009 1:53:15 PM
'# Modify User: Nguyễn Thị Minh Hòa
'# Modify Date: 30/09/2009 1:53:09 PM
'# Description: UserControl D09U2223 (dùng chung cho nhóm G4) chứa nội dung cảnh báo
'#-------------------------------------------------------------------------------------
Public Class D09U2223
    Dim sCusomizedReportID As String = ""
    Dim dt As DataTable
    Dim iperD09F2010 As Integer = 0
    Dim iPerD09F2130 As Integer = 0
    Dim iPerD15F2050 As Integer = 0
    Dim iPerD15F1010 As Integer = 0
    Dim iperPrint As Integer = 0
    Dim iperD21F3010 As Integer = 0
    Dim iperD13F1038 As Integer = 0

#Region "Properties"

    Private _alertBaseID As String
    Public Property AlertBaseID() As String
        Get
            Return _alertBaseID
        End Get
        Set(ByVal Value As String)
            _alertBaseID = Value
        End Set
    End Property

    Private _IsDispose As Boolean
    Public ReadOnly Property IsDispose() As Boolean
        Get
            Return _IsDispose
        End Get
    End Property

    Private _alertCode As String
    Public Property AlertCode() As String
        Get
            Return _alertCode
        End Get
        Set(ByVal Value As String)
            _alertCode = Value
        End Set
    End Property

    Private _sQLQuery As String
    Public WriteOnly Property SQLQuery() As String
        Set(ByVal Value As String)
            _sQLQuery = Value
        End Set
    End Property

    Private _alertMessage As String
    Public WriteOnly Property AlertMessage() As String
        Set(ByVal Value As String)
            _alertMessage = Value
            lblMessage.Text = ConvertVniToUnicode(_alertMessage)
        End Set
    End Property

    Private _moduleID As String
    Public Property ModuleID() As String
        Get
            Return _moduleID
        End Get
        Set(ByVal Value As String)
            _moduleID = Value
        End Set
    End Property

    Private _formPermision As String
    Public Property FormPermision() As String
        Get
            Return _formPermision
        End Get
        Set(ByVal Value As String)
            _formPermision = Value
        End Set
    End Property
#End Region

#Region "Sự kiện của form"

    Private Sub mnuRefesh_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRefesh.Click
        ReplaceQuery()
        dt = ReturnDataTable(_sQLQuery)
        FillDataGrid(True)
    End Sub

    Private Sub picClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picClose.Click
        _IsDispose = True
        D09U2223_Disposed(sender, e)
    End Sub

    Private Sub D09U2223_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.Dispose()
    End Sub

    Private Sub D09U2223_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            Select Case _alertBaseID
                Case "D82A1301"
                    If e.KeyCode = Keys.F Then e.Handled = True
                Case "D82A1302"
                    If e.KeyCode = Keys.F Then e.Handled = True
                Case "D82A1303"

                Case "D82A1304"
                    If e.KeyCode = Keys.F Then e.Handled = True
            End Select
        End If
    End Sub


    Private Sub D09U2223_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' gbEnabledUseFind = False
        LoadLanguage()
        SetShortcutPopupMenu(C1CommandHolder)
        If _moduleID = "13" Then tdbg.AllowUpdate = True
        '************************************************
        'Add phim tat cho menu
        C1CommandHolder.SmoothImages = False
        C1CommandHolder.Commands("mnuLaborContract").Shortcut = Shortcut.CtrlL
        C1CommandHolder.Commands("mnuUpdateInfo").Shortcut = Shortcut.CtrlC
        C1CommandHolder.Commands("mnuTransactionLeaveAssignment").Shortcut = Shortcut.CtrlM
        C1CommandHolder.Commands("mnuRefesh").Shortcut = Shortcut.CtrlR
        C1CommandHolder.Commands("mnuUpdateLeaveDay").Shortcut = Shortcut.CtrlI
        C1CommandHolder.Commands("mnuSetTransaction").Shortcut = Shortcut.CtrlU
        C1CommandHolder.Commands("mnuPITBalance").Shortcut = Shortcut.CtrlQ

        C1CommandHolder.Commands("mnuSalaryProposal").Shortcut = Shortcut.CtrlX
        SetResolutionForm(Me)
        ' C1CommandHolder.Commands("mnuUpdateSalaryMonth").Shortcut = Shortcut.CtrlH
    End Sub
#End Region

    'MaiDuyen update 16/11/2009
    'Goi phan quyen 1 lan duy nhat
    Public Sub LoadPermission()
        iperD09F2010 = ReturnPermission("D09F2010")
        iPerD09F2130 = ReturnPermission("D09F2130")
        iPerD15F2050 = ReturnPermission("D15F2050")
        iPerD15F1010 = ReturnPermission("D15F1010")
        iperD21F3010 = ReturnPermission("D21F3010")
        iperD13F1038 = ReturnPermission("D13F1038")

        'Phan quyen cho mnu in 
        iperPrint = ReturnPermission(_formPermision)
    End Sub

#Region "Các hàm Public"
    'MaiDuyen update 03/09/2009
    Public Sub LoadLanguage()
        mnuPrint.Text = rl3("InU")
        'mnuLaborContract.Text = rl3("Lap_hop_dong_lao_dong")
        'mnuUpdateInfo.Text = rl3("Cap_nhat_thong_tin")
        mnuTransactionLeaveAssignment.Text = rl3("Cap_phep_nam") 'Cấp phép nă&m
        mnuUpdateLeaveDay.Text = rl3("Cap_nhat_ngay_tinh_phep") 'Cập nhật ngày tính phép
        ' mnuSetTransaction.Text = rl3("_Cap_nhat_HSL_goc") '&Cập nhật HSL gốc
        ' 27/3/2013 id 64362
        mnuSetTransaction.Text = rL3("_Cap_nhat_dieu_chinh_luong") '&Cập nhật điều chỉnh lương
        mnuPITBalance.Text = rl3("_Quyet_toan_thue_TNCN") '&Quyết toán thuế TNCN
        'Update 07/12/2011: thêm menu Đề xuất điều chỉnh lương
        mnuSalaryProposal.Text = rl3("De__xuat_dieu_chinh_luong") 'Đề &xuất điều chỉnh lương
        'Update 19/03/2013: incident 46423 thêm menu Điều chỉnh lương
        mnuSalaryAdjust.Text = rl3("Dieu_chinh_luong") 'Điều chỉnh lương
        mnuUpdateFamilyDeductionValidationDate.Text = rl3("Cap_nhat__hieu_luc_giam_tru_gia_canh") 'Cập nhật &hiệu lực giảm trừ gia cảnh

        'Update 27/12/2011: incident 45370 thêm menu Cập nhật hồ sơ lương tháng
        'mnuUpdateSalaryMonth.Text = rl3("Cap_nhat_ho_so_luong_thang")
        mnuUpdate.Text = rl3("Cap_nhat_ho_so_luong_thang")
        ' Lưu ý: set lại caption duoi hàm C1ContextMenu_Popup
        mnuUpdatePayrollFile.Text = rl3("Cap_nhat_ho_so_luong_thang") 'rl3("Cap_nhat_HSL_thang") 'Cập nhật HSL

        mnuFind.Text = rl3("Tim__kiem")
        mnuListAll.Text = rl3("_Liet_ke_tat_ca")

        mnuFilterEmployee.Text = rL3("Sang_loc_nhan_vienU")
    End Sub

    Public Sub FieldCaption()
        'LoadLanguage()
        '--------------------Add động các cột--------------------
        'Dim sSQL As String
        'sSQL = "Select FieldName, FieldCaption  " & vbCrLf
        'sSQL &= "From D82T0120 " & vbCrLf
        'sSQL &= "Where AlertBaseID = " & SQLString(_alertBaseID) & " And Language = " & SQLString(gsLanguage) & vbCrLf
        'sSQL &= "Order by OrderNum"

        Dim dt As DataTable
        dt = ReturnDataTable(SQLStoreD09P8220)

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                For i As Integer = 0 To tdbg.Columns.Count - 1
                    If dr("FieldName").ToString = tdbg.Columns(i).DataField Then
                        tdbg.Columns(i).Caption = dr("FieldCaption").ToString
                    End If
                Next i
            Next
            FooterTotalGrid(tdbg, 1)
            tdbg.Refresh()
        End If
    End Sub

    Public Function LoadTDBGrid() As Boolean
        ReplaceQuery()
        dt = ReturnDataTable(_sQLQuery)
        If dt.Rows.Count > 0 Then
            CreateColumns()
            FillDataGrid()
            Return True
        Else
            Return False
        End If

    End Function
#End Region

#Region "Các hàm Private"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P8220
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 20/04/2011 01:40:02
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P8220() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P8220 "
        sSQL &= SQLString(_alertBaseID) & COMMA 'AlertBaseID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLString(_moduleID) & COMMA 'Module, varchar[2], NOT NULL
        sSQL &= SQLString(_alertCode) 'AlertCode, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P0000
    '# Created User: Thanh Huyền
    '# Created Date: 13/05/2010 02:32:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P0000() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D21P1000 "
        sSQL &= SQLString(_alertBaseID) & COMMA 'AlertBaseID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub CreateColumns()
        '--------------------Add động các cột--------------------
        ResetColorGrid(tdbg)
        Dim sSQL As String

        If _moduleID = "21" Then
            sSQL = SQLStoreD12P0000()
        Else
            'sSQL = "Select OrderNum, FieldName, FieldCaption, FieldWidth, FieldType, IsFilter, ReturnField, Length  " & vbCrLf
            'sSQL &= "From D82T0120 " & vbCrLf
            'sSQL &= "Where AlertBaseID = " & SQLString(_alertBaseID) & " And Language = " & SQLString(gsLanguage) & vbCrLf
            'sSQL &= "Order by OrderNum"
            sSQL = SQLStoreD09P8220()
        End If

        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)

        Dim dtGrid As New DataTable
        Dim nWidth As Integer = 80
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        Dim sFieldType As String = "S"
        Dim sysDataType As System.Type
        Dim iGridCollumns As Integer = 0
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("FieldCaption").ToString = "" Then Continue For
            sFieldType = dt.Rows(i).Item("FieldType").ToString
            Select Case sFieldType
                Case "S"
                    sysDataType = System.Type.GetType("System.String")
                Case "N"
                    sysDataType = System.Type.GetType("System.Double")
                Case "D"
                    sysDataType = System.Type.GetType("System.DateTime")
                Case Else
                    sysDataType = System.Type.GetType("System.String")
            End Select

            dtGrid.Columns.Add(dt.Rows(i).Item("FieldName").ToString, sysDataType)

            col = New C1.Win.C1TrueDBGrid.C1DataColumn
            col.DataField = dt.Rows(i).Item("FieldName").ToString
            'Update 16/07/2013 ID 57892 : Nếu có thay đổi tên resource
            Dim sFieldCaption As String = dt.Rows(i).Item("FieldCaption").ToString
            If sFieldType = "S" Then
                'Update 16/07/2013: Nếu có thay đổi tên resource
                If giReplacResource <> 0 Then
                    sFieldCaption = ReplaceResourceCustom(sFieldCaption)
                End If
            End If
            col.Caption = sFieldCaption
            '  col.Caption = dt.Rows(i).Item("FieldCaption").ToString

            If sFieldType = "N" Then
                col.NumberFormat = "#,##0.00"
            ElseIf sFieldType = "D" Then
                col.NumberFormat = "Short Date"
            End If

            tdbg.Columns.Add(col)
            ' update 11/10/2013 id 60469 - Nếu ColumnType = ‘H’ thì ẩn cột  có FielName tương ứng trên lưới cảnh báo
            If dt.Rows(i).Item("ColumnType").ToString = "H" Then
                tdbg.Splits(0).DisplayColumns(col).Visible = False
            Else
                tdbg.Splits(0).DisplayColumns(col).Visible = True
                'ANHVU
                tdbg.Splits(0).DisplayColumns(col).Width = L3Int(dt.Rows(i).Item("FieldWidth")) + 1 'Không cộng 1 bị lỗi ????? 
                tdbg.Splits(0).DisplayColumns(col).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            End If

            Select Case sFieldType
                Case "S"
                    tdbg.Splits(0).DisplayColumns(col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                Case "N"
                    tdbg.Splits(0).DisplayColumns(col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                Case "D"
                    tdbg.Splits(0).DisplayColumns(col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                    InputDateInTrueDBGrid(tdbg, i)
            End Select
            '--------------------------------------
            'Xu ly neu co cot Chon
            If tdbg.Columns(iGridCollumns).DataField = "IsUsed" Then
                tdbg.Columns(iGridCollumns).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
                tdbg.Splits(0).DisplayColumns(col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Else
                tdbg.Splits(0).DisplayColumns(col).Locked = True
                tdbg.Splits(0).DisplayColumns(col).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            End If

            iGridCollumns = iGridCollumns + 1
        Next
    End Sub


#Region "Active Find - List All (Client)"
    Dim dtCaptionCols As DataTable

    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
            'Những cột bắt buộc nhập
            Dim Arr As New ArrayList
            AddColVisible(tdbg, SPLIT0, Arr, , False, False, gbUnicode)
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        End If
        Dim arrFieldExclude() As String = {"IsUsed"}
        ShowFindDialogClient(Finder, dtCaptionCols, Me.Name, "0", gbUnicode, arrFieldExclude)
    End Sub

    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
        sFind = ResultWhereClause.ToString()
        ReLoadTDBGrid()
    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dt.DefaultView.RowFilter = strFind
        ' Nếu lưới có Group thì bổ sung thêm 2 đoạn lệnh sau:
        'tdbg.WrapCellPointer = tdbg.RowCount > 0
        ResetGrid()
    End Sub
    Private Sub ResetGrid()
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, False)
        CheckMenuOther()
        FooterTotalGrid(tdbg, 1)
    End Sub
#End Region

    Private Sub FillDataGrid(Optional ByVal bReLoad As Boolean = False)
        gbEnabledUseFind = dt.Rows.Count > 0
        dt.AcceptChanges()
        LoadDataSource(tdbg, dt)

        ' update 4/4/2013 id 55558 Load iPer trước ReLoadTDBGrid 
        If Not bReLoad Then
            'MaiDuyen update 16/11/2009
            LoadPermission()
        End If

        ReLoadTDBGrid()
        If Not bReLoad Then

            '            'MaiDuyen update 16/11/2009
            '            LoadPermission()

            mnuPrint.Visible = False
            mnuLaborContract.Visible = False 'Menu Lập hợp đồng
            mnuUpdateInfo.Visible = False  'Menu Cập nhật thông tin
            mnuTransactionLeaveAssignment.Visible = False 'Menu Cấp phép năm
            mnuUpdateLeaveDay.Visible = False 'Cập nhật ngày tính phép

            mnuSetTransaction.Visible = False
            mnuPITBalance.Visible = False
            mnuSalaryProposal.Visible = False
            mnuSalaryAdjust.Visible = False
            'mnuUpdateSalaryMonth.Visible = False
            mnuUpdate.Visible = False

            mnuFind.Visible = False
            mnuListAll.Visible = False
            mnuUpdatePayrollFile.Visible = False
            mnuUpdateFamilyDeductionValidationDate.Visible = False

            mnuFilterEmployee.Visible = False 'Sàng lọc nhân viên ID 107141 18.05.2018
            Dim bVisibleEmpTemp As Boolean = ReturnPermission("D82F3015") > 0
            Select Case _alertBaseID
                Case "D82A1301"
                    mnuSetTransaction.Visible = True

                Case "D82A1302"
                    mnuPITBalance.Visible = True
                    mnuPITBalance.Enabled = tdbg.RowCount > 0
                    C1CommandLink4.Delimiter = False
                Case "D82A1303"
                    mnuFind.Visible = True
                    mnuListAll.Visible = True
                    mnuSalaryProposal.Visible = True
                    mnuSalaryProposal.Enabled = tdbg.RowCount > 0
                    mnuSalaryAdjust.Visible = True
                    mnuSalaryAdjust.Enabled = tdbg.RowCount > 0
                    mnuFilterEmployee.Visible = bVisibleEmpTemp
                    mnuFilterEmployee.Enabled = tdbg.RowCount > 0
                Case "D82A1304"
                    mnuUpdate.Visible = True
                    mnuUpdate.Enabled = tdbg.RowCount > 0
                Case "D82A1305" ' update 26/4/2013 id 54222
                    mnuUpdatePayrollFile.Visible = True
                    mnuUpdatePayrollFile.Enabled = tdbg.RowCount > 0
                Case "D82A1306" ' update 5/8/2013 id 56746 - cập nhật HSL tháng nghiệp vụ bổ nhiệm
                    mnuUpdatePayrollFile.Visible = True
                    mnuUpdatePayrollFile.Enabled = tdbg.RowCount > 0
                Case "D82A1307" ' update 19/12/2013 id  - Cập nhật &hiệu lực giảm trừ gia cảnh
                    mnuUpdateFamilyDeductionValidationDate.Visible = True
                    mnuUpdateFamilyDeductionValidationDate.Enabled = tdbg.RowCount > 0 And iperD13F1038 >= 2
            End Select

            If mnuUpdateLeaveDay.Visible Then
                If mnuLaborContract.Visible = False And mnuUpdateInfo.Visible = False Then
                    mnuUpdateLeaveDayLink.Delimiter = False
                End If
            ElseIf mnuTransactionLeaveAssignment.Visible Then
                If mnuUpdateLeaveDay.Visible = False And (mnuLaborContract.Visible Or mnuUpdateInfo.Visible) Then
                    mnuUpdateLeaveDayLink.Delimiter = False
                ElseIf mnuUpdateLeaveDay.Visible = False And mnuLaborContract.Visible = False And mnuUpdateInfo.Visible = False Then
                    mnuTransactionLeaveAssignmentLink.Delimiter = False
                    mnuUpdateLeaveDayLink.Delimiter = False
                End If
            ElseIf mnuTransactionLeaveAssignment.Visible = False Then
                C1CommandLink3.Delimiter = False
            ElseIf mnuSetTransaction.Visible = False Then
                C1CommandLink3.Delimiter = False
            ElseIf mnuPrint.Visible = False Then
                mnuPrintLink.Delimiter = False
            End If
        End If
    End Sub

    Private Sub CheckMenuOther()
        mnuPrint.Enabled = (iperPrint >= 1) And (tdbg.RowCount > 0)
        mnuLaborContract.Enabled = (iperD09F2010 >= 2) And (tdbg.RowCount > 0)
        mnuUpdateInfo.Enabled = (iPerD09F2130 >= 2) And (tdbg.RowCount > 0)
        mnuLaborContract.Enabled = (iperD09F2010 >= 2) And (tdbg.RowCount > 0)
        mnuTransactionLeaveAssignment.Enabled = (iPerD15F2050 >= 2) And (tdbg.RowCount > 0)
        mnuUpdateLeaveDay.Enabled = (iPerD15F2050 >= 3) And (tdbg.RowCount > 0)
        mnuSetTransaction.Enabled = (iperD21F3010 >= 2) And (tdbg.RowCount > 0)
        mnuUpdatePayrollFile.Enabled = tdbg.RowCount > 0
        If mnuPITBalance.Visible Then mnuPITBalance.Enabled = tdbg.RowCount > 0
    End Sub

    Private Function Exist_ColEmplooyeeID() As Boolean
        Dim iCol_EmployeeID As Integer = -1

        For i As Integer = 0 To tdbg.Columns.Count - 1
            If tdbg.Columns(i).DataField = "EmployeeID" Then
                iCol_EmployeeID = i
                Exit For
            End If
        Next i
        If iCol_EmployeeID = -1 Then
            D99C0008.MsgL3(rl3("Khong_ton_tai_cot_EmployeeID"))
            Me.Cursor = Cursors.Default
            Return False 'k co cot EmployeeID
        End If

        Return True
    End Function
#End Region

#Region "FilterBar"
    '    Dim sFilter As New System.Text.StringBuilder()
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dt Is Nothing) Then Exit Sub
            'sFilter = New StringBuilder("")
            'Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
            'For Each dc In Me.tdbg.Columns
            '    Select Case dc.DataType.Name
            '        Case "DateTime"
            '            If dc.FilterText.Length = 10 Then
            '                If sFilter.Length > 0 Then sFilter.Append(" AND ")
            '                Dim sClause As String = ""
            '                sClause = "(" & dc.DataField & " >= #" & DateSave(CDate(dc.FilterText)) & "#"
            '                sClause &= " And " & dc.DataField & " < #" & DateSave(CDate(dc.FilterText).AddDays(1)) & "# )"
            '                sFilter.Append(sClause)
            '            End If
            '        Case "Boolean"
            '            If dc.FilterText.Length > 0 Then
            '                If sFilter.Length > 0 Then sFilter.Append(" AND ")
            '                sFilter.Append((dc.DataField + " = " + "'" + dc.FilterText + "'"))
            '            End If
            '        Case "String"
            '            If dc.FilterText.Length > 0 Then
            '                If sFilter.Length > 0 Then sFilter.Append(" AND ")
            '                sFilter.Append((dc.DataField + " like " + "'%" + dc.FilterText.Replace("'", "''") + "%'"))
            '            End If

            '        Case "Decimal", "Byte", "Integer", "Int16", "Int32", "Double"
            '            If dc.FilterText.Length > 0 Then
            '                If sFilter.Length > 0 Then sFilter.Append(" AND ")
            '                sFilter.Append((dc.DataField + " = " + "" + dc.FilterText + ""))
            '            End If
            '    End Select
            'Next
            'Filter the data
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
            'dt.DefaultView.RowFilter = sFilter.ToString()
            'CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, False)
            ''Mai Duyen update 16/11/2009
            'CheckMenuOther()

            'FooterTotalGrid(tdbg, 1)
        Catch ex As Exception
            WriteLogFile(ex.Message)
        End Try
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then Exit Sub

        Select Case tdbg.Columns(e.ColIndex).DataField
            Case "IsUsed"
                tdbg.AllowSort = False
                Dim bFlag As Boolean = Not L3Bool(tdbg(0, "IsUsed"))
                For i As Integer = tdbg.RowCount - 1 To 0 Step -1
                    tdbg(i, "IsUsed") = bFlag
                Next
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.S
                    Select Case tdbg.Columns(tdbg.Col).DataField
                        Case "IsUsed"
                            Dim bFlag As Boolean = Not L3Bool(tdbg(0, "IsUsed"))
                            For i As Integer = 0 To tdbg.RowCount - 1
                                tdbg(i, "IsUsed") = bFlag
                            Next
                    End Select
            End Select
        End If
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Columns(tdbg.Col).DataType.Name
            Case "Decimal", "Byte", "Integer"
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case "DateTime"
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select

    End Sub

    Public Function DateSave(ByVal [Date] As String) As String
        If [Date] = "" Then Return "NULL"
        Dim dDate As Date = CType([Date], Date)
        Return dDate.ToString("MM/dd/yyyy")
    End Function

    Public Function DateSave(ByVal [Date] As Object) As String
        If IsDBNull([Date]) Then Return "NULL"
        Return DateSave([Date].ToString)
    End Function

    Private Sub c1date1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1date1.KeyDown
        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        Try
            If e.KeyCode = Keys.Tab Then
                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
                tdbg.Col = tdbg.Col + 1
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub c1date2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1date2.KeyDown
        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        Try
            If e.KeyCode = Keys.Tab Then
                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
                tdbg.Col = tdbg.Col + 1
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Câu SQL"

    Private Sub ReplaceQuery()
        _sQLQuery = _sQLQuery.Replace("{DivisionID}", gsDivisionID)
        _sQLQuery = _sQLQuery.Replace("{UserID}", gsUserID)
        _sQLQuery = _sQLQuery.Replace("{TranMonth}", giTranMonth.ToString())
        _sQLQuery = _sQLQuery.Replace("{TranYear}", giTranYear.ToString) 'IsNewDisplay 
        _sQLQuery = _sQLQuery.Replace("{IsNewDisplay}", "0")

        Dim sSQL As String = ""
        sSQL = "Select ParameterID, ParaValue, ReportID, CustomizedReportID " & vbCrLf
        sSQL &= "From D82T1020" & vbCrLf
        sSQL &= "Where AlertCode = " & SQLString(_alertCode) & " And AlertBaseID=" & SQLString(_alertBaseID) & " And ModuleID= 'D" & _moduleID & "'"
        Dim dt1 As DataTable = ReturnDataTable(sSQL)
        If dt1.Rows.Count > 0 Then
            sCusomizedReportID = dt1.Rows(0).Item("CustomizedReportID").ToString
            For i As Integer = 0 To dt1.Rows.Count - 1
                _sQLQuery = _sQLQuery.Replace("{" & dt1.Rows(i).Item("ParameterID").ToString & "}", dt1.Rows(i).Item("ParaValue").ToString)
            Next
        End If
        _sQLQuery = _sQLQuery.Replace("{Ref04}", "0") 'ID 98331 03.08.2017
    End Sub

    Private Function SQLStoreD09P8210() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P8210 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(_alertBaseID) & COMMA 'AlertBaseID, varchar[20], NOT NULL
        sSQL &= SQLString(_alertCode) & COMMA 'AlertCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 08/09/2009 01:35:08
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666 "
        sSQL &= "Where HostID=" & SQLString(My.Computer.Name) & " And UserID=" & SQLString(gsUserID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 15/03/2011 11:55:41
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009(Optional ByVal sFormID As String = "") As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D91T9009"
        sSQL &= " Where HostID=" & SQLString(My.Computer.Name) & " And UserID=" & SQLString(gsUserID)
        If sFormID <> "" Then  ' update 5/8/2013 id 56746
            sSQL &= " And FormID=" & SQLString(sFormID)
        End If
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 08/09/2009 01:35:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666(ByVal sKey01ID As String, ByVal sKey02ID As String, ByVal sKey05ID As String, ByVal sNum01 As String, ByVal sDate01 As String) As StringBuilder
        Dim sSQL As New StringBuilder("")
        sSQL.Append("Insert Into D09T6666 (")
        sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key05ID, Num01, Date01")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
        sSQL.Append(SQLString(sKey01ID) & COMMA) 'Key01ID, varchar[250], NULL
        sSQL.Append(SQLString(sKey02ID) & COMMA) 'Key02ID, varchar[250], NULL
        ' 27/3/2013 id 64362 - Key05ID
        sSQL.Append(SQLString(sKey05ID) & COMMA) 'Key02ID, varchar[250], NULL
        sSQL.Append(SQLMoney(sNum01) & COMMA) 'Num01, decimal, NOT NULL
        sSQL.Append(SQLDateSave(sDate01)) 'Date01, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 08/09/2009 01:35:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666(ByVal sFormID As String, ByVal sKey01ID As String) As StringBuilder
        Dim sSQL As New StringBuilder("")
        sSQL.Append("Insert Into D09T6666 (")
        sSQL.Append("UserID, HostID, FormID, Key01ID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
        sSQL.Append(SQLString(sFormID) & COMMA) 'FormID, varchar[250], NULL
        sSQL.Append(SQLString(sKey01ID)) 'Key01ID, varchar[250], NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: 
    '# Created User:  HOANGNHAN
    '# Created Date:  26/4/2013 01:35:20
    '# Modified User:: 
    '# Modified Date:: 
    '# Description:  ID 54222
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666_UpdatePayroll(ByVal sFormID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666 "
        sSQL &= "Where HostID=" & SQLString(My.Computer.Name) & " And UserID=" & SQLString(gsUserID) & " And FormID=" & SQLString(sFormID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: 
    '# Created User: HOANGNHAN
    '# Created Date: 26/4/2013 01:35:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: ID 54222
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666_UpdatePayroll(ByVal sFormID As String, ByVal sKey01ID As String, ByVal sKey02ID As String, ByVal sKey04ID As String, ByVal sKey05ID As String, ByVal sNum01 As String, ByVal sDate01 As String) As StringBuilder
        Dim sSQL As New StringBuilder("")
        sSQL.Append("Insert Into D09T6666 (")
        sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key04ID, Key05ID, Num01, Date01, FormID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
        sSQL.Append(SQLString(sKey01ID) & COMMA) 'Key01ID, varchar[250], NULL
        sSQL.Append(SQLString(sKey02ID) & COMMA) 'Key02ID, varchar[250], NULL
        sSQL.Append(SQLString(sKey04ID) & COMMA) 'Key04ID, varchar[250], NULL
        sSQL.Append(SQLString(sKey05ID) & COMMA) 'Key05ID, varchar[250], NULL
        sSQL.Append(SQLMoney(sNum01) & COMMA) 'Num01, decimal, NOT NULL
        sSQL.Append(SQLDateSave(sDate01) & COMMA) 'Date01, datetime, NULL
        sSQL.Append(SQLString(sFormID)) 'FormID, varchar[250], NULL
        sSQL.Append(")")

        Return sSQL
    End Function


#End Region

#Region "Code cho module D09, các module khác thì Rem lại"
#End Region

#Region "Code cho module D15, các module khác thì Rem lại"

    
#End Region

#Region "Code cho module D21, các module khác thì rem lại"

    
#End Region

#Region "Code cho module D13, các module khác thì rem lại"

    Private Function AllowSetTrans() As Boolean
        tdbg.UpdateData()

        Dim bChoose As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, "IsUsed").ToString) Then
                bChoose = True
                Exit For
            End If
        Next
        If Not bChoose Then
            D99C0008.MsgL3(rl3("MSG000010"))
            tdbg.Focus()
            tdbg.Col = 0
            Return False
        End If
        Return True
    End Function

    Private Sub mnuSetTransaction_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSetTransaction.Click
        'Update 24/02/2012: incident 46211 Bổ sung kiểm tra nhiều dòng

        If Not AllowSetTrans() Then Exit Sub

        Dim sSQL As String = ""

        If Not Exist_ColEmplooyeeID() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        sSQL &= SQLDeleteD09T6666().ToString() & vbCrLf
        'Update 24/02/2012: incident 46211 Bổ sung insert nhiều dòng
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, "IsUsed").ToString) Then
                sSQL &= SQLInsertD09T6666("D13F1030", tdbg(i, "EmployeeID").ToString, tdbg(i, "TransID").ToString, tdbg(i, "Times").ToString, tdbg(i, "ValidDate").ToString).ToString() & vbCrLf
            End If
        Next i
        'Update 26/12/2011: incident 43935 Chỉ insert vào dòng hiện tại
        'sSQL &= SQLInsertD09T6666("D13F1030", tdbg(tdbg.Row, "EmployeeID").ToString, tdbg(tdbg.Row, "Times").ToString, tdbg(tdbg.Row, "ValidDate").ToString).ToString() & vbCrLf
        ExecuteSQL(sSQL.ToString())

        If CheckStore(SQLStoreD13P5555) Then

            sSQL = SQLStoreD13P1035().ToString() & vbCrLf
            ExecuteSQLNoTransaction(sSQL.ToString())
            If ExistRecord("Select Top 1 1 From D91T9009 Where UserID = " & SQLString(gsUserID) & " And HostID = " & SQLString(My.Computer.Name) & " And Key02ID = 'D13F2012'") Then
                CallFormShowDialog("D13D0140", "D13F2014")
            End If
        End If

        sSQL = SQLDeleteD09T6666().ToString() & vbCrLf
        sSQL &= SQLDeleteD91T9009().ToString() & vbCrLf
        ExecuteSQL(sSQL.ToString())


        ReplaceQuery()
        dt = ReturnDataTable(_sQLQuery)
        FillDataGrid(True)

        Me.Cursor = Cursors.Default
    End Sub

    ' update 26/4/2013 id 54222 - bổ sung Cập nhật HSL
    Private Sub mnuUpdatePayrollFile_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuUpdatePayrollFile.Click
        If Not AllowSetTrans() Then Exit Sub
        Dim sSQL As String = ""
        Me.Cursor = Cursors.WaitCursor

        Select Case _alertBaseID
            Case "D82A1305" ' update 26/4/2013 id 54222
                sSQL &= SQLDeleteD09T6666_UpdatePayroll("D09F2010").ToString() & vbCrLf
                'Update 24/02/2012: incident 46211 Bổ sung insert nhiều dòng
                For i As Integer = 0 To tdbg.RowCount - 1
                    If L3Bool(tdbg(i, "IsUsed").ToString) Then
                        sSQL &= SQLInsertD09T6666_UpdatePayroll("D09F2010", "D13F1030", tdbg(i, "EmployeeID").ToString, "", tdbg(i, "SerialBook2").ToString, tdbg(i, "Times").ToString, tdbg(i, "EffContractBegin").ToString).ToString() & vbCrLf
                    End If
                Next i
                ExecuteSQL(sSQL.ToString())

                If CheckStore(SQLStoreD13P5555("D09F2010")) Then
                    sSQL = SQLStoreD13P1035(3, "D09F2010").ToString() & vbCrLf ' sSQL = SQLStoreD13P1035(True).ToString() & vbCrLf
                    ExecuteSQLNoTransaction(sSQL.ToString())
                    CallFormShowDialog("D13D0140", "D13F2014")
                    '                    Dim frm As New D13F2014
                    '                    With frm
                    '                        .ShowDialog()
                    '                        .Dispose()
                    '                    End With
                End If
                sSQL = SQLDeleteD09T6666_UpdatePayroll("D09F2010").ToString() & vbCrLf
                ExecuteSQLNoTransaction(sSQL)
            Case "D82A1306" ' update 5/8/2013 id 56746  - cập nhật HSL tháng nghiệp vụ bổ nhiệm
                sSQL &= SQLDeleteD09T6666_UpdatePayroll("D09F2110").ToString() & vbCrLf
                'Update 24/02/2012: incident 46211 Bổ sung insert nhiều dòng
                For i As Integer = 0 To tdbg.RowCount - 1
                    If L3Bool(tdbg(i, "IsUsed").ToString) Then
                        sSQL &= SQLInsertD09T6666_UpdatePayroll("D09F2110", tdbg(i, "EmployeeID").ToString, "", "", "", tdbg(i, "Times").ToString, tdbg(i, "ValidDate").ToString).ToString() & vbCrLf
                    End If
                Next i
                ExecuteSQL(sSQL.ToString())

                If CheckStore(SQLStoreD13P5555("D09F2110")) Then
                    sSQL = SQLStoreD13P1035(3, "D09F2110").ToString() ' Với  	@Mode = 3, @FormID = ‘D09F21
                    ExecuteSQLNoTransaction(sSQL.ToString())
                End If

                sSQL = SQLDeleteD09T6666_UpdatePayroll("D09F2110").ToString() & vbCrLf
                sSQL &= SQLDeleteD91T9009("D09F2110")
                ExecuteSQLNoTransaction(sSQL)
        End Select

        ' update 24/6/2013 id 57495 - Load lại lưới
        ReplaceQuery()
        dt = ReturnDataTable(_sQLQuery)
        FillDataGrid(True)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuPITBalance_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPITBalance.Click
        Dim sEmployeeID As String = ""
        For i As Integer = 0 To tdbg.RowCount - 1
            sEmployeeID &= SQLString(tdbg(i, "EmployeeID").ToString()) & ","
        Next i
        If sEmployeeID <> "" Then
            sEmployeeID = sEmployeeID.Remove(sEmployeeID.Length - 1, 1)
        End If

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", 0)
        SetProperties(arrPro, "IsCallFromAlert", True)
        SetProperties(arrPro, "EmployeeID", sEmployeeID)
        SetProperties(arrPro, "PITYear", tdbg.Columns("PITYear").Text)

        Dim frm As Form = CallFormShowDialog("D13D0240", "D13F2081", arrPro)
        If L3Bool(GetProperties(frm, "bSaved")) Then
            mnuRefesh_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub mnuSalaryProposal_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSalaryProposal.Click
        If Not AllowSetTrans() Then Exit Sub
        'Gọi exe con D09E0240
        Dim sSQL As New StringBuilder("")

        If Not Exist_ColEmplooyeeID() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        sSQL.Append(SQLDeleteD91T9009() & vbCrLf)
        sSQL.Append(SQLInsertD91T9009s_D82A1303().ToString)

        If ExecuteSQL(sSQL.ToString) Then
            Dim arrPro() As StructureProperties = Nothing
            SetProperties(arrPro, "FormIDPermission", "D09F3120") ' ko thấy sự dụng IsTransaction
            Dim frm As Form = CallFormShowDialog("D09D2140", "D09F2000", arrPro)
            If L3Bool(GetProperties(frm, "bSaved")) = False Then
                'Load lại dữ liệu
                dt = ReturnDataTable(_sQLQuery)
                FillDataGrid(True)
            End If
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Function SQLInsertD91T9009s_D82A1303() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, "IsUsed").ToString) Then
                sSQL.Append("Insert Into D91T9009(")
                sSQL.Append("UserID, HostID, Key01ID, Key02ID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
                sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, "EmployeeID").ToString) & COMMA) 'Key01ID, varchar[250], NULL
                sSQL.Append(SQLString("D09F2000")) 'Key02ID, varchar[250], NULL
                sSQL.Append(")")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1035
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 15/03/2011 11:38:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1035(Optional ByVal iMode As Integer = 0, Optional ByVal sFormID As String = "") As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1035 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        ' update 26/4/2013 id 54222 , ' update 5/8/2013 id 56746 - tính năng cũ thì truyền giá trị mặc định
        sSQL &= COMMA & SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(sFormID) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'StatusID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'ContractID, varchar[20], NOT NULL

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1037
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 27/12/2011 08:53:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1037() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1037 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber("3") & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 15/03/2011 11:45:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(Optional ByVal sKey01ID As String = "") As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D09U2223") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(sKey01ID) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") 'DateTo, datetime, NOT NULL
        Return sSQL
    End Function

#End Region

    'Private Sub mnuUpdateSalaryMonth_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuUpdateSalaryMonth.Click, mnuUpdate.Click
    Private Sub mnuUpdate_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuUpdate.Click
        Dim sSQL As String = ""

        If Not AllowSetTrans() Then Exit Sub
        'If Not Exist_ColEmplooyeeID() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        sSQL &= SQLDeleteD09T6666().ToString() & vbCrLf
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, "IsUsed").ToString) Then
                sSQL &= SQLInsertD09T6666("D13F1030", tdbg(i, "EmployeeID").ToString, "", tdbg(i, "Times").ToString, tdbg(i, "ValidDate").ToString).ToString() & vbCrLf
            End If
        Next i
        ExecuteSQL(sSQL.ToString())

        If CheckStore(SQLStoreD13P5555) Then

            sSQL = SQLStoreD13P1037().ToString() & vbCrLf
            ExecuteSQL(sSQL.ToString())

            If ExistRecord("Select Top 1 1 From D91T9009 Where UserID = " & SQLString(gsUserID) & " And HostID = " & SQLString(My.Computer.Name) & " And Key02ID = 'D13F2012'") Then
                CallFormShowDialog("D13D0140", "D13F2014")
            End If
        End If

        sSQL = SQLDeleteD09T6666().ToString() & vbCrLf
        sSQL &= SQLDeleteD91T9009().ToString() & vbCrLf
        ExecuteSQL(sSQL.ToString())

        ReplaceQuery()
        dt = ReturnDataTable(_sQLQuery)
        FillDataGrid(True)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuSalaryAdjust_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSalaryAdjust.Click
        'If _alertBaseID = "D82A1303" Then

        If Not AllowSetTrans() Then Exit Sub
        'Gọi exe con D09E0240
        Dim sSQL As New StringBuilder("")

        If Not Exist_ColEmplooyeeID() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        sSQL.Append(SQLDeleteD91T9009() & vbCrLf)
        sSQL.Append(SQLInsertD91T9009s_SalaryAdjust().ToString)

        If ExecuteSQL(sSQL.ToString) Then
            Dim arrPro() As StructureProperties = Nothing
            SetProperties(arrPro, "FormIDPermission", "D09F3120") ' ko thấy sự dụng IsTransaction
            'SetProperties(arrPro, "Mode09", 5) ' 13/10/2014 id 65350  - * Cảnh báo: D82A1303, menu Điều chỉnh lương: Gọi D09F2021 Sửa lại Truyền @Mode = 5
            SetProperties(arrPro, "Mode09", 7)
            SetProperties(arrPro, "EnabledFilter", True)
            SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
            Dim frm As Form = CallFormShowDialog("D09D2140", "D09F2021", arrPro)
            If L3Bool(GetProperties(frm, "bSaved")) Then
                'Load lại dữ liệu
                dt = ReturnDataTable(_sQLQuery)
                FillDataGrid(True)
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Function SQLInsertD91T9009s_SalaryAdjust() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, "IsUsed").ToString) Then
                sSQL.Append("Insert Into D91T9009(")
                sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, Key04ID, Key05ID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
                sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, "EmployeeID").ToString) & COMMA) 'Key01ID, varchar[250], NULL
                sSQL.Append(SQLString("0004") & COMMA) 'Key02ID, varchar[250], NULL
                sSQL.Append(SQLString("") & COMMA) 'Key03ID, varchar[250], NULL
                sSQL.Append(SQLString("") & COMMA) 'Key04ID, varchar[250], NULL
                sSQL.Append(SQLString(_alertCode)) 'Key05ID, varchar[250], NULL
                sSQL.Append(")")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    Private Function SQLSelectTopD91T9009(ByVal sFormID As String) As String
        Dim sSQL As String = "SELECT 	TOP 1 1 FROM D91T9009 " & vbCrLf
        sSQL &= " WHERE 	UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name)
        sSQL &= " AND FormID =" & SQLString(sFormID)

        Return sSQL
    End Function

    Public Sub SetResolutionTDBG(ByVal tdbg1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal tile_x As Double)
        tdbg1.Width = CInt(tdbg1.Width * tile_x)
        For i As Integer = 0 To tdbg1.Splits.ColCount - 1
            With tdbg1.Splits(i)
                For j As Integer = 0 To tdbg1.Columns.Count - 1
                    .DisplayColumns(j).Width = CInt(.DisplayColumns(j).Width * tile_x)
                    .DisplayColumns(j).Style.Font = New System.Drawing.Font(.DisplayColumns(j).Style.Font.Name, iSizeFont, .DisplayColumns(j).Style.Font.Style)

                    .DisplayColumns(j).HeadingStyle.Font = New System.Drawing.Font(.DisplayColumns(j).HeadingStyle.Font.Name, iSizeFont, .DisplayColumns(j).HeadingStyle.Font.Style)
                    .DisplayColumns(j).FooterStyle.Font = New System.Drawing.Font(.DisplayColumns(j).FooterStyle.Font.Name, iSizeFont, .DisplayColumns(j).FooterStyle.Font.Style)
                    .DisplayColumns(j).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                Next

                .CaptionHeight = CInt(.CaptionHeight * tile_x)
                .ColumnCaptionHeight = CInt(.ColumnCaptionHeight * tile_x)
                .ColumnFooterHeight = CInt(.ColumnFooterHeight * tile_x)
                .SplitSize = CInt(.SplitSize * tile_x)
            End With
        Next
    End Sub

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        ' UPDATE 23/10/2013 ID 60089 - Đổi caption thành ‘Cập nhật HSNV và HSL Tháng’ - Áp dụng đối với mã cảnh báo D82A1305
        Select Case _alertBaseID
            Case "D82A1305"
                mnuUpdatePayrollFile.Text = rl3("Cap_nhat_HSNV_va_HSL_Thang") 'Cập nhật HSNV và HSL Tháng
            Case Else
                mnuUpdatePayrollFile.Text = rl3("Cap_nhat_ho_so_luong_thang") 'rl3("Cap_nhat_HSL_thang") 'Cập nhật HSL
        End Select
    End Sub

    '19/12/2013 id 60826 - Cập nhật &hiệu lực giảm trừ gia cảnh
    Private Sub mnuUpdateFamilyDeductionValidationDate_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuUpdateFamilyDeductionValidationDate.Click
        Dim sSQL As String = ""

        If Not AllowSetTrans() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        sSQL &= SQLDeleteD09T6666_UpdatePayroll("D13F1038").ToString() & vbCrLf
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, "IsUsed").ToString) Then
                sSQL &= SQLInsertD09T6666_UpdatePayroll("D13F1038", tdbg(i, "RelativeID").ToString, "", "", "", "", "").ToString & vbCrLf
            End If
        Next i
        ExecuteSQL(sSQL.ToString())

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "Mode", 1)
        Dim frm As Form = CallFormShowDialog("D13D0140", "D13F1038", arrPro)
        sSQL = SQLDeleteD09T6666().ToString() & vbCrLf
        ExecuteSQL(sSQL.ToString())

        ReplaceQuery()
        dt = ReturnDataTable(_sQLQuery)
        FillDataGrid(True)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuExportToExcel_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click
        'Lưới không có nút Hiển thị
        'Nếu lưới không có Group thì mở dòng code If dtCaptionCols Is Nothing Then
        'và truyền đối số cuối cùng là False vào hàm AddColVisible
        'If dtCaptionCols Is Nothing orelse dtCaptionCols.Rows.Count < 1 Then
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory)
        Next

        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        'Form trong DLL
        ''CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtFind, gsGroupColumns)'Nếu có sử dụng F12 cũ D09U1111
        ' CallShowD99F2222(Me.ParentForm, dtCaptionCols, dt, gsGroupColumns)
        'Form trong EXE
        Dim frm As New D99F2222
        With frm
            .UseUnicode = False
            .FormID = Me.Name
            .dtLoadGrid = dtCaptionCols
            .GroupColumns = gsGroupColumns
            .dtExportTable = dt 'Table load dữ liệu cho lưới
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub mnuFilterEmployee_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuFilterEmployee.Click
        tdbg.UpdateData()
        Dim sSQL As New StringBuilder("")
        '**********************
        Dim sFormID As String = ""
        Select Case _alertBaseID
            Case "D82A1303"
                sFormID = "D82A1303"
        End Select
        If sFormID = "" Then Exit Sub

        Dim dt As DataTable = CType(tdbg.DataSource, DataTable).DefaultView.Table
        Dim dr() As DataRow = dt.Select("IsUsed = True")
        If dr.Length <= 0 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        sSQL.Append(SQLDeleteD09T6666_UpdatePayroll(sFormID) & vbCrLf)
        For i As Integer = 0 To dr.Length - 1
            sSQL.Append(SQLInsertD09T6666(sFormID, L3String(dr(i)("EmployeeID"))))
        Next i

        If ExecuteSQL(sSQL.ToString) Then
            Dim arrPro() As StructureProperties = Nothing
            SetProperties(arrPro, "AlertBaseID", _alertBaseID)
            SetProperties(arrPro, "AlertCode", _alertCode)
            CallFormShowDialog("D82D4240", "D82F3010", arrPro)
        End If

        Me.Cursor = Cursors.Default
    End Sub
End Class
