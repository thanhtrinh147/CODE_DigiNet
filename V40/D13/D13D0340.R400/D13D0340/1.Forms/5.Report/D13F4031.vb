'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:40:04 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:40:04 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F4031
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_Orders As Integer = 0 ' Thứ tự
    Private Const COL_Code As Integer = 1   ' Thu nhập
    Private Const COL_Short As Integer = 2  ' Tiêu đề cột
#End Region

    Dim dtDropDown As New DataTable
    Dim dtGrid As New DataTable
    Dim dtCode1, dtCode2 As New DataTable
    Dim dt As DataTable
    Dim dtReportCatelogy As DataTable
    Dim iLastCol As Integer

    Private _reportCode As String = ""
    Public Property ReportCode() As String
        Get
            Return _reportCode
        End Get
        Set(ByVal value As String)
            If ReportCode = value Then
                _reportCode = ""
                Return
            End If
            _reportCode = value
        End Set
    End Property

    Private _isInherit As Boolean = False
    Public Property isInherit() As Boolean
        Get
            Return _isInherit
        End Get
        Set(ByVal value As Boolean)
            If _isInherit = value Then
                Return
            End If
            _isInherit = value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            LoadTDBCombo()
            LoadTDBDropDown()
            InitdtGrid()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    CheckIdTextBox(txtReportCode)
                    btnSave.Enabled = True
                    btnNext.Enabled = False
                    LoadAdd()
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Enabled = True
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSave.Enabled = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub SetBackColorObligatory()
        txtReportCode.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtReportName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtReportTitle.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcReportCatelogy.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcDAGroupID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub D13F4031_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tabMain.SelectedTab = tabMainInfo
            txtReportCode.Focus()
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            tabMain.SelectedTab = tabDefineColumn

        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
    End Sub

    Private Sub D13F4031_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        tdbcReportCatelogy.SelectedValue = tdbcReportCatelogy.Columns(0).Value
        SetBackColorObligatory()
        tdbg_LockedColumns()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_nghia_bao_cao_bang_luong_-_D13F4031") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa bÀo cÀo b¶ng l§¥ng - D13F4031
        '================================================================ 
        lblReportCode.Text = rl3("Ma") 'Mã
        lblReportName.Text = rl3("Ten") 'Tên
        lblReportTitle.Text = rl3("Tieu_de") 'Tiêu đề
        lblReportCatelogy.Text = rl3("Dang_bao_cao") 'Dạng báo cáo
        lblCustom.Text = rl3("Dac_thu") 'Đặc thù
        lblSalCalMethodID.Text = rl3("PP_tinh_luong") 'PP tính lương
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        optModeSalary1.Text = rl3("Phieu_luong") 'Phiếu lương
        optModeSalary0.Text = rl3("Bang_luong") 'Bảng lương
        '================================================================ 
        chkIsLemonWeb.Text = rl3("Xem_tren_LemonWeb") 'Xem trên LemonWeb
        '================================================================ 
        tabMainInfo.Text = "1." & rl3("Thong_tin_chinh") '1. Thông tin chính
        tabDefineColumn.Text = rl3("2_Dinh_nghia_cot") '2. Định nghĩa cột
        '================================================================ 
        tdbcCustom.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcCustom.Columns("Title").Caption = rL3("Ten") 'Tên
        tdbcCustom.Columns("FileExt").Caption = rL3("Loai_tep") 'Loại tệp

        tdbcReportCatelogy.Columns("ReportCatelogy").Caption = rl3("Ma") 'Mã
        tdbcReportCatelogy.Columns("ReportCatelogyName").Caption = rl3("Ten") 'Tên
        tdbcDAGroupID.Columns("DAGroupID").Caption = rl3("Ma") 'Mã
        tdbcDAGroupID.Columns("DAGroupName").Caption = rl3("Ten") 'Tên
        tdbcSalCalMethodID.Columns("SalCalMethodID").Caption = rl3("Ma") 'Mã
        tdbcSalCalMethodID.Columns("Description").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdCode.Columns("Code").Caption = rl3("Ma_so") 'Mã số
        tdbdCode.Columns("Short").Caption = rl3("Tieu_de_cot") 'Tiêu đề cột
        tdbdCode.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg.Columns("Orders").Caption = rl3("Thu_tu") 'Thứ tự
        tdbg.Columns("Code").Caption = rl3("Thu_nhap") 'Thu nhập
        tdbg.Columns("Short").Caption = rl3("Tieu_de_cot") 'Tiêu đề cột
    End Sub

    Private Sub LoadAdd()
        txtReportCode.Text = ""
        chkDisabled.Checked = False
        txtReportName.Text = ""
        txtReportTitle.Text = ""
        tdbcReportCatelogy.SelectedValue = ""
        txtReportCatelogyName.Text = ""
        optModeSalary0.Checked = True
        optModeSalary0_Click(Nothing, Nothing)

        If isInherit Then
            LoadInherit()
            LoadTDBGrid()
        Else
            LoadMaster()
            LoadTDBGridAdd()
        End If

        tabMain.SelectedIndex = 0
        txtReportCode.Focus()
    End Sub

    Private Sub LoadEdit()
        txtReportCode.Enabled = False
        txtReportName.Focus()
        LoadMaster()
        LoadTDBGrid()
    End Sub

    Private Sub LoadTDBGridAdd()
        Dim sSQL As String = ""
        sSQL = "Select Null as Orders, Right(Code,2) As Code, Short, Description From D13T9000  WITH (NOLOCK) Where Code = '' Order by Code "
        Dim dtGridAdd As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGridAdd, gbUnicode)
    End Sub

    Private Sub LoadInherit()
        Dim sSQL As String = ""
        sSQL = "SELECT	'' As ReportCode, '' As ReportName, '' As ReportTitle, ReportCatelogy, " & vbCrLf
        sSQL &= "Column01, Column02, Column03, Column04, Column05, " & vbCrLf
        sSQL &= "Column06, Column07, Column08, Column09, Column10, " & vbCrLf
        sSQL &= "Column11, Column12, Column13, Column14, Column15, " & vbCrLf
        sSQL &= "Column16, Column17, Column18, Column19, Column20, " & vbCrLf
        sSQL &= "Column21, Column22, Column23, Column24, Column25, " & vbCrLf
        sSQL &= "Column26, Column27, Column28, Column29, Column30, " & vbCrLf
        sSQL &= "Column31, Column32, Column33, Column34, Column35, " & vbCrLf
        sSQL &= "Column36, Column37, Column38, Column39, Column40," & vbCrLf
        sSQL &= "ColCaption01U as ColCaption01, ColCaption02U as ColCaption02, ColCaption03U as ColCaption03, ColCaption04U as ColCaption04, ColCaption05U as ColCaption05, " & vbCrLf
        sSQL &= "ColCaption06U as ColCaption06, ColCaption07U as ColCaption07, ColCaption08U as ColCaption08, ColCaption09U as ColCaption09, ColCaption10U as ColCaption10, " & vbCrLf
        sSQL &= "ColCaption11U as ColCaption11, ColCaption12U as ColCaption12, ColCaption13U as ColCaption13, ColCaption14U as ColCaption14, ColCaption15U as ColCaption15, " & vbCrLf
        sSQL &= "ColCaption16U as ColCaption16, ColCaption17U as ColCaption17, ColCaption18U as ColCaption18, ColCaption19U as ColCaption19, ColCaption20U as ColCaption20, " & vbCrLf
        sSQL &= "ColCaption21U as ColCaption21, ColCaption22U as ColCaption22, ColCaption23U as ColCaption23, ColCaption24U as ColCaption24, ColCaption25U as ColCaption25, " & vbCrLf
        sSQL &= "ColCaption26U as ColCaption26, ColCaption27U as ColCaption27, ColCaption28U as ColCaption28, ColCaption29U as ColCaption29, ColCaption30U as ColCaption30, " & vbCrLf
        sSQL &= "ColCaption31U as ColCaption31, ColCaption32U as ColCaption32, ColCaption33U as ColCaption33, ColCaption34U as ColCaption34, ColCaption35U as ColCaption35, " & vbCrLf
        sSQL &= "ColCaption36U as ColCaption36, ColCaption37U as ColCaption37, ColCaption38U as ColCaption38, ColCaption39U as ColCaption39, ColCaption40U as ColCaption40, " & vbCrLf
        sSQL &= "CreateDate, CreateUserID, LastModifyDate, LastModifyUserID, Disabled, " & vbCrLf
        sSQL &= "DAGroupID, ModeSalary" & vbCrLf
        sSQL &= "FROM D13T4000 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE	ReportCode = " & SQLString(ReportCode) & vbCrLf
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                txtReportCode.Text = .Item("ReportCode").ToString
                chkDisabled.Checked = Convert.ToBoolean(.Item("Disabled"))
                txtReportName.Text = .Item("ReportName").ToString
                txtReportTitle.Text = .Item("ReportTitle").ToString
                tdbcReportCatelogy.SelectedValue = .Item("ReportCatelogy").ToString
                tdbcDAGroupID.SelectedValue = .Item("DAGroupID").ToString
                If .Item("ModeSalary").ToString = "0" Then
                    optModeSalary0.Checked = True
                    optModeSalary0_Click(Nothing, Nothing)
                Else
                    optModeSalary1.Checked = True
                    optModeSalary1_Click(Nothing, Nothing)
                End If
            End With
        Next
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcReportCatelogy
        'sSQL = "Select  ReportID As ReportCatelogy, " & CStr(IIf(gsLanguage = "84", "ReportName AS ReportCatelogyName", "ReportName01 AS ReportCatelogyName")) & " From D91T0100 Where ReportType ='40' And ModuleID = '13' Order By ReportCatelogy "
        sSQL = "Select 	    ReportID As ReportCatelogy, " & IIf(gsLanguage = "84", IIf(gbUnicode, "ReportNameU AS ReportCatelogyName", "ReportName AS ReportCatelogyName"), IIf(gbUnicode, "ReportName01U AS ReportCatelogyName", "ReportName01 AS ReportCatelogyName")).ToString & ", ReportType" & vbCrLf
        sSQL &= " From 	    D91T0100 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where 	    ReportType in ('40', '41') And ModuleID = '13'" & vbCrLf
        sSQL &= "Order By 	ReportCatelogy"
        dtReportCatelogy = ReturnDataTable(sSQL)
        'LoadDataSource(tdbcReportCatelogy, sSQL)

        'Load tdbcDAGroupID
        sSQL = "Select DAGroupID, "
        sSQL &= IIf(gbUnicode, "DAGroupNameU as DAGroupName", "DAGroupName").ToString
        sSQL &= " From LEMONSYS.DBO.D00T0080  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "And (DAGroupID In" & vbCrLf
        sSQL &= "(Select DAGroupID From LEMONSYS.DBO.D00V0080" & vbCrLf
        sSQL &= "Where UserID = " & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "Or " & SQLString(gsUserID) & " = 'LEMONADMIN')" & vbCrLf
        sSQL &= "Order By DAGroupID" & vbCrLf
        LoadDataSource(tdbcDAGroupID, sSQL, gbUnicode)

        'Load tdbcCustom
        sSQL = "SELECT     ReportID, Title" & UnicodeJoin(gbUnicode) & " AS Title, CASE WHEN ISNULL(FileExt, '') <> '' THEN FileExt ELSE 'rpt' END AS FileExt "
        sSQL &= " FROM       D89T1000 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE      ModuleID = '13' " & vbCrLf
        sSQL &= "           AND ReportTypeID = 'D13F4020'" & vbCrLf
        LoadDataSource(tdbcCustom, sSQL, gbUnicode)

        'Load tdbcSalCalMethodID
        sSQL = "SELECT     SalCalMethodID, Description" & UnicodeJoin(gbUnicode) & " AS Description" & vbCrLf
        sSQL &= "FROM 		D13T2500 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY 	Description" & vbCrLf
        LoadDataSource(tdbcSalCalMethodID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadtdbcReportCatelogy(ByVal ID As String)
        LoadDataSource(tdbcReportCatelogy, ReturnTableFilter(dtReportCatelogy, "ReportType = " & ID), gbUnicode)
    End Sub

#Region "Events tdbCombo"

#Region "Events tdbcSalCalMethodID"

    Private Sub tdbcSalCalMethodID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalCalMethodID.LostFocus
        If tdbcSalCalMethodID.FindStringExact(tdbcSalCalMethodID.Text) = -1 Then tdbcSalCalMethodID.Text = ""
        LoadTDBDCode(ComboValue(tdbcSalCalMethodID))
    End Sub

#End Region
#Region "Events tdbcReportCatelogy with txtReportCatelogyName"

    Private Sub tdbcReportCatelogy_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportCatelogy.SelectedValueChanged
        If tdbcReportCatelogy.SelectedValue Is Nothing Then
            txtReportCatelogyName.Text = ""
        Else
            txtReportCatelogyName.Text = tdbcReportCatelogy.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcReportCatelogy_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportCatelogy.LostFocus
        If tdbcReportCatelogy.FindStringExact(tdbcReportCatelogy.Text) = -1 Then
            tdbcReportCatelogy.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcCustom with txtCustomName"

    Private Sub tdbcCustom_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustom.SelectedValueChanged
        If tdbcCustom.SelectedValue Is Nothing Then
            txtCustomName.Text = ""
            txtFileExt.Text = ""
        Else
            txtCustomName.Text = tdbcCustom.Columns(1).Value.ToString
            txtFileExt.Text = tdbcCustom.Columns(2).Value.ToString
        End If
    End Sub

    Private Sub tdbcCustom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustom.LostFocus
        If tdbcCustom.FindStringExact(tdbcCustom.Text) = -1 Then
            tdbcCustom.Text = ""
            txtFileExt.Text = ""
        End If
    End Sub

#End Region


    '#Region "Events tdbcReportCatelogy with txtReportCatelogyName"

    '    Private Sub tdbcReportCatelogy_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportCatelogy.Close
    '        If tdbcReportCatelogy.FindStringExact(tdbcReportCatelogy.Text) = -1 Then
    '            tdbcReportCatelogy.Text = ""
    '            txtReportCatelogyName.Text = ""
    '        End If
    '    End Sub

    '    Private Sub tdbcReportCatelogy_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportCatelogy.SelectedValueChanged
    '        txtReportCatelogyName.Text = tdbcReportCatelogy.Columns(1).Value.ToString
    '    End Sub

    '    Private Sub tdbcReportCatelogy_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcReportCatelogy.KeyDown
    '        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
    '        '    tdbcReportCatelogy.Text = ""
    '        '    txtReportCatelogyName.Text = ""
    '        'End If
    '    End Sub
    '#End Region

#Region "Events tdbcDAGroupID with txtDAGroupName"

    Private Sub tdbcDAGroupID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDAGroupID.Close
        If tdbcDAGroupID.FindStringExact(tdbcDAGroupID.Text) = -1 Then
            tdbcDAGroupID.Text = ""
            txtDAGroupName.Text = ""
        End If
    End Sub

    Private Sub tdbcDAGroupID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDAGroupID.SelectedValueChanged
        txtDAGroupName.Text = tdbcDAGroupID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcDAGroupID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDAGroupID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcDAGroupID.Text = ""
        '    txtDAGroupName.Text = ""
        'End If
    End Sub

#End Region

    '#Region "Events tdbcCustom with txtCustomName"

    '    Private Sub tdbcCustom_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustom.SelectedValueChanged
    '        If tdbcCustom.SelectedValue Is Nothing Then
    '            txtCustomName.Text = ""
    '        Else
    '            txtCustomName.Text = tdbcCustom.Columns(1).Value.ToString
    '        End If
    '    End Sub

    '    Private Sub tdbcCustom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustom.LostFocus
    '        If tdbcCustom.FindStringExact(tdbcCustom.Text) = -1 Then
    '            tdbcCustom.Text = ""
    '            txtCustomName.Text = ""
    '        End If
    '    End Sub

    '#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcSalCalMethodID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalCalMethodID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSalCalMethodID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalCalMethodID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL = "SELECT	 ReportCode, ReportName,  ReportTitle, ReportCatelogy, " & vbCrLf
        sSQL &= "Column01, Column02, Column03, Column04, Column05, " & vbCrLf
        sSQL &= "Column06, Column07, Column08, Column09, Column10, " & vbCrLf
        sSQL &= "Column11, Column12, Column13, Column14, Column15, " & vbCrLf
        sSQL &= "Column16, Column17, Column18, Column19, Column20, " & vbCrLf
        sSQL &= "Column21, Column22, Column23, Column24, Column25, " & vbCrLf
        sSQL &= "Column26, Column27, Column28, Column29, Column30, " & vbCrLf
        sSQL &= "Column31, Column32, Column33, Column34, Column35, " & vbCrLf
        sSQL &= "Column36, Column37, Column38, Column39, Column40," & vbCrLf
        sSQL &= "ColCaption01U as ColCaption01, ColCaption02U as ColCaption02, ColCaption03U as ColCaption03, ColCaption04U as ColCaption04, ColCaption05U as ColCaption05, " & vbCrLf
        sSQL &= "ColCaption06U as ColCaption06, ColCaption07U as ColCaption07, ColCaption08U as ColCaption08, ColCaption09U as ColCaption09, ColCaption10U as ColCaption10, " & vbCrLf
        sSQL &= "ColCaption11U as ColCaption11, ColCaption12U as ColCaption12, ColCaption13U as ColCaption13, ColCaption14U as ColCaption14, ColCaption15U as ColCaption15, " & vbCrLf
        sSQL &= "ColCaption16U as ColCaption16, ColCaption17U as ColCaption17, ColCaption18U as ColCaption18, ColCaption19U as ColCaption19, ColCaption20U as ColCaption20, " & vbCrLf
        sSQL &= "ColCaption21U as ColCaption21, ColCaption22U as ColCaption22, ColCaption23U as ColCaption23, ColCaption24U as ColCaption24, ColCaption25U as ColCaption25, " & vbCrLf
        sSQL &= "ColCaption26U as ColCaption26, ColCaption27U as ColCaption27, ColCaption28U as ColCaption28, ColCaption29U as ColCaption29, ColCaption30U as ColCaption30, " & vbCrLf
        sSQL &= "ColCaption31U as ColCaption31, ColCaption32U as ColCaption32, ColCaption33U as ColCaption33, ColCaption34U as ColCaption34, ColCaption35U as ColCaption35, " & vbCrLf
        sSQL &= "ColCaption36U as ColCaption36, ColCaption37U as ColCaption37, ColCaption38U as ColCaption38, ColCaption39U as ColCaption39, ColCaption40U as ColCaption40, " & vbCrLf
        sSQL &= "CreateDate, CreateUserID, LastModifyDate, LastModifyUserID, Disabled, Customized, " & vbCrLf
        sSQL &= "DAGroupID, ModeSalary, CustomReportID, ReportTitleU, ReportNameU, IsLemonWeb" & vbCrLf
        sSQL &= "  From D13T4000  WITH (NOLOCK) Where ReportCode = " & SQLString(_reportCode)
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                txtReportCode.Text = .Item("ReportCode").ToString
                chkDisabled.Checked = Convert.ToBoolean(.Item("Disabled"))
                txtReportName.Text = .Item("ReportName" & UnicodeJoin(gbUnicode)).ToString
                txtReportTitle.Text = .Item("ReportTitle" & UnicodeJoin(gbUnicode)).ToString
                tdbcCustom.SelectedValue = .Item("CustomReportID").ToString

                tdbcDAGroupID.SelectedValue = .Item("DAGroupID").ToString
                If .Item("ModeSalary").ToString = "0" Then
                    optModeSalary0.Checked = True
                    optModeSalary0_Click(Nothing, Nothing)
                Else
                    optModeSalary1.Checked = True
                    optModeSalary1_Click(Nothing, Nothing)
                End If
                tdbcReportCatelogy.SelectedValue = .Item("ReportCatelogy").ToString
                chkIsLemonWeb.Checked = L3Bool(.Item("IsLemonWeb").ToString)
            End With
        Next
    End Sub

    Private Sub LoadTDBGrid()
        If dt.Rows.Count = 0 Then Exit Sub
        For i As Integer = 1 To 40
            If i < 10 Then
                GetItem("Column" & 0 & i, "ColCaption" & 0 & i)
            Else
                GetItem("Column" & i, "ColCaption" & i)
            End If
        Next
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_Code).ToString <> "" And tdbg(i, COL_Short).ToString <> "" Then
                tdbg(i, COL_Orders) = i + 1
            End If
        Next
    End Sub

    Private Sub GetItem(ByVal sColumnName1 As String, ByVal sColumnName2 As String)
        Dim Row As DataRow
        Row = dtGrid.NewRow
        Row(1) = dt.Rows(0).Item(sColumnName1)
        Row(2) = dt.Rows(0).Item(sColumnName2)
        dtGrid.Rows.Add(Row)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdCode

        'update 11/6/2013 id 56314
        sSQL = "Select CONVERT(Smallint,Substring(Code,4, LEN(Code)-3)) as Orders, Substring(Code,4, LEN(Code)-3) Code, "
        'sSQL = "Select Null as Orders, Right(Code,2) As Code, "
        sSQL &= IIf(gbUnicode, "ShortU as Short, DescriptionU as Description", "Short, Description").ToString
        sSQL &= " From D13T9000  WITH (NOLOCK) Where Type='PRCAL' And Disabled=0 Order by Orders "
        dtCode1 = ReturnDataTable(sSQL)
        LoadDataSource(tdbdCode, dtCode1, gbUnicode)

        'update 11/6/2013 id 56314
        sSQL = "SELECT     CONVERT(Smallint,Substring(CalNo,4, LEN(CalNo)-3)) as Orders, Substring(CalNo,4, LEN(CalNo)-3) Code , ShortName" & UnicodeJoin(gbUnicode) & " AS Short, Caption" & UnicodeJoin(gbUnicode) & " AS Description, SalCalMethodID" & vbCrLf
        '   sSQL = "SELECT     Null as Orders, Right(CalNo,2) As Code , ShortName" & UnicodeJoin(gbUnicode) & " AS Short, Caption" & UnicodeJoin(gbUnicode) & " AS Description, SalCalMethodID" & vbCrLf
        sSQL &= "FROM 		D13T2501 	 WITH (NOLOCK) 	" & vbCrLf
        sSQL &= "WHERE      Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY   Orders" & vbCrLf
       
        dtCode2 = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadTDBDCode(ByVal sSalCalMethodID As String)
        If sSalCalMethodID = "" Then
            LoadDataSource(tdbdCode, dtCode1, gbUnicode)
        Else
            LoadDataSource(tdbdCode, ReturnTableFilter(dtCode2, "SalCalMethodID = " & SQLString(sSalCalMethodID), True), gbUnicode)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        Select Case _FormState
            Case EnumFormState.FormAdd
                'sSQL &= SQLUpdateD91T0100()
                sSQL &= SQLInsertD13T4000()
            Case EnumFormState.FormEdit
                'sSQL &= SQLUpdateD91T0100()
                sSQL &= SQLUpdateD13T4000()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    _reportCode = txtReportCode.Text
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
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
        If txtReportCode.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("_Ma_bao_cao"))
            tabMain.SelectedTab = tabMainInfo
            txtReportCode.Focus()
            Return False
        End If
        If txtReportCode.Text.Trim <> "" Then
            If txtReportCode.Text.Trim.Length > 20 Then
                D99C0008.MsgL3(rl3("Do_dai_Ma_bao_cao_khong_duoc_vuot_qua_20_ky_tu"))
                tabMain.SelectedTab = tabMainInfo
                txtReportCode.Focus()
                Return False
            End If
        End If
        If txtReportName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_bao_cao"))
            tabMain.SelectedTab = tabMainInfo
            txtReportName.Focus()
            Return False
        End If
        If txtReportName.Text.Trim <> "" Then
            If txtReportName.Text.Trim.Length > 50 Then
                D99C0008.MsgL3(rl3("Do_dai_Ten_bao_cao_khong_duoc_vuot_qua_50_ky_tu"))
                tabMain.SelectedTab = tabMainInfo
                txtReportName.Focus()
                Return False
            End If
        End If
        If txtReportTitle.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Tieu_de"))
            tabMain.SelectedTab = tabMainInfo
            txtReportTitle.Focus()
            Return False
        End If
        If txtReportTitle.Text.Trim <> "" Then
            If txtReportTitle.Text.Trim.Length > 250 Then
                D99C0008.MsgL3(rl3("Do_dai_Tieu_de_khong_duoc_vuot_qua_250_ky_tu_U"))
                tabMain.SelectedTab = tabMainInfo
                txtReportTitle.Focus()
                Return False
            End If
        End If
        If tdbcReportCatelogy.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Dang_bao_cao"))
            tabMain.SelectedTab = tabMainInfo
            tdbcReportCatelogy.Focus()
            Return False
        End If
        'If tdbcDAGroupID.Text.Trim = "" Then
        '    D99C0008.MsgNotYetChoose(rl3("Nhom_truy_cap_du_lieu"))
        '    tabMain.SelectedTab = tabMainInfo
        '    tdbcDAGroupID.Focus()
        '    Return False
        'End If
        If _FormState = EnumFormState.FormAdd Then
            If CheckDuplicateKey() = True Then
                D99C0008.MsgL3(rl3("Ma_bao_cao_nay_da_ton_tai"))
                txtReportCode.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        If tdbg.Columns(COL_Code).Text <> "" And tdbg.Columns(COL_Short).Text <> "" Then
            tdbg.Columns(COL_Orders).Text = (tdbg.Bookmark + 1).ToString
        End If
    End Sub
    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_Code
                tdbg.Columns(COL_Code).Text = tdbdCode.Columns("Code").Value.ToString
                tdbg.Columns(COL_Short).Text = tdbdCode.Columns("Short").Value.ToString
                If tdbg.Columns(COL_Code).Text <> "" And tdbg.Columns(COL_Short).Text <> "" Then
                    tdbg.Columns(COL_Orders).Text = (tdbg.Bookmark + 1).ToString
                End If
                If CheckTDBGRowCount() = True Then tdbg.Delete()
        End Select
    End Sub

    Private Function CheckDuplicateKey() As Boolean
        Dim sSQL As String = ""
        sSQL &= "Select ReportCode From D13T4000  WITH (NOLOCK) Where ReportCode = " & SQLString(txtReportCode.Text)
        Dim sRet As String = ReturnScalar(sSQL)
        If sRet <> "" Then
            Return True
        End If
        Return False
    End Function

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_Orders
            Case COL_Code
                If tdbg.Columns(COL_Code).Text <> tdbdCode.Columns("Code").Text Then
                    tdbg.Columns(COL_Code).Text = ""
                    tdbg.Columns(COL_Short).Text = ""
                End If
            Case COL_Short
        End Select
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Orders).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD91T0100
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 13/03/2007 09:51:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD91T0100() As String
        Dim sSQL As String = ""
        sSQL &= "Update D91T0100 Set "
        sSQL &= "ReportName = " & SQLString(txtReportName.Text) 'varchar[250], NULL
        sSQL &= " Where "
        sSQL &= " ReportType = " & SQLString("40") 'varchar[20], NULL
        sSQL &= " And ModuleID = " & SQLString("13") 'varchar[20], NULL
        sSQL &= " And ReportID = " & SQLString(txtReportCode.Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T4000
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 13/03/2007 10:10:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T4000() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D13T4000("
        sSQL &= "ReportCode, ReportName, ReportTitle, ReportCatelogy,CustomReportID,Column01, "
        sSQL &= "Column02, Column03, Column04, Column05, Column06, "
        sSQL &= "Column07, Column08, Column09, Column10, Column11, "
        sSQL &= "Column12, Column13, Column14, Column15, Column16, "
        sSQL &= "Column17, Column18, Column19, Column20, Column21, "
        sSQL &= "Column22, Column23, Column24, Column25, Column26, "
        sSQL &= "Column27, Column28, Column29, Column30, Column31,  "
        sSQL &= "Column32, Column33, Column34, Column35, Column36, "
        sSQL &= "Column37, Column38, Column39, Column40, "

        sSQL &= "ColCaption01U, ColCaption02U, ColCaption03U, ColCaption04U, ColCaption05U, "
        sSQL &= "ColCaption06U, ColCaption07U, ColCaption08U, ColCaption09U, ColCaption10U, "
        sSQL &= "ColCaption11U, ColCaption12U, ColCaption13U, ColCaption14U, ColCaption15U, "
        sSQL &= "ColCaption16U, ColCaption17U, ColCaption18U, ColCaption19U, ColCaption20U, "
        sSQL &= "ColCaption21U, ColCaption22U, ColCaption23U, ColCaption24U, ColCaption25U, "
        sSQL &= "ColCaption26U, ColCaption27U, ColCaption28U, ColCaption29U, ColCaption30U, "
        sSQL &= "ColCaption31U, ColCaption32U, ColCaption33U, ColCaption34U, ColCaption35U, "
        sSQL &= "ColCaption36U, ColCaption37U, ColCaption38U, ColCaption39U, ColCaption40U, "

        sSQL &= "DAGroupID, ModeSalary, ReportTitleU, ReportNameU, "
        sSQL &= "CreateDate,CreateUserID, LastModifyDate, LastModifyUserID, Disabled, "
        sSQL &= "IsLemonWeb"
        sSQL &= ") Values ("

        sSQL &= SQLString(txtReportCode.Text) & COMMA 'ReportCode, varchar[20], NULL
        sSQL &= SQLStringUnicode(txtReportName, False) & COMMA 'ReportName, varchar[50], NULL
        sSQL &= SQLStringUnicode(txtReportTitle, False) & COMMA 'ReportTitle, varchar[250], NULL
        sSQL &= SQLString(tdbcReportCatelogy.SelectedValue) & COMMA 'ReportCatelogy, varchar[20], NULL
        sSQL &= SQLString(tdbcCustom.Text) & COMMA 'CustomReportID, varchar[250], NULL

        For i As Integer = 0 To 39
            sSQL &= SQLString(tdbg(i, COL_Code)) & COMMA 'Column, varchar[20], NULL
        Next

        For i As Integer = 0 To 39
            sSQL &= SQLStringUnicode(tdbg(i, COL_Short), gbUnicode, True) & COMMA 'ColCaptionU, varchar[50], NULL
        Next

        sSQL &= SQLString(tdbcDAGroupID.SelectedValue) & COMMA 'DAGroupID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(optModeSalary0.Checked, 0, 1)) & COMMA 'ModeSalary, tinyint, NOT NULL
        sSQL &= SQLStringUnicode(txtReportTitle, True) & COMMA 'ReportTitleU, nvarchar, NOT NULL
        sSQL &= SQLStringUnicode(txtReportName, True) & COMMA 'ReportNameU, nvarchar, NOT NULL 

        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'LastModifyDate, datetime, NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= SQLNumber(chkDisabled.Checked) & COMMA 'Disabled, tinyint, NULL

        sSQL &= SQLNumber(chkIsLemonWeb.Checked) 'IsLemonWeb, tinyint, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T4000
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 13/03/2007 01:45:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T4000() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T4000 Set "
        sSQL &= "ReportName = " & SQLStringUnicode(txtReportName, False) & COMMA 'varchar[50], NULL
        sSQL &= "ReportTitle = " & SQLStringUnicode(txtReportTitle, False) & COMMA 'varchar[250], NULL
        sSQL &= "ReportNameU = " & SQLStringUnicode(txtReportName, True) & COMMA 'varchar[50], NULL
        sSQL &= "ReportTitleU = " & SQLStringUnicode(txtReportTitle, True) & COMMA 'varchar[250], NULL
        sSQL &= "ReportCatelogy = " & SQLString(tdbcReportCatelogy.SelectedValue) & COMMA 'varchar[20], NULL

        For i As Integer = 0 To 39
            sSQL &= "Column" & (i + 1).ToString("00") & " = " & SQLString(tdbg(i, COL_Code)) & COMMA 'varchar[20], NULL
        Next

        For i As Integer = 0 To 39
            sSQL &= "ColCaption" & (i + 1).ToString("00") & "U = " & SQLStringUnicode(tdbg(i, COL_Short), gbUnicode, True) & COMMA 'varchar[50], NULL
        Next

        sSQL &= "LastModifyDate = GetDate()" & COMMA 'datetime, NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA 'tinyint, NULL
        sSQL &= "DAGroupID = " & SQLString(tdbcDAGroupID.SelectedValue) & COMMA 'varchar[20], NOT NULL
        sSQL &= "CustomReportID = " & SQLString(tdbcCustom.Text) & COMMA 'varchar[20], NOT NULL
        sSQL &= "ModeSalary = " & SQLNumber(IIf(optModeSalary0.Checked, 0, 1)) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsLemonWeb = " & SQLNumber(chkIsLemonWeb.Checked) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "ReportCode = " & SQLString(txtReportCode.Text) 'varchar[20]
        Return sSQL
    End Function
    Private Sub InitdtGrid()
        Dim sSQL As String = ""
        ' sSQL = "Select Null as Orders, Right(Code,2) As Code, "
        sSQL = "Select Null as Orders, Substring(Code,4, LEN(Code)-3) Code, "
        sSQL &= IIf(gbUnicode, "ShortU AS Short, DescriptionU as Description", "Short, Description").ToString
        sSQL &= ", CONVERT(Smallint,Substring(Code,4, LEN(Code)-3)) CodeKey "
        sSQL &= " From D13T9000  WITH (NOLOCK) Where Type='PRCAL' And Disabled=0 Order by Code "
        dtDropDown = ReturnDataTable(sSQL)
        dtGrid = dtDropDown.Clone
        'Create Primary key
        Dim keys(0) As DataColumn
        keys(0) = dtDropDown.Columns("CodeKey")
        dtDropDown.PrimaryKey = keys
    End Sub
    Private Function CheckTDBGRowCount() As Boolean
        If tdbg.RowCount > 40 Then
            D99C0008.MsgL3("Dữ liệu trên lưới không được vượt quá 40 dòng")
            tdbg.Focus()
            Return True
        End If
        Return False
    End Function

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        If isInherit Then
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    With dt.Rows(i)
                        txtReportCode.Text = .Item("ReportCode").ToString
                        chkDisabled.Checked = Convert.ToBoolean(.Item("Disabled"))
                        txtReportName.Text = .Item("ReportName").ToString
                        txtReportTitle.Text = .Item("ReportTitle").ToString
                        tdbcReportCatelogy.SelectedValue = .Item("ReportCatelogy").ToString
                        tdbcDAGroupID.SelectedValue = .Item("DAGroupID").ToString
                        If .Item("ModeSalary").ToString = "0" Then
                            optModeSalary0.Checked = True
                            optModeSalary0_Click(Nothing, Nothing)
                        Else
                            optModeSalary1.Checked = True
                            optModeSalary1_Click(Nothing, Nothing)
                        End If
                    End With
                Next
                dtGrid.Clear()
                LoadTDBGrid()

            End If
        Else
            _reportCode = ""
            LoadAdd()
        End If
        tabMain.SelectedIndex = 0
        chkIsLemonWeb.Checked = False
        tdbcCustom.Text = ""
        txtCustomName.Text = ""
        txtReportCode.Focus()
        btnNext.Enabled = False
        btnSave.Enabled = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.S Then
            tdbg_HeadClick(sender, Nothing)
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            If tdbg.Col = iLastCol Then HotKeyEnterGrid(tdbg, COL_Orders, e)
            Exit Sub
        ElseIf e.Shift And (e.KeyCode = Keys.Insert) Then
            HotKeyShiftInsert(tdbg, 0, COL_Orders, tdbg.Columns.Count)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_Code, 0, 0)
    End Sub

    'Hai hàm này chép từ D99X0000 ra
    ''' <summary>
    ''' Copy giá trị trong 1 cột (khi nhấn Head_Click)
    ''' </summary>
    ''' <param name="c1Grid">Lưới C1</param>
    ''' <param name="ColCopy">Cột cần copy</param>
    ''' <param name="sValue">Giá trị cần copy</param>
    ''' <param name="RowCopy">Dòng đang copy</param>
    ''' <remarks>Chỉ dùng copy những cột dữ liệu không liên quan đến các cột khác, copy cả giá trị ''</remarks>

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            'If sValue = "" Or c1Grid.RowCount < 2 Then Exit Sub
            If c1Grid.RowCount < 2 Then Exit Sub

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse Val(c1Grid(i, ColCopy).ToString) = 0 Then c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(RowCopy, ColCopy) = sValue

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(0, ColCopy) = sValue
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Copy giá trị trong 1 cột có liên quan đến các cột kế nó (khi nhấn Head_Click)
    ''' </summary>
    ''' <param name="c1Grid">Lưới C1</param>
    ''' <param name="ColCopy">Cột cần copy</param>
    ''' <param name="RowCopy">Dòng cần copy</param>
    ''' <param name="ColumnCount">Số cột liên quan khi cần copy</param>
    ''' <remarks>Chỉ copy những cột ở vị trí liên tục nhau</remarks>

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal ColumnCount As Integer, ByVal sValue As String)
        Dim i, j As Integer
        Try
            If c1Grid.RowCount < 2 Then Exit Sub

            If ColumnCount = 1 Then ' Copy trong 1 cot
                CopyColumns(c1Grid, ColCopy, sValue, RowCopy)
            ElseIf ColumnCount > 1 Then ' Copy nhieu cot lien quan
                Dim Flag As DialogResult
                'Flag = D99C0008.MsgCopyColumn()
                Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                    c1Grid.UpdateData()
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse Val(c1Grid(i, ColCopy).ToString) = 0 Then
                            c1Grid(i, ColCopy) = sValue
                            While j < ColumnCount
                                c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                                j += 1
                            End While
                        End If
                    Next
                ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy hết
                    c1Grid.UpdateData()
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        c1Grid(i, ColCopy) = sValue
                        While j < ColumnCount
                            c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                            j += 1
                        End While
                    Next
                    'c1Grid(0, ColCopy) = sValue
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    'Khi nào chuẩn hóa theo người dùng đơn vị xong thì trở về hàm dùng chung

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_Code
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Value.ToString, tdbg.Row)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
            tdbg.Columns(COL_Code).Text = "" ' Gán 1 cột bất kỳ ="" cho lưới
        End If
    End Sub

    Private Sub optModeSalary0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optModeSalary0.Click
        LoadtdbcReportCatelogy("40")
    End Sub

    Private Sub optModeSalary1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optModeSalary1.Click
        LoadtdbcReportCatelogy("41")
    End Sub

End Class