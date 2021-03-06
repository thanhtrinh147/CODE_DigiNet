Imports System.Threading
Public Enum D09E0940Form
    ''' <summary>
    ''' D09
    ''' </summary>
    D09F0150
End Enum

Public Class D09E0940
    Private Const EXEMODULE As String = "D09"
    Private Const EXECHILD_ As String = "D09E0940"
    Private sLanguage As String

    ''' <summary>
    ''' Khởi tạo exe con D09E0940
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
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "CodeTable", gbUnicode.ToString)
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
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "FormState", "0")
    End Sub

    ''' <summary>
    ''' Màn hình cần hiển thị cho exe con
    ''' </summary>
    Public WriteOnly Property FormActive() As D09E0940Form
        Set(ByVal Value As D09E0940Form)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "Ctrl01", [Enum].GetName(GetType(D09E0940Form), Value))
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

    Public WriteOnly Property ID01() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "ID01", Value)
        End Set
    End Property

    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD_, "ModuleID", Value)
        End Set
    End Property

    Public Sub Run()
        If Not ExistFile(My.Application.Info.DirectoryPath & "\" & EXECHILD_ & ".exe") Then Exit Sub
        Dim pInfo As New System.Diagnostics.ProcessStartInfo(My.Application.Info.DirectoryPath & "\" & EXECHILD_ & ".exe")
        pInfo.Arguments = "/DigiNet Corporation"
        pInfo.WindowStyle = ProcessWindowStyle.Normal
        Dim sExe As String = System.Reflection.Assembly.GetExecutingAssembly.GetName().Name
        SaveRunningExeSettings(sExe, EXECHILD_)
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
