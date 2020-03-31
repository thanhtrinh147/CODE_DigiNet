'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:30:43 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:30:43 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Imports System.Text
Imports System

Public Class D13F2011

    Private _description As String = ""
    Public giIsAddFromMaster As Integer
    Public giIgnoreSub As Integer
    Public giMode As Integer
    Public bFlagSalOpen As Boolean

    Dim sEditVoucherTypeID As String = ""
    Dim sEditTransTypeID As String = ""
    Dim dtNCodeID As DataTable
    Dim bIsNotInList As Boolean = False

    Private _payrollVoucherID As String = ""
    Public Property PayrollVoucherID() As String
        Get
            Return _payrollVoucherID
        End Get
        Set(ByVal value As String)
            If PayrollVoucherID = value Then
                _payrollVoucherID = ""
                Return
            End If
            _payrollVoucherID = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            If Description = value Then
                _description = ""
                Return
            End If
            _description = value
        End Set
    End Property

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean 
        Get
            Return _bSaved
        End Get
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
                    btnDetail.Enabled = False
                    LoadTDBCombo()
                    LoadAdd()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnDetail.Enabled = True
                    LoadEdit()
                    ' update 2/4/2013 id 53610
                    chkIsAutoAddEmps.Visible = False
                    chkIsExcludeMaterity.Enabled = False
                    chkIsExcludeMaterity.Location = chkIsAutoAddEmps.Location
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    btnDetail.Enabled = False
                    LoadEdit()
                    ' update 2/4/2013 id 53610
                    chkIsExcludeMaterity.Enabled = False
                    chkIsAutoAddEmps.Visible = False
                    chkIsExcludeMaterity.Location = chkIsAutoAddEmps.Location
                Case EnumFormState.FormOther
                    btnSave.Enabled = True
                    btnDetail.Enabled = False
                    txtDescription.Enabled = False
                    LoadReOpenSalFile()
                    ' update 2/4/2013 id 53610
                    chkIsAutoAddEmps.Visible = False
                    chkIsExcludeMaterity.Enabled = False
                    chkIsExcludeMaterity.Location = chkIsAutoAddEmps.Location
            End Select
        End Set
    End Property

    Private Sub LoadAdd()
        tdbcVoucherTypeID.Text = ""
        txtVoucherTypeName.Text = ""
        txtPayrollVoucherNo.Text = ""
        c1dateVoucherDate.Value = Date.Today
        txtDescription.Text = ""
        txtPayrollVoucherNo.ReadOnly = True
        LoadMaster(_payrollVoucherID)
    End Sub

    Private Sub LoadEdit()
        tdbcTransTypeID.Enabled = False
        tdbcVoucherTypeID.Enabled = False
        txtPayrollVoucherNo.ReadOnly = True
        btnSetNewKey.Enabled = False
        c1dateVoucherDate.Enabled = False
        LoadMaster(_payrollVoucherID)
    End Sub

    Private Sub LoadReOpenSalFile()
        tdbcVoucherTypeID.Enabled = False
        txtPayrollVoucherNo.ReadOnly = True
        btnSetNewKey.Enabled = False
        c1dateVoucherDate.Enabled = False
        LoadMaster(_payrollVoucherID)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTdbcTransTypeID(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sID As String, Optional ByVal sEditTransTypeID As String = "")
        Dim sSQL As String = ""
        sSQL = "SELECT  Distinct TransTypeID,TransTypeName" & UnicodeJoin(gbUnicode) & " as TransTypeName, VoucherTypeID" & vbCrLf
        sSQL &= "FROM   D13T1130 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE  TransactionID = " & SQLString(sID) & vbCrLf
        sSQL &= "   AND Disabled = 0" & vbCrLf
        sSQL &= "   AND (DAGroupID = ''" & vbCrLf
        sSQL &= "           OR  DAGroupID In (  Select  DAGroupID " & vbCrLf
        sSQL &= "                      		    From    LemonSys.dbo.D00V0080" & vbCrLf
        sSQL &= "                       		Where   UserID = " & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "           OR 'LEMONADMIN' = " & SQLString(gsUserID) & ")" & vbCrLf

        If sEditTransTypeID <> "" Then
            sSQL &= " Or TransTypeID = " & SQLString(sEditTransTypeID) & vbCrLf
        End If

        sSQL &= "ORDER BY TransTypeID"
        LoadDataSource(tdbc, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        LoadTdbcTransTypeID(tdbcTransTypeID, "0001", sEditTransTypeID)

        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, D13, sEditVoucherTypeID, gbUnicode)

    End Sub

    Private Sub D13F2011_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
    End Sub

    Private Sub D13F2011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        tdbcVoucherTypeID.AutoSelect = True
InputDateCustomFormat(c1dateVoucherDate)

        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Mo_ho_so_luong_thang_-_D13F2011") & UnicodeCaption(gbUnicode) 'Mê hä s¥ l§¥ng thÀng - D13F2011
        '================================================================ 
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblPayrollVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblteVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblTransTypeID.Text = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnDetail.Text = rl3("Chi_tiet_1") '&Chi tiết
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkIsAutoAddEmps.Text = rl3("Tu_dong_them_NV_vao_HSL_thang") ' update 02/04/2013 id 53610
        chkIsExcludeMaterity.Text = rl3("Loai_bo_nhan_vien_nghi_thai_san")
        '================================================================ 
        grp1.Text = "1. " & rl3("Chung_tu") 'Chứng từ
        '================================================================ 
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcTransTypeID.Columns("TransTypeID").Caption = rl3("Ma") 'Mã
        tdbcTransTypeID.Columns("TransTypeName").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtPayrollVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtDescription.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

#Region "Events tdbcTransTypeID"

    Private Sub tdbcTransTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.Close
        If tdbcTransTypeID.FindStringExact(tdbcTransTypeID.Text) = -1 Then tdbcTransTypeID.Text = ""
    End Sub

    Private Sub tdbcTransTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.SelectedValueChanged
        If Not (tdbcTransTypeID.Tag Is Nothing OrElse tdbcTransTypeID.Tag.ToString = "") Then
            tdbcTransTypeID.Tag = ""
            Exit Sub
        End If
        If tdbcTransTypeID.SelectedValue Is Nothing Then
            Exit Sub
        End If
        If tdbcTransTypeID.Columns("VoucherTypeID").Text <> "" Then
            tdbcVoucherTypeID.Text = tdbcTransTypeID.Columns("VoucherTypeID").Text
        End If
    End Sub

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcTransTypeID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcTransTypeID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

#Region "Events tdbcVoucherTypeID with txtVoucherTypeName"

    Private Sub tdbcVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherTypeName.Text = ""
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        txtVoucherTypeName.Text = tdbcVoucherTypeID.Columns(1).Value.ToString

        If _FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormOther Then
            If Not (tdbcVoucherTypeID.Tag Is Nothing OrElse tdbcVoucherTypeID.Tag.ToString = "") Then
                tdbcVoucherTypeID.Tag = ""
                Exit Sub
            End If
            If tdbcVoucherTypeID.Text <> "" Then
                If L3Int(tdbcVoucherTypeID.Columns("Auto").Text) = 0 Then 'Không tạo mã tự động
                    txtPayrollVoucherNo.ReadOnly = False
                    txtPayrollVoucherNo.TabStop = True
                    btnSetNewKey.Enabled = False
                    txtPayrollVoucherNo.Text = ""
                Else
                    gnNewLastKey = 0
                    txtPayrollVoucherNo.ReadOnly = True
                    txtPayrollVoucherNo.TabStop = False
                    btnSetNewKey.TabStop = False
                    btnSetNewKey.Enabled = True
                    txtPayrollVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
                End If
            End If
        End If
    End Sub

    'Private Sub tdbcVoucherTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcVoucherTypeID.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
    '        tdbcVoucherTypeID.Text = ""
    '        txtVoucherTypeName.Text = ""
    '    End If
    'End Sub
#End Region

    Private Sub LoadMaster(ByVal sPayrollVoucherID As String)
        Dim sSQL As String = ""
        sSQL = "Select VoucherTypeID, PayrollVoucherNo, VoucherDate, Description" & UnicodeJoin(gbUnicode) & " as Description, "
        sSQL &= "PayrollVoucherID, TransTypeID, IsExcludeMaterity " & vbCrLf
        sSQL &= "From D13T0100  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where PayrollVoucherID = " & SQLString(sPayrollVoucherID)
        sSQL &= " And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub

        With dt.Rows(0)
            sEditTransTypeID = .Item("TransTypeID").ToString
            sEditVoucherTypeID = .Item("VoucherTypeID").ToString

            LoadTDBCombo()
            tdbcTransTypeID.SelectedValue = .Item("TransTypeID").ToString
            tdbcVoucherTypeID.Text = .Item("VoucherTypeID").ToString
            txtPayrollVoucherNo.Text = .Item("PayrollVoucherNo").ToString
            c1dateVoucherDate.Value = .Item("VoucherDate").ToString
            txtDescription.Text = .Item("Description").ToString
            chkIsExcludeMaterity.Checked = L3Bool(.Item("IsExcludeMaterity"))
        End With

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0100
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 08/02/2007 02:37:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0100() As String
        Dim sSQL As String = ""
        _payrollVoucherID = CreateIGE("D13T0100", "PayrollVoucherID", "13", "PV", gsStringKey)

        sSQL &= "Insert Into D13T0100("
        sSQL &= "DivisionID, PayrollVoucherID, TranMonth, TranYear, PayrollVoucherNo, "
        sSQL &= "VoucherTypeID, VoucherDate, Description, DescriptionU, "
        sSQL &= "CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, IsExcludeMaterity"
        sSQL &= ") Values ("
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID [KEY], varchar[20], NOT NULL
        sSQL &= SQLString(_payrollVoucherID) & COMMA 'PayrollVoucherID [KEY], varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NULL
        sSQL &= SQLString(txtPayrollVoucherNo.Text) & COMMA 'PayrollVoucherNo, varchar[20], NULL
        sSQL &= SQLString(tdbcVoucherTypeID.SelectedValue) & COMMA 'VoucherTypeID, varchar[20], NULL
        sSQL &= SQLDateSave(c1dateVoucherDate.Value) & COMMA 'VoucherDate, datetime, NULL
        sSQL &= SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA 'Description, varchar[50], NULL
        sSQL &= SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA 'Description, varchar[50], NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= "GetDate()" & COMMA 'LastModifyDate, datetime, NULL
        sSQL &= SQLNumber(chkIsExcludeMaterity.Checked) ' update 27/9/2013 id 59481
        sSQL &= ")"
        Return sSQL
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        'Kiểm tra ngày phiếu có phù hợp trog kỳ kế toán hiện tại hay không
        If Not CheckVoucherDateInPeriod(c1dateVoucherDate.Value.ToString) Then Exit Sub

        Dim sSQL As String = ""
        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL &= SQLInsertD13T0100().ToString() & vbCrLf
                sSQL &= SQLStoreD09P6210("MonthlySalaryFile", _payrollVoucherID, "01", txtPayrollVoucherNo.Text, txtDescription.Text).ToString() & vbCrLf
                ' update 3/4/2013 id 63610 
                If chkIsAutoAddEmps.Checked Then
                    sSQL &= vbCrLf & SQLStoreD13P0101()
                End If
                'Lưu LastKey xuống database
                If CInt(tdbcVoucherTypeID.Columns("Auto").Text) <> 0 Then ' Tạo mã tự động
                    CreateIGEVoucherNo(tdbcVoucherTypeID, True)
                End If
                'Kiểm tra trùng phiếu 
                If CheckDuplicateVoucherNo(D13, "D13T0100", _payrollVoucherID, txtPayrollVoucherNo.Text) Then
                    Me.Cursor = Cursors.Default
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
                    Exit Sub
                End If

            Case EnumFormState.FormEdit
                sSQL &= SQLStoreD09P6200("D13T0100", "PayrollVoucherID", _payrollVoucherID, 0, "PayrollVoucherID") & vbCrLf
                sSQL &= SQLUpdateD13T0100().ToString() & vbCrLf
                sSQL &= SQLStoreD09P6200("D13T0100", "PayrollVoucherID", _payrollVoucherID, 1, "PayrollVoucherID") & vbCrLf
                sSQL &= SQLStoreD09P6210("MonthlySalaryFile", _payrollVoucherID, "02", txtPayrollVoucherNo.Text, txtDescription.Text) & vbCrLf
            Case EnumFormState.FormOther
                sSQL &= SQLStoreD09P6200("D13T0100", "PayrollVoucherID", _payrollVoucherID, 0, "PayrollVoucherID") & vbCrLf
                sSQL &= SQLUpdateD13T0100().ToString() & vbCrLf
                sSQL &= SQLStoreD09P6200("D13T0100", "PayrollVoucherID", _payrollVoucherID, 1, "PayrollVoucherID") & vbCrLf
                sSQL &= SQLStoreD09P6210("MonthlySalaryFile", _payrollVoucherID, "02", txtPayrollVoucherNo.Text, txtDescription.Text) & vbCrLf

        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnDetail.Enabled = True
                    btnClose.Enabled = True
                    btnDetail.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
                Case EnumFormState.FormOther
                    btnSave.Enabled = False
                    btnDetail.Enabled = True
                    btnClose.Enabled = True
                    btnDetail.Focus()
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If
        If txtPayrollVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("So_phieu"))
            txtPayrollVoucherNo.Focus()
            Return False
        End If
        If txtDescription.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtDescription.Focus()
            Return False
        End If

        If txtDescription.Text.Trim <> "" And txtDescription.Text.Trim.Length > 250 Then
            ' UPDATE 5/7/2013 ID 57922
            D99C0008.MsgL3(rL3("Do_dai_Dien_giai_khong_duoc_vuot_qua_250_ky_tu"))
            '   D99C0008.MsgL3(rl3("Do_dai_Dien_giai_khong_duoc_vuot_qua_50_ky_tu"))
            txtDescription.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnSetNewKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetNewKey.Click
        GetNewVoucherNo(tdbcVoucherTypeID, txtPayrollVoucherNo)
    End Sub

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Dim f As New D13F2012
        Dim sSQL As String = ""
        With f
            .PayrollVoucherID = _payrollVoucherID
            .PayrollVoucherNo = txtPayrollVoucherNo.Text
            .VoucherDate = Date.Parse(c1dateVoucherDate.Value.ToString)
            .Description = txtDescription.Text
            .Path = IIf(_FormState = EnumFormState.FormAdd, "02", "03").ToString()
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0100
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 09/02/2007 09:42:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0100() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T0100 Set "
        sSQL &= "Description = " & SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA 'varchar[50], NULL
        sSQL &= "DescriptionU = " & SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA 'varchar[50], NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" 'datetime, NULL
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "PayrollVoucherID = " & SQLString(_payrollVoucherID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0101
    '# Created User: Hoàng Nhân
    '# Created Date: 03/04/2013 08:13:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0101() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Luu Detail" & vbCrlf)
        sSQL &= "Exec D13P0101 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_payrollVoucherID) & COMMA 'PayrollVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F2011") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'EmployeeID, varchar[20], NOT NULL
        If chkIsAutoAddEmps.Checked Then
            sSQL &= SQLNumber(chkIsExcludeMaterity.Checked) 'IsExcludeMaterity, int, NOT NULL
        Else
            sSQL &= SQLNumber(0) 'IsExcludeMaterity, int, NOT NULL
        End If

        Return sSQL
    End Function

End Class