Imports System
Public Class D25F2070

    Private _autoRecInformationID As Boolean = False
    Public WriteOnly Property  AutoRecInformationID() As Boolean
        Set(ByVal Value As Boolean)
            _autoRecInformationID = Value
        End Set
    End Property
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Dim dtCaptionCols As DataTable
    Dim dtBlockID, dtDepartmentID, dtTeamID As DataTable
    Dim bIsUseBlock As Boolean

#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0         ' TransID
    Private Const COL_BlockID As Integer = 1         ' BlockID
    Private Const COL_BlockName As Integer = 2       ' Khối
    Private Const COL_DepartmentID As Integer = 3    ' DepartmentID
    Private Const COL_DepartmentName As Integer = 4  ' Phòng ban
    Private Const COL_TeamID As Integer = 5          ' TeamID
    Private Const COL_TeamName As Integer = 6        ' Tổ nhóm
    Private Const COL_RecPositionID As Integer = 7   ' RecPositionID
    Private Const COL_RecPositionName As Integer = 8 ' Vị trí
    Private Const COL_Number As Integer = 9          ' Số lượng
    Private Const COL_DateFrom As Integer = 10       ' Từ ngày
    Private Const COL_DateTo As Integer = 11         ' Đến ngày
    Private Const COL_NoteDetail As Integer = 12     ' Ghi chú
#End Region

#Region "UserControl D09U1111 (gồm 4 bước)"
    'UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
    'Chuẩn hóa sử dụng D09U1111 cho lưới KHÔNG có nút: gồm 4 bước
    'Nhấn Ctrl+Shift+F: Search "Chuẩn hóa D09U1111 B" để tìm các bước chuẩn sử dụng D09U1111
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
    '*****************************************
    Dim bLoadD25F2020 As Boolean = False 'Ktra xem co goi D25F2020 k?
    Dim vcNewTemp(-1, -1) As VisibleColumn
#End Region

    Private _dtGrid As DataTable
    Public Property dtGrid() As DataTable
        Get
            Return _dtGrid
        End Get
        Set(ByVal Value As DataTable)
            _dtGrid = Value
        End Set
    End Property

    Private _recInformationID As String = ""
    Public Property RecInformationID() As String
        Get
            Return _recInformationID
        End Get
        Set(ByVal Value As String)
            _recInformationID = Value
        End Set
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
            LoadTDBCombo()
            VisibleControl() 'IncidentID	51129 Cho thiết lập phương pháp sinh tự động mã Thông báo tuyển dụng

            Select Case _FormState

                Case EnumFormState.FormAdd
                    dtGrid = ReturnDataTable(SQLStoreD25P1041(0))
                    c1dateVoucherDate.Value = Date.Now()
                    c1dateFromDate.Value = Date.Now()
                    c1dateToDate.Value = Date.Now()
                    btnNext.Enabled = False
                Case EnumFormState.FormEdit
                    dtGrid = ReturnDataTable(SQLStoreD25P1041(0))
                    LoadMaster()
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False

                Case EnumFormState.FormView
                    dtGrid = ReturnDataTable(SQLStoreD25P1041(0))
                    LoadMaster()

                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False

            End Select
        End Set
    End Property

    Private Sub VisibleControl()
        'If D25Systems.AutoRecInformationID Then
        If _autoRecInformationID Then
            If _FormState = EnumFormState.FormAdd Then ReadOnlyControl(txtVoucherNo)
        Else
            tdbcMethodID.Visible = False
            txtVoucherNo.Location = tdbcMethodID.Location
            lblMethodID.Visible = False
            lblVoucherNo.Location = New Point(16, 12)
        End If

        'IncidentID	50891  Bổ sung theo yêu cầu của BAOTRAN
        If _FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormView Then
            tdbcMethodID.Visible = False
            txtVoucherNo.Location = tdbcMethodID.Location
            lblMethodID.Visible = False
            lblVoucherNo.Location = New Point(16, 12)
        End If
    End Sub

    Private Sub D25F2070_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If

        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        If e.KeyCode = Keys.F12 Then ' Mở
            btnShowColumns_Click(Nothing, Nothing)
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

    Private Sub D25F2070_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLoadFormState = False Then FormState = _FormState
        _bSaved = False
        Loadlanguage()
        SetBackColorObligatory()
        ResetFooterGrid(tdbg)

        'ID 79642 21/9/2015
        'tdbg_LockedColumns()

        LoadTDBGrid()
        '******************************
        InputDateInTrueDBGrid(tdbg, COL_DateFrom, COL_DateTo)
        GetTextCreateByNew(tdbcCreatorID, _FormState = EnumFormState.FormAdd)
        '******************************
        CallD09U1111_Button(True)
        '******************************
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtVoucherNo, txtVoucherNo.MaxLength, False)
        '******************************
        InputDateCustomFormat(c1dateVoucherDate, c1dateFromDate, c1dateToDate)
        SetResolutionForm(Me)
    End Sub

    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_BlockName, COL_DepartmentName, COL_TeamName, COL_RecPositionName, COL_Number, COL_DateFrom, COL_DateTo}
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
        Me.Text = rL3("Lap_thong_bao_tuyen_dung_-_D25F2070") & UnicodeCaption(gbUnicode) 'LËp th¤ng bÀo tuyÓn dóng - D25F2070
        '================================================================ 
        lblVoucherNo.Text = rL3("Ma") 'Mã
        lblRecInformationName.Text = rL3("Dien_giai") 'Diễn giải
        lblteVoucherDate.Text = rL3("Ngay_lap") 'Ngày lập
        lblCreatorID.Text = rL3("Nguoi_lap") 'Người lập
        lblteFromDate.Text = rL3("Ngay_tuyenU") 'Ngày tuyển
        lblNote.Text = rL3("Ghi_chu") 'Ghi chú
        lblRecruitmentFileID.Text = rL3("KH_tuyen_dung")
        lblMethodID.Text = rL3("Phuong_phap_tao_ma_tu_dong") 'Phương pháp tạo mã tự động
        '================================================================ 
        btnChooseRecruitment.Text = rL3("_Chon_de_xuat") '&Chọn đề xuất
        'Chuẩn hóa D09U1111 B5: Gắn caption F12
        btnShowColumns.Text = rL3("Hien_thi") & Space(1) & "(F12)" 'Hiển thị
        btnNext.Text = rL3("_Nhap_tiep") 'Nhập &tiếp
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnSave.Text = rL3("_Luu") '&Lưu
        '================================================================ 
        tdbcCreatorID.Columns("EmployeeID").Caption = rL3("Ma") 'Mã
        tdbcCreatorID.Columns("EmployeeName").Caption = rL3("Ten") 'Tên
        tdbcRecruitmentFileID.Columns("VoucherNo").Caption = rL3("Ma") 'Mã
        tdbcRecruitmentFileID.Columns("RecruitmentFileName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbdRecPositionID.Columns("RecPositionID").Caption = rL3("Ma") 'Mã
        tdbdRecPositionID.Columns("RecPositionName").Caption = rL3("Ten") 'Tên
        tdbdTeamID.Columns("TeamID").Caption = rL3("Ma") 'Mã
        tdbdTeamID.Columns("TeamName").Caption = rL3("Ten") 'Tên
        tdbdDepartmentID.Columns("DepartmentID").Caption = rL3("Ma") 'Mã
        tdbdDepartmentID.Columns("DepartmentName").Caption = rL3("Ten") 'Tên
        tdbdBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbdBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("BlockID").Caption = rL3("Ma_khoi") 'Mã khối
        tdbg.Columns("BlockName").Caption = rL3("Ten_khoi") 'Tên khối
        tdbg.Columns("DepartmentID").Caption = rL3("Ma_phong_ban") 'Mã phòng ban
        tdbg.Columns("DepartmentName").Caption = rL3("Ten_phong_ban") 'Tên phòng ban
        tdbg.Columns("TeamID").Caption = rL3("Ma_to_nhom") 'Mã tổ nhóm
        tdbg.Columns("TeamName").Caption = rL3("Ten_to_nhom") 'Tên tổ nhóm
        tdbg.Columns("RecPositionID").Caption = rL3("Ma_vi_tri") 'Mã vị trí
        tdbg.Columns("RecPositionName").Caption = rL3("Ten_vi_tri") 'Tên vị trí
        tdbg.Columns("Number").Caption = rL3("So_luong") 'Số lượng
        tdbg.Columns("DateFrom").Caption = rL3("Tu_ngay") 'Từ ngày
        tdbg.Columns("DateTo").Caption = rL3("Den_ngay") 'Đến ngày
        tdbg.Columns("NoteDetail").Caption = rL3("Ghi_chu") 'Ghi chú


    End Sub

    Private Sub SetBackColorObligatory()
        txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtRecInformationName.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCreatorID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMethodID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY

        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(0).DisplayColumns(COL_Number).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(0).DisplayColumns(COL_DateFrom).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(0).DisplayColumns(COL_DateTo).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function VisibleBlock() As Boolean
        Dim dt As DataTable = ReturnDataTable("SELECT IsUseBlock FROM D09T0000 WITH(NOLOCK) ")
        If dt.Rows(0).Item("IsUseBlock").ToString = "0" Then
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockID).Visible = False
            tdbg.Splits(SPLIT0).DisplayColumns.Item(COL_BlockName).Visible = False
            Return False
        End If

        Return True
    End Function

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_BlockName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_DepartmentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TeamName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_RecPositionName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String
        'LoadDataSource(tdbcCreatorID, ReturnTableEmployeeID(True, False, gbUnicode), gbUnicode)
        LoadCboCreateBy(tdbcCreatorID, gbUnicode)

        'Load tdbcMethodID   IncidentID	50891
        sSQL = "SELECT MethodID, MethodName" & UnicodeJoin(gbUnicode) & " AS MethodName, IsDefault,TypeCode " & vbCrLf
        sSQL &= "FROM D09T1600 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0" & vbCrLf
        sSQL &= "AND TypeCode = 51" & vbCrLf
        sSQL &= "AND (DivisionID =" & SQLString(gsDivisionID) & " Or DivisionID = '') " & vbCrLf
        sSQL &= "ORDER BY MethodName"
        LoadDataSource(tdbcMethodID, sSQL, gbUnicode)
        Dim dr() As DataRow = CType(tdbcMethodID.DataSource, DataTable).Select("IsDefault=1")
        If dr.Length > 0 Then tdbcMethodID.Text = dr(0).Item("MethodName").ToString
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        sSQL = "Select BlockID, BlockName" & UnicodeJoin(gbUnicode) & " As BlockName" & vbCrLf
        sSQL &= "From D09T1140 WITH(NOLOCK)  Where Disabled =0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Order by BlockID"
        LoadDataSource(tdbdBlockID, sSQL, gbUnicode)

        'Load tdbdDepartmentID
        sSQL = "SELECT 	DepartmentID, DepartmentName" & UnicodeJoin(gbUnicode) & " As DepartmentName, BlockID" & vbCrLf
        sSQL &= "FROM D91T0012 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Order by DepartmentID"
        dtDepartmentID = ReturnDataTable(sSQL)

        sSQL = "SELECT D01.TeamID, D01.TeamName" & UnicodeJoin(gbUnicode) & " As TeamName, D01.DepartmentID, D02.BlockID" & vbCrLf
        sSQL &= "FROM D09T0227 D01  WITH(NOLOCK) INNER JOIN D91T0012 D02 WITH(NOLOCK)  ON D02.DepartmentID = D01.DepartmentID" & vbCrLf
        sSQL &= "WHERE D01.Disabled = 0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Order by D01.TeamID"
        dtTeamID = ReturnDataTable(sSQL)

        'Load tdbdPositionID
        LoadDataSource(tdbdRecPositionID, ReturnTableDutyIDRec(False, gbUnicode), gbUnicode)

        'IncidentID	51159    	Cho lập Thông báo tuyển dụng từ Đợt tuyển dụng
        'Load tdbcRecruitmentFileID
        sSQL = "-- Combo Dot tuyen dung" & vbCrLf
        sSQL &= "SELECT DISTINCT VoucherNo , RecruitmentFileName" & UnicodeJoin(gbUnicode) & " AS RecruitmentFileName ,RecruitmentFileID " & vbCrLf
        sSQL &= "FROM D25T1042 WITH(NOLOCK) " & vbCrLf
        sSQL &= "ORDER BY 	 RecruitmentFileID" & vbCrLf
        LoadDataSource(tdbcRecruitmentFileID, sSQL, gbUnicode)

    End Sub

    Private Sub LoadTdbdDepartmentID()
        If Not bIsUseBlock Then
            LoadDataSource(tdbdDepartmentID, dtDepartmentID.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbdDepartmentID, ReturnTableFilter(dtDepartmentID, "BlockID =  " & SQLString(tdbg(tdbg.Row, COL_BlockID).ToString)), gbUnicode)
        End If
    End Sub

    Public Sub LoadtdbdTeamID()
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

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_DepartmentName)
        FooterSumNew(tdbg, COL_Number)
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String = ""

        sSQL = "SELECT DivisionID, RecInformationID, RecInformationName" & UnicodeJoin(gbUnicode) & " AS RecInformationName, "
        sSQL &= "Note" & UnicodeJoin(gbUnicode) & " AS Note, RecruitPlanID, DateFrom, DateTo, CreateDate,CreateUserID, LastModifyDate, "
        sSQL &= "LastModifyUserID, TranMonth, TranYear, VoucherDate, CreatorID, VoucherNo,RecruitmentFileID" & vbCrLf
        sSQL &= "FROM D25T2070 T  WITH(NOLOCK) WHERE T.RecInformationID = " & SQLString(_recInformationID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                txtVoucherNo.Text = .Item("VoucherNo").ToString
                txtRecInformationName.Text = .Item("RecInformationName").ToString
                c1dateVoucherDate.Value = SQLDateShow(.Item("VoucherDate").ToString)
                tdbcCreatorID.SelectedValue = .Item("CreatorID").ToString
                c1dateFromDate.Value = SQLDateShow(.Item("DateFrom").ToString)
                c1dateToDate.Value = SQLDateShow(.Item("DateTo").ToString)
                txtNote.Text = .Item("Note").ToString
                'IncidentID	51159    	Cho lập Thông báo tuyển dụng từ Đợt tuyển dụng
                tdbcRecruitmentFileID.SelectedValue = .Item("RecruitmentFileID").ToString
            End With

        End If

        ReadOnlyControl(txtVoucherNo)
    End Sub

    Private Sub btnShowColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowColumns.Click
        If bLoadD25F2020 Then
            vcNew = vcNewTemp
            giRefreshUserControl = 0
            usrOption.D09U1111Refresh()
            bLoadD25F2020 = False
        End If

        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnShowColumns.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnChooseRecruitment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseRecruitment.Click
        '************************
        If Not bLoadD25F2020 Then vcNewTemp = vcNew
        bLoadD25F2020 = True
        If usrOption.Visible Then usrOption.Hide()
        '************************
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormID", "D25F1040")
        SetProperties(arrPro, "RecDateFrom", c1dateFromDate.Text)
        SetProperties(arrPro, "RecDateTo", c1dateToDate.Text)
        SetProperties(arrPro, "VoucherID", _recInformationID)
        Dim frm As Form = Me
        frm = CallFormShowDialog("D25D0240", "D25F2020", arrPro)
        If L3Bool(GetProperties(frm, "Chose")) Then
            dtGrid = ReturnDataTable(SQLStoreD25P1041(2))
            LoadTDBGrid()
            tdbcRecruitmentFileID.SelectedValue = "" 'ID 80851 02/02/2016
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        _recInformationID = ""
        txtVoucherNo.Text = ""
        txtRecInformationName.Text = ""
        c1dateVoucherDate.Value = Date.Now()
        'tdbcCreatorID.Text = ""
        GetTextCreateByNew(tdbcCreatorID)
        c1dateFromDate.Value = Date.Now()
        c1dateToDate.Value = Date.Now()
        txtNote.Text = ""
        tdbcRecruitmentFileID.Text = ""

        btnNext.Enabled = False
        btnSave.Enabled = True
        '**********************************
        'Xoa luoi
        tdbg.Delete(0, tdbg.RowCount)
        ResetGrid()
        '**********************************

        'IncidentID	50891
        If tdbcMethodID.Visible Then
            Dim dr() As DataRow = CType(tdbcMethodID.DataSource, DataTable).Select("IsDefault=1")
            If dr.Length > 0 Then tdbcMethodID.Text = dr(0).Item("MethodName").ToString
            tdbcMethodID.Focus()
        Else
            txtVoucherNo.Focus()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        tdbg.UpdateData()
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        Select Case _FormState

            Case EnumFormState.FormAdd
                _recInformationID = CreateIGE("D25T2070", "RecInformationID", "25", "IN", gsStringKey)

                sSQL.Append(SQLInsertD25T2070.ToString() & vbCrLf)
                sSQL.Append(SQLInsertD25T2040s().ToString() & vbCrLf)

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD25T2070().ToString() & vbCrLf)
                sSQL.Append(SQLDeleteD25T2040().ToString() & vbCrLf)
                sSQL.Append(SQLInsertD25T2040s().ToString() & vbCrLf)

        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = True
                    btnNext.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        ''IncidentID	50891
        ''-------Sinh mã tự động cho ứng cử viên - chỉ thực hiện khi thêm mới và có check sinh mã tự động ở thiết lập hệ thống
        'If tdbcMethodID.Visible And _FormState = EnumFormState.FormAdd Then
        '    If tdbcMethodID.Text.Trim = "" Then
        '        D99C0008.MsgNotYetChoose(rl3("Phuong_phap_tao_ma_tu_dong"))
        '        tdbcMethodID.Focus()
        '        Return False
        '    End If
        'End If
        '--------Giá trị sinh ra được gắn vào text mã ứng cử viên, thực hiện các bước tiếp theo như bình thường
        If txtRecInformationName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Dien_giai"))
            txtRecInformationName.Focus()
            Return False
        End If
        If c1dateVoucherDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ngay_lap"))
            c1dateVoucherDate.Focus()
            Return False
        End If
        If tdbcCreatorID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Nguoi_lap"))
            tdbcCreatorID.Focus()
            Return False
        End If

        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        For i As Integer = 0 To tdbg.RowCount - 1

            If tdbg(i, COL_BlockName).ToString = "" And bIsUseBlock Then
                D99C0008.MsgNotYetEnter(rL3("Khoi"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_BlockName
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_DepartmentName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Phong_ban"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DepartmentName
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_Number).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("So_luong"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_Number
                tdbg.Bookmark = i
                Return False
            End If

            If tdbg(i, COL_DateFrom).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Tu_ngay"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DateFrom
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_DateTo).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Den_ngay"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DateTo
                tdbg.Bookmark = i
                Return False
            End If

        Next

        ''28/11/2012
        'If tdbcMethodID.Visible And _FormState = EnumFormState.FormAdd Then
        '    Dim sSQL As String = ""
        '    sSQL = SQLDeleteD09T6666.ToString & vbCrLf
        '    sSQL &= SQLInsertD09T6666.ToString & vbCrLf
        '    sSQL &= SQLStoreD09P6600.ToString & vbCrLf
        '    sSQL &= SQLDeleteD09T6666.ToString & vbCrLf
        '    Dim sVoucherNo As String = ""
        '    If Not CheckMyStore(sSQL, sVoucherNo) Then
        '        tdbcMethodID.Focus()
        '        Return False
        '    Else
        '        txtVoucherNo.Text = sVoucherNo
        '    End If
        'End If

        'If txtVoucherNo.Text.Trim = "" Then
        '    D99C0008.MsgNotYetEnter(rl3("Ma"))
        '    txtVoucherNo.Focus()
        '    Return False
        'End If

        'If _FormState = EnumFormState.FormAdd Then
        '    If ExistRecord("SELECT TOP 1 1 FROM D25T2070 WITH(NOLOCK)  WHERE VoucherNo = " & SQLString(txtVoucherNo.Text)) Then
        '        D99C0008.MsgDuplicatePKey()
        '        txtVoucherNo.Focus()
        '        Return False
        '    End If
        'End If

        Return True
    End Function
    ''' <summary>
    ''' Kiểm tra dữ liệu bằng Store
    ''' </summary>
    ''' <param name="SQL">Store cần kiểm tra</param>
    ''' <returns>Trả về True nếu kiểm tra không có lỗi, ngược lại trả về False</returns>
    ''' <remarks>Chú ý: Kết quả trả ra của Store phải có dạng là 1 hàng và 2 cột là Status và Message</remarks>
    Private Function CheckMyStore(ByVal SQL As String, ByRef Status As String, Optional ByVal bMsgAsk As Boolean = False) As Boolean
        'Update 11/10/2010: sửa lại hàm checkstore có trả ra field FontMessage
        'Cách kiểm tra của hàm CheckStore này sẽ như sau:
        'Nếu store trả ra Status <> 0 thì xuất Message theo dạng FontMessage
        'Nếu đối số thứ 2 không truyền vào có nghĩa là False thì xuất Message chỉ có 1 nút Ok
        'Nếu đối số thứ 2 có truyền vào có nghĩa là True thì xuất Message có 2 nút Yes, No

        Dim dt As New DataTable
        Dim sMsg As String
        dt = ReturnDataTable(SQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString = "0" Then
                Status = dt.Rows(0).Item("ID").ToString
                dt = Nothing
                Return True
            End If

            sMsg = dt.Rows(0).Item("Message").ToString
            Dim bFontMessage As Boolean = False
            If dt.Columns.Contains("FontMessage") Then bFontMessage = True

            If Not bMsgAsk Then 'OKOnly
                If Not bFontMessage Then
                    D99C0008.MsgL3(ConvertUnicodeToVietwareF(sMsg))
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            '        MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            D99C0008.MsgL3(ConvertUnicodeToVietwareF(sMsg))
                        Case "1" 'Unicode
                            D99C0008.MsgL3(sMsg, L3MessageBoxIcon.Exclamation)
                        Case "2" 'Convert Vni To Unicode
                            D99C0008.MsgL3(ConvertVniToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
                    End Select
                End If
                dt = Nothing
                Return False
            Else 'YesNo
                If Not bFontMessage Then
                    If D99C0008.MsgAsk(ConvertUnicodeToVietwareF(sMsg)) = Windows.Forms.DialogResult.Yes Then
                        dt = Nothing
                        Return True
                    Else
                        dt = Nothing
                        Return False
                    End If
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            If D99C0008.MsgAsk(ConvertUnicodeToVietwareF(sMsg)) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "1" 'Unicode
                            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "2" 'Convert Vni To Unicode
                            If D99C0008.MsgAsk(ConvertVniToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                    End Select
                End If
            End If
            dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return False
        End If
        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Phan Văn Thông
    '# Created Date: 27/08/2012 03:06:39
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL = "DELETE From D09T6666" & vbCrLf
        sSQL &= "WHERE UserID =" & SQLString(gsUserID) & vbCrLf
        sSQL &= "AND HostID = " & SQLString(My.Computer.Name) & vbCrLf
        sSQL &= "AND FormID = " & SQLString("D25F2070")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Phan Văn Thông
    '# Created Date: 27/08/2012 03:11:48
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, FormID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString("D25F2070")) 'FormID, varchar[20], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6600
    '# Created User: Phan Văn Thông
    '# Created Date: 22/11/2012 01:46:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P6600() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Phan ra cong thuc sinh ma tu dong" & vbCrLf)
        sSQL &= "Exec D09P6600 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLString(tdbcMethodID.SelectedValue.ToString) & COMMA 'MethodID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcMethodID.Columns("TypeCode").Value.ToString) & COMMA 'TypeCode, varchar[20], NOT NULL
        sSQL &= SQLString("D25F2070") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function


#Region "Combo Events"

    'IncidentID	51159 Cho lập Thông báo tuyển dụng từ Đợt tuyển dụng
#Region "Events tdbcRecruitmentFileID"
    Private Sub tdbcRecruitmentFileID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecruitmentFileID.LostFocus
        If tdbcRecruitmentFileID.FindStringExact(tdbcRecruitmentFileID.Text) = -1 Then tdbcRecruitmentFileID.Text = ""
    End Sub
    Private Sub tdbcRecruitmentFileID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecruitmentFileID.Close
        tdbcRecruitmentFileID_Validated(sender, Nothing)
    End Sub
    Private Sub tdbcRecruitmentFileID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcRecruitmentFileID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        '*************************
        Dim sRecruitmentFileID As String = ReturnValueC1Combo(tdbcRecruitmentFileID)
        If tdbcRecruitmentFileID.Tag Is Nothing OrElse tdbcRecruitmentFileID.Tag.ToString <> sRecruitmentFileID Then
            Dim dt As DataTable = ReturnDataTable(SQLStoreD25P1041_New)
            If dtGrid IsNot Nothing Then dtGrid.Clear()
            dtGrid.Merge(dt, False, MissingSchemaAction.AddWithKey)
            LoadTDBGrid()
            '*************************
            tdbcRecruitmentFileID.Tag = sRecruitmentFileID
        End If
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1041
    '# Created User: Phan Văn Thông
    '# Created Date: 09/10/2012 09:13:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1041_New() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi khi chon lai Combo Dot TD" & vbCrLf)
        sSQL &= "Exec D25P1041 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecruitmentFileID)) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber("0") & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString("D25F2070") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA
        sSQL &= SQLString(My.Computer.Name)
        Return sSQL
    End Function
#End Region

#Region "Events tdbcCreatorID"
    Private Sub tdbcCreatorID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.LostFocus
        If tdbcCreatorID.FindStringExact(tdbcCreatorID.Text) = -1 Then tdbcCreatorID.Text = ""
    End Sub
#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCreatorID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub


#Region "Grid Events"

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        If tdbg.Columns(COL_TransID).Text = "" Then tdbg.Columns(COL_TransID).Text = ""

        Select Case e.ColIndex
            Case COL_BlockName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_BlockID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_BlockID).Text = tdbdBlockID.Columns("BlockID").Text
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
                tdbg.Columns(COL_TeamID).Text = ""
                tdbg.Columns(COL_TeamName).Text = ""

            Case COL_TeamName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_TeamID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns("TeamID").Text

            Case COL_RecPositionName
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_RecPositionID).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_RecPositionID).Text = tdbdRecPositionID.Columns("RecPositionID").Text

            Case COL_DateFrom, COL_DateTo
                tdbg.Select()
        End Select

        ResetGrid()
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        ResetGrid()
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_Number
                If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Int) Then tdbg.Columns(e.ColIndex).Text = ""

            Case COL_BlockName, COL_DepartmentName, COL_TeamName, COL_RecPositionName
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                Select Case tdbg.Col
                    Case COL_BlockName
                        F7More(tdbg, COL_BlockID)

                    Case COL_DepartmentName
                        F7More(tdbg, COL_DepartmentID)

                    Case COL_TeamName
                        F7More(tdbg, COL_TeamID)

                    Case COL_RecPositionName
                        F7More(tdbg, COL_RecPositionID)
                    Case Else
                        HotKeyF7(tdbg)
                End Select
                ResetGrid()
            Case Keys.F8
                If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                    HotKeyF8(tdbg)
                    tdbg.Columns(COL_TransID).Text = ""
                Else
                    D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                ResetGrid()
            Case Keys.Enter
                If tdbg.Col = COL_NoteDetail Then HotKeyEnterGrid(tdbg, COL_BlockName, e, SPLIT0)
        End Select

        If bIsUseBlock Then
            HotKeyDownGrid(e, tdbg, COL_BlockName)
        Else
            HotKeyDownGrid(e, tdbg, COL_DepartmentName)
        End If
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_Number
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        '--- Đổ nguồn cho các Dropdown phụ thuộc
        Select Case tdbg.Col
            Case COL_DepartmentName
                LoadTdbdDepartmentID()
            Case COL_TeamName
                LoadtdbdTeamID()
        End Select
    End Sub


#End Region

#Region "SQL, Store"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1041
    '# Created User: DUCTRONG
    '# Created Date: 25/06/2010 03:57:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1041(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P1041 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_recInformationID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA
        sSQL &= SQLString(My.Computer.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2070
    '# Created User: DUCTRONG
    '# Created Date: 25/06/2010 04:05:31
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2070() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D25T2070(")
        sSQL.Append("DivisionID, RecInformationID, RecInformationName, RecInformationNameU, Note, NoteU, ")
        sSQL.Append("DateFrom, DateTo, CreateDate, CreateUserID, LastModifyDate, ")
        sSQL.Append("LastModifyUserID, TranMonth, TranYear, VoucherDate, CreatorID, ") 'VoucherNo,
        sSQL.Append("RecruitmentFileID ")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLString(_recInformationID) & COMMA) 'RecInformationID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtRecInformationName, False) & COMMA) 'RecInformationName, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtRecInformationName, True) & COMMA) 'RecInformationNameU, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote, False) & COMMA) 'Note, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtNote, True) & COMMA) 'NoteU, varchar[250], NOT NULL
        sSQL.Append(SQLDateSave(c1dateFromDate.Text) & COMMA) 'DateFrom, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateToDate.Text) & COMMA) 'DateTo, datetime, NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, smallint, NOT NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'VoucherDate, datetime, NULL
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcCreatorID)) & COMMA) 'CreatorID, varchar[20], NOT NULL
        'sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[50], NOT NULL
        'IncidentID	51159 Cho lập Thông báo tuyển dụng từ Đợt tuyển dụng
        sSQL.Append(SQLString(ReturnValueC1Combo(tdbcRecruitmentFileID))) 'RecruitmentFileID, varchar[50], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD25T2070
    '# Created User: DUCTRONG
    '# Created Date: 25/06/2010 04:11:57
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T2070() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T2070 Set ")
        sSQL.Append("RecInformationName = " & SQLStringUnicode(txtRecInformationName, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("RecInformationNameU = " & SQLStringUnicode(txtRecInformationName, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("Note = " & SQLStringUnicode(txtNote, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("NoteU = " & SQLStringUnicode(txtNote, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("DateFrom = " & SQLDateSave(c1dateFromDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("DateTo = " & SQLDateSave(c1dateToDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("VoucherDate = " & SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("CreatorID = " & SQLString(ReturnValueC1Combo(tdbcCreatorID)) & COMMA) 'varchar[20], NOT NULL
        'sSQL.Append("VoucherNo = " & SQLString(txtVoucherNo.Text) & COMMA) 'varchar[50], NOT NULL
        'IncidentID	51159 Cho lập Thông báo tuyển dụng từ Đợt tuyển dụng
        sSQL.Append("RecruitmentFileID = " & SQLString(ReturnValueC1Combo(tdbcRecruitmentFileID))) 'varchar[50], NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("RecInformationID = " & SQLString(_recInformationID)) 'varchar[20], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2040s
    '# Created User: DUCTRONG
    '# Created Date: 25/06/2010 04:08:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2040s() As StringBuilder
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
            If tdbg(i, COL_TransID).ToString = "" Then
                sTranID = CreateIGEs("D25T2040", "TransID", "25", "RT", gsStringKey, sTranID, iCountIGE)
                tdbg(i, COL_TransID) = sTranID
            End If

            sSQL.Append("Insert Into D25T2040(")
            sSQL.Append("VoucherID, TransTypeID, TransID, BlockID, DepartmentID, ")
            sSQL.Append("TeamID, RecpositionID, Quantity, FromDate, ToDate, ")
            sSQL.Append("Notes, NotesU")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(_recInformationID) & COMMA) 'VoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString("IN") & COMMA) 'TransTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_BlockID)) & COMMA) 'BlockID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_RecPositionID)) & COMMA) 'RecpositionID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_Number)) & COMMA) 'Quantity, int, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateFrom)) & COMMA) 'FromDate, datetime, NOT NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DateTo)) & COMMA) 'ToDate, datetime, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_NoteDetail), gbUnicode, False) & COMMA) 'Notes, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_NoteDetail), gbUnicode, True)) 'Notes, varchar[500], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2040
    '# Created User: DUCTRONG
    '# Created Date: 25/06/2010 04:15:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2040() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2040"
        sSQL &= " Where "
        sSQL &= "VoucherID = " & SQLString(_recInformationID)
        Return sSQL
    End Function


#End Region



End Class