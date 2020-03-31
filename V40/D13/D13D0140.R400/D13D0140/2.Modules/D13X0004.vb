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
    '''' <summary>
    '''' format số lượng
    '''' </summary>
    'Public OriginalQuantity As String
    '''' <summary>
    '''' Số làm tròn của số lượng
    '''' </summary>
    'Public OriginalQuantityRound As Integer
    '''' <summary>
    '''' format số lượng quy đổi
    '''' </summary>
    'Public ConvertedQuantity As String
    '''' <summary>
    '''' Số làm tròn của số lượng quy đổi
    '''' </summary>
    'Public ConvertedQuantityRound As Integer
    '''' <summary>
    '''' format thành tiền
    '''' </summary>
    'Public OriginalAmount As String
    '''' <summary>
    '''' Số làm tròn của thành tiền
    '''' </summary>
    'Public OriginalAmountRound As Integer
    '''' <summary>
    '''' format thành tiền quy đổi
    '''' </summary>
    'Public ConvertedAmount As String
    '''' <summary>
    '''' Số làm tròn của thành tiền quy đổi
    '''' </summary>
    'Public ConvertedAmountRound As Integer
    '''' <summary>
    '''' format giảm giá
    '''' </summary>
    'Public OriginalReduction As String
    '''' <summary>
    '''' Số làm tròn của giảm giá
    '''' </summary>
    'Public OriginalReductionRound As Integer
    '''' <summary>
    '''' format giảm giá quy đổi
    '''' </summary>
    'Public ConvertedReduction As String
    '''' <summary>
    '''' Số làm tròn của giảm giá quy đổi
    '''' </summary>
    'Public ConvertedReductionRound As Integer
    '''' <summary>
    '''' format đơn giá
    '''' </summary>
    'Public UnitPrice As String
    '''' <summary>
    '''' Số làm tròn của đơn giá
    '''' </summary>
    'Public UnitPriceRound As Integer
    '''' <summary>
    '''' format tỷ giá
    '''' </summary>
    'Public ExchangeRate As String
    '''' <summary>
    '''' Số làm tròn của tỷ giá
    '''' </summary>
    'Public ExchangeRateRound As Integer
    '''' <summary>
    '''' Nguyên tệ gốc
    '''' </summary>
    'Public BaseCurrencyID As String
    '''' <summary>
    '''' Dấu phân cách thập phân
    '''' </summary>
    'Public DecimalSeperator As String
    '''' <summary>
    '''' Dấu phân cách hàng ngàn
    '''' </summary>
    'Public ThousandSeperator As String
    '------------------------------------------------------------------------
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

'''' <summary>
'''' Định nghĩa các button dùng cho trường hợp nhấn button sẽ cho hiển thị các cột trên lưới tương ứng với button đó 
'''' </summary>
'Public Enum Button
'    SalaryCoefficientBase = 0     ' Lương cơ bản/Hệ số
'    Income = 1                    ' Thu nhập
'    AnalyseCode = 2               ' Mã phân tích
'    SalaryLevelOfficialTitle = 3  ' Ngạch bậc lương
'    Debit = 4                     ' Tài khoản nợ
'    Credit = 5                    ' Tài khoản có
'    Ana = 6                       ' Khoản mục
'    AnalyseSalary = 7             ' Mã phân tích tiền lương
'    SalaryPaymentMethod = 8       ' Phương pháp trả lương
'    InfoCalculated = 9            ' Thông tin quyết toán
'    InfoTaxIncome = 10            ' Thông tin khai thuế  
'    InfoInsurance = 11            ' Thông tin bảo hiểm
'End Enum

'''' <summary>
'''' Định nghĩa các giá trị boolean của các mức lương dùng để cột mức lương tương ứng hiển thị 
'''' khi mức lương đó hiện tại có sử dụng hay ẩn đi khi mức lương đó hiện tại không sử dụng
'''' </summary>

'Public Structure SALBA
'    Public BASE01 As Boolean
'    Public BASE02 As Boolean
'    Public BASE03 As Boolean
'    Public BASE04 As Boolean
'End Structure
'''' <summary>
'''' Định nghĩa các giá trị boolean của các hệ số lương dùng để cột hệ số lương tương ứng hiển thị 
'''' khi hệ số lương đó hiện tại có sử dụng hay ẩn đi khi hệ số lương đó hiện tại không sử dụng
'''' </summary>
'Public Structure SALCE
'    Public CE01 As Boolean
'    Public CE02 As Boolean
'    Public CE03 As Boolean
'    Public CE04 As Boolean
'    Public CE05 As Boolean
'    Public CE06 As Boolean
'    Public CE07 As Boolean
'    Public CE08 As Boolean
'    Public CE09 As Boolean
'    Public CE10 As Boolean

'End Structure
''' <summary>
''' Định nghĩa các giá trị boolean của các thu nhập dùng để cột thu nhập tương ứng hiển thị 
''' khi thu nhập đó hiện tại có sử dụng hay ẩn đi khi thu nhập đó hiện tại không sử dụng
''' </summary>
Public Structure PRMAS
    Public INC01 As Boolean
    Public INC02 As Boolean
    Public INC03 As Boolean
    Public INC04 As Boolean
    Public INC05 As Boolean
    Public INC06 As Boolean
    Public INC07 As Boolean
    Public INC08 As Boolean
    Public INC09 As Boolean
    Public INC10 As Boolean
    Public INC11 As Boolean
    Public INC12 As Boolean
    Public INC13 As Boolean
    Public INC14 As Boolean
    Public INC15 As Boolean
    Public INC16 As Boolean
    Public INC17 As Boolean
    Public INC18 As Boolean
    Public INC19 As Boolean
    Public INC20 As Boolean
    Public INC21 As Boolean
    Public INC22 As Boolean
    Public INC23 As Boolean
    Public INC24 As Boolean
    Public INC25 As Boolean
    Public INC26 As Boolean
    Public INC27 As Boolean
    Public INC28 As Boolean
    Public INC29 As Boolean
    Public INC30 As Boolean

End Structure

''' <summary>
''' Định nghĩa các giá trị boolean của các mã phân tích dùng để cột mã phân tích tương ứng hiển thị 
''' khi mã phân tích đó hiện tại có sử dụng hay ẩn đi khi mã phân tích đó hiện tại không sử dụng
''' </summary>
Public Structure ANACODE
    Public N01 As Boolean
    Public N02 As Boolean
    Public N03 As Boolean
    Public N04 As Boolean
    Public N05 As Boolean
    Public N06 As Boolean
    Public N07 As Boolean
    Public N08 As Boolean
    Public N09 As Boolean
    Public N10 As Boolean
    Public N11 As Boolean
    Public N12 As Boolean
    Public N13 As Boolean
    Public N14 As Boolean
    Public N15 As Boolean
    Public N16 As Boolean
    Public N17 As Boolean
    Public N18 As Boolean
    Public N19 As Boolean
    Public N20 As Boolean
End Structure

''' <summary>
''' Định nghĩa các giá trị boolean của các mã phân tích dùng để cột mã phân tích tiền lương tương ứng hiển thị 
''' khi mã phân tích tiền lương đó hiện tại có sử dụng hay ẩn đi khi mã phân tích tiền lương đó hiện tại không sử dụng
''' </summary>
Public Structure ANASALARY
    Public P01 As Boolean
    Public P02 As Boolean
    Public P03 As Boolean
    Public P04 As Boolean
    Public P05 As Boolean
    Public P06 As Boolean
    Public P07 As Boolean
    Public P08 As Boolean
    Public P09 As Boolean
    Public P10 As Boolean
    Public P11 As Boolean
    Public P12 As Boolean
    Public P13 As Boolean
    Public P14 As Boolean
    Public P15 As Boolean
    Public P16 As Boolean
    Public P17 As Boolean
    Public P18 As Boolean
    Public P19 As Boolean
    Public P20 As Boolean
End Structure

''' <summary>
''' Định nghĩa các giá trị boolean của các pp tính lương tích dùng để cột mã phân tích tương ứng hiển thị 
''' khi pp tính lương đó hiện tại có sử dụng hay ẩn đi khi pp tính lương đó hiện tại không sử dụng
''' </summary>
Public Structure TNH
    Public TNH01 As Boolean
    Public TNH02 As Boolean
    Public TNH03 As Boolean
    Public TNH04 As Boolean
    Public TNH05 As Boolean
    Public TNH06 As Boolean
    Public TNH07 As Boolean
    Public TNH08 As Boolean
    Public TNH09 As Boolean
    Public TNH10 As Boolean
    Public TNH11 As Boolean
    Public TNH12 As Boolean
    Public TNH13 As Boolean
    Public TNH14 As Boolean
    Public TNH15 As Boolean
    Public TNH16 As Boolean
    Public TNH17 As Boolean
    Public TNH18 As Boolean
    Public TNH19 As Boolean
    Public TNH20 As Boolean
    Public TNH21 As Boolean
    Public TNH22 As Boolean
    Public TNH23 As Boolean
    Public TNH24 As Boolean
    Public TNH25 As Boolean
    Public TNH26 As Boolean
    Public TNH27 As Boolean
    Public TNH28 As Boolean
    Public TNH29 As Boolean
    Public TNH30 As Boolean
    Public TNH31 As Boolean
    Public TNH32 As Boolean
    Public TNH33 As Boolean
    Public TNH34 As Boolean
    Public TNH35 As Boolean
    Public TNH36 As Boolean
    Public TNH37 As Boolean
    Public TNH38 As Boolean
    Public TNH39 As Boolean
    Public TNH40 As Boolean
    Public TNH41 As Boolean
    Public TNH42 As Boolean
    Public TNH43 As Boolean
    Public TNH44 As Boolean
    Public TNH45 As Boolean
    Public TNH46 As Boolean
    Public TNH47 As Boolean
    Public TNH48 As Boolean
    Public TNH49 As Boolean
    Public TNH50 As Boolean
    Public TNH51 As Boolean
    Public TNH52 As Boolean
    Public TNH53 As Boolean
    Public TNH54 As Boolean
    Public TNH55 As Boolean
    Public TNH56 As Boolean
    Public TNH57 As Boolean
    Public TNH58 As Boolean
    Public TNH59 As Boolean
    Public TNH60 As Boolean
    Public TNH61 As Boolean
    Public TNH62 As Boolean
    Public TNH63 As Boolean
    Public TNH64 As Boolean
    Public TNH65 As Boolean
    Public TNH66 As Boolean
    Public TNH67 As Boolean
    Public TNH68 As Boolean
    Public TNH69 As Boolean
    Public TNH70 As Boolean
    Public TNH71 As Boolean
    Public TNH72 As Boolean
    Public TNH73 As Boolean
    Public TNH74 As Boolean
    Public TNH75 As Boolean
    Public TNH76 As Boolean
    Public TNH77 As Boolean
    Public TNH78 As Boolean
    Public TNH79 As Boolean
    Public TNH80 As Boolean

End Structure
#End Region

Module D13X0004

    ''' <summary>
    ''' Định nghĩa các giá trị boolean của các mức lương dùng để cột mức lương tương ứng hiển thị 
    ''' khi mức lương đó hiện tại có sử dụng hay ẩn đi khi mức lương đó hiện tại không sử dụng
    ''' </summary>
    Public Structure SALBA
        Public BASE01 As Boolean
        Public BASE02 As Boolean
        Public BASE03 As Boolean
        Public BASE04 As Boolean

        Public BASE01_DATE As Boolean
        Public BASE02_DATE As Boolean
        Public BASE03_DATE As Boolean
        Public BASE04_DATE As Boolean
    End Structure

    ''' <summary>
    ''' Định nghĩa các giá trị boolean của các hệ số lương dùng để cột hệ số lương tương ứng hiển thị 
    ''' khi hệ số lương đó hiện tại có sử dụng hay ẩn đi khi hệ số lương đó hiện tại không sử dụng
    ''' </summary>
    Public Structure SALCE
        Public CE01 As Boolean
        Public CE02 As Boolean
        Public CE03 As Boolean
        Public CE04 As Boolean
        Public CE05 As Boolean
        Public CE06 As Boolean
        Public CE07 As Boolean
        Public CE08 As Boolean
        Public CE09 As Boolean
        Public CE10 As Boolean
        Public CE11 As Boolean
        Public CE12 As Boolean
        Public CE13 As Boolean
        Public CE14 As Boolean
        Public CE15 As Boolean
        Public CE16 As Boolean
        Public CE17 As Boolean
        Public CE18 As Boolean
        Public CE19 As Boolean
        Public CE20 As Boolean

        Public CE01_DATE As Boolean
        Public CE02_DATE As Boolean
        Public CE03_DATE As Boolean
        Public CE04_DATE As Boolean
        Public CE05_DATE As Boolean
        Public CE06_DATE As Boolean
        Public CE07_DATE As Boolean
        Public CE08_DATE As Boolean
        Public CE09_DATE As Boolean
        Public CE10_DATE As Boolean
        Public CE11_DATE As Boolean
        Public CE12_DATE As Boolean
        Public CE13_DATE As Boolean
        Public CE14_DATE As Boolean
        Public CE15_DATE As Boolean
        Public CE16_DATE As Boolean
        Public CE17_DATE As Boolean
        Public CE18_DATE As Boolean
        Public CE19_DATE As Boolean
        Public CE20_DATE As Boolean
    End Structure

    Public Structure OLSC
        Public OLSC1 As Boolean
        Public OLSC10 As Boolean
        Public OLSC11 As Boolean
        Public OLSC12 As Boolean
        Public OLSC13 As Boolean
        Public OLSC14 As Boolean
        Public OLSC15 As Boolean
        Public OLSC2 As Boolean
        Public OLSC20 As Boolean
        Public OLSC21 As Boolean
        Public OLSC22 As Boolean
        Public OLSC23 As Boolean
        Public OLSC24 As Boolean
        Public OLSC25 As Boolean

        Public OfficialTitleID As Boolean
        Public SalaryLevelID As Boolean
        Public SaCoefficient As Boolean
        Public SaCoefficient12 As Boolean
        Public SaCoefficient13 As Boolean
        Public SaCoefficient14 As Boolean
        Public SaCoefficient15 As Boolean

        Public OfficialTitleID2 As Boolean
        Public SalaryLevelID2 As Boolean
        Public SaCoefficient2 As Boolean
        Public SaCoefficient22 As Boolean
        Public SaCoefficient23 As Boolean
        Public SaCoefficient24 As Boolean
        Public SaCoefficient25 As Boolean

        Public OLSC10_DATE As Boolean
        Public OLSC20_DATE As Boolean
    End Structure

    ''' <summary>
    ''' Định nghĩa các định dạng Format cho mức lương, hệ số lương tương ứng 
    ''' </summary>
    Public Structure StructureFormatSalary
        Public BASE01 As String
        Public BASE02 As String
        Public BASE03 As String
        Public BASE04 As String

        Public CE01 As String
        Public CE02 As String
        Public CE03 As String
        Public CE04 As String
        Public CE05 As String
        Public CE06 As String
        Public CE07 As String
        Public CE08 As String
        Public CE09 As String
        Public CE10 As String
        Public CE11 As String
        Public CE12 As String
        Public CE13 As String
        Public CE14 As String
        Public CE15 As String
        Public CE16 As String
        Public CE17 As String
        Public CE18 As String
        Public CE19 As String
        Public CE20 As String

        Public OLSC11 As String
        Public OLSC12 As String
        Public OLSC13 As String
        Public OLSC14 As String
        Public OLSC15 As String
        Public OLSC21 As String
        Public OLSC22 As String
        Public OLSC23 As String
        Public OLSC24 As String
        Public OLSC25 As String
    End Structure

    ''' <summary>
    ''' Lưu trữ các thiết lập tùy chọn
    ''' </summary>
    Public D13Options As StructureOption
    ''' <summary>
    ''' Lưu trữ các thiết lập Thông tin hệ thống
    ''' </summary>
    Public D13Systems As StructureSystem
    ''' <summary>
    ''' Lưu trữ các thiết lập format
    ''' </summary>
    Public D13Format As StructureFormat
    ''' <summary>
    ''' Lưu trữ các thiết lập format lương
    ''' </summary>
    Public D13FormatSalary As StructureFormatSalary
    '''' <summary>
    '''' Form Main của Module D13
    '''' </summary>

    ''' <summary>
    ''' Load toàn bộ các thông số tùy chọn vào biến D13Options
    ''' </summary>
    Public Sub LoadOptions()
        With D13Options
            '.DefaultDivisionID = D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "DefaultDivisionID", "")
            '.LockDivisionID = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "LockDivisionID", "False"))
            '.MessageAskBeforeSave = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "MessageAskBeforeSave", "True"))
            '.MessageWhenSaveOK = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "MessageWhenSaveOK", "True"))
            '.ViewFormPeriodWhenAppRun = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", "False"))

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
        gsFormatDateType = GetFormatDateType()

        Dim sSQL As String = "Select * From D13T0000 WITH (NOLOCK) "
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
    ''' Load toàn bộ các thông số format cho biến D13Format theo kiểu double, decimal, money
    ''' </summary>
    Public Sub LoadFormats()
        Dim sSQL As String = ""
        sSQL &= "Select Code, Short, Disabled, Type, Decimals From D13T9000  WITH (NOLOCK) Order By Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)

        If dt.Rows.Count > 0 Then
            Dim dtSALBA As DataTable = ReturnTableFilter(dt, " Type = 'SALBA'")
            Dim dtSALCE As DataTable = ReturnTableFilter(dt, " Type = 'SALCE'")
            Dim dtOLSC As DataTable = ReturnTableFilter(dt, " Type = 'OLSC'")

            D13FormatSalary.BASE01 = InsertFormat(dtSALBA.Rows(0).Item("Decimals").ToString)
            D13FormatSalary.BASE02 = InsertFormat(dtSALBA.Rows(1).Item("Decimals").ToString)
            D13FormatSalary.BASE03 = InsertFormat(dtSALBA.Rows(2).Item("Decimals").ToString)
            D13FormatSalary.BASE04 = InsertFormat(dtSALBA.Rows(3).Item("Decimals").ToString)

            D13FormatSalary.CE01 = InsertFormat(dtSALCE.Rows(0).Item("Decimals").ToString)
            D13FormatSalary.CE02 = InsertFormat(dtSALCE.Rows(1).Item("Decimals").ToString)
            D13FormatSalary.CE03 = InsertFormat(dtSALCE.Rows(2).Item("Decimals").ToString)
            D13FormatSalary.CE04 = InsertFormat(dtSALCE.Rows(3).Item("Decimals").ToString)
            D13FormatSalary.CE05 = InsertFormat(dtSALCE.Rows(4).Item("Decimals").ToString)
            D13FormatSalary.CE06 = InsertFormat(dtSALCE.Rows(5).Item("Decimals").ToString)
            D13FormatSalary.CE07 = InsertFormat(dtSALCE.Rows(6).Item("Decimals").ToString)
            D13FormatSalary.CE08 = InsertFormat(dtSALCE.Rows(7).Item("Decimals").ToString)
            D13FormatSalary.CE09 = InsertFormat(dtSALCE.Rows(8).Item("Decimals").ToString)
            D13FormatSalary.CE10 = InsertFormat(dtSALCE.Rows(9).Item("Decimals").ToString)
            D13FormatSalary.CE11 = InsertFormat(dtSALCE.Rows(10).Item("Decimals").ToString)
            D13FormatSalary.CE12 = InsertFormat(dtSALCE.Rows(11).Item("Decimals").ToString)
            D13FormatSalary.CE13 = InsertFormat(dtSALCE.Rows(12).Item("Decimals").ToString)
            D13FormatSalary.CE14 = InsertFormat(dtSALCE.Rows(13).Item("Decimals").ToString)
            D13FormatSalary.CE15 = InsertFormat(dtSALCE.Rows(14).Item("Decimals").ToString)
            D13FormatSalary.CE16 = InsertFormat(dtSALCE.Rows(15).Item("Decimals").ToString)
            D13FormatSalary.CE17 = InsertFormat(dtSALCE.Rows(16).Item("Decimals").ToString)
            D13FormatSalary.CE18 = InsertFormat(dtSALCE.Rows(17).Item("Decimals").ToString)
            D13FormatSalary.CE19 = InsertFormat(dtSALCE.Rows(18).Item("Decimals").ToString)
            D13FormatSalary.CE20 = InsertFormat(dtSALCE.Rows(19).Item("Decimals").ToString)


            D13FormatSalary.OLSC11 = InsertFormat(dtOLSC.Rows(2).Item("Decimals").ToString)
            D13FormatSalary.OLSC12 = InsertFormat(dtOLSC.Rows(3).Item("Decimals").ToString)
            D13FormatSalary.OLSC13 = InsertFormat(dtOLSC.Rows(4).Item("Decimals").ToString)
            D13FormatSalary.OLSC14 = InsertFormat(dtOLSC.Rows(5).Item("Decimals").ToString)
            D13FormatSalary.OLSC15 = InsertFormat(dtOLSC.Rows(6).Item("Decimals").ToString)
            D13FormatSalary.OLSC21 = InsertFormat(dtOLSC.Rows(9).Item("Decimals").ToString)
            D13FormatSalary.OLSC22 = InsertFormat(dtOLSC.Rows(10).Item("Decimals").ToString)
            D13FormatSalary.OLSC23 = InsertFormat(dtOLSC.Rows(11).Item("Decimals").ToString)
            D13FormatSalary.OLSC24 = InsertFormat(dtOLSC.Rows(12).Item("Decimals").ToString)
            D13FormatSalary.OLSC25 = InsertFormat(dtOLSC.Rows(13).Item("Decimals").ToString)
        End If

        D13Format.DefaultNumber2 = "#,##0.00"
        D13Format.DefaultNumber0 = "#,##0"
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


    '    ''' <summary>
    '    ''' Kiểm tra thiết lập Audit
    '    ''' </summary>
    '    ''' <param name="sWhere">Chuỗi điều kiện lấy audit</param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function CheckAudit(ByVal sWhere As String) As Boolean
    '        Dim sSQL As String = ""
    '        sSQL &= "Select Audit From D91T9200  WITH (NOLOCK) Where AuditCode = " & SQLString(sWhere)
    '        Dim dt As DataTable = ReturnDataTable(sSQL)
    '        If dt.Rows.Count = 0 Then Exit Function
    '        If Convert.ToInt16(dt.Rows(0).Item("Audit")) = 0 Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    End Function

    '    '#---------------------------------------------------------------------------------------------------
    '    '# Title: SQLStoreD91P9106
    '    '# Created User: Trần Thị Ái Trâm
    '    '# Created Date: 06/03/2007 09:59:44
    '    '# Modified User: 
    '    '# Modified Date: 
    '    '# Description: 
    '    '#---------------------------------------------------------------------------------------------------
    '    Public Function SQLStoreD91P9106(ByVal sAuditCode As String, ByVal sModuleID As String, ByVal sEventID As String, ByVal sDesc1 As String, ByVal sDesc2 As String, ByVal sDesc3 As String, ByVal sDesc4 As String, ByVal sDesc5 As String) As String
    '        Dim sSQL As String = ""
    '        sSQL &= "Exec D91P9106 "
    '        sSQL &= SQLDateSave(Date.Today) & COMMA 'AuditDate, datetime, NOT NULL
    '        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
    '        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '        sSQL &= SQLString(sModuleID) & COMMA 'ModuleID, varchar[2], NOT NULL
    '        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
    '        sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
    '        sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
    '        sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
    '        sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
    '        sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL
    '        Return sSQL
    '    End Function

    'Public Sub LoadOptions_Unicode()
    '    Dim sSQL As String = "Select * From D09T5550 Where UserID=" & SQLString(gsUserID)
    '    Dim dt As DataTable = ReturnDataTable(sSQL)
    '    If dt.Rows.Count > 0 Then
    '        Dim dr As DataRow = dt.Rows(0)
    '        D13Options.CodeTable = L3Bool(dr.Item("CodeTable"))
    '    Else
    '        D13Options.CodeTable = False
    '    End If
    '    dt.Dispose()
    'End Sub

    Public Function CheckKeyPressSpecialCharactor(ByVal str As String) As Boolean
        'Chuỗi không cho gõ ký tự đặc biệt này
        If str.IndexOf(Chr(91)) >= 0 Then Return True ' [
        If str.IndexOf(Chr(93)) >= 0 Then Return True ']
        If str.IndexOf(Chr(94)) >= 0 Then Return True '^
        If str.IndexOf(Chr(39)) >= 0 Then Return True ' '
        If str.IndexOf(Chr(37)) >= 0 Then Return True ' %
        Return False
    End Function


End Module
