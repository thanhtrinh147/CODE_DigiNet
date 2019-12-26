Public Class D45F2010
    Dim sFind As String = ""
    Dim iper As Integer

    Dim dtGrid, dtCaptionCols As New DataTable
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""

    Dim conn As New SqlConnection(gsConnectionString)
    Dim trans As SqlTransaction = Nothing


#Region "Const of tdbg - Total of Columns: 21"
    Private Const COL_PSalaryVoucherID As Integer = 0       ' PSalaryVoucherID
    Private Const COL_VoucherDate As Integer = 1            ' Ngày phiếu
    Private Const COL_PSalaryVoucherNo As Integer = 2       ' Số phiếu
    Private Const COL_Description As Integer = 3            ' Diễn giải
    Private Const COL_PieceworkCalMethodName As Integer = 4 ' Phương pháp tính lương
    Private Const COL_PriceListName As Integer = 5          ' Bảng giá
    Private Const COL_PSModeName As Integer = 6             ' Loại phiếu lương
    Private Const COL_IsAttCoefUP As Integer = 7            ' Tính theo ĐG-GCHS
    Private Const COL_AttCoefUPDes As Integer = 8           ' Phiếu ĐG-GCHS
    Private Const COL_Calculated As Integer = 9             ' Đã tính
    Private Const COL_CreateUserID As Integer = 10          ' CreateUserID
    Private Const COL_CreateDate As Integer = 11            ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 12      ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 13        ' LastModifyDate
    Private Const COL_PieceworkCalMethodID As Integer = 14  ' PieceworkCalMethodID
    Private Const COL_AttCoefUPID As Integer = 15           ' AttCoefUPID
    Private Const COL_AttDateFrom As Integer = 16           ' AttDateFrom
    Private Const COL_AttDateTo As Integer = 17             ' AttDateTo
    Private Const COL_VoucherNo As Integer = 18             ' VoucherNo
    Private Const COL_PSalaryMode As Integer = 19           ' PSalaryMode
    Private Const COL_BlockID As Integer = 20               ' BlockID
#End Region


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
    End Sub

    Private Sub D45F2010_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        iper = ReturnPermission(Me.Name)
        ResetColorGrid(tdbg, 0, 1)
        Loadlanguage()
        LoadTDBGrid()
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_phieu_luong_san_pham_-_D45F2010") 'Danh sÀch phiÕu l§¥ng s¶n phÈm - D45F2010
        '================================================================ 
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("PSalaryVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("PieceworkCalMethodName").Caption = rl3("Phuong_phap_tinh_luong") 'Phương pháp tính lương
        tdbg.Columns("PriceListName").Caption = rl3("Bang_gia") 'Bảng giá
        tdbg.Columns("PSModeName").Caption = rl3("Loai_phieu_luong") 'Loại phiếu lương
        tdbg.Columns("IsAttCoefUP").Caption = rl3("Tinh_theo_DG-GCHS") 'Tính theo ĐG-GCHS
        tdbg.Columns("AttCoefUPDes").Caption = rl3("Phieu_DG-GCHS") 'Phiếu ĐG-GCHS
        tdbg.Columns("Calculated").Caption = rl3("Da_tinh") 'Đã tính
        '================================================================ 
        tsmCalculate.Text = rl3("Tinh__luong") 'Tính &lương
        mnsCalculate.Text = rl3("Tinh__luong") 'Tính &lương
        tsmCalculateResult.Text = rl3("_Ket_qua_tinh_luong") '&Kết quả tính lương
        mnsCalculateResult.Text = rl3("_Ket_qua_tinh_luong") '&Kết quả tính lương
        tsmDeleteResult.Text = rl3("Xoa_ket__qua_tinh_luong") 'Xoá kết &quả tính lương
        mnsDeleteResult.Text = rl3("Xoa_ket__qua_tinh_luong") 'Xoá kết &quả tính lương
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = SQLStoreD45P2010()
        dtGrid = ReturnDataTable(sSQL)

        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =''
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("PSalaryVoucherID =" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        CheckMnuOther(tdbg.Bookmark)
        FooterTotalGrid(tdbg, COL_PSalaryVoucherNo)
    End Sub

    Private Sub CheckMnuOther(ByVal iRow As Integer)
        tsmCalculate.Enabled = (tdbg.RowCount > 0) And (iper > EnumPermission.View)

        If tdbg.RowCount = 0 Then
            tsmCalculateResult.Enabled = False
        Else
            tsmCalculateResult.Enabled = L3Bool(tdbg(iRow, COL_Calculated).ToString)
        End If
        tsmDeleteResult.Enabled = tsmCalculateResult.Enabled And (iper > EnumPermission.View)
        '******************************
        mnsCalculate.Enabled = tsmCalculate.Enabled
        mnsCalculateResult.Enabled = tsmCalculateResult.Enabled
        mnsDeleteResult.Enabled = tsmDeleteResult.Enabled
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = ""
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

#Region "Context Menu items"

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D45F2011
        With f
            .PSalaryVoucherID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            '26/7 Sửa tạm bỏ SaveOk do màn hình trong còn gọi màn hình trong nửa và màn hình trong nửa củng có lưu nên SaveOk đã thay đổi  
            'If _bSaved Then LoadTDBGrid(True, .PSalaryVoucherID)
            LoadTDBGrid(True, .PSalaryVoucherID)
            .Dispose()
        End With
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Me.Cursor = Cursors.WaitCursor

        If L3Bool(tdbg.Columns(COL_IsAttCoefUP).Text) Then
            Dim f As New D45F2014
            With f
                .AttCoefUPID = tdbg.Columns(COL_AttCoefUPID).Text
                .pSalaryVoucherID = tdbg.Columns(COL_PSalaryVoucherID).Text
                .VoucherNo = tdbg.Columns(COL_VoucherNo).Text
                .Description = tdbg.Columns(COL_AttCoefUPDes).Text
                .AttDateFrom = tdbg.Columns(COL_AttDateFrom).Text
                .AttDateTo = tdbg.Columns(COL_AttDateTo).Text
                .FormState = EnumFormState.FormEdit
                .ShowDialog()
                .Dispose()
            End With
        Else
            If AllowEdit() = False Then Me.Cursor = Cursors.Default : Exit Sub
            Dim f As New D45F2011
            With f
                .PSalaryVoucherID = tdbg.Columns(COL_PSalaryVoucherID).Text
                .bCalculated = L3Bool(tdbg.Columns(COL_Calculated).Text)
                .FormState = EnumFormState.FormEdit
                .ShowDialog()
                .Dispose()
            End With
        End If
        '26/7 Sửa tạm bỏ SaveOk do màn hình trong còn gọi màn hình trong nửa và màn hình trong nửa củng có lưu nên SaveOk đã thay đổi  
        'If _bSaved Then LoadTDBGrid(, tdbg.Columns(COL_PSalaryVoucherID).Text)
        LoadTDBGrid(, tdbg.Columns(COL_PSalaryVoucherID).Text)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Me.Cursor = Cursors.WaitCursor

        If L3Bool(tdbg.Columns(COL_IsAttCoefUP).Text) Then
            Dim f As New D45F2014
            With f
                .AttCoefUPID = tdbg.Columns(COL_AttCoefUPID).Text
                .pSalaryVoucherID = tdbg.Columns(COL_PSalaryVoucherID).Text
                .VoucherNo = tdbg.Columns(COL_VoucherNo).Text
                .Description = tdbg.Columns(COL_AttCoefUPDes).Text
                .AttDateFrom = tdbg.Columns(COL_AttDateFrom).Text
                .AttDateTo = tdbg.Columns(COL_AttDateTo).Text
                .FormState = EnumFormState.FormEdit
                .ShowDialog()
                .Dispose()
            End With
        Else
            Dim f As New D45F2011
            f.PSalaryVoucherID = tdbg.Columns(COL_PSalaryVoucherID).Text
            f.bCalculated = L3Bool(tdbg.Columns(COL_Calculated).Text)
            f.FormState = EnumFormState.FormView
            f.ShowDialog()
            f.Dispose()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If AllowDelete() = False Then Exit Sub

        If CBool(tdbg.Columns(COL_Calculated).Text) Then
            D99C0008.MsgCanNotDelete()
            Exit Sub
        End If

        Dim sSQL As String = ""
        sSQL = "Delete D45T2011 Where PSalaryVoucherID = " & SQLString(tdbg.Columns(COL_PSalaryVoucherID).Text) & vbCrLf
        sSQL &= "Delete D45T2010 Where PSalaryVoucherID = " & SQLString(tdbg.Columns(COL_PSalaryVoucherID).Text) & vbCrLf

        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult Then
            'RunAuditLog(AuditCodePSalaryCalculation, "03", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_PSalaryVoucherNo).Text, tdbg.Columns(COL_Description).Text, "", tdbg.Columns(COL_PieceworkCalMethodID).Text)
            Lemon3.D91.RunAuditLog("45", AuditCodePSalaryCalculation, "03", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_PSalaryVoucherNo).Text, tdbg.Columns(COL_Description).Text, "", tdbg.Columns(COL_PieceworkCalMethodID).Text)
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsmCalculate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmCalculate.Click, mnsCalculate.Click
        Me.Cursor = Cursors.WaitCursor

        If L3Bool(tdbg.Columns(COL_IsAttCoefUP).Text) Then
            If L3Bool(tdbg.Columns(COL_Calculated).Text) Then
                If D99C0008.MsgAsk(rl3("Phieu_nay_da_duoc_tinh_luong_Ban_co_muon_tinh_lai_khong")) = Windows.Forms.DialogResult.Yes Then
                    Dim sSQL As String = SQLStoreD45P2016()
                    If CheckStore(sSQL) Then
                        Dim f As New D45F2015
                        With f
                            .PSalaryVoucherID = tdbg.Columns(COL_PSalaryVoucherID).Text
                            .pieceworkCalMethodID = tdbg.Columns(COL_PieceworkCalMethodID).Text
                            .ShowDialog()
                            .Dispose()
                        End With
                    End If
                End If
            Else
                Dim sSQL As String = SQLStoreD45P2016()
                If CheckStore(sSQL) Then
                    Dim f As New D45F2015
                    With f
                        .PSalaryVoucherID = tdbg.Columns(COL_PSalaryVoucherID).Text
                        .pieceworkCalMethodID = tdbg.Columns(COL_PieceworkCalMethodID).Text
                        .ShowDialog()
                        .Dispose()
                    End With

                End If
            End If
        Else
            If AllowCalSalary() = False Then Me.Cursor = Cursors.Default : Exit Sub
            'mo ket noi
            conn.Close()
            conn.Open()
            trans = conn.BeginTransaction

            Dim sSQL As String = ""
            If L3Bool(tdbg.Columns(COL_Calculated).Text) Then
                If D99C0008.MsgAsk(rl3("Phieu_nay_da_duoc_tinh_luong_Ban_co_muon_tinh_lai_khong")) = Windows.Forms.DialogResult.Yes Then
                    sSQL = SQLStoreD45P2550() & vbCrLf
                    sSQL &= SQLStoreD45P2500()
                Else
                    Dim f As New D45F2012
                    With f
                        .PSalaryVoucherID = tdbg.Columns(COL_PSalaryVoucherID).Text
                        .BlockID = tdbg.Columns(COL_BlockID).Text
                        .PieceworkCalMethodID = tdbg.Columns(COL_PieceworkCalMethodID).Text
                        .PSalaryMode = tdbg.Columns(COL_PSalaryMode).Text   '28/11/2012  sửa cột mã nhân viên , họ và tên chỉ hiện khi loại phiếu tính lương theo nhân viên
                        .ShowDialog()
                        LoadTDBGrid(, tdbg.Columns(COL_PSalaryVoucherID).Text)
                        .Dispose()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End With
                End If
            Else
                sSQL = SQLStoreD45P2500()
            End If

            Dim Dt As DataTable = ReturnDataTable1(sSQL)
            'Thuc thi bi loi
            If Dt Is Nothing Then
                trans.Rollback()
                'dong ket noi
                conn.Close()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            If Dt.Rows.Count > 0 Then
                If Dt.Rows(0).Item("Status").ToString = "1" Then
                    Dim bFontMessage As Boolean = False
                    If Dt.Columns.Contains("FontMessage") Then bFontMessage = True

                    If Not bFontMessage Then
                        D99C0008.MsgL3(ConvertVietwareFToUnicode(Dt.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Exclamation)
                    Else
                        Select Case Dt.Rows(0).Item("FontMessage").ToString
                            Case "0" 'VietwareF
                                D99C0008.MsgL3(ConvertVietwareFToUnicode(Dt.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Exclamation)
                            Case "1" 'Unicode
                                D99C0008.MsgL3(Dt.Rows(0).Item("Message").ToString, L3MessageBoxIcon.Exclamation)
                            Case "2" 'Convert Vni To Unicode
                                D99C0008.MsgL3(ConvertVniToUnicode(Dt.Rows(0).Item("Message").ToString), L3MessageBoxIcon.Exclamation)
                        End Select
                    End If

                    trans.Rollback()
                    'dong ket noi
                    conn.Close()
                Else
                    trans.Commit()
                    'dong ket noi
                    conn.Close()

                    Dim f As New D45F2012
                    With f
                        .PSalaryVoucherID = tdbg.Columns(COL_PSalaryVoucherID).Text
                        .BlockID = tdbg.Columns(COL_BlockID).Text
                        .PieceworkCalMethodID = tdbg.Columns(COL_PieceworkCalMethodID).Text
                        .PSalaryMode = tdbg.Columns(COL_PSalaryMode).Text   '28/11/2012  sửa cột mã nhân viên , họ và tên chỉ hiện khi loại phiếu tính lương theo nhân viên
                        .ShowDialog()
                        .Dispose()
                    End With
                End If
            Else
                trans.Rollback()
                'dong ket noi
                conn.Close()
            End If
        End If
        
        LoadTDBGrid(, tdbg.Columns(COL_PSalaryVoucherID).Text)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsmCalculateResult_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmCalculateResult.Click, mnsCalculateResult.Click
        Me.Cursor = Cursors.WaitCursor
        If L3Bool(tdbg.Columns(COL_IsAttCoefUP).Text) Then
            Dim f As New D45F2015
            With f
                .PSalaryVoucherID = tdbg.Columns(COL_PSalaryVoucherID).Text
                .pieceworkCalMethodID = tdbg.Columns(COL_PieceworkCalMethodID).Text
                .ShowDialog()
                .Dispose()
            End With
        Else
            Dim f As New D45F2012
            With f
                .PSalaryVoucherID = tdbg.Columns(COL_PSalaryVoucherID).Text
                .BlockID = tdbg.Columns(COL_BlockID).Text
                .PieceworkCalMethodID = tdbg.Columns(COL_PieceworkCalMethodID).Text
                .PSalaryMode = tdbg.Columns(COL_PSalaryMode).Text    '8/11/2012 52115  sửa cột mã nhân viên , họ và tên chỉ hiện khi loại phiếu tính lương theo nhân viên
                .ShowDialog()
                .Dispose()
            End With
        End If

        LoadTDBGrid(, tdbg.Columns(COL_PSalaryVoucherID).Text)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsmDeleteResult_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmDeleteResult.Click, mnsDeleteResult.Click
        If AllowCalSalary() = False Then Exit Sub

        If CBool(tdbg.Columns(COL_Calculated).Text) Then
            If D99C0008.MsgAsk(rl3("Phieu_nay_da_duoc_tinh_luong_Ban_co_muon_xoa_ket_qua_nay_khong")) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim sSQL As String = ""
        sSQL = SQLStoreD45P2550() & vbCrLf
        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult Then
            DeleteOK()
            'RunAuditLog(AuditCodePSalaryResultDeletion, "03", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_PSalaryVoucherNo).Text, tdbg.Columns(COL_Description).Text, "", tdbg.Columns(COL_PieceworkCalMethodID).Text)
            Lemon3.D91.RunAuditLog("45", AuditCodePSalaryResultDeletion, "03", tdbg.Columns(COL_VoucherDate).Text, tdbg.Columns(COL_PSalaryVoucherNo).Text, tdbg.Columns(COL_Description).Text, "", tdbg.Columns(COL_PieceworkCalMethodID).Text)
            LoadTDBGrid(, tdbg.Columns(COL_PSalaryVoucherID).Text)
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub
#End Region

#Region "tdbg"

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub

        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
    End Sub

    'không cho nhấn giá trị trên cột Filter bar đối với cột STT
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Calculated 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        CheckMnuOther(tdbg.Row)
    End Sub

    'Private Sub tdbg_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseDown
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        If tdbg.RowCount = 0 Then
    '            mnuSalaryResult.Enabled = False
    '        Else
    '            mnuSalaryResult.Enabled = CBool(tdbg.Columns(COL_Calculated).Text)
    '        End If

    '        mnuDeleteSalaryResult.Enabled = mnuSalaryResult.Enabled And (iper > EnumPermission.View)
    '    End If
    'End Sub
#End Region

    Private Function AllowDelete() As Boolean
        Dim sSQL As String = ""

        sSQL = SQLStoreD45P5555(1)
        If CheckStore(sSQL) = False Then
            Return False
        End If

        sSQL = SQLStoreD45P0101(1)
        AllowDelete = CheckStore(sSQL)
    End Function

    Private Function AllowEdit() As Boolean
        Dim sSQL As String = ""
        sSQL = SQLStoreD45P0101(2)
        AllowEdit = CheckStore(sSQL)
    End Function

    Private Function AllowCalSalary() As Boolean
        Dim sSQL As String = ""
        sSQL = SQLStoreD45P5555(2)
        AllowCalSalary = CheckStore(sSQL)
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2010
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/10/2009 02:23:24
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load luoi
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2010 "
        sSQL &= SQLString("") & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA  'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'Codetable, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA  'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2010") & COMMA  'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage)   'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2550
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/10/2009 02:41:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: Xoa ket qua tinh luong
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2550() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2550 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_PSalaryVoucherID).Text) 'PSalaryVoucherID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2500
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/10/2009 03:41:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2500() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2500 "
        sSQL &= SQLString(tdbg.Columns(COL_PSalaryVoucherID).Text) & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Languge, varchar[10], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Function ReturnDataSet1(ByVal SQL As String) As DataSet
        Dim ds As DataSet = New DataSet()
        If giAppMode = 0 Then
            Dim cmd As SqlCommand = New SqlCommand(SQL, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Try
                cmd.CommandTimeout = 0
                cmd.Transaction = trans
                'Rem lai ngay 03/11/2009 vi neu dung lenh nay thi store se thuc thi 2 lan
                'cmd.ExecuteNonQuery()
                da.Fill(ds)
                Return ds
            Catch
                Clipboard.Clear()
                Clipboard.SetText(SQL)
                MsgErr("Error when excute SQL in function ReturnDataSet(). Paste your SQL code from Clipboard")
                Return Nothing
            End Try
        Else
            Try
                'Dùng D99D0041 mới
                ds = CallWebService.ReturnDataSet(SQL, gsCompanyID, gsWSSPara01, gsWSSPara02, gsWSSPara03, gsWSSPara04, gsWSSPara05)
                Return ds
            Catch
                Clipboard.Clear()
                Clipboard.SetText(SQL)
                MsgErr("Error when excute SQL in function ReturnDataSet(). Paste your SQL code from Clipboard")
                Return Nothing

            End Try
        End If
    End Function

    Private Function ReturnDataTable1(ByVal SQL As String) As DataTable
        Dim ds As DataSet = ReturnDataSet1(SQL)
        If ds Is Nothing Then Return Nothing
        Return ds.Tables(0)
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P0101
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 05/11/2009 08:25:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P0101(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P0101 "
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_PSalaryVoucherID).Text) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2010") & COMMA 'Form, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 23/12/2009 02:36:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P5555(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_PSalaryVoucherID).Text) & COMMA 'KeyID1, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'KeyID2, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'KeyID3, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'KeyID4, varchar[20], NOT NULL
		sSQL &= SQLString("") 'KeyID5, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2016
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/10/2011 11:43:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2016() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2016 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2010") & COMMA 'FormID, varchar[10], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_PSalaryVoucherID).Text) & COMMA 'PSalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function
End Class