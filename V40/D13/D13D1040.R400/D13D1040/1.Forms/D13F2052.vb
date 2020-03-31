Imports System
Imports System.Text
Imports System.Collections

'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:38:01 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 30/08/2010
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D13F2052
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property



#Region "Const of tdbg1"
    Private Const COL_ProcessOrderNum As Integer = 0 ' TT xử lý
    Private Const COL_Orders As Integer = 1          ' TT khoản TN
    Private Const COL_CalNo As Integer = 2           ' Mã khoản thu nhập để tính lương
    Private Const COL_Enabled As Integer = 3         ' Enabled
    Private Const COL_Caption As Integer = 4         ' Diễn giải
    Private Const COL_ShortName As Integer = 5       ' Tên tắt
    Private Const COL_SalSystemID As Integer = 6     ' Khoản thu nhập hệ thống
    Private Const COL_IsBackPay As Integer = 7       ' Hồi tố lương
    Private Const COL_CalculationType As Integer = 8 ' Phương pháp tính mỗi khoản thu nhập
    Private Const COL_Formular As Integer = 9        ' Công thức tính lương
    Private Const COL_Decimals As Integer = 10       ' Làm tròn thập phân
    Private Const COL_SalAccuCheck As Integer = 11   ' Có/không lũy kế vào HSL
    Private Const COL_SalAccuSign As Integer = 12    ' Dấu (+) hoặc (-) khi lũy kế
    Private Const COL_SalAccumulator As Integer = 13 ' Khoản thu nhập trong HSL được lũy kế
    Private Const COL_InsAccuCheck As Integer = 14   ' Có/không lũy kế vào HSBH
    Private Const COL_InsAccuSign As Integer = 15    ' Dấu (+) hoặc (-) khi lũy kế 1
    Private Const COL_InsAccumulator As Integer = 16 ' Khoản bảo hiểm trong HSL được lũy kế
    Private Const COL_IsSub As Integer = 17          ' Tính hồ sơ lương phụ
    Private Const COL_IsMainAccu As Integer = 18     ' Lũy kế HSL chính
    Private Const COL_InSurRate As Integer = 19      ' Tỷ lệ BH trong phương pháp tính lương Gross
    Private Const COL_IsNotPrint As Integer = 20     ' Không in
    Private Const COL_IsLemonWeb As Integer = 21     ' Xem trên LemonWeb
    Private Const COL_FormularDesc As Integer = 22   ' FormularDesc
    Private Const COL_IsUpdate As Integer = 23       ' IsUpdate
#End Region
#Region "Const of tdbg2"
    Private Const COL1_FormularID As Integer = 0  ' Công thức
    Private Const COL1_Description As Integer = 1 ' Diễn giải
#End Region

    'Private bFlagSave As Boolean = False

    Private _EnableSave As Boolean
    Public WriteOnly Property EnableSave() As Boolean
        Set(ByVal value As Boolean)
            _EnableSave = value
        End Set
    End Property

    Private _salCalMethodID As String
    Private _description As String
    Dim dtMain As DataTable

    'Dim dtGrid1 As DataTable

    Public Property SalCalMethodID() As String
        Get
            Return _salCalMethodID
        End Get
        Set(ByVal value As String)
            If SalCalMethodID = value Then
                _salCalMethodID = ""
                Return
            End If
            _salCalMethodID = value
        End Set
    End Property

    Public Property DescriptionID() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            If DescriptionID = value Then
                _description = ""
                Return
            End If
            _description = value
        End Set
    End Property

    Private _divisionName As String
    Public WriteOnly Property DivisionName() As String
        Set(ByVal Value As String)
            _divisionName = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            LoadTDBCombo()
            LoadTDBDropDown()
            LoadGridDataTable()
            LoadTDBGrid1()
            'LoadTDBGrid2()
            InitControl()
            txt_NumberFormat()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    cboDecimals.Text = "0"
                    LoadEdit()
                    cboDecimals.Items(3).ToString()
                    '  btnSave.Enabled = _EnableSave And ReturnPermission("D13F2050") > 1
                    btnSave.Enabled = ReturnPermission("D13F2050") > 1
                Case EnumFormState.FormEdit
                    LoadEdit()
                    ' btnSave.Enabled = _EnableSave And ReturnPermission("D13F2050") > 1 
                    btnSave.Enabled = ReturnPermission("D13F2050") > 1
                Case EnumFormState.FormView
                    LoadEdit()
                    btnSave.Enabled = False
                    btnClose.Focus()
                Case EnumFormState.FormOther
                    LoadEdit()
                    btnSave.Enabled = _EnableSave And ReturnPermission("D13F2050") > 1 ' update 18/10/2012 id 51871
                    '  btnSave.Enabled = ReturnPermission("D13F2050") > 1
            End Select
        End Set
    End Property

    Private Sub LoadEdit()
        txtSalCalMethodID.Text = _salCalMethodID
        txtDescription.Text = _description
        txtDivisionName.Text = _divisionName
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F2052_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    optCalculationType0.Focus()
                Case Keys.D2, Keys.NumPad2
                    chkSalAccuCheck.Focus()
            End Select
        End If
        If e.KeyCode = Keys.Enter And Not txtFormularDesc.Focused And Not txtFormular.Focused Then
            UseEnterAsTab(Me, True)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            If tdbg1.Enabled = True Then
                HotKeyF11(Me, tdbg1)
            End If
        End If
    End Sub

    Private Sub D13F2052_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        tdbcSalAccumulator.AutoCompletion = False

        InputbyUnicode(Me, gbUnicode)
        UnicodeGridDataField(tdbg1, UnicodeArrayCOL(), gbUnicode)
        tdbg1_LockedColumns()
        SetResolutionForm(Me)
        SetBackColorObligatory()
        CheckIdTextBox(txtFormular, txtFormular.MaxLength, True)
    End Sub

    Private Sub tdbg1_LockedColumns()
        tdbg1.Splits(SPLIT0).DisplayColumns(COL_Orders).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub



    Private Function UnicodeArrayCOL() As Integer()
        If Not gbUnicode Then Return Nothing
        Dim ArrCOL() As Integer = {COL_Caption, COL_ShortName, COL_FormularDesc} ' COL_Formular
        Return ArrCOL
    End Function

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_phuong_phap_tinh_luong_-_D13F2052") & UnicodeCaption(gbUnicode) 'Chi tiÕt ph§¥ng phÀp tÛnh l§¥ng - D13F2052
        '================================================================ 
        lblSalCalMethodID.Text = rl3("Ma") 'Mã
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblMethod.Text = rl3("Phuong_phap_luy_ke") 'Phương pháp lũy kế
        lblIssurRate.Text = rL3("Ty_le_BH") 'Tỷ lệ (BHXH, BHYT)
        lblFormular.Text = rl3("Cong_thuc") 'Công thức
        lblDecimals.Text = rl3("Lam_tron") 'Làm tròn
        lblFormularDesc.Text = rl3("Dien_giai")
        lblDivisionName.Text = rl3("Don_vi")
        '================================================================ 
        'btnChamCong.Text = rl3("Dieu__chinh_thu_nhap") 'Điều &chỉnh thu nhập
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnFormula.Text = rl3("Cong__thuc")
        '================================================================ 
        chkListAll.Text = rl3("Hien_thi_tat_ca") 'Hiển thị tất cả
        chkSalAccuCheck.Text = rl3("Luy_ke_vao_HSL") 'Lũy kế vào HSL
        chkIsSub.Text = rl3("HSL_phu") 'HSL phụ
        chkIsSortProcessOrderNum.Text = rl3("Sap_xep_theo_TT_khoan_TN")
        '================================================================ 
        optIsMainAccu0.Text = rl3("Luy_ke_binh_thuong") 'Lũy kế bình thường
        optIsMainAccu1.Text = rl3("Luy_ke_HSL_chinh") 'Lũy kế HSL chính
        optCalculationType3.Text = rl3("Thu_nhap_truoc_thue") 'Thu nhập trước thuế
        optCalculationType2.Text = rl3("Thue_thu_nhap") 'Thuế thu nhập
        optCalculationType1.Text = rl3("Luong_san_pham") 'Lương sản phẩm
        optCalculationType0.Text = rl3("Binh_thuong") 'Bình thường
        '================================================================ 
        grp2.Text = rl3("Thiet_lap_cac_khoan_thu_nhap") 'Thiết lập các khoản thu nhập
        grp4.Text = "2. " & rl3("Luy_ke") 'Lũy kế
        grp3.Text = "1. " & rl3("Loai_thu_nhap") 'Loại thu nhập
        '================================================================ 
        tdbcSalAccumulator.Columns("Short").Caption = rl3("Ma") 'Mã
        tdbcSalAccumulator.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg1.Splits(0).Caption = rl3("Cac_khoan_thu_nhap")
        tdbg1.Columns("Orders").Caption = "   " & rl3("TT_khoan_TN") '  rl3("STT") 'STT ' update 5/6/2013 id 56508
        tdbg1.Columns("ProcessOrderNum").Caption = rl3("TT_xu_ly") ' update 5/6/2013 id 56508
        tdbg1.Columns("CalNo").Caption = rl3("Ma_khoan_thu_nhap_de_tinh_luong") 'Mã khoản thu nhập để tính lương
        tdbg1.Columns("Caption").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg1.Columns("ShortName").Caption = rL3("Ten_tat") 'Tên tắt
        tdbg1.Columns(COL_SalSystemID).Caption = rL3("Khoan_thu_nhap_he_thong") 'Khoản thu nhập hệ thống
        tdbg1.Columns("IsNotPrint").Caption = rl3("Khong_in") 'Không in
        tdbg1.Columns("IsBackPay").Caption = rL3("Hoi_to_luong") 'Hồi tố lương
        tdbg1.Columns("IsLemonWeb").Caption = rL3("Xem_tren_LemonWeb") 'Xem trên LemonWeb
    End Sub

    Private Sub btnChamCong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New D13F2054
        With f
            .FormID = "D13F2054"
            .ShowDialog()
            .Dispose()
            txtFormular.Text &= f.ReturnFormular
        End With
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2052
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 25/12/2009 10:53:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2052() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2052 "
        sSQL &= SQLString(_salCalMethodID) 'SalCalMethodID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub LoadGridDataTable()
        'Dim sSQL As New StringBuilder("")
        'sSQL.Append("Select D2.Code as Code, cast (D1.Disabled as bit) as Disabled, convert(smallint, Right(CalNo,2))Orders, CalNo, " & vbCrLf)
        'sSQL.Append("Caption ,ShortName, CalculationType , Formular, D1.Decimals, SalAccuCheck, SalAccuSign, SalAccumulator," & vbCrLf)
        'sSQL.Append("InsAccuCheck, InsAccuSign, InsAccumulator, IsSub, IsMainAccu, InSurRate, Convert(bit,IsNotPrint) as IsNotPrint, FormularDesc" & vbCrLf)
        'sSQL.Append(" From D13T2501 D1 LEFT JOIN D13T9000 D2 ON D1.CALNo = D2.CODE " & vbCrLf)
        'sSQL.Append("Where SalCalMethodID = " & SQLString(_salCalMethodID) & " AND D2.Type='PRCAL' AND D2.Disabled=0 AND  D1.Disabled =0   Order by CalNo ")
        dtMain = ReturnDataTable(SQLStoreD13P2052)
        Dim col() As DataColumn = {dtMain.Columns("CalNo")}
        dtMain.PrimaryKey = col
    End Sub

    Dim bChangedCheckListAll As Boolean = False
    Private Sub LoadTDBGrid1()
        Dim sKey As String = tdbg1.Columns(COL_Orders).Text
        Dim dtT As DataTable = CType(tdbg1.DataSource, DataTable)
        If dtT IsNot Nothing Then
            dtMain.Merge(dtT, False, MissingSchemaAction.AddWithKey)
        End If
        LoadDataSource(tdbg1, dtMain, gbUnicode)
        chkIsSortProcessOrderNum_CheckedChanged(Nothing, Nothing)
        ReLoadTDBGrid1()
        '        dtMain.AcceptChanges()
        '        If chkListAll.Checked Then
        '            LoadDataSource(tdbg1, dtMain.Copy, gbUnicode)
        '        Else
        '            '  dtMain.DefaultView.RowFilter = "Enabled = True"
        '            LoadDataSource(tdbg1, ReturnTableFilter(dtMain, "Enabled = True"), gbUnicode)
        '        End If


        'If bFlag = True Then
        '    Dim dt1 As DataTable = CType(tdbg1.DataSource, DataTable)
        '    dt1.DefaultView.Sort = "Orders"
        '    tdbg1.Bookmark = dt1.DefaultView.Find(sKey)
        'End If
        'For i As Integer = 0 To tdbg1.RowCount - 1
        '    If CBool(dtMain.Rows(i).Item("Disabled")) = False Then
        '        tdbg1(i, COL_Disabled) = 1
        '    End If
        'Next       
    End Sub

    Private Sub ReLoadTDBGrid1()
        dtMain.AcceptChanges()
        Dim sFilter As String = "" 'TH sFind="" và chkIsUsed.Checked =False
        '  If bChangedCheckListAll Then
        If Not chkListAll.Checked Then
            sFilter = "Enabled=True"
        End If
        '        Else
        '            If Not chkListAll.Checked Then
        '                sFilter = "Enabled=True or IsUpdate=True"
        '            End If
        '        End If
        dtMain.DefaultView.RowFilter = sFilter

        '        ' sửa lỗi khi xóa dòng cuối thanh cuộn đưa lên dòng đầu tiên
        '        If chkListAll.Checked Then
        '            Dim dt1 As DataTable = dtMain.DefaultView.ToTable
        '            Dim dr() As DataRow = dt1.Select("Orders = " & SQLNumber(sValueCurrent))
        '            If dr.Length > 0 Then tdbg1.Row = dt1.Rows.IndexOf(dr(0))
        '        Else
        '            Dim dt1 As DataTable = dtMain.DefaultView.ToTable
        '            Dim dr() As DataRow = dt1.Select("Orders = " & SQLNumber(sValueCurrent))
        '            If dr.Length > 0 Then tdbg1.Row = dt1.Rows.IndexOf(dr(0))
        '        End If

    End Sub

    'Private Sub LoadTDBGrid2()
    '    Dim sSQL As String = ""
    '    sSQL &= "Select FormulaID, Description From D13V1010 Order By TransID, FormulaID"
    '    Dim dt As DataTable = ReturnDataTable(sSQL)
    '    LoadDataSource(tdbg2, dt)
    'End Sub

    Private Sub optCalculationType3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCalculationType3.Click
        txtIssurRate.Enabled = True
        txtIssurRate.Focus()
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL_CalculationType) = 3
            tdbg1(tdbg1.Row, COL_InSurRate) = txtIssurRate.Text
        End If
    End Sub

    Private Sub optCalculationType0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCalculationType0.Click
        txtIssurRate.Text = "0"
        txtIssurRate.Enabled = False
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL_CalculationType) = 0
        End If
    End Sub

    Private Sub optCalculationType2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCalculationType2.Click
        txtIssurRate.Text = "0"
        txtIssurRate.Enabled = False
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL_CalculationType) = 2
        End If
    End Sub

    Private Sub optCalculationType1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCalculationType1.Click
        txtIssurRate.Text = "0"
        txtIssurRate.Enabled = False
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL_CalculationType) = 1
        End If
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcSalAccumulator
        sSQL = "Select Short" & UnicodeJoin(gbUnicode) & " as Short, " & IIf(gbUnicode, "DescriptionU", "Description").ToString & " as Description, Code From D13T9000  WITH(NOLOCK) Where Type = 'PRMAS' And Disabled = 0 "
        LoadDataSource(tdbcSalAccumulator, sSQL, gbUnicode)

    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdSalSystemID
        sSQL = "SELECT		Code AS SalSystemID, Short AS SalSysShortName "
        sSQL &= "FROM		D13T9000 "
        sSQL &= "WHERE		Disabled = 0 and Type = 'PRSYS' "
        sSQL &= "ORDER BY	Code"
        LoadDataSource(tdbdSalSystemID, sSQL, gbUnicode)
    End Sub


    Private Sub ShowDetailGrid()
        If tdbg1.RowCount >= 1 Then
            If tdbg1.Columns(COL_CalculationType).Text <> "" Then
                If L3Int(tdbg1.Columns(COL_CalculationType).Text) = 0 Then
                    optCalculationType0.Checked = True
                    txtIssurRate.Text = "0"
                    txtIssurRate.Enabled = False

                ElseIf L3Int(tdbg1.Columns(COL_CalculationType).Text) = 1 Then
                    optCalculationType1.Checked = True
                    txtIssurRate.Text = "0"
                    txtIssurRate.Enabled = False

                ElseIf L3Int(tdbg1.Columns(COL_CalculationType).Text) = 2 Then
                    optCalculationType2.Checked = True
                    txtIssurRate.Text = "0"
                    txtIssurRate.Enabled = False
                Else
                    optCalculationType3.Checked = True
                    txtIssurRate.Enabled = True
                    txtIssurRate.Text = tdbg1.Columns(COL_InSurRate).Text
                End If
            End If
            txt_NumberFormat()
            txtFormular.Text = tdbg1.Columns(COL_Formular).Text
            txtFormularDesc.Text = tdbg1.Columns(COL_FormularDesc).Text
            If tdbg1.Columns(COL_IsSub).Text <> "" Then
                If L3Int(tdbg1.Columns(COL_IsSub).Text) = 0 Then
                    chkIsSub.Checked = False
                Else
                    chkIsSub.Checked = True
                End If
            End If

            cboDecimals.Text = tdbg1.Columns(COL_Decimals).Text
            If tdbg1.Columns(COL_SalAccuCheck).Text <> "" Then
                chkSalAccuCheck.Checked = CBool(Convert.ToInt16(tdbg1.Columns(COL_SalAccuCheck).Text))
            End If
            If chkSalAccuCheck.Checked = False Then
                cboSalAccuSign.SelectedIndex = -1
                cboSalAccuSign.Text = ""
                tdbcSalAccumulator.Text = ""
                cboSalAccuSign.Enabled = False
                tdbcSalAccumulator.Enabled = False
            Else
                cboSalAccuSign.Enabled = True
                tdbcSalAccumulator.Enabled = True
                cboSalAccuSign.Text = tdbg1.Columns(COL_SalAccuSign).Text
                tdbcSalAccumulator.SelectedValue = tdbg1.Columns(COL_SalAccumulator).Text
            End If
            If tdbg1.Columns(COL_IsMainAccu).Text <> "" Then
                If L3Int(tdbg1.Columns(COL_IsMainAccu).Text) = 1 Then
                    optIsMainAccu1.Checked = True
                Else
                    optIsMainAccu0.Checked = True
                End If
            End If

            If tdbg1(tdbg1.Row, COL_Enabled).ToString <> "" Then
                If Convert.ToInt16(tdbg1(tdbg1.Row, COL_Enabled)) = 0 Then
                    EnabledControl(False)
                    txtIssurRate.Enabled = False
                Else
                    EnabledControl(True)
                End If
            End If
        End If
    End Sub

    Private Sub tdbg1_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg1.FetchCellTips
        Select Case e.ColIndex
            Case COL_Caption
                If Trim(tdbg1.Columns(COL_Caption).Text).Length > tdbg1.Splits(0).DisplayColumns(COL_Caption).Width Then
                    e.CellTip = tdbg1.Columns(COL_Caption).Text
                End If
            Case Else
                e.CellTip = ""
        End Select
    End Sub

    Dim sValueCurrent As String = "" ' Lưu giá trị để focus

    Private Sub tdbg1_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg1.RowColChange
        'tdbg1.UpdateData()
        'Application.DoEvents()
        sValueCurrent = tdbg1.Columns(COL_Orders).Text
        ShowDetailGrid()

    End Sub

    Private Sub chkSalAccuCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSalAccuCheck.Click
        If tdbg1.RowCount >= 1 Then
            If chkSalAccuCheck.Checked = True Then
                cboSalAccuSign.Enabled = True
                tdbcSalAccumulator.Enabled = True
                tdbg1(tdbg1.Row, COL_SalAccuCheck) = 1
                tdbg1(tdbg1.Row, COL_SalAccuSign) = cboSalAccuSign.Text
                tdbg1(tdbg1.Row, COL_SalAccumulator) = ReturnValueC1Combo(tdbcSalAccumulator, "Code") 'tdbcSalAccumulator.Text
            Else
                cboSalAccuSign.SelectedIndex = -1
                cboSalAccuSign.Text = ""
                tdbcSalAccumulator.Text = ""
                cboSalAccuSign.Enabled = False
                tdbcSalAccumulator.Enabled = False
                tdbg1(tdbg1.Row, COL_SalAccuCheck) = 0
                tdbg1(tdbg1.Row, COL_SalAccuSign) = ""
                tdbg1(tdbg1.Row, COL_SalAccumulator) = ""

            End If
        End If
    End Sub

    Private Sub txt_NumberFormat()
        txtIssurRate.Text = (SQLNumber(txtIssurRate.Text, DxxFormat.DefaultNumber2)).ToString
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2501
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 06/03/2007 09:20:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2501() As String
        Dim sSQL As String = ""
        'Dim dt As DataTable = CType(tdbg1.DataSource, DataTable).DefaultView.ToTable
        '   Dim dt As DataTable = ReturnTableFilter(dtMain, "IsUpdate=True", True)
        Dim dr As DataRow
        Dim dt As DataTable = dtMain.DefaultView.ToTable
        Dim sUnicode As String = UnicodeJoin(gbUnicode)
        For i As Integer = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            sSQL &= "Update D13T2501  Set " & vbCrLf
            sSQL &= " Caption = " & SQLStringUnicode(dr("Caption" & sUnicode).ToString, gbUnicode, False) & COMMA 'varchar[150], NOT NULL
            sSQL &= " CaptionU = " & SQLStringUnicode(dr("Caption" & sUnicode).ToString, gbUnicode, True) & COMMA 'varchar[150], NOT NULL
            sSQL &= "Formular = " & SQLString(dr("Formular").ToString) & COMMA 'varchar[2000], NULL
            'sSQL &= "FormularU = " & SQLStringUnicode(dr("FormularU").ToString, gbUnicode, True) & COMMA 'varchar[2000], NULL
            sSQL &= "CalculationType = " & SQLNumber(dr("CalculationType").ToString) & COMMA 'tinyint, NOT NULL
            sSQL &= "Decimals = " & SQLNumber(dr("Decimals").ToString) & COMMA 'int, NOT NULL
            sSQL &= "SalAccuCheck = " & SQLNumber(dr("SalAccuCheck").ToString) & COMMA 'tinyint, NOT NULL
            sSQL &= "SalAccuSign = " & SQLString(dr("SalAccuSign").ToString) & COMMA 'varchar[1], NULL'(tdbg1(i, COL_SalAccuSign)) 
            sSQL &= "SalAccumulator = " & SQLString(dr("SalAccumulator")) & COMMA 'varchar[20], NULL'(tdbg1(i, COL_SalAccumulator))
            sSQL &= "InsAccuCheck = " & SQLNumber(dr("InsAccuCheck").ToString) & COMMA 'tinyint, NOT NULL
            sSQL &= "InsAccuSign = " & SQLString(dr("InsAccuSign").ToString) & COMMA 'varchar[1], NULL
            sSQL &= "InsAccumulator = " & SQLString(dr("InsAccumulator").ToString) & COMMA 'varchar[20], NULL
            sSQL &= "Disabled = " & SQLNumber(Not CBool(dr("Enabled"))) & COMMA 'tinyint, NOT NULL

            sSQL &= "IsSub = " & SQLNumber(dr("IsSub").ToString) & COMMA 'tinyint, NOT NULL
            sSQL &= "ShortName = " & SQLStringUnicode(dr("ShortName" & sUnicode).ToString, gbUnicode, False) & COMMA 'varchar[20], NULL
            sSQL &= "ShortNameU = " & SQLStringUnicode(dr("ShortName" & sUnicode).ToString, gbUnicode, True) & COMMA 'varchar[20], NULL
            sSQL &= "SalSystemID  = " & SQLString(dr("SalSystemID")) & COMMA 'varchar (20), NULL
            sSQL &= "IsMainAccu = " & SQLNumber(dr("IsMainAccu").ToString) & COMMA 'tinyint, NOT NULL
            sSQL &= "InsurRate = " & SQLMoney(dr("InSurRate").ToString) & COMMA 'money, NOT NULL
            sSQL &= "FormularDesc = " & SQLStringUnicode(dr("FormularDesc").ToString, gbUnicode, False) & COMMA
            sSQL &= "FormularDescU = " & SQLStringUnicode(dr("FormularDescU").ToString, gbUnicode, True) & COMMA
            sSQL &= "IsNotPrint = " & SQLNumber(dr("IsNotPrint")) & COMMA 'tinyint, NOT NULL
            sSQL &= "IsBackPay = " & SQLNumber(dr("IsBackPay")) & COMMA 'tinyint, NOT NULL' update 1/10/2013 id 59622
            sSQL &= "ProcessOrderNum = " & SQLNumber(dr("ProcessOrderNum")) & COMMA  ', NOT NULL
            sSQL &= "IsLemonWeb = " & SQLNumber(dr("IsLemonWeb")) 'tinyint, NOT NULL
            sSQL &= "  Where "
            sSQL &= "SalCalMethodID = " & SQLString(_salCalMethodID) & " And "
            sSQL &= "CalNo = " & SQLString(dr("CalNo").ToString) & vbCrLf
        Next
        Return sSQL
    End Function

    Private Sub SetBackColorObligatory()
        cboSalAccuSign.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcSalAccumulator.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub


    Private Function AllowSave() As Boolean
        'dtMain.AcceptChanges()
        'PushGridDataToTable()
        'Dim dtT As DataTable = CType(tdbg1.DataSource, DataTable)
        'If dtT IsNot Nothing Then
        '    dtMain.Merge(dtT, False, MissingSchemaAction.AddWithKey)
        'End If

        If tdbg1.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg1.Focus()
            Return False
        End If

        'Dim sSQL As String = ""
        'sSQL = "Select TOP 1 1 FROM D13T2600 WHERE SalCalMethodID = " & SQLString(_salCalMethodID) & " And Calculated = 1"
        'If ExistRecord(sSQL) Then
        '    D99C0008.MsgL3(rl3("Phuong_phap_tinh_luong_nay_da_duoc_su_dung") & vbCrLf & rl3("Ban_khong_duoc_phep_suaU"))
        '    Return False
        'End If

        For i As Integer = 0 To tdbg1.RowCount - 1
            ' update 5/6/2013 id 56508
            If L3Bool(tdbg1(i, COL_Enabled)) AndAlso (tdbg1(i, COL_ProcessOrderNum).ToString = "" OrElse L3Int(tdbg1(i, COL_ProcessOrderNum)) = 0) Then
                D99C0008.MsgNotYetEnter(rl3("TT_xu_ly"))
                tdbg1.Focus()
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Col = COL_ProcessOrderNum
                tdbg1.Row = i

                Return False
            End If
            If tdbg1(i, COL_Caption).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Col = COL_Caption
                tdbg1.Row = i
                tdbg1.Focus()
                Return False
            End If
            If tdbg1(i, COL_ShortName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Col = COL_ShortName
                tdbg1.Row = i
                tdbg1.Focus()
                Return False
            End If
        Next
        ' update 5/6/2013 id 56508
        For i As Integer = 0 To tdbg1.RowCount - 2
            For j As Integer = i + 1 To tdbg1.RowCount - 1
                If L3Bool(tdbg1(i, COL_Enabled)) AndAlso L3Bool(tdbg1(j, COL_Enabled)) AndAlso tdbg1(i, COL_ProcessOrderNum).ToString = tdbg1(j, COL_ProcessOrderNum).ToString Then
                    'D99C0008.MsgDuplicatePKey() ' Mã này đã tồn tại.
                    D99C0008.MsgL3(rl3("Khoan_thu_nhap") & Space(1) & tdbg1(i, COL_Orders).ToString & ", " & tdbg1(j, COL_Orders).ToString & Space(1) & rl3("trung_thu_tu_xu_ly") & ". " & rl3("Ban_khong_duoc_phep_luu"))
                    tdbg1.Focus()
                    tdbg1.SplitIndex = SPLIT0 'Tùy theo yêu cầu mỗi Form
                    tdbg1.Col = COL_ProcessOrderNum 'Tùy theo yêu cầu mỗi Form
                    tdbg1.Row = i 'Tùy theo yêu cầu mỗi Form
                    Return False
                End If
            Next

        Next
        If tdbg1.Columns(COL_Caption).Text <> "" Then
            If tdbg1.Columns(COL_Caption).Text.Trim.Length > 50 Then
                D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_vuot_qua_50_ky_tu"))
                tdbg1.Col = COL_Caption
                tdbg1.Focus()
                Return False
            End If
        End If
        If tdbg1.Columns(COL_ShortName).Text <> "" Then
            If tdbg1.Columns(COL_ShortName).Text.Trim.Length > 50 Then
                D99C0008.MsgL3(rl3("Do_dai_Ten_tat_khong_duoc_vuot_qua") & " 50 " & rl3("ky_tu_U")) 'Độ dài Tên tắt không được vượt quá 20 ký tự.
                tdbg1.Col = COL_Caption
                tdbg1.Focus()
                Return False
            End If
        End If
        If optCalculationType3.Checked Then
            If txtIssurRate.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ty_le_(BHXH_BHYT)"))
                txtIssurRate.Focus()
                Return False
            Else
                If Convert.ToDouble(txtIssurRate.Text) > 100 Then
                    D99C0008.MsgL3(rl3("Ty_le_(BHXH_BHYT)_khong_duoc_vuot_qua_100%"))
                    txtIssurRate.Focus()
                    Return False
                End If
            End If
        End If
        If txtFormular.Text.Trim <> "" Then
            If txtFormular.Text.Trim.Length > 2000 Then
                D99C0008.MsgL3(rl3("Do_dai_Cong_thuc_khong_duoc_vuot_qua_2000_ky_tu"))
                txtFormular.Focus()
                Return False
            End If
        End If
        If chkSalAccuCheck.Checked Then
            If cboSalAccuSign.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Luy_ke_vao_HSL"))
                cboSalAccuSign.Focus()
                Return False
            End If
            If tdbcSalAccumulator.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Luy_ke_vao_HSL"))
                tdbcSalAccumulator.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg1.UpdateData()

        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False
        sSQL = SQLUpdateD13T2501()
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = False
        If sSQL <> "" Then
            bRunSQL = ExecuteSQL(sSQL)
        Else
            bRunSQL = True
        End If
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            'If CheckAudit("SalCalMethodDe") Then
            '    sSQL = SQLStoreD91P9106("SalCalMethodDe", "13", "02", _salCalMethodID, _description, "", "", "")
            '    ExecuteSQLNoTransaction(sSQL)
            'End If
            Lemon3.D91.RunAuditLog("13", "SalCalMethodDe", "02", _salCalMethodID, _description, "", "", "")
            'Dim iBookmark As Integer
            'If Not IsDBNull(tdbg1.Bookmark) Then iBookmark = tdbg1.Bookmark
            'LoadTDBGrid1()
            'If Not IsDBNull(iBookmark) Then tdbg1.Bookmark = iBookmark

            btnSave.Enabled = True And ReturnPermission("D13F2050") > 1
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True And ReturnPermission("D13F2050") > 1
        End If
    End Sub

    Private Sub chkListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkListAll.Click
        bChangedCheckListAll = True
        '  PushGridDataToTable()
        ReLoadTDBGrid1() '  LoadTDBGrid1()
        ShowDetailGrid()
    End Sub

    Private Sub tdbg1_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.AfterColUpdate
        tdbg1.Columns(COL_IsUpdate).Value = True
        tdbg1.UpdateData()
        Select Case e.ColIndex
            Case COL_Enabled
                If Convert.ToBoolean(tdbg1.Columns(COL_Enabled).Text) = True Then
                    EnabledControl(True)
                Else
                    EnabledControl(False)
                End If
                '     PushGridDataToTable()
                '   ReLoadTDBGrid1() ' LoadTDBGrid1()
            Case COL_SalSystemID
                If tdbg1.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg1.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    Exit Select
                End If
        End Select

    End Sub

    Private Sub tdbg1_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.ComboSelect
        tdbg1.UpdateData()
    End Sub

    Private Sub tdbg1_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.HeadClick
        If tdbg1.RowCount <= 0 Then Exit Sub
        Select Case e.ColIndex
            Case COL_IsNotPrint, COL_IsBackPay
                Dim bVal As Boolean = False
                bVal = Not Convert.ToBoolean(tdbg1(0, e.ColIndex))
                For i As Integer = 0 To tdbg1.RowCount - 1
                    tdbg1(i, e.ColIndex) = bVal
                    tdbg1(i, COL_IsUpdate) = True
                Next
        End Select
    End Sub

    Private Sub EnabledControl(ByVal bFlag As Boolean)
        optCalculationType0.Enabled = bFlag
        optCalculationType1.Enabled = bFlag
        optCalculationType2.Enabled = bFlag
        optCalculationType3.Enabled = bFlag
        txtFormular.Enabled = bFlag
        txtFormularDesc.Enabled = bFlag
        chkIsSub.Enabled = bFlag
        cboDecimals.Enabled = bFlag
        'tdbg2.Enabled = bFlag
        chkSalAccuCheck.Enabled = bFlag
        optIsMainAccu0.Enabled = bFlag
        optIsMainAccu1.Enabled = bFlag
    End Sub

    Private Sub InitControl()
        optCalculationType0.Checked = True
        txtIssurRate.Text = "0"
        txtIssurRate.Enabled = False
        chkListAll.Checked = False
        chkSalAccuCheck.Checked = False
        If tdbg1.RowCount < 1 Then
            cboDecimals.Text = "0"
        End If
        If chkSalAccuCheck.Checked = False Then
            cboSalAccuSign.Enabled = False
            tdbcSalAccumulator.Enabled = False
        End If
        optIsMainAccu0.Checked = True
    End Sub

    Private Sub txtIssurRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIssurRate.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbg1_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg1.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_Orders
                If Not IsNumeric(tdbg1.Columns(COL_Orders).Text) Then e.Cancel = True
            Case COL_CalculationType
                If Not IsNumeric(tdbg1.Columns(COL_CalculationType).Text) Then e.Cancel = True
            Case COL_Decimals
                If Not IsNumeric(tdbg1.Columns(COL_Decimals).Text) Then e.Cancel = True
            Case COL_InSurRate
                If Not IsNumeric(tdbg1.Columns(COL_InSurRate).Text) Then e.Cancel = True
            Case COL_SalSystemID
                If tdbg1.Columns(e.ColIndex).Text <> tdbg1.Columns(e.ColIndex).DropDown.Columns(tdbg1.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg1.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                Else
                    Dim SalSystemID As String
                    SalSystemID = tdbdSalSystemID.Columns("SalSystemID").Text
                    For i As Integer = 0 To tdbg1.RowCount - 1
                        If tdbg1.Row <> i AndAlso SalSystemID = tdbg1(i, COL_SalSystemID).ToString() Then
                            e.Cancel = True
                            D99C0008.MsgDuplicatePKey()
                            tdbg1.Focus()
                            tdbg1.Col = COL_SalSystemID
                            Exit For
                        End If
                    Next
                End If
        End Select
    End Sub

    Private Sub PushGridDataToTable()
        Dim dt As DataTable = CType(tdbg1.DataSource, DataTable)
        dt.AcceptChanges()
    End Sub

    Private Sub txtFormular_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFormular.LostFocus
        'If tdbg1.RowCount >= 1 Then
        '    'tdbg1(tdbg1.Row, COL_Formular) = txtFormular.Text
        '    'Dim dt1 As DataTable = dtMain.DefaultView.ToTable
        '    'Dim col() As DataColumn = {dt1.Columns("CalNo")}
        '    'dt1.PrimaryKey = col

        '    dtMain.DefaultView(tdbg1.Row).Item("Formular") = txtFormular.Text
        '    dtMain.DefaultView(tdbg1.Row).Item("FormularU") = txtFormular.Text

        '    'Dim dTemp As DataTable = dtMain.Copy
        '    'dTemp.Merge(dt1, True, MissingSchemaAction.AddWithKey)

        '    'dtMain = dTemp
        '    dtMain.AcceptChanges()

        '    tdbg1.UpdateData()
        'End If
    End Sub

    Private Sub txtFormularDesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFormularDesc.TextChanged
        'If tdbg1.RowCount >= 1 Then
        '    tdbg1(tdbg1.Row, COL_FormularDesc) = txtFormularDesc.Text
        '    'PushGridDataToTable()
        'End If
        If tdbg1.RowCount = 0 Then Exit Sub
        Dim dt As DataTable = CType(tdbg1.DataSource, DataTable)

        dt.DefaultView(tdbg1.Row).Item("FormularDesc") = txtFormularDesc.Text
        dt.DefaultView(tdbg1.Row).Item("FormularDescU") = txtFormularDesc.Text
    End Sub

    'Private Sub txtFormular_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFormular.Validated
    '    If tdbg1.RowCount >= 1 Then
    '        tdbg1(tdbg1.Row, COL_Formular) = txtFormular.Text
    '    End If
    'End Sub

    Private Sub chkIsSub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsSub.Click
        If tdbg1.RowCount >= 1 Then
            If chkIsSub.Checked = True Then
                tdbg1(tdbg1.Row, COL_IsSub) = 1
            Else
                tdbg1(tdbg1.Row, COL_IsSub) = 0
            End If
        End If
    End Sub

    Private Sub cboDecimals_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDecimals.SelectedValueChanged
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL_Decimals) = cboDecimals.Text
        End If
    End Sub

    Private Sub cboSalAccuSign_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSalAccuSign.SelectedValueChanged
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL_SalAccuSign) = cboSalAccuSign.Text
        End If
        'tdbcSalAccumulator.AutoSelect = True
    End Sub

    Private Sub tdbcSalAccumulator_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalAccumulator.SelectedValueChanged
        'If tdbg1.RowCount >= 1 Then
        '    tdbg1(tdbg1.Row, COL_SalAccumulator) = ReturnValueC1Combo(tdbcSalAccumulator, "Code") 'tdbcSalAccumulator.Text
        'End If
    End Sub

    'Combo Nhập Tên
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalAccumulator.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    'Combo Nhập Tên
    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSalAccumulator.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL_SalAccumulator) = ReturnValueC1Combo(tdbcSalAccumulator, "Code") 'tdbcSalAccumulator.Text
        End If

    End Sub

    Private Sub txtIssurRate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIssurRate.Validated
        txtIssurRate.Text = (SQLNumber(txtIssurRate.Text, DxxFormat.DefaultNumber2)).ToString
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL_InSurRate) = txtIssurRate.Text
        End If
    End Sub

    Private Sub optIsMainAccu0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optIsMainAccu0.Click
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL_IsMainAccu) = 0
        End If
    End Sub

    Private Sub optIsMainAccu1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optIsMainAccu1.Click
        If tdbg1.RowCount >= 1 Then
            tdbg1(tdbg1.Row, COL_IsMainAccu) = 1
        End If
    End Sub

    'Private Sub tdbg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If tdbg2.RowCount < 1 Then Exit Sub

    '    Dim iCurrentPos As Integer = txtFormular.SelectionStart
    '    Dim sFormular As String = txtFormular.Text
    '    Dim sTextBefore As String = sFormular.Substring(0, iCurrentPos)
    '    Dim sTextAfter As String = sFormular.Substring(iCurrentPos, sFormular.Length - iCurrentPos)
    '    txtFormular.Text = sTextBefore & tdbg2(tdbg2.Bookmark, COL1_FormularID).ToString & sTextAfter

    '    If tdbg1.RowCount >= 1 Then
    '        tdbg1(tdbg1.Row, COL_Formular) = txtFormular.Text
    '    End If
    'End Sub

    'Private Sub tdbg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Return Then
    '        txtFormular.Text &= tdbg2(tdbg2.Bookmark, COL1_FormularID).ToString
    '        If tdbg1.RowCount >= 1 Then
    '            tdbg1(tdbg1.Row, COL_Formular) = txtFormular.Text
    '        End If
    '    End If
    'End Sub

    Private Sub btnFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormula.Click
        Dim frm As New D13F2054
        frm.FormID = "D13F2054"
        frm.ShowDialog()
        Dim sFormula As String = frm.ReturnFormular
        frm.Dispose()
        'txtFormular.Text &= sFormula

        Dim iCurrentPos As Integer = txtFormular.SelectionStart
        Dim sFormular As String = txtFormular.Text
        Dim sTextBefore As String = sFormular.Substring(0, iCurrentPos)
        Dim sTextAfter As String = sFormular.Substring(iCurrentPos, sFormular.Length - iCurrentPos)
        txtFormular.Text = sTextBefore & sFormula & sTextAfter

    End Sub

    Private Sub txtFormular_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFormular.TextChanged
        If tdbg1.RowCount = 0 Then Exit Sub
        Dim dt As DataTable = CType(tdbg1.DataSource, DataTable)

        dt.DefaultView(tdbg1.Row).Item("Formular") = txtFormular.Text
        '    dt.DefaultView(tdbg1.Row).Item("FormularU") = txtFormular.Text

    End Sub

    ' update 5/6/2013 id 56508
    Private Sub chkIsSortProcessOrderNum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsSortProcessOrderNum.CheckedChanged
        Dim dt As DataTable = CType(tdbg1.DataSource, DataTable)
        Dim dt1 As DataTable = dtMain.Copy
        If chkIsSortProcessOrderNum.Checked Then
            dt1.DefaultView.Sort = "Orders ASC"
        Else
            dt1.DefaultView.Sort = "ProcessOrderNum ASC"
        End If
        dtMain = dt1.DefaultView.ToTable
        LoadDataSource(tdbg1, dtMain, gbUnicode)
        ReLoadTDBGrid1()
    End Sub

    Private Sub tdbg1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg1.KeyPress
        Select Case tdbg1.Col
            Case COL_Enabled, COL_IsNotPrint, COL_IsBackPay, COL_IsLemonWeb
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_ProcessOrderNum
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

End Class
