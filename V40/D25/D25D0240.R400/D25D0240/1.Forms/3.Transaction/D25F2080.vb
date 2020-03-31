Imports System
Public Class D25F2080
    Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
    End Property

    Private _formID As String = ""
    Public WriteOnly Property FormID As String
        Set(ByVal Value As String)
            _formID = Value
        End Set
    End Property

    Dim iPerD25F5601 As Integer = ReturnPermission("D25F5601")

#Region "Const of tdbg - Total of Columns: 42"
    Private Const COL_TransID As String = "TransID"                 ' TransID
    Private Const COL_IsApprove As String = "IsApprove"             ' Duyệt
    Private Const COL_BlockID As String = "BlockID"                 ' BlockID
    Private Const COL_BlockName As String = "BlockName"             ' Khối
    Private Const COL_DepartmentID As String = "DepartmentID"       ' DepartmentID
    Private Const COL_DepartmentName As String = "DepartmentName"   ' Phòng ban
    Private Const COL_TeamID As String = "TeamID"                   ' TeamID
    Private Const COL_TeamName As String = "TeamName"               ' Tổ nhóm
    Private Const COL_RecPositionID As String = "RecPositionID"     ' RecPositionID
    Private Const COL_RecPositionName As String = "RecPositionName" ' Chức vụ
    Private Const COL_WorkID As String = "WorkID"                   ' WorkID
    Private Const COL_WorkName As String = "WorkName"               ' Vị trí/công việc
    Private Const COL_PlanStatusID As String = "PlanStatusID"       ' PlanStatusID
    Private Const COL_PlanStatusName As String = "PlanStatusName"   ' Trạng thái
    Private Const COL_EmployeeQTY As String = "EmployeeQTY"         ' Định mức
    Private Const COL_PresentQuan As String = "PresentQuan"         ' SL hiện tại
    Private Const COL_PlanQuan As String = "PlanQuan"               ' SL đã lập kế hoạch
    Private Const COL_RemainQuan As String = "RemainQuan"           ' SL còn lại
    Private Const COL_Number As String = "Number"                   ' Số lượng
    Private Const COL_DateFrom As String = "DateFrom"               ' Từ ngày
    Private Const COL_DateTo As String = "DateTo"                   ' Đến ngày
    Private Const COL_VoucherDate As String = "VoucherDate"         ' Ngày lập
    Private Const COL_CreatorID As String = "CreatorID"             ' Người lập
    Private Const COL_Description As String = "Description"         ' Diễn giải
    Private Const COL_ReferenceNo As String = "ReferenceNo"         ' Số tham chiếu
    Private Const COL_Ref01 As String = "Ref01"                     ' Ref01
    Private Const COL_Ref02 As String = "Ref02"                     ' Ref02
    Private Const COL_Ref03 As String = "Ref03"                     ' Ref03
    Private Const COL_Ref04 As String = "Ref04"                     ' Ref04
    Private Const COL_Ref05 As String = "Ref05"                     ' Ref05
    Private Const COL_Ref06 As String = "Ref06"                     ' Ref06
    Private Const COL_Ref07 As String = "Ref07"                     ' Ref07
    Private Const COL_Ref08 As String = "Ref08"                     ' Ref08
    Private Const COL_Ref09 As String = "Ref09"                     ' Ref09
    Private Const COL_Ref10 As String = "Ref10"                     ' Ref10
    Private Const COL_xxx As String = "xxx"                         ' xxx
    Private Const COL_Note As String = "Note"                       ' Ghi chú
    Private Const COL_ApproveNumber As String = "ApproveNumber"     ' SL duyệt
    Private Const COL_ApprovedDate As String = "ApprovedDate"       ' Ngày duyệt
    Private Const COL_ApproverID As String = "ApproverID"           ' Người duyệt
    Private Const COL_ApproveNotes As String = "ApproveNotes"       ' Ghi chú duyệt
    Private Const COL_CreatorName As String = "CreatorName"         ' CreatorName
#End Region

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Dim iOldNumber As Double = 0

    Dim dtEmployeeQTYDepartment As DataTable
    Dim dtEmployeeQTYTeam As DataTable
    Dim dtEmployeeQTYDuty As DataTable
    Dim dtEmployeeQTY As DataTable

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            LoadTDBDropDown()
            If Not D25Systems.IsUseBlock Then    'neu IsUseBlock = 0 thi an cot COL_BlockID va COL_BlockName
                tdbg.Splits(0).DisplayColumns.Item(COL_BlockID).Visible = False
                tdbg.Splits(0).DisplayColumns.Item(COL_BlockName).Visible = False
                LoadTdbdDepartmentID()
            End If
            _bSaved = False
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = False
                Case EnumFormState.FormEdit
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_ReferenceNo).Locked = True
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_ReferenceNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                Case EnumFormState.FormOther
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                Case EnumFormState.FormView
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False
                Case EnumFormState.FormApprove 'ID 90425 07/11/2016
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
            End Select
            '***********************
            If _FormState = EnumFormState.FormEdit OrElse _FormState = EnumFormState.FormView OrElse _FormState = EnumFormState.FormApprove Then
                tdbg.AllowAddNew = False
                tdbg.AllowDelete = False
            End If
        End Set
    End Property

    Private _transID As String = ""
    Public Property TransID() As String
        Get
            Return _transID
        End Get
        Set(ByVal Value As String)
            _transID = Value
        End Set
    End Property

    Private Sub D25F2080_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D25F2080_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Hỏi trước khi đóng 
        If _FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormOther Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If btnSave.Enabled Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        End If
    End Sub

    Private Sub D25F2080_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If D25Options.UseEnterAsTab And e.KeyCode = Keys.Enter Then
            'UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        End If
        Select Case e.KeyCode
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddNumberColumns(arr, SqlDbType.Int, tdbg.Columns(COL_EmployeeQTY).DataField, "N2")
        AddNumberColumns(arr, SqlDbType.Int, tdbg.Columns(COL_PresentQuan).DataField, "N2")
        AddNumberColumns(arr, SqlDbType.Int, tdbg.Columns(COL_PlanQuan).DataField, "N2")
        AddNumberColumns(arr, SqlDbType.Int, tdbg.Columns(COL_RemainQuan).DataField, "N2")
        AddNumberColumns(arr, SqlDbType.Int, tdbg.Columns(COL_Number).DataField, "N2")
        AddNumberColumns(arr, SqlDbType.Int, tdbg.Columns(COL_ApproveNumber).DataField, "N2")

        InputNumber(tdbg, arr)
    End Sub
    Private Sub tdbg_LockedColumns()
        If _FormState = EnumFormState.FormApprove Then 'ID 	90425 04/11/2016
            For i As Integer = IndexOfColumn(tdbg, COL_BlockName) To IndexOfColumn(tdbg, COL_PlanStatusName)
                tdbg.Splits(0).DisplayColumns(i).Locked = True
                tdbg.Splits(0).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            Next
            For i As Integer = IndexOfColumn(tdbg, COL_EmployeeQTY) To IndexOfColumn(tdbg, COL_Note)
                tdbg.Splits(1).DisplayColumns(i).Locked = True
                tdbg.Splits(1).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            Next
        Else
            tdbg.Splits(SPLIT1).DisplayColumns(COL_EmployeeQTY).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COL_PresentQuan).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COL_PlanQuan).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT1).DisplayColumns(COL_RemainQuan).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End If

        If iPerD25F5601 <= 1 Then
            tdbg.Splits(0).DisplayColumns(COL_IsApprove).Locked = True
            tdbg.Splits(0).DisplayColumns(COL_IsApprove).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            For i As Integer = IndexOfColumn(tdbg, COL_ApproveNumber) To IndexOfColumn(tdbg, COL_ApproveNotes)
                tdbg.Splits(2).DisplayColumns(i).Locked = True
                tdbg.Splits(2).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            Next
        End If
    End Sub

    Private Sub D25F2080_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        SetBackColorObligatory()
        Loadlanguage()
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        LoadTDBGrid()
        If _FormState = EnumFormState.FormOther Then iOldNumber = Number(tdbg(0, COL_Number))
        tdbg_LockedColumns()

        LoadRefCaption()
        InputDateInTrueDBGrid(tdbg, COL_DateFrom, COL_DateTo, COL_VoucherDate, COL_ApprovedDate)
        GetTextCreateByNew(tdbg, IndexOfColumn(tdbg, COL_CreatorID), 1)
        InputbyUnicode(Me, gbUnicode)
        CallD99U1111()
        SetResolutionForm(Me)
    End Sub
    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Lap_ke_hoach_tong_theF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'rl3("Lap_ke_hoach_tuyen_dung_-_D25F2080") & UnicodeCaption(gbUnicode) 'LËp kÕ hoÁch tuyÓn dóng - D25F2080
        '================================================================ 
        btnSave.Text = rL3("_Luu") '&Lưu
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnNext.Text = rL3("_Nhap_tiep") 'Nhập &tiếp
        btnF12.Text = rL3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        ' btnPrint.Text = rl3("_In") '&In
        '================================================================ 
        tdbdRecPositionID.Columns("PositionID").Caption = rL3("Ma") 'Mã
        tdbdRecPositionID.Columns("PositionName").Caption = rL3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbdDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbdBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbdBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
        tdbdEmployeeID.Columns("EmployeeID").Caption = rL3("Ma") 'Mã
        tdbdEmployeeID.Columns("EmployeeName").Caption = rL3("Ten") 'Tên
        tdbdWorkID.Columns("WorkID").Caption = rL3("Ma") 'Mã
        tdbdWorkID.Columns("WorkName").Caption = rL3("Ten") 'Tên
        tdbdApproverID.Columns("EmployeeID").Caption = rL3("Ma") 'Mã
        tdbdApproverID.Columns("EmployeeName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_IsApprove).Caption = rL3("Duyet") 'Duyệt
        tdbg.Columns(COL_BlockName).Caption = rL3("Khoi") 'Khối
        tdbg.Columns(COL_DepartmentName).Caption = rL3("Phong_ban") 'Phòng ban
        tdbg.Columns(COL_TeamName).Caption = rL3("To_nhom") 'Tổ nhóm
        tdbg.Columns(COL_RecPositionName).Caption = rL3("Chuc_vu") 'Chức vụ
        tdbg.Columns(COL_WorkName).Caption = rL3("Vi_tricong_viec") 'Vị trí/công việc
        tdbg.Columns(COL_PlanStatusName).Caption = rL3("Trang_thai") 'Trạng thái
        tdbg.Columns(COL_EmployeeQTY).Caption = rL3("Dinh_muc") 'Định mức
        tdbg.Columns(COL_PresentQuan).Caption = rL3("SL_hien_tai") 'SL hiện tại
        tdbg.Columns(COL_PlanQuan).Caption = rL3("SL_da_lap_ke_hoach") 'SL đã lập kế hoạch
        tdbg.Columns(COL_RemainQuan).Caption = rL3("SL_con_lai") 'SL còn lại
        tdbg.Columns(COL_Number).Caption = rL3("So_luong") 'Số lượng
        tdbg.Columns(COL_DateFrom).Caption = rL3("Tu_ngay") 'Từ ngày
        tdbg.Columns(COL_DateTo).Caption = rL3("Den_ngay") 'Đến ngày
        tdbg.Columns(COL_VoucherDate).Caption = rL3("Ngay_lap") 'Ngày lập
        tdbg.Columns(COL_CreatorID).Caption = rL3("Nguoi_lap") 'Người lập
        tdbg.Columns(COL_Description).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_ReferenceNo).Caption = rL3("So_tham_chieu") 'Số tham chiếu
        tdbg.Columns(COL_Note).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_IsApprove).Caption = rL3("Duyet") 'Duyệt
        tdbg.Columns(COL_ApproveNumber).Caption = rL3("SL_duyet") 'SL duyệt
        tdbg.Columns(COL_ApprovedDate).Caption = rL3("Ngay_duyet") 'Ngày duyệt
        tdbg.Columns(COL_ApproverID).Caption = rL3("Nguoi_duyet") 'Người duyệt
        tdbg.Columns(COL_ApproveNotes).Caption = rL3("Ghi_chu_duyet") 'Ghi chú duyệt
    End Sub
    Private Sub SetBackColorObligatory()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Number).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DateFrom).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DateTo).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT1).DisplayColumns(COL_VoucherDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ApproveNumber).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ApprovedDate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ApproverID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Dim dtGrid As DataTable
    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD25P2080()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_DepartmentName)
        FooterSumNew(tdbg, COL_Number, COL_EmployeeQTY, COL_ApproveNumber)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2081
    '# Created User: DUCTRONG
    '# Created Date: 07/08/2008 09:48:07
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2081() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2081"
        sSQL &= " Where GeneralPlanID = " & SQLString(_transID)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2081s
    '# Created User: DUCTRONG
    '# Created Date: 07/08/2008 09:46:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2081s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sTranID As String = ""
        Dim iCountIGE As Int32 = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1
            If _FormState = EnumFormState.FormOther Then '' neu truong hop tach ma i= 0 thi ko lam ji ca
                If i = 0 Then
                    Continue For
                Else        '' neu i khac 0 thi xoa het cac dong <> 0

                    sSQL.Append("Delete D25T2081 where TransID = " & SQLString(tdbg(i, COL_TransID).ToString & vbCrLf))
                End If
            End If
            If tdbg(i, COL_TransID).ToString = "" Then
                sTranID = CreateIGEs("D25T2081", "TransID", "25", "GP", gsStringKey, sTranID, iCountIGE)
                tdbg(i, COL_TransID) = sTranID
            End If

            sSQL.Append("Insert Into D25T2081(")
            sSQL.Append("CreatorID, TransID, DivisionID, BlockID, DepartmentID, TeamID, ")
            sSQL.Append("PositionID, Description, Ref01, Ref02, Ref03, Ref04, ")
            sSQL.Append("Ref05, Ref06, Ref07, Ref08, Ref09, ")
            sSQL.Append("Ref10, Number, DateFrom, DateTo, Note,")
            sSQL.Append("CreateDate, CreateUserID, LastModifyDate, LastModifyUserID, ")
            sSQL.Append("TranMonth, TranYear, VoucherDate, IsApprove, ApprovedDate, ApproverID, ApproveNumber, ApproveNotesU, ")
            sSQL.Append("DescriptionU, Ref01U, Ref02U, Ref03U, Ref04U, ")
            sSQL.Append("Ref05U, Ref06U, Ref07U, Ref08U, Ref09U, ")
            sSQL.Append("Ref10U, NoteU, ReferenceNo, WorkID,PlanStatusID")
            sSQL.Append(") Values(")

            sSQL.Append(SQLString(tdbg(i, COL_CreatorID)) & COMMA)
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BlockID)) & COMMA)
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RecPositionID)) & COMMA) 'PositionID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, False) & COMMA) 'Description, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref01), gbUnicode, False) & COMMA) 'Ref01, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref02), gbUnicode, False) & COMMA) 'Ref02, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref03), gbUnicode, False) & COMMA) 'Ref03, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref04), gbUnicode, False) & COMMA) 'Ref04, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref05), gbUnicode, False) & COMMA) 'Ref05, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref06), gbUnicode, False) & COMMA) 'Ref06, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref07), gbUnicode, False) & COMMA) 'Ref07, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref08), gbUnicode, False) & COMMA) 'Ref08, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref09), gbUnicode, False) & COMMA) 'Ref09, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref10), gbUnicode, False) & COMMA) 'Ref10, varchar[50], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_Number)) & COMMA) 'Number, int, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateFrom)) & COMMA)
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateTo)) & COMMA)
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, False) & COMMA)
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_VoucherDate)) & COMMA) 'VoucherDate, datetime, NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_IsApprove)) & COMMA) 'IsApprove, int, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_ApprovedDate)) & COMMA) 'ApprovedDate, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COL_ApproverID)) & COMMA) 'ApproverID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_ApproveNumber)) & COMMA) 'ApproveNumber, int, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_ApproveNotes), gbUnicode, True) & COMMA) 'ApproveNotesU, nvarchar, NOT NULL

            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, True) & COMMA) 'DescriptionU, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref01), gbUnicode, True) & COMMA) 'Ref01U, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref02), gbUnicode, True) & COMMA) 'Ref02U, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref03), gbUnicode, True) & COMMA) 'Ref03U, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref04), gbUnicode, True) & COMMA) 'Ref04U, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref05), gbUnicode, True) & COMMA) 'Ref05U, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref06), gbUnicode, True) & COMMA) 'Ref06U, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref07), gbUnicode, True) & COMMA) 'Ref07U, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref08), gbUnicode, True) & COMMA) 'Ref08U, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref09), gbUnicode, True) & COMMA) 'Ref09U, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Ref10), gbUnicode, True) & COMMA) 'Ref10U, nvarchar, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, True) & COMMA) 'NoteU, nvarchar, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ReferenceNo)) & COMMA)
            sSQL.Append(SQLString(tdbg(i, COL_WorkID)) & COMMA) 'WorkID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PlanStatusID))) 'PlanStatusID, varchar[50], NOT NULL   IncidentID	49499
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg.UpdateData()
        Dim dr() As DataRow = Nothing
        If _FormState = EnumFormState.FormApprove Then 'ID 	90425 07/11/2016
            If Not AllowApproved(dr) Then Exit Sub
        Else
            If Not AllowSave() Then Exit Sub
        End If

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD25T2081s().ToString)
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T2081s().ToString)
            Case EnumFormState.FormApprove
                sSQL.Append(SQLUpdateD25T2081s_Approved(dr).ToString)
            Case EnumFormState.FormOther
                If Number(tdbg(0, COL_Number)) = 0 Then
                    sSQL.Append("Delete D25T2081 where TransID = " & SQLString(tdbg(0, COL_TransID)))
                Else
                    sSQL.Append(SQLUpdateD25T2081s().ToString)
                End If
                sSQL.Append(SQLInsertD25T2081s().ToString)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            'LoadTDBGrid()

            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    'btnPrint.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit, EnumFormState.FormApprove
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
            If tdbg(i, COL_BlockName).ToString = "" And D25Systems.IsUseBlock Then
                D99C0008.MsgNotYetEnter(rL3("Khoi"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = IndexOfColumn(tdbg, COL_BlockName)
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_DepartmentName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Phong_ban"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = IndexOfColumn(tdbg, COL_DepartmentName)
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_Number).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("So_luong"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = IndexOfColumn(tdbg, COL_Number)
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_DateFrom).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Tu_ngay"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = IndexOfColumn(tdbg, COL_DateFrom)
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_DateTo).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Den_ngay"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = IndexOfColumn(tdbg, COL_DateTo)
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_VoucherDate).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ngay_lap"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = IndexOfColumn(tdbg, COL_VoucherDate)
                tdbg.Bookmark = i
                'tdbg.Focus()
                Return False
            End If
           
            If _FormState = EnumFormState.FormAdd Or (_FormState = EnumFormState.FormOther And i > 0) Then
                If tdbg(i, COL_ReferenceNo).ToString <> "" Then
                    Dim sSQL As String = "Select top 1 1 from D25T2081 WITH(NOLOCK)  where ReferenceNo = " & SQLString(tdbg(i, COL_ReferenceNo).ToString)
                    Dim dtTemp As DataTable = ReturnDataTable(sSQL)
                    If dtTemp.Rows.Count > 0 Then
                        D99C0008.MsgL3(rL3("So_tham_chieu_nay_da_duoc_su_dung") & " " & rL3("Ban_khong_duoc_phep_luu"))
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT1
                        tdbg.Col = IndexOfColumn(tdbg, COL_ReferenceNo)
                        tdbg.Bookmark = i
                        'tdbg.Columns(COL_ReferenceNo).Editor.Focus()
                        Return False
                    End If
                End If
            End If

            'IncidentID 50585
            If L3Int(tdbg(i, COL_EmployeeQTY).ToString) <> 0 Then
                If L3Int(tdbg(i, COL_Number).ToString) > L3Int(tdbg(i, COL_RemainQuan).ToString) Then
                    If D99C0008.MsgAsk(rL3("So_luong_da_vuot_dinh_muc_thiet_lap_Ban_co_muon_luu_khong")) = Windows.Forms.DialogResult.No Then
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT1
                        tdbg.Col = IndexOfColumn(tdbg, COL_Number)
                        tdbg.Bookmark = i
                        Return False

                    End If
                End If
            End If
            If iPerD25F5601 >= 1 AndAlso L3Bool(tdbg(i, COL_IsApprove)) Then
                If tdbg(i, COL_ApproveNumber).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbg.Columns(COL_ApproveNumber).Caption)
                    tdbg.Focus()
                    tdbg.SplitIndex = 2
                    tdbg.Col = IndexOfColumn(tdbg, COL_ApproveNumber)
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
                If tdbg(i, COL_ApprovedDate).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbg.Columns(COL_ApprovedDate).Caption)
                    tdbg.Focus()
                    tdbg.SplitIndex = 2
                    tdbg.Col = IndexOfColumn(tdbg, COL_ApprovedDate)
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
                If tdbg(i, COL_ApproverID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbg.Columns(COL_ApproverID).Caption)
                    tdbg.Focus()
                    tdbg.SplitIndex = 2
                    tdbg.Col = IndexOfColumn(tdbg, COL_ApproverID)
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
            End If
        Next

        Return True
    End Function

    Private Function AllowApproved(ByRef dr() As DataRow) As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        dr = dtGrid.Select(COL_IsApprove & " = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = IndexOfColumn(tdbg, COL_IsApprove)
            tdbg.Row = 0
            Return False
        End If
        For i As Integer = 0 To dr.Length - 1
            If L3Int(dr(i).Item(COL_EmployeeQTY)) <> 0 Then
                If L3Int(dr(i).Item(COL_Number)) > L3Int(dr(i).Item(COL_RemainQuan)) Then
                    If D99C0008.MsgAsk(rL3("So_luong_da_vuot_dinh_muc_thiet_lap_Ban_co_muon_luu_khong")) = Windows.Forms.DialogResult.No Then
                        tdbg.Focus()
                        tdbg.SplitIndex = SPLIT1
                        tdbg.Col = IndexOfColumn(tdbg, COL_Number)
                        tdbg.Bookmark = i
                        Return False

                    End If
                End If
            End If
            '************************
            If iPerD25F5601 >= 1 Then
                If Number(dr(i).Item(COL_ApproveNumber)) = 0 Then
                    D99C0008.MsgNotYetEnter(tdbg.Columns(COL_ApproveNumber).Caption)
                    tdbg.Focus()
                    tdbg.SplitIndex = 2
                    tdbg.Col = IndexOfColumn(tdbg, COL_ApproveNumber)
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
                If dr(i).Item(COL_ApprovedDate).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbg.Columns(COL_ApprovedDate).Caption)
                    tdbg.Focus()
                    tdbg.SplitIndex = 2
                    tdbg.Col = IndexOfColumn(tdbg, COL_ApprovedDate)
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
                If dr(i).Item(COL_ApproverID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(tdbg.Columns(COL_ApproverID).Caption)
                    tdbg.Focus()
                    tdbg.SplitIndex = 2
                    tdbg.Col = IndexOfColumn(tdbg, COL_ApproverID)
                    tdbg.Row = i  'findrowInGrid(tdbg, xxxxKeyValue, xxxxFieldKey)
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2081s
    '# Created User: Kim Quang
    '# Created Date: 26/05/2010 11:24:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2081s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Update D25T2081 Set ")
            sSQL.Append("CreatorID = " & SQLString(tdbg(i, COL_CreatorID)) & COMMA)
            sSQL.Append("DepartmentID = " & SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("TeamID = " & SQLString(tdbg(i, COL_TeamID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("PositionID = " & SQLString(tdbg(i, COL_RecPositionID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("Description = " & SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, False) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("Ref01 = " & SQLStringUnicode(tdbg(i, COL_Ref01), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("Ref02 = " & SQLStringUnicode(tdbg(i, COL_Ref02), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("Ref03 = " & SQLStringUnicode(tdbg(i, COL_Ref03), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("Ref04 = " & SQLStringUnicode(tdbg(i, COL_Ref04), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("Ref05 = " & SQLStringUnicode(tdbg(i, COL_Ref05), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("Ref06 = " & SQLStringUnicode(tdbg(i, COL_Ref06), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("Ref07 = " & SQLStringUnicode(tdbg(i, COL_Ref07), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("Ref08 = " & SQLStringUnicode(tdbg(i, COL_Ref08), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("Ref09 = " & SQLStringUnicode(tdbg(i, COL_Ref09), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("Ref10 = " & SQLStringUnicode(tdbg(i, COL_Ref10), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("Number = " & SQLNumber(tdbg(i, COL_Number)) & COMMA) 'int, NOT NULL
            sSQL.Append("Note = " & SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("DateFrom = " & SQLDateSave(tdbg(i, COL_DateFrom)) & COMMA) 'datetime, NULL
            sSQL.Append("DateTo = " & SQLDateSave(tdbg(i, COL_DateTo)) & COMMA) 'datetime, NULL
            sSQL.Append("BlockID = " & SQLString(tdbg(i, COL_BlockID)) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
            sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
            sSQL.Append("VoucherDate = " & SQLDateSave(tdbg(i, COL_VoucherDate)) & COMMA) 'datetime, NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL

            sSQL.Append("IsApprove = " & SQLNumber(tdbg(i, COL_IsApprove)) & COMMA) 'ApproveNumber, int, NOT NULL
            sSQL.Append("ApprovedDate= " & SQLDateSave(tdbg(i, COL_ApprovedDate)) & COMMA) 'ApprovedDate, datetime, NULL
            sSQL.Append("ApproverID = " & SQLString(tdbg(i, COL_ApproverID)) & COMMA) 'ApproverID, varchar[20], NOT NULL
            sSQL.Append("ApproveNumber = " & SQLNumber(tdbg(i, COL_ApproveNumber)) & COMMA) 'ApproveNumber, int, NOT NULL
            sSQL.Append("ApproveNotesU = " & SQLStringUnicode(tdbg(i, COL_ApproveNotes), gbUnicode, True) & COMMA) 'ApproveNotesU, nvarchar, NOT NULL

            sSQL.Append("Ref01U = " & SQLStringUnicode(tdbg(i, COL_Ref01), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Ref02U = " & SQLStringUnicode(tdbg(i, COL_Ref02), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Ref03U = " & SQLStringUnicode(tdbg(i, COL_Ref03), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Ref04U = " & SQLStringUnicode(tdbg(i, COL_Ref04), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Ref05U = " & SQLStringUnicode(tdbg(i, COL_Ref05), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Ref06U = " & SQLStringUnicode(tdbg(i, COL_Ref06), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Ref07U = " & SQLStringUnicode(tdbg(i, COL_Ref07), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Ref08U = " & SQLStringUnicode(tdbg(i, COL_Ref08), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Ref09U = " & SQLStringUnicode(tdbg(i, COL_Ref09), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("Ref10U = " & SQLStringUnicode(tdbg(i, COL_Ref10), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("NoteU = " & SQLStringUnicode(tdbg(i, COL_Note), gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
            sSQL.Append("WorkID = " & SQLString(tdbg(i, COL_WorkID)) & COMMA) 'varchar[50], NOT NULL
            sSQL.Append("PlanStatusID = " & SQLString(tdbg(i, COL_PlanStatusID))) 'varchar[50], NOT NULL  IncidentID	49499
            sSQL.Append(" Where ")
            sSQL.Append("TransID = " & SQLString(tdbg(i, COL_TransID)))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2081s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 07/11/2016 12:07:34
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2081s_Approved(dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            If i = 0 Then sSQL.Append("-- Luu thong tin duyet" & vbCrLf)
            sSQL.Append("Update D25T2081 Set ")
            sSQL.Append("ApproveNumber = " & SQLNumber(dr(i).Item(COL_ApproveNumber)) & COMMA) 'int, NOT NULL
            sSQL.Append("ApprovedDate = " & SQLDateSave(dr(i).Item(COL_ApprovedDate)) & COMMA) 'datetime, NULL
            sSQL.Append("ApproveNotesU = " & SQLStringUnicode(dr(i).Item(COL_ApproveNotes), gbUnicode, True) & COMMA) 'nvarchar[1000], NOT NULL
            sSQL.Append("ApproverID = " & SQLStringUnicode(dr(i).Item(COL_ApproverID), gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
            sSQL.Append("IsApprove = " & SQLNumber(dr(i).Item(COL_IsApprove))) 'tinyint, NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("TransID = " & SQLString(dr(i).Item(COL_TransID)))

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


    Private Sub LoadRefCaption()
        Dim sSQL As String = SQLStoreD25P0050("D25T2001", gbUnicode)
        Dim dtSpec As DataTable= ReturnDataTable(sSQL)

        If dtSpec.Rows.Count <= 0 Then Exit Sub

        For i As Integer = 0 To 9
            Dim iCol As Integer = IndexOfColumn(tdbg, COL_Ref01)
            tdbg.Splits(SPLIT1).DisplayColumns(iCol + i).Visible = Not CBool(dtSpec.Rows(i).Item("Disabled").ToString)
            tdbg.Splits(SPLIT1).DisplayColumns(iCol + i).HeadingStyle.Font = FontUnicode(gbUnicode, tdbg.Splits(SPLIT1).DisplayColumns(iCol + i).HeadingStyle.Font.Style)
            tdbg.Columns(iCol + i).Caption = dtSpec.Rows(i).Item("RefCaption").ToString
        Next

    End Sub

    Dim dRemainQty As Double = -1

    Private Function CheckOverQuantity() As Boolean
        If _FormState <> EnumFormState.FormOther Then Return False

        Dim iNumber As Double = 0
        For i As Integer = 1 To tdbg.RowCount
            iNumber += Number(tdbg(i, COL_Number))
        Next

        dRemainQty = iOldNumber - iNumber
        If dRemainQty < 0 Then
            D99C0008.MsgL3(rl3("So_luong_khong_hop_leU"))
            tdbg.Focus()
            tdbg.Columns(COL_Number).Text = ""

            tdbg.SplitIndex = SPLIT1
            tdbg.Bookmark = tdbg.Row
            tdbg.Col = IndexOfColumn(tdbg, COL_Number)
            Return True
        End If
        Return False

    End Function

#Region "Tdbg"
    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If e.Row.Equals(0) = False Or _FormState <> EnumFormState.FormOther Then Exit Sub
        e.CellStyle.Locked = True
    End Sub

    Private Sub tdbg_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeDelete
        If tdbg.Row.Equals(0) = False Or _FormState <> EnumFormState.FormOther Then Exit Sub
        e.Cancel = True
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        resetGrid()
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case tdbg.Columns(e.ColIndex).DataField
            Case COL_BlockName, COL_DepartmentName, COL_TeamName, COL_RecPositionName, COL_Number, COL_DateFrom, COL_DateTo, COL_VoucherDate, COL_Note, COL_Ref01, COL_Ref02, COL_Ref03, COL_Ref04, COL_Ref05, COL_Ref06, COL_Ref07, COL_Ref08, COL_Ref09, COL_Ref10, COL_CreatorID
                If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
                    e.Cancel = True
                End If
                'If _FormState = EnumFormState.FormEdit And tdbg.Row <> 0 Then
                '    e.Cancel = True
                'End If
        End Select

    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case tdbg.Columns(e.ColIndex).DataField
            'Case COL_EmployeeQTY, COL_PresentQuan, COL_PlanQuan, COL_RemainQuan
            '    If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Int) Then tdbg.Columns(e.ColIndex).Text = ""

            Case COL_Number
                '  If Not L3IsNumeric(tdbg.Columns(COL_Number).Text, EnumDataType.Int) Then tdbg.Columns(e.ColIndex).Text = ""
                If tdbg.Row = 0 And _FormState = EnumFormState.FormOther Then Exit Sub
                If CheckOverQuantity() Then e.Cancel = True

            Case COL_BlockName, COL_DepartmentName, COL_TeamName, COL_RecPositionName, COL_WorkName, COL_PlanStatusName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If

            Case COL_CreatorID, COL_ApproverID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
            Case COL_ReferenceNo
                e.Cancel = L3IsID(tdbg, e.ColIndex) 'ID 76914 17/07/2015
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case tdbg.Columns(e.ColIndex).DataField
            Case COL_BlockName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_BlockID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_BlockID).Text = tdbdBlockID.Columns("BlockID").Text
                If tdbg.Columns(COL_VoucherDate).Text = "" Then tdbg.Columns(COL_VoucherDate).Text = Now.ToString
                tdbg.Columns(COL_DepartmentID).Text = ""
                tdbg.Columns(COL_DepartmentName).Text = ""
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""

            Case COL_DepartmentName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_DepartmentID).Text = tdbdDepartmentID.Columns("DepartmentID").Text
                If tdbg.Columns(COL_VoucherDate).Text <> "" Then tdbg.Columns(COL_VoucherDate).Text = Now.ToString
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""
                SetValue()

            Case COL_TeamName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_TeamID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns("TeamID").Text
                SetValue()

            Case COL_RecPositionName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_RecPositionID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_RecPositionID).Text = tdbdRecPositionID.Columns("PositionID").Text
                SetValue()

            Case COL_WorkName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_WorkID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_WorkID).Text = tdbdWorkID.Columns("WorkID").Text
                SetValue()
            Case COL_PlanStatusName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_PlanStatusID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_PlanStatusID).Text = tdbdPlanStatusID.Columns("PlanStatusID").Text

            Case COL_CreatorID, COL_ApproverID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    Exit Select
                End If

            Case COL_IsApprove 'ID 	90425 04/11/2016
                SetDefaultApproved(0)
            Case COL_Number
                SetDefaultApproved(1) 'ID 	90425 04/11/2016
                If tdbg.Row = 0 Then Exit Sub ' neu la update dong dau thi ko update nua -> tranh truong hop loop vo tan
                If _FormState = EnumFormState.FormOther Then
                    tdbg(0, e.ColIndex) = dRemainQty
                    Exit Sub
                End If
            Case COL_VoucherDate
                tdbg.Select()
                SetDefaultApproved(2) 'ID 	90425 04/11/2016
            Case COL_DateFrom, COL_DateTo, COL_ApprovedDate
                tdbg.Select()
        End Select

        ResetGrid()
    End Sub

    Private Sub SetValue()
        tdbg.Columns(COL_EmployeeQTY).Text = ReturnEmployeeQTY(0)
        tdbg.Columns(COL_PresentQuan).Text = ReturnEmployeeQTY(1)
        tdbg.Columns(COL_PlanQuan).Text = ReturnEmployeeQTY(2)
        tdbg.Columns(COL_RemainQuan).Text = ReturnEmployeeQTY(3)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case tdbg.Columns(tdbg.Col).DataField
            Case COL_CreatorID, COL_CreatorName
                Select Case e.KeyCode
                    Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                        tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).AutoComplete = False
                    Case Else
                        tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).AutoComplete = True
                End Select
        End Select

        Select Case e.KeyCode
            Case Keys.F7
                Select Case tdbg.Columns(tdbg.Col).DataField

                    Case COL_BlockName
                        F7More(tdbg, IndexOfColumn(tdbg, COL_BlockID))

                    Case COL_DepartmentName
                        F7More(tdbg, IndexOfColumn(tdbg, COL_DepartmentID))

                    Case COL_TeamName
                        F7More(tdbg, IndexOfColumn(tdbg, COL_TeamID))

                    Case COL_RecPositionName
                        F7More(tdbg, IndexOfColumn(tdbg, COL_RecPositionID))

                    Case COL_Number
                        If _FormState <> EnumFormState.FormOther Then
                            HotKeyF7(tdbg)
                        End If
                    Case Else
                        HotKeyF7(tdbg)
                End Select

            Case Keys.F8
                If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                    HotKeyF8(tdbg)
                    tdbg.Columns(COL_TransID).Text = ""

                    If _FormState = EnumFormState.FormOther Then
                        tdbg.Columns(COL_Number).Text = "0"
                        tdbg.UpdateData()
                    End If
                    ResetGrid()
                Else
                    D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

            Case Else
                If tdbg.Row = 0 And _FormState = EnumFormState.FormOther Then
                    If e.Control Then
                        Select Case e.KeyCode
                            Case Keys.Delete
                                Exit Sub
                        End Select
                    End If
                End If
                HotKeyDownGrid(e, tdbg, IndexOfColumn(tdbg, COL_TransID))
        End Select

        If e.Control Then
            Select Case e.KeyCode
                Case Keys.Delete
                    ResetGrid()
            End Select
        End If
    End Sub
    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Columns(tdbg.Col).DataField
            'Case COL_Number
            '    e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_ReferenceNo ' ID 76914
                e.KeyChar = UCase(e.KeyChar) 'Nhập các ký tự hoa
        End Select
    End Sub

    Dim bSelect As Boolean = False
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case tdbg.Columns(e.ColIndex).DataField
            Case COL_BlockName, COL_DepartmentName, COL_TeamName
                Dim arCol() As Integer = {IndexOfColumn(tdbg, COL_BlockID), IndexOfColumn(tdbg, COL_BlockName), IndexOfColumn(tdbg, COL_DepartmentID), IndexOfColumn(tdbg, COL_DepartmentName), IndexOfColumn(tdbg, COL_TeamID), IndexOfColumn(tdbg, COL_TeamName)}
                CopyColumnArr(tdbg, e.ColIndex, arCol)
            Case COL_RecPositionName
                Dim arCol() As Integer = {IndexOfColumn(tdbg, COL_RecPositionID)}
                CopyColumnArr(tdbg, e.ColIndex, arCol)
            Case COL_Number
                'nothing
            Case COL_VoucherDate
                Dim arCol() As Integer = {IndexOfColumn(tdbg, COL_ApprovedDate)}
                CopyColumnArr(tdbg, e.ColIndex, arCol)
            Case COL_IsApprove
                L3HeadClick(tdbg, COL_IsApprove, bSelect)
                For i As Integer = 0 To tdbg.RowCount - 1
                    SetDefaultApproved(0, i)
                Next
                tdbg.UpdateData()
            Case Else
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Text, tdbg.Row)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Columns(tdbg.Col).DataField
            Case COL_BlockName
                If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
                    tdbg.Columns(tdbg.Col).DropDown = Nothing
                    'ElseIf _FormState = EnumFormState.FormEdit And tdbg.Row <> 0 Then
                    '    tdbg.Columns(tdbg.Col).DropDown = Nothing
                Else
                    tdbg.Columns(tdbg.Col).DropDown = tdbdBlockID
                End If

            Case COL_DepartmentName
                If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
                    tdbg.Columns(tdbg.Col).DropDown = Nothing
                    'ElseIf _FormState = EnumFormState.FormEdit And tdbg.Row <> 0 Then
                    '    tdbg.Columns(tdbg.Col).DropDown = Nothing
                Else
                    tdbg.Columns(tdbg.Col).DropDown = tdbdDepartmentID
                    LoadTdbdDepartmentID()
                End If

            Case COL_TeamName
                If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
                    tdbg.Columns(tdbg.Col).DropDown = Nothing
                    'ElseIf _FormState = EnumFormState.FormEdit And tdbg.Row <> 0 Then
                    '    tdbg.Columns(tdbg.Col).DropDown = Nothing
                Else
                    tdbg.Columns(tdbg.Col).DropDown = tdbdTeamID
                    LoadtdbdTeamID()
                End If

            Case COL_RecPositionName
                If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
                    tdbg.Columns(tdbg.Col).DropDown = Nothing
                    'ElseIf _FormState = EnumFormState.FormEdit And tdbg.Row <> 0 Then
                    '    tdbg.Columns(tdbg.Col).DropDown = Nothing
                Else
                    tdbg.Columns(tdbg.Col).DropDown = tdbdRecPositionID
                End If

            Case COL_CreatorID
                If tdbg.Splits(1).DisplayColumns(COL_CreatorID).Locked Then Exit Select
                If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
                    tdbg.Columns(tdbg.Col).DropDown = Nothing
                    'ElseIf _FormState = EnumFormState.FormEdit And tdbg.Row <> 0 Then
                    '    tdbg.Columns(tdbg.Col).DropDown = Nothing
                Else
                    tdbg.Columns(tdbg.Col).DropDown = tdbdEmployeeID
                End If
            Case COL_ApproverID
                If tdbg.Splits(2).DisplayColumns(COL_ApproverID).Locked Then Exit Select
                tdbg.Splits(2).DisplayColumns(COL_ApproverID).Button = L3Bool(tdbg(tdbg.Row, COL_IsApprove))
        End Select
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case tdbg.Columns(e.Col).DataField
            Case COL_ApproveNumber, COL_ApprovedDate, COL_ApproverID
                If iPerD25F5601 <= 1 Then Exit Sub
                If L3Bool(tdbg(e.Row, COL_IsApprove)) = False Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
        End Select
    End Sub

#End Region
    Dim dtBlockID As DataTable
    Dim dtDepartmentID As DataTable
    Dim dtTeamID As DataTable

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        LoadtdbdBlockID(tdbdBlockID, gbUnicode)

        If _FormState = EnumFormState.FormOther And tdbg.Row = 0 Then
            tdbg.Columns(COL_BlockName).DropDown = Nothing
        Else
            tdbg.Columns(COL_BlockName).DropDown = tdbdBlockID
        End If

        dtDepartmentID = ReturnTableDepartmentID(True, False, gbUnicode)
        dtTeamID = ReturnTableTeamID(True, False, gbUnicode)

        'Load tdbdPositionID
        sSQL = "SELECT      DutyID AS PositionID , DutyName" & UnicodeJoin(gbUnicode) & " As PositionName" & vbCrLf
        sSQL &= "FROM       D09T0211 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE      Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY   PositionName" & vbCrLf
        LoadDataSource(tdbdRecPositionID, sSQL, gbUnicode)

        ' LoadDataSource(tdbdEmployeeID, ReturnTableEmployeeID(True, False, gbUnicode), gbUnicode)
        LoadDataSource(tdbdEmployeeID, ReturnTableCreateBy(gbUnicode), gbUnicode)

        'IncidentID 50585
        sSQL = SQLStoreD25P2085()
        dtEmployeeQTY = ReturnDataTable(sSQL)

        'Load tdbdWorkID
        sSQL = "SELECT     WorkID, WorkName" & UnicodeJoin(gbUnicode) & " As WorkName" & vbCrLf
        sSQL &= "FROM       D09T0224 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE      DivisionID = " & SQLString(gsDivisionID) & " OR DivisionID = ''" & vbCrLf
        LoadDataSource(tdbdWorkID, sSQL, gbUnicode)

        'IncidentID	49499
        'Load tdbdPlanStatusID
        sSQL = "--Do nguon dropdown trang thai" & vbCrLf
        sSQL &= "SELECT ID As PlanStatusID,  Name84" & UnicodeJoin(gbUnicode) & " As PlanStatusName" & vbCrLf
        sSQL &= "FROM D25N5555 ('D25F2080','PlanStatusID', '', '', '','') " & vbCrLf
        sSQL &= "ORDER BY PlanStatusID"
        LoadDataSource(tdbdPlanStatusID, sSQL, gbUnicode)

        'Load tdbdApproverID
        Dim dt As DataTable = ReturnTableEmployeeID_D09P6868(gsDivisionID, Me.Name, 0)
        LoadDataSource(tdbdApproverID, ReturnTableFilter(dt, "EmployeeID <>'%'"), gbUnicode)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2085
    '# Created User: Phan Văn Thông
    '# Created Date: 05/09/2012 10:14:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2085() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Tinh Dinh muc, So luong hien tai va So luong ke hoach da lap, So luong con lai" & vbCrlf)
        sSQL &= "Exec D25P2085 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_transID) & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(gsCompanyID) 'CompanyID, varchar[50], NOT NULL
        Return sSQL
    End Function


    'IncidentID 50585
    Private Function ReturnEmployeeQTY(ByVal iMode As Integer) As String
        Dim drWorkID As DataRow = ReturnDataRow(dtEmployeeQTY, "WorkID <> ''") 'ID 	90425 04/11/2016
        Dim sFilterID As String = "DepartmentID=" & SQLString(tdbg.Columns(COL_DepartmentID).Text) & " And TeamID=" & SQLString(tdbg.Columns(COL_TeamID).Text) & " And DutyID =" & SQLString(tdbg.Columns(COL_RecPositionID).Text)
        If drWorkID IsNot Nothing Then
            sFilterID &= " And WorkID =" & SQLString(tdbg.Columns(COL_WorkID).Text)
        End If
        Dim dr() As DataRow = dtEmployeeQTY.Select(sFilterID)
        If dr.Length > 0 Then
            Select Case iMode
                Case 0
                    Return dr(0).Item("EmployeeQTY").ToString
                Case 1
                    Return dr(0).Item("PresentQuan").ToString
                Case 2
                    Return dr(0).Item("PlanQuan").ToString
                Case 3
                    Return dr(0).Item("RemainQuan").ToString
            End Select
        End If
        Return ""
    End Function

    Private Sub SetDefaultApproved(iMode As Byte, Optional i As Integer = -1) 'ID 	90425 04/11/2016
        If i = -1 Then
            Select Case iMode
                Case 0
                    If L3Bool(tdbg.Columns(COL_IsApprove).Value) Then
                        tdbg.Columns(COL_ApproveNumber).Value = tdbg.Columns(COL_Number).Value
                        tdbg.Columns(COL_ApprovedDate).Value = tdbg.Columns(COL_VoucherDate).Value
                    Else
                        tdbg.Columns(COL_ApproveNumber).Value = 0
                        tdbg.Columns(COL_ApprovedDate).Value = ""
                    End If
                Case 1
                    If L3Bool(tdbg.Columns(COL_IsApprove).Value) = False Then Exit Sub
                    tdbg.Columns(COL_ApproveNumber).Text = tdbg.Columns(COL_Number).Text
                Case 2
                    If L3Bool(tdbg.Columns(COL_IsApprove).Value) = False Then Exit Sub
                    tdbg.Columns(COL_ApprovedDate).Text = tdbg.Columns(COL_VoucherDate).Text
            End Select
        Else
            Select Case iMode
                Case 0
                    If L3Bool(tdbg(i, COL_IsApprove)) Then
                        tdbg(i, COL_ApproveNumber) = tdbg(i, COL_Number)
                        tdbg(i, COL_ApprovedDate) = tdbg(i, COL_VoucherDate)
                    Else
                        tdbg(i, COL_ApproveNumber) = 0
                        tdbg(i, COL_ApprovedDate) = ""
                    End If
                Case 1
                    If L3Bool(tdbg(i, COL_IsApprove)) = False Then Exit Sub
                    tdbg(i, COL_ApproveNumber) = tdbg(i, COL_Number)
                Case 2
                    If L3Bool(tdbg(i, COL_IsApprove)) = False Then Exit Sub
                    tdbg(i, COL_ApprovedDate) = tdbg(i, COL_VoucherDate)
            End Select
        End If
    End Sub
    Private Sub LoadTdbdDepartmentID()
        If Not D25Systems.IsUseBlock Then
            LoadDataSource(tdbdDepartmentID, dtDepartmentID.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbdDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID =  " & SQLString(tdbg(tdbg.Row, COL_BlockID).ToString)), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbdTeamID()
        If Not D25Systems.IsUseBlock Then
            LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID, "DepartmentID = " & SQLString(tdbg(tdbg.Row, COL_DepartmentID).ToString)), gbUnicode)
        Else
            LoadDataSource(tdbdTeamID, ReturnTableFilter(dtTeamID, "DepartmentID = " & SQLString(tdbg(tdbg.Row, COL_DepartmentID).ToString) & " And BlockID = " & SQLString(tdbg(tdbg.Row, COL_BlockID).ToString)), gbUnicode)
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P2080
    '# Created User: Phan Văn Thông
    '# Created Date: 12/09/2012 01:09:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P2080() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho grid D25F2080" & vbCrLf)
        sSQL &= "Exec D25P2080 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(_FormState = EnumFormState.FormAdd, 0, 1)) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(_transID) & COMMA 'TransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(_formID) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        btnSave.Enabled = True
        btnNext.Enabled = False
        If dtGrid IsNot Nothing Then dtGrid.Clear()
        ResetGrid()
        '*********************
        Dim sSQL As String =  SQLStoreD25P2085()
        dtEmployeeQTY = ReturnDataTable(sSQL)
    End Sub
    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL_BlockName, COL_DepartmentName, COL_Number, COL_DateFrom, COL_DateTo, COL_VoucherDate, COL_ApproveNumber, COL_ApprovedDate, COL_ApproverID}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

End Class