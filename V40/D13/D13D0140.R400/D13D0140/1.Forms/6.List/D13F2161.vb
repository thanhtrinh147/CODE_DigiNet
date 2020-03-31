Imports System
Public Class D13F2161
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_Code As Integer = 0            ' Giá trị
    Private Const COL_Description As Integer = 1     ' Diễn giải
    Private Const COL_DebitAccountID As Integer = 2  ' TK nợ
    Private Const COL_CreditAccountID As Integer = 3 ' TK có
    Private Const COL_DObjectTypeID As Integer = 4   ' Loại ĐT nợ
    Private Const COL_DObjectID As Integer = 5       ' ĐT nợ
    Private Const COL_CObjectTypeID As Integer = 6   ' Loại ĐT có
    Private Const COL_CObjectID As Integer = 7       ' ĐT có
    Private Const COL_PeriodID As Integer = 8        ' Tập phí
    Private Const COL_Ana01ID As Integer = 9         ' Khoản mục 01
    Private Const COL_Ana02ID As Integer = 10        ' Khoản mục 02
    Private Const COL_Ana03ID As Integer = 11        ' Khoản mục 03
    Private Const COL_Ana04ID As Integer = 12        ' Khoản mục 04
    Private Const COL_Ana05ID As Integer = 13        ' Khoản mục 05
    Private Const COL_Ana06ID As Integer = 14        ' Khoản mục 06
    Private Const COL_Ana07ID As Integer = 15        ' Khoản mục 07
    Private Const COL_Ana08ID As Integer = 16        ' Khoản mục 08
    Private Const COL_Ana09ID As Integer = 17        ' Khoản mục 09
    Private Const COL_Ana10ID As Integer = 18        ' Khoản mục 10
#End Region

    Private dt As DataTable
    Dim sType As String = ""

    Private _transferMethodID As String = ""
    Public Property TransferMethodID() As String 
        Get
            Return _transferMethodID
        End Get
        Set(ByVal Value As String )
            _transferMethodID = value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            LoadTDBCombo()
            LoadTDBGridAnalysisCaption("D13", tdbg, COL_Ana01ID, 1, True, gbUnicode)
            LoadTDBDropDown()
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    LoadEdit()
                    btnSave.Enabled = False
                Case EnumFormState.FormOther
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub D13F2161_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If dtDataD13P2161 IsNot Nothing Then
            dtDataD13P2161.Clear()
            dtDataD13P2161.Dispose()
        End If
    End Sub

    Private Sub D13F2161_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
    End Sub

    Private Sub D13F2161_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        'ResetColorGrid(tdbg)
        ResetFooterGrid(tdbg, 0, 1)
        tdbg_LockColumn()
        _bSaved = False
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtTransferMethodID)
        gbEnabledUseFind = False
        SetBackColorObligatory()
        ResetSplitDividerSize(tdbg)
        Loadlanguage()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub Loadlanguage()
    '    '================================================================ 
    '    Me.Text = rl3("Phuong_phap_chuyen_but_toan_-_D13F2161") & UnicodeCaption(gbUnicode) 'Ph§¥ng phÀp chuyÓn bòt toÀn - D13F2161
    '    '================================================================ 
    '    lblTransferMethodID.Text = rl3("Ma_phuong_phap") 'Mã phương pháp
    '    lblTransferMethodName.Text = rl3("Ten_phuong_phap") 'Tên phương pháp
    '    lblDataTypeID.Text = rl3("DataType") 'Loại dữ liệu
    '    '================================================================ 
    '    btnClose.Text = rl3("Do_ng") 'Đó&ng
    '    btnSave.Text = rl3("_Luu") '&Lưu
    '    btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Nhập &tiếp
    '    '================================================================ 
    '    chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
    '    '================================================================ 
    '    tdbdCreditAccountID.Columns("Code").Caption = rL3("Ma") 'Mã
    '    tdbdCreditAccountID.Columns("Name").Caption = rL3("Ten") 'Tên
    '    tdbdDebitAccountID.Columns("Code").Caption = rL3("Ma") 'Mã
    '    tdbdDebitAccountID.Columns("Name").Caption = rL3("Ten") 'Tên
    '    tdbdCObjectID.Columns("Code").Caption = rL3("Ma") 'Mã
    '    tdbdCObjectID.Columns("Name").Caption = rL3("Ten") 'Diễn giải
    '    tdbdCObjectTypeID.Columns("Code").Caption = rL3("Ma") 'Mã
    '    tdbdCObjectTypeID.Columns("Name").Caption = rL3("Ten") 'Diễn giải
    '    tdbdDObjectID.Columns("Code").Caption = rL3("Ma") 'Mã
    '    tdbdDObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Diễn giải
    '    tdbdDObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
    '    tdbdDObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Ten") 'Diễn giải
    '    tdbdAna01ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdAna01ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdAna02ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdAna02ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdAna03ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdAna03ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdAna04ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdAna04ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdAna05ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdAna05ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdAna06ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdAna06ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdAna07ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdAna07ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdAna08ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdAna08ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdAna09ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdAna09ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdAna10ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdAna10ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    '================================================================ 
    '    tdbg.Columns("Code").Caption = rl3("Gia_tri_") 'Giá trị
    '    tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbg.Columns("DebitAccountID").Caption = rl3("TK_no") 'TK nợ
    '    tdbg.Columns("CreditAccountID").Caption = rl3("TK_co") 'TK có
    '    tdbg.Columns("DObjectTypeID").Caption = rl3("Loai_DT_no") 'Loại ĐT nợ
    '    tdbg.Columns("DObjectID").Caption = rl3("DT_no") 'ĐT nợ
    '    tdbg.Columns("CObjectTypeID").Caption = rl3("Loai_DT_co") 'Loại ĐT có
    '    tdbg.Columns("CObjectID").Caption = rl3("DT_co") 'ĐT có
    '    tdbg.Columns("PeriodID").Caption = rl3("Tap_phi") 'Tập phí
    'End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Phuong_phap_chuyen_but_toan_-_D13F2161") & UnicodeCaption(gbUnicode) 'Ph§¥ng phÀp chuyÓn bòt toÀn - D13F2161
        '================================================================ 
        lblTransferMethodID.Text = rl3("Ma_phuong_phap") 'Mã phương pháp
        lblTransferMethodName.Text = rl3("Ten_phuong_phap") 'Tên phương pháp
        lblDataTypeID.Text = rl3("DataType") 'Loại dữ liệu
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu và Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        tdbcDataTypeID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbcDataTypeID.Columns("Name").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdCreditAccountID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdCreditAccountID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdCreditAccountID.Columns("GroupID").Caption = rl3("Nhom") 'Nhóm
        tdbdDebitAccountID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdDebitAccountID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdDebitAccountID.Columns("GroupID").Caption = rl3("Nhom") 'Nhóm
        tdbdCObjectID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdCObjectID.Columns("Name").Caption = rl3("Ten") 'Tên

        tdbdCObjectTypeID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdCObjectTypeID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdDObjectID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdDObjectID.Columns("Name").Caption = rl3("Ten") 'Tên

        tdbdDObjectTypeID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdDObjectTypeID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdAna01ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna01ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna02ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna02ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna03ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna03ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna04ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna04ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna05ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna05ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna06ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna06ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna07ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna07ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna08ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna08ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna09ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna09ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna10ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna10ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdPeriodID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdPeriodID.Columns("Name").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_Code).Caption = rl3("Gia_tri_") 'Giá trị
        tdbg.Columns(COL_Description).Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_DebitAccountID).Caption = rl3("TK_no") 'TK nợ
        tdbg.Columns(COL_CreditAccountID).Caption = rl3("TK_co") 'TK có
        tdbg.Columns(COL_DObjectTypeID).Caption = rl3("Loai_DT_no") 'Loại ĐT nợ
        tdbg.Columns(COL_DObjectID).Caption = rl3("DT_no") 'ĐT nợ
        tdbg.Columns(COL_CObjectTypeID).Caption = rl3("Loai_DT_co") 'Loại ĐT có
        tdbg.Columns(COL_CObjectID).Caption = rl3("DT_co") 'ĐT có
        tdbg.Columns(COL_PeriodID).Caption = rl3("Tap_phi") 'Tập phí
        tdbg.Columns(COL_Ana01ID).Caption = rl3("Khoan_muc") & " 01" 'Khoản mục 01
        tdbg.Columns(COL_Ana02ID).Caption = rl3("Khoan_muc") & " 02" 'Khoản mục 02
        tdbg.Columns(COL_Ana03ID).Caption = rl3("Khoan_muc") & " 03" 'Khoản mục 03
        tdbg.Columns(COL_Ana04ID).Caption = rl3("Khoan_muc") & " 04" 'Khoản mục 04
        tdbg.Columns(COL_Ana05ID).Caption = rl3("Khoan_muc") & " 05" 'Khoản mục 05
        tdbg.Columns(COL_Ana06ID).Caption = rl3("Khoan_muc") & " 06" 'Khoản mục 06
        tdbg.Columns(COL_Ana07ID).Caption = rl3("Khoan_muc") & " 07" 'Khoản mục 07
        tdbg.Columns(COL_Ana08ID).Caption = rl3("Khoan_muc") & " 08" 'Khoản mục 08
        tdbg.Columns(COL_Ana09ID).Caption = rl3("Khoan_muc") & " 09" 'Khoản mục 09
        tdbg.Columns(COL_Ana10ID).Caption = rl3("Khoan_muc") & " 10" 'Khoản mục 10
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private dtDataD13P2161 As DataTable


    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P2161()
        '14/04/2015 Thay thế đổ nguồn cho 1 số Combo và Dropdown.
        dtDataD13P2161 = ReturnDataTable(sSQL)


        'Load tdbcDataTypeID
        'Update 09/12/2011: Incident 45140
        'sSQL = "Select DataTypeID, DataTypeName" & UnicodeJoin(gbUnicode) & " as DataTypeName From D13V2060 where Language = " & SQLString(gsLanguage) & " order by DataTypeID"
        'sSQL = "Select DataTypeID, DataTypeName" & UnicodeJoin(gbUnicode) & " as DataTypeName From D13V2060 where Language = " & SQLString(gsLanguage) & " order by OrderNo"
        'Dim dt As DataTable = ReturnDataTable(sSQL)
        'For Each row As DataRow In dt.Rows
        '    'Update 16/07/2013: Nếu có thay đổi tên resource
        '    If giReplacResource <> 0 Then
        '        row("DataTypeName") = ReplaceResourceCustom(row("DataTypeName").ToString)
        '    End If
        'Next
        'Thay đổi đổ nguồn theo ID: 70014
        LoadDataSource(tdbcDataTypeID, ReturnTableFilter(dtDataD13P2161, "SourceName = 'DataType'", True), gbUnicode)
    End Sub

    Private Sub LoadEdit()
        'btnNext.Visible = False
        'btnSave.Left = btnNext.Right - btnSave.Width
        Dim sSQL As String = "Select TransferMethodID, TransferMethodName" & UnicodeJoin(gbUnicode) & " as TransferMethodName, DataTypeID, Disabled from D13T1160  WITH (NOLOCK) where TransferMethodID = " & SQLString(_transferMethodID)
        Dim dtMaster As DataTable = ReturnDataTable(sSQL)
        If dtMaster.Rows.Count > 0 Then
            txtTransferMethodID.Text = dtMaster.Rows(0).Item("TransferMethodID").ToString
            txtTransferMethodName.Text = dtMaster.Rows(0).Item("TransferMethodName").ToString
            tdbcDataTypeID.SelectedValue = dtMaster.Rows(0).Item("DataTypeID").ToString
            chkDisabled.Checked = L3Bool(dtMaster.Rows(0).Item("Disabled").ToString)
            sType = dtMaster.Rows(0).Item("DataTypeID").ToString
        End If
        'ID 76488 27/07/2015
        If _FormState = EnumFormState.FormOther Then
            LoadTDBGrid(2)
        Else
            LoadTDBGrid(1)
            btnNext.Visible = False
            btnSave.Left = btnNext.Right - btnSave.Width
            ReadOnlyControl(txtTransferMethodID)
            ReadOnlyControl(tdbcDataTypeID)
        End If
    End Sub

    Dim dtObjectID As DataTable
    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        ' Tài khoản
        'Load tdbdDebitAccountID
        Dim dtAccountID As DataTable = ReturnTableFilter(dtDataD13P2161, "SourceName = 'Account'", True)
        LoadDataSource(tdbdDebitAccountID, dtAccountID, gbUnicode)
        LoadDataSource(tdbdCreditAccountID, dtAccountID.Copy, gbUnicode)

        'Load tdbdObjectID
        'sSQL = "Select ObjectID, ObjectName" & UnicodeJoin(gbUnicode) & " as ObjectName, ObjectTypeID From Object WITH (NOLOCK) " & vbCrLf
        'sSQL &= "	Where	Disabled = 0 " 'and ObjectTypeID = @ObjectTypeID"
        'sSQL &= " And (DAG = '' or DAG In ( Select  DAGroupID From LemonSys.Dbo.D00V0080   Where UserID = '" & gsUserID & "') Or " & SQLString(gsUserID) & "= 'LEMONADMIN')" & vbCrLf
        'sSQL &= " Order by	ObjectID"
        dtObjectID = ReturnTableFilter(dtDataD13P2161, "SourceName = 'Object'", True)

        'Load tdbdDObjectTypeID
        Dim dtObjectTypeID As DataTable = ReturnTableFilter(dtDataD13P2161, "SourceName = 'ObjectType'", True)
        LoadDataSource(tdbdDObjectTypeID, dtObjectTypeID, gbUnicode)
        LoadDataSource(tdbdCObjectTypeID, dtObjectTypeID.Copy, gbUnicode)

        LoadtdbdDObjectID("-1")
        LoadtdbdCObjectID("-1")

        'Load tdbdPeriodID
        'sSQL = "Select A.PeriodID as PeriodID, ISNULL(A.WorkOrderNo, '') as WorkOrderNo, Note" & UnicodeJoin(gbUnicode) & " as Note " & vbCrLf
        ''Update 15/03/2012: Incident 47313
        'sSQL &= " FROM 	D08N0100 (" & SQLString(gsDivisionID) & " , " & giTranMonth & " , " & giTranYear & ", 2) A  " & vbCrLf
        ''sSQL &= " FROM 	D08N0100 (" & SQLString(gsDivisionID) & " , " & giTranMonth & " , " & giTranYear & ", 0) A  " & vbCrLf
        ''sSQL &= " WHERE 	A.DAGroupID='' OR A.DAGroupID IN (	SELECT    DAGroupID FROM LemonSys.dbo.D00V0080"
        ''sSQL &= " WHERE 	UserID = " & SQLString(gsUserID) & ") OR " & SQLString(gsUserID) & " = 'LEMONADMIN'" & vbCrLf
        'sSQL &= " ORDER BY 	PeriodID"
        LoadDataSource(tdbdPeriodID, ReturnTableFilter(dtDataD13P2161, "SourceName = 'Period'", True), gbUnicode)

        Load10TDBDropDownAna()
    End Sub

    Private Sub LoadtdbdDObjectID(ByVal ID As String)
        'If ID = "%" Then
        '    LoadDataSource(tdbdDObjectID, dtObjectID, gbUnicode)
        'Else
        LoadDataSource(tdbdDObjectID, ReturnTableFilter(dtObjectID, " ParentID = " & SQLString(ID)), gbUnicode)
        'End If
    End Sub

    Private Sub LoadtdbdCObjectID(ByVal ID As String)
        LoadDataSource(tdbdCObjectID, ReturnTableFilter(dtObjectID, " ParentID = " & SQLString(ID)), gbUnicode)
    End Sub

    Private Sub Load10TDBDropDownAna()
        'LoadTDBDropDownAna(tdbdAna01ID, tdbdAna02ID, tdbdAna03ID, tdbdAna04ID, tdbdAna05ID, tdbdAna06ID, tdbdAna07ID, tdbdAna08ID, tdbdAna09ID, tdbdAna10ID, tdbg, COL_Ana01ID, gbUnicode, , ReturnTableFilter(dtDataD13P2161, "SourceName = 'Ana'", True))
        Dim dtAnaAll As DataTable = ReturnTableFilter(dtDataD13P2161, "SourceName = 'Ana'", True)
        If dtAnaAll.Columns.Contains("AnaID") = False Then dtAnaAll.Columns.Add("AnaID", Type.GetType("System.String"), "Code")
        If dtAnaAll.Columns.Contains("AnaName") = False Then dtAnaAll.Columns.Add("AnaName", Type.GetType("System.String"), "Name")
        For i As Integer = 0 To 9
            If L3Bool(tdbg.Columns(COL_Ana01ID + i).Tag) = False Then Continue For
            Dim dtAna As DataTable = ReturnTableFilter(dtAnaAll, "ParentID = 'K" & (i + 1).ToString("00") & "'", True)
            LoadDataSource(tdbg.Columns(COL_Ana01ID + i).DropDown, dtAna, gbUnicode)
        Next

    End Sub

    Private Sub LoadTDBGrid(ByVal iMode As Integer, Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim sSQL As String
        sSQL = SQLStoreD13P2160(iMode)
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt, gbUnicode)
        FooterTotalGrid(tdbg, COL_Code)
    End Sub

    Private Sub SetBackColorObligatory()
        txtTransferMethodID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtTransferMethodName.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDataTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_PeriodID
                If tdbg.Columns(COL_PeriodID).Text <> tdbdPeriodID.Columns("Code").Text Then
                    tdbg.Columns(COL_PeriodID).Text = ""
                End If

            Case COL_Ana01ID
                If tdbg.Columns(COL_Ana01ID).Text <> tdbdAna01ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(0) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana01ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana01ID).Text.Length > giArrAnaLength(0) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana01ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana02ID
                If tdbg.Columns(COL_Ana02ID).Text <> tdbdAna02ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(1) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana02ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana02ID).Text.Length > giArrAnaLength(1) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana02ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana03ID
                If tdbg.Columns(COL_Ana03ID).Text <> tdbdAna03ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(2) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana03ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana03ID).Text.Length > giArrAnaLength(2) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana03ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana04ID
                If tdbg.Columns(COL_Ana04ID).Text <> tdbdAna04ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(3) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana04ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana04ID).Text.Length > giArrAnaLength(3) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana04ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana05ID
                If tdbg.Columns(COL_Ana05ID).Text <> tdbdAna05ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(4) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_Ana05ID).Text = ""
                    Else
                        If tdbg.Columns(COL_Ana05ID).Text.Length > giArrAnaLength(4) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_Ana05ID).Text = ""
                        End If
                    End If
                End If
            Case COL_Ana06ID
                If tdbg.Columns(COL_Ana06ID).Text <> tdbdAna06ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana06ID).Text = ""
                End If
            Case COL_Ana07ID
                If tdbg.Columns(COL_Ana07ID).Text <> tdbdAna07ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana07ID).Text = ""
                End If
            Case COL_Ana08ID
                If tdbg.Columns(COL_Ana08ID).Text <> tdbdAna08ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana08ID).Text = ""
                End If
            Case COL_Ana09ID
                If tdbg.Columns(COL_Ana09ID).Text <> tdbdAna09ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana09ID).Text = ""
                End If
            Case COL_Ana10ID
                If tdbg.Columns(COL_Ana10ID).Text <> tdbdAna10ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_Ana10ID).Text = ""
                End If
            Case COL_DObjectTypeID
                If tdbg.Columns(COL_DObjectTypeID).Text <> tdbdDObjectTypeID.Columns("Code").Text Then
                    tdbg.Columns(COL_DObjectTypeID).Text = ""
                End If
            Case COL_CObjectTypeID
                If tdbg.Columns(COL_CObjectTypeID).Text <> tdbdCObjectTypeID.Columns("Code").Text Then
                    tdbg.Columns(COL_CObjectTypeID).Text = ""
                End If
            Case COL_DObjectID
                If tdbg.Columns(COL_DObjectID).Text <> tdbdDObjectID.Columns("Code").Text Then
                    tdbg.Columns(COL_DObjectID).Text = ""
                End If

            Case COL_DebitAccountID
                If tdbg.Columns(COL_DebitAccountID).Text <> tdbdDebitAccountID.Columns("Code").Text Then
                    tdbg.Columns(COL_DebitAccountID).Text = ""
                End If
            Case COL_CreditAccountID
                If tdbg.Columns(COL_CreditAccountID).Text <> tdbdCreditAccountID.Columns(0).Text Then
                    tdbg.Columns(COL_CreditAccountID).Text = ""
                End If
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2160
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 10/11/2010 02:20:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load lưới
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2160(ByVal iMode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2160 "
        sSQL &= SQLString(txtTransferMethodID.Text) & COMMA 'TransferMethodID, varchar[50], NOT NULL
        sSQL &= SQLString(tdbcDataTypeID.SelectedValue) & COMMA 'DataTypeID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsDivisionID)
        Return sSQL
    End Function

#Region "Events tdbcDataTypeID"

    Private Sub tdbcDataTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDataTypeID.LostFocus
        If tdbcDataTypeID.FindStringExact(tdbcDataTypeID.Text) = -1 Then tdbcDataTypeID.Text = ""
        tdbg.Focus()
        If _FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormOther Then
            If tdbg.RowCount <= 0 Then
                sType = ComboValue(tdbcDataTypeID)
                LoadTDBGrid(0)
            Else
                Dim dlg As DialogResult = D99C0008.Msg(rL3("Du_lieu_tren_luoi_se_bi_xoa_Ban_co_muon_thuc_hien_ko"), MsgAnnouncement, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question)
                If dlg = Windows.Forms.DialogResult.Yes Then
                    sType = tdbcDataTypeID.SelectedValue.ToString
                    LoadTDBGrid(0)
                Else
                    tdbcDataTypeID.SelectedValue = sType
                End If
            End If
        End If
    End Sub

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tdbcDataTypeID.BeforeOpen
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDataTypeID.Close
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDataTypeID.KeyUp
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDataTypeID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1160
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 10/11/2010 02:25:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1160() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D13T1160(")
        sSQL.Append("TransferMethodID, TransferMethodName, TransferMethodNameU, Disabled, CreateDate, ")
        sSQL.Append("CreateUserID, LastModifyDate, LastModifyUserID, DataTypeID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtTransferMethodID.Text) & COMMA) 'TransferMethodID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransferMethodName.Text, gbUnicode, False) & COMMA) 'TransferMethodName, varchar[500], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransferMethodName.Text, gbUnicode, True) & COMMA) 'TransferMethodNameU, nvarchar, NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcDataTypeID.SelectedValue)) 'DataTypeID, varchar[50], NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1161s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 10/11/2010 02:28:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1161s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D13T1161(")
            sSQL.Append("TransferMethodID, Code, DebitAccountID, CreditAccountID, DObjectTypeID, ")
            sSQL.Append("DObjectID, CObjectTypeId, CObjectID, Ana01ID, Ana02ID, ")
            sSQL.Append("Ana03ID, Ana04ID, Ana05ID, Ana06ID, Ana07ID, ")
            sSQL.Append("Ana08ID, Ana09ID, Ana10ID, PeriodID ")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtTransferMethodID.Text) & COMMA) 'TransferMethodID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Code)) & COMMA) 'Code, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DebitAccountID)) & COMMA) 'DebitAccountID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CreditAccountID)) & COMMA) 'CreditAccountID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DObjectTypeID)) & COMMA) 'DObjecTypeID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DObjectID)) & COMMA) 'DObjectID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CObjectTypeID)) & COMMA) 'CObjectTypeId, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CObjectID)) & COMMA) 'CObjectID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana01ID)) & COMMA) 'Ana01ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana02ID)) & COMMA) 'Ana02ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana03ID)) & COMMA) 'Ana03ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana04ID)) & COMMA) 'Ana04ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana05ID)) & COMMA) 'Ana05ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana06ID)) & COMMA) 'Ana06ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana07ID)) & COMMA) 'Ana07ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana08ID)) & COMMA) 'Ana08ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana09ID)) & COMMA) 'Ana09ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ana10ID)) & COMMA) 'Ana10ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PeriodID))) 'PeriodID, varchar[50], NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1160
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 10/11/2010 02:40:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1160() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T1160 Set ")
        sSQL.Append("TransferMethodName = " & SQLStringUnicode(txtTransferMethodName.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("TransferMethodNameU = " & SQLStringUnicode(txtTransferMethodName.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID)) 'varchar[20], NOT NULL
        sSQL.Append(" Where TransferMethodID = " & SQLString(txtTransferMethodID.Text) & vbCrLf)
        sSQL.Append("DELETE D13T1161 WHERE TransferMethodID = " & SQLString(txtTransferMethodID.Text))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2161
    '# Created User: Lê Anh Vũ
    '# Created Date: 14/04/2015 09:13:44
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2161() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon chung cho 1 so dropdown" & vbCrlf)
        sSQL &= "Exec D13P2161 "
        sSQL &= SQLString(gsCompanyID) & COMMA 'CompanyID, varchar[50], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA  'TranYear, int, NOT NULL
        sSQL &= SQLNumber(0)
        Return sSQL
    End Function

    Private Function AllowSave() As Boolean
        If txtTransferMethodID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ma_phuong_phap"))
            txtTransferMethodID.Focus()
            Return False
        End If
        If txtTransferMethodName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ten_phuong_phap"))
            txtTransferMethodName.Focus()
            Return False
        End If
        If tdbcDataTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("DataType"))
            tdbcDataTypeID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormOther Then
            If IsExistKey("D13T1160", "TransferMethodID", txtTransferMethodID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtTransferMethodID.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD13T1160().ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T1161s())
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T1160().ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T1161s())
            Case EnumFormState.FormOther
                sSQL.Append(SQLInsertD13T1160().ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T1161s())
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            SaveOK()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    TransferMethodID = txtTransferMethodID.Text
                    If sender IsNot Nothing Then btnNext.Text = rL3("_Nhap_tiep")
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
                Case EnumFormState.FormOther
                    TransferMethodID = txtTransferMethodID.Text
                    If sender IsNot Nothing Then btnNext.Text = rL3("_Nhap_tiep")
                    btnNext.Focus()
            End Select
            btnClose.Enabled = True
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_DObjectTypeID
                tdbg.Columns(COL_DObjectID).Text = ""
            Case COL_CObjectTypeID
                tdbg.Columns(COL_CObjectID).Text = ""
        End Select
        tdbg.UpdateData()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If btnNext.Text = rl3("Luu_va_Nhap__tiep") Then btnSave_Click(Nothing, Nothing)
        If _bSaved = False Then Exit Sub 'luu k thanh cong
        btnSave.Enabled = True
        btnNext.Text = rl3("Luu_va_Nhap__tiep")
        If D13Options.SaveLastRecent Then
            txtTransferMethodID.Text = ""
            txtTransferMethodID.Focus()
        Else
            txtTransferMethodID.Text = ""
            txtTransferMethodName.Text = ""
            tdbcDataTypeID.Text = ""
            LoadTDBGrid(1)
            txtTransferMethodID.Focus()
        End If
    End Sub

    Dim iColD() As Integer = {COL_DObjectTypeID, COL_DObjectID}
    Dim iColC() As Integer = {COL_CObjectTypeID, COL_CObjectID}
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_Description, COL_Code
                Exit Sub
            Case COL_DObjectTypeID, COL_DObjectID
                CopyColumnArr(tdbg, e.ColIndex, iColD)
            Case COL_CObjectTypeID, COL_CObjectID
                CopyColumnArr(tdbg, e.ColIndex, iColC)
            Case Else
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Text, tdbg.Row)
        End Select
    End Sub

    Private Sub tdbg_LockColumn()
        With tdbg.Splits(SPLIT0)
            .DisplayColumns(COL_Code).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            .DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End With
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Select Case tdbg.Col
                    Case COL_Ana10ID
                        HotKeyEnterGrid(tdbg, COL_DebitAccountID, e, SPLIT0)
                End Select
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_DObjectID
                LoadtdbdDObjectID(tdbg.Columns(COL_DObjectTypeID).Text)
            Case COL_CObjectID
                LoadtdbdCObjectID(tdbg.Columns(COL_CObjectTypeID).Text)
        End Select
    End Sub
End Class