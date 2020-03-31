'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:40:32 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:40:32 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F1011
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim bUnicode As Boolean = L3Bool(gbUnicode)
    Dim iLastCol As Integer
    Dim bFlagShiftInsert As Boolean = False

#Region "Const of tdbg"
    Private Const COLD_TaxID As Integer = 0        ' Mã chi tiết thuế
    Private Const COLD_MinSalary As Integer = 1    ' > Mức lương
    Private Const COLD_MaxSalary As Integer = 2    ' <= Mức lương
    Private Const COLD_RateOrAmount As Integer = 3 ' Tỷ lệ (%)
#End Region

    Private _taxObjectID As String
    Public Property TaxObjectID() As String
        Get
            Return _taxObjectID
        End Get
        Set(ByVal value As String)
            If TaxObjectID = value Then
                _taxObjectID = ""
                Return
            End If
            _taxObjectID = value
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
                    CheckIdTextBox(txtTaxObjectID)
                    btnNext.Enabled = False
                    btnSave.Enabled = True
                    LoadAdd()
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Enabled = True
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSave.Enabled = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub LoadAdd()
        txtTaxObjectID.Text = ""
        'chkDisabled.Checked = False
        chkDisabled.Visible = False
        chkIsDefault.Checked = False

        txtTaxObjectName.Text = ""
        optPartIsProgressive.Checked = True
        optFullIsProgressive.Checked = False
        optIsPercent1.Checked = True
        optIsPercent2.Checked = False
        ChangeCaptionTDBGrid()
        LoadMaster(txtTaxObjectID.Text)
        LoadDetail(txtTaxObjectID.Text)
    End Sub

    Private Sub LoadEdit()
        txtTaxObjectName.Focus()
        txtTaxObjectID.Enabled = False
        chkDisabled.Visible = True
        LoadMaster(_taxObjectID)
        LoadDetail(txtTaxObjectID.Text)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F1011_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    optIsPercent1.Focus()

                Case Keys.D2, Keys.NumPad2
                    'txtIncomeAfterTax.Focus()
            End Select
        End If

        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            If tdbg.Enabled = True Then
                HotKeyF11(Me, tdbg)
            End If
        End If
    End Sub

    Private Sub D13F1011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        ChangeCaptionTDBGrid()
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_doi_tuong_nop_thue_thu_nhap_-_D13F1011") & UnicodeCaption(bUnicode) 'CËp nhËt ¢çi t§íng nèp thuÕ thu nhËp - D13F1011
        '================================================================ 
        lblTaxObjectID.Text = rl3("Ma") 'Mã
        lblTaxObjectName.Text = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkIsDefault.Text = rl3("Mac_dinh") 'Mặc định
        '================================================================ 
        optIsPercent2.Text = rl3("Theo_gia_tri") 'Theo giá trị
        optIsPercent1.Text = rl3("Theo_ti_le") 'Theo tỉ lệ
        optFullIsProgressive.Text = rl3("Luy_tien_toan_phan") 'Lũy tiến toàn phần
        optPartIsProgressive.Text = rl3("Luy_tien_tung_phan") 'Lũy tiến từng phần
        '================================================================ 
        grp3.Text = rl3("Phuong_phap_xac_dinh_tri_thue") 'Phương pháp xác định trị thuế
        grpMethodCalTax.Text = rl3("Phuong_phap_tinh_thue") 'Phương pháp tính thuế
        '================================================================ 
        tdbg.Columns("TaxID").Caption = rl3("Ma_chi_tiet_thue") 'Mã chi tiết thuế
        tdbg.Columns("MinSalary").Caption = rl3("_Muc_luong") '> Mức lương
        tdbg.Columns("MaxSalary").Caption = rl3("_Muc_luong1") '<= Mức lương
        tdbg.Columns("RateOrAmount").Caption = rl3("Ty_le_(%)") 'Tỷ lệ (%)
    End Sub

    Private Sub ChangeCaptionTDBGrid()
        If optIsPercent1.Checked = True Then
            tdbg.Columns(COLD_RateOrAmount).Caption = rl3("Ty_le_(%)")
        Else
            tdbg.Columns(COLD_RateOrAmount).Caption = rl3("Gia_tri_")
        End If
    End Sub

    'Private Sub EnableTextBox()
    '    If optIsPercentSurtax1.Checked = True Then
    '        txtRateOrAmount2.Text = "0"
    '        txtRateOrAmount1.Enabled = True
    '        txtRateOrAmount2.Enabled = False
    '    Else
    '        txtRateOrAmount1.Text = "0"
    '        txtRateOrAmount1.Enabled = False
    '        txtRateOrAmount2.Enabled = True
    '    End If
    'End Sub

    'Private Sub txt_NumberFormat()
    '    txtIncomeAfterTax.Text = SQLNumber(txtIncomeAfterTax.Text, D13Format.DefaultNumber2).ToString
    '    txtRateOrAmount1.Text = SQLNumber(txtRateOrAmount1.Text, D13Format.DefaultNumber2).ToString()
    '    txtRateOrAmount2.Text = SQLNumber(txtRateOrAmount2.Text, D13Format.DefaultNumber2).ToString()
    'End Sub

    Private Sub LoadMaster(ByVal sTaxObjectID As String)
        Dim ssQL As String = ""
        ssQL &= "Select TaxObjectID, TaxObjectName, TaxObjectNameU, IsProgressive, IsMaxSalary, " & vbCrLf
        ssQL &= "IsPercent, Disabled, IsDefault " & vbCrLf
        ssQL &= "From D13T0128  WITH (NOLOCK) Where TaxObjectID = " & SQLString(sTaxObjectID)
        Dim dt As DataTable = ReturnDataTable(ssQL)
        If dt.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dt.Rows.Count - 1
            txtTaxObjectID.Text = dt.Rows(i).Item("TaxObjectID").ToString
            txtTaxObjectName.Text = dt.Rows(i).Item("TaxObjectName" & UnicodeJoin(bUnicode)).ToString
            chkDisabled.Checked = Convert.ToBoolean(dt.Rows(i).Item("Disabled"))
            chkIsDefault.Checked = Convert.ToBoolean(dt.Rows(i).Item("IsDefault"))
            If Convert.ToInt16(dt.Rows(i).Item("IsProgressive")) = 1 Then
                optPartIsProgressive.Checked = True
            Else
                optFullIsProgressive.Checked = True
            End If
            If Convert.ToInt16(dt.Rows(i).Item("IsPercent")) = 1 Then
                optIsPercent1.Checked = True
            Else
                optIsPercent2.Checked = True
            End If
        Next
    End Sub

    Private Sub LoadDetail(ByVal sTaxObjectID As String)
        Dim sSQL As String = ""
        sSQL &= "Select TaxID, TaxObjectID, MaxSalary, MinSalary, RateOrAmount From D13T0112  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where TaxObjectID = " & SQLString(sTaxObjectID)
        sSQL &= "Order By TaxID"
        LoadDataSource(tdbg, sSQL, gbUnicode)
    End Sub

    Private Sub SetBackColorObligatory()
        txtTaxObjectID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtTaxObjectName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function AllowSave() As Boolean
        If txtTaxObjectID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_doi_tuong_nop_thue"))
            txtTaxObjectID.Focus()
            Return False
        End If
        If txtTaxObjectID.Text.Trim <> "" And txtTaxObjectID.Text.Trim.Length > 20 Then
            D99C0008.MsgL3(rl3("Do_dai_Ma_doi_tuong_thue_khong_duoc_vuot_qua_20_ky_tu"))
            txtTaxObjectID.Focus()
            Return False
        End If
        If txtTaxObjectName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_doi_tuong_nop_thue"))
            txtTaxObjectName.Focus()
            Return False
        End If
        If txtTaxObjectName.Text.Trim <> "" And txtTaxObjectName.Text.Trim.Length > 50 Then
            D99C0008.MsgL3(rl3("Do_dai_Ten_doi_tuong_nop_thue_khong_duoc_vuot_qua_50_ky_tu"))
            txtTaxObjectName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D13T0128", "TaxObjectID", txtTaxObjectID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtTaxObjectID.Focus()
                Return False
            End If
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COLD_MaxSalary).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("_Muc_luongU"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COLD_MaxSalary
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If tdbg(i, COLD_MaxSalary).ToString <> "" And Val(tdbg(i, COLD_MaxSalary).ToString) > MaxMoney Then
                D99C0008.MsgL3(rl3("_Muc_luong_khong_duoc_vuot_qua_") & MaxMoney)
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COLD_MaxSalary
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If Number(tdbg(i, COLD_MaxSalary).ToString) < Number(tdbg(i, COLD_MinSalary).ToString) Then
                D99C0008.MsgL3(rl3("_Muc_luong_khong_duoc_nho_hon__Muc_luong"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COLD_MaxSalary
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If optIsPercent1.Checked = True Then
                If tdbg(i, COLD_RateOrAmount).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Ty_le_(%)"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COLD_RateOrAmount
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If tdbg(i, COLD_RateOrAmount).ToString <> "" And Convert.ToDouble(tdbg(i, COLD_RateOrAmount)) > 100 Then
                    D99C0008.MsgL3(rl3("Ty_le_(%)_khong_duoc_vuot_qua_100_%"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COLD_RateOrAmount
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            ElseIf optIsPercent2.Checked Then
                If tdbg(i, COLD_RateOrAmount).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Gia_tri_"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COLD_RateOrAmount
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If tdbg(i, COLD_RateOrAmount).ToString <> "" And Val(tdbg(i, COLD_RateOrAmount)) > MaxMoney Then
                    If optIsPercent2.Checked = True Then
                        D99C0008.MsgL3(rl3("Xac_dinh_tri_thue_theo_gia_tri_khong_duoc_vuot_qua_") & MaxMoney)
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COLD_RateOrAmount
                        tdbg.Bookmark = i
                        tdbg.Focus()
                        Return False
                    End If
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        If chkIsDefault.Checked Then
            If CheckStore(SQLStoreD13P5555()) Then
                Dim sSQLUpdateD13T0128 As String = "-- Update ma doi tuong mac dinh ve khong mac dinh" & vbCrLf
                sSQLUpdateD13T0128 &= "UPDATE D13T0128 SET IsDefault = 0 WHERE IsDefault = 1"
                ExecuteSQL(sSQLUpdateD13T0128)
            Else
                btnSave.Enabled = True
                btnClose.Enabled = True
                chkIsDefault.Focus()
                Exit Sub
            End If
        End If

        Dim sSQL As String = ""
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL &= SQLInsertD13T0128() & vbCrLf
                sSQL &= SQLInsertD13T0112s()
            Case EnumFormState.FormEdit
                sSQL &= SQLUpdateD13T0128() & vbCrLf
                sSQL &= SQLDeleteD13T0112() & vbCrLf
                sSQL &= SQLInsertD13T0112s()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    _taxObjectID = txtTaxObjectID.Text
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'Audit Log
                    Dim sDesc1 As String = txtTaxObjectID.Text
                    Dim sDesc2 As String = txtTaxObjectName.Text
                    Dim sDesc3 As String = SQLNumber(chkDisabled.Checked)
                    Dim sDesc4 As String = ""
                    Dim sDesc5 As String = ""
                    RunAuditLog(AuditCodePITObjects, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COLD_TaxID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COLD_MinSalary).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COLD_MinSalary).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COLD_MaxSalary).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COLD_RateOrAmount).NumberFormat = D13Format.DefaultNumber2
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0128
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 26/01/2007 02:18:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0128() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D13T0128("
        sSQL &= "TaxObjectID, TaxObjectName, TaxObjectNameU, IsProgressive, IsMaxSalary, IsPercent, "
        sSQL &= "Disabled, IsDefault, CreateUserID, "
        sSQL &= "CreateDate, LastModifyUserID, LastModifyDate"
        sSQL &= ") Values ("
        sSQL &= SQLString(txtTaxObjectID.Text) & COMMA 'TaxObjectID [KEY], varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtTaxObjectName, False) & COMMA 'TaxObjectName, varchar[50], NULL
        sSQL &= SQLStringUnicode(txtTaxObjectName, True) & COMMA 'TaxObjectName, varchar[50], NULL
        If optPartIsProgressive.Checked Then
            sSQL &= SQLNumber("1") & COMMA 'IsProgressive, bit, NOT NULL
        Else
            sSQL &= SQLNumber("0") & COMMA 'IsProgressive, bit, NOT NULL
        End If
        sSQL &= SQLNumber(0) & COMMA 'IsMaxSalary, bit, NOT NULL
        If optIsPercent1.Checked = True Then
            sSQL &= SQLNumber("1") & COMMA 'IsPercent, bit, NOT NULL
        Else
            sSQL &= SQLNumber("0") & COMMA 'IsPercent, bit, NOT NULL
        End If
        sSQL &= SQLNumber(chkDisabled.Checked) & COMMA 'Disabled, bit, NOT NULL
        sSQL &= SQLNumber(chkIsDefault.Checked) & COMMA 'IsDefault, bit, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" 'LastModifyDate, datetime, NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0112s
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 26/01/2007 02:18:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0112s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        Dim sTaxID As String = ""
        Dim iCountIGE As Int32 = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COLD_TaxID).ToString = "" Then
                iCountIGE += 1
            End If
        Next
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COLD_TaxID).ToString = "" Then
                sTaxID = CreateIGEs("D13T0112", "TaxID", "13", "TL", gsStringKey, sTaxID, iCountIGE)
                tdbg(i, COLD_TaxID) = sTaxID
            End If
            sSQL = ""
            sSQL &= "Insert Into D13T0112("
            sSQL &= "TaxID, TaxObjectID, MaxSalary, MinSalary, RateOrAmount, TotalAmount"
            sSQL &= ") Values ("
            sSQL &= SQLString(tdbg(i, COLD_TaxID)) & COMMA 'TaxID [KEY], varchar[20], NOT NULL
            sSQL &= SQLString(txtTaxObjectID.Text) & COMMA 'TaxObjectID [KEY], varchar[20], NOT NULL
            sSQL &= SQLMoney(tdbg(i, COLD_MaxSalary).ToString) & COMMA 'MaxSalary, money, NULL
            sSQL &= SQLMoney(tdbg(i, COLD_MinSalary).ToString) & COMMA 'MinSalary, money, NULL
            sSQL &= SQLMoney(tdbg(i, COLD_RateOrAmount).ToString) & COMMA 'RateOrAmount, money, NULL
            sSQL &= SQLMoney(0) 'TotalAmount, money, NULL
            sSQL &= ")"
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function

    Private Sub optIsPercent1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optIsPercent1.Click
        ChangeCaptionTDBGrid()
    End Sub

    Private Sub optIsPercent2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optIsPercent2.Click
        ChangeCaptionTDBGrid()
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.UpdateData()
        Select Case e.ColIndex
            Case COLD_MaxSalary
                If tdbg.Columns(COLD_MaxSalary).Text <> "" Then
                    If tdbg.RowCount = 1 Then
                        tdbg(tdbg.Bookmark, COLD_MinSalary) = "0"
                    Else
                        If tdbg.Bookmark = 0 Then
                            tdbg(tdbg.Bookmark, COLD_MinSalary) = "0"
                            If tdbg.Bookmark < tdbg.RowCount - 1 Then
                                tdbg(tdbg.Bookmark + 1, COLD_MinSalary) = tdbg(tdbg.Bookmark, COLD_MaxSalary)
                            End If
                        ElseIf tdbg.Bookmark <> 0 And tdbg.Bookmark < tdbg.RowCount - 1 Then
                            tdbg(tdbg.Bookmark, COLD_MinSalary) = tdbg(tdbg.Bookmark - 1, COLD_MaxSalary)
                            tdbg(tdbg.Bookmark + 1, COLD_MinSalary) = tdbg(tdbg.Bookmark, COLD_MaxSalary)
                        ElseIf tdbg.Bookmark <> 0 And tdbg.Bookmark = tdbg.RowCount - 1 Then
                            tdbg(tdbg.Bookmark, COLD_MinSalary) = tdbg(tdbg.Bookmark - 1, COLD_MaxSalary)
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        If tdbg.Columns(COLD_MaxSalary).Text <> "" Then
            If tdbg.Bookmark = 0 Then
                tdbg(tdbg.Bookmark, COLD_MinSalary) = "0"
            Else
                tdbg(tdbg.Bookmark, COLD_MinSalary) = tdbg(tdbg.Bookmark - 1, COLD_MaxSalary)
            End If
        End If
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COLD_MinSalary
                If Not IsNumeric(tdbg.Columns(COLD_MinSalary).Text) Then e.Cancel = True
            Case COLD_MaxSalary
                If Not IsNumeric(tdbg.Columns(COLD_MaxSalary).Text) Then e.Cancel = True
            Case COLD_RateOrAmount
                If Not IsNumeric(tdbg.Columns(COLD_RateOrAmount).Text) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        bFlagShiftInsert = False
        Select Case e.KeyCode
            Case Keys.F7
                If tdbg.Col <> COLD_MinSalary Then
                    HotKeyF7(tdbg)
                End If

            Case Keys.S
                If e.Control And tdbg.Col <> COLD_MinSalary Then
                    tdbg_HeadClick(sender, Nothing)
                End If

            Case Keys.Insert
                If e.Shift Then
                    bFlagShiftInsert = True
                    HotKeyShiftInsert(tdbg, 0, COLD_MinSalary, tdbg.Columns.Count)
                End If

            Case Keys.Enter
                If tdbg.Col = COLD_RateOrAmount Then
                    HotKeyEnterGrid(tdbg, COLD_MaxSalary, e)
                End If

            Case Else
                HotKeyDownGrid(e, tdbg, COLD_MinSalary)
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COLD_MaxSalary
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLD_RateOrAmount
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If bFlagShiftInsert And tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
            tdbg.Columns(COLD_MinSalary).Text = "" ' Gán 1 cột bất kỳ ="" cho lưới
        End If
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COLD_RateOrAmount, COLD_MaxSalary
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Value.ToString, tdbg.Row)
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0128
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 29/01/2007 10:49:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0128() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T0128 Set "
        sSQL &= "TaxObjectName = " & SQLStringUnicode(txtTaxObjectName, False) & COMMA 'varchar[50], NULL
        sSQL &= "TaxObjectNameU = " & SQLStringUnicode(txtTaxObjectName, True) & COMMA 'varchar[50], NULL
        If optPartIsProgressive.Checked = True Then
            sSQL &= "IsProgressive = " & SQLNumber("1") & COMMA 'bit, NOT NULL
        Else
            sSQL &= "IsProgressive = " & SQLNumber("0") & COMMA 'bit, NOT NULL
        End If
        If optIsPercent1.Checked = True Then
            sSQL &= "IsPercent = " & SQLNumber("1") & COMMA 'bit, NOT NULL
        Else
            sSQL &= "IsPercent = " & SQLNumber("0") & COMMA 'bit, NOT NULL
        End If
        sSQL &= "Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA 'bit, NOT NULL
        sSQL &= "IsDefault = " & SQLNumber(chkIsDefault.Checked) & COMMA 'bit, NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" 'datetime, NULL
        sSQL &= " Where "
        sSQL &= "TaxObjectID = " & SQLString(txtTaxObjectID.Text)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0112
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 29/01/2007 10:50:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0112() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0112"
        sSQL &= " Where "
        sSQL &= "TaxObjectID = " & SQLString(_taxObjectID)
        Return sSQL
    End Function

    Private Sub txtIncomeAfterTax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub
    Private Sub txtRateOrAmount1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtRateOrAmount2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAdd()
        btnSave.Enabled = True
        btnNext.Enabled = False
        txtTaxObjectID.Focus()
    End Sub

    'Hai hàm này chép từ D99X0000 ra
    ''' <summary>
    ''' Copy giá trị trong 1 cột (khi nhấn Head_Click)
    ''' </summary>
    ''' <param name="c1Grid">Lưới C1</param>
    ''' <param name="ColCopy">Cột cần copy</param>
    ''' <param name="sValue">Giá trị cần copy</param>
    ''' <param name="RowCopy">Dòng đang copy</param>
    ''' <remarks>Chỉ dùng copy những cột dữ liệu không liên quan đến các cột khác, copy cả giá trị ''</remarks>

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            'If sValue = "" Or c1Grid.RowCount < 2 Then Exit Sub
            If c1Grid.RowCount < 2 Then Exit Sub

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse Val(c1Grid(i, ColCopy).ToString) = 0 Then c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(RowCopy, ColCopy) = sValue

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(0, ColCopy) = sValue
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Copy giá trị trong 1 cột có liên quan đến các cột kế nó (khi nhấn Head_Click)
    ''' </summary>
    ''' <param name="c1Grid">Lưới C1</param>
    ''' <param name="ColCopy">Cột cần copy</param>
    ''' <param name="RowCopy">Dòng cần copy</param>
    ''' <param name="ColumnCount">Số cột liên quan khi cần copy</param>
    ''' <remarks>Chỉ copy những cột ở vị trí liên tục nhau</remarks>

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal ColumnCount As Integer, ByVal sValue As String)
        Dim i, j As Integer
        Try
            If c1Grid.RowCount < 2 Then Exit Sub

            If ColumnCount = 1 Then ' Copy trong 1 cot
                CopyColumns(c1Grid, ColCopy, sValue, RowCopy)
            ElseIf ColumnCount > 1 Then ' Copy nhieu cot lien quan
                Dim Flag As DialogResult
                'Flag = D99C0008.MsgCopyColumn()
                Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                    c1Grid.UpdateData()
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse Val(c1Grid(i, ColCopy).ToString) = 0 Then
                            c1Grid(i, ColCopy) = sValue
                            While j < ColumnCount
                                c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                                j += 1
                            End While
                        End If
                    Next
                ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy hết
                    c1Grid.UpdateData()
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        c1Grid(i, ColCopy) = sValue
                        While j < ColumnCount
                            c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                            j += 1
                        End While
                    Next
                    'c1Grid(0, ColCopy) = sValue
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Trần Hoàng Nhân
    '# Created Date: 04/07/2012 01:39:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= "-- Stored kiem tra truoc khi luu " & vbCrLf
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F1011") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(txtTaxObjectID.Text) 'Key01ID, varchar[20], NOT NULL
        Return sSQL
    End Function


End Class