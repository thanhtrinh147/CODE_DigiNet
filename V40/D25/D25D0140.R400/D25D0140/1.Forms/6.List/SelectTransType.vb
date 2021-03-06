Public Class SelectTransactionType

    Private Sub SelectTransactionType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        SetBackColorObligatory()
        Loadlanguage()
        LoadTDBCombo()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        Me.Text = rl3("Chon_loai_nghiep_vu_HS_ung_cu_vien") & UnicodeCaption(gbUnicode)
        '================================================================ 
        lblTransTypeID.Text = rl3("Loai_nghiep_vu")
        tdbcTransTypeID.Columns("TransTypeID").Caption = rl3("Ma")
        tdbcTransTypeID.Columns("TransTypeName").Caption = rl3("Ten")
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        sSQL &= " Select TransTypeID, TransTypeName" & UnicodeJoin(gbUnicode) & " as TransTypeName " & vbCrLf
        sSQL &= " From D25T1080 WITH(NOLOCK) 	" & vbCrLf
        sSQL &= " Where	Disabled = 0" & vbCrLf
        sSQL &= " Order by TransTypeID" & vbCrLf
        LoadDataSource(tdbcTransTypeID, sSQL)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcTransTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If tdbcTransTypeID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Loai_nghiep_vu"))
            tdbcTransTypeID.Focus()
            Exit Sub
        End If

        D25Options.TransTypeID = tdbcTransTypeID.Text
        D99C0007.SaveModulesSetting(D25, ModuleOption.lmOptions, "TransTypeID", D25Options.TransTypeID)
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Events tdbcTransTypeID with txtTransTypeName"

    Private Sub tdbcTransTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.Close
        If tdbcTransTypeID.FindStringExact(tdbcTransTypeID.Text) = -1 Then
            tdbcTransTypeID.Text = ""
            txtTransTypeName.Text = ""
        End If
    End Sub

    Private Sub tdbcTransTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.SelectedValueChanged
        txtTransTypeName.Text = tdbcTransTypeID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcTransTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcTransTypeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcTransTypeID.Text = ""
            txtTransTypeName.Text = ""
        End If
    End Sub

#End Region

End Class
