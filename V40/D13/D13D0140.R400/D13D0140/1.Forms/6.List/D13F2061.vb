Public Class D13F2061
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Dim iTransferMode As Integer
    Dim i As Integer
    Dim Flag As Boolean


    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    chkDisabled.Visible = False
                    btnNext.Enabled = False
                    btnDetail.Enabled = False
                    optDetail.Checked = True
                    optCollect.Enabled = True
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnDetail.Enabled = True
                    optCollect.Enabled = True
                    i = btnSave.Left
                    btnSave.Left = btnNext.Left
                    btnDetail.Left = i
                    Flag = True
                    LoadEdit()
                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnDetail.Enabled = True
                    optCollect.Enabled = True
                    i = btnSave.Left
                    btnSave.Left = btnNext.Left
                    btnDetail.Left = i
                    btnSave.Enabled = False
                    Flag = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _transferMethodID As String = ""
    Public Property TransferMethodID() As String
        Get
            Return _transferMethodID
        End Get
        Set(ByVal Value As String)
            _transferMethodID = Value
        End Set
    End Property

    Private Function AllowSave() As Boolean
        If txtTransferMethodID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_phuong_phap"))
            txtTransferMethodID.Focus()
            Return False
        End If
        If Trim(txtTransferMethodID.Text).Length > 20 Then
            D99C0008.MsgL3(rl3("Ma_phuong_phap_khong_duoc_vuot_qua_20_ky_tu"))
            txtTransferMethodID.Focus()
            Return False
        End If
        If txtTransferMethodName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_phuong_phap"))
            txtTransferMethodName.Focus()
            Return False
        End If
        If Trim(txtTransferMethodName.Text).Length > 250 Then
            D99C0008.MsgL3(rl3("Ten_phuong_phap_khong_duoc_vuot_qua_250_ky_tu"))
            txtTransferMethodName.Focus()
            Return False
        End If
        If txtNote.Text.Trim <> "" Then
            If Trim(txtNote.Text).Length > 250 Then
                D99C0008.MsgL3(rl3("Ghi_chu_khong_duoc_vuot_qua_250_ky_tu"))
                txtNote.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        txtTransferMethodID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtTransferMethodName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadEdit()
        txtTransferMethodID.Enabled = False
        chkDisabled.Visible = True
        LoadMaster()
        txtTransferMethodName.Focus()
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String
        sSQL = "Select * From D13T1110 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where TransferMethodID = '" & _transferMethodID & "' "

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            txtTransferMethodID.Text = dt.Rows(0).Item("TransferMethodID").ToString
            txtTransferMethodName.Text = dt.Rows(0).Item("TransferMethodName" & UnicodeJoin(gbUnicode)).ToString
            chkDisabled.Checked = Convert.ToBoolean(dt.Rows(0).Item("Disabled"))
            txtNote.Text = dt.Rows(0).Item("Note" & UnicodeJoin(gbUnicode)).ToString
            If dt.Rows(0).Item("TransferMode").ToString = "0" Then
                optDetail.Checked = True
                iTransferMode = 0
            Else
                optCollect.Checked = True
                iTransferMode = 1
                btnCollectDetail.Enabled = True
            End If
        End If
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_phuong_phap_chuyen_but_toan_-_D13F2061") & UnicodeCaption(gbUnicode) 'CËp nhËt ph§¥ng phÀp chuyÓn bòt toÀn - D13F2061
        '================================================================ 
        lblTransferMethodID.Text = rl3("Ma") 'Mã 
        lblTransferMethodName.Text = rl3("Dien_giai") 'Diễn giải
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        lblTransfer.Text = rl3("Hinh_thuc_chuyen_but_toan") 'Hình thức chuyển bút toán
        '================================================================ 
        btnCollectDetail.Text = rl3("_Chi_tiet_chuyen_tong_hop") '&Chi tiết chuyển tổng hợp
        btnDetail.Text = rl3("_Chi_tiet") '&Chi tiết
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        optCollect.Text = rl3("Tong_hop") 'Tổng hợp
        optDetail.Text = rl3("Chi_tiet") 'Chi tiết
        '================================================================ 
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""

        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        _transferMethodID = txtTransferMethodID.Text
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL = "Select TransferMethodID From D13T1110 WITH (NOLOCK) " & vbCrLf
                sSQL &= "Where TransferMethodID=" & SQLString(_transferMethodID)
                If ExistRecord(sSQL) Then
                    D99C0008.MsgDuplicatePKey()
                    txtTransferMethodID.Focus()
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
                    Exit Sub
                End If
                sSQL = SQLInsertD13T1110() & vbCrLf
            Case EnumFormState.FormEdit
                sSQL = SQLUpdateD13T1110() & vbCrLf
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    ''Lưu lại vết Audit
                    'If CheckAudit("TransTransferMethod") Then
                    '    sSQL = SQLStoreD91P9106("TransTransferMethod", "13", "01", txtTransferMethodID.Text, _txtTransferMethodName.Text, iTransferMode.ToString, "", "")
                    '    ExecuteSQLNoTransaction(sSQL)
                    'End If
                    btnDetail.Enabled = True
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'Lưu lại vết Audit
                    'If CheckAudit("TransTransferMethod") Then
                    '    sSQL = SQLStoreD91P9106("TransTransferMethod", "13", "02", txtTransferMethodID.Text, _txtTransferMethodName.Text, iTransferMode.ToString, "", "")
                    '    ExecuteSQLNoTransaction(sSQL)
                    'End If
                    Lemon3.D91.RunAuditLog("13", "TransTransferMethod", "02", txtTransferMethodID.Text, _txtTransferMethodName.Text, iTransferMode.ToString, "", "")
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub optDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDetail.Click
        If optDetail.Checked Then
            iTransferMode = 0
            btnCollectDetail.Enabled = False
        End If
    End Sub

    Private Sub optCollect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCollect.Click
        'If optCollect.Checked Then
        iTransferMode = 1
        btnCollectDetail.Enabled = True
        'End If
    End Sub

    Private Sub D13F2061_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        End If
    End Sub

    Private Sub D13F2061_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtTransferMethodID)
        SetBackColorObligatory()
        SetResolutionForm(Me)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1110
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 01/03/2007 09:33:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1110() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D13T1110("
        sSQL &= "TransferMethodID, TransferMethodName, TransferMethodNameU, TransferMode, Note, NoteU, IsDebitAccountID, "
        sSQL &= "IsCreditAccountID, IsObjectTypeID, IsObjectID, "
        sSQL &= "Disabled, CreateUserID, "
        sSQL &= "CreateDate, LastModifyUserID, LastModifyDate"
        sSQL &= ") Values ("
        sSQL &= SQLString(txtTransferMethodID.Text) & COMMA 'TransferMethodID [KEY], varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtTransferMethodName, False) & COMMA 'TransferMethodName, varchar[250], NULL
        sSQL &= SQLStringUnicode(txtTransferMethodName, True) & COMMA 'TransferMethodName, varchar[250], NULL
        sSQL &= SQLNumber(iTransferMode) & COMMA 'TransferMode, int, NULL
        sSQL &= SQLStringUnicode(txtNote, False) & COMMA 'Note, varchar[250], NULL
        sSQL &= SQLStringUnicode(txtNote, True) & COMMA 'Note, varchar[250], NULL
        sSQL &= SQLNumber(1) & COMMA 'IsDebitAccountID, tinyint, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'IsCreditAccountID, tinyint, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'IsObjectTypeID, tinyint, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'IsObjectID, tinyint, NOT NULL
        sSQL &= SQLNumber(chkDisabled.Checked) & COMMA 'Disabled, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" 'LastModifyDate, datetime, NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1110
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 01/03/2007 09:33:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1110() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T1110 Set "
        sSQL &= "TransferMethodName = " & SQLStringUnicode(txtTransferMethodName, False) & COMMA 'varchar[250], NULL
        sSQL &= "TransferMethodNameU = " & SQLStringUnicode(txtTransferMethodName, True) & COMMA 'varchar[250], NULL
        sSQL &= "TransferMode = " & SQLNumber(iTransferMode) & COMMA 'int, NULL
        sSQL &= "Note = " & SQLStringUnicode(txtNote, False) & COMMA 'varchar[250], NULL
        sSQL &= "NoteU = " & SQLStringUnicode(txtNote, True) & COMMA 'varchar[250], NULL
        sSQL &= "IsDebitAccountID = " & SQLNumber(1) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsCreditAccountID = " & SQLNumber(1) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsObjectTypeID = " & SQLNumber(1) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsObjectID = " & SQLNumber(1) & COMMA 'tinyint, NOT NULL
        sSQL &= "Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" 'datetime, NULL
        sSQL &= " Where "
        sSQL &= "TransferMethodID = " & SQLString(_transferMethodID)
        Return sSQL
    End Function

    Private Sub btnDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Dim f As New D13F2062
        f.TransferMethodID = txtTransferMethodID.Text
        If _FormState = EnumFormState.FormAdd Then
            f.FormState = EnumFormState.FormAdd
        ElseIf _FormState = EnumFormState.FormEdit Then
            f.FormState = EnumFormState.FormEdit
        ElseIf _FormState = EnumFormState.FormView Then
            f.FormState = EnumFormState.FormView
        End If
        Me.Close()
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub btnCollectDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollectDetail.Click
        Dim f As New D13F2063
        f.TransferMethodID = txtTransferMethodID.Text
        If Flag Then
            f.FormState = EnumFormState.FormEdit
        Else
            f.FormState = EnumFormState.FormView
        End If
        f.ShowDialog()
        f.Dispose()
    End Sub
    
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        _transferMethodID = txtTransferMethodID.Text
        txtTransferMethodID.Text = ""
        txtTransferMethodName.Text = ""
        txtNote.Text = ""

        btnSave.Enabled = True
        btnNext.Enabled = False
        btnDetail.Enabled = False
        txtTransferMethodID.Focus()
    End Sub
End Class