Imports System
Public Class FrameUpdateSalary

    Private _formID As String = ""
    Public WriteOnly Property FormID() As String
        Set(ByVal Value As String)
            _formID = Value
        End Set
    End Property

    Private _employeeID As String = ""
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private Sub FramSalary_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ExecuteSQLNoTransaction(SQLDeleteD09T6666.ToString)
    End Sub

    Private Sub FramSalary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub FramSalary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadlanguage()
        SetBackColorObligatory()
        LoadTDBCombo()
        '**********************************************
        InputbyUnicode(Me, gbUnicode)
        '**********************************************
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        Me.Text = rl3("Cap_nhat_ho_so_luong_thangF") & UnicodeCaption(gbUnicode) 'CËp nhËt hä s¥ l§¥ng thÀng
        '**********************************************
        lblPayrollVoucherID.Text = rl3("Ho_so_luong") 'Hồ sơ lương
        '**********************************************
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '**********************************************
        tdbcPayrollVoucherID.Columns("PayrollVoucherID").Caption = rl3("Ma") 'Mã 
        tdbcPayrollVoucherID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải 
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcPayrollVoucherID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcPayrollVoucherID
        sSQL = "--- Do nguon cho combo Ho so luong" & vbCrLf
        sSQL &= "SELECT PayrollVoucherID, PayrollVoucherNo, Description" & UnicodeJoin(gbUnicode) & " AS Description" & vbCrLf
        sSQL &= "FROM D13T0100" & vbCrLf
        sSQL &= "WHERE DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " AND TranMonth = " & giTranMonth & " AND TranYear = " & giTranYear
        LoadDataSource(tdbcPayrollVoucherID, sSQL, gbUnicode)
    End Sub


#Region "Events tdbcPayrollVoucherID with txtPayrollVoucherName"

    Private Sub tdbcPayrollVoucherID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPayrollVoucherID.SelectedValueChanged
        If tdbcPayrollVoucherID.SelectedValue Is Nothing Then
            txtPayrollVoucherName.Text = ""
        Else
            txtPayrollVoucherName.Text = tdbcPayrollVoucherID.Columns("Description").Value.ToString
        End If
    End Sub

    Private Sub tdbcPayrollVoucherID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPayrollVoucherID.LostFocus
        If tdbcPayrollVoucherID.FindStringExact(tdbcPayrollVoucherID.Text) = -1 Then
            tdbcPayrollVoucherID.Text = ""
        End If
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcPayrollVoucherID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ho_so_luong"))
            tdbcPayrollVoucherID.Focus()
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
        sSQL.Append(SQLStoreD13P0101.ToString)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 02/04/2013 10:40:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam" & vbCrlf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID = " & SQLString(gsUserID) & " AND HostID = " & SQLString(My.Computer.Name) & " AND FormID = " & SQLString(_formID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0101
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 02/04/2013 11:27:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0101() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Luu du lieu" & vbCrlf)
        sSQL &= "Exec D13P0101 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcPayrollVoucherID).ToString) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(_formID) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) 'EmployeeID, varchar[20], NOT NULL
        Return sSQL
    End Function
End Class