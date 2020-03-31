Public Class D13F4022

    Dim dt As DataTable
    Dim bIsEdit As Boolean = False

    Private Sub D13F4022_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.ActiveControl.Name <> txtContent.Name Then UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D13F4022_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        '*****************************************
        Dim sSQL As String = ""
        sSQL = "SELECT	Subject" & UnicodeJoin(gbUnicode) & " AS Subject, Content" & UnicodeJoin(gbUnicode) & " AS Content, " & vbCrLf
        sSQL &= "CreateUserID, LastModifyUserID, CreateDate, LastModifyDate" & vbCrLf
        sSQL &= "FROM D13T4020 WITH (NOLOCK) "
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            txtSubject.Text = dt.Rows(0).Item("Subject").ToString
            txtContent.Text = dt.Rows(0).Item("Content").ToString
            bIsEdit = True
        End If
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Thiet_lap_noi_dung_Email_-_D13F4022") & UnicodeCaption(gbUnicode) 'ThiÕt lËp nèi dung Email - D13F4022
        '================================================================ 
        btnEmployeeInfo.Text = rL3("_Thong_tin_nhan_vien") '&Thông tin nhân viên
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnEmployeeInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeInfo.Click
        Dim f As New D13F4024
        With f
            .ShowInTaskbar = False
            .ShowDialog()

            Dim iCurrentPos As Integer = txtContent.SelectionStart
            Dim sContent As String = txtContent.Text
            Dim sTextBefore As String = sContent.Substring(0, iCurrentPos)
            Dim sTextAfter As String = sContent.Substring(iCurrentPos, sContent.Length - iCurrentPos)
            txtContent.Text = sTextBefore & .CodeID & sTextAfter

            .Dispose()
        End With
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        'If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        If bIsEdit Then
            sSQL.Append(SQLUpdateD13T4020)
        Else
            sSQL.Append(SQLInsertD13T4020)
        End If

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T4020
    '# Created User: DUCTRONG
    '# Created Date: 02/07/2009 09:52:41
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T4020() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D13T4020(")
        sSQL.Append("Subject, SubjectU, Content, ContentU, CreateUserID, LastModifyUserID, CreateDate, ")
        sSQL.Append("LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLStringUnicode(txtSubject, False) & COMMA) 'Subject, varchar[1000], NOT NULL
        sSQL.Append(SQLStringUnicode(txtSubject, True) & COMMA) 'SubjectU, varchar[1000], NOT NULL
        sSQL.Append(SQLStringUnicode(txtContent, False) & COMMA) 'Content, varchar[8000], NOT NULL
        sSQL.Append(SQLStringUnicode(txtContent, True) & COMMA) 'ContentU, varchar[8000], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T4020
    '# Created User: DUCTRONG
    '# Created Date: 02/07/2009 09:53:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T4020() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T4020 Set ")
        sSQL.Append("Subject = " & SQLStringUnicode(txtSubject, False) & COMMA) 'varchar[1000], NOT NULL
        sSQL.Append("SubjectU = " & SQLStringUnicode(txtSubject, True) & COMMA) 'varchar[1000], NOT NULL
        sSQL.Append("Content = " & SQLStringUnicode(txtContent, False) & COMMA) 'varchar[8000], NOT NULL
        sSQL.Append("ContentU= " & SQLStringUnicode(txtContent, True) & COMMA) 'varchar[8000], NOT NULL
        sSQL.Append("CreateUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("CreateDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        Return sSQL
    End Function

End Class