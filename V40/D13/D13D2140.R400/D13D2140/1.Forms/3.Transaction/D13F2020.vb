Imports System.Text

Public Class D13F2020

#Region "Const of tdbg"
    Private Const COL_AbsentVoucherID As Integer = 0   ' Mã phiếu ngầm
    Private Const COL_EntryDate As Integer = 1         ' Ngày phiếu
    Private Const COL_AbsentVoucherNo As Integer = 2   ' Số phiếu
    Private Const COL_DepartmentID As Integer = 3      ' Phòng ban
    Private Const COL_TeamID As Integer = 4            ' Tổ nhóm 
    Private Const COL_PayrollVoucherID As Integer = 5  ' Mã hồ sơ
    Private Const COL_PayrollVoucherNo As Integer = 6  ' Hồ sơ lương
    Private Const COL_DateFrom As Integer = 7          ' Từ ngày
    Private Const COL_DateTo As Integer = 8            ' Đến ngày
    Private Const COL_Remark As Integer = 9            ' Ghi chú
    Private Const COL_CreateDate As Integer = 10       ' CreateDate
    Private Const COL_CreateUserID As Integer = 11     ' CreateUserID
    Private Const COL_LastModifyDate As Integer = 12   ' LastModifyDate
    Private Const COL_LastModifyUserID As Integer = 13 ' LastModifyUserID
    Private Const COL_DepartmentName As Integer = 14   ' DepartmentName
    Private Const COL_TeamName As Integer = 15         ' TeamName
    Private Const COL_AbsentTypeFrom As Integer = 16   ' AbsentTypeFrom
    Private Const COL_AbsentTypeTo As Integer = 17     ' AbsentTypeTo
    '   Private Const COL_PayrollVoucherID As Integer = 18 ' PayrollVoucherID
    Private Const COL_VoucherDate As Integer = 19      ' VoucherDate
    Private Const COL_Description As Integer = 20      ' Description
    Private Const COL_TransTypeID As Integer = 21      ' TransTypeID
    Private Const COL_AttMode As Integer = 22          ' AttMode
    Private Const COL_Locked As Integer = 23         ' Đã khóa
    Private Const COL_LockedUserID As Integer = 24     ' LockedUserID
    Private Const COL_LockedDate As Integer = 25       ' LockedDate
#End Region

    Private gbEnabledUseFind As Boolean = False
    Private sKey As String
    Private sFind As String = ""
    Private sPayrollVoucherID As String

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_AbsentVoucherID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PayrollVoucherID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_phieu_dieu_chinh_thu_nhap_-_D13F2020") & UnicodeCaption(gbUnicode) 'Danh sÀch phiÕu ¢iÒu chÙnh thu nhËp - D13F2020
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        '================================================================ 
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm 
        tdbg.Columns("PayrollVoucherID").Caption = rl3("Ma_ho_so") 'Mã hồ sơ
        tdbg.Columns("PayrollVoucherNo").Caption = rl3("Ho_so_luong") 'Hồ sơ lương
        tdbg.Columns("DateFrom").Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns("Remark").Caption = rl3("Dien_giai") 'Ghi chú
        '================================================================ 
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuSysInfo.Text = rl3("Lich_su_tac_dong") 'Lịch sử tác động
        mnuCheck.Text = rl3("_Chi_tiet")
        mnuLockVoucher.Text = rl3("Khoa__phieu") 'Khóa &phiếu
        mnuAdjustAttendance.Text = rl3("Dieu__chinh_phieu_cham_cong") 'Điều &chỉnh phiếu chấm công
    End Sub

    Private iPerF5700 As Integer = 0
    Private dtGrid As DataTable
    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P2024()
        Dim dtGrid As DataTable = ReturnDataTable(sSQL)
        If iPerF5700 = 0 Then
            dtGrid = ReturnTableFilter(dtGrid, "CreateUserID = " & SQLString(gsUserID))
        End If
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
        If sKey <> "" Then 'Khi Thêm mới hoặc Sửa đều thực thi
            Dim dt As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt.Select(tdbg.Columns(COL_AbsentVoucherID).DataField & "=" & SQLString(sKey), dt.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt.Rows.IndexOf(dr(0))
            If Not tdbg.Focused Then tdbg.Focus()
        End If
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        mnuCheck.Enabled = tdbg.RowCount > 0 And ReturnPermission(Me.Name) >= 1
        CheckMenuOther()
    End Sub

    Dim iPerD13F5557 As Integer = 0
    ' update 29/7/2013 id 58217 
    Private Sub CheckMenuOther()
        'Sáng nếu Quyền (form D13F5557) > 0 và @IsLocked = 1 
        mnuLockVoucher.Enabled = tdbg.RowCount > 0 And Not gbClosed And iPerD13F5557 >= 2 And Not L3Bool(tdbg.Columns(COL_Locked).Text)
    End Sub

    Private Sub D13F2020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        iPerD13F5557 = ReturnPermission("D13F5557") ' update 29/7/2013 id 58217 
        iPerF5700 = ReturnPermission("D13F5700")
        SetShortcutPopupMenu(Me.C1CommandHolder)
        Loadlanguage()
        ResetColorGrid(tdbg)
        gbEnabledUseFind = False
        LoadTDBGrid(True)
        '*************************
        ' update 29/7/2013 id 58217 
        CheckPerF5700(0, lblPerF5700, iPerF5700)
        '*************************]
        InputDateInTrueDBGrid(tdbg, COL_EntryDate, COL_DateFrom, COL_DateTo)

        SetResolutionForm(Me, Me.C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.RowCount < 1 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If mnuEdit.Enabled Then
            mnuEdit_Click(sender, Nothing)
        Else
            mnuView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        If e.ColIndex = COL_DepartmentID Then
            e.CellTip = tdbg.Columns(COL_DepartmentName).Text
        ElseIf e.ColIndex = COL_TeamID Then
            e.CellTip = tdbg.Columns(COL_TeamName).Text
        Else
            e.CellTip = ""
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.RowCount < 1 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            If mnuEdit.Enabled Then
                mnuEdit_Click(sender, Nothing)
            Else
                mnuView_Click(sender, Nothing)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        CheckMenuOther()
    End Sub

    Private Sub mnuView_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim f As New D13F2021
        f.AbsentVoucherID = tdbg.Columns(COL_AbsentVoucherID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Function CheckLocked() As Boolean
        If L3Bool(tdbg.Columns(COL_Locked).Text) Then
            D99C0008.MsgL3(rL3("MSG000003"))
            Return False
        End If
        Return True
    End Function

    Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        If Not CheckLocked() Then Exit Sub
        If Not CheckPerF5700(1, Nothing, iPerF5700, tdbg.Columns(COL_CreateUserID).Text) Then Exit Sub

        If CheckStore(SQLStoreD13P5555(2)) Then
            Dim Bookmark As Integer
            If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
            Dim f As New D13F2021
            With f
                .AbsentVoucherID = tdbg.Columns(COL_AbsentVoucherID).Text
                .OldPayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
                .FormState = EnumFormState.FormEdit
                .ShowDialog()
                .Dispose()
                If .SavedOk Then
                    LoadTDBGrid(False, tdbg.Columns(COL_AbsentVoucherID).Text)
                End If
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            End With
        End If
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Try
            Dim f As New D13F2021
            With f
                .AbsentVoucherID = ""
                .NewPayrollVoucherID = ""
                .FormState = EnumFormState.FormAdd
                .ShowDialog()
                sKey = .AbsentVoucherID
                sPayrollVoucherID = .NewPayrollVoucherID
                .Dispose()
                If .SavedOk Then LoadTDBGrid(True, sKey) 'sPayrollVoucherID)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D29F5558") '  Code cũ truyền là D29F5558
        SetProperties(arrPro, "AuditCode", "TimeSheetRecording")
        SetProperties(arrPro, "AuditItemID", tdbg.Columns(COL_AbsentVoucherID).Text)
        SetProperties(arrPro, "mode", "1")
        SetProperties(arrPro, "CreateUserID", tdbg.Columns(COL_CreateUserID).Text)
        SetProperties(arrPro, "CreateDate", tdbg.Columns(COL_CreateDate).Text)

        CallFormShow(Me, "D91D0640", "D91F1655", arrPro)

        '        Dim frm As New D91F5558
        '        With frm
        '            .FormName = "D91F1655"
        '            .FormPermission = "D29F5558"  'Màn hình phân quyền
        '            .ID01 = "TimeSheetRecording" 'AuditCode
        '            .ID02 = tdbg.Columns(COL_AbsentVoucherID).Text 'AuditItemID
        '            .ID03 = "1" 'Mode
        '            .ID04 = tdbg.Columns(COL_CreateUserID).Text 'CreateUserID
        '            .ID05 = tdbg.Columns(COL_CreateDate).Text 'CreateDate
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        If Not CheckLocked() Then Exit Sub
        If Not CheckPerF5700(2, Nothing, iPerF5700, tdbg.Columns(COL_CreateUserID).Text) Then Exit Sub

        Dim sSQL As New StringBuilder("")
        Dim iBookmark As Integer
        Dim bResult As Boolean

        Dim Msg As Windows.Forms.DialogResult
        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            Dim sRet As String = ""

            If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

            'Kiểm tra trong danh mục phiếu chấm công nhật
            If CheckStore(SQLStoreD13P5555(1)) Then
                sSQL = New StringBuilder("")
                sSQL.Append("Select 1 From D13T0103 D13 WITH (NOLOCK) Where AbsentVoucherID=" & SQLString(tdbg.Columns(COL_AbsentVoucherID).Text) & vbCrLf)
                sRet = ReturnScalar(sSQL.ToString)

                sSQL = New StringBuilder("")
                If sRet <> "" Then
                    Msg = D99C0008.MsgAsk(rL3("Phieu_nay_da_duoc_cham_cong_Ban_co_that_su_muon_xoa_khong"), MessageBoxDefaultButton.Button2)
                    If Msg = Windows.Forms.DialogResult.Yes Then
                        'Xóa Detail
                        sSQL.Append(SQLDeleteD15T2020() & vbCrLf)
                        sSQL.Append(SQLDeleteD13T2031() & vbCrLf)
                        sSQL.Append(SQLDeleteD13T0103() & vbCrLf)
                        'Update 17/11/2011: incident 44428
                        sSQL.Append(SQLDeleteD13T0108() & vbCrLf)

                        'Xóa Master
                        sSQL.Append(SQLDeleteD13T0102() & vbCrLf)
                        'Audit
                        sSQL.Append(SQLStoreD09P6210("TimeSheetRecording", tdbg.Columns(COL_AbsentVoucherID).Text, "03", tdbg.Columns(COL_AbsentVoucherNo).Text, tdbg.Columns(COL_Remark).Text) & vbCrLf)

                        bResult = ExecuteSQL(sSQL.ToString)
                        If bResult = True Then
                            DeleteOK()
                            LoadTDBGrid()
                            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
                        Else
                            DeleteNotOK()
                        End If
                    End If
                Else
                    'Xóa Master
                    sSQL.Append(SQLDeleteD13T0102() & vbCrLf)
                    'Audit
                    sSQL.Append(SQLStoreD09P6210("IncomeAdjustment", tdbg.Columns(COL_AbsentVoucherID).Text, "03", tdbg.Columns(COL_AbsentVoucherNo).Text, tdbg.Columns(COL_Remark).Text) & vbCrLf)

                    bResult = ExecuteSQL(sSQL.ToString)
                    If bResult = True Then
                        DeleteOK()
                        LoadTDBGrid()
                        If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
                    Else
                        DeleteNotOK()
                    End If
                End If
            End If
        End If
    End Sub


    ' update 29/7/2013 id 58217
    Private Sub mnuLockVoucher_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuLockVoucher.Click
        If AskLocked() = Windows.Forms.DialogResult.No Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As String = ""
        sSQL = "-- Lock voucher" & vbCrLf
        sSQL &= "Update D13T0102 Set "
        sSQL &= "Locked = " & SQLNumber(1) & COMMA 'tinyint, NOT NULL
        sSQL &= "LockedUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NOT NULL
        sSQL &= "LockedDate = GetDate()" 'datetime, NULL
        sSQL &= " Where "
        sSQL &= "AbsentVoucherID = " & SQLString(tdbg.Columns(COL_AbsentVoucherID).Text)

        ExecuteSQLNoTransaction(sSQL)
        LoadTDBGrid(False, tdbg.Columns(COL_AbsentVoucherID).Text)
        Me.Cursor = Cursors.Default
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD15T2020
    '# Created User: DUCTRONG
    '# Created Date: 03/08/2009 02:50:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD15T2020() As String
        Dim sSQL As String = ""
        sSQL &= "DELETE     D15T2020" & vbCrLf
        sSQL &= "WHERE      TransID IN (SELECT  VoucherID AS TransID" & vbCrLf
        sSQL &= "                       FROM    D13T2031 WITH (NOLOCK) " & vbCrLf
        sSQL &= "			            WHERE   AbsentVoucherID = " & SQLString(tdbg.Columns(COL_AbsentVoucherID).Text) & ")" & vbCrLf
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T2031
    '# Created User: DUCTRONG
    '# Created Date: 03/08/2009 02:49:59
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T2031() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T2031"
        sSQL &= " Where "
        sSQL &= "AbsentVoucherID  = " & SQLString(tdbg.Columns(COL_AbsentVoucherID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0103
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 14/02/2007 09:16:05
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0103() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0103"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "AbsentVoucherID = " & SQLString(tdbg.Columns(COL_AbsentVoucherID).Text)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0108
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 17/11/2011 04:21:17
    '# Modified User: Nguyễn Thị Minh Hòa
    '# Modified Date: 17/11/2011 04:21:17
    '# Description: Xóa phiếu Điều chỉnh thu nhập
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0108() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0108"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "AbsentVoucherID = " & SQLString(tdbg.Columns(COL_AbsentVoucherID).Text)
        sSQL &= "And TranMonth=" & giTranMonth & " And TranYear=" & giTranYear
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0102
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 14/02/2007 09:16:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0102() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0102"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "AbsentVoucherID = " & SQLString(tdbg.Columns(COL_AbsentVoucherID).Text) & " And "
        sSQL &= "TranMonth=" & giTranMonth & " And TranYear=" & giTranYear
        Return sSQL
    End Function

    Private Sub mnuCheck_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCheck.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        If tdbg.Columns(COL_AttMode).Text = "0" Then
            Dim f As New D13F2022
            Dim iBookmark As Integer
            If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
            With f
                .AbsentVoucherID = tdbg.Columns(COL_AbsentVoucherID).Text
                .OldPayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
                .NewPayrollVoucherID = .OldPayrollVoucherID
                .PayrollVoucherNo = tdbg.Columns(COL_PayrollVoucherNo).Text
                '.VoucherDate =  CType(tdbg.Columns(COL_VoucherDate).Text, Date)
                .VoucherDate = CType(IIf(tdbg.Columns(COL_VoucherDate).Text = "", Nothing, tdbg.Columns(COL_VoucherDate).Text), Date)
                .Description = tdbg.Columns(COL_Description).Text
                .BlockID = "%"
                .DepartmentID = tdbg.Columns(COL_DepartmentID).Text
                .TeamID = tdbg.Columns(COL_TeamID).Text
                .AbsentVoucherNo = tdbg.Columns(COL_AbsentVoucherNo).Text
                .EntryDate = CType(IIf(tdbg.Columns(COL_EntryDate).Text = "", Nothing, tdbg.Columns(COL_EntryDate).Text), Date) 'CType(tdbg.Columns(COL_EntryDate).Text, Date)
                .Remark = tdbg.Columns(COL_Remark).Text
                .TransTypeID = tdbg.Columns(COL_TransTypeID).Text
                ' update 29/7/2013 id 58217 - đã khóa hay ko quyền thì cho xem
                If L3Bool(tdbg.Columns(COL_Locked).Text) OrElse (iPerF5700 <= 2 And tdbg.Columns(COL_CreateUserID).Text <> gsUserID) Then
                    .FormState = EnumFormState.FormView
                Else
                    .FormState = EnumFormState.FormEdit
                End If

                .CalFromF2020 = True
                .ShowDialog()
                .Dispose()
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End With
        Else
            Dim f As New D13F2027

            Dim iBookmark As Integer
            If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

            With f
                .AttMode = tdbg.Columns(COL_AttMode).Text
                .AbsentVoucherID = tdbg.Columns(COL_AbsentVoucherID).Text
                .OldPayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
                .NewPayrollVoucherID = .OldPayrollVoucherID
                .PayrollVoucherNo = tdbg.Columns(COL_PayrollVoucherNo).Text
                .VoucherDate = CType(tdbg.Columns(COL_VoucherDate).Text, Date)
                .Description = tdbg.Columns(COL_Description).Text
                .DepartmentID = tdbg.Columns(COL_DepartmentID).Text
                .TeamID = tdbg.Columns(COL_TeamID).Text
                .AbsentVoucherNo = tdbg.Columns(COL_AbsentVoucherNo).Text
                ' Thấy màn hình D13F2027 ko sử dụng biến này
                '  .EntryDate = CType(tdbg.Columns(COL_EntryDate).Value, Date)
                .Remark = tdbg.Columns(COL_Remark).Text
                .TransTypeID = tdbg.Columns(COL_TransTypeID).Text
                ' update 29/7/2013 id 58217 - đã khóa hay ko quyền thì cho xem
                If L3Bool(tdbg.Columns(COL_Locked).Text) OrElse (iPerF5700 <= 2 And tdbg.Columns(COL_CreateUserID).Text <> gsUserID) Then
                    .FormState = EnumFormState.FormView
                End If
                .ShowDialog()
                .Dispose()
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End With
        End If
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub mnuAdjustAttendance_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdjustAttendance.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim f As New D13F2026
        With f
            .PayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
            .SalaryVoucherID = ""
            .VoucherDate = tdbg.Columns(COL_VoucherDate).Text
            .Description = tdbg.Columns(COL_Description).Text
            .AbsentVoucherID = tdbg.Columns(COL_AbsentVoucherID).Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2024
    '# Created User: DUCTRONG
    '# Created Date: 09/06/2009 11:09:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2024() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2024 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(sFind) & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: DUCTRONG
    '# Created Date: 30/12/2009 09:53:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F2020") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_AbsentVoucherID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnAction, btnClose)
        AnchorForControl(EnumAnchorStyles.BottomLeft, lblPerF5700)
    End Sub
End Class