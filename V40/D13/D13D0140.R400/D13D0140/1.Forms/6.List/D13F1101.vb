Imports System
Public Class D13F1101
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Private _formIDPermission As String = "D13F1101"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
    End Property

    Private _moduleID As String = "13"
    Public WriteOnly Property ModuleID() As String 
        Set(ByVal Value As String )
            _moduleID = Value
        End Set
    End Property


#Region "Const of tdbg"
    Private Const COL_ValueFrom As Integer = 0     ' >=Giá trị
    Private Const COL_ValueTo As Integer = 1       ' <Giá trị
    Private Const COL_ValueDateFrom As Integer = 2 ' >= Ngày
    Private Const COL_ValueDateTo As Integer = 3   ' < Ngày
    Private Const COL_Method As Integer = 4        ' Method
    Private Const COL_MethodName As Integer = 5    ' Phương pháp
    Private Const COL_Result As Integer = 6        ' Kết quả
    Private Const COL_ReferenceID As Integer = 7   ' ReferenceID
#End Region

    Dim bUnicode As Boolean = L3Bool(gbUnicode)
    Dim bShiftInsert As Boolean = False
    Private _resultReferenceID As String

    Public Property ResultReferenceID() As String
        Get
            Return _resultReferenceID
        End Get
        Set(ByVal Value As String)
            _resultReferenceID = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            ' update 17/9/2013 id 59003 - hiện khi D52/Danh mục/ Bảng tham chiếu kết quả/(thêm/xem/sửa)
            If _moduleID = "52" OrElse L3Left(_formIDPermission, 3) = "D52" Then
                Panel1.Enabled = True
            End If
            LoadTDBDropDown()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    CheckIdTextBox(txtResultReferenceID)
                    LoadAddNew()
                    btnNext.Enabled = False
                Case EnumFormState.FormEdit
                    LoadEdit()
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                Case EnumFormState.FormView
                    LoadEdit()
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1100
    '# Created User: Phạm Thị Hồng Phi
    '# Created Date: 02/07/2008 09:47:02
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------

    Private Function SQLInsertD13T1100() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D13T1100(")
        sSQL.Append("ResultReferenceID, ResultReferenceName, ResultReferenceNameU, Notice, NoticeU, Disabled, CreateUserID, ")
        sSQL.Append("CreateDate, LastModifyUserID, LastModifyDate, Mode")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(_resultReferenceID) & COMMA)
        sSQL.Append(SQLStringUnicode(txtResultReferenceName, False) & COMMA)
        sSQL.Append(SQLStringUnicode(txtResultReferenceName, True) & COMMA)
        sSQL.Append(SQLStringUnicode(txtNotice, False) & COMMA)
        sSQL.Append(SQLStringUnicode(txtNotice, True) & COMMA)
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA)
        sSQL.Append(SQLString(gsUserID) & COMMA)
        sSQL.Append("GetDate()" & COMMA)
        sSQL.Append(SQLString(gsUserID) & COMMA)
        sSQL.Append("GetDate()" & COMMA)
        sSQL.Append(SQLNumber(optModeDate.Checked)) ' update 17/9/2013 id 59003
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1101
    '# Created User: Phạm Thị Hồng Phi
    '# Created Date: 02/07/2008 09:50:35
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------

    Private Function SQLInsertD13T1101s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sReferenceID As String = ""
        Dim iCountIGE As Integer = 0

        If _FormState = EnumFormState.FormEdit Then
            For i As Integer = 0 To tdbg.RowCount - 1
                If tdbg(i, COL_ReferenceID).ToString = "" Then
                    iCountIGE = iCountIGE + 1
                End If
            Next
        Else
            iCountIGE = tdbg.RowCount
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_ReferenceID).ToString = "" Then
                sReferenceID = CreateIGEs("D13T1101", "ReferenceID", "13", "RR", gsStringKey, sReferenceID, iCountIGE)
                tdbg(i, COL_ReferenceID) = sReferenceID
            End If
            sSQL.Append("Insert Into D13T1101(")
            sSQL.Append("ReferenceID, ResultReferenceID, Method, Result, ValueFrom, ValueTo, ValueDateFrom, ValueDateTo")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg(i, COL_ReferenceID)) & COMMA)
            sSQL.Append(SQLString(txtResultReferenceID.Text) & COMMA)
            sSQL.Append(SQLString(tdbg(i, COL_Method)) & COMMA)
            sSQL.Append(SQLMoney(tdbg(i, COL_Result), tdbg.Columns(COL_Result).NumberFormat) & COMMA)
            If optModeDate.Checked Then ' update 17/9/2013 id 59003
                sSQL.Append(SQLMoney(0) & COMMA)
                sSQL.Append(SQLMoney(0) & COMMA)
                sSQL.Append(SQLDateSave(tdbg(i, COL_ValueDateFrom)) & COMMA) 'ValueDateFrom, datetime, NULL
                sSQL.Append(SQLDateSave(tdbg(i, COL_ValueDateTo))) 'ValueDateTo, datetime, NULL
            Else
                sSQL.Append(SQLMoney(tdbg(i, COL_ValueFrom), tdbg.Columns(COL_ValueFrom).NumberFormat) & COMMA)
                sSQL.Append(SQLMoney(tdbg(i, COL_ValueTo), tdbg.Columns(COL_ValueTo).NumberFormat) & COMMA)
                sSQL.Append(SQLDateSave("") & COMMA) 'ValueDateFrom, datetime, NULL
                sSQL.Append(SQLDateSave("")) 'ValueDateTo, datetime, NULL
            End If
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next

        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1100
    '# Created User: Phạm Thị Hồng Phi
    '# Created Date: 02/07/2008 09:55:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1100() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T1100 Set ")
        sSQL.Append("ResultReferenceName = " & SQLStringUnicode(txtResultReferenceName, False) & COMMA) 'varchar[100], NOT NULL
        sSQL.Append("ResultReferenceNameU = " & SQLStringUnicode(txtResultReferenceName, True) & COMMA) 'varchar[100], NOT NULL
        sSQL.Append("Notice = " & SQLStringUnicode(txtNotice, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("NoticeU = " & SQLStringUnicode(txtNotice, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'bit, NOT NULL
        sSQL.Append("Mode = " & SQLNumber(optModeDate.Checked) & COMMA) 'bit, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate() ") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("ResultReferenceID = " & SQLString(_resultReferenceID))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1101
    '# Created User: Phạm Thị Hồng Phi
    '# Created Date: 02/07/2008 10:04:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------

    Private Function SQLDeleteD13T1101() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T1101"
        sSQL &= " Where ResultReferenceID=" & SQLString(_resultReferenceID)
        Return sSQL
    End Function

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        sSQL = "Select 0 as Method, " & IIf(Not bUnicode, SQLString(rl3("Gia_tri")), "N" & SQLString(rl3("Gia_tri_"))).ToString & " as MethodName " & vbCrLf
        sSQL &= "Union " & vbCrLf
        sSQL &= "Select 1 as Method, " & IIf(Not bUnicode, SQLString(rl3("Ty_leV")), "N" & SQLString(rl3("Ty_le"))).ToString & " as MethodName "
        LoadDataSource(tdbdMethod, sSQL, bUnicode)
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL = "Select ResultReferenceID,ResultReferenceName, ResultReferenceNameU,Notice, NoticeU,Disabled,Mode " & vbCrLf
        sSQL &= "From D13T1100 WITH(NOLOCK) " & vbCrLf
        sSQL &= "where ResultReferenceID = " & SQLString(_resultReferenceID)
        sSQL &= " Order by ResultReferenceID"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        txtResultReferenceID.Text = dt.Rows(0).Item("ResultReferenceID").ToString
        txtResultReferenceName.Text = dt.Rows(0).Item("ResultReferenceName" & UnicodeJoin(bUnicode)).ToString
        txtNotice.Text = dt.Rows(0).Item("Notice" & UnicodeJoin(bUnicode)).ToString
        chkDisabled.Checked = Convert.ToBoolean(dt.Rows(0).Item("Disabled"))
        ' update 17/9/2013 id 59003
        If Panel1.Enabled Then ' Có sử dụng (D52 gọi qua)
            If L3Int(dt.Rows(0).Item("Mode")) = 0 Then
                optModeValue.Checked = True
            Else
                optModeDate.Checked = True
            End If
        End If
        dt.Dispose()
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL = "Select ReferenceID,ResultReferenceID,ValueFrom,ValueTo," & vbCrLf
        sSQL &= "MethodName= Case When Method=0 Then " & SQLString(rl3("Gia_tri")) & " Else " & SQLString(rl3("Ty_leV")) & " End," & vbCrLf
        sSQL &= "MethodNameU= Case When Method=0 Then N" & SQLString(rl3("Gia_tri_")) & " Else N" & SQLString(rl3("Ty_le")) & " End," & vbCrLf
        sSQL &= "Method,Result,ValueDateFrom, ValueDateTo " & vbCrLf
        sSQL &= "From D13T1101 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where ResultReferenceID= " & SQLString(_resultReferenceID)
        sSQL &= " Order by ReferenceID"
        LoadDataSource(tdbg, sSQL, bUnicode)
    End Sub

    Private Function AllowSave() As Boolean
        If txtResultReferenceID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtResultReferenceID.Focus()
            Return False
        End If
        If txtResultReferenceName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtResultReferenceName.Focus()
            Return False
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If optModeValue.Checked Then
                If tdbg(i, COL_ValueTo).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Gia_tri2"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_ValueTo
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If Number(tdbg(i, COL_ValueFrom).ToString) >= Number(tdbg(i, COL_ValueTo).ToString) Then
                    D99C0008.MsgL3(rl3("Gia_tri1") & " " & rl3("khong_duoc_lon_hon") & " " & rl3("Gia_tri2"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_ValueTo
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            Else
                If tdbg(i, COL_ValueDateFrom).ToString = "" Then
                    If tdbg(i, COL_ValueDateFrom).ToString = "" Then
                        D99C0008.MsgNotYetEnter(" >=" & rl3("Ngay"))
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_ValueDateFrom
                        tdbg.Bookmark = i
                        tdbg.Focus()
                        Return False
                    End If
                End If
                If tdbg(i, COL_ValueDateTo).ToString = "" Then
                    If tdbg(i, COL_ValueDateTo).ToString = "" Then
                        D99C0008.MsgNotYetEnter(" <" & rl3("Ngay"))
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_ValueDateTo
                        tdbg.Bookmark = i
                        tdbg.Focus()
                        Return False
                    End If
                End If
                If CDate(tdbg(i, COL_ValueDateFrom).ToString) >= CDate(tdbg(i, COL_ValueDateTo).ToString) Then
                    D99C0008.MsgL3(">= " & rl3("Ngay") & " " & rl3("khong_duoc_lon_hon") & " < " & rl3("Ngay"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_ValueDateTo
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If
            If tdbg(i, COL_MethodName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Phuong_phap"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_MethodName
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_Result).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ket_qua"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_Result
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
        Next
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D13T1100", "ResultReferenceID", txtResultReferenceID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtResultReferenceID.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub LoadAddNew()
        LoadTDBGrid()
    End Sub

    Private Sub LoadEdit()
        ReadOnlyControl(txtResultReferenceID)
        LoadMaster()
        LoadTDBGrid()
    End Sub

    Private Sub SetBackColorObligatory()
        txtResultReferenceID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtResultReferenceName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ValueFrom).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ValueFrom).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_ValueTo).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_Result).NumberFormat = D13Format.DefaultNumber4
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_bang_tham_chieu_ket_qua_-_D13F1101") & UnicodeCaption(bUnicode) 'CËp nhËt b¶ng tham chiÕu kÕt qu¶ - D13F1101
        '================================================================ 
        lblResultReferenceID.Text = rl3("Ma") 'Mã
        lblResultReferenceName.Text = rl3("Dien_giai") 'Diễn giải
        lblNotice.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        optModeDate.Text = rl3("Ngay")
        optModeValue.Text = rl3("Gia_triU")
        '================================================================ 
        tdbdMethod.Columns("Method").Caption = rl3("Ma") 'Mã
        tdbdMethod.Columns("MethodName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("ValueFrom").Caption = rl3("Gia_tri1") '>=Giá trị
        tdbg.Columns("ValueTo").Caption = rl3("Gia_tri2") '<Giá trị
        tdbg.Columns("ValueDateFrom").Caption = ">= " & rl3("Ngay") '>= Ngày
        tdbg.Columns("ValueDateTo").Caption = "< " & rl3("Ngay") '< Ngày
        tdbg.Columns("MethodName").Caption = rl3("Phuong_phap") 'Phương pháp
        tdbg.Columns("Result").Caption = rl3("Ket_qua") 'Kết quả
    End Sub

    Private Sub D13F1101_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F11
                HotKeyF11(Me, tdbg)
            Case Keys.Enter
                UseEnterAsTab(Me, True)
        End Select
    End Sub

    Private Sub D13F1101_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        InputbyUnicode(Me, bUnicode)
        Loadlanguage()
        UnicodeGridDataField(tdbg, COL_MethodName, bUnicode)
        SetBackColorObligatory()
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        InputDateInTrueDBGrid(tdbg, COL_ValueDateFrom, COL_ValueDateTo)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        txtResultReferenceID.Text = ""
        _resultReferenceID = ""
        txtResultReferenceName.Text = ""
        txtNotice.Text = ""
        LoadAddNew()
        btnNext.Enabled = False
        btnSave.Enabled = True
        txtResultReferenceID.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        tdbg.UpdateData()
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                _resultReferenceID = txtResultReferenceID.Text
                sSQL.Append(SQLInsertD13T1100.ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T1101s.ToString & vbCrLf)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T1100.ToString & vbCrLf)
                sSQL.Append(SQLDeleteD13T1101.ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T1101s.ToString & vbCrLf)
        End Select
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _resultReferenceID = txtResultReferenceID.Text
            _bSaved = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'Audit Log
                    Dim sDesc1 As String = txtResultReferenceID.Text
                    Dim sDesc2 As String = txtResultReferenceName.Text
                    Dim sDesc3 As String = txtNotice.Text
                    Dim sDesc4 As String = SQLNumber(chkDisabled.Checked)
                    Dim sDesc5 As String = ""
                    RunAuditLog(AuditCodeResultRecTable, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

#Region "events of tdbg"

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_MethodName
                tdbg.Columns(COL_MethodName).Text = tdbdMethod.Columns("MethodName").Text
                tdbg.Columns(COL_Method).Text = tdbdMethod.Columns("Method").Text
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_ValueFrom
                If Not L3IsNumeric(tdbg.Columns(COL_ValueFrom).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_ValueTo
                If Not L3IsNumeric(tdbg.Columns(COL_ValueTo).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_Method
                If Not L3IsNumeric(tdbg.Columns(COL_Method).Text, EnumDataType.TinyInt) Then e.Cancel = True
            Case COL_MethodName
                If tdbg.Columns(COL_MethodName).Text <> tdbdMethod.Columns("MethodName").Text Then
                    tdbg.Columns(COL_MethodName).Text = ""
                    tdbg.Columns(COL_Method).Text = ""
                End If
            Case COL_Result
                If Not L3IsNumeric(tdbg.Columns(COL_Result).Text, EnumDataType.Money) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.UpdateData()
        Select Case e.ColIndex
            Case COL_ValueTo
                If tdbg.Row = 0 Then
                    tdbg.Columns(COL_ValueFrom).Text = "0"
                End If
                If tdbg.Row <> 0 Then
                    tdbg.Columns(COL_ValueFrom).Text = tdbg(tdbg.Row - 1, COL_ValueTo).ToString()
                End If
                If tdbg.Row < tdbg.RowCount - 1 Then
                    tdbg(tdbg.Row + 1, COL_ValueFrom) = tdbg.Columns(COL_ValueTo).Text
                End If
            Case COL_ValueDateTo
                '                If tdbg.Row = 0 Then
                '                    tdbg.Columns(COL_ValueDateFrom).Value = Now.Date
                '                End If
                If tdbg.Row <> 0 Then
                    tdbg.Columns(COL_ValueDateFrom).Text = tdbg(tdbg.Row - 1, COL_ValueDateTo).ToString()
                End If
                If tdbg.Row < tdbg.RowCount - 1 Then
                    tdbg(tdbg.Row + 1, COL_ValueDateFrom) = tdbg.Columns(COL_ValueDateTo).Text
                End If
        End Select
    End Sub

    Private Sub tdbg_BeforeDelete(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeDelete
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        If e.Row >= 1 Then
            e.CellStyle.Locked = True
            e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End If
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_ValueFrom
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_ValueTo
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Method
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Result
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Shift And e.KeyCode = Keys.Insert Then
            bShiftInsert = True
            HotKeyShiftInsert(tdbg, SPLIT0, COL_ValueTo, tdbg.Columns.Count)
            bShiftInsert = False
        End If

        Select Case e.KeyCode
            Case Keys.Enter
                If tdbg.Col = COL_Result Then
                    HotKeyEnterGrid(tdbg, COL_ValueTo, e)
                End If
        End Select
    End Sub

#End Region

    Private Sub optModeValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optModeValue.CheckedChanged
        If optModeValue.Checked Then
            tdbg.Splits(0).DisplayColumns(COL_ValueFrom).Visible = True
            tdbg.Splits(0).DisplayColumns(COL_ValueTo).Visible = True
            tdbg.Splits(0).DisplayColumns(COL_ValueDateFrom).Visible = False
            tdbg.Splits(0).DisplayColumns(COL_ValueDateTo).Visible = False
        Else
            tdbg.Splits(0).DisplayColumns(COL_ValueFrom).Visible = False
            tdbg.Splits(0).DisplayColumns(COL_ValueTo).Visible = False
            tdbg.Splits(0).DisplayColumns(COL_ValueDateFrom).Visible = True
            tdbg.Splits(0).DisplayColumns(COL_ValueDateTo).Visible = True
        End If
    End Sub

 
End Class