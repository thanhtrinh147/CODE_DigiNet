'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:38:13 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:38:13 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F2053
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Private _salCalMethodID As String
    Private _description As String


    Public Property SalCalMethodID() As String
        Get
            Return _salCalMethodID
        End Get
        Set(ByVal value As String)
            If SalCalMethodID = value Then
                _salCalMethodID = ""
                Return
            End If
            _salCalMethodID = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            If Description = value Then
                _description = ""
                Return
            End If
            _description = value
        End Set
    End Property
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F2053_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        FormKeyPress(sender, e)
    End Sub

    Private Sub D13F2053_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        LoadTDBCombo()
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ke_thua_phuong_phap_tinh_luong_-_D13F2053") & UnicodeCaption(gbUnicode) 'KÕ thôa ph§¥ng phÀp tÛnh l§¥ng - D13F2053
        '================================================================ 
        lblSalCalMethodID.Text = rl3("PP_ke_thua") 'PP kế thừa
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcSalCalMethodID.Columns("SalCalMethodID").Caption = rl3("Ma") 'Mã
        tdbcSalCalMethodID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcSalCalMethodID
        sSQL = "Select SalCalMethodID, " & IIf(gbUnicode, "DescriptionU", "Description").ToString & " as Description From D13T2500 Where Disabled=0 And SalCalMethodID <> " & SQLString(_salCalMethodID)
        LoadDataSource(tdbcSalCalMethodID, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcSalCalMethodID with txtSalCalMethodName"

    Private Sub tdbcSalCalMethodID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalCalMethodID.Close
        If tdbcSalCalMethodID.FindStringExact(tdbcSalCalMethodID.Text) = -1 Then
            tdbcSalCalMethodID.Text = ""
            txtSalCalMethodName.Text = ""
        End If
    End Sub

    Private Sub tdbcSalCalMethodID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSalCalMethodID.SelectedValueChanged
        txtSalCalMethodName.Text = tdbcSalCalMethodID.Columns(1).Value.ToString
    End Sub

    'Private Sub tdbcSalCalMethodID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSalCalMethodID.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
    '        tdbcSalCalMethodID.Text = ""
    '        txtSalCalMethodName.Text = ""
    '    End If
    'End Sub

#End Region

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        sSQL = SQLStoreD13P2501()
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            'If CheckAudit("SalCalMethodIn") Then
            '    sSQL = SQLStoreD91P9106("SalCalMethodIn", "13", "02", _salCalMethodID, _description, tdbcSalCalMethodID.SelectedValue.ToString, "", "")
            '    ExecuteSQLNoTransaction(sSQL)
            'End If
            Lemon3.D91.RunAuditLog("13", "SalCalMethodIn", "02", _salCalMethodID, _description, tdbcSalCalMethodID.SelectedValue.ToString, "", "")
            btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcSalCalMethodID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("PP_ke_thua"))
            tdbcSalCalMethodID.Focus()
            Return False
        End If
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2501
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 05/03/2007 01:52:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2501() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2501 "
        sSQL &= SQLString(tdbcSalCalMethodID.SelectedValue.ToString) & COMMA 'OldSalCalMethodID, varchar[20], NOT NULL
        sSQL &= SQLString(_salCalMethodID) 'NewSalCalMethodID, varchar[20], NOT NULL
        Return sSQL
    End Function

End Class