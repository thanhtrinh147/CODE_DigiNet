Imports System
Public Class D25F2021
	Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_IsUsed As Integer = 0          ' Chọn
    Private Const COL_TransID As Integer = 1         ' TransID
    Private Const COL_BlockID As Integer = 2         ' BlockID
    Private Const COL_BlockName As Integer = 3       ' Khối
    Private Const COL_DepartmentID As Integer = 4    ' DepartmentID
    Private Const COL_DepartmentName As Integer = 5  ' Phòng ban
    Private Const COL_TeamID As Integer = 6          ' TeamID
    Private Const COL_TeamName As Integer = 7        ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 8   ' RecPositionID
    Private Const COL_RecPositionName As Integer = 9 ' Vị trí
    Private Const COL_EmployeeQTY As Integer = 10    ' Định mức
    Private Const COL_ProNumber As Integer = 11      ' Số lượng
    Private Const COL_DateFrom As Integer = 12       ' Từ ngày
    Private Const COL_DateTo As Integer = 13         ' Đến ngày
    Private Const COL_VoucherDate As Integer = 14    ' Ngày lập
    Private Const COL_CreatorID As Integer = 15      ' Người lập
    Private Const COL_ReferenceNo As Integer = 16    ' Số tham chiếu
    Private Const COL_Ref01 As Integer = 17          ' Ref01
    Private Const COL_Ref02 As Integer = 18          ' Ref02
    Private Const COL_Ref03 As Integer = 19          ' Ref03
    Private Const COL_Ref04 As Integer = 20          ' Ref04
    Private Const COL_Ref05 As Integer = 21          ' Ref05
    Private Const COL_Ref06 As Integer = 22          ' Ref06
    Private Const COL_Ref07 As Integer = 23          ' Ref07
    Private Const COL_Ref08 As Integer = 24          ' Ref08
    Private Const COL_Ref09 As Integer = 25          ' Ref09
    Private Const COL_Ref10 As Integer = 26          ' Ref10
    Private Const COL_ProNote As Integer = 27        ' Ghi chú
    Private Const COL_AppNumber As Integer = 28      ' SL duyệt
    Private Const COL_AppDate As Integer = 29        ' Ngày duyệt
    Private Const COL_ApproverID As Integer = 30     ' Người duyệt
    Private Const COL_AppNote As Integer = 31        ' Ghi chú
#End Region

    Private _savedOK As Boolean = False
    Public ReadOnly Property SavedOK() As Boolean
        Get
            Return _savedOK
        End Get
    End Property

    Private _alertID As String = "D25F3000"
    Public WriteOnly Property AlertID() As String
        Set(ByVal Value As String)
            _alertID = Value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShow, chkIsUsed)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnSave, btnClose)

    End Sub

    Dim dtIsUseBlock As New DataTable
    Private usrOption As D09U1111

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            DataIsUseBlock()    'load table dtIsUseBlock
            bIsUseBlock = IsUseBlock()
            LoadTDBDropDown()
            If Not bIsUseBlock Then    'neu IsUseBlock = 0 thi an cot COL_BlockID va COL_BlockName
                tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockID).Visible = False
                tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockName).Visible = False
            End If

            Select Case _FormState

                Case EnumFormState.FormAdd
                    dtGrid = ReturnDataTable(SQLStoreD25P2022())

                Case EnumFormState.FormEdit

            End Select
        End Set
    End Property

    Private _dtGrid As DataTable
    Public Property dtGrid() As DataTable
        Get
            Return _dtGrid
        End Get
        Set(ByVal Value As DataTable)
            _dtGrid = Value
        End Set
    End Property

    Private _transID As String
    Public Property TransID() As String
        Get
            Return _transID
        End Get
        Set(ByVal Value As String)
            _transID = Value
        End Set
    End Property

    Private Sub D25F2080_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Hỏi trước khi đóng 
        If _FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormOther Then
            If Not _savedOK Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If btnSave.Enabled Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        End If
    End Sub

    Private Sub D25F2080_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If


        '***************************************
        'Chuẩn hóa D09U1111 B4: mở, đóng UserControl
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShow_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            usrOption.Hide()
        End If
        '***************************************
    End Sub

    Private Sub tdbg_LockedColumns()
        For i As Integer = COL_TransID To COL_ProNote
            tdbg.Splits(SPLIT1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(i).Locked = True
            tdbg.Splits(SPLIT1).DisplayColumns(i).AllowFocus = False
        Next
    End Sub

    Private Sub DataIsUseBlock()
        Dim sSQL As String = ""
        sSQL = "select IsUseBlock from D09T0000 WITH(NOLOCK) "
        dtIsUseBlock = ReturnDataTable(sSQL)
    End Sub

    Private Function IsUseBlock() As Boolean
        If dtIsUseBlock.Rows.Count > 0 Then
            If dtIsUseBlock.Rows(0).Item("IsUseBlock").ToString = "0" Then
                Return False
            End If
        End If
        Return True
    End Function

    Dim bIsUseBlock As Boolean
    Private Sub D25F2080_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _FormState
        Loadlanguage()
        gbEnabledUseFind = False
        LoadTdbg()
        InputDateInTrueDBGrid(tdbg, COL_DateFrom, COL_DateTo, COL_AppDate, COL_VoucherDate, COL_AppDate)
        tdbg_LockedColumns()
        LoadRefCaption()
        ResetSplitDividerSize(tdbg)

        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_IsUsed, COL_AppNumber, COL_AppDate, COL_ApproverID, COL_AppNote}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, False, False, gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory, False, False, gbUnicode)
        AddColVisible(tdbg, SPLIT2, Arr, arrColObligatory, False, False, gbUnicode)
        '*****************************************
        'Chuẩn hóa D09U1111 B2: Khởi tạo UserControl    
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , , , gbUnicode)
        '*****************************************

        SetShortcutPopupMenu(Me, Nothing, ContextMenuStrip1)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DepartmentName).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DepartmentID).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None

        tdbg.Splits(SPLIT1).DisplayColumns(COL_TeamID).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TeamName).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None

        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        tdbg.Splits(2).MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Duyet_de_xuat_tuyen_dung_-_D25F2021") & UnicodeCaption(gbUnicode) 'DuyÖt ¢Ò xuÊt tuyÓn dóng - D25F2021
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnShow.Text = rL3("Hien_thi") & Space(1) & "(F12)"
        '================================================================ 
        chkIsUsed.Text = rL3("Chi_hien_thi_du_lieu_da_chon") 'Chỉ hiển thị dữ liệu đã chọn
        chkIsUsed.Text = rL3("Chi_hien_thi_du_lieu_da_chon") 'Chỉ hiển thị dữ liệu đã chọn
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("BlockName").Caption = rl3("Khoi") 'Khối
        tdbg.Columns("DepartmentName").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamName").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("RecPositionName").Caption = rl3("Vi_tri") 'Vị trí
        tdbg.Columns("EmployeeQTY").Caption = rl3("Dinh_muc") 'Định mức
        tdbg.Columns("ProNumber").Caption = rl3("So_luong") 'Số lượng
        tdbg.Columns("DateFrom").Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_lap") 'Ngày lập
        tdbg.Columns("ProNote").Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns("CreatorID").Caption = rl3("Nguoi_lap")
        tdbg.Columns("AppNumber").Caption = rl3("SL_duyet") 'SL duyệt
        tdbg.Columns("AppDate").Caption = rl3("Ngay_duyet") 'Ngày duyệt
        tdbg.Columns("ApproverID").Caption = rl3("Nguoi_duyet") 'Người duyệt
        tdbg.Columns("AppNote").Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns("ReferenceNo").Caption = rl3("So_tham_chieu")
    End Sub

    Private Sub LoadTdbg()
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        resetgrid()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim dr() As DataRow = Nothing
        If Not AllowSave(dr) Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLUpdateD25T2001s().ToString)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _savedOK = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd

                Case EnumFormState.FormEdit Or EnumFormState.FormOther
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        dtGrid.AcceptChanges()
        dr = dtGrid.Select(tdbg.Columns(COL_IsUsed).DataField & " = 1")
        If dr.Length = 0 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.SplitIndex = SPLIT0
            tdbg.Focus()
            tdbg.Col = COL_IsUsed
            Return False
        End If
        '******************
        For i As Integer = 0 To dr.Length - 1
            If dr(i).Item(tdbg.Columns(COL_AppNumber).DataField).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbg.Columns(COL_AppNumber).Caption)
                tdbg.Focus()
                tdbg.SplitIndex = 2
                tdbg.Col = COL_AppNumber
                tdbg.Row = dtGrid.Rows.IndexOf(dr(i))
                Return False
            End If

            If dr(i).Item(tdbg.Columns(COL_AppDate).DataField).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbg.Columns(COL_AppDate).Caption)
                tdbg.Focus()
                tdbg.SplitIndex = 2
                tdbg.Col = COL_AppDate
                tdbg.Row = dtGrid.Rows.IndexOf(dr(i))
                Return False
            End If

            If dr(i).Item(tdbg.Columns(COL_ApproverID).DataField).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbg.Columns(COL_ApproverID).Caption)
                tdbg.Focus()
                tdbg.SplitIndex = 2
                tdbg.Col = COL_ApproverID
                tdbg.Row = dtGrid.Rows.IndexOf(dr(i))
                Return False
            End If
        Next
        '************************
        'ID 65864 04/07/2014
        Dim sSQL As New StringBuilder
        sSQL.Append("--Kiem tra du lieu co duoc phep duyet hay khong truoc khi luu" & vbCrLf)
        sSQL.Append(SQLDeleteD09T6666.ToString & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s(dr).ToString & vbCrLf)
        sSQL.Append(SQLStoreD25P5555.ToString)
        Return CheckStore(sSQL.ToString)

        'Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AppNumber).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AppDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ApproverID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadRefCaption()
        Dim sSQL As String = ""
        Dim dtSpec As New DataTable

        sSQL = SQLStoreD25P0050("D25T2001", gbUnicode)
        dtSpec = ReturnDataTable(sSQL)

        If dtSpec.Rows.Count <= 0 Then Exit Sub

        For i As Integer = 0 To 9
            tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref01 + i).Visible = Not CBool(dtSpec.Rows(i).Item("Disabled").ToString)
            tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref01 + i).HeadingStyle.Font = FontUnicode(gbUnicode, tdbg.Splits(SPLIT1).DisplayColumns(COL_Ref01 + i).HeadingStyle.Font.Style)
            tdbg.Columns(COL_Ref01 + i).Caption = dtSpec.Rows(i).Item("RefCaption").ToString
        Next

    End Sub

#Region "Tdbg"

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        If _FormState = EnumFormState.FormOther Then
            Select Case e.ColIndex
                Case COL_BlockName, COL_DepartmentName, COL_TeamName, COL_RecPositionName, COL_ProNumber, COL_DateFrom, COL_DateTo, COL_VoucherDate, COL_ProNote, COL_Ref01, COL_Ref02, COL_Ref03, COL_Ref04, COL_Ref05, COL_Ref06, COL_Ref07, COL_Ref08, COL_Ref09, COL_Ref10
                    If tdbg.Row = 0 Then
                        e.Cancel = True
                    End If

            End Select
        End If
    End Sub

    Dim bNotInList As Boolean
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_ProNumber
                If Not L3IsNumeric(tdbg.Columns(COL_ProNumber).Text, EnumDataType.Int) Then e.Cancel = True
            Case COL_ApproverID
                If tdbg.Columns(e.ColIndex).Text <> tdbdEmployeeID.Columns("EmployeeName").Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        Select Case e.ColIndex
            Case COL_IsUsed
                If L3Bool(tdbg.Columns(tdbg.Col).Text) Then
                    tdbg.Columns(COL_AppNumber).Text = tdbg.Columns(COL_ProNumber).Text
                    tdbg.Columns(COL_AppDate).Text = Date.Now().ToString
                Else
                    tdbg.Columns(COL_AppNumber).Text = "0"
                    tdbg.Columns(COL_AppDate).Text = ""
                End If
                tdbg.UpdateData()
                FooterTotalGrid(tdbg, COL_DepartmentName)
            Case COL_ApproverID
                If bNotInList = True Then
                    tdbg.Columns(COL_ApproverID).Text = ""
                    '  dtGrid.Rows(tdbg.Row).Item("ApproverName") = tdbg.Columns(COL_ApproverID).Text
                    bNotInList = False
                Else
                    ' dtGrid.Rows(tdbg.Row).Item("ApproverName") = tdbg.Columns(COL_ApproverID).Text
                End If

        End Select
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case tdbg.Col
            Case COL_ApproverID
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) Then
                    tdbg.Columns(COL_ApproverID).DropDown = tdbdEmployeeID
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
                Else
                    tdbg.Columns(COL_ApproverID).DropDown = Nothing
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = True
                End If
            Case Else
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) Then
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
                Else
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = True
                End If
        End Select

    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_ApproverID
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) Then
                    ' tdbg.Columns(COL_ApproverID).DropDown = tdbdEmployeeID
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
                    ' tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoDropDown = True
                Else
                    ' tdbg.Columns(COL_ApproverID).DropDown = Nothing
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = True
                    ' tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoDropDown = False
                End If
                tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Button = tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
            Case Else
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) Then
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = False
                Else
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).Locked = True
                End If
        End Select
    End Sub

    Private Sub HotKeyEnterGrid(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal nFirstCol As Integer, ByVal e As System.Windows.Forms.KeyEventArgs, Optional ByVal iSplitFocus As Integer = 0)
        Try
            'Không gọi hàm CountCol tại đây (do khi gọi ) mà gọi trong code từng form
            With c1Grid
                .UpdateData()

                .SplitIndex = iSplitFocus
                If c1Grid.AllowAddNew = True Then
                    .Row = .Row + 1
                Else
                    .Row = CInt(IIf(.RowCount = .Row + 1, 0, .Row + 1))
                End If
                .Col = nFirstCol
                e.SuppressKeyPress = True
                e.Handled = True
            End With
        Catch ex As Exception
            D99C0008.Msg("Lỗi HotKeyEnterGrid: " & ex.Message)
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                HotKeyF7(tdbg)
            Case Keys.Enter

                Select Case tdbg.Col
                    Case COL_AppNote
                        HotKeyEnterGrid(tdbg, COL_IsUsed, e, SPLIT0)
                End Select

            Case Keys.Tab

        End Select
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
            Exit Sub
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_IsUsed
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_AppNumber
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub HeadClick(ByVal iCol As Integer)
        Select Case iCol
            Case COL_IsUsed
                tdbg.AllowSort = False
                Dim bFlag As Boolean = Not bSelect
                'For i As Integer = 0 To tdbg.RowCount - 1
                '    tdbg(i, COL_IsUsed) = bFlag
                '    If bFlag Then
                '        tdbg(i, COL_AppNumber) = tdbg(i, COL_ProNumber)
                '        tdbg(i, COL_AppDate) = Date.Now().ToString
                '    Else
                '        tdbg(i, COL_AppNumber) = "0"
                '        tdbg(i, COL_AppDate) = ""
                '    End If
                'Next
                Dim i As Integer = tdbg.RowCount - 1
                While i >= 0
                    If bFlag Then
                        tdbg(i, COL_AppNumber) = tdbg(i, COL_ProNumber)
                        tdbg(i, COL_AppDate) = Date.Now().ToString
                    Else
                        tdbg(i, COL_AppNumber) = "0"
                        tdbg(i, COL_AppDate) = ""
                    End If
                    tdbg(i, COL_IsUsed) = bFlag

                    i -= 1
                End While
                bSelect = bFlag
            Case COL_ApproverID, COL_ProNote
                tdbg.AllowSort = False
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
            Case Else
                tdbg.AllowSort = True
        End Select
        tdbg.UpdateData()
    End Sub

    Dim bSelect As Boolean = False
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub
#End Region

    Private Sub LoadTDBDropDown()
        'Dim sSQL As String = ""
        'LoadDataSource(tdbdEmployeeID, ReturnTableEmployeeID(True, False, gbUnicode), gbUnicode)

        'ID 76709 22/07/2015
        Using obj As Lemon3.Data.LoadData.LoadDataG4 = New Lemon3.Data.LoadData.LoadDataG4
            obj.LoadApprovalByG4(tdbdEmployeeID, "D25F2021")
        End Using
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        usrOption.Location = New Point(tdbg.Left, btnShow.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2022
    '# Created User: DUCTRONG
    '# Created Date: 03/06/2010 03:54:57
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2022() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2022 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(_alertID) 'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2001s
    '# Created User: DUCTRONG
    '# Created Date: 03/06/2010 08:21:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2001s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                sSQL.Append("Update D25T2001 Set ")

                sSQL.Append("ProApproved = " & SQLNumber(1) & COMMA) 'tinyint, NOT NULL
                sSQL.Append("AppNumber = " & SQLNumber(tdbg(i, COL_ProNumber)) & COMMA) 'int, NOT NULL
                sSQL.Append("AppNote = " & SQLStringUnicode(tdbg(i, COL_AppNote), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
                sSQL.Append("AppNoteU = " & SQLStringUnicode(tdbg(i, COL_AppNote), gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
                sSQL.Append("ApproverID = " & SQLString(tdbg(i, COL_ApproverID)) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("AppDate = " & SQLDateSave(tdbg(i, COL_AppDate))) 'datetime, NULL
                sSQL.Append(" Where ")
                sSQL.Append("TransID = " & SQLString(tdbg(i, COL_TransID)))

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

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

    'Private Sub ReLoadTDBGrid()
    '    Dim strFind As String = sFind
    '    If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
    '    strFind &= sFilter.ToString

    '    'If Not chkShowDisabled.Checked Then
    '    '    If strFind <> "" Then strFind &= " And "
    '    '    strFind &= "Disabled =0"
    '    'End If
    '    dtGrid.DefaultView.RowFilter = strFind.Replace("ApproverID", "ApproverName")
    '    '  LoadGridFind(tdbg, dtGrid, strFind)'gây lỗi không nhập được ký tự thứ 2 trên filter
    '    ' Nếu lưới có Group thì bổ sung thêm 2 đoạn lệnh sau:
    '    ResetGrid()
    'End Sub

    Private Sub ReLoadTDBGrid()
        dtGrid.AcceptChanges()
        Dim strFind As String = "" 'TH sFind="" và chkIsUsed.Checked =False
        If chkIsUsed.Checked Then
            strFind = "IsUsed = True"
        Else
            strFind = sFind
            If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
            strFind &= sFilter.ToString

            If strFind <> "" Then strFind = "IsUsed = True" & " Or " & strFind
        End If
        dtGrid.DefaultView.RowFilter = strFind.Replace("ApproverID", "ApproverName")

        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        mnsFind.Enabled = (Not chkIsUsed.Checked) And (gbEnabledUseFind OrElse tdbg.RowCount > 0)
        mnsListAll.Enabled = mnsFind.Enabled
        FooterTotalGrid(tdbg, COL_DepartmentName)
    End Sub


#Region "Active Find - List All (Client)"
    'Dim dtCaptionCols As DataTable

    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid()
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, , False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
        sFind = ResultWhereClause.ToString()
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub
#End Region

    Private Sub chkIsUsed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUsed.CheckedChanged

        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 04/07/2014 04:24:07
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID = " & SQLString(gsUserID) & " AND HostID = " & SQLString(My.Computer.Name) & " AND FormID = " & SQLString(Me.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 04/07/2014 04:29:23
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(tdbg.Columns(COL_TransID).DataField).ToString) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 04/07/2014 04:31:49
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5555() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Type, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


End Class