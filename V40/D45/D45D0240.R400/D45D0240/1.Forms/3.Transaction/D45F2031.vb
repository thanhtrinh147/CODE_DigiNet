Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 3:39:07 PM
'# Created User: Nguyễn Thị Ánh
'# Modify Date: 08/05/2007 3:39:07 PM
'# Modify User: Nguyễn Thị Ánh
'#-------------------------------------------------------------------------------------
Public Class D45F2031
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim bSelected As Boolean = False, bSelected1 As Boolean = False, bKeyPress As Boolean = False
    Dim sEditVoucherTypeID As String = ""
    Dim dtGrid, dtDataSalary, dtGridPrice As DataTable
    Dim bNotInList As Boolean = False
    Dim sHAUnitPrices As String = "" 'Lưu giá trị của những dòng được chọn của lưới Đơn giá giờ công hệ số
    Dim sOldTranstypeID As String = ""

#Region "Const of tdbg"
    Private Const COL_IsUse As Integer = 0                  ' Chọn
    Private Const COL_VoucherDate As Integer = 1            ' Ngày phiếu
    Private Const COL_PSalaryVoucherNo As Integer = 2       ' Số phiếu
    Private Const COL_Description As Integer = 3            ' Diễn giải
    Private Const COL_PSalaryVoucherID As Integer = 4       ' PSalaryVoucherID
    Private Const COL_HAUnitPrices As Integer = 5           ' HAUnitPrices
    Private Const COL_PieceworkCalMethodName As Integer = 6 ' Phương pháp tính lương
    Private Const COL_PriceListName As Integer = 7          ' Bảng giá
#End Region

#Region "Const of tdbgUnitPrice"
    Private Const COL1_HAUnitPrices As Integer = 0     ' HAUnitPrices
    Private Const COL1_IsUsed As Integer = 1           ' Chọn
    Private Const COL1_HAUnitPricesName As Integer = 2 ' Đơn giá giờ công hệ số
    Private Const COL1_HACoef As Integer = 3           ' Giờ công hệ số
    Private Const COL1_Code As Integer = 4             ' Khoản thu nhập
    Private Const COL1_IsHANADate As Integer = 5       ' Ngày thường
    Private Const COL1_IsHAAADate1 As Integer = 6      ' Ngày nghỉ
    Private Const COL1_IsHAAADate2 As Integer = 7      ' Ngày nghỉ
    Private Const COL1_IsHANHADate As Integer = 8      ' Lễ ngày thường
    Private Const COL1_IsHAAHADate1 As Integer = 9     ' Lễ ngày nghỉ
    Private Const COL1_IsHAAHADate2 As Integer = 10    ' Lễ ngày nghỉ
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

            LoadTDBDropDown()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnCalculateSalary.Enabled = False
                    btnNext.Enabled = False
                    LoadTDBCombo()
                    LoadDefaultDate()
                Case EnumFormState.FormEdit
                    btnCalculateSalary.Enabled = True
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    btnCalculateSalary.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _attCoefUPID As String = ""
    Public Property AttCoefUPID() As String
        Get
            Return _attCoefUPID
        End Get
        Set(ByVal Value As String)
            _attCoefUPID = Value
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
        txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateAttDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateAttDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgUnitPrice.Splits(SPLIT0).DisplayColumns(COL1_HACoef).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgUnitPrice.Splits(SPLIT0).DisplayColumns(COL1_Code).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
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
        Loadlanguage()
        SetBackColorObligatory()
        tdbg_LockedColumns()
        LoadTDBGridUnitPrice()
        '**********************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtVoucherNo)
        '**********************
        InputDateCustomFormat(c1dateAttDateTo, c1dateAttDateFrom, c1dateVoucherDate)
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Tinh_don_gia_gio_cong_he_so_-_D45F2031") & UnicodeCaption(gbUnicode) 'TÛnh ¢¥n giÀ gié c¤ng hÖ sç - D45F2031
        '================================================================ 
        lblPayroll.Text = rl3("Phieu_luong") 'Phiếu lương
        lblAttDateFrom.Text = rl3("Ngay_cong") 'Ngày công
        lblPSalaryVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblUnitPrice.Text = rL3("Don_gia_gio_cong_he_so") 'Đơn giá giờ công hệ số
        lblTransTypeID.Text = rL3("Loai_nghiep_vu") 'Loại nghiệp vụ
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnCalculateSalary.Text = rl3("T_inh") 'Tín&h
        '================================================================ 
        chkIsDisplayedAllUP.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        chkIsDisplayedAllPS.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        '================================================================ 
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Loai_phieu") 'Loại phiếu
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rL3("Dien_giai") 'Diễn giải
        tdbcTransTypeID.Columns("TransTypeID").Caption = rL3("Ma") 'Mã
        tdbcTransTypeID.Columns("TransTypeName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbdHACoef.Columns("HACoef").Caption = rl3("Ma") 'Mã
        tdbdHACoef.Columns("HACoefName").Caption = rl3("Ten") 'Tên
        tdbdCode.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdCode.Columns("Name").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("IsUse").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("PSalaryVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("PieceworkCalMethodName").Caption = rl3("Phuong_phap_tinh_luong") ' Phương pháp tính lương
        tdbg.Columns("PriceListName").Caption = rl3("Bang_gia")      ' Bảng giá
        '================================================================ 
        tdbgUnitPrice.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbgUnitPrice.Columns("HAUnitPricesName").Caption = rl3("Don_gia_gio_cong_he_so") 'Đơn giá giờ công hệ số
        tdbgUnitPrice.Columns("HACoef").Caption = rl3("Gio_cong_he_so") 'Giờ công hệ số
        tdbgUnitPrice.Columns("Code").Caption = rl3("Khoan_thu_nhap") 'Khoản thu nhập
        tdbgUnitPrice.Columns("IsHANADate").Caption = rl3("Ngay_thuong") 'Ngày thường
        tdbgUnitPrice.Columns("IsHAAADate1").Caption = rl3("Ngay_nghi") & Space(1) & "1"  'Ngày nghỉ 1
        tdbgUnitPrice.Columns("IsHAAADate2").Caption = rl3("Ngay_nghi") & Space(1) & "2" 'Ngày nghỉ 2
        tdbgUnitPrice.Columns("IsHANHADate").Caption = rl3("Le_ngay_thuong") 'Lễ ngày thường
        tdbgUnitPrice.Columns("IsHAAHADate1").Caption = rl3("Le_ngay_nghi") & Space(1) & "1" 'Lễ ngày nghỉ 1
        tdbgUnitPrice.Columns("IsHAAHADate2").Caption = rl3("Le_ngay_nghi") & Space(1) & "2" 'Lễ ngày nghỉ 2
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_VoucherDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PSalaryVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PieceworkCalMethodName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PriceListName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcTransTypeID
        sSQL = "SELECT 	TransTypeID, TransTypeName" & UnicodeJoin(gbUnicode) & " as TransTypeName, VoucherTypeID, PreparerID" & vbCrLf
        sSQL &= "FROM D45T1042 WITH (NOLOCK)" & vbCrLf
        sSQL &= "WHERE Disabled = 0" & vbCrLf
        LoadDataSource(tdbcTransTypeID, sSQL, gbUnicode)
        sOldTranstypeID = ReturnValueC1Combo(tdbcTransTypeID)

        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, D45, sEditVoucherTypeID, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbdHACoef
        sSQL = "Select Code as HACoef,  ShortName" & UnicodeJoin(gbUnicode) & " As HACoefName" & vbCrLf
        sSQL &= "From D29T0080  WITH(NOLOCK) Where Type='HAC' And IsUsed  =1" & vbCrLf
        sSQL &= "Order by HACoef"
        LoadDataSource(tdbdHACoef, sSQL, gbUnicode)

        'Load tdbdCode
        sSQL = "Select Code, Name" & gsLanguage & UnicodeJoin(gbUnicode) & " As Name" & vbCrLf
        sSQL &= "From D45T0020  WITH(NOLOCK) Where Disabled=0"
        LoadDataSource(tdbdCode, sSQL, gbUnicode)
    End Sub



#Region "Events tdbcTransTypeID load tdbcVoucherTypeID"

    Private Sub tdbcTransTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.SelectedValueChanged
        If _FormState = EnumFormState.FormAdd Then
            If sOldTranstypeID <> "" Then
                If D99C0008.MsgAsk(rL3("Thiet_lap_tinh_don_gia_gio_cong_he_so_co_su_thay_doi_Ban_co_muon_thiet_lap_lai_khong")) = Windows.Forms.DialogResult.No Then
                    sOldTranstypeID = ReturnValueC1Combo(tdbcTransTypeID)
                    tdbcTransTypeID.Focus()
                    Exit Sub
                End If
            End If
        Else
            If D99C0008.MsgAsk(rL3("Thiet_lap_tinh_don_gia_gio_cong_he_so_co_su_thay_doi_Ban_co_muon_thiet_lap_lai_khong")) = Windows.Forms.DialogResult.No Then
                sOldTranstypeID = ReturnValueC1Combo(tdbcTransTypeID)
                tdbcTransTypeID.Focus()
                Exit Sub
            End If
        End If

        If tdbcTransTypeID.SelectedValue Is Nothing OrElse tdbcTransTypeID.Text = "" Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
            Exit Sub
        End If
        tdbcVoucherTypeID.SelectedValue = tdbcTransTypeID.Columns("VoucherTypeID").Text
        '***************
        Dim sSQL As String = ""
        sSQL = SQLStoreD45P1043()
        dtGridPrice = ReturnDataTable(sSQL)
        LoadDataSource(tdbgUnitPrice, dtGridPrice, gbUnicode)
        '***************
        Dim bLock As Boolean = True
        For i As Integer = 0 To tdbgUnitPrice.RowCount - 1
            If L3Bool(tdbgUnitPrice(i, COL1_IsUsed)) = True Then
                bLock = False
                Exit For
            End If
        Next
        LockedColGridSalary2(bLock)
        '***************
        sOldTranstypeID = ReturnValueC1Combo(tdbcTransTypeID)
        tdbcTransTypeID.Focus()
    End Sub

    Private Sub tdbcTransTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.LostFocus
        If tdbcTransTypeID.FindStringExact(tdbcTransTypeID.Text) = -1 Then
            tdbcTransTypeID.Text = ""
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
            Exit Sub
        End If
    End Sub

#End Region


#Region "Events tdbcVoucherTypeID"

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        If _FormState <> EnumFormState.FormAdd Then Exit Sub

        If Not (tdbcVoucherTypeID.Tag Is Nothing OrElse tdbcVoucherTypeID.Tag.ToString = "") Then
            tdbcVoucherTypeID.Tag = ""
            Exit Sub
        End If
        If tdbcVoucherTypeID.Columns("Auto").Text = "0" Then 'Không tạo mã tự động
            txtVoucherNo.ReadOnly = False
            txtVoucherNo.TabStop = True
            btnSetNewKey.Enabled = False
            txtVoucherNo.Text = ""
        Else
            gnNewLastKey = 0
            txtVoucherNo.ReadOnly = True
            txtVoucherNo.TabStop = False
            btnSetNewKey.Enabled = True
            If tdbcVoucherTypeID.Text <> "" Then txtVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.LostFocus
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
        End If
    End Sub
#End Region

    Private Sub LoadDefaultDate()
        c1dateVoucherDate.Value = Now.Date
        c1dateAttDateFrom.Value = Now.Date
        c1dateAttDateTo.Value = Now.Date
    End Sub

    Private Sub LoadEdit()
        ReadOnlyControl(tdbcTransTypeID, tdbcVoucherTypeID, txtVoucherNo)
        If _bCalculated Then c1dateVoucherDate.Enabled = False
        '********************************
        Dim sSQL As String = SQLStoreD45P2031()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            sEditVoucherTypeID = dt.Rows(0).Item("VoucherTypeID").ToString
            LoadTDBCombo()
            '-----------------------------------------------------
            tdbcVoucherTypeID.SelectedValue = dt.Rows(0).Item("VoucherTypeID").ToString
            txtVoucherNo.Text = dt.Rows(0).Item("VoucherNo").ToString
            c1dateVoucherDate.Value = SQLDateShow(dt.Rows(0).Item("VoucherDate").ToString)
            txtDescription.Text = dt.Rows(0).Item("Description").ToString
            c1dateAttDateFrom.Value = SQLDateShow(dt.Rows(0).Item("AttDateFrom").ToString)
            c1dateAttDateTo.Value = SQLDateShow(dt.Rows(0).Item("AttDateTo").ToString)
        End If
        '*******************************
        btnNext.Visible = False
        btnSetNewKey.Enabled = False
        btnSave.Left = btnNext.Left
    End Sub

    Private Sub LoadTDBGridUnitPrice()
        Dim sSQL As String = ""

        'Load lưới Đơn giá giờ công hệ số
        If _FormState = EnumFormState.FormAdd Then
            sSQL = SQLStoreD45P1043()
        Else
            sSQL = SQLStoreD45P2033()
        End If
        dtGridPrice = ReturnDataTable(sSQL)
        LoadDataSource(tdbgUnitPrice, dtGridPrice, gbUnicode)
    End Sub

    Private Sub LoadTDBGridSalary(ByVal sHAUnitPrices As String)
        If dtDataSalary Is Nothing Then
            Dim sSQL As String = ""
            'Load lưới Phiếu lương
            sSQL = SQLStoreD45P2034()
            dtDataSalary = ReturnDataTable(sSQL)
        End If
        dtGrid = ReturnTableFilter(dtDataSalary, "HAUnitPrices = " & SQLString(sHAUnitPrices), True)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        '***********************
        ReLoadTDBGrid()
        LockedColGridSalary()
    End Sub

    Private Sub LockedColGridSalary()
        'Khóa cột Chọn
        If L3Bool(tdbgUnitPrice(tdbgUnitPrice.Row, COL1_IsUsed)) = False Then
            tdbg.Splits(0).DisplayColumns(COL_IsUse).Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_IsUse).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_IsUse) = 0
            Next
        Else
            tdbg.Splits(0).DisplayColumns(COL_IsUse).Locked = False
            tdbg.Splits(SPLIT0).DisplayColumns(COL_IsUse).Style.ResetBackColor()
        End If
        tdbg.Refresh()
        tdbg.UpdateData()
    End Sub

    Private Sub LockedColGridSalary2(ByVal bLock As Boolean)
        'Khóa cột Chọn
        If bLock Then
            tdbg.Splits(0).DisplayColumns(COL_IsUse).Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_IsUse).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_IsUse) = 0
            Next
        Else
            tdbg.Splits(0).DisplayColumns(COL_IsUse).Locked = False
            tdbg.Splits(SPLIT0).DisplayColumns(COL_IsUse).Style.ResetBackColor()
        End If
        tdbg.Refresh()
        tdbg.UpdateData()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSetNewKey_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetNewKey.Click
        GetNewVoucherNo(tdbcVoucherTypeID, txtVoucherNo)
    End Sub

    Private Sub btnCalculateSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculateSalary.Click
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As String = SQLStoreD45P2030()
        If ExecuteSQLNoTransaction(sSQL) Then
            Dim f As New D45F2032
            With f
                .AttCoefUPID = _attCoefUPID
                .VoucherNo = txtVoucherNo.Text
                .ShowDialog()
                .Dispose()
            End With
        End If
        Me.Cursor = Cursors.Default
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If
        If txtVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("So_phieu"))
            txtVoucherNo.Focus()
            Return False
        End If
        If c1dateVoucherDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ngay_phieu"))
            c1dateVoucherDate.Focus()
            Return False
        End If
        '*******************************
        If CheckValidDateFromTo(c1dateAttDateFrom, c1dateAttDateTo) = False Then Return False
        '*******************************
        For i As Integer = 0 To tdbgUnitPrice.RowCount - 1
            If L3Bool(tdbgUnitPrice(i, COL1_IsUsed)) Then
                If tdbgUnitPrice(i, COL1_HACoef).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Gio_cong_he_so"))
                    tdbgUnitPrice.SplitIndex = SPLIT0
                    tdbgUnitPrice.Focus()
                    tdbgUnitPrice.Col = COL1_HACoef
                    tdbgUnitPrice.Bookmark = i
                    Return False
                End If
                If tdbgUnitPrice(i, COL1_Code).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Khoan_thu_nhap"))
                    tdbgUnitPrice.SplitIndex = SPLIT0
                    tdbgUnitPrice.Focus()
                    tdbgUnitPrice.Col = COL1_Code
                    tdbgUnitPrice.Bookmark = i
                    Return False
                End If
                If L3Bool(tdbgUnitPrice(i, COL1_IsHANADate)) = False AndAlso L3Bool(tdbgUnitPrice(i, COL1_IsHAAADate1)) = False AndAlso L3Bool(tdbgUnitPrice(i, COL1_IsHAAADate2)) = False _
                            AndAlso L3Bool(tdbgUnitPrice(i, COL1_IsHANHADate)) = False AndAlso L3Bool(tdbgUnitPrice(i, COL1_IsHAAHADate1)) = False AndAlso L3Bool(tdbgUnitPrice(i, COL1_IsHAAHADate2)) = False Then
                    D99C0008.MsgNotYetChoose(rL3("He_so_gio_cong"))
                    tdbgUnitPrice.SplitIndex = SPLIT0
                    tdbgUnitPrice.Focus()
                    tdbgUnitPrice.Col = COL1_IsHANADate
                    tdbgUnitPrice.Bookmark = i
                    Return False
                End If
                '***********************************
                LoadTDBGridSalary(tdbgUnitPrice(i, COL1_HAUnitPrices).ToString)
                Dim dt As DataTable = CType(tdbg.DataSource, DataTable).DefaultView.ToTable
                Dim dr() As DataRow = dt.Select("IsUse = 1")
                If dr.Length <= 0 Then
                    D99C0008.MsgL3(rL3("Ban_phai_chon_phieu_luong_de_tinh_don_gia_gio_cong_he_so") & Space(1) & tdbgUnitPrice(i, COL1_HAUnitPricesName).ToString)
                    tdbgUnitPrice.Bookmark = i

                    tdbg.SplitIndex = 0
                    tdbg.Focus()
                    tdbg.Col = COL_IsUse
                    tdbg.Row = 0
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbgUnitPrice.UpdateData()
        tdbg.UpdateData()

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
                sSQL.Append(SQLInsertD45T2030.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T2033s.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T2031s.ToString & vbCrLf)

                'Lưu LastKey của Số phiếu xuống Database (gọi hàm CreateIGEVoucherNo bật cờ True)
                If tdbcVoucherTypeID.Columns("Auto").Text <> "0" Then txtVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, True)

                'Kiểm tra trùng Số phiếu (gọi hàm CheckDuplicateVoucherNo)
                'Nếu tra trùng Số phiếu thì bật
                'btnSave.Enabled = True
                'btnClose.Enabled = True
                If CheckDuplicateVoucherNo("D45", "D45T2030", _attCoefUPID, txtVoucherNo.Text) Then
                    Me.Cursor = Cursors.Default
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    If tdbcVoucherTypeID.Columns("Auto").Text = "0" Then 'Không tạo mã tự động
                        txtVoucherNo.Focus()
                    Else
                        btnSetNewKey.Focus()
                    End If
                    Exit Sub
                End If

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T2030.ToString & vbCrLf)
                sSQL.Append(SQLDeleteD45T2033.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T2033s.ToString & vbCrLf)
                sSQL.Append(SQLDeleteD45T2031.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T2031s.ToString & vbCrLf)
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

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        _FormState = EnumFormState.FormAdd
        btnNext.Enabled = False
        btnSave.Enabled = True
        btnCalculateSalary.Enabled = False

        LoadDefaultDate()
        If D45Options.SaveLastRecent = False Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
            UnReadOnlyControl(txtVoucherNo)
            txtDescription.Text = ""
            tdbcVoucherTypeID.Focus()
        Else
            tdbcVoucherTypeID_SelectedValueChanged(sender, Nothing)
            If tdbcVoucherTypeID.Columns("Auto").Text = "0" Then 'Không tạo mã tự động
                txtVoucherNo.Focus()
            Else
                c1dateVoucherDate.Focus()
            End If
        End If
        LoadTDBGridUnitPrice()
        dtDataSalary = Nothing
        LoadTDBGridSalary(tdbgUnitPrice.Columns(COL1_HAUnitPrices).Text)

    End Sub

#Region "tdbg"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_IsUse
                UpdateGridSalary()
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_IsUse
                HeadClick(e.ColIndex)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            Select Case tdbg.Col
                Case COL_IsUse
                    HeadClick(tdbg.Col)
            End Select
        ElseIf e.KeyCode = Keys.Enter Then
            If tdbg.Col = COL_IsUse Then HotKeyEnterGrid(tdbg, COL_IsUse, e)
        End If
    End Sub
#End Region

#Region "tdbg1"

    Private Sub tdbg1_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgUnitPrice.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL1_HACoef
                If tdbgUnitPrice.Columns(COL1_HACoef).Text <> tdbdHACoef.Columns(tdbdHACoef.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL1_Code
                If tdbgUnitPrice.Columns(COL1_Code).Text <> tdbdCode.Columns(tdbdCode.DisplayMember).Text Then
                    bNotInList = True
                End If
        End Select
    End Sub

    Private Sub tdbgUnitPrice_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgUnitPrice.AfterColUpdate
        Select Case e.ColIndex
            Case COL1_IsUsed
                tdbgUnitPrice.Columns(COL1_HAUnitPrices).Tag = ""
                tdbgUnitPrice.UpdateData()
                LockedColGridSalary()
                If dtGrid Is Nothing Then Exit Sub
                ReLoadTDBGrid()
            Case COL1_HACoef, COL1_Code
                If bNotInList Then
                    tdbgUnitPrice.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                End If
        End Select
    End Sub

    Private Sub tdbg1_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgUnitPrice.HeadClick
        HeadClick1(e.ColIndex)
    End Sub

    Private Sub tdbg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgUnitPrice.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick1(tdbgUnitPrice.Col)
        ElseIf e.KeyCode = Keys.Enter Then
            If tdbgUnitPrice.Col = COL1_IsHAAHADate2 Then HotKeyEnterGrid(tdbgUnitPrice, COL1_IsUsed, e)
        End If
    End Sub

    Private Sub tdbg1_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgUnitPrice.RowColChange
        If e.LastRow = tdbgUnitPrice.Row Then Exit Sub
        LoadTDBGridSalary(tdbgUnitPrice(tdbgUnitPrice.Row, COL1_HAUnitPrices).ToString)
    End Sub
#End Region

    Private Sub UpdateGridSalary()
        'Merger dtGrid và dtSalary để cập nhật dữ liệu
        tdbg.UpdateData()
        dtDataSalary.PrimaryKey = New DataColumn() {dtDataSalary.Columns("HAUnitPrices"), dtDataSalary.Columns("PSalaryVoucherID")}
        dtDataSalary.Merge(dtGrid, False, MissingSchemaAction.AddWithKey)
    End Sub

    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 OrElse tdbg.Splits(0).DisplayColumns(COL_IsUse).Locked Then Exit Sub
        Select Case iCol
            Case COL_IsUse
                tdbg.AllowSort = False
                L3HeadClick(tdbg, iCol, bSelected) 'Có trong D99X0000
                UpdateGridSalary()
            Case Else
                tdbg.AllowSort = True 'Nếu mặc định AllowSort = True
        End Select
    End Sub

    Private Sub HeadClick1(ByVal iCol As Integer)
        If tdbgUnitPrice.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL1_IsUsed
            Case Else
                CopyColumns(tdbgUnitPrice, iCol, tdbgUnitPrice.Columns(iCol).Text, tdbgUnitPrice.Bookmark)
        End Select
    End Sub

#Region "Checkbox Hiển thị dữ liệu"

    Private Sub chkIsDisplayedAllPS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsDisplayedAllPS.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub chkIsDisplayedAllUP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsDisplayedAllUP.CheckedChanged
        If dtGridPrice Is Nothing Then Exit Sub
        ReLoadTDBGrid1()
    End Sub

    Private Sub ReLoadTDBGrid()
        dtGrid.AcceptChanges()
        Dim sFilter As String = "" 'TH sFind="" và chkIsUsed.Checked =False
        If chkIsDisplayedAllPS.Checked Then sFilter = "IsUse=True"
        dtGrid.DefaultView.RowFilter = sFilter
    End Sub

    Private Sub ReLoadTDBGrid1()
        dtGridPrice.AcceptChanges()
        Dim sFilter As String = "" 'TH sFind="" và chkIsUsed.Checked =False
        If chkIsDisplayedAllUP.Checked Then sFilter = "IsUsed=True"

        dtGridPrice.DefaultView.RowFilter = sFilter
        LoadTDBGridSalary(tdbgUnitPrice(tdbgUnitPrice.Row, COL1_HAUnitPrices).ToString)
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2031
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 03:10:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load Master
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2031() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2031 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2030") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_attCoefUPID) & COMMA 'AttCoefUPID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2030
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 03:13:24
    '# Modified User: 
    '# Modified Date: 
    '# Description: Button Tính
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2030() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2030 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2030") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_attCoefUPID) & COMMA 'AttCoefUPID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2030
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 03:18:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2030() As StringBuilder
        Dim sSQL As New StringBuilder("")
        _attCoefUPID = CreateIGE("D45T2030", "AttCoefUPID", "45", "UP", gsStringKey)

        sSQL.Append("Insert Into D45T2030(")
        sSQL.Append("AttCoefUPID, VoucherDate, VoucherTypeID, VoucherNo, Description, DescriptionU, ")
        sSQL.Append("AttDateFrom, AttDateTo, DivisionID, TranMonth, TranYear, CreateUserID, LastModifyUserID, CreateDate, LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(_attCoefUPID) & COMMA) 'AttCoefUPID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Value) & COMMA) 'VoucherDate, datetime, NOT NULL
        sSQL.Append(SQLString(CbVal(tdbcVoucherTypeID)) & COMMA) 'VoucherTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtDescription, False) & COMMA) 'Description, varchar[1000], NOT NULL
        sSQL.Append(SQLStringUnicode(txtDescription, True) & COMMA) 'DescriptionU, varchar[1000], NOT NULL
        sSQL.Append(SQLDateSave(c1dateAttDateFrom.Value) & COMMA) 'AttDateFrom, datetime, NOT NULL
        sSQL.Append(SQLDateSave(c1dateAttDateTo.Value) & COMMA) 'AttDateTo, datetime, NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T2030
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 03:24:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T2030() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T2030 Set ")
        sSQL.Append("VoucherDate = " & SQLDateSave(c1dateVoucherDate.Value) & COMMA) 'datetime, NOT NULL
        sSQL.Append("Description = " & SQLStringUnicode(txtDescription, False) & COMMA) 'varchar[1000], NOT NULL
        sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription, True) & COMMA) 'varchar[1000], NOT NULL
        sSQL.Append("AttDateFrom = " & SQLDateSave(c1dateAttDateFrom.Value) & COMMA) 'datetime, NOT NULL
        sSQL.Append("AttDateTo = " & SQLDateSave(c1dateAttDateTo.Value) & COMMA) 'datetime, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("AttCoefUPID = " & SQLString(_attCoefUPID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2031
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 03:28:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2031() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2031"
        sSQL &= " Where AttCoefUPID=" & SQLString(_attCoefUPID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2031s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 03:29:18
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2031s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        Dim dr() As DataRow = dtDataSalary.Select("IsUse = 1 And HAUnitPrices In (" & sHAUnitPrices & ")")
        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("Insert Into D45T2031(")
            sSQL.Append("AttCoefUPID, PSalaryVoucherID, PSalaryVoucherNo, HAUnitPrices")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(_attCoefUPID) & COMMA) 'AttCoefUPID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("PSalaryVoucherID").ToString) & COMMA) 'PSalaryVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("PSalaryVoucherNo").ToString) & COMMA) 'PSalaryVoucherNo, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("HAUnitPrices").ToString)) 'HAUnitPrices, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2033
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/03/2012 04:53:22
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load lưới Đơn giá giờ công hệ số
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2033() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2033 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        If _FormState = EnumFormState.FormAdd Then
            sSQL &= SQLString("") & COMMA 'AttCoefUPID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(_attCoefUPID) & COMMA 'AttCoefUPID, varchar[20], NOT NULL
        End If
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1043
    '# Created User: 
    '# Created Date: 17/09/2014 10:00:25
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1043() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi don gia gio cong he so" & vbCrlf)
        sSQL &= "Exec D45P1043 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTransTypeID)) & COMMA 'TransTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2031") & COMMA 'FormID, varchar[10], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2034
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/03/2012 04:54:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load lưới phiếu lương
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2034() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2034 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        If _FormState = EnumFormState.FormAdd Then
            sSQL &= SQLString("") & COMMA 'AttCoefUPID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(_attCoefUPID) & COMMA 'AttCoefUPID, varchar[20], NOT NULL
        End If
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2033
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 28/03/2012 10:12:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2033() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2033"
        sSQL &= " Where AttCoefUPID = " & SQLString(_attCoefUPID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2033s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 28/03/2012 10:07:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu lưới Đơn giá
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2033s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")
        sHAUnitPrices = ""

        Dim dt As DataTable = CType(tdbgUnitPrice.DataSource, DataTable).DefaultView.ToTable
        Dim dr() As DataRow = dt.Select("IsUsed = 1")
        For i As Integer = 0 To dr.Length - 1
            sHAUnitPrices &= SQLString(dr(i).Item(tdbgUnitPrice.Columns(COL1_HAUnitPrices).DataField).ToString) & ","
            '*************************
            sSQL.Append("Insert Into D45T2033(")
            sSQL.Append("AttCoefUPID, HAUnitPrices, PWCode, HACoef, IsHANADate, ")
            sSQL.Append("IsHAAADate1, IsHAAADate2, IsHANHADate, IsHAAHADate1, IsHAAHADate2")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(_attCoefUPID) & COMMA) 'AttCoefUPID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbgUnitPrice.Columns(COL1_HAUnitPrices).DataField).ToString) & COMMA) 'HAUnitPrices, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbgUnitPrice.Columns(COL1_Code).DataField).ToString) & COMMA) 'PWCode, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbgUnitPrice.Columns(COL1_HACoef).DataField).ToString) & COMMA) 'HACoef, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(dr(i).Item(tdbgUnitPrice.Columns(COL1_IsHANADate).DataField)) & COMMA) 'IsHANADate, tinyint, NOT NULL
            sSQL.Append(SQLNumber(dr(i).Item(tdbgUnitPrice.Columns(COL1_IsHAAADate1).DataField)) & COMMA) 'IsHAAADate1, tinyint, NOT NULL
            sSQL.Append(SQLNumber(dr(i).Item(tdbgUnitPrice.Columns(COL1_IsHAAADate2).DataField)) & COMMA) 'IsHAAADate2, tinyint, NOT NULL
            sSQL.Append(SQLNumber(dr(i).Item(tdbgUnitPrice.Columns(COL1_IsHANHADate).DataField)) & COMMA) 'IsHANHADate, tinyint, NOT NULL
            sSQL.Append(SQLNumber(dr(i).Item(tdbgUnitPrice.Columns(COL1_IsHAAHADate1).DataField)) & COMMA) 'IsHAAHADate1, tinyint, NOT NULL
            sSQL.Append(SQLNumber(dr(i).Item(tdbgUnitPrice.Columns(COL1_IsHAAHADate2).DataField))) 'IsHAAHADate2, tinyint, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        '*******************************
        sHAUnitPrices = Microsoft.VisualBasic.Left(sHAUnitPrices, sHAUnitPrices.Length - 1)
        '*******************************
        Return sRet
    End Function



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class