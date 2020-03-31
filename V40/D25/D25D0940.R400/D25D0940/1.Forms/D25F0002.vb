'#-------------------------------------------------------------------------------------
'# Created Date: 25/07/2006 2:41:18 PM
'# Created User: Lê Văn Phước
'# Modify Date: 25/07/2006 2:41:18 PM
'# Modify User: Lê Văn Phước
'#-------------------------------------------------------------------------------------
Public Class D25F0002

#Region "Events tdbcDivisionID with txtDivisionName"

    Private Sub tdbcDivisionID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDefaultDivisionID.Close
        If tdbcDefaultDivisionID.FindStringExact(tdbcDefaultDivisionID.Text) = -1 Then
            tdbcDefaultDivisionID.Text = ""
            txtDefaultDivisionName.Text = ""
        End If
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDefaultDivisionID.SelectedValueChanged
        txtDefaultDivisionName.Text = tdbcDefaultDivisionID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcDivisionID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDefaultDivisionID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcDefaultDivisionID.Text = ""
            txtDefaultDivisionName.Text = ""
        End If
    End Sub

#End Region

    Private Sub LoadTDBCombo()
        LoadCboDivisionID(tdbcDefaultDivisionID, "D09", True, gbUnicode)

        Dim sSQL As String = ""
        sSQL &= " Select	TransTypeID, TransTypeName" & UnicodeJoin(gbUnicode) & " AS TransTypeName" & vbCrLf
        sSQL &= " 				From          D25T1080	 WITH(NOLOCK)" & vbCrLf
        sSQL &= " 				Where	Disabled = 0" & vbCrLf
        sSQL &= " 				Order by	TransTypeID" & vbCrLf
        LoadDataSource(tdbcTransTypeID, sSQL, gbUnicode)
    End Sub

    Private Sub D25F0002_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D25F0002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Loadlanguage()
        LoadTDBCombo()
        LoadEdit()
        InputbyUnicode(Me, gbUnicode)
        btnSave.Enabled = ReturnPermission("D25F0002") > EnumPermission.View
        tdbcDefaultDivisionID.Focus()
        Lemon3.D00Options.LockControlsFromDesktop(tabOption) 'ID 89301 01/08/2016
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Tuy_chon_-_D25F0002") & UnicodeCaption(gbUnicode) 'Tîy chãn - D25F0002
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        lblTransTypeID.Text = rl3("Loai_nghiep_vu")
        '================================================================ 
        chkSaveLastRecent.Text = rl3("Luu_gia_tri_gan_nhat_khi_nhap_tiep") 'Lưu giá trị gần nhất khi nhập tiếp
        chkViewFormPeriodWhenAppRun.Text = rl3("Hien_thi_man_hinh_chon_ky_ke_toan_truoc_khi_chay_chuong_trinh") 'Hiển thị màn hình chọn kỳ kế toán khi chạy chương trình
        chkMessageWhenSaveOK.Text = rl3("Thong_bao_khi_luu_thanh_cong") 'Thông báo khi lưu thành công
        chkMessageAskBeforeSave.Text = rl3("Hoi_truoc_khi_luu") 'Hỏi trước khi lưu
        chkUseEnterAsTab.Text = rL3("Su_dung_chuc_nang_phim_Enter_nhu_phim_Tab") 'Sử dụng chức năng phím Enter như phím Tab
        '================================================================ 
        TabPageDefault.Text = "1. " & rl3("Mac_dinh") '1. Mặc định
        '================================================================ 
        tdbcDefaultDivisionID.Columns("DivisionID").Caption = rl3("Ma_don_vi") 'Mã đơn vị
        tdbcDefaultDivisionID.Columns("DivisionName").Caption = rl3("Ten_don_vi") 'Tên đơn vị
        tdbcTransTypeID.Columns("TransTypeID").Caption = rl3("Ma")
        tdbcTransTypeID.Columns("TransTypeName").Caption = rl3("Ten")
        lblDefaultDivisionID.Text = rl3("Don_vi_mac_dinh")
    End Sub
    Private Sub LoadEdit()
        tdbcDefaultDivisionID.SelectedValue = D25Options.DefaultDivisionID
        tdbcDefaultDivisionID.Tag = D25Options.DefaultDivisionID
        'chkDivisionLocked.Checked = D25Options.LockDivisionID
        'chkDivisionLocked.Tag = D25Options.LockDivisionID

        tdbcTransTypeID.SelectedValue = D25Options.TransTypeID
        chkMessageAskBeforeSave.Checked = D25Options.MessageAskBeforeSave
        chkMessageWhenSaveOK.Checked = D25Options.MessageWhenSaveOK
        chkViewFormPeriodWhenAppRun.Checked = D25Options.ViewFormPeriodWhenAppRun
        chkUseEnterAsTab.Checked = D25Options.UseEnterAsTab
        chkSaveLastRecent.Checked = D25Options.SaveLastRecent
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        UpdateOptions()
        If tdbcDefaultDivisionID.Tag.ToString <> tdbcDefaultDivisionID.Text Then
            D99C0008.MsgSetUpDivision()
        Else
            SaveOK()
        End If
        Me.Close()
    End Sub

    Private Function UpdateOptions() As Boolean
        With D25Options
            .DefaultDivisionID = tdbcDefaultDivisionID.Text
            .MessageAskBeforeSave = chkMessageAskBeforeSave.Checked
            .MessageWhenSaveOK = chkMessageWhenSaveOK.Checked
            .ViewFormPeriodWhenAppRun = chkViewFormPeriodWhenAppRun.Checked
            .UseEnterAsTab = chkUseEnterAsTab.Checked
            .SaveLastRecent = chkSaveLastRecent.Checked
            .TransTypeID = tdbcTransTypeID.Text

            'D99C0007.SaveModulesSetting(D25, ModuleOption.lmOptions, "TransTypeID", .TransTypeID)
            'D99C0007.SaveModulesSetting(D25, ModuleOption.lmOptions, "DefaultDivisionID", .DefaultDivisionID)
            'D99C0007.SaveModulesSetting(D25, ModuleOption.lmOptions, "MessageAskBeforeSave", .MessageAskBeforeSave)
            'D99C0007.SaveModulesSetting(D25, ModuleOption.lmOptions, "MessageWhenSaveOK", .MessageWhenSaveOK)
            'D99C0007.SaveModulesSetting(D25, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", .ViewFormPeriodWhenAppRun)
            'D99C0007.SaveModulesSetting(D25, ModuleOption.lmOptions, "UseEnterAsTab", .UseEnterAsTab)
            'D99C0007.SaveModulesSetting(D25, ModuleOption.lmOptions, "SaveLastRecent", .SaveLastRecent)

            Dim sSQL As New StringBuilder 'ID 89301 01/08/2016
            sSQL.Append(Lemon3.SQLSaveD91T8889s(D25, tabOption, txtDefaultDivisionName, txtTransTypeName))
            Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
            Return bRunSQL
        End With
    End Function

    Private Function AllowSave() As Boolean
        Return True
    End Function

#Region "Events tdbcTransTypeID with txtTransTypeName"

    Private Sub tdbcTransTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.Close
        If tdbcTransTypeID.FindStringExact(tdbcTransTypeID.Text) = -1 Then
            tdbcTransTypeID.Text = ""
            txtTransTypeName.Text = ""
        End If
    End Sub

    Private Sub tdbcTransTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.SelectedValueChanged
        txtTransTypeName.Text = tdbcTransTypeID.Columns(1).Value.ToString
    End Sub

    'Private Sub tdbcTransTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcTransTypeID.KeyDown
    '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
    '        tdbcTransTypeID.Text = ""
    '        txtTransTypeName.Text = ""
    '    End If
    'End Sub

#End Region

End Class