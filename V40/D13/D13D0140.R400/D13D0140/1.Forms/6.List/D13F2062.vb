Public Class D13F2062

    Private dtObject As DataTable
    Private dtAna As DataTable

#Region "Const of tdbg"
    Private Const COL_Orders As Integer = 0                     ' STT
    Private Const COL_PayCalID As Integer = 1                   ' Thu nhập
    Private Const COL_Description As Integer = 2                ' Diễn giải
    Private Const COL_DebitAccountID As Integer = 3             ' TK Nợ
    Private Const COL_CreditAccountID As Integer = 4            ' TK Có
    Private Const COL_DefaultDebitAccountID As Integer = 5      ' TK nợ mặc định
    Private Const COL_DefaultCreditAccountID As Integer = 6     ' TK có mặc định
    Private Const COL_Disabled As Integer = 7                   ' Không sử dụng
    Private Const COL_ObjectTypeID As Integer = 8               ' Loại đối tượng
    Private Const COL_ObjectID As Integer = 9                   ' Đối tượng
    Private Const COL_DefaultObjectTypeID As Integer = 10       ' Loại ĐT mặc định
    Private Const COL_DefaultObjectID As Integer = 11           ' ĐT mặc định
    Private Const COL_CreditObjectTypeID As Integer = 12        ' Loại đối tượng
    Private Const COL_CreditObjectID As Integer = 13            ' Đối tượng
    Private Const COL_DefaultCreditObjectTypeID As Integer = 14 ' Loại ĐT mặc định
    Private Const COL_DefaultCreditObjectID As Integer = 15     ' ĐT mặc định
    Private Const COL_Ana01ID As Integer = 16                   ' KM1
    Private Const COL_Ana02ID As Integer = 17                   ' KM2
    Private Const COL_Ana03ID As Integer = 18                   ' KM3
    Private Const COL_Ana04ID As Integer = 19                   ' KM4
    Private Const COL_Ana05ID As Integer = 20                   ' KM5
    Private Const COL_Ana06ID As Integer = 21                   ' KM6
    Private Const COL_Ana07ID As Integer = 22                   ' KM7
    Private Const COL_Ana08ID As Integer = 23                   ' KM8
    Private Const COL_Ana09ID As Integer = 24                   ' KM9
    Private Const COL_Ana10ID As Integer = 25                   ' KM10
    Private Const COL_CreateUserID As Integer = 26              ' CreateUserID
    Private Const COL_CreateDate As Integer = 27                ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 28          ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 29            ' LastModifyDate
#End Region

    Private _TransferMethodID As String = ""
    Public Property TransferMethodID() As String
        Get
            Return _TransferMethodID
        End Get
        Set(ByVal value As String)
            _TransferMethodID = value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState

    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            CreateTableAna()
            CreateTableTypeObject()
            LoadTDBDropDown()
            LoadTDBDropDownAna()
            LoadTDBGridAnalysisCaption("D13", tdbg, COL_Ana01ID, SPLIT1, True, gbUnicode)

            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnSave.Enabled = True
                    LoadEdit()
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    btnSave.Focus()
                    LoadEdit()
            End Select
        End Set
    End Property

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdPayCalID
        sSQL = "Select Code as PayCalID, Description" & UnicodeJoin(gbUnicode) & " as Description" & vbCrLf
        sSQL &= "From D13T9000 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Type='PRCAL' And Disabled = 0 Order by PayCalID"
        LoadDataSource(tdbdPayCalID, sSQL, gbUnicode)

        'Load tdbdDebitAccountID
        sSQL = "Select AccountID," & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName", "AccountName01").ToString & UnicodeJoin(gbUnicode) & " As AccountName " & vbCrLf
        sSQL &= "From D90T0001 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 " & vbCrLf
        sSQL &= "Union All" & vbCrLf
        sSQL &= "Select Code as AccountID, Description" & UnicodeJoin(gbUnicode) & " as AccountName From D13T9000 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Type='PMACC' And Disabled=0 Order by AccountID"

        Dim dt As DataTable = ReturnDataTable(sSQL)

        LoadDataSource(tdbdDebitAccountID, dt, gbUnicode)
        LoadDataSource(tdbdCreditAccountID, dt.Copy, gbUnicode)

        'Load tdbdDefaultCreditAccountID
        sSQL = "Select AccountID," & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName", "AccountName01").ToString & UnicodeJoin(gbUnicode) & " As AccountName " & vbCrLf
        sSQL &= " From D90T0001  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 Order by AccountID"

        Dim dt1 As DataTable = ReturnDataTable(sSQL)

        LoadDataSource(tdbdDefaultCreditAccountID, dt1, gbUnicode)
        LoadDataSource(tdbdDefaultDebitAccountID, dt1.Copy, gbUnicode)

        'Load tdbdObjectTypeID
        sSQL = "Select ObjectTypeID,ObjectTypeName" & IIf(geLanguage = EnumLanguage.Vietnamese, "", "01").ToString & UnicodeJoin(gbUnicode) & " as ObjectTypeName" & vbCrLf
        sSQL &= "From D91T0005  WITH (NOLOCK) Order by ObjectTypeID"
        Dim dt2 As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbdObjectTypeID, dt2, gbUnicode)
        LoadDataSource(tdbdDefaultObjectTypeID, dt2.Copy, gbUnicode)
        LoadDataSource(tdbdCreditObjectTypeID, dt2.Copy, gbUnicode)
        LoadDataSource(tdbdDefaultCreditObjectTypeID, dt2.Copy, gbUnicode)

    End Sub

    Private Sub CreateTableTypeObject()
        Dim sSQL As String = ""
        'Load tdbdObjectID
        sSQL = "Select ObjectID,ObjectName" & UnicodeJoin(gbUnicode) & " as ObjectName,ObjectTypeID From Object   WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 Order by ObjectTypeID,ObjectID"
        dtObject = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadtdbdObjectID(ByVal sValue As String)
        'Load tdbtdbdObjectID
        LoadDataSource(tdbdObjectID, ReturnTableFilter(dtObject, "ObjectTypeID=" & SQLString(sValue)), gbUnicode)
    End Sub

    Private Sub LoadtdbdDefaultObjectID(ByVal sValue As String)
        'Load tdbtdbdDefaultObjectID
        LoadDataSource(tdbdDefaultObjectID, ReturnTableFilter(dtObject, "ObjectTypeID=" & SQLString(sValue)), gbUnicode)
    End Sub

    Private Sub LoadtdbdCreditObjectID(ByVal sValue As String)
        'Load tdbtdbdCreditObjectID
        LoadDataSource(tdbdCreditObjectID, ReturnTableFilter(dtObject, "ObjectTypeID=" & SQLString(sValue)), gbUnicode)
    End Sub

    Private Sub LoadtdbdDefaultCreditObjectID(ByVal sValue As String)
        'Load tdbtdbdDefaultCreditObjectID
        LoadDataSource(tdbdDefaultCreditObjectID, ReturnTableFilter(dtObject, "ObjectTypeID=" & SQLString(sValue)), gbUnicode)
    End Sub
    Private Sub CreateTableAna()
        Dim sSQL As String
        sSQL = "Select AnaID,AnaName" & UnicodeJoin(gbUnicode) & " as AnaName,AnaCategoryID From D91T0051 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 Order by AnaID"
        dtAna = ReturnDataTable(sSQL)
    End Sub

    Public Sub LoadTDBDropDownAna()
        Dim sSQL As String = ""
        'Load 10 tdbdAna_nn_ID
        LoadDataSource(tdbdAna01ID, ReturnTableFilter(dtAna, "AnaCategoryID='K01'"), gbUnicode)
        LoadDataSource(tdbdAna02ID, ReturnTableFilter(dtAna, "AnaCategoryID='K02'"), gbUnicode)
        LoadDataSource(tdbdAna03ID, ReturnTableFilter(dtAna, "AnaCategoryID='K03'"), gbUnicode)
        LoadDataSource(tdbdAna04ID, ReturnTableFilter(dtAna, "AnaCategoryID='K04'"), gbUnicode)
        LoadDataSource(tdbdAna05ID, ReturnTableFilter(dtAna, "AnaCategoryID='K05'"), gbUnicode)
        LoadDataSource(tdbdAna06ID, ReturnTableFilter(dtAna, "AnaCategoryID='K06'"), gbUnicode)
        LoadDataSource(tdbdAna07ID, ReturnTableFilter(dtAna, "AnaCategoryID='K07'"), gbUnicode)
        LoadDataSource(tdbdAna08ID, ReturnTableFilter(dtAna, "AnaCategoryID='K08'"), gbUnicode)
        LoadDataSource(tdbdAna09ID, ReturnTableFilter(dtAna, "AnaCategoryID='K09'"), gbUnicode)
        LoadDataSource(tdbdAna10ID, ReturnTableFilter(dtAna, "AnaCategoryID='K10'"), gbUnicode)
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL = "Select TransferMethodID,TransferMethodName" & UnicodeJoin(gbUnicode) & " as TransferMethodName,Disabled,TransferMode" & vbCrLf
        sSQL &= "From D13T1110  WITH (NOLOCK) Where TransferMethodID=" & SQLString(_TransferMethodID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            txtTransferMethodID.Text = dt.Rows(0).Item("TransferMethodID").ToString
            txtTransferMethodName.Text = dt.Rows(0).Item("TransferMethodName").ToString
            If dt.Rows(0).Item("TransferMode").ToString = "0" Then
                optDetail.Checked = True
            Else
                optCollect.Checked = True
            End If
        End If
    End Sub

    Private Sub LoadEdit()
        LoadMaster()
        LoadDetail()
    End Sub

    Private Sub LoadDetail()
        Dim sSQL As String = ""
        sSQL = "Select '' as Orders,* From D13T1120 WITH (NOLOCK) " & vbCrLf
        sSQL &= " WHERE  TransferMethodID= " & SQLString(_TransferMethodID)
        LoadDataSource(tdbg, sSQL, gbUnicode)
        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, COL_Orders) = i + 1
        Next
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_PayCalID
                If tdbg.Columns(COL_PayCalID).Text <> "" Then
                    tdbg.Columns(COL_Description).Text = tdbdPayCalID.Columns("Description").Text
                Else
                    tdbg.Columns(COL_Description).Text = ""
                End If

                UpdateTDBGOrderNum(tdbg, COL_Orders)
            Case COL_DefaultDebitAccountID
                UpdateTDBGOrderNum(tdbg, COL_Orders)
            Case COL_DefaultCreditAccountID
                UpdateTDBGOrderNum(tdbg, COL_Orders)
            Case COL_DefaultObjectTypeID, COL_DefaultObjectID
                UpdateTDBGOrderNum(tdbg, COL_Orders)
            Case COL_DefaultCreditObjectTypeID, COL_DefaultCreditObjectID
                UpdateTDBGOrderNum(tdbg, COL_Orders)
            Case COL_Ana01ID
                TestInputAna(tdbg, tdbdAna01ID, COL_Ana01ID, 0)
            Case COL_Ana02ID
                TestInputAna(tdbg, tdbdAna02ID, COL_Ana02ID, 1)
            Case COL_Ana03ID
                TestInputAna(tdbg, tdbdAna03ID, COL_Ana03ID, 2)
            Case COL_Ana04ID
                TestInputAna(tdbg, tdbdAna04ID, COL_Ana04ID, 3)
            Case COL_Ana05ID
                TestInputAna(tdbg, tdbdAna05ID, COL_Ana05ID, 4)
            Case COL_Ana06ID
                TestInputAna(tdbg, tdbdAna06ID, COL_Ana06ID, 5)
            Case COL_Ana07ID
                TestInputAna(tdbg, tdbdAna07ID, COL_Ana07ID, 6)
            Case COL_Ana08ID
                TestInputAna(tdbg, tdbdAna08ID, COL_Ana08ID, 7)
            Case COL_Ana09ID
                TestInputAna(tdbg, tdbdAna09ID, COL_Ana09ID, 8)
            Case COL_Ana10ID
                TestInputAna(tdbg, tdbdAna10ID, COL_Ana10ID, 9)
        End Select
    End Sub

    Private Sub TestInputAna(ByVal TDBG As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal TDBDD As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal colAna As Integer, ByVal i As Integer)
        With TDBG
            If gbArrAnaValidate(i) = True Then 'Nhap trong danh sach 
                If .Columns(colAna).Text <> TDBDD.Columns(0).Text Then
                    .Columns(colAna).Text = ""
                End If
            Else
                If .Columns(colAna).Text <> "" And .Columns(colAna).Text.Length > giArrAnaLength(i) Then
                    .Columns(colAna).Text = (.Columns(colAna).Text).Substring(0, giArrAnaLength(i))
                End If
            End If
        End With
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        UpdateTDBGOrderNum(tdbg, COL_Orders)
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case e.ColIndex
            Case COL_ObjectID
                LoadtdbdObjectID(tdbg.Columns(COL_ObjectTypeID).Text)
            Case COL_DefaultObjectID
                LoadtdbdDefaultObjectID(tdbg.Columns(COL_DefaultObjectTypeID).Text)
            Case COL_CreditObjectID
                LoadtdbdCreditObjectID(tdbg.Columns(COL_CreditObjectTypeID).Text)
            Case COL_DefaultCreditObjectID
                LoadtdbdDefaultCreditObjectID(tdbg.Columns(COL_DefaultCreditObjectTypeID).Text)
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_PayCalID
                If tdbg.Columns(COL_PayCalID).Text <> tdbdPayCalID.Columns("PayCalID").Text Then
                    tdbg.Columns(COL_PayCalID).Text = ""
                    tdbg.Columns(COL_Description).Text = ""
                End If
            Case COL_DebitAccountID
                If tdbg.Columns(COL_DebitAccountID).Text <> tdbdDebitAccountID.Columns("AccountID").Text Then
                    tdbg.Columns(COL_DebitAccountID).Text = ""
                End If
            Case COL_CreditAccountID
                If tdbg.Columns(COL_CreditAccountID).Text <> tdbdCreditAccountID.Columns("AccountID").Text Then
                    tdbg.Columns(COL_CreditAccountID).Text = ""
                End If
            Case COL_DefaultDebitAccountID
                If tdbg.Columns(COL_DefaultDebitAccountID).Text <> tdbdDefaultDebitAccountID.Columns("AccountID").Text Then
                    tdbg.Columns(COL_DefaultDebitAccountID).Text = ""
                End If
            Case COL_DefaultCreditAccountID
                If tdbg.Columns(COL_DefaultCreditAccountID).Text <> tdbdDefaultCreditAccountID.Columns("AccountID").Text Then
                    tdbg.Columns(COL_DefaultCreditAccountID).Text = ""
                End If
            Case COL_ObjectTypeID
                If tdbg.Columns(COL_ObjectTypeID).Text <> tdbdObjectTypeID.Columns("ObjectTypeID").Text Then
                    tdbg.Columns(COL_ObjectTypeID).Text = ""
                    tdbg.Columns(COL_ObjectID).Text = ""
                End If
            Case COL_ObjectID
                If tdbg.Columns(COL_ObjectID).Text <> tdbdObjectID.Columns("ObjectID").Text Then
                    tdbg.Columns(COL_ObjectID).Text = ""
                End If
            Case COL_DefaultObjectTypeID
                If tdbg.Columns(COL_DefaultObjectTypeID).Text <> tdbdDefaultObjectTypeID.Columns("ObjectTypeID").Text Then
                    tdbg.Columns(COL_DefaultObjectTypeID).Text = ""
                    tdbg.Columns(COL_DefaultObjectID).Text = ""
                End If
            Case COL_DefaultObjectID
                If tdbg.Columns(COL_DefaultObjectID).Text <> tdbdDefaultObjectID.Columns("ObjectID").Text Then
                    tdbg.Columns(COL_DefaultObjectID).Text = ""
                End If
            Case COL_CreditObjectTypeID
                If tdbg.Columns(COL_CreditObjectTypeID).Text <> tdbdCreditObjectTypeID.Columns("ObjectTypeID").Text Then
                    tdbg.Columns(COL_CreditObjectTypeID).Text = ""
                    tdbg.Columns(COL_CreditObjectID).Text = ""
                End If
            Case COL_CreditObjectID
                If tdbg.Columns(COL_CreditObjectID).Text <> tdbdCreditObjectID.Columns("ObjectID").Text Then
                    tdbg.Columns(COL_CreditObjectID).Text = ""
                End If
            Case COL_DefaultCreditObjectTypeID
                If tdbg.Columns(COL_DefaultCreditObjectTypeID).Text <> tdbdDefaultCreditObjectTypeID.Columns("ObjectTypeID").Text Then
                    tdbg.Columns(COL_DefaultCreditObjectTypeID).Text = ""
                    tdbg.Columns(COL_DefaultCreditObjectID).Text = ""
                End If
            Case COL_DefaultCreditObjectID
                If tdbg.Columns(COL_DefaultCreditObjectID).Text <> tdbdDefaultCreditObjectID.Columns("ObjectID").Text Then
                    tdbg.Columns(COL_DefaultCreditObjectID).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_PayCalID
                If tdbg.Columns(COL_PayCalID).Text <> "" Then
                    tdbg.Columns(COL_Description).Text = tdbdPayCalID.Columns("Description").Text
                Else
                    tdbg.Columns(COL_Description).Text = ""
                End If
            Case COL_ObjectTypeID
                tdbg.Columns(COL_ObjectID).Text = ""
            Case COL_DefaultObjectTypeID
                tdbg.Columns(COL_DefaultObjectID).Text = ""
            Case COL_CreditObjectTypeID
                tdbg.Columns(COL_CreditObjectID).Text = ""
            Case COL_DefaultCreditObjectTypeID
                tdbg.Columns(COL_DefaultCreditObjectID).Text = ""
        End Select
    End Sub
    Private Sub ClickButton(ByVal button As Button)

        btnDebitObject.Enabled = Math.Abs(button - button.Debit) > 0
        btnCreditObject.Enabled = Math.Abs(button - button.Credit) > 0
        btnAna.Enabled = Math.Abs(button - button.Ana) > 0
        '1.Đối tượng nợ
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ObjectTypeID).Visible = Math.Abs(button - button.Debit) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ObjectID).Visible = Math.Abs(button - button.Debit) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DefaultObjectTypeID).Visible = Math.Abs(button - button.Debit) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DefaultObjectID).Visible = Math.Abs(button - button.Debit) = 0
        '2.Đối tượng có
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CreditObjectTypeID).Visible = Math.Abs(button - button.Credit) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CreditObjectID).Visible = Math.Abs(button - button.Credit) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DefaultCreditObjectTypeID).Visible = Math.Abs(button - button.Credit) = 0
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DefaultCreditObjectID).Visible = Math.Abs(button - button.Credit) = 0
        '3. Khoản mục
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana01ID).Visible = Math.Abs(button - button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana01ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana02ID).Visible = Math.Abs(button - button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana02ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana03ID).Visible = Math.Abs(button - button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana03ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana04ID).Visible = Math.Abs(button - button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana04ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana05ID).Visible = Math.Abs(button - button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana05ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana06ID).Visible = Math.Abs(button - button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana06ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana07ID).Visible = Math.Abs(button - button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana07ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana08ID).Visible = Math.Abs(button - button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana08ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana09ID).Visible = Math.Abs(button - button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana09ID).Tag)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana10ID).Visible = Math.Abs(button - button.Ana) = 0 And Convert.ToBoolean(tdbg.Columns(COL_Ana10ID).Tag)

    End Sub

    Private Sub btnDebitObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDebitObject.Click
        tdbg.Splits(SPLIT1).Caption = rl3("Doi_tuong_no")
        tdbg.Splits(1).CaptionStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        ClickButton(Button.Debit)
        tdbg.SplitIndex = SPLIT1
        tdbg.Col = COL_ObjectTypeID
    End Sub

    Private Sub btnCreditObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreditObject.Click
        tdbg.Splits(SPLIT1).Caption = rl3("Doi_tuong_co")
        tdbg.Splits(1).CaptionStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        ClickButton(Button.Credit)
        tdbg.SplitIndex = SPLIT1
        tdbg.Col = COL_CreditObjectTypeID
    End Sub

    Private Sub btnAna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAna.Click
        tdbg.Splits(SPLIT1).Caption = rl3("Khoan_muc")
        tdbg.Splits(1).CaptionStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        ClickButton(Button.Ana)
        tdbg.SplitIndex = SPLIT1
        tdbg.Col = COL_Ana01ID
    End Sub
    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Orders).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Orders).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub D13F2062_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.F1 Then
            btnHotKey_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
    End Sub

    Private Sub D13F2062_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        Me.Cursor = Cursors.WaitCursor
        tdbg_LockedColumns()

        UnicodeGridDataField(tdbg, COL_Description, gbUnicode)

        tdbg.Splits(SPLIT1).Caption = rl3("Doi_tuong_no")
        ClickButton(Button.Debit)
        tdbg.SplitIndex = SPLIT1
        tdbg.Col = COL_ObjectTypeID

        tdbg.Splits(0).CaptionStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        tdbg.Splits(1).CaptionStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        txtTransferMethodName.Font = FontUnicode(gbUnicode)
        SetResolutionForm(Me)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_phuong_phap_chuyen_but_toan_-_D13F2062") & UnicodeCaption(gbUnicode) 'Chi tiÕt ph§¥ng phÀp chuyÓn bòt toÀn - D13F2062
        '================================================================ 
        lblTransferMethodID.Text = rl3("Ma") 'Mã phương pháp
        lblTransferMethodName.Text = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        btnDebitObject.Text = rl3("1_Doi_tuong_no") '1. Đối tượng nợ
        btnCreditObject.Text = rl3("2_Doi_tuong_co") '2. Đối tượng có
        btnAna.Text = "3. " & rl3("Khoan_muc") '3. Khoản mục
        btnHotKey.Text = rl3("_Phim_nong") '&Phím nóng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        optCollect.Text = rl3("Tong_hop") 'Tổng hợp
        optDetail.Text = rl3("Chi_tiet") 'Chi tiết
        '================================================================ 

        GroupBox2.Text = rl3("Hinh_thuc_chuyen_but_toan") 'Hình thức chuyển bút toán
        '================================================================ 
        tdbdAna01ID.Columns("AnaID").Caption = rl3("Ma_khoan_muc") 'Mã khoản mục
        tdbdAna01ID.Columns("AnaName").Caption = rl3("Ten_khoan_muc") 'Tên khoản mục
        tdbdAna02ID.Columns("AnaID").Caption = rl3("Ma_khoan_muc") 'Mã khoản mục
        tdbdAna02ID.Columns("AnaName").Caption = rl3("Ten_khoan_muc") 'Tên khoản mục
        tdbdAna03ID.Columns("AnaID").Caption = rl3("Ma_khoan_muc") 'Mã khoản mục
        tdbdAna03ID.Columns("AnaName").Caption = rl3("Ten_khoan_muc") 'Tên khoản mục
        tdbdAna04ID.Columns("AnaID").Caption = rl3("Ma_khoan_muc") 'Mã khoản mục
        tdbdAna04ID.Columns("AnaName").Caption = rl3("Ten_khoan_muc") 'Tên khoản mục
        tdbdAna05ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna05ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna06ID.Columns("AnaID").Caption = rl3("Ma_khoan_muc") 'Mã khoản mục
        tdbdAna06ID.Columns("AnaName").Caption = rl3("Ten_khoan_muc") 'Tên khoản mục
        tdbdAna07ID.Columns("AnaID").Caption = rl3("Ma_khoan_muc") 'Mã khoản mục
        tdbdAna07ID.Columns("AnaName").Caption = rl3("Ten_khoan_muc") 'Tên khoản mục
        tdbdAna08ID.Columns("AnaID").Caption = rl3("Ma_khoan_muc") 'Mã khoản mục
        tdbdAna08ID.Columns("AnaName").Caption = rl3("Ten_khoan_muc") 'Tên khoản mục
        tdbdAna09ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna09ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna10ID.Columns("AnaID").Caption = rl3("Ma_khoan_muc") 'Mã khoản mục
        tdbdAna10ID.Columns("AnaName").Caption = rl3("Ten_khoan_muc") 'Tên khoản mục
        tdbdPayCalID.Columns("PayCalID").Caption = rl3("Thu_nhap") 'Thu nhập
        tdbdPayCalID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdDebitAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbdDebitAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbdCreditAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbdCreditAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbdDefaultCreditAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbdDefaultCreditAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbdDefaultDebitAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbdDefaultDebitAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbdObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbdObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdDefaultObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbdDefaultObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdDefaultCreditObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbdDefaultCreditObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdCreditObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbdCreditObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdDefaultCreditObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbdDefaultCreditObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        tdbdCreditObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbdCreditObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        tdbdDefaultObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbdDefaultObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên 
        tdbdObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbdObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        '================================================================ 

        tdbg.Columns("Orders").Caption = rl3("STT") 'STT
        tdbg.Columns("PayCalID").Caption = rl3("Thu_nhap") 'Thu nhập
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("DebitAccountID").Caption = rl3("TK_no") 'TK Nợ
        'tdbg.Columns("CreditAccountID").Caption = rl3("TK_Co") 'TK Có
        tdbg.Columns("CreditAccountID").Caption = rl3("TK_co") 'TK Có
        tdbg.Columns("DefaultDebitAccountID").Caption = rl3("TK_no_mac_dinh") 'TK nợ mặc định
        tdbg.Columns("DefaultCreditAccountID").Caption = rl3("TK_co_mac_dinh") 'TK có mặc định
        tdbg.Columns("Disabled").Caption = rl3("Khong_su_dung") 'Không sử dụng
        tdbg.Columns("ObjectTypeID").Caption = rl3("Loai_doi_tuong") 'Loại đối tượng
        tdbg.Columns("ObjectID").Caption = rl3("Doi_tuong") 'Đối tượng
        tdbg.Columns("DefaultObjectTypeID").Caption = rl3("Loai_DT_mac_dinh") 'Loại ĐT mặc định
        tdbg.Columns("DefaultObjectID").Caption = rl3("DT_mac_dinh_") 'ĐT mặc định 
        tdbg.Columns("CreditObjectTypeID").Caption = rl3("Loai_doi_tuong") 'Loại đối tượng
        tdbg.Columns("CreditObjectID").Caption = rl3("Doi_tuong") 'Đối tượng
        tdbg.Columns("DefaultCreditObjectTypeID").Caption = rl3("Loai_DT_mac_dinh") 'Loại ĐT mặc định
        tdbg.Columns("DefaultCreditObjectID").Caption = rl3("DT_mac_dinh_") 'ĐT mặc định
        'tdbg.Columns("Ana01ID").Caption = rl3("KM1") 'KM1
        'tdbg.Columns("Ana02ID").Caption = rl3("KM2") 'KM2
        'tdbg.Columns("Ana03ID").Caption = rl3("KM3") 'KM3
        'tdbg.Columns("Ana04ID").Caption = rl3("KM4") 'KM4
        'tdbg.Columns("Ana05ID").Caption = rl3("KM5") 'KM5
        'tdbg.Columns("Ana06ID").Caption = rl3("KM6") 'KM6
        'tdbg.Columns("Ana07ID").Caption = rl3("KM7") 'KM7
        'tdbg.Columns("Ana08ID").Caption = rl3("KM8") 'KM8
        'tdbg.Columns("Ana09ID").Caption = rl3("KM9") 'KM9
        'tdbg.Columns("Ana10ID").Caption = rl3("KM10") 'KM10
        tdbg.Splits(0).Caption = rl3("Thong_tin_chinh")
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_Ana01ID, COL_Ana02ID, COL_Ana03ID, COL_Ana04ID, COL_Ana05ID, COL_Ana06ID, COL_Ana07ID, COL_Ana08ID, COL_Ana09ID, COL_Ana10ID
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Value.ToString, tdbg.Row)
        End Select
    End Sub


    'Hai hàm này chép từ D99X0000 ra
    ''' <summary>
    ''' Copy giá trị trong 1 cột (khi nhấn Head_Click)
    ''' </summary>
    ''' <param name="c1Grid">Lưới C1</param>
    ''' <param name="ColCopy">Cột cần copy</param>
    ''' <param name="sValue">Giá trị cần copy</param>
    ''' <param name="RowCopy">Dòng đang copy</param>
    ''' <remarks>Chỉ dùng copy những cột dữ liệu không liên quan đến các cột khác, copy cả giá trị ''</remarks>

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            'If sValue = "" Or c1Grid.RowCount < 2 Then Exit Sub
            If c1Grid.RowCount < 2 Then Exit Sub

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse Val(c1Grid(i, ColCopy).ToString) = 0 Then c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(RowCopy, ColCopy) = sValue

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(0, ColCopy) = sValue
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Copy giá trị trong 1 cột có liên quan đến các cột kế nó (khi nhấn Head_Click)
    ''' </summary>
    ''' <param name="c1Grid">Lưới C1</param>
    ''' <param name="ColCopy">Cột cần copy</param>
    ''' <param name="RowCopy">Dòng cần copy</param>
    ''' <param name="ColumnCount">Số cột liên quan khi cần copy</param>
    ''' <remarks>Chỉ copy những cột ở vị trí liên tục nhau</remarks>

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal ColumnCount As Integer, ByVal sValue As String)
        Dim i, j As Integer
        Try
            If c1Grid.RowCount < 2 Then Exit Sub

            If ColumnCount = 1 Then ' Copy trong 1 cot
                CopyColumns(c1Grid, ColCopy, sValue, RowCopy)
            ElseIf ColumnCount > 1 Then ' Copy nhieu cot lien quan
                Dim Flag As DialogResult
                'Flag = D99C0008.MsgCopyColumn()
                Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                    c1Grid.UpdateData()
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse Val(c1Grid(i, ColCopy).ToString) = 0 Then
                            c1Grid(i, ColCopy) = sValue
                            While j < ColumnCount
                                c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                                j += 1
                            End While
                        End If
                    Next
                ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy hết
                    c1Grid.UpdateData()
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        c1Grid(i, ColCopy) = sValue
                        While j < ColumnCount
                            c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
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


    'Khi nào chuẩn hóa theo người dùng đơn vị xong thì trở về hàm dùng chung


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1120
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 01/03/2007 04:44:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1120() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T1120"
        sSQL &= " Where "
        sSQL &= "TransferMethodID = " & SQLString(_TransferMethodID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1120s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 01/03/2007 04:45:42
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1120s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL = ""
            sSQL &= "Insert Into D13T1120("
            sSQL &= "TransferMethodID,PayCalID, Description,DescriptionU, DebitAccountID, "
            sSQL &= "CreditAccountID, DefaultDebitAccountID, DefaultCreditAccountID, Ana01ID, Ana02ID, "
            sSQL &= "Ana03ID, Ana04ID, Ana05ID, Ana06ID, Ana07ID, "
            sSQL &= "Ana08ID, Ana09ID, Ana10ID, ObjectTypeID, ObjectID, "
            sSQL &= "DefaultObjectTypeID, DefaultObjectID, CreditObjectTypeID, CreditObjectID, DefaultCreditObjectTypeID, "
            sSQL &= "DefaultCreditObjectID, Disabled, CreateUserID, CreateDate, "
            sSQL &= "LastModifyUserID, LastModifyDate"
            sSQL &= ") Values ("
            sSQL &= SQLString(_TransferMethodID) & COMMA 'TransferMethodID [KEY], varchar[20], NOT NULL
            sSQL &= SQLString(tdbg(i, COL_PayCalID)) & COMMA 'PayCalID [KEY], varchar[20], NOT NULL
            sSQL &= SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, False) & COMMA 'Description, varchar[250], NULL
            sSQL &= SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, True) & COMMA 'Description, varchar[250], NULL
            sSQL &= SQLString(tdbg(i, COL_DebitAccountID)) & COMMA 'DebitAccountID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_CreditAccountID)) & COMMA 'CreditAccountID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_DefaultDebitAccountID)) & COMMA 'DefaultDebitAccountID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_DefaultCreditAccountID)) & COMMA 'DefaultCreditAccountID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_Ana01ID)) & COMMA 'Ana01ID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_Ana02ID)) & COMMA 'Ana02ID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_Ana03ID)) & COMMA 'Ana03ID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_Ana04ID)) & COMMA 'Ana04ID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_Ana05ID)) & COMMA 'Ana05ID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_Ana06ID)) & COMMA 'Ana06ID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_Ana07ID)) & COMMA 'Ana07ID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_Ana08ID)) & COMMA 'Ana08ID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_Ana09ID)) & COMMA 'Ana09ID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_Ana10ID)) & COMMA 'Ana10ID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_ObjectTypeID)) & COMMA 'ObjectTypeID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_ObjectID)) & COMMA 'ObjectID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_DefaultObjectTypeID)) & COMMA 'DefaultObjectTypeID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_DefaultObjectID)) & COMMA 'DefaultObjectID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_CreditObjectTypeID)) & COMMA 'CreditObjectTypeID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_CreditObjectID)) & COMMA 'CreditObjectID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_DefaultCreditObjectTypeID)) & COMMA 'DefaultCreditObjectTypeID, varchar[20], NULL
            sSQL &= SQLString(tdbg(i, COL_DefaultCreditObjectID)) & COMMA 'DefaultCreditObjectID, varchar[20], NULL
            sSQL &= SQLNumber(0) & COMMA 'Disabled, tinyint, NULL
            sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
            sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
            sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
            sSQL &= "GetDate()" 'LastModifyDate, datetime, NULL
            sSQL &= ")"
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function
    
    Private Function AllowSave() As Boolean
        If tdbg.RowCount > 0 Then
            For i As Integer = 0 To tdbg.RowCount - 1
                If tdbg(i, COL_PayCalID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Thu_nhap"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_PayCalID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If tdbg(i, COL_DefaultDebitAccountID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("TK_no_mac_dinh"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_DefaultDebitAccountID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If tdbg(i, COL_DefaultCreditAccountID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("TK_co_mac_dinh"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_DefaultCreditAccountID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If

                If tdbg(i, COL_DefaultObjectTypeID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Loai_DT_mac_dinh"))
                    tdbg.SplitIndex = SPLIT1
                    ClickButton(Button.Debit)
                    tdbg.Col = COL_DefaultObjectTypeID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If tdbg(i, COL_DefaultObjectID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("DT_mac_dinh_"))
                    tdbg.SplitIndex = SPLIT1
                    ClickButton(Button.Debit)
                    tdbg.Col = COL_DefaultObjectID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If

                If tdbg(i, COL_DefaultCreditObjectTypeID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Loai_DT_mac_dinh"))
                    tdbg.SplitIndex = SPLIT1
                    ClickButton(Button.Credit)
                    tdbg.Col = COL_DefaultCreditObjectTypeID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If tdbg(i, COL_DefaultCreditObjectID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("DT_mac_dinh_"))
                    tdbg.SplitIndex = SPLIT1
                    ClickButton(Button.Credit)
                    tdbg.Col = COL_DefaultCreditObjectID
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            Next
            Dim j As Integer = 0

            For i As Integer = 0 To tdbg.RowCount - 2
                j = i + 1
                If tdbg(i, COL_PayCalID).ToString <> "" And tdbg(j, COL_PayCalID).ToString <> "" Then
                    If tdbg(j, COL_PayCalID).ToString = tdbg(i, COL_PayCalID).ToString Then
                        D99C0008.MsgL3(rL3("Ma_thu_nhap_nay_da_duoc_dung_Vui_long_chon_ma_khac"))
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_PayCalID
                        tdbg.Bookmark = j
                        tdbg.Focus()
                        Return False
                    End If
                End If
            Next
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        btnSave.Enabled = False
        btnClose.Enabled = False
      
        sSQL = SQLDeleteD13T1120() & vbCrLf
        sSQL &= SQLInsertD13T1120s() & vbCrLf
       
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            'Lưu lại vết Audit
            Dim sDesc3 As String = "0"
            If optDetail.Checked = False Then sDesc3 = "1"
            Lemon3.D91.RunAuditLog("13", "TransferMethodDe", "02", txtTransferMethodID.Text, txtTransferMethodName.Text, sDesc3, "", "")
            'If CheckAudit("TransferMethodDe") Then
            '    If optDetail.Checked Then
            '        sSQL = SQLStoreD91P9106("TransferMethodDe", "13", "02", txtTransferMethodID.Text, txtTransferMethodName.Text, "0", "", "")
            '    Else
            '        sSQL = SQLStoreD91P9106("TransferMethodDe", "13", "02", txtTransferMethodID.Text, txtTransferMethodName.Text, "1", "", "")
            '    End If
            '    ExecuteSQLNoTransaction(sSQL)
            'End If
            btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If

    End Sub

    Private Sub btnHotKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHotKey.Click
        Dim f As New D13F7777
        With f
            .CallShowForm(Me.Name)
            .ShowDialog()
        End With
    End Sub
    Public Sub CopyColumn(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String)
        Dim sValue1 As String = ""
        Dim Flag As DialogResult
        Flag = D99C0008.MsgCopyColumn()
        If ColCopy = COL_PayCalID Then
            sValue1 = c1Grid.Columns(COL_Description).Text
        ElseIf ColCopy = COL_ObjectTypeID Then
            sValue1 = c1Grid.Columns(COL_ObjectID).Text
        ElseIf ColCopy = COL_DefaultObjectTypeID Then
            sValue1 = c1Grid.Columns(COL_DefaultObjectID).Text
        ElseIf ColCopy = COL_CreditObjectTypeID Then
            sValue1 = c1Grid.Columns(COL_CreditObjectID).Text
        ElseIf ColCopy = COL_DefaultCreditObjectTypeID Then
            sValue1 = c1Grid.Columns(COL_DefaultCreditObjectID).Text
        End If

        If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

            For i As Integer = 0 To c1Grid.RowCount - 1
                If c1Grid(i, ColCopy).ToString = "" Then
                    c1Grid(i, ColCopy) = sValue
                    If ColCopy = COL_PayCalID Then
                        c1Grid(i, COL_Description) = sValue1
                    ElseIf ColCopy = COL_ObjectTypeID Then
                        c1Grid(i, COL_ObjectID) = sValue1
                    ElseIf ColCopy = COL_DefaultObjectTypeID Then
                        c1Grid(i, COL_DefaultObjectID) = sValue1
                    ElseIf ColCopy = COL_CreditObjectTypeID Then
                        c1Grid(i, COL_CreditObjectID) = sValue1
                    ElseIf ColCopy = COL_DefaultCreditObjectTypeID Then
                        c1Grid(i, COL_DefaultCreditObjectID) = sValue1
                    End If
                End If
            Next
        ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy nhung dong con trong ' Copy het

            For i As Integer = 0 To c1Grid.RowCount - 1
                c1Grid(i, ColCopy) = sValue
                If ColCopy = COL_PayCalID Then
                    c1Grid(i, COL_Description) = sValue1
                ElseIf ColCopy = COL_ObjectTypeID Then
                    c1Grid(i, COL_ObjectID) = sValue1
                ElseIf ColCopy = COL_DefaultObjectTypeID Then
                    c1Grid(i, COL_DefaultObjectID) = sValue1
                ElseIf ColCopy = COL_CreditObjectTypeID Then
                    c1Grid(i, COL_CreditObjectID) = sValue1
                ElseIf ColCopy = COL_DefaultCreditObjectTypeID Then
                    c1Grid(i, COL_DefaultCreditObjectID) = sValue1
                End If
            Next
            c1Grid(0, ColCopy) = sValue
            If ColCopy = COL_PayCalID Then
                c1Grid(0, COL_Description) = sValue1
            ElseIf ColCopy = COL_ObjectTypeID Then
                c1Grid(0, COL_ObjectID) = sValue1
            ElseIf ColCopy = COL_DefaultObjectTypeID Then
                c1Grid(0, COL_DefaultObjectID) = sValue1
            ElseIf ColCopy = COL_CreditObjectTypeID Then
                c1Grid(0, COL_CreditObjectID) = sValue1
            ElseIf ColCopy = COL_DefaultCreditObjectTypeID Then
                c1Grid(0, COL_DefaultCreditObjectID) = sValue1
            End If
        Else
            Exit Sub
        End If
    End Sub
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.F7 Then
            HotKeysF7(tdbg)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            tdbg_HeadClick(sender, Nothing)
        ElseIf e.Shift And (e.KeyCode = Keys.Insert) Then
            HotKeyShiftInsert(tdbg, 0, COL_Orders, tdbg.Columns.Count)
        ElseIf e.KeyCode = Keys.F4 Then
            For i As Integer = tdbg.Row To tdbg.RowCount - 1
                If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                    tdbg(i, tdbg.Col) = ""
                    tdbg.Focus()
                    If tdbg.Col = COL_PayCalID Then
                        tdbg(i, COL_Description) = ""
                    ElseIf tdbg.Col = COL_ObjectTypeID Then
                        tdbg(i, COL_ObjectID) = ""
                    ElseIf tdbg.Col = COL_DefaultObjectTypeID Then
                        tdbg(i, COL_DefaultObjectID) = ""
                    ElseIf tdbg.Col = COL_CreditObjectTypeID Then
                        tdbg(i, COL_CreditObjectID) = ""
                    ElseIf tdbg.Col = COL_DefaultCreditObjectTypeID Then
                        tdbg(i, COL_DefaultCreditObjectID) = ""
                    End If
                Else
                    D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                    Return
                End If
            Next
        ElseIf e.KeyCode = Keys.F9 Then
            If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked = False Then
                CopyColumnF9(tdbg, tdbg.Col, tdbg.Row, tdbg.Columns(tdbg.Col).Text)
            Else
                D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                Return
            End If
        End If
        HotKeyDownGrid(e, tdbg, COL_Orders, 0, 0)
    End Sub
    Public Sub CopyColumnF9(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal sValue As String)
        Dim sValue1 As String = ""

        If ColCopy = COL_PayCalID Then
            sValue1 = c1Grid.Columns(COL_Description).Text
        ElseIf ColCopy = COL_ObjectTypeID Then
            sValue1 = c1Grid.Columns(COL_ObjectID).Text
        ElseIf ColCopy = COL_DefaultObjectTypeID Then
            sValue1 = c1Grid.Columns(COL_DefaultObjectID).Text
        ElseIf ColCopy = COL_CreditObjectTypeID Then
            sValue1 = c1Grid.Columns(COL_CreditObjectID).Text
        ElseIf ColCopy = COL_DefaultCreditObjectTypeID Then
            sValue1 = c1Grid.Columns(COL_DefaultCreditObjectID).Text
        End If
        For i As Integer = RowCopy To c1Grid.RowCount - 1
            c1Grid(i, ColCopy) = sValue
            If ColCopy = COL_PayCalID Then
                c1Grid(i, COL_Description) = sValue1
            ElseIf ColCopy = COL_ObjectTypeID Then
                c1Grid(i, COL_ObjectID) = sValue1
            ElseIf ColCopy = COL_DefaultObjectTypeID Then
                c1Grid(i, COL_DefaultObjectID) = sValue1
            ElseIf ColCopy = COL_CreditObjectTypeID Then
                c1Grid(i, COL_CreditObjectID) = sValue1
            ElseIf ColCopy = COL_DefaultCreditObjectTypeID Then
                c1Grid(i, COL_DefaultCreditObjectID) = sValue1
            End If
        Next

    End Sub
    Public Sub HotKeysF7(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim sValue As String = ""
        Dim iSplit As Integer = 0
        Try
            If c1Grid.RowCount < 1 Then Exit Sub
            If c1Grid.Col = COL_PayCalID Then
                sValue = c1Grid(c1Grid.Row - 1, COL_Description).ToString
            ElseIf c1Grid.Col = COL_ObjectTypeID Then
                sValue = c1Grid(c1Grid.Row - 1, COL_ObjectID).ToString
            ElseIf c1Grid.Col = COL_DefaultObjectTypeID Then
                sValue = c1Grid(c1Grid.Row - 1, COL_DefaultObjectID).ToString
            ElseIf c1Grid.Col = COL_CreditObjectTypeID Then
                sValue = c1Grid(c1Grid.Row - 1, COL_CreditObjectID).ToString
            ElseIf c1Grid.Col = COL_DefaultCreditObjectTypeID Then
                sValue = c1Grid(c1Grid.Row - 1, COL_DefaultCreditObjectID).ToString
            End If

            iSplit = c1Grid.SplitIndex
            If c1Grid.Splits(iSplit).DisplayColumns(c1Grid.Col).Locked = False Then
                If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" Then
                    c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                    If c1Grid.Col = COL_PayCalID Then
                        c1Grid.Columns(COL_Description).Text = sValue
                    ElseIf c1Grid.Col = COL_ObjectTypeID Then
                        c1Grid.Columns(COL_ObjectID).Text = sValue
                    ElseIf c1Grid.Col = COL_DefaultObjectTypeID Then
                        c1Grid.Columns(COL_DefaultObjectID).Text = sValue
                    ElseIf c1Grid.Col = COL_CreditObjectTypeID Then
                        c1Grid.Columns(COL_CreditObjectID).Text = sValue
                    ElseIf c1Grid.Col = COL_DefaultCreditObjectTypeID Then
                        c1Grid.Columns(COL_DefaultCreditObjectID).Text = sValue
                    End If
                End If
            Else
                D99C0008.MsgL3(MsgLockedColumn, L3MessageBoxIcon.Exclamation)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
            tdbg.Columns(COL_PayCalID).Text = "" ' Gán 1 cột bất kỳ ="" cho lưới
        End If
    End Sub
End Class