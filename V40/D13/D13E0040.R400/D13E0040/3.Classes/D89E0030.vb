''' <summary>
''' Các màn hình của exe con D91E0130
''' </summary>
Public Enum D89E0030Form
    ''' <summary>
    ''' D89F9100
    ''' </summary>
    D89F9100 = 0
End Enum

Public Class D89E0030
    Private Const EXEMODULE As String = "D89"
    Private Const EXECHILD As String = "D89E0030"
    Private sLanguage As String

    ''' <summary>
    ''' Khởi tạo exe con D89E0030
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
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID02", "D89F9100")
    End Sub

    ''' <summary>
    ''' Màn hình cần hiển thị cho exe con
    ''' </summary>
    Public WriteOnly Property FormActive() As D89E0030Form
        Set(ByVal Value As D89E0030Form)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", [Enum].GetName(GetType(D89E0030Form), Value))
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
    ''' ModuleName
    ''' </summary>
    Public WriteOnly Property In_ModuleName() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID01", Value)
        End Set
    End Property

    '''' <summary>
    '''' KeyID02
    '''' </summary>
    'Public WriteOnly Property In_KeyID() As String
    '    Set(ByVal Value As String)
    '        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID02", Value)
    '    End Set
    'End Property

    ''' <summary>
    ''' Thực thi exe con
    ''' </summary>
    Public Sub Run()
        If ExistFile(Application.StartupPath & "\" & EXECHILD & ".EXE") Then
            SaveRunningExeSettings(MODULED13, EXECHILD)
            RunExe(Application.StartupPath & "\" & EXECHILD & ".EXE")
        Else
            If sLanguage = "84" Then
                D99C0008.MsgL3("Không tồn tại file " & EXECHILD & ".exe")
            Else
                D99C0008.MsgL3("Not exist file" & EXECHILD & ".exe")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Nếu gọi Exe con có giá trị trả về thì bReturn = true
    ''' Ngược lại thì bReturn = false
    ''' </summary>
    Private Sub RunExe(ByVal Path As String, Optional ByVal bReturn As Boolean = False)
        SaveRunningExeSettings(MODULED13, EXECHILD)
        If bReturn = False Then
            Shell(Path & " " & "/DigiNet Corporation", vbNormalFocus)
        Else
            Shell(Path & " " & "/DigiNet Corporation", vbNormalFocus, True)
        End If
    End Sub

    ''' <summary>
    ''' Kiểm tra tồn tại exe con không ?
    ''' </summary>
    Private Function ExistFile(ByVal Path As String) As Boolean
        If System.IO.File.Exists(Path) Then Return True
        Return False
    End Function
End Class
