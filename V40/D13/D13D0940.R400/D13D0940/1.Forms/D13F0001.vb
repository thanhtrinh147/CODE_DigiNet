Imports System
Imports System.Text

'#-------------------------------------------------------------------------------------
'# Created Date: 25/07/2006 1:35:52 PM
'# Created User: Lê Văn Phước
'# Modify Date: 25/07/2006 1:35:52 PM
'# Modify User: Lê Văn Phước
'#-------------------------------------------------------------------------------------
Public Class D13F0001

#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0          ' TransID
    Private Const COL_DateFrom As Integer = 1         ' Từ ngày
    Private Const COL_DateTo As Integer = 2           ' Đến ngày
    Private Const COL_SelfDeductionAmt As Integer = 3 ' Mức giảm trừ bản thân
#End Region

#Region "Const of tdbgMinSalary"
    Private Const COLMS_DivisionID As Integer = 0 ' Đơn vị
    Private Const COLMS_MinSalary As Integer = 1  ' Lương tối thiểu
    Private Const COLMS_MSDateFrom As Integer = 2 ' Ngày hiệu lực
    Private Const COLMS_MSDateTo As Integer = 3   ' Ngày hết hiệu lực
#End Region

#Region "Const of tdbgSalAdj"
    Private Const COLS_IsSelected As Integer = 0        ' Chọn
    Private Const COLS_SalParameterID As Integer = 1    ' SalParameterID
    Private Const COLS_SalParameterName As Integer = 2  ' Thông số lương
    Private Const COLS_SalAdjMethodID As Integer = 3    ' Phương pháp điều chỉnh
    Private Const COLS_SalAdjustmentDate As Integer = 4 ' Ngày xét điều chỉnh
    Private Const COLS_Note As Integer = 5              ' Ghi chú
    Private Const COLS_Type As Integer = 6              ' Type
#End Region

#Region "Const of tdbgAuto"
    Private Const COLA_BenefitID As Integer = 0        ' Mã chính sách
    Private Const COLA_BenefitName As Integer = 1      ' Tên chính sách
    Private Const COLA_IsAdvancePayroll As Integer = 2 ' Lương ứng
    Private Const COLA_IsMainPayroll As Integer = 3    ' Lương chính thức
#End Region

    Private dtGridMinSalary As DataTable
    Private dtGridSalAdj As DataTable

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
        End Set
    End Property

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean 
        Get
            Return _bSaved
        End Get
    End Property

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDivisionID
        LoadCboDivisionID(tdbcDivisionID, "D09", True, gbUnicode)

        'Load tdbcPITDecimal01
        sSQL = "select '-5' as PITDecimal" & vbCrLf
        sSQL &= "union all" & vbCrLf
        sSQL &= "select '-4' as PITDecimal" & vbCrLf
        sSQL &= "union all" & vbCrLf
        sSQL &= "select '-3' as PITDecimal" & vbCrLf
        sSQL &= "union all" & vbCrLf
        sSQL &= "select '-2' as PITDecimal" & vbCrLf
        sSQL &= "union all" & vbCrLf
        sSQL &= "select '-1' as PITDecimal" & vbCrLf
        sSQL &= "union all" & vbCrLf
        sSQL &= "select '0' as PITDecimal" & vbCrLf
        sSQL &= "union all" & vbCrLf
        sSQL &= "select '1' as PITDecimal" & vbCrLf
        sSQL &= "union all" & vbCrLf
        sSQL &= "select '2' as PITDecimal" & vbCrLf
        sSQL &= "union all" & vbCrLf
        sSQL &= "select '3' as PITDecimal" & vbCrLf
        sSQL &= "union all" & vbCrLf
        sSQL &= "select '4' as PITDecimal" & vbCrLf
        sSQL &= "union all" & vbCrLf
        sSQL &= "select '5' as PITDecimal" & vbCrLf

        Dim dtPITDecimal As DataTable = ReturnDataTable(sSQL)

        'Load tdbcPITDecimal01
        LoadDataSource(tdbcPITDecimal01, dtPITDecimal.Copy, gbUnicode)

        'Load tdbcPITDecimal02
        LoadDataSource(tdbcPITDecimal02, dtPITDecimal.Copy, gbUnicode)

        'Load tdbcPITDecimal03
        LoadDataSource(tdbcPITDecimal03, dtPITDecimal.Copy, gbUnicode)

        LoadDataSource(tdbcAttShareUserID, SQLStoreD00P0050, gbUnicode)

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD00P0050
    '# Created User: NGOCTHOAI
    '# Created Date: 14/07/2014 09:59:22
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD00P0050() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon combo Nguoi tao phieu luong sau san cong " & vbCrLf)
        sSQL &= "Exec LEMONSYS..D00P0050 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdDivisionID
        sSQL = "Select DivisionID, DivisionName" & UnicodeJoin(gbUnicode) & " as DivisionName, 1 as DisplayOrder " & vbCrLf
        sSQL &= "FROM 		D91T0016   WITH (NOLOCK)  " & vbCrLf
        sSQL &= "WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, DivisionName"
        LoadDataSource(tdbdDivisionID, sSQL, gbUnicode)

        'Load tdbdSalAdjMethodID
        sSQL = "-- DD Phuong phap dieu chinh (Tab – Dieu chinh luong)" & vbCrLf
        sSQL &= "SELECT ID AS SalAdjMethodID, Name" & gsLanguage & UnicodeJoin(gbUnicode) & " as SalAdjustmentMethodName " & vbCrLf
        sSQL &= "FROM 	D13N5555('D13F0001', 'SalAdjustment', '', '', '')" & vbCrLf
        LoadDataSource(tdbdSalAdjMethodID, sSQL, gbUnicode)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'If _FormState =                                                                                                                                                                                                                                          Then End
        Me.Close()
    End Sub

    Private Sub D13F0001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
        If e.Alt Then
            If (e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1) Then
                tabSystem.SelectedIndex = 0
                tabSystem.Focus()
            ElseIf (e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2) Then
                tabSystem.SelectedIndex = 1
                tabSystem.Focus()
            ElseIf (e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3) Then
                tabSystem.SelectedIndex = 2
                tabSystem.Focus()
            ElseIf (e.KeyCode = Keys.D4 Or e.KeyCode = Keys.NumPad4) Then
                tabSystem.SelectedIndex = 3
                tabSystem.Focus()
            ElseIf (e.KeyCode = Keys.D5 Or e.KeyCode = Keys.NumPad5) Then
                tabSystem.SelectedIndex = 4
                tabSystem.Focus()
            ElseIf (e.KeyCode = Keys.D6 Or e.KeyCode = Keys.NumPad6) Then
                tabSystem.SelectedIndex = 5
                tabSystem.Focus()
            ElseIf (e.KeyCode = Keys.D7 Or e.KeyCode = Keys.NumPad7) Then
                tabSystem.SelectedIndex = 6
                tabSystem.Focus()
            End If
        End If
    End Sub

    Private Sub D13F0001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _FormState
        Loadlanguage()
        InputDateInTrueDBGrid(tdbg, COL_DateFrom, COL_DateTo)
        InputDateInTrueDBGrid(tdbg1, COL_DateFrom, COL_DateTo)
        InputDateInTrueDBGrid(tdbgMinSalary, COLMS_MSDateFrom, COLMS_MSDateTo)
        tdbgSalAdj.Columns(COLS_SalAdjustmentDate).Editor = c1dateSalAdjustmentDate
        tdbg_LockedColumns()
        tdbg1_LockedColumns()
        tdbg_NumberFormat()
        tdbg1_NumberFormat()
        tdbgSalAdj_LockedColumns()
        tdbgAuto_LockedColumns()
        InputC1NumbericTDBGridMinSalary()
        tdbgMinSalary.Columns(COLMS_DivisionID).DefaultValue = ""

        SetBackColorObligatory()
        CheckPermission()
        LoadTDBCombo()
        LoadTDBDropDown() ' update 17/9/2013 id 58801
        LoadEdit()
        LoadPeriodNumberAndDefaultPeriod()
        LoadAttPeriodDate()

        'Chặn dấu và kí tự dễ gây lỗi
        CheckIdTextBox(txtSeverancePayFormula, 250, True)

        InputbyUnicode(Me, gbUnicode)

        SetResolutionForm(Me)
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DateFrom).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_SelfDeductionAmt).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub tdbg1_LockedColumns()
        tdbg1.Splits(SPLIT0).DisplayColumns(COL_DateFrom).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg1_NumberFormat()
        tdbg1.Columns(COL_SelfDeductionAmt).NumberFormat = DxxFormat.DefaultNumber0
    End Sub

    Private Sub tdbgAuto_LockedColumns()
        tdbgAuto.Splits(SPLIT0).DisplayColumns(COLA_BenefitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgAuto.Splits(SPLIT0).DisplayColumns(COLA_BenefitName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub



    Private Sub InputC1NumbericTDBGridMinSalary()
        Dim arrCol() As FormatColumn = Nothing 'Mảng lưu trữ định dạng của cột số
        'Thêm cột số có kiểu dữ liệu là Decimal
        AddDecimalColumns(arrCol, tdbgMinSalary.Columns(COLMS_MinSalary).DataField, DxxFormat.DefaultNumber2, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm

        'Định dạng các cột số trên lưới
        InputNumber(tdbgMinSalary, arrCol)
    End Sub

    Private Sub tdbgSalAdj_LockedColumns()
        tdbgSalAdj.Splits(SPLIT0).DisplayColumns(COLS_SalParameterName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub


    Private Sub SetBackColorObligatory()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_SelfDeductionAmt).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg1.Splits(SPLIT0).DisplayColumns(COL_SelfDeductionAmt).Style.BackColor = COLOR_BACKCOLOROBLIGATORY

        tdbgMinSalary.Splits(SPLIT0).DisplayColumns(COLMS_MinSalary).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgMinSalary.Splits(SPLIT0).DisplayColumns(COLMS_MSDateFrom).Style.BackColor = COLOR_BACKCOLOROBLIGATORY

        tdbgSalAdj.Splits(SPLIT0).DisplayColumns(COLS_SalAdjMethodID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbgSalAdj.Splits(SPLIT0).DisplayColumns(COLS_SalAdjustmentDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub CheckPermission()
        Dim per As Integer = ReturnPermission(Me.Name) 'Dùng kiểm tra form đang ở quyền nào
        If per = 1 Then
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If
    End Sub

    'Append 12/08/2009
    Private Sub LoadAttPeriodDate()
        Dim dt As DataTable = ReturnDataTable("Select AttPeriodFrom,AttPeriodTo, IsAdvancedPeriod, AdvancedPeriodFrom, AdvancePeriodTo From D29T0000 WITH (NOLOCK) ")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                txtAttPeriodFrom.Text = .Item("AttPeriodFrom").ToString
                txtAttPeriodTo.Text = .Item("AttPeriodTo").ToString
                chkIsAdvancedPeriod.Checked = L3Bool(.Item("IsAdvancedPeriod"))
                txtAdvancedPeriodFrom.Text = .Item("AdvancedPeriodFrom").ToString
                txtAdvancePeriodTo.Text = .Item("AdvancePeriodTo").ToString
            End With
        End If
    End Sub

    Private Sub LoadEdit()
        tdbcDivisionID.SelectedValue = D13Systems.DefaultDivisionID
        tdbcDivisionID.Tag = D13Systems.DefaultDivisionID
        chkIsUsedPAna.Tag = D13Systems.IsUsedPAna.ToString
        chkIsSalOtherDiv.Tag = D13Systems.IsSalOtherDiv.ToString

        Dim dt As DataTable = ReturnDataTable("Select * From D13T0000 WITH (NOLOCK) ")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                txtSeverancePayFormula.Text = .Item("SeverancePayFormula").ToString
                Select Case L3Int(.Item("SeverancePayMode")) ' SafeCInt()
                    Case 0
                        optPresent.Checked = True
                    Case 1
                        optNearestAverage.Checked = True
                    Case 2
                        optAllTimeAverage.Checked = True
                End Select

                cneNearestMonth.Value = .Item("Months").ToString
                txtSenderAddress.Text = .Item("SenderAddress").ToString
                txtMailServer.Text = .Item("MailServer").ToString
                chkIsTransferEmail.Checked = CBool(IIf(.Item("IsTransferEmail").ToString = "", 0, .Item("IsTransferEmail").ToString))
                chkIsBelongCicle.Checked = CBool(IIf(.Item("IsBelongCicle").ToString = "", 0, .Item("IsBelongCicle").ToString))

                tdbcPITDecimal01.Text = .Item("PITDecimal01").ToString
                tdbcPITDecimal02.Text = .Item("PITDecimal02").ToString
                tdbcPITDecimal03.Text = .Item("PITDecimal03").ToString
                txtResidenceDay.Text = .Item("ResidenceDay").ToString
                txtResidenceDay1.Text = .Item("ResidenceDay").ToString
                txtContinuousMonth.Text = .Item("ContinuousMonth").ToString
                txtCCAddress.Text = .Item("CCAddress").ToString
                txtBCCAddress.Text = .Item("BCCAddress").ToString
                chkIsUsedPAna.Checked = L3Bool(.Item("IsUsedPAna"))
                'ID 106495 21.03.2018
                chkIsSalOtherDiv.Checked = L3Bool(.Item("IsSalOtherDiv"))

                '14/7/2014, id 58418-Tự động san công khi tính lương vá tính lương với dữ liệu sau san công
                chkIsAutoAttShare.Checked = L3Bool(.Item("IsAutoAttShare"))
                tdbcAttShareUserID.Text = .Item("AttShareUserID").ToString
                If chkIsAutoAttShare.Checked = True Then
                    UnReadOnlyControl(tdbcAttShareUserID)
                Else
                    ReadOnlyControl(tdbcAttShareUserID)
                End If
                chkIsPayrollProject.Checked = L3Bool(.Item("IsPayrollProject"))
            End With
        Else
            optPresent.Checked = True
            tdbcPITDecimal01.Text = "0"
            tdbcPITDecimal02.Text = "0"
            tdbcPITDecimal03.Text = "0"
        End If

        LoadTDBGrid()
        LoadtdbgMinSalaryrid() ' update 17/9/2013 id 58801
        LoadTDBGSalAdj()
        LoadtdbgAuto()
    End Sub

    Private Sub LoadtdbgMinSalaryrid()
        Dim sSQL As String = "-- Load luoi Luong toi thieu" & vbCrLf
        sSQL &= "SELECT 		T1.DivisionID, T1.TransID, MinSalary, MSDateFrom, MSDateTo" & vbCrLf
        sSQL &= "FROM 		D13T0002 T1 WITH (NOLOCK)  " & vbCrLf
        sSQL &= "LEFT JOIN 	D91T0016  T2  WITH (NOLOCK) On T1.DivisionID = T2.DivisionID " & vbCrLf
        If chkIsDisplayValid.Checked Then
            sSQL &= "WHERE (convert(varchar(10),MSDateTo,101) >= convert(varchar(10),GETDATE(),101)) OR ISNULL(MSDateTo,'') = ''" & vbCrLf
        End If
        sSQL &= "ORDER BY 	T1.DivisionID, MSDateFrom"

        bGridMinChanged = False
        dtGridMinSalary = ReturnDataTable(sSQL)
        LoadDataSource(tdbgMinSalary, dtGridMinSalary, gbUnicode)
    End Sub

    Private Sub LoadtdbgAuto()
        Dim sSQL As String = "-- Load luoi tab Tu dong" & vbCrLf
        sSQL &= "SELECT 		BenefitID, BenefitName" & UnicodeJoin(gbUnicode) & " as BenefitName, CONVERT(BIT, IsAdvancePayroll) AS IsAdvancePayroll, CONVERT(BIT, IsMainPayroll) AS IsMainPayroll " & vbCrLf
        sSQL &= "FROM 		D52T1010 WITH (NOLOCK)  " & vbCrLf
        sSQL &= "WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY BenefitID "

        LoadDataSource(tdbgAuto, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = "SELECT * FROM D13T0001  WITH (NOLOCK) ORDER BY TransID"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim dt1 As DataTable
        Dim dt2 As DataTable

        dt.DefaultView.RowFilter = "DAType = 'SDA'"
        dt1 = dt.DefaultView.ToTable
        dt.DefaultView.RowFilter = "DAType = 'FDA'"
        dt2 = dt.DefaultView.ToTable
        LoadDataSource(tdbg, dt1, gbUnicode)
        LoadDataSource(tdbg1, dt2, gbUnicode)
    End Sub

    Private Sub LoadTDBGSalAdj()
        Dim sSQL As String = SQLStoreD13P0003()
        dtGridSalAdj = ReturnDataTable(sSQL)
        LoadDataSource(tdbgSalAdj, dtGridSalAdj, gbUnicode)
    End Sub

    Private Sub LoadPeriodNumberAndDefaultPeriod()
        Dim sSQL As String = "Select PeriodNumber From D91T0025 WITH (NOLOCK) "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dt.Rows.Count - 1
            txtPeriodNumber.Text = dt.Rows(i).Item("PeriodNumber").ToString
        Next
        sSQL = "Select Top 1 Replace(Str(TranMonth, 2), ' ', '0') + '/' + LTrim(Str(TranYear)) As DefaultPeriod From D09T9999 D13  WITH (NOLOCK) Where D13.DivisionID = " & SQLString(tdbcDivisionID.SelectedValue) & " Order By (TranYear * 100 + TranMonth) Desc"
        Dim dt1 As DataTable = ReturnDataTable(sSQL)
        For i As Integer = 0 To dt1.Rows.Count - 1
            txtDefaultPeriod.Text = dt1.Rows(i).Item("DefaultPeriod").ToString
        Next
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim sSQL As String = ""
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim drSalAdj() As DataRow = Nothing
        If Not AllowSave(drSalAdj) Then Exit Sub


        Select Case _FormState
            Case EnumFormState.FormAdd
                'Dữ liệu trong bảng D13T0000 chỉ có 1 dòng duy nhất
                'Nên trước khi Insert thì xóa dữ liệu rác
                sSQL = SQLDeleteD13T0000().ToString() & vbCrLf
                sSQL &= SQLInsertD13T0000().ToString() & vbCrLf

                ' Update 21/2/2012 incident 50602
                If Not chkIsUsedPAna.Checked Then
                    sSQL &= SQLUpdateD13T0050().ToString() & vbCrLf
                End If
            Case EnumFormState.FormEdit
                sSQL = SQLUpdateD13T0000().ToString() & vbCrLf
                ' Update 21/2/2012 incident 50602
                If Not chkIsUsedPAna.Checked Then
                    sSQL &= SQLUpdateD13T0050().ToString() & vbCrLf
                End If

        End Select
        sSQL &= SQLDeleteD13T0001().ToString() & vbCrLf
        sSQL &= SQLInsertD13T0001s().ToString() & vbCrLf
        ' update 17/9/2013 id 58801
        sSQL &= SQLDeleteD13T0002() & vbCrLf
        sSQL &= SQLInsertD13T0002s().ToString()
        ' update 30/9/2013 id 58972
        sSQL &= SQLDeleteD13T0003() & vbCrLf
        sSQL &= SQLInsertD13T0003s(drSalAdj).ToString() & vbCrLf

        sSQL &= SQLUpdateD52T1010s.ToString ' 13/2/2014 id 60909

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            'Update 21/2/2012 incident 50602
            UpadateSystems()
            _bSaved = True
            If _FormState = EnumFormState.FormEdit Then
                If tdbcDivisionID.Tag.ToString <> tdbcDivisionID.SelectedValue.ToString Or chkIsUsedPAna.Tag.ToString <> chkIsUsedPAna.Checked.ToString Or chkIsSalOtherDiv.Tag.ToString <> chkIsSalOtherDiv.Checked.ToString Then
                    'D99C0008.MsgSetUpDivision()
                    D99C0008.MsgL3(rL3("Ban_phai_khoi_dong_lai_module_thi_thiet_lap_moi_co_tac_dung"))
                Else
                    SaveOK()
                End If
            Else
                SaveOK()
            End If
        Else
            SaveNotOK()
        End If
        Me.Close()
    End Sub

    Private Function AllowSaveTabSalAdj(ByRef drSalAdj() As DataRow) As Boolean
        tdbgSalAdj.UpdateData()
        dtGridSalAdj.AcceptChanges()

        drSalAdj = dtGridSalAdj.Select("IsSelected=1")
        For i As Integer = 0 To drSalAdj.Length - 1
            If drSalAdj(i).Item("SalAdjMethodID").ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Phuong_phap_dieu_chinh"))
                tabSystem.SelectedTab = tabSalAdj
                tdbgSalAdj.Focus()
                tdbgSalAdj.SplitIndex = SPLIT0
                tdbgSalAdj.Col = COLS_SalAdjMethodID
                tdbgSalAdj.Row = dtGridSalAdj.Rows.IndexOf(drSalAdj(i))
                Return False
            End If
            If drSalAdj(i).Item("SalAdjustmentDate").ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay_xet_dieu_chinh"))
                tabSystem.SelectedTab = tabSalAdj
                tdbgSalAdj.Focus()
                tdbgSalAdj.SplitIndex = SPLIT0
                tdbgSalAdj.Col = COLS_SalAdjustmentDate
                tdbgSalAdj.Row = dtGridSalAdj.Rows.IndexOf(drSalAdj(i))
                Return False
            End If
        Next
        Return True
    End Function

    Private Function AllowSaveTabMinSalary() As Boolean
        tdbgMinSalary.UpdateData()
        dtGridMinSalary.AcceptChanges()
        Dim dtDivision As DataTable = dtGridMinSalary.DefaultView.ToTable(True, "DivisionID")
        For i As Integer = 0 To dtDivision.Rows.Count - 1
            Dim dr() As DataRow = dtGridMinSalary.Select("DivisionID=" & SQLString(dtDivision.Rows(i).Item("DivisionID")))
            For j As Integer = 0 To dr.Length - 1
                If Number(dr(j).Item("MinSalary")) <= 0 Then
                    D99C0008.MsgNotYetEnter(rl3("Luong_toi_thieu"))
                    tabSystem.SelectedTab = tabMinSalary
                    tdbgMinSalary.Focus()
                    tdbgMinSalary.SplitIndex = SPLIT0
                    tdbgMinSalary.Col = COLMS_MinSalary
                    tdbgMinSalary.Row = dtGridMinSalary.Rows.IndexOf(dr(j))
                    Return False
                End If
                If dr(j).Item("MSDateFrom").ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Ngay_hieu_luc_U"))
                    tabSystem.SelectedTab = tabMinSalary
                    tdbgMinSalary.Focus()
                    tdbgMinSalary.SplitIndex = SPLIT0
                    tdbgMinSalary.Col = COLMS_MSDateFrom
                    tdbgMinSalary.Row = dtGridMinSalary.Rows.IndexOf(dr(j))
                    Return False
                End If
                If j < dr.Length - 1 Then ' các dòng trước đó
                    If dr(j).Item("MSDateTo").ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Ngay_het_hieu_luc"))
                        tabSystem.SelectedTab = tabMinSalary
                        tdbgMinSalary.Focus()
                        tdbgMinSalary.SplitIndex = SPLIT0
                        tdbgMinSalary.Col = COLMS_MSDateTo
                        tdbgMinSalary.Row = dtGridMinSalary.Rows.IndexOf(dr(j))
                        Return False
                    End If
                    If CDate(dr(j).Item("MSDateFrom")) > CDate(dr(j).Item("MSDateTo")) Then
                        D99C0008.MsgL3(rl3("Hieu_luc_tu_khong_duoc_lon_hon_Hieu_luc_den"))
                        tabSystem.SelectedTab = tabMinSalary
                        tdbgMinSalary.Focus()
                        tdbgMinSalary.SplitIndex = SPLIT0
                        tdbgMinSalary.Col = COLMS_MSDateTo
                        tdbgMinSalary.Row = dtGridMinSalary.Rows.IndexOf(dr(j))
                        Return False
                    End If
                    ' Kiểm tra ngày từ của dòng trước phải bằng ngày đến của dòng tiếp theo
                    If dr(j + 1).Item("MSDateFrom").ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Ngay_hieu_luc_U"))
                        tabSystem.SelectedTab = tabMinSalary
                        tdbgMinSalary.Focus()
                        tdbgMinSalary.SplitIndex = SPLIT0
                        tdbgMinSalary.Col = COLMS_MSDateFrom
                        tdbgMinSalary.Row = dtGridMinSalary.Rows.IndexOf(dr(j + 1))
                        Return False
                    End If
                    ' Kiểm tra ngày từ của dòng trước phải bằng ngày đến của dòng tiếp theo
                    If CDate(dr(j).Item("MSDateTo")).Date >= CDate(dr(j + 1).Item("MSDateFrom")).Date Then
                        D99C0008.MsgL3(rl3("MSG000009"))
                        tabSystem.SelectedTab = tabMinSalary
                        tdbgMinSalary.Focus()
                        tdbgMinSalary.SplitIndex = SPLIT0
                        tdbgMinSalary.Col = COLMS_MSDateFrom
                        tdbgMinSalary.Row = dtGridMinSalary.Rows.IndexOf(dr(j + 1))
                        Return False
                    End If
                Else
                    If dr(j).Item("MSDateTo").ToString <> "" Then
                        If CDate(dr(j).Item("MSDateFrom")) > CDate(dr(j).Item("MSDateTo")) Then
                            D99C0008.MsgL3(rl3("Hieu_luc_tu_khong_duoc_lon_hon_Hieu_luc_den"))
                            tabSystem.SelectedTab = tabMinSalary
                            tdbgMinSalary.Focus()
                            tdbgMinSalary.SplitIndex = SPLIT0
                            tdbgMinSalary.Col = COLMS_MSDateTo
                            tdbgMinSalary.Row = dtGridMinSalary.Rows.IndexOf(dr(j))
                            Return False
                        End If
                    End If

                End If
            Next
        Next

        Return True
    End Function

    Private Function AllowSave(ByRef drSalAdj() As DataRow) As Boolean
        If tdbcDivisionID.Text = "" Then
            tabSystem.SelectedTab = TabPageMainInfo
            D99C0008.MsgNotYetEnter(rL3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If

        If cneNearestMonth.Text <> "" AndAlso CDec(cneNearestMonth.Text) > 6 Then
            D99C0008.MsgL3(rL3("Gia_tri_binh_quan_thang_gan_nhat_phai_nho_hon_hoac_bang_6"))
            tabSystem.SelectedTab = tabpage2
            cneNearestMonth.Focus()
            Return False
        End If

        tdbg.UpdateData()
        tdbg1.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tabSystem.SelectedTab = TabPage3
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_DateTo
            tdbg.Bookmark = 0
            Return False
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_DateFrom).ToString <> "" And tdbg(i, COL_DateTo).ToString <> "" Then
                If CDate(tdbg(i, COL_DateFrom).ToString) > CDate(tdbg(i, COL_DateTo).ToString) Then
                    D99C0008.MsgL3(rL3("MSG000013"))
                    tabSystem.SelectedTab = TabPage3
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_DateTo
                    tdbg.Bookmark = i
                    Return False
                End If
            End If
            If tdbg(i, COL_SelfDeductionAmt).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_giam_tru_ban_than"))
                tabSystem.SelectedTab = TabPage3
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_SelfDeductionAmt
                tdbg.Bookmark = i
                Return False
            Else
                If tdbg(i, COL_DateTo).ToString = "" AndAlso i <> tdbg.RowCount - 1 Then
                    D99C0008.MsgNotYetEnter(rL3("Den_ngay"))
                    tabSystem.SelectedTab = TabPage3
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_DateTo
                    tdbg.Bookmark = i
                    Return False
                End If
            End If
        Next

        If tdbg1.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg1.Focus()
            tdbg1.SplitIndex = SPLIT0
            tdbg1.Col = COL_DateTo
            tdbg1.Bookmark = 0
            Return False
        End If


        For i As Integer = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COL_DateFrom).ToString <> "" And tdbg1(i, COL_DateTo).ToString <> "" Then
                If CDate(tdbg1(i, COL_DateFrom).ToString) > CDate(tdbg1(i, COL_DateTo).ToString) Then
                    D99C0008.MsgL3(rL3("MSG000013"))
                    tabSystem.SelectedTab = TabPage3
                    tdbg1.Focus()
                    tdbg1.SplitIndex = SPLIT0
                    tdbg1.Col = COL_DateTo
                    tdbg1.Bookmark = i
                    Return False
                End If
            End If
            If tdbg1(i, COL_SelfDeductionAmt).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Muc_giam_tru_gia_canh"))
                tabSystem.SelectedTab = TabPage3
                tdbg1.Focus()
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Col = COL_SelfDeductionAmt
                tdbg1.Bookmark = i
                Return False
            Else
                If tdbg1(i, COL_DateTo).ToString = "" AndAlso i <> tdbg1.RowCount - 1 Then
                    D99C0008.MsgNotYetEnter(rL3("Den_ngay"))
                    tabSystem.SelectedTab = TabPage3
                    tdbg1.Focus()
                    tdbg1.SplitIndex = SPLIT0
                    tdbg1.Col = COL_DateTo
                    tdbg1.Bookmark = i
                    Return False
                End If
            End If
        Next


        If Not AllowSaveTabMinSalary() Then
            Return False
        End If


        If Not AllowSaveTabSalAdj(drSalAdj) Then
            Return False
        End If

        Return True
    End Function

    Private Sub UpadateSystems()
        With D13Systems
            .DefaultDivisionID = tdbcDivisionID.Text
            .IsUsedPAna = chkIsUsedPAna.Checked
            .IsPayrollProject = chkIsPayrollProject.Checked
            .IsSalOtherDiv = chkIsSalOtherDiv.Checked
        End With
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0000
    '# Created User: Lê Văn Phước
    '# Created Date: 25/07/2006 01:50:27
    '# Modified User: 
    '# Modified Date: 21/8/2012 - bổ sung chkIsUsedPAna
    '# Description: Lưu xuống bảng D13T0000
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0000() As String
        Dim iPayMode As Integer
        If optPresent.Checked Then
            iPayMode = 0
        ElseIf optNearestAverage.Checked Then
            iPayMode = 1
        Else
            iPayMode = 2
        End If

        Dim sSQL As String = ""
        sSQL &= "Insert Into D13T0000("
        sSQL &= "DivisionID, SeverancePayFormula, SeverancePayMode, Months, SenderAddress, MailServer, "
        sSQL &= "IsBelongCicle,IsTransferEmail, PITDecimal01, PITDecimal02, PITDecimal03, ResidenceDay, "
        sSQL &= "ContinuousMonth, CCAddress, BCCAddress, IsUsedPAna, IsAutoAttShare, AttShareUserID,IsPayrollProject,IsSalOtherDiv  "
        sSQL &= ") Values ("
        sSQL &= SQLString(tdbcDivisionID.SelectedValue) & COMMA 'DivisionID, VarChar[20], NOT NULL
        sSQL &= SQLString(txtSeverancePayFormula.Text) & COMMA 'SeverancePayFormula, varchar[250], NOT NULL
        sSQL &= SQLNumber(iPayMode) & COMMA 'SeverancePayMode, tinyint, NOT NULL
        sSQL &= SQLNumber(cneNearestMonth.Text) & COMMA 'Months, tinyint, NOT NULL
        sSQL &= SQLString(txtSenderAddress.Text) & COMMA 'SenderAddress, varchar[250], NOT NULL
        sSQL &= SQLString(txtMailServer.Text) & COMMA 'MailServer, varchar[250], NOT NULL
        sSQL &= SQLNumber(chkIsBelongCicle.Checked) & COMMA 'IsBelongCicle, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsTransferEmail.Checked) & COMMA 'IsNewTransferMode, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPITDecimal01.Text) & COMMA 'PITDecimal01, int, NOT NULL
        sSQL &= SQLNumber(tdbcPITDecimal02.Text) & COMMA 'PITDecimal02, int, NOT NULL
        sSQL &= SQLNumber(tdbcPITDecimal03.Text) & COMMA 'PITDecimal03, int, NOT NULL
        sSQL &= SQLNumber(txtResidenceDay.Text) & COMMA 'ResidenceDay, int, NOT NULL
        sSQL &= SQLNumber(txtContinuousMonth.Text) & COMMA 'ContinuousMonth, int, NOT NULL
        sSQL &= SQLString(txtCCAddress.Text) & COMMA 'CCAddress, varchar[250], NOT NULL
        sSQL &= SQLString(txtBCCAddress.Text) & COMMA 'BCCAddressCCAddress, varchar[250], NOT NULL
        sSQL &= SQLNumber(chkIsUsedPAna.Checked) & COMMA
        sSQL &= SQLNumber(chkIsAutoAttShare.Checked) & COMMA 'IsAutoAttShare
        sSQL &= SQLString(tdbcAttShareUserID.Text) & COMMA 'AttShareUserID
        sSQL &= SQLNumber(chkIsPayrollProject.Checked) & COMMA 'IsPayrollProject
        sSQL &= SQLNumber(chkIsSalOtherDiv.Checked) 'IsSalOtherDiv
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0000
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 14/04/2008 11:22:56
    '# Modified User: 
    '# Modified Date: 21/8/2012 - bổ sung chkIsUsedPAna
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0000() As StringBuilder
        Dim iPayMode As Integer
        If optPresent.Checked Then
            iPayMode = 0
        ElseIf optNearestAverage.Checked Then
            iPayMode = 1
        Else
            iPayMode = 2
        End If
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Luu thiet la he thong" & vbCrLf)
        sSQL.Append("Update D13T0000 Set ")
        sSQL.Append("DivisionID = " & SQLString(tdbcDivisionID.SelectedValue) & COMMA) 'varchar[20], NULL
        sSQL.Append("SeverancePayFormula = " & SQLString(txtSeverancePayFormula.Text) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("SeverancePayMode = " & SQLNumber(iPayMode) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("Months = " & SQLNumber(cneNearestMonth.Text) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("SenderAddress = " & SQLString(txtSenderAddress.Text) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MailServer = " & SQLString(txtMailServer.Text) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("IsBelongCicle = " & SQLNumber(chkIsBelongCicle.Checked) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("IsTransferEmail = " & SQLNumber(chkIsTransferEmail.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("PITDecimal01 = " & SQLNumber(tdbcPITDecimal01.Text) & COMMA) 'int, NOT NULL
        sSQL.Append("PITDecimal02 = " & SQLNumber(tdbcPITDecimal02.Text) & COMMA) 'int, NOT NULL
        sSQL.Append("PITDecimal03 = " & SQLNumber(tdbcPITDecimal03.Text) & COMMA) 'int, NOT NULL
        sSQL.Append("ResidenceDay = " & SQLNumber(txtResidenceDay.Text) & COMMA) 'int, NOT NULL
        sSQL.Append("ContinuousMonth = " & SQLNumber(txtContinuousMonth.Text) & COMMA) 'int, NOT NULL
        sSQL.Append("CCAddress = " & SQLString(txtCCAddress.Text) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("BCCAddress = " & SQLString(txtBCCAddress.Text) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("IsUsedPAna = " & SQLNumber(chkIsUsedPAna.Checked) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("IsAutoAttShare = " & SQLNumber(chkIsAutoAttShare.Checked) & COMMA) 'IsAutoAttShare
        sSQL.Append("IsPayrollProject  = " & SQLNumber(chkIsPayrollProject.Checked) & COMMA) 'IsPayrollProject 
        sSQL.Append("IsSalOtherDiv  = " & SQLNumber(chkIsSalOtherDiv.Checked) & COMMA) 'IsSalOtherDiv 
        sSQL.Append("AttShareUserID = " & SQLString(tdbcAttShareUserID.Text)) 'AttShareUserID
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0000
    '# Create User: Nguyễn Thị Minh Hòa
    '# Create Date: 27/07/2006 09:49:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: Xóa bảng D13T0000
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0000() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0000"
        Return sSQL
    End Function

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Thiet_lap_he_thong_-_D13F0001") & UnicodeCaption(gbUnicode) 'ThiÕt lËp hÖ thçng - D13F0001
        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi_mac_dinh") 'Đơn vị mặc định
        lblDefaultPeriod.Text = rl3("Ky_ke_toan_mac_dinh") 'Kỳ kế toán mặc định
        lblNumberPeriod.Text = rl3("So_ky_ke_toan") 'Số kỳ kế toán
        lblNearestMonth.Text = "(" & rl3("Thang_gan_nhat") & ")" 'Tháng gần nhất
        lblSeverancePayFormula.Text = rl3("Luong_tro_cap_thoi_viec") 'Lương trợ cấp thôi việc
        lblMailServer.Text = rl3("Dia_chi_may_chu") 'Địa chỉ máy chủ
        lblSenderAddress.Text = rl3("Dia_chi_mail_nguoi_gui") 'Địa chỉ mail người gửi
        lblFromDate.Text = rl3("Tu_ngay")
        lblAttPeriodTo.Text = rl3("Den_ngay")

        lblContinuousMonth.Text = rl3("thang_lien_tuc") 'tháng liên tục
        lbldate2.Text = rl3("ngay_va_du") 'ngày và đủ
        lblor.Text = rl3("hoac") 'hoặc
        lbldate.Text = rl3("Ngay") 'ngày
        lblInVietNam.Text = rl3("Co_mat_tai_VN") 'Có mặt tại VN
        lblPITDecimal03.Text = rl3("Tong_thue") 'Tổng thuế
        lblPITDecimal02.Text = rl3("Thue_phai_nop_1_thang") 'Thuế phải nộp 1 tháng
        lblPITDecimal01.Text = rl3("Thu_nhap_binh_quan_chiu_thue") 'Thu nhập bình quân chịu thuế

        lblRound.Text = rl3("Lam_tron") 'Làm tròn
        lblResidentPersonalCondition.Text = rl3("Dieu_kien_ca_nhan_cu_tru") 'Điều kiện cá nhân cư trú

        lblCC.Text = rl3("Dia_chi_mail_CC")
        lblBCC.Text = rl3("Dia_chi_mail_BCC")
        lblAdvancedPeriodFrom.Text = rl3("Tu_ngay")
        lblAdvancePeriodTo.Text = rl3("Den_ngay")
        lblAuto.Text = rl3("Tu_dong_tinh_chinh_sach_khi_tinh_luong") 'Tự động tính chính sách khi tính lương
        lblAttShareUserID.Text = rL3("Nguoi_tao_phieu_luong_sau_san_cong") 'Người tạo phiếu lương sau san công
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnFormulaSelect.Text = rL3("Cong_thuc") 'Công thức
        '================================================================ 
        chkIsTransferEmail.Text = rl3("Chuyen_bang_luong_qua_e-mail") 'Chuyển bảng lương qua e-mail
        chkIsBelongCicle.Text = rl3("HSL_thang_phu_thuoc_ky_tinh_luong") 'HSL tháng phụ thuộc kỳ tính lương
        chkIsUsedPAna.Text = rl3("Su_dung_ma_phan_tich_tien_luong")
        chkIsDisplayValid.Text = rl3("Chi_hien_thi_nhung_dong_con_hieu_luc") 'Chỉ hiển thị những dòng còn hiệu lực
        chkIsAdvancedPeriod.Text = rL3("Chu_ky_luong_ung") ' Chu kỳ lương ứng
        chkIsAutoAttShare.Text = rL3("Tu_dong_san_cong_sau_khi_tinh_luong") 'Tự động san công sau khi tính lương
        '================================================================ 
        chkIsSalOtherDiv.Text = rL3("Hien_thi_luoi_luong_ngoai") 'Hiển thị lưới lương ngoài

        '================================================================ 
        optAllTimeAverage.Text = rl3("Binh_quan_toan_thoi_gian") 'Bình quân toàn thời gian
        optNearestAverage.Text = rl3("Binh_quan") 'Bình quân
        optPresent.Text = rl3("Luong_hien_tai") 'Lương hiện tại
        '================================================================ 
        grpPeriodOfSeverancePay.Text = rl3("Thoi_gian_tinh_luong_tro_cap_thoi_viec") 'Thời gian tính lương trợ cấp thôi việc
        grpFormula.Text = rl3("Cong_thuc") 'Công thức
        grpGroup2.Text = rl3("Ky_tinh_luong") 'Kỳ tính lương
        grpSelfDeductionAmt.Text = rl3("Giam_tru_ban_than") 'Giảm trừ bản thân
        grpSelfDeductionAmt1.Text = rl3("Giam_tru_gia_canh")
        '================================================================ 
        TabPageMainInfo.Text = "1. " & rl3("Thong_tin_chinh") 'Thông tin chính
        tabpage2.Text = "2. " & rl3("Tro_cap_thoi_viec") 'Trợ cấp thôi việc
        TabPage1.Text = "3. " & rl3("Chuyen_luong_qua_e-mail") 'Chuyển lương qua e-mail
        TabPage3.Text = "4. " & rl3("Thue_TNCN") 'Thuế TNCN
        tabMinSalary.Text = "5. " & rl3("Luong_toi_thieu") 'Thuế TNCN
        tabSalAdj.Text = "6. " & rl3("Dieu_chinh_luong") 'Điều chỉnh lương
        tabAuto.Text = "7. " & rl3("Tu_dong") 'Tự động
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên
        tdbcAttShareUserID.Columns("UserID").Caption = rL3("Ma") 'Mã
        tdbcAttShareUserID.Columns("UserName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("DateFrom").Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rl3("Den_ngay") 'Đến ngày
        tdbg.Columns("SelfDeductionAmt").Caption = rl3("Muc_giam_tru") 'Mức giảm trừ

        tdbg1.Columns("DateFrom").Caption = rl3("Tu_ngay") 'Từ ngày
        tdbg1.Columns("DateTo").Caption = rl3("Den_ngay") 'Đến ngày
        tdbg1.Columns("SelfDeductionAmt").Caption = rl3("Muc_giam_tru") 'Mức giảm trừ

        tdbgMinSalary.Columns("DivisionID").Caption = rl3("Don_vi")
        tdbgMinSalary.Columns("MinSalary").Caption = rl3("Luong_toi_thieu")
        tdbgMinSalary.Columns("MSDateFrom").Caption = rl3("Ngay_hieu_luc_U")
        tdbgMinSalary.Columns("MSDateTo").Caption = rl3("Ngay_het_hieu_luc")

        tdbgSalAdj.Columns(COLS_IsSelected).Caption = rl3("Chon") 'Chọn
        tdbgSalAdj.Columns(COLS_SalParameterName).Caption = rl3("Thong_so_luong") 'Thông số lương
        tdbgSalAdj.Columns(COLS_SalAdjMethodID).Caption = rl3("Phuong_phap_dieu_chinh") 'Phương pháp điều chỉnh
        tdbgSalAdj.Columns(COLS_SalAdjustmentDate).Caption = rl3("Ngay_xet_dieu_chinh") 'Ngày xét điều chỉnh
        tdbgSalAdj.Columns(COLS_Note).Caption = rl3("Ghi_chu") 'Ghi chú

        tdbgAuto.Columns(COLA_BenefitID).Caption = rl3("Ma_chinh_sach") 'Mã chính sách
        tdbgAuto.Columns(COLA_BenefitName).Caption = rl3("Ten_chinh_sach") 'Tên chính sách
        tdbgAuto.Columns(COLA_IsAdvancePayroll).Caption = rl3("Luong_ung") 'Lương ứng
        tdbgAuto.Columns(COLA_IsMainPayroll).Caption = rL3("Luong_chinh_thuc") 'Lương chính thức
        '================================================================ 
        chkIsPayrollProject.Text = rL3("Tinh_luong_theo_du_an") 'Tính lương theo dự án

    End Sub


    Private Sub EnableTxtNearestMonth()
        If optNearestAverage.Checked Then
            cneNearestMonth.Enabled = True
        Else
            cneNearestMonth.Enabled = False
        End If
    End Sub

    Private Sub optPresent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPresent.CheckedChanged
        EnableTxtNearestMonth()
    End Sub

    Private Sub optNearestAverage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optNearestAverage.CheckedChanged
        EnableTxtNearestMonth()
    End Sub

    Private Sub optAllTimeAverage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAllTimeAverage.CheckedChanged
        EnableTxtNearestMonth()
    End Sub

    Private Sub btnFormulaSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormulaSelect.Click
        '        Dim f As New D21F0005
        '        f.ShowDialog()
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "Mode", "0")
        Dim frm As Form = CallFormShowDialog("D21D0140", "D21F0005", arrPro)
        Dim sFormula_D21F0005 As String = GetProperties(frm, "sFormula_D21F0005").ToString

        Dim iCurrentPos As Integer = txtSeverancePayFormula.SelectionStart
        Dim sFormular As String = txtSeverancePayFormula.Text
        Dim sTextBefore As String = sFormular.Substring(0, iCurrentPos)
        Dim sTextAfter As String = sFormular.Substring(iCurrentPos, sFormular.Length - iCurrentPos)
        txtSeverancePayFormula.Text = sTextBefore & sFormula_D21F0005 & sTextAfter

        ' 'txtSeverancePayFormula.Text += f.Formular
        'f.Dispose()
    End Sub

    Private Sub txtMailServer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMailServer.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "0123456789.:")
    End Sub

    Private Sub txtResidenceDay_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtResidenceDay.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtResidenceDay_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResidenceDay.LostFocus
        If Number(txtResidenceDay.Text) > MaxInt Then
            txtResidenceDay.Text = "0"
        End If
        txtResidenceDay1.Text = txtResidenceDay.Text
    End Sub

    Private Sub txtContinuousMonth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContinuousMonth.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtContinuousMonth_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContinuousMonth.LostFocus
        If Number(txtContinuousMonth.Text) > MaxInt Then
            txtContinuousMonth.Text = "0"
        End If
    End Sub

    Dim bGridMinChanged As Boolean = False
    Private Sub chkIsDisplayValid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsDisplayValid.Click
        If bGridMinChanged Then
            D99C0008.MsgL3(rl3("Ban_phai_luu_lai_du_lieu"))
            chkIsDisplayValid.Checked = Not chkIsDisplayValid.Checked
            Exit Sub
        End If
        LoadtdbgMinSalaryrid()
    End Sub

#Region "Events tdbcDivisionID with txtDivisionName"

    Private Sub tdbcDivisionID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
            txtDivisionName.Text = ""
        End If
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        txtDivisionName.Text = tdbcDivisionID.Columns(1).Value.ToString
        LoadPeriodNumberAndDefaultPeriod()
    End Sub

#End Region

#Region "Events tdbcPITDecimal01"

    Private Sub tdbcPITDecimal01_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPITDecimal01.LostFocus
        If tdbcPITDecimal01.FindStringExact(tdbcPITDecimal01.Text) = -1 Then tdbcPITDecimal01.Text = ""
    End Sub

#End Region

#Region "Events tdbcPITDecimal02"

    Private Sub tdbcPITDecimal02_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPITDecimal02.LostFocus
        If tdbcPITDecimal02.FindStringExact(tdbcPITDecimal02.Text) = -1 Then tdbcPITDecimal02.Text = ""
    End Sub

#End Region

#Region "Events tdbcPITDecimal03"

    Private Sub tdbcPITDecimal03_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPITDecimal03.LostFocus
        If tdbcPITDecimal03.FindStringExact(tdbcPITDecimal03.Text) = -1 Then tdbcPITDecimal03.Text = ""
    End Sub

#End Region

#Region "Sự kiện của tdbg"

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete 'Dòng 0 không cho phép xóa
                If tdbg.RowCount > 1 Then
                    tdbg.AllowDelete = True
                    If tdbg.Row = 0 Then e.Handled = True
                Else
                    tdbg.AllowDelete = False
                End If
            Case Keys.Enter
                '                Select Case tdbg.Col
                '                    Case COL_SelfDeductionAmt
                '                        HotKeyEnterGrid(tdbg, COL_DateTo, e, SPLIT0)
                '                End Select
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_SelfDeductionAmt
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        Select Case e.ColIndex
            Case COL_DateTo
                If tdbg.Row > 0 Then
                    tdbg.Columns(COL_DateFrom).Value = CDate(tdbg(tdbg.Row - 1, COL_DateTo).ToString).AddDays(1)
                End If
                If tdbg.Row < tdbg.RowCount - 1 Then
                    Dim sDateTo As String = tdbg.Columns(COL_DateTo).Text
                    If tdbg(tdbg.Row, COL_DateTo).ToString <> "" Then tdbg(tdbg.Row + 1, COL_DateFrom) = CDate(tdbg(tdbg.Row, COL_DateTo).ToString).AddDays(1)
                    tdbg.Columns(COL_DateTo).Text = sDateTo
                End If
                If tdbg.Row = 0 And tdbg(0, COL_DateFrom).ToString = "" Then
                    tdbg(0, COL_DateFrom) = CDate("01/07/2009")
                End If
            Case COL_SelfDeductionAmt
                If tdbg.Row > 0 Then
                    tdbg.Columns(COL_DateFrom).Value = CDate(tdbg(tdbg.Row - 1, COL_DateTo).ToString).AddDays(1)
                End If
                If tdbg.Row = 0 And tdbg(0, COL_DateFrom).ToString = "" Then
                    tdbg(0, COL_DateFrom) = CDate("01/07/2009")
                End If
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_DateTo
                If tdbg.Row > 0 Then
                    If tdbg(tdbg.Row - 1, COL_DateTo).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Den_ngay"))
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_DateTo
                        tdbg.Bookmark = tdbg.Row - 1
                        e.Cancel = True
                        Exit Sub
                    End If

                    If tdbg(tdbg.Row - 1, COL_DateFrom).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Tu_ngay"))
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_DateFrom
                        tdbg.Bookmark = tdbg.Row - 1
                        e.Cancel = True
                        Exit Sub
                    End If

                End If
            Case COL_SelfDeductionAmt
                If Not L3IsNumeric(tdbg.Columns(COL_SelfDeductionAmt).Text, EnumDataType.Money) Then
                    e.Cancel = True
                    Exit Sub
                End If
                If tdbg.Row > 0 Then
                    If tdbg(tdbg.Row - 1, COL_DateTo).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Den_ngay"))
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_DateTo
                        tdbg.Bookmark = tdbg.Row - 1
                        e.Cancel = True
                        Exit Sub
                    End If

                    If tdbg(tdbg.Row - 1, COL_DateFrom).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Tu_ngay"))
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_DateFrom
                        tdbg.Bookmark = tdbg.Row - 1
                        e.Cancel = True
                        Exit Sub
                    End If

                End If
        End Select
    End Sub
#End Region

#Region "Sự kiện của tdbg1"

    Private Sub tdbg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg1.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete 'Dòng 1 không cho phép xóa
                If tdbg1.RowCount > 1 Then
                    tdbg1.AllowDelete = True
                    If tdbg1.Row = 0 Then e.Handled = True
                Else
                    tdbg1.AllowDelete = False
                End If
        End Select
    End Sub

    Private Sub tdbg1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg1.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg1.Col
            Case COL_SelfDeductionAmt
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg1_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        Select Case e.ColIndex
            Case COL_DateTo
                If tdbg1.Row > 0 Then
                    tdbg1.Columns(COL_DateFrom).Value = CDate(tdbg1(tdbg1.Row - 1, COL_DateTo).ToString).AddDays(1)
                End If
                If tdbg1.Row < tdbg1.RowCount - 1 Then
                    Dim sDateTo As String = tdbg1.Columns(COL_DateTo).Text
                    If tdbg1(tdbg1.Row, COL_DateTo).ToString <> "" Then tdbg1(tdbg1.Row + 1, COL_DateFrom) = CDate(tdbg1(tdbg1.Row, COL_DateTo).ToString).AddDays(1)
                    tdbg1.Columns(COL_DateTo).Text = sDateTo
                End If
                If tdbg1.Row = 0 And tdbg1(0, COL_DateFrom).ToString = "" Then
                    tdbg1(0, COL_DateFrom) = CDate("01/07/2009")
                End If
            Case COL_SelfDeductionAmt
                If tdbg1.Row > 0 Then
                    tdbg1.Columns(COL_DateFrom).Value = CDate(tdbg1(tdbg1.Row - 1, COL_DateTo).ToString).AddDays(1)
                End If
                If tdbg1.Row = 0 And tdbg1(0, COL_DateFrom).ToString = "" Then
                    tdbg1(0, COL_DateFrom) = CDate("01/07/2009")
                End If
        End Select
    End Sub

    Private Sub tdbg1_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg1.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_DateTo
                If tdbg1.Row > 0 Then
                    If tdbg1(tdbg1.Row - 1, COL_DateTo).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Den_ngay"))
                        tdbg1.Focus()
                        tdbg1.SplitIndex = SPLIT0
                        tdbg1.Col = COL_DateTo
                        tdbg1.Row = tdbg1.Row - 1
                        e.Cancel = True
                        Exit Sub
                    End If

                    If tdbg1(tdbg1.Row - 1, COL_DateFrom).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Tu_ngay"))
                        tdbg1.Focus()
                        tdbg1.SplitIndex = SPLIT0
                        tdbg1.Col = COL_DateFrom
                        tdbg1.Row = tdbg1.Row - 1
                        e.Cancel = True
                        Exit Sub
                    End If

                End If
            Case COL_SelfDeductionAmt
                If Not L3IsNumeric(tdbg1.Columns(COL_SelfDeductionAmt).Text, EnumDataType.Money) Then
                    e.Cancel = True
                    Exit Sub
                End If
                If tdbg1.Row > 0 Then
                    If tdbg1(tdbg1.Row - 1, COL_DateTo).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Den_ngay"))
                        tdbg1.Focus()
                        tdbg1.SplitIndex = SPLIT0
                        tdbg1.Col = COL_DateTo
                        tdbg1.Row = tdbg1.Row - 1
                        e.Cancel = True
                        Exit Sub
                    End If

                    If tdbg1(tdbg1.Row - 1, COL_DateFrom).ToString = "" Then
                        D99C0008.MsgNotYetEnter(rl3("Tu_ngay"))
                        tdbg1.Focus()
                        tdbg1.SplitIndex = SPLIT0
                        tdbg1.Col = COL_DateFrom
                        tdbg1.Row = tdbg1.Row - 1
                        e.Cancel = True
                        Exit Sub
                    End If

                End If
        End Select
    End Sub
#End Region

#Region "Sự kiện của tdbgMinSalary"

    Private Sub tdbgMinSalary_AfterInsert(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgMinSalary.AfterInsert

    End Sub

    Private Sub tdbgMinSalary_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgMinSalary.ComboSelect
        tdbgMinSalary.UpdateData()
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbgMinSalary_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgMinSalary.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COLMS_MinSalary
                If Not L3IsNumeric(tdbgMinSalary.Columns(e.ColIndex).Text, EnumDataType.Money) Then e.Cancel = True
            Case COLMS_DivisionID
                If tdbgMinSalary.Columns(e.ColIndex).Text <> tdbgMinSalary.Columns(e.ColIndex).DropDown.Columns(tdbgMinSalary.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbgMinSalary.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
        End Select
    End Sub


    Private Sub tdbgMinSalary_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgMinSalary.AfterColUpdate
        bGridMinChanged = True
        ' Trường hợp DivisionID = Null thì khi merge se bị sai, nên phải gán lại = ""
        If tdbgMinSalary.Columns(COLMS_DivisionID).Text = "" OrElse tdbgMinSalary.Columns(COLMS_DivisionID).Value.ToString = "" Then
            tdbgMinSalary.Columns(COLMS_DivisionID).Value = ""
        End If
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COLMS_DivisionID
                If tdbgMinSalary.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbgMinSalary.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
        End Select
    End Sub

#End Region

#Region "tdbgSalAdj event"

    Private Sub tdbgSalAdj_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgSalAdj.ComboSelect
        tdbgSalAdj.UpdateData()
    End Sub


    Dim bNotInListSalAdj As Boolean = False
    Private Sub tdbgSalAdj_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgSalAdj.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COLS_SalAdjMethodID
                If tdbgSalAdj.Columns(e.ColIndex).Text <> tdbgSalAdj.Columns(e.ColIndex).DropDown.Columns(tdbgSalAdj.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbgSalAdj.Columns(e.ColIndex).Text = ""
                    bNotInListSalAdj = True
                End If
        End Select
    End Sub


    Private Sub tdbgSalAdj_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgSalAdj.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COLS_SalAdjMethodID
                If tdbgSalAdj.Columns(e.ColIndex).Text = "" OrElse bNotInListSalAdj Then
                    tdbgSalAdj.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COLS_SalAdjustmentDate
                If tdbgSalAdj.Columns(COLS_SalAdjustmentDate).Text <> "" Then
                    tdbgSalAdj.Columns(COLS_SalAdjustmentDate).Value = CDate(tdbgSalAdj.Columns(COLS_SalAdjustmentDate).Text & "/2000")
                End If
        End Select
        bNotInListSalAdj = False
    End Sub

    Private Sub tdbgSalAdj_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgSalAdj.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbgSalAdj.Col
            Case COLS_IsSelected
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Dim bSelected As Boolean = False
    Private Sub tdbgSalAdj_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgSalAdj.HeadClick
        Select Case e.ColIndex
            Case COLS_IsSelected
                L3HeadClick(tdbgSalAdj, e.ColIndex, bSelected)
        End Select
    End Sub


#End Region

#Region "tdbgAuto event"

    Private Sub tdbgAuto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgAuto.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbgAuto.Col
            Case COLA_IsAdvancePayroll, COLA_IsMainPayroll
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Dim bSelectAuto As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub HeadClickAuto(ByVal iCol As Integer)
        If tdbgAuto.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COLA_IsAdvancePayroll, COLA_IsMainPayroll
                L3HeadClick(tdbgAuto, iCol, bSelectAuto)
        End Select
    End Sub

    Private Sub tdbgAuto_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgAuto.HeadClick
        HeadClickAuto(e.ColIndex)
    End Sub

    Private Sub tdbgAuto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgAuto.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClickAuto(tdbgAuto.Col)
    End Sub


#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0001
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 30/12/2010 08:05:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0001() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0001"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0001s
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 30/12/2010 08:06:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0001s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sTransID As String = ""
        Dim iCountIGE As Int32 = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COL_TransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                sTransID = CreateIGEs("D13T0001", "TransID", "13", "RS", gsStringKey, sTransID, iCountIGE)
                tdbg(i, COL_TransID) = sTransID
            End If

            sSQL.Append("Insert Into D13T0001(")
            sSQL.Append("DateFrom, DateTo, SelfDeductionAmt, TransID, DAType ")
            sSQL.Append(") Values(")
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateFrom)) & COMMA) 'DateFrom, datetime, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateTo)) & COMMA) 'DateTo, datetime, NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SelfDeductionAmt), DxxFormat.DefaultNumber2) & COMMA) 'SelfDeductionAmt, money, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString("SDA")) 'DAType , varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next

        For i As Integer = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COL_TransID).ToString = "" Then
                sTransID = CreateIGEs("D13T0001", "TransID", "13", "RS", gsStringKey, sTransID, iCountIGE)
                tdbg1(i, COL_TransID) = sTransID
            End If

            sSQL.Append("Insert Into D13T0001(")
            sSQL.Append("DateFrom, DateTo, SelfDeductionAmt, TransID, DAType ")
            sSQL.Append(") Values(")
            sSQL.Append(SQLDateSave(tdbg1(i, COL_DateFrom)) & COMMA) 'DateFrom, datetime, NOT NULL
            sSQL.Append(SQLDateSave(tdbg1(i, COL_DateTo)) & COMMA) 'DateTo, datetime, NULL
            sSQL.Append(SQLMoney(tdbg1(i, COL_SelfDeductionAmt), DxxFormat.DefaultNumber2) & COMMA) 'SelfDeductionAmt, money, NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COL_TransID)) & COMMA) 'TransID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString("FDA")) 'DAType , varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next


        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0050
    '# Created User: Trần Hoàng Nhân
    '# Created Date: 21/08/2012 10:24:15
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0050() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Cap nhat ngay khong su dung cua PTTL khi thiet lap khong su dung PTTL" & vbCrLf)
        sSQL.Append("Update D13T0050 Set ")
        sSQL.Append("Disabled = 1") 'tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0002s
    '# Created User: Hoàng Nhân
    '# Created Date: 17/09/2013 10:33:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0002() As String
        Dim sSQL As String = ""
        sSQL &= "-- Delete tab Luong toi thieu" & vbCrLf
        sSQL &= "Delete From D13T0002"
        If chkIsDisplayValid.Checked Then
            sSQL &= " WHERE (convert(varchar(10),MSDateTo,101) >= convert(varchar(10),GETDATE(),101)) OR ISNULL(MSDateTo,'') = ''"
        End If

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0002s
    '# Created User: Hoàng Nhân
    '# Created Date: 17/09/2013 10:37:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0002s() As StringBuilder
        Dim sRet As New StringBuilder
        'Sinh IGE chi tiết
        Dim sTransactionID As String = ""
        Dim iFirstTrans As Long = 0
        Dim iCountIGE As Integer = 0
        '  iCountIGE = dtGridMinSalary.Select("TransID='' or TransID is null").Length
        '---------------------------------
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbgMinSalary.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert du lieu luoi luong toi thieu" & vbCrLf)
            sSQL.Append("Insert Into D13T0002(")
            sSQL.Append("DivisionID, MinSalary, MSDateFrom, MSDateTo")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(tdbgMinSalary(i, COLMS_DivisionID)) & COMMA) 'DivisionID, varchar[50], NOT NULL
            sSQL.Append(SQLMoney(tdbgMinSalary(i, COLMS_MinSalary), tdbgMinSalary.Columns(COLMS_MinSalary).NumberFormat) & COMMA) 'MinSalary, decimal, NOT NULL
            sSQL.Append(SQLDateSave(tdbgMinSalary(i, COLMS_MSDateFrom)) & COMMA) 'MSDateFrom, datetime, NULL
            sSQL.Append(SQLDateSave(tdbgMinSalary(i, COLMS_MSDateTo))) 'MSDateTo, datetime, NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0003
    '# Created User: Hoàng Nhân
    '# Created Date: 30/09/2013 02:53:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0003() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi cua form D13F0001 (Tab - Dieu chinh luong)" & vbCrLf)
        sSQL &= "Exec D13P0003 "
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0003
    '# Created User: Hoàng Nhân
    '# Created Date: 30/09/2013 03:06:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0003() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu truoc khi insert" & vbCrLf)
        sSQL &= "Delete From D13T0003"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0003s
    '# Created User: Hoàng Nhân
    '# Created Date: 30/09/2013 03:07:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0003s(ByRef drSalAdj() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        If drSalAdj.Length > 0 Then sSQL.Append("-- Insert du lieu dieu chinh luong" & vbCrLf)
        For i As Integer = 0 To drSalAdj.Length - 1
            sSQL.Append("Insert Into D13T0003(")
            sSQL.Append("SalParameterID, SalAdjMethodID, SalAdjustmentDate, Type, Note, NoteU")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(drSalAdj(i).Item("SalParameterID")) & COMMA) 'SalParameterID, varchar[50], NOT NULL
            sSQL.Append(SQLString(drSalAdj(i).Item("SalAdjMethodID")) & COMMA) 'SalAdjMethodID, varchar[50], NOT NULL
            sSQL.Append(SQLDateSave(drSalAdj(i).Item("SalAdjustmentDate")) & COMMA) 'SalAdjustmentDate, datetime, NOT NULL
            sSQL.Append(SQLString(drSalAdj(i).Item("Type")) & COMMA) 'Type, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(drSalAdj(i).Item("Note"), gbUnicode, False) & COMMA) 'Note, varchar[1000], NOT NULL
            sSQL.Append(SQLStringUnicode(drSalAdj(i).Item("Note"), gbUnicode, True)) 'NoteU, nvarchar[2000], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    Private Sub btnSetupMailServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetupMailServer.Click
        Dim sm As New D99D0141.SendMailLemon3(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, CType(geLanguage, EnumLanguage), gbUnicode)
        sm.SetupMailServer()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD52T1010s
    '# Created User: Hoàng Nhân
    '# Created Date: 13/02/2014 04:20:17
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD52T1010s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbgAuto.RowCount - 1
            If i = 0 Then sSQL.Append("-- Luu du lieu tab Tu dong" & vbCrLf)
            sSQL.Append("Update D52T1010 Set ")
            sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("IsAdvancePayroll = " & SQLNumber(tdbgAuto(i, COLA_IsAdvancePayroll)) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("IsMainPayroll = " & SQLNumber(tdbgAuto(i, COLA_IsMainPayroll))) 'tinyint, NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("BenefitID = " & SQLString(tdbgAuto(i, COLA_BenefitID)))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '14/7/2014, id 58418-Tự động san công khi tính lương vá tính lương với dữ liệu sau san công
    Private Sub chkIsAutoAttShare_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsAutoAttShare.Click
        If chkIsAutoAttShare.Checked = True Then
            UnReadOnlyControl(tdbcAttShareUserID)
        Else
            tdbcAttShareUserID.Text = ""
            ReadOnlyControl(tdbcAttShareUserID)
        End If
    End Sub

#Region "Events tdbcAttShareUserID"

    Private Sub tdbcAttShareUserID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAttShareUserID.LostFocus
        If tdbcAttShareUserID.FindStringExact(tdbcAttShareUserID.Text) = -1 Then tdbcAttShareUserID.Text = ""
    End Sub

#End Region


End Class
