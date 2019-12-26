Imports System
Imports System.Windows.Forms
Public Class D45F1013
    
#Region "Const of tdbg - Total of Columns: 7"
    Private Const COL_CreateDate As Integer = 0       ' CreateDate
    Private Const COL_CreateUserID As Integer = 1     ' CreateUserID
    Private Const COL_LastModifyDate As Integer = 2   ' LastModifyDate
    Private Const COL_LastModifyUserID As Integer = 3 ' LastModifyUserID
    Private Const COL_MachineID As Integer = 4        ' Máy sản xuất
    Private Const COL_MachineName As Integer = 5      ' Tên máy sản xuất
    Private Const COL_Disabled As Integer = 6         ' KSD
#End Region

    Private dtGrid As DataTable
    Dim iPerMe As Integer
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Dim iHeight As Integer = 0 ' Lấy tọa độ Y của chuột click tới

    Private _formPermission As String = "D45F1013"
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

    Private bLoadFormState As Boolean = False
    Private _FormState As EnumFormState = EnumFormState.FormView
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
            End Select
            bLoadFormState = True
        End Set
    End Property
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_May_san_xuat") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Danh móc MÀy s¶n xuÊt
        '================================================================ 
        lblMachineID.Text = rl3("May_san_xuat") 'Máy sản xuất
        lblMachineName.Text = rl3("Ten_may_san_xuat") 'Tên máy sản xuất
        '================================================================ 
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu và Nhập &tiếp
        btnNotSave.Text = rl3("_Khong_luu") '&Không Lưu
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        grpDetail.Text = rl3("Chi_tiet") 'Chi tiết
        '================================================================ 
        tdbg.Columns(COL_MachineID).Caption = rl3("May_san_xuat") 'Máy sản xuất
        tdbg.Columns(COL_MachineName).Caption = rl3("Ten_may_san_xuat") 'Tên máy sản xuất
        tdbg.Columns(COL_Disabled).Caption = rl3("KSD") 'KSD
        '================================================================ 
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

    Private Sub D45F1013_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        If bLoadFormState = False Then FormState = _FormState
        LoadInfoGeneral()
        gbEnabledUseFind = False
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        SetImageButton(btnSave, btnNotSave, btnNext, imgButton)
        ResetColorGrid(tdbg)
        LoadTDBGrid()
        SetShortcutPopupMenuNew(Me, ToolStrip1, ContextMenuStrip1)
        CheckIdTextBox(txtMachineID)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D45F1013_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormAdd Then
            txtMachineID.Focus()
        Else
            txtMachineName.Focus()
        End If
    End Sub

    Private Sub D45F1013_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FormState = EnumFormState.FormEdit Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If txtMachineID.Text <> "" Then
                If Not _bSaved Then
                    If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub D45F1013_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        Dim sSQL As String = ""
        sSQL = "--Do nguon cho luoi may san xuat" & vbCrLf & _
                "SELECT MachineID, MachineNameU AS MachineName, [Disabled], CreateDate, CreateUserID,LastModifyDate, " & _
                "LastModifyUserID" & vbCrLf & _
                "FROM D45T1110 WITH(NOLOCK) " & vbCrLf & _
                "ORDER BY MachineID" 
        dtGrid = ReturnDataTable(sSQL)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("MachineID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If

        If dtGrid.Rows.Count = 0 And tsbAdd.Enabled Then
            tsbAdd_Click(Nothing, Nothing)
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
            End If
        End If
    End Sub

    Private Sub ResetGrid()
        EnableMenu(False)
        FooterTotalGrid(tdbg, COL_MachineID)
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
        _bSaved = False
        txtMachineName.Focus()
        chkDisabled.Visible = True
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If Not CheckStore(SQLStoreD45P5555(1)) Then Exit Sub
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD45T1110())
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
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

    Private Sub tsmExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, mnsExportToExcel.Click
        Dim arrColObligatory() As Integer = {COL_MachineID}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, , , gbUnicode)
        Next
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
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
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        'Neu luoi co 1 dong thi k can chay su kien nay
        If tdbg.RowCount <= 1 Then Exit Sub
        If tdbg.Columns(COL_MachineID).Tag Is Nothing OrElse tdbg.Columns(COL_MachineID).Text <> tdbg.Columns(COL_MachineID).Tag.ToString Then
            LoadEdit()
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If txtMachineID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblMachineID.Text)
            txtMachineID.Focus()
            Return False
        End If
        If txtMachineName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblMachineName.Text)
            txtMachineName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If Not CheckStore(SQLStoreD45P5555(0)) Then Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        txtMachineID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtMachineName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function SaveData(ByVal sender As System.Object) As Boolean
        _bSaved = False
        If Not AllowSave() Then Return False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD45T1110())
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1110())
        End Select
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBGrid(True, txtMachineID.Text)
                Case EnumFormState.FormEdit
                    LoadTDBGrid(, txtMachineID.Text)
            End Select
            ReadOnlyControl(txtMachineID)
            SetReturnFormView()
        Else
            SaveNotOK()
            Return False
        End If
        Return True
    End Function

    Private Sub LoadAdd()
        _FormState = EnumFormState.FormAdd
        tdbg.Columns(COL_MachineID).Tag = ""
        '********************
        _bSaved = False
        '*******************
        ClearText(grpDetail)
        chkDisabled.Checked = False
        chkDisabled.Visible = False
        LockControlDetail(False)
        '*******************
        UnReadOnlyControl(True, txtMachineID)
        txtMachineID.Focus()
    End Sub

    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        If dtGrid.Rows.Count = 0 Then Exit Sub 'Chưa đổ nguồn cho lưới
        tdbg.Columns(COL_MachineID).Tag = tdbg.Columns(COL_MachineID).Text
        '************************
        'Gán dữ liệu

        txtMachineID.Text = tdbg.Columns(COL_MachineID).Text
        txtMachineName.Text = tdbg.Columns(COL_MachineName).Text
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        ReadOnlyControl(txtMachineID)

        chkDisabled.Visible = True
    End Sub

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
        If _FormState = EnumFormState.FormAdd AndAlso txtMachineID.Text = "" Then
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


#Region "SQL function"
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P5555
    '# Created User: Lê Anh Vũ
    '# Created Date: 27/09/2016 10:55:46
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P5555(iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra du lieu" & vbCrLf)
        sSQL &= "Exec D45P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(txtMachineID.Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1110
    '# Created User: Lê Anh Vũ
    '# Created Date: 27/09/2016 10:47:22
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1110() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Them moi may san xuat" & vbCrlf)
        sSQL.Append("Insert Into D45T1110(")
        sSQL.Append("MachineID, Disabled, CreateDate, CreateUserID, LastModifyDate, " & vbCrLf)
        sSQL.Append("LastModifyUserID, MachineNameU")
        sSQL.Append(") Values(" & vbCrlf)
        sSQL.Append(SQLString(txtMachineID.Text) & COMMA) 'MachineID, varchar[50], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[50], NOT NULL
        sSQL.Append("GetDate()" & COMMA & vbCrlf) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtMachineName, True)) 'MachineNameU, nvarchar[1000], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T1110
    '# Created User: Lê Anh Vũ
    '# Created Date: 27/09/2016 10:49:30
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T1110() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Sua may san xuat" & vbCrlf)
        sSQL.Append("Update D45T1110 Set ")
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("MachineNameU = " & SQLStringUnicode(txtMachineName, True)) 'nvarchar[1000], NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("MachineID = " & SQLString(txtMachineID.Text)) 'varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T1110
    '# Created User: Lê Anh Vũ
    '# Created Date: 27/09/2016 10:52:49
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T1110() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa may san xuat" & vbCrlf)
        sSQL &= "Delete From D45T1110"
        sSQL &= " Where "
        sSQL &= "MachineID = " & SQLString(txtMachineID.Text) 'varchar[50], NOT NULL
        Return sSQL
    End Function




#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.TopRight, grpDetail, pnlB)
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkShowDisabled)

    End Sub
End Class