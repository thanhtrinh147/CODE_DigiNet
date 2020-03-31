Public Class D25F3090
	Dim dtCaptionCols As DataTable



#Region "Const of tdbg"
    Private Const COL_CostTransID As Integer = 0       ' CostTransID
    Private Const COL_RecPlanID As Integer = 1         ' Mã kế hoạch tuyển dụng
    Private Const COL_PlanReferenceNo As Integer = 2   ' Kế hoạch tuyển dụng
    Private Const COL_ProposalID As Integer = 3        ' Mã đề xuất tuyển dụng
    Private Const COL_ProReferenceNo As Integer = 4    ' Đề xuất tuyển dụng
    Private Const COL_BlockID As Integer = 5           ' Mã khối
    Private Const COL_BlockName As Integer = 6         ' Tên khối
    Private Const COL_DepartmentID As Integer = 7      ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 8    ' Tên phòng ban
    Private Const COL_TeamID As Integer = 9            ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 10         ' Tên tổ nhóm
    Private Const COL_AppNumber As Integer = 11        ' Số lượng
    Private Const COL_VoucherDate As Integer = 12      ' Ngày lập
    Private Const COL_CreatorName As Integer = 13      ' Người lập
    Private Const COL_Note As Integer = 14             ' Ghi chú
    Private Const COL_RecPositionID As Integer = 15    ' Mã vị trí
    Private Const COL_RecPositionName As Integer = 16  ' Tên vị trí
    Private Const COL_RecSourceID As Integer = 17      ' Mã nguồn tuyển
    Private Const COL_RecSourceName As Integer = 18    ' Nguồn tuyển
    Private Const COL_PassNumber As Integer = 19       ' Số lượng thực tuyển
    Private Const COL_CostTypeName As Integer = 20     ' Kế hoạch/ Thực tế
    Private Const COL_RecCostID As Integer = 21        ' Mã loại chi phí
    Private Const COL_RecCostName As Integer = 22      ' Loại chi phí
    Private Const COL_CurrencyID As Integer = 23       ' Loại tiền
    Private Const COL_ExchangeRate As Integer = 24     ' Tỷ giá
    Private Const COL_OCost As Integer = 25            ' CP nguyên tệ
    Private Const COL_CCost As Integer = 26            ' CP quy đổi
    Private Const COL_FromDate As Integer = 27         ' Từ ngày
    Private Const COL_ToDate As Integer = 28           ' Đến ngày
    Private Const COL_Description As Integer = 29      ' Diễn giải
    Private Const COL_CostTypeID As Integer = 30       ' CostTypeID
    Private Const COL_CreatorID As Integer = 31        ' CreatorID
    Private Const COL_CreateUserID As Integer = 32     ' CreateUserID
    Private Const COL_CreateDate As Integer = 33       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 34 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 35   ' LastModifyDate
    Private Const COL_RecruimentFileID As Integer = 36 ' RecruimentFileID
#End Region


    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    '*****************************************
    Dim bLoadD25F2090 As Boolean = False 'Ktra xem co goi D25F2070 k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
    '*****************************************

    Dim iColumns() As Integer = {COL_OCost}
    Dim dtGrid, dtTeamID, dtDepartmentID As New DataTable
    Dim bIsFilter As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShowColumns)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnAction, btnClose)

    End Sub

    Private Sub D25F3010_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub D25F3010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor

        SetBackColorObligatory()
        gbEnabledUseFind = False
        Loadlanguage()

        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        ResetSplitDividerSize(tdbg)
        tdbg_NumberFormat()

        'tdbg.Columns(COL_FromDate).Editor = c1date1
        'tdbg.Columns(COL_ToDate).Editor = c1date1
        'tdbg.Columns(COL_VoucherDate).Editor = c1date1
        InputDateInTrueDBGrid(tdbg, COL_FromDate, COL_ToDate, COL_VoucherDate)
        LoadTDBCombo()
        LoadDefault()
        VisibleBlock()

        FooterTotalGrid(tdbg, COL_Description)
        FooterSumNew(tdbg, iColumns)

        InitiateD09U1111()
        InputbyUnicode(Me, gbUnicode)

        SetShortcutPopupMenu(C1CommandHolder)
        InputDateCustomFormat(c1dateVoucherDateFrom, c1dateVoucherDateTo, c1date1)
        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub
    'Dim dtCaptionCols As DataTable
    Private Sub InitiateD09U1111()
        '*****************************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'Đặt các dòng code sau vào cuối FormLoad
        Dim arrColObligatory() As Integer = {COL_RecPlanID, COL_RecPositionID}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, , , gbUnicode)
        Next
        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , , , gbUnicode)
        '*****************************************
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ExchangeRate).NumberFormat = DxxFormat.ExchangeRateDecimals
        tdbg.Columns(COL_CCost).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_OCost).NumberFormat = DxxFormat.DecimalPlaces
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_chi_phi_tuyen_dung_-_D25F3090") & UnicodeCaption(gbUnicode) 'Truy vÊn chi phÛ tuyÓn dóng - D25F3090
        '================================================================ 
        lblteVoucherDateFrom.Text = rl3("Ngay_lap") 'Ngày lập
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        lblRecCostID.Text = rl3("Loai_chi_phi") 'Loại chi phí
        '================================================================ 
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnFilter.Text = rl3("_Loc") '&Lọc
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcRecCostID.Columns("RecCostID").Caption = rl3("Ma") 'Mã
        tdbcRecCostID.Columns("RecCostName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_RecPlanID).Caption = rL3("Ma_ke_hoach_tuyen_dung") 'Mã kế hoạch tuyển dụng
        tdbg.Columns(COL_PlanReferenceNo).Caption = rL3("Ke_hoach_tuyen_dung") 'Kế hoạch tuyển dụng
        tdbg.Columns(COL_ProposalID).Caption = rL3("Ma_de_xuat_tuyen_dungU") 'Mã đề xuất tuyển dụng
        tdbg.Columns(COL_ProReferenceNo).Caption = rL3("De_xuat_tuyen_dung") 'Đề xuất tuyển dụng
        tdbg.Columns(COL_BlockID).Caption = rL3("Ma_khoi") 'Mã khối
        tdbg.Columns(COL_BlockName).Caption = rL3("Ten_khoi") 'Tên khối
        tdbg.Columns(COL_DepartmentID).Caption = rL3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rL3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns(COL_TeamName).Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_AppNumber).Caption = rL3("So_luong") 'Số lượng
        tdbg.Columns(COL_VoucherDate).Caption = rL3("Ngay_lap") 'Ngày lập
        tdbg.Columns(COL_CreatorName).Caption = rL3("Nguoi_lap") 'Người lập
        tdbg.Columns(COL_Note).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_RecPositionID).Caption = rL3("Ma_vi_tri") 'Mã vị trí
        tdbg.Columns(COL_RecPositionName).Caption = rL3("Ten_vi_tri") 'Tên vị trí
        tdbg.Columns(COL_RecSourceID).Caption = rL3("Ma_nguon_tuyen") 'Mã nguồn tuyển
        tdbg.Columns(COL_RecSourceName).Caption = rL3("Nguon_tuyen") 'Nguồn tuyển
        tdbg.Columns(COL_PassNumber).Caption = rL3("So_luong_thuc_tuyen") 'Số lượng thực tuyển
        tdbg.Columns(COL_CostTypeName).Caption = rL3("Ke_hoach_Thuc_te") 'Kế hoạch/ Thực tế
        tdbg.Columns(COL_RecCostID).Caption = rL3("Ma_loai_chi_phi") 'Mã loại chi phí
        tdbg.Columns(COL_RecCostName).Caption = rL3("Loai_chi_phi") 'Loại chi phí
        tdbg.Columns(COL_CurrencyID).Caption = rL3("Loai_tien") 'Loại tiền
        tdbg.Columns(COL_ExchangeRate).Caption = rL3("Ty_gia") 'Tỷ giá
        tdbg.Columns(COL_OCost).Caption = rL3("CP_nguyen_te") 'CP nguyên tệ
        tdbg.Columns(COL_CCost).Caption = rL3("CP_quy_doi") 'CP quy đổi
        tdbg.Columns(COL_FromDate).Caption = rL3("Tu_ngay") 'Từ ngày
        tdbg.Columns(COL_ToDate).Caption = rL3("Den_ngay") 'Đến ngày
        tdbg.Columns(COL_Description).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Splits(0).Caption = rL3("Thong_chi_chung") 'Thông chi chung
        tdbg.Splits(1).Caption = rL3("Thong_tin_chi_phi") 'Thông tin chi phí
        '================================================================ 
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuPrint.Text = rl3("_In") '&In
    End Sub

    Private Sub SetBackColorObligatory()
        c1dateVoucherDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecCostID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
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
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.Text, gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.Text, tdbcDepartmentID.Text, gbUnicode)

        'Load tdbcRecPositionID
        LoadDataSource(tdbcRecPositionID, ReturnTableDutyIDRec(, gbUnicode), gbUnicode)

        'Load tdbcRecCostID
        sSQL = "SELECT     0 as DisplayOrder,'%' AS RecCostID, " & sLanguage & " AS RecCostName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT     1 as DisplayOrder,RecCostID, RecCostName" & sUnicode & " As RecCostName" & vbCrLf
        sSQL &= "FROM       D25T1030 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE      Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY   DisplayOrder, RecCostID"
        LoadDataSource(tdbcRecCostID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadDefault()
        tdbcRecCostID.SelectedValue = "%"
        tdbcBlockID.SelectedValue = "%"
        tdbcRecPositionID.SelectedValue = "%"
        c1dateVoucherDateFrom.Value = Now
        c1dateVoucherDateTo.Value = Now
    End Sub

    Private Sub VisibleBlock()
        'Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        'If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
        If D25Systems.IsUseBlock = False Then
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockName).Visible = False
        End If
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal FlagEdit As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD25P3091()
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
                dtGrid.DefaultView.Sort = "CostTransID" 'Field của khóa chính
                tdbg.Bookmark = dtGrid.DefaultView.Find(sKeyID)
            End If

        End If

        FooterTotalGrid(tdbg, COL_Description)
        FooterSumNew(tdbg, iColumns)
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        If bLoadD25F2090 Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadD25F2090 = False
        End If

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
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        For Each dc In Me.tdbg.Columns
            dc.FilterText = ""
        Next dc
    End Sub

    Private Function AllowFilter() As Boolean

        If c1dateVoucherDateFrom.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_tu"))
            c1dateVoucherDateFrom.Focus()
            Return False
        End If
        If c1dateVoucherDateTo.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_den"))
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
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, ReturnValueC1Combo(tdbcBlockID), ReturnValueC1Combo(tdbcDepartmentID), gbUnicode)

        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close
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

            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ReturnValueC1Combo(tdbcBlockID), gbUnicode)
        End If
        tdbcDepartmentID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcRecPositionID"

    Private Sub tdbcRecPositionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.LostFocus
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then tdbcRecPositionID.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecCostID"

    Private Sub tdbcRecCostID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecCostID.LostFocus
        If tdbcRecCostID.FindStringExact(tdbcRecCostID.Text) = -1 Then tdbcRecCostID.Text = ""
    End Sub

#End Region

    'Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyDown, tdbcDepartmentID.KeyDown, tdbcTeamID.KeyDown, tdbcRecPositionID.KeyDown, tdbcRecCostID.KeyDown
    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbc.AutoCompletion = False

    '        Case Else
    '            tdbc.AutoCompletion = True
    '    End Select
    'End Sub

    'Private Sub tdbcXX_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Leave, tdbcDepartmentID.Leave, tdbcTeamID.Leave, tdbcRecPositionID.Leave, tdbcRecCostID.Leave
    '    'If gbUnicode Then Exit Sub

    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    If tdbc.SelectedIndex <> -1 Then
    '        tdbc.Text = tdbc.Columns(tdbc.DisplayMember).Text
    '    End If

    'End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close, tdbcRecCostID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated, tdbcRecCostID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
#End Region

#Region "Menu Events"

    Private Sub mnuAdd_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub

        '************************
        If Not bLoadD25F2090 Then vcNewTemp = vcNew
        bLoadD25F2090 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Dim f As New D25F2090
        With f
            .CostTransID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .SavedOK Then
                Dim sKey As String = f.CostTransID
                LoadTDBGrid(True)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub mnuView_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        '************************
        If Not bLoadD25F2090 Then vcNewTemp = vcNew
        bLoadD25F2090 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Dim f As New D25F2090
        With f
            .RecruitmentFileID = tdbg.Columns(COL_RecruimentFileID).Text
            .CostTransID = tdbg.Columns(COL_CostTransID).Text
            .dtGrid = ReturnTableFilter(dtGrid, "CostTransID = " & SQLString(tdbg.Columns(COL_CostTransID).Text), True)
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        '************************
        If Not bLoadD25F2090 Then vcNewTemp = vcNew
        bLoadD25F2090 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Dim f As New D25F2090
        With f
            .CostTransID = tdbg.Columns(COL_CostTransID).Text
            .RecruitmentFileID = tdbg.Columns(COL_RecruimentFileID).Text
            .dtGrid = ReturnTableFilter(dtGrid, "CostTransID = " & SQLString(tdbg.Columns(COL_CostTransID).Text), True)
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
            If .SavedOK Then
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid(False, True)
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub

        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            Dim bResult As Boolean = ExecuteSQL(SQLDeleteD25T2091)
            If bResult Then
                DeleteOK()
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid(False, True)
                If Not IsDBNull(tdbg.Bookmark) Then tdbg.Bookmark = Bookmark
            Else
                DeleteNotOK()
            End If
        End If

    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        'Dim f As New D25M0340
        'With f
        '    .FormActive = enumD25E0340Form.D25F4040
        '    .ID01 = ReturnValueC1Combo(tdbcBlockID) 'BlockID
        '    .ID02 = ReturnValueC1Combo(tdbcDepartmentID) 'DepartmentID
        '    .ID03 = ReturnValueC1Combo(tdbcTeamID) 'TeamID
        '    .ID04 = ReturnValueC1Combo(tdbcRecPositionID) 'RecPositionID
        '    .ID05 = c1dateVoucherDateFrom.Text 'VoucherDateFrom
        '    .ID06 = c1dateVoucherDateTo.Text 'VoucherDateTo
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "BlockID", ReturnValueC1Combo(tdbcBlockID))
        SetProperties(arrPro, "DepartmentID", ReturnValueC1Combo(tdbcDepartmentID))
        SetProperties(arrPro, "TeamID", ReturnValueC1Combo(tdbcTeamID))
        SetProperties(arrPro, "RecPositionID", ReturnValueC1Combo(tdbcRecPositionID))
        SetProperties(arrPro, "VoucherDateFrom", c1dateVoucherDateFrom.Value)
        SetProperties(arrPro, "VoucherDateTo", c1dateVoucherDateTo.Value)
        CallFormShow(Me, "D25D0340", "D25F4040", arrPro)
    End Sub

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    End Sub

#End Region

#Region "Active Find Client - List All "

    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        '*****************************************
        If usrOption IsNot Nothing And bLoadD25F2090 Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadD25F2090 = False
        End If
        '*****************************************
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
        FooterTotalGrid(tdbg, COL_Description)
        FooterSumNew(tdbg, iColumns)

        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    End Sub
#End Region

#Region "Grid Events"

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
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
        'Try
        '    If (dtGrid Is Nothing) Then Exit Sub
        '    sFilter = New StringBuilder("")
        '    Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        '    For Each dc In Me.tdbg.Columns
        '        Select Case dc.DataType.Name
        '            Case "DateTime"
        '                If dc.FilterText.Length = 10 Then
        '                    If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                    Dim sClause As String = ""
        '                    sClause = "(" & dc.DataField & " >= #" & DateSave(CDate(dc.FilterText)) & "#"
        '                    sClause &= " And " & dc.DataField & " < #" & DateSave(CDate(dc.FilterText).AddDays(1)) & "# )"
        '                    sFilter.Append(sClause)
        '                End If

        '            Case "Boolean"
        '                If dc.FilterText.Length > 0 Then
        '                    If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                    sFilter.Append((dc.DataField + " = " + "'" + dc.FilterText + "'"))
        '                End If

        '            Case "String"
        '                If dc.FilterText.Length > 0 Then
        '                    If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                    sFilter.Append((dc.DataField + " like " + "'%" + dc.FilterText.Replace("'", "''") + "%'"))
        '                End If

        '            Case "Decimal", "Byte", "Integer"
        '                If dc.FilterText.Length > 0 Then
        '                    If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                    sFilter.Append((dc.DataField + " = " + "" + dc.FilterText + ""))
        '                End If
        '        End Select
        '    Next

        '    'Filter the data 
        '    If sFilter.ToString() <> "" And sFind <> "" Then
        '        dtGrid.DefaultView.RowFilter = sFilter.ToString() & " AND " & sFind
        '    ElseIf sFind <> "" Then
        '        dtGrid.DefaultView.RowFilter = sFind
        '    ElseIf sFind = "" Then
        '        dtGrid.DefaultView.RowFilter = sFilter.ToString()
        '    End If

        '    CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        '    FooterTotalGrid(tdbg, COL_Description)
        '    FooterSum(tdbg, iColumns, , True)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & " - " & ex.Source)
        'End Try

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
            Case COL_ExchangeRate, COL_OCost, COL_CCost
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub

        If mnuEdit.Enabled Then
            mnuEdit_Click(sender, Nothing)
        ElseIf mnuView.Enabled Then
            mnuView_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg.FilterActive Then Exit Sub
            If mnuEdit.Enabled Then
                mnuEdit_Click(sender, Nothing)
            ElseIf mnuView.Enabled Then
                mnuView_Click(sender, Nothing)
            End If
        Else
            If e.Control Then
                CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
            End If
        End If
    End Sub

#End Region

#Region "SQL, Store"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3091
    '# Created User: 
    '# Created Date: 05/07/2010 03:26:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3091() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P3091 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateFrom.Text) & COMMA 'VoucherDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateTo.Text) & COMMA 'VoucherDateTo, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecCostID)) & COMMA 'RecCostID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecPositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2091
    '# Created User: 
    '# Created Date: 02/07/2010 03:07:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2091() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2091"
        sSQL &= " Where "
        sSQL &= "CostTransID = " & SQLString(tdbg.Columns(COL_CostTransID).Text)
        Return sSQL
    End Function

#End Region

End Class