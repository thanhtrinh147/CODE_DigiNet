Imports System
Imports System.Windows.Forms
Public Class D13F1180


#Region "Const of tdbg - Total of Columns: 8"
    Private Const COL_SalEmpGroupID As Integer = 0    ' Mã
    Private Const COL_SalEmpGroupName As Integer = 1  ' Tên
    Private Const COL_Note As Integer = 2             ' Note
    Private Const COL_Disabled As Integer = 3         ' KSD
    Private Const COL_CreateUserID As Integer = 4     ' CreateUserID
    Private Const COL_LastModifyUserID As Integer = 5 ' LastModifyUserID
    Private Const COL_CreateDate As Integer = 6       ' CreateDate
    Private Const COL_LastModifyDate As Integer = 7   ' LastModifyDate
#End Region

#Region "Const of tdbgD - Total of Columns: 4"
    Private Const COLD_EffectDateBegin As Integer = 0     ' Ngày hiệu lực
    Private Const COLD_EffectDateEnd As Integer = 1       ' Ngày hết hiệu lực
    Private Const COLD_Salary As Integer = 2              ' Mức lương
    Private Const COLD_RegionCeilingAmount As Integer = 3 ' Mức vượt trần
#End Region

    Private dtGrid, dtGridDetail As DataTable
    Dim iPerMe As Integer
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Dim iHeight As Integer = 0 ' Lấy tọa độ Y của chuột click tới

    Private _formPermission As String = "D13F1180"
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property


    Private _FormState As EnumFormState = EnumFormState.FormView
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
            End Select
        End Set
    End Property

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Danh_muc_nhom_luong_-_D13F1180") & UnicodeCaption(gbUnicode) 'Danh móc nhâm l§¥ng - D13F1180
        '================================================================ 
        chkShowDisabled.Text = rL3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        '================================================================ 
        tdbg.Columns("SalEmpGroupID").Caption = rL3("Ma") 'Mã
        tdbg.Columns("SalEmpGroupName").Caption = rL3("Ten") 'Tên
        tdbg.Columns("Disabled").Caption = rL3("KSD") 'KSD

        '================================================================ 
        lblSalEmpGroupID.Text = rL3("Ma") 'Mã
        lblSalEmpGroupName.Text = rL3("Ten") 'Tên
        lblNote.Text = rL3("Ghi_chu") 'Ghi chú
        '================================================================ 
        btnNext.Text = rL3("Luu_va_Nhap__tiep") 'Lưu và Nhập &tiếp
        btnNotSave.Text = rL3("_Khong_luu") '&Không Lưu
        btnSave.Text = rL3("_Luu") '&Lưu
        btnPermission.Text = "&" & rL3("Phan_quyen_du_lieu")
        '================================================================ 
        chkDisabled.Text = rL3("Khong_su_dung") 'Không sử dụng
        '================================================================ 

        '================================================================ 
        grpDetail.Text = rL3("Chi_tiet") 'Chi tiết
        '================================================================ 
        tdbgD.Columns(COLD_EffectDateBegin).Caption = rL3("Ngay_hieu_luc") 'Ngày hiệu lực
        tdbgD.Columns(COLD_EffectDateEnd).Caption = rL3("Ngay_het_hieu_luc") 'Ngày hết hiệu lực
        tdbgD.Columns(COLD_Salary).Caption = rL3("Muc_luong") 'Mức lương
        tdbgD.Columns(COLD_RegionCeilingAmount).Caption = rL3("Muc_vuot_tran") 'Mức vượt trần

    End Sub
    Private Sub D56F1030_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FormState = EnumFormState.FormEdit Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If txtSalEmpGroupID.Text <> "" Then
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
        If _FormState = EnumFormState.FormAdd Then
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
            CheckMenu(_formPermission, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        End If
    End Sub

    ' Trường hợp tìm kiếm không có dữ liệu thì Khóa Detail lại
    Private Sub LockControlDetail(ByVal bLock As Boolean)
        grpDetail.Enabled = Not bLock
    End Sub

    Private Sub D56F1030_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        SetBackColorObligatory()
        SetShortcutPopupMenu(Me, ToolStrip1, ContextMenuStrip1)
        ResetColorGrid(tdbg)
        tdbgD_NumberFormat()
        InputDateInTrueDBGrid(tdbgD, COLD_EffectDateBegin, COLD_EffectDateEnd)
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtSalEmpGroupID)
        gbEnabledUseFind = False
        LoadTDBGrid()
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D56F1030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub
    Private Sub SetBackColorObligatory()
        txtSalEmpGroupID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtSalEmpGroupName.BackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbgD.Splits(SPLIT0).DisplayColumns(COLD_EffectDateBegin).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbgD.Splits(SPLIT0).DisplayColumns(COLD_EffectDateEnd).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_Salary).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bFlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL = "Select SalEmpGroupID,SalEmpGroupName84" & UnicodeJoin(gbUnicode) & " as SalEmpGroupName,Disabled, Note" & UnicodeJoin(gbUnicode) & " As Note, CreateUserID,LastModifyUserID,CreateDate,LastModifyDate" & vbCrLf
        sSQL &= "From D13T1180  WITH (NOLOCK) "
        sSQL &= " Order by SalEmpGroupID"
        dtGrid = ReturnDataTable(sSQL)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If bFlagAdd Then
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then 'Khi Thêm mới hoặc Sửa đều thực thi
            Dim dt As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt.Select(tdbg.Columns(COL_SalEmpGroupID).DataField & " = " & SQLString(sKey), dt.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt.Rows.IndexOf(dr(0))
            If Not tdbg.Focused Then tdbg.Focus()
        End If
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
        If _FormState = EnumFormState.FormAdd Then Exit Sub

        If tdbg.RowCount = 0 Then
            ClearText(grpDetail)
            LockControlDetail(True)
        Else
            LockControlDetail(False)
            _FormState = EnumFormState.FormView
            If bLoadEdit Then
                LoadEdit()
                'tdbg.Focus()
            End If
        End If
    End Sub

    Private Sub ResetGrid()
        EnableMenu(False)
        FooterTotalGrid(tdbg, COL_SalEmpGroupID)
    End Sub

    Private Sub tdbgD_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbgD.Columns(COLD_Salary).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbgD.Columns(COLD_RegionCeilingAmount).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbgD, arr)
    End Sub

    Private Sub CalRegionCeilingAmount()
        tdbgD.Columns(COLD_RegionCeilingAmount).Value = Number(tdbgD.Columns(COLD_Salary).Value) * 20
    End Sub
    Private Sub tdbgD_AfterColUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgD.AfterColUpdate
        Select Case tdbgD.Col
            Case COLD_EffectDateEnd
                CalDateFrom()
            Case COLD_Salary
                CalDateFrom()
                CalDateTo()
                CalRegionCeilingAmount()
        End Select
        'ResetGridDetail()
    End Sub

    Private Sub CalDateFrom(Optional ByVal bAfterDelete As Boolean = False)
        'If tdbgD.Row = 0 Then tdbgD.Columns(COLD_EffectDateBegin).Text = "01/01/1900"

        If bAfterDelete = False Then
            If tdbgD.Row <> 0 Then
                If tdbgD.Columns(COLD_EffectDateBegin).Text = "" Then
                    If tdbgD(tdbgD.Row - 1, COLD_EffectDateEnd).ToString <> "" Then tdbgD.Columns(COLD_EffectDateBegin).Value = DateAdd(DateInterval.Day, 1, CDate(tdbgD(tdbgD.Row - 1, COLD_EffectDateEnd)))
                End If
            End If
            If tdbgD.Row < tdbgD.RowCount - 1 Then
                If tdbgD.Columns(COLD_EffectDateEnd).Text <> "" Then tdbgD(tdbgD.Row + 1, COLD_EffectDateBegin) = DateAdd(DateInterval.Day, 1, CDate(tdbgD.Columns(COLD_EffectDateEnd).Value))
            End If
        Else
            If tdbgD.Row <> 0 Then
                If tdbgD(tdbgD.Row - 1, COLD_EffectDateEnd).ToString <> "" Then tdbgD.Columns(COLD_EffectDateBegin).Value = DateAdd(DateInterval.Day, 1, CDate(tdbgD(tdbgD.Row - 1, COLD_EffectDateEnd)))
            End If
        End If
    End Sub

    Private Sub CalDateTo()
        If tdbgD.Columns(COLD_EffectDateEnd).Text = "" Then
            tdbgD.Columns(COLD_EffectDateEnd).Value = tdbgD.Columns(COLD_EffectDateBegin).Value
        End If
    End Sub
    Private Sub tdbgD_AfterDelete(sender As Object, e As EventArgs) Handles tdbgD.AfterDelete
        CalDateFrom(True)
        tdbg.UpdateData()
    End Sub
    Private Sub tdbgD_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbgD.FetchCellStyle
        Select Case e.Col
            Case COLD_EffectDateBegin
                If e.Row > 0 Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
        End Select
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
        _FormState = EnumFormState.FormEdit
        EnableMenu(True)
        ReadOnlyControl(txtSalEmpGroupID)
        _bSaved = False
        txtSalEmpGroupName.Focus()
        chkDisabled.Visible = True
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If (Not CheckStore(SQLStoreD13P5555)) Then Exit Sub
        Dim sSQLDelete As String
        sSQLDelete = "Delete D13T1180 where SalEmpGroupID = " & SQLString(tdbg.Columns(COL_SalEmpGroupID).Text) & vbCrLf
        sSQLDelete &= SQLDeleteD13T1181()
        Dim bRunSQL As Boolean = ExecuteSQL(sSQLDelete.ToString)
        If bRunSQL Then
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            If dtGrid.Rows.Count = 0 Then
                ResetGrid()
                tsbAdd_Click(Nothing, Nothing)
            Else
                ReLoadTDBGrid()
            End If
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub mnsSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsSysInfo.Click, tsbSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub
#End Region

    Private Sub tsmExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim arrColObligatory() As Integer = {COL_SalEmpGroupID}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
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
        If tdbg.Columns(COL_SalEmpGroupID).Tag Is Nothing OrElse tdbg.Columns(COL_SalEmpGroupID).Text <> tdbg.Columns(COL_SalEmpGroupID).Tag.ToString Then
            LoadEdit()
        End If
    End Sub

    Private Function SaveData(ByVal sender As System.Object) As Boolean
        _bSaved = False
        If Not AllowSave() Then Return False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD13T1180().ToString() & vbCrLf)
                sSQL.Append(SQLDeleteD13T1181() & vbCrLf)
                sSQL.Append(SQLInsertD13T1181s().ToString())
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T1180.ToString() & vbCrLf)
                sSQL.Append(SQLDeleteD13T1181() & vbCrLf)
                sSQL.Append(SQLInsertD13T1181s().ToString())
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBGrid(True, txtSalEmpGroupID.Text)
                Case EnumFormState.FormEdit
                    LoadTDBGrid(, txtSalEmpGroupID.Text)
            End Select
            ReadOnlyControl(txtSalEmpGroupID)
            SetReturnFormView()
        Else
            SaveNotOK()
            Return False
        End If
        Return True
    End Function

    Private Sub LoadAdd()
        _FormState = EnumFormState.FormAdd
        tdbg.Columns(COL_SalEmpGroupID).Tag = ""
        '********************
        ClearText(grpDetail)
        chkDisabled.Checked = False
        chkDisabled.Visible = False
        LockControlDetail(False)
        '*******************
        UnReadOnlyControl(True, txtSalEmpGroupID)
        '*******************
        txtSalEmpGroupID.Focus()
        btnPermission.Enabled = False
        LoadTDBGridDetail()
    End Sub

    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        If dtGrid.Rows.Count = 0 Then Exit Sub 'Chưa đổ nguồn cho lưới
        tdbg.Columns(COL_SalEmpGroupID).Tag = tdbg.Columns(COL_SalEmpGroupID).Text
        txtSalEmpGroupID.Text = tdbg.Columns(COL_SalEmpGroupID).Text
        txtSalEmpGroupName.Text = tdbg.Columns(COL_SalEmpGroupName).Text
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        txtNote.Text = tdbg.Columns(COL_Note).Text
        ReadOnlyControl(txtSalEmpGroupID)
        chkDisabled.Visible = True
        btnPermission.Enabled = True
        LoadTDBGridDetail()
    End Sub

    Private Sub LoadTDBGridDetail()
        Dim sSQL As String
        sSQL = "SELECT		T1.SalEmpGroupID, T1.EffectDateBegin, T1.EffectDateEnd, T1.Salary, T1.RegionCeilingAmount" & vbCrLf & _
                "FROM 		D13T1181 T1 WITH (NOLOCK) " & vbCrLf & _
                "LEFT JOIN	D13T1180 T2 WITH (NOLOCK)  " & vbCrLf & _
                "ON 		T1. SalEmpGroupID = T2. SalEmpGroupID " & vbCrLf & _
                " WHERE T1. SalEmpGroupID =  " & SQLString(txtSalEmpGroupID.Text) & vbCrLf & _
                "ORDER BY 	T1. EffectDateBegin"
        dtGridDetail = ReturnDataTable(sSQL)
        LoadDataSource(tdbgD, dtGridDetail, gbUnicode)
        'ResetGridDetail()
    End Sub

    'Private Sub ResetGridDetail()
    '    FooterTotalGrid(tdbgD, COLD_EffectDateBegin)
    '    FooterSumNew(tdbgD, COLD_Salary)
    'End Sub
    Private Sub SetReturnFormView()
        _FormState = EnumFormState.FormView
        EnableMenu(False)
        If tdbg.RowCount = 0 Then
            ClearText(grpDetail)
        Else
            LoadEdit()
            tdbg.Focus()
        End If
    End Sub
    Private Function AllowSave() As Boolean
        If txtSalEmpGroupID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter("Mã")
            txtSalEmpGroupID.Focus()
            Return False
        End If
        If txtSalEmpGroupName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter("Tên")
            txtSalEmpGroupName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D13T1180", "SalEmpGroupID", txtSalEmpGroupID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtSalEmpGroupID.Focus()
                Return False
            End If
        End If
        tdbgD.UpdateData()
        For i As Integer = 0 To tdbgD.RowCount - 1
            If i <> 0 AndAlso tdbgD(i, COLD_EffectDateBegin).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbgD.Columns(COLD_EffectDateBegin).Caption)
                tdbgD.Focus()
                tdbgD.SplitIndex = 0
                tdbgD.Col = COLD_EffectDateBegin
                tdbgD.Row = i  'findrowInGrid(tdbgD, xxxxKeyValue, xxxxFieldKey)
                Return False
            End If
            If i <> tdbgD.RowCount - 1 AndAlso tdbgD(i, COLD_EffectDateEnd).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbgD.Columns(COLD_EffectDateEnd).Caption)
                tdbgD.Focus()
                tdbgD.SplitIndex = 0
                tdbgD.Col = COLD_EffectDateEnd
                tdbgD.Row = i  'findrowInGrid(tdbgD, xxxxKeyValue, xxxxFieldKey)
                Return False
            End If
            If tdbgD(i, COLD_Salary).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbgD.Columns(COLD_Salary).Caption)
                tdbgD.Focus()
                tdbgD.SplitIndex = 0
                tdbgD.Col = COLD_Salary
                tdbgD.row = i  'findrowInGrid(tdbgD, xxxxKeyValue, xxxxFieldKey)
                Return False
            End If

            If tdbgD(i, COLD_RegionCeilingAmount).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbgD.Columns(COLD_Salary).Caption)
                tdbgD.Focus()
                tdbgD.SplitIndex = 0
                tdbgD.Col = COLD_RegionCeilingAmount
                tdbgD.Row = i  'findrowInGrid(tdbgD, xxxxKeyValue, xxxxFieldKey)
                Return False
            End If

            'Dòng đầu tiên có nhập Từ, Dòng cuối cùng có nhập Đến, dòng giữa thì kiểm tra
            If (i = 0 AndAlso tdbgD(i, COLD_EffectDateBegin).ToString <> "") OrElse (i = tdbgD.RowCount - 1 AndAlso tdbgD(i, COLD_EffectDateEnd).ToString <> "") OrElse (i > 0 AndAlso i < tdbgD.RowCount - 1) Then
                If L3String(tdbgD(i, COLD_EffectDateBegin)) <> "" AndAlso L3String(tdbgD(i, COLD_EffectDateEnd)) <> "" AndAlso CDate(SQLDateShow(tdbgD(i, COLD_EffectDateBegin))) > CDate(SQLDateShow(tdbgD(i, COLD_EffectDateEnd))) Then
                    D99C0008.MsgL3(tdbgD.Columns(COLD_EffectDateBegin).Caption & " " & rL3("ANho_hon_hoac_bang").ToLower() & " " & tdbgD.Columns(COLD_EffectDateEnd).Caption)
                    tdbgD.Focus()
                    tdbgD.SplitIndex = 0
                    tdbgD.Col = COLD_EffectDateBegin
                    tdbgD.Row = i
                    Return False
                End If
            End If
        Next
        Return True
    End Function


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
        If _FormState = EnumFormState.FormAdd AndAlso txtSalEmpGroupID.Text = "" Then
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

    Private Sub btnPermission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPermission.Click
        Dim exe As D00E4240
        exe = New D00E4240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = "D00F0260"
        exe.FormPermission = "D00F0260"
        exe.Code = tdbg.Columns(COL_SalEmpGroupID).Text
        exe.Name = tdbg.Columns(COL_SalEmpGroupName).Text
        exe.ListType = "SalEmpGroup"
        exe.Run()
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.TopRight, grpDetail, pnlB)
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkShowDisabled, btnPermission)

    End Sub

#Region "SQL function"
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1180
    '# Created User: Lê Đình Thái
    '# Created Date: 13/10/2011 03:20:19
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1180() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D13T1180(")
        sSQL.Append("SalEmpGroupID, SalEmpGroupName84, SalEmpGroupName84U, Note, NoteU, ")
        sSQL.Append("Disabled, CreateUserID, LastModifyUserID, CreateDate, LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtSalEmpGroupID.Text) & COMMA) 'SalEmpGroupID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtSalEmpGroupName.Text, gbUnicode, False) & COMMA) 'SalEmpGroupName84, varchar[1000], NOT NULL
        sSQL.Append(SQLStringUnicode(txtSalEmpGroupName.Text, gbUnicode, True) & COMMA) 'SalEmpGroupName84U, nvarchar, NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'Note, varchar[500], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'NoteU, nvarchar, NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Lê Đình Thái
    '# Created Date: 13/10/2011 02:54:41
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F1180") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_SalEmpGroupID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= "Null" & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= "Null" 'DateTo, datetime, NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1180
    '# Created User: Lê Đình Thái
    '# Created Date: 13/10/2011 03:22:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1180() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T1180 Set ")
        sSQL.Append("SalEmpGroupName84 = " & SQLStringUnicode(txtSalEmpGroupName.Text, gbUnicode, False) & COMMA) 'varchar[1000], NOT NULL
        sSQL.Append("SalEmpGroupName84U = " & SQLStringUnicode(txtSalEmpGroupName.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NOT NULL
        sSQL.Append(" Where  SalEmpGroupID = " & SQLString(txtSalEmpGroupID.Text))
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1181
    '# Created User: Lê Anh Vũ
    '# Created Date: 07/07/2016 04:04:33
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1181() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu chi tiet" & vbCrlf)
        sSQL &= "Delete From D13T1181"
        sSQL &= " Where SalEmpGroupID = " & SQLString(txtSalEmpGroupID.Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1181s
    '# Created User: Lê Anh Vũ
    '# Created Date: 07/07/2016 04:05:53
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1181s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbgD.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Them du lieu chi tiet" & vbCrlf)
            sSQL.Append("Insert Into D13T1181(")
            sSQL.Append("SalEmpGroupID, EffectDateBegin, EffectDateEnd, Salary,RegionCeilingAmount")
            sSQL.Append(") Values(" & vbCrlf)
            sSQL.Append(SQLString(txtSalEmpGroupID.Text) & COMMA) 'SalEmpGroupID, varchar[50], NOT NULL
            sSQL.Append(SQLDateSave(tdbgD(i, COLD_EffectDateBegin)) & COMMA) 'EffectDateBegin, datetime, NOT NULL
            sSQL.Append(SQLDateSave(tdbgD(i, COLD_EffectDateEnd)) & COMMA) 'EffectDateEnd, datetime, NULL
            sSQL.Append(SQLMoney(tdbgD(i, COLD_Salary), tdbgD.Columns(COLD_Salary).NumberFormat) & COMMA) 'Salary, money, NOT NULL
            sSQL.Append(SQLMoney(tdbgD(i, COLD_RegionCeilingAmount), tdbgD.Columns(COLD_RegionCeilingAmount).NumberFormat)) 'Salary, money, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function




#End Region


End Class