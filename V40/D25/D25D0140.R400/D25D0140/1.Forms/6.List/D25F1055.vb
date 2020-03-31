Public Class D25F1055

    ' Update 23/05/2011 - Chuẩn unicode theo DC25 _ TIENDAU
    Public skey As String = ""

    Private Sub D25F1055_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D25F1055_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        skey = ""
        Loadlanguage()
        LoadTDBCombo()
        InputbyUnicode(Me, gbUnicode)
        btnOk.Enabled = False
        
    SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ke_thua_nhan_vien_nghi_viec_-_D25F1055") & UnicodeCaption(gbUnicode) 'KÕ thôa nh¡n vi£n nghÙ viÖc - D25F1055
        '================================================================ 
        lblEmployeeID.Text = rl3("Nhan_vien") 'Nhân viên
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnOk.Text = rl3("_Chap_nhan") 'Chấp nhận
        '================================================================ 
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("FullName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên

    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String
        'Load tdbcEmployeeID
        sSQL = " Select EmployeeID, Isnull(LastName" & UnicodeJoin(gbUnicode) & ",'') + ' ' + Isnull(MiddleName" & UnicodeJoin(gbUnicode) & ",'') + ' ' + Isnull(FirstName" & UnicodeJoin(gbUnicode) & ",'') as FullName" & vbCrLf ', LastName, MiddleName, FirstName, DivisionID, DepartmentID, TeamID  " & vbCrLf
        sSQL &= " From D09T0201 WITH(NOLOCK)  " & vbCrLf
        sSQL &= " where Disabled=1 " & vbCrLf
        sSQL &= " Order by EmployeeID "
        LoadDataSource(tdbcEmployeeID, sSQL, gbUnicode)
    End Sub

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then
            tdbcEmployeeID.Text = ""
            txtFullName.Text = ""
        End If
        btnOk.Enabled = tdbcEmployeeID.Text <> ""
    End Sub

#Region "Events tdbcEmployeeID with txtFullName"

    Private Sub tdbcEmployeeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.Close
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then
            tdbcEmployeeID.Text = ""
            txtFullName.Text = ""
        End If

        btnOk.Enabled = tdbcEmployeeID.Text <> ""
    End Sub

    Private Sub tdbcEmployeeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.SelectedValueChanged
        txtFullName.Text = tdbcEmployeeID.Columns(1).Value.ToString
        btnOk.Enabled = tdbcEmployeeID.Text <> ""
    End Sub

    Private Sub tdbcEmployeeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcEmployeeID.KeyDown
        With tdbcEmployeeID
            If e.KeyCode = Keys.F2 Then
                'Dim f As New D91F6010
                'f.InListID = "81"
                'f.InWhere = "" 'DepartmentID = " & SQLString(.Columns("DepartmentID").Text) & " And TeamID = " & SQLString(.Columns("TeamID").Text) & " And EmployeeID = " & SQLString(.Text)
                'f.ShowDialog()
                'tdbcEmployeeID.SelectedValue = f.OutPut01

                'ID 79397 4/9/2015
                Try
                    Dim arrPro() As StructureProperties = Nothing
                    SetProperties(arrPro, "InListID", "81")
                    SetProperties(arrPro, "InWhere", "")
                    Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6010", arrPro)
                    Dim sKey As String = GetProperties(frm, "Output01").ToString
                    If sKey <> "" Then
                        'Load dữ liệu
                        tdbcEmployeeID.SelectedValue = sKey

                    End If
                Catch ex As Exception
                    D99C0008.MsgL3(ex.Message)
                End Try
            End If
        End With

        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            btnOk.Enabled = tdbcEmployeeID.Text <> ""
        End If
    End Sub

#End Region

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If tdbcEmployeeID.Text = "" Then Exit Sub
        Dim f As New D25F1051
        f.EmployeeID = tdbcEmployeeID.Text
        f.ParentFrm = "D25F1055"
        f.FormState = EnumFormState.FormAdd
        f.ShowDialog()
        If f.bSaved Then
            skey = f.CandidateID
        End If
        f.Dispose()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
