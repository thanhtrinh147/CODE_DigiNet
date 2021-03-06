'#------------------------------------------------------
'# Title: D09U1111
'# Created User: Đỗ Minh Dũng
'# Created Date: 28/07/2009 01:56:52
'# ModifiedUser: Minh Hòa
'# ModifiedDate: 16/02/2012 01:56:52
'# Description: UserControl D09U1111 dùng để hiển thị các cột trên lưới do người dùng tự chọn
'# Bổ sung cột UserID cho bảng D91T2022
'# Bổ sung Unicode
'# Sửa: bổ sung  vào Sub New các tham số: sMode (theo phân tích quy định cho lưới có nút Hiển thị chi tiết) 
'       bStatusSave (mờ nút Lưu), bLoadFirst (= true: load lần đầu tại form_Load; = False: load ở các chỗ khác)
'#------------------------------------------------------
Imports System.Text
Imports System
Public Class D09U1111

#Region "Const of tdbg"
    Private Const COL_IsUsed As Integer = 0      ' Chọn
    Private Const COL_Description As Integer = 1 ' Tên cột
    Private Const COL_OrderNum As Integer = 2    ' OrderNum
    Private Const COL_ModuleID As Integer = 3    ' ModuleID
    Private Const COL_FormID As Integer = 4      ' FormID
    Private Const COL_FieldName As Integer = 5   ' FieldName
    Private Const COL_Obligatory As Integer = 6  ' Cột bắt buộc nhập
#End Region

    Private tdbgO As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private _formID As String
    Private _moduleID As String
    Private _mode As String
    Private MyTable As DataTable
    Private _Unicode As Boolean = False
    Private _ButtonNew As Boolean = False

    Public Sub New(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dt As DataTable, ByVal sModuleID As String, ByVal sFormID As String, _
    Optional ByVal sMode As String = "", Optional ByVal bStatusSave As Boolean = True, Optional ByVal bLoadFirst As Boolean = True, Optional ByVal bUseTemplateInquiry As Boolean = False, _
    Optional ByVal bUseUnicode As Boolean = False, Optional ByVal bButtonNew As Boolean = False)

        ' This call is required by the Windows Form Designer. 
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call. 
        'picClose.Image = My.Resources.Close
        giRefreshUserControl = -1
        tdbgO = c1Grid

        MyTable = dt.Copy
        _formID = sFormID
        _moduleID = sModuleID
        _mode = sMode
        _Unicode = bUseUnicode
        _ButtonNew = bButtonNew

        'Nếu đã sử dụng Mẫu template thì không lấy dữ liệu trong bảng D91T2022
        If Not bUseTemplateInquiry Then
            Dim sSQL As String = ""
            sSQL = "Select Distinct " & IIf(_Unicode, "FieldNameU", "FieldName").ToString & " as FieldName, cast(0 as bit) As IsUsed" & vbCrLf
            sSQL &= "From D91T2022" & vbCrLf
            sSQL &= "WHERE ModuleID = " & SQLString(_moduleID) & " And FormID = " & SQLString(_formID)
            sSQL &= " And Mode = " & SQLString(_mode)
            If _Unicode Then
                sSQL &= " And FieldNameU <>''"
            Else
                sSQL &= " And FieldName <>''"
            End If
            'Update 16/02/2012: Incident 
            sSQL &= " And UserID = " & SQLString(gsUserID)

            Dim dtMerge As DataTable = ReturnDataTable(sSQL)
            If dtMerge.Rows.Count > 0 Then
                dtMerge.PrimaryKey = New DataColumn() {dtMerge.Columns("FieldName")}
                For Each dr As DataRow In MyTable.Rows 'OBLIGATORY
                    If dr("Obligatory").ToString <> "1" Then
                        If dtMerge.Rows.Find(dr("FieldName")) IsNot Nothing Then
                            dr("IsUsed") = False
                        End If
                    End If
                Next
            End If
        End If
        '*******************************************
        LoadDataSource(tdbg, MyTable, _Unicode)
        '*******************************************
        'Co dãn cột Description -> Lưới -> UserControl, set vị trí các nút 
        tdbg.Splits(0).DisplayColumns(1).Width = giMaxLengthColumnCaption * 7

        tdbg.Width = tdbg.Splits(0).DisplayColumns(0).Width + tdbg.Splits(0).DisplayColumns(1).Width + 60
        Me.Size = New Size(tdbg.Width + 20, Me.Height)
        btnSave.Location = New Point(tdbg.Right - btnSave.Width, btnSave.Top)
        picClose.Location = New Point(tdbg.Right - picClose.Width, picClose.Top)
        btnRefresh.Location = New Point(btnSave.Left - (btnRefresh.Width + 10), btnRefresh.Top)
        'Hiển thị nút Save
        btnSave.Enabled = bStatusSave

        LoadLanguage()

        '******************KHỞI TẠO mảng vc******************
        'Update 18/03/2010
        If bLoadFirst Then
            ReDim vcNew(tdbgO.Columns.Count - 1, tdbgO.Splits.ColCount - 1)
            For j As Integer = 0 To tdbgO.Splits.ColCount - 1
                For i As Integer = 0 To tdbgO.Columns.Count - 1
                    vcNew(i, j).ColFieldName = tdbgO.Columns(i).DataField
                    'vcNew(i, j).ColVisible = tdbgO.Splits(j).DisplayColumns(i).Visible
                    vcNew(i, j).ColVisible = tdbgO.Splits(j).DisplayColumns(tdbgO.Columns(i).DataField).Visible
                Next i
                'Ghi nhận split size 
                matrix(j, 0) = tdbgO.Splits(j).SplitSize
                matrix(j, 1) = tdbgO.Splits(j).SplitSizeMode
            Next j
        End If
        '********************************************************
        btnRefresh_Click(Nothing, Nothing)
        SetResolutionForm(Me)
    End Sub

    Private Sub D09U1111_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'cho Focus vào lưới (vì sự kiện VisibleChanged k activate ở lần đầu usrctrl show)
        D09U1111_VisibleChanged(Nothing, Nothing)
    End Sub

    Public Sub D09U1111Refresh()
        If Not IsChoosedOnGrid(tdbg, SPLIT0, COL_IsUsed) Then Exit Sub


        'ĐỒNG BỘ HÓA VISIBLE COLUMN GIỮA tdbg và tdbgO
        'Update 18/03/2010: Duyệt ẩn tất cả các cột trên lưới
        If Not _ButtonNew Then ' Update 15/09/2011:  Nếu làm theo dạng Button mới thì không cần ẩn các cột trên lưới
            For j As Integer = 0 To tdbgO.Splits.ColCount - 1
                For i As Integer = 0 To tdbgO.Columns.Count - 1
                    tdbgO.Splits(j).DisplayColumns(i).Visible = False
                Next
                'Update 12/10/2010: Gán lại Mode cho split
                tdbgO.Splits(0).SplitSizeMode = CType(matrix(j, 1), C1.Win.C1TrueDBGrid.SizeModeEnum)
            Next
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            VisibleEachColOnSplit(tdbg(i, COL_FieldName).ToString, CBool(tdbg(i, COL_IsUsed)))
        Next i

        'CHỈNH LẠI SPLITSIZE CỦA LƯỚI, XỬ LÝ CHO 2 TH
        Dim iTotalSplitSize As Integer = 0
        Dim iFirstCol As Integer = -1
        With tdbgO
            If tdbgO.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact Then
                'Set size cho từng split
                For i As Integer = 0 To .Splits.ColCount - 1
                    .Splits(i).SplitSize = 0
                    .Splits(i).ExtendRightColumn = False
                    For j As Integer = 0 To .Columns.Count - 1
                        If .Splits(i).DisplayColumns(j).Visible And .Splits(i).SplitSize <= CInt(matrix(i, 0)) Then
                            If iFirstCol = -1 Then iFirstCol = j
                            .Splits(i).SplitSize += .Splits(i).DisplayColumns(j).Width
                        End If
                    Next j

                    'Cộng thêm cho split 0
                    If i = 0 AndAlso .Splits(i).SplitSize > 0 Then
                        .Splits(i).SplitSize += 20
                    End If

                    'Xử lý HScrollBar
                    If .Splits(i).SplitSize = 0 Then
                        .Splits(i).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.None
                    Else
                        .Splits(i).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                    End If

                    iTotalSplitSize += .Splits(i).SplitSize
                Next i
                'Set lại cột để ScrollBar kéo về đầu
                If .Splits.Count = 1 Then .Col = iFirstCol

                'Kéo dài split cuối và cột cuối
                If iTotalSplitSize < .Width Then
                    For i As Integer = .Splits.ColCount - 1 To 0 Step -1
                        'Tim split cuối có hiển thị
                        If .Splits(i).SplitSize > 0 Then
                            .Splits(i).SplitSize += .Width - iTotalSplitSize
                            .Splits(i).ExtendRightColumn = True
                            Exit For
                        End If
                    Next
                End If
            Else
                Dim bSplitDisable As Boolean = False

                For i As Integer = 0 To .Splits.ColCount - 1
                    Dim bVisible As Boolean = False
                    For j As Integer = 0 To .Columns.Count - 1
                        If .Splits(i).DisplayColumns(j).Visible Then
                            If iFirstCol = -1 Then iFirstCol = j
                            bVisible = True
                            Exit For
                        End If
                    Next j

                    If Not bVisible Then
                        .Splits(i).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
                        .Splits(i).SplitSize = 0
                        .Splits(i).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.None
                        bSplitDisable = True
                    Else
                        .Splits(i).SplitSizeMode = CType(matrix(i, 1), C1.Win.C1TrueDBGrid.SizeModeEnum) '.Splits(i).SplitSizeMode 'C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                        .Splits(i).SplitSize = matrix(i, 0) 'CInt(arSplitSize(i))
                        .Splits(i).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always

                    End If

                    iTotalSplitSize += .Splits(i).SplitSize

                    'Tim split cuối có hiển thị
                    If i = .Splits.ColCount - 1 Then
                        If .Splits(i).SplitSize > 0 And bSplitDisable Then
                            .Splits(i).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable
                        End If
                    End If
                Next i
                'Set lại cột để ScrollBar kéo về đầu
                If .Splits.Count = 1 Then .Col = iFirstCol
            End If
        End With

        If giRefreshUserControl = 0 Then
            'Lọc đưa vào xuất excel
            gdtCaptionExcel = ReturnTableFilter(MyTable, "IsUsed = True", True)
            giRefreshUserControl = 1
        End If

        'Update 15/09/2011
        'Kéo cột về bên trái để khỏi có màu xám
        ' tdbgO.LeftCol = tdbgO.Col
        tdbgO.Splits(tdbgO.SplitIndex).LeftCol = tdbgO.Col 'Bị lỗi D25F2000
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        D09U1111Refresh()
        'Lọc đưa vào xuất excel
        If giRefreshUserControl <> 1 Then
            gdtCaptionExcel = ReturnTableFilter(MyTable, "IsUsed = True", True)
            giRefreshUserControl = 1
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T2022
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 28/07/2009 01:55:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T2022() As String
        Dim sSQL As String = ""
        sSQL &= "Delete D91T2022"
        sSQL &= " Where ModuleID = " & SQLString(_moduleID) & " And FormID = " & SQLString(_formID) & vbCrLf
        sSQL &= " And Mode = " & SQLString(_mode)
        If _Unicode Then
            sSQL &= " And FieldNameU <> ''"
        Else
            sSQL &= " And FieldName <> ''"
        End If
        sSQL &= " And UserID = " & SQLString(gsUserID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T2022s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 28/07/2009 01:56:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T2022s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If Not CBool(tdbg(i, COL_IsUsed)) Then
                sSQL.Append("Insert Into D91T2022(")
                sSQL.Append("ModuleID, FormID, FieldName, FieldNameU, UserID, Mode")
                sSQL.Append(") Values(" & vbCrLf)
                sSQL.Append(SQLString(_moduleID) & COMMA) 'ModuleID, int, NULL
                sSQL.Append(SQLString(_formID) & COMMA) 'FormID, varchar[10], NULL
                If _Unicode Then
                    sSQL.Append("''" & COMMA) 'FieldName, varchar[50], NULL
                    sSQL.Append("N" & SQLString(tdbg(i, COL_FieldName)) & COMMA) 'FieldNameU, varchar[50], NULL
                Else
                    sSQL.Append(SQLString(tdbg(i, COL_FieldName)) & COMMA) 'FieldName, varchar[50], NULL
                    sSQL.Append("N''" & COMMA) 'FieldNameU, varchar[50], NULL
                End If
                sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[10], NULL
                sSQL.Append(SQLString(_mode)) 'Mode,  varchar[50], NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        If Not IsChoosedOnGrid(tdbg, SPLIT0, COL_IsUsed) Then Exit Sub

        btnSave.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD91T2022() & vbCrLf)
        sSQL.Append(SQLInsertD91T2022s())

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnRefresh_Click(Nothing, Nothing)
        Else
            SaveNotOK()
        End If
        btnSave.Enabled = True
    End Sub

    Private Sub picClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picClose.Click
        If giRefreshUserControl = 0 Then
            If D99C0008.MsgAsk(r("Thong_tin_tren_luoi_da_thay_doi_ban_co_muon_Refresh_lai_khong")) = Windows.Forms.DialogResult.Yes Then
                tdbg.UpdateData()
                D09U1111Refresh()
            End If
        End If
        tdbgO.Focus()

        Me.Hide()
    End Sub

    Private Sub LoadLanguage()
        lbl1.Text = r("Chon_cot_hien_thi")
        tdbg.Columns("IsUsed").Caption = r("Chon")
        tdbg.Columns("Description").Caption = r("Ten_cotU")
        btnSave.Text = r("_Luu")
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        If tdbg.Columns(COL_Obligatory).Text = "1" Then
            e.Cancel = True
        End If
        giRefreshUserControl = 0
    End Sub

    Dim bHeadClick As Boolean
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If e.ColIndex = COL_IsUsed Then
            giRefreshUserControl = 0
            GridHead_Click()
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            If tdbg.Col = COL_IsUsed Then
                GridHead_Click()
            End If
        Else
            HotKeyDownGrid(e, tdbg, COL_IsUsed)
        End If
    End Sub

    Private Sub GridHead_Click()
        bHeadClick = Not bHeadClick
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_Obligatory).ToString <> "1" Then
                tdbg(i, COL_IsUsed) = bHeadClick
            End If
        Next i
    End Sub

    Private Sub D09U1111_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        'FOCUS VÀO LƯỚI MỖI KHI D09U1111 VISIBLE
        If Me.Visible Then
            tdbg.SplitIndex = 0
            tdbg.Col = 0
            tdbg.Row = 0
            tdbg.Focus()
        End If
    End Sub

    Private Function IsChoosedOnGrid(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iSplitIndex As Integer, ByVal iCol As Integer) As Boolean
        Dim k As Integer
        Dim b As Boolean = False
        For k = 0 To tdbg.RowCount - 1
            If CBool(tdbg(k, iCol)) Then
                b = True
                Exit For
            End If
        Next k

        'If k >= tdbg.RowCount - 1 Then
        If b = False Then
            D99C0008.MsgL3(r("MSG000010"))
            tdbg.Col = iCol
            tdbg.Row = 0
            tdbg.SplitIndex = iSplitIndex
            If tdbg.Splits(iSplitIndex).MarqueeStyle <> C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor Then tdbg.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Đánh dấu Cột nào k hiển thị cho mảng vc (chỉ có mh chính gọi hàm này)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MarkInvisibleColumn(ByVal iSplit As Integer)
        For i As Integer = 0 To tdbgO.Columns.Count - 1
            'vc(i, iSplit).ColVisible = tdbgO.Splits(iSplit).DisplayColumns(i).Visible
            vcNew(i, iSplit).ColVisible = tdbgO.Splits(iSplit).DisplayColumns(i).Visible
        Next i
    End Sub

    Private Sub VisibleEachColOnSplit(ByVal sFieldName As String, ByVal bChoose As Boolean)
        'Update 14/10/2010
        Dim vcNewLength As Integer = 0
        If tdbgO.Splits.ColCount > 1 Then
            vcNewLength = CInt(vcNew.Length / 2)
        Else
            vcNewLength = CInt(vcNew.Length)
        End If

        For i As Integer = 0 To vcNewLength - 1

            If vcNew(i, 0).ColFieldName = sFieldName Then
                For j As Integer = 0 To tdbgO.Splits.ColCount - 1
                    'With tdbgO.Splits(j).DisplayColumns(i)
                    With tdbgO.Splits(j).DisplayColumns(vcNew(i, 0).ColFieldName)
                        If vcNew(i, j).ColVisible Then
                            .Visible = bChoose
                            Select Case sFieldName
                                '   Case "DivisionID", "DivisionName", "BlockID", "BlockName", "DepartmentID", "DepartmentName", "TeamID", "TeamName"
                                Case "DivisionID", "BlockID", "DepartmentID", "TeamID"
1:
                                    If .Visible AndAlso (tdbgO.AllowUpdate = False OrElse .Locked) Then
                                        .Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Restricted
                                    Else
                                        .Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
                                    End If
                                Case "DivisionName", "BlockName", "DepartmentName", "TeamName"
                                    'Update 16/03/2012: gắn Try Catch bỏ qua lỗi: Dùng cho lưới có cột Name mà không có cột ID
                                    Try
                                        Dim sFielID As String = sFieldName.Replace("Name", "ID")
                                        If tdbgO.Columns.IndexOf(tdbgO.Columns(sFielID)) >= 0 And tdbgO.Splits(j).DisplayColumns(sFielID).Visible Then 'Có tồn tại cột ID
                                            .Merge = tdbgO.Splits(j).DisplayColumns(sFielID).Merge
                                        Else
                                            GoTo 1
                                        End If
                                    Catch ex As Exception
                                        
                                    End Try
                            End Select
                            Exit For 'Một cột chỉ được hiển thị tại 1 split, nên tìm được cột này thì k cần xét tiếp
                        Else
                            .Visible = False
                        End If
                    End With
                Next j
                Exit For
            End If
        Next i
    End Sub

    Private Sub tdbg_OwnerDrawCell(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.OwnerDrawCellEventArgs) Handles tdbg.OwnerDrawCell

        If tdbg(e.Row, COL_Obligatory).ToString = "0" Then Exit Sub

        Dim objPen As New Pen(Color.FromName("Green"))
        Dim pt As New Point()
        Dim X As Integer = e.CellRect.X + L3Int(FormatNumber(((e.CellRect.Width - 11) / 2), 0)) - 2
        Dim rect As New Rectangle(X, e.CellRect.Y + 2, 12, e.CellRect.Height - 5) '(X,Y)(width, Height)

        'Update 31/05/2010
        If e.Row Mod 2 = 0 Then
            e.Graphics.FillRectangle(Brushes.White, e.CellRect)
        Else
            e.Graphics.FillRectangle(Brushes.Beige, e.CellRect)
        End If
        e.Graphics.FillRectangle(Brushes.DarkGray, rect)
        e.Graphics.DrawRectangle(objPen, rect)

        'The commented out line below causes a red checkmark to be drawn in the topmost cell only of the column
        pt.X = e.CellRect.X + L3Int(FormatNumber((e.CellRect.Width / 2), 0)) - 5 '3
        'No red checkmark is drawn in any cell in the column using the Y-cord below
        pt.Y = rect.Y + 5 'e.CellRect.Y + L3Int(((e.CellRect.Height - 11) / 2)) - 5

        'Lines moving downward left to right--left side of check (The checkmark is 3 lines thick)
        e.Graphics.DrawLine(objPen, pt.X, pt.Y + 0, pt.X + 2, pt.Y + 2)
        e.Graphics.DrawLine(objPen, pt.X, pt.Y + 1, pt.X + 2, pt.Y + 3)
        e.Graphics.DrawLine(objPen, pt.X, pt.Y + 2, pt.X + 2, pt.Y + 4)
        'Lines moving upward left to right--right side of check
        e.Graphics.DrawLine(objPen, pt.X + 2, pt.Y + 2, pt.X + 6, pt.Y - 2)
        e.Graphics.DrawLine(objPen, pt.X + 2, pt.Y + 3, pt.X + 6, pt.Y - 1)
        e.Graphics.DrawLine(objPen, pt.X + 2, pt.Y + 4, pt.X + 6, pt.Y - 0)

        e.Handled = True

    End Sub

    'Mẫu truy vấn
    Friend Sub ShowForm(ByVal tdbgO As C1.Win.C1TrueDBGrid.C1TrueDBGrid, Optional ByVal iSplit As Integer = 0, Optional ByVal ArrColObl() As String = Nothing)
        If btnSave.Enabled = False Then btnRefresh.Left = btnSave.Left

        Dim dt As DataTable = CType(tdbg.DataSource, DataTable)
        dt.PrimaryKey = New DataColumn() {dt.Columns("FieldName")}
        For Each dc As C1.Win.C1TrueDBGrid.C1DisplayColumn In tdbgO.Splits(iSplit).DisplayColumns
            Dim dr As DataRow = dt.Rows.Find(dc.DataColumn.DataField)
            If dr Is Nothing Then Continue For 'Không tồn tại field này
            'Thiên Huỳnh Edit 23/09/2010
            'Chú ý: không dùng tdbgO.GroupedColumns.IndexOf(dc.DataColumn) <> -1 để kiểm tra, những cột Group có thể cùng tên Caption nhưng khác FieldName
            'Những cột Group có thể cùng tên Caption nhưng khác FieldName (VD: Level01, ...) 
            'If tdbgO.GroupedColumns.IndexOf(dc.DataColumn) <> -1 Then 'Là cột Group
            For j As Integer = 0 To tdbgO.GroupedColumns.Count - 1
                If tdbgO.GroupedColumns(j).Caption.Trim = dr("Description").ToString.Trim OrElse tdbgO.GroupedColumns(j).DataField = dr("FieldName").ToString Then
                    dr.Item("IsUsed") = 1
                    dr.Item("Obligatory") = 1 ' Group là Bắt buộc nhập
                    Exit For
                Else
                    'Nếu trên lưới tdbgO bỏ Group thì Set lại giá trị bắt buộc nhập = 0
                    'If Not CheckInGroup(tdbgO, dc.Name) Then
                    If ArrColObl IsNot Nothing AndAlso ArrColObl.Length > 0 Then
                        If Not L3FindArrString(ArrColObl, dc.DataColumn.DataField) Then dr.Item("Obligatory") = 0 ' Không Bắt buộc nhập
                    End If
                    'End If
                End If
            Next
        Next
    End Sub

    'Private Function CheckInGroup(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sCaptionName As String) As Boolean
    '    'Kiểm tra Caption hiện tại là Group
    '    For Each dc As C1.Win.C1TrueDBGrid.C1DataColumn In c1Grid.GroupedColumns
    '        If dc.Caption = sCaptionName Then
    '            Return True
    '        End If
    '    Next
    '    Return False
    'End Function

End Class

