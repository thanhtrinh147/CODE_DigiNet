Public Class D25F1053
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_ExperienceID As Integer = 0     ' ExperienceID
    Private Const COL_CandidateID As Integer = 1      ' CandidateID
    Private Const COL_DivisionID As Integer = 2       ' DivisionID
    Private Const COL_DateStarted As Integer = 3      ' Bắt đầu
    Private Const COL_DateEnded As Integer = 4        ' Kết thúc
    Private Const COL_CompanyName As Integer = 5      ' Tên công ty
    Private Const COL_CountryName As Integer = 6      ' Quốc gia
    Private Const COL_Address As Integer = 7          ' Địa chỉ
    Private Const COL_DutyName As Integer = 8         ' Chức vụ
    Private Const COL_JobDescription As Integer = 9   ' Công việc
    Private Const COL_BaseSalary As Integer = 10      ' Mức lương
    Private Const COL_Allowance As Integer = 11       ' Phụ cấp
    Private Const COL_CurrencyID As Integer = 12      ' Loại tiền
    Private Const COL_ColleagueQuan As Integer = 13   ' Số lượng NV cùng bộ phận
    Private Const COL_SubordinateQuan As Integer = 14 ' Số lượng NV dưới quyền
    Private Const COL_LeavingReason As Integer = 15   ' Lý do thôi việc
    Private Const COL_Reference As Integer = 16       ' Thông tin liên hệ
    Private Const COL_Note As Integer = 17            ' Ghi chú
    Private Const COL_CountryID As Integer = 18       ' CountryID
    Private Const COL_DutyID As Integer = 19          ' DutyID
    Private Const COL_WorkID As Integer = 20          ' WorkID
#End Region

    ' Update 23/05/2011 - Chuẩn unicode theo DC25 _ TIENDAU
    Dim dt_LoadGrid As DataTable
    Dim _CandidateID As String = ""
    Dim bFlagShiftInsert As Boolean = False 'Cờ khi nhấn ShiftInsert
    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Public Property CandidateID() As String
        Get
            Return _CandidateID
        End Get
        Set(ByVal value As String)
            _CandidateID = value
        End Set
    End Property

    Private Sub D25F1053_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        End If
    End Sub

    Private Sub D25F1053_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        tdbg_NumberFormat()
        Loadlanguage()
        '*****
        'Phải bỏ khai báo hằng của cột cần chuyển sang Unicode (bỏ Const khai báo cột)
        'Bổ sung nhập liệu Unicode: hàm này để sau hàm LoadLanguage
        'UnicodeGridDataField(tdbg, UnicodeArrayCOL(), gbUnicode) 'sửa dataField và hằng của 1 cột
        '***************
        LoadTDBDropDown()
        LoadTDBGrid()
        '*****
        'tdbg.Columns(COL_DateStarted).Editor = c1dateStart
        'tdbg.Columns(COL_DateEnded).Editor = c1dateEnd
        InputDateInTrueDBGrid(tdbg, COL_DateStarted, COL_DateEnded)
        If gbUnicode Then
            tdbg.Splits(0).DisplayColumns(COL_Address).Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25)
            tdbg.Splits(0).DisplayColumns(COL_CountryName).Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25)
        End If

        
InputDateCustomFormat(c1dateStart,c1dateEnd)
    SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Kinh_nghiem_lam_viec_-_D25F1053") & UnicodeCaption(gbUnicode) 'Kinh nghiÖm lªm viÖc - D25F1053
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbdCountryID.Columns("CountryID").Caption = rl3("Ma") 'Mã
        tdbdCountryID.Columns("CountryName").Caption = rl3("Ten") 'Tên
        tdbdCurrencyID.Columns("CurrencyID").Caption = rl3("Ma") 'Mã
        tdbdCurrencyID.Columns("CurrencyName").Caption = rl3("Ten") 'Tên
        tdbdDutyID.Columns("DutyID").Caption = rl3("Ma") 'Mã
        tdbdDutyID.Columns("DutyName").Caption = rl3("Ten") 'Tên
        tdbdWorkID.Columns("WorkID").Caption = rl3("Ma") 'Mã
        tdbdWorkID.Columns("WorkName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("DateStarted").Caption = rl3("Bat_dau") 'Bắt đầu
        tdbg.Columns("DateEnded").Caption = rl3("Ket_thuc") 'Kết thúc
        tdbg.Columns("CompanyName").Caption = rl3("Ten_cong_ty") 'Tên công ty
        tdbg.Columns("CountryName").Caption = rl3("Quoc_gia") 'Quốc gia
        tdbg.Columns("Address").Caption = rl3("Dia_chi") 'Địa chỉ
        tdbg.Columns("DutyName").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns("JobDescription").Caption = rl3("Cong_viec")
        tdbg.Columns("BaseSalary").Caption = rl3("Muc_luong") 'Mức lương
        tdbg.Columns("Allowance").Caption = rl3("Phu_cap") 'Phụ cấp
        tdbg.Columns("CurrencyID").Caption = rl3("Loai_tien") 'Loại tiền
        tdbg.Columns("ColleagueQuan").Caption = rl3("So_luong_NV_cung_bo_phan") 'Số lượng NV cùng bộ phận
        tdbg.Columns("SubordinateQuan").Caption = rl3("So_luong_NV_duoi_quyen") 'Số lượng NV dưới quyền
        tdbg.Columns("LeavingReason").Caption = rl3("Ly_do_thoi_viec") 'Lý do thôi việc
        tdbg.Columns("Reference").Caption = rl3("Thong_tin_lien_he") 'Thông tin liên hệ
        tdbg.Columns("Note").Caption = rl3("Ghi_chu") 'Ghi chú
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdCountryID
        sSQL &= " Select CountryID, CountryName" & UnicodeJoin(gbUnicode) & " As CountryName" & vbCrLf
        sSQL &= " From D91T0017 WITH(NOLOCK)  Where Disabled = 0 Order by	CountryID"
        LoadDataSource(tdbdCountryID, sSQL, gbUnicode)

        'Load tdbdCurrencyID
        LoadCurrencyID(tdbdCurrencyID, gbUnicode)
        '*Thay doi ngay 11/3/2013 theo ID 54205 của Tuyền Nguyễn bởi Văn Vinh
        sSQL = "SELECT 		'+' As DutyID,  " & NewName & "  As  DutyName, 0 As DisplayOrder  " & vbCrLf
        sSQL &= " UNION	 " & vbCrLf
        sSQL &= " SELECT		DutyID,  DutyName" & UnicodeJoin(gbUnicode) & " As DutyName, 1 As DisplayOrder " & vbCrLf
        sSQL &= " FROM		D09T0211 WITH(NOLOCK)  WHERE		Disabled = 0 ORDER BY		DisplayOrder, DutyID"
        ' sSQL = " Select DutyID, DutyName" & UnicodeJoin(gbUnicode) & " AS DutyName" & vbCrLf
        'sSQL &= " From D09T0211 ORDER BY DutyID" & vbCrLf
        LoadDataSource(tdbdDutyID, sSQL, gbUnicode)
        sSQL = " SELECT 		'+' As WorkID, " & NewName & "  As  WorkName, 0 As  DisplayOrder " & vbCrLf
        sSQL &= " UNION " & vbCrLf
        sSQL &= " SELECT	WorkID,  WorkName" & UnicodeJoin(gbUnicode) & " As WorkName, 1 As DisplayOrder " & vbCrLf
        sSQL &= " FROM	D09T0224 WITH(NOLOCK)  WHERE	Disabled = 0 ORDER BY	DisplayOrder, WorkID"
        'sSQL = " SELECT WorkID, WorkName" & UnicodeJoin(gbUnicode) & " AS WorkName" & vbCrLf
        'sSQL &= " FROM D09T0224" & vbCrLf
        'sSQL &= " ORDER BY WorkID" & vbCrLf
        LoadDataSource(tdbdWorkID, sSQL, gbUnicode)
        '********************************
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String
        sSQL = " Select	T1.DivisionID, T1.CandidateID, T1.ExperienceID, DateStarted, DateEnded," & vbCrLf
        sSQL &= " T1.CompanyName" & UnicodeJoin(gbUnicode) & "  as CompanyName, T1.Address" & UnicodeJoin(gbUnicode) & "  as Address,"
        sSQL &= " T2.CountryName" & UnicodeJoin(gbUnicode) & "  as CountryName, " & vbCrLf
        sSQL &= " T1.CountryID,T1.DutyName" & UnicodeJoin(gbUnicode) & "  as DutyName, '' as DutyID, T1.BaseSalary, T1.Allowance, T1.CurrencyID, T4.CurrencyName, " & vbCrLf
        sSQL &= " T1.ColleagueQuan, T1.SubordinateQuan, T1.LeavingReason" & UnicodeJoin(gbUnicode) & " as LeavingReason, T1.Reference" & UnicodeJoin(gbUnicode) & " as Reference, "
        sSQL &= " T1.JobDescription" & UnicodeJoin(gbUnicode) & "  as JobDescription, '' as WorkID, T1.Note" & UnicodeJoin(gbUnicode) & "  as Note" & vbCrLf
        sSQL &= " From D25T1052 T1 WITH(NOLOCK)  Left join D91T0017 T2  WITH(NOLOCK) On T2.CountryID=T1.CountryID " & vbCrLf
        sSQL &= " Left join D91T0010 T4  WITH(NOLOCK) On T4.CurrencyID=T1.CurrencyID " & vbCrLf
        sSQL &= " Where	T1.DivisionID = " & SQLString(gsDivisionID) & " And T1.CandidateID = " & SQLString(_CandidateID) & vbCrLf
        sSQL &= " Order by T1.ExperienceID"
        dt_LoadGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt_LoadGrid, gbUnicode)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_BaseSalary).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_Allowance).NumberFormat = D25Format.DefaultNumber2
        tdbg.Columns(COL_ColleagueQuan).NumberFormat = D25Format.DefaultNumber0
        tdbg.Columns(COL_SubordinateQuan).NumberFormat = D25Format.DefaultNumber0
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_CountryName
                tdbg.Columns(COL_CountryID).Text = tdbdCountryID.Columns("CountryID").Text
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_BaseSalary, COL_Allowance, COL_ColleagueQuan, COL_SubordinateQuan
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_CountryName
                If tdbg.Columns(COL_CountryName).Text <> tdbdCountryID.Columns("CountryName").Text Then
                    tdbg.Columns(COL_CountryName).Text = ""
                    tdbg.Columns(COL_CountryID).Text = ""
                End If
            Case COL_BaseSalary
                If Not L3IsNumeric(tdbg.Columns(COL_BaseSalary).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_Allowance
                If Not L3IsNumeric(tdbg.Columns(COL_Allowance).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_CurrencyID
                If tdbg.Columns(COL_CurrencyID).Text <> tdbdCurrencyID.Columns("CurrencyID").Text Then
                    tdbg.Columns(COL_CurrencyID).Text = ""
                End If
            Case COL_ColleagueQuan
                If Not L3IsNumeric(tdbg.Columns(COL_ColleagueQuan).Text, EnumDataType.Int) Then e.Cancel = True
            Case COL_SubordinateQuan
                If Not L3IsNumeric(tdbg.Columns(COL_SubordinateQuan).Text, EnumDataType.Int) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        bFlagShiftInsert = False
        Select Case e.KeyCode
            Case Keys.F7
                If tdbg.Col = COL_CountryName Then
                    HotKeyF7_Name(tdbg, COL_CountryID)
                Else
                    HotKeyF7(tdbg)
                End If

            Case Keys.F8
                HotKeyF8(tdbg)
                tdbg.Columns(COL_ExperienceID).Value = ""

            Case Keys.Enter
                If D25Options.UseEnterAsTab And tdbg.Col = COL_Note Then
                    HotKeyEnterGrid(tdbg, COL_DateStarted, e)
                End If

        End Select

        If e.Shift And e.KeyCode = Keys.Insert Then
            bFlagShiftInsert = True
            HotKeyShiftInsert(tdbg, 0, COL_DateStarted, tdbg.Columns.Count)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_DateStarted)
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If bFlagShiftInsert And tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
            tdbg.Columns(COL_ExperienceID).Text = "" ' Gán 1 cột bất kỳ ="" cho lưới
        End If
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()

        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append("DECLARE @Now datetime; SET @Now = getDate()" & vbCrLf)
        sSQL.Append(SQLDeleteD25T1052().ToString & vbCrLf)
        sSQL.Append(SQLInsertD25T1052s())

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True

            btnSave.Enabled = True
            btnClose.Focus()
        Else
            _bSaved = False
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_CompanyName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_cong_ty"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_CompanyName
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
        Next
        Return True
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T1052
    '# Created User: Lê Thị Lành
    '# Created Date: 22/10/2007 04:39:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T1052() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T1052"
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "CandidateID = " & SQLString(_CandidateID)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T1052s
    '# Created User: Lê Thị Lành
    '# Created Date: 22/10/2007 04:42:37
    '# Modified User: dmd
    '# Modified Date: 19/01/09
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1052s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim iCountIGE As Integer = 0
        Dim sExperienceID As String = ""
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_ExperienceID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_ExperienceID).ToString = "" Then
                sExperienceID = CreateIGEs("D25T1052", "ExperienceID", "25", "EX", gsStringKey, sExperienceID, iCountIGE)
                tdbg(i, COL_ExperienceID) = sExperienceID
            End If
            sSQL.Append("Insert Into D25T1052(")
            sSQL.Append("DivisionID, CandidateID, ExperienceID, DateStarted, DateEnded, ")
            sSQL.Append("CompanyName, CompanyNameU, Address, AddressU, ColleagueQuan, SubordinateQuan, LeavingReason, LeavingReasonU, ")
            sSQL.Append("Reference, ReferenceU, Note, NoteU, Disabled, CreateUserID, LastModifyUserID, ")
            sSQL.Append("CreatedDate, LastModifyDate, CountryID, DutyName, DutyNameU, CurrencyID, ")
            sSQL.Append("JobDescription, JobDescriptionU, BaseSalary, Allowance")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_CandidateID) & COMMA) 'CandidateID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ExperienceID).ToString) & COMMA) 'ExperienceID [KEY], varchar[20], NOT NULL
            sSQL.Append(IIf(tdbg(i, COL_DateStarted).ToString = "", "NULL", SQLDateSave(tdbg(i, COL_DateStarted))).ToString & COMMA) 'DateStarted, datetime, NULL
            sSQL.Append(IIf(tdbg(i, COL_DateEnded).ToString = "", "NULL", SQLDateSave(tdbg(i, COL_DateEnded))).ToString & COMMA) 'DateEnded, datetime, NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_CompanyName), gbUnicode, False) & COMMA) 'CompanyName, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_CompanyName), gbUnicode, True) & COMMA) 'CompanyNameU, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Address), gbUnicode, False) & COMMA) 'Address, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Address), gbUnicode, True) & COMMA) 'AddressU, varchar[250], NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_ColleagueQuan).ToString) & COMMA) 'ColleagueQuan, int, NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_SubordinateQuan).ToString) & COMMA) 'SubordinateQuan, int, NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_LeavingReason), gbUnicode, False) & COMMA) 'LeavingReason, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_LeavingReason), gbUnicode, True) & COMMA) 'LeavingReasonU, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Reference), gbUnicode, False) & COMMA) 'Reference, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Reference), gbUnicode, True) & COMMA) 'ReferenceU, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, False) & COMMA) 'Note, varchar[250], NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, True) & COMMA) 'NoteU, varchar[250], NULL
            sSQL.Append(SQLNumber(0) & COMMA) 'Disabled, bit, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("@Now" & COMMA) 'CreatedDate, datetime, NULL
            sSQL.Append("@Now" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COL_CountryID).ToString) & COMMA) 'CountryID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_DutyName), gbUnicode, False) & COMMA) 'DutyName, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_DutyName), gbUnicode, True) & COMMA) 'DutyNameU, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CurrencyID).ToString) & COMMA) 'CurrencyID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_JobDescription), gbUnicode, False) & COMMA) 'JobDescription
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_JobDescription), gbUnicode, True) & COMMA) 'JobDescriptionU
            sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary).ToString) & COMMA) 'BaseSalary, money, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Allowance).ToString)) 'Allowance, money, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function UnicodeArrayCOL() As Integer()
        If Not gbUnicode Then Return Nothing
        Dim ArrCOL() As Integer = {COL_CompanyName, COL_CountryName, COL_Address, COL_DutyName, COL_JobDescription, COL_LeavingReason, COL_Reference, COL_Note}
        Return ArrCOL
    End Function
    '*Them ngay 11/3/2013 theo ID 54205
    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Dim sKeyName As String = ""
        Dim sKeyID As String = ""
        Select Case e.ColIndex
            Case COL_DutyName
                tdbg.Columns(COL_DutyID).Text = tdbdDutyID.Columns("DutyID").Text
                If tdbg.Columns(COL_DutyID).Text = "+" Then
                    tdbg.Columns(COL_DutyID).Text = ""
                    tdbg.Columns(e.ColIndex).Text = ""
                    If ReturnPermission("D09F0290") < EnumPermission.Add Then
                        MsgNoPermissionAdd()
                    Else
                        '                        Dim f As New D09F0129
                        '                        f.formID = "D09F0291"
                        '                        f.FormPermission = "D09F0290"
                        '                        f.FormState = "1"
                        '                        f.ShowDialog()
                        '                        sKeyID = f.RelationID
                        '                        f.Dispose()
                        Dim arrPro() As StructureProperties = Nothing
                        '  SetProperties(arrPro, xxxxxx, DxxFxxxxx)
                        SetProperties(arrPro, "FormCall", Me.Name)
                        SetProperties(arrPro, "FormIDPermission", "D09F0290")
                        SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
                        'ID 96109  30.03.2017 rà các dropdown chức vụ có thêm mới nhưng gọi D09F0291
                        Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0290", arrPro)
                        'SetProperties(arrPro, "FormState", CByte(1))

                        'Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0291", arrPro)
                        'sKeyID = L3String(GetProperties(frm, "RelationID"))
                      
                        'If sKeyID <> "" Then
                        If L3Bool(GetProperties(frm, "bSaved")) Then
                            'Load tdbdRelationID
                            Dim sSQL As String = ""
                            sSQL = "--Load dropdown chuc vu" & vbCrLf
                            sSQL &= "SELECT '+' As DutyID,  " & NewName & "  As  DutyName, 0 As DisplayOrder  " & vbCrLf
                            sSQL &= " UNION	 " & vbCrLf
                            sSQL &= " SELECT DutyID,  DutyName" & UnicodeJoin(gbUnicode) & " As DutyName, 1 As DisplayOrder " & vbCrLf
                            sSQL &= " FROM	D09T0211 WITH(NOLOCK)  WHERE		Disabled = 0 ORDER BY		DisplayOrder, DutyID"
                            LoadDataSource(tdbdDutyID, sSQL, gbUnicode)
                            tdbg.Columns(COL_DutyID).Text = sKeyID
                            Dim dr As DataRow = ReturnDataRow(tdbdDutyID, "DutyID = " & SQLString(sKeyID))
                            If dr Is Nothing Then
                                sKeyName = ""
                            Else
                                sKeyName = dr.Item("DutyName").ToString
                            End If

                            tdbg.Columns(e.ColIndex).Text = sKeyName
                            tdbg.UpdateData()
                        End If
                    End If
                End If
                'Them moi cong viec
            Case COL_JobDescription
                tdbg.Columns(COL_WorkID).Text = tdbdWorkID.Columns("WorkID").Text
                If tdbg.Columns(COL_WorkID).Text = "+" Then
                    tdbg.Columns(COL_WorkID).Text = ""
                    tdbg.Columns(e.ColIndex).Text = ""
                    If ReturnPermission("D09F0431") < EnumPermission.Add Then
                        MsgNoPermissionAdd()
                    Else
                        '                        Dim f As New D09F0129
                        '                        f.formID = "D09F0431"
                        '                        f.FormPermission = "D09F0430"
                        '                        f.FormState = "1"
                        '                        f.ShowDialog()
                        '                        sKeyID = f.RelationID
                        '                        sKeyName = f.RelationName
                        '                        f.Dispose()
                        Dim arrPro() As StructureProperties = Nothing
                        '  SetProperties(arrPro, xxxxxx, DxxFxxxxx)
                        SetProperties(arrPro, "FormIDPermission", "D09F0430")
                        SetProperties(arrPro, "FormState", CByte(1))
                        Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0431", arrPro)
                        sKeyName = L3String(GetProperties(frm, "RelationName"))
                        sKeyID = L3String(GetProperties(frm, "RelationID"))
                        If sKeyName <> "" Then
                            'Load tdbdRelationID
                            Dim sSQL As String = ""
                            sSQL = "--Load dropdown cong viec" & vbCrLf
                            sSQL = " SELECT 		'+' As WorkID, " & NewName & "  As  WorkName, 0 As  DisplayOrder " & vbCrLf
                            sSQL &= " UNION " & vbCrLf
                            sSQL &= " SELECT	WorkID,  WorkName" & UnicodeJoin(gbUnicode) & " As WorkName, 1 As DisplayOrder " & vbCrLf
                            sSQL &= " FROM	D09T0224  WITH(NOLOCK) WHERE	Disabled = 0 ORDER BY	DisplayOrder, WorkID"
                            LoadDataSource(tdbdWorkID, sSQL, gbUnicode)
                            tdbg.Columns(COL_WorkID).Text = sKeyID
                            tdbg.Columns(e.ColIndex).Text = sKeyName
                            tdbg.UpdateData()
                        End If
                    End If
                End If
        End Select
    End Sub

    Public Sub HotKeyF7_Name(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal NameCol As Integer)
        Try
            If c1Grid.RowCount < 1 Then Exit Sub

            If c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns.Item(c1Grid.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then ' Số
                If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse Val(c1Grid(c1Grid.Row, c1Grid.Col).ToString) = 0 Then
                    c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                    c1Grid.Columns(NameCol).Text = c1Grid(c1Grid.Row - 1, NameCol).ToString()
                    c1Grid.UpdateData()
                End If
            Else ' Chuỗi hoặc Ngày
                If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDateShort OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDate Then
                    c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                    c1Grid.Columns(NameCol).Text = c1Grid(c1Grid.Row - 1, NameCol).ToString()
                    c1Grid.UpdateData()
                End If
            End If

        Catch ex As Exception
            D99C0008.Msg("Lỗi HotKeyF7: " & ex.Message)
        End Try
    End Sub
End Class