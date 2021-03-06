''' <summary>
''' Module này liên qua đến các khai báo biến, enum, ... toàn cục
''' </summary>
Module D45X0001
    ''' <summary>
    ''' Module đang coding D45E0040
    ''' </summary>
    Public Const MODULED45 As String = "D45E0040"
    ''' <summary>
    ''' Chuỗi D45
    ''' </summary>
    Public Const D45 As String = "D45"
    ''' <summary>
    ''' Chuỗi ModuleID
    ''' </summary>
    Public Const ModuleID As String = "45"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_APP_NAME As String = "Lemon3"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET cho phiên bản hiện tại
    ''' </summary>
    Public Const L3_HS_SECTION As String = "HandshakeR360"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET  cho 2 phiên bản cũ
    ''' </summary>
    Public Const L3_HS_SECTION1 As String = "Handshake"
    Public Const L3_HS_SECTION2 As String = "Handshake"

    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_MODULE As String = "D45"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_VALUE As String = "R3.60.00.Y2007"

    '''Dùng cho ktra co lưu thành công k
    Public gbSavedOK As Boolean = False
    ''' <summary>
    ''' Dùng cho form Chọn đường dẫn báo cáo: Standard Report
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PathReport9 As String = "\XReports\"
    Public Const PathReportVE As String = "\XReports\VE-XReports\"
    Public Const PathReportE As String = "\XReports\E-XReports\"
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
    Public bIsUseBlock As Boolean 'Ktra Khoi co duoc thiet lap chua?
    Public iPieceWorkMethod As Integer 'Phuong phap cham công

    ''' <summary>
    ''' Option của Treeview thiết lập tại màn hình chính F0000
    ''' </summary>
    ''' <remarks></remarks>
    Public giMenuType As Integer = 0 '0: Chuẩn, 1: cá nhân
    
End Module
