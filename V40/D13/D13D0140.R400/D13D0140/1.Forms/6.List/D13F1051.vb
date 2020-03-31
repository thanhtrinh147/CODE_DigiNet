Imports System
Imports System.Windows.Forms
'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:43:52 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:43:52 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F1051
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Dim dtCaption As DataTable
    Dim dtFilter As DataTable
    Dim bUnicode As Boolean = L3Bool(gbUnicode)

    Private _officialTitleID As String
    Public Property OfficialTitleID() As String
        Get
            Return _officialTitleID
        End Get
        Set(ByVal Value As String)
            _officialTitleID = Value
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Output01", Value)
        End Set
    End Property

    Private _officialTitleName As String
    Public Property OfficialTitleName() As String
        Get
            Return _officialTitleName
        End Get
        Set(ByVal Value As String)
            _officialTitleName = Value
        End Set
    End Property

    Private _salaryLevelID As String
    Public Property SalaryLevelID() As String
        Get
            Return _salaryLevelID
        End Get
        Set(ByVal Value As String)
            _salaryLevelID = Value
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Output02", Value)
        End Set
    End Property

    Private _OldGrade As String = ""
    Public Property OldGrade() As String
        Get
            Return _OldGrade
        End Get
        Set(ByVal value As String)
            If _OldGrade = Value Then
                Return
            End If
            _OldGrade = Value
        End Set
    End Property

    Private _maxGrade As Integer
    Public WriteOnly Property MaxGrade() As Integer
        Set(ByVal Value As Integer)
            _maxGrade = Value
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
            CreateTable()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    CheckIdTextBox(txtSalaryLevelID)
                    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "False")
                    btnNext.Enabled = False
                    btnSave.Enabled = True
                    LoadAdd()
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = True
                    LoadEdit()
                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
                    btnClose.Focus()
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub D13F1051_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D13F1051_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'FormKeyPress(sender, e)
    End Sub

    Private Sub D13F1051_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = r("Cap_nhat_bac_luong_cong_chuc_-_D13F1051") & UnicodeCaption(bUnicode) 'CËp nhËt bËc l§¥ng c¤ng ch÷c - D13F1051
        '================================================================ 
        lblOfficialTitleID.Text = r("Ngach_luong") 'Ngạch lương
        lblSalaryLevelID.Text = r("Ma_bac_luong") 'Mã bậc lương
        lblGrade.Text = r("Bac_luong") 'Bậc lương
        lblNumberYearTransfer.Text = r("Thoi_gian_giu_bac_toi_thieu")
        lblNote.Text = r("Ghi_chu") ' Ghi chú
        lblSalaryLevelName.Text = r("Ten_bac_luong") ' Tên bậc lương
        '================================================================ 
        btnSave.Text = r("_Luu") '&Lưu
        btnClose.Text = r("Do_ng") 'Đó&ng

        btnNext.Text = r("Nhap__tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = r("Khong_su_dung") 'Không sử dụng

        '================================================================ 
        tdbcOfficialTitleID.Columns("OfficialTitleID").Caption = r("Ma") 'Mã
        tdbcOfficialTitleID.Columns("OfficialTitleName").Caption = r("Ten") 'Tên
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcOfficialTitleID
        sSQL = "Select OfficialTitleID, "
        sSQL &= IIf(bUnicode, "OfficialTitleNameU as OfficialTitleName", "OfficialTitleName").ToString
        sSQL &= ", IsUseOfficial From D09T0214 Where Disabled = 0  "
        LoadDataSource(tdbcOfficialTitleID, sSQL, bUnicode)
    End Sub

    Private Sub CreateTable()
        Dim sSQL As String = ""
        sSQL = "Select * From D13T9000 Where Type = 'OLSC'"
        dtCaption = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadCaption(ByVal sIsUseOfficial As String)
        If sIsUseOfficial = "1" Or sIsUseOfficial = "0" Then
            dtFilter = ReturnTableFilter(dtCaption, "Code like 'OLSC1%'")
            For i As Integer = 0 To dtFilter.Rows.Count - 1
                With dtFilter.Rows(i)
                    Select Case .Item("Code").ToString
                        Case "OLSC11"
                            lblSalaryCoefficient.Text = .Item("Short").ToString
                            txtSalaryCoefficient.Text = SQLNumber(txtSalaryCoefficient.Text, InsertFormat(.Item("Decimals").ToString))
                            txtSalaryCoefficient.Enabled = .Item("Disabled").ToString = "0"
                        Case "OLSC12"
                            lblSalaryCoefficient02.Text = .Item("Short").ToString
                            txtSalaryCoefficient02.Text = SQLNumber(txtSalaryCoefficient02.Text, InsertFormat(.Item("Decimals").ToString))
                            txtSalaryCoefficient02.Enabled = .Item("Disabled").ToString = "0"
                        Case "OLSC13"
                            lblSalaryCoefficient03.Text = .Item("Short").ToString
                            txtSalaryCoefficient03.Text = SQLNumber(txtSalaryCoefficient03.Text, InsertFormat(.Item("Decimals").ToString))
                            txtSalaryCoefficient03.Enabled = .Item("Disabled").ToString = "0"
                        Case "OLSC14"
                            lblSalaryCoefficient04.Text = .Item("Short").ToString
                            txtSalaryCoefficient04.Text = SQLNumber(txtSalaryCoefficient04.Text, InsertFormat(.Item("Decimals").ToString))
                            txtSalaryCoefficient04.Enabled = .Item("Disabled").ToString = "0"
                        Case "OLSC15"
                            lblSalaryCoefficient05.Text = .Item("Short").ToString
                            txtSalaryCoefficient05.Text = SQLNumber(txtSalaryCoefficient05.Text, InsertFormat(.Item("Decimals").ToString))
                            txtSalaryCoefficient05.Enabled = .Item("Disabled").ToString = "0"
                    End Select
                End With
            Next
        ElseIf sIsUseOfficial = "2" Then
            dtFilter = ReturnTableFilter(dtCaption, "Code like 'OLSC2%'")
            For i As Integer = 0 To dtFilter.Rows.Count - 1
                With dtFilter.Rows(i)
                    Select Case .Item("Code").ToString
                        Case "OLSC21"
                            lblSalaryCoefficient.Text = .Item("Short").ToString
                            txtSalaryCoefficient.Text = SQLNumber(txtSalaryCoefficient.Text, InsertFormat(.Item("Decimals").ToString))
                            txtSalaryCoefficient.Enabled = .Item("Disabled").ToString = "0"
                        Case "OLSC22"
                            lblSalaryCoefficient02.Text = .Item("Short").ToString
                            txtSalaryCoefficient02.Text = SQLNumber(txtSalaryCoefficient02.Text, InsertFormat(.Item("Decimals").ToString))
                            txtSalaryCoefficient02.Enabled = .Item("Disabled").ToString = "0"
                        Case "OLSC23"
                            lblSalaryCoefficient03.Text = .Item("Short").ToString
                            txtSalaryCoefficient03.Text = SQLNumber(txtSalaryCoefficient03.Text, InsertFormat(.Item("Decimals").ToString))
                            txtSalaryCoefficient03.Enabled = .Item("Disabled").ToString = "0"
                        Case "OLSC24"
                            lblSalaryCoefficient04.Text = .Item("Short").ToString
                            txtSalaryCoefficient04.Text = SQLNumber(txtSalaryCoefficient04.Text, InsertFormat(.Item("Decimals").ToString))
                            txtSalaryCoefficient04.Enabled = .Item("Disabled").ToString = "0"
                        Case "OLSC25"
                            lblSalaryCoefficient05.Text = .Item("Short").ToString
                            txtSalaryCoefficient05.Text = SQLNumber(txtSalaryCoefficient05.Text, InsertFormat(.Item("Decimals").ToString))
                            txtSalaryCoefficient05.Enabled = .Item("Disabled").ToString = "0"
                    End Select
                End With
            Next
        Else
            lblSalaryCoefficient.Text = r("He_so_luong") & " 01"
            lblSalaryCoefficient02.Text = r("He_so_luong") & " 02"
            lblSalaryCoefficient03.Text = r("He_so_luong") & " 03"
            lblSalaryCoefficient04.Text = r("He_so_luong") & " 04"
            lblSalaryCoefficient05.Text = r("He_so_luong") & " 05"

            txtSalaryCoefficient.Enabled = True
            txtSalaryCoefficient02.Enabled = True
            txtSalaryCoefficient03.Enabled = True
            txtSalaryCoefficient04.Enabled = True
            txtSalaryCoefficient05.Enabled = True

            txtSalaryCoefficient.Text = SQLNumber(txtSalaryCoefficient.Text, D13Format.DefaultNumber2)
            txtSalaryCoefficient02.Text = SQLNumber(txtSalaryCoefficient02.Text, D13Format.DefaultNumber2)
            txtSalaryCoefficient03.Text = SQLNumber(txtSalaryCoefficient03.Text, D13Format.DefaultNumber2)
            txtSalaryCoefficient04.Text = SQLNumber(txtSalaryCoefficient04.Text, D13Format.DefaultNumber2)
            txtSalaryCoefficient05.Text = SQLNumber(txtSalaryCoefficient05.Text, D13Format.DefaultNumber2)
        End If
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL &= "Select D1.SalaryLevelID, D1.OfficialTitleID, D2.OfficialTitleName, D2.OfficialTitleNameU" & vbCrLf
        sSQL &= ", D1.SalaryCoefficient, D1.SalaryCoefficient02, D1.SalaryCoefficient03, D1.SalaryCoefficient04, D1.SalaryCoefficient05" & vbCrLf
        sSQL &= ", D1.Disabled, D1.NumberYearTransfer, D1.Grade, D1.Note, D1.NoteU, D1.SalaryLevelName, D1.SalaryLevelNameU " & vbCrLf
        sSQL &= "From D09T0215 AS D1 " & vbCrLf
        sSQL &= "Inner Join D09T0214 AS D2 On D1.OfficialTitleID=D2.OfficialTitleID " & vbCrLf
        sSQL &= "Where D1.OfficialTitleID = " & SQLString(_officialTitleID) & vbCrLf
        sSQL &= "AND D1.SalaryLevelID = " & SQLString(_salaryLevelID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dt.Rows.Count - 1
            tdbcOfficialTitleID.Text = dt.Rows(i).Item("OfficialTitleID").ToString
            txtOfficialTitleName.Text = dt.Rows(i).Item("OfficialTitleName" & UnicodeJoin(bUnicode)).ToString
            txtSalaryLevelID.Text = dt.Rows(i).Item("SalaryLevelID").ToString
            txtSalaryLevelName.Text = dt.Rows(i).Item("SalaryLevelName" & UnicodeJoin(bUnicode)).ToString
            chkDisabled.Checked = Convert.ToBoolean(dt.Rows(i).Item("Disabled").ToString)

            txtSalaryCoefficient.Text = SQLNumber(dt.Rows(i).Item("SalaryCoefficient").ToString, InsertFormat(dtFilter.Rows(2).Item("Decimals").ToString))
            txtSalaryCoefficient02.Text = SQLNumber(dt.Rows(i).Item("SalaryCoefficient02").ToString, InsertFormat(dtFilter.Rows(3).Item("Decimals").ToString))
            txtSalaryCoefficient03.Text = SQLNumber(dt.Rows(i).Item("SalaryCoefficient03").ToString, InsertFormat(dtFilter.Rows(4).Item("Decimals").ToString))
            txtSalaryCoefficient04.Text = SQLNumber(dt.Rows(i).Item("SalaryCoefficient04").ToString, InsertFormat(dtFilter.Rows(5).Item("Decimals").ToString))
            txtSalaryCoefficient05.Text = SQLNumber(dt.Rows(i).Item("SalaryCoefficient05").ToString, InsertFormat(dtFilter.Rows(6).Item("Decimals").ToString))

            txtNumberYearTransfer.Text = dt.Rows(i).Item("NumberYearTransfer").ToString
            txtGrade.Text = dt.Rows(i).Item("Grade").ToString
            txtNote.Text = dt.Rows(i).Item("Note" & UnicodeJoin(bUnicode)).ToString
        Next
    End Sub

    Private Sub LoadAdd()
        tdbcOfficialTitleID.Text = _officialTitleID
        txtSalaryLevelID.Text = ""
        txtSalaryLevelName.Text = ""
        txtOfficialTitleName.Text = _officialTitleName
        chkDisabled.Visible = False
        txtGrade.Text = (_maxGrade + 1).ToString
        
        LoadCaption(tdbcOfficialTitleID.Columns("IsUseOfficial").Text)
        txtNumberYearTransfer.Text = ""
        txtNote.Text = ""
        txtSalaryLevelID.Focus()
    End Sub

    Private Sub LoadEdit()
        txtSalaryCoefficient.Focus()
        tdbcOfficialTitleID.Enabled = False
        txtSalaryLevelID.Enabled = False
        chkDisabled.Visible = True
        LoadMaster()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Events tdbcOfficialTitleID with txtOfficialTitleName"

    Private Sub tdbcOfficialTitleID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID.Close
        If tdbcOfficialTitleID.FindStringExact(tdbcOfficialTitleID.Text) = -1 Then
            tdbcOfficialTitleID.Text = ""
            txtOfficialTitleName.Text = ""
        End If
    End Sub

    Private Sub tdbcOfficialTitleID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID.SelectedValueChanged
        If Not (tdbcOfficialTitleID.Tag Is Nothing OrElse tdbcOfficialTitleID.Tag.ToString = "") Then
            tdbcOfficialTitleID.Tag = ""
            Exit Sub
        End If
        If tdbcOfficialTitleID.SelectedValue Is Nothing Then
            LoadCaption("0")
            Exit Sub
        End If
        LoadCaption(tdbcOfficialTitleID.Columns("IsUseOfficial").Value.ToString)
        txtOfficialTitleName.Text = tdbcOfficialTitleID.Columns("OfficialTitleName").Value.ToString
    End Sub

    Private Sub tdbcOfficialTitleID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcOfficialTitleID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcOfficialTitleID.Text = ""
        '    txtOfficialTitleName.Text = ""
        'End If
    End Sub

#End Region

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        _bSaved = False
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "False")
        btnSave.Enabled = False
        btnClose.Enabled = False

        Select Case _FormState
            Case EnumFormState.FormAdd
                
                sSQL &= SQLInsertD09T0215()
            Case EnumFormState.FormEdit
                sSQL &= SQLUpdateD09T0215() & vbCrLf
                sSQL &= SQLStoreD13P1051()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "True")
            Select Case _FormState
                Case EnumFormState.FormAdd

                    OfficialTitleID = tdbcOfficialTitleID.Text
                    SalaryLevelID = txtSalaryLevelID.Text
                    _maxGrade = SafeCint(txtGrade.Text)
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit

                    'Audit Log
                    Dim sDesc1 As String = txtSalaryLevelID.Text
                    Dim sDesc2 As String = tdbcOfficialTitleID.Text
                    Dim sDesc3 As String = txtSalaryCoefficient.Text
                    Dim sDesc4 As String = SQLNumber(chkDisabled.Checked)
                    Dim sDesc5 As String = ""
                    RunAuditLog(AuditCodeSalaryLevels, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcOfficialTitleID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(r("Ngach_luong"))
            tdbcOfficialTitleID.Focus()
            Return False
        End If

        If txtGrade.Text = "" Then
            D99C0008.MsgNotYetEnter(r("Bac_luong"))
            txtGrade.Focus()
            Return False
        End If

        If txtSalaryLevelID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(r("Ma_bac_luong"))
            txtSalaryLevelID.Focus()
            Return False
        End If
        If txtSalaryLevelID.Text.Trim <> "" And txtSalaryLevelID.Text.Trim.Length > 20 Then
            D99C0008.MsgL3(r("Do_dai_Ma_bac_luong_khong_duoc_qua_20_ky_tu"))
            txtSalaryLevelID.Focus()
            Return False
        End If
        If txtSalaryCoefficient.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(r("He_so_luong"))
            txtSalaryCoefficient.Focus()
            Return False
        End If
        'If txtSalaryCoefficient.Text.Trim <> "" Then         'Rem lại 17/05/2010 ID32893
        '    If Convert.ToDouble(txtSalaryCoefficient.Text) >= 1000 Then
        '        D99C0008.MsgL3(r("He_so_luong_phai__1000_"))
        '        txtSalaryCoefficient.Text = ""
        '        txtSalaryCoefficient.Focus()
        '        Return False
        '    End If
        'End If

        If txtNumberYearTransfer.Text.Trim <> "" Then
            If Convert.ToDouble(txtNumberYearTransfer.Text) > MaxTinyInt Then
                D99C0008.MsgL3(r("Thoi_gian_giu_bac_toi_thieu") & "phải nhỏ hơn 255")
                txtNumberYearTransfer.Text = ""
                txtNumberYearTransfer.Focus()
                Return False
            End If
        End If

        If Not CheckNumSalaryLevelID() Then Return False

        Select Case _FormState
            Case EnumFormState.FormEdit, EnumFormState.FormAdd
                If OldGrade.ToString <> txtGrade.Text Then
                    If IsDupplicateGrade() Then
                        txtGrade.Focus()
                        Return False
                    End If
                End If
        End Select
        
        If _FormState = EnumFormState.FormAdd Then
            Dim sSQL As String = ""
            sSQL &= " Select OfficialTitleID, SalaryLevelID From D09T0215 " & vbCrLf
            sSQL &= " Where OfficialTitleID = " & SQLString(tdbcOfficialTitleID.Text) & vbCrLf
            sSQL &= " AND SalaryLevelID = " & SQLString(txtSalaryLevelID.Text)
            If ExistRecord(sSQL) Then
                D99C0008.MsgDuplicatePKey()
                txtSalaryLevelID.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Function IsDupplicateGrade() As Boolean
        Dim sSQL As String
        sSQL = "select top 1 1 from D09T0215 where Grade = " & SQLString(txtGrade.Text) & " and OfficialTitleID = " & SQLString(tdbcOfficialTitleID.Text)
        If ExistRecord(sSQL) Then
            D99C0008.MsgL3(r("Bac_luong_nay_da_ton_tai"))
            Return True
        Else
            Return False
        End If
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T0215
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 19/01/2007 03:13:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T0215() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D09T0215("
        sSQL &= "Grade, SalaryLevelID, OfficialTitleID, SalaryCoefficient, "
        sSQL &= "SalaryCoefficient02, SalaryCoefficient03, SalaryCoefficient04, SalaryCoefficient05, "
        sSQL &= "Disabled, NumberYearTransfer, Note, NoteU, "
        sSQL &= "CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, SalaryLevelName, SalaryLevelNameU "
        sSQL &= ") Values ("
        sSQL &= SQLNumber(txtGrade.Text) & COMMA 'Grade
        sSQL &= SQLString(txtSalaryLevelID.Text) & COMMA 'SalaryLevelID [KEY], varchar[20], NOT NULL
        sSQL &= SQLString(tdbcOfficialTitleID.Text) & COMMA 'OfficialTitleID [KEY], varchar[20], NOT NULL
        sSQL &= SQLMoney(txtSalaryCoefficient.Text) & COMMA 'SalaryCoefficient, money, NULL
        sSQL &= SQLMoney(txtSalaryCoefficient02.Text) & COMMA 'SalaryCoefficient02, money, NOT NULL
        sSQL &= SQLMoney(txtSalaryCoefficient03.Text) & COMMA 'SalaryCoefficient03, money, NOT NULL
        sSQL &= SQLMoney(txtSalaryCoefficient04.Text) & COMMA 'SalaryCoefficient04, money, NOT NULL
        sSQL &= SQLMoney(txtSalaryCoefficient05.Text) & COMMA 'SalaryCoefficient05, money, NOT NULL
        sSQL &= SQLNumber(chkDisabled.Checked) & COMMA 'Disabled, bit, NOT NULL
        sSQL &= SQLNumber(txtNumberYearTransfer.Text) & COMMA
        sSQL &= SQLStringUnicode(txtNote, False) & COMMA 'Note, varchar[250], NOT NULL
        sSQL &= SQLStringUnicode(txtNote, True) & COMMA 'Note, varchar[250], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NOT NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA  'LastModifyDate, datetime, NULL
        sSQL &= SQLStringUnicode(txtSalaryLevelName, False) & COMMA 'SalaryLevelName, varchar[150], NOT NULL
        sSQL &= SQLStringUnicode(txtSalaryLevelName, True) 'SalaryLevelName, varchar[150], NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD09T0215
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 19/01/2007 03:16:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD09T0215() As String
        Dim sSQL As String = ""
        sSQL &= "Update D09T0215 Set "
        sSQL &= "Grade = " & SQLNumber(txtGrade.Text) & COMMA
        sSQL &= "SalaryCoefficient = " & SQLMoney(txtSalaryCoefficient.Text) & COMMA 'money, NULL
        sSQL &= "SalaryCoefficient02 = " & SQLMoney(txtSalaryCoefficient02.Text) & COMMA 'money, NOT NULL
        sSQL &= "SalaryCoefficient03 = " & SQLMoney(txtSalaryCoefficient03.Text) & COMMA 'money, NOT NULL
        sSQL &= "SalaryCoefficient04 = " & SQLMoney(txtSalaryCoefficient04.Text) & COMMA 'money, NOT NULL
        sSQL &= "SalaryCoefficient05 = " & SQLMoney(txtSalaryCoefficient05.Text) & COMMA 'money, NOT NULL
        sSQL &= "Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA 'bit, NOT NULL
        sSQL &= "NumberYearTransfer = " & SQLNumber(txtNumberYearTransfer.Text) & COMMA
        sSQL &= "Note = " & SQLStringUnicode(txtNote, False) & COMMA 'varchar[250], NOT NULL
        sSQL &= "NoteU = " & SQLStringUnicode(txtNote, True) & COMMA 'varchar[250], NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" & COMMA 'datetime, NULL
        sSQL &= "SalaryLevelName = " & SQLStringUnicode(txtSalaryLevelName, False) & COMMA  'varchar[150], NOT NULL
        sSQL &= "SalaryLevelNameU = " & SQLStringUnicode(txtSalaryLevelName, True) 'varchar[150], NOT NULL
        sSQL &= " Where "
        sSQL &= "SalaryLevelID = " & SQLString(_salaryLevelID) & " And " '[KEY], varchar[20], NOT NULL
        sSQL &= "OfficialTitleID = " & SQLString(_officialTitleID) '[KEY], varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1051
    '# Created User: DUCTRONG
    '# Created Date: 04/01/2010 03:51:48
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1051() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1051 "
        sSQL &= SQLString(_salaryLevelID) & COMMA 'SalaryLevelID, varchar[20], NOT NULL
        sSQL &= SQLString(_officialTitleID) 'OfficialTitleID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Function CheckNumSalaryLevelID() As Boolean
        Dim sSQL2 As String = ""
        Dim sRet2 As String

        sSQL2 &= "Select NumSalaryLevel From D09T0214 Where OfficialTitleID= " & SQLString(tdbcOfficialTitleID.Text)
        sRet2 = ReturnScalar(sSQL2)
        If Convert.ToInt32(txtGrade.Text) > Convert.ToInt32(sRet2) Then
            D99C0008.MsgL3(r("Da_vuot_qua_so_bac_toi_da_cho_phep_Khong_the_them"))
            txtSalaryCoefficient.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAdd()
        btnNext.Enabled = False
        btnSave.Enabled = True
        tdbcOfficialTitleID.Focus()
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcOfficialTitleID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtSalaryLevelID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtSalaryCoefficient.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtGrade.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub txtNumberYearTransfer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberYearTransfer.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtGrade_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrade.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalaryCoefficient_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalaryCoefficient.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalaryCoefficient02_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalaryCoefficient02.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalaryCoefficient03_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalaryCoefficient03.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalaryCoefficient04_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalaryCoefficient04.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalaryCoefficient05_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalaryCoefficient05.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalaryCoefficient_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalaryCoefficient.LostFocus
        If tdbcOfficialTitleID.Text = "" Then
            txtSalaryCoefficient.Text = SQLNumber(txtSalaryCoefficient.Text, D13Format.DefaultNumber2)
        Else
            txtSalaryCoefficient.Text = SQLNumber(txtSalaryCoefficient.Text, InsertFormat(dtFilter.Rows(2).Item("Decimals").ToString))
        End If
    End Sub

    Private Sub txtSalaryCoefficient02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalaryCoefficient02.LostFocus
        If tdbcOfficialTitleID.Text = "" Then
            txtSalaryCoefficient02.Text = SQLNumber(txtSalaryCoefficient02.Text, D13Format.DefaultNumber2)
        Else
            txtSalaryCoefficient02.Text = SQLNumber(txtSalaryCoefficient02.Text, InsertFormat(dtFilter.Rows(3).Item("Decimals").ToString))
        End If
    End Sub

    Private Sub txtSalaryCoefficient03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalaryCoefficient03.LostFocus
        If tdbcOfficialTitleID.Text = "" Then
            txtSalaryCoefficient03.Text = SQLNumber(txtSalaryCoefficient03.Text, D13Format.DefaultNumber2)
        Else
            txtSalaryCoefficient03.Text = SQLNumber(txtSalaryCoefficient03.Text, InsertFormat(dtFilter.Rows(4).Item("Decimals").ToString))
        End If
    End Sub

    Private Sub txtSalaryCoefficient04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalaryCoefficient04.LostFocus
        If tdbcOfficialTitleID.Text = "" Then
            txtSalaryCoefficient04.Text = SQLNumber(txtSalaryCoefficient04.Text, D13Format.DefaultNumber2)
        Else
            txtSalaryCoefficient04.Text = SQLNumber(txtSalaryCoefficient04.Text, InsertFormat(dtFilter.Rows(5).Item("Decimals").ToString))
        End If
    End Sub

    Private Sub txtSalaryCoefficient05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalaryCoefficient05.LostFocus
        If tdbcOfficialTitleID.Text = "" Then
            txtSalaryCoefficient05.Text = SQLNumber(txtSalaryCoefficient05.Text, D13Format.DefaultNumber2)
        Else
            txtSalaryCoefficient05.Text = SQLNumber(txtSalaryCoefficient05.Text, InsertFormat(dtFilter.Rows(6).Item("Decimals").ToString))
        End If
    End Sub

End Class