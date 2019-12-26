'#-------------------------------------------------------------------------------------
'# Created Date: 12/05/2010 08:06:51 AM
'# Created User: Đặng Vũ Minh Quang
'# Modify Date: 12/05/2010 08:06:51 AM
'# Modify User: Đặng Vũ Minh Quang
'#-------------------------------------------------------------------------------------
Public Class D45F3000
	Dim dtCaptionCols As DataTable
	Private _formIDPermission As String = "D45F3000"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property

    Dim dtGrid As DataTable

    'Khai báo biến đổ nguồn combo theo D09 - G4
    Private dtDepartmentID, dtTeamID, dtPeriod, dtStageID As DataTable
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""

#Region "Const of tdbg"
    Private Const COL_PSalaryVoucherNo As Integer = 0   ' Số phiếu
    Private Const COL_BlockID As Integer = 1            ' Khối
    Private Const COL_BlockName As Integer = 2          ' Tên khối
    Private Const COL_DepartmentID As Integer = 3       ' Phòng ban
    Private Const COL_DepartmentName As Integer = 4     ' Tên phòng ban
    Private Const COL_TeamID As Integer = 5             ' Tổ nhóm
    Private Const COL_TeamName As Integer = 6           ' Tên tổ nhóm
    Private Const COL_PieceworkGroupID As Integer = 7   ' Mã nhóm NV chấm công
    Private Const COL_PieceworkGroupName As Integer = 8 ' Tên nhóm NV chấm công
    Private Const COL_EmployeeID As Integer = 9         ' Mã nhân viên
    Private Const COL_EmployeeName As Integer = 10      ' Họ và tên
    Private Const COL_ProductID As Integer = 11         ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 12       ' Tên sản phẩm
    Private Const COL_StageID As Integer = 13           ' Mã công đoạn
    Private Const COL_StageName As Integer = 14         ' Tên công đoạn
    Private Const COL_Quantity01 As Integer = 15        ' Quantity01
    Private Const COL_Quantity02 As Integer = 16        ' Quantity02
    Private Const COL_Quantity03 As Integer = 17        ' Quantity03
    Private Const COL_Quantity04 As Integer = 18        ' Quantity04
    Private Const COL_Quantity05 As Integer = 19        ' Quantity05
    Private Const COL_Quantity06 As Integer = 20        ' Quantity06
    Private Const COL_Quantity07 As Integer = 21        ' Quantity07
    Private Const COL_Quantity08 As Integer = 22        ' Quantity08
    Private Const COL_Quantity09 As Integer = 23        ' Quantity09
    Private Const COL_Quantity10 As Integer = 24        ' Quantity10
    Private Const COL_Quantity11 As Integer = 25        ' Quantity11
    Private Const COL_Quantity12 As Integer = 26        ' Quantity12
    Private Const COL_Quantity13 As Integer = 27        ' Quantity13
    Private Const COL_Quantity14 As Integer = 28        ' Quantity14
    Private Const COL_Quantity15 As Integer = 29        ' Quantity15
    Private Const COL_Quantity16 As Integer = 30        ' Quantity16
    Private Const COL_Quantity17 As Integer = 31        ' Quantity17
    Private Const COL_Quantity18 As Integer = 32        ' Quantity18
    Private Const COL_Quantity19 As Integer = 33        ' Quantity19
    Private Const COL_Quantity20 As Integer = 34        ' Quantity20
    Private Const COL_UnitPrice01 As Integer = 35       ' UnitPrice01
    Private Const COL_UnitPrice02 As Integer = 36       ' UnitPrice02
    Private Const COL_UnitPrice03 As Integer = 37       ' UnitPrice03
    Private Const COL_UnitPrice04 As Integer = 38       ' UnitPrice04
    Private Const COL_UnitPrice05 As Integer = 39       ' UnitPrice05
    Private Const COL_Coefficient01 As Integer = 40     ' Coefficient01
    Private Const COL_Coefficient02 As Integer = 41     ' Coefficient02
    Private Const COL_Coefficient03 As Integer = 42     ' Coefficient03
    Private Const COL_Coefficient04 As Integer = 43     ' Coefficient04
    Private Const COL_Coefficient05 As Integer = 44     ' Coefficient05

    Private Const COL_Total As Integer = 45
#End Region


#Region "UserControl"
    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnF12)
        AnchorForControl(EnumAnchorStyles.TopLeftRight, Panel1, tdbcPieceworkGroupID)
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
    End Sub

    Private Sub D09F2170_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
                Exit Sub
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
                Exit Sub
        End Select

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnF12_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk(rl3("Thong_tin_tren_luoi_da_thay_doi_ban_co_muon_Refresh_lai_khong")) = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
        '***************************************
    End Sub

    Private Sub D09F2170_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        Loadlanguage()
        SetBackColorObligatory()
        ResetColorGrid(tdbg)
        ResetSplitDividerSize(tdbg)
        LoadTDBCombo()
        LoadDefault()
        AddField()
        tdbg_NumberFormat()
        '******************************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtEmployeeID)
        '******************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        CallD09U1111_Button(True)
        '******************************
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPSalaryVoucherID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcProductID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcStageID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPieceworkGroupID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadDefault()
        tdbcPeriodFrom.Text = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcPeriodTo.Text = giTranMonth.ToString("00") & "/" & giTranYear
        'Load tdbcPSalaryVoucherID
        LoadTDBCPSalaryID()
        '******************************
        tdbcBlockID.Enabled = D45Systems.IsUseBlock
        tdbcBlockID.SelectedValue = "%"
        tdbcProductID.SelectedValue = "%"
        tdbcPieceworkGroupID.SelectedValue = "%"
        '******************************
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ket_qua_tinh_luong_-_D45F3000") & UnicodeCaption(gbUnicode) 'KÕt qu¶ tÛnh l§¥ng - D45F3000
        '================================================================ 
        lblEmployeeID.Text = rl3("Ma_nhan_vien") 'Mã nhân viên
        lblEmployeeName.Text = rl3("Ten_NV") 'Tên NV
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblPeriod.Text = rl3("Ky") 'Kỳ
        lblPieceworkGroupID.Text = rl3("Nhom_NV_cham_cong") 'Nhóm NV chấm công
        lblPSalaryVoucherID.Text = rl3("Phieu_luong") 'Phiếu lương
        lblProductID.Text = rl3("San_pham") 'Sản phẩm
        lblStageID.Text = rl3("Cong_doan") 'Công đoạn
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" '&Lọc
        btnF12.Text = "F12 (" & rl3("Hien_thi") & ")"
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcPeriodTo.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPieceworkGroupID.Columns("PieceworkGroupID").Caption = rl3("Ma") 'Mã
        tdbcPieceworkGroupID.Columns("PieceworkGroupName").Caption = rl3("Ten") 'Tên
        tdbcPSalaryVoucherID.Columns("PSalaryVoucherNo").Caption = rl3("Ma") 'Mã
        tdbcPSalaryVoucherID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcProductID.Columns("ProductID").Caption = rl3("Ma") 'Mã
        tdbcProductID.Columns("ProductName").Caption = rl3("Ten") 'Tên
        tdbcStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbcStageID.Columns("StageName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("PSalaryVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("BlockID").Caption = rl3("Khoi") 'Khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("PieceworkGroupID").Caption = rl3("Ma_nhom_NV_cham_cong") 'Mã nhóm NV chấm công
        tdbg.Columns("PieceworkGroupName").Caption = rl3("Ten_nhom_NV_cham_cong") 'Tên nhóm NV chấm công
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns("StageID").Caption = rl3("Ma_cong_doan") 'Mã công đoạn
        tdbg.Columns("StageName").Caption = rl3("Ten_cong_doan") 'Tên công đoạn     
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_Quantity01).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity03).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity04).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity05).NumberFormat = DxxFormat.DefaultNumber2

        tdbg.Columns(COL_Quantity06).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity07).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity08).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity09).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity10).NumberFormat = DxxFormat.DefaultNumber2

        tdbg.Columns(COL_Quantity11).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity12).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity13).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity14).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity15).NumberFormat = DxxFormat.DefaultNumber2

        tdbg.Columns(COL_Quantity16).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity17).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity18).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity19).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity20).NumberFormat = DxxFormat.DefaultNumber2

        tdbg.Columns(COL_UnitPrice01).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice03).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice04).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice05).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Coefficient01).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Coefficient02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Coefficient03).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Coefficient04).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Coefficient05).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

#Region "Load tdbCombo"

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        dtPeriod = ReturnTablePeriod("D09")
        LoadDataSource(tdbcPeriodFrom, dtPeriod.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcPeriodTo, dtPeriod.DefaultView.ToTable, gbUnicode)

        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)

        'Load tdbcBlockID
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)

        'Load tdbcStageID
        sSQL = "SELECT '%' As StageID, " & AllName & " As StageName, '' As ProductID, 0 as DisplayOrder" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT '*' As StageID, N'" & IIf(geLanguage = EnumLanguage.English, "Total", IIf(gbUnicode = False, "Toång coäng", "Tổng cộng")).ToString & "' As StageName, '' As ProductID, 1  as DisplayOrder" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT DISTINCT T1.StageID, StageName" & UnicodeJoin(gbUnicode) & " As StageName, T1.ProductID, 2  as DisplayOrder" & vbCrLf
        sSQL &= "FROM D45T1081 T1  WITH(NOLOCK) INNER JOIN D45T1010 T2  WITH(NOLOCK) ON T1.StageID = T2.StageID" & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, StageID"
        dtStageID = ReturnDataTable(sSQL)

        'Load tdbcProductID
        sSQL = "SELECT '%' AS ProductID, " & AllName & " As ProductName, 0 as DisplayOrder" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT ProductID, ProductName" & UnicodeJoin(gbUnicode) & " As ProductName, 1 as DisplayOrder" & vbCrLf
        sSQL &= "FROM D45T1000  WITH(NOLOCK) WHERE Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, ProductID"
        LoadDataSource(tdbcProductID, sSQL, gbUnicode)

        'Load tdbcPieceworkGroupID
        sSQL = "SELECT '%' AS PieceworkGroupID, " & AllName & " As PieceworkGroupName, 0 AS DisplayOrder" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT PieceworkGroupID, PieceworkGroupName" & UnicodeJoin(gbUnicode) & " As PieceworkGroupName, 1 AS DisplayOrder" & vbCrLf
        sSQL &= "FROM D45T1050  WITH(NOLOCK) WHERE Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, PieceworkGroupID"
        LoadDataSource(tdbcPieceworkGroupID, sSQL, gbUnicode)
    End Sub
#End Region

    Private Sub LoadTDBCStage(ByVal sProductID As String)
        If sProductID = "%" Then
            LoadDataSource(tdbcStageID, dtStageID.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbcStageID, ReturnTableFilter(dtStageID, "ProductID = " & SQLString(sProductID) & " Or StageID='%' Or StageID='*'", True), gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBCPSalaryID()
        Dim sSQL As String

        Dim iTranMonthForm, iTranYearFrom, iTranMonthTo, iTranYearTo As Integer
        If tdbcPeriodFrom.Text = "" Then
            iTranMonthForm = 0
            iTranYearFrom = 0
        Else
            iTranMonthForm = L3Int(tdbcPeriodFrom.Columns("TranMonth").Text)
            iTranYearFrom = L3Int(tdbcPeriodFrom.Columns("TranYear").Text)
        End If

        If tdbcPeriodTo.Text = "" Then
            iTranMonthTo = 0
            iTranYearTo = 0
        Else
            iTranMonthTo = L3Int(tdbcPeriodTo.Columns("TranMonth").Text)
            iTranYearTo = L3Int(tdbcPeriodTo.Columns("TranYear").Text)
        End If

        sSQL = "SELECT '%' AS PSalaryVoucherID, '%' AS PSalaryVoucherNo, " & AllName & " As Description, 0 AS TranMonth, 0 AS TranYear, 0 as DisplayOrder" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT PSalaryVoucherID, PSalaryVoucherNo, Description" & UnicodeJoin(gbUnicode) & " As Description, TranMonth, TranYear, 1 AS DisplayOrder" & vbCrLf
        sSQL &= "FROM D45T2010 WITH (NOLOCK)" & vbCrLf
        sSQL &= "WHERE DivisionID= " & SQLString(gsDivisionID)
        sSQL &= " AND TranMonth + TranYear*100  BETWEEN " & iTranMonthForm + iTranYearFrom * 100 & " And " & iTranMonthTo + iTranYearTo * 100 & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, PSalaryVoucherID, PSalaryVoucherNo"
        LoadDataSource(tdbcPSalaryVoucherID, sSQL, gbUnicode)
        tdbcPSalaryVoucherID.AutoSelect = True
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =’’
            sFind = ""
            sFindServer = ""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
        End If

        sSQL = SQLStoreD45P3000()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("EmployeeID =" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
    End Sub

    Private Sub ResetGrid()
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_EmployeeName)
    End Sub

#Region "Events tdbCombo - G4 Standard"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 OrElse tdbcBlockID.Text = "" Then
            tdbcBlockID.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", gbUnicode)
        Else
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, gbUnicode)
        End If
        tdbcDepartmentID.SelectedValue = "%"
    End Sub


    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 OrElse tdbcDepartmentID.Text = "" Then
            tdbcDepartmentID.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedValue = "%"
    End Sub

    Private Sub tdbcTeamID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 OrElse tdbcTeamID.Text = "" Then
            tdbcTeamID.SelectedValue = ""
        End If
    End Sub
#End Region

#Region "Events tdbcPeriodFrom load tdbcPSalaryVoucherID"

    Private Sub tdbcPeriodFrom_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.GotFocus
        'Dùng phím Enter
        tdbcPeriodFrom.Tag = tdbcPeriodFrom.Text
    End Sub

    Private Sub tdbcPeriodFrom_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbcPeriodFrom.MouseDown
        'Di chuyển chuột
        tdbcPeriodFrom.Tag = tdbcPeriodFrom.Text
    End Sub

    Private Sub tdbcPeriodFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.SelectedValueChanged
        tdbcPSalaryVoucherID.Text = ""
    End Sub

    Private Sub tdbcPeriodFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.LostFocus
        If tdbcPeriodFrom.Tag.ToString = "" And tdbcPeriodFrom.Text = "" Then Exit Sub
        If tdbcPeriodFrom.Tag.ToString = tdbcPeriodFrom.Text And tdbcPeriodFrom.SelectedValue IsNot Nothing Then Exit Sub
        If tdbcPeriodFrom.FindStringExact(tdbcPeriodFrom.Text) = -1 Then
            tdbcPeriodFrom.Text = ""
        End If
        LoadTDBCPSalaryID()
    End Sub
#End Region

#Region "Events tdbcPeriodTo load tdbcPSalaryVoucherID"

    Private Sub tdbcPeriodTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.GotFocus
        'Dùng phím Enter
        tdbcPeriodTo.Tag = tdbcPeriodTo.Text
    End Sub

    Private Sub tdbcPeriodTo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbcPeriodTo.MouseDown
        'Di chuyển chuột
        tdbcPeriodTo.Tag = tdbcPeriodTo.Text
    End Sub

    Private Sub tdbcPeriodTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.SelectedValueChanged
        tdbcPSalaryVoucherID.Text = ""
    End Sub

    Private Sub tdbcPeriodTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.LostFocus
        If tdbcPeriodTo.Tag.ToString = "" And tdbcPeriodTo.Text = "" Then Exit Sub
        If tdbcPeriodTo.Tag.ToString = tdbcPeriodTo.Text And tdbcPeriodTo.SelectedValue IsNot Nothing Then Exit Sub
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then
            tdbcPeriodTo.Text = ""
        End If
        LoadTDBCPSalaryID()
    End Sub

    Private Sub tdbcPSalaryVoucherID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPSalaryVoucherID.LostFocus
        If tdbcPSalaryVoucherID.FindStringExact(tdbcPSalaryVoucherID.Text) = -1 Then tdbcPSalaryVoucherID.Text = ""
    End Sub

#End Region

#Region "Events tdbcProductID "

    Private Sub tdbcProductID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.SelectedValueChanged
        LoadTDBCStage(CbVal(tdbcProductID))
        tdbcStageID.SelectedValue = "%"
    End Sub

    Private Sub tdbcProductID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.LostFocus
        If tdbcProductID.FindStringExact(tdbcProductID.Text) = -1 Then
            tdbcProductID.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcStageID"

    Private Sub tdbcStageID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStageID.LostFocus
        If tdbcStageID.FindStringExact(tdbcStageID.Text) = -1 Then tdbcStageID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPieceworkGroupID"

    Private Sub tdbcPieceworkGroupID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPieceworkGroupID.LostFocus
        If tdbcPieceworkGroupID.FindStringExact(tdbcPieceworkGroupID.Text) = -1 Then tdbcPieceworkGroupID.Text = ""
    End Sub

#End Region

    Private Sub tsbExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
        Dim frm As New D99F2222
        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtGrid, gsGroupColumns)
        'ResetTableForExcel(tdbg, gdtCaptionExcel)
        'With frm
        '    .UseUnicode = gbUnicode
        '    .FormID = Me.Name
        '    .dtLoadGrid = gdtCaptionExcel
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtGrid
        '    .ShowDialog()
        '    .Dispose()
        'End With

    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
    'Bỏ sự kiện Finder_FindClick.
    'Sửa tham số Me.Name -> Me
    'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
    'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
    'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property
    Private sFindServer As String = ""
    'Dim dtCaptionCols As DataTable
    Public WriteOnly Property strNewServer() As String
        Set(ByVal Value As String)
            sFindServer = Value
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, gdtCaptionExcel)
        ShowFindDialogClientServer(Finder, ResetTableByGrid(usrOption, gdtCaptionExcel.DefaultView.ToTable), Me, "0", gbUnicode)
        '*****************************************
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClauseClient As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '    If ResultWhereClauseClient Is Nothing Or ResultWhereClauseClient.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClauseClient.ToString()
    '    sFindServer = ResultWhereClauseServer.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        sFindServer = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, tdbg.Top + tdbg.Height - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        'Những cột bắt buộc nhập
        If bLoadFirst = True Then
            Dim arrColObligatory() As Integer = {COL_EmployeeName, COL_EmployeeID}
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable

        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

#End Region

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Function AllowFilter() As Boolean
        If CheckValidPeriodFromTo(tdbcPeriodFrom, tdbcPeriodTo) = False Then
            Return False
        End If

        If tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Khoi"))
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

        If tdbcPSalaryVoucherID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Phieu_luong"))
            tdbcPSalaryVoucherID.Focus()
            Return False
        End If
        If tdbcProductID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("San_pham"))
            tdbcProductID.Focus()
            Return False
        End If
        If tdbcStageID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Cong_doan"))
            tdbcStageID.Focus()
            Return False
        End If
        If tdbcPieceworkGroupID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Nhom_NV_cham_cong"))
            tdbcPieceworkGroupID.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If AllowFilter() = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        AddField()  ' IncidentID	52116 Hiển thị ToolTip của công thưc hoặc diễn giải cho màn hình kết quả tính lương tại D45 giống D13
        sFind = ""
        sFindServer = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

    'Add 90 cot luong
    Private Sub AddField()
        Dim sSQL As String
        'Tim xem co su dung khoan thu nhap nao khong?
        ' IncidentID	52116 Hiển thị ToolTip của công thưc hoặc diễn giải cho màn hình kết quả tính lương tại D45 giống D13
        sSQL = SQLStoreD45P3001()

        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim dr() As DataRow = dt.Select("Disabled =0")
        If dr.Length > 0 Then 'Có sử dụng khỏan thu nhập
            Try
                Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
                CreateSplit()

                'cac cot phuong phap tinh luong     
                For i As Integer = 0 To dt.Rows.Count - 1
                    If IndexOfColumn(tdbg, "Amount" & Format(i + 1, "00")) > -1 Then
                        tdbg.Columns.RemoveAt(IndexOfColumn(tdbg, "Amount" & Format(i + 1, "00")))
                    End If

                    dc = New C1.Win.C1TrueDBGrid.C1DataColumn
                    dc.DataField = "Amount" & Format(i + 1, "00")
                    dc.NumberFormat = DxxFormat.DefaultNumber2
                    tdbg.Columns.Add(dc)
                    tdbg.Splits(1).DisplayColumns(dc).Width = 110
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    tdbg.Splits(1).DisplayColumns(dc).HeadingStyle.Font = FontUnicode(gbUnicode)
                    '****************************
                    tdbg.Columns(dc.DataField).Caption = dt.Rows(i).Item("AmountName").ToString
                    'If D45Options.Fomula Then
                    If D45Options.Fomula Then
                        tdbg.Columns(dc.DataField).Tag = dt.Rows(i).Item("Formula").ToString
                    Else
                        tdbg.Columns(dc.DataField).Tag = dt.Rows(i).Item("FormulaDesc").ToString
                    End If
                    tdbg.Splits(1).DisplayColumns(dc.DataField).Visible = L3Bool(IIf(dt.Rows(i).Item("Disabled").ToString = "0", True, False))
                Next
            Catch ex As Exception
                D99C0008.MsgL3(ex.Message)
            End Try
        End If

        FormatGrid()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P3001
    '# Created User: Phan Văn Thông
    '# Created Date: 15/11/2012 05:08:08
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P3001() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load ten caption cac cot  va ten cong thuc tuong uung cua tung cot" & vbCrLf)
        sSQL &= "Exec D45P3001 "
        sSQL &= SQLString(tdbcPSalaryVoucherID.SelectedValue.ToString) & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

#Region "Events tdbg"

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Quantity01 To tdbg.Columns.Count - 1
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
    End Sub

    ' IncidentID	52116 Hiển thị ToolTip của công thưc hoặc diễn giải cho màn hình kết quả tính lương tại D45 giống D13
    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        If tdbcPSalaryVoucherID.Text <> "%" Then
            If tdbg.SplitIndex = 1 Then
                e.CellTip = tdbg.Columns(e.ColIndex).Tag.ToString
            Else
                e.CellTip = ""
            End If
        Else
            e.CellTip = ""
        End If
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcPSalaryVoucherID.Close, tdbcProductID.Close, tdbcStageID.Close, tdbcPieceworkGroupID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcPSalaryVoucherID.Validated, tdbcProductID.Validated, tdbcStageID.Validated, tdbcPieceworkGroupID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub FormatGrid()
        ResetSplitDividerSize(tdbg)
        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        '*****************************
        If tdbg.Splits.Count >= 2 Then
            For i As Integer = COL_Total To tdbg.Columns.Count - 1
                tdbg.Splits(0).DisplayColumns(i).Visible = False
            Next

            For i As Integer = 0 To COL_Total - 1
                tdbg.Splits(0).DisplayColumns(i).Visible = True
                tdbg.Splits(1).DisplayColumns(i).Visible = False
            Next
        End If

        tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = D45Systems.IsUseBlock
        tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = D45Systems.IsUseBlock
        Column_CaptionAndVisible()
    End Sub

    Private Sub CreateSplit()
        If tdbg.Splits.Count > 1 Then tdbg.RemoveHorizontalSplit(1)
        tdbg.InsertHorizontalSplit(1)
        tdbg.Splits(0).SplitSize = 5
        tdbg.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable

        tdbg.Splits(1).SplitSize = 10
        tdbg.Splits(1).RecordSelectors = False
        tdbg.Splits(1).BorderStyle = Border3DStyle.Flat

        tdbg.Splits(1).RecordSelectors = False
    End Sub

   

    Private Sub Column_CaptionAndVisible()
        Dim sSQL As String = ""
        Dim dt As DataTable
        Dim i As Integer = 0
        'Cac cot so luong
        sSQL = "SELECT Code, Disabled, ShortName" & UnicodeJoin(gbUnicode) & " + ' (' + Code + ')' As Short " & vbCrLf
        sSQL &= "FROM D45T0010  WITH(NOLOCK) WHERE Type='QTY' ORDER BY Code"
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                tdbg.Columns(COL_Quantity01 + i).Caption = dt.Rows(i).Item("Short").ToString
                tdbg.Splits(0).DisplayColumns(COL_Quantity01 + i).Visible = L3Bool(IIf(dt.Rows(i).Item("Disabled").ToString = "0", True, False))
                tdbg.Splits(0).DisplayColumns(COL_Quantity01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
            Next
        End If
        '------------------------------------------------------------------------------
        'Cac cot Don gia
        sSQL = "SELECT  Code, Disabled, ShortName" & UnicodeJoin(gbUnicode) & " + ' (' + Code + ')'  as Short " & vbCrLf
        sSQL &= "FROM D45T0010  WITH(NOLOCK) WHERE Type='PRICE' ORDER BY 	Code"
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                tdbg.Columns(COL_UnitPrice01 + i).Caption = dt.Rows(i).Item("Short").ToString
                tdbg.Splits(0).DisplayColumns(COL_UnitPrice01 + i).Visible = L3Bool(IIf(dt.Rows(i).Item("Disabled").ToString = "0", True, False))
                tdbg.Splits(0).DisplayColumns(COL_UnitPrice01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
            Next
        End If
        '------------------------------------------------------------------------------
        'Cac cot he so
        sSQL = "SELECT Code, Disabled, Short" & UnicodeJoin(gbUnicode) & " + ' (' + Code + ')' Short " & vbCrLf
        sSQL &= "FROM D13T9000  WITH(NOLOCK) WHERE Type='D45T1010' ORDER BY Code"
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                tdbg.Columns(COL_Coefficient01 + i).Caption = dt.Rows(i).Item("Short").ToString
                tdbg.Splits(0).DisplayColumns(COL_Coefficient01 + i).Visible = L3Bool(IIf(dt.Rows(i).Item("Disabled").ToString = "0", True, False))
                tdbg.Splits(0).DisplayColumns(COL_Coefficient01 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
            Next
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P3000
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 08/02/2006 02:39:22
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P3000() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P3000 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLString(txtEmployeeID.Text) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtEmployeeName.Text) & COMMA 'FullName, nvarchar, NOT NULL
        sSQL &= SQLString(CbVal(tdbcPSalaryVoucherID)) & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcProductID)) & COMMA 'ProductID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcStageID)) & COMMA 'StageID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcPieceworkGroupID)) & COMMA 'PieceworkGroupID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[10], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Languge, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    
    
End Class