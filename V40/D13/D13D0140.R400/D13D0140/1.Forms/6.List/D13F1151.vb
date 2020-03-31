Imports System
Public Class D13F1151
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property



#Region "Const of tdbg"
    Private Const COL_Code As Integer = 0              ' Code
    Private Const COL_Description As Integer = 1       ' Diễn giải
    Private Const COL_Short As Integer = 2             ' Tên tắt
    Private Const COL_IsDependSalObject As Integer = 3 ' Phụ thuộc đối tượng tính lương
    Private Const COL_AdjFormula As Integer = 4        ' Công thức
    Private Const COL_ReferentID As Integer = 5        ' ReferentID
    Private Const COL_IsRefer As Integer = 6           ' Tham chiếu
    Private Const COL_AdjFormulaDesc As Integer = 7    ' Diễn giải công thức
    Private Const COL_CalculateOrder As Integer = 8    ' Thứ tự tính
#End Region

#Region "Const of tdbgD"
    Private Const COLD_ReferentID As Integer = 0          ' Mã Tham chiếu
    Private Const COLD_EvaluationElementID As Integer = 1 ' Mã chỉ tiêu đánh giá
    Private Const COLD_AppTypeID As Integer = 2           ' Loại đánh giá
    Private Const COLD_Operator As Integer = 3            ' Toán tử
    Private Const COLD_ValuesFrom As Integer = 4          ' ValuesFrom
    Private Const COLD_ValuesFromName As Integer = 5      ' Giá trị (từ)
    Private Const COLD_ValuesTo As Integer = 6            ' ValuesTo
    Private Const COLD_ValuesToName As Integer = 7        ' Giá trị (đến)
    Private Const COLD_Method As Integer = 8              ' Phương pháp
    Private Const COLD_Values As Integer = 9              ' Giá trị
#End Region

#Region "Const of tdbgL"
    Private Const COLL_EvaluationElementID As Integer = 0 ' Mã chỉ tiêu đánh giá
    Private Const COLL_AppTypeID As Integer = 1           ' Loại đánh giá
    Private Const COLL_ValuesFrom As Integer = 2          ' ValuesFrom
    Private Const COLL_ValuesFromName As Integer = 3      ' Kết quả đánh giá
    Private Const COLL_SalaryObjectID As Integer = 4      ' Đối tượng tính lương
    Private Const COLL_Notes As Integer = 5               ' Ghi chú
#End Region



    Private bUnicode As Boolean = L3Bool(gbUnicode)
    Private dtGrid, dtGridDetail, dtGridDetailL As DataTable
    Private iHeightGrid As Integer = 0
    Private sModifyUserID As String = ""
    Private sModifyDate As String = ""

    Private _payrollAdjustMethodID As String = ""
    Public Property PayrollAdjustMethodID() As String 
        Get
            Return _payrollAdjustMethodID
        End Get
        Set(ByVal Value As String )
            _payrollAdjustMethodID = Value
        End Set
    End Property

    Private _payrollAdjustMethodName As String = ""
    Public WriteOnly Property PayrollAdjustMethodName() As String 
        Set(ByVal Value As String )
            _payrollAdjustMethodName = Value
        End Set
    End Property

    Private _disabled As Boolean = False
    Public WriteOnly Property Disabled() As boolean 
        Set(ByVal Value As boolean )
            _disabled = Value
        End Set
    End Property

    Private _createDate As String = ""
    Public WriteOnly Property CreateDate() As String
        Set(ByVal Value As String)
            _createDate = Value
        End Set
    End Property

    Private _createUserID As String = gsUserID
    Public WriteOnly Property CreateUserID() As String
        Set(ByVal Value As String)
            _createUserID = Value
        End Set
    End Property

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
                    '  CheckIdTextBoxG4(txtPayrollAdjustMethodID)
                    btnNext.Enabled = False
                    chkDisabled.Visible = False
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub LoadEdit()
        txtPayrollAdjustMethodID.Text = _payrollAdjustMethodID
        txtPayrollAdjustMethodName.Text = _payrollAdjustMethodName
        chkDisabled.Checked = L3Bool(_disabled)
        btnNext.Visible = False
        chkDisabled.Visible = True
        btnSave.Left = btnNext.Left
        ReadOnlyControl(txtPayrollAdjustMethodID)
        'ReadOnlyControl(txtPayrollAdjustMethodName)
    End Sub

    Private Sub D13F1151_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FormState = EnumFormState.FormView Then Exit Sub
        If Not _bSaved Then
            If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
        End If
    End Sub

    Private Sub D13F1151_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub
    Private Sub LoadCheckBoxAndRadio()
        optMethodRefer0.Checked = dtGrid.Select("MethodRefer=0").Length > 0
        optMethodRefer1.Checked = dtGrid.Select("MethodRefer=1").Length > 0
        chkIsReferent.Checked = dtGrid.Select("IsRefer=True").Length > 0 Or optMethodRefer1.Checked
        chkIsReferent_CheckedChanged(Nothing, Nothing)
    End Sub
    Private Sub D13F1151_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        ResetFooterGrid(tdbg)
        ResetFooterGrid(tdbgD)
        ResetFooterGrid(tdbgL)

        gbEnabledUseFind = False
        _bSaved = False
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBoxG4(txtPayrollAdjustMethodID)
        InputC1NumbericTDBGridDetail()
        UnicodeGridDataField(tdbg, UnicodeArrayCOL(), bUnicode)
        'CheckIdTDBGrid(tdbg, COL_AdjFormula, True)
        LoadTDBGrid()
        SetBackColorObligatory()
        SetResolutionForm(Me)
        iHeightGrid = tdbg.Height
        LoadCheckBoxAndRadio()
        If _FormState = EnumFormState.FormAdd Then
            optMethodRefer0.Checked = True
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function UnicodeArrayCOL() As Integer()
        If Not bUnicode Then Return Nothing
        Dim ArrCOL() As Integer = {COL_Description, COL_Short, COL_AdjFormulaDesc}
        Return ArrCOL
    End Function

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Cap_nhat_phuong_phap_dieu_chinh_luong_-_D13F1151") & UnicodeCaption(bUnicode) 'CËp nhËt ph§¥ng phÀp ¢iÒu chÙnh l§¥ng - D13F1151
        '================================================================ 
        lblPayrollAdjustMethodID.Text = rl3("Ma") 'Mã
        lblPayrollAdjustMethodName.Text = rl3("Ten") 'Tên
        lblReferent.Text = rl3("Bang_tham_chieu") 'Bảng tham chiếu
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        '================================================================ 
        tdbdValuesTo.Columns("Values").Caption = rl3("Ma") 'Mã
        tdbdValuesTo.Columns("ValuesName").Caption = rl3("Ten") 'Tên
        tdbdValuesFrom.Columns("Values").Caption = rl3("Ma") 'Mã
        tdbdValuesFrom.Columns("ValuesName").Caption = rl3("Ten") 'Tên
        tdbdEvaluationElementID.Columns("EvaluationElementID").Caption = rl3("Ma") 'Mã
        tdbdEvaluationElementID.Columns("EvaluationElementName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_Description).Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_Short).Caption = rl3("Ten_tat") 'Tên tắt
        tdbg.Columns(COL_IsDependSalObject).Caption = rl3("Phu_thuoc_doi_tuong_tinh_luong") 'Phụ thuộc đối tượng tính lương
        tdbg.Columns(COL_AdjFormula).Caption = rl3("Cong_thuc") 'Công thức
        tdbg.Columns(COL_IsRefer).Caption = rl3("Tham_chieu") 'Tham chiếu
        tdbg.Columns(COL_AdjFormulaDesc).Caption = rl3("Dien_giai_cong_thuc") 'Diễn giải công thức
        tdbg.Columns(COL_CalculateOrder).Caption = rL3("Thu_tu_tinh") 'Thứ tự tính

        '================================================================ 
        tdbgL.Columns(COLL_EvaluationElementID).Caption = rL3("Ma_chi_tieu_danh_gia") 'Mã chỉ tiêu đánh giá
        tdbgL.Columns(COLL_AppTypeID).Caption = rL3("Loai_danh_gia") 'Loại đánh giá
        tdbgL.Columns(COLL_ValuesFromName).Caption = rL3("Ket_qua_danh_gia") 'Kết quả đánh giá
        tdbgL.Columns(COLL_SalaryObjectID).Caption = rL3("Doi_tuong_tinh_luong") 'Đối tượng tính lương
        tdbgL.Columns(COLL_Notes).Caption = rL3("Ghi_chu") 'Ghi chú

        tdbgD.Columns(COLD_ReferentID).Caption = rl3("Ma_tham_chieu") 'Mã Tham chiếu
        tdbgD.Columns(COLD_EvaluationElementID).Caption = rl3("Ma_chi_tieu_danh_gia") 'Mã chỉ tiêu đánh giá
        tdbgD.Columns(COLD_AppTypeID).Caption = rl3("Loai_danh_gia") 'Loại đánh giá
        tdbgD.Columns(COLD_Operator).Caption = rl3("Toan_tu") 'Toán tử
        tdbgD.Columns(COLD_ValuesFromName).Caption = rl3("Gia_tri_(tu)") 'Giái trị (từ)
        tdbgD.Columns(COLD_ValuesToName).Caption = rl3("Gia_tri_(den)") 'Giá trị (đến)
        tdbgD.Columns(COLD_Method).Caption = rl3("Phuong_phap") 'Phương pháp
        tdbgD.Columns(COLD_Values).Caption = rL3("Gia_tri_") 'Giá trị

        '================================================================ 
        chkIsReferent.Text = rL3("Su_dung_bang_tham_chieu_tu_ket_qua_danh_gia") 'Sử dụng bảng tham chiếu từ kết quả đánh giá
        '================================================================ 
        optMethodRefer0.Text = rL3("Tinh_muc_huong_theo_PP_dieu_chinh_luong") 'Tính mức hưởng theo PP điều chỉnh lương
        optMethodRefer1.Text = rL3("Tinh_muc_huong_theo_doi_tuong_tinh_luong") 'Tính mức hưởng theo đối tượng tính lương
        '================================================================ 
        grpR.Text = rL3("Kieu_tham_chieu") 'Kiểu tham chiếu


    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String
        sSQL = "SELECT T00.Code, T00.Short, T00.ShortU, T00.Description, T00.DescriptionU, Isnull(T51.AdjCalOrder,0) As CalculateOrder, " & vbCrLf
        sSQL &= "Isnull(T51.AdjFormula, '') as AdjFormula, Isnull(T51.AdjFormulaDesc, '') as AdjFormulaDesc, Isnull(T51.AdjFormulaDescU, '') as AdjFormulaDescU, " & vbCrLf
        sSQL &= "Isnull(Cast(T51.IsDependSalObject as bit), cast(0 as bit)) as IsDependSalObject," & vbCrLf
        sSQL &= "ISNULL(CAST(T51.IsRefer AS BIT), CAST(0 AS BIT)) AS IsRefer, T51.ReferentID,T51.MethodRefer" & vbCrLf
        sSQL &= "FROM D13T9000 T00 WITH (NOLOCK) " & vbCrLf
        sSQL &= "LEFT JOIN D13T1150 T51  WITH (NOLOCK) ON	T00.Code = T51.AdjCode" & vbCrLf
        sSQL &= "AND T51.PayrollAdjustMethodID = " & SQLString(_payrollAdjustMethodID) & vbCrLf
        ' update 30/10/2013 id 57969 
        sSQL &= "WHERE (T00.Type IN ('SALBA','SALCE') OR (T00.TYPE = 'OLSC' AND (T00.Code = 'OLSC10' OR  T00.Code = 'OLSC20')))" & vbCrLf
        ' sSQL &= "WHERE T00.Type IN ('SALBA','SALCE')" & vbCrLf
        sSQL &= "AND T00.Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY T00.Code"
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, bUnicode)
        FooterTotalGrid(tdbg, COL_Description)
        If dtGridDetail IsNot Nothing Then dtGridDetail.Clear()
        LoadTDBGridDetail()
        If dtGridDetailL IsNot Nothing Then dtGridDetailL.Clear()
        LoadTDBGridDetailL()
    End Sub

    Private Sub LoadTDBGridDetail()
        Dim sSQL As String = ""
        If dtGridDetail Is Nothing Then
            sSQL = SQLStoreD13P1152(0)
            dtGridDetail = ReturnDataTable(sSQL)
        End If
        dtGridDetail.DefaultView.RowFilter = "ReferentID=" & SQLString(tdbg.Columns(COL_ReferentID).Text)
        LoadDataSource(tdbgD, dtGridDetail, gbUnicode)
        FooterTotalGrid(tdbgD, COLD_EvaluationElementID)
        tdbgD.Columns(COLD_ReferentID).DefaultValue = tdbg.Columns(COL_ReferentID).Text
        tdbgD.Columns(COLD_Values).DefaultValue = "0"
        tdbgD.AllowUpdate = L3Bool(tdbg.Columns(COL_IsRefer).Text)
        For i As Integer = 0 To tdbgD.Columns.Count - 1
            If tdbgD.Columns(i).DropDown IsNot Nothing Then
                tdbgD.Splits(0).DisplayColumns(i).Button = tdbgD.AllowUpdate
                tdbgD.UpdateData()
            End If
        Next
    End Sub


    Private Sub LoadTDBGridDetailL()
        Dim sSQL As String = ""
        If dtGridDetailL Is Nothing Then
            sSQL = SQLStoreD13P1152(1)
            dtGridDetailL = ReturnDataTable(sSQL)
        End If
        LoadDataSource(tdbgL, dtGridDetailL, gbUnicode)
        If tdbgL.RowCount > 0 Then
            LoadTDBDValuesFromL((tdbgL(0, COLL_EvaluationElementID).ToString))
        End If
        FooterTotalGrid(tdbgL, COLL_EvaluationElementID)
    End Sub

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLStoreD13P1152
    ''# Created User: Lê Anh Vũ
    ''# Created Date: 29/10/2014 02:16:13
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD13P1152() As String
    '    Dim sSQL As String = ""
    '    sSQL &= ("-- Do nguon cho luoi 3" & vbCrlf)
    '    sSQL &= "Exec D13P1152 "
    '    sSQL &= SQLString(XXXXX) & COMMA 'PayrollAdjustMethodID, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString(XXXXX) & COMMA 'FormID, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
    '    sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
    '    sSQL &= SQLNumber(XXXXX) 'Mode, tinyint, NOT NULL
    '    Return sSQL
    'End Function



    Dim dtAppTypeID, dtValuesFromTo, dtAvaluationE As DataTable

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdEvaluationElementID
        ' update 31/10/2013 id 57491
        sSQL = "-- Do nguon DD Ma chi tieu danh gia" & vbCrLf
        sSQL &= "Select DISTINCT T3.EvaluationElementID, T3.EvaluationElementName" & UnicodeJoin(gbUnicode) & " as EvaluationElementName" & vbCrLf
        sSQL &= "FROM D39T1020 AS T1 WITH (NOLOCK)" & vbCrLf
        sSQL &= "LEFT JOIN D39T1021 T2 WITH (NOLOCK)" & vbCrLf
        sSQL &= "     ON  T2.TransTypeID = T1.TransTypeID" & vbCrLf
        sSQL &= "LEFT JOIN D39T1000 T3 WITH (NOLOCK)" & vbCrLf
        sSQL &= "     ON  T2.EvaluationElementID = T3.EvaluationElementID" & vbCrLf
        sSQL &= "WHERE T1.[Disabled] = 0 "
        sSQL &= "	AND T1.IsSalAdjust = 1 "
        sSQL &= "	AND T3.[Disabled] = 0" & vbCrLf
        sSQL &= "ORDER BY T3.EvaluationElementID"
        dtAvaluationE = ReturnDataTable(sSQL)
        LoadDataSource(tdbdEvaluationElementID, dtAvaluationE.DefaultView.ToTable(), gbUnicode)
        LoadDataSource(tdbdEvaluationElementIDL, dtAvaluationE.DefaultView.ToTable(), gbUnicode)

        'Load tdbdAppTypeID
        sSQL = "-- Do nguon DD Loai danh gia" & vbCrLf
        sSQL &= "Select OrderNo AS AppTypeID, AppTypeShortName" & UnicodeJoin(gbUnicode) & " as AppTypeShortName, EvaluationElementID "
        sSQL &= " From D39T1005 WITH(NOLOCK) "
        sSQL &= " WHERE  	IsUsed = 1"
        sSQL &= " ORDER BY EvaluationElementID, OrderNo"
        dtAppTypeID = ReturnDataTable(sSQL)
        LoadTDBDAppTypeID("%")

        LoadTDBDAppTypeIDL("%")


        'Load tdbdOperator
        sSQL = "-- Do nguon DD toan tu" & vbCrLf
        sSQL &= "Select '=' AS MethodID, N" & SQLString(IIf(geLanguage = EnumLanguage.Vietnamese, IIf(gbUnicode, "Bằng", "Baèng"), "Add").ToString) & " as MethodName"
        LoadDataSource(tdbdOperator, sSQL, gbUnicode)

        'Load tdbdValuesFrom
        sSQL = "-- Do nguon DD Gia tri tu-den" & vbCrLf
        sSQL &= "Select EvaluationLevelID AS [Values], EvaluationLevelName" & UnicodeJoin(gbUnicode) & " as ValuesName, EvaluationElementID "
        sSQL &= " From D39T1001 WITH(NOLOCK) "
        sSQL &= " ORDER BY EvaluationElementID, [Values]"
        dtValuesFromTo = ReturnDataTable(sSQL)
        LoadTDBDValuesFrom("%")
        LoadTDBDValuesFromL("%")

        LoadTDBDValuesTo("%")

        'Load tdbdMethodID
        sSQL = "-- Do nguon DD Phuong phap" & vbCrLf
        sSQL &= "Select 1 AS Method, N" & SQLString(IIf(geLanguage = EnumLanguage.Vietnamese, IIf(gbUnicode, "Giá trị", "Giaù trò"), "Value").ToString) & " as MethodName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "Select 2 AS Method, N" & SQLString(IIf(geLanguage = EnumLanguage.Vietnamese, IIf(gbUnicode, "Tỷ lệ", "Tyû leä"), "Rate").ToString) & " as MethodName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "Select 3 AS Method, N" & SQLString(IIf(geLanguage = EnumLanguage.Vietnamese, IIf(gbUnicode, "Tăng/Giảm", "Taêng/Giaûm"), "Add/Subtract").ToString) & " as MethodName" & vbCrLf
        LoadDataSource(tdbdMethodID, sSQL, gbUnicode)

        'Load tdbdSalaryObjectID
        sSQL = "-- Do nguon DD doi tuong tinh luong" & vbCrLf
        sSQL &= " SELECT 		SalaryObjectID, 	SalaryObjectName" & UnicodeJoin(gbUnicode) & " As SalaryObjectName"
        sSQL &= " FROM		D13T1020 WITH(NOLOCK)  WHERE 		Disabled = 0 "
        sSQL &= " ORDER BY 	SalaryObjectID"
        LoadDataSource(tdbdSalaryObjectID, sSQL, gbUnicode)

    End Sub

    Private Sub LoadTDBDAppTypeID(ByVal sEvaluationElementID As String)
        If sEvaluationElementID = "%" Then
            LoadDataSource(tdbdAppTypeID, dtAppTypeID.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbdAppTypeID, ReturnTableFilter(dtAppTypeID, "EvaluationElementID=" & SQLString(sEvaluationElementID), True), gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBDAppTypeIDL(ByVal sEvaluationElementID As String)
        If sEvaluationElementID = "%" Then
            LoadDataSource(tdbdAppTypeIDL, dtAppTypeID.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbdAppTypeIDL, ReturnTableFilter(dtAppTypeID, "EvaluationElementID=" & SQLString(sEvaluationElementID), True), gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBDValuesFrom(ByVal sEvaluationElementID As String)
        If sEvaluationElementID = "%" Then
            LoadDataSource(tdbdValuesFrom, dtValuesFromTo.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbdValuesFrom, ReturnTableFilter(dtValuesFromTo, "EvaluationElementID=" & SQLString(sEvaluationElementID), True), gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBDValuesFromL(ByVal sEvaluationElementID As String)
        If sEvaluationElementID = "%" Then
            LoadDataSource(tdbdValuesFromL, dtValuesFromTo.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbdValuesFromL, ReturnTableFilter(dtValuesFromTo, "EvaluationElementID=" & SQLString(sEvaluationElementID), True), gbUnicode)
        End If

    End Sub


    Private Sub LoadTDBDValuesTo(ByVal sEvaluationElementID As String)
        If sEvaluationElementID = "%" Then
            LoadDataSource(tdbdValuesTo, dtValuesFromTo, gbUnicode)
        Else
            LoadDataSource(tdbdValuesTo, ReturnTableFilter(dtValuesFromTo, "EvaluationElementID=" & SQLString(sEvaluationElementID), True), gbUnicode)
        End If
    End Sub

    Dim sGetDate As String = ""
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        dtGrid.GetChanges()
        dtGridDetail.AcceptChanges()
        If Not AllowSave() Then Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False
        sGetDate = ReturnScalar("select GetDate()")
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD13T1150s().ToString)
                sSQL.AppendLine(SQLDeleteD13T1152)
                If chkIsReferent.Checked And optMethodRefer1.Checked Then
                    sSQL.AppendLine(SQLInsertD13T1152Gird3().ToString())
                Else
                    sSQL.AppendLine(SQLInsertD13T1152s.ToString)
                End If
            Case EnumFormState.FormEdit
                sSQL.Append(SQLDeleteD13T1150())
                sSQL.AppendLine(SQLInsertD13T1150s().ToString)
                sSQL.AppendLine(SQLDeleteD13T1152)
                If chkIsReferent.Checked And optMethodRefer1.Checked Then
                    sSQL.AppendLine(SQLInsertD13T1152Gird3().ToString())
                Else
                    sSQL.AppendLine(SQLInsertD13T1152s.ToString)
                End If
        End Select
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    PayrollAdjustMethodID = txtPayrollAdjustMethodID.Text
                    btnNext.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If txtPayrollAdjustMethodID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtPayrollAdjustMethodID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D13T1150", "PayrollAdjustMethodID", txtPayrollAdjustMethodID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtPayrollAdjustMethodID.Focus()
                Return False
            End If
        End If
        If txtPayrollAdjustMethodName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten"))
            txtPayrollAdjustMethodName.Focus()
            Return False
        End If

        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_IsDependSalObject).ToString = "False" Then
                If tdbg(i, COL_CalculateOrder).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Thu_tu_tinh"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_CalculateOrder
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If CDec(tdbg(i, COL_CalculateOrder).ToString) < 0 Then
                    D99C0008.MsgNotYetEnter(rl3("Thu_tu_tinh"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_CalculateOrder
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If
        Next

        ' Kiễm tra Nếu dữ liệu detail đ ãtồn tại nhưng Uncheck tại tdbg thì báo
        Dim dr() As DataRow = dtGrid.Select("IsRefer=False")
        For i As Integer = 0 To dr.Length - 1
            If dtGridDetail.Select("ReferentID=" & SQLString(dr(i).Item("ReferentID"))).Length > 0 Then
                If D99C0008.MsgAsk("Dữ liệu tham chiếu chi tiết đã tồn tại." & " " & "Bạn có muốn xóa hay không?") = Windows.Forms.DialogResult.No Then
                    tdbg.Focus()
                    tdbg.SplitIndex = 0
                    tdbg.Col = COL_IsRefer
                    tdbg.Row = dtGrid.Rows.IndexOf(dr(i))
                    Return False
                End If
            End If
        Next
        If Not optMethodRefer1.Checked Then
            dr = dtGrid.Select("IsRefer=True")
            For i As Integer = 0 To dr.Length - 1
                'i: chỉ số lưới master
                'j: 
                'k: chỉ số lưới Detail theo từng ReferentID của lưới master
                Dim drD() As DataRow = dtGridDetail.Select("ReferentID=" & SQLString(dr(i).Item("ReferentID")))
                For j As Integer = 0 To drD.Length - 1
                    If drD(j).Item("EvaluationElementID").ToString = "" Then
                        tdbg.Row = dtGrid.Rows.IndexOf(dr(i)) ' Focus lai lưới master de load detail

                        D99C0008.MsgNotYetEnter(rL3("Ma_chi_tieu_danh_gia"))
                        tdbgD.Focus()
                        tdbgD.SplitIndex = SPLIT0
                        tdbgD.Col = COLD_EvaluationElementID
                        tdbgD.Row = j ' dtGridDetail.DefaultView.ToTable.Rows.IndexOf(drD(j))
                        Return False
                    End If
                    If drD(j).Item("AppTypeID").ToString = "" Then
                        tdbg.Row = dtGrid.Rows.IndexOf(dr(i)) ' Focus lai lưới master de load detail

                        D99C0008.MsgNotYetEnter(rL3("Loai_danh_gia"))
                        tdbgD.Focus()
                        tdbgD.SplitIndex = SPLIT0
                        tdbgD.Col = COLD_AppTypeID
                        tdbgD.Row = j
                        Return False
                    End If
                    If drD(j).Item("Operator").ToString = "" Then
                        tdbg.Row = dtGrid.Rows.IndexOf(dr(i)) ' Focus lai lưới master de load detail

                        D99C0008.MsgNotYetEnter(rL3("Toan_tu"))
                        tdbgD.Focus()
                        tdbgD.SplitIndex = SPLIT0
                        tdbgD.Col = COLD_Operator
                        tdbgD.Row = dtGridDetail.DefaultView.ToTable.Rows.IndexOf(drD(j))
                        Return False
                    End If
                    If drD(j).Item("ValuesFrom").ToString = "" Then
                        tdbg.Row = dtGrid.Rows.IndexOf(dr(i)) ' Focus lai lưới master de load detail

                        D99C0008.MsgNotYetEnter(rL3("Gia_tri_(tu)"))
                        tdbgD.Focus()
                        tdbgD.SplitIndex = SPLIT0
                        tdbgD.Col = COLD_ValuesFromName
                        tdbgD.Row = j
                        Return False
                    End If
                    If drD(j).Item("ValuesTo").ToString = "" Then
                        tdbg.Row = dtGrid.Rows.IndexOf(dr(i)) ' Focus lai lưới master de load detail

                        D99C0008.MsgNotYetEnter(rL3("Gia_tri_(den)"))
                        tdbgD.Focus()
                        tdbgD.SplitIndex = SPLIT0
                        tdbgD.Col = COLD_ValuesToName
                        tdbgD.Row = j
                        Return False
                    End If
                    If drD(j).Item("Method").ToString = "" Then
                        tdbg.Row = dtGrid.Rows.IndexOf(dr(i)) ' Focus lai lưới master de load detail

                        D99C0008.MsgNotYetEnter(rL3("Phuong_phap"))
                        tdbgD.Focus()
                        tdbgD.SplitIndex = SPLIT0
                        tdbgD.Col = COLD_Method
                        tdbgD.Row = j
                        Return False
                    End If

                    For k As Integer = j + 1 To drD.Length - 1
                        If drD(j).Item("EvaluationElementID").ToString = drD(k).Item("EvaluationElementID").ToString AndAlso drD(j).Item("AppTypeID").ToString = drD(k).Item("AppTypeID").ToString AndAlso drD(j).Item("Operator").ToString = drD(k).Item("Operator").ToString AndAlso drD(j).Item("ValuesFrom").ToString = drD(k).Item("ValuesFrom").ToString Then
                            D99C0008.MsgDuplicatePKey() ' Mã này đã tồn tại.
                            tdbg.Row = dtGrid.Rows.IndexOf(dr(i)) ' Focus lai lưới master de load detail

                            tdbgD.Focus()
                            tdbgD.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                            tdbgD.Col = COLD_EvaluationElementID 'Tùy theo yêu cầu mỗi Form
                            tdbgD.Row = k 'Tùy theo yêu cầu mỗi Form
                            Return False
                        End If
                    Next
                Next
            Next
        End If
        
        'TH lưu lưới 3
        If chkIsReferent.Checked AndAlso optMethodRefer1.Checked Then
            For i As Integer = 0 To tdbgL.RowCount - 1
                'For k As Integer = COLL_EvaluationElementID To COLL_SalaryObjectID
                '    If tdbgL(i, k).ToString() = "" Then
                '        D99C0008.MsgNotYetChoose(tdbgL.Columns(k).Caption)
                '        tdbgL.Focus()
                '        tdbgL.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                '        tdbgL.Col = k
                '        tdbgL.Row = i
                '        Return False
                '    End If
                'Next
                If tdbgL(i, COLL_EvaluationElementID).ToString() = "" Then
                    D99C0008.MsgNotYetChoose(tdbgL.Columns(COLL_EvaluationElementID).Caption)
                    tdbgL.Focus()
                    tdbgL.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                    tdbgL.Col = COLL_EvaluationElementID
                    tdbgL.Row = i
                    Return False
                End If
                If tdbgL(i, COLL_SalaryObjectID).ToString() = "" Then
                    D99C0008.MsgNotYetChoose(tdbgL.Columns(COLL_SalaryObjectID).Caption)
                    tdbgL.Focus()
                    tdbgL.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                    tdbgL.Col = COLL_SalaryObjectID
                    tdbgL.Row = i
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        txtPayrollAdjustMethodName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtPayrollAdjustMethodID.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Short).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_EvaluationElementID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_AppTypeID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_Operator).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_ValuesFromName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_ValuesToName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgD.Splits(SPLIT0).DisplayColumns(COLD_Method).Style.BackColor = COLOR_BACKCOLOROBLIGATORY

        tdbgL.Splits(SPLIT0).DisplayColumns(COLL_EvaluationElementID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgL.Splits(SPLIT0).DisplayColumns(COLL_SalaryObjectID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY

    End Sub

    Private Sub InputC1NumbericTDBGridDetail()
        Dim arrCol() As FormatColumn = Nothing 'Mảng lưu trữ định dạng của cột số
        'Thêm cột số có kiểu dữ liệu là Decimal
        AddDecimalColumns(arrCol, tdbgD.Columns(COLD_Values).DataField, "N2", 28, 8, True) 'Cột có DataType là Decimal(28,8), không cho nhập số âm

        'Định dạng các cột số trên lưới
        InputNumber(tdbgD, arrCol)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        txtPayrollAdjustMethodID.Text = ""
        txtPayrollAdjustMethodName.Text = ""
        chkDisabled.Checked = False
        _payrollAdjustMethodID = ""
        _payrollAdjustMethodName = ""
        btnNext.Enabled = False
        btnSave.Enabled = True
        LoadTDBGrid()
        txtPayrollAdjustMethodID.Focus()
    End Sub
    Private Sub EnableGird()
        If chkIsReferent.Checked Then
            tdbg.Height = iHeightGrid - Panel1.Height - 10
            If optMethodRefer0.Checked Then
                Panel1.Visible = True
                tdbgD.Visible = True
                tdbg.Visible = True
                tdbgL.Visible = False
                LoadTDBGridDetail()
            Else
                Panel1.Visible = False
                tdbgD.Visible = False
                tdbg.Visible = False
                tdbgL.Visible = True
                LoadTDBGridDetailL()
            End If
        Else
            tdbg.Visible = True
            tdbg.Height = iHeightGrid
            Panel1.Visible = False
            tdbgL.Visible = False
        End If
    End Sub
    Private Sub chkIsReferent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsReferent.CheckedChanged
        EnableGird()
        grpR.Visible = chkIsReferent.Checked
    End Sub

#Region "tdbg master event"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        If L3Bool(tdbg.Columns(COL_IsRefer).Text) And tdbg.Columns(COL_ReferentID).Text = "" Then
            tdbg.Columns(COL_ReferentID).Value = L3Int(dtGrid.Compute("Max(ReferentID)", "")) + 1
        End If
        If chkIsReferent.Checked Then LoadTDBGridDetail()
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_AdjFormula
                e.Cancel = L3IsFormula(tdbg, e.ColIndex)
        End Select
    End Sub


    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        If e.Row >= 0 And e.ColIndex = COL_AdjFormula Then
            If gbUnicode Then
                e.CellTip = rL3("Nhan_F6_chon_cong_thucU")
            Else
                e.CellTip = rL3("Nhan_F6_chon_cong_thuc")
            End If
        Else
            e.CellTip = ""
        End If
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_IsDependSalObject
                L3HeadClick(e.ColIndex)
                tdbg.Col = e.ColIndex
        End Select
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck 24/11/2008
    Private Sub L3HeadClick(ByVal iCol As Integer)
        Dim bSelected As Boolean = Not bSelect
        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, iCol) = bSelected
        Next
        bSelect = bSelected
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.Columns(COL_IsDependSalObject).Text = "True" Then Exit Sub
        Select Case tdbg.Col
            Case COL_AdjFormula
                If e.KeyCode = Keys.F6 Then
                    Dim sFormula As String = ""
                    Dim arrPro() As StructureProperties = Nothing
                    SetProperties(arrPro, "Mode", "2")
                    Dim frm As Form = CallFormShowDialog("D21D0140", "D21F0005", arrPro)
                    sFormula = GetProperties(frm, "sFormula_D21F0005").ToString
                    tdbg.Columns(COL_AdjFormula).Text = tdbg.Columns(COL_AdjFormula).Text & sFormula
                    tdbg.UpdateData()
                End If
            Case COL_IsDependSalObject
                If e.Control And e.KeyCode = Keys.S Then
                    L3HeadClick(tdbg.Col)
                End If
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_CalculateOrder
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_IsRefer
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_AdjFormula
                e.KeyChar = UCase(e.KeyChar)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.Row = e.LastRow Then Exit Sub

        If tdbg.Columns(COL_IsDependSalObject).Text = "True" Then
            tdbg.Splits(0).DisplayColumns(COL_AdjFormula).Locked = True
            tdbg.Splits(0).DisplayColumns(COL_AdjFormulaDesc).Locked = True
            tdbg.Splits(0).DisplayColumns(COL_CalculateOrder).Locked = True
        Else
            tdbg.Splits(0).DisplayColumns(COL_AdjFormula).Locked = False
            tdbg.Splits(0).DisplayColumns(COL_AdjFormulaDesc).Locked = False
            tdbg.Splits(0).DisplayColumns(COL_CalculateOrder).Locked = False
        End If
        If chkIsReferent.Checked Then LoadTDBGridDetail()
    End Sub
#End Region

#Region "tdbg Detail event"

    Private Sub tdbgD_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgD.ComboSelect
        tdbgD.UpdateData()
    End Sub


    Dim bNotInList As Boolean = False
    Private Sub tdbgD_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgD.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COLD_Values
                If Not L3IsNumeric(tdbgD.Columns(e.ColIndex).Text, EnumDataType.Number) Then e.Cancel = True
            Case COLD_EvaluationElementID, COLD_ValuesFromName, COLD_ValuesToName
                If tdbgD.Columns(e.ColIndex).Text <> tdbgD.Columns(e.ColIndex).DropDown.Columns(tdbgD.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbgD.Columns(e.ColIndex).Text = ""
                End If
                If e.ColIndex = COLD_EvaluationElementID Then
                    If tdbgD.RowCount < 2 Then
                        Exit Sub
                    End If
                    Dim sEvaluationElementID As String = ""
                    sEvaluationElementID = tdbgD.Columns(e.ColIndex).DropDown.Columns(tdbgD.Columns(e.ColIndex).DropDown.DisplayMember).Text
                    For i As Integer = 0 To tdbgD.RowCount - 1
                        If tdbgD(i, COLD_EvaluationElementID).ToString() <> "" AndAlso sEvaluationElementID <> tdbgD(i, COLD_EvaluationElementID).ToString() AndAlso i <> tdbgD.Row Then
                            D99C0008.MsgL3(rL3("Ban_chi_duoc_chon_1_chi_tieu_danh_gia"))
                            tdbgD.Focus()
                            tdbgD.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                            tdbgD.Col = COLL_EvaluationElementID
                            e.Cancel = True
                            Exit Sub
                        End If
                    Next

                    'If dtGridDetail.DefaultView.ToTable(True, tdbgD.Columns(COLD_EvaluationElementID).DataField).Rows.Count > 1 Then
                    '    tdbgD.Focus()
                    '    tdbgD.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                    '    tdbgD.Col = COLL_EvaluationElementID
                    'End If
                End If
            Case COLD_AppTypeID, COLD_Operator, COLD_Method
                If tdbgD.Columns(e.ColIndex).Text <> tdbgD.Columns(e.ColIndex).DropDown.Columns(tdbgD.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbgD.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If

                If e.ColIndex = COLD_AppTypeID Then
                    If tdbgD.RowCount < 2 Then
                        Exit Sub
                    End If
                    Dim sCOLD_AppTypeID As String = ""
                    sCOLD_AppTypeID = tdbgD.Columns(e.ColIndex).DropDown.Columns(tdbgD.Columns(e.ColIndex).DropDown.ValueMember).Text
                    For i As Integer = 0 To tdbgD.RowCount - 1
                        If tdbgD(i, COLD_AppTypeID).ToString() <> "" AndAlso sCOLD_AppTypeID <> tdbgD(i, COLD_AppTypeID).ToString() AndAlso i <> tdbgD.Row Then
                            D99C0008.MsgL3(rL3("Ban_chi_duoc_chon_1_loai_danh_gia"))
                            tdbgD.Focus()
                            tdbgD.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                            tdbgD.Col = COLD_AppTypeID
                            e.Cancel = True
                            Exit Sub
                        End If
                    Next

                    'If dtGridDetail.DefaultView.ToTable(True, tdbgD.Columns(COLD_EvaluationElementID).DataField).Rows.Count > 1 Then
                    '    tdbgD.Focus()
                    '    tdbgD.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                    '    tdbgD.Col = COLL_EvaluationElementID
                    'End If
                End If

        End Select
    End Sub

    Private Sub tdbgD_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgD.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COLD_EvaluationElementID
                'Gắn rỗng các cột liên quan
                tdbgD.Columns(COLD_AppTypeID).Value = ""
                tdbgD.Columns(COLD_ValuesFrom).Value = ""
                tdbgD.Columns(COLD_ValuesFromName).Value = ""
                tdbgD.Columns(COLD_ValuesTo).Value = ""
                tdbgD.Columns(COLD_ValuesToName).Value = ""
            Case COLD_AppTypeID
                If tdbgD.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbgD.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    Exit Select
                End If
            Case COLD_Operator
                If tdbgD.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbgD.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    Exit Select
                End If
                ' Nếu là = thì sét Đến = Từ
                If tdbgD.Columns(COLD_Operator).Value.ToString = "=" Then
                    tdbgD.Columns(COLD_ValuesTo).Text = tdbgD.Columns(COLD_ValuesFrom).Text
                    tdbgD.Columns(COLD_ValuesToName).Text = tdbgD.Columns(COLD_ValuesFromName).Text
                End If
            Case COLD_ValuesFromName
                If tdbgD.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbgD.Columns(COLD_ValuesFrom).Text = ""
                Else
                    tdbgD.Columns(COLD_ValuesFrom).Text = tdbdValuesFrom.Columns("Values").Text
                End If
                ' Nếu là = thì sét Đến = Từ
                If tdbgD.Columns(COLD_Operator).Value.ToString = "=" Then
                    tdbgD.Columns(COLD_ValuesTo).Text = tdbgD.Columns(COLD_ValuesFrom).Text
                    tdbgD.Columns(COLD_ValuesToName).Text = tdbgD.Columns(COLD_ValuesFromName).Text
                End If
            Case COLD_ValuesToName
                If tdbgD.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbgD.Columns(COLD_ValuesTo).Text = ""
                    Exit Select
                End If
                tdbgD.Columns(COLD_ValuesTo).Text = tdbdValuesTo.Columns("Values").Text
            Case COLD_Method
                If tdbgD.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbgD.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    Exit Select
                End If
        End Select
        bNotInList = False
        FooterTotalGrid(tdbgD, COLD_EvaluationElementID)
    End Sub

    Private Sub tdbgD_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgD.RowColChange
        Select Case tdbgD.Col
            Case COLD_AppTypeID
                LoadTDBDAppTypeID(tdbgD(tdbgD.Row, COLD_EvaluationElementID).ToString)
            Case COLD_ValuesFromName
                LoadTDBDValuesFrom(tdbgD(tdbgD.Row, COLD_EvaluationElementID).ToString)
            Case COLD_ValuesToName
                LoadTDBDValuesTo(tdbgD(tdbgD.Row, COLD_EvaluationElementID).ToString)
        End Select
    End Sub


    Private Sub tdbgL_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgL.RowColChange
        Select Case tdbgL.Col
            Case COLL_AppTypeID
                LoadTDBDAppTypeIDL(tdbgL(tdbgL.Row, COLL_EvaluationElementID).ToString)
            Case COLL_ValuesFromName
                LoadTDBDValuesFromL(tdbgL(tdbgL.Row, COLL_EvaluationElementID).ToString)
        End Select
    End Sub

    Private Sub tdbgL_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgL.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex

            Case COLL_EvaluationElementID
                If tdbgL.Columns(e.ColIndex).Text <> tdbgL.Columns(e.ColIndex).DropDown.Columns(tdbgL.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbgL.Columns(e.ColIndex).Text = ""
                End If
            Case COLL_AppTypeID, COLL_ValuesFrom, COLL_SalaryObjectID
                If tdbgL.Columns(e.ColIndex).Text <> tdbgL.Columns(e.ColIndex).DropDown.Columns(tdbgL.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbgL.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
        End Select
    End Sub


    Private Sub tdbgL_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgL.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COLL_EvaluationElementID
                'Gắn rỗng các cột liên quan
                tdbgL.Columns(COLL_AppTypeID).Value = ""
                tdbgL.Columns(COLL_ValuesFrom).Value = ""
            Case COLL_AppTypeID
                If tdbgL.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbgL.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    Exit Select
                End If
            Case COLL_ValuesFromName
                If tdbgL.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbgL.Columns(COLL_ValuesFrom).Text = ""
                Else
                    tdbgL.Columns(COLL_ValuesFrom).Text = tdbdValuesFromL.Columns("Values").Text
                End If
            Case COLL_SalaryObjectID
                If tdbgL.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbgL.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    Exit Select
                End If
        End Select
        bNotInList = False
        FooterTotalGrid(tdbgL, COLL_EvaluationElementID)
    End Sub


    'Private Sub tdbgL_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgL.ComboSelect
    '    tdbgL.UpdateData()
    'End Sub

#End Region
#Region "SQL"
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1150s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 15/07/2010 10:19:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1150s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D13T1150(")
            sSQL.Append("PayrollAdjustMethodID, PayrollAdjustMethodName, PayrollAdjustMethodNameU, AdjCode, IsDependSalObject, AdjCalOrder, ")
            sSQL.Append("AdjFormula, AdjFormulaDesc, AdjFormulaDescU, Disabled, CreateUserID, LastModifyUserID, ")
            sSQL.Append("CreateDate, LastModifyDate, IsRefer, ReferentID,MethodRefer")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtPayrollAdjustMethodID.Text) & COMMA) 'PayrollAdjustMethodID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(txtPayrollAdjustMethodName, False) & COMMA) 'PayrollAdjustMethodName, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(txtPayrollAdjustMethodName, True) & COMMA) 'PayrollAdjustMethodName, varchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Code).ToString) & COMMA) 'AdjCode, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(IIf(tdbg(i, COL_IsDependSalObject).ToString = "True", 1, 0)) & COMMA) 'IsDependSalObject, tinyint, NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_CalculateOrder).ToString) & COMMA) 'AdjCalOrder, int, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_AdjFormula).ToString) & COMMA) 'AdjFormula, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_AdjFormulaDesc), bUnicode, False) & COMMA) 'AdjFormulaDesc, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_AdjFormulaDesc), bUnicode, True) & COMMA) 'AdjFormulaDesc, varchar[500], NOT NULL
            sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
            sSQL.Append(SQLString(_createUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append(IIf(_createDate = "", SQLDateTimeSave(sGetDate), SQLDateTimeSave(_createDate)).ToString & COMMA) 'CreateDate, datetime, NOT NULL
            sSQL.Append(SQLDateTimeSave(sGetDate) & COMMA) 'LastModifyDate, datetime, NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_IsRefer)) & COMMA)
            sSQL.Append(SQLString(tdbg(i, COL_ReferentID)) & COMMA)
            sSQL.Append(SQLNumber(optMethodRefer1.Checked And chkIsReferent.Checked))
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1152
    '# Created User: Lê Anh Vũ
    '# Created Date: 29/10/2014 04:13:15
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1152Gird3() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbgL.RowCount - 1
            sSQL.Append("-- Luu chi tiet cho luoi 3" & vbCrLf)
            sSQL.Append("Insert Into D13T1152(")
            sSQL.Append("PayrollAdjustMethodID, ReferentID, EvaluationElementID, AppTypeID, Operator, ")
            sSQL.Append("ValuesFrom, ValuesTo, Method, SalaryObjectID, NotesU")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(txtPayrollAdjustMethodID.Text) & COMMA) 'PayrollAdjustMethodID, varchar[20], NOT NULL
            sSQL.Append(SQLString(i + 1) & COMMA) 'ReferentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgL(i, COLL_EvaluationElementID).ToString()) & COMMA) 'EvaluationElementID, varchar[50], NOT NULL
            sSQL.Append(SQLNumber(tdbgL(i, COLL_AppTypeID).ToString()) & COMMA) 'AppTypeID, tinyint, NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'Operator, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbgL(i, COLL_ValuesFrom).ToString()) & COMMA) 'ValuesFrom, varchar[20], NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'ValuesTo, varchar[20], NOT NULL
            sSQL.Append(SQLNumber("") & COMMA) 'Method, tinyint, NOT NULL
            sSQL.Append(SQLString(tdbgL(i, COLL_SalaryObjectID).ToString()) & COMMA) 'SalaryObjectID, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgL(i, COLL_Notes).ToString(), gbUnicode, True)) 'NotesU, nvarchar[1000], NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function



    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLInsertD13T1150
    ''# Created User: Lê Anh Vũ
    ''# Created Date: 29/10/2014 03:53:32
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLInsertD13T1150() As StringBuilder
    '    Dim sSQL As New StringBuilder
    '    sSQL.Append("-- A" & vbCrlf)
    '    sSQL.Append("Insert Into D13T1150(")
    '    sSQL.Append("PayrollAdjustMethodID, PayrollAdjustMethodName, Disabled, CreateUserID, LastModifyUserID, ")
    '    sSQL.Append("CreateDate, LastModifyDate, PayrollAdjustMethodNameU, IsRefer, MethodRefer")
    '    sSQL.Append(") Values(" & vbCrlf)
    '    sSQL.Append(SQLString(XXXXX) & COMMA) 'PayrollAdjustMethodID, varchar[20], NULL
    '    sSQL.Append(SQLStringUnicode(txtPayrollAdjustMethodName, False) & COMMA) 'PayrollAdjustMethodName, varchar[500], NOT NULL
    '    sSQL.Append(SQLNumber(XXXXX) & COMMA) 'Disabled, tinyint, NOT NULL
    '    sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
    '    sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
    '    sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
    '    sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
    '    sSQL.Append(SQLStringUnicode(txtPayrollAdjustMethodName, True) & COMMA) 'PayrollAdjustMethodNameU, nvarchar[500], NOT NULL
    '    sSQL.Append(SQLNumber(XXXXX) & COMMA) 'IsRefer, tinyint, NOT NULL
    '    sSQL.Append(SQLNumber(XXXXX) & COMMA) 'MethodRefer, tinyint, NOT NULL
    '    sSQL.Append(")")

    '    Return sSQL
    'End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1150
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 15/07/2010 10:38:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1150() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T1150"
        sSQL &= " Where "
        sSQL &= "PayrollAdjustMethodID = " & SQLString(txtPayrollAdjustMethodID.Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1152
    '# Created User: Hoàng Nhân
    '# Created Date: 25/10/2013 11:19:18
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1152(ByVal imode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon luoi detail" & vbCrLf)
        sSQL &= "Exec D13P1152 "
        sSQL &= SQLString(_payrollAdjustMethodID) & COMMA 'PayrollAdjustMethodID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F1151") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(imode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1152
    '# Created User: Hoàng Nhân
    '# Created Date: 25/10/2013 01:20:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1152() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa detail" & vbCrLf)
        sSQL &= "Delete From D13T1152"
        sSQL &= " Where "
        sSQL &= "PayrollAdjustMethodID = " & SQLString(txtPayrollAdjustMethodID.Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1152s
    '# Created User: Hoàng Nhân
    '# Created Date: 25/10/2013 01:21:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1152s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim dr() As DataRow = dtGrid.Select("IsRefer=True")
        '  If dr.Length > 0 Then sSQL.Append("-- Insert detail" & vbCrLf)
        For i As Integer = 0 To dr.Length - 1
            Dim drDetail() As DataRow = dtGridDetail.Select("ReferentID=" & SQLString(dr(i).Item("ReferentID")))
            For j As Integer = 0 To drDetail.Length - 1
                sSQL.Append("Insert Into D13T1152(")
                sSQL.Append("PayrollAdjustMethodID, ReferentID, EvaluationElementID, AppTypeID, Operator, ")
                sSQL.Append("ValuesFrom, ValuesTo, Method, [Values]")
                sSQL.Append(") Values(" & vbCrLf)
                sSQL.Append(SQLString(txtPayrollAdjustMethodID.Text) & COMMA) 'PayrollAdjustMethodID, varchar[20], NOT NULL
                sSQL.Append(SQLString(drDetail(j).Item("ReferentID")) & COMMA) 'ReferentID, varchar[20], NOT NULL
                sSQL.Append(SQLString(drDetail(j).Item("EvaluationElementID")) & COMMA) 'EvaluationElementID, varchar[50], NOT NULL
                sSQL.Append(SQLNumber(drDetail(j).Item("AppTypeID")) & COMMA) 'AppTypeID, tinyint, NOT NULL
                sSQL.Append(SQLString(drDetail(j).Item("Operator")) & COMMA) 'Operator, varchar[20], NOT NULL
                sSQL.Append(SQLString(drDetail(j).Item("ValuesFrom")) & COMMA) 'ValuesFrom, decimal, NOT NULL
                sSQL.Append(SQLString(drDetail(j).Item("ValuesTo")) & COMMA) 'ValuesTo, decimal, NOT NULL
                sSQL.Append(SQLNumber(drDetail(j).Item("Method")) & COMMA) 'Method, tinyint, NOT NULL
                sSQL.Append(SQLMoney(drDetail(j).Item("Values"), tdbgD.Columns(COLD_Values).NumberFormat)) 'Values, decimal, NOT NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            Next
        Next
        Return sRet
    End Function


#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub optMethodRefer0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMethodRefer0.CheckedChanged
        EnableGird()
    End Sub
End Class