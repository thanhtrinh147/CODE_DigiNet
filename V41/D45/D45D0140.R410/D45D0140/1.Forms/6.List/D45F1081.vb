Imports System
Public Class D45F1081
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_RoutingTransID As Integer = 0 ' RoutingTransID
    Private Const COL_OrderNum As Integer = 1       ' STT
    Private Const COL_StageID As Integer = 2        ' Mã công đoạn
    Private Const COL_StageName As Integer = 3      ' Tên công đoạn
#End Region

    Private _routingID As String = ""
    Public Property RoutingID() As String
        Get
            Return _routingID
        End Get
        Set(ByVal Value As String)
            _routingID = Value
        End Set
    End Property

    Private _productID As String = ""
    Public WriteOnly Property ProductID() As String
        Set(ByVal Value As String)
            _productID = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            LoadDropDown()

            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadCombo()
                    tdbcProductID.Text = _productID
                Case EnumFormState.FormCopy
                    LoadCombo()
                    LoadMaster()
                Case EnumFormState.FormEdit
                    LoadCombo(False)
                    LoadMaster()
                Case EnumFormState.FormView
                    LoadCombo(False)
                    LoadMaster()
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_quy_trinh_san_xuat_san_pham_-_D45F1081") & UnicodeCaption(gbUnicode) 'CËp nhËt quy trØnh s¶n xuÊt s¶n phÈm - D45F1081
        '================================================================ 
        lblProductID.Text = rl3("San_pham") 'Sản phẩm
        lblRoutingNum.Text = rl3("Ma_quy_trinh") 'Mã quy trình
        lblRoutingDesc.Text = rl3("Ten_quy_trinh") 'Tên quy trình
        lblSRoutingID.Text = rl3("Quy_trinh_chuan") 'Quy trình chuẩn
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        tdbcProductID.Columns("ProductID").Caption = rl3("Ma") 'Mã
        tdbcProductID.Columns("ProductName").Caption = rl3("Ten") 'Tên
        tdbcSRoutingID.Columns("SRoutingID").Caption = rl3("Ma") 'Mã
        tdbcSRoutingID.Columns("SRoutingName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("OrderNum").Caption = rl3("STT") 'STT
        tdbg.Columns("StageID").Caption = rl3("Ma_cong_doan") 'Mã công đoạn
        tdbg.Columns("StageName").Caption = rl3("Ten_cong_doan") 'Tên công đoạn
    End Sub

    Private Sub D45F1081_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        SetBackColorObligatory()
        tdbg_LockedColumns()
        LoadTDBGrid()
        '*********************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtRoutingNum)
        '*********************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadCombo(Optional ByVal bAddNew As Boolean = True)
        Dim sSQL As String = ""
        'Kiểm tra chỉ load dữ liệu cho combo tdbcProductID khi thêm mới
        If bAddNew Then
            sSQL = "Select ProductID, ProductName" & UnicodeJoin(gbUnicode) & " as ProductName " & vbCrLf
            sSQL &= "From D45T1000  WITH(NOLOCK) Where Disabled = 0 Order by ProductID"
            LoadDataSource(tdbcProductID, sSQL, gbUnicode)
        End If
        sSQL = "Select SRoutingID, SRoutingName" & UnicodeJoin(gbUnicode) & " as SRoutingName " & vbCrLf
        sSQL &= "From D45T1030  WITH(NOLOCK) Where Disabled = 0 Order by SRoutingID "
        LoadDataSource(tdbcSRoutingID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadDropDown()
        Dim sSQL As String = ""
        sSQL = "Select StageID, StageName" & UnicodeJoin(gbUnicode) & " as StageName" & vbCrLf
        sSQL &= "From D45T1010  WITH(NOLOCK) Where Disabled = 0 Order by DisPlayOrder, StageID"
        LoadDataSource(tdbdStageID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadMaster()
        Dim dt As DataTable
        Dim sSQL As String = ""
        sSQL = "Select T80.RoutingID,T80.ProductID, T80.RoutingNum, " & vbCrLf
        sSQL &= "T80.RoutingDesc" & UnicodeJoin(gbUnicode) & " as RoutingDesc, T00.ProductName" & UnicodeJoin(gbUnicode) & " as ProductName, " & vbCrLf
        sSQL &= "T80.SRoutingID, T80.Disabled, T80.DivisionID " & vbCrLf
        sSQL &= "From D45T1080 T80  WITH(NOLOCK) Inner Join D45T1000 T00  WITH(NOLOCK) On T00.ProductID=T80.ProductID " & vbCrLf
        sSQL &= "Where T80.RoutingID =  " & SQLString(_routingID)
        dt = ReturnDataTable(sSQL)

        txtRoutingNum.Text = dt.Rows(0).Item("RoutingNum").ToString
        txtRoutingDesc.Text = dt.Rows(0).Item("RoutingDesc").ToString
        tdbcSRoutingID.Text = dt.Rows(0).Item("SRoutingID").ToString
        chkDisabled.Checked = L3Bool(dt.Rows(0).Item("Disabled").ToString)
        txtProductName.Text = dt.Rows(0).Item("ProductName").ToString

        'Kiểm tra nếu là xem/sửa thì gán giá trị cho combo ProductID, khoá control tdbcProductID, txtRoutingNum lại. 
        'Nếu là kế thừa thì combo ProductID để trống, không khoá control tdbcProductID, txtRoutingNum lại. 
        If _FormState = EnumFormState.FormEdit OrElse _FormState = EnumFormState.FormView Then 'Sửa/Xem
            tdbcProductID.Text = dt.Rows(0).Item("ProductID").ToString
            ReadOnlyControl(tdbcProductID, txtRoutingNum)
        End If
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bFlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""

        sSQL = "Select T81.RoutingTransID, T81.OrderNum, T81.StageID, T10.StageName" & UnicodeJoin(gbUnicode) & " as StageName " & vbCrLf
        sSQL &= "From D45T1081 T81 Inner join D45T1010 T10 On T10.StageID = T81.StageID " & vbCrLf
        sSQL &= "Where T81.RoutingID = " & SQLString(_routingID) & " Order by T81.OrderNum"

        LoadDataSource(tdbg, sSQL, gbUnicode)
        UpdateTDBGOrderNum(tdbg, COL_OrderNum, , False)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcProductID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtRoutingNum.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtRoutingDesc.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StageName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

#Region "Events tdbcProductID with txtProductName"

    Private Sub tdbcProductID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.SelectedValueChanged
        txtProductName.Text = ReturnValueC1Combo(tdbcProductID, "ProductName").ToString
    End Sub

    Private Sub tdbcProductID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.LostFocus
        If tdbcProductID.ReadOnly Then Exit Sub
        If tdbcProductID.FindStringExact(tdbcProductID.Text) = -1 Then
            tdbcProductID.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcSRoutingID with txtSRoutingName"

    Private Sub tdbcSRoutingID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSRoutingID.SelectedValueChanged
        txtSRoutingName.Text = ReturnValueC1Combo(tdbcSRoutingID, "SroutingName").ToString
    End Sub

    Private Sub tdbcSRoutingID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSRoutingID.LostFocus
        If tdbcSRoutingID.FindStringExact(tdbcSRoutingID.Text) = -1 Then
            tdbcSRoutingID.Text = ""
        End If
    End Sub

#End Region

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        If tdbg.Columns(COL_StageID).Text <> ReturnValueC1DropDown(tdbdStageID, "StageID") Then
            tdbg.Columns(COL_StageID).Text = ""
            tdbg.Columns(COL_StageName).Text = ""
        Else
            tdbg.Columns(COL_StageID).Text = ReturnValueC1DropDown(tdbdStageID, "StageID")
            tdbg.Columns(COL_StageName).Text = ReturnValueC1DropDown(tdbdStageID, "StageName")
        End If
        UpdateTDBGOrderNum(tdbg, COL_OrderNum)
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_OrderNum
                e.Handled = CheckKeyPress(e.KeyChar, True)
        End Select
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcProductID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("San_pham"))
            tdbcProductID.Focus()
            Return False
        End If
        If txtRoutingNum.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_quy_trinh"))
            txtRoutingNum.Focus()
            Return False
        End If
        If txtRoutingDesc.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_quy_trinh"))
            txtRoutingDesc.Focus()
            Return False
        End If
        Dim arrField(1) As String
        arrField(0) = "RoutingNum"
        arrField(1) = "ProductID"
        Dim arrText(1) As String
        arrText(0) = txtRoutingNum.Text
        arrText(1) = tdbcProductID.Text
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D45T1080", arrField, arrText) Then
                D99C0008.MsgDuplicatePKey()
                txtRoutingNum.Focus()
                Return False
            End If
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_StageID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ma_cong_doan"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_StageID
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
        Next
        For i As Integer = 0 To tdbg.RowCount - 2
            For j As Integer = i + 1 To tdbg.RowCount - 1
                If tdbg(i, COL_StageID).ToString = tdbg(j, COL_StageID).ToString Then
                    D99C0008.MsgDuplicatePKey()
                    tdbg.Col = COL_StageID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD45T1080().ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1081s())
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1080().ToString & vbCrLf)
                sSQL.Append(SQLDeleteD45T1081s().ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1081s)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
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

    Private Function SQLInsertD45T1080() As StringBuilder
        'Sinh key tăng tự động cho Master
        _routingID = CreateIGE("D45T1080", "RoutingID", "45", "MR", gsStringKey)

        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D45T1080(")
        sSQL.Append("RoutingID, ProductID, RoutingNum, RoutingDesc, RoutingDescU, ")
        sSQL.Append("SRoutingID, Disabled, CreateDate, CreateUserID, LastModifyDate, ")
        sSQL.Append("LastModifyUserID, DivisionID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(_routingID) & COMMA) 'RoutingID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcProductID.Text) & COMMA) 'ProductID, varchar[20], NOT NULL
        sSQL.Append(SQLString(txtRoutingNum.Text) & COMMA) 'RoutingNum, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtRoutingDesc.Text, gbUnicode, False) & COMMA) 'RoutingDesc, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtRoutingDesc.Text, gbUnicode, True) & COMMA) 'RoutingDescU, nvarchar, NOT NULL
        sSQL.Append(SQLString(tdbcSRoutingID.Text) & COMMA) 'SRoutingID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsDivisionID)) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    Private Function SQLInsertD45T1081s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim iCountIGE As Long = 0
        Dim iFirstIGE As Long
        Dim sRoutingTransID As String = ""

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_RoutingTransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next
        iCountIGE = tdbg.RowCount
        For i As Integer = 0 To tdbg.RowCount - 1
            'Sinh key tăng tự động cho Details
            If tdbg(i, COL_RoutingTransID).ToString = "" Then
                sRoutingTransID = CreateIGENewS("D45T1081", "RoutingTransID", "45", "DR", gsStringKey, sRoutingTransID, iCountIGE, iFirstIGE)
                tdbg(i, COL_RoutingTransID) = sRoutingTransID
            End If

            sSQL.Append("Insert Into D45T1081(")
            sSQL.Append("RoutingTransID, RoutingID, ProductID, RoutingNum, OrderNum, ")
            sSQL.Append("StageID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg(i, COL_RoutingTransID)) & COMMA) 'RoutingTransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_routingID) & COMMA) 'RoutingID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbcProductID.Text) & COMMA) 'ProductID, varchar[20], NOT NULL
            sSQL.Append(SQLString(txtRoutingNum.Text) & COMMA) 'RoutingNum, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_OrderNum)) & COMMA) 'OrderNum, int, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_StageID))) 'StageID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function SQLDeleteD45T1081s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL = ""
            sSQL &= "Delete From D45T1081"
            sSQL &= " Where RoutingID = " & SQLString(_routingID)
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function



    Private Function SQLUpdateD45T1080() As StringBuilder
        Dim sSQL As New StringBuilder

        sSQL.Append("Update D45T1080 Set ")
        sSQL.Append("ProductID = " & SQLString(tdbcProductID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("RoutingNum = " & SQLString(txtRoutingNum.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("RoutingDesc = " & SQLStringUnicode(txtRoutingDesc.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("RoutingDescU = " & SQLStringUnicode(txtRoutingDesc.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("SRoutingID = " & SQLString(tdbcSRoutingID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("DivisionID = " & SQLString(gsDivisionID)) 'varchar[20], NOT NULL
        sSQL.Append(" Where RoutingID = " & SQLString(_routingID))
        Return sSQL
    End Function

    Private Sub btnReSetGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReSetGrid.Click
        Dim sSQL As String = ""
        sSQL = "Select 0 as OrderNum, '' as RoutingTransID, T31.StageID, T10.StageName" & UnicodeJoin(gbUnicode) & " as StageName" & vbCrLf
        sSQL &= "From D45T1031 T31  WITH(NOLOCK) Inner Join D45T1010 T10  WITH(NOLOCK) ON T31.StageID = T10.StageID" & vbCrLf
        sSQL &= "Where SRoutingID = " & SQLString(tdbcSRoutingID.Text) & "  Order By T31.OrderNo"
        LoadDataSource(tdbg, sSQL, gbUnicode)
        UpdateTDBGOrderNum(tdbg, COL_OrderNum)
    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        ClearText(Me)
        btnNext.Enabled = False
        btnSave.Enabled = True
        _routingID = ""
        LoadTDBGrid()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class