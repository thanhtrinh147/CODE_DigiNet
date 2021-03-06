'#-------------------------------------------------------------------------------------
'# Created Date: 25/07/2006 10:14:33 AM
'# Created User: Nguyễn Thị Minh Hòa
'# Modify Date: 25/07/2006 10:14:33 AM
'# Modify User: Nguyễn Thị Minh Hòa
'#-------------------------------------------------------------------------------------
Public Class D45F0003

#Region "Events tdbcDivisionID load tdbcPeriod"

    Private Sub tdbcDivisionID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then tdbcDivisionID.Text = ""
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If Not (tdbcDivisionID.Tag Is Nothing OrElse tdbcDivisionID.Tag.ToString = "") Then
            tdbcDivisionID.Tag = ""
            Exit Sub
        End If
        If tdbcDivisionID.SelectedValue Is Nothing Then
            LoadtdbcPeriod("-1")
            Exit Sub
        End If
        LoadtdbcPeriod(tdbcDivisionID.SelectedValue.ToString())
        tdbcPeriod.Text = tdbcPeriod.Columns(0).Text
    End Sub

    Private Sub tdbcDivisionID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcDivisionID.Text = ""
    End Sub

    Private Sub tdbcPeriod_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriod.Close
        If tdbcPeriod.FindStringExact(tdbcPeriod.Text) = -1 Then tdbcPeriod.Text = ""
    End Sub

    Private Sub tdbcPeriod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPeriod.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPeriod.Text = ""
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub D45F0003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.KeyPress, AddressOf FormKeyPress
        LoadLanguage()
        LoadTDBCombo()
        LoadEdit()
        'Modify 09/05/2013 - ID 56071
        SetBackColorObligatory()
        'btnSelected.Enabled = ReturnPermission("D45F0003") > EnumPermission.View
        InputbyUnicode(Me, gbUnicode)
        '*************************
        'Để đoạn code này để chỉnh lại Font cho tdbcPeriod nên không được bỏ
        'If gbUnicode Then
        tdbcPeriod.Font = New Font("Microsoft Sans Serif", 8.25)
        tdbcPeriod.EditorFont = New Font("Microsoft Sans Serif", 8.25)
        'Else
        '    tdbcPeriod.Font = New Font("Lemon3", 8.249999!)
        '    tdbcPeriod.EditorFont = New Font("Lemon3", 8.249999!)
        'End If
        '*************************

        SetResolutionForm(Me)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_ky") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Chãn kù kÕ toÀn - D45F0003
        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblPeriod.Text = rl3("Ky") 'Kỳ kế toán
        '================================================================ 
        btnSelected.Text = rl3("Chon") 'Chọn
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã đơn vị
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên đơn vị
    End Sub


    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDivisionID
        LoadCboDivisionID(tdbcDivisionID, "D09", True, gbUnicode)
        'Load tdbcPeriod
        'LoadtdbcPeriod("-1")
    End Sub

    Private Sub LoadtdbcPeriod(ByVal ID As String)
        Dim sSQL As String = ""
        sSQL &= "Select (Right(('0'+ RTrim(LTrim(Str(TranMonth)))), 2) + '/' + LTrim(Str(TranYear))) As Period, TranMonth, TranYear "
        sSQL &= "From D09T9999  WITH(NOLOCK) Where DivisionID = " & SQLString(ID) & " Order By TranYear Desc, TranMonth Desc"
        LoadDataSource(tdbcPeriod, sSQL, gbUnicode)
    End Sub

    Private Sub LoadEdit()
        '  tdbcDivisionID.Enabled = Not gbLockedDivisionID
        tdbcDivisionID.Tag = gsDivisionID
        tdbcDivisionID.SelectedValue = gsDivisionID
        LoadtdbcPeriod(gsDivisionID)
        tdbcPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
    End Sub

    Private Sub btnSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelected.Click
        If Not AllowSelected() Then Exit Sub
        Dim sPeriod As String = tdbcPeriod.SelectedValue.ToString
        gsDivisionID = tdbcDivisionID.SelectedValue.ToString
        giTranMonth = Convert.ToInt16(sPeriod.Substring(0, 2))
        giTranYear = Convert.ToInt16(sPeriod.Substring(3))
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Function AllowSelected() As Boolean
        If tdbcDivisionID.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcPeriod.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ky"))
            tdbcPeriod.Focus()
            Return False
        End If
        Return True
    End Function

End Class