Public Class D25F3020
	Dim dtCaptionCols As DataTable

#Region "UserControl D09U1111 (gồm 4 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới KHÔNG có nút: gồm 4 bước
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
    Private arrDetail As New ArrayList 'Mảng Detail

    '*****************************************
    Dim bLoadFormChild As Boolean = False 'Ktra xem co goi form con k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
#End Region

#Region "Const of tdbg - Total of Columns: 53"
    Private Const COL_InterviewFileID As Integer = 0         ' InterviewFileID
    Private Const COL_VoucherNo As Integer = 1               ' Mã
    Private Const COL_Description As Integer = 2             ' Diễn giải
    Private Const COL_VoucherDate As Integer = 3             ' Ngày lập
    Private Const COL_CreatorID As Integer = 4               ' Người lập
    Private Const COL_FromDate As Integer = 5                ' Ngày tuyển (từ)
    Private Const COL_ToDate As Integer = 6                  ' Ngày tuyển (đến)
    Private Const COL_InterviewLevel As Integer = 7          ' Vòng PV
    Private Const COL_RecruitPhaseNo As Integer = 8          ' Đợt
    Private Const COL_InterviewPlace As Integer = 9          ' Địa điểm
    Private Const COL_GroupInterviewer As Integer = 10       ' Nhóm phỏng vấn
    Private Const COL_StatusID As Integer = 11               ' StatusID
    Private Const COL_StatusName As Integer = 12             ' Trạng thái
    Private Const COL_CandidateID As Integer = 13            ' Mã ứng viên
    Private Const COL_CandidateName As Integer = 14          ' Tên ứng viên
    Private Const COL_DivisionID As Integer = 15             ' Mã đơn vị
    Private Const COL_DivisionName As Integer = 16           ' Tên đơn vị
    Private Const COL_BlockID As Integer = 17                ' Mã khối
    Private Const COL_BlockName As Integer = 18              ' Tên khối
    Private Const COL_DepartmentID As Integer = 19           ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 20         ' Tên phòng ban
    Private Const COL_TeamID As Integer = 21                 ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 22               ' Tên tổ nhóm
    Private Const COL_RecPositionID As Integer = 23          ' Mã vị trí
    Private Const COL_RecPositionName As Integer = 24        ' Tên vị trí
    Private Const COL_ProjectID As Integer = 25              ' ProjectID
    Private Const COL_ProjectName As Integer = 26            ' Tên dự án
    Private Const COL_SexName As Integer = 27                ' Giới tính
    Private Const COL_BirthDate As Integer = 28              ' Ngày sinh
    Private Const COL_ReceivedDate As Integer = 29           ' Ngày nhận HS
    Private Const COL_ReceiverName As Integer = 30           ' Người nhận HS
    Private Const COL_ReceivedPlace As Integer = 31          ' Nơi nhận HS
    Private Const COL_DesiredSalary As Integer = 32          ' Lương yêu cầu
    Private Const COL_CurrencyID As Integer = 33             ' Loại tiền
    Private Const COL_RecSourceID As Integer = 34            ' RecSourceID
    Private Const COL_RecsourceName As Integer = 35          ' Nguồn tuyển dụng
    Private Const COL_SuggesterName As Integer = 36          ' Người giới thiệu
    Private Const COL_InterviewLevels As Integer = 37        ' Vòng PV
    Private Const COL_IntDate As Integer = 38                ' Ngày PV
    Private Const COL_IntTime As Integer = 39                ' Giờ PV
    Private Const COL_Interviewer As Integer = 40            ' Người PV
    Private Const COL_InterviewDetailPlace As Integer = 41   ' InterviewDetailPlace
    Private Const COL_GroupInterviewerDetail As Integer = 42 ' GroupInterviewerDetail
    Private Const COL_RecPosition As Integer = 43            ' Vị trí tuyển dụng
    Private Const COL_Content As Integer = 44                ' Nội dung PV
    Private Const COL_Result As Integer = 45                 ' Đánh giá
    Private Const COL_IntStatusID As Integer = 46            ' IntStatusID
    Private Const COL_InStatusName As Integer = 47           ' Kết quả
    Private Const COL_CreateUserID As Integer = 48           ' CreateUserID
    Private Const COL_CreateDate As Integer = 49             ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 50       ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 51         ' LastModifyDate
    Private Const COL_InterviewLevelID As Integer = 52       ' InterviewLevelID
#End Region

    '*****************************************
    Private bIsFilter As Boolean = False
    Dim bIsUseBlock As Boolean = False
    Private dtGrid As DataTable
    Private _formIDPermission As String = "D25F3020"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

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

    Private Sub D25F3020_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
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

    Private Sub D25F3020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        SetShortcutPopupMenu(C1CommandHolder1)
        SetBackColorObligatory()
        Loadlanguage()

        ResetColorGrid(tdbg, SPLIT0, SPLIT0)
        ResetSplitDividerSize(tdbg)
        '********************
        LoadDefault()
        bIsUseBlock = VisibleBlock()
        '********************
        FooterTotalGrid(tdbg, COL_Description)
        CheckMenu(Me.Name, C1CommandHolder1, tdbg.RowCount, gbEnabledUseFind, True)
        CheckMenuOther()

        '********************
        chkIsDisplayDetail_Click(Nothing, Nothing)
        '********************
        LoadCboDivisionIDD09(tdbcDivisionID, "D09", True, gbUnicode)
        tdbcDivisionID.SelectedIndex = 0
        '********************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtCandidateID, txtCandidateID.MaxLength)
        '********************
        InputDateCustomFormat(c1dateVoucherDateTo, c1dateVoucherFromDate)
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate, COL_FromDate, COL_ToDate, COL_BirthDate, COL_ReceivedDate, COL_IntDate)

        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub
    'Dim dtCaptionCols As DataTable
    Private Sub InitiateD09U1111()
        '*****************************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'Đặt các dòng code sau vào cuối FormLoad
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT2, Arr, arrColObligatory, , , gbUnicode)

        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, , , , , gbUnicode)
        '*****************************************

        If chkIsDisplayDetail.Checked Then
            tdbg.Splits(SPLIT0).SplitSize = 440
        End If
    End Sub

    Private Sub chkIsDisplayDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsDisplayDetail.Click
        If chkIsDisplayDetail.Checked Then
            If tdbg.Splits.Count = 1 Then
                tdbg.InsertHorizontalSplit(1)

                tdbg.Splits(SPLIT0).SplitSize = 440
                tdbg.Splits(SPLIT0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
                tdbg.Splits(SPLIT0).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                tdbg.Splits(SPLIT0).RecordSelectors = True

                tdbg.Splits(SPLIT1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                tdbg.Splits(SPLIT1).SplitSize = 1
                tdbg.Splits(SPLIT1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                tdbg.Splits(SPLIT1).RecordSelectors = False
                tdbg.Splits(SPLIT1).BorderStyle = Border3DStyle.Flat

                For i As Integer = COL_VoucherNo To COL_StatusName
                    tdbg.Splits(SPLIT0).DisplayColumns(i).Visible = False
                    tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = False
                Next

                tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Visible = bIsUseBlock
                tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Visible = bIsUseBlock

                For i As Integer = COL_CandidateID To COL_SuggesterName
                    tdbg.Splits(SPLIT0).DisplayColumns(i).Visible = True
                    tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = False
                Next

                For i As Integer = COL_InterviewLevels To COL_InStatusName
                    tdbg.Splits(SPLIT0).DisplayColumns(i).Visible = False
                    tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = True
                Next

                For i As Integer = COL_InterviewFileID To COL_LastModifyDate
                    Select Case i
                        Case COL_InterviewFileID, COL_StatusID, COL_RecSourceID, COL_IntStatusID, COL_CreateUserID, COL_CreateDate, COL_LastModifyDate, COL_LastModifyUserID, COL_Content, COL_Result, COL_InStatusName
                            tdbg.Splits(SPLIT0).DisplayColumns(i).Visible = False
                            tdbg.Splits(SPLIT1).DisplayColumns(i).Visible = False
                    End Select
                Next

                For i As Integer = COL_VoucherNo To COL_StatusName
                    tdbg.Splits(SPLIT0).DisplayColumns(i).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Restricted
                Next
                tdbg.Splits(0).DisplayColumns(COL_ProjectID).Visible = False
                tdbg.Splits(1).DisplayColumns(COL_ProjectID).Visible = False
            End If
        Else
            For i As Integer = COL_CandidateID To COL_InStatusName
                tdbg.Splits(SPLIT0).DisplayColumns(i).Visible = False
            Next

            For i As Integer = COL_InterviewFileID To COL_LastModifyDate
                Select Case i
                    Case COL_InterviewFileID, COL_StatusID, COL_RecSourceID, COL_IntStatusID, COL_CreateUserID, COL_CreateDate, COL_LastModifyDate, COL_LastModifyUserID
                        tdbg.Splits(SPLIT0).DisplayColumns(i).Visible = False
                End Select
            Next

            For i As Integer = COL_VoucherNo To COL_StatusName
                tdbg.Splits(SPLIT0).DisplayColumns(i).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
            Next

            If tdbg.Splits.Count >= 2 Then
                tdbg.RemoveHorizontalSplit(SPLIT1)
                tdbg.Col = COL_VoucherNo

                tdbg.Splits(SPLIT0).SplitSize = 1
                tdbg.Splits(SPLIT0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                tdbg.Splits(SPLIT0).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                tdbg.Splits(SPLIT0).RecordSelectors = True

                For i As Integer = COL_VoucherNo To COL_StatusName
                    tdbg.Splits(SPLIT0).DisplayColumns(i).Visible = True
                Next

                For i As Integer = COL_CandidateID To COL_LastModifyDate
                    tdbg.Splits(SPLIT0).DisplayColumns(i).Visible = False
                Next
                tdbg.Splits(SPLIT0).DisplayColumns(COL_StatusID).Visible = False
            End If

            tdbg.Splits(SPLIT0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
            tdbg.Splits(SPLIT0).SplitSize = 1
        End If

        tdbg.ExtendRightColumn = True
        ResetSplitDividerSize(tdbg)
        ResetColorGrid(tdbg, SPLIT0, tdbg.Splits.Count - 1)

        For i As Integer = 0 To tdbg.Splits.Count - 1
            tdbg.Splits(i).FilterBorderStyle = Border3DStyle.Raised
        Next

        '*******************************
        'Chuẩn hóa D09U1111 B6: Gọi lại UserControl
        InitiateD09U1111()
        '*******************************

        If bIsFilter = False Then Exit Sub

        btnFilter_Click(Nothing, Nothing)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_lich_phong_van_-_D25F3020") & UnicodeCaption(gbUnicode) 'Truy vÊn kÕt qu¶ phàng vÊn - D25F3020
        '================================================================ 
        lblteVoucherFromDate.Text = rl3("Ngay_lap") 'Ngày lập
        lblCandidateID.Text = rl3("Ma_ung_vien") 'Mã ứng viên
        lblDivisionID.Text = rL3("Don_vi") 'Đơn vị
        lblCandidateName.Text = rL3("Ten_ung_vien") 'Tên ứng viên
        '================================================================ 
        btnFilter.Text = rL3("Loc") & " (F5)" '&Lọc
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        '================================================================ 
        chkIsComplete.Text = rl3("Dong_U") 'Đóng
        chkIsPedding.Text = rl3("Dang_thuc_hien") 'Đang thực hiện
        chkIsDisplayDetail.Text = rl3("Hien_thi_chi_tiet") 'Hiển thị chi tiết
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_VoucherNo).Caption = rL3("Ma") 'Mã
        tdbg.Columns(COL_Description).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_VoucherDate).Caption = rL3("Ngay_lap") 'Ngày lập
        tdbg.Columns(COL_CreatorID).Caption = rL3("Nguoi_lap") 'Người lập
        tdbg.Columns(COL_FromDate).Caption = rL3("Ngay_tuyen_(tu)") 'Ngày tuyển (từ)
        tdbg.Columns(COL_ToDate).Caption = rL3("Ngay_tuyen_(den)") 'Ngày tuyển (đến)
        tdbg.Columns(COL_InterviewLevel).Caption = rL3("Vong_PV") 'Vòng PV
        tdbg.Columns(COL_RecruitPhaseNo).Caption = rL3("Dot") 'Đợt
        tdbg.Columns(COL_InterviewPlace).Caption = rL3("Dia_diem") 'Địa điểm
        tdbg.Columns(COL_GroupInterviewer).Caption = rL3("Nhom_phong_van") 'Nhóm phỏng vấn
        tdbg.Columns(COL_StatusName).Caption = rL3("Trang_thai") 'Trạng thái
        tdbg.Columns(COL_CandidateID).Caption = rL3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns(COL_CandidateName).Caption = rL3("Ten_ung_vien") 'Tên ứng viên
        tdbg.Columns(COL_DivisionID).Caption = rL3("Ma_don_vi") 'Mã đơn vị
        tdbg.Columns(COL_DivisionName).Caption = rL3("Ten_don_vi") 'Tên đơn vị
        tdbg.Columns(COL_BlockID).Caption = rL3("Ma_khoi") 'Mã khối
        tdbg.Columns(COL_BlockName).Caption = rL3("Ten_khoi") 'Tên khối
        tdbg.Columns(COL_DepartmentID).Caption = rL3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rL3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns(COL_TeamName).Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_RecPositionID).Caption = rL3("Ma_vi_tri") 'Mã vị trí
        tdbg.Columns(COL_RecPositionName).Caption = rL3("Ten_vi_tri") 'Tên vị trí
        tdbg.Columns(COL_ProjectName).Caption = rL3("Ten_cong_trinh") 'Tên dự án
        tdbg.Columns(COL_SexName).Caption = rL3("Gioi_tinh") 'Giới tính
        tdbg.Columns(COL_BirthDate).Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns(COL_ReceivedDate).Caption = rL3("Ngay_nhan_HS") 'Ngày nhận HS
        tdbg.Columns(COL_ReceiverName).Caption = rL3("Nguoi_nhan_HS") 'Người nhận HS
        tdbg.Columns(COL_ReceivedPlace).Caption = rL3("Noi_nhan_HS") 'Nơi nhận HS
        tdbg.Columns(COL_DesiredSalary).Caption = rL3("Luong_yeu_cau") 'Lương yêu cầu
        tdbg.Columns(COL_CurrencyID).Caption = rL3("Loai_tien") 'Loại tiền
        tdbg.Columns(COL_RecsourceName).Caption = rL3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        tdbg.Columns(COL_SuggesterName).Caption = rL3("Nguoi_gioi_thieu") 'Người giới thiệu
        tdbg.Columns(COL_InterviewLevels).Caption = rL3("Vong_PV") 'Vòng PV
        tdbg.Columns(COL_IntDate).Caption = rL3("Ngay_PV") 'Ngày PV
        tdbg.Columns(COL_IntTime).Caption = rL3("Gio_PV") 'Giờ PV
        tdbg.Columns(COL_Interviewer).Caption = rL3("Nguoi_PV") 'Người PV
        tdbg.Columns(COL_InterviewDetailPlace).Caption = rL3("Dia_diem") 'Địa điểm
        tdbg.Columns(COL_GroupInterviewerDetail).Caption = rL3("Nhom_phong_van") 'Nhóm phỏng vấn
        tdbg.Columns(COL_RecPosition).Caption = rL3("Vi_tri_tuyen_dung") 'Vị trí tuyển dụng
        tdbg.Columns(COL_Content).Caption = rL3("Noi_dung_PV") 'Nội dung PV
        tdbg.Columns(COL_Result).Caption = rL3("Danh_gia") 'Đánh giá
        tdbg.Columns(COL_InStatusName).Caption = rL3("Ket_qua") 'Kết quả
        tdbg.Columns(COL_InterviewPlace).Caption = rL3("Dia_diem")
        '================================================================ 
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuPrint.Text = rl3("_In") '&In
        mnuPeddingLink.Text = rl3("D_ang_thuc_hien") 'Đ&ang thực hiện
        mnuCompleteLink.Text = rl3("Do_ng") 'Đó&ng
        mnuExportToExcel.Text = rL3("Xuat__Excel")
        mnuCreate.Text = rL3("Lap_lich_phong_van_tiep_theo") 'Lập lịch phỏng vấn tiếp theo
    End Sub

    Private Sub SetBackColorObligatory()
        c1dateVoucherFromDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadDefault()
        c1dateVoucherFromDate.Value = Now
        c1dateVoucherDateTo.Value = Now
    End Sub

    Private Function VisibleBlock() As Boolean
        If D25Systems.IsUseBlock = False Then
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockName).Visible = False
            Return False
        End If
        Return True
    End Function

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal FlagEdit As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD25P3020()
        dtGrid = ReturnDataTable(sSQL)
        If dtGrid.Rows.Count < 1 Then 'Không có dữ liệu
            gbEnabledUseFind = False
            LoadDataSource(tdbg, dtGrid, gbUnicode)
            CheckMenu(Me.Name, C1CommandHolder1, tdbg.RowCount, gbEnabledUseFind, True)
        Else 'Có dữ liệu
            If Not FlagEdit Or Not gbEnabledUseFind Then 'Không phải nhấn Sửa (Xóa) hay Chưa nhấn tìm kiếm
                LoadDataSource(tdbg, dtGrid, gbUnicode)
                CheckMenu(Me.Name, C1CommandHolder1, tdbg.RowCount, gbEnabledUseFind, True)
            Else 'Nhấn Sửa (Xóa) hay đã nhấn Tìm kiếm
                ReLoadTDBGrid()
            End If
            If FlagAdd Then
                dtGrid.DefaultView.Sort = "InterviewFileID" 'Field của khóa chính
                tdbg.Bookmark = dtGrid.DefaultView.Find(sKeyID)
            End If

        End If

        CheckMenuOther()
        FooterTotalGrid(tdbg, COL_Description)
    End Sub

    Private Sub CheckMenuOther()
        EnablemnuCreate()
        mnuHold.Enabled = tdbg.RowCount > 0 And chkIsDisplayDetail.Checked = False
        mnuPedding.Enabled = tdbg.RowCount > 0 And chkIsDisplayDetail.Checked = False
        mnuComplete.Enabled = tdbg.RowCount > 0 And chkIsDisplayDetail.Checked = False
        mnuCancel.Enabled = tdbg.RowCount > 0 And chkIsDisplayDetail.Checked = False
  

    End Sub

    Private Sub EnablemnuCreate()
        mnuCreate.Enabled = mnuAdd.Enabled And tdbg.RowCount > 0 And chkIsDisplayDetail.Checked = False AndAlso tdbg.Columns(COL_InterviewLevelID).Text <> "FL"
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
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        '************************************
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
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblDivisionID.Text)
            tdbcDivisionID.Focus()
            Return False
        End If
        If Not CheckValidDateFromTo(c1dateVoucherFromDate, c1dateVoucherDateTo) Then Return False
        'If c1dateVoucherFromDate.Value.ToString = "" Then
        '    D99C0008.MsgNotYetEnter(rL3("Ngay_tu"))
        '    c1dateVoucherFromDate.Focus()
        '    Return False
        'End If
        'If c1dateVoucherDateTo.Value.ToString = "" Then
        '    D99C0008.MsgNotYetEnter(rL3("Ngay_den"))
        '    c1dateVoucherDateTo.Focus()
        '    Return False
        'End If

        Return True
    End Function


#Region "Menu Events"

    Private Sub mnuAdd_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        '************************
        'Dim sKey As String = CallFormD25F2010(Me, EnumFormState.FormAdd, "", "")
        'If sKey <> "" Then
        '    LoadTDBGrid(True, False, sKey)
        'End If
        If Not bLoadFormChild Then vcNewTemp = vcNew
        bLoadFormChild = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Dim f As New D25F2010
        With f
            .InterviewFileID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .SavedOK Then
                Dim sKey As String = f.InterviewFileID
                LoadTDBGrid(True, False, sKey)
            End If
            .Dispose()
        End With
        InitiateD09U1111()
    End Sub

    Private Sub mnuView_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub
        ''************************
        '        CallFormD25F2010(Me, EnumFormState.FormView, tdbg.Columns(COL_InterviewFileID).Text, tdbg.Columns(COL_RecruitPhaseNo).Text)
        If Not bLoadFormChild Then vcNewTemp = vcNew
        bLoadFormChild = True
        If usrOption.Visible Then usrOption.Hide()
        '************************
        Me.Cursor = Cursors.WaitCursor
        Dim f As New D25F2010
        With f
            .InterviewFileID = tdbg.Columns(COL_InterviewFileID).Text
            .RecruitPhaseNo = tdbg.Columns(COL_RecruitPhaseNo).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With

        InitiateD09U1111()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub
        If Not CheckStore(SQLStoreD25P5555(1)) Then Exit Sub

        'If CallFormD25F2010(Me, EnumFormState.FormEdit, tdbg.Columns(COL_InterviewFileID).Text, tdbg.Columns(COL_RecruitPhaseNo).Text) <> "" Then
        '    Dim Bookmark As Integer
        '    If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
        '    LoadTDBGrid(False, True)
        '    If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
        'End If
        ''************************

        If Not bLoadFormChild Then vcNewTemp = vcNew
        bLoadFormChild = True
        If usrOption.Visible Then usrOption.Hide()
        '************************
        Me.Cursor = Cursors.WaitCursor
        Dim f As New D25F2010
        With f
            .InterviewFileID = tdbg.Columns(COL_InterviewFileID).Text
            .RecruitPhaseNo = tdbg.Columns(COL_RecruitPhaseNo).Text
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
        InitiateD09U1111()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub
        If Not CheckStore(SQLStoreD25P5555(6)) Then Exit Sub

        Dim sSQL As String
        Dim bResult As Boolean
        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            'ID 101634 31.10.2017 Bỏ đoạn delete bằng store
            'If chkIsDisplayDetail.Checked Then
            '    sSQL = SQLDeleteD25T2011(True)
            'Else
            '    sSQL = SQLDeleteD25T2040() & vbCrLf
            '    sSQL &= SQLDeleteD25T2011(False) & vbCrLf
            '    sSQL &= " DELETE D25T2010 WHERE InterviewFileID =" & SQLString(tdbg.Columns(COL_InterviewFileID).Text)
            'End If
            sSQL = SQLStoreD25P3021()
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
        '    .FormActive = enumD25E0340Form.D25F4080
        '    .ID01 = txtCandidateID.Text 'CandidateID
        '    .ID02 = txtCandidateName.Text 'CandidateName
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "CandidateID", txtCandidateID.Text)
        SetProperties(arrPro, "CandidateName", txtCandidateName.Text)
        SetProperties(arrPro, "DateFrom", c1dateVoucherFromDate.Value.ToString)
        SetProperties(arrPro, "DateTo", c1dateVoucherDateTo.Value.ToString)
        SetProperties(arrPro, "DivisionID", ReturnValueC1Combo(tdbcDivisionID))
        SetProperties(arrPro, "IsPendding", chkIsPedding.Checked)
        SetProperties(arrPro, "IsComplete", chkIsComplete.Checked)
        SetProperties(arrPro, "InterviewFileID", tdbg.Columns(COL_InterviewFileID).Text)
        SetProperties(arrPro, "VoucherNo", tdbg.Columns(COL_VoucherNo).Text)
        CallFormShow(Me, "D25D0340", "D25F4080", arrPro)
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub mnuPedding_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPedding.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub
        If Not CheckStore(SQLStoreD25P5555(3)) Then Exit Sub
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim bRunSQL As Boolean = ExecuteSQL(SQLUpdateD25T2010(3).ToString)
        If bRunSQL Then
            SaveOK()
        Else
            SaveNotOK()
        End If
    End Sub

    Private Sub mnuComplete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuComplete.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub
        If Not CheckStore(SQLStoreD25P5555(4)) Then Exit Sub
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim bRunSQL As Boolean = ExecuteSQL(SQLUpdateD25T2010(4).ToString)
        If bRunSQL Then
            SaveOK()
        Else
            SaveNotOK()
        End If
    End Sub

    '29/12/2012
    Private Sub mnuExportToExcel_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        '*****************************************
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
        Dim frm As New D99F2222
        ResetTableForExcel(tdbg, gdtCaptionExcel)
        With frm
            .FormID = Me.Name
            .UseUnicode = gbUnicode
            .dtLoadGrid = gdtCaptionExcel
            .GroupColumns = gsGroupColumns
            .dtExportTable = dtGrid
            .ShowDialog()
            .Dispose()
        End With
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
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
        If usrOption IsNot Nothing And bLoadFormChild Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadFormChild = False
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

    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
        sFind = ResultWhereClause.ToString()
        ReLoadTDBGrid()
    End Sub

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
        CheckMenu(Me.Name, C1CommandHolder1, tdbg.RowCount, gbEnabledUseFind, True)
        CheckMenuOther()
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

        '    CheckMenu(Me.Name, C1CommandHolder1, tdbg.RowCount, gbEnabledUseFind, True)
        '    FooterTotalGrid(tdbg, COL_Description)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & " - " & ex.Source)
        'End Try

    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_VoucherDate, COL_FromDate, COL_ToDate, COL_BirthDate, COL_ReceivedDate, COL_IntDate
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
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
                CheckMenu(Me.Name, C1CommandHolder1, tdbg.RowCount, gbEnabledUseFind, True)
            End If
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

#End Region

#Region "SQL, Store"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5555
    '# Created User: Thanh Huyền
    '# Created Date: 16/12/2010 10:12:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5555(ByVal iType As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString("D25F3020") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_InterviewFileID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_CandidateID).Text) & COMMA 'key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsDisplayDetail.Checked) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(iType) & COMMA 'Type, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2040
    '# Created User: Thanh Huyền
    '# Created Date: 16/12/2010 10:12:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: Xoá khi IsDisplayDetail = uncheck
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2040() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2040"
        sSQL &= " Where VoucherID = " & SQLString(tdbg.Columns(COL_InterviewFileID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2011
    '# Created User: Thanh Huyền
    '# Created Date: 16/12/2010 10:14:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: Xoá bảng Detail
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2011(ByVal bDetail As Boolean) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2011"
        sSQL &= " Where InterviewFileID = " & SQLString(tdbg.Columns(COL_InterviewFileID).Text)
        If bDetail Then
            sSQL &= " and CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text)
        End If
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3020
    '# Created User: Thanh Huyền
    '# Created Date: 16/12/2010 01:43:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load lưới
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3020() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P3020 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherFromDate.Value) & COMMA 'VoucherDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateTo.Value) & COMMA 'VoucherDateTo, datetime, NOT NULL
        sSQL &= SQLNumber(chkIsPedding.Checked) & COMMA 'IsPendding, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsComplete.Checked) & COMMA 'IsComplete, tinyint, NOT NULL
        sSQL &= SQLString(txtCandidateID.Text) & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtCandidateName.Text) & COMMA 'CandidateName, varchar[150], NOT NULL
        sSQL &= SQLNumber(chkIsDisplayDetail.Checked) & COMMA 'IsDisplayDetail, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D25F2010") 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3021
    '# Created User: Kim Long
    '# Created Date: 31/10/2017 09:50:26
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3021() As String
        Dim sSQL As String = ""
        sSQL &= ("-- SP xoa " & vbCrlf)
        sSQL &= "Exec D25P3021 "
        sSQL &= SQLString(tdbg.Columns(COL_DivisionID).Text) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_InterviewFileID).Text) & COMMA 'InterviewFileID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLNumber(chkIsDisplayDetail.Checked) & COMMA 'IsDisplayDetail, tinyint, NOT NULL
        sSQL &= SQLString("") 'CandidateID, varchar[50], NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2010
    '# Created User: Thanh Huyền
    '# Created Date: 16/12/2010 01:43:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2010(ByVal iStatus As Integer) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T2010 Set ")
        sSQL.Append("StatusID = " & SQLNumber(iStatus)) 'tinyint, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("InterviewFileID = " & SQLString(tdbg.Columns(COL_InterviewFileID).Text))

        Return sSQL
    End Function

#End Region

#Region "Events tdbcDivisionID"

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then tdbcDivisionID.Text = ""
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
#End Region
    Private Sub mnuCreate_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCreate.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub

        If Not bLoadFormChild Then vcNewTemp = vcNew
        bLoadFormChild = True
        If usrOption.Visible Then usrOption.Hide()
        '************************
        Me.Cursor = Cursors.WaitCursor
        Dim f As New D25F2010
        With f
            .InterviewFileID = tdbg.Columns(COL_InterviewFileID).Text
            .RecruitPhaseNo = tdbg.Columns(COL_RecruitPhaseNo).Text
            .Mode = 1
            .FormState = EnumFormState.FormCopy
            .ShowDialog()
            .Dispose()
            If .SavedOK Then
                Dim sKey As String = f.InterviewFileID
                LoadTDBGrid(True, False, sKey)
            End If
        End With
        Me.Cursor = Cursors.Default
        InitiateD09U1111()
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        EnablemnuCreate()
    End Sub

End Class

