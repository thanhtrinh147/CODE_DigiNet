Imports System.Windows.Forms
'#-------------------------------------------------------------------------------------
'# Created Date: 21/05/2007 2:34:58 PM
'# Created User: Nguyễn Lê Phương
'# Modify Date: 21/05/2007 2:34:58 PM
'# Modify User: Nguyễn Lê Phương
'#-------------------------------------------------------------------------------------
Public Class D45F1010
	Dim report As D99C2003
	Private _formIDPermission As String = "D45F1010"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property


#Region "Const of tdbg - Total of Columns: 12"
    Private Const COL_DisplayOrder As Integer = 0     ' Thứ tự hiển thị
    Private Const COL_StageID As Integer = 1          ' Mã công đoạn
    Private Const COL_StageName As Integer = 2        ' Diễn giải
    Private Const COL_DepartmentID As Integer = 3     ' Phòng ban
    Private Const COL_DepartmentName As Integer = 4   ' Tên phòng ban
    Private Const COL_TeamID As Integer = 5           ' Tổ nhóm
    Private Const COL_TeamName As Integer = 6         ' Tên tổ nhóm
    Private Const COL_CreateUserID As Integer = 7     ' CreateUserID
    Private Const COL_CreateDate As Integer = 8       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 9 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 10  ' LastModifyDate
    Private Const COL_Disabled As Integer = 11        ' KSD
#End Region


    Dim dtGrid, dtCaptionCols As New DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

#Region "Form"

    Private Sub D45F1010_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
        Select Case e.KeyCode
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub D45F1010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        ResetColorGrid(tdbg)

        Loadlanguage()
        LoadTDBGrid()
        CallD99U1111()
        btnInfo.Enabled = ReturnPermission("D45F1010") >= EnumPermission.View
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_cong_doan_-_D45F1010") & UnicodeCaption(gbUnicode) 'Danh móc c¤ng ¢oÁn - D45F1010
        '================================================================ 
        btnInfo.Text = rl3("Thong_tin__he_so") 'Thông tin &hệ số
        '================================================================ 
        tdbg.Columns(COL_DisplayOrder).Caption = rL3("Thu_tu_hien_thi") 'Thứ tự hiển thị
        tdbg.Columns(COL_StageID).Caption = rL3("Ma_cong_doan") 'Mã công đoạn
        tdbg.Columns(COL_StageName).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_DepartmentID).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_TeamName).Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_Disabled).Caption = rL3("KSD") 'KSD
        '================================================================ 
        btnF12.Text = "F12 ( " & rL3("Hien_thi") & " )" 'F12

        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung")
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        'Dim sSQL As String = ""
        'sSQL &= "SELECT	DisplayOrder, StageID, StageName" & UnicodeJoin(gbUnicode) & " as StageName, Note" & UnicodeJoin(gbUnicode) & " as Note, Disabled, CreateUserID, CreateDate," & vbCrLf
        'sSQL &= "LastModifyUserID,LastModifyDate, UP01, UP02, UP03, UP04, UP05" & vbCrLf
        'sSQL &= "From D45T1010 WITH(NOLOCK) " & vbCrLf
        'sSQL &= "Order by DisplayOrder, StageID"

        'ID 83986 25.02.2016
        dtGrid = ReturnDataTable(SQLStoreD45P1012)

        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("StageID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
        End If
        If Not tdbg.Focused Then tdbg.Focus()
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1012
    '# Created User: KIMLONG
    '# Created Date: 09/03/2016 04:02:36
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1012() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Store load luoi" & vbCrlf)
        sSQL &= "Exec D45P1012 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Laguage, varchar[2], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function



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
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
    End Property

    Private sFindServer As String = ""
    Public WriteOnly Property strNewServer() As String
        Set(ByVal Value As String)
            sFindServer = Value
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        ShowFindDialogClientServer(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    sFindServer = ResultWhereClauseServer.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub ReLoadTDBGrid()

        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled =0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        '  LoadGridFind(tdbg, dtGrid, strFind)'gây lỗi không nhập được ký tự thứ 2 trên filter
        CheckMyMenu()
        FooterTotalGrid(tdbg, COL_StageID)
    End Sub

    Private Sub CheckMyMenu()
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , "D45F5605")
    End Sub

#End Region

#Region "tdbg"

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.RowCount < 1 Then Exit Sub
        If tdbg.FilterActive Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            WriteLogFile(ex.Message)
        End Try
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_DisplayOrder
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_Disabled
                If ChrW(Keys.Space).Equals(e.KeyChar) Then Exit Sub
                e.Handled = True
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            tdbg_DoubleClick(Nothing, Nothing)
            Exit Sub
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

#End Region

#Region "Menu"

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D45F1011
        With f
            .StageID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            Dim sKey As String = .StageID
            .Dispose()
            If .bSaved Then
                LoadTDBGrid(True, sKey)
            End If
        End With
    End Sub

    Private Sub tsbInherit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbInherit.Click, tsmInherit.Click, mnsInherit.Click
        Dim f As New D45F1012
        With f
            .ShowDialog()
            .Dispose()
            If .bSaved Then
                Dim Bookmark As Integer
                If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
                LoadTDBGrid(True)
                If Not IsDBNull(Bookmark) Then tdbg.Bookmark = Bookmark
            End If
        End With
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D45F1011
        f.StageID = tdbg.Columns(COL_StageID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D45F1011
        f.StageID = tdbg.Columns(COL_StageID).Text
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        Dim sKey As String = f.StageID
        f.Dispose()
        If f.bSaved Then
            LoadTDBGrid(False, sKey)
        End If
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowDelete() Then Exit Sub
        Dim sSQL As String = ""
        sSQL = "Delete D45T1011 Where StageID = " & SQLString(tdbg.Columns(COL_StageID).Text) & vbCrLf
        sSQL = "Delete D45T1010 Where StageID = " & SQLString(tdbg.Columns(COL_StageID).Text)
        Dim bm As Integer = tdbg.Bookmark
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            'RunAuditLog(AuditCodeStages, "03", tdbg.Columns(COL_StageID).Text, tdbg.Columns(COL_StageName).Text)
            Lemon3.D91.RunAuditLog("45", AuditCodeStages, "03", tdbg.Columns(COL_StageID).Text, tdbg.Columns(COL_StageName).Text)
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            CheckMyMenu()
            FooterTotalGrid(tdbg, COL_StageID)
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbPrint.Click, tsmPrint.Click, mnsPrint.Click
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        'Dim report As New D99C1003
        '************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D45R4020"
        Dim sSubReportName As String = "D91R0000"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        sReportCaption = rl3("Bao_cao_danh_muc_cong_doan") & " - " & sReportName
        'sPathReport = Application.StartupPath & "\XReports\" & sReportName & ".rpt"
        sPathReport = UnicodeGetReportPath(gbUnicode, 0, "") & sReportName & ".rpt"
        sSQL = "Select * From D45T1010 WITH(NOLOCK) " & vbCrLf
        If sFind <> "" Then
            sSQL &= "And " & sFindServer & vbCrLf
        End If
        sSQL &= "Order by StageID"
        sSQLSub = "Select * From D91V0016 Where DivisionID='%'"
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(dtGrid.DefaultView.ToTable)
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub tsbExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới không có nút Hiển thị)
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        ' Dim frm As New D99F2222
        'Gọi form Xuất Excel như sau:
	ResetTableForExcel(tdbg, dtCaptionCols)
	CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
        'With frm
        '    .UseUnicode = gbUnicode
        '    .FormID = Me.Name
        '    .dtLoadGrid = dtCaptionCols
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtGrid
        '    .ShowDialog()
        '    .Dispose()
        'End With
    End Sub

    Private Sub tsmImportData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbImportData.Click, tsmImportData.Click, mnsImportData.Click
        Me.Cursor = Cursors.WaitCursor
        ' .bSaved = False
        '  Dim frm As New D80F2090
        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090(D45, "D45F5605", "D45F1010") Then
            Dim iBookmark As Integer = tdbg.Row
            LoadTDBGrid(True)
            tdbg.Bookmark = iBookmark
        End If
        'With frm
        '    .FormActive = "D80F2090"
        '    .FormPermission = "D45F5605"
        '    .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '    .ModuleID = D45
        '    .TransTypeID = "D45F1010" 'Theo TL phân tích
        '    .ShowDialog()
        '    If .OutPut01 Then .bSaved = .OutPut01
        '    .Dispose()
        'End With

        'If .bSaved Then
        '    Dim iBookmark As Integer = tdbg.Row
        '    LoadTDBGrid(True)
        '    tdbg.Bookmark = iBookmark
        'End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowDelete() As Boolean
        Dim sSQL As String
        sSQL = "Select * From D45T1021  WITH(NOLOCK) Where StageID='" & tdbg.Columns(COL_StageID).Text & "'" & vbCrLf
        If ExistRecord(sSQL) Then
            D99C0008.MsgL3(rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_xoa"), L3MessageBoxIcon.Exclamation)
            Return False
        End If

        sSQL = "Select * From D45T1001  WITH(NOLOCK) Where StageID='" & tdbg.Columns(COL_StageID).Text & "'" & vbCrLf
        If ExistRecord(sSQL) Then
            D99C0008.MsgL3(rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_xoa"), L3MessageBoxIcon.Exclamation)
            Return False
        End If

        sSQL = "Select * From D45T2001  WITH(NOLOCK) Where StageID='" & tdbg.Columns(COL_StageID).Text & "'" & vbCrLf
        If ExistRecord(sSQL) Then
            D99C0008.MsgL3(rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_xoa"), L3MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function


    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub btnInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.Click
        Me.Cursor = Cursors.WaitCursor
        'Dim frm As New D13F1110
        'With frm
        '    .Type = "D45T1010"
        '    .DutyID = "%"
        '    .FormPermision = "D45F1010"
        '    .FormStatus = EnumFormState.FormAdd
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "Type", "D45T1010")
        SetProperties(arrPro, "TypeID", "%")
        SetProperties(arrPro, "FormIDPermission", "D45F1010")
        SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
        CallFormShow(Me, "D13D0140", "D13F1110", arrPro)
        Me.Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub D45F1010_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL_StageID, COL_DisplayOrder}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub


End Class