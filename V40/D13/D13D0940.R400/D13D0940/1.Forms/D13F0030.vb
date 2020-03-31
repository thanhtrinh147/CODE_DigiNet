Imports System.Windows.Forms
Public Class D13F0030


#Region "Const of tdbg"
    Private Const COL_Code As Integer = 0        ' Mã
    Private Const COL_OrderNum As Integer = 1    ' STT
    Private Const COL_Description As Integer = 2 ' Diễn giải
    Private Const COL_Short As Integer = 3       ' Tên tắt
    Private Const COL_Disabled As Integer = 4    ' Sử dụng
    Private Const COL_IsUpdate As Integer = 5    ' IsUpdate
#End Region

#Region "Const of tdbg2 - Total of Columns: 10"
    Private Const COL2_Code As Integer = 0          ' Mã
    Private Const COL2_Description As Integer = 1   ' Diễn giải
    Private Const COL2_Short As Integer = 2         ' Tên tắt
    Private Const COL2_SystemID As Integer = 3      ' Mã hệ thống
    Private Const COL2_Decimals As Integer = 4      ' Làm tròn
    Private Const COL2_IsUsed As Integer = 5        ' Sử dụng
    Private Const COL2_SalSystemID As Integer = 6   ' SalSystemID
    Private Const COL2_EmpDiffRate As Integer = 7   ' Cá nhân
    Private Const COL2_TotalDiffRate As Integer = 8 ' Tổng quỹ lương
    Private Const COL2_IsUpdate As Integer = 9      ' IsUpdate
#End Region


#Region "Const of tdbg3 - Total of Columns: 5"
    Private Const COL3_IsUse As Integer = 0     ' Sử dụng
    Private Const COL3_CodeID As Integer = 1    ' Thu nhập hệ thống
    Private Const COL3_Caption As Integer = 2   ' Tiêu đề cột
    Private Const COL3_RefInfoID As Integer = 3 ' Thông tin tham chiếu
    Private Const COL3_SystemID As Integer = 4  ' Mã hệ thống
#End Region

    Dim dtGrid1, dtGrid2, dtGird3 As DataTable
    Private Sub LoadTDBGrid()
        Dim s As String = ""
        ' update 11/6/2013 id 56314
        's = "Select Convert(Smallint, Substring(Code,4, LEN(Code)-3)) OrderNum, Code, Description, DescriptionU, Short, ShortU, convert(bit,(case Disabled when 0 then 1 else 0 end)) as [Disabled], Decimals, Type, CONVERT(TINYINT, 0) AS IsUpdate from D13T9000  WITH (NOLOCK) where Type = 'PRCAL' order by Type, OrderNum"
        ' s = "Select Right(Code,2) OrderNum, Code, Description, DescriptionU, Short, ShortU, convert(bit,(case Disabled when 0 then 1 else 0 end)) as [Disabled] from D13T9000 where type = 'PRCAL' order by Code"
        dtGrid1 = ReturnDataTable(SQLStoreD13P0030(0).ToString())
        'Lưới 1
        LoadDataSource(tdbg, dtGrid1, gbUnicode)
        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, COL_OrderNum) = i + 1
        Next
        tdbg.Splits(0).DisplayColumns(COL_OrderNum).Locked = True
        FooterTotalGrid(tdbg, COL_Description)

        dtGrid2 = ReturnDataTable(SQLStoreD13P0030(1).ToString())
        LoadDataSource(tdbg2, dtGrid2, gbUnicode)

        dtGird3 = ReturnDataTable(SQLStoreD13P0030(2).ToString())
        LoadDataSource(tdbg3, dtGird3, gbUnicode)
        'ReLoadGrid3()
    End Sub

    Private Sub LoadTDBDropDown()
        Dim dtDecimals As New DataTable
        dtDecimals.Columns.Add("Decimals", Type.GetType("System.Decimal"))
        Dim _r As DataRow
        For j As Integer = -3 To 3
            _r = dtDecimals.NewRow
            _r("Decimals") = j
            dtDecimals.Rows.Add(_r)
        Next
        LoadDataSource(tdbdDecimals, dtDecimals, gbUnicode)

        ' Load tdbdSystemID: Ma he thong 06/03//2015
        Dim sSQL As String
        sSQL = SQLStoreD13P2074(0)
        LoadDataSource(tdbdSystemID, sSQL, gbUnicode)

        'Load dropdown thong tin tham chieu
        sSQL = SQLStoreD13P2074(1)
        LoadDataSource(tdbdRefInfoID, sSQL, gbUnicode)

    End Sub

    Private Function AllowSave() As Boolean
        tdbg2.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_Disabled).ToString) = True Then
                If tdbg(i, COL_Description).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Dien_giai"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_Description
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If
            If tdbg(i, COL_Description).ToString <> "" Then
                If Len(tdbg(i, COL_Description)) > 150 Then
                    D99C0008.MsgL3(rL3("Do_dai_Dien_giai_khong_duoc_lon_hon_150"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_Description
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If
            If CBool(tdbg(i, COL_Disabled).ToString) = True Then
                If tdbg(i, COL_Short).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ten_tat"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_Short
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If

            If tdbg(i, COL_Short).ToString <> "" Then
                If Len(tdbg(i, COL_Short)) > 20 Then
                    D99C0008.MsgL3(rL3("Do_dai_Ten_tat_khong_duoc_lon_hon_20"))
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

    Private Sub ResetColIsUpdateToZero(ByVal ParamArray ListGird() As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        If ListGird.Length < 0 Then Exit Sub
        Try
            For Each c1Gird As C1.Win.C1TrueDBGrid.C1TrueDBGrid In ListGird
                For i As Integer = 0 To c1Gird.RowCount - 1
                    c1Gird(i, "IsUpdate") = "0"
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""

        'Tab: Khoản thu nhập
        sSQL = SQLUpdateD13T9000s()

        'Tab: Khoản thu nhập hệ thống
        sSQL &= SQLUpdateD13T9000().ToString
        sSQL &= SQLUpdateD13T0005().ToString

        'Lưới Quyết toán thuế
        sSQL &= SQLDeleteD13T9001().ToString
        sSQL &= SQLInsertD13T9001().ToString

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            ResetColIsUpdateToZero(tdbg, tdbg2)
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
            If tdbg(i, COL_IsUpdate).ToString() = "0" Then Continue For
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


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0030
    '# Created User: Lê Anh Vũ
    '# Created Date: 20/10/2014 03:51:25
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0030(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi khoan thu nhap he thong" & vbCrLf)
        sSQL &= "Exec D13P0030 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(iMode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0005
    '# Created User: Lê Anh Vũ
    '# Created Date: 20/10/2014 04:49:06
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0005() As StringBuilder
        Dim sSQL As New StringBuilder
        Dim _dr() As DataRow
        _dr = dtGrid2.Select("IsUpdate = 1")
        If _dr.Length < 1 Then Return sSQL
        For Each _r As DataRow In _dr
            sSQL.Append("-- Update bang D13T0005" & vbCrLf)
            sSQL.Append("Update D13T0005 Set ")
            sSQL.Append("EmpDiffRate = " & SQLMoney(_r("EmpDiffRate"), DxxFormat.DefaultNumber1) & COMMA) 'decimal, NOT NULL
            sSQL.Append("TotalDiffRate = " & SQLMoney(_r("TotalDiffRate"), DxxFormat.DefaultNumber1)) 'decimal, NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("SalSystemID = " & SQLString(_r("SalSystemID")))
            sSQL.Append(vbCrLf)
        Next
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T9001
    '# Created User: Lê Anh Vũ
    '# Created Date: 12/03/2015 02:31:43
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T9001() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa D13T9001" & vbCrlf)
        sSQL &= "Delete From D13T9001"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T9001
    '# Created User: Lê Anh Vũ
    '# Created Date: 12/03/2015 02:32:33
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T9001() As StringBuilder
        Dim sSQL As New StringBuilder
        For Each _r As DataRow In dtGrid2.Rows
            If Not L3Bool(_r("IsUsed")) Then Continue For
            Dim _dr() As DataRow
            _dr = dtGird3.Select("CodeID = " & SQLString(_r("SalSystemID")))
            For Each row As DataRow In _dr
                If Not L3Bool(row("IsUse")) Then Continue For
                sSQL.Append("-- Them du lieu vao bang D13T9001" & vbCrLf)
                sSQL.Append("Insert Into D13T9001(")
                sSQL.Append("CodeID, Caption, RefInfoID")
                sSQL.Append(") Values(" & vbCrLf)
                sSQL.Append(SQLString(row("CodeID")) & COMMA) 'CodeID, varchar[50], NOT NULL
                sSQL.Append(SQLStringUnicode(row("Caption"), gbUnicode, True) & COMMA) 'Caption, nvarchar[1000], NOT NULL
                sSQL.Append(SQLString(row("RefInfoID"))) 'RefInfoID, varchar[50], NOT NULL
                sSQL.Append(")")
            Next
        Next
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T9000
    '# Created User: Lê Anh Vũ
    '# Created Date: 21/10/2014 09:20:05
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T9000() As StringBuilder
        Dim sSQL As New StringBuilder
        Dim _dr() As DataRow
        _dr = dtGrid2.Select("IsUpdate = 1")
        If _dr.Length < 1 Then Return sSQL
        For Each _r As DataRow In _dr
            sSQL.Append("-- Update Tab khoan thu nhap he thong" & vbCrLf)
            sSQL.Append("Update D13T9000 Set ")
            sSQL.Append("Description = " & SQLStringUnicode(_r("Description").ToString, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
            sSQL.Append("Short = " & SQLStringUnicode(_r("Short").ToString, gbUnicode, False) & COMMA) 'varchar[500], NULL
            sSQL.Append("SystemID = " & SQLString(_r("SystemID")) & COMMA) 'varchar[50], NULL
            sSQL.Append("Disabled = " & SQLNumber(Not L3Bool(_r("IsUsed").ToString())) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("Decimals = " & SQLNumber(_r("Decimals")) & COMMA) 'int, NOT NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(_r("Description").ToString, gbUnicode, True) & COMMA) 'nvarchar[500], NOT NULL
            sSQL.Append("ShortU = " & SQLStringUnicode(_r("Short").ToString, gbUnicode, True)) 'nvarchar[500], NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("Type = " & SQLString("PRSYS") & " And ")
            sSQL.Append("Code = " & SQLString(_r("SalSystemID")))
            sSQL.Append(vbCrLf)
        Next
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2074
    '# Created User: Lê Anh Vũ
    '# Created Date: 06/03/2015 09:43:49
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2074(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho DDL ma he thong" & vbCrLf)
        sSQL &= "Exec D13P2074 "
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[10], NOT NULL
        Return sSQL
    End Function

    Private Sub tdbg2_LockedColumns()
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_Code).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg2_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg2.Columns(COL2_Decimals).DataField, DxxFormat.DefaultNumber0, 28, 8)
        AddDecimalColumns(arr, tdbg2.Columns(COL2_EmpDiffRate).DataField, DxxFormat.DefaultNumber1, 28, 8)
        AddDecimalColumns(arr, tdbg2.Columns(COL2_TotalDiffRate).DataField, DxxFormat.DefaultNumber1, 28, 8)
        InputNumber(tdbg2, arr)
    End Sub

    Private Sub tdbg2_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.ComboSelect
        tdbg2.UpdateData()
    End Sub

    Private Sub tdbg2_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg2.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL2_Decimals, COL2_EmpDiffRate, COL2_TotalDiffRate
                If Not L3IsNumeric(tdbg2.Columns(e.ColIndex).Text, EnumDataType.Int) Then e.Cancel = True
            Case COL2_SystemID
                If tdbg2.Columns(e.ColIndex).Text <> tdbg2.Columns(e.ColIndex).DropDown.Columns(tdbg2.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg2.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                Else
                    If tdbg2.Columns(e.ColIndex).Text <> "" Then
                        e.Cancel = CheckDuplicateIDOnGrid(tdbg2, COL2_SystemID)
                    End If

                End If
        End Select
    End Sub
    Private Sub UpdateSystemID()
        Dim _dr() As DataRow
        'sSystemID = L3String(tdbg2.Columns(COL2_SystemID).Value)
        _dr = dtGird3.Select("CodeID = " & SQLString(tdbg2.Columns(COL2_Code).Text))
        For Each row As DataRow In _dr
            row("SystemID") = tdbg2.Columns(COL2_SystemID).Value
        Next
        tdbg3.UpdateData()
    End Sub

    Private Sub tdbg2_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        tdbg2.Columns(COL2_IsUpdate).Value = 1
        Select Case e.ColIndex
            Case COL2_SystemID
                If tdbg2.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg2.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    UpdateSystemID()
                    Exit Select
                End If
                UpdateSystemID()
            Case COL2_IsUsed
                'Không tồn tại SystemID trong bảng lưới 3.
                'If dtGird3.Select("SystemID = " & SQLString(tdbg2.Columns(COL2_SystemID).Text)).Length = 0 Then
                Dim _dr() As DataRow
                _dr = dtGird3.Select("SystemID = " & SQLString(tdbg2.Columns(COL2_SystemID).Value) & " And CodeID = " & SQLString(tdbg2.Columns(COL2_Code).Text))
                If L3Bool(tdbg2.Columns(COL2_IsUsed).Text) Then
                    If _dr.Length = 0 Then
                        Dim dataRow As DataRow
                        dataRow = dtGird3.NewRow
                        dataRow("IsUse") = 1
                        dataRow("CodeID") = tdbg2.Columns(COL2_Code).Text
                        dataRow("Caption") = tdbg2.Columns(COL2_Description).Text
                        dataRow("RefInfoID") = ""
                        dataRow("SystemID") = tdbg2.Columns(COL2_SystemID).Value
                        dtGird3.Rows.Add(dataRow)
                    Else
                        For Each row As DataRow In _dr
                            row("IsUse") = True
                        Next
                    End If
                Else
                    For Each row As DataRow In _dr
                        dtGird3.Rows.Remove(row)
                    Next

                End If
                'tdbg3.AllowUpdate = L3Bool(tdbg2.Columns(COL2_IsUsed).Text)
        End Select
    End Sub

    Dim bNotInList As Boolean = False

    'Private Sub D13F0030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.Alt Then
    '        Select Case e.KeyCode
    '            Case Keys.D1, Keys.NumPad1
    '                If (btnInfoCalculate.Enabled) Then btnInfoCalculate_Click(Nothing, Nothing)
    '            Case Keys.D2, Keys.NumPad2
    '                If (btnInfoTax.Enabled) Then btnInfoTax_Click(Nothing, Nothing)
    '            Case Keys.D3, Keys.NumPad3
    '                If (btnInfoInsurance.Enabled) Then btnInfoInsurance_Click(Nothing, Nothing)
    '            Case Keys.D4, Keys.NumPad4
    '                If (btnOthers.Enabled) Then btnOthers_Click(Nothing, Nothing)
    '        End Select

    '    End If


    'End Sub

    Private Sub D13F0030_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        ResetSplitDividerSize(tdbg2)
        ResetFooterGrid(tdbg, 0, 0)
        tdbg2.Splits(SPLIT0).Caption = " "
        Loadlanguage()
        UnicodeGridDataField(tdbg, UnicodeArrayCOL(), gbUnicode)
        tdbg2_LockedColumns()
        tdbg2_NumberFormat()
        tdbg3_LockedColumns()
        LoadTDBDropDown()
        LoadTDBGrid()
        tdbg_LockedColumns()
        CheckPermission()
        HotkeyAltTabControl(tabM)
        SetResolutionForm(Me)

    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, pnlG, tabM)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg, tdbg2)
        AnchorForControl(EnumAnchorStyles.BottomRight, pnlB)

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

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Dinh_nghia_cac_khoan_thu_nhap_-_D13F0030") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa cÀc kho¶n thu nhËp - D13F0030
        '================================================================ 
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        TabD1.Text = rL3("Quyet_toan_thue") 'Quyết toán thuế
        '================================================================ 
        TabPage1.Text = "1. " & rL3("Khoan_thu_nhap") 'Khoản thu nhập
        TabPage2.Text = "2. " & rL3("Khoan_thu_nhap_he_thong") 'Khoản thu nhập hệ thống
        '================================================================ 
        tdbdRefInfoID.Columns("RefInfoID").Caption = rL3("Ma") 'Mã
        tdbdRefInfoID.Columns("RefInfoName").Caption = rL3("Ten") 'Tên
        tdbdSystemID.Columns("SystemID").Caption = rL3("Ma") 'Mã
        tdbdSystemID.Columns("SystemName").Caption = rL3("Ten") 'Tên
        tdbdDecimals.Columns("Decimals").Caption = rL3("Lam_tron") 'Làm tròn
        '================================================================ 
        tdbg.Columns(COL_Code).Caption = rL3("Ma") 'Mã
        tdbg.Columns(COL_OrderNum).Caption = rL3("STT") 'STT
        tdbg.Columns(COL_Description).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_Short).Caption = rL3("Ten_tat") 'Tên tắt
        tdbg.Columns(COL_Disabled).Caption = rL3("Su_dung") 'Sử dụng
        tdbg3.Columns(COL3_IsUse).Caption = rL3("Su_dung") 'Sử dụng
        tdbg3.Columns(COL3_CodeID).Caption = rL3("Thu_nhap_he_thong") 'Thu nhập hệ thống
        tdbg3.Columns(COL3_Caption).Caption = rL3("Tieu_de_cot") 'Tiêu đề cột
        tdbg3.Columns(COL3_RefInfoID).Caption = rL3("Thong_tin_tham_chieu") 'Thông tin tham chiếu
        tdbg2.Columns(COL2_SalSystemID).Caption = rL3("Ma") 'Mã
        tdbg2.Columns(COL2_Description).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg2.Columns(COL2_Short).Caption = rL3("Ten_tat") 'Tên tắt
        tdbg2.Columns(COL2_SystemID).Caption = rL3("Ma_he_thong") 'Mã hệ thống
        tdbg2.Columns(COL2_Decimals).Caption = rL3("Lam_tron") 'Làm tròn
        tdbg2.Columns(COL2_IsUsed).Caption = rL3("Su_dung") 'Sử dụng
        tdbg2.Columns(COL2_EmpDiffRate).Caption = rL3("Ca_nhan") 'Cá nhân
        tdbg2.Columns(COL2_TotalDiffRate).Caption = rL3("Tong_quy_luong") 'Tổng quỹ lương
        tdbg2.Splits(1).Caption = rL3("Ty_le_chenh_lech") & " %" 'Tỷ lệ chênh lệch %
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

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.Columns(COL_IsUpdate).Value = "1"
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
        For i As Integer = tdbg.Row To tdbg.RowCount - 1
            tdbg(i, COL_IsUpdate) = "1"
        Next
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
            For i As Integer = tdbg.Row To tdbg.RowCount - 1
                tdbg(i, COL_IsUpdate) = "1"
            Next
        End If
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_Disabled
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Private Sub tdbg3_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg3.ComboSelect
        tdbg3.UpdateData()
    End Sub


    Dim bNotInList3 As Boolean = False
    Private Sub tdbg3_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg3.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL3_RefInfoID
                If tdbg3.Columns(e.ColIndex).Text <> tdbg3.Columns(e.ColIndex).DropDown.Columns(tdbg3.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg3.Columns(e.ColIndex).Text = ""
                    bNotInList3 = True
                Else
                    If tdbg3.Columns(e.ColIndex).Text <> "" Then
                        e.Cancel = CheckDuplicateIDOnGrid(tdbg3, COL3_RefInfoID)
                    End If
                End If
        End Select
    End Sub


    Private Sub tdbg3_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg3.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL3_IsUse
                Dim _dr() As DataRow
                _dr = dtGrid2.Select("SalSystemID = " & SQLString(tdbg3.Columns(COL3_CodeID).Text))
                For Each row As DataRow In _dr
                    row("IsUsed") = tdbg3.Columns(COL3_IsUse).Text
                Next
                dtGird3.Rows.RemoveAt(tdbg3.Row)
            Case COL3_CodeID
            Case COL3_Caption
            Case COL3_RefInfoID
                If tdbg3.Columns(e.ColIndex).Text = "" OrElse bNotInList3 Then
                    tdbg3.Columns(e.ColIndex).Text = ""
                    bNotInList3 = False
                    Exit Select
                End If
            Case COL3_SystemID
        End Select
    End Sub

    Private Sub tdbg3_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg3.FetchCellStyle
        Select Case e.Col
            Case COL3_IsUse, COL3_RefInfoID
                If L3String(tdbg3(e.Row, COL3_SystemID)) <> "" Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
        End Select
    End Sub

    Private Sub tdbg3_LockedColumns()
        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_CodeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub


    Private Sub ReLoadGrid3()
        'sSystemID = L3String(tdbg2.Columns(COL2_SystemID).Value)
        'sCodeID = tdbg2.Columns(COL2_Code).Text
        'dtGird3.DefaultView.RowFilter = "CodeID = " & SQLString(sCodeID) '& " And SystemID  = " & SQLString(sSystemID))

        'TH dòng hiện tại của lưới 2 có check nhưng stote không trả ra dòng cho lưới 3 thì tự động ép thêm 1 dòng. 12/03/2015
        'Dim _dr() As DataRow
        '_dr = dtGird3.Select("SystemID = " & SQLString(tdbg2.Columns(COL2_SystemID).Value) & " And CodeID = " & SQLString(tdbg2.Columns(COL2_Code).Text))
        'If L3Bool(tdbg2.Columns(COL2_IsUsed).Text) Then
        '    If _dr.Length = 0 Then
        '        Dim dataRow As DataRow
        '        dataRow = dtGird3.NewRow
        '        dataRow("IsUse") = 1
        '        dataRow("CodeID") = tdbg2.Columns(COL2_Code).Text
        '        dataRow("Caption") = tdbg2.Columns(COL2_Description).Text
        '        dataRow("RefInfoID") = ""
        '        dataRow("SystemID") = tdbg2.Columns(COL2_SystemID).Value
        '        dtGird3.Rows.Add(dataRow)
        '    End If
        'End If
    End Sub

    'Private sSystemID As String = "", sCodeID As String = ""
    'Private Sub tdbg2_RowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg2.RowColChange
    '    If L3String(tdbg2.Columns(COL2_SystemID).Value) = sSystemID And tdbg2.Columns(COL2_Code).Text = sCodeID Then Exit Sub
    '    ReLoadGrid3()
    'End Sub

End Class