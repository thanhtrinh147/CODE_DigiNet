Imports System
Public Enum D13E0140Form
    ''' <summary>
    ''' D13F1031
    ''' </summary>
    D13F1031 = 0
    ''' <summary>
    ''' D99F6666
    ''' </summary>
    D99F6666 = 1
    ''' <summary>
    ''' D13F2014
    ''' </summary>
    D13F2014 = 2
    ''' <summary>
    ''' D13F1110
    ''' </summary>
    D13F1110 = 3
    ''' <summary>
    ''' D13F2030
    ''' </summary>
    D13F2030 = 3
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
        'Update 02/11/2010: lưu biến CodeTable xuống Registry
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
    Public WriteOnly Property FormActive() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", Value)
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
    ''' Trạng thái Form màn hình : AddNew , Edit or View
    ''' </summary>
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal Value As EnumFormState)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl02", CType(Value, Integer).ToString)
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
    ''' Thực thi exe con
    ''' </summary>
    Public Function Run() As Boolean
        If Not ExistFile(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe") Then
            Return False
        End If

        Dim pInfo As New System.Diagnostics.ProcessStartInfo(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe")
        pInfo.Arguments = "/DigiNet Corporation"
        pInfo.WindowStyle = ProcessWindowStyle.Normal
        SaveRunningExeSettings(MODULED45, EXECHILD)
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
        SaveRunningExeSettings(MODULED45, EXECHILD)
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
