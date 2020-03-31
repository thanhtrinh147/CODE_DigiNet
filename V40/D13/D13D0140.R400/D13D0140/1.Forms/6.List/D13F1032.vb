'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:42:33 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:42:33 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Imports System.Text

Public Class D13F1032
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Private _employeeID As String = ""
    Dim dtAccount As DataTable
    Dim dtAna As DataTable
    Dim dtAnaCategory As DataTable
    Dim dtObjectID As DataTable


    Public Property EmployeeID() As String
        Get
            Return _employeeID
        End Get
        Set(ByVal value As String)
            If EmployeeID = value Then
                _employeeID = ""
                Return
            End If
            _employeeID = value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnSave.Enabled = True
                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                Case EnumFormState.FormView
                    btnSave.Enabled = False

            End Select
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcAccountID01

        sSQL = "Select AccountID," & IIf(geLanguage = EnumLanguage.Vietnamese, " AccountName" & UnicodeJoin(gbUnicode), "AccountName01" & UnicodeJoin(gbUnicode)).ToString & " As AccountName " & vbCrLf
        sSQL &= " From D90T0001  WITH (NOLOCK) Where Disabled=0 Order by AccountID "
        dtAccount = ReturnDataTable(sSQL)

        LoadDataSource(tdbcAccountID01, dtAccount, gbUnicode)
        LoadDataSource(tdbcAccountID02, ReturnTableFilter(dtAccount, ""), gbUnicode)
        LoadDataSource(tdbcAccountID03, ReturnTableFilter(dtAccount, ""), gbUnicode)
        LoadDataSource(tdbcAccountID04, ReturnTableFilter(dtAccount, ""), gbUnicode)
        LoadDataSource(tdbcAccountID05, ReturnTableFilter(dtAccount, ""), gbUnicode)
        LoadDataSource(tdbcAccountID06, ReturnTableFilter(dtAccount, ""), gbUnicode)
        LoadDataSource(tdbcAccountID07, ReturnTableFilter(dtAccount, ""), gbUnicode)
        LoadDataSource(tdbcAccountID08, ReturnTableFilter(dtAccount, ""), gbUnicode)
        LoadDataSource(tdbcAccountID09, ReturnTableFilter(dtAccount, ""), gbUnicode)
        LoadDataSource(tdbcAccountID10, ReturnTableFilter(dtAccount, ""), gbUnicode)

        With dtAnaCategory
            If .Rows.Count = 0 Then Exit Sub

            'Load tdbcAnaID
            sSQL = "Select AnaID, AnaName" & UnicodeJoin(gbUnicode) & " as AnaName , AnaCategoryID From D91T0051  WITH (NOLOCK) Where Disabled = 0 "
            dtAna = ReturnDataTable(sSQL)

            LoadDataSource(tdbcAnaID01, ReturnTableFilter(dtAna, " AnaCategoryID = " & SQLString(.Rows(0).Item("AnaCategoryID").ToString)), gbUnicode)
            LoadDataSource(tdbcAnaID02, ReturnTableFilter(dtAna, " AnaCategoryID = " & SQLString(.Rows(1).Item("AnaCategoryID").ToString)), gbUnicode)
            LoadDataSource(tdbcAnaID03, ReturnTableFilter(dtAna, " AnaCategoryID = " & SQLString(.Rows(2).Item("AnaCategoryID").ToString)), gbUnicode)
            LoadDataSource(tdbcAnaID04, ReturnTableFilter(dtAna, " AnaCategoryID = " & SQLString(.Rows(3).Item("AnaCategoryID").ToString)), gbUnicode)
            LoadDataSource(tdbcAnaID05, ReturnTableFilter(dtAna, " AnaCategoryID = " & SQLString(.Rows(4).Item("AnaCategoryID").ToString)), gbUnicode)
            LoadDataSource(tdbcAnaID06, ReturnTableFilter(dtAna, " AnaCategoryID = " & SQLString(.Rows(5).Item("AnaCategoryID").ToString)), gbUnicode)
            LoadDataSource(tdbcAnaID07, ReturnTableFilter(dtAna, " AnaCategoryID = " & SQLString(.Rows(6).Item("AnaCategoryID").ToString)), gbUnicode)
            LoadDataSource(tdbcAnaID08, ReturnTableFilter(dtAna, " AnaCategoryID = " & SQLString(.Rows(7).Item("AnaCategoryID").ToString)), gbUnicode)
            LoadDataSource(tdbcAnaID09, ReturnTableFilter(dtAna, " AnaCategoryID = " & SQLString(.Rows(8).Item("AnaCategoryID").ToString)), gbUnicode)
            LoadDataSource(tdbcAnaID10, ReturnTableFilter(dtAna, " AnaCategoryID = " & SQLString(.Rows(9).Item("AnaCategoryID").ToString)), gbUnicode)
        End With

        'Load tdbcObjectTypeID
        sSQL = "Select ObjectTypeID, ObjectTypeName" & UnicodeJoin(gbUnicode) & " as ObjectTypeName From D91T0005  WITH (NOLOCK) Order By ObjectTypeID "
        LoadDataSource(tdbcObjectTypeID, sSQL, gbUnicode)
        'Load tdbcObjectID
        sSQL = "Select ObjectID, ObjectName" & UnicodeJoin(gbUnicode) & " as ObjectName, ObjectTypeID From Object  WITH (NOLOCK) Where Disabled=0 " & vbCrLf
        sSQL &= "Order by ObjectID"
        dtObjectID = ReturnDataTable(sSQL)
        LoadtdbcObjectID("-1")
    End Sub

    Private Sub LoadtdbcObjectID(ByVal ID As String)
        LoadDataSource(tdbcObjectID, ReturnTableFilter(dtObjectID, " ObjectTypeID = " & SQLString(ID)), gbUnicode)
    End Sub

    Private Sub D13F1032_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            tdbcAccountID01.Focus()
        ElseIf e.Control And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            tdbcAnaID01.Focus()
        ElseIf e.Control And (e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3) Then
            tdbcObjectTypeID.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        End If
    End Sub

    Private Sub D13F1032_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        dtAnaCategory = TableAnaCategoryShort()
        GetAccountShort()
        GetAnaCategoryShort()
        LoadTDBCombo()
        LoadMaster()
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Thong_so_chuyen_but_toan_-_D13F1032") & UnicodeCaption(gbUnicode) 'Th¤ng sç chuyÓn bòt toÀn - D13F1032
        '================================================================ 
        lblObjectTypeID.Text = rl3("Loai_doi_tuong") 'Loại đối tượng
        lblObjectID.Text = rl3("Doi_tuong") 'Đối tượng
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        grp1.Text = "1. " & rl3("Ma_tai_khoan") 'Mã tài khoản
        grp2.Text = "2. " & rl3("Ma_phan_tich") 'Mã phân tích
        grp3.Text = "3. " & rl3("Doi_tuong") 'Đối tượng
        '================================================================ 
        tdbcAccountID10.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcAccountID10.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAccountID09.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcAccountID09.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAccountID08.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcAccountID08.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAccountID07.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcAccountID07.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAccountID06.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcAccountID06.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAccountID05.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcAccountID05.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAccountID04.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcAccountID04.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAccountID03.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcAccountID03.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAccountID02.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcAccountID02.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAccountID01.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcAccountID01.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAnaID10.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcAnaID10.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcAnaID09.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcAnaID09.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcAnaID08.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcAnaID08.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcAnaID07.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcAnaID07.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcAnaID06.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcAnaID06.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcAnaID05.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcAnaID05.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcAnaID04.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcAnaID04.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcAnaID03.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcAnaID03.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcAnaID02.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcAnaID02.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcAnaID01.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbcAnaID01.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbcObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbcObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        tdbcObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbcObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
    End Sub


#Region "Events tdbcObjectTypeID"

    Private Sub tdbcObjectTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.Close
        If tdbcObjectTypeID.FindStringExact(tdbcObjectTypeID.Text) = -1 Then tdbcObjectTypeID.Text = ""
    End Sub

    Private Sub tdbcObjectTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcObjectTypeID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcObjectTypeID.Text = ""
    End Sub
#End Region

    Private Sub tdbcObjectTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.SelectedValueChanged
        LoadtdbcObjectID(tdbcObjectTypeID.Text)
    End Sub

    Private Function SQLGetAccountShort() As String
        Dim sSQL As String = ""
        sSQL &= "Select Code, Short" & UnicodeJoin(gbUnicode) & " AccountShort, Disabled From D13T9000  WITH (NOLOCK) Where Type='PMACC' Order by Code "
        Return sSQL
    End Function

    Private Sub GetAccountShort()
        Dim dt As DataTable = ReturnDataTable(SQLGetAccountShort())
        If dt.Rows.Count = 0 Then Exit Sub

        lblAccountShort01.Text = dt.Rows(0).Item("AccountShort").ToString
        lblAccountShort01.Font = FontUnicode(gbUnicode)

        lblAccountShort02.Text = dt.Rows(1).Item("AccountShort").ToString
        lblAccountShort02.Font = FontUnicode(gbUnicode)

        lblAccountShort03.Text = dt.Rows(2).Item("AccountShort").ToString
        lblAccountShort03.Font = FontUnicode(gbUnicode)

        lblAccountShort04.Text = dt.Rows(3).Item("AccountShort").ToString
        lblAccountShort04.Font = FontUnicode(gbUnicode)

        lblAccountShort05.Text = dt.Rows(4).Item("AccountShort").ToString
        lblAccountShort05.Font = FontUnicode(gbUnicode)

        lblAccountShort06.Text = dt.Rows(5).Item("AccountShort").ToString
        lblAccountShort06.Font = FontUnicode(gbUnicode)

        lblAccountShort07.Text = dt.Rows(6).Item("AccountShort").ToString
        lblAccountShort07.Font = FontUnicode(gbUnicode)

        lblAccountShort08.Text = dt.Rows(7).Item("AccountShort").ToString
        lblAccountShort08.Font = FontUnicode(gbUnicode)

        lblAccountShort09.Text = dt.Rows(8).Item("AccountShort").ToString
        lblAccountShort09.Font = FontUnicode(gbUnicode)

        lblAccountShort10.Text = dt.Rows(9).Item("AccountShort").ToString
        lblAccountShort10.Font = FontUnicode(gbUnicode)

        For i As Integer = 0 To dt.Rows.Count - 1
            If Convert.ToInt16(dt.Rows(i).Item("Disabled")) = 1 Then
                Dim sCode As String
                sCode = dt.Rows(i).Item("Code").ToString
                Select Case sCode
                    Case "ZA01"
                        tdbcAccountID01.Enabled = False
                    Case "ZA02"
                        tdbcAccountID02.Enabled = False
                    Case "ZA03"
                        tdbcAccountID03.Enabled = False
                    Case "ZA04"
                        tdbcAccountID04.Enabled = False
                    Case "ZA05"
                        tdbcAccountID05.Enabled = False
                    Case "ZA06"
                        tdbcAccountID06.Enabled = False
                    Case "ZA07"
                        tdbcAccountID07.Enabled = False
                    Case "ZA08"
                        tdbcAccountID08.Enabled = False
                    Case "ZA09"
                        tdbcAccountID09.Enabled = False
                    Case "ZA10"
                        tdbcAccountID10.Enabled = False
                End Select
            End If
        Next
    End Sub

    Private Function TableAnaCategoryShort() As DataTable
        Dim sSQL As String = ""
        sSQL &= "Select AnaCategoryID, AnaCategoryShort" & UnicodeJoin(gbUnicode) & " as AnaCategoryShort, AnaCategoryStatus " & vbCrLf
        sSQL &= " From D91T0050  WITH (NOLOCK) Where AnaTypeID = 'K' And System = 1  Order By AnaCategoryID "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Return dt
    End Function

    Private Sub GetAnaCategoryShort()
        If dtAnaCategory.Rows.Count = 0 Then Exit Sub
        With dtAnaCategory
            lblAnaCategoryShort01.Text = .Rows(0).Item("AnaCategoryShort").ToString
            lblAnaCategoryShort02.Text = .Rows(1).Item("AnaCategoryShort").ToString
            lblAnaCategoryShort03.Text = .Rows(2).Item("AnaCategoryShort").ToString
            lblAnaCategoryShort04.Text = .Rows(3).Item("AnaCategoryShort").ToString
            lblAnaCategoryShort05.Text = .Rows(4).Item("AnaCategoryShort").ToString
            lblAnaCategoryShort06.Text = .Rows(5).Item("AnaCategoryShort").ToString
            lblAnaCategoryShort07.Text = .Rows(6).Item("AnaCategoryShort").ToString
            lblAnaCategoryShort08.Text = .Rows(7).Item("AnaCategoryShort").ToString
            lblAnaCategoryShort09.Text = .Rows(8).Item("AnaCategoryShort").ToString
            lblAnaCategoryShort10.Text = .Rows(9).Item("AnaCategoryShort").ToString

            lblAnaCategoryShort01.Font = FontUnicode(gbUnicode)
            lblAnaCategoryShort02.Font = FontUnicode(gbUnicode)
            lblAnaCategoryShort03.Font = FontUnicode(gbUnicode)
            lblAnaCategoryShort04.Font = FontUnicode(gbUnicode)
            lblAnaCategoryShort05.Font = FontUnicode(gbUnicode)
            lblAnaCategoryShort06.Font = FontUnicode(gbUnicode)
            lblAnaCategoryShort07.Font = FontUnicode(gbUnicode)
            lblAnaCategoryShort08.Font = FontUnicode(gbUnicode)
            lblAnaCategoryShort09.Font = FontUnicode(gbUnicode)
            lblAnaCategoryShort10.Font = FontUnicode(gbUnicode)

            For i As Integer = 0 To .Rows.Count - 1
                If Convert.ToInt16(.Rows(i).Item("AnaCategoryStatus")) = 0 Then
                    Dim sAnaCategoryID As String
                    sAnaCategoryID = .Rows(i).Item("AnaCategoryID").ToString
                    Select Case sAnaCategoryID
                        Case "K01"
                            tdbcAnaID01.Enabled = False
                        Case "K02"
                            tdbcAnaID02.Enabled = False
                        Case "K03"
                            tdbcAnaID03.Enabled = False
                        Case "K04"
                            tdbcAnaID04.Enabled = False
                        Case "K05"
                            tdbcAnaID05.Enabled = False
                        Case "K06"
                            tdbcAnaID06.Enabled = False
                        Case "K07"
                            tdbcAnaID07.Enabled = False
                        Case "K08"
                            tdbcAnaID08.Enabled = False
                        Case "K09"
                            tdbcAnaID09.Enabled = False
                        Case "K10"
                            tdbcAnaID10.Enabled = False
                    End Select
                End If
            Next
        End With

    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0201
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 06/02/2007 10:52:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0201() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T0201 Set "
        sSQL &= "PMAccount01ID = " & SQLString(tdbcAccountID01.Text) & COMMA 'varchar[20], NULL
        sSQL &= "PMAccount02ID = " & SQLString(tdbcAccountID02.Text) & COMMA 'varchar[20], NULL
        sSQL &= "PMAccount03ID = " & SQLString(tdbcAccountID03.Text) & COMMA 'varchar[20], NULL
        sSQL &= "PMAccount04ID = " & SQLString(tdbcAccountID04.Text) & COMMA 'varchar[20], NULL
        sSQL &= "PMAccount05ID = " & SQLString(tdbcAccountID05.Text) & COMMA 'varchar[20], NULL
        sSQL &= "PMAccount06ID = " & SQLString(tdbcAccountID06.Text) & COMMA 'varchar[20], NULL
        sSQL &= "PMAccount07ID = " & SQLString(tdbcAccountID07.Text) & COMMA 'varchar[20], NULL
        sSQL &= "PMAccount08ID = " & SQLString(tdbcAccountID08.Text) & COMMA 'varchar[20], NULL
        sSQL &= "PMAccount09ID = " & SQLString(tdbcAccountID09.Text) & COMMA 'varchar[20], NULL
        sSQL &= "PMAccount10ID = " & SQLString(tdbcAccountID10.Text) & COMMA 'varchar[20], NULL
        sSQL &= "Ana01ID = " & SQLString(tdbcAnaID01.Text) & COMMA 'varchar[20], NULL
        sSQL &= "Ana02ID = " & SQLString(tdbcAnaID02.Text) & COMMA 'varchar[20], NULL
        sSQL &= "Ana03ID = " & SQLString(tdbcAnaID03.Text) & COMMA 'varchar[20], NULL
        sSQL &= "Ana04ID = " & SQLString(tdbcAnaID04.Text) & COMMA 'varchar[20], NULL
        sSQL &= "Ana05ID = " & SQLString(tdbcAnaID05.Text) & COMMA 'varchar[20], NULL
        sSQL &= "Ana06ID = " & SQLString(tdbcAnaID06.Text) & COMMA 'varchar[20], NULL
        sSQL &= "Ana07ID = " & SQLString(tdbcAnaID07.Text) & COMMA 'varchar[20], NULL
        sSQL &= "Ana08ID = " & SQLString(tdbcAnaID08.Text) & COMMA 'varchar[20], NULL
        sSQL &= "Ana09ID = " & SQLString(tdbcAnaID09.Text) & COMMA 'varchar[20], NULL
        sSQL &= "Ana10ID = " & SQLString(tdbcAnaID10.Text) & COMMA 'varchar[20], NULL
        sSQL &= "ObjectTypeID = " & SQLString(tdbcObjectTypeID.Text) & COMMA 'varchar[20], NULL
        sSQL &= "ObjectID = " & SQLString(tdbcObjectID.Text)  'varchar[20], NULL
        sSQL &= " Where "
        sSQL &= "DivisionID = " & SQLString(gsDivisionID) & " And "
        sSQL &= "EmployeeID = " & SQLString(_employeeID)
        Return sSQL
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        sSQL &= SQLUpdateD13T0201()
        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnSave.Enabled = True
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub
    Private Function AllowSave() As Boolean
        If tdbcObjectTypeID.Text.Trim <> "" Then
            If tdbcObjectID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Doi_tuong"))
                tdbcObjectID.Focus()
                Return False
            End If
        End If
        Return True
    End Function

#Region "Events tdbcAnaID01"

    Private Sub tdbcAnaID01_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaID01.Close
        If tdbcAnaID01.FindStringExact(tdbcAnaID01.Text) = -1 Then tdbcAnaID01.Text = ""
    End Sub

    Private Sub tdbcAnaID01_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAnaID01.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAnaID01.Text = ""
    End Sub
#End Region

#Region "Events tdbcAnaID02"

    Private Sub tdbcAnaID02_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaID02.Close
        If tdbcAnaID02.FindStringExact(tdbcAnaID02.Text) = -1 Then tdbcAnaID02.Text = ""
    End Sub

    Private Sub tdbcAnaID02_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAnaID02.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAnaID02.Text = ""
    End Sub

#End Region

#Region "Events tdbcAnaID03"

    Private Sub tdbcAnaID03_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaID03.Close
        If tdbcAnaID03.FindStringExact(tdbcAnaID03.Text) = -1 Then tdbcAnaID03.Text = ""
    End Sub

    Private Sub tdbcAnaID03_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAnaID03.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAnaID03.Text = ""
    End Sub
#End Region

#Region "Events tdbcAnaID04"

    Private Sub tdbcAnaID04_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaID04.Close
        If tdbcAnaID04.FindStringExact(tdbcAnaID04.Text) = -1 Then tdbcAnaID04.Text = ""
    End Sub

    Private Sub tdbcAnaID04_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAnaID04.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAnaID04.Text = ""
    End Sub
#End Region

#Region "Events tdbcAnaID05"
    Private Sub tdbcAnaID05_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaID05.Close
        If tdbcAnaID05.FindStringExact(tdbcAnaID05.Text) = -1 Then tdbcAnaID05.Text = ""
    End Sub

    Private Sub tdbcAnaID05_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAnaID05.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAnaID05.Text = ""
    End Sub
#End Region

#Region "Events tdbcAnaID06"
    Private Sub tdbcAnaID06_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaID06.Close
        If tdbcAnaID06.FindStringExact(tdbcAnaID06.Text) = -1 Then tdbcAnaID06.Text = ""
    End Sub

    Private Sub tdbcAnaID06_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAnaID06.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAnaID06.Text = ""
    End Sub
#End Region

#Region "Events tdbcAnaID07"

    Private Sub tdbcAnaID07_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaID07.Close
        If tdbcAnaID07.FindStringExact(tdbcAnaID07.Text) = -1 Then tdbcAnaID07.Text = ""
    End Sub

    Private Sub tdbcAnaID07_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAnaID07.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAnaID07.Text = ""
    End Sub

#End Region

#Region "Events tdbcAnaID08"
    Private Sub tdbcAnaID08_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaID08.Close
        If tdbcAnaID08.FindStringExact(tdbcAnaID08.Text) = -1 Then tdbcAnaID08.Text = ""
    End Sub

    Private Sub tdbcAnaID08_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAnaID08.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAnaID08.Text = ""
    End Sub
#End Region

#Region "Events tdbcAnaID09"

    Private Sub tdbcAnaID09_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaID09.Close
        If tdbcAnaID09.FindStringExact(tdbcAnaID09.Text) = -1 Then tdbcAnaID09.Text = ""
    End Sub

    Private Sub tdbcAnaID09_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAnaID09.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAnaID09.Text = ""
    End Sub
#End Region

#Region "Events tdbcAnaID10"

    Private Sub tdbcAnaID10_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAnaID10.Close
        If tdbcAnaID10.FindStringExact(tdbcAnaID10.Text) = -1 Then tdbcAnaID10.Text = ""
    End Sub

    Private Sub tdbcAnaID10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAnaID10.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAnaID10.Text = ""
    End Sub
#End Region
    Private Sub LoadMaster()
        Dim sSQL As New StringBuilder(361)
        sSQL.Append("Select   PMAccount01ID,PMAccount02ID, PMAccount03ID,PMAccount04ID, " & vbCrLf)
        sSQL.Append("			PMAccount05ID, PMAccount06ID,PMAccount07ID,PMAccount08ID," & vbCrLf)
        sSQL.Append("			PMAccount09ID,PMAccount10ID, Ana01ID, Ana02ID, Ana03ID ," & vbCrLf)
        sSQL.Append("			Ana04ID ,Ana05ID ,Ana06ID , Ana07ID,Ana08ID, Ana09ID , " & vbCrLf)
        sSQL.Append("			Ana10ID , ObjectTypeID, ObjectID   " & vbCrLf)
        sSQL.Append("From 		D13T0201  WITH (NOLOCK) " & vbCrLf)
        sSQL.Append("Where  	DivisionID= " & SQLString(gsDivisionID) & vbCrLf)
        sSQL.Append("			And EmployeeID=" & SQLString(_employeeID))
        Dim dtMaster As DataTable = ReturnDataTable(sSQL.ToString)
        If dtMaster.Rows.Count < 1 Then Exit Sub
        With dtMaster.Rows(0)
            tdbcAccountID01.Text =.Item("PMAccount01ID").ToString()
            tdbcAccountID02.Text = .Item("PMAccount02ID").ToString()
            tdbcAccountID03.Text = .Item("PMAccount03ID").ToString()
            tdbcAccountID04.Text = .Item("PMAccount04ID").ToString()
            tdbcAccountID05.Text = .Item("PMAccount05ID").ToString()
            tdbcAccountID06.Text = .Item("PMAccount06ID").ToString()
            tdbcAccountID07.Text = .Item("PMAccount07ID").ToString()
            tdbcAccountID08.Text = .Item("PMAccount08ID").ToString()
            tdbcAccountID09.Text = .Item("PMAccount09ID").ToString()
            tdbcAccountID10.Text = .Item("PMAccount10ID").ToString()

            tdbcAnaID01.Text = .Item("Ana01ID").ToString
            tdbcAnaID02.Text = .Item("Ana02ID").ToString
            tdbcAnaID03.Text = .Item("Ana03ID").ToString
            tdbcAnaID04.Text = .Item("Ana04ID").ToString
            tdbcAnaID05.Text = .Item("Ana05ID").ToString
            tdbcAnaID06.Text = .Item("Ana06ID").ToString
            tdbcAnaID07.Text = .Item("Ana07ID").ToString
            tdbcAnaID08.Text = .Item("Ana08ID").ToString
            tdbcAnaID09.Text = .Item("Ana09ID").ToString
            tdbcAnaID10.Text = .Item("Ana10ID").ToString
            tdbcObjectTypeID.Text = .Item("ObjectTypeID").ToString
            tdbcObjectID.Text = .Item("ObjectID").ToString

        End With
    End Sub

End Class