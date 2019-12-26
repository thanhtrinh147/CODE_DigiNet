'''' <summary>
'''' Các vấn đề liên quan đến Thông tin hệ thống và Tùy chọn
'''' </summary>
'''' <summary>
'''' Khai báo structure cho phần định dạng format
'''' </summary>
Public Structure StructureFormat
    '  D45 Format here
    Public Default2Number As String
    Public Default1Number As String
    Public DefaultZeroNumber As String
    '------------------------------------------------------------------------
End Structure


''' <summary>
''' Khai báo Structure cho phần Tùy chọn của Module
''' </summary>
Public Structure StructureOption
    ''' <summary>
    ''' Hỏi trước khi lưu
    ''' </summary>
    Public MessageAskBeforeSave As Boolean
    ''' <summary>
    ''' Thông báo khi lưu thành công
    ''' </summary>
    Public MessageWhenSaveOK As Boolean
    ''' <summary>
    ''' Hiển thị form chọn kỳ kế toán khi chạy chương trình
    ''' </summary>
    Public ViewFormPeriodWhenAppRun As Boolean
    ''' <summary>
    ''' Lưu giá trị gần nhất
    ''' </summary>
    Public SaveLastRecent As Boolean
    ''' <summary>
    ''' Lưu đơn vị mặc định
    ''' </summary>
    Public DefaultDivisionID As String
    ''' <summary>
    ''' Hiển thị màn hình đường dẫn báo cáo
    ''' </summary>
    Public ShowReportPath As Boolean
    ''' <summary>
    ''' Ngôn ngữ báo cáo
    ''' </summary>
    Public ReportLanguage As Integer
    ''' <summary>
    ''' Tự động copy dòng trên xuống dòng dưới
    ''' </summary>
    ''' <remarks></remarks>
    Public AutoCopyValue As Boolean
    ''' <summary>
    ''' Bỏ qua mã nhân viên
    ''' </summary>
    ''' <remarks></remarks>
    Public CancelEmployeeID As Boolean
    ''' <summary>
    ''' Sử dụng chức năng phím Enter để di chuyển đến dòng tiếp theo
    ''' </summary>
    ''' <remarks></remarks>
    Public UseEnterMoveDown As Boolean
End Structure

''' <summary>
''' Khai báo structure cho phần Thiết lập hệ thống
''' </summary>
Public Structure StructureSystem
    ''' <summary>
    ''' Đơn vị mặc định
    ''' </summary>
    Public DefaultDivisionID As String
    Public IsQC As Boolean
    Public IsOQuantity As Boolean
    Public IsWorkingHour As Boolean
End Structure

Module D45X0004

    Public D45Format As StructureFormat

    ''' <summary>
    ''' Lưu trữ các thiết lập tùy chọn
    ''' </summary>
    Public D45Options As StructureOption

    ''' <summary>
    ''' Lưu trữ các thiết lập Thông tin hệ thống
    ''' </summary>
    Public D45Systems As StructureSystem


    ''' <summary>
    ''' Load toàn bộ các thông số tùy chọn vào biến D45Options
    ''' </summary>
    Public Sub LoadOptions()
        With D45Options
            .DefaultDivisionID = D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DefaultDivisionID", "")
            .MessageAskBeforeSave = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "MessageAskBeforeSave", "True"))
            .MessageWhenSaveOK = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "MessageWhenSaveOK", "True"))
            .ViewFormPeriodWhenAppRun = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", "False"))
            .AutoCopyValue = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "AutoCopyValue", "False"))
            .CancelEmployeeID = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "CancelEmployeeID", "False"))
            .UseEnterMoveDown = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "UseEnterMoveDown", "False"))
            .SaveLastRecent = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "SaveLastRecent", "False"))
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", "") = "" Then
                .ShowReportPath = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ShowDirectory", "True", CodeOption.lmUncode), Boolean)
                D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", .ShowReportPath)
            Else
                .ShowReportPath = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", "") = "" Then
                .ReportLanguage = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLang", "0"), Integer)
                D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", .ReportLanguage)
            Else
                .ReportLanguage = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", "0"), Integer)
            End If
        End With
    End Sub


    ''' <summary>
    ''' Load toàn bộ các thống số thiết lập hệ thống vào biến D45Systems
    ''' </summary>
    Public Sub LoadSystems()
        gsFormatDateType = GetFormatDateType()
        Dim sSQL As String = "Select * From D45T0000 WITH(NOLOCK) "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then

            With D45Systems
                .DefaultDivisionID = dt.Rows(0).Item("DivisionID").ToString
                .IsQC = Convert.ToBoolean(dt.Rows(0).Item("IsQC"))
                .IsOQuantity = Convert.ToBoolean(dt.Rows(0).Item("IsOQuantity"))
                .IsWorkingHour = Convert.ToBoolean(dt.Rows(0).Item("IsWorkingHour"))
            End With
            dt.Dispose()
        Else
            With D45Systems
                .DefaultDivisionID = ""
                .IsQC = False
                .IsOQuantity = False
                .IsWorkingHour = False
            End With
        End If
    End Sub

    Public Sub LoadFormats()
        D45Format.Default2Number = "#,##0.00"
        D45Format.Default1Number = "#,##0.0"
        D45Format.DefaultZeroNumber = "#,##0"
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
    ''' Thông báo trước khi khóa phiếu
    ''' </summary>    
    Public Function AskLocked() As DialogResult
        If D45Options.MessageAskBeforeSave Then
            Return D99C0008.MsgAsk(rl3("MSG000002"), MessageBoxDefaultButton.Button2)
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
    ''' Thông báo sau khi khóa phiếu thành công
    ''' </summary>
    Public Sub LockedOK()
        If D45Options.MessageWhenSaveOK Then D99C0008.MsgSaveOK()
    End Sub

    ''' <summary>
    ''' Thông báo không xóa được dữ liệu
    ''' </summary>
    Public Sub DeleteNotOK()
        D99C0008.MsgL3(rl3("Khong_xoa_duoc_du_lieu"))
    End Sub

    ''' <summary>
    ''' Thông báo không khóa được phiếu
    ''' </summary>
    Public Sub LockedNotOK()
        D99C0008.MsgSaveNotOK()
    End Sub

End Module
