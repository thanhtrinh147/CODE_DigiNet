Imports System
Imports System.Threading
Public Enum D09E0240Form
    ''' <summary>
    ''' D09
    ''' </summary>
    D09F2011  ' Hợp đồng lao động cá nhân
    D09F2010  'Hợp đồng lao động hàng loạt
    D09F2050  'Giảm/Tăng lao động 
    D09F5605  'Đăng ký nhân sự
    D09F2222  'Nghiệp vụ nhân sự
    D09F2223  'Nghiệp vụ nhân sự
    D09F2060  'Điều chuyển lao động
    D09F2070 'Kế hoạch nhân sự
    D09F3020  'Điều chỉnh lương
    D09F1979  'Cấp quản lý
    D09F0411  'Thống kê nhân sự
    D09F3070 'Truy vấn kế hoạch nhân sự
    D09F1980 'Lịch sử lương nhân viên
    D09F5888 'Hợp đồng lao động
    D09F3010 'Danh sách nhân viên sắp có sinh nhật
    D09F3080 'Thay đổi cấp bậc quân hàm
    D09F3090 'Khen thưởng / kỷ luật
    D09F3100 'Quá trình công tác
    D09F3110 'Bổ nhiệm
    D09F3120 'Đề xuất điều chỉnh lương
    D09F2000 'Lập đề xuất điều chỉnh lương
    D09F2020 'Duyệt đề xuất điều chỉnh lương
    D09F2021 '
    D09F2040 ' Phụ lục HĐLĐ
    D09F2080 'Cập nhật quân hàm
End Enum

Public Class D09E0240
    Private Const EXEMODULE As String = "D09"
    Private Const EXECHILD As String = "D09E0240"
    Private sLanguage As String

    ''' <summary>
    ''' Khởi tạo exe con D09E0240
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
    ''' Khởi tạo exe con D09E0240
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
        'D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID02", "D09F1031")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "FormState", "")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Closed", gbClosed.ToString)
    End Sub

    ''' <summary>
    ''' Màn hình cần hiển thị cho exe con
    ''' </summary>
    Public WriteOnly Property FormActive() As D09E0240Form
        Set(ByVal Value As D09E0240Form)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", [Enum].GetName(GetType(D09E0240Form), Value))
        End Set
    End Property

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
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal Value As EnumFormState)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "FormState", CType(Value, Integer).ToString)
        End Set
    End Property

    '''' <summary>
    '''' FormState
    '''' </summary>
    'Public WriteOnly Property FormState() As String
    '    Set(ByVal Value As String)
    '        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "FormState", Value)
    '    End Set
    'End Property


    ' '' <summary>
    '''' TranTypeID
    '''' </summary>
    '''' <value></value>
    '''' <remarks></remarks>
    Public WriteOnly Property TranTypeID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranTypeID", Value)
        End Set
    End Property


    ' '' <summary>
    '''' ContractID
    '''' </summary>
    '''' <value></value>
    '''' <remarks></remarks>
    Public WriteOnly Property ContractID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ContractID", Value)
        End Set
    End Property

    ''' <summary>
    ''' Mode: Mode=0:Điều chuyển lao động, Mode=1:Tăng lao động, Mode=2: Giảm lao động, Mode=3: Điều chỉnh lương
    ''' </summary>
    Public WriteOnly Property Mode() As Integer
        Set(ByVal Value As Integer)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Mode", Value.ToString)
        End Set
    End Property

    ''' <summary>
    ''' DepartmentID
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DepartmentID", Value)
        End Set
    End Property

    ''' <summary>
    ''' TeamID
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TeamID", Value)
        End Set
    End Property

    ''' <summary>
    ''' EmployeeID
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "EmployeeID", Value)
        End Set
    End Property


    ''' <summary>
    ''' EmployeeID
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ModuleID", Value)
        End Set
    End Property


    ''' <summary>
    ''' Key01ID='F_EmployeeID'
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property Key01ID() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Key01", Value)
        End Set
    End Property


    ''' <summary>
    ''' Key02ID='C_TranTypeID'
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property Key02ID() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Key02", Value)
        End Set
    End Property


    ''' <summary>
    ''' Key03ID='F_Times'
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property Key03ID() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Key03", Value)
        End Set
    End Property


    ''' <summary>
    ''' Key04ID='F_LastTime'
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property Key04ID() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""

            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Key04", Value)
        End Set
    End Property


    ''' <summary>
    ''' Key05ID=''
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property Key05ID() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Key05", Value)
        End Set
    End Property


    Public WriteOnly Property IsCallFromD09F2225() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "IsCallFromD09F2225", Value)
        End Set
    End Property

    Private _isProposal As String
    Public WriteOnly Property IsProposal() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "IsProposal", Value)
        End Set
    End Property

    ''' <summary>
    ''' Thực thi exe con
    ''' </summary>
    Public Sub Run()
        If Not ExistFile(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe") Then Exit Sub
        Dim pInfo As New System.Diagnostics.ProcessStartInfo(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe")
        pInfo.Arguments = "/DigiNet Corporation"
        pInfo.WindowStyle = ProcessWindowStyle.Normal
        SaveRunningExeSettings(MODULED25, EXECHILD)
        Process.Start(pInfo)
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
