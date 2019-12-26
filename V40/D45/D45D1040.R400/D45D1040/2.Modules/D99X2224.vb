'#######################################################################################
'# MỤC ĐÍCH: Xuất Excel trực tiếp không liên quan đến dll của C1
'#--------------------------------------------------------------------------------------
'# Không được thay đổi bất cứ dòng code này trong module này, nếu muốn thay đổi bạn phải
'# liên lạc với Trưởng nhóm để được giải quyết.
'# Ngày cập nhật cuối cùng: 15/03/2013
'# Người cập nhật cuối cùng: Lê Phương
'# Diễn giải: Xuất Excel trực tiếp không liên quan đến dll của C1
'# Bổ sung đk cột >255 của ExportToExcelMax
'#######################################################################################

Module D99X2224
    Private Const FileNameExcel As String = "Data.xlsx"

    Public Function ExportToExcelMax(ByVal dtData As DataTable, ByVal dtCaptionCols As DataTable) As Boolean
        Return ExportToExcelMax(dtData, dtCaptionCols, Application.StartupPath, FileNameExcel, True)
    End Function

    Public Function ExportToExcelMax(ByVal dtData As DataTable, ByVal dtCaptionCols As DataTable, ByVal sPath As String, ByVal sFileName As String, ByVal bOpenFile As Boolean, Optional ByVal sFirstCol As String = "A", Optional ByVal iFirstRow As Integer = 1) As Boolean
        '******************************************************
        ' Kiểm tra nếu dữ liệu > 65530 dong hoặc >256 cột thì chỉ chạy trên Office 2007
        If Not CheckVersionExcel() Then
            If dtData.Rows.Count > 65530 Then
                MessageBox.Show(ConvertUnicodeToVietwareF(r("So_dong_vuot_qua_gioi_han_cho_phep_cua_Excel") & " (" & dtData.Rows.Count & " > 65530)"), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf dtCaptionCols.Rows.Count > 256 Then
                MessageBox.Show(ConvertUnicodeToVietwareF(r("So_cot_vuot_qua_gioi_han_cho_phep_cua_Excel") & " (" & dtCaptionCols.Rows.Count & "> 256)"), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If
        '******************************************************
        'Kiểm tra tồn tại file Excel đang xuất
        If CloseProcessWindowMax(sFileName) = False Then Return False
        '******************************************************

        Dim oPathFile As String = sPath + "\" + sFileName 'Application.StartupPath + "\" + oFileName' "Data.xlsx"
        Dim oExcel As New Microsoft.Office.Interop.Excel.ApplicationClass() ' Create the Excel Application object
        Dim oWorkbook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Add(Type.Missing) ' Create a new Excel Workbook
        Dim oWorkSheet As Microsoft.Office.Interop.Excel.Worksheet ' Create a new Excel Worksheet

        sFirstCol = sFirstCol.ToUpper
        Dim iFirstCol As Integer = GetIntColumnExcel(sFirstCol) 'Đổi cột Chuỗi sang Số (VD: cột A đổi thành cột 0)

        Dim StartValue As Integer = 0 ' Vị trí bắt đầu của Rang excel
        Dim EndValue As Integer = 0 ' Vị trí cuối cùng của Rang excel
        Dim PrevPos As Integer = iFirstRow - 1 ' 0 ' Vị trí kế tiếp của Rang excel

        Dim iMaxRow As Long = dtData.Rows.Count
        Dim iPackage As Integer = 0 'Số gói cần chạy 
        Dim iLimitRow As Integer 'Số dòng chạy cho 1 gói iPackage
        Dim iRowCount As Integer = 0 ' Tổng số dòng của 1 rang cần khởi tạo (rawData)
        Dim iStartRow As Integer = 0 ' Dòng bắt đầu chạy cho dtData trong 1 gói
        Dim iEndRow As Integer = 0 ' Dòng cuối cùng chạy cho dtData trong 1 gói

        '******************************************************
        '        Dim EndDate As Date
        '        Dim EndOpenFile As Date
        '        Dim StartDate As Date = Now
        '******************************************************
        Try
            ' Tạo Sheet mới
            oWorkSheet = CType(oWorkbook.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
            oWorkSheet.Name = "Data"

            'Xác định số dòng dữ liệu cần xuất cho 1 gói (iPackage)
            If iMaxRow > 10000 Then
                iLimitRow = 1000
            Else
                iLimitRow = 100
            End If

            ' Tìm ký tự "A...Z" của cột
            Dim finalColLetter As String = String.Empty
            Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim colCharsetLen As Integer = colCharset.Length
            If dtCaptionCols.Rows.Count > colCharsetLen Then
                finalColLetter = colCharset.Substring((dtCaptionCols.Rows.Count - 1 + iFirstCol) \ colCharsetLen - 1, 1)
            End If
            finalColLetter += colCharset.Substring((dtCaptionCols.Rows.Count - 1 + iFirstCol) Mod colCharsetLen, 1)

            'Lấy số gói cần chạy để đưa vào rang excel
            If iMaxRow <= iLimitRow Then ' Nếu Số dòng xuất <= iLimitRow thì 1 Package
                iPackage = 1
            Else
                Dim iDecimal As Integer = CInt(iMaxRow Mod iLimitRow)
                If iDecimal = 0 Then ' Chia hết
                    iPackage = CInt(iMaxRow / iLimitRow)
                Else ' Chia dư -> Package = Package + 1
                    iPackage = CInt(Int(iMaxRow / iLimitRow))
                    iPackage += 1
                End If
            End If

            'Tạo bảng và Add Data
            For iX As Long = 1 To iPackage
                If iX < iPackage Then
                    If iX = 1 Then 'Lần đầu tiên
                        iStartRow = iEndRow
                    Else
                        iStartRow = iEndRow + 1
                    End If
                    iEndRow = CInt(iLimitRow * iX) - 1
                    iRowCount = iLimitRow
                Else
                    If iPackage = 1 Then
                        iStartRow = 0
                        iEndRow = CInt(iMaxRow - 1)
                        iRowCount = CInt(iMaxRow)
                    Else
                        iStartRow = iEndRow + 1
                        iEndRow = CInt(iMaxRow - 1)
                        iRowCount = CInt(iMaxRow - (iLimitRow * (iX - 1)))
                    End If
                End If

                StartValue = PrevPos + 1
                If iX = 1 Then ' Table đầu tiên dành vị trí A1 cho header
                    EndValue = iRowCount + PrevPos + 1
                Else ' Các Table sau nối tiếp theo không tạo header
                    EndValue = iRowCount + PrevPos
                End If

                'Tạo mảng dữ liệu để đưa vào file excel
                Dim arrData(iRowCount, dtCaptionCols.Rows.Count - 1) As Object
                Dim sColumnFieldName As String = ""
                Dim sColumnCaption As String = ""
                Dim iRow_Data As Integer = 0
                'Phải lấy dữ liệu của bảng dtCaptionCols để kiểm tra, vì bảng dtData có thứ tự cột không đúng như trên lưới
                For col As Integer = 0 To dtCaptionCols.Rows.Count - 1
                    sColumnFieldName = dtCaptionCols.Rows(col).Item("FieldName").ToString
                    sColumnCaption = dtCaptionCols.Rows(col).Item("Description").ToString
                    If Not gbUnicode Then sColumnCaption = ConvertVniToUnicode(sColumnCaption)

                    iRow_Data = 0
                    If iX = 1 Then ' Đưa dữ liệu vào dòng tiêu đề (Header)
                        arrData(0, col) = sColumnCaption
                        iRow_Data += 1
                    End If

                    ' Đưa dữ liệu vào các dòng kế tiếp
                    For row As Integer = iStartRow To iEndRow
                        Dim dr As DataRow = dtData.Rows(row)
                        'Nếu cột là chuỗi thì thêm dấu ' phía trước để khi xuất Excel thì hiểu giá trị là chuỗi
                        If dtData.Columns(sColumnFieldName).DataType.Name = "String" Then
                            If gbUnicode Then
                                arrData(iRow_Data, col) = "'" & dr.Item(sColumnFieldName).ToString
                            Else 'Nếu nhập liệu VNI thì ConvertVniToUnicode dữ liệu dạng chuỗi sang Unicode
                                arrData(iRow_Data, col) = "'" & ConvertVniToUnicode(dr.Item(sColumnFieldName).ToString)
                            End If
                        Else
                            arrData(iRow_Data, col) = dr.Item(sColumnFieldName)
                        End If
                        iRow_Data += 1
                    Next
                Next

                ' Fast data export to Excel
                Dim excelRange As String = String.Format(sFirstCol & "{0}:{1}{2}", StartValue, finalColLetter, EndValue)
                'Dim excelRange As String = String.Format("A{0}:{1}{2}", StartValue, finalColLetter, EndValue)
                oWorkSheet.Range(excelRange, Type.Missing).Value2 = arrData
                'Khung
                oWorkSheet.Range(excelRange, Type.Missing).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                oWorkSheet.Range(excelRange, Type.Missing).Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                'Định dạng các cột Excel
                Dim range As Microsoft.Office.Interop.Excel.Range
                If iX = 1 Then 'Header
                    'range = DirectCast(excelSheet.Rows(1, Type.Missing), Range)
                    range = TryCast(oWorkSheet.Rows(iFirstRow, Type.Missing), Microsoft.Office.Interop.Excel.Range)
                    range.Font.Bold = True
                    range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    'Mau chu
                    'range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                    'Mau nen
                    range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)
                End If

                Dim colIndex As Integer = iFirstCol '0
                For i As Integer = 0 To dtCaptionCols.Rows.Count - 1
                    Dim dr As DataRow = dtCaptionCols.Rows(i)
                    'Xác định vị trí vùng Range
                    range = DirectCast(oWorkSheet.Range(GetStringColumnExcel(colIndex) & IIf(iX = 1, StartValue + 1, StartValue).ToString, GetStringColumnExcel(colIndex) & EndValue), Microsoft.Office.Interop.Excel.Range)
                    Select Case dr.Item("DataType").ToString
                        Case "N" 'Số thập phân
                            range.EntireColumn.NumberFormat = "#,##0" & InsertZero(L3Int(dtCaptionCols.Rows(i).Item("NumberFormat").ToString()))
                            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                        Case "N1" ' Boolean, Byte là cột checkbox
                            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        Case "N2" 'Số nguyên
                            range.EntireColumn.NumberFormat = "#,##0"
                            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                        Case "D" 'Ngày
                            If L3Int(dr.Item("IsDateTime").ToString()) = 1 Then
                                range.EntireColumn.NumberFormat = "dd/MM/yyyy HH:mm:ss"
                            Else
                                range.EntireColumn.NumberFormat = "dd/MM/yyyy"
                            End If
                            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        Case Else
                            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                            'range.Cells.AddComment("Cột chuỗi")
                    End Select

                    'Định dạng hiển thị dữ liệu cho cột
                    colIndex = colIndex + 1
                Next
                PrevPos = EndValue 'Giữ vị trí cuối cùng của table trước đó

            Next

            oWorkSheet.Columns.AutoFit()
            'Tắt cảnh báo hỏi có muốn Save As không?
            oExcel.DisplayAlerts = False
            oWorkbook.SaveAs(oPathFile) ', XlFileFormat.xlWorkbook, Type.Missing, _
            'Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, _
            'Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)

            If bOpenFile Then ' Mở ứng dụng
                oExcel.Workbooks.Open(oPathFile)
                oExcel.Visible = True
            End If

            Return True
            '        EndOpenFile = Now
            '        Dim lSeconds1 As Long = DateDiff(DateInterval.Second, EndDate, EndOpenFile)
            '        MessageBox.Show("Time open file excel: " & lSeconds1)
        Catch ex As Exception

            If bOpenFile Then oWorkbook.Close(False, Type.Missing, Type.Missing)
            ' Release the Application object
            oExcel.Quit()
        Finally
            oWorkSheet = Nothing
            oWorkbook = Nothing
            If Not bOpenFile Then oExcel.Quit()
            If oExcel IsNot Nothing Then oExcel = Nothing

            System.GC.Collect()
            System.GC.WaitForPendingFinalizers()
        End Try
    End Function

    Public Function CloseProcessWindowMax(Optional ByVal FileName As String = FileNameExcel, Optional ByVal bShowMessage As Boolean = True) As Boolean
        'Doan code dung de dong file Excel mo san (khong phai do Chuong trinh mo)
        Dim p As System.Diagnostics.Process = Nothing
        Dim sWindowName As String = "Microsoft Excel - " & FileName 'Data.xlsx"
        Try
            For Each pr As Process In Process.GetProcessesByName("EXCEL")
                If sWindowName = pr.MainWindowTitle OrElse pr.MainWindowTitle = sWindowName.Substring(0, sWindowName.LastIndexOf(".")) Then
                    If p Is Nothing Then
                        p = pr
                    ElseIf p.StartTime < pr.StartTime Then
                        p = pr
                    End If
                End If
            Next
            If p IsNot Nothing Then
                If bShowMessage Then
                    If (D99C0008.MsgAsk(r("Ban_phai_dong_File") & Space(1) & FileName & Space(1) & r("truoc_khi_xuat_Excel") & "." & vbCrLf & r("Ban_co_muon_dong_khong")) = Windows.Forms.DialogResult.Yes) Then
                        p.Kill()
                        Return True
                    Else
                        Return False
                    End If
                Else
                    p.Kill()
                    Return True
                End If

            End If
            Return True 'False
        Catch ex As Exception
            Return True
        End Try
    End Function


    ' Kiểm tra máy có cài Office 2007 trở lên hay không
    Public Function CheckVersionExcel() As Boolean
        Dim appExcel As New Microsoft.Office.Interop.Excel.Application
        appExcel = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        If L3Int(appExcel.Version) >= 12 Then
            Return True
        End If
        Return False
    End Function

    Private Function GetStringColumnExcel(ByVal sColumn As Integer) As String
        If sColumn <= 25 Then
            Return Chr(sColumn + Asc("A"))
        Else
            Return (Chr(sColumn \ 26 + Asc("A") - 1) + Chr(sColumn Mod 26 + Asc("A"))).ToString
        End If
    End Function

    Private Function GetIntColumnExcel(ByVal sColumn As String) As Integer
        If sColumn.Length = 1 Then

            Return (Asc(sColumn) - Asc("A"))
        Else
            Return (Asc(sColumn.Substring(0, 1)) - Asc("A") + 1) * 26 + (Asc(sColumn.Substring(1, 1)) - Asc("A"))
        End If

    End Function

End Module
