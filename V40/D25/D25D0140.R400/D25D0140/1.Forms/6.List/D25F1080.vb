Imports System.Drawing
Imports System
Public Class D25F1080
 
#Region "Const of tdbg"
    Private Const COL_TransTypeID As Integer = 0      ' Mã
    Private Const COL_TransTypeName As Integer = 1    ' Tên
    Private Const COL_Disabled As Integer = 2         ' Không sử dụng
    Private Const COL_CreateUserID As Integer = 3     ' CreateUserID
    Private Const COL_CreateDate As Integer = 4       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 5 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 6   ' LastModifyDate
#End Region

    ' Update 23/05/2011 - Chuẩn unicode theo DC25 _ TIENDAU
    Dim dtGrid, dtCaptionCols As DataTable
    Dim sKey As String = ""

    Private _transTypeID As String = ""
    Public Property transTypeID() As String
        Get
            Return _transTypeID
        End Get
        Set(ByVal Value As String)
            _transTypeID = Value
        End Set
    End Property

    Private Sub D25F1080_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        Loadlanguage()
        ResetColorGrid(tdbg)
        LoadTDBGrid()
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_loai_nghiep_vu_HS_ung_cu_vien_-_D25F1080") & UnicodeCaption(gbUnicode) 'Danh móc loÁi nghiÖp vó HS ÷ng cõ vi£n - D25F1080
        '================================================================ 
        tdbg.Columns("TransTypeID").Caption = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        tdbg.Columns("TransTypeName").Caption = rl3("Ten") 'Tên
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'Không sử dụng
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'hiển thị danh mục chưa sử dụng

    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bFlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = ""
        sSQL &= " SELECT TransTypeID,CreateUserID,CreateDate,LastModifyUserID,LastModifyDate"
        sSQL &= " ,Disabled,TransTypeName" & UnicodeJoin(gbUnicode) & " as TransTypeName"
        sSQL &= " FROM D25T1080  WITH(NOLOCK)  Order By TransTypeID"
        dtGrid = ReturnDataTable(sSQL)

        gbEnabledUseFind = dtGrid.Rows.Count > 0

        If bFlagAdd Then
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then 'Khi Thêm mới hoặc Sửa đều thực thi
            Dim dt As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt.Select(tdbg.Columns(COL_TransTypeID).DataField & "=" & SQLString(sKey), dt.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt.Rows.IndexOf(dr(0))
            If Not tdbg.Focused Then tdbg.Focus()
        End If

    End Sub

#Region "Active FilterChange "
    Dim sFilter As New System.Text.StringBuilder()
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
              WriteLogFile(ex.Message)
        End Try
    End Sub
    '	Vào sự kiện tdbg_KeyPress viết code như sau:
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        'Select Case tdbg.Col
        '    Case COL_ListID
        '        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        'End Select
    End Sub
    '	Vào sự kiện tdbg_DoubleClick viết code bổ sung đoạn tô đậm như sau:
    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
    End Sub
    '	Vào sự kiện tdbg_KeyDown viết code bổ sung đoạn tô đậm như sau:
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            tdbg_DoubleClick(sender, Nothing)
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub
#End Region

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

    Private bRefreshFilter As Boolean = False

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click
        'If CallMenuFromGrid(sender, tdbg) = False Then Exit Sub
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        gbEnabledUseFind = True
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        'Dim arrColObligatory() As String = {COL_DebitAccountID, COL_CreditAccountID, COL_CurrencyID}
        Dim Arr As New ArrayList
        AddColVisible_String(tdbg, Arr, SPLIT0, , , False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        '  End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If Not chkShowDisabled.Checked Then
            If strFind.Equals("") = False Then strFind &= " And "
            strFind &= "Disabled = 0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_TransTypeID)
        CheckMenu(Me.Name, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
    End Sub

#End Region

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Try
            Dim f As New D25F1081
            f.TransTypeID = ""
            f.FormState = EnumFormState.FormAdd
            f.ShowDialog()
            sKey = f.TransTypeID
            If f.bSaved Then
                LoadTDBGrid(True, sKey)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub tsbView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D25F1081
        f.TransTypeID = tdbg.Columns(COL_TransTypeID).Text
        f.transTypeName = tdbg.Columns(COL_TransTypeName).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D25F1081
        f.TransTypeID = tdbg.Columns(COL_TransTypeID).Text
        f.transTypeName = tdbg.Columns(COL_TransTypeName).Text
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        f.Dispose()
        If f.bSaved Then
            LoadTDBGrid(False, tdbg.Columns(COL_TransTypeID).Text)
        End If
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        Dim sSQL As String
        Dim bResult As Boolean

        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            transTypeID = tdbg.Columns(COL_TransTypeID).Text
            If Not AllowDelete() Then Exit Sub
            sSQL = "Delete D25T1080 Where TransTypeID = " & SQLString(_transTypeID) & vbCrLf
            sSQL &= "Delete D25T1081 Where transTypeID = " & SQLString(_transTypeID)
            bResult = ExecuteSQL(sSQL)
            If bResult Then
                DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
                ResetGrid()
                DeleteOK()
            Else
                DeleteNotOK()
            End If
        End If

    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub


    Private Function AllowDelete() As Boolean
        'Dim sSQL As String = ""
        'sSQL &= "Select 1 From D09T0000 Where TransTypeID = " & _transTypeID
        If D25Options.TransTypeID = _transTypeID Then
            D99C0008.MsgL3(rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_xoa"), L3MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

End Class