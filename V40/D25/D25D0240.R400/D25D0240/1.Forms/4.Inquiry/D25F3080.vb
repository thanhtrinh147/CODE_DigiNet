Imports System
Public Class D25F3080
    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable
    Dim dtCaptionCols As DataTable


#Region "Const of tdbg - Total of Columns: 44"
    Private Const COL_IsApprove As Integer = 0         ' Duyệt
    Private Const COL_BlockID As Integer = 1           ' Mã khối
    Private Const COL_BlockName As Integer = 2         ' Tên khối
    Private Const COL_DepartmentID As Integer = 3      ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 4    ' Tên phòng ban
    Private Const COL_TeamID As Integer = 5            ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 6          ' Tên tổ nhóm
    Private Const COL_RecPositionID As Integer = 7     ' Chức vụ
    Private Const COL_RecPositionName As Integer = 8   ' Tên chức vụ
    Private Const COL_WorkID As Integer = 9            ' Vị trí/công việc
    Private Const COL_WorkName As Integer = 10         ' Tên vị trí/công việc
    Private Const COL_EmployeeQTY As Integer = 11      ' Định mức
    Private Const COL_Number As Integer = 12           ' Số lượng
    Private Const COL_DateFrom As Integer = 13         ' Từ ngày
    Private Const COL_DateTo As Integer = 14           ' Đến ngày
    Private Const COL_VoucherDate As Integer = 15      ' Ngày lập
    Private Const COL_CreatorName As Integer = 16      ' Người lập
    Private Const COL_Description As Integer = 17      ' Diễn giải
    Private Const COL_ReferenceNo As Integer = 18      ' Số tham chiếu
    Private Const COL_Ref01 As Integer = 19            ' Thông tin tham chiếu 01
    Private Const COL_Ref02 As Integer = 20            ' Thông tin tham chiếu 02
    Private Const COL_Ref03 As Integer = 21            ' Thông tin tham chiếu 03
    Private Const COL_Ref04 As Integer = 22            ' Thông tin tham chiếu 04
    Private Const COL_Ref05 As Integer = 23            ' Thông tin tham chiếu 05
    Private Const COL_Ref06 As Integer = 24            ' Thông tin tham chiếu 06
    Private Const COL_Ref07 As Integer = 25            ' Thông tin tham chiếu 07
    Private Const COL_Ref08 As Integer = 26            ' Thông tin tham chiếu 08
    Private Const COL_Ref09 As Integer = 27            ' Thông tin tham chiếu 09
    Private Const COL_Ref10 As Integer = 28            ' Thông tin tham chiếu 10
    Private Const COL_Note As Integer = 29             ' Ghi chú
    Private Const COL_PlanStatusName As Integer = 30   ' Trạng thái
    Private Const COL_ApproverID As Integer = 31       ' Người duyệt
    Private Const COL_ApprovedDate As Integer = 32     ' Ngày duyệt
    Private Const COL_ApproveNumber As Integer = 33    ' SL duyệt
    Private Const COL_ApproveNotes As Integer = 34     ' Ghi chú duyệt
    Private Const COL_PlanStatusID As Integer = 35     ' PlanStatusID
    Private Const COL_TranMonth As Integer = 36        ' TranMonth
    Private Const COL_TranYear As Integer = 37         ' TranYear
    Private Const COL_CreateUserID As Integer = 38     ' CreateUserID
    Private Const COL_CreateDate As Integer = 39       ' CreatDate
    Private Const COL_LastModifyUserID As Integer = 40 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 41   ' LastModifyDate
    Private Const COL_TransID As Integer = 42          ' TransID
    Private Const COL_CreatorID As Integer = 43        ' Người lập
#End Region



    Dim dtGrid, dtTeamID, dtDepartmentID As DataTable

    Private _bIsViewPermissionOnly As Boolean = False
    Public WriteOnly Property bIsViewPermissionOnly() As Boolean
        Set(ByVal Value As Boolean)
            _bIsViewPermissionOnly = Value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRight, Panel1)
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnF12)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnAction, btnClose)

    End Sub

    Private Sub D25F3080_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D25F3080_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
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
        Select Case e.KeyCode
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub D25F3080_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        SetBackColorObligatory()
        gbEnabledUseFind = False
        Loadlanguage()
        LoadRefCaption()
        ResetColorGrid(tdbg, SPLIT0, tdbg.Splits.Count - 1)
        InputDateInTrueDBGrid(tdbg, COL_DateFrom, COL_DateTo, COL_VoucherDate, COL_ApprovedDate)
        LoadTDBCombo()
        LoadDefault()
        VisibleColumns()
        SetShortcutPopupMenu(C1CommandHolder)
        InputbyUnicode(Me, gbUnicode)
        InputDateCustomFormat(c1dateTo, c1dateFrom)
        CallD99U1111()
        CheckMenuOther()
        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SetBackColorObligatory()

        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY

        c1dateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateTo.BackColor = COLOR_BACKCOLOROBLIGATORY

        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecPositionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub LoadDefault()
        tdbcPeriodFrom.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcPeriodTo.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcBlockID.SelectedIndex = 0
        tdbcRecPositionID.SelectedIndex = 0
        c1dateFrom.Value = Now
        c1dateTo.Value = Now
    End Sub

    Private Sub VisibleColumns()
        If D25Systems.IsUseBlock Then
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(0).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(0).DisplayColumns.Item(COL_BlockName).Visible = False
        End If
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
        sSQL = "Select      0 as DisplayOrder,'%' as RecPositionID, " & sLanguage & " As RecPositionName" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "SELECT     1 as DisplayOrder,DutyID AS RecPositionID, DutyName" & sUnicode & " AS RecPositionName " & vbCrLf
        sSQL &= "FROM       D09T0211 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE      Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, RecPositionID" & vbCrLf
        LoadDataSource(tdbcRecPositionID, sSQL, gbUnicode)

        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, "D09")
    End Sub

    Private Sub LoadRefCaption()
        Dim sSQL As String = SQLStoreD25P0050("D25T2001", gbUnicode)
        Dim dtSpec As DataTable = ReturnDataTable(sSQL)
        If dtSpec.Rows.Count <= 0 Then Exit Sub

        For i As Integer = 0 To 9
            tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref01 + i).Visible = Not CBool(dtSpec.Rows(i).Item("Disabled").ToString)
            tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref01 + i).HeadingStyle.Font = FontUnicode(gbUnicode, tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref01 + i).HeadingStyle.Font.Style)
            tdbg.Columns(COL_Ref01 + i).Caption = dtSpec.Rows(i).Item("RefCaption").ToString
        Next
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Ke_hoach_tong_theF") & " - D25F3080" & UnicodeCaption(gbUnicode) ' rl3("Ke_hoach_tuyen_dung_-_D25F3080") & UnicodeCaption(gbUnicode) 'KÕ hoÁch tuyÓn dóng - D25F3080
        '================================================================ 
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rL3("Khoi") 'Khối
        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rL3("Chuc_vu") 'Chức vụ
        '================================================================ 
        btnAction.Text = rL3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnFilter.Text = rL3("_Loc") '&Lọc
        btnF12.Text = rL3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        optDate.Text = rL3("Ngay_lap") 'Ngày lập
        optPeriod.Text = rL3("Ky") 'Kỳ
        '================================================================ 
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên

        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên

        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên

        tdbcPeriodTo.Columns("Period").Caption = rL3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rL3("Ky") 'Kỳ

        tdbcRecPositionID.Columns("RecPositionID").Caption = rL3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("BlockID").Caption = rL3("Ma_khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rL3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rL3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("DepartmentName").Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rL3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("TeamName").Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionID").Caption = rL3("Chuc_vu") 'Chức vụ
        tdbg.Columns("RecPositionName").Caption = rL3("Ten_chuc_vu") 'Tên chức vụ
        tdbg.Columns("WorkID").Caption = rL3("Vi_tricong_viec") 'Vị trí/công việc
        tdbg.Columns("WorkName").Caption = rL3("Ten_vi_tricong_viec") 'Tên vị trí/công việc
        tdbg.Columns("EmployeeQTY").Caption = rL3("Dinh_muc") 'Định mức
        tdbg.Columns("Number").Caption = rL3("So_luong") 'Số lượng
        tdbg.Columns("DateFrom").Caption = rL3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rL3("Den_ngay") 'Đến ngày
        tdbg.Columns("VoucherDate").Caption = rL3("Ngay_lap") 'Ngày lập
        tdbg.Columns("CreatorName").Caption = rL3("Nguoi_lap") 'Người lập
        tdbg.Columns("Note").Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Columns("CreatorID").Caption = rL3("Nguoi_lap") 'Người lập
        tdbg.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns("ReferenceNo").Caption = rL3("So_tham_chieu")
        tdbg.Columns("PlanStatusName").Caption = rL3("Trang_thai")
        tdbg.Columns(COL_IsApprove).Caption = rL3("Duyet") 'Duyệt
        tdbg.Columns(COL_ApproveNumber).Caption = rL3("SL_duyet") 'SL duyệt
        tdbg.Columns(COL_ApprovedDate).Caption = rL3("Ngay_duyet") 'Ngày duyệt
        tdbg.Columns(COL_ApproverID).Caption = rL3("Nguoi_duyet") 'Người duyệt
        tdbg.Columns(COL_ApproveNotes).Caption = rL3("Ghi_chu_duyet") 'Ghi chú duyệt
        '================================================================ 
        mnuAdd.Text = rL3("_Them") '&Thêm
        mnuView.Text = rL3("Xe_m") 'Xe&m
        mnuEdit.Text = rL3("_Sua") '&Sửa
        mnuDelete.Text = rL3("_Xoa") '&Xóa
        mnuSysInfo.Text = rL3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuDivisionData.Text = rL3("Tach__du_lieu") 'Tách dữ liệu
        mnuFind.Text = rL3("Tim_kiem") 'Tìm kiếm
        mnuListAll.Text = rL3("Liet_ke_tat_ca") 'Liệt kê tất cả
        mnuApproved.Text = rL3("Duyet") 'Duyệt
        mnuNotApproved.Text = rL3("Bo_duyet") 'Bỏ duyệt

    End Sub
    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = SQLStoreD25P3080()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("TransID =" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenuOther()
        '*********************************
        FooterTotalGrid(tdbg, COL_DepartmentID)
        FooterSumNew(tdbg, COL_Number, COL_EmployeeQTY, COL_ApproveNumber)
    End Sub
    Private Sub CheckMenuOther()
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        mnuDivisionData.Enabled = (ReturnPermission(Me.Name) - 3 >= 0) And tdbg.RowCount > 0 And Not gbClosed

        If _bIsViewPermissionOnly Then
            mnuAdd.Enabled = False
            mnuEdit.Enabled = False
            mnuDelete.Enabled = False
        End If
    End Sub
    Private Sub CheckMenuOther_Grid()
        Dim per As Integer = ReturnPermission("D25F5601")
        mnuApproved.Enabled = (per > 1) And tdbg.RowCount > 0 And Not gbClosed And (L3Bool(tdbg(tdbg.Row, COL_IsApprove)) = False)
        mnuNotApproved.Enabled = (per > 1) And tdbg.RowCount > 0 And Not gbClosed And (L3Bool(tdbg(tdbg.Row, COL_IsApprove)))
    End Sub

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
        sSQL &= SQLNumber(optPeriod.Checked) & COMMA 'IsUsedPeriod, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub mnuAdd_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Dim f As New D25F2080
        With f
            .TransID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(True, .TransID)
            .Dispose()
        End With
    End Sub

    Private Sub mnuView_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        Dim f As New D25F2080
        With f
            .TransID = tdbg.Columns(COL_TransID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If Not CheckStore(SQLStoreD25P5555("Kiem tra truoc khi sua", 2)) Then Exit Sub 'ID 93480 21/12/2016

        Me.Cursor = Cursors.WaitCursor

        Dim f As New D25F2080
        With f
            .TransID = tdbg.Columns(COL_TransID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(False, tdbg.Columns(COL_TransID).Text)
            .Dispose()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If Not CheckStore(SQLStoreD25P5555("Kiem tra truoc khi xoa", 1)) Then Exit Sub

        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD25T2081() & vbCrLf)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub mnuNotApproved_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuNotApproved.Click 'ID 90425 04/11/2016
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If Not CheckStore(SQLStoreD25P5555("Kiem tra truoc khi bo duyet", 0)) Then Exit Sub

        Dim sSQL As New StringBuilder
        sSQL.Append(SQLUpdateD25T2081.ToString() & vbCrLf)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
            D99C0008.MsgL3(rL3("Bo_duyet_thanh_congU"))
            LoadTDBGrid(False, tdbg.Columns(COL_TransID).Text)
        Else
            D99C0008.MsgL3(rL3("Bo_duyet_khong_thanh_congU"))
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuApproved_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuApproved.Click 'ID 90425 04/11/2016
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        Dim f As New D25F2080
        With f
            .TransID = tdbg.Columns(COL_TransID).Text
            .FormState = EnumFormState.FormApprove
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(False, tdbg.Columns(COL_TransID).Text)
            .Dispose()
        End With
        Me.Cursor = Cursors.Default
    End Sub

#Region "tdbg"
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

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    Dim iHeight As Integer = 0 ' Lấy tọa độ Y của chuột click tới
    Private Sub tdbg_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseClick
        iHeight = e.Location.Y
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If iHeight <= tdbg.Splits(0).ColumnCaptionHeight Then Exit Sub
        If tdbg.RowCount <= 0 OrElse tdbg.FilterActive Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If mnuEdit.Enabled Then
            mnuEdit_Click(sender, Nothing)
        ElseIf mnuView.Enabled Then
            mnuView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub
#End Region



    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2081
    '# Created User: DUCTRONG
    '# Created Date: 07/08/2008 07:50:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2081() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2081"
        sSQL &= " Where TransID = " & SQLString(tdbg.Columns(COL_TransID).Text)
        Return sSQL
    End Function

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
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {}
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbg.Splits.Count - 1
                AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
            Next
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode) ' Dùng DLL 
    End Sub
    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        sFind = ""
        ReLoadTDBGrid()
    End Sub
#End Region
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowSave() Then Exit Sub
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
    End Sub

    Private Function AllowSave() As Boolean
        If optPeriod.Checked Then
            If tdbcPeriodFrom.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Tu_ky"))
                tdbcPeriodFrom.Focus()
                Return False
            End If
            If tdbcPeriodTo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Den_ky"))
                tdbcPeriodTo.Focus()
                Return False
            End If
        Else
            If c1dateFrom.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Tu_ngay"))
                c1dateFrom.Focus()
                Return False
            End If
            If c1dateTo.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Den_ngay"))
                c1dateTo.Focus()
                Return False
            End If
        End If
        If tdbcBlockID.Text.Trim = "" Then
            tdbcBlockID.SelectedIndex = 0
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            tdbcDepartmentID.SelectedIndex = 0
        End If
        If tdbcTeamID.Text.Trim = "" Then
            tdbcTeamID.SelectedIndex = 0
        End If
        If tdbcRecPositionID.Text.Trim = "" Then
            tdbcRecPositionID.SelectedIndex = 0
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
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcTeamID.Close, tdbcDepartmentID.Close, tdbcRecPositionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcTeamID.Validated, tdbcDepartmentID.Validated, tdbcRecPositionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
    Private Sub mnuDivisionData_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDivisionData.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If Not CheckStore(SQLStoreD25P5555("Kiem tra truoc khi tach du lieu", 3)) Then Exit Sub 'ID 93480 21/12/2016

        Me.Cursor = Cursors.WaitCursor
        Dim f As New D25F2080
        With f
            .TransID = tdbg.Columns(COL_TransID).Text
            .FormState = EnumFormState.FormOther
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(False, tdbg.Columns(COL_TransID).Text)
            .Dispose()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        CheckMenuOther_Grid()
    End Sub
    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/11/2016 09:54:57
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5555(sComment As String, iMode As Byte) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "Exec D25P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber("") & COMMA 'Type, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2081
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/11/2016 09:59:22
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2081() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Bo duyet" & vbCrlf)
        sSQL.Append("Update D25T2081 Set ")
        sSQL.Append("ApproveNumber = " & SQLNumber(0) & COMMA) 'int, NOT NULL
        sSQL.Append("ApprovedDate = " & SQLDateSave("") & COMMA) 'datetime, NULL
        sSQL.Append("ApproveNotesU = " & SQLString("") & COMMA) 'nvarchar[1000], NOT NULL
        sSQL.Append("ApproverID = " & SQLString("") & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("IsApprove = " & SQLNumber(0)) 'tinyint, NOT NULL
        sSQL.Append(" Where TransID =" & SQLString(tdbg.Columns(COL_TransID).Text))
        Return sSQL
    End Function
 
End Class