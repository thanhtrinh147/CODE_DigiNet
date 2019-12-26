Imports System
Public Class D45F2008
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Public dtGrid As DataTable

#Region "Const of tdbg"
    Private Const COL_SplitQTY As String = "SplitQTY" ' Số lượng tách
#End Region

    Private _sProductID As String
    Public WriteOnly Property sProductID() As String
        Set(ByVal Value As String)
            _sProductID = Value
        End Set
    End Property

    Private _sProductName As String
    Public WriteOnly Property sProductName() As String
        Set(ByVal Value As String)
            _sProductName = Value
        End Set
    End Property

    Private _quantity As String
    Public WriteOnly Property Quantity() As String
        Set(ByVal Value As String)
            _quantity = Value
        End Set
    End Property

    Private Sub D45F2008_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D45F2008_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        Loadlanguage()
        ResetFooterGrid(tdbg)
        LoadData()
        tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
        '*****************************************
        InputbyUnicode(Me, gbUnicode)
        CheckNumberTDBGrid()
        '********************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Tach_so_luong_-_D45F2008") & UnicodeCaption(gbUnicode) 'TÀch sç l§íng - D45F2008
        '================================================================ 
        lblProductID.Text = rl3("San_pham") 'Sản phẩm
        lblQuantity.Text = rl3("So_luong_can_tach") 'Số lượng cần tách
        '================================================================ 
        btnSplit.Text = rl3("_Tach") '&Tách
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("SplitQTY").Caption = rl3("So_luong_tach") 'Số lượng tách
    End Sub

    Private Sub CheckNumberTDBGrid()
        Dim arrCol() As FormatColumn = Nothing
        AddDecimalColumns(arrCol, COL_SplitQTY, DxxFormat.DefaultNumber2, 18, 4, True) 'Cột có DataType là Decimal(18,2), cho nhập số âm

        InputNumber(tdbg, arrCol)
    End Sub

    Private Sub LoadData()
        txtProductID.Text = _sProductID
        txtProductName.Text = _sProductName
        txtQuantity.Text = SQLNumber(_quantity, DxxFormat.DefaultNumber2)

        '****************************
        'Load luoi mac dinh dong dau tien la txtQuantity
        Dim sSQL As String = "Select convert(Decimal(18,4), " & Number(_quantity) & ") As SplitQTY"
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        FooterSumNew(tdbg, COL_SplitQTY)
        tdbg.AllowAddNew = False
    End Sub

#Region "Luoi"

    Private Sub tdbg_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeRowColChange
        If Number(_quantity) < Number(tdbg.Columns(COL_SplitQTY).FooterText) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case IndexOfColumn(tdbg, COL_SplitQTY)
                If L3IsNumeric(tdbg.Columns(COL_SplitQTY).Text, EnumDataType.Number) = False Then tdbg.Columns(COL_SplitQTY).Text = "0"
                '**************************************
                Dim dSum As Double = Number(dtGrid.Compute("SUM(SplitQTY)", dtGrid.DefaultView.RowFilter))
                tdbg.Columns(COL_SplitQTY).FooterText = dSum.ToString

                If Number(_quantity) < Number(tdbg.Columns(COL_SplitQTY).FooterText) Then
                    D99C0008.MsgL3(rl3("Tong_so_luong_tach_khong_bang_voi_so_luong_san_pham"))
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        FooterSumNew(tdbg, COL_SplitQTY)

        If Number(_quantity) <= Number(tdbg.Columns(COL_SplitQTY).FooterText) Then
            tdbg.AllowAddNew = False
        Else
            tdbg.AllowAddNew = True
        End If
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        FooterSumNew(tdbg, COL_SplitQTY)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Shift AndAlso e.KeyCode = Keys.Insert Then
            HotKeyShiftInsert(tdbg)
        ElseIf e.KeyCode = Keys.Enter AndAlso tdbg.Col = IndexOfColumn(tdbg, COL_SplitQTY) Then
            'Dung thuoc tinh cua luoi chu k dung ham HotKeyEnterGrid
            tdbg.UpdateData()
            'HotKeyEnterGrid(tdbg, COL_SplitQTY, e, 0)
        End If
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.RowCount <= 0 OrElse e.LastRow = tdbg.Row Then Exit Sub

        If Number(_quantity) <= Number(tdbg.Columns(COL_SplitQTY).FooterText) Then
            tdbg.AllowAddNew = False
            Exit Sub
        Else
            tdbg.AllowAddNew = True
        End If

        'Them dong moi va gan gia tri mac dinh
        If tdbg.Row = tdbg.RowCount Then
            Dim dr As DataRow = dtGrid.NewRow
            dtGrid.Rows.InsertAt(dr, tdbg.Row + 1)

            tdbg(tdbg.RowCount - 1, COL_SplitQTY) = Number(_quantity) - Number(tdbg.Columns(COL_SplitQTY).FooterText)
            FooterSumNew(tdbg, COL_SplitQTY)

            tdbg.Focus()
            tdbg.Bookmark = tdbg.Row
            tdbg.UpdateData()
        End If

    End Sub
#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSplit.Click
        If Number(_quantity) <> Number(tdbg.Columns(COL_SplitQTY).FooterText) Then
            D99C0008.MsgL3(rl3("Tong_so_luong_tach_khong_bang_voi_so_luong_san_pham"))
        Else
            _bSaved = True
            Me.Close()
        End If
    End Sub
End Class