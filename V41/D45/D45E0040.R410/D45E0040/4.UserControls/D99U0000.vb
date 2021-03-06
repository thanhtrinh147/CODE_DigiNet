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
            'ID 65449
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
                nRoot = New TreeNode(IIf(geLanguage = EnumLanguage.Vietnamese, dr("ChildLevelName84U").ToString, dr("ChildLevelName01").ToString).ToString)
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
                    nRoot.NodeFont = FontUnicode(gbUnicode, fs)  'New Font("Lemon3", 8.25, fs, GraphicsUnit.Point, 0)
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
                            nNewNode = New TreeNode(IIf(geLanguage = EnumLanguage.Vietnamese, dr1("ChildLevelName84U").ToString, dr1("ChildLevelName01").ToString).ToString)
                            nNewNode.Name = dr1("FormID").ToString & "-" & dr1("ScreenID").ToString

                            nNewNode.NodeFont = FontUnicode(gbUnicode, fs)  'New Font("Lemon3", 8.25, fs, GraphicsUnit.Point, 0)
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

        Dim sSaved As String = "False"
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

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModuleID", _moduleID)
        Dim frm As Form = CallFormShowDialog("D91D0740", "D91F1111", arrPro)
        If L3Bool(GetProperties(frm, "SavedOK")) Then
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

#Region "Gọi các form của module D21"

    Private Sub SelectNode(ByVal SelectedNode As TreeNode)
        If SelectedNode.Name.Trim = "" Then Exit Sub
      
        Dim sFormID As String = ""
        Dim sScreenID As String = ""
        Dim idxNode As Integer = SelectedNode.Name.IndexOf("-")
        sFormID = SelectedNode.Name.Substring(0, idxNode)
        sScreenID = SelectedNode.Name.Substring(idxNode + 1)

        Select Case sFormID
            'Danh mục
            Case "D45F1000" 'Danh mục sản phẩm
                CallFormShow(Me.ParentForm, "D45D0140", "D45F1000") 'RunEXEDxxExx40("D45E0140", "D45F1000")
            Case "D45F1010" 'Danh mục công đoạn
                CallFormShow(Me.ParentForm, "D45D0140", "D45F1010") 'RunEXEDxxExx40("D45E0140", "D45F1010")
            Case "D07F0009" 'Danh mục đơn vị tính
                ' RunEXEDxxExx40("D07E0140", "D07F0009", "D45F5601")
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D45F5601")
                CallFormShow(Me.ParentForm, "D07D1240", "D07F0009", arrPro)
            Case "D07F1410"
                ' RunEXEDxxExx40("D07E0140", "D07F1410", "D45F1090")
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D45F1090")
                CallFormShow(Me.ParentForm, "D07D1440", "D07F1410", arrPro)
            Case "D45F1020" 'Danh mục bảng giá
                CallFormShow(Me.ParentForm, "D45D0140", "D45F1020") '  RunEXEDxxExx40("D45E0140", "D45F1020")
            Case "D45F1030" 'Danh mục quy trình sản xuất chuẩn
                CallFormShow(Me.ParentForm, "D45D0140", "D45F1030") '  RunEXEDxxExx40("D45E0140", "D45F1030")
            Case "D45F1040" 'Danh mục loại nghiệp vụ
                CallFormShow(Me.ParentForm, "D45D0140", "D45F1040") '  RunEXEDxxExx40("D45E0140", "D45F1040")
            Case "D45F1070" 'Danh mục nhóm sản phẩm
                CallFormShow(Me.ParentForm, "D45D0140", "D45F1070") ' RunEXEDxxExx40("D45E0140", "D45F1070")
            Case "D45F1050" 'Danh mục nhóm chấm công sản phẩm
                CallFormShow(Me.ParentForm, "D45D0140", "D45F1050") '  RunEXEDxxExx40("D45E0140", "D45F1050")
            Case "D45F1060" 'Danh mục phương pháp tính lương sản phẩm
                CallFormShow(Me.ParentForm, "D45D0140", "D45F1060") ' RunEXEDxxExx40("D45E0140", "D45F1060")
            Case "D45F1080" 'Quy trinh san xuat san pham
                CallFormShow(Me.ParentForm, "D45D0140", "D45F1080") 'RunEXEDxxExx40("D45E0140", "D45F1080")
                '*********************************
                'Truy van
            Case "D45F2020"
                CallFormThread(Me.ParentForm, "D45D0240", "D45F2020") '  RunEXEDxxExx40("D45E0240", "D45F2020")
            Case "D45F2000" 'Truy vấn chấm công sản phẩm
                CallFormThread(Me.ParentForm, "D45D0240", "D45F2000") 'RunEXEDxxExx40("D45E0240", "D45F2000")
            Case "D45F2030" 'Truy vấn đơn giá giờ công hệ số
                CallFormThread(Me.ParentForm, "D45D0240", "D45F2030") '  RunEXEDxxExx40("D45E0240", "D45F2030")
            Case "D45F3000" 'Truy vấn kết quả tính lương
                CallFormShow(Me.ParentForm, "D45D4040", "D45F3000") '  RunEXEDxxExx40("D45E4040", "D45F3000")
                '*********************************
                'Báo cáo
            Case "D45F4000" 'Báo cáo chấm công sản phẩm
                CallFormShow(Me.ParentForm, "D45D0340", "D45F4000") ' RunEXEDxxExx40("D45E0340", "D45F4000")
            Case "D45F4010" 'Báo cáo bảng giá
                CallFormShow(Me.ParentForm, "D45D0340", "D45F4010") '  RunEXEDxxExx40("D45E0340", "D45F4010")
            Case "D45F4020" 'Báo cáo phiếu lương sản phẩm
                CallFormShow(Me.ParentForm, "D45D0340", "D45F4020") ' RunEXEDxxExx40("D45E0340", "D45F4020")
            Case "D45F4030" 'Thiết lập bảng lương sản phẩm
                CallFormShow(Me.ParentForm, "D45D0340", "D45F4030") 'RunEXEDxxExx40("D45E0340", "D45F4030")
            Case "D89F9100"
                '                Dim exe As New D89E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
                '                exe.FormActive = D89E0140Form.D89F9100
                '                exe.FormPermission = "D45F9100"  'Truy?n giá tr? khác nhau t?ng module 
                '                exe.ModuleID = "D45"             'Truy?n giá tr? khác nhau t?ng module 
                '                exe.Run()
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "ModuleID", "D45")
                CallFormShow(Me.ParentForm, "D89D0140", "D89F9100", arrPro)
            Case "D89F9101"
                '                'IncidentID	52036  	D45\ Báo cáo\ Thiết lập mẫu báo cáo gọi exe D89E4240
                '                Dim exe As New D89E4240(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
                '                With exe
                '                    .FormActive = D89E4240Form.D89F9101
                '                    .FormPermission = "D45F9101" 'Mã màn hình phân quyền
                '                    .Run()
                '                End With
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D45F9101")
                CallFormShow(Me.ParentForm, "D89D4240", "D89F9101", arrPro)
        End Select
    End Sub
#End Region

End Class
