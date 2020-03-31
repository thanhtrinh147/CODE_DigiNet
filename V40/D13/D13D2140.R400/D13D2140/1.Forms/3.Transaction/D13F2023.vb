Imports System
Public Class D13F2023
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Private dtAbsentVoucherNo As DataTable
    Private dtSalaryVoucherNo As DataTable
    Private dtShortName As DataTable

#Region "Public variables"
    Private _AbsentVoucherID As String = ""
    Public Property AbsentVoucherID() As String
        Get
            Return _AbsentVoucherID
        End Get
        Set(ByVal Value As String)
            If _AbsentVoucherID = Value Then
                _AbsentVoucherID = ""
                Return
            End If
            _AbsentVoucherID = Value
        End Set
    End Property

    Private _AbsentTypeID As String = ""
    Public Property AbsentTypeID() As String
        Get
            Return _AbsentTypeID
        End Get
        Set(ByVal Value As String)
            If _AbsentTypeID = Value Then
                _AbsentTypeID = ""
                Return
            End If
            _AbsentTypeID = Value
        End Set
    End Property

    Private _PayrollVoucherID As String = ""
    Public Property PayrollVoucherID() As String
        Get
            Return _PayrollVoucherID
        End Get
        Set(ByVal Value As String)
            If _PayrollVoucherID = Value Then
                _PayrollVoucherID = ""
                Return
            End If
            _PayrollVoucherID = Value
        End Set
    End Property

    Private _oldTranMonth As Integer = giTranMonth
    Public Property OldTranMonth() As Integer
        Get
            Return _oldTranMonth
        End Get
        Set(ByVal Value As Integer)
            _oldTranMonth = Value
        End Set
    End Property

    Private _OldTranYear As Integer = giTranYear
    Public Property OldTranYear() As Integer
        Get
            Return _OldTranYear
        End Get
        Set(ByVal Value As Integer)
            _OldTranYear = Value
        End Set
    End Property
#End Region

#Region "Events tdbcMonthYear"

    Private Sub tdbcMonthYear_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriod1.Close
        If tdbcPeriod1.FindStringExact(tdbcPeriod1.Text) = -1 Then tdbcPeriod1.Text = ""
    End Sub

    'Private Sub tdbcMonthYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPeriod1.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPeriod1.Text = ""
    'End Sub

#End Region

#Region "Events tdbcAbsentVoucherNo"

    Private Sub tdbcAbsentVoucherNo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAbsentVoucherNo.LostFocus
        If tdbcAbsentVoucherNo.FindStringExact(tdbcAbsentVoucherNo.Text) = -1 Then tdbcAbsentVoucherNo.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAbsentVoucherNo.Close, tdbcSalaryVoucherNo.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAbsentVoucherNo.Validated, tdbcSalaryVoucherNo.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub


#Region "Events tdbcAbsentTypeDateID"

    Private Sub tdbcAbsentTypeDateID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAbsentTypeDateID.Close
        If tdbcAbsentTypeDateID.FindStringExact(tdbcAbsentTypeDateID.Text) = -1 Then tdbcAbsentTypeDateID.Text = ""
    End Sub

    'Private Sub tdbcAbsentTypeDateID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAbsentTypeDateID.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAbsentTypeDateID.Text = ""
    'End Sub

#End Region

#Region "Events tdbcPeriod"

    Private Sub tdbcPeriod_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriod2.Close
        If tdbcPeriod2.FindStringExact(tdbcPeriod2.Text) = -1 Then tdbcPeriod2.Text = ""
    End Sub

    'Private Sub tdbcPeriod_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPeriod2.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPeriod2.Text = ""
    'End Sub

#End Region

#Region "Events tdbcLeaveTypeID"

    Private Sub tdbcLeaveTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcLeaveTypeID.Close
        If tdbcLeaveTypeID.FindStringExact(tdbcLeaveTypeID.Text) = -1 Then tdbcLeaveTypeID.Text = ""
    End Sub

    'Private Sub tdbcLeaveTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcLeaveTypeID.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcLeaveTypeID.Text = ""
    'End Sub

#End Region

#Region "Events tdbcLeaveIndexID"

    Private Sub tdbcLeaveIndexID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcLeaveIndexID.Close
        If tdbcLeaveIndexID.FindStringExact(tdbcLeaveIndexID.Text) = -1 Then tdbcLeaveIndexID.Text = ""
    End Sub

    'Private Sub tdbcLeaveIndexID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcLeaveIndexID.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcLeaveIndexID.Text = ""
    'End Sub

#End Region

#Region "Events tdbcMonthYearSalary load tdbcSalaryVoucherNo, tdbcShortName"

    Private Sub tdbcMonthYearSalary_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMonthYearSalary.Close
        If tdbcMonthYearSalary.FindStringExact(tdbcMonthYearSalary.Text) = -1 Then tdbcMonthYearSalary.Text = ""
    End Sub

    Private Sub tdbcMonthYearSalary_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMonthYearSalary.SelectedValueChanged
        If Not (tdbcMonthYearSalary.Tag Is Nothing OrElse tdbcMonthYearSalary.Tag.ToString = "") Then
            tdbcMonthYearSalary.Tag = ""
            Exit Sub
        End If
        If tdbcMonthYearSalary.SelectedValue Is Nothing Then
            LoadtdbcSalaryVoucherNo("-1", "-1")
            Exit Sub
        End If
        LoadtdbcSalaryVoucherNo(tdbcMonthYearSalary.Columns("TranMonth").Text, tdbcMonthYearSalary.Columns("TranYear").Text)
        tdbcSalaryVoucherNo.SelectedIndex = 0
    End Sub

    Private Sub tdbcSalaryVoucherNo_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryVoucherNo.Close
        If tdbcSalaryVoucherNo.FindStringExact(tdbcSalaryVoucherNo.Text) = -1 Then tdbcSalaryVoucherNo.Text = ""
    End Sub

    Private Sub tdbcSalaryVoucherNo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryVoucherNo.SelectedValueChanged
        If Not (tdbcSalaryVoucherNo.Tag Is Nothing OrElse tdbcSalaryVoucherNo.Tag.ToString = "") Then
            tdbcSalaryVoucherNo.Tag = ""
            Exit Sub
        End If
        If tdbcSalaryVoucherNo.SelectedValue Is Nothing Then
            LoadtdbcShortName("-1")
            Exit Sub
        End If
        LoadtdbcShortName(tdbcSalaryVoucherNo.Columns("SalCalMethodID").Text)
        tdbcShortName.SelectedIndex = 0
    End Sub

    Private Sub tdbcShortName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcShortName.Close
        If tdbcShortName.FindStringExact(tdbcShortName.Text) = -1 Then tdbcShortName.Text = ""
    End Sub

#End Region


    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ke_thua_du_lieu_-_D13F2023") & UnicodeCaption(gbUnicode) 'KÕ thôa dö liÖu - D13F2023
        '================================================================ 
        Label1.Text = rl3("Ky_ke_toan") 'Kỳ kế toán
        lblLeaveTypeID.Text = rl3("Loai_phep") 'Loại phép
        'Label2.Text = rl3("Chi_tieu_phep") 'Chỉ tiêu phép
        lblLeaveIndexID.Text = rl3("Chi_tieu_phep") 'Chỉ tiêu phép
        lblMonthYear.Text = rl3("Ky_ke_toan") 'Kỳ kế toán
        lblFormular.Text = rl3("Cong_thuc") 'Công thức
        lblDecimal.Text = rl3("Lam_tron") 'Làm tròn

        lblAbsentTypeDateID.Text = rl3("Khoan_dieu_chinh_thu_nhap")
        lblMonthYearSalary.Text = rl3("Ky_ke_toan") 'Kỳ kế toán
        lblSalaryVoucherNo.Text = rl3("Phieu_luong") 'Phiếu lương
        lblShortName.Text = rl3("Khoan_thu_nhap") 'Khoản thu nhập
        lblAbsentVoucherNo.Text = rl3("Phieu_dieu_chinh_thu_nhap") 'Phiếu điều chỉnh thu nhập

        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnRewardType.Text = rl3("_Cac_loai_thuong") '&Các loại thưởng
        '================================================================ 
        optLeaveType.Text = rl3("Loai_phep") 'Loại phép
        optLeaveQuantity.Text = rl3("Chi_tieu_phep") 'Chỉ tiêu phép
        optLeave.Text = rl3("Quan_ly_phep") 'Quản lý phép
        optCheckVoucher.Text = rl3("Phieu_dieu_chinh_thu_nhap") 'Phiếu điều chỉnh thu nhập
        optSenior.Text = rl3("Thuong_theo_tham_nien") 'Thưởng theo thâm niên
        optSalaryVoucher.Text = rl3("Phieu_luong") 'Phiếu lương
        '================================================================ 
        chkSaveLastValue.Text = rl3("Luu_gia_tri_gan_nhat") 'Lưu giá trị gần nhất
        '================================================================ 
        grpSenior.Text = rl3("Thong_so_ke_thua") 'Thông số kế thừa
        '================================================================ 
        tdbcLeaveIndexID.Columns("LeaveIndexID").Caption = rl3("Ma") 'Mã
        tdbcLeaveIndexID.Columns("LeaveIndexName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcLeaveTypeID.Columns("LeaveTypeID").Caption = rl3("Ma") 'Mã
        tdbcLeaveTypeID.Columns("LeaveTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcPeriod2.Columns("MonthYear").Caption = rl3("Ky_ke_toan") 'Kỳ kế toán
        tdbcAbsentTypeDateID.Columns("AbsentTypeDateID").Caption = rl3("Ma") 'Mã
        tdbcAbsentTypeDateID.Columns("AbsentTypeDateName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcAbsentVoucherNo.Columns("AbsentVoucherID").Caption = rl3("Ma_phieu_ngam") 'Mã phiếu ngầm
        tdbcAbsentVoucherNo.Columns("PayrollVoucherID").Caption = rl3("Ma_ho_so") 'Mã Hồ sơ
        tdbcAbsentVoucherNo.Columns("AbsentVoucherNo").Caption = rl3("Ma") 'Mã
        tdbcAbsentVoucherNo.Columns("Remark").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcPeriod1.Columns("MonthYear").Caption = rl3("Ky_ke_toan") 'Kỳ kế toán

        tdbcSalaryVoucherNo.Columns("SalaryVoucherNo").Caption = rl3("Ma") 'Mã
        tdbcSalaryVoucherNo.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbcShortName.Columns("ShortName").Caption = rl3("Ten_tat") 'Tên tắt
        tdbcShortName.Columns("Caption").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub SetBackColorObligatory()
        txtFormular.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriod1.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcAbsentVoucherNo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcAbsentTypeDateID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriod2.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcLeaveTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcLeaveIndexID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMonthYearSalary.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcSalaryVoucherNo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcShortName.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub D13F2023_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' update 27/3/2013 id 55260 - Delete dữ liệu bảng tạm sau khi đóng form
        Dim sSQL As String
        sSQL = "-- Delete bang tam" & vbCrLf
        sSQL &= "DELETE D09T6666 "
        sSQL &= "WHERE 	FormID = 'D13F2023' "
        sSQL &= " AND UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name) & vbCrLf
        ExecuteSQLNoTransaction(sSQL)
    End Sub

    Private Sub D13F2023_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        FormKeyPress(sender, e)
    End Sub

    Private Sub D13F2023_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        SetBackColorObligatory()
        CreateTableAbsentVoucherNo()
        LoadTDBCombo()
        tdbcDecimal.Text = "0"
        LoadLastValue()
        SetResolutionForm(Me)
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtFormular, txtFormular.MaxLength, True)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcMonthFrom
        sSQL = "Select (Right(('0'+RTrim(LTrim(str(TranMonth)))),2)+ '/' + LTrim(Str(TranYear))) As MonthYear,TranYear,TranMonth" & vbCrLf
        sSQL &= "From D09T9999  WITH (NOLOCK) Where DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "order by TranYear Desc,TranMonth Desc"
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbcPeriod1, dt, gbUnicode)
        LoadDataSource(tdbcPeriod2, ReturnTableFilter(dt, ""), gbUnicode)

        'Load tdbcAbsentTypeDateID
        sSQL = "Select AbsentTypeDateID, AbsentTypeDateName" & UnicodeJoin(gbUnicode) & " as AbsentTypeDateName From D13T0118  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 Order by Orders"
        LoadDataSource(tdbcAbsentTypeDateID, sSQL, gbUnicode)

        'Load tdbcLeaveTypeID
        sSQL = "Select LeaveTypeID,LeaveTypeName" & UnicodeJoin(gbUnicode) & " as LeaveTypeName From D15T1020  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 Order by LeaveTypeID"
        LoadDataSource(tdbcLeaveTypeID, sSQL, gbUnicode)

        'Load tdbcLeaveIndexID
        sSQL = "Select LeaveIndexID,LeaveIndexName" & UnicodeJoin(gbUnicode) & " as LeaveIndexName From D15T1110  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 Order by LeaveIndexID"
        LoadDataSource(tdbcLeaveIndexID, sSQL, gbUnicode)

        'Load tdbcMonthYearSalary
        LoadCboPeriodReport(tdbcMonthYearSalary, "D09")

        'Load tdbcSalaryVoucherNo
        sSQL = "Select SalaryVoucherNo, Description" & UnicodeJoin(gbUnicode) & " as Description, SalaryVoucherID, PayrollVoucherID, TranMonth, TranYear, SalCalMethodID" & vbCrLf
        sSQL &= "From D13T2600 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where DivisionID = " & SQLString(gsDivisionID)
        dtSalaryVoucherNo = ReturnDataTable(sSQL)

        'Load tdbcShortName
        sSQL = "Select ShortName" & UnicodeJoin(gbUnicode) & " as ShortName, Caption" & UnicodeJoin(gbUnicode) & " as Caption, SalCalMethodID, CalNo" & vbCrLf
        sSQL &= "From D13T2501 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0"
        dtShortName = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadtdbcSalaryVoucherNo(ByVal sTranMonth As String, ByVal sTranYear As String)
        LoadDataSource(tdbcSalaryVoucherNo, ReturnTableFilter(dtSalaryVoucherNo, "TranMonth=" & SQLNumber(sTranMonth) & " And TranYear=" & SQLNumber(sTranYear)), gbUnicode)
    End Sub

    Private Sub LoadtdbcShortName(ByVal ID As String)
        LoadDataSource(tdbcShortName, ReturnTableFilter(dtShortName, "SalCalMethodID = " & SQLString(ID)), gbUnicode)
    End Sub

    Private Sub CreateTableAbsentVoucherNo()
        Dim sSQL As String = ""
        'Load tdbcAbsentVoucherNo
        sSQL = "Select AbsentVoucherID,PayrollVoucherID,AbsentVoucherNo,Remark" & UnicodeJoin(gbUnicode) & " as Remark,TranMonth,TranYear" & vbCrLf
        sSQL &= "From D13T0102 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "And AbsentVoucherID <> " & SQLString(_AbsentVoucherID) & vbCrLf
        sSQL &= "Order by EntryDate"
        dtAbsentVoucherNo = ReturnDataTable(sSQL)

    End Sub

    Private Sub LoadtdbcAbsentVoucherNo(ByVal sTranMonth As String, ByVal sTranYear As String)
        'Load tdbcAbsentVoucherNo
        LoadDataSource(tdbcAbsentVoucherNo, ReturnTableFilter(dtAbsentVoucherNo, _
        "TranMonth=" & SQLNumber(sTranMonth) & " And TranYear=" & SQLNumber(sTranYear)), gbUnicode)
    End Sub

    Private Sub tdbcPeriod1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriod1.SelectedValueChanged
        If tdbcPeriod1.Text <> "" Then
            LoadtdbcAbsentVoucherNo(tdbcPeriod1.Columns("TranMonth").Text, tdbcPeriod1.Columns("TranYear").Text)
        End If
    End Sub

    Private Sub btnRewardType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRewardType.Click
        Dim f As New D13F2024
        f.ShowDialog()
        txtFormular.Text = txtFormular.Text & f.Formular
        f.Dispose()
    End Sub

    Private Sub optLeaveType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optLeaveType.Click
        'Sáng các control trong phần 'Loại phép'
        tdbcPeriod2.Enabled = True
        tdbcLeaveTypeID.Enabled = True
        tdbcPeriod2.AutoSelect = True
        tdbcLeaveTypeID.AutoSelect = True

        'Mờ các  control trong phần 'Chỉ tiêu phép'
        tdbcLeaveIndexID.Text = ""
        tdbcLeaveIndexID.Enabled = False
    End Sub

    Private Sub optLeaveQuantity_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optLeaveQuantity.Click
        'Sáng các control trong phần 'Chỉ tiêu phép'
        tdbcLeaveIndexID.Enabled = True
        tdbcLeaveIndexID.AutoSelect = True

        'Mờ cá  control trong phần 'Loại phép'
        tdbcPeriod2.Text = ""
        tdbcLeaveTypeID.Text = ""
        tdbcPeriod2.Enabled = False
        tdbcLeaveTypeID.Enabled = False
    End Sub

    Private Sub optSenior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSenior.Click
        EnabledSenior(True)
        EnabledCheckVoucher(False)
        EnabledLeave(False)
        EnabledSalaryVoucher(False)
    End Sub

    Private Sub optCheckVoucher_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCheckVoucher.Click
        EnabledSenior(False)
        EnabledCheckVoucher(True)
        EnabledLeave(False)
        EnabledSalaryVoucher(False)
    End Sub

    Private Sub optLeave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optLeave.Click
        EnabledSenior(False)
        EnabledCheckVoucher(False)
        EnabledLeave(True)
        EnabledSalaryVoucher(False)
    End Sub

    Private Sub optSalaryVoucher_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSalaryVoucher.Click
        EnabledSenior(False)
        EnabledCheckVoucher(False)
        EnabledLeave(False)
        EnabledSalaryVoucher(True)
    End Sub

    'Mờ/sáng các control trong phần 'Thưởng theo thâm niên'
    Private Sub EnabledSenior(ByVal bFlag As Boolean)
        If bFlag Then
            txtFormular.Enabled = True
            btnRewardType.Enabled = True
            tdbcDecimal.Enabled = True
        Else
            txtFormular.Text = ""
            tdbcDecimal.Text = ""

            txtFormular.Enabled = False
            btnRewardType.Enabled = False
            tdbcDecimal.Enabled = False
        End If
    End Sub

    'Mờ/sáng các control trong phần 'Phiếu chấm công'
    Private Sub EnabledCheckVoucher(ByVal bFlag As Boolean)
        If bFlag Then
            tdbcPeriod1.Enabled = True
            tdbcAbsentVoucherNo.Enabled = True
            tdbcAbsentTypeDateID.Enabled = True
            tdbcPeriod1.AutoSelect = True
            tdbcAbsentVoucherNo.AutoSelect = True
            tdbcAbsentTypeDateID.AutoSelect = True
        Else
            tdbcPeriod1.Text = ""
            tdbcAbsentVoucherNo.Text = ""
            tdbcAbsentTypeDateID.Text = ""
            tdbcPeriod1.Enabled = False
            tdbcAbsentVoucherNo.Enabled = False
            tdbcAbsentTypeDateID.Enabled = False
        End If
    End Sub

    'Mờ/sáng các control trong phần 'Quản lý phép'
    Private Sub EnabledLeave(ByVal bFlag As Boolean)
        If bFlag Then
            optLeaveType.Enabled = True
            optLeaveQuantity.Enabled = True
        Else
            optLeaveType.Checked = False
            optLeaveQuantity.Checked = False
            optLeaveType.Enabled = False
            tdbcPeriod2.Text = ""
            tdbcLeaveTypeID.Text = ""
            tdbcPeriod2.Enabled = False
            tdbcLeaveTypeID.Enabled = False
            optLeaveQuantity.Enabled = False
            tdbcLeaveIndexID.Text = ""
            tdbcLeaveIndexID.Enabled = False
        End If
    End Sub

    'Mờ/sáng các control trong phần 'Phiếu lương'
    Private Sub EnabledSalaryVoucher(ByVal bFlag As Boolean)
        If bFlag Then
            tdbcMonthYearSalary.Enabled = True
            tdbcSalaryVoucherNo.Enabled = True
            tdbcShortName.Enabled = True
            tdbcMonthYearSalary.AutoSelect = True
            tdbcSalaryVoucherNo.AutoSelect = True
            tdbcShortName.AutoSelect = True
        Else
            tdbcMonthYearSalary.Text = ""
            tdbcSalaryVoucherNo.Text = ""
            tdbcShortName.Text = ""
            tdbcMonthYearSalary.Enabled = False
            tdbcSalaryVoucherNo.Enabled = False
            tdbcShortName.Enabled = False
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowInherit() As Boolean
        If optSenior.Checked Then
            If txtFormular.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Cong_thuc"))
                txtFormular.Focus()
                Return False
            End If
        End If

        If optCheckVoucher.Checked Then
            If tdbcPeriod1.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky_ke_toan"))
                tdbcPeriod1.Focus()
                Return False
            End If
            If tdbcAbsentVoucherNo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Phieu_cham_cong"))
                tdbcAbsentVoucherNo.Focus()
                Return False
            End If
            If tdbcAbsentTypeDateID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Loai_cham_cong"))
                tdbcAbsentTypeDateID.Focus()
                Return False
            End If
        End If

        If optSalaryVoucher.Checked Then
            If tdbcMonthYearSalary.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky_ke_toan"))
                tdbcMonthYearSalary.Focus()
                Return False
            End If
            If tdbcSalaryVoucherNo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Phieu_luong"))
                tdbcSalaryVoucherNo.Focus()
                Return False
            End If
            If tdbcShortName.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Khoan_thu_nhap"))
                tdbcShortName.Focus()
                Return False
            End If
        End If

        If optLeave.Checked AndAlso optLeaveType.Checked Then
            If tdbcPeriod2.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky_ke_toan"))
                tdbcPeriod2.Focus()
                Return False
            End If
            If tdbcLeaveTypeID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Loai_phep"))
                tdbcLeaveTypeID.Focus()
                Return False
            End If
        End If

        If optLeave.Checked AndAlso optLeaveQuantity.Checked Then
            If tdbcLeaveIndexID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Chi_tieu_phep"))
                tdbcLeaveIndexID.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim sSQL As String
        'Coi lai
        Dim sDepartmentID As String
        Dim sTeamID As String
        Dim sNewPayrollVoucherID As String
        Dim sNewAbsentVoucherID As String
        Dim sNewTranMonth As String
        Dim sNewTranYear As String

        'Tìm thông tin từ phiếu hiện tại
        sSQL = "Select DepartmentID,TeamID,TranMonth as NewTranMonth,TranYear as NewTranYear," & vbCrLf
        sSQL &= "PayrollVoucherID as NewPayrollVoucherID,AbsentVoucherID as NewAbsentVoucherID," & vbCrLf
        sSQL &= "VoucherTypeID as NewAbsentTypeID From D13T0102 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where AbsentVoucherID=" & SQLString(_AbsentVoucherID) & " And DivisionID=" & SQLString(gsDivisionID) 'SQLString(tdbcAbsentVoucherNo.Columns("AbsentVoucherID").Value) & " And DivisionID=" & SQLString(gsDivisionID)
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count < 1 Then Exit Sub
        With dt.Rows(0)
            sDepartmentID = .Item("DepartmentID").ToString
            sTeamID = .Item("TeamID").ToString
            sNewPayrollVoucherID = .Item("NewPayrollVoucherID").ToString
            sNewAbsentVoucherID = .Item("NewAbsentVoucherID").ToString
            sNewTranMonth = .Item("NewTranMonth").ToString
            sNewTranYear = .Item("NewTranYear").ToString
        End With

        If Not AllowInherit() Then Exit Sub

        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        If optSenior.Checked Then
            sSQL = SQLStoreD13P2020(0, gsDivisionID, sDepartmentID, sTeamID, 0, 0, "", "", "", sNewTranMonth, sNewTranYear, sNewPayrollVoucherID, sNewAbsentVoucherID, _AbsentTypeID, txtFormular.Text, tdbcDecimal.Text)
        End If

        If optCheckVoucher.Checked Then
            sSQL = SQLStoreD13P2020(1, gsDivisionID, sDepartmentID, sTeamID, CInt(tdbcPeriod1.Columns("TranMonth").Text), CInt(tdbcPeriod1.Columns("TranYear").Text), tdbcAbsentVoucherNo.Columns("PayrollVoucherID").Value.ToString, tdbcAbsentVoucherNo.Columns("AbsentVoucherID").Value.ToString, tdbcAbsentTypeDateID.Columns("AbsentTypeDateID").Value.ToString, sNewTranMonth, sNewTranYear, sNewPayrollVoucherID, sNewAbsentVoucherID, _AbsentTypeID, txtFormular.Text, tdbcDecimal.Text)
        End If

        If optLeave.Checked AndAlso optLeaveType.Checked Then
            sSQL = SQLStoreD13P2027(0, gsDivisionID, sDepartmentID, sTeamID, CInt(tdbcPeriod2.Columns("TranMonth").Value), CInt(tdbcPeriod2.Columns("TranYear").Value), "", tdbcLeaveTypeID.Text, sNewTranMonth, sNewTranYear, sNewPayrollVoucherID, sNewAbsentVoucherID, _AbsentTypeID)
        End If

        If optLeave.Checked AndAlso optLeaveQuantity.Checked Then
            sSQL = SQLStoreD13P2027(1, gsDivisionID, sDepartmentID, sTeamID, 0, 0, tdbcLeaveIndexID.Text, "", sNewTranMonth, sNewTranYear, sNewPayrollVoucherID, sNewAbsentVoucherID, _AbsentTypeID)
        End If

        If optSalaryVoucher.Checked Then
            sSQL = SQLStoreD13P2021(gsDivisionID, sDepartmentID, sTeamID, CInt(tdbcMonthYearSalary.Columns("TranMonth").Value), CInt(tdbcMonthYearSalary.Columns("TranYear").Value), tdbcSalaryVoucherNo.Columns("SalaryVoucherID").Text, tdbcShortName.Columns("CalNo").Text, sNewTranMonth, sNewTranYear, sNewPayrollVoucherID, sNewAbsentVoucherID, _AbsentTypeID)
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)

        'Lưu giá trị gần nhất
        SaveLastValue()

        Me.Cursor = Cursors.Default
        If bRunSQL Then
            D99C0008.MsgL3(rL3("Ke_thua_thanh_cong"))
            _bSaved = True
            btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            D99C0008.MsgL3(rL3("Ke_thua_khong_thanh_cong"))
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Sub SaveLastValue()
        If chkSaveLastValue.Checked Then
            D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "SaveLastValue_D13F2023", "1")
        Else
            D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "SaveLastValue_D13F2023", "0")
            Exit Sub
        End If

        Dim sCopyParameter As String = "0"

        If optSenior.Checked Then
            sCopyParameter = "0"
        ElseIf optCheckVoucher.Checked Then
            sCopyParameter = "1"
        ElseIf optLeave.Checked Then
            sCopyParameter = "2"
        ElseIf optSalaryVoucher.Checked Then
            sCopyParameter = "3"
        End If

        D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "CopyParameter", sCopyParameter)

        Select Case sCopyParameter
            Case "0"
                D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "Formular", txtFormular.Text)
                D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "Decimal", tdbcDecimal.Text)
            Case "1"
                D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "Period1", tdbcPeriod1.Text)
                D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "AbsentVoucherNo", tdbcAbsentVoucherNo.Text)
                D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "Decimal", tdbcAbsentTypeDateID.Text)
            Case "2"
                If optLeaveType.Checked Then
                    D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "LeaveType", "1")
                    D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "Period2", tdbcPeriod2.Text)
                    D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "LeaveTypeID", tdbcLeaveTypeID.Text)
                ElseIf optLeaveQuantity.Checked Then
                    D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "LeaveType", "2")
                    D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "LeaveIndexID", tdbcLeaveIndexID.Text)
                Else
                    D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "LeaveType", "0")
                    D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "Period2", "")
                    D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "LeaveTypeID", "")
                    D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "LeaveIndexID", "")
                End If
            Case "3"
                D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "MonthYearSalary", tdbcMonthYearSalary.Text)
                D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "SalaryVoucherNo", tdbcSalaryVoucherNo.Text)
                D99C0007.SaveModulesSetting(D13, ModuleOption.lmLastValues, "ShortName", tdbcShortName.Text)
        End Select
    End Sub

    Private Sub LoadLastValue()
        Dim sCopyParameter As String = "0"
        chkSaveLastValue.Checked = CBool(D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "SaveLastValue_D13F2023", "0"))

        If chkSaveLastValue.Checked Then
            sCopyParameter = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "CopyParameter", "0")
            Select Case sCopyParameter
                Case "0"
                    optSenior.Checked = True
                    optSenior_Click(Nothing, Nothing)
                    txtFormular.Text = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "Formular", "")
                    tdbcDecimal.Text = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "Decimal", "")
                Case "1"
                    optCheckVoucher.Checked = True
                    optCheckVoucher_Click(Nothing, Nothing)
                    tdbcPeriod1.Text = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "Period1", "")
                    tdbcAbsentVoucherNo.Text = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "AbsentVoucherNo", "")
                    tdbcAbsentTypeDateID.Text = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "Decimal", "")
                Case "2"
                    optLeave.Checked = True
                    optLeave_Click(Nothing, Nothing)
                    Dim sLeaveType As String = "1"
                    sLeaveType = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "LeaveType", "1")
                    Select Case sLeaveType
                        Case "0"
                            tdbcPeriod2.Text = ""
                            tdbcLeaveTypeID.Text = ""
                            tdbcLeaveIndexID.Text = ""
                            tdbcPeriod2.Enabled = False
                            tdbcLeaveTypeID.Enabled = False
                            tdbcLeaveIndexID.Enabled = False
                        Case "1"
                            optLeaveType.Checked = True
                            optLeaveType_Click(Nothing, Nothing)
                            tdbcPeriod2.Text = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "Period2", "")
                            tdbcLeaveTypeID.Text = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "LeaveTypeID", "")
                        Case "2"
                            optLeaveQuantity.Checked = True
                            optLeaveQuantity_Click(Nothing, Nothing)
                            tdbcLeaveIndexID.Text = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "LeaveIndexID", "")
                    End Select
                Case "3"
                    optSalaryVoucher.Checked = True
                    optSalaryVoucher_Click(Nothing, Nothing)
                    tdbcMonthYearSalary.Text = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "MonthYearSalary", "")
                    tdbcSalaryVoucherNo.Text = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "SalaryVoucherNo", "")
                    tdbcShortName.Text = D99C0007.GetModulesSetting(D13, ModuleOption.lmLastValues, "ShortName", "")
            End Select
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2020
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 22/02/2007 11:42:39
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2020(ByVal iMode As Int16, ByVal sDivisionID As String, ByVal DepartmentID As String, ByVal TeamID As _
                                      String, ByVal OldTranMonth As Integer, ByVal OldTranYear As Integer, ByVal OldPayrollVoucherID As _
                                      String, ByVal OldAbsentVoucherID As String, ByVal OldAbsentTypeID As String, ByVal NewTranMonth As _
                                      String, ByVal NewTranYear As String, ByVal NewPayrollVoucherID As String, ByVal NewAbsentVoucherID As _
                                      String, ByVal NewAbsentTypeID As String, ByVal sFormular As String, ByVal sDecimal As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2020 "
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(sDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(DepartmentID) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(TeamID) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLNumber(OldTranMonth) & COMMA 'OldTranMonth, smallint, NOT NULL
        sSQL &= SQLNumber(OldTranYear) & COMMA 'OldTranYear, smallint, NOT NULL
        sSQL &= SQLString(OldPayrollVoucherID) & COMMA 'OldPayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(OldAbsentVoucherID) & COMMA 'OldAbsentVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(OldAbsentTypeID) & COMMA 'OldAbsentTypeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(NewTranMonth) & COMMA 'NewTranMonth, smallint, NOT NULL
        sSQL &= SQLNumber(NewTranYear) & COMMA 'NewTranYear, smallint, NOT NULL
        sSQL &= SQLString(NewPayrollVoucherID) & COMMA 'NewPayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(NewAbsentVoucherID) & COMMA 'NewAbsentVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(NewAbsentTypeID) & COMMA 'NewAbsentTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(sFormular) & COMMA 'Formular, varchar[500], NOT NULL
        sSQL &= SQLNumber(sDecimal) & COMMA  'Decimals, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F2020") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name)

        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2025
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 22/02/2007 11:43:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2027(ByVal iMode As Int16, ByVal sDivisionID As String, ByVal DepartmentID As String, ByVal TeamID As String, ByVal OldTranMonth As _
                                      Integer, ByVal OldTranYear As Integer, ByVal LeaveIndexID As String, ByVal LeaveTypeID As _
                                      String, ByVal NewTranMonth As String, ByVal NewTranYear As String, ByVal NewPayrollVoucherID As _
                                      String, ByVal NewAbsentVoucherID As String, ByVal NewAbsentTypeID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2027 "
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(sDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(DepartmentID) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(TeamID) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLNumber(OldTranMonth) & COMMA 'OldTranMonth, smallint, NOT NULL
        sSQL &= SQLNumber(OldTranYear) & COMMA 'OldTranYear, smallint, NOT NULL
        sSQL &= SQLString(LeaveIndexID) & COMMA 'LeaveIndexID, varchar[20], NOT NULL
        sSQL &= SQLString(LeaveTypeID) & COMMA 'LeaveTypeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(NewTranMonth) & COMMA 'NewTranMonth, smallint, NOT NULL
        sSQL &= SQLNumber(NewTranYear) & COMMA 'NewTranYear, smallint, NOT NULL
        sSQL &= SQLString(NewPayrollVoucherID) & COMMA 'NewPayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(NewAbsentVoucherID) & COMMA 'NewAbsentVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(NewAbsentTypeID) & COMMA  'NewAbsentTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F2020") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2021
    '# Created User: DUCTRONG
    '# Created Date: 01/12/2008 10:52:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2021(ByVal sDivisionID As String, ByVal DepartmentID As String, ByVal TeamID As String, _
                                      ByVal OldTranMonth As Integer, ByVal OldTranYear As Integer, _
                                      ByVal SalaryVoucherID As String, ByVal CalNo As String, _
                                      ByVal NewTranMonth As String, ByVal NewTranYear As String, _
                                      ByVal NewPayrollVoucherID As String, ByVal NewAbsentVoucherID As String, _
                                      ByVal NewAbsentTypeID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2021 "
        sSQL &= SQLString(sDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(DepartmentID) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(TeamID) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLNumber(OldTranMonth) & COMMA 'OldTranMonth, int, NOT NULL
        sSQL &= SQLNumber(OldTranYear) & COMMA 'OldTranYear, int, NOT NULL
        sSQL &= SQLString(SalaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(CalNo) & COMMA 'CalNo, varchar[20], NOT NULL
        sSQL &= SQLNumber(NewTranMonth) & COMMA 'NewTranMonth, int, NOT NULL
        sSQL &= SQLNumber(NewTranYear) & COMMA 'NewTranYear, int, NOT NULL
        sSQL &= SQLString(NewPayrollVoucherID) & COMMA 'NewPayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(NewAbsentVoucherID) & COMMA 'NewAbsentVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(NewAbsentTypeID) & COMMA 'NewAbsentTypeID, varchar[20], NOT NULL
        sSQL &= "0,N'',"
        sSQL &= SQLNumber(gbUnicode) & COMMA
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F2020") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name)
        Return sSQL
    End Function

End Class