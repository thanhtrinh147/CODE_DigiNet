Imports System
Imports System.Windows.Forms
Public Class D13F1000
    Private dtGrid As DataTable
    Dim bSavedOK As Boolean = False
    Dim iPerMe As Integer
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Dim iHeight As Integer = 0 ' Lấy tọa độ Y của chuột click tới

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _formIDPermission As String = "D13F1000"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

    Private iOrdersMax As Int32
    Public Property OrdersMax() As Int32
        Get
            Return iOrdersMax
        End Get
        Set(ByVal value As Int32)
            iOrdersMax = value
        End Set
    End Property

    Private _formState As EnumFormState = EnumFormState.FormView
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal Value As EnumFormState)
            _formState = Value
        End Set
    End Property

#Region "Const of tdbg - Total of Columns: 15"
    Private Const COL_AbsentTypeDateID As Integer = 0   ' Mã
    Private Const COL_AbsentTypeDateName As Integer = 1 ' Diễn giải
    Private Const COL_Orders As Integer = 2             ' Thứ tự hiển thị
    Private Const COL_UnitID As Integer = 3             ' ĐVT
    Private Const COL_Unit As Integer = 4               ' Đơn vị
    Private Const COL_Disabled As Integer = 5           ' KSD
    Private Const COL_CreateUserID As Integer = 6       ' Người tạo
    Private Const COL_CreateDate As Integer = 7         ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 8   ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 9     ' Ngày cập nhật cuối cùng
    Private Const COL_Lookup As Integer = 10            ' Lookup
    Private Const COL_Decimals As Integer = 11          ' Decimals
    Private Const COL_IsClassification As Integer = 12  ' IsClassification
    Private Const COL_ClassificationID As Integer = 13  ' ClassificationID
    Private Const COL_IsValue As Integer = 14           ' IsValue
#End Region
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Danh_muc_Khoan_dieu_chinh_thu_nhap_-_D13F1000") & UnicodeCaption(gbUnicode) 'Danh móc Kho¶n ¢iÒu chÙnh thu nhËp - D13F1000
        '================================================================ 
        btnCofficientInfo.Text = rL3("Thong_tin__he_so") 'Thông tin &hệ số
        '================================================================ 
        tdbg.Columns("AbsentTypeDateID").Caption = rL3("Ma") 'Mã 
        tdbg.Columns("AbsentTypeDateName").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns("Orders").Caption = rL3("Thu_tu_hien_thi") 'Thứ tự hiển thị
        tdbg.Columns("UnitID").Caption = rL3("DVT") 'ĐVT
        tdbg.Columns("Unit").Caption = rL3("Don_vi") 'Đơn vị
        tdbg.Columns("Disabled").Caption = rL3("KSD") 'KSD
        '================================================================ 
        chkShowDisabled.Text = rL3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng

        '================================================================ 
        lblClassification.Text = rL3("Loai_danh_gia") 'Loại đánh giá
        lblAbsentTypeID.Text = rL3("Ma") 'Mã 
        lblAbsentTypeName.Text = rL3("Dien_giai") 'Diễn giải
        lblLookup.Text = rL3("Ten_tat") 'Tên tắt
        lblOrders.Text = rL3("Thu_tu_hien_thi") 'Thứ tự hiển thị
        lblUnitID.Text = rL3("DVT") 'ĐVT
        lblDecimals.Text = rL3("Lam_tron") 'Làm tròn
        '================================================================ 
        btnSave.Text = rL3("_Luu") '&Lưu
        btnNext.Text = rL3("Nhap__tiep") 'Nhập &tiếp
        btnAbsentConversion.Text = rL3("_Quy_doi_cong") '&Quy đổi công
        '================================================================ 
        'chkIsTimeSheet.Text = rl3("Bang_cham_cong_nhat") 'Bảng chấm công nhật
        chkIsValue.Text = rL3("Hien_thi_gia_tri_cua_moi_loai") 'Hiển thị giá trị của mỗi loại
        chkIsClassification.Text = rL3("Danh_gia_xep_loai") 'Đánh giá xếp loại
        chkDisabled.Text = rL3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        'grpAbsentType.Text = rl3("Loai_cham_cong") 'Loại chấm công
        '================================================================ 
        tdbcClassification.Columns("ClassificationID").Caption = rL3("Ma") 'Mã
        tdbcClassification.Columns("ClassificationName").Caption = rL3("Dien_giai") 'Diễn giải
    End Sub
    Private Sub D56F1030_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _formState = EnumFormState.FormEdit Then
            If Not _bSaved Then If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
        ElseIf _formState = EnumFormState.FormAdd Then
            If txtAbsentTypeDateID.Text <> "" Then
                If Not _bSaved Then
                    If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub EnableMenu(ByVal bEnabled As Boolean)
        If dtGrid Is Nothing Then Exit Sub
        btnSave.Enabled = bEnabled
        btnNotSave.Enabled = bEnabled
        btnNext.Enabled = bEnabled
        chkShowDisabled.Enabled = Not bEnabled
        tdbg.Enabled = Not bEnabled
        If _formState = EnumFormState.FormAdd Then
            btnNext.Visible = True
            btnNext.Text = rL3("Luu_va_Nhap__tiep")
        Else
            btnNext.Visible = False
        End If
        If btnNext.Visible And btnNext.Enabled Then
            btnSave.Left = btnNext.Left - btnSave.Width - 6
        Else
            btnSave.Left = btnNext.Left + (btnNext.Width - btnSave.Width)
        End If

        If bEnabled Then
            CheckMenu("-1", ToolStrip1, -1, False, False, ContextMenuStrip1)
        Else
            CheckMenu(_formIDPermission, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , Me.Name)
        End If
    End Sub

    ' Trường hợp tìm kiếm không có dữ liệu thì Khóa Detail lại
    Private Sub LockControlDetail(ByVal bLock As Boolean)
        grpDetail.Enabled = Not bLock
    End Sub

    Private Sub D56F1030_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        SetBackColorObligatory()
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        SetImageButton(btnSave, btnNotSave, btnNext, imgButton)
        tdbg_NumberFormat()
        LoadTDBCombo()
        ResetColorGrid(tdbg)
        LoadTDBGrid()
        SetShortcutPopupMenuNew(Me, ToolStrip1, ContextMenuStrip1)
        CheckIdTextBox(txtAbsentTypeDateID)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_Unit).NumberFormat = D13Format.DefaultNumber2
    End Sub
    Private Sub D56F1030_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _formState = EnumFormState.FormAdd Then
            txtAbsentTypeDateID.Focus()
        Else
            txtAbsentTypeDateName.Focus()
        End If
    End Sub

    Private Sub D56F1030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL = "Select AbsentTypeDateID, AbsentTypeDateName" & UnicodeJoin(gbUnicode) & " As AbsentTypeDateName, AbsentTypeDateNameU, Lookup" & UnicodeJoin(gbUnicode) & " As Lookup, Orders, UnitID" & UnicodeJoin(gbUnicode) & " As UnitID, Unit, Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate,IsDailySheet, IsClassification, ClassificationID, IsValue, IsTimeSheet, Decimals "
        sSQL &= " From D13T0118  WITH (NOLOCK) "

        dtGrid = ReturnDataTable(sSQL)

        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("AbsentTypeDateID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0))
        End If
        If dtGrid.Rows.Count = 0 And tsbAdd.Enabled Then tsbAdd_Click(Nothing, Nothing)
    End Sub
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcClassification
        sSQL = "Select Distinct  ClassificationID, "
        sSQL &= IIf(gbUnicode, "ClassificationNameU As ClassificationName", "ClassificationName").ToString
        sSQL &= " From D13T0120  WITH (NOLOCK) Where Disabled = 0 "
        LoadDataSource(tdbcClassification, sSQL, gbUnicode)
    End Sub
    Private Sub ReLoadTDBGrid(Optional ByVal bLoadEdit As Boolean = True)
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled =0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
        If _formState = EnumFormState.FormAdd Then Exit Sub

        If tdbg.RowCount = 0 Then
            ClearText(grpDetail)
            LockControlDetail(True)
        Else
            LockControlDetail(False)
            _formState = EnumFormState.FormView
            If bLoadEdit Then
                LoadEdit()
            End If
        End If
    End Sub
    Private Sub ResetGrid()
        EnableMenu(False)
        FooterTotalGrid(tdbg, COL_AbsentTypeDateID)
    End Sub

    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#Region "Menu"
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, mnsAdd.Click
        LoadAdd()
        EnableMenu(True)
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, mnsEdit.Click
        _formState = EnumFormState.FormEdit
        EnableMenu(True)
        ReadOnlyControl(txtAbsentTypeDateID)
        bSavedOK = False
        txtAbsentTypeDateName.Focus()
        chkDisabled.Visible = True
        btnAbsentConversion.Enabled = True
    End Sub
    Private Function AllowDelete() As Boolean
        Dim s As String = ""
        s = "select * from D13T0103  WITH (NOLOCK) Where AbsentTypeID = " & SQLString(tdbg.Columns(COL_AbsentTypeDateID).Text)
        If ExistRecord(s) Then
            D99C0008.MsgL3(MsgNotDeleteData)
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowDelete() Then Exit Sub
        Dim sSQL As String = ""
        Dim bookmark As Int32
        Dim nRowDelete As Integer

        Me.Cursor = Cursors.WaitCursor
        bookmark = tdbg.Bookmark
        Dim SelectedRows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        Dim i As Integer
        sSQL = ""
        If SelectedRows.Count > 1 Then 'Xóa nhiều dòng một lúc
            For i = 0 To SelectedRows.Count - 1
                sSQL &= SQLDeleteD13T0103(tdbg(SelectedRows.Item(i), COL_AbsentTypeDateID).ToString) & vbCrLf
                sSQL &= SQLDeleteD13T0118(tdbg(SelectedRows.Item(i), COL_AbsentTypeDateID).ToString) & vbCrLf
            Next
            nRowDelete = SelectedRows.Count
        Else 'Xóa 1 dòng
            sSQL &= SQLDeleteD13T0103(tdbg.Columns(COL_AbsentTypeDateID).Text) & vbCrLf
            sSQL &= SQLDeleteD13T0118(tdbg.Columns(COL_AbsentTypeDateID).Text) & vbCrLf
            nRowDelete = 1
        End If
        If ExecuteSQL(sSQL) = True Then
            DeleteOK()
            'Audit Log
            Dim sDesc1 As String = ""
            Dim sDesc2 As String = ""
            Dim sDesc3 As String = ""
            Dim sDesc4 As String = ""
            Dim sDesc5 As String = ""

            If SelectedRows.Count > 1 Then 'Xóa nhiều dòng một lúc
                For i = 0 To SelectedRows.Count - 1
                    sDesc1 = tdbg(SelectedRows.Item(i), COL_AbsentTypeDateID).ToString
                    sDesc2 = tdbg(SelectedRows.Item(i), COL_AbsentTypeDateName).ToString
                    sDesc3 = tdbg(SelectedRows.Item(i), COL_UnitID).ToString
                    RunAuditLog(AuditCodeAttendanceTypes, "03", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)
                Next
            Else 'Xóa 1 dòng
                sDesc1 = tdbg.Columns(COL_AbsentTypeDateID).Text
                sDesc2 = tdbg.Columns(COL_AbsentTypeDateName).Text
                sDesc3 = tdbg.Columns(COL_UnitID).Text
                RunAuditLog(AuditCodeAttendanceTypes, "03", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)
            End If
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
        Else
            DeleteNotOK()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnsSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsSysInfo.Click, tsbSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub
#End Region


    Private Sub mnsImportData_Click(sender As Object, e As EventArgs) Handles mnsImportData.Click, tsbImportData.Click
        If Lemon3.D80.CallFormD80F2090("13", Me.Name, "D13F1000") Then
            LoadTDBGrid()
        End If
    End Sub
    Private Sub tsmExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, mnsExportToExcel.Click
        'Lưới không có nút Hiển thị
        'Nếu lưới không có Group thì mở dòng code If dtCaptionCols Is Nothing Then
        'và truyền đối số cuối cùng là False vào hàm AddColVisible
        'If dtCaptionCols Is Nothing orelse dtCaptionCols.Rows.Count < 1 Then
        Dim arrColObligatory() As Integer = {COL_AbsentTypeDateID}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
    End Sub

    Private Sub txtOrders_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrders.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""
    Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {}
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbg.Splits.Count - 1
                AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
            Next
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me.Name, "0", gbUnicode)

    End Sub

    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
        sFind = ResultWhereClause.ToString()
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Dim report As D99C2003
    Private Sub tsbPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbPrint.Click, mnsPrint.Click
        'Dim report As New D99C1003
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        '************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D13R1000"
        Dim sSubReportName As String = "D09R6000"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        sReportCaption = rL3("Danh_muc_loai_cham_cong") & " - " & sReportName
        sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, "") & sReportName & ".rpt"

        sSQL = "SELECT * FROM D13T0118  WITH (NOLOCK) Where Disabled = 0 ORDER BY AbsentTypeDateID"
        sSQLSub = "Select * From D09V0009"
        UnicodeSubReport(sSubReportName, sSQLSub, , gbUnicode)

        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(dtGrid.DefaultView.ToTable)
            .PrintReport(sPathReport, sReportCaption)
        End With
    End Sub

#End Region
    Private Sub tdbg_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseClick
        iHeight = e.Location.Y
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If iHeight <= tdbg.Splits(0).ColumnCaptionHeight Then Exit Sub
        If tdbg.RowCount <= 0 OrElse tdbg.FilterActive Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Disabled 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Private Sub tdbg_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdbg.AfterSort
        ' If tdbg.FilterActive Then Exit Sub
        LoadEdit()
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        'Neu luoi co 1 dong thi k can chay su kien nay
        If tdbg.RowCount <= 1 Then Exit Sub
        If tdbg.Columns(COL_AbsentTypeDateID).Tag Is Nothing OrElse tdbg.Columns(COL_AbsentTypeDateID).Text <> tdbg.Columns(COL_AbsentTypeDateID).Tag.ToString Then
            LoadEdit()
        End If
    End Sub

    Private Function SaveData(ByVal sender As System.Object) As Boolean
        bSavedOK = False
        If Not AllowSave() Then Return False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _formState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD13T0118())
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T0118())
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            bSavedOK = True
            Select Case _formState
                Case EnumFormState.FormAdd
                    btnCofficientInfo.Enabled = ReturnPermission("D13F5601") > 0
                    btnAbsentConversion.Enabled = True
                    iOrdersMax = L3Int(txtOrders.Text)
                    LoadTDBGrid(True, txtAbsentTypeDateID.Text)
                Case EnumFormState.FormEdit
                    'Audit Log
                    Dim sDesc1 As String = txtAbsentTypeDateID.Text
                    Dim sDesc2 As String = txtAbsentTypeDateName.Text
                    Dim sDesc3 As String = txtUnitID.Text
                    Dim sDesc4 As String = ""
                    Dim sDesc5 As String = ""
                    RunAuditLog(AuditCodeAttendanceTypes, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)
                    LoadTDBGrid(, txtAbsentTypeDateID.Text)
            End Select
            ReadOnlyControl(txtAbsentTypeDateID)
            SetReturnFormView()
        Else
            SaveNotOK()
            Return False
        End If
        Return True
    End Function

    Private Sub LoadAdd()
        _formState = EnumFormState.FormAdd
        tdbg.Columns(COL_AbsentTypeDateID).Tag = ""
        txtAbsentTypeDateID.Text = ""
        chkDisabled.Visible = False
        btnCofficientInfo.Enabled = False
        'txtAbsentTypeDateName.Text = ""
        'txtLookup.Text = ""
        'txtOrders.Text = (iOrdersMax + 1).ToString
        'txtUnitID.Text = ""
        'cboDecimals.Text = "0"
        'tdbcClassification.Text = ""
        'txtClassificationName.Text = ""
        ClearText(grpDetail)
        LockControlDetail(False)
        txtOrders.Text = (iOrdersMax + 1).ToString
        chkIsClassification.Checked = False
        tdbcClassification.Enabled = False
        'chkIsTimeSheet.Checked = False
        chkIsValue.Checked = False
        chkIsValue.Enabled = False
        txtAbsentTypeDateID.Focus()
        btnAbsentConversion.Enabled = False
        UnReadOnlyControl(True, txtAbsentTypeDateID)
    End Sub

    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        If dtGrid.Rows.Count = 0 Then Exit Sub 'Chưa đổ nguồn cho lưới
        tdbg.Columns(COL_AbsentTypeDateID).Tag = tdbg.Columns(COL_AbsentTypeDateID).Text
        '************************
        'Gán dữ liệu
        txtAbsentTypeDateID.Text = tdbg.Columns(COL_AbsentTypeDateID).Text
        txtAbsentTypeDateName.Text = tdbg.Columns(COL_AbsentTypeDateName).Text
        txtLookup.Text = tdbg.Columns(COL_Lookup).Text
        txtOrders.Text = tdbg.Columns(COL_Orders).Text
        txtUnitID.Text = tdbg.Columns(COL_UnitID).Text
        cboDecimals.Text = tdbg.Columns(COL_Decimals).Text
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        If L3Int(tdbg.Columns(COL_IsClassification).Text) = 1 Then
            chkIsClassification.Checked = True
            tdbcClassification.Enabled = True
        Else
            chkIsClassification.Checked = False
            tdbcClassification.Enabled = False
            chkIsValue.Enabled = False
        End If
        tdbcClassification.SelectedValue = tdbg.Columns(COL_ClassificationID).Text '.Item("ClassificationID").ToString
        If L3Int(tdbg.Columns(COL_IsValue).Text) = 1 Then
            chkIsValue.Checked = True
        Else
            chkIsValue.Checked = False
        End If
        '************************
        ReadOnlyControl(txtAbsentTypeDateID)
        btnAbsentConversion.Enabled = False
        chkDisabled.Visible = True
        btnCofficientInfo.Enabled = ReturnPermission("D13F5601") > 0
    End Sub

    Private Sub SetReturnFormView()
        _formState = EnumFormState.FormView
        EnableMenu(False)
        If tdbg.RowCount = 0 Then
            ClearText(grpDetail)
        Else
            LoadEdit()
            tdbg.Focus()
        End If
    End Sub

    Private Function AllowSave() As Boolean
        AllowSave = False
        Dim sSQL As String = ""
        If txtAbsentTypeDateID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ma_loai_cham_cong"))
            txtAbsentTypeDateID.Focus()
            Return False
        End If
        If txtAbsentTypeDateName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ten_cham_cong"))
            txtAbsentTypeDateName.Focus()
            Return False
        End If
        If txtLookup.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ten_tat"))
            txtLookup.Focus()
            Return False
        End If
        If txtOrders.Text.Trim <> "" Then
            If L3Int(txtOrders.Text) > MaxTinyInt Then
                D99C0008.Msg(rL3("Ban_da_nhap_du_lieu_khong_hop_le"))
                txtOrders.Text = ""
                txtOrders.Focus()
                Exit Function
            End If
        End If
        If txtUnitID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ten_don_vi_tinh"))
            txtUnitID.Focus()
            Return False
        End If

        If cboDecimals.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Lam_tron"))
            cboDecimals.Focus()
            Return False
        End If

        If _formState = EnumFormState.FormAdd Then
            sSQL = "select 1 from D13T0118  WITH (NOLOCK) where AbsentTypeDateID = " & SQLString(txtAbsentTypeDateID.Text)
            If ExistRecord(sSQL) Then
                D99C0008.MsgL3(rL3("Ma_loai_cham_cong_nay_da_ton_tai"))
                txtAbsentTypeDateID.Focus()
                Return False
            End If
            sSQL = "select 1 from D13T0118  WITH (NOLOCK) where Orders = " & SQLNumber(txtOrders.Text)
            If ExistRecord(sSQL) Then
                D99C0008.MsgL3(rL3("So_thu_tu_nay_da_ton_tai"))
                txtOrders.Focus()
                Return False
            End If
        Else
            If _formState = EnumFormState.FormEdit Then
                sSQL = "select 1 from D13T0118  WITH (NOLOCK) where Orders = " & SQLNumber(txtOrders.Text) & " AND  AbsentTypeDateID <> " & SQLString(txtAbsentTypeDateID.Text)
                If ExistRecord(sSQL) Then
                    D99C0008.MsgL3(rL3("So_thu_tu_nay_da_ton_tai"))
                    txtOrders.Focus()
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        txtAbsentTypeDateID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtAbsentTypeDateName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtOrders.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtLookup.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtUnitID.BackColor = COLOR_BACKCOLOROBLIGATORY
        cboDecimals.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        'Hỏi trước khi lưu
        If AskSave() = Windows.Forms.DialogResult.No Then
            ' SetReturnFormView()
            Exit Sub
        End If
        SaveData(sender)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'Hỏi trước khi lưu
        If AskSave() = Windows.Forms.DialogResult.No Then
            'SetReturnFormView()
            Exit Sub
        End If
        If SaveData(sender) Then tsbAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub btnNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotSave.Click
        If _formState = EnumFormState.FormAdd AndAlso txtAbsentTypeDateID.Text = "" Then
            If tdbg.RowCount > 0 Then
                LoadEdit()
            End If
            GoTo 1
        End If
        If AskMsgBeforeRowChange() Then
            If Not SaveData(sender) Then Exit Sub
        Else
            LoadEdit()
        End If
1:
        SetReturnFormView()
    End Sub

    Private Sub btnCofficientInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCofficientInfo.Click
        Dim f As New D13F1110
        With f
            .Type = "D13T0118"
            .TypeID = txtAbsentTypeDateID.Text
            .FormIDPermission = _formIDPermission
            .FormState = _FormState

            .ShowInTaskbar = False
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub btnAbsentConversion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbsentConversion.Click
        Dim sSQL As String = ""
        Dim sMethodID As String = ""
        Dim sCycle As String = ""
        Dim sConvertionHours As String = ""
        Dim sDecimal1 As String = "0"

        sSQL &= "Select MethodID, Cycle, ConvertionHours, Decimal1" & vbCrLf
        sSQL &= "From D13T0118 " & vbCrLf
        sSQL &= "Where AbsentTypeDateID = " & SQLString(txtAbsentTypeDateID.Text)

        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                If Number(.Item("ConvertionHours")) <> 0 Then
                    sMethodID = .Item("MethodID").ToString
                    sCycle = IIf(Number(.Item("Cycle")) = 0, "", SQLNumber(.Item("Cycle"), D13Format.DefaultNumber2)).ToString
                    sConvertionHours = IIf(Number(.Item("ConvertionHours")) = 0, "", SQLNumber(.Item("ConvertionHours"), D13Format.DefaultNumber2)).ToString
                    sDecimal1 = .Item("Decimal1").ToString
                End If
            End With
        End If

        Dim f As New D13F1002
        With f
            .ShowInTaskbar = False
            .AbsentTypeDateID = txtAbsentTypeDateID.Text
            .MethodID = sMethodID
            .Cycle = sCycle
            .ConvertionHours = sConvertionHours
            .Decimal1 = sDecimal1
            .ShowDialog()
            .Dispose()
        End With
    End Sub

#Region "Events tdbcClassification"

    Private Sub tdbcClassification_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcClassification.LostFocus
        If tdbcClassification.FindStringExact(tdbcClassification.Text) = -1 Then tdbcClassification.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcClassification.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcClassification.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub chkIsClassification_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsClassification.Click
        If chkIsClassification.Checked Then
            tdbcClassification.Enabled = True
            chkIsValue.Enabled = True
        Else
            tdbcClassification.Text = ""
            tdbcClassification.Enabled = False
            chkIsValue.Checked = False
            chkIsValue.Enabled = False
        End If
    End Sub
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.TopRight, grpDetail, pnlB, btnCofficientInfo)
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkShowDisabled)

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0118
    '# Created User: 
    '# Created Date: 19/01/2006 02:04:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0118() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D13T0118("
        sSQL &= "AbsentTypeDateID, AbsentTypeDateName, AbsentTypeDateNameU, Disabled, CreateUserID, CreateDate, "
        sSQL &= "LastModifyUserID, LastModifyDate, Orders,  UnitID,  UnitIDU, "
        sSQL &= "Lookup, LookupU, IsDailySheet, IsClassification, ClassificationID, IsValue, "
        sSQL &= "IsTimeSheet, Decimals"
        sSQL &= ") Values ("
        sSQL &= SQLString(txtAbsentTypeDateID.Text) & COMMA 'AbsentTypeDateID [KEY], varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtAbsentTypeDateName, False) & COMMA 'AbsentTypeDateName, varchar[50], NULL
        sSQL &= SQLStringUnicode(txtAbsentTypeDateName, True) & COMMA 'AbsentTypeDateName, varchar[50], NULL
        sSQL &= SQLNumber(IIf(chkDisabled.Checked = True, 1, 0)) & COMMA 'Disabled, bit, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'LastModifyDate, datetime, NULL
        sSQL &= SQLNumber(txtOrders.Text) & COMMA 'Orders, tinyint, NULL
        sSQL &= SQLStringUnicode(txtUnitID, False) & COMMA 'UnitID, varchar[20], NULL
        sSQL &= SQLStringUnicode(txtUnitID, True) & COMMA 'UnitID, varchar[20], NULL
        sSQL &= SQLStringUnicode(txtLookup, False) & COMMA 'Lookup, varchar[20], NULL
        sSQL &= SQLStringUnicode(txtLookup, True) & COMMA 'Lookup, varchar[20], NULL
        sSQL &= SQLNumber(0) & COMMA 'IsDailySheet, tinyint, NOT NULL
        sSQL &= SQLNumber(IIf(chkIsClassification.Checked = True, 1, 0)) & COMMA 'IsClassification, tinyint, NOT NULL
        sSQL &= SQLString(tdbcClassification.SelectedValue) & COMMA 'ClassificationID, varchar[20], NULL
        sSQL &= SQLNumber(IIf(chkIsValue.Checked = True, 1, 0)) & COMMA 'IsValue, tinyint, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'IsTimeSheet, tinyint, NOT NULL
        sSQL &= SQLNumber(cboDecimals.Text) 'IsTimeSheet, tinyint, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0118
    '# Created User: 
    '# Created Date: 19/01/2006 02:09:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0118() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T0118 Set "
        sSQL &= "AbsentTypeDateName = " & SQLStringUnicode(txtAbsentTypeDateName, False) & COMMA 'varchar[50], NULL
        sSQL &= "AbsentTypeDateNameU = " & SQLStringUnicode(txtAbsentTypeDateName, True) & COMMA 'varchar[50], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled.Checked = True, 1, 0)) & COMMA 'bit, NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" & COMMA 'datetime, NULL
        sSQL &= "Orders = " & SQLNumber(txtOrders.Text) & COMMA 'tinyint, NULL
        sSQL &= "UnitID = " & SQLStringUnicode(txtUnitID, False) & COMMA 'varchar[20], NULL
        sSQL &= "UnitIDU = " & SQLStringUnicode(txtUnitID, True) & COMMA 'varchar[20], NULL
        sSQL &= "Lookup = " & SQLStringUnicode(txtLookup, False) & COMMA 'varchar[20], NULL
        sSQL &= "LookupU = " & SQLStringUnicode(txtLookup, True) & COMMA 'varchar[20], NULL
        sSQL &= "IsDailySheet = " & SQLNumber(0) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsClassification = " & SQLNumber(IIf(chkIsClassification.Checked = True, 1, 0)) & COMMA 'tinyint, NOT NULL
        sSQL &= "ClassificationID = " & SQLString(tdbcClassification.SelectedValue) & COMMA 'varchar[20], NULL
        sSQL &= "IsValue = " & SQLNumber(IIf(chkIsValue.Checked = True, 1, 0)) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsTimeSheet = " & SQLNumber(1) & COMMA 'tinyint, NOT NULL
        sSQL &= "Decimals = " & SQLNumber(cboDecimals.Text) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "AbsentTypeDateID = " & SQLString(txtAbsentTypeDateID.Text)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0103
    '# Created User: Huỳnh Thị Mai Duyên
    '# Created Date: 18/01/2007 04:29:23
    '# Modified User:Huỳnh Thị Mai Duyên 
    '# Modified Date:18/01/2007 04:29:23 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0103(ByVal sAbsentTypeID As String) As String
        Dim sSQL As String
        sSQL = ""
        sSQL &= "Delete From D13T0103"
        sSQL &= " Where "
        sSQL &= "AbsentTypeID = " & SQLString(sAbsentTypeID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0118
    '# Created User: Huỳnh Thị Mai Duyên
    '# Created Date: 18/01/2007 04:29:23
    '# Modified User:Huỳnh Thị Mai Duyên 
    '# Modified Date:18/01/2007 04:29:23 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0118(ByVal sAbsentTypeID As String) As String
        Dim sSQL As String
        sSQL = ""
        sSQL &= "Delete From D13T0118"
        sSQL &= " Where "
        sSQL &= "AbsentTypeDateID = " & SQLString(sAbsentTypeID)
        Return sSQL
    End Function
End Class