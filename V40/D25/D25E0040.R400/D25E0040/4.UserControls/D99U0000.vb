'#------------------------------------------------------
'#Title: User Control D99U0000
'#CreateUser: NGUYEN THI MINH HOA
'#CreateDate: 30/12/2009
'#ModifiedUser: NGUYEN THI MINH HOA
'#ModifiedDate:  27/01/2010
'#Description: Tạo cây menu tại các form chính (DxxF0000) của các module
'#------------------------------------------------------

Imports System

Public Class D99U0000

    'Dim frmD25F0000 As Form
    'Sub New(ByVal formParent As Form)

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    frmD25F0000 = formParent
    'End Sub
 

#Region "Property"

    Private _moduleID As String
    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            _moduleID = Value
        End Set
    End Property

    Private _formPermission As String
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property
#End Region

#Region "Event Treeview"

    Dim MyNode As TreeNode
    Private Sub tvw1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvw1.AfterSelect
        MyNode = e.Node
    End Sub

    Private Sub tvw1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tvw1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectNode(MyNode)
        End If
    End Sub

    Private Sub tvw1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvw1.NodeMouseClick
        SelectNode(e.Node)
    End Sub
#End Region

#Region "Event MyTree load"

    Dim bPer_F5699 As Boolean
    Private Sub MyTree_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Loadlanguage()
        LoadTreeview(True)

        'Kiểm tra nút Thiết lập
        bPer_F5699 = ReturnPermission(_formPermission) > 1
        If giMenuType = 1 Then
            btnSetup.Enabled = bPer_F5699
            optPersonal.Checked = True
        Else
            btnSetup.Enabled = False
            optStandard.Checked = True
        End If

    End Sub

    Private Sub Loadlanguage()
        optStandard.Text = rl3("Chuan") '"Chuẩn"
        optPersonal.Text = rl3("Ca_nhan") '"Cá nhân"
        btnSetup.Text = rl3("Thiet__lap") '"Thiết &lập"
    End Sub

#End Region

#Region "Load treeview"

    Dim dtTreeview As DataTable
    Private Sub LoadTreeview(Optional ByVal bReload As Boolean = False)

        Dim nRoot As TreeNode
        Dim nNewNode As TreeNode
        Dim dtTree As DataTable

        If bReload Then
            dtTreeview = ReturnDataTable(SQLStoreD91P1110)
            'ID 65442 08/07/2014
            If gbUnicode Then ConvertDataTable(dtTreeview, New String() {"ChildLevelName84"})

            tvw1.Font = FontUnicode(gbUnicode, FontStyle.Bold)
        End If
        dtTree = ReturnTableFilter(dtTreeview, "MenuType = " & giMenuType, True)

        tvw1.Nodes.Clear()
        If giMenuType = 1 Then ' Option Thiết lập thì kiểm tra
            If dtTree Is Nothing OrElse dtTree.Rows.Count < 1 Then
                If bReload Then
                    giMenuType = -1
                    Exit Sub
                Else
                    D99C0008.MsgL3(rl3("Vui_long_thiet_lap_menu_theo_nguoi_dung"))
                    giMenuType = -1
                    btnSetup.Focus()
                    Exit Sub
                End If

            End If
        End If

        tvw1.ImageList = imgTree
        Dim fs As FontStyle
        For Each dr As DataRow In dtTree.Rows
            If dr("LevelID").ToString = "1" Then
                nRoot = New TreeNode(IIf(geLanguage = EnumLanguage.Vietnamese, dr("ChildLevelName84").ToString, dr("ChildLevelName01").ToString).ToString)
                If dr("FormID").ToString <> "" Then nRoot.Name = dr("FormID").ToString & "-" & dr("ScreenID").ToString

                If dr("FormID").ToString <> "" Then
                    nRoot.Name = dr("FormID").ToString & "-" & dr("ScreenID").ToString
                    fs = FontStyle.Regular
                    '  nRoot.NodeFont = New Font("Lemon3", 8.25, fs, GraphicsUnit.Point, 0)
                    nRoot.ImageIndex = 1
                    nRoot.SelectedImageIndex = 1

                    'nRoot.ForeColor = Color.Black 'DarkRed
                Else
                    fs = FontStyle.Bold
                    '  nRoot.NodeFont = New Font("Lemon3", 8.25, fs, GraphicsUnit.Point, 0)
                    nRoot.ImageIndex = 0
                    nRoot.SelectedImageIndex = 0
                    'nRoot.ForeColor = Color.Blue 'Green
                End If
                'nRoot.ImageIndex = 0
                'nRoot.SelectedImageIndex = 0
                'nRoot.ForeColor = Color.Blue 'Green
                nRoot.NodeFont = FontUnicode(gbUnicode, fs)
                fs = FontStyle.Regular
                For Each dr1 As DataRow In dtTree.Rows
                    If dr1("ParentLevelID").ToString = dr("ChildLevelID").ToString Then
                        If dr1("LevelID").ToString = "2" And dr1("FormID").ToString <> "" Then
                            nNewNode = New TreeNode(IIf(geLanguage = EnumLanguage.Vietnamese, dr1("ChildLevelName84").ToString, dr1("ChildLevelName01").ToString).ToString)
                            nNewNode.Name = dr1("FormID").ToString & "-" & dr1("ScreenID").ToString
                            nNewNode.NodeFont = FontUnicode(gbUnicode, fs)
                            'nNewNode.NodeFont = New Font("Lemon3", 8.25, fs, GraphicsUnit.Point, 0)
                            'nNewNode.ForeColor = Color.Black 'DarkRed
                            nNewNode.ImageIndex = 1
                            nNewNode.SelectedImageIndex = 1123

                            nRoot.Nodes.Add(nNewNode)
                        End If
                    End If
                Next
                tvw1.Nodes.Add(nRoot)
            End If
        Next
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P1110
    '# Created User: Nguyễn Thị Minh Hòa
    '# Created Date: 28/12/2009 03:00:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD91P1110() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P1110 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(_moduleID) & COMMA 'ModuleID, varchar[20], NOT NULL
        sSQL &= SQLString(gsCompanyID) 'CompanyID, varchar[50], NOT NULL
        Return sSQL
    End Function

#End Region

#Region "Event Button and Option"

    Private Sub btnSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetup.Click
        btnSetup.Enabled = False

        Dim sSaved As String = "False"
        '        Dim f As New D91F1111
        '        With f
        '            .ModuleID = _moduleID
        '            .FormPermission = _formPermission
        '            .ShowDialog()
        '            sSaved = .OutPut01
        '            .Dispose()
        '        End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", _moduleID)
        Dim frm As Form = CallFormShowDialog("D91D0740", "D91F1111", arrPro)
        If L3Bool(GetProperties(frm, "SavedOK")) Then
            giMenuType = 1
            LoadTreeview(True)
        End If
        '        sSaved = IIf(sSaved <> "", sSaved, "False").ToString
        '        If CBool(sSaved) Then
        '            giMenuType = 1
        '            LoadTreeview(True)
        '        End If
        btnSetup.Enabled = True
    End Sub

    Private Sub optPersonal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optPersonal.Click
        btnSetup.Enabled = bPer_F5699
        giMenuType = 1
        LoadTreeview()
    End Sub

    Private Sub optStandard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optStandard.Click
        btnSetup.Enabled = False
        giMenuType = 0
        LoadTreeview()
    End Sub
#End Region

#Region "Gọi các form của module D25"

    Private Sub SelectNode(ByVal SelectedNode As TreeNode)
        If SelectedNode.Name.Trim = "" Then Exit Sub

        Dim sFormID As String = ""
        Dim sScreenID As String = ""
        Dim idxNode As Integer = SelectedNode.Name.IndexOf("-")
        sFormID = SelectedNode.Name.Substring(0, idxNode)
        sScreenID = SelectedNode.Name.Substring(idxNode + 1)


        Select Case sFormID
            'Danh mục
            Case "D25F1050" 'Danh mục -> A. Hồ sơ ứng viên
                'Dim f As New D25M0140
                'f.FormActive = enumD25E0140Form.D25F1050
                'f.ShowDialog()
                'f.Dispose()
                CallFormThread(Me.ParentForm, "D25D0140", "D25F1050")
            Case "D25F1010" 'Danh mục -> B. Nguồn tuyển dụng
                'Dim f As New D25M0140
                'f.FormActive = enumD25E0140Form.D25F1010
                'f.ShowDialog()
                'f.Dispose()
                CallFormThread(Me.ParentForm, "D25D0140", "D25F1010")
            Case "D09F0290" 'Danh mục -> C. Vị trí ứng tuyển
                '                Dim f As New D09F0290
                '                f.ShowDialog()
                '                f.Dispose()
                CallFormThread(Me.ParentForm, "D09D0140", "D09F0290")
            Case "D25F1030" 'Danh mục -> D. Chi phí tuyển dụng
                'Dim f As New D25M0140
                'f.FormActive = enumD25E0140Form.D25F1030
                'f.ShowDialog()
                'f.Dispose()
                CallFormThread(Me.ParentForm, "D25D0140", "D25F1030")
            Case "D25F1070" 'Danh mục -> E. Người phỏng vấn
                'Dim f As New D25M0140
                'f.FormActive = enumD25E0140Form.D25F1070
                'f.ShowDialog()
                'f.Dispose()
                CallFormThread(Me.ParentForm, "D25D0140", "D25F1070")
            Case "D25F1060" 'Danh mục -> F. Loại nghiệp vụ
                'Dim f As New D25M0140
                'f.FormActive = enumD25E0140Form.D25F1060
                'f.ShowDialog()
                'f.Dispose()
                CallFormThread(Me.ParentForm, "D25D0140", "D25F1060")
            Case "D25F1080" 'Danh mục -> G. Loại nghiệp vụ HS ứng cử viên
                'Dim f As New D25M0140
                'f.FormActive = enumD25E0140Form.D25F1080
                'f.ShowDialog()
                'f.Dispose()
                CallFormThread(Me.ParentForm, "D25D0140", "D25F1080")
            Case "D82F1020" 'Danh mục -> H. Cảnh báo
                'Dim f As New D82F1020
                'With f
                '    .FormName = "D82F1020"
                '    .FormPermission = "D25F5611"
                '    .Key01ID = D25
                '    .ShowDialog()
                '    .Dispose()
                'End With
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D25F5611")
                SetProperties(arrPro, "ModuleID", "D25") 'Gọi từ module D82 thì truyền vào "", khác D82 thì truyền vào "Dxx"
                CallFormShow(Me.ParentForm, "D82D1140", "D82F1020", arrPro)

                'Truy vấn
            Case "D25F3080" 'Truy vấn ->A. Kế hoạch tuyển dụng
                'Dim f As New D25M0240
                'With f
                '    .FormActive = enumD25E0240Form.D25F3080
                '    .ShowDialog()
                '    .Dispose()
                'End With
                CallFormThread(Me.ParentForm, "D25D0240", "D25F3080")
            Case "D25F3000" 'Truy vấn ->B. Đề xuất tuyển dụng
                'Dim f As New D25M0240
                'With f
                '    .FormActive = enumD25E0240Form.D25F3000
                '    .ShowDialog()
                '    .Dispose()
                'End With
                'CallFormThread("D25D0240", "D25F3000")
                CallFormShow(Me.ParentForm, "D25D0240", "D25F3000")
                '-----------Form khong su dung-----------
                'Case "D25F3030" 'Truy vấn ->C. Kế hoạch tuyển dụng
                '    Dim f As New D25F3030
                '    With f
                '        .ShowDialog()
                '        .Dispose()
                '    End With
            Case "D25F3070" 'Truy vấn ->C. Thông báo tuyển dụng
                'Dim f As New D25M0240
                'With f
                '    .FormActive = enumD25E0240Form.D25F3070
                '    .ShowDialog()
                '    .Dispose()
                'End With
                CallFormThread(Me.ParentForm, "D25D0240", "D25F3070")
            Case "D25F3010" 'Truy vấn ->D. Lập đợt tuyển dụng
                'Dim f As New D25M0240
                'With f
                '    .FormActive = enumD25E0240Form.D25F3010
                '    .ShowDialog()
                '    .Dispose()
                'End With
                'CallFormShow(frmD25F0000, "D25D0240", "D25F3010")
                CallFormShow(Me.ParentForm, "D25D0240", "D25F3010")
            Case "D25F3020" 'Truy vấn ->E. Lập lịch phỏng vấn
                'Dim f As New D25M0240
                'With f
                '    .FormActive = enumD25E0240Form.D25F3020
                '    .ShowDialog()
                '    .Dispose()
                'End With
                CallFormShow(Me.ParentForm, "D25D0240", "D25F3020")
            Case "D25F3040" 'Truy vấn -> F. Kết quả phỏng vấn
                'Dim f As New D25M0240
                'With f
                '    .FormActive = enumD25E0240Form.D25F3040
                '    .ShowDialog()
                '    .Dispose()
                'End With
                CallFormThread(Me.ParentForm, "D25D0240", "D25F3040")
            Case "D25F3060" 'Truy vấn -> G. Quyết định tuyển dụng
                'Dim f As New D25M0240
                'With f
                '    .FormActive = enumD25E0240Form.D25F3060
                '    .ShowDialog()
                '    .Dispose()
                'End With
                CallFormThread(Me.ParentForm, "D25D0240", "D25F3060")
            Case "D25F3050" 'Truy vấn -> H. Kết quả tuyển dụng
                'Dim f As New D25M0440
                'With f
                '    .FormActive = enumD25E0440Form.D25F3050
                '    .ShowDialog()
                '    .Dispose()
                'End With
                CallFormThread(Me.ParentForm, "D25D0440", "D25F3050")
            Case "D25F3090" 'Truy vấn -> I. Chi phí tuyển dụng
                'Dim f As New D25M0240
                'With f
                '    .FormActive = enumD25E0240Form.D25F3090
                '    .ShowDialog()
                '    .Dispose()
                'End With
                CallFormShow(Me.ParentForm, "D25D0240", "D25F3090")
                'Báo cáo
            Case "D25F4090" 'Kế hoạch tuyển dụng tổng thể
                'Dim f As New D25M0340
                'f.FormActive = enumD25E0340Form.D25F4090
                'f.ShowDialog()
                'f.Dispose()
                CallFormThread(Me.ParentForm, "D25D0340", "D25F4090")
            Case "D25F4000" 'Danh sách ứng cử viên
                'Dim f As New D25M0340
                'f.FormActive = enumD25E0340Form.D25F4000
                'f.ShowDialog()
                'f.Dispose()
                CallFormShow(Me.ParentForm, "D25D0340", "D25F4000")
            Case "D25F4050" 'Báo cáo phiếu đề xuất tuyển dụng
                'Dim f As New D25M0340
                'f.FormActive = enumD25E0340Form.D25F4050
                'f.ShowDialog()
                'f.Dispose()
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "IsMSS", 0)
                CallFormShow(Me.ParentForm, "D25D0340", "D25F4050", arrPro)
            Case "D25F4060" 'Kế hoạch tuyển dụng
                'Dim f As New D25M0340
                'f.FormActive = enumD25E0340Form.D25F4060
                'f.ShowDialog()
                'f.Dispose()
                CallFormShow(Me.ParentForm, "D25D0340", "D25F4060")
            Case "D25F4070" 'Thông báo tuyển dụng
                'Dim f As New D25M0340
                'f.FormActive = enumD25E0340Form.D25F4070
                'f.ShowDialog()
                'f.Dispose()
                CallFormShow(Me.ParentForm, "D25D0340", "D25F4070")
            Case "D25F4080" 'Lịch phỏng vấn/Thư mời
                'Dim f As New D25M0340
                'f.FormActive = enumD25E0340Form.D25F4080
                'f.ShowDialog()
                'f.Dispose()
                CallFormShow(Me.ParentForm, "D25D0340", "D25F4080")
            Case "D25F4020" 'Kết quả phỏng vấn
                'Dim f As New D25M0340
                'f.FormActive = enumD25E0340Form.D25F4020
                'f.ShowDialog()
                'f.Dispose()
                CallFormShow(Me.ParentForm, "D25D0340", "D25F4020")
            Case "D25F4010" 'Kết quả tuyển dụng
                'Dim f As New D25M0340
                'f.FormActive = enumD25E0340Form.D25F4010
                'f.ShowDialog()
                'f.Dispose()
                CallFormShow(Me.ParentForm, "D25D0340", "D25F4010")
                ' CallFormShow(D25F0000, "D25D0340", "D25F4010")
            Case "D25F4040" 'Chi phí tuyển dụng
                'Dim f As New D25M0340
                'f.FormActive = enumD25E0340Form.D25F4040
                'f.ShowDialog()
                'f.Dispose()
                CallFormShow(Me.ParentForm, "D25D0340", "D25F4040")
                '------------Form khong su dung----------
                'Case "D89F9100"
                '    Dim f As New D25F9100
                '    f.ShowDialog()
                '    f.Dispose()
                'Case "D89F9101"
                '    Dim f As New D25F9101
                '    f.ShowDialog()
                '    f.Dispose()
        End Select

    End Sub

#End Region

End Class
