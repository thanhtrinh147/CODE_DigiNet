'#-------------------------------------------------------------------------------------
'# Created Date: 19/01/2006 10:43:50 AM
'# Created User: Huỳnh Thị Mai Duyên
'# Modify Date: 31/01/2008
'# Modify User: dmd
'Content: bỏ chkIsTimeSheet
'#-------------------------------------------------------------------------------------


Public Class D13F1001
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
    End Property

    Private _formIDPermission As String = "D13F1000"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
    Dim sAbsentTypeID As String
    Private iOrdersMax As Int32

    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            LoadTDBCombo()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    CheckIdTextBox(txtAbsentTypeDateID)
                    btnNext.Enabled = False
                    btnAbsentConversion.Enabled = False
                    LoadAdd()
                Case EnumFormState.FormEdit
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    txtAbsentTypeDateID.Enabled = False
                    btnCofficientInfo.Enabled = ReturnPermission("D13F5601") > 0
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False
                    btnAbsentConversion.Enabled = False
                    txtAbsentTypeDateID.Enabled = False
                    btnCofficientInfo.Enabled = ReturnPermission("D13F5601") > 0
                    LoadEdit()
            End Select
        End Set
    End Property

    Public Property AbsentTypeDateID() As String
        Get
            Return sAbsentTypeID
        End Get
        Set(ByVal value As String)
            sAbsentTypeID = value
        End Set
    End Property
    Public Property OrdersMax() As Int32
        Get
            Return iOrdersMax
        End Get
        Set(ByVal value As Int32)
            iOrdersMax = value
        End Set
    End Property

    Private Sub D13F1001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then UseEnterAsTab(Me)
    End Sub

    Private Sub D13F1001_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        SetBackColorObligatory()
        CheckIdTextBoxG4(txtAbsentTypeDateID)
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)

    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        'Me.Text = rl3("Cap_nhat_loai_cham_cong_-_D13F1001") 'CËp nhËt loÁi chÊm c¤ng - D13F1001
        Me.Text = rl3("Cap_nhat_Khoan_dieu_chinh_thu_nhap_-_D13F1001") & UnicodeCaption(gbUnicode) 'CËp nhËt Kho¶n ¢iÒu chÙnh thu nhËp - D13F1001
        '================================================================ 
        lblClassification.Text = rl3("Loai_danh_gia") 'Loại đánh giá
        lblAbsentTypeID.Text = rl3("Ma") 'Mã 
        lblAbsentTypeName.Text = rl3("Dien_giai") 'Diễn giải
        lblLookup.Text = rl3("Ten_tat") 'Tên tắt
        lblOrders.Text = rl3("Thu_tu_hien_thi") 'Thứ tự hiển thị
        lblUnitID.Text = rl3("DVT") 'ĐVT
        lblDecimals.Text = rl3("Lam_tron") 'Làm tròn
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        btnCofficientInfo.Text = rl3("Thong_tin__he_so") 'Thông tin &hệ số
        btnAbsentConversion.Text = rl3("_Quy_doi_cong") '&Quy đổi công
        '================================================================ 
        'chkIsTimeSheet.Text = rl3("Bang_cham_cong_nhat") 'Bảng chấm công nhật
        chkIsValue.Text = rl3("Hien_thi_gia_tri_cua_moi_loai") 'Hiển thị giá trị của mỗi loại
        chkIsClassification.Text = rl3("Danh_gia_xep_loai") 'Đánh giá xếp loại
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        'grpAbsentType.Text = rl3("Loai_cham_cong") 'Loại chấm công
        '================================================================ 
        tdbcClassification.Columns("ClassificationID").Caption = rl3("Ma") 'Mã
        tdbcClassification.Columns("ClassificationName").Caption = rl3("Dien_giai") 'Diễn giải
    End Sub

    Private Sub LoadAdd()
        txtAbsentTypeDateID.Text = ""
        chkDisabled.Visible = False

        txtAbsentTypeDateName.Text = ""
        txtLookup.Text = ""
        txtOrders.Text = (iOrdersMax + 1).ToString
        'iOrdersMax = CInt(txtOrders.Text)
        txtUnitID.Text = ""
        cboDecimals.Text = "0"
        tdbcClassification.Text = ""
        txtClassificationName.Text = ""
        chkIsClassification.Checked = False
        tdbcClassification.Enabled = False
        'chkIsTimeSheet.Checked = False
        chkIsValue.Checked = False
        chkIsValue.Enabled = False
        btnCofficientInfo.Enabled = False
        txtAbsentTypeDateID.Focus()
    End Sub

    Private Sub LoadEdit()
        chkDisabled.Visible = True
        Dim sSQL As String
        Dim dt As DataTable
        sSQL = ""
        sSQL &= "Select AbsentTypeDateID, AbsentTypeDateName, AbsentTypeDateNameU, Disabled, Orders, Unit, UnitID, UnitIDU," & vbCrLf
        sSQL &= "Lookup, LookupU, IsDailySheet, IsClassification, ClassificationID, IsValue, IsTimeSheet, Decimals" & vbCrLf
        sSQL &= "From D13T0118  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where AbsentTypeDateID = " & SQLString(sAbsentTypeID)
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                txtAbsentTypeDateID.Text = .Item("AbsentTypeDateID").ToString
                txtAbsentTypeDateName.Text = .Item("AbsentTypeDateName" & UnicodeJoin(gbUnicode)).ToString
                txtLookup.Text = .Item("Lookup" & UnicodeJoin(gbUnicode)).ToString
                txtOrders.Text = .Item("Orders").ToString
                txtUnitID.Text = .Item("UnitID" & UnicodeJoin(gbUnicode)).ToString
                cboDecimals.Text = .Item("Decimals").ToString
                chkDisabled.Checked = L3Bool(.Item("Disabled").ToString)
                If CInt(.Item("IsClassification")) = 1 Then
                    chkIsClassification.Checked = True
                    tdbcClassification.Enabled = True
                Else
                    chkIsClassification.Checked = False
                    tdbcClassification.Enabled = False
                    chkIsValue.Enabled = False
                End If
                tdbcClassification.SelectedValue = .Item("ClassificationID").ToString
                If CInt(.Item("IsValue")) = 1 Then
                    chkIsValue.Checked = True
                Else
                    chkIsValue.Checked = False
                End If

                'If CInt(.Item("IsTimeSheet")) = 1 Then
                '    chkIsTimeSheet.Checked = True
                'Else
                '    chkIsTimeSheet.Checked = False
                'End If
            End With
        End If
        txtAbsentTypeDateName.Focus()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False
        _bSaved = False
        Dim sSQL As String = ""
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL = SQLInsertD13T0118()
            Case EnumFormState.FormEdit
                sSQL = SQLUpdateD13T0118()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    sAbsentTypeID = txtAbsentTypeDateID.Text
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnCofficientInfo.Enabled = ReturnPermission("D13F5601") > 0
                    btnAbsentConversion.Enabled = True
                    iOrdersMax = CInt(txtOrders.Text)
                Case EnumFormState.FormEdit
                    'Audit Log
                    Dim sDesc1 As String = txtAbsentTypeDateID.Text
                    Dim sDesc2 As String = txtAbsentTypeDateName.Text
                    Dim sDesc3 As String = txtUnitID.Text
                    Dim sDesc4 As String = ""
                    Dim sDesc5 As String = ""
                    RunAuditLog(AuditCodeAttendanceTypes, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

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

    Private Function AllowSave() As Boolean
        AllowSave = False
        Dim sSQL As String = ""
        If txtAbsentTypeDateID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_loai_cham_cong"))
            txtAbsentTypeDateID.Focus()
            Return False
        End If
        If txtAbsentTypeDateName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_cham_cong"))
            txtAbsentTypeDateName.Focus()
            Return False
        End If
        If txtLookup.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
            txtLookup.Focus()
            Return False
        End If
        If txtOrders.Text.Trim <> "" Then
            If CInt(txtOrders.Text) > MaxTinyInt Then
                D99C0008.Msg(rl3("Ban_da_nhap_du_lieu_khong_hop_le"))
                txtOrders.Text = ""
                txtOrders.Focus()
                Exit Function
            End If
        End If
        If txtUnitID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_don_vi_tinh"))
            txtUnitID.Focus()
            Return False
        End If

        If cboDecimals.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Lam_tron"))
            cboDecimals.Focus()
            Return False
        End If

        If _FormState = EnumFormState.FormAdd Then
            sSQL = "select 1 from D13T0118  WITH (NOLOCK) where AbsentTypeDateID = " & SQLString(txtAbsentTypeDateID.Text)
            If ExistRecord(sSQL) Then
                D99C0008.MsgL3(rl3("Ma_loai_cham_cong_nay_da_ton_tai"))
                txtAbsentTypeDateID.Focus()
                Return False
            End If
            sSQL = "select 1 from D13T0118  WITH (NOLOCK) where Orders = " & SQLNumber(txtOrders.Text)
            If ExistRecord(sSQL) Then
                D99C0008.MsgL3(rL3("So_thu_tu_nay_da_ton_tai"))
                txtOrders.Focus()
                Return False
            End If
        Else
            If _FormState = EnumFormState.FormEdit Then
                sSQL = "select 1 from D13T0118  WITH (NOLOCK) where Orders = " & SQLNumber(txtOrders.Text) & " AND  AbsentTypeDateID <> " & SQLString(txtAbsentTypeDateID.Text)
                If ExistRecord(sSQL) Then
                    D99C0008.MsgL3(rL3("So_thu_tu_nay_da_ton_tai"))
                    txtOrders.Focus()
                    Return False
                End If
            End If

        End If
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0118
    '# Created User: 
    '# Created Date: 19/01/2006 02:04:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0118() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D13T0118("
        sSQL &= "AbsentTypeDateID, AbsentTypeDateName, AbsentTypeDateNameU, Disabled, CreateUserID, CreateDate, "
        sSQL &= "LastModifyUserID, LastModifyDate, Orders,  UnitID,  UnitIDU, "
        sSQL &= "Lookup, LookupU, IsDailySheet, IsClassification, ClassificationID, IsValue, "
        sSQL &= "IsTimeSheet, Decimals"
        sSQL &= ") Values ("
        sSQL &= SQLString(txtAbsentTypeDateID.Text) & COMMA 'AbsentTypeDateID [KEY], varchar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtAbsentTypeDateName, False) & COMMA 'AbsentTypeDateName, varchar[50], NULL
        sSQL &= SQLStringUnicode(txtAbsentTypeDateName, True) & COMMA 'AbsentTypeDateName, varchar[50], NULL
        sSQL &= SQLNumber(IIf(chkDisabled.Checked = True, 1, 0)) & COMMA 'Disabled, bit, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'LastModifyDate, datetime, NULL
        sSQL &= SQLNumber(txtOrders.Text) & COMMA 'Orders, tinyint, NULL
        sSQL &= SQLStringUnicode(txtUnitID, False) & COMMA 'UnitID, varchar[20], NULL
        sSQL &= SQLStringUnicode(txtUnitID, True) & COMMA 'UnitID, varchar[20], NULL
        sSQL &= SQLStringUnicode(txtLookup, False) & COMMA 'Lookup, varchar[20], NULL
        sSQL &= SQLStringUnicode(txtLookup, True) & COMMA 'Lookup, varchar[20], NULL
        sSQL &= SQLNumber(0) & COMMA 'IsDailySheet, tinyint, NOT NULL
        sSQL &= SQLNumber(IIf(chkIsClassification.Checked = True, 1, 0)) & COMMA 'IsClassification, tinyint, NOT NULL
        sSQL &= SQLString(tdbcClassification.SelectedValue) & COMMA 'ClassificationID, varchar[20], NULL
        sSQL &= SQLNumber(IIf(chkIsValue.Checked = True, 1, 0)) & COMMA 'IsValue, tinyint, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'IsTimeSheet, tinyint, NOT NULL
        sSQL &= SQLNumber(cboDecimals.Text) 'IsTimeSheet, tinyint, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0118
    '# Created User: 
    '# Created Date: 19/01/2006 02:09:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0118() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T0118 Set "
        sSQL &= "AbsentTypeDateName = " & SQLStringUnicode(txtAbsentTypeDateName, False) & COMMA 'varchar[50], NULL
        sSQL &= "AbsentTypeDateNameU = " & SQLStringUnicode(txtAbsentTypeDateName, True) & COMMA 'varchar[50], NULL
        sSQL &= "Disabled = " & SQLNumber(IIf(chkDisabled.Checked = True, 1, 0)) & COMMA 'bit, NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" & COMMA 'datetime, NULL
        sSQL &= "Orders = " & SQLNumber(txtOrders.Text) & COMMA 'tinyint, NULL
        sSQL &= "UnitID = " & SQLStringUnicode(txtUnitID, False) & COMMA 'varchar[20], NULL
        sSQL &= "UnitIDU = " & SQLStringUnicode(txtUnitID, True) & COMMA 'varchar[20], NULL
        sSQL &= "Lookup = " & SQLStringUnicode(txtLookup, False) & COMMA 'varchar[20], NULL
        sSQL &= "LookupU = " & SQLStringUnicode(txtLookup, True) & COMMA 'varchar[20], NULL
        sSQL &= "IsDailySheet = " & SQLNumber(0) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsClassification = " & SQLNumber(IIf(chkIsClassification.Checked = True, 1, 0)) & COMMA 'tinyint, NOT NULL
        sSQL &= "ClassificationID = " & SQLString(tdbcClassification.SelectedValue) & COMMA 'varchar[20], NULL
        sSQL &= "IsValue = " & SQLNumber(IIf(chkIsValue.Checked = True, 1, 0)) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsTimeSheet = " & SQLNumber(1) & COMMA 'tinyint, NOT NULL
        sSQL &= "Decimals = " & SQLNumber(cboDecimals.Text) 'tinyint, NOT NULL
        sSQL &= " Where "
        sSQL &= "AbsentTypeDateID = " & SQLString(txtAbsentTypeDateID.Text)
        Return sSQL
    End Function

    Private Sub txtOrders_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrders.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub SetBackColorObligatory()
        txtAbsentTypeDateID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtAbsentTypeDateName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtOrders.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtLookup.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtUnitID.BackColor = COLOR_BACKCOLOROBLIGATORY
        cboDecimals.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcClassification
        sSQL = "Select Distinct  ClassificationID, "
        sSQL &= IIf(gbUnicode, "ClassificationNameU As ClassificationName", "ClassificationName").ToString
        sSQL &= " From D13T0120  WITH (NOLOCK) Where Disabled = 0 "
        LoadDataSource(tdbcClassification, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcClassification with txtClassificationName"

    Private Sub tdbcClassification_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcClassification.Close
        If tdbcClassification.FindStringExact(tdbcClassification.Text) = -1 Then
            tdbcClassification.Text = ""
            txtClassificationName.Text = ""
        End If
    End Sub

    Private Sub tdbcClassification_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcClassification.SelectedValueChanged
        txtClassificationName.Text = tdbcClassification.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcClassification_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcClassification.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcClassification.Text = ""
        '    txtClassificationName.Text = ""
        'End If
    End Sub
#End Region

    Private Sub txtAbsentTypeDateID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbsentTypeDateID.Validated
        If txtLookup.Text = "" Then
            txtLookup.Text = txtAbsentTypeDateID.Text
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        btnSave.Enabled = True
        btnNext.Enabled = False
        LoadAdd()
    End Sub

    Private Sub chkIsClassification_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsClassification.Click
        If chkIsClassification.Checked Then
            tdbcClassification.Enabled = True
            chkIsValue.Enabled = True
        Else
            tdbcClassification.Text = ""
            tdbcClassification.Enabled = False
            chkIsValue.Checked = False
            chkIsValue.Enabled = False
        End If
    End Sub

    Private Sub btnCofficientInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCofficientInfo.Click
        Dim f As New D13F1110
        With f
            .Type = "D13T0118"
            .TypeID = txtAbsentTypeDateID.Text
            .FormIDPermission = _formIDPermission
            .FormState = _FormState

            .ShowInTaskbar = False
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub btnAbsentConversion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbsentConversion.Click
        Dim sSQL As String = ""
        Dim sMethodID As String = ""
        Dim sCycle As String = ""
        Dim sConvertionHours As String = ""
        Dim sDecimal1 As String = "0"

        sSQL &= "Select MethodID, Cycle, ConvertionHours, Decimal1" & vbCrLf
        sSQL &= "From D13T0118 " & vbCrLf
        sSQL &= "Where AbsentTypeDateID = " & SQLString(txtAbsentTypeDateID.Text)

        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                If Number(.Item("ConvertionHours")) <> 0 Then
                    sMethodID = .Item("MethodID").ToString
                    sCycle = IIf(Number(.Item("Cycle")) = 0, "", SQLNumber(.Item("Cycle"), D13Format.DefaultNumber2)).ToString
                    sConvertionHours = IIf(Number(.Item("ConvertionHours")) = 0, "", SQLNumber(.Item("ConvertionHours"), D13Format.DefaultNumber2)).ToString
                    sDecimal1 = .Item("Decimal1").ToString
                End If
            End With
        End If

        Dim f As New D13F1002
        With f
            .ShowInTaskbar = False
            .AbsentTypeDateID = txtAbsentTypeDateID.Text
            .MethodID = sMethodID
            .Cycle = sCycle
            .ConvertionHours = sConvertionHours
            .Decimal1 = sDecimal1
            .ShowDialog()
            .Dispose()
        End With
    End Sub

End Class