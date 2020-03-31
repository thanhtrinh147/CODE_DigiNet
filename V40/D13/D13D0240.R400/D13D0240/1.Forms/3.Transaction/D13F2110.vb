Imports System
Public Class D13F2110
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_Choose As Integer = 0           ' Chọn
    Private Const COL_SalaryVoucherNo As Integer = 1  ' Số phiếu
    Private Const COL_VoucherDate As Integer = 2      ' Ngày phiếu
    Private Const COL_Description As Integer = 3      ' Ghi chú
    Private Const COL_PayrollVoucherNo As Integer = 4 ' Hồ sơ lương 
    Private Const COL_SalCalMethodName As Integer = 5 ' PP tính lương
    Private Const COL_SalaryVoucherID As Integer = 6  ' SalaryVoucherID
#End Region

    Private dt As DataTable

    Private _tTResultVoucherID As String = ""
    Public Property TTResultVoucherID() As String
        Get
            Return _tTResultVoucherID
        End Get
        Set(ByVal Value As String)
            _tTResultVoucherID = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            LoadTDBCombo()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnCalculate.Enabled = False
                    c1dateEntryDate.Value = Now.Date
                    btnNext.Enabled = False
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    btnCalculate.Enabled = False
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub D13F2110_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D13F2110_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        ResetColorGrid(tdbg)
        gbEnabledUseFind = False
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtAbsentVoucherNo)
        LoadTDBGrid()
        SetBackColorObligatory()
        Loadlanguage()
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)
InputDateCustomFormat(c1dateEntryDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Phieu_tinh_ket_qua_chuyen_but_toan_-_D13F2110") & UnicodeCaption(gbUnicode) 'PhiÕu tÛnh kÕt qu¶ chuyÓn bòt toÀn - D13F2110
        '================================================================ 
        lblDescription.Text = rl3("Ghi_chu") 'Ghi chú
        lblteEntryDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblEmployeeID.Text = rl3("Nguoi_lap") 'Người lập
        lblAbsentVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblPolicyID.Text = rl3("Co_che_chuyen_but_toan") 'Cơ chế chuyển bút toán
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnCalculate.Text = rl3("Tin_h") 'Tín&h
        chkIsCalculate.Text = rl3("Da_tinh")
        '================================================================ 
        GroupBox1.Text = rl3("Thong_tin_phieu") 'Thông tin phiếu
        GroupBox2.Text = rl3("Phieu_luong") 'Phiếu lương
        GroupBox3.Text = rl3("Co_che_chuyen_but_toan") 'Cơ chế chuyển bút toán
        '================================================================ 
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Ten") 'Tên
        tdbcPolicyID.Columns("PolicyID").Caption = rl3("Ma") 'Mã
        tdbcPolicyID.Columns("PolicyName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("Choose").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("SalaryVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("Description").Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns("PayrollVoucherNo").Caption = rl3("Ho_so_luong") 'Hồ sơ lương 
        tdbg.Columns("SalCalMethodName").Caption = rl3("PP_tinh_luong") 'PP tính lương
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadEdit()
        Dim sSQL As String = "Select TOP 1 T20.TTRvoucherTypeID, T20.EmployeeID, T20.TTRVoucherNo, T20.TTRVoucherDate, T20.TTRVoucherDesc" & UnicodeJoin(gbUnicode) & " as TTRVoucherDesc, T20.IsCalculated, "
        sSQL &= " T21.PolicyID from D13T2120 T20  WITH (NOLOCK) INNER JOIN D13T2121 T21 On T20.TTResultVoucherID=T21.TTResultVoucherID where T20.TTResultVoucherID = " & SQLString(_tTResultVoucherID)
        Dim dtEdit As DataTable = ReturnDataTable(sSQL)
        If dtEdit.Rows.Count > 0 Then
            tdbcVoucherTypeID.SelectedValue = dtEdit.Rows(0).Item("TTRvoucherTypeID").ToString
            tdbcEmployeeID.SelectedValue = dtEdit.Rows(0).Item("EmployeeID").ToString
            txtAbsentVoucherNo.Text = dtEdit.Rows(0).Item("TTRVoucherNo").ToString
            c1dateEntryDate.Value = dtEdit.Rows(0).Item("TTRVoucherDate").ToString
            txtDescription.Text = dtEdit.Rows(0).Item("TTRVoucherDesc").ToString
            chkIsCalculate.Checked = L3Bool(dtEdit.Rows(0).Item("IsCalculated").ToString)
            tdbcPolicyID.SelectedValue = dtEdit.Rows(0).Item("PolicyID").ToString
        End If
        ReadOnlyControl(tdbcVoucherTypeID)
        ReadOnlyControl(txtAbsentVoucherNo)
        btnNext.Visible = False
        btnSave.Left = btnNext.Left
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcEmployeeID
        LoadCboCreateBy(tdbcEmployeeID, gbUnicode)
        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, "D13", , gbUnicode)
        'Load tdbcPolicyID
        sSQL = "Select PolicyID, PolicyName" & UnicodeJoin(gbUnicode) & " as PolicyName From D13T1165  WITH (NOLOCK) where Disabled = 0 Order by PolicyID "
        LoadDataSource(tdbcPolicyID, sSQL, gbUnicode)
        tdbcPolicyID.SelectedIndex = 0
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String
        sSQL = SQLStoreD13P2101()
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt, gbUnicode)
        FooterTotalGrid(tdbg, COL_PayrollVoucherNo)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2101
    '# Created User: Thanh Huyền
    '# Created Date: 18/11/2010 10:16:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2101() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2101 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_tTResultVoucherID) & COMMA 'TTResultVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub btnCalculate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Dim bExecute As Boolean = ExecuteSQLNoTransaction(SQLStoreD13P2102())
        If bExecute Then
            D99C0008.MsgL3(rl3("Tinh_ket_qua_chuyen_but_toan_thanh_cong"))
            Dim frm As New D13F2120
            With frm
                .TTResultVoucherID = _tTResultVoucherID
                .ShowDialog()
                .Dispose()
            End With
        Else
            D99C0008.MsgL3(rl3("Tinh_khong_thanh_cong"))
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2102
    '# Created User: Thanh Huyền
    '# Created Date: 17/11/2010 04:20:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2102() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2102 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_tTResultVoucherID) & COMMA 'TTResultVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Dim bSelect As Boolean = False 'Mặc định Uncheck 24/11/2008
    Private Sub L3HeadClick(ByVal iCol As Integer)
        Dim bSelected As Boolean = Not bSelect
        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, iCol) = bSelected
        Next
        bSelect = bSelected
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_Choose
                tdbg.AllowSort = False
                L3HeadClick(e.ColIndex)
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.Col = COL_Choose Then
            If e.Control And e.KeyCode = Keys.S Then
                L3HeadClick(tdbg.Col)
            End If
        End If
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtAbsentVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPolicyID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If
        If txtAbsentVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("So_phieu"))
            txtAbsentVoucherNo.Focus()
            Return False
        End If
        If tdbcEmployeeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nguoi_lap"))
            tdbcEmployeeID.Focus()
            Return False
        End If
        Dim bChoose As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_Choose)) Then
                bChoose = True
                Exit For
            End If
        Next
        If Not bChoose Then
            D99C0008.MsgL3(rl3("Ban_phai_chon_du_lieu_tren_luoi1"))
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_Choose
            tdbg.Focus()
            Return False
        End If
        If tdbcPolicyID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Co_che_chuyen_but_toan"))
            tdbcPolicyID.Focus()
            Return False
        End If
        Return True
    End Function

#Region "Events tdbcVoucherTypeID"

    Private Sub tdbcVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtAbsentVoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcVoucherTypeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcVoucherTypeID.Text = ""
            txtAbsentVoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        If tdbcVoucherTypeID.SelectedValue Is Nothing OrElse tdbcVoucherTypeID.Text = "" Then
            txtAbsentVoucherNo.Text = ""
            ReadOnlyControl(txtAbsentVoucherNo)
            Exit Sub
        End If

        If _FormState = EnumFormState.FormAdd Then
            If tdbcVoucherTypeID.Columns("Auto").Text = "1" Then 'Sinh tu dong
                txtAbsentVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
                ReadOnlyControl(txtAbsentVoucherNo)
            Else
                txtAbsentVoucherNo.Text = ""
                UnReadOnlyControl(txtAbsentVoucherNo)
            End If
        End If
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2120
    '# Created User: Thanh Huyền
    '# Created Date: 18/11/2010 10:44:22
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2120() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D13T2120(")
        sSQL.Append("TTResultVoucherID, DivisionID, TranMonth, TranYear, TTRvoucherTypeID, TTRVoucherNo, ")
        sSQL.Append("TTRVoucherDate, TTRVoucherDesc, TTRVoucherDescU, EmployeeID, IsCalculated, CreateDate, CreateUserID, LastModifyDate, LastModifyUserID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(_tTResultVoucherID) & COMMA) 'TTResultVoucherID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[50], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, int, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, int, NOT NULL
        sSQL.Append(SQLString(tdbcVoucherTypeID.SelectedValue) & COMMA) 'TTRVoucherNo, varchar[50], NOT NULL
        sSQL.Append(SQLString(txtAbsentVoucherNo.Text) & COMMA) 'TTRVoucherNo, varchar[50], NOT NULL
        sSQL.Append(SQLDateSave(c1dateEntryDate.Text) & COMMA) 'TTRVoucherDate, datetime, NOT NULL
        sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA) 'TTRVoucherDesc, varchar[500], NOT NULL
        sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA) 'TTRVoucherDescU, nvarchar, NOT NULL
        sSQL.Append(SQLString(tdbcEmployeeID.SelectedValue) & COMMA) 'EmployeeID, varchar[50], NOT NULL
        sSQL.Append(SQLNumber(chkIsCalculate.Checked) & COMMA) 'IsCalculated, tinyint, NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID)) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2121s
    '# Created User: Thanh Huyền
    '# Created Date: 18/11/2010 11:22:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2121s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_Choose)) Then
                sSQL.Append("Insert Into D13T2121(")
                sSQL.Append("TTResultVoucherID, SalaryVoucherID, PolicyID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(_tTResultVoucherID) & COMMA) 'TTResultVoucherID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_SalaryVoucherID)) & COMMA) 'SalaryVoucherID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbcPolicyID.SelectedValue)) 'PolicyID, varchar[50], NOT NULL
                sSQL.Append(")")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2120
    '# Created User: Thanh Huyền
    '# Created Date: 18/11/2010 11:28:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2120() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T2120 Set ")
        sSQL.Append("TTRVoucherDate = " & SQLDateSave(c1dateEntryDate.Text) & COMMA) 'datetime, NOT NULL
        sSQL.Append("TTRVoucherDesc = " & SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("TTRVoucherDescU = " & SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("EmployeeID = " & SQLString(tdbcEmployeeID.SelectedValue) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID)) 'varchar[20], NOT NULL
        sSQL.Append(" Where TTResultVoucherID = " & SQLString(_tTResultVoucherID) & vbCrLf)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T2121
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 10/12/2010 03:39:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T2121() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T2121"
        sSQL &= " Where TTResultVoucherID = " & SQLString(_tTResultVoucherID)
        Return sSQL
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)
        If Not CheckVoucherDateInPeriod(c1dateEntryDate.Text) Then
            Exit Sub
        End If

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                If _tTResultVoucherID = "" Then _tTResultVoucherID = CreateIGE("D13T2120", "TTResultVoucherID", "13", "TR", gsStringKey)
                If tdbcVoucherTypeID.Columns("Auto").Text = "1" Then 'Tự động
                    ' UPDATE 10/6/2013 ID 56910
                    txtAbsentVoucherNo.Text = CreateIGEVoucherNoNew(tdbcVoucherTypeID, "D13T2120", _tTResultVoucherID)
                    'txtAbsentVoucherNo.Text = CreateIGEVoucherNoNew(tdbcVoucherTypeID, "D07T2100", _tTResultVoucherID)
                Else 'Không sinh tự động
                    If CheckDuplicateVoucherNoNew("D13", "D13T2120", _tTResultVoucherID, txtAbsentVoucherNo.Text) Then
                        Me.Cursor = Cursors.Default
                        btnSave.Enabled = True
                        btnClose.Enabled = True
                        txtAbsentVoucherNo.Focus()
                        Exit Sub
                    End If
                    ' UPDATE 10/6/2013 ID 56910
                    InsertVoucherNoD91T9111(txtAbsentVoucherNo.Text, "D13T2120", _tTResultVoucherID)
                    'InsertVoucherNoD91T9111(txtAbsentVoucherNo.Text, "D07T2100", _tTResultVoucherID)
                End If
                sSQL.Append(SQLInsertD13T2120().ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T2121s().ToString)
                'Lưu LastKey của Số phiếu xuống Database (gọi hàm CreateIGEVoucherNo bật cờ True)
                'Kiểm tra trùng Số phiếu (gọi hàm CheckDuplicateVoucherNo)
                'Nếu tra trùng Số phiếu thì bật
                'btnSave.Enabled = True
                'btnClose.Enabled = True
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T2120().ToString & vbCrLf)
                sSQL.Append(SQLDeleteD13T2121().ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T2121s().ToString)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            SaveOK()
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnCalculate.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        _tTResultVoucherID = ""
        btnCalculate.Enabled = False
        btnNext.Enabled = False
        btnSave.Enabled = True
        If Not D13Options.SaveLastRecent Then
            tdbcVoucherTypeID.Text = ""
            txtAbsentVoucherNo.Text = ""
            txtDescription.Text = ""
            tdbcEmployeeID.Text = ""
            tdbcPolicyID.Text = ""
            LoadTDBGrid()
            tdbcVoucherTypeID.Focus()
        Else
            tdbcVoucherTypeID.Text = ""
            txtAbsentVoucherNo.Text = ""
            tdbcVoucherTypeID.Focus()
        End If
    End Sub

#Region "Events tdbcEmployeeID"

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then tdbcEmployeeID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPolicyID"

    Private Sub tdbcPolicyID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPolicyID.LostFocus
        If tdbcPolicyID.FindStringExact(tdbcPolicyID.Text) = -1 Then tdbcPolicyID.Text = ""
    End Sub

#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcPolicyID.BeforeOpen, tdbcEmployeeID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPolicyID.Close, tdbcEmployeeID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPolicyID.KeyUp, tdbcEmployeeID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPolicyID.Validated, tdbcEmployeeID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRight, GroupBox1)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, GroupBox2, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeftRight, GroupBox3)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnCalculate)
        AnchorForControl(EnumAnchorStyles.BottomRight, pnl1)
    End Sub
End Class