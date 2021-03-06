'#-------------------------------------------------------------------------------------
'# Created Date: 25/07/2006 2:41:18 PM
'# Created User: Nguyễn Thị Minh Hòa
'# Modify Date: 25/07/2006 2:41:18 PM
'# Modify User: Nguyễn Thị Minh Hòa
'#-------------------------------------------------------------------------------------
Public Class D45F0002

#Region "Events tdbcDivisionID with txtDivisionName"

    Private Sub tdbcDivisionID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
            txtDivisionName.Text = ""
        End If
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        txtDivisionName.Text = tdbcDivisionID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcDivisionID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcDivisionID.Text = ""
            txtDivisionName.Text = ""
        End If
    End Sub

#End Region

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDivisionID
        'LoadDataSource(tdbcDivisionID, sSQL)
        LoadCboDivisionID(tdbcDivisionID, "D09", True, gbUnicode)
    End Sub

    Private Sub D45F0002_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
        If e.Alt And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tabOption.SelectedTab = TabPageDefault
            If tdbcDivisionID.Enabled Then tdbcDivisionID.Focus()
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            tabOption.SelectedTab = TabPageShow
            chkAutoCopy.Focus()
        ElseIf e.Alt And (e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tabOption.SelectedTab = TabPageReport
            optVietNamese.Focus()
        End If
    End Sub

    Private Sub D45F0002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.KeyPress, AddressOf FormKeyPress
        Loadlanguage()
        LoadTDBCombo()
        LoadEdit()
        InputbyUnicode(Me, gbUnicode)
        btnSave.Enabled = ReturnPermission("D45F0002") > EnumPermission.View
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Tuy_chon_-_D45F0002") & UnicodeCaption(gbUnicode) 'Tîy chãn - D45F0002
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkViewFormPeriodWhenAppRun.Text = rl3("Hien_thi_man_hinh_chon_ky_ke_toan_truoc_khi_chay_chuong_trinh") 'Hiển thị màn hình chọn kỳ kế toán khi chạy chương trình
        chkMessageWhenSaveOK.Text = rl3("Thong_bao_khi_luu_thanh_cong") 'Thông báo khi lưu thành công
        chkMessageAskBeforeSave.Text = rl3("Hoi_truoc_khi_luu") 'Hỏi trước khi lưu
        lblDefaultDivision.Text = rl3("Don_vi_mac_dinh") 'Đơn vị mặc định
        chkAutoCopy.Text = rl3("Tu_dong_copy_gia_tri_dong_tren_xuong_dong_duoi") 'Tự động copy giá trị dòng trên xuống dòng dưới
        chkCancelEmployeeID.Text = rl3("Bo_qua_ma_nhan_vien") 'Bỏ qua mã nhân viên
        chkSaveLastRecent.Text = rl3("Luu_gia_tri_gan_nhat_khi_nhap_tiep") 'Lưu giá trị gần nhất khi nhập tiếp
        chkUseEnterMoveDown.Text = rl3("Su_dung_phim_Enter_de_di_chuyen_den_o_duoi_o_hien_hanh") 'Sử dụng phím Enter để di chuyển đến ô dưới ô hiện hành
        chkShowReportPath.Text = rl3("MSG000035") 'Hiển thị màn hình đường dẫn báo cáo
        chkFormula.Text = rl3("Hien_thi_dien_giai__cong_thuc_tinh_luong_tai_man_hinh_ket_qua_tinh_luong") 'Hiển thị diễn giải / công thức tính lương tại màn hình kết quả tính lương

        '================================================================ 
        optEnglish.Text = rl3("Tieng_Anh") 'Tiếng Anh
        optVietnameseEnglish.Text = rl3("Song_ngu_Viet_-_Anh") 'Song ngữ_Việt Anh
        optVietnamese.Text = rl3("Tieng_Viet") 'Tiếng Việt
        optPieceWorkMethod1.Text = rl3("Nhan_vien") & Space(1) & "/" & Space(1) & rl3("San_pham") & Space(1) & "/" & Space(1) & rl3("Cong_doan") 'Nhân viên / Sản phẩm / Công đoạn
        optPieceWorkMethod2.Text = rl3("San_pham") & Space(1) & "/" & Space(1) & rl3("Cong_doan") & Space(1) & "/" & Space(1) & rl3("Nhan_vien") 'Sản phẩm / Công đoạn / Nhân viên
        optPieceWorkMethod3.Text = rl3("Nhan_vien") & Space(1) & "/" & Space(1) & rl3("San_pham") 'Nhân viên / Sản phẩm
        '================================================================ 
        grp2.Text = rl3("Ngon_ngu_bao_cao") 'Ngôn ngữ báo cáo
        grpPieceMethod.Text = rl3("Phuong_thuc_cham_cong") 'Phương thức chấm công
        '================================================================ 
        TabPageDefault.Text = rl3("1_Mac_dinh") '1. Mặc định
        TabPageShow.Text = "2. " & rl3("Tien_ich") 'Tiện ích
        TabPageReport.Text = rl3("3_Bao_cao") '3. Báo cáo
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma_don_vi") 'Mã đơn vị
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten_don_vi") 'Tên đơn vị
    End Sub


    Private Sub LoadEdit()
        LoadOptions()
        Dim sSQL As String = ""
        sSQL = "Select D45.* From D45T5550 D45  WITH(NOLOCK) Where D45.UserID=" & SQLString(gsUserID)
        Dim dt As DataTable = ReturnDataTable(sSQL)

        tdbcDivisionID.SelectedValue = D45Options.DefaultDivisionID
        tdbcDivisionID.Tag = D45Options.DefaultDivisionID
        chkMessageAskBeforeSave.Checked = D45Options.MessageAskBeforeSave
        chkMessageWhenSaveOK.Checked = D45Options.MessageWhenSaveOK
        chkViewFormPeriodWhenAppRun.Checked = D45Options.ViewFormPeriodWhenAppRun
        chkAutoCopy.Checked = D45Options.AutoCopyValue
        chkCancelEmployeeID.Checked = D45Options.CancelEmployeeID
        chkUseEnterMoveDown.Checked = D45Options.UseEnterMoveDown
        chkSaveLastRecent.Checked = D45Options.SaveLastRecent
        chkShowReportPath.Checked = D45Options.ShowReportPath
        chkFormula.Checked = D45Options.Fomula
        If D45Options.ReportLanguage = 0 Then
            optVietnamese.Checked = True
        ElseIf D45Options.ReportLanguage = 1 Then
            optVietnameseEnglish.Checked = True
        ElseIf D45Options.ReportLanguage = 2 Then
            optEnglish.Checked = True
        End If
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("PieceWorkMethod").ToString = "2" Then
                optPieceWorkMethod2.Checked = True
            Else
                optPieceWorkMethod1.Checked = True
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        UpdateOptions()

        Dim sSQL As String = ""
        sSQL = SQLDeleteD45T5550.ToString & vbCrLf
        sSQL &= SQLInsertD45T5550.ToString & vbCrLf
        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult Then
            If tdbcDivisionID.Tag.ToString <> tdbcDivisionID.Text Then
                D99C0008.MsgSetUpDivision()
            Else
                SaveOK()
            End If
        Else
            SaveNotOK()
        End If
       
        Me.Close()
    End Sub

    Private Sub UpdateOptions()
        With D45Options
            .DefaultDivisionID = tdbcDivisionID.Text
            .MessageAskBeforeSave = chkMessageAskBeforeSave.Checked
            .MessageWhenSaveOK = chkMessageWhenSaveOK.Checked
            .ViewFormPeriodWhenAppRun = chkViewFormPeriodWhenAppRun.Checked
            .AutoCopyValue = chkAutoCopy.Checked
            .CancelEmployeeID = chkCancelEmployeeID.Checked
            .UseEnterMoveDown = chkUseEnterMoveDown.Checked
            .SaveLastRecent = chkSaveLastRecent.Checked
            .ShowReportPath = chkShowReportPath.Checked
            .Fomula = chkFormula.Checked
            If optVietnamese.Checked Then
                .ReportLanguage = 0
            ElseIf optVietnameseEnglish.Checked Then
                .ReportLanguage = 1
            ElseIf optEnglish.Checked Then
                .ReportLanguage = 2
            End If

            '   D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "LockDivisionID", .LockDivisionID)
            D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "DefaultDivisionID", .DefaultDivisionID)
            D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "MessageAskBeforeSave", .MessageAskBeforeSave)
            D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "MessageWhenSaveOK", .MessageWhenSaveOK)
            D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", .ViewFormPeriodWhenAppRun)
            D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "AutoCopyValue", .AutoCopyValue)
            D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "CancelEmployeeID", .CancelEmployeeID)
            D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "UseEnterMoveDown", .UseEnterMoveDown)
            D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "SaveLastRecent", .SaveLastRecent)
            D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", .ShowReportPath)
            D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "Fomula", .Fomula)
            D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", .ReportLanguage.ToString)
        End With
    End Sub

    Private Function AllowSave() As Boolean
        Return True
    End Function

    Private Sub chkDivisionLocked_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If tdbcDivisionID.Text <> "" Then
        '    tdbcDivisionID.Enabled = Not chkDivisionLocked.Checked
        'Else
        '    If chkDivisionLocked.Checked Then chkDivisionLocked.Checked = False
        'End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T5550
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/12/2009 03:27:03
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T5550() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T5550"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T5550
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/12/2009 03:27:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T5550() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D45T5550(")
        sSQL.Append("UserID, PieceWorkMethod")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID [KEY], varchar[20], NOT NULL
        If optPieceWorkMethod1.Checked Then
            sSQL.Append(SQLNumber(1)) 'PieceWorkMethod, int, NULL
        ElseIf optPieceWorkMethod2.Checked Then
            sSQL.Append(SQLNumber(2)) 'PieceWorkMethod, int, NULL
        Else
            sSQL.Append(SQLNumber(3)) 'PieceWorkMethod, int, NULL
        End If

        sSQL.Append(")")

        Return sSQL
    End Function


End Class