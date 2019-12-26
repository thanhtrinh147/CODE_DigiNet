Public Class D45F2016

    Private dtGrid As DataTable
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private sFind As String = ""
    Dim arrayIndex(col_Total - 1) As Integer 'mang luu giu gtri index sau khi doi cot
    Dim bColMove As Boolean

#Region "Const of tdbg - Total of Columns: 80"
    Private Const COL_OrderNo As Integer = 0           ' STT
    Private Const COL_PieceworkGroupID As Integer = 1  ' Nhóm chấm công
    Private Const COL_EmployeeID As Integer = 2        ' Mã nhân viên
    Private Const COL_RefEmployeeID As Integer = 3     ' Mã nhân viên phụ
    Private Const COL_FirstName As Integer = 4         ' Tên nhân viên
    Private Const COL_EmployeeName As Integer = 5      ' Họ và tên
    Private Const COL_DepartmentID As Integer = 6      ' Mã phòng ban
    Private Const COL_DepartmentName As Integer = 7    ' Tên phòng ban
    Private Const COL_TeamID As Integer = 8            ' Mã tổ nhóm
    Private Const COL_TeamName As Integer = 9          ' Tên tổ nhóm
    Private Const COL_ProductID As Integer = 10        ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 11      ' Tên sản phẩm
    Private Const COL_TypeC01 As Integer = 12          ' Loại điều kiện 01
    Private Const COL_TypeC02 As Integer = 13          ' Loại điều kiện 02
    Private Const COL_TypeC03 As Integer = 14          ' Loại điều kiện 03
    Private Const COL_TypeC04 As Integer = 15          ' Loại điều kiện 04
    Private Const COL_TypeC05 As Integer = 16          ' Loại điều kiện 05
    Private Const COL_TypeC06 As Integer = 17          ' Loại điều kiện 06
    Private Const COL_TypeC07 As Integer = 18          ' Loại điều kiện 07
    Private Const COL_TypeC08 As Integer = 19          ' Loại điều kiện 08
    Private Const COL_TypeC09 As Integer = 20          ' Loại điều kiện 09
    Private Const COL_TypeC10 As Integer = 21          ' Loại điều kiện 10
    Private Const COL_TypeC11 As Integer = 22          ' Loại điều kiện 11
    Private Const COL_TypeC12 As Integer = 23          ' Loại điều kiện 12
    Private Const COL_TypeC13 As Integer = 24          ' Loại điều kiện 13
    Private Const COL_TypeC14 As Integer = 25          ' Loại điều kiện 14
    Private Const COL_TypeC15 As Integer = 26          ' Loại điều kiện 15
    Private Const COL_TypeC16 As Integer = 27          ' Loại điều kiện 16
    Private Const COL_TypeC17 As Integer = 28          ' Loại điều kiện 17
    Private Const COL_TypeC18 As Integer = 29          ' Loại điều kiện 18
    Private Const COL_TypeC19 As Integer = 30          ' Loại điều kiện 19
    Private Const COL_TypeC20 As Integer = 31          ' Loại điều kiện 20
    Private Const COL_TypeC21 As Integer = 32          ' Loại điều kiện 21
    Private Const COL_TypeC22 As Integer = 33          ' Loại điều kiện 22
    Private Const COL_TypeC23 As Integer = 34          ' Loại điều kiện 23
    Private Const COL_TypeC24 As Integer = 35          ' Loại điều kiện 24
    Private Const COL_TypeC25 As Integer = 36          ' Loại điều kiện 25
    Private Const COL_TypeC26 As Integer = 37          ' Loại điều kiện 26
    Private Const COL_TypeC27 As Integer = 38          ' Loại điều kiện 27
    Private Const COL_TypeC28 As Integer = 39          ' Loại điều kiện 28
    Private Const COL_TypeC29 As Integer = 40          ' Loại điều kiện 29
    Private Const COL_TypeC30 As Integer = 41          ' Loại điều kiện 30
    Private Const COL_TypeC31 As Integer = 42          ' Loại điều kiện 31
    Private Const COL_TypeC32 As Integer = 43          ' Loại điều kiện 32
    Private Const COL_TypeC33 As Integer = 44          ' Loại điều kiện 33
    Private Const COL_TypeC34 As Integer = 45          ' Loại điều kiện 34
    Private Const COL_TypeC35 As Integer = 46          ' Loại điều kiện 35
    Private Const COL_TypeC36 As Integer = 47          ' Loại điều kiện 36
    Private Const COL_TypeC37 As Integer = 48          ' Loại điều kiện 37
    Private Const COL_TypeC38 As Integer = 49          ' Loại điều kiện 38
    Private Const COL_TypeC39 As Integer = 50          ' Loại điều kiện 39
    Private Const COL_TypeC40 As Integer = 51          ' Loại điều kiện 40
    Private Const COL_Quantity01 As Integer = 52       ' Số lượng 01
    Private Const COL_Quantity02 As Integer = 53       ' Số lượng 02
    Private Const COL_Quantity03 As Integer = 54       ' Số lượng 03
    Private Const COL_Quantity04 As Integer = 55       ' Số lượng 04
    Private Const COL_Quantity05 As Integer = 56       ' Số lượng 05
    Private Const COL_Quantity06 As Integer = 57       ' Số lượng 06
    Private Const COL_Quantity07 As Integer = 58       ' Số lượng 07
    Private Const COL_Quantity08 As Integer = 59       ' Số lượng 08
    Private Const COL_Quantity09 As Integer = 60       ' Số lượng 09
    Private Const COL_Quantity10 As Integer = 61       ' Số lượng 10
    Private Const COL_Quantity11 As Integer = 62       ' Số lượng 11
    Private Const COL_Quantity12 As Integer = 63       ' Số lượng 12
    Private Const COL_Quantity13 As Integer = 64       ' Số lượng 13
    Private Const COL_Quantity14 As Integer = 65       ' Số lượng 14
    Private Const COL_Quantity15 As Integer = 66       ' Số lượng 15
    Private Const COL_Quantity16 As Integer = 67       ' Số lượng 16
    Private Const COL_Quantity17 As Integer = 68       ' Số lượng 17
    Private Const COL_Quantity18 As Integer = 69       ' Số lượng 18
    Private Const COL_Quantity19 As Integer = 70       ' Số lượng 19
    Private Const COL_Quantity20 As Integer = 71       ' Số lượng 20
    Private Const COL_Notes As Integer = 72            ' Ghi chú
    Private Const COL_Attachment As Integer = 73       ' Đính kèm
    Private Const COL_TransID As Integer = 74          ' TransID
    Private Const COL_CreateUserID As Integer = 75     ' CreateUserID
    Private Const COL_CreateDate As Integer = 76       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 77 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 78   ' LastModifyDate
    Private Const COL_Permission As Integer = 79       ' Permission
    Private Const col_Total As Integer = 80
#End Region

#Region "Truyền Biến"
    Private _productVoucherID As String = ""
    Public WriteOnly Property ProductVoucherID() As String
        Set(ByVal Value As String)
            _productVoucherID = Value  '45PV0Z000000951
        End Set
    End Property

    Private _productVoucherNo As String = ""
    Public WriteOnly Property ProductVoucherNo() As String
        Set(ByVal Value As String)
            _productVoucherNo = Value
        End Set
    End Property

    Private _voucherDate As String = ""
    Public WriteOnly Property VoucherDate() As String
        Set(ByVal Value As String)
            _voucherDate = Value        '29/11/2019 00:00:00
        End Set
    End Property

    Private _note As String = ""
    Public WriteOnly Property Note() As String
        Set(ByVal Value As String)
            _note = Value       '12121
        End Set
    End Property

    Private _payrollVoucherID As String = ""
    Public WriteOnly Property PayrollVoucherID() As String
        Set(ByVal Value As String)
            _payrollVoucherID = Value       'PSBGCHSLT201911
        End Set
    End Property

    Private _blockID As String = ""
    Public WriteOnly Property BlockID() As String
        Set(ByVal Value As String)
            _blockID = Value        '%
        End Set
    End Property

    Private _departmentID As String = ""
    Public WriteOnly Property DepartmentID() As String
        Set(ByVal Value As String)
            _departmentID = Value   '%
        End Set
    End Property

    Private _teamID As String = ""
    Public WriteOnly Property TeamID() As String
        Set(ByVal Value As String)
            _teamID = Value '%
        End Set
    End Property
    Private _transTypeID As String = ""
    Public WriteOnly Property TransTypeID() As String
        Set(ByVal Value As String)
            _transTypeID = Value '%
        End Set
    End Property
#End Region

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState = EnumFormState.FormEdit
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
            End Select
        End Set
    End Property

    Private Sub D45F2016_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        CheckFormD13T2605()
        LoadInfoGeneral()
        InputbyUnicode(Me, gbUnicode)
        LoadLanguage()
        LoadDefault()
        LoadTDBGrid()
        LoadTDBDropDown()


        tdbg_LockedColumns()
        SetBackColorObligatory()

        CallD09U1111_Button(True)
        ResetFooterGrid(tdbg)
        Me.Cursor = Cursors.Default
    End Sub
    Private arrMaster As New ArrayList
    Dim dtCaptionCols As DataTable
    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_ProductID}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
        End If

        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)

    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Chi_tiet_san_pham_tinh_luong_theo_dieu_kien") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Chi tiÕt s¶n phÈm tÛnh l§¥ng theo ¢iÒu kiÖn
        '================================================================ 
        lblConditionID.Text = rL3("Ma_dieu_kien") 'Mã điều kiện
        lblProductID.Text = rL3("Ma_san_pham") 'Mã sản phẩm
        lblCODE.Text = rL3("CRM_Ma_loai_dieu_kien") 'Mã loại điều kiện
        '================================================================ 
        btnHotKey.Text = rL3("_Phim_nong") '&Phím nóng
        btnAdjust.Text = rL3("_Dieu_chinh_phieu") '&Điều chỉnh phiếu
        btnShowOption.Text = "F12 ( " & rL3("Hien_thi") & " )" 'Hiển thị (F12)
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        chkTestDuplicate.Text = rL3("Kiem_tra_trung_ma") 'Kiểm tra trùng mã
        '================================================================ 
        grpVoucher.Text = rL3("Chung_tu") 'Chứng từ
        '================================================================ 
        '  tdbcConditionID.Columns("ConditionID").Caption = rL3("Ma") 'Mã
        '  tdbcConditionID.Columns("Description").Caption = rL3("Ten") 'Tên
        tdbcCODE.Columns("CODE").Caption = rL3("Ma") 'Mã
        tdbcCODE.Columns("ShortName").Caption = rL3("Ten") 'Tên
        tdbcProductID.Columns("ProductID").Caption = rL3("Ma") 'Mã 
        tdbcProductID.Columns("ProductName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_OrderNo).Caption = rL3("STT") 'STT
        tdbg.Columns(COL_PieceworkGroupID).Caption = rL3("Nhom_cham_cong") 'Nhóm chấm công
        tdbg.Columns(COL_EmployeeID).Caption = rL3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns(COL_RefEmployeeID).Caption = rL3("Ma_nhan_vien_phu") 'Mã nhân viên phụ
        tdbg.Columns(COL_FirstName).Caption = rL3("Ten_nhan_vien") 'Tên nhân viên
        tdbg.Columns(COL_EmployeeName).Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbg.Columns(COL_DepartmentID).Caption = rL3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns(COL_TeamID).Caption = rL3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns(COL_TeamName).Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns(COL_ProductID).Caption = rL3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns(COL_ProductName).Caption = rL3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns(COL_TypeC01).Caption = rL3("Loai_dieu_kien") & " 01" 'Loại điều kiện 01
        tdbg.Columns(COL_TypeC02).Caption = rL3("Loai_dieu_kien") & " 02" 'Loại điều kiện 02
        tdbg.Columns(COL_TypeC03).Caption = rL3("Loai_dieu_kien") & " 03" 'Loại điều kiện 03
        tdbg.Columns(COL_TypeC04).Caption = rL3("Loai_dieu_kien") & " 04" 'Loại điều kiện 04
        tdbg.Columns(COL_TypeC05).Caption = rL3("Loai_dieu_kien") & " 05" 'Loại điều kiện 05
        tdbg.Columns(COL_TypeC06).Caption = rL3("Loai_dieu_kien") & " 06" 'Loại điều kiện 06
        tdbg.Columns(COL_TypeC07).Caption = rL3("Loai_dieu_kien") & " 07" 'Loại điều kiện 07
        tdbg.Columns(COL_TypeC08).Caption = rL3("Loai_dieu_kien") & " 08" 'Loại điều kiện 08
        tdbg.Columns(COL_TypeC09).Caption = rL3("Loai_dieu_kien") & " 09" 'Loại điều kiện 09
        tdbg.Columns(COL_TypeC10).Caption = rL3("Loai_dieu_kien") & " 10" 'Loại điều kiện 10
        tdbg.Columns(COL_TypeC11).Caption = rL3("Loai_dieu_kien") & " 11" 'Loại điều kiện 11
        tdbg.Columns(COL_TypeC12).Caption = rL3("Loai_dieu_kien") & " 12" 'Loại điều kiện 12
        tdbg.Columns(COL_TypeC13).Caption = rL3("Loai_dieu_kien") & " 13" 'Loại điều kiện 13
        tdbg.Columns(COL_TypeC14).Caption = rL3("Loai_dieu_kien") & " 14" 'Loại điều kiện 14
        tdbg.Columns(COL_TypeC15).Caption = rL3("Loai_dieu_kien") & " 15" 'Loại điều kiện 15
        tdbg.Columns(COL_TypeC16).Caption = rL3("Loai_dieu_kien") & " 16" 'Loại điều kiện 16
        tdbg.Columns(COL_TypeC17).Caption = rL3("Loai_dieu_kien") & " 17" 'Loại điều kiện 17
        tdbg.Columns(COL_TypeC18).Caption = rL3("Loai_dieu_kien") & " 18" 'Loại điều kiện 18
        tdbg.Columns(COL_TypeC19).Caption = rL3("Loai_dieu_kien") & " 19" 'Loại điều kiện 19
        tdbg.Columns(COL_TypeC20).Caption = rL3("Loai_dieu_kien") & " 20" 'Loại điều kiện 20
        tdbg.Columns(COL_TypeC21).Caption = rL3("Loai_dieu_kien") & " 21" 'Loại điều kiện 21
        tdbg.Columns(COL_TypeC22).Caption = rL3("Loai_dieu_kien") & " 22" 'Loại điều kiện 22
        tdbg.Columns(COL_TypeC23).Caption = rL3("Loai_dieu_kien") & " 23" 'Loại điều kiện 23
        tdbg.Columns(COL_TypeC24).Caption = rL3("Loai_dieu_kien") & " 24" 'Loại điều kiện 24
        tdbg.Columns(COL_TypeC25).Caption = rL3("Loai_dieu_kien") & " 25" 'Loại điều kiện 25
        tdbg.Columns(COL_TypeC26).Caption = rL3("Loai_dieu_kien") & " 26" 'Loại điều kiện 26
        tdbg.Columns(COL_TypeC27).Caption = rL3("Loai_dieu_kien") & " 27" 'Loại điều kiện 27
        tdbg.Columns(COL_TypeC28).Caption = rL3("Loai_dieu_kien") & " 28" 'Loại điều kiện 28
        tdbg.Columns(COL_TypeC29).Caption = rL3("Loai_dieu_kien") & " 29" 'Loại điều kiện 29
        tdbg.Columns(COL_TypeC30).Caption = rL3("Loai_dieu_kien") & " 30" 'Loại điều kiện 30
        tdbg.Columns(COL_TypeC31).Caption = rL3("Loai_dieu_kien") & " 31" 'Loại điều kiện 31
        tdbg.Columns(COL_TypeC32).Caption = rL3("Loai_dieu_kien") & " 32" 'Loại điều kiện 32
        tdbg.Columns(COL_TypeC33).Caption = rL3("Loai_dieu_kien") & " 33" 'Loại điều kiện 33
        tdbg.Columns(COL_TypeC34).Caption = rL3("Loai_dieu_kien") & " 34" 'Loại điều kiện 34
        tdbg.Columns(COL_TypeC35).Caption = rL3("Loai_dieu_kien") & " 35" 'Loại điều kiện 35
        tdbg.Columns(COL_TypeC36).Caption = rL3("Loai_dieu_kien") & " 36" 'Loại điều kiện 36
        tdbg.Columns(COL_TypeC37).Caption = rL3("Loai_dieu_kien") & " 37" 'Loại điều kiện 37
        tdbg.Columns(COL_TypeC38).Caption = rL3("Loai_dieu_kien") & " 38" 'Loại điều kiện 38
        tdbg.Columns(COL_TypeC39).Caption = rL3("Loai_dieu_kien") & " 39" 'Loại điều kiện 39
        tdbg.Columns(COL_TypeC40).Caption = rL3("Loai_dieu_kien") & " 40" 'Loại điều kiện 40
        tdbg.Columns(COL_Quantity01).Caption = rL3("So_luong") & " 01" 'Số lượng 01
        tdbg.Columns(COL_Quantity02).Caption = rL3("So_luong") & " 02" 'Số lượng 02
        tdbg.Columns(COL_Quantity03).Caption = rL3("So_luong") & " 03" 'Số lượng 03
        tdbg.Columns(COL_Quantity04).Caption = rL3("So_luong") & " 04" 'Số lượng 04
        tdbg.Columns(COL_Quantity05).Caption = rL3("So_luong") & " 05" 'Số lượng 05
        tdbg.Columns(COL_Quantity06).Caption = rL3("So_luong") & " 06" 'Số lượng 06
        tdbg.Columns(COL_Quantity07).Caption = rL3("So_luong") & " 07" 'Số lượng 07
        tdbg.Columns(COL_Quantity08).Caption = rL3("So_luong") & " 08" 'Số lượng 08
        tdbg.Columns(COL_Quantity09).Caption = rL3("So_luong") & " 09" 'Số lượng 09
        tdbg.Columns(COL_Quantity10).Caption = rL3("So_luong") & " 10" 'Số lượng 10
        tdbg.Columns(COL_Quantity11).Caption = rL3("So_luong") & " 11" 'Số lượng 11
        tdbg.Columns(COL_Quantity12).Caption = rL3("So_luong") & " 12" 'Số lượng 12
        tdbg.Columns(COL_Quantity13).Caption = rL3("So_luong") & " 13" 'Số lượng 13
        tdbg.Columns(COL_Quantity14).Caption = rL3("So_luong") & " 14" 'Số lượng 14
        tdbg.Columns(COL_Quantity15).Caption = rL3("So_luong") & " 15" 'Số lượng 15
        tdbg.Columns(COL_Quantity16).Caption = rL3("So_luong") & " 16" 'Số lượng 16
        tdbg.Columns(COL_Quantity17).Caption = rL3("So_luong") & " 17" 'Số lượng 17
        tdbg.Columns(COL_Quantity18).Caption = rL3("So_luong") & " 18" 'Số lượng 18
        tdbg.Columns(COL_Quantity19).Caption = rL3("So_luong") & " 19" 'Số lượng 19
        tdbg.Columns(COL_Quantity20).Caption = rL3("So_luong") & " 20" 'Số lượng 20
        tdbg.Columns(COL_Notes).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_Attachment).Caption = rL3("Dinh_kem") 'Đính kèm
    End Sub

    Private Sub LoadDefault()
        btnHotKey.Enabled = ReturnPermission("D45F2000") >= 1
        btnAdjust.Enabled = ReturnPermission("D45F2000") >= 2
        btnShowOption.Enabled = ReturnPermission("D45F2000") >= 2

        tdbg_NumberFormat()
        'Do nguon caption Loai dieu kien
        LoadCaptionTypeC()
        'Do nguon du lieu Loai dieu kien
        MakeDropDownTypeC()
        'Do nguon caption So luong
        LoadCaptionQuantity()
    End Sub
    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_Quantity01).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity03).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity04).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity05).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity06).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity07).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity08).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity09).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity10).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity11).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity12).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity13).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity14).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity15).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity16).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity17).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity18).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity19).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity20).NumberFormat = DxxFormat.DefaultNumber2

    End Sub
    Private Sub LoadEdit()
        txtProductVoucherID.Text = _productVoucherID
        txtProductVoucherNo.Text = _productVoucherNo
        c1dateVoucherDate.Value = _voucherDate
        txtNote.Text = _note
        txtPayrollVoucherID.Text = _payrollVoucherID
    End Sub
    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ProductID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Dim dtConditionID As DataTable = ReturnDataTable(SQLStoreD45P1151("Do nguon cho Dropdown loại dieu kien", Me.Name))    
    Private Sub LoadTDBDropDown()
        Dim dt As DataTable
        'Dropdown nhóm chấm công
        LoadDataSource(tdbdPieceworkGroupID, SQLSelectD45T1050("Do nguon Dropdown nhom phan cong"))
        'Dropdown sản phẩm
        dt = ReturnDataTable(SQLSelectD45T1000("Do nguon Dropdown san pham"))
        LoadDataSource(tdbdProductID, dt.Copy)
        LoadDataSource(tdbcProductID, dt.Copy)
        'cbb mdk cbb3
        LoadDataSource(tdbcConditionID, dtConditionID)

        'Dropdown Mã nhân viên + Mã nhân viên phụ
        dt = ReturnDataTable(SQLSelectD45N6666("Do nguon Dropdown Ma nhan vien + Ma nhan vien phu", "D45F2000"))
        Dim dt1 As DataTable
        If _departmentID <> "%" Then
            If _teamID <> "%" Then
                dt1 = ReturnTableFilter(dt, "DepartmentID=" & SQLString(_departmentID) & " and TeamID=" & SQLString(_teamID))
            Else
                dt1 = ReturnTableFilter(dt, "DepartmentID=" & SQLString(_departmentID))
            End If

        Else
            dt1 = dt
        End If

        LoadDataSource(tdbdEmployeeID, dt1)
        LoadDataSource(tdbdRefEmployeeID, dt1)
        LoadDataSource(tdbdFirstName, dt1)
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = SQLStoreD45P4016("Do nguon cho luoi", Me.Name)
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0

        Dim dc As DataColumn = Nothing
        If dtGrid.Columns.Contains("Attachment") Then
            dc = dtGrid.Columns("Attachment")
        Else
            dc = dtGrid.Columns.Add("Attachment")
        End If
        For i As Integer = 0 To dtGrid.Rows.Count - 1
            dtGrid.Rows(i).Item("Attachment") = "(" & ReturnAttachmentNumber("D45T2001", dtGrid.Rows(i).Item("ProductID").ToString(), dtGrid.Rows(i).Item("EmployeeID").ToString(), txtProductVoucherID.Text) & ")"  'Đính kèm
        Next
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
       
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        'ResetGrid()
    End Sub

    Private Sub LoadCaptionTypeC()
        Dim dt As DataTable = ReturnDataTable(SQLSelectD45T0030("Do nguon ten cac cot loai dieu kien"))
        LoadDataSource(tdbcCODE, ReturnTableFilter(dt, "disabled = 1"))

        Dim j As Integer = 0 'dòng của table
        If dt.Rows.Count > 0 Then
            For i As Integer = COL_TypeC01 To COL_TypeC40
                tdbg.Splits(1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dt.Rows(j).Item("ShortName").ToString
                tdbg.Splits(1).DisplayColumns(i).Visible = L3Bool(IIf(dt.Rows(j).Item("Disabled").ToString = "1", 1, 0))
                'If tdbg.Splits(1).DisplayColumns(i).Visible Then iColQuantityLast = i 'Lấy cột cuối cùng của lưới
                j += 1
            Next
        End If
    End Sub

    Private Sub LoadCaptionQuantity()
        Dim dt As DataTable = ReturnDataTable(SQLSelectD45T0010("Do nguon ten cac cot so luong"))
        Dim j As Integer = 0 'dòng của table
        If dt.Rows.Count > 0 Then
            For i As Integer = COL_Quantity01 To COL_Quantity20
                tdbg.Splits(1).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dt.Rows(j).Item("ShortName").ToString
                tdbg.Splits(1).DisplayColumns(i).Visible = L3Bool(IIf(dt.Rows(j).Item("Disabled").ToString = "1", 0, 1))
                'If tdbg.Splits(1).DisplayColumns(i).Visible Then iColQuantityLast = i 'Lấy cột cuối cùng của lưới
                j += 1
            Next
        End If
    End Sub

    Private Sub MakeDropDownTypeC()
        'Dim dt As DataTable = ReturnDataTable(SQLStoreD45P1151("Do nguon cho Dropdown loại dieu kien", Me.Name))
        '  LoadDataSource(tdbcConditionID, dt)
        For i As Integer = 1 To 40
            Dim dd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = CreateDropDownID(Me, "TypeC" & i.ToString("00"), "ConditionID", "ConditionID", "Description", "FieldName")

            dd.Columns(0).Caption = rL3("Ma")
            dd.Columns(1).Caption = rL3("Ten")
            dd.DisplayColumns(2).Visible = False

            LoadDataSource(dd, ReturnTableFilter(dtConditionID, "FieldName='TypeC" & i.ToString("00") & "'"))
            tdbg.Columns(IndexOfColumn(tdbg, "TypeC" & i.ToString("00"))).DropDown = dd
        Next
    End Sub

#Region "SQL"
    Private Function SQLSelectD45T1050(ByVal sComment As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "SELECT PieceworkGroupID, PieceworkGroupName" & UnicodeJoin(gbUnicode) & " AS PieceworkGroupName " & vbCrLf
        sSQL &= "FROM D45T1050 " & vbCrLf
        sSQL &= "WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY PieceworkGroupID "
        Return sSQL
    End Function

    Private Function SQLSelectD45T1000(ByVal sComment As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "SELECT ProductID, ProductName" & UnicodeJoin(gbUnicode) & " As ProductName " & vbCrLf
        sSQL &= "FROM D45T1000 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, ProductID "
        Return sSQL
    End Function

    Private Function SQLSelectD45N6666(ByVal sComment As String, ByVal sFormID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "SELECT * FROM D45N6666 ( " & vbCrLf
        sSQL &= SQLString(gsDivisionID) & COMMA
        sSQL &= SQLString(giTranMonth) & COMMA
        sSQL &= SQLString(giTranYear) & COMMA
        sSQL &= SQLString(SQLStoreD09P6001()) & COMMA
        sSQL &= "GETDATE()" & COMMA
        sSQL &= "GETDATE()" & COMMA
        sSQL &= SQLNumber(0) & COMMA
        sSQL &= SQLString(sFormID) & COMMA
        sSQL &= SQLString(gsUserID) & COMMA
        sSQL &= SQLString(gbUnicode)
        sSQL &= ")"
        Return sSQL
    End Function
    Private Function SQLStoreD09P6001() As String
        Dim sSQL As String = "Exec D09P6001 "
        sSQL &= SQLString(gsDivisionID) & COMMA
        sSQL &= SQLString(giTranMonth) & COMMA
        sSQL &= SQLString(giTranYear) & COMMA
        sSQL &= SQLString(gsUserID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("PayrollVoucherID").ToString
        End If
        Return ""
    End Function
    Private Function SQLSelectD45T0010(ByVal sComment As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "SELECT Code, ShortName" & UnicodeJoin(gbUnicode) & " AS ShortName , Disabled " & vbCrLf
        sSQL &= "FROM D45T0010 " & vbCrLf
        sSQL &= "WHERE Type = 'QTY' " & vbCrLf
        sSQL &= "ORDER BY Code "
        Return sSQL
    End Function

    Private Function SQLSelectD45T0030(ByVal sComment As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "SELECT CODE, NameT AS ShortName, Disabled " & vbCrLf
        sSQL &= "FROM D45T0030 " & vbCrLf
        sSQL &= "ORDER BY CODE "
        Return sSQL
    End Function

    Private Function SQLStoreD45P1151(ByVal sComment As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "SELECT CODE, NameT AS ShortName, Disabled " & vbCrLf
        sSQL &= "FROM D45T0030 " & vbCrLf
        sSQL &= "ORDER BY CODE "
        Return sSQL
    End Function

    Private Function SQLStoreD45P1151(ByVal sComment As String, ByVal sFormID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "Exec D45P1151 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(sFormID) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[50], NOT NULL
        sSQL &= SQLString("DD") 'Type, varchar[50], NOT NULL
        Return sSQL
    End Function

    Private Function SQLStoreD45P4016(ByVal sComment As String, ByVal sFormID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "Exec D45P4016 "
        sSQL &= SQLString(gsDivisionID) & COMMA
        sSQL &= SQLString(_departmentID) & COMMA
        sSQL &= SQLString(_teamID) & COMMA
        sSQL &= SQLString(tdbg.Columns(COL_EmployeeID).Text) & COMMA
        sSQL &= SQLString(_productVoucherID) & COMMA
        sSQL &= SQLNumber(giTranMonth) & COMMA
        sSQL &= SQLNumber(giTranYear) & COMMA
        sSQL &= SQLString(gbUnicode) & COMMA
        sSQL &= SQLString(gsUserID) & COMMA
        sSQL &= SQLString(sFormID)
        Return sSQL
    End Function

    Private Function SQLStoreD91P1010(ByVal sComment As String, ByVal sTableName As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "Exec D91P1010 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sTableName) & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_ProductID).Text) & COMMA 'Key1ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_EmployeeID).Text) & COMMA 'Key2ID, varchar[20], NOT NULL
        sSQL &= SQLString(txtProductVoucherID.Text) & COMMA 'Key3ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key4ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key5ID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub CheckFormD13T2605()
        Dim sSQL As String = ""
        sSQL &= ("-- -	Trước khi mở phiếu chấm công D45F2016, kiểm tra tồn tại phiếu chấm công") & vbCrLf
        sSQL &= "SELECT	VoucherID FROM		D13T2605 "
        sSQL &= "WHERE	Module = 'D45' AND VoucherID =" & SQLString(txtProductVoucherID.Text)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            D99C0008.MsgL3(rL3("Phieu_nay_da_duoc_tinh_luong_Ban_khong_duoc_suaU"))
            btnSave.Enabled = False
        End If

    End Sub
    Private Function SQLDeleteD45T2001() As String
        Dim sSQL As String = "--Xóa dữ liệu cũ" & vbCrLf

        sSQL &= "DELETE 	D45T2001 " & vbCrLf
        sSQL &= "WHERE	DivisionID =" & SQLString(gsDivisionID) & " and TranMonth = " & SQLString(giTranMonth) & " and TranYear =" & SQLString(giTranYear) & " and ProductVoucherID = " & SQLString(_productVoucherID)
        sSQL &= "and (Case when" & SQLString(_departmentID) & " <> '%' then DepartmentID else '%' end =" & SQLString(_departmentID) & ") and			(Case when " & SQLString(_teamID) & " <> '%' then TeamID 			else '%' end = " & SQLString(_teamID) & ")" & vbCrLf

        Return sSQL
    End Function
    Private Function SQLInsertD45T2001() As String
        Dim sTransID As String = ""
        Dim iCountIGE As Integer = tdbg.RowCount
        Dim iFirstIGE As Long
        Dim sSQL As String = "--Insert từng dòng dữ liệu mới vào D45T2001 " & vbCrLf       '& vbCrLf & "BEGIN TRY BEGIN TRANSACTION"

        For i As Integer = 0 To tdbg.RowCount - 1
            'Sinh IGE cho TransID
            If tdbg(i, COL_TransID).ToString = "" Then
                sTransID = CreateIGENewS("D45T2001", "TransID", "45", "DT", gsStringKey, sTransID, iCountIGE, iFirstIGE)
                tdbg(i, COL_TransID) = sTransID
            End If
            sSQL &= "INSERT INTO D45T2001" & vbCrLf
            sSQL &= "(TransID,DivisionID, TranMonth, TranYear, ProductVoucherID, PayrollVoucherID, DepartmentID, TeamID, EmployeeID, ProductID, Quantity01, Quantity02, Quantity03, " & vbCrLf
            sSQL &= "Quantity04, Quantity05, Quantity06, Quantity07, Quantity08, Quantity09, Quantity10, Quantity11, Quantity12, Quantity13, Quantity14, Quantity15, Quantity16, Quantity17, Quantity18, Quantity19, " & vbCrLf
            sSQL &= "Quantity20, TypeC01, TypeC02, TypeC03, TypeC04, TypeC05, TypeC06, TypeC07, TypeC08, TypeC09, TypeC10, TypeC11, TypeC12, TypeC13, TypeC14, TypeC15, TypeC16, TypeC17, " & vbCrLf
            sSQL &= "TypeC18, TypeC19, TypeC20, TypeC21, TypeC22, TypeC23, TypeC24, TypeC25, TypeC26, TypeC27, TypeC28, TypeC29, TypeC30, TypeC31, TypeC32, TypeC33, TypeC34, TypeC35, " & vbCrLf
            sSQL &= "TypeC36, TypeC37, TypeC38, TypeC39, TypeC40, Notes, NotesU,CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, OrderNo, PieceworkGroupID) " & vbCrLf
            sSQL &= "VALUES" & vbCrLf
            sSQL &= "(" & vbCrLf
            sSQL &= SQLString(tdbg(i, COL_TransID).ToString) & COMMA
            sSQL &= SQLString(gsDivisionID) & COMMA
            sSQL &= SQLString(giTranMonth) & COMMA
            sSQL &= SQLString(giTranYear) & COMMA
            sSQL &= SQLString(_productVoucherID) & COMMA
            sSQL &= SQLString(SQLStoreD09P6001()) & COMMA
            sSQL &= SQLString(tdbg(i, COL_DepartmentID).ToString) & COMMA
            sSQL &= SQLString(tdbg(i, COL_TeamID).ToString) & COMMA
            sSQL &= SQLString(tdbg(i, COL_EmployeeID).ToString) & COMMA
            sSQL &= SQLString(tdbg(i, COL_ProductID).ToString) & COMMA & vbCrLf


            For k As Integer = 1 To 20
                sSQL &= SQLNumber(tdbg(i, IndexOfColumn(tdbg, "Quantity" & k.ToString("00"))).ToString) & COMMA
            Next
            sSQL &= vbCrLf
            For j As Integer = 1 To 40
                sSQL &= SQLString(tdbg(i, IndexOfColumn(tdbg, "TypeC" & j.ToString("00"))).ToString) & COMMA
            Next
            sSQL &= vbCrLf & SQLString(tdbg(i, COL_Notes).ToString) & COMMA
            sSQL &= SQLStringUnicode(tdbg(i, COL_Notes).ToString) & COMMA
            sSQL &= SQLString(gsUserID) & COMMA
            sSQL &= "GETDATE()" & COMMA
            sSQL &= SQLString(gsUserID) & COMMA
            sSQL &= "GETDATE()" & COMMA
            sSQL &= SQLString(tdbg(i, COL_OrderNo).ToString) & COMMA
            sSQL &= SQLString(tdbg(i, COL_PieceworkGroupID).ToString)
            sSQL &= ")" & vbCrLf
            'If (i Mod 100) = 0 And i <> 0 Then
            '    sSQL &= "COMMIT END TRY BEGIN CATCH  ROLLBACK END CATCH" & vbCrLf
            '    sSQL &= "BEGIN TRY BEGIN TRANSACTION" & vbCrLf
            'End If
        Next
        'sSQL &= "COMMIT END TRY BEGIN CATCH  ROLLBACK END CATCH" & vbCrLf

        Return sSQL
    End Function
#End Region
    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case e.Col
            Case COL_Permission
                If L3Int(tdbg(e.Row, COL_Permission)) < 2 Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
          
        End Select
    End Sub

    Private Sub tdbg_ButtonClick(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ButtonClick
        Select Case tdbg.Col
            Case COL_Attachment           
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "TableName", "D45T2001")
                SetProperties(arrPro, "Key1ID", tdbg.Columns(COL_ProductID).Text)
                SetProperties(arrPro, "Key2ID", tdbg.Columns(COL_EmployeeID).Text)
                SetProperties(arrPro, "Key3ID", txtProductVoucherID.Text)                          
                CallFormShowDialog("D91D0340", "D91F4010", arrPro)
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text, txtProductVoucherID.Text) & ")"  'Đính kèm
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        UpdateTDBGOrderNum(tdbg, COL_OrderNo)
        Select e.ColIndex   'L3Int(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
            Case COL_ProductID
                If tdbg.Columns(COL_ProductName).Text = "" Then
                    tdbg.Columns(COL_ProductName).Text = ""
                Else
                    tdbg.Columns(COL_ProductName).Text = tdbdProductID.Columns("ProductName").Value.ToString
                End If

                'tdbg.Columns(COL_ProductID).Text = tdbdProductID.Columns("ProductID").Value.ToString
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text, txtProductVoucherNo.Text) & ")"  'Đính kèm
            Case COL_EmployeeID
                tdbg.Columns(COL_Attachment).Text = "(" & ReturnAttachmentNumber("D45T2001", tdbg.Columns(COL_ProductID).Text, tdbg.Columns(COL_EmployeeID).Text, txtProductVoucherNo.Text) & ")"  'Đính kèm              
                If tdbcProductID.Text = "" Then
                    tdbg.Columns(COL_ProductID).Text = ""
                    tdbg.Columns(COL_ProductName).Text = ""
                Else
                    tdbg.Columns(COL_ProductID).Text = tdbcProductID.Columns("ProductID").Value.ToString
                    tdbg.Columns(COL_ProductName).Text = tdbcProductID.Columns("ProductName").Value.ToString
                End If
                tdbg.Columns(IndexOfColumn(tdbg, tdbcConditionID.Columns("FieldName").Value.ToString)).Text = tdbcConditionID.Text
            Case COL_Quantity01, COL_Quantity02, COL_Quantity03, COL_Quantity04, COL_Quantity05, COL_Quantity06, COL_Quantity07, COL_Quantity08, COL_Quantity09, COL_Quantity10, COL_Quantity11, COL_Quantity12, COL_Quantity13, COL_Quantity14, COL_Quantity15, COL_Quantity16, COL_Quantity17, COL_Quantity18, COL_Quantity19, COL_Quantity20
                CalTotalFooter(CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString))

        End Select
    End Sub
    Private Sub CalTotalFooter(ByVal iCol As Integer)
        Dim dQuantity As Double = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            dQuantity += Number(tdbg(i, iCol))
        Next

        tdbg.Columns(iCol).FooterText = Format(dQuantity, DxxFormat.DefaultNumber2)
    End Sub
    Private Sub btnHotKey_Click(sender As Object, e As EventArgs) Handles btnHotKey.Click
        Dim f As New D45F7777
        f.FormID = "D45F2002"
        f.ShowDialog()
        f.Dispose()
    End Sub
    Dim bLoadFormChild As Boolean = False 'Ktra xem co goi form con k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
    Private usrOption As D09U1111
    Private Sub btnAdjust_Click(sender As Object, e As EventArgs) Handles btnAdjust.Click
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

    Private Sub btnShowOption_Click(sender As Object, e As EventArgs) Handles btnShowOption.Click
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
    Dim bSaveOK As Boolean = False
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tdbg.VisibleRows < 2 Then
            D99C0008.MsgNoDataInGrid()
            Exit Sub
        End If
        If allowsave() = False Then
            Exit Sub
        End If
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSQL As String = "-- luu" & vbCrLf
        sSQL &= SQLDeleteD45T2001() & vbCrLf & SQLInsertD45T2001()

        Dim bRun As Boolean = ExecuteSQL(sSQL)
        If bRun = True Then
            SaveOK()
            bSaveOK = True
            btnSave.Enabled = False
        Else
            SaveNotOK()
        End If

    End Sub
    Private Function allowsave() As Boolean
        For i As Integer = 0 To tdbg.VisibleRows - 2
            If tdbg(i, COL_ProductID).ToString = "" Then
                D99D0041.D99C0008.MsgNotYetChoose(rL3("Ma_san_pham"))
                tdbg.SplitIndex = SPLIT1
                tdbg.Row = i
                tdbg.Col = COL_ProductID
                tdbg.Focus()
                Return False
            End If
        Next

        If chkTestDuplicate.Checked = False Then
            Return True
        End If
        For i As Integer = 0 To tdbg.VisibleRows - 2

            Dim stri As String = tdbg(i, COL_EmployeeID).ToString & tdbg(i, COL_ProductID).ToString
            For k As Integer = COL_TypeC01 To COL_TypeC40
                If tdbg.Splits(SPLIT1).DisplayColumns(k).Visible = True Then
                    stri &= tdbg(i, k).ToString
                End If
            Next

            For j As Integer = i + 1 To tdbg.VisibleRows - 1
                Dim strj As String = tdbg(j, COL_EmployeeID).ToString & tdbg(j, COL_ProductID).ToString
                For k As Integer = COL_TypeC01 To COL_TypeC40
                    If tdbg.Splits(SPLIT1).DisplayColumns(k).Visible = True Then
                        strj &= tdbg(i, k).ToString
                    End If
                Next
                If stri = strj Then

                    MyMsg(rL3("Cac_dong_du_lieu_khong_duoc_giong_nhau"))
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Row = j
                    tdbg.Focus()
                    Return False
                End If
            Next
        Next
        Return True
    End Function
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If bSaveOK = False Then
            If AskMsgBeforeClose() = True Then
                Close()
            Else
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub tdbcCODE_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcCODE.SelectedValueChanged
        LoadDataSource(tdbcConditionID, ReturnTableFilter(dtConditionID, "FieldName=" & SQLString(tdbcCODE.Columns("CODE").Value.ToString)))
        tdbcConditionID.SelectedIndex = tdbcConditionID.FindStringExact(L3String(tdbcCODE.Columns("CODE").Value.ToString), 0, "FieldName")
    End Sub
    Private Sub tdbcCODE_LostFocus(sender As Object, e As EventArgs) Handles tdbcCODE.LostFocus
        If tdbcCODE.FindStringExact(tdbcCODE.Text) = -1 Then
            tdbcCODE.Text = ""
            tdbcConditionID.SelectedValue = ""
        End If
    End Sub


    Private Sub tdbg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Quantity01 To COL_Quantity20
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
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

    Private Sub tdbg_ComboSelect(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case L3Int(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
            Case COL_EmployeeID
              
                tdbg.Columns(COL_RefEmployeeID).Text = tdbdEmployeeID.Columns("RefEmployeeID").Value.ToString
                tdbg.Columns(COL_FirstName).Text = tdbdEmployeeID.Columns("FirstName").Value.ToString
                tdbg.Columns(COL_EmployeeName).Text = tdbdEmployeeID.Columns("EmployeeName").Value.ToString

                tdbg.Columns(COL_DepartmentID).Text() = tdbdEmployeeID.Columns("DepartmentID").Value.ToString
                tdbg.Columns(COL_DepartmentName).Text() = tdbdEmployeeID.Columns("DepartmentName").Value.ToString
                tdbg.Columns(COL_TeamID).Text() = tdbdEmployeeID.Columns("TeamID").Value.ToString
                tdbg.Columns(COL_TeamName).Text() = tdbdEmployeeID.Columns("TeamName").Value.ToString

            Case COL_RefEmployeeID
                tdbg.Columns(COL_EmployeeID).Text = tdbdRefEmployeeID.Columns("EmployeeID").Value.ToString
                tdbg.Columns(COL_FirstName).Text = tdbdRefEmployeeID.Columns("FirstName").Value.ToString
                tdbg.Columns(COL_EmployeeName).Text = tdbdRefEmployeeID.Columns("EmployeeName").Value.ToString

                tdbg.Columns(COL_DepartmentID).Text() = tdbdRefEmployeeID.Columns("DepartmentID").Value.ToString
                tdbg.Columns(COL_DepartmentName).Text() = tdbdRefEmployeeID.Columns("DepartmentName").Value.ToString
                tdbg.Columns(COL_TeamID).Text() = tdbdRefEmployeeID.Columns("TeamID").Value.ToString
                tdbg.Columns(COL_TeamName).Text() = tdbdRefEmployeeID.Columns("TeamName").Value.ToString
            Case COL_FirstName
                tdbg.Columns(COL_EmployeeID).Text = tdbdFirstName.Columns("EmployeeID").Value.ToString
                tdbg.Columns(COL_RefEmployeeID).Text = tdbdFirstName.Columns("RefEmployeeID").Value.ToString
                tdbg.Columns(COL_EmployeeName).Text = tdbdFirstName.Columns("EmployeeName").Value.ToString

                tdbg.Columns(COL_DepartmentID).Text() = tdbdFirstName.Columns("DepartmentID").Value.ToString
                tdbg.Columns(COL_DepartmentName).Text() = tdbdFirstName.Columns("DepartmentName").Value.ToString
                tdbg.Columns(COL_TeamID).Text() = tdbdFirstName.Columns("TeamID").Value.ToString
                tdbg.Columns(COL_TeamName).Text() = tdbdFirstName.Columns("TeamName").Value.ToString
            Case COL_ProductID
                tdbg.Columns(COL_ProductName).Text = tdbdProductID.Columns("ProductName").Value.ToString
                tdbg.Columns(COL_ProductID).Text = tdbdProductID.Columns("ProductID").Value.ToString
        End Select

    End Sub

    Private Sub tdbg_BeforeColUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Dim iCol As Integer = CInt(IIf(bColMove = False, e.ColIndex, arrayIndex(e.ColIndex)).ToString)
        Select iCol
            Case COL_EmployeeID
                If tdbg.Columns(COL_EmployeeID).Text.ToUpper <> tdbdEmployeeID.Columns("EmployeeID").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_DepartmentName).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                End If
            Case COL_RefEmployeeID
                If tdbg.Columns(COL_RefEmployeeID).Text.ToUpper <> tdbdRefEmployeeID.Columns("RefEmployeeID").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_DepartmentName).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                End If
            Case COL_FirstName
                If tdbg.Columns(COL_FirstName).Text.ToUpper <> tdbdFirstName.Columns("FirstName").Text.ToUpper Then
                    tdbg.Columns(COL_EmployeeID).Text = ""
                    tdbg.Columns(COL_EmployeeName).Text = ""
                    tdbg.Columns(COL_RefEmployeeID).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_DepartmentName).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                    tdbg.Columns(COL_FirstName).Text = ""
                End If
            Case COL_PieceworkGroupID
                If tdbg.Columns(COL_PieceworkGroupID).Text.ToUpper <> tdbdPieceworkGroupID.Columns("PieceworkGroupID").Text.ToUpper Then
                    tdbg.Columns(COL_PieceworkGroupID).Text = ""
                End If
            Case COL_ProductID
                If tdbg.Columns(COL_ProductID).Text.ToUpper <> tdbdProductID.Columns("ProductID").Text.ToUpper Then
                    tdbg.Columns(COL_ProductID).Text = ""
                    tdbg.Columns(COL_ProductName).Text = ""
              
                End If
        End Select
    End Sub

    Private Sub tdbg_HeadClick(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_Quantity01 To COL_Quantity20
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Value.ToString, tdbg.Row)
                CalTotalFooter(CInt(IIf(bColMove = False, iCol, arrayIndex(iCol)).ToString))
            Case COL_TypeC01 To COL_TypeC40
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Value.ToString, tdbg.Row)         
            Case COL_EmployeeID, COL_RefEmployeeID, COL_FirstName
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Value.ToString, tdbg.Row)
                ' CopyColumns_AfterBefore(tdbg, iCol, tdbg.Row, 2, 5, tdbg.Columns(iCol).Value.ToString)
            Case COL_ProductID, COL_Notes
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Value.ToString, tdbg.Row)
        End Select
    End Sub

    
    Private Sub tdbcProductID_LostFocus(sender As Object, e As EventArgs) Handles tdbcProductID.LostFocus
        If tdbcProductID.FindStringExact(tdbcProductID.Text) = -1 Then
            tdbcProductID.Text = ""
        End If
    End Sub
End Class