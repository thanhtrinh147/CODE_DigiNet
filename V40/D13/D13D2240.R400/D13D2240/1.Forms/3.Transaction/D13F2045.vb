Imports System.Xml
Imports System
Public Class D13F2045
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _salaryVoucherID As String = ""
    Public WriteOnly Property SalaryVoucherID() As String
        Set(ByVal Value As String)
            _salaryVoucherID = Value
        End Set
    End Property
    Private _employeeID As String
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property
    Private _bankID As String
    Public WriteOnly Property  BankID() As String
        Set(ByVal Value As String)
            _bankID = Value
        End Set
    End Property
    Private _mode As Integer
    Public WriteOnly Property Mode() As Integer
        Set(ByVal Value As Integer)
            _mode = Value
        End Set
    End Property
    Private _bankAccountNo As String
    Public WriteOnly Property  BankAccountNo() As String
        Set(ByVal Value As String)
            _bankAccountNo = Value
        End Set
    End Property
    Private Sub CallMode()
        If _mode = 0 Then
            lblEmployeeID.Visible = False
            txtEmployeeID.Visible = False
            'Panel1.Top = 5
            Me.Height = 95
            btnUpdate.Top = lblBankID.Top
            btnClose.Top = lblBankID.Top
            lblBankID.Top = txtEmployeeID.Top
            tdbcBankID.Top = txtEmployeeID.Top
            tdbcBankID.Focus()
        Else
            lblEmployeeID.Visible = True
            txtEmployeeID.Visible = True
            txtEmployeeID.Text = _employeeID
            txtBankAccountNo.Text = _bankAccountNo
            tdbcBankID.SelectedValue = _bankID
            txtEmployeeID.Focus()
        End If
    End Sub
    Private Sub D13P2045_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        LoadTDBCombo()
        CallMode()
        SetBackColorObligatory()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D13P2045_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
        End Select
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_ngan_hang_chuyen_khoan") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'CËp nhËt ng¡n hªng chuyÓn kho¶n - D13F2045
        '================================================================ 
        lblBankID.Text = rl3("Ngan_hang") 'Ngân hàng
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnUpdate.Text = rl3("_Cap_nhat") '&Cập nhật
        '================================================================ 
        tdbcBankID.Columns("BankID").Caption = rl3("Ma") 'Mã
        tdbcBankID.Columns("BankName").Caption = rL3("Ten") 'Tên
        lblEmployeeID.Text = rL3("Ma") 'Mã
        '================================================================ 
        lblBankAccountNo.Text = rL3("So_tai_khoan") 'Số tài khoản
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcBankID
        sSQL = "Select ObjectID BankID, ObjectName" & UnicodeJoin(gbUnicode) & " BankName, BranchName" & UnicodeJoin(gbUnicode) & " as BranchName From Object  WITH(NOLOCK) Where Disabled=0 And ObjectTypeID='NH' Order by ObjectID "
        LoadDataSource(tdbcBankID, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcBankID"

    Private Sub tdbcBankID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBankID.LostFocus
        If tdbcBankID.FindStringExact(tdbcBankID.Text) = -1 Then tdbcBankID.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBankID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBankID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Function AllowUpdate() As Boolean
        If tdbcBankID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ngan_hang"))
            tdbcBankID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcBankID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnUpdate.Focus()
        If btnUpdate.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowUpdate() Then Exit Sub

        btnUpdate.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLStoreD13P2045)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            btnUpdate.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLStoreD13P2045
    ''# Created User: Hoàng Nhân
    ''# Created Date: 14/08/2013 10:56:08
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: 
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD13P2045() As String
    '    Dim sSQL As String = ""
    '    sSQL &= ("-- Cap nhat ngan hang chuyen khoan theo ngan hang da chon" & vbCrlf)
    '    sSQL &= "Exec D13P2045 "
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
    '    sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
    '    sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
    '    sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[50], NOT NULL
    '    sSQL &= SQLString(ReturnValueC1Combo(tdbcBankID).ToString)  & COMMA  'BankID, varchar[50], NOT NULL
    '    Return sSQL
    'End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2045
    '# Created User: Lê Anh Vũ
    '# Created Date: 11/09/2014 02:55:27
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2045() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Cap nhat ngan hang chuyen khoan theo ngan hang da chon" & vbCrlf)
        sSQL &= "Exec D13P2045 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBankID).ToString) & COMMA 'BankID, varchar[50], NOT NULL
        sSQL &= SQLNumber(_mode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[50], NOT NULL
        sSQL &= SQLString(txtBankAccountNo.Text.Trim)  'BankAccountNo, varchar[50], NOT NULL
        Return sSQL
    End Function

End Class