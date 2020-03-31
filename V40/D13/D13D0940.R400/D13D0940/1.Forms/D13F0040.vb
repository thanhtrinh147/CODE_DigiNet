Public Class D13F0040

    Private Function AllowSave() As Boolean
        If chkDisabled01.Checked = True Then
            If txtDescription01.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                txtDescription01.Focus()
                Return False
            End If
            If txtShort01.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                txtShort01.Focus()
                Return False
            End If
            If txtDescription01.Text.Trim <> "" Then
                If Len(txtDescription01.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                    txtDescription01.Focus()
                    Return False
                End If
            End If
            If txtShort01.Text.Trim <> "" Then
                If Len(txtShort01.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
                    txtShort01.Focus()
                    Return False
                End If
            End If
        End If
        If chkDisabled02.Checked = True Then
            If txtDescription02.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                txtDescription02.Focus()
                Return False
            End If
            If txtShort02.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                txtShort02.Focus()
                Return False
            End If
            If txtDescription02.Text.Trim <> "" Then
                If Len(txtDescription02.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                    txtDescription02.Focus()
                    Return False
                End If
            End If
            If txtShort02.Text.Trim <> "" Then
                If Len(txtShort02.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
                    txtShort02.Focus()
                    Return False
                End If
            End If

        End If
        If chkDisabled03.Checked = True Then
            If txtDescription03.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                txtDescription03.Focus()
                Return False
            End If
            If txtShort03.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                txtShort03.Focus()
                Return False
            End If
            If txtDescription03.Text.Trim <> "" Then
                If Len(txtDescription03.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                    txtDescription03.Focus()
                    Return False
                End If
            End If
            If txtShort03.Text.Trim <> "" Then
                If Len(txtShort03.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
                    txtShort03.Focus()
                    Return False
                End If
            End If
        End If
        If chkDisabled04.Checked = True Then
            If txtDescription04.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                txtDescription04.Focus()
                Return False
            End If
            If txtShort04.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                txtShort04.Focus()
                Return False
            End If
            If txtDescription04.Text.Trim <> "" Then
                If Len(txtDescription04.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                    txtDescription04.Focus()
                    Return False
                End If
            End If
            If txtShort04.Text.Trim <> "" Then
                If Len(txtShort04.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
                    txtShort04.Focus()
                    Return False
                End If
            End If
        End If
        If chkDisabled05.Checked = True Then
            If txtDescription05.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                txtDescription05.Focus()
                Return False
            End If
            If txtDescription05.Text.Trim <> "" Then
                If Len(txtDescription05.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                    txtDescription05.Focus()
                    Return False
                End If
            End If
            If txtShort05.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                txtShort05.Focus()
                Return False
            End If
            If txtShort05.Text.Trim <> "" Then
                If Len(txtShort05.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
                    txtShort05.Focus()
                    Return False
                End If
            End If
        End If
        If chkDisabled06.Checked = True Then
            If txtDescription06.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                txtDescription06.Focus()
                Return False
            End If
            If txtDescription06.Text.Trim <> "" Then
                If Len(txtDescription06.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                    txtDescription06.Focus()
                    Return False
                End If
            End If

            If txtShort06.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                txtShort06.Focus()
                Return False
            End If
            If txtShort06.Text.Trim <> "" Then
                If Len(txtShort06.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
                    txtShort06.Focus()
                    Return False
                End If
            End If
        End If
        If chkDisabled07.Checked = True Then
            If txtDescription07.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                txtDescription07.Focus()
                Return False
            End If
            If txtDescription07.Text.Trim <> "" Then
                If Len(txtDescription07.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                    txtDescription07.Focus()
                    Return False
                End If
            End If
            If txtShort07.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                txtShort07.Focus()
                Return False
            End If
            If txtShort07.Text.Trim <> "" Then
                If Len(txtShort07.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
                    txtShort07.Focus()
                    Return False
                End If
            End If
        End If
        If chkDisabled08.Checked = True Then
            If txtDescription08.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                txtDescription08.Focus()
                Return False
            End If
            If txtDescription08.Text.Trim <> "" Then
                If Len(txtDescription08.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                    txtDescription08.Focus()
                    Return False
                End If
            End If

            If txtShort08.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                txtShort08.Focus()
                Return False
            End If
            If txtShort08.Text.Trim <> "" Then
                If Len(txtShort08.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
                    txtShort08.Focus()
                    Return False
                End If
            End If

        End If
        If chkDisabled09.Checked = True Then
            If txtDescription09.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                txtDescription09.Focus()
                Return False
            End If
            If Len(txtDescription09.Text.Trim) > 150 Then
                D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                txtDescription09.Focus()
                Return False
            End If
            If txtShort09.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                txtShort09.Focus()
                Return False
            End If
            If Len(txtShort09.Text.Trim) > 150 Then
                D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
                txtShort09.Focus()
                Return False
            End If
        End If
        If chkDisabled10.Checked = True Then
            If txtDescription10.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                txtDescription10.Focus()
                Return False
            End If
            If txtDescription10.Text.Trim <> "" Then
                If Len(txtDescription10.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                    txtDescription10.Focus()
                    Return False
                End If
            End If

            If txtShort10.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                txtShort10.Focus()
                Return False
            End If
            If txtShort10.Text.Trim <> "" Then
                If Len(txtShort10.Text.Trim) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
                    txtShort10.Focus()
                    Return False
                End If
            End If
        End If

        Return True
    End Function
    Private Sub LoadEdit()
        Dim s As String = ""
        s = "select Code,Description,Short,DescriptionU,ShortU,Disabled from D13T9000  WITH (NOLOCK) where type = 'PMACC'"
        Dim dt As DataTable = ReturnDataTable(s)
        If dt.Rows.Count < 1 Then Exit Sub

        Dim i As Integer = 1
        For j As Integer = 0 To dt.Rows.Count - 1
            Select Case i
                Case 1
                    txtCode01.Text = dt.Rows(j).Item("Code").ToString
                    txtDescription01.Text = dt.Rows(j).Item("Description" & UnicodeJoin(gbUnicode)).ToString
                    txtShort01.Text = dt.Rows(j).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                    chkDisabled01.Checked = Not (Convert.ToBoolean(dt.Rows(j).Item("Disabled")))
                Case 2
                    txtCode02.Text = dt.Rows(j).Item("Code").ToString
                    txtDescription02.Text = dt.Rows(j).Item("Description" & UnicodeJoin(gbUnicode)).ToString
                    txtShort02.Text = dt.Rows(j).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                    chkDisabled02.Checked = Not (Convert.ToBoolean(dt.Rows(j).Item("Disabled")))
                Case 3
                    txtCode03.Text = dt.Rows(j).Item("Code").ToString
                    txtDescription03.Text = dt.Rows(j).Item("Description" & UnicodeJoin(gbUnicode)).ToString
                    txtShort03.Text = dt.Rows(j).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                    chkDisabled03.Checked = Not (Convert.ToBoolean(dt.Rows(j).Item("Disabled")))
                Case 4
                    txtCode04.Text = dt.Rows(j).Item("Code").ToString
                    txtDescription04.Text = dt.Rows(j).Item("Description" & UnicodeJoin(gbUnicode)).ToString
                    txtShort04.Text = dt.Rows(j).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                    chkDisabled04.Checked = Not (Convert.ToBoolean(dt.Rows(j).Item("Disabled")))
                Case 5
                    txtCode05.Text = dt.Rows(j).Item("Code").ToString
                    txtDescription05.Text = dt.Rows(j).Item("Description" & UnicodeJoin(gbUnicode)).ToString
                    txtShort05.Text = dt.Rows(j).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                    chkDisabled05.Checked = Not (Convert.ToBoolean(dt.Rows(j).Item("Disabled")))
                Case 6
                    txtCode06.Text = dt.Rows(j).Item("Code").ToString
                    txtDescription06.Text = dt.Rows(j).Item("Description" & UnicodeJoin(gbUnicode)).ToString
                    txtShort06.Text = dt.Rows(j).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                    chkDisabled06.Checked = Not (Convert.ToBoolean(dt.Rows(j).Item("Disabled")))
                Case 7
                    txtCode07.Text = dt.Rows(j).Item("Code").ToString
                    txtDescription07.Text = dt.Rows(j).Item("Description" & UnicodeJoin(gbUnicode)).ToString
                    txtShort07.Text = dt.Rows(j).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                    chkDisabled07.Checked = Not (Convert.ToBoolean(dt.Rows(j).Item("Disabled")))
                Case 8
                    txtCode08.Text = dt.Rows(j).Item("Code").ToString
                    txtDescription08.Text = dt.Rows(j).Item("Description" & UnicodeJoin(gbUnicode)).ToString
                    txtShort08.Text = dt.Rows(j).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                    chkDisabled08.Checked = Not (Convert.ToBoolean(dt.Rows(j).Item("Disabled")))
                Case 9
                    txtCode09.Text = dt.Rows(j).Item("Code").ToString
                    txtDescription09.Text = dt.Rows(j).Item("Description" & UnicodeJoin(gbUnicode)).ToString
                    txtShort09.Text = dt.Rows(j).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                    chkDisabled09.Checked = Not (Convert.ToBoolean(dt.Rows(j).Item("Disabled")))
                Case 10
                    txtCode10.Text = dt.Rows(j).Item("Code").ToString
                    txtDescription10.Text = dt.Rows(j).Item("Description" & UnicodeJoin(gbUnicode)).ToString
                    txtShort10.Text = dt.Rows(j).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                    chkDisabled10.Checked = Not (Convert.ToBoolean(dt.Rows(j).Item("Disabled")))
            End Select
            i += 1
        Next

    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T9000
    '# Created User: Lý Anh Vĩ
    '# Created Date: 11/01/2007 04:08:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T9000() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T9000 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription01, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Short = " & SQLStringUnicode(txtShort01, False) & COMMA 'varchar[20], NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription01, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "ShortU = " & SQLStringUnicode(txtShort01, True) & COMMA 'varchar[20], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled01.Checked = True, 0, 1)) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "Type = " & SQLString("PMACC") & " And "
        sSQL &= "Code = " & SQLString(txtCode01.Text) & vbCrLf

        sSQL &= "Update D13T9000 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription02, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Short = " & SQLStringUnicode(txtShort02, False) & COMMA 'varchar[20], NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription02, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "ShortU = " & SQLStringUnicode(txtShort02, True) & COMMA 'varchar[20], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled02.Checked = True, 0, 1)) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "Type = " & SQLString("PMACC") & " And "
        sSQL &= "Code = " & SQLString(txtCode02.Text) & vbCrLf

        sSQL &= "Update D13T9000 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription03, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Short = " & SQLStringUnicode(txtShort03, False) & COMMA 'varchar[20], NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription03, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "ShortU = " & SQLStringUnicode(txtShort03, True) & COMMA 'varchar[20], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled03.Checked = True, 0, 1)) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "Type = " & SQLString("PMACC") & " And "
        sSQL &= "Code = " & SQLString(txtCode03.Text) & vbCrLf

        sSQL &= "Update D13T9000 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription04, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Short = " & SQLStringUnicode(txtShort04, False) & COMMA 'varchar[20], NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription04, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "ShortU = " & SQLStringUnicode(txtShort04, True) & COMMA 'varchar[20], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled04.Checked = True, 0, 1)) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "Type = " & SQLString("PMACC") & " And "
        sSQL &= "Code = " & SQLString(txtCode04.Text) & vbCrLf

        sSQL &= "Update D13T9000 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription05, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Short = " & SQLStringUnicode(txtShort05, False) & COMMA 'varchar[20], NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription05, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "ShortU = " & SQLStringUnicode(txtShort05, True) & COMMA 'varchar[20], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled05.Checked = True, 0, 1)) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "Type = " & SQLString("PMACC") & " And "
        sSQL &= "Code = " & SQLString(txtCode05.Text) & vbCrLf

        sSQL &= "Update D13T9000 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription06, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Short = " & SQLStringUnicode(txtShort06, False) & COMMA 'varchar[20], NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription06, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "ShortU = " & SQLStringUnicode(txtShort06, True) & COMMA 'varchar[20], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled06.Checked = True, 0, 1)) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "Type = " & SQLString("PMACC") & " And "
        sSQL &= "Code = " & SQLString(txtCode06.Text) & vbCrLf

        sSQL &= "Update D13T9000 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription07, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Short = " & SQLStringUnicode(txtShort07, False) & COMMA 'varchar[20], NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription07, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "ShortU = " & SQLStringUnicode(txtShort07, True) & COMMA 'varchar[20], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled07.Checked = True, 0, 1)) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "Type = " & SQLString("PMACC") & " And "
        sSQL &= "Code = " & SQLString(txtCode07.Text) & vbCrLf

        sSQL &= "Update D13T9000 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription08, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Short = " & SQLStringUnicode(txtShort08, False) & COMMA 'varchar[20], NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription08, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "ShortU = " & SQLStringUnicode(txtShort08, True) & COMMA 'varchar[20], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled08.Checked = True, 0, 1)) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "Type = " & SQLString("PMACC") & " And "
        sSQL &= "Code = " & SQLString(txtCode08.Text) & vbCrLf

        sSQL &= "Update D13T9000 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription09, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Short = " & SQLStringUnicode(txtShort09, False) & COMMA 'varchar[20], NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription09, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "ShortU = " & SQLStringUnicode(txtShort09, True) & COMMA 'varchar[20], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled09.Checked = True, 0, 1)) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "Type = " & SQLString("PMACC") & " And "
        sSQL &= "Code = " & SQLString(txtCode09.Text) & vbCrLf

        sSQL &= "Update D13T9000 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription10, False) & COMMA 'varchar[150], NOT NULL
        sSQL &= "Short = " & SQLStringUnicode(txtShort10, False) & COMMA 'varchar[20], NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription10, True) & COMMA 'varchar[150], NOT NULL
        sSQL &= "ShortU = " & SQLStringUnicode(txtShort10, True) & COMMA 'varchar[20], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled10.Checked = True, 0, 1)) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "Type = " & SQLString("PMACC") & " And "
        sSQL &= "Code = " & SQLString(txtCode10.Text) & vbCrLf
        Return sSQL
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""

        sSQL = SQLUpdateD13T9000()

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            btnClose.Focus()
        Else
            SaveNotOK()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F0040_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        FormKeyPress(sender, e)
    End Sub

    Private Sub D13F0040_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Loadlanguage()
        CheckPermission()
        InputbyUnicode(Me, gbUnicode)
        LoadEdit()
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_nghia_cac_tai_khoan_chuyen_but_toan_-_D13F0040") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa cÀc tªi kho¶n chuyÓn bòt toÀn - D13F0040
        '================================================================ 
        lbl1.Text = rl3("Dien_giai") 'Diễn giải
        lbl2.Text = rl3("Ten_tat") 'Tên tắt
        lbl3.Text = rl3("Su_dung") 'Sử dụng
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 

    End Sub

    Protected Sub CheckPermission()
        Dim per As Integer = ReturnPermission(Me.Name) 'Dùng kiểm tra form đang ở quyền nào
        If per = 1 Then
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If
    End Sub
End Class