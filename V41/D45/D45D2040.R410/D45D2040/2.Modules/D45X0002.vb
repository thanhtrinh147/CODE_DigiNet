''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D45X0002
    Public Sub SetImageButton(ByVal btnSave As Button, ByVal btnNotSave As Button, ByVal imgButton As ImageList)
        btnSave.Size = New System.Drawing.Size(76, 27)
        btnNotSave.Size = New System.Drawing.Size(100, 27)

        btnSave.ImageList = imgButton
        btnSave.ImageIndex = 0
        btnSave.ImageAlign = ContentAlignment.MiddleLeft

        btnNotSave.ImageList = imgButton
        btnNotSave.ImageIndex = 1
        btnNotSave.ImageAlign = ContentAlignment.MiddleLeft

        btnSave.Text = rL3("_Luu") '&Lưu
        btnNotSave.Text = rL3("_Khong_luu")
    End Sub

#Region "KeyboardCues"

    Private Declare Function SystemParametersInfoSet Lib "user32.dll" Alias "SystemParametersInfoW" (ByVal action As Integer, ByVal param As Integer, ByVal value As Integer, ByVal winini As Boolean) As Boolean
    Private Const SPI_SETKEYBOARDCUES As Integer = &H100B

    Public Sub KeyboardCues()
        SystemParametersInfoSet(SPI_SETKEYBOARDCUES, 0, 1, False)
    End Sub
#End Region

#Region "Màn hình chọn đường dẫn báo cáo"

    Public Function GetReportPath(ByVal ReportTypeID As String, ByVal ReportName As String, ByVal CustomReport As String, ByRef ReportPath As String, Optional ByRef ReportTitle As String = "", Optional ByVal ModuleID As String = "45") As String
        Dim bShowReportPath As Boolean
        Dim iReportLanguage As Byte
        bShowReportPath = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
        iReportLanguage = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
        'Lấy đường dẫn báo cáo từ module D99X0004
        ReportPath = UnicodeGetReportPath(gbUnicode, iReportLanguage, "")
        'Hiển thị màn hình chọn đường dẫn báo cáo
        If bShowReportPath Then

            Dim frm As New D99F6666
            With frm
                .ModuleID = ModuleID '2 ký tự
                .ReportTypeID = ReportTypeID
                .ReportName = ReportName
                .CustomReport = CustomReport
                .ReportPath = ReportPath
                .ReportTitle = ReportTitle
                .ShowDialog()
                ReportName = .ReportName
                ReportPath = .ReportPath
                ReportTitle = .ReportTitle
                SaveOptionReport(.ShowReportPath)
                .Dispose()
            End With
        Else 'Không hiển thị thì lấy theo Loại nghiệp vụ (nếu có)
            If CustomReport <> "" Then
                ReportPath = gsApplicationSetup & "\XCustom\"
                ReportName = CustomReport
            End If
        End If
        ReportPath = ReportPath & ReportName & ".rpt"
        Return ReportName
    End Function

    'Tùy thuộc từng module có biến lưu dưới Registry
    Public Sub SaveOptionReport(ByVal bShowReportPath As Boolean)
        'D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", bShowReportPath)
        D45Options.ShowReportPath = bShowReportPath 'Biến Tùy chọn
    End Sub

#End Region

    'Hàm Paste (dữ liệu đã copty từ ngoài Excel (Word) hay từ khối trên lưới) vào lưới khi đứng tại 1 cột
    Public Function PasteRows(ByVal dtGrid As DataTable, ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean
        Try

            Dim c1Rows As C1.Win.C1TrueDBGrid.SelectedRowCollection = c1Grid.SelectedRows
            If c1Rows.Count > 0 Then 'If Selected rows then exit
                e.SuppressKeyPress = True
                Return False
            End If

            Dim rowSplitter As Char() = {ControlChars.Cr, ControlChars.Lf}
            Dim columnSplitter As Char() = {ControlChars.Tab}

            'Gets the text from clipboard and sets it in each cell accordingly
            Dim dataInClipboard As IDataObject = Clipboard.GetDataObject()
            Dim stringInClipboard As String = ""

            If gbUnicode Then
                stringInClipboard = DirectCast(dataInClipboard.GetData(DataFormats.UnicodeText), String)
            Else
                stringInClipboard = DirectCast(dataInClipboard.GetData(DataFormats.Text), String)
            End If

            Dim rowsInClipboard As String() = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries)
            Dim drow As DataRow

            Dim iCountRow As Integer = (rowsInClipboard.Length - 1) - (c1Grid.RowCount - 1 - c1Grid.Row)
            Dim iOldRow As Integer = c1Grid.Row

            If c1Grid.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then 'the newly added row
                For iRow As Integer = 0 To rowsInClipboard.Length - 1
                    Dim valuesInRow As String() = rowsInClipboard(iRow).Split(columnSplitter)
                    drow = dtGrid.NewRow

                    For iCol As Integer = 0 To valuesInRow.Length - 1
                        If valuesInRow(iCol).Trim <> "" Then drow(c1Grid.Columns(c1Grid.Col + iCol).DataField) = valuesInRow(iCol).Trim
                    Next

                    dtGrid.Rows.Add(drow)
                Next
            Else
                For iRow As Integer = 0 To rowsInClipboard.Length - 1
                    Dim valuesInRow As String() = rowsInClipboard(iRow).Split(columnSplitter)
                    If iRow + iOldRow > c1Grid.RowCount - 1 Then 'dòng mới
                        drow = dtGrid.NewRow

                        For iCol As Integer = 0 To valuesInRow.Length - 1
                            If valuesInRow(iCol).Trim <> "" Then drow(c1Grid.Columns(c1Grid.Col + iCol).DataField) = valuesInRow(iCol).Trim
                        Next

                        dtGrid.Rows.Add(drow)
                    Else 'dòng cũ
                        For iCol As Integer = 0 To valuesInRow.Length - 1
                            If valuesInRow(iCol).Trim <> "" Then c1Grid(iRow + iOldRow, c1Grid.Col + iCol) = valuesInRow(iCol).Trim
                        Next
                    End If
                Next
            End If

            e.SuppressKeyPress = True
            c1Grid.UpdateData()
        Catch ex As Exception
        End Try

        Return True
    End Function
    Public Sub ClearTag(ByVal ctrl As Control)
        If TypeOf (ctrl) Is C1.Win.C1Input.C1DateEdit Then
            CType(ctrl, C1.Win.C1Input.C1DateEdit).Tag = ""
        ElseIf TypeOf (ctrl) Is C1.Win.C1Input.C1NumericEdit Then
            CType(ctrl, C1.Win.C1Input.C1NumericEdit).Tag = ""
        ElseIf (TypeOf (ctrl) Is TextBox Or TypeOf (ctrl) Is C1.Win.C1List.C1Combo) Then
            'Update 15/08/2013: Filter Bar trên lưới có TypeOf là TextBox nên chạy vào điều kiện này
            'ctrl.Text = ""
            If ctrl.Name <> "" Then ctrl.Tag = ""
        End If

        For Each childControl As Control In ctrl.Controls
            ClearTag(childControl)
        Next
    End Sub
End Module
