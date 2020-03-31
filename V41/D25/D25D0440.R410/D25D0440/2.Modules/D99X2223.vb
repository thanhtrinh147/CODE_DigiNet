Imports System
Imports C1.C1Excel
'#######################################################################################
'#                                     CHÚ Ý
'#--------------------------------------------------------------------------------------
'# Không được thay đổi bất cứ dòng code này trong module này, nếu muốn thay đổi bạn phải
'# liên lạc với Trưởng nhóm để được giải quyết.
'# Ngày cập nhật cuối cùng: 03/08/2012
'# Người cập nhật cuối cùng: Nguyễn Thị Ánh
'# Diễn giải: các vấn đề về Xuất Excel đặc thù và Xuất Excel cho Gởi mail cảnh báo
'#######################################################################################
Module D99X2223
    ''' <summary>
    ''' Xuất dữ liệu cho lưới
    ''' </summary>
    ''' <param name="tdbg"></param>
    ''' <param name="book"></param>
    ''' <param name="sheet"></param>
    ''' <param name="iRowBegin">Dòng bắt đầu xuất dữ liệu</param>
    ''' <param name="iColBegin">Cột bắt đầu xuất dữ liệu. Mặc định là 0</param>
    ''' <remarks>Xuất dữ liệu giống y lưới</remarks>
    Public Sub ExportsData(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByRef book As C1XLBook, ByRef sheet As XLSheet, ByVal iRowBegin As Integer, Optional ByVal iColBegin As Integer = 0)
        For i As Integer = 0 To tdbg.Splits.Count - 1
            For row As Integer = 0 To tdbg.RowCount - 1
                For col As Integer = 0 To tdbg.Columns.Count - 1
                    If Not tdbg.Splits(i).DisplayColumns(col).Visible Then Continue For
                    CreateCell(tdbg, row, col, book, sheet, iRowBegin + row, iColBegin + col)
                Next
            Next
        Next
    End Sub

    ''' <summary>
    ''' Xuất dữ liệu cho lưới có merge cột
    ''' </summary>
    ''' <param name="tdbg"></param>
    ''' <param name="book"></param>
    ''' <param name="sheet"></param>
    ''' <param name="iRowBegin">Dòng bắt đầu xuất dữ liệu</param>
    ''' <param name="iColBegin">Cột bắt đầu xuất dữ liệu</param>
    ''' <param name="iRowMerge">Số dòng được merge</param>
    ''' <param name="iColMerge">Số cột được merge</param>
    ''' <remarks></remarks>
    Public Sub ExportsDataMerge(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByRef book As C1XLBook, ByRef sheet As XLSheet, ByVal iRowBegin As Integer, Optional ByVal iColBegin As Integer = 0, Optional ByVal iRowMerge As Integer = 1, Optional ByVal iColMerge As Integer = 2)
        For i As Integer = 0 To tdbg.Splits.Count - 1
            For row As Integer = 0 To tdbg.RowCount - 1
                Dim k As Integer = 0
                For col As Integer = 0 To tdbg.Columns.Count - 1
                    If Not tdbg.Splits(i).DisplayColumns(col).Visible Then Continue For
                    MergedCell(book, sheet, iRowBegin + row, iColBegin + k, iRowMerge, iColMerge)
                    SetStypeCellContent(sheet, book, iRowBegin + row, iColBegin + k, iRowMerge, iColMerge)
                    CreateCell(tdbg, row, col, book, sheet, iRowBegin + row, iColBegin + k)
                    k = k + iColMerge
                Next
            Next
        Next
    End Sub

    Private Sub MergedCell(ByRef book As C1XLBook, ByRef sheet As XLSheet, ByVal iRowFrom As Integer, ByVal iColFrom As Integer, ByVal iRowCount As Integer, ByVal iColCount As Integer)
        Dim c1CellRange As XLCellRange
        c1CellRange = New XLCellRange(iRowFrom, iRowFrom + iRowCount - 1, iColFrom, iColFrom + iColCount - 1)
        sheet.MergedCells.Add(c1CellRange)
    End Sub

    Private Sub SetStypeCell(ByRef sheet As XLSheet, ByRef book As C1XLBook, ByVal iRow As Integer, ByVal iCol As Integer, ByVal sValueCell As String, Optional ByVal iRowCount As Integer = 0, Optional ByVal iColCount As Integer = 0, Optional ByVal bHeader As Boolean = True)
        Dim cell As XLCell
        Dim style As New C1.C1Excel.XLStyle(book)
        SetStypeCellContent(sheet, book, iRow, iCol, iRowCount, iColCount)
        cell = sheet(iRow, iCol)
        style.Font = New System.Drawing.Font("Arial", 10.0!, FontStyle.Bold)
        style.BorderBottom = XLLineStyleEnum.Thin
        style.BorderLeft = XLLineStyleEnum.Thin
        style.BorderTop = XLLineStyleEnum.Thin
        style.BorderRight = XLLineStyleEnum.Thin
        style.AlignVert = XLAlignVertEnum.Center
        style.AlignHorz = XLAlignHorzEnum.Center 'Canh giữa tiêu đề
        If bHeader Then style.BackColor = Color.LightGray
        style.WordWrap = True
        cell.Style = style
        cell.Value = sValueCell
    End Sub

    Private Sub SetStypeCellContent(ByRef sheet As XLSheet, ByRef book As C1XLBook, ByVal iRow As Integer, ByVal iCol As Integer, Optional ByVal iRowCount As Integer = 0, Optional ByVal iColCount As Integer = 0)
        Dim cell As XLCell
        Dim style As New C1.C1Excel.XLStyle(book)
        If (iRowCount > 0) Then
            For i As Integer = 1 To iRowCount - 2
                cell = sheet(iRow + i, iCol)
                Dim styleMerge As New C1.C1Excel.XLStyle(book)
                styleMerge.BorderLeft = XLLineStyleEnum.Thin
                cell.Style = styleMerge
            Next
            cell = sheet(iRow + iRowCount - 1, iCol)
            Dim styleMerge1 As New C1.C1Excel.XLStyle(book)
            styleMerge1.BorderBottom = XLLineStyleEnum.Thin
            styleMerge1.BorderLeft = XLLineStyleEnum.Thin
            cell.Style = styleMerge1

            For i As Integer = 1 To iRowCount - 1
                cell = sheet(iRow + i, iCol + iColCount)
                Dim styleMerge As New C1.C1Excel.XLStyle(book)
                styleMerge.BorderLeft = XLLineStyleEnum.Thin
                cell.Style = styleMerge
            Next
            If (iColCount > 0) Then
                If (iRowCount = 1) Then
                    For i As Integer = 1 To iColCount - 2
                        cell = sheet(iRow + iRowCount - 1, iCol + i)
                        Dim styleMerge As New C1.C1Excel.XLStyle(book)
                        styleMerge.BorderBottom = XLLineStyleEnum.Thin
                        styleMerge.BorderTop = XLLineStyleEnum.Thin
                        cell.Style = styleMerge
                    Next
                    cell = sheet(iRow, iCol + iColCount - 1)
                    Dim styleMerge4 As New C1.C1Excel.XLStyle(book)
                    styleMerge4.BorderRight = XLLineStyleEnum.Thin
                    styleMerge4.BorderBottom = XLLineStyleEnum.Thin
                    styleMerge4.BorderTop = XLLineStyleEnum.Thin
                    cell.Style = styleMerge4
                Else
                    For i As Integer = 1 To iColCount - 1
                        cell = sheet(iRow + iRowCount - 1, iCol + i)
                        Dim styleMerge As New C1.C1Excel.XLStyle(book)
                        styleMerge.BorderBottom = XLLineStyleEnum.Thin
                        cell.Style = styleMerge
                    Next

                    For i As Integer = 1 To iColCount - 2
                        cell = sheet(iRow, iCol + i)
                        Dim styleMerge As New C1.C1Excel.XLStyle(book)
                        styleMerge.BorderTop = XLLineStyleEnum.Thin
                        cell.Style = styleMerge
                    Next
                    cell = sheet(iRow, iCol + iColCount - 1)
                    Dim styleMerge2 As New C1.C1Excel.XLStyle(book)
                    styleMerge2.BorderRight = XLLineStyleEnum.Thin
                    styleMerge2.BorderTop = XLLineStyleEnum.Thin
                    cell.Style = styleMerge2
                    cell = sheet(iRow + iRowCount - 1, iCol + iColCount - 1)
                    Dim styleMerge3 As New C1.C1Excel.XLStyle(book)
                    styleMerge3.BorderRight = XLLineStyleEnum.Thin
                    styleMerge3.BorderBottom = XLLineStyleEnum.Thin
                    cell.Style = styleMerge3
                End If

            End If
        End If
    End Sub

    Private Sub CreateCell(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal rowGrid As Integer, ByVal colGrid As Integer, ByRef book As C1XLBook, ByRef sheet As XLSheet, ByVal iRow As Integer, ByVal iCol As Integer)

        Dim sFormat As String
        Dim cell As XLCell
        Dim sValue As Object = tdbg(rowGrid, colGrid)
        Select Case tdbg.Columns(colGrid).DataType.Name
            Case "Byte", "Integer", "Int16", "Int32", "Int64", "Decimal", "Double", "Single" ' "Decimal", "Double", "Single", "Int16"
                Dim xst As XLStyle = New XLStyle(sheet.Book)
                sFormat = tdbg.Columns(colGrid).NumberFormat
                xst.Format = sFormat
                Try
                    If L3Bool(tdbg(rowGrid, "Isbold")) Then
                        xst.Font = New System.Drawing.Font("Arial", 10.0!, FontStyle.Bold)
                    End If
                Catch ex As Exception
                End Try
                xst.BorderBottom = XLLineStyleEnum.Thin
                xst.BorderLeft = XLLineStyleEnum.Thin
                xst.BorderTop = XLLineStyleEnum.Thin
                xst.BorderRight = XLLineStyleEnum.Thin
                xst.AlignHorz = XLAlignHorzEnum.Right
                sheet.Item(iRow, iCol).Style = xst
                cell = sheet(iRow, iCol)
                If ConvertMoney(sValue, sFormat) = 0 Then
                    cell.Value = ""
                Else
                    cell.Value = sValue
                End If
            Case "Short Date"
                Dim xst As XLStyle = New XLStyle(sheet.Book)
                Try
                    If L3Bool(tdbg(rowGrid, "Isbold")) Then
                        xst.Font = New System.Drawing.Font("Arial", 10.0!, FontStyle.Bold)
                    End If
                Catch ex As Exception
                End Try
                xst.BorderBottom = XLLineStyleEnum.Thin
                xst.BorderLeft = XLLineStyleEnum.Thin
                xst.BorderTop = XLLineStyleEnum.Thin
                xst.BorderRight = XLLineStyleEnum.Thin
                xst.AlignHorz = XLAlignHorzEnum.Center
                xst.Format = "dd/mm/yyyy"
                sheet.Item(iRow, iCol).Style = xst
                cell = sheet(iRow, iCol)
                cell.Value = sValue
            Case "Boolean"
                Dim xst As XLStyle = New XLStyle(sheet.Book)
                Try
                    If L3Bool(tdbg(rowGrid, "Isbold")) Then
                        xst.Font = New System.Drawing.Font("Arial", 10.0!, FontStyle.Bold)
                    End If
                Catch ex As Exception
                End Try
                xst.BorderBottom = XLLineStyleEnum.Thin
                xst.BorderLeft = XLLineStyleEnum.Thin
                xst.BorderTop = XLLineStyleEnum.Thin
                xst.BorderRight = XLLineStyleEnum.Thin
                'Trường hợp này dưới Database có kiểu dữ liệu Bit(0,1) -> DataTable có kiểu dữ liệu String(True,False)
                xst.AlignHorz = XLAlignHorzEnum.Center
                'Bỏ: chuyển về định dạn theo thiết lập ở dưới
                ''Update 07/07/2010: Giá trị = True thì format màu đỏ và canh giữa
                If sValue.ToString.ToUpper = "TRUE" Or sValue.ToString.ToUpper = "FALSE" Then
                    'xst.AlignHorz = XLAlignHorzEnum.Center
                    If sValue.ToString.ToUpper = "TRUE" Then xst.ForeColor = Color.Red
                Else
                    'xst.AlignHorz = XLAlignHorzEnum.Right
                    If sValue.ToString = "1" Then xst.ForeColor = Color.Red
                End If
                sheet.Item(iRow, iCol).Style = xst
                cell = sheet(iRow, iCol)
                cell.Value = sValue
            Case Else
                Dim xst As XLStyle = New XLStyle(sheet.Book)
                xst.BorderBottom = XLLineStyleEnum.Thin
                Try
                    If L3Bool(tdbg(rowGrid, "Isbold")) Then
                        xst.Font = New System.Drawing.Font("Arial", 10.0!, FontStyle.Bold)
                    Else
                        xst.Font = New System.Drawing.Font("Arial", 10.0!)
                    End If
                Catch ex As Exception
                    xst.Font = New System.Drawing.Font("Arial", 10.0!)
                End Try
                xst.BorderLeft = XLLineStyleEnum.Thin
                xst.BorderTop = XLLineStyleEnum.Thin
                xst.BorderRight = XLLineStyleEnum.Thin
                xst.AlignHorz = XLAlignHorzEnum.Left
                sheet.Item(iRow, iCol).Style = xst
                cell = sheet(iRow, iCol)
                If (Not gbUnicode) Then
                    cell.Value = ConvertVniToUnicode(sValue.ToString)
                Else
                    cell.Value = sValue
                End If
        End Select
    End Sub

    Public Sub AutoSizeColumnsEXCEL(ByVal sheet As XLSheet, ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, Optional ByVal iColBegin As Integer = 0)
        Using g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
            For iSplit As Integer = 0 To tdbg.Splits.Count - 1
                For col As Integer = 0 To tdbg.Columns.Count - 1
                    If Not tdbg.Splits(iSplit).DisplayColumns(col).Visible Then Continue For
                    Dim colExe As Integer = col + iColBegin
                    Select Case tdbg.Splits(iSplit).DisplayColumns(col).Width
                        Case Is <= 50 '50
                            sheet.Columns(colExe).Width = 600
                        Case Is <= 80 '110
                            sheet.Columns(colExe).Width = 1290
                        Case Is <= 110
                            sheet.Columns(colExe).Width = 2000
                        Case Is <= 170
                            sheet.Columns(colExe).Width = 3000
                        Case Else
                            sheet.Columns(colExe).Width = 4000
                    End Select
                Next
            Next
        End Using
    End Sub

    Public Sub LoadRowExel(ByRef book As C1XLBook, ByRef sheet As XLSheet, ByVal iRow As Integer, ByVal iCol As Integer, ByVal sValue As String, Optional ByVal emSize As Single = 10.0, Optional ByVal fontstyle As System.Drawing.FontStyle = FontStyle.Regular, Optional ByVal AlignHorz As XLAlignHorzEnum = XLAlignHorzEnum.Left)
        Dim cell As XLCell
        Dim style As New C1.C1Excel.XLStyle(book)
        cell = sheet(iRow, iCol)
        style.Font = New System.Drawing.Font("Arial", emSize, fontstyle)
        style.AlignHorz = AlignHorz 'Canh giữa tiêu đề
        style.AlignVert = XLAlignVertEnum.Center
        cell.Style = style
        cell.Value = sValue
    End Sub

    Public Sub LoadCaptionGrid(ByRef book As C1XLBook, ByRef sheet As XLSheet, ByVal iRow As Integer, ByVal iCol As Integer, ByVal sValueCell As String, Optional ByVal iTotalRowMerge As Integer = 1, Optional ByVal iTotalColMerge As Integer = 1, Optional ByVal bHeader As Boolean = True)
        If iTotalRowMerge <> 1 Or iTotalColMerge <> 1 Then MergedCell(book, sheet, iRow, iCol, iTotalRowMerge, iTotalColMerge)
        SetStypeCell(sheet, book, iRow, iCol, sValueCell, iTotalRowMerge, iTotalColMerge, bHeader)
    End Sub


#Region "Xuất Excel giống lưới cho Send Mail cảnh báo"

    Private Sub LoadCaptionGrid(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByRef book As C1XLBook, ByRef sheet As XLSheet, Optional ByVal iRow As Integer = 0, Optional ByVal iCol As Integer = 0)
        For i As Integer = 0 To tdbg.Columns.Count - 1
            LoadCaptionGrid(book, sheet, iRow, iCol + i, ConvertVniToUnicode(tdbg.Columns(i).Caption))
        Next
    End Sub

    ''' <summary>
    ''' Xuất Excel theo lưới khi send mail ở User cảnh báo
    ''' </summary>
    ''' <param name="fileName">fileName cần xuất Excel. VD: Application.StartupPath + "\Data.xls"</param>
    ''' <param name="tdbg">Lưới cần xuất Excel</param>
    ''' <remarks></remarks>
    Public Sub ExportExel_SendMail(ByVal fileName As String, ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        '  Dim EXL As New Microsoft.Office.Interop.Excel.Application' khi send mail
        Dim book As New C1XLBook()
        Dim sheet As XLSheet = book.Sheets(0)

        LoadCaptionGrid(tdbg, book, sheet)
        ExportsData(tdbg, book, sheet, 1, 0)
        AutoSizeColumnsEXCEL(sheet, tdbg)

        'ErrorOpenFile:'khi send mail
        Try
            book.Save(fileName)
            book.Dispose()
        Catch ex As Exception
            'MsgErrorExcel(ex.Message)
            'Update 7/07/2010: file excel đang mở, nếu người dùng chấp nhận đóng thì thực thi xuất excel tiếp ErrorOpenFile
            ' If CloseProcessWindow(EXL, fileName) Then GoTo ErrorOpenFile'khi send mail
        End Try
        'Không cần mở file Excel khi send mail
        'EXL.Workbooks.Open(fileName)
        'EXL.Visible = True
    End Sub

    Public Function CloseProcessWindow(ByVal EXL As Microsoft.Office.Interop.Excel.Application, ByVal fileName As String, Optional ByVal bShowMessage As Boolean = True) As Boolean
        Dim bClosed As Boolean = False
        Try
            For Each wbExcel As Microsoft.Office.Interop.Excel.Workbook In EXL.Workbooks
                If wbExcel.FullName = fileName Then
                    If bShowMessage Then
                        If (D99C0008.MsgAsk(r("Ban_phai_dong_File") & Space(1) & fileName.Substring(fileName.LastIndexOf("\") + 1) & Space(1) & r("truoc_khi_xuat_Excel") & "." & vbCrLf & r("Ban_co_muon_dong_khong")) = Windows.Forms.DialogResult.Yes) Then
                            wbExcel.Save()
                            wbExcel.Close()
                            If EXL.Workbooks.Count = 0 Then
                                EXL.Visible = False
                            End If
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        wbExcel.Save()
                        wbExcel.Close()
                        If EXL.Workbooks.Count = 0 Then
                            EXL.Visible = False
                        End If
                        Return True
                    End If
                End If
                bClosed = True
            Next
        Catch ex As Exception

        End Try

    End Function
#End Region

End Module
