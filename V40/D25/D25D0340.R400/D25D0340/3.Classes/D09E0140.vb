Imports System.Threading
Public Enum D09E0140Form
    ''' <summary>
    ''' D09
    ''' </summary>
    D09F0101
    D09F0101_b
    D09F0100
    D09F1021
    D09F1061
    D09F1031
    D09F1011
    D09F0901
    D09F2501
    D09F0291
    D09F0431
    D09F1991
    D09F1500
End Enum

Public Class D09E0140
    Private Const EXEMODULE As String = "D09"
    Private Const EXECHILD_ As String = "D09E0140"
    Private sLanguage As String

    ''' <summary>
    ''' Khởi tạo exe con D09E0140
    ''' </summary>
    ''' <param name="Server">Server kết nối đến hệ thống</param>
    ''' <param name="Database">Database kết nối đến hệ thống</param>
    ''' <param name="UserDatabaseID">User Database kết nối đến hệ thống</param>
    ''' <param name="Password">Password kết nối đến hệ thống</param>
    ''' <param name="UserID">User Lemon3 kết nối đến hệ thống</param>
    ''' <param name="Language">Ngôn ngữ sử dụng</param>
    Public Sub New(ByVal Server As String, ByVal Database As String, ByVal UserDatabaseID As String, ByVal Password As String, ByVal UserID As String, ByVal Language As String)
        sLanguage = Language
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "ServerName", Server, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "DBName", Database, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "ConnectionUserID", UserDatabaseID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "Password", Password, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "UserID", UserID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "Language", Language)
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
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "DivisionID", DivisionID)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "TranMonth", TranMonth.ToString)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "TranYear", TranYear.ToString)
        'D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID02", "D09F1031")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "FormState", "")

        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "CodeTable", gbUnicode.ToString)
    End Sub

    ''' <summary>
    ''' Màn hình cần hiển thị cho exe con
    ''' </summary>
    Public WriteOnly Property FormActive() As D09E0140Form
        Set(ByVal Value As D09E0140Form)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "Ctrl01", [Enum].GetName(GetType(D09E0140Form), Value))
        End Set
    End Property

    ''' <summary>
    ''' Màn hình phân quyền cho exe con
    ''' </summary>
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "Ctrl03", Value)
        End Set
    End Property

    ''' <summary>
    ''' FormState
    ''' </summary>
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal Value As EnumFormState)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "FormState", CType(Value, Integer).ToString)
        End Set
    End Property


    ''' <summary>
    ''' Mode
    ''' </summary>
    Public WriteOnly Property In_Mode() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "Mode", Value)
        End Set
    End Property

    Public WriteOnly Property ID01() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "ID01", Value)
        End Set
    End Property


    ''' <summary>
    ''' EmployeeID
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "EmployeeID", Value)
        End Set
    End Property

    ''' <summary>
    ''' RefEmployeeID
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property RefEmployeeID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "RefEmployeeID", Value)
        End Set
    End Property


    ''' <summary>
    ''' Mã thẻ chấm công
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property AttendanceCardNo() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "AttendanceCardNo", Value)
        End Set
    End Property

    ' '' <summary>
    '''' TransTypeID
    '''' </summary>
    '''' <value></value>
    '''' <remarks></remarks>
    Public WriteOnly Property TransTypeID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "TranTypeID", Value)
        End Set
    End Property

    Public WriteOnly Property IsCallFromD09F2225() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "IsCallFromD09F2225", "0")
        End Set
    End Property

    Public WriteOnly Property IsCallFromD09F000() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "IsCallFromD09F000", "False")
        End Set
    End Property

    Public ReadOnly Property Output01() As String
        Get
            Return D99C0007.GetOthersSetting(EXEMODULE, EXECHILD_, "Output01", "0")
        End Get
    End Property

    ''' <summary>
    ''' SavedOK
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public ReadOnly Property Out_SavedOK() As String
        Get
            Return D99C0007.GetOthersSetting(EXEMODULE, EXECHILD_, "SavedOK", "0")
        End Get
    End Property

    ''' <summary>
    ''' TransID mới thêm vào D09T2060
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public ReadOnly Property OutNewTransID() As String
        Get
            Return D99C0007.GetOthersSetting(EXEMODULE, EXECHILD_, "OutNewTransID", "")
        End Get
    End Property


    ''' <summary>
    ''' EmployeeID mới thêm vào D09T0201
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public ReadOnly Property OutNewEmployeeID() As String
        Get
            Return D99C0007.GetOthersSetting(EXEMODULE, EXECHILD_, "OutNewEmployeeID", "")
        End Get
    End Property

    Public ReadOnly Property Out_Formula() As String
        Get
            Return D99C0007.GetOthersSetting(EXEMODULE, EXECHILD_, "Formula_D09F0005", "")
        End Get
    End Property

    ''' <summary>
    ''' OldEmployeeID
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property OldEmployeeID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "OldEmployeeID", Value)
        End Set
    End Property

    ''' <summary>
    ''' OldEmployeeName
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property OldEmployeeName() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "OldEmployeeName", Value)
        End Set
    End Property

    ''' <summary>
    ''' DepartmentID
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "DepartmentID", Value)
        End Set
    End Property


    ''' <summary>
    ''' TeamID
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "TeamID", Value)
        End Set
    End Property

    Public Sub Run()
        If Not ExistFile(My.Application.Info.DirectoryPath & "\" & EXECHILD_ & ".exe") Then Exit Sub
        Dim pInfo As New System.Diagnostics.ProcessStartInfo(My.Application.Info.DirectoryPath & "\" & EXECHILD_ & ".exe")
        pInfo.Arguments = "/DigiNet Corporation"
        pInfo.WindowStyle = ProcessWindowStyle.Normal
        Process.Start(pInfo)

    End Sub

    Private Function ExistFile(ByVal Path As String) As Boolean
        If System.IO.File.Exists(Path) Then Return True
        If sLanguage = "0" Then
            D99C0008.MsgL3("Không tồn tại file " & EXECHILD_ & ".exe")
        Else
            D99C0008.MsgL3("Not exist file" & EXECHILD_ & ".exe")
        End If
        Return False
    End Function

   
End Class
