Imports System

Public Class D25F3000
	Dim dtCaptionCols As DataTable

#Region "Const of tdbg - Total of Columns: 47"
    Private Const COL_ProApproved As Integer = 0       ' Duyệt
    Private Const COL_BlockID As Integer = 1           ' Mã khối
    Private Const COL_BlockName As Integer = 2         ' Tên khối
    Private Const COL_DepartmentID As Integer = 3      ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 4    ' Tên phòng ban
    Private Const COL_TeamID As Integer = 5            ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 6          ' Tên tổ nhóm
    Private Const COL_RecPositionID As Integer = 7     ' Mã vị trí
    Private Const COL_RecPositionName As Integer = 8   ' Tên vị trí
    Private Const COL_WorkID As Integer = 9            ' Công việc
    Private Const COL_WorkName As Integer = 10         ' Tên công việc
    Private Const COL_EmployeeQTY As Integer = 11      ' Định mức
    Private Const COL_ProNumber As Integer = 12        ' Số lượng
    Private Const COL_DateFrom As Integer = 13         ' Từ ngày
    Private Const COL_DateTo As Integer = 14           ' Đến ngày
    Private Const COL_VoucherDate As Integer = 15      ' Ngày lập
    Private Const COL_CreatorID As Integer = 16        ' CreatorID
    Private Const COL_CreatorName As Integer = 17      ' Người lập
    Private Const COL_Description As Integer = 18      ' Diễn giải
    Private Const COL_ReferenceNo As Integer = 19      ' Số tham chiếu
    Private Const COL_Ref01 As Integer = 20            ' Thông tin tham chiếu 01
    Private Const COL_Ref02 As Integer = 21            ' Thông tin tham chiếu 02
    Private Const COL_Ref03 As Integer = 22            ' Thông tin tham chiếu 03
    Private Const COL_Ref04 As Integer = 23            ' Thông tin tham chiếu 04
    Private Const COL_Ref05 As Integer = 24            ' Thông tin tham chiếu 05
    Private Const COL_Ref06 As Integer = 25            ' Thông tin tham chiếu 06
    Private Const COL_Ref07 As Integer = 26            ' Thông tin tham chiếu 07
    Private Const COL_Ref08 As Integer = 27            ' Thông tin tham chiếu 08
    Private Const COL_Ref09 As Integer = 28            ' Thông tin tham chiếu 09
    Private Const COL_Ref10 As Integer = 29            ' Thông tin tham chiếu 10
    Private Const COL_ProNote As Integer = 30          ' Ghi chú
    Private Const COL_TranMonth As Integer = 31        ' TranMonth
    Private Const COL_TranYear As Integer = 32         ' TranYear
    Private Const COL_CreateUserID As Integer = 33     ' CreateUserID
    Private Const COL_CreateDate As Integer = 34       ' CreatDate
    Private Const COL_LastModifyUserID As Integer = 35 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 36   ' LastModifyDate
    Private Const COL_TransID As Integer = 37          ' TransID
    Private Const COL_AppNumber As Integer = 38        ' SL duyệt
    Private Const COL_PassNumber As Integer = 39       ' SL thực tuyển
    Private Const COL_AppDate As Integer = 40          ' Ngày duyệt
    Private Const COL_ApproverID As Integer = 41       ' ApproverID
    Private Const COL_ApproverName As Integer = 42     ' Người duyệt
    Private Const COL_AppNote As Integer = 43          ' Ghi chú
    Private Const COL_StatusComplete As Integer = 44   ' Kết thúc nhận CV
    Private Const COL_IsDependPlan As Integer = 45     ' Theo kế hoạch
    Private Const COL_PlanTransID As Integer = 46      ' PlanTransID
#End Region


    Dim dtGrid, dtTeamID, dtDepartmentID, dtTransID As New DataTable
    Dim iColumns() As Integer = {COL_ProNumber, COL_EmployeeQTY, COL_AppNumber, COL_PassNumber}
    Private sKey As String = ""
    Dim bIsUseAppRecruitProposal As Boolean = False

#Region "UserControl D09U1111 (gồm 4 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới KHÔNG có nút: gồm 4 bước
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    ' b1: khai bao
    Private usrOption As D09U1111
#End Region

    Private _bIsViewPermissionOnly As Boolean
    Public WriteOnly Property bIsViewPermissionOnly() As Boolean
        Set(ByVal Value As Boolean)
            _bIsViewPermissionOnly = Value
        End Set
    End Property

    Private _formIDPermission As String = "D29F2020"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShow)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnAction, btnClose)

    End Sub

    Private Sub D25F3080_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            btnShow_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            usrOption.Hide()
        End If
        '***************************************

    End Sub

    Private Sub D25F3080_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral()
        SetBackColorObligatory()
        gbEnabledUseFind = False
        Loadlanguage()
        LoadRefCaption()
        ResetColorGrid(tdbg, SPLIT0, SPLIT2)
        bIsUseAppRecruitProposal = IsUseAppRecruitProposal()
        'tdbg.Columns(COL_DateFrom).Editor = c1date1
        'tdbg.Columns(COL_DateTo).Editor = c1date1
        'tdbg.Columns(COL_VoucherDate).Editor = c1date1
        InputDateInTrueDBGrid(tdbg, COL_DateFrom, COL_DateTo, COL_VoucherDate)
        LoadTDBCombo()
        LoadDefault()
        VisibleColumns()

        FooterTotalGrid(tdbg, COL_DepartmentID)
        FooterSumNew(tdbg, iColumns)

        SetShortcutPopupMenu(C1CommandHolder)
InputDateCustomFormat(c1dateTo,c1dateFrom,c1date1)
        InputDateInTrueDBGrid(tdbg, COL_AppDate)

        SetResolutionForm(Me, C1ContextMenu)

        InitiateD09U1111()

        Me.Cursor = Cursors.Default
    End Sub
    'Dim dtCaptionCols As DataTable
    Private Sub InitiateD09U1111()
        ''*****************************************
        '  Chuẩn hóa D09U1111 B2: Khởi tạo UserControl
        '  Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_ProApproved}

        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT2, Arr, arrColObligatory, , , gbUnicode)

        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, , , , , gbUnicode)
        ' *****************************************
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Khoi"))
            tdbcBlockID.Focus()
            Return False
        End If
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
        If tdbcRecPositionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Vi_tri"))
            tdbcRecPositionID.Focus()
            Return False
        End If
        If optPeriod.Checked Then
            If tdbcPeriodFrom.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky"))
                tdbcPeriodFrom.Focus()
                Return False
            End If
            If tdbcPeriodTo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky"))
                tdbcPeriodTo.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadDefault()
        tdbcPeriodFrom.Text = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcPeriodTo.Text = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcBlockID.SelectedIndex = 0
        tdbcRecPositionID.SelectedIndex = 0
        c1dateFrom.Value = Now
        c1dateTo.Value = Now
    End Sub

    Private Sub VisibleColumns()
        Dim sSQL As String = ""
        Dim dt As New DataTable
        sSQL = "select IsUseBlock from D09T0000 WITH(NOLOCK) "
        dt = ReturnDataTable(sSQL)
        If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockName).Visible = False
        End If
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcBlockID
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.Text, gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.Text, tdbcDepartmentID.Text, gbUnicode)

        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        'Load tdbcRecPositionID
        'sSQL = "Select '%' as RecPositionID, " & sLanguage & " As RecPositionName" & vbCrLf
        'sSQL &= "Union" & vbCrLf
        'sSQL &= "SELECT	RecPositionID, RecPositionName" & sUnicode & " as RecPositionName FROM D25T1020 WHERE(Disabled = 0) ORDER BY	RecPositionID"
        sSQL = "SELECT		0 as DisplayOrder,'%' AS RecPositionID, " & sLanguage & " AS RecPositionName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT		1 as DisplayOrder,DutyID As RecPositionID, DutyName" & sUnicode & " AS RecPositionName" & vbCrLf
        sSQL &= "FROM		D09T0211  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, RecPositionID" & vbCrLf
        LoadDataSource(tdbcRecPositionID, sSQL, gbUnicode)

        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, "D09")
    End Sub

    Private Sub LoadRefCaption()
        Dim sSQL As String = ""
        Dim dtSpec As New DataTable

        sSQL = SQLStoreD25P0050("D25T2001", gbUnicode)
        dtSpec = ReturnDataTable(sSQL)

        If dtSpec.Rows.Count <= 0 Then Exit Sub

        For i As Integer = 0 To 9
            tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref01 + i).Visible = Not CBool(dtSpec.Rows(i).Item("Disabled").ToString)
            tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref01 + i).HeadingStyle.Font = FontUnicode(gbUnicode, tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref01 + i).HeadingStyle.Font.Style) ' New Font("Lemon3", 8.249999)
            tdbg.Columns(COL_Ref01 + i).Caption = dtSpec.Rows(i).Item("RefCaption").ToString
        Next

    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_de_xuat_tuyen_dung_-_D25F3000") & UnicodeCaption(gbUnicode) 'Truy vÊn ¢Ò xuÊt tuyÓn dóng - D25F3000
        '================================================================ 
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        '================================================================ 
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnShow.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        chkIsAppPro.Text = rL3("De_xuat_da_duyet") 'Đề xuất đã duyệt
        chkIsInStock.Text = rL3("De_xuat_con_ton") ' "Đề xuất còn tồn" 'Đề xuất còn tồn
        '================================================================ 
        optDate.Text = rl3("Ngay_lap") 'Ngày lập
        optPeriod.Text = rl3("Ky") 'Kỳ
        '================================================================ 
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên

        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên

        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcPeriodTo.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("ProApproved").Caption = rl3("Duyet") 'Duyệt
        tdbg.Columns("BlockID").Caption = rl3("Ma_khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionID").Caption = rl3("Ma_vi_tri") 'Mã vị trí
        tdbg.Columns("RecPositionName").Caption = rl3("Ten_vi_tri") 'Tên vị trí
        tdbg.Columns("EmployeeQTY").Caption = rl3("Dinh_muc") 'Định mức
        tdbg.Columns("ProNumber").Caption = rl3("So_luong") 'Số lượng
        tdbg.Columns("DateFrom").Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_lap") 'Ngày lập
        tdbg.Columns("ProNote").Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns("CreatorID").Caption = rl3("Nguoi_lap")
        tdbg.Columns("CreatorName").Caption = rl3("Nguoi_lap") 'Người lập
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("AppNumber").Caption = rl3("SL_duyet") 'SL duyệt
        tdbg.Columns("AppDate").Caption = rl3("Ngay_duyet") 'Ngày duyệt
        tdbg.Columns("ApproverName").Caption = rl3("Nguoi_duyet") 'Người duyệt
        tdbg.Columns("AppNote").Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns("IsDependPlan").Caption = rl3("Theo_ke_hoach") 'Theo kế hoạch
        tdbg.Columns("ReferenceNo").Caption = rL3("So_tham_chieu") 'Theo kế hoạch
        tdbg.Columns(COL_PassNumber).Caption = rL3("So_luong_thuc_tuyen")
        tdbg.Columns(COL_WorkID).Caption = rL3("Cong_viec") 'Công việc
        tdbg.Columns(COL_WorkName).Caption = rL3("Ten_cong_viec") 'Tên công việc
        '================================================================ 
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuPrint.Text = rl3("_In") '&In
        mnuDivisionData.Text = rl3("Ta_ch_du_lieu") 'Tá&ch dữ liệu
        mnuApprove.Text = rl3("_Duyet") '&Duyệt
        mnuDeleteApprove.Text = rl3("_Bo_duyet") '&Bỏ duyệt
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rL3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuTranfer.Text = rL3("Chuyen_ton_de_xuat_TD")

        '================================================================ 
        tdbg.Columns(COL_StatusComplete).Caption = rL3("Ket_thuc_nhan_CV") 'Kết thúc nhận CV

    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal FlagEdit As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD25P3001()
        dtGrid = ReturnDataTable(sSQL)
        If dtGrid.Rows.Count < 1 Then 'Không có dữ liệu
            gbEnabledUseFind = False
            LoadDataSource(tdbg, dtGrid, gbUnicode)
            'CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
            ResetGrid()
        Else 'Có dữ liệu
            If Not FlagEdit Or Not gbEnabledUseFind Then 'Không phải nhấn Sửa (Xóa) hay Chưa nhấn tìm kiếm
                LoadDataSource(tdbg, dtGrid, gbUnicode)
                '  CheckMenu(_formIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
                ResetGrid()
            Else 'Nhấn Sửa (Xóa) hay đã nhấn Tìm kiếm
                ReLoadTDBGrid()
            End If
            If FlagAdd Then
                dtGrid.DefaultView.Sort = "TransID" 'Field của khóa chính
                tdbg.Bookmark = dtGrid.DefaultView.Find(sKeyID)
            End If

        End If
        If _bIsViewPermissionOnly Then
            mnuAdd.Enabled = False
            mnuEdit.Enabled = False
            mnuDelete.Enabled = False
        End If

        FooterTotalGrid(tdbg, COL_DepartmentID)
        FooterSumNew(tdbg, iColumns)
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Dim f As New D25F2000
        With f
            .TransID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .SavedOK Then
                Dim sKey As String = f.TransID
                LoadTDBGrid(True, False, sKey)
            End If
            .Dispose()
        End With

        InitiateD09U1111()
    End Sub

    Private Sub mnuView_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        dtTransID = ReturnTableFilter(dtGrid, "TransID = " & SQLString(tdbg.Columns(COL_TransID).Text), True)
        Dim f As New D25F2000
        With f
            .TransID = tdbg.Columns(COL_TransID).Text
            .FormState = EnumFormState.FormView
            .dtGrid = dtTransID
            .ShowDialog()
            .Dispose()
        End With

        InitiateD09U1111()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub
        Dim dtCheckStore As DataTable = Nothing
        If Not CheckStore(SQLStoreD25P5555(0), "", dtCheckStore) Then Exit Sub
        Dim bIsLock As Boolean = False
        If dtCheckStore IsNot Nothing OrElse dtCheckStore.Rows.Count > 0 Then bIsLock = L3Bool(dtCheckStore.Rows(0).Item("Status"))
        Me.Cursor = Cursors.WaitCursor
        dtTransID = ReturnTableFilter(dtGrid, "TransID = " & SQLString(tdbg.Columns(COL_TransID).Text), True)
        Dim f As New D25F2000
        With f
            .TransID = tdbg.Columns(COL_TransID).Text
            .FormIDPermission = Me.Name
            .IsLock = bIsLock
            .FormState = EnumFormState.FormEdit
            .dtGrid = dtTransID
            .ShowDialog()
            .Dispose()
            If .SavedOK Then
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid(False, True)
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            End If
        End With

        InitiateD09U1111()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub

        If Not CheckStore(SQLStoreD25P5555(2)) Then Exit Sub

        Dim sSQL As String
        Dim bResult As Boolean
        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            ' If Not AllowDelete() Then Exit Sub
            sSQL = SQLDeleteD25T2001()
            bResult = ExecuteSQL(sSQL)
            If bResult Then
                DeleteOK()
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid(False, True)
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            Else
                DeleteNotOK()
            End If
        End If
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
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
                '    CheckMenu(_formIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
                ResetGrid()
            End If
        End If
    End Sub

    Private Sub CheckMenuOther(ByVal FormName As String, ByVal C1CommandHolder As C1.Win.C1Command.C1CommandHolder, ByVal GridRowCount As Integer, ByVal UsedFind As Boolean, ByVal CheckCloseBook As Boolean)
        Dim per As Integer = ReturnPermission(FormName)
        For Each c As C1.Win.C1Command.C1Command In C1CommandHolder.Commands
            Select Case c.Name
                Case "mnuDivisionData"
                    If CheckCloseBook Then
                        c.Enabled = (per - 3 >= 0) And GridRowCount > 0 And Not gbClosed
                    Else
                        c.Enabled = (per - 3 >= 0) And GridRowCount > 0
                    End If
                Case "mnuApprove"
                    If GridRowCount > 0 Then
                        c.Enabled = (Not L3Bool(tdbg.Columns(COL_ProApproved).Text)) And ReturnPermission("D25F2020") >= EnumPermission.Add And bIsUseAppRecruitProposal = False
                    Else
                        c.Enabled = False
                    End If
                Case "mnuDeleteApprove"
                    If GridRowCount > 0 Then
                        c.Enabled = L3Bool(tdbg.Columns(COL_ProApproved).Text) And ReturnPermission("D25F2020") >= EnumPermission.Add And bIsUseAppRecruitProposal = False
                    Else
                        c.Enabled = False
                    End If
                Case "mnuTranfer"
                    If GridRowCount > 0 Then
                        c.Enabled = (Number(tdbg.Columns(COL_ProNumber).Text) - Number(tdbg.Columns(COL_PassNumber).Text)) > 0 And ReturnPermission("D25F3000") >= EnumPermission.Add
                    Else
                        c.Enabled = False
                    End If
            End Select
        Next
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        'Dim f As New D25M0340
        'With f
        '    .FormActive = enumD25E0340Form.D25F4050
        '    .ID01 = gsDivisionID 'DivisionID
        '    .ID02 = ReturnValueC1Combo(tdbcBlockID) 'BlockID
        '    .ID03 = ReturnValueC1Combo(tdbcDepartmentID) 'DepartmentID
        '    .ID04 = ReturnValueC1Combo(tdbcTeamID) 'TeamID
        '    .ID05 = ReturnValueC1Combo(tdbcRecPositionID) 'RecPositionID
        '    .ID06 = "" 'RecruitProposalID
        '    .ID07 = tdbg.Columns(COL_VoucherDate).Text 'ProposalDate
        '    .ShowDialog()
        '    .Dispose()
        'End With
        ExecuteSQL(SQLDeleteD09T6666() & vbCrLf & SQLInsertD09T6666s().ToString)
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "DivisionID", gsDivisionID)
        SetProperties(arrPro, "BlockID", ReturnValueC1Combo(tdbcBlockID))
        SetProperties(arrPro, "DepartmentID", ReturnValueC1Combo(tdbcDepartmentID))
        SetProperties(arrPro, "TeamID", ReturnValueC1Combo(tdbcTeamID))
        SetProperties(arrPro, "RecPositionID", ReturnValueC1Combo(tdbcRecPositionID))
        SetProperties(arrPro, "ProposalDate", tdbg.Columns(COL_VoucherDate).Text)
        CallFormShow(Me, "D25D0340", "D25F4050", arrPro)
    End Sub

    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- In" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID = " & SQLString(gsUserID) & _
                " AND HostID = " & SQLString(My.Computer.Name) & _
                " AND FormID = " & SQLString(Me.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 21/04/2014 08:46:46
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, FormID")
            sSQL.Append(") Values(" & vbCrlf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

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
        FooterSumNew(tdbg, iColumns)
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenuOther(_formIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        CheckMenu(_formIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    End Sub
#End Region

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
        '    FooterTotalGrid(tdbg, COL_DepartmentID)
        '    FooterSum(tdbg, iColumns, , True)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & " - " & ex.Source)
        'End Try

    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_ProNumber, COL_PassNumber
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    'Private Sub c1date1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1date1.KeyDown
    '    Try
    '        If e.KeyCode = Keys.Tab Then
    '            'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
    '            tdbg.Col = tdbg.Col + 1
    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '    End Try

    'End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub

        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
    End Sub

    Private Function AllowFilter() As Boolean
        If optPeriod.Checked Then
            If tdbcPeriodFrom.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky") & rl3("Tu"))
                tdbcPeriodFrom.Focus()
                Return False
            End If
            If tdbcPeriodTo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky_den"))
                tdbcPeriodTo.Focus()
                Return False
            End If
        End If

        If optDate.Checked Then
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

        Return True
    End Function


    Private Sub optDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDate.Click
        If optPeriod.Checked Then
            tdbcPeriodFrom.Enabled = True
            tdbcPeriodTo.Enabled = True
            c1dateFrom.Enabled = False
            c1dateTo.Enabled = False
        Else
            tdbcPeriodFrom.Enabled = False
            tdbcPeriodTo.Enabled = False
            c1dateFrom.Enabled = True
            c1dateTo.Enabled = True
        End If
    End Sub

    Private Sub optPeriod_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optPeriod.Click
        If optPeriod.Checked Then
            tdbcPeriodFrom.Enabled = True
            tdbcPeriodTo.Enabled = True
            c1dateFrom.Enabled = False
            c1dateTo.Enabled = False
        Else
            tdbcPeriodFrom.Enabled = False
            tdbcPeriodTo.Enabled = False
            c1dateFrom.Enabled = True
            c1dateTo.Enabled = True
        End If
    End Sub

#Region "Events tdbcPeriodFrom"

    Private Sub tdbcPeriodFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.LostFocus
        If tdbcPeriodFrom.FindStringExact(tdbcPeriodFrom.Text) = -1 Then tdbcPeriodFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcPeriodTo"

    Private Sub tdbcPeriodTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.LostFocus
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then tdbcPeriodTo.Text = ""
    End Sub

#End Region

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
        'tdbcDepartmentID.AutoSelect = True
    End Sub
#End Region

#Region "Events tdbcRecPositionID"

    Private Sub tdbcRecPositionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.LostFocus
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then tdbcRecPositionID.Text = ""
    End Sub

#End Region

    'Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyDown, tdbcDepartmentID.KeyDown, tdbcTeamID.KeyDown, tdbcRecPositionID.KeyDown
    '    If gbUnicode Then Exit Sub
    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbc.AutoCompletion = False

    '        Case Else
    '            tdbc.AutoCompletion = True
    '    End Select
    'End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShow.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True

    End Sub

    Private Sub mnuDivisionData_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDivisionData.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub

        If Not CheckStore(SQLStoreD25P5555(1)) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        dtTransID = ReturnTableFilter(dtGrid, "TransID = " & SQLString(tdbg.Columns(COL_TransID).Text), True)
        Dim f As New D25F2000
        With f
            .TransID = tdbg.Columns(COL_TransID).Text
            .FormState = EnumFormState.FormOther
            .dtGrid = dtTransID
            .ShowDialog()
            .Dispose()
            If .SavedOK Then
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid(False, True)
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            End If
        End With

        InitiateD09U1111()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub C1ContextMenu_Popup1(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        ResetGrid()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2001
    '# Created User: DUCTRONG
    '# Created Date: 03/06/2010 09:42:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2001() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2001"
        sSQL &= " Where "
        sSQL &= "TransID = " & SQLString(tdbg.Columns(COL_TransID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3080
    '# Created User: Kim Quang
    '# Created Date: 25/05/2010 11:28:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3080() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P3080 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Value) & COMMA 'VoucherDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Value) & COMMA 'VoucherDateTo, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecpositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(optPeriod.Checked) 'IsUsedPeriod, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3001
    '# Created User: DUCTRONG
    '# Created Date: 02/06/2010 01:56:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3001() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P3001 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Value) & COMMA 'VoucherDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Value) & COMMA 'VoucherDateTo, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecpositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(optPeriod.Checked) & COMMA 'IsUsedPeriod, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsAppPro.Checked) & COMMA 'IsAppPro, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(chkIsInStock.Checked) & COMMA 'IsInStock, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub mnuApprove_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuApprove.Click
        If CBool(tdbg.Columns(COL_ProApproved).Text) Then
            D99C0008.MsgL3(rL3("Phieu_nay_da_duoc_duyet")) 'Phiếu này đã được duyệt.
            Exit Sub
        End If

        Dim sSQL As String = ""
        sSQL = "-- Kiem tra de xuat su dung quy trinh duyet thi khong duoc phep duyet tai day" & vbCrLf
        sSQL &= SQLStoreD25P5555(4)
        If Not CheckStore(sSQL) Then Exit Sub

        Dim f As New D25F2021()
        With f
            Dim dtApprove As DataTable = ReturnTableFilter(dtGrid, "TransID = " & SQLString(tdbg.Columns(COL_TransID).Text), True)
            dtApprove.Columns.Add("IsUsed", GetType(Boolean))
            .dtGrid = dtApprove
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
        End With

        If f.SavedOK Then LoadTDBGrid()

        InitiateD09U1111()
    End Sub

    Private Sub mnuDeleteApprove_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDeleteApprove.Click
        'If ExistRecord("Select 1 From D25T2031 T1 INNER JOIN D25T2001 T2 ON T2.TransID = T1.ProposalTransID Where T2.TransID = " & SQLString(tdbg.Columns(COL_TransID).Text)) Then
        '    D99C0008.MsgL3(rl3("De_xuat_nay_da_duoc_su_dungU") & vbCrLf & rl3("Ban_khong_duoc_bo_duyet"))
        '    Exit Sub
        'End If

        If Not CheckStore(SQLStoreD25P5555(3)) Then Exit Sub

        If D99C0008.MsgAsk(rl3("Ban_co_muon_bo_duyet_de_xuat_nay_khong")) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim sSQL As String = ""
        sSQL &= "Update D25T2001 "
        sSQL &= "Set AppNumber = 0, ProApproved = 0, AppNote = '', AppDate = NULL, ApproverID = '' "
        sSQL &= "Where TransID = " & SQLString(tdbg.Columns(COL_TransID).Text)

        Dim bRun As Boolean = ExecuteSQL(sSQL)
        If bRun Then
            D99C0008.MsgL3(rl3("Bo_duyet_thanh_cong"))
            Dim iCurRow As Integer = tdbg.Row
            LoadTDBGrid()
            tdbg.Row = iCurRow
        Else
            D99C0008.MsgL3(rl3("MSG000024"))
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5555
    '# Created User: DUCTRONG
    '# Created Date: 04/06/2010 03:09:07
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5555(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString("D25F3000") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub tdbcName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Leave, tdbcTeamID.Leave, tdbcDepartmentID.Leave, tdbcRecPositionID.Leave
        '  If gbUnicode Then Exit Sub 
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)

        If tdbcName.SelectedIndex <> -1 Then
            tdbcName.Text = tdbcName.Columns(tdbcName.DisplayMember).Text
        End If
    End Sub

    Private Sub mnuTranfer_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTranfer.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim dtLink As DataTable = ReturnTableFilter(dtGrid, "TransID = " & SQLString(tdbg.Columns(COL_TransID).Text), True)
        'o	Reset lại cột Số lượng = SL duyệt – SL thực tuyển
        'o	LinkTransID = @TransID
        'o	TransID = ‘’
        If dtLink.Columns.Contains("LinkTransID") = False Then dtLink.Columns.Add("LinkTransID")
        If dtLink.Columns.Contains("ProNumber") = False Then dtLink.Columns.Add("ProNumber", Type.GetType("System.Decimal"))
        For i As Integer = 0 To dtLink.Rows.Count - 1
            dtLink.Rows(i).Item("LinkTransID") = dtLink.Rows(i).Item("TransID")
            dtLink.Rows(i).Item("TransID") = ""
            dtLink.Rows(i).Item("ProNumber") = Number(dtLink.Rows(i).Item("AppNumber")) - Number(dtLink.Rows(i).Item("PassNumber"))
        Next
        Dim f As New D25F2000
        With f
            .TransID = tdbg.Columns(COL_TransID).Text
            .FormState = EnumFormState.FormCopy
            .dtGrid = dtLink
            .ShowDialog()
            .Dispose()
            If .SavedOK Then
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid(False, True)
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            End If
        End With


        InitiateD09U1111()
        Me.Cursor = Cursors.Default
    End Sub
End Class