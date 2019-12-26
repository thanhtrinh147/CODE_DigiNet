Public Class D45F2041

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _dtD45F2041 As DataTable
    Public ReadOnly Property dtD45F2041 As DataTable
        Get
            Return _dtD45F2041
        End Get
    End Property
    Private Sub D45F2041_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If dtProductAddID IsNot Nothing Then dtProductAddID.Dispose()
    End Sub
    
    Private Sub D45F2041_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral() 'Load System/ Option /... in DxxD9940
        LoadLanguage()
        SetBackColorObligatory()
        LoadTDBCombo()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub D45F2041_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
        End Select
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Ke_thua_tieu_tacF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'KÕ thôa tiÓu tÀc
        '================================================================ 
        lblCustomerID.Text = rl3("Khach_hang") 'Khách hàng
        lblStageID.Text = rl3("Cong_doan") 'Công đoạn
        lblProductAddID.Text = rl3("San_pham_gop") 'Sản phẩm gộp
        '================================================================ 
        btnInherit.Text = rl3("_Ke_thua") '&Kế thừa
        '================================================================ 
        tdbcProductAddID.Columns("ProductAddID").Caption = rl3("Ma") 'Mã
        tdbcProductAddID.Columns("ProductAddName").Caption = rl3("Ten") 'Tên
        tdbcStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbcStageID.Columns("StageName").Caption = rl3("Ten") 'Tên
        tdbcCustomerID.Columns("CustomerID").Caption = rl3("Ma") 'Mã
    End Sub
    Private Sub SetBackColorObligatory()
        tdbcProductAddID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCustomerID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcStageID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Dim dtProductAddID As DataTable
    Private Sub LoadTDBCombo()
        Dim dt As DataTable
        Dim sSQL As String = ""

        'Load tdbcProductAddID
        sSQL = SQLStoreD45P2051()
        dtProductAddID = ReturnDataTable(sSQL)

        'Load tdbcStageID
        sSQL = SQLStoreD45P1011()
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbcStageID, ReturnTableFilter(dt, "DisplayOrder=1"), gbUnicode)

        'Load tdbcCustomerID
        sSQL = SQLStoreD45P1002()
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbcCustomerID, ReturnTableFilter(dt, "DisplayOrder=1"), gbUnicode)

        dt.Dispose()
    End Sub
    Private Sub LoadTDBCProductAddID()
        'Load tdbcMProductAddID
        Dim dt As DataTable = ReturnTableFilter(dtProductAddID, "CustomerID =" & SQLString(ReturnValueC1Combo(tdbcCustomerID)) & " And StageID =" & SQLString(ReturnValueC1Combo(tdbcStageID)) & " And DisplayOrder=1", True)
        LoadDataSource(tdbcProductAddID, dt, gbUnicode)
    End Sub

#Region "Events tdbcProductAddID"
    Private Sub tdbcProductAddID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductAddID.LostFocus
        If tdbcProductAddID.FindStringExact(tdbcProductAddID.Text) = -1 Then tdbcProductAddID.Text = ""
    End Sub

#End Region

#Region "Events tdbcStageID"
    Private Sub tdbcStageID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStageID.LostFocus
        If tdbcStageID.FindStringExact(tdbcStageID.Text) = -1 Then tdbcStageID.Text = ""
    End Sub

#End Region

#Region "Events tdbcCustomerID"
    Private Sub tdbcCustomerID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCustomerID.LostFocus
        If tdbcCustomerID.FindStringExact(tdbcCustomerID.Text) = -1 Then tdbcCustomerID.Text = ""
    End Sub

#End Region
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCustomerID.Close, tdbcStageID.Close, tdbcProductAddID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub
    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCustomerID.Validated, tdbcStageID.Validated, tdbcProductAddID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        '************************
        If tdbc.Name = tdbcCustomerID.Name OrElse tdbc.Name = tdbcStageID.Name Then
            LoadTDBCProductAddID()
        End If
    End Sub
    Private Function AllowSave() As Boolean
        If tdbcCustomerID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblCustomerID.Text)
            tdbcCustomerID.Focus()
            Return False
        End If
        If tdbcStageID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblStageID.Text)
            tdbcStageID.Focus()
            Return False
        End If
        If tdbcProductAddID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblProductAddID.Text)
            tdbcProductAddID.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub btnInherit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInherit.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnInherit.Focus()
        If btnInherit.Focused = False Then Exit Sub
        '************************************
        If Not AllowSave() Then Exit Sub
        _bSaved = True
        _dtD45F2041 = ReturnDataTable(SQLStoreD45P2043.ToString)
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1002
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 03:57:32
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1002() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load khach hang" & vbCrLf)
        sSQL &= "Exec D45P1002 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(1) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1011
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 01:51:04
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1011() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load cong doan" & vbCrLf)
        sSQL &= "Exec D45P1011 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[2], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2051
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 09/03/2016 01:51:44
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2051() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load san pham gop" & vbCrLf)
        sSQL &= "Exec D45P2051 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[2], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2043
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 10/03/2016 11:37:22
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2043() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load lai luoi tieu tac" & vbCrlf)
        sSQL &= "Exec D45P2043 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcProductAddID)) & COMMA 'ProductAddID, varchar[50], NOT NULL
        sSQL &= SQLNumber(1) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function


End Class