Public Class D13F3011
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

#Region "Const of tdbg"
    Private Const COL_Orders As Integer = 0              ' STT
    Private Const COL_PayCalID As Integer = 1            ' Khoản thu nhập
    Private Const COL_Description As Integer = 2         ' Diễn giải
    Private Const COL_Short As Integer = 3               ' Tên tắt
    Private Const COL_SalaryVoucherID As Integer = 4     ' Phiếu lương
    Private Const COL_DivisionID As Integer = 5          ' Mã đơn vị
    Private Const COL_EmployeeID As Integer = 6          ' Mã nhân viên
    Private Const COL_TransferMethodID As Integer = 7    ' Mã PP chuyển bút toán
    Private Const COL_TranMonth As Integer = 8           ' Kỳ kế toán
    Private Const COL_TranYear As Integer = 9            ' Năm kế toán
    Private Const COL_TransID As Integer = 10            ' Bút toán
    Private Const COL_DebitAccountID As Integer = 11     ' TK Nợ
    Private Const COL_CreditAccountID As Integer = 12    ' TK Có
    Private Const COL_CurrencyID As Integer = 13         ' Nguyên tệ
    Private Const COL_OriginalAmount As Integer = 14     ' Số nguyên tệ
    Private Const COL_ConvertedAmount As Integer = 15    ' Số tiền quy đổi
    Private Const COL_ObjectTypeID As Integer = 16       ' Loại ĐT nợ
    Private Const COL_ObjectID As Integer = 17           ' ĐT nợ
    Private Const COL_CreditObjectTypeID As Integer = 18 ' Loại ĐT có
    Private Const COL_CreditObjectID As Integer = 19     ' ĐT có
    Private Const COL_CreateUserID As Integer = 20       ' CreateUserID
    Private Const COL_CreateDate As Integer = 21         ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 22   ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 23     ' LastModifyDate
    Private Const COL_Ana01ID As Integer = 24            ' Khoản mục 1
    Private Const COL_Ana02ID As Integer = 25            ' Khoản mục 2
    Private Const COL_Ana03ID As Integer = 26            ' Khoản mục 3
    Private Const COL_Ana04ID As Integer = 27            ' Khoản mục 4
    Private Const COL_Ana05ID As Integer = 28            ' Khoản mục 5
    Private Const COL_Ana06ID As Integer = 29            ' Khoản mục 6
    Private Const COL_Ana07ID As Integer = 30            ' Khoản mục 7
    Private Const COL_Ana08ID As Integer = 31            ' Khoản mục 8
    Private Const COL_Ana09ID As Integer = 32            ' Khoản mục 9
    Private Const COL_Ana10ID As Integer = 33            ' Khoản mục 10
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()

            LoadTDBGridAnalysisCaption("D13", tdbg, COL_Ana01ID, SPLIT0, True)

            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                    btnTransfer.Enabled = True

                Case EnumFormState.FormView
                    btnTransfer.Enabled = False
            End Select
        End Set
    End Property

    Private _SalaryVoucherID As String = ""
    Public Property SalaryVoucherID() As String
        Get
            Return _SalaryVoucherID
        End Get
        Set(ByVal Value As String)
            _SalaryVoucherID = Value
        End Set
    End Property


    Private _SalaryVoucherNo As String = ""
    Public Property SalaryVoucherNo() As String
        Get
            Return _SalaryVoucherNo
        End Get
        Set(ByVal Value As String)
            _SalaryVoucherNo = Value
        End Set
    End Property

    Private _VoucherDate As String = ""
    Public Property VoucherDate() As String
        Get
            Return _VoucherDate
        End Get
        Set(ByVal Value As String)
            _VoucherDate = Value
        End Set
    End Property

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_chuyen_but_toan_-_D13F3011") 'Chi tiÕt chuyÓn bòt toÀn - D13F3011
        '================================================================ 
        btnTransfer.Text = rl3("_Chuyen_but_toan") '&Chuyển bút toán
        btnClose.Text = rl3("Do_ng") 'Đó&ng

        '================================================================ 
        tdbg.Columns("Orders").Caption = rl3("STT") 'STT
        tdbg.Columns("PayCalID").Caption = rl3("Khoan_thu_nhap") 'Khoản thu nhập
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("Short").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg.Columns("SalaryVoucherID").Caption = rl3("Phieu_luong") 'Phiếu lương
        tdbg.Columns("DivisionID").Caption = rl3("Ma_don_vi") 'Mã đơn vị
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("TransferMethodID").Caption = rl3("Ma_PP_chuyen_but_toan") 'Mã PP chuyển bút toán
        tdbg.Columns("TranMonth").Caption = rl3("Ky_ke_toan") 'Kỳ kế toán
        tdbg.Columns("TranYear").Caption = rl3("Nam_ke_toan") 'Năm kế toán
        tdbg.Columns("TransID").Caption = rl3("But_toan") 'Bút toán
        tdbg.Columns("DebitAccountID").Caption = rl3("TK_no") 'TK Nợ
        'tdbg.Columns("CreditAccountID").Caption = rl3("TK_Co") 'TK Có
        tdbg.Columns("CreditAccountID").Caption = rl3("TK_co") 'TK Có
        tdbg.Columns("CurrencyID").Caption = rl3("Nguyen_te") 'Nguyên tệ
        tdbg.Columns("OriginalAmount").Caption = rl3("So_nguyen_te") 'Số nguyên tệ
        tdbg.Columns("ConvertedAmount").Caption = rl3("So_tien_quy_doi") 'Số tiền quy đổi
        tdbg.Columns("ObjectTypeID").Caption = rl3("Loai_DT_no") 'Loại ĐT nợ
        tdbg.Columns("ObjectID").Caption = rl3("DT_no") 'ĐT nợ
        tdbg.Columns("CreditObjectTypeID").Caption = rl3("Loai_DT_co") 'Loại ĐT có
        tdbg.Columns("CreditObjectID").Caption = rl3("DT_co") 'ĐT có
     
        'tdbg.Columns("Ana01ID").Caption = rl3("Khoan_muc_1") 'Khoản mục 1
        'tdbg.Columns("Ana02ID").Caption = rl3("Khoan_muc_2") 'Khoản mục 2
        'tdbg.Columns("Ana03ID").Caption = rl3("Khoan_muc_3") 'Khoản mục 3
        'tdbg.Columns("Ana04ID").Caption = rl3("Khoan_muc_4") 'Khoản mục 4
        'tdbg.Columns("Ana05ID").Caption = rl3("Khoan_muc_5") 'Khoản mục 5
        'tdbg.Columns("Ana06ID").Caption = rl3("Khoan_muc_6") 'Khoản mục 6
        'tdbg.Columns("Ana07ID").Caption = rl3("Khoan_muc_7") 'Khoản mục 7
        'tdbg.Columns("Ana08ID").Caption = rl3("Khoan_muc_8") 'Khoản mục 8
        'tdbg.Columns("Ana09ID").Caption = rl3("Khoan_muc_9") 'Khoản mục 9
        'tdbg.Columns("Ana10ID").Caption = rl3("Khoan_muc_10") 'Khoản mục 10
    End Sub


    Private Sub LoadTDBGrid()
        Dim sSQL As String
        sSQL = "Select 0 as Orders,Right(PayCalID,len(PayCalID)-3) as PayCalID,Description,Short," & vbCrLf
        sSQL &= "SalaryVoucherID,DivisionID,EmployeeID,TransferMethodID,TranMonth,TranYear,TransID," & vbCrLf
        sSQL &= "DebitAccountID,CreditAccountID,CurrencyID,OriginalAmount,ConvertedAmount," & vbCrLf
        sSQL &= "Ana01ID,Ana02ID,Ana03ID,Ana04ID,Ana05ID,Ana06ID,Ana07ID,Ana08ID,Ana09ID,Ana10ID," & vbCrLf
        sSQL &= "ObjectTypeID,ObjectID,CreditObjectTypeID,CreditObjectID,D13T2110.Disabled" & vbCrLf
        sSQL &= "From D13T2110  WITH(NOLOCK) Inner Join D13T9000  WITH(NOLOCK) On PayCalID=Code" & vbCrLf
        sSQL &= "Where DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "And TranMonth=" & giTranMonth & " And TranYear=" & giTranYear & vbCrLf
        sSQL &= "And SalaryVoucherID=" & SQLString(_SalaryVoucherID)
        Dim dt As DataTable = ReturnDataTable(sSQL)

        LoadDataSource(tdbg, dt)
        tdbg_FooterText()
        tdbg_NumberFormat()
        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, COL_Orders) = i + 1
        Next
    End Sub

    Private Sub tdbg_FooterText()
        Dim SumOAmount As Double = 0
        Dim SumCAmount As Double = 0

        For i As Int32 = 0 To tdbg.RowCount - 1
            SumOAmount += Number(SQLNumber(tdbg(i, COL_OriginalAmount).ToString, D13Format.DefaultNumber2))
            SumCAmount += Number(SQLNumber(tdbg(i, COL_ConvertedAmount).ToString, D13Format.DefaultNumber2))
        Next
        FooterTotalGrid(tdbg, COL_CurrencyID)
        tdbg.Columns(COL_OriginalAmount).FooterText = SQLNumber(SumOAmount.ToString, D13Format.DefaultNumber2)
        tdbg.Columns(COL_ConvertedAmount).FooterText = SQLNumber(SumCAmount.ToString, D13Format.DefaultNumber2)
    End Sub

    Private Sub D13F3011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        LoadTDBGrid()
        btnTransfer.Enabled = Not gbClosed
        'tdbg.Splits(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        'tdbg.Splits(0).HeadingStyle.Font = New Font("Lemon3", 8, FontStyle.Regular)
        'ResetFooterGrid(tdbg, 0, 0)
        ResetColorGrid(tdbg, 0, 0)
        SetResolutionForm(Me)
    End Sub

    Public Function LoadTDBGridAnalysisCaption1(ByVal ModuleID As String, ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal COL_Ana01ID As Integer, ByVal Split As Integer, Optional ByVal IsVisibleColumn As Boolean = False) As Boolean
        Dim bUseAna As Boolean = False

        Dim sSQL As String = "Select AnaCategoryID, AnaCategoryShort, AnaCategoryLength, AnaCategoryValidate, AnaCategoryStatus, Use" & ModuleID & " as UseModule From D91T0050  WITH(NOLOCK) Where System = 1  And AnaTypeID = 'K' Order by AnaCategoryID"
        Dim dt As New DataTable
        dt = ReturnDataTable(sSQL)
        Dim col As Integer = COL_Ana01ID
        Dim i As Integer
        If dt.Rows.Count > 0 Then
            For i = 0 To 9
                c1Grid.Columns(col).Caption = dt.Rows(i).Item("AnaCategoryShort").ToString
                c1Grid.Columns(col).Tag = Convert.ToBoolean(dt.Rows(i).Item("UseModule")) And Convert.ToBoolean(dt.Rows(i).Item("AnaCategoryStatus"))
                c1Grid.Splits(Split).DisplayColumns(col).HeadingStyle.Font = New System.Drawing.Font("Lemon3", 8.249999!)
                gbArrAnaValidate(col - COL_Ana01ID) = Convert.ToBoolean(dt.Rows(i).Item("AnaCategoryValidate"))
                giArrAnaLength(col - COL_Ana01ID) = Convert.ToInt16(dt.Rows(i).Item("AnaCategoryLength"))
                If IsVisibleColumn Then
                    c1Grid.Splits(Split).DisplayColumns(col).Visible = Convert.ToBoolean(c1Grid.Columns(col).Tag)
                    If Not bUseAna And Convert.ToBoolean(c1Grid.Columns(col).Tag) = True Then
                        bUseAna = True
                    End If
                End If
                col += 1
            Next
        End If
        dt = Nothing

        Return bUseAna

    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2111
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/03/2007 08:42:21
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2111() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2111 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_SalaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransferMethodID).Text) & COMMA 'TransferMethodID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2113
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/03/2007 08:43:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2113() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2113 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_SalaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransferMethodID).Text) & COMMA 'TransferMethodID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        If geLanguage = EnumLanguage.Vietnamese Then
            sSQL &= SQLNumber(0) 'Language, tinyint, NOT NULL
        ElseIf geLanguage = EnumLanguage.English Then
            sSQL &= SQLNumber(1) 'Language, tinyint, NOT NULL
        End If
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2112
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/03/2007 08:42:41
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2112() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2112 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_SalaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_TransferMethodID).Text) & COMMA 'TransferMethodID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function

    Private Function CheckBeforeTransfer() As Boolean
        Dim sSQL As String
        sSQL = SQLStoreD13P2113()
        Return CheckStore(sSQL)
    End Function

    Private Sub btnTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
        Dim sSQL As String = ""
        Dim bResult As Boolean
        _bSaved = False

        sSQL = "Select Top 1 1 From D13T2110 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where DivisionID=" & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "And TranMonth=" & giTranMonth & " And TranYear=" & giTranYear & vbCrLf
        sSQL &= "And SalaryVoucherID=" & SQLString(_SalaryVoucherID)

        If Not ExistRecord(sSQL) Then
            D99C0008.MsgL3(rl3("Phieu_nay_khong_ton_tai_but_toan_de_chuyen_Vui_long_kiem_tra_lai"), L3MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If D99C0008.MsgAsk(rl3("Ban_co_that_su_muon_chuyen_nhung_but_toan_nay_khong")) = Windows.Forms.DialogResult.No Then Exit Sub
        End If

        If Not CheckBeforeTransfer() Then Exit Sub

        sSQL = SQLStoreD13P2112() & vbCrLf
        sSQL &= SQLStoreD13P2111()

        bResult = ExecuteSQL(sSQL)
        If bResult Then
            D99C0008.MsgL3(rl3("Chuyen_but_toan_thanh_cong"))
            _bSaved = True
            'Lưu lại vết Audit
            'If CheckAudit("TransactionInquiry") Then
            '    sSQL = SQLStoreD91P9106("TransactionInquiry", "13", "03", _VoucherDate, _SalaryVoucherNo, _SalaryVoucherID, tdbg.Columns(COL_TransferMethodID).Text, "")
            '    ExecuteSQLNoTransaction(sSQL)
            'End If
            Lemon3.D91.RunAuditLog("13", "TransactionInquiry", "03", _VoucherDate, _SalaryVoucherNo, _SalaryVoucherID, tdbg.Columns(COL_TransferMethodID).Text, "")
            btnClose.Focus()
        Else
            D99C0008.MsgL3(rl3("Chuyen_but_toan_khong_thanh_cong"))
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_OriginalAmount).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_ConvertedAmount).NumberFormat = D13Format.DefaultNumber2
    End Sub

End Class