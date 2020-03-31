Public Class D25F4060
	Dim report As D99C2003
    Private DT As DataTable
    Private _DivisionID As String = ""
    Public Property DivisionID() As String
        Get
            Return _DivisionID
        End Get
        Set(ByVal value As String)
            _DivisionID = Value
        End Set
    End Property

    Private _DepartmentID As String = ""
    Public Property DepartmentID() As String
        Get
            Return _DepartmentID
        End Get
        Set(ByVal value As String)
            _DepartmentID = Value
        End Set
    End Property
    Private _TeamID As String = ""
    Public Property TeamID() As String
        Get
            Return _TeamID
        End Get
        Set(ByVal value As String)
            _TeamID = Value
        End Set
    End Property
    Private _RecruitPlanID As String = ""
    Public Property RecruitPlanID() As String
        Get
            Return _RecruitPlanID
        End Get
        Set(ByVal value As String)
            _RecruitPlanID = Value
        End Set
    End Property
    Private _PlanDate As String = ""
    Public Property PlanDate() As String
        Get
            Return _PlanDate
        End Get
        Set(ByVal value As String)
            _PlanDate = Value
        End Set
    End Property

    Private bData As Boolean = False
    Public Property Data() As Boolean
        Get
            Return bData
        End Get
        Set(ByVal value As Boolean)
            bData = value
        End Set
    End Property

    Private kt As Boolean = False
    Dim dtPeriod As DataTable

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P4060
    '# Created User: Lý Anh Vĩ
    '# Created Date: 19/04/2007 10:26:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P4060() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P4060 "
        sSQL &= SQLDateSave(c1dateDate.Text) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= SQLString(IIf(tdbcCustomReportID.Text <> "", txtCustomReportName.Text, txtReportName.Text)) & COMMA 'Title, varchar[250], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLString(tdbcRecruitPlanID.SelectedValue) & COMMA 'RecruitPlanID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcDepartmentID.Text) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcTeamID.Text) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(optRecruitment.Checked = True, 0, 1)) 'ModeData, tinyint, NOT NULL
        Return sSQL
    End Function


    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
      
        LoadCboDivisionIDReport(tdbcDivisionID, "D09", True, gbUnicode) 'ADD 25/06/08

        MyLoadTdbcCustomizeReport(tdbcCustomReportID, Me.Name, gbUnicode)
    End Sub

    Private Sub LoadDepartmentIDCombo(ByVal ID As String)
        Dim sSQL As String = ""
        'Load tdbcDepartmentID
        If geLanguage = EnumLanguage.Vietnamese Then
            sSQL = "Select 0 as DisplayOrder,'%' As DepartmentID, " & AllName & " As DepartmentName" & vbCrLf
        Else
            sSQL = "Select 0 as DisplayOrder,'%' As DepartmentID, 'All' As DepartmentName" & vbCrLf
        End If
        sSQL &= "Union Select 1 as DisplayOrder,DepartmentID, DepartmentName" & UnicodeJoin(gbUnicode) & " as DepartmentName From D91T0012 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Case When '%' = " & SQLString(ID) & " Then '%' Else DivisionID End = " & SQLString(ID) & vbCrLf
        sSQL &= "And Disabled = 0 " & vbCrLf
        sSQL &= " Order by DisplayOrder, DepartmentID"
        LoadDataSource(tdbcDepartmentID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTeamIDCombo(ByVal ID As String)
        Dim sSQL As String = ""
        If geLanguage = EnumLanguage.Vietnamese Then
            sSQL = "Select 0 as DisplayOrder,'%' as TeamID, " & AllName & " as TeamName Union Select 1 as DisplayOrder,TeamID, TeamName" & UnicodeJoin(gbUnicode) & " as TeamName From D09T0227 WITH(NOLOCK) " & vbCrLf
        Else
            sSQL = "Select 0 as DisplayOrder,'%' as TeamID, 'All' as TeamName Union Select 1 as DisplayOrder,TeamID, TeamName" & UnicodeJoin(gbUnicode) & " as TeamName From D09T0227 WITH(NOLOCK) " & vbCrLf
        End If

        sSQL &= "Where ((Case when " & SQLString(ID) & " = '%' then '%'" & vbCrLf
        sSQL &= "Else DepartmentID End) = " & SQLString(ID) & vbCrLf
        sSQL &= ") And Disabled = 0 Order by DisplayOrder, TeamID"
        LoadDataSource(tdbcTeamID, sSQL, gbUnicode)
    End Sub

    Dim bAllowLoadRecruitPlan As Boolean = False 'biến để chặn load thừa cho TdbcRecruitPlan
    Private Sub LoadTDBCRecruitPlan(ByVal sDiv As String)
        If Not bAllowLoadRecruitPlan Then Exit Sub


        Dim sSQL As String = ""
        sSQL = "Select VoucherNo, RecruitPlanName" & UnicodeJoin(gbUnicode) & " as RecruitPlanName, RecruitPlanID From D25T2030 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 And Case When '%' = " & SQLString(sDiv) & " Then '%' Else DivisionID End = " & SQLString(sDiv) & vbCrLf
        sSQL &= "And (TranMonth + TranYear * 100) Between ( " & SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & " + " & SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & " * 100)" & vbCrLf
        sSQL &= "And (" & SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & " + " & SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & " * 100)" & vbCrLf
        sSQL &= "Order by RecruitPlanID"
        LoadDataSource(tdbcRecruitPlanID, sSQL, gbUnicode)

        'tdbcRecruitPlanID.SelectedIndex = 0
    End Sub


#Region "Events tdbcDivisionID with txtDivisionName"

    Private Sub tdbcDivisionID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
            txtDivisionName.Text = ""
        End If
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If tdbcDivisionID.Text <> "" Then
            txtDivisionName.Text = tdbcDivisionID.Columns(1).Value.ToString
        Else
            txtDivisionName.Text = ""
        End If
        bAllowLoadRecruitPlan = False
        LoadDepartmentIDCombo(tdbcDivisionID.Text)


        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, dtPeriod, tdbcDivisionID.Text)

        If dtPeriod.Select("TranMonth = " & SQLNumber(giTranMonth) & " And TranYear = " & SQLNumber(giTranYear) & "And DivisionID = " & SQLString(tdbcDivisionID.Text)).Length > 0 Then
            tdbcPeriodFrom.SelectedValue = Format(giTranMonth, "00") & "/" & giTranYear.ToString
            tdbcPeriodTo.SelectedValue = Format(giTranMonth, "00") & "/" & giTranYear.ToString
        Else
            tdbcPeriodFrom.AutoSelect = True
            tdbcPeriodTo.AutoSelect = True
            'If tdbcPeriodFrom.SelectedValue Is Nothing Then tdbcPeriodFrom.SelectedIndex = 0
            'If tdbcPeriodTo.SelectedValue Is Nothing Then tdbcPeriodTo.SelectedIndex = 0
        End If
      
        bAllowLoadRecruitPlan = True
        LoadTDBCRecruitPlan(tdbcDivisionID.Text)
      
    End Sub

    Private Sub tdbcDivisionID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcDivisionID.Text = ""
            txtDivisionName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcTeamID with txtTeamName"

    Private Sub tdbcTeamID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.Close
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
            txtTeamName.Text = ""
        End If
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        If tdbcTeamID.Text <> "" Then
            txtTeamName.Text = tdbcTeamID.Columns(1).Value.ToString
        Else
            txtTeamName.Text = ""
        End If
    End Sub

    Private Sub tdbcTeamID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcTeamID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcTeamID.Text = ""
            txtTeamName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcDepartmentID with txtDepartmentName"

    Private Sub tdbcDepartmentID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Close
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
            txtDepartmentName.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If tdbcDepartmentID.Text <> "" Then
            txtDepartmentName.Text = tdbcDepartmentID.Columns(1).Value.ToString
        Else
            txtDepartmentName.Text = ""
        End If
        LoadTeamIDCombo(tdbcDepartmentID.Text)
        'tdbcTeamID.SelectedIndex = 0
    End Sub

    Private Sub tdbcDepartmentID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDepartmentID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcDepartmentID.Text = ""
            txtDepartmentName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcRecruitPlanID with txtRecruitPlanName"

    Private Sub tdbcRecruitPlanID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecruitPlanID.Close
        If tdbcRecruitPlanID.FindStringExact(tdbcRecruitPlanID.Text) = -1 Then
            tdbcRecruitPlanID.Text = ""
            txtRecruitPlanName.Text = ""
        End If
    End Sub

    Private Sub tdbcRecruitPlanID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecruitPlanID.SelectedValueChanged
        If tdbcRecruitPlanID.SelectedValue Is Nothing Then
            txtRecruitPlanName.Text = ""
            Exit Sub
        End If
        txtRecruitPlanName.Text = tdbcRecruitPlanID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcRecruitPlanID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecruitPlanID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcRecruitPlanID.Text = ""
            txtRecruitPlanName.Text = ""
        End If
    End Sub

#End Region


    Private Sub SetBackColorObligatory()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecruitPlanID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY

        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub D25F4060_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        FormKeyPress(sender, e)
    End Sub


    Private Sub D25F4060_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        SetBackColorObligatory()
        Loadlanguage()

        dtPeriod = LoadTablePeriodReport("D09")
        LoadTDBCombo()
        If _DivisionID <> "" Then
            tdbcDivisionID.SelectedValue = _DivisionID
        Else
            tdbcDivisionID.SelectedValue = gsDivisionID
        End If

        If _DepartmentID <> "" Then
            tdbcDepartmentID.Text = _DepartmentID
        Else
            tdbcDepartmentID.Text = "%"
        End If
        'If _PlanDate <> "" Then
        '    c1dateDateFrom.Value = _PlanDate
        '    kt = True
        '    c1dateDateTo.Value = _PlanDate
        'Else
        '    c1dateDateFrom.Value = Now.Date
        '    kt = True
        '    c1dateDateTo.Value = Now.Date
        'End If
        If _RecruitPlanID <> "" Then
            tdbcRecruitPlanID.SelectedValue = _RecruitPlanID
        Else
            ' tdbcRecruitPlanID.SelectedIndex = 0
        End If
        If _TeamID <> "" Then
            tdbcTeamID.SelectedValue = _TeamID
        Else
            tdbcTeamID.SelectedValue = "%"
        End If

        If bData = True Then
            optInspectRecruit.Checked = True
        End If

        c1dateDate.Value = Now.Date

        SetText()
        InputbyUnicode(Me, gbUnicode)
        InputDateCustomFormat(c1dateDate)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Bao_cao_ke_hoach_tuyen_dung_-_D25F4060") & UnicodeCaption(gbUnicode) 'BÀo cÀo kÕ hoÁch tuyÓn dóng - D25F4060
        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi") 'Mã đơn vị
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm

        lblRecruitProposalID.Text = rl3("Ke_hoach_TD") 'Kế hoạch TD
        lblteDate.Text = rl3("Ngay_lap") 'Ngày lập

        lblReportID.Text = rl3("Ma_bao_cao") 'Mã báo cáo
        '================================================================ 

        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnPrint.Text = rl3("_In") '&In
        '================================================================ 
        optInspectRecruit.Text = rl3("Ke_hoach_da_duyet") 'Kế hoạch đã duyệt
        optRecruitment.Text = rl3("Ke_hoach_TD") 'Kế hoạch
        '================================================================ 
        grpData.Text = rl3("Du_lieu") 'Dữ liệu      
        '================================================================ 
        tdbcRecruitPlanID.Columns("VoucherNo").Caption = rl3("Ma") 'Mã phiếu
        tdbcRecruitPlanID.Columns("RecruitPlanName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Phòng ban
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Dien_giai") 'Tên phòng ban
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma")  'Mã đơn vị
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Dien_giai") 'Đơn vị


        lblPeriodFrom.Text = rl3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodTo.Columns("Period").Caption = rl3("Ky") 'Kỳ

        lblCustomReportID.Text = rl3("Dac_thu") 'Đặc thù
        lblReportID.Text = rl3("Mau_chuan") 'Mẫu chuẩn

        tdbcCustomReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcCustomReportID.Columns("Title").Caption = rl3("Ten") 'Tên

    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Function AllowPrint() As Boolean
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ma_don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If

        If tdbcPeriodFrom.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ky"))
            tdbcPeriodFrom.Focus()
            Return False
        End If
        If tdbcPeriodTo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ky"))
            tdbcPeriodTo.Focus()
            Return False
        End If


        If tdbcRecruitPlanID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ke_hoach_TD"))
            tdbcRecruitPlanID.Focus()
            Return False
        End If


        Return True
    End Function


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        If Not AllowPrint() Then Exit Sub
        btnPrint.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        'Dim report As New D99C1003

		'************************************ 'D99C1004
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = ""
        Dim sSubReportName As String = "D09R6000"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        If tdbcCustomReportID.Text = "" Then
            sReportName = txtReportID.Text
        Else
            sReportName = tdbcCustomReportID.Text
        End If
        sPathReport = UnicodeGetReportPath(gbUnicode, 0, tdbcCustomReportID.Text) & sReportName & ".rpt"
        sReportCaption = rl3("In_ke_hoach_tuyen_dung") & " - " & sReportName
        sSQL = SQLStoreD25P4060()
        sSQLSub = "Select * from D09V0009"
        UnicodeSubReport(sSubReportName, sSQLSub, CbVal(tdbcDivisionID), gbUnicode)
        With report
            .OpenConnection(conn)
            '.AddParameter("?????", "?????")
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True
    End Sub

#Region "Events tdbcCustomReportID with txtCustomReportName"

    Private Sub tdbcCustomReportID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomReportID.Close
        If tdbcCustomReportID.FindStringExact(tdbcCustomReportID.Text) = -1 Then
            tdbcCustomReportID.Text = ""
            txtCustomReportName.Text = ""
        End If
    End Sub

    Private Sub tdbcCustomReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomReportID.SelectedValueChanged
        txtCustomReportName.Text = tdbcCustomReportID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcCustomReportID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcCustomReportID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcCustomReportID.Text = ""
            txtCustomReportName.Text = ""
        End If
    End Sub

#End Region
#Region "Events tdbcPeriodFrom"

    Private Sub tdbcPeriodFrom_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.Close
        If tdbcPeriodFrom.FindStringExact(tdbcPeriodFrom.Text) = -1 Then tdbcPeriodFrom.Text = ""
    End Sub

    Private Sub tdbcPeriodFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPeriodFrom.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPeriodFrom.Text = ""
    End Sub

    Private Sub tdbcPeriodFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.SelectedValueChanged
        LoadTDBCRecruitPlan(tdbcDivisionID.Text)

    End Sub
#End Region

#Region "Events tdbcPeriodTo"

    Private Sub tdbcPeriodTo_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.Close
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then tdbcPeriodTo.Text = ""
    End Sub

    Private Sub tdbcPeriodTo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPeriodTo.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPeriodTo.Text = ""
    End Sub


    Private Sub tdbcPeriodTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.SelectedValueChanged
        LoadTDBCRecruitPlan(tdbcDivisionID.Text)
    End Sub
#End Region

    Private Sub SetText()
        If optRecruitment.Checked Then
            txtReportID.Text = "D25R4051"
            txtReportName.Text = rl3("KE_HOACH_TUYEN_DUNGV") 'KEÁ HOAÏCH TUYEÅN DUÏNG
        Else
            txtReportID.Text = "D25R4061"
            txtReportName.Text = rl3("KE_HOACH_TUYEN_DUNG_DA_DUYET") 'KEÁ HOAÏCH TUYEÅN DUÏNG ÑAÕ DUYEÄT
        End If
    End Sub

    Private Sub optInspectRecruit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optInspectRecruit.CheckedChanged
        SetText()
    End Sub

    Private Sub optRecruitment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRecruitment.CheckedChanged
        SetText()
    End Sub
End Class