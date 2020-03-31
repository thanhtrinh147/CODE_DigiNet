'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:33:29 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:33:29 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F2015
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Private _newPayrollVoucherID As String = ""
    Private _newTranmonth As Integer = 0
    Private _newTranyear As Integer = 0
    Private _columnName As String = ""
    Private dtPayroll As DataTable

    Public Property NewPayrollVoucherID() As String
        Get
            Return _newPayrollVoucherID
        End Get
        Set(ByVal value As String)
            If NewPayrollVoucherID = value Then
                _newPayrollVoucherID = ""
                Return
            End If
            _newPayrollVoucherID = value
        End Set
    End Property
    Public Property NewTranmonth() As Integer
        Get
            Return _newTranmonth
        End Get
        Set(ByVal value As Integer)
            If NewTranmonth = value Then
                _newTranmonth = 0
                Return
            End If
            _newTranmonth = value
        End Set
    End Property
    Public Property NewTranyear() As Integer
        Get
            Return _newTranyear
        End Get
        Set(ByVal value As Integer)
            If NewTranyear = value Then
                _newTranyear = 0
                Return
            End If
            _newTranyear = value
        End Set
    End Property
    Public Property ColumnName() As String
        Get
            Return _columnName
        End Get
        Set(ByVal value As String)
            If ColumnName = value Then
                _columnName = ""
                Return
            End If
            _columnName = value
        End Set
    End Property
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcMonthYear
        sSQL = "Select (Right(('0'+RTrim(LTrim(str(TranMonth)))),2)+ '/'+LTrim(str(TranYear))) As MonthYear ,TranMonth as OldTranmonth,TranYear as OldTranyear " & vbCrLf
        sSQL &= "From D09T9999  WITH (NOLOCK) Where DivisionID = " & SQLString(gsDivisionID) & " Order By OldTranyear DESC, OldTranmonth DESC "
        LoadDataSource(tdbcMonthYear, sSQL, gbUnicode)

        'LoadtdbcPayrollVoucherNo
        sSQL = "Select PayrollVoucherID as OldPayrollVoucherID, PayrollVoucherNo, Description" & UnicodeJoin(gbUnicode) & " as Description, TranMonth, TranYear " & vbCrLf
        sSQL &= "From D13T0100  WITH (NOLOCK) Where PayrollVoucherID <> " & SQLString(_newPayrollVoucherID) & vbCrLf
        sSQL &= "Order By VoucherDate"
        dtPayroll = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadtdbcPayrollVoucherNo(ByVal ID As String)
        Dim sSQL As String = ""
        Dim iMonth As Int32 = 0
        Dim iYear As Int32 = 0

        If ID <> "" And ID <> "-1" Then
            iMonth = CInt(ID.Substring(0, 2))
            iYear = CInt(ID.Substring(3))
        End If
        LoadDataSource(tdbcPayrollVoucherNo, ReturnTableFilter(dtPayroll, " TranMonth = " & iMonth & " and TranYear = " & iYear), gbUnicode)
    End Sub

    Private Sub optMode1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optMode1.Click
        tdbcMonthYear.Enabled = True
        tdbcPayrollVoucherNo.Enabled = True
        tdbcMonthYear.AutoSelect = True
    End Sub

    Private Sub D13F2015_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        End If
    End Sub

    Private Sub D13F2015_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        LoadTDBCombo()
        cboDecimal.Text = "0"
        CheckIdTextBox(txtFormular, 1000, True)
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ke_thua_du_lieu_-_D13F2015") & UnicodeCaption(gbUnicode) 'KÕ thôa dö liÖu - D13F2015
        '================================================================ 
        lblMonthYear.Text = rl3("Ky_ke_toan") 'Kỳ kế toán
        lblFormular.Text = rl3("Cong_thuc") 'Công thức
        lblDecimal.Text = rl3("Lam_tron") 'Làm tròn
        lblOldPayrollVoucherID.Text = rl3("Ho_so_luong") 'Hồ sơ lương
        '================================================================ 
        btnInherit.Text = rl3("_Ke_thua") '&Kế thừa
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        optMode1.Text = rl3("Ho_so_luong") 'Hồ sơ lương
        optMode0.Text = rl3("Muc_do_tham_nien") 'Mức độ thâm niên
        '================================================================ 
        grp1.Text = rl3("Thong_so_ke_thua") 'Thông số kế thừa
        '================================================================ 

        tdbcPayrollVoucherNo.Columns("PayrollVoucherNo").Caption = rl3("Ma") 'Mã
        tdbcPayrollVoucherNo.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcMonthYear.Columns("MonthYear").Caption = rl3("Ky_ke_toan") 'Kỳ kế toán
    End Sub

    Private Sub optMode0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optMode0.Click
        tdbcMonthYear.Text = ""
        tdbcPayrollVoucherNo.Text = ""
        tdbcMonthYear.Enabled = False
        tdbcPayrollVoucherNo.Enabled = False
    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2030
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 27/02/2007 02:09:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2030() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2030 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        If optMode0.Checked Then
            sSQL &= SQLNumber("0") & COMMA 'Mode, int, NOT NULL
        Else
            sSQL &= SQLNumber("1") & COMMA 'Mode, int, NOT NULL
        End If
        sSQL &= SQLNumber(tdbcMonthYear.Columns("OldTranMonth").Value) & COMMA 'OldTranmonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcMonthYear.Columns("OldTranYear").Value) & COMMA 'OldTranyear, int, NOT NULL
        sSQL &= SQLString(tdbcPayrollVoucherNo.Columns("OldPayrollVoucherID").Value) & COMMA 'OldPayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(_newTranmonth) & COMMA 'NewTranmonth, int, NOT NULL
        sSQL &= SQLNumber(_newTranyear) & COMMA 'NewTranyear, int, NOT NULL
        sSQL &= SQLString(_newPayrollVoucherID) & COMMA 'NewPayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(_columnName) & COMMA 'ColumnName, varchar[20], NOT NULL
        sSQL &= SQLString(txtFormular.Text) & COMMA 'Formular, varchar[1000], NOT NULL
        sSQL &= SQLNumber(cboDecimal.Text) 'Decimal, int, NOT NULL
        Return sSQL
    End Function

    Private Sub btnInherit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInherit.Click
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        _bSaved = False
        btnInherit.Enabled = False
        btnClose.Enabled = False

        sSQL &= SQLStoreD13P2030()
        Me.Cursor = Cursors.WaitCursor
        Dim bResult As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bResult = True Then
            D99C0008.MsgL3(rl3("Du_lieu_da_duoc_ke_thua_thanh_cong"))
            _bSaved = True
            btnInherit.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            D99C0008.MsgL3(rl3("Du_lieu_ke_thua_that_bai"))
            btnInherit.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub
    Private Function AllowSave() As Boolean
        If optMode1.Checked Then
            If tdbcMonthYear.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky_ke_toan"))
                tdbcMonthYear.Focus()
                Return False
            End If
            If tdbcPayrollVoucherNo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rL3("Ho_so_luong"))
                tdbcPayrollVoucherNo.Focus()
                Return False
            End If
        End If
        If txtFormular.Text.Trim <> "" Then
            If txtFormular.TextLength > 2000 Then
                D99C0008.MsgL3(rL3("Do_dai_Cong_thuc_khong_duoc_vuot_qua_2000_ky_tu"))
                txtFormular.Focus()
                Return False
            End If
        End If
        Return True
    End Function

#Region "Events tdbcMonthYear load tdbcOldPayrollVoucherID"

    Private Sub tdbcMonthYear_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMonthYear.Close
        If tdbcMonthYear.FindStringExact(tdbcMonthYear.Text) = -1 Then tdbcMonthYear.Text = ""
    End Sub

    Private Sub tdbcMonthYear_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMonthYear.SelectedValueChanged
        If Not (tdbcMonthYear.Tag Is Nothing OrElse tdbcMonthYear.Tag.ToString = "") Then
            tdbcMonthYear.Tag = ""
            Exit Sub
        End If
        If tdbcMonthYear.SelectedValue Is Nothing Then
            LoadtdbcPayrollVoucherNo("-1")
            Exit Sub
        End If
        LoadtdbcPayrollVoucherNo(tdbcMonthYear.Text)
        tdbcPayrollVoucherNo.AutoSelect = True
    End Sub

    'Private Sub tdbcMonthYear_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcMonthYear.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcMonthYear.Text = ""
    'End Sub

    Private Sub tdbcOldPayrollVoucherID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPayrollVoucherNo.Close
        If tdbcPayrollVoucherNo.FindStringExact(tdbcPayrollVoucherNo.Text) = -1 Then tdbcPayrollVoucherNo.Text = ""
    End Sub

    'Private Sub tdbcOldPayrollVoucherID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPayrollVoucherNo.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPayrollVoucherNo.Text = ""
    'End Sub
    
#End Region

    Private Sub SetBackColorObligatory()
        tdbcMonthYear.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPayrollVoucherNo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        cboDecimal.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
End Class