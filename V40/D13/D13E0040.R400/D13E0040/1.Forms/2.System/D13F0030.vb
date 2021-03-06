Public Class D13F0030

#Region "Const of tdbg"
    Private Const COL_Code As Integer = 0        ' Mã
    Private Const COL_OrderNum As Integer = 1    ' STT
    Private Const COL_Description As Integer = 2 ' Diễn giải
    Private Const COL_Short As Integer = 3       ' Tên tắt
    Private Const COL_Disabled As Integer = 4    ' Sử dụng
#End Region

    Private Sub LoadTDBGrid()
        Dim s As String = ""
        ' update 11/6/2013 id 56314
        s = "Select Convert(Smallint, Substring(Code,4, LEN(Code)-3)) OrderNum, Code, Description, DescriptionU, Short, ShortU, convert(bit,(case Disabled when 0 then 1 else 0 end)) as [Disabled] from D13T9000  WITH (NOLOCK) where type = 'PRCAL' order by OrderNum"
        ' s = "Select Right(Code,2) OrderNum, Code, Description, DescriptionU, Short, ShortU, convert(bit,(case Disabled when 0 then 1 else 0 end)) as [Disabled] from D13T9000 where type = 'PRCAL' order by Code"
        Dim dt As DataTable = ReturnDataTable(s)
        LoadDataSource(tdbg, dt, gbUnicode)

        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, COL_OrderNum) = i + 1
        Next
        tdbg.Splits(0).DisplayColumns(COL_OrderNum).Locked = True
        FooterTotalGrid(tdbg, COL_Description)
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_Disabled).ToString) = True Then
                If tdbg(i, COL_Description).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_Description
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If

            If tdbg(i, COL_Description).ToString <> "" Then
                If Len(tdbg(i, COL_Description)) > 150 Then
                    D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_Description
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If
            If CBool(tdbg(i, COL_Disabled).ToString) = True Then
                If tdbg(i, COL_Short).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_Short
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If

            If tdbg(i, COL_Short).ToString <> "" Then
                If Len(tdbg(i, COL_Short)) > 20 Then
                    D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_Short
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""

        sSQL = SQLUpdateD13T9000s()

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
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T9000s
    '# Created User: Lý Anh Vĩ
    '# Created Date: 11/01/2007 02:58:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T9000s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL = ""
            sSQL &= "Update D13T9000 Set "
            sSQL &= "Description = " & SQLStringUnicode(tdbg(i, COL_Description).ToString, gbUnicode, False) & COMMA 'varchar[150], NOT NULL
            sSQL &= "Short = " & SQLStringUnicode(tdbg(i, COL_Short).ToString, gbUnicode, False) & COMMA 'varchar[20], NULL
            sSQL &= "DescriptionU = " & SQLStringUnicode(tdbg(i, COL_Description).ToString, gbUnicode, True) & COMMA 'varchar[150], NOT NULL
            sSQL &= "ShortU = " & SQLStringUnicode(tdbg(i, COL_Short).ToString, gbUnicode, True) & COMMA 'varchar[20], NULL
            sSQL &= "Disabled = " & SQLNumber(IIf(Convert.ToBoolean(tdbg(i, COL_Disabled)) = True, 0, 1)) 'tinyint, NOT NULL
            sSQL &= " Where "
            sSQL &= "Type = " & SQLString("PRCAL") & " And "
            sSQL &= "Code = " & SQLString(tdbg(i, COL_Code).ToString)
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function

    Private Sub D13F0030_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ResetFooterGrid(tdbg, 0, 0)
        Loadlanguage()
        UnicodeGridDataField(tdbg, UnicodeArrayCOL(), gbUnicode)
        LoadTDBGrid()
        tdbg_LockedColumns()
        CheckPermission()
        SetResolutionForm(Me)
    End Sub

    Private Function UnicodeArrayCOL() As Integer()
        If Not gbUnicode Then Return Nothing
        Dim ArrCOL() As Integer = {COL_Description, COL_Short}
        Return ArrCOL
    End Function


    Protected Sub CheckPermission()
        Dim per As Integer = ReturnPermission(Me.Name) 'Dùng kiểm tra form đang ở quyền nào
        If per = 1 Then
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_nghia_cac_khoan_thu_nhap_-_D13F0030") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa cÀc kho¶n thu nhËp - D13F0030
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbg.Columns("OrderNum").Caption = rl3("STT") 'STT
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("Short").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg.Columns("Disabled").Caption = rl3("Su_dung") 'Sử dụng
    End Sub


    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_Description, COL_Short, COL_Disabled
                tdbg.AllowSort = False
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_Disabled
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub



End Class