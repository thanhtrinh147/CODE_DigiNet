Imports System
Public Class D45F1061
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Dim iBookmark As Integer
    Dim dtGrid, dtGrid1 As DataTable
    Dim bKeyPress As Boolean = False
    Dim bHeadClick As Boolean = False, bHeadClick1 As Boolean = False
    Public bReadOnly As Boolean = False

#Region "Const of tdbg"
    Private Const COL_Orders As Integer = 0      ' STT
    Private Const COL_Disabled As Integer = 1    ' Chọn
    Private Const COL_PWCalNo As Integer = 2     ' PWCalNo
    Private Const COL_Caption As Integer = 3     ' Diễn giải
    Private Const COL_ShortName As Integer = 4   ' Tên tắt
    Private Const COL_Formula As Integer = 5     ' Formula
    Private Const COL_FormulaDesc As Integer = 6 ' FormulaDesc
    Private Const COL_Decimals As Integer = 7    ' Decimals
    Private Const COL_IsNotPrint As Integer = 8  ' Không in
#End Region

#Region "Const of tdbg2"
    Private Const COL1_FunctionID As Integer = 0  ' Tên hàm
    Private Const COL1_Description As Integer = 1 ' Diễn giải
#End Region

    Private _pieceworkCalMethodID As String
    Public Property PieceworkCalMethodID() As String
        Get
            Return _pieceworkCalMethodID
        End Get
        Set(ByVal Value As String)
            _pieceworkCalMethodID = Value
        End Set
    End Property

    Private _description As String
    Public WriteOnly Property Description() As String
        Set(ByVal Value As String)
            _description = Value
        End Set
    End Property

    Private _disabled As Boolean
    Public WriteOnly Property Disabled() As Boolean
        Set(ByVal Value As Boolean)
            _disabled = Value
        End Set
    End Property

    Private _isHACoefUP As Boolean
    Public WriteOnly Property IsHACoefUP() As Boolean
        Set(ByVal Value As Boolean)
            _isHACoefUP = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            LoadTDBCombo()

            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = False
                    LoadAddNew()
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub D15F1101_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bKeyPress Then Exit Sub

        If _FormState = EnumFormState.FormEdit Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If btnSave.Enabled Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        End If
    End Sub

    Private Sub D15F1101_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D15F1101_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetBackColorObligatory()
        ResetColorGrid(tdbg)
        ResetColorGrid(tdbg1)
        Loadlanguage()
        CheckIdTextBox(txtPieceworkCalMethodID)
        CheckIdTextBox(txtTempFormula, 2000, True)
        tdbg_LockedColumns()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Orders).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub SetBackColorObligatory()
        txtPieceworkCalMethodID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtDescription.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_phuong_phap_tinh_luong_san_pham_-_D45F1061") & UnicodeCaption(gbUnicode) 'Chi tiÕt ph§¥ng phÀp tÛnh l§¥ng s¶n phÈm - D45F1061
        '================================================================ 
        lblPieceworkCalMethodID.Text = rl3("Ma") 'Mã 
        lbDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblFunctionID.Text = rl3("Cac_ham_tinh_luong") 'Các hàm tính lương
        lblTempFormulaDesc.Text = rl3("Dien_giai_cong_thuc") 'Diễn giải công thức
        lblTempFormula.Text = rl3("Cong_thuc") 'Công thức
        lblDecimals.Text = rl3("Lam_tron") 'Làm tròn
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkViewAll.Text = rl3("Hien_thi_tat_ca") 'Hiển thị tất cả
        chkIsHACoefUP.Text = rl3("Theo_don_gia_GCHS") 'Theo đơn giá GCHS
        '================================================================ 
        tdbcDecimals.Columns("Decimals").Caption = rl3("Ma") 'Mã
        '================================================================ 
        tdbg.Columns("Orders").Caption = rl3("STT") 'STT
        tdbg.Columns("Disabled").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("Caption").Caption = rl3("Ten") 'Tên
        tdbg.Columns("ShortName").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg.Columns("IsNotPrint").Caption = rl3("Khong_in") 'Không in
        '================================================================ 
        tdbg1.Columns("FunctionID").Caption = rl3("Ten_ham") 'Tên hàm
        tdbg1.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải

        End Sub


#Region "Events tdbcDecimals"

    Private Sub tdbcDecimals_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDecimals.LostFocus
        If tdbcDecimals.FindStringExact(tdbcDecimals.Text) = -1 Then tdbcDecimals.Text = ""
    End Sub

#End Region

    Private Sub LoadTDBGrid(Optional ByVal sPieceworkCalMethodID As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD45P1061(sPieceworkCalMethodID)
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        '********************
        'Gan gtri cho textbox Cong thuc
        tdbg.Bookmark = 0
        '********************
        LoadTDBGrid1()
    End Sub

    Private Sub LoadTDBGrid1()
        If dtGrid1 Is Nothing Then
            'Load luoi Cac hàm tinh luong
            Dim sSQL As String = ""
            sSQL = "Select FunctionID, Description" & UnicodeJoin(gbUnicode) & " as Description , Mode" & vbCrLf
            sSQL &= "From D45V1010 Order by TransID"
            dtGrid1 = ReturnDataTable(sSQL)
        End If
        If chkIsHACoefUP.Checked Then
            LoadDataSource(tdbg1, ReturnTableFilter(dtGrid1, "Mode =1", True), gbUnicode)
        Else
            LoadDataSource(tdbg1, ReturnTableFilter(dtGrid1, "Mode =0", True), gbUnicode)
        End If
    End Sub

    Private Sub chkIsHACoefUP_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsHACoefUP.CheckedChanged
        LoadTDBGrid(_pieceworkCalMethodID)
        '***************************
        If _pieceworkCalMethodID = "" Then 'Them moi
            chkViewAll.Checked = True
        Else 'Ke thua
            chkViewAll.Checked = False
        End If
        chkViewAll_Click(Nothing, Nothing)
    End Sub

    Private Sub LoadAddNew()
        txtPieceworkCalMethodID.Text = ""
        txtDescription.Text = ""
        chkDisabled.Checked = False
        chkIsHACoefUP.Checked = False
        tdbcDecimals.Text = "0"
        '***************************
        LoadTDBGrid(_pieceworkCalMethodID)
        '***************************
        If _PieceworkCalMethodID = "" Then 'Them moi
            chkViewAll.Checked = True
        Else 'Ke thua
            chkViewAll.Checked = False
        End If
        chkViewAll_Click(Nothing, Nothing)
    End Sub

    Private Sub LoadEdit()
        ReadOnlyControl(txtPieceworkCalMethodID)
        txtPieceworkCalMethodID.Text = _PieceworkCalMethodID
        txtDescription.Text = _description
        chkDisabled.Checked = _disabled
        chkIsHACoefUP.Checked = _isHACoefUP
        chkIsHACoefUP.Enabled = False
        '**************************
        'khoa cac control tru Dien giai va K su dung neu bReadOnly=True
        If bReadOnly Then
            ReadOnlyControl(tdbcDecimals)
            ReadOnlyControl(txtTempFormula)
            ReadOnlyControl(txtTempFormulaDesc)
            chkViewAll.Enabled = False
            tdbg.AllowUpdate = False
            tdbg1.AllowUpdate = False
        End If
        '**************************
        LoadTDBGrid(_pieceworkCalMethodID)
        '**************************
        chkViewAll.Checked = False
        chkViewAll_Click(Nothing, Nothing)
    End Sub

    Private Sub chkViewAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkViewAll.Click
        tdbg.UpdateData()

        If chkViewAll.Checked = False Then
            dtGrid.DefaultView.RowFilter = "Disabled=1"
        Else
            dtGrid.DefaultView.RowFilter = ""
        End If

        tdbg.Bookmark = 0

        'Gan gtri cho textbox Cong thuc
        txtTempFormula.Text = ""
        txtTempFormulaDesc.Text = ""
        tdbcDecimals.Text = "0"

        CalFormular(tdbg(tdbg.Bookmark, COL_Formula).ToString)
        txtTempFormulaDesc.Text = tdbg(tdbg.Bookmark, COL_FormulaDesc).ToString
        tdbcDecimals.Text = tdbg(tdbg.Bookmark, COL_Decimals).ToString
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        txtPieceworkCalMethodID.Text = ""
        txtDescription.Text = ""
        chkDisabled.Checked = False
        chkIsHACoefUP.Checked = False
        tdbcDecimals.Text = "0"
        txtTempFormula.Text = ""
        txtTempFormulaDesc.Text = ""
        LoadTDBGrid()

        btnSave.Enabled = True
        btnNext.Enabled = False
        txtPieceworkCalMethodID.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If txtPieceworkCalMethodID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtPieceworkCalMethodID.Focus()
            Return False
        End If
        If txtDescription.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtDescription.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D45T1060", "PieceworkCalMethodID", txtPieceworkCalMethodID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtPieceworkCalMethodID.Focus()
                Return False
            End If
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_Caption).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_Caption
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_ShortName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_ShortName
                tdbg.Bookmark = i
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        If Not AllowSave() Then Exit Sub

        'Luu du lieu lai neu Luu ma chua di chuyen dong
        tdbg(tdbg.Row, COL_Formula) = txtTempFormula.Text
        tdbg(tdbg.Row, COL_FormulaDesc) = txtTempFormulaDesc.Text
        tdbg(tdbg.Row, COL_Decimals) = tdbcDecimals.Text

        tdbg.UpdateData()

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD45T1060.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1061s.ToString & vbCrLf)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1060.ToString & vbCrLf)
                sSQL.Append(SQLDeleteD45T1061.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1061s.ToString & vbCrLf)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            _bSaved = True
            _PieceworkCalMethodID = txtPieceworkCalMethodID.Text
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
                    'RunAuditLog(AuditCodePieceworkCalMethodID, "02", gsDivisionID, txtPieceworkCalMethodID.Text, txtDescription.Text)
                    Lemon3.D91.RunAuditLog("45", AuditCodePieceworkCalMethodID, "02", gsDivisionID, txtPieceworkCalMethodID.Text, txtDescription.Text)
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function CreateTableRound() As DataTable
        Dim dtRound As New DataTable
        Dim colSalary As New DataColumn("Decimals")
        dtRound.Columns.Add(colSalary)
        Dim rowSalary As DataRow
        For i As Integer = -5 To 5
            rowSalary = dtRound.NewRow
            rowSalary("Decimals") = i.ToString
            dtRound.Rows.Add(rowSalary)
        Next
        Return dtRound
    End Function

    Private Sub LoadTDBCombo()
        LoadDataSource(tdbcDecimals, CreateTableRound(), gbUnicode)
    End Sub

    Private Sub CalFormular(ByVal sFormular As String)
        Dim iStart As Integer
        Dim sBefore As String = """"
        Dim sAfter As String = ""

        'Giu lai vtri con tro chuot dang dung va cat chuoi

        iStart = txtTempFormula.SelectionStart
        sBefore = txtTempFormula.Text.Substring(0, iStart)
        sAfter = txtTempFormula.Text.Substring(iStart, txtTempFormula.Text.Length - iStart)

        txtTempFormula.Text = sBefore & sFormular & sAfter
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then
            Return
        End If
        Select Case e.ColIndex
            Case COL_Disabled
                bHeadClick = Not bHeadClick
                For i As Integer = tdbg.RowCount - 1 To 0 Step -1
                    tdbg(i, COL_Disabled) = bHeadClick
                Next
            Case COL_IsNotPrint
                bHeadClick1 = Not bHeadClick1
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, COL_IsNotPrint) = bHeadClick1
                Next
            Case COL_Caption, COL_ShortName
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Value.ToString, tdbg.Bookmark)
                Exit Sub
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control = True And e.KeyCode = Keys.V Then
            e.Handled = True
            e.SuppressKeyPress = True
            tdbg.Columns(tdbg.Col).Text = Clipboard.GetText()
            tdbg.UpdateData()
        End If
        If e.Control And e.KeyCode = Keys.S Then
            Select Case tdbg.Col
                Case COL_Caption, COL_ShortName
                    CopyColumns(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Value.ToString, tdbg.Bookmark)
            End Select
        ElseIf e.KeyCode = Keys.Enter And tdbg.Col = COL_IsNotPrint Then
            HotKeyEnterGrid(tdbg, COL_Disabled, e)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_Disabled, 0)
    End Sub

    Private Sub tdbg_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeRowColChange
        tdbg.UpdateData()

        tdbg(tdbg.Bookmark, COL_Formula) = txtTempFormula.Text
        tdbg(tdbg.Bookmark, COL_FormulaDesc) = txtTempFormulaDesc.Text
        tdbg(tdbg.Bookmark, COL_Decimals) = tdbcDecimals.Text
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.RowCount = 0 OrElse e.LastRow = tdbg.Bookmark Then Exit Sub

        'Gan gtri cho textbox Cong thuc
        txtTempFormula.Text = ""
        txtTempFormulaDesc.Text = ""
        tdbcDecimals.Text = "0"

        CalFormular(tdbg(tdbg.Row, COL_Formula).ToString)
        txtTempFormulaDesc.Text = tdbg(tdbg.Row, COL_FormulaDesc).ToString
        tdbcDecimals.Text = tdbg(tdbg.Row, COL_Decimals).ToString
    End Sub

    Private Sub tdbg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg1.DoubleClick
        'Gan gtri cho textbox Cong thuc
        CalFormular(tdbg1(tdbg1.Row, COL1_FunctionID).ToString)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1060
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 19/10/2009 01:57:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1060() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D45T1060(")
        sSQL.Append("PieceworkCalMethodID, Description, DescriptionU, IsHACoefUP, Disabled, CreateUserID, LastModifyUserID, ")
        sSQL.Append("CreateDate, LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtPieceworkCalMethodID.Text) & COMMA) 'PieceworkCalMethodID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA) 'Description, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA) 'Description, varchar[150], NOT NULL
        sSQL.Append(SQLNumber(chkIsHACoefUP.Checked) & COMMA) 'IsHACoefUP, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T1060
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 19/10/2009 01:57:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T1060() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T1060 Set ")
        sSQL.Append("Description = " & SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("IsHACoefUP = " & SQLNumber(chkIsHACoefUP.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("PieceworkCalMethodID = " & SQLString(_PieceworkCalMethodID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1061s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 19/10/2009 01:58:08
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1061s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To dtGrid.Rows.Count - 1
            If L3Bool(dtGrid.Rows(i).Item("Disabled")) Then
                sSQL.Append("Insert Into D45T1061(")
                sSQL.Append("PieceworkCalMethodID, PWCalNo, Caption, CaptionU, ShortName, ShortNameU, Formula, ")
                sSQL.Append("FormulaDesc, FormulaDescU, Decimals, Disabled, ")
                sSQL.Append("IsNotPrint")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(txtPieceworkCalMethodID.Text) & COMMA) 'PieceworkCalMethodID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(dtGrid.Rows(i).Item("PWCalNo").ToString) & COMMA) 'PWCalNo [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(dtGrid.Rows(i).Item("Caption").ToString, gbUnicode, False) & COMMA) 'Caption, varchar[150], NULL
                sSQL.Append(SQLStringUnicode(dtGrid.Rows(i).Item("Caption").ToString, gbUnicode, True) & COMMA) 'Caption, varchar[150], NULL
                sSQL.Append(SQLStringUnicode(dtGrid.Rows(i).Item("ShortName").ToString, gbUnicode, False) & COMMA) 'ShortName, varchar[50], NULL
                sSQL.Append(SQLStringUnicode(dtGrid.Rows(i).Item("ShortName").ToString, gbUnicode, True) & COMMA) 'ShortName, varchar[50], NULL
                sSQL.Append(SQLString(dtGrid.Rows(i).Item("Formula").ToString) & COMMA) 'Formula, varchar[2000], NULL
                sSQL.Append(SQLStringUnicode(dtGrid.Rows(i).Item("FormulaDesc").ToString, gbUnicode, False) & COMMA) 'FormulaDesc, varchar[2000], NULL
                sSQL.Append(SQLStringUnicode(dtGrid.Rows(i).Item("FormulaDesc").ToString, gbUnicode, True) & COMMA) 'FormulaDesc, varchar[2000], NULL
                sSQL.Append(SQLNumber(dtGrid.Rows(i).Item("Decimals").ToString) & COMMA) 'Decimals, int, NOT NULL
                sSQL.Append(SQLNumber(IIf(L3Bool(dtGrid.Rows(i).Item("Disabled")), 0, 1).ToString) & COMMA) 'Disabled, tinyint, NOT NULL
                sSQL.Append(SQLNumber(dtGrid.Rows(i).Item("IsNotPrint"))) 'IsNotPrint, tinyint, NOT NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T1061
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 18/12/2009 10:42:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T1061() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T1061"
        sSQL &= " Where "
        sSQL &= "PieceworkCalMethodID = " & SQLString(_PieceworkCalMethodID)

        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T1061s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 19/10/2009 01:58:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T1061s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To dtGrid.Rows.Count - 1
            sSQL.Append("Update D45T1061 Set ")
            sSQL.Append("Caption = " & SQLStringUnicode(dtGrid.Rows(i).Item("Caption").ToString, gbUnicode, False) & COMMA) 'varchar[150], NULL
            sSQL.Append("CaptionU = " & SQLStringUnicode(dtGrid.Rows(i).Item("Caption").ToString, gbUnicode, True) & COMMA) 'varchar[150], NULL
            sSQL.Append("ShortName = " & SQLStringUnicode(dtGrid.Rows(i).Item("ShortName").ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
            sSQL.Append("ShortNameU = " & SQLStringUnicode(dtGrid.Rows(i).Item("ShortName").ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
            sSQL.Append("Formula = " & SQLString(dtGrid.Rows(i).Item("Formula").ToString) & COMMA) 'varchar[2000], NULL
            sSQL.Append("FormulaDesc = " & SQLStringUnicode(dtGrid.Rows(i).Item("FormulaDesc").ToString, gbUnicode, False) & COMMA) 'varchar[2000], NULL
            sSQL.Append("FormulaDescU = " & SQLStringUnicode(dtGrid.Rows(i).Item("FormulaDesc").ToString, gbUnicode, True) & COMMA) 'varchar[2000], NULL
            sSQL.Append("Decimals = " & SQLNumber(dtGrid.Rows(i).Item("Decimals").ToString) & COMMA) 'int, NOT NULL
            sSQL.Append("Disabled = " & SQLNumber(IIf(L3Bool(dtGrid.Rows(i).Item("Disabled")), 0, 1).ToString) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("IsNotPrint = " & SQLNumber(dtGrid.Rows(i).Item("IsNotPrint"))) 'tinyint, NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("PieceworkCalMethodID = " & SQLString(_PieceworkCalMethodID) & " And ")
            sSQL.Append("PWCalNo = " & SQLString(dtGrid.Rows(i).Item("PWCalNo").ToString))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub tdbg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg1.KeyDown
        If e.KeyCode = Keys.Enter And tdbg1.Col = COL1_Description Then
            HotKeyEnterGrid(tdbg1, COL1_FunctionID, e)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg1, COL1_FunctionID, 0)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1061
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 18/12/2009 10:37:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1061(ByVal sPieceworkCalMethodID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P1061 "
        sSQL &= SQLString(sPieceworkCalMethodID) & COMMA 'PieceworkCalMethodID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function


    
End Class