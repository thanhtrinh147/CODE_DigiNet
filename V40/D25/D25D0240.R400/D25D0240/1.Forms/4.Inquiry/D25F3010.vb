Public Class D25F3010
	Dim dtCaptionCols As DataTable


#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0           ' TransID
    Private Const COL_RecruitmentFileID As Integer = 1 ' RecruitmentFileID
    Private Const COL_VoucherNo As Integer = 2         ' Mã
    Private Const COL_Description As Integer = 3       ' Diễn giải
    Private Const COL_VoucherDate As Integer = 4       ' Ngày lập
    Private Const COL_CreatorID As Integer = 5         ' Người lập
    Private Const COL_FromDate As Integer = 6          ' Ngày tuyển (từ)
    Private Const COL_ToDate As Integer = 7            ' Ngày tuyển (đến)
    Private Const COL_RFStatusID As Integer = 8        ' RFStatusID
    Private Const COL_RFStatusName As Integer = 9      ' Trạng thái
    Private Const COL_Note As Integer = 10             ' Ghi chú
    Private Const COL_CandidateID As Integer = 11      ' Mã ứng viên
    Private Const COL_CandidateName As Integer = 12    ' Tên ứng viên
    Private Const COL_BlockID As Integer = 13          ' Mã khối
    Private Const COL_BlockName As Integer = 14        ' Tên khối
    Private Const COL_DepartmentID As Integer = 15     ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 16   ' Tên phòng ban
    Private Const COL_TeamID As Integer = 17           ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 18         ' Tên tổ nhóm
    Private Const COL_RecPositionID As Integer = 19    ' Mã vị trí
    Private Const COL_RecPositionName As Integer = 20  ' Tên vị trí
    Private Const COL_ProjectID As Integer = 21        ' ProjectID
    Private Const COL_ProjectName As Integer = 22      ' Tên dự án
    Private Const COL_SexName As Integer = 23          ' Giới tính
    Private Const COL_Birthdate As Integer = 24        ' Ngày sinh
    Private Const COL_ReceivedDate As Integer = 25     ' Ngày nhận HS
    Private Const COL_ReceiverName As Integer = 26     ' Người nhận HS
    Private Const COL_ReceivedPlace As Integer = 27    ' Nơi nhận HS
    Private Const COL_DesiredSalary As Integer = 28    ' Lương yêu cầu
    Private Const COL_CurrencyID As Integer = 29       ' Loại tiền
    Private Const COL_RecSourceID As Integer = 30      ' RecSourceID
    Private Const COL_RecSourceName As Integer = 31    ' Nguồn tuyển dụng
    Private Const COL_SuggesterName As Integer = 32    ' Người giới thiệu
    Private Const COL_LastModifyUserID As Integer = 33 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 34   ' LastModifyDate
    Private Const COL_CreateUserID As Integer = 35     ' CreateUserID
    Private Const COL_CreateDate As Integer = 36       ' CreateDate
#End Region

    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
    Private arrDetail As New ArrayList 'Mảng Detail
    '*****************************************
    Dim bLoadD25F1040 As Boolean = False 'Ktra xem co goi D25F2070 k?
    Dim vcNewTemp(-1, -1) As VisibleColumn

    Dim dtGrid, dtTeamID, dtDepartmentID As New DataTable
    Dim bIsFilter As Boolean = False
    Dim bIsUseBlock As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeft, chkIsDisplayDetail)
        AnchorForControl(EnumAnchorStyles.TopRight, chkIsPendding, chkIsComplete, btnFilter)
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

        ResetColorGrid(tdbg, SPLIT0, SPLIT1)
        ResetSplitDividerSize(tdbg)

        InputDateInTrueDBGrid(tdbg, COL_FromDate, COL_ToDate, COL_VoucherDate, COL_Birthdate, COL_ReceivedDate)

        LoadTDBCombo()
        LoadDefault()
        VisibleBlock()
        ResetGrid()
        FooterTotalGrid(tdbg, COL_Description)

        SetShortcutPopupMenu(C1CommandHolder)

        InitiateD09U1111(True)
        If tdbg.Splits.Count >= 2 Then
            tdbg.RemoveHorizontalSplit(SPLIT1)
            tdbg.Col = COL_VoucherNo
        End If

        InputbyUnicode(Me, gbUnicode)
        InputDateCustomFormat(c1dateTo, c1dateFrom)
        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkIsDisplayDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsDisplayDetail.Click
        If chkIsDisplayDetail.Checked Then
            If tdbg.Splits.Count = 1 Then

                tdbg.InsertHorizontalSplit(SPLIT1)

                tdbg.Splits(SPLIT0).SplitSize = 6
                tdbg.Splits(SPLIT0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                tdbg.Splits(SPLIT0).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                tdbg.Splits(SPLIT0).RecordSelectors = True

                tdbg.Splits(SPLIT1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                tdbg.Splits(SPLIT1).SplitSize = 11
                tdbg.Splits(SPLIT1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                tdbg.Splits(SPLIT1).RecordSelectors = False
                tdbg.Splits(SPLIT1).BorderStyle = Border3DStyle.Flat
                tdbg.Splits(SPLIT1).FilterBorderStyle = Border3DStyle.Raised
                '****************************************************
                For i As Integer = COL_TransID To COL_Note
                    tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = False
                Next

                For i As Integer = COL_CandidateID To COL_SuggesterName
                    tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = True
                Next

                tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockID).Visible = bIsUseBlock
                tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockName).Visible = bIsUseBlock

                tdbg.Splits(SPLIT1).DisplayColumns(COL_RecSourceID).Visible = False
                For i As Integer = COL_CreateDate To COL_CreateDate
                    tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = False
                Next

                For i As Integer = COL_VoucherNo To COL_Note
                    tdbg.Splits(SPLIT0).DisplayColumns(i).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Restricted
                Next
                tdbg.Splits(0).DisplayColumns(COL_ProjectID).Visible = False
                tdbg.Splits(1).DisplayColumns(COL_ProjectID).Visible = False
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

        '***************************************
        usrOption.Hide()
        If bLoadD25F1040 = True Then
            bLoadD25F1040 = False
            arrMaster.Clear()
            arrDetail.Clear()
            InitiateD09U1111(True)
        Else
            InitiateD09U1111(False)
        End If
        '***************************************

        If bIsFilter = False Then Exit Sub

        btnFilter_Click(Nothing, Nothing)
    End Sub

    'Dim dtCaptionCols As DataTable
    Private Sub InitiateD09U1111(ByVal bLoadFirst As Boolean)
        '*****************************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'Đặt các dòng code sau vào cuối FormLoad

        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {}
            'cac cot hien thi khi chua k Hien thi chi tiet
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)

            'cac cot hien thi khi Hien thi chi tiet
            AddColVisible(tdbg, SPLIT0, arrDetail, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrDetail, arrColObligatory, , , gbUnicode)
        End If


        If chkIsDisplayDetail.Checked Then
            dtCaptionCols = CreateTableForExcel(tdbg, arrDetail)
            If usrOption IsNot Nothing Then usrOption.Dispose()
            usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "1", , bLoadFirst, , gbUnicode)
        Else
            dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
            If usrOption IsNot Nothing Then usrOption.Dispose()
            usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
        End If

        '*****************************************
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ke_hoach_tuyen_dungF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'rl3("Truy_van_dot_tuyen_dung_-_D25F3010") & UnicodeCaption(gbUnicode) 'Truy vÊn ¢ít tuyÓn dóng - D25F3010
        '================================================================ 
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
        chkIsDisplayDetail.Text = rL3("Hien_thi_chi_tiet") 'Hiển thị chi tiết
        chkIsPendding.Text = rL3("Dang_thuc_hien") 'Đang thực hiện
        chkIsComplete.Text = rL3("Dong_U") 'Đóng
        '================================================================ 
        optDate.Text = rl3("Ngay_lap") 'Ngày lập
        optPeriod.Text = rl3("Ky") 'Kỳ
        '================================================================ 
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcPeriodTo.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ
        '================================================================ 
        tdbg.Columns("VoucherNo").Caption = rl3("Ma") 'Mã
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_lap") 'Ngày lập
        tdbg.Columns("CreatorID").Caption = rl3("Nguoi_lap") 'Người lập
        tdbg.Columns("FromDate").Caption = rl3("Ngay_tuyen_(tu)") 'Ngày tuyển (từ)
        tdbg.Columns("ToDate").Caption = rl3("Ngay_tuyen_(den)") 'Ngày tuyển (đến)
        tdbg.Columns(COL_RFStatusName).Caption = rl3("Trang_thai") 'Trạng thái
        tdbg.Columns("Note").Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns("CandidateID").Caption = rl3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns("CandidateName").Caption = rl3("Ten_ung_vien") 'Tên ứng viên
        tdbg.Columns("BlockID").Caption = rl3("Ma_khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionID").Caption = rl3("Ma_vi_tri") 'Mã vị trí
        tdbg.Columns("RecPositionName").Caption = rl3("Ten_vi_tri") 'Tên vị trí
        tdbg.Columns(COL_ProjectName).Caption = rl3("Cong_trinh") 'Tên dự án
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
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuPrint.Text = rl3("_In") '&In
        mnuOpen.Text = rl3("Mo_U") 'Mở
        mnuClose.Text = rl3("Do_ng") 'Đó&ng
    End Sub

    Private Sub SetBackColorObligatory()
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
        'sSQL = "Select '%' as RecPositionID, " & sLanguage & " As RecPositionName" & vbCrLf
        'sSQL &= "Union" & vbCrLf
        'sSQL &= "SELECT	RecPositionID, RecPositionName" & sUnicode & " As RecPositionName FROM D25T1020 WHERE Disabled = 0 ORDER BY	RecPositionID"
        LoadDataSource(tdbcRecPositionID, ReturnTableDutyIDRec(, gbUnicode), gbUnicode)

        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, "D09")
    End Sub

    Private Sub LoadDefault()
        bIsUseBlock = VisibleBlock()
        tdbcPeriodFrom.Text = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcPeriodTo.Text = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcBlockID.SelectedIndex = 0
        tdbcRecPositionID.SelectedIndex = 0
        c1dateFrom.Value = Now
        c1dateTo.Value = Now
    End Sub

    Private Function VisibleBlock() As Boolean
        If D25Systems.IsUseBlock = False Then
            ReadOnlyControl(tdbcBlockID)
            Return False
        End If
        Return True
    End Function

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal FlagEdit As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD25P3011()
        dtGrid = ReturnDataTable(sSQL)
        If dtGrid.Rows.Count < 1 Then 'Không có dữ liệu
            gbEnabledUseFind = False
            LoadDataSource(tdbg, dtGrid, gbUnicode)
            ResetGrid()
        Else 'Có dữ liệu
            If Not FlagEdit Or Not gbEnabledUseFind Then 'Không phải nhấn Sửa (Xóa) hay Chưa nhấn tìm kiếm
                LoadDataSource(tdbg, dtGrid, gbUnicode)
                ResetGrid()
            Else 'Nhấn Sửa (Xóa) hay đã nhấn Tìm kiếm
                ReLoadTDBGrid()
            End If
            If FlagAdd Then
                dtGrid.DefaultView.Sort = "RecruitmentFileID" 'Field của khóa chính
                tdbg.Bookmark = dtGrid.DefaultView.Find(sKeyID)
            End If
        End If
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_Description)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    End Sub

    Private Sub CheckMenuOther()
        mnuOpen.Enabled = mnuEdit.Enabled AndAlso tdbg.Columns(COL_RFStatusID).Text <> "3"
        mnuClose.Enabled = mnuEdit.Enabled AndAlso tdbg.Columns(COL_RFStatusID).Text <> "4"
    End Sub

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        CheckMenuOther()
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        If bLoadD25F1040 Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadD25F1040 = False
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

#Region "Combo Events"

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
#End Region

#Region "Menu Events"

    Private Sub mnuAdd_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub

        '************************
        If Not bLoadD25F1040 Then vcNewTemp = vcNew
        bLoadD25F1040 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Dim f As New D25F1040
        With f
            .RecruitmentFileID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .SavedOK Then
                Dim sKey As String = f.RecruitmentFileID
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
        If Not bLoadD25F1040 Then vcNewTemp = vcNew
        bLoadD25F1040 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Me.Cursor = Cursors.WaitCursor
        Dim f As New D25F1040
        With f
            .RecruitmentFileID = tdbg.Columns(COL_RecruitmentFileID).Text
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
        If Not bLoadD25F1040 Then vcNewTemp = vcNew
        bLoadD25F1040 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        If Not CheckStore(SQLStoreD25P5555()) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim f As New D25F1040
        With f
            .RecruitmentFileID = tdbg.Columns(COL_RecruitmentFileID).Text
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

        'InitiateD09U1111()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub

        If Not CheckStore(SQLStoreD25P5555()) Then Exit Sub

        Dim sSQL As String
        Dim bResult As Boolean
        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            ' If Not AllowDelete() Then Exit Sub
            If chkIsDisplayDetail.Checked Then
                sSQL = SQLDeleteD25T1042()
            Else
                sSQL = SQLDeleteD25T2040() & vbCrLf
                sSQL = SQLDeleteD25T1042()
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

    Private Sub mnuSysInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuOpen.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Dim sSQL As String = SQLUpdateD25T1042(3).ToString
        ExecuteSQLNoTransaction(sSQL)
        Dim Bookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
        LoadTDBGrid(False, True)
        If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
    End Sub

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuClose.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Dim sSQL As String = SQLUpdateD25T1042(4).ToString
        ExecuteSQLNoTransaction(sSQL)
        Dim Bookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
        LoadTDBGrid(False, True)
        If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
    End Sub
#End Region

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

        '*****************************************
        If usrOption IsNot Nothing And bLoadD25F1040 Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadD25F1040 = False
        End If
        '*****************************************
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, dtCaptionCols)
        ShowFindDialogClient(Finder, dtCaptionCols, Me, SQLNumber(chkIsDisplayDetail.Checked), gbUnicode)
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
        ResetGrid()
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

        '    ResetGrid()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & " - " & ex.Source)
        'End Try

    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_DesiredSalary
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
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

#End Region

#Region "SQL, Store"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3011
    '# Created User: DUCTRONG
    '# Created Date: 10/06/2010 02:28:18
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3011() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P3011 "
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
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecPositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(optPeriod.Checked) & COMMA 'IsPeriod, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsDisplayDetail.Checked) & COMMA 'IsDisplayDetail, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsPendding.Checked) & COMMA 'IsPendding, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsComplete.Checked) 'IsComplete, tinyint, NOT NULL
        sSQL &= COMMA & SQLString(gsLanguage)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5555
    '# Created User: DUCTRONG
    '# Created Date: 10/06/2010 02:47:53
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5555() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_RecruitmentFileID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_CandidateID).Text) & COMMA 'key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsDisplayDetail.Checked) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T1042
    '# Created User: DUCTRONG
    '# Created Date: 11/06/2010 04:03:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T1042() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T1042"
        sSQL &= " Where "
        If chkIsDisplayDetail.Checked Then
            sSQL &= "RecruitmentFileID = " & SQLString(tdbg.Columns(COL_RecruitmentFileID).Text)
            sSQL &= " And CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text)
        Else
            sSQL &= "RecruitmentFileID = " & SQLString(tdbg.Columns(COL_RecruitmentFileID).Text)
        End If

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2040
    '# Created User: DUCTRONG
    '# Created Date: 11/06/2010 04:04:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2040() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2040"
        sSQL &= " Where "
        sSQL &= "VoucherID = " & SQLString(tdbg.Columns(COL_RecruitmentFileID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T1042
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 03/09/2013 09:52:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T1042(ByVal iRFStatusID As Byte) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T1042 Set ")
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("RFStatusID = " & SQLNumber(iRFStatusID)) 'tinyint, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("RecruitmentFileID  = " & SQLString(tdbg.Columns(COL_RecruitmentFileID).Text))
        Return sSQL
    End Function

#End Region


    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        ExecuteSQL(SQLDeleteD09T6666() & vbCrLf & SQLInsertD09T6666s().ToString)

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormText", rL3("Ke_hoach_tuyen_dungF") & " - D25F4060")
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
End Class