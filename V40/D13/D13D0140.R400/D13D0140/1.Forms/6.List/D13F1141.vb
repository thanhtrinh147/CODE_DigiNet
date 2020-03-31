Imports System
Public Class D13F1141
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Dim bUnicode As Boolean = L3Bool(gbUnicode)
    Dim iValidDateMode As Byte = 0

#Region "Const of tdbg"
    Private Const COL_Description As Integer = 0    ' Diễn giải
    Private Const COL_Description01 As Integer = 1  ' Diễn giải
    Private Const COL_Short As Integer = 2          ' Tên tắt
    Private Const COL_CalculateOrder As Integer = 3 ' Thứ tự tính
    Private Const COL_Formula As Integer = 4        ' Công thức
    Private Const COL_FormulaDesc As Integer = 5    ' Diễn giải công thức
    Private Const COL_Code As Integer = 6           ' Code
#End Region

#Region "Const of tdbg1"
    Private Const COL1_TypeID As Integer = 0       ' TypeID
    Private Const COL1_Description As Integer = 1  ' Mã loại phân tích
    Private Const COL1_NCodeID As Integer = 2      ' Mã phân tích
    Private Const COL1_Descriptions As Integer = 3 ' Diễn giải
#End Region


    Private _Disabled As Boolean = False
    Public WriteOnly Property Disabled() As Boolean
        Set(ByVal value As Boolean)
            _Disabled = value
        End Set
    End Property

    Private _SalaryObjectID As String = ""
    Public Property SalaryObjectID() As String
        Get
            Return _SalaryObjectID
        End Get
        Set(ByVal value As String)
            _SalaryObjectID = value
        End Set
    End Property

    Private _salaryObjectName As String = ""
    Public WriteOnly Property SalaryObjectName() As String
        Set(ByVal Value As String)
            _salaryObjectName = Value
        End Set
    End Property

    Private _shortSalObjectName As String = ""
    Public WriteOnly Property ShortSalObjectName() As String
        Set(ByVal Value As String)
            _shortSalObjectName = value
        End Set
    End Property

    Private _dutyID As String = ""
    Public WriteOnly Property DutyID() As String
        Set(ByVal Value As String)
            _dutyID = Value
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
            LoadTDBDropDown()
            LoadTdbg(_SalaryObjectID)

            Select Case _FormState
                Case EnumFormState.FormAdd
                    optValidDate3.Checked = True
                    iValidDateMode = 3
                    'CheckIdTextBoxG4(txtSalaryObjectID)
                    LoadAdd()

                Case EnumFormState.FormEdit
                    LoadEdit()

                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
            LoadTDBG1()
            LoadTab3Valid()
        End Set
    End Property

    Private Sub EnableForOptValidDate4()
        Select Case iValidDateMode
            Case 4
                chkIsCheckContract.Enabled = True
                tdbcDateEndSalObjectID.Enabled = False
                tdbcDateEndSalObjectID.Text = ""
            Case 5
                chkIsCheckContract.Enabled = False
                chkIsCheckContract.Checked = False
                txtMonthContractNum.Enabled = False
                txtMonthContractNum.Text = ""
                tdbcDateEndSalObjectID.Enabled = True
            Case Else
                chkIsCheckContract.Enabled = False
                chkIsCheckContract.Checked = False
                txtMonthContractNum.Enabled = False
                txtMonthContractNum.Text = ""
                tdbcDateEndSalObjectID.Enabled = False
                tdbcDateEndSalObjectID.Text = ""
        End Select

    End Sub

    Private Sub LoadTdbg(ByVal sSalaryObjectID As String)
        Dim sSQL As New StringBuilder(693)
        sSQL.Append(" SELECT		" & vbCrLf)
        sSQL.Append(" 				D.Code," & vbCrLf)
        sSQL.Append(" 				D.Short," & vbCrLf)
        sSQL.Append(" 				D.ShortU," & vbCrLf)
        sSQL.Append(" 				D.Description," & vbCrLf)
        sSQL.Append(" 				D.DescriptionU," & vbCrLf)
        sSQL.Append(" 				D.Description01," & vbCrLf)
        sSQL.Append(" 				D.Description01U," & vbCrLf)
        sSQL.Append(" 				Isnull(D1.CalOrder,0) As CalculateOrder, " & vbCrLf)
        sSQL.Append(" 				Isnull(D1.Formula, '') as Formula,				" & vbCrLf)
        sSQL.Append(" 				Isnull(D1.FormulaDesc, '') as FormulaDesc," & vbCrLf)
        sSQL.Append(" 				Isnull(D1.FormulaDescU, '') as FormulaDescU" & vbCrLf)
        sSQL.Append(" 	FROM		D13T9000 D WITH (NOLOCK) " & vbCrLf)
        sSQL.Append(" 	LEFT JOIN	D13T1021 D1 WITH (NOLOCK) " & vbCrLf)
        sSQL.Append(" 		ON		D.Code = D1.Code" & vbCrLf)
        sSQL.Append(" 				AND D1.SalaryObjectID = " & SQLString(sSalaryObjectID) & vbCrLf)
        sSQL.Append(" 	WHERE		Type IN ('SALBA','SALCE') " & vbCrLf)
        sSQL.Append(" 				AND Disabled = 0" & vbCrLf)
        sSQL.Append(" 	ORDER BY	D.Code" & vbCrLf)
        'Dim dt As DataTable = ReturnDataTable(sSQL.ToString)
        LoadDataSource(tdbg, sSQL.ToString, bUnicode)

    End Sub

    Private Sub LoadEdit()
        btnNext.Visible = False
        btnSave.Left = btnNext.Left
        LoadEditData()
    End Sub

    Private Sub LoadEditData()
        txtSalaryObjectID.ReadOnly = True
        txtSalaryObjectID.Text = _SalaryObjectID
        txtSalaryObjectName.Text = _salaryObjectName
        chkDisabled.Checked = _Disabled
        txtShortSelObjectName.Text = _shortSalObjectName
        tdbcDutyName.SelectedValue = _dutyID

    End Sub

    Private Sub LoadAdd()
        btnNext.Enabled = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAdd()
        btnSave.Enabled = True
        txtSalaryObjectID.Text = ""
        txtSalaryObjectName.Text = ""
        chkDisabled.Checked = False
        optValidDate3.Checked = True
        iValidDateMode = 3
        EnableForOptValidDate4()

        LoadTdbg("")
        txtSalaryObjectID.Focus()
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        If e.Row >= 0 And e.ColIndex = COL_Formula Then
            If gbUnicode Then
                e.CellTip = rl3("Nhan_F6_chon_cong_thucU")
            Else
                e.CellTip = rl3("Nhan_F6_chon_cong_thuc")
            End If
        Else
            e.CellTip = ""
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown

        If e.Control = True And e.KeyCode = Keys.V Then
            e.Handled = True
            e.SuppressKeyPress = True
            tdbg.Columns(tdbg.Col).Text = Clipboard.GetText()
            tdbg.UpdateData()
        End If

        Select Case e.KeyCode
            Case Keys.Enter
                If tdbg.Row + 1 = tdbg.RowCount And tdbg.Col = COL_FormulaDesc Then
                    tdbg.Row = 0
                    tdbg.Col = COL_CalculateOrder
                    tdbg.SplitIndex = 0
                    e.SuppressKeyPress = True
                    e.Handled = True
                End If
                'HotKeyEnterGrid(tdbg, COL_CalculateOrder, e)

            Case Keys.F7
                HotKeyF7(tdbg)

            Case Keys.F6
                If tdbg.Col = COL_Formula Then

                    Dim arrPro() As StructureProperties = Nothing
                    SetProperties(arrPro, "Mode", "2")
                    Dim frm As Form = CallFormShowDialog("D21D0140", "D21F0005", arrPro)
                    Dim sFormula As String = GetProperties(frm, "sFormula_D21F0005").ToString
                    'Dim f As New D21F0005
                    '                    f.Mode = 2
                    '                    f.ShowDialog()
                    If sFormula <> "" Then

                        Dim iCurrentPos As Integer = tdbg.SelectionStart
                        Dim sFormular As String = tdbg.Columns(tdbg.Col).Text
                        Dim sTextBefore As String = sFormular.Substring(0, iCurrentPos)
                        Dim sTextAfter As String = sFormular.Substring(iCurrentPos, sFormular.Length - iCurrentPos)
                        tdbg.Columns(tdbg.Col).Value = sTextBefore & sFormula & sTextAfter
                        tdbg.UpdateData()

                        'tdbg.SplitIndex = 0
                        'tdbg.Row = tdbg.Bookmark
                        'tdbg.Col = COL_Formula
                        'tdbg.Focus()
                        'tdbg.Select()

                        tdbg.EditActive = True
                        tdbg.SelectionStart = (sTextBefore & sFormula).Length
                    End If

                    ' f.Dispose()
                End If
            Case Else
                HotKeyDownGrid(e, tdbg, COL_CalculateOrder)
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_CalculateOrder
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_Formula
                e.KeyChar = UCase(e.KeyChar) 'Nhập các ký tự hoa
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_CalculateOrder
                If Not L3IsNumeric(tdbg.Columns(COL_CalculateOrder).Text, EnumDataType.Int) Then e.Cancel = True
            Case COL_Formula
                e.Cancel = L3IsFormula(tdbg, e.ColIndex)
        End Select
    End Sub

    Private Function AllowSave() As Boolean
        If txtSalaryObjectID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtSalaryObjectID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D13T1020", "SalaryObjectID", txtSalaryObjectID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtSalaryObjectID.Focus()
                Return False
            End If
        End If

        If optValidDate4.Checked AndAlso chkIsCheckContract.Checked AndAlso txtMonthContractNum.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Thoi_han_HDLD"))
            txtMonthContractNum.Focus()
            Return False
        End If

        If optValidDate5.Checked AndAlso tdbcDateEndSalObjectID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Doi_tuong_tinh_luong"))
            tdbcDateEndSalObjectID.Focus()
            Return False
        End If

        tdbg.UpdateData()
        tdbg1.UpdateData()
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_CalculateOrder).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Thu_tu_tinh"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_CalculateOrder
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Description01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Short).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub D13F1061_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        End If
        If e.Alt Then
            Select Case e.KeyCode
                Case Keys.NumPad1, Keys.D1
                    tabMain.SelectedTab = tabSub1
                    tdbg.Focus()
                    Exit Sub
                Case Keys.NumPad2, Keys.D2
                    tabMain.SelectedTab = tabSub2
                    tdbg1.Col = COL1_NCodeID
                    tdbg1.Focus()
                    Exit Sub

            End Select
        End If


    End Sub

    Private Sub D13F1061_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        tdbg_LockedColumns()
        Loadlanguage()
        VisibleColDescription()
        UnicodeGridDataField(tdbg, UnicodeArrayCOL(), bUnicode)
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBoxG4(txtSalaryObjectID)
        tdbg1_LockedColumns()
        SetBackColorObligatory()
        tdbg.CellTips = C1.Win.C1TrueDBGrid.CellTipEnum.Floating
        _bSaved = False
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VisibleColDescription()
        If geLanguage = EnumLanguage.Vietnamese Then
            tdbg.Splits(0).DisplayColumns(COL_Description01).Visible = False
        Else
            tdbg.Splits(0).DisplayColumns(COL_Description).Visible = False
        End If
    End Sub

    Private Function UnicodeArrayCOL() As Integer()
        If Not bUnicode Then Return Nothing
        Dim ArrCOL() As Integer = {COL_Description, COL_Description01, COL_Short, COL_FormulaDesc}
        Return ArrCOL
    End Function

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_doi_tuong_tinh_luong_-__D13F1141") & UnicodeCaption(bUnicode) 'CËp nhËt ¢çi t§íng tÛnh l§¥ng -  D13F1141
        '================================================================ 
        lblSalaryObjectID.Text = rl3("Ma") 'Mã
        lblSalaryObjectName.Text = rl3("Ten") 'Tên
        lblF6.Text = rl3("Nhan_F6_de_chon_cong_thuc") 'Nhấn F6 để chọn công thức
        lblShortSelObjectName.Text = rl3("Ten_tat") 'Tên tắt
        lblDutyName.Text = rl3("Chuc_vu") 'Chức vụ
        lblMonth1.Text = rl3("(thang)") '(Tháng)
        lblMaintainedMonthNum.Text = rl3("Thoi_gian_giu_doi_tuong_tinh_luong") 'Thời gian giữ đối tượng tính lương
        lblNextSalaryObjectID.Text = rl3("Doi_tuong_tinh_luong_tiep_theo") 'Đối tượng tính lương tiếp theo
        lblMonth.Text = rl3("(thang)") '(Tháng)
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkIsCheckContract.Text = rl3("Thoi_han_HDLD") 'Thời hạn HĐLĐ
        '================================================================ 
        optValidDate5.Text = rl3("Ngay_ket_thuc_doi_tuong_tinh_luong") 'Ngày kết thúc đối tượng tính lương
        optValidDate4.Text = rl3("Ngay_ky_HDLD") 'Ngày ký HĐLĐ
        optValidDate3.Text = rl3("Ngay_vao_lam") 'Ngày vào làm
        optValidDate2.Text = rl3("Ngay_ket_thuc_thu_viec") 'Ngày kết thức thử việc
        optValidDate1.Text = rl3("Ngay_bat_dau_thu_viec") 'Ngày bắt đầu thử việc
        '================================================================ 
        grpValidDate.Text = rl3("Ngay_hieu_luc") 'Ngày hiệu lực
        '================================================================ 
        tabSub1.Text = "1. " & rl3("Thong_so_luong") 'Thông số lương
        tabSub2.Text = "2. " & rl3("Ma_phan_tich_nhan_su") 'Mã phân tích nhân sự
        tabSub3.Text = "3. " & rl3("Thong_tin_hieu_luc") 'Thông tin hiệu lực
        '================================================================ 
        tdbcDutyName.Columns("DutyID").Caption = rl3("Ma") 'Mã
        tdbcDutyName.Columns("DutyName").Caption = rl3("Ten") 'Tên
        tdbcNextSalaryObjectID.Columns("SalaryObjectID").Caption = rl3("Ma") 'Mã
        tdbcNextSalaryObjectID.Columns("SalaryObjectName").Caption = rl3("Ten") 'Tên
        tdbcDateEndSalObjectID.Columns("SalaryObjectID").Caption = rl3("Ma") 'Mã
        tdbcDateEndSalObjectID.Columns("SalaryObjectName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdNCodeID.Columns("NCodeID").Caption = rl3("Ma") 'Mã
        tdbdNCodeID.Columns("Description").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("Description01").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("Short").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg.Columns("CalculateOrder").Caption = rl3("Thu_tu_tinh") 'Thứ tự tính
        tdbg.Columns("Formula").Caption = rl3("Cong_thuc") 'Công thức
        tdbg.Columns("FormulaDesc").Caption = rl3("Dien_giai_cong_thuc") 'Diễn giải công thức

        tdbg1.Columns("Description").Caption = rl3("Ma_loai_phan_tich") 'Mã loại phân tích
        tdbg1.Columns("NCodeID").Caption = rl3("Ma_phan_tich") 'Mã phân tích
        tdbg1.Columns("Descriptions").Caption = rl3("Dien_giai") 'Diễn giải
    End Sub


    Private Sub SetBackColorObligatory()
        txtSalaryObjectID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtMonthContractNum.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDateEndSalObjectID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD13T1020)
                sSQL.Append(SQLInsertD13T1021s)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T1020)
                sSQL.Append(SQLDeleteD13T1021)
                sSQL.Append(SQLInsertD13T1021s)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            SaveOK()
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    _SalaryObjectID = txtSalaryObjectID.Text
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

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1020
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 11/11/2009 11:31:55
    '# Modified User: Nguyễn Thị Minh Hòa
    '# Modified Date: 15/03/2012 11:29:20
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1020() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D13T1020(")
        sSQL.Append("SalaryObjectID, SalaryObjectName, SalaryObjectNameU, Disabled, CreateUserID, LastModifyUserID, ")
        sSQL.Append("CreateDate, LastModifyDate," & vbCrLf)
        sSQL.Append("N01ID, N02ID, ")
        sSQL.Append("N03ID, N04ID, N05ID, N06ID, N07ID, ")
        sSQL.Append("N08ID, N09ID, N10ID, N11ID, N12ID, ")
        sSQL.Append("N13ID, N14ID, N15ID, N16ID, N17ID, ")
        sSQL.Append("N18ID, N19ID, N20ID, " & vbCrLf)
        sSQL.Append("ShortSalObjectName, ShortSalObjectNameU, DutyID " & vbCrLf)
        sSQL.Append(", ValidDateMode, MonthContractNum, DateEndSalObjectID, MaintainedMonthNum, ")
        sSQL.Append("NextSalaryObjectID, IsCheckContract")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(txtSalaryObjectID.Text) & COMMA) 'SalaryObjectID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtSalaryObjectName, False) & COMMA) 'SalaryObjectName, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtSalaryObjectName, True) & COMMA) 'SalaryObjectName, varchar[250], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append("GetDate()" & COMMA & vbCrLf) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N01")) & COMMA) 'N01ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N02")) & COMMA) 'N02ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N03")) & COMMA) 'N03ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N04")) & COMMA) 'N04ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N05")) & COMMA) 'N05ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N06")) & COMMA) 'N06ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N07")) & COMMA) 'N07ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N08")) & COMMA) 'N08ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N09")) & COMMA) 'N09ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N10")) & COMMA) 'N10ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N11")) & COMMA) 'N11ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N12")) & COMMA) 'N12ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N13")) & COMMA) 'N13ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N14")) & COMMA) 'N14ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N15")) & COMMA) 'N15ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N16")) & COMMA) 'N16ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N17")) & COMMA) 'N17ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N18")) & COMMA) 'N18ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N19")) & COMMA) 'N19ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(GetNCodeID("N20")) & COMMA & vbCrLf) 'N20ID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtShortSelObjectName.Text, gbUnicode, False) & COMMA) 'ShortSalObjectName, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtShortSelObjectName.Text, gbUnicode, True) & COMMA) 'ShortSalObjectNameU, nvarchar, NOT NULL
        sSQL.Append(SQLString(tdbcDutyName.SelectedValue) & COMMA) 'DutyID, varchar[50], NOT NULL

        sSQL.Append(SQLNumber(iValidDateMode) & COMMA) 'ValidDateMode, tinyint, NOT NULL
        sSQL.Append(SQLNumber(txtMonthContractNum.Text) & COMMA) 'MonthContractNum, int, NOT NULL
        sSQL.Append(SQLString(tdbcDateEndSalObjectID.SelectedValue) & COMMA) 'DateEndSalObjectID, varchar[50], NOT NULL
        sSQL.Append(SQLNumber(txtMaintainedMonthNum.Text) & COMMA) 'MaintainedMonthNum, int, NOT NULL
        sSQL.Append(SQLString(tdbcDateEndSalObjectID.SelectedValue) & COMMA) 'NextSalaryObjectID, varchar[50], NOT NULL
        sSQL.Append(SQLNumber(chkIsCheckContract.Checked)) 'IsCheckContract, tinyint, NOT NULL

        sSQL.Append(")")
        sSQL.Append(vbCrLf)
        Return sSQL
    End Function

    Dim iCount As Integer = 0 'Index để quét dòng tiếp theo
    Private Function GetNCodeID(ByVal sTypeID As String) As String
        For i As Integer = iCount To tdbg1.RowCount - 1
            If tdbg1(i, COL1_TypeID).ToString = sTypeID Then
                iCount += 1
                Return tdbg1(i, COL1_NCodeID).ToString
            End If
        Next
        Return ""
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1020
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 11/11/2009 11:32:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1020() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T1020 Set ")
        sSQL.Append("SalaryObjectName = " & SQLStringUnicode(txtSalaryObjectName, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("SalaryObjectNameU = " & SQLStringUnicode(txtSalaryObjectName, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
        sSQL.Append("N01ID = " & SQLString(GetNCodeID("N01")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N02ID = " & SQLString(GetNCodeID("N02")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N03ID = " & SQLString(GetNCodeID("N03")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N04ID = " & SQLString(GetNCodeID("N04")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N05ID = " & SQLString(GetNCodeID("N05")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N06ID = " & SQLString(GetNCodeID("N06")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N07ID = " & SQLString(GetNCodeID("N07")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N08ID = " & SQLString(GetNCodeID("N08")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N09ID = " & SQLString(GetNCodeID("N09")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N10ID = " & SQLString(GetNCodeID("N10")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N11ID = " & SQLString(GetNCodeID("N11")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N12ID = " & SQLString(GetNCodeID("N12")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N13ID = " & SQLString(GetNCodeID("N13")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N14ID = " & SQLString(GetNCodeID("N14")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N15ID = " & SQLString(GetNCodeID("N15")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N16ID = " & SQLString(GetNCodeID("N16")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N17ID = " & SQLString(GetNCodeID("N17")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N18ID = " & SQLString(GetNCodeID("N18")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N19ID = " & SQLString(GetNCodeID("N19")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("N20ID = " & SQLString(GetNCodeID("N20")) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("ShortSalObjectName = " & SQLStringUnicode(txtShortSelObjectName.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("ShortSalObjectNameU = " & SQLStringUnicode(txtShortSelObjectName.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("DutyID = " & SQLString(tdbcDutyName.SelectedValue) & COMMA) 'varchar[50], NOT NULL

        sSQL.Append("ValidDateMode = " & SQLNumber(iValidDateMode) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("MonthContractNum = " & SQLNumber(txtMonthContractNum.Text) & COMMA) 'int, NOT NULL
        sSQL.Append("DateEndSalObjectID = " & SQLString(tdbcDateEndSalObjectID.SelectedValue) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("MaintainedMonthNum = " & SQLNumber(txtMaintainedMonthNum.Text) & COMMA) 'int, NOT NULL
        sSQL.Append("NextSalaryObjectID = " & SQLString(tdbcNextSalaryObjectID.SelectedValue) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("IsCheckContract = " & SQLNumber(chkIsCheckContract.Checked)) 'tinyint, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("SalaryObjectID = " & SQLString(_SalaryObjectID))
        sSQL.Append(vbCrLf)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1021
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 11/11/2009 11:32:29
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1021() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T1021"
        sSQL &= " Where "
        sSQL &= "SalaryObjectID = " & SQLString(_SalaryObjectID)
        Return sSQL & vbCrLf
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1021s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 11/11/2009 11:32:41
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1021s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D13T1021(")
            sSQL.Append("SalaryObjectID, Code, CalOrder, Formula, FormulaDesc, FormulaDescU")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtSalaryObjectID.Text) & COMMA) 'SalaryObjectID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Code)) & COMMA) 'Code [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_CalculateOrder)) & COMMA) 'CalOrder, tinyint, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Formula)) & COMMA) 'Formula, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_FormulaDesc), bUnicode, False) & COMMA) 'FormulaDesc, varchar[8000], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_FormulaDesc), bUnicode, True)) 'FormulaDesc, varchar[8000], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDutyName
        sSQL &= "SELECT DutyID, " & IIf(geLanguage = EnumLanguage.Vietnamese, "DutyName", "DutyName01").ToString & UnicodeJoin(gbUnicode) & " as DutyName"
        sSQL &= " FROM D09T0211  WITH (NOLOCK) " & vbCrLf
        sSQL &= " WHERE Disabled = 0 " & vbCrLf
        sSQL &= " ORDER BY  DutyID" & vbCrLf

        LoadDataSource(tdbcDutyName, sSQL, gbUnicode)
        tdbcDutyName.SelectedValue = _dutyID

        'Load tdbcDateEndSalObjectID
        sSQL = "Select SalaryObjectID, SalaryObjectName" & UnicodeJoin(gbUnicode) & " as SalaryObjectName From D13T1020  WITH (NOLOCK) WHERE Disabled = 0 ORDER BY SalaryObjectID"
        Dim dtSal As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcDateEndSalObjectID, dtSal.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcNextSalaryObjectID, dtSal.DefaultView.ToTable, gbUnicode)

    End Sub


    Dim dtNCode As DataTable
    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdNCodeID
        sSQL = "Select NCodeID, Description" & UnicodeJoin(gbUnicode) & " as Description , TypeID From D09T1010  WITH (NOLOCK) Where Disabled =0 Order by TypeID, NCodeID "
        dtNCode = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadtdbdNCodeID(ByVal sTypeID As String)
        'Load tdbdNCodeID
        LoadDataSource(tdbdNCodeID, ReturnTableFilter(dtNCode, "TypeID= " & SQLString(sTypeID), True), gbUnicode)
    End Sub


    Private Sub LoadTDBG1()
        Dim iMode As Byte
        If _FormState = EnumFormState.FormAdd Then
            iMode = 0
        ElseIf _FormState = EnumFormState.FormEdit Then
            iMode = 1
        End If

        Dim sSQL As String = SQLStoreD13P1140(_SalaryObjectID, iMode)
        LoadDataSource(tdbg1, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTab3Valid()
        Dim sSQL As String = "SELECT * FROM D13T1020  WITH (NOLOCK) WHERE SalaryObjectID = " & SQLString(_SalaryObjectID)
        Dim dtV As DataTable = ReturnDataTable(sSQL)

        If dtV.Rows.Count > 0 Then
            Dim dr1 As DataRow = dtV.Rows(0)
            iValidDateMode = L3Byte(dr1.Item("ValidDateMode"))
            Select Case iValidDateMode
                Case 1
                    optValidDate1.Checked = True
                Case 2
                    optValidDate2.Checked = True
                Case 3
                    optValidDate3.Checked = True
                Case 4
                    optValidDate4.Checked = True
                    chkIsCheckContract.Checked = L3Bool(dr1.Item("IsCheckContract"))
                    txtMonthContractNum.Text = dr1.Item("MonthContractNum").ToString
                Case 5
                    optValidDate5.Checked = True
                    tdbcDateEndSalObjectID.SelectedValue = dr1.Item("DateEndSalObjectID").ToString
            End Select
            EnableForOptValidDate4()
            txtMaintainedMonthNum.Text = dr1.Item("MaintainedMonthNum").ToString
            tdbcNextSalaryObjectID.SelectedValue = dr1.Item("NextSalaryObjectID").ToString

        End If

    End Sub



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1140
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 23/11/2011 03:55:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1140(ByVal sSalaryObjectID As String, ByVal iMode As Byte) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1140 "
        sSQL &= SQLString(sSalaryObjectID) & COMMA 'SalaryObjectID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, int, NOT NULL
        Return sSQL
    End Function

#Region "Sự kiện của tdbg1"

    Private Sub tdbg1_LockedColumns()
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_Descriptions).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg1_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg1.RowColChange
        '--- Đổ nguồn cho các Dropdown phụ thuộc
        Select Case tdbg1.Col
            Case COL1_NCodeID
                LoadtdbdNCodeID(tdbg1(tdbg1.Row, COL1_TypeID).ToString)
        End Select
    End Sub

    Private Sub tdbg1_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg1.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL1_NCodeID
                If tdbg1.Columns(COL1_NCodeID).Text <> tdbdNCodeID.Columns("NCodeID").Text Then
                    tdbg1.Columns(COL1_NCodeID).Text = ""
                    tdbg1.Columns(COL1_Descriptions).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg1_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.ComboSelect
        '--- Gán giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL1_NCodeID
                tdbg1.Columns(COL1_Descriptions).Text = tdbdNCodeID.Columns("Description").Text
        End Select
    End Sub

#End Region

    Private Sub D13F1141_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState <> EnumFormState.FormAdd Then
            txtSalaryObjectName.Focus()
        End If
    End Sub

#Region "Events tdbcNextSalaryObjectID"

    Private Sub tdbcNextSalaryObjectID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcNextSalaryObjectID.LostFocus
        If tdbcNextSalaryObjectID.FindStringExact(tdbcNextSalaryObjectID.Text) = -1 Then tdbcNextSalaryObjectID.Text = ""
    End Sub

#End Region

#Region "Events tdbcDateEndSalObjectID"

    Private Sub tdbcDateEndSalObjectID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDateEndSalObjectID.LostFocus
        If tdbcDateEndSalObjectID.FindStringExact(tdbcDateEndSalObjectID.Text) = -1 Then tdbcDateEndSalObjectID.Text = ""
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDateEndSalObjectID.Close, tdbcNextSalaryObjectID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDateEndSalObjectID.Validated, tdbcNextSalaryObjectID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Sub optValidDate1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optValidDate1.Click
        iValidDateMode = 1
        EnableForOptValidDate4()
    End Sub

    Private Sub optValidDate2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optValidDate2.Click
        iValidDateMode = 2
        EnableForOptValidDate4()
    End Sub

    Private Sub optValidDate3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optValidDate3.Click
        iValidDateMode = 3
        EnableForOptValidDate4()
    End Sub

    Private Sub optValidDate4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optValidDate4.Click
        iValidDateMode = 4
        EnableForOptValidDate4()
    End Sub

    Private Sub optValidDate5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optValidDate5.Click
        iValidDateMode = 5
        EnableForOptValidDate4()
    End Sub

    Private Sub txtMonthContractNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonthContractNum.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDotSign)
    End Sub

    Private Sub txtMaintainedMonthNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaintainedMonthNum.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDotSign)
    End Sub

    Private Sub chkIsCheckContract_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsCheckContract.Click
        If chkIsCheckContract.Checked Then
            txtMonthContractNum.Enabled = True
        Else
            txtMonthContractNum.Enabled = False
            txtMonthContractNum.Text = ""
        End If
    End Sub
End Class
