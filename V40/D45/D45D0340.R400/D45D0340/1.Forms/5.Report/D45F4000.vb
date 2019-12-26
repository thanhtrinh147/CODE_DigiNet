Imports System.Drawing
Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 28/05/2007 8:39:02 AM
'# Created User: Nguyễn Lê Phương
'# Modify Date: 28/05/2007 8:39:02 AM
'# Modify User: Nguyễn Lê Phương
'#-------------------------------------------------------------------------------------
Public Class D45F4000
	Dim report As D99C2003

    Private dtTeamID, dtEmployeeID, dtRefEmployeeID As DataTable
    Private dtDepartmentID, dtStageID, dtProVoucherNo As DataTable

    Private _fromDate As String = ""
    Public WriteOnly Property  FromDate() As String
        Set(ByVal Value As String)
            _fromDate = Value
        End Set
    End Property

    Private _toDate As String = ""
    Public WriteOnly Property  ToDate() As String
        Set(ByVal Value As String)
            _toDate = Value
        End Set
    End Property

    Private _departmentID As String = ""
    Public WriteOnly Property  DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value
        End Set
    End Property

    Private _teamID As String = ""
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value
        End Set
    End Property

    Private _employeeID As String = ""
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Private _productVoucherNo As String = ""
    Public WriteOnly Property ProductVoucherNo() As String
        Set(ByVal Value As String)
            _productVoucherNo = Value
        End Set
    End Property

    Private Sub D45F4000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D45F4000_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Loadlanguage()
        LoadTDBCombo()
        c1dateExamineDate.Value = Now.Date
        LoadDefaultValue()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory()
        tdbcNameAutoComplete()
        InputDateCustomFormat(c1dateDateTo, c1dateExamineDate, c1dateDateFrom)

        SetResolutionForm(Me)
    End Sub

    Private Sub LoadDefaultValue()
        tdbcDivisionID.SelectedValue = gsDivisionID.ToString
        c1dateDateFrom.Value = IIf(_fromDate <> "", _fromDate, Date.Now)
        c1dateDateTo.Value = IIf(_toDate <> "", _toDate, Date.Now)

        tdbcRefEmployeeID.SelectedValue = "%"
        tdbcProductID.SelectedValue = "%"
        tdbcStageID.SelectedValue = "%"
        tdbcReportID.SelectedIndex = 0

        If _departmentID = "" Then
            tdbcDepartmentID.SelectedValue = "%"
        Else
            tdbcDepartmentID.SelectedValue = _departmentID
        End If
        If _teamID = "" Then
            tdbcTeamID.SelectedValue = "%"
        Else
            tdbcTeamID.SelectedValue = _teamID

        End If
        tdbcEmployeeID.SelectedValue = _employeeID
        tdbcProVoucherNoFrom.SelectedValue = _productVoucherNo
        tdbcProVoucherNoTo.SelectedValue = _productVoucherNo
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Bao_cao_thong_ke_san_pham_tinh_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'BÀo cÀo thçng k£ s¶n phÈm tÛnh l§¥ng
        'Me.Text = rl3("Bao_cao_cham_cong_san_pham_-_D45F4000") & UnicodeCaption(gbUnicode) 'BÀo cÀo chÊm c¤ng s¶n phÈm - D45F4000
        '================================================================ 
        lblReportID.Text = rl3("Mau_chuan") 'Mẫu chuẩn
        lblteExamineDate.Text = rl3("Ngay_lap") 'Ngày lập
        lblProVoucherNoTo.Text = rl3("Den_phieu") 'Đến phiếu
        lblRefEmployeeID.Text = rl3("Ma_NV_phu") 'Mã NV phụ
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblEmployeeID.Text = rl3("Ma_NV_chinh") 'Mã NV chính
        lblteDateFrom.Text = rl3("Tu_ngay") 'Từ ngày
        lblteDateTo.Text = rl3("Den_ngay") 'Đến ngày
        lblProVoucherNoFrom.Text = rl3("Tu_phieu") 'Từ phiếu
        lblProductID.Text = rl3("San_pham") 'Sản phẩm
        lblStageID.Text = rl3("Cong_doan") 'Công đoạn
        lblPriceListID.Text = rl3("Bang_gia") 'Bảng giá
        lblGroupDivision.Text = "1." & Space(1) & rl3("Don_vi") 'Đơn vị
        lblGroupReport.Text = "2." & Space(1) & rl3("Mau_bao_cao") 'Mẫu báo cáo
        lblGroupFilter.Text = "3." & Space(1) & rl3("Tieu_thuc_loc") 'Tiêu thức lọc
        lblGroupTime.Text = "4." & Space(1) & rl3("Thoi_gian") 'Thời gian
        'lblGroupProduct.Text = "5." & Space(1) & rL3("Phieu_cham_cong_san_pham") 'Phiếu chấm công sản phẩm
        '================================================================ 
        lblGroupProduct.Text = "5." & Space(1) & rL3("Phieu_thong_ke_san_pham_tinh_luong") 'Phiếu thống kê sản phẩm tính lương

        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnPrint.Text = rl3("_In") '&In
        '================================================================ 
        tdbcReportID.Columns("ReportID").Caption = rl3("Mau_bao_cao") 'Mẫu báo cáo
        tdbcReportID.Columns("ReportName").Caption = rl3("Ten_bao_cao") 'Tên báo cáo
        tdbcPriceListID.Columns("PriceListID").Caption = rl3("Ma") 'Mã 
        tdbcPriceListID.Columns("PriceListName").Caption = rl3("Ten") 'Tên
        tdbcStageID.Columns("StageID").Caption = rl3("Ma") 'Mã 
        tdbcStageID.Columns("StageName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcProductID.Columns("ProductID").Caption = rl3("Ma") 'Mã 
        tdbcProductID.Columns("ProductName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcProVoucherNoTo.Columns("ProductVoucherNo").Caption = rl3("Ma") 'Mã
        tdbcProVoucherNoTo.Columns("Note").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcProVoucherNoFrom.Columns("ProductVoucherNo").Caption = rl3("Ma") 'Mã
        tdbcProVoucherNoFrom.Columns("Note").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcRefEmployeeID.Columns("RefEmployeeID").Caption = rl3("Ma") 'Mã 
        tdbcRefEmployeeID.Columns("FullName").Caption = rl3("Ten") 'Tên 
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã 
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên 
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã 
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã 
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã 
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)


        CreateTableRefEmployeeID()

        dtDepartmentID = ReturnTableDepartmentID(, , gbUnicode)
        dtTeamID = ReturnTableTeamID(, , gbUnicode)
        dtEmployeeID = ReturnTableEmployeeID(, , gbUnicode)

        'Load tdbcDivisionID
        LoadCboDivisionIDReport(tdbcDivisionID, "D09", True, gbUnicode)

        'Load tdbcReportID
        sSQL = "Select ReportID, ReportName" & sUnicode & " as ReportName From D91T0100  WITH(NOLOCK) where ModuleID='45' And Reporttype='40' order by ReportID "
        LoadDataSource(tdbcReportID, sSQL, gbUnicode)

        'Load tdbcProductID
        sSQL = " Select 0 AS DisplayOrder,'%' as ProductID, " & sLanguage & " as ProductName " & vbCrLf
        sSQL &= "Union All " & vbCrLf
        sSQL &= "Select 1 AS DisplayOrder,ProductID, ShortName" & sUnicode & " as ProductName From D45T1000 D00  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 Order by DisplayOrder,ProductID"
        LoadDataSource(tdbcProductID, sSQL, gbUnicode)

        'Load tdbcPriceListID
        sSQL = "Select PriceListID,PriceListName" & sUnicode & " as PriceListName From D45T1020  WITH(NOLOCK) Order by PriceListID"
        LoadDataSource(tdbcPriceListID, sSQL, gbUnicode)
    End Sub

    Private Sub CreateTableRefEmployeeID()
        Dim sSQL As String = ""
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)

        'Load tdbcRefEmployeeID
        sSQL = "Select '%' As RefEmployeeID, " & sLanguage & " As FullName,'%' as DepartmentID,'%' as TeamID,'%' as DivisionID, 0 as DisplayOrder " & vbCrLf
        sSQL &= "Union All "
        sSQL &= "Select RefEmployeeID , IsNull(LastName" & sUnicode & " ,'')+ ' ' + IsNull(MiddleName" & sUnicode & " ,'')+ ' ' + IsNull(FirstName" & sUnicode & " ,'') as FullName, " & vbCrLf
        sSQL &= "DepartmentID,TeamID,DivisionID,1 as DisplayOrder" & vbCrLf
        sSQL &= "From D09T0201  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Order by DisplayOrder, RefEmployeeID"
        dtRefEmployeeID = ReturnDataTable(sSQL)
        LoadDataSource(tdbcRefEmployeeID, dtRefEmployeeID, gbUnicode)
    End Sub

    Private Sub CreateTableStageID()
        Dim sSQL As String = ""
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)

        'Load tdbcStageID
        sSQL = " Select 0 AS DisplayOrder,'%' as StageID," & sLanguage & " as StageName,'%' as ProductID  " & vbCrLf
        sSQL &= "Union All " & vbCrLf
        sSQL &= "Select 1 AS DisplayOrder,D01.StageID,D10.StageName " & sUnicode & " as StageName,D01.ProductID" & vbCrLf
        sSQL &= "From D45T1001 D01  WITH(NOLOCK) Inner Join D45T1010 D10  WITH(NOLOCK) On D01.StageID=D10.StageID" & vbCrLf
        sSQL &= "Where D10.Disabled=0 "
        sSQL &= "Order by DisplayOrder,ProductID,StageID"
        dtStageID = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadtdbcProVoucherNo()
        Dim sSQL As String = ""
        Dim sDivisionID As String
        If tdbcDivisionID.SelectedValue Is Nothing Then
            sDivisionID = ""
        Else
            sDivisionID = tdbcDivisionID.SelectedValue.ToString
        End If
        sSQL &= "Select ProductVoucherID, ProductVoucherNo , DivisionID, VoucherDate, Note" & UnicodeJoin(gbUnicode) & " as Note" & vbCrLf
        sSQL &= " From D45T2000  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where DivisionID=" & SQLString(sDivisionID) & " And (VoucherDate Between " & SQLDateSave(c1dateDateFrom.Value) & " And " & SQLDateSave(c1dateDateTo.Value) & ")" & vbCrLf
        sSQL &= "Order by ProductVoucherNo"
        dtProVoucherNo = ReturnDataTable(sSQL)
        LoadDataSource(tdbcProVoucherNoFrom, ReturnTableFilter(dtProVoucherNo, ""), gbUnicode)
        LoadDataSource(tdbcProVoucherNoTo, ReturnTableFilter(dtProVoucherNo, ""), gbUnicode)
   End Sub

    Private Sub LoadtdbcStageID()
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        'Load tdbcStageID
        Dim sSQL As String = ""
        sSQL = " Select 0 AS DisplayOrder,'%' as StageID," & sLanguage & " as StageName,'%' as ProductID  " & vbCrLf
        sSQL &= "Union All " & vbCrLf
        sSQL &= "Select 1 AS DisplayOrder,D01.StageID,D10.StageName" & sUnicode & " as StageName,D01.ProductID" & vbCrLf
        sSQL &= "From D45T1001 D01  WITH(NOLOCK) Inner Join D45T1010 D10  WITH(NOLOCK) On D01.StageID=D10.StageID" & vbCrLf
        sSQL &= "Where D10.Disabled=0 And ProductID=" & SQLString(tdbcProductID.Text) & vbCrLf
        sSQL &= "Order by DisplayOrder, StageID"
        LoadDataSource(tdbcStageID, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcDivisionID"

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        LoadtdbcDepartmentID()
        LoadtdbcProVoucherNo()
        If tdbcDivisionID.SelectedValue Is Nothing Then
            tdbcDepartmentID.Text = ""
            tdbcTeamID.Text = ""
            tdbcEmployeeID.Text = ""
            txtEmployeeName.Text = ""
            tdbcRefEmployeeID.Text = ""
            txtRefEmployeeName.Text = ""
        End If

        tdbcDepartmentID.SelectedIndex = 0
    End Sub

#End Region

#Region "Events tdbcDepartmentID"

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        LoadtdbcTeamID()
        If tdbcDepartmentID.SelectedValue Is Nothing Then
            tdbcTeamID.Text = ""
            tdbcEmployeeID.Text = ""
            txtEmployeeName.Text = ""
            tdbcRefEmployeeID.Text = ""
            txtRefEmployeeName.Text = ""
        End If
        tdbcTeamID.SelectedIndex = 0
    End Sub

#End Region

#Region "Events tdbcTeamID"

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        LoadtdbcEmployeeID()
        LoadtdbcRefEmployeeID()
        If tdbcTeamID.SelectedValue Is Nothing Then
            tdbcEmployeeID.Text = ""
            txtEmployeeName.Text = ""
            tdbcRefEmployeeID.Text = ""
            txtRefEmployeeName.Text = ""
        End If

        tdbcEmployeeID.SelectedIndex = 0
        tdbcRefEmployeeID.SelectedIndex = 0
    End Sub

#End Region

#Region "53.	Sửa lỗi gõ tên trên combo hay dropdown"

    Private Sub tdbcNameAutoComplete()
        tdbcDivisionID.AutoCompletion = False
        tdbcReportID.AutoCompletion = False
        tdbcDepartmentID.AutoCompletion = False
        tdbcTeamID.AutoCompletion = False
    End Sub

    Private Sub tdbcName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus, _
                tdbcReportID.LostFocus, tdbcDepartmentID.LostFocus, tdbcTeamID.LostFocus
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        If tdbcName.ReadOnly OrElse tdbcName.Enabled = False Then Exit Sub
        If tdbcName.FindStringExact(tdbcName.Text) = -1 Then
            tdbcName.SelectedValue = ""
        End If
    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Close, _
                tdbcReportID.Close, tdbcDepartmentID.Close, tdbcTeamID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.Validated, _
                tdbcReportID.Validated, tdbcDepartmentID.Validated, tdbcTeamID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

#Region "Events tdbcEmployeeID with txtEmployeeName"

    Private Sub tdbcEmployeeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.SelectedValueChanged
        If tdbcEmployeeID.SelectedValue Is Nothing Then
            txtEmployeeName.Text = ""
        Else
            txtEmployeeName.Text = tdbcEmployeeID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then
            tdbcEmployeeID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcRefEmployeeID with txtRefEmployeeName"

    Private Sub tdbcRefEmployeeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRefEmployeeID.SelectedValueChanged
        If tdbcRefEmployeeID.SelectedValue Is Nothing Then
            txtRefEmployeeName.Text = ""
        Else
            txtRefEmployeeName.Text = tdbcRefEmployeeID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcRefEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRefEmployeeID.LostFocus
        If tdbcRefEmployeeID.FindStringExact(tdbcRefEmployeeID.Text) = -1 Then
            tdbcRefEmployeeID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcProVoucherNoFrom"

    Private Sub tdbcProVoucherNoFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProVoucherNoFrom.LostFocus
        If tdbcProVoucherNoFrom.FindStringExact(tdbcProVoucherNoFrom.Text) = -1 Then tdbcProVoucherNoFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcProVoucherNoTo"

    Private Sub tdbcProVoucherNoTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProVoucherNoTo.LostFocus
        If tdbcProVoucherNoTo.FindStringExact(tdbcProVoucherNoTo.Text) = -1 Then tdbcProVoucherNoTo.Text = ""
    End Sub
#End Region

#Region "Events tdbcProductID with txtProductName"

    Private Sub tdbcProductID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.LostFocus
        If tdbcProductID.FindStringExact(tdbcProductID.Text) = -1 Then
            tdbcProductID.Text = ""
            txtProductName.Text = ""
            tdbcStageID.Text = ""
            txtStageName.Text = ""
        End If
    End Sub

    Private Sub tdbcProductID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.SelectedValueChanged
        If tdbcProductID.SelectedValue Is Nothing Then
            txtProductName.Text = ""
        Else
            txtProductName.Text = tdbcProductID.Columns(1).Value.ToString
        End If

        If tdbcProductID.Text <> "" Then
            LoadtdbcStageID()
        End If

        tdbcStageID.SelectedIndex = 0
    End Sub
#End Region

#Region "Events tdbcStageID with txtStageName"

    Private Sub tdbcStageID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStageID.LostFocus
        If tdbcStageID.FindStringExact(tdbcStageID.Text) = -1 Then
            tdbcStageID.Text = ""
            txtStageName.Text = ""
        End If
    End Sub

    Private Sub tdbcStageID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStageID.SelectedValueChanged
        If tdbcStageID.SelectedValue Is Nothing Then
            txtStageName.Text = ""
        Else
            txtStageName.Text = tdbcStageID.Columns(1).Value.ToString
        End If

    End Sub
#End Region

#Region "Events tdbcPriceListID with txtPriceListName"

    Private Sub tdbcPriceListID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPriceListID.LostFocus
        If tdbcPriceListID.FindStringExact(tdbcPriceListID.Text) = -1 Then
            tdbcPriceListID.Text = ""
            txtPriceListName.Text = ""
        End If
    End Sub

    Private Sub tdbcPriceListID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPriceListID.SelectedValueChanged
        If tdbcPriceListID.SelectedValue Is Nothing Then
            txtPriceListName.Text = ""
        Else
            txtPriceListName.Text = tdbcPriceListID.Columns(1).Value.ToString
        End If
    End Sub
#End Region

    Private Sub LoadtdbcDepartmentID()
        If CbVal(tdbcDivisionID) = "%" Then
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, ""), gbUnicode)
        Else
            LoadDataSource(tdbcDepartmentID, ReturnTableFilter(dtDepartmentID, "DivisionID=" & SQLString(CbVal(tdbcDivisionID)) & "or DepartmentID='%'"), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbcTeamID()
        If CbVal(tdbcDepartmentID) = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, ""), gbUnicode)
        Else
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID=" & SQLString(CbVal(tdbcDepartmentID)) & "or TeamID='%'"), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbcEmployeeID()
        Dim sDepartmentID As String = CbVal(tdbcDepartmentID)
        Dim sTeamID As String = CbVal(tdbcTeamID)
       
        If sDepartmentID = "%" And sTeamID = "%" Then
            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, ""), gbUnicode)
        ElseIf sDepartmentID = "%" And sTeamID <> "%" Then
            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "TeamID=" & SQLString(sTeamID) & " or EmployeeID='%'"), gbUnicode)
        ElseIf sDepartmentID <> "%" And sTeamID = "%" Then
            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " or EmployeeID='%'"), gbUnicode)
        Else
            LoadDataSource(tdbcEmployeeID, ReturnTableFilter(dtEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " or EmployeeID='%'"), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbcRefEmployeeID()
        Dim sDepartmentID As String = CbVal(tdbcDepartmentID)
        Dim sTeamID As String = CbVal(tdbcTeamID)
        
        If sDepartmentID = "%" And sTeamID = "%" Then
            LoadDataSource(tdbcRefEmployeeID, ReturnTableFilter(dtRefEmployeeID, ""), gbUnicode)
        ElseIf sDepartmentID = "%" And sTeamID <> "%" Then
            LoadDataSource(tdbcRefEmployeeID, ReturnTableFilter(dtRefEmployeeID, "TeamID=" & SQLString(sTeamID) & " or RefEmployeeID='%'"), gbUnicode)
        ElseIf sDepartmentID <> "%" And sTeamID = "%" Then
            LoadDataSource(tdbcRefEmployeeID, ReturnTableFilter(dtRefEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " or RefEmployeeID='%'"), gbUnicode)
        Else
            LoadDataSource(tdbcRefEmployeeID, ReturnTableFilter(dtRefEmployeeID, "DepartmentID=" & SQLString(sDepartmentID) & " And TeamID=" & SQLString(sTeamID) & " or RefEmployeeID='%'"), gbUnicode)
        End If
    End Sub

    Private Sub c1dateDateFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles c1dateDateFrom.Validating
        LoadtdbcProVoucherNo()
    End Sub

    Private Sub c1dateDateTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles c1dateDateTo.Validating
        LoadtdbcProVoucherNo()
    End Sub

    Private Function AllowPrint() As Boolean
        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ma_don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcDepartmentID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phong_ban"))
            tdbcDepartmentID.Focus()
            Return False
        End If
        If tdbcTeamID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("To_nhom"))
            tdbcTeamID.Focus()
            Return False
        End If
        If tdbcEmployeeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ma_NV_chinh"))
            tdbcEmployeeID.Focus()
            Return False
        End If
        If tdbcRefEmployeeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ma_NV_phu"))
            tdbcRefEmployeeID.Focus()
            Return False
        End If
        If c1dateDateFrom.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(lblteDateFrom.Text)
            c1dateDateFrom.Focus()
            Return False
        End If
        If c1dateDateTo.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(lblteDateTo.Text)
            c1dateDateTo.Focus()
            Return False
        End If
        If tdbcProVoucherNoFrom.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Tu_phieu"))
            tdbcProVoucherNoFrom.Focus()
            Return False
        End If
        If tdbcProVoucherNoTo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Den_phieu"))
            tdbcProVoucherNoTo.Focus()
            Return False
        End If
        If tdbcProductID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("San_pham"))
            tdbcProductID.Focus()
            Return False
        End If
        If tdbcStageID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Cong_doan"))
            tdbcStageID.Focus()
            Return False
        End If
        If tdbcReportID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Mau_bao_cao")) 'Mẫu báo cáo
            tdbcReportID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        'txtReportName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcProVoucherNoTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcProVoucherNoFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDepartmentID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTeamID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRefEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcProductID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcStageID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        If Not AllowPrint() Then Exit Sub
        'Dim report As New D99C1003

        '************************************
        Dim SQLSub As String = "SELECT * FROM D09V0009"
        Dim SubReportName As String = "D09R6000"
        UnicodeSubReport(SubReportName, SQLSub, tdbcDivisionID.SelectedValue.ToString, gbUnicode)
        Me.Cursor = Cursors.WaitCursor
        Dim conn As New SqlConnection(gsConnectionString)
        With report
            .OpenConnection(conn)
            .AddSub(SQLSub, SubReportName & ".rpt")
            Dim sSQL As String = SQLStoreD45P4000()
            .AddMain(sSQL)
            Dim sPathReport As String = ""
            'sPathReport = Application.StartupPath & "\XReports\" & tdbcReportID.SelectedValue.ToString & ".rpt"
            sPathReport = UnicodeGetReportPath(gbUnicode, 0, "") & tdbcReportID.SelectedValue.ToString & ".rpt"
            .PrintReport(sPathReport, rL3("Bao_cao_cham_cong_nhat") & " - " & tdbcReportID.SelectedValue.ToString & ".rpt")
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Function SQLStoreD45P4000() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P4000 "
        sSQL &= SQLDateSave(c1dateExamineDate.Value) & COMMA 'ExamineDate, datetime, NOT NULL
        sSQL &= "N" & SQLString(tdbcReportID.Text) & COMMA 'Tilte, varchar[250], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcDepartmentID)) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(CbVal(tdbcTeamID)) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcEmployeeID.SelectedValue) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcRefEmployeeID.SelectedValue) & COMMA 'RefEmployeeID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateDateFrom.Value) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateTo.Value) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(tdbcProVoucherNoFrom.Text) & COMMA 'ProVoucherNoFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcProVoucherNoTo.Text) & COMMA 'ProVoucherNoTo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcProductID.Text) & COMMA 'ProductID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcStageID.Text) & COMMA  'StageID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcPriceListID.Text) & COMMA 'PriceListID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class