Imports System
Imports C1.Win.C1FlexGrid
Imports C1.C1Excel
Imports Microsoft.Office.Interop
Public Class D25F3051

    Dim dtGrid As DataTable

    Private Const COL_LevelID As String = "LevelID"
    Private Const COL_OrderNo As String = "OrderNo"
    Private Const COL_GroupID As String = "GroupID"
    Private Const COL_GroupName As String = "GroupName"
    Dim bfirstRun As Boolean = True

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, flxGrid)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnClose)

    End Sub

    Private Sub D25F3051_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        LoadLanguage()
        c1dateVoucherDateFrom.Value = CDate("01/" & Now.Month.ToString & "/" & Now.Year.ToString)
        c1dateVoucherDateTo.Value = CDate(Date.DaysInMonth(Now.Year, Now.Month).ToString & "/" & Now.Month.ToString & "/" & Now.Year.ToString)
        LoadTDBCombo()
        LoadDefaults()
        SetBackColorObligatory()
        SetShortcutPopupMenu(Me, Nothing, ContextMenuStrip1)
        InputbyUnicode(Me, gbUnicode)
        InputDateCustomFormat(c1dateVoucherDateTo, c1dateVoucherDateFrom)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Thong_ke_ke_hoach_tuyen_dung") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Thçng k£ kÕ hoÁch tuyÓn dóng
        '================================================================ 
        lblteVoucherDateFrom.Text = rl3("Ngay") 'Ngày
        lblRecruitmentFileID.Text = rl3("Ke_hoach_TD") 'Kế hoạch TD
        lblColDataTypeID.Text = rl3("Loai_thong_ke") 'Loại thống kê
        lblGroupID3.Text = rl3("Nhom") & " 3" 'Nhóm 3
        lblGroupID2.Text = rl3("Nhom") & " 2" 'Nhóm 2
        lblGroupID1.Text = rL3("Nhom") & " 1" 'Nhóm 1
        lblDivisionID.Text = rL3("Don_vi") 'Đơn vị
        lblStatisticTime.Text = rL3("Thoi_gian_thong_ke") 'Thời gian thống kê
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        '================================================================ 
        chkIsIntergrateSex.Text = rl3("Tong_hop_theo_gioi_tinh") 'Tổng hợp theo giới tính
        '================================================================ 
        grpColData.Text = rl3("Du_lieu_cot") 'Dữ liệu cột
        grpDataGroup.Text = rl3("Du_lieu_nhom") 'Dữ liệu nhóm
        '================================================================ 
        tdbcRecruitmentFileID.Columns("VoucherNo").Caption = rl3("Ma") 'Mã
        tdbcRecruitmentFileID.Columns("RecruitmentFileName").Caption = rl3("Ten") 'Tên
        tdbcColDataTypeID.Columns("ColDataTypeID").Caption = rl3("Ma") 'Mã
        tdbcColDataTypeID.Columns("ColDataTypeName").Caption = rl3("Ten") 'Tên
        tdbcGroupID3.Columns("GroupID").Caption = rl3("Ma") 'Mã
        tdbcGroupID3.Columns("GroupName").Caption = rl3("Ten") 'Tên
        tdbcGroupID2.Columns("GroupID").Caption = rl3("Ma") 'Mã
        tdbcGroupID2.Columns("GroupName").Caption = rl3("Ten") 'Tên
        tdbcGroupID1.Columns("GroupID").Caption = rl3("Ma") 'Mã
        tdbcGroupID1.Columns("GroupName").Caption = rL3("Ten") 'Tên
        tdbcDivisionID.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên
        tdbcStatisticTime.Columns("ID").Caption = rL3("Ma") 'Mã
        tdbcStatisticTime.Columns("Name").Caption = rL3("Ten") 'Tên
        '================================================================ 
        flxGrid.Cols(COL_OrderNo).Caption = rl3("STT")
        flxGrid.Cols(COL_GroupID).Caption = rl3("Ma")
        flxGrid.Cols(COL_GroupName).Caption = rl3("Ten")
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcStatisticTime
        sSQL = "SELECT ID, " & IIf(geLanguage = EnumLanguage.Vietnamese, "Name84", "Name01").ToString & UnicodeJoin(gbUnicode) & " as Name, FromDate, ToDate" & vbCrLf
        sSQL &= "FROM D25N5555 ('D25F3051'," & SQLString(gsDivisionID) & "," & SQLString(giTranMonth) & "," & SQLString(giTranYear) & ", '', '')" & vbCrLf
        sSQL &= "ORDER BY ID" & vbCrLf
        LoadDataSource(tdbcStatisticTime, sSQL, gbUnicode)

        'Load Division
        LoadCboDivisionIDAll(tdbcDivisionID, "D09", True, gbUnicode)

        'Load tdbcRecruitmentFileID
        LoadTDBCRecruitmentFileID()

        'Load tdbcColDataTypeID
        LoadDataSource(tdbcColDataTypeID, SQLStoreD09P0200("Combo Loại thống kê", "StatisticData"), gbUnicode)
        tdbcColDataTypeID.SelectedValue = "EducationLevel"

        'Load tdbcGroupID1,tdbcGroupID2,tdbcGroupID3
        LoadComboGroupID()
    End Sub

    Private Sub LoadComboGroupID()
        Dim dtGroup As DataTable = ReturnDataTable(SQLStoreD09P0200("Combo Nhóm 1-3", "GroupData"))
        LoadDataSource(tdbcGroupID1, dtGroup.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcGroupID2, dtGroup.DefaultView.ToTable, gbUnicode)
        LoadDataSource(tdbcGroupID3, dtGroup.DefaultView.ToTable, gbUnicode)
        tdbcGroupID1.SelectedIndex = 0
    End Sub

    Private Sub LoadDefaults()
        tdbcStatisticTime.SelectedIndex = 0
        tdbcDivisionID.SelectedValue = "%"
    End Sub

    Private Sub LoadTDBCRecruitmentFileID()
        If c1dateVoucherDateFrom.Text = "" Or c1dateVoucherDateTo.Text = "" Then Exit Sub
        LoadDataSource(tdbcRecruitmentFileID, SQLStoreD09P0200("Combo ke hoach tuyen dung", "RecruimentFile"), gbUnicode)
        tdbcRecruitmentFileID.SelectedIndex = 0
    End Sub

    Private Sub AddColFirst()
        'Add col vào lưới
        flxGrid.Cols.Add()
        flxGrid.Cols(flxGrid.Cols.Count - 1).Name = COL_LevelID
        flxGrid.Cols(COL_LevelID).Caption = COL_LevelID
        flxGrid.Cols(COL_LevelID).Visible = False

        'Add col vào lưới
        flxGrid.Cols.Add()
        flxGrid.Cols(flxGrid.Cols.Count - 1).Name = COL_OrderNo
        flxGrid.Cols(COL_OrderNo).Caption = rl3("STT")
        flxGrid.Cols(COL_OrderNo).Width = 50
        flxGrid.Cols(COL_OrderNo).StyleFixedDisplay.TextAlign = TextAlignEnum.CenterCenter
        flxGrid.Cols(COL_OrderNo).TextAlign = TextAlignEnum.CenterCenter

        'Add col vào lưới
        flxGrid.Cols.Add()
        flxGrid.Cols(flxGrid.Cols.Count - 1).Name = COL_GroupID
        flxGrid.Cols(COL_GroupID).Caption = rl3("Ma")
        flxGrid.Cols(COL_GroupID).Width = 110
        flxGrid.Cols(COL_GroupID).StyleFixedDisplay.TextAlign = TextAlignEnum.CenterCenter
        flxGrid.Cols(COL_GroupID).TextAlign = TextAlignEnum.LeftCenter

        'Add col vào lưới
        flxGrid.Cols.Add()
        flxGrid.Cols(flxGrid.Cols.Count - 1).Name = COL_GroupName
        flxGrid.Cols(COL_GroupName).Caption = rl3("Ten")
        flxGrid.Cols(COL_GroupName).Width = 170
        flxGrid.Cols(COL_GroupName).StyleFixedDisplay.TextAlign = TextAlignEnum.CenterCenter
        flxGrid.Cols(COL_GroupName).TextAlign = TextAlignEnum.LeftCenter
    End Sub

    Private Sub LoadCaptionGrid()
        Try
            'For i As Integer = flxGrid.Cols.Count - 1 To flxGrid.Cols(COL_GroupName).Index + 1 Step -1
            '    flxGrid.Cols.Remove(i)
            'Next
            For i As Integer = flxGrid.Cols.Count - 1 To 1 Step -1
                flxGrid.Cols.Remove(i)
            Next

            AddColFirst()

            Dim dsCaption As DataSet = ReturnDataSet(SQLStoreD09P0200("Do nguon xay dung caption dong nhieu lop", ReturnValueC1Combo(tdbcColDataTypeID).ToString))
            Dim iMaxRow As Integer = L3Int(dsCaption.Tables.Count)
            If iMaxRow = 0 Then Exit Sub
            If bfirstRun Then
                If flxGrid.Rows.Count <= 1 Then flxGrid.Rows.Count = iMaxRow
                bfirstRun = False
            End If

            flxGrid.Rows.Fixed = iMaxRow
            flxGrid.AllowMerging = AllowMergingEnum.FixedOnly
            flxGrid.Styles.Normal.WordWrap = True
            'Merge cột cố định
            flxGrid.Cols(0).AllowMerging = True
            flxGrid.Cols(COL_OrderNo).AllowMerging = True
            flxGrid.Cols(COL_GroupID).AllowMerging = True
            flxGrid.Cols(COL_GroupName).AllowMerging = True

            Dim rng As CellRange = flxGrid.GetCellRange(0, 0, iMaxRow - 1, 0)
            ' Dim rng As CellRange = flxGrid.GetCellRange(0, 0, flxGrid.Rows.Count - 1, 0)
            rng.Data = " "

            rng = flxGrid.GetCellRange(0, flxGrid.Cols(COL_OrderNo).Index, iMaxRow - 1, flxGrid.Cols(COL_OrderNo).Index)
            rng.Data = flxGrid.Cols(COL_OrderNo).Caption

            rng = flxGrid.GetCellRange(0, flxGrid.Cols(COL_GroupID).Index, iMaxRow - 1, flxGrid.Cols(COL_GroupID).Index)
            rng.Data = flxGrid.Cols(COL_GroupID).Caption

            rng = flxGrid.GetCellRange(0, flxGrid.Cols(COL_GroupName).Index, iMaxRow - 1, flxGrid.Cols(COL_GroupName).Index)
            rng.Data = flxGrid.Cols(COL_GroupName).Caption

            'Load cột động
            Dim sField(iMaxRow - 1) As String 'Mảng lưu tiền tố caption theo từng class
            Dim iIndex(iMaxRow - 1) As Integer 'Mảng lưu index col bắt đầu theo class
            LoadDataField(dsCaption, 0, sField, iIndex)

            'Đổ nguồn
            dtGrid = ReturnDataTable(SQLStoreD25P3051)
            flxGrid.SetDataBinding(dtGrid, "")
            mnsExportToExcel.Enabled = dtGrid.Rows.Count > 0
        Catch ex As Exception
            'D99C0008.MsgL3(ex.Message)
        End Try
    End Sub

    'Hàm đệ quy Add cột
    Private Sub LoadDataField(ByVal dsCaption As DataSet, ByVal i As Integer, ByVal arrField() As String, ByVal iIndex() As Integer)
        If iIndex(i) = 0 Then iIndex(i) = flxGrid.Cols.Count - 1
        For k As Integer = 0 To dsCaption.Tables(i).Rows.Count - 1
            'Gán caption theo class vào mảng
            arrField(i) = dsCaption.Tables(i).Rows(k).Item("CaptionLevelID").ToString
            'Nếu không phải class cuối thì ko add col, nhưng gán text cho range theo class
            If i < dsCaption.Tables.Count - 1 Then
                'Gọi đệ quy để lấy table cuối
                LoadDataField(dsCaption, i + 1, arrField, iIndex)
                'Merge range theo class
                flxGrid.Rows(i).AllowMerging = True
                Dim startIndex As Integer = iIndex(i) + 1
                Dim rng As CellRange = flxGrid.GetCellRange(i, startIndex, i, flxGrid.Cols.Count - 1)
                rng.Data = dsCaption.Tables(i).Rows(k).Item("CaptionLevelName").ToString
                'gán lại cho index
                iIndex(i) = flxGrid.Cols.Count - 1
            Else
                'Add col vào lưới
                flxGrid.Cols.Add()
                flxGrid.Cols(flxGrid.Cols.Count - 1).Name = String.Join("_", arrField)
                flxGrid(i, flxGrid.Cols.Count - 1) = dsCaption.Tables(i).Rows(k).Item("CaptionLevelName").ToString
                flxGrid.Cols(flxGrid.Cols.Count - 1).Width = 80
                flxGrid.Cols(flxGrid.Cols.Count - 1).StyleFixedDisplay.TextAlign = TextAlignEnum.CenterCenter
                flxGrid.Cols(flxGrid.Cols.Count - 1).TextAlign = TextAlignEnum.RightCenter
                If dsCaption.Tables(i).Columns.Contains("DataType") Then
                    If dsCaption.Tables(i).Rows(k).Item("DataType").ToString = "N" Then
                        If dsCaption.Tables(i).Columns.Contains("DataFormat") AndAlso dsCaption.Tables(i).Rows(k).Item("DataFormat").ToString <> "" Then
                            flxGrid.Cols(flxGrid.Cols.Count - 1).Format = "N" & dsCaption.Tables(i).Rows(k).Item("DataFormat").ToString
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub D25F3051_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P0200
    '# Created User: Huỳnh Ngọc Minh Tâm
    '# Created Date: 04/07/2014 10:40:01
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P0200(ByVal sCom As String, ByVal sType As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sCom & vbCrLf)
        sSQL &= "Exec D09P0200 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(sType) & COMMA 'Type, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsIntergrateSex.Checked) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateFrom.Value) & COMMA 'FromDate, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateTo.Value) & COMMA 'ToDate, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecruitmentFileID)) & COMMA  'VoucherID01, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcColDataTypeID, "ParentCode")) 'ParentCode, varchar[150], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P3051
    '# Created User: THANHHUYEN
    '# Created Date: 19/11/2013 04:53:30
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P3051() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho grid" & vbCrLf)
        sSQL &= "Exec D25P3051 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateFrom.Value) & COMMA 'FromDate, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateVoucherDateTo.Value) & COMMA 'ToDate, datetime, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcGroupID1)) & COMMA 'Group1, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcGroupID2)) & COMMA 'Group2, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcGroupID3)) & COMMA 'Group3, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcRecruitmentFileID)) & COMMA 'RecruitmentFileID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcColDataTypeID)) & COMMA 'ColDataTypeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsIntergrateSex.Checked) & COMMA 'IsIntergrateSex, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub GetColorDialog(ByVal txtColor As TextBox)
        'Đổi màu color sang integer
        ' Keeps the user from selecting a custom color.
        ColorDialog1.AllowFullOpen = True
        ' Assigns an array of custom colors to the CustomColors property.
        ColorDialog1.CustomColors = New Integer() {14480885, 15195440, 16107657, 1836924, _
           3758726, 12566463, 7526079, 7405793, 6945974, 241502, 2296476, 5130294, _
           3102017, 7324121, 14993507, 11730944}
        ' Allows the user to get help. (The default is false.)
        ColorDialog1.ShowHelp = False
        ' Sets the initial color select to the current text color,
        ColorDialog1.Color = txtColor.BackColor

        ' Update the text box color if the user clicks OK 
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            'Không dùng kiểu này vì các màu lên không đúng như mong muốn
            txtColor.BackColor = Color.FromArgb(ColorDialog1.Color.ToArgb)
            ' txtColor.Text = ColorTranslator.ToHtml(txtColor.BackColor).ToString.Substring(1) 'Bỏ dấu #
        End If
        ColorDialog1.Dispose()
        flxGrid.Refresh()
    End Sub

    Private Sub btnColor1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor1.Click
        GetColorDialog(txtColor1)
    End Sub

    Private Sub btnColor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor2.Click
        GetColorDialog(txtColor2)
    End Sub

    Private Sub btnColor3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor3.Click
        GetColorDialog(txtColor3)
    End Sub

    Private Function AllowFilter() As Boolean
        If c1dateVoucherDateFrom.Text <> "" And c1dateVoucherDateTo.Text <> "" Then
            If Not CheckValidDateFromTo(c1dateVoucherDateFrom, c1dateVoucherDateTo) Then
                Return False
            End If
        End If
        If tdbcColDataTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Loai_thong_ke"))
            tdbcColDataTypeID.Focus()
            Return False
        End If
        If tdbcGroupID1.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nhom_1"))
            tdbcGroupID1.Focus()
            Return False
        End If
        If tdbcGroupID1.Text.Trim <> "" And tdbcGroupID3.Text.Trim <> "" And tdbcGroupID2.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nhom_2"))
            tdbcGroupID2.Focus()
            Return False
        End If
        If tdbcRecruitmentFileID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ke_hoach_TD"))
            tdbcRecruitmentFileID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcColDataTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcGroupID1.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcRecruitmentFileID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        LoadCaptionGrid()
    End Sub

    Private Sub flxGrid_OwnerDrawCell(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles flxGrid.OwnerDrawCell
        Try
            If dtGrid Is Nothing OrElse dtGrid.Rows.Count = 0 Then Exit Sub
            If e.Row < flxGrid.Rows.Fixed OrElse flxGrid.DataSource Is Nothing Then Exit Sub 'Chỉ cho dòng dữ liệu
            If e.Col > flxGrid.Cols(COL_GroupName).Index AndAlso flxGrid(e.Row, e.Col).ToString = "0" Then
                e.Text = ""
            End If
            Select Case L3Int(flxGrid(e.Row, COL_LevelID).ToString)
                Case 1
                    e.Style.ForeColor = txtColor1.BackColor
                Case 2
                    e.Style.ForeColor = txtColor2.BackColor
                Case 3
                    e.Style.ForeColor = txtColor3.BackColor
            End Select
            flxGrid.Styles.Fixed.ForeColor = Color.Black 'Chặn set màu cho caption
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnsExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsExportToExcel.Click
        Me.Cursor = Cursors.WaitCursor
        ExportExel(flxGrid)
        Me.Cursor = Cursors.Default
    End Sub

#Region "ExportExel"

    Private Sub ExportExel(ByVal flex As C1.Win.C1FlexGrid.C1FlexGrid)
        Dim ExcelApp As New Excel.ApplicationClass()
        Dim objBook As Excel.Workbook
        Dim fileName As String = gsApplicationPath + "\Data.xls" 'Application.StartupPath + "\Data.xls"
ErrorOpenFile:
        Try
            flex.SaveExcel(fileName, "sheet1", FileFlags.IncludeFixedCells Or FileFlags.SaveMergedRanges) 'FileFlags.IncludeFixedCells Or
            'Định dạng các cột Excel
            'Instantiate the Application object.
            'Add a Workbook.
            objBook = ExcelApp.Workbooks.Open(fileName)

            'Get the First sheet.
            Dim objSheet As Excel.Worksheet = CType(objBook.Sheets("sheet1"), Excel.Worksheet)

            Dim oRng As Excel.Range
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
            Dim borders As Excel.Borders = oRng.Borders
            ''Set the hair lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous
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

            For i As Integer = flex.Rows.Fixed To flex.Rows.Count - 1
                Select Case L3Int(flxGrid(i, COL_LevelID).ToString)
                    Case 1
                        oRng = objSheet.Range("A" & i + 1, finalColLetter & i + 1)
                        oRng.Font.Color = System.Drawing.ColorTranslator.ToOle(txtColor1.BackColor)
                    Case 2
                        oRng = objSheet.Range("A" & i + 1, finalColLetter & i + 1)
                        oRng.Font.Color = System.Drawing.ColorTranslator.ToOle(txtColor2.BackColor)
                    Case 3
                        oRng = objSheet.Range("A" & i + 1, finalColLetter & i + 1)
                        oRng.Font.Color = System.Drawing.ColorTranslator.ToOle(txtColor3.BackColor)
                End Select
            Next

            'objBook.Save()
            oRng = objSheet.Range("A1", "A3")
            oRng.EntireColumn.Delete()

            oRng = objSheet.Range("A1", "A3")
            oRng.EntireColumn.Delete()

            'Save the excel file.
            ExcelApp.DisplayAlerts = False
            objBook.Save()
            ExcelApp.Quit()

            ExcelApp.Workbooks.Open(fileName)
            ExcelApp.Visible = True
        Catch ex As Exception
            'MsgErrorExcel(ex.Message)
            'Tạm thời chưa đóng được file Excel, để người dùng tự đóng
            If ex.Message = "Failed to create storage file." Then
                D99C0008.MsgL3(rl3("Ban_phai_dong_File") & Space(1) & fileName.Substring(fileName.LastIndexOf("\") + 1) & Space(1) & rl3("truoc_khi_xuat_Excel") & ".")
                'ExcelApp.Quit()
                'objBook.Close()
                GoTo ErrorOpenFile
            End If
            'If CloseProcessWindow(ExcelApp, fileName) Then GoTo ErrorOpenFile
            'Finally
            '    ' Clean up the unmanaged Excel COM resources by explicitly call 
            '    ' Marshal.FinalReleaseComObject on all accessor objects. 
            '    ' See http://support.microsoft.com/kb/317109.
            '    If Not oRng2 Is Nothing Then
            '        Marshal.FinalReleaseComObject(oRng2)
            '        oRng2 = Nothing
            '    End If
            '    If Not oRng1 Is Nothing Then
            '        Marshal.FinalReleaseComObject(oRng1)
            '        oRng1 = Nothing
            '    End If
            '    If Not oCells Is Nothing Then
            '        Marshal.FinalReleaseComObject(oCells)
            '        oCells = Nothing
            '    End If
            '    If Not oSheet Is Nothing Then
            '        Marshal.FinalReleaseComObject(oSheet)
            '        oSheet = Nothing
            '    End If
            '    If Not oWB Is Nothing Then
            '        Marshal.FinalReleaseComObject(oWB)
            '        oWB = Nothing
            '    End If
            '    If Not oWBs Is Nothing Then
            '        Marshal.FinalReleaseComObject(oWBs)
            '        oWBs = Nothing
            '    End If
            '    If Not oXL Is Nothing Then
            '        Marshal.FinalReleaseComObject(oXL)
            '        oXL = Nothing
            '    End If
        End Try
    End Sub

    Private Function GetIntColumnExcel(ByVal sColumn As String) As Integer
        If sColumn.Length = 1 Then

            Return (Asc(sColumn) - Asc("A"))
        Else
            Return (Asc(sColumn.Substring(0, 1)) - Asc("A") + 1) * 26 + (Asc(sColumn.Substring(1, 1)) - Asc("A"))
        End If

    End Function

    Private Sub SaveSheet(ByVal _styles As Hashtable, ByVal flex As C1.Win.C1FlexGrid.C1FlexGrid, ByVal sheet As XLSheet, ByVal fixedCells As Boolean, ByVal book As C1.C1Excel.C1XLBook, Optional ByVal eRowBegin As Integer = 0, Optional ByVal eColBegin As Integer = 0)
        'account for fixed cells
        Dim frows As Integer = flex.Rows.Fixed
        Dim fcols As Integer = flex.Cols.Fixed
        If fixedCells Then frows = 0 : fcols = 0
        'copy dimensions
        Dim lastRow As Integer = flex.Rows.Count - frows - 1
        Dim lastCol As Integer = flex.Cols.Count - fcols - 1
        If lastRow < 0 Or lastCol < 0 Then Exit Sub
        Dim cell As XLCell = sheet(lastRow, lastCol)
        'set default properties
        sheet.Book.DefaultFont = flex.Font
        sheet.DefaultRowHeight = C1XLBook.PixelsToTwips(flex.Rows.DefaultSize)
        sheet.DefaultColumnWidth = C1XLBook.PixelsToTwips(flex.Cols.DefaultSize)
        'prepare to convert styles
        _styles = New Hashtable()
        'set row/column properties
        For r As Integer = frows To flex.Rows.Count - 1
            'size/visibility
            Dim fr As Row = flex.Rows(r)
            Dim xr As XLRow = sheet.Rows(r - frows + eRowBegin)
            If fr.Height >= 0 Then xr.Height = C1XLBook.PixelsToTwips(fr.Height)
            xr.Visible = fr.Visible
            'style
            Dim xs As XLStyle = StyleFromFlex(fr.Style, _styles, book)
            If xs IsNot Nothing Then xr.Style = xs

            For c As Integer = fcols To flex.Cols.Count - 1
                'size/visibility
                Dim fc As Column = flex.Cols(c)
                Dim xc As XLColumn = sheet.Columns(c - fcols + eColBegin)
                If fc.Width >= 0 Then xc.Width = C1XLBook.PixelsToTwips(fc.Width)
                xc.Visible = fc.Visible
                'style
                'Dim xsc As XLStyle = StyleFromFlex(fc.Style, _styles, book)
                'If xsc IsNot Nothing Then xc.Style = xsc
                'Get cell
                cell = sheet(r - frows + eRowBegin, c - fcols + eColBegin)
                'apply content
                cell.Value = flex(r, c)
                '			// apply style
                Dim xscell As XLStyle = StyleFromFlex(flex.GetCellStyle(r, c), _styles, book)
                If xscell IsNot Nothing Then cell.Style = xscell
            Next

        Next
    End Sub

    'convert Excel style into FlexGrid style
    Private Function StyleFromFlex(ByVal style As CellStyle, ByVal _styles As Hashtable, ByVal _book As C1.C1Excel.C1XLBook) As XLStyle
        'sanity
        If style Is Nothing Then Return Nothing
        'look it up on list
        If _styles.Contains(style) Then Return CType(_styles(style), XLStyle)
        'create new Excel style
        Dim xs As XLStyle = New XLStyle(_book)
        'set up new style
        xs.Font = style.Font

        xs.BackColor = style.BackColor

        xs.ForeColor = style.ForeColor

        xs.WordWrap = style.WordWrap
        xs.Format = XLStyle.FormatDotNetToXL(style.Format)
        Select Case style.TextDirection
            Case TextDirectionEnum.Up
                xs.Rotation = 90
            Case TextDirectionEnum.Down
                xs.Rotation = 180
        End Select
        Select Case style.TextAlign
            Case TextAlignEnum.CenterBottom
                xs.AlignHorz = XLAlignHorzEnum.Center
                xs.AlignVert = XLAlignVertEnum.Bottom

            Case TextAlignEnum.CenterCenter
                xs.AlignHorz = XLAlignHorzEnum.Center
                xs.AlignVert = XLAlignVertEnum.Center

            Case TextAlignEnum.CenterTop
                xs.AlignHorz = XLAlignHorzEnum.Center
                xs.AlignVert = XLAlignVertEnum.Top

            Case TextAlignEnum.GeneralBottom
                xs.AlignHorz = XLAlignHorzEnum.General
                xs.AlignVert = XLAlignVertEnum.Bottom

            Case TextAlignEnum.GeneralCenter
                xs.AlignHorz = XLAlignHorzEnum.General
                xs.AlignVert = XLAlignVertEnum.Center

            Case TextAlignEnum.GeneralTop
                xs.AlignHorz = XLAlignHorzEnum.General
                xs.AlignVert = XLAlignVertEnum.Top

            Case TextAlignEnum.LeftBottom
                xs.AlignHorz = XLAlignHorzEnum.Left
                xs.AlignVert = XLAlignVertEnum.Bottom

            Case TextAlignEnum.LeftCenter
                xs.AlignHorz = XLAlignHorzEnum.Left
                xs.AlignVert = XLAlignVertEnum.Center

            Case TextAlignEnum.LeftTop
                xs.AlignHorz = XLAlignHorzEnum.Left
                xs.AlignVert = XLAlignVertEnum.Top

            Case TextAlignEnum.RightBottom
                xs.AlignHorz = XLAlignHorzEnum.Right
                xs.AlignVert = XLAlignVertEnum.Bottom

            Case TextAlignEnum.RightCenter
                xs.AlignHorz = XLAlignHorzEnum.Right
                xs.AlignVert = XLAlignVertEnum.Center

            Case TextAlignEnum.RightTop
                xs.AlignHorz = XLAlignHorzEnum.Right
                xs.AlignVert = XLAlignVertEnum.Top

            Case Else
                Debug.Assert(False)
        End Select

        'save it
        _styles.Add(style, xs)
        Return xs
    End Function

#End Region

    Private Sub tdbcGroupID1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupID1.SelectedValueChanged
        If tdbcGroupID1.SelectedValue Is Nothing Or tdbcGroupID1.Text = "" Then Exit Sub
        If ReturnValueC1Combo(tdbcGroupID1).ToString = ReturnValueC1Combo(tdbcGroupID2).ToString Or ReturnValueC1Combo(tdbcGroupID1).ToString = ReturnValueC1Combo(tdbcGroupID3).ToString Then
            D99C0008.MsgL3(rl3("Ban_khong_duoc_chon_trung_nhom"))
            tdbcGroupID1.Text = ""
        End If
    End Sub

    Private Sub tdbcGroupID2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupID2.SelectedValueChanged
        If tdbcGroupID2.SelectedValue Is Nothing Or tdbcGroupID2.Text = "" Then Exit Sub
        If ReturnValueC1Combo(tdbcGroupID1).ToString = ReturnValueC1Combo(tdbcGroupID2).ToString Or ReturnValueC1Combo(tdbcGroupID2).ToString = ReturnValueC1Combo(tdbcGroupID3).ToString Then
            D99C0008.MsgL3(rl3("Ban_khong_duoc_chon_trung_nhom"))
            tdbcGroupID2.Text = ""
        End If
    End Sub

    Private Sub tdbcGroupID3_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupID3.SelectedValueChanged
        If tdbcGroupID3.SelectedValue Is Nothing Or tdbcGroupID3.Text = "" Then Exit Sub
        If ReturnValueC1Combo(tdbcGroupID1).ToString = ReturnValueC1Combo(tdbcGroupID3).ToString Or ReturnValueC1Combo(tdbcGroupID2).ToString = ReturnValueC1Combo(tdbcGroupID3).ToString Then
            D99C0008.MsgL3(rl3("Ban_khong_duoc_chon_trung_nhom"))
            tdbcGroupID3.Text = ""
        End If
    End Sub

#Region "Events tdbcRecruitmentFileID"

    Private Sub tdbcRecruitmentFileID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRecruitmentFileID.LostFocus
        If tdbcRecruitmentFileID.FindStringExact(tdbcRecruitmentFileID.Text) = -1 Then tdbcRecruitmentFileID.Text = ""
    End Sub

#End Region

#Region "Events tdbcColDataTypeID"

    Private Sub tdbcColDataTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcColDataTypeID.LostFocus
        If tdbcColDataTypeID.FindStringExact(tdbcColDataTypeID.Text) = -1 Then tdbcColDataTypeID.Text = ""
    End Sub

    Private Sub tdbcColDataTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcColDataTypeID.SelectedValueChanged
        If tdbcColDataTypeID.SelectedValue Is Nothing Or tdbcColDataTypeID.Text = "" Then Exit Sub
        LoadComboGroupID()
        chkIsIntergrateSex.Enabled = L3Bool(ReturnValueC1Combo(tdbcColDataTypeID, "IsIntergrateSex"))
    End Sub

#End Region

#Region "Events tdbcGroupID3"

    Private Sub tdbcGroupID3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupID3.LostFocus
        If tdbcGroupID3.FindStringExact(tdbcGroupID3.Text) = -1 Then tdbcGroupID3.Text = ""
    End Sub

#End Region

#Region "Events tdbcGroupID2"

    Private Sub tdbcGroupID2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupID2.LostFocus
        If tdbcGroupID2.FindStringExact(tdbcGroupID2.Text) = -1 Then tdbcGroupID2.Text = ""
    End Sub

#End Region

#Region "Events tdbcGroupID1"

    Private Sub tdbcGroupID1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupID1.LostFocus
        If tdbcGroupID1.FindStringExact(tdbcGroupID1.Text) = -1 Then tdbcGroupID1.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupID1.Close, tdbcStatisticTime.Close, tdbcDivisionID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupID1.Validated, tdbcStatisticTime.Validated, tdbcDivisionID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub c1dateVoucherDateFrom_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateVoucherDateFrom.Validated
        If c1dateVoucherDateFrom.Text = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ngay_hieu_luc_tu"))
            c1dateVoucherDateFrom.Focus()
        End If
    End Sub

    Private Sub c1dateVoucherDateTo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateVoucherDateTo.Validated
        If c1dateVoucherDateTo.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_hieu_luc_den"))
            c1dateVoucherDateTo.Focus()
        End If
    End Sub

    Private Sub c1dateVoucherDateFrom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateVoucherDateFrom.ValueChanged, c1dateVoucherDateTo.ValueChanged
        LoadTDBCRecruitmentFileID()
    End Sub

#Region "Events tdbcStatisticTime"


    Private Sub tdbcStatisticTime_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStatisticTime.LostFocus
        If tdbcStatisticTime.FindStringExact(tdbcStatisticTime.Text) = -1 Then tdbcStatisticTime.Text = ""
    End Sub

    Private Sub tdbcStatisticTime_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcStatisticTime.SelectedValueChanged
        If tdbcStatisticTime.SelectedValue Is Nothing Or tdbcStatisticTime.Text = "" Then Exit Sub
        c1dateVoucherDateFrom.Value = ReturnValueC1Combo(tdbcStatisticTime, "FromDate")
        c1dateVoucherDateTo.Value = ReturnValueC1Combo(tdbcStatisticTime, "ToDate")
    End Sub

#End Region


#Region "Events tdbcDivisionID"

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then tdbcDivisionID.Text = ""
    End Sub

#End Region


  


 
End Class