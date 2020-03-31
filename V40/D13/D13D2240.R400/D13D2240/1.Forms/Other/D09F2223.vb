Imports System
Imports Microsoft.Office.Interop
Imports C1.C1Excel
Imports C1.Win.C1FlexGrid
Imports System.Threading
Public Class D09F2223

    Private _formID As String = ""
    Public WriteOnly Property FormID() As String
        Set(ByVal Value As String)
            _formID = Value
        End Set
    End Property

    Private _moduleID As String = ""
    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            _moduleID = Value
        End Set
    End Property

    Private _exportTypeID As String = ""
    Public WriteOnly Property ExportTypeID() As String
        Set(ByVal Value As String)
            _exportTypeID = Value
        End Set
    End Property

    Private _flexGrid As C1FlexGrid
    Public WriteOnly Property FlexGrid() As C1FlexGrid
        Set(ByVal Value As C1FlexGrid)
            _flexGrid = Value
        End Set
    End Property

    Private _txtColorGroup1 As Textbox
    Public WriteOnly Property TxtColor1() As TextBox
        Set(ByVal Value As TextBox)
            _txtColorGroup1 = Value
        End Set
    End Property

    Private _txtColorGroup2 As TextBox
    Public WriteOnly Property TxtColor2() As TextBox
        Set(ByVal Value As TextBox)
            _txtColorGroup2 = Value
        End Set
    End Property


    Private _txtColorGroup3 As TextBox
    Public WriteOnly Property TxtColor3() As TextBox
        Set(ByVal Value As TextBox)
            _txtColorGroup3 = Value
        End Set
    End Property

    'Private _styleBold As Boolean = False
    'Public WriteOnly Property styleBold() As Boolean
    '    Set(ByVal Value As Boolean)
    '        _styleBold = Value
    '    End Set
    'End Property

    Private _colVisibleFirst As Integer = 0
    Public WriteOnly Property ColVisibleFirst() As Integer
        Set(ByVal Value As Integer)
            _colVisibleFirst = Value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D99F2223_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' oWorkbook = Nothing
        ' Release the Application object
        'ExcelApp.Quit()
        'NAR(ExcelApp)

        'System.Runtime.InteropServices.Marshal 
        '        excel.Quit();
        'while (Marshal.ReleaseComObject(excel) != 0) { }
        'excel = null;
        'GC.Collect();
        'GC.WaitForPendingFinalizers();
        '*****************
        '        // Garbage collecting
        'GC.Collect();
        'GC.WaitForPendingFinalizers();
        '// Clean up references to all COM objects
        '// As per above, you're just using a Workbook and Excel Application instance, so release them:
        'workbook.Close(false, Missing.Value, Missing.Value);
        'Marshal.FinalReleaseComObject(workbook);
        'Marshal.FinalReleaseComObject(xlApp);

    End Sub

    'private void KillSpecificExcelFileProcess(string excelFileName)
    '{
    '    var processes = from p in Process.GetProcessesByName("EXCEL")
    '                    select p;

    '    foreach (var process in processes)
    '    {
    '        if (process.MainWindowTitle == "Microsoft Excel - " + excelFileName)
    '            process.Kill();
    '    }
    '}
    'KillSpecificExcelFileProcess("example1.xlsx");

    Private Sub D99F2223_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        LoadData()
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Xuat_Excel") & UnicodeCaption(gbUnicode) 'Danh sÀch ng§éi nghÙ h§êng trí cÊp çm ¢au - D21F4090
        '================================================================ 
        lblDefaultFolder.Text = rl3("Duong_dan")
        lblDisplayColumn.Text = rl3("Cot_hien_thi")
        lblDisplayRow.Text = rl3("Dong_hien_thi")
        '================================================================ 
        btnExportToExcel.Text = rl3("Xuat__Excel")
        btnClose.Text = rl3("Do_ng") 'Đó&ng
    End Sub

    Private Sub LoadData()
        Dim sSQL As String = "SELECT	ModuleID , FormID , DisplayColumn, DisplayRow, Path, SheetExcel, ExportTypeID" & vbCrLf & _
        "	FROM	D91T2223 T WITH (NOLOCK)" & vbCrLf & _
        "	WHERE	ModuleID =" & SQLString(_moduleID) & _
        " AND FormID = " & SQLString(_formID) & _
        " AND ExportTypeID = " & SQLString(_exportTypeID)
        Dim dtTemp As DataTable = ReturnDataTable(sSQL)
        If dtTemp.Rows.Count = 0 Then Exit Sub
        With dtTemp.Rows(0)
            txtDisplayColumn.Text = .Item("DisplayColumn").ToString
            txtDisplayRow.Text = .Item("DisplayRow").ToString

            txtDefaultFolder.Text = .Item("Path").ToString
            If .Item("SheetExcel").ToString = "" Then 'Xuất nhiều Sheet
                cboDefaultSheet.Visible = False
                lblSheet.Visible = False
            Else
                LoadcmbSheets(.Item("SheetExcel"))
            End If

        End With
        If txtDisplayColumn.Text = "" Then txtDisplayColumn.Text = "A"
        If txtDisplayRow.Text = "" OrElse txtDisplayRow.Text = "0" Then txtDisplayRow.Text = "1"
    End Sub


    Private Sub LoadcmbSheets(Optional ByVal sDefault As Object = "")
        If txtDefaultFolder.Tag IsNot Nothing AndAlso txtDefaultFolder.Tag.ToString = txtDefaultFolder.Text Then Exit Sub
        txtDefaultFolder.Tag = txtDefaultFolder.Text
        cboDefaultSheet.Items.Clear()
        cboDefaultSheet.Font = FontUnicode(True)

        cboDefaultSheet.Visible = txtDefaultFolder.Text <> ""
        lblSheet.Visible = cboDefaultSheet.Visible

        If txtDefaultFolder.Text = "" Then Exit Sub
        If My.Computer.FileSystem.FileExists(txtDefaultFolder.Text) = False Then
            D99C0008.MsgL3("Not exist file Excel:" & Space(1) & txtDefaultFolder.Text)
            Exit Sub
        End If
        Dim oWorkbook As Excel.Workbook
        Dim ExcelApp As New Excel.ApplicationClass
        oWorkbook = ExcelApp.Workbooks.Open(txtDefaultFolder.Text)
        For Each ews As Excel.Worksheet In oWorkbook.Worksheets
            cboDefaultSheet.Items.Add(ews.Name)
        Next
        If sDefault.ToString = "" Then
            cboDefaultSheet.SelectedIndex = 0
        Else
            cboDefaultSheet.Text = sDefault.ToString
        End If
        tipSheet.SetToolTip(cboDefaultSheet, cboDefaultSheet.Text)
        ExcelApp.Quit()
        NAR(ExcelApp)
    End Sub

    Private Sub btnChoose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        Dim file As New OpenFileDialog
        file.Filter = "Excel File (*.xls;*.xlsx)|*.xls;*.xlsx"
        If (file.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            txtDefaultFolder.Text = file.FileName
            cboDefaultSheet.Enabled = True
        End If
        LoadcmbSheets()
        txtDisplayColumn.Text = "A"
        txtDisplayRow.Text = "1"
    End Sub


    Private Function AllowExport() As Boolean
        If txtDefaultFolder.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblDefaultFolder.Text)
            txtDefaultFolder.Focus()
            Return False
        End If
        If My.Computer.FileSystem.FileExists(txtDefaultFolder.Text) = False Then
            D99C0008.MsgL3("Not exist file Excel:" & Space(1) & txtDefaultFolder.Text)
            txtDefaultFolder.Focus()
            Return False
        End If
        If txtDisplayColumn.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblDisplayColumn.Text)
            txtDisplayColumn.Focus()
            Return False
        End If
        If txtDisplayRow.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(lblDisplayRow.Text)
            txtDisplayRow.Focus()
            Return False
        End If

        If cboDefaultSheet.Visible And cboDefaultSheet.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter("Sheet")
            cboDefaultSheet.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        txtDisplayColumn.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtDisplayRow.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtDefaultFolder.BackColor = COLOR_BACKCOLOROBLIGATORY
        cboDefaultSheet.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    'Private Function GetStringColumnExcel(ByVal sColumn As Integer) As String
    '    If sColumn <= 25 Then
    '        Return Chr(sColumn + Asc("A"))
    '    Else
    '        Return (Chr(sColumn \ 26 + Asc("A") - 1) + Chr(sColumn Mod 26 + Asc("A"))).ToString
    '    End If
    'End Function

    Private Sub btnExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        If Not AllowExport() Then Exit Sub
        ExecuteSQL(SQLDeleteD91T2223() & vbCrLf & SQLInsertD91T2223().ToString)
        If txtDisplayColumn.Text = "" Then txtDisplayColumn.Text = "A"
        If txtDisplayRow.Text = "0" Or txtDisplayRow.Text = "" Then txtDisplayRow.Text = "1"
        ExportExel(_flexGrid)

    End Sub


    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Int32

    Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32

    Public Function TerminateExcel() As Boolean

        Dim ClassName As String = "XLMain"

        Dim WindowHandle As Int32

        Dim ReturnVal As Int32

        Const WM_QUIT = &H12

        Do

            WindowHandle = FindWindow(ClassName, Nothing)

            If WindowHandle Then

                ReturnVal = PostMessage(WindowHandle, WM_QUIT, 0, 0)

            End If

        Loop Until WindowHandle = 0
        Return True
    End Function

    'Private Function CloseExe(ByVal fileName As String, Optional ByVal bShowMessage As Boolean = True) As Boolean
    '    Dim p As System.Diagnostics.Process = Nothing
    '    Try
    '        For Each pr As Process In Process.GetProcessesByName("EXCEL")
    '            If pr.MainWindowTitle.Contains(System.IO.Path.GetFileNameWithoutExtension(fileName)) Then 'OrElse pr.MainWindowTitle = sWindowName.Substring(0, sWindowName.LastIndexOf(".")) Then
    '                If p Is Nothing OrElse p.StartTime < pr.StartTime Then
    '                    p = pr
    '                    Exit For
    '                End If
    '            End If
    '        Next
    '        If p Is Nothing Then Return True
    '        'Update 05/04/2013
    '        Me.BringToFront()
    '        Me.Activate()
    '        If (D99C0008.MsgAsk(rl3("Ban_phai_dong_File") & Space(1) & System.IO.Path.GetFileNameWithoutExtension(fileName) & Space(1) & rl3("truoc_khi_xuat_Excel") & "." & vbCrLf & rl3("Ban_co_muon_dong_khong")) = Windows.Forms.DialogResult.Yes) Then
    '            p.Kill()
    '            Return True
    '        Else
    '            Return False
    '        End If
    '        Return True
    '    Catch ex As Exception
    '    End Try

    'End Function

    Private Sub txtDefaultFolder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDefaultFolder.TextChanged
        If txtDefaultFolder.Text <> "" Then
            SetBackColorObligatory()
        Else
            txtDisplayColumn.BackColor = Color.White
            txtDisplayRow.BackColor = Color.White
        End If
    End Sub

    Private Sub txtDefaultFolder_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDefaultFolder.Validated
        LoadcmbSheets()
    End Sub

    Private Sub cboDefaultSheet_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDefaultSheet.SelectionChangeCommitted
        tipSheet.SetToolTip(cboDefaultSheet, cboDefaultSheet.Text)
    End Sub

#Region "ExportExel"

    Private Function CopySheet(ByVal flex As C1.Win.C1FlexGrid.C1FlexGrid, ByVal SheetName As String, ByVal ExcelApp As Excel.ApplicationClass, ByRef objBook As Excel.Workbook, ByVal FileNameNew As String) As Excel.Worksheet
        Try
            If chkDisplayHeader.Checked Then
                flex.SaveExcel(FileNameNew, SheetName, FileFlags.IncludeFixedCells Or FileFlags.SaveMergedRanges) 'FileFlags.IncludeFixedCells Or
            Else
                flex.SaveExcel(FileNameNew, SheetName, FileFlags.VisibleOnly Or FileFlags.SaveMergedRanges) 'FileFlags.IncludeFixedCells Or
            End If

            'Định dạng các cột Excel
            'Instantiate the Application object.
            'Add a Workbook.
            objBook = ExcelApp.Workbooks.Open(FileNameNew)

            'Get the First sheet.
            Dim objSheet As Excel.Worksheet = CType(objBook.Sheets(SheetName), Excel.Worksheet)

            Dim oRng As Excel.Range
            Dim iFirstCol As Integer = GetIntColumnExcel(txtDisplayColumn.Text) 'Đổi cột Chuỗi sang Số (VD: cột A đổi thành cột 0)
            Dim finalColLetter As String = String.Empty
            Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim colCharsetLen As Integer = colCharset.Length
            If flex.Cols.Count - 1 > colCharsetLen Then
                finalColLetter = colCharset.Substring((flex.Cols.Count - 1 + iFirstCol) \ colCharsetLen - 1, 1)
            End If
            finalColLetter += colCharset.Substring((flex.Cols.Count - 1 + iFirstCol) Mod colCharsetLen, 1)
            Dim rowBegin As Integer = 1
            Dim rowCount As Integer = flex.Rows.Count - _flexGrid.Rows.Fixed
            If chkDisplayHeader.Checked Then rowBegin = _flexGrid.Rows.Fixed + 1 : rowCount = flex.Rows.Count
            ''Define a range object(A2).
            oRng = objSheet.Range(txtDisplayColumn.Text & rowBegin, finalColLetter & rowCount)
            'Get the borders collection.
            Dim borders As Excel.Borders = oRng.Borders
            ''Set the hair lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous
            borders.Weight = 2.0R
            If chkDisplayHeader.Checked Then 'Header
                oRng = objSheet.Range("A1", finalColLetter & flex.Rows.Fixed)
                oRng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)
            End If
            ''Data
            oRng = objSheet.Range(txtDisplayColumn.Text & rowBegin, finalColLetter & rowCount)
            oRng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

            oRng = objSheet.Range(txtDisplayColumn.Text & rowBegin, finalColLetter & rowCount)
            oRng.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Dim i As Integer = 0

            For i = _flexGrid.Rows.Fixed To flex.Rows.Count - 1
                Dim iLevel As Integer = L3Int(_flexGrid(i, "LevelID").ToString)
                oRng = objSheet.Range(txtDisplayColumn.Text & rowBegin, finalColLetter & rowBegin)
                Select Case iLevel
                    Case 1
                        If L3Bool(_txtColorGroup1.Tag) Then oRng.Font.Color = System.Drawing.ColorTranslator.ToOle(_txtColorGroup1.BackColor)
                    Case 2
                        If L3Bool(_txtColorGroup2.Tag) Then oRng.Font.Color = System.Drawing.ColorTranslator.ToOle(_txtColorGroup2.BackColor)
                    Case 3
                        If L3Bool(_txtColorGroup3.Tag) Then oRng.Font.Color = System.Drawing.ColorTranslator.ToOle(_txtColorGroup3.BackColor)
                End Select
                rowBegin += 1
            Next

            If chkDisplayHeader.Checked Then
                'Delete hide columns
                i = _flexGrid.Cols.Count - 1
                While i >= _flexGrid.Cols.Fixed
                    If _flexGrid.Cols(i).Visible = False Then objSheet.Columns(i + 1).Delete() 'objSheet.UsedRange.Columns(i).Delete()
                    i -= 1
                End While
                If _flexGrid.Cols.Fixed = 1 Then objSheet.Columns(1).Delete()
            End If

            Return objSheet
        Catch ex As Exception
            'If ex.Message = "Failed to create storage file." Then
            ' D99C0008.MsgL3(rl3("Ban_phai_dong_File") & Space(1) & FileNameNew.Substring(FileNameNew.LastIndexOf("\") + 1) & Space(1) & rl3("truoc_khi_xuat_Excel") & ".")
            '                ExcelApp.Quit()
            '               NAR(ExcelApp)
            'objBook.Close()
            'GoTo ErrorOpenFile
            'Else
            'D99C0008.MsgL3(ex.Message)
            'End If
            CloseProcessWindow(ExcelApp, FileNameNew, True)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Private Sub ExportExel(ByVal flex As C1.Win.C1FlexGrid.C1FlexGrid)
        Dim ExcelApp As New Excel.ApplicationClass()
        Dim objBook As Excel.Workbook = Nothing
        Dim fileName As String = gsApplicationPath + "\" & _formID & ".xls"
        Dim sFileName As String = _formID
        If txtDefaultFolder.Text <> "" Then fileName = txtDefaultFolder.Text : sFileName = txtDefaultFolder.Text.Substring(txtDefaultFolder.Text.LastIndexOf("\"c) + 1)

ErrorOpenFile:
        Try
            Dim sheetName As String = "sheet1"
            If txtDefaultFolder.Text <> "" Then sheetName = cboDefaultSheet.Text
            Dim objSheet As Excel.Worksheet = Nothing
            If txtDisplayColumn.Text = "A" And txtDisplayRow.Text = "1" Then
                objSheet = CopySheet(flex, sheetName, ExcelApp, objBook, fileName) 'fileNameNew
            Else 'Sao chép đến vị trí cần xuất
                Dim objSheet2 As Excel.Worksheet = CopySheet(flex, "Orginal", ExcelApp, objBook, fileName) 'fileNameNew
                objSheet = CType(objBook.Sheets(sheetName), Excel.Worksheet) 'GetStringColumnExcel(_colVisibleFirst) & 
                objSheet2.Range("A1:" & GetStringColumnExcel(flex.Cols.Count - 1) & flex.Rows.Count).Copy(Destination:=objSheet.Range(txtDisplayColumn.Text & txtDisplayRow.Text))
            End If
            ExcelApp.DisplayAlerts = False
            objBook.SaveAs(fileName) 'fileNameNew
            ExcelApp.Quit()
            ExcelApp.Workbooks.Open(fileName)
            objSheet = CType(ExcelApp.ActiveSheet, Excel.Worksheet)
            ExcelApp.Visible = True
            ' TerminateExcel()
        Catch ex As Exception
            'MsgErrorExcel(ex.Message)
            'Tạm thời chưa đóng được file Excel, để người dùng tự đóng
            '  If ex.Message = "Failed to create storage file." Then
            'D99C0008.MsgL3(rl3("Ban_phai_dong_File") & Space(1) & fileName.Substring(fileName.LastIndexOf("\") + 1) & Space(1) & rl3("truoc_khi_xuat_Excel") & ".")
            'ExcelApp.Quit()
            '  NAR(ExcelApp)
            'objBook.Close()
            'GoTo ErrorOpenFile
            '  Else
            '  D99C0008.MsgL3(ex.Message)
            ' End If
            CloseProcessWindow(ExcelApp, fileName, True)
        End Try
    End Sub

    Private Sub NAR(ByVal o As Object)

        Try

            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)

        Catch

        Finally

            o = Nothing

        End Try

    End Sub

    Private Function CloseProcessWindow(ByVal EXL As Excel.ApplicationClass, ByVal fileName As String, Optional ByVal bShowMessage As Boolean = True) As Boolean
        Dim bClosed As Boolean = False
        Try
            For Each wbExcel As Excel.Workbook In EXL.Workbooks
                If wbExcel.FullName = fileName Then
                    If bShowMessage Then
                        If (D99C0008.MsgAsk(rl3("Ban_phai_dong_File") & Space(1) & fileName.Substring(fileName.LastIndexOf("\") + 1) & Space(1) & rl3("truoc_khi_xuat_Excel") & "." & vbCrLf & rl3("Ban_co_muon_dong_khong")) = Windows.Forms.DialogResult.Yes) Then
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
        'Doan code dung de dong file Excel mo san (khong phai do Chuong trinh mo)
        If Not bClosed Then
            Dim p As System.Diagnostics.Process = Nothing
            Dim sWindowName As String = "Microsoft Excel - Data.xls"
            If fileName <> "" Then
                sWindowName = "Microsoft Excel - " & fileName.Substring(fileName.LastIndexOf("\") + 1)
            End If
            Try
                For Each pr As Process In Process.GetProcessesByName("EXCEL")
                    'Update 05/04/2013
                    If pr.MainWindowTitle.Contains(sWindowName) OrElse pr.MainWindowTitle = sWindowName.Substring(0, sWindowName.LastIndexOf(".")) Then
                        If p Is Nothing Then
                            p = pr
                        ElseIf p.StartTime < pr.StartTime Then
                            p = pr
                        End If
                    End If
                Next
                If p IsNot Nothing Then
                    'Update 05/04/2013
                    Me.BringToFront()
                    Me.Activate()
                    If (D99C0008.MsgAsk(rl3("Ban_phai_dong_File") & Space(1) & fileName.Substring(fileName.LastIndexOf("\") + 1) & Space(1) & rl3("truoc_khi_xuat_Excel") & "." & vbCrLf & rl3("Ban_co_muon_dong_khong")) = Windows.Forms.DialogResult.Yes) Then
                        p.Kill()
                        Return True
                    Else
                        Return False
                    End If
                End If
                Return False
            Catch ex As Exception
            End Try
        End If

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

#End Region
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T2223
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 24/12/2013 03:10:52
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T2223() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D91T2223"
        sSQL &= " Where ModuleID = " & SQLString(_moduleID) & " AND FormID = " & SQLString(_formID) & " AND ExportTypeID = " & SQLString(_exportTypeID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T2223
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 24/12/2013 03:12:03
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T2223() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("--Insert D91T2223" & vbCrLf)
        sSQL.Append("Insert Into D91T2223(")
        sSQL.Append("ModuleID, FormID, DisplayColumn, DisplayRow, PATH, ")
        sSQL.Append("SheetExcel, ExportTypeID")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(_moduleID) & COMMA) 'ModuleID, varchar[20], NOT NULL
        sSQL.Append(SQLString(_formID) & COMMA) 'FormID, varchar[20], NOT NULL
        sSQL.Append(SQLString(txtDisplayColumn.Text) & COMMA) 'DisplayColumn, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(txtDisplayRow.Text) & COMMA) 'DisplayRow, int, NOT NULL
        sSQL.Append(SQLString(txtDefaultFolder.Text) & COMMA) 'PATH, varchar[500], NOT NULL
        sSQL.Append(SQLString(cboDefaultSheet.Text) & COMMA) 'SheetExcel, varchar[100], NOT NULL
        sSQL.Append(SQLString(_exportTypeID)) 'ExportTypeID, varchar[50], NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function


    Private Sub txtDisplayRow_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisplayRow.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtDisplayColumn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisplayColumn.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Custom, "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
    End Sub

End Class