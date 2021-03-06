Imports System

Public Class D25M0140

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private ChildName As String = "D25E0140"
    Dim exe As D25E0140

    Private _FormActive As enumD25E0140Form
    Public WriteOnly Property FormActive() As enumD25E0140Form
        Set(ByVal Value As enumD25E0140Form)
            _FormActive = Value
        End Set
    End Property

    'Private _formPermission As String = ""
    'Public WriteOnly Property FormPermission() As String
    '    Set(ByVal Value As String)
    '        _formPermission = Value
    '    End Set
    'End Property

    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            _FormState = value
        End Set
    End Property

    Private _iD01 As String = ""
    Public WriteOnly Property ID01() As String 
        Set(ByVal Value As String )
            _iD01 = Value
        End Set
    End Property

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
        Try
            Dim p As System.Diagnostics.Process
            p = Process.GetProcessesByName(ChildName)(0)
            If p Is Nothing Then
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
        exe = New D25E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = _FormActive
        'exe.FormPermission = _formPermission

        Select Case _FormActive
            Case enumD25E0140Form.D25F1051
                exe.FormState = _FormState
                exe.ID01 = _iD01 'CandidateID
        End Select

        exe.Run()

        'Bắt đầu chạy cơ chế background
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        'D43Options.ShowReportPath = Convert.ToBoolean(D99C0007.GetModulesSetting(D43, ModuleOption.lmOptions, "ShowReportPath", "True"))
        Me.Close()
    End Sub

End Class
