Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 3:39:07 PM
'# Created User: Nguyễn Thị Ánh
'# Modify Date: 08/05/2007 3:39:07 PM
'# Modify User: Nguyễn Thị Ánh
'#-------------------------------------------------------------------------------------
Public Class D45F2014
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim bKeyPress As Boolean
    Dim sEditVoucherTypeID As String = ""
    Dim dtCode As DataTable

#Region "Const of tdbg"
    Private Const COL_IsUse As Integer = 0            ' Chọn
    Private Const COL_ProductVoucherNo As Integer = 1 ' Số phiếu
    Private Const COL_VoucherDate As Integer = 2      ' Ngày phiếu
    Private Const COL_ProductVoucherID As Integer = 3 ' ProductVoucherID
    Private Const COL_PayrollVoucherID As Integer = 4 ' PayrollVoucherID
    Private Const COL_Note As Integer = 5             ' Diễn giải
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

            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnCalculateSalary.Enabled = False
                    LoadTDBCombo()
                Case EnumFormState.FormEdit
                    btnSetNewKey.Enabled = False
                    btnCalculateSalary.Enabled = True
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSetNewKey.Enabled = False
                    btnSave.Enabled = False
                    btnCalculateSalary.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _attCoefUPID As String
    Public Property AttCoefUPID() As String
        Get
            Return _attCoefUPID
        End Get
        Set(ByVal Value As String)
            _attCoefUPID = Value
        End Set
    End Property

    Private _pSalaryVoucherID As String
    Public Property pSalaryVoucherID() As String
        Get
            Return _pSalaryVoucherID
        End Get
        Set(ByVal Value As String)
            _pSalaryVoucherID = Value
        End Set
    End Property

    Private _voucherNo As String
    Public WriteOnly Property VoucherNo() As String
        Set(ByVal Value As String)
            _voucherNo = Value
        End Set
    End Property

    Private _description As String
    Public WriteOnly Property Description() As String
        Set(ByVal Value As String)
            _description = Value
        End Set
    End Property

    Private _attDateFrom As String
    Public WriteOnly Property AttDateFrom() As String
        Set(ByVal Value As String)
            _attDateFrom = Value
        End Set
    End Property

    Private _attDateTo As String
    Public WriteOnly Property AttDateTo() As String
        Set(ByVal Value As String)
            _attDateTo = Value
        End Set
    End Property

    Private Sub SetBackColorObligatory()
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtPSalaryVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDate.BackColor = COLOR_BACKCOLOROBLIGATORY
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
        If e.Alt = True Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    tabInfo.SelectedIndex = 0
                    tdbcVoucherTypeID.Focus()
                Case Keys.D2, Keys.NumPad2
                    tabInfo.SelectedIndex = 1
                    optBalanceMode0.Focus()
            End Select
        End If
    End Sub

    Private Sub D45F2011_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        bKeyPress = True
    End Sub

    Private Sub D45F2014_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        Loadlanguage()
        SetBackColorObligatory()
        LoadDefault()
        '*****************************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtPSalaryVoucherNo)
        '*****************************
        InputDateCustomFormat(c1dateAttDateTo, c1dateAttDateFrom, c1dateVoucherDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Thiet_lap_phieu_luong_san_pham_theo_don_gia_gio_cong_he_so_-_D45F2014") & UnicodeCaption(gbUnicode) 'ThiÕt lËp phiÕu l§¥ng s¶n phÈm theo ¢¥n giÀ gié c¤ng hÖ sç - D45F2014
        '================================================================ 
        lblPiecework.Text = rl3("Phuong_phap_tinh_luong") 'Phương pháp tính lương
        lblPieceworkCalMethodID.Text = rl3("Phuong_phap") 'Phương pháp
        lblUnitPrice.Text = rl3("Don_gia_gio_cong_he_so") 'Đơn giá giờ công hệ số
        lblAttDateFrom.Text = rl3("Ngay_cong") 'Ngày công
        lblPSalaryVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblDescription1.Text = rl3("Dien_giai") 'Diễn giải
        lblSumPWPayrollID.Text = rl3("Quy_luong") 'Quỹ lương
        lblCode.Text = rl3("Khoan_thu_nhap") 'Khoản thu nhập
        lblRound.Text = rl3("Hinh_thuc_lam_tron") 'Hình thức làm tròn
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnCalculateSalary.Text = rl3("Tin_h_luong") 'Tín&h lương
        '================================================================ 
        Tab1.Text = "1. " & rl3("Thong_tin_chinh")
        Tab2.Text = "2. " & rl3("Xu_ly_so_du")
        '================================================================ 
        grpVoucher.Text = rl3("Chung_tu") 'Chứng từ
        '================================================================ 
        optBalanceMode0.Text = rl3("Khong_lam_tron_so_du")
        optBalanceMode1.Text = rL3("Cong_so_du_cho_nguoi_co_muc_luong_cao_nhat")
        optBalanceMode2.Text = rL3("Cong_so_du_cho_nguoi_co_muc_luong_thap_nhat")
        '================================================================ 
        tdbcPieceworkCalMethodID.Columns("PieceworkCalMethodID").Caption = rl3("Ma") 'Mã
        tdbcPieceworkCalMethodID.Columns("PieceworkDescription").Caption = rl3("Ten") 'Tên
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Loai_phieu") 'Loại phiếu
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcSumPWPayrollID.Columns("SumPWPayrollID").Caption = rl3("Ma") 'Mã
        tdbcSumPWPayrollID.Columns("SumPWPayrollName").Caption = rl3("Ten") 'Tên
        tdbcCode.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcCode.Columns("Name").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub LoadDefault()
        If _FormState = EnumFormState.FormAdd Then
            c1dateVoucherDate.Value = Now.Date
            tdbcPieceworkCalMethodID.SelectedIndex = 0
            tdbcSumPWPayrollID.SelectedIndex = 0
            tdbcCode.SelectedIndex = 0
        End If
        '****************************
        txtVoucherNo.Text = _voucherNo
        txtDescription1.Text = _description
        c1dateAttDateFrom.Value = SQLDateShow(_attDateFrom)
        c1dateAttDateTo.Value = SQLDateShow(_attDateTo)
        '****************************
        ReadOnlyControl(txtDescription1, txtVoucherNo, c1dateAttDateFrom, c1dateAttDateTo)
    End Sub

    Private Sub LoadEdit()
        btnSetNewKey.Enabled = False
        ReadOnlyControl(tdbcVoucherTypeID)
        ReadOnlyControl(txtPSalaryVoucherNo)
        '************************************
        Dim sSQL As String = SQLStoreD45P2014()
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
            tdbcSumPWPayrollID.SelectedValue = dt.Rows(0).Item("SumPWPayrollID").ToString
            tdbcCode.SelectedValue = dt.Rows(0).Item("PWCode").ToString
            If dt.Rows(0).Item("BalanceMode").ToString = "0" Then
                optBalanceMode0.Checked = True
            ElseIf dt.Rows(0).Item("BalanceMode").ToString = "1" Then
                optBalanceMode1.Checked = True
            Else
                optBalanceMode2.Checked = True
            End If
        End If
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcCode
        sSQL = "Select PWCalNo AS Code, ShortName" & UnicodeJoin(gbUnicode) & " As Name, PieceworkCalMethodID" & vbCrLf
        sSQL &= "From D45T1061  WITH(NOLOCK) Where Disabled=0 Order by Code"
        dtCode = ReturnDataTable(sSQL)

        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, D45, sEditVoucherTypeID, gbUnicode)

        'Load tdbcCode
        sSQL = "Select PieceworkCalMethodID, Description" & UnicodeJoin(gbUnicode) & " As PieceworkDescription" & vbCrLf
        sSQL &= "From D45T1060  WITH(NOLOCK) Where Disabled=0 And IsHACoefUP=1 Order by PieceworkCalMethodID"
        LoadDataSource(tdbcPieceworkCalMethodID, sSQL, gbUnicode)

        'Load tdbcSumPWPayrollID
        sSQL = "Select ID as SumPWPayrollID, Name As SumPWPayrollName" & vbCrLf
        sSQL &= "From " & SQLUDFD45N5555() & " Order by SumPWPayrollID"
        LoadDataSource(tdbcSumPWPayrollID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBComboCode(ByVal sPieceworkCalMethodID As String)
        LoadDataSource(tdbcCode, ReturnTableFilter(dtCode, "PieceworkCalMethodID=" & SQLString(sPieceworkCalMethodID), True), gbUnicode)
    End Sub

#Region "Events tdbcVoucherTypeID"

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        If _FormState <> EnumFormState.FormAdd Then Exit Sub

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
    End Sub

    Private Sub tdbcVoucherTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.LostFocus
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtPSalaryVoucherNo.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcPieceworkCalMethodID"

    Private Sub tdbcPieceworkCalMethodID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPieceworkCalMethodID.LostFocus
        If tdbcPieceworkCalMethodID.FindStringExact(tdbcPieceworkCalMethodID.Text) = -1 Then tdbcPieceworkCalMethodID.Text = ""
    End Sub

    Private Sub tdbcPieceworkCalMethodID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPieceworkCalMethodID.SelectedValueChanged
        LoadTDBComboCode(CbVal(tdbcPieceworkCalMethodID))
        tdbcCode.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcSumPWPayrollID"

    Private Sub tdbcSumPWPayrollID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSumPWPayrollID.LostFocus
        If tdbcSumPWPayrollID.FindStringExact(tdbcSumPWPayrollID.Text) = -1 Then tdbcSumPWPayrollID.Text = ""
    End Sub

#End Region

#Region "Events tdbcCode"

    Private Sub tdbcCode_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCode.LostFocus
        If tdbcCode.FindStringExact(tdbcCode.Text) = -1 Then tdbcCode.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close, tdbcPieceworkCalMethodID.Close, tdbcSumPWPayrollID.Close, tdbcCode.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Validated, tdbcPieceworkCalMethodID.Validated, tdbcSumPWPayrollID.Validated, tdbcCode.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

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
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
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
                sSQL.Append(SQLInsertD45T2010.ToString & vbCrLf)

                'Lưu LastKey của Số phiếu xuống Database (gọi hàm CreateIGEVoucherNo bật cờ True)
                If tdbcVoucherTypeID.Columns("Auto").Text <> "0" Then txtPSalaryVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, True)

                'Kiểm tra trùng Số phiếu (gọi hàm CheckDuplicateVoucherNo)
                'Nếu tra trùng Số phiếu thì bật
                'btnSave.Enabled = True
                'btnClose.Enabled = True
                If CheckDuplicateVoucherNo("D45", "D45T2010", _PSalaryVoucherID, txtPSalaryVoucherNo.Text) Then
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

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            btnCalculateSalary.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd

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

    Private Sub btnCalculateSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculateSalary.Click
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As String = SQLStoreD45P2016()
        If CheckStore(sSQL) Then
            Dim f As New D45F2015
            With f
                .PSalaryVoucherID = _pSalaryVoucherID
                .pieceworkCalMethodID = CbVal(tdbcPieceworkCalMethodID)
                .ShowDialog()
                .Dispose()
            End With
        End If
        Me.Cursor = Cursors.Default
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2014
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/10/2011 11:27:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2014() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2014 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(_pSalaryVoucherID) & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2016
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/10/2011 11:43:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2016() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2016 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2010") & COMMA 'FormID, varchar[10], NOT NULL
        sSQL &= SQLString(_pSalaryVoucherID) & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2010
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/10/2011 11:29:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2010() As StringBuilder
        Dim sSQL As New StringBuilder

        _pSalaryVoucherID = CreateIGE("D45T2010", "PSalaryVoucherID", "45", "PS", gsStringKey)

        sSQL.Append("Insert Into D45T2010(")
        sSQL.Append("DivisionID, PSalaryVoucherID, TranMonth, TranYear, VoucherTypeID, ")
        sSQL.Append("PSalaryVoucherNo, VoucherDate, Description, DateFrom, DateTo, Calculated, ")
        sSQL.Append("CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, BalanceMode, ")
        sSQL.Append("DescriptionU, IsAttCoefUP, AttCoefUPID, PWCode, SumPWPayrollID, PieceworkCalMethodID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NULL
        sSQL.Append(SQLString(_pSalaryVoucherID) & COMMA) 'PSalaryVoucherID, varchar[20], NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NULL
        sSQL.Append(SQLString(CbVal(tdbcVoucherTypeID)) & COMMA) 'VoucherTypeID, varchar[20], NULL
        sSQL.Append(SQLString(txtPSalaryVoucherNo.Text) & COMMA) 'PSalaryVoucherNo, varchar[20], NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Value) & COMMA) 'VoucherDate, datetime, NULL
        sSQL.Append(SQLStringUnicode(txtDescription, False) & COMMA) 'Description, varchar[150], NULL
        sSQL.Append(SQLDateSave(c1dateAttDateFrom.Value) & COMMA) 'DateFrom, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateAttDateTo.Value) & COMMA) 'DateTo, datetime, NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'Calculated, tinyint, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        If optBalanceMode0.Checked Then
            sSQL.Append(SQLNumber(0) & COMMA) 'BalanceMode, tinyint, NOT NULL
        ElseIf optBalanceMode1.Checked Then
            sSQL.Append(SQLNumber(1) & COMMA) 'BalanceMode, tinyint, NOT NULL
        Else
            sSQL.Append(SQLNumber(2) & COMMA) 'BalanceMode, tinyint, NOT NULL
        End If
        sSQL.Append(SQLStringUnicode(txtDescription, True) & COMMA) 'DescriptionU, nvarchar, NOT NULL
        sSQL.Append(SQLNumber(1) & COMMA) 'IsAttCoefUP, tinyint, NOT NULL
        sSQL.Append(SQLString(_attCoefUPID) & COMMA) 'AttCoefUPID, varchar[20], NOT NULL
        sSQL.Append(SQLString(CbVal(tdbcCode)) & COMMA) 'PWCode, varchar[20], NOT NULL
        sSQL.Append(SQLString(CbVal(tdbcSumPWPayrollID)) & COMMA) 'SumPWPayrollID, varchar[20], NOT NULL
        sSQL.Append(SQLString(CbVal(tdbcPieceworkCalMethodID))) 'PWCode, varchar[20], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T2010
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/10/2011 11:38:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T2010() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T2010 Set ")
        sSQL.Append("VoucherDate = " & SQLDateSave(c1dateVoucherDate.Value) & COMMA) 'datetime, NULL
        sSQL.Append("Description = " & SQLStringUnicode(txtDescription, False) & COMMA) 'varchar[150], NULL
        sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("DateFrom = " & SQLDateSave(c1dateAttDateFrom.Value) & COMMA) 'datetime, NULL
        sSQL.Append("DateTo = " & SQLDateSave(c1dateAttDateTo.Value) & COMMA) 'datetime, NULL
        If optBalanceMode0.Checked Then
            sSQL.Append("BalanceMode = " & SQLNumber(0) & COMMA) 'BalanceMode, tinyint, NOT NULL
        ElseIf optBalanceMode1.Checked Then
            sSQL.Append("BalanceMode = " & SQLNumber(1) & COMMA) 'BalanceMode, tinyint, NOT NULL
        Else
            sSQL.Append("BalanceMode = " & SQLNumber(2) & COMMA) 'BalanceMode, tinyint, NOT NULL
        End If
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("PWCode = " & SQLString(CbVal(tdbcCode)) & COMMA) 'varchar[150], NULL
        sSQL.Append("SumPWPayrollID= " & SQLString(CbVal(tdbcSumPWPayrollID)) & COMMA) 'varchar[150], NULL
        sSQL.Append("PieceworkCalMethodID = " & SQLString(CbVal(tdbcPieceworkCalMethodID))) 'varchar[20], NOT NULL
        sSQL.Append(" Where PSalaryVoucherID = " & SQLString(_pSalaryVoucherID))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUDFD45N5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 02/07/2012 01:53:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUDFD45N5555() As String
        Dim sSQL As String = ""
        sSQL &= "D45N5555("
        sSQL &= SQLString(_attCoefUPID) & COMMA 'AttCoefUPID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Languge, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function




    
End Class