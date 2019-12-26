Public Class D45F7777
    Private iWidthForm As Integer
    Private iHeightForm As Integer

    Dim iMaxID As Integer
    Dim sLabelDetailName As String 'Tên của lablel diễn giải
    Dim sLabelName As String 'tên của label Title

    Dim iLeftAlign As Integer 'Lề trái của label title
    Dim iLabelDistance As Integer ' khoảng cách giữa tên và diễn giải của label
    Dim iTopAlign As Integer
    Dim iDescLeftAlign As Integer 'Lề trái của label diễn giải
    Dim iSpace As Integer ' khoảng cách giữa 2 dòng
    Dim iHeight As Integer
    Dim iCaptionHeight As Integer ' chiều cao của label: 19

    Dim iMaxIndex As Integer  ' chỉ số của label có độ dài lớn nhất
    Dim iMaxWidth As Integer ' độ dài của label dài nhất: Left + Width
    Dim iLabelMaxWidth As Integer 'độ dài của label dài nhất: Width

    Dim OnForm As String
    Dim sClose As String

    Dim F2 As String
    Dim F11 As String
    Dim Alt123 As String
    Dim Ctrl123 As String
    Dim CtrlA As String
    Dim CtrlF As String
    Dim CtrlF1 As String

    Dim OnGrid As String
    Dim F7 As String
    Dim F8 As String
    Dim CtrlS As String
    Dim CtrlD As String
    Dim CtrlHome As String
    Dim CtrlEnd As String
    Dim CtrlPageUp As String
    Dim CtrlPageDown As String
    Dim CtrlArrowR As String
    Dim CtrlArrowL As String
    Dim CtrlInsert As String
    Dim ShiftInsert As String
    Dim CtrlDelete As String
    Dim CtrlC As String
    Dim CtrlV As String
    Dim CtrlE As String
    Dim CtrlI As String
    Dim CtrlT As String

    Private _formID As String = ""
    Public Property FormID() As string
        Get
            Return _formID
        End Get
        Set(ByVal Value As string)
            _formID = Value
        End Set
    End Property

    Private Sub FillCaption()
        If geLanguage = EnumLanguage.Vietnamese Then
            Me.Text = rl3("Danh_sach_phim_nong")
            OnForm = "Trên form"
            sClose = "Đóng form hiển thị phím nóng"
            'F2 = "Tìm kiếm mở rộng"
            F11 = "Di chuyển con trỏ tới lưới"
            'Alt123 = "Di chuyển các STAB"
            'Ctrl123 = "Di chuyển các nút thao tác trên lưới"
            'CtrlA = "Liệt kê tất cả"
            'CtrlF = "Tìm kiếm"
            CtrlF1 = "Hiển thị các phím nóng"

            OnGrid = "Trên lưới"
            F7 = "Copy ô trên xuống ô dưới"
            F8 = "Copy dòng trên xuống dòng dưới"
            CtrlD = "Copy cột diễn giải master xuống detail"
            CtrlS = "Copy cột đang đứng (nhấp HeadClick)"
            CtrlHome = "Di chuyển tới cột đầu tiên"
            CtrlEnd = "Di chuyển tới cột cuối cùng"
            CtrlPageUp = "Di chuyển tới dòng đầu tiên"
            CtrlPageDown = "Di chuyển tới dòng cuối cùng"
            CtrlArrowR = "Di chuyển tới split tiếp theo"
            CtrlArrowL = "Trở về split trước đó"
            CtrlInsert = "Thêm dòng mới"
            ShiftInsert = "Chèn dòng"
            CtrlDelete = "Xóa dòng hiện tại"
            CtrlC = "Copy mảng"
            CtrlV = "Paste mảng"
            CtrlE = "Export ra excel"
            CtrlI = "Import file excel vào lưới"
            CtrlT = "Copy từ file excel vào lưới"

        Else
            Me.Text = "List of HotKeys "
            OnForm = "On The Form"
            sClose = "Close HotKeys' List"
            'F2 = "Find extend"
            F11 = "Moving cursor to grid"

            'Alt123 = "Moving STAB"
            'Ctrl123 = "Moving button on grid"
            'CtrlA = "List all"
            'CtrlF = "Find"
            CtrlF1 = "Show HotKeys' List"

            OnGrid = "On The Grid"
            F7 = "Copy upper cell to lower cell"
            F8 = "Copy upper row to lower row"
            CtrlS = "Copy current column (Press HeadClick)"
            CtrlD = "Copy Description from master to detail"
            CtrlHome = "Moving currsor to first column"
            CtrlEnd = "Moving currsor to last column"
            CtrlPageUp = "Moving currsor to first row"
            CtrlPageDown = "Moving currsor to last row"
            CtrlArrowR = "Moving currsor to next split"
            CtrlArrowL = "Moving currsor to previous split"
            CtrlInsert = "Insert new row"
            ShiftInsert = "Insert row"
            CtrlDelete = "Delete current row"
            CtrlC = "Copy array"
            CtrlV = "Paste array"
            CtrlE = "Export to excel"
            CtrlI = "Import from excel into grid"
            CtrlT = "Copy from excel into grid"

        End If
    End Sub

    Public Sub CallShowForm(ByVal sForm As String)
        FillCaption()

        sLabelName = "lblObj"
        sLabelDetailName = "lbl"
        iLeftAlign = 2
        iDescLeftAlign = 100
        iTopAlign = 3
        iLabelDistance = iDescLeftAlign - iLeftAlign

        iSpace = 0
        iHeight = 19
        iMaxWidth = 0
        iMaxIndex = 0

        iCaptionHeight = 0
        iMaxID = 0

        CreateLabelS(OnForm, "", Color.Blue, 9.75!)

        CreateLabelS("Esc", sClose, Color.Black)
        'CreateLabelS("F2", F2, Color.Black)
        CreateLabelS("F11", F11, Color.Black)
        'CreateLabelS("Alt+1,2,3", Alt123, Color.Black)
        'CreateLabelS("Ctrl+1,2,3", Ctrl123, Color.Black)
        'CreateLabelS("Ctrl+A", CtrlA, Color.Black)
        'CreateLabelS("Ctrl+F", CtrlF, Color.Black)
        CreateLabelS("Ctrl+F1", CtrlF1, Color.Black)

        'Dùng cho form đặc biệt
        Select Case sForm
            'Case "DxxFxxxx"
            '    CreateLabelS("F4", IIf(gsLanguage = "01", "Store", "Nhập kho").ToString, Color.Black)
        End Select

        CreateLabelS(OnGrid, "", Color.Blue, 9.75!)
        CreateLabelS("F7", F7, Color.Black)
        CreateLabelS("F8", F8, Color.Black)

        'CreateLabelS("Ctrl+D", CtrlD, Color.Black)
        CreateLabelS("Ctrl+S", CtrlS, Color.Black)

        CreateLabelS("Ctrl+Home", CtrlHome, Color.Black)
        CreateLabelS("Ctrl+End", CtrlEnd, Color.Black)
        CreateLabelS("Ctrl+PageUp", CtrlPageUp, Color.Black)
        CreateLabelS("Ctrl+PageDown", CtrlPageDown, Color.Black)
        CreateLabelS("Ctrl+ -->", CtrlArrowR, Color.Black)
        CreateLabelS("Ctrl+ <--", CtrlArrowL, Color.Black)

        'Dùng cho form đặc biệt
        Select Case sForm
            'Case "DxxFxxxx"
            '    CreateLabelS("F4", IIf(gsLanguage = "01", "Store", "Nhập kho").ToString, Color.Black)
            Case "D45F1022"
                CreateLabelS("Ctrl+E", CtrlE, Color.Black)
                CreateLabelS("Ctrl+I", CtrlI, Color.Black)
                CreateLabelS("Ctrl+T", CtrlT, Color.Black)
            Case "D45F2003", "D45F2002"
                ' CreateLabelS("F4", IIf(gsLanguage = "01", "Store", "Nhập kho").ToString, Color.Black)
                'CreateLabelS("Ctrl+Insert", CtrlInsert, Color.Black)
                'CreateLabelS("Shift+Insert", ShiftInsert, Color.Black)
                CreateLabelS("Ctrl+Delete", CtrlDelete, Color.Black)
                CreateLabelS("Ctrl+C", CtrlC, Color.Black)
                CreateLabelS("Ctrl+V", CtrlV, Color.Black)
                CreateLabelS("Ctrl+E", CtrlE, Color.Black)
                CreateLabelS("Ctrl+I", CtrlI, Color.Black)
            Case "D45F2002", "D45F1022"
                CreateLabelS("Ctrl+T", CtrlT, Color.Black)
            Case "D45F2004", "D45F2007"
                CreateLabelS("Ctrl+Insert", CtrlInsert, Color.Black)
                CreateLabelS("Shift+Insert", ShiftInsert, Color.Black)
                CreateLabelS("Ctrl+Delete", CtrlDelete, Color.Black)
        End Select

        AdjustLabelDistance()
        iWidthForm = iDescLeftAlign + iLabelMaxWidth
        iHeightForm = iTopAlign + 25

        Me.Size = New System.Drawing.Size(iWidthForm, iHeightForm)
        'Me.Location = New System.Drawing.Point(My.Forms.D27F0000.Width - Me.Width - 10, 0)
        Me.Location = New System.Drawing.Point(My.Computer.Screen.WorkingArea.Width - Me.Width + 1, 0)
    End Sub

    Private Sub CreateLabelS(ByVal sName As String, ByVal sDesc As String, ByVal clForeColor As System.Drawing.Color, Optional ByVal sglFontSize As Single = 8.25!, Optional ByVal Bold As Boolean = True, Optional ByVal DescBold As Boolean = False)
        iMaxID = iMaxID + 1
        Dim ldbName As New Label
        Dim lblDetailName As New Label

        With ldbName
            .Name = sLabelName & iMaxID
            .AutoSize = True
            .Height = iHeight
            .Left = iLeftAlign
            .Top = iTopAlign
            .Visible = True
            .ForeColor = clForeColor
            .BackColor = Me.BackColor

            .Text = sName

            If Bold Then
                .Font = New System.Drawing.Font("Microsoft Sans Serif", sglFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Else
                .Font = New System.Drawing.Font("Microsoft Sans Serif", sglFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            End If

        End With
        Me.Controls.Add(ldbName)
        If ldbName.Width > iLabelDistance Then iLabelDistance = ldbName.Width

        With lblDetailName
            .Name = sLabelDetailName & iMaxID
            .AutoSize = True
            .Height = iHeight
            .Left = iDescLeftAlign
            .Top = iTopAlign
            .Visible = True

            .ForeColor = clForeColor
            .BackColor = Me.BackColor
            .Text = sDesc

            If DescBold Then
                .Font = New System.Drawing.Font("Microsoft Sans Serif", sglFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Else
                .Font = New System.Drawing.Font("Microsoft Sans Serif", sglFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            End If

            iCaptionHeight = .Height
        End With
        Me.Controls.Add(lblDetailName)
        If lblDetailName.Left + lblDetailName.Width > iMaxWidth Then
            iMaxWidth = lblDetailName.Left + lblDetailName.Width
            iMaxIndex = iMaxID
            iLabelMaxWidth = lblDetailName.Width
        End If

        iTopAlign = iTopAlign + iCaptionHeight + iSpace
    End Sub

    'Điều chỉnh khoảng cách giữa tên và diễn giải của label
    Private Sub AdjustLabelDistance()
        Dim Index As Integer

        If iLabelDistance > 66 Then
            For Index = 1 To iMaxID
                Me.Controls(sLabelDetailName & Index).Left = iLeftAlign + iLabelDistance + 15
            Next

            iDescLeftAlign = Me.Controls(sLabelDetailName & "1").Left
        End If
    End Sub

    Private Sub D45F7777_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        CallShowForm(_formID)
        Loadlanguage()
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_sach_phim_nong") 'Danh sÀch phÛm nâng
       
    End Sub


End Class