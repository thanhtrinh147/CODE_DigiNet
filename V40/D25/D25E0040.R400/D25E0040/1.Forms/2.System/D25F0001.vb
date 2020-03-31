Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 25/07/2006 1:35:52 PM
'# Created User: Lê Văn Phước
'# Modify Date: 25/07/2006 1:35:52 PM
'# Modify User: Lê Văn Phước
'#-------------------------------------------------------------------------------------
Public Class D25F0001

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private Sub LoadPeriodNumberAndDefaultPeriod()
        Dim sSQL As String = "Select PeriodNumber From D91T0025 WITH(NOLOCK)"
        txtPeriodNumber.Text = ReturnScalar(sSQL)

        sSQL = "Select Top 1 Replace(Str(TranMonth, 2), ' ', '0') + '/' + LTrim(Str(TranYear)) As DefaultPeriod From D09T9999 D09 WITH(NOLOCK) Where D09.DivisionID = " & SQLString(tdbcDivisionID.SelectedValue) & " Order By (TranYear * 100 + TranMonth) Desc"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            txtDefaultPeriod.Text = dt.Rows(0).Item("DefaultPeriod").ToString
           
        End If
        dt.Dispose()
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

    Private Sub tdbcDivisionID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcDivisionID.Text = ""
            txtDivisionName.Text = ""
        End If
    End Sub

#End Region

    Private bFormClosed As Boolean = False

    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
        End Set
    End Property

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDivisionID
        LoadCboDivisionID(tdbcDivisionID, "D09", True, gbUnicode)

        sSQL = "Select InterviewerID As InterviewerDefault, InterviewerName" & UnicodeJoin(gbUnicode) & " As RecsourceName From D25T1070  WITH(NOLOCK) Where Disabled = 0 Order by InterviewerID"
        LoadDataSource(tdbcInterviewerDefault, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcInterviewerDefault with txtInterviewerDefaultName"

    Private Sub tdbcInterviewerDefault_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcInterviewerDefault.Close
        If tdbcInterviewerDefault.FindStringExact(tdbcInterviewerDefault.Text) = -1 Then
            tdbcInterviewerDefault.Text = ""

        End If
    End Sub

    Private Sub tdbcInterviewerDefault_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcInterviewerDefault.SelectedValueChanged
        txtRecSourceName.Text = tdbcInterviewerDefault.Columns("RecsourceName").Value.ToString

    End Sub

    Private Sub tdbcInterviewerDefault_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcInterviewerDefault.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcInterviewerDefault.Text = ""
            txtRecSourceName.Text = ""
        End If
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        bFormClosed = True
        If _FormState = EnumFormState.FormAdd Then End
        Me.Close()
    End Sub

    Private Sub D25F0001_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If _FormState = EnumFormState.FormAdd And Not bFormClosed Then End
        Me.Close()
    End Sub

    Private Sub D25F0001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
        If e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tabSystem.SelectedTab = TabPageMainInfo
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            tabSystem.SelectedTab = tagPageAuto
        End If
    End Sub

    Private Sub D25F0001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loadlanguage()
        LoadTDBCombo()
        LoadPeriodNumberAndDefaultPeriod()
        LoadEdit()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        InputbyUnicode(Me, gbUnicode)
        btnSave.Enabled = ReturnPermission("D25F0001") > EnumPermission.View
    SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Thiet_lap_he_thong_-_D25F0001") & UnicodeCaption(gbUnicode) 'ThiÕt lËp hÖ thçng - D25F0001
        '================================================================ 
        lblDefaultPeriod.Text = rl3("Ky_ke_toan_mac_dinh") 'Kỳ kế toán mặc định
        lblNumberPeriod.Text = rl3("So_ky_ke_toan") 'Số kỳ kế toán
        lblIntPlaceDefault.Text = rl3("Noi_phong_van") 'Nơi phỏng vấn
        lblInterviewerDefault.Text = rl3("Nguoi_phong_van") 'Người phỏng vấn
        lblCandidateOutputLength.Text = rl3("Do_dai_ma") 'Độ dài mã
        chkSeparator.Text = rl3("Dau_phan_cach") 'Dấu phân cách
        lblCandidateOutputOrder.Text = rl3("Dang_hien_thi") 'Dạng hiển thị
        lblDefaultDivision.Text = rl3("Don_vi_mac_dinh")
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkIsUseAppRecruitProposal.Text = rL3("Duyet_nhieu_cap_de_xuat_tuyen_dung") ' rL3("Duyet_nhieu_cap_de_xuat_tuyen_dung") 'Duyệt nhiều cấp đề xuất tuyển dụng
        'chkDivisionLocked.Text = rl3("Khoa_don_vi") 'Khóa đơn vị
        chkCandidateS5Type.Text = rl3("Sau_phan_tu_dong") 'Sau phần tự động
        chkCandidateS4Type.Text = rl3("Truoc_phan_tu_dong") 'Trước phần tự động
        chkSupply.Text = rl3("Phan_bo_sung") 'Phần bổ sung
        chkAuto.Text = rl3("Phan_tu_dong") 'Phần tự động
        chkCandidateS3Type.Text = rl3("Phan_loai_khac") 'Phân loại khác
        chkCandidateS2Type.Text = rl3("Theo_ten") 'Theo tên
        chkCandidateS1Type.Text = rl3("Theo_ho") 'Theo họ
        chkAutoCandidateID.Text = rl3("Ma_ung_vien") 'Mã ứng viên        'IncidentID	51129
        'chkAutoRecInformationID.Text = rl3("Ma_thong_bao_tuyen_dung")  'Mã thông báo tuyển dụng 
        'chkAutoInterviewFileID.Text = rl3("Ma_lich_phong_van")
        '================================================================ 
        TabPageMainInfo.Text = "1." & rl3("Thong_tin_chinh") '1. Thông tin chính
        tagPageAuto.Text = "2." & rl3("Thiet_lap_ma_tu_dong") 'Thiết lập mã tự động
        '================================================================ 
        tdbcInterviewerDefault.Columns("InterviewerDefault").Caption = rl3("Ma") 'Mã
        tdbcInterviewerDefault.Columns("RecsourceName").Caption = rl3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma_don_vi") 'Mã đơn vị
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten_don_vi") 'Tên đơn vị
        '================================================================ 
        lbl1.Text = rL3("So_luong_thuc_tuyen") 'Số lượng thực tuyển
        '================================================================ 
        optRecruimentActualQTYMode1.Text = rL3("NV_da_thuc_hien_tang_lao_dong") 'NV đã thực hiện tăng lao động
        optRecruimentActualQTYMode0.Text = rL3("NV_da_lap_quyet_dinh_tuyen_dung_co_trang_thai_nhan_tiec") 'NV đã lập quyết định tuyển dụng có trạng thái nhận tiệc

    End Sub


    Private Sub LoadEdit()
        tdbcDivisionID.SelectedValue = D25Systems.DefaultDivisionID
        tdbcDivisionID.Tag = D25Systems.DefaultDivisionID

        tdbcInterviewerDefault.Text = D25Systems.InterviewerDefault
        txtIntPlaceDefault.Text = D25Systems.IntPlaceDefault
        chkAutoCandidateID.Checked = D25Systems.AutoCandidateID

        'chkAutoRecInformationID.Checked = D25Systems.AutoRecInformationID      'IncidentID	51129

        chkAutoCandidateID_CheckedChanged(Nothing, Nothing)

        chkAuto.Checked = D25Systems.AbsentTypeAuto

        If chkAutoCandidateID.Checked Then chkAuto_CheckedChanged(Nothing, Nothing)

        'chkCandidateS1Type.Checked = D25Systems.CandidateS1Type
        'chkCandidateS2Type.Checked = D25Systems.CandidateS2Type
        'chkCandidateS3Type.Checked = D25Systems.CandidateS3Type
        cboCandidateOutputOrder.SelectedIndex = D25Systems.CandidateOutputOrder
        If D25Systems.CandidateSeparator = "" Then
            chkSeparator.Checked = False
        Else
            chkSeparator.Checked = True
            cboCandidateSeparator.Text = D25Systems.CandidateSeparator
        End If
        'chkAutoInterviewFileID.Checked = D25Systems.AutoInterviewFileID
        'c1NumCandudateOutputLength.Value = D25Systems.CandidateOutputLength
        'chkSupply.Checked = D25Systems.SubsidizeAuto

        If chkAutoCandidateID.Checked And chkAuto.Checked Then chkSupply_CheckedChanged(Nothing, Nothing)

        'chkCandidateS4Type.Checked = D25Systems.CandidateS4Type
        'chkCandidateS5Type.Checked = D25Systems.CandidateS5Type
        chkIsUseAppRecruitProposal.Checked = D25Systems.IsUseAppRecruitProposal

        'id: 72228 10/02/2015
        Dim sSQL As String = ""
        sSQL = " SELECT RecruimentActualQTYMode FROM D25T0000 WITH(NOLOCK)"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
 
            optRecruimentActualQTYMode1.Checked = Number(dt.Rows(0).Item("RecruimentActualQTYMode")) > 0
            optRecruimentActualQTYMode0.Checked = Not optRecruimentActualQTYMode1.Checked

        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim sSQL As String = ""

        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        ' Neu chua co du lieu thi AddNew, neu da co du lieu thi luu Edit
        Dim Dt As DataTable
        sSQL = "Select 1 From D25T0000 WITH(NOLOCK) "
        Dt = ReturnDataTable(sSQL)
        If Dt.Rows.Count = 0 Then
            _FormState = EnumFormState.FormAdd
        Else
            _FormState = EnumFormState.FormEdit
        End If

        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL = SQLInsertD25T0000().ToString
            Case EnumFormState.FormEdit
                sSQL = SQLUpdateD25T0000().ToString
        End Select
        sSQL &= vbCrLf & SQLUpdateD09T0009().ToString
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            UpadateSystems()
            _bSaved = True
            If _FormState = EnumFormState.FormEdit Then
                If tdbcDivisionID.Tag.ToString <> tdbcDivisionID.SelectedValue.ToString Then
                    D99C0008.MsgSetUpDivision()
                Else
                    SaveOK()
                End If
            Else
                SaveOK()
            End If
            bFormClosed = True
        Else
            SaveNotOK()
        End If
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcDivisionID.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub UpadateSystems()
        With D25Systems
            .DefaultDivisionID = tdbcDivisionID.Text
            .InterviewerDefault = tdbcInterviewerDefault.Text
            .IntPlaceDefault = txtIntPlaceDefault.Text

            .AutoCandidateID = chkAutoCandidateID.Checked
            '.AutoRecInformationID = chkAutoRecInformationID.Checked

            .AbsentTypeAuto = chkAuto.Checked
            '.AutoInterviewFileID = chkAutoInterviewFileID.Checked
            '.SubsidizeAuto = chkSupply.Checked
            '.CandidateS1Type = chkCandidateS1Type.Checked
            '.CandidateS2Type = chkCandidateS2Type.Checked
            '.CandidateS3Type = chkCandidateS3Type.Checked
            .CandidateOutputOrder = cboCandidateOutputOrder.SelectedIndex
            .CandidateSeparator = IIf(chkSeparator.Checked, cboCandidateSeparator.Text, "").ToString
            '.CandidateOutputLength = CInt(c1NumCandudateOutputLength.Value)
            '.CandidateS4Type = chkCandidateS4Type.Checked
            '.CandidateS5Type = chkCandidateS5Type.Checked
            .IsUseAppRecruitProposal = chkIsUseAppRecruitProposal.Checked
        End With
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T0000
    '# Created User: Lê Thị Lành
    '# Created Date: 02/10/2007 08:18:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu xuống bảng D25T0000
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T0000() As StringBuilder
        Dim sSQL As New StringBuilder
        '        sSQL.Append("Insert Into D25T0000(")
        '        sSQL.Append("DivisionID, InterviewerDefault, IntPlaceDefault, IntPlaceDefaultU, AutoCandidateID, ")
        '        sSQL.Append("CandidateS1Type,  CandidateS2Type,  CandidateS3Type, ") 'CandidateS1,CandidateS2,CandidateS3,
        '        sSQL.Append("CandidatetOutputOrder, CandidateOutputLength, CandidateSeparator, CandidateS4Type, ")
        '        sSQL.Append("CandidateS5Type,SubsidizeAuto,AbsentTypeAuto")
        '        sSQL.Append(") Values(")

        'IncidentID	50850  theo tài liệu PSAP tab mã số tự động chỉ giử lại check thiết lập mã ứng viên tự động
        sSQL.Append("Insert Into D25T0000(")
        sSQL.Append("DivisionID, InterviewerDefault, IntPlaceDefault, IntPlaceDefaultU, AutoCandidateID") ',AutoInterviewFileID, AutoRecInformationID
        '        sSQL.Append("CandidateS1Type,  CandidateS2Type,  CandidateS3Type, ") 'CandidateS1,CandidateS2,CandidateS3,
        '        sSQL.Append("CandidatetOutputOrder, CandidateOutputLength, CandidateSeparator, CandidateS4Type, ")
        '        sSQL.Append("CandidateS5Type,SubsidizeAuto,AbsentTypeAuto")
        sSQL.Append("RecruimentActualQTYMode")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(tdbcDivisionID.Text) & COMMA) 'DivisionID, varchar[20], NULL
        'sSQL.Append(SQLNumber(chkDivisionLocked.Checked) & COMMA) 'DivisionLocked, tinyint, NOT NULL
        sSQL.Append(SQLString(tdbcInterviewerDefault.Columns("InterviewerDefault").ToString) & COMMA) 'InterviewerDefault, varchar[20], NULL
        sSQL.Append(SQLStringUnicode(txtIntPlaceDefault.Text, gbUnicode, False) & COMMA) 'IntPlaceDefault, varchar[250], NULL
        sSQL.Append(SQLStringUnicode(txtIntPlaceDefault.Text, gbUnicode, True) & COMMA) 'IntPlaceDefaultU, varchar[250], NULL
        sSQL.Append(SQLNumber(chkAutoCandidateID.Checked) & COMMA) 'AutoCandidateID, tinyint, NOT NULL
        'sSQL.Append(SQLNumber(chkAutoInterviewFileID.Checked) & COMMA) 'AutoInterviewFileID, tinyint, NOT NULL
        'sSQL.Append(SQLNumber(chkAutoRecInformationID.Checked)) 'AutoRecInformationID , tinyint, NOT NULL  IncidentID	51129
        '        sSQL.Append(SQLNumber(chkCandidateS1Type.Checked) & COMMA) 'CandidateS1Type, tinyint, NULL
        '        'sSQL.Append(SQLString("") & COMMA) 'CandidateS1, varchar[20], NULL
        '        sSQL.Append(SQLNumber(chkCandidateS2Type.Checked) & COMMA) 'CandidateS2Type, tinyint, NULL
        '        'sSQL.Append(SQLString("") & COMMA) 'CandidateS2, varchar[20], NULL
        '        sSQL.Append(SQLNumber(chkCandidateS3Type.Checked) & COMMA) 'CandidateS3Type, tinyint, NULL
        '        'sSQL.Append(SQLString("") & COMMA) 'CandidateS3, varchar[20], NULL
        '        sSQL.Append(SQLNumber(cboCandidateOutputOrder.SelectedIndex) & COMMA) 'CandidatetOutputOrder, tinyint, NULL
        '        sSQL.Append(SQLNumber(c1NumCandudateOutputLength.Value) & COMMA) 'CandidateOutputLength, tinyint, NULL
        '        sSQL.Append(SQLString(IIf(chkSeparator.Checked, cboCandidateSeparator.Text, "")) & COMMA) 'CandidateSeparator, varchar[20], NULL
        '        sSQL.Append(SQLNumber(chkCandidateS4Type.Checked) & COMMA) 'CandidateS4Type, tinyint, NOT NULL
        '        sSQL.Append(SQLNumber(chkCandidateS5Type.Checked) & COMMA) 'CandidateS5Type, tinyint, NOT NULL
        '        sSQL.Append(SQLNumber(chkSupply.Checked) & COMMA)
        '        sSQL.Append(SQLNumber(chkAuto.Checked))
        If optRecruimentActualQTYMode1.Checked Then
            sSQL.Append(SQLNumber(1))
        Else
            sSQL.Append(SQLNumber(0))
        End If

        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T0000
    '# Created User: Lê Thị Lành
    '# Created Date: 02/10/2007 08:32:19
    '# Modified User: 
    '# Modified Date: 
    '# Description: Cập nhật lại bảng D25T0000
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T0000() As StringBuilder
        Dim sSQL As New StringBuilder
        'IncidentID	50850  theo tài liệu PSAP tab mã số tự động chỉ giử lại check thiết lập mã ứng viên tự động
        '        sSQL.Append("Update D25T0000 Set ")
        '        sSQL.Append("DivisionID = " & SQLString(tdbcDivisionID.Text) & COMMA) 'varchar[20], NULL
        '        'sSQL.Append("DivisionLocked = " & SQLNumber(chkDivisionLocked.Checked) & COMMA) 'tinyint, NOT NULL
        '        sSQL.Append("InterviewerDefault = " & SQLString(tdbcInterviewerDefault.Text) & COMMA) 'varchar[20], NULL
        '        sSQL.Append("IntPlaceDefault = " & SQLStringUnicode(txtIntPlaceDefault.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        '        sSQL.Append("IntPlaceDefaultU = " & SQLStringUnicode(txtIntPlaceDefault.Text, gbUnicode, True) & COMMA) 'varchar[500], NULL
        '        sSQL.Append("AutoCandidateID = " & SQLNumber(chkAutoCandidateID.Checked) & COMMA) 'tinyint, NOT NULL
        '        sSQL.Append("CandidateS1Type = " & SQLNumber(chkCandidateS1Type.Checked) & COMMA) 'tinyint, NULL
        '        sSQL.Append("CandidateS2Type = " & SQLNumber(chkCandidateS2Type.Checked) & COMMA) 'tinyint, NULL
        '        sSQL.Append("CandidateS3Type = " & SQLNumber(chkCandidateS3Type.Checked) & COMMA) 'tinyint, NULL
        '        sSQL.Append("CandidatetOutputOrder = " & SQLNumber(cboCandidateOutputOrder.SelectedIndex) & COMMA) 'tinyint, NULL
        '        sSQL.Append("CandidateOutputLength = " & SQLNumber(c1NumCandudateOutputLength.Value) & COMMA) 'tinyint, NULL
        '        sSQL.Append("CandidateSeparator = " & SQLString(IIf(chkSeparator.Checked, cboCandidateSeparator.Text, "")) & COMMA) 'varchar[20], NULL
        '        sSQL.Append("CandidateS4Type = " & SQLNumber(chkCandidateS4Type.Checked) & COMMA) 'tinyint, NOT NULL
        '        sSQL.Append("CandidateS5Type = " & SQLNumber(chkCandidateS5Type.Checked) & COMMA) 'tinyint, NOT NULL
        '        sSQL.Append("SubsidizeAuto = " & SQLNumber(chkSupply.Checked) & COMMA) 'tinyint, NOT NULL
        '        sSQL.Append("AbsentTypeAuto = " & SQLNumber(chkAuto.Checked)) 'tinyint, NOT NULL

        sSQL.Append("Update D25T0000 Set ")
        sSQL.Append("DivisionID = " & SQLString(tdbcDivisionID.Text) & COMMA) 'varchar[20], NULL
        'sSQL.Append("DivisionLocked = " & SQLNumber(chkDivisionLocked.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("InterviewerDefault = " & SQLString(tdbcInterviewerDefault.Text) & COMMA) 'varchar[20], NULL
        sSQL.Append("IntPlaceDefault = " & SQLStringUnicode(txtIntPlaceDefault.Text, gbUnicode, False) & COMMA) 'varchar[250], NULL
        sSQL.Append("IntPlaceDefaultU = " & SQLStringUnicode(txtIntPlaceDefault.Text, gbUnicode, True) & COMMA) 'varchar[500], NULL
        sSQL.Append("AutoCandidateID = " & SQLNumber(chkAutoCandidateID.Checked) & COMMA) 'tinyint, NOT NULL
        'sSQL.Append("AutoInterviewFileID = " & SQLNumber(chkAutoInterviewFileID.Checked) & COMMA) 'tinyint, NOT NULL
        'sSQL.Append("AutoRecInformationID = " & SQLNumber(chkAutoRecInformationID.Checked)) 'tinyint, NOT NULL  IncidentID	51129
        'sSQL.Append("CandidateS1Type = " & SQLNumber(chkCandidateS1Type.Checked) & COMMA) 'tinyint, NULL
        'sSQL.Append("CandidateS2Type = " & SQLNumber(chkCandidateS2Type.Checked) & COMMA) 'tinyint, NULL
        'sSQL.Append("CandidateS3Type = " & SQLNumber(chkCandidateS3Type.Checked) & COMMA) 'tinyint, NULL
        'sSQL.Append("CandidatetOutputOrder = " & SQLNumber(cboCandidateOutputOrder.SelectedIndex) & COMMA) 'tinyint, NULL
        'sSQL.Append("CandidateOutputLength = " & SQLNumber(c1NumCandudateOutputLength.Value) & COMMA) 'tinyint, NULL
        'sSQL.Append("CandidateSeparator = " & SQLString(IIf(chkSeparator.Checked, cboCandidateSeparator.Text, "")) & COMMA) 'varchar[20], NULL
        'sSQL.Append("CandidateS4Type = " & SQLNumber(chkCandidateS4Type.Checked) & COMMA) 'tinyint, NOT NULL
        'sSQL.Append("CandidateS5Type = " & SQLNumber(chkCandidateS5Type.Checked) & COMMA) 'tinyint, NOT NULL
        'sSQL.Append("SubsidizeAuto = " & SQLNumber(chkSupply.Checked) & COMMA) 'tinyint, NOT NULL
        'sSQL.Append("AbsentTypeAuto = " & SQLNumber(chkAuto.Checked)) 'tinyint, NOT NULL
        If optRecruimentActualQTYMode1.Checked Then
            sSQL.Append("RecruimentActualQTYMode = 1") 'tinyint, NOT NULL
        Else
            sSQL.Append("RecruimentActualQTYMode = 0") 'tinyint, NOT NULL
        End If

        Return sSQL
    End Function

    'Check: Thiet lap ma ung vien tu dong
    Private Sub chkAutoCandidateID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoCandidateID.CheckedChanged
        'Phần tự động
        chkAuto.Enabled = chkAutoCandidateID.Checked
        chkCandidateS1Type.Enabled = chkAutoCandidateID.Checked And chkAuto.Checked
        chkCandidateS2Type.Enabled = chkAutoCandidateID.Checked And chkAuto.Checked
        chkCandidateS3Type.Enabled = chkAutoCandidateID.Checked And chkAuto.Checked
        cboCandidateOutputOrder.Enabled = chkAutoCandidateID.Checked And chkAuto.Checked
        chkSeparator.Enabled = chkAutoCandidateID.Checked And chkAuto.Checked
        cboCandidateSeparator.Enabled = chkAutoCandidateID.Checked And chkAuto.Checked And chkSeparator.Checked
        c1NumCandudateOutputLength.Enabled = chkAutoCandidateID.Checked And chkAuto.Checked
        'Phần bổ sung
        chkSupply.Enabled = chkAutoCandidateID.Checked And chkAuto.Checked
        chkCandidateS4Type.Enabled = chkSupply.Checked And chkAutoCandidateID.Checked And chkAuto.Checked
        chkCandidateS5Type.Enabled = chkSupply.Checked And chkAutoCandidateID.Checked And chkAuto.Checked
    End Sub

    'check: Phan tu dong
    Private Sub chkAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAuto.CheckedChanged
        If chkAutoCandidateID.Checked = False Then Exit Sub
        chkCandidateS1Type.Enabled = chkAuto.Checked
        chkCandidateS2Type.Enabled = chkAuto.Checked
        chkCandidateS3Type.Enabled = chkAuto.Checked
        cboCandidateOutputOrder.Enabled = chkAuto.Checked
        chkSeparator.Enabled = chkAuto.Checked
        cboCandidateSeparator.Enabled = chkAuto.Checked And chkSeparator.Checked
        c1NumCandudateOutputLength.Enabled = chkAuto.Checked
        'Phần bổ sung
        chkSupply.Enabled = chkAuto.Checked
        chkCandidateS4Type.Enabled = chkSupply.Checked And chkAuto.Checked
        chkCandidateS5Type.Enabled = chkSupply.Checked And chkAuto.Checked
    End Sub

    'Check:  Phan bo sung
    Private Sub chkSupply_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSupply.CheckedChanged
        If chkAutoCandidateID.Checked = False Or chkAuto.Checked = False Then Exit Sub
        chkCandidateS4Type.Enabled = chkSupply.Checked
        chkCandidateS5Type.Enabled = chkSupply.Checked
    End Sub

    Private Sub chkSeparator_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSeparator.CheckedChanged
        If chkAutoCandidateID.Checked = False Then Exit Sub
        If chkSeparator.Checked Then
            cboCandidateSeparator.Enabled = True
            cboCandidateSeparator.SelectedIndex = 0
        Else
            cboCandidateSeparator.Enabled = False
            cboCandidateSeparator.Text = ""
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD09T0009
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 09/06/2014 02:06:19
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD09T0009() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D09T0009 Set ")
        sSQL.Append("NumValue = " & SQLMoney(chkIsUseAppRecruitProposal.Checked)) 'decimal, NOT NULL
        sSQL.Append(" Where ModuleID = 'D25' AND TransTypeID = 'RecruitmentRequest' AND FormID = 'D25F2000'")
        Return sSQL
    End Function


End Class