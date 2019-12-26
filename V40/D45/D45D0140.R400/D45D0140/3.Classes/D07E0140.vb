

''' <summary>
''' Các màn hình của exe con D07E0140
''' </summary>
Public Enum D07E0140Form
    'Danh mục Kho hàng
    D07F0005 = 0
    'Danh mục Đơn vị tính
    D07F0009 = 1
    'Danh mục Bảng chuyển đổi đơn vị tính
    D07F0018 = 2
    'Ký hiệu công thức
    D07F0112 = 3
    'Thiết lập loại quy cách
    D07F0410 = 4
    'Danh mục phân loại hàng tồn kho
    D07F1111 = 5
    'Danh mục trạng thái phiếu yêu cầu xuất kho
    D07F1201 = 6
    'Danh mục lô hàng
    D07F1210 = 7
    'Thêm mới lô hàng
    D07F1211 = 8
    'Danh mục công thức
    D07F1231 = 9
    'Danh mục vị trí
    D07F1310 = 10
    'Danh mục quy cách hàng tồn kho
    D07F1410 = 11
    'Bảng lịch sử quy cách hàng tồn kho (Chuyển từ D07E0240 sang)
    D07F1420 = 12
    'Bộ chỉ số hàng tồn kho
    D07F1430 = 13
    'Danh mục Loại nghiệp vụ
    D07F1440 = 14
    'Danh mục phương pháp phân tích tuổi nợ
    D07F1510 = 15
    'In theo định mức
    D07F0222 = 16
    'Khoá phiếu
    D07F5557 = 17
    'Thiết lập loại mã phân tích
    D07F0075 = 18
    'Thiết lập thông tin phụ
    D07F0038 = 19
    'Phương pháp tạo mã hàng
    D07F0040 = 20
    'Danh mục -> Danh mục Kit
    D07F0042 = 21
    'Danh mục sản phẩm (sử dụng cho D17)
    D07F1002 = 22
    'Báo cáo đơn vị tính qui đổi
    D07F4400 = 23
    'Thiết lập phương pháp bình quân gia quyền cuối kỳ
    D07F0500 = 24
    'Danh mục hàng tồn kho
    D07F0010 = 25
    'Cập nhật Đơn vị tính
    D07F0012 = 26
End Enum

''' <summary>
''' Class D07E0140 dùng để gọi exe D07E0140
''' </summary>
''' <remarks></remarks>
Public Class D07E0140
    Private Const EXEMODULE As String = "D07"
    Private Const EXECHILD As String = "D07E0140"

    ''' <summary>
    ''' Khởi tạo exe con D07E0140
    ''' </summary>
    ''' <param name="Server">Server kết nối đến hệ thống</param>
    ''' <param name="Database">Database kết nối đến hệ thống</param>
    ''' <param name="UserDatabaseID">User Database kết nối đến hệ thống</param>
    ''' <param name="Password">Password kết nối đến hệ thống</param>
    ''' <param name="UserID">User Lemon3 kết nối đến hệ thống</param>
    ''' <param name="Language">Ngôn ngữ sử dụng</param>
    Public Sub New(ByVal Server As String, ByVal Database As String, ByVal UserDatabaseID As String, ByVal Password As String, ByVal UserID As String, ByVal Language As String)

        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ServerName", Server, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DBName", Database, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", UserDatabaseID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Password", Password, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "UserID", UserID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Language", Language)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "AppMode", giAppMode.ToString)
    End Sub

    ''' <summary>
    ''' Khởi tạo exe con D07E0140
    ''' </summary>
    ''' <param name="Server">Server kết nối đến hệ thống</param>
    ''' <param name="Database">Database kết nối đến hệ thống</param>
    ''' <param name="UserDatabaseID">User Database kết nối đến hệ thống</param>
    ''' <param name="Password">Password kết nối đến hệ thống</param>
    ''' <param name="UserID">User Lemon3 kết nối đến hệ thống</param>
    ''' <param name="Language">Ngôn ngữ sử dụng</param>
    ''' <param name="DivisionID">Đơn vị hiện tại</param>
    ''' <param name="TranMonth">Tháng kế toán hiện tại</param>
    ''' <param name="TranYear">Năm kế toán hiện tại</param>
    Public Sub New(ByVal Server As String, ByVal Database As String, ByVal UserDatabaseID As String, ByVal Password As String, ByVal UserID As String, ByVal Language As String, ByVal DivisionID As String, ByVal TranMonth As Integer, ByVal TranYear As Integer)
        Me.New(Server, Database, UserDatabaseID, Password, UserID, Language)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DivisionID", DivisionID)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranMonth", TranMonth.ToString)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranYear", TranYear.ToString)
    End Sub

    ''' <summary>
    ''' Màn hình cần hiển thị cho exe con
    ''' </summary>
    Public WriteOnly Property FormActive() As D07E0140Form
        Set(ByVal Value As D07E0140Form)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", [Enum].GetName(GetType(D07E0140Form), Value))
        End Set
    End Property

    ''' <summary>
    ''' Form Phân quyền cho màn hình được gọi 
    ''' </summary>
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", Value)
        End Set
    End Property


    ''' <summary>
    ''' Type dùng khi gọi màn hình D07F0112
    ''' </summary>
    Public WriteOnly Property Type() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Type", Value)
        End Set
    End Property

    ''' <summary>
    ''' Trả về Khóa chính
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property Output01() As String
        Get
            Return D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Output01", "")
        End Get
    End Property

    ''' <summary>
    ''' Thực thi exe con
    ''' </summary>
    Public Sub Run()
        If Not ExistFile(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe") Then Exit Sub
        Dim pInfo As New System.Diagnostics.ProcessStartInfo(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe")
        pInfo.Arguments = "/DigiNet Corporation"
        pInfo.WindowStyle = ProcessWindowStyle.Normal
        SaveRunningExeSettings(MODULED45, EXECHILD)
        Process.Start(pInfo)
    End Sub

    ''' <summary>
    ''' Kiểm tra tồn tại exe con không ?
    ''' </summary>
    Private Function ExistFile(ByVal Path As String) As Boolean
        If System.IO.File.Exists(Path) Then Return True
        If geLanguage = EnumLanguage.Vietnamese Then
            D99C0008.MsgL3("Không tồn tại file " & EXECHILD & ".exe")
        Else
            D99C0008.MsgL3("Not exist file " & EXECHILD & ".exe")
        End If
        Return False
    End Function

End Class
