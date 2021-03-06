Imports System.Data
Imports System
'#-------------------------------------------------------------------------------------
'# Title: D09U2223
'# Created User: Nguyễn Hoàng Long
'# Created Date: 15/07/2009 1:53:15 PM
'# Modify User: Nguyễn Thị Minh Hòa
'# Modify Date: 30/09/2009 1:53:09 PM
'# Description: UserControl D09U2223 (dùng chung cho nhóm G4) chứa nội dung cảnh báo
'#-------------------------------------------------------------------------------------
Public Class D09U2223
    Dim sCusomizedReportID As String = ""
    Dim dt As DataTable
    Dim iperD09F2010 As Integer = 0
    Dim iPerD09F2130 As Integer = 0
    Dim iPerD15F2050 As Integer = 0
    Dim iperPrint As Integer = 0
#Region "Properties"

    Private _alertBaseID As String
    Public Property AlertBaseID() As String
        Get
            Return _alertBaseID
        End Get
        Set(ByVal Value As String)
            _alertBaseID = Value
        End Set
    End Property

    Private _IsDispose As Boolean
    Public ReadOnly Property IsDispose() As Boolean
        Get
            Return _IsDispose
        End Get
    End Property

    Private _alertCode As String
    Public Property AlertCode() As String
        Get
            Return _alertCode
        End Get
        Set(ByVal Value As String)
            _alertCode = Value
        End Set
    End Property

    Private _sQLQuery As String
    Public WriteOnly Property SQLQuery() As String
        Set(ByVal Value As String)
            _sQLQuery = Value
        End Set
    End Property

    Private _alertMessage As String
    Public WriteOnly Property AlertMessage() As String
        Set(ByVal Value As String)
            _alertMessage = Value
            lblMessage.Text = ConvertVniToUnicode(_alertMessage)
        End Set
    End Property

    Private _moduleID As String
    Public Property ModuleID() As String
        Get
            Return _moduleID
        End Get
        Set(ByVal Value As String)
            _moduleID = Value
        End Set
    End Property

    Private _formPermision As String
    Public Property FormPermision() As String
        Get
            Return _formPermision
        End Get
        Set(ByVal Value As String)
            _formPermision = Value
        End Set
    End Property
#End Region

#Region "Sự kiện của form"

    'Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim f As New D09M0340
    '    f.FormActive = D09E0340Form.D09F4000
    '    f.FormPermission = _formPermision
    '    f.ID01 = _alertBaseID
    '    f.ID02 = _alertCode
    '    f.ShowDialog()
    '    f.Dispose()
    '    Me.Cursor = Cursors.Default
    'End Sub

    Private Sub mnuRefesh_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRefesh.Click
        FillDataGrid(True)
    End Sub

    Private Sub picClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picClose.Click
        D09U2223_Disposed(sender, e)
    End Sub

    Private Sub D09U2223_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.Dispose()
        _IsDispose = True
    End Sub

    Private Sub D09U2223_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        LoadLanguage()
        
        SetShortcutPopupMenu(C1CommandHolder)

        '************************************************
        'Add phim tat cho menu
        C1CommandHolder.SmoothImages = False
        C1CommandHolder.Commands("mnuLaborContract").Shortcut = Shortcut.CtrlL
        C1CommandHolder.Commands("mnuUpdateInfo").Shortcut = Shortcut.CtrlC
        C1CommandHolder.Commands("mnuTransactionLeaveAssignment").Shortcut = Shortcut.CtrlM
        C1CommandHolder.Commands("mnuRefesh").Shortcut = Shortcut.CtrlR
    End Sub
#End Region
    'MaiDuyen update 16/11/2009
    'Goi phan quyen 1 lan duy nhat
    Public Sub LoadPermission()

        iperD09F2010 = ReturnPermission("D09F2010")
        iPerD09F2130 = ReturnPermission("D09F2130")
        iPerD15F2050 = ReturnPermission("D15F2050")
        'Phan quyen cho mnu in 
        iperPrint = ReturnPermission(_formPermision)

    End Sub

#Region "Các hàm Public"
    'MaiDuyen update 03/09/2009
    Public Sub LoadLanguage()
        mnuPrint.Text = rl3("InU")
        mnuLaborContract.Text = rl3("Lap_hop_dong_lao_dong")
        mnuUpdateInfo.Text = rl3("Cap_nhat_thong_tin")
        mnuTransactionLeaveAssignment.Text = rl3("Cap_phep_nam") 'Cấp phép nă&m


    End Sub

    Public Sub FieldCaption()
        '--------------------Add động các cột--------------------
        Dim sSQL As String
        sSQL = "Select FieldName, FieldCaption  " & vbCrLf
        sSQL &= "From D82T0120 " & vbCrLf
        sSQL &= "Where AlertBaseID = " & SQLString(_alertBaseID) & " And Language = " & SQLString(gsLanguage) & vbCrLf
        sSQL &= "Order by OrderNum"

        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                For i As Integer = 0 To tdbg.Columns.Count - 1
                    If dr("FieldName").ToString = tdbg.Columns(i).DataField Then
                        tdbg.Columns(i).Caption = dr("FieldCaption").ToString
                    End If
                Next i
            Next
            FooterTotalGrid(tdbg, 0)
            tdbg.Refresh()
        End If
    End Sub


    Public Function LoadTDBGrid() As Boolean
        ReplaceQuery()
        dt = ReturnDataTable(_sQLQuery)
        If dt.Rows.Count > 0 Then
            CreateColumns()
            FillDataGrid()
            Return True
        Else
            Return False
        End If

    End Function
#End Region

#Region "Các hàm Private"
    Private Sub CreateColumns()
        '--------------------Add động các cột--------------------
        ResetColorGrid(tdbg)
        Dim sSQL As String
        sSQL = "Select OrderNum, FieldName, FieldCaption, FieldWidth, FieldType, IsFilter, ReturnField, Length  " & vbCrLf
        sSQL &= "From D82T0120 " & vbCrLf
        sSQL &= "Where AlertBaseID = " & SQLString(_alertBaseID) & " And Language = " & SQLString(gsLanguage) & vbCrLf
        sSQL &= "Order by OrderNum"

        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)

        Dim dtGrid As New DataTable
        Dim nWidth As Integer = 80
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        Dim sFieldType As String = "S"
        Dim sysDataType As System.Type

        For i As Integer = 0 To dt.Rows.Count - 1
            sFieldType = dt.Rows(i).Item("FieldType").ToString
            Select Case sFieldType
                Case "S"
                    sysDataType = System.Type.GetType("System.String")
                Case "N"
                    sysDataType = System.Type.GetType("System.Double")
                Case "D"
                    sysDataType = System.Type.GetType("System.DateTime")
                Case Else
                    sysDataType = System.Type.GetType("System.String")
            End Select

            dtGrid.Columns.Add(dt.Rows(i).Item("FieldName").ToString, sysDataType)

            col = New C1.Win.C1TrueDBGrid.C1DataColumn
            col.DataField = dt.Rows(i).Item("FieldName").ToString
            col.Caption = dt.Rows(i).Item("FieldCaption").ToString
            If sFieldType = "N" Then
                col.NumberFormat = "#,##0.00"
            ElseIf sFieldType = "D" Then
                col.NumberFormat = "Short Date"
            End If

            tdbg.Columns.Add(col)
            tdbg.Splits(0).DisplayColumns(col).Visible = True
            tdbg.Splits(0).DisplayColumns(col).Width = Convert.ToInt32(dt.Rows(i).Item("FieldWidth"))
            tdbg.Splits(0).DisplayColumns(col).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Select Case sFieldType
                Case "S"
                    tdbg.Splits(0).DisplayColumns(col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                Case "N"
                    tdbg.Splits(0).DisplayColumns(col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                Case "D"
                    tdbg.Splits(0).DisplayColumns(col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    'If i Mod 2 = 0 Then
                    '    tdbg.Columns(i).Editor = c1date1
                    'Else
                    '    tdbg.Columns(i).Editor = c1date2
                    'End If
                    InputDateInTrueDBGrid(tdbg, i)
            End Select
        Next
        '--------------------Add động các cột--------------------
    End Sub

    Private Sub FillDataGrid(Optional ByVal bReLoad As Boolean = False)
        LoadDataSource(tdbg, dt)

        If Not bReLoad Then

            'MaiDuyen update 16/11/2009
            LoadPermission()

            mnuLaborContract.Visible = False 'Menu Lập hợp đồng
            mnuUpdateInfo.Visible = False  'Menu Cập nhật thông tin
            mnuTransactionLeaveAssignment.Visible = False 'Menu Cấp phép năm
            mnuPrint.Visible = False
            Select Case _alertBaseID
                Case "D82A0901"
                    mnuLaborContract.Visible = True
                    'mnuLaborContract.Enabled = ReturnPermission("D09F2010") >= 2

                    mnuUpdateInfo.Visible = True
                    'mnuUpdateInfo.Enabled = ReturnPermission("D09F2130") >= 2

                Case "D82A0902"
                    mnuLaborContract.Visible = True
                    'mnuLaborContract.Enabled = ReturnPermission("D09F2010") >= 2

                Case "D82A1502"
                    mnuTransactionLeaveAssignment.Visible = True
                    'mnuTransactionLeaveAssignment.Enabled = ReturnPermission("D15F2050") >= 2

            End Select

            '***************************************
            'Set bỏ đường Line
            If mnuTransactionLeaveAssignment.Visible Then
                If mnuLaborContract.Visible = False And mnuUpdateInfo.Visible = False Then
                    mnuTransactionLeaveAssignmentLink.Delimiter = False
                End If
            Else
                mnuRefeshLink.Delimiter = False
            End If
        End If
        '***************************************
        'Mai Duyen update 16/11/2009
        'Menu In
        'mnuPrint.Enabled = (ReturnPermission(_formPermision) >= 1) And (tdbg.RowCount > 0)
        'Mai Duyen update 16/11/2009
        CheckMenuOther()

        '***************************************
        FooterTotalGrid(tdbg, 0)
    End Sub
    'Mai Duyen update 16/11/2009
    Private Sub CheckMenuOther()
        mnuPrint.Enabled = (iperPrint >= 1) And (tdbg.RowCount > 0)
        mnuLaborContract.Enabled = (iperD09F2010 >= 2) And (tdbg.RowCount > 0)
        mnuUpdateInfo.Enabled = (iPerD09F2130 >= 2) And (tdbg.RowCount > 0)
        mnuLaborContract.Enabled = (iperD09F2010 >= 2) And (tdbg.RowCount > 0)
        mnuTransactionLeaveAssignment.Enabled = (iPerD15F2050 >= 2) And (tdbg.RowCount > 0)
    End Sub

    Private Function Exist_ColEmplooyeeID() As Boolean
        Dim iCol_EmployeeID As Integer = -1

        For i As Integer = 0 To tdbg.Columns.Count - 1
            If tdbg.Columns(i).DataField = "EmployeeID" Then
                iCol_EmployeeID = i
                Exit For
            End If
        Next i
        If iCol_EmployeeID = -1 Then
            D99C0008.MsgL3(rl3("Khong_ton_tai_cot_EmployeeID"))
            Me.Cursor = Cursors.Default
            Return False 'k co cot EmployeeID
        End If

        Return True
    End Function
#End Region

#Region "FilterBar"
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dt Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            dt.DefaultView.RowFilter = sFilter.ToString()
            CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, False)
            'Mai Duyen update 16/11/2009
            CheckMenuOther()

            FooterTotalGrid(tdbg, 0)
        Catch ex As Exception
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
        'Try
        '    If (dt Is Nothing) Then Exit Sub
        '    sFilter = New StringBuilder("")
        '    Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        '    For Each dc In Me.tdbg.Columns
        '        Select Case dc.DataType.Name
        '            Case "DateTime"
        '                If dc.FilterText.Length = 10 Then
        '                    If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                    Dim sClause As String = ""
        '                    sClause = "(" & dc.DataField & " >= #" & DateSave(CDate(dc.FilterText)) & "#"
        '                    sClause &= " And " & dc.DataField & " < #" & DateSave(CDate(dc.FilterText).AddDays(1)) & "# )"
        '                    sFilter.Append(sClause)
        '                End If
        '            Case "Boolean"
        '                If dc.FilterText.Length > 0 Then
        '                    If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                    sFilter.Append((dc.DataField + " = " + "'" + dc.FilterText + "'"))
        '                End If
        '            Case "String"
        '                If dc.FilterText.Length > 0 Then
        '                    If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                    sFilter.Append((dc.DataField + " like " + "'%" + dc.FilterText + "%'"))
        '                End If
        '            Case "Decimal", "Byte", "Integer"
        '                If dc.FilterText.Length > 0 Then
        '                    If sFilter.Length > 0 Then sFilter.Append(" AND ")
        '                    sFilter.Append((dc.DataField + " = " + "" + dc.FilterText + ""))
        '                End If
        '        End Select
        '    Next
        '    'Filter the data

        '    dt.DefaultView.RowFilter = sFilter.ToString()
        '    CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, False)
        '    'Mai Duyen update 16/11/2009
        '    CheckMenuOther()

        '    FooterTotalGrid(tdbg, 0)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & " - " & ex.Source)
        'End Try
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Columns(tdbg.Col).DataType.Name
            Case "Decimal", "Byte", "Integer"
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case "DateTime"
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
        End Select

    End Sub

    Public Function DateSave(ByVal [Date] As String) As String
        If [Date] = "" Then Return "NULL"
        Dim dDate As Date = CType([Date], Date)
        Return dDate.ToString("MM/dd/yyyy")
    End Function

    Public Function DateSave(ByVal [Date] As Object) As String
        If IsDBNull([Date]) Then Return "NULL"
        Return DateSave([Date].ToString)
    End Function

    Private Sub c1date1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1date1.KeyDown
        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        Try
            If e.KeyCode = Keys.Tab Then
                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
                tdbg.Col = tdbg.Col + 1
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub c1date2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1date2.KeyDown
        'Fix: khi xóa giá trị sau đó nhấn TAB thì không giữ lại giá trị cũ
        Try
            If e.KeyCode = Keys.Tab Then
                'Chú ý: Nếu cột cuối cùng hiển thị là Date thì không cộng
                tdbg.Col = tdbg.Col + 1
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Câu SQL"

    Private Sub ReplaceQuery()
        _sQLQuery = _sQLQuery.Replace("{DivisionID}", gsDivisionID)
        _sQLQuery = _sQLQuery.Replace("{UserID}", gsUserID)
        _sQLQuery = _sQLQuery.Replace("{TranMonth}", giTranMonth.ToString())
        _sQLQuery = _sQLQuery.Replace("{TranYear}", giTranYear.ToString)

        Dim sSQL As String = ""
        sSQL = "Select ParameterID, ParaValue, ReportID, CustomizedReportID " & vbCrLf
        sSQL &= "From D82T1020" & vbCrLf
        sSQL &= "Where AlertCode = " & SQLString(_alertCode) & " And AlertBaseID=" & SQLString(_alertBaseID) & " And ModuleID= 'D" & _moduleID & "'"
        Dim dt1 As DataTable = ReturnDataTable(sSQL)
        If dt1.Rows.Count > 0 Then
            sCusomizedReportID = dt1.Rows(0).Item("CustomizedReportID").ToString
            For i As Integer = 0 To dt1.Rows.Count - 1
                _sQLQuery = _sQLQuery.Replace("{" & dt1.Rows(i).Item("ParameterID").ToString & "}", dt1.Rows(i).Item("ParaValue").ToString)
            Next
        End If
    End Sub

    Private Function SQLStoreD09P8210() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P8210 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(_alertBaseID) & COMMA 'AlertBaseID, varchar[20], NOT NULL
        sSQL &= SQLString(_alertCode) & COMMA 'AlertCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) 'TranYear, int, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 08/09/2009 01:35:08
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009(ByVal sKey02ID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D91T9009 "
        sSQL &= "Where HostID=" & SQLString(My.Computer.Name) & " And UserID=" & SQLString(gsUserID) & " And Key02ID=" & SQLString(sKey02ID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 08/09/2009 01:35:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009(ByVal sKey01ID As String, ByVal sKey02ID As String) As StringBuilder
        Dim sSQL As New StringBuilder("")
        sSQL.Append("Insert Into D91T9009(")
        sSQL.Append("UserID, HostID, Key01ID, Key02ID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
        sSQL.Append(SQLString(sKey01ID) & COMMA) 'Key01ID, varchar[250], NULL
        sSQL.Append(SQLString(sKey02ID)) 'Key02ID, varchar[250], NULL
        sSQL.Append(")")

        Return sSQL
    End Function
#End Region

    '#Region "Code cho module D09, các module khác thì Rem lại"

    '    Private Sub mnuLaborContract_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuLaborContract.Click
    '        'Gọi exe con D09E0240
    '        Dim sSQL As New StringBuilder("")

    '        If Not Exist_ColEmplooyeeID() Then Exit Sub

    '        Me.Cursor = Cursors.WaitCursor

    '        sSQL.Append(SQLDeleteD91T9009("D09F2010"))
    '        For i As Integer = 0 To tdbg.RowCount - 1
    '            sSQL.Append(SQLInsertD91T9009(tdbg(i, "EmployeeID").ToString, "D09F2010"))
    '        Next i

    '        If ExecuteSQL(sSQL.ToString) Then
    '            Dim bOutput As Boolean
    '            Dim f As New D09M1240
    '            f.FormActive = D09E0240Form.D09F2010
    '            f.FormPermission = "D09F2010"
    '            f.ModuleID = "D" & _moduleID
    '            f.Mode = 1
    '            f.ShowDialog()
    '            bOutput = f.Output01 'Giá trị trả về có lưu thành công không?
    '            f.Dispose()
    '            If bOutput Then
    '                'Load lại dữ liệu 
    '                FillDataGrid(True)
    '            End If
    '        End If
    '        Me.Cursor = Cursors.Default
    '    End Sub

    '    Private Sub mnuUpdateInfo_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuUpdateInfo.Click
    '        Dim sSQL As New StringBuilder("")

    '        If Not Exist_ColEmplooyeeID() Then Exit Sub

    '        Me.Cursor = Cursors.WaitCursor
    '        sSQL.Append(SQLDeleteD91T9009("D09F2131"))
    '        For i As Integer = 0 To tdbg.RowCount - 1
    '            sSQL.Append(SQLInsertD91T9009(tdbg(i, "EmployeeID").ToString, "D09F2131"))
    '        Next i

    '        If ExecuteSQL(sSQL.ToString) Then
    '            Dim bOutput As Boolean
    '            Dim f As New D09F2131
    '            f.AlertBaseID = _alertBaseID

    '            f.ShowDialog()
    '            bOutput = f.Output01 'Giá trị trả về có lưu thành công không?
    '            f.Dispose()

    '            If bOutput Then
    '                'Load lại dữ liệu 
    '                FillDataGrid(True)
    '            End If
    '        End If
    '        Me.Cursor = Cursors.Default
    '    End Sub

    '#End Region

    '#Region "Code cho module D15, các module khác thì Rem lại"

    '    '    Private Sub mnuTransactionLeaveAssignment_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTransactionLeaveAssignment.Click
    '    '        Dim sSQL As New StringBuilder("")

    '    '        If Not Exist_ColEmplooyeeID() Then Exit Sub

    '    '        Me.Cursor = Cursors.WaitCursor
    '    '        sSQL.Append(SQLDeleteD91T9009("I01") & vbCrLf)
    '    '        For i As Integer = 0 To tdbg.RowCount - 1
    '    '            sSQL.Append(SQLInsertD91T9009(tdbg(i, "EmployeeID").ToString, "I01"))
    '    '        Next i

    '    '        If ExecuteSQL(sSQL.ToString) Then
    '    '            Dim bOutput As Boolean
    '    '            Dim frm As New D15F2051
    '    '            With frm
    '    '                .FormName = "D15F2051"
    '    '                .FormPermission = "D15F2050" 'Màn hình phân quyền(có thể k dùng)
    '    '                .FormCall = "D15F0000"
    '    '                .ShowDialog()
    '    '                bOutput = .Output01 'Giá trị trả về có lưu thành công không?
    '    '                .Dispose()
    '    '            End With
    '    '            If bOutput Then
    '    '                'Load lại dữ liệu 
    '    '                FillDataGrid(True)
    '    '            End If
    '    '        End If

    '    '        Me.Cursor = Cursors.Default
    '    '    End Sub
    '#End Region

End Class
