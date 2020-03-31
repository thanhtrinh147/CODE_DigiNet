Imports System
Public Class D25F5600
	Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_IsUsed As Integer = 0          ' Chọn
    Private Const COL_BlockID As Integer = 1         ' Mã khối
    Private Const COL_BlockName As Integer = 2       ' Tên khối
    Private Const COL_DepartmentID As Integer = 3    ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 4  ' Tên phòng ban
    Private Const COL_TeamID As Integer = 5          ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 6        ' Tên tổ nhóm
    Private Const COL_RecPositionID As Integer = 7   ' Mã vị trí
    Private Const COL_RecPositionName As Integer = 8 ' Tên vị trí
    Private Const COL_CandidateID As Integer = 9     ' Mã ứng viên
    Private Const COL_CandidateName As Integer = 10  ' Tên ứng viên
    Private Const COL_SexName As Integer = 11        ' Giới tính
    Private Const COL_Birthdate As Integer = 12      ' Ngày sinh
    Private Const COL_ReceivedDate As Integer = 13   ' Ngày nhận HS
    Private Const COL_ReceiverName As Integer = 14   ' Người nhận HS
    Private Const COL_ReceivedPlace As Integer = 15  ' Nơi nhận HS
    Private Const COL_DesiredSalary As Integer = 16  ' Lương yêu cầu
    Private Const COL_CurrencyID As Integer = 17     ' Loại tiền
    Private Const COL_RecSourceID As Integer = 18    ' RecSourceID
    Private Const COL_RecSourceName As Integer = 19  ' Nguồn tuyển dụng
    Private Const COL_SuggesterName As Integer = 20  ' Người giới thiệu
    Private Const COL_RecruitmentFileID As Integer = 21 ' RecruitmentFielID
#End Region

    Private _formID As String = ""
    Public Property FormID() As String 
        Get
            Return _formID
        End Get
        Set(ByVal Value As String )
            _formID = Value
        End Set
    End Property

    Private _voucherID As String = ""
    Public Property VoucherID() As String
        Get
            Return _voucherID
        End Get
        Set(ByVal Value As String)
            _voucherID = Value
        End Set
    End Property

    Private _key01ID As String = ""
    Public Property Key01ID() As String 
        Get
            Return _key01ID
        End Get
        Set(ByVal Value As String )
            _key01ID = Value
        End Set
    End Property

    Private _key02ID As String = ""
    Public Property Key02ID() As String 
        Get
            Return _key02ID
        End Get
        Set(ByVal Value As String )
            _key02ID = Value
        End Set
    End Property

    Private _key03ID As String = ""
    Public Property Key03ID() As String 
        Get
            Return _key03ID
        End Get
        Set(ByVal Value As String )
            _key03ID = Value
        End Set
    End Property

    Private _key04ID As String = ""
    Public Property Key04ID() As String 
        Get
            Return _key04ID
        End Get
        Set(ByVal Value As String )
            _key04ID = Value
        End Set
    End Property

    Private _key05ID As String = ""
    Public Property Key05ID() As String 
        Get
            Return _key05ID
        End Get
        Set(ByVal Value As String )
            _key05ID = Value
        End Set
    End Property

    Private _dataTableGrid As DataTable = Nothing
    Public Property DataTableGrid() As DataTable
        Get
            Return _dataTableGrid
        End Get
        Set(ByVal Value As DataTable)
            _dataTableGrid = Value
        End Set
    End Property

    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    '*****************************************

    Dim dtGrid As DataTable = Nothing
    Dim dtTeamID As DataTable = Nothing
    Dim dtDepartmentID As DataTable = Nothing

    Dim _candidateMode As Integer = 0
    Dim bIsFilter As Boolean = False

    Private Sub D25F5600_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.F
                    If mnuFind.Enabled Then
                        mnuFind_Click(Nothing, Nothing)
                        Exit Sub
                    End If
                Case Keys.A
                    If mnuListAll.Enabled Then
                        mnuListAll_Click(Nothing, Nothing)
                        Exit Sub
                    End If
            End Select
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở, đóng UserControl
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowColumns_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            usrOption.Hide()
        End If
        '***************************************

    End Sub

    'Dim dtCaptionCols As DataTable

    Private Sub D25F5600_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        gbEnabledUseFind = False
        Loadlanguage()
        ResetFooterGrid(tdbg, SPLIT0, SPLIT2)
        ResetSplitDividerSize(tdbg)
        tdbg_LockedColumns()

        SetBackColorObligatory()
        LoadTDBCombo()
        LoadDefault()
        VisibleBlock()

        FooterTotalGrid(tdbg, COL_DepartmentID)
        SetShortcutPopupMenu(C1CommandHolder)

        '*****************************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'Đặt các dòng code sau vào cuối FormLoad
        Dim arrColObligatory() As Integer = {COL_IsUsed}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, False, False, gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory, False, False, gbUnicode)
        AddColVisible(tdbg, SPLIT2, Arr, arrColObligatory, False, False, gbUnicode)

        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , , , gbUnicode)
        '*****************************************

        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtRFVoucherNo, txtRFVoucherNo.MaxLength)
        CheckIdTextBox(txtIFVoucherNo, txtIFVoucherNo.MaxLength)

        InputDateCustomFormat(c1dateTo, c1dateFrom)
        InputDateInTrueDBGrid(tdbg, COL_Birthdate, COL_ReceivedDate)

        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_ung_vien_-_D25F5600") & UnicodeCaption(gbUnicode) 'Chãn ÷ng vi£n - D25F5600
        '================================================================ 
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        lblRecResourceID.Text = rl3("Nguon_TD") 'Nguồn TD
        '================================================================ 
        btnFilter.Text = rl3("_Loc") '&Lọc
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnAction.Text = rl3("_Chon") '&Chọn
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkShowSelectedDataOnly.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        chkIsExcludeRecFile.Text = rl3("Loai_bo_nhung_ung_vien_da_ton_tai_trong_cac_dot_tuyen_dung") 'Loại bỏ những ứng viên đã tồn tại trong các đợt tuyển dụng
        chkIsExcludeInterviewFile.Text = rl3("Loai_bo_cac_ung_vien_da_ton_tai_trong_cac_lich_phong_van") 'Loại bỏ các ứng viên đã tồn tại trong các lịch phỏng vấn
        '================================================================ 
        optReceivedDate.Text = rl3("Ngay_lap_HS") 'Ngày lập HS
        optRFVoucherNo.Text = rl3("Ma_KH_tuyen_dung") 'rl3("Ma_KH_tuyen_dung") ' rl3("Ma_dot_TD") 'Mã đợt TD
        optIFVoucherNo.Text = rl3("Ma_lich_PV") 'Mã lịch PV
        '================================================================ 
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcRecResourceID.Columns("RecSourceID").Caption = rl3("Ma") 'Mã
        tdbcRecResourceID.Columns("RecSourceName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("BlockID").Caption = rl3("Ma_khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionID").Caption = rl3("Ma_vi_tri") 'Mã vị trí
        tdbg.Columns("RecPositionName").Caption = rl3("Ten_vi_tri") 'Tên vị trí
        tdbg.Columns("CandidateID").Caption = rl3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns("CandidateName").Caption = rl3("Ten_ung_vien") 'Tên ứng viên
        tdbg.Columns("SexName").Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg.Columns("Birthdate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("ReceivedDate").Caption = rl3("Ngay_nhan_HS") 'Ngày nhận HS
        tdbg.Columns("ReceiverName").Caption = rl3("Nguoi_nhan_HS") 'Người nhận HS
        tdbg.Columns("ReceivedPlace").Caption = rl3("Noi_nhan_HS") 'Nơi nhận HS
        tdbg.Columns("DesiredSalary").Caption = rl3("Luong_yeu_cau") 'Lương yêu cầu
        tdbg.Columns("CurrencyID").Caption = rl3("Loai_tien") 'Loại tiền
        tdbg.Columns("RecSourceName").Caption = rl3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        tdbg.Columns("SuggesterName").Caption = rl3("Nguoi_gioi_thieu") 'Người giới thiệu
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
    End Sub

    Private Sub SetBackColorObligatory()
        c1dateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtRFVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtIFVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        For i As Integer = COL_BlockID To COL_RecPositionName
            tdbg.Splits(SPLIT1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(i).AllowFocus = False
        Next
        For i As Integer = COL_CandidateID To COL_SuggesterName
            tdbg.Splits(SPLIT2).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT2).DisplayColumns(i).AllowFocus = False
        Next
    End Sub

    Private Sub LoadTDBCombo()
        Dim sUnicode As String = ""
        Dim sAll As String = ""
        UnicodeAllString(sUnicode, sAll, gbUnicode)

        Dim sSQL As String = ""
        'Load tdbcBlockID
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(True, True, gbUnicode)
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.Text, gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(True, True, gbUnicode)
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.Text, tdbcDepartmentID.Text, gbUnicode)

        'Load tdbcRecPositionID
        'sSQL = "Select '%' as RecPositionID, " & sAll & " As RecPositionName" & vbCrLf
        'sSQL &= "Union" & vbCrLf
        'sSQL &= "SELECT     RecPositionID, RecPositionName" & UnicodeJoin(gbUnicode) & " As RecPositionName" & vbCrLf
        'sSQL &= "FROM       D25T1020" & vbCrLf
        'sSQL &= "WHERE      Disabled = 0 O" & vbCrLf
        'sSQL &= "RDER BY    RecPositionID" & vbCrLf
        LoadDataSource(tdbcRecPositionID, ReturnTableDutyIDRec(True, gbUnicode), gbUnicode)

        sSQL = "SELECT  0 as DisplayOrder,'%' AS RecSourceID, " & sAll & " AS RecSourceName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT 1 as DisplayOrder,RecSourceID, RecSourceName" & sUnicode & " As RecSourceName" & vbCrLf
        sSQL &= "FROM   D25T1010  WITH(NOLOCK) Order by DisplayOrder"
        LoadDataSource(tdbcRecResourceID, sSQL, gbUnicode)

    End Sub

    Private Sub LoadDefault()
        tdbcBlockID.SelectedIndex = 0
        tdbcRecPositionID.SelectedIndex = 0
        tdbcRecResourceID.SelectedIndex = 0
        c1dateFrom.Value = Now
        c1dateTo.Value = Now
        optReceivedDate.Checked = True
        optReceivedDate_Click(Nothing, Nothing)
    End Sub

    Private Sub VisibleBlock()
        'Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        'If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
        If D25Systems.IsUseBlock = False Then
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockName).Visible = False
        End If
    End Sub

    Private Sub LoadTDBGrid()
        Dim dtSelected As DataTable = Nothing
        If dtGrid IsNot Nothing Then
            dtSelected = ReturnTableFilter(dtGrid, "IsUsed = True", True)
        End If

        dtGrid = ReturnDataTable(SQLStoreD25P5600)

        If dtSelected IsNot Nothing Then
            Dim keyCol() As DataColumn = {dtSelected.Columns("CandidateID")}
            dtSelected.PrimaryKey = keyCol
            Dim keyCol1() As DataColumn = {dtGrid.Columns("CandidateID")}
            dtGrid.PrimaryKey = keyCol1

            dtGrid.Merge(dtSelected, False, MissingSchemaAction.AddWithKey)
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        FooterTotalGrid(tdbg, COL_DepartmentID)
    End Sub

    Private Sub chkIsExcludeInterviewFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsExcludeInterviewFile.Click
        If Not bIsFilter Then Exit Sub
        btnFilter_Click(Nothing, Nothing)
    End Sub

    Private Sub chkIsExcludeRecFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsExcludeRecFile.Click
        If Not bIsFilter Then Exit Sub
        btnFilter_Click(Nothing, Nothing)
    End Sub

    Private Sub chkShowSelectedDataOnly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowSelectedDataOnly.Click
        If Not bIsFilter Then Exit Sub

        If dtGrid Is Nothing Then Exit Sub
        Dim sFilter As String = ""

        dtGrid.AcceptChanges()
        If chkShowSelectedDataOnly.Checked Then
            sFilter = "IsUsed = True"
        Else
            If sFind <> "" Then sFilter = sFind & " Or IsUsed = True"
        End If
        dtGrid.DefaultView.RowFilter = sFilter

        FooterTotalGrid(tdbg, COL_DepartmentID)
    End Sub

    Private Sub optReceivedDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optReceivedDate.Click
        If optReceivedDate.Checked Then
            c1dateFrom.Enabled = True
            c1dateTo.Enabled = True
            txtRFVoucherNo.Enabled = False
            txtIFVoucherNo.Enabled = False
        Else
            c1dateFrom.Enabled = False
            c1dateTo.Enabled = False
            txtRFVoucherNo.Enabled = True
            txtIFVoucherNo.Enabled = True
        End If
    End Sub

    Private Sub optRFVoucherNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optRFVoucherNo.Click
        If optRFVoucherNo.Enabled Then
            c1dateFrom.Enabled = False
            c1dateTo.Enabled = False
            txtRFVoucherNo.Enabled = True
            txtIFVoucherNo.Enabled = False
        Else
            c1dateFrom.ReadOnly = True
            c1dateTo.ReadOnly = True
            txtRFVoucherNo.ReadOnly = False
            txtIFVoucherNo.ReadOnly = True
        End If
    End Sub

    Private Sub optIFVoucherNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optIFVoucherNo.Click
        If optIFVoucherNo.Checked Then
            c1dateFrom.Enabled = False
            c1dateTo.Enabled = False
            txtRFVoucherNo.Enabled = False
            txtIFVoucherNo.Enabled = True
        Else
            c1dateFrom.Enabled = True
            c1dateTo.Enabled = True
            txtRFVoucherNo.Enabled = True
            txtIFVoucherNo.Enabled = False
        End If
    End Sub

    Private Function AllowFilter() As Boolean
        If optReceivedDate.Checked Then
            If c1dateFrom.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay_tu"))
                c1dateFrom.Focus()
                Return False
            End If
            If c1dateTo.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay_den"))
                c1dateTo.Focus()
                Return False
            End If
        End If

        If optRFVoucherNo.Checked Then
            If txtRFVoucherNo.Text = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ma_KH_thuc_hien"))
                txtRFVoucherNo.Focus()
                Return False
            End If
        End If

        If optIFVoucherNo.Checked Then
            If txtIFVoucherNo.Text = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ma_lich_PV"))
                txtIFVoucherNo.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        chkShowSelectedDataOnly.Checked = False

        btnFilter.Enabled = False

        If optReceivedDate.Checked Then
            _candidateMode = 1
        End If
        If optRFVoucherNo.Checked Then
            _candidateMode = 2
        End If
        If optIFVoucherNo.Checked Then
            _candidateMode = 3
        End If

        LoadTDBGrid()
        bIsFilter = True

        btnFilter.Enabled = True
    End Sub

    Private Function AllowChoose() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim bFlag As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                bFlag = True
                Exit For
            End If
        Next

        If bFlag = False Then
            D99C0008.MsgNotYetChoose(rl3("Ung_vien"))
            tdbg.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        If Not AllowChoose() Then Exit Sub

        _dataTableGrid = ReturnTableFilter(dtGrid, "IsUsed = True", True)
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

#Region "Active Find Client - List All "

    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid()
        End Set
    End Property

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, dtCaptionCols)
        ShowFindDialogClient(Finder, dtCaptionCols, Me, SQLNumber(0), gbUnicode)
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
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String
        strFind = sFind

        If strFind <> "" Then
            'If chkShowSelectedDataOnly.Checked Then
            strFind = strFind & " Or IsUsed = True"
            'End If
        Else
            If chkShowSelectedDataOnly.Checked Then
                strFind = "IsUsed = True"
            End If
        End If

        LoadGridFind(tdbg, dtGrid, strFind)
        FooterTotalGrid(tdbg, COL_DepartmentID)
    End Sub
#End Region

#Region "Combo Events"

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gbUnicode)

        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If Not (tdbcBlockID.Tag Is Nothing OrElse tdbcBlockID.Tag.ToString = "") Then
            tdbcBlockID.Tag = ""
            Exit Sub
        End If

        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", "-1", gbUnicode)
        Else

            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, gbUnicode)
        End If
        tdbcDepartmentID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcRecPositionID"

    Private Sub tdbcRecPositionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.LostFocus
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then tdbcRecPositionID.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecResourceID"

    Private Sub tdbcRecResourceID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecResourceID.LostFocus
        If tdbcRecResourceID.FindStringExact(tdbcRecResourceID.Text) = -1 Then tdbcRecResourceID.Text = ""
    End Sub

#End Region


    'Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyDown, tdbcDepartmentID.KeyDown, tdbcTeamID.KeyDown, tdbcRecPositionID.KeyDown, tdbcRecResourceID.KeyDown
    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbc.AutoCompletion = False

    '        Case Else
    '            tdbc.AutoCompletion = True
    '    End Select
    'End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close, tdbcRecResourceID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated, tdbcRecResourceID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub


#End Region

#Region "Grid Events"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        Select Case e.ColIndex
            Case COL_IsUsed
                If chkShowSelectedDataOnly.Checked Then tdbg.UpdateData()
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case e.ColIndex()
            Case COL_IsUsed
                Dim bFlag As Boolean = Not L3Bool(tdbg(0, COL_IsUsed).ToString)
                For i As Integer = tdbg.RowCount - 1 To 0 Step -1
                    tdbg(i, COL_IsUsed) = bFlag
                Next
                If chkShowSelectedDataOnly.Checked Then tdbg.UpdateData()
        End Select
    End Sub

#End Region

#Region "SQL, Store"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5600
    '# Created User: DUCTRONG
    '# Created Date: 16/06/2010 08:22:35
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5600() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P5600 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(_candidateMode) & COMMA 'CandidateMode, tinyint, NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Value) & COMMA 'ReceivedDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Value) & COMMA 'ReceivedDateTo, datetime, NOT NULL
        sSQL &= SQLString(txtRFVoucherNo.Text) & COMMA 'RFVoucherNo, varchar[50], NOT NULL
        sSQL &= SQLString(txtIFVoucherNo.Text) & COMMA 'IFVoucherNo, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecPositionID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecResourceID)) & COMMA 'RecSourceID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsExcludeRecFile.Checked) & COMMA 'IsExcludeRecFile, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsExcludeInterviewFile.Checked) & COMMA 'IsExcludeInterviewFile, tinyint, NOT NULL
        sSQL &= SQLString(_formID) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_voucherID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(_key01ID) & COMMA 'Key01ID, varchar[250], NOT NULL
        sSQL &= SQLString(_key02ID) & COMMA 'Key02ID, varchar[250], NOT NULL
        sSQL &= SQLString(_key03ID) & COMMA 'Key03ID, varchar[250], NOT NULL
        sSQL &= SQLString(_key04ID) & COMMA 'Key04ID, varchar[250], NOT NULL
        sSQL &= SQLString(_key05ID) & COMMA 'Key05ID, varchar[250], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) 
        Return sSQL
    End Function

#End Region

    Private Sub txtRFVoucherNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRFVoucherNo.KeyDown
        If e.KeyCode = Keys.F2 And optRFVoucherNo.Checked Then
            'Dim f As New D91F6010
            'f.InListID = "89"
            'f.ShowDialog()
            'txtRFVoucherNo.Text = f.OutPut01
            txtRFVoucherNo.Text = CallFormD91F6010("89")
        End If
    End Sub

    Private Sub txtIFVoucherNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIFVoucherNo.KeyDown
        If e.KeyCode = Keys.F2 And optIFVoucherNo.Checked Then
            'Dim f As New D91F6010
            'f.InListID = "90"
            'f.ShowDialog()
            'txtIFVoucherNo.Text = f.OutPut01
            txtRFVoucherNo.Text = CallFormD91F6010("90")
        End If
    End Sub

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        If chkShowSelectedDataOnly.Checked Then
            mnuFind.Enabled = False
            mnuListAll.Enabled = False
        Else
            CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        End If
    End Sub

End Class