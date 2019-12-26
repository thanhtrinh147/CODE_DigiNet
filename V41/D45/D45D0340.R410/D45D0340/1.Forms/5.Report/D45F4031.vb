Imports System

Public Class D45F4031
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim dtCode, dtGrid, dtMaster As DataTable

#Region "Const of tdbg"
    Private Const COL_OrderNum As Integer = 0  ' Thứ tự
    Private Const COL_Code As Integer = 1      ' Thu nhập
    Private Const COL_ShortName As Integer = 2 ' Tiêu đề cột
#End Region

    Private _reportCode As String
    Public Property ReportCode() As String
        Get
            Return _reportCode
        End Get
        Set(ByVal Value As String)
            _reportCode = value
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


    Private Sub D45F4031_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tabMain.SelectedTab = tabMainInfo
            txtReportCode.Focus()
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            tabMain.SelectedTab = tabDefineColumn
            tdbg.Focus()
            tdbg.Col = COL_Code
            tdbg.SplitIndex = 0
            tdbg.Bookmark = 0
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D13F4031_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        SetBackColorObligatory()
        tdbg_LockedColumns()
        CheckIdTextBox(txtReportCode)
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_nghia_bao_cao_bang_luong_san_pham_-_D45F4031") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa bÀo cÀo b¶ng l§¥ng s¶n phÈm - D45F4031
        '================================================================ 
        lblCustom.Text = rl3("Dac_thu") 'Đặc thù
        lblReportTitle.Text = rl3("Tieu_de") 'Tiêu đề
        lblReportName.Text = rl3("Ten") 'Tên
        lblReportCatelogy.Text = rl3("Dang_bao_cao") 'Dạng báo cáo
        lblReportCode.Text = rl3("Ma") 'Mã
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        tabMainInfo.Text = "1." & Space(1) & rl3("Thong_tin_chinh") '1. Thông tin chính
        tabDefineColumn.Text = "2." & Space(1) & rl3("Dinh_nghia_cot") '2. Định nghĩa cột
        '================================================================ 
        tdbcCustomReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcCustomReportID.Columns("Title").Caption = rl3("Ten") 'Tên
        tdbcReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcReportID.Columns("ReportName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdCode.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdCode.Columns("ShortName").Caption = rl3("Ten") 'Tên
        tdbdCode.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg.Columns("OrderNum").Caption = rl3("Thu__tu") 'Thứ tự
        tdbg.Columns("Code").Caption = rl3("Thu_nhap") 'Thu nhập
        tdbg.Columns("ShortName").Caption = rl3("Tieu_de_cot") 'Tiêu đề cột
    End Sub

    Private Sub SetBackColorObligatory()
        txtReportCode.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtReportName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtReportTitle.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

#Region "Events tdbcReportID with txtReportCategoryName"

    Private Sub tdbcReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.SelectedValueChanged
        If tdbcReportID.SelectedValue Is Nothing Then
            txtReportCategoryName.Text = ""
        Else
            txtReportCategoryName.Text = tdbcReportID.Columns("ReportName").Value.ToString
        End If
    End Sub

    Private Sub tdbcReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.LostFocus
        If tdbcReportID.FindStringExact(tdbcReportID.Text) = -1 Then
            tdbcReportID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcCustomReportID with txtCustomReportName"

    Private Sub tdbcCustomReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomReportID.SelectedValueChanged
        If tdbcCustomReportID.SelectedValue Is Nothing Then
            txtCustomReportName.Text = ""
        Else
            txtCustomReportName.Text = tdbcCustomReportID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcCustomReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomReportID.LostFocus
        If tdbcCustomReportID.FindStringExact(tdbcCustomReportID.Text) = -1 Then
            tdbcCustomReportID.Text = ""
        End If
    End Sub

#End Region

    Private Sub LoadAdd()
        txtReportCode.Text = ""
        chkDisabled.Checked = False
        txtReportName.Text = ""
        txtReportTitle.Text = ""
        tdbcReportID.Text = ""
        tdbcReportID.AutoSelect = True
        txtReportCategoryName.Text = ""
        tdbcCustomReportID.Text = ""
        txtCustomReportName.Text = ""

        LoadTDBGridAdd()

        tabMain.SelectedIndex = 0
        txtReportCode.Focus()
    End Sub

    Private Sub LoadEdit()
        ReadOnlyControl(txtReportCode)
        LoadMaster()
        LoadTDBGrid()

        tabMain.SelectedIndex = 0
    End Sub

    Private Sub LoadTDBGridAdd()
        Dim sSQL As String = ""
        sSQL = "SELECT 	Null as OrderNum, Right(Code,2) As Code, ShortName" & UnicodeJoin(gbUnicode) & " as ShortName, Description84" & UnicodeJoin(gbUnicode) & " As Description" & vbCrLf
        sSQL &= "FROM D45T0020  WITH(NOLOCK) WHERE Code = '' " & vbCrLf
        sSQL &= "ORDER BY Code"

        Dim dtGridAdd As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGridAdd, gbUnicode)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcReportID
        LoadtdbcStandardReport(tdbcReportID, "45", "41", , gbUnicode)

        'Load tdbcCustomReportID
        LoadtdbcCustomizeReport(tdbcCustomReportID, "45", "D45F4020", , gbUnicode)
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL &= "Select ReportCode, Disabled, ReportName" & UnicodeJoin(gbUnicode) & " as ReportName, ReportTitle" & UnicodeJoin(gbUnicode) & " as ReportTitle," & vbCrLf
        sSQL &= "Col01, Col02, Col03, Col04, Col05, Col06, Col07, Col08, Col09, Col10, Col11, Col12" & vbCrLf
        sSQL &= ", Col13, Col14, Col15, Col16, Col17, Col18, Col19, Col20, Col21, Col22, Col23, Col24, Col25" & vbCrLf
        sSQL &= ", Col26, Col27, Col28, Col29, Col30," & vbCrLf
        sSQL &= "CustomReportID, ReportID, ColCaption01" & UnicodeJoin(gbUnicode) & " as ColCaption01, ColCaption02" & UnicodeJoin(gbUnicode) & " as ColCaption02, ColCaption03" & UnicodeJoin(gbUnicode) & " as ColCaption03," & vbCrLf
        sSQL &= "ColCaption04" & UnicodeJoin(gbUnicode) & " as ColCaption04, ColCaption05" & UnicodeJoin(gbUnicode) & " as ColCaption05, ColCaption06" & UnicodeJoin(gbUnicode) & " as ColCaption06, ColCaption07" & UnicodeJoin(gbUnicode) & " as ColCaption07, ColCaption08" & UnicodeJoin(gbUnicode) & " as ColCaption08, ColCaption09" & UnicodeJoin(gbUnicode) & " as ColCaption09, ColCaption10" & UnicodeJoin(gbUnicode) & " as ColCaption10," & vbCrLf
        sSQL &= "ColCaption11" & UnicodeJoin(gbUnicode) & " as ColCaption11, ColCaption12" & UnicodeJoin(gbUnicode) & " as ColCaption12, ColCaption13" & UnicodeJoin(gbUnicode) & " as ColCaption13, ColCaption14" & UnicodeJoin(gbUnicode) & " as ColCaption14, ColCaption15" & UnicodeJoin(gbUnicode) & " as ColCaption15, ColCaption16" & UnicodeJoin(gbUnicode) & " as ColCaption16, ColCaption17" & UnicodeJoin(gbUnicode) & " as ColCaption17," & vbCrLf
        sSQL &= "ColCaption18" & UnicodeJoin(gbUnicode) & " as ColCaption18, ColCaption19" & UnicodeJoin(gbUnicode) & " as ColCaption19, ColCaption20" & UnicodeJoin(gbUnicode) & " as ColCaption20, ColCaption21" & UnicodeJoin(gbUnicode) & " as ColCaption21, ColCaption22" & UnicodeJoin(gbUnicode) & " as ColCaption22, ColCaption23" & UnicodeJoin(gbUnicode) & " as ColCaption23, ColCaption24" & UnicodeJoin(gbUnicode) & " as ColCaption24," & vbCrLf
        sSQL &= "ColCaption25" & UnicodeJoin(gbUnicode) & " as ColCaption25, ColCaption26" & UnicodeJoin(gbUnicode) & " as ColCaption26, ColCaption27" & UnicodeJoin(gbUnicode) & " as ColCaption27, ColCaption28" & UnicodeJoin(gbUnicode) & " as ColCaption28, ColCaption29" & UnicodeJoin(gbUnicode) & " as ColCaption29, ColCaption30" & UnicodeJoin(gbUnicode) & " as ColCaption30" & vbCrLf
        sSQL &= "From D45T4030  WITH(NOLOCK)  Where ReportCode = " & SQLString(_reportCode)
        dtMaster = ReturnDataTable(sSQL)

        If dtMaster.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dtMaster.Rows.Count - 1
            With dtMaster.Rows(i)
                txtReportCode.Text = .Item("ReportCode").ToString
                chkDisabled.Checked = Convert.ToBoolean(.Item("Disabled"))
                txtReportName.Text = .Item("ReportName").ToString
                txtReportTitle.Text = .Item("ReportTitle").ToString
                tdbcCustomReportID.SelectedValue = .Item("CustomReportID").ToString
                tdbcReportID.SelectedValue = .Item("ReportID").ToString
            End With
        Next
    End Sub

    Private Sub LoadTDBGrid()
        If dtMaster.Rows.Count = 0 Then Exit Sub

        For i As Integer = 1 To 30
            GetItem("Col" & i.ToString("00"), "ColCaption" & i.ToString("00"))
        Next

        LoadDataSource(tdbg, dtGrid, gbUnicode)

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_Code).ToString <> "" And tdbg(i, COL_ShortName).ToString <> "" Then
                tdbg(i, COL_OrderNum) = i + 1
            End If
        Next

        'Xoa nhung dong trong tren luoi
        For i As Integer = tdbg.RowCount - 1 To 0 Step -1
            If tdbg(i, COL_OrderNum).ToString = "" Then
                tdbg.Delete(i)
            End If
        Next
    End Sub

    Private Sub GetItem(ByVal sColumnName1 As String, ByVal sColumnName2 As String)
        Dim Row As DataRow
        Row = dtGrid.NewRow
        Row("Code") = dtMaster.Rows(0).Item(sColumnName1)
        Row("ShortName") = dtMaster.Rows(0).Item(sColumnName2)
        dtGrid.Rows.Add(Row)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdCode
        sSQL = "SELECT 	Null as OrderNum, Right(Code,2) As Code, ShortName" & UnicodeJoin(gbUnicode) & " as ShortName, Description84" & UnicodeJoin(gbUnicode) & " As Description" & vbCrLf
        sSQL &= "FROM D45T0020  WITH(NOLOCK) WHERE Type='PWCAL' And Disabled=0 " & vbCrLf
        sSQL &= "ORDER BY Code"

        dtCode = ReturnDataTable(sSQL)
        LoadDataSource(tdbdCode, sSQL, gbUnicode)
    End Sub

    Private Sub InitdtGrid()
        dtGrid = dtCode.Clone

        'Create Primary key
        Dim keys(0) As DataColumn
        keys(0) = dtCode.Columns("Code")
        dtCode.PrimaryKey = keys
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
                sSQL.Append(SQLInsertD45T4030.ToString)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T4030.ToString)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            _reportCode = txtReportCode.Text

            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
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


    Private Function AllowSave() As Boolean
        If txtReportCode.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("_Ma_bao_cao")) 'Mã báo cáo
            tabMain.SelectedTab = tabMainInfo
            txtReportCode.Focus()
            Return False
        End If

        If txtReportName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_bao_cao"))
            tabMain.SelectedTab = tabMainInfo
            txtReportName.Focus()
            Return False
        End If

        If txtReportTitle.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Tieu_de"))
            tabMain.SelectedTab = tabMainInfo
            txtReportTitle.Focus()
            Return False
        End If

        If tdbcReportID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Dang_bao_cao"))
            tabMain.SelectedTab = tabMainInfo
            tdbcReportID.Focus()
            Return False
        End If

        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D45T4030", "ReportCode", txtReportCode.Text) Then
                D99C0008.MsgDuplicatePKey()
                tabMain.SelectedTab = tabMainInfo
                txtReportCode.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
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
    '# Title: SQLInsertD45T4030
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 10/12/2009 02:19:22
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T4030() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D45T4030(")
        sSQL.Append("ReportCode, ReportName, ReportNameU, ReportTitle, ReportTitleU, ReportID, CustomReportID, ")
        sSQL.Append("Disabled, Col01, Col02, Col03, Col04, ")
        sSQL.Append("Col05, Col06, Col07, Col08, Col09, ")
        sSQL.Append("Col10, Col11, Col12, Col13, Col14, ")
        sSQL.Append("Col15, Col16, Col17, Col18, Col19, ")
        sSQL.Append("Col20, Col21, Col22, Col23, Col24, ")
        sSQL.Append("Col25, Col26, Col27, Col28, Col29, ")
        sSQL.Append("Col30, ColCaption01, ColCaption01U, ColCaption02, ColCaption02U, ColCaption03, ColCaption03U, ColCaption04, ColCaption04U, ")
        sSQL.Append("ColCaption05, ColCaption05U, ColCaption06, ColCaption06U, ColCaption07, ColCaption07U, ColCaption08, ColCaption08U, ColCaption09, ColCaption09U, ")
        sSQL.Append("ColCaption10, ColCaption10U, ColCaption11, ColCaption11U, ColCaption12, ColCaption12U, ColCaption13, ColCaption13U, ColCaption14, ColCaption14U, ")
        sSQL.Append("ColCaption15, ColCaption15U, ColCaption16, ColCaption16U, ColCaption17, ColCaption17U, ColCaption18, ColCaption18U, ColCaption19, ColCaption19U, ")
        sSQL.Append("ColCaption20, ColCaption20U, ColCaption21, ColCaption21U, ColCaption22, ColCaption22U, ColCaption23, ColCaption23U, ColCaption24, ColCaption24U, ")
        sSQL.Append("ColCaption25, ColCaption25U, ColCaption26, ColCaption26U, ColCaption27, ColCaption27U, ColCaption28, ColCaption28U, ColCaption29, ColCaption29U, ")
        sSQL.Append("ColCaption30, ColCaption30U, CreateDate, CreateUserID, LastModifyDate, LastModifyUserID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtReportCode.Text) & COMMA) 'ReportCode, varchar[20], NULL

        sSQL.Append(SQLStringUnicode(txtReportName.Text, gbUnicode, False) & COMMA) 'ReportName, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(txtReportName.Text, gbUnicode, True) & COMMA) 'ReportName, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(txtReportTitle.Text, gbUnicode, False) & COMMA) 'ReportTitle, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtReportTitle.Text, gbUnicode, True) & COMMA) 'ReportTitle, varchar[250], NULL

        sSQL.Append(SQLString(tdbcReportID.Text) & COMMA) 'ReportID, varchar[20], NULL
        sSQL.Append(SQLString(tdbcCustomReportID.Text) & COMMA) 'CustomReportID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NULL
        sSQL.Append(SQLString(tdbg(0, COL_Code)) & COMMA) 'Col01, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(1, COL_Code)) & COMMA) 'Col02, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(2, COL_Code)) & COMMA) 'Col03, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(3, COL_Code)) & COMMA) 'Col04, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(4, COL_Code)) & COMMA) 'Col05, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(5, COL_Code)) & COMMA) 'Col06, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(6, COL_Code)) & COMMA) 'Col07, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(7, COL_Code)) & COMMA) 'Col08, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(8, COL_Code)) & COMMA) 'Col09, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(9, COL_Code)) & COMMA) 'Col10, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(10, COL_Code)) & COMMA) 'Col11, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(11, COL_Code)) & COMMA) 'Col12, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(12, COL_Code)) & COMMA) 'Col13, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(13, COL_Code)) & COMMA) 'Col14, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(14, COL_Code)) & COMMA) 'Col15, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(15, COL_Code)) & COMMA) 'Col16, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(16, COL_Code)) & COMMA) 'Col17, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(17, COL_Code)) & COMMA) 'Col18, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(18, COL_Code)) & COMMA) 'Col19, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(19, COL_Code)) & COMMA) 'Col20, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(20, COL_Code)) & COMMA) 'Col21, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(21, COL_Code)) & COMMA) 'Col22, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(22, COL_Code)) & COMMA) 'Col23, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(23, COL_Code)) & COMMA) 'Col24, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(24, COL_Code)) & COMMA) 'Col25, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(25, COL_Code)) & COMMA) 'Col26, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(26, COL_Code)) & COMMA) 'Col27, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(27, COL_Code)) & COMMA) 'Col28, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(28, COL_Code)) & COMMA) 'Col29, varchar[20], NULL
        sSQL.Append(SQLString(tdbg(29, COL_Code)) & COMMA) 'Col30, varchar[20], NULL

        sSQL.Append(SQLStringUnicode(tdbg(0, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption01, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(0, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption01, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(1, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption02, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(1, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption02, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(2, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption03, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(2, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption03, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(3, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption04, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(3, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption04, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(4, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption05, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(4, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption05, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(5, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption06, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(5, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption06, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(6, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption07, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(6, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption07, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(7, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption08, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(7, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption08, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(8, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption09, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(8, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption09, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(9, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption10, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(9, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption10, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(10, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption11, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(10, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption11, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(11, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption12, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(11, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption12, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(12, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption13, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(12, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption13, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(13, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption14, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(13, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption14, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(14, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption15, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(14, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption15, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(15, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption16, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(15, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption16, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(16, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption17, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(16, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption17, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(17, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption18, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(17, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption18, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(18, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption19, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(18, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption19, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(19, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption20, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(19, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption20, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(20, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption21, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(20, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption21, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(21, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption22, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(21, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption22, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(22, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption23, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(22, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption23, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(23, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption24, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(23, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption24, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(24, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption25, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(24, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption25, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(25, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption26, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(25, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption26, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(26, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption27, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(26, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption27, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(27, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption28, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(27, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption28, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(28, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption29, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(28, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption29, varchar[50], NULL

        sSQL.Append(SQLStringUnicode(tdbg(29, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'ColCaption30, varchar[50], NULL
        sSQL.Append(SQLStringUnicode(tdbg(29, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'ColCaption30, varchar[50], NULL

        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID)) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T4030
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 10/12/2009 02:19:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T4030() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T4030 Set ")
        sSQL.Append("ReportName = " & SQLStringUnicode(txtReportName.Text, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ReportNameU = " & SQLStringUnicode(txtReportName.Text, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ReportTitle = " & SQLStringUnicode(txtReportTitle.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("ReportTitleU = " & SQLStringUnicode(txtReportTitle.Text, gbUnicode, True) & COMMA) 'varchar[250], NULL
        sSQL.Append("ReportID = " & SQLString(tdbcReportID.Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("CustomReportID = " & SQLString(tdbcCustomReportID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NULL
        sSQL.Append("Col01 = " & SQLString(tdbg(0, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col02 = " & SQLString(tdbg(1, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col03 = " & SQLString(tdbg(2, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col04 = " & SQLString(tdbg(3, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col05 = " & SQLString(tdbg(4, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col06 = " & SQLString(tdbg(5, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col07 = " & SQLString(tdbg(6, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col08 = " & SQLString(tdbg(7, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col09 = " & SQLString(tdbg(8, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col10 = " & SQLString(tdbg(9, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col11 = " & SQLString(tdbg(10, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col12 = " & SQLString(tdbg(11, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col13 = " & SQLString(tdbg(12, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col14 = " & SQLString(tdbg(13, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col15 = " & SQLString(tdbg(14, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col16 = " & SQLString(tdbg(15, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col17 = " & SQLString(tdbg(16, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col18 = " & SQLString(tdbg(17, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col19 = " & SQLString(tdbg(18, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col20 = " & SQLString(tdbg(19, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col21 = " & SQLString(tdbg(20, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col22 = " & SQLString(tdbg(21, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col23 = " & SQLString(tdbg(22, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col24 = " & SQLString(tdbg(23, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col25 = " & SQLString(tdbg(24, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col26 = " & SQLString(tdbg(25, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col27 = " & SQLString(tdbg(26, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col28 = " & SQLString(tdbg(27, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col29 = " & SQLString(tdbg(28, COL_Code)) & COMMA) 'varchar[20], NULL
        sSQL.Append("Col30 = " & SQLString(tdbg(29, COL_Code)) & COMMA) 'varchar[20], NULL

        sSQL.Append("ColCaption01 = " & SQLStringUnicode(tdbg(0, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption02 = " & SQLStringUnicode(tdbg(1, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption03 = " & SQLStringUnicode(tdbg(2, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption04 = " & SQLStringUnicode(tdbg(3, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption05 = " & SQLStringUnicode(tdbg(4, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption06 = " & SQLStringUnicode(tdbg(5, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption07 = " & SQLStringUnicode(tdbg(6, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption08 = " & SQLStringUnicode(tdbg(7, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption09 = " & SQLStringUnicode(tdbg(8, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption10 = " & SQLStringUnicode(tdbg(9, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption11 = " & SQLStringUnicode(tdbg(10, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption12 = " & SQLStringUnicode(tdbg(11, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption13 = " & SQLStringUnicode(tdbg(12, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption14 = " & SQLStringUnicode(tdbg(13, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption15 = " & SQLStringUnicode(tdbg(14, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption16 = " & SQLStringUnicode(tdbg(15, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption17 = " & SQLStringUnicode(tdbg(16, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption18 = " & SQLStringUnicode(tdbg(17, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption19 = " & SQLStringUnicode(tdbg(18, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption20 = " & SQLStringUnicode(tdbg(18, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption21 = " & SQLStringUnicode(tdbg(20, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption22 = " & SQLStringUnicode(tdbg(21, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption23 = " & SQLStringUnicode(tdbg(22, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption24 = " & SQLStringUnicode(tdbg(23, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption25 = " & SQLStringUnicode(tdbg(24, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption26 = " & SQLStringUnicode(tdbg(25, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption27 = " & SQLStringUnicode(tdbg(26, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption28 = " & SQLStringUnicode(tdbg(27, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption29 = " & SQLStringUnicode(tdbg(28, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption30 = " & SQLStringUnicode(tdbg(29, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[50], NULL

        sSQL.Append("ColCaption01U = " & SQLStringUnicode(tdbg(0, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption02U = " & SQLStringUnicode(tdbg(1, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption03U = " & SQLStringUnicode(tdbg(2, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption04U = " & SQLStringUnicode(tdbg(3, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption05U = " & SQLStringUnicode(tdbg(4, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption06U = " & SQLStringUnicode(tdbg(5, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption07U = " & SQLStringUnicode(tdbg(6, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption08U = " & SQLStringUnicode(tdbg(7, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption09U = " & SQLStringUnicode(tdbg(8, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption10U = " & SQLStringUnicode(tdbg(9, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption11U = " & SQLStringUnicode(tdbg(10, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption12U = " & SQLStringUnicode(tdbg(11, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption13U = " & SQLStringUnicode(tdbg(12, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption14U = " & SQLStringUnicode(tdbg(13, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption15U = " & SQLStringUnicode(tdbg(14, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption16U = " & SQLStringUnicode(tdbg(15, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption17U = " & SQLStringUnicode(tdbg(16, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption18U = " & SQLStringUnicode(tdbg(17, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption19U = " & SQLStringUnicode(tdbg(18, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption20U = " & SQLStringUnicode(tdbg(18, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption21U = " & SQLStringUnicode(tdbg(20, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption22U = " & SQLStringUnicode(tdbg(21, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption23U = " & SQLStringUnicode(tdbg(22, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption24U = " & SQLStringUnicode(tdbg(23, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption25U = " & SQLStringUnicode(tdbg(24, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption26U = " & SQLStringUnicode(tdbg(25, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption27U = " & SQLStringUnicode(tdbg(26, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption28U = " & SQLStringUnicode(tdbg(27, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption29U = " & SQLStringUnicode(tdbg(28, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL
        sSQL.Append("ColCaption30U = " & SQLStringUnicode(tdbg(29, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[50], NULL

        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID)) 'varchar[20], NULL
        sSQL.Append(" Where ReportCode = " & SQLString(txtReportCode.Text))
        Return sSQL
    End Function

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        btnNext.Enabled = False
        btnSave.Enabled = True

        LoadAdd()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Function CheckTDBGRowCount() As Boolean
        If tdbg.RowCount > 30 Then
            D99C0008.MsgL3(rl3("Du_lieu_tren_luoi_khong_duoc_vuot_qua_30_dong"))
            tdbg.Focus()
            Return True
        End If
        Return False
    End Function


    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        If tdbg.Columns(COL_Code).Text <> "" And tdbg.Columns(COL_ShortName).Text <> "" Then
            tdbg.Columns(COL_OrderNum).Text = (tdbg.Bookmark + 1).ToString
        End If
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_Code
                tdbg.Columns(COL_Code).Text = tdbdCode.Columns("Code").Value.ToString
                tdbg.Columns(COL_ShortName).Text = tdbdCode.Columns("ShortName").Value.ToString
                If tdbg.Columns(COL_Code).Text <> "" And tdbg.Columns(COL_ShortName).Text <> "" Then
                    tdbg.Columns(COL_OrderNum).Text = (tdbg.Bookmark + 1).ToString
                End If

                If CheckTDBGRowCount() = True Then tdbg.Delete()
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_Code
                If tdbg.Columns(COL_Code).Text <> tdbdCode.Columns("Code").Text Then
                    tdbg.Columns(COL_Code).Text = ""
                    tdbg.Columns(COL_ShortName).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.RowCount = 0 Then Exit Sub

        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.S Then
            Select Case tdbg.Col
                Case COL_Code, COL_ShortName
                    CopyColumns(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Value.ToString, tdbg.Row)
                    UpdateTDBGOrderNum(tdbg, COL_OrderNum)
            End Select
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            If tdbg.Col = COL_ShortName Then HotKeyEnterGrid(tdbg, COL_Code, e)
            Exit Sub
        ElseIf e.Shift And (e.KeyCode = Keys.Insert) Then
            HotKeyShiftInsert(tdbg, COL_OrderNum)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_Code, 0, 0)
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount = 0 Then Exit Sub

        Select Case e.ColIndex
            Case COL_Code, COL_ShortName
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Value.ToString, tdbg.Row)
                UpdateTDBGOrderNum(tdbg, COL_OrderNum)
        End Select
    End Sub

    Private Sub tabMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMain.Click
        If tabMain.SelectedIndex = 0 Then
            txtReportCode.Focus()
        Else
            tdbg.Focus()
            tdbg.Col = COL_Code
            tdbg.SplitIndex = 0
            tdbg.Bookmark = 0
        End If
    End Sub

End Class