Imports System
'Middle Form dành riêng cho việc gọi các màn hình nghiệp vụ của D09
Public Class D09F5605

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker

    Private ChildName As String = "D09E2040"
    Dim exe As D09E2040

    Private _formActive As D09E2040Form
    Public WriteOnly Property FormActive() As D09E2040Form
        Set(ByVal Value As D09E2040Form)
            _formActive = Value
        End Set
    End Property

    Private _formPermission As String
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
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


    Private _key01ID As String ''F_EmployeeID'
    Public WriteOnly Property Key01ID() As String
        Set(ByVal Value As String)
            _key01ID = Value
        End Set
    End Property


    Private _key02ID As String ''C_TranTypeID'
    Public WriteOnly Property Key02ID() As String
        Set(ByVal Value As String)
            _key02ID = Value
        End Set
    End Property

    Private _key03ID As String ''F_Times'
    Public WriteOnly Property Key03ID() As String
        Set(ByVal Value As String)
            _key03ID = Value
        End Set
    End Property

    Private _key04ID As String ''F_EmployeeID'
    Public WriteOnly Property Key04ID() As String
        Set(ByVal Value As String)
            _key04ID = Value
        End Set
    End Property

    Private _key05ID As String ''F_EmployeeID'
    Public WriteOnly Property Key05ID() As String
        Set(ByVal Value As String)
            _key05ID = Value
        End Set
    End Property

    Private _voucher01ID As String = ""
    Public WriteOnly Property Voucher01ID() As String 
        Set(ByVal Value As String )
            _voucher01ID = Value
        End Set
    End Property

    Private _moduleID As String = ""
    Public WriteOnly Property ModuleID() As String 
        Set(ByVal Value As String )
            _moduleID = Value
        End Set
    End Property

    Private _showEmpStopWork As String = ""
    Public WriteOnly Property ShowEmpStopWork() As String 
        Set(ByVal Value As String )
            _showEmpStopWork = Value
        End Set
    End Property

    Private _formID As String = "" ' Form để truyền vào store D09P5600 
    Public WriteOnly Property FormID() As String 
        Set(ByVal Value As String )
            _formID = Value
        End Set
    End Property

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        
        Try
            'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
            Dim p As New System.Diagnostics.Process
            p = Process.GetProcessesByName(ChildName)(0)
            If p Is Nothing Then
                'D99C0008.MsgL3("Process " & ChildName & " is not running")
                Exit Sub
            End If


            p.EnableRaisingEvents = True
            p.WaitForExit()
        Catch ex As Exception
        End Try
       
    End Sub

    Private Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        '----Truyền tham số exe con------
        Dim exe As New D09E2040(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = _formActive
        exe.FormPermission = _formPermission


        If _tranTypeID Is Nothing Then _tranTypeID = ""

        exe.ModuleID = _moduleID
        exe.FormID = _formID
        exe.Mode = _mode
        exe.TranTypeID = _tranTypeID
        exe.Voucher01ID = _voucher01ID
        exe.Key01ID = _key01ID
        exe.Key02ID = _key02ID
        exe.Key03ID = _key03ID
        exe.Key04ID = _key04ID
        exe.Key05ID = _key05ID
        exe.ShowEmpStopWork = _showEmpStopWork
        exe.FormState = EnumFormState.FormAdd

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
