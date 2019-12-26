Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 3:39:07 PM
'# Created User: Nguyễn Thị Ánh
'# Modify Date: 08/05/2007 3:39:07 PM
'# Modify User: Nguyễn Thị Ánh
'#-------------------------------------------------------------------------------------
Public Class D45F2001

    Public bFlagSave As Boolean = False
    Dim bFormLoad As Boolean = False
    'Public sNewID As String = ""
    Dim dtTeamID, dtDepartmentID, dtBlockID As DataTable
    Private sOldTransTypeID As String
    Dim bRun_tdbcTransTypeID_ItemChange As Boolean = True

    Dim sEditTransTypeID As String = ""
    Dim sEditVoucherTypeID As String = ""

    Private _productVoucherID As String
    Public Property ProductVoucherID() As String
        Get
            Return _productVoucherID
        End Get
        Set(ByVal Value As String)
            _productVoucherID = Value
        End Set
    End Property

    Private _createVoucherNo_D45F2020 As Boolean
    Public WriteOnly Property  CreateVoucherNo_D45F2020() As Boolean
        Set(ByVal Value As Boolean)
            _createVoucherNo_D45F2020 = Value
        End Set
    End Property

    Private _isAuto As Integer = 0 '1(khi goi tu D45F2022)
    Public WriteOnly Property IsAuto() As Integer
        Set(ByVal Value As Integer)
            _isAuto = Value
        End Set
    End Property

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
                    btnSave.Enabled = True
                    btnAttendance.Enabled = False
                    btnNext.Enabled = False
                    bRun_tdbcTransTypeID_ItemChange = True
                    LoadTDBCombo()
                    LoadAddNew()
                Case EnumFormState.FormEdit
                    bRun_tdbcTransTypeID_ItemChange = False
                    btnSave.Enabled = True
                    LoadEdit()
                Case EnumFormState.FormView
                    bRun_tdbcTransTypeID_ItemChange = False
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub D45F2001_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _isAuto = 1 Then ExecuteSQLNoTransaction(SQLDeleteD09T6666.ToString)
    End Sub

    Private Sub D45F2001_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormAdd Then
            If tdbcTransTypeID.GetItemText(0, "TransTypeID") <> "" And tdbcTransTypeID.GetItemText(1, "TransTypeID") = "" Then
                tdbcTransTypeID.SelectedIndex = 0
                tdbcVoucherTypeID.Focus()
            End If
        End If
    End Sub

    Private Sub D45F2001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D45F2001_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        SetBackColorObligatory()
        bFormLoad = True
        '*********************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtProductVoucherNo, txtProductVoucherNo.MaxLength)
        '*********************
        InputDateCustomFormat(c1dateVoucherDate, c1dateDateTo, c1dateDateFrom)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub Loadlanguage()
    '    '================================================================ 
    '    '  Me.Text = rL3("Thiet_lap_phieu_cham_cong_san_pham_-_D45F2001") & UnicodeCaption(gbUnicode) 'ThiÕt lËp phiÕu chÊm c¤ng s¶n phÈm - D45F2001
    '    Me.Text = rL3("Thiet_lap_phieu_thong_ke_san_pham_tinh_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'ThiÕt lËp phiÕu thçng k£ s¶n phÈm tÛnh l§¥ng

    '    '================================================================ 
    '    lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
    '    lblVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
    '    lblVoucherDesc.Text = rl3("Dien_giai") 'Diễn giải
    '    lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
    '    lblteDateFrom.Text = rl3("Tu_ngay") 'Từ ngày
    '    lblteDateTo.Text = rl3("Den_ngay") 'Đến ngày
    '    lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
    '    lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
    '    lblPreparerID.Text = rl3("Nguoi_lap")
    '    lblDAGroupID.Text = rl3("Nhom_truy_cap_du_lieu") 'Nhóm truy cập dữ liệu
    '    '================================================================ 
    '    btnSave.Text = rl3("_Luu") '&Lưu
    '    btnAttendance.Text = rl3("_Cham_cong") '&Chấm công
    '    btnClose.Text = rl3("Do_ng") 'Đó&ng
    '    btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
    '    '================================================================ 
    '    chkIsSpec.Text = rl3("Cham_cong_theo_quy_cach") 'Chấm công theo quy cách
    '    '================================================================ 
    '    optMethod0.Text = rl3("Theo_nhan_vien_U") 'Theo nhân viên
    '    optMethod1.Text = rl3("Theo_phong_banto_nhom") 'Theo phòng ban/tổ nhóm
    '    optMethod2.Text = rl3("Theo_nhom_CCSP") 'Theo nhóm CCSP
    '    optMethod3.Text = rl3("Theo_nhom_nhan_vien") 'Theo nhóm nhân viên
    '    '================================================================ 
    '    grpVoucher.Text = rl3("Chung_tu") 'Chứng từ
    '    grpAttendance.Text = rl3("Cham_cong_cho_khoang_thoi_gian") 'Chấm công cho khoảng thời gian
    '    grpCriate.Text = rl3("Dieu_kien") 'Điều kiện
    '    grpMethod.Text = "Phương pháp thống kê sản phẩm" 'rl3("Phuong_phap_cham_cong") 'Phương pháp chấm công
    '    '================================================================ 
    '    tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Loai_phieu") 'Loại phiếu
    '    tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbcPreparerID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
    '    tdbcPreparerID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
    '    tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã tổ nhóm
    '    tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên tổ nhóm
    '    tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã phòng ban
    '    tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên phòng ban
    '    '================================================================ 
    '    lblTransTypeID.Text = rL3("Loai_nghiep_vu") 'Loại nghiệp vụ
    '    '================================================================ 
    '    tdbcTransTypeID.Columns("TransTypeID").Caption = rL3("Ma") 'Mã
    '    tdbcTransTypeID.Columns("TransTypeName").Caption = rL3("Dien_giai") 'Diễn giải

    '    '================================================================ 
    '    lblBlockID.Text = rL3("Khoi") 'Khối
    '    '================================================================ 
    '    tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
    '    tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên


    'End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Thiet_lap_phieu_thong_ke_san_pham_tinh_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'ThiÕt lËp phiÕu thçng k£ s¶n phÈm tÛnh l§¥ng
        '================================================================ 
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblVoucherDesc.Text = rl3("Dien_giai") 'Diễn giải
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblPreparerID.Text = rl3("Nguoi_lap") 'Người lập
        lblteDateFrom.Text = rl3("Tu_ngay") 'Từ ngày
        lblteDateTo.Text = rl3("Den_ngay") 'Đến ngày
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblTransTypeID.Text = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        lblDAGroupID.Text = rl3("Nhom_truy_cap_du_lieu") 'Nhóm truy cập dữ liệu
        '================================================================ 
        btnAttendance.Text = rl3("Thong_ke_san_pham") 'Thống kê sản phẩm
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkIsSpec.Text = rl3("Thong_ke_san_pham_theo_quy_cach") 'Thống kê sản phẩm theo quy cách
        '================================================================ 
        optMethod3.Text = rl3("Theo_nhom_nhan_vien") 'Theo nhóm nhân viên
        optMethod2.Text = rl3("Theo_nhom_CCSP") 'Theo nhóm CCSP
        optMethod1.Text = rl3("Theo_phong_banto_nhom") 'Theo phòng ban/tổ nhóm
        optMethod0.Text = rl3("Theo_nhan_vien_U") 'Theo nhân viên
        '================================================================ 
        grpVoucher.Text = rl3("Chung_tu") 'Chứng từ
        grpAttendance.Text = rl3("Thong_ke_cho_khoang_thoi_gian") 'Thống kê cho khoảng thời gian
        grpCriate.Text = rl3("Dieu_kien") 'Điều kiện
        grpMethod.Text = rl3("Phuong_phap_thong_ke_san_pham") 'Phương pháp thống kê sản phẩm
        '================================================================ 
        tdbcPreparerID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcPreparerID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Loai_phieu") 'Loại phiếu
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbcTeamID.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbcTransTypeID.Columns("TransTypeID").Caption = rl3("Ma") 'Mã
        tdbcTransTypeID.Columns("TransTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcDAGroupID.Columns("DAGroupID").Caption = rl3("Ma") 'Mã
        tdbcDAGroupID.Columns("DAGroupName").Caption = rl3("Ten") 'Tên
    End Sub



    Private Sub SetBackColorObligatory()
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtProductVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadDefaultDate()
        c1dateVoucherDate.Value = Now.Date
        c1dateDateFrom.Value = Now.Date
        c1dateDateTo.Value = Now.Date
    End Sub

    Private Sub LoadAddNew()
        LoadDefaultDate()
        tdbcVoucherTypeID.SelectedIndex = 0
        GetTextCreateBy(tdbcPreparerID)

        If _isAuto = 1 Then
            optMethod2.Enabled = False
            optMethod1.Checked = True
        End If
    End Sub

    Private Sub LoadEdit()
        Dim sSQL As String = ""
        sSQL = "Select D45.BlockID, D45.ProductVoucherID, D45.VoucherTypeID, D45.ProductVoucherNo, D45.TransDAGroupID, D45.TransTypeID, D45.Method, " & vbCrLf
        sSQL &= "D45.VoucherDate, D45.Note" & UnicodeJoin(gbUnicode) & " As Note,  D45.DateFrom, D45.DateTo, D45.IsSpec, " & vbCrLf
        sSQL &= "D45.PayrollVoucherID, D13.PayrollVoucherNo, D13.Description" & UnicodeJoin(gbUnicode) & " As Description, " & vbCrLf
        sSQL &= "D45.DepartmentID, D91.DepartmentName, D45.TeamID,D45.PreparerID, D27.TeamName, D45.EmployeeID, " & vbCrLf
        If gbUnicode = False Then
            sSQL &= "Isnull(D09.LastName,'') + ' ' + Isnull(D09.MiddleName,'') +' ' + Isnull(D09.FirstName,'') as EmployeeName" & vbCrLf
        Else
            sSQL &= "Isnull(D09.LastNameU,'') + ' ' + Isnull(D09.MiddleNameU,'') +' ' + Isnull(D09.FirstNameU,'') as EmployeeName" & vbCrLf
        End If
        sSQL &= "From D45T2000 D45  WITH(NOLOCK) Inner join D13T0100 D13  WITH(NOLOCK) On D13.PayrollVoucherID = D45.PayrollVoucherID" & vbCrLf & vbCrLf
        sSQL &= "Left Join 	D91T0012 D91  WITH(NOLOCK) On D91.DepartmentID= D45.DepartmentID" & vbCrLf & vbCrLf
        sSQL &= "Left Join 	D09T0227 D27  WITH(NOLOCK) On D27.TeamID= D45.TeamID " & vbCrLf & vbCrLf
        sSQL &= "Left Join 	D09T0201 D09  WITH(NOLOCK) On D09.EmployeeID= D45.EmployeeID" & vbCrLf & vbCrLf
        sSQL &= "Where D45.DivisionID = " & SQLString(gsDivisionID) & " And D45.TranMonth = " & SQLNumber(giTranMonth) & " And " & vbCrLf
        sSQL &= "D45.TranYear =" & SQLNumber(giTranYear) & " And ProductVoucherID = " & SQLString(_productVoucherID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            sEditTransTypeID = dt.Rows(0).Item("TransTypeID").ToString
            sEditVoucherTypeID = dt.Rows(0).Item("VoucherTypeID").ToString
            LoadTDBCombo()
            '--------------------------------------------------------
            tdbcTransTypeID.Text = dt.Rows(0).Item("TransTypeID").ToString
            tdbcDAGroupID.Text = dt.Rows(0).Item("TransDAGroupID").ToString

            tdbcVoucherTypeID.Text = dt.Rows(0).Item("VoucherTypeID").ToString
            txtProductVoucherNo.Text = dt.Rows(0).Item("ProductVoucherNo").ToString
            c1dateVoucherDate.Value = dt.Rows(0).Item("VoucherDate")
            c1dateDateFrom.Value = dt.Rows(0).Item("DateFrom")
            c1dateDateTo.Value = dt.Rows(0).Item("DateTo")
            txtNote.Text = dt.Rows(0).Item("Note").ToString
            tdbcBlockID.SelectedValue = dt.Rows(0).Item("BlockID").ToString
            tdbcDepartmentID.SelectedValue = dt.Rows(0).Item("DepartmentID").ToString
            tdbcTeamID.SelectedValue = dt.Rows(0).Item("TeamID").ToString
            tdbcPreparerID.Text = dt.Rows(0).Item("PreparerID").ToString
            chkIsSpec.Checked = L3Bool(dt.Rows(0).Item("IsSpec").ToString)
            If dt.Rows(0).Item("Method").ToString = "0" Then
                optMethod0.Checked = True
            ElseIf dt.Rows(0).Item("Method").ToString = "1" Then
                optMethod1.Checked = True
            ElseIf dt.Rows(0).Item("Method").ToString = "2" Then
                optMethod2.Checked = True
            Else
                optMethod3.Checked = True
            End If
        End If
        '******************************************
        btnNext.Visible = False
        btnSetNewKey.Enabled = False
        btnSave.Left = btnNext.Left
        btnSetNewKey.Enabled = False
        '******************************************
        tdbcTransTypeID.Enabled = False
        tdbcVoucherTypeID.Enabled = False
        txtProductVoucherNo.ReadOnly = True
        '******************************************
        btnAttendance.Enabled = Not gbClosed 'theo khoá sổ
        grpMethod.Enabled = False
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, D45, sEditVoucherTypeID, gbUnicode)

        'ID 88673 08.09.2016
        'Load tdbcTransTypeID
        sSQL &= "Select TransTypeID, TransTypeName" & UnicodeJoin(gbUnicode) & " As TransTypeName, VoucherTypeID, "
        sSQL &= "Note" & UnicodeJoin(gbUnicode) & " As Note, PreparerID, DAGroupID,Method,IsSpec " & vbCrLf
        sSQL &= "From D45T1040  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where	Disabled = 0  And ( DAGroupID In (Select DAGroupID "
        sSQL &= " From LEMONSYS.DBO.D00V0080	Where 	UserID = " & SQLString(gsUserID) & ") Or  " & SQLString(gsUserID) & "=  'LEMONADMIN'  ) " & vbCrLf
        If sEditTransTypeID <> "" Then sSQL &= " Or TransTypeID =  " & SQLString(sEditTransTypeID)
        sSQL &= "Order by TransTypeID"
        LoadDataSource(tdbcTransTypeID, sSQL, gbUnicode)

        'Load tdbcDAGroupID
        LoadTDBC_DAGroupID(tdbcDAGroupID, gbUnicode)

        'Load tdbcPreparerID
        LoadCboCreateBy(tdbcPreparerID, gbUnicode)

        'Load tdbcBlockID
        dtBlockID = ReturnTableBlockID_D09P6868(gsDivisionID, "D45F2000", 0)
        LoadDataSource(tdbcBlockID, dtBlockID, gbUnicode)
        tdbcBlockID.Enabled = CheckEnableBlockID()

        ''LoadtdbcteamID
        'sSQL = "SELECT '%' As TeamID, " & AllName & " As TeamName, '%' As DepartmentID, '' As  PayrollVoucherID, 0 as DisplayOrder" & vbCrLf
        'sSQL &= "UNION" & vbCrLf
        'sSQL &= "SELECT DISTINCT D01.TeamID, D01.TeamName" & UnicodeJoin(gbUnicode) & " as TeamName, D01.DepartmentID, D13.PayrollVoucherID, 1 as DisplayOrder" & vbCrLf
        'sSQL &= "FROM D09T0227 D01  WITH(NOLOCK) INNER JOIN D13T0101 D13  WITH(NOLOCK) ON D13.TeamID = D01.TeamID And D13.DepartmentID = D01.DepartmentID" & vbCrLf
        'sSQL &= "WHERE D01.Disabled = 0 AND D13.DivisionID = " & SQLString(gsDivisionID)
        'sSQL &= " And  D13.PayrollVoucherID = " & SQLString(gsPayrollVoucherID) & vbCrLf
        'sSQL &= "ORDER BY DisplayOrder, TeamName"
        'dtTeamID = ReturnDataTable(sSQL)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID_D09P6868(gsDivisionID, "D45F2000", 0)

        ''Load tdbcDepartmentID
        'sSQL = "SELECT '%' As DepartmentID, " & AllName & " As DepartmentName, '' As  PayrollVoucherID, 0 as DisplayOrder" & vbCrLf
        'sSQL &= "UNION" & vbCrLf
        'sSQL &= "SELECT DISTINCT D91.DepartmentID, D91.DepartmentName" & UnicodeJoin(gbUnicode) & " as DepartmentName, D13.PayrollVoucherID, 1 as DisplayOrder" & vbCrLf
        'sSQL &= "FROM D91T0012 D91  WITH(NOLOCK) INNER JOIN D13T0101 D13  WITH(NOLOCK) ON D13.DepartmentID = D91.DepartmentID" & vbCrLf
        'sSQL &= "WHERE D91.Disabled = 0 And D91.DivisionID = " & SQLString(gsDivisionID)
        'sSQL &= " And  D13.PayrollVoucherID = " & SQLString(gsPayrollVoucherID) & vbCrLf
        'sSQL &= "ORDER BY DisplayOrder, DepartmentName"
        'dtDepartmentID = ReturnDataTable(sSQL)
        'LoadDataSource(tdbcDepartmentID, dtDepartmentID, gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID_D09P6868(gsDivisionID, "D45F2000", 0)
        LoadDataSource(tdbcDepartmentID, dtDepartmentID, gbUnicode)

        If tdbcBlockID.Enabled And dtBlockID.Rows.Count > 0 Then tdbcBlockID.SelectedIndex = 0
    End Sub

#Region "Events tdbcPreparerID with txtPreparerName"

    Private Sub tdbcPreparerID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPreparerID.LostFocus
        If tdbcPreparerID.FindStringExact(tdbcPreparerID.Text) = -1 Then
            tdbcPreparerID.Text = ""
            txtPreparerName.Text = ""
        End If
    End Sub

    Private Sub tdbcPreparerID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPreparerID.SelectedValueChanged
        If tdbcPreparerID.SelectedValue Is Nothing Then
            txtPreparerName.Text = ""
        Else
            txtPreparerName.Text = tdbcPreparerID.Columns(1).Value.ToString
        End If
    End Sub

#End Region

#Region "Events tdbcTransTypeID with txtTransTypeName"

    Private Sub tdbcTransTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.SelectedValueChanged
        If tdbcTransTypeID.SelectedValue Is Nothing Then
            txtTransTypeName.Text = ""
            tdbcDAGroupID.SelectedValue = ""
            tdbcVoucherTypeID.SelectedValue = ""
            txtNote.Text = ""
            tdbcPreparerID.SelectedValue = ""
            'ID 88673 08.09.2016
            optMethod0.Checked = True
        Else
            txtTransTypeName.Text = tdbcTransTypeID.Columns("TransTypeName").Value.ToString
            tdbcDAGroupID.SelectedValue = tdbcTransTypeID.Columns("DAGroupID").Value.ToString
            tdbcVoucherTypeID.SelectedValue = tdbcTransTypeID.Columns("VoucherTypeID").Value.ToString
            txtNote.Text = tdbcTransTypeID.Columns("Note").Value.ToString
            tdbcPreparerID.SelectedValue = tdbcTransTypeID.Columns("PreparerID").Value.ToString
            'ID 88673 08.09.2016
            chkIsSpec.Checked = L3Bool(tdbcTransTypeID.Columns("IsSpec").Value)
            If tdbcTransTypeID.Columns("Method").Value.ToString = "0" Then
                optMethod0.Checked = True
            ElseIf tdbcTransTypeID.Columns("Method").Value.ToString = "1" Then
                optMethod1.Checked = True
            ElseIf tdbcTransTypeID.Columns("Method").Value.ToString = "2" Then
                optMethod2.Checked = True
            Else
                optMethod3.Checked = True
            End If
            '*****************************
        End If
        '--------------------------------------------------
        If tdbcTransTypeID.Text <> sOldTransTypeID Then bRun_tdbcTransTypeID_ItemChange = True
    End Sub

    Private Sub tdbcTransTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.LostFocus
        ' Cac dong lenh nay chuyen sang tu Sub tdbcTransTypeID_ItemChange
        If bRun_tdbcTransTypeID_ItemChange = False OrElse tdbcTransTypeID.Text = "" Then Exit Sub

        If tdbcTransTypeID.FindStringExact(tdbcTransTypeID.Text) = -1 Then
            tdbcTransTypeID.Text = ""
        Else
            If tdbcVoucherTypeID.Text <> "" Then
                tdbcVoucherTypeID_SelectedValueChanged(sender, e)
            Else
                tdbcVoucherTypeID.Focus()
            End If
        End If

        sOldTransTypeID = tdbcTransTypeID.Text
    End Sub
#End Region

#Region "Events tdbcDAGroupID with txtDAGroupName"

    Private Sub tdbcDAGroupID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDAGroupID.LostFocus
        If tdbcDAGroupID.FindStringExact(tdbcDAGroupID.Text) = -1 Then
            tdbcDAGroupID.Text = ""
            txtDAGroupName.Text = ""
        End If
    End Sub

    Private Sub tdbcDAGroupID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDAGroupID.SelectedValueChanged
        If tdbcDAGroupID.SelectedValue Is Nothing Then
            txtDAGroupName.Text = ""
        Else
            txtDAGroupName.Text = tdbcDAGroupID.Columns(1).Value.ToString
        End If
    End Sub
#End Region

#Region "Events tdbcVoucherTypeID with txtVoucherTypeName"

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        If tdbcVoucherTypeID.SelectedValue Is Nothing OrElse IsDBNull(tdbcVoucherTypeID.SelectedValue) Then
            txtVoucherTypeName.Text = ""
            txtProductVoucherNo.Text = ""
        Else
            txtVoucherTypeName.Text = tdbcVoucherTypeID.Columns(1).Value.ToString
            If tdbcVoucherTypeID.Columns("Auto").Text = "0" Then 'Không tạo mã tự động
                txtProductVoucherNo.ReadOnly = False
                txtProductVoucherNo.TabStop = True
                btnSetNewKey.Enabled = False
                txtProductVoucherNo.Text = ""
            Else
                gnNewLastKey = 0
                txtProductVoucherNo.ReadOnly = True
                txtProductVoucherNo.TabStop = False
                btnSetNewKey.Enabled = True
                txtProductVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
            End If
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.LostFocus
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherTypeName.Text = ""
            txtProductVoucherNo.Text = ""
        End If

    End Sub

#End Region

#Region "Events tdbcDepartmentID with txtDepartmentName load tdbcTeamID with txtTeamName"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        'If tdbcDepartmentID.SelectedValue Is Nothing Then
        '    txtDepartmentName.Text = ""
        'Else
        '    txtDepartmentName.Text = tdbcDepartmentID.Columns("DepartmentName").Text
        'End If
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, ReturnValueC1Combo(tdbcBlockID).ToString, ReturnValueC1Combo(tdbcDepartmentID).ToString, gbUnicode)
        tdbcTeamID.SelectedValue = "%"
        'ID 91533 13.10.2016 Bỏ ĐK where theo PayrollVoucherID
        'LoadtdbcTeamID(ReturnValueC1Combo(tdbcDepartmentID))
        'tdbcTeamID.Text = "%"
    End Sub

    Private Sub tdbcTeamID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""

        End If
    End Sub

#End Region

    'Private Sub LoadtdbcTeamID(ByVal sDepartmentID As String)
    '    Dim sSQL As String = ""
    '    'ID 91533 13.10.2016 Bỏ ĐK where theo PayrollVoucherID
    '    If sDepartmentID = "%" Then
    '        sSQL = "PayrollVoucherID=" & SQLString(gsPayrollVoucherID) & " Or TeamID ='%'"
    '    Else
    '        sSQL = "PayrollVoucherID= " & SQLString(gsPayrollVoucherID) & " And DepartmentID = " & SQLString(sDepartmentID) & " Or TeamID ='%'"
    '    End If

    '    LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, sSQL, True), gbUnicode)
    'End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        _createVoucherNo_D45F2020 = False
        Me.Close()
    End Sub

    Private Sub btnSetNewKey_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetNewKey.Click
        GetNewVoucherNo(tdbcVoucherTypeID, txtProductVoucherNo)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        btnNext.Enabled = False
        btnSave.Enabled = True
        btnAttendance.Enabled = False
        sOldTransTypeID = ""
        bRun_tdbcTransTypeID_ItemChange = True
        grpMethod.Enabled = True

        If D45Options.SaveLastRecent = False Then
            'Khởi tạo lại các giá trị 
            tdbcVoucherTypeID.SelectedValue = ""
            txtVoucherTypeName.Text = ""
            tdbcPreparerID.Text = ""
            txtPreparerName.Text = ""
            tdbcDAGroupID.Text = ""
            txtDAGroupName.Text = ""
            GetTextCreateBy(tdbcPreparerID)

            LoadDefaultDate()
            txtNote.Text = ""
            bFormLoad = False
            tdbcBlockID.SelectedValue = "%"
            tdbcDepartmentID.SelectedValue = "%"
            bFormLoad = True

            chkIsSpec.Checked = False
            optMethod0.Checked = True

            If _isAuto = 1 Then
                optMethod2.Enabled = False
                optMethod1.Checked = True
            End If

            If tdbcTransTypeID.GetItemText(0, "TransTypeID") <> "" And tdbcTransTypeID.GetItemText(1, "TransTypeID") = "" Then
                tdbcTransTypeID.SelectedIndex = 0
                tdbcTransTypeID_LostFocus(Nothing, Nothing)
                tdbcVoucherTypeID.Focus()
            Else 'Làm như cũ 
                tdbcTransTypeID.Text = ""
                tdbcTransTypeID.Focus()
            End If
        Else
            tdbcVoucherTypeID_SelectedValueChanged(sender, Nothing)
        End If
    End Sub

    Private Sub btnAttendance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAttendance.Click
        Dim iPieceWorkMethod As Integer

        If _isAuto = 1 Then 'Goi tu D45F2022 thi deu goi D45F2007
            If optMethod3.Checked Then
                iPieceWorkMethod = 3
            Else
                iPieceWorkMethod = 1
            End If
        Else
            iPieceWorkMethod = GetPieceWorkMethod(_productVoucherID)
        End If

        If iPieceWorkMethod = 0 Then
            Dim sSQL As String
            sSQL = "Select PieceWorkMethod From D45T5550  WITH(NOLOCK) Where UserID=" & SQLString(gsUserID)
            Dim dt As DataTable = ReturnDataTable(sSQL)
            Dim iType As Integer

            If dt.Rows.Count > 0 Then
                iType = L3Int(dt.Rows(0).Item("PieceWorkMethod").ToString)
            Else
                iType = 1
            End If

            If iType = 1 Then
                Dim f As New D45F2002
                With f
                    If TestExist(ProductVoucherID) Then .FormState = EnumFormState.FormView
                    .ProductVoucherID = _productVoucherID
                    .ProductVoucherNo = txtProductVoucherNo.Text
                    .VoucherDate = Format(c1dateVoucherDate.Value, "dd/MM/yyyy")
                    .Note = txtNote.Text
                    .PayrollVoucherID = gsPayrollVoucherID
                    .DepartmentID = ReturnValueC1Combo(tdbcDepartmentID)
                    .TeamID = ReturnValueC1Combo(tdbcTeamID)
                    .EmployeeID = "%"
                    .TransTypeID = tdbcTransTypeID.Text
                    .IsSpec = chkIsSpec.Checked
                    .FormState = _FormState
                    .ShowDialog()
                    .Dispose()
                End With
            Else
                Dim f As New D45F2003
                With f
                    If _FormState = EnumFormState.FormView Then
                        .FormState = EnumFormState.FormView
                    Else
                        If TestExist(ProductVoucherID) Then
                            .FormState = EnumFormState.FormView
                        Else
                            .FormState = _FormState
                        End If
                    End If
                    .ProductVoucherID = ProductVoucherID
                    .ProductVoucherNo = txtProductVoucherNo.Text
                    .VoucherDate = Format(c1dateVoucherDate.Value, "dd/MM/yyyy")
                    .Note = txtNote.Text
                    .PayrollVoucherID = gsPayrollVoucherID
                    .DepartmentID = ReturnValueC1Combo(tdbcDepartmentID)
                    .TeamID = ReturnValueC1Combo(tdbcTeamID)
                    .EmployeeID = "%"
                    .FromDate = c1dateDateFrom.Text
                    .ToDate = c1dateDateTo.Text
                    .TransTypeID = tdbcTransTypeID.Text
                    .ShowDialog()
                    .Dispose()
                End With
            End If

        ElseIf iPieceWorkMethod = 1 OrElse iPieceWorkMethod = 3 Then
            Dim f As New D45F2007
            With f
                If _FormState = EnumFormState.FormView Then
                    .FormState = EnumFormState.FormView
                Else
                    If TestExist(ProductVoucherID) Then
                        .FormState = EnumFormState.FormView
                    Else
                        .FormState = _FormState
                    End If
                End If
                If optMethod0.Checked Then
                    .IsVisibleEmployeeID = False
                    .Mode = 0
                Else
                    .IsVisibleEmployeeID = True
                    .Mode = iPieceWorkMethod ' 1
                End If

                .PayrollVoucherID = gsPayrollVoucherID
                .ProductVoucherID = _productVoucherID
                .ProductVoucherNo = txtProductVoucherNo.Text
                .VoucherDate = Format(c1dateVoucherDate.Value, "dd/MM/yyyy")
                .sMethod = iPieceWorkMethod
                .BlockID = ReturnValueC1Combo(tdbcBlockID)
                .DepartmentID = ReturnValueC1Combo(tdbcDepartmentID)
                .TeamID = ReturnValueC1Combo(tdbcTeamID)
                .IsSpec = chkIsSpec.Checked
                .Note = txtNote.Text
                .ShowDialog()
                .Dispose()
            End With
        Else
            Dim f As New D45F2004
            With f
                If _FormState = EnumFormState.FormView Then
                    .FormState = EnumFormState.FormView
                Else
                    If TestExist(ProductVoucherID) Then
                        .FormState = EnumFormState.FormView
                    Else
                        .FormState = _FormState
                    End If
                End If
                .ProductVoucherID = _productVoucherID
                .ProductVoucherNo = txtProductVoucherNo.Text
                .VoucherDate = Format(c1dateVoucherDate.Value, "dd/MM/yyyy")
                .Note = txtNote.Text
                .PayrollVoucherID = gsPayrollVoucherID
                .DepartmentID = ReturnValueC1Combo(tdbcDepartmentID)
                .TeamID = ReturnValueC1Combo(tdbcTeamID)
                .TransTypeID = tdbcTransTypeID.Text
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If
        If txtProductVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("So_phieu"))
            txtProductVoucherNo.Focus()
            Return False
        End If
        If c1dateVoucherDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_phieu"))
            c1dateVoucherDate.Focus()
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
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        If CheckValidDateFromTo(c1dateDateFrom, c1dateDateTo) = False Then
            Return False
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra trùng ngày phiếu
        If Not CheckVoucherDateInPeriod(c1dateVoucherDate.Text) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        btnSave.Enabled = False
        btnClose.Enabled = False

        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD45T2000)
                'Lưu LastKey
                If tdbcVoucherTypeID.Columns("Auto").Text <> "0" Then txtProductVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, True)
                'Kiểm tra trùng số phiếu
                If CheckDuplicateVoucherNo("D45", "D45T2000", ProductVoucherID, txtProductVoucherNo.Text) Then
                    Me.Cursor = Cursors.Default
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    Exit Sub
                End If
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T2000)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        btnClose.Enabled = True
        If bRunSQL Then
            SaveOK()
            bFlagSave = True
            grpMethod.Enabled = False

            'Thuc thi D45P2024
            If _isAuto = 1 Then ExecuteSQL(SQLStoreD45P2024.ToString)

            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                    btnAttendance.Enabled = True
                Case EnumFormState.FormEdit
                    'RunAuditLog(AuditCodePieceworkVouchers45, "02", c1dateVoucherDate.Text, txtProductVoucherNo.Text, tdbcPreparerID.Text, txtNote.Text)
                    Lemon3.D91.RunAuditLog("45", AuditCodePieceworkVouchers45, "02", c1dateVoucherDate.Text, txtProductVoucherNo.Text, tdbcPreparerID.Text, txtNote.Text)
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

    Private Function GetPieceWorkMethod(ByVal sProductVoucherID As String) As Integer
        Dim sSQL As String = ""
        sSQL = "Select Method From D45T2000  WITH(NOLOCK) Where ProductVoucherID=" & SQLString(sProductVoucherID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            Return L3Int(dt.Rows(0).Item("Method").ToString)
        Else
            Return 0
        End If
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2000
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 07/05/2007 09:49:12
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2000() As StringBuilder
        Dim sSQL As New StringBuilder

        'Sinh IGE cho ProductVoucherID
        _productVoucherID = CreateIGE("D45T2000", "ProductVoucherID", "45", "PV", gsStringKey)

        sSQL.Append("Insert Into D45T2000(")
        sSQL.Append("DivisionID, TranMonth, TranYear, ProductVoucherID, VoucherTypeID, TransTypeID, TransDAGroupID, ")
        sSQL.Append("ProductVoucherNo, VoucherDate, Note, NoteU, DateFrom, DateTo, ")
        sSQL.Append("PayrollVoucherID, DepartmentID, TeamID, PreparerID, Disabled, IsSpec, Method, ")
        sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate,BlockID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
        sSQL.Append(SQLString(ProductVoucherID) & COMMA) 'ProductVoucherID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcVoucherTypeID.Text) & COMMA) 'VoucherTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcTransTypeID.Text) & COMMA) 'TransTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcDAGroupID.Text) & COMMA) 'TransDAGroupID, varchar[20], NOT NULL
        sSQL.Append(SQLString(txtProductVoucherNo.Text) & COMMA) 'ProductVoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'VoucherDate, datetime, NULL
        sSQL.Append(SQLStringUnicode(txtNote, False) & COMMA) 'Note, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote, True) & COMMA) 'NoteU, varchar[150], NOT NULL
        sSQL.Append(SQLDateSave(c1dateDateFrom.Text) & COMMA) 'DateFrom, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateDateTo.Text) & COMMA) 'DateTo, datetime, NULL
        sSQL.Append(SQLString(gsPayrollVoucherID) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcPreparerID)) & COMMA) 'PreparerID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkIsSpec.Checked) & COMMA) 'IsSpec, tinyint, NOT NULL
        If optMethod0.Checked Then
            sSQL.Append(SQLNumber(0) & COMMA) 'Method, tinyint, NOT NULL
        ElseIf optMethod1.Checked Then
            sSQL.Append(SQLNumber(1) & COMMA) 'Method, tinyint, NOT NULL
        ElseIf optMethod2.Checked Then
            sSQL.Append(SQLNumber(2) & COMMA) 'Method, tinyint, NOT NULL
        Else
            sSQL.Append(SQLNumber(3) & COMMA) 'Method, tinyint, NOT NULL
        End If
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcBlockID))) 'BlockID, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T2000
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 07/05/2007 09:49:35
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T2000() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T2000 Set ")
        sSQL.Append("VoucherDate=" & SQLDateSave(c1dateVoucherDate.Value) & COMMA)
        sSQL.Append("Note = " & SQLStringUnicode(txtNote, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote, True) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("DateFrom = " & SQLDateSave(c1dateDateFrom.Text) & COMMA) 'datetime, NULL
        sSQL.Append("DateTo = " & SQLDateSave(c1dateDateTo.Text) & COMMA) 'datetime, NULL
        sSQL.Append("PayrollVoucherID = " & SQLString(gsPayrollVoucherID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("DepartmentID = " & SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("TeamID = " & SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("PreparerID = " & SQLString(ReturnValueC1Combo(tdbcPreparerID)) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("TransTypeID= " & SQLString(tdbcTransTypeID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("TransDAGroupID= " & SQLString(tdbcDAGroupID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("IsSpec= " & SQLNumber(chkIsSpec.Checked) & COMMA) 'IsSpec, tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("BlockID =" & SQLString(ReturnValueC1Combo(tdbcBlockID))) 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("ProductVoucherID = " & SQLString(ProductVoucherID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/07/2011 02:07:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where HostID= Host_Name() And Key01ID='D45F2020' And UserID=" & SQLString(gsUserID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2024
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/07/2011 03:57:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2024() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2024 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(_productVoucherID) 'ProductVoucherID, varchar[20], NOT NULL
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
        sSQL &= SQLString("D45F2000") 'FormID, varchar[20], NOT NULL
        Return sSQL
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
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ReturnValueC1Combo(tdbcBlockID).ToString, gbUnicode)
        tdbcDepartmentID.SelectedValue = "%"
    End Sub

    Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcDepartmentID.SelectedValue = "%"
            tdbcTeamID.SelectedValue = "%"
            Exit Sub
        End If
    End Sub


#End Region



End Class