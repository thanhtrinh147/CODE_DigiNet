Public Class D13F1190
    Private dtGrid As DataTable
    'Dim bAskSave As Boolean = True 'Kiểm tra xem có thông báo hỏi khi nhấn nút Lưu không
    Dim bSavedOK As Boolean = False

#Region "Const of tdbg - Total of Columns: 26"
    Private Const COL_CreateDate As Integer = 0         ' CreateDate
    Private Const COL_CreateUserID As Integer = 1       ' CreateUserID
    Private Const COL_LastModifyDate As Integer = 2     ' LastModifyDate
    Private Const COL_LastModifyUserID As Integer = 3   ' LastModifyUserID
    Private Const COL_CollaboratorID As Integer = 4     ' Mã cộng tác viên
    Private Const COL_CollaboratorName As Integer = 5   ' Họ và tên
    Private Const COL_ColDateJoined As Integer = 6      ' Ngày tham gia
    Private Const COL_ColContactAddressU As Integer = 7 ' Địa chỉ
    Private Const COL_ColContactPhone As Integer = 8    ' Điện thoại
    Private Const COL_Email As Integer = 9              ' Email
    Private Const COL_ColWork As Integer = 10           ' Công việc
    Private Const COL_TaxObjectNameU As Integer = 11    ' Đối tượng tính thuế
    Private Const COL_PaymentMethodName As Integer = 12 ' Phương pháp thanh toán
    Private Const COL_BankName As Integer = 13          ' Ngân hàng
    Private Const COL_BankAccountNo As Integer = 14     ' Số tài khoản
    Private Const COL_Notes As Integer = 15             ' Ghi chú
    Private Const COL_Disabled As Integer = 16          ' KSD
    Private Const COL_PaymentMethod As Integer = 17     ' PaymentMethod
    Private Const COL_BankID As Integer = 18            ' BankID
    Private Const COL_TaxObjectID As Integer = 19       ' TaxObjectID
    Private Const COL_NumIDCard As Integer = 20         ' NumIDCard
    Private Const COL_IssuedPlaceID As Integer = 21     ' IssuedPlaceID
    Private Const COL_NumIDCardDate As Integer = 22     ' NumIDCardDate
    Private Const COL_IncomeTaxCode As Integer = 23     ' IncomeTaxCode
    Private Const COL_PITIssuePlaceID As Integer = 24   ' PITIssuePlaceID
    Private Const COL_PITIssueDate As Integer = 25      ' PITIssueDate
#End Region

    Private _FormState As EnumFormState = EnumFormState.FormView
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
            End Select
        End Set
    End Property
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_cong_tac_vien") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Danh móc cèng tÀc vi£n
        '================================================================ 
        lblCityID.Text = rl3("Ma_cong_tac_vien") 'Mã cộng tác viên
        lblCityName.Text = rl3("Ho_va_ten") 'Họ và tên
        lblDateJoined.Text = rl3("Ngay_tham_gia") 'Ngày tham gia
        lblColContactAddressU.Text = rl3("Dia_chi") 'Địa chỉ
        lblColContactPhone.Text = rl3("Dien_thoai") 'Điện thoại
        lblEmail.Text = rl3("Email") 'Email
        lblColWorkU.Text = rl3("Cong_viec") 'Công việc
        lblTaxObjectName.Text = rl3("Doi_tuong_tinh_thue") 'Đối tượng tính thuế
        lblPaymentMethodName.Text = rl3("Phuong_phap_thanh_toan") 'Phương pháp thanh toán
        lblBankName.Text = rl3("Ngan_hang") 'Ngân hàng
        lblBankAccountNo.Text = rl3("So_tai_khoan") 'Số tài khoản
        lblNotesU.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu và Nhập &tiếp
        btnNotSave.Text = rl3("_Khong_luu") '&Không Lưu
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        grpDetail.Text = rl3("Chi_tiet") 'Chi tiết
        '================================================================ 
        tdbcBankName.Columns("BankID").Caption = rl3("Ma") 'Mã
        tdbcBankName.Columns("BankName").Caption = rl3("Ngan_hang") 'Ngân hàng
        tdbcPaymentMethodName.Columns("PaymentMethod").Caption = rl3("Ma") 'Mã
        tdbcPaymentMethodName.Columns("PaymentMethodName").Caption = rl3("Ten") 'Tên
        tdbcTaxObjectName.Columns("TaxObjectID").Caption = rl3("Ma") 'Mã
        tdbcTaxObjectName.Columns("TaxObjectName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_CollaboratorID).Caption = rl3("Ma") 'Mã
        tdbg.Columns(COL_CollaboratorName).Caption = rl3("Ten") 'Tên
        tdbg.Columns(COL_ColWork).Caption = rl3("Cong_viec") 'Công việc
        tdbg.Columns(COL_ColDateJoined).Caption = rl3("Ngay_tham_gia") 'Ngày tham gia
        tdbg.Columns(COL_ColContactPhone).Caption = rl3("Dien_thoai") 'Điện thoại
        tdbg.Columns(COL_ColContactAddressU).Caption = rl3("Dia_chi") 'Địa chỉ
        tdbg.Columns(COL_TaxObjectNameU).Caption = rl3("Doi_tuong_tinh_thue") 'Đối tượng tính thuế
        tdbg.Columns(COL_PaymentMethodName).Caption = rl3("Phuong_phap_thanh_toan") 'Phương pháp thanh toán
        tdbg.Columns(COL_BankName).Caption = rl3("Ngan_hang") 'Ngân hàng
        tdbg.Columns(COL_BankAccountNo).Caption = rl3("So_tai_khoan") 'Số tài khoản
        tdbg.Columns(COL_Notes).Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_Disabled).Caption = rL3("KSD") 'KSD

        '================================================================ 
        lblNumIDCard.Text = rL3("So_CMND") 'Số CMND
        lblNumIDCardDate.Text = rL3("Ngay_cap_CMND") 'Ngày cấp CMND
        lblIssuedPlaceID.Text = rL3("Noi_cap_CMND") 'Nơi cấp CMND
        lblIncomeTaxCode.Text = rL3("Ma_so_thue") 'Mã số thuế
        lblPITIssueDate.Text = rL3("Ngay_cap_MST") 'Ngày cấp MST
        lblPITIssuePlaceID.Text = rL3("Noi_cap_MST") 'Nơi cấp MST
        '================================================================ 
        tdbcIssuedPlaceID.Columns("IssuedPlaceID").Caption = rL3("Ma") 'Mã
        tdbcIssuedPlaceID.Columns("IssuedPlaceName").Caption = rL3("Ten") 'Tên
        tdbcPITIssuePlaceID.Columns("PITIssuePlaceID").Caption = rL3("Ma") 'Mã
        tdbcPITIssuePlaceID.Columns("PITIssuePlaceName").Caption = rL3("Ten") 'Tên

    End Sub

    Dim _fromPermission As String = "D13F1190"

    Private Sub D56F1030_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FormState = EnumFormState.FormEdit Then
            If Not bSavedOK Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If txtCollboratorID.Text <> "" Then
                If Not bSavedOK Then
                    If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub EnableMenu(ByVal bEnabled As Boolean)
        If dtGrid Is Nothing Then Exit Sub
        btnSave.Enabled = bEnabled
        btnNotSave.Enabled = bEnabled
        btnNext.Enabled = bEnabled
        chkShowDisabled.Enabled = Not bEnabled
        tdbg.Enabled = Not bEnabled
        If _FormState = EnumFormState.FormAdd Then
            btnNext.Visible = True
            btnNext.Text = rl3("Luu_va_Nhap__tiep")
        Else
            btnNext.Visible = False
        End If
        If btnNext.Visible And btnNext.Enabled Then
            btnSave.Left = btnNext.Left - btnSave.Width - 6
        Else
            btnSave.Left = btnNext.Left + (btnNext.Width - btnSave.Width)
        End If
        If bEnabled Then
            CheckMenu("-1", ToolStrip1, -1, False, False, ContextMenuStrip1)
        Else
            CheckMenu(_fromPermission, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , "D13F1190")
        End If
    End Sub

    ' Trường hợp tìm kiếm không có dữ liệu thì Khóa Detail lại
    Private Sub LockControlDetail(ByVal bLock As Boolean)
        grpDetail.Enabled = Not bLock
    End Sub

    Private Sub D13F1190_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        SetBackColorObligatory()
        InputbyUnicode(Me, gbUnicode)
        LoadTDBCombo()
        LoadLanguage()
        ResetColorGrid(tdbg)
        LoadTDBGrid()
        SetShortcutPopupMenuNew(Me, ToolStrip1, ContextMenuStrip1)
        CheckIdTextBox(txtCollboratorID)
        InputDateInTrueDBGrid(tdbg, COL_ColDateJoined)
        InputDateCustomFormat(c1dateDateJoined)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D56F1030_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormAdd Then
            txtCollboratorID.Focus()
        Else
            txtCollboratorName.Focus()
        End If
    End Sub

    Private Sub D56F1030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        dtGrid = ReturnDataTable(SQLStoreD13P1170())
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("CollaboratorID=" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
        If dtGrid.Rows.Count = 0 And tsbAdd.Enabled Then
            tsbAdd_Click(Nothing, Nothing)
        End If
    End Sub

    Dim dtObjectID As DataTable
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        sSQL = "SELECT		ObjectID as BankID, ObjectNameU AS BankName " & _
                " FROM	 	Object  WITH (NOLOCK)  " & _
                " WHERE	 	Disabled = 0 AND ObjectTypeID = 'NH' " & _
                " ORDER BY	ObjectID"
        LoadDataSource(tdbcBankName, sSQL, gbUnicode)

        sSQL = "SELECT		TaxObjectID, TaxObjectNameU AS TaxObjectName " & _
                      " FROM	 	D13T0128  WITH (NOLOCK) " & _
                      " WHERE	 	Disabled = 0" & _
                      " ORDER BY	TaxObjectID"
        LoadDataSource(tdbcTaxObjectName, sSQL, gbUnicode)

        sSQL = "SELECT 	ID As PaymentMethod, Name" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString() & "U As PaymentMethodName " & _
                             " FROM		D21N5555 ('0004', '', '', '', '') " & _
                             " ORDER BY	PaymentMethodName"
        LoadDataSource(tdbcPaymentMethodName, sSQL, gbUnicode)

        sSQL = "      -- Do nguon noi cap CMND " & vbCrLf & _
                " SELECT      ZoneCode As IssuedPlaceID, ZoneNameU As IssuedPlaceName " & vbCrLf & _
                " FROM        D91T1620  WITH(NOLOCK) " & vbCrLf & _
                " WHERE       ZoneLevelID = 'TINH/THANH' And Disabled = 0 " & vbCrLf & _
                " ORDER BY    IssuedPlaceName"
        LoadDataSource(tdbcIssuedPlaceID, sSQL, gbUnicode)

        LoadTDBCPITIssuePlaceID()
    End Sub

    Private Sub LoadTDBCPITIssuePlaceID()
        Dim sSQL As String = ""
        sSQL = "	-- Do nguon noi cap MST " & vbCrLf & _
               " SELECT      '+' as PITIssuePlaceID," & NewName & " as PITIssuePlaceName, 0 As DisplayOrder " & vbCrLf & _
               " UNION ALL " & vbCrLf & _
               " SELECT  LookupID As PITIssuePlaceID, DescriptionU as PITIssuePlaceName, 1 As DisplayOrder " & vbCrLf & _
               " FROM        D91T0320  WITH(NOLOCK) " & vbCrLf & _
               " WHERE       LookupType = 'D09_TaxcodePlace' And Disabled = 0 " & vbCrLf & _
               " ORDER BY    DisplayOrder,   PITIssuePlaceID"
        LoadDataSource(tdbcPITIssuePlaceID, sSQL, gbUnicode)
    End Sub

    Private Sub ReLoadTDBGrid(Optional ByVal bLoadEdit As Boolean = True)
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled =0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
        If _FormState = EnumFormState.FormAdd Then Exit Sub

        If tdbg.RowCount = 0 Then
            ClearText(grpDetail)
            LockControlDetail(True)
        Else
            LockControlDetail(False)
            _FormState = EnumFormState.FormView
            If bLoadEdit Then
                LoadEdit()
                'tdbg.Focus()
            End If
        End If
    End Sub


    Private Sub ResetGrid()
        EnableMenu(False)
        FooterTotalGrid(tdbg, COL_CollaboratorID)
    End Sub

    Private Sub chkShowDisabled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.Click
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#Region "Menu"
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, mnsAdd.Click
        _FormState = EnumFormState.FormAdd
        EnableMenu(True)
        LoadAdd()

    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, mnsEdit.Click
        _FormState = EnumFormState.FormEdit
        EnableMenu(True)
        ReadOnlyControl(txtCollboratorID)
        bSavedOK = False
        txtCollboratorName.Focus()
        chkDisabled.Visible = True
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSQL As New StringBuilder
        If Not CheckStore(SQLStoreD13P5555()) Then Exit Sub
        sSQL.Append(SQLDeleteD13T1170())
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
            'RunAuditLog("City", "03", tdbg.Columns(COL_CityID).Text)
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            If dtGrid.Rows.Count = 0 Then
                ResetGrid()
                tsbAdd_Click(Nothing, Nothing)
            Else
                ReLoadTDBGrid()
                'LoadEdit()
            End If
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg(tdbg.Row, COL_CreateUserID).ToString, tdbg(tdbg.Row, COL_CreateDate).ToString, tdbg(tdbg.Row, COL_LastModifyUserID).ToString, tdbg(tdbg.Row, COL_LastModifyDate).ToString)
    End Sub

#End Region

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""
    Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        '72334
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, _fromPermission, "0", gbUnicode)

    End Sub

    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
        sFind = ResultWhereClause.ToString()
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Dim iHeight As Integer = 0 ' Lấy tọa độ Y của chuột click tới
    Private Sub tdbg_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseClick
        iHeight = e.Location.Y
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If iHeight <= tdbg.Splits(0).ColumnCaptionHeight Then Exit Sub
        If tdbg.RowCount <= 0 OrElse tdbg.FilterActive Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

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

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Disabled 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Private Sub tdbg_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdbg.AfterSort
        ' If tdbg.FilterActive Then Exit Sub
        LoadEdit()
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        'Neu luoi co 1 dong thi k can chay su kien nay
        If tdbg.RowCount <= 1 Then Exit Sub
        If tdbg.Columns(COL_CollaboratorID).Tag Is Nothing OrElse tdbg.Columns(COL_CollaboratorID).Text <> tdbg.Columns(COL_CollaboratorID).Tag.ToString Then
            LoadEdit()
        End If
    End Sub

    Private Function SaveData(ByVal sender As System.Object) As Boolean
        bSavedOK = False
        If Not AllowSave() Then Return False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD13T1170())
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T1170())
        End Select
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            bSavedOK = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBGrid(True, txtCollboratorID.Text)
                Case EnumFormState.FormEdit
                    LoadTDBGrid(, txtCollboratorID.Text)
            End Select
            ReadOnlyControl(txtCollboratorID)
            SetReturnFormView()
        Else
            SaveNotOK()
            Return False
        End If
        Return True
    End Function

    Private Sub LoadAdd()
        _FormState = EnumFormState.FormAdd
        tdbg.Columns(COL_CollaboratorID).Tag = ""
        '********************
        bSavedOK = False
        '*******************
        ClearText(grpDetail)
        chkDisabled.Checked = False
        chkDisabled.Visible = False
        LockControlDetail(False)
        '*******************
        UnReadOnlyControl(True, txtCollboratorID)
        txtCollboratorID.Focus()
    End Sub

    Private Sub LoadEdit()
        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        If dtGrid.Rows.Count = 0 Then Exit Sub 'Chưa đổ nguồn cho lưới
        tdbg.Columns(COL_CollaboratorID).Tag = tdbg.Columns(COL_CollaboratorID).Text
        'Gán dữ liệu
        txtCollboratorID.Text = tdbg.Columns(COL_CollaboratorID).Text
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        txtCollboratorName.Text = tdbg.Columns(COL_CollaboratorName).Text
        c1dateDateJoined.Value = tdbg.Columns(COL_ColDateJoined).Value

        txtNumIDCard.Text = tdbg.Columns(COL_NumIDCard).Text
        c1dateNumIDCardDate.Value = tdbg.Columns(COL_NumIDCardDate).Value
        tdbcIssuedPlaceID.SelectedValue = tdbg.Columns(COL_IssuedPlaceID).Text
        txtIncomeTaxCode.Text = tdbg.Columns(COL_IncomeTaxCode).Text
        c1datePITIssueDate.Value = tdbg.Columns(COL_PITIssueDate).Value
        tdbcPITIssuePlaceID.SelectedValue = tdbg.Columns(COL_PITIssuePlaceID).Text

        txtColContactAddressU.Text = tdbg.Columns(COL_ColContactAddressU).Text
        txtColContactPhone.Text = tdbg.Columns(COL_ColContactPhone).Text
        txtEmail.Text = tdbg.Columns(COL_Email).Text
        txtColWorkU.Text = tdbg.Columns(COL_ColWork).Text
        tdbcTaxObjectName.SelectedValue = tdbg.Columns(COL_TaxObjectID).Text
        tdbcBankName.SelectedValue = tdbg.Columns(COL_BankID).Text
        tdbcPaymentMethodName.SelectedValue = tdbg.Columns(COL_PaymentMethod).Text
        txtBankAccountNo.Text = tdbg.Columns(COL_BankAccountNo).Text
        txtNotesU.Text = tdbg.Columns(COL_Notes).Text
        '************************
        ReadOnlyControl(txtCollboratorID)
    End Sub

    Private Sub SetBackColorObligatory()
        txtCollboratorID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtCollboratorName.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateJoined.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtNumIDCard.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtIncomeTaxCode.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function AllowSave() As Boolean
        '*********************
        If txtCollboratorID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ma"))
            txtCollboratorID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D13T1170", "CollaboratorID", txtCollboratorID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtCollboratorID.Focus()
                Return False
            End If
            If IsExistKey("D13T0201", "EmployeeID", txtCollboratorID.Text) Then
                'D99C0008.MsgDuplicatePKey()
                D99C0008.MsgL3(rL3("Ma_cong_tac_vien_khong_duoc_trung_voi_ma_nhan_vien"))
                txtCollboratorID.Focus()
                Return False
            End If
        End If
        If txtCollboratorName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ten"))
            txtCollboratorName.Focus()
            Return False
        End If
        If c1dateDateJoined.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ngay_tham_gia"))
            c1dateDateJoined.Focus()
            Return False
        End If
        If txtNumIDCard.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblNumIDCard.Text)
            txtNumIDCard.Focus()
            Return False
        End If
        If txtIncomeTaxCode.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblIncomeTaxCode.Text)
            txtIncomeTaxCode.Focus()
            Return False
        End If
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD56P1020
    '# Created User: Lê Anh Vũ
    '# Created Date: 16/12/2013 09:01:28
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD56P1020() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Combo Quoc gia" & vbCrLf)
        sSQL &= "Exec D56P1020 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1170
    '# Created User: Lê Anh Vũ
    '# Created Date: 03/11/2014 06:21:55
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1170() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi cong tac vien" & vbCrLf)
        sSQL &= "Exec D13P1170 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(_fromPermission) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1170
    '# Created User: Lê Anh Vũ
    '# Created Date: 03/11/2014 06:52:15
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1170() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu cong tac vien" & vbCrLf)
        sSQL.Append("Insert Into D13T1170(")
        sSQL.Append("CollaboratorID, CollaboratorNameU, ColContactPhone, Email, ColWorkU, ")
        sSQL.Append("ColDateJoined, TaxObjectID, BankID, PaymentMethod, BankAccountNo, ")
        sSQL.Append("NotesU, Disabled, CreateUserID, ColContactAddressU, CreateDate, ")
        sSQL.Append("LastModifyUserID, LastModifyDate,")
        sSQL.Append("NumIDCard,IssuedPlaceID,NumIDCardDate,IncomeTaxCode, PITIssuePlaceID, PITIssueDate")

        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(txtCollboratorID.Text) & COMMA) 'CollaboratorID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtCollboratorName.Text, gbUnicode, True) & COMMA) 'CollaboratorNameU, nvarchar[500], NOT NULL
        sSQL.Append(SQLString(txtColContactPhone.Text) & COMMA) 'ColContactPhone, varchar[50], NOT NULL
        sSQL.Append(SQLString(txtEmail.Text) & COMMA) 'Email, varchar[500], NOT NULL
        sSQL.Append(SQLStringUnicode(txtColWorkU.Text, gbUnicode, True) & COMMA) 'ColWorkU, nvarchar[500], NOT NULL
        sSQL.Append(SQLDateSave(c1dateDateJoined.Text) & COMMA) 'ColDateJoined, datetime, NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcTaxObjectName)) & COMMA) 'TaxObjectID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcBankName)) & COMMA) 'BankID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcPaymentMethodName)) & COMMA) 'PaymentMethod, varchar[50], NOT NULL
        sSQL.Append(SQLString(txtBankAccountNo.Text) & COMMA) 'BankAccountNo, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNotesU.Text, gbUnicode, True) & COMMA) 'NotesU, nvarchar[1000], NOT NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtColContactAddressU.Text, gbUnicode, True) & COMMA) 'ColContactAddressU, nvarchar[1000], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[50], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL

        'ID 105549 17.01.2018
        sSQL.Append(SQLString(txtNumIDCard.Text) & COMMA) 'NumIDCard, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcIssuedPlaceID)) & COMMA) 'IssuedPlaceID, varchar[50], NOT NULL
        sSQL.Append(SQLDateSave(c1dateNumIDCardDate.Value) & COMMA) 'NumIDCardDate, datetime, NOT NULL
        sSQL.Append(SQLString(txtIncomeTaxCode.Text) & COMMA) 'IncomeTaxCode, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcPITIssuePlaceID)) & COMMA) 'PITIssuePlaceID, varchar[50], NOT NULL
        sSQL.Append(SQLDateSave(c1datePITIssueDate.Value)) 'PITIssueDate, datetime, NOT NULL


        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1170
    '# Created User: Lê Anh Vũ
    '# Created Date: 04/11/2014 02:24:21
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1170() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa cong tac vien" & vbCrLf)
        sSQL &= "Delete From D13T1170"
        sSQL &= " Where CollaboratorID  = " & SQLString(tdbg.Columns(COL_CollaboratorID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1170
    '# Created User: Lê Anh Vũ
    '# Created Date: 04/11/2014 02:31:42
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1170() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Cap nhat cong tac vien" & vbCrLf)
        sSQL.Append("Update D13T1170 Set ")
        sSQL.Append("CollaboratorNameU = " & SQLStringUnicode(txtCollboratorName.Text, gbUnicode, True) & COMMA) 'nvarchar[500], NOT NULL
        sSQL.Append("ColContactPhone = " & SQLString(txtColContactPhone.Text) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("Email = " & SQLString(txtEmail.Text) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("ColWorkU = " & SQLStringUnicode(txtColWorkU.Text, gbUnicode, True) & COMMA) 'nvarchar[500], NOT NULL
        sSQL.Append("ColDateJoined = " & SQLDateSave(c1dateDateJoined.Text) & COMMA) 'datetime, NOT NULL
        sSQL.Append("TaxObjectID = " & SQLString(ReturnValueC1Combo(tdbcTaxObjectName)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("BankID = " & SQLString(ReturnValueC1Combo(tdbcBankName)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("PaymentMethod = " & SQLString(ReturnValueC1Combo(tdbcPaymentMethodName)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("BankAccountNo = " & SQLString(txtBankAccountNo.Text) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("NotesU = " & SQLStringUnicode(txtNotesU.Text, gbUnicode, True) & COMMA) 'nvarchar[1000], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ColContactAddressU = " & SQLStringUnicode(txtColContactAddressU.Text, gbUnicode, True) & COMMA) 'nvarchar[1000], NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL

        'ID 105549 17.01.2018
        sSQL.Append("NumIDCard = " & SQLString(txtNumIDCard.Text) & COMMA) 'NumIDCard, varchar[50], NOT NULL
        sSQL.Append("IssuedPlaceID = " & SQLString(ReturnValueC1Combo(tdbcIssuedPlaceID)) & COMMA) 'IssuedPlaceID, varchar[50], NOT NULL
        sSQL.Append("NumIDCardDate = " & SQLDateSave(c1dateNumIDCardDate.Value) & COMMA) 'NumIDCardDate, datetime, NOT NULL
        sSQL.Append("IncomeTaxCode = " & SQLString(txtIncomeTaxCode.Text) & COMMA) 'IncomeTaxCode, varchar[50], NOT NULL
        sSQL.Append("PITIssuePlaceID = " & SQLString(ReturnValueC1Combo(tdbcPITIssuePlaceID)) & COMMA) 'PITIssuePlaceID, varchar[50], NOT NULL
        sSQL.Append("PITIssueDate = " & SQLDateSave(c1datePITIssueDate.Value)) 'PITIssueDate, datetime, NOT NULL

        sSQL.Append(" Where ")
        sSQL.Append("CollaboratorID = " & SQLString(txtCollboratorID.Text)) 'varchar[50], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Lê Anh Vũ
    '# Created Date: 04/11/2014 02:26:42
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra truoc khi xoa" & vbCrLf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(_fromPermission) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_CollaboratorID).Text) & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(0) 'Num01ID, int, NOT NULL
        Return sSQL
    End Function




    Private Sub SetReturnFormView()
        _FormState = EnumFormState.FormView
        EnableMenu(False)
        If tdbg.RowCount = 0 Then
            ClearText(grpDetail)
        Else
            LoadEdit()
            tdbg.Focus()
        End If
    End Sub

    Private Sub tsbImportData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbImportData.Click, mnsImportData.Click
        Me.Cursor = Cursors.WaitCursor
        'Form trong DLL
        If CallShowDialogD80F2090(D13, "D13F1190", "D13F1190") Then
            LoadTDBGrid()
        End If

        Me.Cursor = Cursors.Default
    End Sub



    Private Sub tsmExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, mnsExportToExcel.Click
        Dim arrColObligatory() As Integer = {COL_CollaboratorID}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr, )
        'End If
        Dim dr() As DataRow = dtCaptionCols.Select("FieldName=''")
        For i As Integer = 0 To dr.Length - 1
            dtCaptionCols.Rows.Remove(dr(i))
        Next
        Dim frm As New D99F2222
        With frm
            .UseUnicode = gbUnicode
            .FormID = _fromPermission
            .dtLoadGrid = dtCaptionCols
            .GroupColumns = gsGroupColumns
            .dtExportTable = dtGrid 'Table load dữ liệu cho lưới
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        'Hỏi trước khi lưu

        If AskSave() = Windows.Forms.DialogResult.No Then
            ' SetReturnFormView()
            Exit Sub
        End If
        SaveData(sender)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'Hỏi trước khi lưu
        If AskSave() = Windows.Forms.DialogResult.No Then
            'SetReturnFormView()
            Exit Sub
        End If
        If SaveData(sender) Then tsbAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub btnNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotSave.Click
        If _FormState = EnumFormState.FormAdd AndAlso txtCollboratorID.Text = "" Then
            If tdbg.RowCount > 0 Then
                LoadEdit()
            End If
            GoTo 1
        End If
        If AskMsgBeforeRowChange() Then
            If Not SaveData(sender) Then Exit Sub
        Else
            LoadEdit()
        End If
1:
        SetReturnFormView()
    End Sub
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.TopRight, grpDetail, pnlB)
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkShowDisabled)

    End Sub

#Region "Events tdbcTaxObjectName with txtTaxObject"

    Private Sub tdbcTaxObjectName_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTaxObjectName.SelectedValueChanged
        If tdbcTaxObjectName.SelectedValue Is Nothing Then
            txtTaxObject.Text = ""
        Else
            txtTaxObject.Text = tdbcTaxObjectName.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcTaxObjectName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTaxObjectName.LostFocus
        If tdbcTaxObjectName.FindStringExact(tdbcTaxObjectName.Text) = -1 Then
            tdbcTaxObjectName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcPaymentMethodName with txtPaymentMethod"

    Private Sub tdbcPaymentMethodName_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPaymentMethodName.SelectedValueChanged
        If tdbcPaymentMethodName.SelectedValue Is Nothing Then
            txtPaymentMethod.Text = ""
        Else
            txtPaymentMethod.Text = tdbcPaymentMethodName.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcPaymentMethodName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPaymentMethodName.LostFocus
        If tdbcPaymentMethodName.FindStringExact(tdbcPaymentMethodName.Text) = -1 Then
            tdbcPaymentMethodName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcBankName with txtBankName"

    Private Sub tdbcBankName_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBankName.SelectedValueChanged
        If tdbcBankName.SelectedValue Is Nothing Then
            txtBankName.Text = ""
        Else
            txtBankName.Text = tdbcBankName.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcBankName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBankName.LostFocus
        If tdbcBankName.FindStringExact(tdbcBankName.Text) = -1 Then
            tdbcBankName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcIssuedPlaceID"

    Private Sub tdbcIssuedPlaceID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcIssuedPlaceID.LostFocus
        If tdbcIssuedPlaceID.FindStringExact(tdbcIssuedPlaceID.Text) = -1 Then tdbcIssuedPlaceID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPITIssuePlaceID"

    Private Sub tdbcPITIssuePlaceID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPITIssuePlaceID.LostFocus
        If tdbcPITIssuePlaceID.FindStringExact(tdbcPITIssuePlaceID.Text) = -1 Then tdbcPITIssuePlaceID.Text = ""
    End Sub
    Private Sub AddNewPITIssuePlaceID()
        If ReturnValueC1Combo(tdbcPITIssuePlaceID) = "+" Then
            Dim arrPro() As StructureProperties = Nothing
            SetProperties(arrPro, "FormIDPermission", "D09F1260")
            SetProperties(arrPro, "FormName", "D09F1260")
            SetProperties(arrPro, "LookupType", "D09_TaxcodePlace")
            SetProperties(arrPro, "FormText", "Danh_muc_noi_cap_ma_so_thue")
            Dim frm As Form = CallFormShowDialog("D91D0140", "D91F0310", arrPro)
            If L3Bool(GetProperties(frm, "bSaved")) Then
                LoadTDBCPITIssuePlaceID()
                tdbcPITIssuePlaceID.SelectedValue = L3String(GetProperties(frm, "LookupID"))
            Else
                tdbcPITIssuePlaceID.Text = ""
            End If
        End If
    End Sub
    Private Sub tdbcPITIssuePlaceID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcPITIssuePlaceID.SelectedValueChanged
        AddNewPITIssuePlaceID()
    End Sub
#End Region

    Private Sub txtIncomeTaxCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIncomeTaxCode.KeyPress
        If CheckIdCharactor(e.KeyChar) And e.KeyChar <> Convert.ToChar(8) Then
            e.Handled = True
        End If

    End Sub









End Class