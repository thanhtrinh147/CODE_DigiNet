Public Class D13F4200
	Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_LevelID As Integer = 0   ' LevelID
    Private Const COL_OrderNo As Integer = 1   ' STT
    Private Const COL_GroupID As Integer = 2   ' Mã
    Private Const COL_GroupName As Integer = 3 ' Tên
#End Region

    Private dtGrid As DataTable
    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Private Sub D13F4200_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D13F4200_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        ResetColorGrid(tdbg)
        gbEnabledUseFind = False
        SetBackColorObligatory()
        LoadTDBCombo()
        LoadLanguage()
        SetShortcutPopupMenu(Me, Nothing, ContextMenuStrip1)
        ResetGrid()
        btnSetupReport.Enabled = ReturnPermission("D09F4120") >= EnumPermission.View

        CallD99U1111()

        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Thong_ke_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Thçng k£ l§¥ng
        '================================================================ 
        lblPeriod.Text = rl3("Ky") 'Kỳ
        lblReportID.Text = rl3("Bao_cao") 'Báo cáo
        lblSalReportID.Text = rl3("Mau_bao_cao_bang_luong") 'Mẫu báo cáo bảng lương
        lblGroupID3.Text = rl3("Nhom") & " 3" 'Nhóm 3
        lblGroupID2.Text = rl3("Nhom") & " 2" 'Nhóm 2
        lblGroupID1.Text = rl3("Nhom") & " 1" 'Nhóm 1
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnF12.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị
        '================================================================ 
        btnSetupReport.Text = rL3("Thiet_lap__bao_cao") 'Thiết lập &báo cáo
        '================================================================ 
        grpGroupID.Text = rl3("Nhom_du_lieu") 'Nhóm dữ liệu
        '================================================================ 
        tdbcSalReportID.Columns("SalReportID").Caption = rl3("Ma") 'Mã
        tdbcSalReportID.Columns("SalReportName").Caption = rl3("Ten") 'Tên
        tdbcReportID.Columns("ReportID").Caption = rl3("Ma") 'Mã
        tdbcReportID.Columns("ReportName").Caption = rl3("Ten") 'Tên
        tdbcPeriodTo.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcGroupID3.Columns("GroupID").Caption = rl3("Ma") 'Mã
        tdbcGroupID3.Columns("GroupName").Caption = rl3("Ten") 'Tên
        tdbcGroupID2.Columns("GroupID").Caption = rl3("Ma") 'Mã
        tdbcGroupID2.Columns("GroupName").Caption = rl3("Ten") 'Tên
        tdbcGroupID1.Columns("GroupID").Caption = rl3("Ma") 'Mã
        tdbcGroupID1.Columns("GroupName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_OrderNo).Caption = rl3("STT") 'STT
        tdbg.Columns(COL_GroupID).Caption = rl3("Ma") 'Mã
        tdbg.Columns(COL_GroupName).Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub LoadTDBCombo()
        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, "D09")
        tdbcPeriodFrom.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        tdbcPeriodTo.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString

        Dim sSQL As String = ""
        'Load tdbcSalReportID
        sSQL = "-- Do nguon Combo bang luong" & vbCrLf
        sSQL &= "Select 	T1.ReportCode AS SalReportID , T1.ReportName" & UnicodeJoin(gbUnicode) & " as SalReportName" & vbCrLf
        sSQL &= "From 	D13T4000 T1 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where 	T1.Disabled = 0 " & vbCrLf
        sSQL &= "Order by 	ReportCode" & vbCrLf
        LoadDataSource(tdbcSalReportID, sSQL, gbUnicode)
        tdbcSalReportID.SelectedIndex = 0

        'Load tdbcGroupID3
        sSQL = "-- Do nguon Combo Nhom" & vbCrLf
        sSQL &= "SELECT Code AS GroupID, " & vbCrLf
        sSQL &= " [Description" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString & UnicodeJoin(gbUnicode) & "] AS GroupName" & vbCrLf
        sSQL &= "FROM		D09V0100 WITH (NOLOCK)" & vbCrLf
        sSQL &= "WHERE		StrFormID LIKE '%D13F4200%'  AND Type = 'GroupData'" & vbCrLf
        Dim dtGroup As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcGroupID1, dtGroup.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcGroupID2, dtGroup.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcGroupID3, dtGroup.DefaultView.ToTable, gbUnicode)

        LoadtdbcReportID()
    End Sub

    Private Sub LoadtdbcReportID()
        'Load tdbcReportID
        Dim sSQL As String = ""
        sSQL = "-- Do nguon Combo bao cao" & vbCrLf
        sSQL &= "SELECT 	ReportID, ReportName" & UnicodeJoin(gbUnicode) & " AS ReportName" & vbCrLf
        sSQL &= "FROM 	D09T4120 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE 	Disabled = 0 AND Type = 1" & vbCrLf
        LoadDataSource(tdbcReportID, sSQL, gbUnicode)
        tdbcReportID.SelectedIndex = 0
    End Sub

    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL_GroupID}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

    Private Sub D13F4200_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(sender, Nothing)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Function AllowFilter() As Boolean
        If CheckValidPeriodFromTo(tdbcPeriodFrom, tdbcPeriodTo) = False Then Return False
        If tdbcReportID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Bao_cao"))
            tdbcReportID.Focus()
            Return False
        End If
        If tdbcSalReportID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Mau_bao_cao_bang_luong"))
            tdbcSalReportID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcSalReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        If AllowFilter() = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        LoadCol()
        dtF12 = Nothing
        CallD99U1111()
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadCol()
        Dim dtCol As DataTable = ReturnDataTable(SQLStoreD13P4200(0))
        Dim sField As String = ""
        'Xóa các cột động cũ
        For k As Integer = tdbg.Columns.Count - 1 To COL_GroupName + 1 Step -1
            tdbg.Columns.RemoveAt(k)
        Next
        For i As Integer = 0 To dtCol.Rows.Count - 1
            Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn
            sField = dtCol.Rows(i).Item("FieldName").ToString
            dc.DataField = sField
            dc.Caption = dtCol.Rows(i).Item("Caption").ToString
            tdbg.Columns.Add(dc)
            tdbg.Splits(0).DisplayColumns(sField).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            tdbg.Splits(0).DisplayColumns(sField).HeadingStyle.Font = FontUnicode(gbUnicode)
            tdbg.Splits(0).DisplayColumns(sField).Style.Font = FontUnicode(gbUnicode)
            tdbg.Splits(0).DisplayColumns(sField).Width = 110 'L3Int(dtCol.Rows(i).Item("Length").ToString)
            tdbg.Splits(0).DisplayColumns(sField).Visible = True
            tdbg.Splits(0).DisplayColumns(sField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            tdbg.Columns(sField).NumberFormat = "N" & dtCol.Rows(i).Item("Decimal").ToString
        Next
    End Sub

    Private Sub LoadTDBGrid()
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        sFind = ""
        dtGrid = ReturnDataTable(SQLStoreD13P4200(1))
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, Nothing, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_GroupID)
    End Sub

    Private Sub tsmExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsExportToExcel.Click
        Me.Cursor = Cursors.WaitCursor
        ExportToExcelMax()
        Me.Cursor = Cursors.Default
    End Sub

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    'Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_GroupID}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
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

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg, e, COL_OrderNo)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_OrderNo 'Chặn nhập liệu trên cột STT tăng tự động trong code
                e.Handled = CheckKeyPress(e.KeyChar, True)
        End Select
    End Sub

    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        Select Case L3Int(tdbg(e.Row, COL_LevelID))
            Case 1
                'có chọn màu nhóm 1
                If L3Bool(txtColor1.Tag) Then e.CellStyle.ForeColor = ReturnColor(txtColor1.BackColor)
            Case 2
                If L3Bool(txtColor2.Tag) Then e.CellStyle.ForeColor = ReturnColor(txtColor2.BackColor)
            Case 3
                If L3Bool(txtColor3.Tag) Then e.CellStyle.ForeColor = ReturnColor(txtColor3.BackColor)
        End Select
    End Sub

    Private Function ReturnColor(ByVal clor As Color) As Color
        If clor = SystemColors.Control Then
            clor = Color.Black
        End If
        Return clor
    End Function

#Region "Màu"

    Private Sub ShowColor(ByVal txtcolor As TextBox)
        Dim MyDialog As New ColorDialog()
        ' Keeps the user from selecting a custom color.
        MyDialog.AllowFullOpen = False
        ' Allows the user to get help. (The default is false.)
        MyDialog.ShowHelp = True
        ' Sets the initial color select to the current text color,
        MyDialog.Color = txtcolor.BackColor
        ' Update the text box color if the user clicks OK 
        If (MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then txtcolor.BackColor = MyDialog.Color : txtcolor.Tag = 1
    End Sub

    Private Sub btnColor1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor1.Click
        ShowColor(txtColor1)
        CheckGroupID(txtColor1, btnColor1)
    End Sub

    Private Sub btnColor2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnColor2.Click
        ShowColor(txtColor2)
        CheckGroupID(txtColor2, btnColor2)
    End Sub

    Private Sub btnColor3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnColor3.Click
        ShowColor(txtColor3)
        CheckGroupID(txtColor3, btnColor3)
    End Sub

    Private Sub CheckGroupID(ByRef txtColor As System.Windows.Forms.TextBox, ByRef btnColor As System.Windows.Forms.Button)
        Dim dgColor As Color = txtColor.BackColor
        If dgColor <> SystemColors.Control Then
            Dim txt As System.Windows.Forms.TextBox
            With grpGroupID
                For i As Integer = 1 To 3
                    txt = CType(.Controls("txtColor" & i), System.Windows.Forms.TextBox)
                    Dim dg As Color = txt.BackColor
                    If txt.Name <> txtColor.Name AndAlso dgColor = dg Then
                        D99C0008.MsgL3(rL3("Ban_khong_duoc_chon_trung_mau_nhom_du_lieu"))
                        txtColor.BackColor = SystemColors.Control
                        btnColor.Focus()
                        Exit Sub
                    End If
                Next
            End With
        End If
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P4200
    '# Created User: THANHHUYEN
    '# Created Date: 04/04/2014 09:00:21
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P4200(ByVal iMode As Byte) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Loc du lieu" & vbCrLf)
        sSQL &= "Exec D13P4200 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'TranYearFrom, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'TranYearTo, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcReportID)) & COMMA 'ReportID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcSalReportID)) & COMMA 'SalReportID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcGroupID1)) & COMMA 'Group01ID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcGroupID2)) & COMMA 'Group02ID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcGroupID3)) & COMMA 'Group03ID, varchar[50], NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

#Region "Events tdbcGroupID1"

    Private Sub tdbcGroupID1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupID1.LostFocus
        If tdbcGroupID1.FindStringExact(tdbcGroupID1.Text) = -1 Then tdbcGroupID1.Text = ""
    End Sub

    Private Sub tdbcGroupID1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupID1.SelectedValueChanged
        If tdbcGroupID1.Text <> "" Then
            If tdbcGroupID1.Text = tdbcGroupID2.Text OrElse tdbcGroupID1.Text = tdbcGroupID3.Text Then
                D99C0008.MsgL3(rL3("Ban_khong_duoc_chon_trung_nhom_du_lieu"))
                tdbcGroupID1.Text = ""
                tdbcGroupID1.Focus()
            End If
        End If

        EnabledComBo_GroupID(1)
    End Sub

#End Region

#Region "Events tdbcGroupID2"

    Private Sub tdbcGroupID2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupID2.LostFocus
        If tdbcGroupID2.FindStringExact(tdbcGroupID2.Text) = -1 Then tdbcGroupID2.Text = ""
    End Sub

    Private Sub tdbcGroupID2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupID2.SelectedValueChanged
        If tdbcGroupID2.Text <> "" Then
            If tdbcGroupID1.Text = tdbcGroupID2.Text OrElse tdbcGroupID2.Text = tdbcGroupID3.Text Then
                D99C0008.MsgL3(rL3("Ban_khong_duoc_chon_trung_nhom_du_lieu"))
                tdbcGroupID2.Text = ""
                tdbcGroupID2.Focus()
            End If
        End If
        EnabledComBo_GroupID(2)
    End Sub

#End Region

#Region "Events tdbcGroupID3"

    Private Sub tdbcGroupID3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupID3.LostFocus
        If tdbcGroupID3.FindStringExact(tdbcGroupID3.Text) = -1 Then tdbcGroupID3.Text = ""
    End Sub

    Private Sub tdbcGroupID3_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupID3.SelectedValueChanged
        If tdbcGroupID3.Text <> "" Then
            If tdbcGroupID3.Text = tdbcGroupID1.Text OrElse tdbcGroupID2.Text = tdbcGroupID3.Text Then
                D99C0008.MsgL3(rL3("Ban_khong_duoc_chon_trung_nhom_du_lieu"))
                tdbcGroupID3.Text = ""
                tdbcGroupID3.Focus()
            End If
        End If
        EnabledComBo_GroupID(3)
    End Sub

#End Region

    Private Sub EnabledComBo_GroupID(ByVal index As Integer)
        Dim i As Integer
        Dim tdbc, tdbcGroupID As C1.Win.C1List.C1Combo
        If index = 3 Then Exit Sub
        With grpGroupID
            For i = index + 1 To 3
                tdbc = CType(.Controls("tdbcGroupID" & i), C1.Win.C1List.C1Combo)
                tdbc.Text = ""
                tdbc.ReadOnly = True
            Next i
            '*************************
            tdbcGroupID = CType(.Controls("tdbcGroupID" & index), C1.Win.C1List.C1Combo)
            If ReturnValueC1Combo(tdbcGroupID).ToString <> "" Then
                tdbc = CType(.Controls("tdbcGroupID" & index + 1), C1.Win.C1List.C1Combo)
                tdbc.ReadOnly = False
            End If
        End With
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

#Region "Events tdbcSalReportID"

    Private Sub tdbcSalReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalReportID.LostFocus
        If tdbcSalReportID.FindStringExact(tdbcSalReportID.Text) = -1 Then tdbcSalReportID.Text = ""
    End Sub

#End Region

#Region "Events tdbcReportID"

    Private Sub tdbcReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.LostFocus
        If tdbcReportID.FindStringExact(tdbcReportID.Text) = -1 Then tdbcReportID.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcReportID.Close, tdbcSalReportID.Close, tdbcGroupID1.Close, tdbcGroupID2.Close, tdbcGroupID3.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcReportID.Validated, tdbcSalReportID.Validated, tdbcGroupID1.Validated, tdbcGroupID2.Validated, tdbcGroupID3.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#Region "ExportExel"

    Private Const FileNameExcel As String = "Data.xlsx"
    Public giVersion2007 As Integer = -1 ' =1 là Office2007, =0 là Office2003
    Public Function ExportToExcelMax() As Boolean
        Try
            Dim oExcel As Object = CreateObject("Excel.Application") 'Microsoft.Office.Interop.Excel.Application 'Class() ' Create the Excel Application object
            'Update 04/07/2013 kiểm tra máy đang cài phiên bản Office nào
            If giVersion2007 = -1 Then
                CheckVersionExcel(oExcel)
            End If
            'D99C0008.Msg(1)
            If giVersion2007 = 1 Then
                ' Kiểm tra nếu dữ liệu > 65530 dong hoặc >256 cột thì chỉ chạy trên Office 2007
                If tdbg.RowCount > 65530 Then
                    MessageBox.Show(ConvertUnicodeToVietwareF(rL3("So_dong_vuot_qua_gioi_han_cho_phep_cua_Excel") & " (" & tdbg.RowCount & " > 65530)"), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    oExcel.Quit()
                    Return False
                ElseIf tdbg.Columns.Count > 256 Then
                    MessageBox.Show(ConvertUnicodeToVietwareF(rL3("So_cot_vuot_qua_gioi_han_cho_phep_cua_Excel") & " (" & tdbg.Columns.Count & "> 256)"), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    oExcel.Quit()
                    Return False
                End If
            End If
            '******************************************************
            'Kiểm tra tồn tại file Excel đang xuất
            If CloseProcessWindowMax(FileNameExcel) = False Then oExcel.Quit() : Return False
            '******************************************************
            ' D99C0008.Msg(2)
            Dim oPathFile As String = gsApplicationPath + "\" + FileNameExcel ' "Data.xlsx"
            Dim oWorkbook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Add(Type.Missing) ' Create a new Excel Workbook
            Dim oWorkSheet As Microsoft.Office.Interop.Excel.Worksheet ' Create a new Excel Worksheet

            Dim sFirstCol As String = "A"
            Dim iFirstCol As Integer = GetIntColumnExcel(sFirstCol) 'Đổi cột Chuỗi sang Số (VD: cột A đổi thành cột 0)

            Dim StartValue As Integer = 0 ' Vị trí bắt đầu của Rang excel
            Dim EndValue As Integer = 0 ' Vị trí cuối cùng của Rang excel
            Dim PrevPos As Integer = 0 ' Vị trí kế tiếp của Rang excel

            Dim iMaxRow As Long = tdbg.RowCount
            Dim iPackage As Integer = 0 'Số gói cần chạy 
            Dim iLimitRow As Integer 'Số dòng chạy cho 1 gói iPackage
            Dim iRowCount As Integer = 0 ' Tổng số dòng của 1 rang cần khởi tạo (rawData)
            Dim iStartRow As Integer = 0 ' Dòng bắt đầu chạy cho dtData trong 1 gói
            Dim iEndRow As Integer = 0 ' Dòng cuối cùng chạy cho dtData trong 1 gói

            Try
                ' Tạo Sheet mới
                oWorkSheet = CType(oWorkbook.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                oWorkSheet.Name = "Data"

                'Xác định số dòng dữ liệu cần xuất cho 1 gói (iPackage)
                If iMaxRow > 10000 Then
                    iLimitRow = 1000
                Else
                    iLimitRow = 100
                End If

                ' Tìm ký tự "A...Z" của cột
                Dim finalColLetter As String = String.Empty
                Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                Dim colCharsetLen As Integer = colCharset.Length
                If tdbg.Columns.Count > colCharsetLen Then
                    finalColLetter = colCharset.Substring((tdbg.Columns.Count - 1 + iFirstCol) \ colCharsetLen - 1, 1)
                End If
                finalColLetter += colCharset.Substring((tdbg.Columns.Count - 1 + iFirstCol) Mod colCharsetLen, 1)

                'Lấy số gói cần chạy để đưa vào rang excel
                If iMaxRow <= iLimitRow Then ' Nếu Số dòng xuất <= iLimitRow thì 1 Package
                    iPackage = 1
                Else
                    Dim iDecimal As Integer = CInt(iMaxRow Mod iLimitRow)
                    If iDecimal = 0 Then ' Chia hết
                        iPackage = CInt(iMaxRow / iLimitRow)
                    Else ' Chia dư -> Package = Package + 1
                        iPackage = CInt(Int(iMaxRow / iLimitRow))
                        iPackage += 1
                    End If
                End If

                'Tạo bảng và Add Data
                For iX As Long = 1 To iPackage
                    If iX < iPackage Then
                        If iX = 1 Then 'Lần đầu tiên
                            iStartRow = iEndRow
                        Else
                            iStartRow = iEndRow + 1
                        End If
                        iEndRow = CInt(iLimitRow * iX) - 1
                        iRowCount = iLimitRow
                    Else
                        If iPackage = 1 Then
                            iStartRow = 0
                            iEndRow = CInt(iMaxRow - 1)
                            iRowCount = CInt(iMaxRow)
                        Else
                            iStartRow = iEndRow + 1
                            iEndRow = CInt(iMaxRow - 1)
                            iRowCount = CInt(iMaxRow - (iLimitRow * (iX - 1)))
                        End If
                    End If
                    ' D99C0008.Msg(3)
                    StartValue = PrevPos + 1
                    If iX = 1 Then ' Table đầu tiên dành vị trí A1 cho header
                        EndValue = iRowCount + PrevPos + 1
                    Else ' Các Table sau nối tiếp theo không tạo header
                        EndValue = iRowCount + PrevPos
                    End If

                    'Tạo mảng dữ liệu để đưa vào file excel
                    Dim arrData(iRowCount + 1, tdbg.Columns.Count - 1) As Object
                    Dim sColumnFieldName As String = ""
                    Dim sColumnCaption As String = ""
                    Dim iRow_Data As Integer = 0
                    'Phải lấy dữ liệu của bảng dtCaptionCols để kiểm tra, vì bảng dtData có thứ tự cột không đúng như trên lưới
                    For col As Integer = 0 To tdbg.Columns.Count - 1
                        sColumnFieldName = tdbg.Columns(col).DataField
                        sColumnCaption = tdbg.Columns(col).Caption
                        'If Not gbUnicode Then sColumnCaption = ConvertVniToUnicode(sColumnCaption)

                        iRow_Data = 0
                        If iX = 1 Then ' Đưa dữ liệu vào dòng tiêu đề (Header)
                            arrData(0, col) = sColumnCaption
                            iRow_Data += 1
                        End If

                        ' Đưa dữ liệu vào các dòng kế tiếp
                        For row As Integer = iStartRow To iEndRow
                            'Dim dr As DataRow = dtData.Rows(row)
                            ''Nếu cột là chuỗi thì thêm dấu ' phía trước để khi xuất Excel thì hiểu giá trị là chuỗi
                            If tdbg.Columns(col).DataType.Name = "String" Then
                                If gbUnicode Then
                                    arrData(iRow_Data, col) = "'" & tdbg(row, col).ToString
                                Else 'Nếu nhập liệu VNI thì ConvertVniToUnicode dữ liệu dạng chuỗi sang Unicode
                                    arrData(iRow_Data, col) = "'" & ConvertVniToUnicode(tdbg(row, col).ToString)
                                End If
                            Else
                                arrData(iRow_Data, col) = tdbg(row, col)
                            End If
                            iRow_Data += 1
                        Next
                    Next
                    ' D99C0008.Msg(4)
                    ' Fast data export to Excel
                    Dim excelRange As String = String.Format(sFirstCol & "{0}:{1}{2}", StartValue, finalColLetter, EndValue)
                    oWorkSheet.Range(excelRange, Type.Missing).Value2 = arrData
                    'Khung
                    oWorkSheet.Range(excelRange, Type.Missing).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    oWorkSheet.Range(excelRange, Type.Missing).Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                    'Định dạng các cột Excel
                    Dim range As Microsoft.Office.Interop.Excel.Range
                    oWorkSheet.Columns.AutoFit()
                    Dim colIndex As Integer = tdbg.Columns.Count - 1 '0
                    For i As Integer = tdbg.Columns.Count - 1 To 0 Step -1
                        'Xác định vị trí vùng Range
                        range = DirectCast(oWorkSheet.Range(GetStringColumnExcel(colIndex) & StartValue, GetStringColumnExcel(colIndex) & EndValue), Microsoft.Office.Interop.Excel.Range)
                        '=======================================================
                        'Định dạng hiển thị dữ liệu cho cột
                        colIndex = colIndex - 1
                        Select Case tdbg.Columns(i).DataType.Name
                            Case "Decimal" 'Số thập phân
                                range.NumberFormat = "#,##0" & InsertZero(L3Int(tdbg.Columns(i).NumberFormat.Replace("N", "")))
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                            Case "Boolean", "Byte" ' Boolean, Byte là cột checkbox
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                            Case "Integer", "Int32" 'Số nguyên
                                range.NumberFormat = "#,##0"
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                            Case "DateTime" 'Ngày
                                range.NumberFormat = tdbg.Columns(i).NumberFormat
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                            Case Else
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                        End Select
                        '=======================================================
                    Next
                    PrevPos = EndValue 'Giữ vị trí cuối cùng của table trước đó

                    If iX = 1 Then 'Header
                        range = TryCast(oWorkSheet.Rows(1, Type.Missing), Microsoft.Office.Interop.Excel.Range)
                        range.Font.Bold = True
                        range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        'Mau nen
                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)
                    End If
                Next

                Dim orange As Microsoft.Office.Interop.Excel.Range
                'Xóa cột LevelID
                For i As Integer = tdbg.Columns.Count - 1 To 0 Step -1
                    If tdbg.Splits(0).DisplayColumns(i).Visible = False Then
                        orange = DirectCast(oWorkSheet.Range(GetStringColumnExcel(i) & EndValue, GetStringColumnExcel(i) & EndValue), Microsoft.Office.Interop.Excel.Range)
                        orange.EntireColumn.Delete()
                    End If
                Next
                '=========================
                For i As Integer = 0 To tdbg.RowCount - 1
                    Select Case L3Int(tdbg(i, COL_LevelID))
                        Case 1
                            orange = DirectCast(oWorkSheet.Range("A" & i + 2, finalColLetter & i + 2), Microsoft.Office.Interop.Excel.Range)
                            orange.Font.Color = System.Drawing.ColorTranslator.ToOle(txtColor1.BackColor)
                        Case 2
                            orange = DirectCast(oWorkSheet.Range("A" & i + 2, finalColLetter & i + 2), Microsoft.Office.Interop.Excel.Range)
                            orange.Font.Color = System.Drawing.ColorTranslator.ToOle(txtColor2.BackColor)
                        Case 3
                            orange = DirectCast(oWorkSheet.Range("A" & i + 2, finalColLetter & i + 2), Microsoft.Office.Interop.Excel.Range)
                            orange.Font.Color = System.Drawing.ColorTranslator.ToOle(txtColor3.BackColor)
                    End Select
                Next

                'Tắt cảnh báo hỏi có muốn Save As không?
                oExcel.DisplayAlerts = False

                If giVersion2007 = 1 Then
                    oWorkbook.SaveAs(oPathFile, FileFormat:=56)
                Else
                    oWorkbook.SaveAs(oPathFile)
                End If

                oExcel.Workbooks.Open(oPathFile)
                oExcel.Visible = True
                Return True
            Catch ex As Exception
                oWorkbook.Close(False, Type.Missing, Type.Missing)
                ' Release the Application object
                oExcel.Quit()
            Finally
                oWorkSheet = Nothing
                oWorkbook = Nothing
                If oExcel IsNot Nothing Then oExcel = Nothing
                System.GC.Collect()
                System.GC.WaitForPendingFinalizers()
            End Try
        Catch ex As Exception
            D99C0008.Msg(ex.Message)
        End Try
    End Function

    ' Kiểm tra máy có cài Office 2007 trở lên hay không
    Public Function CheckVersionExcel(ByVal appExcel As Object) As Boolean
        'Dim appExcel As New Microsoft.Office.Interop.Excel.Application
        ' appExcel = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        If L3Int(appExcel.Version) >= 12 Then
            Return True
        End If
        Return False
    End Function

    Public Function CloseProcessWindowMax(Optional ByVal FileName As String = FileNameExcel, Optional ByVal bShowMessage As Boolean = True) As Boolean
        'Doan code dung de dong file Excel mo san (khong phai do Chuong trinh mo)
        Dim p As System.Diagnostics.Process = Nothing
        Dim sWindowName As String = "Microsoft Excel - " & FileName
        Try
            For Each pr As Process In Process.GetProcessesByName("EXCEL")
                If sWindowName = pr.MainWindowTitle OrElse pr.MainWindowTitle = sWindowName.Substring(0, sWindowName.LastIndexOf(".")) Then
                    If p Is Nothing Then
                        p = pr
                    ElseIf p.StartTime < pr.StartTime Then
                        p = pr
                    End If
                End If
            Next
            If p IsNot Nothing Then
                If bShowMessage Then
                    If (D99C0008.MsgAsk(rL3("Ban_phai_dong_File") & Space(1) & FileName & Space(1) & rL3("truoc_khi_xuat_Excel") & "." & vbCrLf & rL3("Ban_co_muon_dong_khong")) = Windows.Forms.DialogResult.Yes) Then
                        p.Kill()
                        Return True
                    Else
                        Return False
                    End If
                Else
                    p.Kill()
                    Return True
                End If

            End If
            Return True 'False
        Catch ex As Exception
            Return True
        End Try
    End Function

    Private Function GetIntColumnExcel(ByVal sColumn As String) As Integer
        'Update 8/1/2014: Cách mới cho Office từ 2007 về sau
        Dim charColumn() As Char = sColumn.ToCharArray()
        Dim sum As Integer = 0
        For i As Integer = 0 To charColumn.Length - 1
            sum *= 26
            sum += (Asc(sColumn(i)) - Asc("A") + 1)
        Next
        Return sum - 1
    End Function

    Private Function GetStringColumnExcel(ByVal sColumn As Integer) As String
        Dim divNumber As Integer = sColumn + 1
        Dim columnName As String = ""
        Dim modNumber As Integer
        While divNumber > 0
            modNumber = (divNumber - 1) Mod 26
            columnName = Convert.ToChar(65 + modNumber).ToString() & columnName
            divNumber = CInt(((divNumber - modNumber) / 26))
        End While
        Return columnName
    End Function

#End Region

    Private Sub btnSetupReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetupReport.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", "13")
        SetProperties(arrPro, "ID01", "D13F4200")
        SetProperties(arrPro, "Type", L3Byte(1))
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        Dim frm As Form = CallFormShowDialog("D09D4140", "D09F4120", arrPro)
        'Tạm thời luôn luôn load lại theo yc PSAD
        LoadtdbcReportID()
    End Sub

    Private Sub tdbcReportID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcReportID.SelectedValueChanged
        If tdbcReportID.SelectedValue Is Nothing Then Exit Sub
        Dim sSQL As String = ""
        sSQL &= "  --Do nguon cho Mau cua nhom du lieu" & vbCrLf
        sSQL &= "SELECT Group01ID,  GroupColor01ID, Group02ID,  GroupColor02ID, " & vbCrLf
        sSQL &= "Group03ID, GroupColor03ID" & vbCrLf
        sSQL &= "FROM 	D09T4120 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE 	ReportID = " & SQLString(ReturnValueC1Combo(tdbcReportID))
        Dim dtG As DataTable = ReturnDataTable(sSQL)
        If dtG.Rows.Count > 0 Then
            tdbcGroupID1.SelectedValue = ""
            Dim txt As System.Windows.Forms.TextBox
            Dim tdbc As C1.Win.C1List.C1Combo
            With grpGroupID
                For i As Integer = 1 To 3
                    txt = CType(.Controls("txtColor" & i), System.Windows.Forms.TextBox)
                    tdbc = CType(.Controls("tdbcGroupID" & i), C1.Win.C1List.C1Combo)
                    tdbc.SelectedValue = dtG.Rows(0).Item("Group" & i.ToString("00") & "ID")
                    If dtG.Rows(0).Item("GroupColor" & i.ToString("00") & "ID").ToString <> "" Then
                        txt.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & dtG.Rows(0).Item("GroupColor" & i.ToString("00") & "ID").ToString)
                        txt.Tag = 1
                    Else
                        txt.BackColor = System.Drawing.SystemColors.Control
                    End If
                Next
            End With
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class