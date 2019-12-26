Imports System
Public Class D45F1031
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_OrderNo As Integer = 0   ' Thứ tự hiển thị
    Private Const COL_StageID As Integer = 1   ' Mã công đoạn
    Private Const COL_StageName As Integer = 2 ' Diễn giải
#End Region

    Private _sRoutingID As String = ""
    Public Property SRoutingID() As String
        Get
            Return _sRoutingID
        End Get
        Set(ByVal Value As String)
            _sRoutingID = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            LoadTDBCombo()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadAddNew()
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub LoadAddNew()
        btnNext.Enabled = False
        c1datePreparedDate.Value = Now.Date
        GetTextCreateBy(tdbcPreparerID)
    End Sub

    Private Sub LoadEdit()
        btnSave.Left = btnNext.Left
        btnNext.Visible = False
        txtSRoutingID.Enabled = False
        txtSRoutingID.Text = _sRoutingID

        Dim sSQL As String = ""
        sSQL &= " Select SRoutingID, SRoutingName" & UnicodeJoin(gbUnicode) & " as SRoutingName, PreparedDate, PreparerID, Note" & UnicodeJoin(gbUnicode) & " as Note, Disabled,"
        sSQL &= " CreateUserID, CreateDate, LastModifyUserID, LastModifyDate"
        sSQL &= " From D45T1030 D30 WITH(NOLOCK) "
        sSQL &= " Where	SRoutingID = " & SQLString(_sRoutingID)
        Dim dt As DataTable = ReturnDataTable(sSQL)

        If dt.Rows.Count > 0 Then
            txtSRoutingName.Text = dt.Rows(0).Item("SRoutingName").ToString
            chkDisabled.Checked = CBool(dt.Rows(0).Item("Disabled").ToString)
            c1datePreparedDate.Value = dt.Rows(0).Item("PreparedDate").ToString
            tdbcPreparerID.Text = dt.Rows(0).Item("PreparerID").ToString
            txtNote.Text = dt.Rows(0).Item("Note").ToString
        End If
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL &= " Select D31.StageID, D10.StageName" & UnicodeJoin(gbUnicode) & " as StageName, D31.OrderNo"
        sSQL &= " From 	D45T1031 D31 WITH(NOLOCK) "
        sSQL &= " Inner join D45T1010 D10  WITH(NOLOCK) On D10.StageID = D31.StageID"
        sSQL &= " Where	D31. SRoutingID = " & SQLString(_sRoutingID)
        sSQL &= " Order by	OrderNo"
        LoadDataSource(tdbg, sSQL, gbUnicode)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D45F1031_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        End If
    End Sub

    Private Sub D45F1031_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        Loadlanguage()
        SetBackColorObligatory()
        LoadTDBDropDown()
        tdbg_NumberFormat()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtSRoutingID)
        tdbg_LockedColumns()
        LoadTDBGrid()
        InputDateCustomFormat(c1datePreparedDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SetBackColorObligatory()
        txtSRoutingID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtSRoutingName.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1datePreparedDate.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_quy_trinh_san_xuat_chuan_-_D45F1031") & UnicodeCaption(gbUnicode) 'CËp nhËt quy trØnh s¶n xuÊt chuÈn - D45F1031
        '================================================================ 
        lblSRoutingID.Text = rl3("Ma") 'Mã
        lblSRoutingName.Text = rl3("Dien_giai") 'Diễn giải
        lbltePreparedDate.Text = rl3("Ngay_lap") 'Ngày lập
        lblPreparerID.Text = rl3("Nguoi_lap") 'Người lập
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        lblStage.Text = rl3("Cong_doan") 'Công đoạn
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        tdbcPreparerID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcPreparerID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbdStageID.Columns("StageName").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg.Columns("OrderNo").Caption = rl3("Thu_tu_hien_thi") 'Thứ tự hiển thị
        tdbg.Columns("StageID").Caption = rl3("Ma_cong_doan") 'Mã công đoạn
        tdbg.Columns("StageName").Caption = rl3("Dien_giai") 'Diễn giải
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcPreparerID
        LoadCboCreateBy(tdbcPreparerID, gbUnicode)
    End Sub

#Region "Events tdbcPreparerID with txtPreparerName"

    Private Sub tdbcPreparerID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPreparerID.Close
        If tdbcPreparerID.FindStringExact(tdbcPreparerID.Text) = -1 Then
            tdbcPreparerID.Text = ""
            txtPreparerName.Text = ""
        End If
    End Sub

    Private Sub tdbcPreparerID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPreparerID.SelectedValueChanged
        txtPreparerName.Text = tdbcPreparerID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcPreparerID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPreparerID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcPreparerID.Text = ""
            txtPreparerName.Text = ""
        End If
    End Sub

#End Region

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdStageID
        sSQL = "Select StageID, StageName" & UnicodeJoin(gbUnicode) & " as StageName From D45T1010  WITH(NOLOCK) Where Disabled = 0 Order by StageName"
        LoadDataSource(tdbdStageID, sSQL, gbUnicode)
    End Sub

    Private Function AllowSave() As Boolean
        If txtSRoutingID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtSRoutingID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D45T1030", "SRoutingID", txtSRoutingID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtSRoutingID.Focus()
                Return False
            End If
        End If
        If txtSRoutingName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtSRoutingName.Focus()
            Return False
        End If
        If c1datePreparedDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_lap"))
            c1datePreparedDate.Focus()
            Return False
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        ''Kiểm tra trùng trên dòng của Thứ tự hiển thị và Công đoạn
        'For i As Integer = 0 To tdbg.RowCount - 2
        '    For j As Integer = i + 1 To tdbg.RowCount - 1
        '        If tdbg(i, COL_OrderNo).ToString = tdbg(j, COL_OrderNo).ToString Then
        '            'D99C0008.MsgNotYetEnter("Thứ tự hiển thị")
        '            D99C0008.MsgL3("Số thự tự này đã tồn tại. Vui lòng nhập lại số khác.")
        '            tdbg.SplitIndex = SPLIT0
        '            tdbg.Col = COL_OrderNo
        '            tdbg.Bookmark = i
        '            tdbg.Focus()
        '            Return False
        '        End If
        '        If tdbg(i, COL_OrderNo).ToString = tdbg(j, COL_OrderNo).ToString Then
        '            'D99C0008.MsgNotYetEnter("Thứ tự hiển thị")
        '            D99C0008.MsgL3("Công đoạn này đã tồn tại. Vui lòng chọn lại mã khác."
        '            tdbg.SplitIndex = SPLIT0
        '            tdbg.Col = COL_StageID
        '            tdbg.Bookmark = i
        '            tdbg.Focus()
        '            Return False
        '        End If
        '    Next
        'Next
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1030
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 19/03/2008 09:26:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu Addnew master
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1030() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D45T1030(")
        sSQL.Append("SRoutingID, SRoutingName, SRoutingNameU, PreparedDate, PreparerID, Note, NoteU, ")
        sSQL.Append("Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtSRoutingID.Text) & COMMA) 'SRoutingID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtSRoutingName.Text, gbUnicode, False) & COMMA) 'SRoutingName, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtSRoutingName.Text, gbUnicode, True) & COMMA) 'SRoutingName, varchar[150], NOT NULL
        sSQL.Append(SQLDateSave(c1datePreparedDate.Text) & COMMA) 'PreparedDate, datetime, NULL
        sSQL.Append(SQLString(tdbcPreparerID.Text) & COMMA) 'PreparerID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'Note, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'Note, varchar[150], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1031s
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 19/03/2008 09:28:31
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu AddNew và Edit cho detail
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1031s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D45T1031(")
            sSQL.Append("SRoutingID, StageID, OrderNo")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtSRoutingID.Text) & COMMA) 'SRoutingID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_StageID)) & COMMA) 'StageID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_OrderNo))) 'OrderNo, int, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T1030
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 19/03/2008 09:29:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu edit cho master
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T1030() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T1030 Set ")
        'sSQL.Append("SRoutingID = " & SQLString(?????) & COMMA) '[KEY], varchar[20], NOT NULL
        sSQL.Append("SRoutingName = " & SQLStringUnicode(txtSRoutingName.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("SRoutingNameU = " & SQLStringUnicode(txtSRoutingName.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("PreparedDate = " & SQLDateSave(c1datePreparedDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("PreparerID = " & SQLString(tdbcPreparerID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("SRoutingID = " & SQLString(txtSRoutingID.Text))

        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T1031
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 19/03/2008 09:31:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu edit cho Detail
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T1031() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T1031"
        sSQL &= " Where "
        sSQL &= "SRoutingID = " & SQLString(txtSRoutingID.Text) 
        Return sSQL
    End Function



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD45T1030().ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1031s)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1030().ToString & vbCrLf)
                sSQL.Append(SQLDeleteD45T1031() & vbCrLf)
                sSQL.Append(SQLInsertD45T1031s)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            SaveOK()
            btnClose.Enabled = True
            _sRoutingID = txtSRoutingID.Text

            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'RunAuditLog(AuditCodeStandardRoutings, "02", txtSRoutingID.Text, txtSRoutingName.Text, c1datePreparedDate.Text, txtPreparerName.Text)
                    Lemon3.D91.RunAuditLog("45", AuditCodeStandardRoutings, "02", txtSRoutingID.Text, txtSRoutingName.Text, c1datePreparedDate.Text, txtPreparerName.Text)
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StageName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_OrderNo).NumberFormat = DxxFormat.DefaultNumber0
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_OrderNo
            Case COL_StageID
                If tdbg.Columns(COL_StageID).Text.ToUpper <> tdbdStageID.Columns("StageID").Text.ToUpper Then
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
                Else
                    If tdbg.Columns(COL_OrderNo).Text = "" Then
                        If tdbg.Bookmark > 0 Then
                            tdbg.Columns(COL_OrderNo).Text = (Number(tdbg(tdbg.Bookmark - 1, COL_OrderNo).ToString) + 1).ToString
                        ElseIf tdbg.Bookmark = 0 Then
                            tdbg.Columns(COL_OrderNo).Text = "1"
                        End If
                    End If

                    tdbg.Columns(COL_StageID).Text = tdbdStageID.Columns("StageID").Text
                    tdbg.Columns(COL_StageName).Text = tdbdStageID.Columns("StageName").Text
                End If
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_OrderNo
                'Số thự tự này đã tồn tại. Vui lòng nhập lại số khác.
                For i As Integer = 0 To tdbg.RowCount - 1
                    If i <> tdbg.Row Then
                        If tdbg(i, e.ColIndex).ToString = tdbg.Columns(e.ColIndex).Text Then
                            D99C0008.MsgL3(rl3("So_thu_tu_nay_da_ton_tai_Vui_long_nhap_lai_so_khac"))
                            e.Cancel = True
                        End If
                    End If
                Next
            Case COL_StageID
                'Công đoạn này đã tồn tại. Vui lòng chọn lại mã khác.
                For i As Integer = 0 To tdbg.RowCount - 1
                    If i <> tdbg.Row Then
                        If tdbg(i, e.ColIndex).ToString = tdbg.Columns(e.ColIndex).Text Then
                            D99C0008.MsgDuplicatePKey()
                            e.Cancel = True
                        End If
                    End If
                Next
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter And tdbg.Col = COL_StageName Then
            HotKeyEnterGrid(tdbg, COL_OrderNo, e)
            Exit Sub
            'ElseIf e.KeyCode = Keys.F7 Then
            '    HotKeyF7(tdbg)
            '    Exit Sub
            'ElseIf e.KeyCode = Keys.F8 Then
            '    HotKeyF8(tdbg)
            '    Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_OrderNo)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_OrderNo
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub


    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        btnSave.Enabled = True
        btnNext.Enabled = False

        If D45Options.SaveLastRecent = False Then
            txtSRoutingID.Text = ""
            txtSRoutingName.Text = ""
            chkDisabled.Checked = False
            c1datePreparedDate.Value = Now.Date
            GetTextCreateBy(tdbcPreparerID)
            txtPreparerName.Text = ""
            txtNote.Text = ""
            tdbg.Delete(0, tdbg.RowCount)
        End If
        txtSRoutingID.Focus()
    End Sub
End Class