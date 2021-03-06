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
        btnSetup.Text = rL3("Thiet__lap") '"Thiết &lập"
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
            '20/5/2014 ID 65443 
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
                    D99C0008.MsgL3(rL3("Vui_long_thiet_lap_menu_theo_nguoi_dung"))
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
                    nRoot.NodeFont = FontUnicode(gbUnicode, fs) ' New Font("Lemon3", 8.25, fs, GraphicsUnit.Point, 0)
                    nRoot.ImageIndex = 1
                    nRoot.SelectedImageIndex = 1

                    'nRoot.ForeColor = Color.Black 'DarkRed
                Else
                    fs = FontStyle.Bold
                    nRoot.NodeFont = FontUnicode(gbUnicode, fs) '  New Font("Lemon3", 8.25, fs, GraphicsUnit.Point, 0)
                    nRoot.ImageIndex = 0
                    nRoot.SelectedImageIndex = 0
                    'nRoot.ForeColor = Color.Blue 'Green
                End If
                'nRoot.ImageIndex = 0
                'nRoot.SelectedImageIndex = 0
                'nRoot.ForeColor = Color.Blue 'Green

                fs = FontStyle.Regular
                For Each dr1 As DataRow In dtTree.Rows
                    If dr1("ParentLevelID").ToString = dr("ChildLevelID").ToString Then
                        If dr1("LevelID").ToString = "2" And dr1("FormID").ToString <> "" Then
                            nNewNode = New TreeNode(IIf(geLanguage = EnumLanguage.Vietnamese, dr1("ChildLevelName84").ToString, dr1("ChildLevelName01").ToString).ToString)
                            nNewNode.Name = dr1("FormID").ToString & "-" & dr1("ScreenID").ToString

                            nNewNode.NodeFont = FontUnicode(gbUnicode, fs) ' New Font("Lemon3", 8.25, fs, GraphicsUnit.Point, 0)
                            'nNewNode.ForeColor = Color.Black 'DarkRed
                            nNewNode.ImageIndex = 1
                            nNewNode.SelectedImageIndex = 1
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

        'Dim sSaved As String = "False"
        'Dim f As New D91F1111
        'With f
        '    .ModuleID = _moduleID
        '    .FormPermission = _formPermission
        '    .ShowDialog()
        '    sSaved = .OutPut01
        '    .Dispose()
        'End With
        'sSaved = IIf(sSaved <> "", sSaved, "False").ToString
        'If CBool(sSaved) Then
        '    giMenuType = 1
        '    LoadTreeview(True)
        'End If

        'ID 79394 8/9/2015
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", _moduleID)
        SetProperties(arrPro, "FormPermission", _formPermission)
        Dim frm As Form = CallFormShowDialog("D91D0740", "D91F1111", arrPro)
        If L3Bool(GetProperties(frm, "SavedOK")) Then
            'Load lai dữ liệu
            giMenuType = 1
            LoadTreeview(True)
        End If

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

#Region "Gọi các form của module D13"

    Private Sub SelectNode(ByVal SelectedNode As TreeNode)
        If SelectedNode.Name.Trim = "" Then Exit Sub
        'Select Case SelectedNode.Level
        '   Case 1 'node con
        Dim sFormID As String = ""
        Dim sScreenID As String = ""
        Dim idxNode As Integer = SelectedNode.Name.IndexOf("-")
        sFormID = SelectedNode.Name.Substring(0, idxNode)
        sScreenID = SelectedNode.Name.Substring(idxNode + 1)

        Select Case sFormID
            Case "D13F2050"
                CallFormShow(Me.ParentForm, "D13D1040", "D13F2050")
                'Danh mục
            Case "D13F1180" 'Danh mục ---> A. Nhóm lương
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1180")
                '                Dim exe As New D13E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
                '                exe.FormActive = enumD13E0140Form.D13F1180
                '                exe.FormPermission = "D13F1180"
                '                exe.Run()
            Case "D13F2012" 'Danh mục ---> A. Hồ sơ lương gốc
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "Path", "04")
                CallFormThread(Me.ParentForm, "D13D2040", "D13F2012", arrPro)

                '                ' 14/1/2014 id 60442
                '                Dim f As New D13M2040
                '                With f
                '                    .FormActive = enumD13E2040Form.D13F2012
                '                    ' 20/11/2013 id 61095
                '                    .ID01 = "04" '   .ID01 = "01"
                '                    .PayRollVoucherID = gsPayRollVoucherID
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1000" 'Danh mục ---> B. Khoản điều chỉnh thu nhập
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1000")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1000
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1130" 'Danh mục ---> C. Loại nghiệp vụ
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1130")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1130
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1010" 'Danh mục ---> D. Đối tượng thuế thu nhập
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1010")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1010
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1140" 'Danh mục ---> E. Đối tượng tính lương
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1140")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1140
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1080" 'Danh mục ---> F. Thưởng theo thâm niên
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1080")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1080
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1070" 'Danh mục ---> G. Đánh giá xếp loại
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1080")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1070
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1040" 'Danh mục ---> H. Ngạch lương
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1040")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1040
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1050" 'Danh mục ---> I. Bậc lương
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1050")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1050
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1060" 'Danh mục ---> J. Danh mục template tăng thông số lương
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1060")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1060
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1160" 'Danh mục ---> K. Thông số lương mặc định
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1160")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1160
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1090" 'Danh mục ---> L. Mã phân tích tiền lương
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1090")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1090
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1100" 'Danh mục ---> M.Bảng tham chiếu kết quả
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1100")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1100
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F1150" 'Danh mục ---> N. Phương pháp điều chỉnh lương
                CallFormShow(Me.ParentForm, "D13D0140", "D13F1150")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F1150
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F2050" 'Danh mục ---> O. Phương pháp tính lương
                CallFormShow(Me.ParentForm, "D13D0140", "D13F2050")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F2050
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With

            Case "D13F2060" 'Danh mục ---> P. Phương pháp chuyển bút toán
                If D13Systems.IsNewTransferPolicyMode Then
                    CallFormShow(Me.ParentForm, "D13D0140", "D13F2160")
                    '                    Dim f As New D13M0140
                    '                    With f
                    '                        .FormActive = enumD13E0140Form.D13F2160
                    '                        .ShowDialog()
                    '                        .Dispose()
                    '                    End With
                Else
                    CallFormShow(Me.ParentForm, "D13D0140", "D13F2060")
                    '                    Dim f As New D13M0140
                    '                    With f
                    '                        .FormActive = enumD13E0140Form.D13F2060
                    '                        .ShowDialog()
                    '                        .Dispose()
                    '                    End With
                End If

            Case "D13F2165" 'Danh mục ---> Q. Cơ chế chuyển bút toán
                CallFormShow(Me.ParentForm, "D13D0140", "D13F2165")
                '                Dim f As New D13M0140
                '                With f
                '                    .FormActive = enumD13E0140Form.D13F2165
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With

            Case "D82F1020" 'Danh mục ---> R. Danh mục cảnh báo
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D13F5606")
                SetProperties(arrPro, "ModuleID", "D13") 'Gọi từ module D82 thì truyền vào "", khác D82 thì truyền vào "Dxx"
                CallFormShow("D82D1140", "D82F1020", arrPro)
                '                Dim f As New D82F1020
                '                With f
                '                    .FormName = "D82F1020"
                '                    .FormPermission = "D13F5606" 'Theo tài liệu PSAD
                '                    .Key01ID = D13
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With

                'Truy vấn
            Case "D13F3010" 'Truy vấn -->A. Chuyển bút toán
                CallFormThread(Me.ParentForm, "D13D0440", "D13F3010")
                '                Dim f As New D13M0440
                '                With f
                '                    .FormActive = enumD13E0440Form.D13F3010
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F2070" 'Truy vấn -->C. Khai thuế TNCN
                CallFormThread(Me.ParentForm, "D13D0240", "D13F2070")
                '                Dim f As New D13M0240
                '                With f
                '                    .FormActive = enumD13E0240Form.D13F2070
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F2080" 'Truy vấn -->D. Quyết toán thuế TNCN
                CallFormThread(Me.ParentForm, "D13D0240", "D13F2080")
                '                Dim f As New D13M0240
                '                With f
                '                    .FormActive = enumD13E0240Form.D13F2080
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F3020", "D13F3030", "D13F3050"
                ' update 26/3/2013 id 55274
                '                "D13F3020" - 'Phân tích thống kê --> Quỹ trợ cấp thôi việc
                '                "D13F3030" - 'Phân tích thống kê --> Lịch sử lương
                '                "D13F3050" - 'Phân tích thống kê --> Đối chiếu dữ liệu tính lương
                CallFormShow(Me.ParentForm, "D13D4040", sFormID)
                ' RunEXEDxxExx40("D13E4040", sFormID)
                '            Case "D13F3020"
                '                Dim f As New D13M0440
                '                With f
                '                    .FormActive = enumD13E0440Form.D13F3020
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
                '            Case "D13F3030" 'Truy vấn -->E. Lịch sử lương
                '                Dim f As New D13M0440
                '                With f
                '                    .FormActive = enumD13E0440Form.D13F3030
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
                '            Case "D13F3050" 'Truy vấn -->F. Đối chiếu dữ liệu tính lương
                '                Dim f As New D13M0440
                '                With f
                '                    .FormActive = enumD13E0440Form.D13F3050
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With

                'Báo cáo

            Case "D13F4010" 'Báo cáo ---> B. Điều chỉnh thu nhập
                CallFormShow(Me.ParentForm, "D13D0340", "D13F4010")
                '                Dim f As New D13M0340
                '                With f
                '                    .FormActive = enumD13E0340Form.D13F4010
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With

            Case "D13F4020" 'Báo cáo ---> C. Bảng lương công ty
                CallFormShow(Me.ParentForm, "D13D0340", "D13F4020")
                '                Dim f As New D13M0340
                '                With f
                '                    .FormActive = enumD13E0340Form.D13F4020
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F4021" 'Báo cáo ---> D. Chuyển bảng lương qua Email
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "bIsTransferByEmail", True)
                '    SetProperties(arrPro, "FormIDPermission", "D13F5609") ' Hiện tại thấy D13F4020 khong sử đụng tham số này
                CallFormShow(Me.ParentForm, "D13D0340", "D13F4020", arrPro)
                '                Dim f As New D13M0340
                '                With f
                '                    .FormActive = enumD13E0340Form.D13F4020
                '                    .ID02 = CType(True, String)
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F4060" 'Báo cáo ---> E. Khai thuế TNCN
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "PITVoucherID", "")
                SetProperties(arrPro, "BlockID", "%")
                SetProperties(arrPro, "DepartmentID", "%")
                SetProperties(arrPro, "TeamID", "%")
                SetProperties(arrPro, "DeductionLabor", True)
                SetProperties(arrPro, "NonDeductionLabor", False)
                SetProperties(arrPro, "WhereClause", "")

                CallFormShow(Me.ParentForm, "D13D0340", "D13F4060", arrPro)
                '                Dim f As New D13M0340
                '                With f
                '                    .FormActive = enumD13E0340Form.D13F4060
                '                    .ID01 = "" 'PITVoucherID
                '                    .ID02 = "%" 'BlockID
                '                    .ID03 = "%" 'DepartmentID
                '                    .ID04 = "%" 'TeamID
                '                    .ID05 = CType(True, String) 'DeductionLabor
                '                    .ID06 = CType(False, String) 'NonDeductionLabor
                '                    .ID07 = "" 'WhereClause
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With

            Case "D13F4070" 'Báo cáo ---> F. Quyết toán thuế TNCN
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "PITBalanceVoucherID", "")
                SetProperties(arrPro, "BlockID", "%")
                SetProperties(arrPro, "DepartmentID", "%")
                SetProperties(arrPro, "TeamID", "%")
                SetProperties(arrPro, "WhereClause", "")

                CallFormShow(Me.ParentForm, "D13D0340", "D13F4070", arrPro)
                '                Dim f As New D13M0340
                '                With f
                '                    .FormActive = enumD13E0340Form.D13F4070
                '                    .ID01 = "" 'PITBalanceVoucherID
                '                    .ID02 = "%" 'BlockID
                '                    .ID03 = "%" 'DepartmentID
                '                    .ID04 = "%" 'TeamID
                '                    .ID05 = "" 'WhereClause
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With
            Case "D13F4090" 'Báo cáo ---> Giảm trừ gia cảnh
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "CallFormID", "D13F4090")
                CallFormShow(Me.ParentForm, "D13D0140", "D13F4050", arrPro)
                '                Dim frm As New D13F4050
                '                With frm
                '                    .CallForm = "D13F4090"
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With

                'Thiết lập báo cáo
            Case "D13F4030" 'Báo cáo ---> G. Thiết lập bảng lương
                CallFormShow(Me.ParentForm, "D13D0340", "D13F4030")
                '                Dim f As New D13M0340
                '                With f
                '                    .FormActive = enumD13E0340Form.D13F4030
                '                    .ShowDialog()
                '                    .Dispose()
                '                End With

            Case "D89F9100"
                '                Dim f As New D89F9100 'form ảo
                '                f.ShowDialog()
                '                f.Dispose()
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "ModuleID", "D13")
                CallFormShow(Me.ParentForm, "D89D0140", "D89F9100", arrPro)
            Case "D89F9101"
                '                Dim f As New D89F9101
                '                Me.Cursor = Cursors.WaitCursor
                '                f.ShowDialog()
                '                f.Dispose()
                '                Me.Cursor = Cursors.Default
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D13F9101")
                CallFormShow(Me.ParentForm, "D89D4240", "D89F9101", arrPro)

            Case Else
                Try
                    Dim frm As New Form
                    Dim frmName As String = sFormID
                    frmName = System.Reflection.Assembly.GetEntryAssembly.GetName.Name & "." & frmName
                    frm = DirectCast(System.Reflection.Assembly.GetEntryAssembly.CreateInstance(frmName), Form)
                    frm.ShowDialog()
                    frm.Dispose()
                Catch ex As Exception
                    D99C0008.MsgL3(ex.Message)
                End Try

        End Select

        'End Select
    End Sub
#End Region

End Class
