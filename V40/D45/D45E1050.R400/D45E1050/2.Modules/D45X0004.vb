''' <summary>
''' Các vấn đề liên quan đến Thông tin hệ thống và Tùy chọn
''' </summary>
Module D45X0004
    Public Sub LoadOptions()
        With D45Options
            .DefaultDivisionID = D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DefaultDivisionID", "")
            '.LockDivisionID = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "LockDivisionID", "False"))
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "MessageAskBeforeSave") = "" Then
                Dim D45LocalOptions As String = "Lemon3_D45"
                Dim Options As String = "Options"
                .MessageAskBeforeSave = CType(GetSetting(D45LocalOptions, Options, "AskBeforeSave", "True"), Boolean)
            Else
                .MessageAskBeforeSave = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "MessageAskBeforeSave", "True"), Boolean)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "MessageWhenSaveOK") = "" Then
                Dim D45LocalOptions As String = "Lemon3_D45"
                Dim Options As String = "Options"
                .MessageWhenSaveOK = CType(GetSetting(D45LocalOptions, Options, "MessageWhenSaveOK", "True"), Boolean)
            Else
                .MessageWhenSaveOK = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "MessageWhenSaveOK", "True"), Boolean)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun") = "" Then
                Dim D45LocalOptions As String = "Lemon3_D45"
                Dim Options As String = "Options"
                .ViewFormPeriodWhenAppRun = CType(GetSetting(D45LocalOptions, Options, "SelectPeriod", "False"), Boolean)
            Else
                .ViewFormPeriodWhenAppRun = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", "False"), Boolean)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "UseEnterAsTab") = "" Then
                Dim D45LocalOptions As String = "Lemon3_D45"
                Dim Options As String = "Options"
                .UseEnterAsTab = CType(GetSetting(D45LocalOptions, Options, "EnterTab", "True"), Boolean)
            Else
                .UseEnterAsTab = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "UseEnterAsTab", "True"), Boolean)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "SaveRecentForm") = "" Then
                Dim D45LocalOptions As String = "Lemon3_D45"
                Dim Options As String = "Options"
                .SaveLastRecent = CType(GetSetting(D45LocalOptions, Options, "SaveRecentForm", "False"), Boolean)
            Else
                .SaveLastRecent = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "SaveRecentForm", "False"), Boolean)
            End If

            .ReportLanguage = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)

            '.NoneShowReportPathNextTime = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DisabledPathReport", "True"), Boolean)

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath") = "" Then ' Lấy đường dẫn cũ
                .ShowReportPath = L3Bool(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DisabledPathReport", "True"))
                'Nếu chưa có đường dẫn NET thì lưu registry thêm vào biến mới theo chuẩn
                D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", .ShowReportPath)
            Else 'Lấy đường dẫn mới theo chuẩn
                .ShowReportPath = L3Bool(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", "True"))
            End If


            .ViewMyVoucher = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DisplayMyVoucherOnly", "False"), Boolean)
        End With
    End Sub

    ''' <summary>
    ''' Hỏi trước khi lưu tùy thuộc vào thiết lập ở phần Tùy chọn
    ''' </summary>
    Public Function AskSave() As DialogResult
        If D45Options.MessageAskBeforeSave Then
            Return D99C0008.MsgAskSave()
        Else
            Return DialogResult.Yes
        End If
    End Function

    ''' <summary>
    ''' Thông báo khi lưu thành công tùy theo phần thiết lập ở tùy chọn
    ''' </summary>
    Public Sub SaveOK()
        If D45Options.MessageWhenSaveOK Then D99C0008.MsgSaveOK()
    End Sub

    ''' <summary>
    ''' Thông báo không xóa được dữ liệu
    ''' </summary>
    Public Sub DeleteNotOK()
        D99C0008.MsgL3("Không xóa được dữ liệu")
    End Sub


End Module
