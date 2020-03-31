Imports System

''' <summary>
''' Class DxxExx40 dùng để gọi các exe DxxExx40
''' </summary>
''' <remarks></remarks>
Public Class DxxExx40
    Dim sModuleID As String = ""

    Private _exeName As String = ""
    Public WriteOnly Property ExeName() As String
        Set(ByVal Value As String)
            _exeName = Value
        End Set
    End Property

    Public Sub New()

    End Sub
    ''' <summary>
    ''' Khởi tạo exe con DxxExx40
    ''' </summary>
    ''' <param name="Server">Server kết nối đến hệ thống</param>
    ''' <param name="Database">Database kết nối đến hệ thống</param>
    ''' <param name="UserDatabaseID">User Database kết nối đến hệ thống</param>
    ''' <param name="Password">Password kết nối đến hệ thống</param>
    ''' <param name="UserID">User Lemon3 kết nối đến hệ thống</param>
    ''' <param name="Language">Ngôn ngữ sử dụng</param>
    Public Sub New(ByVal ExeName As String, ByVal Server As String, ByVal Database As String, ByVal UserDatabaseID As String, ByVal Password As String, ByVal UserID As String, ByVal Language As String)
        _exeName = ExeName
        sModuleID = L3Left(ExeName, 3)

        D99C0007.SaveOthersSetting(sModuleID, _exeName, "ServerName", Server, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "DBName", Database, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "ConnectionUserID", UserDatabaseID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "Password", Password, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "UserID", UserID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "Language", Language)

        'gbUnicode: True(Nhập liệu Unicode)/False(Nhập liệu VNI)
        'gbUseD54: True(Sử dụng Dự án, Hạng mục)/False (Không sử dụng Dự án, Hạng mục)
        'gbPrintVNI: Có sử dụng In báo cáo VNI hay không khi nhập liệu Unicode
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "CodeTable", gbUnicode.ToString)
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "UseD54", gbUseD54.ToString)
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "IsPrintVNI", gbPrintVNI.ToString)
    End Sub

    ''' <summary>
    ''' Khởi tạo exe con DxxExx40
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
    Public Sub New(ByVal ExeName As String, ByVal Server As String, ByVal Database As String, ByVal UserDatabaseID As String, ByVal Password As String, ByVal UserID As String, ByVal Language As String, ByVal DivisionID As String, ByVal TranMonth As Integer, ByVal TranYear As Integer)
        Me.New(ExeName, Server, Database, UserDatabaseID, Password, UserID, Language)

        D99C0007.SaveOthersSetting(sModuleID, _exeName, "DivisionID", DivisionID)
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "TranMonth", TranMonth.ToString)
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "TranYear", TranYear.ToString)

        D99C0007.SaveOthersSetting(sModuleID, _exeName, "Closed", gbClosed.ToString)
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "CreateBy", gsCreateBy) 'gsCreateBy: Lấy giá Người tạo
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "LockL3UserID", gbLockL3UserID.ToString) 'gbLockL3UserID: Lấy giá trị Khóa người dùng Lemon3
        '*********************************
        Dim sExe As String = System.Reflection.Assembly.GetExecutingAssembly.GetName.Name
        D99C0007.SaveOthersSetting(sModuleID, _exeName, "ModuleID", sExe.Substring(1, 2))
    End Sub

    ''' <summary>
    ''' Màn hình cần hiển thị cho exe con
    ''' </summary>
    Public WriteOnly Property FormActive() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(sModuleID, _exeName, "Ctrl01", Value)
        End Set
    End Property

    ''' <summary>
    ''' Form Phân quyền cho màn hình được gọi 
    ''' </summary>
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(sModuleID, _exeName, "Ctrl03", Value)
        End Set
    End Property

    Public WriteOnly Property IDxx(ByVal sKeyID As String) As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(sModuleID, _exeName, sKeyID, Value)
        End Set
    End Property

    Public ReadOnly Property OutputXX(ByVal sModuleID As String, ByVal _exeName As String, ByVal sKeyID As String) As String
        Get
            Return D99C0007.GetOthersSetting(sModuleID, _exeName, sKeyID, "")
        End Get
    End Property

    ''' <summary>
    ''' Thực thi exe con
    ''' </summary>
    Public Sub Run()
        If Not ExistFile(gsApplicationSetup & "\" & _exeName & ".exe") Then Exit Sub
        Dim pInfo As New System.Diagnostics.ProcessStartInfo(gsApplicationSetup & "\" & _exeName & ".exe")
        pInfo.Arguments = "/DigiNet Corporation"
        pInfo.WindowStyle = ProcessWindowStyle.Normal
        '*************************
        Dim sExe As String = System.Reflection.Assembly.GetExecutingAssembly.GetName.Name
        SaveRunningExeSettings(sExe, _exeName)
        '*************************
        Process.Start(pInfo)
    End Sub

    ''' <summary>
    ''' Kiểm tra tồn tại exe con không ?
    ''' </summary>
    Private Function ExistFile(ByVal Path As String) As Boolean
        If System.IO.File.Exists(Path) Then Return True
        If geLanguage = EnumLanguage.Vietnamese Then
            D99C0008.MsgL3("Không tồn tại file " & _exeName & ".exe")
        Else
            D99C0008.MsgL3("Not exist file " & _exeName & ".exe")
        End If
        Return False
    End Function

End Class
