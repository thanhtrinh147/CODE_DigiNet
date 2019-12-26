''' <summary>
''' Module này liên qua đến các khai báo biến, enum, ... toàn cục
''' </summary>
''' <remarks>Các khai báo ở đây không được trùng với các khai báo ở các Module D99Xxxxx</remarks>
Module D45X0001

    ''' <summary>
    ''' Module đang coding D45E0940
    ''' </summary>
    Public Const MODULED45 As String = "D45E0940"
    ''' <summary>
    ''' Chuỗi D45
    ''' </summary>
    Public Const D45 As String = "D45"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_APP_NAME As String = "Lemon3"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_SECTION As String = "Handshake"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_MODULE As String = "D45"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_VALUE As String = "R3.50.00..Y2006"

    ''''' Dùng cho form Chọn đường dẫn báo cáo: Standard Report
    '''' </summary>
    '''' <remarks></remarks>
    Public Const PathReport9 As String = "\XReports\"
    ''' <summary>
    ''' Dùng cho form Chọn đường dẫn báo cáo: Custom Report
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PathCustomizedReport9 As String = "\XCustom\"
    ''''  Dùng cho form Chọn đường dẫn báo cáo
    '''' </summary>
    '''' <remarks></remarks>
    Public gsReportPath As String

    Public Const FormatDateSysSave As String = "MM/dd/yyyy HH:mm:ss"
    Public Const FormatDateSysShow As String = "dd/MM/yyyy HH:mm:ss"

    Public Const MaxDecimal30 As Double = 1.0E+30

    Public gbSavedOK As Boolean = False
    Public gbCloseOK As Boolean = False
    'Public giRegFlag As Integer

    'Public gnRegNum01 As Double
    'Public gnRegNum02 As Double
    'Public gnRegNum03 As Double
    'Public gnRegNum04 As Double
    'Public gnRegNum05 As Double
    'Public gnRegNum06 As Double
    'Public gnRegNum07 As Double
    'Public gnRegNum08 As Double
    'Public gnRegNum09 As Double
    'Public gnRegNum10 As Double
    'Public gnRegQuantity As Double
    'Public gsRegFormulaID As String
    'Public gsRegFormula As String

    'TODO: AuditLog
    Public gnAudit As Integer

    'Public gbUseAudit As Boolean

    ''' <summary>
    ''' Tìm kiếm số lô D45F2235
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Enum_Find
        f_Startby   'Bat dau boi
        f_Endby     'Ket thuc boi
        f_Between     'Nam giua
        f_Contain   'Co chua
    End Enum

    Public Enum Button
        MainInfo = 0   'Thông tin chính
        Manufactor = 1     'Sản xuất
        Ana = 2    'Khoản mục
        Other = 3   'Thông tin khác
        RefInfo = 4 'Thông tin phụ
    End Enum
    ''' <summary>
    ''' Mã hàng đã chọn vị trí đầy đủ
    ''' </summary>
    ''' <remarks></remarks>
    Public gclrCompletedLocationColor As Color
    ''' <summary>
    ''' Mã hàng đã chọn vị trí còn dỡ dang
    ''' </summary>
    ''' <remarks></remarks>
    Public gclrInProgressLocationColor As Color
    ''' <summary>
    ''' Mã hàng chưa chọn vị trí
    ''' </summary>
    ''' <remarks></remarks>
    Public gclrNotInProgressLocationColor As Color

    Public Const V_XReportPath As String = "\XReports\"
    Public Const VE_XReportPath As String = "\XReports\VE-XReports\"
    Public Const E_XReportPath As String = "\XReports\E-XReports\"

    'Public giPermisionPriceCol As Integer = 0
    'Public gbReturnFromD99U0001 As Boolean = False
End Module
