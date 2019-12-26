'#-------------------------------------------------------------------------------------
'# Created Date: 10/05/2007 2:57:34 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 28/05/2010 -- ID33138 ->Tìm kiếm kiểu mới_ko đổ store khi tìm kiếm
'# Modify User: Thanh Huyền
'#-------------------------------------------------------------------------------------
Imports System.Text
Imports System

Public Class D45F2062
    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable
    Dim COL_Total As Integer = 0
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

#Region "Const of tdbg - Total of Columns: 46"
    Private Const COL_TransID As String = "TransID"                   ' TransID
    Private Const COL_EmployeeID As String = "EmployeeID"             ' Mã NV
    Private Const COL_FullName As String = "FullName"                 ' Họ và tên
    Private Const COL_BlockID As String = "BlockID"                   ' Khối
    Private Const COL_BlockName As String = "BlockName"               ' Tên khối
    Private Const COL_DepartmentID As String = "DepartmentID"         ' Phòng ban
    Private Const COL_DepartmentName As String = "DepartmentName"     ' Tên phòng ban
    Private Const COL_TeamID As String = "TeamID"                     ' Tổ nhóm 
    Private Const COL_TeamName As String = "TeamName"                 ' Tên tổ nhóm
    Private Const COL_EmpGroupID As String = "EmpGroupID"             ' Nhóm NV
    Private Const COL_EmpGroupName As String = "EmpGroupName"         ' Tên nhóm NV
    Private Const COL_DutyID As String = "DutyID"                     ' Chức vụ
    Private Const COL_DutyName As String = "DutyName"                 ' Tên chức vụ
    Private Const COL_WorkID As String = "WorkID"                     ' Công việc
    Private Const COL_WorkName As String = "WorkName"                 ' Tên công việc
    Private Const COL_BirthDate As String = "BirthDate"               ' Ngày sinh
    Private Const COL_SexName As String = "SexName"                   ' Giới tính
    Private Const COL_DateJoined As String = "DateJoined"             ' Ngày vào làm
    Private Const COL_DateLeft As String = "DateLeft"                 ' Ngày nghỉ việc
    Private Const COL_Age As String = "Age"                           ' Tuổi
    Private Const COL_StatusID As String = "StatusID"                 ' Trạng thái làm việc
    Private Const COL_StatusName As String = "StatusName"             ' Tên trạng thái làm việc
    Private Const COL_AttendanceCardNo As String = "AttendanceCardNo" ' Mã thẻ chấm công
    Private Const COL_RefEmployeeID As String = "RefEmployeeID"       ' Mã NV phụ
    Private Const COL_BASE01 As String = "BASE01"                     ' BASE01
    Private Const COL_BASE02 As String = "BASE02"                     ' BASE02
    Private Const COL_BASE03 As String = "BASE03"                     ' BASE03
    Private Const COL_BASE04 As String = "BASE04"                     ' BASE04
    Private Const COL_CE01 As String = "CE01"                         ' CE01
    Private Const COL_CE02 As String = "CE02"                         ' CE02
    Private Const COL_CE03 As String = "CE03"                         ' CE03
    Private Const COL_CE04 As String = "CE04"                         ' CE04
    Private Const COL_CE05 As String = "CE05"                         ' CE05
    Private Const COL_CE06 As String = "CE06"                         ' CE06
    Private Const COL_CE07 As String = "CE07"                         ' CE07
    Private Const COL_CE08 As String = "CE08"                         ' CE08
    Private Const COL_CE09 As String = "CE09"                         ' CE09
    Private Const COL_CE10 As String = "CE10"                         ' CE10
    Private Const COL_AbsentTypeFrom As String = "AbsentTypeFrom"     ' AbsentTypeFrom
    Private Const COL_AbsentTypeTo As String = "AbsentTypeTo"         ' AbsentTypeTo
    Private Const COL_IsSub As String = "IsSub"                       ' HSL phụ
    Private Const COL_ValidDateFrom As String = "ValidDateFrom"       ' Ngày chấm công (Từ)
    Private Const COL_ValidDateTo As String = "ValidDateTo"           ' Ngày chấm công (Đến)
    Private Const COL_SalEmpGroupName As String = "SalEmpGroupName"   ' Nhóm lương
    Private Const COL_Note As String = "Note"                         ' Ghi chú
    Private Const COL_IsUpdate As String = "IsUpdate"                 ' IsUpdate
#End Region

    Private bBA As SALBA
    Private bCE As SALCE

    Dim dtTeamID, dtDepartmentID, dtGrid As DataTable

#Region "Properties"
    Private _absentVoucherID As String = ""
    Public WriteOnly Property AbsentVoucherID As String
        Set(ByVal Value As String)
            _absentVoucherID = Value
        End Set
    End Property

    Private _blockID As String = "%"
    Public WriteOnly Property BlockID As String
        Set(ByVal Value As String)
            _blockID = Value
        End Set
    End Property

    Private _departmentID As String = "%"
    Public WriteOnly Property DepartmentID As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String = "%"
    Public WriteOnly Property TeamID As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _remark As String = ""
    Public WriteOnly Property Remark As String
        Set(ByVal Value As String)
            _remark = Value
        End Set
    End Property
    

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnSave.Enabled = True
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property
#End Region
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D45F2062_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D13F2022_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
        End If

        Select Case e.KeyCode
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub D13F2022_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        COL_Total = tdbg.Columns.Count
        gbEnabledUseFind = False
        LoadTDBCombo()
        '********************
        If D45Systems.IsUseBlock Then ReadOnlyControl(tdbcBlockID)
        tdbg.Splits(0).DisplayColumns(COL_BlockID).Visible = D45Systems.IsUseBlock
        tdbg.Splits(0).DisplayColumns(COL_BlockName).Visible = D45Systems.IsUseBlock
        If _blockID <> "%" Then
            tdbcBlockID.SelectedValue = _blockID
            ReadOnlyControl(tdbcBlockID)
        End If
        If _DepartmentID <> "%" Then
            tdbcDepartmentID.SelectedValue = _DepartmentID
            ReadOnlyControl(tdbcDepartmentID)
        End If
        If _TeamID <> "%" Then
            tdbcTeamID.SelectedValue = _TeamID
            ReadOnlyControl(tdbcTeamID)
        End If
        txtRemark.Text = _Remark
        btnSave.Enabled = (ReturnPermission("D45F2060") >= 2) And _FormState <> EnumFormState.FormView
        '********************
        LoadLanguage()
        SetBackColorObligatory()
        tdbg_NumberFormat()
        tdbg_LockedColumns()
        SQLD13T9000()
        ShowColumns()
        LoadTableCaption(tdbg)
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        ResetSplitDividerSize(tdbg)
        btnFilter_Click(Nothing, Nothing)
        InputDateInTrueDBGrid(tdbg, COL_DateJoined, COL_DateLeft, COL_AbsentTypeTo, COL_ValidDateFrom, COL_ValidDateTo)
        InputbyUnicode(Me, gbUnicode)
        CallD99U1111()
        SetShortcutPopupMenu(ContextMenuStrip1)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_FullName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmpGroupID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmpGroupName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_WorkID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_WorkName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BirthDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_SexName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DateJoined).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DateLeft).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Age).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StatusID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StatusName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_AttendanceCardNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_RefEmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BASE01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BASE02).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BASE03).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BASE04).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE02).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE03).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE04).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE05).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE06).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE07).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE08).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE09).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CE10).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_IsSub).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ValidDateFrom).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ValidDateTo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_SalEmpGroupName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_BASE01).NumberFormat = Format(tdbg.Columns(COL_BASE01).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_BASE02).NumberFormat = Format(tdbg.Columns(COL_BASE02).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_BASE03).NumberFormat = Format(tdbg.Columns(COL_BASE03).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_BASE04).NumberFormat = Format(tdbg.Columns(COL_BASE04).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_CE01).NumberFormat = Format(tdbg.Columns(COL_CE01).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_CE02).NumberFormat = Format(tdbg.Columns(COL_CE02).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_CE03).NumberFormat = Format(tdbg.Columns(COL_CE03).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_CE04).NumberFormat = Format(tdbg.Columns(COL_CE04).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_CE05).NumberFormat = Format(tdbg.Columns(COL_CE05).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_CE06).NumberFormat = Format(tdbg.Columns(COL_CE06).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_CE07).NumberFormat = Format(tdbg.Columns(COL_CE07).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_CE08).NumberFormat = Format(tdbg.Columns(COL_CE08).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_CE09).NumberFormat = Format(tdbg.Columns(COL_CE09).Text, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_CE10).NumberFormat = Format(tdbg.Columns(COL_CE10).Text, DxxFormat.DefaultNumber2)
    End Sub
    Private Sub SetBackColorObligatory()
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBCombo()
        dtTeamID = ReturnTableTeamID_D09P6868(gsDivisionID, "D45F2060", 0)
        dtDepartmentID = ReturnTableDepartmentID_D09P6868(gsDivisionID, "D45F2060", 0)

        'Load tdbcBlockID
        LoadtdbcBlockID_D09P6868(tdbcBlockID, gsDivisionID, "D45F2060", 0)
        tdbcBlockID.SelectedValue = "%"
    End Sub

#Region "Events tdbcBlockID with txtBlockName load tdbcDepartmentID with txtDepartmentName"
    Private Sub tdbcBlockID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
        End If
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        If Not (tdbcBlockID.Tag Is Nothing OrElse tdbcBlockID.Tag.ToString = "") Then
            tdbcBlockID.Tag = ""
            Exit Sub
        End If

        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ReturnValueC1Combo(tdbcBlockID), gsDivisionID, gbUnicode)
        tdbcDepartmentID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcDepartmentID with txtDepartmentName"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not tdbcDepartmentID.SelectedValue Is Nothing AndAlso Not tdbcBlockID.SelectedValue Is Nothing Then
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, tdbcBlockID.SelectedValue.ToString, tdbcDepartmentID.SelectedValue.ToString, gsDivisionID, gbUnicode)
        Else
            LoadtdbcTeamID(tdbcTeamID, dtTeamID, "-1", "-1", "-1", gbUnicode)
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcTeamID with txtTeamName"
    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
        End If
    End Sub
#End Region
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub
    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcBlockID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
    Private Sub SQLD13T9000()
        Dim sSQL As String = "Select Code, Short" & UnicodeJoin(gbUnicode) & " as Short, Disabled, Type From D13T9000  WITH (NOLOCK) Order By Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)

        Dim dt1 As DataTable = ReturnTableFilter(dt, "Type='SALBA'")
        bBA.BASE01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bBA.BASE02 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bBA.BASE03 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bBA.BASE04 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))

        tdbg.Columns(COL_BASE01).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_BASE02).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_BASE03).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_BASE04).Caption = dt1.Rows(3).Item("Short").ToString

        For i As Integer = IndexOfColumn(tdbg, COL_BASE01) To IndexOfColumn(tdbg, COL_BASE04)
            tdbg.Splits(0).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
            tdbg.Splits(0).DisplayColumns(i).Style.Font = FontUnicode(gbUnicode)
        Next

        dt1 = ReturnTableFilter(dt, "Type='SALCE'")
        bCE.CE01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bCE.CE02 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bCE.CE03 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bCE.CE04 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))
        bCE.CE05 = CBool(IIf(dt1.Rows(4).Item("Disabled").ToString = "0", True, False))
        bCE.CE06 = CBool(IIf(dt1.Rows(5).Item("Disabled").ToString = "0", True, False))
        bCE.CE07 = CBool(IIf(dt1.Rows(6).Item("Disabled").ToString = "0", True, False))
        bCE.CE08 = CBool(IIf(dt1.Rows(7).Item("Disabled").ToString = "0", True, False))
        bCE.CE09 = CBool(IIf(dt1.Rows(8).Item("Disabled").ToString = "0", True, False))
        bCE.CE10 = CBool(IIf(dt1.Rows(9).Item("Disabled").ToString = "0", True, False))

        tdbg.Columns(COL_CE01).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_CE02).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_CE03).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_CE04).Caption = dt1.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_CE05).Caption = dt1.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_CE06).Caption = dt1.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_CE07).Caption = dt1.Rows(6).Item("Short").ToString
        tdbg.Columns(COL_CE08).Caption = dt1.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_CE09).Caption = dt1.Rows(8).Item("Short").ToString
        tdbg.Columns(COL_CE10).Caption = dt1.Rows(9).Item("Short").ToString

        For i As Integer = IndexOfColumn(tdbg, COL_CE01) To IndexOfColumn(tdbg, COL_CE10)
            tdbg.Splits(0).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
            tdbg.Splits(0).DisplayColumns(i).Style.Font = FontUnicode(gbUnicode)
        Next
    End Sub

    Private Sub ShowColumns()
        tdbg.Splits(0).DisplayColumns(COL_BASE01).Visible = bBA.BASE01
        tdbg.Splits(0).DisplayColumns(COL_BASE02).Visible = bBA.BASE02
        tdbg.Splits(0).DisplayColumns(COL_BASE03).Visible = bBA.BASE03
        tdbg.Splits(0).DisplayColumns(COL_BASE04).Visible = bBA.BASE04
        tdbg.Splits(0).DisplayColumns(COL_CE01).Visible = bCE.CE01
        tdbg.Splits(0).DisplayColumns(COL_CE02).Visible = bCE.CE02
        tdbg.Splits(0).DisplayColumns(COL_CE03).Visible = bCE.CE03
        tdbg.Splits(0).DisplayColumns(COL_CE04).Visible = bCE.CE04
        tdbg.Splits(0).DisplayColumns(COL_CE05).Visible = bCE.CE05
        tdbg.Splits(0).DisplayColumns(COL_CE06).Visible = bCE.CE06
        tdbg.Splits(0).DisplayColumns(COL_CE07).Visible = bCE.CE07
        tdbg.Splits(0).DisplayColumns(COL_CE08).Visible = bCE.CE08
        tdbg.Splits(0).DisplayColumns(COL_CE09).Visible = bCE.CE09
        tdbg.Splits(0).DisplayColumns(COL_CE10).Visible = bCE.CE10
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Nhap_phieu_dieu_chinh_thu_nhap") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'NhËp phiÕu ¢iÒu chÙnh thu nhËp
        '================================================================ 
        lblDepartmentID.Text = rL3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rL3("To_nhom") 'Tổ nhóm
        lblBlockID.Text = rL3("Khoi") 'Khối
        lblRemark.Text = rL3("Dien_giai") 'Diễn giải
        '================================================================ 
        btnFilter.Text = rL3("Loc") & " (F5)" 'Lọc
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnF12.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị
        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_EmployeeID).Caption = rL3("Ma_NV") 'Mã NV
        tdbg.Columns(COL_FullName).Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(COL_BlockID).Caption = rL3("Khoi") 'Khối
        tdbg.Columns(COL_BlockName).Caption = rL3("Ten_khoi") 'Tên khối
        tdbg.Columns(COL_DepartmentID).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rL3("To_nhom") 'Tổ nhóm 
        tdbg.Columns(COL_TeamName).Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_EmpGroupID).Caption = rL3("Nhom_NV") 'Nhóm NV
        tdbg.Columns(COL_EmpGroupName).Caption = rL3("Ten_nhom_NV") 'Tên nhóm NV
        tdbg.Columns(COL_DutyID).Caption = rL3("Chuc_vu") 'Chức vụ
        tdbg.Columns(COL_DutyName).Caption = rL3("Ten_chuc_vu") 'Tên chức vụ
        tdbg.Columns(COL_WorkID).Caption = rL3("Cong_viec") 'Công việc
        tdbg.Columns(COL_WorkName).Caption = rL3("Ten_cong_viec") 'Tên công việc
        tdbg.Columns(COL_BirthDate).Caption = rL3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns(COL_SexName).Caption = rL3("Gioi_tinh") 'Giới tính
        tdbg.Columns(COL_DateJoined).Caption = rL3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns(COL_DateLeft).Caption = rL3("Ngay_nghi_viec") 'Ngày nghỉ việc
        tdbg.Columns(COL_Age).Caption = rL3("Tuoi") 'Tuổi
        tdbg.Columns(COL_StatusID).Caption = rL3("Trang_thai_lam_viec") 'Trạng thái làm việc
        tdbg.Columns(COL_StatusName).Caption = rL3("Ten_trang_thai_lam_viec") 'Tên trạng thái làm việc
        tdbg.Columns(COL_AttendanceCardNo).Caption = rL3("Ma_the_cham_cong") 'Mã thẻ chấm công
        tdbg.Columns(COL_RefEmployeeID).Caption = rL3("Ma_NV_phu") 'Mã NV phụ
        tdbg.Columns(COL_IsSub).Caption = rL3("HSL_phu") 'HSL phụ
        tdbg.Columns(COL_ValidDateFrom).Caption = rL3("Ngay_cham_cong_(Tu)") 'Ngày chấm công (Từ)
        tdbg.Columns(COL_ValidDateTo).Caption = rL3("Ngay_cham_cong_(Den)") 'Ngày chấm công (Đến)
        tdbg.Columns(COL_SalEmpGroupName).Caption = rL3("Nhom_luong") 'Nhóm lương
        tdbg.Columns(COL_Note).Caption = rL3("Ghi_chu") 'Ghi chú
    End Sub

    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        tdbg.UpdateData()
        dtGrid.AcceptChanges()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
       
        dr = dtGrid.Select(COL_IsUpdate & " = 1")
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim dr() As DataRow = Nothing
        If Not AllowSave(dr) Then Exit Sub

        'Dim sSQL() As New StringBuilder("")
        Dim sSQL() As StringBuilder = Nothing

        btnSave.Enabled = False
        btnClose.Enabled = False
        If dr.Length > 0 Then
            'sRetSQLInsertD45T2064 = New StringBuilder()
            'sSQL.Append(SQLInsertD45T2063s(dr).ToString() & vbCrLf)
            'sSQL.Append(sRetSQLInsertD45T2064.ToString() & vbCrLf)
            'If sSQL.ToString <> "" Then
            '    If Not ExecuteSQL(sSQL.ToString) Then GoTo ErrorSQL
            'End If

            sSQL = SQLInsertD45T2063s(dr) 'Tạo mảng SQL
            Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
            If bRunSQL Then
                'btnFilter_Click(Nothing, Nothing)
                SaveOK()
                _bSaved = True
                btnSave.Enabled = True
                btnClose.Enabled = True
                btnClose.Focus()
            Else
ErrorSQL:
                SaveNotOK()
                btnSave.Enabled = True
                btnClose.Enabled = True
            End If
        Else
            'btnFilter_Click(Nothing, Nothing)
            SaveOK()
            _bSaved = True
            btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        End If
    End Sub

    Private Sub LoadTDBGrid()
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        sFind = ""
        '***********************
        Dim sSQL As String = SQLStoreD45P2064()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Dim sSumFooter As New List(Of String)
    Private Sub ResetGrid()
        mnsFind.Enabled = tdbg.RowCount > 0 AndAlso gbEnabledUseFind
        mnsListAll.Enabled = mnsFind.Enabled
        mnsExportToExcel.Enabled = tdbg.RowCount > 0
        '**************************
        FooterTotalGrid(tdbg, COL_EmployeeID)
        FooterSumNew(tdbg, sSumFooter.ToArray)
    End Sub
    Private Sub tsmExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsExportToExcel.Click
        If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
            Dim arrColObligatory() As Integer = {IndexOfColumn(tdbg, COL_EmployeeID)}
            Dim Arr As New ArrayList
            AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        End If
        'Form trong DLL
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
    End Sub

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Private sFind As String = ""
    Dim dtCaptionCols As DataTable
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Giống sự kiện Finder_FindClick
        End Set
    End Property
    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {IndexOfColumn(tdbg, COL_EmployeeID)}
            Dim Arr As New ArrayList
            For i As Integer = 0 To tdbg.Splits.Count - 1
                AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
            Next
            'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
            dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode) ' Dùng DLL 
    End Sub
    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub
#End Region

#Region "tdbg"
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If tdbg.FilterActive Then HotKeyCtrlVOnGrid(tdbg, e) : Exit Sub
        If e.Control AndAlso e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tdbg_HeadClick(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.Columns(COL_IsUpdate).Value = True
        tdbg.UpdateData()
        ResetGrid()
    End Sub
    Private Sub tdbg_FetchCellTips(sender As Object, e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        If e.Row >= 0 Then
            Select Case tdbg.Columns(e.ColIndex).DataField
                Case COL_DepartmentID
                    e.CellTip = tdbg.Columns(COL_DepartmentName).Text
                Case COL_TeamID
                    e.CellTip = tdbg.Columns(COL_TeamName).Text
                Case Else
                    e.CellTip = ""
            End Select
        Else
            e.CellTip = ""
        End If
    End Sub
#End Region

    Private Sub HeadClick(iCol As Integer)
        If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(iCol).Locked = False Then
            CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
            If iCol >= COL_Total Then ResetGrid()
        End If
    End Sub

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            'If sValue = "" Or c1Grid.RowCount < 2 Then Exit Sub
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 OrElse c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns(ColCopy).Locked Then Exit Sub

            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                        c1Grid(i, ColCopy) = sValue
                        c1Grid(i, COL_IsUpdate) = True
                    End If
                Next

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    c1Grid(i, ColCopy) = sValue
                    c1Grid(i, COL_IsUpdate) = True
                Next
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        btnFilter.Enabled = False
        LoadTDBGrid()
        btnFilter.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub
    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL_EmployeeID, COL_BlockID, COL_DepartmentID, COL_TeamID}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

#Region "Add cột động"
    Dim dtCol As New DataTable
    Dim arrCol() As FormatColumn = Nothing
    Private Sub LoadTableCaption(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        'Xóa các cột động cũ, phải để trước load dtCol
        If dtCol IsNot Nothing AndAlso dtCol.Rows.Count > 0 Then
            For i As Integer = 0 To dtCol.Rows.Count - 1
                c1Grid.Columns.RemoveAt(IndexOfColumn(c1Grid, dtCol.Rows(i).Item("FieldName").ToString))
            Next
        End If

        Dim sSQL As String = SQLStoreD45P2065()
        dtCol = ReturnDataTable(sSQL) 'Đổ nguồn table caption cột động
        If dtCol.Rows.Count > 0 Then
            If tdbg.Splits.Count > 2 Then tdbg.RemoveHorizontalSplit(1)
            tdbg.InsertHorizontalSplit(1)
            tdbg.Splits(1).RecordSelectors = False
            tdbg.Splits(0).SplitSize = 10
            tdbg.Splits(1).SplitSize = 8
            tdbg.Splits(2).SplitSize = 6
            For i As Integer = 0 To tdbg.Columns.Count - 1
                tdbg.Splits(1).DisplayColumns(i).Visible = False
            Next
        End If
        arrCol = Nothing
        '*********************
        'Add cột
        For i As Integer = 0 To dtCol.Rows.Count - 1
            AddColumns(c1Grid, i, dtCol)
        Next

        'Định dạng các cột số trên lưới
        If arrCol IsNot Nothing Then InputNumber(c1Grid, arrCol)
        tdbg.Refresh()
    End Sub

    Dim iIndexCol As Integer = 0
    Private Sub AddColumns(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal i As Integer, ByVal dtCol As DataTable, Optional ByVal bChangeDisplayColums As Boolean = False)
        Dim sField As String = dtCol.Rows(i).Item("FieldName").ToString
        Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn
        dc.Caption = dtCol.Rows(i).Item("Caption").ToString
        dc.DataField = sField
        If bChangeDisplayColums = False Then
            c1Grid.Columns.Add(dc)
        Else
            iIndexCol = L3Int(dtCol.Rows(i).Item("OrderNo")) 'Index insert do store trả ra
            c1Grid.Columns.Insert(iIndexCol, dc)
            '=============================================================================================
            For k As Integer = 0 To c1Grid.Splits.ColCount - 1
                Dim dispColumn As C1.Win.C1TrueDBGrid.C1DisplayColumn = c1Grid.Splits(k).DisplayColumns(dc.DataField)
                tdbg_ChangeDisplayColumns(c1Grid, dispColumn, iIndexCol, k)
            Next k
        End If
        SetFormatCol(c1Grid, sField, dtCol.Rows(i).Item("Decimals").ToString)
    End Sub
    Public Sub tdbg_ChangeDisplayColumns(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dispColumnOld As C1.Win.C1TrueDBGrid.C1DisplayColumn, ByVal posNew As Integer, Optional ByVal iSplit As Integer = 0)
        With c1Grid.Splits(iSplit)
            Dim iDisplay As Integer = .DisplayColumns.IndexOf(dispColumnOld.DataColumn)
            If iDisplay = -1 Then Exit Sub

            Dim dispColumn As C1.Win.C1TrueDBGrid.C1DisplayColumn = .DisplayColumns(dispColumnOld.DataColumn)
            dispColumn.Style.HorizontalAlignment = dispColumnOld.Style.HorizontalAlignment
            dispColumn.Style.VerticalAlignment = dispColumnOld.Style.VerticalAlignment
            dispColumn.Style.Font = New Font(dispColumnOld.Style.Font.Name, dispColumnOld.Style.Font.Size, dispColumnOld.Style.Font.Style)
            dispColumn.HeadingStyle.Font = New Font(dispColumnOld.HeadingStyle.Font.Name, dispColumnOld.HeadingStyle.Font.Size, dispColumnOld.HeadingStyle.Font.Style)
            dispColumn.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            dispColumn.Button = dispColumnOld.Button
            dispColumn.ButtonAlways = dispColumnOld.ButtonAlways
            dispColumn.ButtonText = dispColumnOld.ButtonText
            dispColumn.FetchStyle = dispColumnOld.FetchStyle
            dispColumn.Locked = dispColumnOld.Locked
            dispColumn.Merge = dispColumnOld.Merge
            dispColumn.Visible = dispColumnOld.Visible
            .DisplayColumns.RemoveAt(iDisplay)
            .DisplayColumns.Insert(posNew, dispColumn)
        End With
    End Sub
    Private Sub SetFormatCol(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sField As String, sDecimals As String)
        Dim iSplitIndex As Integer = 1 'c1Grid.Splits.Count - 1
        Try
            c1Grid.Splits(0).DisplayColumns(sField).Visible = False
            c1Grid.Splits(2).DisplayColumns(sField).Visible = False
            c1Grid.Splits(iSplitIndex).DisplayColumns(sField).Visible = True

            c1Grid.Splits(iSplitIndex).DisplayColumns(sField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            AddDecimalColumns(arrCol, sField, "N" & L3Int(sDecimals), 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
            c1Grid.Splits(iSplitIndex).DisplayColumns(sField).Width = 110
            sSumFooter.Add(sField)
        Catch ex As Exception

        End Try

        c1Grid.Splits(iSplitIndex).DisplayColumns(sField).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        c1Grid.Splits(iSplitIndex).DisplayColumns(sField).HeadingStyle.Font = FontUnicode(gbUnicode)
        c1Grid.Splits(iSplitIndex).DisplayColumns(sField).Style.Font = FontUnicode(gbUnicode)
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2065
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 26/10/2016 10:04:09
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2065() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cot dong" & vbCrlf)
        sSQL &= "Exec D45P2065 "
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString("Employee") & COMMA 'TransTypeID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2064
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 26/10/2016 10:08:45
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2064() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrlf)
        sSQL &= "Exec D45P2064 "
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'WhereClause, ntext, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString("D45F2060") 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0103s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/02/2007 08:48:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2063(dr() As DataRow, ByVal iRow As Integer) As String
        Dim sRet As String = ""
        Dim sSQL As String = ""
        sSQL = "Delete  D45T2063"
        sSQL &= " Where DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " And  	AbsentVoucherID = " & SQLString(_absentVoucherID)
        sSQL &= " And TransID = " & SQLString(dr(iRow).Item(COL_TransID).ToString)

        sRet &= sSQL & vbCrLf
        Return sRet
    End Function


    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLInsertD45T2063s
    ''# Created User: Nguyễn Lê Phương
    ''# Created Date: 27/02/2007 08:55:25
    ''# Modify User: Trần Thị Ái Trâm
    ''# Modify Date: 06/06/2007 2:00:37 PM
    ''# Description: 
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLInsertD45T2063s(dr() As DataRow) As String
    '    Dim iCount As Int32 = 0
    '    Dim bResult As Boolean
    '    Dim sSQL As String = ""

    '    For i As Integer = 0 To dr.Length - 1
    '        iCount += 1
    '        sSQL &= SQLDeleteD45T2063(dr, i) & vbCrLf

    '        For j As Integer = 0 To dtCol.Rows.Count - 1
    '            Dim sField As String = dtCol.Rows(j).Item("FieldName").ToString
    '            '***************
    '            If Number(dr(i).Item(sField)) <> 0 Then
    '                sSQL &= "Insert Into D45T2063(" & vbCrLf
    '                sSQL &= " TransID, DivisionID, AbsentVoucherID, EmployeeID, DepartmentID, TeamID, AbsentTypeID, " & vbCrLf
    '                sSQL &= " TranMonth, TranYear, NumberOfDays" & vbCrLf
    '                sSQL &= ") Values (" & vbCrLf
    '                sSQL &= SQLString(dr(i).Item(COL_TransID).ToString) & COMMA 'TransID [KEY], varchar[20], NOT NULL
    '                sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID [KEY], varchar[20], NOT NULL
    '                sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID [KEY], varchar[20], NOT NULL
    '                sSQL &= SQLString(dr(i).Item(COL_EmployeeID).ToString) & COMMA 'EmployeeID , varchar[20], NOT NULL
    '                sSQL &= SQLString(dr(i).Item(COL_DepartmentID).ToString) & COMMA 'DepartmentID , varchar[20], NOT NULL
    '                sSQL &= SQLString(dr(i).Item(COL_TeamID).ToString) & COMMA 'TeamID, varchar[20], NOT NULL
    '                sSQL &= SQLString(sField) & COMMA 'AbsentTypeID, varchar[20], NOT NULL
    '                sSQL &= SQLNumber(giTranMonth) & COMMA 'Tranmonth, tinyint, NOT NULL
    '                sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
    '                sSQL &= SQLMoney(dr(i).Item(sField).ToString) 'NumberOfDays, decimal, NOT NULL
    '                sSQL &= ")" & vbCrLf
    '            End If
    '        Next

    '        'Update 01/11/2011: Trả về chuỗi thực thi cho bảng D13T0105
    '        sRetSQLInsertD45T2064.Append(SQLInsertD45T2064s(dr, i).ToString)

    '        If iCount = 10 Then
    '            bResult = ExecuteSQL(sSQL)
    '            If bResult = True Then
    '                iCount = 0
    '                sSQL = ""
    '                If i = tdbg.RowCount - 1 Then
    '                    btnSave.Enabled = True
    '                    btnClose.Enabled = True
    '                    btnClose.Focus()
    '                    Exit For
    '                End If
    '            Else
    '                SaveNotOK()
    '                btnSave.Enabled = True
    '                btnClose.Enabled = True
    '                btnClose.Focus()
    '                Exit For
    '            End If
    '        End If
    '    Next
    '    Return sSQL
    'End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2066s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/10/2016 02:16:41
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2063s(dr() As DataRow) As StringBuilder()
        Dim sRet() As StringBuilder = Nothing
        Dim iCountSQL As Integer = 0 'Đếm số câu SQL để thực thi
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet Is Nothing Then sSQL.Append("-- Luu D45T2063" & vbCrLf)
            sSQL.Append(SQLDeleteD45T2063(dr, i) & vbCrLf)

            For j As Integer = 0 To dtCol.Rows.Count - 1
                Dim sField As String = dtCol.Rows(j).Item("FieldName").ToString
                '***************
                If Number(dr(i).Item(sField)) <> 0 Then
                    sSQL.Append("Insert Into D45T2063(" & vbCrLf)
                    sSQL.Append(" TransID, DivisionID, AbsentVoucherID, EmployeeID, DepartmentID, TeamID, AbsentTypeID, " & vbCrLf)
                    sSQL.Append(" TranMonth, TranYear, NumberOfDays" & vbCrLf)
                    sSQL.Append(") Values (" & vbCrLf)
                    sSQL.Append(SQLString(dr(i).Item(COL_TransID).ToString) & COMMA) 'TransID [KEY], varchar[20], NOT NULL
                    sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID [KEY], varchar[20], NOT NULL
                    sSQL.Append(SQLString(_absentVoucherID) & COMMA) 'AbsentVoucherID [KEY], varchar[20], NOT NULL
                    sSQL.Append(SQLString(dr(i).Item(COL_EmployeeID).ToString) & COMMA) 'EmployeeID , varchar[20], NOT NULL
                    sSQL.Append(SQLString(dr(i).Item(COL_DepartmentID).ToString) & COMMA) 'DepartmentID , varchar[20], NOT NULL
                    sSQL.Append(SQLString(dr(i).Item(COL_TeamID).ToString) & COMMA) 'TeamID, varchar[20], NOT NULL
                    sSQL.Append(SQLString(sField) & COMMA) 'AbsentTypeID, varchar[20], NOT NULL
                    sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'Tranmonth, tinyint, NOT NULL
                    sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
                    sSQL.Append(SQLMoney(dr(i).Item(sField).ToString)) 'NumberOfDays, decimal, NOT NULL
                    sSQL.Append(")" & vbCrLf)
                End If
            Next
            'Update 01/11/2011: Trả về chuỗi thực thi cho bảng D13T0105
            sSQL.Append(SQLInsertD45T2064s(dr, i).ToString & vbCrLf)

            iCountSQL += 1
            sRet = ReturnSQL(sRet, sSQL, iCountSQL, 10) 'Mặc định là 30 dòng Insert
        Next
        sRet = AddValueInArrStringBuilder(sRet, sSQL, True) 'Mặc định là thêm vào cuối mảng SQL
        Return sRet
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2064s
    '# Created User: 
    '# Created Date: 17/09/2010 09:16:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Dim sRetSQLInsertD45T2064 As New StringBuilder

    Private Function SQLInsertD45T2064s(dr() As DataRow, ByVal iRow As Integer) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        'Update 01/11/2011: Đưa vòng for thực thi cùng lúc với bảng D45T2064
        'update 10/12/2012 by Hoàng Nhân - id 52810 chỉ insert những dòng có note khác rỗng, nhưng xóa thì all dòng
        sSQL.Append(vbCrLf & "Delete From D45T2064")
        sSQL.Append(" Where AbsentVoucherID = " & SQLString(_AbsentVoucherID))
        sSQL.Append(" AND TransID = " & SQLString(dr(iRow).Item(COL_TransID).ToString) & vbCrLf)

        If tdbg(iRow, COL_Note).ToString <> "" Then
            sSQL.Append("Insert Into D45T2064(")
            sSQL.Append("AbsentVoucherID, TransID, Note, NoteU")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(_AbsentVoucherID) & COMMA) 'AbsentVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(iRow).Item(COL_TransID).ToString) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(iRow).Item(COL_Note).ToString, gbUnicode, False) & COMMA) 'Note, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(iRow).Item(COL_Note).ToString, gbUnicode, True)) 'Note, varchar[500], NOT NULL
            sSQL.Append(")")
        End If
        Return sSQL
    End Function





End Class

