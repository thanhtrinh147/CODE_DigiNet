Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 15/06/2011 10:27:50 AM
'# Created User: Thiên Huỳnh
'# Modify Date: 15/06/2011 10:27:50 AM
'# Modify User: Thiên Huỳnh
'#-------------------------------------------------------------------------------------
Public Class D45F1024
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_DetailTransID As Integer = 0 ' DetailTransID
    Private Const COL_TransID As Integer = 1       ' TransID
    Private Const COL_OrderNo As Integer = 2       ' OrderNo
    Private Const COL_ProductID As Integer = 3     ' ProductID
    Private Const COL_QtyFrom As Integer = 4       ' >= Số lượng
    Private Const COL_QtyTo As Integer = 5         ' < Số lượng
    Private Const COL_UnitPrice01 As Integer = 6   ' UnitPrice01
    Private Const COL_UnitPrice02 As Integer = 7   ' UnitPrice02
    Private Const COL_UnitPrice03 As Integer = 8   ' UnitPrice03
    Private Const COL_UnitPrice04 As Integer = 9   ' UnitPrice04
    Private Const COL_UnitPrice05 As Integer = 10  ' UnitPrice05
#End Region

    Private _priceListID As String
    Public WriteOnly Property PriceListID() As String
        Set(ByVal Value As String)
            _priceListID = Value
        End Set
    End Property

    Private _priceMethod As String
    Public WriteOnly Property PriceMethod() As String
        Set(ByVal Value As String)
            _priceMethod = Value
        End Set
    End Property

    Private _productID As String
    Public WriteOnly Property ProductID() As String
        Set(ByVal Value As String)
            _productID = Value
        End Set
    End Property

    Private _sProductName As String
    Public WriteOnly Property sProductName() As String
        Set(ByVal Value As String)
            _sProductName = Value
        End Set
    End Property

    Private _transID As String
    Public WriteOnly Property TransID() As String
        Set(ByVal Value As String)
            _transID = Value
        End Set
    End Property

    Private _stageID As String
    Public WriteOnly Property StageID() As String
        Set(ByVal Value As String)
            _stageID = Value
        End Set
    End Property

    Private Sub D45F1024_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ExecuteSQL("Exec D45P1024 " & SQLString(_priceListID) & ", '%', 0")
    End Sub

    Private Sub D45F1024_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F11
                HotKeyF11(Me, tdbg)
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub

    Private Sub D45F1024_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Loadlanguage()
        LoadTableCaptionPrice()
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadTDBGrid()
        txtProductID.Text = _productID
        txtProductName.Text = _sProductName
        InputbyUnicode(Me, gbUnicode)
        btnSave.Enabled = ReturnPermission("D45F1020") > 1
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String
        sSQL = "Select 0 As OrderNo, * From D45T1024  WITH(NOLOCK) Where PriceListID = " & SQLString(_priceListID)
        sSQL &= " And TransID = " & SQLString(_transID) & " Order By QtyFrom"
        LoadDataSource(tdbg, sSQL, gbUnicode)
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_QtyFrom).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_QtyFrom).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_QtyTo).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice01).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice03).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice04).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice05).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_bang_gia_theo_so_luong_-_D45F1024") & UnicodeCaption(gbUnicode) 'CËp nhËt b¶ng giÀ theo sç l§íng - D45F1024
        '================================================================ 
        lblProductID.Text = rl3("Ma_san_pham") 'Mã sản phẩm
        lblProductName.Text = rl3("Ten_san_pham") 'Tên sản phâm
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        grpPriceList.Text = rl3("Bang_gia") 'Bảng giá
        '================================================================ 
        tdbg.Columns("QtyFrom").Caption = ">= " & rl3("So_luong") '>= Số lượng
        tdbg.Columns("QtyTo").Caption = "< " & rl3("So_luong") '< Số lượng
    End Sub

    Private Sub LoadTableCaptionPrice()
        Dim sSQL As String
        Dim dtCaption As New DataTable
        Dim dtStageID As DataTable
        sSQL = "Select StageID, UP01, UP02, UP03, UP04, UP05 "
        sSQL &= "From D45T1010  WITH(NOLOCK) Where StageID = " & SQLString(_stageID)
        dtStageID = ReturnDataTable(sSQL)

        sSQL = "Select Code, ShortName" & UnicodeJoin(gbUnicode) & " As ShortName, Disabled From D45T0010 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Type = 'Price' Order By Code"
        dtCaption = ReturnDataTable(sSQL)

        For i As Integer = 0 To dtCaption.Rows.Count - 1
            tdbg.Splits(0).DisplayColumns(COL_UnitPrice01 + i).HeadingStyle.Font = FontUnicode(gbUnicode, FontStyle.Regular)
            tdbg.Columns(COL_UnitPrice01 + i).Caption = dtCaption.Rows(i).Item("ShortName").ToString
            If dtStageID.Rows.Count > 0 Then
                tdbg.Splits(0).DisplayColumns(COL_UnitPrice01 + i).Visible = Not L3Bool(dtCaption.Rows(i).Item("Disabled").ToString) And L3Bool(dtStageID.Rows(0).Item("UP" & (i + 1).ToString("00")).ToString)
            Else
                tdbg.Splits(0).DisplayColumns(COL_UnitPrice01 + i).Visible = Not L3Bool(dtCaption.Rows(i).Item("Disabled").ToString)
            End If
        Next
    End Sub

#Region "TDBG"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        If tdbg.Row = 0 Then
            tdbg.Columns(COL_QtyFrom).Text = SQLNumber("0", DxxFormat.DefaultNumber2)
        Else
            tdbg.Columns(COL_QtyFrom).Text = SQLNumber(Number(tdbg(tdbg.Row - 1, COL_QtyTo).ToString), DxxFormat.DefaultNumber2)
        End If
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_QtyFrom
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_QtyTo
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_UnitPrice01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_UnitPrice02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_UnitPrice03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_UnitPrice04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_UnitPrice05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_QtyFrom
                If Not L3IsNumeric(tdbg.Columns(COL_QtyFrom).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_QtyTo
                If Not L3IsNumeric(tdbg.Columns(COL_QtyTo).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_UnitPrice01
                If Not L3IsNumeric(tdbg.Columns(COL_UnitPrice01).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_UnitPrice02
                If Not L3IsNumeric(tdbg.Columns(COL_UnitPrice02).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_UnitPrice03
                If Not L3IsNumeric(tdbg.Columns(COL_UnitPrice03).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_UnitPrice04
                If Not L3IsNumeric(tdbg.Columns(COL_UnitPrice04).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_UnitPrice05
                If Not L3IsNumeric(tdbg.Columns(COL_UnitPrice05).Text, EnumDataType.Number) Then e.Cancel = True
        End Select
    End Sub

#End Region

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_QtyTo).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("So_luong"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_QtyTo
                tdbg.Bookmark = i
                Return False
            End If

            If Number(tdbg(i, COL_QtyFrom).ToString) >= Number(tdbg(i, COL_QtyTo).ToString) Then
                D99C0008.MsgL3(tdbg.Columns(COL_QtyFrom).Caption & Space(1) & rl3("phai_nho_hon") & Space(1) & tdbg.Columns(COL_QtyTo).Caption)
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_QtyTo
                tdbg.Bookmark = i
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        btnSave.Enabled = False
        btnClose.Enabled = False
        Dim sSQL As New StringBuilder("")
        _bSaved = False
        sSQL.Append("Delete D45T1024 Where PriceListID = " & SQLString(_priceListID) & " And TransID = " & SQLString(_transID) & vbCrLf)
        sSQL.Append(SQLInsertD45T1024s)

        Dim bRunSQL As Boolean
        bRunSQL = ExecuteSQL(sSQL.ToString)

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
            btnSave.Focus()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function SQLInsertD45T1024s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D45T1024(")
            sSQL.Append("TransID, PriceListID, ProductID, QtyFrom, ")
            sSQL.Append("QtyTo, UnitPrice01, UnitPrice02, UnitPrice03, UnitPrice04, ")
            sSQL.Append("UnitPrice05")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(_transID) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_priceListID) & COMMA) 'PriceListID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_productID) & COMMA) 'ProductID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_QtyFrom), DxxFormat.DefaultNumber2) & COMMA) 'QtyFrom, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_QtyTo), DxxFormat.DefaultNumber2) & COMMA) 'QtyTo, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice01), DxxFormat.DefaultNumber2) & COMMA) 'UnitPrice01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice02), DxxFormat.DefaultNumber2) & COMMA) 'UnitPrice02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice03), DxxFormat.DefaultNumber2) & COMMA) 'UnitPrice03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice04), DxxFormat.DefaultNumber2) & COMMA) 'UnitPrice04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice05), DxxFormat.DefaultNumber2)) 'UnitPrice05, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class