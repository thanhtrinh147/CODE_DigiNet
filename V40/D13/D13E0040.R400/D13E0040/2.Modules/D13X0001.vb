''' <summary>
''' Module này liên qua đến các khai báo biến, enum, ... toàn cục
''' </summary>
Module D13X0001
    ''' <summary>
    ''' Module đang coding D13E0040
    ''' </summary>
    Public Const MODULED13 As String = "D13E0040"
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
    Public Const L3_HS_SECTION1 As String = "Handshake"
    Public Const L3_HS_SECTION2 As String = "Handshake"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_MODULE As String = "D13"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_VALUE As String = "R3.60.00.Y2007"
    ''' <summary>
    ''' Dùng cho kiểm tra thông tin đã lưu thành công hay chưa
    ''' </summary>
    Public gbSaveOK As Boolean = False
    ''' <summary>
    ''' ????
    ''' </summary>
    Public gbFlag As Boolean = False

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
    Public Const VE_XReportPath As String = "\XReports\VE-XReports\"
    Public Const E_XReportPath As String = "\XReports\E-XReports\"
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
    ''' Option của Treeview thiết lập tại màn hình chính F0000
    ''' </summary>
    ''' <remarks></remarks>
    Public giMenuType As Integer = 0 '0: Chuẩn, 1: cá nhân
    '    ''' <summary>
    '    '''  HSL tháng
    '    ''' </summary>
    '    ''' <remarks></remarks> đ chãuyển qua dll D13D9940
    '    Public gsPayRollVoucherID As String = ""

    ''' <summary>
    ''' Form Main của Module D13
    ''' </summary>
    Public frmD13F0000 As D13F0000

End Module
