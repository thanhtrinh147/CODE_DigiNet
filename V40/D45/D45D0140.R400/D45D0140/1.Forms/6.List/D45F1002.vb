'#-------------------------------------------------------------------------------------
'# Created Date: 14/05/2007 8:21:58 AM
'# Created User: Đỗ Minh Dũng
'# Modify Date: 14/05/2007 8:21:58 AM
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D45F1002
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_IsUsed As Integer = 0          ' Chọn
    Private Const COL_ProductID As Integer = 1       ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 2     ' Tên sản phẩm
    Private Const COL_TransactionDate As Integer = 3 ' Ngày phát sinh
    Private Const COL_SRoutingID As Integer = 4      ' Quy trình sx chuẩn
#End Region

    Dim bCheck As Boolean = False
    Dim dtFind As DataTable
    Dim bSelected As Boolean = False

    Private Sub D45F1002_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        gbEnabledUseFind = False
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)

        Loadlanguage()

        LoadTDBDropdown()
        tdbg_LockedColumns()
        LoadTDBGrid()

        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ke_thua_san_pham_-_D45F1002") & UnicodeCaption(gbUnicode) 'KÕ thôa s¶n phÈm - D45F1002
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("ProductID").Caption = rl3("Ma") 'Mã sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten") 'Tên sản phẩm
        tdbg.Columns("TransactionDate").Caption = rl3("Ngay_phat_sinh") 'Ngày phát sinh
        tdbg.Columns("SRoutingID").Caption = rl3("Quy_trinh_sx_chuan") 'Quy trình sx chuẩn

    End Sub

    Private Sub LoadTDBDropdown()
        Dim sSQL As String = ""
        'Load SRoutingID
        sSQL = "Select SRoutingID, SRoutingName" & UnicodeJoin(gbUnicode) & " AS SRoutingName From D45T1030  WITH(NOLOCK) Where Disabled=0 Order by SRoutingID"
        LoadDataSource(tdbdSRoutingID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As New StringBuilder
        sSQL.Append("SELECT Cast(0 as bit )as IsUsed , InventoryID AS ProductID,'' as SRoutingID,")
        sSQL.Append(" InventoryName" & UnicodeJoin(gbUnicode) & " AS ProductName,")
        sSQL.Append(" CreateDate AS TransactionDate")
        sSQL.Append(" FROM D07T0002 WITH(NOLOCK) ")
        sSQL.Append(" WHERE Disabled = 0 AND IsD45 = 1 AND InventoryID NOT IN")
        sSQL.Append(" (SELECT ProductID FROM D45T1000 WITH(NOLOCK) )")
        sSQL.Append(" ORDER BY InventoryID")
        dtFind = ReturnDataTable(sSQL.ToString)
        LoadDataSource(tdbg, dtFind, gbUnicode)
        CheckMyMenu()
    End Sub

    Private Sub CheckMyMenu()
        CheckMenu(Me.Name, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        tsbInherit.Enabled = tdbg.RowCount > 0
        tsmInherit.Enabled = tdbg.RowCount > 0
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProductID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TransactionDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub PressHeadClick()
        Dim bChoose As Boolean = Not bSelected
        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, COL_IsUsed) = bChoose
        Next i
        bSelected = bChoose
    End Sub


#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
	'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property


    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        sSQL = "Select * From D45V1234 "
        sSQL &= "Where FormID = " & SQLString(Me) & "And Language = " & SQLString(gsLanguage)
        ShowFindDialogClient(Finder, sSQL, gbUnicode)
    End Sub

    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Then Exit Sub
        sFind = ResultWhereClause.ToString()
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        LoadGridFind(tdbg, dtFind, sFind)
        CheckMyMenu()
    End Sub
#End Region

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case e.ColIndex
            Case COL_SRoutingID
                If CBool(tdbg.Columns(COL_IsUsed).Text) = False Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex()
            Case COL_IsUsed
                PressHeadClick()
            Case COL_SRoutingID
                CopyColumns()
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            PressHeadClick()
        End If
    End Sub

    Private Sub CopyColumns()
        Try
            If tdbg.RowCount < 2 Then Exit Sub
            tdbg.UpdateData()
            Dim Flag As DialogResult
            Flag = D99C0008.MsgCopyColumn()
            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                For i As Integer = 0 To tdbg.RowCount - 1
                    If tdbg(i, COL_SRoutingID).ToString = "" And CBool(tdbg(i, COL_IsUsed)) Then tdbg(i, COL_SRoutingID) = tdbg.Columns(COL_SRoutingID).Text
                Next
            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = 0 To tdbg.RowCount - 1
                    If CBool(tdbg(i, COL_IsUsed)) Then tdbg(i, COL_SRoutingID) = tdbg.Columns(COL_SRoutingID).Text
                Next
            Else
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub tsbInherit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbInherit.Click, tsmInherit.Click, mnsInherit.Click
        If Not AllowInherit() Then Exit Sub
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            Exit Sub
        End If
        Dim sSQL As New StringBuilder
        sSQL.Append("Create Table #D45T1000 (ProductID Varchar(20),SRoutingID Varchar(20))")
        sSQL.Append(vbCrLf)
        Dim iCount As Integer = 0
        Dim bResult As Boolean = True
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed)) = True Then
                sSQL.Append("Insert INTO #D45T1000(ProductID,SRoutingID) VALUES (")
                sSQL.Append(SQLString(tdbg(i, COL_ProductID).ToString) & COMMA)
                sSQL.Append(SQLString(tdbg(i, COL_SRoutingID).ToString))
                sSQL.Append(")")
                sSQL.Append(vbCrLf)
                iCount += 1
            End If
            If iCount = 2000 Then
                sSQL.Append(SQLStoreD45P1000() & vbCrLf)
                sSQL.Append("DROP TABLE #D45T1000")
                bResult = ExecuteSQL(sSQL.ToString)
                iCount = 0
                sSQL.Remove(0, sSQL.Length)
                sSQL.Append("Create Table #D45T1000 (ProductID Varchar(20),SRoutingID Varchar(20))")
                sSQL.Append(vbCrLf)
            End If
        Next
        If sSQL.ToString <> "" Then
            sSQL.Append(SQLStoreD45P1000() & vbCrLf)
            sSQL.Append("DROP TABLE #D45T1000")
            bResult = ExecuteSQL(sSQL.ToString)
        End If
        If bResult Then
            _bSaved = True
            D99C0008.MsgL3(rl3("Ke_thua_thanh_cong"))
            Me.Close()
        Else
            D99C0008.MsgL3(rl3("Ke_thua_khong_thanh_cong"))
        End If
    End Sub
    
    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub


    Private Function AllowInherit() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_IsUsed).ToString = "" Then
                D99C0008.MsgL3(rl3("MSG000010"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_IsUsed
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
        Next
        Return True
    End Function

    Private Function SQLStoreD45P1000() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P1000 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

End Class
