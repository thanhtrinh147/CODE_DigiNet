Public Class D13F1061

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Public WriteOnly Property TemplateID() As String
        Set(ByVal value As String)
            mTemplateID = value
        End Set
    End Property

    Private mTemplateID_D13F1061 As String = ""
    Public ReadOnly Property TemplateID_D13F1061() As String
        Get
            Return mTemplateID_D13F1061
        End Get
    End Property

    ''' <summary>
    ''' MaxSmallInt
    ''' </summary>
    Private Const MaxSmallInt As Int16 = 32767

    Private mTemplateID As String = ""
    Private dtSalaryLevelID As DataTable

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            _FormState = value
            _bSaved = False
            LoadTDBCombo()
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    LoadEdit()
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub D13F1061_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tab01.SelectedTab = tpg01
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            tab01.SelectedTab = tpg02
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tab01.SelectedTab = tpg03
            ' End If
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
    End Sub

    Private Sub D13F1061_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _FormState
        Loadlanguage()
        SetBackColorObligatory()
        LoadCaptionDescriptionOnTabPage02()
        LoadCaptionDescriptionOnTabPage03()
        txt_NumberFormat()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtTemplateID)
        InputDateCustomFormat(c1dateDate)

        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Template_tang_thong_so_luong_-_D13F1061") & UnicodeCaption(gbUnicode) 'Template tŸng th¤ng sç l§¥ng - D13F1061
        '================================================================ 
        lblTemplateID.Text = rL3("Ma") 'Mã
        lblTemplateName.Text = rL3("Dien_giai") 'Diễn giải
        lblDutyID.Text = rL3("Chuc_vu") 'Chức vụ
        lblNote.Text = rL3("Ghi_chu") 'Ghi chú
        lblOfficialTitle2.Text = rL3("Ngach_luong_2") 'Ngạch lương 2
        lblOfficialTitleID1.Text = rL3("Ngach_luong_1") 'Ngạch lương 1
        lblNextCoefficient.Text = rL3("He_so_luong") 'Hệ số lương
        lblNextLevel.Text = rL3("Bac_tiep_theo") 'Bậc tiếp theo
        lblNextOfficialTitle.Text = rL3("Ngach_tiep_theo") 'Ngạch tiếp theo
        lblOffSalNextTime.Text = rL3("Thoi_gian_tang_tiep_theo_(thang)") 'Thời gian tăng tiếp theo (tháng)
        lblOfficialTitleID.Text = rL3("Ngach_bac_luong") 'Ngạch bậc lương
        lblNextSalaryLevel.Text = rL3("Muc_luong_tiep_theo") 'Mức lương tiếp theo
        lblNextRaiseSalaryTime.Text = rL3("Thoi_gian_tang_tiep_theo_(thang)") 'Thời gian tăng tiếp theo (tháng)
        lblBasicSalary.Text = rL3("Luong_can_ban") 'Lương căn bản
        lblSalCoefficient.Text = rL3("Muc_tiep_theo") 'Mức tiếp theo
        lblSalNextTime.Text = rL3("Thoi_gian_tiep_theo_(thang)") 'Thời gian tiếp theo (tháng)
        lblCoefficient.Text = rL3("He_so_luong") 'Hệ số lương
        '================================================================ 
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 

        optDateRecruited.Text = rL3("Ngay_tuyenU") 'Ngày tuyển
        optDateJoined.Text = rL3("Ngay_vao_lam_viec") 'Ngày vào làm việc
        optExamineDateEnd.Text = rL3("Ngay_xet_cuoi_cungU") 'Ngày xét cuối cùng
        '================================================================ 
        grp01.Text = rL3("Ngay_bat_dau_tinh") 'Ngày bắt đầu tính
        '================================================================ 
        tpg01.Text = "1. " & rL3("Ngach_-_bac_luong") 'Ngạch - bậc lương
        tpg02.Text = "2. " & rL3("Luong_co_ban") 'Lương cơ bản
        tpg03.Text = "3. " & rL3("He_so_luong") 'Hệ số lương
        '================================================================ 
        tdbcDutyID.Columns("DutyID").Caption = rL3("Ma") 'Mã
        tdbcDutyID.Columns("DutyName").Caption = rL3("Ten") 'Tên
        tdbcSalaryLevelID2.Columns("SalaryLevelID").Caption = rL3("Bac_luong") 'Bậc lương
        tdbcSalaryLevelID2.Columns("SalaryCoefficient").Caption = rL3("He_so_luong") 'Hệ số lương
        tdbcOfficialTitleID2.Columns("OfficialTitleID").Caption = rL3("Ma") 'Mã
        tdbcOfficialTitleID2.Columns("OfficialTitleName").Caption = rL3("Ten") 'Tên
        tdbcSalaryLevelID.Columns("SalaryLevelID").Caption = rL3("Bac_luong") 'Bậc lương
        tdbcSalaryLevelID.Columns("SalaryCoefficient").Caption = rL3("He_so_luong") 'Hệ số lương
        tdbcOfficialTitleID01.Columns("OfficialTitleID").Caption = rL3("Ma") 'Mã
        tdbcOfficialTitleID01.Columns("OfficialTitleName").Caption = rL3("Ten") 'Tên
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcOfficialTitleID01
        'sSQL = "Select OfficialTitleID, OfficialTitleName From D09T0214 Where Disabled = 0 "
        sSQL = "Select OfficialTitleID,OfficialTitleName" & IIf(gbUnicode, "U", "").ToString & " as OfficialTitleName From D09T0214  WITH (NOLOCK) Where Disabled = 0 AND (IsUseOfficial = 0 OR IsUseOfficial = 1) Order By OfficialTitleID "
        LoadDataSource(tdbcOfficialTitleID01, sSQL, gbUnicode)

        sSQL = "Select OfficialTitleID, OfficialTitleName" & IIf(gbUnicode, "U", "").ToString & " as OfficialTitleName From D09T0214  WITH (NOLOCK) Where Disabled = 0 AND (IsUseOfficial = 0 OR IsUseOfficial = 2) Order By OfficialTitleID "
        LoadDataSource(tdbcOfficialTitleID2, sSQL, gbUnicode)

        'Load tdbcSalaryLevelID
        sSQL = "Select SalaryLevelID, SalaryCoefficient, OfficialTitleID From D09T0215  WITH (NOLOCK) Where Disabled = 0"
        dtSalaryLevelID = ReturnDataTable(sSQL)

        'Load tdbcDutyID
        sSQL = "Select DutyID, DutyName" & IIf(gbUnicode, "U", "").ToString & " as DutyName From D09T0211  WITH (NOLOCK) Where Disabled=0 "
        LoadDataSource(tdbcDutyID, sSQL, gbUnicode)
    End Sub

    'Private Sub LoadtdbcSalaryLevelID(ByVal ID As String)
    '    Dim sSQL As String = ""
    '    LoadDataSource(tdbcSalaryLevelID, ReturnTableFilter(dtSalaryLevelID, "OfficialTitleID=" & SQLString(ID)))
    '    Dim dt As DataTable = dtSalaryLevelID.Copy
    '    LoadDataSource(tdbcSalaryLevelID2, ReturnTableFilter(dt, "OfficialTitleID=" & SQLString(ID)))
    'End Sub

    Private Sub LoadtdbcSalaryLevelID1(ByVal ID As String)
        LoadDataSource(tdbcSalaryLevelID, ReturnTableFilter(dtSalaryLevelID, "OfficialTitleID=" & SQLString(ID)), gbUnicode)
    End Sub

    Private Sub LoadtdbcSalaryLevelID2(ByVal ID As String)
        LoadDataSource(tdbcSalaryLevelID2, ReturnTableFilter(dtSalaryLevelID, "OfficialTitleID=" & SQLString(ID)), gbUnicode)
    End Sub

#Region "Events tdbcOfficialTitleID01 load tdbcSalaryLevelID"

    Private Sub tdbcOfficialTitleID01_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID01.Close
        If tdbcOfficialTitleID01.FindStringExact(tdbcOfficialTitleID01.Text) = -1 Then tdbcOfficialTitleID01.Text = ""
    End Sub

    Private Sub tdbcOfficialTitleID01_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID01.SelectedValueChanged
        If Not (tdbcOfficialTitleID01.Tag Is Nothing OrElse tdbcOfficialTitleID01.Tag.ToString = "") Then
            tdbcOfficialTitleID01.Tag = ""
            Exit Sub
        End If
        If tdbcOfficialTitleID01.SelectedValue Is Nothing Then
            LoadtdbcSalaryLevelID1("-1")
            Exit Sub
        End If
        LoadtdbcSalaryLevelID1(tdbcOfficialTitleID01.SelectedValue.ToString())
        tdbcSalaryLevelID.Columns(1).NumberFormat = D13Format.DefaultNumber2
        tdbcSalaryLevelID.Text = ""
    End Sub

    Private Sub tdbcOfficialTitleID01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcOfficialTitleID01.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcOfficialTitleID01.Text = ""
    End Sub

    Private Sub tdbcSalaryLevelID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryLevelID.Close
        If tdbcSalaryLevelID.FindStringExact(tdbcSalaryLevelID.Text) = -1 Then tdbcSalaryLevelID.Text = ""
    End Sub

    Private Sub tdbcSalaryLevelID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSalaryLevelID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcSalaryLevelID.Text = ""
    End Sub

    Private Sub tdbcSalaryLevelID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalaryLevelID.SelectedValueChanged
        txtSalaryCoefficient.Text = (SQLNumber(tdbcSalaryLevelID.Columns(1).Value.ToString, D13Format.DefaultNumber2)).ToString

    End Sub

#End Region

#Region "Events tdbcOfficialTitleID2 load tdbcSalaryLevelID2"

    Private Sub tdbcOfficialTitleID2_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID2.Close
        If tdbcOfficialTitleID2.FindStringExact(tdbcOfficialTitleID2.Text) = -1 Then tdbcOfficialTitleID2.Text = ""
    End Sub

    Private Sub tdbcOfficialTitleID2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID2.SelectedValueChanged
        If Not (tdbcOfficialTitleID2.Tag Is Nothing OrElse tdbcOfficialTitleID2.Tag.ToString = "") Then
            tdbcOfficialTitleID2.Tag = ""
            Exit Sub
        End If
        If tdbcOfficialTitleID2.SelectedValue Is Nothing Then
            LoadtdbcSalaryLevelID2("-1")
            Exit Sub
        End If
        LoadtdbcSalaryLevelID2(tdbcOfficialTitleID2.SelectedValue.ToString())
        tdbcSalaryLevelID2.Columns(1).NumberFormat = D13Format.DefaultNumber2
        tdbcSalaryLevelID2.Text = ""
    End Sub

    Private Sub tdbcOfficialTitleID2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcOfficialTitleID2.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcOfficialTitleID2.Text = ""
    End Sub

    Private Sub tdbcSalaryLevelID2_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryLevelID2.Close
        If tdbcSalaryLevelID2.FindStringExact(tdbcSalaryLevelID2.Text) = -1 Then tdbcSalaryLevelID2.Text = ""
    End Sub

    Private Sub tdbcSalaryLevelID2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSalaryLevelID2.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcSalaryLevelID2.Text = ""
    End Sub

    Private Sub tdbcSalaryLevelID2_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalaryLevelID2.SelectedValueChanged
        txtSalaryCoefficient2.Text = (SQLNumber(tdbcSalaryLevelID2.Columns(1).Value.ToString, D13Format.DefaultNumber2)).ToString
    End Sub

#End Region

    Private Function SQLSelectD13T9000(ByVal sType As String) As DataTable
        Dim sSQL As String = ""
        sSQL = "Select Code, Description,DescriptionU, Disabled From D13T9000  WITH (NOLOCK) "
        sSQL &= "Where Type=" & SQLString(sType) & " Order by Code ASC "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Return dt
    End Function

    Private Sub LoadCaptionDescriptionOnTabPage02()
        Dim dt As DataTable = SQLSelectD13T9000("SALBA")
        Dim sUnicode As String = IIf(gbUnicode, "U", "").ToString

        For i As Integer = 0 To dt.Rows.Count - 1
            If i >= 4 Then Exit For
            tpg02.Controls("lblBasicSalary0" & (i + 1).ToString).Text = dt.Rows(i)("Description" & sUnicode).ToString()
            If gbUnicode Then
                tpg02.Controls("lblBasicSalary0" & (i + 1).ToString).Font = New Font("Microsoft Sans Serif", 8.25)
            End If

            Dim bEnabled As Boolean = Not L3Bool(dt.Rows(i)("Disabled"))
            tpg02.Controls("txtBaseSalary0" & (i + 1).ToString & "NextTime").Enabled = bEnabled
            tpg02.Controls("txtBaseSalary0" & (i + 1).ToString).Enabled = bEnabled
        Next
        dt.Dispose()
    End Sub

    Private Sub LoadCaptionDescriptionOnTabPage03()

        Dim dt As DataTable = SQLSelectD13T9000("SALCE")
        Dim sUnicode As String = IIf(gbUnicode, "U", "").ToString

        For i As Integer = 0 To dt.Rows.Count - 1
            If i >= 10 Then Exit For
            tpg03.Controls("lblCoefficient" & (i + 1).ToString("00")).Text = dt.Rows(i)("Description" & sUnicode).ToString()
            If gbUnicode Then
                tpg03.Controls("lblCoefficient" & (i + 1).ToString("00")).Font = New Font("Microsoft Sans Serif", 8.25)
            End If

            Dim bEnabled As Boolean = Not L3Bool(dt.Rows(i)("Disabled"))
            tpg03.Controls("txtSalNextTime" & (i + 1).ToString("00")).Enabled = bEnabled
            tpg03.Controls("txtSalCoefficient" & (i + 1).ToString("00")).Enabled = bEnabled
        Next
        dt.Dispose()
    End Sub

    'Hàm cũ
    'Private Sub LoadCaptionDescriptionOnTabPage02()
    '    Dim sSQL As String = ""
    '    sSQL = "Select Code, Description,DescriptionU, Disabled From D13T9000 "
    '    sSQL &= "Where Type='SALBA' Order by Code ASC "
    '    Dim dt As DataTable = ReturnDataTable(sSQL)
    '    Dim sUnicode As String = IIf(gbUnicode, "U", "").ToString
    '    If dt.Rows.Count >= 4 Then
    '        If dt.Rows(0)("Disabled").ToString.Trim = "0" Then
    '            lblBasicSalary01.Text = dt.Rows(0)("Description" & sUnicode).ToString()
    '            txtBaseSalary01NextTime.Enabled = True
    '            txtBaseSalary01.Enabled = True
    '        Else
    '            lblBasicSalary01.Text = dt.Rows(0)("Description" & sUnicode).ToString()
    '            txtBaseSalary01NextTime.Enabled = False
    '            txtBaseSalary01.Enabled = False
    '        End If
    '        If dt.Rows(1)("Disabled").ToString.Trim = "0" Then
    '            lblBasicSalary02.Text = dt.Rows(1)("Description" & sUnicode).ToString()
    '            txtBaseSalary02NextTime.Enabled = True
    '            txtBaseSalary02.Enabled = True
    '        Else
    '            lblBasicSalary02.Text = dt.Rows(1)("Description" & sUnicode).ToString()
    '            txtBaseSalary02NextTime.Enabled = False
    '            txtBaseSalary02.Enabled = False
    '        End If
    '        If dt.Rows(2)("Disabled").ToString.Trim = "0" Then
    '            lblBasicSalary03.Text = dt.Rows(2)("Description" & sUnicode).ToString()
    '            txtBaseSalary03NextTime.Enabled = True
    '            txtBaseSalary03.Enabled = True
    '        Else
    '            lblBasicSalary03.Text = dt.Rows(2)("Description" & sUnicode).ToString()
    '            txtBaseSalary03NextTime.Enabled = False
    '            txtBaseSalary03.Enabled = False
    '        End If
    '        If dt.Rows(3)("Disabled").ToString.Trim = "0" Then
    '            lblBasicSalary04.Text = dt.Rows(3)("Description" & sUnicode).ToString()
    '            txtBaseSalary04NextTime.Enabled = True
    '            txtBaseSalary04.Enabled = True
    '        Else
    '            lblBasicSalary04.Text = dt.Rows(3)("Description" & sUnicode).ToString()
    '            txtBaseSalary04NextTime.Enabled = False
    '            txtBaseSalary04.Enabled = False
    '        End If
    '    End If
    '    dt.Dispose()
    'End Sub
    '
    'Private Sub LoadCaptionDescriptionOnTabPage03()
    '    Dim sSQL As String = ""
    '    Dim sUnicode As String = IIf(gbUnicode, "U", "").ToString
    '    sSQL = "Select Code, Description,DescriptionU, Disabled From D13T9000 "
    '    sSQL &= "Where Type='SALCE' Order by Code ASC "
    '    Dim dt As DataTable = ReturnDataTable(sSQL)
    '    If dt.Rows.Count >= 10 Then
    '        If dt.Rows(0)("Disabled").ToString().Trim = "0" Then
    '            lblCoefficient01.Text = dt.Rows(0)("Description" & sUnicode).ToString()
    '            txtSalNextTime01.Enabled = True
    '            txtSalCoefficient01.Enabled = True
    '        Else
    '            lblCoefficient01.Text = dt.Rows(0)("Description" & sUnicode).ToString()
    '            txtSalNextTime01.Enabled = False
    '            txtSalCoefficient01.Enabled = False
    '        End If
    '        If dt.Rows(1)("Disabled").ToString().Trim = "0" Then
    '            lblCoefficient02.Text = dt.Rows(1)("Description" & sUnicode).ToString()
    '            txtSalNextTime02.Enabled = True
    '            txtSalCoefficient02.Enabled = True
    '        Else
    '            lblCoefficient02.Text = dt.Rows(1)("Description" & sUnicode).ToString()
    '            txtSalNextTime02.Enabled = False
    '            txtSalCoefficient02.Enabled = False
    '        End If
    '        If dt.Rows(2)("Disabled").ToString().Trim = "0" Then
    '            lblCoefficient03.Text = dt.Rows(2)("Description" & sUnicode).ToString()
    '            txtSalNextTime03.Enabled = True
    '            txtSalCoefficient03.Enabled = True
    '        Else
    '            lblCoefficient03.Text = dt.Rows(2)("Description" & sUnicode).ToString()
    '            txtSalNextTime03.Enabled = False
    '            txtSalCoefficient03.Enabled = False
    '        End If
    '        If dt.Rows(3)("Disabled").ToString().Trim = "0" Then
    '            lblCoefficient04.Text = dt.Rows(3)("Description" & sUnicode).ToString()
    '            txtSalNextTime04.Enabled = True
    '            txtSalCoefficient04.Enabled = True
    '        Else
    '            lblCoefficient04.Text = dt.Rows(3)("Description" & sUnicode).ToString()
    '            txtSalNextTime04.Enabled = False
    '            txtSalCoefficient04.Enabled = False
    '        End If
    '        If dt.Rows(4)("Disabled").ToString().Trim = "0" Then
    '            lblCoefficient05.Text = dt.Rows(4)("Description" & sUnicode).ToString()
    '            txtSalNextTime05.Enabled = True
    '            txtSalCoefficient05.Enabled = True
    '        Else
    '            lblCoefficient05.Text = dt.Rows(4)("Description" & sUnicode).ToString()
    '            txtSalNextTime05.Enabled = False
    '            txtSalCoefficient05.Enabled = False
    '        End If
    '        If dt.Rows(5)("Disabled").ToString().Trim = "0" Then
    '            lblCoefficient06.Text = dt.Rows(5)("Description" & sUnicode).ToString()
    '            txtSalNextTime06.Enabled = True
    '            txtSalCoefficient06.Enabled = True
    '        Else
    '            lblCoefficient06.Text = dt.Rows(5)("Description" & sUnicode).ToString()
    '            txtSalNextTime06.Enabled = False
    '            txtSalCoefficient06.Enabled = False
    '        End If
    '        If dt.Rows(6)("Disabled").ToString().Trim = "0" Then
    '            lblCoefficient07.Text = dt.Rows(6)("Description" & sUnicode).ToString()
    '            txtSalNextTime07.Enabled = True
    '            txtSalCoefficient07.Enabled = True
    '        Else
    '            lblCoefficient07.Text = dt.Rows(6)("Description" & sUnicode).ToString()
    '            txtSalNextTime07.Enabled = False
    '            txtSalCoefficient07.Enabled = False
    '        End If
    '        If dt.Rows(7)("Disabled").ToString().Trim = "0" Then
    '            lblCoefficient08.Text = dt.Rows(7)("Description" & sUnicode).ToString()
    '            txtSalNextTime08.Enabled = True
    '            txtSalCoefficient08.Enabled = True
    '        Else
    '            lblCoefficient08.Text = dt.Rows(7)("Description" & sUnicode).ToString()
    '            txtSalNextTime08.Enabled = False
    '            txtSalCoefficient08.Enabled = False
    '        End If
    '        If dt.Rows(8)("Disabled").ToString().Trim = "0" Then
    '            lblCoefficient09.Text = dt.Rows(8)("Description" & sUnicode).ToString()
    '            txtSalNextTime09.Enabled = True
    '            txtSalCoefficient09.Enabled = True
    '        Else
    '            lblCoefficient09.Text = dt.Rows(8)("Description" & sUnicode).ToString()
    '            txtSalNextTime09.Enabled = False
    '            txtSalCoefficient09.Enabled = False
    '        End If
    '        If dt.Rows(9)("Disabled").ToString().Trim = "0" Then
    '            lblCoefficient10.Text = dt.Rows(9)("Description" & sUnicode).ToString()
    '            txtSalNextTime10.Enabled = True
    '            txtSalCoefficient10.Enabled = True
    '        Else
    '            lblCoefficient10.Text = dt.Rows(9)("Description" & sUnicode).ToString()
    '            txtSalNextTime10.Enabled = False
    '            txtSalCoefficient10.Enabled = False
    '        End If

    '    End If
    '    dt.Dispose()
    'End Sub

#Region "Events tdbcDutyID with txtDutyName"

    Private Sub tdbcDutyID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDutyID.Close
        If tdbcDutyID.FindStringExact(tdbcDutyID.Text) = -1 Then
            tdbcDutyID.Text = ""
            txtDutyName.Text = ""
        End If
    End Sub

    Private Sub tdbcDutyID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDutyID.SelectedValueChanged
        txtDutyName.Text = tdbcDutyID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcDutyID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDutyID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcDutyID.Text = ""
        '    txtDutyName.Text = ""
        'End If
    End Sub

#End Region

    Private Sub LoadEdit()
        Dim sUnicode As String = IIf(gbUnicode, "U", "").ToString
        Dim sSQL As String = ""
        sSQL = "Select * "
        sSQL &= "From D13T1060  WITH (NOLOCK) "
        sSQL &= "Where Disabled=0 and TemplateID=" & SQLString(mTemplateID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            txtTemplateID.Text = mTemplateID
            txtTemplateName.Text = dt.Rows(0)("TemplateName" & sUnicode).ToString()
            tdbcDutyID.Text = dt.Rows(0)("DutyID").ToString()
            txtNote.Text = dt.Rows(0)("Note" & sUnicode).ToString()
            Select Case dt.Rows(0)("DateBeginBaseOn").ToString.Trim
                Case "ExamineDateEnd"
                    optExamineDateEnd.Checked = True
                    c1dateDate.Enabled = False
                Case "DateJoined"
                    optDateJoined.Checked = True
                    c1dateDate.Enabled = False
                Case "DateRecruited"
                    optDateRecruited.Checked = True
                    c1dateDate.Enabled = False
                Case "FixedDate"
                    optDate.Checked = True
                    c1dateDate.Enabled = optDate.Checked
                    c1dateDate.Value = IIf(dt.Rows(0)("DateBegin").ToString() = "", "", CDate(dt.Rows(0)("DateBegin").ToString()))
            End Select

            txtOffSa1NextTime.Text = dt.Rows(0)("OffSa1NextTime").ToString()
            tdbcOfficialTitleID01.Text = dt.Rows(0)("OfficalTitleID").ToString()
            tdbcSalaryLevelID.Text = dt.Rows(0)("SalaryLevelID").ToString()
            txtSalaryCoefficient.Text = dt.Rows(0)("SaCoefficient").ToString()
            txtOffSa2NextTime.Text = dt.Rows(0)("OffSa2NextTime").ToString()
            tdbcOfficialTitleID2.Text = dt.Rows(0)("OfficalTitleID2").ToString()
            tdbcSalaryLevelID2.Text = dt.Rows(0)("SalaryLevelID2").ToString()
            txtSalaryCoefficient2.Text = dt.Rows(0)("SaCoefficient2").ToString()

            For i As Integer = 1 To 4
                tpg02.Controls("txtBaseSalary" & i.ToString("00") & "NextTime").Text = dt.Rows(0)("BaseSalary" & i.ToString("00") & "NextTime").ToString()
                tpg02.Controls("txtBaseSalary" & i.ToString("00")).Text = dt.Rows(0)("BaseSalary" & i.ToString("00")).ToString()
            Next
            'txtBaseSalary01NextTime.Text = dt.Rows(0)("BaseSalary01NextTime").ToString()
            'txtBaseSalary01.Text = dt.Rows(0)("BaseSalary01").ToString()
            'txtBaseSalary02NextTime.Text = dt.Rows(0)("BaseSalary02NextTime").ToString()
            'txtBaseSalary02.Text = dt.Rows(0)("BaseSalary02").ToString()
            'txtBaseSalary03NextTime.Text = dt.Rows(0)("BaseSalary03NextTime").ToString()
            'txtBaseSalary03.Text = dt.Rows(0)("BaseSalary03").ToString()
            'txtBaseSalary04NextTime.Text = dt.Rows(0)("BaseSalary04NextTime").ToString()
            'txtBaseSalary04.Text = dt.Rows(0)("BaseSalary04").ToString()

            For i As Integer = 1 To 10
                tpg03.Controls("txtSalNextTime" & i.ToString("00")).Text = dt.Rows(0)("SalNextTime" & i.ToString("00")).ToString()
                tpg03.Controls("txtSalCoefficient" & i.ToString("00")).Text = dt.Rows(0)("SalCoefficient" & i.ToString("00")).ToString()
            Next
            'txtSalNextTime01.Text = dt.Rows(0)("SalNextTime01").ToString()
            'txtSalCoefficient01.Text = dt.Rows(0)("SalCoefficient01").ToString()
            'txtSalNextTime02.Text = dt.Rows(0)("SalNextTime02").ToString()
            'txtSalCoefficient02.Text = dt.Rows(0)("SalCoefficient02").ToString()
            'txtSalNextTime03.Text = dt.Rows(0)("SalNextTime03").ToString()
            'txtSalCoefficient03.Text = dt.Rows(0)("SalCoefficient03").ToString()
            'txtSalNextTime04.Text = dt.Rows(0)("SalNextTime04").ToString()
            'txtSalCoefficient04.Text = dt.Rows(0)("SalCoefficient04").ToString()
            'txtSalNextTime05.Text = dt.Rows(0)("SalNextTime05").ToString()
            'txtSalCoefficient05.Text = dt.Rows(0)("SalCoefficient05").ToString()
            'txtSalNextTime06.Text = dt.Rows(0)("SalNextTime06").ToString()
            'txtSalCoefficient06.Text = dt.Rows(0)("SalCoefficient06").ToString()
            'txtSalNextTime07.Text = dt.Rows(0)("SalNextTime07").ToString()
            'txtSalCoefficient07.Text = dt.Rows(0)("SalCoefficient07").ToString()
            'txtSalNextTime08.Text = dt.Rows(0)("SalNextTime08").ToString()
            'txtSalCoefficient08.Text = dt.Rows(0)("SalCoefficient08").ToString()
            'txtSalNextTime09.Text = dt.Rows(0)("SalNextTime09").ToString()
            'txtSalCoefficient09.Text = dt.Rows(0)("SalCoefficient09").ToString()
            'txtSalNextTime10.Text = dt.Rows(0)("SalNextTime10").ToString()
            'txtSalCoefficient10.Text = dt.Rows(0)("SalCoefficient10").ToString()
        End If
        txtTemplateID.Enabled = False
        txtTemplateName.Focus()
        dt.Dispose()
    End Sub


    Private Function AllowSave() As Boolean
        If txtTemplateID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ma_template"))
            txtTemplateID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D13T1060", "TemplateID", txtTemplateID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtTemplateID.Focus()
                Return False
            End If
        End If
        If txtTemplateName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ten_template"))
            txtTemplateName.Focus()
            Return False
        End If
        If tdbcDutyID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Chuc_vu"))
            tdbcDutyID.Focus()
            Return False
        End If
        If txtNote.Text.Trim <> "" Then
            If Trim(txtNote.Text).Length > 250 Then
                D99C0008.MsgL3(rL3("Do_dai_Ghi_chu_khong_duoc_vuot_qua_250_ky_tu"))
                txtNote.Focus()
                Return False
            End If

        End If
        If optDate.Checked Then
            If c1dateDate.Text = "" Then
                D99C0008.MsgNotYetChoose(rL3("Ngay_bat_dau_tinh"))
                c1dateDate.Focus()
                Return False
            End If
        End If
        If txtBaseSalary01NextTime.Text.Trim <> "" Then
            If txtBaseSalary01.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_luong_tiep_theo"))
                tab01.SelectedTab = tpg02
                txtBaseSalary01.Focus()
                Return False
            End If
        End If
        If txtBaseSalary02NextTime.Text.Trim <> "" Then
            If txtBaseSalary02.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_luong_tiep_theo"))
                tab01.SelectedTab = tpg02
                txtBaseSalary02.Focus()
                Return False
            End If
        End If
        If txtBaseSalary03NextTime.Text.Trim <> "" Then
            If txtBaseSalary03.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_luong_tiep_theo"))
                tab01.SelectedTab = tpg02
                txtBaseSalary03.Focus()
                Return False
            End If
        End If
        If txtBaseSalary04NextTime.Text.Trim <> "" Then
            If txtBaseSalary04.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_luong_tiep_theo"))
                tab01.SelectedTab = tpg02
                txtBaseSalary04.Focus()
                Return False
            End If
        End If
        If txtSalNextTime01.Text.Trim <> "" Then
            If txtSalCoefficient01.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_tiep_theo"))
                tab01.SelectedTab = tpg03
                txtSalCoefficient01.Focus()
                Return False
            End If
        End If
        If txtSalNextTime02.Text.Trim <> "" Then
            If txtSalCoefficient02.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_tiep_theo"))
                tab01.SelectedTab = tpg03
                txtSalCoefficient02.Focus()
                Return False
            End If
        End If
        If txtSalNextTime03.Text.Trim <> "" Then
            If txtSalCoefficient03.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_tiep_theo"))
                tab01.SelectedTab = tpg03
                txtSalCoefficient03.Focus()
                Return False
            End If
        End If
        If txtSalNextTime04.Text.Trim <> "" Then
            If txtSalCoefficient04.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_tiep_theo"))
                tab01.SelectedTab = tpg03
                txtSalCoefficient04.Focus()
                Return False
            End If
        End If
        If txtSalNextTime05.Text.Trim <> "" Then
            If txtSalCoefficient05.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_tiep_theo"))
                tab01.SelectedTab = tpg03
                txtSalCoefficient05.Focus()
                Return False
            End If
        End If
        If txtSalNextTime06.Text.Trim <> "" Then
            If txtSalCoefficient06.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_tiep_theo"))
                tab01.SelectedTab = tpg03
                txtSalCoefficient06.Focus()
                Return False
            End If
        End If
        If txtSalNextTime07.Text.Trim <> "" Then
            If txtSalCoefficient07.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_tiep_theo"))
                tab01.SelectedTab = tpg03
                txtSalCoefficient07.Focus()
                Return False
            End If
        End If
        If txtSalNextTime08.Text.Trim <> "" Then
            If txtSalCoefficient08.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_tiep_theo"))
                tab01.SelectedTab = tpg03
                txtSalCoefficient08.Focus()
                Return False
            End If
        End If
        If txtSalNextTime09.Text.Trim <> "" Then
            If txtSalCoefficient09.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_tiep_theo"))
                tab01.SelectedTab = tpg03
                txtSalCoefficient09.Focus()
                Return False
            End If
        End If
        If txtSalNextTime10.Text.Trim <> "" Then
            If txtSalCoefficient10.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_tiep_theo"))
                tab01.SelectedTab = tpg03
                txtSalCoefficient10.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        btnSave.Enabled = False
        btnClose.Enabled = False
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL = SQLInsertD13T1060()
            Case EnumFormState.FormEdit
                sSQL = SQLUpdateD13T1060()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            If _FormState = EnumFormState.FormAdd Then
                mTemplateID_D13F1061 = txtTemplateID.Text
                btnClose.Enabled = True
                btnClose.Focus()
            ElseIf _FormState = EnumFormState.FormEdit Then
                'Audit Log
                Dim sDesc1 As String = txtTemplateID.Text
                Dim sDesc2 As String = txtTemplateName.Text
                Dim sDesc3 As String = txtNote.Text
                Dim sDesc4 As String = ""
                Dim sDesc5 As String = ""
                RunAuditLog(AuditCodeSalaryTemplates, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

                btnSave.Enabled = True
                btnClose.Enabled = True
                btnClose.Focus()
            End If
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
            Return
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1060
    '# Created User: Hoàng Đức Thịnh
    '# Created Date: 19/12/2006 10:21:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1060() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D13T1060("
        sSQL &= "TemplateID, TemplateName,TemplateNameU, DivisionID, DutyID, Note,NoteU, "
        sSQL &= "DateBeginBaseOn, DateBegin, OfficalTitleID, SalaryLevelID, SaCoefficient, "
        sSQL &= "OffSa1NextTime, OfficalTitleID2, SalaryLevelID2, SaCoefficient2, OffSa2NextTime, "
        sSQL &= "BaseSalary01, BaseSalary01NextTime, BaseSalary02, BaseSalary02NextTime, BaseSalary03, "
        sSQL &= "BaseSalary03NextTime, BaseSalary04, BaseSalary04NextTime, SalCoefficient01, SalNextTime01, "
        sSQL &= "SalCoefficient02, SalNextTime02, SalCoefficient03, SalNextTime03, SalCoefficient04, "
        sSQL &= "SalNextTime04, SalCoefficient05, SalNextTime05, SalCoefficient06, SalNextTime06, "
        sSQL &= "SalCoefficient07, SalNextTime07, SalCoefficient08, SalNextTime08, SalCoefficient09, "
        sSQL &= "SalNextTime09, SalCoefficient10, SalNextTime10, Disabled, CreateUserID, "
        sSQL &= "CreateDate, LastModifyUserID, LastModifyDate"
        sSQL &= ") Values ("
        sSQL &= SQLString(txtTemplateID.Text) & COMMA 'TemplateID [KEY], varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtTemplateName.Text, gbUnicode, False) & COMMA 'TemplateName, varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtTemplateName.Text, gbUnicode, True) & COMMA 'TemplateNameU, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcDutyID.Text) & COMMA 'DutyID, varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA 'Note, varchar[250], NOT NULL
        sSQL &= SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA 'NoteU, varchar[250], NOT NULL
        If optExamineDateEnd.Checked Then
            sSQL &= SQLString("ExamineDateEnd") & COMMA 'DateBeginBaseOn, varchar[250], NOT NULL
            sSQL &= SQLDateSave("") & COMMA 'DateBegin, datetime, NULL
        ElseIf optDateJoined.Checked Then
            sSQL &= SQLString("DateJoined") & COMMA 'DateBeginBaseOn, varchar[250], NOT NULL
            sSQL &= SQLDateSave("") & COMMA 'DateBegin, datetime, NULL
        ElseIf optDateRecruited.Checked Then
            sSQL &= SQLString("DateRecruited") & COMMA 'DateBeginBaseOn, varchar[250], NOT NULL
            sSQL &= SQLDateSave("") & COMMA 'DateBegin, datetime, NULL
        ElseIf optDate.Checked Then
            sSQL &= SQLString("FixedDate") & COMMA 'DateBeginBaseOn, varchar[250], NOT NULL
            sSQL &= SQLDateSave(c1dateDate.Text) & COMMA 'DateBegin, datetime, NULL
        End If
        sSQL &= SQLString(tdbcOfficialTitleID01.Text) & COMMA 'OfficalTitleID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcSalaryLevelID.Text) & COMMA 'SalaryLevelID, varchar[20], NOT NULL
        sSQL &= SQLMoney(txtSalaryCoefficient.Text) & COMMA 'SaCoefficient, decimal, NOT NULL
        sSQL &= SQLNumber(txtOffSa1NextTime.Text) & COMMA 'OffSa1NextTime, int, NOT NULL
        sSQL &= SQLString(tdbcOfficialTitleID2.Text) & COMMA 'OfficalTitleID2, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcSalaryLevelID2.Text) & COMMA 'SalaryLevelID2, varchar[20], NOT NULL
        sSQL &= SQLMoney(txtSalaryCoefficient2.Text) & COMMA 'SaCoefficient2, decimal, NOT NULL
        sSQL &= SQLNumber(txtOffSa2NextTime.Text) & COMMA 'OffSa2NextTime, int, NOT NULL
        sSQL &= SQLMoney(txtBaseSalary01.Text) & COMMA 'BaseSalary01, decimal, NOT NULL
        sSQL &= SQLNumber(txtBaseSalary01NextTime.Text) & COMMA 'BaseSalary01NextTime, int, NOT NULL
        sSQL &= SQLMoney(txtBaseSalary02.Text) & COMMA 'BaseSalary02, decimal, NOT NULL
        sSQL &= SQLNumber(txtBaseSalary02NextTime.Text) & COMMA 'BaseSalary02NextTime, int, NOT NULL
        sSQL &= SQLMoney(txtBaseSalary03.Text) & COMMA 'BaseSalary03, decimal, NOT NULL
        sSQL &= SQLNumber(txtBaseSalary03NextTime.Text) & COMMA 'BaseSalary03NextTime, int, NOT NULL
        sSQL &= SQLMoney(txtBaseSalary04.Text) & COMMA 'BaseSalary04, decimal, NOT NULL
        sSQL &= SQLNumber(txtBaseSalary04NextTime.Text) & COMMA 'BaseSalary04NextTime, int, NOT NULL
        sSQL &= SQLMoney(txtSalCoefficient01.Text) & COMMA 'SalCoefficient01, decimal, NOT NULL
        sSQL &= SQLNumber(txtSalNextTime01.Text) & COMMA 'SalNextTime01, int, NOT NULL
        sSQL &= SQLMoney(txtSalCoefficient02.Text) & COMMA 'SalCoefficient02, decimal, NOT NULL
        sSQL &= SQLNumber(txtSalNextTime02.Text) & COMMA 'SalNextTime02, int, NOT NULL
        sSQL &= SQLMoney(txtSalCoefficient03.Text) & COMMA 'SalCoefficient03, decimal, NOT NULL
        sSQL &= SQLNumber(txtSalNextTime03.Text) & COMMA 'SalNextTime03, int, NOT NULL
        sSQL &= SQLMoney(txtSalCoefficient04.Text) & COMMA 'SalCoefficient04, decimal, NOT NULL
        sSQL &= SQLNumber(txtSalNextTime04.Text) & COMMA 'SalNextTime04, int, NOT NULL
        sSQL &= SQLMoney(txtSalCoefficient05.Text) & COMMA 'SalCoefficient05, decimal, NOT NULL
        sSQL &= SQLNumber(txtSalNextTime05.Text) & COMMA 'SalNextTime05, int, NOT NULL
        sSQL &= SQLMoney(txtSalCoefficient06.Text) & COMMA 'SalCoefficient06, decimal, NOT NULL
        sSQL &= SQLNumber(txtSalNextTime06.Text) & COMMA 'SalNextTime06, int, NOT NULL
        sSQL &= SQLMoney(txtSalCoefficient07.Text) & COMMA 'SalCoefficient07, decimal, NOT NULL
        sSQL &= SQLNumber(txtSalNextTime07.Text) & COMMA 'SalNextTime07, int, NOT NULL
        sSQL &= SQLMoney(txtSalCoefficient08.Text) & COMMA 'SalCoefficient08, decimal, NOT NULL
        sSQL &= SQLNumber(txtSalNextTime08.Text) & COMMA 'SalNextTime08, int, NOT NULL
        sSQL &= SQLMoney(txtSalCoefficient09.Text) & COMMA 'SalCoefficient09, decimal, NOT NULL
        sSQL &= SQLNumber(txtSalNextTime09.Text) & COMMA 'SalNextTime09, int, NOT NULL
        sSQL &= SQLMoney(txtSalCoefficient10.Text) & COMMA 'SalCoefficient10, decimal, NOT NULL
        sSQL &= SQLNumber(txtSalNextTime10.Text) & COMMA 'SalNextTime10, int, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Disabled, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NOT NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NOT NULL
        sSQL &= "GetDate()" 'LastModifyDate, datetime, NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1060
    '# Created User: Hoàng Đức Thịnh
    '# Created Date: 19/12/2006 10:40:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1060() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T1060 Set "
        sSQL &= "TemplateName = " & SQLStringUnicode(txtTemplateName.Text, gbUnicode, False) & COMMA 'varchar[20], NOT NULL
        sSQL &= "TemplateNameU = " & SQLStringUnicode(txtTemplateName.Text, gbUnicode, True) & COMMA 'varchar[20], NOT NULL
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & COMMA 'varchar[20], NOT NULL
        sSQL &= "DutyID = " & SQLString(tdbcDutyID.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "Note = " & SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA 'varchar[250], NOT NULL
        sSQL &= "NoteU = " & SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA 'varchar[250], NOT NULL
        If optExamineDateEnd.Checked Then
            sSQL &= "DateBeginBaseOn = " & SQLString("ExamineDateEnd") & COMMA 'DateBeginBaseOn, varchar[250], NOT NULL
            sSQL &= "DateBegin = " & SQLDateSave("") & COMMA 'DateBegin, datetime, NULL
        ElseIf optDateJoined.Checked Then
            sSQL &= "DateBeginBaseOn = " & SQLString("DateJoined") & COMMA 'DateBeginBaseOn, varchar[250], NOT NULL
            sSQL &= "DateBegin = " & SQLDateSave("") & COMMA 'DateBegin, datetime, NULL
        ElseIf optDateRecruited.Checked Then
            sSQL &= "DateBeginBaseOn = " & SQLString("DateRecruited") & COMMA 'DateBeginBaseOn, varchar[250], NOT NULL
            sSQL &= "DateBegin = " & SQLDateSave("") & COMMA 'DateBegin, datetime, NULL
        ElseIf optDate.Checked Then
            sSQL &= "DateBeginBaseOn = " & SQLString("FixedDate") & COMMA 'DateBeginBaseOn, varchar[250], NOT NULL
            sSQL &= "DateBegin = " & SQLDateSave(c1dateDate.Text) & COMMA 'DateBegin, datetime, NULL
        End If
        sSQL &= "OfficalTitleID = " & SQLString(tdbcOfficialTitleID01.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "SalaryLevelID = " & SQLString(tdbcSalaryLevelID.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "SaCoefficient = " & SQLMoney(txtSalaryCoefficient.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "OffSa1NextTime = " & SQLNumber(txtOffSa1NextTime.Text) & COMMA 'int, NOT NULL
        sSQL &= "OfficalTitleID2 = " & SQLString(tdbcOfficialTitleID2.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "SalaryLevelID2 = " & SQLString(tdbcSalaryLevelID2.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "SaCoefficient2 = " & SQLMoney(txtSalaryCoefficient2.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "OffSa2NextTime = " & SQLNumber(txtOffSa2NextTime.Text) & COMMA 'int, NOT NULL
        sSQL &= "BaseSalary01 = " & SQLMoney(txtBaseSalary01.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "BaseSalary01NextTime = " & SQLNumber(txtBaseSalary01NextTime.Text) & COMMA 'int, NOT NULL
        sSQL &= "BaseSalary02 = " & SQLMoney(txtBaseSalary02.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "BaseSalary02NextTime = " & SQLNumber(txtBaseSalary02NextTime.Text) & COMMA 'int, NOT NULL
        sSQL &= "BaseSalary03 = " & SQLMoney(txtBaseSalary03.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "BaseSalary03NextTime = " & SQLNumber(txtBaseSalary03NextTime.Text) & COMMA 'int, NOT NULL
        sSQL &= "BaseSalary04 = " & SQLMoney(txtBaseSalary04.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "BaseSalary04NextTime = " & SQLNumber(txtBaseSalary04NextTime.Text) & COMMA 'int, NOT NULL
        sSQL &= "SalCoefficient01 = " & SQLMoney(txtSalCoefficient01.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SalNextTime01 = " & SQLNumber(txtSalNextTime01.Text) & COMMA 'int, NOT NULL
        sSQL &= "SalCoefficient02 = " & SQLMoney(txtSalCoefficient02.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SalNextTime02 = " & SQLNumber(txtSalNextTime02.Text) & COMMA 'int, NOT NULL
        sSQL &= "SalCoefficient03 = " & SQLMoney(txtSalCoefficient03.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SalNextTime03 = " & SQLNumber(txtSalNextTime03.Text) & COMMA 'int, NOT NULL
        sSQL &= "SalCoefficient04 = " & SQLMoney(txtSalCoefficient04.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SalNextTime04 = " & SQLNumber(txtSalNextTime04.Text) & COMMA 'int, NOT NULL
        sSQL &= "SalCoefficient05 = " & SQLMoney(txtSalCoefficient05.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SalNextTime05 = " & SQLNumber(txtSalNextTime05.Text) & COMMA 'int, NOT NULL
        sSQL &= "SalCoefficient06 = " & SQLMoney(txtSalCoefficient06.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SalNextTime06 = " & SQLNumber(txtSalNextTime06.Text) & COMMA 'int, NOT NULL
        sSQL &= "SalCoefficient07 = " & SQLMoney(txtSalCoefficient07.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SalNextTime07 = " & SQLNumber(txtSalNextTime07.Text) & COMMA 'int, NOT NULL
        sSQL &= "SalCoefficient08 = " & SQLMoney(txtSalCoefficient08.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SalNextTime08 = " & SQLNumber(txtSalNextTime08.Text) & COMMA 'int, NOT NULL
        sSQL &= "SalCoefficient09 = " & SQLMoney(txtSalCoefficient09.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SalNextTime09 = " & SQLNumber(txtSalNextTime09.Text) & COMMA 'int, NOT NULL
        sSQL &= "SalCoefficient10 = " & SQLMoney(txtSalCoefficient10.Text) & COMMA 'decimal, NOT NULL
        sSQL &= "SalNextTime10 = " & SQLNumber(txtSalNextTime10.Text) & COMMA 'int, NOT NULL
        sSQL &= "Disabled = " & SQLNumber(0) & COMMA 'tinyint, NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NOT NULL
        sSQL &= "LastModifyDate = GetDate()" 'datetime, NULL
        sSQL &= " Where "
        sSQL &= "TemplateID = " & SQLString(txtTemplateID.Text)
        Return sSQL
    End Function

    Private Sub txtBaseSalary01NextTime_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBaseSalary01NextTime.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtBaseSalary01_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBaseSalary01.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtBaseSalary02NextTime_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBaseSalary02NextTime.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtBaseSalary02_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBaseSalary02.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtBaseSalary03NextTime_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBaseSalary03NextTime.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtBaseSalary03_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBaseSalary03.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtBaseSalary04NextTime_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBaseSalary04NextTime.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtBaseSalary04_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBaseSalary04.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalNextTime01_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalNextTime01.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalCoefficient01_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalCoefficient01.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalNextTime02_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalNextTime02.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalCoefficient02_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalCoefficient02.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalNextTime03_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalNextTime03.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalCoefficient03_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalCoefficient03.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalNextTime04_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalNextTime04.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalCoefficient04_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalCoefficient04.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalNextTime05_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalNextTime05.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalCoefficient05_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalCoefficient05.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalNextTime06_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalNextTime06.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalCoefficient06_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalCoefficient06.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalNextTime07_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalNextTime07.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalCoefficient07_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalCoefficient07.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalNextTime08_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalNextTime08.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalCoefficient08_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalCoefficient08.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalNextTime09_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalNextTime09.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalCoefficient09_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalCoefficient09.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalNextTime10_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalNextTime10.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalCoefficient10_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalCoefficient10.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtOffSa1NextTime_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOffSa1NextTime.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)

    End Sub

    Private Sub txtSalaryCoefficient_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalaryCoefficient.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtOffSa2NextTime_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOffSa2NextTime.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtSalaryCoefficient2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalaryCoefficient2.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtOffSa1NextTime_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOffSa1NextTime.LostFocus
        If Val(txtOffSa1NextTime.Text) > MaxSmallInt Then
            txtOffSa1NextTime.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtOffSa1NextTime.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtOffSa2NextTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOffSa2NextTime.TextChanged
        If Val(txtOffSa2NextTime.Text) > MaxSmallInt Then
            txtOffSa2NextTime.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtOffSa2NextTime.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtBaseSalary01NextTime_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary01NextTime.LostFocus
        If Val(txtBaseSalary01NextTime.Text) > MaxSmallInt Then
            txtBaseSalary01NextTime.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtBaseSalary01NextTime.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtBaseSalary02NextTime_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary02NextTime.LostFocus
        If Val(txtBaseSalary02NextTime.Text) > MaxSmallInt Then
            txtBaseSalary02NextTime.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtBaseSalary02NextTime.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtBaseSalary03NextTime_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary03NextTime.LostFocus
        If Val(txtBaseSalary03NextTime.Text) > MaxSmallInt Then
            txtBaseSalary03NextTime.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtBaseSalary03NextTime.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtBaseSalary04NextTime_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary04NextTime.LostFocus
        If Val(txtBaseSalary04NextTime.Text) > MaxSmallInt Then
            txtBaseSalary04NextTime.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtBaseSalary04NextTime.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtSalNextTime01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime01.LostFocus
        If Val(txtSalNextTime01.Text) > MaxSmallInt Then
            txtSalNextTime01.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtSalNextTime01.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtSalNextTime02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime02.LostFocus
        If Val(txtSalNextTime02.Text) > MaxSmallInt Then
            txtSalNextTime02.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtSalNextTime02.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtSalNextTime03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime03.LostFocus
        If Val(txtSalNextTime03.Text) > MaxSmallInt Then
            txtSalNextTime03.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtSalNextTime03.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtSalNextTime04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime04.LostFocus
        If Val(txtSalNextTime04.Text) > MaxSmallInt Then
            txtSalNextTime04.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtSalNextTime04.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtSalNextTime05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime05.LostFocus
        If Val(txtSalNextTime05.Text) > MaxSmallInt Then
            txtSalNextTime05.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtSalNextTime05.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtSalNextTime06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime06.LostFocus
        If Val(txtSalNextTime06.Text) > MaxSmallInt Then
            txtSalNextTime06.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtSalNextTime06.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtSalNextTime07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime07.LostFocus
        If Val(txtSalNextTime07.Text) > MaxSmallInt Then
            txtSalNextTime07.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtSalNextTime07.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtSalNextTime08_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime08.LostFocus
        If Val(txtSalNextTime08.Text) > MaxSmallInt Then
            txtSalNextTime08.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtSalNextTime08.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtSalNextTime09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime09.LostFocus
        If Val(txtSalNextTime09.Text) > MaxSmallInt Then
            txtSalNextTime09.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtSalNextTime09.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtSalNextTime10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime10.LostFocus
        If Val(txtSalNextTime10.Text) > MaxSmallInt Then
            txtSalNextTime10.Text = ""
            D99C0008.MsgL3(rL3("So_qua_lon"))
            txtSalNextTime10.Focus()
            Exit Sub
        End If
    End Sub


    Private Sub SetBackColorObligatory()
        txtTemplateID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtTemplateName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDutyID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub txt_NumberFormat()
        txtBaseSalary01.Text = (SQLNumber(txtBaseSalary01.Text, D13Format.DefaultNumber2)).ToString
        txtBaseSalary02.Text = (SQLNumber(txtBaseSalary02.Text, D13Format.DefaultNumber2)).ToString
        txtBaseSalary03.Text = (SQLNumber(txtBaseSalary03.Text, D13Format.DefaultNumber2)).ToString
        txtBaseSalary04.Text = (SQLNumber(txtBaseSalary04.Text, D13Format.DefaultNumber2)).ToString

        txtBaseSalary01NextTime.Text = (SQLNumber(txtBaseSalary01NextTime.Text, D13Format.DefaultNumber0)).ToString
        txtBaseSalary02NextTime.Text = (SQLNumber(txtBaseSalary02NextTime.Text, D13Format.DefaultNumber0)).ToString
        txtBaseSalary03NextTime.Text = (SQLNumber(txtBaseSalary03NextTime.Text, D13Format.DefaultNumber0)).ToString
        txtBaseSalary04NextTime.Text = (SQLNumber(txtBaseSalary04NextTime.Text, D13Format.DefaultNumber0)).ToString

        txtSalaryCoefficient.Text = (SQLNumber(txtSalaryCoefficient.Text, D13Format.DefaultNumber2)).ToString
        txtSalaryCoefficient2.Text = (SQLNumber(txtSalaryCoefficient2.Text, D13Format.DefaultNumber2)).ToString

        txtOffSa1NextTime.Text = (SQLNumber(txtOffSa1NextTime.Text, D13Format.DefaultNumber0)).ToString
        txtOffSa2NextTime.Text = (SQLNumber(txtOffSa2NextTime.Text, D13Format.DefaultNumber0)).ToString

        txtSalCoefficient01.Text = (SQLNumber(txtSalCoefficient01.Text, D13Format.DefaultNumber2)).ToString
        txtSalCoefficient02.Text = (SQLNumber(txtSalCoefficient02.Text, D13Format.DefaultNumber2)).ToString
        txtSalCoefficient03.Text = (SQLNumber(txtSalCoefficient03.Text, D13Format.DefaultNumber2)).ToString
        txtSalCoefficient04.Text = (SQLNumber(txtSalCoefficient04.Text, D13Format.DefaultNumber2)).ToString
        txtSalCoefficient05.Text = (SQLNumber(txtSalCoefficient05.Text, D13Format.DefaultNumber2)).ToString
        txtSalCoefficient06.Text = (SQLNumber(txtSalCoefficient06.Text, D13Format.DefaultNumber2)).ToString
        txtSalCoefficient07.Text = (SQLNumber(txtSalCoefficient07.Text, D13Format.DefaultNumber2)).ToString
        txtSalCoefficient08.Text = (SQLNumber(txtSalCoefficient08.Text, D13Format.DefaultNumber2)).ToString
        txtSalCoefficient09.Text = (SQLNumber(txtSalCoefficient09.Text, D13Format.DefaultNumber2)).ToString
        txtSalCoefficient10.Text = (SQLNumber(txtSalCoefficient10.Text, D13Format.DefaultNumber2)).ToString

        txtSalNextTime01.Text = (SQLNumber(txtSalNextTime01.Text, D13Format.DefaultNumber0)).ToString
        txtSalNextTime02.Text = (SQLNumber(txtSalNextTime02.Text, D13Format.DefaultNumber0)).ToString
        txtSalNextTime03.Text = (SQLNumber(txtSalNextTime03.Text, D13Format.DefaultNumber0)).ToString
        txtSalNextTime04.Text = (SQLNumber(txtSalNextTime04.Text, D13Format.DefaultNumber0)).ToString
        txtSalNextTime05.Text = (SQLNumber(txtSalNextTime05.Text, D13Format.DefaultNumber0)).ToString
        txtSalNextTime06.Text = (SQLNumber(txtSalNextTime06.Text, D13Format.DefaultNumber0)).ToString
        txtSalNextTime07.Text = (SQLNumber(txtSalNextTime07.Text, D13Format.DefaultNumber0)).ToString
        txtSalNextTime08.Text = (SQLNumber(txtSalNextTime08.Text, D13Format.DefaultNumber0)).ToString
        txtSalNextTime09.Text = (SQLNumber(txtSalNextTime09.Text, D13Format.DefaultNumber0)).ToString
        txtSalNextTime10.Text = (SQLNumber(txtSalNextTime10.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtBaseSalary01_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary01.Validated
        txtBaseSalary01.Text = (SQLNumber(txtBaseSalary01.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtBaseSalary02_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary02.Validated
        txtBaseSalary02.Text = (SQLNumber(txtBaseSalary02.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtBaseSalary03_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary03.Validated
        txtBaseSalary03.Text = (SQLNumber(txtBaseSalary03.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtBaseSalary04_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary04.Validated
        txtBaseSalary04.Text = (SQLNumber(txtBaseSalary04.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtBaseSalary01NextTime_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary01NextTime.Validated
        txtBaseSalary01NextTime.Text = (SQLNumber(txtBaseSalary01NextTime.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtBaseSalary02NextTime_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary02NextTime.Validated
        txtBaseSalary02NextTime.Text = (SQLNumber(txtBaseSalary02NextTime.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtBaseSalary03NextTime_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary03NextTime.Validated
        txtBaseSalary03NextTime.Text = (SQLNumber(txtBaseSalary03NextTime.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtBaseSalary04NextTime_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBaseSalary04NextTime.Validated
        txtBaseSalary04NextTime.Text = (SQLNumber(txtBaseSalary04NextTime.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtSalNextTime01_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime01.Validated
        txtSalNextTime01.Text = (SQLNumber(txtSalNextTime01.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtSalNextTime02_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime02.Validated
        txtSalNextTime02.Text = (SQLNumber(txtSalNextTime02.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtSalNextTime03_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime03.Validated
        txtBaseSalary04NextTime.Text = (SQLNumber(txtBaseSalary04NextTime.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtSalNextTime04_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime04.Validated
        txtSalNextTime04.Text = (SQLNumber(txtSalNextTime04.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtSalNextTime05_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime05.Validated
        txtBaseSalary04NextTime.Text = (SQLNumber(txtBaseSalary04NextTime.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtSalNextTime06_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime06.Validated
        txtSalNextTime06.Text = (SQLNumber(txtSalNextTime06.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtSalNextTime07_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime07.Validated
        txtSalNextTime07.Text = (SQLNumber(txtSalNextTime07.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtSalNextTime08_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime08.Validated
        txtSalNextTime08.Text = (SQLNumber(txtSalNextTime08.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtSalNextTime09_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime09.Validated
        txtSalNextTime09.Text = (SQLNumber(txtSalNextTime09.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtSalNextTime10_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalNextTime10.Validated
        txtSalNextTime10.Text = (SQLNumber(txtSalNextTime10.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtSalCoefficient01_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalCoefficient01.Validated
        txtSalCoefficient01.Text = (SQLNumber(txtSalCoefficient01.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtSalCoefficient02_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalCoefficient02.Validated
        txtSalCoefficient02.Text = (SQLNumber(txtSalCoefficient02.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtSalCoefficient03_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalCoefficient03.Validated
        txtSalCoefficient03.Text = (SQLNumber(txtSalCoefficient03.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtSalCoefficient04_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalCoefficient04.Validated
        txtSalCoefficient04.Text = (SQLNumber(txtSalCoefficient04.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtSalCoefficient05_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalCoefficient05.Validated
        txtSalCoefficient05.Text = (SQLNumber(txtSalCoefficient05.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtSalCoefficient06_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalCoefficient06.Validated
        txtSalCoefficient06.Text = (SQLNumber(txtSalCoefficient06.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtSalCoefficient07_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalCoefficient07.Validated
        txtSalCoefficient07.Text = (SQLNumber(txtSalCoefficient07.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtSalCoefficient08_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalCoefficient08.Validated
        txtSalCoefficient08.Text = (SQLNumber(txtSalCoefficient08.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtSalCoefficient09_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalCoefficient09.Validated
        txtSalCoefficient09.Text = (SQLNumber(txtSalCoefficient09.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtSalCoefficient10_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalCoefficient10.Validated
        txtSalCoefficient10.Text = (SQLNumber(txtSalCoefficient10.Text, D13Format.DefaultNumber2)).ToString
    End Sub

    Private Sub txtOffSa1NextTime_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOffSa1NextTime.Validated
        txtOffSa1NextTime.Text = (SQLNumber(txtOffSa1NextTime.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub txtOffSa2NextTime_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOffSa2NextTime.Validated
        txtOffSa2NextTime.Text = (SQLNumber(txtOffSa2NextTime.Text, D13Format.DefaultNumber0)).ToString
    End Sub

    Private Sub optDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDate.Click
        c1dateDate.Enabled = True
        c1dateDate.Value = Date.Today
    End Sub

    Private Sub optDateJoined_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDateJoined.Click
        c1dateDate.Enabled = False
    End Sub

    Private Sub optDateRecruited_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDateRecruited.Click
        c1dateDate.Enabled = False
    End Sub

    Private Sub optExamineDateEnd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optExamineDateEnd.Click
        c1dateDate.Enabled = False
    End Sub

End Class