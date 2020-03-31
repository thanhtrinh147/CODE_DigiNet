'#-------------------------------------------------------------------------------------
'# Created Date: 05/03/2008 3:56:19 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 05/03/2008 3:56:19 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------

Imports System.Text
Imports System

Public Class D13F1161
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim bEnabled As Boolean = False

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            LoadLabelCaptions()

            Select Case _FormState
                Case EnumFormState.FormAdd
                    c1dateEffectiveDateTo.Value = Now.Date
                    c1dateEffectiveDateFrom.Value = Now.Date
                    btnDetail.Enabled = False
                Case EnumFormState.FormEdit
                    bEnabled = True
                    LoadEdit()
                Case EnumFormState.FormView
                    bEnabled = True
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _defaultSalID As String = ""
    Public Property DefaultSalID() As String
        Get
            Return _defaultSalID
        End Get
        Set(ByVal Value As String)
            _defaultSalID = Value
        End Set
    End Property

    Private Sub D13F1161_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FormState = EnumFormState.FormEdit Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If btnSave.Enabled Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        End If
    End Sub

    Private Sub D09F0160_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub

    Private Sub D09F0160_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        _bSaved = False
        SetBackColorObligatory()
        Loadlanguage()
        EnabledControl()
        '****************************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtDefaultSalID, txtDefaultSalID.MaxLength, False)
        '****************************
InputDateCustomFormat(c1dateEffectiveDateFrom,c1dateEffectiveDateTo)

        SetResolutionForm(Me)
    End Sub

    Private Sub SetBackColorObligatory()
        txtDefaultSalID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtDefaultSalName.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateEffectiveDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_thong_so_luong_mac_dinh_-__D13F1161") & UnicodeCaption(gbUnicode) 'CËp nhËt th¤ng sç l§¥ng mÆc ¢Ünh -  D13F1161
        '================================================================ 
        lblCondition.Text = rl3("Co_so_thiet_lap") 'Cơ sở thiết lập
        lblSalaryParameters.Text = rl3("Thong_so_luong") 'Thông số lương
        lblDefaultSalID.Text = rl3("Ma") 'Mã
        lblDefaultSalName.Text = rl3("Ten") 'Tên
        lblteEffectiveDateTo.Text = rl3("Hieu_luc_tu") 'Hiệu lực từ
        lblteEffectiveDateFrom.Text = rl3("Hieu_luc_den") 'Hiệu lực đến
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 
        btnDetail.Text = rl3("_Chi_tiet") '&Chi tiết
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu và Nhập &tiếp
        '================================================================ 
        chkDuty.Text = rl3("Chuc_vu") 'Chức vụ
        chkLevel.Text = rl3("Trinh_do_chuyen_mon_U") 'Trình độ chuyên môn
        chkWorkingStatus.Text = rl3("Trang_thai_lam_viec") 'Trạng thái làm việc
        chkEmployeeType.Text = rl3("Doi_tuong_lao_dong") 'Đối tượng lao động
        chkDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkCheckWork.Text = rl3("Cong_viec") 'Công việc
        chkCheckEducationLevel.Text = rl3("Trinh_do_hoc_van") 'Trình độ học vấn
    End Sub

    Private Sub LoadLabelCaptions()
        Dim sSQL As String = ""
        sSQL = "SELECT Code, Short" & UnicodeJoin(gbUnicode) & " As Short, Disabled " & vbCrLf
        sSQL &= "FROM D13T9000  WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE Type = 'SALCE'  AND RIGHT(Code,2)< 11" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT Code, Short" & UnicodeJoin(gbUnicode) & " As Short, Disabled " & vbCrLf
        sSQL &= "FROM D13T9000  WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE Type = 'SALBA' " & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT 'HSO[BL01]' As Code, " & IIf(gbUnicode = False, "'" & rl3("Ngach_bac_luongV"), "N'" & rl3("Ngach_bac_luong") & Space(1)).ToString & Space(1) & "01' As Short, 0 as Disabled" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT 'HSO[BL02]' As Code, " & IIf(gbUnicode = False, "'" & rl3("Ngach_bac_luongV"), "N'" & rl3("Ngach_bac_luong") & Space(1)).ToString & Space(1) & "02' As Short, 0 as Disabled" & vbCrLf
        sSQL &= "ORDER BY Code" & vbCrLf

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With dt
                chkBaseSalary01.Text = .Rows(0).Item("Short").ToString
                chkBaseSalary01.Font = FontUnicode(gbUnicode)

                chkBaseSalary02.Text = .Rows(1).Item("Short").ToString
                chkBaseSalary02.Font = FontUnicode(gbUnicode)

                chkBaseSalary03.Text = .Rows(2).Item("Short").ToString
                chkBaseSalary03.Font = FontUnicode(gbUnicode)

                chkBaseSalary04.Text = .Rows(3).Item("Short").ToString
                chkBaseSalary04.Font = FontUnicode(gbUnicode)

                chkSalCoefficient01.Text = .Rows(4).Item("Short").ToString
                chkSalCoefficient01.Font = FontUnicode(gbUnicode)

                chkSalCoefficient02.Text = .Rows(5).Item("Short").ToString
                chkSalCoefficient02.Font = FontUnicode(gbUnicode)

                chkSalCoefficient03.Text = .Rows(6).Item("Short").ToString
                chkSalCoefficient03.Font = FontUnicode(gbUnicode)

                chkSalCoefficient04.Text = .Rows(7).Item("Short").ToString
                chkSalCoefficient04.Font = FontUnicode(gbUnicode)

                chkSalCoefficient05.Text = .Rows(8).Item("Short").ToString
                chkSalCoefficient05.Font = FontUnicode(gbUnicode)

                chkSalCoefficient06.Text = .Rows(9).Item("Short").ToString
                chkSalCoefficient06.Font = FontUnicode(gbUnicode)

                chkSalCoefficient07.Text = .Rows(10).Item("Short").ToString
                chkSalCoefficient07.Font = FontUnicode(gbUnicode)

                chkSalCoefficient08.Text = .Rows(11).Item("Short").ToString
                chkSalCoefficient08.Font = FontUnicode(gbUnicode)

                chkSalCoefficient09.Text = .Rows(12).Item("Short").ToString
                chkSalCoefficient09.Font = FontUnicode(gbUnicode)

                chkSalCoefficient10.Text = .Rows(13).Item("Short").ToString
                chkSalCoefficient10.Font = FontUnicode(gbUnicode)

                chkSalary01.Text = .Rows(14).Item("Short").ToString
                chkSalary01.Font = FontUnicode(gbUnicode)

                chkSalary02.Text = .Rows(15).Item("Short").ToString
                chkSalary02.Font = FontUnicode(gbUnicode)

                'chkBaseSalary01.Visible = CBool(IIf(.Rows(0).Item("Disabled").ToString = "1", False, True))
                'chkBaseSalary02.Visible = CBool(IIf(.Rows(1).Item("Disabled").ToString = "1", False, True))
                'chkBaseSalary03.Visible = CBool(IIf(.Rows(2).Item("Disabled").ToString = "1", False, True))
                'chkBaseSalary04.Visible = CBool(IIf(.Rows(3).Item("Disabled").ToString = "1", False, True))
                'chkSalCoefficient01.Visible = CBool(IIf(.Rows(4).Item("Disabled").ToString = "1", False, True))
                'chkSalCoefficient02.Visible = CBool(IIf(.Rows(5).Item("Disabled").ToString = "1", False, True))
                'chkSalCoefficient03.Visible = CBool(IIf(.Rows(6).Item("Disabled").ToString = "1", False, True))
                'chkSalCoefficient04.Visible = CBool(IIf(.Rows(7).Item("Disabled").ToString = "1", False, True))
                'chkSalCoefficient05.Visible = CBool(IIf(.Rows(8).Item("Disabled").ToString = "1", False, True))
                'chkSalCoefficient06.Visible = CBool(IIf(.Rows(9).Item("Disabled").ToString = "1", False, True))
                'chkSalCoefficient07.Visible = CBool(IIf(.Rows(10).Item("Disabled").ToString = "1", False, True))
                'chkSalCoefficient08.Visible = CBool(IIf(.Rows(11).Item("Disabled").ToString = "1", False, True))
                'chkSalCoefficient09.Visible = CBool(IIf(.Rows(12).Item("Disabled").ToString = "1", False, True))
                'chkSalCoefficient10.Visible = CBool(IIf(.Rows(13).Item("Disabled").ToString = "1", False, True))
                'chkSalary01.Visible = CBool(IIf(.Rows(14).Item("Disabled").ToString = "1", False, True))
                'chkSalary02.Visible = CBool(IIf(.Rows(15).Item("Disabled").ToString = "1", False, True))

                chkBaseSalary01.Tag = Not L3Bool(.Rows(0).Item("Disabled"))
                chkBaseSalary02.Tag = Not L3Bool(.Rows(1).Item("Disabled"))
                chkBaseSalary03.Tag = Not L3Bool(.Rows(2).Item("Disabled"))
                chkBaseSalary04.Tag = Not L3Bool(.Rows(3).Item("Disabled"))
                chkSalCoefficient01.Tag = Not L3Bool(.Rows(4).Item("Disabled"))
                chkSalCoefficient02.Tag = Not L3Bool(.Rows(5).Item("Disabled"))
                chkSalCoefficient03.Tag = Not L3Bool(.Rows(6).Item("Disabled"))
                chkSalCoefficient04.Tag = Not L3Bool(.Rows(7).Item("Disabled"))
                chkSalCoefficient05.Tag = Not L3Bool(.Rows(8).Item("Disabled"))
                chkSalCoefficient06.Tag = Not L3Bool(.Rows(9).Item("Disabled"))
                chkSalCoefficient07.Tag = Not L3Bool(.Rows(10).Item("Disabled"))
                chkSalCoefficient08.Tag = Not L3Bool(.Rows(11).Item("Disabled"))
                chkSalCoefficient09.Tag = Not L3Bool(.Rows(12).Item("Disabled"))
                chkSalCoefficient10.Tag = Not L3Bool(.Rows(13).Item("Disabled"))
                chkSalary01.Tag = Not L3Bool(.Rows(14).Item("Disabled"))
                chkSalary02.Tag = Not L3Bool(.Rows(15).Item("Disabled"))
            End With
        End If
    End Sub

    Private Sub LoadEdit()
        Dim sSQL As String = ""

        sSQL = "SELECT D60.DefaultSalID, D60.DefaultSalName" & UnicodeJoin(gbUnicode) & " As DefaultSalName, D60.EffectiveDateTo, D60.EffectiveDateFrom, " & vbCrLf
        sSQL &= "D60.Note" & UnicodeJoin(gbUnicode) & " As Note, D60.ChkDepartment, D60.ChkDuty, D60.ChkLevel, D60.ChkEmployeeType, D60. ChkWorkingStatus, " & vbCrLf
        sSQL &= "D60.ChkSalary01, D60.ChkSalary02, D60.ChkBaseSalary01, D60.ChkBaseSalary02, D60.ChkBaseSalary03, D60.ChkBaseSalary04, D60.ChkSalCoefficient01, D60.ChkSalCoefficient02, " & vbCrLf
        sSQL &= "D60.ChkSalCoefficient03, D60.ChkSalCoefficient04, D60.ChkSalCoefficient05, D60.ChkSalCoefficient06, D60.ChkSalCoefficient07, " & vbCrLf
        sSQL &= "D60.ChkSalCoefficient08, D60.ChkSalCoefficient09, D60.ChkSalCoefficient10, D60.DivisionID, D60.Disabled , D60.ChkWork, D60.ChkEducationLevel" & vbCrLf
        sSQL &= "FROM D09T0160 D60 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE D60.DefaultSalID = " & SQLString(_defaultSalID)

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                txtDefaultSalID.Text = .Item("DefaultSalID").ToString
                txtDefaultSalName.Text = .Item("DefaultSalName").ToString
                c1dateEffectiveDateFrom.Value = SQLDateShow(.Item("EffectiveDateFrom").ToString)
                c1dateEffectiveDateTo.Value = SQLDateShow(.Item("EffectiveDateTo").ToString)
                txtNote.Text = .Item("Note").ToString
                chkDisabled.Checked = L3Bool(.Item("Disabled"))

                chkDepartmentID.Checked = L3Bool(.Item("ChkDepartment"))
                chkDuty.Checked = L3Bool(.Item("ChkDuty"))
                chkLevel.Checked = L3Bool(.Item("ChkLevel"))
                chkEmployeeType.Checked = L3Bool(.Item("ChkEmployeeType"))
                chkWorkingStatus.Checked = L3Bool(.Item("ChkWorkingStatus"))
                chkCheckWork.Checked = L3Bool(.Item("ChkWork"))
                chkCheckEducationLevel.Checked = L3Bool(.Item("ChkEducationLevel"))

                chkSalary01.Checked = L3Bool(.Item("ChkSalary01")) And L3Bool(chkSalary01.Tag)
                chkSalary02.Checked = L3Bool(.Item("ChkSalary02")) And L3Bool(chkSalary02.Tag)
                chkBaseSalary01.Checked = L3Bool(.Item("ChkBaseSalary01")) And L3Bool(chkBaseSalary01.Tag)
                chkBaseSalary02.Checked = L3Bool(.Item("ChkBaseSalary02")) And L3Bool(chkBaseSalary02.Tag)
                chkBaseSalary03.Checked = L3Bool(.Item("ChkBaseSalary03")) And L3Bool(chkBaseSalary03.Tag)
                chkBaseSalary04.Checked = L3Bool(.Item("ChkBaseSalary04")) And L3Bool(chkBaseSalary04.Tag)
                chkSalCoefficient01.Checked = L3Bool(.Item("ChkSalCoefficient01")) And L3Bool(chkSalCoefficient01.Tag)
                chkSalCoefficient02.Checked = L3Bool(.Item("ChkSalCoefficient02")) And L3Bool(chkSalCoefficient02.Tag)
                chkSalCoefficient03.Checked = L3Bool(.Item("ChkSalCoefficient03")) And L3Bool(chkSalCoefficient03.Tag)
                chkSalCoefficient04.Checked = L3Bool(.Item("ChkSalCoefficient04")) And L3Bool(chkSalCoefficient04.Tag)
                chkSalCoefficient05.Checked = L3Bool(.Item("ChkSalCoefficient05")) And L3Bool(chkSalCoefficient05.Tag)
                chkSalCoefficient06.Checked = L3Bool(.Item("ChkSalCoefficient06")) And L3Bool(chkSalCoefficient06.Tag)
                chkSalCoefficient07.Checked = L3Bool(.Item("ChkSalCoefficient07")) And L3Bool(chkSalCoefficient07.Tag)
                chkSalCoefficient08.Checked = L3Bool(.Item("ChkSalCoefficient08")) And L3Bool(chkSalCoefficient08.Tag)
                chkSalCoefficient09.Checked = L3Bool(.Item("ChkSalCoefficient09")) And L3Bool(chkSalCoefficient09.Tag)
                chkSalCoefficient10.Checked = L3Bool(.Item("ChkSalCoefficient10")) And L3Bool(chkSalCoefficient10.Tag)
            End With
        End If

        '***************************************
        btnNext.Visible = False
        btnSave.Left = btnNext.Right - btnSave.Width

        ReadOnlyControl(txtDefaultSalID)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If btnNext.Text = rl3("Luu_va_Nhap__tiep") Then btnSave_Click(Nothing, Nothing)

        If _bSaved = False Then Exit Sub 'luu k thanh cong

        btnSave.Enabled = True
        btnNext.Text = rl3("Luu_va_Nhap__tiep")
        '********************************
        txtDefaultSalID.Text = ""
        txtDefaultSalName.Text = ""
        chkDisabled.Checked = False
        txtNote.Text = ""
        c1dateEffectiveDateTo.Value = Now.Date
        c1dateEffectiveDateFrom.Value = Now.Date

        chkDepartmentID.Checked = False
        chkDuty.Checked = False
        chkLevel.Checked = False
        chkEmployeeType.Checked = False
        chkWorkingStatus.Checked = False
        chkCheckWork.Checked = False
        chkCheckEducationLevel.Checked = False

        chkSalary01.Checked = False
        chkSalary02.Checked = False
        chkBaseSalary01.Checked = False
        chkBaseSalary02.Checked = False
        chkBaseSalary03.Checked = False
        chkBaseSalary04.Checked = False
        chkSalCoefficient01.Checked = False
        chkSalCoefficient02.Checked = False
        chkSalCoefficient03.Checked = False
        chkSalCoefficient04.Checked = False
        chkSalCoefficient05.Checked = False
        chkSalCoefficient06.Checked = False
        chkSalCoefficient07.Checked = False
        chkSalCoefficient08.Checked = False
        chkSalCoefficient09.Checked = False
        chkSalCoefficient10.Checked = False

        btnDetail.Enabled = False
        EnabledControl()
        '********************************
        txtDefaultSalID.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        If AllowSave() = False Then Exit Sub

        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD09T0160.ToString & vbCrLf)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD09T0160.ToString & vbCrLf)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            bEnabled = True
            btnClose.Enabled = True

            _defaultSalID = txtDefaultSalID.Text
            btnDetail.Enabled = True

            Select Case _FormState
                Case EnumFormState.FormAdd
                    If sender IsNot Nothing Then btnNext.Text = rl3("_Nhap_tiep")
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
        If txtDefaultSalID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtDefaultSalID.Focus()
            Return False
        End If

        If txtDefaultSalName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten"))
            txtDefaultSalName.Focus()
            Return False
        End If

        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D09T0160", "DefaultSalID", txtDefaultSalID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtDefaultSalID.Focus()
                Return False
            End If
        End If

        If c1dateEffectiveDateFrom.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Hieu_luc_tu"))
            c1dateEffectiveDateFrom.Focus()
            Return False
        End If

        If c1dateEffectiveDateFrom.Value.ToString <> "" And c1dateEffectiveDateTo.Value.ToString <> "" Then
            If CDate(c1dateEffectiveDateFrom.Value) > CDate(c1dateEffectiveDateTo.Value) Then
                D99C0008.MsgL3(rl3("Ngay") & " " & rl3("Hieu_luc_tu") & " " & rl3("phai_nho_hon") & " " & rl3("Hieu_luc_den"))
                c1dateEffectiveDateTo.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Dim f As New D13F1162
        With f
            .DefaultSalID = txtDefaultSalID.Text
            .DefaultSalName = txtDefaultSalName.Text
            .EffectiveDateFrom = c1dateEffectiveDateFrom.Value.ToString
            .EffectiveDateTo = c1dateEffectiveDateTo.Value.ToString
            .FormState = _FormState
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub EnabledControl()
        If chkDepartmentID.Checked OrElse chkDuty.Checked OrElse chkLevel.Checked OrElse chkEmployeeType.Checked OrElse chkWorkingStatus.Checked OrElse chkCheckWork.Checked OrElse chkCheckEducationLevel.Checked Then
            chkSalary01.Enabled = True And L3Bool(chkSalary01.Tag)
            chkSalary02.Enabled = True And L3Bool(chkSalary02.Tag)
            chkBaseSalary01.Enabled = True And L3Bool(chkBaseSalary01.Tag)
            chkBaseSalary02.Enabled = True And L3Bool(chkBaseSalary02.Tag)
            chkBaseSalary03.Enabled = True And L3Bool(chkBaseSalary03.Tag)
            chkBaseSalary04.Enabled = True And L3Bool(chkBaseSalary04.Tag)
            chkSalCoefficient01.Enabled = True And L3Bool(chkSalCoefficient01.Tag)
            chkSalCoefficient02.Enabled = True And L3Bool(chkSalCoefficient02.Tag)
            chkSalCoefficient03.Enabled = True And L3Bool(chkSalCoefficient03.Tag)
            chkSalCoefficient04.Enabled = True And L3Bool(chkSalCoefficient04.Tag)
            chkSalCoefficient05.Enabled = True And L3Bool(chkSalCoefficient05.Tag)
            chkSalCoefficient06.Enabled = True And L3Bool(chkSalCoefficient06.Tag)
            chkSalCoefficient07.Enabled = True And L3Bool(chkSalCoefficient07.Tag)
            chkSalCoefficient08.Enabled = True And L3Bool(chkSalCoefficient08.Tag)
            chkSalCoefficient09.Enabled = True And L3Bool(chkSalCoefficient09.Tag)
            chkSalCoefficient10.Enabled = True And L3Bool(chkSalCoefficient10.Tag)

            If _FormState <> EnumFormState.FormAdd Then
                bEnabled = True
            End If

            If _FormState <> EnumFormState.FormView Then
                btnSave.Enabled = True
                btnNext.Enabled = True
            End If

            btnDetail.Enabled = bEnabled
        ElseIf chkDepartmentID.Checked = False AndAlso chkDuty.Checked = False AndAlso chkLevel.Checked = False AndAlso chkEmployeeType.Checked = False AndAlso chkWorkingStatus.Checked = False AndAlso chkCheckWork.Checked = False AndAlso chkCheckEducationLevel.Checked = False Then
            chkSalary01.Enabled = False
            chkSalary02.Enabled = False
            chkBaseSalary01.Enabled = False
            chkBaseSalary02.Enabled = False
            chkBaseSalary03.Enabled = False
            chkBaseSalary04.Enabled = False
            chkSalCoefficient01.Enabled = False
            chkSalCoefficient02.Enabled = False
            chkSalCoefficient03.Enabled = False
            chkSalCoefficient04.Enabled = False
            chkSalCoefficient05.Enabled = False
            chkSalCoefficient06.Enabled = False
            chkSalCoefficient07.Enabled = False
            chkSalCoefficient08.Enabled = False
            chkSalCoefficient09.Enabled = False
            chkSalCoefficient10.Enabled = False

            btnSave.Enabled = False
            btnNext.Enabled = False
            btnDetail.Enabled = False
            bEnabled = False
        End If

        EnabledCheckbox()
    End Sub

    Private Sub EnabledCheckbox()
        Dim chkbox As System.Windows.Forms.CheckBox
        Dim i As Integer
        With grpx
            For i = 1 To 2
                chkbox = CType(.Controls("chkSalary0" & i), System.Windows.Forms.CheckBox)
                If chkbox.Checked Then
                    btnDetail.Enabled = True And bEnabled
                    Exit Sub
                End If
            Next

            For i = 1 To 4
                chkbox = CType(.Controls("chkBaseSalary0" & i), System.Windows.Forms.CheckBox)
                If chkbox.Checked Then
                    btnDetail.Enabled = True And bEnabled
                    Exit Sub
                End If
            Next

            For i = 1 To 10
                chkbox = CType(.Controls("chkSalCoefficient" & Format(i, "00").ToString), System.Windows.Forms.CheckBox)
                If chkbox.Checked Then
                    btnDetail.Enabled = True And bEnabled
                    Exit Sub
                End If
            Next
        End With

        btnDetail.Enabled = False
    End Sub

    Private Sub chkDuty_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDuty.Click, chkLevel.Click, chkDepartmentID.Click, chkEmployeeType.Click, chkWorkingStatus.Click, chkCheckWork.Click, chkCheckEducationLevel.Click
        EnabledControl()
    End Sub

    Private Sub chkSalary01_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSalary01.CheckedChanged, chkSalary02.CheckedChanged, chkBaseSalary01.CheckedChanged, chkBaseSalary02.CheckedChanged, chkBaseSalary03.CheckedChanged, chkBaseSalary04.CheckedChanged, chkSalCoefficient01.CheckedChanged, chkSalCoefficient02.CheckedChanged, chkSalCoefficient03.CheckedChanged, chkSalCoefficient04.CheckedChanged, chkSalCoefficient05.CheckedChanged, chkSalCoefficient06.CheckedChanged, chkSalCoefficient07.CheckedChanged, chkSalCoefficient08.CheckedChanged, chkSalCoefficient09.CheckedChanged, chkSalCoefficient10.CheckedChanged
        EnabledCheckbox()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T0160
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/11/2010 11:40:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T0160() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D09T0160(")
        sSQL.Append("ChkDuty, ChkLevel, ChkSalary01, ChkSalary02, ChkBaseSalary01, ")
        sSQL.Append("ChkBaseSalary02, ChkBaseSalary03, ChkBaseSalary04, ChkSalCoefficient01, ChkSalCoefficient02, ")
        sSQL.Append("ChkSalCoefficient03, ChkSalCoefficient04, ChkSalCoefficient05, ChkSalCoefficient06, ChkSalCoefficient07, ")
        sSQL.Append("ChkSalCoefficient08, ChkSalCoefficient09, ChkSalCoefficient10, ChkDepartment, DefaultSalID, ")
        sSQL.Append("DefaultSalName, DefaultSalNameU, DivisionID, Disabled, EffectiveDateTo, ")
        sSQL.Append("EffectiveDateFrom, Note, NoteU, ChkEmployeeType, ChkWorkingStatus, ChkWork, ChkEducationLevel, ")
        sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLNumber(chkDuty.Checked) & COMMA) 'ChkDuty, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkLevel.Checked) & COMMA) 'ChkLevel, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalary01.Enabled, chkSalary01.Checked, 0)) & COMMA) 'ChkSalary01, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalary02.Enabled, chkSalary02.Checked, 0)) & COMMA) 'ChkSalary02, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkBaseSalary01.Enabled, chkBaseSalary01.Checked, 0)) & COMMA) 'ChkBaseSalary01, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkBaseSalary02.Enabled, chkBaseSalary02.Checked, 0)) & COMMA) 'ChkBaseSalary02, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkBaseSalary03.Enabled, chkBaseSalary03.Checked, 0)) & COMMA) 'ChkBaseSalary03, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkBaseSalary04.Enabled, chkBaseSalary04.Checked, 0)) & COMMA) 'ChkBaseSalary04, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalCoefficient01.Enabled, chkSalCoefficient01.Checked, 0)) & COMMA) 'ChkSalCoefficient01, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalCoefficient02.Enabled, chkSalCoefficient02.Checked, 0)) & COMMA) 'ChkSalCoefficient02, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalCoefficient03.Enabled, chkSalCoefficient03.Checked, 0)) & COMMA) 'ChkSalCoefficient03, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalCoefficient04.Enabled, chkSalCoefficient04.Checked, 0)) & COMMA) 'ChkSalCoefficient04, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalCoefficient05.Enabled, chkSalCoefficient05.Checked, 0)) & COMMA) 'ChkSalCoefficient05, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalCoefficient06.Enabled, chkSalCoefficient06.Checked, 0)) & COMMA) 'ChkSalCoefficient06, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalCoefficient07.Enabled, chkSalCoefficient07.Checked, 0)) & COMMA) 'ChkSalCoefficient07, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalCoefficient08.Enabled, chkSalCoefficient08.Checked, 0)) & COMMA) 'ChkSalCoefficient08, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalCoefficient09.Enabled, chkSalCoefficient09.Checked, 0)) & COMMA) 'ChkSalCoefficient09, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(chkSalCoefficient10.Enabled, chkSalCoefficient10.Checked, 0)) & COMMA) 'ChkSalCoefficient10, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkDepartmentID.Checked) & COMMA) 'ChkDepartment, tinyint, NOT NULL
        sSQL.Append(SQLString(txtDefaultSalID.Text) & COMMA) 'DefaultSalID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtDefaultSalName, False) & COMMA) 'DefaultSalName, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtDefaultSalName, True) & COMMA) 'DefaultSalNameU, nvarchar, NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, bit, NOT NULL
        sSQL.Append(SQLDateSave(c1dateEffectiveDateTo.Text) & COMMA) 'EffectiveDateTo, datetime, NOT NULL
        sSQL.Append(SQLDateSave(c1dateEffectiveDateFrom.Text) & COMMA) 'EffectiveDateFrom, datetime, NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote, False) & COMMA) 'Note, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote, True) & COMMA) 'NoteU, nvarchar, NOT NULL
        sSQL.Append(SQLNumber(chkEmployeeType.Checked) & COMMA) 'ChkEmployeeType, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkWorkingStatus.Checked) & COMMA) 'ChkWorkingStatus, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkCheckWork.Checked) & COMMA) 'heckWork, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkCheckEducationLevel.Checked) & COMMA) 'CheckEducationLevel, tinyint, NOT NULL

        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD09T0160
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/11/2010 11:41:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD09T0160() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D09T0160 Set ")
        sSQL.Append("ChkDuty = " & SQLNumber(chkDuty.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkLevel = " & SQLNumber(chkLevel.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalary01 = " & SQLNumber(IIf(chkSalary01.Enabled, chkSalary01.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalary02 = " & SQLNumber(IIf(chkSalary02.Enabled, chkSalary02.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkBaseSalary01 = " & SQLNumber(IIf(chkBaseSalary01.Enabled, chkBaseSalary01.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkBaseSalary02 = " & SQLNumber(IIf(chkBaseSalary02.Enabled, chkBaseSalary02.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkBaseSalary03 = " & SQLNumber(IIf(chkBaseSalary03.Enabled, chkBaseSalary03.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkBaseSalary04 = " & SQLNumber(IIf(chkBaseSalary04.Enabled, chkBaseSalary04.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalCoefficient01 = " & SQLNumber(IIf(chkSalCoefficient01.Enabled, chkSalCoefficient01.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalCoefficient02 = " & SQLNumber(IIf(chkSalCoefficient02.Enabled, chkSalCoefficient02.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalCoefficient03 = " & SQLNumber(IIf(chkSalCoefficient03.Enabled, chkSalCoefficient03.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalCoefficient04 = " & SQLNumber(IIf(chkSalCoefficient04.Enabled, chkSalCoefficient04.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalCoefficient05 = " & SQLNumber(IIf(chkSalCoefficient05.Enabled, chkSalCoefficient05.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalCoefficient06 = " & SQLNumber(IIf(chkSalCoefficient06.Enabled, chkSalCoefficient06.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalCoefficient07 = " & SQLNumber(IIf(chkSalCoefficient07.Enabled, chkSalCoefficient07.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalCoefficient08 = " & SQLNumber(IIf(chkSalCoefficient08.Enabled, chkSalCoefficient08.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalCoefficient09 = " & SQLNumber(IIf(chkSalCoefficient09.Enabled, chkSalCoefficient09.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkSalCoefficient10 = " & SQLNumber(IIf(chkSalCoefficient10.Enabled, chkSalCoefficient10.Checked, 0)) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkDepartment = " & SQLNumber(chkDepartmentID.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("DefaultSalName = " & SQLStringUnicode(txtDefaultSalName, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("DefaultSalNameU = " & SQLStringUnicode(txtDefaultSalName, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'bit, NOT NULL
        sSQL.Append("EffectiveDateTo = " & SQLDateSave(c1dateEffectiveDateTo.Text) & COMMA) 'datetime, NOT NULL
        sSQL.Append("EffectiveDateFrom = " & SQLDateSave(c1dateEffectiveDateFrom.Text) & COMMA) 'datetime, NOT NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("ChkEmployeeType = " & SQLNumber(chkEmployeeType.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkWorkingStatus = " & SQLNumber(chkWorkingStatus.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkWork = " & SQLNumber(chkCheckWork.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("ChkEducationLevel = " & SQLNumber(chkCheckEducationLevel.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NOT NULL
        sSQL.Append(" Where DefaultSalID=" & SQLString(_defaultSalID))
        Return sSQL
    End Function

End Class