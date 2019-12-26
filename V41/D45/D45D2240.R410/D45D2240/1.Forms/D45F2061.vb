Imports System
Imports System.Text

Public Class D45F2061
    Dim clsCheckValid As Lemon3.Controls.CheckEmptyControl
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private dtTeamID As DataTable
    Private dtDepartmentID As DataTable

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            LoadTDBCombo()

            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadAddNew()
                Case EnumFormState.FormEdit
                    LoadEdit()
                    btnCheck.Enabled = False
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    btnCheck.Enabled = True
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _AbsentVoucherID As String = ""
    Public Property AbsentVoucherID() As String
        Get
            Return _AbsentVoucherID
        End Get
        Set(ByVal Value As String)
            If _AbsentVoucherID = Value Then
                _AbsentVoucherID = ""
                Return
            End If
            _AbsentVoucherID = Value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F2021_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        End If
    End Sub
    Private Sub D13F2021_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        LoadLanguage()
        If D45Systems.IsUseBlock = False Then ReadOnlyControl(True, tdbcBlockID)
        clsCheckValid = New Lemon3.Controls.CheckEmptyControl(grpInfo, "D45F2060", "45")
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        InputDateCustomFormat(c1dateDateTo, c1dateDateFrom)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Thiet_lap_phieu_dieu_chinh_thu_nhap") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'ThiÕt lËp phiÕu ¢iÒu chÙnh thu nhËp
        '================================================================ 
        lblRemark.Text = rL3("Dien_giai") 'Diễn giải
        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        lblAttMode.Text = rL3("Phuong_phap") 'Phương pháp
        lblBlockID.Text = rL3("Khoi") 'Khối
        lblteDateFrom.Text = rL3("Thoi_gian") 'Thời gian
        '================================================================ 
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnCheck.Text = rL3("_Chi_tiet") '&Chi tiết
        '================================================================ 
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbcAttMode.Columns("AttMode").Caption = rL3("Ma") 'Mã
        tdbcAttMode.Columns("AttModeName").Caption = rL3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
    End Sub
    Private Sub SetBackColorObligatory()
        tdbcAttMode.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtRemark.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        dtTeamID = ReturnTableTeamID_D09P6868(gsDivisionID, "D45F2060", 0)
        dtDepartmentID = ReturnTableDepartmentID_D09P6868(gsDivisionID, "D45F2060", 0)

        'Load tdbcBlockID
        LoadtdbcBlockID_D09P6868(tdbcBlockID, gsDivisionID, "D45F2060", 0)

        ' Load tdbc AttMode
        sSQL = "-- Do nguon combo AttMode" & vbCrLf
        sSQL &= "SELECT ID as AttMode, Name as AttModeName FROM " & SQLUDFD45N5555()
        LoadDataSource(tdbcAttMode, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcAttMode"
    Private Sub tdbcAttMode_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAttMode.LostFocus
        If tdbcAttMode.FindStringExact(tdbcAttMode.Text) = -1 Then tdbcAttMode.Text = ""
    End Sub

#End Region

#Region "Events tdbcBlockID with txtBlockName load tdbcDepartmentID with txtDepartmentName"
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

        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ReturnValueC1Combo(tdbcBlockID), gsDivisionID, gbUnicode)
        tdbcDepartmentID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcDepartmentID with txtDepartmentName"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gsDivisionID, gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcTeamID with txtTeamName"
    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
        End If
    End Sub
#End Region
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAttMode.Close, tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub
    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAttMode.Validated, tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub LoadAddNew()
        btnCheck.Enabled = False
        LoadDefault()
    End Sub
    Private Sub LoadDefault()
        c1dateDateFrom.Value = Now.Date
        c1dateDateTo.Value = Now.Date
        tdbcBlockID.SelectedValue = "%"
    End Sub
    Private Sub LoadEdit()
        Dim sSQL As String = SQLStoreD45P2061()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                txtRemark.Text = .Item("Remark").ToString
                c1dateDateFrom.Value = SQLDateShow(.Item("DateFrom").ToString)
                c1dateDateTo.Value = SQLDateShow(.Item("DateTo").ToString)
                tdbcAttMode.SelectedValue = .Item("AttMode").ToString
                tdbcBlockID.SelectedValue = .Item("BlockID").ToString
                tdbcDepartmentID.SelectedValue = .Item("DepartmentID").ToString
                tdbcTeamID.SelectedValue = .Item("TeamID").ToString
            End With
        End If

        ReadOnlyControl(tdbcAttMode)
    End Sub

    Private Function AllowSave() As Boolean
        If txtRemark.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblRemark.Text)
            txtRemark.Focus()
            Return False
        End If
        If c1dateDateFrom.Text <> "" AndAlso c1dateDateTo.Text <> "" Then
            If Not CheckValidDateFromTo(c1dateDateFrom, c1dateDateTo) Then
                Return False
            End If
        End If
        If tdbcAttMode.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblAttMode.Text)
            tdbcAttMode.Focus()
            Return False
        End If
        If Not clsCheckValid.CheckEmpty() Then Return False
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblDepartmentID.Text)
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblTeamID.Text)
            tdbcTeamID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                'Sinh IGE cho khóa của Phiếu trước
                If _AbsentVoucherID = "" Then _AbsentVoucherID = CreateIGE("D45T2060", "AbsentVoucherID", "45", "AV", gsStringKey)
                sSQL.Append(SQLInsertD45T2060.ToString & vbCrLf)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T2060.ToString & vbCrLf)
        End Select
        If ReturnValueC1Combo(tdbcAttMode) = "0" Then sSQL.Append(SQLStoreD45P2063.ToString)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            btnCheck.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnCheck.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
        If clsCheckValid IsNot Nothing Then clsCheckValid.ResetValue()

    End Sub
    Private Sub btnCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnCheck.Focus()
        If btnCheck.Focused = False Then Exit Sub
        '************************************
        Dim sAttMode As String = ReturnValueC1Combo(tdbcAttMode).ToString
        If sAttMode = "0" Then
            Dim f As New D45F2062
            With f
                .AbsentVoucherID = _AbsentVoucherID
                .BlockID = ReturnValueC1Combo(tdbcBlockID)
                .DepartmentID = ReturnValueC1Combo(tdbcDepartmentID)
                .TeamID = ReturnValueC1Combo(tdbcTeamID)
                .Remark = txtRemark.Text
                If CheckStore(SQLStoreD45P5555("Kiem tra truoc khi xem chi tiet", 2)) = False OrElse _FormState = EnumFormState.FormView Then
                    .FormState = EnumFormState.FormView
                Else
                    .FormState = EnumFormState.FormEdit
                End If
                .ShowDialog()
                .Dispose()
            End With
        Else
            Dim f As New D45F2063
            With f
                .AttMode = sAttMode
                .AbsentVoucherID = _AbsentVoucherID
                .Remark = txtRemark.Text
                If CheckStore(SQLStoreD45P5555("Kiem tra truoc khi xem chi tiet", 2)) = False OrElse _FormState = EnumFormState.FormView Then
                    .FormState = EnumFormState.FormView
                Else
                    .FormState = EnumFormState.FormEdit
                End If
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUDFD45N5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/10/2016 02:19:17
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUDFD45N5555() As String
        Dim sSQL As String = ""
        sSQL &= "D45N5555("
        sSQL &= SQLString("D45F2060") & COMMA 'AttCoefUPID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Languge, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2061
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/10/2016 02:20:47
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2061() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load master" & vbCrLf)
        sSQL &= "Exec D45P2061 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D45F2060") & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(_AbsentVoucherID) 'AbsentVoucherID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2060
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/10/2016 02:47:37
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2060() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu AddNew" & vbCrlf)
        sSQL.Append("Insert Into D45T2060(")
        sSQL.Append("AttMode, DivisionID, AbsentVoucherID, TranMonth, TranYear, " & vbCrlf)
        sSQL.Append("BlockID, DepartmentID, TeamID, DateFrom, DateTo, " & vbCrlf)
        sSQL.Append("IsAutoAddEmp, RemarkU, CreateUserID, LastModifyUserID, CreateDate, " & vbCrlf)
        sSQL.Append("LastModifyDate")
        sSQL.Append(") Values(" & vbCrlf)
        sSQL.Append(SQLNumber(ReturnValueC1Combo(tdbcAttMode)) & COMMA) 'AttMode, tinyint, NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[50], NOT NULL
        sSQL.Append(SQLString(_AbsentVoucherID) & COMMA) 'AbsentVoucherID [KEY], varchar[50], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, int, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA & vbCrlf) 'TranYear, int, NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA) 'BlockID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'DepartmentID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'TeamID, varchar[50], NOT NULL
        sSQL.Append(SQLDateSave(c1dateDateFrom.Value) & COMMA & vbCrlf) 'DateFrom, datetime, NOT NULL
        sSQL.Append(SQLDateSave(c1dateDateTo.Value) & COMMA) 'DateTo, datetime, NOT NULL
        sSQL.Append(SQLNumber(IIf(ReturnValueC1Combo(tdbcAttMode) = "0", 1, 0)) & COMMA) 'IsAutoAddEmp, tinyint, NOT NULL
        sSQL.Append(SQLStringUnicode(txtRemark, True) & COMMA) 'RemarkU, nvarchar[2000], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA & vbCrlf) 'CreateUserID, varchar[50], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[50], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T2060
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/10/2016 02:50:34
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T2060() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu Edit" & vbCrlf)
        sSQL.Append("Update D45T2060 Set ")
        sSQL.Append("BlockID = " & SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("DepartmentID = " & SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("TeamID = " & SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("DateFrom = " & SQLDateSave(c1dateDateFrom.Value) & COMMA) 'datetime, NOT NULL
        sSQL.Append("DateTo = " & SQLDateSave(c1dateDateTo.Value) & COMMA) 'datetime, NOT NULL
        sSQL.Append("IsAutoAddEmp = " & SQLNumber(IIf(ReturnValueC1Combo(tdbcAttMode) = "0", 1, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("RemarkU = " & SQLStringUnicode(txtRemark, True) & COMMA) 'nvarchar[2000], NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NOT NULL
        sSQL.Append(" Where AbsentVoucherID =" & SQLString(_AbsentVoucherID))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2063
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/10/2016 02:51:56
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2063() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tu dong them nhan vien vao phieu dieu chinh thu nhap" & vbCrlf)
        sSQL &= "Exec D45P2063 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString("D45F2060") 'FormID, varchar[50], NOT NULL
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
        sSQL &= SQLString("D45F2060") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) 'Num01, int, NOT NULL
        Return sSQL
    End Function
End Class