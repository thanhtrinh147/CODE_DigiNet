'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:43:06 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:43:06 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Imports System.Text
Public Class D13F1034

#Region "Const of tdbg"
    Private Const COL_DepartmentID As Integer = 0      ' Phòng ban
    Private Const COL_DepartmentName As Integer = 1    ' Tên phòng ban
    Private Const COL_TeamID As Integer = 2            ' Tổ nhóm
    Private Const COL_TeamName As Integer = 3          ' Tên nhóm
    Private Const COL_EmployeeID As Integer = 4        ' Mã nhân viên
    Private Const COL_FullName As Integer = 5          ' Tên nhân viên
    Private Const COL_IsNew As Integer = 6             ' Nhân viên mới
    Private Const COL_Disabled As Integer = 7          ' Không sử dụng
    Private Const COL_BaseSalary01 As Integer = 8      ' Mức lương 1
    Private Const COL_BaseSalary02 As Integer = 9      ' Mức lương 2
    Private Const COL_BaseSalary03 As Integer = 10     ' Mức lương 3
    Private Const COL_BaseSalary04 As Integer = 11     ' Mức lương 4
    Private Const COL_SalCoefficient01 As Integer = 12 ' Hệ số lương 1
    Private Const COL_SalCoefficient02 As Integer = 13 ' Hệ số lương 2
    Private Const COL_SalCoefficient03 As Integer = 14 ' Hệ số lương 3
    Private Const COL_SalCoefficient04 As Integer = 15 ' Hệ số lương 4
    Private Const COL_SalCoefficient05 As Integer = 16 ' Hệ số lương 5
    Private Const COL_SalCoefficient06 As Integer = 17 ' Hệ số lương 6
    Private Const COL_SalCoefficient07 As Integer = 18 ' Hệ số lương 7
    Private Const COL_SalCoefficient08 As Integer = 19 ' Hệ số lương 8
    Private Const COL_SalCoefficient09 As Integer = 20 ' Hệ số lương 9
    Private Const COL_SalCoefficient10 As Integer = 21 ' Hệ số lương 10
    Private Const COL_CreateUserID As Integer = 22     ' Người tạo
    Private Const COL_CreateDate As Integer = 23       ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 24 ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 25   ' Ngày cập nhật cuối cùng
    Private Const COL_IsUsed As Integer = 26           ' Chọn
#End Region

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Dim dtFind As DataTable
    Private bBA As SALBA
    Private bCE As SALCE
    Public _FormState As EnumFormState

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F1034_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        FormKeyPress(sender, e)
    End Sub

    Private Sub D13F1034_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        SetShortcutPopupMenu(Me.C1CommandHolder)
        Loadlanguage()
        gbEnabledUseFind = False
        LoadTDBCombo()
        ResetColorGrid(tdbg, 0, 1)
        tdbg_NumberFormat()
        SQLD13T9000()
        ShowColumns()
        SetResolutionForm(Me, Me.C1ContextMenu)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_nhan_vien_den_thoi_han_tang_luong_-_D13F1034") 'Danh sÀch nh¡n vi£n ¢Õn théi hÁn tŸng l§¥ng - D13F1034
        '================================================================ 
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...

        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("FullName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbg.Columns("IsNew").Caption = rl3("Nhan_vien_moi") 'Nhân viên mới
        tdbg.Columns("Disabled").Caption = rl3("Khong_su_dung") 'Không sử dụng
        tdbg.Columns("BaseSalary01").Caption = rl3("Muc_luong_1") 'Mức lương 1
        tdbg.Columns("BaseSalary02").Caption = rl3("Muc_luong_2") 'Mức lương 2
        tdbg.Columns("BaseSalary03").Caption = rl3("Muc_luong_3") 'Mức lương 3
        tdbg.Columns("BaseSalary04").Caption = rl3("Muc_luong_4") 'Mức lương 4
        tdbg.Columns("SalCoefficient01").Caption = rl3("He_so_luong_1") 'Hệ số lương 1
        tdbg.Columns("SalCoefficient02").Caption = rl3("He_so_luong_2") 'Hệ số lương 2
        tdbg.Columns("SalCoefficient03").Caption = rl3("He_so_luong_3") 'Hệ số lương 3
        tdbg.Columns("SalCoefficient04").Caption = rl3("He_so_luong_4") 'Hệ số lương 4
        tdbg.Columns("SalCoefficient05").Caption = rl3("He_so_luong_5") 'Hệ số lương 5
        tdbg.Columns("SalCoefficient06").Caption = rl3("He_so_luong_6") 'Hệ số lương 6
        tdbg.Columns("SalCoefficient07").Caption = rl3("He_so_luong_7") 'Hệ số lương 7
        tdbg.Columns("SalCoefficient08").Caption = rl3("He_so_luong_8") 'Hệ số lương 8
        tdbg.Columns("SalCoefficient09").Caption = rl3("He_so_luong_9") 'Hệ số lương 9
        tdbg.Columns("SalCoefficient10").Caption = rl3("He_so_luong_10") 'Hệ số lương 10
        tdbg.Splits(0).Caption = rl3("Thong_tin_chung") 'Thông tin chung
        tdbg.Splits(1).Caption = rl3("Thong_tin_ve_muc_luong_va_he_so_luong") ' Thông tin về mức lương và hệ số lương


        '================================================================ 
        mnuView.Text = rl3("Xe_m") 'Xe&m
        mnuAutoCalCulate.Text = rl3("Tinh_tu_dong") 'Tính tự động
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
        mnuEdit.Text = rl3("_Sua") '&Sửa
    End Sub


    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDepartmentID
        sSQL &= " Select DepartmentID, DepartmentName, 1 As DisplayOrder From D91T0012  WITH (NOLOCK) " & vbCrLf
        sSQL &= " Where 	DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= " And Disabled = 0   " & vbCrLf
        sSQL &= " Union Select '%' AS DepartmentID, " & AllName & " AS DepartmentName, 0 As DisplayOrder" & vbCrLf
        sSQL &= " Order by DisplayOrder, DepartmentID"
        LoadDataSource(tdbcDepartmentID, sSQL)
    End Sub

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        ShowColumns()
        LoadTDBGrid()
    End Sub

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDepartmentID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDepartmentID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL &= SQLStoreD13P1034()
        dtFind = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtFind)
        CheckMenu1(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, False)
        EnabledMenu()
    End Sub

    Private Sub mnuView_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuView.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim f As New D13F1031
        With f
            .DepartmentID = tdbg.Columns(COL_DepartmentID).Text
            .TeamID = tdbg.Columns(COL_TeamID).Text
            .EmployeeID = tdbg.Columns(COL_EmployeeID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1031
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 14/02/2007 11:21:11
    '# Modified User: Do Minh Dung
    '# Modified Date: 28/11/2007
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1031() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1031 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function

    Private Sub mnuSysInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSysInfo.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.RowCount < 1 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If mnuView.Enabled Then
            mnuView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        Select Case e.ColIndex
            Case COL_DepartmentID
                e.CellTip = tdbg.Columns(COL_DepartmentName).Text
            Case COL_TeamID
                e.CellTip = tdbg.Columns(COL_TeamName).Text
            Case Else
                e.CellTip = ""
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If e.ColIndex = 0 Then 'chú ý col_IsUsed = 26 chứ k phải = 0
            Dim bCheck As Boolean = CBool(tdbg(0, COL_IsUsed))
            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_IsUsed) = Not bCheck
            Next i
        End If

    End Sub
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.RowCount < 1 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            'If mnuEdit.Enabled Then
            '    mnuEdit_Click(sender, Nothing)
            'Else
            If mnuView.Enabled Then
                mnuView_Click(sender, Nothing)
            End If

        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_BaseSalary01).NumberFormat = Format(tdbg.Columns(COL_BaseSalary01).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_BaseSalary02).NumberFormat = Format(tdbg.Columns(COL_BaseSalary02).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_BaseSalary03).NumberFormat = Format(tdbg.Columns(COL_BaseSalary03).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_BaseSalary04).NumberFormat = Format(tdbg.Columns(COL_BaseSalary04).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_SalCoefficient01).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient01).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_SalCoefficient02).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient02).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_SalCoefficient03).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient03).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_SalCoefficient04).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient04).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_SalCoefficient05).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient05).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_SalCoefficient06).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient06).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_SalCoefficient07).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient07).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_SalCoefficient08).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient08).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_SalCoefficient09).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient09).Text, D13Format.DefaultNumber2)
        tdbg.Columns(COL_SalCoefficient10).NumberFormat = Format(tdbg.Columns(COL_SalCoefficient10).Text, D13Format.DefaultNumber2)
    End Sub

    Private Sub SQLD13T9000()
        Dim sSQL As String = ""
        sSQL &= "Select Code, Short, Disabled, Type From D13T9000  WITH (NOLOCK) Order By Code"

        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim dt1 As DataTable

        dt1 = ReturnTableFilter(dt, "Type='SALBA'")
        bBA.BASE01 = CBool(IIf(dt1.Rows(0).Item("Disabled").ToString = "0", True, False))
        bBA.BASE02 = CBool(IIf(dt1.Rows(1).Item("Disabled").ToString = "0", True, False))
        bBA.BASE03 = CBool(IIf(dt1.Rows(2).Item("Disabled").ToString = "0", True, False))
        bBA.BASE04 = CBool(IIf(dt1.Rows(3).Item("Disabled").ToString = "0", True, False))
        tdbg.Columns(COL_BaseSalary01).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_BaseSalary02).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_BaseSalary03).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_BaseSalary04).Caption = dt1.Rows(3).Item("Short").ToString

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
        tdbg.Columns(COL_SalCoefficient01).Caption = dt1.Rows(0).Item("Short").ToString
        tdbg.Columns(COL_SalCoefficient02).Caption = dt1.Rows(1).Item("Short").ToString
        tdbg.Columns(COL_SalCoefficient03).Caption = dt1.Rows(2).Item("Short").ToString
        tdbg.Columns(COL_SalCoefficient04).Caption = dt1.Rows(3).Item("Short").ToString
        tdbg.Columns(COL_SalCoefficient05).Caption = dt1.Rows(4).Item("Short").ToString
        tdbg.Columns(COL_SalCoefficient06).Caption = dt1.Rows(5).Item("Short").ToString
        tdbg.Columns(COL_SalCoefficient07).Caption = dt1.Rows(6).Item("Short").ToString
        tdbg.Columns(COL_SalCoefficient08).Caption = dt1.Rows(7).Item("Short").ToString
        tdbg.Columns(COL_SalCoefficient09).Caption = dt1.Rows(8).Item("Short").ToString
        tdbg.Columns(COL_SalCoefficient10).Caption = dt1.Rows(9).Item("Short").ToString
    End Sub
    Private Sub ShowColumns()
        tdbg.Splits(1).DisplayColumns(COL_BaseSalary01).Visible = bBA.BASE01
        tdbg.Splits(1).DisplayColumns(COL_BaseSalary02).Visible = bBA.BASE02
        tdbg.Splits(1).DisplayColumns(COL_BaseSalary03).Visible = bBA.BASE03
        tdbg.Splits(1).DisplayColumns(COL_BaseSalary04).Visible = bBA.BASE04
        tdbg.Splits(1).DisplayColumns(COL_SalCoefficient01).Visible = bCE.CE01
        tdbg.Splits(1).DisplayColumns(COL_SalCoefficient02).Visible = bCE.CE02
        tdbg.Splits(1).DisplayColumns(COL_SalCoefficient03).Visible = bCE.CE03
        tdbg.Splits(1).DisplayColumns(COL_SalCoefficient04).Visible = bCE.CE04
        tdbg.Splits(1).DisplayColumns(COL_SalCoefficient05).Visible = bCE.CE05
        tdbg.Splits(1).DisplayColumns(COL_SalCoefficient06).Visible = bCE.CE06
        tdbg.Splits(1).DisplayColumns(COL_SalCoefficient07).Visible = bCE.CE07
        tdbg.Splits(1).DisplayColumns(COL_SalCoefficient08).Visible = bCE.CE08
        tdbg.Splits(1).DisplayColumns(COL_SalCoefficient09).Visible = bCE.CE09
        tdbg.Splits(1).DisplayColumns(COL_SalCoefficient10).Visible = bCE.CE10
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1034
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 26/02/2007 08:20:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1034() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1034 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbcDepartmentID.SelectedValue.ToString) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(sFind) 'WhereClause, varchar[6000], NOT NULL
        Return sSQL
    End Function

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        Dim p As Point = btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top + 50))
        C1ContextMenu.ShowContextMenu(btnAction, p)
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim sSQL As String = ""
        gbEnabledUseFind = True
        sSQL = "Select * From D13V1234 "
        sSQL &= "Where FormID = " & SQLString(Me.Name) & "And Language = " & SQLString(gsLanguage)
        ShowFindDialogClient(Finder, sSQL, Me)
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.Tostring = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        sFind = ""
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        LoadGridFind(tdbg, dtFind, sFind)
        CheckMenu1(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, False)
        EnabledMenu()
    End Sub
#End Region
    Public Sub CheckMenu1(ByVal FormName As String, ByVal C1CommandHolder As C1.Win.C1Command.C1CommandHolder, ByVal GridRowCount As Integer, ByVal UsedFind As Boolean, ByVal CheckCloseBook As Boolean)
        Dim per As Integer = ReturnPermission(FormName)
        For Each c As C1.Win.C1Command.C1Command In C1CommandHolder.Commands
            Select Case c.Name
                Case "mnuFind" : c.Enabled = UsedFind Or GridRowCount > 0
                Case "mnuListAll" : c.Enabled = UsedFind Or GridRowCount > 0
                Case "mnuSysInfo" : c.Enabled = GridRowCount > 0
            End Select
        Next
    End Sub

    Private Sub CheckWhenHeadClick()
        If tdbg.RowCount <= 0 Then Exit Sub
        'If tdbg.Col = COL_IsUsed Then
        Dim bCheck As Boolean = CBool(tdbg(0, tdbg.Col))
        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, tdbg.Col) = Not bCheck
        Next i
        'End If
    End Sub

    Private Sub mnuAutoCalculate_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAutoCalCulate.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        Dim sSQL As New StringBuilder
        Dim bChoosedAtLeast As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed)) = True Then bChoosedAtLeast = True
        Next
        If bChoosedAtLeast = False Then
            'D99C0008.MsgL3(rl3("Ban_phai_chon_tren_luoi"))
            D99C0008.MsgNoDataInGrid()
            Exit Sub
        End If
        _bSaved = False '   gbFlag = False
        sSQL.Append("CREATE TABLE #D13T0201(EmployeeID Varchar(20))" & vbCrLf)
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_IsUsed).ToString = "True" Then
                sSQL.Append("INSERT INTO #D13T0201(EmployeeID) VALUES(" & SQLString(tdbg(i, COL_EmployeeID)) & ")" & vbCrLf)
            End If
        Next i
        sSQL.Append(SQLStoreD13P1031() & vbCrLf)
        sSQL.Append("DROP TABLE #D13T0201")
        Me.Cursor = Cursors.WaitCursor
        Dim bResult As Boolean = ExecuteSQL(sSQL.ToString)
        If bResult = True Then
            _bSaved = True  '  gbFlag = True
            D99C0008.MsgL3(rl3("Tinh_tu_dong_tang_thong_so_luong_thanh_cong"))
            'LoadTDBGrid()
        Else
            D99C0008.MsgL3(rl3("Tinh_tu_dong_tang_thong_so_luong_khong_thanh_cong"))
            Return
        End If
        Me.Cursor = Cursors.Default
        Me.Close()
    End Sub
    Private Sub EnabledMenu()
        If tdbg.RowCount = 0 Then
            mnuView.Enabled = False
            mnuAutoCalCulate.Enabled = False
        Else
            mnuView.Enabled = True
            If _FormState = EnumFormState.FormView Then
                mnuAutoCalCulate.Enabled = False
            Else
                mnuAutoCalCulate.Enabled = True
            End If
        End If
    End Sub

End Class