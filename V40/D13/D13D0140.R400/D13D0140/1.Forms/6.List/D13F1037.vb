Imports System
Public Class D13F1037

    Private _payrollVoucherID As String = ""
    Public Property PayrollVoucherID() As String
        Get
            Return _payrollVoucherID
        End Get
        Set(ByVal Value As String)
            _payrollVoucherID = Value
        End Set
    End Property

    Private _payrollVoucherNo As String = ""
    Public Property PayrollVoucherNo() As String
        Get
            Return _payrollVoucherNo
        End Get
        Set(ByVal Value As String)
            _payrollVoucherNo = Value
        End Set
    End Property

    Private _voucherTypeID As String = ""
    Public Property VoucherTypeID() As String
        Get
            Return _voucherTypeID
        End Get
        Set(ByVal Value As String)
            _voucherTypeID = Value
        End Set
    End Property

    Private _voucherDate As String = ""
    Public Property VoucherDate() As String
        Get
            Return _voucherDate
        End Get
        Set(ByVal Value As String)
            _voucherDate = Value
        End Set
    End Property

    Private _description As String = ""
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal Value As String)
            _description = Value
        End Set
    End Property

    Private _createUserID As String = ""
    Public Property CreateUserID() As String
        Get
            Return _createUserID
        End Get
        Set(ByVal Value As String)
            _createUserID = Value
        End Set
    End Property

    Private _lastModifyUserID As String = ""
    Public Property LastModifyUserID() As String
        Get
            Return _lastModifyUserID
        End Get
        Set(ByVal Value As String)
            _lastModifyUserID = Value
        End Set
    End Property

    Private _isChoose As Boolean = False
    Public Property IsChoose() As Boolean
        Get
            Return _isChoose
        End Get
        Set(ByVal Value As Boolean)
            _isChoose = Value
        End Set
    End Property

    Private Sub D13F1032_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        LoadTDBCombo()
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_ho_so_luong") & UnicodeCaption(gbUnicode) 'Chãn hä s¥ l§¥ng
        '================================================================ 
        lblPayrollVoucherID.Text = rl3("Ho_so_luong") 'Hồ sơ lương
        '================================================================ 
        btnChoose.Text = rl3("Chon") 'Chọn
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcPayrollVoucherID.Columns("PayrollVoucherNo").Caption = rl3("Ma") 'Mã
        tdbcPayrollVoucherID.Columns("Description").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcPayrollVoucherID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcPayrollVoucherID
        sSQL = "Select PayrollVoucherID, PayrollVoucherNo, Description" & UnicodeJoin(gbUnicode) & " as Description, VoucherTypeID, VoucherDate, CreateUserID, LastModifyUserID From D13T0100  WITH (NOLOCK) "
        sSQL &= "Where 	 DivisionID = " & SQLString(gsDivisionID)
        sSQL &= "And TranMonth = " & SQLString(giTranMonth)
        sSQL &= "And TranYear = " & SQLString(giTranYear)
        sSQL &= "Order By    PayrollVoucherNo"
        LoadDataSource(tdbcPayrollVoucherID, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcPayrollVoucherID with txtPayrollVoucherName"

    Private Sub tdbcPayrollVoucherID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPayrollVoucherID.Close
        If tdbcPayrollVoucherID.FindStringExact(tdbcPayrollVoucherID.Text) = -1 Then
            tdbcPayrollVoucherID.Text = ""
            txtPayrollVoucherName.Text = ""
        End If
    End Sub

    Private Sub tdbcPayrollVoucherID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPayrollVoucherID.SelectedValueChanged
        txtPayrollVoucherName.Text = tdbcPayrollVoucherID.Columns("Description").Value.ToString
    End Sub

    Private Sub tdbcPayrollVoucherID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPayrollVoucherID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcPayrollVoucherID.Text = ""
            txtPayrollVoucherName.Text = ""
        End If
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        If Not AllowChoose() Then Exit Sub
        _payrollVoucherID = tdbcPayrollVoucherID.Columns("PayrollVoucherID").Text
        _payrollVoucherNo = tdbcPayrollVoucherID.Columns("PayrollVoucherNo").Text
        _voucherTypeID = tdbcPayrollVoucherID.Columns("VoucherTypeID").Text
        _voucherDate = tdbcPayrollVoucherID.Columns("VoucherDate").Text
        _description = tdbcPayrollVoucherID.Columns("Description").Text
        _createUserID = tdbcPayrollVoucherID.Columns("CreateUserID").Text
        _lastModifyUserID = tdbcPayrollVoucherID.Columns("LastModifyUserID").Text
        _isChoose = True
        Me.Close()
    End Sub

    Private Function AllowChoose() As Boolean
        If tdbcPayrollVoucherID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose("Hồ sơ lương")
            tdbcPayrollVoucherID.Focus()
            Return False
        End If
        Return True
    End Function

End Class