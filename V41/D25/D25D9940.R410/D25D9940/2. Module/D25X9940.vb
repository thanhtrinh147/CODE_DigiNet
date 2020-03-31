#Region "Khai báo Structure"

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
    ''' Lưu đơn vị tính mặc định
    ''' </summary>
    Public DefaultDivisionID As String
    ''------------------------------------------------------------------------
    ''  D25 Options here
    ''------------------------------------------------------------------------
    Public UseEnterAsTab As Boolean
    Public ProjectID As String

    Public SaveLastRecent As Boolean
    Public TransTypeID As String
End Structure
''' <summary>
''' Khai báo structure cho phần Thiết lập hệ thống
''' </summary>
Public Structure StructureSystem
    ''' <summary>
    ''' Đơn vị mặc định
    ''' </summary>
    Public DefaultDivisionID As String
    '''' <summary>
    '''' Khóa đơn vị
    '''' </summary>
    'Public LockedDivisionID As Boolean
    '------------------------------------------------------------------------
    '  D25 Systems here
    '------------------------------------------------------------------------
    ''' <summary>
    ''' Người phỏng vấn
    ''' </summary>
    ''' <remarks></remarks>
    Public InterviewerDefault As String
    ''' <summary>
    ''' Nơi phỏng vấn
    ''' </summary>
    ''' <remarks></remarks>
    Public IntPlaceDefault As String
    ''' <summary>
    ''' Thiết lập mã ứng viên tự động
    ''' </summary>
    ''' <remarks></remarks>
    Public AutoCandidateID As Boolean
    ''' <summary>
    ''' Phần tự động
    ''' </summary>
    ''' <remarks></remarks>
    Public AbsentTypeAuto As Boolean
    ''' <summary>
    ''' Dấu phân cách
    ''' </summary>
    ''' <remarks></remarks>
    Public CandidateSeparator As String
    ''' <summary>
    ''' Dạng hiển thị
    ''' </summary>
    ''' <remarks></remarks>
    Public CandidateOutputOrder As Integer
    Public LoadSystem As Boolean
    Public FormatDateType As String
    Public IsUseBlock As Boolean
    Public AutoInterviewFileID As Boolean
    Public IsUseAppRecruitProposal As Boolean
End Structure

''' <summary>
''' Khai báo structure cho phần định dạng format
''' </summary>
Public Structure StructureFormat
    '  D25 Format here
    '------------------------------------------------------------------------
    Public DefaultNumber0 As String
    Public DefaultNumber1 As String
    Public DefaultNumber2 As String
    Public DefaultNumber4 As String
End Structure
#End Region


Public Module D25X9940
    ''' <summary>
    ''' Lưu trữ các thiết lập tùy chọn
    ''' </summary>
    Public D25Options As StructureOption
    ''' <summary>
    ''' Lưu trữ các thiết lập Thông tin hệ thống
    ''' </summary>
    Public D25Systems As StructureSystem
    ''' <summary>
    ''' Lưu trữ các thiết lập format
    ''' </summary>
    Public D25Format As StructureFormat
    Public Const D25 As String = "D25"
    Public Const MODULED25 As String = "D25E0040"
    Public Sub LoadOptions()
        Try
            'With D25Options
            '    If D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "MessageAskBeforeSave") = "" Then
            '        Dim LocalOptions As String = "Lemon3_D25"
            '        Dim Options As String = "Options"

            '        .MessageAskBeforeSave = CType(GetSetting(LocalOptions, Options, "AskBeforeSave", "True"), Boolean)
            '        .MessageWhenSaveOK = CType(GetSetting(LocalOptions, Options, "MessageWhenSaveOK", "True"), Boolean)
            '        .UseEnterAsTab = CType(GetSetting(LocalOptions, Options, "EnterAsTab", "False"), Boolean)

            '        'Mới chỉ có ở .Net
            '        .DefaultDivisionID = ""
            '        .ViewFormPeriodWhenAppRun = False
            '        .SaveLastRecent = False
            '        .TransTypeID = ""
            '    Else
            '        .DefaultDivisionID = D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "DefaultDivisionID", "")
            '        .MessageAskBeforeSave = Convert.ToBoolean(D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "MessageAskBeforeSave", "True"))
            '        .MessageWhenSaveOK = Convert.ToBoolean(D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "MessageWhenSaveOK", "True"))
            '        .ViewFormPeriodWhenAppRun = Convert.ToBoolean(D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", "False"))
            '        .UseEnterAsTab = Convert.ToBoolean(D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "UseEnterAsTab", "False"))
            '        .SaveLastRecent = Convert.ToBoolean(D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "SaveLastRecent", "False"))
            '        .TransTypeID = D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "TransTypeID", "")
            '    End If
            '    .ProjectID = GetProjectID() ' D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "ProjectID", "")
            'End With

            Dim clsOptions As New Lemon3.clsOptions(D25) 'ID 89301 01/08/2016
            With D25Options
                'Gọi hàm GetValue với 2 tham số: để lấy giá trị có field name trong table và registry GIỐNG nhau và ở nhánh Options
                .DefaultDivisionID = L3String(clsOptions.GetValue("DefaultDivisionID", ""))
                .MessageAskBeforeSave = L3Bool(clsOptions.GetValue("MessageAskBeforeSave", True))
                .MessageWhenSaveOK = L3Bool(clsOptions.GetValue("MessageWhenSaveOK", True))
                .ViewFormPeriodWhenAppRun = L3Bool(clsOptions.GetValue("ViewFormPeriodWhenAppRun", False))
                .UseEnterAsTab = L3Bool(clsOptions.GetValue("UseEnterAsTab", False))
                .SaveLastRecent = L3Bool(clsOptions.GetValue("SaveLastRecent", False))
                .TransTypeID = L3String(clsOptions.GetValue("TransTypeID", ""))

                .ProjectID = GetProjectID()
            End With
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try

    End Sub
    Public Sub LoadSystems()
        Try
            gsFormatDateType = GetFormatDateType()
            With D25Systems
                Dim sSQL As String = "Select * From D25T0000 WITH(NOLOCK)"
                Dim dt As DataTable = ReturnDataTable(sSQL)
                If dt.Rows.Count > 0 Then

                    .DefaultDivisionID = dt.Rows(0).Item("DivisionID").ToString
                    .InterviewerDefault = dt.Rows(0).Item("InterviewerDefault").ToString
                    .IntPlaceDefault = dt.Rows(0).Item("IntPlaceDefault" & UnicodeJoin(gbUnicode)).ToString
                    .AutoCandidateID = L3Bool(dt.Rows(0).Item("AutoCandidateID"))
                    .AutoInterviewFileID = CBool(dt.Rows(0).Item("AutoInterviewFileID").ToString)
                    .IsUseAppRecruitProposal = GetIsUseAppRecruitProposal()

                    .LoadSystem = True
                Else
                    .DefaultDivisionID = ""
                    .InterviewerDefault = ""
                    .IntPlaceDefault = ""
                    .AutoCandidateID = False
                    .AbsentTypeAuto = False
                    .CandidateOutputOrder = 0
                    .CandidateSeparator = "/"
                    .AutoInterviewFileID = False
                    .LoadSystem = False
                End If
                Dim dtD09T0000 As DataTable = ReturndtD09T0000("IsUseBlock,FormatDateType")
                .FormatDateType = GetValueD09T0000(dtD09T0000, "FormatDateType")
                .IsUseBlock = L3Bool(GetValueD09T0000(dtD09T0000, "IsUseBlock"))
            End With
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub
    Public Function GetProjectID() As String
        Dim sSQL As String = ""
        sSQL = " -- Du an mac dinh theo User" & vbCrLf
        sSQL &= "SELECT  	ProjectID FROM	D09T0201 	T01  WITH(NOLOCK)" & vbCrLf
        sSQL &= "LEFT JOIN LEMONSYS..D00T0030 T02  WITH(NOLOCK) ON 	T01.EmployeeID = T02.HREmployeeID" & vbCrLf
        sSQL &= "WHERE 	UserID = " & SQLString(gsUserID)
        Return ReturnScalar(sSQL)
    End Function
    Private Function GetIsUseAppRecruitProposal() As Boolean
        Dim sSQL As String = "SELECT 	NumValue as IsUseAppRecruitProposal FROM D09T0009" & vbCrLf
        sSQL &= "WHERE	ModuleID = 'D25' AND TransTypeID	= 'RecruitmentRequest' AND FormID = 'D25F2000'"
        Return L3Bool(ReturnScalar(sSQL))
    End Function

    ''' <summary>
    ''' Load toàn bộ các thông số format cho biến D25Format
    ''' </summary>
    Public Sub LoadFormats()
        D25Format.DefaultNumber0 = "#,##0"
        D25Format.DefaultNumber1 = "#,##0.0"
        D25Format.DefaultNumber2 = "#,##0.00"
        D25Format.DefaultNumber4 = "#,##0.0000"
    End Sub

    ''' <summary>
    ''' Hỏi trước khi lưu tùy thuộc vào thiết lập ở phần Tùy chọn
    ''' </summary>
    Public Function AskSave() As DialogResult
        If D25Options.MessageAskBeforeSave Then
            Return D99C0008.MsgAskSave()
        Else
            Return DialogResult.Yes
        End If
    End Function

    ''' <summary>
    ''' Thông báo trước khi khóa phiếu
    ''' </summary>    
    Public Function AskLocked() As DialogResult
        If D25Options.MessageAskBeforeSave Then
            Return D99C0008.MsgAsk(rL3("MSG000002"), MessageBoxDefaultButton.Button2)
        Else
            Return DialogResult.Yes
        End If
    End Function

    ''' <summary>
    ''' Thông báo khi lưu thành công tùy theo phần thiết lập ở tùy chọn
    ''' </summary>
    Public Sub SaveOK()
        If D25Options.MessageWhenSaveOK Then D99C0008.MsgSaveOK()
    End Sub

    ''' <summary>
    ''' Thông báo không khóa được phiếu
    ''' </summary>
    Public Sub LockedNotOK()
        D99C0008.MsgL3(rl3("MSG000003"))
    End Sub

    Public Sub LoadInfoGeneral()
        If D25Systems.LoadSystem Then gsFormatDateType = D25Systems.FormatDateType : Exit Sub

        LoadOptions()
        LoadSystems()
        LoadFormats()
        LoadCustomFormat()
        gsFormatDateType = D25Systems.FormatDateType
    End Sub
End Module