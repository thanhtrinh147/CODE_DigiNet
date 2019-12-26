'#-------------------------------------------------------------------------------------
'# Created Date: 21/05/2007 2:33:42 PM
'# Created User: Nguyễn Lê Phương
'# Modify Date: 21/05/2007 2:33:42 PM
'# Modify User: Nguyễn Lê Phương
'#-------------------------------------------------------------------------------------
Public Class D45F0010

    Private dtData As DataTable

#Region "Const of tdbg"
    Private Const COL_Type As Integer = 0        ' Type
    Private Const COL_Code As Integer = 1        ' Mã
    Private Const COL_Description As Integer = 2 ' Diễn giải
    Private Const COL_ShortName As Integer = 3   ' Tên tắt
    Private Const COL_Disabled As Integer = 4    ' Không sử dụng
    Private Const COL_Formula As Integer = 5     ' Formula
#End Region

#Region "Const of tdbg2"
    Private Const COL2_TransID As Integer = 0     ' TransID
    Private Const COL2_FormulaID As Integer = 1   ' Tên hàm
    Private Const COL2_Description As Integer = 2 ' Diễn giải
#End Region


#Region "Const of tdbg3 - Total of Columns: 7"
    Private Const COL3_OrderNum As Integer = 0    ' STT
    Private Const COL3_Description As Integer = 1 ' Diễn giải
    Private Const COL3_ShortName As Integer = 2   ' Tên tắt
    Private Const COL3_Decimals As Integer = 3    ' Làm tròn
    Private Const COL3_Disabled As Integer = 4    ' KSD
    Private Const COL3_Type As Integer = 5        ' Type
    Private Const COL3_Code As Integer = 6        ' Code
#End Region


#Region "Const of tdbg4"
    Private Const COL4_OrderNum As Integer = 0    ' STT
    Private Const COL4_Description As Integer = 1 ' Diễn giải
    Private Const COL4_ShortName As Integer = 2   ' Tên tắt
    Private Const COL4_Disabled As Integer = 3    ' KSD
    Private Const COL4_Type As Integer = 4        ' Type
    Private Const COL4_Code As Integer = 5        ' Code
#End Region

    '  Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            'bLoadFormState = True
	LoadInfoGeneral()
            CreateData()
            _FormState = value

            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnSave.Enabled = True
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub D45F0010_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
        If e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tabMain.SelectedTab = TabUnitPrice
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            tabMain.SelectedTab = TabFormular
            tdbg.Focus()
            tdbg.Bookmark = 0
            tdbg.Col = COL_Description
        End If
    End Sub

    Private Sub D45F0010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If bLoadFormState = False Then FormState = _formState
        If ReturnPermission("D45F0010") <= EnumPermission.View Then
            FormState = EnumFormState.FormView
        Else
            FormState = EnumFormState.FormEdit
        End If

        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        ResetColorGrid(tdbg)
        ResetColorGrid(tdbg2)
        tdbg_LockedColumns()
        tdbg3_LockedColumns()
        tdbg4_LockedColumns()
        LoadTDBDropDown()
        LoadTDBGrid()
        '*********************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtFormular, 800, True)
        '*********************    
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_nghia_cac_loai_Don_gia_So_luong_-_D45F0010") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa cÀc loÁi ˜¥n giÀ/ Sç l§íng - D45F0010
        '================================================================ 
        lblFormular.Text = rl3("Cong_thuc") 'Công thức
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        TabUnitPrice.Text = "1." & Space(1) & rl3("Dinh_nghia_cac_loai_don_gia") 'Định nghĩa các loại đơn giá
        TabFormular.Text = "2." & Space(1) & rl3("Dinh_nghia_cong_thuc_cho_tham_so") 'Định nghĩa công thức cho tham số
        '================================================================ 
        grpUnitPrice.Text = rl3("Don_gia_thuong") 'Đơn giá thường
        grpHAUnitPrice.Text = rl3("Don_gia_gio_cong_he_so") 'Đơn giá giờ công hệ số
        '================================================================ 
        tdbg2.Columns("FormulaID").Caption = rl3("Ten_ham") 'Tên hàm
        tdbg2.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("ShortName").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg.Columns("Disabled").Caption = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        tdbg3.Columns(COL3_OrderNum).Caption = rl3("STT") 'STT
        tdbg3.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg3.Columns("ShortName").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg3.Columns("Disabled").Caption = rL3("KSD") 'KSD
        tdbg3.Columns(COL3_Decimals).Caption = rL3("Lam_tron")
        '================================================================ 
        tdbg4.Columns(COL4_OrderNum).Caption = rl3("STT") 'STT
        tdbg4.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg4.Columns("ShortName").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg4.Columns("Disabled").Caption = rl3("KSD") 'KSD
        '================================================================ 
        tdbg.Splits(0).Caption = rL3("Cac_tham_so_can_dinh_nghia") 'Các tham số cần định nghĩa
        '================================================================ 
        tdbdDecimals.Columns("ID").Caption = rL3("Ma") 'Mã

    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Code).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg3_LockedColumns()
        tdbg3.Splits(SPLIT0).DisplayColumns(COL3_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg4_LockedColumns()
        tdbg4.Splits(SPLIT0).DisplayColumns(COL4_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub CreateData()
        Dim sSQL As String
        sSQL = "Select Convert(bit,Disabled) As Disabled, Type, Code, Formula,Decimals, "
        sSQL &= "Description" & UnicodeJoin(gbUnicode) & " as Description, ShortName" & UnicodeJoin(gbUnicode) & " as ShortName" & vbCrLf
        sSQL &= "From D45T0010  WITH(NOLOCK) Order by Code"
        dtData = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadTDBGrid()
        Dim dt As DataTable
        '******************************
        'Load luoi 1
        dt = ReturnTableFilter(dtData.DefaultView.ToTable, "Type='QTY'", True)
        LoadDataSource(tdbg, dt, gbUnicode)
        'Gan gtri cho textbox Cong thuc
        tdbg.Bookmark = 0
        '******************************
        'Load luoi 2
        Dim sSQL As String = ""
        sSQL = "Select TransID, FormulaID, Description" & UnicodeJoin(gbUnicode) & " as Description" & vbCrLf
        sSQL &= "From D45V0011" & vbCrLf
        sSQL &= "Order by TransID"
        LoadDataSource(tdbg2, sSQL, gbUnicode)
        '******************************
        'Load lưới Đơn giá thường
        dt = ReturnTableFilter(dtData.DefaultView.ToTable, "Type='PRICE'", True)
        LoadDataSource(tdbg3, dt, gbUnicode)
        '******************************
        'Load lưới Đơn giá giờ công hệ số
        dt = ReturnTableFilter(dtData.DefaultView.ToTable, "Type='HAUnitPrice'", True)
        LoadDataSource(tdbg4, dt, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim dt As DataTable = New DataTable
        Dim dcName As New DataColumn
        dcName.ColumnName = "ID"
        dcName.DataType = Type.GetType("System.String")
        dcName.DefaultValue = ""
        dt.Columns.Add(dcName)
        dt.Rows.Add("0")
        dt.Rows.Add("1")
        dt.Rows.Add("2")
        dt.Rows.Add("3")
        dt.Rows.Add("4")
        LoadDataSource(tdbdDecimals, dt, gbUnicode)
    End Sub
    Private Sub CalFormular(ByVal sFormular As String)
        Dim iStart As Integer
        Dim sBefore As String = """"
        Dim sAfter As String = ""

        'Giu lai vtri con tro chuot dang dung va cat chuoi

        iStart = txtFormular.SelectionStart
        sBefore = txtFormular.Text.Substring(0, iStart)
        sAfter = txtFormular.Text.Substring(iStart, txtFormular.Text.Length - iStart)

        txtFormular.Text = sBefore & sFormular & sAfter

    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_Description).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_Description
                tdbg.Bookmark = i

                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg(tdbg.Row, COL_Formula) = txtFormular.Text
        tdbg.UpdateData()
        tdbg3.UpdateData()
        tdbg4.UpdateData()

        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Dim sSQL As New StringBuilder("")
        Select Case _FormState
            Case EnumFormState.FormAdd
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T0010s)
        End Select

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            Select Case _FormState
                Case EnumFormState.FormAdd

                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()

                    For i As Integer = 0 To tdbg.RowCount - 1
                        'RunAuditLog(AuditCodeQuantityUnitPrice, "02", tdbg3(0, COL3_Description).ToString, tdbg3(0, COL3_ShortName).ToString, tdbg(i, COL_Description).ToString, tdbg(i, COL_ShortName).ToString)
                        Lemon3.D91.RunAuditLog("45", AuditCodeQuantityUnitPrice, "02", tdbg3(0, COL3_Description).ToString, tdbg3(0, COL3_ShortName).ToString, tdbg(i, COL_Description).ToString, tdbg(i, COL_ShortName).ToString)
                    Next
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

#Region "tdbg"

    Private Sub tdbg_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeRowColChange
        tdbg.UpdateData()
        tdbg(tdbg.Row, COL_Formula) = txtFormular.Text
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control = True And e.KeyCode = Keys.V Then
            e.Handled = True
            e.SuppressKeyPress = True
            tdbg.Columns(tdbg.Col).Text = Clipboard.GetText()
            tdbg.UpdateData()
        End If
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.RowCount = 0 OrElse e.LastRow = tdbg.Bookmark Then Exit Sub
        'Gan gtri cho textbox Cong thuc
        txtFormular.Text = ""
        CalFormular(tdbg(tdbg.Row, COL_Formula).ToString)
    End Sub
#End Region

#Region "tdbg2"

    Private Sub tdbg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg2.DoubleClick
        'Gan gtri cho textbox Cong thuc
        CalFormular(tdbg2(tdbg2.Row, COL2_FormulaID).ToString)
    End Sub
#End Region

#Region "tdbg3"

    Private Sub tdbg3_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg3.BeforeColEdit
        Select Case e.ColIndex
            Case COL3_ShortName, COL3_Description
                If L3Bool(tdbg3.Columns(COL3_Disabled).Text) Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub tdbg3_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg3.UnboundColumnFetch
        e.Value = (e.Row + 1).ToString
    End Sub
#End Region

#Region "tdbg4"

    Private Sub tdbg4_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg4.BeforeColEdit
        Select Case e.ColIndex
            Case COL4_ShortName, COL4_Description
                If L3Bool(tdbg4.Columns(COL4_Disabled).Text) Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub tdbg4_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg4.UnboundColumnFetch
        e.Value = (e.Row + 1).ToString
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T0010
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 18/04/2007 10:28:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    'Private Function SQLUpdateD45T0010() As StringBuilder
    '    Dim sRet As New StringBuilder("")
    '    Dim sSQL As New StringBuilder("")

    '    For i As Integer = 0 To 5
    '        Select Case i
    '            Case 0
    '                sSQL.Append("Update D45T0010 Set ")
    '                sSQL.Append("Description = " & SQLStringUnicode(txtDescription01.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
    '                sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription01.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
    '                sSQL.Append("ShortName = " & SQLStringUnicode(txtShortName01.Text, gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
    '                sSQL.Append("ShortNameU = " & SQLStringUnicode(txtShortName01.Text, gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
    '                sSQL.Append("Disabled = " & SQLNumber(chkDisabled01.Checked)) 'tinyint, NOT NULL
    '                sSQL.Append(" Where ")
    '                sSQL.Append("Type = " & SQLString(txtType01.Text) & " And ")
    '                sSQL.Append("Code = " & SQLString(txtCode01.Text))

    '                sRet.Append(sSQL.ToString & vbCrLf)
    '                sSQL.Remove(0, sSQL.Length)
    '            Case 1
    '                sSQL.Append("Update D45T0010 Set ")
    '                sSQL.Append("Description = " & SQLStringUnicode(txtDescription02.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
    '                sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription02.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
    '                sSQL.Append("ShortName = " & SQLStringUnicode(txtShortName02.Text, gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
    '                sSQL.Append("ShortNameU = " & SQLStringUnicode(txtShortName02.Text, gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
    '                sSQL.Append("Disabled = " & SQLNumber(chkDisabled02.Checked)) 'tinyint, NOT NULL
    '                sSQL.Append(" Where ")
    '                sSQL.Append("Type = " & SQLString(txtType02.Text) & " And ")
    '                sSQL.Append("Code = " & SQLString(txtCode02.Text))

    '                sRet.Append(sSQL.ToString & vbCrLf)
    '                sSQL.Remove(0, sSQL.Length)
    '            Case 2
    '                sSQL.Append("Update D45T0010 Set ")
    '                sSQL.Append("Description = " & SQLStringUnicode(txtDescription03.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
    '                sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription03.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
    '                sSQL.Append("ShortName = " & SQLStringUnicode(txtShortName03.Text, gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
    '                sSQL.Append("ShortNameU = " & SQLStringUnicode(txtShortName03.Text, gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
    '                sSQL.Append("Disabled = " & SQLNumber(chkDisabled03.Checked)) 'tinyint, NOT NULL
    '                sSQL.Append(" Where ")
    '                sSQL.Append("Type = " & SQLString(txtType03.Text) & " And ")
    '                sSQL.Append("Code = " & SQLString(txtCode03.Text))

    '                sRet.Append(sSQL.ToString & vbCrLf)
    '                sSQL.Remove(0, sSQL.Length)
    '            Case 3
    '                sSQL.Append("Update D45T0010 Set ")
    '                sSQL.Append("Description = " & SQLStringUnicode(txtDescription04.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
    '                sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription04.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
    '                sSQL.Append("ShortName = " & SQLStringUnicode(txtShortName04.Text, gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
    '                sSQL.Append("ShortNameU = " & SQLStringUnicode(txtShortName04.Text, gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
    '                sSQL.Append("Disabled = " & SQLNumber(chkDisabled04.Checked)) 'tinyint, NOT NULL
    '                sSQL.Append(" Where ")
    '                sSQL.Append("Type = " & SQLString(txtType04.Text) & " And ")
    '                sSQL.Append("Code = " & SQLString(txtCode04.Text))

    '                sRet.Append(sSQL.ToString & vbCrLf)
    '                sSQL.Remove(0, sSQL.Length)
    '            Case 4
    '                sSQL.Append("Update D45T0010 Set ")
    '                sSQL.Append("Description = " & SQLStringUnicode(txtDescription05.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
    '                sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription05.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
    '                sSQL.Append("ShortName = " & SQLStringUnicode(txtShortName05.Text, gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
    '                sSQL.Append("ShortNameU = " & SQLStringUnicode(txtShortName05.Text, gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
    '                sSQL.Append("Disabled = " & SQLNumber(chkDisabled05.Checked)) 'tinyint, NOT NULL
    '                sSQL.Append(" Where ")
    '                sSQL.Append("Type = " & SQLString(txtType05.Text) & " And ")
    '                sSQL.Append("Code = " & SQLString(txtCode05.Text))

    '                sRet.Append(sSQL.ToString & vbCrLf)
    '                sSQL.Remove(0, sSQL.Length)
    '        End Select
    '    Next

    '    For i As Integer = 0 To tdbg.RowCount - 1
    '        sSQL.Append("Update D45T0010 Set ")
    '        sSQL.Append("Description = " & SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
    '        sSQL.Append("DescriptionU = " & SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
    '        sSQL.Append("ShortName = " & SQLStringUnicode(tdbg(i, COL_ShortName), gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
    '        sSQL.Append("ShortNameU = " & SQLStringUnicode(tdbg(i, COL_ShortName), gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
    '        sSQL.Append("Disabled = " & SQLNumber(tdbg(i, COL_Disabled)) & COMMA) 'tinyint, NOT NULL
    '        sSQL.Append("Formula = " & SQLString(tdbg(i, COL_Formula))) 'varchar[800], NOT NULL
    '        sSQL.Append(" Where ")
    '        sSQL.Append("Type = " & SQLString(tdbg(i, COL_Type)) & " And ")
    '        sSQL.Append("Code = " & SQLString(tdbg(i, COL_Code)))

    '        sRet.Append(sSQL.ToString & vbCrLf)
    '        sSQL.Remove(0, sSQL.Length)
    '    Next

    '    Return sRet
    'End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T0010s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/03/2012 03:45:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T0010s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        'Lưới Đơn giá thường
        For i As Integer = 0 To tdbg3.RowCount - 1
            sSQL.Append("Update D45T0010 Set ")
            sSQL.Append("Description = " & SQLStringUnicode(tdbg3(i, COL3_Description), gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
            sSQL.Append("ShortName = " & SQLStringUnicode(tdbg3(i, COL3_ShortName), gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("Disabled = " & SQLNumber(tdbg3(i, COL3_Disabled)) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(tdbg3(i, COL3_Description), gbUnicode, True) & COMMA) 'nvarchar[1000], NOT NULL
            sSQL.Append("ShortNameU = " & SQLStringUnicode(tdbg3(i, COL3_ShortName), gbUnicode, True) & COMMA) 'nvarchar[500], NOT NULL
            sSQL.Append("Decimals = " & SQLNumber(tdbg3(i, COL3_Decimals))) 'nvarchar[500], NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("Type = " & SQLString(tdbg3(i, COL3_Type)) & " And ")
            sSQL.Append("Code = " & SQLString(tdbg3(i, COL3_Code)))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next

        'Lưới Đơn giá giờ công hệ số
        For i As Integer = 0 To tdbg4.RowCount - 1
            sSQL.Append("Update D45T0010 Set ")
            sSQL.Append("Description = " & SQLStringUnicode(tdbg4(i, COL4_Description), gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
            sSQL.Append("ShortName = " & SQLStringUnicode(tdbg4(i, COL4_ShortName), gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("Disabled = " & SQLNumber(tdbg4(i, COL4_Disabled)) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(tdbg4(i, COL4_Description), gbUnicode, True) & COMMA) 'nvarchar[1000], NOT NULL
            sSQL.Append("ShortNameU = " & SQLStringUnicode(tdbg4(i, COL4_ShortName), gbUnicode, True)) 'nvarchar[500], NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("Type = " & SQLString(tdbg4(i, COL4_Type)) & " And ")
            sSQL.Append("Code = " & SQLString(tdbg4(i, COL4_Code)))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next

        'Lưới công thức
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Update D45T0010 Set ")
            sSQL.Append("Description = " & SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
            sSQL.Append("ShortName = " & SQLStringUnicode(tdbg(i, COL_ShortName), gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("ShortNameU = " & SQLStringUnicode(tdbg(i, COL_ShortName), gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("Disabled = " & SQLNumber(tdbg(i, COL_Disabled)) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("Formula = " & SQLString(tdbg(i, COL_Formula))) 'varchar[800], NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("Type = " & SQLString(tdbg(i, COL_Type)) & " And ")
            sSQL.Append("Code = " & SQLString(tdbg(i, COL_Code)))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next

        Return sRet
    End Function



End Class