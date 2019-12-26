#Region "Khai báo Structure"

''' <summary>
''' Khai báo Structure cho phần Tùy chọn của Module
''' </summary>
''' 

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
    Public ViewMyVoucher As Boolean
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
    Public SaveLastRecentsObjectTypeID As String
    ''' <summary>
    ''' Lưu đối tượng gần nhất
    ''' </summary>
    Public SaveLastRecentObjectID As Boolean
    Public SaveLastRecentsObjectID As String
    ''' <summary>
    ''' Lưu diễn giải gần nhất
    ''' </summary>
    Public SaveLastRecentDescription As Boolean
    Public SaveLastRecentsDescription As String
    ''' <summary>
    ''' Lưu mã kho gần nhất
    ''' </summary>
    Public SaveLastRecentWareHouseID As Boolean
    Public SaveLastRecentsWareHouseID As String
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
    '------------------------------------------------------------------------
    '  D45 Options here
    '------------------------------------------------------------------------
    ''' <summary>
    ''' Sử dụng phím Enter như phím Tab
    ''' </summary>
    Public UseEnterAsTab As Boolean
    ''' <summary>
    ''' Truy cap chung tu cua nguoi khac
    ''' </summary>
    Public PerD45F5700 As Integer
    ''' <summary>
    ''' Hiển thị màn hình đường dẫn báo cáo
    ''' </summary>
    Public ShowReportPath As Boolean
    ''' <summary>
    ''' Người lập phiếu
    ''' </summary>
    ''' <remarks></remarks>
    Public SaveLastRecentEmployeeID As Boolean
    Public SaveLastRecentsEmployeeID As String
    ''' <summary>
    ''' Loại hàng tồn kho
    ''' </summary>
    ''' <remarks></remarks>
    Public SaveLastRecentInventoryType As Boolean
    Public SaveLastRecentsInventoryType As String
    ''' <summary>
    ''' Lô hàng
    ''' </summary>
    ''' <remarks></remarks>
    Public SaveLastRecentLocationID As Boolean
    Public SaveLastRecentsLocationID As String

    Public ReportLanguage As Byte
    'Tìm kiếm trước khi hiển thị Danh mục hàng tồn kho
    Public FindBeforeShowingInventoryList As Boolean
    'Mặc định lấy tên hàng làm diễn giải trên lưới
    Public DefaultDescriptionFromItemName As Boolean
    'Tính năng áp giá
    Public PriceImposingFunction As Boolean
    'Giá xuất kho sau khi giải trừ
    Public IssueCostAfterMatching As Boolean
    'Tổng cộng cho cột số lượng
    Public TotalQuantity As Boolean
    'Chọn mẫu báo cáo khi in phiếu nhập, xuất
    Public SelectReportFormatWhenPrintingStockVoucher As Boolean
    'Sử dụng mặt hàng theo kho mặc định
    Public UseDefaultWarehouse As Boolean
    'Thông tin trên màn hình Kế thừa
    Public InformationOfCopyScreen As Boolean
    'Thông tin khi nhập tiếp mã hàng
    Public InformationOfNextNewItem As Boolean
    'Bỏ qua cột đơn vị tính sau khi chọn mã hàng
    Public SkipUnitColumnAfterSelectingProductCode As Boolean
    'Mặc định vị trí nhập theo vị trí xuất gần nhất
    Public DefaultReceiptLocation As Boolean
    'Mặc định vị trí xuất theo vị trí nhập gần nhất
    Public DefaultDeliveryLocation As Boolean
End Structure

'''' <summary>
'''' Thông tin Tùy chọn
'''' </summary>
'''' <remarks></remarks>
'Public Structure StructureFormat
'    Public Amount As String
'    Public UnitPrice As String
'    Public Quantity As String
'    Public D08_Amount As String
'    Public D08_UnitPrice As String
'    Public D08_Quantity As String
'    Public DefaultNumber2 As String
'    Public DefaultNumber0 As String
'    Public UnitPriceDecimalPlaces As String
'    Public D90_Amount As String
'    Public ExchangeRateDecimals As String
'    Public BaseCurrencyID As String

'    Public Amount_Int As Integer
'    Public UnitPrice_Int As Integer
'    Public Quantity_Int As Integer
'    Public UnitPriceDecimalPlaces_Int As Integer
'End Structure

Public Structure StructureFormatD91V0010
    Public UnitPriceDecimals As Integer
    Public OriginalDecimal As Integer
    Public ConvertedDecimal As Integer
End Structure

Public Structure StructureCustomFormat
    Public D45_QuantityDecimals As String
End Structure
''' <summary>
''' Khai báo structure cho phần định dạng format theo chuẩn chung mới lấy từ D91P9300
''' </summary>
Public Structure StructureFormatNew
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
    ''' format số lượng, số lượng QĐ: nhóm sản xuất (D06, D45, D12, D37); nhóm kinh doanh
    ''' </summary>
    Public D45_Quantity As String
    ''' <summary>
    ''' format đơn giá: nhóm sản xuất (D06, D45, D12, D37); nhóm kinh doanh
    ''' </summary>
    ''' <remarks></remarks>
    Public D45_UnitCost As String


    ''' <summary>
    ''' format tiền quy đổi
    ''' </summary>
    Public D90_Converted_Int As Integer
    ''' <summary>
    ''' format số lượng, số lượng QĐ: nhóm sản xuất (D06, D45, D12, D37); nhóm kinh doanh
    ''' </summary>
    Public D45_Quantity_Int As Integer
    ''' <summary>
    ''' format đơn giá: nhóm sản xuất (D06, D45, D12, D37); nhóm kinh doanh
    ''' </summary>
    ''' <remarks></remarks>
    Public D45_UnitCost_Int As Integer

    ''' <summary>
    ''' format số lượng, số lượng QĐ: nhóm sản xuất (D08, D20, D30, D45, D32, D33, D45, D35, D36)
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
End Structure


''' <summary>
''' Khai báo structure cho phần Thiết lập hệ thống
''' </summary>
Public Structure StructureSystem
    ''' <summary>
    ''' Mã hàng đã chọn vị trí đầy đủ
    ''' </summary>
    ''' <remarks></remarks>
    Public CompletedLocationColor As Integer
    ''' <summary>
    ''' Mã hàng đã chọn vị trí còn dỡ dang
    ''' </summary>
    ''' <remarks></remarks>
    Public InProgressLocationColor As Integer
    ''' <summary>
    ''' Mã hàng chưa chọn vị trí
    ''' </summary>
    ''' <remarks></remarks>
    Public NotInProgressLocationColor As Integer
    ''' <summary>
    ''' Khóa không cho sửa SLQĐ
    ''' </summary>
    ''' <remarks></remarks>
    Public ConvertedQuantityLocked As Boolean
    ''' <summary>
    ''' Sử dụng nhóm kho
    ''' </summary>
    ''' <remarks></remarks>
    Public UseGroupWH As Boolean
    Public InventoryLength As Byte
End Structure
#End Region

''' <summary>
''' Các vấn đề liên quan đến Thông tin hệ thống và Tùy chọn
''' </summary>
Module D45X0004
    ''' <summary>
    ''' Form Main của Module D22
    ''' </summary>
    Public D45Options As StructureOption
    ''' <summary>
    ''' Lưu trữ các thiết lập Thông tin hệ thống
    ''' </summary>
    Public D45Systems As StructureSystem
    '''' <summary>
    '''' Lưu trữ các thiết lập format
    '''' </summary>
    'Public D45Format As StructureFormat

    Public D45FormatNew As StructureFormatNew
    Public D45CustomFormat As StructureCustomFormat

    Public D45FormatD91V0010 As StructureFormatD91V0010

    Public Sub LoadOptions()
        Dim D45LocalOptionsLocations As String = "Lemon3_D45"
        With D45Options
            .DefaultDivisionID = D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DefaultDivisionID", "")
            .LockDivisionID = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "LockDivisionID", "False"))
            .PerD45F5700 = Convert.ToInt32(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "PerD45F5700", "0"))
            ' .ShowReportPath = CType(D99C0007.GetModulesSetting("D45", ModuleOption.lmOptions, "DisabledPathReport", "False", CodeOption.lmUncode), Boolean)  'Kh¤ng hiÓn thÜ mªn hØnh bÀo cÀo lÇn sau
            'Chuẩn hóa :Lấy Tùy
            Dim Dxx As String = "D" & PARA_ModuleID 'PARA_ModuleID: lấy giá trị tại hàm GetAllParameter() : PARA_ModuleID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ModuleID", xx)
            If D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ShowReportPath", "") = "" Then
                .ShowReportPath = CType(D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "DisabledPathReport", "True", CodeOption.lmUncode), Boolean)  'Kh¤ng hiÓn thÜ mªn hØnh bÀo cÀo lÇn sau
                D99C0007.SaveModulesSetting(Dxx, ModuleOption.lmOptions, "ShowReportPath", .ShowReportPath)
            Else
                .ShowReportPath = CType(D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
            End If
            If D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ReportLanguage", "") = "" Then
                .ReportLanguage = CType(D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "LanguageReport", "0"), Byte)
                D99C0007.SaveModulesSetting(Dxx, ModuleOption.lmOptions, "ReportLanguage", .ReportLanguage)
            Else
                .ReportLanguage = CType(D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "MessageAskBeforeSave") = "" Then ' Lấy đường dẫn VB6
                .MessageAskBeforeSave = CType(GetSetting(D45LocalOptionsLocations, "Options", "AskBeforeSave", "True"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .MessageAskBeforeSave = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "MessageAskBeforeSave", "True"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "MessageWhenSaveOK") = "" Then ' Lấy đường dẫn VB6
                .MessageWhenSaveOK = CType(GetSetting(D45LocalOptionsLocations, "Options", "MessageWhenSaveOK", "True"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .MessageWhenSaveOK = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "MessageWhenSaveOK", "True"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun") = "" Then ' Lấy đường dẫn VB6
                .ViewFormPeriodWhenAppRun = CType(GetSetting(D45LocalOptionsLocations, "Options", "HIENTHIMANHINHCKKT", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .ViewFormPeriodWhenAppRun = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", "False"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "EnterAsTabKey") = "" Then ' Lấy đường dẫn VB6
                .UseEnterAsTab = CType(GetSetting(D45LocalOptionsLocations, "Options", "EnterAsTabKey", "True"), Boolean) 'Sõ dóng phÛm Enter nh§ phÛm Tab
            Else 'Lấy đường dẫn VBNET
                .UseEnterAsTab = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "EnterAsTabKey", "True"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage") = "" Then ' Lấy đường dẫn VB6
                .ReportLanguage = CType(GetSetting(D45LocalOptionsLocations, "Options", "ReportLanguage", "0"), Byte)
            Else 'Lấy đường dẫn VBNET
                .ReportLanguage = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "FindBeforeShowingInventoryList") = "" Then ' Lấy đường dẫn VB6
                .FindBeforeShowingInventoryList = CType(GetSetting(D45LocalOptionsLocations, "Options", "FilterBeforeShow", "True"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .FindBeforeShowingInventoryList = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "FindBeforeShowingInventoryList", "True"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DefaultDescriptionFromItemName") = "" Then ' Lấy đường dẫn VB6
                .DefaultDescriptionFromItemName = CType(GetSetting(D45LocalOptionsLocations, "Options", "IsDefaultDescription", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .DefaultDescriptionFromItemName = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DefaultDescriptionFromItemName", "False"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "PriceImposingFunction") = "" Then ' Lấy đường dẫn VB6
                .PriceImposingFunction = CType(GetSetting(D45LocalOptionsLocations, "Options", "APGIA", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .PriceImposingFunction = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "PriceImposingFunction", "False"), Boolean)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "UseDefaultWarehouse") = "" Then ' Lấy đường dẫn VB6
                .UseDefaultWarehouse = CType(GetSetting(D45LocalOptionsLocations, "Options", "IsDefaultWareHouse", "False"), Boolean) 'Sõ dóng kho mÆc ¢Ünh
            Else 'Lấy đường dẫn VBNET
                .UseDefaultWarehouse = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "UseDefaultWarehouse", "False"), Boolean)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "SkipUnitColumnAfterSelectingProductCode") = "" Then ' Lấy đường dẫn VB6
                .SkipUnitColumnAfterSelectingProductCode = CType(GetSetting(D45LocalOptionsLocations, "Options", "BOQUADONVITINH", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .SkipUnitColumnAfterSelectingProductCode = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "SkipUnitColumnAfterSelectingProductCode", "False"), Boolean)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "SaveRecentValues") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecent = CType(GetSetting(D45LocalOptionsLocations, "Recent", "SaveRecentValues", "False"), Boolean) 'Sõ dóng kho mÆc ¢Ünh
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecent = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "SaveRecentValues", "False"), Boolean)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "bEmployeeID") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecentEmployeeID = CType(GetSetting(D45LocalOptionsLocations, "Recent", "Employee", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecentEmployeeID = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bEmployeeID", "False"), Boolean)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "sEmployeeID") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecentsEmployeeID = GetSetting(D45LocalOptionsLocations, "Recent", "strEmployeeID", "")
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecentsEmployeeID = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sEmployeeID", "")
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "bInventoryType") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecentInventoryType = CType(GetSetting(D45LocalOptionsLocations, "Recent", "InventoryType", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecentInventoryType = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bInventoryType", "False"))
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "sInventoryType") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecentsInventoryType = GetSetting(D45LocalOptionsLocations, "Recent", "strInventoryTypeID", "")
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecentsInventoryType = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sInventoryType", "")
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "bObjectTypeID") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecentObjectTypeID = CType(GetSetting(D45LocalOptionsLocations, "Recent", "ObjectType", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecentObjectTypeID = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bObjectTypeID", "False"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "sObjectTypeID") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecentsObjectTypeID = GetSetting(D45LocalOptionsLocations, "Recent", "strObjectTypeID", "")
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecentsObjectTypeID = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sObjectTypeID", "")
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "bWareHouseID") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecentWareHouseID = CType(GetSetting(D45LocalOptionsLocations, "Recent", "WareHouse", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecentWareHouseID = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bWareHouseID", "False"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "sWareHouseID") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecentsWareHouseID = GetSetting(D45LocalOptionsLocations, "Recent", "strWareHouseID", "")
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecentsWareHouseID = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sWareHouseID", "")
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "bLocationID") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecentLocationID = CType(GetSetting(D45LocalOptionsLocations, "Recent", "Location", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecentLocationID = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bLocationID", "False"), Boolean)
            End If
            .SaveLastRecentsLocationID = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sLocationID", "")


            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "bDescription") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecentDescription = CType(GetSetting(D45LocalOptionsLocations, "Recent", "Description", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecentDescription = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bDescription", "False"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "sDescription") = "" Then ' Lấy đường dẫn VB6
                .SaveLastRecentsDescription = GetSetting(D45LocalOptionsLocations, "Recent", "strDescription", "")
            Else 'Lấy đường dẫn VBNET
                .SaveLastRecentsDescription = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sDescription", "")
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "InformationOfCopyScreen") = "" Then ' Lấy đường dẫn VB6
                .InformationOfCopyScreen = CType(GetSetting(D45LocalOptionsLocations, "Recent", "Inherite", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .InformationOfCopyScreen = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "InformationOfCopyScreen", "False"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "InformationOfNextNewItem") = "" Then ' Lấy đường dẫn VB6
                .InformationOfNextNewItem = CType(GetSetting(D45LocalOptionsLocations, "Recent", "UseInfoOfInventory", "False"), Boolean) 'Th¤ng tin khi NhËp tiÕp mº hªng
            Else 'Lấy đường dẫn VBNET
                .InformationOfNextNewItem = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "InformationOfNextNewItem", "False"), Boolean)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ViewMyVoucher") = "" Then ' Lấy đường dẫn VB6
                .ViewMyVoucher = CType(GetSetting(D45LocalOptionsLocations, "View", "ViewUserID", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .ViewMyVoucher = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ViewMyVoucher", "False"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "IssueCostAfterMatching") = "" Then ' Lấy đường dẫn VB6
                .IssueCostAfterMatching = CType(GetSetting(D45LocalOptionsLocations, "View", "ViewSalePrice", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .IssueCostAfterMatching = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "IssueCostAfterMatching", "False"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "TotalQuantity") = "" Then ' Lấy đường dẫn VB6
                .TotalQuantity = CType(GetSetting(D45LocalOptionsLocations, "View", "TotalQuantity", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .TotalQuantity = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "TotalQuantity", "False"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "SelectReportFormatWhenPrintingStockVoucher") = "" Then ' Lấy đường dẫn VB6
                .SelectReportFormatWhenPrintingStockVoucher = CType(GetSetting(D45LocalOptionsLocations, "View", "CheckPrintVoucher", "False"), Boolean)
            Else 'Lấy đường dẫn VBNET
                .SelectReportFormatWhenPrintingStockVoucher = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "SelectReportFormatWhenPrintingStockVoucher", "False"), Boolean)
            End If

            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DefaultDeliveryLocation") = "" Then ' Lấy đường dẫn VB6
                .DefaultDeliveryLocation = CType(GetSetting(D45LocalOptionsLocations, "Options", "IsDeliveryLocationDefault", "False"), Boolean) 'MÆc ¢Ünh vÜ trÛ xuÊt theo vÜ trÛ nhËp gÇn nhÊt
            Else 'Lấy đường dẫn VBNET
                .DefaultDeliveryLocation = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DefaultDeliveryLocation", "False"), Boolean)
            End If
            If D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DefaultReceiptLocation") = "" Then ' Lấy đường dẫn VB6
                .DefaultReceiptLocation = CType(GetSetting(D45LocalOptionsLocations, "Options", "IsReceiptLocationDefault", "False"), Boolean) 'MÆc ¢Ünh vÜ trÛ nhËp theo vÜ trÛ nhËp gÇn nhÊt
            Else 'Lấy đường dẫn VBNET
                .DefaultReceiptLocation = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "DefaultReceiptLocation", "False"), Boolean)
            End If
        End With
    End Sub

    'Public Sub LoadLastValues()
    '    With D45Options
    '        .SaveLastRecent = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "SaveRecentValues", "True"))

    '        .SaveLastRecentEmployeeID = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bEmployeeID", "True"))
    '        .SaveLastRecentsEmployeeID = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sEmployeeID", "")

    '        .SaveLastRecentInventoryType = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bInventoryType", "True"))
    '        .SaveLastRecentsInventoryType = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sInventoryType", "")

    '        .SaveLastRecentObjectTypeID = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bObjectTypeID", "True"))
    '        .SaveLastRecentsObjectTypeID = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sWObjectTypeID", "")

    '        .SaveLastRecentWareHouseID = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bWareHouseID", "True"))
    '        .SaveLastRecentsWareHouseID = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sWareHouseID", "")

    '        .SaveLastRecentLocationID = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bLocationID", "True"))
    '        .SaveLastRecentsLocationID = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sLocationID", "")

    '        .SaveLastRecentDescription = Convert.ToBoolean(D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "bDescription", "True"))
    '        .SaveLastRecentsDescription = D99C0007.GetModulesSetting(D45, ModuleOption.lmLastValues, "sDescription", "")
    '    End With
    'End Sub

    'Public Sub SaveLastValues()
    '    With D45Options
    '        D99C0007.SaveModulesSetting(D45, ModuleOption.lmLastValues, "sEmployeeID", .SaveLastRecentsEmployeeID)
    '        D99C0007.SaveModulesSetting(D45, ModuleOption.lmLastValues, "sInventoryType", .SaveLastRecentsInventoryType)
    '        D99C0007.SaveModulesSetting(D45, ModuleOption.lmLastValues, "sWObjectTypeID", .SaveLastRecentsObjectTypeID)
    '        D99C0007.SaveModulesSetting(D45, ModuleOption.lmLastValues, "sWareHouseID", .SaveLastRecentsWareHouseID)
    '        D99C0007.SaveModulesSetting(D45, ModuleOption.lmLastValues, "sLocationID", .SaveLastRecentsLocationID)
    '        D99C0007.SaveModulesSetting(D45, ModuleOption.lmLastValues, "sDescription", .SaveLastRecentsDescription)
    '    End With
    'End Sub

    '''' <summary>
    '''' Load toàn bộ các thông số format cho biến D45Format
    '''' </summary>
    'Public Sub LoadFormats()
    '    Dim sSQL As String
    '    Dim iAmount As Integer = 0, iQuantity As Integer = 0, iUnitPrice As Integer = 0, iUnitPriceDecimalPlaces As Integer = 0
    '    Dim iAmount_D08 As Integer = 0, iQuantity_D08 As Integer = 0, iUnitPrice_D08 As Integer = 0, iAmount_D90 As Integer = 0
    '    Dim iExchangeRateDecimals As Integer = 0
    '    'Format du lieu theo D45 
    '    'sSQL = "DECLARE @DecimalsPlace INT " & vbCrLf
    '    'sSQL &= "SET @DecimalsPlace=(SELECT MAX(ISNULL(DecimalPlaces,0)) " & vbCrLf
    '    'sSQL &= "FROM D91T0010 " & vbCrLf
    '    'sSQL &= "WHERE CurrencyID <> (SELECT TOP 1 BaseCurrencyID FROM D91T0025)) " & vbCrLf
    '    'sSQL &= "SELECT TOP 1 " & vbCrLf
    '    'sSQL &= "D91T0025.ExchangeRateDecimals, D91T0025.BaseCurrencyID, " & vbCrLf
    '    'sSQL &= "D91T0025.D45_ConvertedDecimals, " & vbCrLf
    '    'sSQL &= "D91T0025.D45_QuantityDecimals, " & vbCrLf
    '    'sSQL &= "D91T0025.D45_UnitCostDecimals, D91T0025.D08_ConvertedDecimals, D91T0025.D08_QuantityDecimals, D91T0025.D08_UnitCostDecimals, D91T0025.D90_ConvertedDecimals, " & vbCrLf
    '    'sSQL &= "D45_MaxOriginalDecimals=(CASE WHEN ISNULL(D91T0025.D45_ConvertedDecimals,0)>@DecimalsPlace " & vbCrLf
    '    'sSQL &= "THEN ISNULL(D91T0025.D45_ConvertedDecimals,0) ELSE @DecimalsPlace END) " & vbCrLf
    '    'sSQL &= "FROM D91T0025" & vbCrLf

    '    sSQL = "DECLARE @DecimalsPlace INT , @UnitPriceDecimalPlaces INT " & vbCrLf
    '    sSQL &= "SET @DecimalsPlace=" & vbCrLf
    '    sSQL &= "(" & vbCrLf
    '    sSQL &= "Select MAX(ISNULL(DecimalPlaces, 0))" & vbCrLf
    '    sSQL &= "FROM D91T0010" & vbCrLf
    '    sSQL &= "WHERE CurrencyID <> (SELECT TOP 1 BaseCurrencyID FROM D91T0025)" & vbCrLf
    '    sSQL &= ") " & vbCrLf
    '    sSQL &= "SET @UnitPriceDecimalPlaces = " & vbCrLf
    '    sSQL &= "(" & vbCrLf
    '    sSQL &= " Select MAX(ISNULL(UnitPriceDecimals, 0))" & vbCrLf
    '    sSQL &= " FROM D91T0010 " & vbCrLf
    '    sSQL &= "WHERE 	CurrencyID <> (SELECT TOP 1 BaseCurrencyID FROM D91T0025) " & vbCrLf
    '    sSQL &= ")" & vbCrLf
    '    sSQL &= "SELECT TOP 1 " & vbCrLf
    '    sSQL &= "D91T0025.ExchangeRateDecimals, D91T0025.BaseCurrencyID, " & vbCrLf
    '    sSQL &= "D91T0025.D45_ConvertedDecimals, " & vbCrLf
    '    sSQL &= "D91T0025.D45_QuantityDecimals,D91T0025.BaseCurrencyID, " & vbCrLf
    '    sSQL &= "D91T0025.D45_UnitCostDecimals, D91T0025.D08_ConvertedDecimals, D91T0025.D08_QuantityDecimals, D91T0025.D08_UnitCostDecimals, D91T0025.D90_ConvertedDecimals, " & vbCrLf
    '    sSQL &= "D45_MaxOriginalDecimals=(CASE WHEN ISNULL(D91T0025.D45_ConvertedDecimals,0)>@DecimalsPlace " & vbCrLf
    '    sSQL &= "THEN ISNULL(D91T0025.D45_ConvertedDecimals,0) ELSE ISNULL(@DecimalsPlace, D91T0025.D90_ConvertedDecimals) END)," & vbCrLf
    '    sSQL &= "UnitPriceDecimalPlaces = (CASE WHEN ISNULL(D91T0025.D45_UnitCostDecimals, 0) > @UnitPriceDecimalPlaces " & vbCrLf
    '    sSQL &= "THEN ISNULL(D91T0025.D45_UnitCostDecimals, 0) ELSE ISNULL(@UnitPriceDecimalPlaces, D91T0025.D45_UnitCostDecimals) END) " & vbCrLf
    '    sSQL &= " FROM D91T0025"
    '    Dim dt As DataTable = ReturnDataTable(sSQL)

    '    If dt.Rows.Count > 0 Then
    '        With dt.Rows(0)
    '            iQuantity = CByte(IIf(IsDBNull(.Item("D45_QuantityDecimals")), 0, .Item("D45_QuantityDecimals")))

    '            iUnitPrice = CByte(IIf(IsDBNull(.Item("D45_UnitCostDecimals")), 0, .Item("D45_UnitCostDecimals")))
    '            iAmount = CByte(IIf(IsDBNull(.Item("D45_ConvertedDecimals")), 0, .Item("D45_ConvertedDecimals")))


    '            iQuantity_D08 = CByte(IIf(IsDBNull(.Item("D08_QuantityDecimals")), 0, .Item("D08_QuantityDecimals")))
    '            iUnitPrice_D08 = CByte(IIf(IsDBNull(.Item("D08_UnitCostDecimals")), 0, .Item("D08_UnitCostDecimals")))
    '            iAmount_D08 = CByte(IIf(IsDBNull(.Item("D08_ConvertedDecimals")), 0, .Item("D08_ConvertedDecimals")))

    '            iAmount_D90 = CByte(IIf(IsDBNull(.Item("D90_ConvertedDecimals")), 0, .Item("D90_ConvertedDecimals")))
    '            iExchangeRateDecimals = CByte(IIf(IsDBNull(.Item("ExchangeRateDecimals")), 0, .Item("ExchangeRateDecimals")))
    '            iUnitPriceDecimalPlaces = CByte(IIf(IsDBNull(.Item("UnitPriceDecimalPlaces")), 0, .Item("UnitPriceDecimalPlaces")))

    '            D45Format.BaseCurrencyID = IIf(IsDBNull(.Item("BaseCurrencyID")), "", .Item("BaseCurrencyID")).ToString
    '        End With
    '    End If

    '    With D45Format
    '        .Quantity_Int = iQuantity
    '        .Amount_Int = iAmount
    '        .UnitPrice_Int = iUnitPrice
    '        .UnitPriceDecimalPlaces_Int = iUnitPriceDecimalPlaces

    '        .Quantity = "#,##0" & InsertZero(iQuantity)   ' Số lượng
    '        .UnitPrice = "#,##0" & InsertZero(iUnitPrice)   ' Đơn giá     
    '        .Amount = "#,##0" & InsertZero(iAmount)   ' Thành tiền quy đổi

    '        .D08_Quantity = "#,##0" & InsertZero(iQuantity_D08)   ' Số lượng
    '        .D08_UnitPrice = "#,##0" & InsertZero(iUnitPrice_D08)   ' Đơn giá     
    '        .D08_Amount = "#,##0" & InsertZero(iAmount_D08)   ' Thành tiền quy đổi
    '        .D90_Amount = "#,##0" & InsertZero(iAmount_D90)   ' Thành tiền
    '        .ExchangeRateDecimals = "#,##0" & InsertZero(iExchangeRateDecimals)
    '        .DefaultNumber2 = "#,##0.00"
    '        .DefaultNumber0 = "#,##0"
    '        .UnitPriceDecimalPlaces = "#,##0" & InsertZero(iUnitPriceDecimalPlaces)
    '    End With
    'End Sub

    ''' <summary>
    ''' Load toàn bộ các thông số format cho biến DxxFormat theo chuẩn chung mới lấy từ D91P9300
    ''' </summary>
    Public Sub LoadFormatsNew()
        Const Number2 As String = "#,##0.00"
        Dim sSQL As String = "Exec D91P9300 "
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        With D45FormatNew
            If dt.Rows.Count > 0 Then

                .D45_Quantity_Int = L3Int(dt.Rows(0).Item("D45_QuantityDecimals"))
                .D90_Converted_Int = L3Int(dt.Rows(0).Item("D90_ConvertedDecimals"))
                .D45_UnitCost_Int = L3Int(dt.Rows(0).Item("D45_UnitCostDecimals"))

                .ExchangeRate = InsertFormat(dt.Rows(0).Item("ExchangeRateDecimals"))
                .DecimalPlaces = InsertFormat(dt.Rows(0).Item("DecimalPlaces"))
                .MyOriginal = .DecimalPlaces
                .D90_Converted = InsertFormat(dt.Rows(0).Item("D90_ConvertedDecimals"))
                .D45_Quantity = InsertFormat(dt.Rows(0).Item("D45_QuantityDecimals"))
                .D45_UnitCost = InsertFormat(dt.Rows(0).Item("D45_UnitCostDecimals"))
                .D08_Quantity = InsertFormat(dt.Rows(0).Item("D08_QuantityDecimals"))
                .D08_UnitCost = InsertFormat(dt.Rows(0).Item("D08_UnitCostDecimals"))
                .D08_Ratio = InsertFormat(dt.Rows(0).Item("D08_RatioDecimals"))
                .BOMQty = InsertFormat(dt.Rows(0).Item("BOMQtyDecimals"))
                .BOMPrice = InsertFormat(dt.Rows(0).Item("BOMPriceDecimals"))
                .BOMAmt = InsertFormat(dt.Rows(0).Item("BOMAmtDecimals"))
            Else
                .ExchangeRate = Number2
                .D90_Converted = Number2
                .D45_Quantity = Number2
                .D45_UnitCost = Number2
                .D08_Quantity = Number2
                .D08_UnitCost = Number2
                .D08_Ratio = Number2
                .BOMQty = Number2
                .BOMPrice = Number2
                .BOMAmt = Number2
            End If

            .DefaultNumber2 = Number2
            With D45CustomFormat
                .D45_QuantityDecimals = "N" & dt.Rows(0).Item("D45_QuantityDecimals").ToString
            End With
        End With
    End Sub

    Public Function InsertFormat(ByVal ONumber As Object) As String
        Dim iNumber As Int16 = Convert.ToInt16(ONumber)
        Dim sRet As String = "#,##0"
        If iNumber = 0 Then
        Else
            sRet &= "." & Strings.StrDup(iNumber, "0")
        End If
        Return sRet
    End Function

    'Public Function GetOriginalDecimal(ByVal sCurrencyID As String) As String

    '    Dim sSQL As String
    '    sSQL = "Select OriginalDecimal From D91V0010 Where CurrencyID = " & SQLString(sCurrencyID)
    '    Dim dt As DataTable
    '    dt = ReturnDataTable(sSQL)
    '    If dt.Rows.Count > 0 Then
    '        Return InsertFormat(dt.Rows(0).Item("OriginalDecimal"))
    '    Else
    '        Return D45FormatNew.DecimalPlaces
    '    End If
    'End Function


    'Public Sub GetFormatD91V0010(ByVal _currencyID As String)
    '    Dim sSQL As String
    '    sSQL = "Select * From D91V0010 Where CurrencyID = " & SQLString(_currencyID)
    '    Dim dt As DataTable
    '    dt = ReturnDataTable(sSQL)
    '    With D45FormatD91V0010
    '        If dt.Rows.Count > 0 Then

    '            .UnitPriceDecimals = L3Int(dt.Rows(0).Item("UnitPriceDecimals"))
    '            .OriginalDecimal = L3Int(dt.Rows(0).Item("OriginalDecimal"))
    '            .ConvertedDecimal = L3Int(dt.Rows(0).Item("ConvertedDecimal"))

    '        Else
    '            .UnitPriceDecimals = 2
    '            .OriginalDecimal = 2
    '            .ConvertedDecimal = 2
    '        End If
    '    End With
    'End Sub



    ''' <summary>
    ''' Load toàn bộ các thống số thiết lập hệ thống vào biến D45Systems
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadSystems()
        Dim sSQL As String = "Select * From D45T0000 WITH(NOLOCK) "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        With D45Systems
            If dt.Rows.Count > 0 Then
                .CompletedLocationColor = ConvertColor(dt.Rows(0).Item("CompletedLocationColorNET").ToString) 'Mã hàng đã chọn vị trí đầy đủ
                .InProgressLocationColor = ConvertColor(dt.Rows(0).Item("InProgressLocationColorNET").ToString) 'Mã hàng đã chọn vị trí còn dỡ dang
                .NotInProgressLocationColor = ConvertColor(dt.Rows(0).Item("NotInProgressLocationColorNET").ToString) 'Mã hàng chưa được chọn vị trí
                .ConvertedQuantityLocked = Convert.ToBoolean(dt.Rows(0).Item("ConvertedQuantityLocked"))
                .UseGroupWH = Convert.ToBoolean(dt.Rows(0).Item("UseGroupWH"))
                .InventoryLength = Convert.ToByte(dt.Rows(0).Item("InventoryLength"))
            Else
                .CompletedLocationColor = 0
                .InProgressLocationColor = 0
                .NotInProgressLocationColor = 0
                .ConvertedQuantityLocked = False
                .UseGroupWH = False
                .InventoryLength = 0
            End If
        End With
        dt.Dispose()

        gclrCompletedLocationColor = Color.FromArgb(D45Systems.CompletedLocationColor)
        gclrInProgressLocationColor = Color.FromArgb(D45Systems.InProgressLocationColor)
        gclrNotInProgressLocationColor = Color.FromArgb(D45Systems.NotInProgressLocationColor)
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

    '''' <summary>
    '''' Thông báo trước khi xóa
    '''' </summary>    
    'Public Function AskDelete() As DialogResult
    '    If D45Options.MessageAskBeforeSave Then
    '        Return D99C0008.MsgAskDelete
    '    Else
    '        Return DialogResult.Yes
    '    End If
    'End Function

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
    ''' Message hỏi có chọn Yes, No
    ''' </summary>
    ''' <param name="sMessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AskMsg(ByVal sMessage As String) As DialogResult
        Return D99C0008.MsgAsk(sMessage, MessageBoxDefaultButton.Button2)
    End Function

    ''' <summary>
    ''' Thông báo khi lưu thành công tùy theo phần thiết lập ở tùy chọn
    ''' </summary>
    Public Sub SaveOK()
        If D45Options.MessageWhenSaveOK Then D99C0008.MsgSaveOK()
    End Sub

    '''' <summary>
    '''' Thông báo sau khi xóa thành công
    '''' </summary>
    'Public Sub DeleteOK()
    '    If D45Options.MessageWhenSaveOK Then D99C0008.MsgL3(rl3("MSG000008"))
    'End Sub

    ''' <summary>
    ''' Thông báo sau khi khóa phiếu thành công
    ''' </summary>
    Public Sub LockedOK()
        If D45Options.MessageWhenSaveOK Then D99C0008.MsgSaveOK() 'MsgL3(rl3("Khoa_phieu_thanh_cong"))
    End Sub

    '''' <summary>
    '''' Thông báo không lưu được dữ liệu
    '''' </summary>
    'Public Sub SaveNotOK()
    '    D99C0008.MsgSaveNotOK()
    'End Sub

    ''' <summary>
    ''' Thông báo không xóa được dữ liệu
    ''' </summary>
    Public Sub DeleteNotOK()
        D99C0008.MsgL3(rL3("Khong_xoa_duoc_du_lieu"))
    End Sub

    ''' <summary>
    ''' Thông báo không khóa được phiếu
    ''' </summary>
    Public Sub LockedNotOK()
        D99C0008.MsgSaveNotOK()
    End Sub

    '''' <summary>
    '''' Cèng Footer cho l§ìi
    '''' </summary>
    '''' <param name="ipCol">Cèt cÇn cèng Footer</param>
    '''' <param name="C1Grid">L§ìi cÇn thÓ hiÖn Footer</param>
    '''' <returns>Tång Footer cïa cèt</returns>
    'Public Function Sum(ByVal ipCol As Integer, ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As Double
    '    Dim lSum As Double = 0
    '    For i As Integer = 0 To C1Grid.RowCount - 1
    '        If C1Grid(i, ipCol) Is Nothing OrElse TypeOf (C1Grid(i, ipCol)) Is DBNull Then Continue For
    '        lSum += Convert.ToDouble(C1Grid(i, ipCol))
    '    Next
    '    Return lSum
    'End Function

    'Public Function GetPermisionPriceCol() As Integer
    '    Dim sSQL As String = "Select PermissionPriceCol From D45T0039"
    '    If ReturnScalar(sSQL) = "0" Then
    '        Return 1
    '    Else
    '        Dim iperD45F5600 As Integer = ReturnPermission("D45F5600")
    '        If iperD45F5600 > 0 Then Return 1
    '        Return 0
    '    End If
    'End Function

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLStoreD91P0010
    ''# Created User: 
    ''# Created Date: 19/04/2010 04:00:30
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: Lấy tỷ giá theo loại tiền
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD91P0010(ByVal _currencyID As String, ByVal _exDate As String) As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D91P0010 "
    '    sSQL &= SQLString(_currencyID) & COMMA 'CurrencyID, varchar[20], NOT NULL
    '    sSQL &= SQLDateSave(_exDate) 'ExDate, datetime, NOT NULL
    '    Return sSQL
    'End Function

    ''Lấy tỷ giá theo loại tiền và ngày
    'Public Function GetExchangeRate(ByVal CurrencyID As String, ByVal ExDate As String) As Double
    '    Dim dt As DataTable = ReturnDataTable(SQLStoreD91P0010(CurrencyID, ExDate))
    '    Dim dResult As Double = 1
    '    If dt.Rows.Count > 0 Then
    '        dResult = Number(dt.Rows(0).Item("ExchangeRate"))
    '    End If
    '    Return dResult
    '    dt.Dispose()
    'End Function

    '''' <summary>
    '''' Nhấn F7 trên lưới để copy ô trên xuống ô dưới cho nhiều cột có liên quan
    '''' </summary>
    '''' <param name="c1Grid"></param>
    '''' <param name="iColumns">Tập cột cần truyền vào, VD: Dim iColumns() As Integer = {COL_ObjectName, COL_ObjectAddress}</param>
    '''' <remarks>Nhấn F7 tại cột ObjectID thì gọi HotKeyF7 (tdbg, iColumns)</remarks>
    'Public Sub HotKeyF7_String(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iColumns() As String)
    '    Try
    '        If c1Grid.RowCount < 1 Then Exit Sub

    '        If c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns.Item(c1Grid.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then ' Số
    '            If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse Val(c1Grid(c1Grid.Row, c1Grid.Col).ToString) = 0 Then
    '                c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
    '                For Each i As String In iColumns
    '                    c1Grid.Columns(i).Text = c1Grid(c1Grid.Row - 1, i).ToString()
    '                Next
    '                c1Grid.UpdateData()
    '            End If
    '        Else ' Chuỗi hoặc Ngày
    '            If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDateShort OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDate Then
    '                c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
    '                For Each i As String In iColumns
    '                    c1Grid.Columns(i).Text = c1Grid(c1Grid.Row - 1, i).ToString()
    '                Next i
    '                c1Grid.UpdateData()
    '            End If
    '        End If

    '    Catch ex As Exception
    '        D99C0008.Msg("Lỗi HotKeyF7: " & ex.Message)
    '    End Try

    'End Sub

    'Public Sub HotKeyF8_String(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iColExclude() As String)
    '    Try
    '        If c1Grid.RowCount < 1 Then Exit Sub

    '        Dim bExclude As Boolean = False

    '        If c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns.Item(c1Grid.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then ' Số
    '            If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse Val(c1Grid(c1Grid.Row, c1Grid.Col).ToString) = 0 Then
    '                For i As Integer = c1Grid.Col To c1Grid.Columns.Count - 1
    '                    bExclude = False
    '                    '  For j As Integer = 0 To iColExclude.Length - 1
    '                    For Each j As String In iColExclude
    '                        If c1Grid.Columns(i).DataField = j Then
    '                            bExclude = True
    '                            Exit For
    '                        End If
    '                    Next j
    '                    If Not bExclude Then
    '                        c1Grid.Columns(i).Text = c1Grid(c1Grid.Row - 1, i).ToString()
    '                        c1Grid.UpdateData()
    '                    End If
    '                Next
    '            End If
    '        Else ' Chuỗi hoặc Ngày
    '            If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDateShort OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDate Then
    '                For i As Integer = c1Grid.Col To c1Grid.Columns.Count - 1
    '                    bExclude = False
    '                    'For j As Integer = 0 To iColExclude.Length - 1
    '                    '    If i = iColExclude(j) Then
    '                    For Each j As String In iColExclude
    '                        If c1Grid.Columns(i).DataField = j Then
    '                            bExclude = True
    '                            Exit For
    '                        End If
    '                    Next j
    '                    If Not bExclude Then
    '                        c1Grid.Columns(i).Text = c1Grid(c1Grid.Row - 1, i).ToString()
    '                        c1Grid.UpdateData()
    '                    End If
    '                Next
    '            End If
    '        End If

    '    Catch ex As Exception
    '        D99C0008.Msg("Lỗi HotKeyF8: " & ex.Message)
    '    End Try



    'End Sub

    ''KiÓm tra tr§ìc khi thøc hiÖn
    'Public Function CheckPeriod(ByVal sPeriod As String) As Boolean
    '    If sPeriod <> Format(giTranMonth, "00") & "/" & Format(giTranYear, "0000") Then
    '        D99C0008.MsgL3(rl3("Chung_tu_khong_thuoc_ky_ke_toan_nay_Ban_khong_duoc_phep_sua"))
    '        Return False
    '    End If
    '    Return True
    'End Function

    'Public Sub FooterSum_String(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iColumns() As String, Optional ByVal COL_OrderNo As String = "", Optional ByVal bUseFilterBar As Boolean = False)
    '    Dim dblSum(iColumns.Length) As Double
    '    If bUseFilterBar = False Then tdbg.UpdateData()

    '    For i As Integer = 0 To tdbg.RowCount - 1
    '        If COL_OrderNo <> "" Then tdbg(i, COL_OrderNo) = i + 1 'Có cột STT 
    '        For j As Integer = 0 To iColumns.Length - 1
    '            dblSum(j) += Number(tdbg(i, iColumns(j)))
    '        Next j
    '    Next i
    '    For j As Integer = 0 To iColumns.Length - 1
    '        If tdbg.Columns(iColumns(j)).NumberFormat Is Nothing Then Exit Sub
    '        tdbg.Columns(iColumns(j)).FooterText = Format(dblSum(j), tdbg.Columns(iColumns(j)).NumberFormat)
    '    Next
    'End Sub

    'Public Function ExecuteSQL_Message(ByVal strSQL As String) As Boolean
    '    Dim conn As New SqlConnection(gsConnectionString)
    '    Dim cmd As New SqlCommand(strSQL, conn)
    '    Dim trans As SqlTransaction = Nothing
    '    If Trim(strSQL) = "" Then Exit Function
    '    'If giAppMode = 0 Then
    '    Try
    '        conn.Open()
    '        trans = conn.BeginTransaction
    '        cmd.CommandTimeout = 0
    '        cmd.Transaction = trans
    '        cmd.ExecuteNonQuery()
    '        trans.Commit()
    '        conn.Close()
    '        Return True
    '    Catch ex As Exception
    '        trans.Rollback()
    '        conn.Close()
    '        Clipboard.Clear()
    '        Clipboard.SetText(strSQL)
    '        ' MsgErr(ex.Message)
    '        'D99C0008.MsgL3(ex.Message)
    '        MessageBox.Show(ex.Message, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '        'WriteLogFile(strSQL)
    '        Return False
    '    End Try

    'End Function


    'Public Sub SelectMDIQtyD45T0039(ByRef dOverMDIQty As Double, ByRef dModeOverMDIQty As Double)
    '    Dim sSQL As String = ""
    '    sSQL &= "Select OverMDIQty, ModeOverMDIQty" & vbCrLf
    '    sSQL &= "From D45T0039" & vbCrLf
    '    Dim dtTemp As DataTable = ReturnDataTable(sSQL)
    '    If dtTemp.Rows.Count > 0 Then
    '        dOverMDIQty = Number(dtTemp.Rows(0).Item("OverMDIQty"))
    '        dModeOverMDIQty = Number(dtTemp.Rows(0).Item("ModeOverMDIQty"))
    '    End If
    '    If dModeOverMDIQty = 0 Then dOverMDIQty = dOverMDIQty / 100
    'End Sub




    '#Region "Màn hình chọn đường dẫn báo cáo"
    '    ''' <summary>
    '    ''' Hiển thị màn hình chọn đường dẫn báo cáo
    '    ''' </summary>
    '    ''' <param name="_ReportTypeID">ReportTypeID</param>
    '    ''' <param name="_ReportID">Mẫu chuẩn</param>
    '    ''' <param name="_PathReportID">đường dẫn báo cáo chuẩn (Trả về)</param>
    '    ''' <param name="_TransTypeID">Báo cáo đặc thù theo loại nghiệp vụ (nếu có)</param>
    '    ''' <returns>Mẫu báo cáo cần In và đường dẫn báo cáo</returns>
    '    ''' <remarks></remarks>
    '    Public Function GetReportPath(ByVal _ReportTypeID As String, ByVal _ReportID As String, Optional ByRef _PathReportID As String = "", Optional ByVal _TransTypeID As String = "") As String
    '        LoadOptions()
    '        'Gán _pathReport theo Tùy chọn (không chứa đường dẫn)
    '        _PathReportID = IIf(D45Options.ReportLanguage = 0, "\XReports\", IIf(D45Options.ReportLanguage = 1, "\XReports\VE-XReports\", "\XReports\E-XReports\")).ToString

    '        'Hien thi duong man hinh duong dan
    '        If D45Options.ShowReportPath Then
    '            Dim frm As New D99F6666
    '            With frm
    '                .ModuleID = "07" '2 ký tự
    '                .ReportTypeID = _ReportTypeID
    '                ' .CustomReportID = _customReportID
    '                .ReportID = _ReportID
    '                .PathReportID = _PathReportID 'Đường dẫn báo cáo chuẩn
    '                .ShowDialog()
    '                _ReportID = .ReportID
    '                _PathReportID = .PathReportID
    '                .Dispose()
    '            End With
    '        Else 'Không hiển thị thì lấy theo Loại nghiệp vụ (nếu có)
    '            If _TransTypeID <> "" Then
    '                Dim _customizedReportID As String = ""
    '                GetReportIDByTranTypeID(_TransTypeID, _ReportID, _customizedReportID)
    '                If _customizedReportID <> "" Then
    '                    _PathReportID = PathCustomizedReport9
    '                    _ReportID = _customizedReportID
    '                End If
    '            End If
    '            'If _customReportID <> "" Then
    '            '    _PathReportID = "\XCustom\"
    '            '    _ReportID = _customReportID
    '            'End If
    '        End If
    '        _PathReportID = Application.StartupPath & _PathReportID & _ReportID & ".rpt"
    '        Return _ReportID
    '    End Function

    '    'Tùy thuộc từng module có biến lưu dưới Registry
    '    Public Sub SaveOptionReport(ByVal bChecked As Boolean)
    '        If PARA_ModuleID = D45 Then
    '            D99C0007.SaveModulesSetting("D45", ModuleOption.lmOptions, "DisabledPathReport", bChecked)
    '        Else
    '            PARA_ShowPathReport = bChecked
    '            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ShowPathReport", bChecked.ToString)
    '        End If
    '        D45Options.ShowReportPath = bChecked
    '    End Sub
    '#End Region

    '#Region "Màn hình chọn đường dẫn báo cáo"
    '    ''' <summary>
    '    ''' Gọi form D99F6666
    '    ''' </summary>
    '    ''' <param name="ReportTypeID">DxxFxxxx: load combo đặc thù</param>
    '    ''' <param name="ReportName">DxxRxxxx: Mẫu báo cáo chuẫn</param>
    '    ''' <param name="ReportPath">Đường dẫn báo cáo chuẫn. Có thể truyền ""</param>
    '    ''' <param name="CustomReport">Mẫu báo cáo đặc thù theo từng form</param>
    '    ''' <param name="ReportTitle">Tiêu đề báo cáo</param>
    '    ''' <param name="ModuleID">xx: dùng để đổ nguồn cho combo đặc thù và tên báo cáo</param>
    '    ''' <param name="bUnicode"></param>
    '    ''' <returns>ReportName: Mẫu báo cáo; ReportPath: Đường dẫn báo cáo; ReportTitle: Tiêu đề báo cáo</returns>
    '    ''' <remarks></remarks>
    '    Public Function GetReportPath(ByVal ReportTypeID As String, ByVal ReportName As String, _
    '                             ByVal CustomReport As String, ByRef ReportPath As String, _
    '                            Optional ByRef ReportTitle As String = "", _
    '                            Optional ByVal ModuleID As String = "07", _
    '                            Optional ByVal bUnicode As Boolean = False) As String
    '        Dim Dxx As String = "D" & PARA_ModuleID 'Nếu không có biến PARA_ModuleID thì truyền Dxx. Thay "D" & PARA_ModuleID= Dxx
    '        Dim bShowReportPath As Boolean
    '        Dim iReportLanguage As Byte
    '        bShowReportPath = CType(D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
    '        iReportLanguage = CType(D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)

    '        'Lấy đường dẫn báo cáo từ module D99X0004
    '        ReportPath = UnicodeGetReportPath(bUnicode, iReportLanguage, "")
    '        'Hiển thị màn hình chọn đường dẫn báo cáo
    '        If bShowReportPath Then
    '            Dim frm As New D99F6666
    '            With frm
    '                .ModuleID = ModuleID '2 ký tự
    '                .ReportTypeID = ReportTypeID
    '                .ReportName = ReportName
    '                .CustomReport = CustomReport
    '                .ReportPath = ReportPath
    '                .ReportTitle = ReportTitle
    '                .ShowDialog()
    '                ReportName = .ReportName
    '                ReportPath = .ReportPath
    '                gsReportPath = ReportPath 'biến toàn cục đang dùng 
    '                ReportTitle = .ReportTitle
    '                .Dispose()
    '            End With
    '        Else 'Không hiển thị thì lấy theo Loại nghiệp vụ (nếu có)
    '            If CustomReport <> "" Then
    '                ReportPath = Application.StartupPath & "\XCustom\"
    '                ReportName = CustomReport
    '            End If
    '        End If
    '        ReportPath = ReportPath & ReportName & ".rpt"
    '        Return ReportName
    '    End Function

    '    'Tùy thuộc từng module có biến lưu dưới Registry
    '    Public Sub SaveOptionReport(ByVal bShowReportPath As Boolean) ', ByVal ModuleID As String)
    '        'Nếu không có biến PARA_ModuleID thì truyền Dxx. Thay "D" & PARA_ModuleID= Dxx
    '        D99C0007.SaveModulesSetting("D" & PARA_ModuleID, ModuleOption.lmOptions, "ShowReportPath", bShowReportPath)
    '        D45Options.ShowReportPath = bShowReportPath 'Biến Tùy chọn
    '        'Nếu module nào có thêm code VB6 thì lưu thêm nhánh VB6
    '        'D99C0007.SaveModulesSetting("D45", ModuleOption.lmOptions, "DisabledPathReport", bShowReportPath)
    '    End Sub

    '#End Region


#Region "KeyboardCues"
    '**********************
    Private Declare Function SystemParametersInfoSet Lib "user32.dll" Alias "SystemParametersInfoW" (ByVal action As Integer, ByVal param As Integer, ByVal value As Integer, ByVal winini As Boolean) As Boolean
    Private Const SPI_SETKEYBOARDCUES As Integer = &H100B

    Public Sub KeyboardCues()
        SystemParametersInfoSet(SPI_SETKEYBOARDCUES, 0, 1, False)
    End Sub
#End Region

End Module