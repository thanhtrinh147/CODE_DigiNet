Imports System
Imports System.Collections
Imports C1.C1Excel
Imports System.IO
Imports System.Threading
Public Class D45F2003
	Dim dtCaptionCols As DataTable

    'Chú ý: Cột ProductName, StageName và EmployeeName -> Stype -> Font : Lemon3. Các cột khác Font: Ms Sanserif
    Dim dtProductID As DataTable 'Để lọc khi tìm kiếm mở rộng
    Dim dtStage As DataTable 'Giữ lại để kiểm tra Sản phẩm khác có công đoạn này không?
    Dim dt_EmployeeID, dt_RefEmployeeID, dtFirstName As DataTable

    Dim iColQuantityLast As Integer = COL_RefEmployeeID 'Lấy cột số lượng cuối cùng
    Dim bFlagNewRow As Boolean = False

    Dim bChangeData As Boolean = False 'Khi thay đổi lưới thì báo lưu khi đóng
    Dim bClosed As Boolean = True 'Cờ khi đóng form có lưu dữ liệu không?
    Dim bSaveOK As Boolean
    Dim arrayIndex(COL_Total) As Integer 'mang luu giu gtri index sau khi doi cot
    Dim bColMove As Boolean 'ktra xem co doi cot k?
    Dim iColCheck As Integer = 0 'ktra xem co copy ca 2 cot EmployeeID va RefEmployeeID k?
    Dim bCopyRef As Boolean = False 'True co copy cot RefEmployeeID

    Dim conn As New SqlConnection(gsConnectionString)
    Dim trans As SqlTransaction = Nothing
    Dim bRunExcute As Boolean = True
    Dim sRet As New StringBuilder("") 'luu gtri du ra

#Region "Parameters"

    Private _productVoucherID As String = ""
    Public WriteOnly Property ProductVoucherID() As String
        Set(ByVal Value As String)
            _productVoucherID = Value
        End Set
    End Property

    Private _productVoucherNo As String = ""
    Public WriteOnly Property ProductVoucherNo() As String
        Set(ByVal Value As String)
            _productVoucherNo = Value
        End Set
    End Property

    Private _voucherDate As String
    Public WriteOnly Property VoucherDate() As String
        Set(ByVal Value As String)
            _voucherDate = Value
        End Set
    End Property

    Private _note As String = ""
    Public WriteOnly Property Note() As String
        Set(ByVal Value As String)
            _note = Value
        End Set
    End Property

    Private _payrollVoucherID As String = ""
    Public WriteOnly Property PayrollVoucherID() As String
        Set(ByVal Value As String)
            _payrollVoucherID = Value
        End Set
    End Property

    Private _departmentID As String = ""
    Public WriteOnly Property DepartmentID() As String
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

    Private _transTypeID As String
    Public WriteOnly Property TransTypeID() As String
        Set(ByVal Value As String)
            _transTypeID = Value
        End Set
    End Property
#End Region

#Region "Parmeter to Print"

    Private _fromDate As String
    Public WriteOnly Property FromDate() As String
        Set(ByVal Value As String)
            _fromDate = Value
        End Set
    End Property

    Private _toDate As String
    Public WriteOnly Property ToDate() As String
        Set(ByVal Value As String)
            _toDate = Value
        End Set
    End Property
#End Region

#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0           ' TransID
    Private Const COL_IsLocked As Integer = 1          ' IsLocked
    Private Const COL_OrderNo As Integer = 2           ' STT
    Private Const COL_ProductID As Integer = 3         ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 4       ' Tên sản phẩm
    Private Const COL_StageID As Integer = 5           ' Mã công đoạn
    Private Const COL_StageName As Integer = 6         ' Tên công đoạn
    Private Const COL_RefEmployeeID As Integer = 7     ' Mã nhân viên phụ
    Private Const COL_EmployeeID As Integer = 8        ' Mã nhân viên
    Private Const COL_FirstName As Integer = 9         ' Tên nhân viên
    Private Const COL_EmployeeName As Integer = 10     ' Họ và tên
    Private Const COL_DepartmentID As Integer = 11     ' Mã phòng ban
    Private Const COL_TeamID As Integer = 12           ' Mã tổ nhóm
    Private Const COL_Quantity01 As Integer = 13       ' Soá löôïng 1
    Private Const COL_Quantity02 As Integer = 14       ' Soá löôïng 02
    Private Const COL_Quantity03 As Integer = 15       ' Soá löôïng 03
    Private Const COL_Quantity04 As Integer = 16       ' Soá löôïng 04
    Private Const COL_Quantity05 As Integer = 17       ' Soá löôïng 05
    Private Const COL_Attachment As Integer = 18       ' Đính kèm '120665 - 26 June 2019
    Private Const COL_CreateUserID As Integer = 19     ' CreateUserID
    Private Const COL_CreateDate As Integer = 20       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 21 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 22   ' LastModifyDate
    Private Const COL_ToTal As Integer = 23
#End Region

#Region "UserControl D09U1111 và Xuất Excel (gồm 7 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới CÓ nút: gồm 7 bước (nếu lưới không có Nút thì bỏ B5)
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master

    '*****************************************
    Dim bLoadFormChild As Boolean = False 'Ktra xem co goi form con k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
#End Region

    Dim oData(,) As Object
    Dim oField(,) As Object
    Dim iPrevRow As Integer = 0
    Private iCopyRows As Integer = 0, iCopyCol As Integer = 0
    Private sFirstCol As String = "ProductID"
    Private iCurrentCol As Integer
    Private iFirstColunm As Integer
    Private sLastProductID As String = ""
    Private bPressCopy As Boolean = False

    Friend WithEvents C1XLBook1 As New C1.C1Excel.C1XLBook
    Private iOldFirstRow_CtrlE As Integer = 0, iOldLastRow_CtrlE As Integer = 0, iOldCol_CtrlE As Integer = 0

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


    Private Sub D45F2003_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bSaveOK Then
            If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
        End If
    End Sub

    Private Sub D45F2003_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.F1 Then
            btnHotKey_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        End If
        '***************************************
        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowOption_Click(Nothing, Nothing)
        End If

        If e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()

        End If

        '***************************************
    End Sub

    Private Sub D45F2003_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        bFlagNewRow = False
        bColMove = False

        LoadTDBDropDown()
        LoadData()
        LoadCaptionQuantity()
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        ResetFooterGrid(tdbg, 0, 0)

        If _FormState <> EnumFormState.FormView Then 'cho phep sua
            tdbg.AllowUpdate = True
            tdbg.AllowAddNew = True
            tdbg.AllowDelete = True
            tdbg.AllowSort = False
            bSaveOK = False
        Else
            tdbg.AllowUpdate = False
            tdbg.AllowAddNew = False
            tdbg.AllowDelete = False
            tdbg.AllowSort = True
            bSaveOK = True
        End If
        tdbg.AllowColMove = True

        'Khoi tao mang luu chi so 
        For i As Integer = 0 To tdbg.Columns.Count - 1
            arrayIndex(i) = i
        Next

        '*****************************************
        CallD09U1111_Button(True)
        '*****************************************
        InputbyUnicode(Me, gbUnicode)
        '********************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_EmployeeID, COL_ProductID, COL_StageID}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub


    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_cham_cong_san_pham_-_D45F2003") & UnicodeCaption(gbUnicode)  'rl3("Chi_tiet_cham_cong_san_pham_-_D45F2003") 'Chi tiÕt chÊm c¤ng s¶n phÈm - D45F2003
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnHotKey.Text = rl3("_Phim_nong") '&Phím nóng
        btnAdjust.Text = rl3("Die_u_chinh_phieu") 'Điề&u chỉnh phiếu
        '================================================================ 
        chkTestDuplicate.Text = rl3("Kiem_tra_trung_ma")
        '================================================================ 
        Voucher.Text = rl3("Chung_tu") 'Chứng từ
        '================================================================ 
        tdbdProductID.Columns("ProductID").Caption = rl3("Ma") 'Mã
        tdbdProductID.Columns("ProductName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdRefEmployeeID.Columns("RefEmployeeID").Caption = rl3("Ma") 'Mã 
        tdbdRefEmployeeID.Columns("FirstName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbdRefEmployeeID.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbdRefEmployeeID.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbdEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbdEmployeeID.Columns("FirstName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbdEmployeeID.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbdEmployeeID.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ
        tdbdEmployeeID.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbdEmployeeID.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbdStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbdStageID.Columns("StageName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdFirstName.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbdFirstName.Columns("FirstName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbdFirstName.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbdFirstName.Columns("RefEmployeeID").Caption = rl3("Ma_NV_phu") 'Mã NV phụ
        '================================================================
        tdbg.Columns("OrderNo").Caption = rl3("STT") 'STT
        tdbg.Columns("ProductID").Caption = rl3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm"
        tdbg.Columns("StageID").Caption = rl3("Ma_cong_doan")
        tdbg.Columns("StageName").Caption = rl3("Ten_cong_doan")
        tdbg.Columns("RefEmployeeID").Caption = rl3("Ma_nhan_vien_phu") 'Mã nhân viên phụ
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("FirstName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("DepartmentID").Caption = rl3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("TeamID").Caption = rl3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("Attachment").Caption = rl3("Dinh_kem")'Đính kèm
    End Sub

    Private Sub LoadData()
        txtProductVoucherNo.Text = _productVoucherNo
        txtVoucherDate.Text = _voucherDate
        txtNote.Text = _note
        LoadTDBGrid()
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_StageName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        If D45Options.CancelEmployeeID Then
            tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Locked = True
            tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).AllowFocus = False
        End If
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_Quantity01).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity03).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity04).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity05).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdProductID
        sSQL = "Select D45.ProductID, D45.ProductName" & UnicodeJoin(gbUnicode) & " As ProductName From D45T1000 D45  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Order by ProductID"
        dtProductID = ReturnDataTable(sSQL)
        LoadDataSource(tdbdProductID, dtProductID, gbUnicode)

        'Load tdbdEmployeeID
        sSQL = "Select D13.EmployeeID as EmployeeID, D09.RefEmployeeID as RefEmployeeID, " & vbCrLf
        If gbUnicode = False Then
            sSQL &= "Isnull(D09.LastName,'') + ' ' + Isnull(D09.MiddleName,'') + ' ' + Isnull(D09.FirstName,'')  as EmployeeName, " & vbCrLf
        Else
            sSQL &= "Isnull(D09.LastNameU,'') + ' ' + Isnull(D09.MiddleNameU,'') + ' ' + Isnull(D09.FirstNameU,'')  as EmployeeName, " & vbCrLf
        End If
        sSQL &= "D13.DepartmentID, D13.TeamID, D09.FirstName" & UnicodeJoin(gbUnicode) & " As FirstName" & vbCrLf
        sSQL &= "From 	D13T0101 D13  WITH(NOLOCK) Inner join D09T0201 D09  WITH(NOLOCK) On D13.EmployeeID =  D09.EmployeeID " & vbCrLf
        sSQL &= " Where D13.DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "And (Case when " & SQLString(_departmentID) & " <> '%' then D13.DepartmentID " & vbCrLf
        sSQL &= "else '%' end = " & SQLString(_departmentID) & ")" & vbCrLf
        sSQL &= "And (Case when " & SQLString(_teamID) & " <> '%' then D13.TeamID " & vbCrLf
        sSQL &= "else '%' end = " & SQLString(_teamID) & ")" & vbCrLf
        sSQL &= "And PayrollVoucherID = " & SQLString(_payrollVoucherID) & vbCrLf

        dt_EmployeeID = ReturnDataTable(sSQL)
        dt_RefEmployeeID = dt_EmployeeID.Copy
        dtFirstName = dt_EmployeeID.Copy

        dt_EmployeeID.DefaultView.Sort = "EmployeeID"
        LoadDataSource(tdbdEmployeeID, dt_EmployeeID, gbUnicode)

        'Load tdbdRefEmployeeID
        dt_RefEmployeeID.DefaultView.Sort = "RefEmployeeID"
        LoadDataSource(tdbdRefEmployeeID, dt_RefEmployeeID, gbUnicode)

        'Load tdbdFisrtName
        dtFirstName.DefaultView.Sort = "FirstName"
        LoadDataSource(tdbdFirstName, dtFirstName, gbUnicode)
    End Sub

    Private Sub LoadtdbdStageID(ByVal ID As String)
        'Quá lâu
        Dim sSQL As String = ""
        sSQL = "Select D01.StageID, D10.StageName" & UnicodeJoin(gbUnicode) & " As StageName, D01.ProductID" & vbCrLf
        sSQL &= "From D45T1001 D01  WITH(NOLOCK) Inner join D45T1010 D10  WITH(NOLOCK) On D10.StageID = D01.StageID" & vbCrLf
        sSQL &= "Where	D10.Disabled = 0 And ProductID = " & SQLString(ID) & vbCrLf
        sSQL &= "Order by D01.OrderNo"
        dtStage = ReturnDataTable(sSQL)
        LoadDataSource(tdbdStageID, dtStage, gbUnicode)
    End Sub

    Private Sub LoadCaptionQuantity()
        Dim sSQL As String = ""
        sSQL = "Select Code, ShortName" & UnicodeJoin(gbUnicode) & " As ShortName, Disabled From D45T0010  WITH(NOLOCK) Where Type = 'QTY' Order by Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim j As Integer = 0 'dòng của table
        If dt.Rows.Count > 0 Then
            For i As Integer = COL_Quantity01 To COL_Quantity05
                tdbg.Splits(0).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dt.Rows(j).Item("ShortName").ToString
                tdbg.Splits(0).DisplayColumns(i).Visible = CBool(IIf(dt.Rows(j).Item("Disabled").ToString = "1", 0, 1))
                If tdbg.Splits(0).DisplayColumns(i).Visible Then iColQuantityLast = i 'Lấy cột cuối cùng của lưới
                j += 1
            Next
        End If
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P2002()
        Dim dt As DataTable = ReturnDataTable(sSQL)

        If dt.Rows.Count > 0 Then
            dt.Columns.Add("OrderNo", Type.GetType("System.Single"))
        End If
        Dim dc As DataColumn = Nothing
        If dt.Columns.Contains("Attachment") Then
            dc = dt.Columns("Attachment")
        Else
            dc = dt.Columns.Add("Attachment")
        End If
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("Attachment") = "(" & ReturnAttachmentNumber("D45T2001", dt.Rows(i).Item("ProductID").ToString(), dt.Rows(i).Item("EmployeeID").ToString(),txtProductVoucherNo.Text) & ")"  'Đính kèm
        Next
        LoadDataSource(tdbg, dt, gbUnicode)
        CalFooterAndOrderNo()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2002
    '# Created User: Nguyễn Trần Phương Nam
    '# Created Date: 04/10/2007 03:33:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: Đổ nguồn cho Lưới trường hợp Xem, Sửa
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2002() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2002 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_departmentID) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(_teamID) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(_employeeID) & COMMA 'EmployeeID, varchar[20], NOT NULL
        sSQL &= SQLString(_productVoucherID) & COMMA 'ProductVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, tinyint, NOT NULL '1: Nếu gọi từ D45F2003; 0 : Nếu gọi từ D45F2002
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub CalFooterAndOrderNo()
        Dim dQuantity01 As Double = 0
        Dim dQuantity02 As Double = 0
        Dim dQuantity03 As Double = 0
        Dim dQuantity04 As Double = 0
        Dim dQuantity05 As Double = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, COL_OrderNo) = i + 1
            dQuantity01 += Number(tdbg(i, COL_Quantity01))
            dQuantity02 += Number(tdbg(i, COL_Quantity02))
            dQuantity03 += Number(tdbg(i, COL_Quantity03))
            dQuantity04 += Number(tdbg(i, COL_Quantity04))
            dQuantity05 += Number(tdbg(i, COL_Quantity05))
        Next

        FooterTotalGrid(tdbg, COL_ProductName)

        tdbg.Columns(COL_Quantity01).FooterText = Format(dQuantity01, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity02).FooterText = Format(dQuantity02, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity03).FooterText = Format(dQuantity03, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity04).FooterText = Format(dQuantity04, DxxFormat.DefaultNumber2)
        tdbg.Columns(COL_Quantity05).FooterText = Format(dQuantity04, DxxFormat.DefaultNumber2)
    End Sub

    Private Sub CalTotalFooter(ByVal iCol As Integer)
        Dim dQuantity As Double = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            dQuantity += Number(tdbg(i, iCol))
        Next

        tdbg.Columns(iCol).FooterText = Format(dQuantity, DxxFormat.DefaultNumber2)
    End Sub

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()

        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim i As Integer = 0
        Dim j As Integer = 0
        For i = 0 To tdbg.RowCount - 1
            'Sửa ngày 26/02/2008
            If tdbg(i, COL_ProductID).ToString = "" And tdbg(i, COL_StageID).ToString = "" And tdbg(i, COL_RefEmployeeID).ToString = "" Then Continue For
            '***********************
            If tdbg(i, COL_ProductID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ma_san_pham"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_ProductID
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_StageID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ma_cong_doan"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_StageID
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            'If tdbg(i, COL_RefEmployeeID).ToString = "" Then
            '    D99C0008.MsgNotYetEnter("Mã NV phụ")
            '    tdbg.SplitIndex = SPLIT0
            '    tdbg.Col = COL_RefEmployeeID
            '    tdbg.Bookmark = i
            '    tdbg.Focus()
            '    Return False
            'End If
            If tdbg(i, COL_EmployeeID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ma_NV"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_EmployeeID 'Đã sửa theo Incident 15080
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If i = tdbg.RowCount - 1 Then Exit For
            If chkTestDuplicate.Checked Then
                For j = i + 1 To tdbg.RowCount - 1
                    If tdbg(i, COL_ProductID).ToString = tdbg(j, COL_ProductID).ToString And tdbg(i, COL_StageID).ToString = tdbg(j, COL_StageID).ToString And tdbg(i, COL_EmployeeID).ToString = tdbg(j, COL_EmployeeID).ToString And tdbg(i, COL_DepartmentID).ToString = tdbg(j, COL_DepartmentID).ToString And tdbg(i, COL_TeamID).ToString = tdbg(j, COL_TeamID).ToString Then
                        D99C0008.MsgDuplicatePKey()
                        tdbg.Row = j
                        tdbg.SplitIndex = 0
                        tdbg.Col = COL_StageID
                        tdbg.Focus()
                        Return False
                    End If
                Next
            End If
        Next
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2001
    '# Created User: Nguyễn Trần Phương Nam
    '# Created Date: 05/10/2007 10:28:41
    '# Modified User: 
    '# Modified Date: 
    '# Description: Xóa dữ liệu cũ
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2001() As String
        Dim sSQL As String = ""
        sSQL &= "Delete D45T2001"
        sSQL &= " Where	DivisionID = " & SQLString(gsDivisionID) & " and"
        sSQL &= " TranMonth = " & SQLNumber(giTranMonth) & " and"
        sSQL &= " TranYear = " & SQLNumber(giTranYear) & " and"
        sSQL &= " ProductVoucherID = " & SQLString(_productVoucherID) & " and"
        sSQL &= " (Case when " & SQLString(_departmentID) & " <> '%' then DepartmentID "
        sSQL &= " else '%' end = " & SQLString(_departmentID) & " ) and"
        sSQL &= " (Case when " & SQLString(_teamID) & " <> '%' then TeamID "
        sSQL &= " else '%' end = " & SQLString(_teamID) & ") "
        Return sSQL
    End Function


    Private Sub HotKeyEnterGrid_New(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal nFirstCol As Integer, ByVal e As System.Windows.Forms.KeyEventArgs, Optional ByVal iSplit As Integer = 0, Optional ByVal iUpdateData As Byte = 0)
        Dim iCol As Integer = CInt(IIf(bColMove = False, tdbg.Col, arrayIndex(tdbg.Col)).ToString)

        Try
            'Không gọi hàm CountCol tại đây (do khi gọi ) mà gọi trong code từng form 
            With c1Grid
                If iUpdateData = 1 Then .UpdateData()
                .SplitIndex = iSplit
                If c1Grid.AllowAddNew = True Then
                    .Row = .Row + 1
                Else
                    .Row = CInt(IIf(.RowCount = .Row + 1, 0, .Row + 1))
                End If
                '.Col = nFirstCol
                iCol = nFirstCol

                e.SuppressKeyPress = True
                e.Handled = True

            End With
        Catch ex As Exception
            D99C0008.Msg("Lỗi HotKeyEnterGrid: " & ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    'Sửa ngày 21/02/2008
    Private Sub TestStageID()
        LoadtdbdStageID(tdbg.Columns(COL_ProductID).Text)
        Dim dt As DataTable = dtStage.Copy
        dt.DefaultView.RowFilter = "StageID=" & SQLString(tdbg.Columns(COL_StageID).Text)
        If dt.DefaultView.Count = 0 Then 'không tồn tại
            tdbg.Columns(COL_StageID).Text = ""
            tdbg.Columns(COL_StageName).Text = ""
        End If
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
            Case COL_ProductID
                If tdbg.Columns(COL_ProductID).Text.ToUpper <> tdbdProductID.Columns("ProductID").Text.ToUpper Then
                    tdbg.Columns(COL_ProductID).Text = ""
                    tdbg.Columns(COL_ProductName).Text = ""
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
                Else
                    tdbg.Columns(COL_ProductID).Text = tdbdProductID.Columns("ProductID").Text
                    tdbg.Columns(COL_ProductName).Text = tdbdProductID.Columns("ProductName").Text
                    TestStageID()
                End If
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text,txtProductVoucherNo.Text) & ")"  'Đính kèm
            Case COL_StageID
                If tdbg.Columns(COL_StageID).Text.ToUpper <> tdbdStageID.Columns("StageID").Text.ToUpper Then
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
                Else
                    tdbg.Columns(COL_StageID).Text = tdbdStageID.Columns("StageID").Text
                    tdbg.Columns(COL_StageName).Text = tdbdStageID.Columns("StageName").Text
                End If
            Case COL_EmployeeID
                If tdbg.Columns(COL_EmployeeID).Text.ToUpper <> tdbdEmployeeID.Columns("EmployeeID").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                Else
                    tdbg.Columns(COL_EmployeeID).Text = tdbdEmployeeID.Columns("EmployeeID").Text
                    tdbg.Columns(COL_FirstName).Text = tdbdEmployeeID.Columns("FirstName").Text
                    tdbg.Columns(COL_EmployeeName).Text = tdbdEmployeeID.Columns("EmployeeName").Text
                    tdbg.Columns(COL_RefEmployeeID).Text = tdbdEmployeeID.Columns("RefEmployeeID").Text
                    tdbg.Columns(COL_DepartmentID).Text = tdbdEmployeeID.Columns("DepartmentID").Text
                    tdbg.Columns(COL_TeamID).Text = tdbdEmployeeID.Columns("TeamID").Text
                End If
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text,txtProductVoucherNo.Text) & ")"  'Đính kèm
            Case COL_FirstName
                If tdbg.Columns(COL_FirstName).Text.ToUpper <> tdbdFirstName.Columns("FirstName").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                Else
                    tdbg.Columns(COL_EmployeeID).Text = tdbdFirstName.Columns("EmployeeID").Text
                    tdbg.Columns(COL_FirstName).Text = tdbdFirstName.Columns("FirstName").Text
                    tdbg.Columns(COL_EmployeeName).Text = tdbdFirstName.Columns("EmployeeName").Text
                    tdbg.Columns(COL_RefEmployeeID).Text = tdbdFirstName.Columns("RefEmployeeID").Text
                    tdbg.Columns(COL_DepartmentID).Text = tdbdFirstName.Columns("DepartmentID").Text
                    tdbg.Columns(COL_TeamID).Text = tdbdFirstName.Columns("TeamID").Text
                End If
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text,txtProductVoucherNo.Text) & ")"  'Đính kèm
            Case COL_RefEmployeeID
                If tdbg.Columns(COL_RefEmployeeID).Text.ToUpper <> tdbdRefEmployeeID.Columns("RefEmployeeID").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                Else
                    tdbg.Columns(COL_EmployeeID).Text = tdbdRefEmployeeID.Columns("EmployeeID").Text
                    tdbg.Columns(COL_FirstName).Text = tdbdRefEmployeeID.Columns("FirstName").Text
                    tdbg.Columns(COL_EmployeeName).Text = tdbdRefEmployeeID.Columns("EmployeeName").Text
                    tdbg.Columns(COL_RefEmployeeID).Text = tdbdRefEmployeeID.Columns("RefEmployeeID").Text
                    tdbg.Columns(COL_DepartmentID).Text = tdbdRefEmployeeID.Columns("DepartmentID").Text
                    tdbg.Columns(COL_TeamID).Text = tdbdRefEmployeeID.Columns("TeamID").Text
                End If
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text,txtProductVoucherNo.Text) & ")"  'Đính kèm
            Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05
                CalTotalFooter(CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString))
        End Select

        tdbg.Columns(COL_OrderNo).Text = (tdbg.Bookmark + 1).ToString
        tdbg.Columns(COL_ProductName).FooterText = tdbg.RowCount.ToString
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        CalFooterAndOrderNo() 'Tính lại STT và Tổng số lượng
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
            Case COL_StageID
                If tdbg.Columns(COL_IsLocked).Text = "1" Then
                    e.Cancel = True
                Else
                    LoadtdbdStageID(tdbg.Columns(COL_ProductID).Text)
                End If
            Case COL_Quantity01, COL_ProductID, COL_RefEmployeeID, COL_EmployeeID
                If tdbg.Columns(COL_IsLocked).Text = "1" Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Dim iCol As Integer = CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)

        Select Case CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
            Case COL_ProductID
                If tdbg.Columns(COL_ProductID).Text.ToUpper <> tdbdProductID.Columns("ProductID").Text.ToUpper Then
                    tdbg.Columns(COL_ProductID).Text = ""
                    tdbg.Columns(COL_ProductName).Text = ""
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
                End If
            Case COL_StageID
                If tdbg.Columns(COL_StageID).Text.ToUpper <> tdbdStageID.Columns("StageID").Text.ToUpper Then
                    tdbg.Columns(COL_StageID).Text = ""
                    tdbg.Columns(COL_StageName).Text = ""
                End If
            Case COL_EmployeeID
                If tdbg.Columns(COL_EmployeeID).Text.ToUpper <> tdbdEmployeeID.Columns("EmployeeID").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                End If
            Case COL_FirstName
                If tdbg.Columns(COL_FirstName).Text.ToUpper <> tdbdFirstName.Columns("FirstName").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                End If
            Case COL_RefEmployeeID
                If tdbg.Columns(COL_RefEmployeeID).Text.ToUpper <> tdbdRefEmployeeID.Columns("RefEmployeeID").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                End If

            Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05
                If L3IsNumeric(tdbg.Columns(iCol).Text, EnumDataType.Money) = False Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub tdbg_ButtonClick(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ButtonClick
        Select Case tdbg.Col
            Case COL_Attachment
                if  tdbg.Splits(SPLIT0).DisplayColumns(COL_Attachment).Button = False Then Exit Sub
                If tdbg.Columns(COL_ProductID).Text = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ma_san_pham"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_ProductID
                    tdbg.Focus()
                    Exit Sub
                End If
                If tdbg.Columns(COL_EmployeeID).Text = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ma_NV"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_EmployeeID
                    tdbg.Focus()
                    Exit Sub
                End If
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "TableName", "D45T2001")
                SetProperties(arrPro, "Key1ID", tdbg.Columns(COL_ProductID).Text)
                SetProperties(arrPro, "Key2ID", tdbg.Columns(COL_EmployeeID).Text)
                SetProperties(arrPro, "Key3ID", txtProductVoucherNo.Text)
                SetProperties(arrPro, "Status", L3Byte(IIf(_FormState = EnumFormState.FormView, 0, 1)))
                'SetProperties(arrPro, "bNewDatabase", TRUE/ FALSE)'Lưu database mới ATT, không phải database hiện tại. Không dùng nữa mà theo thiết lập D91T0025
                CallFormShowDialog("D91D0340", "D91F4010", arrPro)
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text,txtProductVoucherNo.Text) & ")"  'Đính kèm
        End Select
    End Sub

    Private Sub tdbg_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.Change
        bChangeData = True
    End Sub

    Private Sub tdbg_ColMove(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColMoveEventArgs) Handles tdbg.ColMove
        Dim iTmp As Integer
        If e.Position < e.ColIndex Then
            iTmp = arrayIndex(e.ColIndex)
            For i As Integer = e.ColIndex To e.Position + 1 Step -1
                arrayIndex(i) = arrayIndex(i - 1)
            Next
            arrayIndex(e.Position) = iTmp
        Else
            iTmp = arrayIndex(e.ColIndex)
            For i As Integer = e.ColIndex To e.Position - 1
                arrayIndex(i) = arrayIndex(i + 1)
            Next
            arrayIndex(e.Position) = iTmp
        End If

        bColMove = True
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
            Case COL_ProductID
                tdbg.Columns(COL_ProductID).Text = tdbdProductID.Columns("ProductID").Text
                tdbg.Columns(COL_ProductName).Text = tdbdProductID.Columns("ProductName").Text
                TestStageID()
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text, txtProductVoucherNo.Text) & ")"  'Đính kèm
            Case COL_StageID
                tdbg.Columns(COL_StageID).Text = tdbdStageID.Columns("StageID").Text
                tdbg.Columns(COL_StageName).Text = tdbdStageID.Columns("StageName").Text
            Case COL_EmployeeID
                tdbg.Columns(COL_EmployeeID).Text = tdbdEmployeeID.Columns("EmployeeID").Text
                tdbg.Columns(COL_FirstName).Text = tdbdEmployeeID.Columns("FirstName").Text
                tdbg.Columns(COL_EmployeeName).Text = tdbdEmployeeID.Columns("EmployeeName").Text
                tdbg.Columns(COL_RefEmployeeID).Text = tdbdEmployeeID.Columns("RefEmployeeID").Text
                tdbg.Columns(COL_DepartmentID).Text = tdbdEmployeeID.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = tdbdEmployeeID.Columns("TeamID").Text
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text, txtProductVoucherNo.Text) & ")"  'Đính kèm
            Case COL_FirstName
                tdbg.Columns(COL_EmployeeID).Text = tdbdFirstName.Columns("EmployeeID").Text
                tdbg.Columns(COL_FirstName).Text = tdbdFirstName.Columns("FirstName").Text
                tdbg.Columns(COL_EmployeeName).Text = tdbdFirstName.Columns("EmployeeName").Text
                tdbg.Columns(COL_RefEmployeeID).Text = tdbdFirstName.Columns("RefEmployeeID").Text
                tdbg.Columns(COL_DepartmentID).Text = tdbdFirstName.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = tdbdFirstName.Columns("TeamID").Text
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text, txtProductVoucherNo.Text) & ")"  'Đính kèm
            Case COL_RefEmployeeID
                tdbg.Columns(COL_EmployeeID).Text = tdbdRefEmployeeID.Columns("EmployeeID").Text
                tdbg.Columns(COL_FirstName).Text = tdbdRefEmployeeID.Columns("FirstName").Text
                tdbg.Columns(COL_EmployeeName).Text = tdbdRefEmployeeID.Columns("EmployeeName").Text
                tdbg.Columns(COL_RefEmployeeID).Text = tdbdRefEmployeeID.Columns("RefEmployeeID").Text
                tdbg.Columns(COL_DepartmentID).Text = tdbdRefEmployeeID.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = tdbdRefEmployeeID.Columns("TeamID").Text
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text, txtProductVoucherNo.Text) & ")"  'Đính kèm
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Dim iCol As Integer = CInt(IIf(bColMove = False, tdbg.Col, arrayIndex(tdbg.Col)).ToString)

        If e.KeyCode = Keys.Enter Then
            Select Case CInt(IIf(bColMove = False, tdbg.Col, arrayIndex(tdbg.Col)).ToString)
                Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05
                    If tdbg.Columns(tdbg.Col).Text = "" Then
                        tdbg.Columns(tdbg.Col).Text = "0"
                    ElseIf Not IsNumeric(tdbg.Columns(tdbg.Col).Text) Then
                        e.Handled = True
                        Exit Sub
                    End If
            End Select

            If iCol = COL_Quantity01 Or iCol = COL_Quantity02 Or iCol = COL_Quantity03 Or iCol = COL_Quantity04 Or iCol = COL_Quantity05 Then ' Or tdbg.Col = COL_RefEmployeeID
                bFlagNewRow = True
                HotKeyEnterGrid_New(tdbg, iCol, e, 0, 1) '
                Exit Sub
            ElseIf iCol = COL_RefEmployeeID Then
                bFlagNewRow = True
                HotKeyEnterGrid_New(tdbg, iCol, e)
                Exit Sub
            ElseIf iCol = COL_ProductID Or iCol = COL_StageID Then
                HotKeyEnterGrid_New(tdbg, iCol, e)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F7 Then
            If iCol = COL_EmployeeID Or iCol = COL_RefEmployeeID Then
                HotKeyF7(tdbg)
                Dim Dt1 As DataTable
                If tdbg.Columns(COL_EmployeeID).Text = String.Empty OrElse tdbg.Columns(COL_EmployeeID).Text Is Nothing Then
                    Dt1 = ReturnTableFilter(dt_RefEmployeeID, "RefEmployeeID=" & SQLString(tdbg.Columns(COL_RefEmployeeID).Text))
                Else
                    Dt1 = ReturnTableFilter(dt_EmployeeID, "EmployeeID=" & SQLString(tdbg.Columns(COL_EmployeeID).Text))
                End If
                tdbg.Columns(COL_RefEmployeeID).Text = Dt1.Rows(0).Item("RefEmployeeID").ToString
                tdbg.Columns(COL_EmployeeID).Text = Dt1.Rows(0).Item("EmployeeID").ToString
                tdbg.Columns(COL_EmployeeName).Text = Dt1.Rows(0).Item("EmployeeName").ToString
                tdbg.Columns(COL_DepartmentID).Text = Dt1.Rows(0).Item("DepartmentID").ToString
                tdbg.Columns(COL_TeamID).Text = Dt1.Rows(0).Item("TeamID").ToString
            Else
                HotKeyF7(tdbg)
            End If
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
            CalFooterAndOrderNo()
            Exit Sub
        ElseIf e.Shift And e.KeyCode = Keys.Insert Then
            HotKeyShiftInsert(tdbg, COL_OrderNo)
            CalFooterAndOrderNo()
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.Delete Then
            Me.Cursor = Cursors.WaitCursor
            DeleteMultiRows(tdbg, e)
            CalFooterAndOrderNo()
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.S Then
            Me.Cursor = Cursors.WaitCursor
            Select Case iCol
                Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05
                    CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Value.ToString, tdbg.Bookmark)
                Case COL_ProductID
                    CopyColumns(tdbg, iCol, tdbg.Bookmark, 2, tdbg.Columns(iCol).Value.ToString)
                Case COL_StageID
                    'CopyColumns_AfterBefore(tdbg, tdbg.Col, tdbg.Bookmark, 2, 1, tdbg.Columns(tdbg.Col).Value.ToString)
                    'CopyColumns(tdbg, tdbg.Col, tdbg.Bookmark, 2, tdbg.Columns(tdbg.Col).Value.ToString)
                    'Bổ sung ngày 08/05/2008 Copy mã công đoạn nhưng ko copy Mã sản phẩm
                    CopyColumnsStageID(tdbg, iCol, tdbg.Bookmark, 2, tdbg.Columns(iCol).Value.ToString)
                Case COL_RefEmployeeID
                    CopyColumns(tdbg, iCol, tdbg.Bookmark, 5, tdbg.Columns(iCol).Value.ToString)
                Case COL_EmployeeID
                    CopyColumns_AfterBefore(tdbg, iCol, tdbg.Bookmark, 1, 3, tdbg.Columns(iCol).Value.ToString)
            End Select
            Me.Cursor = Cursors.Default
        ElseIf e.KeyCode = Keys.F2 Then 'Bổ sung tìm kiếm mở rộng - 'goi exe con D91E0240 tim kiem mo rong
            Select Case iCol
                Case COL_ProductID
                    Me.Cursor = Cursors.WaitCursor
                    ' Dim sKey As String = ""
                    ' Dim f As New D91F6010
                    'With f
                    '    .InListID = "38"
                    '    .InWhere = ""
                    '    .WhereValue = ""
                    '    .ShowDialog()
                    '    sKey = .OutPut01
                    '    .Dispose()
                    'End With

                    'ID 79402 04/09/2015
                    Try
                        Dim arrPro() As StructureProperties = Nothing
                        SetProperties(arrPro, "InListID", "38")
                        SetProperties(arrPro, "InWhere", "")
                        Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6010", arrPro)
                        Dim sKey As String = GetProperties(frm, "Output01").ToString
                        If sKey <> "" Then
                            'Load dữ liệu
                            'Load tdbdProductID
                            Dim dt As DataTable = ReturnTableFilter(dtProductID, "ProductID=" & SQLString(sKey), True)
                            If dt.Rows.Count > 0 Then
                                tdbg.Columns(COL_ProductID).Text = sKey
                                tdbg.Columns(COL_ProductName).Text = dt.Rows(0).Item("ProductName").ToString
                                TestStageID()
                            End If
                        End If
                    Catch ex As Exception
                        D99C0008.MsgL3(ex.Message)
                    End Try

                    ''Load tdbdProductID
                    'Dim dt As DataTable = ReturnTableFilter(dtProductID, "ProductID=" & SQLString(sKey), True)
                    'If dt.Rows.Count > 0 Then
                    '    tdbg.Columns(COL_ProductID).Text = sKey
                    '    tdbg.Columns(COL_ProductName).Text = dt.Rows(0).Item("ProductName").ToString
                    '    TestStageID()
                    'End If
                    Me.Cursor = Cursors.Default
                Case COL_RefEmployeeID
                    Me.Cursor = Cursors.WaitCursor
                    Dim sSQLWhere As String = ""
                    sSQLWhere = "DivisionID = " & SQLString(gsDivisionID) & _
                                " And PayrollVoucherID = " & SQLString(_payrollVoucherID) & _
                                " And (Case when " & SQLString(_departmentID) & " <> '%' then DepartmentID " & _
                                " else '%' end = " & SQLString(_departmentID) & ")" & _
                                " And (Case when " & SQLString(_teamID) & " <> '%' then TeamID " & _
                                " else '%' end = " & SQLString(_teamID) & ")" & _
                                " And (Case when " & SQLString(_employeeID) & " <> '%' then EmployeeID " & _
                                " else '%' end = " & SQLString(_employeeID) & ")"

                    'Dim sKey As String = ""
                    'Dim f As New D91F6010
                    'With f
                    '    .InListID = "37"
                    '    .InWhere = sSQLWhere
                    '    .WhereValue = ""
                    '    .ShowDialog()
                    '    sKey = .OutPut01
                    '    .Dispose()
                    'End With

                    'Dim dt As DataTable = ReturnTableFilter(dt_RefEmployeeID, "RefEmployeeID=" & SQLString(sKey))
                    'If dt.Rows.Count > 0 Then
                    '    tdbg.Columns(COL_RefEmployeeID).Text = sKey
                    '    tdbg.Columns(COL_EmployeeID).Text = dt.Rows(0).Item("EmployeeID").ToString
                    '    tdbg.Columns(COL_EmployeeName).Text = dt.Rows(0).Item("EmployeeName").ToString
                    '    tdbg.Columns(COL_DepartmentID).Text = dt.Rows(0).Item("DepartmentID").ToString
                    '    tdbg.Columns(COL_TeamID).Text = dt.Rows(0).Item("TeamID").ToString
                    'End If

                    'ID 79402 04/09/2015
                    Try
                        Dim arrPro() As StructureProperties = Nothing
                        SetProperties(arrPro, "InListID", "37")
                        SetProperties(arrPro, "InWhere", sSQLWhere)
                        Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6010", arrPro)
                        Dim sKey As String = GetProperties(frm, "Output01").ToString
                        If sKey <> "" Then
                            'Load dữ liệu
                            Dim dt As DataTable = ReturnTableFilter(dt_RefEmployeeID, "RefEmployeeID=" & SQLString(sKey))
                            If dt.Rows.Count > 0 Then
                                tdbg.Columns(COL_RefEmployeeID).Text = sKey
                                tdbg.Columns(COL_EmployeeID).Text = dt.Rows(0).Item("EmployeeID").ToString
                                tdbg.Columns(COL_EmployeeName).Text = dt.Rows(0).Item("EmployeeName").ToString
                                tdbg.Columns(COL_DepartmentID).Text = dt.Rows(0).Item("DepartmentID").ToString
                                tdbg.Columns(COL_TeamID).Text = dt.Rows(0).Item("TeamID").ToString
                            End If
                        End If
                    Catch ex As Exception
                        D99C0008.MsgL3(ex.Message)
                    End Try

                    Me.Cursor = Cursors.Default
                Case Else
                    Exit Sub
            End Select
            tdbg.UpdateData()
            tdbg.SplitIndex = 0
            tdbg.Focus()
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.Insert Then
            bFlagNewRow = True
        ElseIf e.Control And e.KeyCode = Keys.C Then 'Thoại: copy
            'neu k cho cap nhat tren luoi thi cung k cho copy & paste
            If tdbg.AllowUpdate = False Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            bPressCopy = True
            CtrlC()
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.V Then 'Thoại: copy
            'neu k cho cap nhat tren luoi thi cung k cho copy & paste
            If tdbg.AllowUpdate = False Then Exit Sub

            If Not oData Is Nothing Then
                e.SuppressKeyPress = False
                iCurrentCol = iCol
                Me.Cursor = Cursors.WaitCursor
                CtrlV(e)
                UpdateTDBGOrderNum(tdbg, COL_OrderNo)
                tdbg.UpdateData()

                e.SuppressKeyPress = True

                CalFooterAndOrderNo()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        ElseIf e.Control And e.KeyCode = Keys.E Then 'Created by: Thoại
            If tdbg.AllowUpdate = False Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            CtrlE()
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.I Then 'Created by: Thoại
            If tdbg.AllowUpdate = False Then Exit Sub

            'If tdbg.Col = iOldCol_CtrlE Then
            Me.Cursor = Cursors.WaitCursor
            CtrlI()
            iCol = iOldCol_CtrlE - 1
            tdbg.Row = iOldFirstRow_CtrlE
            CalFooterAndOrderNo()
            Me.Cursor = Cursors.Default
            'End If

            Exit Sub
        End If
        HotKeyDownGrid(e, tdbg, COL_ProductID, 0, 1)
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlE
    '# Created User: Hồ Ngọc Thoại
    '# Created Date: 05/10/2008 10:37:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Export dữ liệu từ lưới ra Excel
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlE()
        Dim c1Rows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        Dim c1Cols As C1.Win.C1TrueDBGrid.SelectedColumnCollection = tdbg.SelectedCols

        If c1Cols.Count < 1 Then Exit Sub

        'lưu lại vị trí dòng, cột trước khi export ra excel
        iOldFirstRow_CtrlE = c1Rows(0)
        iOldLastRow_CtrlE = (c1Rows(c1Rows.Count - 1))
        iOldCol_CtrlE = ReturnCol(c1Cols(0).DataField)

        Dim i As Integer = 0, j As Integer = 0
        Dim k As Integer = 0 'dung de gan gtri ra cac cell o Excel

        Dim font As New System.Drawing.Font("VNI-Times", 10.0!, FontStyle.Regular)

        Dim book As C1XLBook = New C1XLBook()
        Dim sheet As XLSheet = book.Sheets(0)
        Dim cell As XLCell
        Dim style1 As C1.C1Excel.XLStyle
        Dim style As C1.C1Excel.XLStyle

        sheet.Name = "Sheet1"

        Try
            Dim icol As Integer = COL_Quantity01

            For j = 0 To c1Cols.Count - 1 'Định dạng caption
                icol = ReturnCol(c1Cols(j).DataField)
                If tdbg.Splits(0).DisplayColumns(c1Cols(j).DataField).Visible = False Then Continue For 'neu la cot an thi xet qua cot ke

                style1 = New XLStyle(book)
                cell = sheet(0, k) 'sheet(0, j)

                style1.AlignHorz = XLAlignHorzEnum.Center
                If icol = COL_Quantity01 Or icol = COL_Quantity02 Or icol = COL_Quantity03 Or icol = COL_Quantity04 Or icol = COL_Quantity05 Then
                    style1.Font = New System.Drawing.Font("VNI-Times", 11.0!, FontStyle.Bold)
                Else
                    style1.Font = New System.Drawing.Font("Arial", 9.0!, FontStyle.Bold)
                End If

                cell.Style = style1

                cell.Value = tdbg.Columns(c1Cols(j).DataField).Caption

                k += 1
            Next

            For i = 0 To c1Rows.Count - 1 'Định dạng những dòng dữ liệu tiếp theo
                k = 0
                For j = 0 To c1Cols.Count - 1

                    icol = ReturnCol(c1Cols(j).DataField)
                    If tdbg.Splits(0).DisplayColumns(c1Cols(j).DataField).Visible = False Then Continue For 'neu la cot an thi xet qua cot ke

                    cell = sheet(i + 1, k) 'sheet(i + 1, j)

                    If icol = COL_Quantity01 Or icol = COL_Quantity02 Or icol = COL_Quantity03 Or icol = COL_Quantity04 Or icol = COL_Quantity05 Then
                        style = New XLStyle(book)
                        style.Font = font
                        style.AlignHorz = XLAlignHorzEnum.Right
                        style.Format = DxxFormat.DefaultNumber2
                        cell.Style = style
                        cell.Value = tdbg(c1Rows.Item(i), c1Cols.Item(j).DataField)
                    Else
                        style = New XLStyle(book)
                        style.Font = font
                        style.AlignHorz = XLAlignHorzEnum.Left
                        style.Format = ""
                        cell.Style = style
                        cell.Value = tdbg(c1Rows.Item(i), c1Cols.Item(j).DataField).ToString

                    End If
                    k += 1
                Next
            Next

            'Fix the columns's size
            AutoSizeColumns(sheet)

            'Save the file
            Dim fileName As String = gsApplicationPath + "\D45F2003.xls"

            If File.Exists(fileName) Then 'Đóng File excel đang mở
                Dim procName As String = "Excel"
                Dim proc As Process
                Dim processes() As Process
                Dim iprocID As Integer = 0

                processes = Process.GetProcessesByName(procName)

                For Each proc In processes
                    If proc.MainWindowTitle = "Microsoft Excel - D45F2003.xls" Then
                        iprocID = proc.Id

                        If iprocID <> 0 Then
                            Dim tempProc As Process = Process.GetProcessById(iprocID) '3932
                            tempProc.CloseMainWindow()
                            tempProc.Close()

                            Exit For
                        End If

                    End If
                Next
            End If

            Application.DoEvents()

            Thread.Sleep(100)

            book.Save(fileName)

            System.Diagnostics.Process.Start(fileName)

        Catch ex As Exception
            D99C0008.MsgL3("Thuc hien tac vu khong thanh cong")

        End Try
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlI
    '# Created User: Hồ Ngọc Thoại
    '# Created Date: 05/10/2008 10:37:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Import dữ liệu từ excel vào lưới
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlI()
        Dim fileName As String = gsApplicationPath + "\D45F2003.xls"

        Try
            Dim cn As System.Data.OleDb.OleDbConnection
            Dim cmd As System.Data.OleDb.OleDbDataAdapter
            Dim ds As New System.Data.DataSet()
            Dim dtExcel As DataTable
            Dim i, j As Integer

            cn = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" & _
                "data source=" & fileName & ";Extended Properties=Excel 8.0;")

            ' Select the data from Sheet1 of the workbook.
            cmd = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", cn)

            cn.Open()
            cmd.Fill(ds)
            cn.Close()

            dtExcel = ds.Tables(0)

            For i = 0 To dtExcel.Rows.Count - 1
                For j = 0 To dtExcel.Columns.Count - 1
                    'tdbg(i + iOldFirstRow_CtrlE, j + iOldCol_CtrlE) = dtExcel.Rows(i).Item(j)
                    tdbg(i + iOldFirstRow_CtrlE, dtExcel.Columns(j).ColumnName) = dtExcel.Rows(i).Item(j)
                Next
            Next

            'If tdbg.Row = iOldFirstRow_CtrlE Then 'chèn vào đúng vị trí cũ
            '    For i = 0 To dtExcel.Rows.Count - 1
            '        For j = 0 To dtExcel.Columns.Count - 1
            '            tdbg(i + iOldFirstRow_CtrlE, j + iOldCol_CtrlE) = dtExcel.Rows(i).Item(j)
            '        Next
            '    Next
            'Else 'thêm mới
            '    Dim iRow As Integer = iOldFirstRow_CtrlE

            '    iRow = tdbg.Row

            '    Dim iAddRows As Integer = tdbg.RowCount - tdbg.Row

            '    If iAddRows > 0 Then 'con trỏ đứng tại vị trí có dữ liệu
            '        If dtExcel.Rows.Count - iAddRows > 0 Then
            '            For i = 0 To dtExcel.Rows.Count - 1 - iAddRows
            '                tdbg.MoveLast()
            '                tdbg.Row = tdbg.Row + 1
            '                tdbg.Columns(COL_TransID).Text = ""
            '            Next
            '        End If
            '    Else 'con trỏ đứng tại dòng mới hoàn toàn
            '        For i = 0 To dtExcel.Rows.Count - 1
            '            tdbg.MoveLast()
            '            tdbg.Row = tdbg.Row + 1
            '            tdbg.Columns(COL_TransID).Text = ""
            '        Next
            '    End If


            '    For i = 0 To dtExcel.Rows.Count - 1
            '        For j = 0 To dtExcel.Columns.Count - 1
            '            tdbg(i + iRow, j + iOldCol_CtrlE) = dtExcel.Rows(i).Item(j)
            '        Next
            '    Next

            '    iOldFirstRow_CtrlE = iRow
            'End If

        Catch ex As Exception
            MsgBox(ex.Message & " - " & ex.ToString)
        End Try
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: AutoSizeColumns
    '# Created User: Hồ Ngọc Thoại
    '# Created Date: 05/10/2008 10:37:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Canh độ rộng của cột trên excel
    '#---------------------------------------------------------------------------------------------------
    Private Sub AutoSizeColumns(ByVal sheet As XLSheet)

        Using g As Graphics = Graphics.FromHwnd(IntPtr.Zero)

            Dim r As Integer, c As Integer
            For c = 0 To sheet.Columns.Count - 1
                Dim colWidth As Integer = -1
                For r = 0 To sheet.Rows.Count - 1

                    Dim value As Object = sheet(r, c).Value

                    If Not (value Is Nothing) Then
                        ' get value (unformatted at this point)
                        Dim text As String = value.ToString()
                        ' get font (default or style)
                        Dim font As Font = C1XLBook1.DefaultFont
                        Dim s As XLStyle = sheet(r, c).Style
                        If Not (s Is Nothing) Then
                            If Not (s.Font Is Nothing) Then
                                font = s.Font
                            End If
                        End If

                        ' measure string (add a little tolerance)
                        Dim sz As Size = System.Drawing.Size.Ceiling(g.MeasureString(text + "XX", font))

                        ' keep widest so far
                        If sz.Width > colWidth Then
                            colWidth = sz.Width
                        End If
                    End If

                    ' done measuring, set column width
                    If colWidth > -1 Then
                        sheet.Columns(c).Width = C1XLBook.PixelsToTwips(colWidth)
                    End If
                Next
            Next
        End Using
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlC
    '# Created User: Hồ Ngọc Thoại
    '# Created Date: 05/10/2008 10:37:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Copy từ dòng được chọn (dán vào vị trí con trỏ đang đứng)
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlC()
        Dim c1Rows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        Dim c1Cols As C1.Win.C1TrueDBGrid.SelectedColumnCollection = tdbg.SelectedCols
        Dim i As Integer = 0, j As Integer = 0

        If c1Cols.Count < 1 Then
            sFirstCol = ""
            Exit Sub
        End If

        If c1Cols(0).DataField = "OrderNo" Or c1Cols(0).DataField = "ProductName" Or c1Cols(0).DataField = "StageName" Or c1Cols(0).DataField = "EmployeeName" Or c1Cols(0).DataField = "DepartmentID" Or c1Cols(0).DataField = "TeamID" Then
            Exit Sub
        End If

        sFirstCol = c1Cols(0).DataField

        Dim iAddCols As Integer = 0

        For j = 0 To c1Cols.Count - 1
            If j = c1Cols.Count - 1 Then
                If c1Cols(j).DataField = "ProductID" Then
                    iAddCols += 1
                End If

                If c1Cols(j).DataField = "StageID" Then
                    iAddCols += 1
                End If

                If c1Cols(j).DataField = "RefEmployeeID" Then
                    iAddCols += 4
                End If

                If c1Cols(j).DataField = "EmployeeID" Then
                    iAddCols += 3
                End If

                'Them vao ngay 29/04/09 vi khi chi copy 3 cot Ma NV phu, Ma Nv va Ten NV se bi sai
                If c1Cols(0).DataField = "RefEmployeeID" Then
                    If c1Cols(j).DataField = "EmployeeName" OrElse c1Cols(j).DataField = "DepartmentID" OrElse c1Cols(j).DataField = "TeamID" Then
                        iAddCols += 4
                    End If
                ElseIf c1Cols(0).DataField = "EmployeeID" Then
                    If c1Cols(j).DataField = "EmployeeName" OrElse c1Cols(j).DataField = "DepartmentID" OrElse c1Cols(j).DataField = "TeamID" Then
                        iAddCols += 3
                    End If
                End If
            End If
        Next

        ReDim oData(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)

        iPrevRow = tdbg.RowCount - 1
        iCopyRows = c1Rows.Count - 1
        iCopyCol = c1Cols.Count - 1

        For i = 0 To c1Rows.Count - 1
            For j = 0 To c1Cols.Count - 1

                If c1Cols(j).DataField <> "ProductName" And c1Cols(j).DataField <> "StageName" And c1Cols(j).DataField <> "EmployeeName" And c1Cols(j).DataField <> "DepartmentID" And c1Cols(j).DataField <> "TeamID" Then
                    oData(i, j) = CObj(tdbg(c1Rows(i), c1Cols(j).DataField))

                    'If j = c1Cols.Count - 1 Then
                    If c1Cols(j).DataField = "ProductID" Then
                        oData(i, j + 1) = CObj(tdbg(c1Rows(i), "ProductName"))
                    End If

                    If c1Cols(j).DataField = "StageID" Then
                        oData(i, j + 1) = CObj(tdbg(c1Rows(i), "StageName"))
                    End If

                    If c1Cols(j).DataField = "RefEmployeeID" Then
                        oData(i, j + 1) = CObj(tdbg(c1Rows(i), "EmployeeID"))
                        oData(i, j + 2) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                        oData(i, j + 3) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                        oData(i, j + 4) = CObj(tdbg(c1Rows(i), "TeamID"))
                    End If

                    If c1Cols(j).DataField = "EmployeeID" Then
                        oData(i, j + 1) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                        oData(i, j + 2) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                        oData(i, j + 3) = CObj(tdbg(c1Rows(i), "TeamID"))
                    End If
                    'End If

                End If
            Next
        Next

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlV
    '# Created User: Hồ Ngọc Thoại
    '# Created Date: 05/10/2008 10:37:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: Past vào vị trí con trỏ đang đứng (từ những dòng copy trên)
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlV(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim i As Integer = 0, j As Integer = 0

        If sFirstCol = "" Then Exit Sub
        iFirstColunm = ReturnCol(sFirstCol)

        If iCurrentCol <> iFirstColunm Then Exit Sub

        If iPrevRow <= tdbg.Row - 1 Then
            tdbg.MoveLast()
            For i = 0 To iCopyRows
                If tdbg.Row = tdbg.RowCount Then
                    tdbg.Row = tdbg.Row
                Else
                    tdbg.Row = tdbg.Row + 1
                End If

                tdbg.Columns(COL_TransID).Text = ""
            Next

            tdbg.UpdateData()

            For i = 0 To iCopyRows
                If i + iPrevRow + 1 <= tdbg.RowCount - 1 Then
                    For j = 0 To iCopyCol
                        If i = iCopyRows And j = 0 Then sLastProductID = oData(i, j).ToString

                        If (j + iFirstColunm) <> COL_ProductName Or (j + iFirstColunm) <> COL_StageName Or (j + iFirstColunm) <> COL_EmployeeName Or (j + iFirstColunm) <> COL_DepartmentID Or (j + iFirstColunm) <> COL_TeamID Then
                            tdbg(i + iPrevRow + 1, j + iFirstColunm) = oData(i, j)

                            'If j = iCopyCol Then
                            If (j + iFirstColunm) = COL_ProductID Then
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                            End If

                            If (j + iFirstColunm) = COL_StageID Then
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                            End If

                            If (j + iFirstColunm) = COL_RefEmployeeID Then
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 2) = oData(i, j + 2)
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 3) = oData(i, j + 3)
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 4) = oData(i, j + 4)
                            End If

                            If (j + iFirstColunm) = COL_EmployeeID Then
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 2) = oData(i, j + 2)
                                tdbg(i + iPrevRow + 1, j + iFirstColunm + 3) = oData(i, j + 3)
                            End If
                            'End If
                        End If
                    Next
                End If
            Next

            tdbg.UpdateData()
            bPressCopy = False
            iPrevRow = tdbg.RowCount - 1
        Else
            Dim liPrevRow As Integer = tdbg.Row - 1
            Dim iAddRows As Integer = tdbg.RowCount - tdbg.Row

            If iAddRows > 0 Then 'con trỏ đứng tại vị trí có dữ liệu
                If iCopyRows + 1 - iAddRows > 0 Then
                    For i = 0 To iCopyRows - iAddRows
                        tdbg.MoveLast()
                        tdbg.Row = tdbg.Row + 1
                        tdbg.Columns(COL_TransID).Text = ""
                    Next
                End If
            End If

            For i = 0 To iCopyRows
                If i + liPrevRow + 1 <= tdbg.RowCount - 1 Then
                    For j = 0 To iCopyCol

                        If (j + iFirstColunm) <> COL_ProductName Or (j + iFirstColunm) <> COL_StageName Or (j + iFirstColunm) <> COL_EmployeeName Or (j + iFirstColunm) <> COL_DepartmentID Or (j + iFirstColunm) <> COL_TeamID Then
                            tdbg(i + liPrevRow + 1, j + iFirstColunm) = oData(i, j)

                            'If j = iCopyCol Then
                            If (j + iFirstColunm) = COL_ProductID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                            End If

                            If (j + iFirstColunm) = COL_StageID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                            End If

                            If (j + iFirstColunm) = COL_RefEmployeeID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 2) = oData(i, j + 2)
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 3) = oData(i, j + 3)
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 4) = oData(i, j + 4)
                            End If

                            If (j + iFirstColunm) = COL_EmployeeID Then
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 1) = oData(i, j + 1)
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 2) = oData(i, j + 2)
                                tdbg(i + liPrevRow + 1, j + iFirstColunm + 3) = oData(i, j + 3)
                            End If
                            'End If
                        End If
                    Next
                End If
            Next

            iPrevRow = tdbg.RowCount - 1
        End If

    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlC
    '# Created User:
    '# Created Date:
    '# Modified User: 
    '# Modified Date: 
    '# Description: Copy từ dòng được chọn (dán vào vị trí con trỏ đang đứng)(da co di chuyen cot)
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlC_ColMove()
        Dim c1Rows As C1.Win.C1TrueDBGrid.SelectedRowCollection = tdbg.SelectedRows
        Dim c1Cols As C1.Win.C1TrueDBGrid.SelectedColumnCollection = tdbg.SelectedCols

        Dim i As Integer = 0, j As Integer = 0

        Dim bRefEmployeeID As Boolean = False
        Dim bCopyQuan As Boolean = False

        bCopyRef = False

        If c1Cols.Count < 1 Then
            sFirstCol = ""
            Exit Sub
        End If

        If c1Cols(0).DataField = "OrderNo" Or c1Cols(0).DataField = "ProductName" Or c1Cols(0).DataField = "StageName" Or c1Cols(0).DataField = "EmployeeName" Or c1Cols(0).DataField = "DepartmentID" Or c1Cols(0).DataField = "TeamID" Then
            Exit Sub
        End If

        'cot dau tien dc Copy
        sFirstCol = c1Cols(0).DataField

        Dim iAddCols As Integer = 0

        iColCheck = 0
        For j = 0 To c1Cols.Count - 1
            If c1Cols(j).DataField = "RefEmployeeID" Or c1Cols(j).DataField = "EmployeeID" Then
                If c1Cols(j).DataField = "RefEmployeeID" Then
                    iColCheck = iColCheck + 1
                    bCopyRef = True
                Else
                    iColCheck = iColCheck + 1
                    If iColCheck = 2 Then
                        bCopyRef = True
                    End If
                End If
            ElseIf c1Cols(j).DataField = "Quantity01" Or c1Cols(j).DataField = "Quantity02" Or c1Cols(j).DataField = "Quantity03" Or c1Cols(j).DataField = "Quantity04" Or c1Cols(j).DataField = "Quantity05" Then
                bCopyQuan = True
            End If
        Next

        Dim bChooseQuan As Boolean = True

        'Quet nhung cot dc copy
        For j = 0 To c1Cols.Count - 1
            If c1Cols(j).DataField = "ProductID" Then
                iAddCols += 1
                bChooseQuan = False
            End If

            If c1Cols(j).DataField = "StageID" Then
                iAddCols += 1
                bChooseQuan = False
            End If

            If c1Cols(j).DataField = "RefEmployeeID" Then
                If bRefEmployeeID = False Then
                    iAddCols += 4 'copy luon nhung cot lien quan
                    bRefEmployeeID = True
                    bChooseQuan = False
                End If
            End If

            If c1Cols(j).DataField = "EmployeeID" Then
                If bRefEmployeeID = False Then
                    If iColCheck = 2 Then
                        iAddCols += 4 'copy luon nhung cot lien quan
                    Else
                        iAddCols += 3 'copy luon nhung cot lien quan
                    End If
                    bRefEmployeeID = True
                    bChooseQuan = False
                End If
            End If

            If c1Cols(j).DataField = "EmployeeName" OrElse c1Cols(j).DataField = "DepartmentID" OrElse c1Cols(j).DataField = "TeamID" OrElse c1Cols(j).DataField = "ProductName" OrElse c1Cols(j).DataField = "StageName" Then
                iAddCols = iAddCols - 1
            End If


        Next

        If bCopyQuan Then 'chi chon nhung cot so luong or k chon 2 cot NV
            If bCopyRef And iColCheck = 2 Then
                ReDim oData(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols - 1)
                ReDim oField(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols - 1)
            Else
                ReDim oData(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)
                ReDim oField(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)
            End If
        Else
            If bCopyRef And iColCheck = 2 Then
                ReDim oData(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols - 1)
                ReDim oField(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)
            Else
                ReDim oData(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)
                ReDim oField(c1Rows.Count - 1, c1Cols.Count - 1 + iAddCols)
            End If
        End If

        Dim iColTemp As Integer

        iPrevRow = tdbg.RowCount - 1
        iCopyRows = c1Rows.Count - 1
        iCopyCol = c1Cols.Count - 1

        bRefEmployeeID = False

        For i = 0 To c1Rows.Count - 1
            iColTemp = 0
            bRefEmployeeID = False
            For j = 0 To c1Cols.Count - 1
                If c1Cols(j).DataField <> "ProductName" And c1Cols(j).DataField <> "StageName" And c1Cols(j).DataField <> "EmployeeName" And c1Cols(j).DataField <> "DepartmentID" And c1Cols(j).DataField <> "TeamID" Then
                    If iColCheck = 0 Then 'k chon ca 2 cot NV
                        oData(i, iColTemp) = CObj(tdbg(c1Rows(i), c1Cols(j).DataField))
                        oField(0, iColTemp) = c1Cols(j).DataField
                        iColTemp = iColTemp + 1

                        If c1Cols(j).DataField = "ProductID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "ProductName"))
                            oField(0, iColTemp) = "ProductName"
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "StageID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "StageName"))
                            oField(0, iColTemp) = "StageName"
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "RefEmployeeID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeID"))
                            oField(0, iColTemp) = "EmployeeID"
                            iColTemp = iColTemp + 1
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                            oField(0, iColTemp) = "EmployeeName"
                            iColTemp = iColTemp + 1
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                            oField(0, iColTemp) = "DepartmentID"
                            iColTemp = iColTemp + 1
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "TeamID"))
                            oField(0, iColTemp) = "TeamID"
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "EmployeeID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                            oField(0, iColTemp) = "EmployeeName"
                            iColTemp = iColTemp + 1
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                            oField(0, iColTemp) = "DepartmentID"
                            iColTemp = iColTemp + 1
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "TeamID"))
                            oField(0, iColTemp) = "TeamID"
                            iColTemp = iColTemp + 1
                        End If
                    Else 'chon 1 trong 2 cot EmployeeID va RefEmployeeID
                        If c1Cols(j).DataField = "EmployeeID" Or c1Cols(j).DataField = "RefEmployeeID" Then
                            If bRefEmployeeID = False Then
                                If iColCheck = 2 Then
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "RefEmployeeID"))
                                    oField(0, iColTemp) = "RefEmployeeID"
                                    iColTemp = iColTemp + 1
                                Else
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), c1Cols(j).DataField))
                                    oField(0, iColTemp) = c1Cols(j).DataField
                                    iColTemp = iColTemp + 1
                                End If
                            End If
                        Else
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), c1Cols(j).DataField))
                            oField(0, iColTemp) = c1Cols(j).DataField
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "ProductID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "ProductName"))
                            oField(0, iColTemp) = "ProductName"
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "StageID" Then
                            oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "StageName"))
                            oField(0, iColTemp) = "StageName"
                            iColTemp = iColTemp + 1
                        End If

                        If c1Cols(j).DataField = "RefEmployeeID" Then
                            If bRefEmployeeID = False Then
                                oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeID"))
                                oField(0, iColTemp) = "EmployeeID"
                                iColTemp = iColTemp + 1
                                oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                                oField(0, iColTemp) = "EmployeeName"
                                iColTemp = iColTemp + 1
                                oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                                oField(0, iColTemp) = "DepartmentID"
                                iColTemp = iColTemp + 1
                                oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "TeamID"))
                                oField(0, iColTemp) = "TeamID"
                                bRefEmployeeID = True
                                iColTemp = iColTemp + 1
                            End If
                        End If

                        If c1Cols(j).DataField = "EmployeeID" Then
                            If bRefEmployeeID = False Then
                                If iColCheck = 2 Then
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeID"))
                                    oField(0, iColTemp) = "EmployeeID"
                                    iColTemp = iColTemp + 1
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                                    oField(0, iColTemp) = "EmployeeName"
                                    iColTemp = iColTemp + 1
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                                    oField(0, iColTemp) = "DepartmentID"
                                    iColTemp = iColTemp + 1
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "TeamID"))
                                    oField(0, iColTemp) = "TeamID"
                                    bRefEmployeeID = True
                                    iColTemp = iColTemp + 1
                                Else
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "EmployeeName"))
                                    oField(0, iColTemp) = "EmployeeName"
                                    iColTemp = iColTemp + 1
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "DepartmentID"))
                                    oField(0, iColTemp) = "DepartmentID"
                                    iColTemp = iColTemp + 1
                                    oData(i, iColTemp) = CObj(tdbg(c1Rows(i), "TeamID"))
                                    oField(0, iColTemp) = "TeamID"
                                    bRefEmployeeID = True
                                    iColTemp = iColTemp + 1
                                End If
                            End If
                        End If

                    End If

                End If
            Next
        Next

    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: CtrlV
    '# Created User: 
    '# Created Date: 
    '# Modified User: 
    '# Modified Date: 
    '# Description: Past vào vị trí con trỏ đang đứng (từ những dòng copy trên)(da co di chuyen cot)
    '#---------------------------------------------------------------------------------------------------
    Private Sub CtrlV_ColMove(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim i As Integer = 0, j As Integer = 0
        Dim bRefEmployeeID As Boolean = False
        Dim iIndex As Integer = 0, k As Integer = 0
        Dim iRowCopy As Integer = 0

        If sFirstCol = "" Then Exit Sub
        iFirstColunm = ReturnCol(sFirstCol)

        If iColCheck = 2 And sFirstCol = "EmployeeID" Then
        Else
            If iCurrentCol <> iFirstColunm Then Exit Sub
        End If

        If iPrevRow <= tdbg.Row - 1 Then
            tdbg.MoveLast()
            For i = 0 To iCopyRows
                If tdbg.Row = tdbg.RowCount Then
                    tdbg.Row = tdbg.Row
                Else
                    tdbg.Row = tdbg.Row + 1
                End If

                tdbg.Columns(COL_TransID).Text = ""
            Next

            tdbg.UpdateData()

            iRowCopy = CInt(oData.Length / (iCopyRows + 1))
            For i = 0 To iCopyRows
                bRefEmployeeID = False
                If i + iPrevRow + 1 <= tdbg.RowCount - 1 Then

                    For j = 0 To iRowCopy - 1 'oData.Length - 1
                        If i = iCopyRows And j = 0 Then sLastProductID = oData(i, j).ToString

                        If oField(0, j).ToString <> "ProductName" Or oField(0, j).ToString <> "StageName" Or oField(0, j).ToString <> "EmployeeName" Or oField(0, j).ToString <> "DepartmentID" Or oField(0, j).ToString <> "TeamID" Then
                            If (iColCheck <> 2 And bCopyRef = False) Or iColCheck = 0 Then
                                tdbg(i + iPrevRow + 1, tdbg.Columns(oField(0, j).ToString).DataField) = oData(i, j)
                            Else
                                If oField(0, j).ToString = "RefEmployeeID" Or oField(0, j).ToString = "EmployeeID" Then
                                    If bRefEmployeeID = False Then
                                        tdbg(i + iPrevRow + 1, "RefEmployeeID") = oData(i, j)
                                    End If
                                Else
                                    tdbg(i + iPrevRow + 1, oField(0, j).ToString) = oData(i, j)
                                End If

                            End If

                            If oField(0, j).ToString = "ProductID" Then
                                tdbg(i + iPrevRow + 1, "ProductName") = oData(i, j + 1)
                            End If

                            If oField(0, j).ToString = "StageID" Then
                                tdbg(i + iPrevRow + 1, "StageName") = oData(i, j + 1)
                            End If

                            If oField(0, j).ToString = "RefEmployeeID" Then
                                If bRefEmployeeID = False Then
                                    tdbg(i + iPrevRow + 1, "EmployeeID") = oData(i, j + 1)
                                    tdbg(i + iPrevRow + 1, "EmployeeName") = oData(i, j + 2)
                                    tdbg(i + iPrevRow + 1, "DepartmentID") = oData(i, j + 3)
                                    tdbg(i + iPrevRow + 1, "TeamID") = oData(i, j + 4)
                                    bRefEmployeeID = True
                                End If

                            End If

                            If oField(0, j).ToString = "EmployeeID" Then
                                If iColCheck = 2 Then
                                    If bRefEmployeeID = False Then
                                        tdbg(i + iPrevRow + 1, "EmployeeID") = oData(i, j + 1)
                                        tdbg(i + iPrevRow + 1, "EmployeeName") = oData(i, j + 2)
                                        tdbg(i + iPrevRow + 1, "DepartmentID") = oData(i, j + 3)
                                        tdbg(i + iPrevRow + 1, "TeamID") = oData(i, j + 4)
                                        bRefEmployeeID = True
                                    End If
                                Else
                                    If bRefEmployeeID = False Then
                                        tdbg(i + iPrevRow + 1, "EmployeeName") = oData(i, j + 1)
                                        tdbg(i + iPrevRow + 1, "DepartmentID") = oData(i, j + 2)
                                        tdbg(i + iPrevRow + 1, "TeamID") = oData(i, j + 3)
                                        bRefEmployeeID = True
                                    End If

                                End If
                            End If
                        End If
                    Next
                End If
            Next

            tdbg.UpdateData()
            bPressCopy = False
            iPrevRow = tdbg.RowCount - 1
        Else
            Dim liPrevRow As Integer = tdbg.Row - 1
            Dim iAddRows As Integer = tdbg.RowCount - tdbg.Row

            If iAddRows > 0 Then 'con trỏ đứng tại vị trí có dữ liệu
                If iCopyRows + 1 - iAddRows > 0 Then
                    For i = 0 To iCopyRows - iAddRows
                        tdbg.MoveLast()
                        tdbg.Row = tdbg.Row + 1
                        tdbg.Columns(COL_TransID).Text = ""
                    Next
                End If
            End If

            For i = 0 To iCopyRows
                bRefEmployeeID = False
                If i + liPrevRow + 1 <= tdbg.RowCount - 1 Then
                    For j = 0 To iCopyCol 'oData.Length - 1
                        If oField(0, j).ToString <> "ProductName" And oField(0, j).ToString <> "StageName" And oField(0, j).ToString <> "EmployeeName" And oField(0, j).ToString <> "DepartmentID" And oField(0, j).ToString <> "TeamID" Then
                            If iColCheck <> 2 And bCopyRef = False Then
                                tdbg(i + liPrevRow + 1, tdbg.Columns(oField(0, j).ToString).DataField) = oData(i, j)
                            Else
                                If oField(0, j).ToString = "RefEmployeeID" Or oField(0, j).ToString = "EmployeeID" Then
                                    If bRefEmployeeID = False Then
                                        tdbg(i + liPrevRow + 1, "RefEmployeeID") = oData(i, j)
                                    End If
                                Else
                                    tdbg(i + liPrevRow + 1, oField(0, j).ToString) = oData(i, j)
                                End If

                            End If

                            If oField(0, j).ToString = "ProductID" Then
                                tdbg(i + liPrevRow + 1, "ProductName") = oData(i, j + 1)
                            End If

                            If oField(0, j).ToString = "StageID" Then
                                tdbg(i + liPrevRow + 1, "StageName") = oData(i, j + 1)
                            End If

                            If oField(0, j).ToString = "RefEmployeeID" Then
                                If bRefEmployeeID = False Then
                                    tdbg(i + liPrevRow + 1, "EmployeeID") = oData(i, j + 1)
                                    tdbg(i + liPrevRow + 1, "EmployeeName") = oData(i, j + 2)
                                    tdbg(i + liPrevRow + 1, "DepartmentID") = oData(i, j + 3)
                                    tdbg(i + liPrevRow + 1, "TeamID") = oData(i, j + 4)
                                    bRefEmployeeID = True
                                End If

                            End If

                            If oField(0, j).ToString = "EmployeeID" Then
                                If iColCheck = 2 Then
                                    If bRefEmployeeID = False Then
                                        tdbg(i + liPrevRow + 1, "EmployeeID") = oData(i, j + 1)
                                        tdbg(i + liPrevRow + 1, "EmployeeName") = oData(i, j + 2)
                                        tdbg(i + liPrevRow + 1, "DepartmentID") = oData(i, j + 3)
                                        tdbg(i + liPrevRow + 1, "TeamID") = oData(i, j + 4)
                                        bRefEmployeeID = True
                                    End If
                                Else
                                    If bRefEmployeeID = False Then
                                        tdbg(i + liPrevRow + 1, "EmployeeName") = oData(i, j + 1)
                                        tdbg(i + liPrevRow + 1, "DepartmentID") = oData(i, j + 2)
                                        tdbg(i + liPrevRow + 1, "TeamID") = oData(i, j + 3)
                                        bRefEmployeeID = True
                                    End If

                                End If
                            End If
                        End If
                    Next
                End If
            Next

            iPrevRow = tdbg.RowCount - 1
        End If

    End Sub

    'Thoại: copy
    Private Function ReturnCol(ByVal sDataField As String) As Integer
        For i As Integer = 0 To tdbg.Columns.Count - 1
            If iColCheck <> 2 Then
                If tdbg.Columns(i).DataField = sDataField Then
                    Return i
                End If
            Else
                If sDataField = "EmployeeID" Then
                    If tdbg.Columns(i).DataField = "RefEmployeeID" Then
                        Return i
                    End If
                Else
                    If tdbg.Columns(i).DataField = sDataField Then
                        Return i
                    End If
                End If
            End If

        Next

        Return -1
    End Function

    Private Sub DeleteMultiRows(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If Not c1Grid.AllowDelete Or c1Grid.RowCount < 1 Then Exit Sub
            If D99C0008.MsgAskDeleteRow() = Windows.Forms.DialogResult.Yes Then
                Dim tdbgSelectedRow As C1.Win.C1TrueDBGrid.SelectedRowCollection = c1Grid.SelectedRows
                Dim i As Integer
                Dim myAL As New ArrayList() 'Tạo mảng lưu lại chỉ số vừa chọn 
                If tdbgSelectedRow.Count > 1 Then
                    For i = 0 To tdbgSelectedRow.Count - 1
                        myAL.Add(tdbgSelectedRow.Item(i))
                    Next
                    myAL.Sort() 'Sắp xếp tăng dần 
                    For i = myAL.Count - 1 To 0 Step -1
                        c1Grid.Delete(CInt(myAL.Item(i)))
                    Next
                Else
                    c1Grid.Delete(c1Grid.Bookmark)
                End If
            Else
                e.Handled = True
            End If
        Catch ex As Exception
            D99C0008.Msg("Lỗi DeleteMultiRows: " & ex.Message)
        End Try
    End Sub
  
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case CInt(IIf(bColMove = False, tdbg.Col, arrayIndex(tdbg.Col)).ToString)
            Case COL_Quantity01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Quantity05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        If D45Options.AutoCopyValue And tdbg.RowCount <> 0 And bFlagNewRow Then 'And bFlagNewRow Nếu tùy chọn có quyền copy', và là cột cuối
            If tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
                ' bFlagShiftInsert And tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent And
                bFlagNewRow = False

                tdbg.Columns(COL_ProductID).Text = tdbg(tdbg.Row - 1, COL_ProductID).ToString
                tdbg.Columns(COL_ProductName).Text = tdbg(tdbg.Row - 1, COL_ProductName).ToString
                tdbg.Columns(COL_StageID).Text = tdbg(tdbg.Row - 1, COL_StageID).ToString
                tdbg.Columns(COL_StageName).Text = tdbg(tdbg.Row - 1, COL_StageName).ToString

                tdbg.Columns(COL_OrderNo).Text = tdbg.RowCount.ToString

                tdbg.Columns(COL_ProductName).FooterText = tdbg.RowCount.ToString

            ElseIf tdbg.Columns(COL_ProductID).Text = "" And tdbg.Columns(COL_StageID).Text = "" And tdbg.Columns(COL_RefEmployeeID).Text = "" Then
                tdbg.Columns(COL_ProductID).Text = tdbg(tdbg.Row - 1, COL_ProductID).ToString
                tdbg.Columns(COL_ProductName).Text = tdbg(tdbg.Row - 1, COL_ProductName).ToString
                tdbg.Columns(COL_StageID).Text = tdbg(tdbg.Row - 1, COL_StageID).ToString
                tdbg.Columns(COL_StageName).Text = tdbg(tdbg.Row - 1, COL_StageName).ToString
            End If
        End If
        Select Case tdbg.Col
            Case COL_Attachment
                 If tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
                    tdbg.Splits(SPLIT0).DisplayColumns(COL_Attachment).Button = False
                Else
                    tdbg.Splits(SPLIT0).DisplayColumns(COL_Attachment).Button = True
                End If
        End Select
    End Sub

    Private Sub btnHotKey_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHotKey.Click
        Dim f As New D45F7777
        f.FormID="D45F2003"
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Dim frm As New D45F4000
        'With frm
        '    .FormActive = D45E0340Form.D45F4000
        '    .FormPermission = "D45F4000"
        '    .DepartmentID = _departmentID
        '    .TeamID = _teamID
        '    .EmployeeID = _employeeID
        '    .ProductVoucherNo = _productVoucherID
        '    .FromDate = _fromDate
        '    .ToDate = _toDate
        '    frm.ShowDialog()
        '    frm.Dispose()
        'End With

        Dim arrPro() As StructureProperties = Nothing
        'SetProperties(arrPro, "FormActive", "D45F4000")
        'SetProperties(arrPro, "FormIDPermission", "D45F4000")
        SetProperties(arrPro, "DepartmentID", _departmentID)
        SetProperties(arrPro, "TeamID", _teamID)
        SetProperties(arrPro, "EmployeeID", _employeeID)
        SetProperties(arrPro, "ProductVoucherNo", _productVoucherID)
        SetProperties(arrPro, "FromDate", _fromDate)
        SetProperties(arrPro, "ToDate", _toDate)
        CallFormShow(Me, "D45D0340", "D45F4000", arrPro)
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then
            bClosed = False
            Exit Sub
        Else
            bClosed = True
        End If

        Dim sSQL As New StringBuilder("")
        Dim bRunSQL As Boolean = True
        btnSave.Enabled = False
        btnClose.Enabled = False

        'mo ket noi
        'conn.Close()
        'conn.Open()
        'trans = conn.BeginTransaction

        Me.Cursor = Cursors.WaitCursor

        sRet = SQLInsertD45T2001s()
       
        If sRet.ToString = "-1" Then ' Thực thi không thành công
            trans.Rollback()
            SaveNotOK()
            bSaveOK = False
            btnClose.Enabled = True
            btnSave.Enabled = True
        Else ' Thực thi thành công
            trans.Commit()
            SaveOK()
            bSaveOK = True
            btnClose.Enabled = True
            btnClose.Focus()
            btnSave.Enabled = True
            ' If gbUseAudit Then
            'RunAuditLog(AuditCodeDetailPiecework, "02", txtVoucherDate.Text, txtProductVoucherNo.Text, txtNote.Text)
            Lemon3.D91.RunAuditLog("45", AuditCodeDetailPiecework, "02", txtVoucherDate.Text, txtProductVoucherNo.Text, txtNote.Text)
            'End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function SQLInsertD45T2001s() As StringBuilder
        Dim i As Integer

        Dim iCount As Integer = 0 'Đếm số dòng Insert

        Dim sSQL As New StringBuilder("")

        Dim sTransID As String = ""
        Dim iCountIGE As Integer = 0

        For i = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        'Sinh IGE cho TransID
        For i = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                sTransID = CreateIGEs("D45T2001", "TransID", "45", "DT", gsStringKey, sTransID, iCountIGE)
                tdbg(i, COL_TransID) = sTransID
            End If
        Next

        'mo ket noi
        conn.Close()
        conn.Open()
        trans = conn.BeginTransaction

        sRet.Remove(0, sRet.Length)
        sRet.Append(SQLDeleteD45T2001() & vbCrLf)

        For i = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_ProductID).ToString = "" And tdbg(i, COL_StageID).ToString = "" And tdbg(i, COL_RefEmployeeID).ToString = "" Then Continue For
            sSQL.Append("Insert Into D45T2001(")
            sSQL.Append("TransID,DivisionID, TranMonth, TranYear, ProductVoucherID, PayrollVoucherID, ")
            sSQL.Append("DepartmentID, TeamID, EmployeeID, ProductID, StageID, IsLocked,")
            sSQL.Append("Quantity01, Quantity02, Quantity03, Quantity04, Quantity05, ")
            sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, OrderNo")
            sSQL.Append(") Values(")
            '*************************
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
            sSQL.Append(SQLString(_productVoucherID) & COMMA) 'ProductVoucherID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_payrollVoucherID) & COMMA) 'PayrollVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_EmployeeID)) & COMMA) 'EmployeeID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ProductID)) & COMMA) 'ProductID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_StageID)) & COMMA) 'StageID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_IsLocked)) & COMMA)
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity01)) & COMMA) 'Quantity01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity02)) & COMMA) 'Quantity02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity03)) & COMMA) 'Quantity03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity04)) & COMMA) 'Quantity04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_Quantity05)) & COMMA) 'Quantity05, decimal, NOT NULL
            If tdbg(i, COL_CreateUserID).ToString = "" Then
                sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            Else
                sSQL.Append(SQLString(tdbg(i, COL_CreateUserID)) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            End If
            If tdbg(i, COL_CreateDate).ToString = "" Then
                sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            Else
                sSQL.Append(SQLDateTimeSave(tdbg(i, COL_CreateDate)) & COMMA) 'CreateDate, datetime, NULL
            End If

            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_OrderNo))) 'OrderNo, int, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)

            iCount += 1

            If iCount = 100 OrElse (i = tdbg.RowCount - 1) Then
                bRunExcute = ExecuteSQL1(sRet.ToString)
                iCount = 0
                sRet.Remove(0, sRet.Length)
                If bRunExcute = False Then 'thuc thi k thanh cong
                    sRet.Append("-1")
                    Return sRet
                End If

            End If
        Next

        Return sRet
    End Function

    Private Sub btnAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
        '************************
        If Not bLoadFormChild Then vcNewTemp = vcNew
        bLoadFormChild = True
        If usrOption.Visible Then usrOption.Hide()
        '************************
        Dim frm As New D45F2006
        With frm
            .FormState = _FormState
            .ProductVoucherID = _productVoucherID
            .PayrollVoucherID = _payrollVoucherID
            .TransTypeID = _transTypeID
            .EmployeeID = "%"
            .SalaryVoucherID = ""
            .Mode = 0
            .ShowDialog()
            .Dispose()
        End With
        If frm.bSaved Then LoadTDBGrid()
    End Sub

    'Bổ sung ngày 08/05/2008 Copy mã công đoạn nhưng ko copy Mã sản phẩm
    Private Sub CopyColumnsStageID(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal ColumnCount As Integer, ByVal sValue As String)
        Dim i, j As Integer
        Try
            If c1Grid.RowCount < 2 Then Exit Sub

            If ColumnCount = 1 Then ' Copy trong 1 cot
                CopyColumns(c1Grid, ColCopy, sValue, RowCopy)
            ElseIf ColumnCount > 1 Then ' Copy nhieu cot lien quan
                c1Grid.UpdateData()
                sValue = c1Grid(RowCopy, ColCopy).ToString

                Dim Flag As DialogResult
                'Flag = D99C0008.MsgCopyColumn()

                Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                            c1Grid(i, ColCopy) = sValue
                            While j < ColumnCount
                                c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                                TestStageIDCopyColumn(i)
                                j += 1
                            End While
                        End If
                    Next
                ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy hết
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        c1Grid(i, ColCopy) = sValue
                        While j < ColumnCount
                            c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                            TestStageIDCopyColumn(i)
                            j += 1
                        End While
                    Next
                    'c1Grid(0, ColCopy) = sValue
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TestStageIDCopyColumn(ByVal RowCopy As Integer)
        LoadtdbdStageID(tdbg(RowCopy, COL_ProductID).ToString)
        Dim dt As DataTable = dtStage.Copy
        dt.DefaultView.RowFilter = "StageID=" & SQLString(tdbg(RowCopy, COL_StageID).ToString)
        If dt.DefaultView.Count = 0 Then 'không tồn tại
            tdbg(RowCopy, COL_StageID) = ""
            tdbg(RowCopy, COL_StageName) = ""
        End If
    End Sub

    Private Function ExecuteSQL1(ByVal strSQL As String) As Boolean
        If Trim(strSQL) = "" Then Exit Function

        'Update 18/10/2010: Chỉ kiểm tra cho trường hợp nhập liệu Unicode
        'Khi Lưu xuống database nếu chiều dài dữ liệu vượt quá giới hạn cho phép thì không thông báo
        If gbUnicode Then strSQL = "SET ANSI_WARNINGS OFF " & vbCrLf & strSQL

        Dim cmd As New SqlCommand(strSQL, conn)

        If giAppMode = 0 Then

            Try
                cmd.CommandTimeout = 0
                cmd.Transaction = trans
                cmd.ExecuteNonQuery()

                Return True
            Catch
                Clipboard.Clear()
                Clipboard.SetText(strSQL)
                'MsgErr("Error when execute SQL in function ExecuteSQL(). Paste your SQL code from Clipboard")
                MessageBox.Show("Error when execute SQL in function ExecuteSQL(). Paste your SQL code from Clipboard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                WriteLogFile1(strSQL)
                Return False
            End Try

        Else
            'Dùng D99D0041 mới
            Dim bCaLlWS As Boolean = False
            bCaLlWS = CallWebService.ExcuteSQLQuery(strSQL, gsCompanyID, gsUserID, True, gsWSSPara01, gsWSSPara02, gsWSSPara03, gsWSSPara04, gsWSSPara05)
            If Not bCaLlWS Then
                MsgErr(CallWebService.ResultError)
                WriteLogFile1(strSQL)
            End If
            Return bCaLlWS
        End If
    End Function

    Public Sub WriteLogFile1(ByVal Text As String)
        Dim sLog As String = ""
        Dim sFileName As String = gsApplicationPath & "\Log.log"
        If (My.Computer.FileSystem.FileExists(sFileName) = False) Then My.Computer.FileSystem.WriteAllText(sFileName, "", True)
        Dim lFileSize As Long = My.Computer.FileSystem.GetFileInfo(sFileName).Length
        If lFileSize > 10 * 1028 * 1028 Then My.Computer.FileSystem.DeleteFile(sFileName, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
        sLog &= Space(20) & Now & vbCrLf
        sLog &= Text & vbCrLf
        sLog &= "--------------------------------------------------------------------------" & vbCrLf
        My.Computer.FileSystem.WriteAllText(sFileName, sLog, True)
    End Sub

    Private Function CreateIGEs(ByVal Table As String, ByVal Field As String, ByVal Key1 As String, ByVal Key2 As String, ByVal Key3 As String, ByVal OldIGE As String, ByVal NumberIGE As Integer) As String
        Dim ret As String = ""
        Dim TempKey As Boolean = True

        If OldIGE = "" Then
            Dim lLastKey As Integer = 0
            ret = IGEKeyPrimary(Table, Field, Key1, Key2, Key3, lLastKey, NumberIGE, OutOrderEnum.lmSSSN, 15, "")
            Return ret

        Else
            Dim iLength As Integer = Key1.Length + Key2.Length + Key3.Length
            Dim iNo As Long = Convert.ToInt32(OldIGE.Substring(iLength)) + 1
            ret = Key1 & Key2 & Key3 & iNo.ToString(Strings.StrDup(15 - iLength, "0"))
            Return ret
        End If

    End Function

    Private Function IGEKeyPrimary(ByVal sTableName As String, _
                                                            ByVal sFieldID As String, _
                                                            ByVal sStringKey1 As String, _
                                                            ByVal sStringKey2 As String, _
                                                            ByVal sStringKey3 As String, _
                                                            ByRef nOutLastKey As Integer, _
                                                            Optional ByVal nRowIGE As Integer = 1, _
                                                            Optional ByVal nOutputOrder As OutOrderEnum = OutOrderEnum.lmSSSN, _
                                                            Optional ByVal nOutputLength As Integer = 15, _
                                                            Optional ByVal sSeperatorCharacter As String = "") As String


        Dim sIGEKeyPrimary As String = ""

        Try
            Dim bKey As Boolean
            Dim KeyString As String

            bKey = False

            KeyString = sStringKey1 & sStringKey2 & sStringKey3

            Dim LastKey As Integer
            Do
                'Lấy LastKey
                LastKey = GetLastKey(KeyString, sTableName)
                '-----------------------------------------------------------
                'Kiem tra chieu dai và lấy chuỗi string của Lastkey
                Dim LastKeyString As String
                LastKeyString = CheckLengthKey(LastKey, sStringKey1, sStringKey2, sStringKey3, sSeperatorCharacter, nOutputLength)
                If LastKeyString <> "" Then
                    'Hop le thi sinh IGE
                    sIGEKeyPrimary = Generate(sStringKey1, sStringKey2, sStringKey3, nOutputOrder, sSeperatorCharacter, LastKeyString)
                End If

                If sIGEKeyPrimary = "" Then
                    If LastKeyString <> "" Then
                        D99C0008.MsgL3("Lỗi sinh mã tự động cho khóa chính", L3MessageBoxIcon.Err)
                        WriteLogFile1("Loi sinh IGE cua table " & sTableName)
                    Else
                        WriteLogFile1("Loi sinh IGE (Chieu dai qua gioi han) cua table " & sTableName)
                    End If
                    Return ""
                End If

                'Luu Last key
                SaveLastKey(sTableName, KeyString, LastKey - 1 + nRowIGE)

                'Kiem tra trung khoa
                Dim sKeyFrom As String, sKeyTo As String
                Dim intZeroLen As Integer
                Dim StringLastKey As String
                Dim nNewLastKey As Long

                sKeyFrom = sIGEKeyPrimary
                If nRowIGE = 1 Then
                    sKeyTo = sKeyFrom
                Else
                    nNewLastKey = (LastKey - 1) + nRowIGE
                    intZeroLen = CType(nOutputLength, Integer) - nNewLastKey.ToString.Length - (sStringKey1.Length + sStringKey2.Length + sStringKey3.Length)
                    '----------------------------
                    If sSeperatorCharacter <> "" Then
                        If sStringKey1 <> "" Then intZeroLen = intZeroLen - 1
                        If sStringKey2 <> "" Then intZeroLen = intZeroLen - 1
                        If sStringKey3 <> "" Then intZeroLen = intZeroLen - 1
                    End If

                    If intZeroLen < 0 Then
                        AnnouncementLength()
                        Return ""
                    Else
                        StringLastKey = Strings.StrDup(intZeroLen, "0") & nNewLastKey
                    End If
                    '----------------------------

                    Select Case nOutputOrder
                        Case OutOrderEnum.lmNSSS
                            sKeyTo = StringLastKey & sStringKey1 & sStringKey2 & sStringKey3
                        Case OutOrderEnum.lmSNSS
                            sKeyTo = sStringKey1 & StringLastKey & sStringKey2 & sStringKey3
                        Case OutOrderEnum.lmSSNS
                            sKeyTo = sStringKey1 & sStringKey2 & StringLastKey & sStringKey3
                        Case Else
                            sKeyTo = sStringKey1 & sStringKey2 & sStringKey3 & StringLastKey
                    End Select
                End If

                bKey = CheckDupKeyPrimary(sTableName, sFieldID, sKeyFrom, sKeyTo)

                'Hop le thi lay du lieu va thoat
                If Not bKey Then
                    nOutLastKey = LastKey
                    Return sIGEKeyPrimary
                End If

            Loop Until bKey = False

            Return ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return ""
        End Try

    End Function

    Private Function GetLastKey(Optional ByVal sStringCreateKey As String = "", Optional ByVal sTable As String = "D91T0001") As Integer
        'Kiểm tra bảng D91T0000
        'Nếu tìm thấy then lấy LastKey
        'Nếu không tìm thấy thì insert 1 dòng mới vào


        Dim sSQL As String
        sSQL = "SELECT LastKey FROM D91T0000 WHERE TableName ='" & sTable & "'" _
          & " AND KeyString = '" & sStringCreateKey & "'"
        Dim sLastKey As String
        sLastKey = ReturnScalar(sSQL)

        If sLastKey <> "" Then ' có dữ liệu
            Return CInt(sLastKey) + 1
        Else ' Không có dữ liệu
            sSQL = "INSERT INTO D91T0000 VALUES ('" & sTable & "', '" & sStringCreateKey & "',0)"
            ExecuteSQLNoTransaction(sSQL)
            Return 1
        End If

    End Function

    Private Function CheckLengthKey(ByVal nLastKey As Integer, ByVal sStringKey1 As String, ByVal sStringKey2 As String, ByVal sStringKey3 As String, ByVal sSeperatorCharacter As String, ByVal nOutputLength As Integer) As String
        Dim nKeyLength As Integer = 0
        If sSeperatorCharacter <> "" Then
            If sStringKey1 <> "" Then
                nKeyLength = nKeyLength + sStringKey1.Length + sSeperatorCharacter.Length
            End If
            If sStringKey2 <> "" Then
                nKeyLength = nKeyLength + sStringKey2.Length + sSeperatorCharacter.Length
            End If
            If sStringKey3 <> "" Then
                nKeyLength = nKeyLength + sStringKey3.Length + sSeperatorCharacter.Length
            End If
        Else
            If sStringKey1 <> "" Then nKeyLength = nKeyLength + sStringKey1.Length
            If sStringKey2 <> "" Then nKeyLength = nKeyLength + sStringKey2.Length
            If sStringKey3 <> "" Then nKeyLength = nKeyLength + sStringKey3.Length
        End If

        If (nKeyLength + nLastKey.ToString.Length) > nOutputLength Then
            AnnouncementLength()
            Return ""
        End If

        Dim nLastKeyLength As Integer = 0
        nLastKeyLength = Convert.ToInt32(nOutputLength) - nKeyLength - nLastKey.ToString.Length
        'LastKeyString = Strings.StrDup(nLastKeyLength, "0") & nLastKey
        Return Strings.StrDup(nLastKeyLength, "0") & nLastKey

    End Function

    Private Sub AnnouncementLength()
        If geLanguage = EnumLanguage.Vietnamese Then
            D99C0008.MsgL3("Chiều dài thiết lập vượt quá giới hạn cho phép." & vbCrLf & "Bạn phải thiết lập lại.", L3MessageBoxIcon.Exclamation)
        Else
            D99C0008.MsgL3("The lenght setup is off limits." & vbCrLf & "You should set again.", L3MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Function Generate(ByVal sS1 As String, ByVal sS2 As String, ByVal sS3 As String, ByVal sOrder As OutOrderEnum, ByVal sCharacter As String, ByVal sLastKeyString As String) As String
        Dim strIDKey As String = ""
        Dim strIncrement As String

        strIncrement = sLastKeyString

        If strIncrement = "" Then Return ""

        Select Case sOrder
            Case OutOrderEnum.lmSSSN
                strIDKey = ConcatenateKeys(sS1, sS2, sS3, strIncrement, sCharacter)
            Case OutOrderEnum.lmSSNS
                strIDKey = ConcatenateKeys(sS1, sS2, strIncrement, sS3, sCharacter)
            Case OutOrderEnum.lmSNSS
                strIDKey = ConcatenateKeys(sS1, strIncrement, sS2, sS3, sCharacter)
            Case OutOrderEnum.lmNSSS
                strIDKey = ConcatenateKeys(strIncrement, sS1, sS2, sS3, sCharacter)
        End Select

        Return strIDKey

    End Function

    Private Function ConcatenateKeys(ByVal Key1 As String, ByVal Key2 As String, ByVal Key3 As String, ByVal Key4 As String, ByVal sCharacter As String) As String

        Dim sKey1 As String, sKey2 As String, sKey3 As String, sKey4 As String
        sKey1 = Key1 : sKey2 = Key2 : sKey3 = Key3 : sKey4 = Key4

        If sCharacter <> "" Then 'Có dấu
            If sKey1 <> "" Then sKey1 = sKey1 & sCharacter
            If sKey2 <> "" Then sKey2 = sKey2 & sCharacter
            If sKey3 <> "" Then sKey3 = sKey3 & sCharacter
            If sKey4 <> "" Then sKey4 = sKey4 & sCharacter
        End If

        ConcatenateKeys = sKey1 & sKey2 & sKey3 & sKey4

        If sCharacter <> "" Then
            Return Microsoft.VisualBasic.Left(ConcatenateKeys, Len(ConcatenateKeys) - Len(sCharacter))
        Else
            Return ConcatenateKeys
        End If

    End Function

    Private Sub SaveLastKey(ByVal sTable As String, ByVal sString As String, ByVal nLastKey As Long)
        Dim strSQL As String
        strSQL = "UPDATE D91T0000 Set LastKey =" & nLastKey _
        & " WHERE TableName = '" & sTable & "' AND KeyString = '" & sString & "'"

        ExecuteSQLNoTransaction(strSQL)
    End Sub

    Private Function CheckDupKeyPrimary(ByVal Table_Name As String, ByVal Field_Name As String, ByVal Field_Values1 As String, ByVal Field_Values2 As String) As Boolean
        Dim sSQL As String
        sSQL = "Select Top 1 1 From " & Table_Name & " " & vbCrLf
        sSQL = sSQL & "Where " & Field_Name & " Between '" & Field_Values1 & "' And '" & Field_Values2 & "'"

        Return ExistRecord(sSQL)
    End Function

    Private Sub btnShowOption_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowOption.Click
        If bLoadFormChild Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadFormChild = False
        End If

        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowOption.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub
End Class