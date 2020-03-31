Imports System
Public Class D25F3200

    Private _isMSS As Integer = 0
    Public WriteOnly Property IsMSS() As Integer
        Set(ByVal Value As Integer)
            _isMSS = Value
        End Set
    End Property

    Dim gbEnabledUseFind As Boolean = False

#Region "Const of tdbg"
    Private Const COL_Description As Integer = 0        ' Đề xuất tuyển dụng
    Private Const COL_DivisionName As Integer = 1       ' Đơn vị
    Private Const COL_BlockName As Integer = 2          ' Khối
    Private Const COL_DepartmentName As Integer = 3     ' Phòng ban
    Private Const COL_DutyName As Integer = 4           ' Chức vụ
    Private Const COL_CandidateID As Integer = 5        ' Mã ứng viên
    Private Const COL_CandidateName As Integer = 6      ' Tên ứng viên
    Private Const COL_StatisticsDateFrom As Integer = 7 ' StatisticsDateFrom
    Private Const COL_StatisticsDateTo As Integer = 8   ' StatisticsDateTo
    Private Const COL_TotalDay As Integer = 9           ' Số ngày


#End Region
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeft, chkIsDisplayDetail)
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnClose)

    End Sub

    Private dtGrid As DataTable

    Private Sub D25F3200_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral()
        ResetColorGrid(tdbg)
        gbEnabledUseFind = False
        LoadTDBCombo()
        InputDateInTrueDBGrid(tdbg, COL_StatisticsDateFrom, COL_StatisticsDateTo)
        LoadLanguage()
        SetBackColorObligatory()
        SetShortcutPopupMenu(ContextMenuStrip1)
        tdbcBlockID.Enabled = D25Systems.IsUseBlock
        ResetGrid()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Thoi_gian_thuc_hien_tuyen_dung") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Théi gian thøc hiÖn tuyÓn dóng
        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblDate.Text = rL3("Ngay_de_xuat") 'Ngày đề xuất
        lblStatisticsFromType.Text = rl3("Hinh_thuc_thong_ke") 'Hình thức thống kê
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        chkIsDisplayDetail.Text = rL3("Hien_thi_chi_tiet") 'Hiển thị chi tiết
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcStatisticsFromType.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbcStatisticsFromType.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbcStatisticsToType.Columns("ID").Caption = rl3("Ma") 'Mã
        tdbcStatisticsToType.Columns("Name").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_Description).Caption = rl3("De_xuat_tuyen_dung") 'Đề xuất tuyển dụng
        tdbg.Columns(COL_DivisionName).Caption = rl3("Don_vi") 'Đơn vị
        tdbg.Columns(COL_BlockName).Caption = rl3("Khoi") 'Khối
        tdbg.Columns(COL_DepartmentName).Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_DutyName).Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns(COL_CandidateID).Caption = rl3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns(COL_CandidateName).Caption = rl3("Ten_ung_vien") 'Tên ứng viên
        tdbg.Columns(COL_TotalDay).Caption = rl3("So_ngay") 'Số ngày
    End Sub

    Private Sub D25F3200_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(sender, Nothing)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
        End Select
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBGrid() 'Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        'If FlagAdd Then
        '    ' Thêm mới thì gán sFind ="" và gán FilterText =""
        '    ResetFilter(tdbg, sFilter, bRefreshFilter)
        '    'sFind = ""
        '    'sFindServer = "" ' Nếu có sử dụng Lọc để In
        'End If
        Dim sSQL As String = SQLStoreD25P3200()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        'If sKey <> "" Then
        '    Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
        '    Dim dr() As DataRow = dt1.Select(XXXXXX & "=" & SQLString(sKey), dt1.DefaultView.Sort)
        '    If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
        '    If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        'End If
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        'If Not chkShowDisabled.Checked Then
        '    If strFind <> "" Then strFind &= " And "
        '    strFind &= "Disabled =0"
        'End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, ContextMenuStrip1, tdbg.RowCount, gbEnabledUseFind)
      FooterTotalGrid(tdbg, COL_Description)
    End Sub

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

    '*****************************
    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_Description}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        ' End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

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
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_TotalDay
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDotSign)
        End Select
    End Sub

    Dim bPressF5 As Boolean = False
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        '************************************
        If Not AllowFilter() Then Exit Sub
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
        bPressF5 = True
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3200
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 10/07/2014 09:13:32
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3200() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrlf)
        sSQL &= "Exec D25P3200 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcStatisticsFromType)) & COMMA 'StatisticsFrom, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcStatisticsToType)) & COMMA 'StatisticsTo, varchar[50], NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Value) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Value) 'DateTo, datetime, NOT NULL
        sSQL &= COMMA & SQLNumber(chkIsDisplayDetail.Checked)
        Return sSQL
    End Function

    Dim dtBlockID, dtDepartmentID As DataTable
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        Dim sUnicode As String = ""
        Dim sAll As String = ""
        UnicodeAllString(sUnicode, sAll, gbUnicode)

        'Load tdbcBlockID
        dtBlockID = ReturnTableBlockID_D09P6868("%", Me.Name, _isMSS)
        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID_D09P6868("%", Me.Name, _isMSS)

        'Load tdbcStatisticsFromType/ StatisticsToType
        sSQL = "SELECT	  ID, Name" & gsLanguage & sUnicode & " AS Name FROM D25N5555 ('" & Me.Name & "','StatisticsFromType','','','','')"
        LoadDataSource(tdbcStatisticsFromType, sSQL, gbUnicode)
        sSQL = "SELECT	  ID, Name" & gsLanguage & sUnicode & " AS Name FROM D25N5555 ('" & Me.Name & "','StatisticsToType','','','','')"
        LoadDataSource(tdbcStatisticsToType, sSQL, gbUnicode)

        LoadCboDivisionIDAll(tdbcDivisionID, "D09", True, gbUnicode)
        LoadDefault()
    End Sub

#Region "Events tdbcDivisionID load tdbcDepartmentID"

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        LoadtdbcBlockID(tdbcBlockID, dtBlockID, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        tdbcBlockID.SelectedIndex = 0
    End Sub

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
            tdbcBlockID.Text = ""
            Exit Sub
        End If
    End Sub

#End Region

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then tdbcBlockID.Text = "" : tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ReturnValueC1Combo(tdbcBlockID), ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        tdbcDepartmentID.SelectedIndex = 0
    End Sub
#End Region

    Private Sub tdbcName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus, tdbcStatisticsFromType.LostFocus, tdbcStatisticsToType.LostFocus
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbc.FindStringExact(tdbc.Text) = -1 Then tdbc.Text = ""
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close, tdbcDepartmentID.Close, tdbcBlockID.Close, tdbcStatisticsFromType.Close, tdbcStatisticsToType.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Validated, tdbcDepartmentID.Validated, tdbcBlockID.Validated, tdbcStatisticsFromType.Validated, tdbcStatisticsToType.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub LoadDefault()
        tdbcDivisionID.SelectedIndex = 0
        'tdbcBlockID.SelectedIndex = 0
        tdbcStatisticsFromType.SelectedIndex = 0
        tdbcStatisticsToType.SelectedIndex = 0
        c1dateFrom.Value = Now
        c1dateTo.Value = Now
    End Sub

    Private Sub tdbcStatisticsFromType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcStatisticsFromType.SelectedValueChanged
        SetCaption(COL_StatisticsDateFrom, tdbcStatisticsFromType)
    End Sub

    Private Sub SetCaption(ByVal Col As Integer, ByVal tdbcStatistic As C1.Win.C1List.C1Combo)
        Dim Caption As String = ReturnValueC1Combo(tdbcStatistic, "Name")
        If geLanguage = EnumLanguage.Vietnamese And gbUnicode = False Then Caption = ConvertVniToUnicode(Caption)
        tdbg.Columns(Col).Caption = Caption
    End Sub

    Private Sub tdbcStatisticsToType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcStatisticsToType.SelectedValueChanged
        SetCaption(COL_StatisticsDateTo, tdbcStatisticsToType)
    End Sub

    Private Function AllowFilter() As Boolean
        If Not CheckValidDateFromTo(c1dateFrom, c1dateTo) Then Return False
        'Ngay_de_xuat
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
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcStatisticsFromType.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Hinh_thuc_thong_ke"))
            tdbcStatisticsFromType.Focus()
            Return False
        End If
        If tdbcStatisticsToType.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Hinh_thuc_thong_ke"))
            tdbcStatisticsToType.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        c1dateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcStatisticsFromType.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcStatisticsToType.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub chkIsDisplayDetail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsDisplayDetail.CheckedChanged
        If tdbg.Columns.Count = 0 Then Exit Sub
        tdbg.Splits(0).DisplayColumns(COL_CandidateID).Visible = chkIsDisplayDetail.Checked
        tdbg.Splits(0).DisplayColumns(COL_CandidateName).Visible = chkIsDisplayDetail.Checked
        If bPressF5 Then btnFilter_Click(Nothing, Nothing)
        If Not chkIsDisplayDetail.Checked Then
            tdbg.LeftCol = COL_Description
        End If
    End Sub
End Class