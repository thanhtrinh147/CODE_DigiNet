Imports System.Xml
Public Class D25F1021
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Dim _RecPositionID As String = ""
    Public Property RecPositionID() As String
        Get
            Return _RecPositionID
        End Get
        Set(ByVal Value As String)
            _RecPositionID = Value
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

            If _FormState <> EnumFormState.FormCopy Then
                tdbcWorkID.Enabled = False
                txtWorkName.Enabled = False
            End If

            Select Case _FormState

                Case EnumFormState.FormAdd, EnumFormState.FormCopy
                    btnNext.Enabled = False
                    LoadAddNew()
                    btnAttach.Enabled = False
                    chkDisabled.Visible = False

                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                    ReadOnlyControl(txtRecPositionID)

                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSave.Enabled = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                    ReadOnlyControl(txtRecPositionID)

            End Select
        End Set
    End Property

    Private Sub D25F1021_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        End If
        If e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tab1.SelectedTab = TabPage1
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            tab1.SelectedTab = TabPage2
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tab1.SelectedTab = TabPage3
        End If
    End Sub

    Private Sub D25F1021_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetBackColorObligatory()
        'LoadFormatNumber()
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtRecPositionID)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_vi_tri_ung_tuyen_-_D25F1021") & UnicodeCaption(gbUnicode) 'CËp nhËt vÜ trÛ ÷ng tuyÓn - D25F1021
        '================================================================ 
        lblRecPositionID.Text = rl3("Ma") 'Mã
        lblRecPositionName.Text = rl3("Dien_giai") 'Diễn giải

        lblmet.Text = rl3("(met)") '(mét)
        lblSex.Text = rl3("Gioi_tinh") 'Giới tính
        lblFromHeight.Text = rl3("Chieu_cao") 'Chiều cao

        lblFromWeight.Text = rl3("Can_nang") 'Cân nặng

        lblFromAge.Text = rl3("Tuoi") 'Tuổi

        lblMaritalStatusID.Text = rl3("TT_hon_nhan") 'TT hôn nhân
        lblPopulationID.Text = rl3("Ho_khau") 'Hộ khẩu
        lblReligionID.Text = rl3("Ton_giao") 'Tôn giáo
        lblCountryID.Text = rl3("Quoc_tich") 'Quốc tịch
        lblHealthStatus.Text = rl3("Suc_khoe") 'Sức khoẻ
        lblAppearance.Text = rl3("Ngoai_hinh") 'Ngoại hình
        lblEducationLevelID.Text = rl3("TD_van_hoa") 'TĐ văn hóa
        lblProfessionalLevelID.Text = rl3("TD_chuyen_mon") 'TĐ chuyên môn
        lblLanguageID.Text = rl3("Ngoai_ngu") 'Ngoại ngữ
        lblExperienceYear.Text = rl3("Kinh_nghiem") 'Kinh nghiệm
        lblSalaryFrom.Text = rl3("Muc_luong") 'Mức lương

        lblJobRequirement.Text = rl3("Yeu_cau_khac") 'Yêu cầu khác
        lblComputingLevel.Text = rl3("Tin_hoc") 'Tin học
        lblOtherTransaction.Text = rl3("Nghiep_vu_khac") 'Nghiệp vụ khác
        lblJobDescription.Text = rl3("Mo_ta") 'Mô tả
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        lblWorkID.Text = rl3("Cong_viec") 'Công việc
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnAttach.Text = rl3("Dinh_kem") 'Đính kèm
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        TabPage1.Text = rl3("1_Yeu_cau_chung") '1. Yêu cầu chung
        TabPage2.Text = rl3("2_Yeu_cau_chuyen_mon") '2. Yêu cầu chuyên môn
        TabPage3.Text = rl3("3_Mo_ta_cong_viec") '3. Mô tả công việc
        '================================================================ 
        tdbcCountryID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcCountryID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcReligionID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcReligionID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcPopulationID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcPopulationID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcMaritalStatusID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcMaritalStatusID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcSex.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcSex.Columns("Description").Caption = rl3("") '
        tdbcCurrencyID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcCurrencyID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcEducationLevelID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcEducationLevelID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcWorkID.Columns("WorkID").Caption = rl3("Ma") 'Mã
        tdbcWorkID.Columns("WorkName").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcSex
        'sSQL = " Select	0 as Sex, " & IIf(geLanguage = EnumLanguage.Vietnamese, "'Nam'", "'Male'").ToString & " as Description " & vbCrLf
        If (gbUnicode) Then
            sSQL = " Select	0 as Code, N'" & ConvertVniToUnicode(rl3("NamV")) & "' as Description " & vbCrLf
            sSQL &= " Union	" & vbCrLf
            sSQL &= " Select	1 as Code, N'" & ConvertVniToUnicode(rl3("Nu")) & "' as Description " & vbCrLf
            sSQL &= " Union	" & vbCrLf
            sSQL &= " Select	2 as Code, N'" & ConvertVniToUnicode(rl3("Khong_xet")) & "' as Description " & vbCrLf
            sSQL &= " Order by	Code"
            LoadDataSource(tdbcSex, sSQL, gbUnicode)

            sSQL = " "
            sSQL &= " Select 0 as Code , N'" & ConvertVniToUnicode(rl3("Doc_than")) & "' as Description" & vbCrLf
            sSQL &= " Union	" & vbCrLf
            sSQL &= " Select 1 as Code , N'" & ConvertVniToUnicode(rl3("Ket_hon")) & "' as Description" & vbCrLf
            sSQL &= " Union	" & vbCrLf
            sSQL &= " Select 2 as Code , N'" & ConvertVniToUnicode(rl3("Khong_xet")) & "' as Description" & vbCrLf
            sSQL &= " Order by	Code " & vbCrLf
            LoadDataSource(tdbcMaritalStatusID, sSQL, gbUnicode)
        Else
            sSQL = " Select	0 as Code, '" & rl3("NamV") & "' as Description " & vbCrLf
            sSQL &= " Union	" & vbCrLf
            sSQL &= " Select	1 as Code, '" & rl3("Nu") & "' as Description " & vbCrLf
            sSQL &= " Union	" & vbCrLf
            sSQL &= " Select	2 as Code, '" & rl3("Khong_xet") & "' as Description " & vbCrLf
            sSQL &= " Order by	Code"
            LoadDataSource(tdbcSex, sSQL, gbUnicode)

            sSQL = " "
            sSQL &= " Select 0 as Code , '" & rl3("Doc_than") & "' as Description" & vbCrLf
            sSQL &= " Union	" & vbCrLf
            sSQL &= " Select 1 as Code , '" & rl3("Ket_hon") & "' as Description" & vbCrLf
            sSQL &= " Union	" & vbCrLf
            sSQL &= " Select 2 as Code , '" & rl3("Khong_xet") & "' as Description" & vbCrLf
            sSQL &= " Order by	Code " & vbCrLf
            LoadDataSource(tdbcMaritalStatusID, sSQL, gbUnicode)
        End If

        'Load tdbcPopulationID
        sSQL = " "
        sSQL &= " Select PopulationID as Code, "
        sSQL &= " PopulationName" & UnicodeJoin(gbUnicode) & "  as Description" & vbCrLf
        sSQL &= " From	D09T0126 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where	Disabled = 0" & vbCrLf
        sSQL &= " Order by	PopulationID" & vbCrLf
        LoadDataSource(tdbcPopulationID, sSQL, gbUnicode)

        'Load tdbcReligionID
        sSQL = " "
        sSQL &= " Select ReligionID as Code,"
        sSQL &= " ReligionName" & UnicodeJoin(gbUnicode) & "  as Description" & vbCrLf
        sSQL &= " From	D09T0204 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where	Disabled = 0" & vbCrLf
        sSQL &= " Order by	ReligionID" & vbCrLf
        LoadDataSource(tdbcReligionID, sSQL, gbUnicode)

        'Load tdbcCountryID
        sSQL = " "
        sSQL &= " Select CountryID as Code,"
        sSQL &= " CountryName" & UnicodeJoin(gbUnicode) & "  as Description" & vbCrLf
        sSQL &= " From	D91T0017 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where	Disabled = 0" & vbCrLf
        sSQL &= " Order by	CountryID" & vbCrLf
        sSQL &= " "
        LoadDataSource(tdbcCountryID, sSQL, gbUnicode)

        'Load tdbcEducationLevelID
        sSQL = " "
        sSQL &= " Select EducationLevelID as Code,"
        sSQL &= " EducationLevelName" & UnicodeJoin(gbUnicode) & "  as Description" & vbCrLf
        sSQL &= " From	D09T0206 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where	Disabled = 0" & vbCrLf
        sSQL &= " Order by	EducationLevelID" & vbCrLf
        sSQL &= " "
        LoadDataSource(tdbcEducationLevelID, sSQL, gbUnicode)


        'Load tdbcCurrencyID
        sSQL = " "
        sSQL &= " Select CurrencyID as Code,"
        sSQL &= " CurrencyName" & UnicodeJoin(gbUnicode) & "  as Description" & vbCrLf
        sSQL &= " From	D91T0010  WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where	Disabled = 0" & vbCrLf
        sSQL &= " Order by	CurrencyID" & vbCrLf
        sSQL &= " "
        LoadDataSource(tdbcCurrencyID, sSQL, gbUnicode)


        sSQL = "Select WorkID, WorkName" & UnicodeJoin(gbUnicode) & " as WorkName " & vbCrLf
        sSQL &= "From D09T0224 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "Order by WorkID" & vbCrLf
        LoadDataSource(tdbcWorkID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadData()
        Dim sSQL As String = ""
        Dim dt As DataTable
        sSQL &= " SELECT RecPositionID,Disabled,CreateUserID,LastModifyUserID,CreateDate,LastModifyDate"
        sSQL &= " ,Sex,FromHeight,ToHeight,FromWeight,ToWeight,FromAge,ToAge,MaritalStatusID,PopulationID"
        sSQL &= " ,NationalityID,InheritWorkID,ProfessionalLevelID,MajorID,LanguageID,LanguageLevelID,ExperienceYear"
        sSQL &= " ,SalaryFrom,SalaryTo,CurrencyID,ReligionID,CountryID,EducationLevelID "
        sSQL &= " ,SexName" & UnicodeJoin(gbUnicode) & " as SexName,Note" & UnicodeJoin(gbUnicode) & "  as Note,Appearance" & UnicodeJoin(gbUnicode) & "  as Appearance"
        sSQL &= " ,ProfessionalLevel" & UnicodeJoin(gbUnicode) & "  as ProfessionalLevel,ComputingLevel" & UnicodeJoin(gbUnicode) & "  as ComputingLevel"
        sSQL &= " ,OtherTransaction" & UnicodeJoin(gbUnicode) & "  as OtherTransaction,Experience" & UnicodeJoin(gbUnicode) & "  as Experience"
        sSQL &= " ,EducationLevel" & UnicodeJoin(gbUnicode) & "  as EducationLevel,Health" & UnicodeJoin(gbUnicode) & "  as Health"
        sSQL &= " ,OtherRequirement" & UnicodeJoin(gbUnicode) & "  as OtherRequirement"
        sSQL &= " ,RecPositionName" & UnicodeJoin(gbUnicode) & " as RecPositionName,JobDescription" & UnicodeJoin(gbUnicode) & " as JobDescription"
        sSQL &= " ,LanguageLevel" & UnicodeJoin(gbUnicode) & " as LanguageLevel,JobRequirement" & UnicodeJoin(gbUnicode) & " as JobRequirement,HealthStatus" & UnicodeJoin(gbUnicode) & " as HealthStatus "
        sSQL &= " FROM D25T1020  WITH(NOLOCK) "
        sSQL &= " Where	RecPositionID = " & SQLString(_RecPositionID)

        'sSQL = " Select * "
        'sSQL &= " From	D25T1020 "

        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If _FormState = EnumFormState.FormCopy Then
                tdbcWorkID.SelectedValue = dt.Rows(0).Item("InheritWorkID").ToString
            End If

            txtRecPositionID.Text = dt.Rows(0).Item("RecPositionID").ToString
            txtRecPositionName.Text = dt.Rows(0).Item("RecPositionName").ToString
            tdbcSex.SelectedValue = dt.Rows(0).Item("Sex").ToString
            txtFromHeight.Text = Format(Number(dt.Rows(0).Item("FromHeight").ToString), D25Format.DefaultNumber2)
            txtToHeight.Text = Format(Number(dt.Rows(0).Item("ToHeight").ToString), D25Format.DefaultNumber2)
            txtFromWeight.Text = Format(Number(dt.Rows(0).Item("FromWeight").ToString), D25Format.DefaultNumber2)
            txtToWeight.Text = Format(Number(dt.Rows(0).Item("ToWeight").ToString), D25Format.DefaultNumber2)
            txtFromAge.Text = Format(Number(dt.Rows(0).Item("FromAge").ToString), D25Format.DefaultNumber0)
            txtToAge.Text = Format(Number(dt.Rows(0).Item("ToAge").ToString), D25Format.DefaultNumber0)
            tdbcMaritalStatusID.Text = dt.Rows(0).Item("MaritalStatusID").ToString
            tdbcPopulationID.Text = dt.Rows(0).Item("PopulationID").ToString
            tdbcReligionID.Text = dt.Rows(0).Item("ReligionID").ToString
            tdbcCountryID.Text = dt.Rows(0).Item("CountryID").ToString
            tdbcEducationLevelID.Text = dt.Rows(0).Item("EducationLevelID").ToString
            txtHealthStatus.Text = dt.Rows(0).Item("HealthStatus").ToString
            txtSexName.Text = dt.Rows(0).Item("SexName").ToString
            txtAppearance.Text = dt.Rows(0).Item("Appearance").ToString

            'tdbcProfessionalLevelID.Text = dt.Rows(0).Item("ProfessionalLevelID").ToString
            'tdbcMajorID.Text = dt.Rows(0).Item("MajorID").ToString
            'tdbcLanguageID.Text = dt.Rows(0).Item("LanguageID").ToString()
            'tdbcLanguageLevelID.Text = dt.Rows(0).Item("LanguageLevelID").ToString


            'Tab2
            txtProfessionalLevel.Text = dt.Rows(0).Item("ProfessionalLevel").ToString
            txtComputingLevel.Text = dt.Rows(0).Item("ComputingLevel").ToString
            txtLanguageLevel.Text = dt.Rows(0).Item("LanguageLevel").ToString
            txtOtherTransaction.Text = dt.Rows(0).Item("OtherTransaction").ToString
            txtExperience.Text = dt.Rows(0).Item("Experience").ToString

            txtSalaryFrom.Text = Format(Number(dt.Rows(0).Item("SalaryFrom").ToString), D25Format.DefaultNumber2)
            txtSalaryTo.Text = Format(Number(dt.Rows(0).Item("SalaryTo").ToString), D25Format.DefaultNumber2)
            tdbcCurrencyID.Text = dt.Rows(0).Item("CurrencyID").ToString
            txtJobRequirement.Text = dt.Rows(0).Item("JobRequirement").ToString
            txtJobDescription.Text = dt.Rows(0).Item("JobDescription").ToString
            txtNote.Text = dt.Rows(0).Item("Note").ToString
            chkDisabled.Checked = Convert.ToBoolean(dt.Rows(0).Item("Disabled"))
        End If

    End Sub

    Private Sub LoadEdit()
        LoadData()
        btnAttach.Text = rl3("Dinh_ke_m") & Space(1) & "(" & ReturnAttachmentNumber("D25T1020", txtRecPositionID.Text, , , , , ) & ")"  'Đính kèm
    End Sub

    Private Sub LoadAddNew()
        '_RecPositionID = ""
        tdbcWorkID.SelectedValue = ""
        tdbcSex.SelectedValue = 2
        txtRecPositionID.Text = ""
        txtRecPositionName.Text = ""
        txtFromHeight.Text = "0.00"
        txtToHeight.Text = "0.00"
        txtFromWeight.Text = "0.00"
        txtToWeight.Text = "0.00"
        txtFromAge.Text = "0"
        txtToAge.Text = "0"
        tdbcMaritalStatusID.Text = ""
        txtMaritalStatusName.Text = ""
        tdbcPopulationID.Text = ""
        txtPopulationName.Text = ""
        tdbcReligionID.Text = ""
        txtRecPositionName.Text = ""
        tdbcCountryID.Text = ""
        txtCountryName.Text = ""
        tdbcEducationLevelID.Text = ""
        txtEducationLevelName.Text = ""
        txtHealthStatus.Text = ""
        txtSexName.Text = ""
        txtAppearance.Text = ""

        'Tab 2
        'tdbcProfessionalLevelID.Text = ""
        txtProfessionalLevel.Text = ""
        txtProfessionalLevel.Text = ""

        txtComputingLevel.Text = ""
        txtOtherTransaction.Text = ""
        txtLanguageLevel.Text = ""


        txtExperience.Text = ""
        txtSalaryFrom.Text = "0.00"
        txtSalaryTo.Text = "0.00"
        tdbcCurrencyID.Text = ""
        txtJobRequirement.Text = ""
        txtJobDescription.Text = ""
        txtNote.Text = ""

        btnSave.Enabled = True
        btnNext.Enabled = False
        tab1.SelectedIndex = 0
        If _FormState = EnumFormState.FormCopy Then
            tdbcWorkID.Focus()
        ElseIf _FormState = EnumFormState.FormAdd Then
            txtRecPositionID.Focus()
        End If

    End Sub

    Private Sub SetBackColorObligatory()
        txtRecPositionID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtRecPositionName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function AllowSave() As Boolean
        If txtRecPositionID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtRecPositionID.Focus()
            Return False
        End If
        If txtRecPositionName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtRecPositionName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormCopy Then
            If IsExistKey("D25T1020", "RecPositionID", txtRecPositionID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtRecPositionID.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1020
    '# Created User: Lê Thị Lành
    '# Created Date: 10/10/2007 08:00:03
    '# Modified User: 
    '# Modified Date: 
    '# Description: Luu AddNew
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1020() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append(" Insert Into D25T1020(")
        sSQL.Append(" RecPositionID, RecPositionName,RecPositionNameU, JobDescription,JobDescriptionU, JobRequirement, JobRequirementU, Note,NoteU, " & vbCrLf)
        sSQL.Append(" Disabled, CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, " & vbCrLf)
        sSQL.Append(" HealthStatus,HealthStatusU, Appearance,AppearanceU, Sex, SexName,SexNameU, FromHeight, " & vbCrLf)
        sSQL.Append(" ToHeight, FromWeight, ToWeight, FromAge, ToAge," & vbCrLf)
        sSQL.Append(" MaritalStatusID, PopulationID, ReligionID, CountryID, EducationLevelID, " & vbCrLf)
        sSQL.Append(" ProfessionalLevel,ProfessionalLevelU, LanguageLevel,LanguageLevelU, ComputingLevel,ComputingLevelU, OtherTransaction,OtherTransactionU, Experience,ExperienceU, " & vbCrLf)
        sSQL.Append(" SalaryFrom, SalaryTo, CurrencyID, InheritWorkID ")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtRecPositionID.Text) & COMMA) 'RecPositionID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtRecPositionName.Text, gbUnicode, False) & COMMA) 'RecPositionName, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtRecPositionName.Text, gbUnicode, True) & COMMA) 'RecPositionName, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtJobDescription.Text, gbUnicode, False) & COMMA) 'JobDescription, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtJobDescription.Text, gbUnicode, True) & COMMA) 'JobDescription, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtJobRequirement.Text, gbUnicode, False) & COMMA) 'JobRequirement, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtJobRequirement.Text, gbUnicode, True) & COMMA) 'JobRequirement, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA & vbCrLf) 'Note, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA & vbCrLf) 'Note, varchar[250], NULL

        sSQL.Append(SQLNumber(IIf(chkDisabled.Checked, 1, 0)) & COMMA) 'Disabled, tinyint, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()" & COMMA & vbCrLf) 'LastModifyDate, datetime, NULL

        sSQL.Append(SQLStringUnicode(txtHealthStatus.Text, gbUnicode, False) & COMMA)
        sSQL.Append(SQLStringUnicode(txtHealthStatus.Text, gbUnicode, True) & COMMA)
        sSQL.Append(SQLStringUnicode(txtAppearance.Text, gbUnicode, False) & COMMA)
        sSQL.Append(SQLStringUnicode(txtAppearance.Text, gbUnicode, True) & COMMA)
        sSQL.Append(SQLNumber(tdbcSex.Columns("Code").Text) & COMMA) 'Sex, tinyint, NOT NULL
        sSQL.Append(SQLStringUnicode(txtSexName.Text, gbUnicode, False) & COMMA)
        sSQL.Append(SQLStringUnicode(txtSexName.Text, gbUnicode, True) & COMMA)
        sSQL.Append(SQLMoney(Number(txtFromHeight.Text)) & COMMA & vbCrLf) 'FromHeight, decimal, NOT NULL

        sSQL.Append(SQLMoney(txtToHeight.Text) & COMMA) 'ToHeight, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtFromWeight.Text) & COMMA) 'FromWeight, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtToWeight.Text) & COMMA) 'ToWeight, decimal, NOT NULL
        sSQL.Append(SQLNumber(txtFromAge.Text) & COMMA) 'FromAge, smallint, NOT NULL
        sSQL.Append(SQLNumber(txtToAge.Text) & COMMA & vbCrLf) 'ToAge, smallint, NOT NULL

        sSQL.Append(SQLString(tdbcMaritalStatusID.Text) & COMMA) 'MaritalStatusID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcPopulationID.Text) & COMMA) 'PopulationID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcReligionID.Text) & COMMA) 'ReligionID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcCountryID.Text) & COMMA) 'CountryID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcEducationLevelID.Text) & COMMA & vbCrLf) 'EducationLevelID, varchar[20], NOT NULL

        sSQL.Append(SQLStringUnicode(txtProfessionalLevel.Text, gbUnicode, False) & COMMA) 'ProfessionalLevel, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtProfessionalLevel.Text, gbUnicode, True) & COMMA) 'ProfessionalLevel, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtLanguageLevel.Text, gbUnicode, False) & COMMA)
        sSQL.Append(SQLStringUnicode(txtLanguageLevel.Text, gbUnicode, True) & COMMA)
        sSQL.Append(SQLStringUnicode(txtComputingLevel.Text, gbUnicode, False) & COMMA)
        sSQL.Append(SQLStringUnicode(txtComputingLevel.Text, gbUnicode, True) & COMMA)
        sSQL.Append(SQLStringUnicode(txtOtherTransaction.Text, gbUnicode, False) & COMMA)
        sSQL.Append(SQLStringUnicode(txtOtherTransaction.Text, gbUnicode, True) & COMMA)
        sSQL.Append(SQLStringUnicode(txtExperience.Text, gbUnicode, False) & COMMA & vbCrLf) 'ExperienceYear, 
        sSQL.Append(SQLStringUnicode(txtExperience.Text, gbUnicode, True) & COMMA & vbCrLf) 'ExperienceYear, 

        sSQL.Append(SQLMoney(txtSalaryFrom.Text) & COMMA) 'SalaryFrom, money, NOT NULL
        sSQL.Append(SQLMoney(txtSalaryTo.Text) & COMMA) 'SalaryTo, money, NOT NULL
        sSQL.Append(SQLString(tdbcCurrencyID.Text) & COMMA) 'CurrencyID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcWorkID.Text))
        sSQL.Append(")" & vbCrLf)

        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T1020
    '# Created User: Lê Thị Lành
    '# Created Date: 10/10/2007 08:00:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: LuuEdit
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T1020() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T1020 Set ")
        'sSQL.Append("RecPositionID = " & SQLString(txtRecPositionID.Text) & COMMA) '[KEY], varchar[20], NOT NULL
        sSQL.Append("InheritWorkID = " & SQLString(tdbcWorkID.Text) & COMMA)
        sSQL.Append("RecPositionName = " & SQLStringUnicode(txtRecPositionName.Text, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("RecPositionNameU= " & SQLStringUnicode(txtRecPositionName.Text, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("JobDescription = " & SQLStringUnicode(txtJobDescription.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("JobDescriptionU = " & SQLStringUnicode(txtJobDescription.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("JobRequirement = " & SQLString(txtJobRequirement.Text) & COMMA) 'varchar[250], NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("Disabled = " & SQLNumber(IIf(chkDisabled.Checked, 1, 0)) & COMMA) 'tinyint, NULL
        'sSQL.Append("CreateUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        'sSQL.Append("CreateDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("Sex = " & SQLNumber(tdbcSex.Columns("Code").Text) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("SexName = " & SQLStringUnicode(txtSexName.Text, gbUnicode, False) & COMMA)
        sSQL.Append("SexNameU = " & SQLStringUnicode(txtSexName.Text, gbUnicode, True) & COMMA)
        sSQL.Append("HealthStatus = " & SQLStringUnicode(txtHealthStatus.Text, gbUnicode, False) & COMMA)
        sSQL.Append("HealthStatusU = " & SQLStringUnicode(txtHealthStatus.Text, gbUnicode, True) & COMMA)
        sSQL.Append("Appearance = " & SQLStringUnicode(txtAppearance.Text, gbUnicode, False) & COMMA)
        sSQL.Append("AppearanceU = " & SQLStringUnicode(txtAppearance.Text, gbUnicode, True) & COMMA)

        sSQL.Append("FromHeight = " & SQLMoney(txtFromHeight.Text) & COMMA) 'decimal, NOT NULL
        sSQL.Append("ToHeight = " & SQLMoney(txtToHeight.Text) & COMMA) 'decimal, NOT NULL
        sSQL.Append("FromWeight = " & SQLMoney(txtFromWeight.Text) & COMMA) 'decimal, NOT NULL
        sSQL.Append("ToWeight = " & SQLMoney(txtToWeight.Text) & COMMA) 'decimal, NOT NULL
        sSQL.Append("FromAge = " & SQLNumber(txtFromAge.Text) & COMMA) 'smallint, NOT NULL
        sSQL.Append("ToAge = " & SQLNumber(txtToAge.Text) & COMMA) 'smallint, NOT NULL
        sSQL.Append("MaritalStatusID = " & SQLString(tdbcMaritalStatusID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("PopulationID = " & SQLString(tdbcPopulationID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("ReligionID = " & SQLString(tdbcReligionID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("CountryID = " & SQLString(tdbcCountryID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("EducationLevelID = " & SQLString(tdbcEducationLevelID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("ProfessionalLevel = " & SQLStringUnicode(txtProfessionalLevel.Text, gbUnicode, False) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("ProfessionalLevelU = " & SQLStringUnicode(txtProfessionalLevel.Text, gbUnicode, True) & COMMA) 'varchar[20], NOT NULL

        sSQL.Append("ComputingLevel = " & SQLStringUnicode(txtComputingLevel.Text, gbUnicode, False) & COMMA)
        sSQL.Append("ComputingLevelU = " & SQLStringUnicode(txtComputingLevel.Text, gbUnicode, True) & COMMA)
        sSQL.Append("OtherTransaction = " & SQLStringUnicode(txtOtherTransaction.Text, gbUnicode, False) & COMMA)
        sSQL.Append("OtherTransactionU = " & SQLStringUnicode(txtOtherTransaction.Text, gbUnicode, True) & COMMA)

        sSQL.Append("LanguageLevel = " & SQLStringUnicode(txtLanguageLevel.Text, gbUnicode, False) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LanguageLevelU = " & SQLStringUnicode(txtLanguageLevel.Text, gbUnicode, True) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("Experience = " & SQLStringUnicode(txtExperience.Text, gbUnicode, False) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ExperienceU = " & SQLStringUnicode(txtExperience.Text, gbUnicode, True) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("SalaryFrom = " & SQLMoney(txtSalaryFrom.Text) & COMMA) 'money, NOT NULL
        sSQL.Append("SalaryTo = " & SQLMoney(txtSalaryTo.Text) & COMMA) 'money, NOT NULL
        sSQL.Append("CurrencyID = " & SQLString(tdbcCurrencyID.Text)) 'varchar[20], NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("RecPositionID = " & SQLString(txtRecPositionID.Text))

        Return sSQL
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd, EnumFormState.FormCopy
                sSQL.Append(SQLInsertD25T1020().ToString)

                'Lưu LastKey của Số phiếu xuống Database (gọi hàm CreateIGEVoucherNo bật cờ True)
                'Kiểm tra trùng Số phiếu (gọi hàm CheckDuplicateVoucherNo)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T1020().ToString)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True

            Select Case _FormState
                Case EnumFormState.FormAdd, EnumFormState.FormCopy
                    btnNext.Enabled = True
                    btnAttach.Enabled = True

                    btnNext.Focus()
                    _RecPositionID = txtRecPositionID.Text
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

#Region "Events tdbcMaritalStatusID with txtMaritalStatusName"

    Private Sub tdbcMaritalStatusID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMaritalStatusID.Close
        If tdbcMaritalStatusID.FindStringExact(tdbcMaritalStatusID.Text) = -1 Then
            tdbcMaritalStatusID.Text = ""
            txtMaritalStatusName.Text = ""
        End If
    End Sub

    Private Sub tdbcMaritalStatusID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMaritalStatusID.SelectedValueChanged
        txtMaritalStatusName.Text = tdbcMaritalStatusID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcMaritalStatusID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcMaritalStatusID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcMaritalStatusID.Text = ""
            txtMaritalStatusName.Text = ""
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tdbcMaritalStatusID.AutoDropDown = False
        End If
    End Sub

#End Region

#Region "Events tdbcPopulationID with txtPopulationName"

    Private Sub tdbcPopulationID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPopulationID.Close
        If tdbcPopulationID.FindStringExact(tdbcPopulationID.Text) = -1 Then
            tdbcPopulationID.Text = ""
            txtPopulationName.Text = ""
        End If
    End Sub

    Private Sub tdbcPopulationID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPopulationID.SelectedValueChanged
        txtPopulationName.Text = tdbcPopulationID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcPopulationID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPopulationID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcPopulationID.Text = ""
            txtPopulationName.Text = ""
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tdbcPopulationID.AutoDropDown = False
        End If
    End Sub

#End Region

#Region "Events tdbcSex"

    Private Sub tdbcSex_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSex.Close
        If tdbcSex.FindStringExact(tdbcSex.Text) = -1 Then tdbcSex.Text = ""
    End Sub

    Private Sub tdbcSex_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSex.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcSex.Text = ""
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tdbcSex.AutoDropDown = False
        End If
    End Sub

#End Region

#Region "Events tdbcReligionID with txtReligionName"

    Private Sub tdbcReligionID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReligionID.Close
        If tdbcReligionID.FindStringExact(tdbcReligionID.Text) = -1 Then
            tdbcReligionID.Text = ""
            txtReligionName.Text = ""
        End If
    End Sub

    Private Sub tdbcReligionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReligionID.SelectedValueChanged
        txtReligionName.Text = tdbcReligionID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcReligionID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcReligionID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcReligionID.Text = ""
            txtReligionName.Text = ""
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tdbcReligionID.AutoDropDown = False
        End If
    End Sub

#End Region

#Region "Events tdbcCountryID with txtCountryName"

    Private Sub tdbcCountryID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCountryID.Close
        If tdbcCountryID.FindStringExact(tdbcCountryID.Text) = -1 Then
            tdbcCountryID.Text = ""
            txtCountryName.Text = ""
        End If
    End Sub

    Private Sub tdbcCountryID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCountryID.SelectedValueChanged
        txtCountryName.Text = tdbcCountryID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcCountryID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcCountryID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcCountryID.Text = ""
            txtCountryName.Text = ""
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tdbcCountryID.AutoDropDown = False
        End If

    End Sub

#End Region

#Region "Events tdbcEducationLevelID with txtEducationLevelName"

    Private Sub tdbcEducationLevelID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEducationLevelID.Close
        If tdbcEducationLevelID.FindStringExact(tdbcEducationLevelID.Text) = -1 Then
            tdbcEducationLevelID.Text = ""
            txtEducationLevelName.Text = ""
        End If
    End Sub

    Private Sub tdbcEducationLevelID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEducationLevelID.SelectedValueChanged
        txtEducationLevelName.Text = tdbcEducationLevelID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcEducationLevelID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcEducationLevelID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcEducationLevelID.Text = ""
            txtEducationLevelName.Text = ""
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tdbcEducationLevelID.AutoDropDown = False
        End If
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAddNew()
    End Sub

    Private Sub txtFromAge_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFromAge.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtFromHeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFromHeight.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtFromWeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFromWeight.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtToAge_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToAge.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtToHeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToHeight.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtToWeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToWeight.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub


    Private Sub txtSalaryFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalaryFrom.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalaryTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalaryTo.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtToHeight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtToHeight.LostFocus
        txtToHeight.Text = Format(Number(txtToHeight.Text), D25Format.DefaultNumber2)
    End Sub

    Private Sub txtFromHeight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFromHeight.LostFocus
        txtFromHeight.Text = Format(Number(txtFromHeight.Text), D25Format.DefaultNumber2)
    End Sub

    Private Sub txtToWeight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtToWeight.LostFocus
        txtToWeight.Text = Format(Number(txtToWeight.Text), D25Format.DefaultNumber2)
    End Sub

    Private Sub txtFromWeight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFromWeight.LostFocus
        txtFromWeight.Text = Format(Number(txtFromWeight.Text), D25Format.DefaultNumber2)
    End Sub

    Private Sub txtFromAge_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFromAge.LostFocus
        txtFromAge.Text = Format(Number(txtFromAge.Text), D25Format.DefaultNumber0)
    End Sub

    Private Sub txtToAge_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblToAge.LostFocus
        txtToAge.Text = Format(Number(txtToAge.Text), D25Format.DefaultNumber0)
    End Sub


    Private Sub txtSalaryFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalaryFrom.LostFocus
        txtSalaryFrom.Text = Format(Number(txtSalaryFrom.Text), D25Format.DefaultNumber2)
    End Sub

    Private Sub txtSalaryTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalaryTo.LostFocus
        txtSalaryTo.Text = Format(Number(txtSalaryTo.Text), D25Format.DefaultNumber2)
    End Sub

    Private Sub btnAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttach.Click
        'Dim f As New D91F4010
        'f.FormState = _FormState
        'f.FormPermission = "D25F1020"
        'f.KeyID = txtRecPositionID.Text
        'f.TableName = "D25T1020"
        'f.ShowDialog()
        'f.Dispose()
        'btnAttach.Text = rL3("Dinh_kem") & Space(1) & "(" & ReturnAttachmentNumber("D25T1020", txtRecPositionID.Text, , , , , ) & ")"  'Đính kèm

        'ID 79397 4/9/2015
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormPermission", "D25F1020")
        SetProperties(arrPro, "TableName", "D25T1020")
        SetProperties(arrPro, "Key1ID", txtRecPositionID.Text)
        SetProperties(arrPro, "FormState", _FormState)
        'SetProperties(arrPro, "bNewDatabase", TRUE/ FALSE)'Lưu database mới ATT, không phải database hiện tại. Không dùng nữa mà theo thiết lập D91T0025
        CallFormShowDialog("D91D0340", "D91F4010", arrPro)
        btnAttach.Text = rL3("Dinh_ke_m") & Space(1) & " (" & ReturnAttachmentNumber("D25T1020", txtRecPositionID.Text) & ")" 'Đính kèm
    End Sub

#Region "Events tdbcWorkID with txtWorkName"

    Private Sub tdbcWorkID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkID.Close
        If tdbcWorkID.FindStringExact(tdbcWorkID.Text) = -1 Then
            tdbcWorkID.Text = ""
            txtWorkName.Text = ""
        End If
    End Sub

    Private Sub tdbcWorkID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkID.SelectedValueChanged
        If tdbcWorkID.Text = "" Or tdbcWorkID.SelectedValue Is Nothing Then
            txtWorkName.Text = ""
            Exit Sub
        End If

        txtWorkName.Text = tdbcWorkID.Columns(1).Value.ToString

        If _FormState = EnumFormState.FormCopy Then
            txtRecPositionID.Text = tdbcWorkID.Columns("WorkID").Text
            txtRecPositionName.Text = tdbcWorkID.Columns("WorkName").Text
        End If
    End Sub

    Private Sub tdbcWorkID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcWorkID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcWorkID.Text = ""
            txtWorkName.Text = ""
        End If
    End Sub

#End Region

    Private Sub tdbcSex_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSex.SelectedValueChanged
        If tdbcSex.Text = "" Or tdbcSex.SelectedValue Is Nothing Then
            txtSexName.Text = ""
            Exit Sub
        End If
        txtSexName.Text = tdbcSex.Columns("Description").Text
    End Sub

End Class