Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 25/05/2007 2:27:19 PM
'# Created User: Nguyễn Lê Phương
'# Modify Date: 25/05/2007 2:27:19 PM
'# Modify User: Nguyễn Lê Phương
'#-------------------------------------------------------------------------------------
Public Class D45F1025
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
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
                    txtOldPriceListID.Text = _OldPriceListID
                Case EnumFormState.FormEdit

                Case EnumFormState.FormView
            End Select
        End Set
    End Property

    Private _oldPriceListID As String = ""
    Public WriteOnly Property OldPriceListID() As String
        Set(ByVal Value As String)
            _oldPriceListID = Value
        End Set
    End Property


    Private Sub SetBackColorObligatory()
        txtNewPriceListID.BackColor = COLOR_BACKCOLOROBLIGATORY
        If optValue.Checked Then
            cboSign1.BackColor = COLOR_BACKCOLOROBLIGATORY
            txtValue1.BackColor = COLOR_BACKCOLOROBLIGATORY
        Else
            cboSign2.BackColor = COLOR_BACKCOLOROBLIGATORY
            txtValue2.BackColor = COLOR_BACKCOLOROBLIGATORY
        End If
    End Sub

    Private Sub D45F1025_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D45F1025_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        SetBackColorObligatory()
        cboSign1.Text = "+"
        cboSign2.Text = "+"
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtNewPriceListID)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ke_thua_bang_gia_-_D45F1025") & UnicodeCaption(gbUnicode) 'KÕ thôa b¶ng giÀ - D45F1025
        '================================================================ 
        lblMethod.Text = rl3("Phuong_thuc_ke_thua") 'Phương thức kế thừa
        lblNewPriceListID.Text = rl3("Ma_bang_gia_moi") 'Mã bảng giá mới
        lblOldPriceListID.Text = rl3("Ma_bang__gia_ke_thua") 'Mã bảng  giá kế thừa
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        optPercent.Text = rl3("Theo_ty_le_phan_tram") 'Theo tỷ lệ phần trăm
        optValue.Text = rl3("Theo_gia_tri_tuyet_doi") 'Theo giá trị tuyệt đối
        '================================================================         
    End Sub

    Private Function AllowSave() As Boolean
        If txtNewPriceListID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_bang_gia_moi"))
            txtNewPriceListID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D45T1020", "PriceListID", txtNewPriceListID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtNewPriceListID.Focus()
                Return False
            End If
        End If
        If optValue.Checked Then
            If cboSign1.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dau"))
                cboSign1.Focus()
                Return False
            End If
            If txtValue1.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Gia_tri_"))
                txtValue1.Focus()
                Return False
            End If
        Else
            If cboSign2.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dau"))
                cboSign2.Focus()
                Return False
            End If
            If txtValue2.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Gia_tri_"))
                txtValue2.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub optValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optValue.CheckedChanged
        If optValue.Checked Then
            cboSign1.BackColor = COLOR_BACKCOLOROBLIGATORY
            txtValue1.BackColor = COLOR_BACKCOLOROBLIGATORY
            cboSign2.BackColor = Color.White
            txtValue2.BackColor = Color.White
            cboSign1.Enabled = True
            txtValue1.Enabled = True
            cboSign2.Enabled = False
            txtValue2.Enabled = False
        Else
            cboSign1.BackColor = Color.White
            txtValue1.BackColor = Color.White
            cboSign2.BackColor = COLOR_BACKCOLOROBLIGATORY
            txtValue2.BackColor = COLOR_BACKCOLOROBLIGATORY
            cboSign1.Enabled = False
            txtValue1.Enabled = False
            cboSign2.Enabled = True
            txtValue2.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False
        _bSaved = False

        Dim sSQL As New StringBuilder("")
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLStoreD45P1025)
            Case EnumFormState.FormEdit
        End Select

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            D99C0008.MsgL3(rl3("Ke_thua_thanh_cong"))
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    Dim f As New D45F1021
                    f.PriceListID = txtNewPriceListID.Text
                    Me.Close()
                    f.FormState = EnumFormState.FormEdit
                    f.ShowDialog()
                    f.Dispose()
                Case EnumFormState.FormEdit

            End Select
        Else
            D99C0008.MsgL3(rl3("Ke_thua_khong_thanh_cong"))
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1025
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/05/2007 02:14:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1025() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P1025 "
        sSQL &= SQLString(txtNewPriceListID.Text) & COMMA 'NewPriceListID, varchar[20], NOT NULL
        sSQL &= SQLString(txtOldPriceListID.Text) & COMMA 'OldPriceListID, varchar[20], NOT NULL
        If optValue.Checked Then
            sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
            sSQL &= SQLString(cboSign1.Text) & COMMA 'Sign, varchar[1], NOT NULL
            sSQL &= SQLMoney(txtValue1.Text) 'AdjustValue, decimal, NOT NULL
        Else
            sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
            sSQL &= SQLString(cboSign2.Text) & COMMA 'Sign, varchar[1], NOT NULL
            sSQL &= SQLMoney(txtValue2.Text) 'AdjustValue, decimal, NOT NULL
        End If

        Return sSQL
    End Function

    Private Sub txtValue1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValue1.KeyPress
        If CheckKeyPress(e.KeyChar, EnumKey.NumberDot) Then e.Handled = True
    End Sub

    Private Sub txtValue1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue1.LostFocus
        If txtValue1.Text <> "" Then
            If IsNumeric(txtValue1.Text) Then
                txtValue1.Text = Format(CDbl(txtValue1.Text), DxxFormat.DefaultNumber2)
            End If
        End If
    End Sub

    Private Sub txtValue2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValue2.KeyPress
        If CheckKeyPress(e.KeyChar, EnumKey.NumberDot) Then e.Handled = True
    End Sub

    Private Sub txtValue2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue2.LostFocus
        If txtValue2.Text <> "" Then
            If IsNumeric(txtValue2.Text) Then
                txtValue2.Text = Format(CDbl(txtValue2.Text), DxxFormat.DefaultNumber2)
            End If
        End If
    End Sub
End Class