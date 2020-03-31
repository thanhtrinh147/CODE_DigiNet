Public Class D09F9100

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker

    Private ChildName As String = "D89E0140"
    Dim exe As D89E0140


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
        p.WaitForExit()
    End Sub

    Private Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        '----Truyền tham số exe con------
        Dim exe As New D89E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = D89E0140Form.D89F9100
        exe.FormPermission = "D13F9100"
        exe.ModuleID = D13
        '------------------------------------
        exe.Run()
        Me.Close()
        ''Bắt đầu chạy cơ chế background
        'backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        'backgroundWorker1.RunWorkerAsync()
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        Me.Close()
    End Sub

    Private Sub D21F0005_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub
End Class
