'#######################################################################################
'#                                     CHÚ Ý
'#--------------------------------------------------------------------------------------
'# Không được thay đổi bất cứ dòng code này trong module này, nếu muốn thay đổi bạn phải
'# liên lạc với Trưởng nhóm để được giải quyết.
'# Ngày tạo: 28/06/2012
'# Người tạo: Nguyễn Thị Ánh
'# Ngày cập nhật cuối cùng: 06/01/2014
'# Người cập nhật cuối cùng: Nguyễn Thị Minh Hòa
'# Bổ sung Tạo dropdown động
'# Bổ sung Đổ nguồn Dự án, Hạng mục
'# Bổ sung Đổ nguồn Mã XDCB
'# Bổ sung chuẩn hiển thị Dự án - hạng mục cho Truy vấn
'# Sửa hàm ReturnConversionFactor(thêm biến ModuleID)
'# Bổ sung Đổ nguồn Kho hàng cho dropdown
'# Sửa add dropdown động : 14/06/2013
'# Chặn ds cột thêm dropdown vào nothing : 21/06/2013
'# Thêm các hàm Load Tài khoản, Khoản mục phân quyền theo Đơn vị
'#######################################################################################
''' <summary>
''' Module liên quan đến các vấn đề Load nguồn
''' </summary>
''' <remarks></remarks>
Module D99X0012

#Region "Đơn vị tính"
    Public Function ReturnTableUnitID(ByVal sInventoryID As String, Optional ByVal sOrderby As String = "") As DataTable
        Dim sSQL As String = ""
        sSQL &= "SELECT T1.UnitID,T2.UnitName" & UnicodeJoin(gbUnicode) & " as UnitName, IsNull(T1.ConversionFactor,1) As ConversionFactor, T1.Tolerance,T1.UseFormula,T1.Formula " & vbCrLf
        sSQL &= " FROM D07T0004 T1   WITH(NOLOCK)" & vbCrLf
        sSQL &= "INNER JOIN  D07T0005 T2  WITH(NOLOCK) ON  T1.UnitID=T2.UnitID" & vbCrLf
        sSQL &= "WHERE T1.Disabled=0 And T1.InventoryID=" & SQLString(sInventoryID)
        If sOrderby <> "" Then sSQL &= vbCrLf & "Order by " & sOrderby
        Return ReturnDataTable(sSQL)
    End Function

    Public Sub LoadtdbdUnitID(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sInventoryID As String, Optional ByVal sOrderby As String = "")
        LoadDataSource(tdbd, ReturnTableUnitID(sInventoryID, sOrderby), gbUnicode)
    End Sub

    '#------------------------------------------------------------------------
    '#Title: SQLStoreD07P7004
    '#Create User: Nguyễn Thị Ánh
    '#Create Date: 25/12/2007 10:11:08
    '#Modified User:
    '#Modified Date:
    '#Description: Lấy ConversionFactor khi UseFormula=1
    '#------------------------------------------------------------------------
    Private Function SQLStoreDxxP7004(ByVal sModuleID As String, ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sFieldFormula As String, Optional ByVal row As Integer = -1) As String
        Dim sSQL As String = ""
        sSQL = "Exec " & sModuleID & "P7004 "
        Try
            If row = -1 Then
                sSQL &= SQLString(tdbg.Columns("InventoryID").Text) & COMMA  ' InventoryID
                sSQL &= SQLString(tdbg.Columns("LocationNo").Text) & COMMA ' LocationNo
                sSQL &= SQLString(tdbg.Columns("Spec01ID").Text) & COMMA  ' Spec01ID
                sSQL &= SQLString(tdbg.Columns("Spec02ID").Text) & COMMA  ' Spec02ID
                sSQL &= SQLString(tdbg.Columns("Spec03ID").Text) & COMMA  ' Spec03ID
                sSQL &= SQLString(tdbg.Columns("Spec04ID").Text) & COMMA  ' Spec04ID
                sSQL &= SQLString(tdbg.Columns("Spec05ID").Text) & COMMA  ' Spec05ID
                sSQL &= SQLString(tdbg.Columns("Spec06ID").Text) & COMMA  ' Spec06ID
                sSQL &= SQLString(tdbg.Columns("Spec07ID").Text) & COMMA  ' Spec07ID
                sSQL &= SQLString(tdbg.Columns("Spec08ID").Text) & COMMA  ' Spec08ID
                sSQL &= SQLString(tdbg.Columns("Spec09ID").Text) & COMMA  ' Spec09ID
                sSQL &= SQLString(tdbg.Columns("Spec10ID").Text) & COMMA  ' Spec10ID
                sSQL &= SQLString(tdbg.Columns(sFieldFormula).Text)  ' Formula
            Else 'Dùng cho HeadClick
                sSQL &= SQLString(tdbg(row, "InventoryID")) & COMMA  ' InventoryID
                sSQL &= SQLString(tdbg(row, "LocationNo")) & COMMA ' LocationNo
                sSQL &= SQLString(tdbg(row, "Spec01ID")) & COMMA  ' Spec01ID
                sSQL &= SQLString(tdbg(row, "Spec02ID")) & COMMA  ' Spec02ID
                sSQL &= SQLString(tdbg(row, "Spec03ID")) & COMMA  ' Spec03ID
                sSQL &= SQLString(tdbg(row, "Spec04ID")) & COMMA  ' Spec04ID
                sSQL &= SQLString(tdbg(row, "Spec05ID")) & COMMA  ' Spec05ID
                sSQL &= SQLString(tdbg(row, "Spec06ID")) & COMMA  ' Spec06ID
                sSQL &= SQLString(tdbg(row, "Spec07ID")) & COMMA  ' Spec07ID
                sSQL &= SQLString(tdbg(row, "Spec08ID")) & COMMA  ' Spec08ID
                sSQL &= SQLString(tdbg(row, "Spec09ID")) & COMMA  ' Spec09ID
                sSQL &= SQLString(tdbg(row, "Spec10ID")) & COMMA  ' Spec10ID
                sSQL &= SQLString(tdbg(row, sFieldFormula))  ' Formula
            End If

        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
        Return sSQL
    End Function

    ''' <summary>
    ''' Trả về Hệ số quy đổi theo D07P7004 khi UseConversionFormula =1
    ''' </summary>
    ''' <param name="tdbg"></param>
    ''' <param name="sFieldFormula">Field ConversionFormula trên lưới</param>
    ''' <returns>Hệ số quy đổi theo Result của D07P7004</returns>
    ''' <remarks>Mặc định trả về 1</remarks>
    Public Function ReturnConversionFactor(ByVal sModuleID As String, ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sFieldFormula As String, Optional ByVal Row As Integer = -1) As Object
        Dim dt As DataTable = ReturnDataTable(SQLStoreDxxP7004(sModuleID, tdbg, sFieldFormula, Row))
        If dt.Rows.Count > 0 Then Return dt.Rows(0).Item("Result")
        Return 1
    End Function
#End Region

#Region "Đổ nguồn Kho hàng"
    ''' <summary>
    ''' Trả về Table Kho hàng của tất cả Đơn vị
    ''' </summary>
    ''' <param name="bAll">Sử dụng Tất cả. Mặc định True</param>
    ''' <param name="sWhere">Điều kiện lọc. Mặc định ""</param>
    ''' <returns>Table Kho hàng</returns>
    ''' <remarks>Nghiệp vụ thêm sWhere = Disabled = 0. Ngược lại thì không có</remarks>
    Private Function ReturnTableWareHouseID(Optional ByVal bAll As Boolean = True, Optional ByVal sWhere As String = "") As DataTable
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon Kho hang" & vbCrLf)
        If bAll Then sSQL &= "Select " & AllCode & " as WareHouseID, " & AllName & " as WareHouseName, '%' as DivisionID, 0 as DisplayOrder " & vbCrLf & "Union All" & vbCrLf
        sSQL &= "Select WareHouseID, WareHouseName" & UnicodeJoin(gbUnicode) & " as WareHouseName, DivisionID,  1 as DisplayOrder " & vbCrLf
        sSQL &= "From D07T0007  WITH(NOLOCK)" & vbCrLf
        sSQL &= "Where ( DAGroupID = '' OR DAGroupID IN (SELECT DAGroupID From LEMONSYS.DBO.D00V0080  WHERE UserID = " & SQLString(gsUserID) & ") OR 'LEMONADMIN' =" & SQLString(gsUserID) & ")" & vbCrLf
        If sWhere <> "" Then sSQL &= " And " & sWhere & vbCrLf
        sSQL &= "Order by DisplayOrder, WareHouseID"
        Return ReturnDataTable(sSQL)
    End Function

    ''' <summary>
    ''' Đổ nguồn cho nhiều combo Kho hàng phụ thuộc Đơn vị
    ''' </summary>
    ''' <param name="tdbc">Danh sách combo</param>
    ''' <param name="dtWareHouse">Có thể truyền Nothing</param>
    ''' <param name="bTransaction">Sử dụng Nghiệp vụ (True)/ Truy vấn/ Báo cáo (False). Nghiệp vụ thêm Disabled = 0. Ngược lại thì không có</param>
    ''' <param name="sDivsionID">Đơn vị. Mặc định rỗng</param>
    ''' <param name="bAll">Sử dụng Tất cả. Mặc định True</param>
    ''' <remarks>Có thể lấy được dtWareHouse nếu truyền Nothing. LoadtdbcWareHouseID(New C1.Win.C1List.C1Combo() {tdbcWareHouseIDFrom, tdbcWareHouseIDTo}, dtWareHouse, tdbcDivisionID.SelectedValue.ToString)</remarks>
    ''' 
    Public Sub LoadtdbcWareHouseID(ByVal tdbc() As C1.Win.C1List.C1Combo, ByRef dtWareHouse As DataTable, ByVal bTransaction As Boolean, Optional ByVal sDivsionID As String = "", Optional ByVal bAll As Boolean = True)
        If dtWareHouse Is Nothing Then dtWareHouse = ReturnTableWareHouseID(bAll, IIf(bTransaction, " Disabled = 0", "").ToString)

        Dim sFilter As String = ""
        If sDivsionID <> "%" And sDivsionID <> "" Then sFilter = " DivisionID = " & SQLString(sDivsionID) & " or DivisionID = '%'"
        Dim dtTemp As DataTable = ReturnTableFilter(dtWareHouse, sFilter, True)
        For i As Integer = 0 To tdbc.Length - 1
            LoadDataSource(tdbc(i), dtTemp.DefaultView.ToTable, gbUnicode)
            If bAll Then tdbc(i).SelectedIndex = 0
            Try
                tdbc(i).Columns("DivisionID").Caption = r("Don_vi")
                tdbc(i).Splits(0).DisplayColumns("DivisionID").Visible = sDivsionID = "%"
            Catch ex As Exception

            End Try
        Next
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho nhiều combo Kho hàng theo Đơn vị hiện tại
    ''' </summary>
    ''' <param name="tdbc">Danh sách combo</param>
    ''' <param name="bAll">Sử dụng Tất cả. Mặc định True</param>
    ''' <remarks>LoadtdbcWareHouseID(New C1.Win.C1List.C1Combo() {tdbcWareHouseIDFrom, tdbcWareHouseIDTo})</remarks>
    Public Sub LoadtdbcWareHouseID(ByVal tdbc() As C1.Win.C1List.C1Combo, ByVal bTransaction As Boolean, Optional ByVal bAll As Boolean = True)
        Dim dtWareHouse As DataTable = ReturnTableWareHouseID(bAll, " DivisionID = " & SQLString(gsDivisionID) & IIf(bTransaction, " And Disabled = 0", "").ToString)

        For i As Integer = 0 To tdbc.Length - 1
            LoadDataSource(tdbc(i), dtWareHouse.DefaultView.ToTable, gbUnicode)
            If bAll Then tdbc(i).SelectedIndex = 0
        Next
    End Sub

    Public Sub LoadtdbdWareHouseID(ByVal tdbd() As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByRef dtWareHouse As DataTable, ByVal bTransaction As Boolean, Optional ByVal sDivsionID As String = "")
        If dtWareHouse Is Nothing Then dtWareHouse = ReturnTableWareHouseID(False, IIf(bTransaction, " Disabled = 0", "").ToString)

        Dim sFilter As String = ""
        If sDivsionID <> "%" And sDivsionID <> "" Then sFilter = " DivisionID = " & SQLString(sDivsionID) & " or DivisionID = '%'"
        Dim dtTemp As DataTable = ReturnTableFilter(dtWareHouse, sFilter, True)
        For i As Integer = 0 To tdbd.Length - 1
            LoadDataSource(tdbd(i), dtTemp.DefaultView.ToTable, gbUnicode)
        Next
    End Sub

    Public Sub LoadtdbdWareHouseID(ByVal tdbd() As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal bTransaction As Boolean)
        Dim dtWareHouse As DataTable = ReturnTableWareHouseID(False, " DivisionID = " & SQLString(gsDivisionID) & IIf(bTransaction, " And Disabled = 0", "").ToString)

        For i As Integer = 0 To tdbd.Length - 1
            LoadDataSource(tdbd(i), dtWareHouse.DefaultView.ToTable, gbUnicode)
        Next
    End Sub
#End Region

#Region "Đổ nguồn Dự án và Hạng mục"
    Public gbUseD54 As Boolean = False

    Public Sub UseModuleD54()
        gbUseD54 = ExistRecord("Select top 1 1 From D54T0000  WITH(NOLOCK)")
    End Sub

    Public Sub VisibleProjectID(ByRef tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iSplit As Integer)
        tdbg.Splits(iSplit).DisplayColumns("ProjectID").Visible = gbUseD54
        tdbg.Splits(iSplit).DisplayColumns("ProjectName").Visible = gbUseD54
        tdbg.Splits(iSplit).DisplayColumns("TaskID").Visible = gbUseD54
        tdbg.Splits(iSplit).DisplayColumns("TaskName").Visible = gbUseD54
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD54P9000
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 20/09/2012 10:33:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD54P9000(ByVal bIsPercent As Boolean) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon du an va hang muc" & vbCrLf)
        sSQL &= "Exec D54P9000 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(bIsPercent) & COMMA 'IsPercent, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage)  'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    Public Function ReturnTableProject_TaskID(Optional ByVal bIsPercent As Boolean = False) As DataTable
        Return ReturnDataTable(SQLStoreD54P9000(bIsPercent))
    End Function

    Public Sub LoadProject(ByVal ctrlProject As Control, Optional ByRef dtSource As DataTable = Nothing, Optional ByVal bIsPercent As Boolean = False)
        If dtSource Is Nothing Then dtSource = ReturnDataTable(SQLStoreD54P9000(bIsPercent))
        Dim dtProject As DataTable = Nothing
        If dtSource.Rows.Count > 0 Then
            dtProject = dtSource.DefaultView.ToTable(True, New String() {"ProjectID", "ProjectName"})
        Else
            dtProject = dtSource
        End If
        If TypeOf (ctrlProject) Is C1.Win.C1List.C1Combo Then
            LoadDataSource(CType(ctrlProject, C1.Win.C1List.C1Combo), dtProject, gbUnicode)
        ElseIf TypeOf (ctrlProject) Is C1.Win.C1TrueDBGrid.C1TrueDBDropdown Then
            LoadDataSource(CType(ctrlProject, C1.Win.C1TrueDBGrid.C1TrueDBDropdown), dtProject, gbUnicode)
        End If
    End Sub

    Public Sub LoadTask(ByVal ctrlTask As Control, Optional ByRef dtSource As DataTable = Nothing, Optional ByVal sProjectID As String = "%", Optional ByVal bIsPercent As Boolean = False)
        If dtSource Is Nothing Then dtSource = ReturnDataTable(SQLStoreD54P9000(bIsPercent))
        Dim dtTaskID As DataTable = Nothing
        If sProjectID = "%" Then
            dtTaskID = dtSource
        Else
            Dim sFilter As String = "ProjectID=" & SQLString(sProjectID)
            dtTaskID = ReturnTableFilter(dtSource, sFilter, True)
        End If
        If TypeOf (ctrlTask) Is C1.Win.C1List.C1Combo Then
            LoadDataSource(CType(ctrlTask, C1.Win.C1List.C1Combo), dtTaskID, gbUnicode)
        ElseIf TypeOf (ctrlTask) Is C1.Win.C1TrueDBGrid.C1TrueDBDropdown Then
            LoadDataSource(CType(ctrlTask, C1.Win.C1TrueDBGrid.C1TrueDBDropdown), dtTaskID, gbUnicode)
        End If
    End Sub
#End Region

#Region "Đổ nguồn Ngân sách và Hạng mục ngân sách"
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD10P9000
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 23/10/2013 11:42:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD10P9000(ByVal sFormID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon Ngan sach, hang muc ngan sach" & vbCrLf)
        sSQL &= "Exec D10P9000 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(sFormID) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Public Function ReturnTableBudgetID_BudgetItemID(ByVal sFormID As String) As DataTable
        Return ReturnDataTable(SQLStoreD10P9000(sFormID))
    End Function

    Public Sub LoadBudget(ByVal ctrlBudgetID As Control, ByVal sFormID As String, Optional ByRef dtSource As DataTable = Nothing)
        If dtSource Is Nothing Then dtSource = ReturnDataTable(SQLStoreD10P9000(sFormID))
        Dim dtBudgetID As DataTable = Nothing
        If dtSource.Rows.Count > 0 Then
            dtBudgetID = dtSource.DefaultView.ToTable(True, New String() {"BudgetID", "BudgetName"})
        Else
            dtBudgetID = dtSource
        End If
        If TypeOf (ctrlBudgetID) Is C1.Win.C1List.C1Combo Then
            LoadDataSource(CType(ctrlBudgetID, C1.Win.C1List.C1Combo), dtBudgetID, gbUnicode)
        ElseIf TypeOf (ctrlBudgetID) Is C1.Win.C1TrueDBGrid.C1TrueDBDropdown Then
            LoadDataSource(CType(ctrlBudgetID, C1.Win.C1TrueDBGrid.C1TrueDBDropdown), dtBudgetID, gbUnicode)
        End If
    End Sub

    Public Sub LoadBudgetItem(ByVal ctrlBudgetItemID As Control, ByVal sFormID As String, Optional ByRef dtSource As DataTable = Nothing, Optional ByVal sBudgetID As String = "%")
        If dtSource Is Nothing Then dtSource = ReturnDataTable(SQLStoreD10P9000(sFormID))
        Dim dtBudgetItemID As DataTable = Nothing
        If sBudgetID = "%" Then
            dtBudgetItemID = dtSource
        Else
            Dim sFilter As String = "BudgetID=" & SQLString(sBudgetID)
            dtBudgetItemID = ReturnTableFilter(dtSource, sFilter, True)
        End If
        If TypeOf (ctrlBudgetItemID) Is C1.Win.C1List.C1Combo Then
            LoadDataSource(CType(ctrlBudgetItemID, C1.Win.C1List.C1Combo), dtBudgetItemID, gbUnicode)
        ElseIf TypeOf (ctrlBudgetItemID) Is C1.Win.C1TrueDBGrid.C1TrueDBDropdown Then
            LoadDataSource(CType(ctrlBudgetItemID, C1.Win.C1TrueDBGrid.C1TrueDBDropdown), dtBudgetItemID, gbUnicode)
        End If
    End Sub
#End Region

#Region "Đổ nguồn cho Mã XDCB"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P9000
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 13/11/2012 02:52:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P9000() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon XDCB" & vbCrLf)
        sSQL &= "Exec D02P9000 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Public Function ReturnTableCIP() As DataTable
        Return ReturnDataTable(SQLStoreD02P9000)
    End Function

    'Update 13/11/2012 by Lê Phương
    Public Sub LoadCIP(ByVal ctrlCIP As Control, Optional ByRef dtCIP As DataTable = Nothing)
        If dtCIP Is Nothing Then dtCIP = ReturnTableCIP()
        If TypeOf (ctrlCIP) Is C1.Win.C1List.C1Combo Then
            LoadDataSource(CType(ctrlCIP, C1.Win.C1List.C1Combo), dtCIP, gbUnicode)
        ElseIf TypeOf (ctrlCIP) Is C1.Win.C1TrueDBGrid.C1TrueDBDropdown Then
            LoadDataSource(CType(ctrlCIP, C1.Win.C1TrueDBGrid.C1TrueDBDropdown), dtCIP, gbUnicode)
        End If
    End Sub

#End Region

#Region "Tạo dropdown động"
    '''' <summary>
    '''' Trả về dropdown
    '''' </summary>
    '''' <param name="frm">form</param>
    '''' <param name="sDropdownName">tên dropdown cần tạo</param>
    ''' <param name="sValueMember">ValueMember của dropdown cần tạo</param>
    ''' <param name="sDisplayMember">DisplayMember của dropdown cần tạo</param>
    ''' <param name="sColumns">mảng các cột của dropdown cần tạo (khác ValueMember)</param>
    Public Function CreateDropDownID(ByVal frm As Form, ByVal sDropdownName As String, ByVal sValueMember As String, ByVal sDisplayMember As String, ByVal ParamArray sColumns() As String) As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Dim tdbdID As New C1.Win.C1TrueDBGrid.C1TrueDBDropdown

        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        'Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager() '(GetType(D09F2180))

        ''***********************************************
        CType(tdbdID, System.ComponentModel.ISupportInitialize).BeginInit()
        '***********************************************
        tdbdID.AllowColMove = False
        tdbdID.AllowColSelect = False
        tdbdID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        tdbdID.AllowSort = False
        tdbdID.AlternatingRows = True
        tdbdID.CaptionHeight = 17
        tdbdID.CaptionStyle = Style1
        tdbdID.ColumnCaptionHeight = 17
        tdbdID.ColumnFooterHeight = 17

        tdbdID.EmptyRows = True
        tdbdID.ExtendRightColumn = True
        tdbdID.FetchRowStyles = False
        tdbdID.FooterStyle = Style3
        tdbdID.HeadingStyle = Style4
        tdbdID.HighLightRowStyle = Style5
        tdbdID.Location = New System.Drawing.Point(541, 90)
        '  tdbdID.Images.Add(CType(resources.GetObject("tdbdID.Images"), System.Drawing.Image))
        '  tdbdID.PropBag = resources.GetString("tdbdID.PropBag")

        tdbdID.RecordSelectorStyle = Style7
        tdbdID.RowDivider.Color = System.Drawing.Color.DarkGray
        tdbdID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        tdbdID.RowHeight = 15
        tdbdID.RowSubDividerColor = System.Drawing.Color.DarkGray
        tdbdID.ScrollTips = False
        tdbdID.Size = New System.Drawing.Size(350, 147)
        tdbdID.Style = Style8
        tdbdID.TabIndex = 30
        tdbdID.TabStop = False
        tdbdID.Visible = False
        tdbdID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        '***********************************************
        tdbdID.OddRowStyle.BackColor = Color.Beige
        tdbdID.EvenRowStyle.BackColor = Color.White
        '***********************************************
        tdbdID.Name = "tdbd" & sDropdownName
        tdbdID.ValueMember = sValueMember
        tdbdID.DisplayMember = sDisplayMember
        If sValueMember = sDisplayMember Then 'Hiển thị Mã, Lưu Mã
            tdbdID.ValueTranslate = False
        Else
            tdbdID.ValueTranslate = True 'Hiển thị Tên, Lưu Mã
        End If
        ''***********************************************
        'Me.Controls.Add(tdbdID)
        frm.Controls.Add(tdbdID)
        CType(tdbdID, System.ComponentModel.ISupportInitialize).EndInit()
        '***********************************************
        CreateColumnDropdown(tdbdID, sValueMember, r("Ma"), 110)
        If sValueMember <> sDisplayMember Then
            CreateColumnDropdown(tdbdID, sDisplayMember, r("Ten"), 200)
        End If
        If sColumns Is Nothing Then Return tdbdID '21/06/2013

        For i As Integer = 0 To sColumns.Length - 1
            If i = 0 AndAlso sValueMember = sDisplayMember AndAlso sColumns(0) <> sDisplayMember Then 'Cột đầu tiên của mảng cột
                CreateColumnDropdown(tdbdID, sColumns(i), r("Ten"), 200)
            Else
                CreateColumnDropdown(tdbdID, sColumns(i))
            End If
        Next

        Return tdbdID
    End Function

    Private Sub CreateColumnDropdown(ByVal tdbdID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sDataField As String, Optional ByVal sCaption As String = "", Optional ByVal iWidth As Integer = 200, Optional ByVal bVisible As Boolean = True)
        Dim dc As New C1.Win.C1TrueDBGrid.C1DropDataColumn
        dc.DataField = sDataField
        tdbdID.Columns.Add(dc)
        tdbdID.Columns(dc.DataField).Caption = IIf(sCaption = "", sDataField, sCaption).ToString
        tdbdID.DisplayColumns(dc.DataField).HeadingStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        tdbdID.DisplayColumns(dc.DataField).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        tdbdID.DisplayColumns(dc.DataField).Style.Font = FontUnicode(gbUnicode)
        tdbdID.DisplayColumns(dc.DataField).Visible = bVisible
        tdbdID.DisplayColumns(dc.DataField).Width = iWidth
    End Sub

#End Region

#Region "Đổ nguồn cho Khoản mục, kiểm tra theo Phân quyền Đơn vị"

    Public Function ReturnTableAnaIDForDivision(ByVal bAddnew As Boolean, ByVal bUnicode As Boolean, ByVal sAnaCategoryID As String) As DataTable
        Dim sSQL As String = "--Do nguon Khoan muc " & vbCrLf
        If bAddnew Then
            sSQL &= "Select '+' as AnaID, " & NewName & " As AnaName, '+' as AnaCategoryID, 0 AS DisplayOrder " & vbCrLf
            sSQL &= "Union All " & vbCrLf
        End If
        sSQL &= "Select AnaID, AnaName" & UnicodeJoin(bUnicode) & " as AnaName, AnaCategoryID, 1 AS DisplayOrder " & vbCrLf
        sSQL &= "From D91T0051 WITH(NOLOCK) Where Disabled = 0 " & vbCrLf
        If sAnaCategoryID = "" Then
            sSQL &= "And AnaCategoryID like 'K%' " & vbCrLf
        Else
            sSQL &= "And AnaCategoryID = " & SQLString(sAnaCategoryID) & vbCrLf
        End If
        'Update 06/01/2014: Kiểm tra quyền Đơn vị sử dụng
        sSQL &= " And (StrDivisionID = '' OR CHARINDEX(" & SQLString(gsDivisionID) & ",StrDivisionID) > 0) " & vbCrLf
        sSQL &= " Order by DisplayOrder, AnaID"
        Return ReturnDataTable(sSQL)
    End Function

    Public Function ReturnTableAnaIDForDivision(ByVal bAddnew As Boolean, ByVal bUnicode As Boolean) As DataTable
        Return ReturnTableAnaIDForDivision(bAddnew, bUnicode, "")
    End Function

    Public Function ReturnTableAnaIDForDivision(ByVal bAddnew As Boolean) As DataTable
        Return ReturnTableAnaIDForDivision(bAddnew, False, "")
    End Function

    Public Function ReturnTableAnaIDForDivision() As DataTable
        Return ReturnTableAnaIDForDivision(False, False, "")
    End Function

    '''' <summary>
    '''' Hàm mới: Đổ nguồn cho 10 khoản mục kiểm tra KM nào có dùng thì đổ nguồn cho Dropdown
    '''' </summary>
    '''' <remarks>Truyền 10 khoản mục cần đổ nguồn vào</remarks>
    '<DebuggerStepThrough()> _
    Public Sub LoadTDBDropDownAnaForDivision(ByVal tdbdAna01ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna02ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna03ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna04ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna05ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna06ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna07ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna08ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna09ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna10ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, _
  ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal COL_Ana01ID As Integer, Optional ByVal bUseUnicode As Boolean = False, Optional ByVal bAddNew As Boolean = False, Optional ByRef dt As DataTable = Nothing, Optional ByVal bPerDivision As Boolean = False)
        If dt Is Nothing Then dt = ReturnTableAnaIDForDivision(bAddNew, bUseUnicode, "")

        If Convert.ToBoolean(tdbg.Columns(COL_Ana01ID).Tag) Then LoadDataSource(tdbdAna01ID, ReturnTableFilter(dt, "AnaCategoryID='K01' or AnaCategoryID='+'"), bUseUnicode)
        If Convert.ToBoolean(tdbg.Columns(COL_Ana01ID + 1).Tag) Then LoadDataSource(tdbdAna02ID, ReturnTableFilter(dt, "AnaCategoryID='K02' or AnaCategoryID='+'"), bUseUnicode)
        If Convert.ToBoolean(tdbg.Columns(COL_Ana01ID + 2).Tag) Then LoadDataSource(tdbdAna03ID, ReturnTableFilter(dt, "AnaCategoryID='K03' or AnaCategoryID='+'"), bUseUnicode)
        If Convert.ToBoolean(tdbg.Columns(COL_Ana01ID + 3).Tag) Then LoadDataSource(tdbdAna04ID, ReturnTableFilter(dt, "AnaCategoryID='K04' or AnaCategoryID='+'"), bUseUnicode)
        If Convert.ToBoolean(tdbg.Columns(COL_Ana01ID + 4).Tag) Then LoadDataSource(tdbdAna05ID, ReturnTableFilter(dt, "AnaCategoryID='K05' or AnaCategoryID='+'"), bUseUnicode)
        If Convert.ToBoolean(tdbg.Columns(COL_Ana01ID + 5).Tag) Then LoadDataSource(tdbdAna06ID, ReturnTableFilter(dt, "AnaCategoryID='K06' or AnaCategoryID='+'"), bUseUnicode)
        If Convert.ToBoolean(tdbg.Columns(COL_Ana01ID + 6).Tag) Then LoadDataSource(tdbdAna07ID, ReturnTableFilter(dt, "AnaCategoryID='K07' or AnaCategoryID='+'"), bUseUnicode)
        If Convert.ToBoolean(tdbg.Columns(COL_Ana01ID + 7).Tag) Then LoadDataSource(tdbdAna08ID, ReturnTableFilter(dt, "AnaCategoryID='K08' or AnaCategoryID='+'"), bUseUnicode)
        If Convert.ToBoolean(tdbg.Columns(COL_Ana01ID + 8).Tag) Then LoadDataSource(tdbdAna09ID, ReturnTableFilter(dt, "AnaCategoryID='K09' or AnaCategoryID='+'"), bUseUnicode)
        If Convert.ToBoolean(tdbg.Columns(COL_Ana01ID + 9).Tag) Then LoadDataSource(tdbdAna10ID, ReturnTableFilter(dt, "AnaCategoryID='K10' or AnaCategoryID='+'"), bUseUnicode)
    End Sub



    '''' <summary>
    '''' Đổ nguồn cho 10 khoản mục (Hàm cũ BỎ)
    '''' </summary>
    '''' <remarks>Truyền 10 khoản mục cần đổ nguồn vào</remarks>
    '<DebuggerStepThrough()> _
    Public Sub LoadTDBDropDownAnaForDivision(ByVal tdbdAna01ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna02ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna03ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna04ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna05ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna06ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna07ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna08ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna09ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna10ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, Optional ByVal bUseUnicode As Boolean = False, Optional ByVal bPerDivision As Boolean = False)
        Dim dt As DataTable
        Dim sSQL As String = ""

        sSQL = "Select AnaID, AnaName" & UnicodeJoin(bUseUnicode) & " as AnaName, AnaCategoryID " & vbCrLf
        sSQL &= "From D91T0051 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 And AnaCategoryID like 'K%' " & vbCrLf
        'Update 06/01/2014: Kiểm tra quyền Đơn vị sử dụng
        sSQL &= "And (StrDivisionID = '' OR CHARINDEX(" & SQLString(gsDivisionID) & ",StrDivisionID) > 0) " & vbCrLf
        sSQL &= "Order by AnaID"
        dt = ReturnDataTable(sSQL)

        LoadDataSource(tdbdAna01ID, ReturnTableFilter(dt, "AnaCategoryID='K01'"), bUseUnicode)
        LoadDataSource(tdbdAna02ID, ReturnTableFilter(dt, "AnaCategoryID='K02'"), bUseUnicode)
        LoadDataSource(tdbdAna03ID, ReturnTableFilter(dt, "AnaCategoryID='K03'"), bUseUnicode)
        LoadDataSource(tdbdAna04ID, ReturnTableFilter(dt, "AnaCategoryID='K04'"), bUseUnicode)
        LoadDataSource(tdbdAna05ID, ReturnTableFilter(dt, "AnaCategoryID='K05'"), bUseUnicode)
        LoadDataSource(tdbdAna06ID, ReturnTableFilter(dt, "AnaCategoryID='K06'"), bUseUnicode)
        LoadDataSource(tdbdAna07ID, ReturnTableFilter(dt, "AnaCategoryID='K07'"), bUseUnicode)
        LoadDataSource(tdbdAna08ID, ReturnTableFilter(dt, "AnaCategoryID='K08'"), bUseUnicode)
        LoadDataSource(tdbdAna09ID, ReturnTableFilter(dt, "AnaCategoryID='K09'"), bUseUnicode)
        LoadDataSource(tdbdAna10ID, ReturnTableFilter(dt, "AnaCategoryID='K10'"), bUseUnicode)
    End Sub

#End Region

#Region "Đổ nguồn Tài khoản (Chỉ gồm Tài khoản trong bảng) kiểm tra Phân quyền theo Đơn vị"

    ''' <summary>
    ''' Trả ra Table Tài khoản có chứa % và kiểm tra Phân quyền theo Đơn vị
    ''' </summary>
    ''' <param name="sClauseWhere">Nếu có điều kiện lọc thì truyền vào (ví dụ: GroupID in ('1', '13'))</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ReturnTableAccountIDGeneralForDivision(ByVal sClauseWhere As String, ByVal bUseUnicode As Boolean, ByVal bAll As Boolean) As DataTable
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, bUseUnicode)

        '***************
        Dim sSQL As String = "--Do nguon Tai khoan" & IIf(bAll, " co % ", "").ToString & vbCrLf
        If bAll Then
            sSQL &= "Select '%' as AccountID, " & sLanguage & " as AccountName, '' As GroupID,0 AS DisplayOrder " & vbCrLf
            sSQL &= "Union All " & vbCrLf
        End If
        sSQL &= "Select AccountID, " & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName", "AccountName01").ToString & sUnicode & " as AccountName, GroupID, 1 AS DisplayOrder "
        sSQL &= "From D90T0001 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 And OffAccount = 0 " & vbCrLf
        sSQL &= "And (StrDivisionID = '' OR CHARINDEX(" & SQLString(gsDivisionID) & ",StrDivisionID) > 0) " & vbCrLf
        If sClauseWhere <> "" Then
            sSQL &= "And (" & sClauseWhere & ") " & vbCrLf
        End If
        sSQL &= "Order By DisplayOrder, AccountID"

        Return ReturnDataTable(sSQL)
    End Function

    '''' <summary>
    '''' Trả ra Table Tài khoản kiểm tra Phân quyền theo Đơn vị
    '''' </summary>
    '''' <param name="sClauseWhere">Nếu có điều kiện lọc thì truyền vào (ví dụ: GroupID in ('1', '13')) </param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    '<DebuggerStepThrough()> _
    Public Function ReturnTableAccountIDForDivision(ByVal sClauseWhere As String, ByVal bUseUnicode As Boolean) As DataTable
        Return ReturnTableAccountIDGeneralForDivision(sClauseWhere, bUseUnicode, False)
    End Function

    Public Function ReturnTableAccountIDForDivision(ByVal sClauseWhere As String) As DataTable
        ' Trả ra Table Tài khoản kiểm tra Phân quyền theo Đơn vị
        Return ReturnTableAccountIDForDivision(sClauseWhere, False)
    End Function

    Public Function ReturnTableAccountIDForDivision() As DataTable
        ' Trả ra Table Tài khoản kiểm tra Phân quyền theo Đơn vị
        Return ReturnTableAccountIDForDivision("", False)
    End Function

    ''' <summary>
    ''' Trả ra Table Tài khoản có chứa % và kiểm tra Phân quyền theo Đơn vị
    ''' </summary>
    ''' <param name="sClauseWhere">Nếu có điều kiện lọc thì truyền vào (ví dụ: GroupID in ('1', '13'))</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReturnTableAccountIDAllForDivision(ByVal sClauseWhere As String, ByVal bUseUnicode As Boolean) As DataTable
        Return ReturnTableAccountIDGeneralForDivision(sClauseWhere, bUseUnicode, True)
    End Function


    Public Function ReturnTableAccountIDAllForDivision(ByVal sClauseWhere As String) As DataTable
        Return ReturnTableAccountIDAllForDivision(sClauseWhere, False)
    End Function

    Public Function ReturnTableAccountIDAllForDivision() As DataTable
        Return ReturnTableAccountIDAllForDivision("", False)
    End Function


    ''' <summary>
    ''' Load Combo Tài khoản
    ''' </summary>
    ''' <param name="tdbc"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDForDivision(ByVal tdbc As C1.Win.C1List.C1Combo, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbc, ReturnTableAccountIDForDivision("", bUseUnicode), bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load Combo Tài khoản có chứa %
    ''' </summary>
    ''' <param name="tdbc"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAllForDivision(ByVal tdbc As C1.Win.C1List.C1Combo, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbc, ReturnTableAccountIDAllForDivision("", bUseUnicode), bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Combo Tài khoản
    ''' </summary>
    ''' <param name="tdbcFrom"></param>
    ''' <param name="tdbcTo"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDForDivision(ByVal tdbcFrom As C1.Win.C1List.C1Combo, ByVal tdbcTo As C1.Win.C1List.C1Combo, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDForDivision("", bUseUnicode)
        LoadDataSource(tdbcFrom, dt, bUseUnicode)
        LoadDataSource(tdbcTo, dt.DefaultView.ToTable, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Combo Tài khoản có chứa %
    ''' </summary>
    ''' <param name="tdbcFrom"></param>
    ''' <param name="tdbcTo"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAllForDivision(ByVal tdbcFrom As C1.Win.C1List.C1Combo, ByVal tdbcTo As C1.Win.C1List.C1Combo, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAllForDivision("", gbUnicode)
        LoadDataSource(tdbcFrom, dt, gbUnicode)
        LoadDataSource(tdbcTo, dt.DefaultView.ToTable, gbUnicode)
    End Sub

    ''' <summary>
    ''' Load Combo Tài khoản có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbc"></param>
    ''' <param name="sClauseWhere"> Điều kiện where (ví dụ: GroupID in ('1', '13'))</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDForDivision(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbc, ReturnTableAccountIDForDivision(sClauseWhere, gbUnicode), gbUnicode)
    End Sub

    ''' <summary>
    ''' Load Combo Tài khoản có chứa % có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbc"></param>
    ''' <param name="sClauseWhere"> Điều kiện where (ví dụ: GroupID in ('1', '13'))</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDAllForDivision(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbc, ReturnTableAccountIDAllForDivision(sClauseWhere, gbUnicode), gbUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 combo Tài khoản có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbcFrom"></param>
    ''' <param name="tdbcTo"></param>
    ''' <param name="sClauseWhere">Điều kiện where (ví dụ: GroupID in ('1', '13'))</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDForDivision(ByVal tdbcFrom As C1.Win.C1List.C1Combo, ByVal tdbcTo As C1.Win.C1List.C1Combo, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDForDivision(sClauseWhere, gbUnicode)
        LoadDataSource(tdbcFrom, dt, gbUnicode)
        LoadDataSource(tdbcTo, dt.Copy, gbUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 combo Tài khoản có chứa % có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbcFrom"></param>
    ''' <param name="tdbcTo"></param>
    ''' <param name="sClauseWhere">Điều kiện where (ví dụ: GroupID in ('1', '13'))</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDAllForDivision(ByVal tdbcFrom As C1.Win.C1List.C1Combo, ByVal tdbcTo As C1.Win.C1List.C1Combo, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAllForDivision(sClauseWhere, gbUnicode)
        LoadDataSource(tdbcFrom, dt, gbUnicode)
        LoadDataSource(tdbcTo, dt.DefaultView.ToTable, gbUnicode)
    End Sub

    ''' <summary>
    ''' Load combo Tài khoản (áp dụng cho màn hình có nhiều combo có cùng nguồn dữ liệu )
    ''' </summary>
    ''' <param name="tdbc"></param>
    ''' <param name="dt">Bảng dữ liệu tài khoản</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
        Public Sub LoadAccountIDForDivision(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal dt As DataTable, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbc, dt.DefaultView.ToTable, gbUnicode)
    End Sub

    ''' <summary>
    ''' Load Dropdown Tài khoản
    ''' </summary>
    ''' <param name="tdbd"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDForDivision(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbd, ReturnTableAccountIDForDivision("", gbUnicode), gbUnicode)
    End Sub

    ''' <summary>
    ''' Load Dropdown Tài khoản có chứa %
    ''' </summary>
    ''' <param name="tdbd"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAllForDivision(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbd, ReturnTableAccountIDAllForDivision("", gbUnicode), gbUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Dropdown Tài khoản
    ''' </summary>
    ''' <param name="tdbdFrom"></param>
    ''' <param name="tdbdTo"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDForDivision(ByVal tdbdFrom As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdTo As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDForDivision("", gbUnicode)
        LoadDataSource(tdbdFrom, dt, gbUnicode)
        LoadDataSource(tdbdTo, dt.DefaultView.ToTable, gbUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Dropdown Tài khoản có chứa %
    ''' </summary>
    ''' <param name="tdbdFrom"></param>
    ''' <param name="tdbdTo"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAllForDivision(ByVal tdbdFrom As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdTo As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAllForDivision("", gbUnicode)
        LoadDataSource(tdbdFrom, dt, gbUnicode)
        LoadDataSource(tdbdTo, dt.DefaultView.ToTable, gbUnicode)
    End Sub

    ''' <summary>
    ''' Load Dropdown Tài khoản có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbd"></param>
    ''' <param name="sClauseWhere"> Điều kiện where (ví dụ: GroupID in ('1', '13'))</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDForDivision(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbd, ReturnTableAccountIDForDivision(sClauseWhere, gbUnicode), gbUnicode)
    End Sub

    ''' <summary>
    ''' Load Dropdown Tài khoản có chứa % có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbd"></param>
    ''' <param name="sClauseWhere"> Điều kiện where (ví dụ: GroupID in ('1', '13'))</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDAllForDivision(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbd, ReturnTableAccountIDAllForDivision(sClauseWhere, gbUnicode), gbUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Dropdown Tài khoản có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbdFrom"></param>
    ''' <param name="tdbdTo"></param>
    ''' <param name="sClauseWhere"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDForDivision(ByVal tdbdFrom As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdTo As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDForDivision(sClauseWhere, gbUnicode)
        LoadDataSource(tdbdFrom, dt, gbUnicode)
        LoadDataSource(tdbdTo, dt.DefaultView.ToTable, gbUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Dropdown Tài khoản có chứa % có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbdFrom"></param>
    ''' <param name="tdbdTo"></param>
    ''' <param name="sClauseWhere"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDAllForDivision(ByVal tdbdFrom As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdTo As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAllForDivision(sClauseWhere, gbUnicode)
        LoadDataSource(tdbdFrom, dt, gbUnicode)
        LoadDataSource(tdbdTo, dt.DefaultView.ToTable, gbUnicode)
    End Sub

    ''' <summary>
    ''' Load Dropdown Tài khoản (áp dụng cho màn hình có nhiều Dropdown có cùng nguồn dữ liệu)
    ''' </summary>
    ''' <param name="tdbd"></param>
    ''' <param name="dt">Bảng dữ liệu Tài khoản</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDForDivision(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal dt As DataTable, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbd, dt.Copy, gbUnicode)
    End Sub

#End Region

#Region "Đổ nguồn Tài khoản (Bao gồm Tài khoản trong bảng và ngoại bảng) kiểm tra Phân quyền theo Đơn vị"

    ''' <summary>
    ''' Trả ra Table Tài khoản có chứa % (bao gồm Tài khoản trong và ngoại bảng)
    ''' </summary>
    ''' <param name="sClauseWhere"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Private Function ReturnTableAccountIDAndOffAccountAllGeneralForDivision(ByVal sClauseWhere As String, ByVal bUseUnicode As Boolean, ByVal bAll As Boolean) As DataTable

        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, bUseUnicode)
        Dim sSQL As String = "--Do nguon Tai khoan" & IIf(bAll, " co %", "").ToString & " (gom TK trong va ngoai bang) " & vbCrLf
        If bAll Then
            sSQL &= "Select '%' as AccountID, " & sLanguage & " as AccountName, '' as GroupID, 0 as DisplayOrder " & vbCrLf
            sSQL &= "Union All " & vbCrLf
        End If
        sSQL &= "Select AccountID, " & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName", "AccountName01").ToString & sUnicode & " as AccountName, GroupID, 1 as DisplayOrder " & vbCrLf
        sSQL &= "From D90T0001 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 " & vbCrLf
        sSQL &= "And (StrDivisionID = '' OR CHARINDEX(" & SQLString(gsDivisionID) & ",StrDivisionID) > 0) " & vbCrLf
        If sClauseWhere <> "" Then
            sSQL &= "And (" & sClauseWhere & ") " & vbCrLf
        End If
        sSQL &= "Order By DisplayOrder, AccountID "

        Return ReturnDataTable(sSQL)
    End Function


    ''' <summary>
    ''' Trả ra Table Tài khoản (bao gồm Tài khoản trong và ngoại bảng)  kiểm tra Phân quyền theo Đơn vị
    ''' </summary>
    ''' <param name="sClauseWhere"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReturnTableAccountIDAndOffAccountForDivision(ByVal sClauseWhere As String, ByVal bUseUnicode As Boolean) As DataTable
        Return ReturnTableAccountIDAndOffAccountAllGeneralForDivision(sClauseWhere, bUseUnicode, False)
    End Function

    Public Function ReturnTableAccountIDAndOffAccountForDivision(ByVal sClauseWhere As String) As DataTable
        Return ReturnTableAccountIDAndOffAccountForDivision(sClauseWhere, False)
    End Function

    Public Function ReturnTableAccountIDAndOffAccountForDivision() As DataTable
        Return ReturnTableAccountIDAndOffAccountForDivision("", False)
    End Function

    ''' <summary>
    ''' Trả ra Table Tài khoản có chứa % (bao gồm Tài khoản trong và ngoại bảng)
    ''' </summary>
    ''' <param name="sClauseWhere"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReturnTableAccountIDAndOffAccountAllForDivision(ByVal sClauseWhere As String, ByVal bUseUnicode As Boolean) As DataTable
        Return ReturnTableAccountIDAndOffAccountAllGeneralForDivision(sClauseWhere, bUseUnicode, True)
    End Function

    Public Function ReturnTableAccountIDAndOffAccountAllForDivision(ByVal sClauseWhere As String) As DataTable
        Return ReturnTableAccountIDAndOffAccountAllForDivision(sClauseWhere, False)
    End Function

    Public Function ReturnTableAccountIDAndOffAccountAllForDivision() As DataTable
        Return ReturnTableAccountIDAndOffAccountAllForDivision("", False)
    End Function
    ''' <summary>
    ''' Load Combo Tài khoản (bao gồm Tài khoản trong và ngoại bảng)
    ''' </summary>
    ''' <param name="tdbc"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAndOffAccountForDivision(ByVal tdbc As C1.Win.C1List.C1Combo, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbc, ReturnTableAccountIDAndOffAccountForDivision("", bUseUnicode), bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load Combo Tài khoản có chứa % (bao gồm Tài khoản trong và ngoại bảng)
    ''' </summary>
    ''' <param name="tdbc"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAndOffAccountAllForDivision(ByVal tdbc As C1.Win.C1List.C1Combo, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbc, ReturnTableAccountIDAndOffAccountAllForDivision("", bUseUnicode), bUseUnicode)
    End Sub

    Public Sub LoadAccountIDAndOffAccountAllForDivision(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbc, ReturnTableAccountIDAndOffAccountAllForDivision(sClauseWhere, bUseUnicode), bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Combo Tài khoản (bao gồm Tài khoản trong và ngoại bảng)
    ''' </summary>
    ''' <param name="tdbcFrom"></param>
    ''' <param name="tdbcTo"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAndOffAccountForDivision(ByVal tdbcFrom As C1.Win.C1List.C1Combo, ByVal tdbcTo As C1.Win.C1List.C1Combo, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAndOffAccountForDivision("", bUseUnicode)
        LoadDataSource(tdbcFrom, dt, bUseUnicode)
        LoadDataSource(tdbcTo, dt.DefaultView.ToTable, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Combo Tài khoản có chứa % (bao gồm Tài khoản trong và ngoại bảng)
    ''' </summary>
    ''' <param name="tdbcFrom"></param>
    ''' <param name="tdbcTo"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAndOffAccountAllForDivision(ByVal tdbcFrom As C1.Win.C1List.C1Combo, ByVal tdbcTo As C1.Win.C1List.C1Combo, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAndOffAccountAllForDivision("", bUseUnicode)
        LoadDataSource(tdbcFrom, dt, bUseUnicode)
        LoadDataSource(tdbcTo, dt.DefaultView.ToTable, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load Combo Tài khoản (bao gồm Tài khoản trong và ngoại bảng) có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbc"></param>
    ''' <param name="sClauseWhere"> Điều kiện where (ví dụ: GroupID in ('1', '13'))</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDAndOffAccountForDivision(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbc, ReturnTableAccountIDAndOffAccountForDivision(sClauseWhere, bUseUnicode), bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 combo Tài khoản (bao gồm Tài khoản trong và ngoại bảng) có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbcFrom"></param>
    ''' <param name="tdbcTo"></param>
    ''' <param name="sClauseWhere"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDAndOffAccountForDivision(ByVal tdbcFrom As C1.Win.C1List.C1Combo, ByVal tdbcTo As C1.Win.C1List.C1Combo, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAndOffAccountForDivision(sClauseWhere, bUseUnicode)
        LoadDataSource(tdbcFrom, dt, bUseUnicode)
        LoadDataSource(tdbcTo, dt.DefaultView.ToTable, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 combo Tài khoản có chứa % (bao gồm Tài khoản trong và ngoại bảng) có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbcFrom"></param>
    ''' <param name="tdbcTo"></param>
    ''' <param name="sClauseWhere"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDAndOffAccountAllForDivision(ByVal tdbcFrom As C1.Win.C1List.C1Combo, ByVal tdbcTo As C1.Win.C1List.C1Combo, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAndOffAccountAllForDivision(sClauseWhere, bUseUnicode)
        LoadDataSource(tdbcFrom, dt, bUseUnicode)
        LoadDataSource(tdbcTo, dt.DefaultView.ToTable, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load Dropdown Tài khoản (bao gồm Tài khoản trong và ngoại bảng)
    ''' </summary>
    ''' <param name="tdbd"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAndOffAccountForDivision(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbd, ReturnTableAccountIDAndOffAccountForDivision("", bUseUnicode), bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load Dropdown Tài khoản có chứa % (bao gồm Tài khoản trong và ngoại bảng)
    ''' </summary>
    ''' <param name="tdbd"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAndOffAccountAllForDivision(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbd, ReturnTableAccountIDAndOffAccountAllForDivision("", bUseUnicode), bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Dropdown Tài khoản (bao gồm Tài khoản trong và ngoại bảng)
    ''' </summary>
    ''' <param name="tdbdFrom"></param>
    ''' <param name="tdbdTo"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAndOffAccountForDivision(ByVal tdbdFrom As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdTo As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAndOffAccountForDivision("", bUseUnicode)
        LoadDataSource(tdbdFrom, dt, bUseUnicode)
        LoadDataSource(tdbdTo, dt.DefaultView.ToTable, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Dropdown Tài khoản có chứa % (bao gồm Tài khoản trong và ngoại bảng)
    ''' </summary>
    ''' <param name="tdbdFrom"></param>
    ''' <param name="tdbdTo"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadAccountIDAndOffAccountAllForDivision(ByVal tdbdFrom As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdTo As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAndOffAccountAllForDivision("", bUseUnicode)
        LoadDataSource(tdbdFrom, dt, bUseUnicode)
        LoadDataSource(tdbdTo, dt.DefaultView.ToTable, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load Dropdown Tài khoản (bao gồm Tài khoản trong và ngoại bảng) có truyền thêm điều kiện Where 
    ''' </summary>
    ''' <param name="tdbd"></param>
    ''' <param name="sClauseWhere"> Điều kiện where (ví dụ: GroupID in ('1', '13'))</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDAndOffAccountForDivision(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbd, ReturnTableAccountIDAndOffAccountForDivision(sClauseWhere, bUseUnicode), bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load Dropdown Tài khoản có chứa % (bao gồm Tài khoản trong và ngoại bảng) có truyền thêm điều kiện Where 
    ''' </summary>
    ''' <param name="tdbd"></param>
    ''' <param name="sClauseWhere"> Điều kiện where (ví dụ: GroupID in ('1', '13'))</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDAndOffAccountAllForDivision(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        LoadDataSource(tdbd, ReturnTableAccountIDAndOffAccountAllForDivision(sClauseWhere, bUseUnicode), bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Dropdown Tài khoản (bao gồm Tài khoản trong và ngoại bảng) có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbdFrom"></param>
    ''' <param name="tdbdTo"></param>
    ''' <param name="sClauseWhere"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDAndOffAccountForDivision(ByVal tdbdFrom As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdTo As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAndOffAccountForDivision(sClauseWhere, bUseUnicode)
        LoadDataSource(tdbdFrom, dt, bUseUnicode)
        LoadDataSource(tdbdTo, dt.DefaultView.ToTable, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Load 2 Dropdown Tài khoản có chứa % (bao gồm Tài khoản trong và ngoại bảng) có truyền thêm điều kiện Where
    ''' </summary>
    ''' <param name="tdbdFrom"></param>
    ''' <param name="tdbdTo"></param>
    ''' <param name="sClauseWhere"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
   Public Sub LoadAccountIDAndOffAccountAllForDivision(ByVal tdbdFrom As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdTo As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sClauseWhere As String, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        dt = ReturnTableAccountIDAndOffAccountAllForDivision(sClauseWhere, bUseUnicode)
        LoadDataSource(tdbdFrom, dt, bUseUnicode)
        LoadDataSource(tdbdTo, dt.DefaultView.ToTable, bUseUnicode)
    End Sub

#End Region

End Module
