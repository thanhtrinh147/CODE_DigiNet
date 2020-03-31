Imports System
Public Class D25F1042


#Region "Const of tdbg"
    Private Const COL_RecDepartmentID As Integer = 0     ' Phòng ban
    Private Const COL_RecDepartmentName As Integer = 1   ' Tên phòng ban
    Private Const COL_RecTeamID As Integer = 2           ' Tổ nhóm
    Private Const COL_RecTeamName As Integer = 3         ' Tên tổ nhóm
    Private Const COL_RecPositionID As Integer = 4       ' Vị trí
    Private Const COL_RecPositionName As Integer = 5     ' Tên vị trí
    Private Const COL_CandidateID As Integer = 6         ' Mã ứng viên
    Private Const COL_CandidateName As Integer = 7       ' Họ và tên
    Private Const COL_Sex As Integer = 8                 ' Giới tính
    Private Const COL_BirthDate As Integer = 9           ' Ngày sinh
    Private Const COL_ReceivedDate As Integer = 10       ' Ngày nhận
    Private Const COL_FileReceiver As Integer = 11       ' Người nhận HS
    Private Const COL_ReceivedPlace As Integer = 12      ' Nơi nhận HS
    Private Const COL_DesiredSalary As Integer = 13      ' Lương yêu cầu
    Private Const COL_CurrencyID As Integer = 14         ' Loại tiền
    Private Const COL_RecSourceName As Integer = 15      ' Nguồn tuyển dụng
    Private Const COL_Suggester As Integer = 16          ' Nguời giới thiệu
    Private Const COL_IntStatusName01 As Integer = 17    ' Vòng 1
    Private Const COL_IntStatusName02 As Integer = 18    ' Vòng 2
    Private Const COL_IntStatusName03 As Integer = 19    ' Vòng 3
    Private Const COL_IntStatusName04 As Integer = 20    ' Vòng 4
    Private Const COL_IntStatusName05 As Integer = 21    ' Vòng 5
    Private Const COL_IntStatusName06 As Integer = 22    ' Vòng 6
    Private Const COL_IntStatusName07 As Integer = 23    ' Vòng 7
    Private Const COL_IntStatusName08 As Integer = 24    ' Vòng 8
    Private Const COL_IntStatusName09 As Integer = 25    ' Vòng 9
    Private Const COL_IntStatusName10 As Integer = 26    ' Vòng 10
    Private Const COL_IntStatusNameFinal As Integer = 27 ' Vòng cuối
    Private Const COL_CreateUserID As Integer = 28       ' CreateUserID
    Private Const COL_CreateDate As Integer = 29         ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 30   ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 31     ' LastModifyDate
#End Region

    Dim sNewCandidateID As String = "" 'Dùng đặt Bookmark tại dòng vừa thêm mới

    Dim dt_LoadRecTeamIDFrom As DataTable

    Private _recruitmentFileID As String
    Public Property RecruitmentFileID() As String
        Get
            Return _recruitmentFileID
        End Get
        Set(ByVal Value As String)
            _recruitmentFileID = Value
        End Set
    End Property

    Private _voucherNo As String
    Public Property VoucherNo() As String
        Get
            Return _voucherNo
        End Get
        Set(ByVal Value As String)
            _voucherNo = Value
        End Set
    End Property

    Private _voucherDate As String
    Public Property VoucherDate() As String
        Get
            Return _voucherDate
        End Get
        Set(ByVal Value As String)
            _voucherDate = Value
        End Set
    End Property

    Private _description As String
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal Value As String)
            _description = Value
        End Set
    End Property

    Private _formPermission As String = "D25F1040"
    Public Property FormPermission() As String
        Get
            Return _formPermission
        End Get
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property

    Private Sub btnAction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAction.Click
        Dim p As Point = btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top + 40))
        C1ContextMenu.ShowContextMenu(btnAction, p)
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D25F1042_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        mnuEdit.Visible = False
        mnuPrint.Visible = False
        txtVoucherNo.Text = VoucherNo
        c1dateVoucherDate.Value = VoucherDate
        txtRecruitmentFileName.Text = Description
        Loadlanguage()
        LoadTDBCombo()
        tdbg_NumberFormat()
        'LoadTDBGrid()
        SetShortcutPopupMenu(C1CommandHolder)
        CheckMenu(_formPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        InputDateCustomFormat(c1dateVoucherDate)
        InputDateInTrueDBGrid(tdbg, COL_BirthDate, COL_ReceivedDate)

        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_dot_tuyen_dung_-_D25F1042") 'Chi tiÕt ¢ít tuyÓn dóng - D25F1042
        '================================================================ 
        lblVoucherNo.Text = rl3("Dot_tuyen") 'Đợt tuyển
        lblRecDepartmentIDFrom.Text = rl3("Phong_ban") 'Phòng ban
        lblRecTeamIDFrom.Text = rl3("To_nhom") 'Tổ nhóm
        lblRecPositionIDFrom.Text = rl3("Vi_tri_TD") 'Vị trí TD
        lblRecSourceIDFrom.Text = rl3("Nguon_TD") 'Nguồn TD
        '================================================================ 
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnFilter.Text = rl3("_Loc") '&Lọc
        '================================================================ 
        tdbcRecDepartmentIDFrom.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcRecDepartmentIDFrom.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcRecDepartmentIDTo.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcRecDepartmentIDTo.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcRecTeamIDFrom.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcRecTeamIDFrom.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcRecTeamIDTo.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcRecTeamIDTo.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcRecPositionIDFrom.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionIDFrom.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcRecPositionIDTo.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbcRecPositionIDTo.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbcRecSourceIDFrom.Columns("RecSourceID").Caption = rl3("Ma") 'Mã
        tdbcRecSourceIDFrom.Columns("RecSourceName").Caption = rl3("Ten") 'Tên
        tdbcRecSourceIDTo.Columns("RecSourceID").Caption = rl3("Ma") 'Mã
        tdbcRecSourceIDTo.Columns("RecSourceName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("RecDepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("RecDepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("RecTeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("RecTeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionID").Caption = rl3("Vi_tri_TD") 'Vị trí TD
        tdbg.Columns("RecPositionName").Caption = rl3("Ten_vi_tri") 'Tên vị trí
        tdbg.Columns("CandidateID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("CandidateName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("Sex").Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg.Columns("BirthDate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns("ReceivedDate").Caption = rl3("Ngay_nhan") 'Ngày nhận
        tdbg.Columns("FileReceiver").Caption = rl3("Nguoi_nhan_HS") 'Người nhận HS
        tdbg.Columns("ReceivedPlace").Caption = rl3("Noi_nhan_HS") 'Nơi nhận HS
        tdbg.Columns("DesiredSalary").Caption = rl3("Luong_yeu_cau") 'Lương yêu cầu
        tdbg.Columns("CurrencyID").Caption = rl3("Loai_tien") 'Loại tiền
        tdbg.Columns("RecSourceName").Caption = rl3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        tdbg.Columns("Suggester").Caption = rl3("Nguoi_gioi_thieu") 'Nguời giới thiệu
        tdbg.Columns("IntStatusName01").Caption = rl3("Vong_1") 'Vòng 1
        tdbg.Columns("IntStatusName02").Caption = rl3("Vong_2") 'Vòng 2
        tdbg.Columns("IntStatusName03").Caption = rl3("Vong_3") 'Vòng 3
        tdbg.Columns("IntStatusName04").Caption = rl3("Vong_4") 'Vòng 4
        tdbg.Columns("IntStatusName05").Caption = rl3("Vong_5") 'Vòng 5
        tdbg.Columns("IntStatusName06").Caption = rl3("Vong_6") 'Vòng 6
        tdbg.Columns("IntStatusName07").Caption = rl3("Vong_7") 'Vòng 7
        tdbg.Columns("IntStatusName08").Caption = rl3("Vong_8") 'Vòng 8
        tdbg.Columns("IntStatusName09").Caption = rl3("Vong_9") 'Vòng 9
        tdbg.Columns("IntStatusName10").Caption = rl3("Vong_10") 'Vòng 10
        tdbg.Columns("IntStatusNameFinal").Caption = rl3("Vong_cuoi") 'Vòng cuối
        '================================================================ 
        mnuAdd.Text = rl3("_Them") '&Thêm
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuEdit.Text = rl3("_Sua") '&Sửa
        mnuDelete.Text = rl3("_Xoa") '&Xóa
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuPrint.Text = rl3("_In") '&In
    End Sub


    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcRecDepartmentIDFrom
        'Load tdbcRecDepartmentIDTo
        sSQL = "Select 1 as DisplayOrder,DepartmentID, DepartmentName From D91T0012 WITH(NOLOCK)  Where Disabled=0 And DivisionID= " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 0 as DisplayOrder,'%' as DepartmentID," & IIf(geLanguage = EnumLanguage.Vietnamese, "'Taát caû'", "'All'").ToString & " as DepartmentName" & vbCrLf
        sSQL &= "Order by DisplayOrder, DepartmentID"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcRecDepartmentIDFrom, dt)
        LoadDataSource(tdbcRecDepartmentIDTo, dt.Copy)
        'Load tdbcRecTeamIDFrom
        'LoadtdbcRecTeamIDFrom("-1")
        'Load tdbcRecTeamIDTo
        'LoadtdbcRecTeamIDTo("-1")
        'Load tdbcRecPositionIDFrom
        'Load tdbcRecPositionIDTo
        sSQL = "Select 1 as DisplayOrder, RecPositionID, RecPositionName From 	D25T1020 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 " & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select	0 as DisplayOrder, '%'	as RecPositionID," & IIf(geLanguage = EnumLanguage.Vietnamese, "'Taát caû'", "'All'").ToString & " as RecPositionName" & vbCrLf
        sSQL &= "Order by	DisplayOrder, RecPositionID"
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbcRecPositionIDFrom, dt)
        LoadDataSource(tdbcRecPositionIDTo, dt.Copy)
        'Load tdbcRecSourceIDFrom
        'Load tdbcRecSourceIDTo
        sSQL = "Select 1 as DisplayOrder, RecSourceID, RecSourceName From D25T1010 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "Where Disabled = 0 " & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select	0 as DisplayOrder, '%'	as RecSourceID," & IIf(geLanguage = EnumLanguage.Vietnamese, "'Taát caû'", "'All'").ToString & " as RecSourceName" & vbCrLf
        sSQL &= "Order by	DisplayOrder, RecSourceID"
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbcRecSourceIDFrom, dt)
        LoadDataSource(tdbcRecSourceIDTo, dt.Copy)
    End Sub

    Private Sub LoadtdbcRecTeamIDFrom(ByVal ID As String)
        Dim sSQL As String = ""
        sSQL = " 	Select	1 as DisplayOrder,T1.TeamID,T1.TeamName, T1.DepartmentID From D09T0227 T1 WITH(NOLOCK) " & vbCrLf
        sSQL &= " 	Inner join 	D91T0012 T2  WITH(NOLOCK) On T2.DepartmentID=T1.DepartmentID" & vbCrLf
        sSQL &= " 	Where	T1.Disabled = 0 And T2.DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " And T1.DepartmentID= " & SQLString(ID) & vbCrLf
        sSQL &= " 	Union" & vbCrLf
        sSQL &= " 	Select 	0 as DisplayOrder, '%' as TeamID," & IIf(geLanguage = EnumLanguage.Vietnamese, "'Taát caû'", "'All'").ToString & "	as TeamName,  '%' as DepartmentID" & vbCrLf
        sSQL &= " 	Order by	DisplayOrder, T1.DepartmentID,T1.TeamID"
        dt_LoadRecTeamIDFrom = ReturnDataTable(sSQL)
        LoadDataSource(tdbcRecTeamIDFrom, dt_LoadRecTeamIDFrom)
    End Sub

    Private Sub LoadtdbcRecTeamIDTo(ByVal ID As String)
        LoadDataSource(tdbcRecTeamIDTo, dt_LoadRecTeamIDFrom.Copy)
    End Sub

#Region "Events tdbcRecDepartmentIDFrom load tdbcRecTeamIDFrom"

    Private Sub tdbcRecDepartmentIDFrom_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDFrom.Close
        If tdbcRecDepartmentIDFrom.FindStringExact(tdbcRecDepartmentIDFrom.Text) = -1 Then tdbcRecDepartmentIDFrom.Text = ""
    End Sub

    Private Sub tdbcRecDepartmentIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDFrom.SelectedValueChanged
        If Not (tdbcRecDepartmentIDFrom.Tag Is Nothing OrElse tdbcRecDepartmentIDFrom.Tag.ToString = "") Then
            tdbcRecDepartmentIDFrom.Tag = ""
            Exit Sub
        End If
        If tdbcRecDepartmentIDFrom.SelectedValue Is Nothing Then
            LoadtdbcRecTeamIDFrom("-1")
            Exit Sub
        End If

        If tdbcRecDepartmentIDFrom.Text = "%" Then
            tdbcRecDepartmentIDTo.Text = "%"
            tdbcRecDepartmentIDTo.Enabled = False
            tdbcRecTeamIDFrom.Enabled = False
        Else
            tdbcRecDepartmentIDTo.Enabled = True
            If tdbcRecDepartmentIDFrom.Text = tdbcRecDepartmentIDTo.Text Then
                tdbcRecTeamIDFrom.Enabled = True
                LoadtdbcRecTeamIDFrom(tdbcRecDepartmentIDFrom.SelectedValue.ToString())
            Else
                tdbcRecTeamIDFrom.Enabled = False
            End If
        End If
        tdbcRecTeamIDFrom.Text = "%"

    End Sub

    Private Sub tdbcRecDepartmentIDFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecDepartmentIDFrom.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecDepartmentIDFrom.Text = ""
    End Sub

    Private Sub tdbcRecTeamIDFrom_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecTeamIDFrom.Close
        If tdbcRecTeamIDFrom.FindStringExact(tdbcRecTeamIDFrom.Text) = -1 Then tdbcRecTeamIDFrom.Text = ""
    End Sub

    Private Sub tdbcRecTeamIDFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecTeamIDFrom.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecTeamIDFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecDepartmentIDTo load tdbcRecTeamIDTo"

    Private Sub tdbcRecDepartmentIDTo_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDTo.Close
        If tdbcRecDepartmentIDTo.FindStringExact(tdbcRecDepartmentIDTo.Text) = -1 Then tdbcRecDepartmentIDTo.Text = ""
    End Sub

    Private Sub tdbcRecDepartmentIDTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecDepartmentIDTo.SelectedValueChanged
        If Not (tdbcRecDepartmentIDTo.Tag Is Nothing OrElse tdbcRecDepartmentIDTo.Tag.ToString = "") Then
            tdbcRecDepartmentIDTo.Tag = ""
            Exit Sub
        End If
        If tdbcRecDepartmentIDTo.SelectedValue Is Nothing Then
            LoadtdbcRecTeamIDTo("-1")
            Exit Sub
        End If
        If tdbcRecDepartmentIDTo.Text = "%" Then
            tdbcRecTeamIDFrom.Text = "%"
            tdbcRecTeamIDFrom.Enabled = False
            'tdbcRecTeamIDTo.Text = "%"
            tdbcRecTeamIDTo.Enabled = False
        Else
            If tdbcRecDepartmentIDFrom.Text = tdbcRecDepartmentIDTo.Text Then
                tdbcRecTeamIDFrom.Enabled = True
                tdbcRecTeamIDTo.Enabled = tdbcRecTeamIDFrom.Text <> "%"
                LoadtdbcRecTeamIDFrom(tdbcRecDepartmentIDTo.SelectedValue.ToString())
            Else
                tdbcRecTeamIDFrom.Text = "%"
                tdbcRecTeamIDFrom.Enabled = False
                'tdbcRecTeamIDTo.Text = "%"
                tdbcRecTeamIDTo.Enabled = False
            End If
        End If

        tdbcRecTeamIDTo.Text = "%"
    End Sub

    Private Sub tdbcRecDepartmentIDTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecDepartmentIDTo.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecDepartmentIDTo.Text = ""
    End Sub

    Private Sub tdbcRecTeamIDTo_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecTeamIDTo.Close
        If tdbcRecTeamIDTo.FindStringExact(tdbcRecTeamIDTo.Text) = -1 Then tdbcRecTeamIDTo.Text = ""
    End Sub

    Private Sub tdbcRecTeamIDTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecTeamIDTo.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecTeamIDTo.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecPositionIDFrom"

    Private Sub tdbcRecPositionIDFrom_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionIDFrom.Close
        If tdbcRecPositionIDFrom.FindStringExact(tdbcRecPositionIDFrom.Text) = -1 Then tdbcRecPositionIDFrom.Text = ""
    End Sub

    Private Sub tdbcRecPositionIDFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecPositionIDFrom.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecPositionIDFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecPositionIDTo"

    Private Sub tdbcRecPositionIDTo_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecPositionIDTo.Close
        If tdbcRecPositionIDTo.FindStringExact(tdbcRecPositionIDTo.Text) = -1 Then tdbcRecPositionIDTo.Text = ""
    End Sub

    Private Sub tdbcRecPositionIDTo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecPositionIDTo.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecPositionIDTo.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecSourceIDFrom"

    Private Sub tdbcRecSourceIDFrom_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecSourceIDFrom.Close
        If tdbcRecSourceIDFrom.FindStringExact(tdbcRecSourceIDFrom.Text) = -1 Then tdbcRecSourceIDFrom.Text = ""
    End Sub

    Private Sub tdbcRecSourceIDFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecSourceIDFrom.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecSourceIDFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcRecSourceIDTo"

    Private Sub tdbcRecSourceIDTo_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecSourceIDTo.Close
        If tdbcRecSourceIDTo.FindStringExact(tdbcRecSourceIDTo.Text) = -1 Then tdbcRecSourceIDTo.Text = ""
    End Sub

    Private Sub tdbcRecSourceIDTo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcRecSourceIDTo.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcRecSourceIDTo.Text = ""
    End Sub

#End Region

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If mnuView.Enabled Then mnuView_Click(sender, Nothing)
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        Select Case tdbg.Col
            Case COL_RecDepartmentID, COL_RecTeamID, COL_RecPositionID
                e.CellTip = tdbg.Columns(tdbg.Col + 1).Text
            Case Else
                e.CellTip = ""
        End Select
    End Sub

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLStoreD25P1042
    ''# Created User: Nguyễn Thị Ánh
    ''# Created Date: 19/11/2007 10:46:16
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: Load tdbg
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD25P1042() As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D25P1042 "
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLString(RecruitmentFileID) & COMMA 'RecruitmentFileID, varchar[20], NOT NULL
    '    sSQL &= SQLString(tdbcRecDepartmentIDFrom.Text) & COMMA 'RecDepartmentIDFrom, varchar[20], NOT NULL
    '    sSQL &= SQLString(tdbcRecDepartmentIDTo.Text) & COMMA 'RecDepartmentIDTo, varchar[20], NOT NULL
    '    sSQL &= SQLString(tdbcRecTeamIDFrom.Text) & COMMA 'RecTeamIDFrom, varchar[20], NOT NULL
    '    sSQL &= SQLString(tdbcRecTeamIDTo.Text) & COMMA 'RecTeamIDTo, varchar[20], NOT NULL
    '    sSQL &= SQLString(tdbcRecPositionIDFrom.Text) & COMMA 'RecPositionIDFrom, varchar[20], NOT NULL
    '    sSQL &= SQLString(tdbcRecPositionIDTo.Text) & COMMA 'RecPositionIDTo, varchar[20], NOT NULL
    '    sSQL &= SQLString(tdbcRecSourceIDFrom.Text) & COMMA 'RecsourceIDFrom, varchar[20], NOT NULL
    '    sSQL &= SQLString(tdbcRecSourceIDTo.Text) & COMMA 'RecsourceIDTo, varchar[20], NOT NULL
    '    sSQL &= SQLString(sFind) 'WhereClause, varchar[1000], NOT NULL
    '    Return sSQL
    'End Function


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


    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        sSQL = "Select * From D25V1234 "
        sSQL &= "Where FormID = " & SQLString(Me) & "And Language = " & SQLString(gsLanguage)
        ShowFindDialogClient(Finder, sSQL)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        'LoadGridFind(tdbg, dt, sFind)
        'CheckMenu(_formPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
        LoadTDBGrid()
    End Sub
#End Region

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD25P1042(RecruitmentFileID, tdbcRecDepartmentIDFrom.Text, tdbcRecDepartmentIDTo.Text, tdbcRecTeamIDFrom.Text, tdbcRecTeamIDTo.Text, tdbcRecPositionIDFrom.Text, tdbcRecPositionIDTo.Text, tdbcRecSourceIDFrom.Text, tdbcRecSourceIDTo.Text, , sFind)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt)
        If sNewCandidateID <> "" Then
            dt.DefaultView.Sort = "CandidateID"
            tdbg.Bookmark = dt.DefaultView.Find(sNewCandidateID)
            sNewCandidateID = ""
        End If
        CheckMenu(_formPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_DesiredSalary).NumberFormat = D25Format.DefaultNumber2
    End Sub


    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Enabled = False
        sFind = ""
        LoadTDBGrid()
        btnFilter.Enabled = True
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T1042
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 19/11/2007 11:06:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T1042() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T1042"
        sSQL &= " Where "
        'sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "RecruitmentFileID = " & SQLString(RecruitmentFileID) & " And "
        sSQL &= "CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text)
        Return sSQL
    End Function

    Private Function AllowDelete() As Boolean
        Dim sSQL As String = ""
        sSQL = "Select 1 From D25T2011  WITH(NOLOCK) "
        sSQL &= " Where "
        'sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "RecruitmentFileID = " & SQLString(RecruitmentFileID) & " And "
        sSQL &= "CandidateID = " & SQLString(tdbg.Columns(COL_CandidateID).Text)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            D99C0008.MsgCanNotDelete()
            Return False
        End If
        Return True
    End Function

  
    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelete.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowDelete() Then Exit Sub
        Dim sSQL As String = SQLDeleteD25T1042()
        Dim bRunSQL As Boolean = ExecuteSQLNoTransaction(sSQL)
        If bRunSQL Then
            DeleteOK()
            Dim bm As Integer = tdbg.Bookmark
            LoadTDBGrid()
            tdbg.Bookmark = bm - 1
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub mnuView_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        Dim f As New D25F1044
        f.RecruitmentFileID = RecruitmentFileID
        'f.RecDepartmentIDFrom = tdbcRecDepartmentIDFrom.Text
        'f.RecDepartmentIDTo = tdbcRecDepartmentIDTo.Text
        'f.RecTeamIDFrom = tdbcRecTeamIDFrom.Text
        'f.RecTeamIDTo = tdbcRecTeamIDTo.Text
        'f.RecPositionIDFrom = tdbcRecPositionIDFrom.Text
        'f.RecPositionIDTo = tdbcRecPositionIDTo.Text
        'f.RecSourceIDFrom = tdbcRecSourceIDFrom.Text
        'f.RecSourceIDTo = tdbcRecSourceIDTo.Text
        f.CandidateID = tdbg.Columns(COL_CandidateID).Text
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            tdbg_DoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub tdbcRecTeamIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecTeamIDFrom.SelectedValueChanged
        tdbcRecTeamIDTo.Text = "%"
        tdbcRecTeamIDTo.Enabled = tdbcRecTeamIDFrom.Text <> "%"
        LoadtdbcRecTeamIDTo(tdbcRecDepartmentIDTo.SelectedValue.ToString())
    End Sub

    Private Sub tdbcRecPositionIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecPositionIDFrom.SelectedValueChanged
        tdbcRecPositionIDTo.Text = "%"
        tdbcRecPositionIDTo.Enabled = tdbcRecPositionIDFrom.Text <> "%"
    End Sub

    Private Sub tdbcRecSourceIDFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecSourceIDFrom.SelectedValueChanged
        tdbcRecSourceIDTo.Text = "%"
        tdbcRecSourceIDTo.Enabled = tdbcRecSourceIDFrom.Text <> "%"
    End Sub

    Private Sub mnuSysInfo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAdd.Click
        If Not CallMenuFromGrid(tdbg, e) Then Exit Sub

        Dim f As New D25F1043
        f.RecruitmentFileID = RecruitmentFileID
        f.ShowDialog()
        If Not f.FormClose Then
            sNewCandidateID = f.Candidate
            LoadTDBGrid()
        End If
        f.Dispose()
    End Sub
End Class