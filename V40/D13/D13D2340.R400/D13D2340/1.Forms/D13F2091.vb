Imports System
Public Class D13F2091
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbgSal"
    Private Const COLS_SalaryVoucherID As Integer = 0  ' SalaryVoucherID
    Private Const COLS_SalaryMethodID As Integer = 1   ' SalaryMethodID
    Private Const COLS_TranMonth As Integer = 2        ' TranMonth
    Private Const COLS_TranYear As Integer = 3         ' TranYear
    Private Const COLS_IsSelected As Integer = 4       ' Chọn
    Private Const COLS_SalaryVoucherNo As Integer = 5  ' Mã
    Private Const COLS_Description As Integer = 6      ' Diễn giải
    Private Const COLS_Period As Integer = 7           ' Kỳ
    Private Const COLS_SalaryMethodName As Integer = 8 ' Phương pháp tính lương
#End Region

#Region "Const of tdbgEmp"
    Private Const COLE_SalAdjTransID As Integer = 0     ' SalAdjTransID
    Private Const COLE_EmployeeID As Integer = 1        ' Mã NV
    Private Const COLE_EmployeeName As Integer = 2      ' Họ và tên
    Private Const COLE_BlockID As Integer = 3           ' Khối
    Private Const COLE_BlockName As Integer = 4         ' Tên khối
    Private Const COLE_DepartmentID As Integer = 5      ' Phòng ban
    Private Const COLE_DepartmentName As Integer = 6    ' Tên phòng ban
    Private Const COLE_TeamID As Integer = 7            ' Tổ nhóm
    Private Const COLE_TeamName As Integer = 8          ' Tên tổ nhóm
    Private Const COLE_EmpGroupID As Integer = 9        ' Nhóm NV
    Private Const COLE_EmpGroupName As Integer = 10     ' Tên nhóm NV
    Private Const COLE_DutyID As Integer = 11           ' Chức vụ
    Private Const COLE_DutyName As Integer = 12         ' Tên chức vụ
    Private Const COLE_WorkID As Integer = 13           ' Công việc
    Private Const COLE_WorkName As Integer = 14         ' Tên công việc
    Private Const COLE_BirthDate As Integer = 15        ' Ngày sinh
    Private Const COLE_SexName As Integer = 16          ' Giới tính
    Private Const COLE_DateJoined As Integer = 17       ' Ngày vào làm
    Private Const COLE_DateLeft As Integer = 18         ' Ngày nghỉ việc
    Private Const COLE_Age As Integer = 19              ' Tuổi
    Private Const COLE_StatusID As Integer = 20         ' Trạng thái làm việc
    Private Const COLE_StatusName As Integer = 21       ' Tên trạng thái làm việc
    Private Const COLE_AttendanceCardNo As Integer = 22 ' Mã thẻ chấm công
    Private Const COLE_RefEmployeeID As Integer = 23    ' Mã NV phụ
    Private Const COLE_PeriodFrom As Integer = 24       ' Từ kỳ
    Private Const COLE_PeriodTo As Integer = 25         ' Đến kỳ
    Private Const COLE_OldValue As Integer = 26         ' Mức cũ
    Private Const COLE_NewValue As Integer = 27         ' Mức mới
    Private Const COLE_DifferentAmount As Integer = 28  ' Chênh lệch
    Private Const COLE_TranMonthFrom As Integer = 29    ' TranMonthFrom
    Private Const COLE_TranYearFrom As Integer = 30     ' TranYearFrom
    Private Const COLE_TranMonthTo As Integer = 31      ' TranMonthTo
    Private Const COLE_TranYearTo As Integer = 32       ' TranYearTo
#End Region

    Private dtGridSal As DataTable
    Private dtGridEmp As DataTable

    Private _periodFrom As String = ""
    Public WriteOnly Property PeriodFrom() As String 
        Set(ByVal Value As String )
            _periodFrom = Value
        End Set
    End Property

    Private _periodTo As String = ""
    Public WriteOnly Property PeriodTo() As String 
        Set(ByVal Value As String )
            _periodTo = Value
        End Set
    End Property

    Private Sub D13F2091_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        ResetFooterGrid(tdbgSal, 0, tdbgSal.Splits.Count - 1)
        ResetColorGrid(tdbgEmp, 0, 1)

        LoadTDBCombo()
        LoadDefault()
        LoadTDBGridSal()
        LoadLanguage()

        tdbgSal_LockedColumns()
        SetBackColorObligatory()
        InputbyUnicode(Me, gbUnicode)
        InputDateInTrueDBGrid(tdbgEmp, COLE_DateJoined, COLE_DateLeft)
InputDateCustomFormat(c1dateBackPayDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadDefault()
        c1dateBackPayDate.Value = Now.Date
        tdbcPeriodFrom.SelectedValue = _periodFrom
        tdbcPeriodTo.SelectedValue = _periodTo
    End Sub

    Private Sub D13F2091_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F11
                HotKeyF11(Me, tdbgSal)
        End Select
    End Sub




    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Hoi_to_luongF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Häi tç l§¥ng
        '================================================================ 
        lblPeriodFrom.Text = rl3("Ky") 'Kỳ
        lblEmployee.Text = rl3("Nhan_vien") 'Nhân viên
        lblSalaryVoucher.Text = rl3("Phieu_luong") 'Phiếu lương
        lblInfo.Text = rl3("Thong_tin_chung") 'Thông tin chung
        lblBackPayDate.Text = rl3("Ngay_hoi_to") 'Ngày hồi tố
        lblSalaryParameter.Text = rl3("Thong_so_luong") 'Thông số lương
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnCal.Text = rl3("_Tinh") '&Tính
        btnBackPayResult.Text = rl3("_Ket_qua_hoi_to_luong") '&Kết quả hồi tố lương
        '================================================================ 
        chkIsUsed.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        '================================================================ 
        tdbgEmp.Columns(COLE_EmployeeID).Caption = rl3("Ma_NV") 'Mã NV
        tdbgEmp.Columns(COLE_EmployeeName).Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbgEmp.Columns(COLE_BlockID).Caption = rl3("Khoi") 'Khối
        tdbgEmp.Columns(COLE_BlockName).Caption = rl3("Ten_khoi") 'Tên khối
        tdbgEmp.Columns(COLE_DepartmentID).Caption = rl3("Phong_ban") 'Phòng ban
        tdbgEmp.Columns(COLE_DepartmentName).Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbgEmp.Columns(COLE_TeamID).Caption = rl3("To_nhom") 'Tổ nhóm
        tdbgEmp.Columns(COLE_TeamName).Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbgEmp.Columns(COLE_EmpGroupID).Caption = rl3("Nhom_NV") 'Nhóm NV
        tdbgEmp.Columns(COLE_EmpGroupName).Caption = rl3("Ten_nhom_NV") 'Tên nhóm NV
        tdbgEmp.Columns(COLE_DutyID).Caption = rl3("Chuc_vu") 'Chức vụ
        tdbgEmp.Columns(COLE_DutyName).Caption = rl3("Ten_chuc_vu") 'Tên chức vụ
        tdbgEmp.Columns(COLE_WorkID).Caption = rl3("Cong_viec") 'Công việc
        tdbgEmp.Columns(COLE_WorkName).Caption = rl3("Ten_cong_viec") 'Tên công việc
        tdbgEmp.Columns(COLE_BirthDate).Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbgEmp.Columns(COLE_SexName).Caption = rl3("Gioi_tinh") 'Giới tính
        tdbgEmp.Columns(COLE_DateJoined).Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbgEmp.Columns(COLE_DateLeft).Caption = rl3("Ngay_nghi_viec") 'Ngày nghỉ việc
        tdbgEmp.Columns(COLE_Age).Caption = rl3("Tuoi") 'Tuổi
        tdbgEmp.Columns(COLE_StatusID).Caption = rl3("Trang_thai_lam_viec") 'Trạng thái làm việc
        tdbgEmp.Columns(COLE_StatusName).Caption = rl3("Ten_trang_thai_lam_viec") 'Tên trạng thái làm việc
        tdbgEmp.Columns(COLE_AttendanceCardNo).Caption = rl3("Ma_the_cham_cong") 'Mã thẻ chấm công
        tdbgEmp.Columns(COLE_RefEmployeeID).Caption = rl3("Ma_NV_phu") 'Mã NV phụ
        tdbgEmp.Columns(COLE_PeriodFrom).Caption = rl3("Tu_ky") 'Từ kỳ
        tdbgEmp.Columns(COLE_PeriodTo).Caption = rl3("Den_ky") 'Đến kỳ
        tdbgEmp.Columns(COLE_OldValue).Caption = rl3("Muc_cu") 'Mức cũ
        tdbgEmp.Columns(COLE_NewValue).Caption = rl3("Muc_moi") 'Mức mới
        tdbgEmp.Columns(COLE_DifferentAmount).Caption = rl3("Chenh_lech") 'Chênh lệch
        tdbgSal.Columns(COLS_IsSelected).Caption = rl3("Chon") 'Chọn
        tdbgSal.Columns(COLS_SalaryVoucherNo).Caption = rl3("Ma") 'Mã
        tdbgSal.Columns(COLS_Description).Caption = rl3("Dien_giai") 'Diễn giải
        tdbgSal.Columns(COLS_Period).Caption = rl3("Ky") 'Kỳ
        tdbgSal.Columns(COLS_SalaryMethodName).Caption = rl3("Phuong_phap_tinh_luong") 'Phương pháp tính lương
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, "D09")

        'Load tdbcSalaryParameter
        sSQL = "-- Do ngom combo SalaryParameter" & vbCrLf
        sSQL &= "SELECT		ID AS SalaryParameter, Name" & gsLanguage & UnicodeJoin(gbUnicode) & " as SalaryParameterName, Num as Decimal" & vbCrLf
        sSQL &= "FROM	    (SELECT * FROM  D13N5555 ('D13F2091',  'SalaryParameter', '', '', '')) A"
        LoadDataSource(tdbcSalaryParameter, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBGridSal()
        If Not CheckValidPeriodFromTo(tdbcPeriodFrom, tdbcPeriodTo) Then Exit Sub

        Dim sSQL As String = SQLStoreD13P2094()
        dtGridSal = ReturnDataTable(sSQL)
        LoadDataSource(tdbgSal, dtGridSal, gbUnicode)
        ReLoadTDBGridSal()
    End Sub

    Private Sub ReLoadTDBGridSal()
        dtGridSal.AcceptChanges()
        Dim sFilter As String = ""
        If chkIsUsed.Checked Then
            sFilter = "IsSelected=True"
        End If
        dtGridSal.DefaultView.RowFilter = sFilter
        FooterTotalGrid(tdbgSal, COLS_SalaryVoucherNo)
    End Sub

    Private Sub chkIsUsed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUsed.Click
        If dtGridSal Is Nothing Then Exit Sub
        ReLoadTDBGridSal()
    End Sub

    Private Sub LoadTDBGridEmp()
        If tdbcSalaryParameter.Tag IsNot Nothing AndAlso tdbcSalaryParameter.Tag.ToString = ReturnValueC1Combo(tdbcSalaryParameter).ToString Then
            Exit Sub
        End If
        tdbcSalaryParameter.Tag = ReturnValueC1Combo(tdbcSalaryParameter).ToString

        If ReturnValueC1Combo(tdbcSalaryParameter).ToString <> "" Then
            Dim sSQL As String = SQLStoreD13P2096()
            dtGridEmp = ReturnDataTable(sSQL)
        Else
            dtGridEmp.Clear()
        End If
        LoadDataSource(tdbgEmp, dtGridEmp, gbUnicode)
        tdbgEmp_NumberFormat()
        FooterTotalGrid(tdbgEmp, COLE_EmployeeID)
        FooterSumNew(tdbgEmp, COLE_OldValue, COLE_NewValue, COLE_DifferentAmount)
    End Sub

    Private Sub tdbgEmp_NumberFormat()
        Dim sFormat As String = "N0"
        If L3Int(ReturnValueC1Combo(tdbcSalaryParameter, "Decimal").ToString) > 0 Then
            sFormat = "N" & ReturnValueC1Combo(tdbcSalaryParameter, "Decimal").ToString
        End If
        tdbgEmp.Columns(COLE_OldValue).NumberFormat = sFormat
        tdbgEmp.Columns(COLE_NewValue).NumberFormat = sFormat
        tdbgEmp.Columns(COLE_DifferentAmount).NumberFormat = sFormat
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        If c1dateBackPayDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_hoi_to"))
            c1dateBackPayDate.Focus()
            Return False
        End If
        If tdbcSalaryParameter.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Thong_so_luong"))
            tdbcSalaryParameter.Focus()
            Return False
        End If


        tdbgSal.UpdateData()
        If tdbgSal.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgSal.Focus()
            Return False
        End If

        dtGridSal.AcceptChanges()
        dr = dtGridSal.Select("IsSelected = 1")
        If dr.Length <= 0 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbgSal.Focus()
            tdbgSal.SplitIndex = 0
            tdbgSal.Col = COLS_IsSelected
            tdbgSal.Row = 0
            Return False
        End If

        tdbgEmp.UpdateData()
        If tdbgEmp.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgEmp.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub SetBackColorObligatory()
        c1dateBackPayDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcSalaryParameter.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbgSal_LockedColumns()
        tdbgSal.Splits(SPLIT0).DisplayColumns(COLS_SalaryVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgSal.Splits(SPLIT0).DisplayColumns(COLS_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgSal.Splits(SPLIT0).DisplayColumns(COLS_Period).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgSal.Splits(SPLIT0).DisplayColumns(COLS_SalaryMethodName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub btnCal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCal.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnCal.Focus()
        If btnCal.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim dr() As DataRow = Nothing
        If Not AllowSave(dr) Then Exit Sub

        btnCal.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD09T6666() & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s(dr).ToString & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s().ToString & vbCrLf)
        sSQL.Append(SQLStoreD13P2091)

        Dim sBackPay As String = ""
        Dim dt As DataTable = ReturnDataTable(sSQL.ToString)
        _bSaved = True
        If dt IsNot Nothing OrElse dt.Rows.Count > 0 Then
            btnBackPayResult.Enabled = (dt.Rows(0).Item("BackPayTransID").ToString <> "")
            D99C0008.MsgL3(dt.Rows(0).Item("Message").ToString)
        End If
        Me.Cursor = Cursors.Default

        btnClose.Enabled = True
        btnCal.Enabled = True
        btnCal.Focus()
        Me.Close()
    End Sub

    Private Sub btnBackPayResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackPayResult.Click
        Dim f As New D13F2092
        f.bFromD13F2091 = True
        f.ShowDialog()
        f.Dispose()
    End Sub

#Region "Events tdbcSalaryParameter"

    Private Sub tdbcSalaryParameter_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalaryParameter.LostFocus
        If tdbcSalaryParameter.FindStringExact(tdbcSalaryParameter.Text) = -1 Then tdbcSalaryParameter.Text = ""
    End Sub

#End Region

#Region "Events tdbcPeriodFrom"

    Private Sub tdbcPeriodFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.LostFocus
        If tdbcPeriodFrom.FindStringExact(tdbcPeriodFrom.Text) = -1 Then tdbcPeriodFrom.Text = ""
    End Sub

    Private Sub tdbcPeriodFrom_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.Validated, tdbcPeriodTo.Validated
        LoadTDBGridSal()
    End Sub


#End Region

#Region "Events tdbcPeriodTo"

    Private Sub tdbcPeriodTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.LostFocus
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then tdbcPeriodTo.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryParameter.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryParameter.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        LoadTDBGridEmp()
    End Sub

#Region "tdbgSal event"

    Private Sub tdbgSal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgSal.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbgSal.Col
            Case COLS_IsSelected
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbgSal.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COLS_IsSelected
                L3HeadClick(tdbgSal, iCol, bSelect) 'Có trong D99X0000
            Case Else
                tdbgSal.AllowSort = False
        End Select
    End Sub

    Private Sub tdbgSal_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgSal.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbgSal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgSal.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbgSal.Col)
        Select Case e.KeyCode
            Case Keys.Enter
                If tdbgSal.Row < tdbgSal.RowCount - 1 Then HotKeyEnterGrid(tdbgSal, COLS_IsSelected, e)
        End Select
    End Sub

#End Region

#Region "SQL"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2094
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 02:04:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2094() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi Phieu luong" & vbCrlf)
        sSQL &= "Exec D13P2094 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodFrom, "TranMonth")) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodFrom, "TranYear")) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodTo, "TranMonth")) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriodTo, "TranYear")) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("D13F2090") 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2096
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 02:15:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2096() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi nhan vien" & vbCrlf)
        sSQL &= "Exec D13P2096 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcSalaryParameter)) & COMMA 'SalaryParameter, varchar[250], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 09:49:35
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Delete bang tam truoc khi insert" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name)
        sSQL &= " AND FormID = 'D13F2091'"

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 09:51:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s(ByRef dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        If dr.Length > 0 Then sSQL.Append("-- Insert vao bang tam (Luoi Phieu luong)" & vbCrLf)

        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID, Key03ID, ")
            sSQL.Append("[Num01], Num02")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D13F2091") & COMMA) 'FormID, varchar[20], NOT NULL
            sSQL.Append(SQLString("SalaryVoucher") & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("SalaryVoucherID")) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("SalaryMethodID")) & COMMA) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(SQLNumber(dr(i).Item("TranMonth")) & COMMA) 'Num01, decimal, NOT NULL
            sSQL.Append(SQLNumber(dr(i).Item("TranYear"))) 'Num01, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 09:51:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        If tdbgEmp.RowCount > 0 Then sSQL.Append("-- Insert vao bang tam (Luoi Phieu luong)" & vbCrLf)

        For i As Integer = 0 To tdbgEmp.RowCount - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID, Key03ID, ")
            sSQL.Append("[Num01], Num02, Num03, Num04, Num05, Num06")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D13F2091") & COMMA) 'FormID, varchar[20], NOT NULL
            sSQL.Append(SQLString("Employee") & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbgEmp(i, COLE_EmployeeID)) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbgEmp(i, COLE_SalAdjTransID)) & COMMA) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(SQLNumber(tdbgEmp(i, COLE_TranMonthFrom)) & COMMA) 'Num01, decimal, NOT NULL
            sSQL.Append(SQLNumber(tdbgEmp(i, COLE_TranYearFrom)) & COMMA) 'Num02, decimal, NOT NULL
            sSQL.Append(SQLNumber(tdbgEmp(i, COLE_TranMonthTo)) & COMMA) 'Num03, decimal, NOT NULL
            sSQL.Append(SQLNumber(tdbgEmp(i, COLE_TranYearTo)) & COMMA) 'Num04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgEmp(i, COLE_OldValue), tdbgEmp.Columns(COLE_OldValue).NumberFormat) & COMMA) 'Num05, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgEmp(i, COLE_NewValue), tdbgEmp.Columns(COLE_NewValue).NumberFormat)) 'Num06, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2091
    '# Created User: Hoàng Nhân
    '# Created Date: 02/10/2013 02:31:57
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2091() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tinh Hoi to luong" & vbCrlf)
        sSQL &= "Exec D13P2091 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLDateSave(c1dateBackPayDate.Value) & COMMA 'BackPayDate, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcSalaryParameter)) & COMMA 'SalaryParameter, varchar[250], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString("D13F2090") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLStringUnicode(txtDescription, False) & COMMA 'Description, varchar[1000], NOT NULL
        sSQL &= SQLStringUnicode(txtDescription, True) 'DescriptionU, nvarchar[1000], NOT NULL
        Return sSQL
    End Function


#End Region

End Class