Imports System.Text
Public Class D45F2060
    Private _formIDPermission As String = "D45F2060"
    Public WriteOnly Property FormIDPermission As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property


    Private dtGrid As DataTable

#Region "Const of tdbg - Total of Columns: 13"
    Private Const COL_AbsentVoucherID As Integer = 0  ' AbsentVoucherID
    Private Const COL_DepartmentID As Integer = 1     ' Phòng ban
    Private Const COL_TeamID As Integer = 2           ' Tổ nhóm 
    Private Const COL_DateFrom As Integer = 3         ' Từ ngày
    Private Const COL_DateTo As Integer = 4           ' Đến ngày
    Private Const COL_Remark As Integer = 5           ' Ghi chú
    Private Const COL_CreateDate As Integer = 6       ' CreateDate
    Private Const COL_CreateUserID As Integer = 7     ' CreateUserID
    Private Const COL_LastModifyDate As Integer = 8   ' LastModifyDate
    Private Const COL_LastModifyUserID As Integer = 9 ' LastModifyUserID
    Private Const COL_DepartmentName As Integer = 10  ' DepartmentName
    Private Const COL_TeamName As Integer = 11        ' TeamName
    Private Const COL_AttMode As Integer = 12         ' AttMode
#End Region
    Private Sub D13F2020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        ResetColorGrid(tdbg)
        gbEnabledUseFind = False
        LoadTDBGrid()
        InputDateInTrueDBGrid(tdbg, COL_DateFrom, COL_DateTo)
        SetShortcutPopupMenu(Me, ToolStrip1, ContextMenuStrip1)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_dieu_chinh_thu_nhap") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Danh sÀch ¢iÒu chÙnh thu nhËp
        '================================================================ 
        tdbg.Columns(COL_DepartmentID).Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_TeamID).Caption = rl3("To_nhom") 'Tổ nhóm 
        tdbg.Columns(COL_DateFrom).Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns(COL_DateTo).Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns(COL_Remark).Caption = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        mnsDetail.Text = rl3("_Chi_tiet") '&Chi tiết
        tsmDetail.Text = rl3("_Chi_tiet") '&Chi tiết
    End Sub
    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = SQLStoreD45P2060()
        dtGrid = ReturnDataTable(sSQL)
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

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub
    Private Sub ResetGrid()
        CheckMenu(_formIDPermission, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        mnsDetail.Enabled = tdbg.RowCount > 0 And ReturnPermission(_formIDPermission) >= 1
        tsmDetail.Enabled = mnsDetail.Enabled
        FooterTotalGrid(tdbg, COL_DepartmentID)
    End Sub

#Region "tdbg"
    Dim sFilter As New System.Text.StringBuilder()
    'Dim sFilterServer As New System.Text.StringBuilder()
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
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tdbg_FetchCellTips(sender As Object, e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        If e.Row >= 0 Then
            Select Case e.ColIndex
                Case COL_DepartmentID
                    e.CellTip = tdbg.Columns(COL_DepartmentName).Text
                Case COL_TeamID
                    e.CellTip = tdbg.Columns(COL_TeamName).Text
                Case Else
                    e.CellTip = ""
            End Select
        Else
            e.CellTip = ""
        End If
    End Sub
#End Region

#Region "Menu"
    Private Sub tsbAdd_Click(sender As Object, e As EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D45F2061
        With f
            .AbsentVoucherID = ""
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            .Dispose()
            If .bSaved Then LoadTDBGrid(True, .AbsentVoucherID)
        End With
    End Sub

    Private Sub tsbView_Click(sender As Object, e As EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D45F2061
        f.AbsentVoucherID = tdbg.Columns(COL_AbsentVoucherID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        If Not CheckStore(SQLStoreD45P5555("Kiem tra truoc khi Sua", 2)) Then Exit Sub

        Dim Bookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then Bookmark = tdbg.Bookmark
        Dim f As New D45F2061
        With f
            .AbsentVoucherID = tdbg.Columns(COL_AbsentVoucherID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
            If .bSaved Then LoadTDBGrid(False, tdbg.Columns(COL_AbsentVoucherID).Text)
        End With
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If Not CheckStore(SQLStoreD45P5555("Kiem tra truoc khi Xoa", 1)) Then Exit Sub

        Dim sSQL As New StringBuilder
        sSQL.Append(SQLStoreD45P2062() & vbCrLf)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
        Else
            DeleteNotOK()
        End If
    End Sub
 
    Private Sub tsbSysInfo_Click(sender As Object, e As EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D29F5558") '  Code cũ truyền là D29F5558
        SetProperties(arrPro, "AuditCode", "TimeSheetRecording")
        SetProperties(arrPro, "AuditItemID", tdbg.Columns(COL_AbsentVoucherID).Text)
        SetProperties(arrPro, "mode", "1")
        SetProperties(arrPro, "CreateUserID", tdbg.Columns(COL_CreateUserID).Text)
        SetProperties(arrPro, "CreateDate", tdbg.Columns(COL_CreateDate).Text)

        CallFormShow(Me, "D91D0640", "D91F1655", arrPro)
    End Sub

    Private Sub tsmDetail_Click(sender As Object, e As EventArgs) Handles tsmDetail.Click, mnsDetail.Click
        If tdbg.Columns(COL_AttMode).Text = "0" Then
            Dim f As New D45F2062
            With f
                .AbsentVoucherID = tdbg.Columns(COL_AbsentVoucherID).Text
                .DepartmentID = tdbg.Columns(COL_DepartmentID).Text
                .TeamID = tdbg.Columns(COL_TeamID).Text
                .Remark = tdbg.Columns(COL_Remark).Text
                If CheckStore(SQLStoreD45P5555("Kiem tra truoc khi xem chi tiet", 2)) = False Then
                    .FormState = EnumFormState.FormView
                Else
                    .FormState = EnumFormState.FormEdit
                End If
                .ShowDialog()
                If .bSaved Then LoadTDBGrid(False, tdbg.Columns(COL_AbsentVoucherID).Text)
                .Dispose()
            End With
        Else
            Dim f As New D45F2063
            With f
                .AttMode = tdbg.Columns(COL_AttMode).Text
                .AbsentVoucherID = tdbg.Columns(COL_AbsentVoucherID).Text
                .Remark = tdbg.Columns(COL_Remark).Text
                If CheckStore(SQLStoreD45P5555("Kiem tra truoc khi xem chi tiet", 2)) = False Then
                    .FormState = EnumFormState.FormView
                Else
                    .FormState = EnumFormState.FormEdit
                End If
                .ShowDialog()
                If .bSaved Then LoadTDBGrid(False, tdbg.Columns(COL_AbsentVoucherID).Text)
                .Dispose()
            End With
        End If
    End Sub
    Private Sub tsbClose_Click(sender As Object, e As EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub
#End Region


#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""

    Dim dtCaptionCols As DataTable

    'DLL sử dụng Properties
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Giống sự kiện Finder_FindClick
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_DepartmentID}
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbg.Splits.Count - 1
                AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
            Next
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode) ' Dùng DLL 
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2060
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/10/2016 11:40:36
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2060() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrlf)
        sSQL &= "Exec D45P2060 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'WhereClause, nvarchar[4000], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/10/2016 11:41:41
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P5555(sComment As String, iMode As Byte) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "Exec D45P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_AbsentVoucherID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) 'Num01, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2062
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/10/2016 02:27:35
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2062() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu" & vbCrlf)
        sSQL &= "Exec D45P2062 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_AbsentVoucherID).Text) & COMMA 'AbsentVoucherID, varchar[50], NOT NULL
        sSQL &= SQLNumber(tdbg.Columns(COL_AttMode).Text) 'AttMode, int, NOT NULL
        Return sSQL
    End Function


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
    End Sub

    
End Class