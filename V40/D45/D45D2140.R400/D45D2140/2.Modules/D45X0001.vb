''' <summary>
''' Module này liên qua đến các khai báo biến, enum, ... toàn cục
''' </summary>
''' <remarks>Các khai báo ở đây không được trùng với các khai báo ở các Module D99Xxxxx</remarks>
Module D45X0001

    ''' <summary>
    ''' Module đang coding D45E0240
    ''' </summary>
    Public Const MODULED45 As String = "D45E0240"
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
    Public Const AuditCodePieceworkVouchers45 As String = "PieceworkVouchers45"
    Public Const AuditCodeDetailPiecework As String = "DetailPiecework"
    Public Const AuditCodePSalaryCalculation As String = "PSalaryCalculation"
    Public Const AuditCodePSalaryResultDeletion As String = "PSalaryResultDeletion"
    Public bCreateVoucherNo_D45F2020 As Boolean = False 'Kiem tra hình D45F2007 dc goi tu Tao phieu cham cong o D45F2020 k?
    Public gsModuleID As String
    Public gsPayrollVoucherID As String = ""
End Module
