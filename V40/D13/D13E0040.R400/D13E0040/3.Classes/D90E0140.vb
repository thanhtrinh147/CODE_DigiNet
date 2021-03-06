Imports System

''' <summary>
''' Các màn hình của exe con D90E0140
''' </summary>
Public Enum D90E0140Form
    ''' <summary>
    ''' D90F0301: Danh mục tài khoản
    ''' D90F5000: Danh mục mã phân bổ
    ''' D90F1000: Danh mục loại nghiệp vụ
    ''' D90F1100: Danh mục loại nghiệp vụ xung tiêu
    ''' D90F1500: Danh mục Nghiệp vụ loại trừ
    ''' D90F5553: Tình trạng khóa sổ
    ''' </summary>
    D90F0301 = 0
    D90F5000 = 1
    D90F1000 = 2
    D90F1100 = 3
    D90F1500 = 4
    D90F5553 = 5
End Enum

Public Class D90E0140
    Private Const EXEMODULE As String = "D90"
    Private Const EXECHILD As String = "D90E0140"
    Private sLanguage As String

    ''' <summary>
    ''' Khởi tạo exe con D90E0140
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
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "AppMode", giAppMode.ToString)
        If giAppMode = 1 Then
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "AppServer", gsAppServer)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "WSSPara01", gsWSSPara01)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "WSSPara02", gsWSSPara02)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "WSSPara03", gsWSSPara03)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "WSSPara04", gsWSSPara04)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "WSSPara05", gsWSSPara05)
        End If

    End Sub

    ''' <summary>
    ''' Khởi tạo exe con D90E0140
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
    Public WriteOnly Property FormActive() As D90E0140Form
        Set(ByVal Value As D90E0140Form)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", [Enum].GetName(GetType(D90E0140Form), Value))
        End Set
    End Property

    ''' <summary>
    ''' Form Phân quyền cho màn hình được gọi
    ''' </summary>
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", Value.ToString)
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

    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID01", Value.ToString)
        End Set
    End Property


    ''' <summary>
    ''' Thực thi exe con
    ''' </summary>
    Public Sub Run()
        If ExistFile(Application.StartupPath & "\" & EXECHILD & ".EXE") Then
            SaveRunningExeSettings(MODULED13, EXECHILD)
            RunExe(Application.StartupPath & "\" & EXECHILD & ".EXE", False)
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
