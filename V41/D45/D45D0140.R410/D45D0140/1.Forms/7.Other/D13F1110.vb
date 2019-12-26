Imports System
Public Class D13F1110
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker

    Private ChildName As String = "D13E0140"
    Dim exe As D13E0140

    Private _type As String = ""
    Public WriteOnly Property Type() As String 
        Set(ByVal Value As String )
            _type = Value
        End Set
    End Property

    Private _dutyID As String = ""
    Public WriteOnly Property DutyID() As String 
        Set(ByVal Value As String )
            _dutyID = Value
        End Set
    End Property

    Private _formPermision As string
    Public Property FormPermision() As string
        Get
            Return _formPermision
        End Get
        Set(ByVal Value As string)
            _formPermision = Value
        End Set
    End Property

    Private _formStatus As Integer
    Public Property FormStatus() As Integer
        Get
            Return _formStatus
        End Get
        Set(ByVal Value As Integer)
            _formStatus = Value
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

        'Chờ đợi exe con tắt tiến trình 
        p.EnableRaisingEvents = True
        p.WaitForExit()
    End Sub

    Private Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        '----Truyền tham số exe con------
        exe = New D13E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = "D13F1110"
        exe.FormPermission = _formPermision
        exe.FormState = CType(_formStatus.ToString, EnumFormState)
        exe.ID01 = _type
        exe.ID02 = _dutyID
        exe.Run()
        '------------------------------------

        'Bắt đầu chạy cơ chế background
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        gbSavedOK = CBool(exe.Out_SavedOK)
        Me.Close()
    End Sub

End Class