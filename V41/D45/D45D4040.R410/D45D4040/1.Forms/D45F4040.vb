Public Class D45F4040

    Dim dtProduct As DataTable
    Dim oFilterCombo As Lemon3.Controls.FilterCombo
    Dim dtBlockID As DataTable
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Bao_cao_can_doi_luong_san_pham") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Bªo cªo c¡n ¢çi l§¥ng s¶n phÌm
        '================================================================ 
        lbl4.Text = "4. " & rL3("Tieu_thuc_loc") 'Tiêu thức lọc
        lbl3.Text = "3. " & rL3("Thoi_gian") 'Thời gian
        lbl2.Text = "2. " & rL3("Mau_bao_cao") 'Mẫu báo cáo
        lbl1.Text = "1. " & rL3("Don_vi") 'Đơn vị
        lblDivisionID.Text = rL3("Don_vi") 'Đơn vị
        lblReportID.Text = rL3("Mau_bao_cao") 'Mẫu báo cáo
        lblPeriod.Text = rL3("Ky") 'Kỳ
        lblCustomerID.Text = rL3("Khach_hang") 'Khách hàng
        lblStageID.Text = rL3("Cong_doan") 'Công đoạn
        lblProductAddID.Text = rL3("San_pham_gop") 'Sản phẩm gộp
        '================================================================ 
        btnPrint.Text = rL3("_In") '&In
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        '================================================================ 
        tdbcProductAddID.Columns("ProductAddID").Caption = rL3("Ma") 'Mã
        tdbcProductAddID.Columns("ProductAddName").Caption = rL3("Ten") 'Tên
        tdbcStageID.Columns("StageID").Caption = rL3("Ma") 'Tên
        tdbcStageID.Columns("StageName").Caption = rL3("Ten") 'Mã
        tdbcCustomerID.Columns("CustomerID").Caption = rL3("Ma") 'Mã
        tdbcCustomerID.Columns("CustomerName").Caption = rL3("Ten") 'Tên
        tdbcPeriod.Columns("Period").Caption = rL3("Ky") 'Kỳ
        tdbcReportID.Columns("ReportID").Caption = rL3("Ma") 'Mã
        tdbcReportID.Columns("Title").Caption = rL3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên

        '================================================================ 
        lblBlockID.Text = rL3("Khoi") 'Khối
        '================================================================ 
        '================================================================ 
        chkIsOutsideStage.Text = rL3("Nhan_vien_tu_phong_ban_khac")  'Nhân viên từ phòng ban khác

        '================================================================ 
        tdbcBlockID.Columns("BlockID").Caption = rL3("Ma") 'Mã
        tdbcBlockID.Columns("BlockName").Caption = rL3("Ten") 'Tên


    End Sub

    Private Sub D45F4040_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral() 'Load System/ Option /... in DxxD9940
        oFilterCombo = New Lemon3.Controls.FilterCombo
        oFilterCombo.CheckD91 = True
        oFilterCombo.UseFilterCombo(tdbcCustomerID, tdbcStageID, tdbcProductAddID, tdbcBlockID)
        LoadTDBCCombo()
        LoadLanguage()
        SetBackColorObligatory()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D45F4040_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt Then
        ElseIf e.Control Then
        Else
            Select Case e.KeyCode
                Case Keys.Enter
                    UseEnterAsTab(Me, True)
            End Select
        End If
    End Sub

    Private Sub LoadTDBCCombo()
        Dim sSQL As String = ""

        dtBlockID = ReturnTableBlockID(, True, gbUnicode)
        dtProduct = ReturnDataTable(SQLStoreD45P2051)
        LoadCboDivisionIDReport(tdbcDivisionID, "D09", True, gbUnicode)
        If tdbcDivisionID IsNot Nothing Then tdbcDivisionID.SelectedValue = gsDivisionID


        sSQL = " -- Do nguon Combo Mau bao cao" & vbCrLf
        sSQL &= " SELECT		T1.ReportTypeID, T2.ReportID, T2.TitleU AS Title, T2.FileExt"
        sSQL &= " FROM		D89T0010 T1 "
        sSQL &= " INNER JOIN	D89T1000 T2 "
        sSQL &= " 	ON		T1.ReportTypeID = T2.ReportTypeID "
        sSQL &= "  WHERE		T1.ModuleID = '45' "
        sSQL &= " 	AND 	T1.ReportTypeID IN ('D45F4030','D45F4040','D45F4050','D45F4060','D45F4070','D45F4080')"
        sSQL &= " ORDER BY	T1.ReportTypeID, T2.ReportID "

        LoadDataSource(tdbcReportID, sSQL, gbUnicode)





                'LoadCboDivisionIDReportD09(tdbcPeriod, D45, gbUnicode,)
                'LoadCboPeriodReport(tdbcPeriod, "D09", ReturnValueC1Combo(tdbcDivisionID))

                'If tdbcPeriod IsNot Nothing Then tdbcPeriod.SelectedText = giTranMonth.ToString("00") & "/" & giTranYear.ToString

        LoadTDBCCustomerID(1)

        LoadTDBCStageID(1)


        If tdbcCustomerID IsNot Nothing Then tdbcCustomerID.SelectedIndex = 0
        If tdbcStageID IsNot Nothing Then tdbcStageID.SelectedIndex = 0
        LoadTDBCProductionAdd("%", "%")
        If tdbcProductAddID IsNot Nothing Then tdbcProductAddID.SelectedIndex = 0
    End Sub

    Private Sub LoadTDBCStageID(Optional iMode As Integer = 0)
        Dim dtStageID As DataTable = ReturnDataTable(SQLStoreD45P1011)
        If ReturnValueC1Combo(tdbcBlockID) = "%" Then
            If iMode <> 0 Then

                LoadDataSource(tdbcStageID, dtStageID, gbUnicode)
            Else
                LoadDataSource(tdbcStageID, ReturnTableFilter(dtStageID, "StageID <>'%'", True), gbUnicode)
            End If
        Else
            If iMode <> 0 Then

                LoadDataSource(tdbcStageID, ReturnTableFilter(dtStageID, "StageID ='%' or BlockID=" & SQLString(ReturnValueC1Combo(tdbcBlockID)), True), gbUnicode)
            Else
                LoadDataSource(tdbcStageID, ReturnTableFilter(dtStageID, "StageID <>'%' and BlockID=" & SQLString(ReturnValueC1Combo(tdbcBlockID)), True), gbUnicode)
            End If
        End If
      

        'If iMode <> 0 Then
        '    LoadDataSource(tdbcStageID, dtStageID, gbUnicode)
        'Else
        '    LoadDataSource(tdbcStageID, ReturnTableFilter(dtStageID, "StageID <>'%'", True), gbUnicode)
        'End If


    End Sub

    Private Sub LoadTDBCCustomerID(Optional iMode As Integer = 0)
        Dim dtCus As DataTable = ReturnDataTable(SQLStoreD45P1002)
        If iMode <> 0 Then
            LoadDataSource(tdbcCustomerID, dtCus, gbUnicode)
        Else
            LoadDataSource(tdbcCustomerID, ReturnTableFilter(dtCus, "CustomerID <>'%'", True), gbUnicode)
        End If

    End Sub
    Private Sub LoadTDBCProductionAdd(ByVal sCus As String, ByVal sStage As String)
        If tdbcProductAddID.Enabled = False Then Exit Sub
        If tdbcCustomerID.Enabled = False Then sCus = "%"

        If sCus = "%" Then
            If sStage = "%" Then
                LoadDataSource(tdbcProductAddID, dtProduct, gbUnicode)
            Else
                LoadDataSource(tdbcProductAddID, ReturnTableFilter(dtProduct, "ProductAddID='%' or StageID=" & SQLString(sStage), True), gbUnicode)
            End If
        Else
            If sStage = "%" Then
                LoadDataSource(tdbcProductAddID, ReturnTableFilter(dtProduct, "ProductAddID='%' or CustomerID=" & SQLString(sCus), True), gbUnicode)
            Else
                If ReturnValueC1Combo(tdbcReportID, "ReportTypeID") = "D45F4050" Or ReturnValueC1Combo(tdbcReportID, "ReportTypeID") = "D45F4040" Then
                    LoadDataSource(tdbcProductAddID, ReturnTableFilter(dtProduct, "ProductAddID='%' or (CustomerID=" & SQLString(sCus) & "  And StageID=" & SQLString(sStage) & ")", True), gbUnicode)
                Else
                    LoadDataSource(tdbcProductAddID, ReturnTableFilter(dtProduct, "CustomerID=" & SQLString(sCus) & "  And StageID=" & SQLString(sStage), True), gbUnicode)
                End If

            End If
        End If

    End Sub
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Not AllowPrint() Then Exit Sub
        Dim sReportName As String = ""
        Dim sReportPath As String = ""
        Dim sReportTitle As String = "" 'Thêm biến
        Dim sCustomReport As String = "" 'tdbcTranTypeID.Columns("InvoiceForm").Text

        Dim file As String = GetReportPathNew("45", ReturnValueC1Combo(tdbcReportID, "ReportTypeID"), sReportName, sCustomReport, sReportPath, ReturnValueC1Combo(tdbcReportID, "Title"))
        If sReportName = "" Then Exit Sub
        'Dim ContractID As String = _contractID
        Me.Cursor = Cursors.WaitCursor
        If btnPrint IsNot Nothing Then btnPrint.Enabled = False
        Select Case file.ToLower
            Case "rpt"
                'printReport(sReportName, sReportPath, rl3("caption"), sSQL)' ' Nếu Caption cố định theo Resource
                printReport(sReportName, sReportPath, sReportTitle, "", SQLStoreD45P4040) ' Nếu Caption lấy theo TIêu đề thiết lập bên D89.
            Case "xls", "xlsx"
                Dim sPathFile As String = D99D0541.GetObjectFile(ReturnValueC1Combo(tdbcReportID, "ReportTypeID"), sReportName, file, sReportPath)
                If sPathFile = "" Then Exit Select
                MyExcel(SQLStoreD45P4040, sPathFile, file, True)
                Me.Cursor = Cursors.Default
                If btnPrint IsNot Nothing Then btnPrint.Enabled = True
            Case "doc", "docx"
                Dim sPathFile As String = D99D0541.GetObjectFile(ReturnValueC1Combo(tdbcReportID, "ReportTypeID"), sReportName, file, sReportPath)
                If sPathFile = "" Then Exit Select
                CreateWordDocumentCopyTemplate(sPathFile, SQLStoreD45P4040)
                OpenFile(sPathFile, False)
        End Select
        Me.Cursor = Cursors.Default
        If btnPrint IsNot Nothing Then btnPrint.Enabled = True
    End Sub

    Private Sub printReport(ByVal sReportName As String, ByVal sReportPath As String, ByVal sReportCaption As String, ByVal _contractID As String, ByVal sSQL As String)
        Dim report As New D99C1003
        Dim conn As New SqlConnection(gsConnectionString)
        ' Dim sSQLSub As String = ""
        ' UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)
        ' sSQL = SQLStoreD27P2335(sReportName, _contractID)
        With report
            .OpenConnection(conn)
            ' .AddSub(sSQLSub, sSubReportName & ".rpt")'Báo cáo không sử dụng SubReport
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption)
        End With
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1002
    '# Created User: KIMLONG
    '# Created Date: 18/03/2016 10:54:01
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1002() As String
        Dim sSQL As String = ""
        sSQL &= ("-- -- Do nguon Combo Khach hang" & vbCrLf)
        sSQL &= "Exec D45P1002 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(1) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1011
    '# Created User: KIMLONG
    '# Created Date: 18/03/2016 10:54:55
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1011() As String
        Dim sSQL As String = ""
        sSQL &= ("-- -- Combo cong doan" & vbCrLf)
        sSQL &= "Exec D45P1011 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[2], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2051
    '# Created User: KIMLONG
    '# Created Date: 18/03/2016 10:55:54
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2051() As String
        Dim sSQL As String = ""
        sSQL &= ("-- -- Combo san pham gop" & vbCrLf)
        sSQL &= "Exec D45P2051 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[2], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P4040
    '# Created User: KIMLONG
    '# Created Date: 05/08/2016 01:24:29
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P4040() As String
        Dim sSQL As String = ""
        sSQL &= ("-- wu" & vbCrlf)
        sSQL &= "Exec D45P4040 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranMonth")) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcPeriod, "TranYear")) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcReportID, "ReportTypeID")) & COMMA 'ReportTypeID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcCustomerID)) & COMMA 'CustomerID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcStageID)) & COMMA 'StageID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcProductAddID)) & COMMA 'ProductAddID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcBlockID)) & COMMA 'BlockID, varchar[50], NOT NULL
        sSQL &= SQLNumber(chkIsOutsideStage.Checked) 'IsOutsideStage, tinyint, NOT NULL
        Return sSQL
    End Function




#Region "Events tdbcReportID with txtFileExt"

    Private Sub tdbcReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.SelectedValueChanged
        If tdbcReportID.SelectedValue Is Nothing Then
            txtFileExt.Text = ""
            txtReportName.Text = ""
        Else
            txtFileExt.Text = ReturnValueC1Combo(tdbcReportID, "FileExt")
            txtReportName.Text = ReturnValueC1Combo(tdbcReportID, "Title")
        End If

        Select Case ReturnValueC1Combo(tdbcReportID, "ReportTypeID")
            Case "D45F4030"
                'ID 94499 bỏ rem combo kỳ
                'tdbcPeriod.Text = ""
                'tdbcPeriod.Enabled = False

                If tdbcPeriod IsNot Nothing Then tdbcPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString

                tdbcCustomerID.Enabled = True

                tdbcProductAddID.Enabled = True
                LoadTDBCCustomerID()
                LoadTDBCStageID()
            Case "D45F4040", "D45F4050"
                tdbcPeriod.Enabled = True
                If tdbcPeriod IsNot Nothing Then tdbcPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
                tdbcCustomerID.Enabled = False
                tdbcProductAddID.Enabled = True
                LoadTDBCCustomerID(1)
                LoadTDBCStageID(1)
                If tdbcStageID IsNot Nothing Then tdbcStageID.SelectedIndex = 0
                If tdbcCustomerID IsNot Nothing Then tdbcCustomerID.SelectedIndex = 0
                If tdbcProductAddID IsNot Nothing Then tdbcProductAddID.SelectedIndex = 0
            Case "D45F4060"
                tdbcPeriod.Enabled = True
                If tdbcPeriod IsNot Nothing Then tdbcPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
                tdbcCustomerID.Enabled = False
                tdbcCustomerID.Text = ""
                LoadTDBCStageID(1)
                If tdbcStageID IsNot Nothing Then tdbcStageID.SelectedIndex = 0
                tdbcProductAddID.Enabled = False
                tdbcProductAddID.Text = ""
            Case "D45F4070"
                tdbcCustomerID.Enabled = False
                tdbcProductAddID.Enabled = False
            Case Else
                tdbcPeriod.Enabled = True
                tdbcCustomerID.Enabled = True
                tdbcProductAddID.Enabled = True
                LoadTDBCCustomerID(1)
                LoadTDBCStageID(1)
                If tdbcCustomerID IsNot Nothing Then tdbcCustomerID.SelectedIndex = 0
                If tdbcStageID IsNot Nothing Then tdbcStageID.SelectedIndex = 0
                If tdbcProductAddID IsNot Nothing Then tdbcProductAddID.SelectedIndex = 0
        End Select
        If tdbcBlockID IsNot Nothing Then tdbcBlockID.SelectedIndex = 0
        chkIsOutsideStage.Checked = False
        chkIsOutsideStage.Visible = ReturnValueC1Combo(tdbcReportID) = "D45R4040E"

    End Sub

    Private Sub tdbcReportID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.LostFocus
        If tdbcReportID.FindStringExact(tdbcReportID.Text) = -1 Then
            tdbcReportID.Text = ""
        End If
    End Sub

#End Region

    Private Function AllowPrint() As Boolean

        If tdbcReportID.Enabled = True Then
            If tdbcReportID.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblReportID.Text)
                tdbcReportID.Focus()
                Return False
            End If
        End If
        If tdbcPeriod.Enabled = True Then
            If tdbcPeriod.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(lblPeriod.Text)
                tdbcPeriod.Focus()
                Return False
            End If
        End If

        If tdbcCustomerID.Enabled And tdbcCustomerID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblCustomerID.Text)
            tdbcCustomerID.Focus()
            Return False
        End If
        If tdbcBlockID.Enabled And tdbcBlockID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblBlockID.Text)
            tdbcBlockID.Focus()
            Return False
        End If
        If tdbcStageID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblStageID.Text)
            tdbcStageID.Focus()
            Return False
        End If

        If tdbcProductAddID.Enabled And tdbcProductAddID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(lblProductAddID.Text)
            tdbcProductAddID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcReportID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcBlockID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCustomerID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcStageID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcProductAddID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If tdbcDivisionID.SelectedValue Is Nothing Then
            LoadCboPeriodReport(tdbcPeriod, "D09", "")
        Else
            LoadtdbcBlockID(tdbcBlockID, dtBlockID, ReturnValueC1Combo(tdbcDivisionID), gbUnicode)
            tdbcBlockID.SelectedValue = "%"
            LoadCboPeriodReport(tdbcPeriod, "D09", ReturnValueC1Combo(tdbcDivisionID))
        End If
        tdbcPeriod.Text = ""
    End Sub

#Region "Events tdbcCustomerID load tdbcProductAddID"

    Private Sub tdbcCustomerID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCustomerID.SelectedValueChanged
        If tdbcCustomerID.SelectedValue Is Nothing Then
            LoadTDBCProductionAdd("-1", "-1")
            tdbcProductAddID.Text = ""
            Exit Sub
        End If
        LoadTDBCProductionAdd(ReturnValueC1Combo(tdbcCustomerID), ReturnValueC1Combo(tdbcStageID))
        If ReturnValueC1Combo(tdbcReportID, "ReportTypeID") = "D45F4050" Or ReturnValueC1Combo(tdbcReportID, "ReportTypeID") = "D45F4040" Then
            tdbcProductAddID.SelectedIndex = 0
        Else
            tdbcProductAddID.Text = ""
        End If

    End Sub

#End Region

    Private Sub tdbcStageID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcStageID.SelectedValueChanged
        If tdbcStageID.SelectedValue Is Nothing Then
            LoadTDBCProductionAdd("-1", "-1")
            tdbcProductAddID.Text = ""
            Exit Sub
        End If
        LoadTDBCProductionAdd(ReturnValueC1Combo(tdbcCustomerID), ReturnValueC1Combo(tdbcStageID))
        If ReturnValueC1Combo(tdbcReportID, "ReportTypeID") = "D45F4050" Or ReturnValueC1Combo(tdbcReportID, "ReportTypeID") = "D45F4040" Then
            tdbcProductAddID.SelectedIndex = 0
        Else
            tdbcProductAddID.Text = ""
        End If
    End Sub

    Private Sub tdbcCustomerID_Validated(sender As Object, e As EventArgs) Handles tdbcCustomerID.Validated
        oFilterCombo.FilterCombo(tdbcCustomerID, e)
        If tdbcCustomerID.FindStringExact(tdbcCustomerID.Text) = -1 Then
            tdbcCustomerID.Text = ""
            tdbcProductAddID.Text = ""
            Exit Sub
        End If
      
    End Sub

    Private Sub tdbcStageID_Validated(sender As Object, e As EventArgs) Handles tdbcStageID.Validated
        oFilterCombo.FilterCombo(tdbcStageID, e)
        If tdbcStageID.FindStringExact(tdbcStageID.Text) = -1 Then
            tdbcStageID.Text = ""
            tdbcProductAddID.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub tdbcProductAddID_Validated(sender As Object, e As EventArgs) Handles tdbcProductAddID.Validated
        oFilterCombo.FilterCombo(tdbcProductAddID, e)
        If tdbcProductAddID.FindStringExact(tdbcProductAddID.Text) = -1 Then tdbcProductAddID.Text = ""
    End Sub

    Private Sub tdbcBlockID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcBlockID.SelectedValueChanged
        Select Case ReturnValueC1Combo(tdbcReportID, "ReportTypeID")
            Case "D45F4030"
                LoadTDBCStageID()
            Case "D45F4040", "D45F4050"
                LoadTDBCStageID(1)
                If tdbcStageID.DataSource IsNot Nothing Then tdbcStageID.SelectedIndex = 0
                If tdbcCustomerID.DataSource IsNot Nothing Then tdbcCustomerID.SelectedIndex = 0
                If tdbcProductAddID.DataSource IsNot Nothing Then tdbcProductAddID.SelectedIndex = 0
            Case "D45F4060"
                tdbcPeriod.Enabled = True
                LoadTDBCStageID(1)
                If tdbcStageID.DataSource IsNot Nothing Then tdbcStageID.SelectedIndex = 0
                tdbcProductAddID.Enabled = False
                tdbcProductAddID.Text = ""
            Case Else
                LoadTDBCStageID(1)
                If tdbcCustomerID.DataSource IsNot Nothing Then tdbcCustomerID.SelectedIndex = 0
                If tdbcStageID.DataSource IsNot Nothing Then tdbcStageID.SelectedIndex = 0
                If tdbcProductAddID.DataSource IsNot Nothing Then tdbcProductAddID.SelectedIndex = 0
        End Select
    End Sub
    Private Sub tdbcBlockID_Validated(sender As Object, e As EventArgs) Handles tdbcBlockID.Validated
        oFilterCombo.FilterCombo(tdbcBlockID, e)
        If tdbcBlockID.FindStringExact(tdbcBlockID.Text) = -1 Then
            tdbcBlockID.Text = ""
            tdbcStageID.Text = ""
            tdbcProductAddID.Text = ""
            Exit Sub
        End If
    End Sub
End Class