Imports System
Public Class D25F2020

#Region "Const of tdbg"
    Private Const COL_IsUsed As Integer = 0          ' Chọn
    Private Const COL_DivisionName As Integer = 1    ' Đơn vị
    Private Const COL_BlockID As Integer = 2         ' BlockID
    Private Const COL_BlockName As Integer = 3       ' Khối
    Private Const COL_DepartmentID As Integer = 4    ' DepartmentID
    Private Const COL_DepartmentName As Integer = 5  ' Phòng ban
    Private Const COL_TeamID As Integer = 6          ' TeamID
    Private Const COL_TeamName As Integer = 7        ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 8   ' RecPositionID
    Private Const COL_RecPositionName As Integer = 9 ' Vị trí
    Private Const COL_Number As Integer = 10         ' Số lượng duyệt
    Private Const COL_DateFrom As Integer = 11       ' Từ ngày
    Private Const COL_DateTo As Integer = 12         ' Đến ngày
    Private Const COL_VoucherDate As Integer = 13    ' Ngày duyệt
    Private Const COL_ApproverID As Integer = 14     ' ApproverID
    Private Const COL_ApproverName As Integer = 15   ' Người duyệt
    Private Const COL_NoteDetail As Integer = 16     ' Ghi chú
    Private Const COL_TransID As Integer = 17        ' TransID
#End Region

#Region "Const of tdbgLeft"
    Private Const COLL_IsUsedGroup As Integer = 0    ' Chọn
    Private Const COLL_DivisionID As Integer = 1     ' DivisionID
    Private Const COLL_DivisionName As Integer = 2   ' Đơn vị
    Private Const COLL_DepartmentID As Integer = 3   ' DepartmentID
    Private Const COLL_DepartmentName As Integer = 4 ' Phòng ban
    Private Const COLL_AppDate As Integer = 5        ' Ngày duyệt
    Private Const COLL_TotalAppNumber As Integer = 6 ' Số lượng tổng
#End Region

    Private _recruitmentFileID As String = ""
    Public Property RecruitmentFileID() As String
        Get
            Return _recruitmentFileID
        End Get
        Set(ByVal Value As String)
            _recruitmentFileID = value
        End Set
    End Property

    Private _formID As String = ""
    Public Property FormID() As String
        Get
            Return _formID
        End Get
        Set(ByVal Value As String)
            _formID = Value
        End Set
    End Property

    Private _voucherID As String = ""
    Public Property VoucherID() As String
        Get
            Return _voucherID
        End Get
        Set(ByVal Value As String)
            _voucherID = Value
        End Set
    End Property

    Private _key01ID As String = ""
    Public Property Key01ID() As String
        Get
            Return _key01ID
        End Get
        Set(ByVal Value As String)
            _key01ID = Value
        End Set
    End Property

    Private _key02ID As String = ""
    Public Property Key02ID() As String
        Get
            Return _key02ID
        End Get
        Set(ByVal Value As String)
            _key02ID = Value
        End Set
    End Property

    Private _key03ID As String = ""
    Public Property Key03ID() As String
        Get
            Return _key03ID
        End Get
        Set(ByVal Value As String)
            _key03ID = Value
        End Set
    End Property

    Private _key04ID As String = ""
    Public Property Key04ID() As String
        Get
            Return _key04ID
        End Get
        Set(ByVal Value As String)
            _key04ID = Value
        End Set
    End Property

    Private _key05ID As String = ""
    Public Property Key05ID() As String
        Get
            Return _key05ID
        End Get
        Set(ByVal Value As String)
            _key05ID = Value
        End Set
    End Property

    Private _chose As Boolean = False
    Public ReadOnly Property Chose() As Boolean
        Get
            Return _chose
        End Get
    End Property

    Private _recDateFrom As String = ""
    Public WriteOnly Property RecDateFrom() As String 
        Set(ByVal Value As String )
            _recDateFrom = Value
        End Set
    End Property

    Private _recDateTo As String = ""
    Public WriteOnly Property RecDateTo() As String 
        Set(ByVal Value As String )
            _recDateTo = Value
        End Set
    End Property

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Dim dtGrid As DataTable = Nothing
    Dim dtTeamID As DataTable = Nothing
    Dim dtDepartmentID As DataTable = Nothing, dtBlockID As DataTable

    Dim bIsFilter As Boolean = False

    Private Sub D25F2020_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D25F2020_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F12 Then ' Mở
            btnF12_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then 'Đóng
            usrOption.picClose_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub D25F2020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            InputbyUnicode(Me, gbUnicode)
            LoadInfoGeneral()
            Loadlanguage()
            ResetColorGrid(tdbg, tdbgLeft)
            ResetSplitDividerSize(tdbg, tdbgLeft)

            LoadTDBCombo()
            LoadDefault()
            VisibleBlock()
            InputDateInTrueDBGrid(tdbg, COL_DateTo, COL_DateFrom, COL_VoucherDate)
            InputDateInTrueDBGrid(tdbgLeft, COLL_AppDate)
            InputDateCustomFormat(c1dateTo, c1dateFrom)
            SetBackColorObligatory()

            CallD99U1111()
            SetResolutionForm(Me)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_de_xuat_tuyen_dung_-_D25F2020") & UnicodeCaption(gbUnicode) 'Chãn ¢Ò xuÊt tuyÓn dóng - D25F2020
        '================================================================ 
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rl3("Khoi") 'Khối
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblRecPositionID.Text = rL3("Vi_tri") 'Vị trí
        lblDivisionID.Text = rL3("Don_vi") 'Đơn vị
        '================================================================ 
        btnFilter.Text = rL3("Loc") & " (F5)" '&Lọc
        btnF12.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiá»ƒn thá»‹
        btnChoose.Text = rl3("_Chon") '&Chọn
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkShowSelectedDataOnly.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon") 'Chỉ hiển thị những dữ liệu đã chọn
        '================================================================ 
        optDate.Text = rl3("Ngay_lap") 'Ngày lập
        optRecDate.Text = rL3("Ngay_tuyenU") 'Ngày tuyển
        '================================================================ 
        tdbcRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rL3("Chon") 'Chọn
        tdbg.Columns(COL_DivisionName).Caption = rL3("Don_vi") 'Đơn vị
        tdbg.Columns("BlockName").Caption = rl3("Khoi") 'Tên khối
        tdbg.Columns("DepartmentName").Caption = rl3("Phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamName").Caption = rl3("To_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionName").Caption = rl3("Vi_tri") 'Tên vị trí
        tdbg.Columns("Number").Caption = rl3("So_luong_duyet") 'Số lượng duyệt
        tdbg.Columns("DateFrom").Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_duyet") 'Ngày duyệt
        tdbg.Columns("ApproverName").Caption = rl3("Nguoi_duyet") 'Người duyệt
        tdbg.Columns("NoteDetail").Caption = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        tdbgLeft.Columns(COLL_IsUsedGroup).Caption = rL3("Chon") 'Chọn
        tdbgLeft.Columns(COLL_DivisionName).Caption = rL3("Don_vi") 'Đơn vị
        tdbgLeft.Columns(COLL_AppDate).Caption = rl3("Ngay_duyet")
        tdbgLeft.Columns(COLL_TotalAppNumber).Caption = rl3("So_luong_tong")
        tdbgLeft.Columns(COLL_DepartmentName).Caption = rl3("Phong_ban") 'Phòng ban
    End Sub

    Private Sub LoadTDBCombo()
        Dim sUnicode As String = ""
        Dim sAll As String = ""
        UnicodeAllString(sUnicode, sAll, gbUnicode)

        Dim sSQL As String = ""
        'Load tdbcBlockID
        dtBlockID = ReturnTableBlockID(, , gbUnicode)
        'Load tdbcDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(, , gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(, , gbUnicode)

        'Load tdbcRecPositionID
        LoadDataSource(tdbcRecPositionID, ReturnTableDutyIDRec(, gbUnicode), gbUnicode)

        LoadCboDivisionIDD09(tdbcDivisionID, "D09", True, gbUnicode)
        tdbcDivisionID.SelectedValue = gsDivisionID
    End Sub

    Private Sub LoadDefault()
        If _recDateFrom <> "" Then
            Try
                c1dateRecDateFrom.Value = CDate(_recDateFrom)
                c1dateRecDateTo.Value = CDate(_recDateTo)
            Catch ex As Exception
                c1dateRecDateFrom.Value = Now
                c1dateRecDateTo.Value = Now
            End Try
        Else
            c1dateRecDateFrom.Value = Now
            c1dateRecDateTo.Value = Now
        End If
        tdbcBlockID.SelectedIndex = 0
        tdbcRecPositionID.SelectedIndex = 0
        c1dateFrom.Value = Now
        c1dateTo.Value = Now
    End Sub

    Private Sub VisibleBlock()
        If D25Systems.IsUseBlock = False Then
            ReadOnlyControl(tdbcBlockID)
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockName).Visible = False
        End If
    End Sub

    Private Sub LoadTDBGrid(ByVal bChecked As Boolean, Optional ByVal bHeadClick As Boolean = False)
        ResetFilter(tdbg, sFilter, bRefreshFilter)

        If bChecked Then 'Thêm dòng
            If bHeadClick Then
                If dtGrid IsNot Nothing Then dtGrid.Clear()
                For i As Integer = 0 To tdbgLeft.RowCount - 1
                    Dim dtTemp As DataTable = ReturnDataTable(SQLStoreD25P2023(tdbgLeft(i, COLL_DepartmentID), tdbgLeft(i, COLL_AppDate)))
                    If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then
                        dtGrid = dtTemp
                    Else
                        dtGrid.Merge(dtTemp)
                    End If
                Next
            Else
                Dim dtTemp As DataTable = ReturnDataTable(SQLStoreD25P2023(tdbgLeft.Columns(COLL_DepartmentID).Value, tdbgLeft.Columns(COLL_AppDate).Value))
                If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then
                    dtGrid = dtTemp
                Else
                    dtGrid.Merge(dtTemp)
                End If
            End If
        Else 'Xóa đi
            If bHeadClick Then
                If dtGrid IsNot Nothing Then dtGrid.Clear()
            Else
                If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then Exit Sub
                Dim dr() As DataRow = dtGrid.Select("DepartmentID =" & SQLString(tdbgLeft.Columns(COLL_DepartmentID).Value)) ' & " And AppDate='" & SQLDateShow(tdbgLeft.Columns(COLL_AppDate).Value) & "'")
                For i As Integer = dr.Length - 1 To 0 Step -1
                    dtGrid.Rows.Remove(dr(i))
                Next
            End If
        End If
        dtGrid.AcceptChanges()
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = ""
        If chkShowSelectedDataOnly.Checked Then
            strFind = "IsUsed = 1 "
        Else
            strFind = sFilter.ToString
            If strFind.Equals("") = False Then strFind &= " OR IsUsed = 1"
        End If

        dtGrid.DefaultView.RowFilter = strFind
        FooterTotalGrid(tdbg, COL_DivisionName)
    End Sub

    Dim dtGridLeft As DataTable
    Private Sub LoadTDBGridLeft()
        dtGridLeft = ReturnDataTable(SQLStoreD25P2023(ReturnValueC1Combo(tdbcDepartmentID), "", 1))
        LoadDataSource(tdbgLeft, dtGridLeft, gbUnicode)

        ReLoadTDBGridLeft()
    End Sub

    Private Sub ReLoadTDBGridLeft()
        Dim strFind As String = sFilterLeft.ToString
        If strFind.Equals("") = False Then strFind &= " OR IsUsedGroup = 1"

        dtGridLeft.DefaultView.RowFilter = strFind
        FooterTotalGrid(tdbgLeft, COLL_DivisionName)
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
            D99C0008.MsgNotYetChoose(rL3("De_xuat_tuyen_dung"))
            tdbg.SplitIndex = 0
            tdbg.Col = COL_IsUsed
            tdbg.Row = 0
            tdbg.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        If Not AllowChoose() Then Exit Sub
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Delete truoc khi insert" & vbCrLf)
        sSQL.Append("DELETE D09T6666 Where UserID = " & SQLString(gsUserID) & " AND HostID = " & SQLString(My.Computer.Name) & " AND FormID = 'D25F2020'" & vbCrLf)
        sSQL.Append("-- Insert bảng tạm các dòng đã chọn." & vbCrLf)
        Dim dr() As DataRow = dtGrid.Select("IsUsed = True")
        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("INSERT INTO D09T6666(UserID, HostID, FormID, Key01ID) VALUES(" & _
                        SQLString(gsUserID) & COMMA & SQLString(My.Computer.Name) & COMMA & SQLString(Me.Name) & COMMA & SQLString(dr(i).Item("TransID")))
            sSQL.Append(")")
        Next
        ExecuteSQL(sSQL.ToString)
        _chose = True
        '        _dataTableGrid = ReturnTableFilter(dtGrid, "IsUsed = True", True)
        Me.Close()
    End Sub

    '    Private Sub btnShowColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
    '        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
    '        giRefreshUserControl = -1
    '        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
    '        Me.Controls.Add(usrOption)
    '        usrOption.BringToFront()
    '        usrOption.Visible = True
    '    End Sub

    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL_IsUsed}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        '************************************
        If Not AllowFilter() Then Exit Sub

        btnFilter.Enabled = False
        chkShowSelectedDataOnly.Checked = False
        bIsFilter = True
        LoadTDBGridLeft()
        If dtGrid IsNot Nothing AndAlso dtGrid.Rows.Count > 0 Then dtGrid.Clear()
        LoadTDBGrid(False)
        btnFilter.Enabled = True
    End Sub

    Private Function AllowFilter() As Boolean
        If optRecDate.Checked Then
            If Not CheckValidDateFromTo(c1dateRecDateFrom, c1dateRecDateTo) Then Return False
        End If
        If optDate.Checked Then
            If Not CheckValidDateFromTo(c1dateFrom, c1dateTo) Then Return False
        End If

        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblDivisionID.Text)
            tdbcDivisionID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub optDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDate.Click
        If optRecDate.Checked Then
            ReadOnlyControl(c1dateFrom, c1dateTo)
            UnReadOnlyControl(True, c1dateRecDateFrom, c1dateRecDateTo)
        Else
            ReadOnlyControl(c1dateRecDateFrom, c1dateRecDateTo)
            UnReadOnlyControl(True, c1dateFrom, c1dateTo)
        End If
    End Sub

    Private Sub optRecDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optRecDate.Click
        If optRecDate.Checked Then
            ReadOnlyControl(c1dateFrom, c1dateTo)
            UnReadOnlyControl(True, c1dateRecDateFrom, c1dateRecDateTo)
        Else
            ReadOnlyControl(c1dateRecDateFrom, c1dateRecDateTo)
            UnReadOnlyControl(True, c1dateFrom, c1dateTo)
        End If
    End Sub



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
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)

        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcBlockID"

    Private Sub tdbcName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Leave, tdbcTeamID.Leave, tdbcDepartmentID.Leave, tdbcRecPositionID.Leave
        '  If gbUnicode Then Exit Sub 
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)

        If tdbcName.SelectedIndex <> -1 Then
            tdbcName.Text = tdbcName.Columns(tdbcName.DisplayMember).Text
        End If
    End Sub


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
            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, "-1", ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
        Else

            LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, tdbcBlockID.SelectedValue.ToString, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
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

#Region "Events tdbcDivisionID"

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then tdbcDivisionID.Text = ""
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        Dim sDivisionID As String = ReturnValueC1Combo(tdbcDivisionID)
        Dim PeriodFrom As Object = "", PeriodTo As Object = ""
        LoadtdbcBlockID(tdbcBlockID, dtBlockID, sDivisionID, gbUnicode)
        tdbcBlockID.SelectedIndex = 0
    End Sub
#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcRecPositionID.Close, tdbcDivisionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcRecPositionID.Validated, tdbcDivisionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

#Region "SQL, Store"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2023
    '# Created User: DUCTRONG
    '# Created Date: 16/06/2010 02:14:19
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2023(ByVal DepartmentID As Object, ByVal AppDate As Object, Optional ByVal mode As Integer = 0) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2023 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Value) & COMMA 'VoucherDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Value) & COMMA 'VoucherDateTo, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(DepartmentID) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecPositionID)) & COMMA 'RecpositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(optRecDate.Checked) & COMMA 'IsUsedPeriod, tinyint, NOT NULL
        sSQL &= SQLString(_formID) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_voucherID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(_key01ID) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString(_key02ID) & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString(_key03ID) & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString(_key04ID) & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString(_key05ID) & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA
        sSQL &= SQLDateSave(AppDate) & COMMA
        sSQL &= SQLNumber(mode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLDateSave(c1dateRecDateFrom.Value) & COMMA 'RecDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateRecDateTo.Value) 'RecDateTo, datetime, NOT NULL
        Return sSQL
    End Function


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
        Select Case e.ColIndex
            Case COL_IsUsed
                tdbg.AllowSort = False
                Dim bFlag As Boolean = Not L3Bool(tdbg(0, COL_IsUsed).ToString)
                For i As Integer = tdbg.RowCount - 1 To 0 Step -1
                    tdbg(i, COL_IsUsed) = bFlag
                Next
                If chkShowSelectedDataOnly.Checked Then tdbg.UpdateData()
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Dim sFilter As New StringBuilder
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            'MessageBox.Show(ex.Message & " - " & ex.Source)
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.FilterActive Then
            tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveRight
        Else
            tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If L3Bool(tdbg(e.Row, COL_IsUsed)) Then
            e.CellStyle.ForeColor = Color.Blue
        End If
    End Sub

#End Region

#Region "GridLeft Events"

    Private Sub chkShowSelectedDataOnly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowSelectedDataOnly.Click
        If Not bIsFilter OrElse dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Dim sFilterLeft As New System.Text.StringBuilder()
    Private Sub tdbgLeft_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgLeft.FilterChange
        Try
            If (dtGridLeft Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbgLeft, sFilterLeft) 'Nếu có Lọc khi In
            ReLoadTDBGridLeft()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbgLeft_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgLeft.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbgLeft, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbgLeft_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgLeft.KeyPress
        If tdbgLeft.Columns(tdbgLeft.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbgLeft.Splits(tdbgLeft.SplitIndex).DisplayColumns(tdbgLeft.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    Private Sub tdbgLeft_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgLeft.HeadClick
        If tdbgLeft.RowCount < 0 Then Exit Sub
        Select Case e.ColIndex
            Case COLL_IsUsedGroup
                tdbgLeft.AllowSort = False
                Dim bFlag As Boolean = Not L3Bool(tdbgLeft(0, COLL_IsUsedGroup).ToString)
                For i As Integer = tdbgLeft.RowCount - 1 To 0 Step -1
                    tdbgLeft(i, COLL_IsUsedGroup) = bFlag
                Next
                Me.Cursor = Cursors.WaitCursor
                LoadTDBGrid(L3Bool(tdbgLeft(0, e.ColIndex)), True)
                Me.Cursor = Cursors.Default
            Case Else
                tdbgLeft.AllowSort = True
        End Select
    End Sub

    Private Sub tdbgLeft_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgLeft.AfterColUpdate
        Select Case e.ColIndex
            Case COLL_IsUsedGroup
                LoadTDBGrid(L3Bool(tdbgLeft.Columns(e.ColIndex).Text))
        End Select
    End Sub

    Private Sub tdbgLeft_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbgLeft.FetchRowStyle
        If L3Bool(tdbgLeft(e.Row, COLL_IsUsedGroup)) Then
            e.CellStyle.ForeColor = Color.Blue
        End If
    End Sub

#End Region


End Class