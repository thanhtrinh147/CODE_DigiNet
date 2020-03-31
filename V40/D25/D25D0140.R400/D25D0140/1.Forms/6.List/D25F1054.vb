Imports System
Public Class D25F1054


#Region "Const of tdbg"
    Private Const COL_DepartmentName As Integer = 0    ' Phòng ban
    Private Const COL_TeamName As Integer = 1          ' Tổ nhóm
    Private Const COL_EmpGroupName As Integer = 2      ' Nhóm nhân viên
    Private Const COL_DutyName As Integer = 3          ' Chức vụ
    Private Const COL_WorkName As Integer = 4          ' Công việc/ Vị trí ứng tuyển
    Private Const COL_InterviewFileName As Integer = 5 ' Lịch phỏng vấn
    Private Const COL_IntDate As Integer = 6           ' Ngày PV
    Private Const COL_InterviewLevels As Integer = 7   ' Vòng PV
    Private Const COL_Content As Integer = 8           ' Nội dung PV
    Private Const COL_Result As Integer = 9            ' Kết quả PV
    Private Const COL_StatusID As Integer = 10         ' Trạng thái
#End Region


    Private _candidateID As String=""
    Public WriteOnly Property CandidateID() As String
        Set(ByVal Value As String)
            _candidateID = Value
        End Set
    End Property

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1054
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 25/06/2013 03:01:35
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1054() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho form D25F1054" & vbCrlf)
        sSQL &= "Exec D25P1054 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_candidateID) & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Dim dtGrid As DataTable
    Private Sub LoadTDBGrid()
        dtGrid = ReturnDataTable(SQLStoreD25P1054())
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        FooterTotalGrid(tdbg, COL_DepartmentName)
    End Sub

    Private Sub D25F1054_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        ResetSplitDividerSize(tdbg)
        ResetColorGrid(tdbg, 0, 1)
        LoadTDBGrid()
        LoadLanguage()
        InputDateInTrueDBGrid(tdbg, COL_IntDate)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Lich_su_phong_van") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'LÜch sõ tuyÓn dóng
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns(COL_DepartmentName).Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_TeamName).Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_EmpGroupName).Caption = rl3("Nhom_nhan_vien") 'Nhóm nhân viên
        tdbg.Columns(COL_DutyName).Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns(COL_WorkName).Caption = rl3("Cong_viec_Vi_tri_ung_tuyen") 'Công việc/ Vị trí ứng tuyển
        tdbg.Columns(COL_InterviewFileName).Caption = rl3("Lich_phong_van") 'Lịch phỏng vấn
        tdbg.Columns(COL_IntDate).Caption = rl3("Ngay_PV") 'Ngày PV
        tdbg.Columns(COL_InterviewLevels).Caption = rl3("Vong_PV") 'Vòng PV
        tdbg.Columns(COL_Content).Caption = rl3("Noi_dung_PV") 'Nội dung PV
        tdbg.Columns(COL_Result).Caption = rl3("Ket_qua_PV") 'Kết quả PV
        tdbg.Columns(COL_StatusID).Caption = rl3("Trang_thai") 'Trạng thái
    End Sub



    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Active FilterChange "
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False

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

    '	Vào sự kiện tdbg_KeyDown viết code bổ sung đoạn tô đậm như sau:
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = "" 'sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
    End Sub
#End Region

End Class