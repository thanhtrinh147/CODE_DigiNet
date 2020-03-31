Imports System
Public Class D25F2000

#Region "Const of tdbg - Total of Columns: 41"
    Private Const COL_TransID As Integer = 0           ' TransID
    Private Const COL_PlanTransID As Integer = 1       ' PlanTransID
    Private Const COL_ProApproved As Integer = 2       ' Duyệt
    Private Const COL_BlockID As Integer = 3           ' BlockID
    Private Const COL_BlockName As Integer = 4         ' Khối
    Private Const COL_DepartmentID As Integer = 5      ' DepartmentID
    Private Const COL_DepartmentName As Integer = 6    ' Phòng ban
    Private Const COL_TeamID As Integer = 7            ' TeamID
    Private Const COL_TeamName As Integer = 8          ' Tổ nhóm
    Private Const COL_RecPositionName As Integer = 9   ' Vị trí
    Private Const COL_RecPositionID As Integer = 10    ' RecPositionID
    Private Const COL_WorkID As Integer = 11           ' Công việc
    Private Const COL_ApproverID As Integer = 12       ' Người duyệt
    Private Const COL_EmployeeQTY As Integer = 13      ' Định mức
    Private Const COL_ProNumber As Integer = 14        ' Số lượng
    Private Const COL_DateFrom As Integer = 15         ' Từ ngày
    Private Const COL_DateTo As Integer = 16           ' Đến ngày
    Private Const COL_VoucherDate As Integer = 17      ' Ngày lập
    Private Const COL_RecruitmentType As Integer = 18  ' Loại tuyển
    Private Const COL_CreatorID As Integer = 19        ' Người lập
    Private Const COL_Sex As Integer = 20              ' Giới tính
    Private Const COL_EducationLevelID As Integer = 21 ' Trình độ giáo dục phổ thông 
    Private Const COL_InterviewDate As Integer = 22    ' Ngày phỏng vấn
    Private Const COL_DateJoined As Integer = 23       ' Ngày bắt đầu công việc
    Private Const COL_Description As Integer = 24      ' Diễn giải
    Private Const COL_ReferenceNo As Integer = 25      ' Số tham chiếu
    Private Const COL_Ref01 As Integer = 26            ' Ref01
    Private Const COL_Ref02 As Integer = 27            ' Ref02
    Private Const COL_Ref03 As Integer = 28            ' Ref03
    Private Const COL_Ref04 As Integer = 29            ' Ref04
    Private Const COL_Ref05 As Integer = 30            ' Ref05
    Private Const COL_Ref06 As Integer = 31            ' Ref06
    Private Const COL_Ref07 As Integer = 32            ' Ref07
    Private Const COL_Ref08 As Integer = 33            ' Ref08
    Private Const COL_Ref09 As Integer = 34            ' Ref09
    Private Const COL_Ref10 As Integer = 35            ' Ref10
    Private Const COL_ProNote As Integer = 36          ' Ghi chú
    Private Const COL_CreatorName As Integer = 37      ' CreatorName
    Private Const COL_StatusComplete As Integer = 38   ' Kết thúc nhận CV
    Private Const COL_IsDependPlan As Integer = 39     ' Theo kế hoạch
    Private Const COL_LinkTransID As Integer = 40      ' LinkTransID
#End Region


    Private _formIDPermission As String = "D25F2000"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

    Private _isMSS As Integer = 1
    Public WriteOnly Property IsMSS() As Integer
        Set(ByVal Value As Integer)
            _isMSS = Value
        End Set
    End Property

    Private _savedOK As Boolean = False
    Public ReadOnly Property SavedOK() As Boolean
        Get
            Return _savedOK
        End Get
    End Property

    Private _isLock As Boolean = False
    Public WriteOnly Property IsLock() As Boolean 
        Set(ByVal Value As Boolean )
            _isLock = Value
        End Set
    End Property

    Dim bIsUseBlock As Boolean
    'Private usrOption2000 As D09U1111

    Dim dtEmployeeQTYDepartment As DataTable
    Dim dtEmployeeQTYTeam As DataTable
    Dim dtEmployeeQTYDuty As DataTable
    Dim dtEmployeeQTY As DataTable

    Dim bLoadFormState As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShow, btnRecruitmentCost, btnRecruitmentPlan)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnSave, btnNext, btnPrint, btnClose)

    End Sub
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            bIsUseBlock = VisibleBlock()
            LoadTDBDropDown()

            'ID 98615 20.09.2017
            tdbg.Splits(2).DisplayColumns(COL_StatusComplete).Visible = Not _FormState = EnumFormState.FormAdd
            Select Case _FormState

                Case EnumFormState.FormAdd
                    ' truong hop goi tu D25E0000
                    Dim sSQL As String = ""
                    sSQL = SQLStoreD25P3001()
                    dtGrid = ReturnTableFilter(ReturnDataTable(sSQL), "TransID = " & SQLString(""), True)
                    btnNext.Enabled = False
                    btnPrint.Enabled = False
                Case EnumFormState.FormEdit, EnumFormState.FormCopy
                    btnRecruitmentCost.Enabled = True
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    tdbg.AllowAddNew = False
                    btnRecruitmentPlan.Enabled = False
                    EnableFectStyle()
                Case EnumFormState.FormOther
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False

                Case EnumFormState.FormView
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False

            End Select
        End Set
    End Property

    Private _dtGrid As DataTable
    Public Property dtGrid() As DataTable
        Get
            Return _dtGrid
        End Get
        Set(ByVal Value As DataTable)
            _dtGrid = Value
        End Set
    End Property

    Private _transID As String = ""
    Public Property TransID() As String
        Get
            Return _transID
        End Get
        Set(ByVal Value As String)
            _transID = Value
        End Set
    End Property

    Private Sub D25F2000_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
        ExecuteSQLNoTransaction("DELETE D09T6666 WHERE UserID = " & SQLString(gsUserID) & " AND HostID = " & SQLString(My.Computer.Name) & " AND FormID = 'D25F3180'")
    End Sub

    Private Sub D25F2080_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Hỏi trước khi đóng 
        If _FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormOther Then
            If Not _savedOK Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If btnSave.Enabled Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        End If
    End Sub

    Private Sub D25F2080_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            'UseEnterAsTab(Me)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If


        '***************************************
        'Chuẩn hóa D09U1111 B4: mở, đóng UserControl
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShow_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            ' usrOption2000.Hide()
            usrOption.picClose_Click(Nothing, Nothing)
        End If
        '***************************************
    End Sub

    Private Sub EnableFectStyle()
        If _formIDPermission <> "D25F3000" OrElse _FormState <> EnumFormState.FormEdit Then Exit Sub
        'Nếu gọi từ D25F3000 từ bậc FetchStyle tất cả các cột trừ cột Từ ngày - Đến ngày
        For iSplit As Integer = 0 To tdbg.Splits.Count - 1
            For iCol As Integer = 0 To tdbg.Columns.Count - 1
                If iCol = COL_DateTo OrElse iCol = COL_DateFrom OrElse iCol = COL_ProApproved Then Continue For
                tdbg.Splits(iSplit).DisplayColumns(iCol).FetchStyle = True
            Next
        Next
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT2).DisplayColumns(COL_IsDependPlan).Locked = True
        tdbg.Splits(SPLIT2).DisplayColumns(COL_IsDependPlan).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_EmployeeQTY).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        LockColums(IsUseAppRecruitProposal() OrElse ReturnPermission("D25F2020") < EnumPermission.Add, tdbg, 0, tdbg.Columns(COL_ProApproved).DataField)
        LockColums(tdbg.Splits(0).DisplayColumns(COL_ProApproved).Locked, tdbg, tdbg.Splits.Count - 1, tdbg.Columns(COL_ApproverID).DataField)
    End Sub

    Private Function VisibleBlock() As Boolean
        'Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        'If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
        If D25Systems.IsUseBlock = False Then
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_BlockName).Visible = False
            Return False
        End If
        Return True
    End Function

    Private Sub D25F2080_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If bLoadFormState = False Then FormState = _FormState
        SetBackColorObligatory()
        Loadlanguage()
        'CheckIdTDBGrid(tdbg, COL_ReferenceNo, False) 'ID 76914 17/07/2015
        LoadTDBGrid()

        If _FormState = EnumFormState.FormOther Then
            iOldNumber = Number(tdbg(0, COL_ProNumber))
        End If

        tdbg_LockedColumns()
        LoadRefCaption()
        InputDateInTrueDBGrid(tdbg, COL_DateFrom, COL_DateTo, COL_VoucherDate, COL_DateJoined, COL_InterviewDate)

        ResetFooterGrid(tdbg, SPLIT0, SPLIT2)
        GetTextCreateByNew(tdbg, COL_CreatorID, 2)
        'InitiateD09U1111()
        CallD99U1111()
        SetResolutionForm(Me)
    End Sub

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable
    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL_ProApproved, COL_BlockName, COL_DepartmentName, COL_ProNumber, COL_DateFrom, COL_DateTo, COL_VoucherDate}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbg.Splits(1).DisplayColumns(COL_BlockName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(1).DisplayColumns(COL_DepartmentName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(2).DisplayColumns(COL_ProNumber).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(2).DisplayColumns(COL_DateFrom).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(2).DisplayColumns(COL_DateTo).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(2).DisplayColumns(COL_VoucherDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("De_xuat_tuyen_dung_-_D25F2000") & UnicodeCaption(gbUnicode) '˜Ò xuÊt tuyÓn dóng - D25F2000
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnShow.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnPrint.Text = rl3("_In") '&In
        btnRecruitmentPlan.Text = "&" & rl3("Chon_ke_hoach_tong_the") ' rl3("Chon__ke_hoach_tuyen_dung") 'Chọn &kế hoạch tuyển dụng
        btnRecruitmentCost.Text = rl3("Chi__phi_TD")
        '================================================================ 
        tdbdRecPositionID.Columns("PositionID").Caption = rl3("Ma") 'Mã
        tdbdRecPositionID.Columns("PositionName").Caption = rl3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên

        tdbdDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên

        tdbdBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbdBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbdSexName.Columns(0).Caption = rl3("Ma") 'Mã
        tdbdSexName.Columns(1).Caption = rL3("Ten") 'Tên
        tdbcRecruitmentType.Columns(0).Caption = rL3("Ma") 'Mã
        tdbcRecruitmentType.Columns(1).Caption = rL3("Ten") 'Tên
        tdbdEducationLevelName.Columns(0).Caption = rl3("Ma") 'Mã
        tdbdEducationLevelName.Columns(1).Caption = rL3("Ten") 'Tên
        tdbdWorkID.Columns("WorkID").Caption = rL3("Ma") 'Mã
        tdbdWorkID.Columns("WorkName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("ProApproved").Caption = rl3("Duyet") 'Duyệt
        tdbg.Columns("BlockName").Caption = rl3("Khoi") 'Khối
        tdbg.Columns("DepartmentName").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamName").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("RecPositionName").Caption = rl3("Vi_tri") 'Vị trí
        tdbg.Columns("EmployeeQTY").Caption = rl3("Dinh_muc") 'Định mức
        tdbg.Columns("ProNumber").Caption = rl3("So_luong") 'Số lượng
        tdbg.Columns("DateFrom").Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_lap") 'Ngày lập
        tdbg.Columns("ProNote").Caption = rl3("Ghi_chu") 'Ghi chú
        tdbg.Columns("CreatorID").Caption = rl3("Nguoi_lap")
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("IsDependPlan").Caption = rl3("Theo_ke_hoach") 'Theo kế hoạch
        tdbg.Columns("ReferenceNo").Caption = rl3("So_tham_chieu")
        tdbg.Columns(COL_Sex).Caption = rl3("Gioi_tinh")
        tdbg.Columns(COL_EducationLevelID).Caption = rL3("Trinh_do_giao_duc_pho_thong")
        tdbg.Columns(COL_InterviewDate).Caption = rl3("Ngay_phong_van")
        tdbg.Columns(COL_DateJoined).Caption = rL3("Ngay_bat_dau_cong_viec")
        tdbg.Columns(COL_RecruitmentType).Caption = rL3("Loai_tuyen")
        tdbg.Columns(COL_ApproverID).Caption = rL3("Nguoi_duyet")
        tdbg.Columns(COL_WorkID).Caption = rL3("Cong_viec") 'Công việc
        tdbg.Columns(COL_StatusComplete).Caption = rL3("Ket_thuc_nhan_CV") 'Kết thúc nhận CV
    End Sub
    Private Sub LoadTDBGrid()
        ' AddColumnsIsLock() ' Bổ sung cột IsLock = ProApproved, để chạy FecthCellStyle
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_DepartmentName)
        FooterSumNew(tdbg, COL_ProNumber, COL_EmployeeQTY)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        tdbg.Delete(0, tdbg.RowCount)
        btnPrint.Enabled = False
        btnNext.Enabled = False
        btnSave.Enabled = True
        btnRecruitmentCost.Enabled = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub

        tdbg.Update()
        tdbg.UpdateData()
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        Select Case _FormState

            Case EnumFormState.FormAdd, EnumFormState.FormCopy
                sSQL.Append(SQLInsertD25T2001s().ToString)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T2001s().ToString)

            Case EnumFormState.FormOther
                If Number(tdbg(0, COL_ProNumber)) = 0 Then
                    sSQL.Append("Delete D25T2001 where TransID = " & SQLString(tdbg(0, COL_TransID)))
                Else
                    sSQL.Append(SQLUpdateD25T2001s().ToString)
                End If
                sSQL.Append(SQLInsertD25T2001s().ToString)

        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _savedOK = True
            btnClose.Enabled = True
            SplitData() 'Bổ sung thực thi store Rã dữ liệu theo quy trình duyệt nhiều cấp vào bảng D84T2000
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnPrint.Enabled = True
                    btnRecruitmentCost.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
                Case EnumFormState.FormOther
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD84P2020
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 10/06/2014 03:29:49
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD84P2020() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Ra User va Ra dia chi Mail khi duyet" & vbCrlf)
        sSQL &= "Exec D84P2020 "
        sSQL &= SQLString(gsCompanyID) & COMMA 'CompanyID, varchar[50], NOT NULL
        sSQL &= SQLString("G4") & COMMA 'ModuleGroup, varchar[10], NOT NULL
        sSQL &= SQLString(D25) & COMMA 'ModuleID, varchar[10], NOT NULL
        sSQL &= SQLString("T0001") & COMMA 'TransTypeID, varchar[50], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLNumber(IIf(_FormState = EnumFormState.FormAdd, 0, 2)) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(100) & COMMA 'StatusApproval, tinyint, NOT NULL
        sSQL &= SQLNumber(0) 'ApprovalLevel, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Dim sSQL As String = ""
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_BlockName).ToString = "" And bIsUseBlock Then
                D99C0008.MsgNotYetEnter(rl3("Khoi"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_BlockName
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_DepartmentName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Phong_ban"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_DepartmentName
                tdbg.Bookmark = i
                Return False
            End If
            If _FormState = EnumFormState.FormAdd Or (_FormState = EnumFormState.FormOther And i > 0) Then
                If tdbg(i, COL_ReferenceNo).ToString <> "" Then
                    sSQL = "Select top 1 1 from D25T2001 WITH(NOLOCK)  where ReferenceNo = " & SQLString(tdbg(i, COL_ReferenceNo).ToString)
                    Dim dtTemp As DataTable = ReturnDataTable(sSQL)
                    If dtTemp.Rows.Count > 0 Then
                        D99C0008.MsgL3(rl3("So_tham_chieu_nay_da_duoc_su_dung") & " " & rl3("Ban_khong_duoc_phep_luu"))
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT2
                        tdbg.Col = COL_ReferenceNo
                        tdbg.Bookmark = i
                        tdbg.Columns(COL_ReferenceNo).Editor.Focus()
                        Return False
                    End If
                End If
            End If
            If tdbg(i, COL_ProNumber).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("So_luong"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_ProNumber
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_DateFrom).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Tu_ngay"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_DateFrom
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_DateTo).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Den_ngay"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_DateTo
                tdbg.Bookmark = i
                Return False
            End If
            If CDate(tdbg(i, COL_DateFrom)) > CDate(tdbg(i, COL_DateTo)) Then
                D99C0008.MsgL3(rL3("MSG000013"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_DateTo
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_VoucherDate).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay_lap"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_VoucherDate
                tdbg.Bookmark = i
                Return False
            End If
        Next
        '****************************
        'ID 88879 20/07/2016
        sSQL = SQLDeleteD09T6666() & vbCrLf
        sSQL &= SQLInsertD09T6666s.ToString() & vbCrLf
        sSQL &= SQLStoreD25P5555()
        If CheckStore(sSQL) = False Then Return False
        '****************************
        Return True
    End Function

    Private Sub LoadRefCaption()
        Dim sSQL As String = ""
        Dim dtSpec As New DataTable

        sSQL = SQLStoreD25P0050("D25T2001", gbUnicode)
        dtSpec = ReturnDataTable(sSQL)

        If dtSpec.Rows.Count <= 0 Then Exit Sub

        For i As Integer = 0 To 9
            tdbg.Splits(SPLIT2).DisplayColumns(COL_Ref01 + i).Visible = Not CBool(dtSpec.Rows(i).Item("Disabled").ToString)
            tdbg.Splits(SPLIT2).DisplayColumns(COL_Ref01 + i).HeadingStyle.Font = FontUnicode(gbUnicode, tdbg.Splits(SPLIT2).DisplayColumns(COL_Ref01 + i).HeadingStyle.Font.Style) ' New Font("Lemon3", 8.249999)
            tdbg.Columns(COL_Ref01 + i).Caption = dtSpec.Rows(i).Item("RefCaption").ToString
        Next

    End Sub

#Region "Tdbg"

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        If _FormState = EnumFormState.FormOther Then
            Select Case e.ColIndex
                Case COL_BlockName, COL_DepartmentName, COL_TeamName, COL_RecPositionName, COL_ProNumber, COL_DateFrom, COL_DateTo, COL_VoucherDate, COL_ProNote, COL_Ref01, COL_Ref02, COL_Ref03, COL_Ref04, COL_Ref05, COL_Ref06, COL_Ref07, COL_Ref08, COL_Ref09, COL_Ref10
                    If tdbg.Row = 0 Then
                        e.Cancel = True
                    End If

            End Select
        End If
        If e.ColIndex = COL_ApproverID Then
            If L3Bool(tdbg.Columns(COL_ProApproved).Text) = False Then e.Cancel = True
        End If
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub


    Dim bNotInList As Boolean = False
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_EmployeeQTY, COL_ProNumber
                If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Int) Then e.Cancel = True

            Case COL_BlockName, COL_DepartmentName, COL_TeamName, COL_RecPositionName, COL_RecruitmentType
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If

            Case COL_CreatorID, COL_Sex, COL_EducationLevelID, COL_ApproverID, COL_WorkID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If

            Case COL_ProNumber
                If Not L3IsNumeric(tdbg.Columns(COL_ProNumber).Text, EnumDataType.Int) Then e.Cancel = True
                If tdbg.Row = 0 And _FormState = EnumFormState.FormOther Then Exit Sub

                If CheckOverQuantity() Then e.Cancel = True
            Case COL_ReferenceNo
                e.Cancel = L3IsID(tdbg, e.ColIndex)
        End Select
    End Sub

    Dim iOldNumber As Double = 0
    Dim dRemainQty As Double = -1

    Private Function CheckOverQuantity() As Boolean
        If _FormState <> EnumFormState.FormOther Then Return False

        Dim iNumber As Double = 0
        For i As Integer = 1 To tdbg.RowCount
            iNumber += Number(tdbg(i, COL_ProNumber))
        Next

        dRemainQty = iOldNumber - iNumber
        If dRemainQty < 0 Then
            D99C0008.MsgL3(rl3("So_luong_khong_hop_leU"))
            tdbg.Focus()
            tdbg.Columns(COL_ProNumber).Text = ""

            tdbg.SplitIndex = SPLIT2
            tdbg.Bookmark = tdbg.Row
            tdbg.Col = COL_ProNumber
            Return True
        End If
        Return False

    End Function

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        tdbg.Columns(COL_ProApproved).Value = L3Bool(tdbg.Columns(COL_ProApproved).Text)
        tdbg.Columns(COL_IsDependPlan).Value = L3Bool(tdbg.Columns(COL_IsDependPlan).Text)
        Select Case e.ColIndex
            Case COL_RecruitmentType
                If tdbg.Columns(e.ColIndex).Text = "" Then tdbg.Columns(e.ColIndex).Text = ""
            Case COL_BlockName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_BlockID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_BlockID).Text = tdbdBlockID.Columns("BlockID").Text
                If tdbg.Columns(COL_VoucherDate).Text = "" Then tdbg.Columns(COL_VoucherDate).Text = Now.ToString
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
                If tdbg.Columns(COL_VoucherDate).Text <> "" Then tdbg.Columns(COL_VoucherDate).Text = Now.ToString
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""
                tdbg.Columns(COL_EmployeeQTY).Text = ReturnEmployeeQTY()

            Case COL_TeamName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_TeamID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns("TeamID").Text
                tdbg.Columns(COL_EmployeeQTY).Text = ReturnEmployeeQTY()

            Case COL_RecPositionName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_RecPositionID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_RecPositionID).Text = tdbdRecPositionID.Columns("PositionID").Text
                tdbg.Columns(COL_EmployeeQTY).Text = ReturnEmployeeQTY()

            Case COL_CreatorID, COL_Sex, COL_EducationLevelID, COL_ApproverID, COL_WorkID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If

            Case COL_DateFrom, COL_DateTo, COL_VoucherDate, COL_DateJoined, COL_InterviewDate
                ' tdbg.Select()

            Case COL_ProNumber
                ' neu la update dong dau thi ko update nua -> tranh truong hop loop vo tan
                If _FormState = EnumFormState.FormOther AndAlso tdbg.Row <> 0 Then
                    Dim iRow As Integer = tdbg.Row
                    Dim sProNumber As String = tdbg(iRow, COL_ProNumber).ToString

                    tdbg(0, e.ColIndex) = dRemainQty
                    tdbg.Row = 0

                    tdbg(iRow, COL_ProNumber) = sProNumber
                End If
        End Select

        ResetGrid()
    End Sub


    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case tdbg.Col
            Case COL_CreatorID, COL_CreatorName
                Select Case e.KeyCode
                    Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                        tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoComplete = False
                    Case Else
                        tdbg.Splits(SPLIT2).DisplayColumns(tdbg.Col).AutoComplete = True
                End Select
        End Select

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

                    Case COL_ProNumber
                        If _FormState <> EnumFormState.FormOther Then
                            HotKeyF7(tdbg)
                        End If
                    Case Else
                        HotKeyF7(tdbg)
                End Select

            Case Keys.F8
                If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                    HotKeyF8_D25F2000(tdbg)
                    tdbg.Columns(COL_TransID).Text = ""

                    If _FormState = EnumFormState.FormOther Then
                        If tdbg.Row <> 0 Then
                            tdbg.Columns(COL_ProNumber).Text = "0"
                        End If
                        tdbg.UpdateData()
                    End If
                Else
                    D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

            Case Else

        End Select
    End Sub

    Private Sub HotKeyF8_D25F2000(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            If c1Grid.RowCount < 1 Then Exit Sub

            If c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns.Item(c1Grid.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then ' Số
                If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse Val(c1Grid(c1Grid.Row, c1Grid.Col).ToString) = 0 Then
                    For i As Integer = c1Grid.Col To c1Grid.Columns.Count - 1
                        If i <> COL_IsDependPlan Then
                            c1Grid.Columns(i).Text = c1Grid(c1Grid.Row - 1, i).ToString()
                            c1Grid.UpdateData()
                        End If
                    Next
                End If
            Else ' Chuỗi hoặc Ngày
                If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDateShort OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDate Then
                    For i As Integer = c1Grid.Col To c1Grid.Columns.Count - 1
                        If i <> COL_IsDependPlan Then
                            c1Grid.Columns(i).Text = c1Grid(c1Grid.Row - 1, i).ToString()
                            c1Grid.UpdateData()
                        End If
                    Next
                End If
            End If

        Catch ex As Exception
            D99C0008.Msg("Lỗi HotKeyF8: " & ex.Message)
        End Try


    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_ProNumber
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_ReferenceNo
                e.KeyChar = UCase(e.KeyChar) 'Nhập các ký tự hoa 
        End Select
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case e.Col
            Case 0 To tdbg.Columns.Count - 1
                If _formIDPermission <> "D25F3000" OrElse _FormState <> EnumFormState.FormEdit Then Exit Select ' Chỉ chạy khi gọi từ màn hình F3000 và Mode sửa
                If e.Col = COL_DateFrom OrElse e.Col = COL_DateTo OrElse e.Col = COL_StatusComplete Then Exit Select ' Không Lock 2 cột từ ngày và đến ngày
                If _isLock Then
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                    e.CellStyle.Locked = True
                End If
        End Select
        '-----------------------------------------------------------------
        Select Case e.Col
            Case COL_ApproverID
                If L3Bool(tdbg.Columns(COL_ProApproved).Text) = False Then
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                    e.CellStyle.Locked = True
                End If
            Case COL_BlockName
                If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
                    tdbg.Columns(e.Col).DropDown = Nothing
                Else
                    tdbg.Columns(e.Col).DropDown = tdbdBlockID
                    tdbg.Splits(SPLIT1).DisplayColumns(e.Col).Button = True
                End If

            Case COL_DepartmentName
                If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
                    tdbg.Columns(e.Col).DropDown = Nothing
                Else
                    tdbg.Columns(e.Col).DropDown = tdbdDepartmentID
                    tdbg.Splits(SPLIT1).DisplayColumns(e.Col).Button = True
                End If

            Case COL_TeamName
                If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
                    tdbg.Columns(e.Col).DropDown = Nothing
                Else
                    tdbg.Columns(e.Col).DropDown = tdbdTeamID
                End If

            Case COL_RecPositionName
                If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
                    tdbg.Columns(e.Col).DropDown = Nothing
                Else
                    tdbg.Columns(e.Col).DropDown = tdbdRecPositionID
                End If
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_DepartmentName
                LoadTdbdDepartmentID()

            Case COL_TeamName
                LoadtdbdTeamID()
            Case COL_ApproverID
                tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Button = L3Bool(tdbg(tdbg.Row, COL_ProApproved))
                tdbg.UpdateData()
        End Select
    End Sub
#End Region

    Dim dtBlockID As DataTable
    Dim dtDepartmentID As DataTable
    Dim dtTeamID As DataTable

    Private Sub LoadTDBDropDown()
        Dim sUnicode As String = ""
        Dim sAll As String = ""
        UnicodeAllString(sUnicode, sAll, gbUnicode)

        Dim sSQL As String = ""

        sSQL = "Select BlockID, BlockName" & UnicodeJoin(gbUnicode) & " as BlockName From D09T1140 WITH(NOLOCK)  Where Disabled =0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Order by BlockID"
        LoadDataSource(tdbdBlockID, sSQL, gbUnicode)

        If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
            tdbg.Columns(COL_BlockName).DropDown = Nothing
        Else
            tdbg.Columns(COL_BlockName).DropDown = tdbdBlockID

        End If

        'Load tdbdDepartmentID
        sSQL = "SELECT 	DepartmentID, DepartmentName" & UnicodeJoin(gbUnicode) & " as DepartmentName, BlockID" & vbCrLf
        sSQL &= "FROM D91T0012 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0" & vbCrLf
        sSQL &= "AND DivisionID = " & SQLString(gsDivisionID)
        dtDepartmentID = ReturnDataTable(sSQL)

        sSQL = "SELECT D01.TeamID, D01.TeamName" & UnicodeJoin(gbUnicode) & " as TeamName, D01.DepartmentID, D02.BlockID" & vbCrLf
        sSQL &= "FROM D09T0227 D01 WITH(NOLOCK) " & vbCrLf
        sSQL &= "INNER JOIN D91T0012 D02 WITH(NOLOCK)  " & vbCrLf
        sSQL &= "ON D02.DepartmentID = D01.DepartmentID" & vbCrLf
        sSQL &= "WHERE D01.Disabled = 0" & vbCrLf
        sSQL &= "AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        dtTeamID = ReturnDataTable(sSQL)

        'Load tdbdPositionID
        'sSQL = "SELECT RecPositionID AS PositionID , RecPositionName" & UnicodeJoin(gbUnicode) & " as  PositionName" & vbCrLf
        'sSQL &= "FROM D25T1020" & vbCrLf
        'sSQL &= "WHERE Disabled = 0"
        sSQL = "SELECT	0 as DisplayOrder,	'%' AS PositionID, " & sAll & " AS PositionName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT	1 as DisplayOrder,	DutyID As PositionID, DutyName" & sUnicode & " AS PositionName" & vbCrLf
        sSQL &= "FROM		D09T0211  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, PositionID" & vbCrLf
        LoadDataSource(tdbdRecPositionID, sSQL, gbUnicode)

        '  LoadDataSource(tdbdEmployeeID, ReturnTableEmployeeID(True, False, gbUnicode), gbUnicode)
        LoadDataSource(tdbdEmployeeID, ReturnTableCreateBy(gbUnicode), gbUnicode)
        sSQL = "Select DepartmentID, TeamID, DutyID, WorkID, EmployeeQTY From D09T1151 WITH(NOLOCK) "
        dtEmployeeQTY = ReturnDataTable(sSQL)

        sSQL = "--Combo Trinh do giao duc pho thông " & vbCrLf & _
                "SELECT 	EducationLevelID, EducationLevelName" & UnicodeJoin(gbUnicode) & " as EducationLevelName" & vbCrLf & _
                "FROM 	D09T0206 WITH(NOLOCK) " & vbCrLf & _
                "WHERE 	Disabled=0 " & vbCrLf & _
                "ORDER BY 	EducationLevelName"
        LoadDataSource(tdbdEducationLevelName, sSQL, gbUnicode)
        LoadtdbdSexName(tdbdSexName)
        'Load tdbdRecruitmentType

        sSQL = " --Combo Loại tuyển " & vbCrLf & _
               "SELECT 	ID ,		Name" & gsLanguage & UnicodeJoin(gbUnicode) & " as Name" & vbCrLf & _
               "FROM 	D25N5555('D25F2000', 'RecruitmentType', '', '', '', '' )"
        LoadDataSource(tdbcRecruitmentType, sSQL, gbUnicode)

        Dim dtEmployee As DataTable = ReturnTableEmployeeID_D09P6868(gsDivisionID, Me.Name, _isMSS)
        dtEmployee.Rows.RemoveAt(0)
        LoadDataSource(tdbdApproverName, dtEmployee, gbUnicode)


        sSQL = "--Dropdown Cong Viec" & vbCrLf
        sSQL &= "SELECT WorkID, WorkName" & UnicodeJoin(gbUnicode) & " AS WorkName" & vbCrLf
        sSQL &= "FROM D09T0224 WITH(NOLOCK)" & vbCrLf
        sSQL &= "WHERE Disabled = 0 AND ( DivisionID =" & SQLString(gsDivisionID) & " OR  DivisionID = '')" & vbCrLf
        sSQL &= "ORDER BY	WorkName"
        LoadDataSource(tdbdWorkID, sSQL, gbUnicode)
    End Sub

    Private Function ReturnEmployeeQTY() As String
        For i As Integer = 0 To dtEmployeeQTY.Rows.Count - 1
            If tdbg.Columns(COL_DepartmentID).Text = dtEmployeeQTY.Rows(i).Item("DepartmentID").ToString Then
                If tdbg.Columns(COL_TeamID).Text = dtEmployeeQTY.Rows(i).Item("TeamID").ToString Then
                    If tdbg.Columns(COL_RecPositionID).Text = dtEmployeeQTY.Rows(i).Item("DutyID").ToString Then
                        If tdbg.Columns(COL_WorkID).Text = dtEmployeeQTY.Rows(i).Item("WorkID").ToString Then
                            Return dtEmployeeQTY.Rows(i).Item("EmployeeQTY").ToString
                        End If
                    End If
                End If
            End If
        Next
        Return ""
    End Function

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

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        'usrOption2000.Location = New Point(tdbg.Left, btnShow.Top - (usrOption2000.Height + 7))
        'Me.Controls.Add(usrOption2000)
        'usrOption2000.BringToFront()
        'usrOption2000.Visible = True
        usrOption.Location = New Point(tdbg.Left, btnShow.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Dim f As New D25M0340
        'With f
        '    .FormActive = enumD25E0340Form.D25F4050
        '    .ID01 = gsDivisionID 'DivisionID
        '    .ID02 = "%" 'BlockID
        '    .ID03 = "%" 'DepartmentID
        '    .ID04 = "%" 'TeamID
        '    .ID05 = "" 'RecPositionID
        '    .ID06 = "" 'RecruitProposalID
        '    .ID07 = tdbg.Columns(COL_VoucherDate).Text 'ProposalDate
        '    .ShowDialog()
        '    .Dispose()
        'End With
        ExecuteSQL(SQLDeleteD09T6666() & vbCrLf & SQLInsertD09T6666s_Print().ToString)

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "DivisionID", gsDivisionID)
        SetProperties(arrPro, "BlockID", "%")
        SetProperties(arrPro, "DepartmentID", "%")
        SetProperties(arrPro, "TeamID", "%")
        SetProperties(arrPro, "ProposalDate", tdbg.Columns(COL_VoucherDate).Text)
        CallFormShow(Me, "D25D0340", "D25F4050", arrPro)
    End Sub

    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where UserID = " & SQLString(gsUserID) & _
                " AND HostID = " & SQLString(My.Computer.Name) & _
                " AND FormID = " & SQLString(Me.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 21/04/2014 08:46:46
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s_Print(Optional ByVal Key02ID As Integer = -1) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID," & IIf(Key02ID <> -1, "Key02ID,", "").ToString & " FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
            If Key02ID <> -1 Then sSQL.Append(SQLString(tdbg(i, COL_RecruitmentType)) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/07/2016 04:39:44
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu bang tam" & vbCrlf)
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, " & vbCrlf)
            sSQL.Append("Key04ID, Key05ID, Num01, Num02, FormID")
            sSQL.Append(") Values(" & vbCrlf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BlockID)) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'Key02ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA & vbCrLf) 'Key03ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RecPositionID)) & COMMA) 'Key04ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_WorkID)) & COMMA) 'Key05ID, varchar[250], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_ProNumber), tdbg.Columns(COL_ProNumber).NumberFormat) & COMMA) 'Num01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_EmployeeQTY), tdbg.Columns(COL_EmployeeQTY).NumberFormat) & COMMA) 'Num02, decimal, NOT NULL
            sSQL.Append(SQLString(Me.Name) & vbCrLf) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Thanh Huyền
    '# Created Date: 24/12/2010 10:13:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666() As StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID))) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(")")
        Next
        Return sSQL
    End Function


    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex

            Case COL_ProApproved
                If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(e.ColIndex).Locked Then Exit Sub
                Dim bFlag As Boolean = Not L3Bool(tdbg(0, COL_ProApproved))
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, COL_ProApproved) = bFlag
                Next

            Case COL_BlockName, COL_DepartmentName, COL_TeamName
                Dim arCol() As Integer = {COL_BlockID, COL_BlockName, COL_DepartmentID, COL_DepartmentName, COL_TeamID, COL_TeamName}
                CopyColumnArr(tdbg, e.ColIndex, arCol)
            Case COL_RecPositionName
                Dim arCol() As Integer = {COL_RecPositionName}
                CopyColumnArr(tdbg, e.ColIndex, arCol)
            Case COL_IsDependPlan, COL_ProNumber
            Case Else
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Text, tdbg.Row)
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3001
    '# Created User: DUCTRONG
    '# Created Date: 02/06/2010 01:56:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3001(Optional ByVal Mode As Object = 0) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho drid D25F3000" & vbCrLf)
        sSQL &= "Exec D25P3001 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLDateSave(Now) & COMMA 'VoucherDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(Now) & COMMA 'VoucherDateTo, datetime, NOT NULL
        sSQL &= SQLString("") & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'RecpositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsUsedPeriod, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA  'IsAppPro, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(Mode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) 'HostID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2001s
    '# Created User: DUCTRONG
    '# Created Date: 03/06/2010 07:52:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2001s() As StringBuilder
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

            If _FormState = EnumFormState.FormOther And i = 0 Then Continue For

            If tdbg(i, COL_TransID).ToString = "" Then
                sTranID = CreateIGEs("D25T2001", "TransID", "25", "RE", gsStringKey, sTranID, iCountIGE)
                tdbg(i, COL_TransID) = sTranID
            End If

            sSQL.Append("Insert Into D25T2001(")
            sSQL.Append("LinkTransID, TransID, DivisionID, DepartmentID, TeamID, ")
            sSQL.Append("RecPositionID, CreatorID, AppNumber, AppNote, AppNoteU, ApproverID, AppDate, ")
            sSQL.Append("ProNumber, ProNote, ProApproved, Ref01, Ref02, Ref03, ")
            sSQL.Append("Ref04, Ref05, Ref06, Ref07, Ref08, ")
            sSQL.Append("Ref09, Ref10, VoucherDate, TranMonth, TranYear, ")
            sSQL.Append("DateFrom, DateTo, BlockID, CreateDate, CreateUserID, ")
            sSQL.Append("LastModifyDate, LastModifyUserID, ") 'CreatorID, 
            sSQL.Append("Description, PlanTransID, DescriptionU, ProNoteU, ")
            sSQL.Append("Ref01U, Ref02U, Ref03U, Ref04U, Ref05U, ")
            sSQL.Append("Ref06U, Ref07U, Ref08U, Ref09U, Ref10U, ")
            sSQL.Append("ReferenceNo, Sex, InterviewDate, DateJoined, RecruitmentType, WorkID, EducationLevelID,StatusComplete")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(tdbg(i, COL_LinkTransID)) & COMMA)
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RecPositionID)) & COMMA) 'RecPositionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CreatorID)) & COMMA) 'CreatorID, varchar[20], NOT NULL
            If L3Bool(tdbg(i, COL_ProApproved)) Then
                sSQL.Append(SQLNumber(tdbg(i, COL_ProNumber)) & COMMA) 'AppNumber, int, NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_ProNote), gbUnicode, False) & COMMA) 'AppNote, varchar[250], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_ProNote), gbUnicode, True) & COMMA) 'AppNoteU, varchar[250], NOT NULL
                ' 24/12/2014 id 71585 - Luôn lưu
                ' sSQL.Append(SQLString(tdbg(i, COL_CreatorID)) & COMMA) 'CreatorID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_ApproverID)) & COMMA)
                sSQL.Append(SQLDateSave(tdbg(i, COL_VoucherDate)) & COMMA) 'AppDate, datetime, NULL
            Else
                sSQL.Append(SQLNumber(0) & COMMA) 'AppNumber, int, NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'AppNote, varchar[250], NOT NULL
                sSQL.Append("N" & SQLString("") & COMMA) 'AppNoteU, varchar[250], NOT NULL
                ' 24/12/2014 id 71585 - Luôn lưu
                '   sSQL.Append(SQLString("") & COMMA) 'CreatorID, varchar[20], NOT NULL
                sSQL.Append(SQLString("") & COMMA)
                sSQL.Append(SQLDateSave("") & COMMA) 'AppDate, datetime, NULL
            End If

            sSQL.Append(SQLNumber(tdbg(i, COL_ProNumber)) & COMMA) 'ProNumber, int, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_ProNote), gbUnicode, False) & COMMA) 'ProNote, varchar[250], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_ProApproved)) & COMMA) 'ProApproved, tinyint, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref01), gbUnicode, False) & COMMA) 'Ref01, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref02), gbUnicode, False) & COMMA) 'Ref02, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref03), gbUnicode, False) & COMMA) 'Ref03, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref04), gbUnicode, False) & COMMA) 'Ref04, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref05), gbUnicode, False) & COMMA) 'Ref05, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref06), gbUnicode, False) & COMMA) 'Ref06, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref07), gbUnicode, False) & COMMA) 'Ref07, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref08), gbUnicode, False) & COMMA) 'Ref08, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref09), gbUnicode, False) & COMMA) 'Ref09, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref10), gbUnicode, False) & COMMA) 'Ref10, varchar[250], NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_VoucherDate)) & COMMA) 'VoucherDate, datetime, NOT NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateFrom)) & COMMA) 'DateFrom, datetime, NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateTo)) & COMMA) 'DateTo, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COL_BlockID)) & COMMA) 'BlockID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            'sSQL.Append(SQLString(tdbg(i, COL_CreatorID)) & COMMA) 'CreatorID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, False) & COMMA) 'Description, varchar[500], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PlanTransID)) & COMMA) 'PlanTransID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, True) & COMMA) 'DescriptionU, nvarchar[1000], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_ProNote), gbUnicode, True) & COMMA) 'ProNoteU, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref01), gbUnicode, True) & COMMA) 'Ref01U, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref02), gbUnicode, True) & COMMA) 'Ref02U, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref03), gbUnicode, True) & COMMA) 'Ref03U, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref04), gbUnicode, True) & COMMA) 'Ref04U, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref05), gbUnicode, True) & COMMA) 'Ref05U, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref06), gbUnicode, True) & COMMA) 'Ref06U, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref07), gbUnicode, True) & COMMA) 'Ref07U, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref08), gbUnicode, True) & COMMA) 'Ref08U, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref09), gbUnicode, True) & COMMA) 'Ref09U, nvarchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref10), gbUnicode, True) & COMMA) 'Ref10U, nvarchar[500], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ReferenceNo)) & COMMA) 'ReferenceNo, varchar[50], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_Sex)) & COMMA) 'Sex, tinyint, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_InterviewDate)) & COMMA) 'InterviewDate, datetime, NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateJoined)) & COMMA) 'DateJoined, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COL_RecruitmentType)) & COMMA) 'RecruitmentType,  varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_WorkID)) & COMMA) 'WorkID,  varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_EducationLevelID)) & COMMA) 'EducationLevelID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_StatusComplete))) 'StatusComplete, tinyint, NOT NULL
            '
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2001s
    '# Created User: DUCTRONG
    '# Created Date: 03/06/2010 08:21:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2001s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Update D25T2001 Set ")

            sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("DepartmentID = " & SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("TeamID = " & SQLString(tdbg(i, COL_TeamID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("RecPositionID = " & SQLString(tdbg(i, COL_RecPositionID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("ProNumber = " & SQLNumber(tdbg(i, COL_ProNumber)) & COMMA) 'int, NOT NULL
            sSQL.Append("ProNote = " & SQLStringUnicode(tdbg(i, COL_ProNote), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("ProNoteU = " & SQLStringUnicode(tdbg(i, COL_ProNote), gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("ProApproved = " & SQLNumber(tdbg(i, COL_ProApproved)) & COMMA) 'tinyint, NOT NULL
            If L3Bool(tdbg(i, COL_ProApproved)) Then
                sSQL.Append("AppNumber = " & SQLNumber(tdbg(i, COL_ProNumber)) & COMMA) 'int, NOT NULL
                sSQL.Append("AppNote = " & SQLStringUnicode(tdbg(i, COL_ProNote), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
                sSQL.Append("AppNoteU = " & SQLStringUnicode(tdbg(i, COL_ProNote), gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
                sSQL.Append("AppDate = " & SQLDateSave(tdbg(i, COL_VoucherDate)) & COMMA) 'int, NOT NULL
                ' 24/12/2014 id 71585 - Lỗi không hiển thị người lập màn hình D25F3000
                '   sSQL.Append("CreatorID = " & SQLString(tdbg(i, COL_CreatorID)) & COMMA) 'varchar[20], NOT NULL
                sSQL.Append("ApproverID = " & SQLString(tdbg(i, COL_ApproverID)) & COMMA) 'varchar[20], NOT NULL
            End If
            For j As Integer = COL_Ref01 To COL_Ref10
                sSQL.Append(tdbg.Columns(j).DataField & " = " & SQLStringUnicode(tdbg(i, j), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
                sSQL.Append(tdbg.Columns(j).DataField & "U = " & SQLStringUnicode(tdbg(i, j), gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
            Next
            sSQL.Append("VoucherDate = " & SQLDateSave(tdbg(i, COL_VoucherDate)) & COMMA) 'datetime, NOT NULL
            sSQL.Append("TranMonth = " & SQLNumber(giTranMonth) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("TranYear = " & SQLNumber(giTranYear) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("DateFrom = " & SQLDateSave(tdbg(i, COL_DateFrom)) & COMMA) 'datetime, NULL
            sSQL.Append("DateTo = " & SQLDateSave(tdbg(i, COL_DateTo)) & COMMA) 'datetime, NULL
            sSQL.Append("BlockID = " & SQLString(tdbg(i, COL_BlockID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("Description = " & SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, False) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            ' 24/12/2014 id 71585 - Luôn lưu
            sSQL.Append("CreatorID = " & SQLString(tdbg(i, COL_CreatorID)) & COMMA) 'varchar[20], NOT NULL
            'EducationLevelID, InterviewDate, DateJoined, Sex
            sSQL.Append("EducationLevelID = " & SQLString(tdbg(i, COL_EducationLevelID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("Sex = " & SQLString(tdbg(i, COL_Sex)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("InterviewDate = " & SQLDateSave(tdbg(i, COL_InterviewDate)) & COMMA) 'datetime, NULL
            sSQL.Append("DateJoined = " & SQLDateSave(tdbg(i, COL_DateJoined)) & COMMA) 'datetime, NULL
            sSQL.Append("RecruitmentType = " & SQLString(tdbg(i, COL_RecruitmentType)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("WorkID = " & SQLString(tdbg(i, COL_WorkID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("PlanTransID = " & SQLString(tdbg(i, COL_PlanTransID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("StatusComplete = " & SQLNumber(tdbg(i, COL_StatusComplete))) 'tinyint, NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("TransID = " & SQLString(tdbg(i, COL_TransID)))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub btnRecruitmentPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecruitmentPlan.Click
        Dim f As New D25F3180
        With f
            .ShowDialog()

            If .SQLInsertD09T6666.Length > 0 Then
                dtGrid = ReturnDataTable(.SQLInsertD09T6666.ToString & vbCrLf & SQLStoreD25P3001(1))
                LoadTDBGrid()
            End If
            'If .DataTableGrid IsNot Nothing Then
            '    If .DataTableGrid.Rows.Count > 0 Then
            '        LoadDataSource(tdbg, .DataTableGrid, gbUnicode)
            '        FooterTotalGrid(tdbg, COL_DepartmentID)
            '        FooterSum(tdbg, iColumns)
            '    End If
            'End If
            .Dispose()
        End With
        ' InitiateD09U1111()
    End Sub

    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        'If tdbg.Row <= 0 Then Exit Sub
        If e.Row.Equals(0) = False Or _FormState <> EnumFormState.FormOther Then Exit Sub
        e.CellStyle.Locked = True
    End Sub

    Private Sub tdbg_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeDelete
        If tdbg.Row.Equals(0) = False Or _FormState <> EnumFormState.FormOther Then Exit Sub
        e.Cancel = True
    End Sub

    Private Sub btnRecruitmentCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecruitmentCost.Click
        Dim bExe As Boolean = ExecuteSQLNoTransaction(SQLInsertD09T6666().ToString)
        If bExe Then
            Dim arrPro() As StructureProperties = Nothing
            SetProperties(arrPro, "bCallD25F2000", True)
            CallFormShowDialog("D25D0240", "D25F2090", arrPro)
        End If
    End Sub

    Private Sub SplitData()
        'khi gọi từ màn hình D25F3000, trạng thái sửa thì chỉ có 1 dòng, nếu dòng đó có isLock = 1 thì không chạy Delete, Insert và D25P2020
        If _formIDPermission = "D25F3000" AndAlso _FormState = EnumFormState.FormEdit AndAlso _isLock Then Exit Sub
        '--------------------------------------------------------------------------------------------------------------------
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD09T6666() & vbCrLf)
        sSQL.Append(SQLInsertD09T6666s_Print(COL_RecruitmentType))
        sSQL.Append(vbCrLf & SQLStoreD84P2020())
        Dim dtTemp As DataTable = ReturnDataTable(sSQL.ToString)
        If dtTemp.Rows.Count = 0 Then Exit Sub

        'Dim f As New D25F5000
        'f.drData = dtTemp.Rows(0)
        'f.ShowDialog()
        'f.Dispose()
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "drData", dtTemp.Rows(0))
        CallFormShowDialog("D84D1140", "D84F5000", arrPro)
        ExecuteSQL(SQLDeleteD09T6666)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/07/2016 04:47:37
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P5555() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra truoc khi Luu" & vbCrLf)
        sSQL &= "Exec D25P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Type, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    
End Class