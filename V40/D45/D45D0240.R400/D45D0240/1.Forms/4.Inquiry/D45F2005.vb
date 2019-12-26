Public Class D45F2005
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_IsUsed As Integer = 0           ' Chọn
    Private Const COL_PayrollVoucherID As Integer = 1 ' PayrollVoucherID
    Private Const COL_PayrollVoucherNo As Integer = 2 ' Hồ sơ lương
    Private Const COL_VoucherTypeID As Integer = 3    ' Loại phiếu
    Private Const COL_TaskResultID As Integer = 4     ' TaskResultID
    Private Const COL_ProductVoucherNo As Integer = 5 ' Số phiếu
    Private Const COL_Note As Integer = 6             ' Diễn giải
    Private Const COL_VoucherDate As Integer = 7      ' Ngày phiếu
#End Region

    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
            sFind = Value
            Dim sSQL As New StringBuilder(434)
            sSQL.Append("Select CAST (0 AS BIT) as IsUsed,")
            sSQL.Append("'' as PayrollVoucherID, '' as PayrollVoucherNo,")
            sSQL.Append("VoucherTypeID, TaskResultID, TaskResultNo as ProductVoucherNo,")
            sSQL.Append("Description as Note,TaskResultDate as VoucherDate")
            sSQL.Append(" From D31T2360 WITH(NOLOCK) ")
            sSQL.Append(" Where	DivisionID = " & SQLString(gsDivisionID))
            sSQL.Append(" AND TranMonth = " & SQLNumber(giTranMonth))
            sSQL.Append(" AND TranYear = " & SQLNumber(giTranYear))
            sSQL.Append(" And " & sFind)
            sSQL.Append(" AND TaskResultID not in ")
            sSQL.Append("(Select ProductVoucherID From D45T2000  WITH(NOLOCK) Where IsD31 = 1)")
            sSQL.Append(" Order by	VoucherDate, TaskResultID")

            Dim dt As DataTable = ReturnDataTable(sSQL.ToString)
            If Not dt Is Nothing Then
                LoadDataSource(tdbg, dt)
            End If
            'ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
	End Property

    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
	'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As New StringBuilder(434)
        sSQL.Append("Select CAST (0 AS BIT) as IsUsed,")
        sSQL.Append("'' as PayrollVoucherID, '' as PayrollVoucherNo,")
        sSQL.Append("VoucherTypeID, TaskResultID, TaskResultNo as ProductVoucherNo,")
        sSQL.Append("Description as Note,TaskResultDate as VoucherDate")
        sSQL.Append(" From D31T2360 A  WITH(NOLOCK) " & vbCrLf)
        sSQL.Append(" Where	DivisionID = " & SQLString(gsDivisionID))
        sSQL.Append(" AND TranMonth = " & SQLNumber(giTranMonth))
        sSQL.Append(" AND TranYear = " & SQLNumber(giTranYear))
        sSQL.Append(" AND TaskResultID not in ")
        sSQL.Append("(Select ProductVoucherID From D45T2000  WITH(NOLOCK) Where IsD31 = 1)")
        If D45Systems.IsQC Then sSQL.Append("And EXISTS (Select top 1 1  From D34T2010 B  WITH(NOLOCK) Group by DCVoucherID Having A.TaskResultID=B.DCVoucherID)")
        sSQL.Append(vbCrLf & " Order by	VoucherDate, TaskResultID")

        LoadDataSource(tdbg, sSQL.ToString)

    End Sub
    Private Sub LoadTdbdPayrollVoucherNo()
        Dim sSQL As New StringBuilder(205)
        sSQL.Append("Select PayrollVoucherID, PayrollVoucherNo, Description")
        sSQL.Append(" From D13T0100  WITH(NOLOCK) ")
        sSQL.Append(" Where DivisionID  = " & SQLString(gsDivisionID))
        sSQL.Append(" AND TranYear = " & SQLNumber(giTranYear))
        sSQL.Append(" AND TranMonth = " & SQLNumber(giTranMonth))
        sSQL.Append(" Order by PayrollVoucherID")

        LoadDataSource(tdbdPayrollVoucherNo, sSQL.ToString)

    End Sub

    Private Sub D45F2005_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        SetShortcutPopupMenu(C1CommandHolder)
        LoadTdbdPayrollVoucherNo()
        LoadTDBGrid()
        Loadlanguage()
        If tdbg.RowCount > 0 Then
            mnuFind.Enabled = True
            mnuListAll.Enabled = True
        Else
            mnuFind.Enabled = False
            mnuListAll.Enabled = False
        End If

        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ke_thua_ket_qua_the_giao_viec_-_D45F2005") 'KÕ thôa kÕt qu¶ thÍ giao viÖc - D45F2005
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        '================================================================ 
        chkCheckAll.Text = rl3("Chon_tat_ca") 'Chọn tất cả
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem")
        mnuListAll.Text = rl3("_Liet_ke_tat_ca")
        tdbdPayrollVoucherNo.Columns("PayrollVoucherNo").Caption = rl3("Ma") 'Mã
        tdbdPayrollVoucherNo.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải 
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn

        tdbg.Columns("PayrollVoucherNo").Caption = rl3("Ho_so_luong") 'Hồ sơ lương
        tdbg.Columns("VoucherTypeID").Caption = rl3("Loai_phieu") 'Loại phiếu

        tdbg.Columns("ProductVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("Note").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
    End Sub

    Private Sub chkCheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheckAll.CheckedChanged
        If chkCheckAll.Checked Then
            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_IsUsed) = True
            Next i
        Else
            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_IsUsed) = False
            Next i
        End If
    End Sub

    'không cho nhập khi chưa check chọn
    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case e.ColIndex
            Case COL_PayrollVoucherNo
                If CBool(tdbg.Columns(COL_IsUsed).Value) = False Then
                    e.Cancel = True
                    tdbg.Columns(COL_PayrollVoucherNo).DropDown = Nothing
                    tdbg.Splits(0).DisplayColumns(COL_PayrollVoucherNo).AutoComplete = False
                    tdbg.Splits(0).DisplayColumns(COL_PayrollVoucherNo).AutoDropDown = False
                Else
                    tdbg.Columns(COL_PayrollVoucherNo).DropDown = tdbdPayrollVoucherNo
                    tdbg.Splits(0).DisplayColumns(COL_PayrollVoucherNo).AutoComplete = True
                    tdbg.Splits(0).DisplayColumns(COL_PayrollVoucherNo).AutoDropDown = True
                End If
        End Select
    End Sub
    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_PayrollVoucherNo
                tdbg.Columns(COL_PayrollVoucherNo).Text = tdbdPayrollVoucherNo.Columns("PayrollVoucherNo").Text
                tdbg.Columns(COL_PayrollVoucherID).Text = tdbdPayrollVoucherNo.Columns("PayrollVoucherID").Text
        End Select
    End Sub
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_PayrollVoucherNo
                If tdbg.Columns(COL_PayrollVoucherNo).Text <> tdbdPayrollVoucherNo.Columns("PayrollVoucherNo").Text Then
                    tdbg.Columns(COL_PayrollVoucherNo).Text = ""
                    tdbg.Columns(COL_PayrollVoucherID).Text = ""
                End If
        End Select
    End Sub
    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Try
            If tdbg.Col = COL_PayrollVoucherNo Then
                If CBool(tdbg.Columns(COL_IsUsed).Value) = False Then
                    tdbg.Columns(COL_PayrollVoucherNo).DropDown = Nothing
                    tdbg.Splits(0).DisplayColumns(COL_PayrollVoucherNo).AutoComplete = False
                    tdbg.Splits(0).DisplayColumns(COL_PayrollVoucherNo).AutoDropDown = False
                Else
                    tdbg.Columns(COL_PayrollVoucherNo).DropDown = tdbdPayrollVoucherNo
                    tdbg.Splits(0).DisplayColumns(COL_PayrollVoucherNo).AutoComplete = True
                    tdbg.Splits(0).DisplayColumns(COL_PayrollVoucherNo).AutoDropDown = True
                End If
            End If
        Catch
        End Try
    End Sub

    Private Function AllowCheck() As Boolean
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed)) = True Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Function AllowAction() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        If AllowCheck() = False Then
            D99C0008.MsgL3(rl3("Khong_co_dong_nao_duoc_chon"), L3MessageBoxIcon.Exclamation)
            Exit Function
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed)) = True Then
                If tdbg(i, COL_PayrollVoucherNo).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Ho_so_luong"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_PayrollVoucherNo
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        If Not AllowAction() Then Exit Sub

        _bSaved = False
        Dim sSQL As New StringBuilder
        sSQL.Append("CREATE TABLE #D45T2005(TaskResultID Varchar(20), PayrollVoucherID Varchar(20))")
        sSQL.Append(vbCrLf)

        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed)) = True Then
                sSQL.Append("Insert INTO #D45T2005(TaskResultID, PayrollVoucherID) VALUES (")
                sSQL.Append(SQLString(tdbg(i, COL_TaskResultID).ToString))
                sSQL.Append(",")
                sSQL.Append(SQLString(tdbg(i, COL_PayrollVoucherID).ToString))
                sSQL.Append(")")
                sSQL.Append(vbCrLf)
            End If
        Next

        sSQL.Append(SQLStoreD45P2005() & vbCrLf)

        sSQL.Append("DROP TABLE #D45T2005")
        Dim bResult As Boolean = ExecuteSQL(sSQL.ToString)
        If bResult Then
            _bSaved = True
            D99C0008.MsgL3(rl3("Ke_thua_thanh_cong"))
            Me.Close()
        Else
            D99C0008.MsgL3(rl3("Ke_thua_khong_thanh_cong"))
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2005
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 14/05/2007 04:15:19
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2005() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2005 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, smallint, NOT NULL
        Return sSQL
    End Function


    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        Dim sSQL As String
        gbEnabledUseFind = True
        sSQL = "Select * From D45V1234 Where FormID=" & SQLString("D45F2005") & " And Language='" & gsLanguage & "'"
        ShowFindDialog(Finder, sSQL)

    End Sub
    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    Try
    '        If ResultWhereClause Is Nothing Then Exit Sub
    '        sFind = ResultWhereClause.ToString
    '        If sFind = "" Then Exit Sub
    '        Dim sSQL As New StringBuilder(434)
    '        sSQL.Append("Select CAST (0 AS BIT) as IsUsed,")
    '        sSQL.Append("'' as PayrollVoucherID, '' as PayrollVoucherNo,")
    '        sSQL.Append("VoucherTypeID, TaskResultID, TaskResultNo as ProductVoucherNo,")
    '        sSQL.Append("Description as Note,TaskResultDate as VoucherDate")
    '        sSQL.Append(" From D31T2360 WITH(NOLOCK) ")
    '        sSQL.Append(" Where	DivisionID = " & SQLString(gsDivisionID))
    '        sSQL.Append(" AND TranMonth = " & SQLNumber(giTranMonth))
    '        sSQL.Append(" AND TranYear = " & SQLNumber(giTranYear))
    '        sSQL.Append(" And " & sFind)
    '        sSQL.Append(" AND TaskResultID not in ")
    '        sSQL.Append("(Select ProductVoucherID From D45T2000  WITH(NOLOCK) Where IsD31 = 1)")
    '        sSQL.Append(" Order by	VoucherDate, TaskResultID")

    '        Dim dt As DataTable = ReturnDataTable(sSQL.ToString)
    '        If Not dt Is Nothing Then
    '            LoadDataSource(tdbg, dt)
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub

        LoadTDBGrid()
        CheckMenu(Me.Name, C1CommandHolder, tdbg.Splits(SPLIT0).Rows.Count, gbEnabledUseFind, False)
    End Sub
End Class
