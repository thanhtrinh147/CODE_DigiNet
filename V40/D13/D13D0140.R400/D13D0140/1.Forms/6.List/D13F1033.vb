'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:42:48 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:42:48 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F1033
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Private _employeeID As String = ""

    Public Property EmployeeID() As String
        Get
            Return _employeeID
        End Get
        Set(ByVal value As String)
            If EmployeeID = value Then
                _employeeID = ""
                Return
            End If
            _employeeID = value
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
                    btnTemplate.Enabled = True
                Case EnumFormState.FormEdit
                    btnTemplate.Enabled = True
                Case EnumFormState.FormView
                    btnTemplate.Enabled = False
            End Select
        End Set
    End Property


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcTemplateID
        sSQL = "Select TemplateID, TemplateName" & UnicodeJoin(gbUnicode) & " as TemplateName, D0.DutyID, DutyName" & UnicodeJoin(gbUnicode) & " as DutyName, "
        sSQL &= " (Case When DateBeginBaseOn='FixedDate' Then convert(varchar(250), DateBegin,103) " & vbCrLf
        sSQL &= " else DateBeginBaseOn end ) DateBeginBaseOn " & vbCrLf
        sSQL &= "From D13T1060 D0  WITH (NOLOCK) Left join D09T0211 D1  WITH (NOLOCK) On D1.DutyID=D0.DutyID " & vbCrLf
        sSQL &= "Where D0.Disabled=0 And DivisionID = " & SQLString(gsDivisionID)
        LoadDataSource(tdbcTemplateID, sSQL, gbUnicode)
    End Sub

    Private Sub D13F1033_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        FormKeyPress(sender, e)
    End Sub

    Private Sub D13F1033_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        LoadTDBCombo()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Gan_template_tang_thong_so_luong_-_D13F1033") & UnicodeCaption(gbUnicode) 'GÀn template tŸng th¤ng sç l§¥ng - D13F1033
        '================================================================ 
        '   lblTemplateID.Text = rl3("Template") 'Template ' update 22/7/2013 id 57344
        lblDutyID.Text = rl3("Chuc_vu") 'Chức vụ
        lblDateBeginBaseOn.Text = rl3("Ngay_bat_dau_tinh") 'Ngày bắt đầu tính
        '================================================================ 
        btnTemplate.Text = rl3("_Gan_template") '&Gán template
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcTemplateID.Columns("TemplateID").Caption = rl3("Ma") 'Mã
        tdbcTemplateID.Columns("TemplateName").Caption = rl3("Ten") 'Tên
        tdbcTemplateID.Columns("DutyID").Caption = rl3("Ma_chuc_vu") 'Mã chức vụ
        tdbcTemplateID.Columns("DutyName").Caption = rl3("Ten_chuc_vu") 'Tên chức vụ
        tdbcTemplateID.Columns("DateBeginBaseOn").Caption = rl3("Ngay_bat_dau_tinh") 'Ngày bắt đầu tính
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcTemplateID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

#Region "Events tdbcTemplateID with txtTemplateName"

    Private Sub tdbcTemplateID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTemplateID.Close
        If tdbcTemplateID.FindStringExact(tdbcTemplateID.Text) = -1 Then
            tdbcTemplateID.Text = ""
            txtTemplateName.Text = ""
        End If
    End Sub

    Private Sub tdbcTemplateID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTemplateID.SelectedValueChanged
        txtTemplateName.Text = tdbcTemplateID.Columns(1).Value.ToString
        txtDutyID.Text = tdbcTemplateID.Columns(2).Value.ToString
        txtDutyName.Text = tdbcTemplateID.Columns(3).Value.ToString
        Dim sDateBeginBaseOn As String
        sDateBeginBaseOn = tdbcTemplateID.Columns(4).Value.ToString
        Select Case sDateBeginBaseOn
            Case "ExamineDateEnd"
                txtDateBeginBaseOn.Text = "Ngày xét cuối cùng"
            Case "DateJoined"
                txtDateBeginBaseOn.Text = "Ngày vào"
            Case "DateRecruited"
                txtDateBeginBaseOn.Text = "Ngày tuyển"
        End Select
    End Sub

    Private Sub tdbcTemplateID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcTemplateID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcTemplateID.Text = ""
        '    txtTemplateName.Text = ""
        'End If
    End Sub
#End Region

    Private Function AllowAssign() As Boolean
        If tdbcTemplateID.Text.Trim = "" Then
            'D99C0008.MsgL3(rl3("Ban_phai_chon") & " " & "Template")
            D99C0008.MsgNotYetChoose("Template")
            tdbcTemplateID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemplate.Click
        If Not AllowAssign() Then Exit Sub

        Dim sSQL As String = ""
        btnTemplate.Enabled = False
        btnClose.Enabled = False
        sSQL &= SQLStoreD13P1030()
        Me.Cursor = Cursors.WaitCursor
        Dim bResult As Boolean = ExecuteSQL(sSQL)
       
        Me.Cursor = Cursors.Default
        If bResult = True Then
            _bSaved = True
            D99C0008.MsgL3(rl3("Gan_Template_thanh_cong"))
            btnTemplate.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            D99C0008.MsgL3(rl3("Gan_Template_khong_thanh_cong"))
            btnTemplate.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1030
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 14/02/2007 11:05:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1030() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1030 "
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcTemplateID.Text) 'TemplateID, varchar[20], NOT NULL
        Return sSQL
    End Function

End Class