''' <summary>
''' Module này liên qua đến các khai báo biến, enum, ... toàn cục
''' </summary>
''' <remarks>Các khai báo ở đây không được trùng với các khai báo ở các Module D99Xxxxx</remarks>
Module D45X0001

    ''' <summary>
    ''' Module đang coding D45E0240
    ''' </summary>
    Public Const MODULED45 As String = "D45E0140"
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
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_SECTION As String = "HandshakeR360"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_MODULE As String = "D45"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_VALUE As String = "R3.60.00.Y2007"

    ''''Dùng cho ktra co lưu thành công k?
    Public gbSavedOK As Boolean = False

    Public bIsUseBlock As Boolean 'Ktra Khoi co duoc thiet lap chua?
    'Các AuditCode của AuditLog
    Public Const AuditCodeProducts As String = "Products"
    Public Const AuditCodeStages As String = "Stages"
    Public Const AuditCodePriceLists As String = "PriceLists"
    Public Const AuditCodeStandardRoutings As String = "StandardRoutings"
    Public Const AuditCodeTransactionTypes As String = "TransactionTypes"
    Public Const AuditCodePieceworkVouchers45 As String = "PieceworkVouchers45"
    Public Const AuditCodePieceworkCalMethodID As String = "PieceworkCalMethodID"

End Module
