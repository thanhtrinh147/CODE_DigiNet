Public Class D45F0020
    Dim bHeadClick As Boolean = False

#Region "Const of tdbg"
    Private Const COL_OrderNum As Integer = 0    ' STT
    Private Const COL_Description As Integer = 1 ' Diễn giải
    Private Const COL_ShortName As Integer = 2   ' Tên tắt
    Private Const COL_Name84 As Integer = 3      ' Tên tiếng Việt
    Private Const COL_Name01 As Integer = 4      ' Tên tiếng Anh
    Private Const COL_Disabled As Integer = 5    ' Sử dụng
    Private Const COL_Code As Integer = 6        ' Code
#End Region

    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub D45F0020_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D45F0020_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        tdbg_LockedColumns()
        LoadTDBGrid()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_nghia_cac_khoan_thu_nhap_luong_san_pham_-_D45F0020") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa cÀc kho¶n thu nhËp l§¥ng s¶n phÈm - D45F0020
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        tdbg.Columns("OrderNum").Caption = rl3("STT") 'STT
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("ShortName").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg.Columns("Name84").Caption = rl3("Ten_tieng_Viet") 'Tên tiếng Việt
        tdbg.Columns("Name01").Caption = rl3("Ten_tieng_Anh") 'Tên tiếng Anh
        tdbg.Columns("Disabled").Caption = rl3("Su_dung") 'Sử dụng
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String
        sSQL = "Select Cast(Right(Code,3) As Int) OrderNum, Code, "
        sSQL &= IIf(geLanguage = EnumLanguage.Vietnamese, "Description84" & UnicodeJoin(gbUnicode), "Description01" & UnicodeJoin(gbUnicode)).ToString & " As Description, "
        sSQL &= "ShortName" & UnicodeJoin(gbUnicode) & " as ShortName, Name84" & UnicodeJoin(gbUnicode) & "  as Name84, Name01" & UnicodeJoin(gbUnicode) & " as Name01, Convert(Bit,(Case Disabled When 0 Then 1 Else 0 End)) As Disabled" & vbCrLf
        sSQL &= "From D45T0020 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Type='PWCAL'" & vbCrLf
        sSQL &= "Order by Code"
        LoadDataSource(tdbg, sSQL, gbUnicode)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
       

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
      
        sSQL.Append(SQLUpdateD45T0020s.ToString)

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
    '# Title: SQLUpdateD45T0020s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 19/10/2009 09:02:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T0020s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Update D45T0020 Set ")
            sSQL.Append("Name84 = " & SQLStringUnicode(tdbg(i, COL_Name84).ToString, gbUnicode, False) & COMMA) 'varchar[250], NULL
            sSQL.Append("Name84U = " & SQLStringUnicode(tdbg(i, COL_Name84).ToString, gbUnicode, True) & COMMA) 'varchar[250], NULL
            sSQL.Append("Name01 = " & SQLStringUnicode(tdbg(i, COL_Name01).ToString, gbUnicode, False) & COMMA) 'varchar[250], NULL
            sSQL.Append("Name01U = " & SQLStringUnicode(tdbg(i, COL_Name01).ToString, gbUnicode, True) & COMMA) 'varchar[250], NULL
            sSQL.Append("ShortName = " & SQLStringUnicode(tdbg(i, COL_ShortName).ToString, gbUnicode, False) & COMMA) 'varchar[100], NULL
            sSQL.Append("ShortNameU = " & SQLStringUnicode(tdbg(i, COL_ShortName).ToString, gbUnicode, True) & COMMA) 'varchar[100], NULL
            sSQL.Append("Disabled = " & SQLNumber(IIf(CBool(tdbg(i, COL_Disabled)), 0, 1).ToString) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
            sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
            sSQL.Append(" Where ")
            sSQL.Append("Type='PWCAL' And Code = " & SQLString(tdbg(i, COL_Code)))

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then
            Return
        End If
        Select Case e.ColIndex
            Case COL_Disabled
                bHeadClick = Not bHeadClick
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, COL_Disabled) = bHeadClick
                Next
            Case COL_Name84, COL_Name01, COL_ShortName
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Value.ToString, tdbg.Bookmark)
                Exit Sub
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Su dung Enter di chuyen den o duoi o hien hanh
            If D45Options.UseEnterMoveDown Then Exit Sub
            If tdbg.Col = COL_Disabled Then HotKeyEnterGrid(tdbg, COL_ShortName, e)
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.S Then
            Select Case tdbg.Col
                Case COL_Name84, COL_Name01, COL_ShortName
                    CopyColumns(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Value.ToString, tdbg.Bookmark)
            End Select
        End If
    End Sub
End Class