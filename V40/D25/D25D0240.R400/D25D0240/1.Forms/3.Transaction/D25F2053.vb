Imports System
Public Class D25F2053
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Dim dtTeamID As DataTable
    Public dtGrid As DataTable
    Dim bNotInList As Boolean = False
    Public bClose As Boolean = False

#Region "Const of tdbg"
    Private Const COL_Choose As Integer = 0           ' Chọn
    Private Const COL_TransID As Integer = 1          ' TransID
    Private Const COL_CandidateID As Integer = 2      ' Mã ứng viên
    Private Const COL_LastName As Integer = 3         ' LastName
    Private Const COL_MiddleName As Integer = 4       ' MiddleName
    Private Const COL_FirstName As Integer = 5        ' FirstName
    Private Const COL_CandidateName As Integer = 6    ' Tên ứng viên
    Private Const COL_DepartmentID As Integer = 7     ' Phòng ban
    Private Const COL_TeamID As Integer = 8           ' Tổ nhóm
    Private Const COL_PositionID As Integer = 9       ' Vị trí
    Private Const COL_MethodID As Integer = 10        ' MethodID
    Private Const COL_EmployeeID As Integer = 11      ' Mã NV
    Private Const COL_InterviewFileID As Integer = 12 ' InterviewFileID
    Private Const COL_DutyID As Integer = 13          ' DutyID
    Private Const COL_DutyName As Integer = 14        ' Tên chức vụ
    Private Const COL_DAGroupID As Integer = 15       ' Nhóm truy cập
    Private Const COL_DAGroupName As Integer = 16     ' DAGroupName
    Private Const COL_TeamName As Integer = 17        ' TeamName
    Private Const COL_DepartmentName As Integer = 18  ' DepartmentName
    Private Const COL_DateJoined As Integer = 19      ' DateJoined
#End Region

    Private _isOnlyView As Boolean
    Public WriteOnly Property IsOnlyView() As Boolean
        Set(ByVal Value As Boolean)
            _isOnlyView = Value
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

    Private _mode As Integer
    Public Property Mode() As Integer
        Get
            Return _mode
        End Get
        Set(ByVal Value As Integer)
            _mode = Value
        End Set
    End Property

    Private Sub D25F2053_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub


    Private Sub D25F2053_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Loadlanguage()
        'tdbg_LockedColumns()
        ResetSplitDividerSize(tdbg)
        SetBackColorObligatory()
        ResetColorGrid(tdbg)
        LoadTDBGrid()
        If _isOnlyView Then btnSave.Enabled = False

        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbg.Splits(0).DisplayColumns(COL_MethodID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    'Private Sub tdbg_LockedColumns()
    '    tdbg.Splits(SPLIT1).DisplayColumns(COL_CandidateID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    '    tdbg.Splits(SPLIT1).DisplayColumns(COL_CandidateName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    '    tdbg.Splits(SPLIT1).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    '    tdbg.Splits(SPLIT1).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    '    tdbg.Splits(SPLIT1).DisplayColumns(COL_PositionID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    'End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_Ho_so_nhan_vien_-_D25F2053") & UnicodeCaption(gbUnicode) 'CËp nhËt Hä s¥ nh¡n vi£n - D25F2053
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbdMethodID.Columns("MethodID").Caption = rl3("Ma") 'Mã
        tdbdMethodID.Columns("MethodName").Caption = rl3("Ten") 'Tên
        tdbdDAGroupID.Columns("DAGroupID").Caption = rl3("Ma") 'Mã
        tdbdDAGroupID.Columns("DAGroupName").Caption = rl3("Ten") 'Tên
        tdbdDutyID.Columns("DutyID").Caption = rl3("Ma") 'Mã
        tdbdDutyID.Columns("DutyName").Caption = rl3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbdDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("Choose").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("CandidateID").Caption = rl3("Ma_ung_vien") 'Mã ứng viên
        tdbg.Columns("CandidateName").Caption = rl3("Ten_ung_vien") 'Tên ứng viên
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("PositionID").Caption = rl3("Vi_tri") 'Vị trí
        tdbg.Columns("MethodID").Caption = rl3("Phuong_phap_tao_ma_tu_dong") 'Phuong_phap_tao_ma_tu_dong
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_NV") 'Mã NV
        tdbg.Columns("DutyName").Caption = rl3("Ten_chuc_vu") 'Tên chức vụ
        tdbg.Columns("DAGroupID").Caption = rl3("Nhom_truy_cap") 'Nhóm truy cập
    End Sub

    Private Sub LoadTDBGrid()
        dtGrid = ReturnDataTable(SQLStoreD25P2053)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
    End Sub

    Private sFind As String = ""
    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        'ResetGrid()
    End Sub

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()
        Dim sSQL As New StringBuilder

        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Select()
            Return False
        End If

        Dim bChecked As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_Choose)) = True Then
                bChecked = True
                Exit For
            End If
        Next i

        If Not bChecked Then
            D99C0008.MsgNotYetChoose(rl3("du_lieu_tren_luoi"))
            tdbg.Focus()
            Return False
        End If


        Return True
    End Function

    Dim sFilter As New System.Text.StringBuilder()
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

    'Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
    '    Me.Cursor = Cursors.WaitCursor
    '    'If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
    '    HotKeyCtrlVOnGrid(tdbg, e)
    '    Me.Cursor = Cursors.Default
    'End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    'Lưu ý: gọi hàm ResetFilter(tdbg, sFilter, bRefreshFilter) tại btnFilter_Click và tsbListAll_Click
    'Bổ sung vào đầu sự kiện tdbg_DoubleClick(nếu có) câu lệnh If tdbg.RowCount <= 0 OrElse tdbg.FilterActive Then Exit Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P2064s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 20/01/2009 02:22:05
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P2064() As String
        Dim sSQL As String
        sSQL = ""
        sSQL &= "Exec D09P2064 "
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA
        sSQL &= SQLString("D25")
        Return sSQL & vbCrLf
    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg.UpdateData()
        If Not AllowSave() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        _bSaved = False

        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD09T6666() & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s.ToString & vbCrLf)
        sSQL.Append(SQLStoreD25P2030() & vbCrLf)
    
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            bClose = True
            btnClose.Focus()
            dtGrid.DefaultView.RowFilter = "Choose<>1 and Choose<>True"
            dtGrid = dtGrid.DefaultView.ToTable
            dtGrid.DefaultView.RowFilter = ""
            ' LoadTDBGrid()
            ExecuteSQLNoTransaction(SQLDeleteD09T6666())
        Else
            SaveNotOK()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        'Select Case e.ColIndex
        '    Case COL_DepartmentID
        '        If tdbg.Columns(COL_DepartmentID).Text <> tdbdDepartmentID.Columns(0).Text Then
        '            tdbg.Columns(e.ColIndex).Text = ""
        '            tdbg.Columns(COL_TeamID).Text = ""
        '        End If

        '    Case COL_TeamID
        '        If tdbg.Columns(COL_TeamID).Text <> tdbdTeamID.Columns(0).Text Then
        '            tdbg.Columns(COL_TeamID).Text = ""
        '        End If

        '    Case COL_DutyID
        '        If tdbg.Columns(COL_DutyID).Text <> tdbdDutyID.Columns(0).Text Then
        '            tdbg.Columns(COL_DutyID).Text = ""
        '        End If

        '    Case COL_DAGroupID
        '        If tdbg.Columns(COL_DAGroupID).Text <> tdbdDAGroupID.Columns(1).Text Then
        '            bNotInList = True
        '        End If

        '    Case COL_MethodID
        '        If tdbg.Columns(COL_MethodID).Text <> tdbdMethodID.Columns(tdbdMethodID.DisplayMember).Text Then
        '            bNotInList = True
        '        End If
        'End Select
    End Sub

    Private Sub LoadTdbdTeamID(ByVal sDep As String)
        If sDep = "%" Then
            LoadDataSource(tdbdTeamID, dtTeamID.Copy, gbUnicode)
        Else
            LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID, "DepartmentID = " & SQLString(sDep) & " Or DepartmentID = '%'", True), gbUnicode)
        End If
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        'Select Case e.ColIndex
        '    Case COL_Choose
        '        If CBool(tdbg.Columns(e.ColIndex).Text) = True Then
        '            tdbg.Columns(COL_EmployeeID).Text = tdbg.Columns(COL_CandidateID).Text
        '        Else
        '            tdbg.Columns(COL_EmployeeID).Text = ""
        '        End If

        '    Case COL_DAGroupID
        '        If bNotInList Then tdbg.Columns(e.ColIndex).Text = "" : bNotInList = False

        '    Case COL_MethodID
        '        If bNotInList Then tdbg.Columns(e.ColIndex).Text = "" : bNotInList = False

        'End Select
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case e.ColIndex
            Case COL_EmployeeID
                If CBool(tdbg.Columns(COL_Choose).Text) = False Then
                    e.Cancel = True
                End If
        End Select

    End Sub

    'Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
    '    tdbg.Col = e.ColIndex
    '    Dim bCheck As Boolean = CBool(tdbg(0, COL_Choose))
    '    Select Case e.ColIndex
    '        Case COL_Choose
    '            For i As Integer = 0 To tdbg.RowCount - 1
    '                tdbg(i, COL_Choose) = Not bCheck
    '            Next i

    '        Case COL_DAGroupID, COL_MethodID
    '            CopyColumns(tdbg, tdbg.Col, tdbg.Columns(e.ColIndex).Text, tdbg.Row)

    '    End Select

    'End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_Choose
                L3HeadClick(tdbg, iCol, bSelect)
            Case COL_CandidateID, COL_CandidateName, COL_DepartmentID, COL_TeamID, COL_PositionID
                tdbg.AllowSort = False
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_TeamID
                '    LoadTdbdTeamID(tdbg.Columns(COL_DepartmentID).Text)
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_DepartmentID
                tdbg.Columns(COL_TeamID).Value = ""
                'tdbg.Columns(COL_TeamName).Value = ""

            Case COL_TeamName
                'tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns(0).Text

        End Select
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P2016
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 14/07/2010 09:55:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P2016(ByVal sMethodID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P2016 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(sMethodID) & COMMA 'MethodID, varchar[50], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2053
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 12/01/2011 03:10:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2053() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2053 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(_transID) & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(_mode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("D25F2053")
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2030s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 19/12/2008 10:33:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2030() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2030 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'InterviewFileID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString("") & COMMA 'DAGroupID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'DutyID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA 'Trans01ID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA
        sSQL &= SQLString(My.Computer.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: THANHHUYEN
    '# Created Date: 05/12/2012 10:15:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa  bang tam " & vbCrlf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name)
        sSQL &= " AND FormID = 'D25F2053'"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: THANHHUYEN
    '# Created Date: 05/12/2012 10:21:07
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert du lieu vao bang tam" & vbCrLf)
            If L3Bool(tdbg(i, COL_Choose)) Then
                sSQL.Append("Insert Into D09T6666(")
                sSQL.Append("UserID, HostID, Key01ID, FormID")
                sSQL.Append(") Values(" & vbCrLf)
                sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
                sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_CandidateID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
                sSQL.Append(SQLString("D25F2053")) 'FormID, varchar[20], NOT NULL
                sSQL.Append(")")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

End Class