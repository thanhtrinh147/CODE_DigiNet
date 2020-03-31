Imports System
Public Class D25F1031
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Dim bUnicode As Boolean = gbUnicode
    Private _recCostID As String
    Public Property RecCostID() As String
        Get
            Return _recCostID
        End Get
        Set(ByVal Value As String)
            _recCostID = Value
        End Set
    End Property

    Private _recCostName As String
    Public Property RecCostName() As String
        Get
            Return _recCostName
        End Get
        Set(ByVal Value As String)
            _recCostName = Value
        End Set
    End Property

    Private _disabled As Boolean
    Public Property Disabled() As Boolean
        Get
            Return _disabled
        End Get
        Set(ByVal Value As Boolean)
            _disabled = Value
        End Set
    End Property

    Private _note As String
    Public Property Note() As String
        Get
            Return _note
        End Get
        Set(ByVal Value As String)
            _note = Value
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
                    btnNext.Enabled = False
                    chkDisabled.Visible = False

                Case EnumFormState.FormEdit
                    LoadEdit()
                    ReadOnlyControl(txtRecCostID)

                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    LoadEdit()
                    ReadOnlyControl(txtRecCostID)

            End Select
        End Set
    End Property

    Private Sub D25F1031_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            If Me.ActiveControl.Name = txtNote.Name Then Exit Sub
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D25F1031_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetBackColorObligatory()
        Loadlanguage()
        '*****
        InputbyUnicode(Me, bUnicode)
        'Update 27/07/2010: Kiểm tra nhập Mã
        CheckIdTextBox(txtRecCostID)
        ''***************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_chi_phi_tuyen_dung_-_D25F1031") & UnicodeCaption(bUnicode) 'CËp nhËt chi phÛ tuyÓn dóng - D25F1031
        '================================================================ 
        lblRecCostID.Text = rl3("Ma") 'Mã
        lblRecCostName.Text = rl3("Dien_giai") 'Diễn giải
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
    End Sub

    Private Sub LoadEdit()
        txtRecCostID.Text = RecCostID
        txtRecCostName.Text = RecCostName
        txtNote.Text = Note
        chkDisabled.Checked = Disabled
        '----------------------------
        btnNext.Visible = False
        btnSave.Left = btnNext.Left
        'txtRecCostID.Enabled = False
    End Sub

    Private Sub SetBackColorObligatory()
        txtRecCostID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtRecCostName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD25T1030)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T1030)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            RecCostID = txtRecCostID.Text
            SaveOK()
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            _bSaved = False
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        txtRecCostID.Text = ""
        txtRecCostName.Text = ""
        txtNote.Text = ""
        chkDisabled.Checked = False

        btnNext.Enabled = False
        txtRecCostID.Focus()
        btnSave.Enabled = True
    End Sub


    Private Function AllowSave() As Boolean
        If txtRecCostID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtRecCostID.Focus()
            Return False
        End If
        If txtRecCostName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtRecCostName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D25T1030", "RecCostID", txtRecCostID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtRecCostID.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1030
    '# Created User: Nguyễn Trần Phương Nam
    '# Created Date: 05/10/2007 03:28:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: Insert trường hợp thêm mới
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1030() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D25T1030(")
        sSQL.Append("RecCostID, RecCostName, RecCostNameU, Note, NoteU, Disabled, CreateUserID, ")
        sSQL.Append("LastModifyUserID, CreateDate, LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtRecCostID.Text) & COMMA) 'RecCostID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtRecCostName, False) & COMMA) 'RecCostName, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtRecCostName, True) & COMMA) 'RecCostNameU, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtNote, False) & COMMA) 'Note, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtNote, True) & COMMA) 'NoteU, varchar[250], NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T1030
    '# Created User: Nguyễn Trần Phương Nam
    '# Created Date: 05/10/2007 04:36:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu trường hợp Sửa Data
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T1030() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T1030 Set ")
        sSQL.Append("RecCostName = " & SQLStringUnicode(txtRecCostName, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("RecCostNameU = " & SQLStringUnicode(txtRecCostName, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("RecCostID = " & SQLString(txtRecCostID.Text))

        Return sSQL
    End Function

End Class