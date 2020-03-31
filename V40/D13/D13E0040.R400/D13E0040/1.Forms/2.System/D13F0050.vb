Imports System.Text
Public Class D13F0050

#Region "Const of tdbgMaster"
    Private Const COL_PAnaCategoryID As Integer = 0     ' Mã loại phân tích
    Private Const COL_PAnaCategoryName84 As Integer = 1 ' Diễn giải
    Private Const COL_PAnaCategoryName01 As Integer = 2 ' Diễn giải
    Private Const COL_PAnaCategoryShort As Integer = 3  ' Tên tắt
    Private Const COL_IsUsed As Integer = 4           ' Không sử dụng
    Private Const COL_CreatedUserID As Integer = 5      ' Người tạo
    Private Const COL_CreateDate As Integer = 6         ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 7   ' Người chỉnh sửa
    Private Const COL_LastModifyDate As Integer = 8     ' Ngày chỉnh sửa
#End Region

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ma_loai_phan_tich_tien_luong_-_D13F0050") & UnicodeCaption(gbUnicode) 'Mº loÁi ph¡n tÛch tiÒn l§¥ng - D13F0050
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbgMaster.Columns("PAnaCategoryID").Caption = rl3("Ma_loai_phan_tich") 'Mã loại phân tích
        tdbgMaster.Columns("PAnaCategoryName84").Caption = rl3("Dien_giai") 'Diễn giải
        tdbgMaster.Columns("PAnaCategoryName01").Caption = rl3("Dien_giai") 'Diễn giải
        tdbgMaster.Columns("PAnaCategoryShort").Caption = rl3("Ten_tat") 'Tên tắt
        tdbgMaster.Columns("IsUsed").Caption = rl3("Su_dung") 'Sử dụng

    End Sub

    Private Sub D13F0050_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResetFooterGrid(tdbgMaster, 0, 0)
        Loadlanguage()
        btnSave.Enabled = ReturnPermission(Me.Name) > EnumPermission.View
        UnicodeGridDataField(tdbgMaster, UnicodeArrayCOL(), gbUnicode)
        LoadTDBGrid()
        tdbgMaster_LockedColumns()
        If gsLanguage = "84" Then
            tdbgMaster.Splits(0).DisplayColumns(COL_PAnaCategoryName01).Visible = False
            tdbgMaster.Splits(0).DisplayColumns(COL_PAnaCategoryName84).Visible = True
        ElseIf gsLanguage = "01" Then
            tdbgMaster.Splits(0).DisplayColumns(COL_PAnaCategoryName01).Visible = True
            tdbgMaster.Splits(0).DisplayColumns(COL_PAnaCategoryName84).Visible = False
        End If
        SetResolutionForm(Me)
    End Sub

    Private Function UnicodeArrayCOL() As Integer()
        If Not gbUnicode Then Return Nothing
        Dim ArrCOL() As Integer = {COL_PAnaCategoryShort, COL_PAnaCategoryName01, COL_PAnaCategoryName84}
        Return ArrCOL
    End Function

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        Dim dt As DataTable
        sSQL &= "SELECT PAnaCategoryID, PAnaCategoryName84, PAnaCategoryName01, PAnaCategoryName84U, PAnaCategoryName01U,"
        sSQL &= " PAnaCategoryShort, PAnaCategoryShortU, CAST((CASE WHEN Disabled = 0 THEN 1 ELSE 0 END) as BIT) AS IsUsed, CreateUserID, CreateDate,"
        sSQL &= " LastModifyUserID, LastModifyDate"
        sSQL &= " FROM D13T0050 WITH (NOLOCK) "
        sSQL &= " ORDER BY PAnaCategoryID"
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbgMaster, dt, gbUnicode)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLUpdateD13T0050s().ToString & vbCrLf)

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

    Private Function AllowSave() As Boolean
        If tdbgMaster.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgMaster.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbgMaster.RowCount - 1
            If tdbgMaster(i, COL_PAnaCategoryName84).ToString = "" Then
                D99C0008.MsgNotYetEnter("Diễn giải")
                tdbgMaster.SplitIndex = SPLIT0
                tdbgMaster.Col = COL_PAnaCategoryName84
                tdbgMaster.Bookmark = i
                tdbgMaster.Focus()
                Return False
            End If
            If tdbgMaster(i, COL_PAnaCategoryName01).ToString = "" Then
                D99C0008.MsgNotYetEnter("Diễn giải")
                tdbgMaster.SplitIndex = SPLIT0
                tdbgMaster.Col = COL_PAnaCategoryName01
                tdbgMaster.Bookmark = i
                tdbgMaster.Focus()
                Return False
            End If
            If tdbgMaster(i, COL_PAnaCategoryShort).ToString = "" Then
                D99C0008.MsgNotYetEnter("Tên tắt")
                tdbgMaster.SplitIndex = SPLIT0
                tdbgMaster.Col = COL_PAnaCategoryShort
                tdbgMaster.Bookmark = i
                tdbgMaster.Focus()
                Return False
            End If
        Next
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0050s
    '# Created User: 
    '# Created Date: 16/11/2007 04:52:15
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0050s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbgMaster.RowCount - 1

            sSQL.Append("Update D13T0050 Set ")
            sSQL.Append("PAnaCategoryName01 = " & SQLStringUnicode(tdbgMaster(i, COL_PAnaCategoryName01), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("PAnaCategoryName84 = " & SQLStringUnicode(tdbgMaster(i, COL_PAnaCategoryName84), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("PAnaCategoryShort = " & SQLStringUnicode(tdbgMaster(i, COL_PAnaCategoryShort), gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("PAnaCategoryName01U = " & SQLStringUnicode(tdbgMaster(i, COL_PAnaCategoryName01), gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("PAnaCategoryName84U = " & SQLStringUnicode(tdbgMaster(i, COL_PAnaCategoryName84), gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("PAnaCategoryShortU = " & SQLStringUnicode(tdbgMaster(i, COL_PAnaCategoryShort), gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("Disabled = " & SQLNumber(Not L3Bool(tdbgMaster(i, COL_IsUsed))) & COMMA) 'tinyint, NOT NULL
            If tdbgMaster(i, COL_CreatedUserID).ToString = "" Then
                sSQL.Append("CreateUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
            End If
            If tdbgMaster(i, COL_CreateDate).ToString = "" Then
                sSQL.Append("CreateDate = GetDate()" & COMMA) 'datetime, NULL
            End If
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
            sSQL.Append(" Where ")
            sSQL.Append("PAnaCategoryID = " & SQLString(tdbgMaster(i, COL_PAnaCategoryID)))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbgMaster_LockedColumns()
        tdbgMaster.Splits(0).DisplayColumns(COL_PAnaCategoryID).Locked = True
        tdbgMaster.Splits(0).DisplayColumns(COL_PAnaCategoryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

End Class