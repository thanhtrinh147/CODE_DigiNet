Public Class D25F3070
	Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0            ' TransID
    Private Const COL_RecInformationID As Integer = 1   ' RecInformationID
    Private Const COL_VoucherNo As Integer = 2          ' Mã
    Private Const COL_RecInformationName As Integer = 3 ' Diễn giải
    Private Const COL_VoucherDate As Integer = 4        ' Ngày lập
    Private Const COL_CreatorID As Integer = 5          ' Người lập
    Private Const COL_FromDate As Integer = 6           ' Ngày tuyển (từ)
    Private Const COL_ToDate As Integer = 7             ' Ngày tuyển (đến)
    Private Const COL_Note As Integer = 8               ' Ghi chú
    Private Const COL_BlockID As Integer = 9            ' Mã khối
    Private Const COL_BlockName As Integer = 10         ' Tên khối
    Private Const COL_DepartmentID As Integer = 11      ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 12    ' Tên phòng ban
    Private Const COL_TeamID As Integer = 13            ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 14          ' Tên tổ nhóm
    Private Const COL_RecPositionID As Integer = 15     ' Mã vị trí
    Private Const COL_RecPositionName As Integer = 16   ' Tên vị trí
    Private Const COL_Quantity As Integer = 17          ' Số lượng
    Private Const COL_DateFrom As Integer = 18          ' Từ ngày
    Private Const COL_DateTo As Integer = 19            ' Đến ngày
    Private Const COL_NoteDetail As Integer = 20        ' Ghi chú
    Private Const COL_CreateDate As Integer = 21        ' CreateDate
    Private Const COL_CreateUserID As Integer = 22      ' CreateUserID
    Private Const COL_LastModifyDate As Integer = 23    ' LastModifyDate
    Private Const COL_LastModifyUserID As Integer = 24  ' LastModifyUserID
#End Region

#Region "UserControl D09U1111 (gồm 4 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới KHÔNG có nút: gồm 4 bước
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
    Private arrDetail As New ArrayList 'Mảng Detail
    '*****************************************
    Dim bLoadD25F2070 As Boolean = False 'Ktra xem co goi D25F2070 k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
#End Region

    Dim iColumns() As Integer = {COL_Quantity}
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

    Private Sub D25F3070_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
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

        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowColumns_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
        '***************************************
    End Sub

    Private Sub D25F3070_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        SetShortcutPopupMenu(C1CommandHolder)
        SetBackColorObligatory()
        Loadlanguage()
        ResetColorGrid(tdbg, SPLIT0, SPLIT0)
        ResetSplitDividerSize(tdbg)
        LoadTDBCombo()
        LoadDefault()
        '*****************************
        'InitiateD09U1111()
        CallD09U1111_ChkDetail(True)
        'Phai thiet ke Split Chi tiet luc dau de Add vao mang Detal cua nut Hien thi cho dung
        'Sau do Remove di split Chi tiet de khi chon Hien thi chi tiet moi add vao
        If tdbg.Splits.Count >= 2 Then
            tdbg.RemoveHorizontalSplit(SPLIT1)
            tdbg.Col = COL_VoucherNo
        End If
        '*****************************
InputDateCustomFormat(c1dateVoucherDateFrom,c1dateVoucherDateTo,c1date1)
        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_thong_bao_tuyen_dung_-_D25F3070") & UnicodeCaption(gbUnicode) 'Truy vÊn th¤ng bÀo tuyÓn dóng - D25F3070
        '================================================================ 
        lblteVoucherDateFrom.Text = rl3("Ngay_lap") 'Ngày lập
        lblRecInformationID.Text = rl3("Thong_bao_TD") 'Thông báo TD
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        '================================================================ 
        btnFilter.Text = rl3("_Loc") '&Lọc
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        '================================================================ 
        chkIsDisplayDetail.Text = rl3("Hien_thi_chi_tiet") 'Hiển thị chi tiết
        '================================================================ 
        tdbcRecInformationID.Columns("VoucherNo").Caption = rl3("Ma") 'Mã
        tdbcRecInformationID.Columns("RecInformationName").Caption = rl3("Ten") 'Tên
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("VoucherNo").Caption = rl3("Ma") 'Mã
        tdbg.Columns("RecInformationName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_lap") 'Ngày lập
        tdbg.Columns("CreatorID").Caption = rl3("Nguoi_lap") 'Người lập
        tdbg.Columns("FromDate").Caption = rl3("Ngay_tuyen_(tu)") 'Ngày tuyển (từ)
        tdbg.Columns("ToDate").Caption = rl3("Ngay_tuyen_(den)") 'Ngày tuyển (đến)
        tdbg.Columns("Note").Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns("BlockID").Caption = rl3("Ma_khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionID").Caption = rl3("Ma_vi_tri") 'Mã vị trí
        tdbg.Columns("RecPositionName").Caption = rl3("Ten_vi_tri") 'Tên vị trí
        tdbg.Columns("Quantity").Caption = rl3("So_luong") 'Số lượng
        tdbg.Columns("DateFrom").Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns("NoteDetail").Caption = rl3("Ghi_chu") 'Ghi chú
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
        tdbcRecInformationID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcBlockID
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)

        'Load tdbcRecPositionID
        LoadDataSource(tdbcRecPositionID, ReturnTableDutyIDRec(, gbUnicode), gbUnicode)
    End Sub

    Private Sub LoadtdbcRecInformationID()
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        Dim sSQL As String = ""

        'Load tdbcRecInformationID
        sSQL = "SELECT  '%' AS RecInformationID, '%' AS VoucherNo, " & sLanguage & " AS RecInformationName, 0 as DisplayOrder" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT	Distinct RecInformationID, VoucherNo, RecInformationName" & sUnicode & " As RecInformationName, 1 as DisplayOrder" & vbCrLf
        sSQL &= "FROM D25T2070  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE DivisionID=" & SQLString(gsDivisionID) & " and VoucherDate BETWEEN " & SQLDateSave(c1dateVoucherDateFrom.Text) & " AND " & SQLDateSave(c1dateVoucherDateTo.Text) & vbCrLf
        sSQL &= "ORDER BY  DisplayOrder, RecInformationName"
        LoadDataSource(tdbcRecInformationID, sSQL, gbUnicode)
        tdbcRecInformationID.SelectedIndex = 0
    End Sub

    Private Sub LoadDefault()
        bIsUseBlock = VisibleBlock()
        tdbcBlockID.SelectedIndex = 0
        tdbcRecPositionID.SelectedIndex = 0
        c1dateVoucherDateFrom.Value = Now
        c1dateVoucherDateTo.Value = Now
        tdbcRecInformationID.SelectedIndex = 0

        'tdbg.Columns(COL_VoucherDate).Editor = c1date1
        'tdbg.Columns(COL_FromDate).Editor = c1date1
        'tdbg.Columns(COL_ToDate).Editor = c1date1
        'tdbg.Columns(COL_DateFrom).Editor = c1date1
        'tdbg.Columns(COL_DateTo).Editor = c1date1
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate, COL_FromDate, COL_ToDate, COL_DateFrom, COL_DateTo)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    End Sub

    Private Function VisibleBlock() As Boolean
        Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
            ReadOnlyControl(tdbcBlockID)
            Return False
        End If
        Return True
    End Function

    'Private Sub InitiateD09U1111()
    '    '*****************************************
    '    'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
    '    'Đặt các dòng code sau vào cuối FormLoad
    '    Dim arrColObligatory() As Integer = {}
    '    Dim Arr As New ArrayList
    '    AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory)
    '    AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory)
    '    'Dim dtCaptionCols As DataTable
    '    dtCaptionCols = CreateTableForExcel(tdbg, Arr)
    '    usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name)
    '    '*****************************************
    'End Sub

    Private Sub CallD09U1111_ChkDetail(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {}
            'cac cot hien thi khi chua k Hien thi chi tiet
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)

            'cac cot hien thi khi Hien thi chi tiet
            AddColVisible(tdbg, SPLIT0, arrDetail, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrDetail, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable
        If chkIsDisplayDetail.Checked Then
            dtCaptionCols = CreateTableForExcel(tdbg, arrDetail)
            If usrOption IsNot Nothing Then usrOption.Dispose()
            usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "1", , bLoadFirst, , gbUnicode)
        Else
            dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
            If usrOption IsNot Nothing Then usrOption.Dispose()
            usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
        End If
    End Sub

    Private Sub chkIsDisplayDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsDisplayDetail.Click
        If chkIsDisplayDetail.Checked Then
            If tdbg.Splits.Count = 1 Then

                tdbg.InsertHorizontalSplit(SPLIT1)

                tdbg.Splits(SPLIT0).SplitSize = 347
                tdbg.Splits(SPLIT0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
                tdbg.Splits(SPLIT0).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                tdbg.Splits(SPLIT0).RecordSelectors = True

                tdbg.Splits(SPLIT1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                tdbg.Splits(SPLIT1).SplitSize = 1
                tdbg.Splits(SPLIT1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                tdbg.Splits(SPLIT1).RecordSelectors = False
                tdbg.Splits(SPLIT1).BorderStyle = Border3DStyle.Flat
                tdbg.Splits(SPLIT1).FilterBorderStyle = Border3DStyle.Raised
                '****************************************************
                For i As Integer = COL_TransID To COL_Note
                    tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = False
                Next

                For i As Integer = COL_BlockID To COL_NoteDetail
                    tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = True
                Next
                tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockID).Visible = bIsUseBlock
                tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockName).Visible = bIsUseBlock

                For i As Integer = COL_CreateDate To COL_CreateDate
                    tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = False
                Next

                For i As Integer = COL_VoucherNo To COL_Note
                    tdbg.Splits(SPLIT0).DisplayColumns(i).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Restricted
                Next
            End If
        Else
            For i As Integer = COL_VoucherNo To COL_Note
                tdbg.Splits(SPLIT0).DisplayColumns(i).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
            Next

            If tdbg.Splits.Count >= 2 Then
                tdbg.RemoveHorizontalSplit(SPLIT1)
                tdbg.Col = COL_VoucherNo
            End If

            tdbg.Splits(SPLIT0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
            tdbg.Splits(SPLIT0).SplitSize = 1
        End If
        tdbg.ExtendRightColumn = True

        If chkIsDisplayDetail.Checked Then
            tdbg.Splits(SPLIT0).SplitSize = 347
            tdbg.Splits(SPLIT0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
        End If

        '***************************************
        'InitiateD09U1111()
        usrOption.Hide()
        If bLoadD25F2070 = True Then
            bLoadD25F2070 = False
            arrMaster.Clear()
            arrDetail.Clear()
            CallD09U1111_ChkDetail(True)
        Else
            CallD09U1111_ChkDetail(False)
        End If
        '***************************************
        If bIsFilter = False Then Exit Sub

        btnFilter_Click(Nothing, Nothing)
    End Sub


#Region "Combo Events"

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

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecInformationID"

    Private Sub tdbcRecInformationID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecInformationID.LostFocus
        If tdbcRecInformationID.FindStringExact(tdbcRecInformationID.Text) = -1 Then tdbcRecInformationID.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecPositionID"

    Private Sub tdbcRecPositionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.LostFocus
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then tdbcRecPositionID.Text = ""
    End Sub

#End Region

    'Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyDown, tdbcDepartmentID.KeyDown, tdbcTeamID.KeyDown, tdbcRecPositionID.KeyDown, tdbcRecInformationID.KeyDown
    '    If gbUnicode Then Exit Sub
    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbc.AutoCompletion = False
    '        Case Else
    '            tdbc.AutoCompletion = True
    '    End Select
    'End Sub

    'Private Sub tdbcXX_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Leave, tdbcDepartmentID.Leave, tdbcTeamID.Leave, tdbcRecPositionID.Leave, tdbcRecInformationID.Leave
    '    If gbUnicode Then Exit Sub

    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    If tdbc.SelectedIndex <> -1 Then
    '        tdbc.Text = tdbc.Columns(tdbc.DisplayMember).Text
    '    End If

    'End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close, tdbcRecInformationID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated, tdbcRecInformationID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
#End Region

#Region "Menu Events"

    Private Sub mnuAdd_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub

        '************************
        If Not bLoadD25F2070 Then vcNewTemp = vcNew
        bLoadD25F2070 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Dim f As New D25F2070
        With f
            .RecInformationID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bSaved Then
                Dim sKey As String = f.RecInformationID
                LoadTDBGrid(True, False, sKey)
            End If
            .Dispose()
        End With

        'InitiateD09U1111()

    End Sub

    Private Sub mnuView_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub

        '************************
        If Not bLoadD25F2070 Then vcNewTemp = vcNew
        bLoadD25F2070 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Me.Cursor = Cursors.WaitCursor
        Dim f As New D25F2070
        With f
            .RecInformationID = tdbg.Columns(COL_RecInformationID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With

        'InitiateD09U1111()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub

        '************************
        If Not bLoadD25F2070 Then vcNewTemp = vcNew
        bLoadD25F2070 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Me.Cursor = Cursors.WaitCursor
        Dim f As New D25F2070
        With f
            .RecInformationID = tdbg.Columns(COL_RecInformationID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
            If .bSaved Then
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid(False, True)
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            End If
        End With

        'InitiateD09U1111()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub

        Dim sSQL As String
        Dim bResult As Boolean
        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            If chkIsDisplayDetail.Checked Then
                sSQL = SQLDeleteD25T2040()
            Else
                sSQL = SQLDeleteD25T2040() & vbCrLf
                sSQL &= SQLDeleteD25T2070()
            End If

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

    Private Sub mnuPrint_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub

        'Dim f As New D25M0340
        'With f
        '    .FormActive = enumD25E0340Form.D25F4070
        '    .ID01 = ReturnValueC1Combo(tdbcBlockID) 'BlockID
        '    .ID02 = ReturnValueC1Combo(tdbcDepartmentID) 'DepartmentID
        '    .ID03 = ReturnValueC1Combo(tdbcTeamID) 'TeamID
        '    .ID04 = ReturnValueC1Combo(tdbcRecPositionID) 'RecPositionID
        '    .ID05 = ReturnValueC1Combo(tdbcRecInformationID) 'RecInformationID
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "BlockID", ReturnValueC1Combo(tdbcBlockID))
        SetProperties(arrPro, "DepartmentID", ReturnValueC1Combo(tdbcDepartmentID))
        SetProperties(arrPro, "TeamID", ReturnValueC1Combo(tdbcTeamID))
        SetProperties(arrPro, "RecPositionID", ReturnValueC1Combo(tdbcRecPositionID))
        SetProperties(arrPro, "RecInformationID", ReturnValueC1Combo(tdbcRecInformationID))
        CallFormThread(Me, "D25D0340", "D25F4070", arrPro)
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

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
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property


    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        '*****************************************
        If usrOption IsNot Nothing And bLoadD25F2070 Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadD25F2070 = False
        End If
        '*****************************************
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, gdtCaptionExcel)
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, gdtCaptionExcel.DefaultView.ToTable), Me, SQLNumber(chkIsDisplayDetail.Checked), gbUnicode)
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
        FooterTotalGrid(tdbg, COL_RecInformationName)
        FooterSumNew(tdbg, iColumns)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    End Sub
#End Region


    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal FlagEdit As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD25P3070()
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
                dtGrid.DefaultView.Sort = "RecInformationID" 'Field của khóa chính
                tdbg.Bookmark = dtGrid.DefaultView.Find(sKeyID)
            End If

        End If

        FooterTotalGrid(tdbg, COL_RecInformationName)
        FooterSumNew(tdbg, iColumns)
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        If bLoadD25F2070 Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadD25F2070 = False
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
        If tdbcRecInformationID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Thong_bao_TD"))
            tdbcRecInformationID.Focus()
            Return False
        End If
        If tdbcBlockID.Text.Trim = "" And bIsUseBlock Then
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

        Return True
    End Function

    Private Sub c1dateVoucherDateFrom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateVoucherDateFrom.ValueChanged
        LoadtdbcRecInformationID()
    End Sub

    Private Sub c1dateVoucherDateTo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateVoucherDateTo.ValueChanged
        LoadtdbcRecInformationID()
    End Sub

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
        '    FooterTotalGrid(tdbg, COL_RecInformationName)
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
            Case COL_VoucherDate, COL_DateFrom, COL_DateTo, COL_FromDate, COL_ToDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_Quantity
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
    '# Title: SQLStoreD25P3070
    '# Created User: DUCTRONG
    '# Created Date: 25/06/2010 03:08:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3070() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P3070 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateFrom.Value) & COMMA 'VoucherDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateTo.Value) & COMMA 'VoucherDateTo, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecInformationID)) & COMMA 'RecInformationID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecPositionID, varchar[20], NOT NULL
        sSQL &= SQLString(chkIsDisplayDetail.Checked) & COMMA 'IsDisplayDetail, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2040
    '# Created User: DUCTRONG
    '# Created Date: 25/06/2010 03:12:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2040() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2040"
        sSQL &= " Where "

        If chkIsDisplayDetail.Checked Then
            sSQL &= "VoucherID = " & SQLString(tdbg.Columns(COL_RecInformationID).Text)
            sSQL &= " And TransID = " & SQLString(tdbg.Columns(COL_TransID).Text)
        Else
            sSQL &= "VoucherID = " & SQLString(tdbg.Columns(COL_RecInformationID).Text)
        End If
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2070
    '# Created User: DUCTRONG
    '# Created Date: 25/06/2010 03:13:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2070() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2070"
        sSQL &= " Where "
        sSQL &= "RecInformationID = " & SQLString(tdbg.Columns(COL_RecInformationID).Text)

        Return sSQL
    End Function


#End Region

End Class