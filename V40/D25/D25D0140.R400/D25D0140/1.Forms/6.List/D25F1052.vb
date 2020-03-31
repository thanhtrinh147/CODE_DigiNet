Public Class D25F1052
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbgMaster"
    Private Const COL_Description As Integer = 0       ' Diễn giải
    Private Const COL_Certificates As Integer = 1      ' Văn bằng
    Private Const COL_SchoolID As Integer = 2          ' SchoolID
    Private Const COL_SchoolName As Integer = 3        ' Trường học
    Private Const COL_MajorID As Integer = 4           ' MajorID
    Private Const COL_MajorName As Integer = 5         ' Ngành học
    Private Const COL_DateStarted As Integer = 6       ' Bắt đầu
    Private Const COL_DateEnded As Integer = 7         ' Kết thúc
    Private Const COL_EducationFormID As Integer = 8   ' EducationFormID
    Private Const COL_EducationFormName As Integer = 9 ' Loại hình đào tạo
    Private Const COL_TransEducationID As Integer = 10 ' TransEducationID
#End Region
#Region "Const of tdbgDetail"
    Private Const COLD_Description As Integer = 0       ' Diễn giải
    Private Const COLD_TransLanguageID As Integer = 1   ' TransLanguageID
    Private Const COLD_LanguageID As Integer = 2        ' LanguageID
    Private Const COLD_LanguageName As Integer = 3      ' Ngoại ngữ
    Private Const COLD_LanguageLevelID As Integer = 4   ' LanguageLevelID
    Private Const COLD_LanguageLevelName As Integer = 5 ' Cấp độ
    Private Const COLD_Listening As Integer = 6         ' Nghe
    Private Const COLD_Speaking As Integer = 7          ' Nói
    Private Const COLD_Reading As Integer = 8           ' Đọc
    Private Const COLD_Writing As Integer = 9           ' Viết
    Private Const COLD_ListeningID As Integer = 10      ' ListeningID
    Private Const COLD_ReadingID As Integer = 11        ' ReadingID
    Private Const COLD_SpeakingID As Integer = 12       ' SpeakingID
    Private Const COLD_WritingID As Integer = 13        ' WritingID
#End Region
#Region "Const of tdbgComputing"
    Private Const COL3_Description As Integer = 0          ' Diễn giải
    Private Const COL3_ComputingCertificate As Integer = 1 ' Văn bằng
    Private Const COL3_ComputingLevel As Integer = 2     ' ComputingLevelID
    Private Const COL3_ComputingLevelName As Integer = 3   ' Cấp độ
    Private Const COL3_SchoolID As Integer = 4             ' SchoolID
    Private Const COL3_SchoolName As Integer = 5           ' Trường học
    Private Const COL3_CreateUserID As Integer = 6         ' CreateUserID
    Private Const COL3_CreateDate As Integer = 7           ' CreateDate
#End Region

    ' Update 23/05/2011 - Chuẩn unicode theo DC25 _ TIENDAU
    Dim dtStudy As DataTable
    Dim _CandidateID As String = ""

    Public Property CandidateID() As String
        Get
            Return _CandidateID
        End Get
        Set(ByVal value As String)
            _CandidateID = value
        End Set
    End Property
    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            LoadTDBDropDown()

            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub D25F1052_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbgStudy)
            Exit Sub
        End If
    End Sub

    Private Sub D25F1052_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        LoadTDBGridStudy()
        LoadTDBGridLanguage()
        LoadTdbgComputing()
        '*****
        'tdbgStudy.Columns(COL_DateStarted).Editor = c1dateDateStart
        'tdbgStudy.Columns(COL_DateEnded).Editor = c1dateDateEnd
        '*****
        'Phải bỏ khai báo hằng của cột cần chuyển sang Unicode (bỏ Const khai báo cột)
        'Bổ sung nhập liệu Unicode: hàm này để sau hàm LoadLanguage
        'UnicodeGridDataField(tdbgStudy, UnicodeArrayCOL_Study(), gbUnicode) 'sửa dataField và hằng của 1 cột
        'UnicodeGridDataField(tdbgLanguage, UnicodeArrayCOL_Language(), gbUnicode) 'sửa dataField và hằng của 1 cột
        'UnicodeGridDataField(tdbgComputing, UnicodeArrayCOL_Computing(), gbUnicode) 'sửa dataField và hằng của 1 cột
        ''***************
        InputDateInTrueDBGrid(tdbgStudy, COL_DateStarted, COL_DateEnded)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    'Private Function UnicodeArrayCOL_Study() As Integer()
    '    If Not gbUnicode Then Return Nothing

    '    Dim ArrCOL() As Integer = {COL_Description, COL_Certificates, COL_SchoolName, COL_MajorName, COL_EducationFormName}

    '    Return ArrCOL
    'End Function

    'Private Function UnicodeArrayCOL_Language() As Integer()
    '    If Not gbUnicode Then Return Nothing

    '    Dim ArrCOL() As Integer = {COLD_Description, COLD_LanguageName, COLD_LanguageLevelName, COLD_Listening, COLD_Reading, COLD_Speaking, COLD_Writing}

    '    Return ArrCOL
    'End Function

    'Private Function UnicodeArrayCOL_Computing() As Integer()
    '    If Not gbUnicode Then Return Nothing

    '    Dim ArrCOL() As Integer = {COL3_Description, COL3_ComputingCertificate, COL3_ComputingLevelName, COL3_SchoolName}

    '    Return ArrCOL
    'End Function

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Qua_trinh_dao_tao_-_D25F1052") & UnicodeCaption(gbUnicode) 'QuÀ trØnh ¢ªo tÁo - D25F1052
        '================================================================ 

        lblEducation.Text = rl3("Qua_trinh_hoc_tap") 'Quá trình học tập
        lblLanguage.Text = rl3("Trinh_do_ngoai_ngu") 'Trình độ ngoại ngữ
        lblComputingLevel.Text = rl3("Trinh_do_tin_hoc") 'Trình độ tin học
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbdSchoolName.Columns("SchoolID").Caption = rl3("Ma") 'Mã
        tdbdSchoolName.Columns("SchoolName").Caption = rl3("Ten") 'Tên
        tdbdMajorName.Columns("MajorID").Caption = rl3("Ma") 'Mã
        tdbdMajorName.Columns("MajorName").Caption = rl3("Ten") 'Tên
        tdbdLanguageName.Columns("LanguageID").Caption = rl3("Ma") 'Mã
        tdbdLanguageName.Columns("LanguageName").Caption = rl3("Ten") 'Tên
        tdbdLanguageLevelName.Columns("LanguageLevelID").Caption = rl3("Ma") 'Mã
        tdbdLanguageLevelName.Columns("LanguageLevelName").Caption = rl3("Ten") 'Tên
        tdbdEducationFormName.Columns("EducationFormID").Caption = rl3("Ma") 'Mã
        tdbdEducationFormName.Columns("EducationFormName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbgStudy.Columns("SchoolName").Caption = rl3("Truong_hoc") 'Trường học
        tdbgStudy.Columns("MajorName").Caption = rl3("Nganh_hoc") 'Ngành học
        tdbgStudy.Columns("DateStarted").Caption = rl3("Bat_dau") 'Bắt đầu
        tdbgStudy.Columns("DateEnded").Caption = rl3("Ket_thuc") 'Kết thúc
        tdbgStudy.Columns("EducationFormName").Caption = rl3("Loai_hinh_dao_tao") 'Loại hình đào tạo
        tdbgStudy.Columns("Certificates").Caption = rl3("Van_bang") 'Văn bằng
        tdbgStudy.Columns("Description").Caption = rl3("Dien_giai")
        '================================================================ 
        tdbgLanguage.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbgLanguage.Columns("LanguageName").Caption = rl3("Ngoai_ngu") 'Ngoại ngữ
        tdbgLanguage.Columns("LanguageLevelName").Caption = rl3("Cap_do") 'Cấp độ
        tdbgLanguage.Columns("Listening").Caption = rl3("Nghe") 'Nghe
        tdbgLanguage.Columns("Speaking").Caption = rl3("Noi") 'Nói
        tdbgLanguage.Columns("Reading").Caption = rl3("Doc") 'Đọc
        tdbgLanguage.Columns("Writing").Caption = rl3("Viet") 'Viết
        '================================================================ 
        tdbgComputing.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbgComputing.Columns("ComputingCertificate").Caption = rl3("Van_bang") 'Văn bằng
        tdbgComputing.Columns("ComputingLevelName").Caption = rl3("Cap_do") 'Cấp độ
        tdbgComputing.Columns("SchoolName").Caption = rl3("Truong_hoc") 'Trường học
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        '*Thay doi ngay 12/3/2013 theo ID 54205 của Tuyền Nguyễn boi Văn Vinh
        sSQL = " --Do nguon cho dropdown truong hoc" & vbCrLf
        sSQL &= " SELECT '+' As SchoolID, " & NewName & "  As  SchoolName, 0 As DisplayOrder  " & vbCrLf
        sSQL &= " UNION " & vbCrLf
        sSQL &= " SELECT SchoolID,  SchoolName" & UnicodeJoin(gbUnicode) & " As SchoolName, 1 As DisplayOrder" & vbCrLf
        sSQL &= " FROM	D09T0213 WITH(NOLOCK)  WHERE	Disabled = 0 ORDER BY DisplayOrder, SchoolID"
        ''Load tdbdSchoolName
        'sSQL &= "Select	SchoolID, SchoolName" & UnicodeJoin(gbUnicode) & " As SchoolName" & vbCrLf
        'sSQL &= "From D09T0213" & vbCrLf
        'sSQL &= "Where Disabled = 0 " & vbCrLf
        'sSQL &= "Order by SchoolID"
        LoadDataSource(tdbdSchoolName, sSQL, gbUnicode)

        sSQL = "--DO nguon cho dropdown nganh hoc" & vbCrLf
        sSQL &= " SELECT '+' As MajorID, " & NewName & "  As  MajorName, 0 As DisplayOrder " & vbCrLf
        sSQL &= " UNION " & vbCrLf
        sSQL &= " SELECT	MajorID, MajorName" & UnicodeJoin(gbUnicode) & " As MajorName, 1 As DisplayOrder " & vbCrLf
        sSQL &= " FROM	D09T0212 WITH(NOLOCK)  WHERE	Disabled = 0 ORDER BY	DisplayOrder, MajorID"
        ''Load tdbdMajorName
        'sSQL = "Select MajorID, MajorName" & UnicodeJoin(gbUnicode) & " As MajorName" & vbCrLf
        'sSQL &= "From D09T0212" & vbCrLf
        'sSQL &= "Where Disabled = 0 " & vbCrLf
        'sSQL &= "Order by MajorID"
        LoadDataSource(tdbdMajorName, sSQL, gbUnicode)

        sSQL = "--DO nguon cho dropdown ngoai ngu " & vbCrLf
        sSQL &= "SELECT 		'+' As LanguageID, " & NewName & "  As  LanguageName, 0 As DisplayOrder  " & vbCrLf
        sSQL &= " UNION " & vbCrLf
        sSQL &= " SELECT	LanguageID, LanguageName" & UnicodeJoin(gbUnicode) & " As LanguageName, 1 As DisplayOrder " & vbCrLf
        sSQL &= " FROM	D09T0207 WITH(NOLOCK)  WHERE	Disabled = 0 ORDER BY	DisplayOrder, LanguageID"
        ''Load tdbdLanguageName
        'sSQL = "Select	LanguageID, LanguageName" & UnicodeJoin(gbUnicode) & "  As LanguageName " & vbCrLf
        'sSQL &= "From D09T0207" & vbCrLf
        'sSQL &= "Where Disabled = 0 " & vbCrLf
        'sSQL &= "Order by LanguageID"
        LoadDataSource(tdbdLanguageName, sSQL, gbUnicode)

        sSQL = "--Do nguon cho dropdown trinh do ngoai ngu" & vbCrLf
        sSQL &= " SELECT 		'+' As LanguageLevelID, " & NewName & "  As  LanguageLevelName, 0 As DisplayOrder  " & vbCrLf
        sSQL &= " UNION " & vbCrLf
        sSQL &= " SELECT	LanguageLevelID, LanguageLevelName" & UnicodeJoin(gbUnicode) & " As LanguageLevelName, 1 As DisplayOrder " & vbCrLf
        sSQL &= " FROM	D09T0208 WITH(NOLOCK)  WHERE	Disabled = 0 ORDER BY	DisplayOrder, LanguageLevelID"
        ''Load tdbdLanguageLevelName
        'sSQL = "Select	LanguageLevelID, LanguageLevelName" & UnicodeJoin(gbUnicode) & "  As LanguageLevelName" & vbCrLf
        'sSQL &= "From D09T0208" & vbCrLf
        'sSQL &= "Where	Disabled = 0 " & vbCrLf
        'sSQL &= "Order by LanguageLevelID"
        LoadDataSource(tdbdLanguageLevelName, sSQL, gbUnicode)
        '**********************************************
        'Load tdbdEducationFormName
        sSQL = "Select	EducationFormID, EducationFormName" & UnicodeJoin(gbUnicode) & "   As EducationFormName" & vbCrLf
        sSQL &= "From D09T0223 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where	Disabled = 0 " & vbCrLf
        sSQL &= "Order by	EducationFormID"
        LoadDataSource(tdbdEducationFormName, sSQL, gbUnicode)

        'Load tdbdLookupID
        sSQL = "Select LookupID ,Description" & UnicodeJoin(gbUnicode) & "   As Description, LookupType" & vbCrLf
        sSQL &= "From D91T0320 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "Order by DisplayOrder, LookupID" & vbCrLf
        Dim dtLookupID As DataTable = ReturnDataTable(sSQL)

        'Speaking, listening, reading
        LoadDataSource(tdbdLookupID, ReturnTableFilter(dtLookupID, "LookupType = 'D09_AssessType'"), gbUnicode)

        'dropdown tdbdComputingLevelName
        LoadDataSource(tdbdComputingLevelName, ReturnTableFilter(dtLookupID, "LookupType = 'D09_ComputingLevel'"), gbUnicode)
    End Sub

    Private Sub LoadTDBGridStudy()
        Dim sSQL As String = ""

        ' Đổ nguồn cho lưới (Quá trình học tập)
        sSQL = " Select T1.Description" & UnicodeJoin(gbUnicode) & " as Description, T1.TransEducationID, T1.SchoolID, T2.SchoolName" & UnicodeJoin(gbUnicode) & "  as SchoolName, " & vbCrLf
        sSQL &= " T1.MajorID, T3.MajorName" & UnicodeJoin(gbUnicode) & " as MajorName, " & vbCrLf
        sSQL &= " convert(varchar(10),T1.DateStarted,103) as DateStarted, convert(varchar(10),T1.DateEnded,103) as DateEnded, " & vbCrLf
        sSQL &= " T1.EducationFormID, T4.EducationFormName" & UnicodeJoin(gbUnicode) & "  as EducationFormName, T1.Certificates" & UnicodeJoin(gbUnicode) & "  as Certificates" & vbCrLf
        sSQL &= " From D25T1050 T1  WITH(NOLOCK) Left Join D09T0213 T2 WITH(NOLOCK)  On T2.SchoolID = T1.SchoolID " & vbCrLf
        sSQL &= " Left Join D09T0212 T3  WITH(NOLOCK) On T3.MajorID = T1.MajorID Left Join D09T0223 T4  WITH(NOLOCK) On T4.EducationFormID = T1.EducationFormID" & vbCrLf
        sSQL &= " Where	DivisionID = " & SQLString(gsDivisionID) & " And CandidateID = " & SQLString(_CandidateID) & vbCrLf
        sSQL &= " Order by T1.SchoolID"
        dtStudy = ReturnDataTable(sSQL)
        LoadDataSource(tdbgStudy, dtStudy, gbUnicode)
    End Sub

    Private Sub LoadTDBGridLanguage()
        Dim sSQL As String = ""

        sSQL = "Select T1.Description" & UnicodeJoin(gbUnicode) & "  as Description, T1.TransLanguageID, T1.LanguageID, T2.LanguageName" & UnicodeJoin(gbUnicode) & "  as LanguageName, " & vbCrLf
        sSQL &= "T1.LanguageLevelID, T3.LanguageLevelName" & UnicodeJoin(gbUnicode) & "  as LanguageLevelName, " & vbCrLf
        sSQL &= "T1.Listening AS ListeningID, T1.Speaking AS SpeakingID, T1.Reading AS ReadingID, T1.Writing AS WritingID, " & vbCrLf
        sSQL &= "D5.Description" & UnicodeJoin(gbUnicode) & "  as Speaking, " & vbCrLf
        sSQL &= "D6.Description" & UnicodeJoin(gbUnicode) & "  as Listening, " & vbCrLf
        sSQL &= "D7.Description" & UnicodeJoin(gbUnicode) & "  as Writing, " & vbCrLf
        sSQL &= "D8.Description" & UnicodeJoin(gbUnicode) & "  as Reading" & vbCrLf
        sSQL &= "From D25T1051 T1  WITH(NOLOCK) Left Join D09T0207 T2 WITH(NOLOCK)  On T2.LanguageID=T1.LanguageID " & vbCrLf
        sSQL &= "Left join 	D09T0208 T3  WITH(NOLOCK) On T3.LanguageLevelID=T1.LanguageLevelID" & vbCrLf
        sSQL &= "LEFT JOIN 	D91T0320 D5  WITH(NOLOCK) ON T1.Speaking = D5.LookupID AND D5.LookupType = 'D09_AssessType'" & vbCrLf
        sSQL &= "LEFT JOIN 	D91T0320 D6  WITH(NOLOCK) ON T1.Listening = D6.LookupID AND D6.LookupType = 'D09_AssessType'" & vbCrLf
        sSQL &= "LEFT JOIN 	D91T0320 D7  WITH(NOLOCK) ON T1.Writing = D7.LookupID AND D7.LookupType = 'D09_AssessType'" & vbCrLf
        sSQL &= "LEFT JOIN 	D91T0320 D8  WITH(NOLOCK) ON T1.Reading = D8.LookupID AND D8.LookupType = 'D09_AssessType'"
        sSQL &= "Where	DivisionID = " & SQLString(gsDivisionID) & " And CandidateID = " & SQLString(_CandidateID)
        LoadDataSource(tdbgLanguage, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTdbgComputing()
        Dim sSQL As String = ""
        sSQL &= " SELECT T1.DivisionID,T1.CandidateID,T1.ComputingCertificate" & UnicodeJoin(gbUnicode) & " as ComputingCertificate" & vbCrLf
        sSQL &= " ,T1.ComputingLevel,T1.Disabled,T1.SchoolID,T1.Description" & UnicodeJoin(gbUnicode) & " as Description" & vbCrLf
        sSQL &= " ,T1.CreateUserID,T1.CreateDate,T1.LastModifyUserID,T1.LastModifyDate" & vbCrLf
        sSQL &= " ,T2.Description" & UnicodeJoin(gbUnicode) & "  AS ComputingLevelName, T3.SchoolName" & UnicodeJoin(gbUnicode) & "  as SchoolName" & vbCrLf
        sSQL &= " FROM D25T1054 T1 WITH(NOLOCK)  LEFT JOIN D91T0320 T2 WITH(NOLOCK)  ON T1.ComputingLevel = T2.LookupID  AND T2.LookupType = 'D09_ComputingLevel' " & vbCrLf
        sSQL &= " LEFT JOIN D09T0213 T3 WITH(NOLOCK)  ON T3.SchoolID = T1.SchoolID  " & vbCrLf
        sSQL &= " WHERE	DivisionID =  " & SQLString(gsDivisionID) & " And CandidateID = " & SQLString(_CandidateID) & vbCrLf

        LoadDataSource(tdbgComputing, sSQL, gbUnicode)
    End Sub

    Private Function AllowSave() As Boolean

        For i As Integer = 0 To tdbgLanguage.RowCount - 1
            For j As Integer = i + 1 To tdbgLanguage.RowCount - 1
                If tdbgLanguage(j, COLD_LanguageName).ToString = tdbgLanguage(i, COLD_LanguageName).ToString And tdbgLanguage(j, COLD_LanguageLevelName).ToString = tdbgLanguage(i, COLD_LanguageLevelName).ToString Then
                    'D99C0008.MsgNotYetChoose(rl3("Ngoai_ngu") & " " & rl3("_va_") & " " & rl3("Cap_do"))

                    D99C0008.MsgL3(rl3("Ngoai_ngu") & " " & rl3("_va_") & " " & rl3("Cap_do") & " " & rl3("Da_duoc_chon"))
                    tdbgLanguage.Col = COLD_LanguageName
                    tdbgLanguage.Row = i
                    tdbgLanguage.Focus()
                    Return False
                End If
            Next
        Next

        'If tdbgMaster.RowCount <= 0 And tdbgDetail.RowCount <= 0 Then
        '    D99C0008.MsgL3("Bạn phải chọn thông tin để lưu.")
        '    tdbgMaster.Focus()
        '    Return False
        'End If


        'comment 16/10/08
        ''Kiểm tra cho lưới master
        'Dim i As Integer = 0
        'Dim j As Integer = 0
        'For i = 0 To tdbgMaster.RowCount - 2
        '    For j = i + 1 To tdbgMaster.RowCount - 1
        '        If tdbgMaster(i, COL_SchoolID).ToString = tdbgMaster(j, COL_SchoolID).ToString And tdbgMaster(i, COL_MajorID).ToString = tdbgMaster(j, COL_MajorID).ToString And tdbgMaster(i, COL_EducationFormID).ToString = tdbgMaster(j, COL_EducationFormID).ToString And tdbgMaster(i, COL_Certificates).ToString = tdbgMaster(j, COL_Certificates).ToString Then
        '            D99C0008.MsgL3(rl3("Thong_tin_nay_da_ton_tai"))
        '            tdbgMaster.Col = COL_SchoolID
        '            tdbgMaster.Row = j
        '            tdbgMaster.Focus()
        '            Return False
        '        End If
        '    Next
        'Next
        ''Kiểm tra cho lưới Detail
        'For i = 0 To tdbgDetail.RowCount - 2
        '    For j = i + 1 To tdbgDetail.RowCount - 1
        '        If tdbgDetail(i, COLD_LanguageID).ToString = tdbgDetail(j, COLD_LanguageID).ToString And tdbgDetail(i, COLD_LanguageLevelID).ToString = tdbgDetail(j, COLD_LanguageLevelID).ToString Then
        '            D99C0008.MsgL3(rl3("Thong_tin_nay_da_ton_tai"))
        '            tdbgDetail.Col = COLD_LanguageID
        '            tdbgDetail.Row = j
        '            tdbgDetail.Focus()
        '            Return False
        '        End If
        '    Next
        'Next
        'end comment 16/10/08
        Return True
    End Function

    Private Sub tdbgMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgStudy.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                HotKeyF7(tdbgStudy)
                Exit Sub
            Case Keys.F8
                Select Case tdbgStudy.Col
                    Case COL_SchoolName, COL_MajorID, COL_EducationFormName
                        HotKeyF8_Name(tdbgStudy)
                        Exit Sub
                    Case Else
                        HotKeyF8(tdbgStudy)
                        Exit Sub
                End Select
            Case Keys.Enter
                If D25Options.UseEnterAsTab And tdbgStudy.Col = COL_EducationFormName Then
                    HotKeyEnterGrid(tdbgStudy, COL_Description, e)
                    Exit Sub
                End If

            Case Keys.F2
                If tdbgStudy.Col = COL_SchoolName Then
                    'Dim f As New D91F6010
                    'f.InListID = "71"
                    'f.InWhere = ""
                    'f.ShowDialog()
                    'For Each dr As DataRow In CType(tdbdSchoolName.DataSource, DataTable).Rows
                    '    If dr("SchoolID").ToString = f.OutPut01 Then
                    '        tdbgStudy.Columns(COL_SchoolID).Text = f.OutPut01
                    '        tdbgStudy.Columns(COL_SchoolName).Text = dr("SchoolName").ToString
                    '        tdbgStudy.UpdateData()
                    '    End If
                    'Next

                    'f.Dispose()

                    'ID 79397 4/9/2015
                    Try
                        Dim arrPro() As StructureProperties = Nothing
                        SetProperties(arrPro, "InListID", "71")
                        SetProperties(arrPro, "InWhere", "")
                        Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6010", arrPro)
                        Dim sKey As String = GetProperties(frm, "Output01").ToString
                        If sKey <> "" Then
                            'Load dữ liệu
                            For Each dr As DataRow In CType(tdbdSchoolName.DataSource, DataTable).Rows
                                If dr("SchoolID").ToString = sKey Then
                                    tdbgStudy.Columns(COL_SchoolID).Text = sKey
                                    tdbgStudy.Columns(COL_SchoolName).Text = dr("SchoolName").ToString
                                    tdbgStudy.UpdateData()
                                End If
                            Next

                        End If
                    Catch ex As Exception
                        D99C0008.MsgL3(ex.Message)
                    End Try
                End If

        End Select
        If e.Shift And e.KeyCode = Keys.Insert Then 'And tdbgStudy.Col = COL_SchoolName Then
            HotKeyShiftInsert(tdbgStudy)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbgStudy, COL_Description)

    End Sub

    Private Sub tdbgMaster_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgStudy.AfterColUpdate
        Dim sKeyName As String = ""
        Dim sKeyID As String = ""
        Dim sSQL As String = ""
        Select Case e.ColIndex
            Case COL_DateStarted, COL_DateEnded
                tdbgStudy.Select()
            Case COL_SchoolName
                tdbgStudy.Columns(COL_SchoolID).Text = tdbdSchoolName.Columns("SchoolID").Value.ToString
                tdbgStudy.Columns(COL_SchoolName).Text = tdbdSchoolName.Columns("SchoolName").Value.ToString
                '*Them ngay 12/3/2013 theo ID 54205
                AddNewShoolName(tdbgStudy, e.ColIndex, COL_SchoolID, COL_SchoolName)
                '**********************************
            Case COL_MajorName
                tdbgStudy.Columns(COL_MajorID).Text = tdbdMajorName.Columns("MajorID").Value.ToString
                tdbgStudy.Columns(COL_MajorName).Text = tdbdMajorName.Columns("MajorName").Value.ToString
                '*Them ngay 12/3/2013 theo ID 54205
                If tdbgStudy.Columns(COL_MajorID).Text = "+" Then
                    tdbgStudy.Columns(COL_MajorID).Text = ""
                    tdbgStudy.Columns(e.ColIndex).Text = ""
                    If ReturnPermission("D09F0310") < EnumPermission.Add Then
                        MsgNoPermissionAdd()
                    Else
                        '                        Dim f As New D09F0129
                        '                        f.formID = "D09F0311"
                        '                        f.FormPermission = "D09F0310"
                        '                        f.FormState = "1"
                        '                        f.ShowDialog()
                        '                        sKeyID = f.RelationID
                        '                        sKeyName = f.RelationName
                        '                        f.Dispose()
                        Dim arrPro() As StructureProperties = Nothing
                        '  SetProperties(arrPro, xxxxxx, DxxFxxxxx)
                        SetProperties(arrPro, "FormIDPermission", "D09F0310")
                        'SetProperties(arrPro, "FormState", CByte(1))
                        SetProperties(arrPro, "FormState", CByte(0)) ' ID 119774 09/05/2019
                        Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0311", arrPro)
                        sKeyName = L3String(GetProperties(frm, "MajorName"))
                        sKeyID = L3String(GetProperties(frm, "MajorID"))
                        If sKeyName <> "" Then
                            'Load tdbdRelationID
                            sSQL = "--Do nguon cho dropdown nganh hoc" & vbCrLf
                            sSQL &= " SELECT '+' As MajorID, " & NewName & "  As  MajorName, 0 As DisplayOrder " & vbCrLf
                            sSQL &= " UNION " & vbCrLf
                            sSQL &= " SELECT	MajorID, MajorName" & UnicodeJoin(gbUnicode) & " As MajorName, 1 As DisplayOrder " & vbCrLf
                            sSQL &= " FROM	D09T0212  WITH(NOLOCK) WHERE	Disabled = 0 ORDER BY	DisplayOrder, MajorID"
                            LoadDataSource(tdbdMajorName, sSQL, gbUnicode)
                            tdbgStudy.Columns(COL_MajorID).Text = sKeyID
                            tdbgStudy.Columns(e.ColIndex).Text = sKeyName
                            tdbgStudy.UpdateData()
                        End If
                    End If
                End If
                '**********************************
            Case COL_EducationFormName
                tdbgStudy.Columns(COL_EducationFormID).Text = tdbdEducationFormName.Columns("EducationFormID").Value.ToString
                tdbgStudy.Columns(COL_EducationFormName).Text = tdbdEducationFormName.Columns("EducationFormName").Value.ToString
        End Select
    End Sub

    Private Sub tdbgMaster_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgStudy.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_SchoolName
                If tdbgStudy.Columns(COL_SchoolName).Text <> tdbdSchoolName.Columns("SchoolName").Text Then
                    tdbgStudy.Columns(COL_SchoolID).Text = ""
                    tdbgStudy.Columns(COL_SchoolName).Text = ""
                End If
            Case COL_MajorName
                If tdbgStudy.Columns(COL_MajorName).Text <> tdbdMajorName.Columns("MajorName").Text Then
                    tdbgStudy.Columns(COL_MajorID).Text = ""
                    tdbgStudy.Columns(COL_MajorName).Text = ""
                End If
            Case COL_EducationFormName
                If tdbgStudy.Columns(COL_EducationFormName).Text <> tdbdEducationFormName.Columns("EducationFormName").Text Then
                    tdbgStudy.Columns(COL_EducationFormID).Text = ""
                    tdbgStudy.Columns(COL_EducationFormName).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbgMaster_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgStudy.ComboSelect
        tdbgStudy.UpdateData()
        'Select Case e.ColIndex
        '    Case COL_SchoolName
        '        tdbgStudy.Columns(COL_SchoolID).Text = tdbdSchoolName.Columns("SchoolID").Value.ToString
        '        tdbgStudy.Columns(COL_SchoolName).Text = tdbdSchoolName.Columns("SchoolName").Value.ToString
        '    Case COL_MajorName
        '        tdbgStudy.Columns(COL_MajorID).Text = tdbdMajorName.Columns("MajorID").Value.ToString
        '        tdbgStudy.Columns(COL_MajorName).Text = tdbdMajorName.Columns("MajorName").Value.ToString
        '    Case COL_EducationFormName
        '        tdbgStudy.Columns(COL_EducationFormID).Text = tdbdEducationFormName.Columns("EducationFormID").Value.ToString
        '        tdbgStudy.Columns(COL_EducationFormName).Text = tdbdEducationFormName.Columns("EducationFormName").Value.ToString
        'End Select
    End Sub

    Private Sub tdbgLanguage_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgLanguage.AfterColUpdate
        Dim sKeyName As String = ""
        Dim sKeyID As String = ""
        Dim sSQL As String = ""
        Select Case e.ColIndex
            Case COLD_LanguageName
                If CheckDuplicateLanguage(tdbgLanguage.Columns(COLD_LanguageName).Text, tdbgLanguage.Columns(COLD_LanguageLevelName).Text, tdbgLanguage.Row) Then
                    D99C0008.MsgL3(rl3("Ngoai_ngu_va_cap_do_nay_da_duoc_chon"))
                    tdbgLanguage.Columns(COLD_LanguageName).Text = ""
                    tdbgLanguage.Columns(COLD_LanguageID).Text = ""
                Else
                    tdbgLanguage.Columns(COLD_LanguageID).Text = tdbdLanguageName.Columns("LanguageID").Value.ToString
                    tdbgLanguage.Columns(COLD_LanguageName).Text = tdbdLanguageName.Columns("LanguageName").Value.ToString
                    '*Them ngay 12/3/2013 theo ID 54205
                    If tdbgLanguage.Columns(COLD_LanguageID).Text = "+" Then
                        tdbgLanguage.Columns(COLD_LanguageID).Text = ""
                        tdbgLanguage.Columns(e.ColIndex).Text = ""
                        If ReturnPermission("D09F0250") < EnumPermission.Add Then
                            MsgNoPermissionAdd()
                        Else
                            '                            Dim f As New D09F0129
                            '                            f.formID = "D09F0251"
                            '                            f.FormPermission = "D09F0250"
                            '                            f.FormState = "1"
                            '                            f.ShowDialog()
                            '                            sKeyID = f.RelationID
                            '                            sKeyName = f.RelationName
                            '                            f.Dispose()
                            Dim arrPro() As StructureProperties = Nothing
                            '  SetProperties(arrPro, xxxxxx, DxxFxxxxx)
                            SetProperties(arrPro, "FormIDPermission", "D09F0250")
                            'SetProperties(arrPro, "FormState", CByte(1))
                            SetProperties(arrPro, "FormState", CByte(0)) ' ID 119774 09/05/2019
                            Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0251", arrPro)
                            sKeyName = L3String(GetProperties(frm, "LanguageName"))
                            sKeyID = L3String(GetProperties(frm, "LanguageID"))
                            If sKeyName <> "" Then
                                'Load tdbdRelationID
                                sSQL = "--DO nguon cho dropdown ngoai ngu " & vbCrLf
                                sSQL &= "SELECT 		'+' As LanguageID, " & NewName & "  As  LanguageName, 0 As DisplayOrder  " & vbCrLf
                                sSQL &= " UNION " & vbCrLf
                                sSQL &= " SELECT	LanguageID, LanguageName" & UnicodeJoin(gbUnicode) & " As LanguageName, 1 As DisplayOrder " & vbCrLf
                                sSQL &= " FROM	D09T0207  WITH(NOLOCK) WHERE	Disabled = 0 ORDER BY	DisplayOrder, LanguageID"
                                LoadDataSource(tdbdLanguageName, sSQL, gbUnicode)
                                tdbgLanguage.Columns(COLD_LanguageID).Text = sKeyID
                                tdbgLanguage.Columns(e.ColIndex).Text = sKeyName
                                tdbgLanguage.UpdateData()
                            End If
                        End If
                    End If
                    '**********************************
                End If
            Case COLD_LanguageLevelName
                If CheckDuplicateLanguage(tdbgLanguage.Columns(COLD_LanguageName).Text, tdbgLanguage.Columns(COLD_LanguageLevelName).Text, tdbgLanguage.Row) Then
                    D99C0008.MsgL3(rl3("Ngoai_ngu_va_cap_do_nay_da_duoc_chon"))
                    tdbgLanguage.Columns(COLD_LanguageLevelName).Text = ""
                    tdbgLanguage.Columns(COLD_LanguageLevelID).Text = ""
                Else
                    tdbgLanguage.Columns(COLD_LanguageLevelName).Text = tdbdLanguageLevelName.Columns("LanguageLevelName").Value.ToString
                    tdbgLanguage.Columns(COLD_LanguageLevelID).Text = tdbdLanguageLevelName.Columns("LanguageLevelID").Value.ToString
                    '*Them ngay 12/3/2013 theo ID 54205
                    If tdbgLanguage.Columns(COLD_LanguageLevelID).Text = "+" Then
                        tdbgLanguage.Columns(COLD_LanguageLevelID).Text = ""
                        tdbgLanguage.Columns(e.ColIndex).Text = ""
                        If ReturnPermission("D09F0260") < EnumPermission.Add Then
                            MsgNoPermissionAdd()
                        Else
                            '                            Dim f As New D09F0129
                            '                            f.formID = "D09F0261"
                            '                            f.FormPermission = "D09F0260"
                            '                            f.FormState = "1"
                            '                            f.ShowDialog()
                            '                            sKeyID = f.RelationID
                            '                            sKeyName = f.RelationName
                            '                            f.Dispose()
                            Dim arrPro() As StructureProperties = Nothing
                            '  SetProperties(arrPro, xxxxxx, DxxFxxxxx)
                            SetProperties(arrPro, "FormIDPermission", "D09F0260")
                            'SetProperties(arrPro, "FormState", CByte(1))
                            SetProperties(arrPro, "FormState", CByte(0)) ' ID 119774 09/05/2019
                            Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0261", arrPro)
                            sKeyName = L3String(GetProperties(frm, "LanguageLevelName"))
                            sKeyID = L3String(GetProperties(frm, "LanguageLevelID"))
                            If sKeyName <> "" Then
                                'Load tdbdLanguageLevelName
                                sSQL = "--Do nguon cho dropdown trinh do ngoai ngu" & vbCrLf
                                sSQL &= " SELECT 		'+' As LanguageLevelID, " & NewName & "  As  LanguageLevelName, 0 As DisplayOrder  " & vbCrLf
                                sSQL &= " UNION " & vbCrLf
                                sSQL &= " SELECT	LanguageLevelID, LanguageLevelName" & UnicodeJoin(gbUnicode) & " As LanguageLevelName, 1 As DisplayOrder " & vbCrLf
                                sSQL &= " FROM	D09T0208 WITH(NOLOCK)  WHERE	Disabled = 0 ORDER BY	DisplayOrder, LanguageLevelID"
                                LoadDataSource(tdbdLanguageLevelName, sSQL, gbUnicode)
                                tdbgLanguage.Columns(COLD_LanguageLevelID).Text = sKeyID
                                tdbgLanguage.Columns(e.ColIndex).Text = sKeyName
                                tdbgLanguage.UpdateData()
                            End If
                        End If
                    End If
                    '**********************************
                End If

            Case COLD_Listening
                tdbgLanguage.Columns(COLD_ListeningID).Text = tdbdLookupID.Columns(0).Text

            Case COLD_Speaking
                tdbgLanguage.Columns(COLD_SpeakingID).Text = tdbdLookupID.Columns(0).Text

            Case COLD_Reading
                tdbgLanguage.Columns(COLD_ReadingID).Text = tdbdLookupID.Columns(0).Text

            Case COLD_Writing
                tdbgLanguage.Columns(COLD_Writing).Text = tdbdLookupID.Columns(1).Text
                tdbgLanguage.Columns(COLD_WritingID).Text = tdbdLookupID.Columns(0).Text
        End Select

    End Sub

    Private Sub tdbgDetail_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgLanguage.BeforeColUpdate
        Select Case e.ColIndex
            Case COLD_LanguageName
                If tdbgLanguage.Columns(COLD_LanguageName).Text <> tdbdLanguageName.Columns("LanguageName").Value.ToString Then
                    tdbgLanguage.Columns(COLD_LanguageName).Text = ""
                    tdbgLanguage.Columns(COLD_LanguageID).Text = ""
                End If
            Case COLD_LanguageLevelName
                If tdbgLanguage.Columns(COLD_LanguageLevelName).Text <> tdbdLanguageLevelName.Columns("LanguageLevelName").Value.ToString Then
                    tdbgLanguage.Columns(COLD_LanguageLevelName).Text = ""
                    tdbgLanguage.Columns(COLD_LanguageLevelID).Text = ""
                End If
            Case COLD_Listening
                If tdbgLanguage.Columns(COLD_Listening).Text <> tdbdLookupID.Columns(1).Text Then
                    tdbgLanguage.Columns(COLD_Listening).Text = ""
                    tdbgLanguage.Columns(COLD_ListeningID).Text = ""
                End If

            Case COLD_Speaking
                If tdbgLanguage.Columns(COLD_Speaking).Text <> tdbdLookupID.Columns(1).Text Then
                    tdbgLanguage.Columns(COLD_Speaking).Text = ""
                    tdbgLanguage.Columns(COLD_SpeakingID).Text = ""
                End If

            Case COLD_Reading
                If tdbgLanguage.Columns(COLD_Reading).Text <> tdbdLookupID.Columns(1).Text Then
                    tdbgLanguage.Columns(COLD_Reading).Text = ""
                    tdbgLanguage.Columns(COLD_ReadingID).Text = ""
                End If

            Case COLD_Writing
                If tdbgLanguage.Columns(COLD_Writing).Text <> tdbdLookupID.Columns(1).Text Then
                    tdbgLanguage.Columns(COLD_Writing).Text = ""
                    tdbgLanguage.Columns(COLD_WritingID).Text = ""
                End If
        End Select
    End Sub

    Private Function CheckDuplicateLanguage(ByVal LanguageName As String, ByVal LanguageLevelName As String, ByVal iRow As Integer) As Boolean
        Dim bFlag As Boolean = False
        For i As Integer = 0 To tdbgLanguage.RowCount - 1
            If i <> iRow And LanguageName = tdbgLanguage(i, COLD_LanguageName).ToString And LanguageLevelName = tdbgLanguage(i, COLD_LanguageLevelName).ToString Then
                Return True
                Exit For
            End If
        Next
        Return False
    End Function

    Private Sub tdbgDetail_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgLanguage.ComboSelect
        tdbgLanguage.UpdateData()
        'Select Case e.ColIndex
        '    Case COLD_LanguageName, COLD_LanguageLevelName
        '        tdbgLanguage.UpdateData()
        '        '    If CheckDuplicateLanguage(tdbgLanguage.Columns(COLD_LanguageName).Text, tdbgLanguage.Columns(COLD_LanguageLevelName).Text, tdbgLanguage.Row) Then
        '        '        D99C0008.MsgL3(rl3("Ngoai_ngu_va_cap_do_nay_da_duoc_chon"))
        '        '        tdbgLanguage.Columns(COLD_LanguageName).Text = ""
        '        '        tdbgLanguage.Columns(COLD_LanguageID).Text = ""
        '        '    Else
        '        '        tdbgLanguage.Columns(COLD_LanguageID).Text = tdbdLanguageName.Columns("LanguageID").Value.ToString
        '        '        tdbgLanguage.Columns(COLD_LanguageName).Text = tdbdLanguageName.Columns("LanguageName").Value.ToString
        '        '    End If
        '        'Case COLD_LanguageLevelName
        '        '    If CheckDuplicateLanguage(tdbgLanguage.Columns(COLD_LanguageName).Text, tdbgLanguage.Columns(COLD_LanguageLevelName).Text, tdbgLanguage.Row) Then
        '        '        D99C0008.MsgL3(rl3("Ngoai_ngu_va_cap_do_nay_da_duoc_chon"))
        '        '        tdbgLanguage.Columns(COLD_LanguageLevelName).Text = ""
        '        '        tdbgLanguage.Columns(COLD_LanguageLevelID).Text = ""
        '        '    Else
        '        '        tdbgLanguage.Columns(COLD_LanguageLevelName).Text = tdbdLanguageLevelName.Columns("LanguageLevelName").Value.ToString
        '        '        tdbgLanguage.Columns(COLD_LanguageLevelID).Text = tdbdLanguageLevelName.Columns("LanguageLevelID").Value.ToString
        '        '    End If
        '    Case COLD_Listening
        '        tdbgLanguage.Columns(COLD_ListeningID).Text = tdbdLookupID.Columns(0).Text

        '    Case COLD_Speaking
        '        tdbgLanguage.Columns(COLD_SpeakingID).Text = tdbdLookupID.Columns(0).Text

        '    Case COLD_Reading
        '        tdbgLanguage.Columns(COLD_ReadingID).Text = tdbdLookupID.Columns(0).Text

        '    Case COLD_Writing
        '        tdbgLanguage.Columns(COLD_WritingID).Text = tdbdLookupID.Columns(0).Text

        'End Select

    End Sub

    Private Sub tdbgDetail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgLanguage.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                HotKeyF7(tdbgLanguage)
                Exit Sub
            Case Keys.F8
                Select Case tdbgLanguage.Col
                    Case COLD_LanguageName, COLD_LanguageLevelName
                        HotKeyF8_Name(tdbgLanguage)
                        Exit Sub
                    Case Else
                        HotKeyF8(tdbgLanguage)
                        Exit Sub
                End Select
            Case Keys.Enter
                If D25Options.UseEnterAsTab And tdbgLanguage.Col = COLD_Writing Then
                    HotKeyEnterGrid(tdbgLanguage, COLD_Description, e)
                    Exit Sub
                End If
        End Select
        If e.Shift And e.KeyCode = Keys.Insert Then 'And tdbgLanguage.Col = COLD_LanguageName Then
            'HotKeyShiftInsert(tdbgLanguage, 0, COLD_LanguageName, tdbgLanguage.Columns.Count)
            HotKeyShiftInsert(tdbgLanguage)
            Exit Sub
        End If
        If e.KeyCode = Keys.Enter And tdbgLanguage.Col = COLD_Writing Then Exit Sub
        HotKeyDownGrid(e, tdbgLanguage, COLD_Description)
    End Sub

    Private Sub tdbgComputing_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgComputing.AfterColUpdate
        Select Case e.ColIndex
            Case COL3_ComputingLevelName
                tdbgComputing.Columns(COL3_ComputingLevel).Text = tdbdComputingLevelName.Columns(0).Text

            Case COL3_SchoolName
                tdbgComputing.Columns(COL3_SchoolID).Text = tdbdSchoolName.Columns(0).Text
                AddNewShoolName(tdbgComputing, e.ColIndex, COL3_SchoolID, COL3_SchoolName)
        End Select
    End Sub

    Private Sub tdbgComputing_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgComputing.BeforeColUpdate
        Select Case e.ColIndex
            Case COL3_ComputingLevelName
                If tdbgComputing.Columns(COL3_ComputingLevelName).Text <> tdbdComputingLevelName.Columns(1).Text Then
                    tdbgComputing.Columns(COL3_ComputingLevelName).Text = ""
                    tdbgComputing.Columns(COL3_ComputingLevel).Text = ""
                End If

            Case COL3_SchoolName
                If tdbgComputing.Columns(COL3_SchoolName).Text <> tdbdSchoolName.Columns(1).Text Then
                    tdbgComputing.Columns(COL3_SchoolID).Text = ""
                    tdbgComputing.Columns(COL3_SchoolName).Text = ""
                End If

        End Select
    End Sub

    Private Sub tdbgComputing_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgComputing.ComboSelect
        tdbgComputing.UpdateData()
        'Select Case e.ColIndex
        '    Case COL3_ComputingLevelName
        '        tdbgComputing.Columns(COL3_ComputingLevel).Text = tdbdComputingLevelName.Columns(0).Text

        '    Case COL3_SchoolName
        '        tdbgComputing.Columns(COL3_SchoolID).Text = tdbdSchoolName.Columns(0).Text
        'End Select
    End Sub

    Private Sub tdbgComputing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgComputing.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                HotKeyF7(tdbgComputing)
                Exit Sub
            Case Keys.F8
                Select Case tdbgComputing.Col
                    Case COL3_ComputingLevelName, COL3_SchoolName
                        HotKeyF8_Name(tdbgComputing)
                        Exit Sub
                    Case Else
                        HotKeyF8(tdbgComputing)
                        Exit Sub
                End Select
            Case Keys.Enter
                If D25Options.UseEnterAsTab And tdbgComputing.Col = COL3_SchoolName Then
                    HotKeyEnterGrid(tdbgComputing, COL3_Description, e)
                    Exit Sub
                End If
        End Select
        If e.Shift And e.KeyCode = Keys.Insert Then 'And tdbgLanguage.Col = COLD_LanguageName Then
            'HotKeyShiftInsert(tdbgLanguage, 0, COLD_LanguageName, tdbgLanguage.Columns.Count)
            HotKeyShiftInsert(tdbgComputing)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbgComputing, COL3_Description)
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbgStudy.UpdateData()
        tdbgLanguage.UpdateData()
        tdbgComputing.UpdateData()

        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append("DECLARE @Now datetime; SET @Now = getDate()" & vbCrLf)
        sSQL.Append(SQLDeleteD25T1050() & vbCrLf)
        sSQL.Append(SQLInsertD25T1050s().ToString & vbCrLf)
        sSQL.Append(SQLDeleteD25T1051() & vbCrLf)
        sSQL.Append(SQLInsertD25T1051s().ToString & vbCrLf)
        sSQL.Append(SQLDeleteD25T1054.ToString & vbCrLf)
        sSQL.Append(SQLInsertD25T1054s)

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
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T1050
    '# Created User: Lê Thị Lành
    '# Created Date: 22/10/2007 08:50:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T1050() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T1050"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "CandidateID = " & SQLString(_CandidateID)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1050s
    '# Created User: Lê Thị Lành
    '# Created Date: 22/10/2007 09:00:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1050s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sTransEducationID As String = ""

        Dim iCountIGE As Integer = 0
        For i As Integer = 0 To tdbgStudy.RowCount - 1
            If tdbgStudy(i, COL_TransEducationID).ToString = "" Then iCountIGE += 1
        Next

        For i As Integer = 0 To tdbgStudy.RowCount - 1
            If tdbgStudy(i, COL_TransEducationID).ToString = "" Then
                sTransEducationID = CreateIGEs("D25T1050", "TransEducationID", "25", "TE", gsStringKey, sTransEducationID, iCountIGE)
                tdbgStudy(i, COL_TransEducationID) = sTransEducationID
            End If
            sSQL.Append("Insert Into D25T1050(")
            sSQL.Append("DivisionID, CandidateID, SchoolID, DateStarted, DateEnded, ")
            sSQL.Append("Certificates, CertificatesU, Disabled, CreateUserID, LastModifyUserID, CreateDate, ")
            sSQL.Append("LastModifyDate, TransEducationID, MajorID, Description, DescriptionU, EducationFormID ")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_CandidateID) & COMMA) 'CandidateID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgStudy(i, COL_SchoolID).ToString) & COMMA) 'SchoolID [KEY], varchar[20], NOT NULL
            sSQL.Append(IIf(tdbgStudy(i, COL_DateStarted).ToString = "", "NULL", SQLDateSave(tdbgStudy(i, COL_DateStarted))).ToString & COMMA) 'DateStarted, datetime, NULL
            sSQL.Append(IIf(tdbgStudy(i, COL_DateEnded).ToString = "", "NULL", SQLDateSave(tdbgStudy(i, COL_DateEnded))).ToString & COMMA) 'DateEnded, datetime, NULL
            sSQL.Append(SQLStringUnicode(tdbgStudy(i, COL_Certificates), gbUnicode, False) & COMMA) 'Certificates, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbgStudy(i, COL_Certificates), gbUnicode, True) & COMMA) 'CertificatesU, varchar[250], NULL
            sSQL.Append(SQLNumber(0) & COMMA) 'Disabled, tinyint, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("@Now" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append("@Now" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLString(tdbgStudy(i, COL_TransEducationID)) & COMMA) 'TransEducationID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgStudy(i, COL_MajorID).ToString) & COMMA) 'MajorID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgStudy(i, COL_Description), gbUnicode, False) & COMMA)
            sSQL.Append(SQLStringUnicode(tdbgStudy(i, COL_Description), gbUnicode, True) & COMMA)
            sSQL.Append(SQLString(tdbgStudy(i, COL_EducationFormID).ToString)) 'EducationFormID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T1051
    '# Created User: Lê Thị Lành
    '# Created Date: 22/10/2007 09:18:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T1051() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T1051"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "CandidateID = " & SQLString(_CandidateID)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1051s
    '# Created User: Lê Thị Lành
    '# Created Date: 22/10/2007 09:21:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1051s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sTransLanguageID As String = ""
        Dim iCountIGE As Integer = 0
        For i As Integer = 0 To tdbgLanguage.RowCount - 1
            If tdbgLanguage(i, COLD_TransLanguageID).ToString = "" Then iCountIGE += 1
        Next
        'sSQL.Append("DECLARE @Now datetime; SET @Now = getDate()" & vbCrLf)
        For i As Integer = 0 To tdbgLanguage.RowCount - 1
            If tdbgLanguage(i, COLD_TransLanguageID).ToString = "" Then
                sTransLanguageID = CreateIGEs("D25T1051", "TransLanguageID", "25", "TL", gsStringKey, sTransLanguageID, iCountIGE)
                tdbgLanguage(i, COLD_TransLanguageID) = sTransLanguageID
            End If
            sSQL.Append("Insert Into D25T1051(")
            sSQL.Append("DivisionID, CandidateID, LanguageID, LanguageLevelID, Listening, ")
            sSQL.Append("Speaking, Reading, Writing, Disabled, CreateUserID, ")
            sSQL.Append("LastModifyUserID, CreateDate, LastModifyDate, TransLanguageID, Description, DescriptionU")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_CandidateID) & COMMA) 'CandidateID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgLanguage(i, COLD_LanguageID)) & COMMA) 'LanguageID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgLanguage(i, COLD_LanguageLevelID)) & COMMA) 'LanguageLevelID, varchar[20], NULL
            sSQL.Append(SQLString(tdbgLanguage(i, COLD_ListeningID)) & COMMA) 'Listening, varchar[50], NULL
            sSQL.Append(SQLString(tdbgLanguage(i, COLD_SpeakingID)) & COMMA) 'Speaking, varchar[50], NULL
            sSQL.Append(SQLString(tdbgLanguage(i, COLD_ReadingID)) & COMMA) 'Reading, varchar[50], NULL
            sSQL.Append(SQLString(tdbgLanguage(i, COLD_WritingID)) & COMMA) 'Writing, varchar[50], NULL
            sSQL.Append(SQLNumber(0) & COMMA) 'Disabled, tinyint, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("@Now" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append("@Now" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLString(tdbgLanguage(i, COLD_TransLanguageID)) & COMMA) 'TransLanguageID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgLanguage(i, COLD_Description), gbUnicode, False) & COMMA) 'Description, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgLanguage(i, COLD_Description), gbUnicode, True)) 'DescriptionU, varchar[250], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T1054
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 29/10/2008 09:20:22
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T1054() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T1054"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "CandidateID = " & SQLString(_CandidateID)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1054s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 29/10/2008 09:26:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1054s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        With tdbgComputing
            For i As Integer = 0 To tdbgComputing.RowCount - 1
                sSQL.Append("Insert Into D25T1054(")
                sSQL.Append("DivisionID, CandidateID, ComputingCertificate, ComputingCertificateU, ComputingLevel, Disabled, ")
                sSQL.Append("SchoolID, Description, DescriptionU, CreateUserID, CreateDate, LastModifyUserID, ")
                sSQL.Append("LastModifyDate")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
                sSQL.Append(SQLString(_CandidateID) & COMMA) 'CandidateID, varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbgComputing(i, COL3_ComputingCertificate), gbUnicode, False) & COMMA) 'ComputingCertificate, varchar[250], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbgComputing(i, COL3_ComputingCertificate), gbUnicode, True) & COMMA) 'ComputingCertificateU, varchar[250], NOT NULL
                sSQL.Append(SQLString(tdbgComputing(i, COL3_ComputingLevel)) & COMMA) 'ComputingLevel, varchar[20], NOT NULL
                sSQL.Append(SQLNumber(0) & COMMA) 'Disabled, tinyint, NOT NULL
                sSQL.Append(SQLString(tdbgComputing(i, COL3_SchoolID)) & COMMA) 'SchoolID, varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbgComputing(i, COL3_Description), gbUnicode, False) & COMMA) 'Description, varchar[250], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbgComputing(i, COL3_Description), gbUnicode, True) & COMMA) 'DescriptionU, varchar[250], NOT NULL

                sSQL.Append(SQLString(IIf(tdbgComputing(i, COL3_CreateUserID).ToString <> "", tdbgComputing(i, COL3_CreateUserID).ToString, gsUserID)) & COMMA) 'CreateUserID, varchar[20], NOT NULL
                sSQL.Append(IIf(tdbgComputing(i, COL3_CreateDate).ToString <> "", SQLDateSave(tdbgComputing(i, COL3_CreateDate)), "GetDate()").ToString & COMMA) 'CreateDate, datetime, NULL

                sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
                sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            Next
        End With
        Return sRet
    End Function

    Private Sub AddNewShoolName(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal col As Integer, ByVal SchoolID As Integer, ByVal SchoolName As Integer)
        If C1Grid.Columns(SchoolID).Text = "+" Then
            C1Grid.Columns(SchoolID).Text = ""
            C1Grid.Columns(SchoolName).Text = ""
            If ReturnPermission("D09F0320") < EnumPermission.Add Then
                MsgNoPermissionAdd()
            Else
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D09F0320")
                SetProperties(arrPro, "FormState", CByte(EnumFormState.FormAdd))
                'Dim frm As Form = CallFormShow(Me.ParentForm, "D09D0140", "D09F0321", arrPro)
                Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0321", arrPro)
                Dim sKeyName As String = L3String(GetProperties(frm, "SchoolName"))
                Dim sKeyID As String = L3String(GetProperties(frm, "SchoolID"))
                If sKeyID <> "" Then
                    'Load tdbdRelationID
                    Dim sSQL As String = ""
                    sSQL = " --Do nguon cho dropdown truong hoc" & vbCrLf
                    sSQL &= " SELECT '+' As SchoolID, " & NewName & "  As  SchoolName, 0 As DisplayOrder  " & vbCrLf
                    sSQL &= " UNION " & vbCrLf
                    sSQL &= " SELECT SchoolID,  SchoolName" & UnicodeJoin(gbUnicode) & " As SchoolName, 1 As DisplayOrder" & vbCrLf
                    sSQL &= " FROM	D09T0213 WITH(NOLOCK)  WHERE	Disabled = 0 ORDER BY DisplayOrder, SchoolID"
                    LoadDataSource(C1Grid.Columns(col).DropDown, sSQL, gbUnicode)
                    C1Grid.Columns(SchoolID).Text = sKeyID
                    C1Grid.Columns(SchoolName).Text = sKeyName
                    C1Grid.UpdateData()
                End If
            End If
        End If
    End Sub

    Public Sub HotKeyF8_Name(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            If c1Grid.RowCount < 1 Then Exit Sub

            If c1Grid(c1Grid.Row, c1Grid.Col).ToString() = "" Then
                For j As Integer = c1Grid.Col - 1 To c1Grid.Columns.Count - 1
                    c1Grid.Columns(j).Text = c1Grid(c1Grid.Row - 1, j).ToString()
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class