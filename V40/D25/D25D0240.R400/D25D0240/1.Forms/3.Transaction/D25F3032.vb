Imports System
Public Class D25F3032


#Region "Const of tdbg - Total of Columns: 9"
    Private Const COL_OrderNo As Integer = 0               ' STT
    Private Const COL_EvaluationElementID As Integer = 1   ' EvaluationElementID
    Private Const COL_EvaluationElementName As Integer = 2 ' Chỉ tiêu yêu cầu
    Private Const COL_EvaluationLevelName As Integer = 3   ' Loại
    Private Const COL_EvaluationLevelID As Integer = 4     ' EvaluationLevelID
    Private Const COL_EPoint As Integer = 5                ' Giá trị
    Private Const COL_MaxValue As Integer = 6              ' MaxValue
    Private Const COL_IsDisplayLevel As Integer = 7        ' IsDisplayLevel
    Private Const COL_Method As Integer = 8                ' Method
#End Region


    Private _candidateID As String = ""
    Public WriteOnly Property CandidateID() As String 
        Set(ByVal Value As String )
            _candidateID = Value
        End Set
    End Property

    Private _candidateName As String = ""
    Public WriteOnly Property CandidateName() As String 
        Set(ByVal Value As String )
            _candidateName = Value
        End Set
    End Property

    Private _recPositionID As String = ""
    Public WriteOnly Property RecPositionID() As String 
        Set(ByVal Value As String )
            _recPositionID = Value
        End Set
    End Property

    Private _recPositionName As String = ""
    Public WriteOnly Property RecPositionName() As String 
        Set(ByVal Value As String )
            _recPositionName = Value
        End Set
    End Property

    Private _sexName As String = ""
    Public WriteOnly Property SexName() As String 
        Set(ByVal Value As String )
            _sexName = Value
        End Set
    End Property

    Private _birthDate As String = ""
    Public WriteOnly Property BirthDate() As String 
        Set(ByVal Value As String )
            _birthDate = Value
        End Set
    End Property

    Private _interviewFileID As String = ""
    Public WriteOnly Property InterviewFileID As String
        Set(ByVal Value As String)
            _interviewFileID = Value
        End Set
    End Property

    Dim dtELevelID As DataTable

    Private Sub D25F3032_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
    End Sub

    Private Sub D25F3032_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        tdbg.Focus()
    End Sub

    Private Sub D25F3032_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadMaster()
        LoadDetail()
        c1dateBirthDate.ReadOnly = True
        InputbyUnicode(Me, gbUnicode)
InputDateCustomFormat(c1dateBirthDate)
        SetResolutionForm(Me)
        tdbg.Col = 0
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_gia_theo_chi_tieu_yeu_cau_-_D25F3032") & UnicodeCaption(gbUnicode) '˜Ành giÀ theo chÙ ti£u y£u cÇu - D25F3032
        '================================================================ 
        lblEmployeeID.Text = rl3("Ma_nhan_vien") 'Mã nhân viên
        lblFullName.Text = rl3("Ten_nhan_vien") 'Tên nhân viên
        lblSexName.Text = rl3("Gioi_tinh") 'Giới tính
        lblteBirthDate.Text = rl3("Ngay_sinh") 'Ngày sinh
        lblRecPositionname.Text = rl3("Vi_tri") 'Vị trí
        lblEvaluationElement.Text = rl3("Chi_tiet_yeu_cau") 'Chỉ tiêu yêu cầu
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbdEvaluationLevelID.Columns("EvaluationLevelID").Caption = rL3("Ma") 'Mã
        tdbdEvaluationLevelID.Columns("EvaluationLevelName").Caption = rL3("Loai") 'Loại
        tdbdEvaluationLevelID.Columns("Value").Caption = rL3("Gia_tri_") 'Giá trị
        '================================================================ 
        tdbg.Columns("OrderNo").Caption = rl3("STT") 'STT
        tdbg.Columns("EvaluationElementName").Caption = rl3("Chi_tiet_yeu_cau") 'Chỉ tiêu yêu cầu
        tdbg.Columns("EvaluationLevelID").Caption = rl3("Loai") 'Loại
        tdbg.Columns("EPoint").Caption = rl3("Gia_tri_") 'Giá trị
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EvaluationElementID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EvaluationElementName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_EPoint).NumberFormat = D25Format.DefaultNumber2
    End Sub

    Private Sub LoadtdbdEvaluationLevelID(ByVal sEvaluationElementID As String)
        Dim sSQL As String = ""
        'Load tdbdEvaluationLevelID

        'sSQL = "SELECT		EvaluationLevelID," & vbCrLf
        'sSQL &= "			EvaluationLevelName" & UnicodeJoin(gbUnicode) & " AS EvaluationLevelName" & vbCrLf
        'sSQL &= "FROM		D39T1001 T1 WITH(NOLOCK) " & vbCrLf
        'sSQL &= "LEFT JOIN	D39T1000 T2 WITH(NOLOCK) " & vbCrLf
        'sSQL &= "	ON		T1.EvaluationElementID = T2.EvaluationElementID" & vbCrLf
        'sSQL &= "WHERE		T1.EvaluationElementID = " & SQLString(sEvaluationElementID) & vbCrLf

        'ID 96923 29.05.2017
        'Load tdbdEvaluationLevelID
        sSQL = "SELECT		T1.EvaluationLevelID as EvaluationLevelID ," & vbCrLf
        sSQL &= "			T1.EvaluationLevelName" & UnicodeJoin(gbUnicode) & " AS EvaluationLevelName," & vbCrLf
        sSQL &= "			T1.ValueFrom, T1.ValueTo, T1.Value" & vbCrLf
        sSQL &= " FROM		D39T1001 T1 WITH(NOLOCK) " & vbCrLf
        sSQL &= " LEFT JOIN	D39T1000 T2 WITH(NOLOCK) " & vbCrLf
        sSQL &= "	ON		T1.EvaluationElementID = T2.EvaluationElementID" & vbCrLf
        sSQL &= "WHERE	    T2.IsUseD25 =1 AND 	T1.EvaluationElementID = " & SQLString(sEvaluationElementID) & vbCrLf
        dtELevelID = ReturnDataTable(sSQL)
        LoadDataSource(tdbdEvaluationLevelID, dtELevelID, gbUnicode)
    End Sub

    Private Sub LoadMaster()
        txtEmployeeID.Text = _candidateID
        txtFullName.Text = _candidateName
        txtSexName.Text = _sexName
        c1dateBirthDate.Value = _birthDate
        txtRecPositionName.Text = _recPositionName
    End Sub

    Private Sub LoadDetail()
        Dim sSQL As String = SQLStoreD25P3035()

        'sSQL = "SELECT		D25.OrderNo, D25.RecPositionID, D25.EvaluationElementID, T1.EvaluationLevelID," & vbCrLf
        'sSQL &= "			EvaluationElementName" & UnicodeJoin(gbUnicode) & " AS EvaluationElementName," & vbCrLf
        'sSQL &= "			EvaluationLevelName" & UnicodeJoin(gbUnicode) & " AS EvaluationLevelName, " & vbCrLf
        'sSQL &= "ISNULL(EPoint ,0) AS EPoint" & vbCrLf
        'sSQL &= "FROM		D25T1021 D25  WITH(NOLOCK) " & vbCrLf
        'sSQL &= "LEFT JOIN 	 D25T3032   T1  WITH(NOLOCK) " & vbCrLf
        'sSQL &= "	ON  		D25.RecPositionID = T1.RecPositionID AND T1.EvaluationElementID = D25.EvaluationElementID AND EmployeeID = " & SQLString(_candidateID) & vbCrLf
        'sSQL &= "LEFT JOIN	D39T1000 T2 WITH(NOLOCK) " & vbCrLf
        'sSQL &= "	ON  		D25.EvaluationElementID = T2.EvaluationElementID" & vbCrLf
        'sSQL &= "LEFT JOIN	D39T1001 D39 WITH(NOLOCK) " & vbCrLf
        'sSQL &= "	ON		D25.EvaluationElementID = D39.EvaluationElementID " & vbCrLf
        'sSQL &= "AND 	T1. EvaluationLevelID= D39. EvaluationLevelID" & vbCrLf
        'sSQL &= "WHERE		D25.RecPositionID = " & SQLString(_recPositionID) & vbCrLf
        'sSQL &= "ORDER BY	D25.OrderNo" & vbCrLf
        LoadDataSource(tdbg, sSQL, gbUnicode)

        'Fix khi du lieu co 1 dong, chua kip RolColChange
        LoadtdbdEvaluationLevelID(tdbg(0, COL_EvaluationElementID).ToString)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_EPoint
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Dim bIsNotInList As Boolean = False
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        tdbg.UpdateData()
        Select Case e.ColIndex
            Case COL_EvaluationLevelName
                If bIsNotInList = True Then
                    tdbg.Columns(COL_EvaluationLevelName).Text = ""
                    tdbg.Columns(COL_EvaluationLevelID).Text = ""
                End If
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    tdbg.Columns(COL_EPoint).Text = ""
                Else
                    tdbg.Columns(COL_EPoint).Value = tdbdEvaluationLevelID.Columns("Value").Text
                End If
            Case COL_EPoint
                If Not bEditTrue Then Exit Sub
                If L3Bool(tdbg.Columns(COL_IsDisplayLevel).Text) Then
                    Dim dr() As DataRow = dtELevelID.Select("ValueFrom <=" & Number(tdbg.Columns(COL_EPoint).Text) & " AND ValueTo >" & Number(tdbg.Columns(COL_EPoint).Text))
                    If dr.Length = 0 Then Exit Sub
                    tdbg.Columns(COL_EvaluationLevelID).Text = L3String(dr(0)("EvaluationLevelID"))
                    tdbg.Columns(COL_EvaluationLevelName).Text = L3String(dr(0)("EvaluationLevelName"))
                End If
        End Select
    End Sub

    Dim bEditTrue As Boolean = False

    Private Sub tdbg_AfterColEdit(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColEdit
        'tdbg.UpdateData()
        Select Case tdbg.Col
            Case COL_EPoint
                If L3Bool(tdbg.Columns(COL_Method).Text) Then Exit Sub
                If L3Bool(tdbg.Columns(COL_IsDisplayLevel).Text) Then
                    If dtELevelID Is Nothing OrElse dtELevelID.Rows.Count = 0 Then Exit Sub
                    Dim dr() As DataRow = dtELevelID.Select("ValueFrom <=" & Number(tdbg.Columns(COL_EPoint).Text) & " AND ValueTo >" & Number(tdbg.Columns(COL_EPoint).Text))
                    If dr.Length = 0 Then
                        If tdbg.Columns(COL_EvaluationLevelName).Text = "" And Number(tdbg.Columns(COL_EPoint).Text) = 0 Then Exit Sub
                        D99C0008.Msg(rL3("Gia_tri_khong_hop_le"))
                        tdbg.Columns(COL_EvaluationLevelID).Text = ""
                        tdbg.Columns(COL_EvaluationLevelName).Text = ""
                        tdbg.Columns(COL_EPoint).Value = 0
                        bEditTrue = False
                        Exit Sub
                    End If
                    bEditTrue = True
                Else
                    If Number(tdbg.Columns(COL_EPoint).Text) > Number(tdbg.Columns(COL_MaxValue).Text) And Number(tdbg.Columns(COL_MaxValue).Text) <> 0 Then
                        D99C0008.Msg(rL3("Gia_tri_nhap_vao_lon_hon_gia_tri_Max__Vui_long_nhap_lai"))
                        tdbg.Columns(COL_EPoint).Value = Number(tdbg.Columns(COL_MaxValue).Text)
                        Exit Sub
                    End If
                End If
        End Select
        'tdbg.UpdateData()
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case e.Col
            Case COL_EvaluationLevelName
                If Not L3Bool(tdbg(e.Row, COL_Method)) Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
            Case COL_EPoint
                If L3Bool(tdbg(e.Row, COL_Method)) Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
        End Select
    End Sub


    'Private Sub tdbg_BeforeRowColChange(sender As Object, e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeRowColChange
    '    tdbg.UpdateData()
    '    Select Case tdbg.Col
    '        Case COL_EPoint
    '            If L3Bool(tdbg.Columns(COL_Method).Text) Then Exit Sub
    '            If L3Bool(tdbg.Columns(COL_IsDisplayLevel).Text) Then
    '                Dim dr() As DataRow = dtELevelID.Select("ValueFrom <=" & Number(tdbg.Columns(COL_EPoint).Text) & " AND ValueTo >" & Number(tdbg.Columns(COL_EPoint).Text))
    '                If dr.Length = 0 Then
    '                    If tdbg.Columns(COL_EvaluationLevelName).Text = "" And Number(tdbg.Columns(COL_EPoint).Text) = 0 Then Exit Sub
    '                    D99C0008.Msg(rL3("Gia_tri_khong_hop_le"))
    '                    tdbg.Columns(COL_EvaluationLevelID).Text = ""
    '                    tdbg.Columns(COL_EvaluationLevelName).Text = ""
    '                    tdbg.Columns(COL_EPoint).Value = 0
    '                    e.Cancel = True
    '                End If

    '            Else
    '                If Number(tdbg.Columns(COL_EPoint).Text) > Number(tdbg.Columns(COL_MaxValue).Text) Then
    '                    D99C0008.Msg(rL3("Gia_tri_nhap_vao_lon_hon_gia_tri_Max__Vui_long_nhap_lai"))
    '                    tdbg.Columns(COL_EPoint).Value = Number(tdbg.Columns(COL_MaxValue).Text)
    '                    e.Cancel = True
    '                End If
    '            End If
    '    End Select
    'End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_EvaluationLevelName
                If tdbg.Columns(COL_EvaluationLevelName).Text <> tdbdEvaluationLevelID.Columns("EvaluationLevelName").Text Then
                    bIsNotInList = True
                Else
                    bIsNotInList = False
                End If
            Case COL_EPoint
                If Not L3IsNumeric(tdbg.Columns(COL_EPoint).Text, EnumDataType.Money) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        '--- Gán giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_EvaluationLevelName
                tdbg.Columns(COL_EvaluationLevelID).Text = tdbdEvaluationLevelID.Columns("EvaluationLevelID").Text
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        '--- Đổ nguồn cho các Dropdown phụ thuộc
        Select Case tdbg.Col
            Case COL_EvaluationLevelName, COL_EPoint
                LoadtdbdEvaluationLevelID(tdbg(tdbg.Row, COL_EvaluationElementID).ToString)
        End Select
        tdbg.Splits(0).DisplayColumns(COL_EvaluationLevelName).Button = L3Bool(tdbg.Columns(COL_Method).Text)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        'If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLDeleteD25T3032.ToString() & vbCrLf)
        sSQL.Append(SQLInsertD25T3032s.ToString() & vbCrLf)

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

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T3032
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 01/07/2011 03:09:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T3032() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T3032"
        'sSQL &= " Where RecPositionID = " & SQLString(_recPositionID)
        sSQL &= " Where InterviewFileID = " & SQLString(_interviewFileID)
        sSQL &= " AND EmployeeID = " & SQLString(_candidateID)

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T3032s
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 01/07/2011 03:10:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T3032s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D25T3032(")
            sSQL.Append("EvaluationLevelID, RecPositionID, EmployeeID, InterviewFileID, EPoint, EvaluationElementID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg(i, COL_EvaluationLevelID)) & COMMA) 'EvaluationLevelID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_recPositionID) & COMMA) 'RecPositionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_candidateID) & COMMA) 'EmployeeID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_interviewFileID) & COMMA) 'InterviewFileID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_EPoint), D25Format.DefaultNumber2) & COMMA) 'EPoint, decimal, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_EvaluationElementID))) 'EvaluationElementID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3035
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/12/2016 02:10:02
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3035() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi" & vbCrlf)
        sSQL &= "Exec D25P3035 "
        sSQL &= SQLString(_interviewFileID) & COMMA 'InterviewFileID, varchar[50], NOT NULL
        sSQL &= SQLString(_recPositionID) & COMMA 'RecPositionID, varchar[50], NOT NULL
        sSQL &= SQLString(_candidateID) 'CandidateID, varchar[50], NOT NULL
        Return sSQL
    End Function




End Class