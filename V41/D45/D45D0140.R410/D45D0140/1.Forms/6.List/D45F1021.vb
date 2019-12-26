Imports System.Windows.Forms
Imports System
Imports C1.Win.C1TrueDBGrid
Imports System.Linq

'#-------------------------------------------------------------------------------------
'# Created Date: 21/05/2007 2:36:08 PM
'# Created User: Nguyễn Lê Phương
'# Modify Date: 21/05/2007 2:36:08 PM
'# Modify User: Nguyễn Lê Phương
'#-------------------------------------------------------------------------------------
Public Class D45F1021
    Private _bSaved As Boolean = False
    Dim dtFormat As DataTable
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Dim iHeight As Integer
    Dim dtTermID, dtGrid, dtPrice, dtMachince, dtdepartmentID As DataTable
    Dim dtPriceType, dtCaptionCols As DataTable
    Dim iColLast As Integer = COL_PriceMethodName 'Cột cuối cùng hiển thị
    Dim sColor As System.Drawing.Color
    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Dim bUseSpec As Boolean = False




#Region "Const of tdbg - Total of Columns: 39"
    Private Const COL_TransID As Integer = 0          ' TransID
    Private Const COL_OrderNo As Integer = 1          ' STT
    Private Const COL_ProductID As Integer = 2        ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 3      ' Tên sản phẩm
    Private Const COL_OProductName As Integer = 4     ' OProductName
    Private Const COL_DepartmentName As Integer = 5   ' Phòng ban
    Private Const COL_TeamName As Integer = 6         ' Tổ nhóm
    Private Const COL_StageName As Integer = 7        ' Công đoạn
    Private Const COL_Spec01Name As Integer = 8       ' Spec01Name
    Private Const COL_Spec02Name As Integer = 9       ' Spec02Name
    Private Const COL_Spec03Name As Integer = 10      ' Spec03Name
    Private Const COL_Spec04Name As Integer = 11      ' Spec04Name
    Private Const COL_Spec05Name As Integer = 12      ' Spec05Name
    Private Const COL_Spec06Name As Integer = 13      ' Spec06Name
    Private Const COL_Spec07Name As Integer = 14      ' Spec07Name
    Private Const COL_Spec08Name As Integer = 15      ' Spec08Name
    Private Const COL_Spec09Name As Integer = 16      ' Spec09Name
    Private Const COL_Spec10Name As Integer = 17      ' Spec10Name
    Private Const COL_MachineID As Integer = 18       ' Máy sản xuất
    Private Const COL_PriceMethodName As Integer = 19 ' Loại giá
    Private Const COL_UnitPrice01 As Integer = 20     ' UnitPrice01
    Private Const COL_UnitPrice02 As Integer = 21     ' UnitPrice02
    Private Const COL_UnitPrice03 As Integer = 22     ' UnitPrice03
    Private Const COL_UnitPrice04 As Integer = 23     ' UnitPrice04
    Private Const COL_UnitPrice05 As Integer = 24     ' UnitPrice05
    Private Const COL_DepartmentID As Integer = 25    ' DepartmentID
    Private Const COL_TeamID As Integer = 26          ' TeamID
    Private Const COL_StageID As Integer = 27         ' StageID
    Private Const COL_Spec01ID As Integer = 28        ' Spec01ID
    Private Const COL_Spec02ID As Integer = 29        ' Spec02ID
    Private Const COL_Spec03ID As Integer = 30        ' Spec03ID
    Private Const COL_Spec04ID As Integer = 31        ' Spec04ID
    Private Const COL_Spec05ID As Integer = 32        ' Spec05ID
    Private Const COL_Spec06ID As Integer = 33        ' Spec06ID
    Private Const COL_Spec07ID As Integer = 34        ' Spec07ID
    Private Const COL_Spec08ID As Integer = 35        ' Spec08ID
    Private Const COL_Spec09ID As Integer = 36        ' Spec09ID
    Private Const COL_Spec10ID As Integer = 37        ' Spec10ID
    Private Const COL_PriceMethodID As Integer = 38   ' PriceMethodID
#End Region


#Region "Const of tdbg2"
    Private Const COL2_DetailTransID As Integer = 0 ' DetailTransID
    Private Const COL2_TransID As Integer = 1       ' TransID
    Private Const COL2_OrderNo As Integer = 2       ' OrderNo
    Private Const COL2_ProductID As Integer = 3     ' ProductID
    Private Const COL2_QtyFrom As Integer = 4       ' >= Số lượng
    Private Const COL2_QtyTo As Integer = 5         ' < Số lượng
    Private Const COL2_UnitPrice01 As Integer = 6   ' UnitPrice01
    Private Const COL2_UnitPrice02 As Integer = 7   ' UnitPrice02
    Private Const COL2_UnitPrice03 As Integer = 8   ' UnitPrice03
    Private Const COL2_UnitPrice04 As Integer = 9   ' UnitPrice04
    Private Const COL2_UnitPrice05 As Integer = 10  ' UnitPrice05
#End Region

#Region "Const of tdbgPrice"
    Private Const COLP_OrderNo As Integer = 0            ' STT
    Private Const COLP_Choose As Integer = 1      ' Chọn
    Private Const COLP_StageID As Integer = 2     ' Công đoạn
    Private Const COLP_UnitPrice01 As Integer = 3 ' UnitPrice01
    Private Const COLP_UnitPrice02 As Integer = 4 ' UnitPrice02
    Private Const COLP_UnitPrice03 As Integer = 5 ' UnitPrice03
    Private Const COLP_UnitPrice04 As Integer = 6 ' UnitPrice04
    Private Const COLP_UnitPrice05 As Integer = 7 ' UnitPrice05
    Private Const COLP_Row As Integer = 8         ' Row
#End Region

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            _FormState = value

            LoadTableCaptionPrice()
            LoadTDBGridSpecificationCaption(tdbg, COL_Spec01Name, 1)
            LoadTDBCombo()
            LoadTDBDropDown()
            LoadFormatC()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    chkDisabled.Visible = False
                    LoadAddNew()
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _PriceListID As String
    Public Property PriceListID() As String
        Get
            Return _PriceListID
        End Get
        Set(ByVal Value As String)
            If _PriceListID = Value Then
                _PriceListID = ""
                Return
            End If
            _PriceListID = Value
        End Set
    End Property

    Private _status As String = ""
    Public WriteOnly Property Status() As String
        Set(ByVal Value As String)
            _status = Value
        End Set
    End Property

    Private Sub D45F1021_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.Escape Then
            If grpFrm.Visible Then ShowFramCalcule(False)
            Exit Sub
        End If
    End Sub

    Private Sub D45F1021_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        SetBackColorObligatory()
        tdbg_LockedColumns()
        tdbg2_LockedColumns()
        tdbgPrice_LockedColumns()
        tdbg_NumberFormat()
        tdbg2_NumberFormat()
        tdbgPrice_NumberFormat()


        ResetFooterGrid(tdbg, 0, 1)
        ResetSplitDividerSize(tdbg)
        ResetFooterGrid(tdbgPrice)
        '*************************
        InputPercent(txtRate)
        txtRate.AcceptsTab = True
        txtRate.ErrorInfo.ErrorMessageCaption = "ERROR"
        txtRate.ErrorInfo.ShowErrorMessage = False
        txtRate.ErrorInfo.ErrorAction = C1.Win.C1Input.ErrorActionEnum.None


        '*************************
        CheckIdTextBox(txtPriceListID)
        InputbyUnicode(Me, gbUnicode)
        '*************************
        If D45Options.UseEnterMoveDown Then tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
        For i As Integer = COL_UnitPrice01 To COL_UnitPrice05
            tdbg.Splits(1).DisplayColumns(i).FetchStyle = True
        Next
        For i As Integer = COL2_UnitPrice01 To COL2_UnitPrice05
            tdbg2.Splits(0).DisplayColumns(i).FetchStyle = True
        Next
        '*************************
        sColor = tdbg.HighLightRowStyle.BackColor
        iHeight = tdbg.Height
        '*************************
        InputDateCustomFormat(c1dateValidTo, c1dateValidFrom, c1dateDateTo, c1dateDateFrom)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadTDBCombo()
        dtMachince = ReturnTableBlockID_D09P6868(gsDivisionID, "D45F1020", 0)
        LoadDataSource(tdbcBlockID, dtMachince, gbUnicode)
        tdbcBlockID.Enabled = CheckEnableBlockID()
        If tdbcBlockID.Enabled And dtMachince.Rows.Count > 0 Then tdbcBlockID.SelectedIndex = 0
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdProductID
        sSQL = "Select ProductID, ProductName" & UnicodeJoin(gbUnicode) & " As ProductName "
        sSQL &= "From D45T1000  WITH(NOLOCK) Where Disabled = 0 Order By ProductID"
        LoadDataSource(tdbdProductID, sSQL, gbUnicode)

        'Load tdbdDepartmentID
        dtTermID = ReturnTableTeamID(True, False, gbUnicode)
        dtdepartmentID = ReturnTableDepartmentID(True, False, gbUnicode)
        LoadDataSource(tdbdDepartmentID, dtdepartmentID, gbUnicode)

        'Load tdbdStageID
        '15/11/2012 IncidentID	52403
        sSQL = "-- Do nguon cho dropdowm cong doan " & vbCrLf
        sSQL &= "SELECT	'*' AS StageID," & IIf(gbUnicode, "N'*(" & rL3("Khong_phu_thuoc_cong_doan") & ")'", ConvertUnicodeToVni("N'*(" & rL3("Khong_phu_thuoc_cong_doan") & ")'")).ToString & " AS StageName,1 AS UP01, 1 AS UP02, 1 AS UP03, 1 AS UP04, 1 AS UP05, 0 AS DisplayOrder ,0 AS DisOrder" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT StageID, StageName" & UnicodeJoin(gbUnicode) & " As StageName, UP01, UP02, UP03, UP04, UP05, DisplayOrder, 1 AS DisOrder" & vbCrLf
        sSQL &= "FROM D45T1010 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY DisOrder,DisplayOrder"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbdStageID, dt.DefaultView.Table, gbUnicode)
        LoadDataSource(tdbdStageID1, dt.DefaultView.Table, gbUnicode)

        'Load tdbdPriceMethod
        sSQL = "Select PriceMethod, PriceMethodName" & UnicodeJoin(gbUnicode) & " As PriceMethodName "
        sSQL &= "From D45V1022 Where Language = " & SQLString(gsLanguage) & " Order By PriceMethod"
        LoadDataSource(tdbdPriceMethod, sSQL, gbUnicode)

        sSQL = "-- DropDown May san xuat " & vbCrLf
        sSQL &= "     SELECT MachineID, MachineNameU AS MachineName " & vbCrLf
        sSQL &= "  FROM 	D45T1110 WITH(NOLOCK)" & vbCrLf
        sSQL &= "       WHERE Disabled = 0 " & vbCrLf
        sSQL &= " ORDER BY MachineName"
        LoadDataSource(tdbdMachineID, sSQL, gbUnicode)

        'Load 10 quy cách
        LoadTDBDropDownSpecification(tdbdSpec01ID, tdbdSpec02ID, tdbdSpec03ID, tdbdSpec04ID, tdbdSpec05ID, tdbdSpec06ID, tdbdSpec07ID, tdbdSpec08ID, tdbdSpec09ID, tdbdSpec10ID, tdbg, COL_Spec01Name, gbUnicode)
    End Sub

    Private Sub LoadTeamID(ByVal sDepartmentID As String)
        LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTermID, "DepartmentID = " & SQLString(sDepartmentID), True), gbUnicode)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Cap_nhat_chi_tiet_bang_gia_-_D45F1021") & UnicodeCaption(gbUnicode) 'CËp nhËt chi tiÕt b¶ng giÀ - D45F1021
        '================================================================ 
        lblPriceListID.Text = rL3("Ma_bang_gia") 'Mã bảng giá
        lblPriceListName.Text = rL3("Dien_giai") 'Diễn giải
        lblNote.Text = rL3("Ghi_chu") 'Ghi chú
        lblteDateFrom.Text = rL3("Tu_ngay") 'Từ ngày
        lblteDateTo.Text = rL3("Den_ngay") 'Đến ngày
        lblEnter.Text = rL3("Ban_dat_con_tro_vao_cot_muon_tim_kiem_sau_do_nhap_gia_tri_muon_tim_vao_day_roi_bam_tim_kiem")
        lblteValidDateFrom.Text = rL3("Hieu_luc") 'Hiệu lực
        '================================================================ 
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnNext.Text = rL3("Nhap__tiep") 'Nhập &tiếp
        btnSave.Text = rL3("_Luu") '&Lưu
        btnHotKeys.Text = rL3("Phim_nong") 'Phím nóng
        btnFind.Text = rL3("Tim__kiem")
        btnCalcul.Text = rL3("Tinh")
        btnExit.Text = btnClose.Text
        btnExportToExcel.Text = rL3("Xuat__Excel") 'Xuất &Excel
        '================================================================ 
        GroupBox3.Text = rL3("Chi_tiet") 'Chi tiết
        grpCalcul.Text = rL3("Tinh_don_gia") ' rl3("Tinh_don_gia")
        '================================================================ 
        optRate.Text = rL3("Theo_ty_le_tren_tong_don_gia_cac_cong_doan_khac")
        '================================================================ 
        chkIsStage.Text = rL3("Bang_gia_theo_cong_doan")
        chkIsDepartment.Text = rL3("Bang_gia_theo_phong_ban_to_nhom")
        chkDisabled.Text = rL3("Khong_su_dung") 'Không hiển thị
        chkIsSpec.Text = rL3("Bang_gia_theo_quy_cach") 'Bảng giá theo quy cách
        '================================================================
        tdbdProductID.Columns("ProductID").Caption = rL3("Ma")
        tdbdProductID.Columns("ProductName").Caption = rL3("Ten")
        tdbdDepartmentID.Columns("DepartmentID").Caption = rL3("Ma")
        tdbdDepartmentID.Columns("DepartmentName").Caption = rL3("Ten")
        tdbdTeamID.Columns("TeamID").Caption = rL3("Ma")
        tdbdTeamID.Columns("TeamName").Caption = rL3("Ten")
        tdbdStageID.Columns("StageID").Caption = rL3("Ma")
        tdbdStageID.Columns("StageName").Caption = rL3("Ten")
        tdbdPriceMethod.Columns("PriceMethod").Caption = rL3("Ma")
        tdbdPriceMethod.Columns("PriceMethodName").Caption = rL3("Ten")
        tdbdSpec01ID.Columns("SpecID").Caption = rL3("Ma")
        tdbdSpec01ID.Columns("SpecName").Caption = rL3("Ten")
        tdbdSpec02ID.Columns("SpecID").Caption = rL3("Ma")
        tdbdSpec02ID.Columns("SpecName").Caption = rL3("Ten")
        tdbdSpec03ID.Columns("SpecID").Caption = rL3("Ma")
        tdbdSpec03ID.Columns("SpecName").Caption = rL3("Ten")
        tdbdSpec04ID.Columns("SpecID").Caption = rL3("Ma")
        tdbdSpec04ID.Columns("SpecName").Caption = rL3("Ten")
        tdbdSpec05ID.Columns("SpecID").Caption = rL3("Ma")
        tdbdSpec05ID.Columns("SpecName").Caption = rL3("Ten")
        tdbdSpec06ID.Columns("SpecID").Caption = rL3("Ma")
        tdbdSpec06ID.Columns("SpecName").Caption = rL3("Ten")
        tdbdSpec07ID.Columns("SpecID").Caption = rL3("Ma")
        tdbdSpec07ID.Columns("SpecName").Caption = rL3("Ten")
        tdbdSpec08ID.Columns("SpecID").Caption = rL3("Ma")
        tdbdSpec08ID.Columns("SpecName").Caption = rL3("Ten")
        tdbdSpec09ID.Columns("SpecID").Caption = rL3("Ma")
        tdbdSpec09ID.Columns("SpecName").Caption = rL3("Ten")
        tdbdSpec10ID.Columns("SpecID").Caption = rL3("Ma")
        tdbdSpec10ID.Columns("SpecName").Caption = rL3("Ten")
        '================================================================
        tdbg.Columns(COL_OrderNo).Caption = rL3("STT") 'STT
        tdbg.Columns("ProductID").Caption = rL3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns(COL_ProductName).Caption = rL3("Ten_san_pham") 'Diễn giải
        tdbg.Columns("DepartmentName").Caption = rL3("Phong_ban")
        tdbg.Columns("TeamName").Caption = rL3("To_nhom")
        tdbg.Columns("StageName").Caption = rL3("Cong_doan")
        tdbg.Columns("PriceMethodName").Caption = rL3("Loai_gia")
        '================================================================
        tdbg2.Columns("QtyFrom").Caption = ">= " & rL3("So_luong")
        tdbg2.Columns("QtyTo").Caption = "< " & rL3("So_luong")
        '================================================================
        tdbgPrice.Columns(0).Caption = rL3("STT") 'STT
        tdbgPrice.Columns("Choose").Caption = rL3("Chon") 'Chọn
        tdbgPrice.Columns("StageID").Caption = rL3("Cong_doan")
        '================================================================ 
        chkMachineID.Text = rL3("Bang_gia_theo_may_san_xuat") 'Bảng giá theo máy sản xuất

        '================================================================ 
        lblBlockID.Text = rL3("Khoi") 'Khối
        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        tdbg.Columns(COL_OrderNo).Caption = rL3("STT") 'STT
        tdbg.Columns(COL_ProductID).Caption = rL3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns(COL_ProductName).Caption = rL3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_TeamName).Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_StageName).Caption = rL3("Cong_doan") 'Công đoạn
        tdbg.Columns(COL_MachineID).Caption = rL3("May_san_xuat") 'Máy sản xuất
        tdbg.Columns(COL_PriceMethodName).Caption = rL3("Loai_gia") 'Loại giá


    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P1020()
        dtGrid = ReturnDataTable(sSQL)
        _originalTotalRow = dtGrid.Rows.Count
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        UpdateTDBGOrderNum(tdbg, COL_OrderNo)
        FooterTotalGrid(tdbg, COL_ProductID)
        btnExportToExcel.Enabled = tdbg.RowCount > 0
    End Sub

    Private Sub LoadAddNew()
        c1dateDateFrom.Value = Now.Date
        c1dateDateTo.Value = Now.Date
        c1dateValidFrom.Value = Now.Date
        c1dateValidTo.Value = "NULL"
        chkIsStage.Checked = False
        chkIsDepartment.Checked = False
        chkIsSpec.Checked = False
        chkMachineID.Checked = False
        chkIsSpec_Click(Nothing, Nothing)
        btnNext.Enabled = False
        VisibledCol()
        LoadTDBGrid()
    End Sub

    Private Sub LoadEdit()
        If _status = "1" Then
            tdbg.AllowAddNew = True
            tdbg.AllowDelete = True
            tdbg.AllowUpdate = True

            tdbg2.AllowUpdate = False
        End If

        chkIsStage.Enabled = False
        chkIsDepartment.Enabled = False
        chkIsSpec.Enabled = False
        chkMachineID.Enabled = False
        ReadOnlyControl(txtPriceListID)
        btnNext.Visible = False
        btnSave.Left = btnNext.Left
        '--------------------------
        LoadMaster()
        LoadTDBGrid()
        '--------------------------
        Dim sSQL As String = "Select Top 1 1 From D45T2010  WITH(NOLOCK) Where PriceListID =" & SQLString(_PriceListID)
        If ExistRecord(sSQL) Then
            c1dateValidFrom.Enabled = False
        End If
        If c1dateValidTo.Text <> "" AndAlso CDate(c1dateValidTo.Text) < Today.Date Then
            c1dateValidTo.Enabled = False
        End If
        '--------------------------
        VisibledCol()
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String
        sSQL = "SELECT PriceListID, PriceListName" & UnicodeJoin(gbUnicode) & " as PriceListName, "
        sSQL &= "DateFrom, DateTo, Note" & UnicodeJoin(gbUnicode) & " as Note, Disabled, CreateUserID, "
        sSQL &= "CreateDate, LastModifyUserID, LastModifyDate, Mode, IsDepartment, ValidFrom, ValidTo, IsSpec,BlockID, IsCheckMachine" & vbCrLf
        sSQL &= " From D45T1020  WITH(NOLOCK) Where PriceListID=" & SQLString(_PriceListID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            txtPriceListID.Text = dt.Rows(0).Item("PriceListID").ToString
            txtPriceListName.Text = dt.Rows(0).Item("PriceListName").ToString
            txtNote.Text = dt.Rows(0).Item("Note").ToString
            chkDisabled.Checked = L3Bool(dt.Rows(0).Item("Disabled").ToString)
            chkIsStage.Checked = Not L3Bool(dt.Rows(0).Item("Mode").ToString)
            chkIsDepartment.Checked = L3Bool(dt.Rows(0).Item("IsDepartment").ToString)
            chkIsSpec.Checked = L3Bool(dt.Rows(0).Item("IsSpec").ToString)
            chkIsSpec_Click(Nothing, Nothing)
            c1dateDateFrom.Value = SQLDateShow(dt.Rows(0).Item("DateFrom").ToString)
            c1dateDateTo.Value = SQLDateShow(dt.Rows(0).Item("DateTo").ToString)
            c1dateValidFrom.Value = SQLDateShow(dt.Rows(0).Item("ValidFrom").ToString)
            c1dateValidTo.Value = SQLDateShow(dt.Rows(0).Item("ValidTo").ToString)
            chkMachineID.Checked = L3Bool(dt.Rows(0).Item("IsCheckMachine").ToString)
            tdbcBlockID.SelectedValue = dt.Rows(0).Item("BlockID").ToString
        End If
        dt.Dispose()
    End Sub

    Private Sub VisibledCol()
        tdbg.Splits(1).DisplayColumns(COL_StageName).Visible = chkIsStage.Checked
        tdbg.Splits(0).DisplayColumns(COL_DepartmentName).Visible = chkIsDepartment.Checked
        tdbg.Splits(0).DisplayColumns(COL_TeamName).Visible = chkIsDepartment.Checked
    End Sub

    Private Sub LoadTableCaptionPrice()
        Dim sSQL As String
        Dim dtCaption As New DataTable
        sSQL = "Select Code, ShortName" & UnicodeJoin(gbUnicode) & " As ShortName, Disabled From D45T0010 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Type = 'Price' Order By Code"
        dtCaption = ReturnDataTable(sSQL)

        For i As Integer = 0 To dtCaption.Rows.Count - 1
            tdbg.Splits(1).DisplayColumns(COL_UnitPrice01 + i).HeadingStyle.Font = FontUnicode(gbUnicode, FontStyle.Regular)
            tdbg.Columns(COL_UnitPrice01 + i).Caption = dtCaption.Rows(i).Item("ShortName").ToString
            tdbg.Splits(1).DisplayColumns(COL_UnitPrice01 + i).Visible = Not L3Bool(dtCaption.Rows(i).Item("Disabled").ToString)
            iColLast = COL_UnitPrice01 + i
            '**************************************************
            tdbg2.Splits(0).DisplayColumns(COL2_UnitPrice01 + i).HeadingStyle.Font = FontUnicode(gbUnicode, FontStyle.Regular)
            tdbg2.Columns(COL2_UnitPrice01 + i).Caption = dtCaption.Rows(i).Item("ShortName").ToString
            tdbg2.Splits(0).DisplayColumns(COL2_UnitPrice01 + i).Visible = Not L3Bool(dtCaption.Rows(i).Item("Disabled").ToString)
            '**************************************************
            tdbgPrice.Splits(0).DisplayColumns(COLP_UnitPrice01 + i).HeadingStyle.Font = FontUnicode(gbUnicode, FontStyle.Regular)
            tdbgPrice.Columns(COLP_UnitPrice01 + i).Caption = dtCaption.Rows(i).Item("ShortName").ToString
            tdbgPrice.Splits(0).DisplayColumns(COLP_UnitPrice01 + i).Visible = Not L3Bool(dtCaption.Rows(i).Item("Disabled").ToString)
        Next
    End Sub

    Private Sub LoadTDBGridSpecificationCaption(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal COL_Spec01ID As Integer, ByVal Split As Integer)
        Dim bUseSpec As Boolean = False

        Dim sSQL As String = "Select SpecTypeID, Caption" & UnicodeJoin(gbUnicode) & " as Caption, IsD45, Disabled From D07T0410 WITH(NOLOCK)  Order by SpecTypeID"
        Dim dt As New DataTable
        dt = ReturnDataTable(sSQL)
        Dim iIndex As Integer = COL_Spec01ID
        Dim i As Integer

        If dt.Rows.Count > 0 Then
            For i = 0 To 9
                tdbg.Columns(iIndex).Caption = dt.Rows(i).Item("Caption").ToString
                tdbg.Columns(iIndex).Tag = Convert.ToBoolean(dt.Rows(i).Item("IsD45")) AndAlso Not (Convert.ToBoolean(dt.Rows(i).Item("Disabled")))
                gbArrSpecVisiable(iIndex - COL_Spec01ID) = Convert.ToBoolean(tdbg.Columns(iIndex).Tag)
                If Not bUseSpec And Convert.ToBoolean(tdbg.Columns(iIndex).Tag) = True Then
                    bUseSpec = True
                End If
                tdbg.Splits(Split).DisplayColumns(iIndex).HeadingStyle.Font = FontUnicode(gbUnicode, tdbg.Splits(Split).DisplayColumns(iIndex).HeadingStyle.Font.Style) 'New System.Drawing.Font("Lemon3", 8.249999!)

                iIndex += 1
            Next
        End If
        dt = Nothing
    End Sub

    Private Sub SetBackColorObligatory()
        txtPriceListID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtPriceListName.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtRate.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateValidFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg2_LockedColumns()
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_QtyFrom).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbgPrice_LockedColumns()
        tdbgPrice.Splits(SPLIT0).DisplayColumns(COLP_OrderNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgPrice.Splits(SPLIT0).DisplayColumns(COLP_StageID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgPrice.Splits(SPLIT0).DisplayColumns(COLP_UnitPrice01).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgPrice.Splits(SPLIT0).DisplayColumns(COLP_UnitPrice02).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgPrice.Splits(SPLIT0).DisplayColumns(COLP_UnitPrice03).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgPrice.Splits(SPLIT0).DisplayColumns(COLP_UnitPrice04).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbgPrice.Splits(SPLIT0).DisplayColumns(COLP_UnitPrice05).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Function ReturnFormat(ByVal sCode As String) As String
        Dim dtR As DataTable
        Dim sFormat As String = ""
        dtR = ReturnTableFilter(dtFormat, "Code=" & SQLString(sCode), True)
        If dtR.Rows.Count > 0 Then sFormat = dtR.Rows(0)("Decimals").ToString
        Return sFormat
    End Function
    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_OrderNo).NumberFormat = DxxFormat.DefaultNumber0
        tdbg.Columns(COL_UnitPrice01).NumberFormat = CustomFormat(ReturnFormat("UP01"))
        tdbg.Columns(COL_UnitPrice02).NumberFormat = CustomFormat(ReturnFormat("UP02"))
        tdbg.Columns(COL_UnitPrice03).NumberFormat = CustomFormat(ReturnFormat("UP03"))
        tdbg.Columns(COL_UnitPrice04).NumberFormat = CustomFormat(ReturnFormat("UP04"))
        tdbg.Columns(COL_UnitPrice05).NumberFormat = CustomFormat(ReturnFormat("UP05"))
        'tdbg.Columns(COL_UnitPrice05).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub tdbg2_NumberFormat()
        tdbg2.Columns(COL2_QtyFrom).NumberFormat = DxxFormat.DefaultNumber2
        tdbg2.Columns(COL2_QtyTo).NumberFormat = DxxFormat.DefaultNumber2
        'tdbg2.Columns(COL2_UnitPrice01).NumberFormat = DxxFormat.DefaultNumber2
        'tdbg2.Columns(COL2_UnitPrice02).NumberFormat = DxxFormat.DefaultNumber2
        'tdbg2.Columns(COL2_UnitPrice03).NumberFormat = DxxFormat.DefaultNumber2
        'tdbg2.Columns(COL2_UnitPrice04).NumberFormat = DxxFormat.DefaultNumber2
        'tdbg2.Columns(COL2_UnitPrice05).NumberFormat = DxxFormat.DefaultNumber2
        tdbg2.Columns(COL2_UnitPrice01).NumberFormat = CustomFormat(ReturnFormat("UP01"))
        tdbg2.Columns(COL2_UnitPrice02).NumberFormat = CustomFormat(ReturnFormat("UP02"))
        tdbg2.Columns(COL2_UnitPrice03).NumberFormat = CustomFormat(ReturnFormat("UP03"))
        tdbg2.Columns(COL2_UnitPrice04).NumberFormat = CustomFormat(ReturnFormat("UP04"))
        tdbg2.Columns(COL2_UnitPrice05).NumberFormat = CustomFormat(ReturnFormat("UP05"))
    End Sub

    Private Sub tdbgPrice_NumberFormat()
        tdbgPrice.Columns(COLP_UnitPrice01).NumberFormat = DxxFormat.DefaultNumber2
        tdbgPrice.Columns(COLP_UnitPrice02).NumberFormat = DxxFormat.DefaultNumber2
        tdbgPrice.Columns(COLP_UnitPrice03).NumberFormat = DxxFormat.DefaultNumber2
        tdbgPrice.Columns(COLP_UnitPrice04).NumberFormat = DxxFormat.DefaultNumber2
        tdbgPrice.Columns(COLP_UnitPrice05).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub UpdateOldRowInsert()
        If dtPriceType.Rows.Count = 0 Then Exit Sub
        Dim iRow As String = tdbg.Row.ToString
        For i As Integer = 0 To dtPriceType.Rows.Count - 1
            If dtPriceType.Rows(i).Item("OrderNo").ToString > iRow Then
                dtPriceType.Rows(i).Item("OrderNo") = L3Int(dtPriceType.Rows(i).Item("OrderNo").ToString) + 1
            End If
        Next
        tdbg_RowColChange(Nothing, Nothing)
    End Sub

    Private Sub UpdateOldRowDelete()
        If dtPriceType.Rows.Count = 0 Then Exit Sub
        Dim iRow As Integer = tdbg.Row
        Dim bExitRow As Boolean
        For i As Integer = 0 To dtPriceType.Rows.Count - 1
            If L3Int(dtPriceType.Rows(i).Item("OrderNo").ToString) = iRow + 1 Then
                bExitRow = True
            ElseIf L3Int(dtPriceType.Rows(i).Item("OrderNo").ToString) > iRow Then
                dtPriceType.Rows(i).Item("OrderNo") = L3Int(dtPriceType.Rows(i).Item("OrderNo").ToString) - 1
            End If
        Next
        If bExitRow Then
            dtPriceType = ReturnTableFilter(dtPriceType, "OrderNo <> " & Number(iRow))
        End If
        tdbg_RowColChange(Nothing, Nothing)
    End Sub

    Private Sub LoadTDBGrid2()
        If dtPriceType Is Nothing Then LoadTablePriceType()
        Dim dt As DataTable = ReturnTableFilter(dtPriceType, "OrderNo = " & Number(tdbg.Columns(COL_OrderNo).Text), True)
        LoadDataSource(tdbg2, dt, gbUnicode)
    End Sub

    Private Sub SaveCurrentRow()
        If dtPriceType Is Nothing Then LoadTablePriceType()
        tdbg2.UpdateData()
        Dim dt As DataTable = CType(tdbg2.DataSource, DataTable)
        If dt Is Nothing Then Exit Sub
        dtPriceType = ReturnTableFilter(dtPriceType, "OrderNo <> " & Number(tdbg.Columns(COL_OrderNo).Text))
        dtPriceType.Merge(dt, True)
    End Sub

    Private Sub LoadTablePriceType()
        tdbg.UpdateData()
        dtGrid.AcceptChanges()

        If _FormState = EnumFormState.FormAdd Then
            dtPriceType = ReturnDataTable("Select 0 As OrderNo, * From D45T1024  WITH(NOLOCK) Where PriceListID = ''")
        Else
            dtPriceType = ReturnDataTable("Select 0 As OrderNo, * From D45T1024  WITH(NOLOCK) Where PriceListID = " & SQLString(_PriceListID))
            For i As Integer = 0 To tdbg.RowCount - 1
                For j As Integer = 0 To dtPriceType.Rows.Count - 1
                    If dtPriceType.Rows(j).Item("TransID").ToString = tdbg(i, COL_TransID).ToString Then
                        dtPriceType.Rows(j).Item("OrderNo") = tdbg(i, COL_OrderNo).ToString
                    End If
                Next
            Next
        End If

        dtPriceType.AcceptChanges()
    End Sub

    Private Sub CalculatorProductNameFromSpec_All(Optional ByVal bHeadClick As Boolean = False)
        Dim iRow As Integer = L3Int(IIf(bHeadClick, tdbg.Row, 0)) 'Set value từ dòng 0 khi load lại lưới. VD như Kế thừa...
        For i As Integer = iRow To tdbg.RowCount - 1
            tdbg(i, COL_ProductName) = CalculatorProductNameFromSpec(i)
        Next
    End Sub

    Private Function CalculatorProductNameFromSpec(ByVal row As Integer) As String
        Dim sFullInventoryName As String = ""
        sFullInventoryName = tdbg(row, COL_OProductName).ToString
        For i As Integer = 0 To 9
            If L3Bool(tdbg.Columns(COL_Spec01Name + i).Tag) And tdbg(row, COL_Spec01Name + i).ToString <> "" Then
                sFullInventoryName &= Space(1) & Trim(tdbg(row, COL_Spec01Name + i).ToString)
            End If
        Next
        Return sFullInventoryName
    End Function

    Private Sub HeadClick_tdbg(ByVal icol As Integer)
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then Exit Sub

        Select Case icol
            Case COL_ProductID
                Dim iCols() As Integer = {COL_ProductID, COL_OProductName}
                CopyColumnArr(tdbg, tdbg.Col, iCols)
                CalculatorProductNameFromSpec_All(True)

            Case COL_DepartmentName
                Dim iCols() As Integer = {COL_DepartmentID, COL_TeamID, COL_TeamName}
                CopyColumnArr(tdbg, tdbg.Col, iCols)

            Case COL_Spec01Name To COL_Spec10Name
                Dim indexID As Integer = IndexOfColumn(tdbg, tdbg.Columns(icol).DataField.Replace("Name", "ID"))
                Dim iCols() As Integer = {indexID}
                CopyColumnsMyArr(tdbg, icol, tdbg.Columns(icol).Value.ToString, tdbg.Row, iCols)
                CalculatorProductNameFromSpec_All(True)

            Case COL_UnitPrice01 To COL_UnitPrice05
                CopyColumnsMy(tdbg, icol, tdbg.Columns(icol).Value.ToString, tdbg.Row)

            Case Else
                CopyColumnsMy(tdbg, icol, tdbg.Columns(icol).Value.ToString, tdbg.Row)
        End Select
    End Sub


#Region "tdbg"
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_UnitPrice01 To COL_UnitPrice05
                If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Number) Then tdbg.Columns(e.ColIndex).Text = ""
            Case COL_TeamName, COL_StageName, COL_Spec01Name To COL_Spec10Name, COL_PriceMethodName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("Name", "ID")).Text = ""
                End If
            Case COL_ProductID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    tdbg.Columns(COL_ProductName).Text = ""
                    tdbg.Columns(COL_OProductName).Text = ""
                End If
            Case COL_DepartmentName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    tdbg.Columns(COL_ProductID).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeDelete
        UpdateOldRowDelete()
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        ResetGrid()
        tdbg_RowColChange(Nothing, Nothing)
    End Sub

    Private Sub tdbg_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeRowColChange
        If tdbg.Row <> tdbg.RowCount Then
            SaveCurrentRow()
            tdbg2.Delete(0, tdbg2.RowCount)
        End If
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_ProductID
                If tdbg.Columns(e.ColIndex).Text <> "" Then tdbg.Columns(COL_OProductName).Text = tdbdProductID.Columns("ProductName").Text
                tdbg.Columns(COL_ProductName).Text = CalculatorProductNameFromSpec(tdbg.Bookmark)
                If tdbg.Columns(COL_PriceMethodName).Text = "" Then
                    tdbg.Columns(COL_PriceMethodName).Text = ReturnValueC1DropDown(tdbdPriceMethod, tdbdPriceMethod.DisplayMember, "PriceMethod=0")
                    tdbg.Columns(COL_PriceMethodID).Text = "0"
                End If

            Case COL_DepartmentName
                If tdbg.Columns(e.ColIndex).Text <> "" Then
                    tdbg.Columns(COL_DepartmentID).Text = tdbdDepartmentID.Columns("DepartmentID").Text
                End If
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""
                'Case COL_MachineID
                '    If tdbg.Columns(e.ColIndex).Text <> "" Then
                '        tdbg.Columns(COL_MachineID).Text = tdbdMachineID.Columns("MachineID").Text
                '    End If

            Case COL_TeamName
                If tdbg.Columns(e.ColIndex).Text = "" Then Exit Sub
                tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns("TeamID").Text

            Case COL_StageName
                If tdbg.Columns(e.ColIndex).Text = "" Then Exit Sub
                tdbg.Columns(COL_StageID).Text = tdbdStageID.Columns("StageID").Text

            Case COL_Spec01Name To COL_Spec10Name
                If tdbg.Columns(e.ColIndex).Text <> "" Then
                    tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("Name", "ID")).Text = tdbg.Columns(e.ColIndex).DropDown.Columns("SpecID").Text
                End If
                tdbg.Columns(COL_ProductName).Text = CalculatorProductNameFromSpec(tdbg.Bookmark)

            Case COL_PriceMethodName
                If tdbg.Columns(e.ColIndex).Text = "" Then Exit Sub
                tdbg.Columns(COL_PriceMethodID).Text = tdbdPriceMethod.Columns("PriceMethod").Text
                If Number(tdbg.Columns(COL_PriceMethodID).Text) = 0 Then
                    tdbg.Height = iHeight
                Else
                    tdbg.Height = iHeight - tdbg2.Height - 5 ' 239
                End If
        End Select

        ResetGrid()
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
        If _status = "1" Then
            Select Case e.ColIndex
                Case COL_ProductID, COL_DepartmentID, COL_StageID, COL_MachineID

                    Dim _duplicate As Array = dtGrid.AsEnumerable().GroupBy(Function(i) New With {Key .ProductID = IIf(i("ProductID") IsNot DBNull.Value, i("ProductID"), ""),
                                                                                         Key .DepartmentName = IIf(i("DepartmentID") IsNot DBNull.Value, i("DepartmentID"), ""),
                                                                                         Key .StageID = IIf(i("StageID") IsNot DBNull.Value, i("StageID"), ""),
                                                                                         Key .MachineID = IIf(i("MachineID") IsNot DBNull.Value, i("MachineID"), "")}).Where(Function(p) p.Count > 1).ToArray()
                    If _duplicate IsNot Nothing AndAlso _duplicate.Length > 0 Then
                        D99C0008.MsgDuplicatePKey()
                        Select Case e.ColIndex
                            Case COL_ProductID
                                tdbg.Columns(COL_ProductID).Text = ""
                                tdbg.Columns(COL_ProductName).Text = ""
                                tdbg.Columns(COL_OProductName).Text = ""
                            Case COL_DepartmentName
                                tdbg.Columns(COL_DepartmentID).Text = ""
                                tdbg.Columns(COL_DepartmentName).Text = ""
                            Case COL_MachineID
                                tdbg.Columns(COL_MachineID).Text = ""
                            Case COL_StageName
                                tdbg.Columns(COL_StageID).Text = ""
                                tdbg.Columns(COL_StageName).Text = ""
                        End Select
                    End If
            End Select
        End If
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If _status = "1" Then Exit Sub
        HeadClick_tdbg(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            HeadClick_tdbg(tdbg.Col)
        ElseIf e.KeyCode = Keys.Enter And tdbg.Col = iColLast Then
            If D45Options.UseEnterMoveDown Then Exit Sub
            HotKeyEnterGrid(tdbg, COL_ProductID, e, SPLIT0)
        ElseIf e.Shift And e.KeyCode = Keys.Insert Then
            UpdateOldRowInsert()
            HotKeyShiftInsert(tdbg, COL_OrderNo)
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.Delete Then
            If Not tdbg.AllowDelete Or tdbg.RowCount < 1 Then e.Handled = True
            If tdbg.Bookmark <> tdbg.Row + tdbg.FirstRow Then e.Handled = True
            If D99C0008.MsgAskDeleteRow() = Windows.Forms.DialogResult.Yes Then
                UpdateOldRowDelete()
                tdbg.Delete(tdbg.Bookmark)
                tdbg.UpdateData()
                ResetGrid()
                tdbg_RowColChange(Nothing, Nothing)
            Else
                e.Handled = True
            End If
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter And tdbg.Col = COL_ProductID Then
            If Not CheckDropdownInList(tdbdProductID, tdbg.Columns(COL_ProductID).Text) Then
                tdbg.Columns(COL_ProductName).Value = ""
            End If
            Exit Sub
        Else
            HotKeyDownGrid(e, tdbg, COL_ProductID, 0, 1)
        End If

        If e.KeyCode = Keys.F9 And chkIsStage.Checked And Not String.IsNullOrEmpty(tdbg(tdbg.Row, COL_ProductID).ToString()) Then
            Select Case tdbg.Col
                Case COL_ProductID, COL_PriceMethodName, COL_StageID, COL_UnitPrice01 To COL_UnitPrice05
                    ShowFramCalcule(True)
                    Exit Sub
            End Select
        End If

    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_UnitPrice01 To COL_UnitPrice05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        If (tdbg(e.Row, COL_PriceMethodID).ToString <> "0" OrElse tdbg(e.Row, COL_PriceMethodID).ToString = "") And e.Col <> COL_PriceMethodName Then
            e.CellStyle.Locked = True
            e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        Else
            If chkIsStage.Checked Then
                Select Case e.Col
                    Case COL_UnitPrice01 To COL_UnitPrice05
                        'Dim bUse As Boolean
                        'bUse = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP01", "StageID = " & SQLString(tdbg(e.Row, COL_StageID))))
                        'If Not bUse Then
                        '    e.CellStyle.Locked = True
                        '    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                        'End If
                        '***********************************************
                        Dim sIndex As String = L3Right(tdbg.Columns(e.Col).DataField, 2)
                        Dim bUse As Boolean = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP" & sIndex, "StageID = " & SQLString(tdbg(e.Row, COL_StageID))))
                        If Not bUse Then
                            e.CellStyle.Locked = True
                            e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                        End If
                End Select
            End If
        End If
        If _status = "1" Then
            If e.Row < _originalTotalRow Then
                e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            End If
        End If
    End Sub

    Private _originalTotalRow As Integer = 0
    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        Select Case tdbg.Col
            Case COL_TeamName
                LoadTeamID(tdbg(tdbg.Row, COL_DepartmentID).ToString)
            Case COL_DepartmentName
                If ReturnValueC1Combo(tdbcBlockID) <> "" Then
                    LoadtdbdDepartmentID(tdbdDepartmentID, dtdepartmentID, ReturnValueC1Combo(tdbcBlockID), gbUnicode)
                Else
                    LoadtdbdDepartmentID(tdbdDepartmentID, dtdepartmentID, "%", gbUnicode)
                End If

        End Select
        '**********************************
        If Number(tdbg(tdbg.Row, COL_PriceMethodID).ToString) = 0 Then
            tdbg.Height = iHeight
        Else
            tdbg.Height = iHeight - tdbg2.Height - 5 '255
        End If

        ' Set màu mặc định
        tdbg.HighLightRowStyle.BackColor = sColor
        'tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        tdbg2.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        tdbg2.HighLightRowStyle.BackColor = tdbg.HighLightRowStyle.BackColor
        If _status = "1" Then
            If tdbg.Row <= _originalTotalRow - 1 Then
                tdbg_LockRows(True)
            Else
                tdbg_LockRows(False)
            End If
        End If
        LoadTDBGrid2()
    End Sub

#End Region

    Private Sub CopyColumnsMy(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 Then Exit Sub

            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                        If c1Grid(i, COL_PriceMethodID).ToString <> "0" Or c1Grid(i, COL_PriceMethodID).ToString = "" Then
                        ElseIf chkIsStage.Checked Then
                            Select Case ColCopy
                                Case COL_UnitPrice01 To COL_UnitPrice05
                                    'Dim bUse As Boolean
                                    'bUse = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP01", "StageID = " & SQLString(tdbg(i, COL_StageID))))
                                    'If bUse Then c1Grid(i, ColCopy) = sValue
                                    '***********************************************
                                    Dim sIndex As String = L3Right(tdbg.Columns(ColCopy).DataField, 2)
                                    Dim bUse As Boolean = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP" & sIndex, "StageID = " & SQLString(tdbg(i, COL_StageID))))
                                    If bUse Then c1Grid(i, ColCopy) = sValue
                            End Select
                        Else
                            c1Grid(i, ColCopy) = sValue
                        End If
                    End If
                Next
            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, COL_PriceMethodID).ToString <> "0" Or c1Grid(i, COL_PriceMethodID).ToString = "" Then
                    ElseIf chkIsStage.Checked Then
                        Select Case ColCopy
                            Case COL_UnitPrice01
                                'Dim bUse As Boolean
                                'bUse = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP01", "StageID = " & SQLString(tdbg(i, COL_StageID))))
                                'If bUse Then c1Grid(i, ColCopy) = sValue
                                '***********************************************
                                Dim sIndex As String = L3Right(tdbg.Columns(ColCopy).DataField, 2)
                                Dim bUse As Boolean = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP" & sIndex, "StageID = " & SQLString(tdbg(i, COL_StageID))))
                                If bUse Then c1Grid(i, ColCopy) = sValue
                        End Select
                    Else
                        c1Grid(i, ColCopy) = sValue
                    End If
                Next
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CopyColumnsMyArr(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32, ByVal iColumns() As Integer)
        Try
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 Then Exit Sub

            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                        If c1Grid(i, COL_PriceMethodID).ToString <> "0" Or c1Grid(i, COL_PriceMethodID).ToString = "" Then
                        ElseIf chkIsStage.Checked Then
                            Select Case ColCopy
                                Case COL_UnitPrice01
                                    'Dim bUse As Boolean
                                    'bUse = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP01", "StageID = " & SQLString(tdbg(i, COL_StageID))))
                                    'If bUse Then c1Grid(i, ColCopy) = sValue
                                    '***********************************************
                                    Dim sIndex As String = L3Right(tdbg.Columns(ColCopy).DataField, 2)
                                    Dim bUse As Boolean = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP" & sIndex, "StageID = " & SQLString(tdbg(i, COL_StageID))))
                                    If bUse Then c1Grid(i, ColCopy) = sValue
                            End Select
                        Else
                            c1Grid(i, ColCopy) = sValue
                            For j As Integer = 0 To iColumns.Length - 1
                                c1Grid(i, iColumns(j)) = c1Grid(RowCopy, iColumns(j))
                            Next j
                        End If
                    End If
                Next
            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, COL_PriceMethodID).ToString <> "0" Or c1Grid(i, COL_PriceMethodID).ToString = "" Then
                    ElseIf chkIsStage.Checked Then
                        Select Case ColCopy
                            Case COL_UnitPrice01
                                'Dim bUse As Boolean
                                'bUse = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP01", "StageID = " & SQLString(tdbg(i, COL_StageID))))
                                'If bUse Then c1Grid(i, ColCopy) = sValue
                                '***********************************************
                                Dim sIndex As String = L3Right(tdbg.Columns(ColCopy).DataField, 2)
                                Dim bUse As Boolean = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP" & sIndex, "StageID = " & SQLString(tdbg(i, COL_StageID))))
                                If bUse Then c1Grid(i, ColCopy) = sValue
                        End Select
                    Else
                        c1Grid(i, ColCopy) = sValue
                        For j As Integer = 0 To iColumns.Length - 1
                            c1Grid(i, iColumns(j)) = c1Grid(RowCopy, iColumns(j))
                        Next j
                    End If
                Next
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

#Region "TDBG2"

    Private Sub tdbg2_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.AfterColUpdate
        If tdbg2.Row = 0 Then
            tdbg2.Columns(COL2_QtyFrom).Text = SQLNumber("0", DxxFormat.DefaultNumber2)
        Else
            tdbg2.Columns(COL2_QtyFrom).Text = SQLNumber(Number(tdbg2(tdbg2.Row - 1, COL2_QtyTo).ToString), DxxFormat.DefaultNumber2)
        End If
        tdbg2.Columns(COL2_OrderNo).Text = tdbg.Columns(COL_OrderNo).Text
        tdbg2.Columns(COL2_ProductID).Text = tdbg.Columns(COL_ProductID).Text
    End Sub

    Private Sub tdbg2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg2.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg2.Col
            Case COL2_QtyFrom, COL2_QtyTo
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL2_UnitPrice01, COL2_UnitPrice02, COL2_UnitPrice03, COL2_UnitPrice04, COL2_UnitPrice05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg2_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg2.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL2_QtyFrom, COL2_QtyTo
                If Not L3IsNumeric(tdbg2.Columns(e.ColIndex).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL2_UnitPrice01, COL2_UnitPrice02, COL2_UnitPrice03, COL2_UnitPrice04, COL2_UnitPrice05
                If Not L3IsNumeric(tdbg2.Columns(e.ColIndex).Text, EnumDataType.Number) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg2_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg2.FetchCellStyle
        If chkIsStage.Checked = False Then Exit Sub
        Select Case e.Col
            Case COL2_UnitPrice01
                Dim bUse As Boolean
                bUse = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP01", "StageID = " & SQLString(tdbg.Columns(COL_StageID).Value.ToString)))
                If Not bUse Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
            Case COL2_UnitPrice02
                Dim bUse As Boolean
                bUse = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP02", "StageID = " & SQLString(tdbg.Columns(COL_StageID).Value.ToString)))
                If Not bUse Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
            Case COL2_UnitPrice03
                Dim bUse As Boolean
                bUse = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP03", "StageID = " & SQLString(tdbg.Columns(COL_StageID).Value.ToString)))
                If Not bUse Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
            Case COL2_UnitPrice04
                Dim bUse As Boolean
                bUse = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP04", "StageID = " & SQLString(tdbg.Columns(COL_StageID).Value.ToString)))
                If Not bUse Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
            Case COL2_UnitPrice05
                Dim bUse As Boolean
                bUse = L3Bool(ReturnValueC1DropDown(tdbdStageID, "UP05", "StageID = " & SQLString(tdbg.Columns(COL_StageID).Value.ToString)))
                If Not bUse Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
        End Select
    End Sub

#End Region

    Private Sub c1dateDateFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles c1dateDateFrom.Validating
        LoadTDBGrid()
    End Sub

    Private Sub c1dateDateTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles c1dateDateTo.Validating
        LoadTDBGrid()
    End Sub

    Private Sub chkIsStage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsStage.Click
        tdbg.Splits(1).DisplayColumns(COL_StageName).Visible = chkIsStage.Checked
    End Sub

    Private Sub chkIsDepartment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsDepartment.Click
        tdbg.Splits(0).DisplayColumns(COL_DepartmentName).Visible = chkIsDepartment.Checked
        tdbg.Splits(0).DisplayColumns(COL_TeamName).Visible = chkIsDepartment.Checked
    End Sub

    Private Sub chkIsSpec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsSpec.Click
        For i As Integer = COL_Spec01Name To COL_Spec10Name
            tdbg.Splits(1).DisplayColumns(i).Visible = L3Bool(tdbg.Columns(i).Tag) AndAlso chkIsSpec.Checked
        Next
    End Sub

    Private Sub btnHotKeys_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHotKeys.Click
        Dim f As New D45F7777
        f.FormID = "D45F1021"
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim bExist As Boolean = False 'Cờ để tìm thấy k?
        '****************************
        Dim dt As DataTable = Nothing
        Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        tdbd = tdbg.Columns(tdbg.Col).DropDown
        If tdbd IsNot Nothing AndAlso tdbd.DisplayMember <> tdbd.ValueMember Then dt = CType(tdbd.DataSource, DataTable)
        '****************************
        For i As Integer = 0 To tdbg.RowCount - 1
            Dim sValue As String = tdbg(i, tdbg.Col).ToString
            '****************************
            If dt IsNot Nothing Then
                Dim dr() As DataRow = dt.Select(tdbd.ValueMember & "=" & SQLString(tdbg(i, tdbg.Col)))
                If dr.Length > 0 Then sValue = dr(0).Item(tdbd.DisplayMember).ToString
            End If
            '****************************
            'Dim iIndex As Integer = tdbg(i, tdbg.Col).ToString.ToUpper.IndexOf(txtEnter.Text.ToUpper)
            Dim iIndex As Integer = sValue.ToUpper.IndexOf(txtEnter.Text.ToUpper)
            If iIndex <> -1 Then '0: khi txtEnter.Text=Empty; -1: không tìm thấy
                bExist = True
                tdbg.Row = i
                tdbg.Focus()
                Exit For
            End If
        Next

        If bExist = False Then
            D99C0008.MsgL3(rL3("Khong_tim_thay_gia_tri_nao"))
            txtEnter.Focus()
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        txtPriceListID.Text = ""
        txtPriceListName.Text = ""
        txtNote.Text = ""
        btnSave.Enabled = True
        btnNext.Enabled = False
        dtPriceType = Nothing
        LoadAddNew()
        tdbg2.Delete(0, tdbg2.RowCount)
        tdbg.Height = iHeight
        txtPriceListID.Focus()
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Dim arrColObligatory() As Integer = {COL_ProductID, COL_PriceMethodName}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, , , gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)

        '       Dim frm As New D99F2222
        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
        'With frm
        '    .UseUnicode = gbUnicode
        '    .FormID = Me.Name
        '    .dtLoadGrid = dtCaptionCols
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtGrid 'Table load dữ liệu cho lưới
        '    .ShowDialog()
        '    .Dispose()
        'End With
    End Sub

    Private Sub LoadTDBGrid_Price()
        tdbg.UpdateData()
        btnCalcul.Enabled = False

        Dim sSQL As String = ""
        sSQL = "Select Convert(bit,0) as Choose, '' As StageID, 0.00 As UnitPrice01, 0.00 As UnitPrice02, 0.00 As UnitPrice03, 0.00 As UnitPrice04, 0.00 As UnitPrice05"
        dtPrice = ReturnDataTable(sSQL)
        If dtPrice IsNot Nothing Then dtPrice.Clear()
        '*********************************
        Dim dt As DataTable = dtGrid.DefaultView.ToTable
        Dim dr() As DataRow = dt.Select("ProductID = " & SQLString(tdbg.Columns(COL_ProductID).Text) & " And OrderNo < " & tdbg.Row + 1)
        For i As Integer = 0 To dr.Length - 1
            dtPrice.ImportRow(dr(i))
            dtPrice.Rows(i).Item("Choose") = 0
        Next
        '*********************************
        LoadDataSource(tdbgPrice, dtPrice, gbUnicode)
        FooterTotalGrid(tdbgPrice, COLP_StageID)
        Total()
    End Sub

    Private Sub Total()
        Dim dUnitPrice As Double = 0

        For i As Integer = COLP_UnitPrice01 To COLP_UnitPrice05
            dUnitPrice = Number(dtPrice.Compute("SUM(" & tdbgPrice.Columns(i).DataField & ")", "Choose = 1"))
            tdbgPrice.Columns(i).FooterText = SQLNumber(dUnitPrice, DxxFormat.DefaultNumber2)
        Next
        '********************************
        Dim dr() As DataRow = dtPrice.Select("Choose = 1")
        btnCalcul.Enabled = dr.Length > 0
    End Sub

#Region "tdbgPrice"

    Private Sub tdbgPrice_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgPrice.AfterColUpdate
        tdbgPrice.UpdateData()
        Total()
    End Sub

    Private Sub tdbgPrice_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbgPrice.UnboundColumnFetch
        e.Value = (e.Row + 1).ToString
    End Sub

    Private Sub tdbgPrice_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgPrice.HeadClick
        tdbgPrice.UpdateData()
        HeadClick(e.ColIndex)
    End Sub
#End Region

    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbgPrice.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COLP_Choose
                L3HeadClick(tdbgPrice, iCol, bSelect) 'Có trong D99X0000
                Total()
            Case Else
                tdbgPrice.AllowSort = True 'Nếu mặc định AllowSort = True
        End Select
    End Sub

    Private Sub ShowFramCalcule(ByVal bShow As Boolean)
        grpFrm.Visible = bShow
        If bShow Then
            grpFrm.BringToFront()
            LoadTDBGrid_Price()
            grpFrm.Focus()
            txtRate.Focus()
        Else
            tdbg.Focus()
        End If
    End Sub

    Private Sub btnCalcul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcul.Click
        If Number(txtRate.Text) = 0 Then
            D99C0008.MsgNotYetEnter(rL3("Ty_le"))
            txtRate.Focus()
        End If
        '*****************************
        Dim P1 As Double = 0, P2 As Double = 0, P3 As Double = 0, P4 As Double = 0, P5 As Double = 0, dbRate As Double = 0
        ' khai báo biến lưu giá trị của mã sản phẩm của dòng hiện tại
        Dim sCode As String = ""
        ' Lấy về các giá trị cho biến
        dbRate = Number(txtRate.Text) / 100

        P1 = Number(SQLNumber(tdbgPrice.Columns(COLP_UnitPrice01).FooterText, DxxFormat.DefaultNumber2))
        P2 = Number(SQLNumber(tdbgPrice.Columns(COLP_UnitPrice02).FooterText, DxxFormat.DefaultNumber2))
        P3 = Number(SQLNumber(tdbgPrice.Columns(COLP_UnitPrice03).FooterText, DxxFormat.DefaultNumber2))
        P4 = Number(SQLNumber(tdbgPrice.Columns(COLP_UnitPrice04).FooterText, DxxFormat.DefaultNumber2))
        P5 = Number(SQLNumber(tdbgPrice.Columns(COLP_UnitPrice05).FooterText, DxxFormat.DefaultNumber2))

        ' Gán lại giá các giá trị cho dòng hiện tại
        tdbg(tdbg.Row, COL_UnitPrice01) = P1 * dbRate
        tdbg(tdbg.Row, COL_UnitPrice02) = P2 * dbRate
        tdbg(tdbg.Row, COL_UnitPrice03) = P3 * dbRate
        tdbg(tdbg.Row, COL_UnitPrice04) = P4 * dbRate
        tdbg(tdbg.Row, COL_UnitPrice05) = P5 * dbRate
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        ShowFramCalcule(False)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg.UpdateData()
        tdbg2.UpdateData()
        SaveCurrentRow()
        If Not AllowSave() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        btnSave.Enabled = False
        btnClose.Enabled = False
        Dim sSQL As New StringBuilder("")
        _bSaved = False

        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD45T1020().ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1021s.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1024s)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD45T1020.ToString & vbCrLf)
                sSQL.Append(SQLDeleteD45T1021.ToString & vbCrLf)
                sSQL.Append(SQLInsertD45T1021s().ToString)
                sSQL.Append("Delete D45T1024 Where PriceListID = " & SQLString(txtPriceListID.Text) & vbCrLf)
                sSQL.Append(SQLInsertD45T1024s)
        End Select
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            _PriceListID = txtPriceListID.Text
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'RunAuditLog(AuditCodePriceLists, "02", txtPriceListID.Text, txtPriceListName.Text, c1dateDateFrom.Text, c1dateDateTo.Text)
                    Lemon3.D91.RunAuditLog("45", AuditCodePriceLists, "02", txtPriceListID.Text, txtPriceListName.Text, c1dateDateFrom.Text, c1dateDateTo.Text)
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        ' Set lại màu mặc định
        tdbg.HighLightRowStyle.BackColor = sColor
        'tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        tdbg2.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        tdbg2.HighLightRowStyle.BackColor = tdbg.HighLightRowStyle.BackColor


        If txtPriceListID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ma_bang_gia"))
            txtPriceListID.Focus()
            Return False
        End If
        If txtPriceListName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Dien_giai"))
            txtPriceListName.Focus()
            Return False
        End If

        If c1dateValidFrom.Enabled AndAlso c1dateValidFrom.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rL3("Hieu_luc_tu"))
            c1dateValidFrom.Focus()
            Return False
        End If

        If c1dateValidTo.Enabled Then
            If c1dateValidFrom.Text <> "" AndAlso c1dateValidTo.Text <> "" Then
                If CDate(c1dateValidFrom.Text) > CDate(c1dateValidTo.Text) Then
                    D99C0008.MsgL3(rL3("MSG000013")) 'Hiệu lực đến phải lớn hơn Hiệu lực từ
                    c1dateValidTo.Focus()
                    Return False
                End If
            End If

            If c1dateValidTo.Text <> "" Then
                If CDate(c1dateValidTo.Text) < Today.Date Then
                    D99C0008.MsgL3(rL3("Hieu_luc_den_phai_lon_hon_hoac_bang_ngay_hien_hanh")) 'Hiệu lực đến phải lớn hơn hoặc bằng ngày hiện hành
                    c1dateValidTo.Focus()
                    Return False
                End If
            End If
        End If

        Select Case L3String(tdbcBlockID.Tag)
            Case "W"
                If tdbcBlockID.Text.Trim = "" Then
                    If D99C0008.MsgAsk(rL3("Ban_chua_nhap_khoi_Ban_co_muon_tiep_tuc_luu_khong")) = Windows.Forms.DialogResult.No Then
                        tdbcBlockID.Focus()
                        Return False
                    Else
                        GoTo 1
                    End If
                End If
            Case "O"
                If tdbcBlockID.Text.Trim = "" Then
                    D99C0008.MsgNotYetEnter(lblBlockID.Text)
                    tdbcBlockID.Focus()
                    Return False
                End If
        End Select
1:
        '************************
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        ' Duyệt kiểm tra dữ liệu trên lưới
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_ProductID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ma_san_pham"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_ProductID
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If chkIsStage.Checked Then
                If tdbg(i, COL_StageID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Cong_doan"))
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_StageID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            End If
            If tdbg(i, COL_PriceMethodName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Loai gia"))
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_PriceMethodName
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If

            If Number(tdbg(i, COL_PriceMethodID).ToString) <> 0 And Not String.IsNullOrEmpty(tdbg(tdbg.Row, COL_PriceMethodName).ToString) Then
                Dim dt As DataTable
                dt = ReturnTableFilter(dtPriceType, "OrderNo = " & Number(tdbg(i, COL_OrderNo)), True)
                ' Nếu không có giá trị trên lưới Detail thì bắt buộc nhập trên lưới Detail
                If dt.Rows.Count = 0 Then
                    D99C0008.MsgNoDataInGrid()
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Focus()
                    tdbg.Col = COL_PriceMethodName
                    tdbg.Row = i
                    tdbg.Height = iHeight - tdbg2.Height - 5 '255

                    tdbg2.SplitIndex = SPLIT0
                    tdbg2.Focus()
                    tdbg2.Col = COL2_QtyTo
                    tdbg2.Row = 0
                    ' Set màu cho dòng bị lỗi trên lưới
                    tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                    tdbg.HighLightRowStyle.BackColor = Color.Green
                    tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                    tdbg.HighLightRowStyle.BackColor = Color.Green
                    Return False
                Else
                    ' Ngược lại kiểm tra dòng bị lỗi và set forcus cho dòng bị lỗi đó
                    For j As Integer = 0 To dt.Rows.Count - 1
                        If Number(dt.Rows(j).Item("QtyTo").ToString) = 0 Then
                            D99C0008.MsgNotYetEnter(rL3("So_luong"))
                            tdbg.SplitIndex = SPLIT1
                            tdbg.Col = COL_PriceMethodName
                            tdbg.Row = i
                            tdbg.Focus()
                            tdbg.Height = iHeight - tdbg2.Height - 5 '255

                            tdbg2.SplitIndex = SPLIT0
                            tdbg2.Focus()
                            tdbg2.Col = COL2_QtyTo
                            tdbg2.Row = j
                            ' Gán màu cho dòng bị lỗi
                            tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                            tdbg.HighLightRowStyle.BackColor = Color.Green
                            tdbg2.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                            tdbg2.HighLightRowStyle.BackColor = Color.Green
                            Return False
                        End If

                        If Number(dt.Rows(j).Item("QtyFrom").ToString) >= Number(dt.Rows(j).Item("QtyTo").ToString) Then
                            D99C0008.MsgL3(tdbg2.Columns(COL2_QtyFrom).Caption & Space(1) & rL3("phai_nho_hon") & Space(1) & tdbg2.Columns(COL2_QtyTo).Caption)
                            tdbg.SplitIndex = SPLIT1
                            tdbg.Col = COL_PriceMethodName
                            tdbg.Row = i
                            tdbg.Focus()
                            tdbg.Height = iHeight - tdbg2.Height - 5 '255

                            tdbg2.SplitIndex = SPLIT0
                            tdbg2.Focus()
                            tdbg2.Col = COL2_QtyTo
                            tdbg2.Row = j
                            ' Gán màu cho dòng bị lỗi
                            tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                            tdbg.HighLightRowStyle.BackColor = Color.Green
                            tdbg2.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                            tdbg2.HighLightRowStyle.BackColor = Color.Green
                            Return False
                        End If
                    Next
                End If
            End If
        Next
        '***************************
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D45T1020", "PriceListID", txtPriceListID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtPriceListID.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Function SQLInsertD45T1020() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D45T1020(")
        sSQL.Append("PriceListID, PriceListName, PriceListNameU, DateFrom, DateTo, ValidFrom, ValidTo, Note, NoteU, ")
        sSQL.Append("Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, Mode, IsSpec, IsDepartment,BlockID, IsCheckMachine")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtPriceListID.Text) & COMMA) 'PriceListID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtPriceListName.Text, gbUnicode, False) & COMMA) 'PriceListName, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtPriceListName.Text, gbUnicode, True) & COMMA) 'PriceListName, varchar[150], NOT NULL
        sSQL.Append(SQLDateSave(c1dateDateFrom.Value) & COMMA) 'DateFrom, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateDateTo.Value) & COMMA) 'DateTo, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateValidFrom.Value) & COMMA) 'ValidFrom, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateValidTo.Value) & COMMA) 'ValidTo, datetime, NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'Note, varchar[150], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'Note, varchar[150], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLNumber(Not chkIsStage.Checked) & COMMA) 'Mode, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkIsSpec.Checked) & COMMA) 'IsSpec, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkIsDepartment.Checked) & COMMA)
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA)
        sSQL.Append(SQLNumber(chkMachineID.Checked))
        sSQL.Append(")")

        Return sSQL
    End Function

    Private Function SQLInsertD45T1021s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sTransID As String = ""
        Dim nRowCountTransID As Integer = 0
        Dim iFirstIGETransID As Long

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                nRowCountTransID += 1
            End If
        Next
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                sTransID = CreateIGENewS("D45T1021", "TransID", "45", "PL", gsStringKey, sTransID, nRowCountTransID, iFirstIGETransID)
                tdbg(i, COL_TransID) = sTransID
            End If

            sSQL.Append("Insert Into D45T1021(")
            sSQL.Append("PriceListID, ProductID, StageID, UnitPriceType, UnitPrice01, ")
            sSQL.Append("UnitPrice02, UnitPrice03, UnitPrice04, UnitPrice05, DepartmentID, ")
            sSQL.Append("TeamID, Spec01ID, Spec02ID, Spec03ID, Spec04ID, Spec05ID, Spec06ID, ")
            sSQL.Append("Spec07ID, Spec08ID, Spec09ID, Spec10ID, PriceMethod, TransID,MachineID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtPriceListID.Text) & COMMA) 'PriceListID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ProductID)) & COMMA) 'ProductID [KEY], varchar[50], NOT NULL
            If chkIsStage.Checked Then
                sSQL.Append(SQLString(tdbg(i, COL_StageID)) & COMMA) 'StageID [KEY], varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'StageID [KEY], varchar[20], NOT NULL
            End If
            sSQL.Append(SQLNumber(0) & COMMA) 'UnitPriceType, tinyint, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice01), tdbg.Columns(COL_UnitPrice01).NumberFormat) & COMMA) 'UnitPrice01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice02), tdbg.Columns(COL_UnitPrice02).NumberFormat) & COMMA) 'UnitPrice02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice03), tdbg.Columns(COL_UnitPrice03).NumberFormat) & COMMA) 'UnitPrice03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice04), tdbg.Columns(COL_UnitPrice04).NumberFormat) & COMMA) 'UnitPrice04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice05), tdbg.Columns(COL_UnitPrice05).NumberFormat) & COMMA) 'UnitPrice05, decimal, NOT NULL
            If chkIsDepartment.Checked Then
                sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'DepartmentID, varchar[20], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'TeamID, varchar[20], NOT NULL
            End If

            If chkIsSpec.Checked Then
                sSQL.Append(SQLString(tdbg(i, COL_Spec01ID)) & COMMA) 'Spec01ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec02ID)) & COMMA) 'Spec02ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec03ID)) & COMMA) 'Spec03ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec04ID)) & COMMA) 'Spec04ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec05ID)) & COMMA) 'Spec05ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec06ID)) & COMMA) 'Spec06ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec07ID)) & COMMA) 'Spec07ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec08ID)) & COMMA) 'Spec08ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec09ID)) & COMMA) 'Spec09ID, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_Spec10ID)) & COMMA) 'Spec10ID, varchar[50], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'Spec01ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec02ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec03ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec04ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec05ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec06ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec07ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec08ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec09ID, varchar[50], NOT NULL
                sSQL.Append(SQLString("") & COMMA) 'Spec10ID, varchar[50], NOT NULL
            End If

            sSQL.Append(SQLNumber(tdbg(i, COL_PriceMethodID)) & COMMA) 'PriceMethod, tinyint, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_MachineID))) 'MachineID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Function SQLUpdateD45T1020() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T1020 Set ")
        sSQL.Append("PriceListName = " & SQLStringUnicode(txtPriceListName.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("PriceListNameU = " & SQLStringUnicode(txtPriceListName.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("DateFrom = " & SQLDateSave(c1dateDateFrom.Value) & COMMA) 'datetime, NULL
        sSQL.Append("DateTo = " & SQLDateSave(c1dateDateTo.Value) & COMMA) 'datetime, NULL
        sSQL.Append("ValidFrom = " & SQLDateSave(c1dateValidFrom.Value) & COMMA) 'datetime, NULL
        sSQL.Append("ValidTo = " & SQLDateSave(c1dateValidTo.Value) & COMMA) 'datetime, NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA) 'varchar[150], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("Mode = " & SQLNumber(Not chkIsStage.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("IsSpec = " & SQLNumber(chkIsSpec.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("IsDepartment = " & SQLNumber(chkIsDepartment.Checked) & COMMA)
        sSQL.Append("BlockID  = " & SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA)
        sSQL.Append("IsCheckMachine   = " & SQLNumber(chkMachineID.Checked))
        sSQL.Append(" Where ")
        sSQL.Append("PriceListID = " & SQLString(txtPriceListID.Text))

        Return sSQL
    End Function

    Private Function SQLDeleteD45T1021() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T1021"
        sSQL &= " Where "
        sSQL &= "PriceListID = " & SQLString(txtPriceListID.Text)
        Return sSQL
    End Function

    Private Function SQLStoreD45P1020() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P1020 "
        sSQL &= SQLString(txtPriceListID.Text) & COMMA 'PriceListID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString("") & COMMA 'ProductID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= "N" & SQLString("") & COMMA 'ProductName, varchar[150], NOT NULL
        sSQL &= SQLString("") & COMMA 'AnaCategoryID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'AnaID, varchar[20], NOT NULL
        sSQL &= SQLNumber(Not chkIsStage.Checked) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P0066
    '# Created User: KIMLONG
    '# Created Date: 07/10/2016 12:36:48
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD91P0066() As String
        Dim sSQL As String = ""
        sSQL &= ("-- -- Kiem tra bat buoc nhap combo Khoi: BlockID" & vbCrLf)
        sSQL &= "Exec D91P0066 "
        sSQL &= SQLString("45") & COMMA 'ModuleID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("D45F1020") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) 'CheckMode, tinyint, NOT NULL
        Return sSQL
    End Function



    Private Function SQLInsertD45T1024s() As StringBuilder
        Dim dtTmp1 As DataTable = CType(tdbg.DataSource, DataTable)
        Dim dtTmp2 As DataTable
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To dtPriceType.Rows.Count - 1
            dtTmp2 = ReturnTableFilter(dtTmp1, "ProductID = " & SQLString(dtPriceType.Rows(i).Item("ProductID").ToString) & " And OrderNo = " & dtPriceType.Rows(i).Item("OrderNo").ToString, True)
            sSQL.Append("Insert Into D45T1024(")
            sSQL.Append("TransID, PriceListID, ProductID, QtyFrom, ")
            sSQL.Append("QtyTo, UnitPrice01, UnitPrice02, UnitPrice03, UnitPrice04, ")
            sSQL.Append("UnitPrice05")
            sSQL.Append(") Values(")
            If dtTmp2.Rows.Count > 0 Then
                sSQL.Append(SQLString(dtTmp2.Rows(0).Item("TransID").ToString) & COMMA) 'TransID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString("") & COMMA) 'TransID, varchar[20], NOT NULL
            End If
            sSQL.Append(SQLString(txtPriceListID.Text) & COMMA) 'PriceListID, varchar[20], NOT NULL
            sSQL.Append(SQLString(dtPriceType.Rows(i).Item("ProductID").ToString) & COMMA) 'ProductID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(dtPriceType.Rows(i).Item("QtyFrom").ToString, DxxFormat.DefaultNumber2) & COMMA) 'QtyFrom, decimal, NOT NULL
            sSQL.Append(SQLMoney(dtPriceType.Rows(i).Item("QtyTo").ToString, DxxFormat.DefaultNumber2) & COMMA) 'QtyTo, decimal, NOT NULL
            sSQL.Append(SQLMoney(dtPriceType.Rows(i).Item("UnitPrice01").ToString, tdbg.Columns(COL_UnitPrice01).NumberFormat) & COMMA) 'UnitPrice01, decimal, NOT NULL
            sSQL.Append(SQLMoney(dtPriceType.Rows(i).Item("UnitPrice02").ToString, tdbg.Columns(COL_UnitPrice02).NumberFormat) & COMMA) 'UnitPrice02, decimal, NOT NULL
            sSQL.Append(SQLMoney(dtPriceType.Rows(i).Item("UnitPrice03").ToString, tdbg.Columns(COL_UnitPrice03).NumberFormat) & COMMA) 'UnitPrice03, decimal, NOT NULL
            sSQL.Append(SQLMoney(dtPriceType.Rows(i).Item("UnitPrice04").ToString, tdbg.Columns(COL_UnitPrice04).NumberFormat) & COMMA) 'UnitPrice04, decimal, NOT NULL
            sSQL.Append(SQLMoney(dtPriceType.Rows(i).Item("UnitPrice05").ToString, tdbg.Columns(COL_UnitPrice05).NumberFormat)) 'UnitPrice05, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    Private Sub LoadFormatC()
        Dim sSQL As String = ""
        sSQL = " -- Lay thiet lap dinh dang so le" & vbCrLf
        sSQL &= " SELECT  Decimals,Code "
        sSQL &= " FROM 		D45T0010 WITH(NOLOCK) "
        sSQL &= " WHERE 		Type = 'Price' "
        sSQL &= " ORDER BY 	Code"
        dtFormat = ReturnDataTable(sSQL)
    End Sub

    Private Function CheckEnableBlockID() As Boolean
        Dim dtCheck As DataTable = ReturnDataTable(SQLStoreD91P0066())
        If dtCheck.Rows.Count > 0 Then
            Dim dr() As DataRow = dtCheck.Select("SqlFieldName='BlockID'")
            If dr.Length > 0 Then
                Select Case L3String(dr(0)("ValidMode"))
                    Case "O"
                        tdbcBlockID.Tag = L3String(dr(0)("ValidMode"))
                        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
                        Return True
                    Case "W"
                        tdbcBlockID.Tag = L3String(dr(0)("ValidMode"))
                        Return True
                    Case Else
                        Return False
                End Select
            End If
        End If
        Return False
    End Function

    Private Sub chkMachineID_CheckedChanged(sender As Object, e As EventArgs) Handles chkMachineID.CheckedChanged
        tdbg.Splits(0).DisplayColumns(COL_MachineID).Visible = chkMachineID.Checked
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcBlockID.SelectedValueChanged
        Select Case tdbg.Col
            Case COL_TeamName
                LoadTeamID(tdbg(tdbg.Row, COL_DepartmentID).ToString)
            Case COL_DepartmentName
                If ReturnValueC1Combo(tdbcBlockID) <> "" Then
                    LoadtdbdDepartmentID(tdbdDepartmentID, dtdepartmentID, ReturnValueC1Combo(tdbcBlockID), gbUnicode)
                Else
                    LoadtdbdDepartmentID(tdbdDepartmentID, dtdepartmentID, "%", gbUnicode)
                End If

        End Select
    End Sub
    Private Sub tdbg_LockRows(Optional ByVal bLock As Boolean = False)
        tdbg.AllowDelete = Not bLock
        tdbg.AllowUpdate = Not bLock
        If bLock = False Then
            tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        End If
        For Each _spit As C1.Win.C1TrueDBGrid.Split In tdbg.Splits
            For Each _displayCol As C1.Win.C1TrueDBGrid.C1DisplayColumn In _spit.DisplayColumns
                _displayCol.Locked = bLock
            Next
        Next
    End Sub

    Private Sub tdbg_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If _status = "1" Then
            If e.Row < _originalTotalRow Then
                e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            End If
        End If
    End Sub


End Class