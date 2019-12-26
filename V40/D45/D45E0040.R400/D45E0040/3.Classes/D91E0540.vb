

''' <summary>
''' Các màn hình của exe con D91E0540: Mã phân tích
''' </summary>
Public Enum D91E0540Form
    ''' <summary>
    ''' D91F1301: Danh mục mã phân tích
    ''' </summary>
    D91F1301 = 0
    ''' <summary>
    ''' Thêm mới mã phân tích
    ''' </summary>
    ''' <remarks></remarks>
    D91F1302 = 1
    ''' <summary>
    ''' Thiết lập đối tượng khách hàng
    ''' </summary>
    ''' <remarks></remarks>
    D91F0120 = 2
End Enum

''' <summary>
''' Class D91E0540 dùng để gọi exe D91E0540 Danh mục Mã phân tích hay Danh mục đối tượng
''' </summary>
''' <remarks></remarks>
Public Class D91E0540
    Private Const EXEMODULE As String = "D91"
    Private Const EXECHILD As String = "D91E0540"

    ''' <summary>
    ''' Khởi tạo exe con D91E0540
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
    ''' Khởi tạo exe con D91E0540
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
    Public WriteOnly Property FormActive() As D91E0540Form
        Set(ByVal Value As D91E0540Form)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", [Enum].GetName(GetType(D91E0540Form), Value))
        End Set
    End Property

    ''' <summary>
    ''' Form Phân quyền cho màn hình được gọi D91F1301
    ''' </summary>
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", Value)
        End Set
    End Property

    ''' <summary>
    ''' Trạng thái Form màn hình : AddNew , Edit or View
    ''' </summary>
    Public WriteOnly Property FormStatus() As EnumFormState
        Set(ByVal Value As EnumFormState)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl02", CByte(Value).ToString)
            'D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl02", [Enum].GetName(GetType(EnumFormState), Value))
        End Set
    End Property

    ''' <summary>
    ''' Truyền vào AnaCategatoryID (Mã loại phân tích) dùng cho form D91F1302
    ''' Truyền vào ObjectID (Mã đối tượng) dùng cho form D91F0120
    ''' </summary>
    Public WriteOnly Property KeyID01() As String
        Set(ByVal value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID01", value)
        End Set
    End Property

    ''' <summary>
    ''' Truyền vào AnaCategatoryName (Tên loại phân tích) dùng cho form D91F1302
    ''' Truyền vào ObjectTypeID (Loại đối tượng) dùng cho form D91F0120
    ''' </summary>
    Public WriteOnly Property KeyID02() As String
        Set(ByVal value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID02", value)
        End Set
    End Property

    ''' <summary>
    ''' Truyền vào CompanyID (Mã đối tác) dùng cho form D91F0120
    ''' </summary>
    Public WriteOnly Property KeyID03() As String
        Set(ByVal value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID03", value)
        End Set
    End Property

    ''' <summary>
    ''' Truyền vào IsApproved (Có Duyệt hay không) dùng cho form D91F0120
    ''' </summary>
    Public WriteOnly Property KeyID04() As String
        Set(ByVal value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID04", value)
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
