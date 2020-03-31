Public Class D25F1057

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _candidateID As String = ""
    Public WriteOnly Property CandidateID  As String
        Set(ByVal Value As String)
            _candidateID = Value
        End Set
    End Property
    
#Region "Const of tdbg - Total of Columns: 6"
    Private Const COL_OrderNum As Integer = 0    ' Số thứ tự
    Private Const COL_DocTypeID As Integer = 1   ' DocTypeID
    Private Const COL_DocTypeName As Integer = 2 ' Tên loại giấy tờ
    Private Const COL_IsSubmit As Integer = 3    ' Đã nộp
    Private Const COL_DocNotes As Integer = 4    ' Ghi chú
    Private Const COL_UpdateDate As Integer = 5  ' Ngày cập nhật
#End Region

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral() ' hàm trong DxxD9940
            _FormState = value

            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private dtGrid As DataTable
    Private Sub D25F1057_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        tdbg_LockedColumns()
        LoadTDBGrid()
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        InputDateInTrueDBGrid(tdbg, COL_UpdateDate)
        '*****************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D25F1057_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
        End Select
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Giay_to_tuy_than") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'GiÊy té tîy th¡n
        '================================================================ 
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns(COL_OrderNum).Caption = rL3("STT") 'STT
        tdbg.Columns(COL_DocTypeName).Caption = rL3("Ten_loai_giay_to") 'Tên loại giấy tờ
        tdbg.Columns(COL_IsSubmit).Caption = rL3("Da_nop") 'Đã nộp
        tdbg.Columns(COL_DocNotes).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_UpdateDate).Caption = rL3("Ngay_cap_nhat") 'Ngày cập nhật
    End Sub
    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DocTypeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD25P1059()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        FooterTotalGrid(tdbg, COL_DocTypeName)
    End Sub
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.AppendLine(SQLDeleteD25T1055.ToString)
        sSQL.AppendLine(SQLInsertD25T1055s.ToString)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

#Region "tdbg"
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_IsSubmit
                If L3Bool(tdbg.Columns(e.ColIndex).Value) Then
                    tdbg.Columns(COL_UpdateDate).Value = Now.Date
                Else
                    tdbg.Columns(COL_UpdateDate).Value = ""
                End If
            Case COL_UpdateDate
                tdbg.Select()
        End Select
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_IsSubmit
                L3HeadClick(tdbg, iCol, bSelect)
                For i As Integer = 0 To tdbg.RowCount - 1
                    If bSelect Then
                        tdbg(i, COL_UpdateDate) = Now.Date
                    Else
                        tdbg(i, COL_UpdateDate) = ""
                    End If
                Next
                tdbg.UpdateData()
            Case COL_DocNotes, COL_UpdateDate
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Bookmark)
        End Select
    End Sub
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
    End Sub

    Private Sub tdbg_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg.UnboundColumnFetch
        Select Case e.Col
            Case COL_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1059
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 17/01/2017 08:59:51
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1059() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi giay to tuy than" & vbCrlf)
        sSQL &= "Exec D25P1059 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisonID, varchar[20], NOT NULL
        sSQL &= SQLString(_candidateID) & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T1055
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 17/01/2017 09:00:49
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T1055() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu cu" & vbCrlf)
        sSQL &= "Delete From D25T1055"
        sSQL &= " Where CandidateID =" & SQLString(_candidateID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1055s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 17/01/2017 09:01:32
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1055s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu du lieu vao bang D25T1055" & vbCrlf)
            sSQL.Append("Insert Into D25T1055(")
            sSQL.Append("DivisionID, CandidateID, DocTypeID, DocTypeNameU, IsSubmit, " & vbCrLf)
            sSQL.Append("DocNotesU, UpdateDate, LastModifyUserID, LastModifyDate")
            sSQL.Append(") Values(" & vbCrlf)
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_candidateID) & COMMA) 'CandidateID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DocTypeID)) & COMMA) 'DocTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_DocTypeName), gbUnicode, True) & COMMA) 'DocTypeNameU, nvarchar[1000], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_IsSubmit)) & COMMA & vbCrlf) 'IsSubmit, tinyint, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_DocNotes), gbUnicode, True) & COMMA) 'DocNotesU, nvarchar[1000], NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_UpdateDate)) & COMMA) 'UpdateDate, datetime, NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & vbCrlf) 'LastModifyDate, datetime, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


End Class