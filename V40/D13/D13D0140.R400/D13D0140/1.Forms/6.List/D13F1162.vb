Imports System
Public Class D13F1162

#Region "Const of tdbg"
    Private Const COL_DepartmentID As Integer = 0        ' Phòng ban
    Private Const COL_DutyID As Integer = 1              ' Chức vụ
    Private Const COL_ProfessionalLevelID As Integer = 2 ' Trình độ chuyên môn
    Private Const COL_EmployeeTypeID As Integer = 3      ' Đối tượng lao động
    Private Const COL_WorkingStatusID As Integer = 4     ' Trạng thái làm việc
    Private Const COL_WorkID As Integer = 5              ' Công việc
    Private Const COL_EducationLevelID As Integer = 6    ' Trình độ học vấn
    Private Const COL_OfficalTitleID As Integer = 7      ' Ngạch lương 01
    Private Const COL_SalaryLevelID As Integer = 8       ' Bậc lương 01
    Private Const COL_OfficalTitleID2 As Integer = 9     ' Ngạch lương 02
    Private Const COL_SalaryLevelID2 As Integer = 10     ' Bậc lương 02
    Private Const COL_BaseSalary01 As Integer = 11       ' Mức lương 01
    Private Const COL_BaseSalary02 As Integer = 12       ' Mức lương 02
    Private Const COL_BaseSalary03 As Integer = 13       ' Mức lương 03
    Private Const COL_BaseSalary04 As Integer = 14       ' Mức lương 04
    Private Const COL_SalCoefficient01 As Integer = 15   ' Hệ số 1
    Private Const COL_SalCoefficient02 As Integer = 16   ' Hệ số 2
    Private Const COL_SalCoefficient03 As Integer = 17   ' Hệ số 3
    Private Const COL_SalCoefficient04 As Integer = 18   ' Hệ số 4
    Private Const COL_SalCoefficient05 As Integer = 19   ' Hệ số 5
    Private Const COL_SalCoefficient06 As Integer = 20   ' Hệ số 6
    Private Const COL_SalCoefficient07 As Integer = 21   ' Hệ số 7
    Private Const COL_SalCoefficient08 As Integer = 22   ' Hệ số 8
    Private Const COL_SalCoefficient09 As Integer = 23   ' Hệ số 9
    Private Const COL_SalCoefficient10 As Integer = 24   ' Hệ số 10
    Private Const COL_TransID As Integer = 25            ' TransID
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            LoadTDBDropDown()

            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
            End Select
        End Set
    End Property

    Private _defaultSalID As String = ""
    Public Property DefaultSalID() As String
        Get
            Return _defaultSalID
        End Get
        Set(ByVal Value As String)
            _defaultSalID = Value
        End Set
    End Property

    Private _defaultSalName As String = ""
    Public Property DefaultSalName() As String
        Get
            Return _defaultSalName
        End Get
        Set(ByVal Value As String)
            _defaultSalName = Value
        End Set
    End Property

    Private _effectiveDateFrom As String = ""
    Public WriteOnly Property EffectiveDateFrom() As String 
        Set(ByVal Value As String )
            _effectiveDateFrom = Value
        End Set
    End Property

    Private _effectiveDateTo As String = ""
    Public WriteOnly Property EffectiveDateTo() As String 
        Set(ByVal Value As String )
            _effectiveDateTo = Value
        End Set
    End Property

    Dim dtGrid, dtSalaryLevelID, dtCaption, dtSalBase, dtSalCoeff As DataTable
    Dim iLastCol As Integer
    Dim bNotInList As Boolean = False, bContinue As Boolean = False
    Dim iCol As Integer

    Private Sub D09F0161_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D09F0161_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        tdbg_NumberFormat()
        LoadData()
        CreateTableCaption()
        GetCaptionSalBase()
        GetCaptionSalCoeff()
        LoadTDBGrid()
        VisibeColumns()

        iLastCol = CountCol(tdbg, SPLIT1)
        '****************************
        If _FormState = EnumFormState.FormView Then
            btnSave.Enabled = False
            btnUpdate.Enabled = False
        Else
            'btnSave.Enabled = ReturnPermission("D13F1161") > EnumPermission.View
        End If
        '****************************
        InputbyUnicode(Me, gbUnicode)
        '****************************
        SetResolutionForm(Me)
    End Sub

    Private Sub LoadData()
        txtDefaultSalID.Text = _defaultSalID
        txtDefaultSalName.Text = _defaultSalName
        c1dateEffectiveDateFrom.Value = _effectiveDateFrom
        c1dateEffectiveDateTo.Value = _effectiveDateTo
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_thong_so_luong_mac_dinh_-_D13F1162") & UnicodeCaption(gbUnicode) 'Chi tiÕt th¤ng sç l§¥ng mÆc ¢Ünh - D13F1162
        '================================================================ 
        lblDefaultSalID.Text = rL3("Thong_so_luong_mac_dinh") 'Thông số lương mặc định
        '================================================================ 
        lblEffectiveDateTo.Text = rL3("Hieu_luc_den") 'Hiệu lực đến
        lblEffectiveDateFrom.Text = rL3("Hieu_luc_tu") 'Hiệu lực từ
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnUpdate.Text = rL3("_Cap_nhat_thong_so_luong") '&Cập nhật thông số lương
        '================================================================ 
        tdbdDutyID.Columns("DutyID").Caption = rl3("Ma") 'Mã
        tdbdDutyID.Columns("DutyName").Caption = rl3("Ten") 'Tên
        tdbdProfessionalLevelID.Columns("ProfessionalLevelID").Caption = rl3("Ma") 'Mã
        tdbdProfessionalLevelID.Columns("ProfessionalLevelName").Caption = rl3("Ten") 'Tên
        tdbdOfficialTitleID.Columns("OfficialTitleID").Caption = rl3("Ma") 'Mã
        tdbdOfficialTitleID.Columns("OfficialTitleName").Caption = rl3("Ten") 'Tên
        tdbdSalaryLevelID.Columns("SalaryLevelID").Caption = rl3("Ma") 'Mã
        tdbdSalaryLevelID.Columns("SalaryCoefficient").Caption = rl3("He_so_luong") 'Hệ số lương
        tdbdDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbdOfficialTitleID2.Columns("OfficialTitleID").Caption = rl3("Ma") 'Mã
        tdbdOfficialTitleID2.Columns("OfficialTitleName").Caption = rl3("Ten") 'Tên
        tdbdEmployeeTypeID.Columns("EmployeeTypeID").Caption = rl3("Ma") 'Mã
        tdbdEmployeeTypeID.Columns("EmployeeTypeName").Caption = rl3("Ten") 'Tên
        tdbdWorkingStatusID.Columns("WorkingStatusID").Caption = rl3("Ma") 'Mã
        tdbdWorkingStatusID.Columns("WorkingStatusName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("DutyID").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns("ProfessionalLevelID").Caption = rl3("Trinh_do_chuyen_mon_U") 'Trình độ chuyên môn
        tdbg.Columns("EmployeeTypeID").Caption = rl3("Doi_tuong_lao_dong") 'Đối tượng lao động
        tdbg.Columns("WorkingStatusID").Caption = rl3("Trang_thai_lam_viec") 'Trạng thái làm việc
        tdbg.Columns("WorkID").Caption = rl3("Cong_viec") 'Công việc
        tdbg.Columns("EducationLevelID").Caption = rl3("Trinh_do_hoc_van") 'Trình độ học vấn

        tdbg.Columns("OfficalTitleID").Caption = rl3("Ngach_luong_01") 'Ngạch lương 01
        tdbg.Columns("SalaryLevelID").Caption = rl3("Bac_luong_01U") 'Bậc lương 01
        tdbg.Columns("OfficalTitleID2").Caption = rl3("Ngach_luong_02") 'Ngạch lương 02
        tdbg.Columns("SalaryLevelID2").Caption = rl3("Bac_luong_02") 'Bậc lương 02
        '================================================================ 
        tdbg.Splits(0).Caption = rl3("Co_so_thiet_lap") 'Cơ sở thiết lập
        tdbg.Splits(1).Caption = rl3("Thong_so_luong") 'Thông số lương
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_BaseSalary01).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_BaseSalary02).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_BaseSalary03).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_BaseSalary04).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_SalCoefficient01).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_SalCoefficient02).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_SalCoefficient03).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_SalCoefficient04).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_SalCoefficient05).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_SalCoefficient06).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_SalCoefficient07).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_SalCoefficient08).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_SalCoefficient09).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_SalCoefficient10).NumberFormat = D13Format.DefaultNumber2
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbcDepartmentID
        sSQL = "Select DepartmentID, DepartmentName" & UnicodeJoin(gbUnicode) & " As DepartmentName" & vbCrLf
        sSQL &= "From D91T0012  WITH (NOLOCK) Where Disabled =0" & vbCrLf
        sSQL &= "Order by DepartmentName"
        LoadDataSource(tdbdDepartmentID, ReturnTableDepartmentID(True, False, gbUnicode), gbUnicode)

        'Load tdbdDutyID
        sSQL = "SELECT DutyID, DutyName" & UnicodeJoin(gbUnicode) & " as DutyName" & vbCrLf
        sSQL &= "FROM D09T0211  WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY DutyName" & vbCrLf
        LoadDataSource(tdbdDutyID, sSQL, gbUnicode)

        'Load tdbdProfessionalLevelID
        sSQL = "SELECT ProfessionalLevelID, ProfessionalLevelName" & UnicodeJoin(gbUnicode) & " as ProfessionalLevelName" & vbCrLf
        sSQL &= "FROM D09T0205 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY ProfessionalLevelName" & vbCrLf
        LoadDataSource(tdbdProfessionalLevelID, sSQL, gbUnicode)

        'Load tdbdEmployeeTypeID
        sSQL = "SELECT LookupID As EmployeeTypeID, Description" & UnicodeJoin(gbUnicode) & " As EmployeeTypeName" & vbCrLf
        sSQL &= "FROM D91T0320 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE LookupType = 'D09_LaborObject' AND Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY EmployeeTypeName"
        LoadDataSource(tdbdEmployeeTypeID, sSQL, gbUnicode)

        'Load tdbdWorkingStatusID
        sSQL = "SELECT  StatusID as WorkingStatusID, StatusName" & UnicodeJoin(gbUnicode) & " as WorkingStatusName" & vbCrLf
        sSQL &= "FROM D09T0111  WITH (NOLOCK) WHERE Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY WorkingStatusName"
        LoadDataSource(tdbdWorkingStatusID, sSQL, gbUnicode)

        'Load tdbdOfficialTitleID
        sSQL = "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " as OfficialTitleName" & vbCrLf
        sSQL &= "From D09T0214  WITH (NOLOCK) Where Disabled = 0 AND (IsUseOfficial = 0 OR IsUseOfficial = 1) Order By OfficialTitleID "
        LoadDataSource(tdbdOfficialTitleID, sSQL, gbUnicode)

        'Load tdbdOfficialTitleID2
        sSQL = "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " as OfficialTitleName" & vbCrLf
        sSQL &= " From D09T0214  WITH (NOLOCK) Where Disabled = 0 AND (IsUseOfficial = 0 OR IsUseOfficial = 2) Order By OfficialTitleID "
        LoadDataSource(tdbdOfficialTitleID2, sSQL, gbUnicode)

        'Load tdbdSalaryLevelID
        sSQL = "SELECT SalaryLevelID, SalaryCoefficient, OfficialTitleID " & vbCrLf
        sSQL &= "FROM D09T0215  WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE 	Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY SalaryLevelID" & vbCrLf
        dtSalaryLevelID = ReturnDataTable(sSQL)

        'Load tdbdWorkID
        sSQL = "SELECT     WorkID, WorkName" & UnicodeJoin(gbUnicode) & " As WorkName " & vbCrLf
        sSQL &= "FROM       D09T0224  WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE      Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY   WorkName" & vbCrLf
        LoadDataSource(tdbdWorkID, sSQL, gbUnicode)

        'Load tdbdEducationLevelID
        sSQL = "SELECT     EducationLevelID, EducationLevelName" & UnicodeJoin(gbUnicode) & " As EducationLevelName" & vbCrLf
        sSQL &= "FROM 		D09T0206  WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY 	EducationLevelName" & vbCrLf
        LoadDataSource(tdbdEducationLevelID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBDSalaryLevelID(ByVal ID As String)
        LoadDataSource(tdbdSalaryLevelID, ReturnTableFilter(dtSalaryLevelID, "OfficialTitleID=" & SQLString(ID)), gbUnicode)
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""

        sSQL = "SELECT D61.TransID, D61.DefaultSalID, D61.DepartmentID, D61.DutyID, D61.ProfessionalLevelID, D61.EmployeeTypeID, D61.WorkingStatusID, " & vbCrLf
        sSQL &= "D61.OfficalTitleID, D61.SalaryLevelID, D61.OfficalTitleID2, D61.SalaryLevelID2, D61.BaseSalary01, D61.BaseSalary02, D61.BaseSalary03, D61.BaseSalary04, " & vbCrLf
        sSQL &= "D61.SalCoefficient01, D61.SalCoefficient02, D61.SalCoefficient03, D61.SalCoefficient04, D61.SalCoefficient05, " & vbCrLf
        sSQL &= "D61.SalCoefficient06, D61.SalCoefficient07, D61.SalCoefficient08, D61.SalCoefficient09, D61.SalCoefficient10, " & vbCrLf
        sSQL &= "D61.WorkID, D61.EducationLevelID" & vbCrLf
        sSQL &= "FROM D09T0161 D61 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE D61.DefaultSalID = " & SQLString(_defaultSalID) & vbCrLf
        sSQL &= "ORDER BY D61.TransID"
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
    End Sub

    Private Sub VisibeColumns()
        Dim sSQL As String = ""
        Dim i As Integer = 0
        Dim iCol As Integer = -1

        sSQL = "SELECT D60.DefaultSalID, D60.DefaultSalName" & UnicodeJoin(gbUnicode) & " As DefaultSalName, D60.ChkDepartment, D60.ChkDuty, D60.ChkLevel, D60.ChkEmployeeType, D60.ChkWorkingStatus, " & vbCrLf
        sSQL &= "D60.ChkWork, D60.ChkEducationLevel, " & vbCrLf
        sSQL &= "D60.ChkSalary01, D60.ChkSalary02, D60.ChkBaseSalary01, D60.ChkBaseSalary02, D60.ChkBaseSalary03, D60.ChkBaseSalary04, " & vbCrLf
        sSQL &= "D60.ChkSalCoefficient01, D60.ChkSalCoefficient02, D60.ChkSalCoefficient03, D60.ChkSalCoefficient04, D60.ChkSalCoefficient05, " & vbCrLf
        sSQL &= "D60.ChkSalCoefficient06, D60.ChkSalCoefficient07,  D60.ChkSalCoefficient08, D60.ChkSalCoefficient09, D60.ChkSalCoefficient10 " & vbCrLf
        sSQL &= "FROM D09T0160 D60  WITH (NOLOCK) WHERE D60.DefaultSalID =  " & SQLString(_defaultSalID)
        Dim dt As DataTable = ReturnDataTable(sSQL)

        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                'Split Co so thiet lap
                iCol = COL_DepartmentID
                For i = 2 To 8
                    tdbg.Splits(0).DisplayColumns(iCol).Visible = L3Bool(.Item(i))
                    iCol = iCol + 1
                Next

                'Split Thong so luong
                iCol = COL_OfficalTitleID
                For i = 9 To dt.Columns.Count - 1
                    tdbg.Splits(1).DisplayColumns(iCol).Visible = L3Bool(.Item(i))

                    If iCol = COL_OfficalTitleID Or iCol = COL_OfficalTitleID2 Then
                        tdbg.Splits(1).DisplayColumns(iCol + 1).Visible = L3Bool(.Item(i))
                        iCol = iCol + 1
                    End If

                    iCol = iCol + 1
                Next
            End With
        End If
    End Sub

    Private Sub LoadColumnsCaption()
        Dim sSQL As String = ""
        sSQL = "SELECT Code, Short" & UnicodeJoin(gbUnicode) & " As Short" & vbCrLf
        sSQL &= "FROM D13T9000 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE Type = 'SALCE'AND Disabled = 0 " & vbCrLf
        sSQL &= "UNION " & vbCrLf
        sSQL &= "SELECT Code, Short" & UnicodeJoin(gbUnicode) & " As Short" & vbCrLf
        sSQL &= "FROM D13T9000  WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE Type = 'SALBA' AND Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY Code" & vbCrLf
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim col As Integer = COL_BaseSalary01

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                With dt
                    If tdbg.Splits(SPLIT1).DisplayColumns(col).Visible = True Then
                        tdbg.Columns(col).Caption = .Rows(i).Item("Short").ToString
                        tdbg.Splits(SPLIT1).DisplayColumns(col).HeadingStyle.Font = FontUnicode(gbUnicode)
                        col += 1
                    End If
                End With
            Next

        End If
    End Sub

    Private Sub CreateTableCaption()
        Dim sSQL As String
        sSQL = "Select * From D13T9000  WITH (NOLOCK) Order By Code "
        dtCaption = ReturnDataTable(sSQL)
    End Sub

    Private Sub GetCaptionSalBase()
        dtSalBase = ReturnTableFilter(dtCaption, "Type='SALBA'")

        Dim iCol As Integer = COL_BaseSalary01
        If dtSalBase.Rows.Count > 0 Then
            For i As Integer = 0 To dtSalBase.Rows.Count - 1
                tdbg.Splits(SPLIT1).DisplayColumns(iCol).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(iCol).Caption = dtSalBase.Rows(i).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                iCol += 1
            Next
        End If
    End Sub

    Private Sub GetCaptionSalCoeff()

        dtSalCoeff = ReturnTableFilter(dtCaption, "Type='SALCE'")
        Dim iCol As Integer = COL_SalCoefficient01

        If dtSalCoeff.Rows.Count > 0 Then
            For i As Integer = 0 To 9 'dtSalCoeff.Rows.Count - 1
                tdbg.Splits(SPLIT1).DisplayColumns(iCol).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(iCol).Caption = dtSalCoeff.Rows(i).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                iCol += 1
            Next
        End If
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_DepartmentID
                If tdbg.Columns(COL_DepartmentID).Text <> tdbdDepartmentID.Columns(tdbdDepartmentID.DisplayMember).Text Then
                    bNotInList = True
                End If

            Case COL_DutyID
                If tdbg.Columns(COL_DutyID).Text <> tdbdDutyID.Columns(tdbdDutyID.DisplayMember).Text Then
                    bNotInList = True
                End If

            Case COL_ProfessionalLevelID
                If tdbg.Columns(COL_ProfessionalLevelID).Text <> tdbdProfessionalLevelID.Columns(tdbdProfessionalLevelID.DisplayMember).Text Then
                    bNotInList = True
                End If

            Case COL_EmployeeTypeID
                If tdbg.Columns(COL_EmployeeTypeID).Text <> tdbdEmployeeTypeID.Columns(tdbdEmployeeTypeID.DisplayMember).Text Then
                    bNotInList = True
                End If

            Case COL_WorkingStatusID
                If tdbg.Columns(COL_WorkingStatusID).Text <> tdbdWorkingStatusID.Columns(tdbdWorkingStatusID.DisplayMember).Text Then
                    bNotInList = True
                End If

            Case COL_WorkID
                If tdbg.Columns(COL_WorkID).Text <> tdbdWorkID.Columns(tdbdWorkID.DisplayMember).Text Then
                    bNotInList = True
                End If

            Case COL_EducationLevelID
                If tdbg.Columns(COL_EducationLevelID).Text <> tdbdEducationLevelID.Columns(tdbdEducationLevelID.DisplayMember).Text Then
                    bNotInList = True
                End If

            Case COL_OfficalTitleID
                If tdbg.Columns(COL_OfficalTitleID).Text <> tdbdOfficialTitleID.Columns("OfficialTitleID").Text Then
                    tdbg.Columns(COL_OfficalTitleID).Text = ""
                    tdbg.Columns(COL_SalaryLevelID).Text = ""
                End If

            Case COL_SalaryLevelID
                If tdbg.Columns(COL_SalaryLevelID).Text <> tdbdSalaryLevelID.Columns("SalaryLevelID").Text Then
                    tdbg.Columns(COL_SalaryLevelID).Text = ""
                End If

            Case COL_OfficalTitleID2
                If tdbg.Columns(COL_OfficalTitleID2).Text <> tdbdOfficialTitleID2.Columns("OfficialTitleID").Text Then
                    tdbg.Columns(COL_OfficalTitleID2).Text = ""
                    tdbg.Columns(COL_SalaryLevelID2).Text = ""
                End If

            Case COL_SalaryLevelID2
                If tdbg.Columns(COL_SalaryLevelID2).Text <> tdbdSalaryLevelID.Columns("SalaryLevelID").Text Then
                    tdbg.Columns(COL_SalaryLevelID2).Text = ""
                End If

            Case COL_BaseSalary01, COL_BaseSalary02, COL_BaseSalary03, COL_BaseSalary04
                If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Number) Then tdbg.Columns(e.ColIndex).Text = "0"

            Case COL_SalCoefficient01, COL_SalCoefficient02, COL_SalCoefficient03, COL_SalCoefficient04, COL_SalCoefficient05
                If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Number) Then tdbg.Columns(e.ColIndex).Text = "0"

            Case COL_SalCoefficient06, COL_SalCoefficient07, COL_SalCoefficient08, COL_SalCoefficient09, COL_SalCoefficient10
                If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Number) Then tdbg.Columns(e.ColIndex).Text = "0"
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_DepartmentID
                If bNotInList Then
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    bNotInList = False
                End If
            Case COL_DutyID
                If bNotInList Then
                    tdbg.Columns(COL_DutyID).Text = ""
                    bNotInList = False
                End If
            Case COL_ProfessionalLevelID
                If bNotInList Then
                    tdbg.Columns(COL_ProfessionalLevelID).Text = ""
                    bNotInList = False
                End If
            Case COL_EmployeeTypeID
                If bNotInList Then
                    tdbg.Columns(COL_EmployeeTypeID).Text = ""
                    bNotInList = False
                End If
            Case COL_WorkingStatusID
                If bNotInList Then
                    tdbg.Columns(COL_WorkingStatusID).Text = ""
                    bNotInList = False
                End If
            Case COL_WorkID
                If bNotInList Then
                    tdbg.Columns(COL_WorkID).Text = ""
                    bNotInList = False
                End If
            Case COL_EducationLevelID
                If bNotInList Then
                    tdbg.Columns(COL_EducationLevelID).Text = ""
                    bNotInList = False
                End If
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_OfficalTitleID
                tdbg.Columns(COL_SalaryLevelID).Text = ""
            Case COL_SalaryLevelID
                tdbg.Columns(COL_SalaryLevelID).Text = tdbdSalaryLevelID.Columns("SalaryLevelID").Text
            Case COL_OfficalTitleID2
                tdbg.Columns(COL_SalaryLevelID2).Text = ""
            Case COL_SalaryLevelID2
                tdbg.Columns(COL_SalaryLevelID2).Text = tdbdSalaryLevelID.Columns("SalaryLevelID").Text
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_BaseSalary01, COL_BaseSalary02, COL_BaseSalary03, COL_BaseSalary04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SalCoefficient01, COL_SalCoefficient02, COL_SalCoefficient03, COL_SalCoefficient04, COL_SalCoefficient05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_SalCoefficient06, COL_SalCoefficient07, COL_SalCoefficient08, COL_SalCoefficient09, COL_SalCoefficient10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub


    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                HotKeyF7(tdbg)
            Case Keys.F8
                HotKeyF8(tdbg)
            Case Keys.Enter
                If tdbg.Col = iLastCol Then HotKeyEnterGrid(tdbg, COL_DepartmentID, e)
        End Select

        If e.KeyCode = Keys.Shift Then
            If e.KeyCode = Keys.Insert Then
                HotKeyShiftInsert(tdbg)
            End If
        End If
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)

        HotKeyDownGrid(e, tdbg, COL_DepartmentID, SPLIT0, SPLIT1)
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_SalaryLevelID
                LoadTDBDSalaryLevelID(tdbg(tdbg.Row, COL_OfficalTitleID).ToString)
                tdbdSalaryLevelID.Columns(1).NumberFormat = D13Format.DefaultNumber2

            Case COL_SalaryLevelID2
                LoadTDBDSalaryLevelID(tdbg(tdbg.Row, COL_OfficalTitleID2).ToString)
                tdbdSalaryLevelID.Columns(1).NumberFormat = D13Format.DefaultNumber2
        End Select
    End Sub

    ' 13/6/2014 id 65256 - Bổ sung cho cột số
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_DepartmentID, COL_DutyID, COL_ProfessionalLevelID, COL_EmployeeTypeID, COL_WorkingStatusID, COL_WorkID, COL_EducationLevelID, COL_BaseSalary01, COL_BaseSalary02, COL_BaseSalary03, COL_BaseSalary04, COL_SalCoefficient01, COL_SalCoefficient02, COL_SalCoefficient03, COL_SalCoefficient04, COL_SalCoefficient05, COL_SalCoefficient06, COL_SalCoefficient07, COL_SalCoefficient08, COL_SalCoefficient09, COL_SalCoefficient10
                'Copy 1 cột
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Bookmark)
            Case COL_OfficalTitleID, COL_SalaryLevelID
                'Copy nhiều cột
                Dim iColRelative() As Integer = {COL_OfficalTitleID, COL_SalaryLevelID}
                CopyColumnArr(tdbg, iCol, iColRelative)
            Case COL_OfficalTitleID2, COL_SalaryLevelID2
                'Copy nhiều cột
                Dim iColRelative() As Integer = {COL_OfficalTitleID2, COL_SalaryLevelID2}
                CopyColumnArr(tdbg, iCol, iColRelative)
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()

        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLDeleteD09T0161() & vbCrLf)
        sSQL.Append(SQLInsertD09T0161s())

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            Return False
        End If

        With tdbg.Splits(0)
            For i As Integer = 0 To tdbg.RowCount - 1
                bContinue = False
                Dim sText As String = ReturnValue(i)
                If sText <> "" Then
                    D99C0008.MsgNotYetChoose(sText)
                    tdbg.Focus()
                    tdbg.Row = i
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = iCol
                    Return False
                End If

                Dim iBookmark As Integer = ReturnRecord(i)
                If iBookmark <> -1 Then
                    D99C0008.MsgDuplicatePKey()
                    tdbg.Focus()
                    tdbg.Row = iBookmark
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_DepartmentID
                    Return False
                End If
            Next
        End With
        Return True
    End Function


    Private Function ReturnRecord(ByVal iRow As Integer) As Integer
        Dim sField As String = ""
        Dim iBookmark As Integer = -1

        For i As Integer = COL_DepartmentID To COL_EducationLevelID
            If tdbg.Splits(0).DisplayColumns(i).Visible And tdbg(iRow, i).ToString <> "" Then
                If sField = "" Then
                    sField = tdbg.Columns(i).DataField & "= " & SQLString(tdbg(iRow, i).ToString)
                Else
                    sField &= " And " & tdbg.Columns(i).DataField & "= " & SQLString(tdbg(iRow, i).ToString)
                End If
            End If
        Next

        If sField <> "" Then
            Dim dr() As DataRow = dtGrid.Select(sField)
            If dr.Length > 1 Then
                iBookmark = dtGrid.Rows.IndexOf(dr(1))
            End If
        End If
        Return iBookmark
    End Function

    Private Function ReturnValue(ByVal iRow As Integer) As String
        Dim sText As String = ""
        iCol = -1

        For i As Integer = COL_DepartmentID To COL_WorkingStatusID
            If tdbg.Splits(0).DisplayColumns(i).Visible Then
                If tdbg(iRow, i).ToString = "" Then
                    If sText = "" Then
                        sText = tdbg.Columns(i).Caption
                    Else
                        sText &= " / " & tdbg.Columns(i).Caption
                    End If
                    If iCol = -1 Then iCol = i
                Else 'da nhap gia tri
                    bContinue = True
                    sText = ""
                    Exit For
                End If
              
            End If
        Next

        Return sText
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T0161
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 06/03/2008 02:31:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T0161() As String
        Dim sSQL As String = ""
        'sSQL &= "Delete From D09T0161"
        'sSQL &= "Delete From D09T0161 where TransID  Between " & SQLString(tdbg(0, COL_TransID)) & " and " & SQLString(tdbg(tdbg.RowCount - 1, COL_TransID))
        'For i As Integer = 0 To tdbg.RowCount - 1
        '    sSQL &= "Delete From D09T0161 where TransID = " & SQLString(tdbg(i, COL_TransID)) & vbCrLf
        'Next
        sSQL = "Delete From D09T0161 where DefaultSalID  = " & SQLString(_defaultSalID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T0161s
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 06/03/2008 02:32:07
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T0161s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sTransID As String = ""
        Dim iCountIGE As Int32 = 0
        Dim dr() As DataRow

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                sTransID = CreateIGEs("D09T0161", "TransID", "09", "DP", gsStringKey, sTransID, iCountIGE)
                tdbg(i, COL_TransID) = sTransID
            End If

            sSQL.Append("Insert Into D09T0161(")
            sSQL.Append("TransID,DefaultSalID, DepartmentID, DutyID, ProfessionalLevelID, EmployeeTypeID, WorkingStatusID, WorkID, EducationLevelID, ")
            sSQL.Append("OfficalTitleID, SalaryLevelID, OfficalTitleID2, SalaryLevelID2, BaseSalary01, ")
            sSQL.Append("BaseSalary02, BaseSalary03, BaseSalary04, SalCoefficient01, SalCoefficient02, ")
            sSQL.Append("SalCoefficient03, SalCoefficient04, SalCoefficient05, SalCoefficient06, SalCoefficient07, ")
            sSQL.Append("SalCoefficient08, SalCoefficient09, SalCoefficient10")
            sSQL.Append(") Values(")

            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_defaultSalID) & COMMA) 'DefaultSalID, varchar[20], NOT NULL

            If tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Visible Then
                sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'DepartmentID, decimal, NOT NULL
            End If

            If tdbg.Splits(0).DisplayColumns(COL_DutyID).Visible Then
                sSQL.Append(SQLString(tdbg(i, COL_DutyID)) & COMMA) 'DutyID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'DutyID, decimal, NOT NULL
            End If

            If tdbg.Splits(0).DisplayColumns(COL_ProfessionalLevelID).Visible Then
                sSQL.Append(SQLString(tdbg(i, COL_ProfessionalLevelID)) & COMMA) 'ProfessionalLevelID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'ProfessionalLevelID, decimal, NOT NULL
            End If

            If tdbg.Splits(0).DisplayColumns(COL_EmployeeTypeID).Visible Then
                sSQL.Append(SQLString(tdbg(i, COL_EmployeeTypeID)) & COMMA) 'EmployeeTypeID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'EmployeeTypeID, decimal, NOT NULL
            End If

            If tdbg.Splits(0).DisplayColumns(COL_WorkingStatusID).Visible Then
                sSQL.Append(SQLString(tdbg(i, COL_WorkingStatusID)) & COMMA) 'WorkingStatusID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'WorkingStatusID, decimal, NOT NULL
            End If

            If tdbg.Splits(0).DisplayColumns(COL_WorkID).Visible Then
                sSQL.Append(SQLString(tdbg(i, COL_WorkID)) & COMMA) 'WorkID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'WorkID, decimal, NOT NULL
            End If

            If tdbg.Splits(0).DisplayColumns(COL_EducationLevelID).Visible Then
                sSQL.Append(SQLString(tdbg(i, COL_EducationLevelID)) & COMMA) 'EducationLevelID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'EducationLevelID, decimal, NOT NULL
            End If

            If tdbg.Splits(1).DisplayColumns(COL_OfficalTitleID).Visible Then
                sSQL.Append(SQLString(tdbg(i, COL_OfficalTitleID)) & COMMA) 'OfficalTitleID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'OfficalTitleID, decimal, NOT NULL
            End If

            If tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID).Visible And tdbg(i, COL_OfficalTitleID).ToString <> "" And tdbg(i, COL_SalaryLevelID).ToString <> "" Then
                sSQL.Append(SQLString(tdbg(i, COL_SalaryLevelID)) & COMMA) 'SalaryLevelID, varchar[20], NOT NULL
            ElseIf (tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID).Visible = False) Or (tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID).Visible And tdbg(i, COL_OfficalTitleID).ToString = "" And tdbg(i, COL_SalaryLevelID).ToString = "") Then
                sSQL.Append(SQLString("") & COMMA) 'SalaryLevelID, decimal, NOT NULL
            ElseIf tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID).Visible And tdbg(i, COL_OfficalTitleID).ToString <> "" And tdbg(i, COL_SalaryLevelID).ToString = "" Then
                dr = dtSalaryLevelID.Select("OfficialTitleID=" & SQLString(tdbg(i, COL_OfficalTitleID).ToString))
                If dr.Length > 0 Then
                    sSQL.Append(SQLString(dr(0).Item("SalaryLevelID").ToString) & COMMA) 'SalaryLevelID, decimal, NOT NULL '
                Else
                    sSQL.Append(SQLString("") & COMMA) 'SalaryLevelID, decimal, NOT NULL '
                End If
            End If

            If tdbg.Splits(1).DisplayColumns(COL_OfficalTitleID2).Visible Then
                sSQL.Append(SQLString(tdbg(i, COL_OfficalTitleID2)) & COMMA) 'SalaryLevelID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'SalaryLevelID, decimal, NOT NULL
            End If

            If tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID2).Visible And tdbg(i, COL_OfficalTitleID2).ToString <> "" And tdbg(i, COL_SalaryLevelID2).ToString <> "" Then
                sSQL.Append(SQLString(tdbg(i, COL_SalaryLevelID2)) & COMMA) 'SalaryLevelID, varchar[20], NOT NULL
            ElseIf (tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID2).Visible = False) Or (tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID2).Visible And tdbg(i, COL_OfficalTitleID2).ToString = "" And tdbg(i, COL_SalaryLevelID2).ToString = "") Then
                sSQL.Append(SQLString("") & COMMA) 'SalaryLevelID, decimal, NOT NULL

            ElseIf tdbg.Splits(1).DisplayColumns(COL_SalaryLevelID2).Visible And tdbg(i, COL_OfficalTitleID2).ToString <> "" And tdbg(i, COL_SalaryLevelID2).ToString = "" Then
                dr = dtSalaryLevelID.Select("OfficialTitleID=" & SQLString(tdbg(i, COL_OfficalTitleID2).ToString))
                If dr.Length > 0 Then
                    sSQL.Append(SQLString(dr(0).Item("SalaryLevelID").ToString) & COMMA) 'SalaryLevelID, decimal, NOT NULL '
                Else
                    sSQL.Append(SQLString("") & COMMA) 'SalaryLevelID, decimal, NOT NULL '
                End If
            End If

            If tdbg.Splits(1).DisplayColumns(COL_BaseSalary01).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary01), D13Format.DefaultNumber2) & COMMA) 'BaseSalary01, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'BaseSalary01, decimal, NOT NULL
            End If
            If tdbg.Splits(1).DisplayColumns(COL_BaseSalary02).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary02), D13Format.DefaultNumber2) & COMMA) 'BaseSalary02, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'BaseSalary02, decimal, NOT NULL
            End If
            If tdbg.Splits(1).DisplayColumns(COL_BaseSalary03).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary03), D13Format.DefaultNumber2) & COMMA) 'BaseSalary03, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'BaseSalary03, decimal, NOT NULL
            End If
            If tdbg.Splits(1).DisplayColumns(COL_BaseSalary04).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_BaseSalary04), D13Format.DefaultNumber2) & COMMA) 'BaseSalary04, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'BaseSalary04, decimal, NOT NULL
            End If
            If tdbg.Splits(1).DisplayColumns(COL_SalCoefficient01).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient01), D13Format.DefaultNumber2) & COMMA) 'SalCoefficient01, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'SalCoefficient01, decimal, NOT NULL
            End If
            If tdbg.Splits(1).DisplayColumns(COL_SalCoefficient02).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient02), D13Format.DefaultNumber2) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            End If

            If tdbg.Splits(1).DisplayColumns(COL_SalCoefficient03).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient03), D13Format.DefaultNumber2) & COMMA) 'SalCoefficient03, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            End If
            If tdbg.Splits(1).DisplayColumns(COL_SalCoefficient04).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient04), D13Format.DefaultNumber2) & COMMA) 'SalCoefficient04, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            End If
            If tdbg.Splits(1).DisplayColumns(COL_SalCoefficient05).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient05), D13Format.DefaultNumber2) & COMMA) 'SalCoefficient04, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            End If

            If tdbg.Splits(1).DisplayColumns(COL_SalCoefficient06).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient06), D13Format.DefaultNumber2) & COMMA) 'SalCoefficient04, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            End If
            If tdbg.Splits(1).DisplayColumns(COL_SalCoefficient07).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient07), D13Format.DefaultNumber2) & COMMA) 'SalCoefficient04, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            End If
            If tdbg.Splits(1).DisplayColumns(COL_SalCoefficient08).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient08), D13Format.DefaultNumber2) & COMMA) 'SalCoefficient04, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            End If
            If tdbg.Splits(1).DisplayColumns(COL_SalCoefficient09).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient09), D13Format.DefaultNumber2) & COMMA) 'SalCoefficient04, decimal, NOT NULL
            Else
                sSQL.Append((0) & COMMA) 'SalCoefficient02, decimal, NOT NULL
            End If
            If tdbg.Splits(1).DisplayColumns(COL_SalCoefficient10).Visible Then
                sSQL.Append(SQLMoney(tdbg(i, COL_SalCoefficient10), D13Format.DefaultNumber2)) 'SalCoefficient04, decimal, NOT NULL
            Else
                sSQL.Append((0)) 'SalCoefficient02, decimal, NOT NULL
            End If

            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Me.Cursor = Cursors.WaitCursor
        btnClose.Enabled = False
        btnSave.Enabled = False
        btnUpdate.Enabled = False

        Dim sSQL As String = SQLStoreD13P5555()
        If CheckStore(sSQL) = False Then
            Me.Cursor = Cursors.Default
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnUpdate.Enabled = True
            Exit Sub
        End If

        sSQL = SQLStoreD13P1036()

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            D99C0008.MsgL3(rL3("Cap_nhat_thanh_cong"))
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnUpdate.Enabled = True
            btnClose.Focus()
        Else
            D99C0008.MsgL3(rL3("Cap_nhat_khong_thanh_cong"))
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: 
    '# Created Date: 09/07/2014 04:18:00
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra hieu luc cua thong so luong mac dinh" & vbCrLf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(_defaultSalID) & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateEffectiveDateFrom.Value) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateEffectiveDateTo.Value) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(0) 'Num01ID, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1036
    '# Created User: 
    '# Created Date: 09/07/2014 04:21:35
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1036() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Cap nhat thong so luong cho tat ca nhan vien thoa dieu kien" & vbCrlf)
        sSQL &= "Exec D13P1036 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString("") & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(2) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA 'TranTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(_defaultSalID) 'DefaultSalID, varchar[50], NOT NULL
        Return sSQL
    End Function

End Class