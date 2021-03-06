'#-------------------------------------------------------------------------------------
'# Created Date: 25/07/2006 10:14:33 AM
'# Created User: Lê Văn Phước
'# Modify Date: 25/07/2006 10:14:33 AM
'# Modify User: Lê Văn Phước
'#-------------------------------------------------------------------------------------
Public Class D25F0003
    Dim dtPeriod As DataTable
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
            LoadCboPeriodReport(tdbcPeriod, dtPeriod, "-1")
            Exit Sub
        End If
        LoadCboPeriodReport(tdbcPeriod, dtPeriod, tdbcDivisionID.Text)
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

    Private Sub D25F0003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.KeyPress, AddressOf FormKeyPress
        Loadlanguage()
        dtPeriod = LoadTablePeriodReport("D09")
        SetBackColorObligatory()
        LoadTDBCombo()
        LoadEdit()
        If gbUnicode Then
            tdbcPeriod.Font = FontUnicode(True, , 8.25)
        Else
            tdbcPeriod.Font = FontUnicode(False, , 8.249999!)
        End If
        tdbcPeriod.EditorFont = tdbcPeriod.Font
        'Modify 08/05/2013 - ID 56071
        'btnSelected.Enabled = ReturnPermission(Me.Name) > EnumPermission.View
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_ky") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Chãn kù kÕ toÀn - D25F0003
        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblPeriod.Text = rl3("Ky_ke_toan") 'Kỳ kế toán
        '================================================================ 
        btnSelected.Text = rl3("Chon") 'Chọn
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã đơn vị
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên đơn vị
    End Sub

    Private Sub LoadTDBCombo()
        LoadCboDivisionID(tdbcDivisionID, "D09", True, gbUnicode)
        'Load tdbcPeriod
        'LoadtdbcPeriod("-1")
        LoadCboPeriodReport(tdbcPeriod, dtPeriod, "-1")
    End Sub

    Private Sub LoadEdit()
        tdbcDivisionID.Tag = gsDivisionID
        tdbcDivisionID.SelectedValue = gsDivisionID
        LoadCboPeriodReport(tdbcPeriod, dtPeriod, gsDivisionID)
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

        'btnClose.Text = "&Kỳ kế toán: "
    End Sub

    Private Function AllowSelected() As Boolean
        If tdbcDivisionID.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcPeriod.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ky_ke_toan"))
            tdbcPeriod.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
End Class