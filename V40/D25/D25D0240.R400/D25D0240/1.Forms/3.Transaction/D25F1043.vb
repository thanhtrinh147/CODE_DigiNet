Imports System.Windows.Forms
Imports System
Public Class D25F1043

#Region "Const of tdbgFrom"
    Private Const COL_CandidateID As Integer = 0         ' Mã
    Private Const COL_CandidateName As Integer = 1       ' Họ và tên
    Private Const COL_RecDepartmentID As Integer = 2     ' Phòng ban
    Private Const COL_RecTeamID As Integer = 3           ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 4       ' Vị trí
    Private Const COL_Suggester As Integer = 5           ' Người giới thiệu
    Private Const COL_SuggesterDivision As Integer = 6   ' Đơn vị NGT
    Private Const COL_SuggesterDepartment As Integer = 7 ' Phòng ban NGT
    Private Const COL_SuggesterDuty As Integer = 8       ' Chức vụ NGT

#End Region


#Region "Const of tdbgTo"
    Private Const COLT_CandidateID As Integer = 0         ' Mã
    Private Const COLT_CandidateName As Integer = 1       ' Họ và tên
    Private Const COLT_RecDepartmentID As Integer = 2     ' Phòng ban
    Private Const COLT_RecTeamID As Integer = 3           ' Tổ nhóm
    Private Const COLT_RecPositionID As Integer = 4       ' Vị trí ứng tuyển
    Private Const COLT_Suggester As Integer = 5           ' Người giới thiệu
    Private Const COLT_SuggesterDivision As Integer = 6   ' Đơn vị NGT
    Private Const COLT_SuggesterDepartment As Integer = 7 ' Phòng ban NGT
    Private Const COLT_SuggesterDuty As Integer = 8       ' Chức vụ NGT
#End Region


    Dim dtL As New DataTable
    Dim dtR As New DataTable

    Public bFlagSave As Boolean = False

    Private _recruitmentFileID As String
    Public Property RecruitmentFileID() As String
        Get
            Return _recruitmentFileID
        End Get
        Set(ByVal Value As String)
            _recruitmentFileID = Value
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

    Private Sub D21F2011_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FormClose = _formClose
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        _formClose = True
        D21F2011_FormClosed(sender, Nothing)
    End Sub

    Private Sub D21F2011_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        tdbgFrom.AllowSort = True
        tdbgTo.AllowSort = True
        ResetColorGrid(tdbgFrom)
        ResetColorGrid(tdbgTo)
        gbEnabledUseFind = False
        LoadLanguage()
        LoadTDBGridFrom()
        InitdtR()
        CheckStatus()
        SetResolutionForm(Me, C1ContextMenu)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Them_ung_vien_-_D25F1043") 'Th£m ÷ng vi£n - D25F1043 - D25F2013
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkCancelCandidateID.Text = rl3("Loai_bo_nhung_ung_vien_da_ton_tai_trong_cac_dot_tuyen_dung") 'Loại bỏ những ứng viên đã tồn tại trong các đợt tuyển dụng
        '================================================================ 
        tdbgFrom.Columns("CandidateID").Caption = rl3("Ma") 'Mã
        tdbgFrom.Columns("CandidateName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbgTo.Columns("CandidateID").Caption = rl3("Ma") 'Mã
        tdbgTo.Columns("CandidateName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbgFrom.Columns("RecPositionID").Caption = rl3("Vi_tri_ung_tuyen") 'Vị trí ứng tuyển
        tdbgTo.Columns("RecPositionID").Caption = rl3("Vi_tri_ung_tuyen") 'Vị trí ứng tuyển

        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
    End Sub

    Private Sub CheckStatus()
        'btnRow.Enabled = dtL.Rows.Count > 0
        'btnSelectAll.Enabled = dtL.Rows.Count > 0
        'btnCancelAll.Enabled = dtR.Rows.Count > 0
        'btnCancelRow.Enabled = dtR.Rows.Count > 0

        btnRow.Enabled = tdbgFrom.RowCount > 0
        btnSelectAll.Enabled = tdbgFrom.RowCount > 0
        btnCancelAll.Enabled = tdbgTo.RowCount > 0
        btnCancelRow.Enabled = tdbgTo.RowCount > 0
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
            'ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
            '----------------
            LoadTDBGridFrom()
            SubtractSameRow()
            CheckStatus()
            FooterTotalGrid(tdbgFrom, COL_CandidateName)
            FooterTotalGrid(tdbgTo, COL_CandidateName)
		End Set
	End Property


    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        sSQL = "Select * From D25V1234 "
        sSQL &= "Where FormID = " & SQLString(Me) & "And Language = " & SQLString(gsLanguage)
        ShowFindDialog(Finder, sSQL)
    End Sub

    Private Sub SubtractSameRow()
        For Each dr As DataRow In dtR.Rows
            Dim drFound As DataRow = dtL.Rows.Find(dr("CandidateID").ToString)
            If drFound IsNot Nothing Then
                dtL.Rows.Remove(drFound)
            End If
        Next
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    LoadTDBGridFrom()
    '    SubtractSameRow()
    '    CheckStatus()
    '    FooterTotalGrid(tdbgFrom, COL_CandidateName)
    '    FooterTotalGrid(tdbgTo, COL_CandidateName)
    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        sFind = ""
        LoadTDBGridFrom()
        SubtractSameRow()
        CheckStatus()
        FooterTotalGrid(tdbgFrom, COL_CandidateName)
        FooterTotalGrid(tdbgTo, COL_CandidateName)
    End Sub
#End Region


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1043
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 20/11/2007 09:10:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load tdbgFrom
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1043() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P1043 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(RecruitmentFileID) & COMMA 'RecruitmentFileID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkCancelCandidateID.Checked) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(sFind) 'WhereClause, varchar[1000], NOT NULL
        Return sSQL
    End Function


    Private Sub LoadTDBGridFrom()
        Dim sSQL As String = ""
        sSQL = SQLStoreD25P1043()
        'create primary key
        dtL = ReturnDataTable(sSQL)
        Dim keys(0) As DataColumn
        keys(0) = dtL.Columns("CandidateID")
        dtL.PrimaryKey = keys

        LoadDataSource(tdbgFrom, dtL)
        FooterTotalGrid(tdbgFrom, COL_CandidateName)
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

    'Private Sub btnRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRow.Click
    '    btnRow.Enabled = False
    '    If tdbgFrom.Bookmark < 0 Then Exit Sub
    '    Dim bookmark As Integer = tdbgFrom.Bookmark
    '    If bookmark > dtL.Rows.Count Then bookmark = dtL.Rows.Count
    '    Dim aSelectRows As C1.Win.C1TrueDBGrid.SelectedRowCollection
    '    aSelectRows = tdbgFrom.SelectedRows
    '    If aSelectRows.Count > 0 Then 'chọn nhiều dòng
    '        Dim i As Integer
    '        'Thêm dữ liệu lưới phải
    '        For i = 0 To aSelectRows.Count - 1
    '            CopyItem(dtL, dtR, tdbgFrom(aSelectRows.Item(i), COL_CandidateID).ToString)
    '        Next
    '        'Xoá dl lưới trái
    '        i = aSelectRows.Count - 1
    '        Dim j As Integer = aSelectRows.Item(i) 'Dùng để giảm 1 khi đã xóa đi trong lưới 1 dòng
    '        While (i >= 0)
    '            'RemoveItem(j, tdbgFrom, dtL, COL_CandidateID)
    '            i -= 1
    '            If i >= 0 Then j = aSelectRows.Item(i) - 1
    '        End While
    '    Else 'dòng có con trỏ, không chọn
    '        CopyItem(dtL, dtR, tdbgFrom.Columns(COL_CandidateID).Text)
    '        RemoveItem(tdbgFrom.Row, tdbgFrom, dtL, COL_CandidateID)
    '    End If
    '    LoadDataSource(tdbgFrom, dtL)
    '    LoadDataSource(tdbgTo, dtR)
    '    FooterTotalGrid(tdbgFrom, COL_CandidateName)
    '    FooterTotalGrid(tdbgTo, COL_CandidateName)


    '    tdbgFrom.Bookmark = bookmark
    '    btnRow.Enabled = True
    '    btnRow.Focus()
    '    CheckStatus()

    'End Sub

    Private Sub btnRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRow.Click
        btnRow.Enabled = False
        If tdbgFrom.Bookmark < 0 Then Exit Sub
        Dim bookmark As Integer = tdbgFrom.Bookmark
        'If bookmark > dtL.Rows.Count Then bookmark = dtL.Rows.Count

        CopyItem(dtL, dtR, tdbgFrom.Columns(COL_CandidateID).Text)
        RemoveItem(dtL, tdbgFrom.Columns(COL_CandidateID).Text)

        LoadDataSource(tdbgFrom, dtL)
        LoadDataSource(tdbgTo, dtR)
        FooterTotalGrid(tdbgFrom, COL_CandidateName)
        FooterTotalGrid(tdbgTo, COL_CandidateName)

        If bookmark > tdbgFrom.RowCount - 1 Then
            bookmark = tdbgFrom.RowCount - 1
        End If
        tdbgFrom.Bookmark = bookmark
        tdbgFrom.Row = bookmark
        btnRow.Enabled = True
        btnRow.Focus()
        CheckStatus()

    End Sub


    'Private Sub CopyItem(ByVal iRow As Integer, ByVal tdbgSource As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dtSource As DataTable, ByVal tdbgDes As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByRef dtDes As DataTable)
    '    Dim Row As DataRow
    '    'Row = dtDes.NewRow
    '    'For i As Integer = 0 To tdbgSource.Columns.Count - 1
    '    '    Row(i) = tdbgSource(iRow, i)
    '    'Next
    '    'dtDes.Rows.Add(Row)

    '    Row = dtSource.Rows.Find(tdbgSource.Columns(COL_CandidateID).Text)
    '    dtDes.ImportRow(Row)
    'End Sub


    Private Sub CopyItem(ByVal dtSource As DataTable, ByRef dtDes As DataTable, ByVal sKeyValue As String)

        'Row = dtDes.NewRow
        'For i As Integer = 0 To tdbgSource.Columns.Count - 1
        '    Row(i) = tdbgSource(iRow, i)
        'Next
        'dtDes.Rows.Add(Row)

        Dim Row As DataRow = dtSource.Rows.Find(sKeyValue)
        dtDes.ImportRow(Row)
    End Sub

    'Private Sub RemoveItem(ByVal iRow As Integer, ByVal tdbgSource As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByRef dtSource As DataTable, Optional ByVal iColPkey As Integer = 0)
    '    Dim myDataRow As DataRowCollection = dtSource.Rows
    '    If myDataRow.Contains(tdbgSource(iRow, iColPkey)) Then
    '        Dim row As DataRow = myDataRow.Find(tdbgSource(iRow, iColPkey))
    '        myDataRow.Remove(row)
    '    End If
    'End Sub

    Private Sub RemoveItem(ByRef dtSource As DataTable, ByVal sValue As String)
        Dim dr As DataRow = dtSource.Rows.Find(sValue)
        If dr IsNot Nothing Then
            dtSource.Rows.Remove(dr)
        End If

    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        'Dim i As Integer = tdbgFrom.RowCount - 1
        'While i >= 0
        '    CopyItem(dtL, dtR, tdbgFrom(i, COL_CandidateID).ToString)
        '    'RemoveItem(i, tdbgFrom, dtL, COL_CandidateID)
        '    RemoveItem(dtL, tdbgFrom(i, COL_CandidateID).ToString)
        '    i = tdbgFrom.RowCount - 1
        'End While

        For Each dr As DataRow In dtL.Rows
            dtR.ImportRow(dr)
        Next
        dtL.Clear()

        LoadDataSource(tdbgFrom, dtL)
        LoadDataSource(tdbgTo, dtR)
        FooterTotalGrid(tdbgFrom, COL_CandidateName)
        FooterTotalGrid(tdbgTo, COL_CandidateName)


        CheckStatus()
    End Sub

    'Private Sub btnCancelRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelRow.Click
    '    btnCancelRow.Enabled = False
    '    If tdbgTo.Bookmark < 0 Then Exit Sub
    '    Dim bookmark As Integer = tdbgTo.Bookmark
    '    If bookmark > dtR.Rows.Count Then bookmark = dtR.Rows.Count
    '    Dim aSelectRows As C1.Win.C1TrueDBGrid.SelectedRowCollection
    '    aSelectRows = tdbgTo.SelectedRows
    '    If aSelectRows.Count > 0 Then 'chọn nhiều dòng
    '        Dim i As Integer
    '        'Thêm dữ liệu lưới phải
    '        For i = 0 To aSelectRows.Count - 1

    '            CopyItem(dtL, dtR, tdbgFrom(aSelectRows.Item(i), COL_CandidateID).ToString)
    '        Next
    '        'Xoá dl lưới trái
    '        i = aSelectRows.Count - 1
    '        Dim j As Integer = aSelectRows.Item(i) 'Dùng để giảm 1 khi đã xóa đi trong lưới 1 dòng
    '        While (i >= 0)
    '            'RemoveItem(i, tdbgTo, dtR, COL_CandidateID)
    '            RemoveItem(j, tdbgTo, dtR, COL_CandidateID)
    '            i -= 1
    '            If i >= 0 Then j = aSelectRows.Item(i) - 1
    '        End While
    '    Else 'dòng có con trỏ, không chọn
    '        CopyItem(dtR, dtL, tdbgTo.Columns(COLT_CandidateID).Text)
    '        RemoveItem(dtR, tdbgTo.Columns(COL_CandidateID).Text)
    '    End If
    '    LoadDataSource(tdbgFrom, dtL)
    '    LoadDataSource(tdbgTo, dtR)

    '    FooterTotalGrid(tdbgFrom, COL_CandidateName)
    '    FooterTotalGrid(tdbgTo, COL_CandidateName)

    '    tdbgTo.Bookmark = bookmark

    '    btnCancelRow.Enabled = True
    '    btnCancelRow.Focus()
    '    CheckStatus()

    'End Sub

    Private Sub btnCancelRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelRow.Click
        btnCancelRow.Enabled = False
        If tdbgTo.Bookmark < 0 Then Exit Sub
        Dim bookmark As Integer = tdbgTo.Bookmark
        
        CopyItem(dtR, dtL, tdbgTo.Columns(COLT_CandidateID).Text)
        RemoveItem(dtR, tdbgTo.Columns(COL_CandidateID).Text)

        LoadDataSource(tdbgFrom, dtL)
        LoadDataSource(tdbgTo, dtR)

        FooterTotalGrid(tdbgFrom, COL_CandidateName)
        FooterTotalGrid(tdbgTo, COL_CandidateName)

        If bookmark > tdbgTo.RowCount - 1 Then bookmark = tdbgTo.RowCount - 1

        tdbgTo.Bookmark = bookmark
        tdbgTo.Row = bookmark
        btnCancelRow.Enabled = True
        btnCancelRow.Focus()
        CheckStatus()

    End Sub

    Private Sub btnCancelAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelAll.Click
        'Dim i As Integer = tdbgTo.RowCount - 1
        'While i >= 0
        '    CopyItem(dtR, dtL, tdbgTo(i, COLT_CandidateID).ToString)
        '    RemoveItem(dtR, tdbgTo(i, COL_CandidateID).ToString)
        '    i = tdbgTo.RowCount - 1
        'End While

        For Each dr As DataRow In dtR.Rows
            dtL.ImportRow(dr)
        Next

        dtR.Clear()

        LoadDataSource(tdbgFrom, dtL)
        LoadDataSource(tdbgTo, dtR)
        FooterTotalGrid(tdbgFrom, COL_CandidateName)
        FooterTotalGrid(tdbgTo, COL_CandidateName)

        CheckStatus()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1042
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 20/11/2007 09:20:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1042(ByVal aCandidateIDs As String) As StringBuilder
        Dim sSQL As New StringBuilder
        Dim sRet As New StringBuilder
        Dim aCandidate() As String = Microsoft.VisualBasic.Split(aCandidateIDs, ",")
        sRet.Append("DECLARE @Now datetime; SET @Now = getDate()" & vbCrLf)
        For i As Integer = 0 To aCandidate.Length - 1
            sSQL.Append("Insert Into D25T1042(")
            sSQL.Append("DivisionID, RecruitmentFileID, CandidateID,")
            sSQL.Append("CreateUserID, LastModifyUserID, CreateDate, LastModifyDate")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(RecruitmentFileID) & COMMA) 'RecruitmentFileID [KEY], varchar[20], NOT NULL
            sSQL.Append(aCandidate(i) & COMMA) 'CandidateID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("@Now" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append("@Now") 'LastModifyDate, datetime, NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub chkCancelCandidateID_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCancelCandidateID.CheckedChanged
        sFind = ""
        LoadTDBGridFrom()
        dtR.Clear()
        tdbgTo.Delete(0, tdbgTo.RowCount)
        CheckStatus()
        FooterTotalGrid(tdbgTo, COL_CandidateName)

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

        Dim bRunSQL As Boolean = ExecuteSQL(SQLInsertD25T1042(aCandidateIDs).ToString)
        If bRunSQL Then
            SaveOK()
            bFlagSave = True
        Else
            SaveNotOK()
            bFlagSave = False
        End If
        Me.Close()
    End Sub
End Class