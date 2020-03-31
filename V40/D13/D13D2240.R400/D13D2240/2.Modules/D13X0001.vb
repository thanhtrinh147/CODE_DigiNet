''' <summary>
''' Module này liên qua đến các khai báo biến, enum, ... toàn cục
''' </summary>
''' <remarks>Các khai báo ở đây không được trùng với các khai báo ở các Module D99Xxxxx</remarks>
Module D13X0001

    ''' <summary>
    ''' Module đang coding D13E2240
    ''' </summary>
    Public Const MODULED13 As String = "D13E2240"
    ''' <summary>
    ''' Chuỗi D13
    ''' </summary>
    Public Const D13 As String = "D13"
    ''' <summary>
    ''' Chuỗi ModuleID
    ''' </summary>
    Public Const ModuleID As String = "13"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_APP_NAME As String = "Lemon3"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_SECTION As String = "HandshakeR360"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_MODULE As String = "D13"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_VALUE As String = "R3.60.00.Y2007"
    Public gbSavedOK As Boolean
    ''' <summary>
    ''' ????
    ''' </summary>
    Public gbFlag As Boolean = False
    'Public gbUnicode As Boolean = False
    'Reportpath
    ''' <summary>
    ''' Dùng cho form Chọn đường dẫn báo cáo: Standard Report
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PathReport9 As String = "\XReports\"
    ''' <summary>
    ''' Dùng cho form Chọn đường dẫn báo cáo: Custom Report
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PathCustomizedReport9 As String = "\XCustom\"
    ''' <summary>
    '''  Dùng cho form Chọn đường dẫn báo cáo
    ''' </summary>
    ''' <remarks></remarks>
    Public gsReportPath As String
    ''' <summary>
    '''  Dùng cho form Chọn đường dẫn báo cáo-giá trị ReportID bên nghiệp vụ
    ''' </summary>
    ''' <remarks></remarks>
    Public gsReportID As String
    ''' <summary>
    '''  Dùng cho In theo đặc thù
    ''' </summary>
    ''' <remarks></remarks>
    Public gbIsCustom As Integer = 0 'Nếu 1 thì in theo đường dẫn ..\Lemon3\XCustom ; Ngược lại thì theo đường dẫn ..\Lemon3\XReports

    ''' <summary>
    '''  HSL tháng
    ''' </summary>
    ''' <remarks></remarks>
    Public gsPayRollVoucherID As String = ""

    ''' <summary>
    ''' Định nghĩa các button dùng cho trường hợp nhấn button sẽ cho hiển thị các cột trên lưới tương ứng với button đó 
    ''' </summary>
    Public Enum Button
        SalaryCoefficientBase = 0     ' Lương cơ bản/Hệ số
        Income = 1                    ' Thu nhập
        AnalyseCode = 2               ' Mã phân tích nhân sự
        SalaryLevelOfficialTitle = 3  ' Ngạch bậc lương
        Debit = 4                     ' Tài khoản nợ
        Credit = 5                    ' Tài khoản có
        Ana = 6                       ' Khoản mục
        AnalyseSalary = 7             ' Mã phân tích tiền lương
        SalaryPaymentMethod = 8       ' Phương pháp trả lương
        InfoCalculated = 9            ' Thông tin quyết toán
        InfoTaxIncome = 10            ' Thông tin khai thuế  
        InfoInsurance = 11            ' Thông tin bảo hiểm
    End Enum

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

    End Structure
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

    '    ''' <summary>
    '    ''' Định nghĩa các giá trị boolean của các pp tính lương tích dùng để cột mã phân tích tương ứng hiển thị 
    '    ''' khi pp tính lương đó hiện tại có sử dụng hay ẩn đi khi pp tính lương đó hiện tại không sử dụng
    '    ''' </summary>
    '    Public Structure TNH
    '        Public TNH01 As Boolean
    '        Public TNH02 As Boolean
    '        Public TNH03 As Boolean
    '        Public TNH04 As Boolean
    '        Public TNH05 As Boolean
    '        Public TNH06 As Boolean
    '        Public TNH07 As Boolean
    '        Public TNH08 As Boolean
    '        Public TNH09 As Boolean
    '        Public TNH10 As Boolean
    '        Public TNH11 As Boolean
    '        Public TNH12 As Boolean
    '        Public TNH13 As Boolean
    '        Public TNH14 As Boolean
    '        Public TNH15 As Boolean
    '        Public TNH16 As Boolean
    '        Public TNH17 As Boolean
    '        Public TNH18 As Boolean
    '        Public TNH19 As Boolean
    '        Public TNH20 As Boolean
    '        Public TNH21 As Boolean
    '        Public TNH22 As Boolean
    '        Public TNH23 As Boolean
    '        Public TNH24 As Boolean
    '        Public TNH25 As Boolean
    '        Public TNH26 As Boolean
    '        Public TNH27 As Boolean
    '        Public TNH28 As Boolean
    '        Public TNH29 As Boolean
    '        Public TNH30 As Boolean
    '        Public TNH31 As Boolean
    '        Public TNH32 As Boolean
    '        Public TNH33 As Boolean
    '        Public TNH34 As Boolean
    '        Public TNH35 As Boolean
    '        Public TNH36 As Boolean
    '        Public TNH37 As Boolean
    '        Public TNH38 As Boolean
    '        Public TNH39 As Boolean
    '        Public TNH40 As Boolean
    '        Public TNH41 As Boolean
    '        Public TNH42 As Boolean
    '        Public TNH43 As Boolean
    '        Public TNH44 As Boolean
    '        Public TNH45 As Boolean
    '        Public TNH46 As Boolean
    '        Public TNH47 As Boolean
    '        Public TNH48 As Boolean
    '        Public TNH49 As Boolean
    '        Public TNH50 As Boolean
    '        Public TNH51 As Boolean
    '        Public TNH52 As Boolean
    '        Public TNH53 As Boolean
    '        Public TNH54 As Boolean
    '        Public TNH55 As Boolean
    '        Public TNH56 As Boolean
    '        Public TNH57 As Boolean
    '        Public TNH58 As Boolean
    '        Public TNH59 As Boolean
    '        Public TNH60 As Boolean
    '        Public TNH61 As Boolean
    '        Public TNH62 As Boolean
    '        Public TNH63 As Boolean
    '        Public TNH64 As Boolean
    '        Public TNH65 As Boolean
    '        Public TNH66 As Boolean
    '        Public TNH67 As Boolean
    '        Public TNH68 As Boolean
    '        Public TNH69 As Boolean
    '        Public TNH70 As Boolean
    '        Public TNH71 As Boolean
    '        Public TNH72 As Boolean
    '        Public TNH73 As Boolean
    '        Public TNH74 As Boolean
    '        Public TNH75 As Boolean
    '        Public TNH76 As Boolean
    '        Public TNH77 As Boolean
    '        Public TNH78 As Boolean
    '        Public TNH79 As Boolean
    '        Public TNH80 As Boolean
    '
    '        'ADD 18/12/07
    '        Public TNH81 As Boolean
    '        Public TNH82 As Boolean
    '        Public TNH83 As Boolean
    '        Public TNH84 As Boolean
    '        Public TNH85 As Boolean
    '        Public TNH86 As Boolean
    '        Public TNH87 As Boolean
    '        Public TNH88 As Boolean
    '        Public TNH89 As Boolean
    '        Public TNH90 As Boolean
    '
    '        Public TNH91 As Boolean
    '        Public TNH92 As Boolean
    '        Public TNH93 As Boolean
    '        Public TNH94 As Boolean
    '        Public TNH95 As Boolean
    '        Public TNH96 As Boolean
    '        Public TNH97 As Boolean
    '        Public TNH98 As Boolean
    '        Public TNH99 As Boolean
    '        Public TNH100 As Boolean
    '
    '    End Structure

    ''' <summary>
    ''' Định nghĩa các giá trị boolean của các hệ số lương dùng để cột hệ số lương tương ứng hiển thị 
    ''' khi hệ số lương đó hiện tại có sử dụng hay ẩn đi khi hệ số lương đó hiện tại không sử dụng
    ''' </summary>
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

        Public OLSC10_DATE As Boolean
        Public OLSC20_DATE As Boolean
    End Structure

End Module
