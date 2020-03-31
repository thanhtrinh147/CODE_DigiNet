Public Class ExeLock

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private _frmParent As Form
    Private _sChild As String
    Public Sub New(ByRef frmMother As Form, ByVal sChild As String)
        _frmParent = frmMother
        _sChild = sChild
        _frmParent.Enabled = False
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub backgroundWorker1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles backgroundWorker1.Disposed


    End Sub

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        Dim p As New System.Diagnostics.Process
        Try
            p = Process.GetProcessesByName(_sChild)(0)
        Catch ex As Exception
        End Try

        If p Is Nothing Then
            MsgBox("There is no such a process is running")
            Exit Sub
        End If
        p.EnableRaisingEvents = True
        p.WaitForExit()
        backgroundWorker1.Dispose()
    End Sub

    

    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        _frmParent.Enabled = True

        _frmParent.Activate()

    End Sub
End Class
