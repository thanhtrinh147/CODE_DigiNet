''' <summary>
''' Module này liên qua đến các khai báo biến, enum, ... toàn cục
''' </summary>
''' <remarks>Các khai báo ở đây không được trùng với các khai báo ở các Module D99Xxxxx</remarks>
Module D13X0001

    ''' <summary>
    ''' Module đang coding D13D0140
    ''' </summary>
    Public Const MODULED13 As String = "D13D0140"
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
    ''' <summary>
    ''' MaxSmallInt
    ''' </summary>
    Public Const MaxSmallInt As Int16 = 32767
    ''' <summary>
    ''' gbSavedOK
    ''' </summary>
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
    Public gsModuleID As String = "D13"

End Module
