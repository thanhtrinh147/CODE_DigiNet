Imports System.Xml
Imports System
Imports System.IO
Imports System.Windows.Forms

Public Class D25F1051_NN

    ' Update 23/05/2011 - Chuẩn unicode theo DC25 _ TIENDAU
    Dim sOtherDep As String = ""
    Dim sOtherTeam As String = ""
    'Dim dtTeam As DataTable
    Dim dt_RecTeamID As DataTable
    Dim dtForm As DataTable
    'Sinh IGE
    Dim eOutputOrder As OutOrderEnum
    Dim sSeparator As String
    Dim bFlag As Boolean

    Dim iOutputLen As Integer
    Dim sImgFileName As String = ""

    Dim orgIGE As String
    Dim bChecked As Boolean = False

    Dim MyLocation As New Point(-315, 245)
    Dim Tab2Location As New Point(15, 10)
    'Dim MyLocation2 As New Point(15, )
    Private Const col1 As Integer = 15
    Private Const col2 As Integer = 345
    Private Const col3 As Integer = 675
    Dim arControl As New ArrayList

    Private Class MyControl
        Private _objControl As Control
        Public Property objControl() As Control
            Get
                Return _objControl
            End Get
            Set(ByVal Value As Control)
                _objControl = Value
            End Set
        End Property

        Private _sType As String
        Public Property sType() As String
            Get
                Return _sType
            End Get
            Set(ByVal Value As String)
                _sType = Value
            End Set
        End Property

        Private _sFieldName As String
        Public Property sFieldName() As String
            Get
                Return _sFieldName
            End Get
            Set(ByVal Value As String)
                _sFieldName = Value
            End Set
        End Property

        Private _sFieldNameU As String
        Public Property sFieldNameU() As String
            Get
                Return _sFieldNameU
            End Get
            Set(ByVal Value As String)
                _sFieldNameU = Value
            End Set
        End Property

        Private _sSaveType As String
        Public Property sSaveType() As String
            Get
                Return _sSaveType
            End Get
            Set(ByVal Value As String)
                _sSaveType = Value
            End Set
        End Property
    End Class

    Private _divisionID As String = ""
    Public WriteOnly Property DivisionID() As String
        Set(ByVal Value As String)
            _divisionID = Value
            If _divisionID = "" Then _divisionID = gsDivisionID
        End Set
    End Property

    Private _employeeID As String
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private _candidateID As String
    Public Property CandidateID() As String
        Get
            Return _candidateID
        End Get
        Set(ByVal Value As String)
            _candidateID = Value
        End Set
    End Property
    Private _nativePlace As String
    Public Property NativePlace() As String
        Get
            Return _nativePlace
        End Get
        Set(ByVal Value As String)
            _nativePlace = Value
        End Set
    End Property

    Private _longBusinessTrip As String
    Public Property LongBusinessTrip() As String
        Get
            Return _longBusinessTrip
        End Get
        Set(ByVal Value As String)
            _longBusinessTrip = Value
        End Set
    End Property

    Private _transferedD09 As String
    Public Property TransferedD09() As String
        Get
            Return _transferedD09
        End Get
        Set(ByVal Value As String)
            _transferedD09 = Value
        End Set
    End Property

    Private _parentFrm As String
    Public WriteOnly Property ParentFrm() As String
        Set(ByVal Value As String)
            _parentFrm = Value
        End Set
    End Property

    Private _moduleID As String = "25"
    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            _moduleID = Value
        End Set
    End Property

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _divisionIDValue As String
    Public WriteOnly Property DivisionIDValue() As String
        Set(ByVal Value As String)
            _divisionIDValue = Value
        End Set
    End Property

    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
            tdbcRecDepartmentID.Tag = ""
            clsCheckValid = New Lemon3.Controls.CheckEmptyControl(Panel1, "D25F1051") 'Set màu control vừa thêm
            AutoAddControls()
            LoadTDBCombo()
            VisibleControl() 'IncidentID	50891
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = False
                    LoadAddNew()

                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnRelationship.Enabled = ReturnPermission("D25F1050") >= 2
                    LoadEdit()
                    ReadOnlyControl(txtCandidateID, tdbcMethodID)

                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
                    btnRelationship.Enabled = False
                    LoadEdit()
                    ReadOnlyControl(txtCandidateID, tdbcMethodID)

            End Select
        End Set
    End Property

    Private Sub VisibleControl()
        If D25Systems.AutoCandidateID Then
            If _FormState = EnumFormState.FormAdd Then ReadOnlyControl(txtCandidateID)
        Else
            tdbcMethodID.Visible = False
            txtCandidateID.Location = tdbcMethodID.Location
            txtCandidateID.Width = txtLastName.Width
            lblMethodID.Visible = False
            lblCandidateID.Location = lblMethodID.Location
        End If

        'IncidentID	50891  Bổ sung theo yêu cầu của BAOTRAN
        If _FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormView Then
            tdbcMethodID.Visible = False
            txtCandidateID.Location = tdbcMethodID.Location
            txtCandidateID.Width = txtLastName.Width
            lblMethodID.Visible = False
            lblCandidateID.Location = lblMethodID.Location
        End If
    End Sub

    Private Sub D25F1051_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            If TypeOf (Me.ActiveControl) Is TextBox AndAlso CType(Me.ActiveControl, TextBox).Multiline = True Then
            Else
                UseEnterAsTab(Me)
            End If
        ElseIf e.Alt And (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
            TabMain.SelectedTab = TabPage1
            tabMain_Click(Nothing, Nothing)
        ElseIf e.Alt And (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
            TabMain.SelectedTab = TabPage2
        End If
    End Sub

    Dim clsCheckValid As Lemon3.Controls.CheckEmptyControl
    Private Sub D25F1051_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        If _divisionID = "" Then _divisionID = gsDivisionID
        _bSaved = False
        SetBackColorObligatory()
        Loadlanguage()
        TabMain.Focus()
        TabMain.SelectedTab = TabPage1
        tabMain_Click(Nothing, Nothing)    'IncidentID	50891 Bổ sung
        InputbyUnicode(Me, gbUnicode)
        tdbcMethodID.AutoCompletion = False   'IncidentID	50891 Bổ sung
        CheckIdTextBox(txtCandidateID)
        ' SetResolutionForm(Me)
        'AutoAddControls()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_danh_muc_ung_cu_vien_-_D25F1051") & UnicodeCaption(gbUnicode) 'CËp nhËt danh móc ÷ng cõ vi£n - D25F1051
        '================================================================ 

        lblteBirthDate.Text = rl3("Ngay_sinh") 'Ngày sinh
        lblEthnicID.Text = rl3("Dan_toc") 'Dân tộc
        lblBirthPlace.Text = rl3("Noi_sinh") 'Nơi sinh
        lblCountryName.Text = rl3("Quoc_tich") 'Quốc tịch
        lblReligionName.Text = rl3("Ton_giao") 'Tôn giáo
        lblLastName.Text = rl3("Ho_va_ten") 'Họ và tên
        lblIDCardNo.Text = rl3("So_CMND") 'Số CMND
        lblteIDCardDate.Text = rl3("Ngay_cap") 'Ngày cấp
        'IncidentID	50891 Bổ sung
        lblCandidateID.Text = rl3("Ma_ung_cu_vien") 'Mã ứng cử viên
        lblMethodID.Text = rl3("Phuong_phap_tao_ma_tu_dong") 'Phương pháp tạo mã tự động
        '================================================================ 
        btnQTDT.Text = rl3("_Qua_trinh_dao_tao") '&Quá trình đào tạo
        btnKNLV.Text = rl3("_Kinh_nghiep_lam_viec") '&Kinh nghiệp làm việc
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnRelationship.Text = rl3("Quan_he__gia_dinh") 'Quan hệ &gia đình
        '================================================================ 
        chkLongBusinesstrip.Text = rl3("Chap_nhan_di_cong_tac_xa") 'Chấp nhận đi công tác xa
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        optGirl.Text = rl3("Nu_U") 'Nữ
        optBoy.Text = rl3("NamV") 'Nam
        '================================================================ 
        grpsex.Text = rl3("Gioi_tinh") 'Giới tính
        '================================================================ 
        TabPage1.Text = "1. " & rl3("Ca_nhan") ' rl3("1_Ca_nhan") '1. Cá nhân 
        TabPage2.Text = "2. " & rl3("Ky_nang")

        tdbcReligionName.Columns("ReligionID").Caption = rl3("Ma") 'Mã
        tdbcReligionName.Columns("ReligionName").Caption = rl3("Ten") 'Tên
        tdbcNationalityID.Columns("NationalityID").Caption = rl3("Ma") 'Mã
        tdbcNationalityID.Columns("CountryName").Caption = rl3("Ten") 'Tên
        tdbcEthnicID.Columns("EthnicID").Caption = rl3("Ma") 'Mã
        tdbcEthnicID.Columns("EthnicName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        lblZoneName.Text = rL3("Noi_cap") 'Nơi cấp
        tdbcZoneName.Columns("ZoneCode").Caption = rL3("Ma") 'Mã
        tdbcZoneName.Columns("ZoneName").Caption = rL3("Ten") 'Tên



    End Sub

    Private Sub LoadAddNew()

        btnEnclourse.Text = rl3("Dinh_ke_m") 'Đính kè&m

        EnableButton(False)

        SetNew()
        If _parentFrm = "D25F1055" Then

            Dim dt As DataTable = ReturnDataTable(SQLStoreD25P1055)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                txtLastName.Text = dr("LastName").ToString
                txtMiddleName.Text = dr("Middlename").ToString
                txtFirstName.Text = dr("FirstName").ToString
                If dr("Sex").ToString = "0" Then
                    optBoy.Checked = True
                Else
                    optGirl.Checked = True
                End If
                c1dateBirthDate.Value = SQLDateShow(dr("BirthDate").ToString)
                txtBirthPlace.Text = dr("BirthPlace").ToString
                tdbcEthnicID.SelectedValue = dr("EthnicID").ToString
                tdbcReligionName.SelectedValue = dr("ReligionID").ToString
                txtIDCardNo.Text = dr("IDCardNo").ToString
                tdbcNationalityID.SelectedValue = dr("NationalityID").ToString
                c1dateIDCardDate.Value = dr("IDCardDate").ToString
                'txtIDCardPlace.Text = dr("IDCardPlace").ToString
                tdbcZoneName.SelectedValue = dr("IDCardPlaceID").ToString


            End If

        End If
        bFlag = True
    End Sub

    Private Sub SetNew()
        txtCandidateID.Text = ""   'IncidentID	50891
        txtLastName.Text = ""
        txtMiddleName.Text = ""
        txtFirstName.Text = ""
        optBoy.Checked = True
        c1dateBirthDate.Value = ""
        txtBirthPlace.Text = ""
        'tdbcEthnicID.SelectedValue = ""
        'tdbcReligionName.SelectedValue = ""
        txtIDCardNo.Text = ""
        'tdbcNationalityID.SelectedValue = ""
        c1dateIDCardDate.Value = ""
        'txtIDCardPlace.Text = ""
        txtNumday.Text = ""
        txtNumMonth.Text = ""
        txtNumYear.Text = ""
        'Mặc định Dân tộc Kinh, Tôn giáo không, Quốc tịch Việt Nam
        Dim MatchIndex As Integer
        MatchIndex = tdbcEthnicID.FindString("KINH")
        If MatchIndex <> -1 Then
            tdbcEthnicID.SelectedIndex = MatchIndex
        Else
            tdbcEthnicID.SelectedValue = ""
        End If

        MatchIndex = tdbcReligionName.FindString("KHOÂNG")
        If MatchIndex <> -1 Then
            tdbcReligionName.SelectedIndex = MatchIndex
        Else
            tdbcReligionName.SelectedValue = ""
        End If

        MatchIndex = tdbcNationalityID.FindString("VIEÄT NAM")
        If MatchIndex <> -1 Then
            tdbcNationalityID.SelectedIndex = MatchIndex
        Else
            tdbcNationalityID.SelectedValue = ""
        End If

        chkLongBusinesstrip.Checked = False

        If tdbcRecDepartmentID.Tag.ToString = "Visible" Then LoadOtherTdbcTeamID("-1")

        picCandidate.Image = Nothing
        lblGetPhoto.Visible = True
        lblGetPhoto2.Visible = True
        sImgFileName = ""
    End Sub

    Private Sub EnableButton(ByVal bEnable As Boolean)
        btnQTDT.Enabled = bEnable
        btnKNLV.Enabled = bEnable
        btnEnclourse.Enabled = bEnable
        btnRelationship.Enabled = bEnable And ReturnPermission("D25F1050") >= 2
    End Sub

    Private Sub LoadEdit()
        btnNext.Visible = False
        btnSave.Left = btnNext.Left

        LoadEditData()
        btnEnclourse.Text = rl3("Dinh_ke_m") & Space(1) & "(" & ReturnAttachmentNumber("D25T1041", txtCandidateID.Text) & ")"
    End Sub

    Private Sub LoadEditData()
        Dim sImage As String = ""
        Dim dt As DataTable
        Dim sSQL As String = ""
        sSQL = SQLStoreD25P1051()
        dt = ReturnDataTable(sSQL)

        If dt.Rows.Count <= 0 Then Exit Sub
        Dim dr As DataRow = dt.Rows(0)
        'Tab1
        txtCandidateID.Text = dt.Rows(0).Item("CandidateID").ToString
        txtLastName.Text = dt.Rows(0).Item("LastName").ToString
        txtMiddleName.Text = dt.Rows(0).Item("MiddleName").ToString
        txtFirstName.Text = dt.Rows(0).Item("FirstName").ToString

        If dt.Rows(0).Item("Sex").ToString = "0" Then
            optBoy.Checked = True
        Else
            optGirl.Checked = True
        End If
        c1dateBirthDate.Value = SQLDateShow(dt.Rows(0).Item("BirthDate").ToString)
        txtBirthPlace.Text = dt.Rows(0).Item("BirthPlace").ToString
        tdbcEthnicID.SelectedValue = dt.Rows(0).Item("EthnicID").ToString
        tdbcReligionName.SelectedValue = dt.Rows(0).Item("ReligionID").ToString
        txtIDCardNo.Text = dt.Rows(0).Item("IDCardNo").ToString
        tdbcNationalityID.SelectedValue = dt.Rows(0).Item("NationalityID").ToString
        c1dateIDCardDate.Value = dt.Rows(0).Item("IDCardDate").ToString
        'txtIDCardPlace.Text = dt.Rows(0).Item("IDCardPlace").ToString
        tdbcZoneName.SelectedValue = dt.Rows(0).Item("IDCardPlaceID").ToString
        '****************
        If c1dateBirthDate.Text <> "" Then
            Dim d As Date
            d = CDate(c1dateBirthDate.Text)

            If Number(dt.Rows(0).Item("UnDefinedBD")) = 0 Then 'Load ngay,thang,nam
                txtNumday.Text = d.Day.ToString
                txtNumMonth.Text = d.Month.ToString
                txtNumYear.Text = d.Year.ToString
            ElseIf Number(dt.Rows(0).Item("UnDefinedBD")) = 1 Then 'Chi load nam
                txtNumYear.Text = d.Year.ToString
                txtNumday.Text = ""
                txtNumMonth.Text = ""
            ElseIf Number(dt.Rows(0).Item("UnDefinedBD")) = 2 Then 'Chi load thang,nam
                txtNumMonth.Text = d.Month.ToString
                txtNumYear.Text = d.Year.ToString
                txtNumday.Text = ""
            End If
        Else
            txtNumday.Text = ""
            txtNumMonth.Text = ""
            txtNumYear.Text = ""
        End If
        '*********************
        chkDisabled.Checked = Convert.ToBoolean(Number(dt.Rows(0).Item("Disabled")))

        For i As Integer = 0 To arControl.Count - 1
            Dim x As MyControl = CType(arControl(i), MyControl)
            For Each dc As DataColumn In dt.Columns
                'If dc.ColumnName.Equals(IIf(gbUnicode, x.sFieldNameU, x.sFieldName)) Then
                If dc.ColumnName.Equals(x.sFieldName) Then
                    If dc.ColumnName = "RecDepartmentID" Then
                        sOtherDep = dr(dc).ToString
                    ElseIf dc.ColumnName = "RecTeamID" Then
                        sOtherTeam = dr(dc).ToString
                    End If


                    Select Case x.sType
                        Case "Ref"
                            Dim txt As TextBox = CType(x.objControl, TextBox)
                            txt.Text = dr(dc).ToString
                            If txt.TextAlign = HorizontalAlignment.Right Then
                                txt.Text = Format(Number(txt.Text), D25Format.DefaultNumber2)
                            Else
                                txt.Font = FontUnicode(gbUnicode, txt.Font.Style)
                            End If

                        Case "Cmb"

                            Dim cmb As C1.Win.C1List.C1Combo = CType(x.objControl, C1.Win.C1List.C1Combo)
                            ' sOtherDep = dr(dc).ToString
                            Select Case x.sSaveType
                                Case "0"
                                    cmb.SelectedValue = dr(dc)

                                Case "1"
                                    cmb.Text = dr(dc).ToString

                                Case "2"

                                    If dr(dc).ToString = "True" Then
                                        cmb.SelectedValue = 1
                                    ElseIf dr(dc).ToString = "False" Then
                                        cmb.SelectedValue = 0
                                    Else
                                        cmb.SelectedValue = dr(dc)
                                    End If
                            End Select

                        Case "Dtp"
                            CType(x.objControl, C1.Win.C1Input.C1DateEdit).Value = SQLDateShow(dr(dc))

                    End Select
                End If
            Next
        Next i

        tdbcRecDepartmentID.SelectedValue = sOtherDep
        'If tdbcOtherDepartmentID.Tag.ToString <> "Visible" Then
        LoadOtherTdbcTeamID(ReturnValueC1Combo(tdbcRecDepartmentID)) 'LoadDataSource(tdbcOtherTeamID, dt_RecTeamID.Copy, gbUnicode)
        tdbcRecTeamID.SelectedValue = sOtherTeam
        picCandidate.Image = ReturnImage(dt.Rows(0).Item("ImageID"))
        If picCandidate.Image IsNot Nothing Then
            lblGetPhoto.Visible = False
            lblGetPhoto2.Visible = False
        End If
        sImgFileName = "Original"

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1051
    '# Created User: Phan Văn Thông
    '# Created Date: 06/09/2012 03:10:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1051() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho form " & vbCrLf)
        sSQL &= "Exec D25P1051 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(CandidateID) & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber("1") 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub SetBackColorObligatory()
        txtCandidateID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtLastName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtFirstName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMethodID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function AllowSave() As Boolean
        TabMain.SelectedTab = TabPage1

        'IncidentID	50891
        '-------Sinh mã tự động cho ứng cử viên - chỉ thực hiện khi thêm mới và có check sinh mã tự động ở thiết lập hệ thống
        If tdbcMethodID.Visible And _FormState = EnumFormState.FormAdd Then

            If tdbcMethodID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Phuong_phap_tao_ma_tu_dong"))
                tdbcMethodID.Focus()
                Return False
            End If

            Dim sSQL As String = ""
            sSQL = SQLDeleteD09T6666.ToString & vbCrLf
            sSQL &= SQLInsertD09T6666.ToString & vbCrLf
            sSQL &= SQLStoreD09P2016.ToString & vbCrLf
            Dim sGetCandidateID As String = ""
            If Not CheckMyStore(sSQL, sGetCandidateID) Then
                tdbcMethodID.Focus()
                Return False
            Else
                txtCandidateID.Text = sGetCandidateID
            End If

        End If
        '--------Giá trị sinh ra được gắn vào text mã ứng cử viên, thực hiện các bước tiếp theo như bình thường

        If txtCandidateID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            TabMain.SelectedTab = TabPage1
            txtCandidateID.Focus()
            Return False
        End If
        If txtLastName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ho_va_ten"))
            TabMain.SelectedTab = TabPage1
            txtLastName.Focus()
            Return False
        End If
        If txtFirstName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ho_va_ten"))
            TabMain.SelectedTab = TabPage1
            txtFirstName.Focus()
            Return False
        End If
        'Kiem tra ngay sinh
        If txtNumday.Text <> "" Then
            If txtNumMonth.Text = "" Then
                TabMain.SelectedTab = TabPage1
                D99C0008.MsgL3(rl3("MSG000009"))
                txtNumMonth.Focus()
                Return False
            Else
                If txtNumYear.Text = "" Then
                    TabMain.SelectedTab = TabPage1
                    D99C0008.MsgL3(rl3("MSG000009"))
                    txtNumYear.Focus()
                    Return False
                End If
            End If
        End If
        If txtNumMonth.Text <> "" Then
            If txtNumYear.Text = "" Then
                TabMain.SelectedTab = TabPage1
                D99C0008.MsgL3(rl3("MSG000009"))
                txtNumYear.Focus()
                Return False
            End If
        End If
        '*************
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D25T1041", "CandidateID", txtCandidateID.Text) Then
                D99C0008.MsgDuplicatePKey()
                TabMain.SelectedTab = TabPage1
                txtCandidateID.Focus()
                Return False
            End If
        End If
        If txtIDCardNo.Text <> "" Then
            If txtIDCardNo.Text.Length <> 9 And txtIDCardNo.Text.Length <> 12 Then
                D99C0008.MsgL3(rl3("So_CMND_chua_hop_le"))
                txtIDCardNo.Focus()
                Return False
            End If
        End If
        '        'If Not CheckStore(SQLStoreD25P5555(Me.Name, txtIDCardNo.Text, ""), True) Then
        '        '    TabMain.SelectedTab = TabPage1
        '        '    txtIDCardNo.Focus()
        '        '    Return False
        '        'End If
        '        'Dim Ctrl1 As New usrctrlCombo
        '        'TabPage1.Controls.Add(Ctrl1)
        '        ' For Each ctr1 As Control In TabPage1.Controls
        If Not clsCheckValid.CheckEmpty() Then Return False

        For Each ctr1 As Control In Panel1.Controls
            If Not TypeOf (ctr1) Is usrctrlCombo OrElse ctr1.Visible = False Then Continue For
            Dim cmb1 As C1.Win.C1List.C1Combo = CType(ctr1.Controls.Item(0), C1.Win.C1List.C1Combo)
            If cmb1.EditorBackColor = COLOR_BACKCOLOROBLIGATORY And cmb1.Text = "" Then
                If cmb1.Text = "" Then
                    Dim lbl As Label = CType(ctr1.Controls.Item(1), Label)
                    TabMain.SelectedTab = TabPage1
                    D99C0008.MsgNotYetEnter(lbl.Text)
                    cmb1.Focus()
                    ctr1.Focus()
                    Return False
                End If
            End If
            If cmb1.EditorBackColor = COLOR_BACKCOLORWARNING And cmb1.Text = "" Then
                If L3Bool(ctr1.Tag) Then Continue For
                If cmb1.Text = "" Then
                    Dim lbl As Label = CType(ctr1.Controls.Item(1), Label)
                    If D99C0008.MsgAsk(rL3("Ban_chua_nhap") & Space(1) & lbl.Text & ". " & rL3("MSG000021")) = Windows.Forms.DialogResult.No Then
                        TabMain.SelectedTab = TabPage1
                        cmb1.Focus()
                        ctr1.Focus()
                        Return False
                    Else
                        ctr1.Tag = True
                    End If
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Kiểm tra dữ liệu bằng Store
    ''' </summary>
    ''' <param name="SQL">Store cần kiểm tra</param>
    ''' <returns>Trả về True nếu kiểm tra không có lỗi, ngược lại trả về False</returns>
    ''' <remarks>Chú ý: Kết quả trả ra của Store phải có dạng là 1 hàng và 2 cột là Status và Message</remarks>
    Private Function CheckMyStore(ByVal SQL As String, ByRef Status As String, Optional ByVal bMsgAsk As Boolean = False) As Boolean
        'Update 11/10/2010: sửa lại hàm checkstore có trả ra field FontMessage
        'Cách kiểm tra của hàm CheckStore này sẽ như sau:
        'Nếu store trả ra Status <> 0 thì xuất Message theo dạng FontMessage
        'Nếu đối số thứ 2 không truyền vào có nghĩa là False thì xuất Message chỉ có 1 nút Ok
        'Nếu đối số thứ 2 có truyền vào có nghĩa là True thì xuất Message có 2 nút Yes, No

        Dim dt As New DataTable
        Dim sMsg As String
        dt = ReturnDataTable(SQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString = "0" Then
                Status = dt.Rows(0).Item("CandidateID").ToString
                dt = Nothing
                Return True
            End If

            sMsg = dt.Rows(0).Item("Message").ToString
            Dim bFontMessage As Boolean = False
            If dt.Columns.Contains("FontMessage") Then bFontMessage = True

            If Not bMsgAsk Then 'OKOnly
                If Not bFontMessage Then
                    MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Case "1" 'Unicode
                            D99C0008.MsgL3(sMsg, L3MessageBoxIcon.Exclamation)
                        Case "2" 'Convert Vni To Unicode
                            D99C0008.MsgL3(ConvertVniToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
                    End Select
                End If
                dt = Nothing
                Return False
            Else 'YesNo
                If Not bFontMessage Then
                    If MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        dt = Nothing
                        Return True
                    Else
                        dt = Nothing
                        Return False
                    End If
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            If MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "1" 'Unicode
                            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "2" 'Convert Vni To Unicode
                            If D99C0008.MsgAsk(ConvertVniToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                    End Select
                End If
            End If
            dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return False
        End If
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Phan Văn Thông
    '# Created Date: 27/08/2012 03:06:39
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL = "DELETE From D09T6666" & vbCrLf
        sSQL &= "WHERE UserID =" & SQLString(gsUserID) & vbCrLf
        sSQL &= "AND HostID = " & SQLString(My.Computer.Name) & vbCrLf
        sSQL &= "AND FormID = " & SQLString("D25F1051")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Phan Văn Thông
    '# Created Date: 27/08/2012 03:11:48
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, Str01, Str02, Str03, Str04, Str05, Num01 , FormID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        'IncidentID	50891  Bổ sung theo yêu cầu của BAOTRAN
        If gbUnicode Then
            sSQL.Append(SQLStringUnicode(txtLastName.Text, gbUnicode, True) & COMMA) 'Str01, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(txtMiddleName.Text, gbUnicode, True) & COMMA) 'Str02, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(txtFirstName.Text, gbUnicode, True) & COMMA) 'Str03, nvarchar[500], NOT NULL
        Else
            sSQL.Append(SQLStringUnicode(txtLastName.Text, gbUnicode, False) & COMMA) 'Str01, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(txtMiddleName.Text, gbUnicode, False) & COMMA) 'Str02, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(txtFirstName.Text, gbUnicode, False) & COMMA) 'Str03, nvarchar[500], NOT NULL
        End If
        sSQL.Append(SQLStringUnicode("", gbUnicode, True) & COMMA) 'Str04, nvarchar[500], NOT NULL
        sSQL.Append(SQLStringUnicode("", gbUnicode, True) & COMMA) 'Str05, nvarchar[500], NOT NULL
        sSQL.Append(SQLMoney("1") & COMMA) 'Num01, decimal, NOT NULL
        sSQL.Append(SQLString("D25F1051")) 'FormID, varchar[20], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P2016
    '# Created User: Phan Văn Thông
    '# Created Date: 27/08/2012 03:28:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P2016() As String
        Dim sSQL As String = ""
        sSQL &= ("--Sinh ma tu dong" & vbCrLf)
        sSQL &= "Exec D09P2016 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcMethodID.SelectedValue.ToString) & COMMA 'MethodID, varchar[50], NOT NULL
        sSQL &= SQLNumber("3") & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(_moduleID) 'ModuleID, tinyint, NOT NULL
        Return sSQL
    End Function

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLStoreD25P5555
    ''# Created User: Nguyễn Thị Ánh
    ''# Created Date: 29/02/2012 04:50:54
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: Kiểm tra trước khi lưu
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD25P5555() As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D25P5555 "
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
    '    sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
    '    sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
    '    sSQL &= SQLString(txtIDCardNo.Text) & COMMA 'Key01ID, varchar[20], NOT NULL
    '    sSQL &= SQLString("") & COMMA 'key02ID, varchar[20], NOT NULL
    '    sSQL &= SQLString("") & COMMA 'key03ID, varchar[20], NOT NULL
    '    sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
    '    sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
    '    sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
    '    sSQL &= SQLNumber(0) & COMMA 'Type, tinyint, NOT NULL
    '    sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
    '    Return sSQL
    'End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcEthnicID
        sSQL = "Select EthnicID, EthnicName" & UnicodeJoin(gbUnicode) & " as EthnicName From D09T0203 WITH(NOLOCK)  Where Disabled = 0 Order By EthnicID"
        LoadDataSource(tdbcEthnicID, sSQL, gbUnicode)
        'Load tdbcReligionName
        sSQL = "Select ReligionID, ReligionName" & UnicodeJoin(gbUnicode) & " as ReligionName From D09T0204 WITH(NOLOCK)  Where Disabled = 0 Order By ReligionID"
        LoadDataSource(tdbcReligionName, sSQL, gbUnicode)
        'Load tdbcCountryName
        sSQL = "Select CountryID as NationalityID, CountryName" & UnicodeJoin(gbUnicode) & " as  CountryName From D91T0017  WITH(NOLOCK) Where Disabled = 0 Order By CountryID"
        LoadDataSource(tdbcNationalityID, sSQL, gbUnicode)

        'LoadtdbcRecTeamID("-1")
        sSQL = "Select T1.TeamID, T1.TeamName" & UnicodeJoin(gbUnicode) & " as TeamName, T1.DepartmentID " & vbCrLf
        sSQL &= "From D09T0227 T1 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Inner join D91T0012 T2  WITH(NOLOCK) On T2.DepartmentID=T1.DepartmentID" & vbCrLf
        sSQL &= "Where DivisionID = " & SQLString(_divisionID)
        sSQL &= " AND T1.Disabled = 0 Order by T1.DepartmentID,T1.TeamID "
        dt_RecTeamID = ReturnDataTable(sSQL)

        'Load tdbcMethodID   IncidentID	50891
        sSQL = "SELECT MethodID, MethodName" & UnicodeJoin(gbUnicode) & " AS MethodName, IsDefault " & vbCrLf
        sSQL &= "FROM D09T1600 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0" & vbCrLf
        sSQL &= "AND TypeCode = 50" & vbCrLf
        sSQL &= "AND (DivisionID =" & SQLString(_divisionID) & " Or DivisionID = '') " & vbCrLf
        sSQL &= "ORDER BY MethodName"
        LoadDataSource(tdbcMethodID, sSQL, gbUnicode)
        Dim dr() As DataRow = CType(tdbcMethodID.DataSource, DataTable).Select("IsDefault=1")
        If dr.Length > 0 Then tdbcMethodID.Text = dr(0).Item("MethodName").ToString

        btnClose.Text = rL3("Them_moiU")

        'id 76241 8/6/2015
        'LoadZoneName
        sSQL = " SELECT ZoneCode, ZoneName" & UnicodeJoin(gbUnicode) & " AS ZoneName"
        sSQL &= " FROM D91T1620  WITH(NOLOCK) "
        sSQL &= "WHERE ZoneLevelID = 'TINH/THANH' AND  Disabled = 0"
        sSQL &= "ORDER BY ZoneName"
        LoadDataSource(tdbcZoneName, sSQL, gbUnicode)

    End Sub

#Region "Events tdbcEthnicID"

    Private Sub tdbcEthnicID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEthnicID.Close
        If tdbcEthnicID.FindStringExact(tdbcEthnicID.Text) = -1 Then tdbcEthnicID.Text = ""
    End Sub

    Private Sub tdbcEthnicID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcEthnicID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcEthnicID.Text = ""
    End Sub

#End Region

#Region "Events tdbcReligionName"

    Private Sub tdbcReligionName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReligionName.LostFocus
        If tdbcReligionName.FindStringExact(tdbcReligionName.Text) = -1 Then tdbcReligionName.Text = ""
    End Sub
#End Region

#Region "Events tdbcCountryName"

    Private Sub tdbcCountryName_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcNationalityID.Close
        If tdbcNationalityID.FindStringExact(tdbcNationalityID.Text) = -1 Then tdbcNationalityID.Text = ""
    End Sub

    Private Sub tdbcCountryName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcNationalityID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcNationalityID.Text = ""

    End Sub

#End Region

#Region "Events tdbcMethodID"
    Private Sub tdbcMethodID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMethodID.LostFocus
        If tdbcMethodID.FindStringExact(tdbcMethodID.Text) = -1 Then tdbcMethodID.Text = ""
    End Sub
#End Region

    Private Function SQLInsertD25T1041(ByVal UndefinedBD As Integer) As StringBuilder
        Dim sSQL As New StringBuilder

        sSQL.Append("Insert Into D25T1041(")
        sSQL.Append("  CandidateID, LastName,LastNameU, MiddleName,MiddleNameU,  " & vbCrLf)
        sSQL.Append(" FirstName,FirstNameU, CandidateName,CandidateNameU, Sex, UndefinedBD, BirthDate, BirthPlace,BirthPlaceU, " & vbCrLf)
        sSQL.Append(" EthnicID, ReligionID, NationalityID, IDCardNo, IDCardDate, " & vbCrLf)
        sSQL.Append(" IDCardPlaceID, LongBusinesstrip, TransferedD09 " & vbCrLf)

        For i As Integer = 0 To arControl.Count - 1
            Dim x As MyControl = CType(arControl(i), MyControl)
            ' Nếu trường sFieldName bằng rỗng thì không làm tiếp
            If Not String.IsNullOrEmpty(x.sFieldName) Then sSQL.Append(COMMA & x.sFieldName)
            If Not x.sFieldNameU.Equals(x.sFieldName) And Not String.IsNullOrEmpty(x.sFieldNameU) Then sSQL.Append(COMMA & x.sFieldNameU)
        Next
        sSQL.Append(" ,CreateUserID, CreateDate, LastModifyUserID, lastModifyDate " & vbCrLf)
        sSQL.Append(") Values(")

        'sSQL.Append(SQLString(_divisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(txtCandidateID.Text) & COMMA) 'CandidateID [KEY], varchar[20], NOT NULL
        'sSQL.Append(SQLNumber(IIf(chkDisabled.Checked, 1, 0).ToString) & COMMA) 'Disabled, tinyint, NULL
        sSQL.Append(SQLStringUnicode(txtLastName.Text, gbUnicode, False) & COMMA) 'LastName, varchar[30], NOT NULL
        sSQL.Append(SQLStringUnicode(txtLastName.Text, gbUnicode, True) & COMMA) 'LastName, varchar[30], NOT NULL
        sSQL.Append(SQLStringUnicode(txtMiddleName.Text, gbUnicode, False) & COMMA & vbCrLf) 'MiddleName, varchar[60], NOT NULL
        sSQL.Append(SQLStringUnicode(txtMiddleName.Text, gbUnicode, True) & COMMA & vbCrLf) 'MiddleName, varchar[60], NOT NULL
        sSQL.Append(SQLStringUnicode(txtFirstName.Text, gbUnicode, False) & COMMA) 'FirstName, varchar[30], NOT NULL
        sSQL.Append(SQLStringUnicode(txtFirstName.Text, gbUnicode, True) & COMMA) 'FirstName, varchar[30], NOT NULL
        '******************************
        If txtMiddleName.Text <> "" Then 'ID 84207 26/01/2016
            sSQL.Append("isnull(" & SQLStringUnicode(txtLastName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtMiddleName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, False) & ",'') " & COMMA) 'CandidateName, varchar[50], NULL
            sSQL.Append("isnull(" & SQLStringUnicode(txtLastName, True) & ",'') + ' ' +	isnull(" & SQLStringUnicode(txtMiddleName, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, True) & ",'') " & COMMA) 'CandidateNameU, varchar[50], NULL
        Else
            sSQL.Append("isnull(" & SQLStringUnicode(txtLastName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, False) & ",'') " & COMMA) 'CandidateName, varchar[50], NULL
            sSQL.Append("isnull(" & SQLStringUnicode(txtLastName, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, True) & ",'') " & COMMA) 'CandidateNameU, varchar[50], NULL
        End If
        '******************************
        sSQL.Append(SQLNumber(IIf(optBoy.Checked, "0", "1").ToString) & COMMA) 'Sex, tinyint, NULL
        sSQL.Append(SQLNumber(UndefinedBD) & COMMA)
        sSQL.Append(SQLDateSave(c1dateBirthDate.Value) & COMMA) 'BirthDate, datetime, NULL
        sSQL.Append(SQLStringUnicode(txtBirthPlace.Text, gbUnicode, False) & COMMA & vbCrLf) 'BirthPlace, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtBirthPlace.Text, gbUnicode, True) & COMMA & vbCrLf) 'BirthPlace, varchar[250], NULL
        sSQL.Append(SQLString(tdbcEthnicID.Columns("EthnicID").Text) & COMMA) 'EthnicID, varchar[20], NULL
        sSQL.Append(SQLString(tdbcReligionName.Columns("ReligionID").Text) & COMMA) 'ReligionID, varchar[20], NULL
        sSQL.Append(SQLString(tdbcNationalityID.Columns("NationalityID").Text) & COMMA) 'NationalityID, varchar[20], NULL
        sSQL.Append(SQLString(txtIDCardNo.Text) & COMMA) 'IDCardNo, varchar[20], NULL
        sSQL.Append(SQLDateSave(c1dateIDCardDate.Value) & COMMA & vbCrLf) 'IDCardDate, datetime, NULL

        'sSQL.Append(SQLStringUnicode(txtIDCardPlace.Text, gbUnicode, False) & COMMA) 'IDCardPlace, varchar[250], NOT NULL
        'sSQL.Append(SQLStringUnicode(txtIDCardPlace.Text, gbUnicode, True) & COMMA) 'IDCardPlace, varchar[250], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcZoneName)) & COMMA) 'IDCardPlace, varchar[250], NOT NULL
        sSQL.Append(SQLString(IIf(chkLongBusinesstrip.Checked, "1", "0").ToString) & COMMA) 'LongBusinesstrip, varchar[20], NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'TransferedD09, tinyint, NOT NULL


        For i As Integer = 0 To arControl.Count - 1
            Dim x As MyControl = CType(arControl(i), MyControl)

            Select Case x.sType
                Case "Ref"
                    If CType(x.objControl, TextBox).TextAlign = HorizontalAlignment.Right Then
                        sSQL.Append(SQLNumber(x.objControl.Text) & COMMA)
                    Else

                        If x.sFieldNameU.Equals(x.sFieldName) Then
                            sSQL.Append(SQLString(x.objControl.Text) & COMMA)
                        Else
                            If Not String.IsNullOrEmpty(x.sFieldName) Then
                                sSQL.Append(SQLStringUnicode(x.objControl.Text, gbUnicode, False) & COMMA)
                            End If

                            If Not String.IsNullOrEmpty(x.sFieldNameU) Then
                                sSQL.Append(SQLStringUnicode(x.objControl.Text, gbUnicode, True) & COMMA)
                            End If
                        End If

                    End If

                Case "Cmb"
                    Select Case x.sSaveType
                        Case "0"
                            sSQL.Append(SQLString(ReturnValueC1Combo(CType(x.objControl, C1.Win.C1List.C1Combo))) & COMMA)

                        Case "1"
                            If x.sFieldNameU.Equals(x.sFieldName) Then
                                sSQL.Append(SQLString(x.objControl.Text) & COMMA)
                            Else
                                If Not String.IsNullOrEmpty(x.sFieldName) Then
                                    sSQL.Append(SQLStringUnicode(x.objControl.Text, gbUnicode, False) & COMMA)
                                End If

                                If Not String.IsNullOrEmpty(x.sFieldNameU) Then
                                    sSQL.Append(SQLStringUnicode(x.objControl.Text, gbUnicode, True) & COMMA)
                                End If
                            End If
                        Case "2"
                            sSQL.Append(SQLNumber(ReturnValueC1Combo(CType(x.objControl, C1.Win.C1List.C1Combo))) & COMMA)
                    End Select

                Case "Dtp"
                    sSQL.Append(SQLDateSave(x.objControl.Text) & COMMA)
            End Select
        Next i
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA & vbCrLf) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()") 'lastModifyDate, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function
    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLUpdateD25T1041
    ''# Created User: Lê Thị Lành
    ''# Created Date: 02/11/2007 11:25:57
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: 
    ''#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T1041(ByVal UndefinedBD As Integer) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T1041 Set ")
        If sImgFileName = "" Then
            sSQL.Append("ImageID = NULL" & COMMA)
        End If

        sSQL.Append("LastName = " & SQLStringUnicode(txtLastName.Text, gbUnicode, False) & COMMA) 'varchar[30], NOT NULL
        sSQL.Append("LastNameU = " & SQLStringUnicode(txtLastName.Text, gbUnicode, True) & COMMA) 'varchar[30], NOT NULL
        sSQL.Append("MiddleName = " & SQLStringUnicode(txtMiddleName.Text, gbUnicode, False) & COMMA) 'varchar[60], NOT NULL
        sSQL.Append("MiddleNameU = " & SQLStringUnicode(txtMiddleName.Text, gbUnicode, True) & COMMA) 'varchar[60], NOT NULL
        sSQL.Append("FirstName = " & SQLStringUnicode(txtFirstName.Text, gbUnicode, False) & COMMA) 'varchar[30], NOT NULL
        sSQL.Append("FirstNameU = " & SQLStringUnicode(txtFirstName.Text, gbUnicode, True) & COMMA) 'varchar[30], NOT NULL
        '******************************
        If txtMiddleName.Text <> "" Then 'ID 84207 26/01/2016
            sSQL.Append("CandidateName = isnull(" & SQLStringUnicode(txtLastName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtMiddleName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, False) & ",'') " & COMMA) 'varchar[50], NULL
            sSQL.Append("CandidateNameU = isnull(" & SQLStringUnicode(txtLastName, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtMiddleName, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, True) & ",'') " & COMMA) 'varchar[50], NULL
        Else
            sSQL.Append("CandidateName = isnull(" & SQLStringUnicode(txtLastName, False) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, False) & ",'') " & COMMA) 'varchar[50], NULL
            sSQL.Append("CandidateNameU = isnull(" & SQLStringUnicode(txtLastName, True) & ",'') + ' ' + isnull(" & SQLStringUnicode(txtFirstName, True) & ",'') " & COMMA) 'varchar[50], NULL
        End If
        '******************************
        sSQL.Append("Sex = " & SQLNumber(IIf(optBoy.Checked, "0", "1").ToString) & COMMA) 'tinyint, NULL
        sSQL.Append("UndefinedBD = " & SQLNumber(UndefinedBD) & COMMA) 'tinyint, NULL
        sSQL.Append("BirthDate = " & SQLDateSave(c1dateBirthDate.Value) & COMMA) 'datetime, NULL
        sSQL.Append("BirthPlace = " & SQLStringUnicode(txtBirthPlace.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("BirthPlaceU = " & SQLStringUnicode(txtBirthPlace.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("EthnicID = " & SQLString(tdbcEthnicID.Columns("EthnicID").Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("ReligionID = " & SQLString(tdbcReligionName.Columns("ReligionID").Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("NationalityID = " & SQLString(tdbcNationalityID.Columns("NationalityID").Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("IDCardNo = " & SQLString(txtIDCardNo.Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("IDCardDate = " & SQLDateSave(c1dateIDCardDate.Value) & COMMA) 'datetime, NULL
        'sSQL.Append("IDCardPlace = " & SQLStringUnicode(txtIDCardPlace.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("IDCardPlaceID = " & SQLString(ReturnValueC1Combo(tdbcZoneName)) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("LongBusinesstrip = " & SQLString(IIf(chkLongBusinesstrip.Checked, "1", "0").ToString) & COMMA) 'varchar[20], NULL
        sSQL.Append("Disabled = " & SQLNumber(IIf(chkDisabled.Checked, "1", "0").ToString) & COMMA) 'tinyint, NULL
        'DrivingLicenseID
        For i As Integer = 0 To arControl.Count - 1
            Dim x As MyControl = CType(arControl(i), MyControl)
            Select Case x.sType
                Case "Ref"
                    If CType(x.objControl, TextBox).TextAlign = HorizontalAlignment.Right Then
                        sSQL.Append(x.sFieldName & " = " & SQLNumber(x.objControl.Text) & COMMA)
                    Else
                        If x.sFieldNameU.Equals(x.sFieldName) Then
                            sSQL.Append(x.sFieldName & " = " & SQLString(x.objControl.Text) & COMMA)
                        Else
                            If Not String.IsNullOrEmpty(x.sFieldName) Then
                                sSQL.Append(x.sFieldName & " = " & SQLStringUnicode(x.objControl.Text, gbUnicode, False) & COMMA)
                            End If
                            If Not String.IsNullOrEmpty(x.sFieldNameU) Then
                                sSQL.Append(x.sFieldNameU & " = " & SQLStringUnicode(x.objControl.Text, gbUnicode, True) & COMMA)
                            End If

                        End If

                    End If

                Case "Cmb"
                    Select Case x.sSaveType
                        Case "0"
                            sSQL.Append(x.sFieldName & " = " & SQLString(ReturnValueC1Combo(CType(x.objControl, C1.Win.C1List.C1Combo))) & COMMA)

                        Case "1"
                            If x.sFieldNameU.Equals(x.sFieldName) Then
                                sSQL.Append(x.sFieldName & " = " & SQLString(x.objControl.Text) & COMMA)
                            Else
                                If Not String.IsNullOrEmpty(x.sFieldName) Then
                                    sSQL.Append(x.sFieldName & " = " & SQLStringUnicode(x.objControl.Text, gbUnicode, False) & COMMA)
                                End If
                                If Not String.IsNullOrEmpty(x.sFieldNameU) Then
                                    sSQL.Append(x.sFieldNameU & " = " & SQLStringUnicode(x.objControl.Text, gbUnicode, True) & COMMA)
                                End If
                            End If
                        Case "2"
                            sSQL.Append(x.sFieldName & " = " & SQLNumber(ReturnValueC1Combo(CType(x.objControl, C1.Win.C1List.C1Combo))) & COMMA)
                    End Select

                Case "Dtp"
                    sSQL.Append(x.sFieldName & " = " & SQLDateSave(x.objControl.Text) & COMMA)
            End Select
        Next i

        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("lastModifyDate =  getdate()") 'datetime, NULL

        sSQL.Append(" Where ")
        'sSQL.Append("DivisionID = " & SQLString(_divisionID) & " And ")
        sSQL.Append("CandidateID = " & SQLString(_candidateID))

        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1055
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 14/01/2009 10:54:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1055() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P1055 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1056
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 14/01/2009 10:57:16
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1056() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P1056 "
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(txtCandidateID.Text) 'CandidateID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Function ReadPhoto(ByVal sFileName As String) As Byte()
        Dim photo As Byte() = {}
        If Not ExistFile(sFileName) Then Return photo
        Dim fs As New FileStream(sFileName, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)

        photo = br.ReadBytes(CInt(fs.Length))
        br.Close()
        fs.Close()
        Return photo
    End Function

    Public Sub SaveImage(ByVal sFileName As String, ByVal sKey As String)

        Dim photo As Byte() = ReadPhoto(sFileName)
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sqlcmd As New SqlCommand("Update D25T1041 Set ImageID = @ImageID  Where CandidateID = @CandidateID", conn)

        Try
            If sqlcmd.Parameters.Count = 0 Then
                sqlcmd.Parameters.Add("@CandidateID", SqlDbType.VarChar, 20, "CandidateID").Value = sKey
                sqlcmd.Parameters.Add("@ImageID", System.Data.SqlDbType.Image, photo.Length).Value = photo 'Lưu ảnh kiểu Image 
            End If

            conn.Open()
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            sqlcmd.Dispose()
            conn.Close()
        End Try
    End Sub
    ''' 
    ''' Kiểm tra có tồn tại file dữ liệu hay không 
    ''' 
    ''' sFileName là chuỗi đường dẫn tên tập tin 
    ''' 
    ''' 
    Public Function ExistFile(ByVal sFileName As String) As Boolean
        ExistFile = True
        If Not File.Exists(sFileName) Then
            ExistFile = False
        End If
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        'If Not bCheckIDCardNo Then Exit Sub 'TH không thỏa CMND 
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        '************************** Ngay sinh
        Dim ngay As Integer = L3Int(txtNumday.Text)
        Dim thang As Integer = L3Int(txtNumMonth.Text)
        Dim nam As Integer = L3Int(txtNumYear.Text)
        Dim iUndefinedBD As Integer = 0
        If nam = 0 Then 'k nhap
            iUndefinedBD = 0
        Else
            If ngay <> 0 AndAlso thang <> 0 Then 'Nhap day du ngay ,thang ,nam
                iUndefinedBD = 0
            ElseIf ngay = 0 AndAlso thang = 0 Then 'Chi nhap nam
                iUndefinedBD = 1
            ElseIf ngay = 0 AndAlso thang <> 0 Then 'Chi nhap thang,nam
                iUndefinedBD = 2
            End If
        End If

        If ngay = 0 Then ngay = 1
        If thang = 0 Then thang = 1

        If nam <> 0 Then
            Dim d As New Date(nam, thang, ngay)
            c1dateBirthDate.Value = SQLDateShow(d)
        Else
            c1dateBirthDate.Value = ""
        End If
        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD25T1041(iUndefinedBD).ToString & vbCrLf)
                If _parentFrm = "D25F1055" Then sSQL.Append(SQLStoreD25P1056)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T1041(iUndefinedBD))
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            If sImgFileName <> "Original" And sImgFileName <> "" Then
                SaveImage(sImgFileName, txtCandidateID.Text)
            End If
            SaveOK()
            _bSaved = True
            _candidateID = txtCandidateID.Text
            btnClose.Enabled = True
            EnableButton(True)
            ResetValueClass()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                    'EnableButton(True)
                    'btnEnclourse.Text = rl3("Dinh_ke_m") & Space(1) & "(" & ReturnAttachmentNumber("D25T1041", txtCandidateID.Text) & ")"

                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()

                    'Bổ sung AuditLog (10/04/2008)

                    Dim Decs1 As String = ""
                    Dim Decs2 As String = ""
                    Dim Decs3 As String = ""
                    Dim Decs4 As String = ""
                    Dim Decs5 As String = ""
                    Decs1 = Trim(_divisionID.ToString)
                    Decs2 = Trim(CandidateID.ToString)
                    'Decs3 = Trim(tdbcRecDepartmentID.Text)
                    'Decs4 = Trim(tdbcRecTeamID.Text)
                    'Decs5 = Trim(tdbcRecPositionID.Text)
                    Call RunAuditLog("CandidateFiles", "02", Decs1, Decs2, Decs3, Decs4, Decs5)

            End Select
        Else
            SaveNotOK()
            _bSaved = False
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Sub picCandidate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picCandidate.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = System.Environment.GetFolderPath _
   (System.Environment.SpecialFolder.Personal)
        openFileDialog1.Filter = "jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*"

        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            sImgFileName = openFileDialog1.FileName
            If sImgFileName <> "" Then
                Dim myImage As Image = Image.FromFile(sImgFileName)
                If picCandidate.Image Is Nothing = False Then picCandidate.Image.Dispose()

                picCandidate.Image = myImage
            End If
        End If
        If Not picCandidate.Image Is Nothing Then
            lblGetPhoto.Visible = False
            lblGetPhoto2.Visible = False
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If Not D25Options.SaveLastRecent Then
            SetNew()
        End If
        btnNext.Enabled = False
        EnableButton(False)
        btnSave.Enabled = True
        btnEnclourse.Text = rl3("Dinh_ke_m") 'Đính kè&m
        TabMain.SelectedTab = TabPage1
        ResetValueClass()
        'If txtCandidateID.ReadOnly = False Then
        '    txtCandidateID.Text = ""
        '    txtCandidateID.Focus()
        'Else
        '    txtLastName.Focus()
        'End If

        'IncidentID	50891
        If tdbcMethodID.Visible Then
            Dim dr() As DataRow = CType(tdbcMethodID.DataSource, DataTable).Select("IsDefault=1")
            If dr.Length > 0 Then tdbcMethodID.Text = dr(0).Item("MethodName").ToString
            tdbcMethodID.Focus()
        Else
            txtCandidateID.Focus()
        End If

    End Sub

    Private Sub ResetValueClass()
        If clsCheckValid IsNot Nothing Then clsCheckValid.ResetValue()
        For Each ctr1 As Control In Panel1.Controls
            If Not TypeOf (ctr1) Is usrctrlCombo OrElse ctr1.Visible = False Then Continue For
            ctr1.Tag = False
        Next
    End Sub


    Private Sub btnQTDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQTDT.Click
        Dim f1 As New D25F1052
        f1.CandidateID = txtCandidateID.Text
        f1.FormState = _FormState
        f1.ShowDialog()
        f1.Dispose()
    End Sub

    Private Sub btnKNLV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKNLV.Click
        'Dim frm As New DxxMxx40
        'With frm
        '    .exeName = "D09E1040" 'Exe cần gọi
        '    .FormActive = "D09F0504" 'Form cần hiển thị
        '    Dim sField() As String = {"FormState", "CandidateID"}
        '    Dim sValue() As String = {CInt(_FormState).ToString, txtCandidateID.Text}
        '    .IDxx(sField) = sValue
        '    .ShowDialog()
        '    .Dispose()
        'End With

        'ID 82836 14/12/2015
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", _FormState)
        SetProperties(arrPro, "CandidateID", txtCandidateID.Text)
        CallFormShowDialog("D09D1040", "D09F0504", arrPro)
    End Sub


    Private Sub btnEnclourse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnclourse.Click
        'Dim f As New D91F4010
        'f.FormPermission = "D25F1050"
        'f.KeyID = txtCandidateID.Text
        'f.TableName = "D25T1041"
        'f.FormState = _FormState
        'f.ShowDialog()
        'f.Dispose()
        'btnEnclourse.Text = rL3("Dinh_ke_m") & Space(1) & "(" & ReturnAttachmentNumber("D25T1041", txtCandidateID.Text) & ")"

        'ID 79397 4/9/2015
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormPermission", "D25F1050")
        SetProperties(arrPro, "TableName", "D25T1041")
        SetProperties(arrPro, "Key1ID", txtCandidateID.Text)
        SetProperties(arrPro, "FormState", _FormState)
        'SetProperties(arrPro, "bNewDatabase", TRUE/ FALSE)'Lưu database mới ATT, không phải database hiện tại. Không dùng nữa mà theo thiết lập D91T0025
        CallFormShowDialog("D91D0340", "D91F4010", arrPro)
        btnEnclourse.Text = rL3("Dinh_ke_m") & Space(1) & " (" & ReturnAttachmentNumber("D25T1041", txtCandidateID.Text) & ")" 'Đính kèm
    End Sub

    Private Sub tabMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabMain.Click
        If TabMain.SelectedIndex = 0 Then
            If _FormState = EnumFormState.FormAdd Then
                If tdbcMethodID.Visible Then
                    tdbcMethodID.Focus()
                Else
                    txtCandidateID.Focus()
                End If
            Else
                txtLastName.Focus()
            End If
            '  Application.DoEvents()

        ElseIf TabMain.SelectedIndex = 1 Then
            'c1dateReceivedDate.Focus()
        Else
            'txtPCSkill.Focus()
        End If
    End Sub


    Private Sub lblGetPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGetPhoto.Click
        picCandidate_Click(Nothing, Nothing)
    End Sub

    Private Sub lblGetPhoto2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGetPhoto2.Click
        picCandidate_Click(Nothing, Nothing)
    End Sub

    Private Sub btnRemoveImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveImg.Click
        picCandidate.Image = Nothing
        sImgFileName = ""

        lblGetPhoto.Visible = True
        lblGetPhoto2.Visible = True
    End Sub

    Public Sub SetUpCboDivision_Department_Team(ByVal dr As DataRow)
        Select Case dr("FieldName").ToString
            Case "RecDepartmentID"
                Panel1.Controls.Add(lblOtherDepartmentID)
                Panel1.Controls.Add(tdbcRecDepartmentID)
                lblOtherDepartmentID.Text = dr("CaptionName" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString).ToString
                lblOtherDepartmentID.Font = FontUnicode(gbUnicode, lblOtherDepartmentID.Font.Style)
                lblOtherDepartmentID.Visible = True
                lblOtherDepartmentID.Location = MyLocation
                'lblOtherDepartmentID.Visible = False
                tdbcRecDepartmentID.Location = New Point(MyLocation.X + 126, MyLocation.Y + 1)
                tdbcRecDepartmentID.Visible = True
                tdbcRecDepartmentID.Tag = "Visible"
                If MyLocation.X >= col3 Then
                    tdbcRecDepartmentID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.RightDown
                End If
                Dim x As New MyControl
                x.objControl = tdbcRecDepartmentID
                x.sType = "Cmb"
                x.sFieldName = dr("FieldName").ToString
                x.sFieldNameU = dr("FieldNameU").ToString
                x.sSaveType = dr("SaveType").ToString
                arControl.Add(x)
                tdbcRecDepartmentID.TabIndex = iIndex + 1
                iIndex = tdbcRecDepartmentID.TabIndex
                '  If bSetColor Then tdbcOtherDepartmentID.EditorBackColor = clr
                '  clsCheckValid.SetControl(L3String(dr("FieldName")), tdbcRecDepartmentID)
                Dim sSQL As New StringBuilder(391)
                'sSQL.Append(" SELECT  '+' as DepartmentID, " & IIf(geLanguage = EnumLanguage.Vietnamese, "'<Theâm môùi>'", "'<Add new>'").ToString & " as DepartmentName, '<Add new>' as DivisionID, '' As BlockID ")
                'sSQL.Append(" Union ")
                sSQL.Append("Select DepartmentID, DepartmentName" & UnicodeJoin(gbUnicode) & " as DepartmentName, DivisionID, BlockID")
                sSQL.Append(" From 	D91T0012 WITH(NOLOCK) ")
                sSQL.Append(" Where 	Disabled= 0 And DivisionID=" & SQLString(gsDivisionID))
                LoadDataSource(tdbcRecDepartmentID, sSQL.ToString, gbUnicode)

            Case "RecTeamID"
                Panel1.Controls.Add(lblOtherTeamID)
                Panel1.Controls.Add(tdbcRecTeamID)
                lblOtherTeamID.Visible = True
                lblOtherTeamID.Text = dr("CaptionName" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString).ToString
                lblOtherTeamID.Font = FontUnicode(gbUnicode, lblOtherTeamID.Font.Style)
                lblOtherTeamID.Location = MyLocation
                tdbcRecTeamID.Location = New Point(MyLocation.X + 125, MyLocation.Y)
                tdbcRecTeamID.Visible = True
                tdbcRecTeamID.Tag = "Visible"
                tdbcRecTeamID.TabIndex = iIndex + 1
                iIndex = tdbcRecTeamID.TabIndex
                'If bSetColor Then tdbcOtherTeamID.EditorBackColor = clr
                '  clsCheckValid.SetControl(L3String(dr("FieldName")), tdbcRecTeamID)
                If MyLocation.X >= col3 Then
                    tdbcRecTeamID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.RightDown
                End If
                Dim x As New MyControl
                x.objControl = tdbcRecTeamID
                x.sType = "Cmb"
                x.sFieldName = dr("FieldName").ToString
                x.sFieldNameU = dr("FieldNameU").ToString
                x.sSaveType = dr("SaveType").ToString
                arControl.Add(x)
                ' LoadTableTeam()
        End Select


    End Sub

    'biến Ghi nhận tabindex để set cho tdbcDepartmentID và tdbcTeamID nếu 2 ctrl này có visible=true
    Dim iIndex As Integer

    Private Sub AutoAddControls()
        Dim sSQL As String = ""
        Dim sUnicode As String = UnicodeJoin(gbUnicode)
        sSQL = " SELECT   T1.*, " ' T1.TransTypeID, T1.GroupDataID, T1.OrderNo, T1.FieldName" & UnicodeJoin(gbUnicode) & " as FieldName," & _
        '" T1.Tab,T1.CreateUserID, T1.CreateDate, T1.LastModifyUserID, T1.LastModifyDate, " & _
        sSQL &= " T2.FieldType, T2.Length, T2.CaptionName01" & sUnicode & " as CaptionName01, T2.CaptionName84" & sUnicode & " as CaptionName84, T2.SaveType" & vbCrLf
        sSQL &= " FROM  D25T1081 T1 WITH(NOLOCK) " & vbCrLf
        sSQL &= " INNER JOIN  D25T0320 T2 WITH(NOLOCK) " & vbCrLf
        sSQL &= "         ON           T1.GroupDataID = T2.GroupDataID AND T1.FieldName" & sUnicode & " = T2.FieldName" & sUnicode & vbCrLf
        sSQL &= " WHERE          T1.TransTypeID = " & SQLString(D25Options.TransTypeID) & vbCrLf
        'sSQL &= " WHERE          T1.TransTypeID = 'L1'" & vbCrLf
        sSQL &= " ORDER BY     T1.OrderNo" & vbCrLf

        dtForm = ReturnDataTable(sSQL)
        ' Dim cmbo As C1.Win.C1List.C1Combo = CType(Panel1.Controls(14).Controls(0), C1.Win.C1List.C1Combo)
        'Load Tab 1
        Dim dtTab1 As DataTable = ReturnTableFilter(dtForm, "Tab = 1")
        For Each dr As DataRow In dtTab1.Rows
            If MyLocation.X >= col3 Then
                MyLocation.X = 15
                MyLocation.Y += 30
            Else
                MyLocation.X = MyLocation.X + 330
            End If

            Dim clr As Color
            Dim bSetColor As Boolean = clsCheckValid.GetBackColorCtrl(L3String(dr("FieldName")), clr)
            Select Case dr("FieldType").ToString
                Case "Ref"
                    Dim Ctrl1 As New usrctrlTextBox
                    If bSetColor Then Ctrl1 = New usrctrlTextBox(clr)

                    Ctrl1.Txt = txtCandidateID
                    Panel1.Controls.Add(Ctrl1)

                    Ctrl1.Location = MyLocation
                    Ctrl1.sFieldName = dr("FieldName").ToString
                    ' Ctrl1.sCandidateID = txtCandidateID.Text

                    Dim txt As TextBox = CType(Ctrl1.Controls.Item(0), TextBox)
                    If Number(dr("Length")) = 0 Then
                        txt.TextAlign = HorizontalAlignment.Right
                    Else
                        txt.MaxLength = L3Int(dr("Length").ToString)
                    End If
                    txt.Font = FontUnicode(gbUnicode, txt.Font.Style)

                    Dim lbl As Label = CType(Ctrl1.Controls.Item(1), Label)
                    lbl.Text = dr("CaptionName" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString).ToString
                    lbl.Font = FontUnicode(gbUnicode, lbl.Font.Style)
                    Dim x As New MyControl
                    x.objControl = txt
                    x.sType = "Ref"
                    x.sFieldName = dr("FieldName").ToString
                    x.sFieldNameU = dr("FieldNameU").ToString
                    x.sSaveType = dr("SaveType").ToString

                    arControl.Add(x)

                    iIndex = Ctrl1.TabIndex
                    'Bổ sung nhập mã cho field Fax, Email
                    If dr("FieldName").ToString.Contains("Email") Then CheckIdTextBox(txt, 250) : txt.CharacterCasing = CharacterCasing.Normal
                    If dr("FieldName").ToString.Contains("Fax") Then AddHandler txt.KeyPress, AddressOf txtIDCardNo_KeyPress
                    If dr("FieldName").ToString.Contains("Mobile") Then AddHandler txt.KeyPress, AddressOf txtIDCardNo_KeyPress
                    If dr("FieldName").ToString.Contains("Telephone") Then AddHandler txt.KeyPress, AddressOf txtIDCardNo_KeyPress
                    If dr("FieldName").ToString.Contains("DrivingLicenseID") Then AddHandler txt.KeyPress, AddressOf txtIDCardNo_KeyPress
                Case "Cmb"
                    If dr("FieldName").ToString = "RecDepartmentID" Or dr("FieldName").ToString = "RecTeamID" Then
                        Select Case dr("FieldName").ToString
                            Case "RecDepartmentID"
                                Dim dr1() As DataRow = dtTab1.Select("FieldName='DivisionID'")
                                SetUpCboDivision_Department_Team(dr) ', bSetColor, clr)
                                '  If dr1.Length > 0 Then GoTo 1
                                '                    If dr1.Length <= 0 Then
                                '                        SetUpCboDivision_Department_Team(dr)
                                '                    Else
                                '                        SetUpCboDivision_Department_Team(dr)
                                '                        GoTo 1
                                '                    End If
                            Case "RecTeamID"
                                SetUpCboDivision_Department_Team(dr) ', bSetColor, clr)
                        End Select
                    Else
1:
                        Dim Ctrl1 As New usrctrlCombo
                        If bSetColor Then Ctrl1 = New usrctrlCombo(clr)
                        Ctrl1.Name = "tdbc" & L3String(dr("FieldName")) '& "_"
                        '  TabPage1.Controls.Add(Ctrl1)
                        Panel1.Controls.Add(Ctrl1)

                        Ctrl1.Location = MyLocation
                        Ctrl1.SaveType = dr("SaveType").ToString
                        Ctrl1.FieldName = dr("FieldName").ToString

                        If Ctrl1.Name = "tdbcRecDepartmentID" Then
                            Ctrl1.Visible = False
                        End If

                        Dim cmb1 As C1.Win.C1List.C1Combo = CType(Ctrl1.Controls.Item(0), C1.Win.C1List.C1Combo)
                        If MyLocation.X >= col3 Then
                            cmb1.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.RightDown
                        End If

                        Dim lbl As Label = CType(Ctrl1.Controls.Item(1), Label)
                        lbl.Text = dr("CaptionName" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString).ToString
                        lbl.Font = FontUnicode(gbUnicode, lbl.Font.Style)
                        If dr("FieldName").ToString = "FileReceiver" Then
                            lbl.Font = lblFileReceiver_Underlined.Font
                        End If
                        Try
                            'Load Combo
                            'LoadDataSource(cmb1, SQLStoreD09P3030(dr("FieldName").ToString))
                            'If dr("FieldName").ToString = "RecDepartmentID" Then
                            '    Dim sSQL1 As New StringBuilder
                            '    sSQL1.Append("Select DepartmentID as Code, DepartmentName" & UnicodeJoin(gbUnicode) & " as Name, DivisionID, BlockID")
                            '    sSQL1.Append(" From 	D91T0012 WITH(NOLOCK) ")
                            '    sSQL1.Append(" Where 	Disabled= 0 And DivisionID=" & SQLString(gsDivisionID))
                            '    Ctrl1.SQLSource = sSQL1.ToString
                            ' Else
                            If dr("FieldName").ToString <> "RecDepartmentID" Then
                                Ctrl1.SQLSource = SQLStoreD25P5050(dr("FieldName").ToString)
                                Ctrl1.LoadCombosource()
                            End If

                            'End If


                        Catch ex As Exception
                            D99C0008.MsgL3("Combo can not load data with field " & dr("FieldName").ToString)
                        End Try
                        If dr("FieldName").ToString = "DivisionID" Then
                            cmb1.EditorBackColor = COLOR_BACKCOLOROBLIGATORY : cmb1.SelectedValue = gsDivisionID
                            _divisionIDValue = gsDivisionID
                        End If

                        Dim x As New MyControl
                        x.objControl = cmb1
                        x.sType = "Cmb"
                        x.sFieldName = dr("FieldName").ToString
                        x.sFieldNameU = dr("FieldNameU").ToString
                        x.sSaveType = dr("SaveType").ToString

                        If dr("FieldName").ToString <> "RecDepartmentID" Then
                            arControl.Add(x)
                        End If

                        iIndex = Ctrl1.TabIndex
                    End If

                Case "Dtp"
                    Dim Ctrl1 As New usrctrlDate
                    If bSetColor Then Ctrl1 = New usrctrlDate(clr)
                    Panel1.Controls.Add(Ctrl1)
                    Ctrl1.Location = MyLocation

                    Dim lbl As Label = CType(Ctrl1.Controls.Item(1), Label)
                    lbl.Text = dr("CaptionName" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString).ToString
                    lbl.Font = FontUnicode(gbUnicode, lbl.Font.Style)
                    Dim c1date As C1.Win.C1Input.C1DateEdit = CType(Ctrl1.Controls.Item(0), C1.Win.C1Input.C1DateEdit)


                    Dim x As New MyControl
                    x.objControl = c1date
                    x.sType = "Dtp"
                    x.sFieldName = dr("FieldName").ToString
                    x.sFieldNameU = dr("FieldNameU").ToString
                    x.sSaveType = dr("SaveType").ToString

                    arControl.Add(x)
                    iIndex = Ctrl1.TabIndex
            End Select


        Next


        'Load Tab 2
        Dim dtTab2 As DataTable = ReturnTableFilter(dtForm, "Tab = 2")
        For Each dr As DataRow In dtTab2.Rows
            If MyLocation.X >= col3 Then
                MyLocation.X = 15
                MyLocation.Y += 30
            Else
                MyLocation.X = MyLocation.X + 330
            End If


            Select Case dr("FieldType").ToString
                Case "Ref"
                    If CInt(dr("Tab")) = 1 Then
                        Dim Ctrl1 As New usrctrlTextBox
                        Panel1.Controls.Add(Ctrl1)

                        Ctrl1.Location = MyLocation

                        Dim txt As TextBox = CType(Ctrl1.Controls.Item(0), TextBox)
                        txt.MaxLength = L3Int(dr("Length").ToString)
                        txt.Font = FontUnicode(gbUnicode, txt.Font.Style)
                        Dim lbl As Label = CType(Ctrl1.Controls.Item(1), Label)
                        lbl.Text = dr("CaptionName" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString).ToString
                        lbl.Font = FontUnicode(gbUnicode, lbl.Font.Style)
                        Dim x As New MyControl
                        x.objControl = txt
                        x.sType = "Ref"
                        x.sFieldName = dr("FieldName").ToString
                        x.sFieldNameU = dr("FieldNameU").ToString
                        x.sSaveType = dr("SaveType").ToString

                        arControl.Add(x)
                    Else
                        Dim Ctrl1 As New WideTextBox
                        TabPage2.Controls.Add(Ctrl1)

                        Ctrl1.Location = Tab2Location

                        Dim txt As TextBox = CType(Ctrl1.Controls.Item(0), TextBox)
                        txt.MaxLength = L3Int(dr("Length").ToString)
                        txt.Font = FontUnicode(gbUnicode, txt.Font.Style)
                        Dim lbl As Label = CType(Ctrl1.Controls.Item(1), Label)
                        lbl.Text = dr("CaptionName" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString).ToString
                        lbl.Font = FontUnicode(gbUnicode, lbl.Font.Style)
                        Dim x As New MyControl
                        x.objControl = txt
                        x.sType = "Ref"
                        x.sFieldName = dr("FieldName").ToString
                        x.sFieldNameU = dr("FieldNameU").ToString
                        x.sSaveType = dr("SaveType").ToString

                        arControl.Add(x)

                        Tab2Location.Y += 57
                    End If

                Case "Cmb"
                    If dr("FieldName").ToString = "OtherDivisionID" Or dr("FieldName").ToString = "OtherDepartmentID" Or dr("FieldName").ToString = "OtherTeamID" Then
                        'SetUpCboDivision_Department_Team(dr)
                    Else
                        Dim Ctrl1 As New usrctrlCombo
                        TabPage2.Controls.Add(Ctrl1)

                        Ctrl1.Location = Tab2Location
                        Ctrl1.SaveType = dr("SaveType").ToString
                        Ctrl1.FieldName = dr("FieldName").ToString

                        Dim cmb1 As C1.Win.C1List.C1Combo = CType(Ctrl1.Controls.Item(0), C1.Win.C1List.C1Combo)
                        If MyLocation.X >= col3 Then
                            cmb1.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.RightDown
                        End If

                        Dim lbl As Label = CType(Ctrl1.Controls.Item(1), Label)
                        lbl.Text = dr("CaptionName" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString).ToString
                        lbl.Font = FontUnicode(gbUnicode, lbl.Font.Style)
                        Try
                            'Load Combo
                            'LoadDataSource(cmb1, SQLStoreD09P3030(dr("FieldName").ToString))
                            Ctrl1.SQLSource = SQLStoreD25P5050(dr("FieldName").ToString)
                            Ctrl1.LoadCombosource()

                        Catch ex As Exception
                            D99C0008.MsgL3("Combo can not load data with field " & dr("FieldName").ToString)
                        End Try


                        Dim x As New MyControl
                        x.objControl = cmb1
                        x.sType = "Cmb"
                        x.sFieldName = dr("FieldName").ToString
                        x.sFieldNameU = dr("FieldNameU").ToString
                        x.sSaveType = dr("SaveType").ToString

                        arControl.Add(x)

                        Tab2Location.Y += 29
                    End If

                Case "Dtp"
                    Dim Ctrl1 As New usrctrlDate
                    TabPage2.Controls.Add(Ctrl1)
                    Ctrl1.Location = Tab2Location

                    Dim lbl As Label = CType(Ctrl1.Controls.Item(1), Label)
                    lbl.Text = dr("CaptionName" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString).ToString
                    lbl.Font = FontUnicode(gbUnicode, lbl.Font.Style)
                    Dim c1date As C1.Win.C1Input.C1DateEdit = CType(Ctrl1.Controls.Item(0), C1.Win.C1Input.C1DateEdit)


                    Dim x As New MyControl
                    x.objControl = c1date
                    x.sType = "Dtp"
                    x.sFieldName = dr("FieldName").ToString
                    x.sFieldNameU = dr("FieldNameU").ToString
                    x.sSaveType = dr("SaveType").ToString

                    arControl.Add(x)
                    Tab2Location.Y += 29
            End Select
        Next
    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5050
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 28/08/2009 03:56:22
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5050(ByVal sFieldName As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P5050 "
        sSQL &= SQLString(sFieldName) & COMMA 'FieldName, varchar[250], NOT NULL
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

#Region "Events tdbcOtherDepartmentID"

    Private Sub tdbcOtherDepartmentID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentID.Close
        If tdbcRecDepartmentID.FindStringExact(tdbcRecDepartmentID.Text) = -1 Then tdbcRecDepartmentID.Text = ""
    End Sub

    Private Sub tdbcOtherDepartmentID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecDepartmentID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecDepartmentID.Text = ""
    End Sub
    'Private Sub tdbcOtherDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcOtherDepartmentID.SelectedValueChanged
    '    LoadOtherTdbcTeamID(ReturnValueC1Combo(tdbcOtherDepartmentID))
    'End Sub
    Private Sub tdbcOtherDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentID.SelectedValueChanged
        LoadOtherTdbcTeamID(ReturnValueC1Combo(tdbcRecDepartmentID))
    End Sub
#End Region

#Region "Events tdbcOtherTeamID"

    Private Sub tdbcOtherTeamID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecTeamID.Close
        If tdbcRecTeamID.FindStringExact(tdbcRecTeamID.Text) = -1 Then tdbcRecTeamID.Text = ""
    End Sub

    Private Sub tdbcOtherTeamID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecTeamID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcOtherTeamID.Text = ""

    End Sub
#End Region

    Private Sub LoadOtherTdbcTeamID(ByVal sDep As String)
        ' LoadDataSource(tdbcOtherTeamID, ReturnTableFilter(dt_RecTeamID, "TeamID <>'+' AND DepartmentID = " & SQLString(sDep)), gbUnicode)
        LoadDataSource(tdbcRecTeamID, ReturnTableFilter(dt_RecTeamID, "DepartmentID = " & SQLString(sDep)), gbUnicode)
    End Sub
    
    Private Sub txtIDCardNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIDCardNo.KeyPress
        'e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub btnRelationship_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelationship.Click
        'Dim frm As New DxxMxx40
        'With frm
        '    .exeName = "D09E1040"
        '    .FormActive = "D09F1502"
        '    .FormPermission = "D25F1050"
        '    Dim sField() As String = {"EmployeeID", "FormState"}
        '    Dim sValue() As String = {_candidateID, CType(_FormState, String)}
        '    .IDxx(sField) = sValue
        '    .ShowDialog()
        '    .Dispose()
        'End With

        'ID 82836 14/12/2015
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormState", _FormState)
        SetProperties(arrPro, "EmployeeID", _candidateID)
        CallFormShowDialog("D09D1040", "D09F1502", arrPro)
    End Sub


    Private Sub txtIDCardNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIDCardNo.LostFocus
        If txtIDCardNo.Text = "" Then Exit Sub
        If txtIDCardNo.Text.Length <> 9 And txtIDCardNo.Text.Length <> 12 Then
            txtIDCardNo.Focus()
        End If
    End Sub

    'Dim bCheckIDCardNo As Boolean = True
    Private Sub txtIDCardNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIDCardNo.Validated
        If Me.ActiveControl.Name = btnClose.Name Then Exit Sub
        btnSave.Enabled = CheckIDCardNo(Me.Name, txtIDCardNo.Text, txtCandidateID.Text)
        If btnSave.Enabled = False Then txtIDCardNo.Focus()
    End Sub

    Public Sub LoadtdbcDepartment(ByVal tdbcDepartment As C1.Win.C1List.C1Combo, ByVal sDivision As String)
        Dim sSQL1 As New StringBuilder
        sSQL1.Append("Select DepartmentID as Code, DepartmentName" & UnicodeJoin(gbUnicode) & " as Name, DivisionID, BlockID")
        sSQL1.Append(" From 	D91T0012 WITH(NOLOCK) ")
        sSQL1.Append(" Where 	Disabled= 0 And DivisionID=" & SQLString(sDivision))
        '*******************************
        LoadDataSource(tdbcDepartment, sSQL1.ToString, gbUnicode)
    End Sub

#Region "Input BirthDate"
    Private Sub c1dateBirthDate_DropDownClosed(ByVal sender As Object, ByVal e As C1.Win.C1Input.DropDownClosedEventArgs) Handles c1dateBirthDate.DropDownClosed

        Try
            If c1dateBirthDate.Text <> "" Then
                Dim d As Date
                d = CDate(c1dateBirthDate.Text)
                txtNumday.Text = d.Day.ToString
                txtNumMonth.Text = d.Month.ToString
                txtNumYear.Text = d.Year.ToString
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub c1dateBirthDate_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateBirthDate.DropDownOpened
        GetThisFormDate(c1dateBirthDate, txtNumday.Text, txtNumMonth.Text, txtNumYear.Text)
    End Sub


    Private Sub txtNumday_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumday.Validating
        e.Cancel = CheckNumInValid(c1dateBirthDate, txtNumday, 1, 31, txtNumday.Text, txtNumMonth.Text, txtNumYear.Text)
    End Sub

    Private Sub txtNumMonth_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumMonth.Validating
        e.Cancel = CheckNumInValid(c1dateBirthDate, txtNumMonth, 1, 12, txtNumday.Text, txtNumMonth.Text, txtNumYear.Text)
    End Sub

    Private Sub txtNumYear_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumYear.Validating
        e.Cancel = CheckNumInValid(c1dateBirthDate, txtNumYear, 1900, Today.Year, txtNumday.Text, txtNumMonth.Text, txtNumYear.Text)
    End Sub

    Private Sub txtNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumday.KeyPress, txtNumMonth.KeyPress, txtNumYear.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub btnBirthDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBirthDate.Click
        c1dateBirthDate.OpenDropDown()
    End Sub
#End Region

    Private Sub txtCandidateID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCandidateID.Validated
        'Dim Ctrl1 As usrctrlTextBox
        ''Panel1.Controls.Add(Ctrl1)
        'Ctrl1.sCandidateID = txtCandidateID.Text

    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcReligionName.Close, tdbcZoneName.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcReligionName.Validated, tdbcZoneName.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
End Class
