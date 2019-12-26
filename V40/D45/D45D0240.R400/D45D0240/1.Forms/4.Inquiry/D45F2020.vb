Imports System
Public Class D45F2020
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Dim dtCaptionCols As DataTable
	Private _formIDPermission As String = "D45F2020"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property

    Dim dtGrid, dtDetail As DataTable
    Dim dtDepartmentID, dtTeamID As DataTable
    Dim iHeight As Integer = -1
    Dim sFilter, sFilterDetail As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False, bRefreshFilter_Detail As Boolean = False 'Cờ bật set FilterText =""
    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private _createVoucherNo_D45F2020 As Boolean
    Public WriteOnly Property CreateVoucherNo_D45F2020() As Boolean
        Set(ByVal Value As Boolean)
            _createVoucherNo_D45F2020 = Value
        End Set
    End Property


#Region "Const of tdbg"
    Private Const COL_VoucherID As Integer = 0       ' VoucherID
    Private Const COL_Choose As Integer = 1          ' Chọn
    Private Const COL_VoucherDate As Integer = 2     ' Ngày phiếu
    Private Const COL_VoucherNo As Integer = 3       ' Số phiếu
    Private Const COL_EmployeeName As Integer = 4    ' Người lập
    Private Const COL_VoucherDesc As Integer = 5     ' Diễn giải
    Private Const COL_ProductCount As Integer = 6    ' Tổng sản phẩm
    Private Const COL_Quantity03 As Integer = 7      ' Số lượng kế hoạch
    Private Const COL_ProductQuantity As Integer = 8 ' ProductQuantity
    Private Const COL_Quantity02 As Integer = 9      ' Quantity02
    Private Const COL_ShiftID As Integer = 10        ' Ca
    Private Const COL_BuildTimes As Integer = 11     ' Số lần xử lý
    Private Const COL_IsInherit As Integer = 12      ' Kế thừa
    Private Const COL_TransType As Integer = 13      ' Loại nghiệp vụ
#End Region

#Region "Const of tdbg2"
    Private Const COL2_VoucherDate As Integer = 0      ' Ngày phiếu
    Private Const COL2_ProductVoucherNo As Integer = 1 ' Số phiếu
    Private Const COL2_EmployeeName As Integer = 2     ' Người lập
    Private Const COL2_Note As Integer = 3             ' Diễn giải
    Private Const COL2_DepartmentName As Integer = 4   ' Phòng ban
    Private Const COL2_TeamName As Integer = 5         ' Tổ nhóm
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRight, grp1, txtVoucherNo)
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter, chkShowCCSP)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnCreateVoucherNo)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnClose)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
    End Sub

    Private Sub D45F2020_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where Key01ID='D45F2020' And UserID=" & SQLString(gsUserID) & " And HostID=" & SQLString(My.Computer.Name)

        ExecuteSQLNoTransaction(sSQL)
    End Sub

    Private Sub D45F2020_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub D45F2020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        gbEnabledUseFind = False
        '.bSaved = False
        Loadlanguage()
        SetBackColorObligatory()
        ResetSplitDividerSize(tdbg)
        ResetFooterGrid(tdbg)
        ResetColorGrid(tdbg, 0, 2)
        ResetColorGrid(tdbg2)
        tdbg_NumberFormat()
        LoadTDBCombo()
        LoadDefault()
        LoadCaptionQuantity()
        '***************************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtVoucherNo)
        '***************************
        SetShortcutPopupMenu(C1CommandHolder)
        InputDateCustomFormat(c1dateDateFrom, c1dateDateTo)
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate, COL2_VoucherDate)

        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Phieu_TKSPTL_chua_xu_lyF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'PhiÕu TKSPTL ch§a xõ lü
        'Me.Text = rl3("Phieu_CCSP_chua_xu_ly_-_D45F2020") & UnicodeCaption(gbUnicode) 'PhiÕu CCSP ch§a xõ lü - D45F2020
        '================================================================ 
        lblteDateFrom.Text = rl3("Ngay") 'Ngày
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        '================================================================ 
        btnFilter.Text = rl3("Loc") & Space(1) & "(F5)" 'Lọc
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnCreateVoucherNo.Text = rl3("_Tao_phieu_cham_cong") '&Tạo phiếu chấm công
        btnInherit.Text = rl3("_Ke_thua_du_lieu") '&Kế thừa dữ liệu
        '================================================================ 
        'chkShowCCSP.Text = rL3("Hien_thi_cac_phieu_CCSP") 'Hiển thị các phiếu CCSP
        chkShowCCSP.Text = rL3("Hien_thi_cac_phieu_TKSPTL") 'Hiển thị các phiếu TKSPTL
        '================================================================ 
        tdbg.Columns("Choose").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("VoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("EmployeeName").Caption = rl3("Nguoi_lap") 'Người lập
        tdbg.Columns("VoucherDesc").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("ProductCount").Caption = rL3("Tong_san_pham") 'Tổng sản phẩm
        tdbg.Columns("Quantity03").Caption = rL3("So_luong_ke_hoach") 'Số lượng kế hoạch
        tdbg.Columns("ProductQuantity").Caption = rl3("Tong_so_luong_") 'Tổng số lượng
        tdbg.Columns("ShiftID").Caption = rl3("Ca") 'Ca
        tdbg.Columns("BuildTimes").Caption = rl3("So_lan_xu_ly") 'Số lần xử lý
        tdbg.Columns("IsInherit").Caption = rl3("Ke_thua") 'Kế thừa
        tdbg.Columns("TransType").Caption = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        '================================================================ 
        tdbg2.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg2.Columns("ProductVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg2.Columns("EmployeeName").Caption = rl3("Nguoi_lap") 'Người lập
        tdbg2.Columns("Note").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg2.Columns("DepartmentName").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg2.Columns("TeamName").Caption = rl3("To_nhom") 'Tổ nhóm
        '================================================================ 
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rL3("_Liet_ke_tat_ca") '&Liệt kê tất cả

        '================================================================ 
        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên

    End Sub


    Private Sub SetBackColorObligatory()
        c1dateDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ProductQuantity).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity03).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub LoadDefault()
        CheckMenu(_formIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        '**************************
        btnCreateVoucherNo.Enabled = ReturnPermission(Me.Name) >= 2
        btnInherit.Enabled = btnCreateVoucherNo.Enabled
        '**************************
        c1dateDateFrom.Value = Now.Date
        c1dateDateTo.Value = Now.Date
        tdbcDepartmentID.SelectedValue = "%"
        '**************************
        '**************************
        iHeight = tdbg.Height
        tdbg2.Visible = False
    End Sub

    Private Sub LoadCaptionQuantity()
        Dim sSQL As String = ""
        sSQL = "Select Code, ShortName" & UnicodeJoin(gbUnicode) & " As ShortName, Disabled From D45T0010  WITH(NOLOCK) Where Type = 'QTY' Order by Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim j As Integer = 0 'dòng của table
        If dt.Rows.Count > 0 Then
            For i As Integer = COL_ProductQuantity To COL_Quantity02
                tdbg.Splits(1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dt.Rows(j).Item("ShortName").ToString
                tdbg.Splits(1).DisplayColumns(i).Visible = L3Bool(IIf(dt.Rows(j).Item("Disabled").ToString = "1", 0, 1))
                j += 1
            Next
        End If
    End Sub
    Private Sub LoadTDBCombo()
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)
        LoadDataSource(tdbcDepartmentID, dtDepartmentID)
    End Sub
    Private Function AllowFilter() As Boolean
        If c1dateDateFrom.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay"))
            c1dateDateFrom.Focus()
            Return False
        End If
        If c1dateDateTo.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay"))
            c1dateDateTo.Focus()
            Return False
        End If

        If CDate(c1dateDateFrom.Text) > CDate(c1dateDateTo.Text) Then
            D99C0008.MsgL3(rl3("MSG000013"))
            c1dateDateFrom.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P2020()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
        '**************************
        LoadDetail(tdbg(tdbg.Row, COL_VoucherID).ToString)
    End Sub

    Private Sub LoadTDBGrid_Detail(ByVal sVoucherID As String)
        Dim sSQL As String = ""
        sSQL = "Select * From " & SQLUDFD45N2020(sVoucherID) & vbCrLf
        sSQL &= "Order by VoucherDate Desc, ProductVoucherNo"
        dtDetail = ReturnDataTable(sSQL)

        LoadDataSource(tdbg2, dtDetail, gbUnicode)
        FooterTotalGrid(tdbg2, COL2_ProductVoucherNo)
    End Sub

    Private Sub LoadDetail(ByVal sVoucherID As String)
        If dtGrid Is Nothing Then Exit Sub

        'Load luoi detail neu co check hien thi CCSP
        If chkShowCCSP.Checked Then
            ResetFilter(tdbg2, sFilterDetail, bRefreshFilter_Detail)
            If tdbg.RowCount > 0 Then
                LoadTDBGrid_Detail(sVoucherID)
            Else
                If dtDetail IsNot Nothing Then dtDetail.Clear()
            End If
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If AllowFilter() = False Then Exit Sub

        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub



        tdbg.UpdateData()

        Dim dt As DataTable = dtGrid.DefaultView.ToTable
        Dim dr() As DataRow = dt.Select("Choose= True")
        If dr.Length <= 0 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = 0
            tdbg.Col = COL_Choose
            tdbg.Bookmark = 0
            Exit Sub
        End If
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSQL As String = ""
        For i As Integer = 0 To dr.Length - 1
            If Not AllowDelete(L3String(dr(i)("VoucherID"))) Then
                tdbg.Focus()
                tdbg.SplitIndex = 0
                tdbg.Col = COL_Choose
                tdbg.Row = findrowInGrid(tdbg, L3String(dr(i)("VoucherID")), "VoucherID")
                Exit Sub
            End If
            sSQL &= " Delete D45T2020 Where VoucherID = " & SQLString(L3String(dr(i)("VoucherID"))) & vbCrLf
            sSQL &= " Delete D45T2021 Where VoucherID = " & SQLString(L3String(dr(i)("VoucherID"))) & vbCrLf
        Next

        'sSQL &= "Delete D45T2020 Where VoucherID = " & SQLString(tdbg.Columns(COL_VoucherID).Text) & vbCrLf
        'sSQL &= "Delete D45T2021 Where VoucherID = " & SQLString(tdbg.Columns(COL_VoucherID).Text) & vbCrLf


        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            'DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            'ResetGrid()
            LoadTDBGrid()
            DeleteOK()
        Else
            DeleteNotOK()
        End If

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
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    'Dim dtCaptionCols As DataTable

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, 0, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, 1, Arr, arrColObligatory, , , gbUnicode)

        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
        '*****************************************
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        'LoadGridFind(tdbg, dtGrid, strFind)'gây lỗi không nhập được ký tự thứ 2 trên filter
    
        ResetGrid()
        LoadDetail(tdbg(tdbg.Row, COL_VoucherID).ToString)
    End Sub

    Private Sub ReLoadTDBGrid2()
        Dim strFind As String = ""
        If sFilterDetail.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilterDetail.ToString

        dtDetail.DefaultView.RowFilter = strFind
        'LoadGridFind(tdbg, dtGrid, strFind)'gây lỗi không nhập được ký tự thứ 2 trên filter

        FooterTotalGrid(tdbg2, COL2_ProductVoucherNo)
    End Sub
#End Region

    Private Sub ResetGrid()
        CheckMenu(_formIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        FooterTotalGrid(tdbg, COL_VoucherNo)
    End Sub

    Private Sub c1dateDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        Try
            If e.KeyCode = Keys.Tab Then
                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
                tdbg.Col = tdbg.Col + 1
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub c1dateDate2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        Try
            If e.KeyCode = Keys.Tab Then
                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
                tdbg2.Col = tdbg2.Col + 1
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_Choose
                L3HeadClick(tdbg, iCol, bSelect) 'Có trong D99X0000
            Case Else
                tdbg.AllowSort = True 'Nếu mặc định AllowSort = True
        End Select
    End Sub

    Private Sub chkShowCCSP_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowCCSP.CheckedChanged
        If chkShowCCSP.Checked Then
            tdbg.Height = iHeight - tdbg2.Height - 12
            tdbg2.Visible = True
        Else
            tdbg.Height = iHeight
            tdbg2.Visible = False
        End If
    End Sub

#Region "tdbg"

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

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = COL_Choose Then HotKeyEnterGrid(tdbg, COL_Choose, e)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
        End If

        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    'không cho nhấn giá trị trên cột Filter bar đối với cột STT
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Choose 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_VoucherDate, COL_ProductCount, COL_BuildTimes
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_ProductQuantity
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If dtGrid Is Nothing OrElse e.LastRow = tdbg.Row Then Exit Sub
        LoadDetail(tdbg(tdbg.Row, COL_VoucherID).ToString)
    End Sub
#End Region

#Region "tdbg2"
    Private Sub tdbg2_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg2.FilterChange
        Try
            If (dtDetail Is Nothing) Then Exit Sub
            If bRefreshFilter_Detail Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg2, sFilterDetail)
            ReLoadTDBGrid2()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg2.Col = COL2_TeamName Then HotKeyEnterGrid(tdbg2, COL2_VoucherDate, e)
        End If

        HotKeyCtrlVOnGrid(tdbg2, e) 'Đã bổ sung D99X0000
    End Sub

    'không cho nhấn giá trị trên cột Filter bar đối với cột STT
    Private Sub tdbg2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg2.KeyPress
        Select Case tdbg2.Col
            Case COL2_VoucherDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

#End Region

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim dt As DataTable = dtGrid.DefaultView.ToTable
        Dim dr() As DataRow = dt.Select("Choose= True")
        If dr.Length <= 0 Then
            D99C0008.MsgL3(rl3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = 0
            tdbg.Col = COL_Choose
            tdbg.Bookmark = 0
            Return False
        End If
        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCreateVoucherNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateVoucherNo.Click
        tdbg.UpdateData()
        If Not AllowSave() Then Exit Sub

        _CreateVoucherNo_D45F2020 = True
        btnCreateVoucherNo.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLDeleteD09T6666.ToString & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s.ToString & vbCrLf)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            btnCreateVoucherNo.Enabled = True
            btnClose.Enabled = True

            Dim f As New D45F2022
            With f
                .ShowDialog()
                .Dispose()
            End With
        Else
            btnClose.Enabled = True
            btnCreateVoucherNo.Enabled = True
        End If
    End Sub

    Private Sub btnInherit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInherit.Click
        'Goi D45F2023
        Dim frm As New D45F2023
        With frm
            .ShowDialog()
            .Dispose()
        End With
        If frm.bSaved Then LoadTDBGrid()
    End Sub

    Private Function AllowDelete(ByVal sVoucherID As String) As Boolean
        Dim sSQL As String = SQLStoreD45P5555(sVoucherID)
        Return CheckStore(sSQL)
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2020
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/07/2011 10:38:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load luoi Master
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2020() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2020 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateDateFrom.Value) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateTo.Value) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(txtVoucherNo.Text) & COMMA 'VoucherNo, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        'ID 112419  15.10.2018
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DeparmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID))  'TeamID, varchar[20], NOT NULL

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUDFD45N2020
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/07/2011 10:39:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load luoi Detail
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUDFD45N2020(ByVal sVoucherID As String) As String
        Dim sSQL As String = ""
        sSQL &= "D45N2020("
        sSQL &= SQLString(sVoucherID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/07/2011 03:40:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where HostID=Host_Name() And Key01ID='D45F2020' And Key02ID='Voucher' And UserID=" & SQLString(gsUserID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/07/2011 03:42:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        Dim dt As DataTable = dtGrid.DefaultView.ToTable
        Dim dr() As DataRow = dt.Select("Choose= True")

        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Str01")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString("D45F2020") & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString("Voucher") & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_VoucherID).DataField).ToString)) 'Str01, nvarchar, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 22/11/2011 03:45:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P5555(ByVal sVoucherID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(sVoucherID) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function


#Region "Events tdbCombo - G4 Standard"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 OrElse tdbcDepartmentID.Text = "" Then
            tdbcDepartmentID.Text = ""
            tdbcDepartmentID.SelectedValue = "%"
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "%", tdbcDepartmentID.SelectedValue.ToString, gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedValue = "%"
    End Sub

    Private Sub tdbcTeamID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 OrElse tdbcTeamID.Text = "" Then
            tdbcTeamID.Text = ""
            tdbcTeamID.SelectedValue = "%"
        End If
    End Sub

#End Region
    
    Private Sub tdbg_AfterColUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.UpdateData()
    End Sub
End Class