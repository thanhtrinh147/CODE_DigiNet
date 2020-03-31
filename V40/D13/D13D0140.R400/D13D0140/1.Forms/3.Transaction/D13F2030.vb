Imports System
Public Class D13F2030
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_DepartmentID As Integer = 0       ' Phòng ban
    Private Const COL_TeamID As Integer = 1             ' Tổ nhóm
    Private Const COL_EmployeeID As Integer = 2         ' Mã NV
    Private Const COL_EmployeeName As Integer = 3       ' Họ và tên
    Private Const COL_Birthdate As Integer = 4          ' Ngày sinh
    Private Const COL_VoucherNo As Integer = 5          ' Số phiếu
    Private Const COL_VoucherDate As Integer = 6        ' Ngày phiếu
    Private Const COL_VoucherID As Integer = 7          ' VoucherID
    Private Const COL_AbsentVoucherNo As Integer = 8    ' Chấm công nhật
    Private Const COL_TransferAbsentType As Integer = 9 ' Loại công
    Private Const COL_TATValue As Integer = 10          ' Giá trị
    Private Const COL_TransferValue As Integer = 11     ' Giá trị chuyển
    Private Const COL_LeaveTypeID As Integer = 12       ' Loại phép
    Private Const COL_LeaveCoefficient As Integer = 13  ' Hệ số
    Private Const COL_ReceiveAbsentType As Integer = 14 ' Công nhận
    Private Const COL_ReceiveValue As Integer = 15      ' Giá trị nhận
    Private Const COL_AddLeaveQuantity As Integer = 16  ' Phép cộng thêm
    Private Const COL_RemainValue As Integer = 17       ' Giá trị còn lại
    Private Const COL_CreateUserID As Integer = 18      ' CreateUserID
    Private Const COL_CreateDate As Integer = 19        ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 20  ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 21    ' LastModifyDate
    Private Const COL_DivisionID As Integer = 22        ' DivisionID
    Private Const COL_TranMonth As Integer = 23         ' TranMonth
    Private Const COL_TranYear As Integer = 24          ' TranYear
#End Region

    Private _absentVoucherNo As String = ""
    Public Property AbsentVoucherNo() As String 
        Get
            Return _absentVoucherNo
        End Get
        Set(ByVal Value As String )
            _absentVoucherNo = Value
        End Set
    End Property

    Private _absentVoucherID As String = ""
    Public Property AbsentVoucherID() As String 
        Get
            Return _absentVoucherID
        End Get
        Set(ByVal Value As String )
            _absentVoucherID = Value
        End Set
    End Property

    Private _remark As String = ""
    Public Property Remark() As String 
        Get
            Return _remark
        End Get
        Set(ByVal Value As String )
            _remark = Value
        End Set
    End Property

    Private _enabledMenu As String = "1"
    Public Property EnabledMenu() As String 
        Get
            Return _enabledMenu
        End Get
        Set(ByVal Value As String )
            _enabledMenu = Value
        End Set
    End Property

    Dim dt As New DataTable
    Dim sVoucherID As String = ""

    Private Sub D13F2030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
    End Sub

    Private Sub D13F2030_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        SetShortcutPopupMenu(Me.C1CommandHolder)
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        ResetColorGrid(tdbg, 0, 1)
        ResetSplitDividerSize(tdbg)
        tdbg_NumberFormat()
        txtAbsentVoucherID.Text = _absentVoucherNo
        txtAbsentVoucherNoName.Text = _remark
        LoadTDBGrid(_absentVoucherID)
        InputDateInTrueDBGrid(tdbg, COL_Birthdate, COL_VoucherDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TATValue).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TATValue).Locked = True
        tdbg.Splits(SPLIT1).DisplayColumns(COL_RemainValue).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_RemainValue).Locked = True
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_chuyen_cong_sang_phep_-_D13F2030") & UnicodeCaption(gbUnicode) 'Truy vÊn chuyÓn c¤ng sang phÏp - D13F2030
        '================================================================ 
        lblAbsentVoucherNo.Text = rl3("Cham_cong_nhat") 'Chấm công nhật
        '================================================================ 
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcAbsentVoucherNo.Columns("AbsentVoucherNo").Caption = rl3("Ma") 'Mã
        tdbcAbsentVoucherNo.Columns("Remark").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_NV") 'Mã NV
        tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("Birthdate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("VoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("AbsentVoucherNo").Caption = rl3("Cham_cong_nhat") 'Chấm công nhật
        tdbg.Columns("TransferAbsentType").Caption = rl3("Loai_cong") 'Loại công
        tdbg.Columns("TATValue").Caption = rl3("Gia_tri_") 'Giá trị
        tdbg.Columns("TransferValue").Caption = rl3("Gia_tri_chuyen") 'Giá trị chuyển
        tdbg.Columns("LeaveTypeID").Caption = rl3("Loai_phep") 'Loại phép
        tdbg.Columns("LeaveCoefficient").Caption = rl3("He_so") 'Hệ số
        tdbg.Columns("AddLeaveQuantity").Caption = rl3("Phep_cong_them") 'Phép cộng thêm
        tdbg.Columns("ReceiveAbsentType").Caption = rl3("Cong_nhan") 'Công nhận
        tdbg.Columns("ReceiveValue").Caption = rl3("Gia_tri_nhan") 'Giá trị nhận
        tdbg.Columns("RemainValue").Caption = rl3("Gia_tri_con_lai") 'Giá trị còn lại
        '================================================================ 
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuSysInfo.Text = rL3("Thong_tin__he_thong") 'Thông tin &hệ thống
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcAbsentVoucherNo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_TransferValue).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_ReceiveValue).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_AddLeaveQuantity).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_TATValue).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_RemainValue).NumberFormat = D13Format.DefaultNumber2
    End Sub

    Private Sub LoadTDBGrid(ByVal ID As String, Optional ByVal bFlag As Boolean = False)
        Dim sSQL As String
        sSQL = "SELECT T1.*,  (Isnull(T3.NumberOfDays, 0) + Isnull(TransferValue, 0)) As TATValue, T3.NumberOfDays As RemainValue," & vbCrLf
        sSQL &= "IsNull(LastName" & UnicodeJoin(gbUnicode) & ",'')+ ' ' + IsNull(MiddleName" & UnicodeJoin(gbUnicode) & ",'')+ ' ' + IsNull(FirstName" & UnicodeJoin(gbUnicode) & ",'') " & vbCrLf
        sSQL &= "AS EmployeeName, T2.Birthdate, T2.DepartmentID, T2.TeamID" & vbCrLf
        sSQL &= "FROM D13T2031 T1 WITH (NOLOCK) " & vbCrLf
        sSQL &= "INNER JOIN D13T0103 T3  WITH (NOLOCK) ON T1.AbsentVoucherID = T3.AbsentVoucherID AND T1.EmployeeID = T3.EmployeeID AND T1.DivisionID = T3.DivisionID And T1.TransferAbsentType = T3.AbsentTypeID" & vbCrLf
        sSQL &= "INNER JOIN	D09T0201 T2  WITH (NOLOCK) ON T1.EmployeeID = T2.EmployeeID" & vbCrLf
        sSQL &= "WHERE CASE WHEN " & SQLString(ID) & " = '%' THEN '%'" & vbCrLf
        sSQL &= "ELSE T1.AbsentVoucherID END = " & SQLString(ID) & vbCrLf
        sSQL &= "ORDER BY  T2.DepartmentID, T2.TeamID, T1.EmployeeID"
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt, gbUnicode)

        If bFlag = True Then
            dt.DefaultView.Sort = "VoucherID"
            tdbg.Bookmark = dt.DefaultView.Find(sVoucherID)
        End If

        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        If mnuAdd.Enabled Then mnuAdd.Enabled = CBool(_enabledMenu)
        If mnuDelete.Enabled Then mnuDelete.Enabled = CBool(_enabledMenu)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcAbsentVoucherNo
        sSQL = "SELECT '%' AS AbsentVoucherNo, 'Taát caû' As Remark, 0 As DisplayOrder" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT AbsentVoucherNo, Remark, 1 As DisplayOrder" & vbCrLf
        sSQL &= "FROM D13T0102 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "AND TranMonth = " & SQLString(giTranMonth) & vbCrLf
        sSQL &= "AND TranYear = " & SQLString(giTranYear) & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, AbsentVoucherNo"

        LoadDataSource(tdbcAbsentVoucherNo, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcAbsentVoucherNo with txtAbsentVoucherNoName"

    Private Sub tdbcAbsentVoucherNo_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAbsentVoucherNo.Close
        If tdbcAbsentVoucherNo.FindStringExact(tdbcAbsentVoucherNo.Text) = -1 Then
            tdbcAbsentVoucherNo.Text = ""
            txtAbsentVoucherNoName.Text = ""
        End If
    End Sub

    Private Sub tdbcAbsentVoucherNo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAbsentVoucherNo.SelectedValueChanged
        If Not (tdbcAbsentVoucherNo.Tag Is Nothing OrElse tdbcAbsentVoucherNo.Tag.ToString = "") Then
            tdbcAbsentVoucherNo.Tag = ""
            Exit Sub
        End If
        If tdbcAbsentVoucherNo.SelectedValue Is Nothing Then
            LoadTDBGrid("")
            Exit Sub
        End If
        txtAbsentVoucherNoName.Text = tdbcAbsentVoucherNo.Columns("Remark").Value.ToString
        LoadTDBGrid(tdbcAbsentVoucherNo.Text)
    End Sub

    Private Sub tdbcAbsentVoucherNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAbsentVoucherNo.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcAbsentVoucherNo.Text = ""
        '    txtAbsentVoucherNoName.Text = ""
        'End If
    End Sub

#End Region

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
    'Dim dtCaptionCols As DataTable

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        'Dim sSQL As String = ""
        'gbEnabledUseFind = True
        'sSQL = "Select * From D13V1234 "
        'sSQL &= "Where FormID = " & SQLString(Me.Name) & "And Language = " & SQLString(gsLanguage)
        'ShowFindDialogClient(Finder, sSQL)
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        '72334
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , False, False, gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, , False, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        LoadGridFind(tdbg, dt, sFind)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        If mnuAdd.Enabled Then mnuAdd.Enabled = CBool(_enabledMenu)
        If mnuDelete.Enabled Then mnuDelete.Enabled = CBool(_enabledMenu)
    End Sub
#End Region

    Private Sub mnuSysInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim f As New D13F2031
        With f
            .AbsentVoucherID = _absentVoucherID
            .ShowDialog()
            .Dispose()
        End With
        LoadTDBGrid(_absentVoucherID, True)
    End Sub

    Private Sub mnuView_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim Frm As New D13F2031
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark

        With Frm
            .AbsentVoucherID = txtAbsentVoucherID.Text
            .ShowDialog()
            .Dispose()
        End With
        If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEdit.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim Frm As New D13F2031
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        With Frm
            .AbsentVoucherID = txtAbsentVoucherID.Text
            .ShowDialog()
            .Dispose()
        End With
        LoadTDBGrid(tdbcAbsentVoucherNo.Text)
        If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim sSQL As String = ""
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If tdbg.RowCount <= 0 Then Exit Sub

        'sSQL = SQLDeleteD91T9009.ToString & vbCrLf
        'sSQL &= SQLInsertD91T9009.ToString & vbCrLf
        'sSQL &= SQLStoreD15P2071.ToString

        'Dim dt As New DataTable
        'dt = ReturnDataTable(sSQL)
        'If dt.Rows.Count > 0 Then
        '    If dt.Rows(0).Item("Status").ToString = "0" Then
        '        'Xoa du lieu
        '        sSQL = SQLStoreD13P2032()
        '        If ExecuteSQL(sSQL) Then
        '            DeleteOK()
        '            LoadTDBGrid(tdbcAbsentVoucherNo.Text)
        '        Else
        '            DeleteNotOK()
        '        End If
        '    ElseIf dt.Rows(0).Item("Status").ToString = "1" Then
        '        MessageBox.Show(rl3("Du_lieu_nam_nay_da_duoc_ket_chuyenF") & " " & rl3("Ban_khong_duoc_phep_xoaF"), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        'Dö liÖu nŸm nªy ¢º ¢§íc kÕt chuyÓn. BÁn kh¤ng ¢§íc phÏp xâa.
        '    ElseIf dt.Rows(0).Item("Status").ToString = "2" Then
        '        MessageBox.Show(rl3("So_luong_phep_cua_nhan_vien_da_duoc_su_dungF") & " " & rl3("Ban_khong_duoc_phep_xoaF"), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        'Sç l§íng phÏp cïa nh¡n vi£n ¢º ¢§íc sõ dóng. BÁn kh¤ng ¢§íc phÏp xâa.
        '    End If
        '    dt = Nothing
        'Else
        '    D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
        'End If

        'Xoa du lieu
        sSQL = SQLStoreD13P2032()
        If ExecuteSQL(sSQL) Then
            DeleteOK()
            _bSaved = True
            LoadTDBGrid(_absentVoucherID)
        Else
            DeleteNotOK()
        End If

        'ExecuteSQL(SQLDeleteD91T9009.ToString)
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.RowCount < 1 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If mnuEdit.Enabled Then
            mnuEdit_Click(sender, Nothing)
        Else
            mnuView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.RowCount < 1 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            If mnuEdit.Enabled Then
                mnuEdit_Click(sender, Nothing)
            Else
                mnuView_Click(sender, Nothing)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2032
    '# Created User: DUCTRONG
    '# Created Date: 06/01/2009 10:41:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2032() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2032 "
        sSQL &= SQLString(tdbg.Columns(COL_VoucherID).Text) & COMMA 'VoucherID, varchar[20], NOT NULL
        'sSQL &= SQLString(tdbg.Columns(COL_VoucherNo).Text) & COMMA 'VoucherNo, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'VoucherNo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_DivisionID).Text) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_EmployeeID).Text) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_AbsentVoucherNo).Text) & COMMA 'AbsentVoucherNo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransferAbsentType).Text) & COMMA 'TransferAbsentType, varchar[20], NOT NULL
        sSQL &= SQLMoney(tdbg.Columns(COL_TransferValue).Text, D13Format.DefaultNumber2) & COMMA 'TransferValue, decimal, NOT NULL
        'sSQL &= SQLString(tdbg.Columns(COL_ReceiveAbsentType).Text) & COMMA 'ReceiveAbsentType, varchar[20], NOT NULL
        'sSQL &= SQLMoney(tdbg.Columns(COL_ReceiveValue).Text, D13Format.DefaultNumber2) & COMMA 'ReceiveValue, decimal, NOT NULL
        sSQL &= SQLString("") & COMMA 'ReceiveAbsentType, varchar[20], NOT NULL
        sSQL &= SQLMoney(0) & COMMA 'ReceiveValue, decimal, NOT NULL

        sSQL &= SQLMoney(tdbg.Columns(COL_AddLeaveQuantity).Text, D13Format.DefaultNumber2) & COMMA 'AddLeaveQuantity, decimal, NOT NULL
        sSQL &= SQLNumber(tdbg.Columns(COL_TranMonth).Text) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbg.Columns(COL_TranYear).Text) & COMMA 'TranYear, int, NOT NULL

        sSQL &= SQLString(_absentVoucherID)  'DivisionID, varchar[20], NOT NULL
        'sSQL &= SQLMoney(tdbg.Columns(COL_TATValue).Text, D13Format.DefaultNumber2)  'EmployeeID, varchar[20], NOT NULL

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 21/05/2009 02:42:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D91T9009"
        sSQL &= " WHERE	UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name)
        sSQL &= " AND Key02ID = 'I02'"

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 21/05/2009 02:42:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D91T9009(")
        sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, ")
        sSQL.Append("Key04ID, Key05ID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbg.Columns(COL_VoucherID).Text) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString("I02") & COMMA) 'Key02ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(giTranYear) & COMMA) 'Key03ID, varchar[250], NOT NULL
        sSQL.Append(SQLString("") & COMMA) 'Key04ID, varchar[250], NOT NULL
        sSQL.Append(SQLString("")) 'Key05ID, varchar[250], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD15P2071
    '# Created User: DUCTRONG
    '# Created Date: 21/05/2009 02:47:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD15P2071() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D15P2071 "
        sSQL &= SQLString("I02") & COMMA 'TransType, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(2) 'Mode, int, NOT NULL
        Return sSQL
    End Function


End Class