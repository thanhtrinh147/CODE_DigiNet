'#-------------------------------------------------------------------------------------
'# Created Date: 11/12/2008 11:50:01 AM
'# Created User: Đỗ Minh Dũng
'# Modify Date: 11/12/2008 11:50:01 AM
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D25F3060

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRight, GroupBox1)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShowColumns)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnAction, btnClose)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)

    End Sub

    Dim sKey As String
    Dim dtGrid As DataTable
    Dim sFind As String = ""

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Dim dtBlockID, dtDepartmentID, dtTeamID As DataTable
    Dim iPerD25F2100 As Integer = ReturnPermission("D25F2100")

#Region "Const of tdbg - Total of Columns: 68"
    Private Const COL_TransID As Integer = 0            ' TransID
    Private Const COL_AppDate As Integer = 1            ' AppDate
    Private Const COL_ApproverID As Integer = 2         ' ApproverID
    Private Const COL_Approved As Integer = 3           ' Duyệt
    Private Const COL_NotApproved As Integer = 4        ' Từ chối
    Private Const COL_CandidateID As Integer = 5        ' Mã ứng viên
    Private Const COL_CandidateName As Integer = 6      ' Họ và tên
    Private Const COL_TransferedNameD09 As Integer = 7  ' Chuyển sang HSNV
    Private Const COL_StatusName As Integer = 8         ' Trạng thái
    Private Const COL_DivisionID As Integer = 9         ' Đơn vị
    Private Const COL_DivisionName As Integer = 10      ' Tên đơn vị
    Private Const COL_BlockID As Integer = 11           ' Khối
    Private Const COL_BlockName As Integer = 12         ' Tên khối
    Private Const COL_DepartmentID As Integer = 13      ' Phòng ban
    Private Const COL_DepartmentName As Integer = 14    ' Tên phòng ban
    Private Const COL_TeamID As Integer = 15            ' Tổ nhóm
    Private Const COL_TeamName As Integer = 16          ' Tên tổ nhóm
    Private Const COL_RecPositionID As Integer = 17     ' Mã vị trí
    Private Const COL_RecPositionName As Integer = 18   ' Tên vị trí
    Private Const COL_PreparedDate As Integer = 19      ' Ngày lập
    Private Const COL_PreparerID As Integer = 20        ' Người lập
    Private Const COL_SexName As Integer = 21           ' Giới tính
    Private Const COL_Birthdate As Integer = 22         ' Ngày sinh
    Private Const COL_ContactAddress As Integer = 23    ' Địa chỉ
    Private Const COL_Telephone As Integer = 24         ' Điện thoại
    Private Const COL_Email As Integer = 25             ' Email
    Private Const COL_TransferedD09 As Integer = 26     ' TransferedD09
    Private Const COL_WorkID As Integer = 27            ' Công việc
    Private Const COL_DutyID As Integer = 28            ' Chức vụ
    Private Const COL_ProjectID As Integer = 29         ' Dự án
    Private Const COL_ProjectName As Integer = 30       ' Tên dự án
    Private Const COL_DirectManagerID As Integer = 31   ' Người quản lý trực tiếp
    Private Const COL_DirectManagerName As Integer = 32 ' Tên người quản lý trực tiếp
    Private Const COL_BeginDate As Integer = 33         ' Ngày vào làm
    Private Const COL_WorkingPlace As Integer = 34      ' Địa điểm
    Private Const COL_WorkingStatusID As Integer = 35   ' Hình thức làm việc
    Private Const COL_WorkingHours As Integer = 36      ' Thời gian làm việc
    Private Const COL_TrialPeriod As Integer = 37       ' Thời gian thử việc
    Private Const COL_TrialDateFrom As Integer = 38     ' Ngày bắt đầu TV
    Private Const COL_TrialDateTo As Integer = 39       ' Ngày kết thúc TV
    Private Const COL_Notes As Integer = 40             ' Ghi chú
    Private Const COL_OfferDate As Integer = 41         ' Ngày gởi thư nhận việc
    Private Const COL_N01Name As Integer = 42           ' N01Name
    Private Const COL_N02Name As Integer = 43           ' N02Name
    Private Const COL_N03Name As Integer = 44           ' N03Name
    Private Const COL_N04Name As Integer = 45           ' N04Name
    Private Const COL_N05Name As Integer = 46           ' N05Name
    Private Const COL_N06Name As Integer = 47           ' N06Name
    Private Const COL_N07Name As Integer = 48           ' N07Name
    Private Const COL_N08Name As Integer = 49           ' N08Name
    Private Const COL_N09Name As Integer = 50           ' N09Name
    Private Const COL_N10Name As Integer = 51           ' N10Name
    Private Const COL_N11Name As Integer = 52           ' N11Name
    Private Const COL_N12Name As Integer = 53           ' N12Name
    Private Const COL_N13Name As Integer = 54           ' N13Name
    Private Const COL_N14Name As Integer = 55           ' N14Name
    Private Const COL_N15Name As Integer = 56           ' N15Name
    Private Const COL_N16Name As Integer = 57           ' N16Name
    Private Const COL_N17Name As Integer = 58           ' N17Name
    Private Const COL_N18Name As Integer = 59           ' N18Name
    Private Const COL_N19Name As Integer = 60           ' N19Name
    Private Const COL_N20Name As Integer = 61           ' N20Name
    Private Const COL_IsSendMail As Integer = 62        ' Đã gửi mail
    Private Const COL_CreateUserID As Integer = 63      ' CreateUserID
    Private Const COL_CreateDate As Integer = 64        ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 65  ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 66    ' LastModifyDate
    Private Const COL_InterviewFileID As Integer = 67   ' InterviewFileID
#End Region



    Private Sub D25F3060_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt Then
        ElseIf e.Control Then
        Else
            Select Case e.KeyCode
                Case Keys.Enter
                    UseEnterAsTab(Me, True)
                Case Keys.F5
                    btnFilter_Click(sender, Nothing)
                Case Keys.F11
                    HotKeyF11(Me, tdbg)
                    'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
                Case Keys.F12 ' Mở
                    btnShowColumns_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

    Private Sub D25F3060_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()

        Loadlanguage()
        LoadNxxID()
        SetBackColorObligatory()
        ResetColorGrid(tdbg, 0, 2)
        ResetSplitDividerSize(tdbg)
        LoadTDBCombo()
        LoadDefault()
        VisibleBlock()
        '****************************
        dtF12 = Nothing
        CallD99U1111()
        '****************************
        InputbyUnicode(Me, gbUnicode)
        '****************************
        InputDateCustomFormat(c1dateDateTo, c1dateDateFrom)
        InputDateInTrueDBGrid(tdbg, COL_PreparedDate, COL_Birthdate, COL_BeginDate, COL_OfferDate)
        SetShortcutPopupMenu(C1CommandHolder)
        SetResolutionForm(Me, C1ContextMenu)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Truy_van_quyet_dinh_tuyen_dung_-_D25F3060") & UnicodeCaption(gbUnicode)  'Truy vÊn quyÕt ¢Ünh tuyÓn dóng - D25F3060
        '================================================================ 
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rL3("Khoi") 'Khối
        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rL3("Vi_tri") 'Vị trí
        lblteDateFrom.Text = rL3("Ngay") 'Ngày
        lblStatusID.Text = rL3("Trang_thai") 'Trạng thái
        lblTransferedD09.Text = rL3("Chuyen_sang_HSNV") 'Chuyển sang HSNV
        lblDivisionID.Text = rL3("Don_vi") 'Đơn vị
        '================================================================ 
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnAction.Text = rL3("_Thuc_hien_") '&Thực hiện...
        btnFilter.Text = rL3("Loc") & " (F5)" 'Lọc
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnShowColumns.Text = rL3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        chkIsAppDecision.Text = rL3("Quyet_dinh_da_duyet") 'Quyết định đã duyệt
        '================================================================ 
        tdbcRecPositionID.Columns("RecPositionID").Caption = rL3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rL3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
        tdbcStatusID.Columns("StatusID").Caption = rL3("Ma") 'Mã
        tdbcStatusID.Columns("StatusName").Caption = rL3("Ten") 'Tên
        tdbcTransferedD09.Columns("TransferedD09").Caption = rL3("Ma") 'Mã
        tdbcTransferedD09.Columns("TransferedNameD09").Caption = rL3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_Approved).Caption = rL3("Duyet") 'Duyệt
        tdbg.Columns(COL_CandidateID).Caption = rL3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns(COL_CandidateName).Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(COL_TransferedNameD09).Caption = rL3("Chuyen_sang_HSNV") 'Chuyển sang HSNV
        tdbg.Columns(COL_DivisionID).Caption = rL3("Don_vi") 'Đơn vị
        tdbg.Columns(COL_DivisionName).Caption = rL3("Ten_don_vi") 'Tên đơn vị
        tdbg.Columns(COL_BlockID).Caption = rL3("Khoi") 'Khối
        tdbg.Columns(COL_BlockName).Caption = rL3("Ten_khoi") 'Tên khối
        tdbg.Columns(COL_DepartmentID).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_TeamName).Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_RecPositionID).Caption = rL3("Ma_vi_tri") 'Mã vị trí
        tdbg.Columns(COL_RecPositionName).Caption = rL3("Ten_vi_tri") 'Tên vị trí
        tdbg.Columns(COL_PreparedDate).Caption = rL3("Ngay_lap") 'Ngày lập
        tdbg.Columns(COL_PreparerID).Caption = rL3("Nguoi_lap") 'Người lập
        tdbg.Columns(COL_SexName).Caption = rL3("Gioi_tinh") 'Giới tính
        tdbg.Columns(COL_Birthdate).Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns(COL_ContactAddress).Caption = rL3("Dia_chi") 'Địa chỉ
        tdbg.Columns(COL_Telephone).Caption = rL3("Dien_thoai") 'Điện thoại
        tdbg.Columns(COL_WorkID).Caption = rL3("Cong_viec") 'Công việc
        tdbg.Columns(COL_DutyID).Caption = rL3("Chuc_vu") 'Chức vụ
        tdbg.Columns(COL_ProjectID).Caption = rL3("Cong_trinh") 'Dự án
        tdbg.Columns(COL_ProjectName).Caption = rL3("Ten_cong_trinh") 'Tên dự án
        tdbg.Columns(COL_DirectManagerID).Caption = rL3("Nguoi_quan_ly_truc_tiep") 'Người quản lý trực tiếp
        tdbg.Columns(COL_DirectManagerName).Caption = rL3("Ten_nguoi_quan_ly_truc_tiep") 'Tên người quản lý trực tiếp
        tdbg.Columns(COL_BeginDate).Caption = rL3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns(COL_WorkingPlace).Caption = rL3("Dia_diem") 'Địa điểm
        tdbg.Columns(COL_WorkingStatusID).Caption = rL3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        tdbg.Columns(COL_WorkingHours).Caption = rL3("Thoi_gian_lam_viec") 'Thời gian làm việc
        tdbg.Columns(COL_TrialPeriod).Caption = rL3("Thoi_gian_thu_viec") 'Thời gian thử việc
        tdbg.Columns(COL_TrialDateFrom).Caption = rL3("Ngay_bat_dau_TV") 'Ngày bắt đầu TV
        tdbg.Columns(COL_TrialDateTo).Caption = rL3("Ngay_ket_thuc_TV") 'Ngày kết thúc TV
        tdbg.Columns(COL_Notes).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_OfferDate).Caption = rL3("Ngay_goi_thu_nhan_viec") 'Ngày gởi thư nhận việc
        tdbg.Columns(COL_StatusName).Caption = rL3("Trang_thai") 'Trạng thái
        '================================================================ 
        mnuAdd.Text = rL3("_Them") '&Thêm
        mnuView.Text = rL3("Xe_m") 'Xe&m
        mnuEdit.Text = rL3("_Sua") '&Sửa
        mnuDelete.Text = rL3("_Xoa") '&Xóa
        mnuSysInfo.Text = rL3("Thong_tin__he_thong") 'Thông tin &hệ thống

        'ID 100088 19.09.2017
        'mnuPrint.Text = rL3("_In") '&In
        mnuPrint.Text = rL3("_InGui_mail") '&In/Gửi mail

        mnuTranferAll.Text = rL3("Chuyen_sang_HSNV") 'Chuyển sang HSNV
        mnuRemTransfer.Text = rL3("Bo_chuyen") 'Bỏ chuyển
        C1CommandLink2.Text = mnuRemTransfer.Text
        mnuTransfer.Text = rL3("_Duyet") '&Duyệt
        mnuDeleteTransfer.Text = rL3("_Bo_duyet") '&Bỏ duyệt
        C1CommandLink4.Text = mnuDeleteTransfer.Text
        mnuUpdateList.Text = rL3("Ca_p_nhat_thong_tin_trung_tuyen") 'Cậ&p nhật thông tin trúng tuyển
        mnuFind.Text = rL3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rL3("_Liet_ke_tat_ca") '&Liệt kê tất cả

        tdbg.Columns(COL_NotApproved).Caption = rL3("Tu_choi")
        'ID 104029 10.10.2017
        tdbg.Columns(COL_IsSendMail).Caption = rL3("Da_gui_mail") 'Đã gửi mail
    End Sub

    Private Sub SetBackColorObligatory()
        c1dateDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcBlockID
        'LoadtdbcBlockID(tdbcBlockID, gbUnicode)
        dtBlockID = ReturnTableBlockID(, , gbUnicode)
        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(, , gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(, , gbUnicode)

        'Load tdbcRecPositionID
        LoadDataSource(tdbcRecPositionID, ReturnTableDutyIDRec(True, gbUnicode), gbUnicode)
        'Load tdbcDivisionID
        LoadCboDivisionIDD09(tdbcDivisionID, "D09", True, gbUnicode)
        tdbcDivisionID.SelectedIndex = 0 'Value = gsDivisionID

        'id 75368 5/6/2015
        'LoadTransferedD09
        sSQL = "SELECT ID as TransferedD09, Name" & IIf(geLanguage = EnumLanguage.English, "01", "84").ToString & UnicodeJoin(gbUnicode) & " AS TransferedNameD09" & vbCrLf
        sSQL &= "FROM D25N5555 ('D25F3060','RecruitmentDecision','','','','')"
        LoadDataSource(tdbcTransferedD09, sSQL, gbUnicode)

        'ID 78934 11/12/2015
        sSQL = "-- Do nguon trang thai" & vbCrLf
        sSQL &= "SELECT '%' As StatusID, " & AllName & " As StatusName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT '00001' As StatusID, N'" & rL3("Dat_co_nhan_viec") & "' As StatusName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT '00002' As StatusID, N'" & rL3("Dat_khong_nhan_viec") & "' As StatusName" & vbCrLf
        sSQL &= "ORDER BY StatusID"
        LoadDataSource(tdbcStatusID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadDefault()
        tdbcBlockID.SelectedIndex = 0
        tdbcRecPositionID.SelectedIndex = 0
        tdbcStatusID.SelectedIndex = 0
        '********************
        'ID 78934 11/12/2015
        c1dateDateFrom.Value = "1" & "/" & giTranMonth & "/" & giTranYear 'Default ngày đầu tháng
        c1dateDateTo.Value = Date.DaysInMonth(giTranYear, giTranMonth) & "/" & giTranMonth & "/" & giTranYear 'Default Ngày cuối tháng
        '********************
        CheckMenuOther()
    End Sub

    Private Sub VisibleBlock()
        Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockName).Visible = False
        End If
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bFlagAdd As Boolean = False)
        Dim sSQL As String = SQLStoreD25P3160()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)

        If bFlagAdd = True Then
            Dim dr() As DataRow = dtGrid.Select("TransID=" & SQLString(sKey))
            If dr.Length > 0 Then tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(0))
            'If dr.Length > 0 Then tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(0))
        End If
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub CheckMenuOther()
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        If tdbg.RowCount <= 0 Then
            mnuTranferAll.Enabled = False
        Else
            Dim drT() As DataRow = dtGrid.Select("Approved = 1 And TransferedD09=0")
            mnuTranferAll.Enabled = drT.Length > 0
        End If
    End Sub
    Private Sub ResetGrid()
        CheckMenuOther()
        '********************
        FooterTotalGrid(tdbg, COL_CandidateName)
    End Sub

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        Dim bTransferedD09 As Boolean = L3Bool(tdbg.Columns(COL_TransferedD09).Text)
        Dim bApproved As Boolean = L3Bool(tdbg.Columns(COL_Approved).Text)
        Dim bNotApproved As Boolean = L3Bool(tdbg.Columns(COL_NotApproved).Text)
        Dim iCount As Integer = tdbg.RowCount

        mnuTransfer.Enabled = Not bTransferedD09 And iPerD25F2100 >= 2 And iCount > 0
        mnuDeleteTransfer.Enabled = Not bTransferedD09 And (bApproved Or bNotApproved) And iPerD25F2100 >= 2 And iCount > 0

        mnuToEmployeeFiles.Enabled = Not bTransferedD09 And bApproved And iCount > 0
        mnuRemTransfer.Enabled = (tdbg.Columns(COL_TransferedD09).Text = "2") And iCount > 0
        'mnuUpdateList.Enabled = Not bTransferedD09 And iCount > 0
        mnuUpdateList.Enabled = iCount > 0
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 12/04/2012 01:18:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666(ByVal sFormID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID=" & SQLString(gsUserID)
        sSQL &= " And HostID=" & SQLString(My.Computer.Name)
        sSQL &= " And FormID= " & SQLString(sFormID) 'D25F2053'"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 11/04/2012 01:33:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666(ByVal dr As DataRow) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, Key01ID, FormID ")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
        sSQL.Append(SQLString(dr.Item("CandidateID")) & COMMA) 'Key01ID, nvarchar[500], NULL
        sSQL.Append(SQLString("D25F2053")) 'FormID, varchar[50], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 11/04/2012 01:35:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim dtTable As DataTable = dtGrid.DefaultView.ToTable
        Dim dr() As DataRow = dtTable.Select("Approved = 1 And TransferedD09=0")
        For i As Integer = 0 To dr.Length - 1
            sSQL.Append(SQLInsertD09T6666(dr(i)))
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next

        Return sRet
    End Function


    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If AllowFilter() = False Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowFilter() As Boolean
        If c1dateDateFrom.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ngay"))
            c1dateDateFrom.Focus()
            Return False
        End If
        If c1dateDateTo.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ngay"))
            c1dateDateTo.Focus()
            Return False
        End If

        If CDate(c1dateDateFrom.Text) > CDate(c1dateDateTo.Text) Then
            D99C0008.MsgL3(rL3("Ngay_khong_hop_le"))
            c1dateDateFrom.Focus()
            Return False
        End If
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblDivisionID.Text)
            tdbcDivisionID.Focus()
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
        If tdbcRecPositionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Vi_tri"))
            tdbcRecPositionID.Focus()
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
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)

        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcDivisionID"

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then tdbcDivisionID.Text = ""
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        LoadtdbcBlockID(tdbcBlockID, dtBlockID, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        tdbcBlockID.SelectedIndex = 0
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

            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        End If
        tdbcDepartmentID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcRecPositionID"

    Private Sub tdbcRecPositionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.LostFocus
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then tdbcRecPositionID.Text = ""
    End Sub

#End Region

#Region "Events tdbcStatusID"

    Private Sub tdbcStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStatusID.LostFocus
        If tdbcStatusID.FindStringExact(tdbcStatusID.Text) = -1 Then tdbcStatusID.Text = ""
    End Sub
#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close, tdbcDivisionID.Close, tdbcStatusID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated, tdbcDivisionID.Validated, tdbcStatusID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(Me, New Point(btnAction.Left, btnAction.Top))
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If mnuEdit.Enabled Then
            mnuEdit_Click(Nothing, Nothing)
        ElseIf mnuView.Enabled Then
            mnuView_Click(Nothing, Nothing)
        End If
    End Sub

    'Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
    '    If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
    'End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    'Private sFind As String = ""

    Dim dtCaptionCols As DataTable

    'DLL sử dụng Properties
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Giống sự kiện Finder_FindClick
        End Set
    End Property

    '*****************************
    Private Sub mnsFind_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_CandidateID}
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbg.Splits.Count - 1
                AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
            Next
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode) ' Dùng DLL 
    End Sub

    Private Sub mnsListAll_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub


#Region "Context Menu items"

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub

        Dim f As New D25F2060
        With f
            .FormState = EnumFormState.FormAdd
            '.dtD25F3060 = dtGrid
            .TransID = ""
            .ShowDialog()
            sKey = .TransID
            .Dispose()
        End With

        If f.bSaved Then
            LoadTDBGrid(True)
        End If
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If L3Bool(tdbg.Columns(COL_Approved).Text) Then
            D99C0008.MsgL3(rL3("Quyet_dinh_nay_da_duoc_duyet_Ban_khong_duoc_phep_sua"))
            Exit Sub
        End If
        If L3Bool(tdbg.Columns(COL_NotApproved).Text) Then
            D99C0008.MsgL3(rL3("Quyet_dinh_nay_da_tu_choi_duyet_Ban_khong_duoc_phep_sua"))
            Exit Sub
        End If
        Dim f As New D25F2060
        With f
            '.dtD25F3060 = dtGrid
            .TransID = tdbg.Columns(COL_TransID).Text
            .DivisionID = tdbg.Columns(COL_DivisionID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
        End With

        If f.bSaved Then
            Dim iBookmark As Integer = tdbg.Bookmark
            LoadTDBGrid()
            tdbg.Bookmark = iBookmark
        End If
    End Sub

    Private Sub mnuView_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        Dim f As New D25F2060

        With f
            '.dtD25F3060 = dtGrid
            .TransID = tdbg.Columns(COL_TransID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()

            .Dispose()
        End With
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        If L3Bool(tdbg.Columns(COL_Approved).Text) Then
            D99C0008.MsgL3(rL3("Quyet_dinh_nay_da_duoc_duyet_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If
        If L3Bool(tdbg.Columns(COL_NotApproved).Text) Then
            D99C0008.MsgL3(rL3("Quyet_dinh_nay_da_tu_choi_duyet_Ban_khong_duoc_phep_xoa"))
            Exit Sub
        End If

        Dim sSQL As String = ""
        sSQL = "Delete D25T2061 Where TransID = " & SQLString(tdbg.Columns(COL_TransID).Text) & " And CandidateID= " & SQLString(tdbg.Columns(COL_CandidateID).Text) & vbCrLf

        Dim bResult As Boolean
        bResult = ExecuteSQL(sSQL)
        If bResult Then
            DeleteOK()
            Dim iBookmark As Integer = -1
            If tdbg.Bookmark - 1 > 0 Then
                iBookmark = tdbg.Bookmark - 1
            End If
            LoadTDBGrid()
            If iBookmark > -1 Then tdbg.Bookmark = iBookmark
        Else
            DeleteNotOK()
        End If
    End Sub


    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub mnuToEmployeeFiles_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuToEmployeeFiles.Click
        Dim f As New D25F2053
        With f
            .IsOnlyView = False
            .TransID = tdbg.Columns(COL_TransID).Text
            .Mode = 1
            .ShowDialog()
            .Dispose()
        End With

        If f.bSaved Then
            Dim iBookmark As Integer = tdbg.Bookmark
            LoadTDBGrid()
            tdbg.Bookmark = iBookmark
        End If

    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        'Dim f As New D25M0340
        'With f
        '    .FormActive = enumD25E0340Form.D25F4080
        '    .ShowDialog()
        '    .Dispose()
        'End With

        Dim sSQL As New StringBuilder
        sSQL.AppendLine(SQLDeleteD09T6666("D25F3060"))
        sSQL.AppendLine(SQLInsertD09T6666().ToString)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If Not bRunSQL Then Exit Sub
        '-------------------------------
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormCall", "D25F3060")
        SetProperties(arrPro, "DateFrom", CType(c1dateDateFrom.Value, String))
        SetProperties(arrPro, "DateTo", CType(c1dateDateTo.Value, String))

        'id 71427 12/6/2015
        SetProperties(arrPro, "DivisionID", ReturnValueC1Combo(tdbcDivisionID))
        SetProperties(arrPro, "DepartmentID", ReturnValueC1Combo(tdbcDepartmentID))
        SetProperties(arrPro, "TeamID", ReturnValueC1Combo(tdbcTeamID))
        SetProperties(arrPro, "RecPositionID", ReturnValueC1Combo(tdbcRecPositionID))

        CallFormShow(Me, "D25D0340", "D25F4080", arrPro)
    End Sub

    Private Sub mnuRemTransfer_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRemTransfer.Click
        'Modify 05/12/2012 - ID 51366
        'If Not CheckStore(SQLStoreD25P0101(0)) Then Exit Sub
        Dim sSQL As String = ""
        sSQL &= SQLStoreD25P0101(1) & vbCrLf
        If ExecuteSQL(sSQL) Then
            SaveOK()

            Dim iBookmark As Integer = tdbg.Bookmark
            LoadTDBGrid()
            tdbg.Bookmark = iBookmark

        Else
            SaveNotOK()
        End If
    End Sub

    Private Sub mnuUpdateList_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuUpdateList.Click
        'Dim f As New D25F2052
        'With f
        '    .TransID = tdbg.Columns(COL_TransID).Text
        '    .CandidateID = tdbg.Columns(COL_CandidateID).Text
        '    .WorkingStatusID = tdbg.Columns(COL_WorkingStatusID).Text
        '    .ShowDialog()
        '    .Dispose()
        'End With

        'If f.bSaved Then
        '    Dim iBookmark As Integer = tdbg.Bookmark
        '    LoadTDBGrid()
        '    tdbg.Bookmark = iBookmark
        'End If
        'ID 99824 28.09.2017
        Dim f As New D25F2054
        With f
            .sDateForm = c1dateDateFrom.Text
            .sDateTo = c1dateDateTo.Text
            .sDivitionID = ReturnValueC1Combo(tdbcDivisionID)
            .sBlockID = ReturnValueC1Combo(tdbcBlockID)
            .sDepartmentID = ReturnValueC1Combo(tdbcDepartmentID)
            .sTeamID = ReturnValueC1Combo(tdbcTeamID)
            .sRecPositionID = ReturnValueC1Combo(tdbcRecPositionID)
            .ShowDialog()
            .Dispose()
        End With

        If f.bSaveOK Then
            LoadTDBGrid()
        End If
    End Sub

    Private Sub mnuDeleteTransfer_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDeleteTransfer.Click
        Dim sSQL As String = SQLUpdateD25T2061.ToString
        ExecuteSQLNoTransaction(sSQL)

        Dim iBookmark As Integer = tdbg.Bookmark
        LoadTDBGrid()
        tdbg.Bookmark = iBookmark

    End Sub

    Private Sub mnuTransfer_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransfer.Click
        Dim f As New D25F2100
        With f
            .dtD25F3060 = dtGrid
            .TransID = tdbg.Columns(COL_TransID).Text
            .FormState = EnumFormState.FormEdit
            sKey = .TransID
            .ShowDialog()
            .Dispose()
        End With

        If f.bSaved Then
            'Dim iBookmark As Integer = tdbg.Bookmark
            LoadTDBGrid()
            'tdbg.Bookmark = iBookmark
        End If
    End Sub

#End Region

    'ID 81044 27/10/2015
    Private Sub LoadNxxID()
        'Load captions of N01ID->N20ID, NewN01 -> NewN20ID
        Dim dtNxxID As DataTable = ReturnDataTable("Select Description" & UnicodeJoin(gbUnicode) & " As Description, TypeID, Disabled From D09T0010  WITH(NOLOCK) Order by TypeID")
        If dtNxxID.Rows.Count > 0 Then
            Try
                For i As Integer = 0 To 19
                    tdbg.Columns(COL_N01name + i).Caption = dtNxxID.Rows(i).Item("Description").ToString
                    tdbg.Splits(SPLIT2).DisplayColumns(COL_N01Name + i).Visible = Not L3Bool(dtNxxID.Rows(i).Item("Disabled"))
                    tdbg.Splits(SPLIT2).DisplayColumns(COL_N01Name + i).HeadingStyle.Font = FontUnicode(gbUnicode)
                Next i
            Catch ex As Exception
            End Try
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P0101
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 29/12/2008 02:44:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P0101(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P0101 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'DecisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransID).Text) 'TransID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3160
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 11/12/2015 09:48:29
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3160() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P3160 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateDateFrom.Text) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateTo.Text) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'PositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsAppDecision.Checked) & COMMA 'IsAppDecision, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D25F3060") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTransferedD09)) & COMMA 'TransferedD09, varchar[10], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcStatusID)) 'StatusID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2061
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/01/2011 03:03:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2061() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T2061 Set ")
        sSQL.Append("Approved = " & SQLNumber(0) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("NotApproved = " & SQLNumber(0) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("AppDate = " & SQLDateSave("") & COMMA) 'datetime, NOT NULL
        sSQL.Append("ApproverID = " & SQLString("")) 'varchar[50], NOT NULL
        sSQL.Append(" Where TransID=" & SQLString(tdbg.Columns(COL_TransID).Text) & " And CandidateID= " & SQLString(tdbg.Columns(COL_CandidateID).Text))
        Return sSQL
    End Function

    Private Sub mnuTranferAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTranferAll.Click
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLInsertD09T6666s())
        If sSQL.ToString = "" Then Exit Sub
        Dim sRet As New StringBuilder
        sRet.Append(SQLDeleteD09T6666("D25F2053") & vbCrLf)
        sRet.Append(sSQL)
        Dim bRunEXE As Boolean = ExecuteSQL(sRet.ToString)
        If Not bRunEXE Then Exit Sub

        Dim f As New D25F2053
        With f
            .IsOnlyView = False
            .TransID = "%"
            .Mode = 0
            .ShowDialog()
            .Dispose()
        End With

        If f.bSaved Then
            Dim iBookmark As Integer = tdbg.Bookmark
            LoadTDBGrid()
            tdbg.Bookmark = iBookmark
        End If
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: xuanhoa
    '# Created Date: 12/06/2015 11:31:05
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert bang tam D09T6666" & vbCrLf)
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, " & vbCrLf)
            sSQL.Append("FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_InterviewFileID)) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CandidateID)) & COMMA & vbCrLf) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub btnShowColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD99U1111(Optional ByVal bLoad As Boolean = True, Optional ByVal iButton As Object = 0)
        Dim arrColObligatory() As Object = {COL_Approved}
        Dim arrColObligatory1() As Object = {COL_CandidateID}
        If bLoad Then
            usrOption.AddColVisible(tdbg, SPLIT0, dtF12, , arrColObligatory, COL_Approved, COL_NotApproved) 'Duyệt hết split 0 vì có hiển thị các cột ở cuối cùng như COL_D08T0300_Status
            usrOption.AddColVisible(tdbg, SPLIT1, dtF12, , arrColObligatory1, COL_CandidateID) 'split1
            usrOption.AddColVisible(tdbg, SPLIT2, dtF12, , , COL_DivisionID) 'split2
        End If
        usrOption.picClose_Click(Nothing, Nothing)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12, , , , iButton)
    End Sub

End Class
