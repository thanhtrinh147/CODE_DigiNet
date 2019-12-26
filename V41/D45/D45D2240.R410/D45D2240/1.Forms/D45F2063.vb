'#-------------------------------------------------------------------------------------
'# Created Date: 10/05/2007 2:57:34 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 27/21/2009 
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Imports System.Text
Imports System
Imports System.Drawing
Public Class D45F2063
    Dim COL_Total As Integer
    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable
    Private bBA As SALBA
    Private bCE As SALCE


#Region "Const of tdbg - Total of Columns: 8"
    Private Const COL_DivisionID As String = "DivisionID"         ' Đơn vị
    Private Const COL_DivisionName As String = "DivisionName"     ' Tên đơn vị
    Private Const COL_BlockID As String = "BlockID"               ' Khối
    Private Const COL_BlockName As String = "BlockName"           ' Tên khối
    Private Const COL_DepartmentID As String = "DepartmentID"     ' Phòng ban
    Private Const COL_DepartmentName As String = "DepartmentName" ' Tên phòng ban
    Private Const COL_TeamID As String = "TeamID"                 ' Tổ nhóm 
    Private Const COL_TeamName As String = "TeamName"             ' Tên tổ nhóm
#End Region


    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _attMode As String = ""
    Public WriteOnly Property AttMode As String
        Set(ByVal Value As String)
            _attMode = Value
        End Set
    End Property
    
    Private _absentVoucherID As String = ""
    Public WriteOnly Property AbsentVoucherID As String
        Set(ByVal Value As String)
            _absentVoucherID = Value
        End Set
    End Property

    Private _remark As String = ""
    Public WriteOnly Property Remark As String
        Set(ByVal Value As String)
            _remark = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnSave.Enabled = True
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub D45F2062_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D13F2022_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        '***************************************
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
        End If
        '***************************************
        Select Case e.KeyCode
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub D13F2022_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        COL_Total = tdbg.Columns.Count
        gbEnabledUseFind = False
        LoadLanguage()
        tdbg_LockedColumns()
        '********************
        tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = D45Systems.IsUseBlock
        tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = D45Systems.IsUseBlock
        txtRemark.Text = _remark
        btnSave.Enabled = (ReturnPermission("D45F2060") >= 2) And _FormState <> EnumFormState.FormView
        '*****************************************
        LoadTableCaption(tdbg)
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        ResetSplitDividerSize(tdbg)
        btnFilter_Click(Nothing, Nothing)
        InputbyUnicode(Me, gbUnicode)
        CallD99U1111()
        SetShortcutPopupMenu(ContextMenuStrip1)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub
    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {IndexOfColumn(tdbg, COL_DivisionID), IndexOfColumn(tdbg, COL_BlockID), IndexOfColumn(tdbg, COL_DepartmentID), IndexOfColumn(tdbg, COL_TeamID)}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""
    Dim dtCaptionCols As DataTable

    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Giống sự kiện Finder_FindClick
        End Set
    End Property
    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {}
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbg.Splits.Count - 1
                AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
            Next
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode) ' Dùng DLL 
    End Sub
    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ReLoadTDBGrid()
    End Sub
#End Region

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DivisionID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DivisionName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Nhap_phieu_dieu_chinh_thu_nhap") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'NhËp phiÕu ¢iÒu chÙnh thu nhËp
        '================================================================ 
        btnFilter.Text = rL3("Loc") & " (F5)" 'Lọc
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnF12.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị
        '================================================================ 
        GroupBox1.Text = rL3("Chung_tu") 'Chứng từ
        '================================================================ 
        tdbg.Columns(COL_DivisionID).Caption = rL3("Don_vi") 'Đơn vị
        tdbg.Columns(COL_DivisionName).Caption = rL3("Ten_don_vi") 'Tên đơn vị
        tdbg.Columns(COL_BlockID).Caption = rL3("Khoi") 'Khối
        tdbg.Columns(COL_BlockName).Caption = rL3("Ten_khoi") 'Tên khối
        tdbg.Columns(COL_DepartmentID).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rL3("To_nhom") 'Tổ nhóm 
        tdbg.Columns(COL_TeamName).Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
    End Sub

    Dim dtGrid As DataTable
    Private Sub LoadTDBGrid()
        sFind = ""
        '***********************
        Dim sSQL As String = SQLStoreD45P2066()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub
    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Dim sSumFooter As New List(Of String)
    Private Sub ResetGrid()
        mnsFind.Enabled = tdbg.RowCount > 0 AndAlso gbEnabledUseFind
        mnsListAll.Enabled = mnsFind.Enabled
        '**************************
        FooterTotalGrid(tdbg, COL_DivisionID)
        FooterSumNew(tdbg, sSumFooter.ToArray)
    End Sub

#Region "tdbg"
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.UpdateData()
        ResetGrid()
    End Sub
    Private Sub tdbg_FetchCellTips(sender As Object, e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        If e.Row >= 0 Then
            Select Case tdbg.Columns(e.ColIndex).DataField
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

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.Control AndAlso e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tdbg_HeadClick(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub
#End Region

    Private Sub HeadClick(iCol As Integer)
        If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(iCol).Locked = False Then
            CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
            ResetGrid()
        End If
    End Sub
    'Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
    '    If Not AllowSave() Then Exit Sub

    '    Dim sSQL As String = ""
    '    Dim bRunSQL As Boolean
    '    btnSave.Enabled = False
    '    btnClose.Enabled = False

    '    sSQL = SQLInsertD45T2065s() & vbCrLf
    '    If sSQL <> "" Then
    '        bRunSQL = ExecuteSQL(sSQL)
    '        If bRunSQL Then
    '            'btnFilter_Click(Nothing, Nothing)
    '            SaveOK()
    '            _bSaved = True
    '            btnSave.Enabled = True
    '            btnClose.Enabled = True
    '            btnClose.Focus()
    '        Else
    '            SaveNotOK()
    '            btnSave.Enabled = True
    '            btnClose.Enabled = True
    '        End If
    '    End If
    'End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không

        'If Not CheckVoucherDateInPeriod(c1dateVoucherDate.Text) Then c1dateVoucherDate.Focus() : Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL() As StringBuilder = Nothing
        sSQL = SQLInsertD45T2065s() 'Tạo mảng SQL

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Me.Cursor = Cursors.WaitCursor
        btnFilter.Enabled = False

        LoadTDBGrid()
        btnFilter.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnF12Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

#Region "Add cột động"
    Dim dtCol As New DataTable
    Dim arrCol() As FormatColumn = Nothing
    Private Sub LoadTableCaption(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        'Xóa các cột động cũ, phải để trước load dtCol
        If dtCol IsNot Nothing AndAlso dtCol.Rows.Count > 0 Then
            For i As Integer = 0 To dtCol.Rows.Count - 1
                c1Grid.Columns.RemoveAt(IndexOfColumn(c1Grid, dtCol.Rows(i).Item("FieldName").ToString))
            Next
        End If

        Dim sSQL As String = SQLStoreD45P2065()
        dtCol = ReturnDataTable(sSQL) 'Đổ nguồn table caption cột động
        If dtCol.Rows.Count > 0 Then
            If tdbg.Splits.Count > 1 Then tdbg.RemoveHorizontalSplit(1)
            tdbg.InsertHorizontalSplit(1)
            tdbg.Splits(1).RecordSelectors = False
            tdbg.Splits(0).SplitSize = 10
            tdbg.Splits(1).SplitSize = 7
            For i As Integer = 0 To tdbg.Columns.Count - 1
                tdbg.Splits(1).DisplayColumns(i).Visible = False
            Next
        End If
        arrCol = Nothing
        '*********************
        'Add cột
        For i As Integer = 0 To dtCol.Rows.Count - 1
            AddColumns(c1Grid, i, dtCol)
        Next

        'Định dạng các cột số trên lưới
        If arrCol IsNot Nothing Then InputNumber(c1Grid, arrCol)
        tdbg.Refresh()
    End Sub

    Dim iIndexCol As Integer = 0
    Private Sub AddColumns(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal i As Integer, ByVal dtCol As DataTable, Optional ByVal bChangeDisplayColums As Boolean = False)
        Dim sField As String = dtCol.Rows(i).Item("FieldName").ToString
        Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn
        dc.Caption = dtCol.Rows(i).Item("Caption").ToString
        dc.DataField = sField
        If bChangeDisplayColums = False Then
            c1Grid.Columns.Add(dc)
        Else
            iIndexCol = L3Int(dtCol.Rows(i).Item("OrderNo")) 'Index insert do store trả ra
            c1Grid.Columns.Insert(iIndexCol, dc)
            '=============================================================================================
            For k As Integer = 0 To c1Grid.Splits.ColCount - 1
                Dim dispColumn As C1.Win.C1TrueDBGrid.C1DisplayColumn = c1Grid.Splits(k).DisplayColumns(dc.DataField)
                tdbg_ChangeDisplayColumns(c1Grid, dispColumn, iIndexCol, k)
            Next k
        End If
        SetFormatCol(c1Grid, sField, dtCol.Rows(i).Item("Decimals").ToString)
    End Sub
    Public Sub tdbg_ChangeDisplayColumns(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dispColumnOld As C1.Win.C1TrueDBGrid.C1DisplayColumn, ByVal posNew As Integer, Optional ByVal iSplit As Integer = 0)
        With c1Grid.Splits(iSplit)
            Dim iDisplay As Integer = .DisplayColumns.IndexOf(dispColumnOld.DataColumn)
            If iDisplay = -1 Then Exit Sub

            Dim dispColumn As C1.Win.C1TrueDBGrid.C1DisplayColumn = .DisplayColumns(dispColumnOld.DataColumn)
            dispColumn.Style.HorizontalAlignment = dispColumnOld.Style.HorizontalAlignment
            dispColumn.Style.VerticalAlignment = dispColumnOld.Style.VerticalAlignment
            dispColumn.Style.Font = New Font(dispColumnOld.Style.Font.Name, dispColumnOld.Style.Font.Size, dispColumnOld.Style.Font.Style)
            dispColumn.HeadingStyle.Font = New Font(dispColumnOld.HeadingStyle.Font.Name, dispColumnOld.HeadingStyle.Font.Size, dispColumnOld.HeadingStyle.Font.Style)
            dispColumn.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            dispColumn.Button = dispColumnOld.Button
            dispColumn.ButtonAlways = dispColumnOld.ButtonAlways
            dispColumn.ButtonText = dispColumnOld.ButtonText
            dispColumn.FetchStyle = dispColumnOld.FetchStyle
            dispColumn.Locked = dispColumnOld.Locked
            dispColumn.Merge = dispColumnOld.Merge
            dispColumn.Visible = dispColumnOld.Visible
            .DisplayColumns.RemoveAt(iDisplay)
            .DisplayColumns.Insert(posNew, dispColumn)
        End With
    End Sub
    Private Sub SetFormatCol(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sField As String, sDecimals As String)
        Dim iSplitIndex As Integer = 1 'c1Grid.Splits.Count - 1
        Try
            c1Grid.Splits(0).DisplayColumns(sField).Visible = False
            c1Grid.Splits(iSplitIndex).DisplayColumns(sField).Visible = True

            c1Grid.Splits(iSplitIndex).DisplayColumns(sField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            AddDecimalColumns(arrCol, sField, "N" & L3Int(sDecimals), 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
            c1Grid.Splits(iSplitIndex).DisplayColumns(sField).Width = 110
            sSumFooter.Add(sField)
        Catch ex As Exception

        End Try

        c1Grid.Splits(iSplitIndex).DisplayColumns(sField).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        c1Grid.Splits(iSplitIndex).DisplayColumns(sField).HeadingStyle.Font = FontUnicode(gbUnicode)
        c1Grid.Splits(iSplitIndex).DisplayColumns(sField).Style.Font = FontUnicode(gbUnicode)
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2065
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 26/10/2016 11:37:31
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2065() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cot dong" & vbCrlf)
        sSQL &= "Exec D45P2065 "
        sSQL &= SQLString(_absentVoucherID) & COMMA 'AbsentVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString("Team") & COMMA 'TransTypeID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2066
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 26/10/2016 11:38:19
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2066() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrlf)
        sSQL &= "Exec D45P2066 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString("%") & COMMA 'DepartmentID, varchar[50], NOT NULL
        sSQL &= SQLString("%") & COMMA 'TeamID, varchar[50], NOT NULL
        sSQL &= SQLString(_absentVoucherID) & COMMA 'AbsentVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'TransTypeID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(_attMode) & COMMA 'AttMode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D45F2060") 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0103s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/02/2007 08:48:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2065(ByVal iRow As Integer) As String
        Dim sRet As String = ""
        Dim sSQL As String = ""

        sSQL = "Delete  D45T2065" & vbCrLf
        sSQL &= "Where 	DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "And  	AbsentVoucherID = " & SQLString(_absentVoucherID) & vbCrLf
        sSQL &= "And DepartmentID = " & SQLString(tdbg(iRow, COL_DepartmentID)) & vbCrLf
        sSQL &= "And TeamID = " & SQLString(tdbg(iRow, COL_TeamID)) & vbCrLf
        sSQL &= "And BlockID = " & SQLString(tdbg(iRow, COL_BlockID)) & vbCrLf

        sRet &= sSQL & vbCrLf
        Return sRet
    End Function

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLInsertD4T2065s
    ''# Created User: dmd
    ''# Created Date: 26/11/2009 08:55:25
    ''# Modify User: 
    ''# Modify Date: 
    ''# Description: 
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLInsertD45T2065s() As String

    '    Dim iCount As Int32 = 0
    '    Dim bResult As Boolean

    '    Dim sSQL As String = ""

    '    For i As Integer = 0 To tdbg.RowCount - 1
    '        iCount += 1
    '        sSQL &= SQLDeleteD45T2065(i) & vbCrLf
    '        For j As Integer = 0 To dtCol.Rows.Count - 1
    '            Dim sField As String = dtCol.Rows(j).Item("FieldName").ToString
    '            '***************
    '            If Number(tdbg(i, sField)) <> 0 Then
    '                sSQL &= "Insert Into D45T2065(" & vbCrLf
    '                sSQL &= " DivisionID, AbsentVoucherID, BlockID, DepartmentID, TeamID, AbsentTypeID, " & vbCrLf
    '                sSQL &= " TranMonth, TranYear, Value" & vbCrLf
    '                sSQL &= ") Values (" & vbCrLf

    '                sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID [KEY], varchar[20], NOT NULL
    '                sSQL &= SQLString(_absentVoucherID) & COMMA 'AbsentVoucherID [KEY], varchar[20], NOT NULL
    '                sSQL &= SQLString(tdbg(i, COL_BlockID)) & COMMA 'DepartmentID [KEY], varchar[20], NOT NULL
    '                sSQL &= SQLString(tdbg(i, COL_DepartmentID)) & COMMA 'DepartmentID [KEY], varchar[20], NOT NULL
    '                sSQL &= SQLString(tdbg(i, COL_TeamID)) & COMMA 'TeamID [KEY], varchar[20], NOT NULL
    '                sSQL &= SQLString(sField) & COMMA 'AbsentTypeID, varchar[20], NOT NULL
    '                sSQL &= SQLNumber(giTranMonth) & COMMA 'Tranmonth, tinyint, NOT NULL
    '                sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
    '                sSQL &= SQLMoney(tdbg(i, sField))  'Value, decimal, NOT NULL
    '                sSQL &= ")" & vbCrLf
    '            End If
    '        Next

    '        If iCount = 10 Then
    '            bResult = ExecuteSQL(sSQL)
    '            If bResult = True Then
    '                iCount = 0
    '                sSQL = ""
    '                If i = tdbg.RowCount - 1 Then
    '                    SaveOK()
    '                    btnSave.Enabled = True
    '                    btnClose.Enabled = True
    '                    btnClose.Focus()
    '                    Exit For
    '                End If
    '            Else
    '                SaveNotOK()
    '                btnSave.Enabled = True
    '                btnClose.Enabled = True
    '                btnClose.Focus()
    '                Exit For
    '            End If

    '        End If
    '    Next
    '    Return sSQL
    'End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2065s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/10/2016 02:42:21
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2065s() As StringBuilder()
        Dim sRet() As StringBuilder = Nothing
        Dim iCountSQL As Integer = 0 'Đếm số câu SQL để thực thi
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If sSQL.ToString = "" And sRet Is Nothing Then sSQL.Append("-- Luu du llieu" & vbCrlf)
            sSQL.Append(SQLDeleteD45T2065(i) & vbCrLf)

            For j As Integer = 0 To dtCol.Rows.Count - 1
                Dim sField As String = dtCol.Rows(j).Item("FieldName").ToString
                '***************
                If Number(tdbg(i, sField)) <> 0 Then
                    sSQL.Append("Insert Into D45T2065(" & vbCrLf)
                    sSQL.Append(" DivisionID, AbsentVoucherID, BlockID, DepartmentID, TeamID, AbsentTypeID, " & vbCrLf)
                    sSQL.Append(" TranMonth, TranYear, Value" & vbCrLf)
                    sSQL.Append(") Values (" & vbCrLf)
                    sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
                    sSQL.Append(SQLString(_absentVoucherID) & COMMA) 'AbsentVoucherID [KEY], varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_BlockID)) & COMMA) 'DepartmentID [KEY], varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID [KEY], varchar[20], NOT NULL
                    sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID [KEY], varchar[20], NOT NULL
                    sSQL.Append(SQLString(sField) & COMMA) 'AbsentTypeID, varchar[20], NOT NULL
                    sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'Tranmonth, tinyint, NOT NULL
                    sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
                    sSQL.Append(SQLMoney(tdbg(i, sField)))  'Value, decimal, NOT NULL
                    sSQL.Append(")" & vbCrLf)
                End If
            Next

            iCountSQL += 1
            sRet = ReturnSQL(sRet, sSQL, iCountSQL, 10) 'Mặc định là 30 dòng Insert
        Next
        sRet = AddValueInArrStringBuilder(sRet, sSQL, True) 'Mặc định là thêm vào cuối mảng SQL
        Return sRet
    End Function


End Class

