Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 11/12/2008 11:49:51 AM
'# Created User: Đỗ Minh Dũng
'# Modify Date: 11/12/2008 11:49:51 AM
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D25F2100
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Dim dtCaptionCols As DataTable
    Dim bNotInList As Boolean = False
    Public dtD25F3060 As DataTable
    Dim dtGrid As DataTable
    Dim iPerD25F2100 As Integer = ReturnPermission("D25F2100")
    Dim bFlag As Boolean = False


#Region "Const of tdbg - Total of Columns: 28"
    Private Const COL_TransID As Integer = 0            ' TransID
    Private Const COL_Approved As Integer = 1           ' Duyệt
    Private Const COL_NotApproved As Integer = 2        ' Từ chối
    Private Const COL_CandidateID As Integer = 3        ' Mã ứng viên
    Private Const COL_CandidateName As Integer = 4      ' Tên ứng viên
    Private Const COL_BlockID As Integer = 5            ' BlockID
    Private Const COL_BlockName As Integer = 6          ' Khối
    Private Const COL_DepartmentID As Integer = 7       ' DepartmentID
    Private Const COL_DepartmentName As Integer = 8     ' Phòng ban
    Private Const COL_TeamID As Integer = 9             ' TeamID
    Private Const COL_TeamName As Integer = 10          ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 11     ' RecPositionID
    Private Const COL_RecPositionName As Integer = 12   ' Vị trí
    Private Const COL_SexName As Integer = 13           ' Giới tính
    Private Const COL_Birthdate As Integer = 14         ' Ngày sinh
    Private Const COL_ContactAddress As Integer = 15    ' Địa chỉ
    Private Const COL_Telephone As Integer = 16         ' Điện thoại
    Private Const COL_Email As Integer = 17             ' Email
    Private Const COL_WorkID As Integer = 18            ' WorkID
    Private Const COL_WorkName As Integer = 19          ' Công việc
    Private Const COL_DutyID As Integer = 20            ' DutyID
    Private Const COL_DutyName As Integer = 21          ' Chức vụ
    Private Const COL_BeginDate As Integer = 22         ' Ngày vào làm
    Private Const COL_WorkingStatusID As Integer = 23   ' WorkingStatusID
    Private Const COL_WorkingStatusName As Integer = 24 ' Hình thức làm việc
    Private Const COL_WorkingPlace As Integer = 25      ' Địa điểm
    Private Const COL_AppDate As Integer = 26           ' Ngày duyệt
    Private Const COL_ApproverID As Integer = 27        ' Người duyệt
#End Region


#Region "UserControl D09U1111 (gồm 4 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới KHÔNG có nút: gồm 4 bước
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
    '*****************************************
    Dim bLoadFormChild As Boolean = False 'Ktra xem co goi form con k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
#End Region

    Private _transID As String = "%"
    Public Property TransID() As String
        Get
            Return _transID
        End Get
        Set(ByVal Value As String)
            _transID = value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            LoadTDBDropDown()

            Select Case _FormState
                Case EnumFormState.FormAdd

                Case EnumFormState.FormEdit
               
            End Select
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShowOption, chkIsUsed)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnSave, btnClose)

    End Sub

    Private Sub D25F2060_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab Then
            If e.KeyCode = Keys.Enter Then UseEnterAsTab(Me)
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowOption_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
        '***************************************
    End Sub

    Private Sub D25F2060_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        _bSaved = False
        ResetColorGrid(tdbg, 0, 2)
        tdbg.Splits(2).MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        ResetSplitDividerSize(tdbg)
        gbEnabledUseFind = False
        SetShortcutPopupMenu(Me, Nothing, ContextMenuStrip1)
        Loadlanguage()
        SetBackColorObligatory()
        tdbg_LockedColumns()
        'LoadTDBDropDown()
        VisibleBlock()
        LoadTDBGrid()
        '*************************************
        InputDateInTrueDBGrid(tdbg, COL_BeginDate, COL_AppDate)
        InputbyUnicode(Me, gbUnicode)
        '********************
        CallD09U1111_Button(True)
        btnSave.Enabled = iPerD25F2100 > EnumPermission.View
        '********************
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Duyet_quyet_dinh_tuyen_dung_-_D25F2100") & UnicodeCaption(gbUnicode) 'DuyÖt quyÕt ¢Ünh tuyÓn dóng - D25F2100
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        chkIsUsed.Text = rl3("Chi_hien_thi_nhung_du_lieu_da_chon")
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnShowOption.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        '================================================================ 
        tdbdApproverID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbdApproverID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("Approved").Caption = rl3("Duyet") 'Duyệt
        tdbg.Columns("CandidateID").Caption = rl3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns("CandidateName").Caption = rl3("Ten_ung_vien") 'Tên ứng viên
        tdbg.Columns("BlockName").Caption = rl3("Khoi") 'Tên khối
        tdbg.Columns("DepartmentName").Caption = rl3("Phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamName").Caption = rl3("To_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionName").Caption = rl3("Vi_tri") 'Tên vị trí
        tdbg.Columns("SexName").Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg.Columns("BirthDate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("ContactAddress").Caption = rl3("Dia_chi") 'Địa chỉ
        tdbg.Columns("Telephone").Caption = rl3("Dien_thoai") 'Điện thoại
        tdbg.Columns("WorkName").Caption = rl3("Cong_viec") 'Công việc
        tdbg.Columns("DutyName").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns("BeginDate").Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns("WorkingStatusName").Caption = rl3("Hinh_thuc_lam_viec") 'Hình thức làm việc
        tdbg.Columns("WorkingPlace").Caption = rl3("Dia_diem") 'Địa điểm
        tdbg.Columns("AppDate").Caption = rl3("Ngay_duyet") 'Ngày duyệt
        tdbg.Columns("ApproverID").Caption = rL3("Nguoi_duyet") 'Người duyệt

        tdbg.Columns(COL_NotApproved).Caption = rL3("Tu_choi")
    End Sub

    Private Sub SetBackColorObligatory()
        tdbg.Splits(2).DisplayColumns(COL_AppDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(2).DisplayColumns(COL_ApproverID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CandidateID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CandidateName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_RecPositionID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_RecPositionName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SexName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BirthDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ContactAddress).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Telephone).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Email).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_WorkName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DutyName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BeginDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_WorkingStatusName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_WorkingPlace).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_AppDate, COL_ApproverID, COL_AppDate}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT2, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)

    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbdPreparerID
        'LoadDataSource(tdbdApproverID, ReturnTableEmployeeID(True, False, gbUnicode), gbUnicode)

        'ID 76709 22/07/2015
        Using obj As Lemon3.Data.LoadData.LoadDataG4 = New Lemon3.Data.LoadData.LoadDataG4
            obj.LoadApprovalByG4(tdbdApproverID, "D25F2100")
        End Using
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""

        If _FormState = EnumFormState.FormAdd Then
            sSQL = SQLStoreD25P2100()
            dtGrid = ReturnDataTable(sSQL)
        Else
            dtGrid = ReturnTableFilter(dtD25F3060, "TransID=" & SQLString(_transID))
        End If
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim dr() As DataRow = dtGrid.Select("Approved = True Or NotApproved = True")
        If dr.Length <= 0 Then
            D99C0008.MsgL3(rl3("MSG000010"))
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_Approved
            tdbg.Bookmark = 0
            tdbg.Focus()
            Return False
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_Approved)) Then
                If tdbg(i, COL_AppDate).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ngay_duyet"))
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COL_AppDate
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If tdbg(i, COL_ApproverID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Nguoi_duyet"))
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COL_ApproverID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If

            If L3Bool(tdbg(i, COL_NotApproved)) Then
                If tdbg(i, COL_AppDate).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ngay_duyet"))
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COL_NotApproved
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If tdbg(i, COL_ApproverID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Nguoi_duyet"))
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COL_NotApproved
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()

        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False
        _bSaved = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLUpdateD25T2061s.ToString)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnClose.Focus()
            _bSaved = True
            _transID = tdbg.Columns(COL_TransID).Text
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnSave.Focus()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub VisibleBlock()
        Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
            tdbg.Splits(2).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(2).DisplayColumns.Item(COL_BlockName).Visible = False
        End If
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate

        Select Case e.ColIndex
            Case COL_ApproverID
                If tdbg.Columns(e.ColIndex).Text <> tdbdApproverID.Columns(tdbdApproverID.DisplayMember).Text Then
                    bNotInList = True
                End If
        End Select

    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.UpdateData()
        Select Case e.ColIndex
            Case COL_Approved
                If L3Bool(tdbg.Columns(COL_NotApproved).Value) Then
                    tdbg.Columns(COL_NotApproved).Value = 0
                End If
            Case COL_NotApproved
                If L3Bool(tdbg.Columns(COL_Approved).Value) Then
                    tdbg.Columns(COL_Approved).Value = 0
                End If
            Case COL_BeginDate, COL_Birthdate, COL_AppDate
                tdbg.Select()
        End Select
        FooterTotalGrid(tdbg, COL_CandidateName)
    End Sub

    Dim bSelect As Boolean = False

    Private Sub HeadClick(ByVal iCol As Integer)
        Select Case iCol
            Case COL_Approved
                L3HeadClick(tdbg, iCol, bSelect, COL_NotApproved, "False")
            Case COL_NotApproved
                L3HeadClick(tdbg, iCol, bSelect, COL_Approved, "False")
            Case COL_ApproverID, COL_AppDate
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case tdbg.Col
            Case COL_ApproverID
                Select Case e.KeyCode
                    Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                        tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoComplete = False
                    Case Else
                        tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoComplete = True
                End Select
        End Select

        Select Case e.KeyCode
            Case Keys.F7
                HotKeyF7(tdbg)
            Case Keys.F8
                HotKeyF8(tdbg)
            Case Keys.Enter
                If tdbg.Col = COL_ApproverID Then
                    HotKeyEnterGrid(tdbg, COL_Approved, e, SPLIT0)
                End If
        End Select
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
            Exit Sub
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
        HotKeyDownGrid(e, tdbg, COL_Approved, 0, 2)
    End Sub

    Private Sub btnShowOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowOption.Click
        If bLoadFormChild Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadFormChild = False
        End If

        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowOption.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2061s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/01/2011 04:10:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2061s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        Dim dt As DataTable = CType(tdbg.DataSource, DataTable)
        Dim dr() As DataRow = dt.Select("Approved = True Or NotApproved = True")
        If dr.Length > 0 Then
            For i As Integer = 0 To dr.Length - 1
                sSQL.Append("Update D25T2061 Set ")
                sSQL.Append("Approved = " & SQLNumber(dr(i).Item("Approved")) & COMMA) 'tinyint, NOT NULL
                sSQL.Append("NotApproved = " & SQLNumber(dr(i).Item("NotApproved")) & COMMA) 'tinyint, NOT NULL
                sSQL.Append("AppDate = " & SQLDateSave(dr(i).Item("AppDate").ToString) & COMMA) 'datetime, NOT NULL
                sSQL.Append("ApproverID = " & SQLString(dr(i).Item("ApproverID").ToString)) 'varchar[50], NOT NULL
                sSQL.Append(" Where TransID = " & SQLString(dr(i).Item("TransID").ToString) & " And CandidateID= " & SQLString(dr(i).Item("CandidateID").ToString))
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            Next
        End If

        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2100
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/01/2011 02:05:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2100() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2100 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
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
    '    'tdbg.WrapCellPointer = tdbg.RowCount > 0
    '    ResetGrid()
    'End Sub

    Private Sub ReLoadTDBGrid()
        dtGrid.AcceptChanges()
        Dim strFind As String = "" 'TH sFind="" và chkIsUsed.Checked =False
        If chkIsUsed.Checked Then
            strFind = "Approved=True or NotApproved=True"
        Else
            strFind = sFind
            If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
            strFind &= sFilter.ToString

            If strFind <> "" Then strFind = " Approved=True or NotApproved=True" & " Or " & strFind
        End If
        dtGrid.DefaultView.RowFilter = strFind.Replace("ApproverID", "ApproverName")

        ResetGrid()
    End Sub


    Private Sub ResetGrid()
        mnsFind.Enabled = (Not chkIsUsed.Checked) And (gbEnabledUseFind OrElse tdbg.RowCount > 0)
        mnsListAll.Enabled = mnsFind.Enabled
        FooterTotalGrid(tdbg, COL_CandidateName)
    End Sub


#Region "Active Find - List All (Client)"
    'Dim dtCaptionCols As DataTable

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


    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        dtGrid.AcceptChanges()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, , False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        ' End If
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), Me, "0", gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            'Case COL_AppDate, COL_ApproverID
            '    e.Handled = tdbg.FilterActive
            Case COL_Approved
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_NotApproved
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_ApproverID
                If tdbg.FilterActive = False Then
                    tdbg.Columns(COL_ApproverID).DropDown = tdbdApproverID
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoDropDown = True
                Else
                    tdbg.Columns(COL_ApproverID).DropDown = Nothing
                    tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoDropDown = False
                End If
        End Select
    End Sub

    Private Sub chkIsUsed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUsed.CheckedChanged

        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

End Class
