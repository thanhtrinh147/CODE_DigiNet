Imports System.Drawing
Imports System
Public Class D45F2006

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private ChildName As String = "D45E0240"

#Region "Property"

    Private _formName As String
    Public WriteOnly Property FormName() As String
        Set(ByVal Value As String)
            _formName = Value
        End Set
    End Property

    Private _formState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal Value As EnumFormState)
            _formState = Value
        End Set
    End Property

    Private _formPermission As String
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property

    Private _payrollVoucherID As String
    Public WriteOnly Property PayrollVoucherID() As String
        Set(ByVal Value As String)
            _payrollVoucherID = Value
        End Set
    End Property

    Private _salaryVoucherID As String
    Public WriteOnly Property SalaryVoucherID() As String
        Set(ByVal Value As String)
            _salaryVoucherID = Value
        End Set
    End Property

    Private _employeeID As String = ""
    Public WriteOnly Property EmployeeID() As String 
        Set(ByVal Value As String )
            _employeeID = Value
        End Set
    End Property

#End Region

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
        End Try
    End Sub

    Public Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        '----Truyền tham số exe con------
        Dim exe As New D45E0240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        If _formName = "D45F2006" Then
            exe.FormActive = D45E0240Form.D45F2006
            exe.FormPermision = _formPermission
            exe.PayrollVoucherID = _payrollVoucherID
            exe.ProductVoucherID = ""
            exe.SalaryVoucherID = _salaryVoucherID
            exe.EmployeeID = _employeeID
            exe.Mode = 1
            exe.FormState = _formState
        End If
        exe.Run()
        '------------------------------------

        'Bắt đầu chạy cơ chế background
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        Me.Close()
    End Sub

End Class