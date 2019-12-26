Public Class D45F2051

    Private _productAddID As String = ""
    Public WriteOnly Property ProductAddID As String
        Set(ByVal Value As String)
            _productAddID = Value
        End Set
    End Property

    Private _partProductID As String = ""
    Public WriteOnly Property PartProductID As String
        Set(ByVal Value As String)
            _partProductID = Value
        End Set
    End Property
    
    Private _partProductName As String = ""
    Public WriteOnly Property PartProductName As String
        Set(ByVal Value As String)
            _partProductName = Value
        End Set
    End Property

    Private _SumQuantity As Double = 0
    Public WriteOnly Property SumQuantity As Double
        Set(ByVal Value As Double)
            _sumQuantity = Value
        End Set
    End Property

    Private _dtGrid As DataTable
    Public Property dtGrid As DataTable
        Get
            Return _dtGrid
        End Get
        Set(ByVal Value As DataTable)
            _dtGrid = Value
        End Set
    End Property

    Private _dtDataDetail As DataTable
    Public WriteOnly Property dtDataDetail As DataTable
        Set(ByVal Value As DataTable)
            _dtDataDetail = Value
        End Set
    End Property

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Dim dtGrid1 As DataTable

#Region "Const of tdbg - Total of Columns: 6"
    Private Const COL_Choose As String = "Choose"                   ' Chọn
    Private Const COL_OrderNum As Integer = 1                       ' STT
    Private Const COL_PartProductID As String = "PartProductID"     ' PartProductID
    Private Const COL_PartProductName As String = "PartProductName" ' Tên tiểu tác
    Private Const COL_PPUnitPrice As String = "PPUnitPrice"         ' Đơn giá
    Private Const COL_PPNorm As String = "PPNorm"                   ' Định mức
#End Region

#Region "Const of tdbg1 - Total of Columns: 11"
    Private Const COL1_PartProductID As String = "PartProductID"         ' PartProductID
    Private Const COL1_OrderNum As String = "OrderNum"                   ' STT
    Private Const COL1_EmployeeID As String = "EmployeeID"               ' Mã NV
    Private Const COL1_EmployeeName As String = "EmployeeName"           ' Họ và tên
    Private Const COL1_DepartmentID As String = "DepartmentID"           ' DepartmentID
    Private Const COL1_TeamID As String = "TeamID"                       ' TeamID
    Private Const COL1_EmpQuantity As String = "EmpQuantity"             ' Sản lượng
    Private Const COL1_TotalTime As String = "TotalTime"                 ' Tổng thời gian
    Private Const COL1_EmpAmount As String = "EmpAmount"                 ' Thành tiền
    Private Const COL1_IsEmpOutsideStage As String = "IsEmpOutsideStage" ' IsEmpOutsideStage
    Private Const COL1_EmpPartProductID As String = "EmpPartProductID"   ' EmpPartProductID
#End Region
    Private Sub D45F2051_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If _dtDataDetail IsNot Nothing Then _dtDataDetail.Dispose()
        If _dtGrid IsNot Nothing Then _dtGrid.Dispose()
        If dtGrid1 IsNot Nothing Then dtGrid1.Dispose()
    End Sub
    Private Sub D45F2051_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
        End Select
    End Sub
    Private Sub D45F2051_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral()
        ResetFooterGrid(tdbg, tdbg1)
        SetBackColorObligatory()
        LoadLanguage()
        tdbg_LockedColumns()
        tdbg1_LockedColumns()
        tdbg_NumberFormat()
        tdbg1_NumberFormat()
        LoadData()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Sao_chep_nhan_vien_tu_tieu_tac") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Sao chÏp nh¡n vi£n tô tiÓu tÀc
        '================================================================ 
        lblPartProductName.Text = rL3("Sao_chep_tu_tieu_tac") 'Sao chép từ tiểu tác
        lblSelect.Text = rL3("Chon_cac_tieu_tac_can_sao_chep") 'Chọn các tiểu tác cần sao chép
        lblSumQuantity.Text = rL3("San_luong") 'Sản lượng
        lblEmpQuantity.Text = rL3("San_luong_can_thuc_hien") 'Sản lượng cần thực hiện
        '================================================================ 
        btnCopy.Text = rL3("_Sao_chep") '&Sao chép
        '================================================================ 
        tdbg.Columns(COL_Choose).Caption = rL3("Chon") 'Chọn
        tdbg.Columns(COL_OrderNum).Caption = rL3("STT") 'STT
        tdbg.Columns(COL_PartProductName).Caption = rL3("Ten_tieu_tac") 'Tên tiểu tác
        tdbg.Columns(COL_PPUnitPrice).Caption = rL3("Don_gia") 'Đơn giá
        tdbg.Columns(COL_PPNorm).Caption = rL3("Dinh_muc") 'Định mức
        tdbg1.Columns(COL1_OrderNum).Caption = rL3("STT") 'STT
        tdbg1.Columns(COL1_EmployeeID).Caption = rL3("Ma_NV") 'Mã NV
        tdbg1.Columns(COL1_EmployeeName).Caption = rL3("Ho_va_ten") 'Họ và tên
        tdbg1.Columns(COL1_EmpQuantity).Caption = rL3("San_luong") 'Sản lượng
        tdbg1.Columns(COL1_TotalTime).Caption = rL3("Tong_thoi_gian") 'Tổng thời gian
        tdbg1.Columns(COL1_EmpAmount).Caption = rL3("Thanh_tien") 'Thành tiền
    End Sub
    Private Sub SetBackColorObligatory()
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_EmpQuantity).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PartProductName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PPUnitPrice).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PPNorm).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub tdbg1_LockedColumns()
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_EmployeeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_TotalTime).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_EmpAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_PPUnitPrice).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_PPNorm).NumberFormat = DxxFormat.DefaultNumber2
    End Sub
    Private Sub tdbg1_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddNumberColumns(arr, SqlDbType.Int, COL1_EmpQuantity, DxxFormat.DefaultNumber0)
        AddDecimalColumns(arr, tdbg1.Columns(COL1_TotalTime).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg1.Columns(COL1_EmpAmount).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbg1, arr)
    End Sub
    Private Sub LoadData()
        lblPartProductName.Text = rL3("Sao_chep_tu_tieu_tac") & ": " & _partProductName
        cneSumQuantity.Value = Number(_SumQuantity, DxxFormat.DefaultNumber0)
        '**************************
        ResetDataGrid1()
        LoadTDBGrid()
    End Sub
    Private Sub ResetDataGrid1()
        For i As Integer = 0 To _dtDataDetail.Rows.Count - 1 'Reset lại khoá chính = rỗng
            _dtDataDetail.Rows(i).Item(COL1_EmpPartProductID) = ""
            _dtDataDetail.Rows(i).Item(COL1_PartProductID) = ""
        Next
    End Sub
    Private Sub LoadTDBGrid()
        'Add cot Choose để chọn dòng
        Dim c1 As New DataColumn(COL_Choose, System.Type.GetType("System.Boolean"))
        _dtGrid.Columns.Add(c1)
        '*******************
        _dtGrid.DefaultView.RowFilter = COL_PartProductID & " <> " & SQLString(_partProductID)
        _dtGrid = _dtGrid.DefaultView.ToTable
        For i As Integer = 0 To _dtGrid.Rows.Count - 1
            _dtGrid.Rows(i).Item(COL_Choose) = 0
        Next
        '*******************
        LoadDataSource(tdbg, _dtGrid, gbUnicode)
        ResetGrid()
    End Sub
    Private Sub ReLoadTDBGrid()
        _dtGrid.AcceptChanges()
        Dim strFind As String = ""
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        If strFind <> "" Then strFind = COL_Choose & "=True" & " Or " & strFind

        _dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub
    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_PartProductName)
    End Sub
    Private Sub LoadTDBGrid1(Optional iRow As Integer = -1)
        If _dtDataDetail.Columns.Contains(COL1_OrderNum) = False Then
            Dim c1 As New DataColumn(COL1_OrderNum, System.Type.GetType("System.Int32"))
            _dtDataDetail.Columns.Add(c1)
        End If
        If _dtDataDetail.Columns.Contains(COL_PPNorm) = False Then
            Dim c1 As New DataColumn(COL_PPNorm, System.Type.GetType("System.Decimal"))
            _dtDataDetail.Columns.Add(c1)
        End If
        If _dtDataDetail.Columns.Contains(COL_PPUnitPrice) = False Then
            Dim c1 As New DataColumn(COL_PPUnitPrice, System.Type.GetType("System.Decimal"))
            _dtDataDetail.Columns.Add(c1)
        End If
        '*******************
        Dim dt As DataTable = _dtDataDetail.DefaultView.ToTable
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item(COL1_EmpPartProductID) = ""
            If iRow = -1 Then
                dt.Rows(i).Item(COL1_PartProductID) = tdbg.Columns(COL_PartProductID).Text
                dt.Rows(i).Item(COL1_OrderNum) = tdbg.Columns(COL_OrderNum).Text
                dt.Rows(i).Item(COL_PPNorm) = tdbg.Columns(COL_PPNorm).Text
                dt.Rows(i).Item(COL_PPUnitPrice) = tdbg.Columns(COL_PPUnitPrice).Text
            Else
                dt.Rows(i).Item(COL1_PartProductID) = tdbg(iRow, COL_PartProductID).ToString
                dt.Rows(i).Item(COL1_OrderNum) = tdbg(iRow, COL_OrderNum).ToString
                dt.Rows(i).Item(COL_PPNorm) = tdbg(iRow, COL_PPNorm).ToString
                dt.Rows(i).Item(COL_PPUnitPrice) = tdbg(iRow, COL_PPUnitPrice).ToString
            End If
        Next
        dt.AcceptChanges()
        '******************
        tdbg1.UpdateData()
        If dtGrid1 Is Nothing OrElse dtGrid1.Rows.Count = 0 Then
            dtGrid1 = dt.DefaultView.ToTable
        Else
            If dt.Rows.Count > 0 Then
                dtGrid1.PrimaryKey = New DataColumn() {dtGrid1.Columns(COL1_PartProductID), dtGrid1.Columns(COL1_EmployeeID)}
                dtGrid1.Merge(dt, True, MissingSchemaAction.AddWithKey)
            End If
        End If
        LoadDataSource(tdbg1, dtGrid1, gbUnicode)
        CreateConvertExpression(dtGrid1, COL1_EmpQuantity, COL_PPNorm, COL1_TotalTime)
        CreateConvertExpression(dtGrid1, COL1_TotalTime, COL_PPUnitPrice, COL1_EmpAmount)
        '**********************
        ResetGrid1()
        dt.Dispose()
    End Sub
    Private Sub RemoveRowGrid1(Optional iRow As Integer = -1)
        tdbg1.UpdateData()
        Dim sPartProductID As String = IIf(iRow = -1, tdbg.Columns(COL_PartProductID).Text, tdbg(iRow, COL_PartProductID).ToString).ToString
        Dim dr() As DataRow = dtGrid1.Select(COL_PartProductID & " = " & SQLString(sPartProductID))
        If dr.Length = 0 Then Exit Sub
        For i As Integer = dr.Length - 1 To 0 Step -1
            dtGrid1.Rows.Remove(dr(i))
        Next

        dtGrid1.AcceptChanges()
        tdbg1.UpdateData()
        ResetGrid1()
    End Sub
    Private Sub ResetGrid1()
        tdbg1.UpdateData()
        FooterTotalGrid(tdbg1, COL1_EmployeeID)
        FooterSumNew(tdbg1, COL1_EmpQuantity, COL1_TotalTime, COL1_EmpAmount)
    End Sub
    Private Sub CreateConvertExpression(ByVal dt As DataTable, ByVal sInput1 As String, ByVal sInput2 As String, ByVal sOutput As String)
        dt.Columns(sOutput).Expression = "IsNull (" & sInput1 & ",0) " & " * " & "IsNull (" & sInput2 & ",0) "
        dt.AcceptChanges()
    End Sub

#Region "tdbg"
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        If tdbg.FilterActive Then Exit Sub
        Select Case tdbg.Columns(e.ColIndex).DataField
            Case COL_Choose
                'tdbg.UpdateData()
                If L3Bool(tdbg.Columns(COL_Choose).Text) Then
                    LoadTDBGrid1()
                Else
                    RemoveRowGrid1()
                End If
        End Select
        tdbg.UpdateData()
        ResetGrid()
    End Sub
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = IndexOfColumn(tdbg, COL_Choose) Then HotKeyEnterGrid(tdbg, IndexOfColumn(tdbg, COL_Choose), e)
        End If
    End Sub
    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub
    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If L3Bool(tdbg(e.Row, COL_Choose)) Then
            e.CellStyle.ForeColor = Color.Blue
        End If
    End Sub
#End Region

    Dim bSelect As Boolean = False
    Private Sub HeadClick(iCol As Integer)
        Select Case tdbg.Columns(iCol).DataField
            Case COL_Choose
                L3HeadClick(tdbg, IndexOfColumn(tdbg, COL_Choose), bSelect)
                '****************************
                For i As Integer = 0 To tdbg.RowCount - 1
                    If bSelect Then
                        LoadTDBGrid1(i)
                    Else
                        RemoveRowGrid1(i)
                    End If
                Next
        End Select
    End Sub

#Region "tdbg1"
    Private Sub tdbg1_AfterColUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.AfterColUpdate
        Select Case tdbg1.Columns(e.ColIndex).DataField
            Case COL1_EmpQuantity
                'CalTotalTime()
                'CalEmpAmount()
        End Select
        tdbg1.UpdateData()
        ResetGrid1()
    End Sub
    Private Sub tdbg1_KeyDown(sender As Object, e As KeyEventArgs) Handles tdbg1.KeyDown
        If e.KeyCode = Keys.Enter AndAlso tdbg1.Col = IndexOfColumn(tdbg1, COL1_EmpQuantity) Then
            HotKeyDownGrid(e, tdbg1, IndexOfColumn(tdbg1, COL1_EmpQuantity))
        End If
    End Sub
#End Region
    Private Function AllowSave() As Boolean
        tdbg1.UpdateData()
        If tdbg1.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg1.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg1.RowCount - 1
            If Number(tdbg1(i, COL1_EmpQuantity)) = 0 Then
                D99C0008.MsgNotYetEnter(tdbg1.Columns(COL1_EmpQuantity).Caption)
                tdbg1.Focus()
                tdbg1.SplitIndex = 0
                tdbg1.Col = IndexOfColumn(tdbg1, COL1_EmpQuantity)
                tdbg1.Row = i  'findrowInGrid(tdbg1, xxxxKeyValue, xxxxFieldKey)
                Return False
            End If
        Next
        '***********************
        Dim dt As DataTable = dtGrid1.DefaultView.ToTable(True, COL1_PartProductID)
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim dSum As Double = 0
            For j As Integer = 0 To tdbg1.RowCount - 1
                If dt.Rows(i).Item(COL1_PartProductID).ToString = tdbg1(j, COL1_PartProductID).ToString Then
                    dSum += Number(tdbg1(j, COL1_EmpQuantity))
                End If
            Next
            If Number(cneSumQuantity.Value, DxxFormat.DefaultNumber0) <> Number(dSum, DxxFormat.DefaultNumber0) Then
                D99C0008.MsgL3(rL3("Tong_san_luong_nhan_vien_thuc_hien_phai_bang_san_luong_cua_san_pham_gop_") & vbCrLf & rL3("Ban_vui_long_kiem_tra_laiU"))
                Return False
            End If
        Next
        Return True
    End Function
    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnCopy.Focus()
        If btnCopy.Focused = False Then Exit Sub
        '************************************
        If D99C0008.MsgAsk(rL3("San_luong_cua_nhan_vien_se_duoc_sao_chep_cho_cac_tieu_tac_duoc_chon") & vbCrLf & rL3("MSG000021")) = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD45T2050s.ToString & vbCrLf)
        sSQL.Append(SQLInsertD45T2050s.ToString)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            _bSaved = True
            Me.Close()
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD45T2050s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/03/2016 04:23:03
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD45T2050s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        Dim dr() As DataRow = dtGrid.Select(COL_Choose & "=True")
        For i As Integer = 0 To dr.Length - 1
            sSQL = ""
            If i = 0 Then sSQL &= ("-- Xoa du lieu truoc khi luu" & vbCrLf)
            sSQL &= "Delete From D45T2050"
            sSQL &= " Where "
            sSQL &= "PartProductID = " & SQLString(dr(i).Item(COL_PartProductID).ToString)
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T2050s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/03/2016 04:25:29
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T2050s() As StringBuilder
        Dim sRet As New StringBuilder
        'Sinh IGE chi tiết
        Dim sTransactionID As String = ""
        Dim iFirstTrans As Long = 0
        Dim iCountIGE As Integer = 0
        Dim dtSourceGrid As DataTable = CType(tdbg1.DataSource, DataTable)
        iCountIGE = dtSourceGrid.Select(COL1_EmpPartProductID & "='' or " & COL1_EmpPartProductID & " is null").Length
        '---------------------------------
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg1.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert can doi san pham" & vbCrlf)
            If tdbg1(i, COL1_EmpPartProductID).ToString = "" Then
                sTransactionID = CreateIGENewS("D45T2050", "EmpPartProductID", "45", "EP", gsStringKey, sTransactionID, iCountIGE, iFirstTrans)
                tdbg1(i, COL1_EmpPartProductID) = sTransactionID
            End If
            sSQL.Append("Insert Into D45T2050(")
            sSQL.Append("EmpPartProductID, ProductAddID, PartProductID, EmployeeID, DepartmentID, " & vbCrlf)
            sSQL.Append("TeamID, EmpQuantity, TotalTime, UnitPrice, EmpAmount, " & vbCrlf)
            sSQL.Append("TranMonth, TranYear, IsEmpOutsideStage")
            sSQL.Append(") Values(" & vbCrlf)
            sSQL.Append(SQLString(tdbg1(i, COL1_EmpPartProductID)) & COMMA) 'EmpPartProductID [KEY], varchar[50], NOT NULL
            sSQL.Append(SQLString(_productAddID) & COMMA) 'ProductAddID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_PartProductID)) & COMMA) 'PartProductID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_EmployeeID)) & COMMA) 'EmployeeID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_DepartmentID)) & COMMA & vbCrlf) 'DepartmentID, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg1(i, COL1_TeamID)) & COMMA) 'TeamID, varchar[50], NOT NULL
            sSQL.Append(SQLNumber(tdbg1(i, COL1_EmpQuantity)) & COMMA) 'EmpQuantity, int, NOT NULL
            sSQL.Append(SQLMoney(tdbg1(i, COL1_TotalTime), tdbg1.Columns(COL1_TotalTime).NumberFormat) & COMMA) 'TotalTime, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg.Columns(COL_PPUnitPrice).Text, tdbg.Columns(COL_PPUnitPrice).NumberFormat) & COMMA & vbCrLf) 'UnitPrice, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg1(i, COL1_EmpAmount), tdbg1.Columns(COL1_EmpAmount).NumberFormat) & COMMA) 'EmpAmount, decimal, NOT NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, int, NOT NULL
            sSQL.Append(SQLNumber(tdbg1(i, COL1_IsEmpOutsideStage)) & vbCrlf) 'IsEmpOutsideStage, tinyint, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function




End Class