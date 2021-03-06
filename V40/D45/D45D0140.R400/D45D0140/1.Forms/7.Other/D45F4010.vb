Imports System
Public Class D45F4010

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

    Private _formPermission As String = ""
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property

    Private _PriceListID As String = ""
    Public WriteOnly Property PriceListID() As String
        Set(ByVal Value As String)
            _PriceListID = Value
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
        exe = New D45E0340(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString(), "%", giTranMonth, giTranYear)
        exe.FormActive = D45E0340Form.D45F4010
        exe.FormPermission = _formPermission
        exe.PriceListID = _PriceListID

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
