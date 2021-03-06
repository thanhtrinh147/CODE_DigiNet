Imports System
Public Class D07F1211

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private ChildName As String = "D07E0140"

    Private exe As D07E0140

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

    'Truyền vào khi gọi D07F0112
    Private _Type As String = ""
    Public WriteOnly Property Type() As String
        Set(ByVal Value As String)
            _Type = Value
        End Set
    End Property


    'Trả về giá trị LocationNo(Lô nhập) từ form D07F1211 hoặc Công thức từ D07F0112 hoặc Mã DVT từ D07F0012
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
        exe = New D07E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString(), "%", giTranMonth, giTranYear)

        If _formName = "D07F0005" Then 'Danh mục Kho hàng
            exe.FormActive = D07E0140Form.D07F0005
        ElseIf _formName = "D07F0009" Then 'Danh mục Đơn vị tính
            exe.FormActive = D07E0140Form.D07F0009
        ElseIf _formName = "D07F0012" Then 'Thêm mới Đơn vị tính
            exe.FormActive = D07E0140Form.D07F0012
        ElseIf _formName = "D07F0018" Then  'Danh mục Bảng chuyển đổi đơn vị tính" 
            exe.FormActive = D07E0140Form.D07F0018
        ElseIf _formName = "D07F0410" Then  'Thiết lập loại quy cách" 
            exe.FormActive = D07E0140Form.D07F0410
        ElseIf _formName = "D07F1111" Then  'Danh mục phân loại hàng tồn kho" 
            exe.FormActive = D07E0140Form.D07F1111
        ElseIf _formName = "D07F1201" Then  'Danh mục trạng thái phiếu yêu cầu xuất kho" 
            exe.FormActive = D07E0140Form.D07F1201
        ElseIf _formName = "D07F1210" Then  'Danh mục lô hàng" 
            exe.FormActive = D07E0140Form.D07F1210
        ElseIf _formName = "D07F1211" Then 'Thêm mới lô hàng" 
            exe.FormActive = D07E0140Form.D07F1211
        ElseIf _formName = "D07F1231" Then  'Danh mục công thức" 
            exe.FormActive = D07E0140Form.D07F1231
        ElseIf _formName = "D07F1310" Then  'Danh mục vị trí" 
            exe.FormActive = D07E0140Form.D07F1310
        ElseIf _formName = "D07F1410" Then  'Danh mục quy cách hàng tồn kho" 
            exe.FormActive = D07E0140Form.D07F1410
        ElseIf _formName = "D07F1420" Then  'Bảng lịch sử quy cách hàng tồn kho (Chuyển từ D07E0240 sang)" 
            exe.FormActive = D07E0140Form.D07F1420
        ElseIf _formName = "D07F1430" Then 'Bộ chỉ số hàng tồn kho" 
            exe.FormActive = D07E0140Form.D07F1430
        ElseIf _formName = "D07F1440" Then 'Danh mục Loại nghiệp vụ" 
            exe.FormActive = D07E0140Form.D07F1440
        ElseIf _formName = "D07F1510" Then 'Danh mục phương pháp phân tích tuổi nợ" 
            exe.FormActive = D07E0140Form.D07F1510
        ElseIf _formName = "D07F0222" Then 'In theo định mức" 
            exe.FormActive = D07E0140Form.D07F0222
            exe.FormPermission = "D07F0222"
        ElseIf _formName = "D07F5557" Then 'Khoá phiếu" 
            exe.FormActive = D07E0140Form.D07F5557
        ElseIf _formName = "D07F0075" Then 'Thiết lập loại mã phân tích" 
            exe.FormActive = D07E0140Form.D07F0075
        ElseIf _formName = "D07F0038" Then 'Thiết lập thông tin phụ" 
            exe.FormActive = D07E0140Form.D07F0038
        ElseIf _formName = "D07F0040" Then  'Phương pháp tạo mã hàng" 
            exe.FormActive = D07E0140Form.D07F0040
        ElseIf _formName = "D07F0042" Then  'Danh mục -> Danh mục Kit" 
            exe.FormActive = D07E0140Form.D07F0042
        ElseIf _formName = "D07F1002" Then 'Danh mục sản phẩm (sử dụng cho D17)" 
            exe.FormActive = D07E0140Form.D07F1002
        ElseIf _formName = "D07F4400" Then  'Báo cáo đơn vị tính qui đổi" 
            exe.FormActive = D07E0140Form.D07F4400
        ElseIf _formName = "D07F0500" Then  'Thiết lập phương pháp bình quân gia quyền cuối kỳ" 
            exe.FormActive = D07E0140Form.D07F0500
        ElseIf _formName = "D07F0010" Then  'Danh mục hàng tồn kho" 
            exe.FormActive = D07E0140Form.D07F0010
        ElseIf _formName = "D07F0112" Then  'Ký hiệu công thức
            exe.FormActive = D07E0140Form.D07F0112
            exe.Type = "4"
        End If
        exe.FormPermission = _formPermission

        exe.Run()

        If _formName = "D07F1211" Or _formName = "D07F0112" Or _formName = "D07F0012" Then 'Cơ chế đợi
            'Bắt đầu chạy cơ chế background
            backgroundWorker1 = New System.ComponentModel.BackgroundWorker
            backgroundWorker1.RunWorkerAsync()
        Else ' Cơ chế không đợi
            Me.Close()
        End If

    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        _Output01 = exe.Output01
        Me.Close()
    End Sub

End Class
