Imports System.Windows.Forms
Imports System
Public Class D25F2090
    Dim dtCaptionCols As DataTable


#Region "Const of tdbg"
    Private Const COL_CostTransID As Integer = 0        ' CostTransID
    Private Const COL_RecPlanID As Integer = 1          ' RecPlanID
    Private Const COL_RecPlanName As Integer = 2        ' Kế hoạch tuyển dụng
    Private Const COL_ProposalID As Integer = 3         ' ProposalID
    Private Const COL_ProposalName As Integer = 4       ' Đề xuất tuyển dụng
    Private Const COL_BlockID As Integer = 5            ' BlockID
    Private Const COL_BlockName As Integer = 6          ' Khối
    Private Const COL_DepartmentID As Integer = 7       ' DepartmentID
    Private Const COL_DepartmentName As Integer = 8     ' Phòng ban
    Private Const COL_TeamID As Integer = 9             ' TeamID
    Private Const COL_TeamName As Integer = 10          ' Tổ nhóm
    Private Const COL_AppNumber As Integer = 11         ' Số lượng
    Private Const COL_VoucherDate As Integer = 12       ' Ngày lập
    Private Const COL_CreatorID As Integer = 13         ' Người lập
    Private Const COL_Description As Integer = 14       ' Diễn giải
    Private Const COL_RecPositionID As Integer = 15     ' RecPositionID
    Private Const COL_RecPositionName As Integer = 16   ' Vị trí
    Private Const COL_RecSourceID As Integer = 17       ' Nguồn tuyển
    Private Const COL_PassNumber As Integer = 18        ' Số lượng thực tuyển
    Private Const COL_CostTypeID As Integer = 19        ' Kế hoạch/ Thực tế
    Private Const COL_RecCostID As Integer = 20         ' RecCostID
    Private Const COL_RecCostName As Integer = 21       ' Loại chi phí
    Private Const COL_CurrencyID As Integer = 22        ' Loại tiền
    Private Const COL_ExchangeRate As Integer = 23      ' Tỷ giá
    Private Const COL_OCost As Integer = 24             ' CP nguyên tệ
    Private Const COL_CCost As Integer = 25             ' CP quy đổi
    Private Const COL_FromDate As Integer = 26          ' Từ ngày
    Private Const COL_ToDate As Integer = 27            ' Đến ngày
    Private Const COL_Note As Integer = 28              ' Ghi chú
    Private Const COL_RecruitmentFileID As Integer = 29 ' RecruitmentFileID
    Private Const COL_VoucherNo As Integer = 30         ' VoucherNo
    Private Const COL_OriginalDecimal As Integer = 31   ' OriginalDecimal
    Private Const COL_CreateUserID As Integer = 32      ' CreateUserID
    Private Const COL_CreateDate As Integer = 33        ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 34  ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 35    ' LastModifyDate
#End Region

    '*****************************************
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    '*****************************************
    Dim bLoadD25F2090 As Boolean = False 'Ktra xem co goi D25F2070 k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
    '*****************************************
    Dim bIsUseBlock As Boolean
    Dim bSelectValue As Boolean = False
    Dim dtBlockID, dtDepartmentID, dtTeamID As DataTable

    Private _dtGrid As DataTable
    Public Property dtGrid() As DataTable
        Get
            Return _dtGrid
        End Get
        Set(ByVal Value As DataTable)
            _dtGrid = Value
        End Set
    End Property

    Private _costTransID As String = ""
    Public Property CostTransID() As String
        Get
            Return _costTransID
        End Get
        Set(ByVal Value As String)
            _costTransID = Value
        End Set
    End Property

    Private _bCallD25F2000 As Boolean = False
    Public WriteOnly Property bCallD25F2000() As Boolean
        Set(ByVal Value As Boolean)
            _bCallD25F2000 = Value
        End Set
    End Property

    Private _recruitmentFileID As String = ""
    Public WriteOnly Property RecruitmentFileID() As String
        Set(ByVal Value As String)
            _recruitmentFileID = Value
        End Set
    End Property

    Private _savedOK As Boolean = False
    Public ReadOnly Property SavedOK() As Boolean
        Get
            Return _savedOK
        End Get
    End Property

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            _FormState = value

            bIsUseBlock = VisibleBlock()
            LoadTDBDropDown()

            Select Case _FormState

                Case EnumFormState.FormAdd
                    If _bCallD25F2000 Then
                        dtGrid = ReturnTableFilter(ReturnDataTable(SQLStoreD25P3091(1)), "CostTransID = ''", True)
                    Else
                        dtGrid = ReturnTableFilter(ReturnDataTable(SQLStoreD25P3091()), "CostTransID = ''", True)
                    End If
                    btnNext.Enabled = False
                    btnPrint.Enabled = False
                Case EnumFormState.FormEdit
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    tdbg.AllowAddNew = False
                Case EnumFormState.FormView
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False

            End Select
        End Set
    End Property

    Private Sub D25F2090_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If

        '***************************************
        'Chuẩn hóa D09U1111 B4: mở, đóng UserControl
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowColumns_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then 'Đóng
            usrOption.Hide()
        End If
        '***************************************

    End Sub

    Dim bLoad As Boolean = False
    Private Sub D25F2090_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _FormState
        Loadlanguage()
        'If _recruitmentFileID = "" Then tdbg.Splits(1).DisplayColumns(COL_RecruitmentFileID).Visible = False
        ResetFooterGrid(tdbg, SPLIT0, SPLIT1)

        ResetSplitDividerSize(tdbg)

        tdbg_LockedColumns()
        tdbg_NumberFormat()


        InputDateInTrueDBGrid(tdbg, COL_FromDate, COL_ToDate, COL_VoucherDate)
        LoadTDBGrid()
        'If _FormState <> EnumFormState.FormAdd Then
        '    LoadTDBDProReferenceNo()
        '    LoadTDBDPlanReferenceNo()
        'End If
        GetTextCreateByNew(tdbg, COL_CreatorID, 1)
        'tdbg.Splits(1).DisplayColumns(COL_RecPlanName).FetchStyle = True
        'tdbg.Splits(1).DisplayColumns(COL_BlockName).FetchStyle = True
        'tdbg.Splits(1).DisplayColumns(COL_DepartmentName).FetchStyle = True
        'tdbg.Splits(1).DisplayColumns(COL_TeamName).FetchStyle = True
        'tdbg.Splits(1).DisplayColumns(COL_RecPositionName).FetchStyle = True
        InitiateD09U1111()
        bLoad = True
        SetResolutionForm(Me)
    End Sub

    Private Sub D25F2090_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        tdbg.Focus()
        tdbg.SplitIndex = SPLIT0
        tdbg.Col = COL_Description
        tdbg.Bookmark = 0
        tdbg.Focus()
        tdbg.Col = COL_RecPlanName
    End Sub

    Private Sub InitiateD09U1111()
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_CurrencyID, COL_ExchangeRate, COL_OCost, COL_CCost, COL_CostTypeID, COL_VoucherDate, COL_CreatorID}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory, , , gbUnicode)
        '*****************************************
        'Chuẩn hóa D09U1111 B2: Khởi tạo UserControl    
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , , , gbUnicode)
        '*****************************************

        For i As Integer = COL_BlockID To COL_TeamName
            tdbg.Splits(SPLIT1).DisplayColumns(i).Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
        Next
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_phi_tuyen_dung_-_D25F2090") & UnicodeCaption(gbUnicode) 'Chi phÛ tuyÓn dóng - D25F2090
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnShowColumns.Text = rl3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
        btnPrint.Text = rl3("_In") '&In
        '================================================================ 
        tdbdRecSourceID.Columns(0).Caption = rL3("Ma") 'Mã
        tdbdRecSourceID.Columns(1).Caption = rL3("Ten") 'Tên
        tdbdRecPositionID.Columns("RecPositionID").Caption = rl3("Ma") 'Mã
        tdbdRecPositionID.Columns("RecPositionName").Caption = rl3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbdDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbdBlockID.Columns("BlockID").Caption = rl3("Ma") 'Mã
        tdbdBlockID.Columns("BlockName").Caption = rl3("Ten") 'Tên
        tdbdRecCostID.Columns("RecCostID").Caption = rl3("Ma") 'Mã
        tdbdRecCostID.Columns("RecCostName").Caption = rl3("Ten") 'Tên
        tdbdCurrencyID.Columns("CurrencyID").Caption = rl3("Ma") 'Mã
        tdbdCurrencyID.Columns("CurrencyName").Caption = rl3("Ten") 'Tên
        tdbdCurrencyID.Columns("ExchangeRate").Caption = rl3("Ty_gia") 'Tỷ giá
        tdbdCostTypeID.Columns("CostTypeID").Caption = rl3("Ma") 'Mã
        tdbdCostTypeID.Columns("CostTypeName").Caption = rl3("Ten") 'Tên
        tdbdCreatorID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbdCreatorID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbdProReferenceNo.Columns("ProReferenceNo").Caption = rl3("Ten_de_xuat") 'Tên đề xuất
        tdbdProReferenceNo.Columns("PlanReferenceNo").Caption = rl3("Ten_ke_hoach") 'Tên kế hoạch
        tdbdProReferenceNo.Columns("BlockID").Caption = rl3("Khoi") 'Khối
        tdbdProReferenceNo.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbdProReferenceNo.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbdProReferenceNo.Columns("RecPositionID").Caption = rl3("Vi_tri") 'Vị trí
        tdbdPlanReferenceNo.Columns("PlanReferenceNo").Caption = rl3("Ten_ke_hoach") 'Tên kế hoạch
        tdbdPlanReferenceNo.Columns("BlockID").Caption = rl3("Khoi") 'Khối
        tdbdPlanReferenceNo.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbdPlanReferenceNo.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbdPlanReferenceNo.Columns("PositionID").Caption = rl3("Vi_tri") 'Vị trí
        tdbdRecruitmentFileID.Columns("VoucherNo").Caption = rl3("Ma") 'Mã
        tdbdRecruitmentFileID.Columns("RecruitmentFileID").Caption = rl3("Ten") 'Tên
        '================================================================ 
        btnChoose.Text = rL3("Chon_de_xuat_tuyen_dung") 'Chọn đề xuất tuyển dụng
        '================================================================ 
        tdbg.Columns(COL_RecPlanName).Caption = rL3("Ke_hoach_tuyen_dung") 'Kế hoạch tuyển dụng
        tdbg.Columns(COL_ProposalName).Caption = rL3("De_xuat_tuyen_dung") 'Đề xuất tuyển dụng
        tdbg.Columns(COL_BlockName).Caption = rL3("Khoi") 'Khối
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_TeamName).Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_AppNumber).Caption = rL3("So_luong") 'Số lượng
        tdbg.Columns(COL_VoucherDate).Caption = rL3("Ngay_lap") 'Ngày lập
        tdbg.Columns(COL_CreatorID).Caption = rL3("Nguoi_lap") 'Người lập
        tdbg.Columns(COL_Description).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_RecPositionName).Caption = rL3("Vi_tri") 'Vị trí
        tdbg.Columns(COL_RecSourceID).Caption = rL3("Nguon_tuyen") 'Nguồn tuyển
        tdbg.Columns(COL_PassNumber).Caption = rL3("So_luong_thuc_tuyen") 'Số lượng thực tuyển
        tdbg.Columns(COL_CostTypeID).Caption = rL3("Ke_hoach_Thuc_te") 'Kế hoạch/ Thực tế
        tdbg.Columns(COL_RecCostName).Caption = rL3("Loai_chi_phi") 'Loại chi phí
        tdbg.Columns(COL_CurrencyID).Caption = rL3("Loai_tien") 'Loại tiền
        tdbg.Columns(COL_ExchangeRate).Caption = rL3("Ty_gia") 'Tỷ giá
        tdbg.Columns(COL_OCost).Caption = rL3("CP_nguyen_te") 'CP nguyên tệ
        tdbg.Columns(COL_CCost).Caption = rL3("CP_quy_doi") 'CP quy đổi
        tdbg.Columns(COL_FromDate).Caption = rL3("Tu_ngay") 'Từ ngày
        tdbg.Columns(COL_ToDate).Caption = rL3("Den_ngay") 'Đến ngày
        tdbg.Columns(COL_Note).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Splits(0).Caption = rL3("Thong_tin_chung") 'Thông tin chung
        tdbg.Splits(1).Caption = rL3("Thong_tin_chi_phi") 'Thông tin chi phí
    End Sub

    Private Function VisibleBlock() As Boolean
        'Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        'If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
        If D25Systems.IsUseBlock = False Then
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockName).Visible = False
            Return False
        End If
        Return True
    End Function

    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_AppNumber).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_PassNumber).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_ExchangeRate).DataField, DxxFormat.ExchangeRateDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_OCost).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_CCost).DataField, DxxFormat.D90_ConvertedDecimals, 28, 8)
        InputNumber(tdbg, arr)
    End Sub


    Private Sub tdbg_LockedColumns()
        ' tdbg.Splits(SPLIT0).DisplayColumns(COL_RecPositionName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_CostTransID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_BlockID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_DepartmentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        'tdbg.Splits(SPLIT1).DisplayColumns(COL_TeamID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CCost).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_FromDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ToDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CurrencyID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_OCost).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CostTypeID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_VoucherDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CreatorID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBDropDown()
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************

        Dim sSQL As String = ""

        'Load tdbdRecCostID
        sSQL = "Select RecCostID, RecCostName" & sUnicode & " As RecCostName From D25T1030 WITH(NOLOCK)  Where Disabled = 0 ORDER BY RecCostID"
        'sSQL = "SELECT 	'%' As CostTypeID, " & sLanguage & " As RecCostName" & vbCrLf
        'sSQL &= "UNION" & vbCrLf
        'sSQL &= "SELECT     RecCostID, RecCostName" & sUnicode & " as RecCostName" & vbCrLf
        'sSQL &= "FROM       D25T1030 " & vbCrLf
        'sSQL &= "WHERE      Disabled = 0" & vbCrLf
        'sSQL &= "ORDER BY   RecCostID" & vbCrLf
        LoadDataSource(tdbdRecCostID, sSQL, gbUnicode)

        'Load tdbdCurrencyID
        LoadCurrencyID(tdbdCurrencyID, gbUnicode)

        'Load tdbdBlockID
        LoadDataSource(tdbdBlockID, ReturnTableBlockID(True, False, gbUnicode), gbUnicode)

        'Load tdbdDepartmentID
        dtDepartmentID = ReturnTableDepartmentID(True, False, gbUnicode)

        'Load tdbdTeamID
        dtTeamID = ReturnTableTeamID(True, False, gbUnicode)

        'Load tdbdPositionID
        LoadDataSource(tdbdRecPositionID, ReturnTableDutyIDRec(False, gbUnicode), gbUnicode)

        'Load tdbdCostTypeID
        sSQL = "SELECT	1 AS CostTypeID, " & IIf(gbUnicode, "N'Kế hoạch'", "'Keá hoaïch'").ToString() & " AS CostTypeName" & vbCrLf
        sSQL &= "UNION	" & vbCrLf
        sSQL &= "SELECT	2 AS CostTypeID, " & IIf(gbUnicode, "N'Thực hiện'", "'Thöïc hieän'").ToString() & " AS CostTypeName	" & vbCrLf
        sSQL &= "ORDER BY   CostTypeID"
        LoadDataSource(tdbdCostTypeID, sSQL, gbUnicode)

        'Load tdbdCreatorID

        LoadDataSource(tdbdCreatorID, ReturnTableCreateBy(gbUnicode), gbUnicode)
        'Load đơt tuyển dụng
        sSQL = "SELECT DISTINCT RecruitmentFileID, VoucherNo, RecruitmentFileName" & sUnicode & " as RecruitmentFileName "
        sSQL &= "FROM D25T1042  WITH(NOLOCK) "
        sSQL &= "WHERE DivisionID = " & SQLString(gsDivisionID)
        LoadDataSource(tdbdRecruitmentFileID, sSQL, gbUnicode)

        '  LoadTDBDProReferenceNo()

        '  LoadTDBDPlanReferenceNo()
        LoadDataSource(tdbdPlanReferenceNo, SQLStoreD25P2091("", 1, "Load dropdown Ke hoach tuyen dung"), gbUnicode)
        sSQL = "--Do nguon Dropdown nguon tuyen" & vbCrLf & _
        "SELECT		 RecSourceID AS RecSourceID, RecSourceName" & sUnicode & " AS RecSourceName" & vbCrLf & _
        "FROM		 D25T1010" & vbCrLf & _
        "WHERE 		Disabled =0" & vbCrLf & _
        "ORDER BY	 RecSourceID"

        LoadDataSource(tdbdRecSourceID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBDProReferenceNo(ByVal RecPlanID As String)
        'Dim sSQL As String = ""
        'sSQL = "SELECT T1.TransID, T1.ReferenceNo AS ProReferenceNo, T2.ReferenceNo AS PlanReferenceNo, T1.BlockID, T1.DepartmentID, T1.TeamID, T1.RecPositionID, T1.PlanTransID" & vbCrLf
        'sSQL &= "FROM D25T2001 T1 WITH(NOLOCK) " & vbCrLf
        'sSQL &= "LEFT JOIN	D25T2081 T2 WITH(NOLOCK)  ON T1. PlanTransID = T2.TransID" & vbCrLf
        'sSQL &= "WHERE isnull(T1.ReferenceNo,'') <>''  and ((T1.DateFrom Between ISNULL(" & SQLDateSave(tdbg.Columns(COL_FromDate).Text) & ", GetDate()) and ISNULL(" & SQLDateSave(tdbg.Columns(COL_ToDate).Text) & ",GetDate()) ) OR (T1.DateTo Between ISNULL(" & SQLDateSave(tdbg.Columns(COL_FromDate).Text) & ", GetDate()) and ISNULL(" & SQLDateSave(tdbg.Columns(COL_ToDate).Text) & ", GetDate())))"
        'If tdbg.Columns(COL_RecruitmentFileID).Text <> "" Then
        '    sSQL &= " AND T1.TransID IN (SELECT TransID FROM D25T2040 WITH(NOLOCK)  WHERE VoucherID = " & SQLString(tdbg.Columns(COL_RecruitmentFileID).Value)
        '    sSQL &= " and TransTypeID ='RF')"
        'End If
        'LoadDataSource(tdbdProReferenceNo, sSQL)
        LoadDataSource(tdbdProReferenceNo, SQLStoreD25P2091(RecPlanID, 0, "Load dropdown De xuat tuyen dung"), gbUnicode)
    End Sub

    'Private Sub LoadTDBDPlanReferenceNo()
    '    Dim sSQL As String = ""
    '    sSQL = "SELECT TransID, ReferenceNo AS PlanReferenceNo, BlockID, DepartmentID, TeamID, PositionID" & vbCrLf
    '    sSQL &= "FROM D25T2081 WITH(NOLOCK) " & vbCrLf
    '    If bLoad Then sSQL &= "WHERE (DateFrom Between ISNULL(" & SQLDateSave(tdbg.Columns(COL_FromDate).Text) & ", GetDate()) and ISNULL(" & SQLDateSave(tdbg.Columns(COL_ToDate).Text) & ", GetDate())) OR (DateTo Between ISNULL(" & SQLDateSave(tdbg.Columns(COL_FromDate).Text) & ",GetDate()) and ISNULL(" & SQLDateSave(tdbg.Columns(COL_ToDate).Text) & ", GetDate()) )"
    '    LoadDataSource(tdbdPlanReferenceNo, sSQL)
    'End Sub

    Private Sub LoadTdbdDepartmentID()
        If Not bIsUseBlock Then
            LoadDataSource(tdbdDepartmentID, dtDepartmentID.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbdDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID =  " & SQLString(tdbg(tdbg.Row, COL_BlockID).ToString)), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbdTeamID()
        If Not bIsUseBlock Then
            LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID, "DepartmentID = " & SQLString(tdbg(tdbg.Row, COL_DepartmentID).ToString)), gbUnicode)
        Else
            LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID, "DepartmentID = " & SQLString(tdbg(tdbg.Row, COL_DepartmentID).ToString) & " And BlockID = " & SQLString(tdbg(tdbg.Row, COL_BlockID).ToString)), gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBGrid()
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        If bLoadD25F2090 Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadD25F2090 = False
        End If

        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        SetBackColorObligatory()
        tdbg.Delete(0, tdbg.RowCount)
        ResetGrid()
        btnPrint.Enabled = False
        btnNext.Enabled = False
        btnSave.Enabled = True
        tdbg.Focus()
        tdbg.SplitIndex = SPLIT0
        tdbg.Col = COL_RecCostID
        tdbg.Bookmark = 0
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Dim f As New D25M0340
        'With f
        '    .FormActive = enumD25E0340Form.D25F4040
        '    .ShowDialog()
        '    .Dispose()
        'End With
        CallFormShow(Me, "D25D0340", "D25F4040")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        Select Case _FormState

            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD25T2091s().ToString)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLDeleteD25T2091() & vbCrLf)
                sSQL.Append(SQLInsertD25T2091s().ToString)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _savedOK = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnPrint.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
                Case EnumFormState.FormOther
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_VoucherDate).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ngay_lap"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_VoucherDate
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_CreatorID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Nguoi_lap"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_CreatorID
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_FromDate).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Tu_ngay"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_FromDate
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_ToDate).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Den_ngay"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_ToDate
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_FromDate) IsNot DBNull.Value And tdbg(i, COL_ToDate) IsNot DBNull.Value And tdbg(i, COL_FromDate).ToString <> "  /  /" And tdbg(i, COL_ToDate).ToString <> "  /  /" And tdbg(i, COL_FromDate).ToString <> "" And tdbg(i, COL_ToDate).ToString <> "" Then
                If CDate(tdbg(i, COL_FromDate)) > CDate(tdbg(i, COL_ToDate)) Then
                    D99C0008.MsgL3(rl3("Ngay_bat_dau_khong_duoc_lon_hon_ngay_ket_thuc"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_FromDate
                    tdbg.Bookmark = i
                    Return False
                End If
            End If

            If tdbg(i, COL_CurrencyID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Loai_tien"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_CurrencyID
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_ExchangeRate).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ty_gia"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_ExchangeRate
                tdbg.Bookmark = i
                Return False
            End If
            If Number(tdbg(i, COL_ExchangeRate)) <= 0 Then
                D99C0008.MsgL3(rl3("Ty_gia_khong_hop_leU"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_ExchangeRate
                tdbg.Bookmark = i
                Return False
            End If
            If Number(tdbg(i, COL_OCost).ToString) = 0 Then
                D99C0008.MsgNotYetEnter(rL3("CP_nguyen_te"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_OCost
                tdbg.Bookmark = i
                Return False
            End If
            If Number(tdbg(i, COL_OCost)) <= 0 Then
                D99C0008.MsgL3(rl3("CP_nguyen_te_khong_hop_le"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_OCost
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_CostTypeID).ToString = "" Then
                D99C0008.MsgNotYetEnter(tdbg.Columns(COL_CostTypeID).Caption)
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_CostTypeID
                tdbg.Bookmark = i
                Return False
            End If
        Next

        Return True
    End Function

#Region "SQL, Store"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3091
    '# Created User: 
    '# Created Date: 05/07/2010 03:26:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3091(Optional ByVal iMode As Integer = 0) As String
        Dim sSQL As String = ""
        If _recruitmentFileID <> "" Then
            iMode = 2
        End If
        sSQL &= "Exec D25P3091 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(Now()) & COMMA 'VoucherDateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(Now()) & COMMA 'VoucherDateTo, datetime, NOT NULL
        sSQL &= SQLString("%") & COMMA 'RecCostID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'BlockID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'RecPositionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(_recruitmentFileID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2091
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 30/06/2014 04:36:09
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2091(ByVal sTransID As String, ByVal Mode As Object, ByVal sComment As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "Exec D25P2091 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sTransID) & COMMA 'PlanID, varchar[20], NOT NULL
        sSQL &= SQLNumber(Mode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2090
    '# Created User: 
    '# Created Date: 06/07/2010 09:03:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2090() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P2090 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_costTransID) & COMMA 'RecruitmentCostID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'WhereClause, varchar[8000], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2091s
    '# Created User: 
    '# Created Date: 06/07/2010 09:53:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2091s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sCostTransID As String = ""

        Dim iCount As Integer = 0
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_CostTransID).ToString = "" Then
                iCount += 1
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_CostTransID).ToString = "" Then
                sCostTransID = CreateIGEs("D25T2091", "CostTransID", "25", "CT", gsStringKey, sCostTransID, iCount)
                tdbg(i, COL_CostTransID) = sCostTransID
            End If

            sSQL.Append("Insert Into D25T2091(")
            sSQL.Append("CostTransID, Description, DescriptionU, DivisionID, RecCostID, ")
            sSQL.Append("CurrencyID, ExchangeRate, OCost, CCost, FromDate, ToDate, ")
            sSQL.Append("BlockID, DepartmentID, TeamID, RecPositionID, CostTypeID, VoucherDate, ")
            sSQL.Append("CreatorID, Note, NoteU, RecSourceID, AppNumber, PassNumber, CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, ProposalID, RecPlanID, RecruitmentFileID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg(i, COL_CostTransID).ToString) & COMMA) 'CostTransID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, False) & COMMA) 'Description, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, True) & COMMA) 'DescriptionU, nvarchar, NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RecCostID)) & COMMA) 'RecCostID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CurrencyID)) & COMMA) 'CurrencyID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(Number(tdbg(i, COL_ExchangeRate)), DxxFormat.ExchangeRateDecimals) & COMMA) 'ExchangeRate, money, NOT NULL
            sSQL.Append(SQLMoney(Number(tdbg(i, COL_OCost))) & COMMA) 'OCost, money, NOT NULL
            sSQL.Append(SQLMoney(Number(tdbg(i, COL_CCost)), DxxFormat.D90_ConvertedDecimals) & COMMA) 'CCost, money, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_FromDate)) & COMMA) 'FromDate, datetime, NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_ToDate)) & COMMA) 'ToDate, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COL_BlockID)) & COMMA) 'BlockID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RecPositionID)) & COMMA) 'RecPositionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CostTypeID)) & COMMA) 'CostTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_VoucherDate)) & COMMA) 'VoucherDate, datetime, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CreatorID)) & COMMA) 'CreatorID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, False) & COMMA) 'Note, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, True) & COMMA) 'NoteU, nvarchar, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RecSourceID)) & COMMA)
            sSQL.Append(SQLNumber(tdbg(i, COL_AppNumber)) & COMMA)
            sSQL.Append(SQLNumber(tdbg(i, COL_PassNumber)) & COMMA)
            sSQL.Append(SQLString(IIf(tdbg(i, COL_CreateUserID).ToString = "", gsUserID, tdbg(i, COL_CreateUserID))) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append(IIf(tdbg(i, COL_CreateDate).ToString = "", "GetDate()", SQLDateTimeSave(tdbg(i, COL_CreateDate))).ToString & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            'sSQL.Append(SQLString(tdbg(i, COL_ProposalName)) & COMMA)
            sSQL.Append(SQLString(tdbg(i, COL_ProposalID)) & COMMA)
            'sSQL.Append(SQLString(tdbg(i, COL_RecPlanName)) & COMMA)
            sSQL.Append(SQLString(tdbg(i, COL_RecPlanID)) & COMMA)
            sSQL.Append(SQLString(tdbg(i, COL_RecruitmentFileID)))
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2091
    '# Created User: 
    '# Created Date: 06/07/2010 09:55:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2091() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2091"
        sSQL &= " Where CostTransID = " & SQLString(_costTransID)
        If _recruitmentFileID <> "" Then
            sSQL &= " or RecruitmentFileID = " & SQLString(_recruitmentFileID)
        End If
        Return sSQL
    End Function

#End Region

    Private Function FindRowDropdown(ByVal dtSource As DataTable, ByVal sFilter As String, ByVal sColName As String) As String
        Dim sName As String = ""
        If dtSource IsNot Nothing Then
            Dim drow() As DataRow = dtSource.Select(sFilter)
            If drow.Length > 0 Then
                sName = dtSource.Rows(dtSource.Rows.IndexOf(drow(0))).Item(sColName).ToString
            End If
        End If
        Return sName
    End Function

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        'If tdbg(e.Row, COL_ProposalName).ToString <> "" Then
        '    e.CellStyle.Locked = True
        '    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        'End If
    End Sub


    Private Sub HeadClick(ByVal icol As Integer)
        Select Case icol
            Case COL_CurrencyID
                CopyColumnArr(tdbg, icol, New Integer() {COL_ExchangeRate, COL_CCost})
                ResetGrid()
            Case COL_FromDate, COL_ToDate, COL_CostTypeID, COL_VoucherDate, COL_CreatorID, COL_Note
                CopyColumns(tdbg, icol, tdbg.Columns(icol).Text, tdbg.Row)
                'Case COL_OCost'bỏ
                '    CopyColumnArr(tdbg, icol, New Integer() {COL_CCost})
                '    ResetGrid()
            Case COL_RecCostName
                CopyColumnArr(tdbg, icol, New Integer() {COL_RecCostID})
        End Select

    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

#Region "Grid Events"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_RecSourceID
                If bNotInList Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_RecSourceID).Text = ""
                    bNotInList = False
                    Exit Select
                End If
            Case COL_CurrencyID
                tdbg.Columns(COL_ExchangeRate).Text = tdbdCurrencyID.Columns("ExchangeRate").Text
                tdbg.Columns(COL_CCost).Value = Number(tdbg.Columns(COL_OCost).Text) * Number(tdbg.Columns(COL_ExchangeRate).Text)
                tdbg.Columns(COL_CCost).FooterText = MyFooterSum(tdbg, COL_CCost, DxxFormat.D90_ConvertedDecimals)

            Case COL_ExchangeRate
                tdbg.Columns(COL_CCost).Value = Number(tdbg.Columns(COL_OCost).Text) * Number(tdbg.Columns(COL_ExchangeRate).Text)
                tdbg.Columns(COL_CCost).FooterText = MyFooterSum(tdbg, COL_CCost, DxxFormat.D90_ConvertedDecimals)

            Case COL_OCost
                tdbg.Columns(COL_CCost).Value = Number(tdbg.Columns(COL_OCost).Text) * Number(tdbg.Columns(COL_ExchangeRate).Text)
                tdbg.Columns(COL_CCost).FooterText = MyFooterSum(tdbg, COL_CCost, DxxFormat.D90_ConvertedDecimals)

            Case COL_ProposalName
                If bSelectValue Then
                    tdbg.Columns(COL_ProposalID).Text = ""
                    tdbg.Columns(COL_RecPlanID).Text = ""
                    tdbg.Columns(COL_ProposalName).Text = ""
                    tdbg.Columns(COL_RecPlanName).Text = ""
                    tdbg.Columns(COL_BlockID).Text = ""
                    tdbg.Columns(COL_BlockName).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_DepartmentName).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                    tdbg.Columns(COL_RecPositionID).Text = ""
                    tdbg.Columns(COL_RecPositionName).Text = ""
                    tdbg.Columns(COL_ProposalID).Text = ""
                    bSelectValue = False
                End If
            Case COL_RecruitmentFileID
                If bSelectValue Then
                    tdbg.Columns(COL_RecruitmentFileID).Text = ""
                    tdbg.Columns(COL_RecruitmentFileID).Value = ""
                    bSelectValue = False
                End If
                tdbg.Columns(COL_RecPlanName).Text = ""
                tdbg.Columns(COL_BlockID).Text = ""
                tdbg.Columns(COL_BlockName).Text = ""
                tdbg.Columns(COL_DepartmentID).Text = ""
                tdbg.Columns(COL_DepartmentName).Text = ""
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""
                tdbg.Columns(COL_RecPositionID).Text = ""
                tdbg.Columns(COL_RecPositionName).Text = ""
                tdbg.Columns(COL_ProposalName).Text = ""
            Case COL_RecPlanName
                If bSelectValue Then
                    tdbg.Columns(COL_RecPlanName).Text = ""
                    tdbg.Columns(COL_RecPlanID).Text = ""
                    bSelectValue = False
                End If
            Case COL_RecCostName
                If bSelectValue Then
                    tdbg.Columns(COL_RecCostName).Text = ""
                    tdbg.Columns(COL_RecCostID).Text = ""
                    bSelectValue = False
                End If
            Case COL_FromDate
                tdbg.Columns(COL_FromDate).Value = tdbg.Columns(COL_FromDate).Text
                'LoadTDBDProReferenceNo()
                'LoadTDBDPlanReferenceNo()
                tdbg.Select()
            Case COL_ToDate
                tdbg.Columns(COL_ToDate).Value = tdbg.Columns(COL_ToDate).Text
                'LoadTDBDProReferenceNo()
                'LoadTDBDPlanReferenceNo()
                tdbg.Select()
            Case COL_VoucherDate
                tdbg.Select()
        End Select

        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_RecCostID)
        FooterSumNew(tdbg, COL_CCost)
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        ResetGrid()
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case e.ColIndex
            Case COL_CurrencyID, COL_ExchangeRate, COL_OCost

                If tdbg.Columns(COL_CurrencyID).Text = "" Then
                    If e.ColIndex <> COL_CurrencyID And e.ColIndex <> COL_RecCostID Then
                        D99C0008.MsgNotYetEnter(rL3("Loai_tien"))
                        tdbg.Focus()
                        tdbg.Col = COL_CurrencyID
                        tdbg.Row = tdbg.Row
                        tdbg.SplitIndex = 0
                    End If
                    Exit Sub
                End If

                If tdbg.Columns(COL_ExchangeRate).Text = "" Then
                    If e.ColIndex <> COL_ExchangeRate And e.ColIndex <> COL_CurrencyID Then
                        D99C0008.MsgNotYetEnter(rL3("Ty_gia"))
                        tdbg.Focus()
                        tdbg.Col = COL_ExchangeRate
                        tdbg.Row = tdbg.Row
                        tdbg.SplitIndex = 0
                    End If
                    Exit Sub
                End If
            Case COL_RecPlanName, COL_TeamName, COL_DepartmentName, COL_BlockName, COL_RecPositionName
                If tdbg.Columns(COL_ProposalName).Text <> "" Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_RecSourceID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
            Case COL_RecCostName
                If tdbg.Columns(e.ColIndex).Text <> tdbdRecCostID.Columns(tdbdRecCostID.DisplayMember).Text Then
                    tdbg.Columns(COL_RecCostID).Text = ""
                    tdbg.Columns(COL_RecCostName).Text = ""
                    bSelectValue = True
                End If
            Case COL_CurrencyID
                If tdbg.Columns(COL_CurrencyID).Text <> tdbdCurrencyID.Columns("CurrencyID").Text Then
                    tdbg.Columns(COL_CurrencyID).Text = ""
                    tdbg.Columns(COL_ExchangeRate).Text = ""
                End If
            Case COL_OCost
                If Not L3IsNumeric(tdbg.Columns(COL_OCost).Text, EnumDataType.Money) Then e.Cancel = True
            Case COL_CCost
                If Not L3IsNumeric(tdbg.Columns(COL_CCost).Text, EnumDataType.Money) Then e.Cancel = True

            Case COL_BlockName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(COL_BlockID).Text = ""
                    tdbg.Columns(COL_BlockName).Text = ""
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_DepartmentName).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                End If

            Case COL_DepartmentName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_DepartmentName).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                End If

            Case COL_TeamName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(COL_TeamID).Text = ""
                    tdbg.Columns(COL_TeamName).Text = ""
                End If
            Case COL_RecPositionName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(COL_RecPositionID).Text = ""
                    tdbg.Columns(COL_RecPositionName).Text = ""
                End If
            Case COL_CostTypeID
                If tdbg.Columns(COL_CostTypeID).Text <> tdbdCostTypeID.Columns("CostTypeID").Text Then
                    tdbg.Columns(COL_CostTypeID).Text = ""
                End If
            Case COL_CreatorID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    'bNotInList = True
                End If
                'If tdbg.Columns(COL_CreatorID).Text <> tdbdCreatorID.Columns("EmployeeID").Text Then
                '    tdbg.Columns(COL_CreatorID).Text = ""
                'End If
            Case COL_ProposalName
                If tdbg.Columns(COL_ProposalName).Text <> tdbdProReferenceNo.Columns("ProReferenceNo").Text Then
                    tdbg.Columns(COL_ProposalName).Text = ""
                    tdbg.Columns(COL_RecPlanName).Text = ""
                    tdbg.Columns(COL_ProposalID).Text = ""
                    tdbg.Columns(COL_RecPlanID).Text = ""
                End If
                If tdbg.Columns(COL_ProposalName).Text = "" Then
                    bSelectValue = True
                End If
                tdbg.Splits(1).DisplayColumns(COL_RecPlanName).Button = True
                tdbg.Splits(1).DisplayColumns(COL_BlockName).Button = True
                tdbg.Splits(1).DisplayColumns(COL_DepartmentName).Button = True
                tdbg.Splits(1).DisplayColumns(COL_TeamName).Button = True
                tdbg.Splits(1).DisplayColumns(COL_RecPositionName).Button = True
            Case COL_RecruitmentFileID
                If tdbg.Columns(COL_RecruitmentFileID).Text <> tdbdRecruitmentFileID.Columns("VoucherNo").Text Then
                    tdbg.Columns(COL_RecruitmentFileID).Text = ""
                    tdbg.Columns(COL_ProposalID).Text = ""
                    tdbg.Columns(COL_RecPlanID).Text = ""
                End If
                If tdbg.Columns(COL_RecruitmentFileID).Text = "" Then
                    bSelectValue = True
                End If
            Case COL_RecPlanName
                If tdbg.Columns(COL_RecPlanName).Text <> tdbdPlanReferenceNo.Columns("PlanReferenceNo").Text Then
                    tdbg.Columns(COL_RecPlanName).Text = ""
                    tdbg.Columns(COL_RecPlanID).Text = ""
                End If
                If tdbg.Columns(COL_RecPlanName).Text = "" Then
                    bSelectValue = True
                End If
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
        '--- Gán giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_CurrencyID
                tdbg.Columns(COL_ExchangeRate).Text = tdbdCurrencyID.Columns("ExchangeRate").Text
                tdbg.Columns(COL_CCost).Value = Number(tdbg.Columns(COL_OCost).Text) * Number(tdbg.Columns(COL_ExchangeRate).Text)
            Case COL_BlockName
                tdbg.Columns(COL_BlockID).Text = tdbdBlockID.Columns("BlockID").Text
                tdbg.Columns(COL_DepartmentID).Text = ""
                tdbg.Columns(COL_DepartmentName).Text = ""
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""

                If tdbg.Columns(COL_VoucherDate).Text = "" Then tdbg.Columns(COL_VoucherDate).Text = Now.ToString

            Case COL_DepartmentName
                tdbg.Columns(COL_DepartmentID).Text = tdbdDepartmentID.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""

                If tdbg.Columns(COL_VoucherDate).Text <> "" Then tdbg.Columns(COL_VoucherDate).Text = Now.ToString

            Case COL_TeamName
                tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns("TeamID").Text
            Case COL_RecCostName
                tdbg.Columns(COL_RecCostID).Text = tdbdRecCostID.Columns("RecCostID").Text
            Case COL_RecPositionName
                tdbg.Columns(COL_RecPositionID).Text = tdbdRecPositionID.Columns("RecPositionID").Text

            Case COL_ProposalName
                tdbg.Columns(COL_ProposalID).Text = tdbdProReferenceNo.Columns("TransID").Text 'FindRowDropdown(CType(tdbdProReferenceNo.DataSource, DataTable), "ProReferenceNo = " & SQLString(tdbdProReferenceNo.Columns("ProReferenceNo").Text), "TransID")

                tdbg.Columns(COL_RecPlanName).Text = FindRowDropdown(CType(tdbdPlanReferenceNo.DataSource, DataTable), "TransID = " & SQLString(tdbdProReferenceNo.Columns("PlanTransID").Text), "PlanReferenceNo")
                tdbg.Columns(COL_RecPlanID).Text = FindRowDropdown(CType(tdbdPlanReferenceNo.DataSource, DataTable), "TransID = " & SQLString(tdbdProReferenceNo.Columns("PlanTransID").Text), "TransID")

                tdbg.Columns(COL_BlockID).Text = tdbdProReferenceNo.Columns("BlockID").Text
                tdbg.Columns(COL_BlockName).Text = FindRowDropdown(CType(tdbdBlockID.DataSource, DataTable), "BlockID = " & SQLString(tdbg.Columns(COL_BlockID).Text), "BlockName")

                LoadTdbdDepartmentID()
                tdbg.Columns(COL_DepartmentID).Text = tdbdProReferenceNo.Columns("DepartmentID").Text
                tdbg.Columns(COL_DepartmentName).Text = FindRowDropdown(CType(tdbdDepartmentID.DataSource, DataTable), "DepartmentID = " & SQLString(tdbg.Columns(COL_DepartmentID).Text), "DepartmentName")

                LoadtdbdTeamID()
                tdbg.Columns(COL_TeamID).Text = tdbdProReferenceNo.Columns("TeamID").Text
                tdbg.Columns(COL_TeamName).Text = FindRowDropdown(CType(tdbdTeamID.DataSource, DataTable), "TeamID = " & SQLString(tdbg.Columns(COL_TeamID).Text), "TeamName")

                tdbg.Columns(COL_RecPositionID).Text = tdbdProReferenceNo.Columns("RecPositionID").Text
                tdbg.Columns(COL_RecPositionName).Text = FindRowDropdown(CType(tdbdRecPositionID.DataSource, DataTable), "RecPositionID = " & SQLString(tdbg.Columns(COL_RecPositionID).Text), "RecPositionName")

            Case COL_RecPlanName
                tdbg.Columns(COL_BlockID).Text = tdbdPlanReferenceNo.Columns("BlockID").Text
                tdbg.Columns(COL_BlockName).Text = FindRowDropdown(CType(tdbdBlockID.DataSource, DataTable), "BlockID = " & SQLString(tdbg.Columns(COL_BlockID).Text), "BlockName")

                LoadTdbdDepartmentID()
                tdbg.Columns(COL_DepartmentID).Text = tdbdPlanReferenceNo.Columns("DepartmentID").Text
                tdbg.Columns(COL_DepartmentName).Text = FindRowDropdown(CType(tdbdDepartmentID.DataSource, DataTable), "DepartmentID = " & SQLString(tdbg.Columns(COL_DepartmentID).Text), "DepartmentName")

                LoadtdbdTeamID()
                tdbg.Columns(COL_TeamID).Text = tdbdPlanReferenceNo.Columns("TeamID").Text
                tdbg.Columns(COL_TeamName).Text = FindRowDropdown(CType(tdbdTeamID.DataSource, DataTable), "TeamID = " & SQLString(tdbg.Columns(COL_TeamID).Text), "TeamName")

                tdbg.Columns(COL_RecPositionID).Text = tdbdPlanReferenceNo.Columns("PositionID").Text
                tdbg.Columns(COL_RecPositionName).Text = FindRowDropdown(CType(tdbdRecPositionID.DataSource, DataTable), "RecPositionID = " & SQLString(tdbg.Columns(COL_RecPositionID).Text), "RecPositionName")

                tdbg.Columns(COL_RecPlanID).Text = tdbdPlanReferenceNo.Columns("TransID").Text
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_DepartmentName
                LoadTdbdDepartmentID()
            Case COL_TeamName
                LoadtdbdTeamID()
            Case COL_ProposalName, COL_RecPlanName
                If tdbg.Columns(COL_ProposalName).Text <> "" Then
                    tdbg.Splits(1).DisplayColumns(COL_RecPlanName).Button = False
                    tdbg.Splits(1).DisplayColumns(COL_BlockName).Button = False
                    tdbg.Splits(1).DisplayColumns(COL_DepartmentName).Button = False
                    tdbg.Splits(1).DisplayColumns(COL_TeamName).Button = False
                    tdbg.Splits(1).DisplayColumns(COL_RecPositionName).Button = False
                Else
                    tdbg.Splits(1).DisplayColumns(COL_RecPlanName).Button = True
                    tdbg.Splits(1).DisplayColumns(COL_BlockName).Button = True
                    tdbg.Splits(1).DisplayColumns(COL_DepartmentName).Button = True
                    tdbg.Splits(1).DisplayColumns(COL_TeamName).Button = True
                    tdbg.Splits(1).DisplayColumns(COL_RecPositionName).Button = True
                End If
                If tdbg.Col = COL_ProposalName Then LoadTDBDProReferenceNo(tdbg(tdbg.Row, COL_RecPlanID).ToString)
        End Select
    End Sub

    Private Sub tdbdRecCostID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbdRecCostID.KeyDown
        Select Case e.KeyCode
            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                tdbg.Splits(SPLIT1).DisplayColumns(COL_RecCostID).AutoComplete = False
            Case Else
                tdbg.Splits(SPLIT1).DisplayColumns(COL_RecCostID).AutoComplete = True
        End Select
    End Sub

    Private Sub tdbdCreatorID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbdCreatorID.KeyDown
        Select Case e.KeyCode
            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                tdbg.Splits(SPLIT1).DisplayColumns(COL_CreatorID).AutoComplete = False
            Case Else
                tdbg.Splits(SPLIT1).DisplayColumns(COL_CreatorID).AutoComplete = True
        End Select
    End Sub

    Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            If tdbg.Col = COL_Note Then
                HotKeyEnterGrid(tdbg, COL_RecCostID, e)
            End If
        End If

        Select Case tdbg.Col
            Case COL_RecCostID ', COL_CreatorID
                Select Case e.KeyCode
                    Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                        tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).AutoComplete = False
                    Case Else
                        tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).AutoComplete = True
                End Select
        End Select

        If e.KeyCode = Keys.F7 Then
            Select Case tdbg.Col
                Case COL_RecCostID
                    If HotKeyF7_ColDepend(tdbg) Then tdbg.Columns(COL_Description).Text = tdbg(tdbg.Row - 1, COL_Description).ToString

                Case COL_Description
                    If tdbg(tdbg.Row, COL_RecCostID).ToString = "" Then
                    Else
                        HotKeyF7(tdbg)
                    End If

                Case COL_CurrencyID
                    If tdbg(tdbg.Row, COL_RecCostID).ToString = "" Then
                    Else
                        If HotKeyF7_ColDepend(tdbg) Then
                            tdbg.Columns(COL_ExchangeRate).Text = tdbg(tdbg.Row - 1, COL_ExchangeRate).ToString
                            tdbg.Columns(COL_CCost).Value = Number(tdbg.Columns(COL_OCost).Text) * Number(tdbg.Columns(COL_ExchangeRate).Text)
                            tdbg.Columns(COL_CCost).FooterText = MyFooterSum(tdbg, COL_CCost, DxxFormat.D90_ConvertedDecimals)
                        End If
                    End If

                Case COL_ExchangeRate
                    If tdbg(tdbg.Row, COL_RecCostID).ToString = "" Or tdbg(tdbg.Row, COL_CurrencyID).ToString = "" Then
                    Else
                        HotKeyF7(tdbg)
                        tdbg.Columns(COL_CCost).Value = Number(tdbg.Columns(COL_OCost).Text) * Number(tdbg.Columns(COL_ExchangeRate).Text)
                        tdbg.Columns(COL_CCost).FooterText = MyFooterSum(tdbg, COL_CCost, DxxFormat.D90_ConvertedDecimals)
                    End If

                Case COL_OCost
                    If tdbg(tdbg.Row, COL_RecCostID).ToString = "" Or tdbg(tdbg.Row, COL_CurrencyID).ToString = "" Or tdbg(tdbg.Row, COL_ExchangeRate).ToString = "" Then
                    Else
                        HotKeyF7(tdbg)
                        tdbg.Columns(COL_CCost).Value = Number(tdbg.Columns(COL_OCost).Text) * Number(tdbg.Columns(COL_ExchangeRate).Text)
                        tdbg.Columns(COL_CCost).FooterText = MyFooterSum(tdbg, COL_CCost, DxxFormat.D90_ConvertedDecimals)

                    End If

                Case COL_CCost 'not F7

                Case COL_FromDate, COL_ToDate
                    If tdbg(tdbg.Row, COL_RecCostID).ToString = "" Or tdbg(tdbg.Row, COL_CurrencyID).ToString = "" Or tdbg(tdbg.Row, COL_ExchangeRate).ToString = "" Or tdbg(tdbg.Row, COL_OCost).ToString = "" Then
                    Else
                        HotKeyF7(tdbg)
                    End If

                Case Else
                    HotKeyF7(tdbg)

            End Select
            ResetGrid()
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbg)
            tdbg.Columns(COL_CostTransID).Text = ""
            tdbg.Columns(COL_CCost).FooterText = MyFooterSum(tdbg, COL_CCost, DxxFormat.D90_ConvertedDecimals)
            ResetGrid()
        Else
            HotKeyDownGrid(e, tdbg, COL_RecCostID)
        End If

        If e.Control And e.KeyCode = Keys.S Then
            HeadClick(tdbg.Col)
        End If
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1041
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 01/07/2014 02:57:48
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1041() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi khi Chon de xuat tuyen dung" & vbCrlf)
        sSQL &= "Exec D25P1041 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_recruitmentFileID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(3) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        If Not bLoadD25F2090 Then vcNewTemp = vcNew
        bLoadD25F2090 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************

        Dim f As New D25F2020
        With f
            .FormID = Me.Name
            .VoucherID = _recruitmentFileID
            .ShowDialog()
            If .Chose Then dtGrid = ReturnDataTable(SQLStoreD25P1041) : LoadTDBGrid()
            .Dispose()
        End With
    End Sub

    Dim bNotInList As Boolean = False

    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs)

    End Sub
End Class