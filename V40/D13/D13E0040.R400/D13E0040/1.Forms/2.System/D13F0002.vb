Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 25/07/2006 2:41:18 PM
'# Created User: Lê Văn Phước
'# Modify Date: 25/07/2006 2:41:18 PM
'# Modify User: Lê Văn Phước
'#-------------------------------------------------------------------------------------
Public Class D13F0002

    Dim bSetUpDivision As Boolean = False

#Region "Events tdbcDivisionID with txtDivisionName"

    Private Sub tdbcDivisionID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDefaultDivisionID.Close
        If tdbcDefaultDivisionID.FindStringExact(tdbcDefaultDivisionID.Text) = -1 Then
            tdbcDefaultDivisionID.Text = ""
            txtDivisionName.Text = ""
        End If
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDefaultDivisionID.SelectedValueChanged
        txtDivisionName.Text = tdbcDefaultDivisionID.Columns(1).Value.ToString
    End Sub

    'Private Sub tdbcDivisionID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
    '        tdbcDivisionID.Text = ""
    '        txtDivisionName.Text = ""
    '    End If
    'End Sub

#End Region

    Private Sub LoadTDBCombo()
        LoadCboDivisionID(tdbcDefaultDivisionID, "D09", True, gbUnicode)
    End Sub

    Private Sub D13F0002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Lemon3.D00Options.LockControlsFromDesktop(tabOption)
        AddHandler Me.KeyPress, AddressOf FormKeyPress
        Loadlanguage()
        LoadTDBCombo()
        CheckPermission()
        LoadEdit()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
    End Sub

    Private Sub CheckPermission()
        Dim per As Integer = ReturnPermission(Me.Name) 'Dùng kiểm tra form đang ở quyền nào
        If per = 1 Then
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub LoadEdit()
        tdbcDefaultDivisionID.SelectedValue = D13Options.DefaultDivisionID
        tdbcDefaultDivisionID.Tag = D13Options.DefaultDivisionID
        chkMessageAskBeforeSave.Checked = D13Options.MessageAskBeforeSave
        chkMessageWhenSaveOK.Checked = D13Options.MessageWhenSaveOK
        chkViewFormPeriodWhenAppRun.Checked = D13Options.ViewFormPeriodWhenAppRun
        chkShowDiagram.Checked = False ' D13Options.ShowDiagram
        chkShowReportPath.Checked = D13Options.ShowReportPath
        chkShowZeroNumber.Checked = D13Options.ShowZeroNumber

        chkShowFormular.Checked = D13Options.ShowFormular

        If D13Options.ReportLanguage = 2 Then
            optReportLanguage2.Checked = True
        ElseIf D13Options.ReportLanguage = 1 Then
            optReportLanguage1.Checked = True
        Else
            optReportLanguage0.Checked = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As New StringBuilder
        sSQL.Append(Lemon3.SQLSaveD91T8889s(D13, tabOption))
        'ListControlExclude(): DS control không lưu, có thể không truyền
        ' sSQL.Append(Lemon3.SQLInsertD91T8889(D13, "MaxLines", chkMaxLines.Text, txtMaxLines.Text))
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)

        UpdateOptions()
        If tdbcDefaultDivisionID.Tag.ToString <> tdbcDefaultDivisionID.Text Or bSetUpDivision Then
            'D99C0008.MsgSetUpDivision()
            D99C0008.MsgL3(rl3("Ban_phai_khoi_dong_lai_module_thi_thiet_lap_moi_co_tac_dung"))
        Else
            SaveOK()
        End If
        Me.Close()
    End Sub

    Private Sub UpdateOptions()
        With D13Options
            .DefaultDivisionID = tdbcDefaultDivisionID.Text
            .MessageAskBeforeSave = chkMessageAskBeforeSave.Checked
            .MessageWhenSaveOK = chkMessageWhenSaveOK.Checked
            .ViewFormPeriodWhenAppRun = chkViewFormPeriodWhenAppRun.Checked
            .ShowDiagram = False
            .ShowReportPath = chkShowReportPath.Checked
            .ShowZeroNumber = chkShowZeroNumber.Checked
            .ShowFormular = chkShowFormular.Checked
            If optReportLanguage2.Checked Then
                .ReportLanguage = 2
            ElseIf optReportLanguage1.Checked Then
                .ReportLanguage = 1
            Else
                .ReportLanguage = 0
            End If

            'D99C0007.SaveModulesSetting(D13, ModuleOption.lmOptions, "DefaultDivisionID", .DefaultDivisionID)
            'D99C0007.SaveModulesSetting(D13, ModuleOption.lmOptions, "MessageAskBeforeSave", .MessageAskBeforeSave)
            'D99C0007.SaveModulesSetting(D13, ModuleOption.lmOptions, "MessageWhenSaveOK", .MessageWhenSaveOK)
            'D99C0007.SaveModulesSetting(D13, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", .ViewFormPeriodWhenAppRun)
            'D99C0007.SaveModulesSetting(D13, ModuleOption.lmOptions, "ShowDiagram", .ShowDiagram)
            'D99C0007.SaveModulesSetting(D13, ModuleOption.lmOptions, "ShowReportPath", .ShowReportPath)
            'D99C0007.SaveModulesSetting(D13, ModuleOption.lmOptions, "ReportLanguage", .ReportLanguage)
            'D99C0007.SaveModulesSetting(D13, ModuleOption.lmOptions, "ShowZeroNumber", .ShowZeroNumber)
            'D99C0007.SaveModulesSetting(D13, ModuleOption.lmOptions, "ShowFormular", .ShowFormular)
        End With
    End Sub

    Private Function AllowSave() As Boolean
        Return True
    End Function


    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Tuy_chon_-_D13F0002") & UnicodeCaption(gbUnicode) 'Tîy chãn - D13F0002
        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi_mac_dinh") 'Đơn vị mặc định
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkShowDiagram.Text = rl3("Hien_thi_so_do_quy_trinh") 'Hiển thị sơ đồ quy trình
        chkViewFormPeriodWhenAppRun.Text = rl3("Hien_thi_man_hinh_chon_ky_ke_toan_truoc_khi_chay_chuong_trinh") 'Hiển thị màn hình chọn kỳ kế toán khi chạy chương trình
        chkMessageWhenSaveOK.Text = rl3("Thong_bao_khi_luu_thanh_cong") 'Thông báo khi lưu thành công
        chkMessageAskBeforeSave.Text = rl3("Hoi_truoc_khi_luu") 'Hỏi trước khi lưu
        'chkShowReportPath.Text = rl3("Hien_thi_man_hinh_duong_dan_bao_cao") 'Hiển thị màn hình đường dẫn báo cáo cho lần sau
        chkShowReportPath.Text = rl3("MSG000035")
        '================================================================ 
        optReportLanguage0.Text = rl3("Tieng_Viet") 'Tiếng Việt
        optReportLanguage1.Text = rl3("Song_ngu_Viet_-_Anh") 'Song ngữ Việt - Anh
        optReportLanguage2.Text = rl3("Tieng_Anh") 'Tiếng Anh
        '================================================================ 
        grpReportLanguage.Text = rl3("Ngon_ngu_bao_cao") 'Ngôn ngữ báo cáo
        '================================================================ 
        TabPageDefault.Text = "1. " & rl3("Mac_dinh") 'Mặc định
        TabPage1.Text = "2. " & rl3("Bao_cao") 'Báo cáo
        '================================================================ 
        tdbcDefaultDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDefaultDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        chkShowZeroNumber.Text = rl3("Hien_thi_so_0_tai_man_hinh_bang_luong_cong_ty") 'Hiển thị số 0 tại màn hình bảng lương công ty
        chkShowFormular.Text = rl3("Hien_thi_cong_thucdien_giai_cong_thuc_tinh_luong_tai_man_hinh_bang_luong_cong_ty")
    End Sub

    Private Sub chkShowDiagram_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDiagram.Click
        bSetUpDivision = True
    End Sub

End Class