Imports System
Public Enum enumD13E0140Form
    D13F1030 'Danh mục ---> A. Hồ sơ lương gốc
    D13F1000 'Danh mục ---> B. Khoản điều chỉnh thu nhập
    D13F1130 'Danh mục ---> C. Loại nghiệp vụ
    D13F1010 'Danh mục ---> D. Đối tượng thuế thu nhập
    D13F1140 'Danh mục ---> E. Đối tượng tính lương
    D13F1080 'Danh mục ---> F. Thưởng theo thâm niên
    D13F1070 'Danh mục ---> G. Đánh giá xếp loại
    D13F1040 'Danh mục ---> H. Ngạch lương
    D13F1050 'Danh mục ---> I. Bậc lương
    D13F1060 'Danh mục ---> J. Danh mục template tăng thông số lương
    D13F1160 'Danh mục ---> K. Thông số lương mặc định
    D13F1090 'Danh mục ---> L. Mã phân tích tiền lương
    D13F1100 'Danh mục ---> M. Bảng tham chiếu kết quả
    D13F1150 'Danh mục ---> N. Phương pháp điều chỉnh lương
    D13F2050 'Danh mục ---> O. Phương pháp tính lương
    D13F2160 'Danh mục ---> P. Phương pháp chuyển bút toán
    D13F2060 'Danh mục ---> P. Phương pháp chuyển bút toán
    D13F2165 'Danh mục ---> Q. Cơ chế chuyển bút toán

    D13F2014 'Mở hồ sơ lương phụ
    D13F2030 'Truy vấn chuyển công sang phép
    D13F2025 'Kế thừa dữ liệu

    D13F0010 'Hệ thống ---> C. Thiết lập khác/1. Hệ số sử dụng
    D13F4050 'Báo cáo ---> A. Hồ sơ lương
End Enum

Public Class D13E0140
    Private Const EXEMODULE As String = "D13"
    Private Const EXECHILD As String = "D13E0140"
    Private sLanguage As String

    ''' <summary>
    ''' Khởi tạo exe con D13E0140
    ''' </summary>
    ''' <param name="Server">Server kết nối đến hệ thống</param>
    ''' <param name="Database">Database kết nối đến hệ thống</param>
    ''' <param name="UserDatabaseID">User Database kết nối đến hệ thống</param>
    ''' <param name="Password">Password kết nối đến hệ thống</param>
    ''' <param name="UserID">User Lemon3 kết nối đến hệ thống</param>
    ''' <param name="Language">Ngôn ngữ sử dụng</param>
    Public Sub New(ByVal Server As String, ByVal Database As String, ByVal UserDatabaseID As String, ByVal Password As String, ByVal UserID As String, ByVal Language As String)
        sLanguage = Language
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ServerName", Server, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DBName", Database, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", UserDatabaseID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Password", Password, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "UserID", UserID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Language", Language)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "CodeTable", gbUnicode.ToString)
    End Sub

    ''' <summary>
    ''' Khởi tạo exe con D91E0130
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
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID02", "D13F1031")
    End Sub

    ''' <summary>
    ''' Màn hình cần hiển thị cho exe con
    ''' </summary>
    Public WriteOnly Property FormActive() As enumD13E0140Form
        Set(ByVal Value As enumD13E0140Form)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", [Enum].GetName(GetType(enumD13E0140Form), Value))
        End Set
    End Property
    'Public WriteOnly Property FormActive() As String
    '    Set(ByVal Value As String)
    '        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", Value)
    '    End Set
    'End Property

    ''' <summary>
    ''' Màn hình phân quyền cho exe con
    ''' </summary>
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", Value)
        End Set
    End Property

    ''' <summary>
    ''' FormState
    ''' </summary>
    Public WriteOnly Property In_FormState() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "FormState", Value)
        End Set
    End Property

    ''' <summary>
    ''' Truyền vào ID01
    ''' </summary>
    Public WriteOnly Property ID01() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID01", Value)
        End Set
    End Property

    ''' <summary>
    ''' Truyền vào ID02
    ''' </summary>
    Public WriteOnly Property ID02() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID02", Value)
        End Set
    End Property

    ''' <summary>
    ''' Truyền vào ID03
    ''' </summary>
    Public WriteOnly Property ID03() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID03", Value)
        End Set
    End Property

    ''' <summary>
    ''' Truyền vào ID04
    ''' </summary>
    Public WriteOnly Property ID04() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID04", Value)
        End Set
    End Property

    ''' <summary>
    ''' DepartmentID
    ''' </summary>
    Public WriteOnly Property In_DepartmentID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DepartmentID", Value)
        End Set
    End Property

    ''' <summary>
    ''' TeamID
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property In_TeamID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TeamID", Value)
        End Set
    End Property

    ''' <summary>
    ''' EmployeeID
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property In_EmployeeID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "EmployeeID", Value)
        End Set
    End Property

    ''' <summary>
    ''' SavedOK
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public ReadOnly Property Out_SavedOK() As String
        Get
            Return D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "0")
        End Get
    End Property

    ''' <summary>
    ''' Truyền vào PayrollVoucherID
    ''' </summary>
    Public WriteOnly Property PayrollVoucherID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "PayrollVoucherID", Value)
        End Set
    End Property

    ''' <summary>
    ''' Truyền vào FormID: là form cha của D99F6666: màn hình chọn đường dẫn báo cáo
    ''' </summary>
    Public WriteOnly Property CallFromFormID() As String
        Set(ByVal value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "CallFromFormID", value)
        End Set
    End Property

    ''' <summary>
    ''' Trả về tên báo cáo
    ''' </summary>
    Public ReadOnly Property StandardForm() As String
        Get
            Return D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "StandardForm", "")
        End Get
    End Property

    ''' <summary>
    ''' Trả về đường dẫn báo cáo
    ''' </summary>
    Public ReadOnly Property ReportPath() As String
        Get
            Return D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "gsReportPath", "")
        End Get
    End Property

    ''' <summary>
    ''' Code Table chuyển Unicode
    ''' </summary>
    Public WriteOnly Property CodeTable() As String
        Set(ByVal Value As String)
            ' D99C0007.SaveModulesSetting(EXEMODULE, ModuleOption.lmOptions, "CodeTable", D13Options.CodeTable.ToString)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "CodeTable", gbUnicode.ToString)
        End Set
    End Property

    ''' <summary>
    ''' Thực thi exe con
    ''' </summary>
    Public Function Run() As Boolean
        If Not ExistFile(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe") Then
            Return False
        End If

        Dim pInfo As New System.Diagnostics.ProcessStartInfo(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe")
        pInfo.Arguments = "/DigiNet Corporation"
        pInfo.WindowStyle = ProcessWindowStyle.Normal
        SaveRunningExeSettings(MODULED13, EXECHILD)
        Process.Start(pInfo)
        Return True
    End Function

    ''' <summary>
    ''' Thực thi exe con và chờ kết quả trả về
    ''' </summary>
    Public Sub RunAndWait()
        If Not ExistFile(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe") Then Exit Sub
        Dim pInfo As New System.Diagnostics.ProcessStartInfo(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe")
        pInfo.Arguments = "/DigiNet Corporation"
        pInfo.WindowStyle = ProcessWindowStyle.Normal
        SaveRunningExeSettings(MODULED13, EXECHILD)
        Process.Start(pInfo).WaitForExit()
    End Sub

    ''' <summary>
    ''' Kiểm tra tồn tại exe con không ?
    ''' </summary>
    Private Function ExistFile(ByVal Path As String) As Boolean
        If System.IO.File.Exists(Path) Then Return True
        If sLanguage = "0" Then
            D99C0008.MsgL3("Không tồn tại file " & EXECHILD & ".exe")
        Else
            D99C0008.MsgL3("Not exist file" & EXECHILD & ".exe")
        End If
        Return False
    End Function
End Class
