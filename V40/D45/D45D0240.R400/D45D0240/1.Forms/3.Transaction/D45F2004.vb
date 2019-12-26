Imports System.Data
Imports System
Imports System.Collections
Imports C1.C1Excel
Imports System.IO
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.Runtime.Serialization
Public Class D45F2004
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Private dtDepartmentID, dtTeamID, dtEmployeeID, dtGrid, dtGrid2 As DataTable
    Dim sBlockID, sDepartmentID, sTeamID As String
    Private nTotalProduct As Integer = 0, nTotalProduct1 As Integer = 0
    Dim dtAddField, dtAddField1, dtCaption, dtAnaID As New DataTable
    Dim iColLast As Integer = COL_PieceworkGroupName 'Cột cuối cùng hiển thị của lưới 1
    Dim iColLast2 As Integer = COL2_TeamID 'Cột cuối cùng hiển thị của lưới 2
    'Khi lưu: 100 dòng lưu 1 lần
    Dim conn As New SqlConnection(gsConnectionString)
    Dim trans As SqlTransaction = Nothing
    Dim bRunSQL As Boolean = True
    Dim sRet As New StringBuilder("") 'luu gtri du ra
    Dim bColMove As Boolean = False 'ktra xem co di chuyen cot k?
    Dim arrayIndex() As Integer 'mang luu giu gtri index sau khi doi cot
    Friend WithEvents C1XLBook1 As New C1.C1Excel.C1XLBook
    Private iOldFirstRow_CtrlE As Integer = 0, iOldLastRow_CtrlE As Integer = 0, iOldCol_CtrlE As Integer = 0
    Dim bSelected As Boolean = False
    Dim dResolutionX As Double = 0


#Region "Const of tdbg"
    Private Const COL_BatchID As Integer = 0            ' BatchID
    Private Const COL_PieceworkGroupID As Integer = 1   ' PieceworkGroupID
    Private Const COL_PieceworkGroupName As Integer = 2 ' Nhóm chấm công
    Private Const COL_Total As Integer = 3
#End Region

#Region "Const of tdbg2"
    Private Const COL2_BatchID As Integer = 0              ' BatchID
    Private Const COL2_PieceworkGroupID As Integer = 1     ' PieceworkGroupID
    Private Const COL2_Choose As Integer = 2               ' Chọn
    Private Const COL2_PieceworkGroupName As Integer = 3   ' Nhóm chấm công
    Private Const COL2_EmployeeID As Integer = 4           ' Mã nhân viên
    Private Const COL2_RefEmployeeID As Integer = 5        ' Mã NV phụ
    Private Const COL2_FirstName As Integer = 6            ' Tên nhân viên
    Private Const COL2_EmployeeName As Integer = 7         ' Họ và tên
    Private Const COL2_DepartmentID As Integer = 8         ' Phòng ban
    Private Const COL2_TeamID As Integer = 9               ' Tổ nhóm
    Private Const COL2_WorkingHours As Integer = 10        ' Số giờ làm việc
    Private Const COL2_MasterApportionCoef As Integer = 11 ' Tổng số giờ làm việc
    Private Const COL2_Total As Integer = 12
#End Region

#Region "Parameters from D45F1020"

    Private _productVoucherID As String = ""
    Public WriteOnly Property ProductVoucherID() As String
        Set(ByVal Value As String)
            _productVoucherID = Value
        End Set
    End Property

    Private _productVoucherNo As String = ""
    Public WriteOnly Property ProductVoucherNo() As String
        Set(ByVal Value As String)
            _productVoucherNo = Value
        End Set
    End Property

    Private _voucherDate As String = ""
    Public WriteOnly Property VoucherDate() As String
        Set(ByVal Value As String)
            _voucherDate = Value
        End Set
    End Property

    Private _note As String = ""
    Public WriteOnly Property Note() As String
        Set(ByVal Value As String)
            _note = Value
        End Set
    End Property

    Private _payrollVoucherID As String = ""
    Public WriteOnly Property PayrollVoucherID() As String
        Set(ByVal Value As String)
            _payrollVoucherID = Value
        End Set
    End Property

    Private _departmentID As String
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _transTypeID As String
    Public WriteOnly Property TransTypeID() As String
        Set(ByVal Value As String)
            _transTypeID = Value
        End Set
    End Property
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub D45F1022_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.F1 Then
            btnHotKey_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D45F1022_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        _bSaved = False
        bColMove = False
        '-------------------------------------
        tdbcAnaCategoryID.Tag = "-1"
        tdbcAnaID.Tag = "-1"
        tdbcBlockID.Tag = "-1"
        tdbcDepartmentID.Tag = "-1"
        tdbcTeamID.Tag = "-1"
        tdbcPieceworkGroupID.Tag = "-1"
        tdbcGroupProductID.Tag = "-1"
        '-------------------------------------
        SetBackColorObligatory()
        Loadlanguage()
        LoadTDBDropDown()
        LoadTDBCombo()
        LoadDefault()
        '-------------------------------------
        tdbg_LockedColumns()
        tdbg2_LockedColumns()
        tdbg2_NumberFormat()
        ResetFooterGrid(tdbg, SPLIT0, tdbg.Splits.Count - 1)
        ResetFooterGrid(tdbg2, SPLIT0, tdbg2.Splits.Count - 1)
        '-------------------------------------
        If D45Options.UseEnterMoveDown Then tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
        '*********************
        InputbyUnicode(Me, gbUnicode)
        '*********************
        tdbcNameAutoComplete()

        InputDateCustomFormat(c1dateVoucherDate)

        dResolutionX = SetResolutionForm(Me)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcGroupProductID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadDefault()
        txtProductVoucherNo.Text = _ProductVoucherNo
        txtNote.Text = _Note
        tdbcBlockID.SelectedValue = "%"
        tdbcDepartmentID.SelectedValue = _departmentID
        tdbcTeamID.SelectedValue = _teamID

        c1dateVoucherDate.Value = SQLDateShow(_VoucherDate)
        ReadOnlyControl(txtProductVoucherNo)
        ReadOnlyControl(c1dateVoucherDate)
        ReadOnlyControl(txtNote)
        chkIsPieceworkGroup.Checked = False
        chkIsPieceworkGroup_Click(Nothing, Nothing)

        '---------------------------------------------
        'Khoi tao mang luu chi so 
        ReDim arrayIndex(tdbg.Columns.Count - 1)
        For i As Integer = 0 To tdbg.Columns.Count - 1
            arrayIndex(i) = i
        Next
        '---------------------------------------------
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        'Me.Text = rl3("Chi_tiet_cham_cong_san_pham_-_D45F2004") & UnicodeCaption(gbUnicode)  'Chi tiÕt chÊm c¤ng s¶n phÈm - D45F2004
        Me.Text = rL3("Chi_tiet_thong_ke_san_pham_tinh_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Chi tiÕt thçng k£ s¶n phÈm tÛnh l§¥ng
        '================================================================ 
        lblAnaCategoryID.Text = rL3("Loai_ma_phan_tich") 'Loại mã phân tích
        lblAnaID.Text = rL3("Ma_phan_tich") 'Mã phân tích
        lblBlockID.Text = rL3("Khoi") 'Khối
        lblDepartmentIDFrom.Text = rL3("Phong_ban") 'Phòng ban
        lblTeamIDFrom.Text = rL3("To_nhom") 'Tổ nhóm
        lblPieceworkGroupID.Text = rL3("Nhom_NV_cham_cong") 'Nhóm NV chấm công
        lblGroupProductID.Text = rL3("Nhom_san_pham") 'Nhóm sản phẩm
        '================================================================ 
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnHotKey.Text = rL3("Phim_nong") 'Phím nóng
        btnFilter.Text = rL3("Lo_c") 'Lọ&c
        '================================================================ 
        'chkIsPieceworkGroup.Text = rL3("Cham_cong_theo_nhom_CCSP") 'Chấm công theo nhóm CCSP
        chkIsPieceworkGroup.Text = rL3("Thong_ke_theo_nhom_CCSP") 'Thống kê theo nhóm CCSP
        chkShowSelected.Text = rL3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        '================================================================ 
        optDetailApportionCoef.Text = rL3("He_so_rieng") 'Hệ số riêng
        optMasterApportionCoef.Text = rL3("He_so_chung") 'Hệ số chung
        '================================================================ 
        grpVoucher.Text = rL3("Chung_tu") 'Chứng từ
        pnl1.Text = rL3("Chi_tiet_thong_ke") 'Chi tiết thống kê
        '================================================================ 
        tdbcAnaCategoryID.Columns("AnaCategoryShort").Caption = rL3("Ma") 'Mã
        tdbcAnaCategoryID.Columns("AnaCategoryName").Caption = rL3("Ten") 'Tên
        tdbcAnaID.Columns("AnaID").Caption = rL3("Ma") 'Mã
        tdbcAnaID.Columns("AnaName").Caption = rL3("Ten") 'Tên
        tdbcPieceworkGroupID.Columns("PieceworkGroupID").Caption = rL3("Ma") 'Mã
        tdbcPieceworkGroupID.Columns("PieceworkGroupName").Caption = rL3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbcGroupProductID.Columns("GroupProductID").Caption = rL3("Ma") 'Mã
        tdbcGroupProductID.Columns("GroupProductName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbdFirstName.Columns("EmployeeID").Caption = rL3("Ma_nhan_vien") 'Mã nhân viên
        tdbdFirstName.Columns("RefEmployeeID").Caption = rL3("Ma_NV_phu") 'Mã NV phụ
        tdbdFirstName.Columns("EmployeeName").Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbdFirstName.Columns("FirstName").Caption = rL3("Ten_nhan_vien") 'Tên nhân viên
        tdbdRefEmployeeID.Columns("EmployeeID").Caption = rL3("Ma_nhan_vien") 'Mã nhân viên
        tdbdRefEmployeeID.Columns("RefEmployeeID").Caption = rL3("Ma_NV_phu") 'Mã NV phụ
        tdbdRefEmployeeID.Columns("EmployeeName").Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbdRefEmployeeID.Columns("FirstName").Caption = rL3("Ten_nhan_vien") 'Tên nhân viên
        tdbdEmployeeID.Columns("EmployeeID").Caption = rL3("Ma_nhan_vien") 'Mã nhân viên
        tdbdEmployeeID.Columns("RefEmployeeID").Caption = rL3("Ma_NV_phu") 'Mã NV phụ
        tdbdEmployeeID.Columns("EmployeeName").Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbdEmployeeID.Columns("FirstName").Caption = rL3("Ten_nhan_vien") 'Tên nhân viên
        '================================================================ 
        tdbg.Columns("PieceworkGroupName").Caption = rL3("Nhom_cham_cong") 'Nhóm chấm công
        '================================================================ 
        tdbg2.Columns("IsChosen").Caption = rL3("Chon") 'Chọn
        tdbg2.Columns("PieceworkGroupName").Caption = rL3("Nhom_cham_cong") 'Nhóm chấm công
        tdbg2.Columns("EmployeeID").Caption = rL3("Ma_nhan_vien") 'Mã nhân viên
        tdbg2.Columns("RefEmployeeID").Caption = rL3("Ma_NV_phu") 'Mã NV phụ
        tdbg2.Columns("FirstName").Caption = rL3("Ten_nhan_vien") 'Tên nhân viên
        tdbg2.Columns("EmployeeName").Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbg2.Columns("DepartmentID").Caption = rL3("Phong_ban") 'Phòng ban
        tdbg2.Columns("TeamID").Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg2.Columns("WorkingHours").Caption = rL3("So_gio_lam_viec") 'Số giờ làm việc
        tdbg2.Columns("MasterApportionCoef").Caption = rL3("Tong_so_gio_lam_viec") 'Tổng số giờ làm việc
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PieceworkGroupName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg2_LockedColumns()
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_PieceworkGroupName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg2_NumberFormat()
        tdbg2.Columns(COL2_WorkingHours).NumberFormat = DxxFormat.DefaultNumber2
        tdbg2.Columns(COL2_MasterApportionCoef).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub LoadTDBCombo()
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************

        Dim sSQL As String = ""
        'Load tdbcAnaID
        sSQL = "Select D50.AnaCategoryID, D51.AnaID, D51.AnaName" & UnicodeJoin(gbUnicode) & " As AnaName" & vbCrLf
        sSQL &= "From D91T0051 D51  WITH(NOLOCK) Inner Join D91T0050 D50  WITH(NOLOCK) On D51.AnaCategoryID = D50.AnaCategoryID" & vbCrLf
        sSQL &= "Where Disabled=0 And D50.AnaTypeID='M'" & vbCrLf
        sSQL &= "Order by D50.AnaCategoryID, D51.AnaID"
        dtAnaID = ReturnDataTable(sSQL)

        'Load tdbcAnaCategoryID
        sSQL = "Select D91.AnaCategoryID, D91.AnaCategoryShort, D91.AnaCategoryName" & UnicodeJoin(gbUnicode) & " As AnaCategoryName, D91.AnaCategoryStatus, D91.UseD45 " & vbCrLf
        sSQL &= "From D91T0050 D91 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where D91.AnaTypeID='M' And D91.AnaCategoryStatus=1" & vbCrLf
        sSQL &= "Order by D91.AnaCategoryID"
        LoadDataSource(tdbcAnaCategoryID, sSQL, gbUnicode)

        'DepartmentID
        sSQL = "Select DepartmentID, DepartmentName" & UnicodeJoin(gbUnicode) & " As DepartmentName, BlockID, 1 As DisplayOrder" & vbCrLf
        sSQL &= "From D91T0012 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 And DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Union " & vbCrLf
        sSQL &= "Select '%' as DepartmentID, " & sLanguage & " As DepartmentName, '%' AS BlockID, 0 As DisplayOrder" & vbCrLf
        sSQL &= "Order by DisplayOrder, DepartmentName"
        dtDepartmentID = ReturnDataTable(sSQL)

        'TeamID
        sSQL = "Select D01.TeamID, D01.TeamName" & UnicodeJoin(gbUnicode) & " As TeamName, D01.DepartmentID, D02.BlockID, 1 As DisplayOrder " & vbCrLf
        sSQL &= "From D09T0227 D01  WITH(NOLOCK) Inner Join D91T0012 D02  WITH(NOLOCK) On D01.DepartmentID=D02.DepartmentID" & vbCrLf
        sSQL &= "Where D01.Disabled=0  And DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Union Select '%' as TeamID, " & sLanguage & " As TeamName, '%' as DepartmentID, '%' as BlockID, 0 As DisplayOrder" & vbCrLf
        sSQL &= "Order by DisplayOrder, TeamName"
        dtTeamID = ReturnDataTable(sSQL)

        'Load tdbcBlockID 
        sSQL = "Select BlockID, BlockName" & UnicodeJoin(gbUnicode) & " As BlockName, 1 As DisplayOrder  From D09T1140 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where DivisionID=" & SQLString(gsDivisionID) & " And Disabled=0" & vbCrLf
        sSQL &= "Union Select '%' As BlockID, " & sLanguage & " As BlockName, 0 As DisplayOrder" & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, BlockName"
        LoadDataSource(tdbcBlockID, sSQL, gbUnicode)

        'Load tdbcPieceworkGroupID
        sSQL = "Select D50.PieceworkGroupID, D50.PieceworkGroupName" & UnicodeJoin(gbUnicode) & " As PieceworkGroupName, D50.GroupProductID" & vbCrLf
        sSQL &= "From D45T1050 D50 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where D50.Disabled=0" & vbCrLf
        sSQL &= "Order by D50.PieceworkGroupID"
        LoadDataSource(tdbcPieceworkGroupID, sSQL, gbUnicode)

        'Load tdbcGroupProductID
        sSQL = "Select D45.GroupProductID, D45.GroupProductName" & UnicodeJoin(gbUnicode) & " As GroupProductName" & vbCrLf
        sSQL &= "From D45T1070 D45 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where D45.Disabled=0" & vbCrLf
        sSQL &= "Order by D45.GroupProductID"
        LoadDataSource(tdbcGroupProductID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdEmployeeID
        sSQL = "SELECT D13.EmployeeID as EmployeeID, D09.RefEmployeeID as RefEmployeeID, "
        If gbUnicode = False Then
            sSQL &= "Isnull(D09.LastName,'') + ' ' + Isnull(D09.MiddleName,'') + ' ' + Isnull(D09.FirstName,'') as EmployeeName, "
        Else
            sSQL &= "Isnull(D09.LastNameU,'') + ' ' + Isnull(D09.MiddleNameU,'') + ' ' + Isnull(D09.FirstNameU,'') as EmployeeName, "
        End If

        sSQL &= "D09.FirstName" & UnicodeJoin(gbUnicode) & " As FirstName, D13.DepartmentID, D13.TeamID, D91.BlockID" & vbCrLf
        sSQL &= "FROM D13T0101 D13  WITH(NOLOCK) INNER JOIN D09T0201 D09  WITH(NOLOCK) ON D13.EmployeeID = D09.EmployeeID " & vbCrLf
        sSQL &= "INNER JOIN	D91T0012 D91  WITH(NOLOCK) ON	D91.DepartmentID = D09.DepartmentID" & vbCrLf
        sSQL &= "WHERE D13.DivisionID = " & SQLString(gsDivisionID) & " And PayrollVoucherID = " & SQLString(_payrollVoucherID)
        dtEmployeeID = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadTDBCAnaID()
        Dim sAnaCategoryID As String = ""

        If tdbcAnaCategoryID.SelectedValue Is Nothing Then
            sAnaCategoryID = ""
        Else
            sAnaCategoryID = tdbcAnaCategoryID.SelectedValue.ToString
        End If

        LoadDataSource(tdbcAnaID, ReturnTableFilter(dtAnaID, "AnaCategoryID=" & SQLString(sAnaCategoryID), True), gbUnicode)
    End Sub

    Private Sub LoadtdbcDepartmentID()
        If tdbcBlockID.SelectedValue Is Nothing Then
            sBlockID = ""
        Else
            sBlockID = tdbcBlockID.SelectedValue.ToString
        End If

        If sBlockID = "%" Then
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, ""), gbUnicode)
        Else
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID=" & SQLString(sBlockID) & " or DepartmentID = '%'", True), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbcTeamID()
        If tdbcBlockID.SelectedValue Is Nothing Then
            sBlockID = ""
        Else
            sBlockID = tdbcBlockID.SelectedValue.ToString
        End If
        If tdbcDepartmentID.SelectedValue Is Nothing Then
            sDepartmentID = ""
        Else
            sDepartmentID = tdbcDepartmentID.SelectedValue.ToString
        End If

        If sDepartmentID = "%" AndAlso sBlockID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, ""), gbUnicode)
        ElseIf sBlockID = "%" AndAlso sDepartmentID <> "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID=" & SQLString(sDepartmentID) & "or TeamID='%'", True), gbUnicode)
        ElseIf sBlockID <> "%" AndAlso sDepartmentID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "BlockID=" & SQLString(sBlockID) & "or TeamID='%'", True), gbUnicode)
        ElseIf sBlockID <> "%" AndAlso sDepartmentID <> "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID=" & SQLString(sDepartmentID) & " And BlockID=" & SQLString(sBlockID) & " or TeamID='%'", True), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbdEmployeeID()
        If tdbcBlockID.SelectedValue Is Nothing Then
            sBlockID = ""
        Else
            sBlockID = tdbcBlockID.SelectedValue.ToString
        End If
        If tdbcDepartmentID.SelectedValue Is Nothing Then
            sDepartmentID = ""
        Else
            sDepartmentID = tdbcDepartmentID.SelectedValue.ToString
        End If
        If tdbcTeamID.SelectedValue Is Nothing Then
            sTeamID = ""
        Else
            sTeamID = tdbcTeamID.SelectedValue.ToString
        End If

        If sBlockID = "%" Then
            If sDepartmentID = "%" AndAlso sTeamID = "%" Then
                LoadDataSource(tdbdEmployeeID, ReturnTableFilter(dtEmployeeID, ""), gbUnicode)
            ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
                LoadDataSource(tdbdEmployeeID, ReturnTableFilter(dtEmployeeID, "TeamID=" & SQLString(sTeamID), True), gbUnicode)
            ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
                LoadDataSource(tdbdEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID), True), gbUnicode)
            Else
                LoadDataSource(tdbdEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID), True), gbUnicode)
            End If
        Else
            If sDepartmentID = "%" AndAlso sTeamID = "%" Then
                LoadDataSource(tdbdEmployeeID, ReturnTableFilter(dtEmployeeID, "BlockID=" & SQLString(sBlockID), True), gbUnicode)
            ElseIf sDepartmentID = "%" AndAlso sTeamID <> "%" Then
                LoadDataSource(tdbdEmployeeID, ReturnTableFilter(dtEmployeeID, "TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID), True), gbUnicode)
            ElseIf sTeamID = "%" AndAlso sDepartmentID <> "%" Then
                LoadDataSource(tdbdEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And BlockID=" & SQLString(sBlockID), True), gbUnicode)
            Else
                LoadDataSource(tdbdEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " And BlockID=" & SQLString(sBlockID), True), gbUnicode)
            End If
        End If

        Dim dtRefEmployeeID As DataTable = CType(tdbdEmployeeID.DataSource, DataTable).Copy
        Dim dtFirstName As DataTable = CType(tdbdEmployeeID.DataSource, DataTable).Copy
        LoadDataSource(tdbdRefEmployeeID, dtRefEmployeeID, gbUnicode)
        LoadDataSource(tdbdFirstName, dtFirstName, gbUnicode)
    End Sub

#Region "Events tdbcAnaCategoryID"

    Private Sub tdbcAnaCategoryID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaCategoryID.LostFocus
        If tdbcAnaCategoryID.FindStringExact(tdbcAnaCategoryID.Text) = -1 Then tdbcAnaCategoryID.Text = ""
    End Sub

    Private Sub tdbcAnaCategoryID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAnaCategoryID.SelectedValueChanged
        LoadTDBCAnaID()
        tdbcAnaID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcAnaID"

    Private Sub tdbcAnaID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaID.LostFocus
        If tdbcAnaID.FindStringExact(tdbcAnaID.Text) = -1 Then tdbcAnaID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPieceworkGroupID"

    Private Sub tdbcPieceworkGroupID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPieceworkGroupID.SelectedValueChanged
        If tdbcPieceworkGroupID.SelectedValue Is Nothing Then
            tdbcGroupProductID.Text = ""
        Else
            tdbcGroupProductID.Text = tdbcPieceworkGroupID.Columns("GroupProductID").Text
        End If
    End Sub

#End Region

#Region "Events tdbcGroupProductID"

    Private Sub tdbcGroupProductID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.LostFocus
        If tdbcGroupProductID.FindStringExact(tdbcGroupProductID.Text) = -1 Then tdbcGroupProductID.Text = ""
    End Sub

#End Region

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        LoadtdbcDepartmentID()
        tdbcDepartmentID.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        LoadtdbcTeamID()
        tdbcTeamID.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        LoadtdbdEmployeeID()
    End Sub

#End Region

#Region "53.	Sửa lỗi gõ tên trên combo hay dropdown"

    Private Sub tdbcNameAutoComplete()
        tdbcPieceworkGroupID.AutoCompletion = False
        tdbcBlockID.AutoCompletion = False
        tdbcDepartmentID.AutoCompletion = False
        tdbcTeamID.AutoCompletion = False
    End Sub

    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPieceworkGroupID.LostFocus, _
                tdbcBlockID.LostFocus, tdbcDepartmentID.LostFocus, tdbcTeamID.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPieceworkGroupID.Close, _
                tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPieceworkGroupID.Validated, _
                tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Sub LoadTableField()
        Dim sSQL As String = ""
        'Load cac cot dong cho luoi 1
        sSQL = SQLStoreD45P2042_tdbg()
        dtAddField = ReturnDataTable(sSQL)

        'Load cac cot dong cho luoi 2
        sSQL = SQLStoreD45P2042_tdbg1()
        dtAddField1 = ReturnDataTable(sSQL)
    End Sub

    Private Sub CreateSplit_tdbg()
        Dim i As Integer

        'If tdbg.Splits.Count > 1 Then tdbg.RemoveHorizontalSplit(1)
        tdbg.InsertHorizontalSplit(1)

        tdbg.Splits(0).SplitSize = 170
        tdbg.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
        tdbg.Splits(0).ColumnCaptionHeight = 30
        tdbg.Splits(0).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always

        tdbg.Splits(1).SplitSize = 1
        tdbg.Splits(1).ColumnCaptionHeight = 30
        tdbg.Splits(1).RecordSelectors = False
        tdbg.Splits(1).BorderStyle = Border3DStyle.Flat
        tdbg.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always

        For i = 0 To COL_Total - 1
            tdbg.Splits(1).DisplayColumns(i).Visible = False
        Next
    End Sub

    Private Sub CreateSplit_tdbg1()
        Dim i As Integer

        'If tdbg2.Splits.Count > 1 Then tdbg2.RemoveHorizontalSplit(1)
        tdbg2.InsertHorizontalSplit(1)

        tdbg2.Splits(0).SplitSize = 1
        tdbg2.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
        tdbg2.Splits(0).ColumnCaptionHeight = 30
        tdbg2.Splits(0).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always

        tdbg2.Splits(1).SplitSize = 1
        tdbg2.Splits(1).ColumnCaptionHeight = 30
        tdbg2.Splits(1).RecordSelectors = False
        tdbg2.Splits(1).BorderStyle = Border3DStyle.Flat
        tdbg2.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always

        For i = 0 To COL2_Total - 1
            tdbg2.Splits(1).DisplayColumns(i).Visible = False
        Next

    End Sub

    Private Sub AddField_tdbg()
        Try
            Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
            If dtAddField.Rows.Count > 0 Then
                nTotalProduct = dtAddField.Rows.Count
                CreateSplit_tdbg()

                For j As Integer = 0 To dtAddField.Rows.Count - 1
                    'add các cột : 5 cột cho 1 sản phẩm
                    dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc.DataField = "QT01_" & dtAddField.Rows(j).Item("ProductID").ToString
                    dc.DataType = Type.GetType("System.Decimal")
                    dc.NumberFormat = DxxFormat.DefaultNumber2

                    tdbg.Columns.Add(dc)
                    tdbg.Columns(dc.DataField).Caption = dtAddField.Rows(j).Item("ProductName").ToString & vbCrLf & "(" & dtAddField.Rows(j).Item("QU01_ShortName").ToString & ")"

                    'Moi
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = Not L3Bool(dtAddField.Rows(j).Item("QU01"))
                    tdbg.Columns(dc.DataField).Tag = tdbg.Splits(1).DisplayColumns(dc.DataField).Visible
                    'ID 58242: Chuẩn hóa độ phân giải
                    tdbg.Splits(1).DisplayColumns(dc).Width = 110 * L3Int(IIf(dResolutionX > 0, dResolutionX, 1))
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

                    '-------------------------------------------------------------------------------
                    dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc.DataField = "QT02_" & dtAddField.Rows(j).Item("ProductID").ToString
                    dc.DataType = Type.GetType("System.Decimal")
                    dc.NumberFormat = DxxFormat.DefaultNumber2
                    tdbg.Columns.Add(dc)
                    tdbg.Columns(dc.DataField).Caption = dtAddField.Rows(j).Item("ProductName").ToString & vbCrLf & "(" & dtAddField.Rows(j).Item("QU02_ShortName").ToString & ")"

                    'Moi
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = Not L3Bool(dtAddField.Rows(j).Item("QU02"))
                    tdbg.Columns(dc.DataField).Tag = tdbg.Splits(1).DisplayColumns(dc.DataField).Visible
                    'ID 58242: Chuẩn hóa độ phân giải
                    tdbg.Splits(1).DisplayColumns(dc).Width = 110 * L3Int(IIf(dResolutionX > 0, dResolutionX, 1))
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

                    '-------------------------------------------------------------------------------
                    dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc.DataField = "QT03_" & dtAddField.Rows(j).Item("ProductID").ToString
                    dc.DataType = Type.GetType("System.Decimal")
                    dc.NumberFormat = DxxFormat.DefaultNumber2

                    tdbg.Columns.Add(dc)
                    tdbg.Columns(dc.DataField).Caption = dtAddField.Rows(j).Item("ProductName").ToString & vbCrLf & "(" & dtAddField.Rows(j).Item("QU03_ShortName").ToString & ")"

                    'Moi
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = Not L3Bool(dtAddField.Rows(j).Item("QU03"))
                    tdbg.Columns(dc.DataField).Tag = tdbg.Splits(1).DisplayColumns(dc.DataField).Visible
                    'ID 58242: Chuẩn hóa độ phân giải
                    tdbg.Splits(1).DisplayColumns(dc).Width = 110 * L3Int(IIf(dResolutionX > 0, dResolutionX, 1))
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

                    '-------------------------------------------------------------------------------
                    dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc.DataField = "QT04_" & dtAddField.Rows(j).Item("ProductID").ToString
                    dc.DataType = Type.GetType("System.Decimal")
                    dc.NumberFormat = DxxFormat.DefaultNumber2

                    tdbg.Columns.Add(dc)
                    tdbg.Columns(dc.DataField).Caption = dtAddField.Rows(j).Item("ProductName").ToString & vbCrLf & "(" & dtAddField.Rows(j).Item("QU04_ShortName").ToString & ")"

                    'Moi
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = Not L3Bool(dtAddField.Rows(j).Item("QU04"))
                    tdbg.Columns(dc.DataField).Tag = tdbg.Splits(1).DisplayColumns(dc.DataField).Visible
                    'ID 58242: Chuẩn hóa độ phân giải
                    tdbg.Splits(1).DisplayColumns(dc).Width = 110 * L3Int(IIf(dResolutionX > 0, dResolutionX, 1))
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    '-------------------------------------------------------------------------------
                    dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc.DataField = "QT05_" & dtAddField.Rows(j).Item("ProductID").ToString
                    dc.DataType = Type.GetType("System.Decimal")
                    dc.NumberFormat = DxxFormat.DefaultNumber2

                    tdbg.Columns.Add(dc)
                    tdbg.Columns(dc.DataField).Caption = dtAddField.Rows(j).Item("ProductName").ToString & vbCrLf & "(" & dtAddField.Rows(j).Item("QU05_ShortName").ToString & ")"

                    'Moi
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = Not L3Bool(dtAddField.Rows(j).Item("QU05"))
                    tdbg.Columns(dc.DataField).Tag = tdbg.Splits(1).DisplayColumns(dc.DataField).Visible
                    'ID 58242: Chuẩn hóa độ phân giải
                    tdbg.Splits(1).DisplayColumns(dc).Width = 110 * L3Int(IIf(dResolutionX > 0, dResolutionX, 1))
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg.Splits(1).ColumnFooterHeight = 17
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AddField_tdbg1()
        Try
            Dim dc1 As C1.Win.C1TrueDBGrid.C1DataColumn
            If dtAddField1.Rows.Count > 0 Then
                nTotalProduct1 = dtAddField1.Rows.Count
                CreateSplit_tdbg1()
                For j As Integer = 0 To dtAddField1.Rows.Count - 1
                    'add các cột : 6 cột cho 1 sản phẩm
                    dc1 = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc1.DataField = "QT01_" & dtAddField1.Rows(j).Item("ProductID").ToString
                    dc1.DataType = Type.GetType("System.Decimal")
                    dc1.NumberFormat = DxxFormat.DefaultNumber2

                    tdbg2.Columns.Add(dc1)
                    tdbg2.Columns(dc1.DataField).Caption = dtAddField1.Rows(j).Item("ProductName").ToString & vbCrLf & "(" & dtAddField1.Rows(j).Item("QU01_ShortName").ToString & ")"
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.Font = FontUnicode(gbUnicode)

                    'Moi
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible = Not L3Bool(dtAddField1.Rows(j).Item("QU01"))
                    tdbg2.Columns(dc1.DataField).Tag = tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible
                    'ID 58242: Chuẩn hóa độ phân giải
                    tdbg2.Splits(1).DisplayColumns(dc1).Width = 110 * L3Int(IIf(dResolutionX > 0, dResolutionX, 1))
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    '-------------------------------------------------------------------------------
                    dc1 = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc1.DataField = "QT02_" & dtAddField1.Rows(j).Item("ProductID").ToString
                    dc1.DataType = Type.GetType("System.Decimal")
                    dc1.NumberFormat = DxxFormat.DefaultNumber2

                    tdbg2.Columns.Add(dc1)
                    tdbg2.Columns(dc1.DataField).Caption = dtAddField1.Rows(j).Item("ProductName").ToString & vbCrLf & "(" & dtAddField1.Rows(j).Item("QU02_ShortName").ToString & ")"
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.Font = FontUnicode(gbUnicode)

                    'Moi
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible = Not L3Bool(dtAddField1.Rows(j).Item("QU02"))
                    tdbg2.Columns(dc1.DataField).Tag = tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible
                    'ID 58242: Chuẩn hóa độ phân giải
                    tdbg2.Splits(1).DisplayColumns(dc1).Width = 110 * L3Int(IIf(dResolutionX > 0, dResolutionX, 1))
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    '-------------------------------------------------------------------------------
                    dc1 = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc1.DataField = "QT03_" & dtAddField1.Rows(j).Item("ProductID").ToString
                    dc1.DataType = Type.GetType("System.Decimal")
                    dc1.NumberFormat = DxxFormat.DefaultNumber2

                    tdbg2.Columns.Add(dc1)
                    tdbg2.Columns(dc1.DataField).Caption = dtAddField1.Rows(j).Item("ProductName").ToString & vbCrLf & "(" & dtAddField1.Rows(j).Item("QU03_ShortName").ToString & ")"
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.Font = FontUnicode(gbUnicode)

                    'Moi
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible = Not L3Bool(dtAddField1.Rows(j).Item("QU03"))
                    tdbg2.Columns(dc1.DataField).Tag = tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible
                    'ID 58242: Chuẩn hóa độ phân giải
                    tdbg2.Splits(1).DisplayColumns(dc1).Width = 110 * L3Int(IIf(dResolutionX > 0, dResolutionX, 1))
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    '-------------------------------------------------------------------------------
                    dc1 = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc1.DataField = "QT04_" & dtAddField1.Rows(j).Item("ProductID").ToString
                    dc1.DataType = Type.GetType("System.Decimal")
                    dc1.NumberFormat = DxxFormat.DefaultNumber2

                    tdbg2.Columns.Add(dc1)
                    tdbg2.Columns(dc1.DataField).Caption = dtAddField1.Rows(j).Item("ProductName").ToString & vbCrLf & "(" & dtAddField1.Rows(j).Item("QU04_ShortName").ToString & ")"
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.Font = FontUnicode(gbUnicode)

                    'Moi
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible = Not L3Bool(dtAddField1.Rows(j).Item("QU04"))
                    tdbg2.Columns(dc1.DataField).Tag = tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible
                    'ID 58242: Chuẩn hóa độ phân giải
                    tdbg2.Splits(1).DisplayColumns(dc1).Width = 110 * L3Int(IIf(dResolutionX > 0, dResolutionX, 1))
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    '-------------------------------------------------------------------------------
                    dc1 = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc1.DataField = "QT05_" & dtAddField1.Rows(j).Item("ProductID").ToString
                    dc1.DataType = Type.GetType("System.Decimal")
                    dc1.NumberFormat = DxxFormat.DefaultNumber2

                    tdbg2.Columns.Add(dc1)
                    tdbg2.Columns(dc1.DataField).Caption = dtAddField1.Rows(j).Item("ProductName").ToString & vbCrLf & "(" & dtAddField1.Rows(j).Item("QU05_ShortName").ToString & ")"
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.Font = FontUnicode(gbUnicode)

                    'Moi
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible = Not L3Bool(dtAddField1.Rows(j).Item("QU05"))
                    tdbg2.Columns(dc1.DataField).Tag = tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible
                    'ID 58242: Chuẩn hóa độ phân giải
                    tdbg2.Splits(1).DisplayColumns(dc1).Width = 110 * L3Int(IIf(dResolutionX > 0, dResolutionX, 1))
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    '-------------------------------------------------------------------------------
                    dc1 = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc1.DataField = "DetailApportionCoef_" & dtAddField1.Rows(j).Item("ProductID").ToString
                    dc1.DataType = Type.GetType("System.Decimal")
                    dc1.NumberFormat = DxxFormat.DefaultNumber2

                    tdbg2.Columns.Add(dc1)
                    tdbg2.Columns(dc1.DataField).Caption = dtAddField1.Rows(j).Item("ProductName").ToString & vbCrLf & "(" & dtAddField1.Rows(j).Item("DetailApportionCoef_ShortName").ToString & ")"
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.Font = FontUnicode(gbUnicode)

                    'Moi
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible = Not L3Bool(dtAddField1.Rows(j).Item("QU06"))
                    tdbg2.Columns(dc1.DataField).Tag = tdbg2.Splits(1).DisplayColumns(dc1.DataField).Visible
                    'ID 58242: Chuẩn hóa độ phân giải
                    tdbg2.Splits(1).DisplayColumns(dc1).Width = 110 * L3Int(IIf(dResolutionX > 0, dResolutionX, 1))
                    tdbg2.Splits(1).DisplayColumns(dc1.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg2.Splits(1).DisplayColumns(dc1).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P2004()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)

        FooterTotalGrid(tdbg, COL_PieceworkGroupName)
        CalFooter()
    End Sub

    Private Sub LoadTDBGrid2()
        Dim sSQL As String
        If chkIsPieceworkGroup.Checked = True Then
            sSQL = SQLStoreD45P2041(1, tdbg.Columns(COL_BatchID).Text)
        Else
            sSQL = SQLStoreD45P2041(0, "")
        End If
        dtGrid2 = ReturnDataTable(sSQL)
        LoadDataSource(tdbg2, dtGrid2, gbUnicode)

        '-------------------------
        If chkIsPieceworkGroup.Checked = False Or (chkIsPieceworkGroup.Checked And optDetailApportionCoef.Checked) Then
            SumDetailApportionCoef()
            tdbg2.Splits(SPLIT0).DisplayColumns(COL2_MasterApportionCoef).Locked = True
            tdbg2.Splits(SPLIT0).DisplayColumns(COL2_MasterApportionCoef).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        Else
            tdbg2.Splits(SPLIT0).DisplayColumns(COL2_MasterApportionCoef).Locked = False
            tdbg2.Splits(SPLIT0).DisplayColumns(COL2_MasterApportionCoef).Style.ResetBackColor()
        End If

        FooterTotalGrid(tdbg2, COL2_EmployeeID)
        CalFooter2()
    End Sub

    Private Sub CalFooter()
        Dim i, j As Integer
        Dim Sum As Double

        If tdbg.Splits.Count = 1 Then Exit Sub


        For i = COL_Total To tdbg.Columns.Count - 1
            If bColMove = False Then
                If tdbg.Splits(1).DisplayColumns(i).Visible = True Then
                    Sum = 0
                    For j = 0 To tdbg.RowCount - 1
                        Sum = Sum + Number(IIf(tdbg(j, i).ToString = "", 0, tdbg(j, i).ToString))
                    Next
                End If
            Else
                Sum = 0
                For j = 0 To tdbg.RowCount - 1
                    Sum = Sum + Number(IIf(tdbg(j, i).ToString = "", 0, tdbg(j, i).ToString))
                Next
            End If
            tdbg.Columns(i).FooterText = Format(Sum, DxxFormat.DefaultNumber2)
        Next
    End Sub

    Private Sub CalFooter2()
        Dim i, j As Integer
        Dim Sum As Double


        For i = COL2_WorkingHours To tdbg2.Columns.Count - 1
            Sum = 0
            For j = 0 To tdbg2.RowCount - 1
                If i = COL2_WorkingHours Or i = COL2_MasterApportionCoef Then
                    Sum = Sum + Number(IIf(tdbg2(j, i).ToString = "", 0, tdbg2(j, i).ToString))
                Else
                    If tdbg2.Splits(1).DisplayColumns(i).Visible Then
                        Sum = Sum + Number(IIf(tdbg2(j, i).ToString = "", 0, tdbg2(j, i).ToString))
                    End If
                End If

            Next
            tdbg2.Columns(i).FooterText = Format(Sum, DxxFormat.DefaultNumber2)
        Next
    End Sub

    Private Sub SumDetailApportionCoef()
        Dim i, j As Integer
        Dim Sum As Double = 0

        If tdbg2.Splits.Count = 1 Then Exit Sub

        For i = 0 To tdbg2.RowCount - 1
            Sum = 0
            For j = COL2_Total To tdbg2.Columns.Count - 1
                If tdbg2.Splits(1).DisplayColumns(j).Visible Then 'If tdbg2.Columns(j).DataField.Contains("DetailApportionCoef_") Then
                    Sum = Sum + Number(IIf(tdbg2(i, j).ToString = "", 0, tdbg2(i, j).ToString))
                End If
            Next

            tdbg2(i, COL2_MasterApportionCoef) = Format(Sum, DxxFormat.DefaultNumber2)
        Next
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If chkIsPieceworkGroup.Checked Then
            If tdbcPieceworkGroupID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Nhom_NV_cham_cong"))
                tdbcPieceworkGroupID.Focus()
                Return False
            End If
        End If

        If tdbcGroupProductID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Nhom_san_pham"))
            tdbcGroupProductID.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        If AllowSave() = False Then Exit Sub

        tdbg.UpdateData()
        tdbg2.UpdateData()

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder("")

        If optDetailApportionCoef.Checked Then
            sSQL.Append(SaveData_Detail.ToString)
        Else
            sSQL.Append(SaveData_Master.ToString)
        End If

        If sRet.ToString = "-1" Then ' Thực thi không thành công
            trans.Rollback()
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        Else ' Thực thi thành công
            If sRet.ToString <> "" Then
                If bRunSQL = ExecuteSQL_MoreCommand(sRet.ToString) Then 'Thực thi những dòng còn lại
                    trans.Commit()
                    SaveOK()
                    _bSaved = True
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
                Else
                    trans.Rollback()
                    SaveNotOK()
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                End If
            Else
                trans.Commit()
                SaveOK()
                _bSaved = True
                btnSave.Enabled = True
                btnClose.Enabled = True
                btnClose.Focus()
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        If e.ColIndex >= COL_Total Then
            If L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Money) = False Then
                tdbg.Columns(e.ColIndex).Text = "0.00"
            Else
                tdbg.Columns(e.ColIndex).Text = SQLNumber(tdbg.Columns(e.ColIndex).Text, DxxFormat.DefaultNumber2)
            End If
        End If
    End Sub

    Private Sub tdbg_ColMove(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColMoveEventArgs) Handles tdbg.ColMove
        Dim iTmp As Integer
        If e.Position < e.ColIndex Then
            iTmp = arrayIndex(e.ColIndex)
            For i As Integer = e.ColIndex To e.Position + 1 Step -1
                arrayIndex(i) = arrayIndex(i - 1)
            Next
            arrayIndex(e.Position) = iTmp
        Else
            iTmp = arrayIndex(e.ColIndex)
            For i As Integer = e.ColIndex To e.Position - 1
                arrayIndex(i) = arrayIndex(i + 1)
            Next
            arrayIndex(e.Position) = iTmp
        End If
        bColMove = True
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Dim iCol As Integer = CInt(IIf(bColMove = False, tdbg.Col, arrayIndex(tdbg.Col)).ToString)

        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            If tdbg.Col >= COL_Total Then
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Bookmark)

                Dim j As Integer
                Dim Sum As Double
                If tdbg.Splits(1).DisplayColumns(iCol).Visible = True Then
                    Sum = 0
                    For j = 0 To tdbg.RowCount - 1
                        Sum = Sum + Number(IIf(tdbg(j, iCol).ToString = "", 0, tdbg(j, iCol).ToString))
                    Next
                    tdbg.Columns(iCol).FooterText = Format(Sum, DxxFormat.DefaultNumber2)
                End If
            End If
            tdbg.Refresh()
        ElseIf e.KeyCode = Keys.Enter And iCol = iColLast Then
            If D45Options.UseEnterMoveDown Then Exit Sub
            HotKeyEnterGrid(tdbg, COL_Total, e, tdbg.Splits.Count - 1)
        End If

        HotKeyDownGrid(e, tdbg, COL_Total, 0, tdbg.Splits.Count - 1)
    End Sub

    Private Sub btnHotKey_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHotKey.Click
        Dim f As New D45F7777
        f.FormID = "D45F2004"
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Dim iCol As Integer = CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
        If iCol >= COL_Total Then
            Dim Sum As Double
            If tdbg.Splits(1).DisplayColumns(iCol).Visible = True Then
                Sum = 0
                For j As Integer = 0 To tdbg.RowCount - 1
                    Sum = Sum + Number(IIf(tdbg(j, iCol).ToString = "", 0, tdbg(j, iCol).ToString))
                Next
                tdbg.Columns(iCol).FooterText = Format(Sum, DxxFormat.DefaultNumber2)
            End If
        End If
        tdbg.Refresh()
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.Col >= COL_Total Then
            CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Text, tdbg.Bookmark)

            Dim j As Integer
            Dim Sum As Double

            Sum = 0
            For j = 0 To tdbg.RowCount - 1
                Sum = Sum + Number(IIf(tdbg(j, e.ColIndex).ToString = "", 0, tdbg(j, e.ColIndex).ToString))
            Next
            tdbg.Columns(e.ColIndex).FooterText = Format(Sum, DxxFormat.DefaultNumber2)

        End If
    End Sub

    Private Sub tdbg2_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.AfterColUpdate
        tdbg2.UpdateData()

        Select Case e.ColIndex
            Case COL2_Choose
                If L3Bool(tdbg2.Columns(COL2_Choose).Text) = False Then
                    tdbg2.Columns(COL2_EmployeeID).DropDown = Nothing
                    tdbg2.Columns(COL2_RefEmployeeID).DropDown = Nothing
                    tdbg2.Columns(COL2_FirstName).DropDown = Nothing
                Else
                    tdbg2.Columns(COL2_EmployeeID).DropDown = tdbdEmployeeID
                    tdbg2.Columns(COL2_RefEmployeeID).DropDown = tdbdRefEmployeeID
                    tdbg2.Columns(COL2_FirstName).DropDown = tdbdFirstName
                End If
            Case COL2_EmployeeID, COL2_RefEmployeeID, COL2_FirstName
                If chkIsPieceworkGroup.Checked Then
                    tdbg2.Columns(COL2_PieceworkGroupID).Text = tdbg(tdbg.Row, COL_PieceworkGroupID).ToString
                    tdbg2.Columns(COL2_PieceworkGroupName).Text = tdbg(tdbg.Row, COL_PieceworkGroupName).ToString
                Else
                    tdbg2.Columns(COL2_PieceworkGroupID).Text = ""
                    tdbg2.Columns(COL2_PieceworkGroupName).Text = ""
                End If
            Case COL2_WorkingHours, COL2_MasterApportionCoef
                CalVaue_Col(e.ColIndex)
        End Select

        If e.ColIndex >= COL2_Total Then
            If chkIsPieceworkGroup.Checked = False Or (chkIsPieceworkGroup.Checked And optDetailApportionCoef.Checked) Then
                SumDetailApportionCoef()
                CalVaue_Col(COL2_MasterApportionCoef)
            End If

            CalVaue_Col(e.ColIndex)
        End If

        chkShowSelected_CheckedChanged(Nothing, Nothing)
        FooterTotalGrid(tdbg2, COL2_EmployeeID)
        CalFooter2()
        tdbg2.Refresh()
    End Sub

    Private Sub tdbg2_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg2.AfterDelete
        FooterTotalGrid(tdbg2, COL2_EmployeeID)
        CalFooter2()
    End Sub

    Private Sub tdbg2_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg2.BeforeColEdit
        If tdbg2.Bookmark < tdbg2.RowCount AndAlso e.ColIndex <> COL2_Choose Then
            If L3Bool(tdbg2.Columns(COL2_Choose).Text) = False And chkIsPieceworkGroup.Checked = False Then
                e.Cancel = True
                tdbg2.Columns(COL2_EmployeeID).DropDown = Nothing
                tdbg2.Columns(COL2_RefEmployeeID).DropDown = Nothing
                tdbg2.Columns(COL2_FirstName).DropDown = Nothing
            Else
                tdbg2.Columns(COL2_EmployeeID).DropDown = tdbdEmployeeID
                tdbg2.Columns(COL2_RefEmployeeID).DropDown = tdbdRefEmployeeID
                tdbg2.Columns(COL2_FirstName).DropDown = tdbdFirstName
            End If
        End If

        Select Case e.ColIndex
            Case COL2_MasterApportionCoef
                If chkIsPieceworkGroup.Checked = False Or (chkIsPieceworkGroup.Checked And optDetailApportionCoef.Checked) Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub tdbg2_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg2.BeforeColUpdate
        Select Case e.ColIndex
            Case COL2_EmployeeID
                If tdbg2.Columns(COL2_EmployeeID).Text <> tdbdEmployeeID.Columns("EmployeeID").Text Then
                    tdbg2.Columns(COL2_EmployeeID).Text = ""
                    tdbg2.Columns(COL2_RefEmployeeID).Text = ""
                    tdbg2.Columns(COL2_FirstName).Text = ""
                    tdbg2.Columns(COL2_EmployeeName).Text = ""
                    tdbg2.Columns(COL2_DepartmentID).Text = ""
                    tdbg2.Columns(COL2_TeamID).Text = ""
                End If

            Case COL2_RefEmployeeID
                If tdbg2.Columns(COL2_RefEmployeeID).Text <> tdbdRefEmployeeID.Columns("RefEmployeeID").Text Then
                    tdbg2.Columns(COL2_EmployeeID).Text = ""
                    tdbg2.Columns(COL2_RefEmployeeID).Text = ""
                    tdbg2.Columns(COL2_FirstName).Text = ""
                    tdbg2.Columns(COL2_EmployeeName).Text = ""
                    tdbg2.Columns(COL2_DepartmentID).Text = ""
                    tdbg2.Columns(COL2_TeamID).Text = ""
                End If

            Case COL2_FirstName
                If tdbg2.Columns(COL2_FirstName).Text <> tdbdFirstName.Columns("FirstName").Text Then
                    tdbg2.Columns(COL2_EmployeeID).Text = ""
                    tdbg2.Columns(COL2_RefEmployeeID).Text = ""
                    tdbg2.Columns(COL2_FirstName).Text = ""
                    tdbg2.Columns(COL2_EmployeeName).Text = ""
                    tdbg2.Columns(COL2_DepartmentID).Text = ""
                    tdbg2.Columns(COL2_TeamID).Text = ""
                End If
        End Select

        If e.ColIndex >= COL2_Total Then
            If L3IsNumeric(tdbg2.Columns(e.ColIndex).Text, EnumDataType.Money) = False Then
                tdbg2.Columns(e.ColIndex).Text = "0.00"
            Else
                tdbg2.Columns(e.ColIndex).Text = SQLNumber(tdbg2.Columns(e.ColIndex).Text, DxxFormat.DefaultNumber2)
            End If
        End If
    End Sub

    Private Sub tdbg2_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.ComboSelect
        Select Case e.ColIndex
            Case COL2_EmployeeID
                tdbg2.Columns(COL2_RefEmployeeID).Text = tdbdEmployeeID.Columns("RefEmployeeID").Text
                tdbg2.Columns(COL2_FirstName).Text = tdbdEmployeeID.Columns("FirstName").Text
                tdbg2.Columns(COL2_EmployeeName).Text = tdbdEmployeeID.Columns("EmployeeName").Text
                tdbg2.Columns(COL2_DepartmentID).Text = tdbdEmployeeID.Columns("DepartmentID").Text
                tdbg2.Columns(COL2_TeamID).Text = tdbdEmployeeID.Columns("TeamID").Text
                FooterTotalGrid(tdbg2, COL2_EmployeeID)

            Case COL2_RefEmployeeID
                tdbg2.Columns(COL2_EmployeeID).Text = tdbdRefEmployeeID.Columns("EmployeeID").Text
                tdbg2.Columns(COL2_FirstName).Text = tdbdRefEmployeeID.Columns("FirstName").Text
                tdbg2.Columns(COL2_EmployeeName).Text = tdbdRefEmployeeID.Columns("EmployeeName").Text
                tdbg2.Columns(COL2_DepartmentID).Text = tdbdRefEmployeeID.Columns("DepartmentID").Text
                tdbg2.Columns(COL2_TeamID).Text = tdbdRefEmployeeID.Columns("TeamID").Text
                FooterTotalGrid(tdbg2, COL2_EmployeeID)

            Case COL2_FirstName
                tdbg2.Columns(COL2_RefEmployeeID).Text = tdbdFirstName.Columns("RefEmployeeID").Text
                tdbg2.Columns(COL2_EmployeeID).Text = tdbdFirstName.Columns("EmployeeID").Text
                tdbg2.Columns(COL2_EmployeeName).Text = tdbdFirstName.Columns("EmployeeName").Text
                tdbg2.Columns(COL2_DepartmentID).Text = tdbdFirstName.Columns("DepartmentID").Text
                tdbg2.Columns(COL2_TeamID).Text = tdbdFirstName.Columns("TeamID").Text
                FooterTotalGrid(tdbg2, COL2_EmployeeID)
        End Select
    End Sub

    Private Sub tdbg2_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.HeadClick
        If tdbg2.RowCount = 0 Then Exit Sub

        Select Case e.ColIndex
            Case COL2_Choose
                PressHeadClick()

            Case COL2_WorkingHours, COL2_MasterApportionCoef
                If tdbg2.Splits(0).DisplayColumns(e.ColIndex).Locked Then Exit Sub

                CopyColumns_tdbg2(tdbg2, e.ColIndex, tdbg2.Columns(e.ColIndex).Text, tdbg2.Bookmark)
                CalVaue_Col(e.ColIndex)
                Exit Sub
        End Select

        If e.ColIndex >= COL2_Total Then
            CopyColumns_tdbg2(tdbg2, e.ColIndex, tdbg2.Columns(e.ColIndex).Text, tdbg2.Bookmark)

            If chkIsPieceworkGroup.Checked = False Or (chkIsPieceworkGroup.Checked And optDetailApportionCoef.Checked) Then
                SumDetailApportionCoef()
                CalVaue_Col(COL2_MasterApportionCoef)
            End If

            CalVaue_Col(e.ColIndex)
        End If

    End Sub

    Private Sub tdbg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg2.KeyDown
        If tdbg2.RowCount = 0 Then Exit Sub

        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg2)
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg2)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            Select Case tdbg2.Col
                Case COL2_Choose
                    PressHeadClick()

                Case COL2_WorkingHours, COL2_MasterApportionCoef
                    If tdbg2.Splits(0).DisplayColumns(tdbg2.Col).Locked Then Exit Sub

                    'CopyColumns(tdbg2, tdbg2.Col, tdbg2.Columns(tdbg2.Col).Text, tdbg2.Bookmark)
                    CopyColumns_tdbg2(tdbg2, tdbg2.Col, tdbg2.Columns(tdbg2.Col).Text, tdbg2.Bookmark)
                    CalVaue_Col(tdbg2.Col)
                    Exit Sub
            End Select

            If tdbg2.Col >= COL2_Total Then
                'CopyColumns(tdbg2, tdbg2.Col, tdbg2.Columns(tdbg2.Col).Text, tdbg2.Bookmark)
                CopyColumns_tdbg2(tdbg2, tdbg2.Col, tdbg2.Columns(tdbg2.Col).Text, tdbg2.Bookmark)

                If chkIsPieceworkGroup.Checked = False Or (chkIsPieceworkGroup.Checked And optDetailApportionCoef.Checked) Then
                    SumDetailApportionCoef()
                    CalVaue_Col(COL2_MasterApportionCoef)
                End If

                CalVaue_Col(tdbg2.Col)
            End If

            tdbg2.Refresh()
        ElseIf e.KeyCode = Keys.Enter And tdbg2.Col = iColLast2 Then
            If D45Options.UseEnterMoveDown Then Exit Sub
            HotKeyEnterGrid(tdbg2, COL2_EmployeeID, e, 0)
        ElseIf e.Shift And e.KeyCode = Keys.Insert Then
            HotKeyShiftInsert(tdbg2)
        End If

        HotKeyDownGrid(e, tdbg2, COL2_Total, 0, tdbg2.Splits.Count - 1)
    End Sub

    Private Sub tdbg2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg2.KeyPress
        If tdbg2.Col = COL2_WorkingHours Or tdbg2.Col = COL2_MasterApportionCoef Or tdbg2.Col >= COL2_Total Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    Private Sub PressHeadClick()
        Dim bChoose As Boolean = Not bSelected
        For i As Integer = 0 To tdbg2.RowCount - 1
            tdbg2(i, COL2_Choose) = bChoose
        Next i
        bSelected = bChoose
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        tdbg.UpdateData()
        tdbg2.UpdateData()

        If AllowSave() = False Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        chkShowSelected.Checked = False
        'chi add cot dong khi co thay doi 
        If tdbcPieceworkGroupID.Text <> tdbcPieceworkGroupID.Tag.ToString OrElse tdbcGroupProductID.Text <> tdbcGroupProductID.Tag.ToString Then
            LoadTableField()

            'Phai xoa cac cot dong da duoc add vao truoc do
            For i As Integer = tdbg.Columns.Count - 1 To COL_Total Step -1
                tdbg.Columns.RemoveAt(i)
            Next

            For i As Integer = tdbg2.Columns.Count - 1 To COL2_Total Step -1
                tdbg2.Columns.RemoveAt(i)
            Next

            If tdbg.Splits.Count > 1 Then tdbg.RemoveHorizontalSplit(1)
            If tdbg2.Splits.Count > 1 Then tdbg2.RemoveHorizontalSplit(1)

            If dtAddField.Rows.Count > 0 Then

                'Add vao cac cot dong moi
                AddField_tdbg()

                ResetFooterGrid(tdbg, SPLIT0, tdbg.Splits.Count - 1)

                If tdbg.Splits.Count > 1 Then
                    For i As Integer = COL_Total To tdbg.Columns.Count - 1
                        tdbg.Splits(1).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        tdbg.Splits(1).DisplayColumns(i).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    Next
                End If
            End If

            If dtAddField1.Rows.Count > 0 Then

                'Add vao cac cot dong moi
                AddField_tdbg1()

                ResetFooterGrid(tdbg2, SPLIT0, tdbg2.Splits.Count - 1)

                If tdbg2.Splits.Count > 1 Then
                    For i As Integer = COL2_Total To tdbg2.Columns.Count - 1
                        tdbg2.Splits(1).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        tdbg2.Splits(1).DisplayColumns(i).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    Next
                End If
            End If
        End If


        'Load lai nguon khi co chon lai 1 combo
        If tdbcPieceworkGroupID.Text <> tdbcPieceworkGroupID.Tag.ToString OrElse tdbcGroupProductID.Text <> tdbcGroupProductID.Tag.ToString OrElse _
            tdbcBlockID.Text <> tdbcBlockID.Tag.ToString OrElse tdbcDepartmentID.Text <> tdbcDepartmentID.Tag.ToString OrElse tdbcTeamID.Text <> tdbcTeamID.Tag.ToString Then
            LoadTDBGrid()
            LoadTDBGrid2()
        End If

        '--------------------------------------
        tdbcAnaCategoryID.Tag = tdbcAnaCategoryID.Text
        tdbcAnaID.Tag = tdbcAnaID.Text
        tdbcBlockID.Tag = tdbcBlockID.Text
        tdbcDepartmentID.Tag = tdbcDepartmentID.Text
        tdbcTeamID.Tag = tdbcTeamID.Text
        tdbcPieceworkGroupID.Tag = tdbcPieceworkGroupID.Text
        tdbcGroupProductID.Tag = tdbcGroupProductID.Text
        '--------------------------------------

        iColLast = CountCol(tdbg, tdbg.Splits.Count - 1)
        iColLast2 = CountCol(tdbg2, tdbg2.Splits.Count - 1)

        '---------------------------------------------
        'Khoi tao mang luu chi so (neu co di chuyen cot)
        ReDim arrayIndex(tdbg.Columns.Count - 1)
        For i As Integer = 0 To tdbg.Columns.Count - 1
            arrayIndex(i) = i
        Next
        '---------------------------------------------

        tdbg2.SplitIndex = 0
        tdbg2.Col = COL2_EmployeeID
        tdbg2.Focus()

        Application.DoEvents()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function SQLStoreD45P2004() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2004 "
        sSQL &= SQLString(_productVoucherID) & COMMA 'ProductVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcPieceworkGroupID)) & COMMA 'PieceworkGroupID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcAnaCategoryID)) & COMMA 'AnaCategoryID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcAnaID)) & COMMA 'AnaID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcGroupProductID)) & COMMA 'GroupProductID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Function SQLStoreD45P2041(ByVal iMode As Integer, ByVal sBatchID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2041 "
        sSQL &= SQLString(sBatchID) & COMMA 'BatchID, varchar[20], NOT NULL
        sSQL &= SQLString(_productVoucherID) & COMMA 'ProductVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcPieceworkGroupID)) & COMMA 'PieceworkGroupID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcAnaCategoryID)) & COMMA 'AnaCategoryID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcAnaID)) & COMMA 'AnaID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL

        If chkIsPieceworkGroup.Checked Then
            sSQL &= SQLString(tdbcGroupProductID.Text) & COMMA 'GroupProductID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(tdbcGroupProductID.Text) & COMMA 'GroupProductID, varchar[20], NOT NULL
        End If

        sSQL &= SQLNumber(optDetailApportionCoef.Checked) & COMMA 'IsDetailCoef, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub CalVaue_Col(ByVal iCol As Integer)
        Dim j As Integer
        Dim Sum As Double = 0

        For j = 0 To tdbg2.RowCount - 1
            Sum = Sum + Number(IIf(tdbg2(j, iCol).ToString = "", 0, tdbg2(j, iCol).ToString))
        Next
        tdbg2.Columns(iCol).FooterText = Format(Sum, DxxFormat.DefaultNumber2)
    End Sub

    Private Sub chkIsPieceworkGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsPieceworkGroup.Click
        If chkIsPieceworkGroup.Checked = True Then
            ReadOnlyControl(tdbcBlockID)
            ReadOnlyControl(tdbcDepartmentID)
            ReadOnlyControl(tdbcTeamID)

            tdbcPieceworkGroupID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
            tdbg2.Height = 334
            tdbg2.Location = New Point(5, 225)
            tdbg.Visible = True
        Else
            If _departmentID <> "%" OrElse _teamID <> "%" Then
                ReadOnlyControl(tdbcBlockID)
                ReadOnlyControl(tdbcDepartmentID)
                ReadOnlyControl(tdbcTeamID)
            Else
                If D45Systems.IsUseBlock Then
                    UnReadOnlyControl(tdbcBlockID)
                Else
                    ReadOnlyControl(tdbcBlockID)
                End If
                UnReadOnlyControl(tdbcDepartmentID)
                UnReadOnlyControl(tdbcTeamID)
            End If
            tdbcPieceworkGroupID.EditorBackColor = SystemColors.Window
            tdbg2.Height = 450
            tdbg2.Location = New Point(5, 109)
            tdbg.Visible = False
        End If
        '---------------------------------------------
        optDetailApportionCoef.Enabled = chkIsPieceworkGroup.Checked
        optMasterApportionCoef.Enabled = chkIsPieceworkGroup.Checked
        chkShowSelected.Checked = False
        chkShowSelected.Visible = Not chkIsPieceworkGroup.Checked
        tdbg2.Splits(0).DisplayColumns(COL2_Choose).Visible = chkShowSelected.Visible
        ResetValue()
    End Sub

    Private Function SQLDeleteD45T2002() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2002"
        sSQL &= " Where BatchID=" & SQLString(tdbg.Columns(COL_BatchID).Text) & " And ProductVoucherID=" & SQLString(_productVoucherID) & vbCrLf
        sSQL &= "And ProductID In (Select ProductID From D45T1071 D45  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where D45.GroupProductID=" & SQLString(tdbcGroupProductID.Text) & ")"

        Return sSQL
    End Function

    Private Function SQLDeleteD45T2001() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2001"
        sSQL &= " Where BatchID=" & SQLString(tdbg.Columns(COL_BatchID).Text) & " And ProductVoucherID=" & SQLString(_productVoucherID) & vbCrLf
        sSQL &= "And (ProductID In (Select ProductID From D45T1071 D45  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where D45.GroupProductID=" & SQLString(tdbcGroupProductID.Text) & ") Or ProductID Is Null Or ProductID='')"
        Return sSQL
    End Function

    Private Function SaveData_Detail() As StringBuilder
        Dim sSQL As New StringBuilder("")
        Dim iCount As Integer = 0 'Đếm số dòng Insert
        Dim iCol As Integer
        Dim k As Integer = 0
        Dim sTransID As String = "", sBatchID As String = ""
        Dim iCountIGETransID As Integer = 0, iCountIGEBatchID As Integer = 0

        iCountIGETransID = tdbg2.RowCount
        iCountIGEBatchID = tdbg.RowCount

        Dim iOrderNo As Integer = 0

        iOrderNo = GetOrderNo(iCountIGETransID)

        'mo ket noi
        conn.Close()
        conn.Open()
        trans = conn.BeginTransaction

        sRet.Remove(0, sRet.Length)

        If chkIsPieceworkGroup.Checked = False Then

            For i As Integer = 0 To tdbg2.RowCount - 1
                k = 0
                While k < nTotalProduct1
                    iCol = COL2_Total + (k * 6) '6 cột cho 1 công đoạn

                    sSQL.Remove(0, sSQL.Length)
                    If Number(tdbg2(i, tdbg2.Columns(iCol).DataField).ToString) <> 0 OrElse Number(tdbg2(i, tdbg2.Columns(iCol + 1).DataField).ToString) <> 0 OrElse Number(tdbg2(i, tdbg2.Columns(iCol + 2).DataField).ToString) <> 0 _
                        OrElse Number(tdbg2(i, tdbg2.Columns(iCol + 3).DataField).ToString) <> 0 OrElse Number(tdbg2(i, tdbg2.Columns(iCol + 4).DataField).ToString) <> 0 OrElse Number(tdbg2(i, tdbg2.Columns(iCol + 5).DataField).ToString) <> 0 Then

                        'Sinh IGE cho TransID
                        sTransID = CreateIGEs("D45T2001", "TransID", "45", "DT", gsStringKey, sTransID, iCountIGETransID)

                        sSQL.Append("Insert Into D45T2001(")
                        sSQL.Append("DivisionID, TranMonth, TranYear, ProductVoucherID, PayrollVoucherID, ")
                        sSQL.Append("DepartmentID, TeamID, EmployeeID, ProductID, StageID, ")
                        sSQL.Append("Quantity01, Quantity02, Quantity03, Quantity04, Quantity05, DetailApportionCoef, ")
                        sSQL.Append("IsLocked, TransID, CreateUserID, CreateDate, LastModifyUserID, ")
                        sSQL.Append("LastModifyDate, OrderNo, PieceworkGroupID, BatchID, WorkingHours, MasterApportionCoef")
                        sSQL.Append(") Values(")
                        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
                        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
                        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
                        sSQL.Append(SQLString(_productVoucherID) & COMMA) 'ProductVoucherID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(_payrollVoucherID) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(tdbg2(i, COL2_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(tdbg2(i, COL2_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(tdbg2(i, COL2_EmployeeID)) & COMMA) 'EmployeeID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(dtAddField1.Rows(k).Item("ProductID").ToString) & COMMA) 'ProductID, varchar[50], NOT NULL
                        sSQL.Append(SQLString("") & COMMA) 'StageID, varchar[20], NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol).DataField).ToString) & COMMA) 'Quantity01, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol + 1).DataField).ToString) & COMMA) 'Quantity02, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol + 2).DataField).ToString) & COMMA) 'Quantity03, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol + 3).DataField).ToString) & COMMA) 'Quantity04, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol + 4).DataField).ToString) & COMMA) 'Quantity05, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol + 5).DataField).ToString) & COMMA) 'DetailApportionCoef, decimal, NOT NULL
                        sSQL.Append(SQLNumber(0) & COMMA) 'IsLocked, tinyint, NOT NULL
                        sSQL.Append(SQLString(sTransID) & COMMA) 'TransID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
                        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
                        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
                        sSQL.Append((iOrderNo + i) & COMMA) 'OrderNo, int, NOT NULL
                        sSQL.Append(SQLString(tdbg2(i, COL2_PieceworkGroupID)) & COMMA) 'PieceworkGroupID, varchar[20], NOT NULL
                        sSQL.Append(SQLString("") & COMMA) 'BatchID, varchar[20], NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, COL2_WorkingHours)) & COMMA) 'WorkingHours, varchar[20], NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, COL2_MasterApportionCoef))) 'MasterApportionCoef, varchar[20], NOT NULL
                        sSQL.Append(")")

                        sRet.Append(sSQL.ToString & vbCrLf)
                        sSQL.Remove(0, sSQL.Length)

                        iCount += 1

                        If iCount = 100 OrElse (i = tdbg2.RowCount - 1) Then
                            bRunSQL = ExecuteSQL_MoreCommand(sRet.ToString)
                            iCount = 0
                            sRet.Remove(0, sRet.Length)
                            If bRunSQL = False Then 'thuc thi k thanh cong
                                sRet.Append("-1")
                                Return sRet
                            End If

                        End If
                    End If

                    k += 1
                End While
            Next

        Else
            sRet.Remove(0, sRet.Length)
            sRet.Append(SQLDeleteD45T2002.ToString & vbCrLf)
            sRet.Append(SQLDeleteD45T2001.ToString & vbCrLf)

            'Luu D45T2002
            For i As Integer = 0 To tdbg.RowCount - 1
                k = 0
                While k < nTotalProduct
                    iCol = COL_Total + (k * 5) '6 cột cho 1 công đoạn

                    sSQL.Remove(0, sSQL.Length)
                    If Number(tdbg(i, tdbg.Columns(iCol).DataField).ToString) <> 0 OrElse Number(tdbg(i, tdbg.Columns(iCol + 1).DataField).ToString) <> 0 OrElse Number(tdbg(i, tdbg.Columns(iCol + 2).DataField).ToString) <> 0 _
                        OrElse Number(tdbg(i, tdbg.Columns(iCol + 3).DataField).ToString) <> 0 OrElse Number(tdbg(i, tdbg.Columns(iCol + 4).DataField).ToString) <> 0 Then

                        'Sinh IGE cho BatchID
                        If tdbg(i, COL_BatchID).ToString = "" Then
                            sBatchID = CreateIGEs("D45T2002", "BatchID", "45", "DB", gsStringKey, sBatchID, iCountIGEBatchID)
                            tdbg(i, COL_BatchID) = sBatchID
                        End If

                        sSQL.Append("Insert Into D45T2002(")
                        sSQL.Append("BatchID, ProductVoucherID, PieceworkGroupID, ProductID, Quantity01, ")
                        sSQL.Append("Quantity02, Quantity03, Quantity04, Quantity05")
                        sSQL.Append(") Values(")
                        sSQL.Append(SQLString(tdbg(i, COL_BatchID)) & COMMA) 'BatchID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(_productVoucherID) & COMMA) 'ProductVoucherID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(tdbg(i, COL_PieceworkGroupID)) & COMMA) 'PieceworkGroupID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(dtAddField.Rows(k).Item("ProductID").ToString) & COMMA) 'ProductID, varchar[20], NOT NULL
                        sSQL.Append(SQLMoney(tdbg(i, tdbg.Columns(iCol).DataField).ToString) & COMMA) 'Quantity01, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg(i, tdbg.Columns(iCol + 1).DataField).ToString) & COMMA) 'Quantity02, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg(i, tdbg.Columns(iCol + 2).DataField).ToString) & COMMA) 'Quantity03, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg(i, tdbg.Columns(iCol + 3).DataField).ToString) & COMMA) 'Quantity04, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg(i, tdbg.Columns(iCol + 4).DataField).ToString)) 'Quantity05, decimal, NOT NULL
                        sSQL.Append(")")

                        sRet.Append(sSQL.ToString & vbCrLf)
                        sSQL.Remove(0, sSQL.Length)

                        iCount += 1

                        If iCount = 100 Then
                            bRunSQL = ExecuteSQL_MoreCommand(sRet.ToString)
                            iCount = 0
                            sRet.Remove(0, sRet.Length)
                            If bRunSQL = False Then 'thuc thi k thanh cong
                                sRet.Append("-1")
                                Return sRet
                            End If
                        End If
                    End If
                    k += 1
                End While
            Next

            '-------------------------------------------------------------------
            'Luu D45T2001
            For i As Integer = 0 To tdbg2.RowCount - 1
                k = 0
                While k < nTotalProduct1
                    iCol = COL2_Total + (k * 6) '6 cột cho 1 công đoạn

                    sSQL.Remove(0, sSQL.Length)
                    If Number(tdbg2(i, tdbg2.Columns(iCol).DataField).ToString) <> 0 OrElse Number(tdbg2(i, tdbg2.Columns(iCol + 1).DataField).ToString) <> 0 OrElse Number(tdbg2(i, tdbg2.Columns(iCol + 2).DataField).ToString) <> 0 _
                        OrElse Number(tdbg2(i, tdbg2.Columns(iCol + 3).DataField).ToString) <> 0 OrElse Number(tdbg2(i, tdbg2.Columns(iCol + 4).DataField).ToString) <> 0 OrElse Number(tdbg2(i, tdbg2.Columns(iCol + 5).DataField).ToString) <> 0 Then

                        'Sinh IGE cho TransID
                        sTransID = CreateIGEs("D45T2001", "TransID", "45", "DT", gsStringKey, sTransID, iCountIGETransID)

                        sSQL.Append("Insert Into D45T2001(")
                        sSQL.Append("DivisionID, TranMonth, TranYear, ProductVoucherID, PayrollVoucherID, ")
                        sSQL.Append("DepartmentID, TeamID, EmployeeID, ProductID, StageID, ")
                        sSQL.Append("Quantity01, Quantity02, Quantity03, Quantity04, Quantity05, DetailApportionCoef, ")
                        sSQL.Append("IsLocked, TransID, CreateUserID, CreateDate, LastModifyUserID, ")
                        sSQL.Append("LastModifyDate, OrderNo, PieceworkGroupID, BatchID, WorkingHours, MasterApportionCoef")
                        sSQL.Append(") Values(")
                        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
                        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
                        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
                        sSQL.Append(SQLString(_productVoucherID) & COMMA) 'ProductVoucherID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(_payrollVoucherID) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(tdbg2(i, COL2_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(tdbg2(i, COL2_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(tdbg2(i, COL2_EmployeeID)) & COMMA) 'EmployeeID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(dtAddField1.Rows(k).Item("ProductID").ToString) & COMMA) 'ProductID, varchar[50], NOT NULL
                        sSQL.Append(SQLString("") & COMMA) 'StageID, varchar[20], NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol).DataField).ToString) & COMMA) 'Quantity01, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol + 1).DataField).ToString) & COMMA) 'Quantity02, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol + 2).DataField).ToString) & COMMA) 'Quantity03, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol + 3).DataField).ToString) & COMMA) 'Quantity04, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol + 4).DataField).ToString) & COMMA) 'Quantity05, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, tdbg2.Columns(iCol + 5).DataField).ToString) & COMMA) 'DetailApportionCoef, decimal, NOT NULL
                        sSQL.Append(SQLNumber(0) & COMMA) 'IsLocked, tinyint, NOT NULL
                        sSQL.Append(SQLString(sTransID) & COMMA) 'TransID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
                        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
                        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
                        sSQL.Append((iOrderNo + i) & COMMA) 'OrderNo, int, NOT NULL
                        sSQL.Append(SQLString(tdbg2(i, COL2_PieceworkGroupID)) & COMMA) 'PieceworkGroupID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(tdbg.Columns(COL_BatchID).Text) & COMMA) 'BatchID, varchar[20], NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, COL2_WorkingHours)) & COMMA) 'WorkingHours, varchar[20], NOT NULL
                        sSQL.Append(SQLMoney(tdbg2(i, COL2_MasterApportionCoef))) 'MasterApportionCoef, varchar[20], NOT NULL
                        sSQL.Append(")")

                        sRet.Append(sSQL.ToString & vbCrLf)
                        sSQL.Remove(0, sSQL.Length)

                        iCount += 1

                        If iCount = 100 OrElse (i = tdbg2.RowCount - 1) Then
                            bRunSQL = ExecuteSQL_MoreCommand(sRet.ToString)
                            iCount = 0
                            sRet.Remove(0, sRet.Length)
                            If bRunSQL = False Then 'thuc thi k thanh cong
                                sRet.Append("-1")
                                Return sRet
                            End If
                        End If
                    End If

                    k += 1
                End While
            Next
        End If

        Return sRet
    End Function

    Private Function SaveData_Master() As StringBuilder
        Dim sSQL As New StringBuilder("")
        Dim iCount As Integer = 0 'Đếm số dòng Insert
        Dim iCol As Integer
        Dim k As Integer = 0
        Dim sTransID As String = "", sBatchID As String = ""
        Dim iCountIGETransID As Integer = 0, iCountIGEBatchID As Integer = 0

        iCountIGETransID = tdbg2.RowCount
        iCountIGEBatchID = tdbg.RowCount

        Dim iOrderNo As Integer = 0

        iOrderNo = GetOrderNo(iCountIGETransID)

        'mo ket noi
        conn.Close()
        conn.Open()
        trans = conn.BeginTransaction

        sRet.Remove(0, sRet.Length)

        If chkIsPieceworkGroup.Checked = False Then

            For i As Integer = 0 To tdbg2.RowCount - 1
                sSQL.Remove(0, sSQL.Length)

                If Number(tdbg2(i, COL2_MasterApportionCoef)) <> 0 Then

                    'Sinh IGE cho TransID
                    sTransID = CreateIGEs("D45T2001", "TransID", "45", "DT", gsStringKey, sTransID, iCountIGETransID)

                    sSQL.Append("Insert Into D45T2001(")
                    sSQL.Append("DivisionID, TranMonth, TranYear, ProductVoucherID, PayrollVoucherID, ")
                    sSQL.Append("DepartmentID, TeamID, EmployeeID, ProductID, StageID, ")
                    sSQL.Append("IsLocked, TransID, CreateUserID, CreateDate, LastModifyUserID, ")
                    sSQL.Append("LastModifyDate, OrderNo, PieceworkGroupID, BatchID, WorkingHours, ")
                    sSQL.Append("DetailApportionCoef, MasterApportionCoef")
                    sSQL.Append(") Values(")
                    sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
                    sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
                    sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
                    sSQL.Append(SQLString(_productVoucherID) & COMMA) 'ProductVoucherID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(_payrollVoucherID) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg2(i, COL2_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg2(i, COL2_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg2(i, COL2_EmployeeID)) & COMMA) 'EmployeeID, varchar[20], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'ProductID, varchar[50], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'StageID, varchar[20], NOT NULL
                    sSQL.Append(SQLNumber(0) & COMMA) 'IsLocked, tinyint, NOT NULL
                    sSQL.Append(SQLString(sTransID) & COMMA) 'TransID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                    sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
                    sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
                    sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
                    sSQL.Append(SQLNumber(iOrderNo + 1) & COMMA) 'OrderNo, int, NOT NULL
                    sSQL.Append(SQLString(tdbg2(i, COL2_PieceworkGroupID)) & COMMA) 'PieceworkGroupID, varchar[20], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'BatchID, varchar[20], NOT NULL
                    sSQL.Append(SQLMoney(tdbg2(i, COL2_WorkingHours)) & COMMA) 'WorkingHours, decimal, NOT NULL
                    sSQL.Append(SQLMoney(tdbg2(i, COL2_MasterApportionCoef))) 'MasterApportionCoef, decimal, NOT NULL
                    sSQL.Append(")")

                    sRet.Append(sSQL.ToString & vbCrLf)
                    sSQL.Remove(0, sSQL.Length)
                    iCount += 1

                    If iCount = 100 OrElse (i = tdbg2.RowCount - 1) Then
                        bRunSQL = ExecuteSQL_MoreCommand(sRet.ToString)
                        iCount = 0
                        sRet.Remove(0, sRet.Length)
                        If bRunSQL = False Then 'thuc thi k thanh cong
                            sRet.Append("-1")
                            Return sRet
                        End If

                    End If
                End If
            Next

        Else
            sRet.Remove(0, sRet.Length)
            sRet.Append(SQLDeleteD45T2002.ToString & vbCrLf)
            sRet.Append(SQLDeleteD45T2001.ToString & vbCrLf)

            'Luu D45T2002
            For i As Integer = 0 To tdbg.RowCount - 1
                k = 0
                While k < nTotalProduct
                    iCol = COL_Total + (k * 5) '6 cột cho 1 công đoạn

                    sSQL.Remove(0, sSQL.Length)
                    If Number(tdbg(i, tdbg.Columns(iCol).DataField).ToString) <> 0 OrElse Number(tdbg(i, tdbg.Columns(iCol + 1).DataField).ToString) <> 0 OrElse Number(tdbg(i, tdbg.Columns(iCol + 2).DataField).ToString) <> 0 _
                        OrElse Number(tdbg(i, tdbg.Columns(iCol + 3).DataField).ToString) <> 0 OrElse Number(tdbg(i, tdbg.Columns(iCol + 4).DataField).ToString) <> 0 Then

                        'Sinh IGE cho BatchID
                        If tdbg(i, COL_BatchID).ToString = "" Then
                            sBatchID = CreateIGEs("D45T2002", "BatchID", "45", "DB", gsStringKey, sBatchID, iCountIGEBatchID)
                            tdbg(i, COL_BatchID) = sBatchID
                        End If

                        sSQL.Append("Insert Into D45T2002(")
                        sSQL.Append("BatchID, ProductVoucherID, PieceworkGroupID, ProductID, Quantity01, ")
                        sSQL.Append("Quantity02, Quantity03, Quantity04, Quantity05")
                        sSQL.Append(") Values(")
                        sSQL.Append(SQLString(tdbg(i, COL_BatchID)) & COMMA) 'BatchID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(_productVoucherID) & COMMA) 'ProductVoucherID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(tdbg(i, COL_PieceworkGroupID)) & COMMA) 'PieceworkGroupID, varchar[20], NOT NULL
                        sSQL.Append(SQLString(dtAddField.Rows(k).Item("ProductID").ToString) & COMMA) 'ProductID, varchar[20], NOT NULL
                        sSQL.Append(SQLMoney(tdbg(i, tdbg.Columns(iCol).DataField).ToString) & COMMA) 'Quantity01, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg(i, tdbg.Columns(iCol + 1).DataField).ToString) & COMMA) 'Quantity02, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg(i, tdbg.Columns(iCol + 2).DataField).ToString) & COMMA) 'Quantity03, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg(i, tdbg.Columns(iCol + 3).DataField).ToString) & COMMA) 'Quantity04, decimal, NOT NULL
                        sSQL.Append(SQLMoney(tdbg(i, tdbg.Columns(iCol + 4).DataField).ToString)) 'Quantity05, decimal, NOT NULL
                        sSQL.Append(")")

                        sRet.Append(sSQL.ToString & vbCrLf)
                        sSQL.Remove(0, sSQL.Length)

                        iCount += 1

                        If iCount = 100 Then
                            bRunSQL = ExecuteSQL_MoreCommand(sRet.ToString)
                            iCount = 0
                            sRet.Remove(0, sRet.Length)
                            If bRunSQL = False Then 'thuc thi k thanh cong
                                sRet.Append("-1")
                                Return sRet
                            End If
                        End If
                    End If
                    k += 1
                End While
            Next

            '-------------------------------------------------------------------
            'Luu D45T2001
            For i As Integer = 0 To tdbg2.RowCount - 1
                sSQL.Remove(0, sSQL.Length)
                If Number(tdbg2(i, COL2_MasterApportionCoef)) <> 0 Then

                    'Sinh IGE cho TransID
                    sTransID = CreateIGEs("D45T2001", "TransID", "45", "DT", gsStringKey, sTransID, iCountIGETransID)

                    sSQL.Append("Insert Into D45T2001(")
                    sSQL.Append("DivisionID, TranMonth, TranYear, ProductVoucherID, PayrollVoucherID, ")
                    sSQL.Append("DepartmentID, TeamID, EmployeeID, ProductID, StageID, ")
                    sSQL.Append("IsLocked, TransID, CreateUserID, CreateDate, LastModifyUserID, ")
                    sSQL.Append("LastModifyDate, OrderNo, PieceworkGroupID, BatchID, WorkingHours, MasterApportionCoef")
                    sSQL.Append(") Values(")
                    sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
                    sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
                    sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
                    sSQL.Append(SQLString(_productVoucherID) & COMMA) 'ProductVoucherID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(_payrollVoucherID) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg2(i, COL2_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg2(i, COL2_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg2(i, COL2_EmployeeID)) & COMMA) 'EmployeeID, varchar[20], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'ProductID, varchar[50], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'StageID, varchar[20], NOT NULL
                    sSQL.Append(SQLNumber(0) & COMMA) 'IsLocked, tinyint, NOT NULL
                    sSQL.Append(SQLString(sTransID) & COMMA) 'TransID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                    sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
                    sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
                    sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
                    sSQL.Append((iOrderNo + i) & COMMA) 'OrderNo, int, NOT NULL
                    sSQL.Append(SQLString(tdbg2(i, COL2_PieceworkGroupID)) & COMMA) 'PieceworkGroupID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg.Columns(COL_BatchID).Text) & COMMA) 'BatchID, varchar[20], NOT NULL
                    sSQL.Append(SQLMoney(tdbg2(i, COL2_WorkingHours)) & COMMA) 'WorkingHours, varchar[20], NOT NULL
                    sSQL.Append(SQLMoney(tdbg2(i, COL2_MasterApportionCoef))) 'MasterApportionCoef, varchar[20], NOT NULL
                    sSQL.Append(")")

                    sRet.Append(sSQL.ToString & vbCrLf)
                    sSQL.Remove(0, sSQL.Length)

                    iCount += 1

                    If iCount = 100 OrElse (i = tdbg2.RowCount - 1) Then
                        bRunSQL = ExecuteSQL_MoreCommand(sRet.ToString)
                        iCount = 0
                        sRet.Remove(0, sRet.Length)
                        If bRunSQL = False Then 'thuc thi k thanh cong
                            sRet.Append("-1")
                            Return sRet
                        End If
                    End If
                End If

            Next
        End If

        Return sRet
    End Function

    Private Function GetLastKey(Optional ByVal sStringCreateKey As String = "", Optional ByVal sTable As String = "D91T0001") As Integer
        'Kiểm tra bảng D91T0000
        'Nếu tìm thấy then lấy LastKey
        'Nếu không tìm thấy thì insert 1 dòng mới vào


        Dim sSQL As String
        sSQL = "SELECT LastKey FROM D91T0000 WHERE TableName ='" & sTable & "'" _
          & " AND KeyString = '" & sStringCreateKey & "'"
        Dim sLastKey As String
        sLastKey = ReturnScalar(sSQL)

        If sLastKey <> "" Then ' có dữ liệu
            Return CInt(sLastKey) + 1
        Else ' Không có dữ liệu
            sSQL = "INSERT INTO D91T0000 (TableName, KeyString, LastKey) VALUES ('" & sTable & "', '" & sStringCreateKey & "',0)"
            ExecuteSQLNoTransaction(sSQL)
            Return 1
        End If

    End Function

    Private Sub SaveLastKey(ByVal sTable As String, ByVal sString As String, ByVal nLastKey As Long)
        Dim strSQL As String
        strSQL = "UPDATE D91T0000 Set LastKey =" & nLastKey _
        & " WHERE TableName = '" & sTable & "' AND KeyString = '" & sString & "'"

        ExecuteSQLNoTransaction(strSQL)
    End Sub

    Private Function GetOrderNo(ByVal CountIGE As Integer) As Integer
        Dim iOrderNoFrom As Integer
        Dim iOrderNoTo As Integer
        Dim bKey As Boolean = False

        Do
            'Lấy Lastkey
            iOrderNoFrom = GetLastKey(_productVoucherID, "D45T2001")
            iOrderNoTo = iOrderNoFrom + (CountIGE - 1)
            'Lưu Lastkey
            SaveLastKey("D45T2001", _productVoucherID, iOrderNoTo)
            'Kiểm tra trùng khóa
            bKey = IsExistKeyBetween("D45T2001", "OrderNo", iOrderNoFrom.ToString, iOrderNoTo.ToString)

        Loop Until bKey = False

        Return iOrderNoFrom

    End Function

    Private Function IsExistKeyBetween(ByVal TableName As String, ByVal Field As String, ByVal TextFrom As String, ByVal TextTo As String) As Boolean
        Dim sSQL As String
        sSQL = "Select Top 1 1 From " & TableName & " Where " & Field & " Between " & SQLString(TextFrom) & " And " & SQLString(TextTo)
        sSQL &= " And ProductVoucherID=" & SQLString(_productVoucherID)
        Return ExistRecord(sSQL)
    End Function

    Private Function SQLStoreD45P2042_tdbg() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2042 "
        sSQL &= SQLString(_transTypeID) & COMMA 'TransTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcAnaCategoryID)) & COMMA 'AnaCategoryID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcAnaID)) & COMMA 'AnaID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcGroupProductID.Text) & COMMA 'GroupProductID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsPieceworkGroup, int, NOT NULL
        sSQL &= SQLNumber(2) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(optDetailApportionCoef.Checked) & COMMA 'IsDetailCoef, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Function SQLStoreD45P2042_tdbg1() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2042 "
        sSQL &= SQLString(_transTypeID) & COMMA 'TransTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcAnaCategoryID)) & COMMA 'AnaCategoryID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcAnaID)) & COMMA 'AnaID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcGroupProductID.Text) & COMMA 'GroupProductID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsPieceworkGroup.Checked) & COMMA 'IsPieceworkGroup, int, NOT NULL
        sSQL &= SQLNumber(2) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(optDetailApportionCoef.Checked) & COMMA 'IsDetailCoef, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL

        Return sSQL
    End Function

    Private Sub optDetailApportionCoef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDetailApportionCoef.Click
        ResetValue()
    End Sub

    Private Sub optMasterApportionCoef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optMasterApportionCoef.Click
        ResetValue()
    End Sub

    Private Sub ResetValue()
        '---------------------------------------------
        tdbcAnaCategoryID.Tag = "-1"
        tdbcAnaID.Tag = "-1"
        tdbcBlockID.Tag = "-1"
        tdbcDepartmentID.Tag = "-1"
        tdbcTeamID.Tag = "-1"
        tdbcPieceworkGroupID.Tag = "-1"
        tdbcGroupProductID.Tag = "-1"
        '---------------------------------------------
        'Load lai luoi 1 va luoi 2 rong
        If Not dtGrid Is Nothing Then dtGrid.Clear()
        If Not dtGrid2 Is Nothing Then dtGrid2.Clear()

        FooterTotalGrid(tdbg, COL_PieceworkGroupName)
        CalFooter()
        FooterTotalGrid(tdbg2, COL2_EmployeeID)
        CalFooter2()
    End Sub

    Private Function ExecuteSQL_MoreCommand(ByVal strSQL As String) As Boolean
        If Trim(strSQL) = "" Then Exit Function

        'Update 18/10/2010: Chỉ kiểm tra cho trường hợp nhập liệu Unicode
        'Khi Lưu xuống database nếu chiều dài dữ liệu vượt quá giới hạn cho phép thì không thông báo
        If gbUnicode Then strSQL = "SET ANSI_WARNINGS OFF " & vbCrLf & strSQL

        Dim cmd As New SqlCommand(strSQL, conn)

        If giAppMode = 0 Then

            Try
                cmd.CommandTimeout = 0
                cmd.Transaction = trans
                cmd.ExecuteNonQuery()
                'trans.Commit()
                'conn.Close()
                Return True
            Catch
                bRunSQL = False
                'trans.Rollback()
                'conn.Close()
                Clipboard.Clear()
                Clipboard.SetText(strSQL)
                MsgErr("Error when execute SQL in function ExecuteSQL(). Paste your SQL code from Clipboard")
                WriteLogFile1(strSQL)
                Return False
            End Try

        Else
            'Dùng D99D0041 mới
            Dim bCaLlWS As Boolean = False
            bCaLlWS = CallWebService.ExcuteSQLQuery(strSQL, gsCompanyID, gsUserID, True, gsWSSPara01, gsWSSPara02, gsWSSPara03, gsWSSPara04, gsWSSPara05)
            If Not bCaLlWS Then
                MsgErr(CallWebService.ResultError)
                WriteLogFile1(strSQL)
            End If
            Return bCaLlWS
        End If
    End Function

    Private Sub WriteLogFile1(ByVal Text As String)
        Dim sLog As String = ""
        Dim sFileName As String = gsApplicationPath & "\Log.log"
        If (My.Computer.FileSystem.FileExists(sFileName) = False) Then My.Computer.FileSystem.WriteAllText(sFileName, "", True)
        Dim lFileSize As Long = My.Computer.FileSystem.GetFileInfo(sFileName).Length
        If lFileSize > 10 * 1028 * 1028 Then My.Computer.FileSystem.DeleteFile(sFileName, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
        sLog &= Space(20) & Now & vbCrLf
        sLog &= Text & vbCrLf
        sLog &= "--------------------------------------------------------------------------" & vbCrLf
        My.Computer.FileSystem.WriteAllText(sFileName, sLog, True)
    End Sub

    Private Sub chkShowSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowSelected.CheckedChanged
        If Not dtGrid2 Is Nothing Then
            If chkShowSelected.Checked Then
                dtGrid2.DefaultView.RowFilter = "IsChosen=1"
            Else
                dtGrid2.DefaultView.RowFilter = ""
            End If
        End If
        FooterTotalGrid(tdbg2, COL2_EmployeeID)
        CalFooter2()
    End Sub

    Private Sub tdbg2_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg2.RowColChange
        If tdbg2.Row = tdbg2.RowCount OrElse L3Bool(tdbg2(tdbg2.Row, COL2_Choose)) Then
            tdbg2.Columns(COL2_EmployeeID).DropDown = tdbdEmployeeID
            tdbg2.Columns(COL2_RefEmployeeID).DropDown = tdbdRefEmployeeID
            tdbg2.Columns(COL2_FirstName).DropDown = tdbdFirstName
        Else
            tdbg2.Columns(COL2_EmployeeID).DropDown = Nothing
            tdbg2.Columns(COL2_RefEmployeeID).DropDown = Nothing
            tdbg2.Columns(COL2_FirstName).DropDown = Nothing
        End If
    End Sub

    Private Sub CopyColumns_tdbg2(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            'If sValue = "" Or c1Grid.RowCount < 2 Then Exit Sub
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 Then Exit Sub

            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid.Splits(SPLIT0).DisplayColumns(COL2_Choose).Visible = True Then
                        If L3Bool(c1Grid(i, COL2_Choose)) Then
                            If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then c1Grid(i, ColCopy) = sValue
                        End If
                    Else
                        If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then c1Grid(i, ColCopy) = sValue
                    End If
                Next
                'c1Grid(RowCopy, ColCopy) = sValue

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid.Splits(SPLIT0).DisplayColumns(COL2_Choose).Visible = True Then
                        If L3Bool(c1Grid(i, COL2_Choose)) Then
                            c1Grid(i, ColCopy) = sValue
                        End If
                    Else
                        c1Grid(i, ColCopy) = sValue
                    End If
                Next
                'c1Grid(0, ColCopy) = sValue
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

End Class