Imports System
Public Class D13F2120
	Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_DetailID As Integer = 0           ' DetailID
    Private Const COL_TransferObjectID As Integer = 1   ' ĐT chuyển bút toán
    Private Const COL_TransferObjectName As Integer = 2 ' Tên ĐT cuyển bút toán
    Private Const COL_PayCalDesc As Integer = 3         ' Khoản thu nhập
    Private Const COL_VoucherNo As Integer = 4          ' Số phiếu
    Private Const COL_VoucherDate As Integer = 5        ' Ngày phiếu
    Private Const COL_EmployeeID As Integer = 6         ' Người lập
    Private Const COL_VoucherDesc As Integer = 7        ' Diễn giải
    Private Const COL_Description As Integer = 8        ' Ghi chú
    Private Const COL_DebitAccountID As Integer = 9     ' TK nợ
    Private Const COL_CreditAccountID As Integer = 10   ' TK có
    Private Const COL_ConvertedAmount As Integer = 11   ' Thành tiền
    Private Const COL_DObjectTypeID As Integer = 12     ' Loại ĐT nợ
    Private Const COL_DObjectID As Integer = 13         ' ĐT nợ
    Private Const COL_CObjectTypeID As Integer = 14     ' Loại ĐT có
    Private Const COL_CObjectID As Integer = 15         ' ĐT có
    Private Const COL_PeriodID As Integer = 16          ' Tập phí
    Private Const COL_Ana01ID As Integer = 17           ' Khoản mục 01
    Private Const COL_Ana02ID As Integer = 18           ' Khoản mục 02
    Private Const COL_Ana03ID As Integer = 19           ' Khoản mục 03
    Private Const COL_Ana04ID As Integer = 20           ' Khoản mục 04
    Private Const COL_Ana05ID As Integer = 21           ' Khoản mục 05
    Private Const COL_Ana06ID As Integer = 22           ' Khoản mục 06
    Private Const COL_Ana07ID As Integer = 23           ' Khoản mục 07
    Private Const COL_Ana08ID As Integer = 24           ' Khoản mục 08
    Private Const COL_Ana09ID As Integer = 25           ' Khoản mục 09
    Private Const COL_Ana10ID As Integer = 26           ' Khoản mục 10
#End Region


    Private dt As DataTable

    Private _tTResultVoucherID As String = ""
    Public WriteOnly Property TTResultVoucherID() As String
        Set(ByVal Value As String)
            _tTResultVoucherID = Value
        End Set
    End Property

    Private Sub D13F2120_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D13F2120_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        '    ResetColorGrid(tdbg, 0, 2)
        ResetFooterGrid(tdbg, 0, 2)
        ResetSplitDividerSize(tdbg)
        gbEnabledUseFind = False
        tdbg_NumberFormat()
        tdbg_LockedColumns()
        LoadTDBGrid()
        LoadTDBGridAnalysisCaption("D13", tdbg, COL_Ana01ID, 2, True, gbUnicode)
        Loadlanguage()
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_ket_qua_chuyen_but_toan_-_D13F2120") & UnicodeCaption(gbUnicode) 'Chi tiÕt kÕt qu¶ chuyÓn bòt toÀn - D13F2120
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnExportToExcel.Text = rl3("Xuat__Excel") 'Xuất &Excel
        '================================================================ 
        ' UPDATE 3/6/2013 ID 56910
        tdbg.Columns("TransferObjectID").Caption = rl3("DT_chuyen_but_toan")
        tdbg.Columns("TransferObjectName").Caption = rl3("Ten_DT_cuyen_but_toan")
        tdbg.Columns("PayCalDesc").Caption = rl3("Khoan_thu_nhap") 'Khoản thu nhập
        tdbg.Columns("VoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("EmployeeID").Caption = rl3("Nguoi_lap") 'Người lập
        tdbg.Columns("VoucherDesc").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("Description").Caption = rl3("Ghi_chu") ' UPDATE 3/6/2013 ID 56910
        tdbg.Columns("DebitAccountID").Caption = rl3("TK_no") 'TK nợ
        tdbg.Columns("CreditAccountID").Caption = rl3("TK_co") 'TK có
        tdbg.Columns("ConvertedAmount").Caption = rl3("Thanh_tien") 'Thành tiền
        tdbg.Columns("DObjectTypeID").Caption = rl3("Loai_DT_no") 'Loại ĐT nợ
        tdbg.Columns("DObjectID").Caption = rl3("DT_no") 'ĐT nợ
        tdbg.Columns("CObjectTypeID").Caption = rl3("Loai_DT_co") 'Loại ĐT có
        tdbg.Columns("CObjectID").Caption = rl3("DT_co") 'ĐT có
        tdbg.Columns("PeriodID").Caption = rl3("Tap_phi")
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ConvertedAmount).NumberFormat = DxxFormat.DecimalPlaces
    End Sub

    ' UPDATE 3/6/2013 ID 56910
    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TransferObjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TransferObjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PayCalDesc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_VoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_VoucherDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_EmployeeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_VoucherDesc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DebitAccountID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CreditAccountID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ConvertedAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DObjectTypeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DObjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CObjectTypeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CObjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_PeriodID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana01ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana02ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana03ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana04ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana05ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana06ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana07ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana08ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana09ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Ana10ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String
        Dim iColumns() As Integer = {COL_ConvertedAmount}
        sSQL = SQLStoreD13P2002()
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt, gbUnicode)
        If dt.Rows.Count <= 0 Then
            btnExportToExcel.Enabled = False
            btnExportToExcelSys.Enabled = False
        End If
        FooterTotalGrid(tdbg, COL_VoucherNo)
        FooterSum(tdbg, iColumns)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2002
    '# Created User: Thanh Huyền
    '# Created Date: 18/11/2010 11:12:33
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2002() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2002 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_tTResultVoucherID) & COMMA 'TTResultVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    'Dim dtCaptionCols As DataTable
    Private Sub btnExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        '*****************************************
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới không có nút Hiển thị)
        'Nếu lưới không có Group thì mở dòng code If dtCaptionCols Is Nothing Then 
        'và truyền đối số cuối cùng là False vào hàm AddColVisible
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , True, , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, , True, , gbUnicode)
        AddColVisible(tdbg, SPLIT2, Arr, , True, , gbUnicode)

        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)

        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, dtCaptionCols, dt, gsGroupColumns)

        '        Dim frm As New D99F2222
        '        With frm
        '            .FormID = Me.Name
        '            .UseUnicode = gbUnicode
        '            .dtLoadGrid = dtCaptionCols
        '            .GroupColumns = gsGroupColumns
        '            .dtExportTable = dt
        '            .ShowDialog()
        '            .Dispose()
        '        End With
        '*****************************************
    End Sub

    ' UPDATE 3/6/2013 ID 56910
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLUpdateD13T2122s.ToString)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True

            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2122s
    '# Created User: Hoàng Nhân
    '# Created Date: 03/06/2013 02:30:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2122s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If i = 0 Then sSQL.Append("-- Luu truong ghi chu" & vbCrLf)
            sSQL.Append("Update D13T2122 Set ")
            sSQL.Append("Description = " & SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, False) & COMMA) 'varchar[2000], NOT NULL
            sSQL.Append("DescriptionU = " & SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, True)) 'nvarchar[2000], NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append(" TTResultVoucherID = " & SQLString(_tTResultVoucherID))
            sSQL.Append(" AND DetailID = " & SQLString(tdbg(i, COL_DetailID)))
            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        Select Case e.ColIndex
            Case COL_Description
                e.CellTip = tdbg(e.Row, e.ColIndex).ToString
            Case Else
                e.CellTip = ""
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then HotKeyEnterGrid(tdbg, COL_Description, e)
        If e.KeyCode = Keys.Tab Then btnSave.Focus()
        HotKeyDownGrid(e, tdbg, COL_Description)
    End Sub

    Private Sub btnExportToExcelSys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcelSys.Click

        Dim appExcel As New Microsoft.Office.Interop.Excel.Application
        appExcel = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)

        Dim sPath As String = ""
        SaveFileDialog1.FileName = "data"

        Dim sFileName As String = "Data.xls"
        SaveFileDialog1.Filter = "Lemon3 System File (*.l3sf) |*.l3sf|All File (*.*) |*.*"
        If L3Int(appExcel.Version) >= 12 Then
            sFileName = "Data.xlsx"
            SaveFileDialog1.Filter = "Lemon3 System File (*.l3sfx) |*.l3sfx|All File (*.*) |*.*"
        End If

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            sPath = SaveFileDialog1.FileName
        End If
        If sPath = "" Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        Dim dtDataExport As DataTable = ReturnDataTable(SQLStoreD13P2039)
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        AddColVisibleL3SF(dtDataExport, Arr)
        Dim dtCaptionExport As DataTable = CreateTableForExcelOnlyL3SF(dtDataExport, Arr)

        ExportToExcelMax(dtDataExport, dtCaptionExport, gsApplicationPath, sFileName, False, "B", 10)
        EncodeFile(gsApplicationPath & "\" & sFileName, sPath)

        Me.Cursor = Cursors.Default
        '*****************************************
    End Sub

    Sub EncodeFile(ByVal srcFile As String, ByVal destfile As String)
        Try
            Dim srcBT As Byte()
            Dim dest As String

            Dim sr As New IO.FileStream(srcFile, IO.FileMode.Open)
            ReDim srcBT(L3Int(sr.Length))
            sr.Read(srcBT, 0, L3Int(sr.Length))
            sr.Close()
            dest = System.Convert.ToBase64String(srcBT)

            Dim sw As New IO.StreamWriter(destfile, False)

            sw.Write(dest)
            sw.Close()
            If IO.File.Exists(srcFile) Then
                IO.File.Delete(srcFile)
            End If
            D99C0008.MsgL3(rl3("Xuat_du_lieu_thanh_cong"))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2039
    '# Created User: Hoàng Nhân
    '# Created Date: 06/06/2013 09:43:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2039() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xuat ra Excel de import vao D04" & vbCrlf)
        sSQL &= "Exec D13P2039 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_tTResultVoucherID) & COMMA 'TTResultVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsCompanyID) 'CompanyID, varchar[50], NOT NULL
        Return sSQL
    End Function

    Public Sub AddColVisibleL3SF(ByVal dtData As DataTable, ByRef ar As ArrayList)
        Try
            For i As Integer = 0 To dtData.Columns.Count - 1
                Dim dc As DataColumn = dtData.Columns(i)
                '   If c1Grid.Splits(iSplit).DisplayColumns(i).Visible Then
                Dim e As New ShowColumn
                e.FieldName = dc.ColumnName
                '                'Kiểm tra Cột nào bắt buộc nhập
                '                If ArrColObl IsNot Nothing AndAlso ArrColObl.Length > 0 Then
                '                    'Dạng số
                '                    If L3FindInteger(ArrColObl, i) Then
                '                        e.Obligatory = 1 ' Bắt buộc nhập
                '                    Else
                '                        e.Obligatory = 0 ' Không bắt buộc nhập
                '                    End If
                '                Else
                '                    e.Obligatory = 0 ' Không bắt buộc nhập
                '                End If

                '                If bUseUnicode Then
                '                    If c1Grid.Splits(iSplit).DisplayColumns(i).HeadingStyle.Font.Name = "Microsoft Sans Serif" Then
                '                        e.Caption = dc.Caption
                '                    Else
                '                        e.Caption = ConvertVniToUnicode(dc.Caption)
                '                    End If
                '                Else
                '                    If c1Grid.Splits(iSplit).DisplayColumns(i).HeadingStyle.Font.Name = "Microsoft Sans Serif" Then
                '                        e.Caption = ConvertUnicodeToVni(dc.Caption)
                '                    Else
                '                        e.Caption = dc.Caption
                '                    End If
                '                End If
                e.Caption = dc.ColumnName
                '                'Không có ý nghĩa khi chưa Load grid
                '                If dc.DataType.Name = "Decimal" OrElse dc.DataType.Name = "Double" OrElse dc.DataType.Name = "Single" Then 'Kiểu số có format (có dấu - có dấu .)
                '                    e.NumberFormat = IIf(dc.NumberFormat.Contains("Event"), dc.Tag, dc.NumberFormat).ToString 'dc.NumberFormat
                '                    e.IsSum = CByte(IIf(IsNumeric(dc.FooterText), 1, 0))
                '                Else
                '                    e.NumberFormat = ""
                '                    e.IsSum = 0
                '                End If
                e.Grouped = 0
                e.IsDateTime = 0
                e.DataType = dc.DataType.Name
                '  e.DataWidth = dc.DataWidth
                ar.Add(e)
                '     End If
            Next i
        Catch ex As Exception

        End Try
    End Sub

    Public Function CreateTableForExcelOnlyL3SF(ByVal dtData As DataTable, ByVal arrColVisible As ArrayList) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("FieldName", GetType(System.String))
        dt.Columns.Add("Description", GetType(System.String))
        dt.Columns.Add("OrderNum", GetType(System.Int32))
        dt.Columns.Add("OrderNo", GetType(System.Int32))
        dt.Columns.Add("DataType", GetType(System.String))
        dt.Columns.Add("IsUsed", GetType(System.Boolean))
        dt.Columns.Add("IsUnicode", GetType(System.Boolean))
        dt.Columns.Add("NumberFormat", GetType(System.Byte))
        dt.Columns.Add("Obligatory", GetType(System.Byte))
        dt.Columns.Add("Grouped", GetType(System.Byte))
        dt.Columns.Add("IsSum", GetType(System.Byte))
        dt.Columns.Add("IsDateTime", GetType(System.Byte))
        dt.Columns.Add("IsExport", GetType(System.Byte))
        dt.Columns.Add("DataWidth", GetType(System.Int32))

        Dim dr As DataRow
        Dim iCount As Integer = 0

        For i As Integer = 0 To arrColVisible.Count - 1
            iCount += 1
            dr = dt.NewRow
            Dim e As ShowColumn = CType(arrColVisible(i), ShowColumn)
            dr("FieldName") = e.FieldName
            dr("Description") = e.Caption
            dr("Obligatory") = e.Obligatory
            dr("Grouped") = e.Grouped
            dr("IsSum") = e.IsSum
            dr("IsDateTime") = e.IsDateTime
            dr("IsExport") = 0
            dr("IsUsed") = 1
            dr("IsUnicode") = 0
            dr("DataWidth") = e.DataWidth

            'Lay do dai max
            If dr("Description").ToString.Length > giMaxLengthColumnCaption Then giMaxLengthColumnCaption = dr("Description").ToString.Length

            dr("OrderNum") = iCount
            dr("OrderNo") = 0

            'Có ý nghĩa khi grid đã được load nguồn
            dr("NumberFormat") = 0
            'Update 26/03/2010
            'Cần phân biệt kiểu số để đưa vào tìm kiếm: N1(TinyInt); N2 (Int); N (Các kiểu số còn lại)
            'Update 13/07/2010: Byte có thể không là Checkbox, VD: cột TranMonth trên lưới
            If e.DataType = "Boolean" OrElse e.DataType = "Byte" Then 'Kiểu số dạng Checkbox (chỉ gõ số, không dấu - dấu .)
                '  If C1Grid.Columns(e.FieldName).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then 'Kiểu số dạng Checkbox
                dr("DataType") = "N1"
            ElseIf e.DataType.Contains("Int") OrElse e.DataType = "Byte" Then 'Kiểu số không format (có dấu - không dấu .)
                dr("DataType") = "N2"
                '                'Kiểm tra cột nào có tính tổng
                '                If arrColSum IsNot Nothing AndAlso arrColSum.Length > 0 Then
                '                    If L3FindInteger(arrColSum, C1Grid.Columns.IndexOf(C1Grid.Columns(e.FieldName))) Then
                '                        dr("IsSum") = "1"
                '                    Else
                '                        dr("IsSum") = "0"
                '                    End If
                '                End If
            ElseIf e.DataType = "Decimal" OrElse e.DataType = "Double" OrElse e.DataType = "Single" Then 'Kiểu số có format (có dấu - có dấu .)
                dr("DataType") = "N"
                If e.DataType.Contains("Decimal") Then 'Kiểu số->lấy Format
                    dr("NumberFormat") = 8
                    Dim sFormat As String = e.NumberFormat
                    If sFormat IsNot Nothing AndAlso sFormat <> "" Then
                        If sFormat = "Percent" Or sFormat.Contains("%") Then  'Thêm trường hợp format Percent - Update 06/11/2012
                            dr("DataType") = "Percent"
                        ElseIf sFormat.Contains(".") Then
                            Dim arr() As String = sFormat.Split(CType(".", Char))
                            dr("NumberFormat") = arr(arr.Length - 1).Length
                        ElseIf sFormat.Contains("N") Then 'Bổ sung 07/10/2011 TH định dạng trên cột "Nx"
                            dr("NumberFormat") = sFormat.Substring(1, sFormat.Length - 1)
                        End If
                    End If
                End If

                'Kiểm tra cột nào có tính tổng
                '                If arrColSum IsNot Nothing AndAlso arrColSum.Length > 0 Then
                '                    dr("IsSum") = e.IsSum
                '                End If

                '                If arrColSum IsNot Nothing AndAlso arrColSum.Length > 0 Then
                '                    If L3FindInteger(arrColSum, C1Grid.Columns.IndexOf(C1Grid.Columns(e.FieldName))) Then
                '                        dr("IsSum") = "1"
                '                    Else
                '                        dr("IsSum") = "0"
                '                    End If
                '                End If

            ElseIf e.DataType = "DateTime" Then 'Kiểu ngày
                dr("DataType") = "D"
                '                If arrColDateLong IsNot Nothing AndAlso arrColDateLong.Length > 0 Then
                '                    If L3FindInteger(arrColDateLong, C1Grid.Columns.IndexOf(C1Grid.Columns(e.FieldName))) Then
                '                        dr("IsDateTime") = "1"
                '                    Else
                '                        dr("IsDateTime") = "0"
                '                    End If
                '                End If
            Else 'Kiểu chuỗi
                dr("DataType") = "S"
            End If

            dt.Rows.Add(dr)
        Next

        Return dt

    End Function
End Class