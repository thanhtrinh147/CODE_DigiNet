Imports System
Public Class D25F1091
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_InterviewerID As Integer = 0   ' Mã
    Private Const COL_InterviewerName As Integer = 1 ' Tên
    Private Const COL_DutyName As Integer = 2        ' Chức vụ
    Private Const COL_ContactPhone As Integer = 3    ' Điện thoại
    Private Const COL_Note As Integer = 4            ' Ghi chú
#End Region

    ' Update 24/05/2011 - Chuẩn unicode theo DC25 _ TIENDAU
    Private sCreateUserID As String
    Private sCreateDate As String

    Private _intGroupID As String
    Public Property IntGroupID() As String
        Get
            Return _intGroupID
        End Get
        Set(ByVal Value As String)
            _intGroupID = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            Select Case _FormState
                Case EnumFormState.FormAdd
                    CheckIdTextBox(txtIntGroupID)
                    btnNext.Enabled = False
                    chkDisabled.Visible = False

                Case EnumFormState.FormEdit
                    ReadOnlyControl(txtIntGroupID)
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left

                Case EnumFormState.FormView
                    ReadOnlyControl(txtIntGroupID)
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub D25F1091_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D25F1091_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetBackColorObligatory()
        tdbg_LockedColumns()
        Loadlanguage()
        LoadTDBDropDown()
        LoadDefault()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtIntGroupID)
        
    SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_nhom_phong_van_-_D25F1091") & UnicodeCaption(gbUnicode) 'CËp nhËt nhâm phàng vÊn - D25F1091
        '================================================================ 
        lblIntGroupID.Text = rl3("Ma") 'Mã
        lblIntGroupName.Text = rl3("Ten") 'Tên
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblLine.Text = rl3("Danh_sach_nguoi_phong_van") 'Danh sách người phỏng vấn
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        tdbg.Columns("InterviewerID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("InterviewerName").Caption = rl3("Ten") 'Tên
        tdbg.Columns("DutyName").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns("ContactPhone").Caption = rl3("Dien_thoai") 'Điện thoại
        tdbg.Columns("Note").Caption = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        tdbdInterviewerID.Columns("InterviewerID").Caption = rl3("Ma") 'Mã
        tdbdInterviewerID.Columns("InterviewerName").Caption = rl3("Ten") 'Tên
    End Sub


    Private Sub LoadDefault()
        Dim sSQL As String
        sSQL = " SELECT	D1.IntGroupID,"
        sSQL &= " D1.IntGroupName" & UnicodeJoin(gbUnicode) & " AS IntGroupName, "
        sSQL &= " D1.Description" & UnicodeJoin(gbUnicode) & "  AS Description,"
        sSQL &= " D2.InterviewerName" & UnicodeJoin(gbUnicode) & "  AS InterviewerName,	"
        sSQL &= " D1.Notes" & UnicodeJoin(gbUnicode) & " AS Note, "
        sSQL &= " D09.DutyName" & IIf(gsLanguage = "84", "", "01").ToString & UnicodeJoin(gbUnicode) & " as DutyName , D2.ContactPhone,"
        sSQL &= " D1.Disabled, D1.InterviewerID,D1.CreateUserID, D1.CreateDate"
        sSQL &= " FROM D25T1090 D1 WITH(NOLOCK) "
        sSQL &= " LEFT JOIN	D25T1070  D2 WITH(NOLOCK) "
        sSQL &= " ON D1.InterviewerID = D2.InterviewerID"
        sSQL &= " LEFT JOIN	D09T0211 D09 WITH(NOLOCK) "
        sSQL &= " ON D09.DutyID = D2.Duty"
        sSQL &= " WHERE	D1.IntGroupID = " & SQLString(_intGroupID)

        'Trả ra bảng dt
        Dim dt As DataTable = ReturnDataTable(sSQL)
        'Load Master
        If dt.Rows.Count > 0 Then
            txtIntGroupID.Text = dt.Rows(0).Item("IntGroupID").ToString
            txtIntGroupName.Text = dt.Rows(0).Item("IntGroupName").ToString
            txtDescription.Text = dt.Rows(0).Item("Description").ToString
            chkDisabled.Checked = L3Bool(dt.Rows(0).Item("Disabled").ToString)
            'Lưu lại người tạo, ngày tạo để Lưu Edit
            sCreateUserID = dt.Rows(0).Item("CreateUserID").ToString
            sCreateDate = dt.Rows(0).Item("CreateDate").ToString
        End If
        'Load Grid
        LoadDataSource(tdbg, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdInterviewerID
        sSQL = "SELECT D25.InterviewerID,"
        sSQL &= " D25.InterviewerName" & UnicodeJoin(gbUnicode) & " AS InterviewerName, "
        sSQL &= " D25.ContactPhone, D09.DutyName" & IIf(gsLanguage = "84", "", "01").ToString & UnicodeJoin(gbUnicode) & " as DutyName,  D25.Note" & UnicodeJoin(gbUnicode) & " AS Note"
        sSQL &= " FROM D25T1070 D25 WITH(NOLOCK)  LEFT JOIN	D09T0211 D09  WITH(NOLOCK) ON D09.DutyID = D25.Duty"
        sSQL &= " WHERE D25.Disabled = 0 ORDER BY	InterviewerID"
        LoadDataSource(tdbdInterviewerID, sSQL, gbUnicode)
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_InterviewerName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ContactPhone).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub SetBackColorObligatory()
        txtIntGroupID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtIntGroupName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub


    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_InterviewerID
                If tdbg.Columns(e.ColIndex).Text <> tdbdInterviewerID.Columns("InterviewerID").Text Then
                    tdbg.Columns(COL_InterviewerID).Text = ""
                    tdbg.Columns(COL_InterviewerName).Text = ""
                    tdbg.Columns(COL_DutyName).Text = ""
                    tdbg.Columns(COL_ContactPhone).Text = ""
                    tdbg.Columns(COL_Note).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        '--- Gán giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_InterviewerID
                tdbg.Columns(COL_InterviewerName).Text = tdbdInterviewerID.Columns("InterviewerName").Text
                tdbg.Columns(COL_DutyName).Text = tdbdInterviewerID.Columns("DutyName").Text
                tdbg.Columns(COL_ContactPhone).Text = tdbdInterviewerID.Columns("ContactPhone").Text
                tdbg.Columns(COL_Note).Text = tdbdInterviewerID.Columns("Note").Text
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter And tdbg.Col = COL_Note Then
            HotKeyEnterGrid(tdbg, COL_InterviewerID, e)
        End If
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        ClearText(Me)
        CType(tdbg.DataSource, DataTable).Clear()
        tdbg.Update()
        btnSave.Enabled = True
        btnNext.Enabled = False
        txtIntGroupID.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD25T1090s.ToString)

                'Lưu LastKey của Số phiếu xuống Database (gọi hàm CreateIGEVoucherNo bật cờ True)
                'Kiểm tra trùng Số phiếu (gọi hàm CheckDuplicateVoucherNo)
                'Nếu tra trùng Số phiếu thì bật
                'btnSave.Enabled = True
                'btnClose.Enabled = True

            Case EnumFormState.FormEdit
                sSQL.Append(SQLDeleteD25T1090() & vbCrLf)
                sSQL.Append(SQLInsertD25T1090s.ToString)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    _intGroupID = txtIntGroupID.Text
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            _bSaved = False
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If txtIntGroupID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtIntGroupID.Focus()
            Return False
        End If

        If txtIntGroupName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten"))
            txtIntGroupName.Focus()
            Return False
        End If

        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D25T1090", "IntGroupID", txtIntGroupID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtIntGroupID.Focus()
                Return False
            End If
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 2
            For j As Integer = i + 1 To tdbg.RowCount - 1
                If tdbg(i, COL_InterviewerID).ToString.Trim = tdbg(j, COL_InterviewerID).ToString.Trim Then
                    D99C0008.MsgL3(rl3("Du_lieu_tren_luoi_khong_duoc_trung") & ". " & rl3("Ban_khong_duoc_phep_luu"))
                    tdbg.Bookmark = j
                    tdbg.Col = COL_InterviewerID
                    tdbg.Focus()
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1090s
    '# Created User: Lê Sơn Long
    '# Created Date: 23/12/2010 10:18:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1090s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D25T1090(")
            sSQL.Append("IntGroupID, IntGroupName, IntGroupNameU, Description, DescriptionU, ")
            sSQL.Append("Disabled, Notes, NotesU, InterviewerID, CreateUserID, ")
            sSQL.Append("CreateDate, LastModifyDate, LastModifyUserID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtIntGroupID.Text) & COMMA) 'IntGroupID [KEY], varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(txtIntGroupName.Text, gbUnicode, False) & COMMA) 'IntGroupName, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(txtIntGroupName.Text, gbUnicode, True) & COMMA) 'IntGroupNameU, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA) 'Description, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA) 'DescriptionU, nvarchar, NOT NULL
            sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, False) & COMMA) 'Notes, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, True) & COMMA) 'NotesU, nvarchar, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_InterviewerID)) & COMMA) 'InterviewerID [KEY], varchar[20], NOT NULL
            If _FormState = EnumFormState.FormAdd Then
                sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateDate, datetime, NOT NULL
                sSQL.Append("GetDate()" & COMMA) 'CreateUserID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString(sCreateUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                sSQL.Append(SQLDateTimeSave(sCreateDate) & COMMA) 'CreateDate, datetime, NOT NULL
            End If
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
            sSQL.Append(SQLString(gsUserID)) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T1090
    '# Created User: Lê Sơn Long
    '# Created Date: 23/12/2010 10:19:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T1090() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T1090"
        sSQL &= " Where "
        sSQL &= "IntGroupID = " & SQLString(_intGroupID)
        Return sSQL
    End Function

    'Private Sub LoadAddNew()
    '    Dim sSQL As String
    '    sSQL = " SELECT	D1.IntGroupID,"
    '    sSQL &= " D1.IntGroupName" & UnicodeJoin(gbUnicode) & " AS IntGroupName, "
    '    sSQL &= " D1.Description" & UnicodeJoin(gbUnicode) & "  AS Description,"
    '    sSQL &= " D2.InterviewerName" & UnicodeJoin(gbUnicode) & "  AS InterviewerName,	"
    '    sSQL &= " D1.Notes" & UnicodeJoin(gbUnicode) & " AS Note, "
    '    sSQL &= " D09.DutyName" & IIf(gsLanguage = "84", "", "01").ToString & UnicodeJoin(gbUnicode) & " as DutyName , D2.ContactPhone,"
    '    sSQL &= " D1.Disabled, D1.InterviewerID,D1.CreateUserID, D1.CreateDate"
    '    sSQL &= " FROM D25T1090 D1"
    '    sSQL &= " LEFT JOIN	D25T1070  D2"
    '    sSQL &= " ON D1.InterviewerID = D2.InterviewerID"
    '    sSQL &= " LEFT JOIN	D09T0211 D09"
    '    sSQL &= " ON D09.DutyID = D2.Duty"
    '    sSQL &= " WHERE	D1.IntGroupID = " & SQLString(_intGroupID)
    '    'Load lưới AddNew
    '    LoadDataSource(tdbg, sSQL, gbUnicode)
    'End Sub

End Class