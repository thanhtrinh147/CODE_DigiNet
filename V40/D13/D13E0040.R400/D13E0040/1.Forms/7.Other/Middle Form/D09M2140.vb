Imports System
Public Class D09M2140

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker

    Private ChildName As String = "D09E2140"
    Dim exe As D09E2140

    Private _formActive As D09E2140Form
    Public WriteOnly Property FormActive() As D09E2140Form
        Set(ByVal Value As D09E2140Form)
            _formActive = Value
        End Set
    End Property

    Private _formPermission As String
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property

    Private _departmentID As String
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _employeeID As String
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private _mode As Integer
    Public WriteOnly Property Mode() As Integer
        Set(ByVal Value As Integer)
            _mode = Value
        End Set
    End Property

    Private _formState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal Value As EnumFormState)
            _formState = Value
        End Set
    End Property

    Private _tranTypeID As String
    Public WriteOnly Property TranTypeID() As String
        Set(ByVal Value As String)
            _tranTypeID = Value
        End Set
    End Property

    Private _isTransaction As Boolean = False
    Public Property IsTransaction() As Boolean
        Get
            Return _isTransaction
        End Get
        Set(ByVal Value As Boolean)
            _isTransaction = Value
        End Set
    End Property

    'Trả về giá trị có Lưu thành công không 
    Private _Output01 As Boolean = False
    Public ReadOnly Property Output01() As Boolean
        Get
            Return _Output01
        End Get
    End Property

    Private _Output02 As Boolean = False
    Public ReadOnly Property Output02() As Boolean
        Get
            Return _Output02
        End Get
    End Property


    Private _bWait As Boolean = False
    Public Property bWait() As Boolean
        Get
            Return _bWait
        End Get
        Set(ByVal Value As Boolean)
            _bWait = Value
        End Set
    End Property

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
        Dim p As New System.Diagnostics.Process
        Try
            p = Process.GetProcessesByName(ChildName)(0)
        Catch ex As Exception
        End Try
        If p Is Nothing Then
            'D99C0008.MsgL3("Process " & ChildName & " is not running")
            Exit Sub
        End If


        p.EnableRaisingEvents = True
        'p.WaitForExit()
    End Sub

    Private Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        '----Truyền tham số exe con------
        exe = New D09E2140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = _formActive
        exe.FormPermission = _formPermission
        exe.IsTransaction = _isTransaction.ToString
        exe.ModuleID = ModuleID
        exe.Run()

        If _bWait = False Then
            Me.Close()
        Else
            '------------------------------------
            'Bắt đầu chạy cơ chế background
            backgroundWorker1 = New System.ComponentModel.BackgroundWorker
            backgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        _Output01 = exe.Output01
        _Output02 = exe.Output02
        Me.Close()
    End Sub

End Class
