Imports System
Public Class D13F2014

    Private _parentFormID As String = ""
    Public Property ParentFormID() As String 
        Get
            Return _parentFormID
        End Get
        Set(ByVal Value As String )
            _parentFormID = Value
        End Set
    End Property

    Private _tranTypeID As String = ""
    Public Property TranTypeID() As String 
        Get
            Return _tranTypeID
        End Get
        Set(ByVal Value As String )
            _tranTypeID = Value
        End Set
    End Property

    Private _payrollVoucherID As String = ""
    Public WriteOnly Property PayrollVoucherID() As String
        Set(ByVal Value As String)
            _payrollVoucherID = Value
        End Set
    End Property

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

#Region "Const of tdbg - Total of Columns: 24"
    Private Const COL_TransID As Integer = 0           ' TransID
    Private Const COL_IsUsed As Integer = 1            ' Chọn
    Private Const COL_EmployeeID As Integer = 2        ' Mã NV
    Private Const COL_EmployeeName As Integer = 3      ' Họ và tên
    Private Const COL_DivisionID As Integer = 4        ' Đơn vị
    Private Const COL_DepartmentID As Integer = 5      ' Phòng ban1
    Private Const COL_DepartmentName As Integer = 6    ' DepartmentName
    Private Const COL_TeamID As Integer = 7            ' Tổ nhóm1
    Private Const COL_EmpGroupID As Integer = 8        ' Nhóm nhân viên1
    Private Const COL_TeamName As Integer = 9          ' TeamName
    Private Const COL_DutyID As Integer = 10           ' Chức vụ 0
    Private Const COL_ProjectID As Integer = 11        ' Dự án
    Private Const COL_SubDivisionID As Integer = 12    ' Đơn vị 2
    Private Const COL_SubDepartmentID As Integer = 13  ' Phòng ban
    Private Const COL_SubTeamID As Integer = 14        ' Tổ nhóm
    Private Const COL_SubEmpGroupID As Integer = 15    ' Nhóm NV
    Private Const COL_SubDutyID As Integer = 16        ' Chức vụ
    Private Const COL_SubProjectID As Integer = 17     ' Dự án
    Private Const COL_TaxObjectID As Integer = 18      ' Đối tượng thuế
    Private Const COL_PayrollVoucherNo As Integer = 19 ' HSL tháng
    Private Const COL_PayrollVoucherID As Integer = 20 ' PayrollVoucherID
    Private Const COL_ValidDateFrom As Integer = 21    ' Ngày chấm công (từ)
    Private Const COL_ValidDateTo As Integer = 22      ' Ngày chấm công (đến)
    Private Const COL_RefNo As Integer = 23            ' Số tham chiếu
#End Region

    Dim dtPayroll, dtDepartmentID, dtTeam, dtEmpGroupID As DataTable
    '  Dim bFlagSavedOK As Boolean = False
    Dim bCancel As Boolean = False

    '    Private Sub D13F2014_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '        If bFlagSavedOK Then
    '            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "1")
    '        Else
    '            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "0")
    '        End If
    '    End Sub

    Private Sub D13F2014_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Loadlanguage()
        ResetSplitDividerSize(tdbg)
        ResetFooterGrid(tdbg, 0, 1)
        tdbg_LockedColumns()
        LoadTDBDropDown()
        LoadTDBGrid()
        tdbg.Columns(COL_SubDutyID).DropDown = Nothing
        InputDateInTrueDBGrid(tdbg, COL_ValidDateFrom, COL_ValidDateTo)


        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Mo_ho_so_luong_phu_-_D13F2014") & UnicodeCaption(gbUnicode) 'Mê hä s¥ l§¥ng phó - D13F2014
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbdDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbdTaxObjectID.Columns("TaxObjectID").Caption = rl3("Ma") 'Mã
        tdbdTaxObjectID.Columns("TaxObjectName").Caption = rl3("Ten") 'Tên
        tdbdPayrollVoucherID.Columns("PayrollVoucherNo").Caption = rl3("Ma") 'Mã
        tdbdPayrollVoucherID.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbdSubEmpGroupID.Columns("EmpGroupID").Caption = rl3("Ma") 'Mã
        tdbdSubEmpGroupID.Columns("EmpGroupName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_EmployeeID).Caption = rL3("Ma_NV") 'Mã NV
        tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("SubDepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("SubTeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("TaxObjectID").Caption = rl3("Doi_tuong_thue") 'Đối tượng thuế
        tdbg.Columns("PayrollVoucherNo").Caption = rl3("HSL_thang") 'HSL tháng
        tdbg.Columns("DivisionID").Caption = rl3("Don_vi")
        tdbg.Columns("SubDivisionID").Caption = rl3("Don_vi")
        tdbg.Columns("ValidDateFrom").Caption = rl3("Ngay_cham_cong") & " (" & rl3("Tu") & ")"
        tdbg.Columns("ValidDateto").Caption = rl3("Ngay_cham_cong") & " (" & rl3("Den") & ")"
        tdbg.Columns(COL_DutyID).Caption = rl3("Chuc_vu")
        tdbg.Columns(COL_SubDutyID).Caption = rl3("Chuc_vu")
        tdbg.Columns("RefNo").Caption = rl3("So_tham_chieu") 'Số tham chiếu
        tdbg.Columns("EmpGroupID").Caption = rl3("Nhom_nhan_vien") 'Nhóm nhân viên
        tdbg.Columns(COL_SubEmpGroupID).Caption = rL3("Nhom_NV") 'Nhóm NV
        tdbg.Splits(0).Caption = rl3("Thong_tin_chinh")
        tdbg.Splits(1).Caption = rL3("Thong_tin_mo_HSL_phu")
        tdbg.Columns(COL_ProjectID).Caption = rL3("Cong_trinh") 'Dự án
        tdbg.Columns(COL_SubProjectID).Caption = rL3("Cong_trinh") 'Dự án

        '================================================================ 
        tdbdProjectID.Columns("ProjectID").Caption = rL3("Ma") 'Mã
        tdbdProjectID.Columns("ProjectName").Caption = rL3("Ten") 'Tên

    End Sub

    Private Sub tdbg_LockedColumns()
        For i As Integer = COL_DivisionID To COL_DutyID
            tdbg.Splits(SPLIT0).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT0).DisplayColumns(i).Locked = True
        Next
        If _parentFormID = "D13F2012" Then
            tdbg.Splits(SPLIT1).DisplayColumns(COL_PayrollVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        Else
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubDepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubTeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubEmpGroupID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            ' update 5/8/2013 id 56746 - Thảo Bích Thuận - lock cột SubDutyID
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubDutyID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubProjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        End If
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_SubDivisionID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TaxObjectID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ValidDateFrom).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ValidDateTo).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBGrid()
        LoadDataSource(tdbg, SQLStoreD13P2010, gbUnicode)

        If _parentFormID = "D13F2012" Then
            tdbg.Columns(COL_PayrollVoucherID).DropDown = Nothing
            tdbg.Splits(SPLIT1).DisplayColumns(COL_PayrollVoucherID).AutoDropDown = False
            tdbg.Splits(SPLIT1).DisplayColumns(COL_PayrollVoucherID).Locked = True
        Else
            tdbg.Columns(COL_SubDepartmentID).DropDown = Nothing
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubDepartmentID).AutoDropDown = False
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubDepartmentID).Locked = True

            tdbg.Columns(COL_SubTeamID).DropDown = Nothing
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubTeamID).AutoDropDown = False
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubTeamID).Locked = True

            tdbg.Columns(COL_SubEmpGroupID).DropDown = Nothing
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubEmpGroupID).AutoDropDown = False
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubEmpGroupID).Locked = True

            ' update 5/8/2013 id 56746 - Thảo Bích Thuận - lock cột SubDutyID
            tdbg.Columns(COL_SubDutyID).DropDown = Nothing
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubDutyID).AutoDropDown = False
            tdbg.Splits(SPLIT1).DisplayColumns(COL_SubDutyID).Locked = True
        End If

        FooterTotalGrid(tdbg, COL_EmployeeName)
    End Sub


    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbdDepartmentID
        sSQL = "SELECT DepartmentID, DepartmentName" & UnicodeJoin(gbUnicode) & " as DepartmentName, DivisionID" & vbCrLf
        sSQL &= "FROM D91T0012 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY DepartmentID"
        dtDepartmentID = ReturnDataTable(sSQL)

        'Load tdbdTeamID
        sSQL = "SELECT D01.TeamID, D01.TeamName" & UnicodeJoin(gbUnicode) & " as TeamName, D01.DepartmentID, D02.DivisionID" & vbCrLf
        sSQL &= "FROM D09T0227 D01  WITH (NOLOCK) " & vbCrLf
        sSQL &= "INNER JOIN D91T0012 D02  WITH (NOLOCK) On D02.DepartmentID = D01.DepartmentID " & vbCrLf
        sSQL &= "WHERE D01.Disabled = 0" & vbCrLf
        sSQL &= "AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "ORDER BY D01.TeamID"
        dtTeam = ReturnDataTable(sSQL)

        'Load tdbdSubEmpGroupID
        sSQL = "SELECT EmpGroupID, EmpGroupName" & gsLanguage & UnicodeJoin(gbUnicode) & " As EmpGroupName, DepartmentID, TeamID" & vbCrLf
        sSQL &= "FROM D09T1210  WITH (NOLOCK) WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY EmpGroupID"
        dtEmpGroupID = ReturnDataTable(sSQL)

        'Load tdbdTaxObjectID
        sSQL = "SELECT TaxObjectID, TaxObjectName" & UnicodeJoin(gbUnicode) & " as TaxObjectName" & vbCrLf
        sSQL &= "FROM D13T0128 WITH (NOLOCK) " & vbCrLf
        sSQL &= "ORDER BY TaxObjectID"
        LoadDataSource(tdbdTaxObjectID, sSQL, gbUnicode)

        'Load tdbdDutyID
        sSQL = "Select DutyID, DutyName" & UnicodeJoin(gbUnicode) & " as DutyName" & vbCrLf
        sSQL &= "From D09T0211 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "Order by DutyID" & vbCrLf
        LoadDataSource(tdbdDutyID, sSQL, gbUnicode)


        sSQL = "--Do nguon cho du an (SubProject)" & vbCrLf & _
            "SELECT 		D09. ProjectID AS ProjectID, D09.DescriptionU AS ProjectName" & vbCrLf & _
            "FROM 		D09T1080 D09  WITH(NOLOCK)" & vbCrLf & _
            "WHERE 		D09.[Disabled] = 0" & vbCrLf & _
            "ORDER BY 	D09.ProjectID"
        LoadDataSource(tdbdProjectID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTdbdDepartmentID()
        LoadDataSource(tdbdDepartmentID, ReturnTableFilter(dtDepartmentID, "DivisionID = " & SQLString(tdbg.Columns(COL_SubDivisionID).Text)), gbUnicode)
    End Sub

    Private Sub LoadTDBDTeamID()
        LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeam, "DivisionID = " & SQLString(tdbg.Columns(COL_SubDivisionID).Text) & " And DepartmentID = " & SQLString(tdbg.Columns(COL_SubDepartmentID).Text)), gbUnicode)
    End Sub

    Private Sub LoadTDBDSubEmpGroupID()
        LoadDataSource(tdbdSubEmpGroupID, ReturnTableFilter(dtEmpGroupID, "DepartmentID = " & SQLString(tdbg.Columns(COL_SubDepartmentID).Text) & " And TeamID = " & SQLString(tdbg.Columns(COL_SubTeamID).Text)), gbUnicode)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2013s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 13/10/2009 11:25:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2013s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        Dim sTransID As String = ""

        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) Then
                sTransID = CreateIGE("D13T0101", "TransID", "13", "DP", gsStringKey)

                sSQL = ""
                sSQL &= "Exec D13P2013 "
                sSQL &= SQLString(sTransID) & COMMA 'TransID, varchar[20], NOT NULL
                If _parentFormID = "D13F2012" Then
                    sSQL &= SQLString(tdbg(i, COL_PayrollVoucherID)) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
                Else
                    sSQL &= SQLString("") & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
                End If
                sSQL &= SQLString(tdbg(i, COL_SubDivisionID)) & COMMA 'SubDivisionID, varchar[20], NOT NULL
                sSQL &= SQLString(tdbg(i, COL_EmployeeID)) & COMMA 'EmployeeID, varchar[20], NOT NULL
                sSQL &= SQLString(tdbg(i, COL_SubDepartmentID)) & COMMA 'SubDepartmentID, varchar[20], NOT NULL
                sSQL &= SQLString(tdbg(i, COL_SubTeamID)) & COMMA 'SubTeamID, varchar[20], NOT NULL
                sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
                sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
                sSQL &= SQLString(tdbg(i, COL_TaxObjectID)) & COMMA 'TaxObjectID, varchar[20], NOT NULL
                sSQL &= SQLDateSave(tdbg(i, COL_ValidDateFrom)) & COMMA 'ValidDateFrom, datetime, NOT NULL
                sSQL &= SQLDateSave(tdbg(i, COL_ValidDateTo)) & COMMA 'ValidDateTo, datetime, NOT NULL
                sSQL &= SQLString(tdbg(i, COL_SubDutyID)) & COMMA 'SubDutyID, varchar[20], NOT NULL
                sSQL &= SQLString(tdbg(i, COL_RefNo)) & COMMA 'RefNo, varchar[50], NOT NULL
                'Update 26/12/2011: Thêm 2 trường UserID, HostID
                sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
                sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
                sSQL &= SQLString(tdbg(i, COL_SubEmpGroupID)) & COMMA 'EmpGroupID, varchar[20], NOT NULL
                sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
                sSQL &= SQLString("") & COMMA 'TranTypeID, varchar[20], NOT NULL
                sSQL &= SQLString("") & COMMA 'FormID, varchar[50], NOT NULL
                sSQL &= SQLString(tdbg(i, COL_SubProjectID)) 'ProjectID, varchar[50], NOT NULL
                sRet &= sSQL & vbCrLf
            End If
        Next
        Return sRet
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()
        If Not AllowSave() Then Exit Sub
        'If Not CheckOpenSubPayroll() Then Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        'sSQL.Append(SQLInsertD13T0101s.ToString)
        sSQL.Append(SQLStoreD13P2013s)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True  ' bFlagSavedOK = True

            'Lưu lại vết Audit
            For i As Integer = 0 To tdbg.RowCount - 1
                If CBool(tdbg(i, COL_IsUsed).ToString) Then
                    Lemon3.D91.RunAuditLog("13", "MonthlySalaryFile", "01", tdbg(i, COL_PayrollVoucherNo).ToString, tdbg(i, COL_EmployeeID).ToString, "", "", "")
                    'ExecuteSQLNoTransaction(SQLStoreD91P9106("MonthlySalaryFile", "13", "01", tdbg(i, COL_PayrollVoucherNo).ToString, tdbg(i, COL_EmployeeID).ToString, "", "", ""))
                End If
            Next


            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
            Me.Close()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean

        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed).ToString) Then
                If tdbg(i, COL_SubDepartmentID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Phong_ban"))
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_SubDepartmentID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If tdbg(i, COL_TaxObjectID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Doi_tuong_thue"))
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_TaxObjectID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                'If tdbg(i, COL_PayrollVoucherNo).ToString = "" Then
                '    D99C0008.MsgNotYetEnter(rl3("HSL_thang"))
                '    tdbg.SplitIndex = SPLIT1
                '    tdbg.Col = COL_PayrollVoucherNo
                '    tdbg.Bookmark = i
                '    tdbg.Focus()
                '    Return False
                'End If

                If tdbg(i, COL_ValidDateFrom).ToString.Trim = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Ngay_cham_cong") & " (" & rl3("Tu") & ")")
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_ValidDateFrom
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If

                If tdbg(i, COL_ValidDateTo).ToString.Trim = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Ngay_cham_cong") & " (" & rl3("Den") & ")")
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_ValidDateTo
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If

                If tdbg(i, COL_ValidDateFrom).ToString.Trim <> "" And tdbg(i, COL_ValidDateTo).ToString.Trim <> "" Then
                    If CDate(tdbg(i, COL_ValidDateFrom)) > CDate(tdbg(i, COL_ValidDateTo)) Then
                        D99C0008.MsgL3(rl3("Gia_tri_Tu_ngay_khong_duoc_lon_hon_gia_tri_Den_ngay"))
                        tdbg.SplitIndex = SPLIT1
                        tdbg.Col = COL_ValidDateFrom
                        tdbg.Bookmark = i
                        tdbg.Focus()
                        Return False
                    End If
                End If

                If tdbg(i, COL_RefNo).ToString.Trim <> "" Then
                    If ExistRecord("SELECT TOP 1 1 FROM D13T0101  WITH (NOLOCK) WHERE RefNo = " & SQLString(tdbg(i, COL_RefNo).ToString)) Then
                        D99C0008.MsgL3(rl3("So_tham_chieu_nay_da_ton_tai") & " " & rl3("Ban_khong_duoc_phep_luu"))
                        tdbg.SplitIndex = SPLIT1
                        tdbg.Col = COL_RefNo
                        tdbg.Bookmark = i
                        tdbg.Focus()
                        Return False
                    End If
                    'Else
                    '    If Not CheckStore(SQLStoreD13P5555(tdbg(i, COL_TransID).ToString, tdbg(i, COL_ValidDateFrom).ToString, tdbg(i, COL_ValidDateTo).ToString)) Then
                    '        tdbg.SplitIndex = SPLIT1
                    '        tdbg.Col = COL_ValidDateFrom
                    '        tdbg.Bookmark = i
                    '        tdbg.Focus()
                    '        Return False
                    '    End If
                End If

                Dim sStatus As String = "0"
                If Not CheckStoreD13P5555(SQLStoreD13P5555(tdbg(i, COL_TransID).ToString, tdbg(i, COL_ValidDateFrom).ToString, tdbg(i, COL_ValidDateTo).ToString), , sStatus) Then
                    tdbg.SplitIndex = SPLIT1
                    If sStatus = "1" Then
                        tdbg.Col = COL_ValidDateFrom
                    Else
                        tdbg.Col = COL_ValidDateTo
                    End If
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If

            End If
        Next

        Dim bIsChoose As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed).ToString) Then
                bIsChoose = True
                Exit For
            End If
        Next
        If bIsChoose = False Then
            D99C0008.MsgL3(rl3("MSG000010"))
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_IsUsed
            tdbg.Bookmark = 0
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function CheckOpenSubPayroll() As Boolean
        Dim sEmployeeID As String = ""
        Dim iFocus As Integer = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed).ToString) Then
                If ExistOpenSubPayroll(tdbg(i, COL_EmployeeID).ToString, tdbg(i, COL_SubDepartmentID).ToString, tdbg(i, COL_SubTeamID).ToString, tdbg(i, COL_PayrollVoucherID).ToString) Then
                    If sEmployeeID = "" Then
                        sEmployeeID = tdbg(i, COL_EmployeeID).ToString
                        iFocus = i
                    Else
                        sEmployeeID = sEmployeeID & "; " & tdbg(i, COL_EmployeeID).ToString
                    End If
                End If
            End If
        Next

        If sEmployeeID <> "" Then
            D99C0008.MsgL3(rl3("Nhan_vien") & ": " & sEmployeeID & " " & rl3("dang_lam_viec_trong_phong_ban_to_nhom_da_chon") & " " & rl3("Vui_long_chon_lai_thong_tin_mo_HSL_phu"))
            tdbg.SplitIndex = SPLIT1
            tdbg.Col = COL_SubDepartmentID
            tdbg.Bookmark = iFocus
            tdbg.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function ExistOpenSubPayroll(ByVal sEmployeeID As String, ByVal sSubDepartmentID As String, ByVal sSubTeamID As String, ByVal sPayrollVoucherID As String) As Boolean
        Dim sSQL As String = ""
        sSQL = "SELECT TOP 1 1 " & vbCrLf
        sSQL &= "FROM D13T0101 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE EmployeeID = " & SQLString(sEmployeeID) & vbCrLf
        sSQL &= "AND DepartmentID = " & SQLString(sSubDepartmentID) & vbCrLf
        sSQL &= "AND Isnull(TeamID,'') = " & SQLString(sSubTeamID) & vbCrLf
        sSQL &= "AND PayrollVoucherID = " & SQLString(sPayrollVoucherID)
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        Return dt.Rows.Count > 0
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case e.ColIndex
            Case COL_SubDepartmentID, COL_SubTeamID, COL_SubEmpGroupID
                If _parentFormID <> "D13F2012" Then
                    e.Cancel = True
                    Exit Sub
                End If
                If Not CBool(tdbg.Columns(COL_IsUsed).Text) Then
                    e.Cancel = True
                    Exit Sub
                End If
                Select Case e.ColIndex
                    Case COL_SubDepartmentID
                        LoadTdbdDepartmentID()
                    Case COL_SubTeamID
                        LoadTDBDTeamID()
                    Case COL_SubEmpGroupID
                        LoadTDBDSubEmpGroupID()
                End Select

            Case COL_TaxObjectID
                If Not CBool(tdbg.Columns(COL_IsUsed).Text) Then e.Cancel = True

            Case COL_PayrollVoucherNo
                If _parentFormID = "D13F2012" Then
                    e.Cancel = True
                    Exit Sub
                End If

                If Not CBool(tdbg.Columns(COL_IsUsed).Text) Then
                    e.Cancel = True
                    Exit Sub
                End If

                Dim dt As DataTable = ReturnTableFilter(dtPayroll, "DivisionID = " & SQLString(tdbg.Columns(COL_SubDivisionID).Text))
                LoadDataSource(tdbdPayrollVoucherID, dt, gbUnicode)
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_SubDepartmentID
                If tdbg.Columns(COL_SubDepartmentID).Text <> tdbdDepartmentID.Columns("DepartmentID").Text Then
                    tdbg.Columns(COL_SubDepartmentID).Text = ""
                End If
            Case COL_SubTeamID
                If tdbg.Columns(COL_SubTeamID).Text <> tdbdTeamID.Columns("TeamID").Text Then
                    tdbg.Columns(COL_SubTeamID).Text = ""
                End If

            Case COL_SubEmpGroupID
                If tdbg.Columns(COL_SubEmpGroupID).Text <> tdbdSubEmpGroupID.Columns(tdbdSubEmpGroupID.DisplayMember).Text Then
                    tdbg.Columns(COL_SubEmpGroupID).Text = ""
                End If

            Case COL_TaxObjectID
                If tdbg.Columns(COL_TaxObjectID).Text <> tdbdTaxObjectID.Columns("TaxObjectID").Text Then
                    tdbg.Columns(COL_TaxObjectID).Text = ""
                End If
            Case COL_PayrollVoucherNo
                If tdbg.Columns(COL_PayrollVoucherNo).Text <> tdbdPayrollVoucherID.Columns("PayrollVoucherNo").Text Then
                    tdbg.Columns(COL_PayrollVoucherNo).Text = ""
                    tdbg.Columns(COL_PayrollVoucherID).Text = ""
                End If
            Case COL_SubDutyID
                'e.Cancel = L3IsID(tdbg, e.ColIndex)
                'bCancel = e.Cancel
            Case COL_SubProjectID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If

            Case COL_RefNo
                e.Cancel = L3IsID(tdbg, e.ColIndex)
                bCancel = e.Cancel
        End Select
    End Sub

    Private Function L3IsID(ByRef tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As Integer) As Boolean
        'If CheckContinue(tdbg) = False Then Return False
        Dim bCancel As Boolean = IndexIdCharactor(tdbg.Columns(iCol).Text) >= 0
        If bCancel Then D99C0008.MsgL3(rl3("Ma_co_ky_tu_khong_hop_le"))
        Return bCancel
    End Function
    Private Function IndexIdCharactor(ByVal str As String) As Integer
        '  If str.Length > iLength Then Return -2 'vượt chiều dài
        'BackSpace: 8
        For Each c As Char In str
            Select Case AscW(c)
                Case 13, 10 'Mutiline của textbox và phím Enter
                    Continue For
                Case Is < 33, Is > 127, 37, 39, 91, 93, 94 'Các ký tự đặc biệt: 37(%) 39(') 91([) 93(]) 94(^)
                    Return str.IndexOf(c)
            End Select
        Next
        Return -1
    End Function

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_SubDepartmentID
                tdbg.Columns(COL_SubDepartmentID).Text = tdbdDepartmentID.Columns("DepartmentID").Text
                tdbg.Columns(COL_SubTeamID).Text = ""
                tdbg.Columns(COL_SubEmpGroupID).Text = ""
            Case COL_SubTeamID
                tdbg.Columns(COL_SubTeamID).Text = tdbdTeamID.Columns("TeamID").Text
                tdbg.Columns(COL_SubEmpGroupID).Text = ""
            Case COL_TaxObjectID
                tdbg.Columns(COL_TaxObjectID).Text = tdbdTaxObjectID.Columns("TaxObjectID").Text
            Case COL_PayrollVoucherNo
                tdbg.Columns(COL_PayrollVoucherNo).Text = tdbdPayrollVoucherID.Columns("PayrollVoucherNo").Text
                tdbg.Columns(COL_PayrollVoucherID).Text = tdbdPayrollVoucherID.Columns("PayrollVoucherID").Text
        End Select
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case tdbg.Col
            Case COL_RefNo
                tdbg.TabAcrossSplits = False
            Case Else
                tdbg.TabAcrossSplits = True
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
        End If
        Select Case tdbg.Col
            Case COL_RefNo
                tdbg.TabAcrossSplits = False
            Case Else
                tdbg.TabAcrossSplits = True
        End Select
        Select Case tdbg.Col
            Case COL_ValidDateFrom, COL_ValidDateTo
                If e.Control = True And e.KeyCode = Keys.V Then
                    e.Handled = True
                    e.SuppressKeyPress = True
                    tdbg.Columns(tdbg.Col).Text = Clipboard.GetText()
                    tdbg.UpdateData()
                End If
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_SubProjectID
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_ProjectID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_ProjectID).Text = tdbdProjectID.Columns("ProjectID").Text
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_RefNo, COL_SubDutyID
                e.KeyChar = CType(e.KeyChar.ToString.ToUpper, Char)
        End Select
    End Sub

    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_IsUsed
                Dim bVal As Boolean = False
                bVal = Not Convert.ToBoolean(tdbg(0, COL_IsUsed))
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, COL_IsUsed) = bVal
                Next
            Case COL_SubTeamID, COL_SubDepartmentID, COL_SubEmpGroupID
                If _parentFormID = "D13F2012" Then
                    CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
                End If
            Case COL_PayrollVoucherNo
                If _parentFormID <> "D13F2012" Then
                    CopyColumns(tdbg, iCol, tdbg.Row, 1, tdbg.Columns(iCol).Text)
                End If
            Case COL_TaxObjectID, COL_SubDutyID, COL_ValidDateFrom, COL_ValidDateTo
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2010
    '# Created User: DUCTRONG
    '# Created Date: 25/02/2009 01:58:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2010 "
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(IIf(_parentFormID = "D13F2012", _payrollVoucherID, _tranTypeID).ToString) & COMMA 'Mode, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA
        sSQL &= SQLNumber(giTranYear) & COMMA
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2014
    '# Created User: DUCTRONG
    '# Created Date: 25/02/2009 04:23:38
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2014(ByVal sTransID As String, ByVal sEmployeeID As String, ByVal sPayrollVoucherID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2014 "
        sSQL &= SQLString(sTransID) & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLString(sEmployeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(sPayrollVoucherID) 'PayrollVoucherID, varchar[20], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0101s
    '# Created User: DUCTRONG
    '# Created Date: 25/02/2009 04:16:12
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0101s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sTransID As String = ""
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed).ToString) Then

                sTransID = CreateIGE("D13T0101", "TransID", "13", "DP", gsStringKey)

                sSQL.Append("Insert Into D13T0101(")
                sSQL.Append("TransID, DivisionID, PayrollVoucherID, EmployeeID, DepartmentID, TeamID, " & vbCrLf)
                sSQL.Append("TranMonth, TranYear, IsSub, TaxObjectID, " & vbCrLf)
                sSQL.Append("N01ID, N02ID, N03ID, N04ID, N05ID, N06ID, N07ID, N08ID, N09ID, N10ID, " & vbCrLf)
                sSQL.Append("N11ID, N12ID, N13ID, N14ID, N15ID, N16ID, N17ID, N18ID, N19ID, N20ID" & vbCrLf)
                sSQL.Append(") ")
                sSQL.Append("Select ")
                sSQL.Append(SQLString(sTransID) & COMMA) 'TransID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_PayrollVoucherID).ToString) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_EmployeeID).ToString) & COMMA) 'EmployeeID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_SubDepartmentID).ToString) & COMMA) 'DepartmentID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_SubTeamID).ToString) & COMMA & vbCrLf) 'TeamID, varchar[20], NOT NULL
                sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
                sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
                sSQL.Append(SQLNumber(1) & COMMA) 'IsSub, tinyint, NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_TaxObjectID).ToString) & COMMA & vbCrLf) 'TaxObjectID, varchar[20], NULL
                sSQL.Append("T1.N01ID, T1.N02ID, T1.N03ID, T1.N04ID, T1.N05ID, T1.N06ID, T1.N07ID, T1.N08ID, T1.N09ID, T1.N10ID, " & vbCrLf)
                sSQL.Append("T1.N11ID, T1.N12ID, T1.N13ID, T1.N14ID, T1.N15ID, T1.N16ID, T1.N17ID, T1.N18ID, T1.N19ID, T1.N20ID " & vbCrLf)
                sSQL.Append("FROM D09T0200 T1 WHERE T1.EmployeeID = " & SQLString(tdbg(i, COL_EmployeeID)) & vbCrLf)

                sSQL.Append(SQLStoreD13P2014(sTransID, tdbg(i, COL_EmployeeID).ToString, tdbg(i, COL_PayrollVoucherID).ToString).ToString)

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 20/01/2011 11:54:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(ByVal sTransID As String, ByVal sValidDateFrom As String, ByVal sValidDateTo As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(sTransID) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(sValidDateFrom) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(sValidDateTo) 'DateTo, datetime, NOT NULL
        Return sSQL
    End Function

    Private Function CheckStoreD13P5555(ByVal SQL As String, Optional ByVal bMsgAsk As Boolean = False, Optional ByRef Status As String = "0") As Boolean
        'Update 11/10/2010: sửa lại hàm checkstore có trả ra field FontMessage
        'Cách kiểm tra của hàm CheckStore này sẽ như sau:
        'Nếu store trả ra Status <> 0 thì xuất Message theo dạng FontMessage
        'Nếu đối số thứ 2 không truyền vào có nghĩa là False thì xuất Message chỉ có 1 nút Ok
        'Nếu đối số thứ 2 có truyền vào có nghĩa là True thì xuất Message có 2 nút Yes, No

        Dim dt As New DataTable
        Dim sMsg As String
        dt = ReturnDataTable(SQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString = "0" Then
                dt = Nothing
                Return True
            Else
                Status = dt.Rows(0).Item("Status").ToString
            End If

            sMsg = dt.Rows(0).Item("Message").ToString
            Dim bFontMessage As Boolean = False
            If dt.Columns.Contains("FontMessage") Then bFontMessage = True

            If Not bMsgAsk Then 'OKOnly
                If Not bFontMessage Then
                    D99C0008.MsgL3(ConvertVietwareFToUnicode(sMsg))
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            D99C0008.MsgL3(ConvertVietwareFToUnicode(sMsg))
                        Case "1" 'Unicode
                            D99C0008.MsgL3(sMsg, L3MessageBoxIcon.Exclamation)
                        Case "2" 'Convert Vni To Unicode
                            D99C0008.MsgL3(ConvertVniToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
                    End Select
                End If
                dt = Nothing
                Return False
            Else 'YesNo
                If Not bFontMessage Then
                    If D99C0008.MsgAsk(ConvertVietwareFToUnicode(sMsg)) = Windows.Forms.DialogResult.Yes Then
                        dt = Nothing
                        Return True
                    Else
                        dt = Nothing
                        Return False
                    End If
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            If D99C0008.MsgAsk(ConvertVietwareFToUnicode(sMsg)) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "1" 'Unicode
                            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "2" 'Convert Vni To Unicode
                            If D99C0008.MsgAsk(ConvertVniToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                    End Select
                End If
                End If
            dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return False
        End If
        Return True
    End Function

End Class