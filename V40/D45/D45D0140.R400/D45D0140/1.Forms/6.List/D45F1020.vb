'#-------------------------------------------------------------------------------------
'# Created Date: 21/05/2007 2:36:14 PM
'# Created User: Nguyễn Lê Phương
'# Modify Date: 21/05/2007 2:36:14 PM
'# Modify User: Nguyễn Lê Phương
'#-------------------------------------------------------------------------------------

Public Class D45F1020
	Private _formIDPermission As String = "D45F1020"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property

    Dim dtGrid, dtCaptionCols As New DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

#Region "Const of tdbg"
    Private Const COL_PriceListID As Integer = 0      ' Mã bảng giá
    Private Const COL_PriceListName As Integer = 1    ' Diễn giải
    Private Const COL_ValidFrom As Integer = 2        ' Hiệu lực từ
    Private Const COL_ValidTo As Integer = 3          ' Hiệu lực đến
    Private Const COL_DateFrom As Integer = 4         ' Từ ngày
    Private Const COL_DateTo As Integer = 5           ' Đến ngày
    Private Const COL_Disabled As Integer = 6         ' KSD
    Private Const COL_CreateUserID As Integer = 7     ' CreateUserID
    Private Const COL_CreateDate As Integer = 8       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 9 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 10  ' LastModifyDate
    Private Const COL_Mode As Integer = 11            ' Mode
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkShowDisabled)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
    End Sub

#Region "Form"

    Private Sub D45F1020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        ResetColorGrid(tdbg)
        Loadlanguage()
        LoadTDBGrid()
        '**************************
        InputDateInTrueDBGrid(tdbg, COL_ValidFrom, COL_ValidTo)
        '**************************
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_bang_gia_-_D45F1020") & UnicodeCaption(gbUnicode) 'Danh móc b¶ng giÀ - D45F1020
        '================================================================ 
        tdbg.Columns("PriceListID").Caption = rl3("Ma_bang_gia") 'Mã bảng giá
        tdbg.Columns("PriceListName").Caption = rl3("Dien_giai")  'Tên sản phẩm
        tdbg.Columns("ValidFrom").Caption = rl3("Hieu_luc_tu") 'Hiệu lực từ
        tdbg.Columns("ValidTo").Caption = rl3("Hieu_luc_den") 'Hiệu lực đến
        tdbg.Columns("DateFrom").Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'Không hiển thị
        '================================================================ 
        tsmUpdateNewPrice.Text = rl3("Cap_nhat_gia_moi")
        mnsUpdateNewPrice.Text = tsmUpdateNewPrice.Text
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung")
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        'Dim sSQL As String = ""
        'sSQL = "SELECT 	PriceListID, PriceListName" & UnicodeJoin(gbUnicode) & " as PriceListName, ValidFrom, ValidTo, DateFrom, DateTo, "
        'sSQL &= "Note" & UnicodeJoin(gbUnicode) & " as Note, Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, Mode " & vbCrLf
        'sSQL &= "From D45T1020 WITH(NOLOCK) " & vbCrLf
        'sSQL &= "Order by PriceListID"

        'ID 90547 07.10.2016
        dtGrid = ReturnDataTable(SQLStoreD45P1021)

        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("PriceListID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
        End If
        If Not tdbg.Focused Then tdbg.Focus()
    End Sub
#End Region

    Private Sub c1dateEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        Try
            If e.KeyCode = Keys.Tab Then
                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
                tdbg.Col = tdbg.Col + 1
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

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

    End Sub

    Private Sub CheckMyMenu()
        FooterTotalGrid(tdbg, COL_PriceListID)

        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , "D45F5604")

        tsmUpdateNewPrice.Enabled = tdbg.RowCount > 0
        mnsUpdateNewPrice.Enabled = tsmUpdateNewPrice.Enabled
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
        Dim f As New D45F1021
        With f
            .PriceListID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            Dim sKey As String = .PriceListID
            .Dispose()
            If .bSaved Then
                LoadTDBGrid(True, sKey)
            End If
        End With
    End Sub

    Private Sub tsbInherit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbInherit.Click, tsmInherit.Click, mnsInherit.Click
        Dim f As New D45F1025
        With f
            .OldPriceListID = tdbg.Columns(COL_PriceListID).Text
            .FormState = EnumFormState.FormAdd
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
        Dim f As New D45F1021
        f.PriceListID = tdbg.Columns(COL_PriceListID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim sStatus As String = "1"
        If Not CheckMyStore(SQLStoreD45P5555(2), sStatus) Then Exit Sub

        Dim f As New D45F1021
        f.Status = sStatus
        f.PriceListID = tdbg.Columns(COL_PriceListID).Text
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        Dim sKey As String = f.PriceListID
        f.Dispose()
        If f.bSaved Then
            LoadTDBGrid(False, sKey)
        End If
    End Sub

    Private Function CheckMyStore(ByVal SQL As String, ByRef sStatus As String) As Boolean
        'Update 1/03/2010: sửa lại hàm checkstore có trả ra field FontMessage
        'Cách kiểm tra của hàm CheckStore này sẽ như sau:
        'Nếu store trả ra Status <> 0 thì xuất Message theo dạng FontMessage
        'Nếu store trả ra MsgAsk = 0 thì xuất Message nút Ok,  MsgAsk = 1 thì xuất Message nút Yes, No

        Dim dt As New DataTable
        Dim sMsg As String
        Dim bMsgAsk As Boolean = False
        dt = ReturnDataTable(SQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString = "0" Then
                sStatus = "0"
                dt = Nothing
                Return True
            End If

            sMsg = dt.Rows(0).Item("Message").ToString
            Dim bFontMessage As Boolean = False
            If dt.Columns.Contains("FontMessage") Then bFontMessage = True
            If dt.Columns.Contains("MsgAsk") Then
                If L3Byte(dt.Rows(0).Item("MsgAsk")) = 1 Then
                    bMsgAsk = True
                End If
            End If

            If Not bMsgAsk Then 'OKOnly
                If Not bFontMessage Then
                    D99C0008.MsgL3(ConvertVietwareFToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            D99C0008.MsgL3(ConvertVietwareFToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
                        Case "1" 'Unicode
                            D99C0008.MsgL3(sMsg, L3MessageBoxIcon.Exclamation)
                        Case "2" 'Convert Vni To Unicode
                            D99C0008.MsgL3(ConvertVniToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
                    End Select
                End If
                dt = Nothing
                Return False
            Else 'YesNo
                If Not bFontMessage Then
                    If D99C0008.MsgAsk(ConvertVietwareFToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        dt = Nothing
                        Return True
                    Else
                        dt = Nothing
                        Return False
                    End If
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            If D99C0008.MsgAsk(ConvertVietwareFToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "1" 'Unicode
                            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "2" 'Convert Vni To Unicode
                            If D99C0008.MsgAsk(ConvertVniToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                    End Select
                End If
            End If
            dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return False
        End If
        Return True
    End Function

    Private Function AllowEdit() As Boolean
        Dim sSQL As String = SQLStoreD45P5555(2)
        Return CheckStore(sSQL)
    End Function

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
        sSQL &= SQLString(tdbg.Columns(COL_PriceListID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1021
    '# Created User: KIMLONG
    '# Created Date: 07/10/2016 03:21:49
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1021() As String
        Dim sSQL As String = ""
        sSQL &= ("-- -- Do nguon danh sach phieu" & vbCrlf)
        sSQL &= "Exec D45P1021 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function



    Private Function AllowUpdateNewPrice() As Boolean
        Dim sSQL As String = SQLStoreD45P5555(3)
        Return CheckStore(sSQL)
    End Function

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not CheckStore(SQLStoreD45P5555(1)) Then Exit Sub
        Dim sSQL As String = ""
        sSQL = "Delete D45T1021 Where PriceListID = " & SQLString(tdbg.Columns(COL_PriceListID).Text) & vbCrLf
        sSQL &= "Delete D45T1020 Where PriceListID = " & SQLString(tdbg.Columns(COL_PriceListID).Text) & vbCrLf
        sSQL &= "Delete D45T1024 Where PriceListID = " & SQLString(tdbg.Columns(COL_PriceListID).Text)
        Dim bm As Integer = tdbg.Bookmark
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            'RunAuditLog(AuditCodePriceLists, "03", tdbg.Columns(COL_PriceListID).Text, tdbg.Columns(COL_PriceListName).Text, tdbg.Columns(COL_DateFrom).Text, tdbg.Columns(COL_DateTo).Text)
            Lemon3.D91.RunAuditLog("45", AuditCodePriceLists, "03", tdbg.Columns(COL_PriceListID).Text, tdbg.Columns(COL_PriceListName).Text, tdbg.Columns(COL_DateFrom).Text, tdbg.Columns(COL_DateTo).Text)
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            CheckMyMenu()
            FooterTotalGrid(tdbg, COL_PriceListID)
        Else
            DeleteNotOK()
        End If


        '        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        '        If Not AllowDelete() Then Exit Sub
        '        Dim sSQL As String = ""
        '        sSQL = "Delete D45T1021 Where PriceListID = " & SQLString(tdbg.Columns(COL_PriceListID).Text) & vbCrLf
        '        sSQL &= "Delete D45T1020 Where PriceListID = " & SQLString(tdbg.Columns(COL_PriceListID).Text) & vbCrLf
        '        sSQL &= "Delete D45T1024 Where PriceListID = " & SQLString(tdbg.Columns(COL_PriceListID).Text)
        '        Dim bm As Integer = tdbg.Bookmark
        '        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        '        If bRunSQL Then
        '            RunAuditLog(AuditCodePriceLists, "03", tdbg.Columns(COL_PriceListID).Text, tdbg.Columns(COL_PriceListName).Text, tdbg.Columns(COL_DateFrom).Text, tdbg.Columns(COL_DateTo).Text)
        '            DeleteOK()
        '            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
        '            CheckMyMenu()
        '            FooterTotalGrid(tdbg, COL_PriceListID)
        '        Else
        '            DeleteNotOK()
        '        End If
    End Sub


    Private Function AllowDelete() As Boolean
        Dim sSQL As String = SQLStoreD45P5555(1)
        Return CheckStore(sSQL)
    End Function

    Private Sub tsmUpdateNewPrice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmUpdateNewPrice.Click, mnsUpdateNewPrice.Click
        Dim f As New D45F1022
        With f
            .PriceListID = tdbg.Columns(COL_PriceListID).Text
            .PriceListName = tdbg.Columns(COL_PriceListName).Text
            .DateFrom = SQLDateShow(tdbg.Columns(COL_DateFrom).Text)
            .DateTo = SQLDateShow(tdbg.Columns(COL_DateTo).Text)
            .Mode = tdbg.Columns(COL_Mode).Text
            If AllowUpdateNewPrice() = False Then
                .FormState = EnumFormState.FormView
            End If
            .ShowDialog()
            .Dispose()
            If .bSaved Then
                LoadTDBGrid(True, tdbg.Columns(COL_PriceListID).Text)
            End If
        End With
    End Sub

    Private Sub tsbExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới không có nút Hiển thị)
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_PriceListID, COL_PriceListName}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If

        'Dim frm As New D99F2222
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
        '       .bSaved = False
        '       Dim frm As New D80F2090
        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090(D45, "D45F5604", "D45F1020") Then
            Dim iBookmark As Integer = tdbg.Row
            LoadTDBGrid(True)
            tdbg.Bookmark = iBookmark
        End If
        'With frm
        '    .FormActive = "D80F2090"
        '    .FormPermission = "D45F5604"
        '    .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '    .ModuleID = D45
        '    .TransTypeID = "D45F1020" 'Theo TL phân tích
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

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbPrint.Click, tsmPrint.Click, mnsPrint.Click
        'Dim frm As New D45F4010
        'frm.PriceListID = tdbg.Columns(COL_PriceListID).Text
        'frm.ShowDialog()
        'frm.Dispose()

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "PriceListID", tdbg.Columns(COL_PriceListID).Text)
        CallFormShowDialog("D45D0340", "D45F4010", arrPro)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#End Region

End Class