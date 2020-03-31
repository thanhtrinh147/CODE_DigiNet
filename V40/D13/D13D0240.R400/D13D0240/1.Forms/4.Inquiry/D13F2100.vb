Imports System.Windows.Forms
Public Class D13F2100

#Region "Const of tdbg"
    Private Const COL_TTResultVoucherNo As Integer = 0 ' Số phiếu
    Private Const COL_TTRVoucherDate As Integer = 1    ' Ngày phiếu
    Private Const COL_EmployeeName As Integer = 2      ' Người lập
    Private Const COL_TTRVoucherDesc As Integer = 3    ' Diễn giải
    Private Const COL_PolicyName As Integer = 4        ' Cơ chế chuyển bút toán
    Private Const COL_IsCalculate As Integer = 5       ' Đã tính
    Private Const COL_Posted As Integer = 6            ' Đã chuyển
    Private Const COL_TTResultVoucherID As Integer = 7 ' TTResultVoucherID
    Private Const COL_CreateUserID As Integer = 8      ' CreateUserID
    Private Const COL_CreateDate As Integer = 9        ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 10  ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 11   ' LastModifyDate
#End Region

    Private dtGrid As DataTable

    Private Sub D13F2100_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        ResetColorGrid(tdbg)
        gbEnabledUseFind = False
        LoadTDBGrid()
        SetShortcutPopupMenu(C1CommandHolder)
        Loadlanguage()
        InputDateInTrueDBGrid(tdbg, COL_TTRVoucherDate)

        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_phieu_tinh_ket_qua_chuyen_but_toan_-_D13F2100") & UnicodeCaption(gbUnicode) 'Truy vÊn phiÕu tÛnh kÕt qu¶ chuyÓn bòt toÀn - D13F2100
        '================================================================ 
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("TTRVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("TTRVoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("EmployeeName").Caption = rl3("Nguoi_lap") 'Người lập
        tdbg.Columns("TTRVoucherDesc").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("PolicyName").Caption = rl3("Co_che_chuyen_but_toan") 'Cơ chế chuyển bút toán
        tdbg.Columns("IsCalculated").Caption = rl3("Da_tinh") 'Đã tính
        tdbg.Columns("Posted").Caption = rl3("Da_chuyen") 'Đã chuyển
        '================================================================ 
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuCalculate.Text = rl3("_Tinh") '&Tính
        mnuCancelCalculate.Text = rl3("_Bo_tinh") '&Bỏ tính
        mnuShowDetail.Text = rl3("_Chi_tiet") '&Chi tiết
        mnuTransfred.Text = rl3("Chuye_n_but_toan") 'Chuyể&n bút toán
        C1CommandLink4.Text = rl3("Chuye_n_but_toan") 'Chuyể&n bút toán
        mnuDeleteTransfered.Text = rl3("Xo_a_chuyen_but_toan") 'Xó&a chuyển bút toán 
        C1CommandLink5.Text = rl3("Xo_a_chuyen_but_toan") 'Xó&a chuyển bút toán 
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(Me, New Point(btnAction.Left, btnAction.Top))
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim sSQL As String
        sSQL = SQLStoreD13P2001()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        If FlagAdd Then
            Dim drow() As DataRow = dtGrid.Select("TTResultVoucherID = " & SQLString(sKeyID))
            If drow.Length > 0 Then
                tdbg.Bookmark = dtGrid.Rows.IndexOf(drow(0))
            End If
            'dtGrid.DefaultView.Sort = "TTResultVoucherID" 'Field của khóa chính
            'tdbg.Bookmark = dtGrid.DefaultView.Find(sKeyID)
        End If
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        mnuCalculate.Enabled = mnuDelete.Enabled
        mnuCancelCalculate.Enabled = mnuDelete.Enabled
        mnuShowDetail.Enabled = mnuView.Enabled
        CheckMenuOrder()
        FooterTotalGrid(tdbg, COL_TTResultVoucherNo)
    End Sub

    Private Sub CheckMenuOrder()
        If L3Bool(tdbg.Columns(COL_IsCalculate).Text) Then
            mnuCalculate.Enabled = False
            mnuCancelCalculate.Enabled = mnuAdd.Enabled
        Else
            mnuCalculate.Enabled = mnuAdd.Enabled
            mnuCancelCalculate.Enabled = False
        End If

        mnuTransfred.Enabled = L3Bool(tdbg.Columns(COL_IsCalculate).Text) = True And L3Bool(tdbg.Columns(COL_Posted).Text) = False And tdbg.RowCount <> 0 And mnuAdd.Enabled
        mnuDeleteTransfered.Enabled = L3Bool(tdbg.Columns(COL_IsCalculate).Text) = True And L3Bool(tdbg.Columns(COL_Posted).Text) = True And tdbg.RowCount <> 0 And mnuAdd.Enabled
        If (L3Bool(tdbg.Columns(COL_IsCalculate).Text) = True And L3Bool(tdbg.Columns(COL_Posted).Text) = True) Then
            mnuCancelCalculate.Enabled = False
        End If
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        Dim frm As New D13F2110
        With frm
            .TTResultVoucherID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()

            If .bSaved Then
                Dim sKey As String = frm.TTResultVoucherID
                LoadTDBGrid(True, sKey)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If L3Bool(tdbg.Columns(COL_IsCalculate).Text) Then
            D99C0008.MsgL3(rl3("Phieu_nay_da_tinh_ket_qua_chuyen_but_toan") & rl3("Ban_khong_the_sua"))
            Exit Sub
        End If
        Dim frm As New D13F2110
        With frm
            .TTResultVoucherID = tdbg.Columns(COL_TTResultVoucherID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
            If .bSaved Then
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid()
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            End If
        End With
    End Sub

    Private Sub mnuView_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        Dim frm As New D13F2110

        With frm
            .TTResultVoucherID = tdbg.Columns(COL_TTResultVoucherID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        Dim sSQL As String
        Dim bResult As Boolean
        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            If L3Bool(tdbg.Columns(COL_IsCalculate).Text) Then
                D99C0008.MsgL3(rl3("Phieu_nay_da_tinh_ket_qua_chuyen_but_toan") & rl3("Ban_khong_the_xoa"))
                Exit Sub
            End If
            sSQL = "Delete D13T2121 Where TTResultVoucherID = " & SQLString(tdbg.Columns(COL_TTResultVoucherID).Text) & vbCrLf
            sSQL &= "Delete D13T2120 Where TTResultVoucherID = " & SQLString(tdbg.Columns(COL_TTResultVoucherID).Text)
            bResult = ExecuteSQL(sSQL)
            If bResult Then
                DeleteOK()
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                tdbg.Delete()
                FooterTotalGrid(tdbg, COL_TTResultVoucherNo)
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            Else
                DeleteNotOK()
            End If
        End If
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        If mnuEdit.Enabled Then
            mnuEdit_Click(sender, Nothing)
        ElseIf mnuView.Enabled Then
            mnuView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            If mnuEdit.Enabled Then
                mnuEdit_Click(sender, Nothing)
            ElseIf mnuView.Enabled Then
                mnuView_Click(sender, Nothing)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuCancelCalculate_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCancelCalculate.Click
        Dim sSQL As String = "Delete D13T2122 where TTResultVoucherID = " & SQLString(tdbg.Columns(COL_TTResultVoucherID).Text) & vbCrLf
        sSQL &= "Update D13T2120 SET IsCalculated = 0 WHERE TTResultVoucherID = " & SQLString(tdbg.Columns(COL_TTResultVoucherID).Text)
        Dim bResult As Boolean = ExecuteSQLNoTransaction(sSQL)
        If bResult Then

            D99C0008.MsgL3(rl3("Bo_tinh_ket_qua_chuyen_but_toan_thanh_cong"))
            LoadTDBGrid()
        Else
            D99C0008.MsgL3(rl3("Bo_tinh_khong_thanh_congU"))
        End If
    End Sub

    Private Sub mnuShowDetail_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuShowDetail.Click
        Dim frm As New D13F2120
        With frm
            .TTResultVoucherID = tdbg.Columns(COL_TTResultVoucherID).Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Dim sFilter As New System.Text.StringBuilder()
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            sFilter = New StringBuilder("")
            Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
            For Each dc In Me.tdbg.Columns
                Select Case dc.DataType.Name
                    Case "DateTime"
                        If dc.FilterText.Length = 10 Then
                            If sFilter.Length > 0 Then sFilter.Append(" AND ")
                            Dim sClause As String = ""
                            sClause = "(" & dc.DataField & " >= #" & DateSave(CDate(dc.FilterText)) & "#"
                            sClause &= " And " & dc.DataField & " < #" & DateSave(CDate(dc.FilterText).AddDays(1)) & "# )"
                            sFilter.Append(sClause)
                        End If

                    Case "Boolean"
                        If dc.FilterText.Length > 0 Then
                            If sFilter.Length > 0 Then sFilter.Append(" AND ")
                            sFilter.Append((dc.DataField + " = " + "'" + dc.FilterText + "'"))
                        End If

                    Case "String"
                        If dc.FilterText.Length > 0 Then
                            If sFilter.Length > 0 Then sFilter.Append(" AND ")
                            sFilter.Append((dc.DataField + " like " + "'%" + dc.FilterText.Replace("'", "''") + "%'"))
                        End If

                    Case "Byte", "Integer", "Int16", "Int32", "Int64"
                        If dc.FilterText.Length > 0 Then
                            If sFilter.Length > 0 Then sFilter.Append(" AND ")
                            sFilter.Append((dc.DataField + " = " + "" + dc.FilterText + ""))
                        End If

                    Case "Decimal", "Double", "Single"
                        If dc.FilterText.Length > 0 Then
                            If sFilter.Length > 0 Then sFilter.Append(" AND ")
                            sFilter.Append((dc.DataField + " = " + "" + dc.FilterText + ""))
                        End If

                End Select
            Next

            ''13/04/2015: Không viết đặc thù. Gọi DLL chung  
            'If (dtGrid Is Nothing) Then Exit Sub
            'FilterChangeGrid(tdbg, sFilter)

            dtGrid.DefaultView.RowFilter = sFilter.ToString()
            CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
            mnuCalculate.Enabled = mnuDelete.Enabled
            mnuCancelCalculate.Enabled = mnuDelete.Enabled
            mnuShowDetail.Enabled = mnuView.Enabled
            CheckMenuOrder()
            FooterTotalGrid(tdbg, COL_TTResultVoucherNo)
        Catch ex As Exception
            'MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2001
    '# Created User: Thanh Huyền
    '# Created Date: 17/11/2010 04:18:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2001() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2001 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2102
    '# Created User: Thanh Huyền
    '# Created Date: 17/11/2010 04:20:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2102() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2102 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TTResultVoucherID).Text) & COMMA 'TTResultVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub mnuCalculate_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCalculate.Click
        Dim bExecute As Boolean = ExecuteSQLNoTransaction(SQLStoreD13P2102())
        If bExecute Then
            D99C0008.MsgL3(rl3("Tinh_ket_qua_chuyen_but_toan_thanh_cong"))
            mnuShowDetail_Click(Nothing, Nothing)
            LoadTDBGrid()
        Else
            D99C0008.MsgL3(rl3("Tinh_khong_thanh_cong"))
        End If
    End Sub

    Private Sub tdbg_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If tdbg.RowCount < 1 Then
                mnuCalculate.Enabled = False
                mnuCancelCalculate.Enabled = False
                Exit Sub
            End If
            If L3Bool(tdbg.Columns(COL_IsCalculate).Text) Then
                mnuCalculate.Enabled = False
                mnuCancelCalculate.Enabled = True
            Else
                mnuCalculate.Enabled = True
                mnuCancelCalculate.Enabled = False
            End If
        End If
    End Sub

    Private Sub mnuTransfred_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransfred.Click
        Dim dtTmp As DataTable = ReturnDataTable(SQLStoreD13P2103())
        If dtTmp.Rows.Count > 0 Then
            If dtTmp.Rows(0).Item("Status").ToString = "0" Then
                D99C0008.MsgL3(rl3("Khong_co_but_toan_de_chuyen"))
            Else
                D99C0008.MsgL3(rl3("Chuyen_but_toan_thanh_cong"))
                LoadTDBGrid()
            End If
        Else
            D99C0008.MsgL3(rl3("Khong_co_dong_nao_tra_ra_tu_Store"))
        End If
    End Sub

    Private Sub mnuDeleteTransfered_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDeleteTransfered.Click
        Dim dt As DataTable = ReturnDataTable(SQLStoreD13P2104())
        If dt.Rows.Count > 0 Then
            If (dt.Rows(0).Item("Status").ToString = "1") Then
                D99C0008.MsgL3(ConvertVietwareFToUnicode(dt.Rows(0).Item("Message").ToString))
            Else
                Dim bExecute As Boolean = ExecuteSQLNoTransaction(SQLStoreD13P2105())
                D99C0008.MsgL3(rL3("Xoa_chuyen_but_toan_thanh_cong"))
                LoadTDBGrid()
            End If
        Else
            D99C0008.MsgL3(rL3("Khong_co_dong_nao_tra_ra_tu_Store"))
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2103
    '# Created User: Lê Đình Thái
    '# Created Date: 06/09/2011 11:11:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2103() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2103 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TTResultVoucherID).Text) & COMMA 'TTResultVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsCompanyID) & COMMA  'CompanyID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2104
    '# Created User: Lê Đình Thái
    '# Created Date: 06/09/2011 11:17:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2104() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2104 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TTResultVoucherID).Text) & COMMA 'TTResultVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA  'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsCompanyID) 'CompanyID VARCHAR(50) = ''
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2105
    '# Created User: Lê Đình Thái
    '# Created Date: 06/09/2011 11:16:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2105() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2105 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TTResultVoucherID).Text) & COMMA  'TTResultVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsCompanyID) 'CompanyID VARCHAR(50) = ''
        Return sSQL
    End Function

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        CheckMenuOrder()
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnAction, btnClose)
    End Sub
End Class