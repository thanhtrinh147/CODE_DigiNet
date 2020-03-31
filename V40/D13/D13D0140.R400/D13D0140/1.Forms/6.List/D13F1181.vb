Imports System.Drawing
Imports System
Public Class D13F1181
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Private _salEmpGroupID As String = ""
    Public Property SalEmpGroupID() As String
        Get
            Return _salEmpGroupID
        End Get
        Set(ByVal Value As String)
            _salEmpGroupID = Value
        End Set
    End Property

    '   Dim perD13F1181 As EnumPermission = CType(ReturnPermission("D13F1181"), EnumPermission)

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
                    btnPermission.Enabled = False
                    chkDisabled.Visible = False
                Case EnumFormState.FormEdit
                    LoadMaster()
                    ReadOnlyControl(txtSalEmpGroupID)
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnPermission.Enabled = True
                Case EnumFormState.FormView
                    LoadMaster()
                    ReadOnlyControl(txtSalEmpGroupID, txtSalEmpGroupName)
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False
                    btnPermission.Enabled = True
            End Select
        End Set
    End Property

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_nhom_luong_-_D13F1181") & UnicodeCaption(gbUnicode) 'CËp nhËt nhâm l§¥ng - D13F1181
        '================================================================ 
        lblSalEmpGroupID.Text = rl3("Ma") 'Mã
        lblSalEmpGroupName.Text = rl3("Ten") 'Tên
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        btnPermission.Text = "&" & rL3("Phan_quyen_du_lieu")
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
    End Sub


    Private Sub LoadMaster()
        Dim sSQL As String = "SELECT  SalEmpGroupID,SalEmpGroupName84" & UnicodeJoin(gbUnicode) & " as SalEmpGroupName84,Disabled,Note" & UnicodeJoin(gbUnicode) & " as Note"
        sSQL &= " From D13T1180  WITH (NOLOCK) Where SalEmpGroupID = " & SQLString(SalEmpGroupID)
        Dim dtGird As DataTable = ReturnDataTable(sSQL)
        If (dtGird.Rows.Count > 0) Then
            txtSalEmpGroupID.Text = SalEmpGroupID
            txtSalEmpGroupName.Text = dtGird.Rows(0).Item("SalEmpGroupName84").ToString
            txtNote.Text = dtGird.Rows(0).Item("Note").ToString
            chkDisabled.Checked = L3Bool(dtGird.Rows(0).Item("Disabled").ToString)
        End If
    End Sub

    Private Sub D13F1181_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            UseEnterAsTab(Me)
        End If
    End Sub
    Private Sub D13F1181_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        InputbyUnicode(Me, gbUnicode)
        Loadlanguage()
        CheckIdTextBox(txtSalEmpGroupID)
        SetBackColorObligatory()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
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
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        txtSalEmpGroupID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtSalEmpGroupName.BackColor = COLOR_BACKCOLOROBLIGATORY
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
                sSQL.Append(SQLInsertD13T1180)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T1180)
        End Select
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                    btnPermission.Enabled = True
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

    Private Sub btnPermission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPermission.Click
        Dim exe As D00E4240
        exe = New D00E4240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = "D00F0260"
        exe.FormPermission = "D00F0260"
        exe.Code = txtSalEmpGroupID.Text
        exe.Name = txtSalEmpGroupName.Text
        exe.ListType = "SalEmpGroup"
        exe.Run()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        ClearText(Me)
        txtSalEmpGroupID.Focus()
        chkDisabled.Checked = False
        btnSave.Enabled = True
        btnNext.Enabled = False
        btnPermission.Enabled = False
    End Sub

End Class