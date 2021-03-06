Imports System
Public Class D91F1301

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private ChildName As String = "D91E0540"

    Private exe As D91E0540

    'Phân biệt các form được gọi trong class D91E0540
    Private _formName As String
    Public WriteOnly Property FormName() As String
        Set(ByVal Value As String)
            _formName = Value
        End Set
    End Property

    Private _formPermission As String
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property

    Private _myFormState As EnumFormState
    Public WriteOnly Property MyFormState() As EnumFormState
        Set(ByVal Value As EnumFormState)
            _myFormState = Value
        End Set
    End Property

    'AnaCategatoryID: dùng cho form D91F1302
    'ObjectID: dùng cho form D91F0120
    Private _KeyID01 As String
    Public WriteOnly Property KeyID01() As String
        Set(ByVal Value As String)
            _KeyID01 = Value
        End Set
    End Property

    'AnaCategatoryName: dùng cho form D91F1302
    'ObjectTypeID: dùng cho form D91F0120
    Private _KeyID02 As String
    Public WriteOnly Property KeyID02() As String
        Set(ByVal Value As String)
            _KeyID02 = Value
        End Set
    End Property

    'CompanyID: dùng cho form D91F0120
    Private _KeyID03 As String
    Public WriteOnly Property KeyID03() As String
        Set(ByVal Value As String)
            _KeyID03 = Value
        End Set
    End Property

    'IsApproved: dùng cho form D91F0120
    Private _KeyID04 As String
    Public WriteOnly Property KeyID04() As String
        Set(ByVal Value As String)
            _KeyID04 = Value
        End Set
    End Property


    'Trả về giá trị AnaID (Mã phân tích) từ form D91F1302
    'Trả về giá trị ObjectID (Mã đối tượng) từ form D91F0120
    Private _Output01 As String
    Public ReadOnly Property Output01() As String
        Get
            Return _Output01
        End Get
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
        exe = New D91E0540(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString(), gsDivisionID, giTranMonth, giTranYear)

        If _formName = "D91F1301" Then ' Danh mục Mã phân tích
            exe.FormPermission = "D91F1301"
            exe.FormActive = D91E0540Form.D91F1301

        ElseIf _formName = "D91F1302" Then ' Cập nhật Mã phân tích
            exe.FormPermission = "D91F1301"
            exe.FormActive = D91E0540Form.D91F1302
            exe.KeyID01 = _KeyID01
            exe.KeyID02 = _KeyID02
            exe.FormStatus = _myFormState

        ElseIf _formName = "D91F0120" Then 'Cập nhật Đối tượng
            exe.FormPermission = _formPermission '"D17F2410"
            exe.FormActive = D91E0540Form.D91F0120
            exe.KeyID01 = _KeyID01
            exe.KeyID02 = _KeyID02
            exe.KeyID03 = _KeyID03
            exe.KeyID04 = _KeyID04
            exe.FormStatus = _myFormState
        End If
        exe.Run()


        If _formName = "D91F1301" Then ' Cơ chế không đợi
            Me.Close()
        Else ' Cơ chế đợi
            'Bắt đầu chạy cơ chế background
            backgroundWorker1 = New System.ComponentModel.BackgroundWorker
            backgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        _Output01 = exe.Output01
        Me.Close()
    End Sub

End Class
