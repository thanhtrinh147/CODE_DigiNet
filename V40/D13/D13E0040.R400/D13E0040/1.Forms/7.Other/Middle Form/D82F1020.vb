Imports System
Public Class D82F1020

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private Const EXECHILD As String = "D82E0440"

    Private exe As D82E0440

    Private _FormName As String
    Public WriteOnly Property FormName() As String
        Set(ByVal Value As String)
            _FormName = Value
        End Set
    End Property

    Private _FormPermission As String
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _FormPermission = Value
        End Set
    End Property

    Private _FormStatus As EnumFormState
    Public WriteOnly Property FormStatus() As EnumFormState
        Set(ByVal Value As EnumFormState)
            _FormStatus = Value
        End Set
    End Property

    Private _key01ID As String
    Public WriteOnly Property Key01ID() As String
        Set(ByVal Value As String)
            _key01ID = Value
        End Set
    End Property


    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
        Dim p As System.Diagnostics.Process
        Try
            p = Process.GetProcessesByName(EXECHILD)(0)

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
        exe = New D82E0440(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString(), gsDivisionID, giTranMonth, giTranYear)


        exe.FormPermission = _FormPermission
        If _FormName = "D82F1020" Then
            exe.FormActive = D82E0440Form.D82F1020
        End If

        exe.FormStatus = _FormStatus
        exe.Key01ID = _key01ID
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
