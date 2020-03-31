Imports System
Public Class D25F2061

#Region "Const of tdbg"
    Private Const COL_Chosen As Integer = 0        ' Chọn
    Private Const COL_DepartmentID As Integer = 1  ' Phòng ban
    Private Const COL_TeamID As Integer = 2        ' Tổ nhóm
    Private Const COL_PositionID As Integer = 3    ' Vị trí
    Private Const COL_CandidateID As Integer = 4   ' Mã nhân viên
    Private Const COL_CandidateName As Integer = 5 ' Tên nhân viên
    Private Const COL_BirthDate As Integer = 6     ' Ngày sinh
    Private Const COL_BirthPlace As Integer = 7    ' Nơi sinh
    Private Const COL_SexName As Integer = 8       ' Giới tính
#End Region

    Dim dtTeamID, dtPositionID As DataTable

    Dim bChooseHeadClick As Boolean = False
    'Dim bChooseSuccessfully As Boolean
    Private _decisionID As String
    Public WriteOnly Property DecisionID() As String
        Set(ByVal Value As String)
            _decisionID = Value
        End Set
    End Property

    Private _bChooseSuccessfully As Boolean
    Public ReadOnly Property bChooseSuccessfully() As Boolean
        Get
            Return _bChooseSuccessfully
        End Get
    End Property

    Private Sub D25F2061_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If D25Options.UseEnterAsTab Then
            If e.KeyChar = Chr(13) Then
                Me.ProcessTabKey(True)
            End If
        End If
    End Sub

    Private Sub D25F2061_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        SetBackColorObligatory()
        tdbg_LockedColumns()
        createdtTeam()
        LoadTDBCombo()
        SetDefault()
        btnChoose.Enabled = tdbg.RowCount > 0
        InputbyUnicode(Me, gbUnicode)
        InputDateInTrueDBGrid(tdbg, COL_BirthDate)

        SetResolutionForm(Me)
    End Sub

    Private Sub LoadTDBCombo()
        'Dim sSQL As String = ""
        ''Load tdbcDeparmentID
        'sSQL = "Select DepartmentID, DepartmentName From D91T0012 Where Disabled=0 And DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        'sSQL &= "UNION Select '%' As DepartmentID, 'Taát caû' As DepartmentName ORDER BY DepartmentID"
        'LoadDataSource(tdbcDepartmentID, sSQL)

        ''Load tdbcPositionID
        'sSQL = "Select RecPositionID, RecPositionName From D25T1020 Where Disabled=0" & vbCrLf
        'sSQL &= "Union Select '%' As RecPositionID, 'Taát caû' As RecPositionName" & vbCrLf
        'sSQL &= "ORDER BY RecPositionName"
        'LoadDataSource(tdbcPositionID, sSQL)

        'Load tdbcDepartmentID
        LoadDataSource(tdbcDepartmentID, ReturnTableDepartmentID(True, , gbUnicode), gbUnicode)

        'Load tdbcTeamID
        dtTeamID = ReturnTableTeamID(True, , gbUnicode)

        'Load tdbcPositionID
        LoadDataSource(tdbcPositionID, ReturnTableDutyIDRec(, gbUnicode), gbUnicode)
    End Sub

    Private Sub LoadtdbcTeamID(ByVal ID As String)
        'Load tdbcTeamID
        If ID = "%" Then
            LoadDataSource(tdbcTeamID, dtTeamID.Copy, gbUnicode)
        Else
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID=" & SQLString(ID) & " or TeamID = '%'", True), gbUnicode)
        End If
    End Sub

    Private Sub createdtTeam()
        Dim sSQL As String = ""
        sSQL = "Select 1 as DisplayOrder, D01.TeamID, D01.TeamName, D01.DepartmentID From D09T0227 D01 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Inner Join D91T0012 D02 WITH(NOLOCK)  On D01.DepartmentID=D02.DepartmentID" & vbCrLf
        sSQL &= "Where D01.Disabled=0 And DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Union Select 0 as DisplayOrder,'%' As TeamID, 'Taát caû' As TeamName, '%' As DepartmentID" & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, D01.TeamID"
        dtTeamID = ReturnDataTable(sSQL)
    End Sub

#Region "Events tdbcDepartmentID with txtDeparmentName load tdbcTeamID with txtTeamName"

    Private Sub tdbcDepartmentID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Close
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
            txtDeparmentName.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not (tdbcDepartmentID.Tag Is Nothing OrElse tdbcDepartmentID.Tag.ToString = "") Then
            tdbcDepartmentID.Tag = ""
            Exit Sub
        End If
        If tdbcDepartmentID.SelectedValue Is Nothing Then
            LoadtdbcTeamID("-1")
            Exit Sub
        End If
        txtDeparmentName.Text = tdbcDepartmentID.Columns(1).Text
        LoadtdbcTeamID(ReturnValueC1Combo(tdbcDepartmentID))
        tdbcTeamID.SelectedValue = "%"
        'txtTeamName.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDepartmentID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcDepartmentID.Text = ""
            txtDeparmentName.Text = ""
        End If
    End Sub

    Private Sub tdbcTeamID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.Close
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
            txtTeamName.Text = ""
        End If
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        txtTeamName.Text = tdbcTeamID.Columns(1).Value.ToString()
    End Sub

    Private Sub tdbcTeamID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcTeamID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcTeamID.Text = ""
            txtTeamName.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcPositionID with txtPositionName"

    Private Sub tdbcPositionID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPositionID.Close
        If tdbcPositionID.FindStringExact(tdbcPositionID.Text) = -1 Then
            tdbcPositionID.Text = ""
            txtPositionName.Text = ""
        End If
    End Sub

    Private Sub tdbcPositionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPositionID.SelectedValueChanged
        txtPositionName.Text = tdbcPositionID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcPositionID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPositionID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcPositionID.Text = ""
            txtPositionName.Text = ""
        End If
    End Sub

#End Region

    Private Sub SetDefault()
        tdbcDepartmentID.SelectedValue = "%"
        tdbcTeamID.SelectedValue = "%"
        tdbcPositionID.SelectedValue = "%"
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: Phan Vĩnh Lộc
    '# Created Date: 11/12/2008 11:49:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D91T9009"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009s
    '# Created User: Phan Vĩnh Lộc
    '# Created Date: 11/12/2008 11:49:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_Chosen)) Then
                sSQL.Append("Insert Into D91T9009(")
                sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, ")
                sSQL.Append("Key04ID, Key05ID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
                sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_CandidateID)) & COMMA) 'Key01ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'Key02ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'Key03ID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_PositionID)) & COMMA) 'Key04ID, varchar[20], NOT NULL
                sSQL.Append(SQLString("")) 'Key05ID, varchar[20], NOT NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case tdbg.Col
            Case COL_Chosen
                Dim bcheck As Boolean = Not bChooseHeadClick
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, COL_Chosen) = bcheck
                Next
                bChooseHeadClick = bcheck
        End Select
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_ung_vien_-_D25F2061") & UnicodeCaption(gbUnicode)  'Chãn ÷ng vi£n - D25F2061
        '================================================================ 
        lblDeparmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblPositionID.Text = rl3("Vi_tri") 'Vị trí
        '================================================================ 
        btnFilter.Text = rl3("_Loc") '&Lọc
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnChoose.Text = rl3("_Chon") '&Chọn
        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("Chosen").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("PositionID").Caption = rl3("Vi_tri") 'Vị trí
        tdbg.Columns("CandidateID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("CandidateName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbg.Columns("BirthDate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("BirthPlace").Caption = rl3("Noi_sinh") 'Nơi sinh
        tdbg.Columns("SexName").Caption = rl3("Gioi_tinh") 'Giới tính
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowChoose() Then Exit Sub
        LoadDataSource(tdbg, SQLStoreD25P2061(), gbUnicode)
        btnChoose.Enabled = tdbg.RowCount > 0
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        Dim bHasChosen As Boolean
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_Chosen)) Then
                bHasChosen = True
            End If
        Next

        If Not bHasChosen Then
            D99C0008.MsgNotYetChoose(rl3("Tren_luoi"))
            Exit Sub
        End If

        Dim sSQL As String = ""
        sSQL = SQLDeleteD91T9009() & vbCrLf
        sSQL &= SQLInsertD91T9009s().ToString
        Dim bRun As Boolean = ExecuteSQL(sSQL)
        If bRun Then
            _bChooseSuccessfully = True
            Me.Close()
        Else
            D99C0008.MsgSaveNotOK()
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2061
    '# Created User: Phan Vĩnh Lộc
    '# Created Date: 11/12/2008 02:08:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2061() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2061 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcDepartmentID.Text) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcTeamID.Text) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcPositionID.Text) & COMMA 'PositionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_decisionID) & COMMA 'DecisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Function AllowChoose() As Boolean
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        If tdbcPositionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Vi_tri"))
            tdbcPositionID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PositionID).Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PositionID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CandidateID).Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CandidateID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CandidateName).Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CandidateName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BirthDate).Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BirthDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BirthPlace).Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BirthPlace).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_SexName).Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_SexName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPositionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
End Class