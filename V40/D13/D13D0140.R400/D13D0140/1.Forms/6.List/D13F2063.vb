Public Class D13F2063
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
            LoadAna()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    LoadEdit()
            End Select
        End Set
    End Property



    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL = "Select IsAna01ID,IsAna02ID,IsAna03ID,IsAna04ID,IsAna05ID," & vbCrLf
        sSQL &= "IsAna06ID,IsAna07ID,IsAna08ID,IsAna09ID,IsAna10ID" & vbCrLf
        sSQL &= "From D13T1110  WITH (NOLOCK) Where TransferMethodID=" & SQLString(_TransferMethodID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If chkIsAna01ID.Enabled Then
                chkIsAna01ID.Checked = Convert.ToBoolean(dt.Rows(0).Item("IsAna01ID"))
            End If
            If chkIsAna02ID.Enabled Then
                chkIsAna02ID.Checked = Convert.ToBoolean(dt.Rows(0).Item("IsAna02ID"))
            End If
            If chkIsAna03ID.Enabled Then
                chkIsAna03ID.Checked = Convert.ToBoolean(dt.Rows(0).Item("IsAna03ID"))
            End If
            If chkIsAna04ID.Enabled Then
                chkIsAna04ID.Checked = Convert.ToBoolean(dt.Rows(0).Item("IsAna04ID"))
            End If
            If chkIsAna05ID.Enabled Then
                chkIsAna05ID.Checked = Convert.ToBoolean(dt.Rows(0).Item("IsAna05ID"))
            End If
            If chkIsAna06ID.Enabled Then
                chkIsAna06ID.Checked = Convert.ToBoolean(dt.Rows(0).Item("IsAna06ID"))
            End If
            If chkIsAna07ID.Enabled Then
                chkIsAna07ID.Checked = Convert.ToBoolean(dt.Rows(0).Item("IsAna07ID"))
            End If
            If chkIsAna08ID.Enabled Then
                chkIsAna08ID.Checked = Convert.ToBoolean(dt.Rows(0).Item("IsAna08ID"))
            End If
            If chkIsAna09ID.Enabled Then
                chkIsAna09ID.Checked = Convert.ToBoolean(dt.Rows(0).Item("IsAna09ID"))
            End If
            If chkIsAna10ID.Enabled Then
                chkIsAna10ID.Checked = Convert.ToBoolean(dt.Rows(0).Item("IsAna10ID"))
            End If
        End If
    End Sub

    Private Sub LoadEdit()
        LoadMaster()
    End Sub

    Private Sub LoadAna()
        Dim sSQL As String = ""
        sSQL &= "Select AnaCategoryID,AnaCategoryShort,AnaCategoryShortU,AnaCategoryStatus" & vbCrLf
        sSQL &= "From D91T0050  WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where AnaTypeID='K' and System=1" & vbCrLf
        sSQL &= "Order by AnaCategoryID"
        Dim dt As DataTable = ReturnDataTable(sSQL)

        For i As Integer = 0 To dt.Rows.Count - 1
            Select Case i
                Case 0
                    chkIsAna01ID.Text = dt.Rows(i).Item("AnaCategoryShort" & UnicodeJoin(gbUnicode)).ToString
                    If dt.Rows(i).Item("AnaCategoryStatus").ToString = "1" Then
                        chkIsAna01ID.Enabled = True
                    End If
                Case 1
                    chkIsAna02ID.Text = dt.Rows(i).Item("AnaCategoryShort" & UnicodeJoin(gbUnicode)).ToString
                    If dt.Rows(i).Item("AnaCategoryStatus").ToString = "1" Then
                        chkIsAna02ID.Enabled = True
                    End If
                Case 2
                    chkIsAna03ID.Text = dt.Rows(i).Item("AnaCategoryShort" & UnicodeJoin(gbUnicode)).ToString
                    If dt.Rows(i).Item("AnaCategoryStatus").ToString = "1" Then
                        chkIsAna03ID.Enabled = True
                    End If
                Case 3
                    chkIsAna04ID.Text = dt.Rows(i).Item("AnaCategoryShort" & UnicodeJoin(gbUnicode)).ToString
                    If dt.Rows(i).Item("AnaCategoryStatus").ToString = "1" Then
                        chkIsAna04ID.Enabled = True
                    End If
                Case 4
                    chkIsAna05ID.Text = dt.Rows(i).Item("AnaCategoryShort" & UnicodeJoin(gbUnicode)).ToString
                    If dt.Rows(i).Item("AnaCategoryStatus").ToString = "1" Then
                        chkIsAna05ID.Enabled = True
                    End If
                Case 5
                    chkIsAna06ID.Text = dt.Rows(i).Item("AnaCategoryShort" & UnicodeJoin(gbUnicode)).ToString
                    If dt.Rows(i).Item("AnaCategoryStatus").ToString = "1" Then
                        chkIsAna06ID.Enabled = True
                    End If
                Case 6
                    chkIsAna07ID.Text = dt.Rows(i).Item("AnaCategoryShort" & UnicodeJoin(gbUnicode)).ToString
                    If dt.Rows(i).Item("AnaCategoryStatus").ToString = "1" Then
                        chkIsAna07ID.Enabled = True
                    End If
                Case 7
                    chkIsAna08ID.Text = dt.Rows(i).Item("AnaCategoryShort" & UnicodeJoin(gbUnicode)).ToString
                    If dt.Rows(i).Item("AnaCategoryStatus").ToString = "1" Then
                        chkIsAna08ID.Enabled = True
                    End If
                Case 8
                    chkIsAna09ID.Text = dt.Rows(i).Item("AnaCategoryShort" & UnicodeJoin(gbUnicode)).ToString
                    If dt.Rows(i).Item("AnaCategoryStatus").ToString = "1" Then
                        chkIsAna09ID.Enabled = True
                    End If
                Case 9
                    chkIsAna10ID.Text = dt.Rows(i).Item("AnaCategoryShort" & UnicodeJoin(gbUnicode)).ToString
                    If dt.Rows(i).Item("AnaCategoryStatus").ToString = "1" Then
                        chkIsAna10ID.Enabled = True
                    End If
            End Select
        Next
    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T1110
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 05/03/2007 01:30:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T1110() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T1110 Set "
        sSQL &= "TransferMode = " & SQLNumber(1) & COMMA 'int, NULL
        sSQL &= "IsAna01ID = " & SQLNumber(chkIsAna01ID.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsAna02ID = " & SQLNumber(chkIsAna02ID.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsAna03ID = " & SQLNumber(chkIsAna03ID.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsAna04ID = " & SQLNumber(chkIsAna04ID.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsAna05ID = " & SQLNumber(chkIsAna05ID.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsAna06ID = " & SQLNumber(chkIsAna06ID.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsAna07ID = " & SQLNumber(chkIsAna07ID.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsAna08ID = " & SQLNumber(chkIsAna08ID.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsAna09ID = " & SQLNumber(chkIsAna09ID.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "IsAna10ID = " & SQLNumber(chkIsAna10ID.Checked) & COMMA 'tinyint, NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" 'datetime, NULL
        sSQL &= " Where "
        sSQL &= "TransferMethodID = " & SQLString(_TransferMethodID)
        Return sSQL
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSQL As String = ""
        btnSave.Enabled = False
        btnClose.Enabled = False
        Select Case _FormState
            Case EnumFormState.FormAdd

            Case EnumFormState.FormEdit
                sSQL = SQLUpdateD13T1110()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
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

#Region "D13F2063_KeyDown"
    Private Sub D13F2063_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    chkIsDebitAccountID.Focus()
                Case Keys.D2, Keys.NumPad2
                    chkIsAna01ID.Focus()
            End Select
        End If
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
    End Sub
#End Region

    Private Sub D13F2063_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_chuyen_tong_hop_-_D13F2063") & UnicodeCaption(gbUnicode) 'Chi tiÕt chuyÓn tång híp - D13F2063
        '================================================================ 
        lblGroup.Text = rl3("Nguyen_tac_nhom_cac_but_toan") 'Nguyên tắc nhóm các bút toán
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkIsObjectID.Text = rl3("Doi_tuong") 'Đối tượng
        chkIsObjectTypeID.Text = rl3("Loai_doi_tuong") 'Loại đối tượng
        chkIsCreditAccountID.Text = rl3("Tai_khoan_no") 'Tài khoản nợ
        chkIsDebitAccountID.Text = rl3("Tai_khoan_co") 'Tài khoản có
        'chkIsAna10ID.Text = rl3("Khoan_muc_1") 'Khoản mục 1
        'chkIsAna09ID.Text = rl3("Khoan_muc_1") 'Khoản mục 1
        'chkIsAna08ID.Text = rl3("Khoan_muc_1") 'Khoản mục 1
        'chkIsAna07ID.Text = rl3("Khoan_muc_1") 'Khoản mục 1
        'chkIsAna06ID.Text = rl3("Khoan_muc_1") 'Khoản mục 1
        'chkIsAna05ID.Text = rl3("Khoan_muc_1") 'Khoản mục 1
        'chkIsAna04ID.Text = rl3("Khoan_muc_1") 'Khoản mục 1
        'chkIsAna03ID.Text = rl3("Khoan_muc_1") 'Khoản mục 1
        'chkIsAna02ID.Text = rl3("Khoan_muc_1") 'Khoản mục 1
        'chkIsAna01ID.Text = rl3("Khoan_muc_1") 'Khoản mục 1
        '================================================================ 
        GroupBox1.Text = "1. " & rl3("Theo_tai_khoan_doi_tuong") 'Theo tài khoản, đối tượng
        GroupBox2.Text = "2. " & rl3("Theo_khoan_muc") 'Theo khoản mục
    End Sub


End Class