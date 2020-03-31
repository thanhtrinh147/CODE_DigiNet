Imports System
Public Class D25F2013


#Region "Const of tdbgFrom và tdbgTo"
    Private Const COL_CandidateID As Integer = 0     ' Mã
    Private Const COL_CandidateName As Integer = 1   ' Họ và tên
    Private Const COL_RecDepartmentID As Integer = 2 ' Phòng ban
    Private Const COL_RecTeamID As Integer = 3       ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 4   ' Vị trí
#End Region

    Dim dtL As New DataTable
    Dim dtR As New DataTable

    Public bFlagSave As Boolean = False

    Private _interviewFileID As String
    Public Property InterviewFileID() As String
        Get
            Return _interviewFileID
        End Get
        Set(ByVal Value As String)
            _interviewFileID = Value
        End Set
    End Property


    Private _recruitmentFileID As String
    Public Property RecruitmentFileID() As String
        Get
            Return _recruitmentFileID
        End Get
        Set(ByVal Value As String)
            _recruitmentFileID = Value
        End Set
    End Property

    Private _interviewLevel As String
    Public Property InterviewLevel() As String
        Get
            Return _interviewLevel
        End Get
        Set(ByVal Value As String)
            _interviewLevel = Value
        End Set
    End Property

    Private _recruitPlanID As String
    Public Property RecruitPlanID() As String
        Get
            Return _recruitPlanID
        End Get
        Set(ByVal Value As String)
            _recruitPlanID = Value
        End Set
    End Property

    Private _recDepartmentID As String
    Public Property RecDepartmentID() As String
        Get
            Return _recDepartmentID
        End Get
        Set(ByVal Value As String)
            _recDepartmentID = Value
        End Set
    End Property

    Private _recTeamID As String
    Public Property RecTeamID() As String
        Get
            Return _recTeamID
        End Get
        Set(ByVal Value As String)
            _recTeamID = Value
        End Set
    End Property

    Private _recPositionID As String
    Public Property RecPositionID() As String
        Get
            Return _recPositionID
        End Get
        Set(ByVal Value As String)
            _recPositionID = Value
        End Set
    End Property

    Private _candidate As String
    Public Property Candidate() As String
        Get
            Return _candidate
        End Get
        Set(ByVal Value As String)
            _candidate = Value
        End Set
    End Property

    Private _formClose As Boolean = False
    Public Property FormClose() As Boolean
        Get
            Return _formClose
        End Get
        Set(ByVal Value As Boolean)
            _formClose = Value
        End Set
    End Property

    Private Sub D21F2013_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FormClose = _formClose
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        _formClose = True
        D21F2013_FormClosed(sender, Nothing)
    End Sub

    Private Sub D21F2011_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        LoadLanguage()
        LoadTDBGridFrom()
        InitdtR()
        CheckStatus()
InputDateCustomFormat(c1dateIntDate)
        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Them_ung_vien_-_D25F2013") 'Th£m ÷ng vi£n - D25F2013
        '================================================================ 
        lblteIntDate.Text = rl3("Ngay_phong_van") 'Thời gian
        lblInTime.Text = rl3("Gio_phong_van")

        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkCancelCandidateID.Text = rl3("Hien_thi_cac_ung_vien_da_doi_lich_phong_van")
        '================================================================ 
        tdbgFrom.Columns("CandidateID").Caption = rl3("Ma") 'Mã
        tdbgFrom.Columns("CandidateName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbgTo.Columns("CandidateID").Caption = rl3("Ma") 'Mã
        tdbgTo.Columns("CandidateName").Caption = rl3("Ho_va_ten") 'Họ và tên
        'lblteIntDate.Text = rl3("Ngay_PV") 'Thời gian
        'lblInTime.Text = rl3("Gio_PV")
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
    End Sub

    Private Sub CheckStatus()
        btnRow.Enabled = dtL.Rows.Count > 0
        btnSelectAll.Enabled = dtL.Rows.Count > 0
        btnCancelAll.Enabled = dtR.Rows.Count > 0
        btnCancelRow.Enabled = dtR.Rows.Count > 0
    End Sub


#Region "Active Find - List All "
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
            LoadTDBGridFrom() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property


    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        sSQL = "Select * From D25V1234 "
        sSQL &= "Where FormID = " & SQLString(Me) & "And Language = " & SQLString(gsLanguage)
        sSQL &= "Order by No"
        ShowFindDialog(Finder, sSQL)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    LoadTDBGridFrom()
    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        sFind = ""
        LoadTDBGridFrom()
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2013
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 03/12/2007 03:07:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2013() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2013 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(InterviewFileID) & COMMA 'InterviewFileID, varchar[20], NOT NULL
        sSQL &= SQLString(RecruitmentFileID) & COMMA 'RecruitmentFileID, varchar[20], NOT NULL
        sSQL &= SQLString(InterviewLevel) & COMMA 'InterviewLevel, varchar[20], NOT NULL
        sSQL &= SQLString(RecruitPlanID) & COMMA 'RecruitPlanID, varchar[20], NOT NULL
        sSQL &= SQLString(RecDepartmentID) & COMMA 'RecDepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(RecTeamID) & COMMA 'RecTeamID, varchar[20], NOT NULL
        sSQL &= SQLString(RecPositionID) & COMMA 'RecPositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkCancelCandidateID.Checked) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(sFind) 'WhereClause, varchar[1000], NOT NULL
        Return sSQL
    End Function



    Private Sub LoadTDBGridFrom()
        Dim sSQL As String = ""
        sSQL = SQLStoreD25P2013()
        'create primary key
        dtL = ReturnDataTable(sSQL)
        Dim keys(0) As DataColumn
        keys(0) = dtL.Columns("CandidateID")
        dtL.PrimaryKey = keys

        LoadDataSource(tdbgFrom, dtL)

    End Sub

    Private Sub InitdtR()
        'Dim sSQL As String = ""
        'sSQL = "Select CandidateID,'' as CandidateName From D25T1042 where 0=1"
        'dtR = ReturnDataTable(sSQL)
        'Dim dc As New DataColumn("CandidateID", GetType(System.String))
        'dtR.Columns.Add(dc)
        'dc = New DataColumn("CandidateName", GetType(System.String))
        'dtR.Columns.Add(dc)
        'Create Primary key
        'Dim keys(0) As DataColumn
        'keys(0) = dtR.Columns("CandidateID")
        'dtR.PrimaryKey = keys

        dtR = dtL.Clone

    End Sub

    Private Sub btnRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRow.Click
        If tdbgFrom.Bookmark < 0 Then Exit Sub
        Dim bookmark As Integer = tdbgFrom.Bookmark
        If bookmark > dtL.Rows.Count Then bookmark = dtL.Rows.Count
        Dim aSelectRows As C1.Win.C1TrueDBGrid.SelectedRowCollection
        aSelectRows = tdbgFrom.SelectedRows
        If aSelectRows.Count > 0 Then 'chọn nhiều dòng
            Dim i As Integer
            'Thêm dữ liệu lưới phải
            For i = 0 To aSelectRows.Count - 1
                CopyItem(aSelectRows.Item(i), tdbgFrom, dtL, tdbgTo, dtR)
            Next
            'Xoá dl lưới trái
            i = aSelectRows.Count - 1
            Dim j As Integer = aSelectRows.Item(i) 'Dùng để giảm 1 khi đã xóa đi trong lưới 1 dòng
            While (i >= 0)
                RemoveItem(j, tdbgFrom, dtL, COL_CandidateID)
                i -= 1
                If i >= 0 Then j = aSelectRows.Item(i) - 1
            End While
        Else 'dòng có con trỏ, không chọn
            CopyItem(tdbgFrom.Row, tdbgFrom, dtL, tdbgTo, dtR)
            RemoveItem(tdbgFrom.Row, tdbgFrom, dtL, COL_CandidateID)
        End If
        LoadDataSource(tdbgFrom, dtL)
        LoadDataSource(tdbgTo, dtR)

        tdbgFrom.Bookmark = bookmark

        CheckStatus()
    End Sub

    Private Sub CopyItem(ByVal iRow As Integer, ByVal tdbgSource As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dtSource As DataTable, ByVal tdbgDes As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByRef dtDes As DataTable)
        Dim Row As DataRow
        Row = dtDes.NewRow
        For i As Integer = 0 To tdbgSource.Columns.Count - 1
            Row(i) = tdbgSource(iRow, i)
        Next
        dtDes.Rows.Add(Row)
    End Sub

    Private Sub RemoveItem(ByVal iRow As Integer, ByVal tdbgSource As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByRef dtSource As DataTable, Optional ByVal iColPkey As Integer = 0)
        Dim myDataRow As DataRowCollection = dtSource.Rows
        If myDataRow.Contains(tdbgSource(iRow, iColPkey)) Then
            Dim row As DataRow = myDataRow.Find(tdbgSource(iRow, iColPkey))
            myDataRow.Remove(row)
        End If
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        Dim i As Integer = tdbgFrom.RowCount - 1
        While i >= 0
            CopyItem(i, tdbgFrom, dtL, tdbgTo, dtR)
            RemoveItem(i, tdbgFrom, dtL, COL_CandidateID)
            i = tdbgFrom.RowCount - 1
        End While
        LoadDataSource(tdbgFrom, dtL)
        LoadDataSource(tdbgTo, dtR)

        CheckStatus()
    End Sub

    Private Sub btnCancelRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelRow.Click
        If tdbgTo.Bookmark < 0 Then Exit Sub
        Dim bookmark As Integer = tdbgTo.Bookmark
        If bookmark > dtR.Rows.Count Then bookmark = dtR.Rows.Count
        Dim aSelectRows As C1.Win.C1TrueDBGrid.SelectedRowCollection
        aSelectRows = tdbgTo.SelectedRows
        If aSelectRows.Count > 0 Then 'chọn nhiều dòng
            Dim i As Integer
            'Thêm dữ liệu lưới phải
            For i = 0 To aSelectRows.Count - 1
                'CopyItem(i, tdbgTo, dtR, tdbgFrom, dtL) '
                CopyItem(aSelectRows.Item(i), tdbgTo, dtR, tdbgFrom, dtL)
            Next
            'Xoá dl lưới trái
            i = aSelectRows.Count - 1
            Dim j As Integer = aSelectRows.Item(i) 'Dùng để giảm 1 khi đã xóa đi trong lưới 1 dòng
            While (i >= 0)
                'RemoveItem(i, tdbgTo, dtR, COL_CandidateID)
                RemoveItem(j, tdbgTo, dtR, COL_CandidateID)
                i -= 1
                If i >= 0 Then j = aSelectRows.Item(i) - 1
            End While
        Else 'dòng có con trỏ, không chọn
            CopyItem(tdbgTo.Row, tdbgTo, dtR, tdbgFrom, dtL)
            RemoveItem(tdbgTo.Row, tdbgTo, dtR, COL_CandidateID)
        End If
        LoadDataSource(tdbgFrom, dtL)
        LoadDataSource(tdbgTo, dtR)

        tdbgTo.Bookmark = bookmark

        CheckStatus()
    End Sub

    Private Sub btnCancelAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelAll.Click
        Dim i As Integer = tdbgTo.RowCount - 1
        While i >= 0
            CopyItem(i, tdbgTo, dtR, tdbgFrom, dtL)
            RemoveItem(i, tdbgTo, dtR, COL_CandidateID)
            i = tdbgTo.RowCount - 1
        End While
        LoadDataSource(tdbgFrom, dtL)
        LoadDataSource(tdbgTo, dtR)

        CheckStatus()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2011s
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 03/12/2007 04:01:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2011s(ByVal aCandidateIDs As String) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim aCandidate() As String = Microsoft.VisualBasic.Split(aCandidateIDs, ",")
        sRet.Append("DECLARE @Now datetime; SET @Now = getDate()" & vbCrLf)
        For i As Integer = 0 To tdbgTo.RowCount - 1
            sSQL.Append("Insert Into D25T2011(")
            sSQL.Append("DivisionID, InterviewFileID, RecruitmentFileID, CandidateID,") ' IntStatusID, ")
            sSQL.Append("IntDate, IntTime, Interviewer, InterviewPlace,") ' Content, Result, ")
            sSQL.Append("Disabled, CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, ")
          
            sSQL.Append("InterviewLevels) Values(")
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(InterviewFileID) & COMMA) 'InterviewFileID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(RecruitmentFileID) & COMMA) 'RecruitmentFileID [KEY], varchar[20], NOT NULL
            sSQL.Append(aCandidate(i) & COMMA) 'CandidateID [KEY], varchar[20], NOT NULL

            sSQL.Append(SQLDateSave(c1dateIntDate.Text) & COMMA) 'IntDate, datetime, NULL
            If c1dateIntTime.Text <> "" Then
                sSQL.Append(SQLString(Format(c1dateIntTime.Value, "HHmm")) & COMMA)
            Else
                sSQL.Append("''" & COMMA)
            End If
            'sSQL.Append(SQLString(IIf(c1dateIntTime.Text <> "", Format(c1dateIntTime.Value, "HHmm"), "")) & COMMA)
            sSQL.Append(SQLString("") & COMMA) 'Interviewer, varchar[50], NULL
            sSQL.Append(SQLString("") & COMMA) 'InterviewPlace, varchar[250], NULL
           
            sSQL.Append(SQLNumber(0) & COMMA) 'Disabled, tinyint, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("@Now" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append("@Now" & COMMA) 'LastModifyDate, datetime, NULL
           
            sSQL.Append(SQLString(InterviewLevel)) 'InterviewLevels [KEY], varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub chkCancelCandidateID_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCancelCandidateID.CheckedChanged
        LoadTDBGridFrom()
        tdbgTo.Delete(0, tdbgTo.RowCount)
        CheckStatus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If tdbgTo.RowCount = 0 Then Exit Sub
        Dim aCandidateIDs As String = ""
        For i As Integer = 0 To tdbgTo.RowCount - 2
            aCandidateIDs &= SQLString(tdbgTo(i, COL_CandidateID)) & ","
        Next
        aCandidateIDs &= SQLString(tdbgTo(tdbgTo.RowCount - 1, COL_CandidateID))
        If aCandidateIDs = "" Then Exit Sub
        'đặt bookmark cho dòng đầu tiên
        Candidate = tdbgTo(0, COL_CandidateID).ToString 'chi dùng với TH thêm(đặt bookmark).

        Dim bRunSQL As Boolean = ExecuteSQL(SQLInsertD25T2011s(aCandidateIDs).ToString)
        If bRunSQL Then
            SaveOK()
            bFlagSave = True
        Else
            SaveNotOK()
            bFlagSave = False
        End If

        ''Mở D25F2014
        'Dim f As New D25F2014
        'f.InterviewFileID = InterviewFileID
        'f.RecruitmentFileID = RecruitmentFileID
        'f.RecTeamID = RecTeamID
        'f.Candidate = Candidate
        'f.InterviewLevel = InterviewLevel
        'f.FormState = EnumFormState.FormEdit
        'f.ShowDialog()
        'f.Dispose()

        Me.Close()
    End Sub
End Class