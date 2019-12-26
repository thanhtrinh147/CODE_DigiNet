Imports System
Public Class D45F1071
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim dtGrid As DataTable
    Dim bNotInList_ProductID As Boolean = False

#Region "Const of tdbg"
    Private Const COL_ProductID As Integer = 0   ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 1 ' Tên sản phẩm
    Private Const COL_ShortName As Integer = 2   ' Tên tắt
    Private Const COL_Note As Integer = 3        ' Ghi chú
#End Region


    Private _groupProductID As String = ""
    Public Property GroupProductID() As String
        Get
            Return _groupProductID
        End Get
        Set(ByVal Value As String)
            _groupProductID = Value
        End Set
    End Property

    Private _groupProductName As String = ""
    Public WriteOnly Property GroupProductName() As String
        Set(ByVal Value As String)
            _groupProductName = Value
        End Set
    End Property

    Private _groupProductDesc As String = ""
    Public WriteOnly Property GroupProductDesc() As String
        Set(ByVal Value As String)
            _groupProductDesc = Value
        End Set
    End Property

    Private _disabled As Boolean = False
    Public WriteOnly Property Disabled() As Boolean
        Set(ByVal Value As Boolean)
            _disabled = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            LoadTDBDropDown()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadAddNew()
                    LoadTDBGrid()
                Case EnumFormState.FormEdit
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub D45F1041_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg, 0, COL_ProductID)
        End If
    End Sub

    Private Sub D45F1071_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetBackColorObligatory()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtGroupProductID)
        Loadlanguage()
        tdbg_LockedColumns()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_nhom_san_pham-_D45F1071") & UnicodeCaption(gbUnicode) 'CËp nhËt nhâm s¶n phÈm- D45F1071
        '================================================================ 
        lblGroupProductID.Text = rl3("Ma") 'Mã
        lblGroupProductName.Text = rl3("Ten") 'Tên
        lblGroupProductDesc.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        grpList.Text = rl3("Danh_sach_san_pham") 'Danh sách sản phẩm
        '================================================================ 
        tdbdProductID.Columns("ProductID").Caption = rl3("Ma") 'Mã
        tdbdProductID.Columns("ProductName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns("ShortName").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg.Columns("Note").Caption = rl3("Ghi_chu") 'Ghi chú
    End Sub

    Private Sub SetBackColorObligatory()
        txtGroupProductID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtGroupProductName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ShortName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Note).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadAddNew()
        btnSave.Enabled = True
        btnNext.Enabled = False

        chkDisabled.Checked = False
        txtGroupProductID.Text = ""
        txtGroupProductName.Text = ""
        txtGroupProductDesc.Text = ""
    End Sub

    Private Sub LoadEdit()
        txtGroupProductID.Text = _groupProductID
        txtGroupProductName.Text = _groupProductName
        txtGroupProductDesc.Text = _groupProductDesc
        chkDisabled.Checked = _disabled
        ReadOnlyControl(txtGroupProductID)
        '--------------------------
        LoadTDBGrid()
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdProductID
        sSQL = "SELECT D45.ProductID, D45.ProductName" & UnicodeJoin(gbUnicode) & " as ProductName, D45.ShortName" & UnicodeJoin(gbUnicode) & " as ShortName, D45.Note" & UnicodeJoin(gbUnicode) & " as Note" & vbCrLf
        sSQL &= "FROM D45T1000 D45 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE D45.Disabled = 0" & vbCrLf
        sSQL &= "Order by D45.ProductID"
        LoadDataSource(tdbdProductID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL = "Select D2.ProductID, D1.ProductName" & UnicodeJoin(gbUnicode) & " as ProductName, D1.ShortName" & UnicodeJoin(gbUnicode) & " as ShortName, D1.Note" & UnicodeJoin(gbUnicode) & " as Note" & vbCrLf
        sSQL &= "From D45T1071 D2  WITH(NOLOCK) Inner Join D45T1000 D1  WITH(NOLOCK) On D1.ProductID=D2.ProductID"
        sSQL &= " And D2.GroupProductID=" & SQLString(_groupProductID) & " And D1.Disabled=0" & vbCrLf
        sSQL &= "Order by D2.ProductID"
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        If D45Options.SaveLastRecent = False Then
            LoadAddNew()
        End If

        'Xoa rong luoi
        dtGrid.Clear()
        tdbg.UpdateData()

        txtGroupProductID.Focus()
    End Sub

    Private Function AllowSave() As Boolean
        If txtGroupProductID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtGroupProductID.Focus()
            Return False
        End If
        If txtGroupProductName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten"))
            txtGroupProductName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D45T1070", "GroupProductID", txtGroupProductID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtGroupProductID.Focus()
                Return False
            End If
        End If
        Return True
    End Function


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg.UpdateData()

        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD45T1070.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1071s.ToString & vbCrLf)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1070.ToString & vbCrLf)
                sSQL.Append(SQLDeleteD45T1071.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1071s.ToString & vbCrLf)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _groupProductID = txtGroupProductID.Text
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_ProductID
                If bNotInList_ProductID Then
                    tdbg.Columns(COL_ProductID).Text = ""
                    tdbg.Columns(COL_ProductName).Text = ""
                    tdbg.Columns(COL_ShortName).Text = ""
                    tdbg.Columns(COL_Note).Text = ""
                Else
                    tdbg.Columns(COL_ProductName).Text = tdbdProductID.Columns("ProductName").Text
                    tdbg.Columns(COL_ShortName).Text = tdbdProductID.Columns("ShortName").Text
                    tdbg.Columns(COL_Note).Text = tdbdProductID.Columns("Note").Text
                End If
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_ProductID
                If tdbg.Columns(COL_ProductID).Text <> tdbdProductID.Columns("ProductID").Text Then
                    bNotInList_ProductID = True
                Else
                    bNotInList_ProductID = False

                    If ExitsValue(tdbg, COL_ProductID, tdbg.Columns(COL_ProductID).Text, tdbg.Row) Then
                        D99C0008.MsgDuplicatePKey()
                        tdbg.Columns(COL_ProductID).Text = ""
                        tdbg.Columns(COL_ProductName).Text = ""
                        tdbg.Columns(COL_ShortName).Text = ""
                        tdbg.Columns(COL_Note).Text = ""
                        e.Cancel = True
                    End If
                End If
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
            Exit Sub
        ElseIf e.Shift And e.KeyCode = Keys.Insert Then
            HotKeyShiftInsert(tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter And tdbg.Col = COL_ProductID Then
            HotKeyEnterGrid(tdbg, COL_ProductID, e)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_ProductID, 0)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1070
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 04/03/2010 09:55:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1070() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D45T1070(")
        sSQL.Append("GroupProductID, GroupProductName, GroupProductNameU, GroupProductDesc, GroupProductDescU, Disabled, CreateUserID, ")
        sSQL.Append("LastModifyUserID, CreateDate, LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtGroupProductID.Text) & COMMA) 'GroupProductID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtGroupProductName.Text, gbUnicode, False) & COMMA) 'GroupProductName, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtGroupProductName.Text, gbUnicode, True) & COMMA) 'GroupProductName, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtGroupProductDesc.Text, gbUnicode, False) & COMMA) 'GroupProductDesc, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtGroupProductDesc.Text, gbUnicode, True) & COMMA) 'GroupProductDesc, varchar[150], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T1070
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 04/03/2010 09:45:12
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T1070() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T1070 Set ")
        sSQL.Append("GroupProductName = " & SQLStringUnicode(txtGroupProductName.Text, gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("GroupProductNameU = " & SQLStringUnicode(txtGroupProductName.Text, gbUnicode, True) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("GroupProductDesc = " & SQLStringUnicode(txtGroupProductDesc.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("GroupProductDescU = " & SQLStringUnicode(txtGroupProductDesc.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("GroupProductID = " & SQLString(_groupProductID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T1071
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 04/03/2010 09:45:31
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T1071() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T1071"
        sSQL &= " Where GroupProductID=" & SQLString(_groupProductID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1071s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 04/03/2010 09:45:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1071s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D45T1071(")
            sSQL.Append("GroupProductID, ProductID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtGroupProductID.Text) & COMMA) 'GroupProductID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ProductID))) 'ProductID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


End Class