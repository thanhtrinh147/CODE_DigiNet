
'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:35:03 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 11/03/2010
'# Modify User: MINHHOA
'# Description: Sửa lại giao diện incident 45702
'#-------------------------------------------------------------------------------------
Imports System.Text
Imports System.Windows.Forms
Imports System
Public Class D13F2041
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
    End Property

    Private _defaultChooseListEmp As Boolean = False
    Public WriteOnly Property DefaultChooseListEmp() As Boolean 
        Set(ByVal Value As Boolean )
            _defaultChooseListEmp = Value
        End Set
    End Property

    Dim dtCaptionCols As DataTable
    Dim sEditVoucherTypeID As String = ""
    Dim sEditTransTypeID As String = ""
    Dim dtGrid As DataTable
    Private dtTeamID, dtDayVoucherNo, dtProVoucherNo As New DataTable
    Private dtAdjustIncomeRoot, dtGridAdjustIncome, dtGridEmp As DataTable
    Dim dtNCodeID As DataTable

    Private _calculated, _updated As Int16
    Dim bP4500, bP2110, bP2600 As Boolean

    Private sSalCalMethodID As String = ""  '        'update 25/3/2013 incident 54141

    Dim bOnCalculating As Boolean = False
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker

    Dim iAttPeriodFrom As Integer = 0
    Dim iAttPeriodTo As Integer = 0
    Dim iAdvancedPeriodFrom As Integer = 0
    Dim iAdvancePeriodTo As Integer = 0
    Private bLoadFirst As Boolean = False


#Region "Const of tdbgAdjustIncome - Total of Columns: 14"
    Private Const COLA_IsUse As Integer = 0             ' Chọn
    Private Const COLA_VoucherTypeID As Integer = 1     ' VoucherTypeID
    Private Const COLA_IsAdvancedSal As Integer = 2     ' IsAdvancedSal
    Private Const COLA_VoucherID As Integer = 3         ' VoucherID
    Private Const COLA_VoucherTypeName As Integer = 4   ' Loại phiếu
    Private Const COLA_VoucherNo As Integer = 5         ' Số phiếu
    Private Const COLA_Remark As Integer = 6            ' Diễn giải
    Private Const COLA_BlockID As Integer = 7           ' BlockID
    Private Const COLA_BlockName As Integer = 8         ' Khối
    Private Const COLA_ProjectID As Integer = 9         ' ProjectID
    Private Const COLA_ProjectName As Integer = 10      ' Dự án
    Private Const COLA_SalaryObjectID As Integer = 11   ' SalaryObjectID
    Private Const COLA_SalaryObjectName As Integer = 12 ' Đối tượng tính lương
    Private Const COLA_ModuleID As Integer = 13         ' ModuleID
#End Region


#Region "Const of tdbgEmp - Total of Columns: 16"
    Private Const COLE_IsUsed As Integer = 0         ' Chọn
    Private Const COLE_TransID As Integer = 1        ' TransID
    Private Const COLE_EmployeeID As Integer = 2     ' Mã NV
    Private Const COLE_EmployeeName As Integer = 3   ' Họ và Tên
    Private Const COLE_DepartmentName As Integer = 4 ' Phòng ban
    Private Const COLE_TeamName As Integer = 5       ' Tổ nhóm
    Private Const COLE_ProjectName As Integer = 6    ' Dự án
    Private Const COLE_SalaryObjectName As Integer = 7 ' ĐT tính lương
    Private Const COLE_EmpGroupName As Integer = 8   ' Nhóm nhân viên
    Private Const COLE_DutyName As Integer = 9       ' Chức vụ
    Private Const COLE_WorkName As Integer = 10      ' Công việc
    Private Const COLE_BirthDate As Integer = 11     ' Ngày sinh
    Private Const COLE_DateLeft As Integer = 12      ' Ngày nghỉ việc
    Private Const COLE_DateJoined As Integer = 13    ' Ngày vào làm
    Private Const COLE_StatusName As Integer = 14    ' Trạng thái làm việc
    Private Const COLE_Type As Integer = 15          ' Type
#End Region


    Dim _PayrollVoucherID As String = ""
    Public Property PayrollVoucherID() As String
        Get
            Return _PayrollVoucherID
        End Get
        Set(ByVal value As String)
            _PayrollVoucherID = value
        End Set
    End Property

    Private _salaryVoucherID As String = ""
    Public Property SalaryVoucherID() As String
        Get
            Return _salaryVoucherID
        End Get
        Set(ByVal value As String)
            If SalaryVoucherID = value Then
                _salaryVoucherID = ""
                Return
            End If
            _salaryVoucherID = value
        End Set
    End Property

    Private _formCall As String = Me.Name
    Public WriteOnly Property FormCall() As String
        Set(ByVal value As String)
            _formCall = value
        End Set
    End Property


    Public Property Calculated() As Int16
        Get
            Return _calculated
        End Get
        Set(ByVal value As Int16)
            If Calculated = value Then
                _calculated = 0
                Return
            End If
            _calculated = value 'Caculated 
        End Set
    End Property

    Public Property Updated() As Int16
        Get
            Return _updated
        End Get
        Set(ByVal value As Int16)
            If Updated = value Then
                _updated = 0
                Return
            End If
            _updated = value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            LoadTDBCombo()
            tabMain.Tag = tabMain.Width
            InitForm()
            VisibletdbgEmp(_defaultChooseListEmp)
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnSalCalculation.Enabled = False
                    btnSave.Enabled = True
                    LoadAdd()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnSalCalculation.Enabled = False
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    btnSalCalculation.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub D13F2041_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bOnCalculating Then
            e.Cancel = True
        End If
    End Sub

    Private Sub D13F2041_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    tabMain.SelectedTab = tabPage1
                    Application.DoEvents()
                    If tdbgAdjustIncome.Enabled Then tdbgAdjustIncome.Focus()
                Case Keys.D2, Keys.NumPad2
                    tabMain.SelectedTab = tabPage3
                    Application.DoEvents()
                    If tdbcTransferMethodID.Enabled Then tdbcTransferMethodID.Focus()
            End Select
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        End If
    End Sub

    Private Sub D13F2041_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        InputbyUnicode(Me, gbUnicode)
        ReLoadImage(picRunning)
        InputDateInTrueDBGrid(tdbgEmp, COLE_BirthDate, COLE_DateLeft, COLE_DateJoined)
        ResetColorGrid(tdbgAdjustIncome)
        ResetColorGrid(tdbgEmp)
        LoadLanguage()
        SetBackColorObligatory()
        InputDateCustomFormat(c1dateDateTo, c1dateDateFrom, c1dateVoucherDate)
        SetShortcutPopupMenu(ContextMenuStrip1)
        bLoadFirst = True
        SetResolutionForm(Me)
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbgAdjustIncome.Splits(SPLIT0).DisplayColumns(COLA_VoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgAdjustIncome.Splits(SPLIT0).DisplayColumns(COLA_Remark).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Thiet_lap_chung_tu_luong_-_D13F2041") & UnicodeCaption(gbUnicode) 'ThiÕt lËp ch÷ng tô l§¥ng - D13F2041
        '================================================================ 
        lblTransferMethodID.Text = rL3("PP_chuyen_but_toan") 'PP chuyển bút toán
        lblInsExRate.Text = rL3("Ty_gia_bao_hiem") 'Tỷ giá bảo hiểm
        lblSalaryExRate.Text = rL3("Ty_gia_luong") 'Tỷ giá lương
        lblProjectID.Text = rL3("Cong_trinh") 'Dự án
        lblteDateFrom.Text = rL3("Thoi_gian") 'Thời gian
        lblteVoucherDate.Text = rL3("Ngay_phieu") 'Ngày phiếu
        lblDescription.Text = rL3("Dien_giai") 'Ghi chú
        lblSalCalMethodID.Text = rL3("PP_tinh_luong") 'PP tính lương
        lblDepartmentIDFrom.Text = rL3("Phong_ban") 'Phòng ban
        lblTeamIDFrom.Text = rL3("To_nhom") 'Tổ nhóm
        lblNCodeID.Text = rL3("Ma_PTNS") 'Mã PTNS
        lblTransTypeID.Text = rL3("Mau_thiet_lapU") 'Mãu thiết lập
        lblIsObjectTypeCaculateSal.Text = rL3("Doi_tuong") 'Đối tượng
        '================================================================ 
        btnChooseEmpStopWorking.Text = "<< " & rL3("Chon_nhan_vien") 'Chọn nhân viên nghỉ việc
        btnSave.Text = rL3("_Luu") '&Lưu
        btnSalCalculation.Text = rL3("_Tinh_luong") '&Tính lương
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        chkIsAdvancedSal.Text = rL3("Luong_ung") 'Lương ứng
        chkIsEmpStopWorking.Text = rL3("Nhan_vien_nghi_viec") 'Nhân viên nghỉ việc
        chkIsEmpWorking.Text = rL3("Nhan_vien_dang_lam_viec") 'Nhân viên đang làm việc
        chkIsExceptNotAttendence.Text = rL3("Loai_nhan_vien_khong_co_du_lieu_cham_cong_tong_hop") 'Loại nhân viên không có dữ liệu chấm công tổng hợp
        chkIsExceptNotIncomeAdjust.Text = rL3("Loai_nhan_vien_khong_co_du_lieu_dieu_chinh_thu_nhap") 'Loại nhân viên không có dữ liệu điều chỉnh thu nhập
        chkIsExceptMaterity.Text = rL3("Loai_nhan_vien_nghi_thai_san") 'Loại nhân viên nghỉ thai sản
        chkShowSelected.Text = rL3("Chi_hien_thi_nhung_du_lieu_da_chon") ' Chỉ hiển thị những dòng đã chọn
        '================================================================ 
        optIsObjectTypeCaculateSal2.Text = rL3("Ca_hai_U") 'Cả hai
        optIsObjectTypeCaculateSal1.Text = rL3("Nguoi_nuoc_ngoai") 'Người nước ngoài
        optIsObjectTypeCaculateSal0.Text = rL3("Nguoi_trong_nuoc") 'Người trong nước
        '================================================================ 
        grpEmpStopWorking.Text = rL3("Danh_sach_nhan_vien") 'Danh sách nhân viên nghỉ việc
        '================================================================ 
        tabPage1.Text = rL3("Du_lieu_dau_vao")
        tabPage3.Text = rL3("Nang_cao") 'Nâng cao
        '================================================================ 
        tdbcTransferMethodID.Columns("TransferMethodID").Caption = rL3("Ma") 'Mã
        tdbcTransferMethodID.Columns("TransferMethodName").Caption = rL3("Dien_giai") 'Diễn giải
        tdbcNCodeID.Columns("NCodeID").Caption = rL3("Ma") 'Mã
        tdbcNCodeID.Columns("NCodeName").Caption = rL3("Ten") 'Tên
        tdbcProjectID.Columns("ProjectID").Caption = rL3("Ma") 'Mã
        tdbcProjectID.Columns("ProjectName").Caption = rL3("Ten") 'Tên
        tdbcNCodeTypeID.Columns("NCodeTypeID").Caption = rL3("Ma") 'Mã
        tdbcNCodeTypeID.Columns("NCodeTypeName").Caption = rL3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        'Lê Anh Vũ: Tạm thời bỏ dòng này vì lỗi Resource
        'tdbcDepartmentID.Columns("PayrollVoucherID").Caption = rL3("Ma_HSL") 'Mã HSL
        tdbcSalCalMethodID.Columns("SalCalMethodID").Caption = rL3("Ma") 'Mã
        tdbcSalCalMethodID.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        tdbcTransTypeID.Columns("TransTypeID").Caption = rL3("Ma") 'Mã
        tdbcTransTypeID.Columns("TransTypeName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        '================================================================ 
        tdbgEmp.Columns(COLE_IsUsed).Caption = rL3("Chon") 'Chọn
        tdbgEmp.Columns(COLE_EmployeeID).Caption = rL3("Ma_NV") 'Mã NV
        tdbgEmp.Columns(COLE_EmployeeName).Caption = rL3("Ho_va_ten") 'Họ và Tên
        tdbgEmp.Columns(COLE_DepartmentName).Caption = rL3("Phong_ban") 'Phòng ban
        tdbgEmp.Columns(COLE_TeamName).Caption = rL3("To_nhom") 'Tổ nhóm
        tdbgEmp.Columns(COLE_ProjectName).Caption = rL3("Cong_trinh")  'Dự án
        tdbgEmp.Columns(COLE_EmpGroupName).Caption = rL3("Nhom_nhan_vien") 'Nhóm nhân viên
        tdbgEmp.Columns(COLE_DutyName).Caption = rL3("Chuc_vu") 'Chức vụ
        tdbgEmp.Columns(COLE_WorkName).Caption = rL3("Cong_viec") 'Công việc
        tdbgEmp.Columns(COLE_BirthDate).Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbgEmp.Columns(COLE_DateLeft).Caption = rL3("Ngay_nghi_viec") 'Ngày nghỉ việc
        tdbgEmp.Columns(COLE_DateJoined).Caption = rL3("Ngay_vao_lam") 'Ngày vào làm
        tdbgEmp.Columns(COLE_StatusName).Caption = rL3("Trang_thai_lam_viec") 'Trạng thái làm việc

        '================================================================ 
        tdbgEmp.Columns(COLE_SalaryObjectName).Caption = rL3("Doi_tuong_tinh_luong") 'ĐT tính lương

        tdbgAdjustIncome.Columns(COLA_IsUse).Caption = rL3("Chon") 'Chọn
        tdbgAdjustIncome.Columns(COLA_VoucherTypeName).Caption = rL3("Loai_phieu") 'Loại phiếu
        tdbgAdjustIncome.Columns(COLA_VoucherNo).Caption = rL3("So_phieu") 'Số phiếu
        tdbgAdjustIncome.Columns(COLA_Remark).Caption = rL3("Dien_giai") 'Diễn giải
        '================================================================ 
        lblBlockID.Text = rL3("Khoi") 'Khối
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        lblSalaryObjectID.Text = rL3("Doi_tuong_tinh_luong") 'Đối tượng tính lương
        '================================================================ 
        tdbcSalaryObjectID.Columns("SalaryObjectID").Caption = rL3("Ma") 'Mã
        tdbcSalaryObjectID.Columns("SalaryObjectName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        tdbgAdjustIncome.Columns(COLA_BlockName).Caption = rL3("Khoi") 'Khối
        tdbgAdjustIncome.Columns(COLA_ProjectName).Caption = rL3("Cong_trinh") 'Dự án
        tdbgAdjustIncome.Columns(COLA_SalaryObjectName).Caption = rL3("Doi_tuong_tinh_luongU") 'Đối tượng tính lương

        '================================================================ 
        lblStatusID.Text = rL3("Trang_thai_lam_viec") 'Trạng thái làm việc
        '================================================================ 
        tdbcStatusID.Columns("StatusID").Caption = rL3("Ma") 'Mã
        tdbcStatusID.Columns("StatusName").Caption = rL3("Ten") 'Tên


    End Sub

    Private Sub btnChooseEmpStopWorking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseEmpStopWorking.Click
        VisibletdbgEmp(Not grpEmpStopWorking.Visible)
    End Sub

    Private Sub VisibletdbgEmp(ByVal bVisible As Boolean)
        ' tdbgAdjustIncome.Tag = tdbgAdjustIncome.Width

        If bVisible Then
            If grpEmpStopWorking.Visible Then Exit Sub

            grpEmpStopWorking.Visible = True
            btnChooseEmpStopWorking.Text = ">> " & rL3("Chon_nhan_vien")
            tabMain.Width = L3Int(tabMain.Tag)
            '  tdbgAdjustIncome.Width = L3Int(tdbgAdjustIncome.Tag)
        Else
            grpEmpStopWorking.Visible = False
            btnChooseEmpStopWorking.Text = "<< " & rL3("Chon_nhan_vien")
            tabMain.Width = 984
            ' tdbgAdjustIncome.Width = 962
        End If
    End Sub

#Region "Events tdbcTransTypeID"

    Private Sub tdbcTransTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.LostFocus
        If tdbcTransTypeID.FindStringExact(tdbcTransTypeID.Text) = -1 Then tdbcTransTypeID.Text = ""
    End Sub

    Private Sub tdbcTransTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.SelectedValueChanged
        If Not (tdbcTransTypeID.Tag Is Nothing OrElse tdbcTransTypeID.Tag.ToString = "") Then
            tdbcTransTypeID.Tag = ""
            Exit Sub
        End If
        If tdbcTransTypeID.SelectedValue Is Nothing Then
            Exit Sub
        End If

        If _FormState = EnumFormState.FormAdd Then ' Chi load default khi Thêm mơi
            LoadbyTransTypeID()
        End If
    End Sub

    Private Sub LoadbyTransTypeID()
        chkIsEmpWorking.Checked = L3Bool(ReturnValueC1Combo(tdbcTransTypeID, "IsEmpWorking"))
        chkIsExceptMaterity.Checked = L3Bool(ReturnValueC1Combo(tdbcTransTypeID, "IsExceptMaterity"))
        chkIsExceptNotIncomeAdjust.Checked = L3Bool(ReturnValueC1Combo(tdbcTransTypeID, "IsExceptNotIncomeAdjust"))
        chkIsExceptNotAttendence.Checked = L3Bool(ReturnValueC1Combo(tdbcTransTypeID, "IsExceptNotAttendence"))
        chkIsEmpStopWorking.Checked = L3Bool(ReturnValueC1Combo(tdbcTransTypeID, "IsEmpStopWorking"))
        If L3Int(ReturnValueC1Combo(tdbcTransTypeID, "IsObjectTypeCaculateSal")) = 0 Then
            optIsObjectTypeCaculateSal0.Checked = True
        ElseIf L3Int(ReturnValueC1Combo(tdbcTransTypeID, "IsObjectTypeCaculateSal")) = 1 Then
            optIsObjectTypeCaculateSal1.Checked = True
        Else
            optIsObjectTypeCaculateSal2.Checked = True
        End If
        If CheckExistForm(Me.Name) Then LoadTDBGridEmp()
    End Sub

#End Region

#Region "Events tdbcSalCalMethodID with txtSalCalMethodName"

    Private Sub tdbcSalCalMethodID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalCalMethodID.LostFocus
        If tdbcSalCalMethodID.FindStringExact(tdbcSalCalMethodID.Text) = -1 Then
            tdbcSalCalMethodID.Text = ""
            'txtSalCalMethodName.Text = ""
        End If
    End Sub

    Private Sub tdbcSalCalMethodID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalCalMethodID.SelectedValueChanged
        '        If tdbcSalCalMethodID.SelectedValue Is Nothing Then
        '            txtSalCalMethodName.Text = ""
        '            Exit Sub
        '        End If
        '
        '        txtSalCalMethodName.Text = tdbcSalCalMethodID.Columns(1).Value.ToString
    End Sub
#End Region

#Region "Events tdbcTransferMethodID with txtTransferMethodName load tdbcDepartmentIDFrom"

    Private Sub tdbcTransferMethodID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransferMethodID.LostFocus
        If tdbcTransferMethodID.FindStringExact(tdbcTransferMethodID.Text) = -1 Then
            tdbcTransferMethodID.Text = ""
            'txtTransferMethodName.Text = ""
        End If
    End Sub

    Private Sub tdbcTransferMethodID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransferMethodID.SelectedValueChanged
        If tdbcTransferMethodID.Text Is Nothing Then
            txtTransferMethodName.Text = ""
            Exit Sub
        End If
        'txtTransferMethodName.Text = tdbcTransferMethodID.Columns(1).Text
    End Sub

    Private Sub tdbcDepartmentIDFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    'Private Sub tdbcDepartmentIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
    '    If Not (tdbcDepartmentID.Tag Is Nothing OrElse tdbcDepartmentID.Tag.ToString = "") Then
    '        tdbcDepartmentID.Tag = ""
    '        Exit Sub
    '    End If
    '    If tdbcDepartmentID.SelectedValue Is Nothing Then
    '        LoadtdbcTeamID("-1")
    '        Exit Sub
    '    ElseIf tdbcDepartmentID.SelectedValue.ToString = "%" Then
    '        tdbcTeamID.Enabled = False
    '        If tdbcTeamID.SelectedValue Is Nothing Then
    '            LoadtdbcTeamID("-1")
    '        Else
    '            tdbcTeamID.SelectedValue = "%"
    '        End If
    '    ElseIf tdbcDepartmentID.SelectedValue.ToString <> "%" Then
    '        LoadtdbcTeamID(tdbcDepartmentID.SelectedValue.ToString)
    '        tdbcTeamID.Enabled = True
    '    End If

    'End Sub
#End Region

#Region "Events tdbcDepartmentIDTo load tdbcTeamIDFrom"

    Private Sub tdbcDepartmentIDTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'If tdbcDepartmentIDTo.FindStringExact(tdbcDepartmentIDTo.Text) = -1 Then tdbcDepartmentIDTo.Text = ""
    End Sub

    '    Private Sub tdbcDepartmentIDTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '        If Not (tdbcDepartmentIDTo.Tag Is Nothing OrElse tdbcDepartmentIDTo.Tag.ToString = "") Then
    '            tdbcDepartmentIDTo.Tag = ""
    '            Exit Sub
    '        End If
    '        If tdbcDepartmentIDTo.SelectedValue Is Nothing Then
    '            LoadtdbcTeamID("-1")
    '            Exit Sub
    '        ElseIf tdbcDepartmentIDTo.SelectedValue.ToString = "%" Then
    '            tdbcTeamIDFrom.Enabled = False
    '            tdbcTeamIDTo.Enabled = False
    '        ElseIf tdbcDepartmentIDTo.SelectedValue.ToString <> "%" Then
    '            tdbcDepartmentIDFrom.Enabled = True
    '            LoadtdbcTeamID(tdbcDepartmentIDTo.SelectedValue.ToString)
    '            If tdbcDepartmentIDTo.Text = tdbcDepartmentIDFrom.Text Then
    '                tdbcTeamIDFrom.Enabled = True
    '                tdbcTeamIDTo.Enabled = True
    '            Else
    '                tdbcTeamIDFrom.Enabled = False
    '                tdbcTeamIDTo.Enabled = False
    '            End If
    '        End If
    '        tdbcTeamIDFrom.AutoSelect = True
    '        tdbcTeamIDTo.AutoSelect = True
    '    End Sub

    Private Sub tdbcTeamIDFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub
#End Region

    Private Sub SetBackColorObligatory()
        tdbcTransTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcSalCalMethodID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtDescription.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadAdd()
        tdbcTransTypeID.SelectedIndex = 0
        txtDescription.Text = ""
        tdbcSalCalMethodID.SelectedValue = tdbcSalCalMethodID.Columns("SalCalMethodID").Text
        tdbcDepartmentID.SelectedValue = tdbcDepartmentID.Columns("DepartmentID").Text
        tdbcTransferMethodID.Text = ""
        LoadMaster()
        LoadTime()
    End Sub

    ' 26/1/2014 id 64227
    Private Sub LoadTime()
        ' Store trả ra MinDate, MaxDate gán giá trị Default cho DateForm, DateTo.
        Dim sSQL As String = ""
        If chkIsAdvancedSal.Checked Then
            sSQL = SQLStoreD29P2001(iAdvancedPeriodFrom, iAdvancePeriodTo)
        Else
            sSQL = SQLStoreD29P2001(iAttPeriodFrom, iAttPeriodTo)
        End If
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt IsNot Nothing OrElse dt.Rows.Count > 0 Then
            c1dateDateFrom.Value = dt.Rows(0).Item("MinDate")
            c1dateDateTo.Value = dt.Rows(0).Item("MaxDate")
        End If
    End Sub

    Private Sub LoadEdit()
        tdbcTransTypeID.Enabled = False
        c1dateVoucherDate.Enabled = False

        LoadMaster()

    End Sub
    Private dtBlock, dtDepartmentID, dtEmpGroupID As DataTable

    'Private Sub DefaultProject()
    '    tdbcProjectID.SelectedIndex = 0
    '    If ReturnValueC1Combo(tdbcProjectID) <> "%" Then
    '        tdbcProjectID.SelectedValue = ""
    '    End If
    'End Sub
    Private Sub LoadTDBCombo()
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        Dim sSQL As String = SQLStoreD13P1130()
        'LoadTdbcTransTypeID(tdbcTransTypeID, "0003", sEditTransTypeID)
        LoadDataSource(tdbcTransTypeID, sSQL, gbUnicode)


        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)

        LoadtdbcBlockID(tdbcBlockID, gbUnicode)
        tdbcBlockID.SelectedValue = "%"
        'Load tdbcDepartmentID

        LoadDataSource(tdbcDepartmentID, dtDepartmentID, gbUnicode)

        'Load tdbcSalCalMethodID
        sSQL = "Select SalCalMethodID, Description" & UnicodeJoin(gbUnicode) & " as Description From D13T2500 WITH(NOLOCK) "
        sSQL &= " WHERE (Disabled = 0 OR SalCalMethodID = " & SQLString(sSalCalMethodID) & ")"
        sSQL &= " AND (DivisionID = " & SQLString(gsDivisionID) & " Or DivisionID = '')"
        sSQL &= " Order By SalCalMethodID"
        LoadDataSource(tdbcSalCalMethodID, sSQL, gbUnicode)

        'Load tdbcTransferMethodID
        sSQL = "Select TransferMethodID, TransferMethodName" & UnicodeJoin(gbUnicode) & " as TransferMethodName From D13T1110  WITH(NOLOCK) Where Disabled = 0 "
        LoadDataSource(tdbcTransferMethodID, sSQL, gbUnicode)

        'Load tdbcProjectID
        'sSQL = "Select ProjectID, Description" & UnicodeJoin(gbUnicode) & " As ProjectName From D09T1080  WITH(NOLOCK) " & vbCrLf
        'sSQL &= "WHERE Disabled = 0" & vbCrLf
        'sSQL &= "ORDER BY ProjectID"
        'Dim dtProjectID As DataTable = ReturnDataTable(SQLStoreD09P6868()) 
        LoadDataSource(tdbcProjectID, SQLStoreD09P6868(), gbUnicode) 'TUANVU yeu cau doi cau do nguon theo ID 75781.
        tdbcProjectID.SelectedIndex = 0
        'LoadDataSource(tdbcGAProjectID, dtProjectID.Copy, gbUnicode)

        'Load tdbcNCodeTypeID
        sSQL = "Select TypeID as NCodeTypeID, Description" & UnicodeJoin(gbUnicode) & " as NCodeTypeName " & vbCrLf
        sSQL &= " FROM D09T0010  WITH(NOLOCK) WHERE Disabled = 0 ORDER BY TypeID"
        LoadDataSource(tdbcNCodeTypeID, sSQL, gbUnicode)

        'Load tdbcNCodeID
        sSQL = "Select NCodeID, Description" & UnicodeJoin(gbUnicode) & " as NCodeName, TypeID as NCodeTypeID "
        sSQL &= " FROM D09T1010  WITH(NOLOCK) WHERE Disabled = 0 ORDER BY TypeID"
        dtNCodeID = ReturnDataTable(sSQL)

        'Load tdbcSalaryObjectID
        sSQL = " SELECT '%' as SalaryObjectID, " & AllName & " as SalaryObjectName, 0 As DisplayOrder" & vbCrLf
        sSQL &= " Union All" & vbCrLf
        sSQL &= " Select SalaryObjectID, SalaryObjectNameU as SalaryObjectName, 1 As DisplayOrder " & vbCrLf
        sSQL &= " From D13T1020 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where Disabled = 0 " & vbCrLf
        sSQL &= " Order by DisplayOrder"
        LoadDataSource(tdbcSalaryObjectID, sSQL, gbUnicode)
        tdbcSalaryObjectID.SelectedValue = "%"

        'Load tdbcStatusID
        sSQL = " SELECT '%' as StatusID, " & AllName & " as StatusName, 0 As DisplayOrder" & vbCrLf
        sSQL &= " Union All" & vbCrLf
        sSQL &= " Select StatusID, StatusNameU As StatusName, 1 As DisplayOrder " & vbCrLf
        sSQL &= " From D09T0111   WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where Disabled = 0 " & vbCrLf
        sSQL &= " Order by DisplayOrder,StatusName"
        LoadDataSource(tdbcStatusID, sSQL, gbUnicode)
        tdbcStatusID.SelectedValue = "%"
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If Not (tdbcBlockID.Tag Is Nothing OrElse tdbcBlockID.Tag.ToString = "") Then
            tdbcBlockID.Tag = ""
            Exit Sub
        End If
        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadTDBGridAdjustIncome("", ReturnValueC1Combo(tdbcProjectID), ReturnValueC1Combo(tdbcSalaryObjectID))
            LoadTDBGridEmp()
            Exit Sub
        End If
        LoadTDBGridAdjustIncome(ReturnValueC1Combo(tdbcBlockID), ReturnValueC1Combo(tdbcProjectID), ReturnValueC1Combo(tdbcSalaryObjectID))
        If bLoadFirst Then LoadTDBGridEmp()

        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ReturnValueC1Combo(tdbcBlockID).ToString, gsDivisionID, gbUnicode)
        tdbcDepartmentID.SelectedIndex = 0
        bValueChanged = True
    End Sub


#Region "Events tdbcDepartmentID with txtDepartmentName"

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gsDivisionID, gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
        bValueChanged = True
    End Sub
#End Region

#Region "Events tdbcSalaryObjectID"

    Private Sub tdbcSalaryObjectID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalaryObjectID.SelectedValueChanged
        If tdbcSalaryObjectID.SelectedValue Is Nothing Then
            LoadTDBGridAdjustIncome(ReturnValueC1Combo(tdbcBlockID), ReturnValueC1Combo(tdbcProjectID), "")
            LoadTDBGridEmp()
            Exit Sub
        End If
        LoadTDBGridAdjustIncome(ReturnValueC1Combo(tdbcBlockID), ReturnValueC1Combo(tdbcProjectID), ReturnValueC1Combo(tdbcSalaryObjectID))
        If bLoadFirst Then LoadTDBGridEmp()
        bValueChanged = True
    End Sub

#End Region

#Region "Events tdbcStatusID"

    Private Sub tdbcStatusID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStatusID.SelectedValueChanged
        If bLoadFirst Then LoadTDBGridEmp()
        bValueChanged = True
    End Sub

#End Region


    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcSalaryObjectID.Close, tdbcStatusID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcBlockID.Validated, tdbcSalaryObjectID.Validated, tdbcStatusID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
    Private bValueChanged As Boolean = False
    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus, tdbcDepartmentID.LostFocus, tdbcTeamID.LostFocus, tdbcSalaryObjectID.LostFocus, tdbcStatusID.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
        If bValueChanged Then
            LoadTDBGridEmp()
            bValueChanged = False
        End If
    End Sub

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcBlockID.BeforeOpen, tdbcDepartmentID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub


    Private Sub LoadtdbcNCodeID(ByVal ID As String)
        LoadDataSource(tdbcNCodeID, ReturnTableFilter(dtNCodeID, " NCodeTypeID = " & SQLString(ID)), gbUnicode)
    End Sub

    'Private Sub LoadtdbcTeamID(ByVal ID As String)
    '    If ID = "%" Then
    '        LoadDataSource(tdbcTeamID, dtTeamID, gbUnicode)
    '    Else
    '        LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID='%' Or DepartmentID = " & SQLString(ID)), gbUnicode)
    '    End If
    '    tdbcTeamID.SelectedValue = "%"
    'End Sub

    Private Sub InitForm()
        Dim sSQL As New StringBuilder(800)
        sSQL.Append("-- Khoi tao bien chi ky luong ung" & vbCrLf)
        sSQL.Append("SELECT  AttPeriodFrom, AttPeriodTo, AdvancedPeriodFrom, AdvancePeriodTo FROM	D29T0000 WITH(NOLOCK)")
        Dim dt As DataTable = ReturnDataTable(sSQL.ToString)

        If dt.Rows.Count > 0 Then
            iAttPeriodFrom = L3Int(dt.Rows(0).Item("AttPeriodFrom"))
            iAttPeriodTo = L3Int(dt.Rows(0).Item("AttPeriodTo"))
            iAdvancedPeriodFrom = L3Int(dt.Rows(0).Item("AdvancedPeriodFrom"))
            iAdvancePeriodTo = L3Int(dt.Rows(0).Item("AdvancePeriodTo"))
        End If

        c1dateVoucherDate.Value = Date.Today
        c1dateDateFrom.Value = Now.ToShortDateString
        c1dateDateTo.Value = Now.ToShortDateString

        sSQL = New StringBuilder(800)
        sSQL.Append("SELECT Convert(bit,Case when IsNull(T2.VoucherID,'') <> '' Then 1 Else 0 End) AS IsUsed," & vbCrLf)
        sSQL.Append("T1.AbsentVoucherID, T1.AbsentVoucherNo, T1.Note" & UnicodeJoin(gbUnicode) & " as Note, T1.ProjectID, T1.PayrollVoucherID " & vbCrLf)
        sSQL.Append("FROM D29T2080 T1  WITH(NOLOCK) LEFT JOIN	D13T2605 T2  WITH(NOLOCK) ON	T1.AbsentVoucherID = T2.VoucherID" & vbCrLf)
        sSQL.Append("AND T2.SalaryVoucherID = " & SQLString(_salaryVoucherID) & vbCrLf)
        sSQL.Append("AND T2.Module = 'D29'" & vbCrLf)
        sSQL.Append("WHERE 	T1.DivisionID = " & SQLString(gsDivisionID) & vbCrLf)
        sSQL.Append("AND T1.TranMonth = " & SQLNumber(giTranMonth) & vbCrLf)
        sSQL.Append("AND T1.TranYear = " & SQLNumber(giTranYear) & vbCrLf)
        sSQL.Append("ORDER BY T1.AbsentVoucherNo" & vbCrLf)
        dtGrid = ReturnDataTable(sSQL.ToString)
    End Sub

    Private Sub LoadMaster()
        dtAdjustIncomeRoot = ReturnDataTable(SQLStoreD13P2042())

        Dim sSQL As New StringBuilder("")
        Dim sPayrollVoucherID As String
        Dim sSQL1 As New StringBuilder("")

        sSQL.Append(SQLStoreD13P2600) ' 16/12/2013 id 61758

        Dim dt As DataTable = ReturnDataTable(sSQL.ToString)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                sEditTransTypeID = .Item("TransTypeID").ToString
                sEditVoucherTypeID = .Item("VoucherTypeID").ToString
                sSalCalMethodID = .Item("SalCalMethodID").ToString  '        'update 25/3/2013 incident 54141
                tdbcTransTypeID.SelectedValue = .Item("TransTypeID").ToString
                c1dateVoucherDate.Value = .Item("VoucherDate").ToString
                txtDescription.Text = .Item("Description").ToString

                sPayrollVoucherID = IIf(IsDBNull(.Item("PayrollVoucherID").ToString) Or .Item("PayrollVoucherID").ToString = "", "", .Item("PayrollVoucherID").ToString).ToString
                sSQL1.Append("Select top 1 PayrollVoucherNo From D13T0100  WITH(NOLOCK) Where PayrollVoucherID = " & SQLString(sPayrollVoucherID))
                Dim dt1 As DataTable = ReturnDataTable(sSQL1.ToString)
                dt1.Dispose()

                tdbcSalCalMethodID.SelectedValue = .Item("SalCalMethodID").ToString
                tdbcBlockID.SelectedValue = L3String(.Item("BlockID").ToString)
                tdbcDepartmentID.SelectedValue = .Item("DepartmentIDFrom").ToString
                tdbcTeamID.SelectedValue = .Item("TeamIDFrom").ToString
                c1dateDateFrom.Value = .Item("DateFrom").ToString
                c1dateDateTo.Value = .Item("DateTo").ToString

                tdbcProjectID.SelectedValue = .Item("ProjectID").ToString
                tdbcSalaryObjectID.SelectedValue = .Item("SalaryObjectID").ToString
                tdbcStatusID.SelectedValue = .Item("StatusID").ToString
                tdbcTransferMethodID.SelectedValue = .Item("TransferMethodID").ToString

                If Convert.ToInt16(.Item("Calculated")) = 1 Then
                    _calculated = 1
                    EnabledControl(False)
                Else
                    _calculated = 0
                    EnabledControl(True)
                End If

                txtDescription.Enabled = True
                txtSalaryExRate.Text = SQLNumber(.Item("SalaryExRate").ToString, D13Format.DefaultNumber2)
                txtInsExRate.Text = SQLNumber(.Item("InsExRate").ToString, D13Format.DefaultNumber2)
                chkIsAdvancedSal.Checked = L3Bool(.Item("IsAdvancedSal"))

                tdbcNCodeTypeID.SelectedValue = .Item("NCodeTypeID").ToString
                LoadtdbcNCodeID(ReturnValueC1Combo(tdbcNCodeTypeID).ToString)
                tdbcNCodeID.SelectedValue = .Item("NCodeID").ToString

                chkIsEmpWorking.Checked = L3Bool(.Item("IsEmpWorking"))
                chkIsExceptMaterity.Checked = L3Bool(.Item("IsIncludeMaternityEmps")) '(ReturnValueC1Combo(tdbcTransTypeID, "IsExceptMaterity"))
                chkIsExceptNotIncomeAdjust.Checked = L3Bool(.Item("IsExceptNotIncomeAdjust")) ' L3Bool(ReturnValueC1Combo(tdbcTransTypeID, "ExceptNotIncomeAdjust"))
                chkIsExceptNotAttendence.Checked = L3Bool(.Item("IsExceptNotAttendence")) ' L3Bool(ReturnValueC1Combo(tdbcTransTypeID, "ExceptNotAttendence"))
                chkIsEmpStopWorking.Checked = L3Bool(.Item("IsEmpStopWorking")) 'L3Bool(ReturnValueC1Combo(tdbcTransTypeID, "IsEmpStopWorking"))
                If L3Int(.Item("IsObjectTypeCaculateSal")) = 0 Then
                    optIsObjectTypeCaculateSal0.Checked = True
                ElseIf L3Int(.Item("IsObjectTypeCaculateSal")) = 1 Then
                    optIsObjectTypeCaculateSal1.Checked = True
                Else
                    optIsObjectTypeCaculateSal2.Checked = True
                End If

            End With
        End If
        LoadTDBGridAdjustIncome(ReturnValueC1Combo(tdbcBlockID), ReturnValueC1Combo(tdbcProjectID), ReturnValueC1Combo(tdbcSalaryObjectID))
        LoadTDBGridEmp()
    End Sub

    Private Sub LoadTDBGridAdjustIncome(ByVal sBlockID As String, ByVal sProjectID As String, ByVal sSalaryObjectID As String)
        If dtAdjustIncomeRoot Is Nothing Then Exit Sub

        ResetFilter(tdbgAdjustIncome, sFilterAdjustIncome, bRefreshFilterAdjustIncome)
        Dim sFilterBlockID As String = "(BlockID ='%' Or BlockID ='' Or BlockID = " & SQLString(sBlockID) & ")"
        Dim sFilterSalaryObjectID As String = "(SalaryObjectID ='%' Or SalaryObjectID ='' Or SalaryObjectID = " & SQLString(sSalaryObjectID) & ")"
        Dim sFilterProjectID As String = "(ProjectID ='%' Or ProjectID ='' Or ProjectID = " & SQLString(sProjectID) & ")"


        If (sProjectID = "" OrElse sProjectID = "%") And (sBlockID = "" OrElse sBlockID = "%") And (sSalaryObjectID = "" OrElse sSalaryObjectID = "%") Then
            dtGridAdjustIncome = dtAdjustIncomeRoot.Copy()

        ElseIf (sProjectID = "" OrElse sProjectID = "%") And (sBlockID <> "" And sBlockID <> "%") And (sSalaryObjectID <> "" And sSalaryObjectID <> "%") Then
            dtGridAdjustIncome = ReturnTableFilter(dtAdjustIncomeRoot, sFilterBlockID & " And " & sFilterSalaryObjectID, True)

        ElseIf (sBlockID = "" OrElse sBlockID = "%") And (sProjectID <> "" And sProjectID <> "%") And (sSalaryObjectID <> "" And sSalaryObjectID <> "%") Then
            dtGridAdjustIncome = ReturnTableFilter(dtAdjustIncomeRoot, sFilterProjectID & " And " & sFilterSalaryObjectID, True)

        ElseIf (sSalaryObjectID = "" OrElse sSalaryObjectID = "%") And (sProjectID <> "" And sProjectID <> "%") And (sBlockID <> "" And sBlockID <> "%") Then
            dtGridAdjustIncome = ReturnTableFilter(dtAdjustIncomeRoot, sFilterProjectID & " And " & sFilterBlockID, True)

        ElseIf (sSalaryObjectID = "" OrElse sSalaryObjectID = "%") And (sBlockID = "" OrElse sBlockID = "%") And (sProjectID <> "" And sProjectID <> "%") Then
            dtGridAdjustIncome = ReturnTableFilter(dtAdjustIncomeRoot, sFilterProjectID, True)

        ElseIf (sSalaryObjectID = "" OrElse sSalaryObjectID = "%") And (sProjectID = "" OrElse sProjectID = "%") And (sBlockID <> "" And sBlockID <> "%") Then
            dtGridAdjustIncome = ReturnTableFilter(dtAdjustIncomeRoot, sFilterBlockID, True)

        ElseIf (sProjectID = "" OrElse sProjectID = "%") And (sBlockID = "" OrElse sBlockID = "%") And (sSalaryObjectID <> "" And sSalaryObjectID <> "%") Then
            dtGridAdjustIncome = ReturnTableFilter(dtAdjustIncomeRoot, sFilterSalaryObjectID, True)

        Else
            dtGridAdjustIncome = ReturnTableFilter(dtAdjustIncomeRoot, sFilterProjectID & " And " & sFilterBlockID & " And " & sFilterSalaryObjectID, True)
        End If

        LoadDataSource(tdbgAdjustIncome, dtGridAdjustIncome, gbUnicode)
        ReLoadTDBGridAdjustIncome()
    End Sub

    Private Sub ReLoadTDBGridAdjustIncome()

        'Xét các dòng có VoucherTypeID = 1 trên lưới dữ liệu đầu vào.
        '#check Lương ứng#
        'Nếu không check lương ứng thì lưới dữ liệu đầu vào chỉ hiển thị dòng có IsAdvancedSal = 0 và check chọn những dòng này.
        'Ngược lại nếu có check chọn lương ứng thì lưới dữ liệu đầu vào chỉ hiển thị những dòng có IsAdvancedSal = 1 và check chọn những dòng này.
        Dim strFind As String = "(VoucherTypeID <> 1) or (VoucherTypeID = 1 and IsAdvancedSal = " & SQLNumber(chkIsAdvancedSal.Checked) & ")"

        If sFilterAdjustIncome.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilterAdjustIncome.ToString
        dtGridAdjustIncome.DefaultView.RowFilter = strFind
        ResetGridAdjustIncome()
    End Sub

    Private Sub ResetGridAdjustIncome()
        FooterTotalGrid(tdbgAdjustIncome, COLA_VoucherTypeName)
    End Sub

    Private gbEnabledUseFind As Boolean = False

    Private Sub LoadTDBGridEmp()
        ResetFilter(tdbgEmp, sFilterEmp, bRefreshFilterEmp)
        Dim iMode As Integer = L3Int(IIf(_FormState = EnumFormState.FormAdd, 0, 1))
        If bLoadFirst = False AndAlso _formCall = "D13F2040" AndAlso (_FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormView) Then iMode = 2 'Load lần đầu và gọi từ màn hình F2040 ở Mode xem  và sửa.
        Dim sSQL As String = SQLStoreD13P2044(iMode)
        dtGridEmp = ReturnDataTable(sSQL)
        gbEnabledUseFind = dtGridEmp.Rows.Count > 0

        LoadDataSource(tdbgEmp, dtGridEmp, gbUnicode)
        ReLoadTDBGridEmp()
    End Sub

    Private Sub ReLoadTDBGridEmp()
        Dim strFind As String = sFind
        If sFilterEmp.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilterEmp.ToString
        If chkShowSelected.Checked Then
            strFind = "IsUsed =1"
        Else
            If strFind <> "" Then strFind &= " OR IsUsed =1"
        End If
        dtGridEmp.DefaultView.RowFilter = strFind
        ResetGridEmp()
    End Sub

    Private Sub ResetGridEmp()
        FooterTotalGrid(tdbgEmp, COLE_EmployeeID)
        mnsFind.Enabled = (Not chkShowSelected.Checked) And (gbEnabledUseFind Or tdbgEmp.RowCount > 0) 'Mờ khi  chkIsUsed.Checked = True
        mnsListAll.Enabled = mnsFind.Enabled
    End Sub

    Private Sub EnabledControl(ByVal bFlag As Boolean)
        tdbcSalCalMethodID.Enabled = bFlag
        tdbcBlockID.Enabled = D13Systems.IsUseBlock AndAlso bFlag
        tdbcTeamID.Enabled = bFlag
        tdbcDepartmentID.Enabled = bFlag

        tdbcSalaryObjectID.Enabled = bFlag
        tdbcStatusID.Enabled = bFlag

        c1dateDateFrom.Enabled = bFlag
        c1dateDateTo.Enabled = bFlag
        tdbcProjectID.Enabled = bFlag
        tdbcTransferMethodID.Enabled = bFlag
        tdbcNCodeTypeID.Enabled = bFlag
        tdbcNCodeID.Enabled = bFlag

        tdbgAdjustIncome.AllowUpdate = bFlag

        txtSalaryExRate.Enabled = bFlag
        txtInsExRate.Enabled = bFlag

        chkIsAdvancedSal.Enabled = bFlag

        tdbgEmp.AllowUpdate = bFlag
        btnSalCalculation.Enabled = bFlag
    End Sub

    Private Function AllowSave(ByRef drEmp() As DataRow) As Boolean
        If _FormState = EnumFormState.FormAdd Then
            If tdbcTransTypeID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Mau_thiet_lapU"))
                tdbcTransTypeID.Focus()
                Return False
            End If
        End If
        If CDate(c1dateDateFrom.Value) > CDate(c1dateDateTo.Value) Then
            D99C0008.MsgL3(rL3("Gia_tri_Tu_ngay_khong_duoc_lon_hon_gia_tri_Den_ngay"))
            c1dateDateFrom.Focus()
            Return False
        End If
        If tdbcSalCalMethodID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("PP_tinh_luong"))
            tdbcSalCalMethodID.Focus()
            Return False
        End If
        If txtDescription.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Dien_giai"))
            txtDescription.Focus()
            Return False
        End If

        If tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblBlockID.Text)
            tdbcBlockID.Focus()
            Return False
        End If

        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If

        dtGridEmp.AcceptChanges()
        drEmp = dtGridEmp.Select("IsUsed = 1")
        If drEmp.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            VisibletdbgEmp(True)
            tdbgEmp.Focus()
            tdbgEmp.SplitIndex = 0
            tdbgEmp.Col = COLE_IsUsed
            tdbgEmp.Row = 0
            Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If bOnCalculating Then Exit Sub
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbgEmp.UpdateData()
        tdbgAdjustIncome.UpdateData()

        Dim drEmp() As DataRow = Nothing
        If Not AllowSave(drEmp) Then Exit Sub
        'Kiểm tra ngày phiếu có phù hợp trog kỳ kế toán hiện tại hay không
        If Not CheckVoucherDateInPeriod(c1dateVoucherDate.Value.ToString) Then Exit Sub
        Dim sSQL As New StringBuilder("")
        btnSave.Enabled = False
        btnClose.Enabled = False
        _bSaved = False

        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD13T2600.ToString() & vbCrLf)
                sSQL.Append(SQLDeleteD13T2605.ToString() & vbCrLf)
                sSQL.Append(SQLInsertD13T2605s.ToString() & vbCrLf)
                sSQL.Append(SQLInsertD13T0113s(drEmp).ToString() & vbCrLf)
                'Audit
                sSQL.Append(SQLStoreD09P6210("SalaryCalculation", _salaryVoucherID, "01", "", txtDescription.Text) & vbCrLf)
            Case EnumFormState.FormEdit
                If _calculated = 0 Then ' Bổ sung lại theo ID 75781 TuanVu yeu cau
                    sSQL.Append(SQLStoreD09P6200("D13T2600", "SalaryVoucherID", _salaryVoucherID, 0, "SalaryVoucherID") & vbCrLf)
                    sSQL.Append(SQLUpdateD13T2600(0).ToString() & vbCrLf)
                    sSQL.Append(SQLDeleteD13T2605.ToString() & vbCrLf)
                    sSQL.Append(SQLInsertD13T2605s.ToString() & vbCrLf)
                    sSQL.Append(SQLDeleteD13T0113() & vbCrLf)
                    sSQL.Append(SQLInsertD13T0113s(drEmp).ToString() & vbCrLf)
                    sSQL.Append(SQLStoreD09P6200("D13T2600", "SalaryVoucherID", _salaryVoucherID, 1, "SalaryVoucherID") & vbCrLf)
                    sSQL.Append(SQLStoreD09P6210("SalaryCalculation", _salaryVoucherID, "02", "", txtDescription.Text) & vbCrLf)
                Else
                    sSQL.Append(SQLUpdateD13T2600(1).ToString()) ' Chỉ sửa diễn giải
                End If
        End Select

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            sSQL.Remove(0, sSQL.Length)

            SaveOK()
            _bSaved = True
            If _calculated = 0 Then btnSalCalculation.Enabled = True ' Chưa tính lương mới sáng Nút tính lương 
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnClose.Enabled = True
                    btnSalCalculation.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    Me.SelectNextControl(btnSave, True, True, True, True)
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Events tdbcProjectID with txtProjectName load tdbcDayVoucherNoTo"

    Private Sub tdbcProjectID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcProjectID.Close
        If tdbcProjectID.FindStringExact(tdbcProjectID.Text) = -1 Then
            tdbcProjectID.Text = ""
        End If
    End Sub

    Private Sub tdbcProjectID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcProjectID.SelectedValueChanged
        If Not (tdbcProjectID.Tag Is Nothing OrElse tdbcProjectID.Tag.ToString = "") Then
            tdbcProjectID.Tag = ""
            Exit Sub
        End If
        If tdbcProjectID.SelectedValue Is Nothing Then
            LoadTDBGridAdjustIncome(ReturnValueC1Combo(tdbcBlockID), "", ReturnValueC1Combo(tdbcSalaryObjectID))
            LoadTDBGridEmp()
            Exit Sub
        End If
        LoadTDBGridAdjustIncome(ReturnValueC1Combo(tdbcBlockID), ReturnValueC1Combo(tdbcProjectID), ReturnValueC1Combo(tdbcSalaryObjectID))
        If bLoadFirst Then LoadTDBGridEmp()
    End Sub

#End Region

#Region "txtSalaryExRate event"

    Private Sub txtSalaryExRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalaryExRate.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtInsExRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInsExRate.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtSalaryExRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalaryExRate.LostFocus
        If IsNumeric(txtSalaryExRate.Text) Then
            If Number(txtSalaryExRate.Text) > MaxDecimal Then
                txtSalaryExRate.Text = SQLNumber(0, D13Format.DefaultNumber2)
            Else
                txtSalaryExRate.Text = SQLNumber(txtSalaryExRate.Text, D13Format.DefaultNumber2)
            End If
        Else
            txtSalaryExRate.Text = SQLNumber(0, D13Format.DefaultNumber2)
        End If
    End Sub

    Private Sub txtInsExRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInsExRate.LostFocus
        If IsNumeric(txtInsExRate.Text) Then
            If Number(txtInsExRate.Text) > MaxDecimal Then
                txtInsExRate.Text = SQLNumber(0, D13Format.DefaultNumber2)
            Else
                txtInsExRate.Text = SQLNumber(txtInsExRate.Text, D13Format.DefaultNumber2)
            End If
        Else
            txtInsExRate.Text = SQLNumber(0, D13Format.DefaultNumber2)
        End If
    End Sub

#End Region

#Region "Events tdbcNCodeTypeID load tdbcNCodeID"

    Private Sub tdbcNCodeTypeID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNCodeTypeID.GotFocus
        'Dùng phím Enter
        tdbcNCodeTypeID.Tag = tdbcNCodeTypeID.Text
    End Sub

    Private Sub tdbcNCodeTypeID_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbcNCodeTypeID.MouseDown
        'Di chuyển chuột
        tdbcNCodeTypeID.Tag = tdbcNCodeTypeID.Text
    End Sub

    Private Sub tdbcNCodeTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNCodeTypeID.SelectedValueChanged
        tdbcNCodeID.Text = ""
        'If bLoadFirst Then LoadTDBGridEmp()
    End Sub

    Private Sub tdbcNCodeTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNCodeTypeID.LostFocus
        If tdbcNCodeTypeID.Tag.ToString = "" And tdbcNCodeTypeID.Text = "" Then Exit Sub
        If tdbcNCodeTypeID.Tag.ToString = tdbcNCodeTypeID.Text And tdbcNCodeTypeID.SelectedValue IsNot Nothing Then Exit Sub
        If tdbcNCodeTypeID.FindStringExact(tdbcNCodeTypeID.Text) = -1 Then
            tdbcNCodeTypeID.Text = ""
            LoadtdbcNCodeID("-1")
            tdbcNCodeID.Text = ""
            Exit Sub
        End If
        LoadtdbcNCodeID(ReturnValueC1Combo(tdbcNCodeTypeID).ToString())
        tdbcNCodeID.Text = ""
    End Sub

    Private Sub tdbcNCodeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcNCodeID.LostFocus
        If tdbcNCodeID.FindStringExact(tdbcNCodeID.Text) = -1 Then tdbcNCodeID.Text = ""
    End Sub

#End Region


    ' 30/6/2014 id 66949 - Phòng  ban, Tổ nhóm, Dự án, Mã PTNS: Thực hiện sự kiện lost forcus tại các combo này, đổ nguồn cho lưới danh sách nhân viên.
    'Private Sub tdbcName1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcProjectID.Validated, tdbcNCodeTypeID.Validated, tdbcNCodeID.Validated
    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    tdbc.Text = tdbc.WillChangeToText
    '    LoadTDBGridEmp()
    'End Sub

    Private Sub D13F2041_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormEdit OrElse _FormState = EnumFormState.FormView Then
            If txtDescription.Enabled Then txtDescription.Focus()
        End If
    End Sub

    ' 6/2/2013 id 61827
    Private Sub chkIsAdvancedSal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsAdvancedSal.CheckedChanged
        If dtGridAdjustIncome Is Nothing Then Exit Sub

        ReLoadTDBGridAdjustIncome()
    End Sub

    Private Sub chkIsAdvancedSal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsAdvancedSal.Click
        LoadTime()
    End Sub

    Private Sub chkShowSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowSelected.CheckedChanged
        If dtGridEmp Is Nothing Then Exit Sub
        ReLoadTDBGridEmp()
    End Sub

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    'Cần sửa Tìm kiếm như sau:
    'Bỏ sự kiện Finder_FindClick.
    'Sửa tham số Me.Name -> Me
    'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
    'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGridEmp() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property


    'Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbgEmp.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COLE_IsUsed, COLE_EmployeeID}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbgEmp.Splits.Count - 1
            AddColVisible(tdbgEmp, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbgEmp, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGridEmp()
    '    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbgEmp, sFilterEmp, bRefreshFilterEmp)
        ReLoadTDBGridEmp()
    End Sub

#End Region

#Region "tdbgAdjustIncome event"

    Dim sFilterAdjustIncome As New System.Text.StringBuilder()
    Dim bRefreshFilterAdjustIncome As Boolean = False
    Private Sub tdbgAdjustIncome_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgAdjustIncome.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilterAdjustIncome Then Exit Sub
            FilterChangeGrid(tdbgAdjustIncome, sFilterAdjustIncome) 'Nếu có Lọc khi In
            ReLoadTDBGridAdjustIncome()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbgAdjustIncome_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgAdjustIncome.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbgAdjustIncome, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbgAdjustIncome_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgAdjustIncome.KeyPress
        Select Case tdbgAdjustIncome.Col
            Case COLA_IsUse
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Private Sub tdbgAdjustIncome_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgAdjustIncome.HeadClick
        If tdbgAdjustIncome.RowCount <= 0 Then Exit Sub
        If _calculated = 1 Then Exit Sub ' Tính lương rồi không cho HeadClick
        If e.ColIndex = COLA_IsUse Then
            tdbgAdjustIncome.AllowSort = False
            Dim bFlag As Boolean = Not L3Bool(tdbgAdjustIncome(0, COLA_IsUse).ToString)
            For i As Integer = 0 To tdbgAdjustIncome.RowCount - 1
                tdbgAdjustIncome(i, COLA_IsUse) = bFlag
            Next
        Else
            tdbgAdjustIncome.AllowSort = True
        End If
    End Sub

#End Region

#Region "tdbgEmp event"

    Dim sFilterEmp As New System.Text.StringBuilder()
    Dim bRefreshFilterEmp As Boolean = False

    Private Sub tdbgEmp_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgEmp.AfterColUpdate
        Select Case e.ColIndex
            Case COLE_IsUsed
                tdbgEmp.UpdateData()
        End Select
    End Sub

    Private Sub tdbgEmp_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgEmp.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilterEmp Then Exit Sub
            FilterChangeGrid(tdbgEmp, sFilterEmp) 'Nếu có Lọc khi In
            ReLoadTDBGridEmp()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbgEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgEmp.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbgEmp, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbgEmp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgEmp.KeyPress
        Select Case tdbgEmp.Col
            Case COLE_IsUsed
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Dim bSelectedEmp As Boolean = False
    Private Sub tdbgEmp_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgEmp.HeadClick
        If tdbgEmp.RowCount <= 0 Then Exit Sub
        Select Case e.ColIndex
            Case COLE_IsUsed
                If tdbgEmp.AllowUpdate Then L3HeadClick(tdbgEmp, e.ColIndex, bSelectedEmp)
            Case Else
                tdbgEmp.AllowSort = True
        End Select
    End Sub

#End Region

#Region "Tính lương"

    Private Sub DoTask()
        Me.Cursor = Cursors.WaitCursor
        btnSalCalculation.Enabled = False
        btnClose.Enabled = False
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
        tmr1.Enabled = True
        pnlPic.Visible = True
        bOnCalculating = True
    End Sub

    Private Sub btnSalCalculation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalCalculation.Click
        bP4500 = False
        bP2110 = False
        bP2600 = False
        If _calculated = 1 Then
            If ExistRecord("Select Top 1 1 From D13T2074  WITH(NOLOCK) Where SalaryVoucherID = " & SQLString(_salaryVoucherID)) Then
                D99C0008.MsgL3(rL3("Phieu_nay_da_duoc_su_dung_Ban_khong_the_tinh_lai"))
                Exit Sub
            End If
            DoTask()
        Else
            DoTask()
            If _calculated = 0 Then
                EnabledControl(False)
            End If
        End If
    End Sub

    Dim startDate As DateTime
    Private Sub tmr1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr1.Tick

        'If bP4500 Then
        '    If pgb1.Value >= 5000 Then
        '        bP4500 = False
        '    Else
        '        pgb1.PerformStep()
        '    End If

        'ElseIf bP4500 = False And bP2110 = False And bP2600 = False And pgb1.Value < 5000 Then
        '    Dim v1 As Long = startDate.Hour * 10000 + startDate.Minute * 100 + startDate.Second
        '    Dim v2 As Long = Now.Hour * 10000 + Now.Minute * 100 + Now.Second
        '    If v2 - v1 >= 30 Then
        '        pgb1.PerformStep()
        '        startDate = Now
        '    End If


        'ElseIf bP2110 Then
        '    If pgb1.Value >= 5500 Then
        '        bP2110 = False
        '    Else
        '        pgb1.PerformStep()
        '    End If

        'ElseIf bP2600 Then
        '    If pgb1.Value >= 6000 Then
        '        LoadResult()
        '    Else
        '        pgb1.PerformStep()
        '    End If
        'End If

        If bP2600 Then
            pnlPic.Visible = False
            LoadResult()
        End If

    End Sub

    Private Sub MuchTimeWork()
        Dim sSQL As New StringBuilder("")

        startDate = Now

        'Tính lại bảng lương
        sSQL = New StringBuilder("")
        sSQL.Append(SQLStoreD13P4500())

        bP4500 = CheckStoreShowMSGVB(sSQL.ToString)
        If bP4500 Then
            'Tính lương thành công trả về _calculated = 1 
            If _calculated = 0 Then _calculated = 1

            'Kiểm tra phiếu này có dùng phương pháp chuyển bút toán không
            sSQL = New StringBuilder("")
            sSQL.Append("Select TransferMethodID From D13T2600  WITH(NOLOCK) Where DivisionID = " & SQLString(gsDivisionID) & " And TranMonth = " & giTranMonth & " And ")
            sSQL.Append("TranYear = " & giTranYear & " And SalaryVoucherID = " & SQLString(_salaryVoucherID))
            Dim sRet As String = ReturnScalar(sSQL.ToString)
            If sRet <> "" Then
                sSQL = New StringBuilder("")
                sSQL.Append(SQLStoreD13P2110())
                If ExecuteSQL(sSQL.ToString) = True Then bP2110 = True
            End If

            'Cập nhật thông tin thay đổi
            sSQL = New StringBuilder("")
            sSQL.Append("Update D13T2600 Set ")
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
            sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
            sSQL.Append(" Where ")
            sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & " And ")
            sSQL.Append("SalaryVoucherID = " & SQLString(_salaryVoucherID) & vbCrLf)

            sSQL.Append(SQLStoreD13P4600()) '14/7/2014, 58418-Tự động san công khi tính lương vá tính lương với dữ liệu sau san công 	

            If ExecuteSQL(sSQL.ToString) Then bP2600 = True : _bSaved = True
        Else
            'D99C0008.MsgL3(rl3("Tinh_luong_khong_thanh_cong_Vui_long_kiem_tra_lai_phuong_phap_tinh_luong"))

            tmr1.Enabled = False
            pnlPic.Visible = False
            Me.Cursor = Cursors.Default

            bOnCalculating = False
        End If
    End Sub

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        MuchTimeWork()
    End Sub

    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        If Not bP4500 Then
            'Update 20/12/2011: Incident 42925
            'D99C0008.MsgL3(rl3("Tinh_luong_khong_thanh_cong_Vui_long_kiem_tra_lai_phuong_phap_tinh_luong"))
        End If
    End Sub

    Private Sub LoadResult()
        If bP2600 Then
            Me.Cursor = Cursors.Default

            bP2600 = False
            Dim sSQL As New StringBuilder("")
            '21/11/2013 id 59979 - bo HSL tháng
            LoadResultSalCal("", "", _salaryVoucherID, gsPayRollVoucherID, ReturnValueC1Combo(tdbcSalCalMethodID).ToString, ReturnValueC1Combo(tdbcTransferMethodID).ToString, c1dateVoucherDate.Text, txtDescription.Text)
            'LoadResultSalCal(txtSalaryVoucherNo.Text, ReturnValueC1Combo(tdbcPayrollVoucherNo).ToString, _salaryVoucherID, tdbcPayrollVoucherNo.Columns(0).Value.ToString, ReturnValueC1Combo(tdbcSalCalMethodID).ToString, ReturnValueC1Combo(tdbcTransferMethodID).ToString, c1dateVoucherDate.Text, txtDescription.Text)
            Lemon3.D91.RunAuditLog("13", "SalaryCalTrans", "02", c1dateVoucherDate.Value.ToString, "", txtDescription.Text, "", ReturnValueC1Combo(tdbcSalCalMethodID).ToString)
            tmr1.Enabled = False
            pnlPic.Visible = False
            bOnCalculating = False
            If _calculated = 0 Then btnSalCalculation.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    '    ' Update 10/10/2012 id 51772 - Lỗi hiển thị thông báo khi tính lương
    '    ''' <summary>
    '    ''' Kiểm tra dữ liệu bằng Store (HÀM MỚI) dạng thông báo do store tự trả ra
    '    ''' </summary>
    '    ''' <param name="SQL">Store cần kiểm tra</param>
    '    ''' <returns>Trả về True nếu kiểm tra không có lỗi, ngược lại trả về False</returns>
    '    ''' <remarks>Chú ý: Kết quả trả ra của Store phải có dạng là 1 hàng và 4 cột là Status, Message, FontMessage, MsgAsk</remarks>
    '    Public Function CheckStoreShowMSGVB(ByVal SQL As String) As Boolean
    '        'Update 1/03/2010: sửa lại hàm checkstore có trả ra field FontMessage
    '        'Cách kiểm tra của hàm CheckStore này sẽ như sau:
    '        'Nếu store trả ra Status <> 0 thì xuất Message theo dạng FontMessage
    '        'Nếu store trả ra MsgAsk = 0 thì xuất Message nút Ok,  MsgAsk = 1 thì xuất Message nút Yes, No
    '
    '        Dim dt As New DataTable
    '        Dim sMsg As String
    '        Dim bMsgAsk As Boolean = False
    '        dt = ReturnDataTable(SQL)
    '        If dt.Rows.Count > 0 Then
    '            If dt.Rows(0).Item("Status").ToString = "0" Then
    '                dt = Nothing
    '                Return True
    '            End If
    '
    '            sMsg = dt.Rows(0).Item("Message").ToString
    '            Dim bFontMessage As Boolean = False
    '            If dt.Columns.Contains("FontMessage") Then bFontMessage = True
    '            If dt.Columns.Contains("MsgAsk") Then
    '                If L3Byte(dt.Rows(0).Item("MsgAsk")) = 1 Then
    '                    bMsgAsk = True
    '                End If
    '            End If
    '
    '            If Not bMsgAsk Then 'OKOnly
    '                If Not bFontMessage Then
    '                    MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Else
    '                    Select Case dt.Rows(0).Item("FontMessage").ToString
    '                        Case "0" 'VietwareF
    '                            MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        Case "1" 'Unicode
    '                            ' D99C0008.MsgL3(sMsg, L3MessageBoxIcon.Exclamation)
    '                            MessageBox.Show(ConvertUnicodeToVietwareF(sMsg), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
    '                        Case "2" 'Convert Vni To Unicode
    '                            D99C0008.MsgL3(ConvertVniToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
    '                    End Select
    '                End If
    '                dt = Nothing
    '                Return False
    '            Else 'YesNo
    '                If Not bFontMessage Then
    '                    If MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
    '                        dt = Nothing
    '                        Return True
    '                    Else
    '                        dt = Nothing
    '                        Return False
    '                    End If
    '                Else
    '                    Select Case dt.Rows(0).Item("FontMessage").ToString
    '                        Case "0" 'VietwareF
    '                            If MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
    '                                dt = Nothing
    '                                Return True
    '                            Else
    '                                dt = Nothing
    '                                Return False
    '                            End If
    '                        Case "1" 'Unicode
    '                            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
    '                                dt = Nothing
    '                                Return True
    '                            Else
    '                                dt = Nothing
    '                                Return False
    '                            End If
    '                        Case "2" 'Convert Vni To Unicode
    '                            If D99C0008.MsgAsk(ConvertVniToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
    '                                dt = Nothing
    '                                Return True
    '                            Else
    '                                dt = Nothing
    '                                Return False
    '                            End If
    '                    End Select
    '                End If
    '            End If
    '            dt = Nothing
    '        Else
    '            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
    '            Return False
    '        End If
    '        Return True
    '    End Function
#End Region

#Region "SQL"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6868
    '# Created User: Lê Anh Vũ
    '# Created Date: 16/06/2015 02:11:51
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P6868() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load Combo du an" & vbCrLf)
        sSQL &= "Exec D09P6868 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F2040") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString("Project") & COMMA 'TypeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsMSS, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2600
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 30/03/2007 03:50:29
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2600() As StringBuilder
        Dim sSQL As New StringBuilder
        _salaryVoucherID = CreateIGE("D13T2600", "SalaryVoucherID", "13", "SV", gsStringKey)

        sSQL.Append("Insert Into D13T2600(")
        sSQL.Append("DivisionID, SalaryVoucherID, TranMonth, TranYear, ")
        sSQL.Append("VoucherDate, Description, DescriptionU, SalCalMethodID, PayrollVoucherID, ")
        sSQL.Append("Calculated, IsDate, DateFrom, DateTo, ") 'GAProjectID, 
        sSQL.Append("DayVoucherTypeID, DayVoucherNoFrom, DayVoucherNoTo, ")
        sSQL.Append("DepartmentIDFrom, DepartmentIDTo, CreateUserID, LastModifyUserID, ")
        sSQL.Append("CreateDate, LastModifyDate, TeamIDFrom, TeamIDTo, ") ' 
        sSQL.Append("TransferMethodID, ProjectID, TransTypeID, SalaryExRate, InsExRate, IsAdvancedSal, " & vbCrLf)
        sSQL.Append("NCodeTypeID, NCodeID, DepartmentID, TeamID, " & vbCrLf)
        sSQL.Append("IsIncludeMaternityEmps, IsEmpWorking, IsEmpStopWorking, IsExceptNotAttendence, IsExceptNotIncomeAdjust, ")
        sSQL.Append("IsObjectTypeCaculateSal,BlockID,SalaryObjectID,StatusID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(_salaryVoucherID) & COMMA) 'SalaryVoucherID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Value) & COMMA) 'VoucherDate, datetime, NULL
        sSQL.Append(SQLStringUnicode(txtDescription, False) & COMMA) 'Description, varchar[150], NULL
        sSQL.Append(SQLStringUnicode(txtDescription, True) & COMMA) 'DescriptionU, varchar[150], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcSalCalMethodID)) & COMMA) 'SalCalMethodID, varchar[20], NULL
        '21/11/2013 id 59979 - bo HSL tháng
        sSQL.Append(SQLString(gsPayRollVoucherID) & COMMA) 'PayrollVoucherID, varchar[20], NULL
        ' sSQL.Append(SQLString(ReturnValueC1Combo(tdbcPayrollVoucherNo, "PayrollVoucherID")) & COMMA) 'PayrollVoucherID, varchar[20], NULL
        sSQL.Append(SQLNumber("0") & COMMA) 'Calculated, tinyint, NOT NULL
        sSQL.Append(SQLNumber("0") & COMMA) 'IsDate, tinyint, NOT NULL
        sSQL.Append(SQLDateSave(c1dateDateFrom.Value) & COMMA) 'DateFrom, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateDateTo.Value) & COMMA) 'DateTo, datetime, NULL
        sSQL.Append(SQLString("") & COMMA) 'DayVoucherTypeID, varchar[20], NULL
        sSQL.Append(SQLString("") & COMMA) 'DayVoucherNoFrom, varchar[20], NULL
        sSQL.Append(SQLString("") & COMMA) 'DayVoucherNoTo, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'DepartmentIDFrom, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'DepartmentIDTo, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'TeamIDFrom, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'TeamIDTo, varchar[20], NULL

        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTransferMethodID)) & COMMA) 'TransferMethodID, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcProjectID)) & COMMA) 'ProjectID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTransTypeID)) & COMMA) 'TransTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLMoney(txtSalaryExRate.Text, D13Format.DefaultNumber2) & COMMA) 'SalaryExRate, decimal, NOT NULL
        sSQL.Append(SQLMoney(txtInsExRate.Text, D13Format.DefaultNumber2) & COMMA) 'InsExRate, decimal, NOT NULL
        sSQL.Append(SQLNumber(chkIsAdvancedSal.Checked) & COMMA & vbCrLf)
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcNCodeTypeID)) & COMMA) 'NCodeTypeID, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcNCodeID)) & COMMA) 'NCodeID, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'DepartmentIDFrom, varchar[20], NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'TeamIDFrom, varchar[20], NULL
        sSQL.Append(SQLNumber(chkIsExceptMaterity.Checked) & COMMA) 'IsIncludeMaternityEmps, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkIsEmpWorking.Checked) & COMMA) 'IsEmpWorking, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkIsEmpStopWorking.Checked) & COMMA) 'IsEmpStopWorking, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkIsExceptNotAttendence.Checked) & COMMA) 'IsExceptNotAttendence, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkIsExceptNotIncomeAdjust.Checked) & COMMA) 'IsExceptNotIncomeAdjust, tinyint, NOT NULL
        If optIsObjectTypeCaculateSal0.Checked = True Then
            sSQL.Append(SQLNumber(0) & COMMA) 'IsObjectTypeCaculateSal, tinyint, NOT NULL
        ElseIf optIsObjectTypeCaculateSal1.Checked = True Then
            sSQL.Append(SQLNumber(1) & COMMA) 'IsObjectTypeCaculateSal, tinyint, NOT NULL
        Else
            sSQL.Append(SQLNumber(2) & COMMA) 'IsObjectTypeCaculateSal, tinyint, NOT NULL
        End If
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA) 'BlockID,  varchar[20], NULL
        'ID 98198 11.07.2017
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcSalaryObjectID)) & COMMA) 'SalaryObjectID, varchar[20], NULL
        'ID 108128 21.05.2018
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcStatusID))) 'StatusID, varchar[20], NULL
        sSQL.Append(")" & vbCrLf)

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2600
    '# Created User: Lê Anh Vũ
    '# Created Date: 16/06/2015 02:25:52
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2600(ByVal icalculated As Integer) As StringBuilder
        Dim sSQL As New StringBuilder
        If icalculated = 0 Then
            sSQL.Append("Update D13T2600 Set ")
            sSQL.Append("VoucherDate = " & SQLDateSave(c1dateVoucherDate.Value) & COMMA) 'datetime, NULL
            sSQL.Append("Description = " & SQLStringUnicode(txtDescription, False) & COMMA) 'varchar[150], NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription, True) & COMMA) 'varchar[150], NULL
            sSQL.Append("SalCalMethodID = " & SQLString(ReturnValueC1Combo(tdbcSalCalMethodID)) & COMMA) 'varchar[20], NULL
            '21/11/2013 id 59979 - bo HSL tháng
            sSQL.Append("PayrollVoucherID = " & SQLString(gsPayRollVoucherID) & COMMA) 'varchar[20], NULL
            'sSQL.Append("PayrollVoucherID = " & SQLString(ReturnValueC1Combo(tdbcPayrollVoucherNo, "PayrollVoucherID")) & COMMA) 'varchar[20], NULL
            sSQL.Append("DateFrom = " & SQLDateSave(c1dateDateFrom.Value) & COMMA) 'datetime, NULL
            sSQL.Append("DateTo = " & SQLDateSave(c1dateDateTo.Value) & COMMA) 'datetime, NULL
            sSQL.Append("DayVoucherTypeID = " & SQLString("") & COMMA) 'varchar[20], NULL
            sSQL.Append("DayVoucherNoFrom = " & SQLString("") & COMMA) 'varchar[20], NULL
            sSQL.Append("DayVoucherNoTo = " & SQLString("") & COMMA) 'varchar[20], NULL
            sSQL.Append("DepartmentIDFrom = " & SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("DepartmentIDTo = " & SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
            sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
            sSQL.Append("TeamIDFrom = " & SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("TeamIDTo = " & SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("TransferMethodID = " & SQLString(ReturnValueC1Combo(tdbcTransferMethodID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("ProjectID = " & SQLString(ReturnValueC1Combo(tdbcProjectID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("TransTypeID = " & SQLString(ReturnValueC1Combo(tdbcTransTypeID)) & COMMA) 'varchar[20], NOT NULL
            If chkIsAdvancedSal.Enabled Then
                sSQL.Append("IsAdvancedSal = " & SQLNumber(chkIsAdvancedSal.Checked) & COMMA)
            End If
            sSQL.Append("SalaryExRate = " & SQLMoney(txtSalaryExRate.Text, D13Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
            sSQL.Append("InsExRate = " & SQLMoney(txtInsExRate.Text, D13Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
            sSQL.Append("NCodeTypeID = " & SQLString(ReturnValueC1Combo(tdbcNCodeTypeID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("NCodeID = " & SQLString(ReturnValueC1Combo(tdbcNCodeID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("DepartmentID = " & SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("TeamID = " & SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'varchar[20], NULL
            sSQL.Append("BlockID = " & SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA) 'varchar[20], NULL
            'ID 98198 11.07.2017
            sSQL.Append("SalaryObjectID = " & SQLString(ReturnValueC1Combo(tdbcSalaryObjectID)) & COMMA) 'SalaryObjectID, varchar[20], NULL
            'ID 108128 21.05.2018
            sSQL.Append("StatusID = " & SQLString(ReturnValueC1Combo(tdbcStatusID))) 'StatusID, varchar[20], NULL
            sSQL.Append(" Where ")
            sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & " And ")
            sSQL.Append("TranMonth = " & giTranMonth & " And TranYear = " & giTranYear & " And ")
            sSQL.Append("SalaryVoucherID = " & SQLString(_salaryVoucherID))
        Else
            sSQL.Append("-- Update D13T2600 khi Caculated <> 0" & vbCrLf)
            sSQL.Append("Update D13T2600 Set ")
            sSQL.Append("Description = " & SQLStringUnicode(txtDescription, False) & COMMA) 'varchar[300], NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
            sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription, True)) 'nvarchar[300], NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & " And ")
            sSQL.Append("TranMonth = " & giTranMonth & " And TranYear = " & giTranYear & " And ")
            sSQL.Append("SalaryVoucherID = " & SQLString(_salaryVoucherID))
        End If
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4600
    '# Created User: NGOCTHOAI
    '# Created Date: 14/07/2014 10:32:03
    '14/7/2014, 58418-Tự động san công khi tính lương vá tính lương với dữ liệu sau san công 	
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4600() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tu dong san cong khi tinh luong" & vbCrLf)
        sSQL &= "Exec D13P4600 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(_calculated) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Type, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Languge, varchar[20], NOT NULL
        Return sSQL

    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4500
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 02/04/2007 10:45:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4500() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P4500 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(_calculated) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Type, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Languge, varchar[20], NOT NULL
        Return sSQL & vbCrLf
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2110
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 02/04/2007 11:04:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2110() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2110 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTransferMethodID)) & COMMA 'TransferMethodID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(_calculated) 'Mode, int, NOT NULL
        Return sSQL & vbCrLf
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T2605
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 09/09/2009 01:57:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T2605() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T2605"
        sSQL &= " Where SalaryVoucherID = " & SQLString(_salaryVoucherID)
        Return sSQL & vbCrLf
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2605s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 09/09/2009 01:58:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2605s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        '        For i As Integer = 0 To tdbg.RowCount - 1
        '            If CBool(tdbg(i, COL_IsUsed)) Then
        '                sSQL.Append("Insert Into D13T2605(")
        '                sSQL.Append("SalaryVoucherID, SalaryVoucherNo, VoucherID, VoucherNo, Module")
        '                sSQL.Append(") Values(")
        '                sSQL.Append(SQLString(_salaryVoucherID) & COMMA) 'SalaryVoucherID, varchar[20], NOT NULL
        '                sSQL.Append(SQLString(txtSalaryVoucherNo.Text) & COMMA) 'SalaryVoucherNo, varchar[20], NOT NULL
        '                sSQL.Append(SQLString(tdbg(i, COL_AbsentVoucherID)) & COMMA) 'VoucherID, varchar[20], NOT NULL
        '                sSQL.Append(SQLString(tdbg(i, COL_AbsentVoucherNo)) & COMMA) 'VoucherNo, varchar[20], NOT NULL
        '                sSQL.Append(SQLString("D29")) 'Module, varchar[20], NOT NULL
        '                sSQL.Append(")")
        '
        '                sRet.Append(sSQL.ToString & vbCrLf)
        '                sSQL.Remove(0, sSQL.Length)
        '            End If
        '        Next
        '
        '        sSQL.Remove(0, sSQL.Length)
        '
        '        For i As Integer = 0 To tdbgSalary.RowCount - 1
        '            If CBool(tdbgSalary(i, COLS_IsUse)) Then
        '                sSQL.Append("Insert Into D13T2605(")
        '                sSQL.Append("SalaryVoucherID, SalaryVoucherNo, VoucherID, VoucherNo, Module")
        '                sSQL.Append(") Values(")
        '                sSQL.Append(SQLString(_salaryVoucherID) & COMMA) 'SalaryVoucherID, varchar[20], NOT NULL
        '                sSQL.Append(SQLString(txtSalaryVoucherNo.Text) & COMMA) 'SalaryVoucherNo, varchar[20], NOT NULL
        '                sSQL.Append(SQLString(tdbgSalary(i, COLS_PSalaryVoucherID)) & COMMA) 'VoucherID, varchar[20], NOT NULL
        '                sSQL.Append(SQLString(tdbgSalary(i, COLS_PSalaryVoucherNo)) & COMMA) 'VoucherNo, varchar[20], NOT NULL
        '                sSQL.Append(SQLString("D45")) 'Module, varchar[20], NOT NULL
        '                sSQL.Append(")")
        '
        '                sRet.Append(sSQL.ToString & vbCrLf)
        '                sSQL.Remove(0, sSQL.Length)
        '            End If
        '        Next

        ' sSQL.Remove(0, sSQL.Length)

        For i As Integer = 0 To tdbgAdjustIncome.RowCount - 1
            If L3Bool(tdbgAdjustIncome(i, COLA_IsUse).ToString) Then
                sSQL.Append("Insert Into D13T2605(")
                sSQL.Append("SalaryVoucherID, VoucherID, VoucherNo, Module")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(_salaryVoucherID) & COMMA) 'SalaryVoucherID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbgAdjustIncome(i, COLA_VoucherID)) & COMMA) 'VoucherID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbgAdjustIncome(i, COLA_VoucherNo)) & COMMA) 'VoucherNo, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbgAdjustIncome(i, COLA_ModuleID))) 'Module, varchar[20], NOT NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next

        sRet.Append(vbCrLf)
        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2042
    '# Created User: DUCTRONG
    '# Created Date: 30/12/2009 02:21:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2042() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon phieu Cham cong tong hop, dieu chinh thu nhap, phieu tinh luong san pham" & vbCrLf)
        sSQL &= "Exec D13P2042 "
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsPayRollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLString("D13F2041") 'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2600
    '# Created User: Hoàng Nhân
    '# Created Date: 16/12/2013 08:37:29
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2600() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho form khi xem, sua" & vbCrLf)
        sSQL &= "Exec D13P2600 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1130
    '# Created User: Hoàng Nhân
    '# Created Date: 20/01/2014 09:49:04
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1130() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load combo Mau thiet lap" & vbCrLf)
        sSQL &= "Exec D13P1130 "
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F2040") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("%") & COMMA 'TranTypeID, varchar[20], NOT NULL
        sSQL &= SQLString("0003") & COMMA 'TransactionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2044
    '# Created User: Hoàng Nhân
    '# Created Date: 20/01/2014 09:52:01
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2044(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon danh sach nhan (default chon)" & vbCrLf)
        sSQL &= "Exec D13P2044 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL  ' -- 0 AddNew, 1 Edit
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D13F2041") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsPayRollVoucherID) & COMMA 'PayrollVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcNCodeTypeID)) & COMMA 'NCodeTypeID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcNCodeID)) & COMMA 'NCodeID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcProjectID)) & COMMA  'ProjectID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTransTypeID)) & COMMA 'TransTypeID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA  'BlockID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA  'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcSalaryObjectID)) & COMMA  'SalaryObjectID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcStatusID))  'StatusID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0113
    '# Created User: Hoàng Nhân
    '# Created Date: 20/01/2014 10:36:43
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0113() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Delete truoc khi insert" & vbCrLf)
        sSQL &= "Delete From D13T0113"
        sSQL &= " Where AbsentVoucherID = " & SQLString(_salaryVoucherID)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0113s
    '# Created User: Hoàng Nhân
    '# Created Date: 20/01/2014 10:36:09
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0113s(ByVal drEmp() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        If drEmp Is Nothing Then Return sRet

        For i As Integer = 0 To drEmp.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu cac nhan vien duoc chon de tinh luong " & vbCrLf)
            sSQL.Append("Insert Into D13T0113(")
            sSQL.Append("TransID, AbsentVoucherID, EmployeeID, Type")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(drEmp(i).Item("TransID")) & COMMA) 'TransID, varchar[50], NOT NULL
            sSQL.Append(SQLString(_salaryVoucherID) & COMMA) 'AbsentVoucherID, varchar[50], NOT NULL
            sSQL.Append(SQLString(drEmp(i).Item("EmployeeID")) & COMMA) 'EmployeeID, varchar[50], NOT NULL
            sSQL.Append(SQLNumber(drEmp(i).Item("Type"))) 'Type, tinyint, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD29P2001
    '# Created User: Hoàng Nhân
    '# Created Date: 26/04/2014 04:23:49
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD29P2001(ByVal iFromDate As Integer, ByVal iToDate As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load du lieu cho tung ky cham cong dua vao thong so ky cham cong 'Tu ngay' 'Den ngay' tai he thong." & vbCrLf)
        sSQL &= "Exec D29P2001 "
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'MinDate, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'MaxDate, datetime, NOT NULL
        sSQL &= SQLNumber(2) & COMMA 'IsRecordSet, int, NOT NULL
        sSQL &= SQLNumber(iFromDate) & COMMA 'FromDate, int, NOT NULL
        sSQL &= SQLNumber(iToDate) & COMMA 'ToDate, int, NOT NULL
        sSQL &= SQLString("") 'LeaveObjectID, varchar[20], NOT NULL
        Return sSQL
    End Function
#End Region

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        bValueChanged = True
    End Sub



    Private Sub tdbcNCodeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcNCodeID.SelectedValueChanged
        If bLoadFirst Then LoadTDBGridEmp()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

 
End Class

