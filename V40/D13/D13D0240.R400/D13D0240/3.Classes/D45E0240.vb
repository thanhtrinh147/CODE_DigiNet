Imports System
''' <summary>
''' Các màn hình của exe con D45E0240
''' </summary>
Public Enum D45E0240Form
    ''' <summary>
    ''' D45F2006: Điều chỉnh phiếu
    ''' </summary>
    D45F2006 = 0
End Enum

Public Class D45E0240
    Private Const EXEMODULE As String = "D45"
    Private Const EXECHILD As String = "D45E0240"

    ''' <summary>
    ''' Khởi tạo exe con D45E0240
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
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "CodeTable", gbUnicode.ToString)
    End Sub

    ''' <summary>
    ''' Khởi tạo exe con D45E0240
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
    Public WriteOnly Property FormActive() As D45E0240Form
        Set(ByVal Value As D45E0240Form)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", [Enum].GetName(GetType(D45E0240Form), Value))
        End Set
    End Property

    ''' <summary>
    ''' Màn hình phân quyền
    ''' </summary>
    Public WriteOnly Property FormPermision() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", Value)
        End Set
    End Property

    ''' <summary>
    ''' 0 : AddNew
    ''' 1 : Edit
    ''' 2 : Edit Other
    ''' 3 : View
    ''' </summary>
    Public WriteOnly Property FormState() As Integer
        Set(ByVal value As Integer)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "FormState", CByte(value).ToString)
        End Set
    End Property

    ''' <summary>
    ''' ProductVoucherID
    ''' </summary>
    Public WriteOnly Property ProductVoucherID() As String
        Set(ByVal value As String)

            If value Is Nothing Then
                value = ""
            End If
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ProductVoucherID", value)
        End Set
    End Property

    ''' <summary>
    ''' PayrollVoucherID
    ''' </summary>
    Public WriteOnly Property PayrollVoucherID() As String
        Set(ByVal value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "PayrollVoucherID", value)
        End Set
    End Property

    ''' <summary>
    ''' SalaryVoucherID
    ''' </summary>
    Public WriteOnly Property SalaryVoucherID() As String
        Set(ByVal value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SalaryVoucherID", value)
        End Set
    End Property

    ''' <summary>
    ''' Mode
    ''' </summary>
    Public WriteOnly Property Mode() As Integer
        Set(ByVal value As Integer)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Mode", value.ToString)
        End Set
    End Property

    ''' <summary>
    ''' EmployeeID
    ''' </summary>
    Private _employeeID As String
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID01", Value.ToString)
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
        SaveRunningExeSettings(MODULED13, EXECHILD)
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
