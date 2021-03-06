Imports System
Public Class D45F4000

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private ChildName As String = "D45E0340"

    Private exe As D45E0340
    'Phân biệt các form được gọi trong class D07E0140
    Private _formName As String = ""
    Public WriteOnly Property FormName() As String
        Set(ByVal Value As String)
            _formName = Value
        End Set
    End Property

    Private _FormActive As D45E0340Form
    Public WriteOnly Property FormActive() As D45E0340Form
        Set(ByVal Value As D45E0340Form)
            _FormActive = Value
        End Set
    End Property

    Private _formPermission As String = ""
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property

    Private _DepartmentID As String = ""
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _DepartmentID = Value
        End Set
    End Property

    Private _TeamID As String = ""
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _TeamID = Value
        End Set
    End Property

    Private _EmployeeID As String = ""
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _EmployeeID = Value
        End Set
    End Property

    Private _ProductVoucherNo As String = ""
    Public WriteOnly Property ProductVoucherNo() As String
        Set(ByVal Value As String)
            _ProductVoucherNo = Value
        End Set
    End Property

    Private _FromDate As String = ""
    Public WriteOnly Property FromDate() As String
        Set(ByVal Value As String)
            _FromDate = Value
        End Set
    End Property

    Private _ToDate As String = ""
    Public WriteOnly Property ToDate() As String
        Set(ByVal Value As String)
            _ToDate = Value
        End Set
    End Property

    Private _Flag As Boolean = False
    Public WriteOnly Property Flag() As Boolean
        Set(ByVal Value As Boolean)
            _Flag = Value
        End Set
    End Property

    Private _PSalaryVoucherID As String = ""
    Public WriteOnly Property PSalaryVoucherID() As String
        Set(ByVal Value As String)
            _PSalaryVoucherID = Value
        End Set
    End Property

    Private _FindServer As String = ""
    Public WriteOnly Property FindServer() As String
        Set(ByVal Value As String)
            _FindServer = Value
        End Set
    End Property

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
        Dim p As System.Diagnostics.Process

        Try

            p = Process.GetProcessesByName(ChildName)(0)

            If p Is Nothing Then
                Exit Sub
            End If

            'Chờ đợi exe con tắt tiến trình 
            p.EnableRaisingEvents = True
            p.WaitForExit()

        Catch ex As Exception
            MsgBox(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Public Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        '----Truyền tham số exe con------
        Dim exe As New D45E0340(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        With exe
            .FormActive = _FormActive
            .FormPermission = _formPermission
            .DepartmentID = _DepartmentID
            .TeamID = _TeamID
            .EmployeeID = _EmployeeID
            .ProductVoucherNo = _ProductVoucherNo
            .FromDate = _FromDate
            .ToDate = _ToDate
            .Flag = _Flag
            .PSalaryVoucherID = _PSalaryVoucherID
            .FindServer = _FindServer
        End With
        exe.Run()
        'Bắt đầu chạy cơ chế background
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        Me.Close()
    End Sub

End Class
