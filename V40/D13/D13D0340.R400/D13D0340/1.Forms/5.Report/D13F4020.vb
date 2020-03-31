﻿Imports System.Drawing
Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:39:42 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:39:42 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F4020
    Private Const iMaxCol As Integer = 40
    Dim dtBlockID, dtEmpGroupID, dtDepartmentID, dtTeamID, dtEmployeeID As DataTable
    Dim dtMonthYear, dtSalaryVoucherNo As DataTable
    Dim dtReportID, dtProject As DataTable
    Dim sSalaryVoucherNo As String = ""
    '    Dim dicOldValue As New Dictionary(Of C1.Win.C1List.C1Combo, Object) 'Giữ lại giá trị nếu có thay đổi mới set control phụ thuộc về ""

    Private _salaryVoucherNo As String = ""
    Public Property SalaryVoucherNo() As String
        Get
            Return _salaryVoucherNo
        End Get
        Set(ByVal Value As String)
            _salaryVoucherNo = Value
        End Set
    End Property

    Private _payrollVoucherNo As String = ""
    Public Property PayrollVoucherNo() As String
        Get
            Return _payrollVoucherNo
        End Get
        Set(ByVal Value As String)
            _payrollVoucherNo = Value
        End Set
    End Property

    Private _callingForm As String = ""
    Public Property CallingForm() As String
        Get
            Return _callingForm
        End Get
        Set(ByVal Value As String)
            _callingForm = Value
        End Set
    End Property

    Private _bIsTransferByEmail As Boolean = False
    Public Property bIsTransferByEmail() As Boolean
        Get
            Return _bIsTransferByEmail
        End Get
        Set(ByVal value As Boolean)
            If _bIsTransferByEmail = Value Then
                Return
            End If
            _bIsTransferByEmail = Value
        End Set
    End Property

    Private _sFind As String = ""
    Public Property sFind() As String
        Get
            Return _sFind
        End Get
        Set(ByVal value As String)
            If _sFind = Value Then
                Return
            End If
            _sFind = Value
        End Set
    End Property

    Private _employeeName As String = ""
    Public WriteOnly Property EmployeeName() As String
        Set(ByVal Value As String)
            _employeeName = Value
        End Set
    End Property

    Private _employeeID As String = ""
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private _departmentID As String = ""
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String = ""
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _blockID As String = ""
    Public WriteOnly Property BlockID() As String
        Set(ByVal Value As String)
            _blockID = Value
        End Set
    End Property

    Private _empGroupID As String = ""
    Public WriteOnly Property EmpGroupID() As String
        Set(ByVal Value As String)
            _empGroupID = Value
        End Set
    End Property


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F4020_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim sSQL As String = "DELETE  D91T2024 WHERE UserID = " & SQLString(gsUserID) & " AND FormID = 'D13F4020'"
        ExecuteSQL(sSQL)
    End Sub

    Private Sub D13F4020_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tdbcDivisionID.Focus()
        End If

        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
    End Sub

    Dim oFilterCheckG4 As Lemon3.Controls.FilterCheckComboG4
    Dim oFilterCheck As Lemon3.Controls.FilterCheckCombo

    Private Sub D13F4020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Loadlanguage()
        SetBackColorObligatory()
        tdbcBlockID.AutoCompletion = False
        tdbcEmpGroupID.AutoCompletion = False

        'ID 76805; Chuyển Đơn vị, PTNS sang Filter check nhiều giá trị
        oFilterCheck = New Lemon3.Controls.FilterCheckCombo
        oFilterCheck.UseFilterCheckCombo(tdbcNCodeID, tdbcProjectID, tdbcSalaryObjectID)

        oFilterCheckG4 = New Lemon3.Controls.FilterCheckComboG4
        oFilterCheckG4.CurrentDivisionID = False
        oFilterCheckG4.UseFilterCheckComboG4(tdbcBlockID, tdbcDepartmentID, tdbcTeamID, tdbcEmpGroupID, tdbcEmployeeID, tdbcSalaryVoucherNoFrom)
        LoadTDBCombo()
        tdbcDivisionID.SelectedValue = gsDivisionID

        InitForm()
        InputbyUnicode(Me, gbUnicode)

        CheckReadOnlyCboBlockID()

        'Dung them 21/10/2007
        If _callingForm = "D13F2042" Then
            LoadtdbcSalaryVoucherNo(ReturnValueC1Combo(tdbcDivisionID).ToString, sPayrollVoucherID)
            oFilterCheckG4.SetValue(tdbcSalaryVoucherNoFrom, _salaryVoucherNo)
            If _blockID <> "" AndAlso _blockID <> "%" Then oFilterCheckG4.FilterCheckBlockID(tdbcBlockID, e) : oFilterCheckG4.SetValue(tdbcBlockID, _blockID) 'tdbcBlockID.SelectedValue = _blockID
            If _departmentID <> "" AndAlso _departmentID <> "%" Then oFilterCheckG4.FilterCheckDepartmentID(tdbcDepartmentID, e, oFilterCheckG4.ReturnValueC1Combo(tdbcBlockID)) : oFilterCheckG4.SetValue(tdbcDepartmentID, _departmentID)
            If _teamID <> "" AndAlso _teamID <> "%" Then oFilterCheckG4.FilterCheckTeamID(tdbcTeamID, e, oFilterCheckG4.ReturnValueC1Combo(tdbcBlockID), oFilterCheckG4.ReturnValueC1Combo(tdbcDepartmentID)) : oFilterCheckG4.SetValue(tdbcTeamID, _teamID)
            If _empGroupID <> "" AndAlso _empGroupID <> "%" Then oFilterCheckG4.FilterCheckEmpGroupID(tdbcEmpGroupID, e, oFilterCheckG4.ReturnValueC1Combo(tdbcBlockID), oFilterCheckG4.ReturnValueC1Combo(tdbcDepartmentID), oFilterCheckG4.ReturnValueC1Combo(tdbcTeamID)) : oFilterCheckG4.SetValue(tdbcEmpGroupID, _empGroupID)
            LoadtdbcEmployeeID()
            If _employeeID <> "" Then
                oFilterCheckG4.SetValue(tdbcEmployeeID, _employeeID)
            Else
                If _employeeName <> "" Then oFilterCheckG4.SetValue(tdbcEmployeeID, _employeeName)
            End If

        End If
       
        InputDateCustomFormat(c1datePaymentDate, c1dateExamineDate)
        bLoad = True 'Chặn không cho load Nhân viên nhiều lần: Nhóm nhân viên, Kỳ
        SetResolutionForm(Me)
    End Sub

    Private Sub CheckReadOnlyCboBlockID()
        Dim dt As New DataTable
        dt = ReturnDataTable("Select IsUseBlock From D09T0000 WITH (NOLOCK) ")
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("IsUseBlock").ToString <> "1" Then ReadOnlyControl(tdbcBlockID)
        End If
        dt = Nothing
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Bao_cao_bang_luong_cong_ty_-_D13F4020") & UnicodeCaption(gbUnicode) 'BÀo cÀo b¶ng l§¥ng c¤ng ty - D13F4020
        '================================================================ 
        lblSalaryParameters.Text = rl3("Thong_so_phieu_tinh_luong") 'Thông số phiếu tính lương
        lbllblMonthYearFrom.Text = rl3("Tu") 'Từ
        lblMonthYearTo.Text = rl3("Den") 'Đến
        lblSalaryVoucherNoFrom.Text = rl3("Tinh_luong") 'rl3("Tu_phieu_tinh_luong") 'Từ phiếu tính lương
        lblDivisionID.Text = rL3("Don_vi") 'Đơn vị

        lblBlockID.Text = rl3("Khoi") 'Khối
        lblEmpGroupID.Text = rl3("Nhom_nhan_vien") 'Nhóm nhân viên

        lblDepartmentIDFrom.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamIDFrom.Text = rl3("To_nhom") 'Tổ nhóm
        lblEmployeeIDFrom.Text = rl3("Nhan_vien") 'Nhân viên
        lblteExamineDate.Text = rl3("Ngay_xet") 'Ngày xét
        '================================================================ 
        lblReportID.Text = rL3("Mau_bao_cao") 'Mẫu báo cáo

        lblTitle.Text = rl3("Tieu_de") 'Tiêu đề
        lblPaymentMethod.Text = rl3("PP_tra_luong") 'PP trả lương
        lblPeriod.Text = rl3("Ky_ke_toan") 'Kỳ kế toán
        lblBankID.Text = rl3("Ngan_hang") 'Ngân hàng
        lblCustom.Text = rl3("Dac_thu") 'Đặc thù

        lblPayrollFormID.Text = rl3("HT_huong_luong") 'HT hưởng lương
        tdbcPayrollFormID.Columns("PayrollFormID").Caption = rl3("Ma") 'Mã
        tdbcPayrollFormID.Columns("PayrollFormName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        btnPrint.Text = rl3("_In") '&In
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnTransferEmail.Text = rl3("Chuyen_bang_luong_qua__e-mail") 'Chuyển bảng lương qua &e-mail
        btnEmailContent.Text = rl3("Noi__dung_Email") 'Nội &dung Email
        btnFilter.Text = rl3("_Loc") '&Lọc
        '================================================================ 
        chkIsProject.Text = rl3("In_theo_cong_trinh") 'In theo công trình
        chkEmpWorking.Text = rl3("Nhan_vien_dang_lam_viec") 'Nhân viên đang làm việc
        chkEmpStopWork.Text = rl3("Nhan_vien_da_nghi_viec") 'Nhân viên đã nghỉ việc
        '================================================================ 
        optModeSalary1.Text = rl3("Phieu_luong") 'Phiếu lương
        optModeSalary0.Text = rl3("Bang_luong") 'Bảng lương
        optDetail.Text = rl3("Chi_tiet") 'Chi tiết
        optGeneral.Text = rl3("Tong_hop") 'Tổng hợp
        optTimeMode1.Text = rl3("Ky_ke_toan") 'Kỳ
        optTimeMode2.Text = rl3("Ngay_thanh_toan") 'Ngày thanh toán
        '================================================================ 
        grp3.Text = rl3("Thong_so_thoi_gian") 'Thông số thời gian
        grp2.Text = rl3("Thong_so_thiet_lap") 'Thông số thiết lập
        '================================================================ 
        tdbcBankID.Columns("BankID").Caption = rL3("Ma") 'Mã
        tdbcBankID.Columns("BankName").Caption = rl3("Ten") 'Tên

        tdbcEmployeeID.Columns("EmployeeID").Caption = rL3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcEmpGroupID.Columns("EmpGroupID").Caption = rl3("Ma") 'Mã
        tdbcEmpGroupID.Columns("EmpGroupName").Caption = rl3("Ten") 'Tên

        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ten") 'Tênen") 'Tên

        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        tdbcReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcReportID.Columns("ReportName").Caption = rl3("Ten") 'Tên
        tdbcReportID.Columns("ReportTitle").Caption = rL3("Tieu_de") 'Tiêu đề
        '================================================================ 
        lblProjectID.Text = rL3("Cong_trinh") 'Dự án
        lblNCodeTypeID.Text = rL3("Ma_PTNS") 'Mã PTNS
        '================================================================ 
        tdbcProjectID.Columns("ProjectID").Caption = rL3("Ma") 'Mã
        tdbcProjectID.Columns("ProjectName").Caption = rL3("Ten") 'Tên
        tdbcNCodeTypeID.Columns("NCodeTypeID").Caption = rL3("Ma") 'Mã
        tdbcNCodeTypeID.Columns("NCodeTypeName").Caption = rL3("Ten") 'Tên
        tdbcNCodeID.Columns("NCodeID").Caption = rL3("Ma") 'Mã
        tdbcNCodeID.Columns("NCodeName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        lblSalaryObjectID.Text = rL3("Doi_tuong_tinh_luong") 'Đối tượng tính lương
        '================================================================ 
        '================================================================ 
        tdbcSalaryObjectID.Columns("SalaryObjectID").Caption = rL3("Ma") 'Mã
        tdbcSalaryObjectID.Columns("SalaryObjectName").Caption = rL3("Ten") 'Tên


    End Sub

    Private Sub SetBackColorObligatory()
        tdbcReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcEmpGroupID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPaymentMethod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBankID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMonthYearFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMonthYearTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPayrollFormID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcSalaryVoucherNoFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcSalaryVoucherNoTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub InitForm()
        optModeSalary0_Click(Nothing, Nothing)
        c1dateExamineDate.Value = Date.Today
        ' tdbcDivisionID.SelectedValue = gsDivisionID
        '  tdbcDepartmentID.SelectedIndex = 0
        optMonthYearFrom.Checked = True
        c1datePaymentDate.Value = Date.Today
        EnabledControl(True)

        If bIsTransferByEmail Then
            VisibleControlForTransferByEmail()

            'btnTransferEmail.Left = 313
            'btnTransferEmail.Top = 529
            btnTransferEmail.Visible = True
            btnPrint.Visible = False

        Else
            btnTransferEmail.Visible = False
            btnPrint.Visible = True
        End If
        tdbcBankID.SelectedIndex = 0
        oFilterCheck.SetValue(tdbcProjectID, "")
    End Sub

    Private Sub VisibleControlForTransferByEmail()
        'Chỉ chạy 1 lần duy nhất
        optModeSalary0.Checked = True
        optModeSalary0.Visible = False
        optModeSalary1.Visible = False

        optGeneral.Checked = True
        grp10.Visible = False

    End Sub
    Private Sub LoadTDBComboNCodeID(ByVal type As String)
        Dim sSQL As String = ""
        'Load tdbcNCodeID
        sSQL = "SELECT NCodeID, DescriptionU as NCodeName, TypeID as NCodeTypeID " & vbCrLf
        sSQL &= "FROM D09T1010  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0 and TypeID =" & SQLString(type) & vbCrLf
        sSQL &= "ORDER BY TypeID, DescriptionU" & vbCrLf

        LoadDataSource(tdbcNCodeID, sSQL, gbUnicode)

    End Sub

    Private Sub LoadTDBCombo()
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        Dim sSQL As String = ""

        'Load tdbcReportID
        sSQL = "Select T1.ReportCode as ReportID, T1.ReportName" & sUnicode & " as ReportName, T1.ReportTitle" & sUnicode & " as ReportTitle, " & _
                "T1.ReportCatelogy, T1.ModeSalary,T1.CustomReportID, " & _
                "T2.Title" & sUnicode & " as CustomReportName, T2.ReportTypeID, CASE WHEN Isnull(T2.FileExt, '') <> '' THEN T2.FileExt ELSE 'rpt' END AS FileExt " & vbCrLf
        sSQL &= "From D13T4000 T1 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Left join D89T1000 T2  WITH (NOLOCK) On T2.ReportID = T1.CustomReportID And T2.ModuleID = '13' And ReportTypeID = " & SQLString(Me.Name) & vbCrLf
        sSQL &= "Where T1.Disabled = 0 " & vbCrLf
        sSQL &= "And (T1.DAGroupID = '' OR T1.DAGroupID In" & vbCrLf
        sSQL &= "(Select DAGroupID From LEMONSYS.DBO.D00V0080" & vbCrLf
        sSQL &= "Where UserID = " & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "Or " & SQLString(gsUserID) & " = 'LEMONADMIN')" & vbCrLf
        sSQL &= "Order By ReportName " & vbCrLf
        dtReportID = ReturnDataTable(sSQL)

        'Load tdbcMonthYear
        dtMonthYear = LoadTablePeriodReport("D09")

        dtSalaryVoucherNo = ReturnDataTable(SQLStoreD13P4516(0))
        'them 15/02/2008
        'comboPP tính lương
        If geLanguage = EnumLanguage.Vietnamese Then
            sSQL = " SELECT '%' as Code, " & sLanguage & " as Description " & vbCrLf
            sSQL &= " Union All SELECT 'C',N'" & IIf(gbUnicode, "Tiền mặt", "Tieàn maët").ToString & "' " & vbCrLf
            sSQL &= " Union All SELECT 'B',N'" & IIf(gbUnicode, "Chuyển khoản", "Chuyeån khoaûn").ToString & "' "
        Else
            sSQL = " SELECT '%' as Code, 'All' as Description " & vbCrLf
            sSQL &= " Union All SELECT 'C','Cash' " & vbCrLf
            sSQL &= " Union All SELECT 'B','Deposit' "
        End If
        LoadDataSource(tdbcPaymentMethod, sSQL, gbUnicode)

        'Load tdbcBankID
        sSQL = "SELECT '%' as BankID, " & sLanguage & " as BankName, 0 As DisplayOrder" & vbCrLf
        sSQL &= "Union All" & vbCrLf
        sSQL &= "SELECT ObjectID as BankID, ObjectName" & sUnicode & " as BankName, 1 As DisplayOrder" & vbCrLf
        sSQL &= "FROM Object WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled =0 AND ObjectTypeID = 'NH'" & vbCrLf
        sSQL &= " Order By DisplayOrder, BankID"
        LoadDataSource(tdbcBankID, sSQL, gbUnicode)

        'Load tdbcDivisionID
        LoadCboDivisionIDReportD09(tdbcDivisionID, "D09", gbUnicode)
        sSQL = "SELECT	'%' As PayrollFormID, " & AllName & " As PayrollFormName, 0 As DisplayOrder UNION "
        sSQL &= " SELECT LookupID As PayrollFormID, Description" & UnicodeJoin(gbUnicode) & " As PayrollFormName, DisplayOrder FROM	D91T0320 "
        sSQL &= " WHERE LookupType = 'D09_PayrollForm' AND Disabled = 0 AND (DAGroupID = '' OR DAGroupID  IN (SELECT DAGroupID "
        sSQL &= " FROM Lemonsys.dbo.D00V0080 WHERE 	UserID= " & SQLString(gsUserID) & ") OR  'LEMONADMIN' = " & SQLString(gsUserID) & ") ORDER BY 	DisplayOrder, PayrollFormID"
        LoadDataSource(tdbcPayrollFormID, sSQL, gbUnicode)

        Using proj As Lemon3.Data.LoadData.LoadDataG4 = New Lemon3.Data.LoadData.LoadDataG4
            dtProject = proj.ReturnTableProjectByG4(Me.Name)
            'Dim dr() As DataRow = dtProject.Select("ProjectID = '%'")
            'If dr.Length > 0 Then
            '    dtProject.Rows.Remove(dr(0))
            'End If
            LoadDataSource(tdbcProjectID, dtProject, gbUnicode)
        End Using

        'Load tdbcNCodeTypeID
        sSQL = "SELECT TypeID as NCodeTypeID, Description" & UnicodeJoin(gbUnicode) & " as NCodeTypeName " & vbCrLf
        sSQL &= "FROM D09T0010  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY TypeID" & vbCrLf

        LoadDataSource(tdbcNCodeTypeID, sSQL, gbUnicode)
        LoadTDBComboNCodeID(ReturnValueC1Combo(tdbcNCodeTypeID))

        sSQL = " SELECT '%' as SalaryObjectID, " & AllName & " as SalaryObjectName, 0 As DisplayOrder" & vbCrLf
        sSQL &= " Union All" & vbCrLf
        sSQL &= " Select SalaryObjectID, SalaryObjectNameU as SalaryObjectName, 1 As DisplayOrder " & vbCrLf
        sSQL &= " From D13T1020 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where Disabled = 0 " & vbCrLf
        sSQL &= " Order by DisplayOrder"
        LoadDataSource(tdbcSalaryObjectID, sSQL, gbUnicode)
        oFilterCheck.SetValue(tdbcSalaryObjectID, "%")
    End Sub


#Region "Events tdbcNCodeTypeID load tdbcNCodeID"

    Private Sub tdbcNCodeTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNCodeTypeID.SelectedValueChanged
        If tdbcNCodeTypeID.SelectedValue Is Nothing OrElse tdbcNCodeTypeID.Text = "" Then
            LoadTDBComboNCodeID("-1")
            oFilterCheck.SetValue(tdbcNCodeID, "")
            Exit Sub
        End If
        LoadTDBComboNCodeID(tdbcNCodeTypeID.SelectedValue.ToString)
        'oFilterCheck.SetValue(tdbcNCodeID, "")
        oFilterCheck.SetValueFirst(tdbcNCodeID)
        'tdbcNCodeID.SelectedIndex = 0 ' Không biết gán sao ^^
    End Sub

    Private Sub tdbcNCodeTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNCodeTypeID.LostFocus
        If tdbcNCodeTypeID.FindStringExact(tdbcNCodeTypeID.Text) = -1 Then
            tdbcNCodeTypeID.Text = ""
            oFilterCheck.SetValue(tdbcNCodeID, "")
            Exit Sub
        End If

    End Sub

    Private Sub tdbcNCodeID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNCodeID.Validated
        oFilterCheck.FilterCheckCombo(tdbcNCodeID, e)
    End Sub

#End Region
    Private Sub LoadtdbcReportID(ByVal ID As Integer)
        LoadDataSource(tdbcReportID, ReturnTableFilter(dtReportID, "ModeSalary = " & ID), gbUnicode)
    End Sub

    Private Sub LoadtdbcSalaryVoucherNo(ByVal sDivisionID As String, ByVal sPayrollVoucherID As String)
        'Dim dtTemp As DataTable = ReturnTableFilter(dtSalaryVoucherNo, GetFilterSalaryVoucherNo(sDivisionID, iTranMonth, iTranYear), True)
        Dim dtTemp As DataTable = ReturnTableFilter(dtSalaryVoucherNo, GetFilterSalaryVoucherNo(sDivisionID), True)

        oFilterCheckG4.LoadDataSource(tdbcSalaryVoucherNoFrom, dtTemp)
    End Sub

    Private Function GetFilterSalaryVoucherNo(ByVal sDivisionID As String) As String
        Dim sFilterSalaryVoucherNo As String = "" ' Luu lại giá trị filter combo để truyền khi nhấn F2
        Dim iTranMonthFr, iTranMonthTo, iTranyearFr, iTranYearTo As Integer

        iTranMonthFr = L3Int(ReturnValueC1Combo(tdbcMonthYearFrom, "TranMonth"))
        iTranMonthTo = L3Int(ReturnValueC1Combo(tdbcMonthYearTo, "TranMonth"))

        iTranyearFr = L3Int(ReturnValueC1Combo(tdbcMonthYearFrom, "TranYear"))
        iTranYearTo = L3Int(ReturnValueC1Combo(tdbcMonthYearTo, "TranYear"))

        'Dim sWherePeriod As String = "TranMonth >= " & iTranMonthFr & " And TranMonth <= " & iTranMonthTo & " And TranYear >= " & iTranyearFr & " And TranYear <= " & iTranYearTo
        Dim sWherePeriod As String = "TranMonth  + TranYear * 12 >= " & iTranMonthFr + iTranyearFr * 12 & " And TranMonth + TranYear * 12 <= " & iTranMonthTo + iTranYearTo * 12

        If sDivisionID.Trim = "%" Then
            sFilterSalaryVoucherNo = " DivisionID ='%' or ( " & sWherePeriod & ")"
        Else
            sFilterSalaryVoucherNo = " DivisionID ='%' Or DivisionID = " & SQLString(sDivisionID) & " And " & sWherePeriod
        End If
        Return sFilterSalaryVoucherNo
    End Function

#Region "Events tdbcReportID with txtReportName"
    Private Sub tdbcReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.SelectedValueChanged
        If tdbcReportID.SelectedValue Is Nothing Then
            tdbcReportID.Text = ""
            txtCustomReportID.Text = ""
            txtCustomName.Text = ""
            txtFileExt.Text = ""
        Else
            txtTitle.Text = tdbcReportID.Columns("ReportTitle").Value.ToString
            txtCustomReportID.Text = tdbcReportID.Columns("CustomReportID").Value.ToString
            txtCustomName.Text = tdbcReportID.Columns("CustomReportName").Value.ToString
            If txtCustomReportID.Text.Trim <> "" Then
                txtFileExt.Text = "." & ReturnValueC1Combo(tdbcReportID, "FileExt")
            Else
                txtFileExt.Text = ""
            End If


        End If
    End Sub

    Private Sub tdbcReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.LostFocus
        If tdbcReportID.FindStringExact(tdbcReportID.Text) = -1 Then
            tdbcReportID.Text = ""
            txtCustomReportID.Text = ""
            txtCustomName.Text = ""
            txtFileExt.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcDivisionID with txtDivisionName"


    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
            'txtDivisionName.Text = ""
        End If
    End Sub
    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If Not (tdbcDivisionID.Tag Is Nothing OrElse tdbcDivisionID.Tag.ToString = "") Then
            tdbcDivisionID.Tag = ""
            Exit Sub
        End If
        'Update 09/04/2012: incident 47718 Bổ sung thêm cbo Khối, Nhóm NViên
        '  If dtBlockID Is Nothing Then dtBlockID = ReturnTableBlockID(, , gbUnicode)
        oFilterCheckG4.DivisionID = ReturnValueC1Combo(tdbcDivisionID)
        '   oFilterCheck.UseFilterCheckBlockID(tdbcBlockID)
        If tdbcDivisionID.SelectedValue Is Nothing Then
            LoadCboPeriodReport(tdbcMonthYearFrom, tdbcMonthYearTo, dtMonthYear, "-1")
            Exit Sub
        End If
        LoadCboPeriodReport(tdbcMonthYearFrom, tdbcMonthYearTo, dtMonthYear, ComboValue(tdbcDivisionID))

        tdbcMonthYearFrom.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        tdbcMonthYearTo.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        If tdbcMonthYearFrom.Text = "" And tdbcMonthYearTo.Text = "" Then
            tdbcMonthYearFrom.Text = tdbcMonthYearFrom.Columns("Period").Text
            tdbcMonthYearTo.Text = tdbcMonthYearTo.Columns("Period").Text
        End If
        oFilterCheckG4.SetValue(tdbcBlockID, "")
        oFilterCheckG4.SetValue(tdbcDepartmentID, "")
        oFilterCheckG4.SetValue(tdbcTeamID, "")
        oFilterCheckG4.SetValue(tdbcEmpGroupID, "")
        oFilterCheckG4.SetValue(tdbcEmployeeID, "")
        sPayrollVoucherID = GetPayrollVoucherIDD13()
        oFilterCheckG4.SetValue(tdbcSalaryVoucherNoFrom, "")

    End Sub
#End Region

#Region "Events tdbcBlockID load tdbcDepartmentIDFrom"
    '
    '    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
    '        '        If Not (tdbcBlockID.Tag Is Nothing OrElse tdbcBlockID.Tag.ToString = "") Then
    '        '            tdbcBlockID.Tag = ""
    '        '            Exit Sub
    '        '        End If
    '
    '        If tdbcBlockID.SelectedValue Is Nothing Or tdbcDivisionID.SelectedValue Is Nothing Then
    '            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", "-1", gbUnicode)
    '        Else
    '            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, tdbcDivisionID.SelectedValue.ToString, gbUnicode)
    '        End If
    '        tdbcDepartmentID.SelectedValue = "%"
    '
    '    End Sub

    '   Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
    '        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
    '            tdbcBlockID.Text = ""
    '        End If
    '  End Sub

#End Region

#Region "Events tdbcDepartmentIDFrom"

    '    Private Sub tdbcDepartmentIDFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
    '        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    '    End Sub

    Dim sDepartmentID As String

    Private Sub tdbcDepartmentIDFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDepartmentID.KeyDown
        'If e.KeyCode = Keys.F2 Then
        '    Dim sResult As String = ""
        '    sDepartmentID = ""
        '    Dim sSQL As String = "Select Cast(0 as bit) As Selected, DepartmentID as SelectionID, DepartmentName" & UnicodeJoin(gbUnicode) & " as SelectionName" & vbCrLf
        '    sSQL &= " From D91T0012 WITH (NOLOCK) "
        '    '  sSQL &= " Where Disabled = 0 And DivisionID Like " & SQLString(tdbcDivisionID.SelectedValue.ToString) & " And BlockID Like " & SQLString(ReturnValueC1Combo(tdbcBlockID)) & " Order by DepartmentID"
        '    sSQL &= " Where Disabled = 0 And DivisionID Like " & SQLString(tdbcDivisionID.SelectedValue.ToString) & " And BlockID IN " & SQLString(oFilterCheck.GetValueServer(tdbcBlockID)) & " Order by DepartmentID"
        '    '            Dim f As New D91F6020
        '    '            Dim sSQL As String = ""
        '    '            With f
        '    '                'Mode chọn: 0 là theo mode In nhiều giá trị, 1: in cả 2 mode
        '    '                .ModeSelect = "0"
        '    '                sSQL = "Select Cast(0 as bit) As Selected, DepartmentID as SelectionID, DepartmentName" & UnicodeJoin(gbUnicode) & " as SelectionName" & vbCrLf
        '    '                sSQL &= " From D91T0012 WITH (NOLOCK) "
        '    '                sSQL &= " Where Disabled = 0 And DivisionID Like " & SQLString(tdbcDivisionID.SelectedValue.ToString) & " Order by DepartmentID"
        '    '                .SQLSelection = sSQL 'Theo TL phân tích 
        '    '                .ShowDialog()
        '    '                sResult = .OutPut01
        '    '                .Dispose()
        '    '            End With
        '    Dim arrPro() As StructureProperties = Nothing
        '    SetProperties(arrPro, "ModeSelect", L3Byte(0))
        '    SetProperties(arrPro, "SQLSelection", sSQL)
        '    Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6020", arrPro)
        '    sResult = GetProperties(frm, "ReturnField").ToString
        '    'Load dữ liệu
        '    '  tdbg.Columns(COL_SQLFind).Value = sKey

        '    If sResult <> "" Then
        '        'Có trả về giá trị. Ví dụ nhấn F2 tại tiêu thức 1
        '        If sResult.Substring(0, 1) <> "(" Then
        '            'Lấy theo giá trị Từ đến:
        '            '+ Gán lại giá trị cho 2 combo tiêu thức từ đến
        '            '+ Chuỗi tiêu thức gán bằng rỗng, sSQLOutput1= ""  
        '            tdbcDepartmentID.SelectedValue = "%"
        '        Else
        '            'Lấy theo tập hợp:
        '            '+ Gán giá trị mặc định cho 2 combo tiêu thức từ đến
        '            '+ Chuỗi tiêu thức sSQLOutput1= sResult
        '            tdbcDepartmentID.SelectedValue = "%"
        '        End If

        '        sResult = sResult.Substring(1, sResult.Length - 1)
        '        sResult = sResult.Substring(0, sResult.Length - 1)

        '        Dim xArray() As String = Microsoft.VisualBasic.Split(sResult, ",")
        '        For i As Integer = 0 To xArray.Length - 1
        '            xArray(i) = xArray(i).Trim
        '        Next i
        '        For i As Integer = 0 To xArray.Length - 1
        '            If i < xArray.Length - 1 Then
        '                sDepartmentID &= xArray(i) & "','"
        '            Else
        '                sDepartmentID &= xArray(i)
        '            End If
        '        Next
        '    End If

        'End If
    End Sub

    'Private Sub tdbcDepartmentIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
    '    If Not (tdbcDepartmentID.Tag Is Nothing OrElse tdbcDepartmentID.Tag.ToString = "") Then
    '        tdbcDepartmentID.Tag = ""
    '        Exit Sub
    '    End If

    '    If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing AndAlso Not tdbcDivisionID.SelectedValue Is Nothing Then
    '        LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, tdbcDivisionID.SelectedValue.ToString, gbUnicode)
    '    Else
    '        LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
    '    End If
    '    tdbcTeamID.SelectedValue = "%"

    '    '
    '    '        If tdbcDepartmentID.SelectedValue Is Nothing Then
    '    '            'LoadtdbcTeamID("-1", "-1")
    '    '            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
    '    '            tdbcTeamID.SelectedValue = "%"
    '    '            Exit Sub
    '    '        End If
    '    '        'LoadtdbcTeamID(tdbcDivisionID.SelectedValue.ToString, tdbcDepartmentIDFrom.SelectedValue.ToString)
    '    '        LoadtdbcTeamID(tdbcTeamID, dtTeamID, "%", ComboValue(tdbcDepartmentID), ComboValue(tdbcDivisionID), gbUnicode)
    '    '        tdbcTeamID.SelectedValue = "%"
    '    '        tdbcEmployeeID.SelectedValue = "%"
    'End Sub
#End Region

#Region "Events tdbcSalaryObjectID"

    Private Sub tdbcSalaryObjectID_Validated(sender As Object, e As EventArgs) Handles tdbcSalaryObjectID.Validated
        oFilterCheck.FilterCheckCombo(tdbcSalaryObjectID, e)
    End Sub

#End Region


    Private Sub LoadtdbcEmployeeID()
        '  Dim sOldEmployeeID As String = oFilterCheck.ReturnValueC1Combo(tdbcEmployeeID)
        LoadDataSource(tdbcEmployeeID, SQLStoreD09P6666, gbUnicode)
        '        If sOldEmployeeID = "" Then
        '            tdbcEmployeeID.SelectedValue = "%"
        '        Else
        '            oFilterCheck.SetValue(tdbcEmployeeID, sOldEmployeeID)
        '        End If
    End Sub

#Region "Events tdbcTeamIDFrom load tdbcTeamIDTo"

    '    Private Sub tdbcTeamIDFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
    '        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.SelectedValue = ""
    '    End Sub

    '    Private Sub tdbcTeamIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
    '        If Not tdbcTeamID.SelectedValue Is Nothing AndAlso Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
    '            ' LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, tdbcTeamID.SelectedValue.ToString, "%", gbUnicode)
    '            LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, tdbcTeamID.SelectedValue.ToString, gbUnicode)
    '        Else
    '            '  LoadtdbcEmployeeID(tdbcEmployeeID, dtEmployeeID, "-1", "-1", "-1", "-1", gbUnicode)
    '            LoadtdbcEmpGroupID(tdbcEmpGroupID, dtEmpGroupID, "-1", "-1", "-1", gbUnicode)
    '        End If
    '        tdbcEmpGroupID.SelectedValue = "%"
    '    End Sub

#End Region

#Region "Events tdbcEmpGroupID"

    '    Private Sub tdbcEmpGroupID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmpGroupID.LostFocus
    '        If tdbcEmpGroupID.FindStringExact(tdbcEmpGroupID.Text) = -1 Then tdbcEmpGroupID.SelectedValue = ""
    '    End Sub

    '    Private Sub tdbcEmpGroupID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmpGroupID.SelectedValueChanged
    '        LoadtdbcEmployeeID()
    '    End Sub

#End Region

#Region "Events tdbcBankID with txtBankName"

    Private Sub tdbcBankID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBankID.LostFocus
        If tdbcBankID.FindStringExact(tdbcBankID.Text) = -1 Then
            tdbcBankID.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcMonthYearTo"
    Private Sub tdbcMonthYearTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMonthYearTo.LostFocus
        If tdbcMonthYearTo.FindStringExact(tdbcMonthYearTo.Text) = -1 Then tdbcMonthYearTo.Text = ""
    End Sub

    Private Sub tdbcMonthYearTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMonthYearTo.SelectedValueChanged
        If Not (tdbcMonthYearTo.Tag Is Nothing OrElse tdbcMonthYearTo.Tag.ToString = "") Then
            tdbcMonthYearTo.Tag = ""
            Exit Sub
        End If
        If tdbcMonthYearTo.SelectedValue Is Nothing Then
            EnabledControl(False)
            Exit Sub
        End If
        If IsDBNull(tdbcMonthYearTo.Columns(2).Value) Then
            tdbcMonthYearTo.Columns(2).Value = 0
        End If
        If IsDBNull(tdbcMonthYearTo.Columns(3).Value) Then
            tdbcMonthYearTo.Columns(3).Value = 0
        End If
        sPayrollVoucherID = GetPayrollVoucherIDD13()
        EnabledControl(CheckPeriod())
        oFilterCheckG4.SetValue(tdbcSalaryVoucherNoFrom, "")
    End Sub


#End Region

    '   Dim bLoadPayrollVoucherID As Boolean = False ' Cờ này bật khi Load form xong, chặn load nhiều lần 
    Dim sPayrollVoucherID As String = "" ' Lưu giá trị PayrollVoucherID khi chọn lại kỳ, Đơn vị
    ' 20/11/2013 id 61332 - BỎ COMBO HỒ SƠ LƯƠNG THÁNG
    Private Function GetPayrollVoucherIDD13() As String
        If ReturnValueC1Combo(tdbcDivisionID).ToString = "%" Then
            Return "%"
        End If

        Dim sSQL As String = ""
        If optGeneral.Checked Then
            Return GetPayRollVoucherID(ReturnValueC1Combo(tdbcDivisionID).ToString, L3Int(ReturnValueC1Combo(tdbcMonthYearFrom, "TranMonth")), L3Int(ReturnValueC1Combo(tdbcMonthYearFrom, "TranYear")))
        Else ' chi tiết
            If tdbcMonthYearFrom.Text = tdbcMonthYearTo.Text Then
                Return GetPayRollVoucherID(ReturnValueC1Combo(tdbcDivisionID).ToString, L3Int(ReturnValueC1Combo(tdbcMonthYearFrom, "TranMonth")), L3Int(ReturnValueC1Combo(tdbcMonthYearFrom, "TranYear")))
            Else 'Nếu Kỳ (từ) <>= Kỳ (đến): @PayRollVoucherID = ‘%’
                Return "%"
            End If
        End If
    End Function


    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryVoucherNoFrom.Close, tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcEmpGroupID.Close, tdbcEmployeeID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub


#Region "Events tdbcMonthYearFrom load tdbcMonthYearTo"

    Private Sub tdbcMonthYearFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMonthYearFrom.LostFocus
        If tdbcMonthYearFrom.FindStringExact(tdbcMonthYearFrom.Text) = -1 Then tdbcMonthYearFrom.Text = ""
    End Sub

    Dim bLoad As Boolean = False
    Private Sub tdbcMonthYearFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMonthYearFrom.SelectedValueChanged
        If Not (tdbcMonthYearFrom.Tag Is Nothing OrElse tdbcMonthYearFrom.Tag.ToString = "") Then
            tdbcMonthYearFrom.Tag = ""
            Exit Sub
        End If
        If tdbcMonthYearFrom.SelectedValue Is Nothing Then
            'LoadtdbcPayrollVoucherNo(tdbcDivisionID.SelectedValue.ToString, giTranMonth, giTranYear)
            EnabledControl(False)
            Exit Sub
        End If
        If IsDBNull(tdbcMonthYearFrom.Columns("TranMonth").Value) Then
            tdbcMonthYearFrom.Columns("TranMonth").Value = 0
        End If
        If IsDBNull(tdbcMonthYearFrom.Columns("TranYear").Value) Then
            tdbcMonthYearFrom.Columns("TranYear").Value = 0
        End If

        If optModeSalary0.Checked And optGeneral.Checked Then
            tdbcMonthYearTo.Text = tdbcMonthYearFrom.Text
            bLoad = False 'Chặn khi tdbcMonthYearTo.Text đã gắn rồi
        End If
        EnabledControl(CheckPeriod())
        If bLoad Then
            '  LoadtdbcEmployeeID() ' 18/9/2014 id 68476
            sPayrollVoucherID = GetPayrollVoucherIDD13()
        End If
        bLoad = True
        oFilterCheckG4.SetValue(tdbcSalaryVoucherNoFrom, "")
    End Sub
#End Region
    Private Function CheckPeriod() As Boolean
        If tdbcMonthYearFrom.Text = "" OrElse tdbcMonthYearTo.Text = "" Then Return False
        If L3Int(ReturnValueC1Combo(tdbcMonthYearFrom, "TranYear")) > L3Int(ReturnValueC1Combo(tdbcMonthYearTo, "TranYear")) Then
            Return False
        ElseIf L3Int(ReturnValueC1Combo(tdbcMonthYearFrom, "TranYear")) = L3Int(ReturnValueC1Combo(tdbcMonthYearTo, "TranYear")) Then
            If L3Int(ReturnValueC1Combo(tdbcMonthYearFrom, "TranMonth")) > L3Int(ReturnValueC1Combo(tdbcMonthYearTo, "TranMonth")) Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

#Region "Events tdbcPaymentMethod with txtPaymentMethodName"

    Private Sub tdbcPaymentMethod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPaymentMethod.LostFocus
        If tdbcPaymentMethod.FindStringExact(tdbcPaymentMethod.Text) = -1 Then
            tdbcPaymentMethod.Text = ""
        End If
    End Sub

    Private Sub tdbcPaymentMethod_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPaymentMethod.SelectedValueChanged
        If ComboValue(tdbcPaymentMethod) = "C" Then
            'tdbcBankID.Enabled = False
            ReadOnlyControl(tdbcBankID)
        Else
            'tdbcBankID.Enabled = True
            UnReadOnlyControl(tdbcBankID, True)
        End If
    End Sub

#End Region

    '    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDepartmentID.BeforeOpen, tdbcEmployeeID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcPaymentMethod.BeforeOpen, tdbcBankID.BeforeOpen, tdbcBlockID.BeforeOpen, tdbcEmpGroupID.BeforeOpen
    '        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
    '            e.Cancel = True
    '        End If
    '    End Sub


    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPaymentMethod.Close, tdbcBankID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPaymentMethod.KeyUp, tdbcBankID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPaymentMethod.Validated, tdbcBankID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub


    Private Sub EnabledControl(ByVal bFlag As Boolean)
        If bFlag Then
            ReadOnlyControl(False, tdbcSalaryVoucherNoFrom)
            '  UnReadOnlyControl(tdbcPayrollVoucherNo)
        Else
            ReadOnlyControl(tdbcSalaryVoucherNoFrom)
            oFilterCheckG4.SetValue(tdbcSalaryVoucherNoFrom, "")
        End If


    End Sub

    Private Sub ClearText()
        '        tdbcSalaryVoucherNoFrom.SelectedValue = ""
        '        tdbcSalaryVoucherNoTo.SelectedValue = ""
        oFilterCheckG4.SetValue(tdbcSalaryVoucherNoFrom, "")
    End Sub



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4010
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 13/03/2007 05:09:27
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 17/03/2015 10:57:27
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4010(Optional ByVal IsTransferEmail As Byte = 0) As String
        Dim sEmployeeID As String = oFilterCheckG4.GetValueServer(tdbcEmployeeID)
        Dim sSQL As String = ""
        sSQL = "-- Bao cao thiet lap bang luong" & vbCrLf
        sSQL &= "Exec D13P4010 "
        sSQL &= SQLDateSave(c1dateExamineDate.Value) & COMMA 'ReportDate, datetime, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcDepartmentID)) & COMMA 'FromDepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcDepartmentID)) & COMMA 'ToDepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcTeamID)) & COMMA 'FromTeamID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcTeamID)) & COMMA 'ToTeamID, varchar[20], NOT NULL
        sSQL &= SQLString(sEmployeeID) & COMMA 'FromEmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(sEmployeeID) & COMMA 'ToEmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcReportID.SelectedValue) & COMMA 'ReportCode, varchar[20], NOT NULL

        sSQL &= SQLNumber(tdbcMonthYearFrom.Columns("TranMonth").Value) & COMMA 'FromTranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearTo.Columns("TranMonth").Value) & COMMA 'ToTranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearFrom.Columns("TranYear").Value) & COMMA 'FromTranYear, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearTo.Columns("TranYear").Value) & COMMA 'ToTranYear, int, NOT NULL

        If tdbcMonthYearFrom.Text = tdbcMonthYearTo.Text Then
            sSQL &= SQLString(sPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString("%") & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        End If
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcSalaryVoucherNoFrom)) & COMMA 'tdbcSalaryVoucherNoFrom, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'tdbcSalaryVoucherNoTo, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcPaymentMethod)) & COMMA 'TdbcPaymentMethod
        sSQL &= SQLNumber(0) & COMMA 'IsRefEmployeeID, tinyint, NOT NULL
        If optDetail.Checked Then
            sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        Else
            sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        End If
        sSQL &= SQLString(ComboValue(tdbcBankID)) & COMMA 'BankID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        If tdbcSalaryVoucherNoFrom.Text = "" And sSalaryVoucherNo <> "" Then ' 14/3/2014 id 63983 
            ' If tdbcSalaryVoucherNoFrom.Text = "" And sSalaryVoucherNo <> "" Then
            sSQL &= SQLString("AND D600.SalaryVoucherNo In (" & sSalaryVoucherNo & ")") & COMMA 'strSalaryVoucherNo, varchar[8000], NOT NULL
        Else
            sSQL &= SQLString("") & COMMA 'strSalaryVoucherNo, varchar[8000], NOT NULL
        End If
        sSQL &= SQLNumber(chkIsProject.Checked) & COMMA 'IsProject, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= IIf(sDepartmentID = "", "''", sDepartmentID).ToString() & COMMA
        sSQL &= SQLNumber(chkEmpWorking.Checked) & COMMA 'EmpWorking, tinyint, NOT NULL
        sSQL &= SQLNumber(chkEmpStopWork.Checked) & COMMA 'EmpStopWork, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(IIf(optTimeMode1.Checked, 1, 2)) & COMMA 'TimeMode, tinyint, NOT NULL
        sSQL &= SQLDateSave(c1datePaymentDate.Text) & COMMA 'PaymentDate, datetime, NOT NULL
        sSQL &= SQLString("D13F4020") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= "N" & SQLString(sFind) & COMMA  'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcEmpGroupID)) & COMMA 'EmpGroupID, varchar[20], NOT NULL

        'Them ngay 13/11/2012 theo incident 51373 của Bích Thuận bởi Văn Vinh
        sSQL &= SQLString(ComboValue(tdbcPayrollFormID)) & COMMA 'PayrollFormID, varchar[50], NOT NULL
        sSQL &= SQLNumber(IsTransferEmail) & COMMA 'IsTransferEmail, tinyint, NOT NULL
        sSQL &= SQLString(gsCompanyID) & COMMA 'CompanyID,varchar[20], NOT NULL

        'Them combo du an,PTNS 03/08/2015
        sSQL &= SQLString(oFilterCheck.GetValueServer(tdbcProjectID)) & COMMA 'ProjectID, varchar[50], NOT NULL
        sSQL &= SQLString(tdbcNCodeTypeID.SelectedValue) & COMMA 'NCodeTypeID, varchar[50], NOT NULL
        sSQL &= SQLString(oFilterCheck.GetValueServer(tdbcNCodeID)) & COMMA 'NcodeID, varchar[50], NOT NULL
        '98380  03.07.2017
        sSQL &= SQLString(oFilterCheck.GetValueServer(tdbcSalaryObjectID)) 'SalaryObjectID, varchar[50], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4012
    '# Created User: DUCTRONG
    '# Created Date: 19/05/2009 02:47:18
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4012(ByVal sEmployeeIDFrom As String, ByVal sEmployeeIDTo As String) As String
        Dim sSQL As String = ""
        sSQL = "-- In bao bao bang luong theo Option Phieu luong" & vbCrLf
        sSQL &= "Exec D13P4012 "
        sSQL &= SQLDateSave(c1dateExamineDate.Value) & COMMA 'ReportDate, datetime, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcDepartmentID)) & COMMA 'FromDepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcDepartmentID)) & COMMA 'ToDepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcTeamID)) & COMMA 'FromTeamID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcTeamID)) & COMMA 'ToTeamID, varchar[20], NOT NULL
        sSQL &= SQLString(sEmployeeIDFrom) & COMMA 'FromEmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(sEmployeeIDTo) & COMMA 'ToEmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcReportID.SelectedValue) & COMMA 'ReportCode, varchar[20], NOT NULL

        sSQL &= SQLNumber(tdbcMonthYearFrom.Columns("TranMonth").Value) & COMMA 'FromTranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearTo.Columns("TranMonth").Value) & COMMA 'ToTranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearFrom.Columns("TranYear").Value) & COMMA 'FromTranYear, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearTo.Columns("TranYear").Value) & COMMA 'ToTranYear, int, NOT NULL

        If tdbcMonthYearFrom.Text = tdbcMonthYearTo.Text Then
            sSQL &= SQLString(sPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString("%") & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        End If
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcSalaryVoucherNoFrom)) & COMMA 'tdbcSalaryVoucherNoFrom, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'tdbcSalaryVoucherNoTo, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcPaymentMethod)) & COMMA 'PaymentMethod, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBankID)) & COMMA 'BankID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        If tdbcSalaryVoucherNoFrom.Text = "" Then
            sSQL &= SQLString("AND D600.SalaryVoucherNo In (" & sSalaryVoucherNo & ")") & COMMA 'strSalaryVoucherNo, varchar[8000], NOT NULL
        Else
            sSQL &= SQLString("") & COMMA 'strSalaryVoucherNo, varchar[8000], NOT NULL
        End If
        sSQL &= SQLNumber(chkIsProject.Checked) & COMMA 'IsProject, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkEmpWorking.Checked) & COMMA 'EmpWorking, tinyint, NOT NULL
        sSQL &= SQLNumber(chkEmpStopWork.Checked) & COMMA 'EmpStopWork, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= "N" & SQLString(sFind) & COMMA 'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcEmpGroupID)) & COMMA 'EmpGroupID, varchar[20], NOT NULL
        'Them ngay 13/11/2012 theo incident 51373 của Bích Thuận bởi Văn Vinh
        sSQL &= SQLString(ComboValue(tdbcPayrollFormID)) 'PayrollFormID, varchar[50], NOT NULL       
        Return sSQL
    End Function




    Private Function SQLReportPrinted() As String
        Dim sSQL As String = ""
        sSQL = "Select * From D13T4000 WITH (NOLOCK) Where ReportCode = " & SQLString(tdbcReportID.SelectedValue)
        Return sSQL
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Not AllowPrint() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        PrintReport()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PrintReport()
       
        Dim sName As String
        Dim sSQL As String
        Dim dt As DataTable
        'Dim bResult As Boolean
        Dim sReportCaption As String = rL3("Bang_luong_cong_tyF")
        Dim sPathReport As String = ""
        Dim sSubReportName As String = "D09R6000"
        Dim sSQLSub As String = ""

        Dim sReportName As String = ""
        Dim sFile As String = "rpt"
        If txtCustomReportID.Text.Trim <> "" Then
            sReportName = txtCustomReportID.Text
            sFile = txtFileExt.Text.Trim()
        Else
            sReportName = tdbcReportID.Columns("ReportCatelogy").Value.ToString()
        End If


        ' Update 7/8/2012 incident 41191 - đổi SubReport VNI
        sSQLSub = "-- Đổ nguồn cho subreport vni" & vbCrLf
        sSQLSub &= "SELECT 	CompanyName  as  Company, CompanyAddress as  Address, "
        sSQLSub &= " CompanyPhone  as  Telephone, CompanyFax  as  Fax, BankAccountName as BankAccountName, BankAccountNo,  VATCode"
        sSQLSub &= " FROM D91V0016"
        sSQLSub &= " WHERE   	DivisionID = " & SQLString(ReturnValueC1Combo(tdbcDivisionID))
        '  sSQLSub = "Select * From D09V0009"


        If optModeSalary0.Checked Then
            sSQL = SQLStoreD13P4010()
        Else
            sSQL = SQLStoreD13P4012(oFilterCheckG4.GetValueServer(tdbcEmployeeID), oFilterCheckG4.GetValueServer(tdbcEmployeeID))
        End If
        sFile = sFile.Trim.Replace(".", "")
        Select Case sFile.Trim
            Case "rpt", ""
                Dim report As New D99C1004
                Dim conn As New SqlConnection(gsConnectionString)
                sReportCaption = sReportCaption & " - " & sReportName
                sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, txtCustomReportID.Text) & sReportName & ".rpt"
                UnicodeSubReport(sSubReportName, sSQLSub, tdbcDivisionID.SelectedValue.ToString, gbUnicode)
                With report
                    .OpenConnection(conn)
                    .AddSub(sSQLSub, sSubReportName & ".rpt")
                    .AddParameter("TITLE", txtTitle.Text)

                    If tdbcMonthYearFrom.Text <> tdbcMonthYearTo.Text Then
                        report.AddParameter("MONTHYEAR", IIf(gbUnicode = False, rL3("Tu_"), ConvertVniToUnicode(rL3("Tu_"))).ToString & (tdbcMonthYearFrom.Columns(2).Text) & "/" & (tdbcMonthYearFrom.Columns(3).Text) & " - " & (tdbcMonthYearTo.Columns(2).Text) & "/" & (tdbcMonthYearTo.Columns(3).Text))
                    Else
                        report.AddParameter("MONTHYEAR", IIf(gbUnicode = False, rL3("ThangV"), ConvertVniToUnicode(rL3("ThangV"))).ToString & (tdbcMonthYearFrom.Columns(2).Text) & " /" & (tdbcMonthYearFrom.Columns(3).Text))
                    End If
                    dt = ReturnDataTable(SQLReportPrinted)
                    If dt.Rows.Count = 0 Then Exit Sub
                    For i As Integer = 1 To iMaxCol
                        sName = "ColCaption" & Format(i, "00")
                        If dt.Rows(0).Item(sName).ToString <> "" Then
                            .AddParameter(sName, dt.Rows(0).Item(sName).ToString)
                        Else
                            .AddParameter(sName, "")
                        End If
                    Next
                    'Add Main
                    .AddMain(sSQL)
                    .PrintReport(sPathReport, sReportCaption)
                End With
            Case Else
                Try
                    Dim sReportPath As String = ""
                    Dim sReportTypeID As String = ReturnValueC1Combo(tdbcReportID, "ReportTypeID")
                    Dim dtReport As DataTable = ReturnTableFilter(ReturnTableReportID(sReportTypeID, "13"), "ReportID ='" & sReportName & "'")
                    Dim file As String = GetReportPathNew(dtReport, "13", sReportTypeID, sReportName, "", sReportPath, "")
                    If sReportPath = "" Then Exit Sub
                    If ReturnDataTable(sSQL).Rows.Count < 1 Then D99C0008.Msg(rL3("Bao_cao_khong_co_du_lieu")) : Exit Sub
                    D99D0541.PrintOfficeType(sReportTypeID, sReportName, sReportPath, sFile, sSQL)
                Catch ex As Exception
                    btnPrint.Enabled = True
                End Try
        End Select

    End Sub

    Private Function SQLLoadReport() As String
        Dim sSQL As String = ""
        sSQL = "Select * From D13V4010 Order By DepartmentID, TeamID, EmployeeID"
        Return sSQL
    End Function

    Private Function AllowPrint() As Boolean
        If c1dateExamineDate.Text = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ngay_xet"))
            c1dateExamineDate.Focus()
            Return False
        End If
        If txtTitle.Text <> "" Then
            If txtTitle.Text.Trim.Length > 250 Then
                D99C0008.MsgNotYetEnter(rL3("Do_dai_Tieu_de_khong_duoc_vuot_qua_250_ky_tu"))
                txtTitle.Focus()
                Return False
            End If
        End If
        If tdbcReportID.Text = "" And txtCustomReportID.Text = "" Then
            D99C0008.MsgNotYetChoose(rL3("Dang_bao_cao"))
            tdbcReportID.Focus()
            Return False
        End If
        If tdbcDivisionID.Text = "" Then
            D99C0008.MsgNotYetChoose(rL3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        '        If tdbcBlockID.ReadOnly = False AndAlso tdbcBlockID.Text.Trim = "" Then
        '            D99C0008.MsgNotYetChoose(rL3("Khoi"))
        '            tdbcBlockID.Focus()
        '            Return False
        '        End If
        '        If tdbcDepartmentID.Text.Trim = "" Then
        '            D99C0008.MsgNotYetChoose(rL3("Phong_ban"))
        '            tdbcDepartmentID.Focus()
        '            Return False
        '        End If
        '        If tdbcTeamID.Text.Trim = "" Then
        '            D99C0008.MsgNotYetChoose(rL3("To_nhom"))
        '            tdbcTeamID.Focus()
        '            Return False
        '        End If
        '        If tdbcEmpGroupID.Text.Trim = "" Then
        '            D99C0008.MsgNotYetChoose(rL3("Nhom_nhan_vien"))
        '            tdbcEmpGroupID.Focus()
        '            Return False
        '        End If
        '        If tdbcEmployeeID.Text.Trim = "" Then
        '            D99C0008.MsgNotYetChoose(rL3("Nhan_vien"))
        '            tdbcEmployeeID.Focus()
        '            Return False
        '        End If

        If tdbcPayrollFormID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("HT_huong_luong"))
            tdbcPayrollFormID.Focus()
            Return False
        End If

        If tdbcPaymentMethod.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("PP_tra_luong"))
            tdbcPaymentMethod.Focus()
            Return False
        End If
        If tdbcBankID.ReadOnly = False AndAlso tdbcBankID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ngan_hang"))
            tdbcBankID.Focus()
            Return False
        End If

        If optModeSalary0.Checked And optTimeMode2.Checked Then
            If c1datePaymentDate.Visible AndAlso c1datePaymentDate.Text = "" Then
                D99C0008.MsgNotYetChoose(rL3("Ngay_thanh_toan"))
                c1datePaymentDate.Focus()
                Return False
            End If
        End If

        If tdbcMonthYearTo.Visible = False Then
            If tdbcMonthYearFrom.ReadOnly = False AndAlso tdbcMonthYearFrom.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Ky"))
                tdbcMonthYearFrom.Focus()
                Return False
            End If
        Else
            If tdbcMonthYearFrom.ReadOnly = False AndAlso tdbcMonthYearFrom.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Ky"))
                tdbcMonthYearFrom.Focus()
                Return False
            End If
            If tdbcMonthYearTo.ReadOnly = False AndAlso tdbcMonthYearTo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Ky"))
                tdbcMonthYearTo.Focus()
                Return False
            End If
            If CheckValidPeriodFromTo(tdbcMonthYearFrom, tdbcMonthYearTo) = False Then Return False
        End If

        '        If tdbcSalaryVoucherNoFrom.Visible AndAlso tdbcSalaryVoucherNoFrom.ReadOnly = False AndAlso tdbcSalaryVoucherNoFrom.Text = "" Then
        '            D99C0008.MsgNotYetChoose(rL3("Tu_phieu"))
        '            tdbcSalaryVoucherNoFrom.Focus()
        '            Return False
        '        End If
        '        If tdbcSalaryVoucherNoTo.Visible AndAlso tdbcSalaryVoucherNoTo.ReadOnly = False AndAlso tdbcSalaryVoucherNoTo.Text = "" Then
        '            D99C0008.MsgNotYetChoose(rL3("Den_phieu"))
        '            tdbcSalaryVoucherNoTo.Focus()
        '            Return False
        '        End If
        Return True
    End Function

    Private Sub btnTransferEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferEmail.Click

        If Not AllowPrint() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        SendMail()
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub SendMail()

        btnTransferEmail.Enabled = False
        btnClose.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Dim report As D99C1004
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = ""
        Dim sSubReportName As String = "D09R6000"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""
        '        Dim sLogSendMail As String = "" 'sLog &= Space(20) & Now & vbCrLf
        Dim sEmployeeID As String = ""
        Dim sAddressReceiver As String = "" 'Địa chỉ người nhận

        Dim iResultSend As Integer = 0
        Dim sErrorStringMail As String = ""
        Dim sListEmployeeID As String = "" 'Mảng các nhân viên không gởi được mail
        Dim sPassSalaryFile As String = ""

        sReportName = tdbcReportID.Columns(3).Value.ToString
        If txtCustomReportID.Text <> "" Then sReportName = txtCustomReportID.Text
        sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, txtCustomReportID.Text) & sReportName & ".rpt"

        If My.Computer.FileSystem.FileExists(sPathReport) = False Then
            D99C0008.MsgL3(rL3("Khong_ton_tai_bao_cao") & vbCrLf & sPathReport, L3MessageBoxIcon.Exclamation)
            btnTransferEmail.Enabled = True
            btnClose.Enabled = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        'Kiểm tra có dữ liệu để gởi mail không
        'Update 17/03/2015: Thay đổi cách gởi mail
        sSQL = SQLStoreD13P4010(1) 'SQLStoreD13P4020()
        Dim dtMail As DataTable = ReturnDataTable(sSQL)
        If dtMail.Rows.Count <= 0 Then
            D99C0008.MsgL3("Không tồn tại nhân viên.")
            GoTo _exit
        End If

        '===========================================================================
        'Thực hiện việc In báo cáo xuất ra file .PDF, sau đó đính kèm file vào gởi mail   
        'Lay Body dung cua Email
        Dim sSubject As String = ""
        Dim sContent As String = ""
        Dim dtCodeID As DataTable
        Dim dtContent As DataTable
        'Lấy nội dung mail, Content, Subject
        dtContent = ReturnDataTable("SELECT * FROM D13T4020 WITH (NOLOCK) ")
        'Lấy code để thay thế vào nội dung email
        dtCodeID = ReturnDataTable("SELECT * FROM D13V4022 WHERE FormID = " & SQLString(Me.Name))
        ' Lấy thông tin CC, BCC
        'Dim dtMailServer As DataTable = ReturnDataTable("Select * From D13T0000 WITH (NOLOCK) ")
        'Dim sCCAddress As String = dtMailServer.Rows(0).Item("CCAddress").ToString()
        'Dim sBCCAddress As String = dtMailServer.Rows(0).Item("BCCAddress").ToString()



        'Lấy hồ sơ lương tháng
        If sPayrollVoucherID = "" Then sPayrollVoucherID = GetPayrollVoucherIDD13()
        'Xóa bảng temp ghi file log D09T6666 
        'ExecuteSQLNoTransaction(SQLDeleteD09T6666)

        '=================================================
        Dim sTitleUnicode As String ' Gởi mail thì Font phải là Unicode
        If gbUnicode Then
            sTitleUnicode = txtTitle.Text
        Else
            sTitleUnicode = ConvertVniToUnicode(txtTitle.Text)
        End If
        sSQLSub = "Select * From D09V0009"
        UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)

        'Lấy Parameter động
        Dim sSQLParameter As String = SQLReportPrinted()
        Dim dtParameter As DataTable = ReturnDataTable(sSQLParameter)
        Dim sErrorCCAndBCCAddressMail As String = ""
        Dim sListErrorCCAndBCCAddressMail As String = ""


        For i As Integer = 0 To dtMail.Rows.Count - 1
            sErrorCCAndBCCAddressMail = ""

            'Kiểm tra tồn tại dll iTextSharppassword để giải mã File PDF đính kèm
            sPassSalaryFile = dtMail.Rows(i).Item("PassSalaryFile").ToString

            '#If DEBUG Then
            '            sPassSalaryFile = "ƒssku"
            '#End If

            If sPassSalaryFile <> "" Then
                sPassSalaryFile = D00D0041.D00C0001.EncryptString(sPassSalaryFile, False)
            End If

            sEmployeeID = dtMail.Rows(i).Item("EmployeeID").ToString
            sAddressReceiver = dtMail.Rows(i).Item("Receiver").ToString

            If sAddressReceiver = "" Then GoTo NotSendMail
            'Kiểm tra email người nhận có hợp lệ không
            If Not D99D0141.SendMailLemon3.CheckEmailAddress(sAddressReceiver) Then GoTo NotSendMail
            report = New D99C1004()
            With report
                .OpenConnection(conn)
                'Truyền Parameter của Main
                .AddParameter("TITLE", txtTitle.Text)
                If tdbcMonthYearFrom.Text <> tdbcMonthYearTo.Text Then
                    .AddParameter("MONTHYEAR", IIf(gbUnicode = False, rL3("Tu_"), ConvertVniToUnicode(rL3("Tu_"))).ToString & (tdbcMonthYearFrom.Columns(2).Text) & "/" & (tdbcMonthYearFrom.Columns(3).Text) & " - " & (tdbcMonthYearTo.Columns(2).Text) & "/" & (tdbcMonthYearTo.Columns(3).Text))
                Else
                    .AddParameter("MONTHYEAR", IIf(gbUnicode = False, rL3("ThangV"), ConvertVniToUnicode(rL3("ThangV"))).ToString & (tdbcMonthYearFrom.Columns(2).Text) & " /" & (tdbcMonthYearFrom.Columns(3).Text))
                End If

                If dtParameter.Rows.Count > 0 Then
                    For j As Integer = 1 To iMaxCol
                        Dim sName As String = "ColCaption" & Format(j, "00")
                        If dtParameter.Rows(0).Item(sName).ToString <> "" Then
                            .AddParameter(sName, dtParameter.Rows(0).Item(sName).ToString)
                        Else
                            .AddParameter(sName, "")
                        End If
                    Next
                End If

                ' =========================================
                If dtContent.Rows.Count > 0 Then
                    ' sSubject luon la Unicode
                    sSubject = dtContent.Rows(0).Item("Subject" & UnicodeJoin(True)).ToString
                    sContent = dtContent.Rows(0).Item("Content" & UnicodeJoin(gbUnicode)).ToString
                End If

                'Update 21/05/2012: Sửa Subject bổ sung thêm Mã nhân viên EmployeeID
                sSubject = IIf(sSubject = "", sTitleUnicode & " (" & sEmployeeID & ")", sSubject & " (" & sEmployeeID & ")").ToString

                ' Lấy giá trị sContent =========================================
                If sContent = "" Then
                    sContent = sTitleUnicode
                Else
                    Dim sContentMail As String = sContent
                    For j As Integer = 0 To dtCodeID.Rows.Count - 1
                        If sContent.Contains(dtCodeID.Rows(j).Item("CodeID").ToString) Then
                            sContentMail = Microsoft.VisualBasic.Replace(sContentMail, dtCodeID.Rows(j).Item("CodeID").ToString, dtMail.Rows(i).Item(dtCodeID.Rows(j).Item("FieldName").ToString).ToString)
                        End If
                    Next
                    If gbUnicode Then
                        sContent = sContentMail
                    Else
                        sContent = ConvertVniToUnicode(sContentMail)
                    End If
                End If

                ' =========================================
                .AddSub(sSQLSub, sSubReportName & ".rpt")
                '.AddMain(SQLStoreD13P4010(dtMail.Rows(i).Item("EmployeeID").ToString(), dtMail.Rows(i).Item("EmployeeID").ToString()))
                Dim dtMainReport As DataTable = ReturnTableFilter(dtMail, "EmployeeID = " & SQLString(sEmployeeID), True)
                .AddMain(dtMainReport)

                .KeyIDSendMail = sEmployeeID ' Đưa Mã file PDF xuất ra từ report
                Dim sResult As String = ""
                .PrintReport(sPathReport, sReportCaption, ReportModeType.lmPreview, "", True, sPassSalaryFile, sResult) ' Có xuất ra file thì truyền True
                If sResult <> "" Then 'Nếu bị lỗi in thì ko cho Gởi mail
                    D99C0008.MsgL3(sResult, L3MessageBoxIcon.Err)
                    dtMainReport.Dispose()
                    GoTo _exit
                    'Else
                    '    D99C0008.MsgL3("abc", L3MessageBoxIcon.Exclamation)
                End If

                dtMainReport.Dispose()
            End With

            'Gởi mail
            'Send mail: Nếu Tài liệu ghi Người gởi lấy từ UserAdminEmail thì truyền vào ""
            sContent = sContent.Replace(ChrW(10), "<br>")

            If Not report.SendMail("", sAddressReceiver, dtMail.Rows(i).Item("CCAddress").ToString, dtMail.Rows(i).Item("BCCAddress").ToString, sSubject, sContent, "", "", "", sErrorCCAndBCCAddressMail) Then


NotSendMail:
                'Ghi nhận lỗi gởi mail
                iResultSend += 1
                Dim sEMPTY As String
                sEMPTY = IIf(sAddressReceiver = "", rL3("trong"), sAddressReceiver).ToString
                sErrorStringMail &= vbCrLf & rL3("Nhan_vien") & Space(1) & sEmployeeID & " - Email: " & sEMPTY '& " - " & tdbcReportID.Columns(1).Value.ToString & vbCrLf

                'If sErrorListMail <> "" Then sErrorListMail &= ";"
                'sErrorListMail &= sAddressReceiver

                If sErrorCCAndBCCAddressMail <> "" Then sListErrorCCAndBCCAddressMail &= rL3("Nhan_vien") & Space(1) & sEmployeeID & " - " & sErrorCCAndBCCAddressMail & vbCrLf

                WriteLogFile("Error when send mail for " & sEmployeeID & " email: " & sEMPTY & " with Subject " & tdbcReportID.Columns(1).Value.ToString, "ErrorSendMail.log")

            Else
                If sListEmployeeID <> "" Then sListEmployeeID &= COMMA
                sListEmployeeID &= SQLString(sEmployeeID)

                If sErrorCCAndBCCAddressMail <> "" Then sListErrorCCAndBCCAddressMail &= rL3("Nhan_vien") & Space(1) & sEmployeeID & " - " & sErrorCCAndBCCAddressMail & vbCrLf
            End If

        Next

        Dim sMss As String
        If iResultSend = 0 Then
            'D99C0008.MsgL3(rL3("Goi_mail_thanh_cong"))
            sMss = rL3("Goi_mail_thanh_cong")
            If sListErrorCCAndBCCAddressMail <> "" Then sMss &= vbCrLf & vbCrLf & rL3("Dia_chi_mail_CC_khong_hop_le").Replace("CC", "CC/BCC") & vbCrLf & sListErrorCCAndBCCAddressMail
            D99C0008.MsgL3(sMss)
        Else
            'D99C0008.MsgL3(rL3("Cac_mail_goi_con_loi_") & iResultSend & "/" & dtMail.Rows.Count & sErrorStringMail)
            sMss = rL3("Cac_mail_goi_con_loi_") & iResultSend & "/" & dtMail.Rows.Count & sErrorStringMail
            If sListErrorCCAndBCCAddressMail <> "" Then sMss &= vbCrLf & vbCrLf & rL3("Dia_chi_mail_CC_khong_hop_le").Replace("CC", "CC/BCC") & vbCrLf & sListErrorCCAndBCCAddressMail
            D99C0008.MsgL3(sMss)
        End If
        'If sErrorListMail <> "" Then WriteLogFile(sErrorListMail, "ErrorListMail.log")

_exit:  btnTransferEmail.Enabled = True
        btnClose.Enabled = True
        report = Nothing
        conn.Dispose()
        '       If sLogSendMail <> "" Then WriteLogFileSendMail(sLogSendMail)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4020
    '# Created User: NGUYEN NGOC THANH
    '# Created Date: 19/06/2008
    '# Modified User: NGUYEN NGOC THANH 
    '# Modified Date: 19/06/2008 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4020() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4020 "
        sSQL &= SQLString(ComboValue(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcDepartmentID)) & COMMA 'FromDepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcDepartmentID)) & COMMA 'ToDepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcTeamID)) & COMMA 'FromTeamID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcTeamID)) & COMMA 'ToTeamID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcEmployeeID)) & COMMA 'FromEmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcEmployeeID)) & COMMA 'ToEmployeeID, varchar[20], NOT NULL

        sSQL &= SQLNumber(tdbcMonthYearFrom.Columns("TranMonth").Value) & COMMA 'FromTranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearTo.Columns("TranMonth").Value) & COMMA 'ToTranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearFrom.Columns("TranYear").Value) & COMMA 'FromTranYear, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYearTo.Columns("TranYear").Value) & COMMA 'ToTranYear, int, NOT NULL

        If tdbcMonthYearFrom.Text = tdbcMonthYearTo.Text Then
            sSQL &= SQLString(sPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString("%") & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        End If
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcSalaryVoucherNoFrom)) & COMMA 'tdbcSalaryVoucherNoFrom, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'tdbcSalaryVoucherNoTo, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcPaymentMethod)) & COMMA 'TdbcPaymentMethod
        '   sSQL &= SQLNumber(0) & COMMA 'IsRefEmployeeID, tinyint, NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'WhereClause, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkEmpWorking.Checked) & COMMA 'EmpWorking, tinyint, NOT NULL
        sSQL &= SQLNumber(chkEmpStopWork.Checked) & COMMA 'EmpStopWork, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL& COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F5609") 'FormID, varchar[50], NOT NULL

        Return sSQL
    End Function


    Private Function TestIP(ByVal sIP As String) As Boolean
        Try
            If My.Computer.Network.Ping(sIP) Then
                'MsgBox("Mail Server successfully.", MsgBoxStyle.Information, "Announcement")
                Return True
            Else
                'MsgBox("Not exist Mail Server.", MsgBoxStyle.Critical, "Announcement")
                D99C0008.MsgL3(rL3("Dia_chi_may_chu_khong_hop_le"))
                Return False
            End If
        Catch ex As Exception
            'MsgBox("Not exist Mail Server.", MsgBoxStyle.Critical, "Announcement")
            D99C0008.MsgL3(rL3("Dia_chi_may_chu_khong_hop_le"))
            Return False
        End Try

    End Function

    Private Sub LoadPeriodNumberAndDefaultPeriod(ByVal sDivisionID As String)
        Dim sSQL As String = ""
        sSQL = "Select Top 1 Replace(Str(TranMonth, 2), ' ', '0') + '/' + LTrim(Str(TranYear)) As DefaultPeriod " & vbCrLf
        sSQL &= "From D09T9999  WITH (NOLOCK) D13 Where D13.DivisionID = " & SQLString(sDivisionID) & vbCrLf
        sSQL &= "And TranMonth = " & SQLString(giTranMonth) & vbCrLf
        sSQL &= "And TranYear = " & SQLString(giTranYear) & vbCrLf
        sSQL &= " Order By (TranYear * 100 + TranMonth) Desc"
        Dim dt1 As DataTable = ReturnDataTable(sSQL)
        If dt1.Rows.Count > 0 Then
            tdbcMonthYearFrom.Text = dt1.Rows(0).Item("DefaultPeriod").ToString
            tdbcMonthYearTo.Text = dt1.Rows(0).Item("DefaultPeriod").ToString
        Else
            tdbcMonthYearFrom.SelectedIndex = 0
            tdbcMonthYearTo.SelectedIndex = 0
        End If
    End Sub

    Private Sub optModeSalary0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optModeSalary0.Click
        LoadtdbcReportID(0)
        optDetail.Enabled = True
        optGeneral.Enabled = True
        btnFilter.Enabled = True
        LockToCombo()
    End Sub

    Private Sub optModeSalary1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optModeSalary1.Click
        LoadtdbcReportID(1)
        optDetail.Enabled = False
        optGeneral.Enabled = False
        btnFilter.Enabled = False
        LockToCombo()
    End Sub

    Private Sub btnEmailContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmailContent.Click
        Dim f As New D13F4022
        With f
            .ShowInTaskbar = False
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub LockToCombo()
        If optModeSalary0.Checked And optGeneral.Checked Then
            ReadOnlyControl(tdbcMonthYearTo)

            lbllblMonthYearFrom.Visible = False
            lblMonthYearTo.Visible = False
            tdbcMonthYearTo.Visible = False
            chkIsProject.Visible = False

            '==================================
            optTimeMode1.Visible = True
            lblPeriod.Visible = False
            optTimeMode2.Visible = True
            c1datePaymentDate.Visible = True

            If optTimeMode1.Checked Then
                UnReadOnlyControl(True, tdbcMonthYearFrom)
                UnReadOnlyControl(False, tdbcSalaryVoucherNoFrom)
                '  UnReadOnlyControl(tdbcPayrollVoucherNo)
                ReadOnlyControl(c1datePaymentDate)
            Else
                ReadOnlyControl(tdbcMonthYearFrom, tdbcSalaryVoucherNoFrom)
                'tdbcSalaryVoucherNoFrom.SelectedValue = "%"
                oFilterCheckG4.SetValue(tdbcSalaryVoucherNoFrom, "")
                UnReadOnlyControl(c1datePaymentDate, True)
            End If
        Else
            UnReadOnlyControl(True, tdbcMonthYearFrom, tdbcMonthYearTo)
            UnReadOnlyControl(False, tdbcSalaryVoucherNoFrom)
            lbllblMonthYearFrom.Visible = True
            lblMonthYearTo.Visible = True
            tdbcMonthYearTo.Visible = True
            chkIsProject.Visible = True

            '===============================
            optTimeMode1.Visible = False
            lblPeriod.Visible = True
            optTimeMode2.Visible = False
            c1datePaymentDate.Visible = False
            '   UnReadOnlyControl(tdbcPayrollVoucherNo)
        End If
    End Sub

    Private Sub optDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDetail.Click
        LockToCombo()
    End Sub

    Private Sub optGeneral_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optGeneral.Click
        LockToCombo()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 27/06/2011 02:59:03
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666(ByVal Key01ID As String, ByVal Key02ID As String, ByVal Key03ID As String) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID ")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString(Key01ID) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(Key02ID) & COMMA) 'Key02ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(Key03ID)) 'Key03ID, varchar[250], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 27/06/2011 03:12:38
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where Key01ID = 'D13P4010' AND HostID = " & SQLString(My.Computer.Name) & " AND UserID = " & SQLString(gsUserID)
        Return sSQL
    End Function

    Private Sub WriteLogFileSendMail(ByVal Text As String, Optional ByVal FileName As String = "SendMail.log")
        Dim sLog As String = ""
        Dim sFileName As String = gsApplicationSetup & "\" & FileName
        If (My.Computer.FileSystem.FileExists(sFileName) = False) Then My.Computer.FileSystem.WriteAllText(sFileName, "", True)
        Dim lFileSize As Long = My.Computer.FileSystem.GetFileInfo(sFileName).Length
        If lFileSize > 10 * 1028 * 1028 Then My.Computer.FileSystem.DeleteFile(sFileName, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
        sLog &= Space(20) & Now & vbCrLf
        sLog &= Text & vbCrLf
        sLog &= "--------------------------------------------------------------------------" & vbCrLf
        My.Computer.FileSystem.GetFileInfo(sFileName).IsReadOnly = False
        My.Computer.FileSystem.WriteAllText(sFileName, sLog, True)
    End Sub

    Private Sub optTimeMode1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optTimeMode1.Click, optTimeMode2.Click
        LockToCombo()
    End Sub

#Region "Active Find - List All (Server)"
    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
    'Bỏ sự kiện Finder_FindClick.
    'Sửa tham số Me.Name -> Me
    'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
    'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    'Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            btnPrint_Click(Nothing, Nothing)
            sFind = ""
        End Set
    End Property

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        sSQL = "Select * From D13V1234 "
        sSQL &= "Where FormID = " & SQLString("D13F4020") & "And Language = " & SQLString(gsLanguage) & vbCrLf
        sSQL &= " Order by No"
        'ShowFindDialogClient(Finder, sSQL, gbUnicode)
        ShowFindDialogClient(Finder, sSQL, Me, gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        btnPrint_Click(Nothing, Nothing)
    '        sFind = ""
    '    End Sub

#End Region

    Private Sub txtTitle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTitle.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    'Thêm ngày 14/11/2012 theo incident 51373  của Bích Thuận bởi Văn Vinh
#Region "Events tdbcPayrollFormID"

    Private Sub tdbcPayrollFormID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPayrollFormID.KeyDown
        If e.KeyCode = Keys.F2 Then
            ' If tdbcSel01IDFrom.Tag Is Nothing Then Exit Sub 'tdbc.Tag lưu câu SQL đổ nguồn cho combo
            Me.Cursor = Cursors.WaitCursor
            Dim sSQL As String = "SELECT LookupID As SelectionID, Description" & UnicodeJoin(gbUnicode) & " As SelectionName, 'D09_PayrollForm'  AS SelectionGroup, 'D13F4020' As FormID"
            sSQL &= " FROM	D91T0320 WHERE	LookupType = 'D09_PayrollForm' AND Disabled = 0 AND (DAGroupID = '' "
            sSQL &= "  OR DAGroupID  IN (SELECT DAGroupID FROM 	Lemonsys.dbo.D00V0080 WHERE 	UserID= " & SQLString(gsUserID) & ") OR  'LEMONADMIN' = " & SQLString(gsUserID) & ") "
            Dim chuoi As String = HotKeyF2D91F6020(sSQL, tdbcPayrollFormID, , 2) 'Gán giá trị sau khi tìm kiếm
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub tdbcPayrollFormID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPayrollFormID.LostFocus
        If tdbcPayrollFormID.FindStringExact(tdbcPayrollFormID.Text) = -1 Then tdbcPayrollFormID.Text = ""
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4516
    '# Created User: 
    '# Created Date: 14/07/2014 03:06:42
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4516(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon combo phieu luong" & vbCrLf)
        sSQL &= "Exec D13P4516 "
        ' Mode = 0 ko care tdbcDivisionID, TranMonth, TranYear
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcMonthYearTo, "TranMonth")) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcMonthYearTo, "TranYear")) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA  'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsCompanyID) 'CompanyID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6666
    '# Created User: Hoàng Nhân
    '# Created Date: 18/09/2014 01:37:57
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P6666() As String
        Dim sTranMonthTo As String = "", sTranYearTo As String = ""
        If optDetail.Checked Then
            sTranMonthTo = ReturnValueC1Combo(tdbcMonthYearTo, "TranMonth")
            sTranYearTo = ReturnValueC1Combo(tdbcMonthYearTo, "TranYear")
        End If
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho Combo Nhan vien" & vbCrLf)
        sSQL &= "Exec D09P6666 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcMonthYearFrom, "TranMonth")) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcMonthYearFrom, "TranYear")) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D13F4020") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA 'Key01ID, varchar[500], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcBlockID)) & COMMA 'BlockID, varchar[50], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[50], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcTeamID)) & COMMA 'TeamID, varchar[50], NOT NULL
        sSQL &= SQLString(oFilterCheckG4.GetValueServer(tdbcEmpGroupID)) & COMMA 'EmpGroupID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLNumber(sTranMonthTo) & COMMA 'TranMonthTo, int, NOT NULL
        sSQL &= SQLNumber(sTranYearTo) 'TranYearTo, int, NOT NULL
        Return sSQL
    End Function

    Private Sub tdbcBlockID_BeforeOpen(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcBlockID.BeforeOpen
        e.Cancel = True
        oFilterCheckG4.FilterCheckBlockID(tdbcBlockID, e)
        '  oFilterCheck.FilterCheckCombo(tdbcBlockID, e)

    End Sub

    Private Sub tdbcDepartmentID_BeforeOpen(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDepartmentID.BeforeOpen
        e.Cancel = True
        oFilterCheckG4.FilterCheckDepartmentID(tdbcDepartmentID, e, oFilterCheckG4.ReturnValueC1Combo(tdbcBlockID))
        ' oFilterCheck.FilterCheckCombo(tdbcDepartmentID, e)
    End Sub

    Private Sub tdbcTeamID_BeforeOpen(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcTeamID.BeforeOpen
        e.Cancel = True
        oFilterCheckG4.FilterCheckTeamID(tdbcTeamID, e, oFilterCheckG4.ReturnValueC1Combo(tdbcBlockID), oFilterCheckG4.ReturnValueC1Combo(tdbcDepartmentID))
    End Sub

    Private Sub tdbcEmpGroupID_BeforeOpen(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcEmpGroupID.BeforeOpen
        e.Cancel = True
        oFilterCheckG4.FilterCheckEmpGroupID(tdbcEmpGroupID, e, oFilterCheckG4.ReturnValueC1Combo(tdbcBlockID), oFilterCheckG4.ReturnValueC1Combo(tdbcDepartmentID), oFilterCheckG4.ReturnValueC1Combo(tdbcTeamID))
    End Sub

    Private Sub tdbcBlockID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated
        oFilterCheckG4.FilterCheckBlockID(tdbcBlockID, e)
        If Not oFilterCheckG4.CheckChangeValue(sender) Then Exit Sub
        oFilterCheckG4.SetValues("", tdbcDepartmentID, tdbcTeamID, tdbcEmpGroupID, tdbcEmployeeID)
    End Sub

    Private Sub tdbcDepartmentID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Validated
        oFilterCheckG4.FilterCheckDepartmentID(tdbcDepartmentID, e, oFilterCheckG4.ReturnValueC1Combo(tdbcBlockID))
        If Not oFilterCheckG4.CheckChangeValue(sender) Then Exit Sub
        oFilterCheckG4.SetValues("", tdbcTeamID, tdbcEmpGroupID, tdbcEmployeeID)
    End Sub

    Private Sub tdbcTeamID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.Validated
        oFilterCheckG4.FilterCheckTeamID(tdbcTeamID, e, oFilterCheckG4.ReturnValueC1Combo(tdbcBlockID), oFilterCheckG4.ReturnValueC1Combo(tdbcDepartmentID))
        If Not oFilterCheckG4.CheckChangeValue(sender) Then Exit Sub

        oFilterCheckG4.SetValues("", tdbcEmpGroupID, tdbcEmployeeID)
    End Sub

    Private Sub tdbcEmpGroupID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmpGroupID.Validated
        oFilterCheckG4.FilterCheckEmpGroupID(tdbcEmpGroupID, e, oFilterCheckG4.ReturnValueC1Combo(tdbcBlockID), oFilterCheckG4.ReturnValueC1Combo(tdbcDepartmentID), oFilterCheckG4.ReturnValueC1Combo(tdbcTeamID))
        If Not oFilterCheckG4.CheckChangeValue(sender) Then Exit Sub
        oFilterCheckG4.SetValue(tdbcEmployeeID, "")
    End Sub

    Private Sub tdbcEmployeeID_BeforeOpen(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcEmployeeID.BeforeOpen
        e.Cancel = True
        tdbcEmployeeID_Validated(sender, e)
    End Sub

    Private Sub tdbcEmployeeID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.Validated, tdbcSalaryVoucherNoFrom.Validated
        oFilterCheckG4.FilterCheckDepand(tdbcEmployeeID, e, SQLStoreD09P6666)
    End Sub

    Private Sub tdbcSalaryVoucherNoFrom_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalaryVoucherNoFrom.Validated
        'oFilterCheckG4.FilterCheckDepand(CType(sender, C1.Win.C1List.C1Combo), e, dtSalaryVoucherNo, GetFilterSalaryVoucherNo(ReturnValueC1Combo(tdbcDivisionID), L3Int(ReturnValueC1Combo(tdbcMonthYearTo, "TranMonth")), L3Int(ReturnValueC1Combo(tdbcMonthYearTo, "TranYear"))))
        oFilterCheckG4.FilterCheckDepand(CType(sender, C1.Win.C1List.C1Combo), e, dtSalaryVoucherNo, GetFilterSalaryVoucherNo(ReturnValueC1Combo(tdbcDivisionID)))
    End Sub

    Private Sub tdbcSalaryVoucherNoFrom_BeforeOpen(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcSalaryVoucherNoFrom.BeforeOpen
        e.Cancel = True
        tdbcSalaryVoucherNoFrom_Validated(sender, e)
    End Sub

    Private Sub tdbcProjectID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProjectID.Validated
        oFilterCheck.FilterCheckCombo(tdbcProjectID, e)
    End Sub

    Private Sub optGeneral_CheckedChanged(sender As Object, e As EventArgs) Handles optGeneral.CheckedChanged
        If oFilterCheckG4 Is Nothing Then Exit Sub
        oFilterCheckG4.SetValue(tdbcSalaryVoucherNoFrom, "")
    End Sub



End Class
