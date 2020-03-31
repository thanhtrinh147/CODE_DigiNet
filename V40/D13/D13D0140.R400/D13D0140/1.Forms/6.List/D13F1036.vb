Imports System
Public Class D13F1036

#Region "Const of tdbg"
    Private Const COL_IsChecked As Integer = 0             ' Chọn
    Private Const COL_DepartmentName As Integer = 1        ' Phòng ban
    Private Const COL_DutyName As Integer = 2              ' Chức vụ
    Private Const COL_WorkName As Integer = 3              ' Công việc
    Private Const COL_EducationLevelName As Integer = 4    ' Trình độ học vấn
    Private Const COL_ProfessionalLevelName As Integer = 5 ' Trình độ chuyên môn
    Private Const COL_EmployeeTypeName As Integer = 6      ' Đối tượng lao động
    Private Const COL_WorkingStatusName As Integer = 7     ' Trạng thái làm việc
    Private Const COL_BaseSalary01 As Integer = 8          ' Mức lương 01
    Private Const COL_BaseSalary02 As Integer = 9          ' Mức lương 02
    Private Const COL_BaseSalary03 As Integer = 10         ' Mức lương 03
    Private Const COL_BaseSalary04 As Integer = 11         ' Mức lương 04
    Private Const COL_SalCoefficient01 As Integer = 12     ' Hệ số 01
    Private Const COL_SalCoefficient02 As Integer = 13     ' Hệ số 02
    Private Const COL_SalCoefficient03 As Integer = 14     ' Hệ số 03
    Private Const COL_SalCoefficient04 As Integer = 15     ' Hệ số 04
    Private Const COL_SalCoefficient05 As Integer = 16     ' Hệ số 05
    Private Const COL_SalCoefficient06 As Integer = 17     ' Hệ số 06
    Private Const COL_SalCoefficient07 As Integer = 18     ' Hệ số 07
    Private Const COL_SalCoefficient08 As Integer = 19     ' Hệ số 08
    Private Const COL_SalCoefficient09 As Integer = 20     ' Hệ số 09
    Private Const COL_SalCoefficient10 As Integer = 21     ' Hệ số 10
    Private Const COL_OfficalTitleID As Integer = 22       ' Ngạch lương 01
    Private Const COL_SalaryLevelID As Integer = 23        ' Bậc lương 01
    Private Const COL_OfficalTitleID2 As Integer = 24      ' Ngạch lương 02
    Private Const COL_SalaryLevelID2 As Integer = 25       ' Bậc lương 02
#End Region

    Private dtGrid As DataTable

    Private _employeeID As String = ""
    Public Property EmployeeID() As String 
        Get
            Return _employeeID
        End Get
        Set(ByVal Value As String )
            _employeeID = Value
        End Set
    End Property

    Private _tableDefaultSalary As DataTable = Nothing
    Public Property TableDefaultSalary() As Datatable
        Get
            Return _tableDefaultSalary
        End Get
        Set(ByVal Value As Datatable)
            _tableDefaultSalary = Value
        End Set
    End Property
    'Private _divisionID As String = ""
    'Public WriteOnly Property DivisionID() As String 
    '    Set(ByVal Value As String )
    '        _divisionID = Value
    '    End Set
    'End Property

    Private Sub D13F1036_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If _divisionID.Trim = "" Then _divisionID = gsDivisionID
        LoadInfoGeneral()
        Loadlanguage()
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadCaption()
        dtGrid = ReturnDataTable(SQLStoreD13P1036())
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        SetResolutionForm(Me)
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

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_thong_so_luong_mac_dinh_-_D13F1036") & UnicodeCaption(gbUnicode) 'Chãn th¤ng sç l§¥ng mÆc ¢Ünh - D13F1036
        '================================================================ 
        btnChoose.Text = rl3("_Chon") '&Chọn
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("IsChecked").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("DepartmentName").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("DutyName").Caption = rl3("Chuc_vu") 'Chức vụ
        tdbg.Columns("WorkName").Caption = rl3("Cong_viec") 'Công việc
        tdbg.Columns("EducationLevelName").Caption = rl3("Trinh_do_hoc_van") 'Trình độ học vấn
        tdbg.Columns("ProfessionalLevelName").Caption = rl3("Trinh_do_chuyen_mon_U") 'Trình độ chuyên môn
        tdbg.Columns("EmployeeTypeName").Caption = rl3("Doi_tuong_lao_dong") 'Đối tượng lao động
        tdbg.Columns("WorkingStatusName").Caption = rl3("Trang_thai_lam_viec") 'Trạng thái làm việc
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DutyName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_WorkName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_EducationLevelName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ProfessionalLevelName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_EmployeeTypeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_WorkingStatusName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_BaseSalary01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_BaseSalary02).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_BaseSalary03).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_BaseSalary04).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient02).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient03).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient04).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient05).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient06).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient07).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient08).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient09).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalCoefficient10).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_OfficalTitleID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalaryLevelID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_OfficalTitleID2).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SalaryLevelID2).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadCaption()
        Dim sSQL As String = ""
        sSQL &= "Select * From D13T9000  WITH (NOLOCK) Order By Code"
        Dim dtCaption As DataTable = ReturnDataTable(sSQL)

        Dim dtBaseSalary As DataTable = ReturnTableFilter(dtCaption, " Type = 'SALBA'")
        If dtBaseSalary.Rows.Count > 0 Then
            For i As Integer = COL_BaseSalary01 To COL_BaseSalary04
                tdbg.Splits(SPLIT2).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dtBaseSalary.Rows(i - COL_BaseSalary01).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                tdbg.Splits(SPLIT2).DisplayColumns(i).Visible = Not CBool(dtBaseSalary.Rows(i - COL_BaseSalary01).Item("Disabled"))
            Next
        End If

        Dim dtSalCoefficient As DataTable = ReturnTableFilter(dtCaption, " Type = 'SALCE'")
        If dtSalCoefficient.Rows.Count > 0 Then
            For i As Integer = COL_SalCoefficient01 To COL_SalCoefficient10
                tdbg.Splits(SPLIT2).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dtSalCoefficient.Rows(i - COL_SalCoefficient01).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                tdbg.Splits(SPLIT2).DisplayColumns(i).Visible = Not CBool(dtSalCoefficient.Rows(i - COL_SalCoefficient01).Item("Disabled"))
            Next
        End If

        Dim dtOLSC As DataTable = ReturnTableFilter(dtCaption, " Type = 'OLSC'")

        If dtOLSC.Rows.Count > 0 Then
            For i As Integer = 0 To dtOLSC.Rows.Count - 1
                With dtOLSC.Rows(i)
                    Select Case .Item("Code").ToString
                        Case "OLSC1"
                            tdbg.Splits(SPLIT2).DisplayColumns(COL_OfficalTitleID).HeadingStyle.Font = FontUnicode(gbUnicode)
                            tdbg.Columns(COL_OfficalTitleID).Caption = dtOLSC.Rows(i).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            tdbg.Splits(SPLIT2).DisplayColumns(COL_OfficalTitleID).Visible = Not CBool(dtOLSC.Rows(i).Item("Disabled"))
                        Case "OLSC10"
                            tdbg.Splits(SPLIT2).DisplayColumns(COL_SalaryLevelID).HeadingStyle.Font = FontUnicode(gbUnicode)
                            tdbg.Columns(COL_SalaryLevelID).Caption = dtOLSC.Rows(i).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            tdbg.Splits(SPLIT2).DisplayColumns(COL_SalaryLevelID).Visible = Not CBool(dtOLSC.Rows(i).Item("Disabled"))
                        Case "OLSC2"
                            tdbg.Splits(SPLIT2).DisplayColumns(COL_OfficalTitleID2).HeadingStyle.Font = FontUnicode(gbUnicode)
                            tdbg.Columns(COL_OfficalTitleID2).Caption = dtOLSC.Rows(i).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            tdbg.Splits(SPLIT2).DisplayColumns(COL_OfficalTitleID2).Visible = Not CBool(dtOLSC.Rows(i).Item("Disabled"))
                        Case "OLSC20"
                            tdbg.Splits(SPLIT2).DisplayColumns(COL_SalaryLevelID2).HeadingStyle.Font = FontUnicode(gbUnicode)
                            tdbg.Columns(COL_SalaryLevelID2).Caption = dtOLSC.Rows(i).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            tdbg.Splits(SPLIT2).DisplayColumns(COL_SalaryLevelID2).Visible = Not CBool(dtOLSC.Rows(i).Item("Disabled"))
                    End Select
                End With
            Next
        End If

    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        Select Case e.ColIndex
            Case COL_IsChecked
                For i As Integer = 0 To tdbg.Row - 1
                    tdbg(i, COL_IsChecked) = False
                Next
                For i As Integer = tdbg.Row + 1 To tdbg.RowCount - 1
                    tdbg(i, COL_IsChecked) = False
                Next
        End Select
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim bFlag As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsChecked).ToString) = True Then
                bFlag = True
            End If
        Next
        If Not bFlag Then
            D99C0008.MsgL3(rl3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_IsChecked
            tdbg.Bookmark = 0
            Return False
        End If
        Return True
    End Function

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        If Not AllowSave() Then Exit Sub
        TableDefaultSalary = ReturnTableFilter(dtGrid, "IsChecked = True", True)
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1036
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 01/12/2010 09:26:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1036() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1036 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

End Class