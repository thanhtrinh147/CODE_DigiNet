Imports System
Public Class D25F4081

    Private _f_Call As D25F4080
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _typeID As String = ""
    Public WriteOnly Property TypeID() As String 
        Set(ByVal Value As String )
            _typeID = Value
        End Set
    End Property


    Public Property F_Call As D25F4080
        Get
            Return _f_Call
        End Get
        Set(ByVal Value As D25F4080)
            _f_Call = Value
        End Set
    End Property
    

    Private _formID As String = "D25F4081"
    Public WriteOnly Property FormID() As String 
        Set(ByVal Value As String )
            _formID = Value
        End Set
    End Property

    Private Sub D25F4081_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral()
        LoadTDBCombo()
        LoadDefault()
        LoadLanguage()
        '*******************
        btnSave.Enabled = ReturnPermission("D25F4081") > EnumPermission.View
        '*******************
        SetBackColorObligatory()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D25F4081_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If Me.ActiveControl.Name = txtEmailContent.Name Then Exit Sub
                UseEnterAsTab(Me, True)
        End Select
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Thiet_lap_noi_dung_mail") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'ThiÕt lËp nèi dung mail
        '================================================================ 
        'lblTypeID.Text = rL3("Ket_qua_PV") 'Kết quả PV
        '================================================================ 
        lblTypeID.Text = rL3("Ket_qua_PVTrang_thai") 'Kết quả PV/Trạng thái

        lblSubject.Text = rl3("Tieu_de") 'Tiêu đề
        lblEmailContent.Text = rl3("Noi_dung") 'Nội dung
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnInfoCandidate.Text = rL3("_Thong_tin_ung_vien") '&Thông tin ứng viên
        '================================================================ 
        btnChoose.Text = rL3("Chon") 'Chọn

    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcTypeID
        sSQL = "SELECT		'%' AS TypeID, " & AllName & " AS TypeName" & vbCrLf
        sSQL &= "UNION ALL  " & vbCrLf
        sSQL &= "SELECT    		 IntStatusID AS TypeID, IntStatusNameU AS TypeName" & vbCrLf
        sSQL &= "FROM 		D25V2016 " & vbCrLf
        sSQL &= "ORDER BY   	TypeID" & vbCrLf

        LoadDataSource(tdbcTypeID, sSQL, gbUnicode)
        tdbcTypeID.SelectedIndex = 0
    End Sub

    Private Sub LoadDefault()
        tdbcTypeID.SelectedValue = _typeID
        If txtSubject.Text = "" Then
            txtSubject.Text = "Kết quả phỏng vấn"
        End If
    End Sub

    Private Sub LoadEdit()
        Dim sSQL As String = ""
        sSQL = "SELECT 		EmailContentU AS EmailContent, SubjectU AS Subject"
        sSQL &= " FROM D25T4081 WITH(NOLOCK)"
        sSQL &= " WHERE		FormID = " & SQLString(_formID)
        sSQL &= " AND TypeID = " & SQLString(ReturnValueC1Combo(tdbcTypeID))

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            With dt.Rows(0)
                txtSubject.Text = .Item("Subject").ToString
                txtEmailContent.Text = .Item("EmailContent").ToString
            End With
            dt.Dispose()
        Else
            txtSubject.Text = ""
            txtEmailContent.Text = ""
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblTypeID.Text)
            tdbcTypeID.Focus()
            Return False
        End If
        If txtSubject.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblSubject.Text)
            txtSubject.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtSubject.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLDeleteD25T4081)
        sSQL.AppendLine(SQLInsertD25T4081.ToString)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
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

#Region "Events tdbcTypeID with txtSubject"

    Private Sub tdbcTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTypeID.SelectedValueChanged
        LoadEdit()
        btnSave.Enabled = ReturnValueC1Combo(tdbcTypeID) <> "%"
    End Sub

    Private Sub tdbcTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTypeID.LostFocus
        If tdbcTypeID.FindStringExact(tdbcTypeID.Text) = -1 Then
            tdbcTypeID.Text = ""
        End If
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTypeID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTypeID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T4081
    '# Created User: Hoàng Nhân
    '# Created Date: 04/12/2014 03:02:22
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T4081() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu" & vbCrlf)
        sSQL &= "Delete From D25T4081"
        sSQL &= " Where "
        sSQL &= "FormID = " & SQLString(_formID)
        sSQL &= " AND TypeID = " & SQLString(ReturnValueC1Combo(tdbcTypeID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T4081
    '# Created User: Hoàng Nhân
    '# Created Date: 04/12/2014 05:14:58
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T4081() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu" & vbCrlf)
        sSQL.Append("Insert Into D25T4081(")
        sSQL.Append("EmailContentU, SubjectU, FormID, TypeID")
        sSQL.Append(") Values(" & vbCrlf)
        sSQL.Append(SQLStringUnicode(txtEmailContent, True) & COMMA) 'EmailContentU, nvarchar[8000], NOT NULL
        sSQL.Append(SQLStringUnicode(txtSubject, True) & COMMA) 'SubjectU, nvarchar[1000], NOT NULL
        sSQL.Append(SQLString(_formID) & COMMA) 'FormID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTypeID))) 'TypeID, varchar[50], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function



    Private Sub btnInfoCandidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoCandidate.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormID", _formID)
        Dim frm As Form = CallFormShowDialog("D13D0340", "D13F4024", arrPro)
        Dim sCodeID As String = GetProperties(frm, "CodeID").ToString

        'Gan vo EmailContent
        Dim iCurrentPos As Integer = txtEmailContent.SelectionStart
        Dim sContent As String = txtEmailContent.Text
        Dim sTextBefore As String = sContent.Substring(0, iCurrentPos)
        Dim sTextAfter As String = sContent.Substring(iCurrentPos, sContent.Length - iCurrentPos)
        txtEmailContent.Text = sTextBefore & sCodeID & sTextAfter
    End Sub

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        F_Call.rtbEmailContent.Text = txtEmailContent.Text
    End Sub
End Class