''' <summary>
''' Định nghĩa các biến truyền qua lại giữa các exe với nhau
''' </summary>
Module D45X0003

    Public Const EXEMODULE As String = "D45"
    Public Const EXED00 As String = "D00E0030"
    Public Const EXEPARENT As String = "D45E0030"
    Public Const EXECHILD As String = "D45E0940"
    '---------------------------------------
    ''' <summary>
    ''' Server truyền vào
    ''' </summary>
    Public PARA_Server As String
    ''' <summary>
    ''' Database truyền vào
    ''' </summary>
    Public PARA_Database As String
    ''' <summary>
    ''' User login vào Lemon3 truyền vào
    ''' </summary>
    Public PARA_ConnectionUser As String
    ''' <summary>
    ''' User login vào Database truyền vào
    ''' </summary>
    Public PARA_UserID As String
    ''' <summary>
    ''' Password user login vào Database truyền vào
    ''' </summary>
    Public PARA_Password As String
    ''' <summary>
    ''' Đơn vị truyền vào
    ''' </summary>
    Public PARA_DivisionID As String
    ''' <summary>
    ''' Tháng kế toán truyền vào
    ''' </summary>
    Public PARA_TranMonth As String
    ''' <summary>
    ''' Năm kế toán truyền vào
    ''' </summary>
    Public PARA_TranYear As String
    ''' <summary>
    ''' Ngôn ngữ truyền vào
    ''' </summary>
    ''' <remarks></remarks>
    Public PARA_Language As EnumLanguage
    ''' <summary>
    ''' Form ID dùng để hiển thị. Ví dụ: DxxFxxxx
    ''' </summary>
    Public PARA_FormID As String
    ''' <summary>
    ''' Form ID dùng để phân quyền. Ví dụ: DxxFxxxx
    ''' </summary>
    Public PARA_FormIDPermission As String
    ''' <summary>
    ''' Trạng thái đóng sổ, mở sổ của kỳ kế toán hiện hành
    ''' </summary>
    ''' <remarks></remarks>
    Public PARA_bClosing As Boolean
    '''' <summary>
    '''' Mã hàng
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_InventoryID As String
    '''' <summary>
    '''' Tên hàng
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_InventoryName As String
    '''' <summary>
    '''' LoÁi nghiÖp vó TransType
    '''' </summary>
    'Public PARA_TransType As String
    '''' <summary>
    '''' Mº cïa phiÕu nhËp/xuÊt/xuÊt VCNB/y£u cÇu xuÊt kho reVoucherID
    '''' </summary>
    'Public PARA_reVoucherID As String = ""
    '''' <summary>
    '''' NghiÖp vó câ ph¶i lª y£u cÇu(=1 nÕu lª y£u cÇu xuÊt kho)
    '''' </summary>
    'Public PARA_Mode As Integer
    '''' <summary>
    '''' Mặc định vị trí xuất theo vị trí nhập gần nhất
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_IsDeliveryLocationDefault As Boolean
    '''' <summary>
    '''' Mặc định vị trí nhập theo vị trí nhập gần nhất
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_IsReceiptLocationDefault As Boolean
    '''' <summary>
    '''' Mã hàng đã chọn vị trí đầy đủ (dùng cho D45F2240)
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_CompletedLocationColor As Int32
    '''' <summary>
    '''' Mã hàng đã chọn vị trí còn dỡ dang (dùng cho D45F2240)
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_InProgressLocationColor As Int32
    '''' <summary>
    '''' Mã hàng chưa đợc chọn vị trí (dùng cho D45F2240)
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_NotInProgressLocationColor As Int32
    '''' <summary>
    '''' Audit - D91T9200
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Audit As Boolean
   
    '''' <summary>
    '''' Màn hình thông tin D45F5558
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_InfoFormCode As String
    '''' <summary>
    '''' Tên form truyền vào để lấy dữ liệu
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_FormName As String
    '''' <summary>
    '''' Dòng hiện tại khi gọi D45F5559
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_RowIndex As Integer
    'Dùng cho D45F6153
    '''' <summary>
    '''' Mã kho
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_WareHouseID As String
    '''' <summary>
    '''' Mã kho xuất VCNB
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_WareHouseID2 As String
    '''' <summary>
    '''' Đơn vị tính
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_UnitID As String
    '''' <summary>
    '''' Mã QC1
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Spec01ID As String
    '''' <summary>
    '''' Mã QC2
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Spec02ID As String
    '''' <summary>
    '''' Mã QC3
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Spec03ID As String
    '''' <summary>
    '''' Mã QC4
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Spec04ID As String
    '''' <summary>
    '''' Mã QC5
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Spec05ID As String
    '''' <summary>
    '''' Mã QC6
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Spec06ID As String
    '''' <summary>
    '''' Mã QC7
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Spec07ID As String
    '''' <summary>
    '''' Mã QC8
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Spec08ID As String
    '''' <summary>
    '''' Mã QC9
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Spec09ID As String
    '''' <summary>
    '''' Mã QC10
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_Spec10ID As String
    'Public PARA_ObjectTypeID As String
    'Public PARA_ObjectID As String
    'Public PARA_KindVoucherID As Integer
    'Public PARA_UseWHUnit As Integer
    'Public PARA_Module As String = ""
    'Public PARA_BatchID As String = ""
    ''Truyen ma form goi man hinh thong tin 
    'Public PARA_FormInfo As String

    'Public PARA_ID01 As String = ""
    'Public PARA_ID02 As String = ""
    'Public PARA_ID03 As String = ""
    'Public PARA_ID04 As String = ""
    'Public PARA_ReportID As String = ""
    'Public PARA_PathReport As String = ""
    ''Goi D45F2015
    'Public PARA_RDVoucherID As String = ""
    'Public PARA_RDVoucherNo As String = ""
    '''' <summary>
    '''' Quyền Khóa phiếu
    '''' </summary>
    '''' <remarks></remarks>
    'Public giPerD45F5557 As Integer
    '''' <summary>
    '''' Tên máy đang sử dụng
    '''' </summary>
    '''' <remarks></remarks>
    'Public PARA_HostID As String
    Public PARA_ModuleID As String = ""
    Public PARA_CreateBy As String
    'Public PARA_Inherit As Boolean = False

    'Public PARA_LanguageReport As Integer = 0
    'Public PARA_ShowPathReport As Boolean = False
End Module
