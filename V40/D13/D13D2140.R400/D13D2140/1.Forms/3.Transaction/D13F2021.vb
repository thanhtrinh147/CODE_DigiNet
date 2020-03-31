Imports System
Imports System.Text

Public Class D13F2021
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_IsCheck As Integer = 0        ' Chọn
    Private Const COL_DepartmentID As Integer = 1   ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 2 ' Tên phòng ban
#End Region

    Dim sEditVoucherTypeID As String = ""
    Dim sEditTransTypeID As String = ""
    Private dtTeamID As DataTable
    Private dtDepartmentID As DataTable

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Private _formCall As String = ""
    Public WriteOnly Property FormCall() As String 
        Set(ByVal Value As String )
            _formCall = value
        End Set
    End Property
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()

            LoadTDBCBlockID()
            CreateTableTeamID()
            CreateTableDepartmentID()

            _bSaved = False
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBCombo()
                    LoadAddNew()
                    chkIsCheckDepartment.Checked = False
                    tdbg.Enabled = False
                    btnCheck.Enabled = False
                    EnableTdbcTeamID()
                Case EnumFormState.FormEdit
                    LoadEdit()
                    btnCheck.Enabled = False
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    btnCheck.Enabled = True
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _AbsentVoucherID As String = ""
    Public Property AbsentVoucherID() As String
        Get
            Return _AbsentVoucherID
        End Get
        Set(ByVal Value As String)
            If _AbsentVoucherID = Value Then
                _AbsentVoucherID = ""
                Return
            End If
            _AbsentVoucherID = Value
        End Set
    End Property

    '    Private _EntryDate As DateTime
    '    Public Property EntryDate() As DateTime
    '        Get
    '            Return _EntryDate
    '        End Get
    '        Set(ByVal Value As DateTime)
    '            _EntryDate = Value
    '        End Set
    '    End Property

    Private _NewPayrollVoucherID As String = ""
    Private _OldPayrollVoucherID As String = ""
    Public Property NewPayrollVoucherID() As String
        Get
            Return _NewPayrollVoucherID
        End Get
        Set(ByVal Value As String)
            _NewPayrollVoucherID = Value
        End Set
    End Property
    Public Property OldPayrollVoucherID() As String
        Get
            Return _OldPayrollVoucherID
        End Get
        Set(ByVal Value As String)
            _OldPayrollVoucherID = Value
        End Set
    End Property

    Private _savedOk As Boolean = False
    Public Property SavedOk() As Boolean
        Get
            Return _savedOk
        End Get
        Set(ByVal Value As Boolean)
            _savedOk = Value
        End Set
    End Property

    '    Private Sub btnSetNewKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        GetNewVoucherNo(tdbcVoucherTypeID, txtAbsentVoucherNo)
    '    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D13F2021_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    txtRemark.Focus()
                Case Keys.D2, Keys.NumPad2
                    c1dateDateFrom.Focus()
                Case Keys.D3, Keys.NumPad3
                    tdbcBlockID.Focus()
            End Select
        End If
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        End If
    End Sub
    Private Sub CallFormOthers()
        If _formCall = "D09F2250" Then
            tdbcTransTypeID.Enabled = False
            tdbcAttMode.SelectedValue = "0"
            tdbcAttMode.Enabled = False
            tdbcDepartmentID.Enabled = False
            tdbcBlockID.Enabled = False
            tdbcSalaryObjectID.Enabled = False
            tdbcProjectID.Enabled = False
            tdbcTeamID.Enabled = False
            chkIsCheckDepartment.Enabled = False
            chkIsAutoAddEmp.Checked = True
            chkIsAutoAddEmp.Enabled = False
        End If
    End Sub

    Private Sub D13F2021_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        Loadlanguage()
        Me.Cursor = Cursors.WaitCursor
        InputbyUnicode(Me, gbUnicode)
        tdbg_LockedColumns()
        SetBackColorObligatory()
        ' 21/1/2014 id 61589 
        Dim bIsAdvancedPeriod As Integer = L3Int(ReturnScalar("SELECT IsAdvancedPeriod FROM D29T0000 WITH (NOLOCK)"))
        If bIsAdvancedPeriod = 0 Then
            optIsAdvancedSal1.Enabled = False
        End If
        InputDateCustomFormat(c1dateDateTo, c1dateDateFrom)
        CallFormOthers()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_phieu_dieu_chinh_thu_nhap_-_D13F2021") & UnicodeCaption(gbUnicode) 'CËp nhËt phiÕu ¢iÒu chÙnh thu nhËp - D13F2021
        '================================================================ 
        lblRemark.Text = rl3("Dien_giai") 'Ghi chú
        lblteDateFrom.Text = rl3("Thoi_gian") 'Từ
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblProjectID.Text = rl3("Cong_trinh") 'Công trình
        lblAttMode.Text = rl3("Phuong_phap")
        lblNcodeType.Text = rl3("Ma_loai_PTNS")
        lblTransTypeID.Text = rl3("Mau_thiet_lapU")
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnCheck.Text = rl3("_Chi_tiet") '&Chi tiết
        '================================================================ 
        chkIsCheckDepartment.Text = rl3("Theo_phong_ban") 'Theo phòng ban
        chkIsAutoAddEmp.Text = rl3("Tu_dong_them_NV_vao_phieu_dieu_chinh_thu_nhap") 'Tự động thêm NV vào phiếu điều chỉnh thu nhập
        '================================================================ 
        optIsAdvancedSal0.Text = rl3("Luong_chinh")
        optIsAdvancedSal1.Text = rl3("Luong_ung")
        '================================================================ 
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcProjectID.Columns("ProjectID").Caption = rl3("Ma") 'Mã
        tdbcProjectID.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbcAttMode.Columns("AttMode").Caption = rl3("Ma") 'Mã
        tdbcAttMode.Columns("AttModeName").Caption = rl3("Ten") 'Tên
        tdbcNCodeType.Columns("NCodeTypeID").Caption = rl3("Ma") 'Mã
        tdbcNCodeType.Columns("NCodeTypeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("IsCheck").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("DepartmentName").Caption = rL3("Ten_phong_ban") 'Tên phòng ban

        '================================================================ 
        lblBlockID.Text = rL3("Khoi") 'Khối
        lblSalaryObjectID.Text = rL3("Doi_tuong_tinh_luong") 'ĐT tính lương
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
        tdbcSalaryObjectID.Columns("SalaryObjectID").Caption = rL3("Ma") 'Mã
        tdbcSalaryObjectID.Columns("SalaryObjectName").Caption = rL3("Ten") 'Tên

    End Sub

    Private Sub SetBackColorObligatory()
        tdbcAttMode.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcNCodeType.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtRemark.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadAddNew()
        LoadDefaultDate()
        tdbcNCodeType.Visible = False
        lblNcodeType.Visible = False
    End Sub

    Private Sub LoadDefaultDate()
        c1dateDateFrom.Value = Now.Date
        c1dateDateFrom.Tag = c1dateDateFrom.Value

        c1dateDateTo.Value = Now.Date
        c1dateDateTo.Tag = c1dateDateTo.Value

        tdbcBlockID.SelectedValue = "%"
        tdbcBlockID.Enabled = D13Systems.IsUseBlock
        tdbcProjectID.SelectedValue = "%"
        tdbcDepartmentID.SelectedValue = "%"
        tdbcTeamID.SelectedValue = "%"
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String
        sSQL = "Select D1.TransTypeID, D1.AbsentVoucherID,D1.TranMonth,D1.TranYear,D1.VoucherTypeID, " & vbCrLf
        sSQL &= "D1.AbsentVoucherNo,D1.EntryDate,D1.Remark" & UnicodeJoin(gbUnicode) & " as Remark,D1.DateFrom,D1.DateTo, " & vbCrLf
        sSQL &= "D1.PayrollVoucherID,D2.PayrollVoucherNo,D1.BlockID,D1.DepartmentID,D1.TeamID, D1.ProjectID,D1.SalaryObjectID, AttMode, D1.IsCheckDepartment, NCodeTypeID, " & vbCrLf
        sSQL &= "CONVERT(Bit,D1. IsAutoAddEmp) AS IsAutoAddEmp, IsAdvancedSal" & vbCrLf
        sSQL &= "From D13T0102 D1  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Inner join D13T0100 D2  WITH (NOLOCK) On D2.PayrollVoucherID=D1.PayrollVoucherID " & vbCrLf
        sSQL &= "Where D1.DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "And AbsentVoucherID=" & SQLString(_AbsentVoucherID)

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                '                Select Case .Item("AttMode").ToString
                '                    Case "0"
                '                        optEmployee.Checked = True
                '                    Case "1"
                '                        optTeam.Checked = True
                '                    Case "2"
                '                        optDepartment.Checked = True
                '                        'Update 16/02/2012: Incident 45314 Bổ sung thêm 2 option Nhóm nhân viên và Đơn vị
                '                    Case "3"
                '                        optGroupEmp.Checked = True
                '                    Case "4"
                '                        optDivision.Checked = True
                '                End Select

                sEditTransTypeID = .Item("TransTypeID").ToString
                sEditVoucherTypeID = .Item("VoucherTypeID").ToString

                LoadTDBCombo()
                tdbcAttMode.SelectedValue = .Item("AttMode").ToString
                tdbcTransTypeID.SelectedValue = .Item("TransTypeID").ToString
                '                tdbcVoucherTypeID.Text = .Item("VoucherTypeID").ToString
                '                txtAbsentVoucherNo.Text = .Item("AbsentVoucherNo").ToString
                txtRemark.Text = .Item("Remark").ToString

                c1dateDateFrom.Value = SQLDateShow(.Item("DateFrom").ToString)
                c1dateDateTo.Value = SQLDateShow(.Item("DateTo").ToString)
                '  c1dateEntryDate.Value = SQLDateShow(.Item("EntryDate").ToString)
                _OldPayrollVoucherID = .Item("PayrollVoucherID").ToString
                _NewPayrollVoucherID = .Item("PayrollVoucherID").ToString
                tdbcBlockID.SelectedValue = .Item("BlockID").ToString
                tdbcDepartmentID.SelectedValue = .Item("DepartmentID").ToString

                tdbcTeamID.SelectedValue = .Item("TeamID").ToString
                tdbcProjectID.SelectedValue = .Item("ProjectID").ToString

                tdbcSalaryObjectID.SelectedValue = .Item("SalaryObjectID").ToString
                tdbcNCodeType.SelectedValue = .Item("NCodeTypeID").ToString
                EnableTdbcTeamID()

                chkIsCheckDepartment.Checked = L3Bool(.Item("IsCheckDepartment").ToString)
                chkIsAutoAddEmp.Checked = L3Bool(.Item("IsAutoAddEmp").ToString)

                If chkIsCheckDepartment.Checked Then
                    LoadTDBGrid(True)
                    ReadOnlyControl(tdbcDepartmentID, tdbcTeamID)
                Else
                    tdbg.Enabled = False
                    UnReadOnlyControl(True, tdbcDepartmentID, tdbcTeamID)
                End If

                If L3Int(.Item("IsAdvancedSal")) = 0 Then
                    optIsAdvancedSal0.Checked = True
                Else
                    optIsAdvancedSal1.Checked = True
                End If
            End With

        End If
    End Sub

    Private Function AllowSave() As Boolean
        '        If CDate(c1dateDateFrom.Value) > CDate(c1dateDateTo.Value) Then
        '            D99C0008.MsgL3(rl3("Gia_tri_Tu_ngay_khong_duoc_lon_hon_gia_tri_Den_ngay"))
        '            c1dateDateFrom.Focus()
        '            Return False
        '        End If
        If c1dateDateFrom.Enabled Then ' 8/4/2014 id 64733 
            If Not CheckValidDateFromTo(c1dateDateFrom, c1dateDateTo) Then
                Return False
            End If
        End If
        If txtRemark.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Dien_giai"))
            txtRemark.Focus()
            Return False
            'Else
            '    If txtRemark.TextLength > 500 Then
            '        D99C0008.MsgL3(rL3("Ghi_chu_khong_duoc_vuot_qua_50_ky_tu"))
            '        txtRemark.Focus()
            '        Return False
            '    End If
        End If
        If tdbcAttMode.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phuong_phap"))
            tdbcAttMode.Focus()
            Return False
        End If
        If ReturnValueC1Combo(tdbcAttMode).ToString = "5" And tdbcNCodeType.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ma_loai_PTNS"))
            tdbcNCodeType.Focus()
            Return False
        End If
        If D13Systems.IsUseBlock AndAlso tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblBlockID.Text)
            tdbcBlockID.Focus()
            Return False
        End If
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

        If chkIsCheckDepartment.Checked Then
            tdbg.UpdateData()
            dtGrid.AcceptChanges()
            Dim dr() As DataRow = dtGrid.Select("IsCheck = True")
            If dr.Length <= 0 Then
                D99C0008.MsgNoDataInGrid()
                tdbg.Focus()
                tdbg.Col = COL_IsCheck
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub LoadEdit()
        ' grpAbsentMethod.Enabled = False
        tdbcAttMode.Enabled = False
        tdbcNCodeType.Enabled = False

        tdbcTransTypeID.Enabled = False
        LoadMaster()

        ' Update 1/8/2012 incident 50402 - Bỏ các câu lệnh sau khi load Edit: SELECT count(*) From   D13T0103 ………… ;SELECT count(*) From   D13T0104 …………
        '        If IsCheck(ReturnCheckOption) = True Then ' Đã có chi tiết phiếu
        '            tdbcPayrollVoucherNo.Enabled = False
        '            chkIsCheckDepartment.Enabled = False
        '            tdbg.Enabled = False
        '        Else
        '            tdbcPayrollVoucherNo.Enabled = True
        '        End If

        ' Update 1/8/2012 incident 50402
        Dim sSQL1 As String = ""
        sSQL1 = "-- Kiem tra phieu đa ton tai chi tiet hay chua?" & vbCrLf
        sSQL1 &= " Select Top 1 1 "
        sSQL1 &= " From D13T0113 WITH (NOLOCK) "
        sSQL1 &= " Where  AbsentVoucherID = " & SQLString(_AbsentVoucherID) ' @AbsentVoucherID
        Dim sSQL2 As String = ""
        sSQL2 = "-- Kiem tra phieu đa ton tai chi tiet hay chua?" & vbCrLf
        sSQL2 &= " Select Top 1 1 "
        sSQL2 &= " From D13T0104 WITH (NOLOCK) "
        sSQL2 &= " Where AbsentVoucherID = " & SQLString(_AbsentVoucherID) '@AbsentVoucherID"
        Dim IsDetail As Boolean = ExistRecord(sSQL1) Or ExistRecord(sSQL2)
        If IsDetail Then ' ReadOnly tất cả thông tin khác khi IsDetail=1 trừ "Ghi chú"
            c1dateDateFrom.Enabled = False
            c1dateDateTo.Enabled = False
            tdbcAttMode.Enabled = False
            tdbcNCodeType.Enabled = False
            tdbcDepartmentID.Enabled = False
            tdbcTeamID.Enabled = False
            tdbcProjectID.Enabled = False
            chkIsCheckDepartment.Enabled = False

            tdbcBlockID.Enabled = False
            tdbcSalaryObjectID.Enabled = False
        End If
        '--------------------------------------------------------
    End Sub

    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAttMode.LostFocus, tdbcNCodeType.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAttMode.Close, tdbcNCodeType.Close, tdbcDepartmentID.Close, tdbcTeamID.Close, tdbcProjectID.Close, tdbcBlockID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAttMode.Validated, tdbcNCodeType.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated, tdbcProjectID.Validated, tdbcBlockID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
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
        '        If tdbcTransTypeID.Columns("VoucherTypeID").Text <> "" Then
        '            tdbcVoucherTypeID.Text = tdbcTransTypeID.Columns("VoucherTypeID").Text
        '        End If
    End Sub

#End Region

#Region "Events tdbcBlockID"

    Private Sub tdbcBlockID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.LostFocus
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then tdbcBlockID.Text = ""
    End Sub
    Private Sub tdbcBlockID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcBlockID.SelectedValueChanged
        LoadtdbcDepartmentID(tdbcDepartmentID, dtDepartmentID, ReturnValueC1Combo(tdbcBlockID).ToString, gbUnicode)
        tdbcDepartmentID.SelectedValue = "%"
    End Sub


#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.LostFocus
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then tdbcDepartmentID.Text = ""
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        'tdbcTeamID.Text = ""
        'If tdbcDepartmentID.Text <> "" Then
        'LoadtdbcTeamID()
        'End If
        LoadtdbcTeamID(tdbcTeamID, dtTeamID, ReturnValueC1Combo(tdbcBlockID).ToString, ReturnValueC1Combo(tdbcDepartmentID).ToString, gbUnicode)
        tdbcTeamID.SelectedValue = "%"
    End Sub

#End Region

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.LostFocus
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then tdbcTeamID.Text = ""
    End Sub

#End Region

#Region "Events tdbcProjectID"

    Private Sub tdbcProjectID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProjectID.LostFocus
        If tdbcProjectID.FindStringExact(tdbcProjectID.Text) = -1 Then tdbcProjectID.Text = ""
    End Sub

#End Region

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcTransTypeID
        LoadTdbcTransTypeID(tdbcTransTypeID, "0002", sEditTransTypeID)

        'Load tdbcProjectID
        sSQL = "-- Do nguon combo du an" & vbCrLf
        sSQL &= " SELECT '%' as ProjectID, " & AllName & " as Description, 0 As DisplayOrder" & vbCrLf
        sSQL &= " Union All " & vbCrLf
        sSQL &= " Select ProjectID,Description" & UnicodeJoin(gbUnicode) & " as Description, 1 As DisplayOrder From D09T1080 WITH (NOLOCK) " & vbCrLf
        sSQL &= " Where Disabled = 0 " & vbCrLf
        sSQL &= " Order by DisplayOrder,ProjectID"
        LoadDataSource(tdbcProjectID, sSQL, gbUnicode)

        ' Update 1/8/2012 incident 50402
        ' Load tdbc AttMode
        sSQL = "-- Do nguon combo AttMode" & vbCrLf
        sSQL &= "SELECT ID as AttMode, Name" & gsLanguage & UnicodeJoin(gbUnicode) & " as AttModeName "
        sSQL &= "FROM	D13N5555 ('D13F2021', '', '', '', '')"
        LoadDataSource(tdbcAttMode, sSQL, gbUnicode)
        ' ẩn cột AttMode (Mã)
        tdbcAttMode.Splits(0).DisplayColumns("AttMode").Visible = False

        ' Load tdbc NCodeType
        sSQL = "-- Do nguon combo NCodeType" & vbCrLf
        sSQL &= "SELECT TypeID as NCodeTypeID, Description" & UnicodeJoin(gbUnicode) & " As NCodeTypeName"
        sSQL &= " FROM D09T0010  WITH (NOLOCK) "
        sSQL &= " WHERE Disabled = 0 "
        sSQL &= " ORDER BY 	TypeID"
        LoadDataSource(tdbcNCodeType, sSQL, gbUnicode)

        'Load tdbcSalaryObjectID
        sSQL = " SELECT '%' as SalaryObjectID, " & AllName & " as SalaryObjectName, 0 As DisplayOrder" & vbCrLf
        sSQL &= " Union All" & vbCrLf
        sSQL &= " Select SalaryObjectID, SalaryObjectNameU as SalaryObjectName, 1 As DisplayOrder " & vbCrLf
        sSQL &= " From D13T1020 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where Disabled = 0 " & vbCrLf
        sSQL &= " Order by DisplayOrder"
        LoadDataSource(tdbcSalaryObjectID, sSQL, gbUnicode)
        tdbcSalaryObjectID.SelectedValue = "%"

    End Sub

    Private Sub LoadTDBCBlockID()
        Dim sSQL As String = ""
        'Load tdbcDepartmentID
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************

        sSQL = "Select Distinct D09.BlockID,  D09.BlockName" & sUnicode & " As BlockName, D09.DivisionID,1 as DisplayOrder " & vbCrLf
        sSQL &= "From D13T0101 D13  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Left Join D91T0012 D91  WITH (NOLOCK)  On D13.DepartmentID = D91.DepartmentID " & vbCrLf
        sSQL &= "Left Join D09T1140 D09 WITH (NOLOCK)  On D09.BlockID = D91.BlockID " & vbCrLf
        sSQL &= "WHERE D13.DivisionID=" & SQLString(gsDivisionID) & " AND D13.PayrollVoucherID = " & SQLString(gsPayRollVoucherID) & vbCrLf
        sSQL &= "Union All " & vbCrLf
        sSQL &= "Select '%' As BlockID," & sLanguage & " As BlockName, '%' as DivisionID, 0 AS DisplayOrder " & vbCrLf
        sSQL &= "Order by DisplayOrder,BlockID"

        LoadDataSource(tdbcBlockID, sSQL, gbUnicode)

    End Sub

    Private Sub CreateTableDepartmentID()
        Dim sSQL As String = ""
        'Load tdbcDepartmentID
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        sSQL = "Select distinct D13.DepartmentID as DepartmentID, DepartmentName" & sUnicode & " as DepartmentName,D91.BlockID as BlockID, D13.PayrollVoucherID, D91.DepDisplayOrder, 1 AS DisplayOrder " & vbCrLf
        sSQL &= " From D13T0101 D13  WITH (NOLOCK) Left Join D91T0012 D91 WITH (NOLOCK)  On D13.DepartmentID = D91.DepartmentID " & vbCrLf
        sSQL &= "Where D13.DivisionID=" & SQLString(gsDivisionID) & " And D91.Disabled=0 and D13.PayrollVoucherID = " & SQLString(gsPayRollVoucherID) & vbCrLf
        sSQL &= "Union All " & vbCrLf
        sSQL &= "Select '%' As DepartmentID, " & sLanguage & " As DepartmentName,'%' as BlockID, '%' as PayrollVoucherID, 0 As DepDisplayOrder, 0 AS DisplayOrder " & vbCrLf
        sSQL &= "Order by DisplayOrder, D91.DepDisplayOrder, DepartmentID"
        ' update 19/11/2013 - id 61328 -- Truyền biến toàn cục @PayrollVoucherID khi load Form D13F0000
        'LoadDataSource(tdbcDepartmentID, sSQL, gbUnicode)
        dtDepartmentID = ReturnDataTable(sSQL)

    End Sub

    Private Sub CreateTableTeamID()
        Dim sSQL As String = ""
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        'Load tdbcTeamID
        sSQL = " Select   	    T1.TeamID, T1.TeamName" & sUnicode & " as TeamName,T2.BlockID, T1.DepartmentID, T1.TeamDisplayOrder, 1 AS DisplayOrder " & vbCrLf
        sSQL &= " From  		D09T0227 T1 WITH (NOLOCK) " & vbCrLf
        sSQL &= " Inner join 	D91T0012 T2  WITH (NOLOCK) " & vbCrLf
        sSQL &= " On       	    T2.DepartmentID = T1.DepartmentID" & vbCrLf
        sSQL &= " Where 		T1.Disabled = 0" & " And T2.DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= " Union " & vbCrLf
        sSQL &= " Select  		'%'  TeamID, " & sLanguage & "  TeamName,'%' As BlockID, '%' as DepartmentID, 0 As TeamDisplayOrder, 0 AS DisplayOrder " & vbCrLf
        sSQL &= " Order by      DisplayOrder, T1.TeamDisplayOrder, TeamID"
        dtTeamID = ReturnDataTable(sSQL)
    End Sub

    '    Private Sub LoadtdbcDepartmentID()
    '        'Load tdbcDepartmentID
    '        LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "PayrollVoucherID=" & SQLString(tdbcPayrollVoucherNo.Columns("PayrollVoucherID").Text) & "or DepartmentID='%'"), gbUnicode)
    '    End Sub

    'Private Sub LoadtdbcTeamID()
    '    'Load tdbcTeamID
    '    If ReturnValueC1Combo(tdbcDepartmentID).ToString <> "%" Then
    '        LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, " DepartmentID=" & SQLString(ReturnValueC1Combo(tdbcDepartmentID).ToString) & " or TeamID='%'"), gbUnicode)
    '    Else
    '        LoadDataSource(tdbcTeamID, dtTeamID.Copy, gbUnicode)
    '    End If
    'End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0102
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 14/02/2007 11:38:13
    '# Modified User: Nguyễn Thị Minh Hòa
    '# Modified Date: 18/11/2011 08:55:59
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0102() As String
        Dim sSQL As String = ""
        'REM 27/10/2009 DO LỖI Ở DB KHÁCH HÀNG, SỬA THEO Y/C HOÀI VŨ
        '_AbsentVoucherID = CreateIGE("D13T0102", "AbsentVoucherID", Trim(tdbcVoucherTypeID.Text), giTranYear & giTranMonth, gsStringKey)
        _AbsentVoucherID = CreateIGE("D13T0102", "AbsentVoucherID", "13", "AV", gsStringKey)

        sSQL &= "Insert Into D13T0102("
        sSQL &= "AttMode, DivisionID, AbsentVoucherID, TranMonth, TranYear, VoucherTypeID, "
        sSQL &= "AbsentVoucherNo,BlockID, DepartmentID, TeamID,SalaryObjectID, "
        sSQL &= "EntryDate, DateFrom, DateTo, Remark,RemarkU, CreateUserID, "
        sSQL &= "LastModifyUserID, CreateDate, LastModifyDate, PayrollVoucherID, ProjectID, TransTypeID," & vbCrLf
        sSQL &= "IsCheckDepartment, NCodeTypeID, IsAutoAddEmp, IsAdvancedSal"
        sSQL &= ") Values ("
        'sSQL &= SQLNumber(IIf(optEmployee.Checked, 0, IIf(optTeam.Checked, 1, 2))) & COMMA
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcAttMode)) & COMMA
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID [KEY], varchar[20], NOT NULL
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID [KEY], varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString("") & COMMA 'VoucherTypeID, varchar[20], NULL
        sSQL &= SQLString("") & COMMA 'AbsentVoucherNo, varchar[20], NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[20], NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcSalaryObjectID)) & COMMA 'SalaryObjectID, varchar[20], NULL
        sSQL &= SQLDateSave("") & COMMA 'EntryDate, datetime, NULL
        sSQL &= SQLDateSave(c1dateDateFrom.Value) & COMMA 'DateFrom, datetime, NULL
        sSQL &= SQLDateSave(c1dateDateTo.Value) & COMMA 'DateTo, datetime, NULL
        sSQL &= SQLStringUnicode(txtRemark.Text, gbUnicode, False) & COMMA 'Remark, varchar[50], NULL
        sSQL &= SQLStringUnicode(txtRemark.Text, gbUnicode, True) & COMMA 'Remark, varchar[50], NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= "GetDate()" & COMMA 'LastModifyDate, datetime, NULL
        ' update 19/11/2013 - id 61328 -- Truyền biến toàn cục @PayrollVoucherID khi load Form D13F0000
        sSQL &= SQLString(gsPayRollVoucherID) & COMMA 'tdbcPayrollVoucherNo.Columns("PayrollVoucherID").Text)  'PayrollVoucherID, varchar[20], NULL
        'sSQL &= SQLString(_NewPayrollVoucherID) & COMMA 'tdbcPayrollVoucherNo.Columns("PayrollVoucherID").Text)  'PayrollVoucherID, varchar[20], NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcProjectID)) & COMMA 'ProjectID, varchar[20], NOT NULL
        sSQL &= SQLString(IIf(tdbcTransTypeID.Text = "", "", tdbcTransTypeID.SelectedValue)) & COMMA 'TransTypeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsCheckDepartment.Checked) & COMMA 'IsCheckDepartment, tinyint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcNCodeType).ToString) & COMMA
        sSQL &= SQLNumber(chkIsAutoAddEmp.Checked) & COMMA 'IsAutoAddEmp, tinyint, NOT NULL
        sSQL &= SQLNumber(optIsAdvancedSal1.Checked) 'IsAdvancedSal, tinyint, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0108s
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 18/11/2011 08:56:29
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0108s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsCheck)) = True Then
                sSQL.Append("Insert Into D13T0108(")
                sSQL.Append("DivisionID, DepartmentID, AbsentVoucherID, TranMonth, TranYear ")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[150], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[150], NOT NULL
                sSQL.Append(SQLString(_AbsentVoucherID) & COMMA) 'AbsentVoucherID, varchar[150], NOT NULL
                sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, int, NOT NULL
                sSQL.Append(SQLNumber(giTranYear)) 'TranYear, int, NOT NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0108
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 18/11/2011 09:02:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0108() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0108"
        sSQL &= " Where "
        sSQL &= "AbsentVoucherID = " & SQLString(_AbsentVoucherID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0102
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 14/02/2007 11:38:31
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0102() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T0102 Set "
        '        sSQL &= "VoucherTypeID = " & SQLString(tdbcVoucherTypeID.Text) & COMMA 'varchar[20], NULL
        '        sSQL &= "AbsentVoucherNo = " & SQLString(txtAbsentVoucherNo.Text) & COMMA 'varchar[20], NULL
        '        sSQL &= "EntryDate = " & SQLDateSave(c1dateEntryDate.Value) & COMMA 'datetime, NULL
        sSQL &= "Remark = " & SQLStringUnicode(txtRemark.Text, gbUnicode, False) & COMMA 'varchar[50], NULL
        sSQL &= "RemarkU = " & SQLStringUnicode(txtRemark.Text, gbUnicode, True) & COMMA 'varchar[50], NULL
        sSQL &= "DateFrom = " & SQLDateSave(c1dateDateFrom.Value) & COMMA 'datetime, NULL
        sSQL &= "DateTo = " & SQLDateSave(c1dateDateTo.Value) & COMMA 'datetime, NULL
        sSQL &= "BlockID = " & SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'varchar[20], NULL
        sSQL &= "DepartmentID = " & SQLString(ReturnValueC1Combo(tdbcDepartmentID)) & COMMA 'varchar[20], NULL
        sSQL &= "TeamID = " & SQLString(ReturnValueC1Combo(tdbcTeamID)) & COMMA 'varchar[20], NULL
        sSQL &= "SalaryObjectID = " & SQLString(ReturnValueC1Combo(tdbcSalaryObjectID)) & COMMA 'varchar[20], NULL
        ' update 19/11/2013 - id 61328 -- Truyền biến toàn cục @PayrollVoucherID khi load Form D13F0000
        sSQL &= "PayrollVoucherID = " & SQLString(gsPayRollVoucherID) & COMMA 'tdbcPayrollVoucherNo.Columns("PayrollVoucherID").Text) & COMMA 'varchar[20], NULL
        'sSQL &= "PayrollVoucherID = " & SQLString(_NewPayrollVoucherID) & COMMA 'tdbcPayrollVoucherNo.Columns("PayrollVoucherID").Text) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" & COMMA 'datetime, NULL
        sSQL &= "ProjectID = " & SQLString(ReturnValueC1Combo(tdbcProjectID)) & COMMA 'varchar[20], NOT NULL
        sSQL &= "TransTypeID = " & SQLString(IIf(tdbcTransTypeID.Text = "", "", tdbcTransTypeID.SelectedValue)) & COMMA 'varchar[20], NOT NULL
        sSQL &= "IsCheckDepartment = " & SQLNumber(chkIsCheckDepartment.Checked) & COMMA 'varchar[20], NOT NULL
        sSQL &= "NCodeTypeID   = " & SQLString(ReturnValueC1Combo(tdbcNCodeType).ToString) & COMMA
        sSQL &= "IsAutoAddEmp = " & SQLNumber(chkIsAutoAddEmp.Checked) & COMMA 'varchar[20], NOT NULL ' update 19/7/2013 id 57801
        sSQL &= "IsAdvancedSal = " & SQLNumber(optIsAdvancedSal1.Checked) 'varchar[20], NOT NULL ' update 19/7/2013 id 57801
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "AbsentVoucherID = " & SQLString(_AbsentVoucherID)
        Return sSQL
    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then
            Exit Sub
        End If

        Dim sSQL As String = ""

        btnSave.Enabled = False
        btnClose.Enabled = False

        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL = SQLInsertD13T0102() & vbCrLf
                ' update 19/7/2013 id 
                If chkIsCheckDepartment.Checked Then
                    sSQL &= SQLInsertD13T0108s().ToString & vbCrLf
                End If
                If chkIsAutoAddEmp.Checked AndAlso ReturnValueC1Combo(tdbcAttMode).ToString = "0" Then
                    sSQL &= SQLStoreD13P0113() & vbCrLf
                End If
                'Audit
                sSQL &= SQLStoreD09P6210("TimeSheetRecording", _AbsentVoucherID, "01", "", txtRemark.Text) & vbCrLf

            Case EnumFormState.FormEdit
                sSQL = SQLStoreD09P6200("D13T0102", "AbsentVoucherID", _AbsentVoucherID, 0, "AbsentVoucherID") & vbCrLf
                sSQL &= SQLUpdateD13T0102() & vbCrLf
                sSQL &= SQLDeleteD13T0108() & vbCrLf
                If chkIsCheckDepartment.Checked Then
                    sSQL &= SQLInsertD13T0108s().ToString & vbCrLf
                End If
                If chkIsAutoAddEmp.Checked AndAlso ReturnValueC1Combo(tdbcAttMode).ToString = "0" Then
                    sSQL &= SQLStoreD13P0113() & vbCrLf
                End If
                sSQL &= SQLStoreD09P6200("D13T0102", "AbsentVoucherID", _AbsentVoucherID, 1, "AbsentVoucherID") & vbCrLf
                sSQL &= SQLStoreD09P6210("TimeSheetRecording", _AbsentVoucherID, "02", "", txtRemark.Text) & vbCrLf
        End Select

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            _savedOk = True
            btnCheck.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnClose.Enabled = True
                    btnCheck.Focus()
                    _NewPayrollVoucherID = gsPayRollVoucherID
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
            _OldPayrollVoucherID = _NewPayrollVoucherID
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If

    End Sub

    Private Sub btnCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        ' Update 1/8/2012 incident 50402
        Dim sAttMode As String = ReturnValueC1Combo(tdbcAttMode).ToString
        If sAttMode = "0" Then ' If optEmployee.Checked Then
            Dim f As New D13F2022
            With f
                .AbsentVoucherID = AbsentVoucherID
                .NewPayrollVoucherID = _NewPayrollVoucherID
                ' 21/7/2014 id 67189 
                .OldPayrollVoucherID = gsPayRollVoucherID '  _OldPayrollVoucherID
                .BlockID = ReturnValueC1Combo(tdbcBlockID)
                .DepartmentID = ReturnValueC1Combo(tdbcDepartmentID).ToString
                .TeamID = ReturnValueC1Combo(tdbcTeamID).ToString
                .sSalaryObjectID = ReturnValueC1Combo(tdbcSalaryObjectID)
                '                .AbsentVoucherNo = txtAbsentVoucherNo.Text
                '                .EntryDate = Date.Parse(c1dateEntryDate.Value.ToString)
                .Remark = txtRemark.Text
                .TransTypeID = IIf(tdbcTransTypeID.Text = "", "", tdbcTransTypeID.SelectedValue).ToString
                .FormState = _FormState
                Me.Close()
                .ShowDialog()
                .Dispose()
            End With
        Else
            Dim f As New D13F2027
            With f
                ' Update 1/8/2012 incident 50402 '  .AttMode = ReturnCheckOption.ToString
                .AttMode = sAttMode
                .AbsentVoucherID = AbsentVoucherID
                .NewPayrollVoucherID = _NewPayrollVoucherID
                .OldPayrollVoucherID = _OldPayrollVoucherID
                .BlockID = ReturnValueC1Combo(tdbcBlockID).ToString
                .DepartmentID = ReturnValueC1Combo(tdbcDepartmentID).ToString
                .TeamID = ReturnValueC1Combo(tdbcTeamID).ToString
                .sSalaryObjectID = ReturnValueC1Combo(tdbcSalaryObjectID)
                '                .AbsentVoucherNo = txtAbsentVoucherNo.Text
                '                .EntryDate = Date.Parse(c1dateEntryDate.Value.ToString)
                .Remark = txtRemark.Text
                .TransTypeID = IIf(tdbcTransTypeID.Text = "", "", tdbcTransTypeID.SelectedValue).ToString
                .FormState = _FormState

                Me.Close()
                .ShowDialog()
                .Dispose()
            End With
        End If

    End Sub

    '    Private Function ReturnCheckOption() As Byte
    '        Dim iCheckOption As Byte = 0
    '        If optEmployee.Checked Then
    '            iCheckOption = 0
    '        ElseIf optTeam.Checked Then
    '            iCheckOption = 1
    '        ElseIf optDepartment.Checked Then
    '            iCheckOption = 2
    '            'Update 16/02/2012: Incident 45314 Bổ sung thêm 2 option Nhóm nhân viên và Đơn vị
    '        ElseIf optGroupEmp.Checked Then
    '            iCheckOption = 3
    '        ElseIf optDivision.Checked Then
    '            iCheckOption = 4
    '        End If
    '        Return iCheckOption
    '    End Function


    Private Function IsCheck(ByVal iAttMode As Byte) As Boolean
        Dim sSQL As New StringBuilder(154)
        sSQL.Append("Select     count(*) ")
        If iAttMode = 0 Then ' Theo nhân viên
            sSQL.Append("From       D13T0103  WITH (NOLOCK) ")
        Else 'Update 17/02/2012: Incident 45314'If (iAttMode = 1 OrElse iAttMode = 2) Then ' Theo Tổ nhóm, Phòng ban
            sSQL.Append("From       D13T0104  WITH (NOLOCK) ")
        End If
        sSQL.Append("Where      AbsentVoucherID = " & SQLString(_AbsentVoucherID) & vbCrLf)
        sSQL.Append("           And DivisionID =" & SQLString(gsDivisionID) & vbCrLf)
        sSQL.Append("           And PayrollVoucherID =" & SQLString(gsPayRollVoucherID))
        Dim sRet As String = ReturnScalar(sSQL.ToString)
        If sRet <> "0" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub EnableTdbcTeamID()
        ' Update 1/8/2012 incident 50402
        Dim sAttMode As String = ReturnValueC1Combo(tdbcAttMode).ToString

        Select Case sAttMode
            Case "2"
                tdbcBlockID.Enabled = D13Systems.IsUseBlock
                tdbcDepartmentID.Enabled = True
                chkIsCheckDepartment.Enabled = True
                tdbg.Enabled = True
                tdbcTeamID.SelectedValue = "%"
                tdbcTeamID.Enabled = False
            Case "4"
                tdbcBlockID.Enabled = False
                tdbcDepartmentID.Enabled = False
                tdbcTeamID.Enabled = False
                tdbcBlockID.SelectedValue = "%"
                tdbcDepartmentID.SelectedValue = "%"
                tdbcTeamID.SelectedValue = "%"
                chkIsCheckDepartment.Checked = False
                chkIsCheckDepartment.Enabled = False
                If dtGrid IsNot Nothing Then dtGrid.Clear()
                tdbg.Enabled = False
            Case "5" ' update 10/9/2013 id 58998 - Mờ IsCheckDepartment khi AttMode = 6
                tdbcBlockID.Enabled = D13Systems.IsUseBlock
                tdbcDepartmentID.Enabled = True
                tdbcTeamID.Enabled = True
                tdbg.Enabled = True
                chkIsCheckDepartment.Checked = False
                chkIsCheckDepartment.Enabled = False
                If dtGrid IsNot Nothing Then dtGrid.Clear()
                tdbg.Enabled = False
            Case "6" ' update 10/9/2013 id 58998 - Mờ IsCheckDepartment khi AttMode = 6
                tdbcBlockID.Enabled = D13Systems.IsUseBlock
                tdbcDepartmentID.Enabled = False
                tdbcTeamID.Enabled = False
                tdbcDepartmentID.SelectedValue = "%"
                tdbcTeamID.SelectedValue = "%"
                tdbg.Enabled = True
                chkIsCheckDepartment.Checked = False
                chkIsCheckDepartment.Enabled = False
                If dtGrid IsNot Nothing Then dtGrid.Clear()
                tdbg.Enabled = False
            Case Else
                tdbcBlockID.Enabled = D13Systems.IsUseBlock
                tdbcDepartmentID.Enabled = True
                tdbcTeamID.Enabled = True
                chkIsCheckDepartment.Enabled = True
                tdbg.Enabled = True
        End Select

        '        If sAttMode = "2" Then ' If optDepartment.Checked Then
        '            tdbcDepartmentID.Enabled = True
        '            chkIsCheckDepartment.Enabled = True
        '            tdbg.Enabled = True
        '            tdbcTeamID.Text = "%"
        '            tdbcTeamID.Enabled = False
        '        ElseIf sAttMode = "4" Then ' If optDivision.Checked Then
        '            tdbcDepartmentID.Enabled = False
        '            tdbcTeamID.Enabled = False
        '            tdbcDepartmentID.Text = "%"
        '            tdbcTeamID.Text = "%"
        '            chkIsCheckDepartment.Checked = False
        '            chkIsCheckDepartment.Enabled = False
        '            If dtGrid IsNot Nothing Then dtGrid.Clear()
        '            tdbg.Enabled = False
        '        ElseIf sAttMode = "5" Then
        '            tdbcDepartmentID.Enabled = True
        '            tdbcTeamID.Enabled = True
        '            tdbg.Enabled = True
        '            chkIsCheckDepartment.Checked = False
        '            chkIsCheckDepartment.Enabled = False
        '            If dtGrid IsNot Nothing Then dtGrid.Clear()
        '            tdbg.Enabled = False
        '        ElseIf sAttMode = "6" Then
        '            tdbcDepartmentID.Enabled = True
        '            tdbcTeamID.Enabled = True
        '            tdbg.Enabled = True
        '            chkIsCheckDepartment.Checked = False
        '            chkIsCheckDepartment.Enabled = False
        '            If dtGrid IsNot Nothing Then dtGrid.Clear()
        '            tdbg.Enabled = False
        '        Else
        '            tdbcDepartmentID.Enabled = True
        '            tdbcTeamID.Enabled = True
        '            chkIsCheckDepartment.Enabled = True
        '            tdbg.Enabled = True
        '        End If
    End Sub

    '      ' Update 1/8/2012 incident 50402 (đã bỏ các opt..)
    '    Private Sub optDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        EnableTdbcTeamID()
    '    End Sub
    '
    '    Private Sub optEmployee_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        EnableTdbcTeamID()
    '    End Sub
    '
    '    Private Sub optTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        EnableTdbcTeamID()
    '    End Sub
    '    Private Sub optDivision_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        EnableTdbcTeamID()
    '    End Sub
    '
    '    Private Sub optGroupEmp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        EnableTdbcTeamID()
    '    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0104
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 21/11/2011 01:50:35
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0104(ByVal iMode As Byte) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P0104 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        ' update 19/11/2013 - id 61328 -- Truyền biến toàn cục @PayrollVoucherID khi load Form D13F0000
        sSQL &= SQLString(gsPayRollVoucherID) & COMMA 'PayrollVoucherID, varchar[50], NOT NULL
        '   sSQL &= SQLString(_NewPayrollVoucherID) & COMMA 'PayrollVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID))  'BlockID, varchar[50], NOT NULL
        Return sSQL
    End Function

    Dim dtGridRoot As DataTable
    Dim dtGrid As DataTable
    Private Sub LoadTDBGrid(ByVal bFirst As Boolean)
        'Update 18/11/2011: incident 44428
        'If bFirst Then
        If _FormState = EnumFormState.FormAdd Then
            dtGridRoot = ReturnDataTable(SQLStoreD13P0104(1))
        Else
            dtGridRoot = ReturnDataTable(SQLStoreD13P0104(0))
        End If

        'End If
        dtGrid = dtGridRoot.DefaultView.ToTable
        LoadDataSource(tdbg, dtGrid, gbUnicode)

    End Sub

    ' Update 1/8/2012 incident 50402 
    ' Thay thế cho sự kiện chkIsCheckDepartment_Click
    Private Sub chkIsCheckDepartment_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsCheckDepartment.CheckedChanged
        If chkIsCheckDepartment.Checked Then
            tdbg.Enabled = True
            ReadOnlyControl(tdbcDepartmentID, tdbcTeamID)
            tdbcTeamID.SelectedValue = "%"
            tdbcDepartmentID.SelectedValue = "%"
            'Load dữ liệu cho lưới
            If dtGridRoot Is Nothing OrElse dtGridRoot.Rows.Count < 1 Then
                LoadTDBGrid(True)
            Else
                LoadTDBGrid(False)
            End If
        Else
            tdbg.Enabled = False
            UnReadOnlyControl(True, tdbcDepartmentID, tdbcTeamID)
            'Xóa lưới
            If tdbg.RowCount > 0 Then
                tdbg.Delete(0, tdbg.RowCount)
            End If
        End If
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Dim bSelect As Boolean = False
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then Exit Sub

        If e.ColIndex = COL_IsCheck Then
            L3HeadClick(tdbg, COL_IsCheck, bSelect)
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.S
                    If tdbg.Col = COL_IsCheck Then L3HeadClick(tdbg, COL_IsCheck, bSelect)
            End Select
        End If
    End Sub

    Private Sub tdbcAttMode_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAttMode.SelectedValueChanged
        If ReturnValueC1Combo(tdbcAttMode).ToString = "5" Then
            tdbcNCodeType.Visible = True
            lblNcodeType.Visible = True
        Else
            tdbcNCodeType.SelectedIndex = -1
            tdbcNCodeType.Visible = False
            lblNcodeType.Visible = False
        End If
        EnableTdbcTeamID()
        EnableChkIsAutoAddEmp() ' update 19/7/2013 id 57801
    End Sub

    ' update 19/7/2013 id 57801
    Private Sub EnableChkIsAutoAddEmp()
        Select Case _FormState
            Case EnumFormState.FormAdd
                'AddNew: Sáng nếu @AttMode = 0.
                If ReturnValueC1Combo(tdbcAttMode).ToString = "0" Then
                    chkIsAutoAddEmp.Enabled = True
                Else
                    chkIsAutoAddEmp.Enabled = False
                    chkIsAutoAddEmp.Checked = False
                End If
            Case EnumFormState.FormEdit, EnumFormState.FormView
                'Edit: Sáng nếu @AttMode = 0 và Không tồn tại dữ liệu trong bảng D13T0103
                Dim bResult As Boolean = IsExistKey("D13T0103", "AbsentVoucherID", _AbsentVoucherID)
                If ReturnValueC1Combo(tdbcAttMode).ToString = "0" AndAlso Not bResult Then
                    chkIsAutoAddEmp.Enabled = True
                Else
                    chkIsAutoAddEmp.Enabled = False
                End If
        End Select

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0113
    '# Created User: Hoàng Nhân
    '# Created Date: 19/07/2013 08:39:03
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0113() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tu dong add NV vao phieu dieu chinh thu nhap" & vbCrLf)
        sSQL &= "Exec D13P0113 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_AbsentVoucherID) & COMMA 'AbsentVoucherID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcSalaryObjectID)) 'SalaryObjectID, varchar[50], NOT NULL
        Return sSQL
    End Function

End Class