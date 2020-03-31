Imports System
Public Class D25F1040
	Dim dtCaptionCols As DataTable


#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0           ' TransID
    Private Const COL_BlockID As Integer = 1           ' BlockID
    Private Const COL_BlockName As Integer = 2         ' Khối
    Private Const COL_DepartmentID As Integer = 3      ' DepartmentID
    Private Const COL_DepartmentName As Integer = 4    ' Phòng ban
    Private Const COL_TeamID As Integer = 5            ' TeamID
    Private Const COL_TeamName As Integer = 6          ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 7     ' RecPositionID
    Private Const COL_RecPositionName As Integer = 8   ' Vị trí
    Private Const COL_ProjectID As Integer = 9         ' Dự án
    Private Const COL_Number As Integer = 10           ' Số lượng
    Private Const COL_DateFrom As Integer = 11         ' Từ ngày
    Private Const COL_DateTo As Integer = 12           ' Đến ngày
    Private Const COL_Sex As Integer = 13              ' Giới tính
    Private Const COL_EducationLevelID As Integer = 14 ' Trình độ giáo dục phổ thông
    Private Const COL_InterviewDate As Integer = 15    ' Ngày phỏng vấn
    Private Const COL_DateJoined As Integer = 16       ' Ngày bắt đầu công việc
    Private Const COL_NoteDetail As Integer = 17       ' Ghi chú
#End Region

#Region "Const of tdbgDetail"
    Private Const COL1_RecruitmentFielID As Integer = 0 ' RecruitmentFielID
    Private Const COL1_BlockID As Integer = 1           ' BlockID
    Private Const COL1_BlockName As Integer = 2         ' Khối
    Private Const COL1_DepartmentID As Integer = 3      ' DepartmentID
    Private Const COL1_DepartmentName As Integer = 4    ' Phòng ban
    Private Const COL1_TeamID As Integer = 5            ' TeamID
    Private Const COL1_TeamName As Integer = 6          ' Tổ nhóm
    Private Const COL1_RecPositionID As Integer = 7     ' RecPositionID
    Private Const COL1_RecPositionName As Integer = 8   ' Vị trí
    Private Const COL1_RecSourceID As Integer = 9       ' RecSourceID
    Private Const COL1_RecSourceName As Integer = 10    ' Nguồn tuyển dụng
    Private Const COL1_CandidateID As Integer = 11      ' Mã ứng viên
    Private Const COL1_CandidateName As Integer = 12    ' Tên ứng viên
    Private Const COL1_SexName As Integer = 13          ' Giới tính
    Private Const COL1_Birthdate As Integer = 14        ' Ngày sinh
    Private Const COL1_ReceivedDate As Integer = 15     ' Ngày nhận HS
    Private Const COL1_ReceiverName As Integer = 16     ' Người nhận HS
    Private Const COL1_ReceivedPlace As Integer = 17    ' Nơi nhận HS
    Private Const COL1_DesiredSalary As Integer = 18    ' Lương yêu cầu
    Private Const COL1_CurrencyID As Integer = 19       ' Loại tiền
    Private Const COL1_SuggesterName As Integer = 20    ' Người giới thiệu
#End Region


    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    '*****************************************
    '*****************************************
    Dim bLoadD25F1040 As Boolean = False 'Ktra xem co goi D25F2070 k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
    '*****************************************

    Dim bIsUseBlock As Boolean

    Dim dtBlockID As DataTable
    Dim dtDepartmentID As DataTable
    Dim dtTeamID As DataTable
    Dim bPermissionD25F3090 As Boolean = False

    Private _dtGrid As DataTable
    Public Property dtGrid() As DataTable
        Get
            Return _dtGrid
        End Get
        Set(ByVal Value As DataTable)
            _dtGrid = Value
        End Set
    End Property

    Private _recruitmentFileID As String = ""
    Public Property RecruitmentFileID() As String 
        Get
            Return _recruitmentFileID
        End Get
        Set(ByVal Value As String )
            _recruitmentFileID = value
        End Set
    End Property

    Private _projectID As String = "" 'PARA_ID02
    Public WriteOnly Property ProjectID() As String
        Set(ByVal Value As String)
            _projectID = Value
        End Set
    End Property

    Private _savedOK As Boolean = False
    Public ReadOnly Property SavedOK() As Boolean
        Get
            Return _savedOK
        End Get
    End Property

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            bPermissionD25F3090 = (ReturnPermission("D25F3090") >= 2)
            bIsUseBlock = VisibleBlock()
            LoadTDBDropDown()
            LoadTDBCombo()

            Select Case _FormState

                Case EnumFormState.FormAdd
                    'dtGrid = ReturnDataTable(SQLStoreD25P1041(0))
                    c1dateVoucherDate.Value = Date.Now()
                    c1dateFrom.Value = Date.Now()
                    c1dateTo.Value = Date.Now()
                    btnNext.Enabled = False
                    ' GetTextCreateByNew(tdbcCreatorID)
                Case EnumFormState.FormEdit
                    ' dtGrid = ReturnDataTable(SQLStoreD25P1041(0))
                    LoadMaster()
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    If bPermissionD25F3090 Then btnRecruitmentCost.Enabled = True
                Case EnumFormState.FormView
                    ' dtGrid = ReturnDataTable(SQLStoreD25P1041(0))
                    LoadMaster()

                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False

            End Select
        End Set
    End Property

    Private Sub D25F1040_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If

        If e.Alt Then
            If e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1 Then
                tabMain.SelectedIndex = 0
            End If
            If e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2 Then
                tabMain.SelectedIndex = 1
            End If
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở, đóng UserControl
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowColumns_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            usrOption.Hide()
        End If
        '***************************************

    End Sub

    Private Sub D25F1040_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        If bLoadFormState = False Then FormState = _FormState
        Loadlanguage()
        SetBackColorObligatory()
        ResetFooterGrid(tdbg, SPLIT0, SPLIT0)
        ResetColorGrid(tdbgDetail, SPLIT0, SPLIT1)
        ResetSplitDividerSize(tdbg, tdbgDetail)

        LoadTDBGrid()
        GetTextCreateByNew(tdbcCreatorID, _FormState = EnumFormState.FormAdd)
        ' LoadData()
        'tdbg_LockedColumns()
        InputDateInTrueDBGrid(tdbg, COL_DateFrom, COL_DateTo, COL_InterviewDate, COL_DateJoined)

        InitiateD09U1111()
        tdbcCreatorID.AutoCompletion = False

        If _projectID <> "" Then LockColums(tdbg, 0, tdbg.Columns(COL_ProjectID).DataField) : tdbg.Columns(COL_ProjectID).DefaultValue = _projectID
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtVoucherNo)

        InputDateCustomFormat(c1dateTo, c1dateFrom, c1dateVoucherDate)
        InputDateInTrueDBGrid(tdbgDetail, COL1_Birthdate, COL1_ReceivedDate, COL1_Birthdate, COL1_ReceivedDate, COL1_Birthdate, COL1_ReceivedDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D25F1040_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtVoucherNo.Focus()
    End Sub

    Private Sub InitiateD09U1111()
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_BlockName, COL_DepartmentName, COL_Number, COL_DateFrom, COL_DateTo}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        '*****************************************
        'Chuẩn hóa D09U1111 B2: Khởi tạo UserControl    
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , , , gbUnicode)
        '*****************************************
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Lap_ke_hoach_tuyen_dungF") & " - D25F1040" & UnicodeCaption(gbUnicode) '("Lap_dot_tuyen_dung_-_D25F1040") & UnicodeCaption(gbUnicode)  'LËp ¢ít tuyÓn dóng - D25F1040
        '================================================================ 
        lblVoucherNo.Text = rl3("Ma") 'Mã
        lblRecruitmentFileName.Text = rl3("Dien_giai") 'Diễn giải
        lblteVoucherDate.Text = rl3("Ngay_lap") 'Ngày lập
        lblCreatorID.Text = rl3("Nguoi_lap") 'Người lập
        lblteFrom.Text = rl3("Ngay_tuyenU") 'Ngày tuyển
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnChooseRecruitment.Text = rl3("_Chon_de_xuat") '&Chọn đề xuất
        btnChooseCandidate.Text = rl3("Chon_ung__vien") 'Chọn ứng &viên
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnRecruitmentCost.Text = rl3("Chi__phi_TD")
        '================================================================ 
        TabPage1.Text = "1. " & rl3("Thong_tin_chung") 'Thông tin chung
        TabPage2.Text = "2. " & rl3("Chi_tiet") 'Chi tiết
        '================================================================ 
        tdbcCreatorID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcCreatorID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbdRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbdDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbdBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbdBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên

        tdbdProjectID.Columns("ProjectID").Caption = rl3("Ma") 'Mã
        tdbdProjectID.Columns("ProjectName").Caption = rl3("Ten") 'Tên

        tdbdSexName.Columns(0).Caption = rl3("Ma") 'Mã
        tdbdSexName.Columns(1).Caption = rl3("Ten") 'Tên
        tdbdEducationLevelName.Columns(0).Caption = rl3("Ma") 'Mã
        tdbdEducationLevelName.Columns(1).Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("BlockName").Caption = rl3("Khoi") 'Tên khối
        tdbg.Columns("DepartmentName").Caption = rl3("Phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamName").Caption = rl3("To_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionName").Caption = rl3("Vi_tri") 'Tên vị trí
        tdbg.Columns("Number").Caption = rl3("So_luong") 'Số lượng
        tdbg.Columns("DateFrom").Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns(COL_Sex).Caption = rl3("Gioi_tinh")
        tdbg.Columns(COL_ProjectID).Caption = rl3("Cong_trinh")
        tdbg.Columns(COL_EducationLevelID).Caption = rl3("Trinh_do_giao_duc_pho_thong")
        tdbg.Columns(COL_DateJoined).Caption = rl3("Ngay_bat_dau_cong_viec")
        tdbg.Columns(COL_InterviewDate).Caption = rl3("Ngay_phong_van")
        tdbg.Columns("NoteDetail").Caption = rl3("Ghi_chu") 'Ghi chú

        tdbgDetail.Columns("BlockID").Caption = rl3("Ma_khoi") 'Mã khối
        tdbgDetail.Columns("BlockName").Caption = rl3("Ten_khoi") 'Tên khối
        tdbgDetail.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbgDetail.Columns("DepartmentName").Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbgDetail.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbgDetail.Columns("TeamName").Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbgDetail.Columns("RecPositionID").Caption = rl3("Ma_vi_tri") 'Mã vị trí
        tdbgDetail.Columns("RecPositionName").Caption = rl3("Ten_vi_tri") 'Tên vị trí
        tdbgDetail.Columns("RecSourceName").Caption = rl3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        tdbgDetail.Columns("CandidateID").Caption = rl3("Ma_ung_vien") 'Mã ứng viên
        tdbgDetail.Columns("CandidateName").Caption = rl3("Ten_ung_vien") 'Tên ứng viên
        tdbgDetail.Columns("SexName").Caption = rl3("Gioi_tinh") 'Giới tính
        tdbgDetail.Columns("Birthdate").Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbgDetail.Columns("ReceivedDate").Caption = rl3("Ngay_nhan_HS") 'Ngày nhận HS
        tdbgDetail.Columns("ReceiverName").Caption = rl3("Nguoi_nhan_HS") 'Người nhận HS
        tdbgDetail.Columns("ReceivedPlace").Caption = rl3("Noi_nhan_HS") 'Nơi nhận HS
        tdbgDetail.Columns("DesiredSalary").Caption = rl3("Luong_yeu_cau") 'Lương yêu cầu
        tdbgDetail.Columns("CurrencyID").Caption = rl3("Loai_tien") 'Loại tiền
        tdbgDetail.Columns("SuggesterName").Caption = rl3("Nguoi_gioi_thieu") 'Người giới thiệu
    End Sub

    Private Sub SetBackColorObligatory()
        txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtRecruitmentFileName.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCreatorID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Number).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DateFrom).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DateTo).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function VisibleBlock() As Boolean
        If D25Systems.IsUseBlock = False Then
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockName).Visible = False

            tdbgDetail.Splits(SPLIT0).DisplayColumns.Item(COL1_BlockID).Visible = False
            tdbgDetail.Splits(SPLIT0).DisplayColumns.Item(COL1_BlockName).Visible = False

            Return False
        End If

        Return True
    End Function

    'Private Sub tdbg_LockedColumns()
    '    tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    '    tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    '    tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    '    tdbg.Splits(SPLIT0).DisplayColumns(COL_RecPositionName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    'End Sub

    Private Sub LoadTDBCombo()
        'LoadDataSource(tdbcCreatorID, ReturnTableEmployeeID(True, False, gbUnicode), gbUnicode)
        LoadCboCreateBy(tdbcCreatorID, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'sSQL = "Select BlockID, BlockName From D09T1140 Where Disabled =0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        'sSQL &= "Order by BlockID"
        LoadDataSource(tdbdBlockID, ReturnTableBlockID(, False, gbUnicode), gbUnicode)

        'Load tdbdDepartmentID
        'sSQL = "SELECT 	DepartmentID, DepartmentName, BlockID" & vbCrLf
        'sSQL &= "FROM D91T0012" & vbCrLf
        'sSQL &= "WHERE Disabled = 0" & vbCrLf
        'sSQL &= "AND DivisionID = " & SQLString(gsDivisionID)
        dtDepartmentID = ReturnTableDepartmentID(True, False, gbUnicode)

        'sSQL = "SELECT D01.TeamID, D01.TeamName, D01.DepartmentID, D02.BlockID" & vbCrLf
        'sSQL &= "FROM D09T0227 D01" & vbCrLf
        'sSQL &= "INNER JOIN D91T0012 D02 " & vbCrLf
        'sSQL &= "ON D02.DepartmentID = D01.DepartmentID" & vbCrLf
        'sSQL &= "WHERE D01.Disabled = 0" & vbCrLf
        'sSQL &= "AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        dtTeamID = ReturnTableTeamID(True, False, gbUnicode)

        'Load tdbdPositionID
        'sSQL = "SELECT RecPositionID, RecPositionName" & vbCrLf
        'sSQL &= "FROM D25T1020" & vbCrLf
        'sSQL &= "WHERE Disabled = 0"
        LoadDataSource(tdbdRecPositionID, ReturnTableDutyIDRec(False, gbUnicode), gbUnicode)


        sSQL = "--Combo Trinh do giao duc pho thong " & vbCrLf & _
            "SELECT 	EducationLevelID, EducationLevelName" & UnicodeJoin(gbUnicode) & " as EducationLevelName" & vbCrLf & _
            "FROM 	D09T0206 WITH(NOLOCK) " & vbCrLf & _
            "WHERE 	Disabled=0 " & vbCrLf & _
            "ORDER BY 	EducationLevelName"
        LoadDataSource(tdbdEducationLevelName, sSQL, gbUnicode)

        'sSQL = "-- Combo Gioi tinh" & vbCrLf & _
        '    "SELECT	0 AS Sex, " & vbCrLf & _
        '    "		CASE WHEN " & SQLNumber(gbUnicode) & " = 0 THEN 'Nam' ELSE N'Nam' END AS SexName" & vbCrLf & _
        '    "UNION" & vbCrLf & _
        '    "SELECT	1 AS Sex, " & vbCrLf & _
        '    "		CASE WHEN " & SQLNumber(gbUnicode) & " = 0 THEN 'Nöõ' ELSE N'Nữ' END AS SexName"
        'LoadDataSource(tdbdSexName, sSQL, gbUnicode)
        LoadtdbdSexName(tdbdSexName)
        sSQL = "-- Combo Du an" & vbCrLf & _
                "Select 	ProjectID, Description" & UnicodeJoin(gbUnicode) & " As ProjectName, 1 As DisplayOrder" & vbCrLf & _
                "From 	D09T1080  WITH(NOLOCK) " & vbCrLf & _
                "Where Disabled = 0" & vbCrLf & _
                "Order by 	DisplayOrder, ProjectName"
        LoadDataSource(tdbdProjectID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTdbdDepartmentID()
        If Not bIsUseBlock Then
            LoadDataSource(tdbdDepartmentID, dtDepartmentID.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbdDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID =  " & SQLString(tdbg(tdbg.Row, COL_BlockID).ToString)), gbUnicode)
        End If
    End Sub

    Public Sub LoadtdbdTeamID()
        If Not bIsUseBlock Then
            LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID, "DepartmentID = " & SQLString(tdbg(tdbg.Row, COL_DepartmentID).ToString)), gbUnicode)
        Else
            LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID, "DepartmentID = " & SQLString(tdbg(tdbg.Row, COL_DepartmentID).ToString) & " And BlockID = " & SQLString(tdbg(tdbg.Row, COL_BlockID).ToString)), gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal iMode As Integer = 0)
        dtGrid = ReturnDataTable(SQLStoreD25P1041(iMode))
        LoadDataSource(tdbg, dtGrid, gbUnicode)
    End Sub

    Private Sub LoadMaster()
        Dim dtMaster As DataTable = ReturnDataTable(SQLStoreD25P1041(1))
        If dtMaster.Rows.Count > 0 Then
            With dtMaster.Rows(0)
                txtVoucherNo.Text = .Item("VoucherNo").ToString
                txtRecruitmentFileName.Text = .Item("RecruitmentFileName").ToString
                c1dateVoucherDate.Value = SQLDateShow(.Item("VoucherDate").ToString)
                tdbcCreatorID.SelectedValue = .Item("CreatorID")
                GetTextCreateByNew(tdbcCreatorID, False)
                c1dateFrom.Value = SQLDateShow(.Item("FromDate").ToString)
                c1dateTo.Value = SQLDateShow(.Item("ToDate").ToString)
                txtNote.Text = .Item("Note").ToString
            End With

            LoadDataSource(tdbgDetail, dtMaster, gbUnicode)
            FooterTotalGrid(tdbgDetail, COL1_CandidateID)
        End If

        ReadOnlyControl(txtVoucherNo)
    End Sub

    'Incident: 51165 sửa theo mail chị Thảo Tại tab chi tiết: Dòng tổng cộng: chỉ đếm những dòng có CaididateID <> rỗng.
    Private Sub FooterTotalGrid(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iColumnName As Integer)
        Dim iRow As Integer = CType(tdbg.DataSource, DataTable).Select("CandidateID <> ''").Length
        tdbg.Columns(iColumnName).FooterText = rl3("Tong_cong") & Space(1) & "(" & iRow & ")"
    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        If bLoadD25F1040 Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadD25F1040 = False
        End If

        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnChooseCandidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseCandidate.Click
        '************************
        If Not bLoadD25F1040 Then vcNewTemp = vcNew
        bLoadD25F1040 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Dim f As New D25F5600
        With f
            .FormID = "D25F1040"
            .VoucherID = _recruitmentFileID
            .ShowDialog()
            If f.DataTableGrid IsNot Nothing Then
                If .DataTableGrid.Rows.Count > 0 Then
                    LoadDataSource(tdbgDetail, .DataTableGrid, gbUnicode)
                    FooterTotalGrid(tdbgDetail, COL1_CandidateID)
                End If
            End If
            .Dispose()
        End With

        'InitiateD09U1111()
    End Sub

    Private Sub btnChooseRecruitment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseRecruitment.Click
        '************************
        If Not bLoadD25F1040 Then vcNewTemp = vcNew
        bLoadD25F1040 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Dim f As New D25F2020
        With f
            .FormID = "D25F1040"
            .VoucherID = _recruitmentFileID
            .RecDateFrom = c1dateFrom.Text
            .RecDateTo = c1dateTo.Text
            .ShowDialog()
            If .Chose Then LoadTDBGrid(2)
            'If .DataTableGrid IsNot Nothing Then
            '    If .DataTableGrid.Rows.Count > 0 Then
            '        LoadDataSource(tdbg, .DataTableGrid, gbUnicode)
            '    End If
            'End If
            .Dispose()
        End With

        'InitiateD09U1111()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        tdbg.Delete(0, tdbg.RowCount)
        tdbgDetail.Delete(0, tdbgDetail.RowCount)

        txtVoucherNo.Text = ""
        txtRecruitmentFileName.Text = ""
        c1dateVoucherDate.Value = Date.Now()
        tdbcCreatorID.SelectedValue = gsCreateBy

        c1dateFrom.Value = Date.Now()
        c1dateTo.Value = Date.Now()
        txtNote.Text = ""
        btnRecruitmentCost.Enabled = False
        _recruitmentFileID = ""

        btnNext.Enabled = False
        btnSave.Enabled = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg.UpdateData()
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        Select Case _FormState

            Case EnumFormState.FormAdd
                _recruitmentFileID = CreateIGE("D25T1042", "RecruitmentFileID", "25", "RF", gsStringKey)

                sSQL.Append(SQLInsertD25T2040s().ToString() & vbCrLf)
                sSQL.Append(SQLInsertD25T1042s.ToString() & vbCrLf)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLDeleteD25T2040().ToString() & vbCrLf)
                sSQL.Append(SQLDeleteD25T1042().ToString() & vbCrLf)
                sSQL.Append(SQLInsertD25T2040s().ToString() & vbCrLf)
                sSQL.Append(SQLInsertD25T1042s.ToString() & vbCrLf)

        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _savedOK = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    If bPermissionD25F3090 Then btnRecruitmentCost.Enabled = True
                    btnNext.Enabled = True
                    btnNext.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        'If txtVoucherNo.Text.Trim = "" Then
        '    D99C0008.MsgNotYetEnter(rl3("Ma"))
        '    tabMain.SelectedIndex = 0
        '    txtVoucherNo.Focus()
        '    Return False
        'End If

        'If _FormState = EnumFormState.FormAdd Then
        '    If ExistRecord("SELECT TOP 1 1 FROM D25T1042 WITH(NOLOCK)  WHERE VoucherNo = " & SQLString(txtVoucherNo.Text)) Then
        '        D99C0008.MsgDuplicatePKey()
        '        tabMain.SelectedIndex = 0
        '        txtVoucherNo.Focus()
        '        Return False
        '    End If
        'End If

        If txtRecruitmentFileName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            tabMain.SelectedIndex = 0
            txtRecruitmentFileName.Focus()
            Return False
        End If
        If c1dateVoucherDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_lap"))
            tabMain.SelectedIndex = 0
            c1dateVoucherDate.Focus()
            Return False
        End If
        If tdbcCreatorID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nguoi_lap"))
            tabMain.SelectedIndex = 0
            tdbcCreatorID.Focus()
            Return False
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tabMain.SelectedIndex = 0
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1

            If tdbg(i, COL_BlockName).ToString = "" And bIsUseBlock Then
                D99C0008.MsgNotYetEnter(rl3("Khoi"))
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_BlockName
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_DepartmentName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Phong_ban"))
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DepartmentName
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_Number).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("So_luong"))
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_Number
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_DateFrom).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Tu_ngay"))
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DateFrom
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_DateTo).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Den_ngay"))
                tabMain.SelectedIndex = 0
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DateTo
                tdbg.Bookmark = i
                Return False
            End If

        Next
        'IncidentID	51165   	Bỏ việc ràng buộc bắt buộc nhập lưới tại Tab 2.Chi tiết    BỎ XONG BỊ LỔI NÊN TẠM THỜI CHƯA LÀM
        '        If tdbgDetail.RowCount <= 0 Then
        '            D99C0008.MsgNotYetChoose(rl3("Ung_vien"))
        '            tabMain.SelectedIndex = 1
        '            btnChooseCandidate.Focus()
        '            Return False
        '        End If

        Return True
    End Function

#Region "Combo Events"

#Region "Events tdbcCreatorID"

    Private Sub tdbcCreatorID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.Close
        tdbcCreatorID_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcCreatorID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.LostFocus
        If tdbcCreatorID.FindStringExact(tdbcCreatorID.Text) = -1 Then tdbcCreatorID.Text = ""
    End Sub

#End Region

    'Private Sub tdbcXX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcCreatorID.KeyDown
    '    Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
    '    Select Case e.KeyCode
    '        Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
    '            tdbc.AutoCompletion = False

    '        Case Else
    '            tdbc.AutoCompletion = True
    '    End Select
    'End Sub

#End Region

#Region "Grid Events"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        If tdbg.Columns(COL_TransID).Text = "" Then tdbg.Columns(COL_TransID).Text = ""

        Select Case e.ColIndex
            Case COL_BlockName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_BlockID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_BlockID).Text = tdbdBlockID.Columns("BlockID").Text
                tdbg.Columns(COL_DepartmentID).Text = ""
                tdbg.Columns(COL_DepartmentName).Text = ""
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""

            Case COL_DepartmentName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_DepartmentID).Text = tdbdDepartmentID.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""

            Case COL_TeamName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_TeamID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns("TeamID").Text

            Case COL_RecPositionName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_RecPositionID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_RecPositionID).Text = tdbdRecPositionID.Columns("RecPositionID").Text

            Case COL_DateFrom, COL_DateTo, COL_InterviewDate, COL_DateJoined
                tdbg.Select()

            Case COL_Sex
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
             
            Case COL_EducationLevelID, COL_ProjectID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
        End Select
        
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_Number
                If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Int) Then e.Cancel = True
            Case COL_BlockName, COL_DepartmentName, COL_TeamName, COL_RecPositionName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
            Case COL_Sex, COL_EducationLevelID, COL_ProjectID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                Select Case tdbg.Col
                    Case COL_BlockName
                        F7More(tdbg, COL_BlockID)

                    Case COL_DepartmentName
                        F7More(tdbg, COL_DepartmentID)

                    Case COL_TeamName
                        F7More(tdbg, COL_TeamID)

                    Case COL_RecPositionName
                        F7More(tdbg, COL_RecPositionID)
                    Case Else
                        HotKeyF7(tdbg)
                End Select
            Case Keys.F8
                If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                    HotKeyF8(tdbg)
                    tdbg.Columns(COL_TransID).Text = ""
                Else
                    D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

            Case Else

        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_Number
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        '--- Đổ nguồn cho các Dropdown phụ thuộc
        Select Case tdbg.Col
            Case COL_DepartmentName
                LoadTdbdDepartmentID()
            Case COL_TeamName
                LoadtdbdTeamID()
        End Select
    End Sub


#End Region

#Region "SQL, Store"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1041
    '# Created User: DUCTRONG
    '# Created Date: 11/06/2010 08:27:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1041(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P1041 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_recruitmentFileID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("D25F1040") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA
        sSQL &= SQLString(My.Computer.Name)
        sSQL &= COMMA & SQLString(gsLanguage)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2040s
    '# Created User: DUCTRONG
    '# Created Date: 11/06/2010 11:56:53
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2040s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sTranID As String = ""
        Dim iCountIGE As Int32 = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                sTranID = CreateIGEs("D25T2040", "TransID", "25", "RF", gsStringKey, sTranID, iCountIGE)
                tdbg(i, COL_TransID) = sTranID
            End If

            sSQL.Append("Insert Into D25T2040(")
            sSQL.Append("DivisionID, VoucherID, TransTypeID, TransID, BlockID, DepartmentID, ")
            sSQL.Append("TeamID, RecpositionID, Quantity, FromDate, ToDate, EducationLevelID, InterviewDate, DateJoined, Sex, ProjectID, ")
            sSQL.Append("Notes, NotesU")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'VoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_recruitmentFileID) & COMMA) 'VoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString("RF") & COMMA) 'TransTypeID, varchar[20], NOT NULL
			sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BlockID)) & COMMA) 'BlockID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RecPositionID)) & COMMA) 'RecpositionID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_Number)) & COMMA) 'Quantity, int, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateFrom)) & COMMA) 'FromDate, datetime, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateTo)) & COMMA) 'ToDate, datetime, NOT NULL

            sSQL.Append(SQLString(tdbg(i, COL_EducationLevelID)) & COMMA) 'EducationLevelID, varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_InterviewDate)) & COMMA) 'InterviewDate, datetime, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateJoined)) & COMMA) 'DateJoined, datetime, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Sex)) & COMMA) 'Sex, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ProjectID)) & COMMA) 'ProjectID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_NoteDetail), gbUnicode, False) & COMMA) 'Notes, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_NoteDetail), gbUnicode, True)) 'NotesU, nvarchar, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1042s
    '# Created User: DUCTRONG
    '# Created Date: 11/06/2010 11:57:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1042s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        '-	Nếu trên lưới Chi tiết tồn tại dòng dữ liệu: Lưu như cũ.
        '-	Nếu trên lưới Chi tiết không tồn tại dòng dữ liệu: Lưu 1 dòng dữ liệu vào bảng D25T1042 như cũ với CandidateID bằng rỗng.
        For i As Integer = 0 To tdbgDetail.RowCount - 1
            sSQL.Append("Insert Into D25T1042(")
            sSQL.Append("DivisionID, RecruitmentFileID, CandidateID, ")
            sSQL.Append("CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, ")
            sSQL.Append("TranMonth, TranYear, RecruitmentFileName, RecruitmentFileNameU, ")
            sSQL.Append("FromDate, ToDate,  CreatorID, Note, NoteU, VoucherDate") 'VoucherNo,

            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_recruitmentFileID) & COMMA) 'RecruitmentFileID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgDetail(i, COL1_CandidateID)) & COMMA) 'CandidateID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
            sSQL.Append(SQLStringUnicode(txtRecruitmentFileName.Text, gbUnicode, False) & COMMA) 'RecruitmentFileName, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(txtRecruitmentFileName.Text, gbUnicode, True) & COMMA) 'RecruitmentFileNameU, nvarchar, NOT NULL
            sSQL.Append(SQLDateSave(c1dateFrom.Text) & COMMA) 'FromDate, datetime, NULL
            sSQL.Append(SQLDateSave(c1dateTo.Text) & COMMA) 'ToDate, datetime, NULL
            'sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[50], NOT NULL
            sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCreatorID)) & COMMA) 'CreatorID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'Note, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'NoteU, nvarchar, NOT NULL
            sSQL.Append(SQLDateSave(c1dateVoucherDate.Text)) 'VoucherDate, datetime, NOT NULL

            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next


        If sRet.ToString = "" Then
            sSQL.Append("Insert Into D25T1042(")
            sSQL.Append("DivisionID, RecruitmentFileID, CandidateID, ")
            sSQL.Append("CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, ")
            sSQL.Append("TranMonth, TranYear, RecruitmentFileName, RecruitmentFileNameU, ")
            sSQL.Append("FromDate, ToDate, VoucherNo, CreatorID, Note, NoteU, VoucherDate")

            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_recruitmentFileID) & COMMA) 'RecruitmentFileID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'CandidateID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
            sSQL.Append(SQLStringUnicode(txtRecruitmentFileName.Text, gbUnicode, False) & COMMA) 'RecruitmentFileName, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(txtRecruitmentFileName.Text, gbUnicode, True) & COMMA) 'RecruitmentFileNameU, nvarchar, NOT NULL
            sSQL.Append(SQLDateSave(c1dateFrom.Text) & COMMA) 'FromDate, datetime, NULL
            sSQL.Append(SQLDateSave(c1dateTo.Text) & COMMA) 'ToDate, datetime, NULL
            sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[50], NOT NULL
            sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCreatorID)) & COMMA) 'CreatorID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'Note, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'NoteU, nvarchar, NOT NULL
            sSQL.Append(SQLDateSave(c1dateVoucherDate.Text)) 'VoucherDate, datetime, NOT NULL

            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        End If
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T1042
    '# Created User: DUCTRONG
    '# Created Date: 11/06/2010 04:03:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T1042() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T1042"
        sSQL &= " Where "
        sSQL &= "RecruitmentFileID = " & SQLString(_recruitmentFileID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2040
    '# Created User: DUCTRONG
    '# Created Date: 11/06/2010 04:04:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2040() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2040"
        sSQL &= " Where "
        sSQL &= "VoucherID = " & SQLString(_recruitmentFileID)
        Return sSQL
    End Function


#End Region

    Private Sub tdbcCreatorID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub btnRecruitmentCost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecruitmentCost.Click
        'Dim bExe As Boolean = ExecuteSQLNoTransaction(SQLInsertD09T6666().ToString)
        'If bExe Then
        Dim frm As New D25F2090
        frm.bCallD25F2000 = False
        frm.RecruitmentFileID = _recruitmentFileID
        frm.FormState = EnumFormState.FormAdd
        frm.ShowDialog()
        frm.Dispose()
        'End If
    End Sub

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLInsertD09T6666
    ''# Created User: Thanh Huyền
    ''# Created Date: 28/02/2011
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: Bổ sung Chi phí tuyển dụng
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLInsertD09T6666() As StringBuilder
    '    Dim sSQL As New StringBuilder
    '    For i As Integer = 0 To tdbg.RowCount - 1
    '        sSQL.Append("Insert Into D09T6666(")
    '        sSQL.Append("UserID, HostID, Key01ID")
    '        sSQL.Append(") Values(")
    '        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(tdbg(i, COL_TransID))) 'Key01ID, varchar[250], NOT NULL
    '        sSQL.Append(")")
    '    Next
    '    Return sSQL
    'End Function
End Class