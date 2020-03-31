Public Class D25F3050
	Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_BlockID As Integer = 0             ' Mã khối
    Private Const COL_BlockName As Integer = 1           ' Tên khối
    Private Const COL_DepartmentID As Integer = 2        ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 3      ' Tên phòng ban
    Private Const COL_TeamID As Integer = 4              ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 5            ' Tên tổ nhóm
    Private Const COL_RecPositionID As Integer = 6       ' Mã vị trí
    Private Const COL_RecPositionName As Integer = 7     ' Tên vị trí
    Private Const COL_PlanNumber As Integer = 8          ' SL kế hoạch
    Private Const COL_ProNumber As Integer = 9           ' SL đề xuất
    Private Const COL_ChosenNumber As Integer = 10       ' SL được chọn
    Private Const COL_JoinedNumber As Integer = 11       ' SL tham gia
    Private Const COL_PassedNumber As Integer = 12       ' SL đạt
    Private Const COL_CandidateID As Integer = 13        ' Mã ứng viên
    Private Const COL_CandidateName As Integer = 14      ' Tên ứng viên
    Private Const COL_CanBlockID As Integer = 15         ' CanBlockID
    Private Const COL_CanBlockName As Integer = 16       ' CanBlockName
    Private Const COL_CanDepartmentID As Integer = 17    ' CanDepartmentID
    Private Const COL_CanDepartmentName As Integer = 18  ' CanDepartmentName
    Private Const COL_CanTeamID As Integer = 19          ' CanTeamID
    Private Const COL_CanTeamName As Integer = 20        ' CanTeamName
    Private Const COL_CanRecPositionID As Integer = 21   ' CanRecPositionID
    Private Const COL_CanRecPositionName As Integer = 22 ' CanRecPositionName
    Private Const COL_IntStatusName As Integer = 23      ' Kết quả
    Private Const COL_SexName As Integer = 24            ' Giới tính
    Private Const COL_BirthDate As Integer = 25          ' Ngày sinh
    Private Const COL_RecSourceName As Integer = 26      ' Nguồn tuyển dụng
    Private Const COL_IntDate As Integer = 27            ' Ngày PV
    Private Const COL_TransferedD09 As Integer = 28      ' Chuyển sang HSNV
#End Region

    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    '*****************************************

    Dim iColumns() As Integer = {COL_PlanNumber, COL_ProNumber, COL_ChosenNumber, COL_JoinedNumber, COL_PassedNumber}
    Dim dtGrid, dtTeamID, dtDepartmentID As New DataTable
    Dim bIsFilter As Boolean = False
    Dim bIsUseBlock As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeft, chkIsDisplayDetail)
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShowColumns)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnAction, btnClose)

    End Sub


    Private Sub D25F3050_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub D25F3050_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor

        gbEnabledUseFind = False
        Loadlanguage()

        ResetColorGrid(tdbg, SPLIT0)
        ResetSplitDividerSize(tdbg)
        tdbg_NumberFormat()
        'tdbg.Columns(COL_BirthDate).Editor = c1date1
        'tdbg.Columns(COL_IntDate).Editor = c1date1
        InputDateInTrueDBGrid(tdbg, COL_BirthDate, COL_IntDate)
        LoadTDBCombo()
        LoadDefault()
        bIsUseBlock = VisibleBlock()

        FooterTotalGrid(tdbg, COL_DepartmentID)
        FooterTotalGrid(tdbg, COL_CandidateName)
        FooterSum(tdbg, iColumns)

        InitiateD09U1111()
        InputbyUnicode(Me, gbUnicode)

        SetShortcutPopupMenu(C1CommandHolder)
InputDateCustomFormat(c1dateVoucherDateTo,c1dateVoucherDateFrom,c1date1)
        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_ket_qua_tuyen_dung_-_D25F3050") & UnicodeCaption(gbUnicode) 'Truy vÊn kÕt qu¶ tuyÓn dóng - D25F3050
        '================================================================ 
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        lblteVoucherDateFrom.Text = rl3("Ngay_tuyenU") 'Ngày tuyển
        lblIntStatusID.Text = rl3("Ket_qua_PV") 'Kết quả PV
        '================================================================ 
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        '================================================================ 
        chkIsDisplayDetail.Text = rl3("Hien_thi_chi_tiet") 'Hiển thị chi tiết
        '================================================================ 
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcIntStatusID.Columns("IntStatusID").Caption = rl3("Ma") 'Mã
        tdbcIntStatusID.Columns("IntStatusName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("BlockID").Caption = rl3("Ma_khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionID").Caption = rl3("Ma_vi_tri") 'Mã vị trí
        tdbg.Columns("RecPositionName").Caption = rl3("Ten_vi_tri") 'Tên vị trí
        tdbg.Columns("PlanNumber").Caption = rl3("SL_ke_hoach") 'SL kế hoạch
        tdbg.Columns("ProNumber").Caption = rl3("_SL_____de_xuat") 'SL đề xuất
        tdbg.Columns("ChosenNumber").Caption = rl3("SL_duoc_chon") 'SL được chọn
        tdbg.Columns("JoinedNumber").Caption = rl3("SL_tham_gia") 'SL tham gia
        tdbg.Columns("PassedNumber").Caption = rl3("SL_dat") 'SL đạt
        tdbg.Columns("CandidateID").Caption = rl3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns("CandidateName").Caption = rl3("Ten_ung_vien") 'Tên ứng viên

        tdbg.Columns("CanBlockID").Caption = rl3("Ma_khoi") 'Mã khối
        tdbg.Columns("CanBlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("CanDepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("CanDepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("CanTeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("CanTeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("CanRecPositionID").Caption = rl3("Ma_vi_tri") 'Mã vị trí
        tdbg.Columns("CanRecPositionName").Caption = rl3("Ten_vi_tri") 'Tên vị trí

        tdbg.Columns("IntStatusName").Caption = rl3("Ket_qua") 'Kết quả
        tdbg.Columns("SexName").Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg.Columns("BirthDate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("RecSourceName").Caption = rl3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        tdbg.Columns("IntDate").Caption = rl3("Ngay_PV") 'Ngày PV
        tdbg.Columns("TransferedD09").Caption = rl3("Chuyen_sang_HSNV") 'Chuyển sang HSNV
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuPrint.Text = rl3("_In") '&In
    End Sub

    Private Sub InitiateD09U1111()
        '*****************************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'Đặt các dòng code sau vào cuối FormLoad
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory, , , gbUnicode)
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , , , gbUnicode)
        '*****************************************
    End Sub

    Private Sub chkIsDisplayDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsDisplayDetail.Click
        For i As Integer = COL_BlockID To COL_PassedNumber
            tdbg.Splits(SPLIT0).DisplayColumns(i).Visible = Not chkIsDisplayDetail.Checked
        Next
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Visible = (Not chkIsDisplayDetail.Checked) And bIsUseBlock
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Visible = (Not chkIsDisplayDetail.Checked) And bIsUseBlock

        For i As Integer = COL_CandidateID To COL_TransferedD09
            tdbg.Splits(SPLIT0).DisplayColumns(i).Visible = chkIsDisplayDetail.Checked
        Next
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CanBlockID).Visible = chkIsDisplayDetail.Checked And bIsUseBlock
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CanBlockName).Visible = chkIsDisplayDetail.Checked And bIsUseBlock

        InitiateD09U1111()

        If bIsFilter = False Then Exit Sub

        btnFilter_Click(Nothing, Nothing)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_PlanNumber).NumberFormat = D25Format.DefaultNumber0
        tdbg.Columns(COL_ProNumber).NumberFormat = D25Format.DefaultNumber0
        tdbg.Columns(COL_ChosenNumber).NumberFormat = D25Format.DefaultNumber0
        tdbg.Columns(COL_JoinedNumber).NumberFormat = D25Format.DefaultNumber0
        tdbg.Columns(COL_PassedNumber).NumberFormat = D25Format.DefaultNumber0
    End Sub

    Private Sub LoadTDBCombo()
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************

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
        sSQL = "SELECT '%' AS RecPositionID, " & sLanguage & " AS RecPositionName, 0 as DisplayOrder" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT	DutyID As RecPositionID, DutyName" & sUnicode & " AS RecPositionName, 1 as DisplayOrder" & vbCrLf
        sSQL &= "FROM D09T0211  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE	Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, RecPositionName" & vbCrLf
        LoadDataSource(tdbcRecPositionID, sSQL, gbUnicode)

        'Load tdbcIntStatusID
        sSQL = "Select	0 as DisplayOrder,'%' as IntStatusID, " & sLanguage & " as IntStatusName " & vbCrLf
        sSQL &= "Union	" & vbCrLf
        sSQL &= "Select	1 as DisplayOrder,'00001' as IntStatusID, " & IIf(gbUnicode, "N'Đạt'", "'Ñaït'").ToString() & " as IntStatusName " & vbCrLf
        sSQL &= "Union	" & vbCrLf
        sSQL &= "Select	1 as DisplayOrder,'00002' as IntStatusID, " & IIf(gbUnicode, "N'Không đạt'", "'Khoâng ñaït'").ToString() & " as IntStatusName" & vbCrLf
        sSQL &= "Union	" & vbCrLf
        sSQL &= "Select	1 as DisplayOrder,'00003' as IntStatusID, " & IIf(gbUnicode, "N'Không tham gia phỏng vấn'", "'Khoâng tham gia phoûng vaán'").ToString() & " as IntStatusName" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select	1 as DisplayOrder,'00004' as IntStatusID, " & IIf(gbUnicode, "N'Dời lịch phỏng vấn'", "'Dôøi lòch phoûng vaán'").ToString() & " as IntStatusName" & vbCrLf
        sSQL &= "Order by	DisplayOrder, IntStatusID"
        LoadDataSource(tdbcIntStatusID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadDefault()
        tdbcBlockID.SelectedValue = "%"
        tdbcRecPositionID.SelectedValue = "%"
        tdbcIntStatusID.SelectedValue = "%"
        c1dateVoucherDateFrom.Value = Now
        c1dateVoucherDateTo.Value = Now
    End Sub

    Private Function VisibleBlock() As Boolean
        Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockName).Visible = False
            Return False
        End If
        Return True
    End Function

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal FlagEdit As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD25P3050()
        dtGrid = ReturnDataTable(sSQL)
        If dtGrid.Rows.Count < 1 Then 'Không có dữ liệu
            gbEnabledUseFind = False
            LoadDataSource(tdbg, dtGrid, gbUnicode)
            CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        Else 'Có dữ liệu
            If Not FlagEdit Or Not gbEnabledUseFind Then 'Không phải nhấn Sửa (Xóa) hay Chưa nhấn tìm kiếm
                LoadDataSource(tdbg, dtGrid, gbUnicode)
                CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
            Else 'Nhấn Sửa (Xóa) hay đã nhấn Tìm kiếm
                ReLoadTDBGrid()
            End If
            If FlagAdd Then
                dtGrid.DefaultView.Sort = "CadidateID" 'Field của khóa chính
                tdbg.Bookmark = dtGrid.DefaultView.Find(sKeyID)
            End If

        End If

        FooterTotalGrid(tdbg, COL_DepartmentID)
        FooterTotalGrid(tdbg, COL_CandidateName)
        FooterSum(tdbg, iColumns)
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub

        sFind = ""
        ResetFilter()
        LoadTDBGrid()

        bIsFilter = True
    End Sub

    Private Sub ResetFilter()
        'Set lại các giá trị FilterText
        tdbg.SetDataBinding(Nothing, "", True)
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        For Each dc In Me.tdbg.Columns
            dc.FilterText = ""
        Next dc
    End Sub

    Private Function AllowFilter() As Boolean

        If c1dateVoucherDateFrom.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ngay_tu"))
            c1dateVoucherDateFrom.Focus()
            Return False
        End If
        If c1dateVoucherDateTo.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ngay_den"))
            c1dateVoucherDateTo.Focus()
            Return False
        End If

        Return True
    End Function

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

#Region "Events tdbcIntStatusID"

    Private Sub tdbcIntStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcIntStatusID.LostFocus
        If tdbcIntStatusID.FindStringExact(tdbcIntStatusID.Text) = -1 Then tdbcIntStatusID.Text = ""
    End Sub

#End Region

    'Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyDown, tdbcDepartmentID.KeyDown, tdbcTeamID.KeyDown, tdbcRecPositionID.KeyDown, tdbcIntStatusID.KeyDown
    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbc.AutoCompletion = False

    '        Case Else
    '            tdbc.AutoCompletion = True
    '    End Select
    'End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close, tdbcIntStatusID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated, tdbcIntStatusID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    'Private Sub tdbcXX_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Leave, tdbcDepartmentID.Leave, tdbcTeamID.Leave, tdbcRecPositionID.Leave, tdbcIntStatusID.Leave
    '    'If gbUnicode Then Exit Sub

    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    If tdbc.SelectedIndex <> -1 Then
    '        tdbc.Text = tdbc.Columns(tdbc.DisplayMember).Text
    '    End If

    'End Sub

#End Region

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

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, gdtCaptionExcel)
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, gdtCaptionExcel.DefaultView.ToTable), Me, SQLNumber(0), gbUnicode)
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
        'Dim strFind As String
        'strFind = sFind
        'If sFilter.ToString() <> "" Then
        '    If strFind <> "" Then
        '        strFind &= " And " & sFilter.ToString
        '    Else
        '        strFind &= sFilter.ToString
        '    End If
        'End If
        'LoadGridFind(tdbg, dtGrid, strFind)
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        FooterTotalGrid(tdbg, COL_DepartmentID)
        FooterTotalGrid(tdbg, COL_CandidateName)
        FooterSumNew(tdbg, iColumns)

        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    End Sub
#End Region

#Region "Grid Events"

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        '    Try
        '        If (dtGrid Is Nothing) Then Exit Sub
        '        sFilter = New StringBuilder("")
        '        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        '        For Each dc In Me.tdbg.Columns
        '            Select Case dc.DataType.Name
        '                Case "DateTime"
        '                    If dc.FilterText.Length = 10 Then
        '                        If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                        Dim sClause As String = ""
        '                        sClause = "(" & dc.DataField & " >= #" & DateSave(CDate(dc.FilterText)) & "#"
        '                        sClause &= " And " & dc.DataField & " < #" & DateSave(CDate(dc.FilterText).AddDays(1)) & "# )"
        '                        sFilter.Append(sClause)
        '                    End If

        '                Case "Boolean"
        '                    If dc.FilterText.Length > 0 Then
        '                        If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                        sFilter.Append((dc.DataField + " = " + "'" + dc.FilterText + "'"))
        '                    End If

        '                Case "String"
        '                    If dc.FilterText.Length > 0 Then
        '                        If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                        sFilter.Append((dc.DataField + " like " + "'%" + dc.FilterText.Replace("'", "''") + "%'"))
        '                    End If

        '                Case "Decimal", "Byte", "Integer", "Int32"
        '                    If dc.FilterText.Length > 0 Then
        '                        If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                        sFilter.Append((dc.DataField + " = " + "" + dc.FilterText + ""))
        '                    End If
        '            End Select
        '        Next

        '        'Filter the data 
        '        If sFilter.ToString() <> "" And sFind <> "" Then
        '            dtGrid.DefaultView.RowFilter = sFilter.ToString() & " AND " & sFind
        '        ElseIf sFind <> "" Then
        '            dtGrid.DefaultView.RowFilter = sFind
        '        ElseIf sFind = "" Then
        '            dtGrid.DefaultView.RowFilter = sFilter.ToString()
        '        End If

        '        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        '        FooterTotalGrid(tdbg, COL_DepartmentID)
        '        FooterTotalGrid(tdbg, COL_CandidateName)
        '        FooterSum(tdbg, iColumns, , True)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & " - " & ex.Source)
        'End Try
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            'MessageBox.Show(ex.Message & " - " & ex.Source)
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub c1date1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1date1.KeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
                tdbg.Col = tdbg.Col + 1
                Exit Sub
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_PlanNumber
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_ProNumber
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_ChosenNumber
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_JoinedNumber
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_PassedNumber
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control Then
            CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        End If
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3050
    '# Created User: 
    '# Created Date: 27/07/2010 03:53:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3050() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P3050 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateFrom.Text) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateTo.Text) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcIntStatusID)) & COMMA 'IntStatusID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecpositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsDisplayDetail.Checked) & COMMA 'IsDetailDisplay, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        'Dim f As New D25M0340
        'With f
        '    .FormActive = enumD25E0340Form.D25F4010
        '    .ID01 = ReturnValueC1Combo(tdbcBlockID)
        '    .ID02 = ReturnValueC1Combo(tdbcDepartmentID)
        '    .ID03 = ReturnValueC1Combo(tdbcTeamID)
        '    .ID04 = ReturnValueC1Combo(tdbcRecPositionID)
        '    .ID05 = ReturnValueC1Combo(tdbcIntStatusID)
        '    .ID06 = c1dateVoucherDateFrom.Text
        '    .ID07 = c1dateVoucherDateTo.Text
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "BlockID", ReturnValueC1Combo(tdbcBlockID))
        SetProperties(arrPro, "DepartmentID", ReturnValueC1Combo(tdbcDepartmentID))
        SetProperties(arrPro, "TeamID", ReturnValueC1Combo(tdbcTeamID))
        SetProperties(arrPro, "RecPositionID", ReturnValueC1Combo(tdbcRecPositionID))
        SetProperties(arrPro, "IntStatusID", ReturnValueC1Combo(tdbcIntStatusID))
        SetProperties(arrPro, "DateFrom", c1dateVoucherDateFrom.Text)
        SetProperties(arrPro, "DateTo", c1dateVoucherDateTo.Text)
        CallFormThread(Me, "D25D0340", "D25F4010", arrPro)
    End Sub

End Class