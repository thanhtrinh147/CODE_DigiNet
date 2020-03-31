''' <summary>
''' Module này liên qua đến các khai báo biến, enum, ... toàn cục
''' </summary>
Module D25X0001
    ''' <summary>
    ''' Module đang coding D25E0040
    ''' </summary>
    Public Const MODULED25 As String = "D25D4040"
    ''' <summary>
    ''' Chuỗi D25
    ''' </summary>
    Public Const D25 As String = "D25"
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
    Public Const L3_HS_SECTION1 As String = "Handshake"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_SECTION2 As String = "Handshake"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_MODULE As String = "D25"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_VALUE As String = "R3.60.00.Y2007"
    ''' <summary>
    ''' Sau khi lưu thành công
    ''' </summary>
    ''' <remarks></remarks>
    Public gbSavedOk As Boolean = False
    ''' <summary>
    ''' Ngày giờ
    ''' </summary>
    ''' <remarks></remarks>
    Public Const gsDateTimeShow As String = "dd/MM/yyyy hh:mm:ss"
    Public Const gsDateTimeSave As String = "MM/dd/yyyy hh:mm:ss"
    ''' <summary>
    ''' Hằng số mặc định cho ngày giờ dd/MM/yyyy HH:mm:ss
    ''' </summary>
    ''' <remarks></remarks>
    Public Const MaskFormatDateTime As String = "__/__/____ __:__:__"
    ''' <summary>
    ''' Hằng số mặc định cho giờ là HH:MM:SS
    ''' </summary>
    ''' <remarks></remarks>
    Public Const MaskFormatTime As String = "__:__:__"
    ''' <summary>
    ''' Hằng số mặc định cho giờ là HH:MM
    ''' </summary>
    ''' <remarks></remarks>
    Public Const MaskFormatTimeMinute As String = "__:__"
    '''' <summary>
    '''' Các biến toàn cục cho Audit
    '''' </summary>
    'Public gbUseAudit As Boolean ' Module này có sử dụng Audit hay không
    Public gsAuditForm As String ' Mã và Tên Form cho in báo cáo (Font VNI)
    Public gsAuditReport As String 'Mã và Tên Report in báo cáo (Font VNI)

    Public gsCurrencyID As String

    'Khóa sổ 
    Public Const AuditCodeCloseBook As String = "CloseBook25"
    'Mở sổ 
    Public Const AuditCodeOpenBook As String = "OpenBook25"

    Public EditPermission_D25F2012 As Boolean

    ''' <summary>
    ''' Option của Treeview thiết lập tại màn hình chính F0000
    ''' </summary>
    ''' <remarks></remarks>
    Public giMenuType As Integer = 0 '0: Chuẩn, 1: cá nhân

End Module
