Imports System.Windows.Forms
Imports System
Public Class D13F2046

#Region "Const of tdbg"
    Private Const COL_EmployeeID As String = "EmployeeID"             ' Mã NV
    Private Const COL_EmployeeName As String = "EmployeeName"         ' Họ và tên
    Private Const COL_BlockID As String = "BlockID"                   ' Khối
    Private Const COL_BlockName As String = "BlockName"               ' Tên khồi
    Private Const COL_DepartmentID As String = "DepartmentID"         ' Phòng ban
    Private Const COL_DepartmentName As String = "DepartmentName"     ' Tên phòng ban
    Private Const COL_TeamID As String = "TeamID"                     ' Tổ nhóm
    Private Const COL_TeamName As String = "TeamName"                 ' Tên tổ nhóm
    Private Const COL_EmpGroupID As String = "EmpGroupID"             ' Nhóm NV
    Private Const COL_EmpGroupName As String = "EmpGroupName"         ' Tên nhóm NV
    Private Const COL_DutyID As String = "DutyID"                     ' Chức vụ
    Private Const COL_DutyName As String = "DutyName"                 ' Tên chức vụ
    Private Const COL_WorkID As String = "WorkID"                     ' Công việc
    Private Const COL_WorkName As String = "WorkName"                 ' Tên công việc
    Private Const COL_BirthDate As String = "BirthDate"               ' Ngày sinh
    Private Const COL_SexName As String = "SexName"                   ' Giới tính
    Private Const COL_DateJoined As String = "DateJoined"             ' Ngày vào làm
    Private Const COL_DateLeft As String = "DateLeft"                 ' Ngày nghỉ việc
    Private Const COL_Age As String = "Age"                           ' Tuổi
    Private Const COL_StatusID As String = "StatusID"                 ' Trạng thái làm việc
    Private Const COL_StatusName As String = "StatusName"             ' Tên trạng thái làm việc
    Private Const COL_AttendanceCardNo As String = "AttendanceCardNo" ' Mã thẻ chấm công
    Private Const COL_RefEmployeeID As String = "RefEmployeeID"       ' Mã NV phụ
#End Region
    Private dtGrid As DataTable
  
    Private _salaryVoucherID As String = ""

    Private Const COL_LevelID As String = "LevelID" 'Cột ẩn đầu tiên
    Public WriteOnly Property  SalaryVoucherID() As String 
        Set(ByVal Value As String )
            _salaryVoucherID = Value
        End Set
    End Property

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2046
    '# Created User: Lê Anh Vũ
    '# Created Date: 22/10/2014 08:43:00
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2046() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi" & vbCrLf)
        sSQL &= "Exec D13P2046 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[50], NOT NULL
        sSQL &= SQLNumber(IIf(optMode1.Checked, 1, 2)) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA  'Language, tinyint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcPreSalaryVoucherID))
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P4121
    '# Created User: Lê Anh Vũ
    '# Created Date: 21/10/2014 01:48:03
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P4121() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load Caption dong cho luoi" & vbCrlf)
        sSQL &= "Exec D09P4121 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'ReportID, varchar[20], NOT NULL
        sSQL &= SQLString("13") & COMMA 'ModuleID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLNumber("") & COMMA 'PeriodMode, tinyint, NOT NULL
        sSQL &= SQLNumber("2") & COMMA 'TranMonthFrom, tinyint, NOT NULL
        sSQL &= SQLNumber("2013") & COMMA 'TranYearFrom, smallint, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonthTo, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYearTo, smallint, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber("") & COMMA 'IsPeriodDetail, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA 'PeriodTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(optMode1.Checked, 1, 2))  'Mode, tinyint, NOT NULL
        'sSQL &= SQLString(ReturnValueC1Combo(tdbcPreSalaryVoucherID))
        Return sSQL
    End Function

    Dim dtTmpCaption As DataTable

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Doi_chieu_du_lieu_tinh_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) '˜çi chiÕu dö liÖu tÛnh l§¥ng
        '================================================================ 
        lblPreSalaryVoucherID.Text = rl3("Phieu_luong_can_doi_chieu") 'Phiếu lương cần đối chiếu
        '================================================================ 
        btnF12.Text = rl3("Hien_thi") 'Hiển thị
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        optMode2.Text = rL3("Chieu_doc") 'Chiều dọc
        optMode1.Text = rL3("Chieu_ngang") 'Chiều ngang
        btnFillter.Text = rl3("Loc") & " (F5)" 'Lọc (F5)
        '================================================================ 
        chkShowALL.Text = rl3("Hien_thi_tat_ca") 'Hiển thị tất cả
        '================================================================ 
        tdbcPreSalaryVoucherID.Columns("PreSalaryVoucherID").Caption = rl3("Ma") 'Mã
        tdbcPreSalaryVoucherID.Columns("Description").Caption = rl3("Ten") 'Tên
    End Sub


    Private Function LoadCaptionMerge(ByVal dtCaption As DataTable) As String
        flex.Cols.RemoveRange(flex.Cols.Fixed, flex.Cols.Count - 1)
        Dim sColEnd As String = "" 'Cột cuối cùng merge 2 dòng

        dtTmpCaption = dtCaption.Copy()
        _ListCol = dtCaption.Select("FieldName='' And ColMergeNum >=1")
        If dtCaption Is Nothing OrElse dtCaption.Rows.Count = 0 Then Return ""
        AddColums(dtCaption)
        Dim iLeftCol As Integer = flex.Cols.Fixed - 1   'Cột bắt đầu merge
        Dim iRightCol As Integer = iLeftCol
        For i As Integer = 0 To dtCaption.Rows.Count - 1
            Try
                If sColEnd = "" And i > 0 And GetValue(dtCaption, "FieldName", i) = "" Then sColEnd = GetValue(dtCaption, "FieldName", i - 1)
                If dtCaption.Rows(i).Item("FieldName").ToString <> "" And dtGrid.Columns.Contains(dtCaption.Rows(i).Item("FieldName").ToString) = False Then Continue For

                If iLeftCol >= flex.Cols.Count Then Return ""
                Dim drLevel As DataRow = dtCaption.Rows(i)
                Dim sField As String = ""
                If IsDBNull(drLevel.Item("FieldName")) = False AndAlso drLevel.Item("FieldName").ToString <> "" Then
                    sField = drLevel.Item("FieldName").ToString.Replace("[", "").Replace("]", "")
                    iLeftCol = flex.Cols.IndexOf(sField)
                Else
                    iLeftCol = flex.Cols.IndexOf(drLevel.Item("CaptionID").ToString & "_01") 'TH lấy cột đầu tiên của dòng merge
                End If
                If iLeftCol < 0 Then Continue For
                ' flex.Cols(iLeftCol).Visible = True
                If drLevel.Item("DataType").ToString = "S" Then flex.Cols(sField).StyleDisplay.TextAlign = TextAlignEnum.LeftCenter
                If L3Int(drLevel.Item("RowMergeNum")) = 1 And L3Int(drLevel.Item("ColMergeNum")) = 1 Then 'Gắn caption cột không merge
                    flex.Rows(flex.Rows.Fixed - 1).Item(sField) = drLevel.Item("Caption").ToString
                    'If drLevel.Item("ColumnFormat").ToString = "Percent" Then
                    '    flex.Cols(sField).Format = "#,##0.00%"
                    'Else
                    If drLevel.Item("DataType").ToString = "N" Then flex.Cols(sField).Format = "N" & drLevel.Item("Decimals").ToString
                    'End If
                    flex.Cols(sField).Width = 50 + (30 * (L3Int(drLevel.Item("Length")) - 1))
                    Continue For
                End If
                'Merge cột
                Dim topRow As Integer = L3Int(drLevel.Item("Levels"))
                Dim BottomRow As Integer = L3Int(drLevel.Item("RowMergeNum"))
                iRightCol = L3Int(drLevel.Item("ColMergeNum"))
                If iRightCol = 1 And BottomRow = 1 Then Continue For 'Không merge dòng cột
                If iRightCol = 1 And BottomRow = 2 Then 'Chỉ merge dòng
                    iRightCol = iLeftCol 'Chỉ merge trên 1 cột
                    BottomRow = flex.Rows.Fixed - 1
                    If drLevel.Item("DataType").ToString = "N" Then
                        flex.Cols(iLeftCol).Format = "N" & drLevel.Item("Decimals").ToString
                        flex.Cols(iLeftCol).TextAlign = TextAlignEnum.LeftCenter
                        flex.Cols(iLeftCol).StyleDisplay.TextAlign = TextAlignEnum.LeftCenter
                    End If
                    flex.Cols(iLeftCol).Width = 50 + (30 * (L3Int(drLevel.Item("Length")) - 1))
                Else 'Chỉ merge trên 1 dòng
                    iRightCol += iLeftCol - 1
                    BottomRow = topRow
                End If
                flex.Cols(iLeftCol).AllowMerging = True
                If iRightCol >= flex.Cols.Count Then Return ""
                Dim rng As CellRange = flex.GetCellRange(topRow, iLeftCol, BottomRow, iRightCol)
                rng.Data = drLevel.Item("Caption").ToString
            Catch ex As Exception
                D99C0008.MsgL3(ex.Message)
            End Try
        Next
        Return sColEnd
    End Function

    Private Sub D13F2046_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
                Exit Sub
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
                Exit Sub
            Case Keys.F5
                btnFillter_Click(Nothing, Nothing)
                Exit Sub
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcPreSalaryVoucherID
        sSQL = "SELECT  '%'AS PreSalaryVoucherID, " & AllName & "  AS Description, '%' AS SalCalMethodID" & vbCrLf
        sSQL &= "UNION ALL " & vbCrLf
        sSQL &= "SELECT  SalaryVoucherID As PreSalaryVoucherID,  Isnull(Description" & UnicodeJoin(gbUnicode) & " , SalaryVoucherNo) As Description, SalCalMethodID" & vbCrLf
        sSQL &= "FROM D13T2600" & vbCrLf
        'sSQL &= "WHERE TranMonth = " & SQLNumber(giTranMonth - 1) & " AND TranYear =  " & SQLNumber(giTranYear) & vbCrLf
        sSQL &= "WHERE TranMonth + TranYear * 12 = " & SQLNumber(giTranMonth + giTranYear * 12 - 1) & vbCrLf
        sSQL &= "ORDER BY PreSalaryVoucherID"
        LoadDataSource(tdbcPreSalaryVoucherID, sSQL, gbUnicode)
        tdbcPreSalaryVoucherID.SelectedValue = "%"
    End Sub

    Private Sub ResetGrid()
        mnsExportToExcel.Enabled = flex.Rows.Count > flex.Rows.Fixed
    End Sub
    Private bLoadComplete As Boolean = True

    Private Sub D13F2046_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        LoadTDBCombo()
        InitFlexGrid()
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        '************************
        SetShortcutPopupMenu(Me, Nothing, ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub MergeRowFlex(ByVal flex As C1.Win.C1FlexGrid.C1FlexGrid, ByVal colBegin As Integer, ByVal colEnd As Integer, Optional ByVal topRow As Integer = 0, Optional ByVal bottomRow As Integer = 1)
        flex.AllowMerging = AllowMergingEnum.FixedOnly
        ' create col headers
        For i As Integer = colBegin To colEnd
            flex.Cols(i).AllowMerging = True
            Dim rng As C1.Win.C1FlexGrid.CellRange = flex.GetCellRange(topRow, i, bottomRow, i)
            rng.Data = flex.Cols(i).Caption
            flex.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
        Next
    End Sub

    Private Sub flxGrid_OwnerDrawCell(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles flex.OwnerDrawCell
        Try
            If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then Exit Sub
            If e.Row < flex.Rows.Fixed OrElse flex.DataSource Is Nothing Then Exit Sub 'Chỉ cho dòng dữ liệu
            Dim level As Integer = L3Int(flex(e.Row, COL_LevelID))
            If level = 1 Then
                e.Style.ForeColor = Color.Blue  'Cột tổng cộng
            Else
                e.Style.ForeColor = GetForeColor(e.Col, e.Row)
            End If
            flex.Styles.Fixed.ForeColor = Color.Black 'Chặn set màu cho caption
        Catch ex As Exception
            D99C0008.MsgL3("Error: " & ex.Message)
        End Try
    End Sub
    Private _ListCol() As DataRow

    Private Function GetForeColor(ByVal iCol As Integer, ByVal iRow As Integer) As Color
        Dim sColDynamic As String
        Dim iColMerge As Integer = 0
        Dim rng As C1.Win.C1FlexGrid.CellRange = flex.GetCellRange(iRow, iCol)
        If _ListCol.Length < 1 Then
            Return Color.Black
        Else
            For Each row As DataRow In _ListCol
                iColMerge = L3Int(row("ColMergeNum").ToString())
                sColDynamic = row("CaptionID").ToString().Trim() & "_0" & iColMerge + 1
                If dtGrid.Columns.IndexOf(sColDynamic) > 0 And L3Int(flex(iRow, sColDynamic).ToString()) = 1 Then
                    For i As Integer = 1 To iColMerge
                        If flex.Cols(iCol).Name = row("CaptionID").ToString().Trim() & "_0" & i Then
                            Return Color.Red
                        End If
                    Next
                End If
            Next
            Return Color.Black
        End If
    End Function

    Private Function GetFixRowFlexGird(ByVal dtCaption As DataTable) As Integer
        If dtCaption Is Nothing OrElse dtCaption.Rows.Count = 0 Then Return 1
        Return dtCaption.DefaultView.ToTable(True, "Levels").Rows.Count
    End Function
    Private Sub SetWithFlexGird(ByVal dtCaption As DataTable)
        If dtCaption Is Nothing OrElse dtCaption.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dtCaption.Rows.Count - 1
            Dim sFieldName As String = L3String(dtCaption.Rows(i).Item("FieldName"))
            If sFieldName <> "" AndAlso flex.Cols.Contains(sFieldName) Then
                flex.Cols(sFieldName).Width = 50 + (30 * (L3Int(dtCaption.Rows(i).Item("Length")) - 1))
            End If
        Next
        'flex.Cols(0).Width = 21
    End Sub
    Private Function LoadFlexGrid() As String
        Try
            flex.Rows(0).TextAlign = TextAlignEnum.CenterCenter
            flex.Styles.Fixed.WordWrap = True
            Dim dtCaption As DataTable = ReturnDataTable(SQLStoreD09P4121)
            'Merge header
            flex.Styles.Normal.WordWrap = True

            flex.Rows.Fixed = GetFixRowFlexGird(dtCaption)
            flex.Rows(flex.Rows.Fixed - 1).Height = 28
            flex.AllowMerging = AllowMergingEnum.FixedOnly
            ' create row headers
            For i As Integer = 0 To flex.Rows.Fixed - 1
                flex.Rows(i).AllowMerging = True
            Next

            Dim sColEnd As String = ""
            flex.AutoGenerateColumns = False
            sColEnd = LoadCaptionMerge(dtCaption)
            'Load DataSource

            flex.DataSource = dtGrid
            SetWithFlexGird(dtCaption) ' Set lại Width cho Columns
            '   flex.Cols(45).Width = 110
            '  flex.SetDataBinding(dtGrid, "", True)'Không có thanh trượt xuống, chậm 1 nhịp
            ''********************
            'If chkIsPeriodDetail.Checked Then 
            'MergeRowFlex(flex, flex.Cols.Fixed, flex.Cols.IndexOf(sColEnd), 0, flex.Rows.Fixed - 1)
            '****************************
            ResetGrid()
            Return sColEnd
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
        Return ""
    End Function

    Private Sub InitFlexGrid()
        'Grid left
        flex.Styles.ParseString("Alternate{BackColor:Beige;}") 'Đặt màu dòng chẵn
        flex.Rows(0).TextAlign = TextAlignEnum.CenterCenter 'Canh giữa header
        flex.Styles.Fixed.WordWrap = True
        Dim sFont As System.Drawing.Font = flex.Styles("Fixed").Font
        flex.Styles("Normal").Font = FontUnicode(gbUnicode)
        flex.Styles("Fixed").Font = sFont
        'flex.Col(0).w()
    End Sub


    Private Sub AddColums(ByVal dtCaption As DataTable)
        Dim col As C1.Win.C1FlexGrid.Column = flex.Cols.Add()
        col.Name = COL_LevelID
        col.Caption = COL_LevelID
        col.Visible = False
        For i As Integer = 0 To dtCaption.Rows.Count - 1
            Dim sField As String = L3String(dtCaption.Rows(i).Item("FieldName"))
            If sField = "" OrElse dtGrid.Columns.IndexOf(sField) < 0 Then Continue For
            col = flex.Cols.Add()
            col.Name = sField
            col.Caption = L3String(dtCaption.Rows(i).Item("Caption"))
            col.Visible = Not L3Bool(dtCaption.Rows(i).Item("IsVisible"))
            col.TextAlignFixed = TextAlignEnum.CenterCenter
            If L3String(dtCaption.Rows(i).Item("DataType")) = "N" Then
                col.TextAlign = TextAlignEnum.RightCenter
            ElseIf L3String(dtCaption.Rows(i).Item("DataType")) = "D" Then
                col.TextAlign = TextAlignEnum.CenterCenter
            End If
        Next
    End Sub


    Private usrOption As New D09U1113()
    Dim dtF12 As DataTable

    Private Sub VisibleCol()
        For i As Integer = 0 To flex.Cols.Count - 1
            If flex.Cols(i).Visible Then
                Dim dr() As DataRow = dtTmpCaption.Select("FieldName = " & SQLString(flex.Cols(i).Name))
                If dr.Length <= 0 Then Continue For
                flex.Cols(i).Visible = Not L3Bool(dr(0)("IsVisible"))
            End If
        Next
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing OrElse flex.DataSource Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(flex.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
        VisibleCol()
    End Sub

    Private Sub CallD99U1113(ByVal iRightCol As Integer)
        Dim arrColObligatory() As Object = {"DivisionID", "EmployeeID", "EmployeeName"}
        dtF12 = Nothing
        Dim colBegin As Integer = flex.Cols.IndexOf(COL_LevelID) + 1
        usrOption.AddColVisible(flex, dtF12, , arrColObligatory, colBegin)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1113(Me, flex, dtF12)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub mnsExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsExportToExcel.Click
        Dim frm As New D99F2223
        With frm
            .FormID = Me.Name
            .ModuleID = "13"
            .ExportTypeID = ""
            .FlexGrid = flex
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub chkShowALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowALL.CheckedChanged
        Dim strFillter As String = ""
        Dim sColDynamic As String = ""
        Dim _dr() As DataRow
        Try
            _dr = dtTmpCaption.Select("FieldName='' And ColMergeNum >=1")
            If _dr.Length < 1 Then
                Exit Sub
            Else
                Dim i As Integer = 0
                For Each row As DataRow In _dr
                    sColDynamic = row("CaptionID").ToString().Trim() & "_0" & L3Int(row("ColMergeNum").ToString()) + 1
                    If dtGrid.Columns.IndexOf(sColDynamic) = -1 Then Continue For
                    If i > 0 Then strFillter &= " Or "
                    strFillter &= sColDynamic & " = 1"
                    i += 1
                Next
            End If
            If chkShowALL.Checked Then
                dtGrid.DefaultView.RowFilter = ""
            Else
                dtGrid.DefaultView.RowFilter = strFillter & " Or LevelID = 1"
            End If
        Catch ex As Exception
            D99C0008.MsgL3("Error data: " & ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Private Sub btnFillter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFillter.Click
        'flex.DrawMode = DrawModeEnum.OwnerDraw
        Me.Cursor = Cursors.WaitCursor
        dtGrid = ReturnDataTable(SQLStoreD13P2046)
        'dtGrid = ReturnTableFilter(dtGrid, "EmployeeID ='114112' Or  EmployeeID ='' ", True)
        If dtGrid Is Nothing OrElse dtGrid.Rows.Count < 1 Then Exit Sub
        Dim sColEndMergeRow As String = LoadFlexGrid()
        CallD99U1113(flex.Cols.IndexOf(sColEndMergeRow))
        chkShowALL_CheckedChanged(Nothing, Nothing)
        Me.Cursor = Cursors.Default
        bLoadComplete = True
        'flex.DrawMode = DrawModeEnum.Normal
    End Sub
End Class