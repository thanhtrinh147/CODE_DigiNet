Imports System
Public Class D45F1022
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0      ' TransID
    Private Const COL_OrderNo As Integer = 1      ' STT
    Private Const COL_ProductID As Integer = 2    ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 3  ' Tên sản phẩm
    Private Const COL_OProductName As Integer = 4 ' OProductName
    Private Const COL_DepartmentID As Integer = 5 ' Phòng ban
    Private Const COL_TeamID As Integer = 6       ' TeamID
    Private Const COL_TeamName As Integer = 7     ' Tổ nhóm
    Private Const COL_StageID As Integer = 8      ' StageID
    Private Const COL_StageName As Integer = 9    ' Công đoạn
    Private Const COL_PriceMethod As Integer = 10 ' Loại giá
    Private Const COL_Spec01ID As Integer = 11    ' Spec01ID
    Private Const COL_Spec02ID As Integer = 12    ' Spec02ID
    Private Const COL_Spec03ID As Integer = 13    ' Spec03ID
    Private Const COL_Spec04ID As Integer = 14    ' Spec04ID
    Private Const COL_Spec05ID As Integer = 15    ' Spec05ID
    Private Const COL_Spec06ID As Integer = 16    ' Spec06ID
    Private Const COL_Spec07ID As Integer = 17    ' Spec07ID
    Private Const COL_Spec08ID As Integer = 18    ' Spec08ID
    Private Const COL_Spec09ID As Integer = 19    ' Spec09ID
    Private Const COL_Spec10ID As Integer = 20    ' Spec10ID
    Private Const COL_UnitPrice01 As Integer = 21 ' UnitPrice01
    Private Const COL_UnitPrice02 As Integer = 22 ' UnitPrice02
    Private Const COL_UnitPrice03 As Integer = 23 ' UnitPrice03
    Private Const COL_UnitPrice04 As Integer = 24 ' UnitPrice04
    Private Const COL_UnitPrice05 As Integer = 25 ' UnitPrice05
#End Region

    Dim dtTeamID, dtStageID, dtAnaID As DataTable
    Dim iColLast As Integer = COL_PriceMethod 'Cột cuối cùng hiển thị
    Private Const COL_Total As Integer = 14

    Private sFindServer As String = ""
    Public WriteOnly Property strNewServer() As String
        Set(ByVal Value As String)
            sFindServer = Value
        End Set
    End Property


#Region "Parameters from D45F1020"

    Private _priceListID As String = ""
    Public WriteOnly Property PriceListID() As String
        Set(ByVal Value As String)
            _priceListID = Value
        End Set
    End Property

    Private _priceListName As String = ""
    Public WriteOnly Property PriceListName() As String
        Set(ByVal Value As String)
            _priceListName = Value
        End Set
    End Property

    Private _dateFrom As String = ""
    Public WriteOnly Property DateFrom() As String
        Set(ByVal Value As String)
            _dateFrom = Value
        End Set
    End Property

    Private _dateTo As String = ""
    Public WriteOnly Property DateTo() As String
        Set(ByVal Value As String)
            _dateTo = Value
        End Set
    End Property

    Private _mode As String
    Public WriteOnly Property Mode() As String
        Set(ByVal Value As String)
            _mode = Value
        End Set
    End Property
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                Case EnumFormState.FormView
                    btnSave.Enabled = False
            End Select
        End Set
    End Property


    Private Sub D45F1022_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.F1 Then
            btnHotKey_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D45F1022_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        _bSaved = False
        SetShortcutPopupMenu(C1CommandHolder)
        Loadlanguage()
        LoadTDBGridSpecificationCaption(tdbg, COL_Spec01ID, 1, False, gbUnicode)
        LoadTDBCombo()
        LoadTDBDropDown()
        LoadTableCaptionPrice()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtProductID)
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        ResetFooterGrid(tdbg, 0, 1)
        ResetSplitDividerSize(tdbg)
        '****************************
        If D45Options.UseEnterMoveDown Then tdbg.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
        '****************************
        txtPriceListID.Text = _priceListID
        txtPriceListName.Text = _priceListName
        '****************************
        mnuFind.Enabled = gbEnabledUseFind Or tdbg.RowCount > 0
        mnuListAll.Enabled = gbEnabledUseFind Or tdbg.RowCount > 0
        '****************************
        Dim dtTmp As DataTable
        dtTmp = ReturnDataTable("Select Mode, IsDepartment From D45T1020  WITH(NOLOCK) Where PriceListID = " & SQLString(_priceListID))
        If dtTmp.Rows.Count > 0 Then
            tdbg.Splits(1).DisplayColumns(COL_Stagename).Visible = Not L3Bool(dtTmp.Rows(0).Item("Mode").ToString)
            tdbg.Splits(0).DisplayColumns(COL_DepartmentID).Visible = L3Bool(dtTmp.Rows(0).Item("IsDepartment").ToString)
            tdbg.Splits(0).DisplayColumns(COL_TeamName).Visible = L3Bool(dtTmp.Rows(0).Item("IsDepartment").ToString)
        End If
        tdbg.Splits(1).DisplayColumns(COL_UnitPrice01).FetchStyle = True
        tdbg.Splits(1).DisplayColumns(COL_UnitPrice02).FetchStyle = True
        tdbg.Splits(1).DisplayColumns(COL_UnitPrice03).FetchStyle = True
        tdbg.Splits(1).DisplayColumns(COL_UnitPrice04).FetchStyle = True
        tdbg.Splits(1).DisplayColumns(COL_UnitPrice05).FetchStyle = True
        tdbcNameAutoComplete()
        '****************************
        SetResolutionForm(Me, C1ContextMenu)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_chi_tiet_bang_gia_-_D45F1022") & UnicodeCaption(gbUnicode) 'CËp nhËt chi tiÕt b¶ng giÀ - D45F1022
        '================================================================ 
        lblPriceListID.Text = rl3("Bang_gia") 'Bảng giá
        lblProductID.Text = rl3("Ma_san_pham") & Space(1) & rl3("co_chuaU")  'Mã sản phẩm có chứa
        lblProductName.Text = rl3("Ten_san_pham") & Space(1) & rl3("co_chuaU")
        lblAnaCategoryID.Text = rl3("Loai_ma_phan_tich")
        lblAnaID.Text = rl3("Ma_phan_tich")
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnHotKey.Text = rl3("Phim_nong") 'Phím nóng
        btnFilter.Text = rl3("Lo_c") 'Lọ&c
        '================================================================ 
        tdbg.Columns("OrderNo").Caption = rl3("STT") 'STT
        tdbg.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Diễn giải
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban")
        tdbg.Columns("TeamName").Caption = rl3("To_nhom")
        tdbg.Columns("StageName").Caption = rl3("Cong_doan")
        tdbg.Columns("PriceMethod").Caption = rl3("Loai_gia")
        '================================================================ 
        tdbdDepartmentID.Columns("DepartmentID").Caption = rl3("Ma")
        tdbdDepartmentID.Columns("DepartmentName").Caption = rl3("Ten")
        tdbdTeamID.Columns("TeamID").Caption = rl3("Ma")
        tdbdTeamID.Columns("TeamName").Caption = rl3("Ten")
        tdbdPriceMethod.Columns("PriceMethod").Caption = rl3("Ma")
        tdbdPriceMethod.Columns("PriceMethodName").Caption = rl3("Ten")
        tdbcAnaCategoryID.Columns("AnaCategoryShort").Caption = rl3("Ma")
        tdbcAnaCategoryID.Columns("AnaCategoryName").Caption = rl3("Ten")
        tdbcAnaID.Columns("AnaID").Caption = rl3("Ma")
        tdbcAnaID.Columns("AnaName").Caption = rl3("Ten")
        tdbdSpec01ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec01ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec02ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec02ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec03ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec03ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec04ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec04ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec05ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec05ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec06ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec06ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec07ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec07ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec08ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec08ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec09ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec09ID.Columns("SpecName").Caption = rl3("Ten")
        tdbdSpec10ID.Columns("SpecID").Caption = rl3("Ma")
        tdbdSpec10ID.Columns("SpecName").Caption = rl3("Ten")
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProductID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_StageName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_OrderNo).NumberFormat = DxxFormat.DefaultNumber0
        tdbg.Columns(COL_UnitPrice01).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice03).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice04).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_UnitPrice05).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcAnaID
        sSQL = "Select D50.AnaCategoryID, D51.AnaID, D51.AnaName" & UnicodeJoin(gbUnicode) & " as  AnaName" & vbCrLf
        sSQL &= "From D91T0051 D51  WITH(NOLOCK) Inner Join D91T0050 D50  WITH(NOLOCK) On D51.AnaCategoryID = D50.AnaCategoryID" & vbCrLf
        sSQL &= "Where Disabled=0 And D50.AnaTypeID='M'" & vbCrLf
        sSQL &= "Order by D50.AnaCategoryID, D51.AnaID"
        dtAnaID = ReturnDataTable(sSQL)
        LoadTDBCAnaID()

        'Load tdbcAnaCategoryID
        sSQL = "Select D91.AnaCategoryID, D91.AnaCategoryShort" & UnicodeJoin(gbUnicode) & " as AnaCategoryShort, D91.AnaCategoryName" & UnicodeJoin(gbUnicode) & " as AnaCategoryName, D91.AnaCategoryStatus, D91.UseD45 " & vbCrLf
        sSQL &= "From D91T0050 D91 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where D91.AnaTypeId='M' And D91.AnaCategoryStatus=1" & vbCrLf
        sSQL &= "Order by D91.AnaCategoryID"
        LoadDataSource(tdbcAnaCategoryID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBCAnaID()
        Dim sAnaCategoryID As String = ""

        If tdbcAnaCategoryID.SelectedValue Is Nothing Then
            sAnaCategoryID = ""
        Else
            sAnaCategoryID = tdbcAnaCategoryID.SelectedValue.ToString
        End If

        LoadDataSource(tdbcAnaID, ReturnTableFilter(dtAnaID, "AnaCategoryID=" & SQLString(sAnaCategoryID), True), gbUnicode)
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
        Next
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdDepartmentID
        dtTeamID = ReturnTableTeamID(True, False, gbUnicode)
        Dim dtDepartmentID As DataTable = ReturnTableDepartmentID(True, False, gbUnicode)
        LoadDataSource(tdbdDepartmentID, dtDepartmentID, gbUnicode)

        'Load tdbdPriceMethod
        sSQL = "Select PriceMethod, PriceMethodName" & UnicodeJoin(gbUnicode) & " As PriceMethodName "
        sSQL &= "From D45V1022 Where Language = " & SQLString(gsLanguage) & " Order By PriceMethod"
        LoadDataSource(tdbdPriceMethod, sSQL, gbUnicode)

        'Load tdbdStageID
        '15/11/2012 IncidentID	52403
        sSQL = "-- Do nguon cho dropdowm cong doan " & vbCrLf
        sSQL &= "SELECT	'*' AS StageID," & IIf(gbUnicode, "N'*(" & rl3("Khong_phu_thuoc_cong_doan") & ")'", ConvertUnicodeToVni("N'*(" & rl3("Khong_phu_thuoc_cong_doan") & ")'")).ToString & " AS StageName,1 AS UP01, 1 AS UP02, 1 AS UP03, 1 AS UP04, 1 AS UP05, 0 AS DisplayOrder ,0 AS DisOrder" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT StageID, StageName" & UnicodeJoin(gbUnicode) & " As StageName, UP01, UP02, UP03, UP04, UP05, DisplayOrder, 1 AS DisOrder" & vbCrLf
        sSQL &= "FROM D45T1010 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY DisOrder,DisplayOrder"
        dtStageID = ReturnDataTable(sSQL)

        'Load 10 quy cách
        LoadTDBDropDownSpecification(tdbdSpec01ID, tdbdSpec02ID, tdbdSpec03ID, tdbdSpec04ID, tdbdSpec05ID, tdbdSpec06ID, tdbdSpec07ID, tdbdSpec08ID, tdbdSpec09ID, tdbdSpec10ID, tdbg, COL_Spec01ID, gbUnicode)
    End Sub

    Private Sub LoadTermID(ByVal sDepartmentID As String)
        LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID, "DepartmentID = " & SQLString(sDepartmentID), True), gbUnicode)
    End Sub

    Private Sub LoadTDBGridSpecificationCaption(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal COL_Spec01ID As Integer, ByVal Split As Integer, Optional ByVal IsVisibleColumn As Boolean = False, Optional ByVal bUnicode As Boolean = False)
        Dim bUseSpec As Boolean = False

        Dim sSQL As String = "Select SpecTypeID, Caption" & UnicodeJoin(bUnicode) & " as Caption, IsD45, Disabled From D07T0410  WITH(NOLOCK) Order by SpecTypeID"
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
                tdbg.Splits(Split).DisplayColumns(iIndex).HeadingStyle.Font = FontUnicode(bUnicode, tdbg.Splits(Split).DisplayColumns(iIndex).HeadingStyle.Font.Style) 'New System.Drawing.Font("Lemon3", 8.249999!)

                iIndex += 1
            Next
        End If
        dt = Nothing
    End Sub

    Private Function SQLStoreD45P1020() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P1020 "
        sSQL &= SQLString(txtPriceListID.Text) & COMMA 'PriceListID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(_dateFrom) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(_dateTo) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(txtProductID.Text) & COMMA 'ProductID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(sFindServer) & COMMA 'WhereClause, varchar[8000], NOT NULL
        sSQL &= "N" & SQLString(txtProductName.Text) & COMMA 'ProductName, varchar[150], NOT NULL
        If tdbcAnaCategoryID.SelectedValue Is Nothing OrElse tdbcAnaCategoryID.Text = "" Then
            sSQL &= SQLString("") & COMMA 'AnaCategoryID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(tdbcAnaCategoryID.SelectedValue.ToString) & COMMA 'AnaCategoryID, varchar[20], NOT NULL
        End If
        If tdbcAnaCategoryID.SelectedValue Is Nothing OrElse tdbcAnaID.Text = "" Then
            sSQL &= SQLString("") & COMMA 'AnaID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(tdbcAnaID.SelectedValue.ToString) & COMMA 'AnaID, varchar[20], NOT NULL
        End If
        sSQL &= SQLNumber(_mode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P1020()
        Dim dt As DataTable = ReturnDataTable(sSQL)

        LoadDataSource(tdbg, sSQL, gbUnicode)
        mnuFind.Enabled = gbEnabledUseFind Or tdbg.RowCount > 0
        mnuListAll.Enabled = gbEnabledUseFind Or tdbg.RowCount > 0
        UpdateTDBGOrderNum(tdbg, COL_OrderNo)
        FooterTotalGrid(tdbg, COL_ProductID)
        '*************************************
        If dt.Rows.Count > 0 Then
            For i As Integer = COL_Spec01ID To COL_Spec10ID
                tdbg.Splits(1).DisplayColumns(i).Visible = Convert.ToBoolean(tdbg.Columns(i).Tag) AndAlso L3Bool(dt.Rows(0).Item("IsSpec").ToString)
            Next
        Else
            For i As Integer = COL_Spec01ID To COL_Spec10ID
                tdbg.Splits(1).DisplayColumns(i).Visible = False
            Next
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function SQLDeleteD45T1021(ByVal sAllProductID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D45T1021"
        sSQL &= " Where "
        sSQL &= "PriceListID = " & SQLString(txtPriceListID.Text) & " And "
        sSQL &= "ProductID In (" & sAllProductID & ")"
        Return sSQL
    End Function

    Private Function SQLInsertD45T1021s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
       
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Delete From D45T1021 Where PriceListID = " & SQLString(txtPriceListID.Text))
            sSQL.Append(" And TransID = " & SQLString(tdbg(i, COL_TransID)) & vbCrLf)
            sSQL.Append("Insert Into D45T1021(")
            sSQL.Append("PriceListID, ProductID, StageID, UnitPriceType, UnitPrice01, ")
            sSQL.Append("UnitPrice02, UnitPrice03, UnitPrice04, UnitPrice05, DepartmentID, ")
            sSQL.Append("TeamID, Spec01ID, Spec02ID, Spec03ID, Spec04ID, Spec05ID, Spec06ID, ")
            sSQL.Append("Spec07ID, Spec08ID, Spec09ID, Spec10ID, PriceMethod, TransID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtPriceListID.Text) & COMMA) 'PriceListID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ProductID)) & COMMA) 'ProductID [KEY], varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_StageID)) & COMMA) 'StageID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLNumber(0) & COMMA) 'UnitPriceType, tinyint, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice01)) & COMMA) 'UnitPrice01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice02)) & COMMA) 'UnitPrice02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice03)) & COMMA) 'UnitPrice03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice04)) & COMMA) 'UnitPrice04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice05)) & COMMA) 'UnitPrice05, decimal, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
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
            sSQL.Append(SQLNumber(tdbg(i, COL_PriceMethod)) & COMMA) 'PriceMethod, tinyint, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID))) 'TransID, varchar[20], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        btnSave.Enabled = False
        btnClose.Enabled = False
        Dim sSQL As New StringBuilder

        ssql.Append(SQLUpdateD45T1020.ToString & vbCrLf)
        sSQL.Append(SQLInsertD45T1021s.ToString)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            'RunAuditLog(AuditCodePriceLists, "02", txtPriceListID.Text, txtPriceListName.Text, _dateFrom, _dateTo)
            Lemon3.D91.RunAuditLog("45", AuditCodePriceLists, "02", txtPriceListID.Text, txtPriceListName.Text, _dateFrom, _dateTo)
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnSave.Focus()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnHotKey_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHotKey.Click
        Dim f As New D45F7777
        f.FormID = "D45F1022"
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Function SQLUpdateD45T1020() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D45T1020 Set ")
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("PriceListID = " & SQLString(txtPriceListID.Text))

        Return sSQL
    End Function

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Me.Cursor = Cursors.WaitCursor
        sFind = ""
        sFindServer = ""
        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

#Region "Active Find Client - List All "

    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
	'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
            LoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    'Dim dtCaptionCols As DataTable

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , False, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClientServer(Finder, dtCaptionCols, Me.Name, "0", gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClauseClient As Object, ByVal ResultWhereClauseServer As Object) Handles Finder.FindReportClick
    '    If ResultWhereClauseClient Is Nothing Or ResultWhereClauseClient.ToString = "" Then Exit Sub
    '    gbEnabledUseFind = True
    '    sFind = ResultWhereClauseClient.ToString()
    '    sFindServer = ResultWhereClauseServer.ToString()
    '    LoadTDBGrid()
    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        sFindServer = ""
        sFind = ""
        LoadTDBGrid()
    End Sub

#End Region

#Region "Events tdbcAnaCategoryID"

    Private Sub tdbcAnaCategoryID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAnaCategoryID.SelectedValueChanged
        LoadTDBCAnaID()
        tdbcAnaID.SelectedIndex = 0
    End Sub

#End Region

#Region "53.	Sửa lỗi gõ tên trên combo hay dropdown"

    Private Sub tdbcNameAutoComplete()
        tdbcAnaCategoryID.AutoCompletion = False
        tdbcAnaID.AutoCompletion = False
    End Sub

    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAnaCategoryID.LostFocus, tdbcAnaID.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAnaCategoryID.Close, tdbcAnaID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAnaCategoryID.Validated, tdbcAnaID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region


#Region "TDBG"

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_DepartmentID
                If tdbg.Columns(COL_DepartmentID).Text <> tdbdDepartmentID.Columns(tdbdDepartmentID.DisplayMember).Text Then
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                    bNotInList = True
                End If
            Case COL_TeamName
                If tdbg.Columns(COL_TeamName).Text <> tdbdTeamID.Columns(tdbdTeamID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_PriceMethod
                If tdbg.Columns(COL_PriceMethod).Text <> tdbdPriceMethod.Columns(tdbdPriceMethod.DisplayMember).Text Then
                    bNotInList = True
                End If
         
            Case COL_Spec01ID
                If tdbg.Columns(COL_Spec01ID).Text <> tdbdSpec01ID.Columns(tdbdSpec01ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec02ID
                If tdbg.Columns(COL_Spec02ID).Text <> tdbdSpec02ID.Columns(tdbdSpec02ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec03ID
                If tdbg.Columns(COL_Spec03ID).Text <> tdbdSpec03ID.Columns(tdbdSpec03ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec04ID
                If tdbg.Columns(COL_Spec04ID).Text <> tdbdSpec04ID.Columns(tdbdSpec04ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec05ID
                If tdbg.Columns(COL_Spec05ID).Text <> tdbdSpec05ID.Columns(tdbdSpec05ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec06ID
                If tdbg.Columns(COL_Spec06ID).Text <> tdbdSpec06ID.Columns(tdbdSpec06ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec07ID
                If tdbg.Columns(COL_Spec07ID).Text <> tdbdSpec07ID.Columns(tdbdSpec07ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec08ID
                If tdbg.Columns(COL_Spec08ID).Text <> tdbdSpec08ID.Columns(tdbdSpec08ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec09ID
                If tdbg.Columns(COL_Spec09ID).Text <> tdbdSpec09ID.Columns(tdbdSpec09ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_Spec10ID
                If tdbg.Columns(COL_Spec10ID).Text <> tdbdSpec10ID.Columns(tdbdSpec10ID.DisplayMember).Text Then
                    bNotInList = True
                End If
            Case COL_UnitPrice01
                If Not L3IsNumeric(tdbg.Columns(COL_UnitPrice01).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_UnitPrice02
                If Not L3IsNumeric(tdbg.Columns(COL_UnitPrice02).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_UnitPrice03
                If Not L3IsNumeric(tdbg.Columns(COL_UnitPrice03).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_UnitPrice04
                If Not L3IsNumeric(tdbg.Columns(COL_UnitPrice04).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_UnitPrice05
                If Not L3IsNumeric(tdbg.Columns(COL_UnitPrice05).Text, EnumDataType.Number) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_OrderNo
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_UnitPrice01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_UnitPrice02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_UnitPrice03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_UnitPrice04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_UnitPrice05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.F3 Then
            If tdbg(tdbg.Row, COL_PriceMethod).ToString <> "0" Then
                Dim frm As New D45F1024
                With frm
                    .PriceListID = _priceListID
                    .ProductID = tdbg.Columns(COL_ProductID).Text
                    .sProductName = tdbg.Columns(COL_ProductName).Text
                    .PriceMethod = tdbg.Columns(COL_PriceMethod).Text
                    .TransID = tdbg.Columns(COL_TransID).Text
                    .StageID = tdbg.Columns(COL_StageID).Text
                    .ShowDialog()
                    .Dispose()
                End With
            End If
        ElseIf e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbg)
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            HeadClick_tdbg(tdbg.Col)
        ElseIf e.KeyCode = Keys.Enter And tdbg.Col = iColLast Then
            If D45Options.UseEnterMoveDown Then Exit Sub
            HotKeyEnterGrid(tdbg, COL_Total, e, 1)
        End If
        HotKeyDownGrid(e, tdbg, COL_Total, 1, 1)
    End Sub

    Dim bNotInList As Boolean
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán
        Select Case e.ColIndex
            Case COL_DepartmentID
                If bNotInList Then
                    bNotInList = False
                    tdbg.Columns(COL_DepartmentID).Text = ""
                End If
            Case COL_TeamName
                If bNotInList Then
                    bNotInList = False
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                End If
            Case COL_PriceMethod
                If bNotInList Then
                    bNotInList = False
                    tdbg.Columns(COL_PriceMethod).Text = ""
                End If
            Case COL_Spec01ID, COL_Spec02ID, COL_Spec03ID, COL_Spec04ID, COL_Spec05ID
                If bNotInList Then
                    bNotInList = False
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
                CalculatorProductNameFromSpec()
            Case COL_Spec06ID, COL_Spec07ID, COL_Spec08ID, COL_Spec09ID, COL_Spec10ID
                If bNotInList Then
                    bNotInList = False
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
                CalculatorProductNameFromSpec()
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        '--- Gán giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_TeamName
                tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns("TeamID").Text
            Case COL_PriceMethod

            Case COL_DepartmentID
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_TeamName
                LoadTermID(tdbg.Columns(COL_DepartmentID).Value.ToString)
        End Select
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        If tdbg(e.Row, COL_PriceMethod).ToString <> "0" Or tdbg(e.Row, COL_PriceMethod).ToString = "" Then
            e.CellStyle.Locked = True
            e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        ElseIf tdbg.Splits(1).DisplayColumns(COL_StageName).Visible Then
            Dim dt As DataTable = dtStageID.DefaultView.ToTable
            Dim dr() As DataRow = dt.Select("StageID = " & SQLString(tdbg(e.Row, COL_StageID).ToString))
            Dim bUse As Boolean = False
            If dr.Length > 0 Then
                Select Case e.Col
                    Case COL_UnitPrice01
                        bUse = L3Bool(dr(0).Item("UP01"))
                    Case COL_UnitPrice02
                        bUse = L3Bool(dr(0).Item("UP02"))
                    Case COL_UnitPrice03
                        bUse = L3Bool(dr(0).Item("UP03"))
                    Case COL_UnitPrice04
                        bUse = L3Bool(dr(0).Item("UP04"))
                    Case COL_UnitPrice05
                        bUse = L3Bool(dr(0).Item("UP05"))
                End Select
            End If

            If Not bUse Then
                e.CellStyle.Locked = True
                e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            End If
        End If
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick_tdbg(e.ColIndex)
    End Sub
#End Region

    Private Sub HeadClick_tdbg(ByVal icol As Integer)
        Select Case icol
            Case COL_TransID, COL_OrderNo, COL_ProductID, COL_ProductName, COL_OProductName, COL_TeamName

            Case COL_DepartmentID
                Dim iCols() As Integer = {COL_DepartmentID, COL_TeamID, COL_TeamName}
                CopyColumnArr(tdbg, tdbg.Col, iCols)

            Case COL_Spec01ID, COL_Spec02ID, COL_Spec03ID, COL_Spec04ID, COL_Spec05ID, COL_Spec06ID, COL_Spec07ID, COL_Spec08ID, COL_Spec09ID, COL_Spec10ID
                CopyColumnsMy(tdbg, icol, tdbg.Columns(icol).Value.ToString, tdbg.Row)
                CalculatorProductNameFromSpecs(tdbg.Row)

            Case Else
                CopyColumnsMy(tdbg, icol, tdbg.Columns(icol).Value.ToString, tdbg.Row)
        End Select
    End Sub


    Private Sub CopyColumnsMy(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 Then Exit Sub

            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                        If c1Grid(i, COL_PriceMethod).ToString <> "0" Or c1Grid(i, COL_PriceMethod).ToString = "" Then
                        ElseIf c1Grid.Splits(1).DisplayColumns(COL_StageName).Visible Then
                            Dim dt As DataTable = dtStageID.DefaultView.ToTable
                            Dim dr() As DataRow = dt.Select("StageID = " & SQLString(tdbg(i, COL_StageID).ToString))
                            Dim bUse As Boolean = False
                            If dr.Length > 0 Then
                                Select Case ColCopy
                                    Case COL_UnitPrice01
                                        bUse = L3Bool(dr(0).Item("UP01"))
                                    Case COL_UnitPrice02
                                        bUse = L3Bool(dr(0).Item("UP02"))
                                    Case COL_UnitPrice03
                                        bUse = L3Bool(dr(0).Item("UP03"))
                                    Case COL_UnitPrice04
                                        bUse = L3Bool(dr(0).Item("UP04"))
                                    Case COL_UnitPrice05
                                        bUse = L3Bool(dr(0).Item("UP05"))
                                End Select
                            End If

                            If bUse Then
                                c1Grid(i, ColCopy) = sValue
                            End If
                        Else
                            c1Grid(i, ColCopy) = sValue
                        End If
                    End If

                Next

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, COL_PriceMethod).ToString <> "0" Or c1Grid(i, COL_PriceMethod).ToString = "" Then
                    ElseIf c1Grid.Splits(1).DisplayColumns(COL_StageName).Visible Then
                        Dim dt As DataTable = dtStageID.DefaultView.ToTable
                        Dim dr() As DataRow = dt.Select("StageID = " & SQLString(tdbg(i, COL_StageID).ToString))
                        Dim bUse As Boolean = False
                        If dr.Length > 0 Then
                            Select Case ColCopy
                                Case COL_UnitPrice01
                                    bUse = L3Bool(dr(0).Item("UP01"))
                                Case COL_UnitPrice02
                                    bUse = L3Bool(dr(0).Item("UP02"))
                                Case COL_UnitPrice03
                                    bUse = L3Bool(dr(0).Item("UP03"))
                                Case COL_UnitPrice04
                                    bUse = L3Bool(dr(0).Item("UP04"))
                                Case COL_UnitPrice05
                                    bUse = L3Bool(dr(0).Item("UP05"))
                            End Select
                        End If

                        If bUse Then
                            c1Grid(i, ColCopy) = sValue
                        End If
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

    Private Sub CalculatorProductNameFromSpec()
        Dim sFullProductName As String
        sFullProductName = ""
        '*****************************
        If tdbg.Columns(COL_ProductID).Text = "" Then
            tdbg.Columns(COL_ProductName).Text = ""
            Exit Sub
        End If
        '*****************************
        sFullProductName = IIf(IsDBNull(tdbg.Columns(COL_OProductName).Text), "", Trim(tdbg.Columns(COL_OProductName).Text)).ToString

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec01ID).Visible And tdbg.Columns(COL_Spec01ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec01ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec02ID).Visible And tdbg.Columns(COL_Spec02ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec02ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec03ID).Visible And tdbg.Columns(COL_Spec03ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec03ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec04ID).Visible And tdbg.Columns(COL_Spec04ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec04ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec05ID).Visible And tdbg.Columns(COL_Spec05ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec05ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec06ID).Visible And tdbg.Columns(COL_Spec06ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec06ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec07ID).Visible And tdbg.Columns(COL_Spec07ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec07ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec08ID).Visible And tdbg.Columns(COL_Spec08ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec08ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec09ID).Visible And tdbg.Columns(COL_Spec09ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec09ID).Text)
        End If

        If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec10ID).Visible And tdbg.Columns(COL_Spec10ID).Text <> "" Then
            sFullProductName = sFullProductName & Space(1) & Trim(tdbg.Columns(COL_Spec10ID).Text)
        End If

        tdbg.Columns(COL_ProductName).Text = sFullProductName
    End Sub

    Private Sub CalculatorProductNameFromSpecs(ByVal RowCopy As Integer)
        Dim sFullProductName As String

        For i As Integer = RowCopy + 1 To tdbg.RowCount - 1
            If tdbg(i, COL_ProductID).ToString = "" Then
                tdbg(i, COL_ProductName) = ""
                Continue For
            End If

            sFullProductName = ""

            sFullProductName = IIf(IsDBNull(tdbg(i, COL_OProductName).ToString), "", Trim(tdbg(i, COL_OProductName).ToString)).ToString

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec01ID).Visible And tdbg(i, COL_Spec01ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec01ID, tdbdSpec01ID.DisplayMember, tdbdSpec01ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec01ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec02ID).Visible And tdbg(i, COL_Spec02ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec02ID, tdbdSpec02ID.DisplayMember, tdbdSpec02ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec02ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec03ID).Visible And tdbg(i, COL_Spec03ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec03ID, tdbdSpec03ID.DisplayMember, tdbdSpec03ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec03ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec04ID).Visible And tdbg(i, COL_Spec04ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec04ID, tdbdSpec04ID.DisplayMember, tdbdSpec04ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec04ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec05ID).Visible And tdbg(i, COL_Spec05ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec05ID, tdbdSpec05ID.DisplayMember, tdbdSpec05ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec05ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec06ID).Visible And tdbg(i, COL_Spec06ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec06ID, tdbdSpec06ID.DisplayMember, tdbdSpec06ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec06ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec07ID).Visible And tdbg(i, COL_Spec07ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec07ID, tdbdSpec07ID.DisplayMember, tdbdSpec07ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec07ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec08ID).Visible And tdbg(i, COL_Spec08ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec08ID, tdbdSpec08ID.DisplayMember, tdbdSpec08ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec08ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec09ID).Visible And tdbg(i, COL_Spec09ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec09ID, tdbdSpec09ID.DisplayMember, tdbdSpec09ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec09ID))))
            End If

            If tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec10ID).Visible And tdbg(i, COL_Spec10ID).ToString <> "" Then
                sFullProductName = sFullProductName & Space(1) & Trim(ReturnValueC1DropDown(tdbdSpec10ID, tdbdSpec10ID.DisplayMember, tdbdSpec10ID.ValueMember & " = " & SQLString(tdbg(i, COL_Spec10ID))))
            End If

            tdbg(i, COL_ProductName) = sFullProductName
        Next
    End Sub

End Class