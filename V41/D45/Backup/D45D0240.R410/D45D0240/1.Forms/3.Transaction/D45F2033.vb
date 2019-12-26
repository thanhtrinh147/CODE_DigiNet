Imports System
Public Class D45F2033
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Dim dtCaptionCols As DataTable
    Dim dtDepartmentID, dtTeamID, dtGrid As DataTable
    Public dtCaption As DataTable
    Dim iColumns() As Integer = {COL_BlockName, COL_DepartmentID, COL_DepartmentName, COL_TeamID, COL_TeamName}
    Dim iColumns1() As Integer = {COL_DepartmentName, COL_TeamID, COL_TeamName}
    Dim iColumns2() As Integer = {COL_TeamName}
    Dim iColFirst As Integer = -1
    Dim iLastCol As Integer = -1

#Region "Const of tdbg"
    Private Const COL_BlockID As Integer = 0        ' Mã khối
    Private Const COL_BlockName As Integer = 1      ' Tên khối
    Private Const COL_DepartmentID As Integer = 2   ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 3 ' Tên phòng ban
    Private Const COL_TeamID As Integer = 4         ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 5       ' Tên tổ nhóm
    Private Const COL_HAUnitPrice As Integer = 6    ' Đơn giá giờ công hệ số
    Private Const COL_HAUnitPrice02 As Integer = 7  ' HAUnitPrice02
    Private Const COL_HAUnitPrice03 As Integer = 8  ' HAUnitPrice03
    Private Const COL_HAUnitPrice04 As Integer = 9  ' HAUnitPrice04
    Private Const COL_HAUnitPrice05 As Integer = 10 ' HAUnitPrice05
#End Region

#Region "UserControl"
    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
#End Region

    Private _attCoefUPID As String
    Public WriteOnly Property AttCoefUPID() As String
        Set(ByVal Value As String)
            _attCoefUPID = Value
        End Set
    End Property

    Private _transID As String
    Public WriteOnly Property TransID() As String
        Set(ByVal Value As String)
            _transID = Value
        End Set
    End Property

    Private _blockID As String
    Public WriteOnly Property BlockID() As String
        Set(ByVal Value As String)
            _blockID = Value
        End Set
    End Property

    Private _blockName As String
    Public WriteOnly Property BlockName() As String
        Set(ByVal Value As String)
            _blockName = Value
        End Set
    End Property

    Private _departmentID As String
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _departmentName As String
    Public WriteOnly Property DepartmentName() As String
        Set(ByVal Value As String)
            _departmentName = Value
        End Set
    End Property

    Private _teamID As String
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _teamName As String
    Public WriteOnly Property TeamName() As String
        Set(ByVal Value As String)
            _teamName = Value
        End Set
    End Property

    Private _drFirst As DataRow
    Public WriteOnly Property drFirst() As DataRow
        Set(ByVal Value As DataRow)
            _drFirst = Value
        End Set
    End Property

    Private Sub D45F2033_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnF12_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk(rl3("Thong_tin_tren_luoi_da_thay_doi_ban_co_muon_Refresh_lai_khong")) = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
        '***************************************
    End Sub

    Private Sub D45F2033_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        _bSaved = False
        Loadlanguage()
        SetBackColorObligatory()
        LoadDefault() 'Phải để trước tdbg_LockedColumns để có gtrị để khóa cột
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadTDBDropDown()
        ResetFooterGrid(tdbg)
        LoadCaption()
        LoadTDBGrid()
        '********************
        'Su dung Enter di chuyen den o duoi o hien hanh
        If D45Options.UseEnterMoveDown Then tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
        '********************
        InputbyUnicode(Me, gbUnicode)
        '******************************
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        CallD09U1111_Button(True)
        '******************************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Style.Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        '******************************
        tdbg.Columns(COL_BlockID).DefaultValue = _blockID
        tdbg.Columns(COL_BlockName).DefaultValue = _blockName
        If _departmentID <> "" AndAlso _teamID = "" Then
            tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Columns(COL_DepartmentID).DefaultValue = _departmentID
            tdbg.Columns(COL_DepartmentName).DefaultValue = _departmentName
        End If
        '***************************************
        For i As Integer = 0 To COL_HAUnitPrice
            If tdbg.Splits(0).DisplayColumns(i).Style.Locked Then
                tdbg.Splits(0).DisplayColumns(i).AllowFocus = False
            End If
            'Tim cot dau tien k bi lock
            If iColFirst = -1 AndAlso tdbg.Columns(i).DataField.Contains("ID") AndAlso tdbg.Splits(0).DisplayColumns(i).Style.Locked = False Then
                iColFirst = i
            End If
        Next
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_HAUnitPrice).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_HAUnitPrice02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_HAUnitPrice03).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_HAUnitPrice04).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_HAUnitPrice05).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub LoadDefault()
        txtBlockName.Text = _blockName
        txtDepartmentName.Text = _departmentName
        txtTeamName.Text = _teamName
        ReadOnlyControl(txtBlockName, txtDepartmentName, txtTeamName)
        '******************************
        tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = D45Systems.IsUseBlock
        tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = D45Systems.IsUseBlock
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Tach_don_gia_gio_cong_he_so_-_D45F2033") & UnicodeCaption(gbUnicode) 'TÀch ¢¥n giÀ gié c¤ng hÖ sç - D45F2033
        '================================================================ 
        lblBlockName.Text = rl3("Khoi") 'Khối
        lblDepartmentName.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamName.Text = rl3("To_nhom") 'Tổ nhóm
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnF12.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        tdbdTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbdDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbdBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbdBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("BlockID").Caption = rl3("Ma_khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("HAUnitPrice").Caption = rl3("Don_gia_gio_cong_he_so") 'Đơn giá giờ công hệ số
    End Sub

    Private Sub SetBackColorObligatory()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_HAUnitPrice).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_HAUnitPrice02).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_HAUnitPrice03).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_HAUnitPrice04).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_HAUnitPrice05).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbdBlockID
        sSQL = "SELECT BlockID, BlockName" & UnicodeJoin(gbUnicode) & " As BlockName" & vbCrLf
        sSQL &= "FROM 	D09T1140  WITH(NOLOCK) WHERE	Disabled = 0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "ORDER BY BlockName"
        LoadDataSource(tdbdBlockID, sSQL, gbUnicode)

        'Load tdbdDepartmentID
        sSQL = "SELECT DepartmentID, DepartmentName" & UnicodeJoin(gbUnicode) & " As DepartmentName, BlockID" & vbCrLf
        sSQL &= "FROM D91T0012  WITH(NOLOCK) WHERE Disabled = 0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "ORDER BY DepartmentName"
        dtDepartmentID = ReturnDataTable(sSQL)
        LoadTDBDDepartmentID("-1")

        'Load tdbdTeamID
        sSQL = "SELECT D01.TeamID, D01.TeamName" & UnicodeJoin(gbUnicode) & " as TeamName, D02.BlockID, D01.DepartmentID" & vbCrLf
        sSQL &= "FROM D09T0227 D01  WITH(NOLOCK) INNER JOIN D91T0012 D02  WITH(NOLOCK) On D02.DepartmentID = D01.DepartmentID" & vbCrLf
        sSQL &= "WHERE	D01.Disabled = 0 And D02.DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "ORDER BY TeamName"
        dtTeamID = ReturnDataTable(sSQL)
        LoadTDBDTeamID("-1", "-1")
    End Sub

    Private Sub LoadTDBDDepartmentID(ByVal sBlockID As String)
        If tdbg.Splits(0).DisplayColumns(COL_BlockID).Style.Locked Then sBlockID = _blockID

        LoadDataSource(tdbdDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID=" & SQLString(sBlockID), True), gbUnicode)
    End Sub

    Private Sub LoadTDBDTeamID(ByVal sBlockID As String, ByVal sDepartmentID As String)
        If tdbg.Splits(0).DisplayColumns(COL_BlockID).Style.Locked Then sBlockID = _blockID
        If tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Style.Locked Then sDepartmentID = _departmentID

        LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID, "BlockID=" & SQLString(sBlockID) & " And DepartmentID=" & SQLString(sDepartmentID), True), gbUnicode)
    End Sub

    Private Sub LoadCaption()
        If dtCaption.Rows.Count > 0 Then
            For i As Integer = 0 To dtCaption.Rows.Count - 1
                Dim sField As String = dtCaption.Rows(i).Item("Field").ToString
                tdbg.Columns(sField).Caption = dtCaption.Rows(i).Item("Caption").ToString
                tdbg.Splits(0).DisplayColumns(sField).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Splits(0).DisplayColumns(sField).Visible = Not L3Bool(dtCaption.Rows(i).Item("Disable"))
            Next
        End If
    End Sub

    Private Sub LoadTDBGrid()
        dtGrid = _drFirst.Table.Clone
        dtGrid.ImportRow(_drFirst) 'Dòng gốc
        '*****************************
        Dim sSQL As String = SQLStoreD45P2032()
        Dim dtTemp As DataTable = ReturnDataTable(sSQL)
        '*****************************
        dtGrid.Merge(dtTemp)
        '*****************************
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        '*****************
        iLastCol = CountCol(tdbg, tdbg.Splits.Count - 1)
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, tdbg.Top + tdbg.Height - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        'Những cột bắt buộc nhập
        If bLoadFirst = True Then
            Dim arrColObligatory() As Integer = {}
            For i As Integer = 0 To tdbg.Splits.Count - 1
                AddColVisible(tdbg, i, arrMaster, arrColObligatory, , , gbUnicode)
            Next
        End If

        'Dim dtCaptionCols As DataTable

        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

#Region "tdbg"
    Private Sub tdbg_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeDelete
        If tdbg.Row = 0 Then e.Cancel = True
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_BlockID
                If tdbg.Columns(COL_BlockID).Text <> tdbdBlockID.Columns(tdbdBlockID.DisplayMember).Text Then
                    tdbg.Columns(COL_BlockID).Text = ""
                    tdbg.Columns(COL_BlockName).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_DepartmentName).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                End If
            Case COL_DepartmentID
                If tdbg.Columns(COL_DepartmentID).Text <> tdbdDepartmentID.Columns(tdbdDepartmentID.DisplayMember).Text Then
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_DepartmentName).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                End If
            Case COL_TeamID
                If tdbg.Columns(COL_TeamID).Text <> tdbdTeamID.Columns(tdbdTeamID.DisplayMember).Text Then
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                End If
            Case COL_HAUnitPrice To COL_HAUnitPrice05
                If Not L3IsNumeric(tdbg.Columns(COL_HAUnitPrice).Text, EnumDataType.Number) Then tdbg.Columns(COL_HAUnitPrice).Text = "0"
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        '--- Gán giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_BlockID
                tdbg.Columns(COL_BlockName).Text = tdbdBlockID.Columns("BlockName").Text
                tdbg.Columns(COL_DepartmentID).Text = ""
                tdbg.Columns(COL_DepartmentName).Text = ""
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""
            Case COL_DepartmentID
                tdbg.Columns(COL_DepartmentName).Text = tdbdDepartmentID.Columns("DepartmentName").Text
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""
            Case COL_TeamID
                tdbg.Columns(COL_TeamName).Text = tdbdTeamID.Columns("TeamName").Text
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_HAUnitPrice To COL_HAUnitPrice05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.Row = 0 Then Exit Sub 'Vì dòng đầu tiên bị khóa lại

        If e.KeyCode = Keys.F7 Then
            If tdbg.Col = COL_BlockID Then
                HotKeyF7(tdbg, iColumns)
            ElseIf tdbg.Col = COL_DepartmentID Then
                HotKeyF7(tdbg, iColumns1)
            ElseIf tdbg.Col = COL_TeamID Then
                HotKeyF7(tdbg, iColumns2)
            Else
                HotKeyF7(tdbg)
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
        ElseIf e.Shift AndAlso e.KeyCode = Keys.Insert Then
            HotKeyShiftInsert(tdbg)
        ElseIf e.KeyCode = Keys.Enter AndAlso tdbg.Col = iLastCol Then
            If D45Options.UseEnterMoveDown Then Exit Sub
            HotKeyEnterGrid(tdbg, iColFirst, e, 0)
        End If

        HotKeyDownGrid(e, tdbg, COL_BlockID)
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        If tdbg.Row = 0 Then Exit Sub 'Vì dòng đầu tiên bị khóa lại
        '--- Đổ nguồn cho các Dropdown phụ thuộc
        Select Case tdbg.Col
            Case COL_DepartmentID
                LoadTDBDDepartmentID(tdbg(tdbg.Row, COL_BlockID).ToString)
            Case COL_TeamID
                LoadTDBDTeamID(tdbg(tdbg.Row, COL_BlockID).ToString, tdbg(tdbg.Row, COL_DepartmentID).ToString)
        End Select
    End Sub

    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If e.Row <> 0 Then Exit Sub
        e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        e.CellStyle.Locked = True
    End Sub
#End Region

    Private Sub HeadClick(ByVal iCol As Integer)
        tdbg.UpdateData()
        Select Case iCol
            Case COL_BlockID
                CopyColumnArr(tdbg, iCol, iColumns)
            Case COL_DepartmentID, COL_TeamID
                'K Headclick cot phu thuoc
            Case COL_HAUnitPrice
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Bookmark)
                FooterSumNew(tdbg, COL_HAUnitPrice)
        End Select
    End Sub

    Private Function AllowSave() As Boolean
        'Dòng đầu tiên bị khóa lại nên không kiểm tra
        For i As Integer = 1 To tdbg.RowCount - 1
            If tdbg(i, COL_TeamID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ma_to_nhom"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_TeamID
                tdbg.Bookmark = i
                Return False
            End If
            '***********************
            Dim dr() As DataRow = dtGrid.Select("TeamID=" & SQLString(tdbg(i, COL_TeamID)))
            If dr.Length > 1 Then
                D99C0008.MsgDuplicatePKey()
                tdbg.SplitIndex = SPLIT0
                tdbg.Focus()
                tdbg.Col = COL_TeamID
                tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(dr.Length - 1))
                Return False
            End If
            '***********************
            If tdbg.Splits(0).DisplayColumns(COL_HAUnitPrice).Visible AndAlso tdbg(i, COL_HAUnitPrice).ToString = "" Then
                D99C0008.MsgNotYetEnter(IIf(gbUnicode, tdbg.Columns(COL_HAUnitPrice).Caption, ConvertVniToUnicode(tdbg.Columns(COL_HAUnitPrice).Caption)).ToString)
                tdbg.SplitIndex = SPLIT0
                tdbg.Focus()
                tdbg.Col = COL_HAUnitPrice
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg.Splits(0).DisplayColumns(COL_HAUnitPrice02).Visible AndAlso tdbg(i, COL_HAUnitPrice02).ToString = "" Then
                D99C0008.MsgNotYetEnter(IIf(gbUnicode, tdbg.Columns(COL_HAUnitPrice02).Caption, ConvertVniToUnicode(tdbg.Columns(COL_HAUnitPrice02).Caption)).ToString)
                tdbg.SplitIndex = SPLIT0
                tdbg.Focus()
                tdbg.Col = COL_HAUnitPrice02
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg.Splits(0).DisplayColumns(COL_HAUnitPrice03).Visible AndAlso tdbg(i, COL_HAUnitPrice03).ToString = "" Then
                D99C0008.MsgNotYetEnter(IIf(gbUnicode, tdbg.Columns(COL_HAUnitPrice03).Caption, ConvertVniToUnicode(tdbg.Columns(COL_HAUnitPrice03).Caption)).ToString)
                tdbg.SplitIndex = SPLIT0
                tdbg.Focus()
                tdbg.Col = COL_HAUnitPrice03
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg.Splits(0).DisplayColumns(COL_HAUnitPrice04).Visible AndAlso tdbg(i, COL_HAUnitPrice04).ToString = "" Then
                D99C0008.MsgNotYetEnter(IIf(gbUnicode, tdbg.Columns(COL_HAUnitPrice04).Caption, ConvertVniToUnicode(tdbg.Columns(COL_HAUnitPrice04).Caption)).ToString)
                tdbg.SplitIndex = SPLIT0
                tdbg.Focus()
                tdbg.Col = COL_HAUnitPrice04
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg.Splits(0).DisplayColumns(COL_HAUnitPrice05).Visible AndAlso tdbg(i, COL_HAUnitPrice05).ToString = "" Then
                D99C0008.MsgNotYetEnter(IIf(gbUnicode, tdbg.Columns(COL_HAUnitPrice05).Caption, ConvertVniToUnicode(tdbg.Columns(COL_HAUnitPrice05).Caption)).ToString)
                tdbg.SplitIndex = SPLIT0
                tdbg.Focus()
                tdbg.Col = COL_HAUnitPrice05
                tdbg.Bookmark = i
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()
        If AllowSave() = False Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD45T2032.ToString & vbCrLf)
        sSQL.Append(SQLInsertD45T2032s.ToString & vbCrLf)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2032
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 01:30:57
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load luoi
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2032() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2032 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D45F2030") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_attCoefUPID) & COMMA 'AttCoefUPID, varchar[20], NOT NULL
        sSQL &= SQLString(_blockID) & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString(_departmentID) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(_teamID) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(_transID) & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Languge, varchar[20], NOT NULL

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2032
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 01:41:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2032() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T2032"
        sSQL &= " Where SplitTransID=" & SQLString(_transID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2032s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 24/10/2011 01:41:31
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2032s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 1 To tdbg.RowCount - 1 'Không lưu dòng đầu tiên vì dòng đầu tiên bị khóa lại
            sSQL.Append("Insert Into D45T2032(")
            sSQL.Append("AttCoefUPID, TransID, SplitTransID, BlockID, DepartmentID, TeamID, ")
            sSQL.Append("HAUnitPrice, HAUnitPrice02, HAUnitPrice03, HAUnitPrice04, HAUnitPrice05")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(_attCoefUPID) & COMMA) 'AttCoefUPID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_transID) & COMMA) 'SplitTransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_transID) & COMMA) 'SplitTransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BlockID)) & COMMA) 'BlockID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_HAUnitPrice), DxxFormat.DefaultNumber2) & COMMA) 'HAUnitPrice, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_HAUnitPrice02), DxxFormat.DefaultNumber2) & COMMA) 'HAUnitPrice02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_HAUnitPrice03), DxxFormat.DefaultNumber2) & COMMA) 'HAUnitPrice03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_HAUnitPrice04), DxxFormat.DefaultNumber2) & COMMA) 'HAUnitPrice04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_HAUnitPrice05), DxxFormat.DefaultNumber2)) 'HAUnitPrice05, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    
    
    
    
End Class