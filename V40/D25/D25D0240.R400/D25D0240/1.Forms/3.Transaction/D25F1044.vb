Imports System.Windows.Forms
Imports System
Imports System.IO

Public Class D25F1044

#Region "Const of tdbg"
    Private Const COL_Level As Integer = 0         ' Vòng PV
    Private Const COL_IntDate As Integer = 1       ' Ngày
    Private Const COL_Content As Integer = 2       ' Nội dung
    Private Const COL_IntStatusName As Integer = 3 ' Kết quả
    Private Const COL_Result As Integer = 4        ' Ghi chú
#End Region

    Dim PathFile As String = gsApplicationPath & "\Temp\" ' Application.StartupPath & "\Temp\"
    Dim ExtFile As String = ".jpg"

    Private _recruitmentFileID As String
    Public Property RecruitmentFileID() As String
        Get
            Return _recruitmentFileID
        End Get
        Set(ByVal Value As String)
            _recruitmentFileID = Value
        End Set
    End Property

    Private _candidateID As String
    Public Property CandidateID() As String
        Get
            Return _candidateID
        End Get
        Set(ByVal Value As String)
            _candidateID = Value
        End Set
    End Property

    Private Sub D25F1044_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        picImageID.Dispose()
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(PathFile, _
            FileIO.SearchOption.SearchAllSubDirectories, "*" & ExtFile)
            Try
                If Not picImageID.Image Is Nothing Then picImageID.Image.Dispose()
                My.Computer.FileSystem.DeleteFile(foundFile)
            Catch ex As IOException
                D99C0008.MsgL3(ex.Message)
            End Try
        Next
    End Sub

    Private Sub D25F1044_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        ResetColorGrid(tdbg)
        Loadlanguage()
        LoadData()
        InputDateCustomFormat(c1dateReceivedDate, c1dateBirthDate, c1dateTrailDateTo, c1dateTrialDateFrom, c1dateBeginDate, c1dateRecruitedDate)
        InputDateInTrueDBGrid(tdbg, COL_IntDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Thong_tin_ung_vien_-_D25F1044") 'Th¤ng tin ÷ng vi£n - D25F1044
        '================================================================ 
        lblInterviewResult.Text = rl3("Ket_qua_phong_van") 'Kết quả phỏng vấn
        lblRecruitInfo.Text = rl3("Thong_tin_tuyen_dung") 'Thông tin tuyển dụng
        lblGeneralInfo.Text = rl3("Thong_tin_chung") 'Thông tin chung
        lblCandidateID.Text = rl3("Ung_vien") 'Ứng viên
        lblteBirthDate.Text = rl3("Ngay_sinh") 'Ngày sinh
        lblSex.Text = rl3("Gioi_tinh") 'Giới tính
        lblCountryName.Text = rl3("Quoc_tich") 'Quốc tịch
        lblteReceivedDate.Text = rl3("Ngay_nhan_ho_so") 'Ngày nhận hồ sơ
        lblFileReceiverName.Text = rl3("Nguoi_nhan") 'Người nhận
        lblRecSourceName.Text = rl3("Nguon_tuyen_dung") 'Nguồn tuyển dụng
        lblRecDepartmentName.Text = rl3("Phong_ban") 'Phòng ban
        lblRecTeamName.Text = rl3("To_nhom") 'Tổ nhóm
        lblRecPositionName.Text = rl3("Vi_tri") 'Vị trí
        lblDesiredSalary.Text = rl3("Luong_yeu_cau") 'Lương yêu cầu
        lblCurrencyID.Text = rl3("Loai_tien") 'Loại tiền
        lblTempProcess.Text = rl3("Qua_trinh_thu_viec") 'Quá trình thử việc
        lblWorkInfo.Text = rl3("Thong_tin_lam_viec") 'Thông tin làm việc
        lblteRecruitedDate.Text = rl3("Ngay_trung_tuyen") 'Ngày trúng tuyển
        lblteBeginDate.Text = rl3("Ngay_lam_viec") 'Ngày làm việc
        lblWorkingPace.Text = rl3("Dia_diem") 'Địa điểm
        lblWorkingTypeName.Text = rl3("Hinh_thuc") 'Hình thức
        lblWorkingStatusName.Text = rl3("Loai_hinh") 'Loại hình
        lblReceiverName.Text = rl3("Nguoi_tiep_nhan") 'Người tiếp nhận
        lblMainSalary.Text = rl3("Luong_chinh_thuc") 'Lương chính thức
        lblMainCurrenctID.Text = rl3("Loai_tien") 'Loại tiền
        lblteTrialDateFrom.Text = rl3("Thoi_gian") 'Thời gian
        lblTempSalary.Text = rl3("Luong_thu_viec") 'Lương thử việc
        lblTrailCurrencyID.Text = rl3("Loai_tien") 'Loại tiền
        lblContent.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnFileRecSource.Text = rl3("_Ho_so_ung_vien") '&Hồ sơ ứng viên
        '================================================================ 
        chkLongBusinesstrip.Text = rl3("Di_cong_tac_xa") 'Đi công tác xa
        chkTransferedD09.Text = rl3("Da_chuyen_sang_HSNV") 'Đã chuyển sang HSNV
        '================================================================ 
        '================================================================ 
        TabPage1.Text = rl3("1_Tuyen_dung") '1. Tuyển dụng
        TabPage2.Text = rl3("2_Trung_tuyen") '2. Trúng tuyển
        '================================================================ 
        tdbg.Columns("InterviewLevels").Caption = rl3("Vong_PV") 'Vòng PV
        tdbg.Columns("IntDate").Caption = rl3("Ngay") 'Ngày
        tdbg.Columns("Content").Caption = rl3("Noi_dung") 'Nội dung
        tdbg.Columns("IntStatusName").Caption = rl3("Ket_qua") 'Kết quả
        tdbg.Columns("Note").Caption = rl3("Ghi_chu") 'Ghi chú
    End Sub

    Private Sub D25F1044_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tabCandidateInfo.SelectTab(0)
            Exit Sub
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            tabCandidateInfo.SelectTab(1)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
    End Sub

    Private Sub D25F1044_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            FormKeyPress(sender, e)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub LoadData()
        Try
            Dim sSQL As String = SQLStoreD25P1042(RecruitmentFileID, , , , , , , , , CandidateID)
            Dim dt As DataTable = ReturnDataTable(sSQL)
            Dim dt_Loadtdbg As New DataTable
            'Dim dr As DataRow
            If dt.Rows.Count > 0 Then
                'Tab Tuyển dụng
                txtCandidateID.Text = CandidateID
                txtCandidateName.Text = dt.Rows(0).Item("CandidateName").ToString
                c1dateBirthDate.Value = SQLDateShow(dt.Rows(0).Item("BirthDate"))
                txtSex.Text = dt.Rows(0).Item("Sex").ToString
                txtCountryName.Text = dt.Rows(0).Item("CountryName").ToString
                c1dateReceivedDate.Value = SQLDateShow(dt.Rows(0).Item("ReceivedDate"))
                txtFileReceiverName.Text = dt.Rows(0).Item("FileReceiverName").ToString
                txtRecSourceName.Text = dt.Rows(0).Item("RecSourceName").ToString
                txtRecDepartmentName.Text = dt.Rows(0).Item("RecDepartmentName").ToString
                txtRecTeamName.Text = dt.Rows(0).Item("RecTeamName").ToString
                txtRecPositionName.Text = dt.Rows(0).Item("RecPositionName").ToString
                txtDesiredSalary.Text = Format(dt.Rows(0).Item("DesiredSalary"), D25Format.DefaultNumber0)
                txtCurrencyID.Text = dt.Rows(0).Item("CurrencyID").ToString
                chkLongBusinesstrip.Checked = CBool(dt.Rows(0).Item("LongBusinesstrip"))
                '--------------------------------------------------------------
                'Tab Trúng tuyển
                c1dateRecruitedDate.Value = SQLDateShow(dt.Rows(0).Item("RecruitedDate"))
                c1dateBeginDate.Value = SQLDateShow(dt.Rows(0).Item("BeginDate"))
                txtWorkingPace.Text = dt.Rows(0).Item("WorkingPlace").ToString
                txtWorkingTypeName.Text = dt.Rows(0).Item("WorkingTypeName").ToString
                txtWorkingStatusName.Text = dt.Rows(0).Item("WorkingStatusName").ToString
                txtReceiverName.Text = dt.Rows(0).Item("ReceiverName").ToString
                txtMainSalary.Text = Format(Number(dt.Rows(0).Item("MainSalary")), D25Format.DefaultNumber0)
                txtMainCurrenctID.Text = dt.Rows(0).Item("MainCurrencyID").ToString
                c1dateTrialDateFrom.Value = SQLDateShow(dt.Rows(0).Item("TrialDateFrom"))
                c1dateTrailDateTo.Value = SQLDateShow(dt.Rows(0).Item("TrialDateTo"))
                txtTempSalary.Text = Format(Number(dt.Rows(0).Item("TempSalary")), D25Format.DefaultNumber0)
                txtTrailCurrencyID.Text = dt.Rows(0).Item("TrialCurrencyID").ToString
                txtContent.Text = dt.Rows(0).Item("Content").ToString
                '--------------------------------------------------------------
                chkTransferedD09.Checked = CBool(dt.Rows(0).Item("TransferedD09"))
                LoadImage()
                '----------------------------------
                LoadTdbg()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadImage()
        If Not picImageID.Image Is Nothing Then picImageID.Image.Dispose()
        Dim fileName As String = ""
        fileName = PathFile & _candidateID & ExtFile

        'Kiểm tra thư mục có tồn tại không?
        If Not My.Computer.FileSystem.DirectoryExists(PathFile) Then MkDir(PathFile)
        'kiểm tra tên file này tồn tại trên máy local không?
        'Ngược lại thì lấy hình dưới database
        'Nếu đã tồn tại trên máy local thì gán lên
        If My.Computer.FileSystem.FileExists(fileName) Then
            picImageID.Image = System.Drawing.Image.FromFile(fileName)
            Exit Sub
        End If
        Dim sSQL As String = "Select ImageID From D25T1041 WITH(NOLOCK)  Where DivisionID=" & SQLString(gsDivisionID) & " And CandidateID=" & SQLString(_candidateID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then picImageID.Image = WriteImage(dt.Rows(0).Item("ImageID"), fileName)
    End Sub

    'Hồ sơ ứng viên(chỉ xem)
    Private Sub btnFileRecSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileRecSource.Click
        'Dim f As New D25M0140
        'With f
        '    .FormActive = enumD25E0140Form.D25F1051
        '    .ID01 = CandidateID
        '    .FormState = EnumFormState.FormView
        '    .ShowDialog()
        '    .Dispose()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "CandidateID", CandidateID)
        SetProperties(arrPro, "FormState", EnumFormState.FormView)
        CallFormThread(Me, "D25D0140", "D25F1051", arrPro)
    End Sub

    Private Sub LoadTdbg()
        Dim sSQL As String = ""
        sSQL &= "Select InterviewLevels, IntDate, IntStatusID," & vbCrLf
        sSQL &= "Case IntStatusID When '00001' Then " & SQLString(rl3("Dat_V")) & " When '00002' Then " & SQLString(rl3("Khong_dat_V")) & " When '00003' Then " & SQLString(rl3("Khong_tham_gia_phong_van_V")) & " End IntStatusName," & vbCrLf
        sSQL &= "Content, Result, Case When IntStatusID = '00003' And ReSchedule = 1 Then " & SQLString(rl3("Doi_lich_phong_van_V")) & " Else '' End As Note" & vbCrLf
        sSQL &= " From D25T2011 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= " And RecruitmentFileID = " & SQLString(_recruitmentFileID) & vbCrLf
        sSQL &= " And CandidateID = " & SQLString(_candidateID) & vbCrLf
        LoadDataSource(tdbg, sSQL)
    End Sub

End Class