Imports System.Text
Public Class D25F0050

#Region "Const of tdbgPropose"
    Private Const COLP_RefID As Integer = 0      ' RefID
    Private Const COLP_Order As Integer = 1      ' STT
    Private Const COLP_RefCaption As Integer = 2 ' Diễn giải
    Private Const COLP_Disabled As Integer = 3   ' Không sử dụng
#End Region

#Region "Const of tdbgResult"
    Private Const COLR_RefID As Integer = 0      ' RefID
    Private Const COLR_Order As Integer = 1      ' STT
    Private Const COLR_RefCaption As Integer = 2 ' Diễn giải
    Private Const COLR_Disabled As Integer = 3   ' Không sử dụng
#End Region

    Private Sub D25F0050_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        End If

        If e.Alt = True And (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
            tab1.SelectedIndex = 0
            tab1.Focus()
        End If

        If e.Alt = True And (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
            tab1.SelectedIndex = 1
            tab1.Focus()
        End If
    End Sub

    Private Sub D25F0050_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tdbg_LockedColumns()
        LoadTDBGrid()
        Loadlanguage()
        btnSave.Enabled = ReturnPermission("D25F0050") > EnumPermission.View
        '*****
        'Phải bỏ khai báo hằng của cột cần chuyển sang Unicode (bỏ Const khai báo cột)
        'Bổ sung nhập liệu Unicode: hàm này để sau hàm LoadLanguage
        UnicodeGridDataField(tdbgPropose, UnicodeArrayCOL_tdbgPropose(), gbUnicode) 'sửa dataField và hằng của 1 cột
        UnicodeGridDataField(tdbgResult, UnicodeArrayCOL_tdbgResult(), gbUnicode) 'sửa dataField và hằng của 1 cột
        '***************
        SetResolutionForm(Me)
    End Sub

    Private Function UnicodeArrayCOL_tdbgPropose() As Integer()
        If Not gbUnicode Then Return Nothing

        Dim ArrCOL() As Integer = {COLP_RefCaption}

        Return ArrCOL
    End Function

    Private Function UnicodeArrayCOL_tdbgResult() As Integer()
        If Not gbUnicode Then Return Nothing

        Dim ArrCOL() As Integer = {COLR_RefCaption}

        Return ArrCOL
    End Function

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = r("Thiet_lap_thong_tin_tham_chieu_-_D25F0050") & UnicodeCaption(gbUnicode) 'ThiÕt lËp th¤ng tin tham chiÕu - D25F0050
        '=============================================================== 
        btnSave.Text = r("_Luu") '&Lưu
        btnClose.Text = r("Do_ng") 'Đó&ng
        '================================================================ 
        tdbgPropose.Columns("Order").Caption = r("STT") 'STT
        tdbgPropose.Columns("RefCaption").Caption = r("Dien_giai_tham_chieu") 'Diễn giải tham chiếu
        tdbgPropose.Columns("Disabled").Caption = r("Khong_su_dung") 'Không hiển thị
        '================================================================ 
        tdbgResult.Columns("Order").Caption = r("STT") 'STT
        tdbgResult.Columns("RefCaption").Caption = r("Dien_giai_tham_chieu") 'Diễn giải tham chiếu
        tdbgResult.Columns("Disabled").Caption = r("Khong_su_dung") 'Không hiển thị
        '================================================================ 
        TabPage1.Text = "1. " & r("De_xuat_tuyen_dung")
        TabPage2.Text = "2. " & r("Ket_qua_phong_van")
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbgPropose.Splits(SPLIT0).DisplayColumns(COLP_Order).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgResult.Splits(SPLIT0).DisplayColumns(COLR_Order).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadTDBGrid()
        LoadDataSource(tdbgPropose, SQLStoreD25P0050("D25T2001", gbUnicode), gbUnicode)
        LoadDataSource(tdbgResult, SQLStoreD25P0050("D25T2011", gbUnicode), gbUnicode)

        UpdateTDBGOrderNum(tdbgPropose, COLP_Order)
        UpdateTDBGOrderNum(tdbgResult, COLR_Order)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T0050s
    '# Created User: Lý Anh Vĩ
    '# Created Date: 18/04/2007 04:21:54
    '# Modified User: 09/01/09
    '# Modified Date: dmd
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T0050s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbgPropose.RowCount - 1
            sSQL.Append("Update D25T0050 Set ")
            sSQL.Append("RefCaption = " & SQLStringUnicode(tdbgPropose(i, COLP_RefCaption), gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("RefCaptionU = " & SQLStringUnicode(tdbgPropose(i, COLP_RefCaption), gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("Disabled = " & SQLNumber(tdbgPropose(i, COLP_Disabled))) 'tinyint, NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("RefID = " & SQLString(tdbgPropose(i, COLP_RefID)))
            sSQL.Append(" And TableName = 'D25T2001'")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next

        For i As Integer = 0 To tdbgResult.RowCount - 1
            sSQL.Append("Update D25T0050 Set ")
            sSQL.Append("RefCaption = " & SQLStringUnicode(tdbgResult(i, COLR_RefCaption), gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("RefCaptionU = " & SQLStringUnicode(tdbgResult(i, COLR_RefCaption), gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("Disabled = " & SQLNumber(tdbgResult(i, COLR_Disabled))) 'tinyint, NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("RefID = " & SQLString(tdbgResult(i, COLR_RefID)))
            sSQL.Append(" And TableName = 'D25T2011'")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    Private Function AllowSave() As Boolean
        If tdbgPropose.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgPropose.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbgPropose.RowCount - 1
            'If Len(tdbgPropose(i, COL_RefCaption)) > 50 Then
            '    D99C0008.MsgL3("Chiều dài Diễn giải không hợp lệ")
            '    tdbgPropose.SplitIndex = SPLIT0
            '    tdbgPropose.Col = COL_RefCaption
            '    tdbgPropose.Bookmark = i
            '    tdbgPropose.Focus()
            '    Return False
            'End If
            If CBool(tdbgPropose(i, COLP_Disabled)) = False Then
                If tdbgPropose(i, COLP_RefCaption).ToString = "" Then
                    D99C0008.MsgNotYetEnter(r("Dien_giai_tham_chieu"))
                    tab1.SelectedIndex = 0
                    tdbgPropose.SplitIndex = SPLIT0
                    tdbgPropose.Col = COLP_RefCaption
                    tdbgPropose.Bookmark = i
                    tdbgPropose.Focus()
                    Return False
                End If
            End If
        Next

        For i As Integer = 0 To tdbgResult.RowCount - 1
            If CBool(tdbgResult(i, COLR_Disabled)) = False Then
                If tdbgResult(i, COLR_RefCaption).ToString = "" Then
                    D99C0008.MsgNotYetEnter(r("Dien_giai_tham_chieu"))
                    tab1.SelectedIndex = 1
                    tdbgResult.SplitIndex = SPLIT0
                    tdbgResult.Col = COLR_RefCaption
                    tdbgResult.Bookmark = i
                    tdbgResult.Focus()
                    Return False
                End If
            End If
        Next

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbgPropose.UpdateData()
        tdbgResult.UpdateData()

        If Not AllowSave() Then Exit Sub
        btnSave.Enabled = False

        Dim sSQL As New StringBuilder
        sSQL.Append(SQLUpdateD25T0050s.ToString)

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnSave.Enabled = True
        Else
            SaveNotOK()
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub



End Class