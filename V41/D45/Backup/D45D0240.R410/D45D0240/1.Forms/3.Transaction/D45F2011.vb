Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 3:39:07 PM
'# Created User: Nguyễn Thị Ánh
'# Modify Date: 08/05/2007 3:39:07 PM
'# Modify User: Nguyễn Thị Ánh
'#-------------------------------------------------------------------------------------
Public Class D45F2011
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim dtGrid, dtTeamID, dtBlockID, dtDepartment, dtPriceList As DataTable
    Dim bRun_tdbcVoucherTypeID As Boolean
    Dim bSelected As Boolean = False
    Dim bKeyPress As Boolean
    Public bSaveOK As Boolean = False
    Dim sEditVoucherTypeID As String = ""
    Dim conn As New SqlConnection(gsConnectionString)
    Dim trans As SqlTransaction = Nothing

#Region "Const of tdbg"
    Private Const COL_IsUse As Integer = 0            ' Chọn
    Private Const COL_ProductVoucherNo As Integer = 1 ' Số phiếu
    Private Const COL_VoucherDate As Integer = 2      ' Ngày phiếu
    Private Const COL_ProductVoucherID As Integer = 3 ' ProductVoucherID
    Private Const COL_PayrollVoucherID As Integer = 4 ' PayrollVoucherID
    Private Const COL_Note As Integer = 5             ' Diễn giải
#End Region

#Region "Const of tdbg2 - Total of Columns: 3"
    Private Const COL2_AbsentVoucherID As String = "AbsentVoucherID" ' AbsentVoucherID
    Private Const COL2_IsCheck As String = "IsCheck"                 ' Chọn
    Private Const COL2_Description As String = "Description"         ' Diễn giải
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public Property FormState() As EnumFormState
        Get
            Return _FormState
        End Get


        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            tdbcDepartmentID.Tag = ""
            tdbcTeamID.Tag = ""

            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnCalculateSalary.Enabled = False
                    btnNext.Enabled = False
                    bRun_tdbcVoucherTypeID = True
                    LoadTDBCombo()
                    LoadAddNew()
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSetNewKey.Enabled = False
                    btnSave.Left = btnNext.Left
                    bRun_tdbcVoucherTypeID = False
                    btnCalculateSalary.Enabled = True
                    LoadEdit()
                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSetNewKey.Enabled = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
                    bRun_tdbcVoucherTypeID = False
                    btnCalculateSalary.Enabled = False
                    LoadEdit()
            End Select
        End Set

    End Property

    Private _pSalaryVoucherID As String = ""
    Public Property PSalaryVoucherID() As String
        Get
            Return _pSalaryVoucherID
        End Get
        Set(ByVal Value As String)
            _pSalaryVoucherID = Value
        End Set
    End Property

    Private _bCalculated As Boolean
    Public WriteOnly Property bCalculated() As Boolean
        Set(ByVal Value As Boolean)
            _bCalculated = Value
        End Set
    End Property

    Private Sub SetBackColorObligatory()
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtPSalaryVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPieceworkCalMethodID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPriceListID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub D45F2011_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bKeyPress Then Exit Sub

        If _FormState = EnumFormState.FormEdit Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If btnSave.Enabled Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        End If

    End Sub

    Private Sub D45F2001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D45F2011_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        bKeyPress = True
    End Sub

    Private Sub D45F2001_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtPSalaryVoucherNo)
        tdbg_LockedColumns()
        tdbg2_LockedColumns()
        SetBackColorObligatory()
        tdbcNameAutoComplete()
        Panel1.Enabled = optPSalaryMode0.Checked
        InputDateCustomFormat(c1dateDateTo, c1dateDateFrom, c1dateVoucherDate)
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)
        LoadTDBGrid()
        LoadTDBGrid2()
        HotkeyAltTabControl(tabMain) 'Đánh phím tắt cho Tab 
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Thiet_lap_phieu_luong_san_pham_-_D45F2011") & UnicodeCaption(gbUnicode) 'ThiÕt lËp phiÕu l§¥ng s¶n phÈm - D45F2011
        'Me.Text = rL3("Thiet_lap_phieu_luong_san_pham") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'ThiÕt lËp phiÕu l§¥ng s¶n phÈm
        '================================================================ 
        lblteDateFrom.Text = rl3("Thoi_gian_tu") 'Thời gian từ
        lblPSalaryVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblPieceworkCalMethodID.Text = rl3("PP_tinh_luong") 'PP tính lương
        lblPriceListID.Text = rl3("Bang_gia") 'Bảng giá
        lblPSalaryMode.Text = rl3("Tinh_luong_Main") 'Tính lương
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnCalculateSalary.Text = rL3("Tin_h_luong") 'Tín&h lương
        '================================================================ 
        Tab1.Text = "1. " & rL3("Thong_ke_san_pham_tinh_luong") 'Thống kê sản phẩm tính lương
        Tab2.Text = "2. " & rL3("Dieu_chinh_thu_nhap") 'Điều chỉnh thu nhập
        '================================================================ 
        optPSalaryMode0.Text = rl3("Theo_nhan_vien_U") 'Theo nhân viên
        optPSalaryMode1.Text = rl3("Theo_phong_banto_nhom") 'Theo phòng ban/tổ nhóm
        optPSalaryMode2.Text = rl3("Theo_nhom_nhan_vien_cham_cong") 'Theo nhóm nhân viên chấm công
        optPSalaryMode3.Text = rl3("Theo_nhom_nhan_vien") 'Theo nhóm nhân viên
        '================================================================ 
        'IncidentID	52408
        lblIsGroupEmployee.Text = rl3("Nhom_du_lieu")
        optIsGroupEmployee1.Text = rl3("Khong_nhom_du_lieu")
        optIsGroupEmployee2.Text = rl3("Nhom_theo_SP_CD")
        optIsGroupEmployee3.Text = rl3("Nhom_theo_SP")

        chkIsGroupEmployee.Text = rl3("Nhom_NV_theo_SP_CD") 'Nhóm NV theo SP, CĐ
        '================================================================ 
        grpVoucher.Text = rl3("Chung_tu") 'Chứng từ
        '================================================================ 
        tdbcPriceListID.Columns("PriceListID").Caption = rl3("Ma") 'Mã
        tdbcPriceListID.Columns("PriceListName").Caption = rl3("Ten") 'Tên
        tdbcPieceworkCalMethodID.Columns("PieceworkCalMethodID").Caption = rl3("Ma") 'Mã
        tdbcPieceworkCalMethodID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbcTeamID.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Loai_phieu") 'Loại phiếu
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg.Columns("IsUse").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("ProductVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("Note").Caption = rL3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg2.Columns(COL2_IsCheck).Caption = rL3("Chon") 'Chọn
        tdbg2.Columns(COL2_Description).Caption = rL3("Dien_giai") 'Diễn giải
        '================================================================ 
        lblBlockID.Text = rL3("Khoi") 'Khối
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên

    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProductVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_VoucherDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Note).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg2_LockedColumns()
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadDefault()
        c1dateVoucherDate.Value = Now.Date
        c1dateDateFrom.Value = Now.Date
        c1dateDateTo.Value = Now.Date
        optPSalaryMode0.Checked = True
        chkIsGroupEmployee.Enabled = True
        Panel1.Enabled = True
    End Sub

    Private Sub LoadAddNew()
        LoadDefault()
        tdbcDepartmentID.SelectedValue = "%"
    End Sub

    Private Sub LoadEdit()
        btnSetNewKey.Enabled = False
        ReadOnlyControl(tdbcVoucherTypeID)
        ReadOnlyControl(txtPSalaryVoucherNo)

        If _bCalculated Then
            ReadOnlyControl(c1dateVoucherDate, c1dateDateFrom, c1dateDateTo)
            ReadOnlyControl(tdbcDepartmentID, tdbcTeamID, tdbcPieceworkCalMethodID, tdbcPriceListID, tdbcBlockID)
            chkIsGroupEmployee.Enabled = False
            Panel1.Enabled = False

            tdbg.Splits(SPLIT0).DisplayColumns(COL_IsUse).Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_IsUse).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End If

        Dim sSQL As String = SQLStoreD45P2010()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            sEditVoucherTypeID = dt.Rows(0).Item("VoucherTypeID").ToString
            LoadTDBCombo()
            '-----------------------------------------------------
            tdbcVoucherTypeID.SelectedValue = dt.Rows(0).Item("VoucherTypeID").ToString
            txtPSalaryVoucherNo.Text = dt.Rows(0).Item("PSalaryVoucherNo").ToString
            c1dateVoucherDate.Value = SQLDateShow(dt.Rows(0).Item("VoucherDate").ToString)
            txtDescription.Text = dt.Rows(0).Item("Description").ToString
            tdbcPieceworkCalMethodID.SelectedValue = dt.Rows(0).Item("PieceworkCalMethodID").ToString
            tdbcBlockID.SelectedValue = dt.Rows(0).Item("BlockID").ToString
            tdbcPriceListID.SelectedValue = dt.Rows(0).Item("PriceListID").ToString
            tdbcDepartmentID.SelectedValue = dt.Rows(0).Item("DepartmentID").ToString
            tdbcTeamID.SelectedValue = dt.Rows(0).Item("TeamID").ToString
            c1dateDateFrom.Value = SQLDateShow(dt.Rows(0).Item("DateFrom").ToString)
            c1dateDateTo.Value = SQLDateShow(dt.Rows(0).Item("DateTo").ToString)

            If dt.Rows(0).Item("IsGroupEmployee").ToString = "0" Then
                optIsGroupEmployee1.Checked = True
            ElseIf dt.Rows(0).Item("IsGroupEmployee").ToString = "1" Then
                optIsGroupEmployee2.Checked = True
            Else
                optIsGroupEmployee3.Checked = True
            End If
            chkIsGroupEmployee.Checked = L3Bool(dt.Rows(0).Item("IsGroupEmployee"))

            If dt.Rows(0).Item("PSalaryMode").ToString = "0" Then
                optPSalaryMode0.Checked = True
            ElseIf dt.Rows(0).Item("PSalaryMode").ToString = "1" Then
                optPSalaryMode1.Checked = True
            ElseIf dt.Rows(0).Item("PSalaryMode").ToString = "2" Then
                optPSalaryMode2.Checked = True
            Else
                optPSalaryMode3.Checked = True
            End If
        End If
    End Sub

    Private Sub LoadTDBGrid()
        Dim iMethod As Integer
        If optPSalaryMode0.Checked Then
            iMethod = 0
        ElseIf optPSalaryMode1.Checked Then
            iMethod = 1
        ElseIf optPSalaryMode2.Checked Then
            iMethod = 2
        Else
            iMethod = 3
        End If
        dtGrid = ReturnDataTable(SQLStoreD45P2009(iMethod))
        LoadDataSource(tdbg, dtGrid, gbUnicode)
    End Sub

    Dim dtGrid2 As DataTable
    Private Sub LoadTDBGrid2()
        If optPSalaryMode0.Checked OrElse optPSalaryMode1.Checked Then
            Dim sSQL As String = SQLStoreD45P2067()
            dtGrid2 = ReturnDataTable(sSQL)
            LoadDataSource(tdbg2, dtGrid2, gbUnicode)
        Else
            If dtGrid2 IsNot Nothing Then dtGrid2.Clear()
        End If
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, D45, sEditVoucherTypeID, gbUnicode)

        'Load tdbcPieceworkCalMethodID
        sSQL = "SELECT PieceworkCalMethodID, Description" & UnicodeJoin(gbUnicode) & " as Description" & vbCrLf
        sSQL &= "FROM D45T1060  WITH(NOLOCK) WHERE Disabled = 0 AND IsHACoefUP = 0" & vbCrLf
        sSQL &= "ORDER BY PieceworkCalMethodID "
        LoadDataSource(tdbcPieceworkCalMethodID, sSQL, gbUnicode)

        'Load tdbcBlockID
        dtBlockID = ReturnTableBlockID_D09P6868(gsDivisionID, "D45F2010", 0)
        LoadDataSource(tdbcBlockID, dtBlockID, gbUnicode)
        tdbcBlockID.Enabled = CheckEnableBlockID()


        'Load tdbcTeamID
        'dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        dtTeamID = ReturnTableTeamID_D09P6868(gsDivisionID, "D45F2010", 0)

        'Load tdbcDepartmentID
        'dtDepartment = ReturnTableDepartmentID(True, , gbUnicode)
        dtDepartment = ReturnTableDepartmentID_D09P6868(gsDivisionID, "D45F2010", 0)
        LoadDataSource(tdbcDepartmentID, dtDepartment, gbUnicode)

        'Load tdbcPriceListID
        'sSQL = "SELECT PriceListID, PriceListName" & UnicodeJoin(gbUnicode) & " as PriceListName" & vbCrLf
        'sSQL &= "FROM D45T1020  WITH(NOLOCK) " & vbCrLf
        'sSQL &= "WHERE Disabled = 0 And (ValidTo>=GetDate() Or ValidTo Is Null)" & vbCrLf
        'sSQL &= "ORDER BY PriceListID"

        'Load tdbcPriceListID
        dtPriceList = ReturnDataTable(SQLStoreD45P2008)
        LoadTDBCPriceList("")

        If tdbcBlockID.Enabled And dtBlockID.Rows.Count > 0 Then tdbcBlockID.SelectedIndex = 0
    End Sub

    Private Sub LoadTDBCPriceList(ByVal ID As String)
        If ID = "" Or ID = "%" Then
            LoadDataSource(tdbcPriceListID, dtPriceList, gbUnicode)
        Else
            LoadDataSource(tdbcPriceListID, ReturnTableFilter(dtPriceList, "BlockID='' or BlockID=" & SQLString(ID)), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbcTeamID(ByVal ID As String)
        If ID = "%" Then
            LoadDataSource(tdbcTeamID, dtTeamID, gbUnicode)
            ReadOnlyControl(tdbcTeamID)
        Else
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID ='%' Or DepartmentID  = " & SQLString(ID), True), gbUnicode)
            UnReadOnlyControl(tdbcTeamID)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Events tdbcVoucherTypeID"

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        If tdbcVoucherTypeID.SelectedValue Is Nothing Then
            txtPSalaryVoucherNo.Text = ""
            txtPSalaryVoucherNo.Text = ""
        Else
            If bRun_tdbcVoucherTypeID Then
                If Not (tdbcVoucherTypeID.Tag Is Nothing OrElse tdbcVoucherTypeID.Tag.ToString = "") Then
                    tdbcVoucherTypeID.Tag = ""
                    Exit Sub
                End If
                If tdbcVoucherTypeID.Columns("Auto").Text = "0" Then 'Không tạo mã tự động
                    txtPSalaryVoucherNo.ReadOnly = False
                    txtPSalaryVoucherNo.TabStop = True
                    btnSetNewKey.Enabled = False
                    txtPSalaryVoucherNo.Text = ""
                Else
                    gnNewLastKey = 0
                    txtPSalaryVoucherNo.ReadOnly = True
                    txtPSalaryVoucherNo.TabStop = False
                    btnSetNewKey.Enabled = True
                    If tdbcVoucherTypeID.Text <> "" Then txtPSalaryVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
                End If
            Else
                bRun_tdbcVoucherTypeID = True
            End If
        End If
    End Sub

#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If tdbcDepartmentID.SelectedValue Is Nothing Then
            LoadtdbcTeamID("")
        Else
            LoadtdbcTeamID(tdbcDepartmentID.SelectedValue.ToString())
        End If
        tdbcTeamID.SelectedValue = "%"
    End Sub

#End Region

#Region "53.	Sửa lỗi gõ tên trên combo hay dropdown"

    Private Sub tdbcNameAutoComplete()
        tdbcVoucherTypeID.AutoCompletion = False
        tdbcPieceworkCalMethodID.AutoCompletion = False
        tdbcPriceListID.AutoCompletion = False
        tdbcDepartmentID.AutoCompletion = False
        tdbcTeamID.AutoCompletion = False
    End Sub

    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.LostFocus, _
                tdbcPieceworkCalMethodID.LostFocus, tdbcPriceListID.LostFocus, tdbcDepartmentID.LostFocus, tdbcTeamID.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close, _
                tdbcPieceworkCalMethodID.Close, tdbcPriceListID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Validated, _
                tdbcPieceworkCalMethodID.Validated, tdbcPriceListID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Sub btnSetNewKey_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetNewKey.Click
        GetNewVoucherNo(tdbcVoucherTypeID, txtPSalaryVoucherNo)
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If
        If txtPSalaryVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("So_phieu"))
            txtPSalaryVoucherNo.Focus()
            Return False
        End If
        If c1dateVoucherDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_phieu"))
            c1dateVoucherDate.Focus()
            Return False
        End If
        If tdbcPieceworkCalMethodID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("PP_tinh_luong"))
            tdbcPieceworkCalMethodID.Focus()
            Return False
        End If

        Select Case L3String(tdbcBlockID.Tag)
            Case "W"
                If tdbcBlockID.Text.Trim = "" Then
                    If D99C0008.MsgAsk(rL3("Ban_chua_nhap_khoi_Ban_co_muon_tiep_tuc_luu_khong")) = Windows.Forms.DialogResult.No Then
                        tdbcBlockID.Focus()
                        Return False
                    Else
                        GoTo 1
                    End If
                End If
            Case "O"
                If tdbcBlockID.Text.Trim = "" Then
                    D99C0008.MsgNotYetEnter(lblBlockID.Text)
                    tdbcBlockID.Focus()
                    Return False
                End If
        End Select
1:
        If tdbcPriceListID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Bang_gia"))
            tdbcPriceListID.Focus()
            Return False
        End If

        If c1dateDateFrom.Value.ToString <> "" AndAlso c1dateDateTo.Value.ToString <> "" Then
            If CDate(c1dateDateFrom.Text) > CDate(c1dateDateTo.Text) Then
                D99C0008.MsgL3(rl3("Ngay_khong_hop_le"))
                c1dateDateTo.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg.UpdateData()
        tdbg2.UpdateData()
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)
        If Not CheckVoucherDateInPeriod(c1dateVoucherDate.Text) Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False
        btnCalculateSalary.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                If _pSalaryVoucherID = "" Then _pSalaryVoucherID = CreateIGE("D45T2010", "PSalaryVoucherID", "45", "PS", gsStringKey)
                sSQL.Append(SQLInsertD45T2010.ToString & vbCrLf)
                'Lưu LastKey của Số phiếu xuống Database (gọi hàm CreateIGEVoucherNo bật cờ True)
                If tdbcVoucherTypeID.Columns("Auto").Text <> "0" Then txtPSalaryVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, True)

                'Kiểm tra trùng Số phiếu (gọi hàm CheckDuplicateVoucherNo)
                'Nếu tra trùng Số phiếu thì bật
                'btnSave.Enabled = True
                'btnClose.Enabled = True
                If CheckDuplicateVoucherNo("D45", "D45T2010", _pSalaryVoucherID, txtPSalaryVoucherNo.Text) Then
                    Me.Cursor = Cursors.Default
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    If tdbcVoucherTypeID.Columns("Auto").Text = "0" Then 'Không tạo mã tự động
                        txtPSalaryVoucherNo.Focus()
                    Else
                        btnSetNewKey.Focus()
                    End If
                    Exit Sub
                End If

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T2010.ToString & vbCrLf)
        End Select
        sSQL.Append(SQLDeleteD45T2011.ToString & vbCrLf)
        sSQL.Append(SQLInsertD45T2011s.ToString & vbCrLf)
        sSQL.Append(SQLDeleteD45T2066.ToString & vbCrLf)
        If tdbg2.RowCount > 0 Then sSQL.Append(SQLInsertD45T2066s.ToString & vbCrLf)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            bSaveOK = True
            btnClose.Enabled = True
            btnCalculateSalary.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'RunAuditLog(AuditCodePSalaryCalculation, "02", c1dateVoucherDate.Text, txtPSalaryVoucherNo.Text, "", tdbcPieceworkCalMethodID.SelectedValue.ToString)
                    Lemon3.D91.RunAuditLog("45", AuditCodePSalaryCalculation, "02", c1dateVoucherDate.Text, txtPSalaryVoucherNo.Text, "", tdbcPieceworkCalMethodID.SelectedValue.ToString)
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        _pSalaryVoucherID = ""
        btnNext.Enabled = False
        btnSave.Enabled = True
        btnCalculateSalary.Enabled = False
        bRun_tdbcVoucherTypeID = True

        If D45Options.SaveLastRecent = False Then
            LoadDefault()

            tdbcVoucherTypeID.Text = ""
            txtPSalaryVoucherNo.Text = ""
            txtDescription.Text = ""
            tdbcPieceworkCalMethodID.SelectedValue = ""
            tdbcPriceListID.SelectedValue = ""
            tdbcDepartmentID.SelectedValue = "%"
            tdbcTeamID.SelectedValue = "%"
            chkIsGroupEmployee.Checked = False
            optIsGroupEmployee1.Checked = True

            tdbcVoucherTypeID.Focus()
        Else
            tdbcVoucherTypeID_SelectedValueChanged(sender, Nothing)
            If tdbcVoucherTypeID.Columns("Auto").Text = "0" Then 'Không tạo mã tự động
                txtPSalaryVoucherNo.Focus()
            Else
                c1dateVoucherDate.Focus()
            End If
        End If

        LoadTDBGrid()
        LoadTDBGrid2()
    End Sub

    Private Sub optPSalaryMode0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optPSalaryMode0.Click, optPSalaryMode1.Click, optPSalaryMode2.Click, optPSalaryMode3.Click
        chkIsGroupEmployee.Enabled = optPSalaryMode0.Checked
        Panel1.Enabled = optPSalaryMode0.Checked
        LoadTDBGrid()
        LoadTDBGrid2()
    End Sub

    Private Function SQLStoreD45P2010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2010 "
        sSQL &= SQLString(_PSalaryVoucherID) & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    Private Function SQLInsertD45T2010() As StringBuilder
        Dim sSQL As New StringBuilder("")

        sSQL.Append("Insert Into D45T2010(")
        sSQL.Append("DivisionID, PSalaryVoucherID, TranMonth, TranYear, VoucherTypeID, PSalaryVoucherNo, VoucherDate, ")
        sSQL.Append("Description, DescriptionU, PieceworkCalMethodID, PriceListID, DateFrom, DateTo, DepartmentID, TeamID, ")
        sSQL.Append("CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, IsGroupEmployee, PSalaryMode,BlockID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NULL
        sSQL.Append(SQLString(_PSalaryVoucherID) & COMMA) 'PSalaryVoucherID, varchar[20], NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NULL
        sSQL.Append(SQLString(tdbcVoucherTypeID.SelectedValue) & COMMA) 'VoucherTypeID, varchar[20], NULL
        sSQL.Append(SQLString(txtPSalaryVoucherNo.Text) & COMMA) 'PSalaryVoucherNo, varchar[20], NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'VoucherDate, datetime, NULL

        sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA) 'Description, varchar[150], NULL
        sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA) 'Description, varchar[150], NULL

        sSQL.Append(SQLString(tdbcPieceworkCalMethodID.SelectedValue) & COMMA) 'PieceworkCalMethodID, varchar[20], NULL
        sSQL.Append(SQLString(tdbcPriceListID.SelectedValue) & COMMA) 'PriceListID, varchar[20], NULL
        sSQL.Append(SQLDateSave(c1dateDateFrom.Text) & COMMA) 'DateFrom, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateDateTo.Text) & COMMA) 'DateTo, datetime, NULL
        sSQL.Append(SQLString(tdbcDepartmentID.SelectedValue) & COMMA) 'DepartmentID, varchar[20], NULL
        sSQL.Append(SQLString(tdbcTeamID.SelectedValue) & COMMA) 'TeamID, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL


        If optIsGroupEmployee1.Checked Then
            sSQL.Append(SQLNumber("0") & COMMA) 'Method, tinyint, NOT NULL
        ElseIf optIsGroupEmployee2.Checked Then
            sSQL.Append(SQLNumber("1") & COMMA) 'Method, tinyint, NOT NULL
        Else
            sSQL.Append(SQLNumber("2") & COMMA) 'Method, tinyint, NOT NULL
        End If
        ' sSQL.Append(SQLNumber(chkIsGroupEmployee.Checked) & COMMA) 'Method, tinyint, NOT NULL


        If optPSalaryMode0.Checked Then
            sSQL.Append(SQLNumber(0)) 'PSalaryMode, tinyint, NOT NULL
        ElseIf optPSalaryMode1.Checked Then
            sSQL.Append(SQLNumber(1)) 'PSalaryMode, tinyint, NOT NULL
        ElseIf optPSalaryMode2.Checked Then
            sSQL.Append(SQLNumber(2)) 'PSalaryMode, tinyint, NOT NULL
        Else
            sSQL.Append(SQLNumber(3)) 'PSalaryMode, tinyint, NOT NULL
        End If
        sSQL.Append(COMMA & SQLString(ReturnValueC1Combo(tdbcBlockID))) 'BlockID, varchar[20], NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    Private Function SQLUpdateD45T2010() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T2010 Set ")
        sSQL.Append("VoucherDate = " & SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("Description = " & SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA) 'varchar[150], NULL
        sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA) 'varchar[150], NULL
        sSQL.Append("PieceworkCalMethodID = " & SQLString(tdbcPieceworkCalMethodID.SelectedValue) & COMMA) 'varchar[20], NULL
        sSQL.Append("PriceListID = " & SQLString(tdbcPriceListID.SelectedValue) & COMMA) 'varchar[20], NULL
        sSQL.Append("DateFrom = " & SQLDateSave(c1dateDateFrom.Text) & COMMA) 'datetime, NULL
        sSQL.Append("DateTo = " & SQLDateSave(c1dateDateTo.Text) & COMMA) 'datetime, NULL
        sSQL.Append("DepartmentID = " & SQLString(tdbcDepartmentID.SelectedValue) & COMMA) 'varchar[20], NULL
        sSQL.Append("TeamID = " & SQLString(tdbcTeamID.SelectedValue) & COMMA) 'varchar[20], NULL	


        If optIsGroupEmployee1.Checked Then
            sSQL.Append("IsGroupEmployee = " & SQLNumber("0") & COMMA) 'varchar[20], NULL
        ElseIf optIsGroupEmployee2.Checked Then
            sSQL.Append("IsGroupEmployee = " & SQLNumber("1") & COMMA) 'varchar[20], NULL
        Else
            sSQL.Append("IsGroupEmployee = " & SQLNumber("2") & COMMA) 'varchar[20], NULL
        End If
        'sSQL.Append("IsGroupEmployee = " & SQLNumber(chkIsGroupEmployee.Checked) & COMMA) 'varchar[20], NULL

        If optPSalaryMode0.Checked Then
            sSQL.Append("PSalaryMode = " & SQLNumber(0) & COMMA) 'varchar[20], NULL
        ElseIf optPSalaryMode1.Checked Then
            sSQL.Append("PSalaryMode = " & SQLNumber(1) & COMMA) 'varchar[20], NULL
        ElseIf optPSalaryMode2.Checked Then
            sSQL.Append("PSalaryMode = " & SQLNumber(2) & COMMA) 'varchar[20], NULL
        Else
            sSQL.Append("PSalaryMode = " & SQLNumber(3) & COMMA) 'varchar[20], NULL
        End If
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("BlockID  =" & SQLString(ReturnValueC1Combo(tdbcBlockID))) 'datetime, NULL
        sSQL.Append(" Where PSalaryVoucherID=" & SQLString(_PSalaryVoucherID))
        Return sSQL
    End Function

    Private Function SQLDeleteD45T2011() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2011"
        sSQL &= " Where PSalaryVoucherID=" & SQLString(_PSalaryVoucherID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P0066
    '# Created User: KIMLONG
    '# Created Date: 12/10/2016 02:38:14
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD91P0066() As String
        Dim sSQL As String = ""
        sSQL &= ("-- -- Kiem tra bat buoc nhap combo Khoi: BlockID" & vbCrLf)
        sSQL &= "Exec D91P0066 "
        sSQL &= SQLString("45") & COMMA 'ModuleID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("D45F2010") 'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2009
    '# Created User: KIMLONG
    '# Created Date: 12/10/2016 02:48:28
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2009(ByVal iMethod As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- --- Do nguon phieu cham cong san pham" & vbCrLf)
        sSQL &= "Exec D45P2009 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D45F2010") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(IIf(_FormState = EnumFormState.FormAdd, "", _pSalaryVoucherID)) & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMethod) 'Method, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Function SQLInsertD45T2011s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUse)) Then
                sSQL.Append("Insert Into D45T2011(")
                sSQL.Append("PSalaryVoucherID, ProductVoucherID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(_pSalaryVoucherID) & COMMA) 'PSalaryVoucherID, varchar[20], NULL
                sSQL.Append(SQLString(tdbg(i, COL_ProductVoucherID))) 'ProductVoucherID, varchar[20], NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    Private Sub btnCalculateSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculateSalary.Click
        Dim sSQL As String = ""
        Dim Dt As DataTable

        If AllowCalSalary() = False Then Exit Sub

        'Ktra xem phieu da duoc tinh luong chua?
        sSQL = "Select Calculated From D45T2010 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where PSalaryVoucherID = " & SQLString(_PSalaryVoucherID)
        Dt = ReturnDataTable(sSQL)
        If Dt.Rows.Count > 0 Then
            'mo ket noi
            conn.Close()
            conn.Open()
            trans = conn.BeginTransaction

            If Dt.Rows(0).Item("Calculated").ToString = "1" Then
                If D99C0008.MsgAsk(rl3("Phieu_nay_da_duoc_tinh_luong_Ban_co_muon_tinh_lai_khong")) = Windows.Forms.DialogResult.Yes Then
                    sSQL = SQLStoreD45P2550() & vbCrLf
                    sSQL &= SQLStoreD45P2500()
                Else
                    'Goi D45F2012 de xem ket qua tinh luong
                    Dim f As New D45F2012
                    With f
                        .PSalaryVoucherID = _pSalaryVoucherID
                        .BlockID = ReturnValueC1Combo(tdbcBlockID)
                        .PieceworkCalMethodID = tdbcPieceworkCalMethodID.SelectedValue.ToString
                        .PSalaryMode = IIf(optPSalaryMode0.Checked, "0", "").ToString    '28/11/2012  sửa cột mã nhân viên , họ và tên chỉ hiện khi loại phiếu tính lương theo nhân viên
                        .ShowDialog()
                        .Dispose()
                    End With
                    Exit Sub
                End If
            Else
                sSQL = SQLStoreD45P2500()
            End If

            Dt = ReturnDataTable1(sSQL)
            'Thuc thi bi loi
            If Dt Is Nothing Then
                trans.Rollback()
                'dong ket noi
                conn.Close()
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            If Dt.Rows.Count > 0 Then
                If Dt.Rows(0).Item("Status").ToString = "1" Then
                    Dim bFontMessage As Boolean = False
                    If Dt.Columns.Contains("FontMessage") Then bFontMessage = True

                    If Not bFontMessage Then
                        D99C0008.MsgL3(ConvertVietwareFToUnicode(Dt.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Exclamation)
                    Else
                        Select Case Dt.Rows(0).Item("FontMessage").ToString
                            Case "0" 'VietwareF
                                D99C0008.MsgL3(ConvertVietwareFToUnicode(Dt.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Exclamation)
                            Case "1" 'Unicode
                                D99C0008.MsgL3(Dt.Rows(0).Item("Message").ToString, L3MessageBoxIcon.Exclamation)
                            Case "2" 'Convert Vni To Unicode
                                D99C0008.MsgL3(ConvertVniToUnicode(Dt.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Exclamation)
                        End Select
                    End If

                    trans.Rollback()
                    'dong ket noi
                    conn.Close()
                Else
                    trans.Commit()
                    'dong ket noi
                    conn.Close()

                    'Goi D45F2012 de xem ket qua tinh luong
                    Dim f As New D45F2012
                    With f
                        .PSalaryVoucherID = _pSalaryVoucherID
                        .BlockID = ReturnValueC1Combo(tdbcBlockID)
                        .PieceworkCalMethodID = tdbcPieceworkCalMethodID.SelectedValue.ToString
                        .PSalaryMode = IIf(optPSalaryMode0.Checked, "0", "").ToString    '28/11/2012  sửa cột mã nhân viên , họ và tên chỉ hiện khi loại phiếu tính lương theo nhân viên
                        .ShowDialog()
                        .Dispose()
                    End With
                End If
            Else
                trans.Rollback()
                'dong ket noi
                conn.Close()
            End If

            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Function SQLStoreD45P2550() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2550 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_PSalaryVoucherID) 'PSalaryVoucherID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Function SQLStoreD45P2500() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2500 "
        sSQL &= SQLString(_PSalaryVoucherID) & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Languge, varchar[10], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Function ReturnDataSet1(ByVal SQL As String) As DataSet
        Dim ds As DataSet = New DataSet()
        If giAppMode = 0 Then
            Dim cmd As SqlCommand = New SqlCommand(SQL, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Try
                cmd.CommandTimeout = 0
                cmd.Transaction = trans
                'Rem lai ngay 03/11/2009 vi neu dung lenh nay thi store se thuc thi 2 lan
                'cmd.ExecuteNonQuery()
                da.Fill(ds)
                Return ds
            Catch
                Clipboard.Clear()
                Clipboard.SetText(SQL)
                MsgErr("Error when excute SQL in function ReturnDataSet(). Paste your SQL code from Clipboard")
                Return Nothing
            End Try
        Else
            Try
                'Dùng D99D0041 mới
                ds = CallWebService.ReturnDataSet(SQL, gsCompanyID, gsWSSPara01, gsWSSPara02, gsWSSPara03, gsWSSPara04, gsWSSPara05)
                Return ds
            Catch
                Clipboard.Clear()
                Clipboard.SetText(SQL)
                MsgErr("Error when excute SQL in function ReturnDataSet(). Paste your SQL code from Clipboard")
                Return Nothing

            End Try
        End If
    End Function

    Private Function ReturnDataTable1(ByVal SQL As String) As DataTable
        Dim ds As DataSet = ReturnDataSet1(SQL)
        If ds Is Nothing Then Return Nothing
        Return ds.Tables(0)
    End Function

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_IsUse
                PressHeadClick()
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            Select Case tdbg.Col
                Case COL_IsUse
                    PressHeadClick()
            End Select
        ElseIf e.KeyCode = Keys.Enter Then
            If tdbg.Col = COL_Note Then HotKeyEnterGrid(tdbg, COL_IsUse, e)
        End If
    End Sub

    Private Sub PressHeadClick()
        Dim bChoose As Boolean = Not bSelected
        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, COL_IsUse) = bChoose
        Next i
        bSelected = bChoose
    End Sub

#Region "tdbg2"
    Private Sub tdbg2_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.HeadClick
        HeadClick2(e.ColIndex)
    End Sub

    Private Sub tdbg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg2.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            Select Case tdbg.Col
                Case COL_IsUse
                    HeadClick2(tdbg2.Col)
            End Select
        ElseIf e.KeyCode = Keys.Enter Then
            If tdbg2.Col = IndexOfColumn(tdbg2, COL2_Description) Then HotKeyEnterGrid(tdbg2, IndexOfColumn(tdbg2, COL2_IsCheck), e)
        End If
    End Sub

    Dim bSelect2 As Boolean = False
    Private Sub HeadClick2(iCol As Integer)
        Select Case tdbg2.Columns(iCol).DataField
            Case COL2_IsCheck
                L3HeadClick(tdbg2, COL2_IsCheck, bSelect2)
        End Select
    End Sub
#End Region
    Private Function SQLStoreD45P5555(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D45F2010") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_PSalaryVoucherID) & COMMA 'KeyID1, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'KeyID2, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'KeyID3, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'KeyID4, varchar[20], NOT NULL
        sSQL &= SQLString("") 'KeyID5, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2008
    '# Created User: KIMLONG
    '# Created Date: 12/10/2016 02:34:28
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2008() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon combo Bang gia" & vbCrlf)
        sSQL &= "Exec D45P2008 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D45F2010") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function



    Private Function AllowCalSalary() As Boolean
        Dim sSQL As String = ""
        sSQL = SQLStoreD45P5555(2)
        AllowCalSalary = CheckStore(sSQL)
    End Function

    Private Function CheckEnableBlockID() As Boolean
        Dim dtCheckO As DataTable = ReturnDataTable(SQLStoreD91P0066())
        If dtCheckO.Rows.Count > 0 Then
            Dim dr() As DataRow = dtCheckO.Select("SqlFieldName='BlockID'")
            If dr.Length > 0 Then
                Select Case L3String(dr(0)("ValidMode"))
                    Case "O"
                        tdbcBlockID.Tag = L3String(dr(0)("ValidMode"))
                        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
                    Case "W"
                        tdbcBlockID.Tag = L3String(dr(0)("ValidMode"))
                End Select
            End If
        End If

        Dim sSQL As String = "Select IsUseBlock From D09T0000 "
        Dim dtCheckE As DataTable = ReturnDataTable(sSQL)
        If dtCheckE.Rows.Count > 0 Then
            Return L3Bool(dtCheckE.Rows(0)("IsUseBlock").ToString)
        End If

        Return False
    End Function

#Region "Events tdbcBlockID load tdbcDepartmentID"

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartment, ReturnValueC1Combo(tdbcBlockID).ToString, gbUnicode)
        LoadTDBCPriceList(ReturnValueC1Combo(tdbcBlockID))
        If dtGrid IsNot Nothing Then
            dtGrid.DefaultView.RowFilter = "BlockID ='' or BlockID =" & SQLString(ReturnValueC1Combo(tdbcBlockID))
            For i As Integer = 0 To dtGrid.Rows.Count - 1
                dtGrid.Rows(i)("IsUse") = ReturnValueC1Combo(tdbcBlockID) <> ""
            Next
        End If

        tdbcDepartmentID.SelectedValue = "%"
    End Sub

    Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
            tdbcDepartmentID.SelectedValue = "%"
            tdbcTeamID.SelectedValue = "%"
            tdbcPriceListID.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2067
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 26/10/2016 02:21:35
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2067() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon phieu dieu chinh thu nhap" & vbCrlf)
        sSQL &= "Exec D45P2067 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D45F2010") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, varchar[50], NOT NULL
        sSQL &= SQLString(_pSalaryVoucherID) & COMMA 'PsalaryVoucherID, varchar[50], NOT NULL
        sSQL &= SQLNumber(IIf(_FormState = EnumFormState.FormAdd, 0, 1)) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[50], NOT NULL
        sSQL &= SQLNumber(IIf(optPSalaryMode0.Checked, 0, 1)) 'OptionID, int, NOT NULL
        Return sSQL
    End Function

    Private Function SQLDeleteD45T2066() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2066 "
        sSQL &= " Where PSalaryVoucherID=" & SQLString(_pSalaryVoucherID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2066s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 26/10/2016 02:43:48
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2066s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim dtSourceGrid As DataTable = CType(tdbg2.DataSource, DataTable)
        Dim dr() As DataRow = dtSourceGrid.Select(COL2_IsCheck & "=1")
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu khoan dieu chinh thu nhap" & vbCrlf)
            sSQL.Append("Insert Into D45T2066(")
            sSQL.Append("AbsentVoucherID, PSalaryVoucherID")
            sSQL.Append(") Values(" & vbCrlf)
            sSQL.Append(SQLString(dr(i).Item(COL2_AbsentVoucherID)) & COMMA) 'AbsentVoucherID, varchar[50], NOT NULL
            sSQL.Append(SQLString(_pSalaryVoucherID)) 'PSalaryVoucherID, varchar[50], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


End Class