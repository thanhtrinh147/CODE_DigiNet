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
    '''' <summary>
    '''' Khóa đơn vị
    '''' </summary>
    'Public LockDivisionID As Boolean
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
    '------------------------------------------------------------------------
    '  D25 Options here
    Public TransTypeID As String
    '------------------------------------------------------------------------
    ''' <summary>
    ''' Sử dụng Enter như phím Tab
    ''' </summary>
    Public UseEnterAsTab As Boolean
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
    ''' Thiết lập mã Thông báo tuyển dụng tự động
    ''' </summary>
    ''' <remarks></remarks>
    Public AutoRecInformationID As Boolean
    Public AutoInterviewFileID As Boolean

End Structure

''' <summary>
''' Khai báo structure cho phần định dạng format
''' </summary>
Public Structure StructureFormat
    Public DefaultNumber0 As String
    Public DefaultNumber2 As String
    Public D25FormatThreeZero As String
    ''' <summary>
    ''' format số lượng
    ''' </summary>
    Public OriginalQuantity As String
    ''' <summary>
    ''' Số làm tròn của số lượng
    ''' </summary>
    Public OriginalQuantityRound As Integer
    ''' <summary>
    ''' format số lượng quy đổi
    ''' </summary>
    Public ConvertedQuantity As String
    ''' <summary>
    ''' Số làm tròn của số lượng quy đổi
    ''' </summary>
    Public ConvertedQuantityRound As Integer
    ''' <summary>
    ''' format thành tiền
    ''' </summary>
    Public OriginalAmount As String
    ''' <summary>
    ''' Số làm tròn của thành tiền
    ''' </summary>
    Public OriginalAmountRound As Integer
    ''' <summary>
    ''' format thành tiền quy đổi
    ''' </summary>
    Public ConvertedAmount As String
    ''' <summary>
    ''' Số làm tròn của thành tiền quy đổi
    ''' </summary>
    Public ConvertedAmountRound As Integer
    ''' <summary>
    ''' format giảm giá
    ''' </summary>
    Public OriginalReduction As String
    ''' <summary>
    ''' Số làm tròn của giảm giá
    ''' </summary>
    Public OriginalReductionRound As Integer
    ''' <summary>
    ''' format giảm giá quy đổi
    ''' </summary>
    Public ConvertedReduction As String
    ''' <summary>
    ''' Số làm tròn của giảm giá quy đổi
    ''' </summary>
    Public ConvertedReductionRound As Integer
    ''' <summary>
    ''' format đơn giá
    ''' </summary>
    Public UnitPrice As String
    ''' <summary>
    ''' Số làm tròn của đơn giá
    ''' </summary>
    Public UnitPriceRound As Integer
    ''' <summary>
    ''' format tỷ giá
    ''' </summary>
    Public ExchangeRate As String
    ''' <summary>
    ''' Số làm tròn của tỷ giá
    ''' </summary>
    Public ExchangeRateRound As Integer
    ''' <summary>
    ''' Nguyên tệ gốc
    ''' </summary>
    Public BaseCurrencyID As String
    ''' <summary>
    ''' Dấu phân cách thập phân
    ''' </summary>
    Public DecimalSeperator As String
    ''' <summary>
    ''' Dấu phân cách hàng ngàn
    ''' </summary>
    Public ThousandSeperator As String
    '------------------------------------------------------------------------
    '  D25 Format here
    '------------------------------------------------------------------------
End Structure
#End Region

''' <summary>
''' Khai báo structure cho phần định dạng format theo chuẩn chung mới lấy từ D91P9300
''' </summary>
Public Structure StructureFormatNew
    'Public DefaultNumber2 As String

    ''' <summary>
    ''' format tỷ giá
    ''' </summary>
    Public ExchangeRate As String
    ''' <summary>
    ''' format nguyên tệ
    ''' </summary>
    Public DecimalPlaces As String

    ''' <summary>
    ''' format nguyên tệ ứng với mỗi loại tiền
    ''' </summary>
    Public MyOriginal As String

    ''' <summary>
    ''' format tiền quy đổi
    ''' </summary>
    Public D90_Converted As String
    ''' <summary>
    ''' format số lượng, số lượng QĐ: nhóm sản xuất (D06, D07, D12, D37); nhóm kinh doanh
    ''' </summary>
    Public D07_Quantity As String
    ''' <summary>
    ''' format đơn giá: nhóm sản xuất (D06, D07, D12, D37); nhóm kinh doanh
    ''' </summary>
    ''' <remarks></remarks>
    Public D07_UnitCost As String
    ''' <summary>
    ''' format số lượng, số lượng QĐ: nhóm sản xuất (D08, D20, D30, D31, D32, D33, D34, D35, D36)
    ''' </summary>
    ''' <remarks></remarks>
    Public D08_Quantity As String
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public D08_UnitCost As String
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public D08_Ratio As String
    ''' <summary>
    ''' format số lượng, số lượng QĐ: nhóm sản xuất (danh mục Bộ định mức D08, danh mục Cấu trúc sản phẩm D32)
    ''' </summary>
    ''' <remarks></remarks>
    Public BOMQty As String
    ''' <summary>
    ''' format đơn giá: nhóm sản xuất (danh mục Bộ định mức D08, danh mục Cấu trúc sản phẩm D32)
    ''' </summary>
    ''' <remarks></remarks>
    Public BOMPrice As String
    ''' <summary>
    ''' format thành tiền: nhóm sản xuất (danh mục Bộ định mức D08, danh mục Cấu trúc sản phẩm D32)
    ''' </summary>
    ''' <remarks></remarks>
    Public BOMAmt As String
    ''' <summary>
    ''' Format 2 số lẻ (không theo quy tắc nào)
    ''' </summary>
    ''' <remarks></remarks>
    Public DefaultNumber2 As String
    Public DefaultNumber4 As String
    Public DefaultNumber0 As String
End Structure


''' <summary>
''' Module liên quan đến các vấn đề về Tùy chọn, Thiết lập hệ thống, ...
''' </summary>
''' <remarks></remarks>
Module D25X0004

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
    Public D25Format As StructureFormatNew
    ''' <summary>
    ''' Load toàn bộ các thông số tùy chọn vào biến D25Options
    ''' </summary>
    Public Sub LoadOptions()
        If D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "MessageAskBeforeSave") = "" Then
            Dim LocalOptions As String = "Lemon3_D25"
            Dim Options As String = "Options"
            With D25Options
                .MessageAskBeforeSave = CType(GetSetting(LocalOptions, Options, "AskBeforeSave", "True"), Boolean)
                .MessageWhenSaveOK = CType(GetSetting(LocalOptions, Options, "MessageWhenSaveOK", "True"), Boolean)
                .UseEnterAsTab = CType(GetSetting(LocalOptions, Options, "EnterAsTab", "False"), Boolean)

                
                'Mới chỉ có ở .Net
                .DefaultDivisionID = ""
                .ViewFormPeriodWhenAppRun = False
                .SaveLastRecent = False
                .TransTypeID = ""
            End With

        Else
            With D25Options

                .DefaultDivisionID = D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "DefaultDivisionID", "")
                .MessageAskBeforeSave = Convert.ToBoolean(D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "MessageAskBeforeSave", "True"))
                .MessageWhenSaveOK = Convert.ToBoolean(D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "MessageWhenSaveOK", "True"))
                .ViewFormPeriodWhenAppRun = Convert.ToBoolean(D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", "False"))
                .UseEnterAsTab = Convert.ToBoolean(D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "UseEnterAsTab", "False"))
                .SaveLastRecent = Convert.ToBoolean(D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "SaveLastRecent", "False"))
                .TransTypeID = D99C0007.GetModulesSetting(D25, ModuleOption.lmOptions, "TransTypeID", "")
            End With
        End If
    End Sub

    ''Hàm mới load Tùy chọn
    'Public Sub LoadOptions_New()
    '    Dim sSQL As String = "Select * From D09T5550 Where UserID=" & SQLString(gsUserID)
    '    Dim dt As DataTable = ReturnDataTable(sSQL)
    '    If dt.Rows.Count > 0 Then
    '        Dim dr As DataRow = dt.Rows(0)
    '        D25Options.CodeTable = L3Bool(dr.Item("CodeTable"))
    '    Else
    '        D25Options.CodeTable = False
    '    End If

    '    dt.Dispose()
    'End Sub

    'Hàm mới load Tùy chọn
    Public Sub LoadOptions_Unicode()
        Dim sSQL As String = "Select * From D09T5550 WITH(NOLOCK)  Where UserID=" & SQLString(gsUserID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            gbUnicode = L3Bool(dr.Item("CodeTable"))
        Else
            gbUnicode = False
        End If
#If DEBUG Then
        gbUnicode = True
#End If
        dt.Dispose()
    End Sub

    ''' <summary>
    ''' Load toàn bộ các thống số thiết lập hệ thống vào biến D25Systems
    ''' </summary>
    Public Sub LoadSystems()
        gsFormatDateType = GetFormatDateType()
        Dim sSQL As String = "Select * From D25T0000 WITH(NOLOCK) "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With D25Systems
                .DefaultDivisionID = dt.Rows(0).Item("DivisionID").ToString
                '.LockedDivisionID = Convert.ToBoolean(dt.Rows(0).Item("DivisionLocked"))
                .InterviewerDefault = dt.Rows(0).Item("InterviewerDefault").ToString
                .IntPlaceDefault = dt.Rows(0).Item("IntPlaceDefault" & UnicodeJoin(gbUnicode)).ToString
                .AutoCandidateID = CBool(dt.Rows(0).Item("AutoCandidateID").ToString)
                .AutoRecInformationID = CBool(dt.Rows(0).Item("AutoRecInformationID").ToString)
                .AutoInterviewFileID = CBool(dt.Rows(0).Item("AutoInterviewFileID").ToString)
            End With
        Else
            With D25Systems
                .DefaultDivisionID = ""
                '.LockedDivisionID = False
                .InterviewerDefault = ""
                .IntPlaceDefault = ""
                .AutoCandidateID = False
                .AutoRecInformationID = False
                .AutoInterviewFileID = False
            End With
        End If
    End Sub

    '''' <summary>
    '''' Load toàn bộ các thông số format cho biến D25Format
    '''' </summary>
    'Public Sub LoadFormats()
    '    D25Format.DefaultNumber0 = "#,##0"
    '    D25Format.DefaultNumber2 = "#,##0.00"
    '    D25Format.D25FormatThreeZero = "#,##0.000"
    '    'd25format.
    'End Sub



    Public Sub LoadFormatsNew()
        Const Number2 As String = "#,##0.00"
        Const Number4 As String = "#,##0.0000"
        Dim sSQL As String = "Exec D91P9300 "
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)

        With D25Format
            If dt.Rows.Count > 0 Then
                .ExchangeRate = InsertFormat(dt.Rows(0).Item("ExchangeRateDecimals"))
                .DecimalPlaces = InsertFormat(dt.Rows(0).Item("DecimalPlaces"))
                .MyOriginal = .DecimalPlaces
                .D90_Converted = InsertFormat(dt.Rows(0).Item("D90_ConvertedDecimals"))
                .D07_Quantity = InsertFormat(dt.Rows(0).Item("D07_QuantityDecimals"))
                .D07_UnitCost = InsertFormat(dt.Rows(0).Item("D07_UnitCostDecimals"))
                .D08_Quantity = InsertFormat(dt.Rows(0).Item("D08_QuantityDecimals"))
                .D08_UnitCost = InsertFormat(dt.Rows(0).Item("D08_UnitCostDecimals"))
                .D08_Ratio = InsertFormat(dt.Rows(0).Item("D08_RatioDecimals"))
                .BOMQty = InsertFormat(dt.Rows(0).Item("BOMQtyDecimals"))
                .BOMPrice = InsertFormat(dt.Rows(0).Item("BOMPriceDecimals"))
                .BOMAmt = InsertFormat(dt.Rows(0).Item("BOMAmtDecimals"))
            Else
                .ExchangeRate = Number2
                .D90_Converted = Number2
                .D07_Quantity = Number2
                .D07_UnitCost = Number2
                .D08_Quantity = Number2
                .D08_UnitCost = Number2
                .D08_Ratio = Number2
                .BOMQty = Number2
                .BOMPrice = Number2
                .BOMAmt = Number2
            End If
            .DefaultNumber0 = "#,##0"
            .DefaultNumber2 = Number2
            .DefaultNumber4 = Number4
        End With
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
            Return D99C0008.Msg(rl3("Ban_co_muon_khoa_phieu_nay_khong1"), rl3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
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
    ''' Thông báo sau khi khóa phiếu thành công
    ''' </summary>
    Public Sub LockedOK()
        If D25Options.MessageWhenSaveOK Then
            'D99C0008.MsgL3(rl3("Khoa_phieu_thanh_cong"))
            D99C0008.MsgSaveOK()
        End If
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
        'D99C0008.MsgL3(rl3("Khong_khoa_duoc_phieu"))
        D99C0008.MsgSaveNotOK()
    End Sub

    ''' <summary>
    ''' Thông báo cột đã bị khóa khi nhấn phím nóng trên cột này để copy, xóa
    ''' </summary>
    Public Function MsgLockedColumn() As String
        Dim sMsg As String = ""
        sMsg = rl3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay") 'rl3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay")
        Return sMsg

    End Function
End Module
