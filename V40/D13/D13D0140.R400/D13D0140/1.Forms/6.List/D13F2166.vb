Imports System
Public Class D13F2166
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property



#Region "Const of tdbg"
    Private Const COL_OrderNum As Integer = 0         ' STT
    Private Const COL_PayCalID As Integer = 1         ' Khoản thu nhập
    Private Const COL_Description As Integer = 2      ' Diễn giải
    Private Const COL_TransferMethodID As Integer = 3 ' PP chuyển bút toán
    Private Const COL_DetailID As Integer = 4         ' DetailID
    Private Const COL_DebitAccountID As Integer = 5   ' TK nợ
    Private Const COL_CreditAccountID As Integer = 6  ' TK có
    Private Const COL_DObjectTypeID As Integer = 7    ' Loại ĐT nợ 1
    Private Const COL_DObjectID As Integer = 8        ' ĐT nợ 1
    Private Const COL_CObjectTypeID As Integer = 9    ' Loại ĐT có 1
    Private Const COL_CObjectID As Integer = 10       ' ĐT có 1
    Private Const COL_PeriodID As Integer = 11        ' Tập phí
    Private Const COL_Ana01ID As Integer = 12         ' Khoản mục 01 ana
    Private Const COL_Ana02ID As Integer = 13         ' Khoản mục 02  ana
    Private Const COL_Ana03ID As Integer = 14         ' Khoản mục 03  ana
    Private Const COL_Ana04ID As Integer = 15         ' Khoản mục 04  ana
    Private Const COL_Ana05ID As Integer = 16         ' Khoản mục 05  ana
    Private Const COL_Ana06ID As Integer = 17         ' Khoản mục 06 ana
    Private Const COL_Ana07ID As Integer = 18         ' Khoản mục 07 ana
    Private Const COL_Ana08ID As Integer = 19         ' Khoản mục 08 ana
    Private Const COL_Ana09ID As Integer = 20         ' Khoản mục 09 ana
    Private Const COL_Ana10ID As Integer = 21         ' Khoản mục 10 ana
    Private Const COL_M_DObjectTypeID As Integer = 22 ' Loại ĐT nợ
    Private Const COL_M_DObjectID As Integer = 23     ' ĐT nợ
    Private Const COL_M_CObjectTypeID As Integer = 24 ' Loại DT có
    Private Const COL_M_CObjectID As Integer = 25     ' ĐT có
    Private Const COL_M_Ana01ID As Integer = 26       ' Khoản mục 01
    Private Const COL_M_Ana02ID As Integer = 27       ' Khoản mục 02
    Private Const COL_M_Ana03ID As Integer = 28       ' Khoản mục 03
    Private Const COL_M_Ana04ID As Integer = 29       ' Khoản mục 04
    Private Const COL_M_Ana05ID As Integer = 30       ' Khoản mục 05
    Private Const COL_M_Ana06ID As Integer = 31       ' Khoản mục 06
    Private Const COL_M_Ana07ID As Integer = 32       ' Khoản mục 07
    Private Const COL_M_Ana08ID As Integer = 33       ' Khoản mục 08
    Private Const COL_M_Ana09ID As Integer = 34       ' Khoản mục 09
    Private Const COL_M_Ana10ID As Integer = 35       ' Khoản mục 10
#End Region


    Private dt As DataTable

    Private _policyID As String = ""
    Public Property PolicyID() As String
        Get
            Return _policyID
        End Get
        Set(ByVal Value As String)
            _policyID = value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
    Private _FormState As EnumFormState
    Private dtDataD13P2161_Mode_1 As DataTable
    Private dtDataD13P2161_Mode_0 As DataTable

    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
            bLoadFormState = True
            LoadInfoGeneral()
            _FormState = value

            bUseAna = LoadTDBGridAnalysisCaption("D13", tdbg, COL_Ana01ID, 1, True, gbUnicode)
            LoadTDBGridAnalysisCaption("D13", tdbg, COL_M_Ana01ID, 1, True, gbUnicode)
            LoadTDBDropDown()
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    LoadEdit()
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private Sub D13F2161_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub


    Private Sub D13F2161_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.WaitCursor
        'ResetColorGrid(tdbg)
        _bSaved = False
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtPolicyID)
        gbEnabledUseFind = False
        SetBackColorObligatory()
        ResetSplitDividerSize(tdbg)
        Loadlanguage()
        LoadTDBGrid()
        tdbg_LockColumn()

        tdbg.Splits(SPLIT0).DisplayColumns(COL_PayCalID).AutoComplete = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PayCalID).AutoDropDown = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TransferMethodID).AutoComplete = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TransferMethodID).AutoDropDown = True

        ClickButton(Button.SalaryCoefficientBase)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub Loadlanguage()
    '    '================================================================ 
    '    Me.Text = rl3("Thiet_lap_co_che_chuyen_but_toan_-_D13F2166") & UnicodeCaption(gbUnicode) 'ThiÕt lËp c¥ chÕ chuyÓn bòt toÀn - D13F2166
    '    '================================================================ 
    '    lblPolicyID.Text = rl3("Ma") 'Mã
    '    lblPolicyName.Text = rl3("Ten") 'Tên
    '    '================================================================ 
    '    btnAccObject.Text = "&1. " & rl3("Tai_khoan") & " - " & rl3("Doi_tuong") 'Tài khoản
    '    btnAna.Text = "&2. " & rl3("Tap_phi") & " - " & rl3("Khoan_muc") '"Tập phí - Khoản mục"
    '    btnLink.Text = "&3. " & rl3("Lien_ket") 'Liên kết
    '    btnClose.Text = rl3("Do_ng") 'Đó&ng
    '    btnSave.Text = rl3("_Luu") '&Lưu
    '    btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Nhập &tiếp
    '    '================================================================ 
    '    chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
    '    '================================================================
    '    tdbdPayCalID.Columns("PayCalID").Caption = rl3("Ma") 'Mã
    '    tdbdPayCalID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbdTransferMethodID.Columns("TransferMethodID").Caption = rl3("Ma") 'Mã
    '    tdbdTransferMethodID.Columns("TransferMethodName").Caption = rl3("Ten") 'Tên
    '    tdbdCObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
    '    tdbdCObjectID.Columns("ObjectName").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbdCObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
    '    tdbdCObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbdDObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
    '    tdbdDObjectID.Columns("ObjectName").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbdDObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
    '    tdbdDObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbdCreditAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
    '    tdbdCreditAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
    '    tdbdDebitAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
    '    tdbdDebitAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
    '    tdbdM_CObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
    '    tdbdM_CObjectID.Columns("ObjectName").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbdM_CObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
    '    tdbdM_CObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbdM_DObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
    '    tdbdM_DObjectID.Columns("ObjectName").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbdM_DObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
    '    tdbdM_DObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
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
    '    tdbdM_Ana10ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdM_Ana10ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdM_Ana09ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdM_Ana09ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdM_Ana08ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdM_Ana08ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdM_Ana07ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdM_Ana07ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdM_Ana06ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdM_Ana06ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdM_Ana05ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdM_Ana05ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdM_Ana04ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdM_Ana04ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdM_Ana03ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdM_Ana03ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdM_Ana02ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdM_Ana02ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    tdbdM_Ana01ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
    '    tdbdM_Ana01ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
    '    '================================================================ 
    '    tdbg.Columns("OrderNum").Caption = rl3("STT") 'STT
    '    tdbg.Columns("PayCalID").Caption = rl3("Khoan_thu_nhap") 'Khoản thu nhập
    '    tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
    '    tdbg.Columns("TransferMethodID").Caption = rl3("PP_chuyen_but_toan") 'PP chuyển bút toán
    '    tdbg.Columns("DebitAccountID").Caption = rl3("TK_no") 'TK nợ
    '    tdbg.Columns("CreditAccountID").Caption = rl3("TK_co") 'TK có
    '    tdbg.Columns("DObjectTypeID").Caption = rl3("Loai_DT_no") 'Loại ĐT nợ 1
    '    tdbg.Columns("DObjectID").Caption = rl3("DT_no") 'ĐT nợ 1
    '    tdbg.Columns("CObjectTypeID").Caption = rl3("Loai_DT_co") 'Loại ĐT có 1
    '    tdbg.Columns("CObjectID").Caption = rl3("DT_co") 'ĐT có 1
    '    tdbg.Columns("M_DObjectTypeID").Caption = rl3("Loai_DT_no") 'Loại ĐT nợ
    '    tdbg.Columns("M_DObjectID").Caption = rl3("DT_no") 'ĐT nợ
    '    tdbg.Columns("M_CObjectTypeID").Caption = rl3("Loai_DT_co") '
    '    tdbg.Columns("M_CObjectID").Caption = rl3("DT_co") 'ĐT có
    '    tdbg.Columns("PeriodID").Caption = rl3("Tap_phi")
    'End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Thiet_lap_co_che_chuyen_but_toan_-_D13F2166") & UnicodeCaption(gbUnicode) 'ThiÕt lËp c¥ chÕ chuyÓn bòt toÀn - D13F2166
        '================================================================ 
        lblPolicyID.Text = rl3("Ma") 'Mã
        lblPolicyName.Text = rl3("Ten") 'Tên
        '================================================================ 
        btnAccObject.Text = "&1. " & rL3("Tai_khoan") & " - " & rL3("Doi_tuong") 'Tài khoản
        btnAna.Text = "&2. " & rL3("Tap_phi") & " - " & rL3("Khoan_muc") '"Tập phí - Khoản mục"
        btnLink.Text = "&3. " & rL3("Lien_ket") 'Liên kết
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Lưu và Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        chkIsSliptVouchers.Text = rL3("Tach_phieu_theo_khoan_thu_nhap") 'Tách phiếu theo khoản thu nhập
        '================================================================ 
        tdbdPayCalID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdPayCalID.Columns("Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdTransferMethodID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdTransferMethodID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdCObjectID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdCObjectID.Columns("Code").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdCObjectTypeID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdCObjectTypeID.Columns("Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdDObjectID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdDObjectID.Columns("Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdDObjectTypeID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdDObjectTypeID.Columns("Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdCreditAccountID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdCreditAccountID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdDebitAccountID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdDebitAccountID.Columns("Name").Caption = rl3("Ten") 'Tên
        tdbdM_CObjectID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdM_CObjectID.Columns("Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdM_CObjectTypeID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdM_CObjectTypeID.Columns("Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdM_DObjectID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdM_DObjectID.Columns("Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdM_DObjectTypeID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdM_DObjectTypeID.Columns("Name").Caption = rl3("Dien_giai") 'Diễn giải
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
        tdbdM_Ana10ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdM_Ana10ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdM_Ana09ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdM_Ana09ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdM_Ana08ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdM_Ana08ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdM_Ana07ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdM_Ana07ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdM_Ana06ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdM_Ana06ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdM_Ana05ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdM_Ana05ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdM_Ana04ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdM_Ana04ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdM_Ana03ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdM_Ana03ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdM_Ana02ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdM_Ana02ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdM_Ana01ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdM_Ana01ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdPeriodID.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbdPeriodID.Columns("Name").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg.Columns("OrderNum").Caption = rL3("STT") 'STT
        tdbg.Columns("PayCalID").Caption = rL3("Khoan_thu_nhap") 'Khoản thu nhập
        tdbg.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns("TransferMethodID").Caption = rL3("PP_chuyen_but_toan") 'PP chuyển bút toán
        tdbg.Columns("DebitAccountID").Caption = rL3("TK_no") 'TK nợ
        tdbg.Columns("CreditAccountID").Caption = rL3("TK_co") 'TK có
        tdbg.Columns("DObjectTypeID").Caption = rL3("Loai_DT_no") 'Loại ĐT nợ 1
        tdbg.Columns("DObjectID").Caption = rL3("DT_no") 'ĐT nợ 1
        tdbg.Columns("CObjectTypeID").Caption = rL3("Loai_DT_co") 'Loại ĐT có 1
        tdbg.Columns("CObjectID").Caption = rL3("DT_co") 'ĐT có 1
        tdbg.Columns("M_DObjectTypeID").Caption = rL3("Loai_DT_no") 'Loại ĐT nợ
        tdbg.Columns("M_DObjectID").Caption = rL3("DT_no") 'ĐT nợ
        tdbg.Columns("M_CObjectTypeID").Caption = rL3("Loai_DT_co") '
        tdbg.Columns("M_CObjectID").Caption = rL3("DT_co") 'ĐT có
        tdbg.Columns("PeriodID").Caption = rL3("Tap_phi")

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadEdit()
        btnNext.Visible = False
        btnSave.Left = btnNext.Right - btnSave.Width
        ReadOnlyControl(txtPolicyID)
        Dim sSQL As String
        sSQL = "-- Do nguon master cua co che" & vbCrLf
        sSQL &= " Select PolicyID, PolicyName" & UnicodeJoin(gbUnicode) & " as PolicyName, Disabled, IsSliptVouchers from D13T1165  WITH (NOLOCK) where PolicyID = " & SQLString(_policyID)
        Dim dtMaster As DataTable = ReturnDataTable(sSQL)
        If dtMaster.Rows.Count > 0 Then
            txtPolicyID.Text = dtMaster.Rows(0).Item("PolicyID").ToString
            txtPolicyName.Text = dtMaster.Rows(0).Item("PolicyName").ToString
            chkDisabled.Checked = L3Bool(dtMaster.Rows(0).Item("Disabled").ToString)
            chkIsSliptVouchers.Checked = L3Bool(dtMaster.Rows(0).Item("IsSliptVouchers"))
        End If
    End Sub

    Dim dtObjectID As DataTable
    Dim dtM_Object As DataTable
    Private Sub LoadTDBDropDown()

        Dim sSQL As String = ""

        sSQL = SQLStoreD13P2161(1)
        dtDataD13P2161_Mode_1 = ReturnDataTable(sSQL)

        sSQL = SQLStoreD13P2161(0)
        dtDataD13P2161_Mode_0 = ReturnDataTable(sSQL)


        'sSQL = "Select Code as PayCalID, " & IIf(geLanguage = EnumLanguage.Vietnamese, "Description", "Description01").ToString & UnicodeJoin(gbUnicode) & " as Description From D13T9000  WITH (NOLOCK) "
        'sSQL &= "Where Type='PRCAL' and Disabled = 0 Order by PayCalID"
        'Dim dtPayCalID As DataTable = ReturnTableFilter(dtDataD13P2161, "", True)

        LoadDataSource(tdbdPayCalID, ReturnTableFilter(dtDataD13P2161_Mode_1, "SourceName = 'PayCal'", True), gbUnicode)

        'sSQL = "Select TransferMethodID, TransferMethodName" & UnicodeJoin(gbUnicode) & " as TransferMethodName From D13T1160  WITH (NOLOCK) "
        'sSQL &= "Where Disabled = 0 Order by TransferMethodID"
        'Dim dtTransferMethodID As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbdTransferMethodID, ReturnTableFilter(dtDataD13P2161_Mode_1, "SourceName = 'TransferMethod'", True), gbUnicode)

        'Load tdbdDebitAccountID
        'sSQL = "Select 'BLANK' as AccountID, " & IIf(gbUnicode, "N'" & rl3("De_trong") & "'", "'" & rl3("De_trong_VNI") & "'").ToString & " as AccountName, 0 as DisplayOrder" & vbCrLf
        'sSQL &= "Union All" & vbCrLf
        'sSQL &= "Select 'DEF' as AccountID, " & IIf(gbUnicode, "N'" & rl3("Theo_phuong_phap_chuyen") & "'", "'" & rl3("Theo_phuong_phap_chuyen_VNI") & "'").ToString & " as AccountName, 1 as DisplayOrder" & vbCrLf
        'sSQL &= "Union All" & vbCrLf
        'sSQL &= "SELECT AccountID AS AccountID," & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName", "AccountName01").ToString & UnicodeJoin(gbUnicode) & " As AccountName, 2 As DisplayOrder" & vbCrLf
        'sSQL &= "FROM D90T0001  WITH (NOLOCK) WHERE(Disabled = 0 And OffAccount = 0) ORDER BY DisplayOrder, AccountID"
        Dim dtAccountID As DataTable = ReturnTableFilter(dtDataD13P2161_Mode_1, "SourceName = 'Account'", True)

        LoadDataSource(tdbdDebitAccountID, dtAccountID, gbUnicode)
        LoadDataSource(tdbdCreditAccountID, dtAccountID.Copy, gbUnicode)

        'Load tdbdObjectID
        'sSQL = "Select 'BLANK' as ObjectID, " & IIf(gbUnicode, "N'" & rl3("De_trong") & "'", "'" & rl3("De_trong_VNI") & "'").ToString & " as ObjectName, 0 as DisplayOrder, '%' as ObjectTypeID" & vbCrLf
        'sSQL &= "Union All" & vbCrLf
        'sSQL &= "Select 'DEF' as ObjectID, " & IIf(gbUnicode, "N'" & rl3("Theo_phuong_phap_chuyen") & "'", "'" & rl3("Theo_phuong_phap_chuyen_VNI") & "'").ToString & " as ObjectName, 1 as DisplayOrder, '%' as ObjectTypeID" & vbCrLf
        'sSQL &= "Union All" & vbCrLf
        'sSQL &= "Select ObjectID, ObjectName" & UnicodeJoin(gbUnicode) & " as ObjectName, 2 as DisplayOrder, ObjectTypeID From Object WITH (NOLOCK) " & vbCrLf
        'sSQL &= "Where	Disabled = 0 " & vbCrLf
        'sSQL &= "Order by DisplayOrder, ObjectTypeID, ObjectID"

        dtObjectID = ReturnTableFilter(dtDataD13P2161_Mode_1, "SourceName = 'Object'", True)

        'Load tdbdDObjectTypeID
        'sSQL = "Select 'BLANK' as ObjectTypeID, " & IIf(gbUnicode, "N'" & rl3("De_trong") & "'", "'" & rl3("De_trong_VNI") & "'").ToString & " as ObjectTypeName, 0 as DisplayOrder" & vbCrLf
        'sSQL &= "Union All" & vbCrLf
        'sSQL &= "Select 'DEF' as ObjectTypeID, " & IIf(gbUnicode, "N'" & rl3("Theo_phuong_phap_chuyen") & "'", "'" & rl3("Theo_phuong_phap_chuyen_VNI") & "'").ToString & " as ObjectTypeName, 1 as DisplayOrder" & vbCrLf
        'sSQL &= "Union All" & vbCrLf
        'sSQL &= "SELECT	ObjectTypeID, " & IIf(geLanguage = EnumLanguage.Vietnamese, "ObjectTypeName", "ObjectTypeName01").ToString & UnicodeJoin(gbUnicode) & " AS ObjectTypeName, 2 AS DisplayOrder" & vbCrLf
        'sSQL &= "FROM D91T0005  WITH (NOLOCK) ORDER BY DisplayOrder, ObjectTypeID"

        Dim dtObjectTypeID As DataTable = ReturnTableFilter(dtDataD13P2161_Mode_1, "SourceName = 'ObjectType'", True) ' ReturnDataTable(sSQL)

        LoadDataSource(tdbdDObjectTypeID, dtObjectTypeID, gbUnicode)
        LoadDataSource(tdbdCObjectTypeID, dtObjectTypeID.Copy, gbUnicode)

        LoadtdbdObjectID("-1", tdbdDObjectID)

        LoadtdbdObjectID("-1", tdbdCObjectID)

        Dim dtObjectTypeID_M As DataTable = ReturnTableFilter(dtDataD13P2161_Mode_0, "SourceName = 'ObjectType'", True)

        'LoadObjectTypeID(tdbdM_DObjectTypeID, gbUnicode)
        'LoadObjectTypeID(tdbdM_CObjectTypeID, gbUnicode)

        LoadDataSource(tdbdM_DObjectTypeID, dtObjectTypeID_M, gbUnicode)
        LoadDataSource(tdbdM_CObjectTypeID, dtObjectTypeID_M.Copy, gbUnicode)

        'sSQL = "SELECT DataTypeID as ObjectID, DataTypeID as AnaID, DataTypeName" & UnicodeJoin(gbUnicode) & " AS ObjectName, DataTypeName" & UnicodeJoin(gbUnicode) & " AS AnaName  FROM D13V2060 WHERE Language = " & SQLString(gsLanguage) & " ORDER BY DataTypeID "
        dtM_Object = ReturnTableFilter(dtDataD13P2161_Mode_0, "SourceName = 'Object'", True)

        If dtM_Object.Columns.Contains("AnaID") = False Then dtM_Object.Columns.Add("AnaID", Type.GetType("System.String"), "Code")
        If dtM_Object.Columns.Contains("AnaName") = False Then dtM_Object.Columns.Add("AnaName", Type.GetType("System.String"), "Name")

        LoadDataSource(tdbdM_DObjectID, dtM_Object.Copy, gbUnicode)
        LoadDataSource(tdbdM_CObjectID, dtM_Object.Copy, gbUnicode)

        'Load tdbdPeriodID
        'sSQL = "Select A.PeriodID as PeriodID, ISNULL(A.WorkOrderNo, '') as WorkOrderNo, Note" & UnicodeJoin(gbUnicode) & " as Note " & vbCrLf
        ''Update 15/03/2012: Incident 47313
        'sSQL &= " FROM 	D08N0100 (" & SQLString(gsDivisionID) & " , " & giTranMonth & " , " & giTranYear & ", 2) A  " & vbCrLf
        ''        sSQL &= " FROM 	D08N0100 (" & SQLString(gsDivisionID) & " , " & giTranMonth & " , " & giTranYear & ", 0) A  " & vbCrLf
        ''        sSQL &= " WHERE 	A.DAGroupID='' OR A.DAGroupID IN (	SELECT    DAGroupID FROM LemonSys.dbo.D00V0080"
        ''        sSQL &= " WHERE 	UserID = " & SQLString(gsUserID) & ") OR " & SQLString(gsUserID) & " = 'LEMONADMIN'" & vbCrLf
        'sSQL &= " ORDER BY 	PeriodID"

        LoadDataSource(tdbdPeriodID, ReturnTableFilter(dtDataD13P2161_Mode_1, "SourceName = 'Period'", True), gbUnicode)

        LoadDataSource(tdbdM_Ana01ID, dtM_Object.Copy, gbUnicode)
        LoadDataSource(tdbdM_Ana02ID, dtM_Object.Copy, gbUnicode)
        LoadDataSource(tdbdM_Ana03ID, dtM_Object.Copy, gbUnicode)
        LoadDataSource(tdbdM_Ana04ID, dtM_Object.Copy, gbUnicode)
        LoadDataSource(tdbdM_Ana05ID, dtM_Object.Copy, gbUnicode)
        LoadDataSource(tdbdM_Ana06ID, dtM_Object.Copy, gbUnicode)
        LoadDataSource(tdbdM_Ana07ID, dtM_Object.Copy, gbUnicode)
        LoadDataSource(tdbdM_Ana08ID, dtM_Object.Copy, gbUnicode)
        LoadDataSource(tdbdM_Ana09ID, dtM_Object.Copy, gbUnicode)
        LoadDataSource(tdbdM_Ana10ID, dtM_Object.Copy, gbUnicode)

        Load10TDBDropDownAna()
    End Sub


    Private Sub LoadtdbdObjectID(ByVal ID As String, ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, Optional ByVal iMode As Integer = 1)
        'If ID = "%" Then
        '    LoadDataSource(tdbdDObjectID, dtObjectID, gbUnicode)
        'Else
        If iMode = 1 Then
            LoadDataSource(tdbd, ReturnTableFilter(dtObjectID, " ParentID = " & SQLString(ID) & " or ParentID ='%'"), gbUnicode)
        Else
            LoadDataSource(tdbd, ReturnTableFilter(dtM_Object, " ParentID = " & SQLString(ID) & " or ParentID ='%'"), gbUnicode)
        End If

        'End If
    End Sub



    Private Sub Load10TDBDropDownAna()
        'LoadTDBDropDownAna_Custom(tdbdAna01ID, tdbdAna02ID, tdbdAna03ID, tdbdAna04ID, tdbdAna05ID, tdbdAna06ID, tdbdAna07ID, tdbdAna08ID, tdbdAna09ID, tdbdAna10ID, gbUnicode)
        'LoadTDBDropDownAna_Custom(tdbdM_Ana01ID, tdbdM_Ana02ID, tdbdM_Ana03ID, tdbdM_Ana04ID, tdbdM_Ana05ID, tdbdM_Ana06ID, tdbdM_Ana07ID, tdbdM_Ana08ID, tdbdM_Ana09ID, tdbdM_Ana10ID, gbUnicode)
        Dim dtAnaAll As DataTable = ReturnTableFilter(dtDataD13P2161_Mode_1, "SourceName = 'Ana'", True)
        If dtAnaAll.Columns.Contains("AnaID") = False Then dtAnaAll.Columns.Add("AnaID", Type.GetType("System.String"), "Code")
        If dtAnaAll.Columns.Contains("AnaName") = False Then dtAnaAll.Columns.Add("AnaName", Type.GetType("System.String"), "Name")
        For i As Integer = 0 To 9
            If L3Bool(tdbg.Columns(COL_Ana01ID + i).Tag) = False Then Continue For
            Dim dtAna As DataTable = ReturnTableFilter(dtAnaAll, "ParentID = 'K" & (i + 1).ToString("00") & "'", True)
            LoadDataSource(tdbg.Columns(COL_Ana01ID + i).DropDown, dtAna, gbUnicode)
        Next
    End Sub

    Private Sub LoadTDBDropDownAna_Custom(ByVal tdbdAna01ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna02ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna03ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna04ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna05ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna06ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna07ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna08ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna09ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal tdbdAna10ID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, Optional ByVal bUseUnicode As Boolean = False)
        Dim dt As DataTable
        Dim sSQL As String = ""
        sSQL = "Select 'BLANK' as AnaID, " & IIf(gbUnicode, "N'" & rl3("De_trong") & "'", "'" & rl3("De_trong_VNI") & "'").ToString & " as AnaName, 0 as DisplayOrder, '%' as AnaCategoryID" & vbCrLf
        sSQL &= "Union All" & vbCrLf
        sSQL &= "Select 'DEF' as AnaID, " & IIf(gbUnicode, "N'" & rl3("Theo_phuong_phap_chuyen") & "'", "'" & rl3("Theo_phuong_phap_chuyen_VNI") & "'").ToString & " as AnaName, 1 as DisplayOrder, '%' as AnaCategoryID" & vbCrLf
        sSQL &= "Union All" & vbCrLf
        sSQL &= "Select AnaID, AnaName" & UnicodeJoin(bUseUnicode) & " as AnaName, 2 as DisplayOrder, AnaCategoryID From D91T0051  WITH (NOLOCK) Where Disabled = 0 And AnaCategoryID like 'K%' Order by DisplayOrder, AnaCategoryID, AnaID"
        dt = ReturnDataTable(sSQL)

        LoadDataSource(tdbdAna01ID, ReturnTableFilter(dt, "AnaCategoryID='K01' or AnaCategoryID='%' "), bUseUnicode)
        LoadDataSource(tdbdAna02ID, ReturnTableFilter(dt, "AnaCategoryID='K02' or AnaCategoryID='%' "), bUseUnicode)
        LoadDataSource(tdbdAna03ID, ReturnTableFilter(dt, "AnaCategoryID='K03' or AnaCategoryID='%' "), bUseUnicode)
        LoadDataSource(tdbdAna04ID, ReturnTableFilter(dt, "AnaCategoryID='K04' or AnaCategoryID='%' "), bUseUnicode)
        LoadDataSource(tdbdAna05ID, ReturnTableFilter(dt, "AnaCategoryID='K05' or AnaCategoryID='%' "), bUseUnicode)
        LoadDataSource(tdbdAna06ID, ReturnTableFilter(dt, "AnaCategoryID='K06' or AnaCategoryID='%' "), bUseUnicode)
        LoadDataSource(tdbdAna07ID, ReturnTableFilter(dt, "AnaCategoryID='K07' or AnaCategoryID='%' "), bUseUnicode)
        LoadDataSource(tdbdAna08ID, ReturnTableFilter(dt, "AnaCategoryID='K08' or AnaCategoryID='%' "), bUseUnicode)
        LoadDataSource(tdbdAna09ID, ReturnTableFilter(dt, "AnaCategoryID='K09' or AnaCategoryID='%' "), bUseUnicode)
        LoadDataSource(tdbdAna10ID, ReturnTableFilter(dt, "AnaCategoryID='K10' or AnaCategoryID='%' "), bUseUnicode)
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKeyID As String = "")
        Dim sSQL As String
        sSQL = SQLStoreD13P2165()
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt, gbUnicode)
        UpdateTDBGOrderNum(tdbg, COL_OrderNum)
    End Sub

    Private Sub SetBackColorObligatory()
        txtPolicyID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtPolicyName.BackColor = COLOR_BACKCOLOROBLIGATORY

        tdbg.Splits(SPLIT0).DisplayColumns(COL_PayCalID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TransferMethodID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.UpdateData()
        UpdateTDBGOrderNum(tdbg, COL_OrderNum)
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
                If tdbg.Columns(COL_DObjectTypeID).Text <> tdbdDObjectTypeID.Columns(0).Text Then
                    tdbg.Columns(COL_DObjectTypeID).Text = ""
                End If
            Case COL_CObjectTypeID
                If tdbg.Columns(COL_CObjectTypeID).Text <> tdbdCObjectTypeID.Columns(0).Text Then
                    tdbg.Columns(COL_CObjectTypeID).Text = ""
                End If
            Case COL_DObjectID
                If tdbg.Columns(COL_DObjectID).Text <> tdbdDObjectID.Columns(0).Text Then
                    tdbg.Columns(COL_DObjectID).Text = ""
                End If

            Case COL_DebitAccountID
                If tdbg.Columns(COL_DebitAccountID).Text <> tdbdDebitAccountID.Columns(0).Text Then
                    tdbg.Columns(COL_DebitAccountID).Text = ""
                End If
            Case COL_CreditAccountID
                If tdbg.Columns(COL_CreditAccountID).Text <> tdbdCreditAccountID.Columns(0).Text Then
                    tdbg.Columns(COL_CreditAccountID).Text = ""
                End If
                '===================================================================================
            Case COL_M_Ana01ID
                If tdbg.Columns(COL_M_Ana01ID).Text <> tdbdM_Ana01ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(0) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_M_Ana01ID).Text = ""
                    Else
                        If tdbg.Columns(COL_M_Ana01ID).Text.Length > giArrAnaLength(0) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_M_Ana01ID).Text = ""
                        End If
                    End If
                End If
            Case COL_M_Ana02ID
                If tdbg.Columns(COL_M_Ana02ID).Text <> tdbdM_Ana02ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(1) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_M_Ana02ID).Text = ""
                    Else
                        If tdbg.Columns(COL_M_Ana02ID).Text.Length > giArrAnaLength(1) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_M_Ana02ID).Text = ""
                        End If
                    End If
                End If
            Case COL_M_Ana03ID
                If tdbg.Columns(COL_M_Ana03ID).Text <> tdbdM_Ana03ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(2) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_M_Ana03ID).Text = ""
                    Else
                        If tdbg.Columns(COL_M_Ana03ID).Text.Length > giArrAnaLength(2) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_M_Ana03ID).Text = ""
                        End If
                    End If
                End If
            Case COL_M_Ana04ID
                If tdbg.Columns(COL_M_Ana04ID).Text <> tdbdM_Ana04ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(3) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_M_Ana04ID).Text = ""
                    Else
                        If tdbg.Columns(COL_M_Ana04ID).Text.Length > giArrAnaLength(3) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_M_Ana04ID).Text = ""
                        End If
                    End If
                End If
            Case COL_M_Ana05ID
                If tdbg.Columns(COL_M_Ana05ID).Text <> tdbdM_Ana05ID.Columns("AnaID").Text Then
                    If gbArrAnaValidate(4) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(COL_M_Ana05ID).Text = ""
                    Else
                        If tdbg.Columns(COL_M_Ana05ID).Text.Length > giArrAnaLength(4) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(COL_M_Ana05ID).Text = ""
                        End If
                    End If
                End If
            Case COL_M_Ana06ID
                If tdbg.Columns(COL_M_Ana06ID).Text <> tdbdM_Ana06ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_M_Ana06ID).Text = ""
                End If
            Case COL_M_Ana07ID
                If tdbg.Columns(COL_M_Ana07ID).Text <> tdbdM_Ana07ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_M_Ana07ID).Text = ""
                End If
            Case COL_M_Ana08ID
                If tdbg.Columns(COL_M_Ana08ID).Text <> tdbdM_Ana08ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_M_Ana08ID).Text = ""
                End If
            Case COL_M_Ana09ID
                If tdbg.Columns(COL_M_Ana09ID).Text <> tdbdM_Ana09ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_M_Ana09ID).Text = ""
                End If
            Case COL_M_Ana10ID
                If tdbg.Columns(COL_M_Ana10ID).Text <> tdbdM_Ana10ID.Columns("AnaID").Text Then
                    tdbg.Columns(COL_M_Ana10ID).Text = ""
                End If

            Case COL_M_DObjectTypeID
                If tdbg.Columns(COL_M_DObjectTypeID).Text <> tdbdM_DObjectTypeID.Columns(0).Text Then
                    tdbg.Columns(COL_M_DObjectTypeID).Text = ""
                End If
            Case COL_M_CObjectTypeID
                If tdbg.Columns(COL_M_CObjectTypeID).Text <> tdbdM_CObjectTypeID.Columns(0).Text Then
                    tdbg.Columns(COL_M_CObjectTypeID).Text = ""
                End If
            Case COL_M_DObjectID
                If tdbg.Columns(COL_M_DObjectID).Text <> tdbdM_DObjectID.Columns(0).Text Then
                    tdbg.Columns(COL_M_DObjectID).Text = ""
                End If
            Case COL_M_CObjectID
                If tdbg.Columns(COL_M_CObjectID).Text <> tdbdM_CObjectID.Columns(0).Text Then
                    tdbg.Columns(COL_M_CObjectID).Text = ""
                End If
            Case COL_PayCalID
                If tdbg.Columns(COL_PayCalID).Text = "" Then Exit Sub
                For i As Integer = 0 To tdbg.RowCount - 1
                    If tdbg.Row = i Or tdbg(i, COL_PayCalID).ToString = "" Then Continue For
                    If tdbg(i, COL_PayCalID).ToString = tdbdPayCalID.Columns(0).Text Then
                        D99C0008.MsgL3(rl3("Khoan_thu_nhap_da_ton_tai"))
                        tdbg.Columns(COL_PayCalID).Text = ""
                        tdbg.Columns(COL_Description).Text = ""
                        tdbdPayCalID.Row = -1
                        e.Cancel = True
                    End If
                Next
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
    Private Function SQLStoreD13P2165() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2165 "
        sSQL &= SQLString(_policyID) & COMMA 'TransferMethodID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1165
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 11/11/2010 02:14:53
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1165() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D13T1165(")
        sSQL.Append("PolicyID, PolicyName, PolicyNameU, Disabled, CreateDate, ")
        sSQL.Append("CreateUserID, LastModifyDate, LastModifyUserID,IsSliptVouchers")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtPolicyID.Text) & COMMA) 'PolicyID, varchar[50], NOT NULL
        sSQL.Append(SQLStringUnicode(txtPolicyName.Text, gbUnicode, False) & COMMA) 'PolicyName, varchar[500], NOT NULL
        sSQL.Append(SQLStringUnicode(txtPolicyName.Text, gbUnicode, True) & COMMA) 'PolicyNameU, nvarchar, NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(chkIsSliptVouchers.Checked)) 'IsSliptVouchers, tinyint, NOT NULL
        sSQL.Append(")")
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1166s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 11/11/2010 02:20:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1166s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sDetail As String = ""
        Dim nRowCountBatchID As Long
        Dim iFirstIGEBatchID As Long

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_DetailID).ToString = "" Then
                nRowCountBatchID += 1
            End If
        Next
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_DetailID).ToString = "" Then
                sDetail = CreateIGENewS("D13T1166", "DetailID", "13", "DA", gsStringKey, sDetail, nRowCountBatchID, iFirstIGEBatchID)
                tdbg(i, COL_DetailID) = sDetail
            End If

            sSQL.Append("Insert Into D13T1166(")
            sSQL.Append("PolicyID, DetailID, PayCalID, TransferMethodID, DebitAccountID, ")
            sSQL.Append("CreditAccountID, DObjectTypeID, DObjectID, CObjectTypeID, CObjectID, ")
            sSQL.Append("Ana01ID, Ana02ID, Ana03ID, Ana04ID, Ana05ID, ")
            sSQL.Append("Ana06ID, Ana07ID, Ana08ID, Ana09ID, Ana10ID, ")
            sSQL.Append("M_DObjectTypeID, M_DObjectID, M_CObjectTypeID, M_CObjectID, M_Ana01ID, ")
            sSQL.Append("M_Ana02ID, M_Ana03ID, M_Ana04ID, M_Ana05ID, M_Ana06ID, ")
            sSQL.Append("M_Ana07ID, M_Ana08ID, M_Ana09ID, M_Ana10ID, PeriodID ")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtPolicyID.Text) & COMMA) 'PolicyID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DetailID)) & COMMA) 'DetailID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PayCalID)) & COMMA) 'PayCalID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TransferMethodID)) & COMMA) 'TransferMethodID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DebitAccountID)) & COMMA) 'DebitAccountID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CreditAccountID)) & COMMA) 'CreditAccountID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DObjectTypeID)) & COMMA) 'DObjectTyepID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DObjectID)) & COMMA) 'DObjectID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CObjectTypeID)) & COMMA) 'CObjectTypeID, varchar[50], NOT NULL
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
            sSQL.Append(SQLString(tdbg(i, COL_M_DObjectTypeID)) & COMMA) 'M_DObjectTyepID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_DObjectID)) & COMMA) 'M_DObjectID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_CObjectTypeID)) & COMMA) 'M_CObjectTypeID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_CObjectID)) & COMMA) 'M_CObjectID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_Ana01ID)) & COMMA) 'M_Ana01ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_Ana02ID)) & COMMA) 'M_Ana02ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_Ana03ID)) & COMMA) 'M_Ana03ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_Ana04ID)) & COMMA) 'M_Ana04ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_Ana05ID)) & COMMA) 'M_Ana05ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_Ana06ID)) & COMMA) 'M_Ana06ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_Ana07ID)) & COMMA) 'M_Ana07ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_Ana08ID)) & COMMA) 'M_Ana08ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_Ana09ID)) & COMMA) 'M_Ana09ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_M_Ana10ID)) & COMMA) 'M_Ana10ID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PeriodID))) 'PeriodID, varchar[50], NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1165
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 11/11/2010 02:27:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1165() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T1165 Set ")
        sSQL.Append("PolicyName = " & SQLStringUnicode(txtPolicyName.Text, gbUnicode, False) & COMMA) 'varchar[500], NOT NULL
        sSQL.Append("PolicyNameU = " & SQLStringUnicode(txtPolicyName.Text, gbUnicode, True) & COMMA) 'nvarchar, NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("IsSliptVouchers  = " & SQLNumber(chkIsSliptVouchers.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID)) 'varchar[20], NOT NULL
        sSQL.Append(" Where PolicyID = " & SQLString(txtPolicyID.Text) & vbCrLf)
        sSQL.Append("Delete D13T1166 where PolicyID = " & SQLString(txtPolicyID.Text))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2161
    '# Created User: Lê Anh Vũ
    '# Created Date: 14/04/2015 11:36:53
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2161(Optional ByVal iMode As Integer = 0) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load du lieu chung cho Combo, DD" & vbCrLf)
        sSQL &= "Exec D13P2161 "
        sSQL &= SQLString(gsCompanyID) & COMMA 'CompanyID, varchar[50], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, int, NOT NULL
        Return sSQL
    End Function




    Private Function AllowSave() As Boolean
        If txtPolicyID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma"))
            txtPolicyID.Focus()
            Return False
        End If
        If txtPolicyName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten"))
            txtPolicyName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D13T1165", "PolicyID", txtPolicyID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtPolicyID.Focus()
                Return False
            End If
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_PayCalID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Khoan_thu_nhap"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_PayCalID
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_TransferMethodID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("PP_chuyen_but_toan"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_TransferMethodID
                tdbg.Bookmark = i
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        tdbg.UpdateData()
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD13T1165().ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T1166s())
            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T1165().ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T1166s())
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            SaveOK()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    PolicyID = txtPolicyID.Text
                    If sender IsNot Nothing Then btnNext.Text = rl3("_Nhap_tiep")
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
            btnClose.Enabled = True
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If btnNext.Text = rl3("Luu_va_Nhap__tiep") Then btnSave_Click(Nothing, Nothing)
        If _bSaved = False Then Exit Sub 'luu k thanh cong
        btnSave.Enabled = True
        btnNext.Text = rl3("Luu_va_Nhap__tiep")
     
        txtPolicyID.Text = ""
        _policyID = ""
        txtPolicyName.Text = ""
        chkDisabled.Checked = False
        LoadTDBGrid()
        txtPolicyID.Focus()

    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_DObjectTypeID
                tdbg.Columns(COL_DObjectID).Text = ""
            Case COL_CObjectTypeID
                tdbg.Columns(COL_CObjectID).Text = ""

            Case COL_M_DObjectTypeID
                tdbg.Columns(COL_M_DObjectID).Text = ""
            Case COL_M_CObjectTypeID
                tdbg.Columns(COL_M_CObjectID).Text = ""
            Case COL_PayCalID
                tdbg.Columns(COL_Description).Text = tdbdPayCalID.Columns(1).Text
        End Select
    End Sub

    Dim iColD() As Integer = {COL_DObjectTypeID, COL_DObjectID}
    Dim iColC() As Integer = {COL_CObjectTypeID, COL_CObjectID}
    Dim iColM_D() As Integer = {COL_M_DObjectTypeID, COL_M_DObjectID}
    Dim iColM_C() As Integer = {COL_M_CObjectTypeID, COL_M_CObjectID}
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_PayCalID
                Exit Sub
            Case COL_DObjectTypeID, COL_DObjectID
                CopyColumnArr(tdbg, e.ColIndex, iColD)
            Case COL_CObjectTypeID, COL_CObjectID
                CopyColumnArr(tdbg, e.ColIndex, iColC)
            Case COL_M_DObjectTypeID, COL_M_DObjectID
                CopyColumnArr(tdbg, e.ColIndex, iColM_D)
            Case COL_M_CObjectTypeID, COL_M_CObjectID
                CopyColumnArr(tdbg, e.ColIndex, iColM_C)
            Case Else
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Text, tdbg.Row)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        HotKeyDownGrid(e, tdbg, COL_OrderNum, 0, 1)
        Select Case e.KeyCode
            Case Keys.F7
                HotKeyF7(tdbg)
            Case Keys.F8
                HotKeyF8(tdbg)
            Case Keys.Enter
                Select Case tdbg.Col
                    Case COL_CObjectID, COL_Ana10ID, COL_M_Ana10ID
                        HotKeyEnterGrid(tdbg, COL_PayCalID, e, SPLIT0)
                End Select
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_DObjectID
                LoadtdbdObjectID(tdbg.Columns(COL_DObjectTypeID).Text, tdbdDObjectID)
            Case COL_CObjectID
                LoadtdbdObjectID(tdbg.Columns(COL_CObjectTypeID).Text, tdbdCObjectID)

            Case COL_M_DObjectID
                LoadtdbdObjectID(tdbg.Columns(COL_M_DObjectTypeID).Text, tdbdM_DObjectID, 0)
            Case COL_M_CObjectID
                LoadtdbdObjectID(tdbg.Columns(COL_M_CObjectTypeID).Text, tdbdM_CObjectID, 0)
        End Select
    End Sub

    Dim bUseAna As Boolean = False
    Private Sub ClickButton(ByVal button As Button)
        btnAccObject.Enabled = Math.Abs(button - button.SalaryCoefficientBase) > 0
        btnAna.Enabled = Math.Abs(button - button.AnalyseCode) > 0 'And bUseAna Update 19/01/2012: nút này Có thêm cột Tập phí
        btnLink.Enabled = Math.Abs(button - button.Income) > 0
        '1. Tài khoản - Đối tượng
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DebitAccountID).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CreditAccountID).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DObjectTypeID).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DObjectID).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CObjectTypeID).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CObjectID).Visible = Math.Abs(button - button.SalaryCoefficientBase) = 0

        '2. Khoản mục
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana01ID).Visible = Math.Abs(button - button.AnalyseCode) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana01ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana02ID).Visible = Math.Abs(button - button.AnalyseCode) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana02ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana03ID).Visible = Math.Abs(button - button.AnalyseCode) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana03ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana04ID).Visible = Math.Abs(button - button.AnalyseCode) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana04ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana05ID).Visible = Math.Abs(button - button.AnalyseCode) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana05ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana06ID).Visible = Math.Abs(button - button.AnalyseCode) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana06ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana07ID).Visible = Math.Abs(button - button.AnalyseCode) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana07ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana08ID).Visible = Math.Abs(button - button.AnalyseCode) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana08ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana09ID).Visible = Math.Abs(button - button.AnalyseCode) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana09ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana10ID).Visible = Math.Abs(button - button.AnalyseCode) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana10ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_PeriodID).Visible = Math.Abs(button - button.AnalyseCode) = 0

        '3. Mapping
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_DObjectTypeID).Visible = Math.Abs(button - button.Income) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_DObjectID).Visible = Math.Abs(button - button.Income) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_CObjectTypeID).Visible = Math.Abs(button - button.Income) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_CObjectID).Visible = Math.Abs(button - button.Income) = 0


        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_Ana01ID).Visible = Math.Abs(button - button.Income) = 0 And Convert.ToBoolean(tdbg.Columns(COL_M_Ana01ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_Ana02ID).Visible = Math.Abs(button - button.Income) = 0 And Convert.ToBoolean(tdbg.Columns(COL_M_Ana02ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_Ana03ID).Visible = Math.Abs(button - button.Income) = 0 And Convert.ToBoolean(tdbg.Columns(COL_M_Ana03ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_Ana04ID).Visible = Math.Abs(button - button.Income) = 0 And Convert.ToBoolean(tdbg.Columns(COL_M_Ana04ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_Ana05ID).Visible = Math.Abs(button - button.Income) = 0 And Convert.ToBoolean(tdbg.Columns(COL_M_Ana05ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_Ana06ID).Visible = Math.Abs(button - button.Income) = 0 And Convert.ToBoolean(tdbg.Columns(COL_M_Ana06ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_Ana07ID).Visible = Math.Abs(button - button.Income) = 0 And Convert.ToBoolean(tdbg.Columns(COL_M_Ana07ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_Ana08ID).Visible = Math.Abs(button - button.Income) = 0 And Convert.ToBoolean(tdbg.Columns(COL_M_Ana08ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_Ana09ID).Visible = Math.Abs(button - button.Income) = 0 And Convert.ToBoolean(tdbg.Columns(COL_M_Ana09ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_M_Ana10ID).Visible = Math.Abs(button - button.Income) = 0 And Convert.ToBoolean(tdbg.Columns(COL_M_Ana10ID).Tag)
    End Sub

    Private Sub btnAccObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccObject.Click
        ClickButton(Button.SalaryCoefficientBase)
    End Sub

    Private Sub btnAna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAna.Click
        ClickButton(Button.AnalyseCode)
    End Sub

    Private Sub btnLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLink.Click
        ClickButton(Button.Income)
    End Sub

    Private Sub tdbg_LockColumn()
        With tdbg.Splits(SPLIT0)
            .DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End With
    End Sub

End Class
