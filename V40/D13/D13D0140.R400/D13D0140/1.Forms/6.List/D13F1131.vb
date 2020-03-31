Imports System
Public Class D13F1131
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
    End Property

#Region "Const of tdbg"
    Private Const COL_AbsentTypeID As Integer = 0   ' Mã loại công
    Private Const COL_AbsentTypeName As Integer = 1 ' Tên loại công
    Private Const COL_OrderNo As Integer = 2        ' Thứ tự hiển thị
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            _bSaved = False
            CreateDataTable()
            LoadTDBCombo()
            LoadTDBDropDown()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    CheckIdTextBox(txtTransTypeID)
                    btnNext.Enabled = False
                    LoadAddNew()
                Case EnumFormState.FormEdit
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _transTypeID As String = ""
    Public Property TransTypeID() As String
        Get
            Return _transTypeID
        End Get
        Set(ByVal Value As String)
            _transTypeID = Value
        End Set
    End Property

    Dim sCreateDate As String = ""
    Dim sCreateUserID As String = ""
    Dim dt As DataTable
    Dim dtDetail As DataTable

    Private Sub D13F1131_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            If tdbg.Enabled = True Then
                HotKeyF11(Me, tdbg)
            End If
        End If
    End Sub

    Private Sub D13F1131_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        SetBackColorObligatory()
        tdbg_LockedColumns()
        InputbyUnicode(Me, gbUnicode)
        UnicodeGridDataField(tdbg, COL_AbsentTypeName, gbUnicode)
        CheckIdTextBox(txtTransTypeID)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_loai_nghiep_vu_-_D13F1131") & UnicodeCaption(gbUnicode) 'CËp nhËt loÁi nghiÖp vó - D13F1131
        '================================================================ 
        lblTransTypeID.Text = rl3("Ma") 'Mã
        lblTransTypeName.Text = rl3("Ten") 'Tên
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        lblTransactionID.Text = rl3("Nghiep_vu") 'Nghiệp vụ
        lblDAGroupID.Text = rl3("Nhom_truy_cap") 'Nhóm truy cập
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        '================================================================ 
        TabPage1.Text = rl3("Khoan_dieu_chinh_thu_nhap")
        '================================================================ 
        tdbcTransactionID.Columns("TransactionID").Caption = rl3("Ma") 'Mã
        tdbcTransactionID.Columns("TransactionName").Caption = rl3("Ten") 'Tên
        tdbcDAGroupID.Columns("DAGroupID").Caption = rl3("Ma") 'Mã
        tdbcDAGroupID.Columns("DAGroupName").Caption = rl3("Ten") 'Tên
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdAbsentTypeDateID.Columns("AbsentTypeDateID").Caption = rl3("Ma") 'Mã
        tdbdAbsentTypeDateID.Columns("AbsentTypeDateName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("AbsentTypeID").Caption = rl3("Ma") 'Mã loại công
        tdbg.Columns("AbsentTypeName").Caption = rl3("Ten") 'Tên loại công
        tdbg.Columns("OrderNo").Caption = rl3("Thu_tu_hien_thi") 'Thứ tự hiển thị
    End Sub

    Private Sub SetBackColorObligatory()
        txtTransTypeID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtTransTypeName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTransactionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_AbsentTypeName).Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_AbsentTypeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcTransactionID
        sSQL = "SELECT      '0001' As TransactionID, "
        sSQL &= IIf(gsLanguage = "84", IIf(gbUnicode, "N'Hồ sơ lương tháng'", "'Hoà sô löông thaùng'"), "'Monthly Payroll Files'").ToString & " As TransactionName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT     '0002' As TransactionID, "
        sSQL &= IIf(gsLanguage = "84", IIf(gbUnicode, "N'Điều chỉnh thu nhập'", "'Ñieàu chænh thu nhaäp'"), "'Income Amount'").ToString & " As TransactionName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT     '0003' As TransactionID, "
        sSQL &= IIf(gsLanguage = "84", IIf(gbUnicode, "N'Phiếu lương'", "'Phieáu löông'"), "'Payroll Vouchers'").ToString & " As TransactionName" & vbCrLf
        sSQL &= "ORDER BY   TransactionID"
        LoadDataSource(tdbcTransactionID, sSQL, gbUnicode)

        ''Load tdbcDAGroupID
        'sSQL = "SELECT 		DAGroupID as DAGroupID, DAGroupName as DAGroupName" & vbCrLf
        'sSQL &= "FROM 		LemonSys.dbo.D00T0080 " & vbCrLf
        'sSQL &= "WHERE 		Disabled = 0 " & vbCrLf
        'sSQL &= "And " & vbCrLf
        'sSQL &= "(" & vbCrLf
        'sSQL &= "DAGroupID In (	Select 	DAGroupID " & vbCrLf
        'sSQL &= "From 	LemonSys.dbo.D00V0080 " & vbCrLf
        'sSQL &= "Where 	UserID = " & SQLString(gsUserID) & ") " & vbCrLf
        'sSQL &= "Or 'LEMONADMIN' = " & SQLString(gsUserID) & vbCrLf
        'sSQL &= ") " & vbCrLf
        'sSQL &= "ORDER BY 	DAGroupID"
        'LoadDataSource(tdbcDAGroupID, sSQL, gbUnicode)
        LoadTDBC_DAGroupID(tdbcDAGroupID, gbUnicode)

        'Load tdbcVoucherTypeID
        sSQL = "Select     VoucherTypeID, "
        sSQL &= IIf(gbUnicode, "VoucherTypeNameU As VoucherTypeName", "VoucherTypeName").ToString
        sSQL &= " ,Auto, S1, S2, S3, OutputOrder, OutputLength, Separator, S1Type, S2Type"
        sSQL &= " From  D91T0001 WITH (NOLOCK) "
        sSQL &= " Where Disabled = 0 And UseD13 = 1"
        'Update 15/02/2012: Incident 46667
        sSQL &= " AND ( VoucherDivisionID='' OR VoucherDivisionID =" & SQLString(gsDivisionID) & " ) "
        sSQL &= " Order By VoucherTypeID"
        LoadDataSource(tdbcVoucherTypeID, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcTransactionID"

    Private Sub tdbcTransactionID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransactionID.Close
        If tdbcTransactionID.FindStringExact(tdbcTransactionID.Text) = -1 Then tdbcTransactionID.Text = ""
    End Sub

    Private Sub tdbcTransactionID_SelectedValueChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransactionID.SelectedValueChanged
        If tdbcTransactionID.SelectedValue Is Nothing Then
            EnabledDetail("")
            Exit Sub
        End If
        EnabledDetail(tdbcTransactionID.SelectedValue.ToString)
        If tdbcTransactionID.SelectedValue.ToString <> "0002" Then
            Dim dtTmp As New DataTable
            dtTmp = dt.Copy
            dtTmp.Clear()
            LoadDataSource(tdbg, dtTmp, gbUnicode)
        End If
    End Sub

    Private Sub tdbcTransactionID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcTransactionID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcTransactionID.Text = ""
        If gbUnicode Then Exit Sub
        Select Case e.KeyCode
            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                tdbcTransactionID.AutoCompletion = False
            Case Else
                tdbcTransactionID.AutoCompletion = True
        End Select
    End Sub

#End Region

#Region "Events tdbcDAGroupID"

    Private Sub tdbcDAGroupID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDAGroupID.LostFocus
        If tdbcDAGroupID.FindStringExact(tdbcDAGroupID.Text) = -1 Then tdbcDAGroupID.Text = ""
    End Sub

    Private Sub tdbcDAGroupID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDAGroupID.KeyDown
        If gbUnicode Then Exit Sub
        Select Case e.KeyCode
            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                tdbcDAGroupID.AutoCompletion = False
            Case Else
                tdbcDAGroupID.AutoCompletion = True
        End Select
    End Sub

#End Region

#Region "Events tdbcVoucherTypeID with txtVoucherTypeName"

    Private Sub tdbcVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherTypeName.Text = ""
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        txtVoucherTypeName.Text = tdbcVoucherTypeID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcVoucherTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcVoucherTypeID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcVoucherTypeID.Text = ""
        '    txtVoucherTypeName.Text = ""
        'End If
    End Sub

#End Region

    Private Sub EnabledDetail(ByVal ID As String)
        tabMain.Enabled = ID = "0002"
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdAbsentTypeDateID
        sSQL = "SELECT  AbsentTypeDateID,"
        sSQL &= IIf(gbUnicode, "AbsentTypeDateNameU as AbsentTypeDateName", "AbsentTypeDateName").ToString
        sSQL &= " FROM        D13T0118 WITH (NOLOCK) "
        sSQL &= " WHERE       Disabled = 0"
        sSQL &= " ORDER BY    AbsentTypeDateID"

        LoadDataSource(tdbdAbsentTypeDateID, sSQL, gbUnicode)
    End Sub

    Private Sub CreateDataTable()
        Dim sSQL As String = ""
        sSQL = "SELECT      T30.TransTypeID, T30.TransTypeName,T30.TransTypeNameU, T30.Note, T30.NoteU, T30.Disabled, T30.CreateUserID, "
        sSQL &= "T30.LastModifyUserID, T30.CreateDate, T30.LastModifyDate, "
        sSQL &= "T30.AbsentTypeID, T18.AbsentTypeDateName AS AbsentTypeName, T18.AbsentTypeDateNameU AS AbsentTypeNameU, T30.OrderNo, " & vbCrLf
        sSQL &= "TransactionID, DAGroupID, VoucherTypeID" & vbCrLf
        sSQL &= "FROM       D13T1130 T30 WITH (NOLOCK) " & vbCrLf
        sSQL &= "LEFT JOIN D13T0118 T18 WITH (NOLOCK) " & vbCrLf
        sSQL &= "ON         T30.AbsentTypeID = T18.AbsentTypeDateID" & vbCrLf
        sSQL &= "WHERE      TransTypeID = " & SQLString(_transTypeID)
        dt = ReturnDataTable(sSQL)

        sSQL = "SELECT 	 	T1.TransTypeID, AbsentTypeDateName As AbsentTypeName, AbsentTypeDateNameU As AbsentTypeNameU, T1.AbsentTypeID, T1.OrderNo" & vbCrLf
        sSQL &= "FROM 		D13T1131 T1 WITH (NOLOCK) " & vbCrLf
        sSQL &= "INNER JOIN	D13T0118 T2  WITH (NOLOCK) ON T1.AbsentTypeID = T2.AbsentTypeDateID" & vbCrLf
        sSQL &= "WHERE      T1.TransTypeID = " & SQLString(_transTypeID) & vbCrLf
        sSQL &= "ORDER BY 	T1.OrderNo"
        dtDetail = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadAddNew()
        txtTransTypeID.Text = ""
        txtTransTypeName.Text = ""
        tdbcTransactionID.AutoSelect = True
        tdbcDAGroupID.Text = ""
        tdbcVoucherTypeID.Text = ""
        txtNote.Text = ""
        chkDisabled.Checked = False
        LoadDataSource(tdbg, ReturnTableFilter(dtDetail, "TransTypeID = ''"), gbUnicode)
        txtTransTypeID.Focus()
    End Sub

    Private Sub LoadEdit()
        If dt.Rows.Count > 0 Then
            txtTransTypeID.Text = dt.Rows(0).Item("TransTypeID").ToString
            txtTransTypeName.Text = dt.Rows(0).Item("TransTypeName" & UnicodeJoin(gbUnicode)).ToString
            tdbcTransactionID.SelectedValue = dt.Rows(0).Item("TransactionID").ToString
            tdbcDAGroupID.SelectedValue = dt.Rows(0).Item("DAGroupID").ToString
            tdbcVoucherTypeID.Text = dt.Rows(0).Item("VoucherTypeID").ToString
            txtNote.Text = dt.Rows(0).Item("Note" & UnicodeJoin(gbUnicode)).ToString
            chkDisabled.Checked = CBool(IIf(CInt(dt.Rows(0).Item("Disabled")) = 1, True, False))
            sCreateUserID = dt.Rows(0).Item("CreateUserID").ToString
            sCreateDate = SQLDateTimeSave(dt.Rows(0).Item("CreateDate").ToString)
        End If

        'If dt.Rows(0).Item("TransactionID").ToString = "0002" Then
        '    LoadDataSource(tdbg, dt)
        'Else
        '    Dim dtTmp As DataTable
        '    dtTmp = dt.Copy
        '    dtTmp.Clear()
        '    LoadDataSource(tdbg, dtTmp)
        'End If
        If dtDetail.Rows.Count > 0 Then
            LoadDataSource(tdbg, dtDetail, gbUnicode)
        End If

        txtTransTypeID.Enabled = False
        tdbcTransactionID.Enabled = False
    End Sub

    Private Function AllowSave() As Boolean
        If txtTransTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtTransTypeID.Focus()
            Return False
        Else
            If _FormState = EnumFormState.FormAdd Then
                Dim sSQL As String = ""
                sSQL = "SELECT TOP 1 1" & vbCrLf
                sSQL &= "FROM     D13T1130 WITH (NOLOCK) " & vbCrLf
                sSQL &= "WHERE TransTypeID = " & SQLString(txtTransTypeID.Text)
                If ExistRecord(sSQL) Then
                    D99C0008.MsgDuplicatePKey()
                    txtTransTypeID.Focus()
                    Return False
                End If
            End If
        End If
        If txtTransTypeName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten"))
            txtTransTypeName.Focus()
            Return False
        End If


        If _FormState = EnumFormState.FormAdd Then
            If tdbcTransactionID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Nghiep_vu"))
                tdbcTransactionID.Focus()
                Return False
            End If
        End If

        If Me.tabMain.Enabled Then
            If tdbg.RowCount <= 0 Then
                D99C0008.MsgNoDataInGrid()
                tdbg.Focus()
                Return False
            End If
        End If
        If Me.tabMain.Enabled Then
            For i As Integer = 0 To tdbg.RowCount - 1
                If tdbg(i, COL_AbsentTypeID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ma_loai_cong"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_AbsentTypeID
                    tdbg.Bookmark = i
                    Return False
                End If
                If tdbg(i, COL_OrderNo).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Thu_tu_hien_thi"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_OrderNo
                    tdbg.Bookmark = i
                    Return False
                End If
            Next

            For i As Integer = 0 To tdbg.RowCount - 1
                For j As Integer = i + 1 To tdbg.RowCount - 1
                    If tdbg(i, COL_AbsentTypeID).ToString = tdbg(j, COL_AbsentTypeID).ToString Then
                        D99C0008.MsgDuplicatePKey()
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_AbsentTypeID
                        tdbg.Bookmark = j
                        Return False
                    End If
                    If tdbg(i, COL_OrderNo).ToString = tdbg(j, COL_OrderNo).ToString Then
                        D99C0008.MsgDuplicatePKey()
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_OrderNo
                        tdbg.Bookmark = j
                        Return False
                    End If
                Next
            Next
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                If Me.tabMain.Enabled Then
                    sSQL.Append(SQLInsertD13T1130.ToString & vbCrLf)
                    sSQL.Append(SQLInsertD13T1131s)
                    'sSQL.Append(SQLInsertD13T1130s)
                Else
                    sSQL.Append(SQLInsertD13T1130)
                End If
            Case EnumFormState.FormEdit
                sSQL.Append(SQLDeleteD13T1131().ToString & vbCrLf)
                sSQL.Append(SQLDeleteD13T1130().ToString & vbCrLf)

                If Me.tabMain.Enabled Then
                    sSQL.Append(SQLInsertD13T1130.ToString & vbCrLf)
                    sSQL.Append(SQLInsertD13T1131s)
                Else
                    sSQL.Append(SQLInsertD13T1130)
                End If
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    _transTypeID = txtTransTypeID.Text
                    btnNext.Enabled = True
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
        LoadAddNew()
        btnNext.Enabled = False
        btnSave.Enabled = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_AbsentTypeID
                If tdbg.Columns(COL_AbsentTypeID).Text <> tdbdAbsentTypeDateID.Columns("AbsentTypeDateID").Text Then
                    tdbg.Columns(COL_AbsentTypeID).Text = ""
                    tdbg.Columns(COL_AbsentTypeName).Text = ""
                End If
            Case COL_OrderNo
                If Not L3IsNumeric(tdbg.Columns(COL_OrderNo).Text, EnumDataType.Int) Then
                    tdbg.Columns(COL_OrderNo).Text = (Max() + 1).ToString
                End If
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_AbsentTypeID
                tdbg.Columns(COL_AbsentTypeID).Text = tdbdAbsentTypeDateID.Columns("AbsentTypeDateID").Value.ToString
                tdbg.Columns(COL_AbsentTypeName).Text = tdbdAbsentTypeDateID.Columns("AbsentTypeDateName").Value.ToString
                If tdbg.Columns(COL_OrderNo).Text.Trim = "" Then
                    tdbg.Columns(COL_OrderNo).Text = (Max() + 1).ToString
                End If
        End Select
    End Sub

    Private Function Max() As Integer
        Dim iMax As Integer = 0
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_OrderNo).ToString <> "" Then
                If iMax < CInt(tdbg(i, COL_OrderNo)) Then
                    iMax = CInt(tdbg(i, COL_OrderNo))
                End If
            End If
        Next
        Return iMax
    End Function

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_OrderNo
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
            If tdbg.Col = COL_AbsentTypeID Then
                tdbg.Columns(COL_AbsentTypeName).Text = tdbg(tdbg.Row - 1, COL_AbsentTypeName).ToString()
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
        ElseIf e.KeyCode = Keys.Enter Then
            If tdbg.Col = COL_OrderNo Then HotKeyEnterGrid(tdbg, COL_AbsentTypeID, e, 0)
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1130
    '# Created User: DUCTRONG
    '# Created Date: 29/05/2009 02:19:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1130() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T1130"
        sSQL &= " Where TransTypeID = " & SQLString(_transTypeID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1131
    '# Created User: DUCTRONG
    '# Created Date: 09/06/2009 03:30:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1131() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T1131"
        sSQL &= " Where TransTypeID = " & SQLString(_transTypeID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1130s
    '# Created User: DUCTRONG
    '# Created Date: 29/05/2009 02:19:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1130s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        If _FormState = EnumFormState.FormAdd Then
            sCreateUserID = gsUserID
            sCreateDate = "GetDate()"
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D13T1130(")
            sSQL.Append("TransTypeID, TransTypeName, Note, TransTypeNameU, NoteU, Disabled, CreateUserID, ")
            sSQL.Append("LastModifyUserID, CreateDate, LastModifyDate, AbsentTypeID, OrderNo,")
            sSQL.Append("TransactionID, DAGroupID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtTransTypeID.Text) & COMMA) 'TransTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(txtTransTypeName, False) & COMMA) 'TransTypeName, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(txtNote, False) & COMMA) 'Note, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(txtTransTypeName, True) & COMMA) 'TransTypeName, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(txtNote, True) & COMMA) 'Note, varchar[250], NOT NULL
            sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
            sSQL.Append(SQLString(sCreateUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append(sCreateDate & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COL_AbsentTypeID)) & COMMA) 'AbsentTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_OrderNo)) & COMMA) 'OrderNo, int, NOT NULL
            sSQL.Append(SQLString(IIf(tdbcTransactionID.Text = "", "", tdbcTransactionID.SelectedValue)) & COMMA) 'TransactionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(IIf(tdbcDAGroupID.Text = "", "", tdbcDAGroupID.SelectedValue))) 'DAGroupID, varchar[50], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1130
    '# Created User: DUCTRONG
    '# Created Date: 08/06/2009 09:37:49
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1130() As StringBuilder
        Dim sSQL As New StringBuilder

        If _FormState = EnumFormState.FormAdd Then
            sCreateUserID = gsUserID
            sCreateDate = "GetDate()"
        End If

        sSQL.Append("Insert Into D13T1130(")
        sSQL.Append("TransTypeID, TransTypeName, TransTypeNameU, Note, NoteU,Disabled, CreateUserID, ")
        sSQL.Append("LastModifyUserID, CreateDate, LastModifyDate, ")
        sSQL.Append("TransactionID, DAGroupID, VoucherTypeID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtTransTypeID.Text) & COMMA) 'TransTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransTypeName, False) & COMMA) 'TransTypeName, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransTypeName, True) & COMMA) 'TransTypeName, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote, False) & COMMA) 'Note, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote, True) & COMMA) 'Note, varchar[250], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(sCreateUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append(sCreateDate & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(IIf(tdbcTransactionID.Text = "", "", tdbcTransactionID.SelectedValue)) & COMMA) 'TransactionID, varchar[20], NOT NULL
        sSQL.Append(SQLString(IIf(tdbcDAGroupID.Text = "", "", tdbcDAGroupID.SelectedValue)) & COMMA) 'DAGroupID, varchar[50], NOT NULL
        sSQL.Append(SQLString(tdbcVoucherTypeID.Text)) 'VoucherTypeID, varchar[20], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1131s
    '# Created User: DUCTRONG
    '# Created Date: 09/06/2009 03:27:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1131s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D13T1131(")
            sSQL.Append("TransTypeID, AbsentTypeID, OrderNo")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtTransTypeID.Text) & COMMA) 'TransTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_AbsentTypeID)) & COMMA) 'AbsentTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_OrderNo))) 'OrderNo, int, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub tdbcTransactionID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransactionID.Leave
        If gbUnicode Then Exit Sub
        If tdbcTransactionID.SelectedIndex <> -1 Then
            tdbcTransactionID.Text = tdbcTransactionID.Columns("TransactionName").Text
        End If
    End Sub

    Private Sub tdbcDAGroupID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDAGroupID.Leave
        If gbUnicode Then Exit Sub
        If tdbcDAGroupID.SelectedIndex <> -1 Then
            tdbcDAGroupID.Text = tdbcDAGroupID.Columns("DAGroupName").Text
        End If
    End Sub

End Class