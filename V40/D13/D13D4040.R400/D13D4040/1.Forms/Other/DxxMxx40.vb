Imports System

Public Structure StructureKey
    Public Name As String
    Public Value As String
End Structure

Public Class DxxMxx40

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Dim exe As New DxxExx40

    Private _exeName As String = ""
    Public WriteOnly Property exeName() As String
        Set(ByVal Value As String)
            _exeName = Value
        End Set
    End Property

    Private _formActive As String
    Public WriteOnly Property FormActive() As String
        Set(ByVal Value As String)
            _formActive = Value
        End Set
    End Property

    Private _formPermission As String = ""
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property

    Private bSetFormState As Boolean = False ' Do không thể kiểm tra _formState = nothing
    Private _formState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal Value As EnumFormState )
            _formState = Value
            bSetFormState = True
        End Set
    End Property

    Private _iDValue As Object()
    Private _iDxx As String()
    Public WriteOnly Property IDxx(ByVal IDName As String()) As Object()
        Set(ByVal Value() As Object)
            _iDValue = Value
            _iDxx = IDName
        End Set
    End Property

    Private _outputName() As String
    Public WriteOnly Property OutputName() As String()
        Set(ByVal Value() As String)
            _outputName = Value
        End Set
    End Property

    Private _outputXX() As String
    Public ReadOnly Property OutputXX() As String()
        Get
            Return _outputXX
        End Get
    End Property

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
        Dim p As System.Diagnostics.Process
        Try
            p = Process.GetProcessesByName(_exeName)(0)
            If p Is Nothing Then
                Exit Sub
            End If
            p.EnableRaisingEvents = True
            p.WaitForExit()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        Dim exe As New DxxExx40(_exeName, gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        With exe
            .FormActive = _formActive 'Form cần hiển thị
            If _formPermission = "" Then _formPermission = _formActive
            .FormPermission = _formPermission 'Mã màn hình phân quyền
            If bSetFormState Then .FormState = _formState

            If _iDxx IsNot Nothing Then
                For i As Integer = 0 To _iDxx.Length - 1
                    .IDxx(_iDxx(i)) = _iDValue(i).ToString
                Next
            End If
            .Run()
        End With

        'Bắt đầu chạy cơ chế background
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        If _outputName Is Nothing Then GoTo close
        ReDim _outputXX(_outputName.Length - 1)
        For i As Integer = 0 To _outputName.Length - 1
            _outputXX(i) = exe.OutputXX(L3Left(_exeName, 3), _exeName, _outputName(i))
        Next
close:
        Me.Close()
    End Sub

End Class
