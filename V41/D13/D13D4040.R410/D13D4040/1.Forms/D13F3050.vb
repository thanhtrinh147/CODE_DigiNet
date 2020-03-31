Public Class D13F3050

#Region "Const of tdbg1"
    Private Const COL_DepartmentID As Integer = 0 ' Phòng ban
    Private Const COL_TeamID As Integer = 1       ' Tổ nhóm
    Private Const COL_EmployeeID As Integer = 2   ' Mã nhân viên
    Private Const COL_EmployeeName As Integer = 3 ' Tên nhân viên
    Private Const COL_DutyID As Integer = 4       ' Chức vụ
    Private Const COL_Sex As Integer = 5          ' Giới tính
    Private Const COL_Birthdate As Integer = 6    ' Ngày sinh
    Private Const COL_DateJoined As Integer = 7   ' Ngày vào làm
#End Region

#Region "Const of tdbg2"
    Private Const COL2_Code As Integer = 0          ' Code
    Private Const COL2_Description As Integer = 1   ' Khoản đối chiếu
    Private Const COL2_Period As Integer = 2        ' Kỳ lương
    Private Const COL2_ComparePeriod As Integer = 3 ' Kỳ đối chiếu
    Private Const COL2_DiffValue As Integer = 4     ' Chênh lệch
#End Region

#Region "Const of tdbg3"
    Private Const COL3_DepartmentID As Integer = 0  ' Phòng ban
    Private Const COL3_TeamID As Integer = 1        ' Tổ nhóm
    Private Const COL3_EmployeeID As Integer = 2    ' Mã nhân viên
    Private Const COL3_EmployeeName As Integer = 3  ' Tên nhân viên
    Private Const COL3_DutyID As Integer = 4        ' Chức vụ
    Private Const COL3_Sex As Integer = 5           ' Giới tính
    Private Const COL3_Birthdate As Integer = 6     ' Ngày sinh
    Private Const COL3_DateJoined As Integer = 7    ' Ngày vào làm
    Private Const COL3_Period As Integer = 8        ' Kỳ lương
    Private Const COL3_ComparePeriod As Integer = 9 ' Kỳ đối chiếu
    Private Const COL3_DiffValue As Integer = 10    ' Chênh lệch
#End Region

    Private dt1, dt2, dt3 As DataTable
    Private dtDepartmentID, dtTeamID As DataTable
    Private dtCaptionCols_grid1, dtCaptionCols_grid3_M, dtCaptionCols_grid3_D As DataTable   'Table ghi nhận caption của lưới 3
    Dim bEnabledUseFind2 As Boolean = False
    Dim bEnabledUseFind3 As Boolean = False
    Dim bLoad As Boolean = False
    Dim bFilter As Boolean = False
    Dim iCol() As Integer = {}

    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrGrid As New ArrayList
    'Private arrGrid3Master As New ArrayList
    'Private arrGrid3Detail As New ArrayList

    Private Sub D13F3050_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
        If e.Alt And e.KeyCode = Keys.D1 Then
            tabMain.SelectedTab = TabPage1
        ElseIf e.Alt And e.KeyCode = Keys.D2 Then
            tabMain.SelectedTab = TabPage2
        End If
    End Sub

    Private Sub D13F3050_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        ResetColorGrid(tdbg1)
        ResetColorGrid(tdbg2)
        ResetColorGrid(tdbg3, 0, 1)
        Loadlanguage()
        LoadTDBCombo()
        LoadDefault()
        tdbg3_NumberFormat()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtEmployeeID, txtEmployeeID.MaxLength)
        AddCol()
        gbEnabledUseFind = False
        bLoad = True
        SetShortcutPopupMenu(C1CommandHolder)
        SetBackColorObligatory()
        '*****************************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'Đặt các dòng code sau vào cuối FormLoad
        '*****************************************
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        'Những cột bắt buộc nhập
        'Những cột bắt buộc nhập
        '-----------------------------------
        'Các cột ở SPLIT0
        AddColVisible(tdbg3, SPLIT0, arrGrid, , , , gbUnicode)
        AddColVisible(tdbg3, SPLIT1, arrGrid, , , , gbUnicode)
        '-----------------------------------
        CallD09U1111()
        '*****************************************
        ResetSplitDividerSize(tdbg1)
        ResetSplitDividerSize(tdbg3)
        InputDateInTrueDBGrid(tdbg1, COL_Birthdate, COL_DateJoined)
        InputDateInTrueDBGrid(tdbg3, COL3_Birthdate, COL3_DateJoined)

        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadDefault()
        tdbcBlockID.SelectedValue = "%"
        tdbcWorkingStatusID.SelectedValue = "%"
        If D13Systems.IsUseBlock Then
            UnReadOnlyControl(tdbcBlockID)
        Else
            ReadOnlyControl(tdbcBlockID)
        End If
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Doi_chieu_du_lieu_tinh_luong_-_D13F3050") & UnicodeCaption(gbUnicode) '˜çi chiÕu dö liÖu tÛnh l§¥ng - D13F3050
        '================================================================ 
        lblEmployeeID.Text = rl3("Ma_NV") 'Mã NV
        lblEmployeeName.Text = rl3("Ho_va_ten") 'Tên NV
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblWorkingStatusID.Text = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        lblDataMode.Text = rl3("Nguon_doi_chieu") 'Nguồn đối chiếu
        lblCompareMode.Text = rl3("Hinh_thuc_doi_chieu") 'Hình thức đối chiếu
        lblData.Text = rl3("Du_lieu") 'Dữ liệu
        lblPeriod.Text = rl3("Ky") 'Kỳ
        lblVoucherID.Text = rl3("Phieu") 'Phiếu
        lblComparePeriod.Text = rl3("Ky_doi_chieu") 'Kỳ đối chiếu
        lblCompareVoucherID.Text = rl3("Phieu_doi_chieu") 'Phiếu đối chiếu
        lblCompareCode.Text = rl3("Khoan_doi_chieu") 'Khoản đối chiếu
        '================================================================ 
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '***************************************
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '***************************************
        '================================================================ 
        optDataAdjustIncome.Text = rl3("Dieu_chinh_thu_nhap") 'Điều chỉnh thu nhập
        optDataSalary.Text = rl3("Luong") 'Lương
        optCompare2.Text = rl3("DL_chenh_lech_giua_2_ky") 'DL chênh lệch giữa 2 kỳ
        optCompare3.Text = rl3("DL_chi_phat_sinh_1_trong_2_ky") 'DL chỉ phát sinh 1 trong 2 kỳ
        optCompare1.Text = rl3("DL_phat_sinh_trong_2_ky") 'DL phát sinh trong 2 kỳ
        '================================================================ 
        TabPage1.Text = rl3("Du_lieu_phat_sinh_trong_ky") 'Dữ liệu phát sinh trong kỳ
        TabPage2.Text = rl3("Doi_chieu_chenh_lech_2_ky_luong") 'Đối chiếu chênh lệch 2 kỳ lương
        '================================================================ 
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã
        tdbcWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        tdbcVoucherID.Columns("VoucherID").Caption = rl3("So_phieu") 'Số phiếu
        tdbcVoucherID.Columns("Description").Caption = rl3("Dien_giai") 'Mã phiếu
        tdbcCompareVoucherID.Columns("VoucherID").Caption = rl3("So_phieu")
        tdbcCompareVoucherID.Columns("Description").Caption = rl3("Dien_giai") 'Mã phiếu
        tdbcCompareCode.Columns("CompareCode").Caption = rl3("Khoan_doi_chieu") 'Khoản đối chiếu
        tdbcCompareCode.Columns("Short").Caption = rl3("Ten_tat")
        '================================================================ 
        tdbg1.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg1.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg1.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg1.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbg1.Columns("DutyID").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg1.Columns("Sex").Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg1.Columns("Birthdate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg1.Columns("DateJoined").Caption = rl3("Ngay_vao_lam") 'Ngày vào làm

        tdbg2.Columns("Description").Caption = rl3("Khoan_doi_chieu") 'Khoản đối chiếu
        tdbg2.Columns("Period").Caption = rl3("Ky_luong") 'Kỳ lương
        tdbg2.Columns("ComparePeriod").Caption = rl3("Ky_doi_chieu") 'Kỳ đối chiếu
        tdbg2.Columns("DiffValue").Caption = rl3("Chenh_lech") 'Chênh lệch

        tdbg3.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg3.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg3.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg3.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbg3.Columns("DutyID").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg3.Columns("Sex").Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg3.Columns("Birthdate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg3.Columns("DateJoined").Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbg3.Columns("Period").Caption = rl3("Ky_luong") 'Kỳ lương
        tdbg3.Columns("ComparePeriod").Caption = rl3("Ky_doi_chieu") 'Kỳ đối chiếu
        tdbg3.Columns("DiffValue").Caption = rl3("Chenh_lech") 'Chênh lệch
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuExportToExcel.Text = rl3("Xuat__Excel") 'Xuất &Excel
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)

        LoadtdbcBlockID(tdbcBlockID, gbUnicode)
        LoadtdbcWorkingStatusID(tdbcWorkingStatusID, , gbUnicode)

        'Load tdbcPeriodFrom
        Dim dt As DataTable = ReturnTablePeriod("D09")
        LoadDataSource(tdbcPeriod, dt, gbUnicode)
        'LoadCboPeriodReport(tdbcPeriod, "D09")
        tdbcPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear

        'Load tdbcPeriodFrom
        'LoadCboPeriodReport(tdbcComparePeriod, "D09")
        LoadDataSource(tdbcComparePeriod, dt.Copy, gbUnicode)
        tdbcComparePeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear

        'Load tdbcVoucherID
        If tdbcPeriod.Text <> "" Then
            LoadtdbcVoucherID(tdbcPeriod.Columns("TranMonth").Text, tdbcPeriod.Columns("TranYear").Text)
        End If
        If tdbcComparePeriod.Text <> "" Then
            LoadtdbcVoucherID(tdbcComparePeriod.Columns("TranMonth").Text, tdbcComparePeriod.Columns("TranYear").Text, False)
        End If

        'Load tdbcCompareMode
        sSQL = SQLStoreD13P3044(giTranMonth.ToString, giTranYear.ToString, 2)
        LoadDataSource(tdbcCompareCode, sSQL, gbUnicode)

        'Load tdbcSign
        'sSQL = "Select 0 as Sign, '' as SignName" & vbCrLf
        'sSQL &= "Union" & vbCrLf
        sSQL = "Select 1 as Sign, '=' as SignName" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 2 as Sign, '>' as SignName" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 3 as Sign, '<' as SignName" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 4 as Sign, '>=' as SignName" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 5 as Sign, '<=' as SignName"
        LoadDataSource(tdbcSign, sSQL, gbUnicode)
    End Sub

    Private Sub LoadtdbcVoucherID(ByVal sTranMonth As String, ByVal sTranYear As String, Optional ByVal bVoucher As Boolean = True)
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P3044(sTranMonth, sTranYear, 1)
        If bVoucher Then
            LoadDataSource(tdbcVoucherID, sSQL, gbUnicode) 'bVoucher = True => Combo Phiếu
            tdbcVoucherID.SelectedValue = "%"
        Else
            LoadDataSource(tdbcCompareVoucherID, sSQL, gbUnicode) 'bVoucher = False => Combo Phiếu đối chiếu
            tdbcCompareVoucherID.SelectedValue = "%"
        End If
    End Sub

    Private iCountCol As Integer = 0
    Private Sub AddCol()
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        If tdbg1.Splits.ColCount >= 2 Then
            tdbg1.RemoveHorizontalSplit(1)
        End If

        Dim sSQL As String = ""
        sSQL = SQLStoreD13P3040()
        Dim dt3040 As DataTable = ReturnDataTable(sSQL)
        If dt3040.Rows.Count > 0 Then

            tdbg1.InsertHorizontalSplit(1)
            While tdbg1.Columns.Count >= COL_DateJoined + 2
                tdbg1.Columns.RemoveAt(COL_DateJoined + 1)
            End While

            'tdbg1.Splits(1).SplitSize = 5
            'tdbg1.Splits(1).Caption = ""

            tdbg1.Splits(1).RecordSelectors = False
            tdbg1.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
            tdbg1.Splits(1).BorderStyle = Border3DStyle.Flat
            tdbg1.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always

            For j As Integer = 0 To COL_DateJoined
                tdbg1.Splits(1).DisplayColumns(j).Visible = False
            Next
            iCountCol = COL_DateJoined
            Dim nWidth As Integer = 110
            For i As Integer = 0 To dt3040.Rows.Count - 1
                col = New C1.Win.C1TrueDBGrid.C1DataColumn
                col.DataField = dt3040.Rows(i).Item("Code").ToString
                col.Caption = dt3040.Rows(i).Item("Short").ToString
                tdbg1.Columns.Add(col)
                tdbg1.Splits(1).DisplayColumns(col).Visible = True
                tdbg1.Splits(1).DisplayColumns(col).Width = nWidth
                tdbg1.Splits(1).DisplayColumns(col).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                tdbg1.Splits(1).DisplayColumns(col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                tdbg1.Columns(COL_DateJoined + i + 1).NumberFormat = D13Format.DefaultNumber2

                tdbg1.Splits(1).DisplayColumns(col).HeadingStyle.Font = FontUnicode(gbUnicode)
            Next
            tdbg1.Splits(1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
            tdbg1.Splits(1).SplitSize = 1
            tdbg1.Splits(1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
            '  tdbg1.Splits(1).ColumnCaptionHeight = 28 ' Gắn này sẽ bị lỗi nếu có chỉnh theo Độ phân giải Windows 25/03/2016
        End If
        ReDim iCol(dt3040.Rows.Count - 1)
        Dim k As Integer = 0
        For i As Integer = COL_DateJoined + 1 To tdbg1.Columns.Count - 1
            iCol(k) = i
            k += 1
        Next
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(Me, New Point(btnAction.Left, btnAction.Top))
    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg1.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Private sFind1 As String = ""
    Private sFind2 As String = ""
    Private sFind3 As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            If Me.ActiveControl.Name = "tdbg1" Then
                sFind1 = Value
            ElseIf Me.ActiveControl.Name = "tdbg2" Then
                sFind2 = Value
            ElseIf Me.ActiveControl.Name = "tdbg3" Then
                sFind3 = Value
            End If
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        If Me.ActiveControl.Name = "tdbg1" Then
            gbEnabledUseFind = True
            '*****************************************
            'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
            tdbg1.UpdateData()
            ResetTableForExcel(tdbg1, dtCaptionCols_grid1)
            ShowFindDialogClient(Finder, dtCaptionCols_grid1, Me, "0", gbUnicode)
            '*****************************************
        ElseIf Me.ActiveControl.Name = "tdbg2" Then
            bEnabledUseFind2 = True

            If Not CallMenuFromGrid(tdbg2, e) Then Exit Sub
            gbEnabledUseFind = True
            '*****************************************
            'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
            tdbg2.UpdateData()
            If dtCaption2 Is Nothing OrElse dtCaption2.Rows.Count < 1 Then
                'Những cột bắt buộc nhập
                Dim Arr As New ArrayList
                AddColVisible(tdbg2, SPLIT0, Arr, , , , gbUnicode)
                'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
                dtCaption2 = CreateTableForExcelOnly(tdbg2, Arr)
            End If
            ShowFindDialogClient(Finder, dtCaption2, Me, "0", gbUnicode)
            '*****************************************
        ElseIf Me.ActiveControl.Name = "tdbg3" Then
            bEnabledUseFind3 = True
            If Not CallMenuFromGrid(tdbg3, e) Then Exit Sub
            gbEnabledUseFind = True
            '*****************************************
            'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
            tdbg3.UpdateData()
            ResetTableForExcel(tdbg3, dtCaptionCols_grid3_D)
            ShowFindDialogClient(Finder, dtCaptionCols_grid3_D, Me, "1", gbUnicode)
            '*****************************************
        End If
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        If Me.ActiveControl.Name = "tdbg1" Then
    '            sFind1 = ResultWhereClause.ToString()
    '        ElseIf Me.ActiveControl.Name = "tdbg2" Then
    '            sFind2 = ResultWhereClause.ToString()
    '        ElseIf Me.ActiveControl.Name = "tdbg3" Then
    '            sFind3 = ResultWhereClause.ToString()
    '        End If
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click

        If Me.ActiveControl.Name = "tdbg1" Then
            sFind1 = ""
        ElseIf Me.ActiveControl.Name = "tdbg2" Then
            sFind2 = ""
        ElseIf Me.ActiveControl.Name = "tdbg3" Then
            sFind3 = ""
        End If
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        'LoadGridFind(tdbg, dt, sFind)
        'CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        If Me.ActiveControl.Name = "tdbg1" Then
            dt1.DefaultView.RowFilter = sFind1
            '  LoadGridFind(tdbg1, dt1, sFind1)
            FooterTotalGrid(tdbg1, GetColFirst(tdbg1))
            FooterSum(tdbg1, iCol)
        ElseIf Me.ActiveControl.Name = "tdbg2" Then
            '  LoadGridFind(tdbg2, dt2, sFind2)
            dt2.DefaultView.RowFilter = sFind2
            FooterTotalGrid(tdbg2, GetColFirst(tdbg2))
            FooterSum(tdbg2, sCol2)
        ElseIf Me.ActiveControl.Name = "tdbg3" Then
            'LoadGridFind(tdbg3, dt3, sFind3)
            dt3.DefaultView.RowFilter = sFind3
            FooterTotalGrid(tdbg3, GetColFirst(tdbg3))
            FooterSum(tdbg3, iCol3)
        End If
    End Sub
#End Region

    Dim dtCaption2 As New DataTable
    Private Sub mnuExportToExcel_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportToExcel.Click
        If Me.ActiveControl.Name = "tdbg1" Then

            If Not CallMenuFromGrid(tdbg1, e) Then Exit Sub
            ' Gọi form Xuất Excel như sau:
            ResetTableForExcel(tdbg1, dtCaptionCols_grid1)
            CallShowD99F2222(Me, dtCaptionCols_grid1, dt1, gsGroupColumns)

            '            '*****************************************
            '            'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
            '            ResetTableForExcel(tdbg1, gdtCaptionExcel, iCol)
            '            Dim frm As New D99F2222
            '            With frm
            '                .FormID = Me.Name
            '                .UseUnicode = gbUnicode
            '                .dtLoadGrid = gdtCaptionExcel
            '                .GroupColumns = gsGroupColumns
            '                .dtExportTable = dt1
            '                .ShowDialog()
            '                .Dispose()
            '            End With
            '            '*****************************************

        ElseIf Me.ActiveControl.Name = "tdbg2" Then
            If CallMenuFromGrid(tdbg2, e) = False Then Exit Sub
            '*****************************************
            'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới không có nút Hiển thị)
            'Nếu lưới không có Group thì mở dòng code If dtCaptionCols Is Nothing Then 
            'và truyền đối số cuối cùng là False vào hàm AddColVisible
            If dtCaption2 Is Nothing OrElse dtCaption2.Rows.Count < 1 Then
                Dim Arr As New ArrayList
                AddColVisible(tdbg2, SPLIT0, Arr, , , , gbUnicode)
                'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
                dtCaption2 = CreateTableForExcelOnly(tdbg2, Arr)
            End If
            Dim frm As New D99F2222
            'Gọi form Xuất Excel như sau:
            ResetTableForExcel(tdbg2, dtCaption2)
            CallShowD99F2222(Me, dtCaption2, dt2, gsGroupColumns)

            '            Dim frm As New D99F2222
            '            ResetTableForExcel(tdbg2, gdtCaptionExcel, iCol2)
            '            With frm
            '                .FormID = Me.Name
            '                .UseUnicode = gbUnicode
            '                .dtLoadGrid = dtCaption2 'gdtCaptionExcel '
            '                .GroupColumns = gsGroupColumns
            '                .dtExportTable = dt2
            '                .ShowDialog()
            '                .Dispose()
            '            End With
            '            '*****************************************
        ElseIf Me.ActiveControl.Name = "tdbg3" Then
            If Not CallMenuFromGrid(tdbg3, e) Then Exit Sub

            'Gọi form Xuất Excel như sau:
            ResetTableForExcel(tdbg3, dtCaptionCols_grid3_D)
            CallShowD99F2222(Me, dtCaptionCols_grid3_D, dt3, gsGroupColumns)
            '            '*****************************************
            '            'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
            '            Dim frm As New D99F2222
            '            ResetTableForExcel(tdbg3, gdtCaptionExcel, iCol3)
            '            With frm
            '                .FormID = Me.Name
            '                .UseUnicode = gbUnicode
            '                .dtLoadGrid = gdtCaptionExcel
            '                .GroupColumns = gsGroupColumns
            '                .dtExportTable = dt3
            '                .ShowDialog()
            '                .Dispose()
            '            End With
            '            '*****************************************
        End If
    End Sub

    Private Function GetColFirst(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As Integer
        For i As Integer = 0 To tdbg.Columns.Count - 1
            If tdbg.Splits(0).DisplayColumns(i).Visible = True Then
                Return i
            End If
        Next
    End Function

    Private Sub LoadTDBGrid_1()
        Dim sSQL As String
        sSQL = SQLStoreD13P3041()
        dt1 = ReturnDataTable(sSQL)
        LoadDataSource(tdbg1, dt1, gbUnicode)
        FooterTotalGrid(tdbg1, GetColFirst(tdbg1))
        FooterSum(tdbg1, iCol)
        If tabMain.SelectedIndex = 1 Then
            LoadTDBGrid_2()
        End If
    End Sub

    Dim sCol2() As String = {"Period", "ComparePeriod", "DiffValue"}
    Dim iCol2() As Integer = {COL2_Period, COL2_ComparePeriod, COL2_DiffValue}
    Private Sub LoadTDBGrid_2()
        Dim sSQL As String
        sSQL = SQLStoreD13P3042()
        dt2 = ReturnDataTable(sSQL)
        LoadDataSource(tdbg2, dt2, gbUnicode)
        FooterTotalGrid(tdbg2, GetColFirst(tdbg2))
        FooterSum(tdbg2, sCol2)
    End Sub

    Dim iCol3() As Integer = {COL3_Period, COL3_ComparePeriod, COL3_DiffValue}
    Private Sub LoadTDBGrid_3()
        Dim sSQL As String
        sSQL = SQLStoreD13P3043()
        dt3 = ReturnDataTable(sSQL)
        LoadDataSource(tdbg3, dt3, gbUnicode)
        FooterTotalGrid(tdbg3, GetColFirst(tdbg3))
        FooterSum(tdbg3, iCol3)
    End Sub

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", "-1", gbUnicode)
        Else

            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, gbUnicode)
        End If
        tdbcDepartmentID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedValue = "%"
    End Sub
#End Region

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcWorkingStatusID"

    Private Sub tdbcWorkingStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcWorkingStatusID.LostFocus
        If tdbcWorkingStatusID.FindStringExact(tdbcWorkingStatusID.Text) = -1 Then
            tdbcWorkingStatusID.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcPeriod"
    Dim sPeriod As String = ""
    Private Sub tdbcPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriod.LostFocus
        If tdbcPeriod.FindStringExact(tdbcPeriod.Text) = -1 Then tdbcPeriod.Text = ""
        If sPeriod <> tdbcPeriod.Text Then
            LoadtdbcVoucherID(tdbcPeriod.Columns("TranMonth").Text, tdbcPeriod.Columns("TranYear").Text)
        End If
        sPeriod = tdbcPeriod.Text
    End Sub

#End Region

#Region "Events tdbcComparePeriod"
    Dim sComPeriod As String = ""
    Private Sub tdbcComparePeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcComparePeriod.LostFocus
        If tdbcComparePeriod.FindStringExact(tdbcComparePeriod.Text) = -1 Then tdbcComparePeriod.Text = ""
        If sComPeriod <> tdbcComparePeriod.Text Then
            LoadtdbcVoucherID(tdbcComparePeriod.Columns("TranMonth").Text, tdbcComparePeriod.Columns("TranYear").Text, False)
        End If
        sComPeriod = tdbcComparePeriod.Text
    End Sub

#End Region

#Region "Events tdbcVoucherID"

    Private Sub tdbcVoucherID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherID.LostFocus
        If tdbcVoucherID.FindStringExact(tdbcVoucherID.Text) = -1 Then tdbcVoucherID.Text = ""
    End Sub

#End Region

#Region "Events tdbcCompareVoucherID"

    Private Sub tdbcCompareVoucherID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCompareVoucherID.LostFocus
        If tdbcCompareVoucherID.FindStringExact(tdbcCompareVoucherID.Text) = -1 Then tdbcCompareVoucherID.Text = ""
    End Sub

#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcBlockID.BeforeOpen, tdbcDepartmentID.BeforeOpen, tdbcTeamID.BeforeOpen, tdbcWorkingStatusID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcWorkingStatusID.Close, tdbcCompareVoucherID.Close, tdbcVoucherID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyUp, tdbcDepartmentID.KeyUp, tdbcTeamID.KeyUp, tdbcWorkingStatusID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcWorkingStatusID.Validated, tdbcCompareVoucherID.Validated, tdbcCompareVoucherID.Close
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#Region "SQL function"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3044
    '# Created User: Thanh Huyền
    '# Created Date: 11/05/2010 09:24:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load Combo Phiếu, Phiếu đối chiếu
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3044(ByVal sTranMonth As String, ByVal sTranYear As String, ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P3044 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(sTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(sTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(IIf(optDataSalary.Checked, 1, 2)) & COMMA 'DataMode, int, NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3040
    '# Created User: Thanh Huyền
    '# Created Date: 11/05/2010 09:55:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load cột động cho lưới 1
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3040() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P3040 "
        sSQL &= SQLString(ComboValue(tdbcVoucherID)) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(IIf(optDataSalary.Checked, 1, 2)) & COMMA 'DataMode, int, NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3041
    '# Created User: Thanh Huyền
    '# Created Date: 11/05/2010 10:47:49
    '# Modified User: 
    '# Modified Date: 
    '# Description: Đổ nguồn cho lưới 1
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3041() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P3041 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcWorkingStatusID)) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtEmployeeName.Text) & COMMA 'EmployeeName, varchar[250], NOT NULL
        sSQL &= SQLString(txtEmployeeID.Text) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranMonth").Text) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranYear").Text) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcVoucherID)) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(optDataSalary.Checked, 1, 2)) & COMMA 'DataMode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D13F3050") 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3042
    '# Created User: Thanh Huyền
    '# Created Date: 12/05/2010 10:10:07
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load lưới 2
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3042() As String
        Dim sSQL As String = ""
        Dim iCom As Integer
        If optCompare1.Checked Then
            iCom = 1
        ElseIf optCompare3.Checked Then
            iCom = 3
        Else
            iCom = 2
        End If
        sSQL &= "Exec D13P3042 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcWorkingStatusID)) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg1.Columns(COL_EmployeeID).Text) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iCom) & COMMA 'CompareMode, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranMonth").Text) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranYear").Text) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcVoucherID)) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcCompareCode)) & COMMA 'CompareCode, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcComparePeriod.Columns("TranMonth").Text) & COMMA 'CompareTranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcComparePeriod.Columns("TranYear").Text) & COMMA 'CompareTranYear, int, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcCompareVoucherID)) & COMMA 'CompareVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(optDataSalary.Checked, 1, 2)) & COMMA 'DataMode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3043
    '# Created User: Thanh Huyền
    '# Created Date: 13/05/2010 07:31:49
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load lưới 3
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3043() As String
        Dim sSQL As String = ""
        Dim iCom As Integer
        If optCompare1.Checked Then
            iCom = 1
        ElseIf optCompare3.Checked Then
            iCom = 3
        Else
            iCom = 2
        End If
        sSQL &= "Exec D13P3043 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcWorkingStatusID)) & COMMA 'WorkingStatusID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtEmployeeName.Text) & COMMA 'EmployeeName, varchar[250], NOT NULL
        sSQL &= SQLString(txtEmployeeID.Text) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iCom) & COMMA 'CompareMode, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranMonth").Text) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriod.Columns("TranYear").Text) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcVoucherID)) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(ComboValue(tdbcCompareCode)) & COMMA 'CompareCode, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcComparePeriod.Columns("TranMonth").Text) & COMMA 'CompareTranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcComparePeriod.Columns("TranYear").Text) & COMMA 'CompareTranYear, int, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcCompareVoucherID)) & COMMA 'CompareVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(optDataSalary.Checked, 1, 2)) & COMMA 'DataMode, int, NOT NULL
        sSQL &= SQLString(ComboValue(tdbcSign)) & COMMA 'Sign, varchar[20], NOT NULL
        sSQL &= SQLMoney(txtDiffValue.Text, D13Format.DefaultNumber0) & COMMA 'DiffValue, decimal, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D13F3050") 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

#End Region

    Private Sub optDataSalary_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDataSalary.CheckedChanged
        If bLoad Then
            LoadtdbcVoucherID(tdbcPeriod.Columns("TranMonth").Text, tdbcPeriod.Columns("TranYear").Text)
            LoadtdbcVoucherID(tdbcComparePeriod.Columns("TranMonth").Text, tdbcComparePeriod.Columns("TranYear").Text, False)
            Dim sSQL As String = ""
            'Load tdbcCompareMode
            sSQL = SQLStoreD13P3044("0", "0", 2)
            LoadDataSource(tdbcCompareCode, sSQL, gbUnicode)
            AddCol()
            If optCompare1.Checked = False Then
                tdbcCompareCode.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub tdbg1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg1.MouseDown
        mnuFind.Enabled = tdbg1.RowCount > 0 Or gbEnabledUseFind
        mnuListAll.Enabled = tdbg1.RowCount > 0 Or gbEnabledUseFind
        mnuExportToExcel.Enabled = tdbg1.RowCount > 0
    End Sub

    Private Sub tdbg2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg2.MouseDown
        mnuFind.Enabled = tdbg2.RowCount > 0 Or bEnabledUseFind2
        mnuListAll.Enabled = tdbg2.RowCount > 0 Or bEnabledUseFind2
        mnuExportToExcel.Enabled = tdbg2.RowCount > 0
    End Sub

    Private Sub tdbg3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg3.MouseDown
        mnuFind.Enabled = tdbg3.RowCount > 0 Or bEnabledUseFind3
        mnuListAll.Enabled = tdbg3.RowCount > 0 Or bEnabledUseFind3
        mnuExportToExcel.Enabled = tdbg3.RowCount > 0
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        If optCompare1.Checked Then
            LoadTDBGrid_1()
        Else
            LoadTDBGrid_3()
        End If
        bFilter = True
    End Sub

    Private Sub txtDiffValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiffValue.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDotSign)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcComparePeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCompareCode.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcVoucherID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCompareVoucherID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        'tdbcWorkingStatusID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCompareCode.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub CallD09U1111_Grid1()
        For i As Integer = 0 To COL_DateJoined
            tdbg1.Splits(0).DisplayColumns(i).Visible = True
        Next
        Dim arrGrid1 As New ArrayList
        AddColVisible(tdbg1, SPLIT0, arrGrid1, , , , gbUnicode)
        AddColVisible(tdbg1, SPLIT1, arrGrid1, , , , gbUnicode)
        dtCaptionCols_grid1 = CreateTableForExcel(tdbg1, arrGrid1)
        usrOption = New D09U1111(tdbg1, dtCaptionCols_grid1, Me.Name.Substring(1, 2), Me.Name, "0", True, , , gbUnicode)
    End Sub

    Dim bLoadFirst As Boolean = True
    Private Sub CallD09U1111()
        If usrOption IsNot Nothing Then
            usrOption.Hide()
        End If
        If optCompare1.Checked Then
            CallD09U1111_Grid1()
        ElseIf optCompare3.Checked Then
            dtCaptionCols_grid3_D = CreateTableForExcel(tdbg3, arrGrid)
            usrOption = New D09U1111(tdbg3, dtCaptionCols_grid3_D, Me.Name.Substring(1, 2), Me.Name, "1", , True, , gbUnicode)
            bLoadFirst = False
        End If
    End Sub

#Region "Events tdbcCompareCode"

    Private Sub tdbcCompareCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCompareCode.LostFocus
        If tdbcCompareCode.FindStringExact(tdbcCompareCode.Text) = -1 Then tdbcCompareCode.Text = ""
        'tdbcCompareCode.AutoSelect = True
    End Sub
#End Region

    Private Sub tdbcSign_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSign.SelectedValueChanged
        If tdbcSign.Text <> "" Then
            UnReadOnlyControl(txtDiffValue, True)
        Else
            txtDiffValue.Text = ""
            ReadOnlyControl(txtDiffValue)
        End If
    End Sub

    Private Sub tdbcSign_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSign.LostFocus
        If tdbcSign.FindStringExact(tdbcSign.Text) = -1 Then tdbcSign.Text = ""
    End Sub

    Private Sub optCompare3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCompare3.Click
        tabMain.Visible = False
        tdbg3.Visible = True
        tdbg3.Height = tabMain.Height - 22
        tdbg3.Top = tabMain.Top + 22
        tdbg3.Left = tabMain.Left + 6
        UnReadOnlyControl(tdbcCompareCode, True)
        tdbcCompareCode.SelectedIndex = 0
        ReadOnlyControl(tdbcSign)
        ReadOnlyControl(txtDiffValue)
        tdbcSign.Text = ""
        txtDiffValue.Text = ""
        If dt1 IsNot Nothing Then
            dt1.Clear()
            FooterTotalGrid(tdbg1, GetColFirst(tdbg1))
            FooterSum(tdbg1, iCol)
        End If
        If dt2 IsNot Nothing Then
            dt2.Clear()
            FooterTotalGrid(tdbg2, GetColFirst(tdbg2))
            FooterSum(tdbg2, sCol2)
        End If
        If dt3 IsNot Nothing Then
            dt3.Clear()
            FooterTotalGrid(tdbg3, GetColFirst(tdbg3))
            FooterSum(tdbg3, iCol3)
        End If
        'tdbg3.Splits(1).DisplayColumns("DiffValue").Visible = False
        CallD09U1111()
    End Sub

    Private Sub optCompare2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCompare2.Click
        tabMain.Visible = False
        tdbg3.Visible = True
        tdbg3.Height = tabMain.Height - 22
        tdbg3.Top = tabMain.Top + 22
        tdbg3.Left = tabMain.Left + 6
        UnReadOnlyControl(tdbcCompareCode, True)
        tdbcCompareCode.SelectedIndex = 0
        UnReadOnlyControl(tdbcSign)
        If dt1 IsNot Nothing Then
            dt1.Clear()
            FooterTotalGrid(tdbg1, GetColFirst(tdbg1))
            FooterSum(tdbg1, iCol)
        End If
        If dt2 IsNot Nothing Then
            dt2.Clear()
            FooterTotalGrid(tdbg2, GetColFirst(tdbg2))
            FooterSum(tdbg2, sCol2)
        End If
        If dt3 IsNot Nothing Then
            dt3.Clear()
            FooterTotalGrid(tdbg3, GetColFirst(tdbg3))
            FooterSum(tdbg3, iCol3)
        End If
        'tdbg3.Splits(1).DisplayColumns("DiffValue").Visible = True
        CallD09U1111()
    End Sub

    Private Sub optCompare1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCompare1.Click
        tabMain.Visible = True
        tdbg3.Visible = False
        If dt3 IsNot Nothing Then
            dt3.Clear()
            FooterTotalGrid(tdbg3, GetColFirst(tdbg3))
            FooterSum(tdbg3, iCol3)
        End If
        AddCol()
        tabMain.SelectedTab = TabPage1
        ReadOnlyControl(tdbcCompareCode)
        ReadOnlyControl(tdbcSign)
        ReadOnlyControl(txtDiffValue)
        tdbcCompareCode.Text = ""
        tdbcSign.Text = ""
        txtDiffValue.Text = ""
        CallD09U1111()
    End Sub

    Private Function AllowFilter() As Boolean
        If optCompare2.Checked And tdbcSign.Text <> "" Then
            If txtDiffValue.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Chenh_lech"))
                txtDiffValue.Focus()
                Return False
            End If
        End If
        If tdbcPeriod.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ky"))
            tdbcPeriod.Focus()
            Return False
        End If
        If tdbcVoucherID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phieu"))
            tdbcVoucherID.Focus()
            Return False
        End If
        If tdbcComparePeriod.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ky_doi_chieu"))
            tdbcComparePeriod.Focus()
            Return False
        End If
        If tdbcCompareVoucherID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Phieu_doi_chieu"))
            tdbcCompareVoucherID.Focus()
            Return False
        End If
        If tdbcCompareCode.Enabled = True And (optCompare3.Checked Or optCompare2.Checked) Then
            If tdbcCompareCode.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Khoan_doi_chieu"))
                tdbcCompareCode.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub tdbg3_NumberFormat()
        tdbg3.Columns(COL3_Period).NumberFormat = D13Format.DefaultNumber2
        tdbg3.Columns(COL3_ComparePeriod).NumberFormat = D13Format.DefaultNumber2
        tdbg3.Columns(COL3_DiffValue).NumberFormat = D13Format.DefaultNumber2
        tdbg2.Columns("Period").NumberFormat = D13Format.DefaultNumber2
        tdbg2.Columns("ComparePeriod").NumberFormat = D13Format.DefaultNumber2
        tdbg2.Columns("DiffValue").NumberFormat = D13Format.DefaultNumber2
    End Sub

    Private Sub tabMain_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tabMain.Selecting
        If e.TabPageIndex = 1 Then
            If tdbg1.RowCount > 0 Then
                LoadTDBGrid_2()
            End If
        End If
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, Panel3, tabMain)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg1, tdbg2, tdbg3)
        AnchorForControl(EnumAnchorStyles.BottomRight, pnl1)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShowColumns)
    End Sub
End Class