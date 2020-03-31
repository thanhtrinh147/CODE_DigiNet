'''' <summary>
'''' Các vấn đề liên quan đến Thông tin hệ thống và Tùy chọn
'''' </summary>
'''' 
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
    ''' Hỏi trước khi xóa
    ''' </summary>
    Public MessageAskBeforeDelete As Boolean
    ''' <summary>
    ''' Hỏi trước khi sửa
    ''' </summary>
    Public MessageAskBeforeEdit As Boolean
    ''' <summary>
    ''' Thông báo khi lưu thành công
    ''' </summary>
    Public MessageWhenSaveOK As Boolean
    ''' <summary>
    ''' Thông báo khi nhập xuất dữ liệu thành công
    ''' </summary>
    Public MessageWhenImportExportDataOK As Boolean
    ''' <summary>
    ''' Thông báo khi kế thừa thành công
    ''' </summary>
    Public MessageWhenInheritOK As Boolean
    ''' <summary>
    ''' Hiển thị form chọn kỳ kế toán khi chạy chương trình
    ''' </summary>
    Public ViewFormPeriodWhenAppRun As Boolean
    ''' <summary>
    ''' Hiển thị đơn vị tính
    ''' </summary>
    Public ViewUnitID As Boolean
    ''' <summary>
    ''' Hiển thị đơn vị tính gốc
    ''' </summary>
    Public ViewBaseUnitID As Boolean
    ''' <summary>
    ''' Hiển thị số lương quy đổi
    ''' </summary>
    Public ViewConvertedQuantity As Boolean
    ''' <summary>
    ''' Hiển thị thành tiền quy đổi
    ''' </summary>
    Public ViewConvertedAmount As Boolean
    ''' <summary>
    ''' Hiển thị số phiếu của riêng tôi
    ''' </summary>
    Public ViewMyInvoice As Boolean
    ''' <summary>
    ''' Cho phép sửa số tiền quy đổi
    ''' </summary>
    Public AllowEditConvertedAmount As Boolean
    ''' <summary>
    ''' Cho phép sửa số lượng quy đổi
    ''' </summary>
    Public AllowEditConvertedQuantity As Boolean
    ''' <summary>
    ''' Cho phép nhập số âm
    ''' </summary>
    Public AllowEnterNumberNegative As Boolean
    ''' <summary>
    ''' Lưu giá trị gần nhất
    ''' </summary>
    Public SaveLastRecent As Boolean
    ''' <summary>
    ''' Lưu loại đối tượng gần nhất
    ''' </summary>
    Public SaveLastRecentObjectTypeID As Boolean
    ''' <summary>
    ''' Lưu đối tượng gần nhất
    ''' </summary>
    Public SaveLastRecentObjectID As Boolean
    ''' <summary>
    ''' Lưu diễn giải gần nhất
    ''' </summary>
    Public SaveLastRecentDescription As Boolean
    ''' <summary>
    ''' Lưu mã kho gần nhất
    ''' </summary>
    Public SaveLastRecentWareHouseID As Boolean
    ''' <summary>
    ''' Lưu đơn vị tính mặc định
    ''' </summary>
    Public DefaultDivisionID As String
    ''' <summary>
    ''' Mã kho mặc định
    ''' </summary>
    Public DefaultWareHouseID As String
    ''' <summary>
    ''' Tài khoản mặc định
    ''' </summary>
    Public DefaultAccountID As String
    ''' <summary>
    ''' Tài khoản nợ mặc định
    ''' </summary>
    Public DefaultCreditAccountID As String
    ''' <summary>
    ''' Tài khoản có mặc định
    ''' </summary>
    Public DefaultDebitAccountID As String
    ''' <summary>
    ''' Nhóm thuế mặc định
    ''' </summary>
    Public DefaultVATGroupID As String
    ''' <summary>
    ''' Khóa đơn vị
    ''' </summary>
    Public LockDivisionID As Boolean
    ''' <summary>
    ''' Khóa thành tiền quy đổi
    ''' </summary>
    Public LockConvertedAmount As Boolean
    ''' <summary>
    ''' Làm tròn thành tiền quy đổi
    ''' </summary>
    Public RoundConvertedAmount As Boolean
    ''' <summary>
    ''' Hiển thị tên đơn vị tính
    ''' </summary>
    Public ViewUnitName As Boolean
    ''' <summary>
    ''' Hiển thị sơ đồ quy trình
    ''' </summary>
    Public ShowDiagram As Boolean
    ''' <summary>
    ''' Hiển thị màn hình đường dẫn báo cáo
    ''' </summary>
    Public ShowReportPath As Boolean
    ''' <summary>
    ''' Ngôn ngữ báo cáo
    ''' </summary>
    Public ReportLanguage As Byte
    '------------------------------------------------------------------------
    '  D13 Options here
    '   Public CodeTable As Boolean
    '------------------------------------------------------------------------
End Structure

''' <summary>
''' Khai báo structure cho phần Thiết lập hệ thống
''' </summary>
Public Structure StructureSystem
    ''' <summary>
    ''' Đơn vị mặc định
    ''' </summary>
    Public DefaultDivisionID As String
    ''' <summary>
    ''' Nguyên tệ mặc định
    ''' </summary>
    Public DefaultCurrencyID As String
    ''' <summary>
    ''' Tài khoản mặc định
    ''' </summary>
    Public DefaultAccountID As String
    ''' <summary>
    ''' Loại chứng từ mặc định
    ''' </summary>
    Public DefaultVoucherTypeID As String
    ''' <summary>
    ''' Tài khoản nợ mặc định
    ''' </summary>
    Public DefaultCreditAccountID As String
    ''' <summary>
    ''' Tài khoản có mặc định
    ''' </summary>
    Public DefaultDebitAccountID As String
    ''' <summary>
    ''' Khóa đơn vị
    ''' </summary>
    Public LockedDivisionID As Boolean
    '------------------------------------------------------------------------
    '  D13 Systems here
    ' update 21/8/2012 incident 50602
    ''' <summary>
    ''' Dùng cho Sử dụng mã phân tích tiền lương
    ''' </summary>
    Public IsUsedPAna As Boolean
    '------------------------------------------------------------------------
End Structure

''' <summary>
''' Khai báo structure cho phần định dạng format
''' </summary>
Public Structure StructureFormat
    '  D13 Format here
    ''' <summary>
    ''' Theo hằng số bất kỳ
    ''' </summary>
    ''' <remarks></remarks>
    Public DefaultNumber2 As String
    ''' <summary>
    ''' Format các số kiểu int (không lấy số thập phân)
    ''' </summary>
    Public DefaultNumber0 As String
    '------------------------------------------------------------------------

End Structure

#End Region

Module D13X0004
    ''' <summary>
    ''' Lưu trữ các thiết lập tùy chọn
    ''' </summary>
    Public D13Options As StructureOption
    ''' <summary>
    ''' Lưu trữ các thiết lập Thông tin hệ thống
    ''' </summary>
    Public D13Systems As StructureSystem
    ''' <summary>
    ''' Load toàn bộ các thông số tùy chọn vào biến D13Options
    ''' </summary>
    Public Sub LoadOptions()
        With D13Options
            If D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "DefaultDivisionID") = "" Then ' Lấy đường dẫn VB6
                Dim D13LocalOptions As String = "Lemon3_D13"
                Dim Options As String = "Options"
                .DefaultDivisionID = GetSetting(D13LocalOptions, Options, "DefaultDivisionID", "")
            Else 'Lấy đường dẫn VBNET
                .DefaultDivisionID = D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "DefaultDivisionID", "")
            End If

            If D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "MessageAskBeforeSave") = "" Then ' Lấy đường dẫn VB6
                Dim D13LocalOptions As String = "Lemon3_D13"
                Dim Options As String = "Options"
                .MessageAskBeforeSave = CType(GetSetting(D13LocalOptions, Options, "AskBeforeSave", "True"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .MessageAskBeforeSave = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "MessageAskBeforeSave", "True"))
            End If

            If D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "MessageWhenSaveOK") = "" Then ' Lấy đường dẫn VB6
                Dim D13LocalOptions As String = "Lemon3_D13"
                Dim Options As String = "Options"
                .MessageWhenSaveOK = CType(GetSetting(D13LocalOptions, Options, "MessageWhenSaveOK", "True"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .MessageWhenSaveOK = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "MessageWhenSaveOK", "True"))
            End If

            If D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun") = "" Then ' Lấy đường dẫn VB6
                Dim D13LocalOptions As String = "Lemon3_D13"
                Dim Options As String = "Options"
                .ViewFormPeriodWhenAppRun = CType(GetSetting(D13LocalOptions, Options, "NotShowPeriod", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .ViewFormPeriodWhenAppRun = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", "False"))
            End If

            If D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ShowDiagram") = "" Then ' Lấy đường dẫn VB6
                Dim D13LocalOptions As String = "Lemon3_D13"
                Dim Options As String = "Options"
                .ShowDiagram = CType(GetSetting(D13LocalOptions, Options, "ShowDiagram", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .ShowDiagram = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ShowDiagram", "False"))
            End If

            Dim Dxx As String = "D" & PARA_ModuleID 'PARA_ModuleID: lấy giá trị tại hàm GetAllParameter() : PARA_ModuleID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ModuleID", xx)
            .ShowReportPath = CType(D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
            .ReportLanguage = CType(D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)

        End With

        'LoadOptions_New()
    End Sub

    ''' <summary>
    ''' Load toàn bộ các thống số thiết lập hệ thống vào biến D13Systems
    ''' </summary>
    Public Sub LoadSystems()
        Dim sSQL As String = "Select * From D13T0000  WITH(NOLOCK) "
gsFormatDateType = GetFormatDateType()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With D13Systems
                .DefaultDivisionID = dt.Rows(0).Item("DivisionID").ToString
                .LockedDivisionID = Convert.ToBoolean(dt.Rows(0).Item("DivisionLocked"))
                .IsUsedPAna = L3Bool(dt.Rows(0).Item("IsUsedPAna").ToString)
            End With
        Else
            With D13Systems
                .DefaultDivisionID = ""
                .LockedDivisionID = False
                .IsUsedPAna = False
            End With
        End If
    End Sub

    ''' <summary>
    ''' Hỏi trước khi lưu tùy thuộc vào thiết lập ở phần Tùy chọn
    ''' </summary>
    Public Function AskSave() As DialogResult
        If D13Options.MessageAskBeforeSave Then
            Return D99C0008.MsgAskSave()
        Else
            Return DialogResult.Yes
        End If
    End Function

    ''' <summary>
    ''' Thông báo trước khi khóa phiếu
    ''' </summary>    
    Public Function AskLocked() As DialogResult
        If D13Options.MessageAskBeforeSave Then
            Return D99C0008.Msg(rl3("MSG000002"), rl3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        Else
            Return DialogResult.Yes
        End If
    End Function

    ''' <summary>
    ''' Thông báo khi lưu thành công tùy theo phần thiết lập ở tùy chọn
    ''' </summary>
    Public Sub SaveOK()
        If D13Options.MessageWhenSaveOK Then D99C0008.MsgSaveOK()
    End Sub

    ''' <summary>
    ''' Thông báo sau khi khóa phiếu thành công
    ''' </summary>
    Public Sub LockedOK()
        If D13Options.MessageWhenSaveOK Then D99C0008.MsgSaveOK()
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

    ''' <summary>
    ''' Kiểm tra thiết lập Audit
    ''' </summary>
    ''' <param name="sWhere">Chuỗi điều kiện lấy audit</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckAudit(ByVal sWhere As String) As Boolean
        Dim sSQL As String = ""
        sSQL &= "Select Audit From D91T9200  WITH(NOLOCK) Where AuditCode = " & SQLString(sWhere)
gsFormatDateType = GetFormatDateType()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Function
        If Convert.ToInt16(dt.Rows(0).Item("Audit")) = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9106
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 06/03/2007 09:59:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD91P9106(ByVal sAuditCode As String, ByVal sModuleID As String, ByVal sEventID As String, ByVal sDesc1 As String, ByVal sDesc2 As String, ByVal sDesc3 As String, ByVal sDesc4 As String, ByVal sDesc5 As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9106 "
        sSQL &= SQLDateSave(Date.Today) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sModuleID) & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL
        Return sSQL
    End Function

End Module
