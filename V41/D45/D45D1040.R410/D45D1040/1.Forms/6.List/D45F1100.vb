Imports System.Windows.Forms
Imports System
Public Class D45F1100
    Dim dtMethodID, dtCaptionCols As DataTable
    Private dtGrid As DataTable
    Dim bCallFormAddNew As Boolean = False 'True khi gọi  từ <+> của combo từ Form khác
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        AnchorForControl(EnumAnchorStyles.TopLeftRight, grpFilter)
        AnchorForControl(EnumAnchorStyles.TopRight, grpDetail, pnlButton)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkShowDisabled)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnFilter, btnSave, btnNext, btnNotSave)
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Const of tdbg - Total of Columns: 12"
    Private Const COL_OrderNum As Integer = 0                         ' STT
    Private Const COL_GroupProductID As String = "GroupProductID"     ' Nhóm sản phẩm
    Private Const COL_ComponentID As String = "ComponentID"         ' Nhóm tiểu tác
    Private Const COL_TaskID As String = "TaskID"                     ' Cụm tiểu tác
    Private Const COL_TaskName As String = "TaskName"                 ' Tên cụm tiểu tác
    Private Const COL_Disabled As String = "Disabled"                 ' KSD
    Private Const COL_Notes As String = "Notes"                       ' Notes
    Private Const COL_IGEMethodID As String = "IGEMethodID"           ' IGEMethodID
    Private Const COL_CreateUserID As String = "CreateUserID"         ' CreateUserID
    Private Const COL_LastModifyUserID As String = "LastModifyUserID" ' LastModifyUserID
    Private Const COL_CreateDate As String = "CreateDate"             ' CreateDate
    Private Const COL_LastModifyDate As String = "LastModifyDate"     ' LastModifyDate
#End Region

    Private _formIDPermission As String = "D45F1100"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _groupProductID As String = ""
    Public WriteOnly Property GroupProductID As String
        Set(ByVal Value As String)
            _groupProductID = Value
        End Set
    End Property

    Private _componentID As String = ""
    Public WriteOnly Property ComponentID As String
        Set(ByVal Value As String)
            _componentID = Value
        End Set
    End Property

    Private _taskID As String = ""
    Public Property TaskID As String
        Get
            Return _taskID
        End Get
        Set(ByVal Value As String)
            _taskID = Value
        End Set
    End Property
    

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState = EnumFormState.FormView
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            _FormState = value

            LoadTDBCombo()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    bCallFormAddNew = True
                    ResizeForm() ' gọi từ Nghiệp vụ
                    LoadDataDefault()
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
            End Select
        End Set
    End Property

    Private Sub D56F1030_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormAdd Then
            tdbcMethodID.Focus()
        Else
            chkDisabled.Focus()
        End If
    End Sub

    Private Sub D57F1000_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _FormState = EnumFormState.FormEdit Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If tdbcGroupProductID.Text <> "" Then
                If Not _bSaved Then
                    If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub D57F1000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If Me.ActiveControl.Name = txtNotes.Name Then Exit Sub
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(sender, Nothing)
        End Select
    End Sub

    Private Sub D57F1000_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        SetBackColorObligatory()
        ResetColorGrid(tdbg)
        LoadLanguage()
        If Not _FormState = EnumFormState.FormAdd Then
            EnableMenu(False)
            LockControlDetail(True)
        End If
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtTaskID)
        SetImageButton(btnSave, btnNotSave, btnNext, imgButton)
        SetShortcutPopupMenuNew(Me, ToolStrip1, ContextMenuStrip1, False)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ResizeForm()
        ' Cách lấy kích thước
        Dim iTitleHeight As Integer = 22 ' chiều cao TitleHeight
        Dim iLine As Integer = 3 ' 3 đường viền Trái, Phải, Trên
        Dim iWidthControl As Integer = 5 ' khoảng cách các từ viền trái tới GroupBox

        ToolStrip1.Visible = False
        grpFilter.Visible = False
        tdbg.Visible = False
        chkShowDisabled.Visible = False
        chkDisabled.Visible = False

        grpDetail.Location = New Point(iWidthControl, iWidthControl)
        Me.Width = grpDetail.Width + (2 * (iWidthControl + iLine)) ' Khoảng cách cách ra 2 bên
        Me.Height = grpDetail.Height + grpDetail.Location.Y + iTitleHeight + iLine + pnlButton.Height + (2 * iWidthControl)
        '**************************
        btnNotSave.Visible = False
        pnlButton.Width = pnlButton.Width - btnNotSave.Width - iWidthControl
        pnlButton.Location = New Point(Me.Width - pnlButton.Width - (2 * iLine) - iWidthControl + 3, Me.Height - pnlButton.Height - iTitleHeight - iLine - iWidthControl)
    End Sub
    Private Sub SetBackColorObligatory()
        tdbcGroupProductIDM.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcComponentIDM.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtTaskID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtTaskName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcGroupProductID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcComponentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_cum_tieu_tac") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Danh móc cóm tiÓu tÀc
        '================================================================ 
        lblTaskID.Text = rl3("Ma") 'Mã
        lblNotes.Text = rl3("Ghi_chu") 'Ghi chú
        lblTaskName.Text = rl3("Ten") 'Tên
        lblMethodID.Text = rl3("PP_tao_ma_tu_dong") 'PP tạo mã tự động
        lblGroupProductID.Text = rl3("Nhom_san_pham") 'Nhóm sản phẩm
        lblComponentID.Text = rl3("Nhom_tieu_tac") 'Nhóm tiểu tác
        lblGroupProductIDM.Text = rl3("Nhom_san_pham") 'Nhóm sản phẩm
        lblComponentIDM.Text = rl3("Nhom_tieu_tac") 'Nhóm tiểu tác
        '================================================================ 
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu và Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNotSave.Text = rl3("Khong_luu") 'Không Lưu
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        '================================================================ 
        grpDetail.Text = rl3("Chi_tiet") 'Chi tiết
        '================================================================ 
        tdbcComponentID.Columns("ComponentID").Caption = rl3("Ma") 'Mã
        tdbcComponentID.Columns("ComponentName").Caption = rl3("Ten") 'Tên
        tdbcGroupProductID.Columns("GroupProductID").Caption = rl3("Ma") 'Mã
        tdbcGroupProductID.Columns("GroupProductName").Caption = rl3("Ten") 'Tên
        tdbcMethodID.Columns("MethodID").Caption = rl3("Ma") 'Mã
        tdbcMethodID.Columns("MethodName").Caption = rl3("Ten") 'Tên
        tdbcComponentIDM.Columns("ComponentID").Caption = rl3("Ma") 'Mã
        tdbcComponentIDM.Columns("ComponentName").Caption = rl3("Ten") 'Tên
        tdbcGroupProductIDM.Columns("GroupProductID").Caption = rl3("Ma") 'Mã
        tdbcGroupProductIDM.Columns("GroupProductName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_OrderNum).Caption = rl3("STT") 'STT
        tdbg.Columns(COL_GroupProductID).Caption = rl3("Nhom_san_pham") 'Nhóm sản phẩm
        tdbg.Columns(COL_ComponentID).Caption = rl3("Nhom_tieu_tac") 'Nhóm tiểu tác
        tdbg.Columns(COL_TaskID).Caption = rl3("Cum_tieu_tac") 'Cụm tiểu tác
        tdbg.Columns(COL_TaskName).Caption = rl3("Ten_cum_tieu_tac") 'Tên cụm tiểu tác
        tdbg.Columns(COL_Disabled).Caption = rl3("KSD") 'KSD
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcMethodID
        sSQL = "-- Combo phuong phap tao ma tu dong" & vbCrLf
        sSQL &= "	SELECT		MethodID, MethodNameU as MethodName, IsDefault" & vbCrLf
        sSQL &= "	   FROM			D09T1600  WITH(NOLOCK)" & vbCrLf
        sSQL &= "	WHERE		Disabled=0 And TypeCode = '47'" & vbCrLf
        sSQL &= "				And ( DivisionID =  " & SQLString(gsDivisionID) & " Or DivisionID = '' )" & vbCrLf
        sSQL &= "        ORDER BY	MethodName	" & vbCrLf

        dtMethodID = ReturnDataTable(sSQL)

        LoadDataSource(tdbcMethodID, dtMethodID, gbUnicode)

        'Load tdbcGroupProductID,tdbcGroupProductIDM
        LoadTDBCGroupProductID()

        'Load tdbcComponentID
        LoadTDBCComponentID(tdbcComponentID, ReturnValueC1Combo(tdbcGroupProductID))
    End Sub

    Private Sub LoadTDBCGroupProductID(Optional sGroupProductIDM As String = "%")
        Dim sSQL As String = ""
        'Load tdbcGroupProductID
        sSQL = "---- Do nguon combo nhom san pham " & vbCrLf
        sSQL &= "	SELECT  		'+' AS GroupProductID, " & NewName & " AS  GroupProductName, 0 AS DisplayOrder " & vbCrLf
        sSQL &= "	UNION " & vbCrLf
        sSQL &= "	SELECT  		'%' AS GroupProductID, " & AllName & " AS  GroupProductName, 0 AS DisplayOrder " & vbCrLf
        sSQL &= "	UNION " & vbCrLf
        sSQL &= "	SELECT 		GroupProductID, GroupProductNameU as GroupProductName, 1 AS DisplayOrder" & vbCrLf
        sSQL &= "	FROM 		D45T1070 WITH(NOLOCK)" & vbCrLf
        sSQL &= "   WHERE  Disabled = 0 " & vbCrLf
        sSQL &= "	ORDER BY DisplayOrder, GroupProductName" & vbCrLf
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcGroupProductID, ReturnTableFilter(dt, "GroupProductID <> '%'", True), gbUnicode)

        'Load tdbcGroupProductIDM
        LoadDataSource(tdbcGroupProductIDM, ReturnTableFilter(dt, "GroupProductID <> '+'", True), gbUnicode)
        tdbcGroupProductIDM.SelectedValue = sGroupProductIDM
    End Sub

    Dim dtComponentID As DataTable = Nothing
    Private Sub LoadTDBCComponentID(tdbc As C1.Win.C1List.C1Combo, sGroupProductID As String, Optional sComponentID As String = "%")
        Dim sSQL As String = ""
        'Load tdbcComponentID

        If dtComponentID Is Nothing Then
            sSQL = "-- Combo nhom tieu tac" & vbCrLf
            sSQL &= "	SELECT  		'+' AS ComponentID, " & NewName & "  AS  ComponentName, '%' As GroupProductID, 0 AS DisplayOrder" & vbCrLf
            sSQL &= "	UNION " & vbCrLf
            sSQL &= "	SELECT  		'%' AS ComponentID, " & AllName & " AS  ComponentName, '%' As GroupProductID, 0 AS DisplayOrder" & vbCrLf
            sSQL &= "	UNION " & vbCrLf
            sSQL &= "	SELECT 		ComponentID, ComponentNameU as ComponentName, GroupProductID, 1 AS DisplayOrder" & vbCrLf
            sSQL &= "	FROM 		D45T1090 WITH(NOLOCK)" & vbCrLf
            sSQL &= "   WHERE  Disabled = 0 " & vbCrLf
            sSQL &= "	ORDER BY 	DisplayOrder, ComponentName" & vbCrLf
            dtComponentID = ReturnDataTable(sSQL)
        End If
        '**************************
        Dim sWhere As String = ""
        If tdbc.Name = tdbcComponentID.Name Then
            sWhere = "ComponentID <> '%'"
            If sGroupProductID <> "" Then
                LoadDataSource(tdbc, ReturnTableFilter(dtComponentID, sWhere & " AND (ComponentID ='+' OR  GroupProductID =" & SQLString(sGroupProductID) & ")", True), gbUnicode)
            Else
                LoadDataSource(tdbc, ReturnTableFilter(dtComponentID, sWhere & " AND GroupProductID =" & SQLString(sGroupProductID), True), gbUnicode)
            End If
        Else
            'Load tdbcComponentIDM
            sWhere = "ComponentID <> '+'"
            LoadDataSource(tdbc, ReturnTableFilter(dtComponentID, sWhere & " AND (ComponentID ='%' OR GroupProductID =" & SQLString(sGroupProductID) & ")", True), gbUnicode)
            tdbcComponentIDM.SelectedValue = sComponentID
        End If
    End Sub

#Region "Events tdbcGroupProductIDM"
    Private Sub tdbcGroupProductIDM_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupProductIDM.LostFocus
        If tdbcGroupProductIDM.FindStringExact(tdbcGroupProductIDM.Text) = -1 Then tdbcGroupProductIDM.Text = ""
    End Sub
    Private Sub tdbcGroupProductIDM_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcGroupProductIDM.SelectedValueChanged
        LoadTDBCComponentID(tdbcComponentIDM, ReturnValueC1Combo(tdbcGroupProductIDM), "%")
    End Sub
#End Region

#Region "Events tdbcMethodID"
    Private Sub tdbcMethodID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMethodID.LostFocus
        If tdbcMethodID.FindStringExact(tdbcMethodID.Text) = -1 Then tdbcMethodID.Text = ""
    End Sub
#End Region

#Region "Events tdbcGroupProductID"
    Private Sub tdbcGroupProductID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.LostFocus
        If tdbcGroupProductID.FindStringExact(tdbcGroupProductID.Text) = -1 Then tdbcGroupProductID.Text = ""
    End Sub
    Private Sub tdbcGroupProductID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcGroupProductID.SelectedValueChanged
        LoadTDBCComponentID(tdbcComponentID, ReturnValueC1Combo(tdbcGroupProductID))
    End Sub
#End Region

#Region "Events tdbcComponentIDM"

    Private Sub tdbcComponentIDM_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcComponentIDM.LostFocus
        If tdbcComponentIDM.FindStringExact(tdbcComponentIDM.Text) = -1 Then tdbcComponentIDM.Text = ""
    End Sub

#End Region

#Region "Events tdbcComponentID"
    Private Sub tdbcComponentID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcComponentID.LostFocus
        If tdbcComponentID.FindStringExact(tdbcComponentID.Text) = -1 Then tdbcComponentID.Text = ""
    End Sub

#End Region
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.Close, tdbcGroupProductIDM.Close, tdbcMethodID.Close, tdbcComponentIDM.Close, tdbcComponentID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupProductID.Validated, tdbcGroupProductIDM.Validated, tdbcMethodID.Validated, tdbcComponentIDM.Validated, tdbcComponentID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        '*******************
        Select Case tdbc.Name
            'Case tdbcGroupProductIDM.Name
            '    Dim sGroupProductIDM As String = ReturnValueC1Combo(tdbcGroupProductIDM)
            '    If tdbcGroupProductIDM.Tag Is Nothing OrElse tdbcGroupProductIDM.Tag.ToString <> sGroupProductIDM Then
            '        LoadTDBCComponentID(tdbcComponentIDM, sGroupProductIDM, "%")
            '        tdbcGroupProductIDM.Tag = sGroupProductIDM
            '    End If
            Case tdbcMethodID.Name
                If tdbcMethodID.Text <> "" Then
                    ReadOnlyControl(txtTaskID)
                Else
                    UnReadOnlyControl(True, txtTaskID)
                End If
            Case tdbcGroupProductID.Name
                Dim sGroupProductID As String = ReturnValueC1Combo(tdbcGroupProductID)
                If tdbcGroupProductID.Tag Is Nothing OrElse tdbcGroupProductID.Tag.ToString <> sGroupProductID Then
                    If ReturnValueC1Combo(tdbcGroupProductID) = "+" Then
                        tdbcGroupProductID.SelectedValue = ""
                        If ReturnPermission("D45F1070") < EnumPermission.Add Then
                            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_them_moi"))
                        Else
                            Dim arrPro() As StructureProperties = Nothing
                            SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
                            Dim frm As Form = CallFormShowDialog("D45D0140", "D45F1071", arrPro)
                            Dim sOutput01 As String = GetProperties(frm, "GroupProductID").ToString
                            If sOutput01 <> "" Then 'If L3Bool(GetProperties(frm, "bSaved")) Then
                                LoadTDBCGroupProductID(ReturnValueC1Combo(tdbcGroupProductIDM))
                                tdbcGroupProductID.SelectedValue = sOutput01
                                _bSaved = False 'phải khởi đầu biến này lại, nếu không sau khi thêm thành công, mở mh thêm mới tắt form mà k làm gì ->error
                                sGroupProductID = sOutput01
                            Else
                                sGroupProductID = ""
                            End If
                        End If
                        tdbcGroupProductID.Focus()
                    End If
                    '***********************
                    tdbcGroupProductID.Tag = sGroupProductID
                End If
            Case tdbcComponentID.Name
                Dim sComponentID As String = ReturnValueC1Combo(tdbcComponentID)
                If tdbcComponentID.Tag Is Nothing OrElse tdbcComponentID.Tag.ToString <> sComponentID Then
                    If ReturnValueC1Combo(tdbcComponentID) = "+" Then
                        tdbcComponentID.SelectedValue = ""
                        If ReturnPermission("D45F1095") < EnumPermission.Add Then
                            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_them_moi"))
                        Else
                            Dim f As New D45F1095
                            f.GroupProductID = ReturnValueC1Combo(tdbcGroupProductID)
                            f.FormState = EnumFormState.FormAdd
                            f.ShowDialog()
                            Dim sOutput As String = f.ComponentID
                            If sOutput <> "" Then
                                dtComponentID = Nothing
                                LoadTDBCComponentID(tdbcComponentID, ReturnValueC1Combo(tdbcGroupProductID))
                                tdbcComponentID.SelectedValue = sOutput
                                LoadTDBCComponentID(tdbcComponentIDM, ReturnValueC1Combo(tdbcGroupProductIDM), ReturnValueC1Combo(tdbcComponentIDM))
                                _bSaved = False 'phải khởi đầu biến này lại, nếu không sau khi thêm thành công, mở mh thêm mới tắt form mà k làm gì ->error
                                sComponentID = sOutput
                            Else
                                sComponentID = ""
                            End If
                            f.Dispose()
                        End If
                        tdbcComponentID.Focus()
                    End If
                    tdbcComponentID.Tag = sComponentID
                End If
        End Select
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sTaskID As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If

        Dim sSQL As String = SQLStoreD45P1100()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)

        ReLoadTDBGrid(False)
        If sTaskID <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select(COL_TaskID & "=" & SQLString(sTaskID), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
        If dtGrid.Rows.Count = 0 And tsbAdd.Enabled Then tsbAdd_Click(Nothing, Nothing) : Exit Sub
        LoadEdit()
    End Sub

    Private Sub ReLoadTDBGrid(Optional ByVal bLoadEdit As Boolean = True)
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled =0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
        If _FormState = EnumFormState.FormAdd Then Exit Sub
        ''**************
        If tdbg.RowCount = 0 Then
            ClearText(grpDetail)
            LockControlDetail(True)
        Else
            LockControlDetail(False)
            _FormState = EnumFormState.FormView
            If bLoadEdit Then LoadEdit()
        End If
    End Sub
    Private Sub ResetGrid()
        EnableMenu(False)
        FooterTotalGrid(tdbg, COL_GroupProductID)
    End Sub

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub
    Private Sub LoadDataDefault()
        tdbcGroupProductID.SelectedValue = _groupProductID
        tdbcGroupProductID.Enabled = False
        tdbcComponentID.SelectedValue = _componentID
        tdbcComponentID.Enabled = False
    End Sub
    Private Sub LoadAdd()
        _FormState = EnumFormState.FormAdd
        '********************
        _bSaved = False
        '*******************
        ClearText(grpDetail)
        chkDisabled.Checked = False
        chkDisabled.Visible = False
        LockControlDetail(False)
        '*******************
        If bCallFormAddNew Then
            LoadDataDefault()
            UnReadOnlyControl(True, txtTaskID)
        Else
            UnReadOnlyControl(True, tdbcGroupProductID, tdbcComponentID, txtTaskID)
        End If

        UnReadOnlyControl(False, tdbcMethodID)

        Dim dr() As DataRow = dtMethodID.Select("IsDefault=1")
        If dr.Length > 0 Then tdbcMethodID.SelectedValue = dr(0)("MethodID")

        tdbcMethodID.Focus()
    End Sub

    Private Sub LoadEdit()
        If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then Exit Sub 'Chưa đổ nguồn cho lưới
        tdbg.Columns(COL_TaskID).Tag = tdbg(tdbg.Row, COL_TaskID).ToString
        '************************
        'Gán dữ liệu
        tdbcMethodID.SelectedValue = tdbg.Columns(COL_IGEMethodID).Text
        tdbcGroupProductID.SelectedValue = tdbg.Columns(COL_GroupProductID).Text
        tdbcComponentID.SelectedValue = tdbg.Columns(COL_ComponentID).Text
        txtTaskID.Text = tdbg.Columns(COL_TaskID).Text
        txtTaskName.Text = tdbg.Columns(COL_TaskName).Text
        txtNotes.Text = tdbg.Columns(COL_Notes).Text
        chkDisabled.Checked = L3Bool(tdbg.Columns(COL_Disabled).Text)
        chkDisabled.Visible = True
        '************************
        ReadOnlyControl(tdbcMethodID, tdbcGroupProductID, tdbcComponentID, txtTaskID)
    End Sub

    Private Sub EnableMenu(ByVal bEnabled As Boolean)
        'If dtGrid Is Nothing Then Exit Sub
        btnSave.Enabled = bEnabled
        btnNotSave.Enabled = bEnabled
        btnNext.Enabled = bEnabled
        chkShowDisabled.Enabled = Not bEnabled
        tdbg.Enabled = Not bEnabled
        grpFilter.Enabled = Not bEnabled

        If _FormState = EnumFormState.FormAdd Then
            btnNext.Visible = True
            btnNext.Text = rL3("Luu_va_Nhap__tiep")
        Else
            btnNext.Visible = False
        End If
        If btnNext.Visible And btnNext.Enabled Then
            btnSave.Left = btnNext.Left - btnSave.Width - 6
        Else
            btnSave.Left = btnNext.Left + (btnNext.Width - btnSave.Width)
        End If

        If bEnabled Then
            CheckMenu("-1", ToolStrip1, -1, False, False, ContextMenuStrip1)
        Else
            CheckMenu(_formIDPermission, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        End If
    End Sub

    Private Sub LockControlDetail(ByVal bLock As Boolean)
        grpDetail.Enabled = Not bLock
    End Sub

#Region "Menu"
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, mnsAdd.Click
        _FormState = EnumFormState.FormAdd
        EnableMenu(True)
        LoadAdd()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, mnsEdit.Click
        If CheckStore(SQLStoreD45P5555("Kiem tra truoc khi sua", 2)) = False Then Exit Sub

        _FormState = EnumFormState.FormEdit
        EnableMenu(True)
        ReadOnlyControl(tdbcMethodID, tdbcGroupProductID, tdbcComponentID, txtTaskID)
        _bSaved = False
        chkDisabled.Focus()
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, mnsDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub
        If CheckStore(SQLStoreD45P5555("Kiem tra truoc khi xoa", 1)) = False Then Exit Sub

        Dim sSQL As String = SQLDeleteD45T1100()
        Dim bResult As Boolean = ExecuteSQL(sSQL)
        If bResult Then
            DeleteOK()
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            If dtGrid.Rows.Count = 0 Then
                ResetGrid()
                tsbAdd_Click(Nothing, Nothing)
            Else
                ReLoadTDBGrid()
            End If
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub
#End Region

#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then 'Incident 72333
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

#Region "tdbg"
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Dim iHeight As Integer = 0 ' Lấy tọa độ Y của chuột click tới
    Private Sub tdbg_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseClick
        iHeight = e.Location.Y
    End Sub
    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If iHeight <= tdbg.Splits(0).ColumnCaptionHeight Then Exit Sub
        If tdbg.RowCount <= 0 OrElse tdbg.FilterActive Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If tsbEdit.Enabled Then tsbEdit_Click(sender, Nothing)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()

        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
    Private Sub tdbg_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdbg.AfterSort
        LoadEdit()
    End Sub
    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        'Neu o thanh Filter thi k kiem tra va chay su kien RowColChange
        If tdbg.FilterActive OrElse tdbg.RowCount < 0 Then Exit Sub

        If tdbg.Columns(COL_TaskID).Tag Is Nothing OrElse tdbg.Columns(COL_TaskID).Tag.ToString <> tdbg(tdbg.Row, COL_TaskID).ToString Then
            LoadEdit()
        End If
    End Sub
    Private Sub tdbg_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg.UnboundColumnFetch
        Select Case e.Col
            Case COL_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub

#End Region

    Private Function SaveData(ByVal sender As System.Object) As Boolean
        _bSaved = False
        If Not AllowSave() Then Return False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD45T1100.ToString)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1100.ToString)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            _taskID = txtTaskID.Text

            If bCallFormAddNew = False Then 'Chỉ làm khi lưới hiển thị
                Select Case _FormState
                    Case EnumFormState.FormAdd
                        LoadTDBGrid(True, txtTaskID.Text)
                    Case EnumFormState.FormEdit
                        LoadTDBGrid(, txtTaskID.Text)
                End Select
                ReadOnlyControl(tdbcMethodID, tdbcGroupProductID, tdbcComponentID, txtTaskID)
                SetReturnFormView()
            Else
                Select Case _FormState
                    Case EnumFormState.FormAdd
                        btnSave.Enabled = False
                        If sender IsNot Nothing Then btnNext.Text = rL3("Nhap__tiep")
                        btnNext.Enabled = True
                        btnNext.Focus()
                End Select
            End If
        Else
            SaveNotOK()
            Return False
        End If
        Return True
    End Function

    Private Sub SetReturnFormView()
        _FormState = EnumFormState.FormView
        EnableMenu(False)
        If tdbg.RowCount = 0 Then
            ClearText(grpDetail)
        Else
            LoadEdit()
            tdbg.Focus()
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub

        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        SaveData(sender)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If bCallFormAddNew Then
            If btnNext.Text = rL3("Luu_va_Nhap__tiep") Then
                btnSave_Click(sender, e)
                If _bSaved = False Then Exit Sub
            End If

            btnNext.Text = rL3("Luu_va_Nhap__tiep")
            _FormState = EnumFormState.FormAdd

            btnSave.Enabled = True
            tsbAdd_Click(Nothing, Nothing)
        Else
            If AskSave() = Windows.Forms.DialogResult.No Then
                SetReturnFormView()
                Exit Sub
            End If
            If SaveData(sender) Then tsbAdd_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub btnNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotSave.Click
        If _FormState = EnumFormState.FormAdd AndAlso tdbcGroupProductID.Text = "" Then
            If tdbg.RowCount > 0 Then LoadEdit()
            GoTo 1
        End If

        If AskMsgBeforeRowChange() Then
            If Not SaveData(sender) Then Exit Sub
        Else
            LoadEdit()
        End If
1:
        SetReturnFormView()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        If AllowSave(True) = False Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        LoadTDBGrid(True)
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowSave(Optional bFilter As Boolean = False) As Boolean
        If bFilter Then
            If tdbcGroupProductIDM.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblGroupProductIDM.Text)
                tdbcGroupProductIDM.Focus()
                Return False
            End If
            If tdbcComponentIDM.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblComponentIDM.Text)
                tdbcGroupProductIDM.Focus()
                Return False
            End If
        Else
            If tdbcGroupProductID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblGroupProductID.Text)
                tdbcGroupProductID.Focus()
                Return False
            End If
            If tdbcComponentID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblComponentID.Text)
                tdbcComponentID.Focus()
                Return False
            End If
            If _FormState = EnumFormState.FormAdd AndAlso tdbcMethodID.Text.Trim <> "" Then  'Sinh mã tự động cho mã nhóm tiểu tác 
                Dim sSQL As String = ""
                sSQL = SQLDeleteD09T6666() & vbCrLf
                sSQL &= SQLInsertD09T6666.ToString() & vbCrLf
                sSQL &= SQLStoreD09P2016() & vbCrLf
                Dim dt As DataTable = Nothing
                If CheckStore(sSQL, "", dt) Then
                    If dt.Rows.Count > 0 Then txtTaskID.Text = dt.Rows(0).Item(COL_TaskID).ToString
                Else
                    Return False
                End If
            End If
            '******************************
            If txtTaskID.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(lblTaskID.Text)
                txtTaskID.Focus()
                Return False
            End If
            If txtTaskName.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(lblTaskName.Text)
                txtTaskName.Focus()
                Return False
            End If

            If _FormState = EnumFormState.FormAdd Then
                If IsExistKey("D45T1100", "TaskID", txtTaskID.Text) Then
                    D99C0008.MsgDuplicatePKey()
                    txtTaskID.Focus()
                    Return False
                End If
            End If

        End If

        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/02/2017 10:11:28
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P5555(sComment As String, iMode As Byte) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "Exec D45P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TaskID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) 'Num01, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/02/2017 10:14:48
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam D09T6666" & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        sSQL &= "FormID = " & SQLString(Me.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/02/2017 10:16:05
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Insert du lieu vao bang tam" & vbCrLf)
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, Str01, Str02, Num01, FormID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcGroupProductID)) & COMMA) 'Str01, nvarchar[500], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcComponentID)) & COMMA) 'Str02, nvarchar[500], NOT NULL
        sSQL.Append(SQLMoney(1) & COMMA) 'Num01, decimal, NOT NULL
        sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P2016
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/02/2017 10:21:50
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P2016() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Sinh ma tu dong" & vbCrLf)
        sSQL &= "Exec D09P2016 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcMethodID)) & COMMA 'MethodID, varchar[50], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber("45") & COMMA 'ModuleID, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1100
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 08/02/2017 05:05:39
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1100() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi" & vbCrlf)
        sSQL &= "Exec D45P1100 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcComponentIDM)) & COMMA 'ComponentID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcGroupProductIDM)) & COMMA 'GroupProductID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1100
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 08/02/2017 05:12:57
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1100() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Them moi du lieu" & vbCrlf)
        sSQL.Append("Insert Into D45T1100(")
        sSQL.Append("GroupProductID, ComponentID, TaskID, TaskNameU, NotesU, " & vbCrlf)
        sSQL.Append("Disabled, IGEMethodID, CreateUserID, LastModifyUserID, CreateDate, " & vbCrlf)
        sSQL.Append("LastModifyDate")
        sSQL.Append(") Values(" & vbCrlf)
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcGroupProductID)) & COMMA) 'GroupProductID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcComponentID)) & COMMA) 'ComponentID, varchar[50], NOT NULL
        sSQL.Append(SQLString(txtTaskID.Text) & COMMA) 'TaskID [KEY], varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTaskName, True) & COMMA) 'TaskNameU, nvarchar[1000], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNotes, True) & COMMA & vbCrLf) 'NotesU, nvarchar[2000], NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcMethodID)) & COMMA) 'IGEMethodID, varchar[50], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[50], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA & vbCrlf) 'LastModifyUserID, varchar[50], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T1100
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 08/02/2017 05:14:02
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T1100() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("-- Cap nhat du lieu" & vbCrlf)
        sSQL.Append("Update D45T1100 Set ")
        sSQL.Append("TaskNameU = " & SQLStringUnicode(txtTaskName, True) & COMMA) 'nvarchar[1000], NOT NULL
        sSQL.Append("NotesU = " & SQLStringUnicode(txtNotes, True) & COMMA) 'nvarchar[2000], NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NOT NULL
        sSQL.Append(" Where TaskID =" & SQLString(txtTaskID.Text))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T1100
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 08/02/2017 05:14:59
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T1100() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu" & vbCrlf)
        sSQL &= "Delete From D45T1100"
        sSQL &= " Where "
        sSQL &= "TaskID = " & SQLString(tdbg.Columns(COL_TaskID).Text)
        Return sSQL
    End Function



    
End Class