Imports System.Data
Imports System

Public Class D25U2224

    Dim _picMain As PictureBox
    Public Sub New(ByVal picMain As PictureBox, ByVal sModuleID As String, ByRef NoData As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _picMain = picMain
        _moduleID = sModuleID
        LoadTDBGrid(NoData)
    End Sub

#Region "Const of tdbg"
    Private Const COL_AlertBaseID As Integer = 0  ' AlertBaseID
    Private Const COL_AlertCode As Integer = 1    ' AlertCode
    Private Const COL_AlertMessage As Integer = 2 ' Cảnh báo
    Private Const COL_SQLQuery As Integer = 3     ' SQLQuery
    Private Const COL_Quantity As Integer = 4     ' Số lượng
#End Region

    Private _moduleID As String = ""
    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            _moduleID = Value
        End Set
    End Property

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P8200
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 15/11/2013 01:32:28
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P8200(Optional ByVal MenuType As Integer = 0, Optional ByVal ParentDesktopID As String = "", Optional ByVal Mode As Integer = 0, Optional ByVal IsNewDisplay As Integer = 0) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi 1" & vbCrLf)
        sSQL &= "Exec D09P8200 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(_moduleID) & COMMA 'ModuleID, varchar[20], NOT NULL
        sSQL &= SQLNumber(MenuType) & COMMA 'MenuType, int, NOT NULL
        sSQL &= SQLString(ParentDesktopID) & COMMA 'ParentDesktopID, varchar[20], NOT NULL
        sSQL &= SQLNumber(Mode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(IsNewDisplay) & COMMA 'IsNewDisplay, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, smallint, NOT NULL
        Return sSQL
    End Function

    Dim dtGrid As DataTable
    Private Sub LoadTDBGrid(Optional ByRef NoData As Boolean = True)
        dtGrid = ReturnDataTable(SQLStoreD09P8200(, , , 1))
        NoData = dtGrid.Rows.Count = 0
        LoadDataSource(tdbgM, dtGrid, gbUnicode)
        tdbg_RowColChange(Nothing, Nothing)
    End Sub

    Dim dtGridDetail As DataTable
    Private Sub LoadTDBGridDetail()
        ResetFilter(tdbgD, sFilterD, bRefreshFilterD)
        If tdbgM.Bookmark < 0 Then tdbgD.ClearFields() : Exit Sub

        Dim sSQL As String = tdbgM.Columns(COL_SQLQuery).Text
        ReplaceQuery(sSQL, tdbgM.Columns(COL_AlertCode).Text, tdbgM.Columns(COL_AlertBaseID).Text)
        dtGridDetail = ReturnDataTable(sSQL)
        tdbgD.SetDataBinding(dtGridDetail, "", False)
        For i As Integer = 0 To tdbgD.Columns.Count - 1
            tdbgD.Splits(0).DisplayColumns(i).Visible = False
        Next
        LoadLanguage()

        FooterTotalGrid(tdbgD, 2)
        CheckMenuOther()
    End Sub

    Public Sub LoadLanguage(Optional ByVal loadGrid As Boolean = False)
        mnuPrint.Text = rL3("InU")
        mnuApprove.Text = rL3("Duyet")
        btnCollapse.Text = rl3("Chi_tiet")
        lblMessage.Text = rl3("Canh_bao") ' ConvertVniToUnicode(tdbgM.Columns(COL_AlertMessage).Text)
        FormatGridDetail(tdbgM.Columns(COL_AlertBaseID).Text)
        If loadGrid Then LoadTDBGrid()
    End Sub

    Private Sub ReplaceQuery(ByRef _sQLQuery As String, ByVal _alertCode As String, ByVal _alertBaseID As String, Optional ByVal IsNewDisplay As Integer = 0)
        _sQLQuery = _sQLQuery.Replace("{DivisionID}", gsDivisionID)
        _sQLQuery = _sQLQuery.Replace("{UserID}", gsUserID)
        _sQLQuery = _sQLQuery.Replace("{TranMonth}", giTranMonth.ToString())
        _sQLQuery = _sQLQuery.Replace("{TranYear}", giTranYear.ToString)
        _sQLQuery = _sQLQuery.Replace("{CodeTable}", SQLNumber(gbUnicode))
        _sQLQuery = _sQLQuery.Replace("{Language}", gsLanguage)
        _sQLQuery = _sQLQuery.Replace("{IsNewDisplay}", IsNewDisplay.ToString)

        Dim sSQL As String = ""
        sSQL = "Select ParameterID, ParaValue, ReportID, CustomizedReportID " & vbCrLf
        sSQL &= "From D82T1020" & vbCrLf
        sSQL &= "Where AlertCode = " & SQLString(_alertCode) & " And AlertBaseID=" & SQLString(_alertBaseID) & " And ModuleID= 'D" & _moduleID & "'"
        Dim dt1 As DataTable = ReturnDataTable(sSQL)
        For i As Integer = 0 To dt1.Rows.Count - 1
            _sQLQuery = _sQLQuery.Replace("{" & dt1.Rows(i).Item("ParameterID").ToString & "}", dt1.Rows(i).Item("ParaValue").ToString)
        Next
    End Sub

    Private Sub FormatGridDetail(ByVal _alertBaseID As String)
        Dim sSQL As String = ""
        sSQL = "Select OrderNum, FieldName, FieldCaption" & UnicodeJoin(gbUnicode) & " As FieldCaption, FieldWidth, FieldType, IsFilter, ReturnField, Length, ColumnType" & vbCrLf
        sSQL &= "From D82T0120 " & vbCrLf
        sSQL &= "Where AlertBaseID = " & SQLString(_alertBaseID) & " And Language = " & SQLString(gsLanguage) & vbCrLf
        sSQL &= "Order by OrderNum"

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub

        For Each dr As DataRow In dt.Rows
            Dim sFieldName As String = dr("FieldName").ToString
            Try
                If tdbgD.Columns.IndexOf(tdbgD.Columns(sFieldName)) < 0 Then Continue For 'Nếu không tồn tại lưới thì bỏ qua
            Catch ex As Exception
                Continue For 'Nếu không tồn tại lưới thì bỏ qua
            End Try


            tdbgD.Splits(0).DisplayColumns(sFieldName).Width = Convert.ToInt32(dr.Item("FieldWidth"))
            tdbgD.Splits(0).DisplayColumns(sFieldName).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            tdbgD.Splits(0).DisplayColumns(sFieldName).HeadingStyle.Font = FontUnicode(gbUnicode)

            Dim sFieldCaption As String = dr.Item("FieldCaption").ToString
            Select Case dr("FieldType").ToString
                Case "S"
                    If giReplacResource <> 0 Then sFieldCaption = ReplaceResourceCustom(sFieldCaption)
                    tdbgD.Splits(0).DisplayColumns(sFieldName).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                Case "N"
                    tdbgD.Splits(0).DisplayColumns(sFieldName).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    tdbgD.Columns(sFieldName).NumberFormat = "N2"
                Case "D"
                    tdbgD.Splits(0).DisplayColumns(sFieldName).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    InputDateInTrueDBGrid(tdbgD, sFieldName)
            End Select
            tdbgD.Columns(sFieldName).Caption = sFieldCaption
            tdbgD.Splits(0).DisplayColumns(sFieldName).Visible = (dr.Item("ColumnType").ToString = "")
            '--------------------------------------
            'Xu ly neu co cot Chon
            If tdbgD.Columns(sFieldName).DataField = "IsUsed" Then
                tdbgD.Columns(sFieldName).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
                tdbgD.Splits(0).DisplayColumns(sFieldName).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Else
                tdbgD.Splits(0).DisplayColumns(sFieldName).Locked = True
                tdbgD.Splits(0).DisplayColumns(sFieldName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            End If
        Next
        tdbgD.Refresh()
    End Sub


    Private Sub D99U2223_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.Dispose()
    End Sub


    Private Sub D99U2223_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        ResetFooterGrid(tdbgM, tdbgD)
        InputbyUnicode(Me, gbUnicode)
        ResetColorGrid(tdbgM)
        'Add phim tat cho menu
        C1CommandHolder.SmoothImages = False
        C1CommandHolder.Commands("mnuLaborContract").Shortcut = Shortcut.CtrlL
        C1CommandHolder.Commands("mnuUpdateInfo").Shortcut = Shortcut.CtrlC
        C1CommandHolder.Commands("mnuTransactionLeaveAssignment").Shortcut = Shortcut.CtrlM
        C1CommandHolder.Commands("mnuRefesh").Shortcut = Shortcut.CtrlR
        '************************
        VisibleMenu()
        picClose.BringToFront()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Dim sAlertBaseID As String = "" 'Chặn rowcol 
    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgM.RowColChange
        'If tdbgM.Columns.Count = 0 OrElse tdbgM.Row < 0 OrElse tdbgM.RowCount = 0 Then Exit Sub
        If tdbgM.Columns.Count = 0 Then Exit Sub
        If tdbgM.Row < 0 OrElse tdbgM.RowCount = 0 Then
            sAlertBaseID = ""
            If dtGridDetail IsNot Nothing AndAlso dtGridDetail.Rows.Count > 0 Then dtGridDetail.Clear()
            Exit Sub
        End If
        If sAlertBaseID <> tdbgM(tdbgM.Row, COL_AlertBaseID).ToString & tdbgM(tdbgM.Row, COL_AlertCode).ToString Then LoadTDBGridDetail()
        tdbgM.Columns(COL_AlertMessage).Caption = IIf(gbUnicode, tdbgM.Columns(COL_AlertMessage).Text, ConvertVniToUnicode(tdbgM.Columns(COL_AlertMessage).Text)).ToString
        sAlertBaseID = tdbgM(tdbgM.Row, COL_AlertBaseID).ToString & tdbgM(tdbgM.Row, COL_AlertCode).ToString

        mnuPrint.Visible = False
        mnuApprove.Visible = False
        Select Case tdbgM(tdbgM.Row, COL_AlertBaseID).ToString
            Case "D82A2508"
                mnuApprove.Visible = True
        End Select

        '***************************************
        'Set bỏ đường Line
        If mnuApprove.Visible = False Then mnuRefeshLink.Delimiter = False

    End Sub

    Private Sub CheckMenuOther()
        mnuPrint.Enabled = (tdbgD.RowCount > 0)
        mnuApprove.Enabled = (tdbgD.RowCount > 0)
    End Sub

    Private Sub VisibleMenu()
        mnuApprove.Enabled = (ReturnPermission("D25F2020") >= 2) And D25Systems.IsUseAppRecruitProposal = False
    End Sub

    Dim Tooltip As New ToolTip
    Private Sub btnCollasp_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCollapse.MouseHover
        Tooltip.SetToolTip(btnCollapse, IIf(L3Bool(btnCollapse.Tag), "Expand", "Collapse").ToString)
    End Sub

    Private Sub btnCollasp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCollapse.Click
        tdbgD.Visible = L3Bool(btnCollapse.Tag)
        If tdbgD.Visible Then
            btnCollapse.Image = imgDownUp.Images(0)
            pnlDetail.Location = New Point(pnlDetail.Location.X, pnlDetail.Location.Y - tdbgD.Height)
            tdbgM.Height -= tdbgD.Height
        Else
            btnCollapse.Image = imgDownUp.Images(1)
            pnlDetail.Location = New Point(pnlDetail.Location.X, pnlDetail.Location.Y + tdbgD.Height)
            tdbgM.Height += tdbgD.Height
        End If
        btnCollapse.Tag = Not L3Bool(btnCollapse.Tag) '0: Collapse, 1: Expand
    End Sub

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbgM_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgM.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbgM, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbgM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgM.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbgM, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        tdbg_RowColChange(Nothing, Nothing)
    End Sub

    Dim sFilterD As New System.Text.StringBuilder()
    Dim bRefreshFilterD As Boolean = False
    Private Sub tdbgD_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgD.FilterChange
        Try
            If (dtGridDetail Is Nothing) Then Exit Sub
            If bRefreshFilterD Then Exit Sub
            FilterChangeGrid(tdbgD, sFilterD) 'Nếu có Lọc khi In
            ReLoadTDBGriddetail()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub
    Private Sub tdbgd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgD.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbgD, e)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ReLoadTDBGridDetail()
        Dim strFind As String = sFilterD.ToString
        If dtGridDetail.Columns.Contains("IsUsed") And strFind <> "" Then strFind &= " or IsUsed =1"
        dtGridDetail.DefaultView.RowFilter = strFind
        FooterTotalGrid(tdbgD, 2)
    End Sub
    Private Sub tdbgD_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgD.HeadClick
        If tdbgD.RowCount <= 0 Then Exit Sub
        Select Case tdbgD.Columns(e.ColIndex).DataField
            Case "IsUsed"
                tdbgD.AllowSort = False
                Dim bFlag As Boolean = Not L3Bool(tdbgD(0, "IsUsed"))
                For i As Integer = 0 To tdbgD.RowCount - 1
                    tdbgD(i, "IsUsed") = bFlag
                Next
            Case Else
                tdbgD.AllowSort = True
        End Select
    End Sub
    Private Sub picClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picClose.Click
        '_IsDispose = True
        _picMain.Visible = True
        D99U2223_Disposed(Nothing, Nothing)
    End Sub
    Private Sub tdbgD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgD.KeyPress
        If tdbgD.Columns(tdbgD.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbgD.Splits(0).DisplayColumns(tdbgD.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
    Private Sub mnuApprove_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs)
        Dim sSQL As New StringBuilder("")
        Const sAlertID As String = "D82A2508"
        'If Not Exist_ColEmplooyeeID() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        sSQL.Append("-- Duyet" & vbCrLf)
        sSQL.Append(SQLDeleteD09T6666(sAlertID) & vbCrLf)
        For i As Integer = 0 To tdbgD.RowCount - 1
            If L3Bool(GetValue(tdbgD, "IsUsed", i)) Then sSQL.Append(SQLInsertD09T6666(GetValue(tdbgD, "TransID", i), sAlertID))
        Next i

        If ExecuteSQL(sSQL.ToString) Then
            Dim arrPro() As StructureProperties = Nothing
            SetProperties(arrPro, "AlertID", sAlertID)
            Dim frm As Form = CallFormShowDialog("D25D0240", "D25F2021", arrPro)
            If L3Bool(GetProperties(frm, "SavedOK")) Then
                LoadTDBGridDetail()
                ExecuteSQLNoTransaction(SQLDeleteD09T6666(sAlertID))
            End If
        End If
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub mnuRefesh_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs)
        LoadTDBGridDetail()
    End Sub

    Private Function SQLDeleteD09T6666(ByVal FormID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        sSQL &= "FormID = " & SQLString(FormID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 08/10/2014 09:33:26
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666(ByVal Key01ID As String, ByVal FormID As String) As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D09T6666(")
        sSQL.Append("UserID, HostID, Key01ID, FormID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
        sSQL.Append(SQLString(Key01ID) & COMMA) 'Key01ID, varchar[250], NOT NULL
        sSQL.Append(SQLString(FormID)) 'FormID, varchar[20], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function
End Class
