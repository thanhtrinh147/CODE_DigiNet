'#-------------------------------------------------------------------------------------
'# Created User: Thiên Huỳnh
'# Created Date: 18/07/2008 2:25:08 PM
'# Modify User: Minh Hòa
'# Modify Date: 19/11/2013
'# Description: Xuất dữ liệu ra Excel
'# Bổ sung CultureInfo
'# Sửa lại giá trị ngày khi xuất ra Excel
'# Sửa lỗi không xuất được thông báo trên Office2007
'# Sửa lỗi xuất 2 lần khi chọn vào Chuyển Unicode
'# Sửa hàm LoadTDBDropDown, load dropdown tdbdFormat tăng từ 5 lên 9 
'# Bổ sung set màu của Phương viết
'# Sửa hàm SetCellStyle: 19/11/2013
'# CheckInvalidExport: tách sheet khi xuất excel 18/07/2014
'#-------------------------------------------------------------------------------------

Imports C1.C1Excel
Imports System
Imports System.Text
Imports Microsoft.Office.Interop
Imports System.Windows.Forms

Public Class D99F2222

#Region "Const of tdbg - Total of Columns: 15"
    Private Const COL_OrderNo As Integer = 0        ' STT
    Private Const COL_Description As Integer = 1    ' Cột dữ liệu
    Private Const COL_IsUsed As Integer = 2         ' Chọn
    Private Const COL_IsUnicode As Integer = 3      ' Chuyển Unicode
    Private Const COL_NumberFormat As Integer = 4   ' Định dạng
    Private Const COL_DataType As Integer = 5       ' DataType
    Private Const COL_FieldName As Integer = 6      ' FieldName
    Private Const COL_Grouped As Integer = 7        ' Grouped
    Private Const COL_IsSum As Integer = 8          ' Tính tổng
    Private Const COL_IsDateTime As Integer = 9     ' IsDateTime
    Private Const COL_IsExport As Integer = 10      ' IsExport
    Private Const COL_FooterText As Integer = 11    ' FooterText
    Private Const COL_IsMerge As Integer = 12       ' IsMerge
    Private Const COL_MergeRelative As Integer = 13 ' MergeRelative
    Private Const COL_Format As Integer = 14        ' Format
#End Region

#Region "Const of tdbgGroup"
    Private Const COL1_GroupFieldName As Integer = 0     ' GroupFieldName
    Private Const COL1_GroupFieldNameDesc As Integer = 1 ' Nhóm
    Private Const COL1_ExcelFunction As Integer = 2      ' Hàm
#End Region

#Region "Const of tdbgSubTotals"
    Private Const COL2_GroupFieldName As Integer = 0 ' GroupFieldName
    Private Const COL2_ExcelFunction As Integer = 1  ' ExcelFunction
    Private Const COL2_FieldName As Integer = 2      ' FieldName
    Private Const COL2_FieldNameDesc As Integer = 3  ' Cột hiển thị Subtotals
    Private Const COL2_IsGroup As Integer = 4        ' IsGroup
#End Region

#Region "Const of tdbgColumn"
    Private Const COL3_FieldName As Integer = 0     ' FieldName
    Private Const COL3_FieldNameDesc As Integer = 1 ' Cột dữ liệu
#End Region

#Region "Const of tdbgData"
    Private Const COL5_FieldName As Integer = 0     ' FieldName
    Private Const COL5_FieldNameDesc As Integer = 1 ' Cột dữ liệu
    Private Const COL5_ExcelFunction As Integer = 2 ' Hàm
#End Region

#Region "Const of tdbgRow"
    Private Const COL4_FieldName As Integer = 0     ' FieldName
    Private Const COL4_FieldNameDesc As Integer = 1 ' Cột dữ liệu
#End Region

#Region "Variabled And Property"
    Private arrDisabledColumn As New ArrayList
    Friend WithEvents C1XLBook1 As New C1.C1Excel.C1XLBook
    Private bUnicode As Boolean = False
    Private bCheckD91T2021 As Boolean
    Private _dtExportTable As DataTable
    Private _FormState As EnumFormState
    Private sFormName As String = ""
    Private dtExcelTmp As DataTable 'Dùng để đổ các Template
    Dim dtExportTmp As DataTable 'Nguồn dữ liệu xuất excel
    Dim sSort As String = "" 'Chuỗi sort cho table  dtExportTmp
    Private bHeadClick As Boolean = True
    Private bSum As Boolean = True

    Dim dtGrid As New DataTable 'Để đổ nguồn cho Grid ở TH Sửa

    Dim dtD91T2023 As New DataTable 'Để đổ nguồn cho Grid ở SubTotals và PivotTable
    Dim dtSubTotals As New DataTable() 'Để đổ nguồn cho lươí dạng SubTotal
    Dim dtPivot As New DataTable() 'Để đổ nguồn cho lươí dạng PivotTable
    Dim iSheetData As Integer = 0 'Index cua Sheet xuat data 
    Dim iSheetPivot As Integer = 0 'Index cua Sheet xuat pivot

    Dim colDistinct() As String = {"GroupFieldName", "GroupFieldNameDesc", "ExcelFunction"}
    Dim btdbgGroup_RowColChange As Boolean = False

    Dim EXL As Excel.Application
    Dim bIsLoadEXL As Boolean = False
    Dim MaxRowExcel As Integer = 65000 ' Số dòng tối đa của 1 Sheet trong Excel
    Dim iMaxSheet As Integer = 1
    Private DEFAULT_PATH_OUT As String = Application.StartupPath & "\Temp"

    ''' <summary>
    ''' _modeVB6 = 1: màn hình VB6; 0 màn hình .NET
    ''' </summary>
    ''' <remarks></remarks>
    Private _modeVB6 As Integer
    Public WriteOnly Property ModeVB6() As Integer
        Set(ByVal Value As Integer)
            _modeVB6 = Value
        End Set
    End Property

    Private _formID As String = ""
    Public Property FormID() As String
        Get
            Return _formID
        End Get
        Set(ByVal Value As String)
            _formID = value
        End Set
    End Property

    Public WriteOnly Property dtExportTable() As DataTable
        Set(ByVal value As DataTable)
            _dtExportTable = value
        End Set
    End Property

    Private _dtLoadGrid As DataTable
    Public WriteOnly Property dtLoadGrid() As DataTable
        Set(ByVal Value As DataTable)
            _dtLoadGrid = Value
        End Set
    End Property

    Private _groupColumns As String()
    Public WriteOnly Property GroupColumns() As String()
        Set(ByVal Value As String())
            _groupColumns = Value
        End Set
    End Property

    Private _useUnicode As Boolean
    Public WriteOnly Property UseUnicode() As Boolean
        Set(ByVal Value As Boolean)
            _useUnicode = Value
        End Set
    End Property

    Private _dtMaster As DataTable
    Public WriteOnly Property dtMaster() As DataTable
        Set(ByVal Value As DataTable)
            _dtMaster = Value
            If _dtMaster Is Nothing Then Exit Property
            _dtMaster.DefaultView.Sort = "TabIndex"
            LoadDataSource(tdbgM, _dtMaster, gbUnicode)
            FooterTotalGrid(tdbgM, COLM_Description)
        End Set
    End Property

#End Region

#Region "From Load"

    Public Sub New()
        '*** 07/07/2010: Khởi tạo Thread khi gọi ứng dụng của Excel
        If bIsLoadEXL = False Then
            Dim thr As Threading.Thread = New Threading.Thread(AddressOf BackProcessLoad)
            thr.Start()
        End If
        InitializeComponent()
    End Sub

    Private Sub LoadTDBDropDown()
        Dim dtFormat As New DataTable() ' Table chứa các cột Format số lẻ
        dtFormat.Columns.Add("DecimalNo", GetType(String))
        For i As Integer = 0 To 9
            dtFormat.Rows.Add(New Object() {i})
        Next
        LoadDataSource(tdbdFormat, dtFormat)

        Dim dtFunc As New DataTable()
        dtFunc.Columns.Add("Code", GetType(String))
        dtFunc.Columns.Add("Description", GetType(String))

        Dim code, desc As String
        code = "0"
        desc = "Sum"
        dtFunc.Rows.Add(New Object() {code, desc})

        code = "1"
        desc = "Count"
        dtFunc.Rows.Add(New Object() {code, desc})

        LoadDataSource(tdbdFunctionGroup, dtFunc)
        LoadDataSource(tdbdFunctionData, dtFunc.Copy)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        Dim dtTmp As DataTable
        'Load tdbcExcelTemplateID
        sSQL = "Select '+' As ExcelTemplateID Union All Select Distinct ExcelTemplateID From D91T2021 WITH(NOLOCK) "
        sSQL &= " Where ModuleID = " & SQLString(sFormName.Substring(1, 2)) & " And FormID = " & SQLString(sFormName)
        'Update 16/08/2010: Nhập Unicode lưu template khác, Vni template khác
        If _useUnicode Then
            sSQL &= " And FieldNameU <> ''"
        Else
            sSQL &= " And FieldName <> ''"
        End If
        sSQL &= " Order By ExcelTemplateID;"
        dtTmp = ReturnDataTable(sSQL)
        bCheckD91T2021 = dtTmp.Rows.Count > 1
        LoadDataSource(tdbcExcelTemplateID, dtTmp)

        'Lấy template cho Dạng xuất phức tạp
        LoadTableD91T2023()
        'Mới: tạo bảng tạm để load lưới cho màn hình .NET
        If _modeVB6 <> 1 And bCheckD91T2021 Then
            CreateTableGrid()
        End If
    End Sub

    Private Sub CreateTableGrid()
        Dim sSQL As String
        'Tạo Table để đổ nguồn cho Lưới
        sSQL = "Select ExcelTemplateID, FieldName" & UnicodeJoin(_useUnicode) & " as FieldName, '' As Description, OrderNum, 0 As OrderNo," & vbCrLf
        sSQL &= "'' As DataType, Convert(Bit,1) As IsUsed, Convert(Bit,IsUnicode) As IsUnicode, NumberFormat, " & vbCrLf
        sSQL &= " DisplayColumn, DisplayRow, Path, SheetExcel, ShowColTitle, IsExportType, ExportType, " & vbCrLf
        sSQL &= " SubtotalRow, SubtotalColumn, GrandTotalRow, GrandTotalColumn, " & vbCrLf
        sSQL &= "Title" & UnicodeJoin(_useUnicode) & " as Title, " & vbCrLf
        sSQL &= "CheckValue, UnCheckValue, PageOrientation, PagePercent, PageSize, IsAutoSizeColumn,IsMarkTimer,PathOut, IsNoFormula " & vbCrLf
        sSQL &= "From D91T2021 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where ModuleID = " & SQLString(sFormName.Substring(1, 2)) & " And FormID = " & SQLString(sFormName) & vbCrLf
        'Update 16/08/2010: Nhập Unicode lưu template khác, Vni template khác
        If _useUnicode Then
            sSQL &= " And FieldNameU <> ''"
        Else
            sSQL &= " And FieldName <> ''"
        End If

        sSQL &= "Order By OrderNum"
        dtExcelTmp = ReturnDataTable(sSQL)
    End Sub

    Private Sub CreateExcelColTable()
        Dim dtColExcel As New DataTable ' Table chứa các cột của Excel
        dtColExcel.Columns.Add("ColNum", GetType(String))
        dtColExcel.Columns.Add("ColChar", GetType(String))

        Dim aArrayLetter() As String
        aArrayLetter = Microsoft.VisualBasic.Split("A B C D E F G H I J K L M N O P Q R S T U V W X Y Z", " ")

        For i As Integer = 1 To 26
            dtColExcel.Rows.Add(New Object() {i.ToString, aArrayLetter(i - 1)})
        Next

        Dim i1, i2 As Integer
        i1 = 0
        i2 = 0
        For i As Integer = 27 To 256
            dtColExcel.Rows.Add(New Object() {i.ToString, aArrayLetter(i1) & aArrayLetter(i2)})
            i2 += 1
            If i2 = 26 Then
                i1 += 1
                i2 = 0
            End If
        Next
        LoadDataSource(tdbcColExcel, dtColExcel)
        tdbcColExcel.SelectedIndex = 0
    End Sub

    Private Sub CreateGridVB6()
        Dim sSQL As String
        sSQL = SQLStoreD91P2020()
        dtGrid = ReturnDataTable(sSQL)
        'Thêm các cột không có trong database
        dtGrid.Columns.Add("Obligatory", GetType(System.Byte))
        dtGrid.Columns.Add("Grouped", GetType(System.Byte))
        dtGrid.Columns.Add("IsSum", GetType(System.Byte))
        dtGrid.Columns.Add("IsDateTime", GetType(System.Byte))
        dtGrid.Columns.Add("IsExport", GetType(System.Byte))
        'Insert dữ liệu cho các cột mới
        Dim dr As DataRow
        For row As Integer = 0 To dtGrid.Rows.Count - 1
            dr = dtGrid.Rows(row)
            dr("Obligatory") = "0"
            dr("Grouped") = "0"
            dr("IsSum") = "0"
            dr("IsDateTime") = "0"
            dr("IsExport") = "0"
        Next

        'Load dữ liệu vào lưới
        If chkShowAll.Checked Then
            ReturnTableFilterRow(dtGrid, "")
        Else
            ReturnTableFilterRow(dtGrid, "IsUsed = 1")
        End If
        LoadDataSource(tdbg, dtGrid)

        If tdbcExcelTemplateID.Text <> "" And tdbcExcelTemplateID.Text <> "+" Then 'If _FormState <> EnumFormState.FormAdd Then
            LoadMaster(dtGrid)
            'Load Xuất Theo dạng phức tạp
            LoadSubTotalsAndPivotTable(1)
        Else
            'Load Xuất Theo dạng phức tạp
            LoadSubTotalsAndPivotTable(0)
        End If
    End Sub

    Private Sub CreateGrid()
        Try
            Dim dtLoadAddnew As DataTable 'Để đổ nguồn cho Grid ở TH Thêm mới
            dtLoadAddnew = _dtLoadGrid.Copy
            If tdbcExcelTemplateID.Text <> "" And tdbcExcelTemplateID.Text <> "+" Then
                dtGrid = ReturnTableFilter(dtExcelTmp, "ExcelTemplateID = " & SQLString(tdbcExcelTemplateID.Text), True)
                LoadMaster(dtGrid)

                Dim iCountRow As Integer = dtGrid.Rows.Count 'Giữ lại những dòng có IsUsed = True 
                'Đẩy cột NumberFormat từ bảng dtLoadEdit vào dtLoadAddnew
                For i As Integer = 0 To dtLoadAddnew.Rows.Count - 1
                    For j As Integer = 0 To dtGrid.Rows.Count - 1
                        If dtLoadAddnew.Rows(i).Item("FieldName").ToString = dtGrid.Rows(j).Item("FieldName").ToString Then
                            dtLoadAddnew.Rows(i).Item("NumberFormat") = dtGrid.Rows(j).Item("NumberFormat")
                            Exit For
                        End If
                    Next
                Next

                'Merge 2 bảng lại để lấy đủ dữ liệu theo thứ tự
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("FieldName")}
                dtGrid.Merge(dtLoadAddnew, False, MissingSchemaAction.AddWithKey)

                'Set lại cột IsUsed = False cho những dòng mới
                For i As Integer = iCountRow To dtGrid.Rows.Count - 1
                    If dtGrid.Rows(i).Item("Grouped").ToString = "0" Then
                        dtGrid.Rows(i).Item("IsUsed") = False
                    End If
                Next

                'Xóa những cột có Diễn giải =""
                Dim i1 As Integer = 0
                While i1 < dtGrid.Rows.Count
                    If dtGrid.Rows(i1).Item("Description").ToString = "" Then
                        dtGrid.Rows(i1).Delete()
                    Else
                        i1 += 1
                    End If
                End While

                'Load dữ liệu vào lưới
                If chkShowAll.Checked Then
                    ReturnTableFilterRow(dtGrid, "")
                Else
                    ReturnTableFilterRow(dtGrid, "IsUsed = 1")
                End If
                LoadDataGrid(dtGrid)
                '************************************
                'Load Xuất Theo dạng phức tạp
                LoadSubTotalsAndPivotTable(1)
            Else 'Thêm mới
                ResetDataMaster()
                dtGrid = dtLoadAddnew
                LoadDataGrid(dtGrid)
                '************************************
                'Load Xuất Theo dạng phức tạp
                LoadSubTotalsAndPivotTable(0)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub ReturnTableFilterRow(ByVal dt As DataTable, ByVal sWhereClause As String)
        'Nếu muốn lấy lại DataTable gốc thì gán sWhereClause = ""
        dt.DefaultView.RowFilter = sWhereClause
    End Sub

    Private Sub LoadSubTotalsAndPivotTable(ByVal iMode As Integer)
        'iMode =0: Thêm mới; iMode =1: Sửa
        If iMode = 0 Then 'Thêm mới
            dtSubTotals = dtD91T2023.Clone
            dtPivot = dtD91T2023.Clone
            LoadNewTableSubTotal()
            LoadNewTablePivot()
        Else 'Sửa
            If dtD91T2023.Rows.Count = 0 Then 'Bảng Template lưu cho dạng Xuất phức tạp chưa có dữ liệu
                dtSubTotals = dtD91T2023.Clone
                dtPivot = dtD91T2023.Clone
                LoadNewTableSubTotal()
                LoadNewTablePivot()
            Else
                Dim dtD91T2023Load As DataTable
                dtD91T2023Load = ReturnTableFilter(dtD91T2023, "ExcelTemplateID = " & SQLString(tdbcExcelTemplateID.Text), True)
                If dtD91T2023Load.Rows.Count > 0 Then
                    RemoveFieldName(dtD91T2023Load) 'Remove các field có trong Template những không có trong tdbg
                    'Load Subtotals
                    dtSubTotals = ReturnTableFilter(dtD91T2023Load, "ExportType = 0", True)
                    If dtSubTotals.Rows.Count > 0 Then
                        LoadEditTableSubTotal()
                    Else
                        LoadNewTableSubTotal()
                    End If
                    'Load PivotTable
                    dtPivot = ReturnTableFilter(dtD91T2023Load, "ExportType = 1")
                    If dtPivot.Rows.Count > 0 Then
                        LoadEditTablePivot()
                    Else
                        LoadNewTablePivot()
                    End If
                Else
                    dtSubTotals = dtD91T2023.Clone
                    dtPivot = dtD91T2023.Clone
                    LoadNewTableSubTotal()
                    LoadNewTablePivot()
                End If
            End If
        End If
    End Sub

    Private Sub RemoveFieldName(ByRef dtTemp As DataTable)
        'Kiểm tra dữ liệu của template có trong lưới xuất excel không
        Dim bFlag As Boolean = False
        Dim row As Integer = 0

        'Kiểm tra GroupFieldName, nếu tìm thấy trong lưới xuất Excel thì gán lại tên  GroupFieldNameDesc        
        Dim dtDistinct As DataTable
        dtDistinct = dtTemp.DefaultView.ToTable(True, colDistinct)
        For row = 0 To dtDistinct.Rows.Count - 1
            bFlag = False
            If dtDistinct.Rows(row).Item("GroupFieldName").ToString <> "" Then
                For i As Integer = 0 To tdbg.RowCount - 1
                    If L3Bool(tdbg(i, COL_IsUsed)) = True Then
                        If dtDistinct.Rows(row).Item("GroupFieldName").ToString = tdbg(i, COL_FieldName).ToString Then
                            bFlag = True
                            tdbg(i, COL_IsExport) = 1
                            'gán lại tên GroupFieldNameDesc cho các cột Group
                            Dim dr() As DataRow = dtTemp.Select("GroupFieldName = " & SQLString(dtDistinct.Rows(row).Item("GroupFieldName").ToString))
                            For j As Integer = 0 To dr.Length - 1
                                dr(j).Item("GroupFieldNameDesc") = tdbg(i, COL_Description).ToString
                                'Update lại cho table
                                dtTemp.Rows(j).SetParentRow(dr(j))
                            Next
                            Exit For
                        End If
                    End If
                Next

                If Not bFlag Then
                    Dim dr() As DataRow = dtTemp.Select("GroupFieldName = " & SQLString(dtDistinct.Rows(row).Item("GroupFieldName").ToString))
                    For i As Integer = 0 To dr.Length - 1
                        dtTemp.Rows.Remove(dr(i))
                    Next
                End If
            End If
        Next

        'Kiểm tra FieldName, nếu tìm thấy trong lưới xuất Excel thì gán lại tên  FieldNameDesc        
        Dim sCol() As String = {"FieldName"}
        dtDistinct = dtTemp.DefaultView.ToTable(True, sCol)
        bFlag = False
        row = 0
        For row = 0 To dtDistinct.Rows.Count - 1
            bFlag = False
            For i As Integer = 0 To tdbg.RowCount - 1
                If L3Bool(tdbg(i, COL_IsUsed)) = True Then
                    If dtDistinct.Rows(row).Item("FieldName").ToString = tdbg(i, COL_FieldName).ToString Then
                        bFlag = True
                        'gán lại tên FieldNameDesc  
                        Dim dr() As DataRow = dtTemp.Select("FieldName = " & SQLString(dtDistinct.Rows(row).Item("FieldName").ToString))
                        For j As Integer = 0 To dr.Length - 1
                            dr(j).Item("FieldNameDesc") = tdbg(i, COL_Description).ToString
                            'Update lại hàm cho table
                            dtTemp.Rows(j).SetParentRow(dr(j))
                            tdbg(i, COL_IsExport) = L3Int(tdbg(i, COL_IsExport)) + 1
                        Next
                        Exit For
                    End If
                End If
            Next

            If Not bFlag Then
                Dim dr() As DataRow = dtTemp.Select("FieldName = " & SQLString(dtDistinct.Rows(row).Item("FieldName").ToString))
                For i As Integer = 0 To dr.Length - 1
                    dtTemp.Rows.Remove(dr(i))
                Next
            End If
        Next
        tdbg.UpdateData()

    End Sub

    Private Sub LoadDataGrid(ByVal dt As DataTable)
        LoadDataSource(tdbg, dt, _useUnicode)
    End Sub

    Private Sub LoadGrid()
        If _modeVB6 = 1 Then
            CreateGridVB6()
        Else
            CreateGrid()
        End If
    End Sub

    Private Sub LoadNewTablePivot()
        'Load mặc định cho dạng PivotTable
        LoadDataSource(tdbgColumn, dtPivot.Copy, _useUnicode)
        LoadDataSource(tdbgRow, dtPivot.Copy, _useUnicode)
        LoadDataSource(tdbgData, dtPivot, _useUnicode)
    End Sub

    Private Sub LoadEditTablePivot()
        LoadDataSource(tdbgColumn, ReturnTableFilter(dtPivot, "DisplayType = 0", True), _useUnicode)
        LoadDataSource(tdbgRow, ReturnTableFilter(dtPivot, "DisplayType = 1", True), _useUnicode)
        LoadDataSource(tdbgData, ReturnTableFilter(dtPivot, "DisplayType = 2", True), _useUnicode)
    End Sub

    Private Sub LoadNewTableSubTotal()
        'Load mặc định cho dạng SubTotal
        Try
            If _groupColumns Is Nothing OrElse _groupColumns.Length < 1 Then ' Dùng luôn cho trường hợp VB6 (VB6 luôn luôn không có Group)
                LoadDataSource(tdbgGroup, dtSubTotals.Copy, _useUnicode)
                LoadDataSource(tdbgSubTotals, dtSubTotals.Copy, _useUnicode)
                Exit Sub
            End If

            'Gán các Group hiện có và Các cột Subtotals
            Dim iExportType, iDisplayType, OrderNum As Integer
            Dim ExcelFunction As Integer
            Dim GroupFieldName, GroupFieldNameDesc, FieldName, FieldNameDesc As String
            Dim iOrder As Integer = 0
            iDisplayType = 0
            iExportType = 0 'Dạng SubTotal
            OrderNum = 0
            bSum = True
            ExcelFunction = 0 'Hàm Sum
            GroupFieldNameDesc = ""

            For i As Integer = 0 To _groupColumns.Length - 1
                GroupFieldName = _groupColumns(i)
                If GroupFieldName = Nothing Then
                    Continue For
                End If

                iOrder = 0
                'Lấy GroupFieldNameDesc đúng vị trí
                For j As Integer = 0 To tdbg.RowCount - 1
                    If L3Bool(tdbg(j, COL_IsUsed)) = True Then
                        If tdbg(j, COL_FieldName).ToString = GroupFieldName Then
                            GroupFieldNameDesc = tdbg(j, COL_Description).ToString
                            tdbg(j, COL_IsExport) = L3Int(tdbg(j, COL_IsExport)) + 1
                            'Huỳnh Edit 26/05/2010: Không có Column tổng vẫn đổ nguồn cho tdbgGroup
                            FieldName = "" 'tdbg(j, COL_FieldName).ToString
                            FieldNameDesc = "" 'tdbg(j, COL_Description).ToString"
                            OrderNum = iOrder + 1
                            dtSubTotals.PrimaryKey = New DataColumn() {dtSubTotals.Columns("GroupFieldName"), dtSubTotals.Columns("FieldName")}
                            dtSubTotals.Rows.Add(New Object() {tdbcExcelTemplateID.Text, iExportType, iDisplayType, OrderNum, ExcelFunction, _
                            GroupFieldName, FieldName, GroupFieldNameDesc, FieldNameDesc})
                            iOrder += 1
                            '---------------------------------------------------
                            Exit For
                        End If
                    End If
                Next

                iOrder = 0
                OrderNum = 0

                'Add những cột có Sum để load dữ liệu cho SubTotal
                For j As Integer = 0 To tdbg.RowCount - 1
                    If L3Bool(tdbg(j, COL_IsUsed)) = True And L3Int(tdbg(j, COL_IsSum).ToString) = 1 Then
                        FieldName = tdbg(j, COL_FieldName).ToString
                        FieldNameDesc = tdbg(j, COL_Description).ToString
                        OrderNum = iOrder + 1
                        dtSubTotals.PrimaryKey = New DataColumn() {dtSubTotals.Columns("GroupFieldName"), dtSubTotals.Columns("FieldName")}
                        dtSubTotals.Rows.Add(New Object() {tdbcExcelTemplateID.Text, iExportType, iDisplayType, OrderNum, ExcelFunction, _
                        GroupFieldName, FieldName, GroupFieldNameDesc, FieldNameDesc})

                        tdbg(j, COL_IsExport) = L3Int(tdbg(j, COL_IsExport)) + 1
                        iOrder += 1
                    End If
                Next
            Next

            btdbgGroup_RowColChange = True

            'Nếu không có cột Sum thì set lại hàm thành Count
            If iOrder = 0 AndAlso dtSubTotals IsNot Nothing AndAlso dtSubTotals.Rows.Count > 0 Then
                ExcelFunction = 1 'Hàm Count
                bSum = False
                For i As Integer = 0 To dtSubTotals.Rows.Count - 1
                    dtSubTotals.Rows(i).Item("ExcelFunction") = ExcelFunction
                Next
            End If
            'Dùng Distinct để lấy dữ liệu cho Group
            Dim dtG As DataTable
            dtG = dtSubTotals.DefaultView.ToTable(True, colDistinct)
            LoadDataSource(tdbgGroup, dtG, _useUnicode)
        Catch ex As Exception
            MessageBox.Show("Error!")
        End Try
    End Sub

    Private Sub LoadEditTableSubTotal()
        btdbgGroup_RowColChange = True
        'Dùng Distinct để lấy dữ liệu cho Group, Gán lại dữ liệu cho GroupFieldNameDesc
        Dim dtG As DataTable
        dtG = dtSubTotals.DefaultView.ToTable(True, colDistinct)
        LoadDataSource(tdbgGroup, dtG, _useUnicode)

        tdbgGroup_RowColChange(Nothing, Nothing)
    End Sub

    Private Sub D99F2222_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        End If
        If e.Alt Then
            If e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1 Then
                tabMain.SelectedTab = TabInfo
                Application.DoEvents()
                If tdbcExcelTemplateID.Visible Then
                    tdbcExcelTemplateID.Focus()
                Else
                    txtExcelTemplateID.Focus()
                End If
                Application.DoEvents()
            ElseIf e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2 Then
                Application.DoEvents()
                tabMain.SelectedTab = TabAdvance
                txtChecked.Focus()
                Application.DoEvents()
            End If
        End If
    End Sub

    Private Sub D99F2222_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If _dtMaster Is Nothing OrElse _dtMaster.Rows.Count = 0 Then tabDisplay.TabPages.Remove(TabPage2)
        ResetColorGrid(tdbgM)
        SetBackColorObligatory()
        chkIsExportType.Checked = False
        chkIsExportType_Click(Nothing, Nothing)
        cboDefaultSheet.Enabled = False
        tdbg_LockedColumns()
        GetFormName()
        Loadlanguage()
        InputbyUnicode(Me, _useUnicode)
        CreateExcelColTable()
        LoadTDBDropDown()
        LoadTDBCombo()

        'Update 18/10/2010: kiểm tra nhập Mã
        CheckIdTextBox(New TextBox() {txtExcelTemplateID, txtChecked, txtUnChecked})


        If Not bCheckD91T2021 Then
            _FormState = EnumFormState.FormAdd
            btnDelete.Enabled = False
            tdbcExcelTemplateID.Visible = False
            txtExcelTemplateID.Visible = True
            txtExcelTemplateID.Text = ""
            chkIsMarkTimer.Enabled = False
            'Update 07/07/2010: Thêm mới thì Check, Sửa thì UnCheck
            chkShowAll.Checked = True
            LoadGrid()
        Else
            _FormState = EnumFormState.FormEdit
            'Update 07/07/2010: Thêm mới thì Check, Sửa thì UnCheck
            chkShowAll.Checked = False
            txtExcelTemplateID.Visible = False
            tdbcExcelTemplateID.SelectedIndex = 1
        End If

        If _useUnicode Then
            chkConvertUnicode.Checked = True
            chkConvertUnicode.Visible = False
            tdbg.Splits(0).DisplayColumns(COL_Description).Style.Font = FontUnicode()
        End If

        tdbgGroup_LockedColumns()
        tdbgSubTotals_LockedColumns()
        tdbgColumn_LockedColumns()
        tdbgRow_LockedColumns()
        tdbgData_LockedColumns()

        dudAdjust.SelectedItem = "100"
        cboPageSize.Text = "A4"
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Xuat_Excel") & UnicodeCaption(_useUnicode) 'XuÊt Excel 
        '================================================================ 
        lblColExcel.Text = rl3("Cot_hien_thi") 'Cột hiển thị
        lblRowExcel.Text = rl3("Dong_hien_thi") 'Dòng hiển thị
        'lblPathIn.Text = rl3("Duong_dan") 'Đường dẫn
        lblExcelTemplateID.Text = rl3("Mau_xuat_Excel")
        lblColumn.Text = rl3("Cot") '"Cột"
        If geLanguage = EnumLanguage.Vietnamese Then
            lblRow.Text = "Dòng"
        Else
            lblRow.Text = "Row"
        End If
        lblData.Text = rl3("Du_lieu") '"Dữ liệu"
        lblMessage.Text = rl3("Dung_chuot_de_di_chuyen_dong_trong_moi_luoi") '"Dùng chuột để di chuyển dòng trong mỗi lưới"
        '================================================================ 
        grpShowPivot.Text = rl3("Hien_thi") '"Hiển thị"
        '================================================================ 
        chkDisplayTitle.Text = rl3("Hien_thi_tieu_de_cot") 'Hiển thị tiêu đề cột
        chkConvertUnicode.Text = rl3("Chuyen_Unicode")
        chkShowAll.Text = rl3("Hien_thi_tat_ca")
        chkIsExportType.Text = rl3("Dang_xuat") '"Dạng xuất"
        chkSubTotalsRow.Text = rl3("Tong_cua_tung_nhom_dong") '"Tổng của từng nhóm dòng"
        chkSubTotalsCol.Text = rl3("Tong_cua_tung_nhom_cot") '"Tổng của từng nhóm cột"
        chkGrandRow.Text = rl3("Tong_cua_tong_dong") '"Tổng của tổng dòng"
        chkGrandColumn.Text = rL3("Tong_cua_tong_cot") '"Tổng của tổng cột"
        chkShowSum.Text = rL3("Hien_thi_dong_tong") '"Hiển thị dòng tổng"
        chkIsAutoSizeColumn.Text = rL3("Tu_dong_gian_cot") '"Tự động giãn cột
        chkIsNoFormula.Text = "Bỏ qua cột có công thức"
        '================================================================ 
        btnExport.Text = rl3("Xuat__Excel") 'Xuất &Excel
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnDelete.Text = rl3("_Xoa") '&Xóa
        '================================================================ 
        'tdbg.Columns("OrderNo").Caption = rl3("STT")
        tdbg.Columns("Description").Caption = rl3("Cot_du_lieu") 'Cột dữ liệu
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        'tdbg.Columns("IsUnicode").Caption = rl3("Chuyen_Unicode") 'Chọn
        tdbg.Columns("NumberFormat").Caption = rl3("Dinh_dang") 'Chọn
        '================================================================ 
        tdbgGroup.Columns("GroupFieldNameDesc").Caption = rl3("Cot_du_lieu") 'Cột dữ liệu

        Dim sFunction As String
        If geLanguage = EnumLanguage.Vietnamese Then
            sFunction = "Hàm"
        Else
            sFunction = "Function"
        End If

        tdbgGroup.Columns("ExcelFunction").Caption = sFunction
        '================================================================ 
        tdbgSubTotals.Columns("FieldNameDesc").Caption = rl3("Cot_hien_thi_Subtotals") '"Cột hiển thị Subtotals"
        '================================================================ 
        tdbgColumn.Columns("FieldNameDesc").Caption = rl3("Cot_du_lieu") 'Cột dữ liệu
        '================================================================ 
        tdbgRow.Columns("FieldNameDesc").Caption = rl3("Cot_du_lieu") 'Cột dữ liệu
        '================================================================ 
        tdbgData.Columns("FieldNameDesc").Caption = rl3("Cot_du_lieu") 'Cột dữ liệu
        tdbgData.Columns("ExcelFunction").Caption = sFunction '"Hàm"

        lblTitle.Text = rl3("Tieu_de")
        TabInfo.Text = "1. " & rl3("Thong_tin_chung")
        TabAdvance.Text = "2. " & rl3("Nang_cao")
        If geLanguage = EnumLanguage.Vietnamese Then
            'lblSetupCheck.Text = "Thiết lập dữ liệu xuất cho giá trị của cột tùy chọn"
            'lblApperance.Text = "Thiết lập trang in"
            optPortrait.Text = "Thẳng đứng"
            optLandscape.Text = "Nằm ngang"
            lblAdjust.Text = "Kích cỡ"
            lblSizePecent.Text = "% kích cỡ chuẩn"
            lblPageSize.Text = "Khổ giấy"
        Else
            'lblSetupCheck.Text = "Setup value for Checkbox data column"
            'lblApperance.Text = "Page setup"
            optPortrait.Text = "Portrait"
            optLandscape.Text = "Landscape"
            lblAdjust.Text = "Scaling"
            'grpAdjust.Width = 533
            'grpAdjust.Left = txtChecked.Left
            lblSizePecent.Text = "% normal size"
            lblPageSize.Text = "Paper size"
        End If

        TabPage1.Text = "1. " & rL3("Cot_du_lieu")
        TabPage2.Text = "2. " & rL3("Danh_sach_tham_so")

        tdbgM.Columns(COLM_Description).Caption = rL3("Noi_dung")
        tdbgM.Columns(COLM_FieldExcel).Caption = rL3("Tham_so")
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcExcelTemplateID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtExcelTemplateID.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcColExcel.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtRow.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadMaster(ByVal dt As DataTable)
        If dt.Rows.Count = 0 Then
            txtPathOut.Text = DEFAULT_PATH_OUT
            lblSampleFileName.Text = txtPathOut.Text & "\Data.xls"
            Exit Sub
        End If


        Dim sPath As String = ""
        Dim sSheet As String = ""
        Dim dr As DataRow
        dr = dt.Rows(0)

        sPath = dr("Path").ToString
        sSheet = dr("SheetExcel").ToString
        chkConvertUnicode.Checked = L3Bool(dr("IsUnicode").ToString)
        chkDisplayTitle.Checked = L3Bool(dr("ShowColTitle").ToString)
        tdbcColExcel.Text = IIf(dr("DisplayColumn").ToString = "", "A", dr("DisplayColumn").ToString).ToString
        txtRow.Text = IIf(dr("DisplayRow").ToString = "", "1", dr("DisplayRow").ToString).ToString
        chkIsExportType.Checked = L3Bool(dr("IsExportType").ToString)
        chkIsExportType_Click(Nothing, Nothing)
        optSubTotals.Checked = Not L3Bool(dr("ExportType").ToString)
        optPivotTable.Checked = L3Bool(dr("ExportType").ToString)
        chkSubTotalsRow.Checked = L3Bool(dr("SubtotalRow").ToString)
        chkSubTotalsCol.Checked = L3Bool(dr("SubtotalColumn").ToString)
        chkGrandRow.Checked = L3Bool(dr("GrandTotalRow").ToString)
        chkGrandColumn.Checked = L3Bool(dr("GrandTotalColumn").ToString)
        txtTitle.Text = dr("Title").ToString

        txtChecked.Text = dr("CheckValue").ToString
        txtUnChecked.Text = dr("UnCheckValue").ToString
        optPortrait.Checked = Not L3Bool(dr("PageOrientation").ToString)
        optLandscape.Checked = L3Bool(dr("PageOrientation").ToString)
        dudAdjust.Text = dr("PagePercent").ToString
        cboPageSize.Text = dr("PageSize").ToString
        chkIsAutoSizeColumn.Checked = L3Bool(dr("IsAutoSizeColumn").ToString)
        chkIsNoFormula.Checked = L3Bool(dr("IsNoFormula"))

        If sPath = "" Then
            txtPathIn.Text = ""
            cboDefaultSheet.Items.Clear()
            cboDefaultSheet.Text = ""
            cboDefaultSheet.Enabled = False

            chkIsMarkTimer.Enabled = False
            lblSampleFileName.Visible = False

            txtPathOut.Text = DEFAULT_PATH_OUT
            lblSampleFileName.Text = txtPathOut.Text & "\Data.xls"
        Else
            txtPathIn.Text = sPath

            txtPathOut.Text = L3String(dr("PathOut"))
            If txtPathOut.Text.Trim = "" Then txtPathOut.Text = DEFAULT_PATH_OUT
            cboDefaultSheet.Text = sSheet
            cboDefaultSheet.Enabled = True

            chkIsMarkTimer.Enabled = True
            chkIsMarkTimer.Checked = L3Bool(dr("IsMarkTimer"))
            lblSampleFileName.Visible = True

            chkFileTimer_Click(Nothing, Nothing)
            GetNameSheets()
            txtPathIn.Tag = txtPathIn.Text
        End If
    End Sub

    Private Sub LoadTableD91T2023()
        'Tạo Table để đổ nguồn cho Lưới SubTotals và PivotTable
        Dim sSQL As String
        'sSQL = "Select ExcelTemplateID, ExportType, DisplayType, GroupFieldName, GroupFieldNameU,  OrderNum, FieldName, FieldNameU, ExcelFunction From D91T2023 " & vbCrLf
        sSQL = "Select ExcelTemplateID, ExportType, DisplayType, OrderNum, ExcelFunction, " & vbCrLf
        If _useUnicode Then
            sSQL &= " GroupFieldNameU as GroupFieldName, FieldNameU as FieldName " & vbCrLf
        Else
            sSQL &= " GroupFieldName, FieldName " & vbCrLf
        End If

        sSQL &= " From D91T2023 WITH(NOLOCK) Where ModuleID = " & SQLString(sFormName.Substring(1, 2)) & " And FormID = " & SQLString(sFormName) & vbCrLf
        'Update 16/08/2010: Nhập Unicode lưu template khác, Vni template khác
        If _useUnicode Then
            sSQL &= " And FieldNameU <> ''"
        Else
            sSQL &= " And FieldName <> ''"
        End If

        dtD91T2023 = ReturnDataTable(sSQL)
        'Add thêm vào table 2 cột: GroupFieldNameDesc, FieldNameDesc
        dtD91T2023.Columns.Add("GroupFieldNameDesc", GetType(System.String))
        dtD91T2023.Columns.Add("FieldNameDesc", GetType(System.String))
    End Sub

    Private Sub ResetDataMaster()
        'Create by Minh Hòa 01/09/2010: set lại các giá trị cho dữ liệu các control của master
        txtTitle.Text = ""
        txtPathIn.Text = ""
        cboDefaultSheet.Items.Clear()
        tdbcColExcel.Text = "A"
        txtRow.Text = "1"
        txtChecked.Text = "1"
        txtUnChecked.Text = "0"
        optPortrait.Checked = True
        dudAdjust.Text = "100"
        cboPageSize.Text = "A4"
        chkDisplayTitle.Checked = True
        chkIsExportType.Checked = False
        chkIsExportType_Click(Nothing, Nothing)
        optSubTotals.Checked = True
        'Update 21/12/2010
        optPivotTable.Checked = False

        chkShowSum.Checked = True
        chkIsAutoSizeColumn.Checked = True
        chkIsNoFormula.Checked = False
        txtPathOut.Text = DEFAULT_PATH_OUT
        lblSampleFileName.Text = txtPathOut.Text + "\Data.xls"
        chkIsMarkTimer.Checked = False
    End Sub
#End Region

#Region "Events tdbcColExcel"

    Private Sub tdbcColExcel_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcColExcel.Close
        If tdbcColExcel.FindStringExact(tdbcColExcel.Text) = -1 Then tdbcColExcel.Text = ""
    End Sub

    Private Sub tdbcColExcel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcColExcel.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcColExcel.Text = ""
    End Sub

#End Region

#Region "Events tdbcExcelTemplateID"

    Private Sub tdbcExcelTemplateID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcExcelTemplateID.SelectedValueChanged
        If tdbcExcelTemplateID.Text = "" Then
            tdbg.DataSource = Nothing
            Exit Sub
        End If
        If tdbcExcelTemplateID.Text = "+" Then
            _FormState = EnumFormState.FormAdd
            'Update 07/07/2010: Thêm mới thì Check, Sửa thì UnCheck
            chkShowAll.Checked = True

            txtExcelTemplateID.Visible = True
            txtExcelTemplateID.Text = ""
            ResetDataMaster()

            btnDelete.Enabled = False
            btnSave.Enabled = True
            tdbcExcelTemplateID.Visible = False
            txtExcelTemplateID.Focus()

        Else
            'Update 07/07/2010: Thêm mới thì Check, Sửa thì UnCheck
            chkShowAll.Checked = False
        End If
        LoadGrid()
    End Sub

    Private Sub tdbcExcelTemplateID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcExcelTemplateID.LostFocus
        If tdbcExcelTemplateID.FindStringExact(tdbcExcelTemplateID.Text) = -1 Then
            tdbcExcelTemplateID.Text = ""
        End If

    End Sub

#End Region

#Region "Events Of tdbg"

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case tdbg.Col
            Case COL_NumberFormat
                If tdbg.Columns(COL_DataType).Value.ToString.Trim <> "N" Then
                    tdbg.Columns(COL_NumberFormat).DropDown = Nothing
                    e.Cancel = True
                Else
                    tdbg.Columns(COL_NumberFormat).DropDown = tdbdFormat
                    e.Cancel = False
                End If

            Case COL_IsUsed
                If tdbg.Columns(COL_Grouped).Text = "1" Then
                    e.Cancel = True
                End If
                If tdbg.Columns(COL_IsExport).Text <> "" AndAlso tdbg.Columns(COL_IsExport).Text <> "0" Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.Col = COL_NumberFormat And e.KeyCode = Keys.Enter Then
            HotKeyEnterGrid(tdbg, COL_IsUsed, e, SPLIT0)
        End If
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_OrderNo
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_NumberFormat
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_NumberFormat
                If tdbg.Columns(COL_DataType).Value.ToString.Trim <> "N" Then
                    tdbg.Columns(COL_NumberFormat).Text = "0"
                End If
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then Exit Sub
        If bHeadClick = False And chkShowAll.Checked = False Then Exit Sub
        Select Case e.ColIndex
            Case COL_IsUsed
                bHeadClick = Not bHeadClick
                For Each dr As DataRow In dtGrid.Rows
                    If L3Int(dr.Item(tdbg.Columns(COL_Grouped).DataField)) <> 1 And L3Int(dr.Item(tdbg.Columns(COL_IsExport).DataField)) = 0 Then
                        dr.Item(tdbg.Columns(COL_IsUsed).DataField) = bHeadClick
                    End If
                Next
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_NumberFormat
                If Not L3IsNumeric(tdbg.Columns(COL_NumberFormat).Text) Then e.Cancel = True
                If tdbg.Columns(COL_NumberFormat).Text <> tdbdFormat.Columns("DecimalNo").Text Then
                    tdbg.Columns(COL_NumberFormat).Text = "0"
                End If
        End Select
    End Sub

    Private Sub tdbg_ColResize(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColResizeEventArgs) Handles tdbg.ColResize
        If tdbg.Col = COL_NumberFormat Then
            tdbdFormat.Width = tdbg.Splits(0).DisplayColumns(COL_NumberFormat).Width
        End If
    End Sub

    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If tdbg(e.Row, COL_Grouped).ToString = "1" Then
            e.CellStyle.ForeColor = Color.Blue
        End If
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.Col = COL_NumberFormat Then
            If tdbg(tdbg.Row, COL_DataType).ToString.Trim <> "N" Then
                tdbg.Columns(COL_NumberFormat).DropDown = Nothing
            Else
                tdbg.Columns(COL_NumberFormat).DropDown = tdbdFormat
            End If
        End If
    End Sub

#End Region

#Region "Vẽ lại nút Checkbox ở dạng lock"

    Private Sub tdbg_OwnerDrawCell(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.OwnerDrawCellEventArgs) Handles tdbg.OwnerDrawCell
        If tdbg(e.Row, COL_IsExport).ToString = "" OrElse tdbg(e.Row, COL_IsExport).ToString = "0" Then Exit Sub

        'If tdbg(e.Row, COL_Grouped).ToString = "" OrElse tdbg(e.Row, COL_Grouped).ToString = "0" Then Exit Sub

        Dim objPen As New Pen(Color.FromName("Green"))
        Dim pt As New Point()

        'Dim rect As New Rectangle(e.CellRect.X + 18, e.CellRect.Y, L3Int(e.CellRect.Width / 4) - 1, e.CellRect.Height - 4)
        Dim X As Integer = e.CellRect.X + L3Int((e.CellRect.Width - 11) / 2) - 2
        Dim rect As New Rectangle(X, e.CellRect.Y, 12, e.CellRect.Height - 3)
        e.Graphics.FillRectangle(Brushes.DarkGray, rect)
        e.Graphics.DrawRectangle(objPen, rect)

        'The commented out line below causes a red checkmark to be drawn in the topmost cell only of the column
        pt.X = e.CellRect.X + L3Int(e.CellRect.Width / 2) - 5 '3
        'No red checkmark is drawn in any cell in the column using the Y-cord below
        pt.Y = e.CellRect.Y + L3Int(e.CellRect.Height / 2) - 3

        'Lines moving downward left to right--left side of check (The checkmark is 3 lines thick)
        e.Graphics.DrawLine(objPen, pt.X, pt.Y + 0, pt.X + 2, pt.Y + 2)
        e.Graphics.DrawLine(objPen, pt.X, pt.Y + 1, pt.X + 2, pt.Y + 3)
        e.Graphics.DrawLine(objPen, pt.X, pt.Y + 2, pt.X + 2, pt.Y + 4)
        'Lines moving upward left to right--right side of check
        e.Graphics.DrawLine(objPen, pt.X + 2, pt.Y + 2, pt.X + 6, pt.Y - 2)
        e.Graphics.DrawLine(objPen, pt.X + 2, pt.Y + 3, pt.X + 6, pt.Y - 1)
        e.Graphics.DrawLine(objPen, pt.X + 2, pt.Y + 4, pt.X + 6, pt.Y - 0)

        e.Handled = True

    End Sub
#End Region

#Region "Các sự kiện và hàm để Di chuyển dòng của tdbg"

    Private Sub tdbg_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbg.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub tdbg_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbg.DragDrop
        Dim row, col As Integer
        Dim mypoint As Point
        mypoint = tdbg.PointToClient(New Point(e.X, e.Y))
        tdbg.CellContaining(mypoint.X, mypoint.Y, row, col)
        If row = -1 Then Exit Sub
        MoveRowNew(tdbg, tdbg.Bookmark, row, COL_FieldName)
    End Sub

    ' if we cancel or droped then reset the top grid
    Private Sub tdbg_QueryContinueDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles tdbg.QueryContinueDrag
        If e.Action = DragAction.Drop OrElse e.Action = DragAction.Cancel Then
            ResetDragDrop()
        End If
    End Sub

    Private Sub tdbg_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseMove
        ' if we don't have an empty start drag point, then the drag has been initiated
        If Not Me._ptStartDrag.IsEmpty Then
            ' create a rectangle that bounds the start of the drag operation by 2 pixels
            Dim r As New Rectangle(Me._ptStartDrag, Drawing.Size.Empty)
            r.Inflate(2, 2)
            ' if we've moved more than 2 pixels, lets start the drag operation
            If Not r.Contains(e.X, e.Y) Then
                tdbg.Row = Me._dragRow
                tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                tdbg.DoDragDrop(Me._dragRow, DragDropEffects.Copy)
            End If
        End If
    End Sub

    Private Sub tdbg_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseDown
        Dim row, col As Integer
        Me._ptStartDrag = Point.Empty
        Me._dragRow = -1
        If tdbg.CellContaining(e.X, e.Y, row, col) Then
            ' save the starting point of the drag operation
            Me._ptStartDrag = New Point(e.X, e.Y)
            Me._dragRow = row
        End If
    End Sub

    Dim row1 As Integer
    Dim col1 As Integer
    ' reset drag drop flags on mouse up
    Private Sub tdbg_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseUp
        ResetDragDrop()
        Me.tdbg.CellContaining(e.X, e.Y, row1, col1)
    End Sub

#End Region

#Region "Các sự kiện và hàm để Di chuyển dòng của tdbgGroup"

    Private Sub tdbgGroup_LockedColumns()
        tdbgGroup.Splits(SPLIT0).DisplayColumns(COL1_GroupFieldNameDesc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbgGroup_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbgGroup.BeforeColEdit
        If e.ColIndex = COL1_ExcelFunction Then
            If tdbgGroup(tdbgGroup.Row, COL1_GroupFieldName).ToString = "" Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tdbgGroup_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgGroup.RowColChange
        If btdbgGroup_RowColChange Then
            'Huỳnh Edit 27/05/2010: Bổ sung thêm điều kiện Filter Fieldname <> '' khi Có Group mà ko có Sum
            LoadDataSource(tdbgSubTotals, ReturnTableFilter(dtSubTotals, "GroupFieldName = " & SQLString(tdbgGroup.Columns(COL1_GroupFieldName).Text) & " And FieldName <> ''", True), _useUnicode)
        End If

    End Sub

    Private Sub tdbgGroup_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgGroup.AfterColUpdate
        If e.ColIndex = COL1_ExcelFunction Then
            Dim dr() As DataRow = dtSubTotals.Select("GroupFieldName = " & SQLString(tdbgGroup.Columns(COL1_GroupFieldName).Text) & " And FieldName <> ''")
            For i As Integer = 0 To dr.Length - 1
                dr(i).Item("ExcelFunction") = tdbgGroup.Columns(COL1_ExcelFunction).Value
                'Update lại hàm cho table
                dtSubTotals.Rows(i).SetParentRow(dr(i))
            Next
        End If
    End Sub

    Private Sub tdbgGroup_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbgGroup.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub tdbgGroup_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbgGroup.DragDrop
        Dim row, col As Integer
        Dim mypoint As Point
        mypoint = tdbgGroup.PointToClient(New Point(e.X, e.Y))
        tdbgGroup.CellContaining(mypoint.X, mypoint.Y, row, col)
        If row = -1 Then Exit Sub
        MoveRowNew(tdbgGroup, tdbgGroup.Bookmark, row, COL_FieldName)
    End Sub

    ' if we cancel or droped then reset the top grid
    Private Sub tdbgGroup_QueryContinueDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles tdbgGroup.QueryContinueDrag
        If e.Action = DragAction.Drop OrElse e.Action = DragAction.Cancel Then
            ResetDragDrop()
        End If
    End Sub

    Private Sub tdbgGroup_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgGroup.MouseMove
        ' if we don't have an empty start drag point, then the drag has been initiated
        If Not Me._ptStartDrag.IsEmpty Then
            ' create a rectangle that bounds the start of the drag operation by 2 pixels
            Dim r As New Rectangle(Me._ptStartDrag, Drawing.Size.Empty)
            r.Inflate(2, 2)
            ' if we've moved more than 2 pixels, lets start the drag operation
            If Not r.Contains(e.X, e.Y) Then
                tdbgGroup.Row = Me._dragRow
                tdbgGroup.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                tdbgGroup.DoDragDrop(Me._dragRow, DragDropEffects.Copy)
            End If
        End If
    End Sub

    Private Sub tdbgGroup_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgGroup.MouseDown
        Dim row, col As Integer
        Me._ptStartDrag = Point.Empty
        Me._dragRow = -1
        If tdbgGroup.CellContaining(e.X, e.Y, row, col) Then
            ' save the starting point of the drag operation
            Me._ptStartDrag = New Point(e.X, e.Y)
            Me._dragRow = row
        End If
    End Sub

    Dim row1G As Integer
    Dim col1G As Integer
    ' reset drag drop flags on mouse up
    Private Sub tdbgGroup_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgGroup.MouseUp
        ResetDragDrop()
        Me.tdbgGroup.CellContaining(e.X, e.Y, row1G, col1G)
    End Sub

#End Region

#Region "Các sự kiện và hàm để Di chuyển dòng của tdbgSubTotals"

    Private Sub tdbgSubTotals_LockedColumns()
        tdbgSubTotals.Splits(SPLIT0).DisplayColumns(COL2_FieldNameDesc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

#End Region

#Region "Các sự kiện và hàm để Di chuyển dòng của tdbgColumn"

    Private Sub tdbgColumn_LockedColumns()
        tdbgColumn.Splits(SPLIT0).DisplayColumns(COL3_FieldNameDesc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbgColumn_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbgColumn.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub tdbgColumn_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbgColumn.DragDrop
        Dim row, col As Integer
        Dim mypoint As Point
        mypoint = tdbgColumn.PointToClient(New Point(e.X, e.Y))
        tdbgColumn.CellContaining(mypoint.X, mypoint.Y, row, col)
        If row = -1 Then Exit Sub
        MoveRowNew(tdbgColumn, tdbgColumn.Bookmark, row, COL_FieldName)
    End Sub

    ' if we cancel or droped then reset the top grid
    Private Sub tdbgColumn_QueryContinueDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles tdbgColumn.QueryContinueDrag
        If e.Action = DragAction.Drop OrElse e.Action = DragAction.Cancel Then
            ResetDragDrop()
        End If
    End Sub

    Private Sub tdbgColumn_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgColumn.MouseMove
        ' if we don't have an empty start drag point, then the drag has been initiated
        If Not Me._ptStartDrag.IsEmpty Then
            ' create a rectangle that bounds the start of the drag operation by 2 pixels
            Dim r As New Rectangle(Me._ptStartDrag, Drawing.Size.Empty)
            r.Inflate(2, 2)
            ' if we've moved more than 2 pixels, lets start the drag operation
            If Not r.Contains(e.X, e.Y) Then
                tdbgColumn.Row = Me._dragRow
                tdbgColumn.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                tdbgColumn.DoDragDrop(Me._dragRow, DragDropEffects.Copy)
            End If
        End If
    End Sub

    Private Sub tdbgColumn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgColumn.MouseDown
        Dim row, col As Integer
        Me._ptStartDrag = Point.Empty
        Me._dragRow = -1
        If tdbgColumn.CellContaining(e.X, e.Y, row, col) Then
            ' save the starting point of the drag operation
            Me._ptStartDrag = New Point(e.X, e.Y)
            Me._dragRow = row
        End If
    End Sub

    Dim row1C As Integer
    Dim col1C As Integer
    ' reset drag drop flags on mouse up
    Private Sub tdbgColumn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgColumn.MouseUp
        ResetDragDrop()
        Me.tdbgColumn.CellContaining(e.X, e.Y, row1C, col1C)
    End Sub

#End Region

#Region "Các sự kiện và hàm để Di chuyển dòng của tdbgRow"

    Private Sub tdbgRow_LockedColumns()
        tdbgRow.Splits(SPLIT0).DisplayColumns(COL4_FieldNameDesc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbgRow_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbgRow.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub tdbgRow_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbgRow.DragDrop
        Dim row, col As Integer
        Dim mypoint As Point
        mypoint = tdbgRow.PointToClient(New Point(e.X, e.Y))
        tdbgRow.CellContaining(mypoint.X, mypoint.Y, row, col)
        If row = -1 Then Exit Sub
        MoveRowNew(tdbgRow, tdbgRow.Bookmark, row, COL_FieldName)
    End Sub

    ' if we cancel or droped then reset the top grid
    Private Sub tdbgRow_QueryContinueDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles tdbgRow.QueryContinueDrag
        If e.Action = DragAction.Drop OrElse e.Action = DragAction.Cancel Then
            ResetDragDrop()
        End If
    End Sub

    Private Sub tdbgRow_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgRow.MouseMove
        ' if we don't have an empty start drag point, then the drag has been initiated
        If Not Me._ptStartDrag.IsEmpty Then
            ' create a rectangle that bounds the start of the drag operation by 2 pixels
            Dim r As New Rectangle(Me._ptStartDrag, Drawing.Size.Empty)
            r.Inflate(2, 2)
            ' if we've moved more than 2 pixels, lets start the drag operation
            If Not r.Contains(e.X, e.Y) Then
                tdbgRow.Row = Me._dragRow
                tdbgRow.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                tdbgRow.DoDragDrop(Me._dragRow, DragDropEffects.Copy)
            End If
        End If
    End Sub

    Private Sub tdbgRow_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgRow.MouseDown
        Dim row, col As Integer
        Me._ptStartDrag = Point.Empty
        Me._dragRow = -1
        If tdbgRow.CellContaining(e.X, e.Y, row, col) Then
            ' save the starting point of the drag operation
            Me._ptStartDrag = New Point(e.X, e.Y)
            Me._dragRow = row
        End If
    End Sub

    Dim row1R As Integer
    Dim col1R As Integer
    ' reset drag drop flags on mouse up
    Private Sub tdbgRow_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgRow.MouseUp
        ResetDragDrop()
        Me.tdbgRow.CellContaining(e.X, e.Y, row1R, col1R)
    End Sub

#End Region

#Region "Các sự kiện và hàm để Di chuyển dòng của tdbgData"

    Private Sub tdbgData_LockedColumns()
        tdbgData.Splits(SPLIT0).DisplayColumns(COL5_FieldNameDesc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbgData_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbgData.BeforeColEdit
        If e.ColIndex = COL5_ExcelFunction Then
            If tdbgData(tdbgData.Row, COL5_FieldName).ToString = "" Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tdbgData_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbgData.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub tdbgData_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tdbgData.DragDrop
        Dim row, col As Integer
        Dim mypoint As Point
        mypoint = tdbgData.PointToClient(New Point(e.X, e.Y))
        tdbgData.CellContaining(mypoint.X, mypoint.Y, row, col)
        If row = -1 Then Exit Sub
        MoveRowNew(tdbgData, tdbgData.Bookmark, row, COL_FieldName)
    End Sub

    ' if we cancel or droped then reset the top grid
    Private Sub tdbgData_QueryContinueDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles tdbgData.QueryContinueDrag
        If e.Action = DragAction.Drop OrElse e.Action = DragAction.Cancel Then
            ResetDragDrop()
        End If
    End Sub

    Private Sub tdbgData_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgData.MouseMove
        ' if we don't have an empty start drag point, then the drag has been initiated
        If Not Me._ptStartDrag.IsEmpty Then
            ' create a rectangle that bounds the start of the drag operation by 2 pixels
            Dim r As New Rectangle(Me._ptStartDrag, Drawing.Size.Empty)
            r.Inflate(2, 2)
            ' if we've moved more than 2 pixels, lets start the drag operation
            If Not r.Contains(e.X, e.Y) Then
                tdbgData.Row = Me._dragRow
                tdbgData.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
                tdbgData.DoDragDrop(Me._dragRow, DragDropEffects.Copy)
            End If
        End If
    End Sub

    Private Sub tdbgData_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgData.MouseDown
        Dim row, col As Integer
        Me._ptStartDrag = Point.Empty
        Me._dragRow = -1
        If tdbgData.CellContaining(e.X, e.Y, row, col) Then
            ' save the starting point of the drag operation
            Me._ptStartDrag = New Point(e.X, e.Y)
            Me._dragRow = row
        End If
    End Sub

    Dim row1D As Integer
    Dim col1D As Integer
    ' reset drag drop flags on mouse up
    Private Sub tdbgData_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgData.MouseUp
        ResetDragDrop()
        Me.tdbgData.CellContaining(e.X, e.Y, row1D, col1D)
    End Sub

#End Region

#Region "Các hàm di chuyển của lưới"

    Private _ptStartDrag As Point = Point.Empty
    Private _dragRow As Integer = -1
    Private Sub ResetDragDrop()
        ' Turn off drag-and-drop by resetting the highlight and label text.
        Me._ptStartDrag = Point.Empty
        Me._dragRow = -1
        tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder
    End Sub

    Private Sub MoveRowNew(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iFrom As Integer, ByVal iTo As Integer, Optional ByVal iColKey As Integer = -1)
        'Các sự kiện để di chuyển dòng
        '1. tdbg_MouseUp
        '2. tdbg_MouseDown
        '3. tdbg_MouseMove
        '4. tdbg_QueryContinueDrag()
        '5. tdbg_DragDrop()
        '6. tdbg_DragEnter()
        'Huỳnh Edit: Bỏ qua lỗi khi DraDrop ra ngoài vùng dữ liệu
        Dim iRowCount As Integer = 0
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, 0).ToString <> "" Then
                iRowCount += 1
            Else
                Exit For
            End If
        Next
        If iTo >= iRowCount Then Exit Sub
        'End Edit
        If iFrom < iTo Then
            For i As Integer = iFrom To iTo - 1
                For col As Integer = 0 To tdbg.Columns.Count - 1
                    Dim sValue As String = tdbg(i, col).ToString
                    'Gán cột là khóa = ""
                    If col = iColKey Then
                        Dim sValueKey As String = tdbg(i + 1, col).ToString
                        tdbg(i + 1, col) = ""
                        tdbg(i, col) = sValueKey
                    Else
                        tdbg(i, col) = tdbg(i + 1, col).ToString
                    End If
                    tdbg(i + 1, col) = sValue
                Next
            Next
        Else
            For i As Integer = iFrom To iTo + 1 Step -1
                For col As Integer = 0 To tdbg.Columns.Count - 1
                    Dim sValue As String = tdbg(i - 1, col).ToString
                    'Gán cột là khóa = ""
                    If col = iColKey Then
                        Dim sValueKey As String = tdbg(i, col).ToString
                        tdbg(i, col) = ""
                        tdbg(i - 1, col) = sValueKey
                    Else
                        tdbg(i - 1, col) = tdbg(i, col).ToString
                    End If
                    tdbg(i, col) = sValue
                Next
            Next
        End If
    End Sub
#End Region

#Region "Button Click"

    Private Sub txtRow_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRow.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtRow_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRow.LostFocus
        If Number(txtRow.Text) = 0 Then
            txtRow.Focus()
            Exit Sub
        End If
        txtRow.Text = Format(Number(txtRow.Text), "#,##0")
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Update 07/07/2010: Đóng application của Excel
        Dim thr As Threading.Thread = New Threading.Thread(AddressOf BackProcessClose)
        thr.Start()

        Me.Close()
    End Sub

    Private Function CheckPath() As Boolean
        If txtPathIn.Text <> "" Then
            If Not CheckPathIn() Then Return False
            If txtPathOut.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(lblPathOut.Text)
                tabMain.SelectedTab = TabInfo
                txtPathOut.Focus()
                Return False
            End If
            Dim sPathIn As String = txtPathIn.Text.Trim().Substring(0, txtPathIn.Text.Trim().LastIndexOf("\"c))
            If sPathIn = txtPathOut.Text.Trim() Then
                D99C0008.MsgL3(lblPathOut.Text & " " & rL3("phai_khac_voi") & " " & lblPathIn.Text)
                tabMain.SelectedTab = TabInfo
                txtPathOut.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Function AllowExport() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        Else
            Dim bSelect As Boolean = False
            For i As Integer = 0 To tdbg.RowCount - 1
                If L3Bool(tdbg(i, COL_IsUsed).ToString) Then
                    bSelect = True
                    Exit For
                End If
            Next
            If bSelect = False Then
                D99C0008.MsgL3(rl3("MSG000010"))
                Return False
            End If
        End If
        If tdbcColExcel.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Cot_hien_thi"))
            tabMain.SelectedTab = TabInfo
            tdbcColExcel.Focus()
            Return False
        End If
        If txtRow.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dong_hien_thi"))
            tabMain.SelectedTab = TabInfo
            txtRow.Focus()
            Return False
        End If
        If Number(tdbcColExcel.SelectedValue) > MaxTinyInt Then '255
            D99C0008.MsgL3(rl3("Nhap_so_qua_lon"))
            tabMain.SelectedTab = TabInfo
            tdbcColExcel.Focus()
            Return False
        End If
        If Number(txtRow.Text.Trim) <= 0 Then
            D99C0008.MsgL3(rl3("Dong_hien_thi_phai__0"))
            tabMain.SelectedTab = TabInfo
            txtRow.Focus()
            Return False
        End If
        If Number(txtRow.Text.Trim) > Int16.MaxValue * 2 Then '65535
            D99C0008.MsgL3(rl3("Nhap_so_qua_lon"))
            tabMain.SelectedTab = TabInfo
            txtRow.Focus()
            Return False
        End If
        If Not CheckPath() Then Return False
        If txtPathIn.Text <> "" AndAlso cboDefaultSheet.Text.Trim = "" Then
            If Not GetNameSheets() Then Return False

            If cboDefaultSheet.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose("Sheet")
                tabMain.SelectedTab = TabInfo
                cboDefaultSheet.Focus()
                Return False
            End If
        End If
        If Not CheckPathOut() Then Return False
        If txtChecked.Text.Trim = txtUnChecked.Text.Trim Then
            D99C0008.MsgL3(IIf(gsLanguage = "84", "Thiết lập dữ liệu xuất cho giá trị của cột tùy chọn không hợp lệ.", "Setup value for Checkbox data column is not valid").ToString)
            tabMain.SelectedTab = TabAdvance
            txtChecked.Focus()
            Return False
        End If

        If chkIsExportType.Checked Then
            If optPivotTable.Checked = True Then 'Dạng PivotTable
                If Not AllowExportPivotTable() Then
                    Me.Cursor = Cursors.Default
                    btnExport.Enabled = True
                    Return False
                End If
                '************************************
            Else
                If Not AllowExportSubTotals() Then
                    Me.Cursor = Cursors.Default
                    btnExport.Enabled = True
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Private Function CheckPathOut() As Boolean
        If txtPathOut.Text.Trim() <> "" Then
            If Not System.IO.Directory.Exists(txtPathOut.Text.Trim()) Then
                D99C0008.MsgL3(lblPathOut.Text & " " & rL3("MSG000042"))
                tabMain.SelectedTab = TabInfo
                txtPathOut.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Function CheckPathIn() As Boolean
        If txtPathIn.Text <> "" Then
            If Not System.IO.File.Exists(txtPathIn.Text.Trim) Then
                D99C0008.MsgL3(lblPathIn.Text & " " & rL3("MSG000042"))
                tabMain.SelectedTab = TabInfo
                txtPathIn.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Function AllowExportSubTotals() As Boolean
        tdbgGroup.UpdateData()
        tdbgSubTotals.UpdateData()
        If tdbgGroup.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgGroup.Col = COL1_GroupFieldNameDesc
            tdbgGroup.Focus()
            Return False
        End If

        For j As Integer = 0 To tdbgGroup.RowCount - 1
            'Huỳnh Edit 27/05/2010: Bổ sung thêm điều kiện Select: FieldName <> ''
            Dim dr() As DataRow = dtSubTotals.Select("GroupFieldName = " & SQLString(tdbgGroup(j, COL1_GroupFieldName)) & " And FieldName <> ''")
            If dr.Length < 1 Then
                tdbgGroup.Row = j
                D99C0008.MsgNoDataInGrid()
                tdbgSubTotals.Focus()
                Return False
            End If
        Next
        Return True
    End Function

    Private Function AllowExportPivotTable() As Boolean
        tdbgColumn.UpdateData()
        tdbgRow.UpdateData()
        tdbgData.UpdateData()
        If tdbgColumn.RowCount <= 0 And tdbgRow.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgColumn.Focus()
            Return False
        End If

        If tdbgData.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgData.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function CheckExport(ByRef book As C1XLBook, ByRef sheet As XLSheet, ByVal sFileName As String) As Boolean
        Dim sheetPivot As XLSheet

        If txtPathIn.Text.Trim = "" Then
            sheet = book.Sheets(0)
            sheet.Name = "Data"
            iSheetData = 1
            If chkIsExportType.Checked = True And optPivotTable.Checked = True Then 'Dạng PivotTable
                book.Sheets.Add()
                sheetPivot = book.Sheets(1)
                sheetPivot.Name = "Pivot"
                iSheetPivot = 2
            End If
        Else
            Try

ReloadFile:
                book.Load(sFileName)
                If chkIsExportType.Checked = False Then
                    sheet = book.Sheets(cboDefaultSheet.Text)
                Else
                    If D99C0008.MsgAsk(rL3("Du_lieu_trong_file_nay_se_bi_xoa_khi_xuat") & vbCrLf & rL3("MSG000021")) = Windows.Forms.DialogResult.No Then
                        Me.Cursor = Cursors.Default
                        btnExport.Enabled = True
                        Return False
                    End If
                    Dim iSheetCount As Integer = book.Sheets.Count
                    For i As Integer = 0 To iSheetCount - 1
                        book.Sheets.RemoveAt(0)
                    Next

                    book.Sheets.Add()
                    sheet = book.Sheets(0)
                    sheet.Name = "Data"
                    iSheetData = 1
                    If optPivotTable.Checked = True Then 'Dạng PivotTable
                        book.Sheets.Add()
                        sheetPivot = book.Sheets(1)
                        sheetPivot.Name = "Pivot"
                        iSheetPivot = 2
                    End If
                End If
            Catch ex As Exception
                If CloseProcessWindow(sFileName) Then GoTo ReloadFile

                Me.Cursor = Cursors.Default
                btnExport.Enabled = True
                D99C0008.MsgL3(rL3("Loi_khi_mo_file_hoac_file_khong_ton_tai"))
                txtPathIn.Focus()
                Return False
            End Try
        End If

        Return True
    End Function

    Private Sub SortDatatable()
        If dtExportTmp Is Nothing Then
            sSort = GetStringSort()
            If sSort <> "" Then _dtExportTable.DefaultView.Sort = sSort
            dtExportTmp = _dtExportTable.DefaultView.ToTable
        Else
            Dim sSortNew As String = ""
            sSortNew = GetStringSort()
            If sSortNew <> "" And sSortNew <> sSort Then
                sSort = sSortNew
                dtExportTmp.DefaultView.Sort = sSort
                dtExportTmp = dtExportTmp.DefaultView.ToTable
            End If
        End If
    End Sub

    Private Function CheckInvalidExport(ByVal iUsedCol As Integer, ByRef iRow As Integer, ByRef iCol As Integer) As Boolean

        iRow = Convert.ToInt32(IIf(txtRow.Text = "", "1", txtRow.Text))
        iCol = Convert.ToInt32(IIf(tdbcColExcel.SelectedValue.ToString = "", "1", tdbcColExcel.SelectedValue.ToString))
        iRow = iRow - 1
        iCol = iCol - 1

        '-------------------------------------------
        'Minh Hòa Update 28/08/2010: Bổ sung title xuất excel
        ' Thêm 3 dòng nếu có tiêu đề
        If txtTitle.Text.Trim <> "" Then
            iRow += 3
        End If
        '-------------------------------------------

        '        'Thử tách sheet nhỏ hơn Sheet quy định
        '        Dim iMaxRow1 As Integer = iRow + dtExportTmp.DefaultView.ToTable.Rows.Count
        '        iMaxSheet = CInt(Math.Round(iMaxRow1 / MaxRowExcel))

        ' Update 20/11/2012 id 52604 - 
        Dim iRowData As Integer = dtExportTmp.DefaultView.ToTable.Rows.Count
        'If iRow + iRowData - 1 > Int16.MaxValue * 2 Or iRow + iRowData < 1 Then
        If iRow + iRowData - 1 > MaxRowExcel Then
            'Update 18/07/2014: incident 67372  nếu số dòng vượt quá 1 Sheet thì tách thành nhiều sheet khác
            Dim iMaxRow As Integer = iRow + iRowData
            'iMaxSheet = CInt(Math.Round(iMaxRow / MaxRowExcel))
            iMaxSheet = CInt(Math.Ceiling(iMaxRow / MaxRowExcel))
            Return False

        ElseIf iCol + iUsedCol > 255 Or iCol + iUsedCol < 1 Then
            D99C0008.MsgL3(rL3("So_cot_vuot_qua_gioi_han_cho_phep_cua_Excel"))
            Me.Cursor = Cursors.Default
            btnExport.Enabled = True
            tdbcColExcel.Focus()
            Return True
        End If
        Return False
    End Function



    'Xóa dòng trong Sheet đã có dữ liệu
    Private Sub DeletetRowSheet(ByRef sheet As XLSheet, ByVal iRowFrom As Integer, ByVal iRowTo As Integer)
        'Không được Delete dòng. File mẫu khách hàng không được có dữ liệu ID 80829 11/11/2015 Theo thống nhất với GSAM
        'Try
        '    '            For i As Integer = iRowFrom To iRowTo
        '    '                sheet.Rows.RemoveAt(i)
        '    '            Next
        '    Dim iCount As Integer = sheet.Rows.Count
        '    'MessageBox.Show("iRowFrom = " & iRowFrom & " -  sheet.Rows.Count =  " & iCount)
        '    For i As Integer = iCount - 1 To iRowFrom Step -1
        '        'MessageBox.Show("iRow = " & i)
        '        sheet.Rows.RemoveAt(i)
        '    Next

        'Catch ex As Exception

        'End Try
    End Sub

    Private Function SetTitleStyleXLS(ByRef style As C1.C1Excel.XLStyle) As C1.C1Excel.XLStyle
        style.Font = New System.Drawing.Font("Arial", 10.0!, FontStyle.Bold)
        style.BackColor = Color.LightGray
        style.BorderBottom = XLLineStyleEnum.Thin
        style.BorderLeft = XLLineStyleEnum.Thin
        style.BorderTop = XLLineStyleEnum.Thin
        style.BorderRight = XLLineStyleEnum.Thin
        style.AlignHorz = XLAlignHorzEnum.Center 'Canh giữa tiêu đề
        Return style
    End Function

    Private Function SetFooterStyleXLS(ByVal sheet As XLSheet, ByVal xstSum As C1.C1Excel.XLStyle) As C1.C1Excel.XLStyle
        xstSum = New XLStyle(sheet.Book)
        xstSum.BorderBottom = XLLineStyleEnum.Thin
        xstSum.BorderLeft = XLLineStyleEnum.Thin
        xstSum.BorderTop = XLLineStyleEnum.Thin
        xstSum.BorderRight = XLLineStyleEnum.Thin
        xstSum.BackColor = Color.LightGray
        xstSum.Font = New System.Drawing.Font("Arial", 10.0!, FontStyle.Bold)
        Return xstSum
    End Function

    Private Sub SetFooterCellXLS(ByRef sheet As XLSheet, ByRef bIsSum As Boolean, ByVal sType As String, ByVal j As Integer, ByVal rowXLS As Integer, ByVal colXLS As Integer, ByVal sFormat As String)
        ' Dim dSum As Object
        ' Dim bIsSum As Boolean = False
        If chkShowSum.Checked = False Then Exit Sub
        Dim cellTotal As C1.C1Excel.XLCell
        Dim xstSum As XLStyle
        While dicFormula.ContainsKey(colXLS)
            cellTotal = sheet(rowXLS, colXLS)
            xstSum = SetFooterStyleXLS(sheet, xstSum)
            cellTotal.Style = xstSum
            colXLS += 1
        End While

        Dim dSum As Object = tdbg(j, COL_FooterText)
        cellTotal = sheet(rowXLS, colXLS)
        xstSum = SetFooterStyleXLS(sheet, xstSum)
        If dSum IsNot Nothing AndAlso L3String(dSum) <> "" Then
            xstSum.AlignHorz = XLAlignHorzEnum.Right
            xstSum.Format = sFormat
            If L3Bool(tdbg(j, COL_IsSum)) AndAlso IsNumeric(dSum) Then
                cellTotal.Value = Number(dSum) 'Tổng cộng thì chuyển qua dạng Number
            Else
                If sType.Contains("%") Then
                    Dim sVTmp As String = L3String(dSum)
                    sVTmp = sVTmp.Replace("%", "")
                    cellTotal.Value = Number(sVTmp) / 100 'các cột phần trăm,...
                Else
                    cellTotal.Value = dSum 'Tổng công (4)
                End If

            End If
            If Not bIsSum Then bIsSum = True
        End If
        cellTotal.Style = xstSum
    End Sub

    Private Function SetCellStyleXLS(ByVal book As C1XLBook, ByVal sType As String, ByVal sValue As Object, ByRef sFormat As String, ByVal j As Integer) As C1.C1Excel.XLStyle
        Dim xst As XLStyle = New XLStyle(book)
        If sType = "Percent" Then 'Định dạng Percent - Update 06/11/2012
            xst.BorderBottom = XLLineStyleEnum.Thin
            xst.BorderLeft = XLLineStyleEnum.Thin
            xst.BorderTop = XLLineStyleEnum.Thin
            xst.BorderRight = XLLineStyleEnum.Thin
            xst.AlignHorz = XLAlignHorzEnum.Right
            'sFormat = sType '"#,##0" & InsertZero(L3Int(tdbg(j, COL_NumberFormat)))
            xst.Format = "0.00%"
        ElseIf sType.Contains("%") Then 'Định dạng CustomPercent - Update 13/01/2015
            xst.BorderBottom = XLLineStyleEnum.Thin
            xst.BorderLeft = XLLineStyleEnum.Thin
            xst.BorderTop = XLLineStyleEnum.Thin
            xst.BorderRight = XLLineStyleEnum.Thin
            xst.AlignHorz = XLAlignHorzEnum.Right
            xst.Format = sType '"0.000%"
            sFormat = sType
        ElseIf sType = "D" Then ' Date(D)
            xst.BorderBottom = XLLineStyleEnum.Thin
            xst.BorderLeft = XLLineStyleEnum.Thin
            xst.BorderTop = XLLineStyleEnum.Thin
            xst.BorderRight = XLLineStyleEnum.Thin
            xst.AlignHorz = XLAlignHorzEnum.Center

            If L3Int(tdbg(j, COL_IsDateTime)) = 1 Then
                xst.Format = "dd/MM/yyyy hh:mm:ss"
            ElseIf L3Int(tdbg(j, COL_IsDateTime)) = 2 Then 'Bổ sung dạng format cho cột Giờ
                xst.Format = L3String(tdbg(j, COL_Format))
            Else
                xst.Format = "dd/mm/yyyy"
            End If

        ElseIf sType = "N1" Then ' Boolean, Byte là cột checkbox
            xst.BorderBottom = XLLineStyleEnum.Thin
            xst.BorderLeft = XLLineStyleEnum.Thin
            xst.BorderTop = XLLineStyleEnum.Thin
            xst.BorderRight = XLLineStyleEnum.Thin
            'Trường hợp này dưới Database có kiểu dữ liệu Bit(0,1) -> DataTable có kiểu dữ liệu String(True,False)
            xst.AlignHorz = XLAlignHorzEnum.Center

            'Bỏ: chuyển về định dạn theo thiết lập ở dưới
            ''Update 07/07/2010: Giá trị = True thì format màu đỏ và canh giữa
            If sValue.ToString.ToUpper = "TRUE" Or sValue.ToString.ToUpper = "FALSE" Then
                'xst.AlignHorz = XLAlignHorzEnum.Center
                If sValue.ToString.ToUpper = "TRUE" Then xst.ForeColor = Color.Red
            Else
                'xst.AlignHorz = XLAlignHorzEnum.Right
                If sValue.ToString = "1" Then xst.ForeColor = Color.Red
            End If

        ElseIf sType = "N2" Then 'dạng số nguyên, không thập phân
            xst.BorderBottom = XLLineStyleEnum.Thin
            xst.BorderLeft = XLLineStyleEnum.Thin
            xst.BorderTop = XLLineStyleEnum.Thin
            xst.BorderRight = XLLineStyleEnum.Thin
            xst.AlignHorz = XLAlignHorzEnum.Right
            sFormat = "#,##0"
            xst.Format = sFormat '"#,##0"
        ElseIf sType = "N" Then ' Number(N)
            xst.BorderBottom = XLLineStyleEnum.Thin
            xst.BorderLeft = XLLineStyleEnum.Thin
            xst.BorderTop = XLLineStyleEnum.Thin
            xst.BorderRight = XLLineStyleEnum.Thin
            xst.AlignHorz = XLAlignHorzEnum.Right
            sFormat = "#,##0" & InsertZero(L3Int(tdbg(j, COL_NumberFormat)))
            xst.Format = sFormat '"#,##0" & InsertZero(L3Int(tdbg(j, COL_NumberFormat)))
        Else 'String(S)
            xst.BorderBottom = XLLineStyleEnum.Thin
            xst.BorderLeft = XLLineStyleEnum.Thin
            xst.BorderTop = XLLineStyleEnum.Thin
            xst.BorderRight = XLLineStyleEnum.Thin
            xst.AlignHorz = XLAlignHorzEnum.Left
            xst.WordWrap = True
        End If
        Return xst
    End Function

    Private Sub SetCellValueXLS(ByRef cell As XLCell, ByVal sType As String, ByVal sValue As Object, ByVal j As Integer)
        If sType = "N1" Then ' Boolean, Byte
            cell.Value = sValue
            'Update: 09/09/2010: Set lại giá trị theo Thiết lập
            If sValue.ToString.ToUpper = "TRUE" Or sValue.ToString.ToUpper = "FALSE" Then
                'xst.AlignHorz = XLAlignHorzEnum.Center
                If sValue.ToString.ToUpper = "TRUE" Then
                    cell.Value = txtChecked.Text
                Else
                    cell.Value = txtUnChecked.Text
                End If
            Else
                'xst.AlignHorz = XLAlignHorzEnum.Right
                If sValue.ToString = "1" Then
                    cell.Value = txtChecked.Text
                Else
                    cell.Value = txtUnChecked.Text
                End If
            End If
        ElseIf sType = "D" AndAlso L3Int(tdbg(j, COL_IsDateTime)) = 0 AndAlso sValue.ToString <> "" Then
            'Update: 08/04/2011: Nếu là Ngày dạng "dd/MM/yyyy" thì chỉ lấy đúng 10 ký tự, để khỏi kéo rộng cột
            '  cell.Value = sValue.ToString.Substring(0, 10)
            If sValue.ToString <> "" Then
                'cell.Value = CType(sValue.ToString.Substring(0, 10), Date)
                cell.Value = SQLDateShow(sValue)
            Else
                cell.Value = sValue
            End If
        Else
            cell.Value = sValue
        End If
    End Sub




    Private Sub SetTiltle(ByVal book As C1XLBook, ByRef sheet As XLSheet, ByRef iRow As Integer, ByVal iCol As Integer)
        If chkDisplayTitle.Checked = False Then Exit Sub
        'Chuyển tiêu đề các cột cần xuất ra Excel (Chiếm 1 dòng trong Excel)
        Dim cell As XLCell
        Dim k As Integer = 0
        Dim style As New C1.C1Excel.XLStyle(book)

        For j As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(j, COL_IsUsed)) = True AndAlso L3String(tdbg(j, COL_FieldName)).Trim <> "" Then
                While dicFormula.ContainsKey(iCol + j + k)
                    cell = sheet(iRow, iCol + j + k)
                    cell.Value = ""
                    cell.Style = SetTitleStyleXLS(style)
                    k += 1
                End While
                cell = sheet(iRow, iCol + j + k)
                If _useUnicode Then
                    cell.Value = tdbg(j, COL_Description).ToString
                Else
                    cell.Value = ConvertVniToUnicode(tdbg(j, COL_Description).ToString)
                End If
                cell.Style = SetTitleStyleXLS(style)
            Else
                k = k - 1
            End If
        Next
        iRow = iRow + 1
    End Sub

    Private Sub Merge(ByVal i As Integer, ByVal j As Integer, ByRef sValue1 As Object, ByRef sValue2 As Object, ByRef iMergeFirstRow As Integer)
        If L3Bool(tdbg(j, COL_IsMerge)) = False Then Exit Sub
        If tdbg(j, COL_MergeRelative).ToString = "" Then 'không merge theo cột quan hệ (ví dụ: Số phiếu)
            If sValue1 Is Nothing Then
                sValue1 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString)
                iMergeFirstRow = i
            End If
        Else 'merge theo cột quan hệ (ví dụ: Tiền NT merge theo Số phiếu)
            If dtExportTmp.Columns.Contains("MergeWhere") Then 'Merge có điều kiện
                'Tìm giá trị cột MergeWhere trong dtExportTmp không chứa giá trị của cột FieldName trên lưới thì được phép merge
                If Not dtExportTmp.Rows(i).Item("MergeWhere").ToString.Contains(tdbg(j, COL_FieldName).ToString) Then
                    If sValue1 IsNot Nothing And sValue2 Is Nothing Then
                        sValue2 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString).ToString
                        iMergeFirstRow = i
                    ElseIf sValue1 Is Nothing And sValue2 Is Nothing Then
                        sValue1 = dtExportTmp.Rows(i).Item(tdbg(j, COL_MergeRelative).ToString).ToString
                        sValue2 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString).ToString
                        iMergeFirstRow = i
                    End If
                End If
            Else
                If sValue1 IsNot Nothing And sValue2 Is Nothing Then
                    sValue2 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString).ToString
                    iMergeFirstRow = i
                ElseIf sValue1 Is Nothing And sValue2 Is Nothing Then
                    sValue1 = dtExportTmp.Rows(i).Item(tdbg(j, COL_MergeRelative).ToString).ToString
                    sValue2 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString).ToString
                    iMergeFirstRow = i
                End If
            End If

        End If
    End Sub

    Private Sub MergeCell(ByRef sheet As XLSheet, ByVal i As Integer, ByVal j As Integer, ByVal k As Integer, ByRef sValue1 As Object, ByRef sValue2 As Object, ByVal iMergeFirstRow As Integer, ByRef iCount As Integer, ByVal iRow As Integer, ByVal iCol As Integer)
        If L3Bool(tdbg(j, COL_IsMerge)) = False Then Exit Sub
        Dim c1CellRange As XLCellRange
        If tdbg(j, COL_MergeRelative).ToString = "" Then 'không merge theo cột quan hệ (ví dụ: Số phiếu)
            If sValue1 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString) Then
                iCount += 1
            End If
            If i = dtExportTmp.Rows.Count - 1 And iCount > 1 Then
                c1CellRange = New XLCellRange(iMergeFirstRow + iRow, iRow + i, iCol + j + k, iCol + j + k)
                sheet.MergedCells.Add(c1CellRange) 'merge dòng

                For z As Integer = iMergeFirstRow + iRow + 1 To iRow + i 'xóa các dòng đã merge, chỉ giữ lại dòng merge đầu tiên
                    sheet.Item(z, iCol + j + k).Value = Nothing
                Next

                sValue1 = Nothing
                iCount = 0
            ElseIf i < dtExportTmp.Rows.Count - 1 Then
                If sValue1 <> dtExportTmp.Rows(i + 1).Item(tdbg(j, COL_FieldName).ToString) Then
                    If iCount > 1 Then
                        c1CellRange = New XLCellRange(iMergeFirstRow + iRow, iRow + i, iCol + j + k, iCol + j + k)
                        sheet.MergedCells.Add(c1CellRange) 'merge dòng

                        For z As Integer = iMergeFirstRow + iRow + 1 To iRow + i 'xóa các dòng đã merge, chỉ giữ lại dòng merge đầu tiên
                            sheet.Item(z, iCol + j + k).Value = Nothing
                        Next
                    End If

                    sValue1 = Nothing
                    iCount = 0
                End If
            End If

        Else  'merge theo cột quan hệ (ví dụ: Tiền NT merge theo Số phiếu)
            If sValue1 = dtExportTmp.Rows(i).Item(tdbg(j, COL_MergeRelative).ToString) And sValue2 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString) Then
                iCount += 1
            End If
            If i = dtExportTmp.Rows.Count - 1 And iCount > 1 Then
                c1CellRange = New XLCellRange(iMergeFirstRow + iRow, iRow + i, iCol + j + k, iCol + j + k)
                sheet.MergedCells.Add(c1CellRange) 'merge dòng

                For z As Integer = iMergeFirstRow + iRow + 1 To iRow + i 'xóa các dòng đã merge, chỉ giữ lại dòng merge đầu tiên
                    sheet.Item(z, iCol + j + k).Value = Nothing
                Next

                sValue1 = Nothing
                sValue2 = Nothing
                iCount = 0
            ElseIf i < dtExportTmp.Rows.Count - 1 Then
                If sValue1 = dtExportTmp.Rows(i + 1).Item(tdbg(j, COL_MergeRelative).ToString) And sValue2 <> dtExportTmp.Rows(i + 1).Item(tdbg(j, COL_FieldName).ToString) Then
                    If iCount > 1 Then
                        c1CellRange = New XLCellRange(iMergeFirstRow + iRow, iRow + i, iCol + j + k, iCol + j + k)
                        sheet.MergedCells.Add(c1CellRange) 'merge dòng

                        For z As Integer = iMergeFirstRow + iRow + 1 To iRow + i 'xóa các dòng đã merge, chỉ giữ lại dòng merge đầu tiên
                            sheet.Item(z, iCol + j + k).Value = Nothing
                        Next
                    End If

                    sValue2 = Nothing
                    iCount = 0
                ElseIf sValue1 <> dtExportTmp.Rows(i + 1).Item(tdbg(j, COL_MergeRelative).ToString) Then
                    If iCount > 1 Then
                        c1CellRange = New XLCellRange(iMergeFirstRow + iRow, iRow + i, iCol + j + k, iCol + j + k)
                        sheet.MergedCells.Add(c1CellRange) 'merge dòng

                        For z As Integer = iMergeFirstRow + iRow + 1 To iRow + i 'xóa các dòng đã merge, chỉ giữ lại dòng merge đầu tiên
                            sheet.Item(z, iCol + j + k).Value = Nothing
                        Next
                    End If

                    sValue1 = Nothing
                    sValue2 = Nothing
                    iCount = 0
                End If
            End If
        End If
    End Sub

    'Private Sub CallExport(ByRef book As C1XLBook, ByRef sheet As XLSheet, ByVal iUsedCol As Integer, ByVal iRow As Integer, ByVal iCol As Integer, ByVal iRowBegin As Integer, ByVal iRowEnd As Integer)
    '    Dim sFormat As String = ""
    '    Dim cell As XLCell
    '    ' Dim iRow, iCol As Integer
    '    Dim style As New C1.C1Excel.XLStyle(book)

    '    ProcessOptions(book, sheet)
    '    Try
    '        'If txtPath.Text <> "" Then 'Thêm dòng vào Excel nếu có thiết lập mẫu
    '        '    'Dùng cho trường hợp giữ lại phần Footer của file có sẵn
    '        '    Dim iTotalRow As Integer = iRowEnd - iRowBegin + 1
    '        '    If chkDisplayTitle.Checked Then iTotalRow += 1
    '        '    If chkShowSum.Checked Then
    '        '        Dim dr() As DataRow = dtGrid.Select("IsSum=1 And " & "IsUsed=1")
    '        '        If dr.Length > 0 Then iTotalRow += 1
    '        '    End If
    '        '    InsertRowExcel(sheet, iRow, iTotalRow)
    '        'End If

    '        '********************
    '        Dim sType As String 'Lấy kiểu dữ liệu để Format
    '        Dim sValue As Object 'Lấy giá trị để Export
    '        Dim k As Integer = 0
    '        If chkDisplayTitle.Checked Then
    '            'Chuyển tiêu đề các cột cần xuất ra Excel (Chiếm 1 dòng trong Excel)
    '            For j As Integer = 0 To tdbg.RowCount - 1
    '                If L3Bool(tdbg(j, COL_IsUsed)) = True AndAlso L3String(tdbg(j, COL_FieldName)).Trim <> "" Then
    '                    cell = sheet(iRow, iCol + j + k)
    '                    If _useUnicode Then
    '                        cell.Value = tdbg(j, COL_Description).ToString
    '                    Else
    '                        cell.Value = ConvertVniToUnicode(tdbg(j, COL_Description).ToString)
    '                    End If

    '                    style.Font = New System.Drawing.Font("Arial", 10.0!, FontStyle.Bold)
    '                    style.BackColor = Color.LightGray
    '                    style.BorderBottom = XLLineStyleEnum.Thin
    '                    style.BorderLeft = XLLineStyleEnum.Thin
    '                    style.BorderTop = XLLineStyleEnum.Thin
    '                    style.BorderRight = XLLineStyleEnum.Thin
    '                    style.AlignHorz = XLAlignHorzEnum.Center 'Canh giữa tiêu đề
    '                    cell.Style = style
    '                Else
    '                    k = k - 1
    '                End If
    '            Next
    '            iRow = iRow + 1
    '        End If

    '        'Write to Excel and convert Font to Unicode
    '        If bUnicode And _useUnicode = False And L3Bool(chkConvertUnicode.Tag) = False Then
    '            ConvertDataTable(dtExportTmp, arrDisabledColumn)
    '            chkConvertUnicode.Tag = True
    '        End If
    '        k = 0
    '        Dim iRowExcel As Integer = 0 'Số dòng Excel cho bắt đầu mỗi Sheet
    '        Dim dSum As Double
    '        Dim bIsSum As Boolean = False
    '        ''Merge
    '        Dim sValue1 As Object, sValue2 As Object
    '        Dim iCount As Integer = 0, iMergeFirstRow As Integer = 0
    '        Dim c1CellRange As XLCellRange
    '        ''End Merge

    '        For j As Integer = 0 To tdbg.RowCount - 1
    '            If L3Bool(tdbg(j, COL_IsUsed)) AndAlso L3String(tdbg(j, COL_FieldName)).Trim <> "" Then
    '                iRowExcel = 0
    '                dSum = 0
    '                sValue1 = Nothing
    '                sValue2 = Nothing
    '                iCount = 0
    '                'For i As Integer = 0 To dtExportTmp.Rows.Count - 1
    '                For i As Integer = iRowBegin To iRowEnd
    '                    sType = tdbg(j, COL_DataType).ToString.Trim
    '                    sValue = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString)
    '                    ''Merge
    '                    If L3Bool(tdbg(j, COL_IsMerge)) = True Then
    '                        If tdbg(j, COL_MergeRelative).ToString = "" Then 'khÃ´ng merge theo cá»™t
    '                            If sValue1 Is Nothing Then
    '                                sValue1 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString)
    '                                iMergeFirstRow = i
    '                            End If
    '                        Else
    '                            If sValue1 IsNot Nothing And sValue2 Is Nothing Then
    '                                sValue2 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString).ToString
    '                                iMergeFirstRow = i
    '                            ElseIf sValue1 Is Nothing And sValue2 Is Nothing Then
    '                                sValue1 = dtExportTmp.Rows(i).Item(tdbg(j, COL_MergeRelative).ToString).ToString
    '                                sValue2 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString).ToString
    '                                iMergeFirstRow = i
    '                            End If
    '                        End If
    '                    End If
    '                    ''End Merge

    '                    'Xem Có hiển thị dòng tổng không thì tính tổng
    '                    'If chkShowSum.Checked AndAlso L3Bool(tdbg(j, COL_IsSum)) Then
    '                    '    dSum += Number(sValue)
    '                    'End If
    '                    'Định dạng cho cột cho Excel
    '                    If sType = "Percent" Then 'Định dạng Percent - Update 06/11/2012
    '                        Dim xst As XLStyle = New XLStyle(sheet.Book)
    '                        xst.BorderBottom = XLLineStyleEnum.Thin
    '                        xst.BorderLeft = XLLineStyleEnum.Thin
    '                        xst.BorderTop = XLLineStyleEnum.Thin
    '                        xst.BorderRight = XLLineStyleEnum.Thin
    '                        xst.AlignHorz = XLAlignHorzEnum.Right
    '                        'sFormat = sType '"#,##0" & InsertZero(L3Int(tdbg(j, COL_NumberFormat)))
    '                        xst.Format = "0.00%"
    '                        sheet.Item(iRow + iRowExcel, iCol + j + k).Style = xst
    '                    ElseIf sType.Contains("%") Then 'Định dạng CustomPercent - Update 13/01/2015
    '                        Dim xst As XLStyle = New XLStyle(sheet.Book)
    '                        xst.BorderBottom = XLLineStyleEnum.Thin
    '                        xst.BorderLeft = XLLineStyleEnum.Thin
    '                        xst.BorderTop = XLLineStyleEnum.Thin
    '                        xst.BorderRight = XLLineStyleEnum.Thin
    '                        xst.AlignHorz = XLAlignHorzEnum.Right
    '                        xst.Format = sType '"0.000%"
    '                        sheet.Item(iRow + iRowExcel, iCol + j + k).Style = xst
    '                    ElseIf sType = "D" Then ' Date(D)
    '                        Dim xst As XLStyle = New XLStyle(sheet.Book)
    '                        xst.BorderBottom = XLLineStyleEnum.Thin
    '                        xst.BorderLeft = XLLineStyleEnum.Thin
    '                        xst.BorderTop = XLLineStyleEnum.Thin
    '                        xst.BorderRight = XLLineStyleEnum.Thin
    '                        xst.AlignHorz = XLAlignHorzEnum.Center

    '                        If L3Int(tdbg(j, COL_IsDateTime)) = 1 Then
    '                            xst.Format = "dd/MM/yyyy hh:mm:ss"
    '                        Else
    '                            xst.Format = "dd/mm/yyyy"
    '                        End If
    '                        sheet.Item(iRow + iRowExcel, iCol + j + k).Style = xst

    '                    ElseIf sType = "N1" Then ' Boolean, Byte là cột checkbox
    '                        Dim xst As XLStyle = New XLStyle(sheet.Book)
    '                        xst.BorderBottom = XLLineStyleEnum.Thin
    '                        xst.BorderLeft = XLLineStyleEnum.Thin
    '                        xst.BorderTop = XLLineStyleEnum.Thin
    '                        xst.BorderRight = XLLineStyleEnum.Thin
    '                        'Trường hợp này dưới Database có kiểu dữ liệu Bit(0,1) -> DataTable có kiểu dữ liệu String(True,False)
    '                        xst.AlignHorz = XLAlignHorzEnum.Center

    '                        'Bỏ: chuyển về định dạn theo thiết lập ở dưới
    '                        ''Update 07/07/2010: Giá trị = True thì format màu đỏ và canh giữa
    '                        If sValue.ToString.ToUpper = "TRUE" Or sValue.ToString.ToUpper = "FALSE" Then
    '                            'xst.AlignHorz = XLAlignHorzEnum.Center
    '                            If sValue.ToString.ToUpper = "TRUE" Then xst.ForeColor = Color.Red
    '                        Else
    '                            'xst.AlignHorz = XLAlignHorzEnum.Right
    '                            If sValue.ToString = "1" Then xst.ForeColor = Color.Red
    '                        End If

    '                        sheet.Item(iRow + iRowExcel, iCol + j + k).Style = xst
    '                    ElseIf sType = "N2" Then 'dạng số nguyên, không thập phân
    '                        Dim xst As XLStyle = New XLStyle(sheet.Book)
    '                        xst.BorderBottom = XLLineStyleEnum.Thin
    '                        xst.BorderLeft = XLLineStyleEnum.Thin
    '                        xst.BorderTop = XLLineStyleEnum.Thin
    '                        xst.BorderRight = XLLineStyleEnum.Thin
    '                        xst.AlignHorz = XLAlignHorzEnum.Right
    '                        sFormat = "#,##0"
    '                        xst.Format = sFormat

    '                        sheet.Item(iRow + iRowExcel, iCol + j + k).Style = xst
    '                    ElseIf sType = "N" Then ' Number(N)
    '                        Dim xst As XLStyle = New XLStyle(sheet.Book)
    '                        xst.BorderBottom = XLLineStyleEnum.Thin
    '                        xst.BorderLeft = XLLineStyleEnum.Thin
    '                        xst.BorderTop = XLLineStyleEnum.Thin
    '                        xst.BorderRight = XLLineStyleEnum.Thin
    '                        xst.AlignHorz = XLAlignHorzEnum.Right
    '                        sFormat = "#,##0" & InsertZero(L3Int(tdbg(j, COL_NumberFormat)))
    '                        xst.Format = sFormat

    '                        sheet.Item(iRow + iRowExcel, iCol + j + k).Style = xst

    '                    Else 'String(S)
    '                        Dim xst As XLStyle = New XLStyle(sheet.Book)
    '                        xst.BorderBottom = XLLineStyleEnum.Thin
    '                        xst.BorderLeft = XLLineStyleEnum.Thin
    '                        xst.BorderTop = XLLineStyleEnum.Thin
    '                        xst.BorderRight = XLLineStyleEnum.Thin
    '                        xst.AlignHorz = XLAlignHorzEnum.Left
    '                        xst.WordWrap = True
    '                        sheet.Item(iRow + iRowExcel, iCol + j + k).Style = xst
    '                    End If
    '                    'Export Value to Excel
    '                    cell = sheet(iRow + iRowExcel, iCol + j + k)

    '                    'Gán lại giá trị định dạng cell
    '                    If sType = "N1" Then ' Boolean, Byte
    '                        cell.Value = sValue
    '                        'Update: 09/09/2010: Set lại giá trị theo Thiết lập
    '                        If sValue.ToString.ToUpper = "TRUE" Or sValue.ToString.ToUpper = "FALSE" Then
    '                            'xst.AlignHorz = XLAlignHorzEnum.Center
    '                            If sValue.ToString.ToUpper = "TRUE" Then
    '                                cell.Value = txtChecked.Text
    '                            Else
    '                                cell.Value = txtUnChecked.Text
    '                            End If
    '                        Else
    '                            'xst.AlignHorz = XLAlignHorzEnum.Right
    '                            If sValue.ToString = "1" Then
    '                                cell.Value = txtChecked.Text
    '                            Else
    '                                cell.Value = txtUnChecked.Text
    '                            End If
    '                        End If
    '                    ElseIf sType = "D" AndAlso L3Int(tdbg(j, COL_IsDateTime)) = 0 AndAlso sValue.ToString <> "" Then
    '                        'Update: 08/04/2011: Nếu là Ngày dạng "dd/MM/yyyy" thì chỉ lấy đúng 10 ký tự, để khỏi kéo rộng cột
    '                        '  cell.Value = sValue.ToString.Substring(0, 10)
    '                        If sValue.ToString <> "" Then
    '                            'cell.Value = CType(sValue.ToString.Substring(0, 10), Date)
    '                            cell.Value = SQLDateShow(sValue)
    '                        Else
    '                            cell.Value = sValue
    '                        End If
    '                    Else
    '                        cell.Value = sValue
    '                        'cell.Style.Format = "Percent"
    '                    End If

    '                    'Gán giá trị cho các Cell, nếu cột số = 0 thì gán lại = ''
    '                    If sheet.Item(iRow + iRowExcel, iCol + j + k).Style.AlignHorz = XLAlignHorzEnum.Right And sType <> "N1" And sType <> "Percent" And sType.Contains("%") = False Then
    '                        If ConvertMoney(sValue, sFormat) = 0 Then cell.Value = ""
    '                    End If

    '                    iRowExcel += 1
    '                    '****************************************************
    '                    'Lê Phương bổ sung ngày 18/01/2013: Xuất Excel theo định dạng lưới
    '                    'Dữ liệu cột Style là tập hợp giá trị định dạng của dòng và cell
    '                    'Nếu có sự kiện FechtRowStyle thì lưu--> (định dạng font chữ,màu chữ ,màu nền)
    '                    'Nếu cell nào có sự kiện FechtCellStyle thì lưu--> FieldName(định dạng font chữ,màu chữ ,màu nền)
    '                    'Dữ liệu cột Style sẽ có dạng-->(định dạng font chữ,màu chữ ,màu nền);FieldName(định dạng font chữ,màu chữ ,màu nền)
    '                    If dtExportTmp.Columns.Contains(COL_StyleExcel) Then
    '                        Dim arrayStyle() As String = dtExportTmp.Rows(i).Item(COL_StyleExcel).ToString.Split(";"c)
    '                        If arrayStyle.Length > 0 Then
    '                            If arrayStyle(0).ToString.StartsWith("(") Then 'Sự kiện FechRowStyle
    '                                'Cắt 2 ký tự ()ở đầu và cuối để lấy ra giá trị của sự kiện FechRowStyle
    '                                arrayStyle(0) = arrayStyle(0).Substring(1, arrayStyle(0).Length - 2)
    '                                'Gán giá trị của sự kiện FechtRowStyle
    '                                SetCellStyle(cell, arrayStyle(0))
    '                                '**********************
    '                                'Gán giá trị của sự kiện FechtCellStyle
    '                                For iarrayStyle As Integer = 1 To arrayStyle.Length - 1
    '                                    Dim arrayCell() As String = arrayStyle(iarrayStyle).Split("("c, ")"c)
    '                                    If arrayCell.Length > 0 AndAlso arrayCell(0) = tdbg(j, COL_FieldName).ToString Then
    '                                        SetCellStyle(cell, arrayCell(1))
    '                                        Exit For
    '                                    End If
    '                                Next
    '                            Else 'Chi có sự kiện FetchCellStyle
    '                                For iarrayStyle As Integer = 0 To arrayStyle.Length - 1
    '                                    Dim arrayCell() As String = arrayStyle(iarrayStyle).Split("("c, ")"c)
    '                                    If arrayCell.Length > 0 AndAlso arrayCell(0) = tdbg(j, COL_FieldName).ToString Then
    '                                        SetCellStyle(cell, arrayCell(1))
    '                                        Exit For
    '                                    End If
    '                                Next
    '                            End If
    '                        End If
    '                    End If
    '                    'Merge
    '                    If L3Bool(tdbg(j, COL_IsMerge)) = True Then
    '                        If tdbg(j, COL_MergeRelative).ToString = "" Then 'không merge theo cột quan hệ
    '                            If sValue1 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString) Then
    '                                iCount += 1
    '                            End If
    '                            If i = dtExportTmp.Rows.Count - 1 And iCount > 1 Then
    '                                c1CellRange = New XLCellRange(iMergeFirstRow + iRow, iRow + i, iCol + j + k, iCol + j + k)
    '                                sheet.MergedCells.Add(c1CellRange) 'merge dòng

    '                                For z As Integer = iMergeFirstRow + iRow + 1 To iRow + i 'xóa các dòng đã merge, chỉ giữ lại dòng merge đầu tiên
    '                                    sheet.Item(z, iCol + j + k).Value = Nothing
    '                                Next

    '                                sValue1 = Nothing
    '                                iCount = 0
    '                            ElseIf i < dtExportTmp.Rows.Count - 1 Then
    '                                If sValue1 <> dtExportTmp.Rows(i + 1).Item(tdbg(j, COL_FieldName).ToString) Then
    '                                    If iCount > 1 Then
    '                                        c1CellRange = New XLCellRange(iMergeFirstRow + iRow, iRow + i, iCol + j + k, iCol + j + k)
    '                                        sheet.MergedCells.Add(c1CellRange) 'merge dòng

    '                                        For z As Integer = iMergeFirstRow + iRow + 1 To iRow + i 'xóa các dòng đã merge, chỉ giữ lại dòng merge đầu tiên
    '                                            sheet.Item(z, iCol + j + k).Value = Nothing
    '                                        Next
    '                                    End If

    '                                    sValue1 = Nothing
    '                                    iCount = 0
    '                                End If
    '                            End If

    '                        Else 'merge theo cột quan hệ
    '                            If sValue1 = dtExportTmp.Rows(i).Item(tdbg(j, COL_MergeRelative).ToString) And sValue2 = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString) Then
    '                                iCount += 1
    '                            End If
    '                            If i = dtExportTmp.Rows.Count - 1 And iCount > 1 Then
    '                                c1CellRange = New XLCellRange(iMergeFirstRow + iRow, iRow + i, iCol + j + k, iCol + j + k)
    '                                sheet.MergedCells.Add(c1CellRange) 'merge dòng

    '                                For z As Integer = iMergeFirstRow + iRow + 1 To iRow + i 'xóa các dòng đã merge, chỉ giữ lại dòng merge đầu tiên
    '                                    sheet.Item(z, iCol + j + k).Value = Nothing
    '                                Next

    '                                sValue1 = Nothing
    '                                sValue2 = Nothing
    '                                iCount = 0
    '                            ElseIf i < dtExportTmp.Rows.Count - 1 Then
    '                                If sValue1 = dtExportTmp.Rows(i + 1).Item(tdbg(j, COL_MergeRelative).ToString) And sValue2 <> dtExportTmp.Rows(i + 1).Item(tdbg(j, COL_FieldName).ToString) Then
    '                                    If iCount > 1 Then
    '                                        c1CellRange = New XLCellRange(iMergeFirstRow + iRow, iRow + i, iCol + j + k, iCol + j + k)
    '                                        sheet.MergedCells.Add(c1CellRange) 'merge dòng

    '                                        For z As Integer = iMergeFirstRow + iRow + 1 To iRow + i 'xóa các dòng đã merge, chỉ giữ lại dòng merge đầu tiên
    '                                            sheet.Item(z, iCol + j + k).Value = Nothing
    '                                        Next
    '                                    End If

    '                                    sValue2 = Nothing
    '                                    iCount = 0
    '                                ElseIf sValue1 <> dtExportTmp.Rows(i + 1).Item(tdbg(j, COL_MergeRelative).ToString) Then
    '                                    If iCount > 1 Then
    '                                        c1CellRange = New XLCellRange(iMergeFirstRow + iRow, iRow + i, iCol + j + k, iCol + j + k)
    '                                        sheet.MergedCells.Add(c1CellRange) 'merge dòng

    '                                        For z As Integer = iMergeFirstRow + iRow + 1 To iRow + i 'xóa các dòng đã merge, chỉ giữ lại dòng merge đầu tiên
    '                                            sheet.Item(z, iCol + j + k).Value = Nothing
    '                                        Next
    '                                    End If

    '                                    sValue1 = Nothing
    '                                    sValue2 = Nothing
    '                                    iCount = 0
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                    ''End Merge

    '                Next
    '                dSum = Number(tdbg(j, COL_FooterText))
    '                'Xem Có hiển thị dòng tổng không thì tính tổng
    '                If chkShowSum.Checked Then
    '                    Dim cellTotal As C1.C1Excel.XLCell
    '                    cellTotal = sheet(iRow + iRowExcel, iCol + j + k)
    '                    Dim xstSum As XLStyle = New XLStyle(sheet.Book)
    '                    xstSum.BorderBottom = XLLineStyleEnum.Thin
    '                    xstSum.BorderLeft = XLLineStyleEnum.Thin
    '                    xstSum.BorderTop = XLLineStyleEnum.Thin
    '                    xstSum.BorderRight = XLLineStyleEnum.Thin
    '                    xstSum.BackColor = Color.LightGray
    '                    xstSum.Font = New System.Drawing.Font("Arial", 10.0!, FontStyle.Bold)
    '                    If L3Bool(tdbg(j, COL_IsSum)) Then
    '                        xstSum.AlignHorz = XLAlignHorzEnum.Right
    '                        xstSum.Format = sFormat
    '                        cellTotal.Value = dSum
    '                        If Not bIsSum Then bIsSum = True
    '                    End If
    '                    cellTotal.Style = xstSum
    '                End If
    '            Else
    '                k = k - 1
    '            End If
    '        Next
    '        'Nếu không có Sum thì xóa dòng Footer Sum 
    '        If chkShowSum.Checked AndAlso Not bIsSum Then
    '            'sheet.Rows.RemoveAt(iRowExcel + iRow - 1 + SQLNumber(chkDisplayTitle.Checked))
    '            sheet.Rows.RemoveAt(iRowExcel + iRow)
    '        End If
    '    Catch ex As Exception
    '        D99C0008.MsgL3(ex.ToString)
    '    End Try
    'End Sub
    'Insert dòng trong Excel dựa vào dữ liệu xuất
    Private Sub InsertRowExcel(ByRef sheet As XLSheet, ByVal iRow As Integer, ByVal iTotalRow As Integer)
        Try
            sheet(iRow, 1).Value = "" 'lỗi khi insert dòng chưa nhập liệu
            For i As Integer = 0 To iTotalRow - 1
                sheet.Rows.Insert(iRow)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CallExport(ByRef book As C1XLBook, ByRef sheet As XLSheet, ByVal iUsedCol As Integer, ByVal iRow As Integer, ByVal iCol As Integer, ByVal iRowBegin As Integer, ByVal iRowEnd As Integer)
        ProcessOptions(book, sheet)
        Try
            If txtPathIn.Text <> "" AndAlso chkIsNoFormula.Checked = False Then 'Thêm dòng vào Excel nếu có thiết lập mẫu và không kiểm tra công thức
                'Dùng cho trường hợp giữ lại phần Footer của file có sẵn
                Dim iTotalRow As Integer = iRowEnd - iRowBegin + 1
                If chkDisplayTitle.Checked Then iTotalRow += 1
                If chkShowSum.Checked Then
                    Dim dr() As DataRow = dtGrid.Select("IsSum=1 And " & "IsUsed=1")
                    If dr.Length > 0 Then iTotalRow += 1
                End If
                InsertRowExcel(sheet, iRow, iTotalRow)
            End If

            Dim sFormat As String = ""
            Dim cell As XLCell

            '********************
            SetTiltle(book, sheet, iRow, iCol) 'Set dòng tiêu đề
            'Write to Excel and convert Font to Unicode
            If bUnicode And _useUnicode = False And L3Bool(chkConvertUnicode.Tag) = False Then
                ConvertDataTable(dtExportTmp, arrDisabledColumn)
                chkConvertUnicode.Tag = True
            End If

            Dim k As Integer = 0
            Dim iRowExcel As Integer = 0 'Số dòng Excel cho bắt đầu mỗi Sheet
            Dim bIsSum As Boolean = False
            ''Merge
            Dim sValue1 As Object, sValue2 As Object
            Dim iCount As Integer = 0, iMergeFirstRow As Integer = 0
            ''End Merge

            For j As Integer = 0 To tdbg.RowCount - 1
                Dim sType As String = tdbg(j, COL_DataType).ToString.Trim

                If L3Bool(tdbg(j, COL_IsUsed)) AndAlso L3String(tdbg(j, COL_FieldName)).Trim <> "" Then
                    While dicFormula.ContainsKey(iCol + j + k) 'Nếu cột công thức thì tăng lên 1
                        iRowExcel = iRowEnd - iRowBegin + 1
                        SetFooterCellXLS(sheet, bIsSum, sType, j, iRow + iRowExcel, iCol + j + k, sFormat)
                        k += 1
                    End While
                    iRowExcel = 0
                    ' dSum = Nothing
                    sValue1 = Nothing
                    sValue2 = Nothing
                    iCount = 0
                    'For i As Integer = 0 To dtExportTmp.Rows.Count - 1
                    For i As Integer = iRowBegin To iRowEnd
                        Merge(i, j, sValue1, sValue2, iMergeFirstRow)
                        'Export Value to Excel
                        Dim sValue As Object = dtExportTmp.Rows(i).Item(tdbg(j, COL_FieldName).ToString)
                        cell = sheet(iRow + iRowExcel, iCol + j + k)
                        cell.Style = SetCellStyleXLS(sheet.Book, sType, sValue, sFormat, j) 'Định dạng cell
                        SetCellValueXLS(cell, sType, sValue, j) 'Gán lại giá trị định dạng cell

                        'Gán giá trị cho các Cell, nếu cột số = 0 thì gán lại = ''
                        If sheet.Item(iRow + iRowExcel, iCol + j + k).Style.AlignHorz = XLAlignHorzEnum.Right And sType <> "N1" And sType <> "Percent" And sType.Contains("%") = False Then
                            If ConvertMoney(sValue, sFormat) = 0 Then cell.Value = ""
                        End If

                        iRowExcel += 1
                        '****************************************************
                        SetCellStyle(cell, i, j)
                        'Merge
                        MergeCell(sheet, i, j, k, sValue1, sValue2, iMergeFirstRow, iCount, iRow, iCol)
                    Next
                    SetFooterCellXLS(sheet, bIsSum, sType, j, iRow + iRowExcel, iCol + j + k, sFormat)
                Else
                    k = k - 1
                End If
            Next
            'Nếu không có Sum thì xóa dòng Footer Sum 
            If chkShowSum.Checked AndAlso Not bIsSum Then
                sheet.Rows.RemoveAt(iRowExcel + iRow)
            End If

        Catch ex As Exception
            D99C0008.MsgL3(ex.ToString)
        End Try
    End Sub

    Private Sub SetCellStyle(ByRef cell As XLCell, ByVal i As Integer, ByVal j As Integer)
        'Lê Phương bổ sung ngày 18/01/2013: Xuất Excel theo định dạng lưới
        'Dữ liệu cột Style là tập hợp giá trị định dạng của dòng và cell
        'Nếu có sự kiện FechtRowStyle thì lưu--> (định dạng font chữ,màu chữ ,màu nền)
        'Nếu cell nào có sự kiện FechtCellStyle thì lưu--> FieldName(định dạng font chữ,màu chữ ,màu nền)
        'Dữ liệu cột Style sẽ có dạng-->(định dạng font chữ,màu chữ ,màu nền);FieldName(định dạng font chữ,màu chữ ,màu nền)
        If dtExportTmp.Columns.Contains(COL_StyleExcel) = False Then Exit Sub
        Dim arrayStyle() As String = dtExportTmp.Rows(i).Item(COL_StyleExcel).ToString.Split(";"c)
        If arrayStyle.Length > 0 Then
            If arrayStyle(0).ToString.StartsWith("(") Then 'Sự kiện FechRowStyle
                'Cắt 2 ký tự ()ở đầu và cuối để lấy ra giá trị của sự kiện FechRowStyle
                arrayStyle(0) = arrayStyle(0).Substring(1, arrayStyle(0).Length - 2)
                'Gán giá trị của sự kiện FechtRowStyle
                SetCellStyle(cell, arrayStyle(0))
                '**********************
                'Gán giá trị của sự kiện FechtCellStyle
                For iarrayStyle As Integer = 1 To arrayStyle.Length - 1
                    Dim arrayCell() As String = arrayStyle(iarrayStyle).Split("("c, ")"c)
                    If arrayCell.Length > 0 AndAlso arrayCell(0) = tdbg(j, COL_FieldName).ToString Then
                        SetCellStyle(cell, arrayCell(1))
                        Exit For
                    End If
                Next
            Else 'Chi có sự kiện FetchCellStyle
                For iarrayStyle As Integer = 0 To arrayStyle.Length - 1
                    Dim arrayCell() As String = arrayStyle(iarrayStyle).Split("("c, ")"c)
                    If arrayCell.Length > 0 AndAlso arrayCell(0) = tdbg(j, COL_FieldName).ToString Then
                        SetCellStyle(cell, arrayCell(1))
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub SetCellStyle(ByRef cell As XLCell, ByVal sValue As String)
        Dim FontStyle() As String = sValue.Split(","c)
        'Mảng cắt ra gồm 3 phần tử theo thứ tự: Các định dạng font, Màu chữ, Mau nền
        'Gán Màu chữ or màu nền khi có giá trị <>""
        '***************************************
        'Set màu chữ
        If FontStyle(1) <> "" Then cell.Style.ForeColor = Color.FromArgb(L3Int(FontStyle(1)))
        'Set màu nền
        If FontStyle(2) <> "" Then cell.Style.BackColor = Color.FromArgb(L3Int(FontStyle(2)))
        '***************************************
        'Định dạng font chữ
        'Bổ sung ngày 19/11/2013
        Dim bConvertUnicode As Boolean = chkConvertUnicode.Checked
        Select Case FontStyle(0)
            Case "B"
                ' 8/5/2014 - Khi in đậm xuất bị lỗi do cell.Style.Font = nothing
                If cell.Style.Font Is Nothing Then
                    cell.Style.Font = FontUnicode(gbUnicode OrElse bConvertUnicode, Drawing.FontStyle.Bold)
                Else ' Trường hợp ngoại lệ
                    cell.Style.Font = New System.Drawing.Font(cell.Style.Font.Name, cell.Style.Font.Size, Drawing.FontStyle.Bold, GraphicsUnit.Point) ' = FontUnicode(gbUnicode OrElse bConvertUnicode, Drawing.FontStyle.Bold)
                End If
            Case "I"
                cell.Style.Font = FontUnicode(gbUnicode OrElse bConvertUnicode, Drawing.FontStyle.Italic)
            Case "U"
                cell.Style.Font = FontUnicode(gbUnicode OrElse bConvertUnicode, Drawing.FontStyle.Underline)
            Case "BI"
                cell.Style.Font = FontUnicode(gbUnicode OrElse bConvertUnicode, Drawing.FontStyle.Bold Or Drawing.FontStyle.Italic)
            Case "IU"
                cell.Style.Font = FontUnicode(gbUnicode OrElse bConvertUnicode, Drawing.FontStyle.Italic Or Drawing.FontStyle.Underline)
            Case "BU"
                cell.Style.Font = FontUnicode(gbUnicode OrElse bConvertUnicode, Drawing.FontStyle.Bold Or Drawing.FontStyle.Underline)
            Case "BIU"
                cell.Style.Font = FontUnicode(gbUnicode OrElse bConvertUnicode, Drawing.FontStyle.Underline Or Drawing.FontStyle.Bold Or Drawing.FontStyle.Italic)
        End Select
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        If Not AllowExport() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        btnExport.Enabled = False
        bUnicode = False
        Dim book As C1XLBook
        book = New C1XLBook()
        Dim sheet As XLSheet

        iSheetData = 1
        iSheetPivot = 0
        '***************************Bổ sung xuất excel master
        Dim fileName As String = DEFAULT_PATH_OUT + "\Data.xls"


        fileName = ExportMaster(fileName)
        If fileName = "" Then Me.Cursor = Cursors.Default : btnExport.Enabled = True : Exit Sub
        '***************************

        sheet = book.Sheets(0)
        'Kiểm tra trước khi xuất
        If Not CheckExport(book, sheet, fileName) Then Me.Cursor = Cursors.Default : Exit Sub
        '***************************

        'Lấy dữ liệu xuất excel
        SortDatatable()
        '***************************
        'Đếm số cột được check dùng
        Dim iUsedCol As Integer = GetDisabledColumn()
        '***************************

        'Update 18/07/2014: incident 67372  nếu số dòng vượt quá 1 Sheet thì tách thành nhiều sheet khác
        Dim iRow, iCol As Integer
        If CheckInvalidExport(iUsedCol, iRow, iCol) Then Exit Sub

        Dim iRowBegin As Integer
        Dim iRowEnd As Integer = MaxRowExcel

        For i As Integer = 0 To iMaxSheet - 1
            If i > 0 Then
                book.Sheets.Add()
                sheet = book.Sheets(i)
                sheet.Name = "Data" & i
            End If

            'Định dạng xuất
            iRowBegin = i * MaxRowExcel
            If iRowEnd > dtExportTmp.Rows.Count Then
                iRowEnd = dtExportTmp.Rows.Count
            End If


            CallExport(book, sheet, iUsedCol, iRow, iCol, iRowBegin, iRowEnd - 1)
            ''***************************
            'Update 05/06/2015: Incident 76315
            If chkIsAutoSizeColumn.Checked Then
                'Fix the columns's size
                AutoSizeColumns(sheet)
            End If

            '-------------------------------------------
            'Minh Hòa Update 01/09/2010: MergedCells nên để sau AutoSizeColumns
            If chkIsExportType.Checked = False Or optPivotTable.Checked = False Then ProcessOptions(book, sheet)
            '-------------------------------------------
            iRowEnd += MaxRowExcel

        Next


        'Update 07/07/2010
ErrorOpenFile:
        Try
            If txtPathIn.Text.Trim = "" AndAlso txtPathOut.Text.Trim = "" Then
                'Save the file
                book.Save(fileName)
            Else
                book.Sheets.SelectedIndex = cboDefaultSheet.SelectedIndex 'Update 09/09/2010
                ' book.Save(fileName) 'Lê Anh Vũ: 24/08/2015 - TH có dùng File mẫu thì không dùng hàm này được vì bị lỗi trên .NET 4.0 (Desktop)
                SaveData(book, fileName)
            End If

            '*****************************************
            ''Update 07/07/2010: dòng code dùng While đang đợi khởi tạo EXL (application của Excel tại Public Sub New của form)
            '' Khi nào EXL khởi tạo xong thì biến bIsLoadEXL = True và vòng While kết thúc
            'While bIsLoadEXL = False
            'End While
            '*****************************************
            'Update 10/12/2012: dòng code CultureInfo đang bị lỗi, tạm thời rem lại
            'Update 03/11/2011: Sửa lại lấy CultureInfo theo ngôn ngữ hiện có
            'Fix lỗi theo 56017
            Try
                Dim newCulture As System.Globalization.CultureInfo
                Dim OldCulture As System.Globalization.CultureInfo

                OldCulture = System.Threading.Thread.CurrentThread.CurrentCulture
                newCulture = New System.Globalization.CultureInfo( _
                                EXL.LanguageSettings.LanguageID(Microsoft.Office.Core.MsoAppLanguageID.msoLanguageIDUI))
                System.Threading.Thread.CurrentThread.CurrentCulture = newCulture
            Catch ex As Exception
                ' D99C0008.MsgL3(ex.Message)
            End Try
            '*****************************************

            'Update 10/11/2009
            'Kiểm tra có check vào Dạng xuất không?
            If Not chkIsExportType.Checked Then 'Xuất thường
                'System.Diagnostics.Process.Start(fileName)
                'Update 07/07/2010: đưa đọan code có liên quan đến EXL ra ngòai Sub này để khỏi chậm code
                OpenExcelApp(fileName)
            Else 'Xuất theo dạng có Group của Excel
                If optPivotTable.Checked = True Then 'Dạng PivotTable
                    ExportPivotTable(fileName, iUsedCol)
                    '************************************
                Else 'Dạng SubTotals
                    ExportSubTotals(fileName, iUsedCol)
                    'BoldSubTotals(fileName)
                    'Dim EXL As New Excel.Application
                    'EXL.Workbooks.Open(fileName)
                    'EXL.Visible = True
                    Process.Start(fileName)
                End If
            End If
            'Update 03/11/2011: trả lại CultureInfo hiện có
            'System.Threading.Thread.CurrentThread.CurrentCulture = OldCulture

        Catch ex As Exception
            'MsgErrorExcel(ex.Message)
            'Update 7/07/2010: file excel đang mở, nếu người dùng chấp nhận đóng thì thực thi xuất excel tiếp ErrorOpenFile
            If CloseProcessWindow(fileName) Then GoTo ErrorOpenFile
        End Try

        btnExport.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub SaveData(ByVal book As C1XLBook, ByRef fileName As String)
    '    Dim sPathOld As String = fileName
    '    If chkIsMarkTimer.Checked Then
    '        fileName = txtPathIn.Text.Trim()
    '    Else
    '        IO.File.Delete(fileName)
    '        Dim name As String = Strings.Left(fileName, fileName.LastIndexOf("."c)) 'lấy tên file
    '        fileName = fileName.Replace(name, name & "" & Format(Now, "yyMMdd")) 'namefile_yyMMdd
    '    End If
    '    Try
    '        book.Save(fileName) '.NET 4.0 bị lỗi khi lưu đè lên 
    '        IO.File.Delete(sPathOld)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub SaveData(ByVal book As C1XLBook, ByRef fileName As String)
        Dim sPathOld As String = fileName
        Dim name As String = Strings.Left(fileName, fileName.LastIndexOf("."c)) 'lấy tên file
        If chkIsMarkTimer.Checked Then
            fileName = fileName.Replace(name, name & "" & Format(Now, "yyMMdd")) 'namefile_yyMMdd
        Else
            fileName = fileName.Replace(name, name.Substring(0, name.Length - 1))
        End If
        Try
            book.Save(fileName) '.NET 4.0 bị lỗi khi lưu đè lên 
            IO.File.Delete(sPathOld)
        Catch ex As Exception
        End Try
    End Sub

    '*** Update 07/07/2010: Các tiến trình chạy song song giúp cải thiện tốc độ chạy của chương trình
#Region "Dùng Threading để cải thiện tốc độ chạy của chương trình"

    Private Sub BackProcessLoad()
        If EXL Is Nothing Then EXL = New Excel.Application
        bIsLoadEXL = True
        Threading.Thread.CurrentThread.Abort()
    End Sub

    Private Sub BackProcessClose()
        If EXL IsNot Nothing Then
            EXL = Nothing
            System.GC.Collect()
        End If
        Threading.Thread.CurrentThread.Abort()
    End Sub

#End Region

    Private Sub OpenExcelApp(ByVal fileName As String)
        'EXL.Workbooks.Open(fileName)
        'EXL.Visible = True
        Process.Start(fileName)
    End Sub

    Private Function CloseProcessWindow(ByVal fileName As String, Optional ByVal bShowMessage As Boolean = True) As Boolean
        Dim bClosed As Boolean = False
        Try
            For Each wbExcel As Excel.Workbook In EXL.Workbooks
                If wbExcel.FullName.ToLower = fileName.ToLower Then
                    If bShowMessage Then
                        If (D99C0008.MsgAsk(rL3("Ban_phai_dong_File") & Space(1) & fileName.Substring(fileName.LastIndexOf("\") + 1) & Space(1) & rL3("truoc_khi_xuat_Excel") & "." & vbCrLf & rL3("Ban_co_muon_dong_khong")) = Windows.Forms.DialogResult.Yes) Then
                            wbExcel.Save()
                            wbExcel.Close()
                            If EXL.Workbooks.Count = 0 Then
                                EXL.Visible = False
                            End If
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        wbExcel.Save()
                        wbExcel.Close()
                        If EXL.Workbooks.Count = 0 Then
                            EXL.Visible = False
                        End If
                        Return True
                    End If
                End If
                bClosed = True
            Next
        Catch ex As Exception

        End Try
        'Doan code dung de dong file Excel mo san (khong phai do Chuong trinh mo)
        If Not bClosed Then
            Dim p As System.Diagnostics.Process = Nothing
            'Dim sWindowName As String = "Microsoft Excel - Data.xls"
            Dim sWindowName As String = "Microsoft Excel - Data"
            If txtPathIn.Text <> "" Then
                'Update 09/7/2015: phải lấy tên file
                'sWindowName = "Microsoft Excel - " & txtPath.Text.Substring(txtPath.Text.LastIndexOf("\") + 1)
                sWindowName = "Microsoft Excel - " & fileName.Substring(fileName.LastIndexOf("\") + 1)
                sWindowName = sWindowName.Substring(0, sWindowName.LastIndexOf("."))
            End If
            Try
                For Each pr As Process In Process.GetProcessesByName("EXCEL")
                    'Update 05/04/2013
                    If pr.MainWindowTitle = "" Then Continue For

                    If pr.MainWindowTitle.Contains(sWindowName) OrElse pr.MainWindowTitle = sWindowName.Substring(0, sWindowName.LastIndexOf(".")) Then
                        'If pr.MainWindowTitle.Contains(sWindowName) Then
                        If p Is Nothing Then
                            p = pr
                        ElseIf p.StartTime < pr.StartTime Then
                            p = pr
                        End If
                    End If
                Next
                If p IsNot Nothing Then
                    'Update 05/04/2013
                    Me.BringToFront()
                    Me.Activate()
                    If (D99C0008.MsgAsk(rL3("Ban_phai_dong_File") & Space(1) & fileName.Substring(fileName.LastIndexOf("\") + 1) & Space(1) & rL3("truoc_khi_xuat_Excel") & "." & vbCrLf & rL3("Ban_co_muon_dong_khong")) = Windows.Forms.DialogResult.Yes) Then
                        p.Kill()
                        Return True
                    Else
                        Return False
                    End If
                End If
                Return False
            Catch ex As Exception
            End Try
        End If

    End Function

    Private Sub ExportSubTotals(ByVal sfileName As String, ByVal iUsedCol As Integer)
        Try
            'Chuyển qua kiểm tra AllowExport
            'If Not AllowExportSubTotals() Then
            '    Me.Cursor = Cursors.Default
            '    btnExport.Enabled = True
            '    Exit Sub
            'End If

            'Set lại Index cho Group và Sum cho cột số
            Dim iCountGroup As Integer = tdbgGroup.RowCount
            Dim arrGroupColumns(iCountGroup - 1) As Integer
            Dim arrFunction(iCountGroup - 1) As Microsoft.Office.Interop.Excel.XlConsolidationFunction
            Dim WSheet As New Excel.Worksheet

            EXL.Workbooks.Open(sfileName)
            WSheet = CType(EXL.Workbooks.Item(1).ActiveSheet, Excel.Worksheet)

            Dim range(iCountGroup - 1) As Excel.Range
            Dim sAreaMax As String = GetAreaMaxData(iUsedCol + 10, dtExportTmp.Rows.Count + 50)
            Dim sAreaMin As String = tdbcColExcel.Text & txtRow.Text
            'Minh Hòa Update 28/08/2010
            If txtTitle.Text.Trim <> "" Then
                sAreaMin = tdbcColExcel.Text & (Integer.Parse(txtRow.Text) + 3).ToString
            End If

            'Set lại Index cho Group
            Dim idxCol As Integer = 0
            Dim idxSumCount As Integer = 0
            Dim idxGroupIsColSubtotal As Integer = 0

            For j As Integer = 0 To tdbgGroup.RowCount - 1
                idxCol = 0 + idxGroupIsColSubtotal
                idxSumCount = 0
                'Xác định hàm Sum hay Count
                'Huỳnh edit 27/05/2010: Thêm điều kiện Select FieldName <> ''
                Dim dr() As DataRow = dtSubTotals.Select("GroupFieldName = " & SQLString(tdbgGroup(j, COL1_GroupFieldName)) & " And FieldName <> ''")
                Dim arrSumCount(dr.Length - 1) As Integer
                If dr(0).Item("ExcelFunction").ToString = "1" Then 'Count
                    arrFunction(j) = Excel.XlConsolidationFunction.xlCount
                Else 'Sum
                    arrFunction(j) = Excel.XlConsolidationFunction.xlSum
                End If
                'Xác định Group và tập SumCount
                For i As Integer = 0 To tdbg.RowCount - 1
                    If L3Bool(tdbg(i, COL_IsUsed)) Then
                        'Group
                        If tdbg(i, COL_FieldName).ToString = tdbgGroup(j, COL1_GroupFieldName).ToString Then
                            arrGroupColumns(j) = idxCol + 1
                            'Cot dau tien la Group va Subtotal
                            If i = 0 And dr(0).Item("GroupFieldName").ToString = dr(0).Item("FieldName").ToString Then
                                idxGroupIsColSubtotal = 1
                            End If
                        End If
                        'Xác định cột nào Sum Hay Count
                        For k As Integer = 0 To dr.Length - 1
                            If tdbg(i, COL_FieldName).ToString = dr(k).Item("FieldName").ToString Then
                                arrSumCount(idxSumCount) = idxCol + 1
                                idxSumCount += 1
                                Exit For
                            End If
                        Next
                        idxCol += 1
                    End If
                Next
                range(j) = WSheet.Range(sAreaMin, sAreaMax)
                range(j).Subtotal(L3Int(arrGroupColumns(j)), arrFunction(j), arrSumCount, Nothing, , Excel.XlSummaryRow.xlSummaryBelow)

            Next

            EXL.Workbooks.Item(1).Save()
            EXL.Workbooks.Close()
            'EXL.Visible = True
            BoldSubTotals(sfileName, arrGroupColumns)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: Export Subtotals")
            CloseProcessWindow(sfileName, False)
        End Try
    End Sub

    Private Sub BoldSubTotals(ByVal sFile As String, ByVal arrGroupColumns() As Integer)
        'Trọng Update 12/01/2011: Tô đậm cho các cột sum, count
        'Exit Sub
        Dim book As C1XLBook
        Dim sheet As XLSheet
        book = New C1XLBook()
        book.Load(sFile)
        sheet = book.Sheets(0)

        Dim cell As XLCell
        Dim style As New C1.C1Excel.XLStyle(book)
        style.Font = New System.Drawing.Font("Arial", 10.0!, FontStyle.Bold)
        style.BorderBottom = XLLineStyleEnum.Thin
        style.BorderLeft = XLLineStyleEnum.Thin
        style.BorderTop = XLLineStyleEnum.Thin
        style.BorderRight = XLLineStyleEnum.Thin

        Dim bBold As Boolean = False
        Dim bCenter As Boolean = False
        Dim iColStart As Integer = GetIntColumnExcel(tdbcColExcel.Text)

        For iRow As Integer = 0 To sheet.Rows.Count - 1
            For iCol As Integer = 0 To arrGroupColumns.Length - 1
                bBold = False
                bCenter = False
                For i As Integer = 0 To arrGroupColumns(iCol) - 1 + iColStart
                    Try
                        bBold = sheet(iRow, i).Style.Font.Bold
                    Catch
                    End Try
                    If bBold Then Exit For
                Next
                Try
                    bCenter = sheet(iRow, arrGroupColumns(iCol) - 1 + iColStart).Style.AlignHorz = XLAlignHorzEnum.Center
                Catch
                End Try
                If bBold Then
                    If bCenter Then
                        Continue For
                    End If
                    For iColumn As Integer = iColStart To sheet.Columns.Count - 1
                        cell = sheet(iRow, iColumn)
                        cell.Style = style
                    Next
                End If
            Next
        Next
        book.Save(sFile)
    End Sub

    Private Sub ExportPivotTable(ByVal sfileName As String, ByVal iUsedCol As Integer)
        'Chuyển qua kiểm tra AllowExport
        'If Not AllowExportPivotTable() Then
        '    Me.Cursor = Cursors.Default
        '    btnExport.Enabled = True
        '    Exit Sub
        'End If
        Dim xlSourceSheet As New Excel.Worksheet
        Dim xlPivotSheet As New Excel.Worksheet
        Dim rowField(tdbgRow.RowCount - 1) As Excel.PivotField
        Dim colField(tdbgColumn.RowCount - 1) As Excel.PivotField
        Dim pivotTable As Excel.PivotTable
        'Update 28/08/2010
        Dim book As Excel.Workbook

        Try
            book = EXL.Workbooks.Open(sfileName)
            xlSourceSheet = CType(EXL.Workbooks.Item(1).Sheets.Item(iSheetData), Excel.Worksheet)
            xlPivotSheet = CType(EXL.Workbooks.Item(1).Sheets.Item(iSheetPivot), Excel.Worksheet)
            xlPivotSheet.Select() 'Hiển thị mặc định SheetPivot 

            Dim sAreaMax As String = GetAreaMaxData(iUsedCol, dtExportTmp.Rows.Count)
            Dim sAreaMin As String = tdbcColExcel.Text & txtRow.Text
            'Minh Hòa Update 28/08/2010
            ' Thêm 3 dòng nếu có tiêu đề
            If txtTitle.Text.Trim <> "" Then
                sAreaMin = tdbcColExcel.Text & (Integer.Parse(txtRow.Text) + 3).ToString
            End If

            EXL.ActiveWorkbook.PivotCaches.Add(Excel.XlPivotTableSourceType.xlDatabase, xlSourceSheet.Range(sAreaMin & ":" & sAreaMax)).CreatePivotTable(xlPivotSheet.Range(sAreaMin), TableName:="PivotTable2")
            pivotTable = CType(xlPivotSheet.PivotTables("PivotTable2"), Excel.PivotTable)

            'Update 11/06/2010: Đọan code của lưới tdbgData phải đặt trước đọan code lưới tdbgRow và lưới tdbgColumn
            Dim sFieldNameDesc As String
            For i As Integer = 0 To tdbgData.RowCount - 1
                If _useUnicode Then
                    sFieldNameDesc = tdbgData(i, COL5_FieldNameDesc).ToString
                Else
                    sFieldNameDesc = ConvertVniToUnicode(tdbgData(i, COL5_FieldNameDesc).ToString)
                End If

                If tdbgData(i, COL5_ExcelFunction).ToString = "1" Then 'Count
                    pivotTable.AddDataField(pivotTable.PivotFields(sFieldNameDesc), "Count of" & Space(1) & sFieldNameDesc, Excel.XlConsolidationFunction.xlCount)
                Else 'Sum
                    pivotTable.AddDataField(pivotTable.PivotFields(sFieldNameDesc), "Sum of" & Space(1) & sFieldNameDesc, Excel.XlConsolidationFunction.xlSum)
                End If
            Next

            For i As Integer = 0 To tdbgRow.RowCount - 1
                If _useUnicode Then
                    rowField(i) = CType(pivotTable.PivotFields(tdbgRow(i, COL4_FieldNameDesc).ToString), Excel.PivotField)
                Else
                    rowField(i) = CType(pivotTable.PivotFields(ConvertVniToUnicode(tdbgRow(i, COL4_FieldNameDesc).ToString)), Excel.PivotField)
                End If

                rowField(i).Orientation = Excel.XlPivotFieldOrientation.xlRowField
                If chkSubTotalsRow.Checked = False Then
                    If rowField(i).Subtotals IsNot Nothing Then
                        Dim bSubtotals As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False}
                        rowField(i).Subtotals = bSubtotals
                    End If
                End If
            Next

            For i As Integer = 0 To tdbgColumn.RowCount - 1
                If _useUnicode Then
                    colField(i) = CType(pivotTable.PivotFields(tdbgColumn(i, COL3_FieldNameDesc).ToString), Excel.PivotField)
                Else
                    colField(i) = CType(pivotTable.PivotFields(ConvertVniToUnicode(tdbgColumn(i, COL3_FieldNameDesc).ToString)), Excel.PivotField)
                End If

                colField(i).Orientation = Excel.XlPivotFieldOrientation.xlColumnField
                If chkSubTotalsCol.Checked = False Then
                    If colField(i).Subtotals IsNot Nothing Then
                        Dim bSubtotals As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False}
                        colField(i).Subtotals = bSubtotals
                    End If
                End If
            Next

            'Minh Hòa Update 28/08/2010
            ProcessOptions(book, xlPivotSheet, iUsedCol)

            'Tuỳ chọn hiển thị
            pivotTable.ColumnGrand = chkGrandColumn.Checked
            pivotTable.RowGrand = chkGrandRow.Checked
            pivotTable.EnableFieldList = False
            EXL.CommandBars("PivotTable").Visible = False
            EXL.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: Export Pivot Table")
            CloseProcessWindow(sfileName, False)
        End Try
    End Sub

    Private Sub MsgErrorExcel(ByVal sMessage As String)
        If txtPathIn.Text.Trim <> "" Then
            Dim SplitArray() As String
            SplitArray = Microsoft.VisualBasic.Split(txtPathIn.Text, "\")
            D99C0008.MsgL3(rL3("Ban_phai_dong_File") & " " & SplitArray(SplitArray.Length - 1) & " " & rL3("truoc_khi_xuat_Excel"))
        Else
            D99C0008.MsgL3(rL3("Ban_phai_dong_File_Dataxls_truoc_khi_xuat_Excel"))
        End If
    End Sub

    Private Sub btnChoosePathIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoosePathIn.Click
        Dim file As New OpenFileDialog
        file.Filter = "Excel File (*.xls)|*.xls"
        If (file.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            txtPathIn.Text = file.FileName
            cboDefaultSheet.Enabled = True
        End If
        txtPathIn_Validated(Nothing, Nothing)
    End Sub

    Private Sub btnChoosePathOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoosePathOut.Click
        Dim sFolder As New FolderBrowserDialog
        sFolder.Description = "Chọn thư mục chứa file xuất excel"
        If txtPathOut.Text <> "" Then
            sFolder.SelectedPath = txtPathOut.Text
        Else
            sFolder.SelectedPath = DEFAULT_PATH_OUT
        End If
        sFolder.ShowNewFolderButton = True
        If sFolder.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPathOut.Text = sFolder.SelectedPath
        End If
        sFolder.Dispose()
        chkIsMarkTimer.Enabled = txtPathIn.Text.Trim <> "" 'AndAlso txtPathOut.Text.Trim() <> ""
        txtPathOut_Validated(Nothing, Nothing)
    End Sub


    Private Function CheckInputCode(ByVal sCode As String) As Boolean
        Dim sStringInput As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Return sStringInput.Contains(sCode.Trim.Substring(0, 1))

    End Function

    Private Function AllowSave() As Boolean
        If Not CheckPath() Then Return False 'Kiểm tra thư mục hợp lệ
        If txtExcelTemplateID.Visible = True Then
            If txtExcelTemplateID.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Mau_xuat_Excel"))
                tabMain.SelectedTab = TabInfo
                txtExcelTemplateID.Focus()
                Return False
            Else
                If Not CheckInputCode(txtExcelTemplateID.Text) Then
                    D99C0008.MsgL3(rL3("Mau_xuat_Excel") & Space(1) & rL3("khong_hop_le"))
                    tabMain.SelectedTab = TabInfo
                    txtExcelTemplateID.Focus()
                    Return False
                End If
            End If

            If ExistRecord("Select Top 1 1 From D91T2021 WITH(NOLOCK) Where FormID = " & SQLString(sFormName) & " And ExcelTemplateID = " & SQLString(IIf(_FormState = EnumFormState.FormAdd, txtExcelTemplateID.Text, tdbcExcelTemplateID.Text))) Then
                D99C0008.MsgDuplicatePKey()
                If _FormState = EnumFormState.FormAdd Then
                    tabMain.SelectedTab = TabInfo
                    txtExcelTemplateID.Focus()
                Else
                    tabMain.SelectedTab = TabInfo
                    tdbcExcelTemplateID.Focus()
                End If
                Return False
            End If
        Else
            If tdbcExcelTemplateID.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("Mau_xuat_Excel"))
                tabMain.SelectedTab = TabInfo
                tdbcExcelTemplateID.Focus()
                Return False
            End If
        End If
        If txtChecked.Text = txtUnChecked.Text Or (txtChecked.Text = "" And txtUnChecked.Text = "") Then
            D99C0008.MsgNotYetChoose(IIf(gsLanguage = "84", "Thiết lập dữ liệu xuất cho giá trị của cột tùy chọn không hợp lệ.", "Setup value for Checkbox data column is not valid").ToString)
            tabMain.SelectedTab = TabAdvance
            txtChecked.Focus()
            Return False
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        Else
            For i As Integer = 0 To tdbg.RowCount - 1
                If L3Bool(tdbg(i, COL_IsUsed).ToString) Then
                    Return True
                End If
            Next
            D99C0008.MsgNoDataInGrid()
            Return False
        End If
        Return True
    End Function

    Private Sub btnNotSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotSave.Click
        If AskMsgBeforeRowChange() Then
            If Not SaveData(sender) Then Exit Sub
        Else
            LoadTDBCombo()
            If Not bCheckD91T2021 Then
                btnDelete.Enabled = False
                tdbcExcelTemplateID.Visible = False
                txtExcelTemplateID.Visible = True
                txtExcelTemplateID.Enabled = True
                txtExcelTemplateID.Text = ""
                _FormState = EnumFormState.FormAdd
                'Update 07/07/2010: Thêm mới thì Check, Sửa thì UnCheck
                chkShowAll.Checked = True

                LoadGrid()
                btnDelete.Enabled = False
            Else
                txtExcelTemplateID.Visible = False
                tdbcExcelTemplateID.Visible = True

                'Update 07/07/2010: Thêm mới thì Check, Sửa thì UnCheck
                chkShowAll.Checked = False
                tdbcExcelTemplateID.SelectedIndex = 1
                btnDelete.Enabled = True
                _FormState = EnumFormState.FormEdit
            End If
            btnSave.Enabled = True
        End If
    End Sub

    Private Function SaveData(ByVal sender As System.Object) As Boolean
        tdbgSubTotals.UpdateData()
        tdbgColumn.UpdateData()
        tdbgRow.UpdateData()
        tdbgData.UpdateData()

        If Not AllowSave() Then Exit Function

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD91T2021s().ToString & vbCrLf)
                sSQL.Append(SQLInsertD91T2023s())
            Case EnumFormState.FormEdit
                sSQL.Append("Delete From D91T2021 Where FormID = " & SQLString(sFormName) & " And ExcelTemplateID = " & SQLString(tdbcExcelTemplateID.Text) & vbCrLf)
                sSQL.Append(SQLInsertD91T2021s().ToString & vbCrLf)
                sSQL.Append("Delete From D91T2023 Where FormID = " & SQLString(sFormName) & " And ExcelTemplateID = " & SQLString(tdbcExcelTemplateID.Text) & vbCrLf)
                sSQL.Append(SQLInsertD91T2023s)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    txtExcelTemplateID.Visible = False
                    tdbcExcelTemplateID.Visible = True
                    LoadTDBCombo()
                    _FormState = EnumFormState.FormEdit
                    tdbcExcelTemplateID.Text = txtExcelTemplateID.Text
                    btnSave.Enabled = True
                    btnDelete.Enabled = True
                Case EnumFormState.FormEdit
                    LoadTableD91T2023()
                    If _modeVB6 <> 1 Then CreateTableGrid()
                    LoadGrid()
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        'Hỏi trước khi lưu
        If AskSave() = Windows.Forms.DialogResult.No Then
            ' SetReturnFormView()
            Exit Sub
        End If
        SaveData(sender)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        Dim sSQL As String
        sSQL = "Delete From D91T2021 Where FormID = " & SQLString(sFormName) & " And  ExcelTemplateID = " & SQLString(IIf(_FormState = EnumFormState.FormAdd, txtExcelTemplateID.Text, tdbcExcelTemplateID.Text)) & vbCrLf
        sSQL &= "Delete From D91T2023 Where FormID = " & SQLString(sFormName) & " And  ExcelTemplateID = " & SQLString(IIf(_FormState = EnumFormState.FormAdd, txtExcelTemplateID.Text, tdbcExcelTemplateID.Text))
        If ExecuteSQL(sSQL) Then
            DeleteOK()
            LoadTDBCombo()
            If Not bCheckD91T2021 Then
                btnDelete.Enabled = False
                tdbcExcelTemplateID.Visible = False
                txtExcelTemplateID.Visible = True
                txtExcelTemplateID.Enabled = True
                txtExcelTemplateID.Text = ""
                _FormState = EnumFormState.FormAdd
                'Update 07/07/2010: Thêm mới thì Check, Sửa thì UnCheck
                chkShowAll.Checked = True

                LoadGrid()
            Else
                txtExcelTemplateID.Visible = False
                'Update 07/07/2010: Thêm mới thì Check, Sửa thì UnCheck
                chkShowAll.Checked = False
                tdbcExcelTemplateID.SelectedIndex = 1
                _FormState = EnumFormState.FormEdit
            End If
            btnSave.Enabled = True
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub chkShowAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowAll.Click
        tdbg.UpdateData()
        If chkShowAll.Checked Then
            ReturnTableFilterRow(dtGrid, "")
        Else
            ReturnTableFilterRow(dtGrid, "IsUsed = 1")
        End If
    End Sub

    Private Sub txtSheet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    'Private Sub txtPath_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPath.LostFocus
    '    cboDefaultSheet.Enabled = Not (txtPath.Text.Trim = "")
    '    If txtPath.Text.Trim = "" Then
    '        cboDefaultSheet.Enabled = False
    '        cboDefaultSheet.Text = ""
    '        cboDefaultSheet.Items.Clear()
    '    Else
    '        cboDefaultSheet.Enabled = True
    '        If My.Computer.FileSystem.FileExists(txtPath.Text) = True Then
    '            GetNameSheets()
    '        Else
    '            cboDefaultSheet.Items.Clear()
    '            cboDefaultSheet.Text = ""
    '        End If
    '    End If
    'End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        If tdbg.Row > 0 Then
            MoveRowNew(tdbg, tdbg.Row, tdbg.Row - 1, COL_FieldName)
            tdbg.Bookmark = tdbg.Row - 1
        End If
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        If tdbg.Row < tdbg.RowCount - 1 Then
            MoveRowNew(tdbg, tdbg.Row, tdbg.Row + 1, COL_FieldName)
            tdbg.Bookmark = tdbg.Row + 1
        End If
    End Sub

    Private Sub chkConvertUnicode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkConvertUnicode.Click
        dtExportTmp = Nothing
        chkConvertUnicode.Tag = False
    End Sub

#End Region

#Region "SQL Store"

    Private Function SQLStoreD91P2020() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P2020 "
        sSQL &= SQLString(sFormName.Substring(1, 2)) & COMMA 'ModuleID, varchar, NOT NULL
        sSQL &= SQLString("(" & _formID & ")") & COMMA 'FormID, varchar[10], NOT NULL
        'Design By Thanh Phương 16/07/2009
        'Trong trường hợp thêm mới truyền ExcelTemplateID = '%' để đổ ra hết dữ liệu
        If _FormState = EnumFormState.FormAdd Then
            sSQL &= SQLString("%") & COMMA 'ExcelTemplateID, varchar[50], NOT NULL
        Else
            sSQL &= SQLString(tdbcExcelTemplateID.SelectedValue) & COMMA 'ExcelTemplateID, varchar[50], NOT NULL
        End If
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLNumber("1") 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Function SQLInsertD91T2021s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed).ToString) Then
                sSQL.AppendLine("Insert Into D91T2021(")
                sSQL.AppendLine("OrderNum, FieldName, FieldNameU, ModuleID, FormID, ExcelTemplateID, NumberFormat,")
                sSQL.AppendLine("IsUnicode, DisplayColumn, DisplayRow, Path, ")
                sSQL.AppendLine("SheetExcel, ShowColTitle, IsExportType, ExportType, ")
                sSQL.AppendLine("SubtotalRow, SubtotalColumn, GrandTotalRow, GrandTotalColumn, Title, TitleU, ")
                sSQL.AppendLine("CheckValue, UnCheckValue, PageOrientation, PagePercent, PageSize, IsAutoSizeColumn,IsMarkTimer,PathOut, IsNoFormula ")
                sSQL.AppendLine(") Values(")
                sSQL.Append(SQLNumber(i + 1) & COMMA) 'OrderNum, int, NOT NULL
                If _useUnicode Then
                    sSQL.Append("''" & COMMA) 'FieldName, varchar[50], NOT NULL
                    sSQL.Append(SQLStringUnicode(tdbg(i, COL_FieldName).ToString, True, True) & COMMA) 'FieldNameU, varchar[50], NOT NULL
                Else
                    sSQL.Append(SQLString(tdbg(i, COL_FieldName).ToString) & COMMA) 'FieldName, varchar[50], NOT NULL
                    sSQL.Append("''" & COMMA) 'FieldNameU, varchar[50], NOT NULL
                End If
                sSQL.Append(SQLString(sFormName.Substring(1, 2)) & COMMA) 'ModuleID, varchar, NOT NULL
                sSQL.Append(SQLString(sFormName) & COMMA) 'FormID, varchar[10], NOT NULL
                If _FormState = EnumFormState.FormAdd Then
                    sSQL.Append(SQLString(txtExcelTemplateID.Text) & COMMA) 'ExcelTemplateID, varchar[50], NOT NULL
                Else
                    sSQL.Append(SQLString(tdbcExcelTemplateID.Text) & COMMA) 'ExcelTemplateID, varchar[50], NOT NULL
                End If
                sSQL.Append(SQLNumber(tdbg(i, COL_NumberFormat).ToString) & COMMA & vbCrLf) 'NumberFormat, tinyint, NOT NULL
                sSQL.Append(SQLNumber(chkConvertUnicode.Checked) & COMMA) 'IsUnicode, tinyint, NOT NULL
                sSQL.Append(SQLString(tdbcColExcel.Text) & COMMA) 'DisplayColumn, varchar[20], NOT NULL
                sSQL.Append(SQLNumber(txtRow.Text) & COMMA) 'DisplayRow, int, NOT NULL
                sSQL.Append(SQLString(txtPathIn.Text) & COMMA) 'Path, varchar[500], NOT NULL
                sSQL.Append(SQLString(cboDefaultSheet.Text) & COMMA) 'SheetExcel, varchar[100], NOT NULL
                sSQL.Append(SQLNumber(chkDisplayTitle.Checked) & COMMA) 'ShowColTitle, tinyint, NOT NULL
                sSQL.Append(SQLNumber(chkIsExportType.Checked) & COMMA) 'IsExportType, tinyint, NOT NULL
                sSQL.Append(SQLNumber(optPivotTable.Checked) & COMMA) 'ExportType, tinyint, NOT NULL
                sSQL.Append(SQLNumber(chkSubTotalsRow.Checked) & COMMA) 'SubtotalRow, tinyint, NOT NULL
                sSQL.Append(SQLNumber(chkSubTotalsCol.Checked) & COMMA) 'SubtotalColumn, tinyint, NOT NULL
                sSQL.Append(SQLNumber(chkGrandRow.Checked) & COMMA) 'GrandTotalRow, tinyint, NOT NULL
                sSQL.Append(SQLNumber(chkGrandColumn.Checked) & COMMA) 'GrandTotalColumn, tinyint, NOT NULL
                If _useUnicode Then
                    sSQL.Append(SQLString("") & COMMA) 'Title, varchar[250], NOT NULL
                    sSQL.Append("N" & SQLString(txtTitle.Text) & COMMA) 'TitleU, nvarchar[250], NOT NULL
                Else
                    sSQL.Append(SQLString(txtTitle.Text) & COMMA) 'Title, varchar[250], NOT NULL
                    sSQL.Append(SQLString("") & COMMA) 'TitleU, nvarchar[250], NOT NULL
                End If
                sSQL.Append(SQLString(txtChecked.Text) & COMMA)
                sSQL.Append(SQLString(txtUnChecked.Text) & COMMA)
                sSQL.Append(SQLNumber(optLandscape.Checked) & COMMA)
                sSQL.Append(SQLNumber(dudAdjust.Text) & COMMA)
                sSQL.Append(SQLString(cboPageSize.Text) & COMMA)
                sSQL.Append(SQLNumber(chkIsAutoSizeColumn.Checked) & COMMA) 'IsAutoSizeColumn, tinyint, NOT NULL
                sSQL.Append(SQLNumber(chkIsMarkTimer.Checked) & COMMA) 'IsMarkTimer, tinyint, NOT NULL
                sSQL.Append(SQLString(txtPathOut.Text) & COMMA)
                sSQL.Append(SQLNumber(chkIsNoFormula.Checked))
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    Private Function SQLInsertD91T2023s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sSQLInsert As String
        sSQLInsert = "Insert Into D91T2023( "
        sSQLInsert &= "ModuleID, FormID, ExcelTemplateID, ExportType, DisplayType, "
        sSQLInsert &= "GroupFieldName, GroupFieldNameU, FieldName, FieldNameU, OrderNum, "
        sSQLInsert &= "ExcelFunction)" & vbCrLf

        Dim iOrderNum As Integer = 0
        Dim iExportType As Integer = 0
        Dim iDisplayType As Integer = 0
        Dim dr1 As DataRow
        'Dạng Subtotals
        For j As Integer = 0 To tdbgGroup.RowCount - 1
            dtSubTotals.DefaultView.Sort = "OrderNum"
            dtSubTotals = dtSubTotals.DefaultView.ToTable

            Dim dr() As DataRow
            dr = dtSubTotals.Select("GroupFieldName = " & SQLString(tdbgGroup(j, COL1_GroupFieldName)) & " And FieldName <> ''")

            iOrderNum = 0
            For i As Integer = 0 To dr.Length - 1
                dr1 = dr(i)
                sSQL.Append(sSQLInsert)
                sSQL.Append(" Values(" & vbCrLf)
                sSQL.Append(SQLString(sFormName.Substring(1, 2)) & COMMA) 'ModuleID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(sFormName) & COMMA) 'FormID [KEY], varchar[20], NOT NULL

                If _FormState = EnumFormState.FormAdd Then
                    sSQL.Append(SQLString(txtExcelTemplateID.Text) & COMMA) 'ExcelTemplateID, varchar[50], NOT NULL
                Else
                    sSQL.Append(SQLString(tdbcExcelTemplateID.Text) & COMMA) 'ExcelTemplateID, varchar[50], NOT NULL
                End If

                sSQL.Append(SQLNumber(iExportType) & COMMA) 'ExportType, int, NOT NULL
                sSQL.Append(SQLNumber(iDisplayType) & COMMA) 'DisplayType, int, NOT NULL
                If _useUnicode Then
                    sSQL.Append("''" & COMMA) 'GroupFieldName, varchar[50], NOT NULL
                    sSQL.Append(SQLString(dr1("GroupFieldName").ToString) & COMMA) 'GroupFieldNameU, varchar[50], NOT NULL
                    sSQL.Append("''" & COMMA) 'FieldName, varchar[50], NOT NULL
                    sSQL.Append(SQLStringUnicode(dr1("FieldName").ToString, True, True) & COMMA) 'FieldNameU, varchar[50], NOT NULL
                Else
                    sSQL.Append(SQLString(dr1("GroupFieldName").ToString) & COMMA) 'GroupFieldName, varchar[50], NOT NULL
                    sSQL.Append("''" & COMMA) 'GroupFieldNameU, varchar[50], NOT NULL
                    sSQL.Append(SQLString(dr1("FieldName").ToString) & COMMA) 'FieldName, varchar[50], NOT NULL
                    sSQL.Append("''" & COMMA) 'FieldNameU, varchar[50], NOT NULL
                End If

                sSQL.Append(SQLNumber(iOrderNum + 1) & COMMA) 'OrderNum, int, NOT NULL
                sSQL.Append(SQLNumber(dr1("ExcelFunction").ToString)) 'ExcelFunction, int, NOT NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
                iOrderNum += 1
            Next
        Next

        'Dạng PivotTable
        iExportType = 1
        'Dạng cột
        iDisplayType = 0
        iOrderNum = 0
        For i As Integer = 0 To tdbgColumn.RowCount - 1
            sSQL.Append(sSQLInsert)
            sSQL.Append("Values(" & vbCrLf)
            sSQL.Append(SQLString(sFormName.Substring(1, 2)) & COMMA) 'ModuleID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(sFormName) & COMMA) 'FormID [KEY], varchar[20], NOT NULL
            If _FormState = EnumFormState.FormAdd Then
                sSQL.Append(SQLString(txtExcelTemplateID.Text) & COMMA) 'ExcelTemplateID, varchar[50], NOT NULL
            Else
                sSQL.Append(SQLString(tdbcExcelTemplateID.Text) & COMMA) 'ExcelTemplateID, varchar[50], NOT NULL
            End If
            sSQL.Append(SQLNumber(iExportType) & COMMA) 'ExportType, int, NOT NULL
            sSQL.Append(SQLNumber(iDisplayType) & COMMA) 'DisplayType, int, NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'GroupFieldName, varchar[50], NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'GroupFieldNameU, varchar[50], NOT NULL
            If _useUnicode Then
                sSQL.Append("''" & COMMA) 'FieldName, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbgColumn(i, COL3_FieldName).ToString) & COMMA) 'FieldNameU, varchar[50], NOT NULL
            Else
                sSQL.Append(SQLString(tdbgColumn(i, COL3_FieldName).ToString) & COMMA) 'FieldName, varchar[50], NOT NULL
                sSQL.Append("''" & COMMA) 'FieldNameU, varchar[50], NOT NULL
            End If
            sSQL.Append(SQLNumber(iOrderNum + 1) & COMMA) 'OrderNum, int, NOT NULL
            sSQL.Append(SQLNumber(0)) 'ExcelFunction, int, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
            iOrderNum += 1
        Next

        'Dạng dòng
        iDisplayType = 1
        iOrderNum = 0
        For i As Integer = 0 To tdbgRow.RowCount - 1
            sSQL.Append(sSQLInsert)
            sSQL.Append(" Values(" & vbCrLf)
            sSQL.Append(SQLString(sFormName.Substring(1, 2)) & COMMA) 'ModuleID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(sFormName) & COMMA) 'FormID [KEY], varchar[20], NOT NULL
            If _FormState = EnumFormState.FormAdd Then
                sSQL.Append(SQLString(txtExcelTemplateID.Text) & COMMA) 'ExcelTemplateID, varchar[50], NOT NULL
            Else
                sSQL.Append(SQLString(tdbcExcelTemplateID.Text) & COMMA) 'ExcelTemplateID, varchar[50], NOT NULL
            End If
            sSQL.Append(SQLNumber(iExportType) & COMMA) 'ExportType, int, NOT NULL
            sSQL.Append(SQLNumber(iDisplayType) & COMMA) 'DisplayType, int, NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'GroupFieldName, varchar[50], NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'GroupFieldNameU, varchar[50], NOT NULL
            If _useUnicode Then
                sSQL.Append("''" & COMMA) 'FieldName, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbgRow(i, COL4_FieldName).ToString) & COMMA) 'FieldNameU, varchar[50], NOT NULL
            Else
                sSQL.Append(SQLString(tdbgRow(i, COL4_FieldName).ToString) & COMMA) 'FieldName, varchar[50], NOT NULL
                sSQL.Append("''" & COMMA) 'FieldNameU, varchar[50], NOT NULL
            End If
            sSQL.Append(SQLNumber(iOrderNum + 1) & COMMA) 'OrderNum, int, NOT NULL
            sSQL.Append(SQLNumber(0)) 'ExcelFunction, int, NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
            iOrderNum += 1
        Next

        'Dạng dữ liệu
        iDisplayType = 2
        iOrderNum = 0
        For i As Integer = 0 To tdbgData.RowCount - 1
            sSQL.Append(sSQLInsert)
            sSQL.Append("Values(" & vbCrLf)
            sSQL.Append(SQLString(sFormName.Substring(1, 2)) & COMMA) 'ModuleID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(sFormName) & COMMA) 'FormID [KEY], varchar[20], NOT NULL
            If _FormState = EnumFormState.FormAdd Then
                sSQL.Append(SQLString(txtExcelTemplateID.Text) & COMMA) 'ExcelTemplateID, varchar[50], NOT NULL
            Else
                sSQL.Append(SQLString(tdbcExcelTemplateID.Text) & COMMA) 'ExcelTemplateID, varchar[50], NOT NULL
            End If
            sSQL.Append(SQLNumber(iExportType) & COMMA) 'ExportType, int, NOT NULL
            sSQL.Append(SQLNumber(iDisplayType) & COMMA) 'DisplayType, int, NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'GroupFieldName, varchar[50], NOT NULL
            sSQL.Append(SQLString("") & COMMA) 'GroupFieldNameU, varchar[50], NOT NULL
            If _useUnicode Then
                sSQL.Append("''" & COMMA) 'FieldName, varchar[50], NOT NULL
                sSQL.Append(SQLString(tdbgData(i, COL5_FieldName).ToString) & COMMA) 'FieldNameU, varchar[50], NOT NULL
            Else
                sSQL.Append(SQLString(tdbgData(i, COL5_FieldName).ToString) & COMMA) 'FieldName, varchar[50], NOT NULL
                sSQL.Append("''" & COMMA) 'FieldNameU, varchar[50], NOT NULL
            End If

            sSQL.Append(SQLNumber(iOrderNum + 1) & COMMA) 'OrderNum, int, NOT NULL

            sSQL.Append(SQLNumber(tdbgData(i, COL5_ExcelFunction))) 'ExcelFunction, int, NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
            iOrderNum += 1
        Next
        Return sRet
    End Function

#End Region

#Region "Button RightLeft"

    Private Sub btnRightGroup_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightGroup.Click
        Try
            If L3Bool(tdbg.Columns(COL_IsUsed).Text) = False Then Exit Sub

            'Kiểm tra có giá trị trong lưới chưa, nếu có thì thoát không thêm vào
            tdbgGroup.UpdateData()
            For i As Integer = 0 To tdbgGroup.RowCount - 1
                If tdbgGroup(i, COL1_GroupFieldName).ToString = tdbg.Columns(COL_FieldName).Text Then
                    Exit Sub
                End If
            Next

            btdbgGroup_RowColChange = False
            LoadDataNewGroup(tdbg.Columns(COL_FieldName).Text, tdbg.Columns(COL_Description).Text)
            AddIndexIsExport()

            tdbgGroup_RowColChange(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLeftGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftGroup.Click
        Try
            Dim dr() As DataRow = dtSubTotals.Select("GroupFieldName = " & SQLString(tdbgGroup(tdbgGroup.Bookmark, COL1_GroupFieldName).ToString) & " And FieldName <> ''")
            For i As Integer = 0 To dr.Length - 1
                'Remove Index IsExport
                For j As Integer = 0 To tdbg.RowCount - 1
                    If tdbg(j, COL_FieldName).ToString = dr(i).Item("FieldName").ToString Then
                        tdbg(j, COL_IsExport) = (L3Int(tdbg(j, COL_IsExport)) - 1).ToString
                        Exit For
                    End If
                Next
                'Remove các dòng thuộc group
                dtSubTotals.Rows.Remove(dr(i))
            Next

            RemoveIndexIsExport(tdbgGroup(tdbgGroup.Bookmark, COL1_GroupFieldName).ToString)

            tdbgGroup.Delete()
            tdbgGroup_RowColChange(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRightSubtotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightSubtotals.Click
        Try
            If L3Bool(tdbg.Columns(COL_IsUsed).Text) = False Then Exit Sub
            If tdbgGroup.Columns(COL1_GroupFieldName).Text = "" Then Exit Sub
            Dim iExportType As Integer = 0 'SubTotalss
            Dim iDisplayType As Integer = 0
            Dim ExcelFunction As Integer = L3Int(IIf(bSum = True, 0, 1)) 'Hàm Sum
            Dim OrderNum As Integer = dtSubTotals.Rows.Count
            'Huỳnh Edit 27/05/2010: Khi chưa có SubTotal thì gán giá trị, ko Addnew
            Dim dtTmp As DataTable
            dtTmp = ReturnTableFilter(dtSubTotals, "GroupFieldName = " & SQLString(tdbgGroup.Columns(COL1_GroupFieldName).Text) & " And FieldName = ''", True)
            If dtTmp.Rows.Count > 0 Then
                For i As Integer = 0 To dtSubTotals.Rows.Count - 1
                    If dtSubTotals.Rows(i).Item("GroupFieldName").ToString = tdbgGroup.Columns(COL1_GroupFieldName).Text Then
                        dtSubTotals.Rows(i).Item("FieldName") = tdbg.Columns(COL_FieldName).Text
                        dtSubTotals.Rows(i).Item("FieldNameDesc") = tdbg.Columns(COL_Description).Text
                    End If
                Next
            Else
                dtSubTotals.PrimaryKey = New DataColumn() {dtSubTotals.Columns("GroupFieldName"), dtSubTotals.Columns("FieldName")}
                dtSubTotals.Rows.Add(New Object() {tdbcExcelTemplateID.Text, iExportType, iDisplayType, OrderNum, L3Int(tdbgGroup.Columns(COL1_ExcelFunction).Value), _
                tdbgGroup.Columns(COL1_GroupFieldName).Text, tdbg.Columns(COL_FieldName).Text, tdbgGroup.Columns(COL1_GroupFieldNameDesc).Text, tdbg.Columns(COL_Description).Text})
            End If
            AddIndexIsExport()
            tdbgGroup_RowColChange(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLefttSubtotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLefttSubtotals.Click
        Try
            Dim dr() As DataRow = dtSubTotals.Select("GroupFieldName = " & SQLString(tdbgSubTotals(tdbgSubTotals.Bookmark, COL2_GroupFieldName).ToString) & " And FieldName = " & SQLString(tdbgSubTotals(tdbgSubTotals.Bookmark, COL2_FieldName).ToString))
            If dr.Length > 0 Then dtSubTotals.Rows.Remove(dr(0))

            RemoveIndexIsExport(tdbgSubTotals(tdbgSubTotals.Bookmark, COL2_FieldName).ToString)
            tdbgGroup_RowColChange(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRightCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightCol.Click
        Try
            If L3Bool(tdbg.Columns(COL_IsUsed).Text) = False Then Exit Sub
            '************************************************
            'Kiểm tra tồn tại field này chưa
            If ExistFieldNamePivot(tdbg.Columns(COL_FieldName).Text) Then Exit Sub
            '************************************************
            'Add thêm nhóm mới vào lươí
            tdbgColumn.UpdateData()
            tdbgColumn.MoveLast()
            tdbgColumn.Row += 1
            tdbgColumn.Columns(COL3_FieldName).Text = tdbg.Columns(COL_FieldName).Text
            tdbgColumn.Columns(COL3_FieldNameDesc).Text = tdbg.Columns(COL_Description).Text
            '************************************************
            AddIndexIsExport()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLeftCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftCol.Click
        Try
            RemoveIndexIsExport(tdbgColumn(tdbgColumn.Bookmark, COL3_FieldName).ToString)

            tdbgColumn.Delete()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRightRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightRow.Click
        Try
            If L3Bool(tdbg.Columns(COL_IsUsed).Text) = False Then Exit Sub
            '************************************************
            'Kiểm tra tồn tại field này chưa
            If ExistFieldNamePivot(tdbg.Columns(COL_FieldName).Text) Then Exit Sub
            '************************************************
            'Add thêm nhóm mới vào lươí
            tdbgRow.UpdateData()
            tdbgRow.MoveLast()
            tdbgRow.Row += 1
            tdbgRow.Columns(COL4_FieldName).Text = tdbg.Columns(COL_FieldName).Text
            tdbgRow.Columns(COL4_FieldNameDesc).Text = tdbg.Columns(COL_Description).Text
            '************************************************
            AddIndexIsExport()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLeftRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftRow.Click
        Try
            RemoveIndexIsExport(tdbgRow(tdbgRow.Bookmark, COL4_FieldName).ToString)

            tdbgRow.Delete()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRightData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightData.Click
        Try
            If L3Bool(tdbg.Columns(COL_IsUsed).Text) = False Then Exit Sub
            '************************************************
            'Kiểm tra tồn tại field này chưa
            'Update 10/06/2010: thêm đối số True sau hàm này
            If ExistFieldNamePivot(tdbg.Columns(COL_FieldName).Text, True) Then Exit Sub
            '************************************************
            'Add thêm nhóm mới vào lươí
            tdbgData.UpdateData()
            tdbgData.MoveLast()
            tdbgData.Row += 1
            tdbgData.Columns(COL5_FieldName).Text = tdbg.Columns(COL_FieldName).Text
            tdbgData.Columns(COL5_FieldNameDesc).Text = tdbg.Columns(COL_Description).Text
            tdbgData.Columns(COL5_ExcelFunction).Value = 0
            '************************************************
            AddIndexIsExport()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLeftData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftData.Click
        Try
            RemoveIndexIsExport(tdbgData(tdbgData.Bookmark, COL5_FieldName).ToString)

            tdbgData.Delete()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Optional Click"

    Private Sub optPivotTable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optPivotTable.Click
        SetOptionExportType(1)
    End Sub

    Private Sub optSubTotals_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSubTotals.Click
        SetOptionExportType(0)
    End Sub

    Private Sub SetOptionExportType(ByVal iMode As Int16)
        If iMode = 1 Then
            optPivotTable.Checked = True
            optSubTotals.Checked = False

        Else
            optPivotTable.Checked = False
            optSubTotals.Checked = True
        End If
    End Sub

    Private Sub chkIsExportType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsExportType.Click
        If chkIsExportType.Checked Then
            grpSubTotals.Enabled = True
            grpPivotTable.Enabled = True
            chkDisplayTitle.Checked = True
            chkDisplayTitle.Enabled = False
        Else
            grpSubTotals.Enabled = False
            grpPivotTable.Enabled = False
            chkDisplayTitle.Enabled = True
        End If

    End Sub

#End Region

#Region "Các hàm"

    Private Sub LoadDataNewGroup(ByVal sNewGroup As String, ByVal sNewGroupDesc As String)
        Dim iExportType, iDisplayType, OrderNum As Integer
        Dim ExcelFunction As Integer
        Dim GroupFieldName, GroupFieldNameDesc, FieldName, FieldNameDesc As String
        Dim iOrder As Integer = 0

        GroupFieldName = sNewGroup
        GroupFieldNameDesc = sNewGroupDesc
        iExportType = 0 'Dạng SubTotal
        iDisplayType = 0
        OrderNum = 0
        ExcelFunction = L3Int(IIf(bSum = True, 0, 1)) 'Hàm Sum
        '************************************************
        'Add thêm nhóm mới vào lươí
        tdbgGroup.UpdateData()
        tdbgGroup.MoveLast()
        tdbgGroup.Row += 1
        tdbgGroup.Columns(COL1_GroupFieldName).Text = GroupFieldName
        tdbgGroup.Columns(COL1_GroupFieldNameDesc).Text = GroupFieldNameDesc
        tdbgGroup.Columns(COL1_ExcelFunction).Text = ExcelFunction.ToString
        '************************************************
        If bSum = True Then
            For j As Integer = 0 To tdbg.RowCount - 1
                If L3Bool(tdbg(j, COL_IsUsed)) = True And L3Int(tdbg(j, COL_IsSum).ToString) = 1 Then
                    FieldName = tdbg(j, COL_FieldName).ToString
                    FieldNameDesc = tdbg(j, COL_Description).ToString
                    OrderNum = iOrder + 1
                    dtSubTotals.PrimaryKey = New DataColumn() {dtSubTotals.Columns("GroupFieldName"), dtSubTotals.Columns("FieldName")}
                    dtSubTotals.Rows.Add(New Object() {tdbcExcelTemplateID.Text, iExportType, iDisplayType, OrderNum, ExcelFunction, _
                    GroupFieldName, FieldName, GroupFieldNameDesc, FieldNameDesc})

                    iOrder += 1
                    'Gán chỉ số cho cột COL_IsExport của lưới xuất excel
                    tdbg(j, COL_IsExport) = (L3Int(tdbg(j, COL_IsExport)) + 1).ToString
                End If
            Next
            If iOrder = 0 Then
                bSum = False
                tdbgGroup.Columns(COL1_ExcelFunction).Text = "1"
            End If

        End If
        btdbgGroup_RowColChange = True
    End Sub

    Private Sub AddIndexIsExport()
        tdbg.Columns(COL_IsExport).Text = (L3Int(tdbg.Columns(COL_IsExport).Text) + 1).ToString
    End Sub

    Private Sub RemoveIndexIsExport(ByVal sFieldName As String)
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_FieldName).ToString = sFieldName Then
                tdbg(i, COL_IsExport) = (L3Int(tdbg(i, COL_IsExport)) - 1).ToString
                Exit For
            End If
        Next
    End Sub

    Private Function ExistFieldNameGroup(ByVal sFieldName As String) As Boolean
        For i As Integer = 0 To tdbgGroup.RowCount - 1
            If tdbgColumn(i, COL1_GroupFieldName).ToString = sFieldName Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function ExistFieldNamePivot(ByVal sFieldName As String, Optional ByVal bIsColData As Boolean = False) As Boolean
        'Update 10/06/2010: thêm đối số bIsColData: True là đẩy vào lưới Dữ liệu
        If Not bIsColData Then
            For i As Integer = 0 To tdbgColumn.RowCount - 1
                If tdbgColumn(i, COL3_FieldName).ToString = sFieldName Then
                    Return True
                End If
            Next
            For i As Integer = 0 To tdbgRow.RowCount - 1
                If tdbgRow(i, COL4_FieldName).ToString = sFieldName Then
                    Return True
                End If
            Next
        Else
            For i As Integer = 0 To tdbgData.RowCount - 1
                If tdbgData(i, COL5_FieldName).ToString = sFieldName Then
                    Return True
                End If
            Next
        End If

        Return False
    End Function

    ''' <summary>
    ''' Lấy  FormName dùng để lưu mẫu xuất dữ liệu
    ''' Nếu FormID được truyền là một chuỗi các Form thì FormName được lấy phần tử đầu tiên của chuỗi đó
    ''' còn FormID được truyền từ 1 Form thì FormName là chính nó
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetFormName()
        Dim barr As Boolean = False
        sFormName = _formID.Trim
        'Kiểm tra xem có phải là chuỗi giá trị hay không
        barr = sFormName.Contains(",")
        If barr = True Then 'Nếu là chuỗi thì cắt lấy giá trị đầu tiên
            sFormName = sFormName.Substring(0, sFormName.IndexOf(","))
            sFormName = sFormName.Trim.Substring(1) 'Cắt dấu nháy đầu tiền
            sFormName = sFormName.Substring(0, sFormName.IndexOf("'")) 'Cắt dấu nháy cuối
        Else
            sFormName = _formID.Trim
            _formID = "'" & _formID & "'" ' Nếu truyền vào 1 Form thì truyền thêm 2 dấu nháy (đầu và cuối)
        End If
    End Sub

    Private Function GetDisabledColumn() As Int32
        Dim iCount As Int32 = 0
        arrDisabledColumn.Clear()
        bUnicode = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_IsUsed)) = True Then
                iCount += 1
                'Update 16/10/2009
                If chkConvertUnicode.Checked Then ' Chuyển Unicode
                    If tdbg(i, COL_DataType).ToString.Trim = "S" Then
                        arrDisabledColumn.Add(tdbg(i, COL_FieldName))
                        bUnicode = True
                    End If
                End If
            End If
        Next
        Return iCount
    End Function

    Private Sub AutoSizeColumns(ByVal sheet As XLSheet)
        Dim iRowStart As Integer
        If txtTitle.Text.Trim <> "" Then
            iRowStart = L3Int(txtRow.Text) + 3 - 1
        Else
            iRowStart = L3Int(txtRow.Text) - 1
        End If

        Using g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
            Dim iMaxLenght As Integer
            Dim r As Integer, c As Integer
            For c = 0 To sheet.Columns.Count - 1
                If dicFormula.ContainsKey(c.ToString) Then Continue For 'Bổ sung Auto Size cho cột công thức
                iMaxLenght = 0
                Dim colWidth As Integer = -1
                'For r = 0 To sheet.Rows.Count - 1
                For r = iRowStart To sheet.Rows.Count - 1
                    Dim value As Object = sheet(r, c).Value
                    If L3String(value) <> "" Then
                        If iMaxLenght < L3String(value).Length Then iMaxLenght = L3String(value).Length
                        ' get value (unformatted at this point)
                        ' get font (default or style)
                        Dim font As Font = C1XLBook1.DefaultFont
                        Dim s As XLStyle = sheet(r, c).Style

                        If Not (s Is Nothing) Then
                            If Not (s.Font Is Nothing) Then
                                font = s.Font
                            End If
                        End If

                        'Update 18/06/2015
                        If s.AlignHorz = XLAlignHorzEnum.Right Then 'Neu la So thi lay them chieu dai cua Format
                            Try
                                If s.Format IsNot Nothing AndAlso s.Format <> "" Then value = Format(value, s.Format)
                            Catch ex As Exception

                            End Try

                        End If

                        ' measure string (add a little tolerance)
                        Dim sz As Size
                        If Not IsDBNull(value) Then
                            sz = System.Drawing.Size.Ceiling(g.MeasureString(L3String(value) + "XX", font))
                        End If

                        ' keep widest so far
                        If sz.Width > colWidth Then colWidth = sz.Width

                    End If
                    ' done measuring, set column width
                    If colWidth > -1 Then sheet.Columns(c).Width = C1XLBook.PixelsToTwips(colWidth) + 10 * iMaxLenght 'Công thêm sai số do sử dụng Tiếng Việt
                    sheet.Columns(c).Width += 100 'Cộng thêm 100
                Next

            Next

        End Using
    End Sub

    Private Function GetStringSort() As String
        Dim sSort As String = ""
        'Kiểm tra có check vào Dạng xuất
        If chkIsExportType.Checked Then 'Xuất theo dạng có Group của Excel
            If optPivotTable.Checked = True Then 'Dạng PivotTable
                'For i As Integer = 0 To tdbgRow.RowCount - 1
                '    If sSort = "" Then
                '        sSort = tdbgRow(i, COL4_FieldName).ToString
                '    Else
                '        sSort &= "," & tdbgRow(i, COL4_FieldName).ToString
                '    End If
                'Next
            Else ' dạng Subtotals
                For i As Integer = 0 To tdbgGroup.RowCount - 1
                    If sSort = "" Then
                        sSort = tdbgGroup(i, COL1_GroupFieldName).ToString
                    Else
                        sSort &= "," & tdbgGroup(i, COL1_GroupFieldName).ToString
                    End If
                Next
            End If
        End If
        Return sSort
    End Function

    Private Function GetNameSheets() As Boolean

        Dim workbook As C1XLBook = New C1XLBook()
        Dim i As Integer = 0
        cboDefaultSheet.Items.Clear()
        If txtPathIn.Text.Trim <> "" Then
            'Update 07/07/2015: kiểm tra thêm việc chọn file .xlsx thì không cho xuất
            If txtPathIn.Text.Trim.Contains(".xlsx") Then
                D99C0008.MsgL3("File xuất không hợp lệ. Bạn phải chọn file dạng .xls")
                Return False
            End If

            If My.Computer.FileSystem.FileExists(txtPathIn.Text) = False Then
                If gsLanguage = "84" Then
                    D99C0008.MsgL3("Không tồn tại file Excel:" & Space(1) & txtPathIn.Text & vbCrLf)
                Else
                    D99C0008.MsgL3("Not exist file Excel:" & Space(1) & txtPathIn.Text & vbCrLf)
                End If
                txtPathIn.Text = ""
                txtPathIn.Tag = ""
                txtPathIn_Validated(Nothing, Nothing)
                Return False
            Else
                Try
                    workbook.Load(txtPathIn.Text)
                Catch ex As Exception
                    D99C0008.MsgL3("File xuất không đúng định dạng.")
                    Return False
                End Try

            End If
            'Get names of all sheets in the workbook
            For i = 0 To workbook.Sheets.Count - 1
                cboDefaultSheet.Items.Add(workbook.Sheets(i).Name)
            Next
            cboDefaultSheet.SelectedIndex = 0
        End If
        workbook = Nothing
        GC.Collect()
        Return True
    End Function

    Private Function GetAreaMaxData(ByVal iColUsed As Integer, ByVal iRowUsed As Integer) As String
        Dim sColArea As String
        Dim iCol As Integer
        iCol = GetIntColumnExcel(tdbcColExcel.Text) + iColUsed - 1
        sColArea = GetStringColumnExcel(iCol)

        Dim iRowArea As Integer
        iRowArea = L3Int(txtRow.Text) + iRowUsed
        'Minh Hòa  update 28/08/2010
        ' Thêm 3 dòng nếu có tiêu đề
        If txtTitle.Text.Trim <> "" Then
            iRowArea += 3
        End If

        Return sColArea & iRowArea.ToString
    End Function

#End Region

#Region "Các sự kiện của tab Nâng cao"
    'Minh Hòa 28/08/2010
    Private Sub ProcessOptions(ByRef book As C1XLBook, ByRef sheet As XLSheet)
        If txtTitle.Text.Trim <> "" Then
            Dim cell As XLCell
            Dim iCol As Integer = GetIntColumnExcel(tdbcColExcel.Text)
            Dim iRow As Integer = L3Int(txtRow.Text) - 1
            'Gan tieu de 
            cell = sheet(iRow, iCol)
            cell.Value = IIf(txtTitle.Font.Name = "Lemon3", ConvertVniToUnicode(txtTitle.Text.ToUpper), txtTitle.Text.ToUpper)
            cell.Style = New XLStyle(book)
            cell.Style.Font = New Font("Arial", 12.0!, FontStyle.Bold)
            cell.Style.AlignHorz = XLAlignHorzEnum.Center 'Canh giữa tiêu đề
            cell.Style.ForeColor = Color.Blue

            'Merge Cells
            Dim c1CellRange As XLCellRange
            'Update 09/09/2010
            Dim iColSel As Integer
            iColSel = ReturnTableFilter(dtGrid, "IsUsed = 1", True).Rows.Count

            If chkIsExportType.Checked And optPivotTable.Checked = True Then
                c1CellRange = New XLCellRange(iRow, iRow, iCol, iColSel + iCol)
            Else
                c1CellRange = New XLCellRange(iRow, iRow, iCol, iColSel - 1 + iCol)
            End If
            sheet.MergedCells.Add(c1CellRange)
        End If

        ' Giay ngang/ doc 
        sheet.PrintSettings.Landscape = optLandscape.Checked
        ' Zoom %
        If dudAdjust.Text <> "" Then
            sheet.PrintSettings.ScalingFactor = L3Int(dudAdjust.Text)
        End If

        'Chọn loai kich co giay
        If cboPageSize.Text <> "" Then
            Select Case cboPageSize.Text
                Case "Letter"
                    sheet.PrintSettings.PaperKind = Printing.PaperKind.Letter
                Case "Legal"
                    sheet.PrintSettings.PaperKind = Printing.PaperKind.Legal
                Case "Executive"
                    sheet.PrintSettings.PaperKind = Printing.PaperKind.Executive
                Case "A3"
                    sheet.PrintSettings.PaperKind = Printing.PaperKind.A3
                Case "A4"
                    sheet.PrintSettings.PaperKind = Printing.PaperKind.A4
                Case "A5"
                    sheet.PrintSettings.PaperKind = Printing.PaperKind.A5
                Case Else
                    sheet.PrintSettings.PaperKind = Printing.PaperKind.A4
            End Select
        End If
    End Sub

    Private Sub ProcessOptions(ByRef book As Excel.Workbook, ByRef sheet As Excel.Worksheet, ByVal ColUse As Integer)
        If txtTitle.Text.Trim <> "" Then

            'Merge Cells
            Dim cellTitle As Excel.Range
            Dim iColCount As Integer
            Dim sColEnd As String

            If chkIsExportType.Checked And optPivotTable.Checked = True Then
                iColCount = tdbgColumn.RowCount
                'cellTitle = sheet.Range(tdbcColExcel.Text & "1:C1" & tdbgColumn.RowCount.ToString)
            Else
                iColCount = tdbg.RowCount - 1
                'cellTitle = sheet.Range("A1:C" & (tdbg.RowCount - 1).ToString)
            End If
            sColEnd = GetStringColumnExcel(GetIntColumnExcel(tdbcColExcel.Text) + iColCount + 1)
            'If chkGrandRow.Checked Then
            '    sColEnd = GetStringColumnExcel(GetIntColumnExcel(tdbcColExcel.Text) + ColUse + 1)
            'Else
            '    sColEnd = GetStringColumnExcel(GetIntColumnExcel(tdbcColExcel.Text) + ColUse)
            'End If

            cellTitle = sheet.Range(tdbcColExcel.Text & txtRow.Text & ":" & sColEnd & txtRow.Text)

            With cellTitle
                .MergeCells = True
                .Value = IIf(txtTitle.Font.Name = "Lemon3", ConvertVniToUnicode(txtTitle.Text.ToUpper), txtTitle.Text.ToUpper)
                .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                '.Interior.ColorIndex = 36 ' Set mau nen neu can
                .Font.Color = 16711680 'Blue
                .Font.Bold = True
                .Font.Size = 14
                .Font.Name = "Arial"

            End With
        End If

        ' Giay ngang/ doc 
        If optLandscape.Checked Then
            sheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
        Else
            sheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait
        End If

        ' Zoom %
        If dudAdjust.Text <> "" Then
            sheet.PageSetup.Zoom = L3Int(dudAdjust.Text)
        End If
        'Chọn loai kich co giay
        If cboPageSize.Text <> "" Then
            Select Case cboPageSize.Text
                Case "Letter"
                    sheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLetter
                Case "Legal"
                    sheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal
                Case "Executive"
                    sheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperExecutive
                Case "A3"
                    sheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA3
                Case "A4"
                    sheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
                Case "A5"
                    sheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA5
                Case Else
                    sheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
            End Select
        End If
    End Sub

    Private Sub dudAdjust_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dudAdjust.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub dudAdjust_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dudAdjust.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = True
        Else
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End If
    End Sub

    Private Sub dudAdjust_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dudAdjust.LostFocus
        If dudAdjust.Text <> "" Then
            If dudAdjust.Text.Length > 3 Then
                dudAdjust.Text = "10"
            Else
                If L3Int(dudAdjust.Text) > 400 Or L3Int(dudAdjust.Text) < 10 Then
                    dudAdjust.Text = "10"
                End If
            End If

        End If
    End Sub

    Private Sub chkChecked_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkChecked.Click
        chkChecked.Checked = True
    End Sub

    Private Sub chkUnChecked_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUnChecked.Click
        chkUnChecked.Checked = False
    End Sub


    ' Hàm cũ không dùng nữa.
    'Private Function GetIntColumnExcel(ByVal sColumn As String) As Integer
    '    If sColumn.Length = 1 Then

    '        Return (Asc(sColumn) - Asc("A"))
    '    Else
    '        Return (Asc(sColumn.Substring(0, 1)) - Asc("A") + 1) * 26 + (Asc(sColumn.Substring(1, 1)) - Asc("A"))
    '    End If

    'End Function

    'Private Function GetStringColumnExcel(ByVal sColumn As Integer) As String
    '    If sColumn <= 25 Then
    '        Return Chr(sColumn + Asc("A"))
    '    Else
    '        Return (Chr(sColumn \ 26 + Asc("A") - 1) + Chr(sColumn Mod 26 + Asc("A"))).ToString
    '    End If
    'End Function
#End Region


#Region "Const of tdbgPara - Total of Columns: 4"
    Private Const COLM_Description As String = "Description" ' Nội dung
    Private Const COLM_FieldExcel As String = "FieldExcel"   ' Tham số
    Private Const COLM_Value As String = "Value"             ' Value
#End Region

#Region "Danh sách tham số"

    Private Function ExportMaster(ByVal filePath As String) As String
        Dim book As Excel.Workbook
        If chkIsNoFormula.Checked Then
            GetFormula(dicFormula, book) 'Bổ sung lấy công thức của sheet excel 25/02/2016
        Else
            dicFormula = New Dictionary(Of String, String) 'Set lại =0
        End If
        If txtPathIn.Text <> "" Then
            filePath = txtPathIn.Text
        Else
            If txtPathOut.Text.Trim = "" Then
                ' Return filePath
                GoTo close
            End If
        End If

        If txtPathOut.Text <> "" Then
            Dim fileName As String = filePath.Substring(filePath.LastIndexOf("\"c) + 1, filePath.Length - filePath.LastIndexOf("\"c) - 1)
            filePath = txtPathOut.Text.Trim() & "\" & fileName
            filePath = filePath.Replace("\\", "\")
        End If
        Dim name As String = Strings.Left(filePath, filePath.LastIndexOf("."c)) 'lấy tên file
        filePath = filePath.Replace(name, name & "_") 'namefile_yyMMdd
        If tdbgM.RowCount = 0 Then
            Try
ReloadFile:
                If txtPathIn.Text.Trim <> "" Then
                    If chkIsNoFormula.Checked Then
                        book.SaveAs(filePath)
                        CloseExcelApp(EXL, book)
                    Else
                        IO.File.Copy(txtPathIn.Text, filePath, True) 'Sao chép mẫu ra để thêm dữ liệu
                    End If

                End If

            Catch ex As Exception
                If CloseProcessWindow(filePath) Then GoTo ReloadFile
                Return ""
            End Try
            Return filePath
        End If
        If txtPathIn.Text.Trim <> "" Then

            If book Is Nothing Then
                EXL = New Excel.Application
                EXL.Application.Interactive = True
                EXL.Application.UserControl = True
                EXL.Application.DisplayAlerts = False
                book = EXL.Workbooks.Open(txtPathIn.Text.Trim) 'fileName) 
            End If
            '    Dim book As Excel.Workbook
            Try
                'EXL.Application.Interactive = True
                'EXL.Application.UserControl = True
                'EXL.Application.DisplayAlerts = False
                'book = EXL.Workbooks.Open(txtPathIn.Text.Trim) 'fileName) mở file mẫu đang chọn
                For i As Integer = 0 To tdbgM.RowCount - 1
                    Dim range As Excel.Range = EXL.Cells.Find(What:=L3String(tdbgM(i, COLM_FieldExcel)), MatchCase:=False)
                    If range Is Nothing Then Continue For
                    If range.Value2 Is Nothing Then Continue For
                    Dim sValue As String = range.Value2
                    If sValue = L3String(tdbgM(i, COLM_FieldExcel)) Then
                        range.Value2 = tdbgM(i, COLM_Value) ' TH gắn overwrite cell thì giữ lại định dạng
                    Else
                        range.Value2 = sValue.Replace(L3String(tdbgM(i, COLM_FieldExcel)), L3String(tdbgM(i, COLM_Value)))
                    End If
                    i -= 1 ' Quét lại lần nữa TH khách hàng thiết lập nhiều lần
                Next
                book.SaveAs(filePath)
            Catch ex As Exception
                D99C0008.MsgL3(ex.Message)
            End Try
close:
            EXL = Nothing
            CloseExcelApp(EXL, book)

        End If
        Return filePath
    End Function

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbgM_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgM.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbgM, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbgM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgM.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbgM, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbgM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgM.KeyPress
        If tdbgM.Columns(tdbgM.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbgM.Splits(tdbgM.SplitIndex).DisplayColumns(tdbgM.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = ""
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        FooterTotalGrid(tdbgM, COLM_Description)
    End Sub
#End Region

    Private Sub txtPathIn_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPathIn.TextChanged
        chkIsNoFormula.Visible = txtPathIn.Text <> ""
    End Sub

    Private Sub txtPathIn_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPathIn.Validated
        'If btnChoosePathIn.Focused Then Exit Sub
        'If Not CheckPathIn() Then Exit Sub
        cboDefaultSheet.Enabled = Not (txtPathIn.Text.Trim = "")
        If txtPathIn.Text.Trim = "" Then
            cboDefaultSheet.Enabled = False
            cboDefaultSheet.Text = ""
            cboDefaultSheet.Items.Clear()
            chkIsMarkTimer.Checked = False
            chkIsMarkTimer.Enabled = False
            lblSampleFileName.Text = ""

        Else
            cboDefaultSheet.Enabled = True
            If My.Computer.FileSystem.FileExists(txtPathIn.Text) = True Then
                If L3String(txtPathIn.Tag) <> txtPathIn.Text Then GetNameSheets()
            Else
                cboDefaultSheet.Items.Clear()
                cboDefaultSheet.Text = ""
            End If
            chkIsMarkTimer.Enabled = True
        End If
        chkFileTimer_Click(Nothing, Nothing)
        txtPathIn.Tag = txtPathIn.Text
    End Sub

    Private Sub txtPathOut_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPathOut.Validated
        'If btnChoosePathOut.Focused Then Exit Sub
        'If Not CheckPathOut() Then Exit Sub
        chkFileTimer_Click(Nothing, Nothing)
    End Sub
    'Private Sub btnChoosePathIn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChoosePathIn.LostFocus
    '    txtPathIn_Validated(Nothing, Nothing)
    'End Sub

    'Private Sub btnChoosePathOut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChoosePathOut.LostFocus
    '    txtPathOut_Validated(Nothing, Nothing)
    'End Sub

    Private Sub chkFileTimer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsMarkTimer.Click
        Try
            Dim filePath = DEFAULT_PATH_OUT & "\Data.xls"
            If txtPathIn.Text <> "" Then
                filePath = txtPathIn.Text
            End If
            If txtPathOut.Text <> "" Then
                Dim fileName As String = filePath.Substring(filePath.LastIndexOf("\"c) + 1, filePath.Length - filePath.LastIndexOf("\"c) - 1)
                filePath = txtPathOut.Text.Trim() & "\" & fileName
                filePath = filePath.Replace("\\", "\")
            End If
            Dim name As String = Strings.Left(filePath, filePath.LastIndexOf("."c)) 'lấy tên file
            If chkIsMarkTimer.Checked Then filePath = filePath.Replace(name, name & "_" & Format(Now, "yyMMdd")) 'namefile_yyMMdd
            lblSampleFileName.Text = filePath
        Catch ex As Exception
            lblSampleFileName.Text = ""
        End Try
    End Sub

    Private Sub btnPreviewFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tdbgFormula.Visible = Not tdbgFormula.Visible
    End Sub

    'Xuất nhiều thì qua sheet mới
    'copy fomular
    'Lúc nào cũng kiểm tra công thức hay bổ sung check thiết lập
    Dim dicFormula As New Dictionary(Of String, String) 'Get cột excel và công thức
    Private Sub GetFormula(ByRef dicFormula As Dictionary(Of String, String), ByRef book As Excel.Workbook)
        If txtPathIn.Text = "" Then Exit Sub 'Chỉ xét công thức khi chọn mẫu
        If EXL Is Nothing Then EXL = New Excel.Application
        Dim sheet As Excel.Worksheet
        Try
            EXL.Application.Interactive = True
            EXL.Application.UserControl = True
            EXL.Application.DisplayAlerts = False
            book = EXL.Workbooks.Open(txtPathIn.Text.Trim) 'fileName) mở file mẫu đang chọn
            sheet = book.Worksheets(cboDefaultSheet.SelectedIndex + 1)
            Dim rowBegin As Integer = L3Int(txtRow.Text)
            For c As Integer = 1 To sheet.Columns.Count 'Vì excel bắt đầu từ 1
                Dim range As Excel.Range = sheet.Cells(rowBegin, c)
                If range.HasFormula Then
                    Dim key As String = c - 1
                    If dicFormula.ContainsKey(key) Then
                        dicFormula.Item(key) = range.Formula '-1 vì bắt đầu từ 1
                    Else
                        dicFormula.Add(key, range.Formula)
                    End If
                End If
            Next
            'Chèn dòng dùng core excel khi check vào Công thức và có chọn mẫu
            Dim iTotalRow As Integer = _dtExportTable.DefaultView.ToTable.Rows.Count
            If dicFormula.Count > 0 AndAlso chkDisplayTitle.Checked = False Then iTotalRow -= 1 'bỏ dòng insert có công thức, dữ liệu 7 dòng thì insert thêm 6 dòng nếu không có hiển thị Tiêu đề
            Dim iRow As Integer = L3Int(txtRow.Text)
            If txtTitle.Text.Trim <> "" Then
                InsertRowForWorksheet(sheet, 3, iRow, False)
                iRow += 3
            End If
            'Dùng cho trường hợp giữ lại phần Footer của file có sẵn
            '  If chkDisplayTitle.Checked Then iTotalRow += 1
            'If chkShowSum.Checked Then'Dòng tổng không copy
            '    Dim dr() As DataRow = dtGrid.Select("IsSum=1 And " & "IsUsed=1")
            '    If dr.Length > 0 Then iTotalRow += 1
            'End If
            InsertRowForWorksheet(sheet, iTotalRow, iRow)
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
            EXL = Nothing
            CloseExcelApp(EXL, book)
        Finally

        End Try
    End Sub

    Private Sub InsertRowForWorksheet(ByRef worksheet As Excel.Worksheet, ByVal iRowCount As Integer, ByVal iRow As Integer, Optional ByVal bCopyRow As Boolean = True)
        'Lê Anh Vũ : Khi nâng cấp lên VS 2013 thay thế bằng đoạn code sau: 
        'worksheet.Rows(iRow).ReSize(iRowCount - 1).Insert(Excel.XlInsertShiftDirection.xlShiftDown, worksheet.Rows(iRow).Copy())
        'Exit Sub
        Dim book As Excel.Workbook
        ' Dim sheet As Excel.Worksheet
        If worksheet Is Nothing Then
            EXL = New Excel.Application
            EXL.Application.Interactive = True
            EXL.Application.UserControl = True
            EXL.Application.DisplayAlerts = False
            book = EXL.Workbooks.Open(txtPathIn.Text.Trim) 'fileName) 
            worksheet = book.Worksheets(cboDefaultSheet.SelectedIndex + 1) 'Chưa làm trường hợp nhiều quá copy sheet mới
        End If

        Dim excelRang As Excel.Range
        Dim sCol As String
        sCol = ColumnIndexToColumnLetter(worksheet.Columns.Count)
        'excelRang.Value2 = ""
        Dim iCountRowAdd As Integer = 0
        Dim iAdd As Integer = 0
        Dim index As Integer

        For k As Integer = 0 To iRowCount - 1
            If bCopyRow Then
                index = k
                'Office không cho Insert 1 lúc trên 2^14 dòng
                If k > 14 Then index = 14
                iAdd = Math.Pow(2, index)
                If iCountRowAdd + iAdd >= iRowCount Then
                    iAdd = iRowCount - iCountRowAdd
                    If iAdd < 1 Then Exit For
                    excelRang = worksheet.Range("A" & iRow & ":" & sCol & iRow + iAdd - 1)
                    worksheet.Rows(iRow).Insert(Excel.XlInsertShiftDirection.xlShiftDown, excelRang.Copy())
                    Exit For
                Else
                    iCountRowAdd += iAdd
                    excelRang = worksheet.Range("A" & iRow & ":" & sCol & iRow + iAdd - 1)
                    worksheet.Rows(iRow).Insert(Excel.XlInsertShiftDirection.xlShiftDown, excelRang.Copy())
                End If
            Else
                excelRang = worksheet.Range("A" & worksheet.Rows.Count - 1 & ":" & sCol & worksheet.Rows.Count - 1)
                worksheet.Rows(iRow).Insert(Excel.XlInsertShiftDirection.xlShiftDown, excelRang.Copy())
            End If
        Next
    End Sub


    Public Function ColumnIndexToColumnLetter(ByVal colIndex As Integer) As String
        Dim div As Integer = colIndex
        Dim colLetter As String = ""
        Dim modnum As Integer = 0

        While div > 0
            modnum = (div - 1) Mod 26
            colLetter = Chr(65 + modnum) + colLetter
            div = CInt((div - modnum) \ 26)
        End While
        Return colLetter
    End Function
End Class

