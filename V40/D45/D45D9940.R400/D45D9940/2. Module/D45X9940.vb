#Region "Khai báo Structure"

''' <summary>
''' Khai báo Structure cho phần Tùy chọn của Module
''' </summary>

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
    Public ReportLanguage As Byte
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
    Public Fomula As Boolean
End Structure

''' <summary>
''' Khai báo structure cho phần Thiết lập hệ thống
''' </summary>
Public Structure StructureSystem
    Public LoadSystem As Boolean
    Public FormatDateType As String
    Public IsUseBlock As Boolean

    ''' <summary>
    ''' Đơn vị mặc định
    ''' </summary>
    Public DefaultDivisionID As String
    Public IsQC As Boolean
    Public IsOQuantity As Boolean
    Public IsWorkingHour As Boolean
End Structure


#End Region


Public Module D45X9940
    ''' <summary>
    ''' Lưu trữ các thiết lập tùy chọn
    ''' </summary>
    Public D45Options As StructureOption
    ''' <summary>
    ''' Lưu trữ các thiết lập Thông tin hệ thống
    ''' </summary>
    Public D45Systems As StructureSystem
    Public Const D45 As String = "D45"
    Public Const MODULED45 As String = "D45E0040"
    Public gsPayrollVoucherID As String = ""

    Public Sub LoadOptions()
        Try
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
                    .ReportLanguage = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLang", "0"), Byte)
                    D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", .ReportLanguage)
                Else
                    .ReportLanguage = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
                End If
                .Fomula = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "Fomula", "true"))
            End With
        Catch ex As Exception
            MessageBox.Show("Error LoadOptions")
        End Try


    End Sub

    ''' <summary>
    ''' Load toàn bộ các thống số thiết lập hệ thống vào biến D45Systems
    ''' </summary>
    Public Sub LoadSystems()
        Try
            gsFormatDateType = GetFormatDateType()
            D45Systems.LoadSystem = True
            Dim sSQL As String = "Select * From D45T0000 WITH(NOLOCK) "
            Dim dt As DataTable = ReturnDataTable(sSQL)
            With D45Systems
                If dt.Rows.Count > 0 Then
                    .DefaultDivisionID = dt.Rows(0).Item("DivisionID").ToString
                    .IsQC = Convert.ToBoolean(dt.Rows(0).Item("IsQC"))
                    .IsOQuantity = Convert.ToBoolean(dt.Rows(0).Item("IsOQuantity"))
                    .IsWorkingHour = Convert.ToBoolean(dt.Rows(0).Item("IsWorkingHour"))

                    dt.Dispose()
                Else
                    .DefaultDivisionID = ""
                    .IsQC = False
                    .IsOQuantity = False
                    .IsWorkingHour = False

                End If
                Dim dtD09T0000 As DataTable = ReturndtD09T0000("IsUseBlock,FormatDateType")
                .FormatDateType = GetValueD09T0000(dtD09T0000, "FormatDateType")
                .IsUseBlock = L3Bool(GetValueD09T0000(dtD09T0000, "IsUseBlock"))
            End With

        Catch ex As Exception
            MessageBox.Show("Error LoadSystems")
        End Try
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
            Return D99C0008.MsgAsk(rL3("MSG000002"), MessageBoxDefaultButton.Button2)
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
    ''' Thông báo không khóa được phiếu
    ''' </summary>
    Public Sub LockedNotOK()
        D99C0008.MsgL3(rl3("MSG000003"))
    End Sub

    Public Sub LoadOthers()
        gsPayrollVoucherID = GetPayRollVoucherID()
    End Sub

    Public Sub LoadInfoGeneral()
        If D45Systems.LoadSystem Then Exit Sub

        LoadOptions()
        LoadSystems()
        LoadOthers()
        LoadCustomFormat()
    End Sub
End Module