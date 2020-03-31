Imports System
Public Class D13F1100
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_ResultReferenceID As Integer = 0   ' Mã
    Private COL_ResultReferenceName As Integer = 1 ' Diễn giải
    Private COL_Notice As Integer = 2              ' Ghi chú
    Private Const COL_Disabled As Integer = 3            ' Không sử dụng
    Private Const COL_CreateUserID As Integer = 4        ' CreateUserID
    Private Const COL_CreateDate As Integer = 5          ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 6      ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 7      ' LastModifyDate
#End Region

    Dim dtGrid, dtCaptionCols As DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Private _formIDPermission As String = "D13F1100"
    Public WriteOnly Property FormIDPermission() As String 
        Set(ByVal Value As String )
            _formIDPermission = Value
        End Set
    End Property

    Private Sub D13F1100_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        gbEnabledUseFind = False
        Loadlanguage()
        ResetColorGrid(tdbg)
        LoadTDBGrid()
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        Me.Text = rl3("Bang_tham_chieu_ket_quaF") & " - D13F1100" & UnicodeCaption(gbUnicode) 'B¶ng tham chiÕu kÕt qu¶ - D13F1100
        If _formIDPermission <> "" Then
            Select Case _formIDPermission.Substring(0, 3)
                Case "D52"
                    Me.Text = rl3("Bang_tham_chieu_ket_quaF") & " - " & _formIDPermission & UnicodeCaption(gbUnicode)
                Case "D29"
                    Me.Text = rl3("Bang_tham_chieu_ket_quaF") & " - " & _formIDPermission & UnicodeCaption(gbUnicode)
            End Select
        End If
        '================================================================ 
        tdbg.Columns("ResultReferenceID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("ResultReferenceName").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns("Notice").Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Columns("Disabled").Caption = rL3("KSD") 'KSD
        '================================================================ 
        chkShowDisabled.Text = rL3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL &= "select ResultReferenceID, ResultReferenceName" & UnicodeJoin(gbUnicode) & " As ResultReferenceName, Notice" & UnicodeJoin(gbUnicode) & " As Notice, Disabled," & vbCrLf
        sSQL &= "CreateUserID, CreateDate, LastModifyUserID, LastModifyDate " & vbCrLf
        sSQL &= "From D13T1100  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Order by ResultReferenceID"
        dtGrid = ReturnDataTable(sSQL)

        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("ResultReferenceID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0))
        End If

        If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled = 0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_ResultReferenceID)
    End Sub

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        '72334
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , , , gbUnicode)
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.Tostring = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

#End Region

#Region "Menu bar"

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim frm As New D13F1101
        With frm
            .ResultReferenceID = ""
            .FormIDPermission = _formIDPermission
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            If .bSaved = True Then
                LoadTDBGrid(True, .ResultReferenceID)
            End If
            .Dispose()
        End With

    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim frm As New D13F1101
        With frm
            .ResultReferenceID = tdbg.Columns(COL_ResultReferenceID).Text
            .FormIDPermission = _formIDPermission
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        If Not CheckStore(SQLStoreD13P5555(2)) Then Exit Sub
        Dim frm As New D13F1101
        With frm
            .ResultReferenceID = tdbg.Columns(COL_ResultReferenceID).Text
            .FormIDPermission = _formIDPermission
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            If .bSaved Then LoadTDBGrid(False, tdbg.Columns(COL_ResultReferenceID).Text)
            .Dispose()
        End With

    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If Not CheckStore(SQLStoreD13P5555(1)) Then Exit Sub
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim sSQL As String = ""
        sSQL = SQLDeleteD13T1101() & vbCrLf
        sSQL &= SQLDeleteD13T1100()
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)

        If bRunSQL Then
            DeleteOK()

            'Audit Log
            Dim sDesc1 As String = tdbg.Columns(COL_ResultReferenceID).Text
            Dim sDesc2 As String = tdbg.Columns(COL_ResultReferenceName).Text
            Dim sDesc3 As String = tdbg.Columns(COL_Notice).Text
            Dim sDesc4 As String = SQLNumber(CBool(tdbg.Columns(COL_Disabled).Text))
            Dim sDesc5 As String = ""
            RunAuditLog(AuditCodeResultRecTable, "03", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

#End Region

#Region "Grid"

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

#End Region

    Private Function SQLDeleteD13T1101() As String
        Dim sSQL As String = ""
        sSQL = "delete D13T1101 where ResultReferenceID= " & SQLString(tdbg.Columns(COL_ResultReferenceID).Text)
        Return sSQL
    End Function

    Private Function SQLDeleteD13T1100() As String
        Dim sSQL As String = ""
        sSQL = "delete D13T1100 where ResultReferenceID= " & SQLString(tdbg.Columns(COL_ResultReferenceID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 06/05/2011 01:10:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F1100") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_ResultReferenceID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") 'DateTo, datetime, NOT NULL
        Return sSQL
    End Function

End Class