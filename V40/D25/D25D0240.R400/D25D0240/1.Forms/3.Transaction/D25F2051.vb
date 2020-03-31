Imports System
Public Class D25F2051
    Public Const gsDateTimeShow As String = "dd/MM/yyyy hh:mm:ss"
    Public Const MaskFormatTimeMinute As String = "__:__"
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private iLastCol As Integer

#Region "Const of tdbg"
    Private Const COL_InterviewID As Integer = 0       ' InterviewID
    Private Const COL_DivisionID As Integer = 1        ' DivisionID
    Private Const COL_InterviewFileID As Integer = 2   ' InterviewFileID
    Private Const COL_CandidateID As Integer = 3       ' CandidateID
    Private Const COL_InterviewerName As Integer = 4   ' Người phỏng vấn
    Private Const COL_InterviewDate As Integer = 5     ' Ngày PV
    Private Const COL_IntTime As Integer = 6           ' Giờ PV
    Private Const COL_InterviewForm As Integer = 7     ' Nội dung
    Private Const COL_InterviewResult As Integer = 8   ' Đánh giá
    Private Const COL_EEValue01 As Integer = 9         ' EEValue01
    Private Const COL_EE01 As Integer = 10             ' EE01
    Private Const COL_EEValue02 As Integer = 11        ' EEValue02
    Private Const COL_EE02 As Integer = 12             ' EE02
    Private Const COL_EEValue03 As Integer = 13        ' EEValue03
    Private Const COL_EE03 As Integer = 14             ' EE03
    Private Const COL_EEValue04 As Integer = 15        ' EEValue04
    Private Const COL_EE04 As Integer = 16             ' EE04
    Private Const COL_EEValue05 As Integer = 17        ' EEValue05
    Private Const COL_EE05 As Integer = 18             ' EE05
    Private Const COL_EEValue06 As Integer = 19        ' EEValue06
    Private Const COL_EE06 As Integer = 20             ' EE06
    Private Const COL_EEValue07 As Integer = 21        ' EEValue07
    Private Const COL_EE07 As Integer = 22             ' EE07
    Private Const COL_EEValue08 As Integer = 23        ' EEValue08
    Private Const COL_EE08 As Integer = 24             ' EE08
    Private Const COL_EEValue09 As Integer = 25        ' EEValue09
    Private Const COL_EE09 As Integer = 26             ' EE09
    Private Const COL_EEValue10 As Integer = 27        ' EEValue10
    Private Const COL_EE10 As Integer = 28             ' EE10
    Private Const COL_Note As Integer = 29             ' Ghi chú
    Private Const COL_CreateUserID As Integer = 30     ' CreateUserID
    Private Const COL_CreateDate As Integer = 31       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 32 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 33   ' LastModifyDate
    Private Const COL_InterviewerID As Integer = 34    ' InterviewerID
#End Region

    Private _isOnlyView As Boolean
    Public WriteOnly Property IsOnlyView() As Boolean
        Set(ByVal Value As Boolean)
            _isOnlyView = Value
        End Set
    End Property

    Private _interviewFileID As String
    Public Property InterviewFileID() As String
        Get
            Return _interviewFileID
        End Get
        Set(ByVal Value As String)
            _interviewFileID = Value
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

    Private _intGroupID As String
    Public Property IntGroupID() As String
        Get
            Return _intGroupID
        End Get
        Set(ByVal Value As String)
            _intGroupID = Value
        End Set
    End Property


    Private Sub D25F2051_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D25F2051_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        _bSaved = False
        Loadlanguage()
        tdbg_NumberFormat()
        LoadTDBDropdown()
        LoadCaption()
        LoadTDBGrid()
        '*************************
        If _isOnlyView Then btnSave.Enabled = False
        iLastCol = CountCol(tdbg, tdbg.Splits.ColCount - 1)
        InputDateInTrueDBGrid(tdbg, COL_InterviewDate)
        '*************************
        InputDateCustomFormat(c1dateInterviewDate)
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Chi_tiet_ket_qua_phong_van_-_D25F2051") & UnicodeCaption(gbUnicode) 'Chi tiÕt kÕt qu¶ phàng vÊn - D25F2051
        '================================================================ 
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbdInterviewerID.Columns("InterviewerID").Caption = rL3("Ma") 'Mã
        tdbdInterviewerID.Columns("InterviewerName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("InterviewerName").Caption = rL3("Nguoi_phong_van") 'Người phỏng vấn
        tdbg.Columns("InterviewDate").Caption = rL3("Ngay_PV") 'Ngày PV
        tdbg.Columns("IntTime").Caption = rL3("Gio_PV") 'Giờ PV
        tdbg.Columns("InterviewForm").Caption = rL3("Noi_dung") 'Nội dung
        tdbg.Columns("InterviewResult").Caption = rL3("Danh_gia") 'Đánh giá
        tdbg.Columns("Note").Caption = rL3("Ghi_chu") 'Ghi chú
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_EEValue01).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue02).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue03).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue04).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue05).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue06).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue07).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue08).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue09).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_EEValue10).NumberFormat = D25Format.DefaultNumber2
    End Sub

    Private Sub LoadTDBDropdown()
        'Đổ nguồn cho DropDown InterviewerID
        Dim sSQL As New StringBuilder(197)
        sSQL.Append("SELECT InterviewerID, InterviewerName" & UnicodeJoin(gbUnicode) & " AS InterviewerName" & vbCrLf)
        sSQL.Append("FROM D25T1070 WITH(NOLOCK) " & vbCrLf)
        sSQL.Append("WHERE Disabled=0 " & vbCrLf)
        If _intGroupID <> "" Then
            sSQL.Append("AND InterviewerID IN (SELECT InterviewerID FROM D25T1090 WITH(NOLOCK)  WHERE	IntGroupID = " & SQLString(_intGroupID) & ")" & vbCrLf)
        End If
        sSQL.Append("ORDER BY InterviewerID ")

        LoadDataSource(tdbdInterviewerID, sSQL.ToString, gbUnicode)
    End Sub

    Private Sub LoadTDBGrid()
        'Bổ sung Field Unicode
        'Dim sUnicode As String = ""
        'Dim sLanguage As String = ""
        'UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        ''***************

        Dim sSQL As String
        'sSQL = " SELECT InterviewID,DivisionID,InterviewFileID,CandidateID,convert(varchar(10),InterviewDate,103)+ ' '+ convert(varchar(8),InterviewDate,108) as InterviewDate,"
        'sSQL &= " T1.InterviewerID, InterviewerName" & sUnicode & " As InterviewerName, InterviewForm" & sUnicode & " As InterviewForm, InterviewResult" & sUnicode & " As InterviewResult, T1.Note" & sUnicode & " As Note" & vbCrLf
        'sSQL &= " FROM D25T2012 T1" & vbCrLf
        'sSQL &= "Left join D25T1070 T2 On T1.InterviewerID=T2.InterviewerID" & vbCrLf
        'sSQL &= " WHERE	DivisionID =" & SQLString(gsDivisionID)
        'sSQL &= " AND InterviewFileID =" & SQLString(_interviewFileID)
        'sSQL &= " AND CandidateID=" & SQLString(_candidateID) & vbCrLf
        'sSQL &= " ORDER BY InterviewID"

        sSQL = SQLStoreD25P2051()
        LoadDataSource(tdbg, sSQL, gbUnicode)
    End Sub

    Private Sub LoadCaption()
        Dim sSQL As String = SQLStoreD25P0050()
        Dim dt As DataTable = ReturnDataTable(sSQL)

        Dim k As Integer = 0
        Dim sGiaTri As String = IIf(gbUnicode, rL3("Gia_tri_"), ConvertUnicodeToVni(rL3("Gia_tri_"))).ToString
        Dim sGhiChu As String = IIf(gbUnicode, rL3("Ghi_chu"), ConvertUnicodeToVni(rL3("Ghi_chu"))).ToString

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To 9
                tdbg.Columns(COL_EEValue01 + k).Caption = dt.Rows(i).Item("RefCaption" & UnicodeJoin(gbUnicode)).ToString & Space(1) & "(" & sGiaTri & ")"
                tdbg.Columns(COL_EE01 + k).Caption = dt.Rows(i).Item("RefCaption" & UnicodeJoin(gbUnicode)).ToString & Space(1) & "(" & sGhiChu & ")"

                tdbg.Splits(0).DisplayColumns(COL_EEValue01 + k).Visible = Not (Convert.ToBoolean(dt.Rows(i).Item("Disabled")))
                tdbg.Splits(0).DisplayColumns(COL_EE01 + k).Visible = Not (Convert.ToBoolean(dt.Rows(i).Item("Disabled")))

                tdbg.Splits(0).DisplayColumns(COL_EEValue01 + k).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Splits(0).DisplayColumns(COL_EE01 + k).HeadingStyle.Font = FontUnicode(gbUnicode)
                k += 2
            Next
        End If
        dt = Nothing
    End Sub

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_InterviewDate).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Thoi_gian"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_InterviewDate
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_InterviewerID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Nguoi_phong_van"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_InterviewerID
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_InterviewForm).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Noi_dung"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_InterviewForm
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()

        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLDeleteD25T2012() & vbCrLf)
        sSQL.Append(SQLInsertD25T2012s)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.Col = COL_InterviewerName Then
            Select Case e.KeyCode
                Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                    tdbg.Splits(0).DisplayColumns(COL_InterviewerName).AutoComplete = False
                Case Else
                    tdbg.Splits(0).DisplayColumns(COL_InterviewerName).AutoComplete = True
            End Select
        End If
        '************************
        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
            Exit Sub
        ElseIf D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            If tdbg.Col = iLastCol Then HotKeyEnterGrid(tdbg, COL_InterviewDate, e)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_InterviewDate)

    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_InterviewerName
                tdbg.Columns(COL_InterviewerID).Text = tdbdInterviewerID.Columns("InterviewerID").Text
                If tdbg.Columns(COL_InterviewDate).Text = "" Then tdbg.Columns(COL_InterviewDate).Text = Format(Now, gsDateTimeShow)
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_IntTime
                Dim dTime As Object
                dTime = ConvertTime(tdbg.Columns(e.ColIndex).Text)
                If dTime.ToString <> MaskFormatTimeMinute Then
                    tdbg.Columns(e.ColIndex).Text = dTime.ToString
                    If dTime.ToString = "00:00" Then
                        tdbg.Columns(e.ColIndex).Text = MaskFormatTimeMinute
                    End If
                Else
                    tdbg.Columns(e.ColIndex).Text = MaskFormatTimeMinute
                End If

            Case COL_InterviewerName
                If tdbg.Columns(COL_InterviewerID).Text <> tdbdInterviewerID.Columns("InterviewerID").Text Then
                    tdbg.Columns(COL_InterviewerID).Text = ""
                    tdbg.Columns(COL_InterviewerName).Text = ""
                    tdbg.Columns(COL_InterviewDate).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_InterviewDate
                tdbg.Select()
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_IntTime
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789:")
            Case COL_EEValue01, COL_EEValue02, COL_EEValue03, COL_EEValue04, COL_EEValue05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_EEValue06, COL_EEValue07, COL_EEValue08, COL_EEValue09, COL_EEValue10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2012
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 06/12/2007 01:56:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2012() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2012"
        sSQL &= " Where "
        sSQL &= "InterviewFileID = " & SQLString(InterviewFileID) & " And "
        sSQL &= "CandidateID = " & SQLString(CandidateID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2012s
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 06/12/2007 01:58:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2012s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sInterviewID As String = ""
        sSQL.Append("DECLARE @Now datetime; SET @Now = getDate()" & vbCrLf)
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D25T2012(")
            sSQL.Append("InterviewID, DivisionID, InterviewFileID, CandidateID, InterviewDate, ")
            sSQL.Append("InterviewerID, InterviewForm, InterviewResult, Note, ")
            sSQL.Append("Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, ")
            sSQL.Append("InterviewFormU, InterviewResultU, NoteU, EE01, ")
            sSQL.Append("EE02, EE03, EE04, EE05, EE06, ")
            sSQL.Append("EE07, EE08, EE09, EE010, IntTime, ")
            sSQL.Append("EE01U, EE02U, EE03U, EE04U, EE05U, EE06U, EE07U, EE08U, EE09U, EE010U,")
            sSQL.Append("EEValue03, EEValue01, EEValue02, EEValue04, ")
            sSQL.Append("EEValue05, EEValue06, EEValue07, EEValue08, EEValue09, ")
            sSQL.Append("EEValue10")
            sSQL.Append(") Values(")
            'Sinh IGE
            sInterviewID = CreateIGEs("D25T2012", "InterviewID", "25", "IR", gsStringKey, sInterviewID, tdbg.RowCount)
            tdbg(i, COL_InterviewID) = sInterviewID
            '-----------------
            sSQL.Append(SQLString(sInterviewID) & COMMA) 'InterviewID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NULL
            sSQL.Append(SQLString(InterviewFileID) & COMMA) 'InterviewFileID, varchar[20], NULL
            sSQL.Append(SQLString(CandidateID) & COMMA) 'CandidateID, varchar[20], NULL
            'sSQL.Append("'" & Format(CDate(tdbg(i, COL_InterviewDate)), gsDateTimeSave) & "'" & COMMA) 'InterviewDate, datetime, NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_InterviewDate)) & COMMA) 'InterviewDate, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COL_InterviewerID)) & COMMA) 'InterviewerID, varchar[20], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_InterviewForm), gbUnicode, False) & COMMA) 'InterviewForm, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_InterviewResult), gbUnicode, False) & COMMA) 'InterviewResult, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, False) & COMMA) 'Note, varchar[250], NULL
            sSQL.Append(SQLNumber(0) & COMMA) 'Disabled, tinyint, NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append("@Now" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("@Now" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_InterviewForm), gbUnicode, True) & COMMA) 'InterviewFormU, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_InterviewResult), gbUnicode, True) & COMMA) 'InterviewResultU, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, True) & COMMA) 'NoteU, nvarchar, NOT NULL

            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE01), gbUnicode, False) & COMMA) 'EE01, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE02), gbUnicode, False) & COMMA) 'EE02, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE03), gbUnicode, False) & COMMA) 'EE03, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE04), gbUnicode, False) & COMMA) 'EE04, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE05), gbUnicode, False) & COMMA) 'EE05, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE06), gbUnicode, False) & COMMA) 'EE06, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE07), gbUnicode, False) & COMMA) 'EE07, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE08), gbUnicode, False) & COMMA) 'EE08, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE09), gbUnicode, False) & COMMA) 'EE09, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE10), gbUnicode, False) & COMMA) 'EE010, varchar[500], NOT NULL

            sSQL.Append(SQLString(ConvertTimeToString(tdbg(i, COL_IntTime).ToString)) & COMMA) 'IntTime, datetime, NOT NULL

            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE01), gbUnicode, True) & COMMA) 'EE01, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE02), gbUnicode, True) & COMMA) 'EE02, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE03), gbUnicode, True) & COMMA) 'EE03, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE04), gbUnicode, True) & COMMA) 'EE04, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE05), gbUnicode, True) & COMMA) 'EE05, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE06), gbUnicode, True) & COMMA) 'EE06, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE07), gbUnicode, True) & COMMA) 'EE07, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE08), gbUnicode, True) & COMMA) 'EE08, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE09), gbUnicode, True) & COMMA) 'EE09, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_EE10), gbUnicode, True) & COMMA) 'EE010, varchar[500], NOT NULL


            sSQL.Append(SQLMoney(tdbg(i, COL_EEValue03), D25Format.DefaultNumber2) & COMMA) 'EEValue03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_EEValue01), D25Format.DefaultNumber2) & COMMA) 'EEValue01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_EEValue02), D25Format.DefaultNumber2) & COMMA) 'EEValue02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_EEValue04), D25Format.DefaultNumber2) & COMMA) 'EEValue04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_EEValue05), D25Format.DefaultNumber2) & COMMA) 'EEValue05, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_EEValue06), D25Format.DefaultNumber2) & COMMA) 'EEValue06, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_EEValue07), D25Format.DefaultNumber2) & COMMA) 'EEValue07, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_EEValue08), D25Format.DefaultNumber2) & COMMA) 'EEValue08, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_EEValue09), D25Format.DefaultNumber2) & COMMA) 'EEValue09, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_EEValue10), D25Format.DefaultNumber2)) 'EEValue10, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P0050
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 31/12/2010 01:38:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P0050() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P0050 "
        sSQL &= SQLString("D25T2011") & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2051
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 31/12/2010 01:39:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2051() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2051 "
        sSQL &= SQLString(_intGroupID) & COMMA 'IntGroupID, varchar[50], NOT NULL
        sSQL &= SQLString(_interviewFileID) & COMMA 'InterviewFileID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(_candidateID)
        Return sSQL
    End Function

End Class