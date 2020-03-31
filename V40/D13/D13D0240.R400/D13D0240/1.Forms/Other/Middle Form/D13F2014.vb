Imports System
Public Class D13F2014
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker

    Private ChildName As String = "D13E0140"
    Dim exe As D13E0140
    Private _callFromFormID As String = ""
    Public Property CallFromFormID() As String 
        Get
            Return _callFromFormID
        End Get
        Set(ByVal Value As String )
            _callFromFormID = Value
        End Set
    End Property

    Private _payrollVoucherID As String = ""
    Public Property PayrollVoucherID() As String
        Get
            Return _payrollVoucherID
        End Get
        Set(ByVal Value As String)
            _payrollVoucherID = Value
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
            'Chờ đợi exe con tắt tiến trình 
            p.EnableRaisingEvents = True
            p.WaitForExit()

        Catch ex As Exception
        End Try
        
    End Sub

    Private Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.ShowInTaskbar = False
        gbSavedOK = False
        '----Truyền tham số exe con------

        exe = New D13E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = enumD13E0140Form.D13F2014 '"D13F2014"
        exe.FormPermission = "D13F2014"
        exe.CallFromFormID = _callFromFormID
        exe.PayrollVoucherID = _payrollVoucherID
        exe.RunAndWait()

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