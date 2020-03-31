Imports System
Public Class D25F2052
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Parameters"
    Private _transID As String
    Public Property TransID() As String
        Get
            Return _transID
        End Get
        Set(ByVal Value As String)
            _transID = Value
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

    Private _workingStatusID As String
    Public WriteOnly Property WorkingStatusID() As String
        Set(ByVal Value As String)
            _workingStatusID = Value
        End Set
    End Property
#End Region

    Private Sub D25F2052_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If

        If e.Alt = True And (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
            TabM.SelectedIndex = 0
            TabM.Focus()
        End If
        If e.Alt = True And (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
            TabM.SelectedIndex = 1
            TabM.Focus()
        End If

    End Sub

    Private Sub D25F2052_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Loadlanguage()
        SetBackColorObligatory()
        LoadTDBComBo()
        LoadData()
        '******************
        btnSave.Enabled = ReturnPermission("D25F3060") > EnumPermission.View
        '******************
        InputbyUnicode(Me, gbUnicode)
InputDateCustomFormat(c1dateBeginDate)
        SetResolutionForm(Me)
    End Sub

    Private Sub SetBackColorObligatory()
        c1dateBeginDate.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Thong_tin_trung_tuyen_-_D25F2052") & UnicodeCaption(gbUnicode) 'Th¤ng tin tròng tuyÓn - D25F2052
        '================================================================ 
        lblWorkingPlace.Text = rl3("Dia_diem") 'Địa điểm
        lblWorkID.Text = rl3("Cong_viec") 'Công việc
        lblteBeginDate.Text = rl3("Ngay_vao_lam") 'Ngày vào làm
        lblWorkingHours.Text = rl3("Thoi_gian_lam_viec") 'Thời gian làm việc
        lblTrialPeriod.Text = rl3("Thoi_gian_thu_viec") 'Thời gian thử việc
        lblMainSalary.Text = rl3("Luong_chinh_thuc") 'Lương chính thức
        lblTrialSalary.Text = rl3("Luong_thu_viec") 'Lương thử việc
        lblAllowance01.Text = rl3("Phu_cap") & " 01" 'Phụ cấp01
        lblAllowance02.Text = rl3("Phu_cap") & " 02" 'Phụ cấp02
        lblAllowance03.Text = rl3("Phu_cap") & " 03" 'Phụ cấp03
        lblAllowance04.Text = rl3("Phu_cap") & " 04" 'Phụ cấp04
        lblAllowance05.Text = rl3("Phu_cap") & " 05" 'Phụ cấp05
        lblCurrencyID.Text = rl3("Loai_tien") 'Loại tiền
        lblNote01.Text = rl3("Ghi_chu") & " 01" 'Ghi chú 01
        lblNote02.Text = rl3("Ghi_chu") & " 02" 'Ghi chú 02
        lblNote03.Text = rl3("Ghi_chu") & " 03" 'Ghi chú 03
        lblNote04.Text = rl3("Ghi_chu") & " 04" 'Ghi chú 04
        lblNote05.Text = rl3("Ghi_chu") & " 05" 'Ghi chú 05
        lblNote06.Text = rl3("Ghi_chu") & " 06" 'Ghi chú 01
        lblNote07.Text = rl3("Ghi_chu") & " 07" 'Ghi chú 02
        lblNote08.Text = rl3("Ghi_chu") & " 08" 'Ghi chú 03
        lblNote09.Text = rl3("Ghi_chu") & " 09" 'Ghi chú 04
        lblNote10.Text = rl3("Ghi_chu") & " 10" 'Ghi chú 05
        lblDutyID.Text = rl3("Chuc_vu")
        lblModule.Text = rl3("Module_su_dung")

        lblWorkingStatusID.Text = rl3("Hinh_thuc_lam_viec")
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 

        '================================================================ 
        TabPage1.Text = "1."
        TabPage2.Text = "2."
        '================================================================ 
        tdbcWorkID.Columns("WorkID").Caption = rl3("Ma") 'Mã
        tdbcWorkID.Columns("WorkName").Caption = rl3("Ten") 'Tên
        tdbcMainSalary.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcMainSalary.Columns("Short").Caption = rl3("Dien_giai") 'Diễn giải

        tdbcTrialSalary.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcTrialSalary.Columns("Short").Caption = rl3("Dien_giai") 'Diễn giải

        tdbcAllowance01.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcAllowance01.Columns("Short").Caption = rl3("Dien_giai") 'Diễn giải

        tdbcAllowance02.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcAllowance02.Columns("Short").Caption = rl3("Dien_giai") 'Diễn giải

        tdbcAllowance03.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcAllowance03.Columns("Short").Caption = rl3("Dien_giai") 'Diễn giải

        tdbcAllowance04.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcAllowance04.Columns("Short").Caption = rl3("Dien_giai") 'Diễn giải

        tdbcAllowance05.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcAllowance05.Columns("Short").Caption = rl3("Dien_giai") 'Diễn giải

        tdbcCurrencyID.Columns("CurrencyID").Caption = rl3("Ma") 'Mã
        tdbcCurrencyID.Columns("CurrencyName").Caption = rl3("Dien_giai") 'Diễn giải

        tdbcWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma")
        tdbcWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten")

        chkIsUseD15.Text = rl3("Quan_ly_phep") 'Quản lý phép
        chkIsUseD21.Text = rl3("Y_te_bao_hiem") 'Y tế bảo hiểm
    End Sub

    Private Sub LoadTDBComBo()
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************

        Dim sSQL As String = ""

        'TdbcWorkID
        sSQL &= " SELECT 	WorkID, WorkName" & sUnicode & " AS WorkName" & vbCrLf
        sSQL &= " FROM 	D09T0224  WITH(NOLOCK) " & vbCrLf
        sSQL &= " WHERE	Disabled = 0" & vbCrLf
        sSQL &= " ORDER BY 	WorkID" & vbCrLf
        LoadDataSource(tdbcWorkID, sSQL, gbUnicode)

        'TdbcMainSalary, TrialSalary
        sSQL = " SELECT 	Code, Short" & sUnicode & " AS Short, Disabled" & vbCrLf
        sSQL &= " FROM      D13T9000  WITH(NOLOCK) " & vbCrLf
        sSQL &= " WHERE     Type = 'SALBA'  " & vbCrLf
        sSQL &= "           AND Disabled = 0" & vbCrLf
        sSQL &= " ORDER BY 	Code" & vbCrLf
        Dim dtSalary As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcMainSalary, dtSalary.Copy, gbUnicode)
        LoadDataSource(tdbcTrialSalary, dtSalary.Copy, gbUnicode)


        sSQL = " SELECT 	Code, Short" & sUnicode & " AS Short, Disabled " & vbCrLf
        sSQL &= " FROM      D13T9000  WITH(NOLOCK) " & vbCrLf
        sSQL &= " WHERE     Type = 'SALCE'  " & vbCrLf
        sSQL &= "           AND Disabled = 0" & vbCrLf
        sSQL &= " ORDER BY  Code" & vbCrLf

        Dim dtAllowance As DataTable = ReturnDataTable(sSQL)
        'TdbcAllowanceXX
        LoadDataSource(tdbcAllowance01, dtAllowance.Copy, gbUnicode)
        LoadDataSource(tdbcAllowance02, dtAllowance.Copy, gbUnicode)
        LoadDataSource(tdbcAllowance03, dtAllowance.Copy, gbUnicode)
        LoadDataSource(tdbcAllowance04, dtAllowance.Copy, gbUnicode)
        LoadDataSource(tdbcAllowance05, dtAllowance.Copy, gbUnicode)

        LoadCurrencyID(tdbcCurrencyID, gbUnicode)

        'Load tdbcWorkingStatusID
        sSQL = "Select 0 as DisplayOrder,'%' as WorkingStatusID, " & sLanguage & " As WorkingStatusName" & vbCrLf
        sSQL &= "Union Select 1 as DisplayOrder,WorkingStatusID, WorkingStatusName" & sUnicode & " AS WorkingStatusName From D09T0070  WITH(NOLOCK) Where Disabled = 0 Order by DisplayOrder, WorkingStatusID"
        LoadDataSource(tdbcWorkingStatusID, sSQL, gbUnicode)

        LoadTdbcDutyID(tdbcDutyID)
    End Sub

    Private Sub LoadData()

        Dim dt As DataTable = ReturnDataTable(SQLStoreD25P2052)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)

            tdbcWorkID.SelectedValue = dr("WorkID")
            c1dateBeginDate.Value = SQLDateTimeShow(dr("BeginDate"))
            tdbcWorkingStatusID.SelectedValue = dr("WorkingStatusID")
            txtWorkingPlace.Text = dr("WorkingPlace").ToString
            txtWorkingHours.Text = dr("WorkingHours").ToString
            txtTrialPeriod.Text = dr("TrialPeriod").ToString
            tdbcMainSalary.SelectedValue = dr("MainSalary")
            tdbcTrialSalary.SelectedValue = dr("TrialSalary")
            tdbcCurrencyID.SelectedValue = dr("CurrencyID")
            tdbcDutyID.SelectedValue = dr("DutyID")
            txtMainSalaryName.Text = SQLNumber(dr("MainValue").ToString, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
            txtTrialSalaryName.Text = SQLNumber(dr("TrialValue").ToString, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
            tdbcAllowance01.SelectedValue = dr("Allowance01")
            tdbcAllowance02.SelectedValue = dr("Allowance02")
            tdbcAllowance03.SelectedValue = dr("Allowance03")
            tdbcAllowance04.SelectedValue = dr("Allowance04")
            tdbcAllowance05.SelectedValue = dr("Allowance05")
            txtAllowance01Name.Text = SQLNumber(dr("Value01").ToString, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
            txtAllowance02Name.Text = SQLNumber(dr("Value02").ToString, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
            txtAllowance03Name.Text = SQLNumber(dr("Value03").ToString, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
            txtAllowance04Name.Text = SQLNumber(dr("Value04").ToString, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
            txtAllowance05Name.Text = SQLNumber(dr("Value05").ToString, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))

            txtNote01.Text = dr("Note01").ToString
            txtNote02.Text = dr("Note02").ToString
            txtNote03.Text = dr("Note03").ToString
            txtNote04.Text = dr("Note04").ToString
            txtNote05.Text = dr("Note05").ToString
            txtNote06.Text = dr("Note06").ToString
            txtNote07.Text = dr("Note07").ToString
            txtNote08.Text = dr("Note08").ToString
            txtNote09.Text = dr("Note09").ToString
            txtNote10.Text = dr("Note10").ToString

            chkIsUseD15.Checked = L3Bool(dr("IsUseD15"))
            chkIsUseD21.Checked = L3Bool(dr("IsUseD21"))
        End If

        If tdbcWorkingStatusID.Text = "" Then
            tdbcWorkingStatusID.SelectedValue = _workingStatusID
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If c1dateBeginDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ngay_vao_lam"))
            c1dateBeginDate.Focus()
            Return False
        End If
        If tdbcCurrencyID.Text.Trim = "" AndAlso (tdbcMainSalary.Text <> "" Or tdbcTrialSalary.Text <> "" Or tdbcAllowance01.Text <> "" Or tdbcAllowance02.Text <> "" Or tdbcAllowance03.Text <> "" Or tdbcAllowance04.Text <> "" Or tdbcAllowance05.Text <> "") Then
            D99C0008.MsgNotYetChoose(rL3("Loai_tien"))
            tdbcCurrencyID.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLUpdateD25T2061)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


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
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcDutyID.Text = ""
            txtDutyName.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcWorkID with txtWorkName"

    Private Sub tdbcWorkID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkID.Close
        If tdbcWorkID.FindStringExact(tdbcWorkID.Text) = -1 Then
            tdbcWorkID.Text = ""
            txtWorkName.Text = ""
        End If
    End Sub

    Private Sub tdbcWorkID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkID.SelectedValueChanged
        txtWorkName.Text = tdbcWorkID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcWorkID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcWorkID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcWorkID.Text = ""
            txtWorkName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcMainSalary with txtMainSalaryName"

    Private Sub tdbcMainSalary_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMainSalary.LostFocus
        If tdbcMainSalary.FindStringExact(tdbcMainSalary.Text) = -1 Then
            tdbcMainSalary.Text = ""
            txtMainSalaryName.Text = ""
        End If
    End Sub

    Private Sub tdbcMainSalary_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMainSalary.SelectedValueChanged
        If tdbcMainSalary.Text = "" Or tdbcMainSalary Is Nothing Then
            txtMainSalaryName.Enabled = False
            txtMainSalaryName.Text = ""
            Exit Sub
        End If
        txtMainSalaryName.Enabled = True
    End Sub

#End Region

#Region "Events tdbcTrialSalary with txtTrialSalaryName"

    Private Sub tdbcTrialSalary_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTrialSalary.LostFocus
        If tdbcTrialSalary.FindStringExact(tdbcTrialSalary.Text) = -1 Then
            tdbcTrialSalary.Text = ""
            txtTrialSalaryName.Text = ""
        End If
    End Sub

    Private Sub tdbcTrialSalary_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTrialSalary.SelectedValueChanged
        If tdbcTrialSalary.SelectedValue Is Nothing Or tdbcTrialSalary.Text = "" Then
            txtTrialSalaryName.Text = ""
            txtTrialSalaryName.Enabled = False
            Exit Sub
        End If
        txtTrialSalaryName.Enabled = True
    End Sub

#End Region

#Region "Events tdbcAllowance01 with txtAllowance01Name"

    Private Sub tdbcAllowance01_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAllowance01.Close
        If tdbcAllowance01.FindStringExact(tdbcAllowance01.Text) = -1 Then
            tdbcAllowance01.Text = ""
            txtTrialSalaryName.Text = ""
        End If
    End Sub

    Private Sub tdbcAllowance01_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAllowance01.SelectedValueChanged
        If tdbcAllowance01.SelectedValue Is Nothing Or tdbcAllowance01.Text = "" Then
            txtAllowance01Name.Text = ""
            txtAllowance01Name.Enabled = False
            Exit Sub
        End If
        txtAllowance01Name.Enabled = True
    End Sub

    Private Sub tdbcAllowance01_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAllowance01.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcAllowance01.Text = ""
            txtAllowance01Name.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcAllowance02 with txtAllowance02Name"

    Private Sub tdbcAllowance02_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAllowance02.Close
        If tdbcAllowance02.FindStringExact(tdbcAllowance02.Text) = -1 Then
            tdbcAllowance02.Text = ""
            txtAllowance02Name.Text = ""
        End If
    End Sub

    Private Sub tdbcAllowance02_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAllowance02.SelectedValueChanged
        If tdbcAllowance02.SelectedValue Is Nothing Or tdbcAllowance02.Text = "" Then
            txtAllowance02Name.Text = ""
            txtAllowance02Name.Enabled = False
            Exit Sub
        End If
        txtAllowance02Name.Enabled = True
    End Sub

    Private Sub tdbcAllowance02_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAllowance02.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcAllowance02.Text = ""
            txtAllowance02Name.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcAllowance03 with txtAllowance03Name"

    Private Sub tdbcAllowance03_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAllowance03.Close
        If tdbcAllowance03.FindStringExact(tdbcAllowance03.Text) = -1 Then
            tdbcAllowance03.Text = ""
            txtAllowance03Name.Text = ""
        End If
    End Sub

    Private Sub tdbcAllowance03_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAllowance03.SelectedValueChanged
        If tdbcAllowance03.SelectedValue Is Nothing Or tdbcAllowance03.Text = "" Then
            txtAllowance03Name.Text = ""
            txtAllowance03Name.Enabled = False
            Exit Sub
        End If
        txtAllowance03Name.Enabled = True
    End Sub

    Private Sub tdbcAllowance03_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAllowance03.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcAllowance03.Text = ""
            txtAllowance03Name.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcAllowance04 with txtAllowance04Name"

    Private Sub tdbcAllowance04_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAllowance04.Close
        If tdbcAllowance04.FindStringExact(tdbcAllowance04.Text) = -1 Then
            tdbcAllowance04.Text = ""
            txtAllowance04Name.Text = ""
        End If
    End Sub

    Private Sub tdbcAllowance04_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAllowance04.SelectedValueChanged
        If tdbcAllowance04.SelectedValue Is Nothing Or tdbcAllowance04.Text = "" Then
            txtAllowance04Name.Text = ""
            txtAllowance04Name.Enabled = False
            Exit Sub
        End If
        txtAllowance04Name.Enabled = True
    End Sub

    Private Sub tdbcAllowance04_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAllowance04.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcAllowance04.Text = ""
            txtAllowance04Name.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcAllowance05 with txtAllowance05Name"

    Private Sub tdbcAllowance05_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAllowance05.Close
        If tdbcAllowance05.FindStringExact(tdbcAllowance05.Text) = -1 Then
            tdbcAllowance05.Text = ""
            txtAllowance05Name.Text = ""
        End If
    End Sub

    Private Sub tdbcAllowance05_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAllowance05.SelectedValueChanged
        If tdbcAllowance05.SelectedValue Is Nothing Or tdbcAllowance05.Text = "" Then
            txtAllowance05Name.Text = ""
            txtAllowance05Name.Enabled = False
            Exit Sub
        End If
        txtAllowance05Name.Enabled = True
    End Sub

    Private Sub tdbcAllowance05_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAllowance05.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcAllowance05.Text = ""
            txtAllowance05Name.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcCurrencyID"

    Private Sub tdbcCurrencyID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCurrencyID.Close
        If tdbcCurrencyID.FindStringExact(tdbcCurrencyID.Text) = -1 Then
            tdbcCurrencyID.Text = ""

        End If

    End Sub

    Private Sub tdbcCurrencyID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcCurrencyID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcCurrencyID.Text = ""

        End If

    End Sub

    Private Sub tdbcCurrencyID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCurrencyID.SelectedValueChanged
        If tdbcCurrencyID.SelectedValue Is Nothing Or tdbcCurrencyID.Text = "" Then

            Exit Sub
        End If
        txtMainSalaryName.Text = SQLNumber(txtMainSalaryName.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
        txtTrialSalaryName.Text = SQLNumber(txtTrialSalaryName.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
        txtAllowance01Name.Text = SQLNumber(txtAllowance01Name.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
        txtAllowance02Name.Text = SQLNumber(txtAllowance02Name.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
        txtAllowance03Name.Text = SQLNumber(txtAllowance03Name.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
        txtAllowance04Name.Text = SQLNumber(txtAllowance04Name.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
        txtAllowance05Name.Text = SQLNumber(txtAllowance05Name.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
    End Sub


#End Region

#Region "Events tdbcWorkingStatusID with txtWorkingStatusName"

    Private Sub tdbcWorkingStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.LostFocus
        If tdbcWorkingStatusID.FindStringExact(tdbcWorkingStatusID.Text) = -1 Then
            tdbcWorkingStatusID.Text = ""
        End If
    End Sub

#End Region

    'Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcMainSalary.KeyDown, tdbcTrialSalary.KeyDown, tdbcWorkingStatusID.KeyDown
    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbc.AutoCompletion = False

    '        Case Else
    '            tdbc.AutoCompletion = True
    '    End Select
    'End Sub

    'Private Sub tdbcXX_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMainSalary.Leave, tdbcTrialSalary.Leave, tdbcWorkingStatusID.Leave
    '    'If gbUnicode Then Exit Sub

    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    If tdbc.SelectedIndex <> -1 Then
    '        tdbc.Text = tdbc.Columns(tdbc.DisplayMember).Text
    '    End If

    'End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMainSalary.Close, tdbcTrialSalary.Close, tdbcWorkingStatusID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMainSalary.Validated, tdbcTrialSalary.Validated, tdbcWorkingStatusID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub


    Private Sub txtMainSalaryName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMainSalaryName.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtMainSalaryName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMainSalaryName.LostFocus
        L3IsNumeric(txtMainSalaryName.Text)
        txtMainSalaryName.Text = SQLNumber(txtMainSalaryName.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
    End Sub

    Private Sub txtTrialSalaryName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTrialSalaryName.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtTrialSalaryName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTrialSalaryName.LostFocus
        L3IsNumeric(txtTrialSalaryName.Text)
        txtTrialSalaryName.Text = SQLNumber(txtTrialSalaryName.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
    End Sub

    Private Sub txtAllowance01Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAllowance01Name.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtAllowance02Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAllowance02Name.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtAllowance03Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAllowance03Name.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtAllowance04Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAllowance04Name.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtAllowance05Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAllowance05Name.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtAllowance01Name_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAllowance01Name.LostFocus
        L3IsNumeric(txtAllowance01Name.Text)
        txtAllowance01Name.Text = SQLNumber(txtAllowance01Name.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
    End Sub

    Private Sub txtAllowance02Name_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAllowance02Name.LostFocus
        L3IsNumeric(txtAllowance02Name.Text)
        txtAllowance02Name.Text = SQLNumber(txtAllowance02Name.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
    End Sub

    Private Sub txtAllowance03Name_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAllowance03Name.LostFocus
        L3IsNumeric(txtAllowance03Name.Text)
        txtAllowance03Name.Text = SQLNumber(txtAllowance03Name.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
    End Sub

    Private Sub txtAllowance04Name_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAllowance04Name.LostFocus
        L3IsNumeric(txtAllowance04Name.Text)
        txtAllowance04Name.Text = SQLNumber(txtAllowance04Name.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
    End Sub

    Private Sub txtAllowance05Name_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAllowance05Name.LostFocus
        L3IsNumeric(txtAllowance05Name.Text)
        txtAllowance05Name.Text = SQLNumber(txtAllowance05Name.Text, InsertFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text))
    End Sub

    Private Function SQLDateTimeShow(ByVal [Date] As Object) As String
        If IsDBNull([Date]) Then Return ""
        If [Date].ToString.Trim = "" Then Return ""
        Return Format(Convert.ToDateTime([Date]), "dd/MM/yyyy HH:mm")
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T1042
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 15/12/2008 08:12:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2061() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T2061 Set ")
        sSQL.Append("CurrencyID = " & SQLString(tdbcCurrencyID.Text) & COMMA)
        sSQL.Append("BeginDate = " & SQLDateTimeSave(c1dateBeginDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("WorkingPlace = " & SQLStringUnicode(txtWorkingPlace.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("WorkingPlaceU = " & SQLStringUnicode(txtWorkingPlace.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("WorkingHours = " & SQLStringUnicode(txtWorkingHours.Text, gbUnicode, False) & COMMA)
        sSQL.Append("WorkingHoursU = " & SQLStringUnicode(txtWorkingHours.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("TrialPeriod = " & SQLStringUnicode(txtTrialPeriod.Text, gbUnicode, False) & COMMA)
        sSQL.Append("TrialPeriodU = " & SQLStringUnicode(txtTrialPeriod.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("WorkID = " & SQLString(tdbcWorkID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("MainSalary = " & SQLString(ReturnValueC1Combo(tdbcMainSalary)) & COMMA) 'money, NOT NULL
        sSQL.Append("MainValue = " & SQLMoney(txtMainSalaryName.Text) & COMMA) 'money, NOT NULL
        sSQL.Append("TrialSalary = " & SQLString(ReturnValueC1Combo(tdbcTrialSalary)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("TrialValue = " & SQLMoney(txtTrialSalaryName.Text) & COMMA) 'money, NOT NULL
        sSQL.Append("Allowance01 = " & SQLString(ReturnValueC1Combo(tdbcAllowance01)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("Value01 = " & SQLMoney(txtAllowance01Name.Text) & COMMA) 'money, NOT NULL
        sSQL.Append("Allowance02 = " & SQLString(ReturnValueC1Combo(tdbcAllowance02)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("Value02 = " & SQLMoney(txtAllowance02Name.Text) & COMMA) 'money, NOT NULL
        sSQL.Append("Allowance03 = " & SQLString(ReturnValueC1Combo(tdbcAllowance03)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("Value03 = " & SQLMoney(txtAllowance03Name.Text) & COMMA) 'money, NOT NULL
        sSQL.Append("Allowance04 = " & SQLString(ReturnValueC1Combo(tdbcAllowance04)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("Value04 = " & SQLMoney(txtAllowance04Name.Text) & COMMA) 'money, NOT NULL
        sSQL.Append("Allowance05 = " & SQLString(ReturnValueC1Combo(tdbcAllowance05)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("Value05 = " & SQLMoney(txtAllowance05Name.Text) & COMMA) 'money, NOT NULL
        sSQL.Append("WorkingStatusID = " & SQLString(ReturnValueC1Combo(tdbcWorkingStatusID)) & COMMA)
        sSQL.Append("DutyID = " & SQLString(tdbcDutyID.Text) & COMMA)
        sSQL.Append("Note01 = " & SQLStringUnicode(txtNote01.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Note02 = " & SQLStringUnicode(txtNote02.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Note03 = " & SQLStringUnicode(txtNote03.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Note04 = " & SQLStringUnicode(txtNote04.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Note05 = " & SQLStringUnicode(txtNote05.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Note06 = " & SQLStringUnicode(txtNote06.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Note07 = " & SQLStringUnicode(txtNote07.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Note08 = " & SQLStringUnicode(txtNote08.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Note09 = " & SQLStringUnicode(txtNote09.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Note10 = " & SQLStringUnicode(txtNote10.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("Note01U = " & SQLStringUnicode(txtNote01.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Note02U = " & SQLStringUnicode(txtNote02.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Note03U = " & SQLStringUnicode(txtNote03.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Note04U = " & SQLStringUnicode(txtNote04.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Note05U = " & SQLStringUnicode(txtNote05.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Note06U = " & SQLStringUnicode(txtNote06.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Note07U = " & SQLStringUnicode(txtNote07.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Note08U = " & SQLStringUnicode(txtNote08.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Note09U = " & SQLStringUnicode(txtNote09.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Note10U = " & SQLStringUnicode(txtNote10.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("IsUseD15 = " & SQLNumber(chkIsUseD15.Checked) & COMMA)
        sSQL.Append("IsUseD21 = " & SQLNumber(chkIsUseD21.Checked))
        sSQL.Append(" Where ")
        sSQL.Append("TransID = " & SQLString(_transID) & " And ")
        sSQL.Append("CandidateID = " & SQLString(_candidateID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2052
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 15/12/2008 09:51:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2052() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2052 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'InterviewFileID, varchar[20], NOT NULL
        sSQL &= SQLString(_candidateID) & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'InterviewLevel, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(_transID) 'TransID, varchar[20], NOT NULL
        Return sSQL
    End Function



End Class