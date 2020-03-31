﻿Imports System
Imports System.Text
Public Class D25F0050

    Private _moduleID As String = ""
    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            _moduleID = Value
        End Set
    End Property

    Private _formIDPermission As String = "D25F0050"
    Public WriteOnly Property formIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

#Region "Const of tdbgU - Total of Columns: 4"
    Private Const COL_RefID As String = "RefID"           ' RefID
    Private Const COL_OrderNum As Integer = 1             ' STT
    Private Const COL_RefCaption As String = "RefCaption" ' Diễn giải
    Private Const COL_Disabled As String = "Disabled"     ' KSD
#End Region

#Region "Const of tdbgPropose - Total of Columns: 4"
    Private Const COLP_RefID As Integer = 0      ' RefID
    Private Const COLP_OrderNum As Integer = 1   ' STT
    Private Const COLP_RefCaption As Integer = 2 ' Diễn giải
    Private Const COLP_Disabled As Integer = 3   ' KSD
#End Region

#Region "Const of tdbgResult - Total of Columns: 4"
    Private Const COLR_RefID As Integer = 0      ' RefID
    Private Const COLR_OrderNum As Integer = 1   ' STT
    Private Const COLR_RefCaption As Integer = 2 ' Diễn giải
    Private Const COLR_Disabled As Integer = 3   ' KSD
#End Region

#Region "Const of tdbgIdentification - Total of Columns: 5"
    Private Const COLI_TableName As String = "TableName"   ' TableName
    Private Const COLI_OrderNum As Integer = 1             ' STT
    Private Const COLI_RefID As String = "RefID"           ' Mã tham chiếu
    Private Const COLI_RefCaption As String = "RefCaption" ' Diễn giải
    Private Const COLI_Disabled As String = "Disabled"     ' KSD
#End Region

#Region "Const of tdbg6 - Total of Columns: 4"
    Private Const COL6_RefID As Integer = 0      ' RefID
    Private Const COL6_OrderNum As Integer = 1   ' STT
    Private Const COL6_RefCaption As Integer = 2 ' Diễn giải
    Private Const COL6_Disabled As Integer = 3   ' KSD
#End Region




    Private Sub D25F0050_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        End If

        If e.Alt = True And (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
            tabMain.SelectedIndex = 0
            tabMain.Focus()
        ElseIf e.Alt = True And (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
            If _moduleID = "38" Then Exit Sub
            tabMain.SelectedIndex = 1
            tabMain.Focus()
        ElseIf e.Alt = True And (e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3) Then
            If _moduleID <> "38" Then Exit Sub
            tabMain.SelectedIndex = 2
            tabMain.Focus()
        ElseIf e.Alt = True And (e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3) Then
            If _moduleID <> "38" Then Exit Sub
            tabMain.SelectedIndex = 3
            tabMain.Focus()
        End If
    End Sub

    Private Sub D25F0050_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        tdbg_LockedColumns()
        InputbyUnicode(Me, gbUnicode)
        LoadTDBGrid()
        Loadlanguage()
        btnSave.Enabled = ReturnPermission(_formIDPermission) > EnumPermission.View
        '***************
        If _moduleID <> "38" Then
            tabMain.TabPages.Remove(Tab4)
            tabMain.TabPages.Remove(Tab3)
            Tab1.Text = "1. " & rL3("De_xuat_tuyen_dung")
            Tab2.Text = "2. " & rL3("Ket_qua_phong_van")
            Tab5.Text = "3. " & rL3("Giay_to_tuy_than_") 'Giấy tờ tùy thân
            Tab6.Text = "4. " & rL3("Cong_thong_tin_ung_vien") 'Cổng thông tin ứng viên
        Else
            Tab3.Text = "1. " & rL3("De_xuat_Ke_hoach_dao_tao") 'Đề xuất/ Kế hoạch đào tạo
            Tab4.Text = "2. " & rL3("Cap_nhat_ket_qua_dao_tao")
            tabMain.TabPages.Remove(Tab6)
            tabMain.TabPages.Remove(Tab5)
            tabMain.TabPages.Remove(Tab2)
            tabMain.TabPages.Remove(Tab1)
        End If
        HotkeyAltTabControl(tabMain)
        SetResolutionForm(Me)
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Thiet_lap_thong_tin_tham_chieu") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'ThiÕt lËp th¤ng tin tham chiÕu
        If _moduleID = "38" Then
            Me.Text = rL3("Thiet_lap_thong_tin_tham_chieu") & " - " & "D38F0050" & UnicodeCaption(gbUnicode) 'ThiÕt lËp th¤ng tin tham chiÕu
        End If
        '================================================================ 
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        Tab1.Text = "1. " & rL3("De_xuat_tuyen_dung") 'Đề xuất tuyển dụng
        Tab2.Text = "2. " & rL3("Ket_qua_phong_van") 'Kết quả phỏng vấn
        Tab3.Text = "3. " & rL3("De_xuat_Ke_hoach_dao_tao") 'Đề xuất/ Kế hoạch đào tạo
        Tab4.Text = "4. " & rL3("Cap_nhat_ket_qua_dao_tao") 'Cập nhật kết quả đào tạo
        Tab5.Text = "5. " & rL3("Giay_to_tuy_than_") 'Giấy tờ tùy thân
        '================================================================ 
        tdbgPropose.Columns(COLP_OrderNum).Caption = rL3("STT") 'STT
        tdbgPropose.Columns(COLP_RefCaption).Caption = rL3("Dien_giai") 'Diễn giải
        tdbgPropose.Columns(COLP_Disabled).Caption = rL3("KSD") 'KSD
        '================================================================ 
        tdbgResult.Columns(COLR_OrderNum).Caption = rL3("STT") 'STT
        tdbgResult.Columns(COLR_RefCaption).Caption = rL3("Dien_giai") 'Diễn giải
        tdbgResult.Columns(COLR_Disabled).Caption = rL3("KSD") 'KSD
        '================================================================ 
        tdbgRef.Columns(COLR_OrderNum).Caption = rL3("STT") 'STT
        tdbgRef.Columns(COLR_RefCaption).Caption = rL3("Dien_giai") 'Diễn giải
        tdbgRef.Columns(COLR_Disabled).Caption = rL3("KSD") 'KSD
        '================================================================ 
        tdbgU.Columns(COL_OrderNum).Caption = rL3("STT") 'STT
        tdbgU.Columns(COL_RefCaption).Caption = rL3("Dien_giai") 'Diễn giải
        tdbgU.Columns(COL_Disabled).Caption = rL3("KSD") 'KSD
        '================================================================ 
        tdbgIdentification.Columns(COLI_OrderNum).Caption = rL3("STT") 'STT
        tdbgIdentification.Columns(COLI_RefID).Caption = rL3("Ma_tham_chieu") 'Mã tham chiếu
        tdbgIdentification.Columns(COLI_RefCaption).Caption = rL3("Dien_giai") 'Diễn giải
        tdbgIdentification.Columns(COLI_Disabled).Caption = rL3("KSD") 'KSD

        '================================================================ 
        '================================================================ 
        Tab6.Text = "6. " & rL3("Cong_thong_tin_ung_vien") 'Cổng thông tin ứng viên

        '================================================================ 
        tdbg6.Columns(COL_OrderNum).Caption = rL3("STT") 'STT
        tdbg6.Columns(COL6_RefCaption).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg6.Columns(COL6_Disabled).Caption = rL3("KSD") 'KSD

    End Sub

    Private Sub tdbg_LockedColumns()
        tdbgPropose.Splits(SPLIT0).DisplayColumns(COLP_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgResult.Splits(SPLIT0).DisplayColumns(COLR_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgRef.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgU.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgIdentification.Splits(SPLIT0).DisplayColumns(COLI_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg6.Splits(SPLIT0).DisplayColumns(COL6_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadTDBGrid()
        Dim dt As DataTable = ReturnDataTable(SQLStoreD25P0050)

        If _moduleID = "38" Then
            LoadDataSource(tdbgRef, ReturnTableFilter(dt, "TableName='D38T2000'", True), gbUnicode)
            LoadDataSource(tdbgU, ReturnTableFilter(dt, "TableName='D38T2040'", True), gbUnicode)
        Else
            LoadDataSource(tdbgPropose, ReturnTableFilter(dt, "TableName='D25T2001'", True), gbUnicode)
            LoadDataSource(tdbgResult, ReturnTableFilter(dt, "TableName='D25T2011'", True), gbUnicode)
            LoadDataSource(tdbgIdentification, ReturnTableFilter(dt, "TableName='D25T1055'", True), gbUnicode) 'ID 93232 16/01/2017
            LoadDataSource(tdbg6, ReturnTableFilter(dt, "TableName='D25T1045'", True), gbUnicode) 'ID 116548 18/01/2019
        End If
    End Sub

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLStoreD25P0050
    ''# Created User: Đỗ Minh Dũng
    ''# Created Date: 09/01/2009 02:16:52
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: 
    ''#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD25P0050() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P0050 "
        sSQL &= SQLString("%") & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

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
        If _moduleID = "38" Then
            For i As Integer = 0 To tdbgResult.RowCount - 1
                sSQL.Append("Update D25T0050 Set ")
                sSQL.Append("RefCaption = " & SQLStringUnicode(tdbgRef(i, COL_RefCaption), gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
                sSQL.Append("RefCaptionU = " & SQLStringUnicode(tdbgRef(i, COL_RefCaption), gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
                sSQL.Append("Disabled = " & SQLNumber(tdbgRef(i, COL_Disabled))) 'tinyint, NOT NULL
                sSQL.Append(" Where ")
                sSQL.Append("RefID = " & SQLString(tdbgRef(i, COL_RefID)))
                sSQL.Append(" And TableName = 'D38T2000'")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            Next
            For i As Integer = 0 To tdbgU.RowCount - 1
                sSQL.Append("Update D25T0050 Set ")
                sSQL.Append("RefCaption = " & SQLStringUnicode(tdbgU(i, COL_RefCaption), gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
                sSQL.Append("RefCaptionU = " & SQLStringUnicode(tdbgU(i, COL_RefCaption), gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
                sSQL.Append("Disabled = " & SQLNumber(tdbgU(i, COL_Disabled))) 'tinyint, NOT NULL
                sSQL.Append(" Where ")
                sSQL.Append("RefID = " & SQLString(tdbgU(i, COL_RefID)))
                sSQL.Append(" And TableName = 'D38T2040'")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            Next
        Else
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

            For i As Integer = 0 To tdbgIdentification.RowCount - 1 'ID	93232 16/01/2017
                sSQL.Append("Update D25T0050 Set ")
                sSQL.Append("RefCaption = " & SQLStringUnicode(tdbgIdentification(i, COLI_RefCaption), gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
                sSQL.Append("RefCaptionU = " & SQLStringUnicode(tdbgIdentification(i, COLI_RefCaption), gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
                sSQL.Append("Disabled = " & SQLNumber(tdbgIdentification(i, COLI_Disabled))) 'tinyint, NOT NULL
                sSQL.Append(" Where ")
                sSQL.Append("RefID = " & SQLString(tdbgIdentification(i, COLI_RefID)))
                sSQL.Append(" And TableName = 'D25T1055'")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            Next

            For i As Integer = 0 To tdbg6.RowCount - 1
                sSQL.Append("Update D25T0050 Set ")
                sSQL.Append("RefCaption = " & SQLStringUnicode(tdbg6(i, COL6_RefCaption), gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
                sSQL.Append("RefCaptionU = " & SQLStringUnicode(tdbg6(i, COL6_RefCaption), gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
                sSQL.Append("Disabled = " & SQLNumber(tdbg6(i, COL6_Disabled))) 'tinyint, NOT NULL
                sSQL.Append(" Where ")
                sSQL.Append("RefID = " & SQLString(tdbg6(i, COL6_RefID)))
                sSQL.Append(" And TableName = 'D25T1045'")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            Next
        End If
        Return sRet
    End Function

    Private Function AllowSave() As Boolean
        If _moduleID = "38" Then
            For i As Integer = 0 To tdbgRef.RowCount - 1
                If CBool(tdbgRef(i, COL_Disabled)) = False Then
                    If tdbgRef(i, COL_RefCaption).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rL3("Dien_giai_tham_chieu"))
                        tabMain.SelectedIndex = 2
                        tdbgRef.SplitIndex = SPLIT0
                        tdbgRef.Col = IndexOfColumn(tdbgRef, COL_RefCaption)
                        tdbgRef.Bookmark = i
                        tdbgRef.Focus()
                        Return False
                    End If
                End If
            Next
            For i As Integer = 0 To tdbgU.RowCount - 1
                If CBool(tdbgU(i, COL_Disabled)) = False Then
                    If tdbgU(i, COL_RefCaption).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rL3("Dien_giai_tham_chieu"))
                        tabMain.SelectedIndex = 2
                        tdbgU.SplitIndex = SPLIT0
                        tdbgU.Col = IndexOfColumn(tdbgU, COL_RefCaption)
                        tdbgU.Bookmark = i
                        tdbgU.Focus()
                        Return False
                    End If
                End If
            Next
        Else
            If tdbgPropose.RowCount <= 0 Then
                D99C0008.MsgNoDataInGrid()
                tdbgPropose.Focus()
                Return False
            End If
            For i As Integer = 0 To tdbgPropose.RowCount - 1
                If CBool(tdbgPropose(i, COLP_Disabled)) = False Then
                    If tdbgPropose(i, COLP_RefCaption).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rL3("Dien_giai_tham_chieu"))
                        tabMain.SelectedIndex = 0
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
                        D99C0008.MsgNotYetEnter(rL3("Dien_giai_tham_chieu"))
                        tabMain.SelectedIndex = 1
                        tdbgResult.SplitIndex = SPLIT0
                        tdbgResult.Col = COLR_RefCaption
                        tdbgResult.Bookmark = i
                        tdbgResult.Focus()
                        Return False
                    End If
                End If
            Next

           

            For i As Integer = 0 To tdbgIdentification.RowCount - 1  'ID	93232 16/01/2017
                If tdbgIdentification(i, COLI_RefCaption).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbgIdentification.Columns(COLI_RefCaption).Caption)
                    tdbgIdentification.Focus()
                    tdbgIdentification.SplitIndex = 0
                    tdbgIdentification.Col = IndexOfColumn(tdbgIdentification, COLI_RefCaption)
                    tdbgIdentification.Row = i  'findrowInGrid(tdbgIdentification, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
            Next

            For i As Integer = 0 To tdbg6.RowCount - 1
                If CBool(tdbg6(i, COL6_Disabled)) = False Then
                    If tdbg6(i, COL6_RefCaption).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rL3("Dien_giai_tham_chieu"))
                        tabMain.SelectedIndex = 3
                        tdbg6.SplitIndex = SPLIT0
                        tdbg6.Col = COL6_RefCaption
                        tdbg6.Bookmark = i
                        tdbg6.Focus()
                        Return False
                    End If
                End If
            Next
        End If
        Return True
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbgPropose.UpdateData()
        tdbgResult.UpdateData()
        tdbgIdentification.UpdateData()
        tdbgRef.UpdateData()
        tdbgU.UpdateData()
        tdbg6.UpdateData()

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

    'DataField của cột ="" nên phải khai báo cột kiểu Integer
    Private Sub tdbgPropose_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbgPropose.UnboundColumnFetch
        Select Case e.Col
            Case COLP_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString

        End Select
    End Sub

    'DataField của cột ="" nên phải khai báo cột kiểu Integer
    Private Sub tdbgResult_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbgResult.UnboundColumnFetch
        Select Case e.Col
            Case COLR_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub
    'DataField của cột ="" nên phải khai báo cột kiểu Integer
    Private Sub tdbgRef_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbgRef.UnboundColumnFetch
        Select Case e.Col
            Case COL_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub

    'DataField của cột ="" nên phải khai báo cột kiểu Integer
    Private Sub tdbgU_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbgU.UnboundColumnFetch
        Select Case e.Col
            Case COL_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub

    'DataField của cột ="" nên phải khai báo cột kiểu Integer
    Private Sub tdbgIdentification_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbgIdentification.UnboundColumnFetch
        Select Case e.Col
            Case COLI_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub

    'DataField của cột ="" nên phải khai báo cột kiểu Integer
    Private Sub tdbg6_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg6.UnboundColumnFetch
        Select Case e.Col
            Case COL6_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub

End Class