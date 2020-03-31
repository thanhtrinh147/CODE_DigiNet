Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:43:43 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 
'# Modify User: 
'#-------------------------------------------------------------------------------------
Public Class D13F1050
	Dim report As D99C2003
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Private _formIDPermission As String = "D13F1050"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property

#Region "Const of tdbg - Total of Columns: 11"
    Private Const COL_OfficialTitleID As Integer = 0    ' OfficialTitleID
    Private Const COL_OfficialTitleName As Integer = 1  ' Ngạch lương
    Private Const COL_Grade As Integer = 2              ' Bậc lương
    Private Const COL_SalaryLevelID As Integer = 3      ' Mã bậc lương
    Private Const COL_SalaryCoefficient As Integer = 4  ' Hệ số lương
    Private Const COL_NumberYearTransfer As Integer = 5 ' Thời gian giữ bậc
    Private Const COL_Disabled As Integer = 6           ' KSD
    Private Const COL_CreateUserID As Integer = 7       ' Người tạo
    Private Const COL_CreateDate As Integer = 8         ' Ngày tạo
    Private Const COL_LastModifyUserID As Integer = 9   ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As Integer = 10    ' Ngày cập nhật cuối cùng
#End Region

    Dim dtGrid, dtCaptionCols As DataTable
    Dim dtCaption As DataTable
    Dim dtFilter As DataTable
    Dim bRefreshFilter As Boolean
    Dim sFilter As New System.Text.StringBuilder()

    Dim bKeyPress As Boolean = False
    Dim bChangeRow As Boolean = True 'Kiểm tra xem có được di chuyển qua dòng khác không
    Dim bAskSave As Boolean = True 'Kiểm tra xem có thông báo hỏi khi nhấn nút Lưu không

    Private _officialTitleID As String = ""
    Public Property OfficialTitleID() As String
        Get
            Return _officialTitleID
        End Get
        Set(ByVal Value As String)
            _officialTitleID = Value
            ' D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Output01", Value)
        End Set
    End Property

    Private _salaryLevelID As String = ""
    Public Property SalaryLevelID() As String
        Get
            Return _salaryLevelID
        End Get
        Set(ByVal Value As String)
            _salaryLevelID = Value
            '  D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Output02", Value)
        End Set
    End Property

    Private _OldGrade As String = ""
    Public Property OldGrade() As String
        Get
            Return _OldGrade
        End Get
        Set(ByVal value As String)
            If _OldGrade = Value Then
                Return
            End If
            _OldGrade = Value
        End Set
    End Property

    Private _maxGrade As Integer = 0
    Public WriteOnly Property MaxGrade() As Integer
        Set(ByVal Value As Integer)
            _maxGrade = Value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            chkIsUseOfficialF1.Tag = "True"
            chkIsUseOfficialF2.Tag = "True"
            chkIsUseOfficial1.Tag = "True"
            chkIsUseOfficial2.Tag = "True"
            FormatC1Number()
            CreateTable()
            LoadTDBCombo()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    ResizeForm() ' gọi từ Nghiệp vụ
                    LoadAdd()
                    btnNext.Enabled = False
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    LoadEdit()
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub ResizeForm()
        ' Cách lấy kích thước
        Dim iTitleHeight As Integer = 22 ' chiều cao TitleHeight
        Dim iLine As Integer = 3 ' 3 đường viền Trái, Phải, Trên
        Dim iWidthControl As Integer = 5 ' khoảng cách các từ viền trái tới GroupBox

        TableToolStrip.Visible = False
        tdbg.Visible = False
        pnlFilter.Visible = False
        chkDisabled.Visible = False

        GroupBox1.Location = New Point(iWidthControl, iWidthControl)
        Me.Width = GroupBox1.Width + (2 * (iWidthControl + iLine))  ' Khoảng cách cách ra 2 bên
        Me.Height = GroupBox1.Height + GroupBox1.Location.Y + iTitleHeight + iLine + pnlButton.Height + (2 * iWidthControl)

        pnlButton.Location = New Point(Me.Width - pnlButton.Width - (2 * iLine) - iWidthControl, Me.Height - pnlButton.Height - iTitleHeight - iLine - iWidthControl)
    End Sub

    Private Sub D13F1050_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bKeyPress Then Exit Sub

        If _FormState = EnumFormState.FormEdit Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then
            If btnSave.Enabled Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        End If
    End Sub

    Private Sub D13F1050_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
    End Sub

    Private Sub D13F1050_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If tdbg.FilterActive Then
            bKeyPress = False
        Else
            bKeyPress = True
        End If
    End Sub

    Private Sub D13F1050_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        SetShortcutPopupMenu(Me, TableToolStrip, ContextMenuStrip1)
        gbEnabledUseFind = False
        Loadlanguage()
        'ID 97485 02.06.2017
        LoadCaptionShortBySystem()

        ResetColorGrid(tdbg)
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtSalaryLevelID)
        SetBackColorObligatory()
        SetResolutionForm(Me, ContextMenuStrip1)
       
    End Sub

    Private Sub LoadCaptionShortBySystem()
        Dim sSQL As String = ""
        sSQL = "        SELECT Code, T1.ShortU AS CaptionOptionName " & vbCrLf & _
                " FROM D13T9000 T1 WITH(NOLOCK) " & vbCrLf & _
                " WHERE T1.Type = 'OLSC' AND T1.Code IN ('OLSC1','OLSC2')"
        Dim dtCap As DataTable = ReturnDataTable(sSQL)
        If dtCap.Rows.Count = 2 Then
            chkIsUseOfficialF1.Text = L3String(dtCap.Rows(0)("CaptionOptionName"))
            chkIsUseOfficialF2.Text = L3String(dtCap.Rows(1)("CaptionOptionName"))
            chkIsUseOfficial1.Text = L3String(dtCap.Rows(0)("CaptionOptionName"))
            chkIsUseOfficial2.Text = L3String(dtCap.Rows(1)("CaptionOptionName"))
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        AnchorForControl(EnumAnchorStyles.TopLeftRight, pnlFilter)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, chkShowDisabled)
        AnchorForControl(EnumAnchorStyles.TopRight, GroupBox1, pnlButton)

    End Sub
    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_bac_luong_-_D13F1050") & UnicodeCaption(gbUnicode) 'Danh móc bËc l§¥ng - D13F1050
        '================================================================ 
        lblOfficialTitleIDF.Text = rl3("Ngach_luong") 'Ngạch lương
        lblOfficialTitleID.Text = rl3("Ngach_luong") 'Ngạch lương
        lblSalaryLevelID.Text = rl3("Ma_bac_luong") 'Mã bậc lương
        lblGrade.Text = rl3("Bac_luong") 'Bậc lương
        lblNumberYearTransfer.Text = rl3("Thoi_gian_giu_bac_toi_thieu")
        lblNote.Text = rl3("Ghi_chu") ' Ghi chú
        lblSalaryLevelName.Text = rl3("Ten_bac_luong") ' Tên bậc lương
        lblMonth.Text = rl3("Thang") ' Tháng
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu && Nhập &tiếp
        '================================================================ 
        chkIsUseOfficialF1.Text = rl3("Ngach") & " 1"
        chkIsUseOfficialF2.Text = rl3("Ngach") & " 2"
        chkIsUseOfficial1.Text = rl3("Ngach") & " 1"
        chkIsUseOfficial2.Text = rl3("Ngach") & " 2"
        '================================================================ 
        GroupBox1.Text = rl3("Chi_tiet") 'Chi tiết
        '================================================================ 
        tdbcOfficialTitleIDF.Columns("OfficialTitleID").Caption = rl3("Ma") 'Mã
        tdbcOfficialTitleIDF.Columns("OfficialTitleName").Caption = rl3("Ten") 'Tên
        tdbcOfficialTitleID.Columns("OfficialTitleID").Caption = rl3("Ma") 'Mã
        tdbcOfficialTitleID.Columns("OfficialTitleName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("OfficialTitleName").Caption = rL3("Ngach_luong") 'Ngạch lương
        tdbg.Columns("SalaryLevelID").Caption = rl3("Ma_bac_luong") 'Mã bậc lương
        tdbg.Columns("SalaryCoefficient").Caption = rl3("He_so_luong") 'Hệ số lương
        tdbg.Columns("Grade").Caption = rl3("Bac_luong") 'Bậc lương
        tdbg.Columns("NumberYearTransfer").Caption = rl3("Thoi_gian_giu_bac")
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'KSD
        '================================================================ 
        chkShowDisabled.Text = rl3("Hien_thi_danh_muc_khong_su_dung") 'Hiển thị danh mục không sử dụng
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
    End Sub

    Private Sub CreateTable()
        Dim sSQL As String = ""
        sSQL = "Select Code, Decimals, Disabled, Short" & UnicodeJoin(gbUnicode) & " as Short From D13T9000  WITH (NOLOCK) Where Type = 'OLSC'"
        dtCaption = ReturnDataTable(sSQL)
    End Sub

    Private Sub FormatC1Number()
        InputNumber(cneGrade, SqlDbType.Int, "N0", False, 28, 8) 'Nhập số âm = True. Default = False
        InputNumber(cneNumberYearTransfer, SqlDbType.Int, "N0", False, 28, 8) 'Nhập số âm = True. Default = False
    End Sub

    Private Sub LoadCaption(ByVal sIsUseOfficial As String)
        If sIsUseOfficial = "1" Then
            dtFilter = ReturnTableFilter(dtCaption, "Code like 'OLSC1%'")
            For i As Integer = 0 To dtFilter.Rows.Count - 1
                With dtFilter.Rows(i)
                    Select Case .Item("Code").ToString
                        Case "OLSC11"
                            lblSalaryCoefficient01.Text = .Item("Short").ToString
                            lblSalaryCoefficient01.Font = FontUnicode(gbUnicode)
                            cneSalaryCoefficient01.Enabled = .Item("Disabled").ToString = "0"
                            InputNumber(cneSalaryCoefficient01, SqlDbType.Decimal, "N" & .Item("Decimals").ToString, False, 28, 8) 'Nhập số âm = True. Default = False

                        Case "OLSC12"
                            lblSalaryCoefficient02.Text = .Item("Short").ToString
                            lblSalaryCoefficient02.Font = FontUnicode(gbUnicode)
                            cneSalaryCoefficient02.Enabled = .Item("Disabled").ToString = "0"
                            InputNumber(cneSalaryCoefficient02, SqlDbType.Decimal, "N" & .Item("Decimals").ToString, False, 28, 8) 'Nhập số âm = True. Default = False
                        Case "OLSC13"
                            lblSalaryCoefficient03.Text = .Item("Short").ToString
                            lblSalaryCoefficient03.Font = FontUnicode(gbUnicode)
                            cneSalaryCoefficient03.Enabled = .Item("Disabled").ToString = "0"
                            InputNumber(cneSalaryCoefficient03, SqlDbType.Decimal, "N" & .Item("Decimals").ToString, False, 28, 8) 'Nhập số âm = True. Default = False
                        Case "OLSC14"
                            lblSalaryCoefficient04.Text = .Item("Short").ToString
                            lblSalaryCoefficient04.Font = FontUnicode(gbUnicode)
                            cneSalaryCoefficient04.Enabled = .Item("Disabled").ToString = "0"
                            InputNumber(cneSalaryCoefficient04, SqlDbType.Decimal, "N" & .Item("Decimals").ToString, False, 28, 8) 'Nhập số âm = True. Default = False
                        Case "OLSC15"
                            lblSalaryCoefficient05.Text = .Item("Short").ToString
                            lblSalaryCoefficient05.Font = FontUnicode(gbUnicode)
                            cneSalaryCoefficient05.Enabled = .Item("Disabled").ToString = "0"
                            InputNumber(cneSalaryCoefficient05, SqlDbType.Decimal, "N" & .Item("Decimals").ToString, False, 28, 8) 'Nhập số âm = True. Default = False
                    End Select
                End With
            Next
        ElseIf sIsUseOfficial = "2" Then
            dtFilter = ReturnTableFilter(dtCaption, "Code like 'OLSC2%'")
            For i As Integer = 0 To dtFilter.Rows.Count - 1
                With dtFilter.Rows(i)
                    Select Case .Item("Code").ToString
                        Case "OLSC21"
                            lblSalaryCoefficient01.Text = .Item("Short").ToString
                            lblSalaryCoefficient01.Font = FontUnicode(gbUnicode)
                            cneSalaryCoefficient01.Enabled = .Item("Disabled").ToString = "0"
                            InputNumber(cneSalaryCoefficient01, SqlDbType.Decimal, "N" & .Item("Decimals").ToString, False, 28, 8) 'Nhập số âm = True. Default = False
                        Case "OLSC22"
                            lblSalaryCoefficient02.Text = .Item("Short").ToString
                            lblSalaryCoefficient02.Font = FontUnicode(gbUnicode)
                            cneSalaryCoefficient02.Enabled = .Item("Disabled").ToString = "0"
                            InputNumber(cneSalaryCoefficient02, SqlDbType.Decimal, "N" & .Item("Decimals").ToString, False, 28, 8) 'Nhập số âm = True. Default = False
                        Case "OLSC23"
                            lblSalaryCoefficient03.Text = .Item("Short").ToString
                            lblSalaryCoefficient03.Font = FontUnicode(gbUnicode)
                            cneSalaryCoefficient03.Enabled = .Item("Disabled").ToString = "0"
                            InputNumber(cneSalaryCoefficient03, SqlDbType.Decimal, "N" & .Item("Decimals").ToString, False, 28, 8) 'Nhập số âm = True. Default = False
                        Case "OLSC24"
                            lblSalaryCoefficient04.Text = .Item("Short").ToString
                            lblSalaryCoefficient04.Font = FontUnicode(gbUnicode)
                            cneSalaryCoefficient04.Enabled = .Item("Disabled").ToString = "0"
                            InputNumber(cneSalaryCoefficient04, SqlDbType.Decimal, "N" & .Item("Decimals").ToString, False, 28, 8) 'Nhập số âm = True. Default = False
                        Case "OLSC25"
                            lblSalaryCoefficient05.Text = .Item("Short").ToString
                            lblSalaryCoefficient05.Font = FontUnicode(gbUnicode)
                            cneSalaryCoefficient05.Enabled = .Item("Disabled").ToString = "0"
                            InputNumber(cneSalaryCoefficient05, SqlDbType.Decimal, "N" & .Item("Decimals").ToString, False, 28, 8) 'Nhập số âm = True. Default = False
                    End Select
                End With
            Next
        Else
            lblSalaryCoefficient01.Text = rl3("He_so_luong") & " 01"
            lblSalaryCoefficient02.Text = rl3("He_so_luong") & " 02"
            lblSalaryCoefficient03.Text = rl3("He_so_luong") & " 03"
            lblSalaryCoefficient04.Text = rl3("He_so_luong") & " 04"
            lblSalaryCoefficient05.Text = rl3("He_so_luong") & " 05"

            cneSalaryCoefficient01.Enabled = True
            cneSalaryCoefficient02.Enabled = True
            cneSalaryCoefficient03.Enabled = True
            cneSalaryCoefficient04.Enabled = True
            cneSalaryCoefficient05.Enabled = True

            InputNumber(cneSalaryCoefficient01, SqlDbType.Decimal, "N2", False, 28, 8) 'Nhập số âm = True. Default = False
            InputNumber(cneSalaryCoefficient02, SqlDbType.Decimal, "N2", False, 28, 8) 'Nhập số âm = True. Default = False
            InputNumber(cneSalaryCoefficient03, SqlDbType.Decimal, "N2", False, 28, 8) 'Nhập số âm = True. Default = False
            InputNumber(cneSalaryCoefficient04, SqlDbType.Decimal, "N2", False, 28, 8) 'Nhập số âm = True. Default = False
            InputNumber(cneSalaryCoefficient05, SqlDbType.Decimal, "N2", False, 28, 8) 'Nhập số âm = True. Default = False
        End If
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcOfficialTitleIDF.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtSalaryLevelID.BackColor = COLOR_BACKCOLOROBLIGATORY
        cneSalaryCoefficient01.BackColor = COLOR_BACKCOLOROBLIGATORY
        cneGrade.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Dim dtDecimals As DataTable
    Private Sub tdbg_NumberFormat()
        If dtDecimals Is Nothing Then
            dtDecimals = ReturnDataTable("SELECT Code, Decimals FROM D13T9000  WITH (NOLOCK) WHERE	Type = 'OLSC' AND (Code = 'OLSC11' OR Code = 'OLSC21')")
        End If

        Dim sFormat As String = D13Format.DefaultNumber2
        If ReturnValueC1Combo(tdbcOfficialTitleIDF, "IsUseOfficial").ToString = "0" Then
            sFormat = InsertFormat(dtDecimals.Compute("Max(Decimals)", "").ToString)
        ElseIf ReturnValueC1Combo(tdbcOfficialTitleIDF, "IsUseOfficial").ToString = "1" Then
            sFormat = InsertFormat(dtDecimals.Select("Code = 'OLSC11'")(0).Item("Decimals").ToString)
        Else ' 2
            sFormat = InsertFormat(dtDecimals.Select("Code = 'OLSC21'")(0).Item("Decimals").ToString)
        End If
        tdbg.Columns(COL_SalaryCoefficient).NumberFormat = sFormat 'Format(tdbg.Columns(COL_SalaryCoefficient).Text, sFormat)
    End Sub

    Public Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        tdbg_NumberFormat()

        '        Dim IsUseOfficialF As Integer = 0
        '        If chkIsUseOfficialF1.Checked And chkIsUseOfficialF2.Checked Then
        '            IsUseOfficialF = 0
        '        ElseIf chkIsUseOfficialF1.Checked Then
        '            IsUseOfficialF = 1
        '        ElseIf chkIsUseOfficialF2.Checked Then
        '            IsUseOfficialF = 2
        '        End If

        '        Dim sSQL As String = ""
        '        sSQL &= "--Do nguon luoi danh muc bac luong" & vbCrLf
        '        sSQL &= "SELECT		T1.SalaryLevelID, T1.OfficialTitleID, T2.OfficialTitleName" & UnicodeJoin(gbUnicode) & " as OfficialTitleName, T1.SalaryCoefficient, T1.Disabled, " & vbCrLf
        '        sSQL &= "T1.CreateUserID, T1.CreateDate, T1.LastModifyUserID, T1.LastModifyDate, T1.NumberYearTransfer, T1.Grade, " & vbCrLf
        '        sSQL &= "T1.SalaryCoefficient02, T1.SalaryCoefficient03, T1.SalaryCoefficient04, T1.SalaryCoefficient05, T2.IsUseOfficial," & vbCrLf
        '        sSQL &= "NumberYearTransfer, Note" & UnicodeJoin(gbUnicode) & " as Note, SalaryLevelName" & UnicodeJoin(gbUnicode) & " as SalaryLevelName" & vbCrLf
        '        sSQL &= " FROM		D09T0215 T1 WITH(NOLOCK)" & vbCrLf
        '        sSQL &= " INNER JOIN 	D09T0214 T2 WITH(NOLOCK)" & vbCrLf
        '        sSQL &= "	ON		T1.OfficialTitleID=T2.OfficialTitleID " & vbCrLf
        '        sSQL &= " WHERE		T1.OfficialTitleID like " & SQLString(tdbcOfficialTitleIDF.Text) & vbCrLf
        '        sSQL &= "AND T2.IsUseOfficial=" & SQLNumber(IsUseOfficialF) & vbCrLf
        '        ' sSQL &= "AND T2.IsUseOfficial=" & SQLNumber(ReturnValueC1Combo(tdbcOfficialTitleIDF, "IsUseOfficial")) & vbCrLf
        '        sSQL &= " ORDER BY	SalaryLevelID" & vbCrLf

        Dim sSQL As String = SQLStoreD13P0214(1)
        dtGrid = ReturnDataTable(sSQL)

        gbEnabledUseFind = dtGrid.Rows.Count > 0

        If FlagAdd Then ' Thêm mới thì set Filter = "" và sFind =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OfficialTitleName).Visible = (ReturnValueC1Combo(tdbcOfficialTitleIDF) = "%")
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid(False)

        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select("SalaryLevelID = " & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0))
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If

        LoadEdit()
    End Sub

    Private Sub ReLoadTDBGrid(Optional ByVal bLoadEdit As Boolean = True)
        '  If AllowActive() = False Then Exit Sub
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled =0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
        bKeyPress = False

        If bLoadEdit Then LoadEdit()
    End Sub

    Private Sub ResetGrid()
        EnabledMenu()
        FooterTotalGrid(tdbg, COL_SalaryLevelID)
    End Sub

    Private Sub EnabledMenu()
        If tdbcOfficialTitleIDF.Text = "%" Then
            CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , "D13F5604")
            tsbEdit.Enabled = False
            tsbDelete.Enabled = False
            tsmEdit.Enabled = False
            tsmDelete.Enabled = False
            mnsEdit.Enabled = False
            mnsDelete.Enabled = False
        Else
            CheckMenu(_formIDPermission, TableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1, , "D13F5604")
        End If
        ' update 27/3/2013 id 55214 - Chuẩn hóa phân quyền menu Import dữ liệu
        ' ImportData phân quyền theo 2 màn hình D13F5604 và PARA_FormIDPermission
        tsbImportData.Enabled = tsbImportData.Enabled And tsbAdd.Enabled = True
        tsmImportData.Enabled = tsbImportData.Enabled
        mnsImportData.Enabled = tsbImportData.Enabled
    End Sub

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến trong từng form.
    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    Private Sub tsbFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        '72334
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        Dim arrColObligatory() As Integer = {COL_SalaryLevelID, COL_SalaryCoefficient, COL_Grade}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, False, False, gbUnicode)
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    '    Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '        If ResultWhereClause Is Nothing Or ResultWhereClause.Tostring = "" Then Exit Sub
    '        sFind = ResultWhereClause.ToString()
    '        ReLoadTDBGrid()
    '    End Sub

#End Region

    Dim dtOfficialTitleIDF As DataTable
    Dim dtOfficialTitleIDD As DataTable

    Private Sub LoadTDBCombo()
        Dim sSQL As String = SQLStoreD13P0214(0)
        '        'Load tdbcOfficialTitleID, tdbcOfficialTitleIDF
        '        sSQL &= "Select '%' OfficialTitleID, " & AllName & " as OfficialTitleName, 0 as IsUseOfficial, 0 AS DisplayOrder " & vbCrLf
        '        sSQL &= "UNION " & vbCrLf
        '        sSQL &= "Select OfficialTitleID, OfficialTitleName" & UnicodeJoin(gbUnicode) & " As OfficialTitleName, IsUseOfficial, 1 AS DisplayOrder" & vbCrLf
        '        sSQL &= "From D09T0214 Where Disabled=0" & vbCrLf
        '        sSQL &= "ORDER BY OfficialTitleID"
        dtOfficialTitleIDF = ReturnDataTable(sSQL)

        dtOfficialTitleIDD = dtOfficialTitleIDF.DefaultView.ToTable
        dtOfficialTitleIDD.Rows.RemoveAt(0) ' bỏ dòng %

        LoadTDBCOfficialTitleIDF()
        LoadTDBCOfficialTitleIDD()
    End Sub

    Private Sub LoadTDBCOfficialTitleIDF()
        ' If _FormState = EnumFormState.FormAdd Then Exit Sub

        If dtOfficialTitleIDF Is Nothing Then Exit Sub

        Dim IsUseOfficialF As Integer = 0
        If chkIsUseOfficialF1.Checked And chkIsUseOfficialF2.Checked Then
            IsUseOfficialF = 0
        ElseIf chkIsUseOfficialF1.Checked Then
            IsUseOfficialF = 1
        ElseIf chkIsUseOfficialF2.Checked Then
            IsUseOfficialF = 2
        End If

        Dim dt As DataTable
        If IsUseOfficialF = 0 Then
            dt = dtOfficialTitleIDF.DefaultView.ToTable
        Else
            dt = ReturnTableFilter(dtOfficialTitleIDF, "OfficialTitleID = '%' or IsUseOfficial= 0 or IsUseOfficial=" & SQLNumber(IsUseOfficialF), True)
        End If

        LoadDataSource(tdbcOfficialTitleIDF, dt, gbUnicode)
    End Sub

    Private Sub LoadTDBCOfficialTitleIDD(Optional ByVal bLoadEdit As Boolean = False)
        If dtOfficialTitleIDD Is Nothing Then Exit Sub

        Dim IsUseOfficial As Integer = 0
        If chkIsUseOfficial1.Checked And chkIsUseOfficial2.Checked Then
            IsUseOfficial = 0
        ElseIf chkIsUseOfficial1.Checked Then
            IsUseOfficial = 1
        ElseIf chkIsUseOfficial2.Checked Then
            IsUseOfficial = 2
        End If
        Dim dt As DataTable = ReturnTableFilter(dtOfficialTitleIDD, "IsUseOfficial=" & SQLNumber(IsUseOfficial), True)
        LoadDataSource(tdbcOfficialTitleID, dt, gbUnicode)

    End Sub

    Private Sub chkIsUseOfficialF1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUseOfficialF1.CheckedChanged
        If chkIsUseOfficialF1.Checked = False And chkIsUseOfficialF2.Checked = False Then
            chkIsUseOfficialF1.Tag = "False"
            D99C0008.MsgL3(rl3("Khong_duoc_go_ca_2_checkbox_ngach"))
            chkIsUseOfficialF1.Checked = True
            Exit Sub
        End If
        ' Không cho uncheck cả 2 check, chặn trường hợp khi uncheck mà check lại sẽ load lại combo
        If chkIsUseOfficialF1.Tag Is Nothing OrElse chkIsUseOfficialF1.Tag.ToString = "False" Then
            chkIsUseOfficialF1.Tag = "True"
            Exit Sub
        End If
        LoadTDBCOfficialTitleIDF()
    End Sub

    Private Sub chkIsUseOfficialF2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUseOfficialF2.CheckedChanged
        If chkIsUseOfficialF1.Checked = False And chkIsUseOfficialF2.Checked = False Then
            chkIsUseOfficialF2.Tag = "False"
            D99C0008.MsgL3(rl3("Khong_duoc_go_ca_2_checkbox_ngach"))
            chkIsUseOfficialF2.Checked = True
            Exit Sub
        End If
        ' Không cho uncheck cả 2 check, chặn trường hợp khi uncheck mà check lại sẽ load lại combo
        If chkIsUseOfficialF2.Tag Is Nothing OrElse chkIsUseOfficialF2.Tag.ToString = "False" Then
            chkIsUseOfficialF2.Tag = "True"
            Exit Sub
        End If
        LoadTDBCOfficialTitleIDF()
    End Sub

    Private Sub chkIsUseOfficial1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUseOfficial1.CheckedChanged
        If chkIsUseOfficial1.Checked = False And chkIsUseOfficial2.Checked = False Then
            chkIsUseOfficial1.Tag = "False"
            D99C0008.MsgL3(rl3("Khong_duoc_go_ca_2_checkbox_ngach"))
            chkIsUseOfficial1.Checked = True
            Exit Sub
        End If
        ' Không cho uncheck cả 2 check, chặn trường hợp khi uncheck mà check lại sẽ load lại combo
        If chkIsUseOfficial1.Tag Is Nothing OrElse chkIsUseOfficial1.Tag.ToString = "False" Then
            chkIsUseOfficial1.Tag = "True"
            Exit Sub
        End If
        LoadTDBCOfficialTitleIDD()
    End Sub

    Private Sub chkIsUseOfficial2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsUseOfficial2.CheckedChanged
        If chkIsUseOfficial1.Checked = False And chkIsUseOfficial2.Checked = False Then
            chkIsUseOfficial2.Tag = "False"
            D99C0008.MsgL3(rl3("Khong_duoc_go_ca_2_checkbox_ngach"))
            chkIsUseOfficial2.Checked = True
            Exit Sub
        End If
        ' Không cho uncheck cả 2 check, chặn trường hợp khi uncheck mà check lại sẽ load lại combo
        If chkIsUseOfficial2.Tag Is Nothing OrElse chkIsUseOfficial2.Tag.ToString = "False" Then
            chkIsUseOfficial2.Tag = "True"
            Exit Sub
        End If
        LoadTDBCOfficialTitleIDD()
    End Sub

    Private Function GetMaxGrade() As Integer
        Dim iGrade As Integer
        If tdbg.RowCount > 0 Then
            iGrade = SafeCint(tdbg(0, COL_Grade))
        Else
            iGrade = 0
        End If

        For i As Integer = 1 To tdbg.RowCount - 1
            If SafeCint(tdbg(i, COL_Grade)) > iGrade Then
                iGrade = SafeCint(tdbg(i, COL_Grade))
            End If
        Next i

        Return iGrade
    End Function

    Private Sub LoadAdd()
        _FormState = EnumFormState.FormAdd
        sValueMaster = ""
        '********************
        _bSaved = False
        bKeyPress = False
        bTemp = False
        '*******************
        ClearText(GroupBox1, chkIsUseOfficial1, chkIsUseOfficial2)
        chkDisabled.Checked = False
        chkDisabled.Visible = False
        '        chkIsUseOfficial1.Checked = True
        '        chkIsUseOfficial2.Checked = True
        chkIsUseOfficial1.Enabled = True
        chkIsUseOfficial2.Enabled = True
        LoadTDBCOfficialTitleIDD()
        If tdbg.Visible Then
            tdbcOfficialTitleID.SelectedValue = tdbg.Columns(COL_OfficialTitleID).Text
            cneGrade.Value = Number(GetMaxGrade) + 1

        Else
            tdbcOfficialTitleID.SelectedValue = _officialTitleID
            cneGrade.Value = _maxGrade + 1
        End If
      
        cneSalaryCoefficient01.Value = 0
        cneSalaryCoefficient02.Value = 0
        cneSalaryCoefficient03.Value = 0
        cneSalaryCoefficient04.Value = 0
        cneSalaryCoefficient05.Value = 0

        LoadCaption(ReturnValueC1Combo(tdbcOfficialTitleID, "IsUseOfficial").ToString)
        '*******************
        UnReadOnlyControl(True, txtSalaryLevelID, tdbcOfficialTitleID)
        tdbcOfficialTitleID.Focus()
        '*******************
        btnSave.Enabled = True
        btnSave.Left = btnNext.Left - btnSave.Width - 6
        btnNext.Visible = True
        btnNext.Enabled = True
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu && Nhập &tiếp
    End Sub

    Dim sValueMaster As String = ""
    Private Sub LoadEdit()

        If dtGrid Is Nothing Then Exit Sub 'Chưa đổ nguồn cho lưới
        If sValueMaster = tdbg.Columns(COL_Grade).Text & "-" & tdbg.Columns(COL_SalaryLevelID).Text & "-" & tdbg.Columns(COL_OfficialTitleID).Text Then
            EnabledSave()
            Exit Sub
        End If
        sValueMaster = tdbg.Columns(COL_Grade).Text & "-" & tdbg.Columns(COL_SalaryLevelID).Text & "-" & tdbg.Columns(COL_OfficialTitleID).Text
        '************************
        'Gán dữ liệu
        Dim dr() As DataRow = dtGrid.Select("SalaryLevelID=" & SQLString(tdbg.Columns(COL_SalaryLevelID).Text) & " AND Grade = " & SQLString(tdbg.Columns(COL_Grade).Text) & " AND OfficialTitleID = " & SQLString(tdbg.Columns(COL_OfficialTitleID).Text))
        If dr.Length > 0 Then
            If L3Int(dr(0).Item("IsUseOfficial").ToString) = 0 Then
                chkIsUseOfficial1.Checked = True
                chkIsUseOfficial2.Checked = True
            ElseIf L3Int(dr(0).Item("IsUseOfficial").ToString) = 1 Then
                chkIsUseOfficial1.Checked = True
                chkIsUseOfficial2.Checked = False
            Else
                chkIsUseOfficial2.Checked = True
                chkIsUseOfficial1.Checked = False
            End If
            LoadTDBCOfficialTitleIDD(True)
            tdbcOfficialTitleID.SelectedValue = dr(0).Item("OfficialTitleID").ToString
            If tdbcOfficialTitleID.SelectedValue Is Nothing Then
                txtOfficialTitleName.Text = ""
            End If
            ' txtOfficialTitleName.Text = dr(0).Item("OfficialTitleName").ToString
            txtSalaryLevelID.Text = dr(0).Item("SalaryLevelID").ToString
            txtSalaryLevelName.Text = dr(0).Item("SalaryLevelName").ToString
            chkDisabled.Checked = Convert.ToBoolean(dr(0).Item("Disabled").ToString)

            cneSalaryCoefficient01.Value = dr(0).Item("SalaryCoefficient")
            cneSalaryCoefficient02.Value = dr(0).Item("SalaryCoefficient02")
            cneSalaryCoefficient03.Value = dr(0).Item("SalaryCoefficient03")
            cneSalaryCoefficient04.Value = dr(0).Item("SalaryCoefficient04")
            cneSalaryCoefficient05.Value = dr(0).Item("SalaryCoefficient05")

            cneNumberYearTransfer.Value = dr(0).Item("NumberYearTransfer")
            cneGrade.Value = dr(0).Item("Grade").ToString
            txtNote.Text = dr(0).Item("Note").ToString
        Else
            tdbcOfficialTitleID.Text = ""
            txtOfficialTitleName.Text = ""
            txtSalaryLevelID.Text = ""
            txtSalaryLevelName.Text = ""
            chkDisabled.Checked = False

            cneSalaryCoefficient01.Value = 0
            cneSalaryCoefficient02.Value = 0
            cneSalaryCoefficient03.Value = 0
            cneSalaryCoefficient04.Value = 0
            cneSalaryCoefficient05.Value = 0

            cneNumberYearTransfer.Value = 0
            cneGrade.Value = 0
            txtNote.Text = ""
        End If
        '************************
        chkDisabled.Visible = True
        chkIsUseOfficial1.Enabled = False
        chkIsUseOfficial2.Enabled = False
        ReadOnlyControl(txtSalaryLevelID, tdbcOfficialTitleID)
        '************************
        EnabledSave()
    End Sub

    Private Sub EnabledSave()
        If _FormState = EnumFormState.FormAdd Then
            btnNext.Visible = True
            btnSave.Left = btnNext.Left - btnSave.Width - 6
        Else
            chkDisabled.Visible = True
            btnNext.Visible = False
            btnSave.Left = btnNext.Left + (btnNext.Width - btnSave.Width)
            btnSave.Enabled = (_FormState <> EnumFormState.FormView)
        End If
    End Sub

#Region "Events tdbcOfficialTitleIDF with txtOfficialTitleNameF"

    Private Sub tdbcOfficialTitleIDF_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleIDF.SelectedValueChanged
        If tdbcOfficialTitleIDF.SelectedValue Is Nothing Then
            txtOfficialTitleNameF.Text = ""
        Else
            txtOfficialTitleNameF.Text = tdbcOfficialTitleIDF.Columns(1).Value.ToString
        End If
        If AllowActive() = False Then Exit Sub
        LoadTDBGrid(True)
    End Sub

    Private Sub tdbcOfficialTitleIDF_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleIDF.LostFocus
        If tdbcOfficialTitleIDF.FindStringExact(tdbcOfficialTitleIDF.Text) = -1 Then
            tdbcOfficialTitleIDF.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcOfficialTitleID with txtOfficialTitleName"

    Private Sub tdbcOfficialTitleID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID.LostFocus
        If tdbcOfficialTitleID.FindStringExact(tdbcOfficialTitleID.Text) = -1 Then
            tdbcOfficialTitleID.Text = ""
            txtOfficialTitleName.Text = ""
        End If
    End Sub

    Private Sub tdbcOfficialTitleID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcOfficialTitleID.SelectedValueChanged
        If Not (tdbcOfficialTitleID.Tag Is Nothing OrElse tdbcOfficialTitleID.Tag.ToString = "") Then
            tdbcOfficialTitleID.Tag = ""
            Exit Sub
        End If
        If tdbcOfficialTitleID.SelectedValue Is Nothing Then
            LoadCaption("0")
            Exit Sub
        End If
        LoadCaption(ReturnValueC1Combo(tdbcOfficialTitleID, "IsUseOfficial").ToString)
        txtOfficialTitleName.Text = tdbcOfficialTitleID.Columns("OfficialTitleName").Value.ToString
    End Sub

#End Region

#Region "Menu bar"

    Private Function AllowActive() As Boolean
        If txtSalaryLevelID.Text <> "" And bKeyPress = True Then
            If D99C0008.MsgAsk(rl3("Du_lieu_chua_duoc_luu") & " " & rl3("MSG000028")) = Windows.Forms.DialogResult.Yes Then
                bAskSave = False
                btnSave_Click(Nothing, Nothing)
                If bChangeRow Then 'neu chua luu dc thi van dung tai dong do
                    _FormState = EnumFormState.FormView
                    bKeyPress = False
                    Return True
                Else
                    Return False
                End If
            Else
                _FormState = EnumFormState.FormView
            End If
            bKeyPress = False
        Else
            _FormState = EnumFormState.FormView
        End If
        Return True
    End Function

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        If AllowActive() = False Then Exit Sub
        LoadAdd()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        If _FormState = EnumFormState.FormAdd Then
            If AllowActive() = False Then Exit Sub
        End If

        _FormState = EnumFormState.FormEdit
        LoadEdit()
        _bSaved = False
        bKeyPress = False
        txtOfficialTitleNameF.Focus()
    End Sub

    Private Function AllowDelete() As Boolean
        bChangeRow = False
        '*********************
        If Not CheckStore(SQLStoreD13P5555(2)) Then
            Return False
        End If
        '******************
        bChangeRow = True
        Return True
    End Function

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If AllowActive() = False Then Exit Sub
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        If Not AllowDelete() Then Exit Sub

        Dim sSQL As String = SQLDeleteD09T0215()
        Dim bResult As Boolean = ExecuteSQL(sSQL)

        If bResult = True Then
            DeleteOK()

            'Audit Log
            Dim sDesc1 As String = tdbg.Columns(COL_SalaryLevelID).Text
            Dim sDesc2 As String = tdbg.Columns(COL_OfficialTitleID).Text
            Dim sDesc3 As String = tdbg.Columns(COL_SalaryCoefficient).Text
            Dim sDesc4 As String = SQLNumber(CBool(tdbg.Columns(COL_Disabled).Text))
            Dim sDesc5 As String = ""
            RunAuditLog(AuditCodeSalaryLevels, "03", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            ResetGrid()
            LoadEdit()
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tsbExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_SalaryLevelID, COL_SalaryCoefficient, COL_Grade}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, True, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        '	Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)

        '        Dim frm As New D99F2222
        '        With frm
        '            .UseUnicode = gbUnicode
        '            .FormID = Me.Name
        '            .dtLoadGrid = dtCaptionCols
        '            .GroupColumns = gsGroupColumns
        '            .dtExportTable = dtGrid
        '            .ShowDialog()
        '            .Dispose()
        '        End With
        '*****************************************
    End Sub

    Private Sub tsbImportData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportData.Click, tsmImportData.Click, mnsImportData.Click
        If AllowActive() = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        'Gọi form Import Data như sau:
        If CallShowDialogD80F2090(D13, "D13F5604", "D13F1050") Then
            'Load lại dữ liệu
            bKeyPress = False
            'Load lại dữ liệu
            LoadTDBGrid(True)
        End If
        Me.Cursor = Cursors.Default

        '        Dim frm As New D80F2090
        '        With frm
        '            .FormActive = "D80F2090"
        '            .FormPermission = "D13F5604"
        '            .ModuleID = D13
        '            .TransTypeID = "D13F1050" 'Theo TL phân tích
        '            .sFont = IIf(gbUnicode, "UNICODE", "VNI").ToString
        '            .ShowDialog()
        '            If .OutPut01 Then .bSaved = .OutPut01
        '            .Dispose()
        '        End With
        '        If .bSaved Then
        '            bKeyPress = False
        '            'Load lại dữ liệu
        '            LoadTDBGrid(True)
        '        End If

    End Sub

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click, tsmPrint.Click, mnsPrint.Click
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        'Dim report As New D99C1003
        '************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D13R1050"
        Dim sSubReportName As String = IIf(gbUnicode, "D91R0000", "D09R6000").ToString
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""
        sReportCaption = rl3("In_danh_muc_bac_luong") & " - " & sReportName
        sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, "") & sReportName & ".rpt"
        sSQLSub = IIf(gbUnicode, "Select * From D91V0016 Where DivisionID = " & SQLString(gsDivisionID), "Select * From D09V0009").ToString
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(dtGrid.DefaultView.ToTable)
            .PrintReport(sPathReport, sReportCaption)
        End With
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

#End Region

#Region "Grid"

    Private Sub tdbg_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdbg.AfterSort
        If AllowActive() = False Then Exit Sub
        If tdbg.FilterActive Then Exit Sub
        LoadEdit()
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub
        If tdbcOfficialTitleIDF.Text <> "%" Then
            If tsbEdit.Enabled Then
                tsbEdit_Click(sender, Nothing)
            End If
        End If
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Disabled 'Chặn Ctrl + V trên cột Check
                e.Handled = Not ChrW(Keys.Space).Equals(e.KeyChar)
            Case COL_Grade, COL_NumberYearTransfer
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
            Case COL_SalaryCoefficient
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'MessageBox.Show(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub tdbg_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeRowColChange
        If tdbg.RowCount <= 1 OrElse tdbg.FilterActive OrElse _FormState = EnumFormState.FormView Then Exit Sub
        '*********************
        'Dữ liệu Chi tiết không thay đổi
        If Not bKeyPress Then
            _FormState = EnumFormState.FormView
            EnabledSave()
            Exit Sub
        End If
        '*********************
        'Dữ liệu Chi tiết có thay đổi
        If btnSave.Enabled Then
            '*************
            If AskMsgBeforeRowChange() Then
                bAskSave = False
                '************************************
                _FormState = EnumFormState.FormEdit
                btnSave_Click(sender, e)
                If bChangeRow = False Then 'Vi phạm nên không được di chuyển dòng
                    e.Cancel = True 'neu chua luu dc thi van dung tai dong do
                    bKeyPress = True
                    Exit Sub
                End If
            Else
                LoadEdit()
            End If
        End If

        _FormState = EnumFormState.FormView
        bKeyPress = False
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        'Neu luoi co 1 dong thi k can chay su kien nay
        If tdbg.RowCount <= 1 Then Exit Sub

        'Neu o thanh Filter thi k kiem tra va chay su kien RowColChange
        If tdbg.FilterActive Then
            bKeyPress = False
            Exit Sub
        End If

        If sValueMaster <> tdbg.Columns(COL_Grade).Text & "-" & tdbg.Columns(COL_SalaryLevelID).Text & "-" & tdbg.Columns(COL_OfficialTitleID).Text Then
            LoadEdit()
        End If
    End Sub
#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Dim bTemp As Boolean = False
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnNext.Focus()
        If btnNext.Focused = False Then Exit Sub
        '************************************
        If btnNext.Text = rl3("Luu_va_Nhap__tiep") Then
            btnSave_Click(Nothing, Nothing)
            If bTemp = False Then Exit Sub
        End If
        btnNext.Text = rl3("Luu_va_Nhap__tiep")
        btnSave.Enabled = True
        '************************************
        LoadAdd()
    End Sub

    Private Function AllowSave() As Boolean
        bChangeRow = False
        If tdbcOfficialTitleID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ngach_luong"))
            tdbcOfficialTitleID.Focus()
            Return False
        End If

        If Number(cneGrade.Value) = 0 Then
            D99C0008.MsgNotYetEnter(rl3("Bac_luong"))
            cneGrade.Focus()
            Return False
        End If

        If txtSalaryLevelID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_bac_luong"))
            txtSalaryLevelID.Focus()
            Return False
        End If
        If txtSalaryLevelID.Text.Trim <> "" And txtSalaryLevelID.Text.Trim.Length > 20 Then
            D99C0008.MsgL3(rl3("Do_dai_Ma_bac_luong_khong_duoc_qua_20_ky_tu"))
            txtSalaryLevelID.Focus()
            Return False
        End If
        If Number(cneSalaryCoefficient01.Value) = 0 Then
            D99C0008.MsgNotYetEnter(rl3("He_so_luong"))
            cneSalaryCoefficient01.Focus()
            Return False
        End If

        If L3Int(cneNumberYearTransfer.Value) <> 0 Then
            If Number(cneNumberYearTransfer.Value) > MaxTinyInt Then
                D99C0008.MsgL3(rl3("Thoi_gian_giu_bac_toi_thieu") & " " & rl3("phai_nho_hon") & " 255")
                cneNumberYearTransfer.Text = ""
                cneNumberYearTransfer.Focus()
                Return False
            End If
        End If

        '28/11/2013 ID 60495 - Kiem tra tại D13P5555
        If Not CheckStore(SQLStoreD13P5555(L3Int(IIf(_FormState = EnumFormState.FormAdd, 0, 1)))) Then
            Return False
        End If
        '        If Not CheckNumSalaryLevelID() Then Return False
        '
        '        Select Case _FormState
        '            Case EnumFormState.FormEdit, EnumFormState.FormAdd
        '                If L3Int(tdbg.Columns(COL_Grade).Text) <> L3Int(cneGrade.Value) Then
        '                    If IsDupplicateGrade() Then
        '                        cneGrade.Focus()
        '                        Return False
        '                    End If
        '                End If
        '        End Select
        '
        '        If _FormState = EnumFormState.FormAdd Then
        '            Dim sSQL As String = ""
        '            sSQL &= " Select OfficialTitleID, SalaryLevelID From D09T0215 " & vbCrLf
        '            sSQL &= " Where OfficialTitleID = " & SQLString(tdbcOfficialTitleID.Text) & vbCrLf
        '            sSQL &= " AND SalaryLevelID = " & SQLString(txtSalaryLevelID.Text)
        '            If ExistRecord(sSQL) Then
        '                D99C0008.MsgDuplicatePKey()
        '                txtSalaryLevelID.Focus()
        '                Return False
        '            End If
        '        End If

        bChangeRow = True
        Return True
    End Function

    '    Private Function CheckNumSalaryLevelID() As Boolean
    '        Dim sSQL2 As String = ""
    '        Dim sRet2 As String
    '
    '        sSQL2 &= "Select NumSalaryLevel From D09T0214 Where OfficialTitleID= " & SQLString(tdbcOfficialTitleID.Text)
    '        sRet2 = ReturnScalar(sSQL2)
    '        If L3Int(cneGrade.Value) > L3Int(sRet2) Then
    '            D99C0008.MsgL3(rl3("Da_vuot_qua_so_bac_toi_da_cho_phep_Khong_the_them"))
    '            cneSalaryCoefficient01.Focus()
    '            Return False
    '        End If
    '        Return True
    '    End Function

    '    Private Function IsDupplicateGrade() As Boolean
    '        Dim sSQL As String
    '        sSQL = "select top 1 1 from D09T0215 where Grade = " & SQLNumber(cneGrade.Value) & " and OfficialTitleID = " & SQLString(tdbcOfficialTitleID.Text)
    '        If ExistRecord(sSQL) Then
    '            D99C0008.MsgL3(rl3("Bac_luong_nay_da_ton_tai"))
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    End Function

    Dim bSave As Boolean = False
    Private Function Save(ByVal sender As System.Object) As Boolean
        'Chỉ thông báo hỏi khi nhấn nút Lưu. Còn khi du chuyển sang dòng khác thì không hỏi
        If bAskSave Then
            'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
            btnSave.Focus()
            If btnSave.Focused = False Then Return False
            '************************************
            If AskSave() = Windows.Forms.DialogResult.No Then Return False
        Else
            bAskSave = True
        End If
        If Not AllowSave() Then Return False
        Dim sSQL As String = ""

        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL &= SQLInsertD09T0215()
            Case EnumFormState.FormEdit
                sSQL &= SQLUpdateD09T0215() & vbCrLf
                sSQL &= SQLStoreD13P1051()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            bKeyPress = False
            bTemp = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    If tdbg.Visible Then ' gọi từ Danh mục
                        LoadTDBGrid(True, txtSalaryLevelID.Text)
                    End If


                    OfficialTitleID = tdbcOfficialTitleID.Text
                    SalaryLevelID = txtSalaryLevelID.Text
                    _maxGrade = L3Int(cneGrade.Value)

                    If sender IsNot Nothing Then btnNext.Text = rL3("Nhap__tiep")
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'Audit Log
                    Dim sDesc1 As String = txtSalaryLevelID.Text
                    Dim sDesc2 As String = tdbcOfficialTitleID.Text
                    Dim sDesc3 As String = cneSalaryCoefficient01.Value.ToString
                    Dim sDesc4 As String = SQLNumber(chkDisabled.Checked)
                    Dim sDesc5 As String = ""
                    RunAuditLog(AuditCodeSalaryGrades, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

                    LoadTDBGrid(, txtSalaryLevelID.Text)

                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If

        Return False
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' Save(sender)

        'Chỉ thông báo hỏi khi nhấn nút Lưu. Còn khi du chuyển sang dòng khác thì không hỏi
        If bAskSave Then
            'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
            btnSave.Focus()
            If btnSave.Focused = False Then Exit Sub
            '************************************
            If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Else
            bAskSave = True
        End If
        _bSaved = False

        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        _bSaved = False
        ' D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "False")
        btnSave.Enabled = False
        btnClose.Enabled = False

        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL &= SQLInsertD09T0215()
            Case EnumFormState.FormEdit
                sSQL &= SQLUpdateD09T0215() & vbCrLf
                sSQL &= SQLStoreD13P1051()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            bKeyPress = False
            bTemp = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBGrid(True, txtSalaryLevelID.Text)
                    _officialTitleID = tdbcOfficialTitleID.SelectedValue.ToString
                    If sender IsNot Nothing Then btnNext.Text = rL3("Nhap__tiep")
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'Audit Log
                    Dim sDesc1 As String = txtSalaryLevelID.Text
                    Dim sDesc2 As String = tdbcOfficialTitleIDF.Text
                    Dim sDesc3 As String = cneSalaryCoefficient01.Value.ToString
                    Dim sDesc4 As String = SQLNumber(chkDisabled.Checked)
                    Dim sDesc5 As String = ""
                    RunAuditLog(AuditCodeSalaryGrades, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

                    LoadTDBGrid(, txtSalaryLevelID.Text)

                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T0215
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 19/01/2007 04:34:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T0215() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T0215" & vbCrLf
        sSQL &= " Where OfficialTitleID= " & SQLString(tdbcOfficialTitleID.SelectedValue)
        sSQL &= "AND  SalaryLevelID = " & SQLString(tdbg.Columns(COL_SalaryLevelID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T0215
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 19/01/2007 03:13:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T0215() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D09T0215("
        sSQL &= "Grade, SalaryLevelID, OfficialTitleID, SalaryCoefficient, "
        sSQL &= "SalaryCoefficient02, SalaryCoefficient03, SalaryCoefficient04, SalaryCoefficient05, "
        sSQL &= "Disabled, NumberYearTransfer, Note, NoteU, "
        sSQL &= "CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, SalaryLevelName, SalaryLevelNameU "
        sSQL &= ") Values ("
        sSQL &= SQLNumber(cneGrade.Value) & COMMA 'Grade
        sSQL &= SQLString(txtSalaryLevelID.Text) & COMMA 'SalaryLevelID [KEY], varchar[20], NOT NULL
        sSQL &= SQLString(tdbcOfficialTitleID.Text) & COMMA 'OfficialTitleID [KEY], varchar[20], NOT NULL
        sSQL &= SQLMoney(cneSalaryCoefficient01.Value) & COMMA 'SalaryCoefficient, money, NULL
        sSQL &= SQLMoney(cneSalaryCoefficient02.Value) & COMMA 'SalaryCoefficient02, money, NOT NULL
        sSQL &= SQLMoney(cneSalaryCoefficient03.Value) & COMMA 'SalaryCoefficient03, money, NOT NULL
        sSQL &= SQLMoney(cneSalaryCoefficient04.Value) & COMMA 'SalaryCoefficient04, money, NOT NULL
        sSQL &= SQLMoney(cneSalaryCoefficient05.Value) & COMMA 'SalaryCoefficient05, money, NOT NULL
        sSQL &= SQLNumber(chkDisabled.Checked) & COMMA 'Disabled, bit, NOT NULL
        sSQL &= SQLNumber(cneNumberYearTransfer.Value) & COMMA
        sSQL &= SQLStringUnicode(txtNote, False) & COMMA 'Note, varchar[250], NOT NULL
        sSQL &= SQLStringUnicode(txtNote, True) & COMMA 'Note, varchar[250], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NOT NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA  'LastModifyDate, datetime, NULL
        sSQL &= SQLStringUnicode(txtSalaryLevelName, False) & COMMA 'SalaryLevelName, varchar[150], NOT NULL
        sSQL &= SQLStringUnicode(txtSalaryLevelName, True) 'SalaryLevelName, varchar[150], NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD09T0215
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 19/01/2007 03:16:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD09T0215() As String
        Dim sSQL As String = ""
        sSQL &= "Update D09T0215 Set "
        sSQL &= "Grade = " & SQLNumber(cneGrade.Value) & COMMA
        sSQL &= "SalaryCoefficient = " & SQLMoney(cneSalaryCoefficient01.Value) & COMMA 'money, NULL
        sSQL &= "SalaryCoefficient02 = " & SQLMoney(cneSalaryCoefficient02.Value) & COMMA 'money, NOT NULL
        sSQL &= "SalaryCoefficient03 = " & SQLMoney(cneSalaryCoefficient03.Value) & COMMA 'money, NOT NULL
        sSQL &= "SalaryCoefficient04 = " & SQLMoney(cneSalaryCoefficient04.Value) & COMMA 'money, NOT NULL
        sSQL &= "SalaryCoefficient05 = " & SQLMoney(cneSalaryCoefficient05.Value) & COMMA 'money, NOT NULL
        sSQL &= "Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA 'bit, NOT NULL
        sSQL &= "NumberYearTransfer = " & SQLNumber(cneNumberYearTransfer.Value) & COMMA
        sSQL &= "Note = " & SQLStringUnicode(txtNote, False) & COMMA 'varchar[250], NOT NULL
        sSQL &= "NoteU = " & SQLStringUnicode(txtNote, True) & COMMA 'varchar[250], NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" & COMMA 'datetime, NULL
        sSQL &= "SalaryLevelName = " & SQLStringUnicode(txtSalaryLevelName, False) & COMMA  'varchar[150], NOT NULL
        sSQL &= "SalaryLevelNameU = " & SQLStringUnicode(txtSalaryLevelName, True) 'varchar[150], NOT NULL
        sSQL &= " Where "
        sSQL &= "SalaryLevelID = " & SQLString(txtSalaryLevelID.Text) & " And " '[KEY], varchar[20], NOT NULL
        sSQL &= "OfficialTitleID = " & SQLString(ReturnValueC1Combo(tdbcOfficialTitleID)) '[KEY], varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1051
    '# Created User: DUCTRONG
    '# Created Date: 04/01/2010 03:51:48
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#--------------------------------------
    Private Function SQLStoreD13P1051() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1051 "
        sSQL &= SQLString(txtSalaryLevelID.Text) & COMMA 'SalaryLevelID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcOfficialTitleID)) 'OfficialTitleID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Hoàng Nhân
    '# Created Date: 19/11/2013 01:23:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra truoc khi xoa" & vbCrLf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcOfficialTitleID.Text) & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString(txtSalaryLevelID.Text) & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(cneGrade.Value) 'Num01ID, int, NOT NULL - Theo Mẫn truyền bậc lương
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P0214
    '# Created User: Hoàng Nhân
    '# Created Date: 10/12/2013 08:29:45
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P0214(ByVal iMode As Integer) As String
        Dim IsUseOfficialF As Integer = 0
        If chkIsUseOfficialF1.Checked And chkIsUseOfficialF2.Checked Then
            IsUseOfficialF = 0
        ElseIf chkIsUseOfficialF1.Checked Then
            IsUseOfficialF = 1
        ElseIf chkIsUseOfficialF2.Checked Then
            IsUseOfficialF = 2
        End If

        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi" & vbCrLf)
        sSQL &= "Exec D13P0214 "
        sSQL &= SQLString(tdbcOfficialTitleIDF.Text) & COMMA 'OfficialTitleID, varchar[50], NOT NULL
        sSQL &= SQLNumber(IsUseOfficialF) & COMMA 'IsUseOfficial, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage)  'Language, varchar[10], NOT NULL
        Return sSQL
    End Function


    Private Sub btn333_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Width += 200
    End Sub

    Private Sub btn2222_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Width -= 200
    End Sub
End Class