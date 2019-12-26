Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 21/05/2007 2:34:35 PM
'# Created User: Nguyễn Lê Phương
'# Modify Date: 21/05/2007 2:34:35 PM
'# Modify User: Nguyễn Lê Phương
'#-------------------------------------------------------------------------------------
Public Class D45F1001
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Private dtGrid As DataTable
    Dim iBookmark As Integer
    'Dim bFlagShiftInsert As Boolean = False

#Region "Const of tdbg"
    Private Const COL_StageID As Integer = 0   ' Mã công đoạn
    Private Const COL_StageName As Integer = 1 ' Diễn giải
    Private Const COL_OrderNo As Integer = 2   ' Thứ tự hiển thị
    Private Const CountCol As Integer = 3
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()

            LoadCaptionDefault()
            LoadTDBComboAnaCaption(lblM01ID, lblM02ID, lblM03ID, lblM04ID, lblM05ID, tdbcS01ID, tdbcS02ID, tdbcS03ID, tdbcS04ID, tdbcS05ID, gbUnicode)
            LoadTDBCombo()
            LoadTDBDropDown()

            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = False
                    chkDisabled.Visible = False
                    c1dateTransactionDate.Value = Now
                    txtDisplayOrder.Text = "0"
                    tdbcStatusID.SelectedIndex = 0
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _ProductID As String = ""
    Public Property ProductID() As String
        Get
            Return _ProductID
        End Get
        Set(ByVal Value As String)
            If _ProductID = Value Then
                _ProductID = ""
                Return
            End If
            _ProductID = Value
        End Set
    End Property

    Private _displayOrder As String = "0"
    Public Property DisplayOrder() As string
        Get
            Return _displayOrder
        End Get
        Set(ByVal Value As string)
            _displayOrder = Value
        End Set
    End Property

#Region "Events tdbcUnitID"

    Private Sub tdbcUnitID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcUnitID.Close
        If tdbcUnitID.FindStringExact(tdbcUnitID.Text) = -1 Then tdbcUnitID.Text = ""
        If tdbcUnitID.Text = "+" Then
            'Kiem tra quyen form cha
            If ReturnPermission("D45F5601") > 1 Then
                Dim sKeyID As String
                'Dim frm As New D07F1211
                'With frm
                '    .FormName = "D07F0012"
                '    .FormPermission = "D45F5601" 'Màn hình phân quyền
                '    .ShowDialog()
                '    sKeyID = .Output01 'Giá trị trả về UnitID
                '    .Dispose()
                'End With
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D45F5601")
                Dim frm As Form = CallFormShowDialog("D07D1240", "D07F0012", arrPro)
                If L3Bool(GetProperties(frm, "bSaved")) Then
                    sKeyID = L3String(GetProperties(frm, "UnitID"))
                    Dim sSQL As String = ""
                    sSQL = "Select '+' As UnitID, " & NewName & " As UnitName" & vbCrLf
                    sSQL &= "Union" & vbCrLf
                    sSQL &= "Select UnitID, UnitName" & UnicodeJoin(gbUnicode) & " as UnitName From D07T0005 WITH(NOLOCK) " & vbCrLf
                    sSQL &= "Where Disabled=0 Order by UnitID"
                    LoadDataSource(tdbcUnitID, sSQL, gbUnicode)
                    tdbcUnitID.Text = sKeyID
                End If
                'If sKeyID <> "" Then
                '    'Load lại dữ liệu cho tdbcUnitID
                '    Dim sSQL As String = ""
                '    sSQL = "Select '+' As UnitID, " & NewName & " As UnitName" & vbCrLf
                '    sSQL &= "Union" & vbCrLf
                '    sSQL &= "Select UnitID, UnitName" & UnicodeJoin(gbUnicode) & " as UnitName From D07T0005 WITH(NOLOCK) " & vbCrLf
                '    sSQL &= "Where Disabled=0 Order by UnitID"
                '    LoadDataSource(tdbcUnitID, sSQL, gbUnicode)
                '    tdbcUnitID.Text = sKeyID
                'End If
            Else
                tdbcUnitID.Text = ""
                D99C0008.MsgL3(rl3("Ban_khong_co_quyen_them_moi"))
                tdbcUnitID.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub tdbcUnitID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcUnitID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcUnitID.Text = ""
        If tdbcUnitID.Text = "+" And e.KeyCode = Keys.Enter Then
            'Kiem tra quyen form cha
            If ReturnPermission("D45F5601") > 1 Then
                Dim sKeyID As String
                'Dim frm As New D07F1211
                'With frm
                '    .FormName = "D07F0012"
                '    .FormPermission = "D45F5601" 'Màn hình phân quyền
                '    .ShowDialog()
                '    sKeyID = .Output01 'Giá trị trả về
                '    .Dispose()
                'End With
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D45F5601")
                Dim frm As Form = CallFormShowDialog("D07D1240", "D07F0012", arrPro)
                If L3Bool(GetProperties(frm, "bSaved")) Then
                    sKeyID = L3String(GetProperties(frm, "UnitID"))
                    Dim sSQL As String = ""
                    sSQL = "Select '+' As UnitID, " & NewName & " As UnitName" & vbCrLf
                    sSQL &= "Union" & vbCrLf
                    sSQL &= "Select UnitID, UnitName" & UnicodeJoin(gbUnicode) & " as UnitName From D07T0005 WITH(NOLOCK) " & vbCrLf
                    sSQL &= "Where Disabled=0 Order by UnitID"
                    LoadDataSource(tdbcUnitID, sSQL, gbUnicode)
                    tdbcUnitID.Text = sKeyID
                End If
                'If sKeyID <> "" Then
                '    'Load lại dữ liệu cho tdbcUnitID
                '    Dim sSQL As String = ""
                '    sSQL = "Select '+' As UnitID, " & NewName & " As UnitName" & vbCrLf
                '    sSQL &= "Union" & vbCrLf
                '    sSQL &= "Select UnitID, UnitName" & UnicodeJoin(gbUnicode) & " as UnitName From D07T0005  WITH(NOLOCK) " & vbCrLf
                '    sSQL &= "Where Disabled=0 Order by UnitID"
                '    LoadDataSource(tdbcUnitID, sSQL, gbUnicode)
                '    tdbcUnitID.Text = sKeyID
                'End If
            Else
                tdbcUnitID.Text = ""
                D99C0008.MsgL3(rl3("Ban_khong_co_quyen_them_moi"))
                tdbcUnitID.Focus()
                Exit Sub
            End If
        End If
    End Sub

#End Region

    Private Sub D45F1001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If

        Dim i As Integer = 0
        If e.Alt Then

            LockTab(tabMain, False)
            If e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1 Then
                Application.DoEvents()
                tabMain.SelectedTab = TabStageID
                Application.DoEvents()
                i = 1
            End If

            If e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2 Then
                Application.DoEvents()
                tabMain.SelectedTab = TabAna
                Application.DoEvents()
                i = 2
            End If

            LockTab(tabMain, True)

            If i = 1 Then
                tdbcSRoutingID.Focus()
            Else
                'TabAna_Focus()
                tabMain.Focus()
                tabMain.SelectedTab = TabAna
            End If
        End If

    End Sub

    Private Sub D45F1001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        Loadlanguage()
        LoadTDBGrid()
        tdbg_NumberFormat()
        tdbg_LockedColumns()
        SetBackColorObligatory()
        ExecuteSQL(SQLDeleteD91T9009)
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtProductID, 50)
        '**************************
        'An tab Cong doan
        tabMain.TabPages.RemoveAt(0)
        '**************************
        InputDateCustomFormat(c1dateTransactionDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_san_pham_-_D45F1001") & UnicodeCaption(gbUnicode) 'CËp nhËt s¶n phÈm - D45F1001
        '================================================================ 
        lblteTransactionDate.Text = rl3("Ngay_phat_sinh") 'Ngày phát sinh
        lblProductID.Text = rl3("Ma_san_pham") 'Mã sản phẩm
        lblProductName.Text = rl3("Ten_san_pham") 'Tên sản phẩm
        lblShortName.Text = rl3("Ten_tat") 'Tên tắt
        lblUnitID.Text = rl3("DVT") 'ĐVT
        lblNote.Text = rl3("Ghi_chu") 'Ghi chú
        lblSRoutingID.Text = rl3("Quy_trinh_sx_chuan") 'Quy trình sx chuẩn
        lblDisplayOrder.Text = rl3("Thu_tu_hien_thi") 'Thứ tự hiển thị
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        TabStageID.Text = "1." & Space(1) & rl3("Cong_doan") 'Công đoạn
        'TabAna.Text = "2." & Space(1) & rl3("Ma_phan_tich") 'Mã phân tích
        TabAna.Text = rl3("Ma_phan_tich") 'Mã phân tích
        '================================================================ 
        tdbcSRoutingID.Columns("SRoutingID").Caption = rl3("Ma") 'Mã
        tdbcSRoutingID.Columns("SRoutingName").Caption = rl3("Ten") 'Tên
        tdbcUnitID.Columns("UnitID").Caption = rl3("Ma") 'Mã
        tdbcUnitID.Columns("UnitName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcS01ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcS01ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcS02ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcS02ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcS03ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcS03ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcS04ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcS04ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcS05ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcS05ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdStageID.Columns("StageID").Caption = rl3("Ma") 'Mã 
        tdbdStageID.Columns("StageName").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg.Columns("StageID").Caption = rl3("Ma_cong_doan") 'Mã công đoạn
        tdbg.Columns("StageName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("OrderNo").Caption = rL3("Thu_tu_hien_thi") 'Thứ tự hiển thị

        '================================================================ 
        lblCustomerID.Text = rL3("Khach_hang") 'Khách hàng
        lblStatusID.Text = rL3("Trang_thai") 'Trạng thái
        lblProductionBatch.Text = rL3("Lenh_san_xuat")
        '================================================================ 
        tdbcCustomerID.Columns("CustomerID").Caption = rL3("Ma") 'Mã
        tdbcCustomerID.Columns("CustomerName").Caption = rL3("Ten") 'Tên
        tdbcStatusID.Columns("StatusID").Caption = rL3("Ma") 'Mã
        tdbcStatusID.Columns("StatusName").Caption = rL3("Ten") 'Tên

    End Sub

    'gan caption mac dinh cho 5 mã pt
    Private Sub LoadCaptionDefault()
        lblM01ID.Text = rl3("Ma_pt_SP") & Space(1) & "1" 'Mã pt SP 1
        lblM02ID.Text = rl3("Ma_pt_SP") & Space(1) & "2" 'Mã pt SP 2
        lblM03ID.Text = rl3("Ma_pt_SP") & Space(1) & "3" 'Mã pt SP 3
        lblM04ID.Text = rl3("Ma_pt_SP") & Space(1) & "4" 'Mã pt SP 4
        lblM05ID.Text = rl3("Ma_pt_SP") & Space(1) & "5" 'Mã pt SP 5
    End Sub

    Private Sub LoadTDBCombo()

        Dim sSQL As String = ""
        'Load tdbcUnitID
        sSQL = "Select '+' As UnitID, " & NewName & " As UnitName" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select UnitID, UnitName" & UnicodeJoin(gbUnicode) & " as UnitName From D07T0005  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 Order by UnitID"
        LoadDataSource(tdbcUnitID, sSQL, gbUnicode)

        'Load SRoutingID
        sSQL = "Select SRoutingID, SRoutingName" & UnicodeJoin(gbUnicode) & " as SRoutingName From D45T1030  WITH(NOLOCK) Where Disabled=0 Order by SRoutingID"
        LoadDataSource(tdbcSRoutingID, sSQL, gbUnicode)

        'Load 5 mã pt
        LoadTDComboAna(tdbcS01ID, tdbcS02ID, tdbcS03ID, tdbcS04ID, tdbcS05ID, gbUnicode)

        'Load tdbcStatusID
        sSQL = " -- Do nguon Combo Trang thai" & vbCrLf
        sSQL &= " SELECT '0001' AS StatusID, CASE WHEN " & SQLString(gsLanguage) & "='84' "
        sSQL &= " then  N'Chưa hoàn thành' ELSE 'Non-Complete' END AS StatusName "
        sSQL &= " UNION ALL"
        sSQL &= " SELECT '0002' AS StatusID, CASE WHEN " & SQLString(gsLanguage) & "='84' "
        sSQL &= " then  N'Đã hoàn thành' ELSE 'Complete'END AS StatusName "
        LoadDataSource(tdbcStatusID, sSQL, gbUnicode)

        'Load tdbcCustomerID
        LoadDataSource(tdbcCustomerID, SQLStoreD45P1002, gbUnicode)
    End Sub


#Region "Events tdbcSRoutingID with txtSRoutingName"

    Private Sub tdbcSRoutingID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSRoutingID.Close
        If tdbcSRoutingID.FindStringExact(tdbcSRoutingID.Text) = -1 Then
            tdbcSRoutingID.Text = ""
            txtSRoutingName.Text = ""
        End If
    End Sub

    Private Sub tdbcSRoutingID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcSRoutingID.SelectedValueChanged
        txtSRoutingName.Text = tdbcSRoutingID.Columns(1).Value.ToString
        LoadTDBGrid_SRoutingID()
    End Sub

    Private Sub tdbcSRoutingID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSRoutingID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcSRoutingID.Text = ""
            txtSRoutingName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcS01ID"

    Private Sub tdbcS01ID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcS01ID.Close
        ShowD91F1302(tdbcS01ID, "M01", lblM01ID.Tag.ToString)
    End Sub

    Private Sub tdbcS01ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcS01ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            ShowD91F1302(tdbcS01ID, "M01", lblM01ID.Tag.ToString)
        End If
    End Sub

    Private Sub tdbcS01ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcS01ID.LostFocus
        If tdbcS01ID.FindStringExact(tdbcS01ID.Text) = -1 Then
            tdbcS01ID.Text = ""
        Else
            ShowD91F1302(tdbcS01ID, "M01", lblM01ID.Tag.ToString)
        End If

    End Sub
#End Region

#Region "Events tdbcS02ID"

    Private Sub tdbcS02ID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcS02ID.Close
        ShowD91F1302(tdbcS02ID, "M02", lblM02ID.Tag.ToString)
    End Sub

    Private Sub tdbcS02ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcS02ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            ShowD91F1302(tdbcS02ID, "M02", lblM02ID.Tag.ToString)
        End If
    End Sub

    Private Sub tdbcS02ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcS02ID.LostFocus
        If tdbcS02ID.FindStringExact(tdbcS02ID.Text) = -1 Then
            tdbcS02ID.Text = ""
        Else
            ShowD91F1302(tdbcS02ID, "M02", lblM02ID.Tag.ToString)
        End If
    End Sub

#End Region

#Region "Events tdbcS03ID"

    Private Sub tdbcS03ID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcS03ID.Close
        ShowD91F1302(tdbcS03ID, "M03", lblM03ID.Tag.ToString)
    End Sub

    Private Sub tdbcS03ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcS03ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            ShowD91F1302(tdbcS03ID, "M03", lblM03ID.Tag.ToString)
        End If
    End Sub

    Private Sub tdbcS03ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcS03ID.LostFocus
        If tdbcS03ID.FindStringExact(tdbcS03ID.Text) = -1 Then
            tdbcS03ID.Text = ""
        Else
            ShowD91F1302(tdbcS03ID, "M03", lblM03ID.Tag.ToString)
        End If

    End Sub

#End Region

#Region "Events tdbcS04ID"

    Private Sub tdbcS04ID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcS04ID.Close
        ShowD91F1302(tdbcS04ID, "M04", lblM04ID.Tag.ToString)
    End Sub

    Private Sub tdbcS04ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcS04ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            ShowD91F1302(tdbcS04ID, "M04", lblM04ID.Tag.ToString)
        End If
    End Sub

    Private Sub tdbcS04ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcS04ID.LostFocus
        If tdbcS04ID.FindStringExact(tdbcS04ID.Text) = -1 Then
            tdbcS04ID.Text = ""
        Else
            ShowD91F1302(tdbcS04ID, "M04", lblM04ID.Tag.ToString)
        End If

    End Sub
#End Region

#Region "Events tdbcS05ID"

    Private Sub tdbcS05ID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcS05ID.Close
        ShowD91F1302(tdbcS05ID, "M05", lblM05ID.Tag.ToString)
    End Sub

    Private Sub tdbcS05ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcS05ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            ShowD91F1302(tdbcS05ID, "M05", lblM05ID.Tag.ToString)
        End If
    End Sub


    Private Sub tdbcS05ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcS05ID.LostFocus
        If tdbcS05ID.FindStringExact(tdbcS05ID.Text) = -1 Then
            tdbcS05ID.Text = ""
        Else
            ShowD91F1302(tdbcS05ID, "M05", lblM05ID.Tag.ToString)
        End If
    End Sub
#End Region

    Private Sub ShowD91F1302(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sKeyID01 As String, ByVal sKeyID02 As String)
        If tdbc.Text = "+" Then
            tdbc.Text = ""

            'Dim sKeyID As String
            'Dim frm As New D91F1301
            'With frm
            '    .FormName = "D91F1302"
            '    .KeyID01 = sKeyID01 'Mã loại phân tích
            '    .KeyID02 = sKeyID02 'Tên loại phân tích
            '    .ShowDialog()
            '    sKeyID = .Output01 'Giá trị trả về AnaID
            '    .Dispose()
            'End With
            'If sKeyID <> "" Then
            '    'Load lại dữ liệu cho Combo hay Dropdown của Mã phân tích
            '    LoadTDComboAna(tdbc)
            '    tdbc.Text = sKeyID
            '    If tdbc.FindStringExact(sKeyID) = -1 Then tdbc.Text = ""
            'End If
            'If iPerD91F1301 <= 0 Then
            '    D99C0008.MsgL3(rL3("Ban_khong_co_quyen_them_moi"))
            '    Exit Sub
            'End If
            Dim arrPro() As StructureProperties = Nothing
            SetProperties(arrPro, "FormIDPermission", "D91F1301")
            SetProperties(arrPro, "AnaCategatoryID", sKeyID01)
            SetProperties(arrPro, "AnaCategatoryName", sKeyID02)
            SetProperties(arrPro, "FormState", 0)
            Dim frm As Form = CallFormShowDialog("D91D0540", "D91F1302", arrPro)
            Dim sKey As Object = GetProperties(frm, "AnaID")
            If sKey Is Nothing Then Exit Sub
            If sKey.ToString <> "" Then
                LoadTDComboAna(tdbc)
                tdbc.SelectedValue = sKey
                If tdbc.FindStringExact(sKey.ToString) = -1 Then tdbc.Text = ""
            End If


        End If
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdStageID
        sSQL = "Select StageID, StageName" & UnicodeJoin(gbUnicode) & " as StageName From D45T1010  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 Order by StageID"
        LoadDataSource(tdbdStageID, sSQL, gbUnicode)
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StageName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadEdit()
        txtProductID.ReadOnly = True
        txtProductID.Enabled = False
        LoadMaster()
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String
        sSQL = "Select D00.TransactionDate, D00.ProductID, D00.ProductName" & UnicodeJoin(gbUnicode) & " as ProductName," & vbCrLf
        sSQL &= "D00.ShortName" & UnicodeJoin(gbUnicode) & " as ShortName, D00.UnitID, D00.Note" & UnicodeJoin(gbUnicode) & " as Note, D00.Disabled," & vbCrLf
        sSQL &= "D00.M01ID, D00.M02ID, D00.M03ID, D00.M04ID, D00.M05ID, D00.DisplayOrder, CustomerID, StatusID, ProductionBatchU as ProductionBatch " & vbCrLf
        sSQL &= "From D45T1000 D00  WITH(NOLOCK) Left Join D07T0005 D05  WITH(NOLOCK) On D00.UnitID=D05.UnitID" & vbCrLf
        sSQL &= "Where ProductID = " & SQLString(ProductID)

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            c1dateTransactionDate.Value = SQLDateShow(dt.Rows(0).Item("TransactionDate").ToString)
            txtProductID.Text = dt.Rows(0).Item("ProductID").ToString
            txtProductName.Text = dt.Rows(0).Item("ProductName").ToString
            chkDisabled.Checked = Convert.ToBoolean(dt.Rows(0).Item("Disabled"))
            txtShortName.Text = dt.Rows(0).Item("ShortName").ToString
            tdbcUnitID.Text = dt.Rows(0).Item("UnitID").ToString
            txtNote.Text = dt.Rows(0).Item("Note").ToString
            txtDisplayOrder.Text = dt.Rows(0).Item("DisplayOrder").ToString

            tdbcS01ID.Text = dt.Rows(0).Item("M01ID").ToString
            tdbcS02ID.Text = dt.Rows(0).Item("M02ID").ToString
            tdbcS03ID.Text = dt.Rows(0).Item("M03ID").ToString
            tdbcS04ID.Text = dt.Rows(0).Item("M04ID").ToString
            tdbcS05ID.Text = dt.Rows(0).Item("M05ID").ToString

            tdbcCustomerID.SelectedValue = dt.Rows(0).Item("CustomerID").ToString
            tdbcStatusID.SelectedValue = dt.Rows(0).Item("StatusID").ToString
            txtProductionBatch.Text = dt.Rows(0).Item("ProductionBatch").ToString
        End If
    End Sub

    'Thay CreateGrid() và LoadDetail() thành LoadTDBGrid() 17/01/2008
    Private Sub CreateGrid()
        Dim sSQL As String

        sSQL = "Select D01.StageID,StageName" & UnicodeJoin(gbUnicode) & " as StageName,OrderNo,ProductID" & vbCrLf
        sSQL &= "From D45T1001 D01  WITH(NOLOCK) Inner Join D45T1010 D10  WITH(NOLOCK) On D01.StageID=D10.StageID" & vbCrLf
        sSQL &= "Order By OrderNo"
        dtGrid = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadDetail()
        LoadDataSource(tdbg, ReturnTableFilter(dtGrid, "ProductID=" & SQLString(_ProductID)), gbUnicode)
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String
        sSQL = "Select D01.StageID,StageName" & UnicodeJoin(gbUnicode) & " as StageName,OrderNo,ProductID" & vbCrLf
        sSQL &= "From D45T1001 D01  WITH(NOLOCK) Inner Join D45T1010 D10  WITH(NOLOCK) On D01.StageID=D10.StageID" & vbCrLf
        sSQL &= "Where ProductID=" & SQLString(_ProductID) & vbCrLf
        sSQL &= "Order By OrderNo"
        LoadDataSource(tdbg, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBGrid_SRoutingID()
        Dim sSQL As String
        sSQL = "Select D31.StageID,D10.StageName" & UnicodeJoin(gbUnicode) & " as StageName,D31.OrderNo" & vbCrLf
        sSQL &= "From D45T1031 D31  WITH(NOLOCK) Inner Join D45T1010 D10  WITH(NOLOCK) On D31.StageID=D10.StageID" & vbCrLf
        sSQL &= "Where D31.SRoutingID=" & SQLString(tdbcSRoutingID.Text) & vbCrLf
        sSQL &= "Order By D31.OrderNo"
        LoadDataSource(tdbg, sSQL, gbUnicode)
    End Sub

    Private Sub SetBackColorObligatory()
        txtProductID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtProductName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtShortName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtDisplayOrder.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_OrderNo).NumberFormat = DxxFormat.DefaultNumber0
    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        _ProductID = txtProductID.Text
        If D45Options.SaveLastRecent = False Then
            txtProductID.Text = ""
            txtProductName.Text = ""
            txtNote.Text = ""
            c1dateTransactionDate.Value = Now.Date
            txtShortName.Text = ""
            tdbcUnitID.Text = ""
            tdbcCustomerID.Text = ""
            'tdbcStatusID.Text = ""
            tdbcStatusID.SelectedIndex = 0
            txtProductionBatch.Text = ""
            chkDisabled.Visible = False
            tdbcS01ID.SelectedValue = ""
            tdbcS02ID.SelectedValue = ""
            tdbcS03ID.SelectedValue = ""
            tdbcS04ID.SelectedValue = ""
            tdbcS05ID.SelectedValue = ""
            'tabMain.SelectedTab = TabStageID
            LoadTDBGrid()
        End If

        btnSave.Enabled = True
        btnNext.Enabled = False
        txtProductID.Focus()
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_OrderNo
                iBookmark = tdbg.Bookmark
                If ExitsOrder(tdbg(iBookmark, COL_OrderNo).ToString, iBookmark) Then
                    D99C0008.MsgDuplicatePKey()
                    tdbg.Columns("OrderNo").Text = ""
                    tdbg.Col = COL_OrderNo
                    tdbg.Focus()
                End If
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_StageID
                If tdbg.Columns(COL_StageID).Text <> tdbdStageID.Columns("StageID").Text Then
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_StageID
                If Exits(tdbg.Columns("StageID").Text, tdbg.Bookmark) Then
                    D99C0008.MsgDuplicatePKey()
                    tdbg.Columns("StageID").Text = ""
                    tdbg.Col = COL_StageID
                    tdbg.Focus()
                Else
                    If tdbg.Columns(COL_OrderNo).Text = "" Then
                        If tdbg.Bookmark > 0 Then
                            tdbg.Columns(COL_OrderNo).Text = (Number(tdbg(tdbg.Bookmark - 1, COL_OrderNo).ToString) + 1).ToString
                        ElseIf tdbg.Bookmark = 0 Then
                            tdbg.Columns(COL_OrderNo).Text = "1"
                        End If
                    End If
                    tdbg.Columns(COL_StageID).Text = tdbdStageID.Columns("StageID").Text
                    tdbg.Columns(COL_StageName).Text = tdbdStageID.Columns("StageName").Text
                    tdbg.Col = COL_OrderNo
                End If

        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
            Exit Sub
        ElseIf e.Shift And e.KeyCode = Keys.Insert Then
            HotKeyShiftInsert(tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter And tdbg.Col = COL_OrderNo Then
            HotKeyEnterGrid(tdbg, COL_StageID, e)
            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_StageID, 0)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Col = COL_OrderNo Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    Private Function Exits(ByVal ref As String, ByVal nRow As Int32) As Boolean
        For i As Integer = 0 To tdbg.RowCount - 1
            If i <> nRow And tdbg.Item(i, COL_StageID).ToString = ref Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function ExitsOrder(ByVal ref As String, ByVal nRow As Int32) As Boolean
        For i As Integer = 0 To tdbg.RowCount - 1

            If i <> nRow And tdbg.Item(i, COL_OrderNo).ToString = ref Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If txtProductID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_san_pham"))
            txtProductID.Focus()
            Return False
        End If
        If txtProductName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_san_pham"))
            txtProductName.Focus()
            Return False
        End If
        If txtShortName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_tat"))
            txtShortName.Focus()
            Return False
        End If

        If txtDisplayOrder.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Thu_tu_hien_thi"))
            txtDisplayOrder.Focus()
            Return False
        End If
      
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D45T1000", "ProductID", txtProductID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtProductID.Focus()
                Return False
            End If
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_StageID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ma_cong_doan"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_StageID
                tdbg.Row = i
                tdbg.Focus()
                Return False
            Else
                If tdbg(i, COL_OrderNo).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Thu_tu_hien_thi"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_OrderNo
                    tdbg.Row = i
                    tdbg.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        _ProductID = txtProductID.Text
        _displayOrder = txtDisplayOrder.Text

        Dim sSQL As New StringBuilder("")
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD45T1000.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1001s.ToString)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1000.ToString & vbCrLf)
                sSQL.Append(SQLDeleteD45T1001.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1001s.ToString)
        End Select

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()

            sSQL = New StringBuilder("")
            sSQL.Append(SQLInsertD91T9009())
            ExecuteSQL(sSQL.ToString)

            _bSaved = True

            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    ' If gbUseAudit Then
                    'RunAuditLog(AuditCodeProducts, "02", txtProductID.Text, txtProductName.Text, tdbcUnitID.Text, txtNote.Text)
                    Lemon3.D91.RunAuditLog("45", AuditCodeProducts, "02", txtProductID.Text, txtProductName.Text, tdbcUnitID.Text, txtNote.Text)
                    'End If
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1000
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/04/2007 09:54:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1000() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D45T1000(")
        sSQL.Append("TransactionDate, ProductID, ProductName, ProductNameU, ShortName, ShortNameU, UnitID, ")
        sSQL.Append("Note, NoteU, Disabled, CreateUserID, CreateDate, LastModifyUserID, ")
        sSQL.Append("LastModifyDate, M01ID, M02ID, M03ID, M04ID, M05ID, DisplayOrder,CustomerID, StatusID, ProductionBatchU")
        sSQL.Append(") Values(")
        sSQL.Append(SQLDateSave(c1dateTransactionDate.Value) & COMMA) 'TransactionDate, datetime, NULL
        sSQL.Append(SQLString(txtProductID.Text) & COMMA) 'ProductID [KEY], varchar[20], NOT NULL

        sSQL.Append(SQLStringUnicode(txtProductName.Text, gbUnicode, False) & COMMA) 'ProductName, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtProductName.Text, gbUnicode, True) & COMMA) 'ProductName, varchar[150], NOT NULL

        sSQL.Append(SQLStringUnicode(txtShortName.Text, gbUnicode, False) & COMMA) 'ShortName, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtShortName.Text, gbUnicode, True) & COMMA) 'ShortName, varchar[50], NOT NULL

        sSQL.Append(SQLString(tdbcUnitID.Text) & COMMA) 'UnitID, varchar[20], NOT NULL

        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'Note, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'Note, varchar[150], NOT NULL

        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(tdbcS01ID.Text) & COMMA) 'S01ID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcS02ID.Text) & COMMA) 'S02ID, varchar[50], NOT NULL
        sSQL.Append(SQLString(tdbcS03ID.Text) & COMMA) 'S03ID, varchar[50], NOT NULL
        sSQL.Append(SQLString(tdbcS04ID.Text) & COMMA) 'S04ID, varchar[50], NOT NULL
        sSQL.Append(SQLString(tdbcS05ID.Text) & COMMA) 'S05ID, varchar[50], NOT NULL
        sSQL.Append(SQLNumber(txtDisplayOrder.Text) & COMMA) 'DisplayOrder, int, NOT NULL
        'ID 83982 25.02.2016
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCustomerID)) & COMMA) 'CustomerID, varchar[50], NOT NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcStatusID)) & COMMA) 'StatusID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtProductionBatch.Text, gbUnicode, True)) 'ProductionBatch, varchar[50], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD45T1000
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/04/2007 09:54:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD45T1000() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T1000 Set ")
        sSQL.Append("TransactionDate = " & SQLDateSave(c1dateTransactionDate.Value) & COMMA) 'datetime, NULL

        sSQL.Append("ProductName = " & SQLStringUnicode(txtProductName.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("ProductNameU = " & SQLStringUnicode(txtProductName.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL

        sSQL.Append("ShortName = " & SQLStringUnicode(txtShortName.Text, gbUnicode, False) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("ShortNameU = " & SQLStringUnicode(txtShortName.Text, gbUnicode, True) & COMMA) 'varchar[50], NOT NULL

        sSQL.Append("UnitID = " & SQLString(tdbcUnitID.Text) & COMMA) 'varchar[20], NOT NULL

        sSQL.Append("Note = " & SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL

        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("DisplayOrder = " & SQLNumber(txtDisplayOrder.Text) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("M01ID = " & SQLString(tdbcS01ID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("M02ID = " & SQLString(tdbcS02ID.Text) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("M03ID = " & SQLString(tdbcS03ID.Text) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("M04ID = " & SQLString(tdbcS04ID.Text) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("M05ID = " & SQLString(tdbcS05ID.Text) & COMMA) 'varchar[50], NOT NULL
        'ID 83982 25.02.2016
        sSQL.Append("CustomerID = " & SQLString(ReturnValueC1Combo(tdbcCustomerID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("StatusID = " & SQLString(ReturnValueC1Combo(tdbcStatusID)) & COMMA) 'varchar[50], NOT NULL
        sSQL.Append("ProductionBatchU = " & SQLStringUnicode(txtProductionBatch.Text, gbUnicode, True)) 'varchar[50], NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("ProductID = " & SQLString(_ProductID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T1001s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/04/2007 09:54:38
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T1001s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.Splits(0).Rows.Count - 2
            sSQL.Append("Insert Into D45T1001(")
            sSQL.Append("ProductID, StageID, OrderNo")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtProductID.Text) & COMMA) 'ProductID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_StageID)) & COMMA) 'StageID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_OrderNo))) 'OrderNo, int, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T1001
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/04/2007 09:54:49
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T1001() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T1001"
        sSQL &= " Where "
        sSQL &= "ProductID = " & SQLString(_ProductID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 07/05/2009 03:07:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D91T9009"
        sSQL &= " Where "
        sSQL &= " UserID = " & SQLString(gsUserID)
        sSQL &= " And HostID = " & SQLString(My.Computer.Name)
        sSQL &= " And Key01ID = " & SQLString("45")
        sSQL &= " And Key02ID = " & SQLString("D45F1000")
        sSQL &= " And Key03ID = " & SQLString("ProductID")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009
    '# Created User: DUCTRONG
    '# Created Date: 07/05/2009 03:13:31
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D91T9009(")
        sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, Key04ID ")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString("45") & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString("D45F1000") & COMMA) 'Key02ID, varchar[250], NOT NULL
        sSQL.Append(SQLString("ProductID") & COMMA) 'Key03ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(txtProductID.Text)) 'Key04ID, varchar[250], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1002
    '# Created User: KIMLONG
    '# Created Date: 25/02/2016 03:19:09
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1002() As String
        Dim sSQL As String = ""
        sSQL &= ("-- -- Do nguon combo KH" & vbCrlf)
        sSQL &= "Exec D45P1002 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function



    Private Sub TabAna_Focus()
        If tdbcS01ID.ReadOnly = False Then tdbcS01ID.Focus() : Exit Sub
        If tdbcS02ID.ReadOnly = False Then tdbcS02ID.Focus() : Exit Sub
        If tdbcS03ID.ReadOnly = False Then tdbcS03ID.Focus() : Exit Sub
        If tdbcS04ID.ReadOnly = False Then tdbcS04ID.Focus() : Exit Sub
        If tdbcS05ID.ReadOnly = False Then tdbcS05ID.Focus() : Exit Sub
    End Sub

    Private Sub txtDisplayOrder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisplayOrder.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtDisplayOrder_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisplayOrder.LostFocus
        If L3IsNumeric(txtDisplayOrder.Text, EnumDataType.Int) = False Then
            txtDisplayOrder.Text = ""
        End If
    End Sub

#Region "Events tdbcCustomerID load tdbcStatusID"

    Private Sub tdbcCustomerID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCustomerID.SelectedValueChanged
        If tdbcCustomerID.SelectedValue Is Nothing OrElse tdbcCustomerID.Text = "" Then
            'tdbcStatusID.Text = ""
            Exit Sub
        End If
        tdbcStatusID.SelectedIndex = 0
    End Sub

    Private Sub tdbcCustomerID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCustomerID.LostFocus
        If tdbcCustomerID.FindStringExact(tdbcCustomerID.Text) = -1 Then
            tdbcCustomerID.Text = ""
            'tdbcStatusID.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub tdbcStatusID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcStatusID.LostFocus
        If tdbcStatusID.FindStringExact(tdbcStatusID.Text) = -1 Then tdbcStatusID.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCustomerID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCustomerID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

End Class