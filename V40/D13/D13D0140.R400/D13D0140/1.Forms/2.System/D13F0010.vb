'#-------------------------------------------------------------------------------------
'# Created Date: 25/09/2009 09:15:34 AM
'# Created User: Đỗ Minh Dũng
'# Modify Date: 19/05/2010
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D13F0010
	Private _formIDPermission As String = "D13F0010"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
    End Property

#Region "Const of tdbg1"
    Private COL_DataType As Integer = 0         ' DataType
    Private COL_Type As Integer = 1             ' Type
    Private COL_Code As Integer = 2             ' Code
    Private COL_FieldName As Integer = 3        ' Diễn giải
    Private COL_Description As Integer = 4      ' Tên Tiếng Việt
    Private COL_Description01 As Integer = 5     ' Tên Tiếng Anh
    Private COL_Short As Integer = 6            ' Tên tắt
    Private COL_Decimals As Integer = 7         ' Làm tròn
    Private COL_Disabled As Integer = 8         ' Sử dụng
    Private COL_LastModifyUserID As Integer = 9 ' Người cập nhật cuối
    Private COL_LastModifyDate As Integer = 10  ' Ngày cập nhật cuối
#End Region

    Dim dt As DataTable
    Dim bUnicode As Boolean = gbUnicode
    'Bỏ số thứ tự của tab - T.Thảo - 19/05/2010
    'Private Sub D13F0010_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.Alt Then
    '        Select Case e.KeyCode
    '            Case Keys.D1, Keys.NumPad1
    '                tabMain.SelectedIndex = 0
    '                tdbg1.Focus()
    '                tdbg1.SplitIndex = SPLIT0
    '                tdbg1.Col = COL_Description
    '                tdbg1.Bookmark = 0
    '            Case Keys.D2,                              Keys.NumPad2
    '                tabMain.SelectedIndex = 1
    '                tdbg2.Focus()
    '                tdbg2.SplitIndex = SPLIT0
    '                tdbg2.Col = COL_Description
    '                tdbg2.Bookmark = 0
    '            Case Keys.D3, Keys.NumPad3
    '                tabMain.SelectedIndex = 2
    '                tdbg3.Focus()
    '                tdbg3.SplitIndex = SPLIT0
    '                tdbg3.Col = COL_Description
    '                tdbg3.Bookmark = 0
    '            Case Keys.D4, Keys.NumPad4
    '                tabMain.SelectedIndex = 3
    '                tdbg4.Focus()
    '                tdbg4.SplitIndex = SPLIT0
    '                tdbg4.Col = COL_Description
    '                tdbg4.Bookmark = 0
    '            Case Keys.D5, Keys.NumPad5
    '                tabMain.SelectedIndex = 4
    '                tdbg5.Focus()
    '                tdbg5.SplitIndex = SPLIT0
    '                tdbg5.Col = COL_Description
    '                tdbg5.Bookmark = 0
    '            Case Keys.D6, Keys.NumPad6
    '                tabMain.SelectedIndex = 5
    '                tdbg6.Focus()
    '                tdbg6.SplitIndex = SPLIT0
    '                tdbg6.Col = COL_Description
    '                tdbg6.Bookmark = 0
    '            Case Keys.D7, Keys.NumPad7
    '                tabMain.SelectedIndex = 6
    '                tdbg7.Focus()
    '                tdbg7.SplitIndex = SPLIT0
    '                tdbg7.Col = COL_Description
    '                tdbg7.Bookmark = 0
    '            Case Keys.D8, Keys.NumPad8
    '                tabMain.SelectedIndex = 7
    '                tdbg8.Focus()
    '                tdbg8.SplitIndex = SPLIT0
    '                tdbg8.Col = COL_Description
    '                tdbg8.Bookmark = 0
    '            Case Keys.D9, Keys.NumPad9
    '                tabMain.SelectedIndex = 8
    '                tdbg9.Focus()
    '                tdbg9.SplitIndex = SPLIT0
    '                tdbg9.Col = COL_Description
    '                tdbg9.Bookmark = 0
    '        End Select
    '    End If
    'End Sub


    Private Sub D13F0010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        UnicodeGridDataField(tdbg1, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg2, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg3, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg4, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg5, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg6, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg7, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg8, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg9, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg10, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg11, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg12, UnicodeArrayCOL(), bUnicode)
        UnicodeGridDataField(tdbg13, UnicodeArrayCOL(), bUnicode)
        tdbg_LockedColumns()
        CreateDataTable()
        LoadTDBGrid()
        CheckGrid3()
        btnSave.Enabled = ReturnPermission(_formIDPermission) > 1

        InputDateInTrueDBGrid(tdbg1, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg2, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg3, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg4, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg5, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg6, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg7, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg8, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg9, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg10, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg11, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg12, COL_LastModifyDate)
        InputDateInTrueDBGrid(tdbg13, COL_LastModifyDate)

    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub LoadGridLanguage(ByVal tdbgX As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        With tdbgX
            .Columns(COL_FieldName).Caption = rl3("Dien_giai") 'Diễn giải
            .Columns(COL_Description).Caption = rl3("Ten_tieng_Viet") 'Tên Tiếng Việt
            .Columns("Description01").Caption = rl3("Ten_tieng_Anh") 'Tên Tiếng Anh
            .Columns("Short").Caption = rl3("Ten_tat") 'Tên tắt
            .Columns("Decimals").Caption = rl3("Lam_tron") 'Làm tròn
            .Columns("Disabled").Caption = rl3("Su_dung") 'Sử dụng
            .Columns("LastModifyUserID").Caption = rl3("Nguoi_cap_nhat_cuoi") 'Người cập nhật cuối
            .Columns("LastModifyDate").Caption = rl3("Ngay_cap_nhat_cuoi") 'Ngày cập nhật cuối
        End With
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_nghia_he_so_-_D13F0010") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa hÖ sç - D13F0010
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        TabPage1.Text = rl3("He_so_luong") 'Hồ sơ lương
        TabPage2.Text = rl3("Muc_luong")  'Mức lương
        TabPage3.Text = rl3("Ngach_bac_luong")  'Ngạch bậc lương
        TabPage4.Text = rl3("He_so_chuc_vu")  'Chức vụ
        TabPage5.Text = rl3("He_so_phong_ban") 'Phòng ban
        TabPage6.Text = rl3("Khoan_dieu_chinh_thu_nhap")
        'TabPage7.Text = rl3("Yeu_to_danh_gia")  'Yếu tố đánh giá
        TabPage7.Text = rl3("Chi_tieu_danh_gia")  'Chỉ tiêu đánh giá
        TabPage8.Text = rl3("He_so_khen_thuong") 'Hệ số khen thưởng
        TabPage9.Text = rl3("He_so_ky_luat")  'Hệ số kỷ luật
        TabPage10.Text = rl3("He_so_cham_cong") 'Hệ số chấm công
        TabPage11.Text = rl3("He_so_cong_doan")
        TabPage12.Text = rl3("He_so_cong_viec")
        TabPage13.Text = rl3("He_so_du_an") ' Hệ số dự án'  ' UPDATE 12/6/2013 ID 56277
        '================================================================ 
        LoadGridLanguage(tdbg1)
        LoadGridLanguage(tdbg2)
        LoadGridLanguage(tdbg3)
        LoadGridLanguage(tdbg4)
        LoadGridLanguage(tdbg5)
        LoadGridLanguage(tdbg6)
        LoadGridLanguage(tdbg7)
        LoadGridLanguage(tdbg8)
        LoadGridLanguage(tdbg9)
        LoadGridLanguage(tdbg10)
        LoadGridLanguage(tdbg11)
        LoadGridLanguage(tdbg12)
        LoadGridLanguage(tdbg13)
    End Sub

    Private Sub TdbgX_LockColumn(ByVal tdbgX As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        With tdbgX.Splits(SPLIT0)
            .DisplayColumns(COL_FieldName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            .DisplayColumns.Item(COL_FieldName).Locked = True
            .DisplayColumns(COL_LastModifyUserID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            .DisplayColumns.Item(COL_LastModifyUserID).Locked = True
            .DisplayColumns(COL_LastModifyDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            .DisplayColumns.Item(COL_LastModifyDate).Locked = True
        End With
    End Sub

    Private Sub tdbg_LockedColumns()
        TdbgX_LockColumn(tdbg1)
        TdbgX_LockColumn(tdbg2)
        TdbgX_LockColumn(tdbg3)
        TdbgX_LockColumn(tdbg4)
        TdbgX_LockColumn(tdbg5)
        TdbgX_LockColumn(tdbg6)
        TdbgX_LockColumn(tdbg7)
        TdbgX_LockColumn(tdbg8)
        TdbgX_LockColumn(tdbg9)
        TdbgX_LockColumn(tdbg10)
        TdbgX_LockColumn(tdbg11)
        TdbgX_LockColumn(tdbg12)
        TdbgX_LockColumn(tdbg13)
    End Sub

    Public Sub CreateDataTable()
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P0010()
        dt = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadTDBGrid()
        If dt.Rows.Count > 0 Then
            LoadDataSource(tdbg1, ReturnTableFilter(dt, "Type = 'SALCE'", True), bUnicode)
            LoadDataSource(tdbg2, ReturnTableFilter(dt, "Type = 'SALBA'", True), bUnicode)
            LoadDataSource(tdbg3, ReturnTableFilter(dt, "Type = 'OLSC'", True), bUnicode)
            LoadDataSource(tdbg4, ReturnTableFilter(dt, "Type = 'D09T0211'", True), bUnicode)
            LoadDataSource(tdbg5, ReturnTableFilter(dt, "Type = 'D91T0012'", True), bUnicode)
            LoadDataSource(tdbg6, ReturnTableFilter(dt, "Type = 'D13T0118'", True), bUnicode)
            LoadDataSource(tdbg7, ReturnTableFilter(dt, "Type = 'D39T1000'", True), bUnicode)
            LoadDataSource(tdbg8, ReturnTableFilter(dt, "Type = 'REWARD'", True), bUnicode)
            LoadDataSource(tdbg9, ReturnTableFilter(dt, "Type = 'DISCIPLINE'", True), bUnicode)
            LoadDataSource(tdbg10, ReturnTableFilter(dt, "Type = 'D29T1070'", True), bUnicode)
            LoadDataSource(tdbg11, ReturnTableFilter(dt, "Type = 'D45T1010'", True), bUnicode)
            LoadDataSource(tdbg12, ReturnTableFilter(dt, "Type = 'D09T0224'", True), bUnicode)
            LoadDataSource(tdbg13, ReturnTableFilter(dt, "Type = 'D09T1080'", True), bUnicode) ' UPDATE 12/6/2013 ID 56277
            SetDefaultValue(tdbg3)
        End If
    End Sub

    Private Sub SetDefaultValue(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        For i As Integer = 0 To c1Grid.RowCount - 1
            If c1Grid(i, COL_DataType).ToString <> "1" Then
                c1Grid(i, COL_Decimals) = ""
            End If
        Next
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If Not CheckColDecimal(tdbg1) Then Return False
        If Not CheckColDecimal(tdbg2) Then Return False
        If Not CheckColDecimal(tdbg3) Then Return False
        If Not CheckColDecimal(tdbg4) Then Return False
        If Not CheckColDecimal(tdbg5) Then Return False
        If Not CheckColDecimal(tdbg6) Then Return False
        If Not CheckColDecimal(tdbg7) Then Return False
        If Not CheckColDecimal(tdbg8) Then Return False
        If Not CheckColDecimal(tdbg9) Then Return False
        If Not CheckColDecimal(tdbg10) Then Return False
        If Not CheckColDecimal(tdbg11) Then Return False
        If Not CheckColDecimal(tdbg12) Then Return False
        If Not CheckColDecimal(tdbg13) Then Return False
        Return True
    End Function

    Private Function CheckColDecimal(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As Boolean
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_Decimals).ToString = "" And tdbg(i, COL_DataType).ToString = "1" Then
                D99C0008.MsgNotYetEnter(rl3("Lam_tron"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_Decimals
                tdbg.Bookmark = i
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg1.UpdateData()
        tdbg2.UpdateData()
        tdbg3.UpdateData()
        tdbg4.UpdateData()
        tdbg5.UpdateData()
        tdbg6.UpdateData()
        tdbg7.UpdateData()
        tdbg8.UpdateData()
        tdbg9.UpdateData()
        tdbg10.UpdateData()
        tdbg12.UpdateData()
        tdbg13.UpdateData()
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        'Tab 1
        sSQL.Append(SQLUpdateD13T9000s(tdbg1).ToString & vbCrLf)
        'Tab 2
        sSQL.Append(SQLUpdateD13T9000s(tdbg2).ToString & vbCrLf)
        'Tab 3
        sSQL.Append(SQLUpdateD13T9000s(tdbg3).ToString & vbCrLf)
        'Tab 4
        sSQL.Append(SQLUpdateD13T9000s(tdbg4).ToString & vbCrLf)
        'Tab 5
        sSQL.Append(SQLUpdateD13T9000s(tdbg5).ToString & vbCrLf)
        'Tab 6
        sSQL.Append(SQLUpdateD13T9000s(tdbg6).ToString & vbCrLf)
        'Tab 7
        sSQL.Append(SQLUpdateD13T9000s(tdbg7).ToString & vbCrLf)
        'Tab 8
        sSQL.Append(SQLUpdateD13T9000s(tdbg8).ToString & vbCrLf)
        'Tab 9
        sSQL.Append(SQLUpdateD13T9000s(tdbg9).ToString & vbCrLf)
        'Tab 10
        sSQL.Append(SQLUpdateD13T9000s(tdbg10).ToString & vbCrLf)

        'Tab 11
        sSQL.Append(SQLUpdateD13T9000s(tdbg11).ToString & vbCrLf)

        sSQL.Append(SQLUpdateD13T9000s(tdbg12).ToString & vbCrLf)

        sSQL.Append(SQLUpdateD13T9000s(tdbg13).ToString & vbCrLf) ' UPDATE 12/6/2013 ID 56277

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            D99C0008.MsgL3(rl3("Ban_phai_khoi_dong_lai_module_thi_thiet_lap_moi_co_tac_dung"))
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub tdbgX_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg1.FetchCellStyle, _
    tdbg2.FetchCellStyle, tdbg3.FetchCellStyle, tdbg4.FetchCellStyle, tdbg5.FetchCellStyle, tdbg6.FetchCellStyle, _
tdbg7.FetchCellStyle, tdbg8.FetchCellStyle, tdbg9.FetchCellStyle, tdbg10.FetchCellStyle, tdbg11.FetchCellStyle, tdbg12.FetchCellStyle, tdbg13.FetchCellStyle

        Dim tdbgX As C1.Win.C1TrueDBGrid.C1TrueDBGrid = CType(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        With tdbgX
            Select Case .Col
                Case COL_Decimals
                    If .Columns(COL_DataType).Text <> "1" Then
                        .Columns(COL_Decimals).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
                        .Splits(SPLIT0).DisplayColumns(COL_Decimals).Locked = True
                        .Columns(COL_Decimals).Text = ""
                    Else
                        .Columns(COL_Decimals).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
                        .Splits(SPLIT0).DisplayColumns(COL_Decimals).Locked = False
                    End If
            End Select
        End With
    End Sub

    Private Sub tdbgX_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.HeadClick, _
tdbg2.HeadClick, tdbg3.HeadClick, tdbg4.HeadClick, tdbg5.HeadClick, tdbg6.HeadClick, _
        tdbg7.HeadClick, tdbg8.HeadClick, tdbg9.HeadClick, tdbg10.HeadClick, tdbg11.HeadClick, tdbg12.HeadClick, tdbg13.HeadClick

        Dim tdbgX As C1.Win.C1TrueDBGrid.C1TrueDBGrid = CType(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        With tdbgX
            tdbgX.UpdateData()
            If .RowCount <= 0 Then Exit Sub
            Select Case e.ColIndex
                Case COL_Disabled
                    Dim bFlag As Boolean = Not CBool(tdbgX(0, COL_Disabled))
                    For i As Integer = 0 To .RowCount - 1
                        tdbgX(i, COL_Disabled) = bFlag
                    Next
            End Select
        End With
    End Sub

    Private Sub tdbgX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg1.KeyDown, _
    tdbg2.KeyDown, tdbg3.KeyDown, tdbg4.KeyDown, tdbg5.KeyDown, tdbg6.KeyDown, _
tdbg7.KeyDown, tdbg8.KeyDown, tdbg9.KeyDown, tdbg10.KeyDown, tdbg11.KeyDown, tdbg12.KeyDown, tdbg13.KeyDown
        Dim tdbgX As C1.Win.C1TrueDBGrid.C1TrueDBGrid = CType(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        With tdbgX
            If e.KeyCode = Keys.Enter Then
                If .Col = COL_Disabled Then
                    HotKeyEnterGrid(tdbgX, COL_Description, e)
                End If
            End If
        End With
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0010
    '# Created User: DUCTRONG
    '# Created Date: 18/05/2009 09:32:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P0010 "
        sSQL &= SQLString("%") & COMMA 'Type, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T9000s
    '# Created User: DUCTRONG
    '# Created Date: 18/05/2009 10:35:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T9000s(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To c1Grid.RowCount - 1
            sSQL.Append("Update D13T9000 Set ")
            sSQL.Append("Description = " & SQLStringUnicode(c1Grid(i, COL_Description), bUnicode, False) & COMMA) 'varchar[150], NOT NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(c1Grid(i, COL_Description), bUnicode, True) & COMMA) 'varchar[150], NOT NULL
            sSQL.Append("Short = " & SQLStringUnicode(c1Grid(i, COL_Short), bUnicode, False) & COMMA) 'varchar[20], NULL
            sSQL.Append("ShortU = " & SQLStringUnicode(c1Grid(i, COL_Short), bUnicode, True) & COMMA) 'varchar[20], NULL
            sSQL.Append("Disabled = " & SQLNumber(IIf(CBool(c1Grid(i, COL_Disabled)), 0, 1)) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("Decimals = " & SQLNumber(c1Grid(i, COL_Decimals)) & COMMA) 'int, NOT NULL
            sSQL.Append("Description01 = " & SQLString(c1Grid(i, COL_Description01)) & COMMA) 'varchar[150], NOT NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
            sSQL.Append(" Where ")
            sSQL.Append("Type = " & SQLString(c1Grid(i, COL_Type)) & " And ")
            sSQL.Append("Code = " & SQLString(c1Grid(i, COL_Code)))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function LockCell(ByVal row As Integer) As Boolean
        Dim Arr() As Integer = {1, 10, 11, 2, 20, 21}
        For i As Integer = 0 To Arr.Length - 1
            If tdbg3(row, COL_Type).ToString = "OLSC" And tdbg3(row, COL_Code).ToString = "OLSC" & Arr(i).ToString Then
                'tdbg3.Columns(COL_Disabled).Text = "1"
                'tdbg3.Splits(1).DisplayColumns(COL_Disabled).Locked = True
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub tdbg3_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg3.RowColChange
        'tdbg3.Splits(1).DisplayColumns(COL_Disabled).Locked = False
        tdbg3.Splits(1).DisplayColumns(COL_Disabled).Locked = LockCell(tdbg3.Row)
    End Sub

    Private Sub CheckGrid3()
        Dim Arr() As Integer = {1, 10, 11, 2, 20, 21}
        For j As Integer = 0 To tdbg3.RowCount - 1
            For i As Integer = 0 To Arr.Length - 1
                If tdbg3(j, COL_Type).ToString = "OLSC" And tdbg3(j, COL_Code).ToString = "OLSC" & Arr(i).ToString Then
                    tdbg3(j, COL_Disabled) = "1"
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub tdbg3_OwnerDrawCell(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.OwnerDrawCellEventArgs) Handles tdbg3.OwnerDrawCell
        'If tdbg(e.Row, COL_Description).ToString <> "Maõ haøng" Then Exit Sub

        If LockCell(e.Row) = False Then Exit Sub

        Dim objPen As New Pen(Color.FromName("Green"))
        Dim pt As New Point()

        'Dim rect As New Rectangle(e.CellRect.X + 18, e.CellRect.Y, CInt(e.CellRect.Width / 4) - 1, e.CellRect.Height - 4)
        Dim X As Integer = e.CellRect.X + CInt((e.CellRect.Width - 11) / 2) - 2
        Dim rect As New Rectangle(X, e.CellRect.Y, 12, e.CellRect.Height - 3)
        e.Graphics.FillRectangle(Brushes.DarkGray, rect)
        e.Graphics.DrawRectangle(objPen, rect)

        'The commented out line below causes a red checkmark to be drawn in the topmost cell only of the column
        pt.X = e.CellRect.X + CInt(e.CellRect.Width / 2) - 4
        'No red checkmark is drawn in any cell in the column using the Y-cord below
        pt.Y = e.CellRect.Y + CInt(e.CellRect.Height / 2) - 3

        'Lines moving downward left to right--left side of check (The checkmark is 3 lines thick)
        e.Graphics.DrawLine(objPen, pt.X, pt.Y + 0, pt.X + 2, pt.Y + 2)
        e.Graphics.DrawLine(objPen, pt.X, pt.Y + 1, pt.X + 2, pt.Y + 3)
        e.Graphics.DrawLine(objPen, pt.X, pt.Y + 2, pt.X + 2, pt.Y + 4)
        'Lines moving upward left to right--right side of check
        e.Graphics.DrawLine(objPen, pt.X + 2, pt.Y + 2, pt.X + 6, pt.Y - 2)
        e.Graphics.DrawLine(objPen, pt.X + 2, pt.Y + 3, pt.X + 6, pt.Y - 1)
        e.Graphics.DrawLine(objPen, pt.X + 2, pt.Y + 4, pt.X + 6, pt.Y - 0)
        e.Handled = True
    End Sub

    Private Function UnicodeArrayCOL() As Integer()
        If Not bUnicode Then Return Nothing
        Dim ArrCOL() As Integer = {COL_FieldName, COL_Description, COL_Short}
        'FieldName cột chỉ gán lại khi COL khai báo là string
        Return ArrCOL
    End Function

End Class