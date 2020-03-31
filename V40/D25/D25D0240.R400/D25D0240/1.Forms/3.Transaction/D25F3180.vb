Imports System.Text
Public Class D25F3180
	Dim dtCaptionCols As DataTable


#Region "Const of tdbg"
    Private Const COL_PlanTransID As Integer = 0     ' PlanTransID
    Private Const COL_IsUsed As Integer = 1          ' Chọn
    Private Const COL_BlockID As Integer = 2         ' BlockID
    Private Const COL_BlockName As Integer = 3       ' Khối
    Private Const COL_DepartmentID As Integer = 4    ' DepartmentID
    Private Const COL_DepartmentName As Integer = 5  ' Phòng ban
    Private Const COL_TeamID As Integer = 6          ' TeamID
    Private Const COL_TeamName As Integer = 7        ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 8   ' RecPositionID
    Private Const COL_RecPositionName As Integer = 9 ' Vị trí
    Private Const COL_ProNumber As Integer = 10      ' Số lượng
    Private Const COL_DateFrom As Integer = 11       ' Từ ngày
    Private Const COL_DateTo As Integer = 12         ' Đến ngày
    Private Const COL_VoucherDate As Integer = 13    ' Ngày lập
    Private Const COL_ProNote As Integer = 14        ' Ghi chú
#End Region

    Private _savedOK As Boolean = False
    Public ReadOnly Property SavedOK() As Boolean
        Get
            Return _savedOK
        End Get
    End Property

    Private _sQLInsertD09T6666 As New StringBuilder
    Public ReadOnly Property SQLInsertD09T6666() As StringBuilder
        Get
            Return _sQLInsertD09T6666
        End Get
    End Property

    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    '*****************************************

    Dim iColumns() As Integer = {COL_ProNumber}
    Dim dtTeamID, dtDepartmentID As New DataTable
    Dim dtGrid As DataTable = Nothing
    Dim bIsFilter As Boolean = False

    Private Sub D25F3180_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
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

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở, đóng UserControl
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowColumns_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            usrOption.Hide()
        End If
        '***************************************

    End Sub

    Private Sub D25F3180_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        ResetFooterGrid(tdbg, SPLIT0, SPLIT1)
        ResetSplitDividerSize(tdbg)
        tdbg_LockedColumns()

        LoadTDBCombo()
        LoadDefault()
        VisibleBlock()
        ResetGrid()
        InputDateCustomFormat(c1dateVoucherDateTo, c1dateVoucherDateFrom)
        InputDateInTrueDBGrid(tdbg, COL_DateFrom, COL_DateTo, COL_VoucherDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default

        InitiateD09U1111()
    End Sub
    'Dim dtCaptionCols As DataTable
    Private Sub InitiateD09U1111()
        '*****************************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'Đặt các dòng code sau vào cuối FormLoad
        Dim arrColObligatory() As Integer = {COL_IsUsed}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory, , , gbUnicode)

        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, , , , , gbUnicode)
        '*****************************************
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_ke_hoach_tong_theF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Chãn kÕ hoÁch tuyÓn dóng - D25F3180
        '================================================================ 
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rl3("Vi_tri") 'Vị trí
        lblteVoucherDateFrom.Text = rl3("Ngay_lap") 'Ngày lập
        '================================================================ 
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnChoose.Text = rl3("_Chon") '&Chọn
        '================================================================ 
        chkShowSelectedDataOnly.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon")  'Chỉ hiển thị những dữ liệu đã chọn
        '================================================================ 
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("BlockName").Caption = rl3("Khoi") 'Mã khối
        tdbg.Columns("DepartmentName").Caption = rl3("Phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamName").Caption = rl3("To_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionName").Caption = rl3("Vi_tri") 'Tên vị trí
        tdbg.Columns("ProNumber").Caption = rl3("So_luong") 'Số lượng
        tdbg.Columns("DateFrom").Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_lap") 'Ngày lập
        tdbg.Columns("ProNote").Caption = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
    End Sub

    Private Sub tdbg_LockedColumns()
        For i As Integer = COL_BlockID To COL_ProNote
            tdbg.Splits(SPLIT1).DisplayColumns(i).Locked = True
            tdbg.Splits(SPLIT1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        Next
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcBlockID
        LoadtdbcBlockID(tdbcBlockID, gbUnicode)

        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(True, , gbUnicode)
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.Text, gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.Text, tdbcDepartmentID.Text, gbUnicode)
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        'Load tdbcRecPositionID
        'sSQL = "Select '%' as RecPositionID, " & sLanguage & " As RecPositionName" & vbCrLf
        'sSQL &= "Union" & vbCrLf
        'sSQL &= "SELECT	RecPositionID, RecPositionName" & sUnicode & " as RecPositionName FROM D25T1020 WHERE(Disabled = 0) ORDER BY	RecPositionID"
        sSQL = "SELECT		0 as DisplayOrder,'%' AS RecPositionID, " & sLanguage & " AS RecPositionName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT		1 as DisplayOrder,DutyID As RecPositionID, DutyName" & sUnicode & " AS RecPositionName" & vbCrLf
        sSQL &= "FROM		D09T0211 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "WHERE		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, RecPositionID" & vbCrLf
        LoadDataSource(tdbcRecPositionID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadDefault()
        tdbcBlockID.SelectedIndex = 0
        tdbcRecPositionID.SelectedIndex = 0
        c1dateVoucherDateFrom.Value = Now
        c1dateVoucherDateTo.Value = Now
    End Sub

    Private Sub VisibleBlock()
        'Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        'If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
        If D25Systems.IsUseBlock = False Then
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockName).Visible = False
        End If
    End Sub


    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal FlagEdit As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim dtSelected As DataTable = Nothing
        If dtGrid IsNot Nothing Then
            dtSelected = ReturnTableFilter(dtGrid, "IsUsed = True", True)
        End If

        dtGrid = ReturnDataTable(SQLStoreD25P3180())

        If dtSelected IsNot Nothing Then
            Dim keyCol() As DataColumn = {dtSelected.Columns("PlanTransID")}
            dtSelected.PrimaryKey = keyCol
            Dim keyCol1() As DataColumn = {dtGrid.Columns("PlanTransID")}
            dtGrid.PrimaryKey = keyCol1

            dtGrid.Merge(dtSelected, False, MissingSchemaAction.AddWithKey)
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        mnuFind.Enabled = (Not chkShowSelectedDataOnly.Checked) And (gbEnabledUseFind Or tdbg.RowCount > 0) 'Mờ khi  chkIsUsed.Checked = True
        mnuListAll.Enabled = mnuFind.Enabled 'Mờ khi  chkIsUsed.Checked = True
        FooterTotalGrid(tdbg, COL_DepartmentName)
        FooterSumNew(tdbg, iColumns)
    End Sub

    Private Sub chkShowSelectedDataOnly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowSelectedDataOnly.Click
        If Not bIsFilter Then Exit Sub
        If dtGrid Is Nothing Then Exit Sub
        Dim sFilter As String = ""

        If chkShowSelectedDataOnly.Checked Then
            sFilter = "IsUsed = True"
        Else
            sFilter = IIf(sFind = "", "", sFind & " Or IsUsed = True").ToString
        End If

        dtGrid.DefaultView.RowFilter = sFilter
        ResetGrid()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowChoose() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim bFlag As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                bFlag = True
                Exit For
            End If
        Next

        If bFlag = False Then
            D99C0008.MsgNotYetChoose(rl3("De_xuat_tuyen_dung"))
            tdbg.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        If Not AllowChoose() Then Exit Sub
        Dim dtTemp As DataTable = ReturnTableFilter(dtGrid, "IsUsed = True", True)
        _sQLInsertD09T6666 = New StringBuilder
        '_dataTableGrid = ReturnTableFilter(dtGrid, "IsUsed = True", True)
        For i As Integer = 0 To dtTemp.Rows.Count - 1
            _sQLInsertD09T6666.Append("INSERT INTO D09T6666(UserID, HostID, FormID, Key01ID) VALUES(" & SQLString(gsUserID) & ", " & SQLString(My.Computer.Name) & ", " & SQLString(Me.Name) & ", " & SQLString(dtTemp.Rows(i).Item("PlanTransID")) & ")".ToString & vbCrLf)
        Next
        Me.Close()
    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub

        btnFilter.Enabled = False
        sFind = ""
        chkShowSelectedDataOnly.Checked = False
        bIsFilter = True
        LoadTDBGrid()
        btnFilter.Enabled = True
    End Sub

    Private Function AllowFilter() As Boolean

        If c1dateVoucherDateFrom.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_tu"))
            c1dateVoucherDateFrom.Focus()
            Return False
        End If
        If c1dateVoucherDateTo.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_den"))
            c1dateVoucherDateTo.Focus()
            Return False
        End If

        Return True
    End Function


#Region "Active Find Client - List All "

    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    Private sFind As String = ""

    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid()
        End Set
    End Property

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, dtCaptionCols)
        ShowFindDialogClient(Finder, dtCaptionCols, Me, SQLNumber(0), gbUnicode)
        '*****************************************
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        sFind = ""
        chkShowSelectedDataOnly.Checked = False
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        dtGrid.AcceptChanges()
        Dim sFilter As String = "" 'TH sFind="" và chkIsUsed.Checked =False
        If sFind = "" Then
            If chkShowSelectedDataOnly.Checked Then sFilter = "IsUsed=True"
        Else
            sFilter = "IsUsed=True" & " Or " & sFind
        End If
        dtGrid.DefaultView.RowFilter = sFilter

        ResetGrid()
    End Sub

#End Region

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
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gbUnicode)

        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
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

            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, gbUnicode)
        End If
        tdbcDepartmentID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcRecPositionID"

    Private Sub tdbcRecPositionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionID.LostFocus
        If tdbcRecPositionID.FindStringExact(tdbcRecPositionID.Text) = -1 Then tdbcRecPositionID.Text = ""
    End Sub

#End Region

    Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcBlockID.KeyDown, tdbcDepartmentID.KeyDown, tdbcTeamID.KeyDown, tdbcRecPositionID.KeyDown
        If gbUnicode Then Exit Sub
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        Select Case e.KeyCode
            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                tdbc.AutoCompletion = False

            Case Else
                tdbc.AutoCompletion = True
        End Select
    End Sub

    Private Sub tdbcName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Leave, tdbcTeamID.Leave, tdbcDepartmentID.Leave, tdbcRecPositionID.Leave
        '  If gbUnicode Then Exit Sub 
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)

        If tdbcName.SelectedIndex <> -1 Then
            tdbcName.Text = tdbcName.Columns(tdbcName.DisplayMember).Text
        End If
    End Sub

#End Region

#Region "Grid Events"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        Select Case e.ColIndex
            Case COL_IsUsed
                If chkShowSelectedDataOnly.Checked Then tdbg.UpdateData()
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case e.ColIndex()
            Case COL_IsUsed
                Dim bFlag As Boolean = Not L3Bool(tdbg(0, COL_IsUsed).ToString)
                For i As Integer = tdbg.RowCount - 1 To 0 Step -1
                    tdbg(i, COL_IsUsed) = bFlag
                Next
                If chkShowSelectedDataOnly.Checked Then tdbg.UpdateData()
        End Select
    End Sub
#End Region

#Region "SQL, Store"
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3180
    '# Created User: 
    '# Created Date: 28/07/2010 11:30:31
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3180() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P3180 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateFrom.Text) & COMMA 'VoucherDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateTo.Text) & COMMA 'VoucherDateTo, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecpositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(gsCompanyID) 'CompanyID, varchar[50], NOT NULL
        Return sSQL
    End Function
#End Region


End Class