Public Class D45F2070

    Private _bSaved As Boolean=False
    Private _sProductVoucherID As String
    Private _sProSalTransID As String

    Private _sTeamID As String
    Private _sDepartmentID As String
    Private bUpdate As Boolean = False


    Public ReadOnly Property bSaved As Boolean
        Get
            Return _bSaved
        End Get
    End Property
    

    Public WriteOnly Property sProductVoucherID As String
        Set(ByVal Value As String)
            _sProductVoucherID = Value
        End Set
    End Property
    

    Public WriteOnly Property sDepartmentID As String
        Set(ByVal Value As String)
            _sDepartmentID = Value
        End Set
    End Property

    Public WriteOnly Property sTeamID As String
        Set(ByVal Value As String)
            _sTeamID = Value
        End Set
    End Property

    Public WriteOnly Property sProSalTransID As String
        Set(ByVal Value As String)
            _sProSalTransID = Value
        End Set
    End Property


    

#Region "Const of tdbg - Total of Columns: 16"
    Private Const COL_IsUsed As Integer = 0            ' Chọn
    Private Const COL_EmployeeID As Integer = 1        ' Mã nhân viên
    Private Const COL_EmployeeName As Integer = 2      ' Họ và tên
    Private Const COL_DepartmentID As Integer = 3      ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 4    ' Tên phòng ban
    Private Const COL_TeamID As Integer = 5            ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 6          ' Tên tổ nhóm
    Private Const COL_DutyID As Integer = 7            ' Mã chức vụ
    Private Const COL_DutyName As Integer = 8          ' Tên chức vụ
    Private Const COL_Sex As Integer = 9               ' Giới tính
    Private Const COL_BirthDate As Integer = 10        ' Ngày sinh
    Private Const COL_DateJoined As Integer = 11       ' Ngày vào làm
    Private Const COL_IsPayrollProduct As Integer = 12 ' Tính lương sản phẩm
    Private Const COL_IsSalaryFund As Integer = 13     ' Gộp quỹ lương
    Private Const COL_DayworkWages As Integer = 14     ' Lương công nhật
    Private Const COL_ProSalTransID As Integer = 15    ' ProSalTransID
#End Region


    Private dtGrid As DataTable

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
            bLoadFormState = True
            LoadInfoGeneral() ' hàm trong DxxD9940
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property


    Private Sub D45F2070_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        ResetFooterGrid(tdbg)
        LoadTDBGrid()
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DutyName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Sex).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BirthDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DateJoined).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_DayworkWages).DataField, DxxFormat.DefaultNumber4, 28, 8)
        InputNumber(tdbg, arr)
    End Sub



    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_nhan_vienF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Danh sÀch nh¡n vi£n
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnChoiceEmp.Text = rl3("Chon_nhan_vien") 'Chọn nhân viên
        '================================================================ 
        tdbg.Columns(COL_IsUsed).Caption = rl3("Chon") 'Chọn
        tdbg.Columns(COL_EmployeeID).Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns(COL_EmployeeName).Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(COL_DepartmentID).Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rl3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns(COL_TeamName).Caption = rl3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_DutyID).Caption = rl3("Ma_chuc_vu") 'Mã chức vụ
        tdbg.Columns(COL_DutyName).Caption = rl3("Ten_chuc_vu") 'Tên chức vụ
        tdbg.Columns(COL_Sex).Caption = rl3("Gioi_tinh") 'Giới tính
        tdbg.Columns(COL_BirthDate).Caption = rl3("Ngay_sinh") 'Ngày sinh
        tdbg.Columns(COL_DateJoined).Caption = rl3("Ngay_vao_lam") 'Ngày vào làm
        tdbg.Columns(COL_IsPayrollProduct).Caption = rl3("Tinh_luong_san_pham") 'Tính lương sản phẩm
        tdbg.Columns(COL_IsSalaryFund).Caption = rl3("Gop_quy_luong") 'Gộp quỹ lương
        tdbg.Columns(COL_DayworkWages).Caption = rl3("Luong_cong_nhat") 'Lương công nhật
    End Sub

    Private Sub D45F2070_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt Then
        ElseIf e.Control Then
        Else
            Select Case e.KeyCode
                Case Keys.Enter
                    UseEnterAsTab(Me, True)
                Case Keys.F11
                    HotKeyF11(Me, tdbg)
            End Select
        End If
    End Sub

    Private Sub D45F2070_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btnSave.Enabled And bUpdate Then
            If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
        End If
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bIsSelectEmp As Boolean = False)
        Dim sSQL As String = SQLStoreD45P2071()
        If bIsSelectEmp Then
            Dim dtTemp As DataTable = dtGrid.Clone

            If dtGrid IsNot Nothing AndAlso dtGrid.Rows.Count > 0 Then
                dtTemp = ReturnDataTable(sSQL)
                Try
                    dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("EmployeeID")}
                    dtGrid.Merge(dtTemp, True, MissingSchemaAction.AddWithKey)
                Catch ex As Exception
                End Try
            Else
                dtGrid = dtTemp
            End If
        Else
            dtGrid = ReturnDataTable(sSQL)
        End If
        dtGrid.Columns(COL_ProSalTransID).Expression = "'" & _sProSalTransID & "'"
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        SUMFooter()
    End Sub

    Private Sub SUMFooter()
        FooterTotalGrid(tdbg, COL_EmployeeID)
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'ExecuteSQLNoTransaction(SQLDeleteD91T9009(Me.Name))
        Me.Close()
    End Sub

    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        tdbg.UpdateData()
        dr = dtGrid.Select("IsUsed=1")
        If tdbg.RowCount <= 0 OrElse dr.Length = 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim dr() As DataRow
        If Not AllowSave(dr) Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False
        bUpdate = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLDeleteD45T2070() & vbCrLf)
        sSQL.Append(SQLInsertD45T2070s(dr).ToString)
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

    Private Sub btnChoiceEmp_Click(sender As Object, e As EventArgs) Handles btnChoiceEmp.Click
        ExecuteSQLNoTransaction(SQLDeleteD91T9009(Me.Name))


        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", Me.Name)
        SetProperties(arrPro, "Key01", "F_EmployeeID")
        SetProperties(arrPro, "FormID", Me.Name)
        SetProperties(arrPro, "ModuleID", "15")

        If L3Bool(GetProperties(CallFormShowDialog("D09D2040", "D09F5605", arrPro), "bSaved")) Then
            LoadTDBGrid(True)
            bUpdate = True
        End If
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case e.Col
            Case COL_DayworkWages
                If L3Bool(tdbg(e.Row, COL_IsPayrollProduct)) Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        tdbg.UpdateData()
        bUpdate = True
        Select Case e.ColIndex
            Case COL_IsUsed
            Case COL_EmployeeID
            Case COL_EmployeeName
            Case COL_DepartmentID
            Case COL_DepartmentName
            Case COL_TeamID
            Case COL_TeamName
            Case COL_DutyID
            Case COL_DutyName
            Case COL_Sex
            Case COL_BirthDate
            Case COL_DateJoined
            Case COL_IsPayrollProduct
                If L3Bool(tdbg(tdbg.Row, e.ColIndex)) Then
                    tdbg(tdbg.Row, COL_DayworkWages) = 0
                End If
            Case COL_IsSalaryFund
            Case COL_DayworkWages
        End Select
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_IsUsed, COL_IsSalaryFund
                L3HeadClick(tdbg, iCol, bSelect)
            Case COL_IsPayrollProduct
                L3HeadClick(tdbg, iCol, bSelect)
                For i As Integer = 0 To tdbg.RowCount - 1
                    If L3Bool(tdbg(i, COL_IsPayrollProduct)) Then tdbg(i, COL_DayworkWages) = 0
                Next
                tdbg.UpdateData()

            Case COL_DayworkWages
                CopyColumns(tdbg, iCol, COL_IsPayrollProduct, "False")
            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col)
    End Sub





    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2071
    '# Created User: Kim Long
    '# Created Date: 10/05/2018 09:42:17
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2071() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho Grid" & vbCrlf)
        sSQL &= "Exec D45P2071 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_sDepartmentID) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(_sTeamID) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(_sProSalTransID) & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) 'TransID, varchar[20], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2070s
    '# Created User: Kim Long
    '# Created Date: 18/05/2018 03:33:47
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2070s(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert D45T2070" & vbCrLf)
            sSQL.Append("Insert Into D45T2070(")
            sSQL.Append("ProductVoucherID,  ProSalTransID,  " & vbCrLf)
            sSQL.Append(" EmployeeID,DepartmentID,TeamID, IsPayrollProduct, IsSalaryFund, DayworkWages")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(_sProductVoucherID) & COMMA) 'ProductVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("ProSalTransID")) & COMMA) 'ProSalTransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dr(i).Item("EmployeeID")) & COMMA) 'EmployeeID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_sDepartmentID) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_sTeamID) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(dr(i).Item("IsPayrollProduct")) & COMMA) 'IsPayrollProduct, tinyint, NOT NULL
            sSQL.Append(SQLNumber(dr(i).Item("IsSalaryFund")) & COMMA & vbCrLf) 'IsSalaryFund, tinyint, NOT NULL
            sSQL.Append(SQLMoney(dr(i).Item("DayworkWages"))) 'DayworkWages, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2070
    '# Created User: Kim Long
    '# Created Date: 18/05/2018 05:25:03
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2070() As String
        Dim sSQL As String = ""
        sSQL &= ("--DEL D45T2070" & vbCrLf)
        sSQL &= "Delete From D45T2070"
        sSQL &= " Where ProSalTransID=" & SQLString(_sProSalTransID)
        Return sSQL
    End Function




  
End Class