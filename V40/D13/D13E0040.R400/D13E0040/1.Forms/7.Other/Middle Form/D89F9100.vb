Public Class D89F9100
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private ChildName As String = "D89E0140"
    Dim exe As D89E0140
    Dim p As System.Diagnostics.Process

    Private _voucherID As String
    Public WriteOnly Property VoucherID() As String
        Set(ByVal Value As String)
            _voucherID = Value
        End Set
    End Property

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork

        'Chờ đợi exe con tắt tiến trình 
        p.EnableRaisingEvents = True
        p.WaitForExit()
    End Sub

    Private Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(1, 1)

        '----Truyền tham số exe con------
        Dim exe As New D89E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = D89E0140Form.D89F9100
        exe.FormPermission = "D34F2111"
        exe.ModuleID = "D13"
        exe.Run()

        '------------------------------------

        'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
        '---------------------------------
        Try
            p = Process.GetProcessesByName(ChildName)(0)
        Catch ex As Exception
        End Try
        If p Is Nothing Then
            D99C0008.MsgL3("Process " & ChildName & " is not running")
            Exit Sub
        End If
        '------------------------------------------

        'Bắt đầu chạy cơ chế background
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted

        Me.Close()

    End Sub

End Class