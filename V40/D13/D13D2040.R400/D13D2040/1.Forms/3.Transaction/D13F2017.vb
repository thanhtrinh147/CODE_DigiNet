Imports System.Windows.Forms
Public Class D13F2017
    Private dtGrid As DataTable
    Private sFind As String = ""
    Private dtCaptionCols As DataTable

#Region "Const of tdbg - Total of Columns: 7"
    Private Const SCOL_EmployeeID As String = "EmployeeID"           ' Mã NV
    Private Const SCOL_EmployeeName As String = "EmployeeName"       ' Họ và tên
    Private Const SCOL_Mobilephone As String = "Mobilephone"         ' Số Mobile
    Private Const SCOL_Email As String = "Email"                     ' Email
    Private Const SCOL_IsTransferEmail As String = "IsTransferEmail" ' Gửi bảng lương qua email
    Private Const SCOL_PassSalaryFile As String = "PassSalaryFile"   ' Mật khẩu phiếu lương
    Private Const SCOL_IsUpdate As String = "IsUpdate"               ' Cập nhật
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2018
    '# Created User: Lê Anh Vũ
    '# Created Date: 07/10/2014 01:40:36
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2018() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi " & vbCrlf)
        sSQL &= "Exec D13P2018 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString("D13F2012") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[2], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0201
    '# Created User: Lê Anh Vũ
    '# Created Date: 07/10/2014 02:27:14
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0201() As StringBuilder
        Dim sSQL As New StringBuilder
        Dim sPassEn As String
        For i As Integer = 0 To dtGrid.Rows.Count - 1
            If dtGrid.Rows(i)(SCOL_IsUpdate).ToString() <> "1" Then Continue For
            sPassEn = D00D0041.D00C0001.EncryptString(dtGrid.Rows(i)(SCOL_PassSalaryFile).ToString(), True)
            sSQL.Append("-- Update mat khau nhan vien D13T0201" & vbCrLf)
            sSQL.Append("Update D13T0201 Set ")
            sSQL.Append("PassSalaryFile = " & SQLString(sPassEn) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("IsTransferEmail  = " & SQLNumber(dtGrid.Rows(i)(SCOL_IsTransferEmail))) 'varchar[50], NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("EmployeeID = " & SQLString(dtGrid.Rows(i)(SCOL_EmployeeID).ToString()))
            If i <> dtGrid.Rows.Count - 1 Then
                sSQL.Append(vbCrLf)
            End If
        Next
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD09T0201s
    '# Created User: Lê Anh Vũ
    '# Created Date: 21/09/2015 05:19:39
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD09T0201s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dtGrid.Rows.Count - 1
            If dtGrid.Rows(i)(SCOL_IsUpdate).ToString() <> "1" Then Continue For
            If i = 0 Then sSQL.Append("--  Luu dia chi Email" & vbCrLf)
            sSQL.Append("Update D09T0201 Set ")
            sSQL.Append("Email = " & SQLStringUnicode(dtGrid.Rows(i)(SCOL_Email), gbUnicode, False)) 'varchar[500], NULL
            sSQL.Append(" Where ")
            sSQL.Append("EmployeeID = " & SQLString(dtGrid.Rows(i)(SCOL_EmployeeID)))
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Thiet_lap_thong_tin_gui_bang_luong_qua_email") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'ThiÕt lËp th¤ng tin gõi b¶ng l§¥ng qua email
        '================================================================ 
        btnSave.Text = rL3("Luu") 'Lưu
        '================================================================ 
        tdbg.Columns(SCOL_EmployeeID).Caption = rL3("Ma_NV") 'Mã NV
        tdbg.Columns(SCOL_EmployeeName).Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(SCOL_Mobilephone).Caption = rL3("So_Mobile") 'Số Mobile
        tdbg.Columns(SCOL_IsTransferEmail).Caption = rL3("Gui_bang_luong_qua_email") 'Gửi bảng lương qua email
        tdbg.Columns(SCOL_PassSalaryFile).Caption = rL3("Mat_khau_phieu_luong") 'Mật khẩu phiếu lương
        tdbg.Columns(SCOL_IsUpdate).Caption = rL3("Cap_nhat") 'Cập nhật
        '================================================================ 
        mnsExportOut.Text = rL3("Xuat_Excel_U") 'Xuất excel
        '================================================================ 
        'chkCheckEmail.Text = rL3("Kiem_tra_email_hop_le") 'Kiểm tra email hợp lệ
    End Sub

    Private Sub ModifyTablePass()
        If dtGrid Is Nothing Then Exit Sub
        If dtGrid.Rows.Count <= 0 Then Exit Sub
        For Each _r As DataRow In dtGrid.Rows
            Dim _sPass As String
            _sPass = _r(SCOL_PassSalaryFile).ToString()
            _r(SCOL_PassSalaryFile) = D00D0041.D00C0001.EncryptString(_sPass, False)
        Next
        dtGrid.AcceptChanges()
    End Sub

    Private Sub ResetIsUpdateToZero()

        If dtGrid Is Nothing Then Exit Sub
        If dtGrid.Rows.Count <= 0 Then Exit Sub
        For Each _r As DataRow In dtGrid.Rows
            _r(SCOL_IsUpdate) = 0
        Next
        dtGrid.AcceptChanges()
    End Sub

    Private Sub LoadTDBGrid()
        dtGrid = ReturnDataTable(SQLStoreD13P2018())
        ModifyTablePass()
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid(Optional ByVal bLoadEdit As Boolean = True)
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, SCOL_EmployeeID)
    End Sub

    Private Sub D13F5611_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        tdbg.UpdateData()
        If btnSave.Enabled Then
            Dim _dr() As DataRow
            _dr = dtGrid.Select(SCOL_IsUpdate & "='1'")
            If _dr.Length > 0 Then
                If AskMsgBeforeRowChange() Then
                    SaveData(sender)
                End If
            End If
        End If
    End Sub

    Private Sub D13F5611_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        tdbg_LockedColumns()
        LoadLanguage()
        ResetColorGrid(tdbg)
        LoadTDBGrid()
        SetResolutionForm(Me)
        SetShortcutPopupMenu(ContextMenuStrip1)
        btnSave.Enabled = ReturnPermission("D13F5611") > EnumPermission.View
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        'Hỏi trước khi lưu
        If AskSave() = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        SaveData(sender)
    End Sub
    Private Function AllowSave() As Boolean
        Dim _dr() As DataRow
        _dr = dtGrid.Select(SCOL_IsUpdate & "='1'")
        If _dr.Length = 0 Then
            D99C0008.Msg(rL3("Du_lieu_khong_co_su_thay_doi_"))
            Return False
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If Not L3Bool(tdbg(i, SCOL_IsUpdate)) Then Continue For 'Chỉ kiểm tra những dòng sửa.
            Dim sEmail As String = L3String(tdbg(i, SCOL_Email))
            If sEmail.Trim <> "" AndAlso Not CheckEmailAddress(sEmail) Then
                D99C0008.MsgL3(rL3("Email_khong_hop_le"))
                tdbg.Focus()
                tdbg.SplitIndex = 0
                tdbg.Col = IndexOfColumn(tdbg, SCOL_Email)
                tdbg.Row = i
                Return False
            End If
        Next
        Return True
    End Function

    Const EmailExpressions As String = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"

    Private Function CheckEmailAddress(ByVal sEmail As String) As Boolean
        'Return True: là hợp lệ
        If sEmail = "" Then Return True
        Dim reg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(EmailExpressions)
        Return reg.IsMatch(sEmail)
    End Function

    Private Function SaveData(ByVal sender As System.Object) As Boolean
        If Not AllowSave() Then Return False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLUpdateD09T0201s())
        sSQL.Append(SQLUpdateD13T0201())
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            ResetIsUpdateToZero()
            Return True
        Else
            SaveNotOK()
            Return False
        End If
        Return True
    End Function

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(SCOL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(SCOL_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(SCOL_Mobilephone).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.Columns(SCOL_IsUpdate).Text = "1"
    End Sub

    Dim sFilter As New System.Text.StringBuilder()
    'Dim sFilterServer As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case tdbg.Columns(iCol).DataField
            Case SCOL_IsTransferEmail
                L3HeadClick(tdbg, iCol, bSelect)
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, SCOL_IsUpdate) = "1"
                Next
                ResetGrid()
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg, e)
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    Private Sub mnsExportOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsExportOut.Click
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , False, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        '*****************************************
        'Dùng cho Xuất Excel trực tiếp
        Me.Cursor = Cursors.WaitCursor
        ExportToExcelMax(dtGrid.DefaultView.ToTable, dtCaptionCols)
        Me.Cursor = Cursors.Default
        '*****************************************
    End Sub


#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    'DLL sử dụng Properties
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Giống sự kiện Finder_FindClick
        End Set
    End Property

    '*****************************
    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {}
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbg.Splits.Count - 1
                AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
            Next
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
        ' ShowFindDialogClient(Finder, dtCaptionCols, Me,"0", gbUnicode)' Dùng DLL 
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

End Class