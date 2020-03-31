Imports System
'Imports Microsoft.Office.Interop
'Imports C1.C1Excel
Imports C1.Win.C1FlexGrid
Imports System.Threading
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core

Public Class D99F2223

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

    Private _txtColor As Textbox
    Public WriteOnly Property TxtColor() As Textbox
        Set(ByVal Value As Textbox)
            _txtColor = Value
        End Set
    End Property

    Private _styleBold As Boolean = False
    Public WriteOnly Property styleBold() As Boolean
        Set(ByVal Value As Boolean)
            _styleBold = Value
        End Set
    End Property

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
        'oWorkbook = Nothing
        '' Release the Application object
        'oExcel = Nothing
    End Sub

    Private Sub D99F2223_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Dim oExcel As Object
    Dim oWorkbook As Object

    Private Sub LoadcmbSheets(Optional ByVal sDefault As Object = "")
        Try
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
            If oExcel Is Nothing Then oExcel = CreateObject("Excel.Application")
            oWorkbook = oExcel.Workbooks.Open(txtDefaultFolder.Text) ' Create a new Excel Workbook
            'Dim oWorkSheet As Object
            '  oWorkbook = oExcel.Workbooks.Open(txtDefaultFolder.Text)
            For Each ews As Object In oWorkbook.Worksheets
                cboDefaultSheet.Items.Add(ews.Name)
            Next
            If sDefault.ToString = "" Then
                cboDefaultSheet.SelectedIndex = 0
            Else
                cboDefaultSheet.Text = sDefault.ToString
            End If
            tipSheet.SetToolTip(cboDefaultSheet, cboDefaultSheet.Text)
            '  Application.Workbooks("NewWorkbook.xlsx").Close(SaveChanges:=False) 'Đóng wookbook
            oWorkbook.Close(False, Type.Missing, Type.Missing)
        Catch ex As Exception
            oWorkbook = Nothing
            ' Release the Application object
            oExcel.Quit()
            System.GC.Collect()
            System.GC.WaitForPendingFinalizers()
        End Try
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
        If txtDefaultFolder.Text.Trim = "" Then Return True

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
        btnExportToExcel.Enabled = False
        ExportExel(_flexGrid)
        btnExportToExcel.Enabled = True
    End Sub

    Private Function CloseExe(ByVal fileName As String, Optional ByVal bShowMessage As Boolean = True) As Boolean
        Dim p As System.Diagnostics.Process = Nothing
        Try
            For Each pr As Process In Process.GetProcessesByName("EXCEL")
                If pr.MainWindowTitle.Contains(System.IO.Path.GetFileNameWithoutExtension(fileName)) Then 'OrElse pr.MainWindowTitle = sWindowName.Substring(0, sWindowName.LastIndexOf(".")) Then
                    If p Is Nothing OrElse p.StartTime < pr.StartTime Then
                        p = pr
                        Exit For
                    End If
                End If
            Next
            If p Is Nothing Then Return True
            'Update 05/04/2013
            Me.BringToFront()
            Me.Activate()
            If (D99C0008.MsgAsk(rl3("Ban_phai_dong_File") & Space(1) & System.IO.Path.GetFileNameWithoutExtension(fileName) & Space(1) & rl3("truoc_khi_xuat_Excel") & "." & vbCrLf & rL3("Ban_co_muon_dong_khong")) = Windows.Forms.DialogResult.Yes) Then
                p.Kill()
                Return True
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
        End Try

    End Function

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

    Private Function CopySheet(ByVal flex As C1.Win.C1FlexGrid.C1FlexGrid, ByVal SheetName As String, ByVal oExcel As Object, ByRef objBook As Object, ByVal FileNameNew As String) As Object
        flex.SaveExcel(FileNameNew, SheetName, FileFlags.IncludeFixedCells Or FileFlags.SaveMergedRanges) 'FileFlags.IncludeFixedCells Or
        'Định dạng các cột Excel
        'Instantiate the Application object.
        'Add a Workbook.
        objBook = oExcel.Workbooks.Open(FileNameNew)

        'Get the First sheet.
        Dim objSheet As Object = objBook.Sheets(SheetName)

        Dim oRng As Object 'Excel.Range
        Dim iFirstCol As Integer = GetIntColumnExcel("A") 'Đổi cột Chuỗi sang Số (VD: cột A đổi thành cột 0)
        Dim finalColLetter As String = String.Empty
        Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim colCharsetLen As Integer = colCharset.Length
        If flex.Cols.Count - 1 > colCharsetLen Then
            finalColLetter = colCharset.Substring((flex.Cols.Count - 1 + iFirstCol) \ colCharsetLen - 1, 1)
        End If
        finalColLetter += colCharset.Substring((flex.Cols.Count - 1 + iFirstCol) Mod colCharsetLen, 1)
        ''Define a range object(A2).
        oRng = objSheet.Range("A1", finalColLetter & flex.Rows.Count)
        'Get the borders collection.
        Dim borders As Object = oRng.Borders 'Excel.Borders = oRng.Borders
        ''Set the hair lines style.
        borders.LineStyle = 1 'Excel.XlLineStyle.xlContinuous
        borders.Weight = 2.0R
        'objBook.Save()
        'Header
        oRng = objSheet.Range("A1", finalColLetter & flex.Rows.Fixed)
        oRng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)
        'objBook.Save()
        ''Data
        oRng = objSheet.Range("A" & flex.Rows.Fixed + 1, finalColLetter & flex.Rows.Count)
        oRng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

        oRng = objSheet.Range("A" & flex.Rows.Fixed + 1, finalColLetter & flex.Rows.Count)
        oRng.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

        If L3Int(txtDisplayRow.Text) > 1 Then objSheet.Range("A1", finalColLetter & L3Int(txtDisplayRow.Text)).Insert()
        Return objSheet
    End Function


    Private Sub ExportExel(ByVal flex As C1.Win.C1FlexGrid.C1FlexGrid)
        If oExcel Is Nothing Then oExcel = CreateObject("Excel.Application")

        Dim fileName As String = gsApplicationPath + "\" & _formID & ".xls"
        Dim fileNameNew As String = ""
        Dim sFileName As String = _formID
        If txtDefaultFolder.Text <> "" Then
            fileName = txtDefaultFolder.Text
            sFileName = txtDefaultFolder.Text.Substring(txtDefaultFolder.Text.LastIndexOf("\"c) + 1)
        End If
        fileNameNew = fileName.Replace(sFileName, "Copy of " & sFileName)


        Try
            If txtDefaultFolder.Text = "" Then
                If IO.File.Exists(fileName) Then IO.File.Delete(fileName)
            Else
                If IO.File.Exists(fileNameNew) Then IO.File.Delete(fileNameNew)
            End If
        Catch ex As Exception
            If txtDefaultFolder.Text <> "" Then
                D99C0008.MsgL3(rL3("Ban_phai_dong_File") & Space(1) & fileNameNew & Space(1) & rL3("truoc_khi_xuat_Excel") & ".")
            Else
                D99C0008.MsgL3(rL3("Ban_phai_dong_File") & Space(1) & fileName & Space(1) & rL3("truoc_khi_xuat_Excel") & ".")
            End If

            btnExportToExcel.Enabled = True
            oExcel.Quit()
            Exit Sub
        End Try
        '*****************
        ' Dim oExcel As Object = CreateObject("Excel.Application")
        If giVersion2007 = -1 Then
            CheckVersionExcel(oExcel)
        End If

        'D99C0008.Msg(1)
        If giVersion2007 = 1 Then
            ' Kiểm tra nếu dữ liệu > 65530 dong hoặc >256 cột thì chỉ chạy trên Office 2007
            If flex.Rows.Count > 65530 Then
                MessageBox.Show(ConvertUnicodeToVietwareF(rL3("So_dong_vuot_qua_gioi_han_cho_phep_cua_Excel") & " (" & flex.Rows.Count & " > 65530)"), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Error)
                oExcel.Quit()
                btnExportToExcel.Enabled = True
                Exit Sub
            ElseIf flex.Cols.Count > 256 Then
                MessageBox.Show(ConvertUnicodeToVietwareF(rL3("So_cot_vuot_qua_gioi_han_cho_phep_cua_Excel") & " (" & flex.Cols.Count & "> 256)"), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Error)
                oExcel.Quit()
                btnExportToExcel.Enabled = True
                Exit Sub
            End If
        End If

        '******************************************************
        'Kiểm tra tồn tại file Excel đang xuất
        If CloseProcessWindowMax(fileName) = False Then oExcel.Quit() : Exit Sub
        Dim objBook As Object

ErrorOpenFile:
        Try
            Dim sheetName As String = "sheet1"
            If txtDefaultFolder.Text <> "" Then sheetName = cboDefaultSheet.Text
            Dim objSheet As Object
            'If txtDisplayColumn.Text = "A" And txtDisplayRow.Text = "1" Then
            '    objSheet = CopySheet(flex, sheetName, oExcel, objBook, fileName) 'fileNameNew
            'Else 'Sao chép đến vị trí cần xuất
            '    Dim objSheet2 As Object = CopySheet(flex, "Orginal", oExcel, objBook, fileName) 'fileNameNew
            '    objSheet = objBook.Worksheets(sheetName) 'GetStringColumnExcel(_colVisibleFirst) & 
            '    objSheet2.Range(GetStringColumnExcel(_colVisibleFirst) & "1:" & GetStringColumnExcel(flex.Cols.Count - 1) & flex.Rows.Count).Copy(Destination:=objSheet.Range(txtDisplayColumn.Text & txtDisplayRow.Text))
            'End If

            objSheet = CopySheet(flex, sheetName, oExcel, objBook, fileName) 'fileNameNew

            'Tắt cảnh báo hỏi có muốn Save As không?
            oExcel.DisplayAlerts = False

            If txtDefaultFolder.Text = "" Then
                If giVersion2007 = 1 Then
                    objBook.SaveAs(fileName, FileFormat:=56)
                Else
                    objBook.SaveAs(fileName)
                End If
                oExcel.Workbooks.Open(fileName)
            Else
                If giVersion2007 = 1 Then
                    objBook.SaveAs(fileNameNew, FileFormat:=56)
                Else
                    objBook.SaveAs(fileNameNew)
                End If
                oExcel.Workbooks.Open(fileNameNew)
            End If
            oExcel.Visible = True
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
            objBook.Close(False, Type.Missing, Type.Missing)
            ' Release the Application object
            oExcel.Quit()
            btnExportToExcel.Enabled = True
        Finally
            'objSheet = Nothing
            objBook = Nothing
            If oExcel IsNot Nothing Then oExcel = Nothing
            System.GC.Collect()
            System.GC.WaitForPendingFinalizers()
        End Try

    End Sub

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
        sSQL.Append(") Values(" & vbCrlf)
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



    Public Function CheckVersionExcel(ByVal appExcel As Object) As Boolean
        'Dim appExcel As New Microsoft.Office.Interop.Excel.Application
        ' appExcel = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        If L3Int(appExcel.Version) >= 12 Then
            Return True
        End If
        Return False
    End Function

    Public Function CloseProcessWindowMax(ByVal FileName As String, Optional ByVal bShowMessage As Boolean = True) As Boolean
        'Doan code dung de dong file Excel mo san (khong phai do Chuong trinh mo)
        Dim p As System.Diagnostics.Process = Nothing
        Dim sWindowName As String = "Microsoft Excel - " & FileName
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
                    If (D99C0008.MsgAsk(rL3("Ban_phai_dong_File") & Space(1) & FileName & Space(1) & rL3("truoc_khi_xuat_Excel") & "." & vbCrLf & rL3("Ban_co_muon_dong_khong")) = Windows.Forms.DialogResult.Yes) Then
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

   

End Class