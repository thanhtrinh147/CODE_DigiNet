''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D13X0002

#Region "Màn hình chọn đường dẫn báo cáo"
    Public Function GetReportPath(ByVal ReportTypeID As String, ByVal ReportName As String, ByVal CustomReport As String, ByRef ReportPath As String, Optional ByRef ReportTitle As String = "", Optional ByVal ModuleID As String = "13") As String
        Return Lemon3.Reports.GetReportPath(ReportTypeID, ReportName, CustomReport, ReportPath, ReportTitle, ModuleID, D13Options.ShowReportPath)
        'Dim bShowReportPath As Boolean
        'Dim iReportLanguage As Byte
        ''Lấy giá trị PARA_ModuleID từ module gọi đến
        ''Nếu là exe chính (không có biến PARA_ModuleID) thì lấy Dxx 
        'bShowReportPath = CType(D99C0007.GetModulesSetting("D" & ModuleID, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
        'iReportLanguage = CType(D99C0007.GetModulesSetting("D" & ModuleID, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
        ''Lấy đường dẫn báo cáo từ module D99X0004
        'ReportPath = UnicodeGetReportPath(gbUnicode, iReportLanguage, "")
        'If bShowReportPath Then 'Hiển thị màn hình chọn đường dẫn báo cáo
        '    Dim frm As New D99F6666
        '    With frm
        '        .ModuleID = ModuleID '2 ký tự, tùy theo từng module có thể lấy theo module gốc chứa exe con hoặc module gọi đến.
        '        .ReportTypeID = ReportTypeID
        '        .ReportName = ReportName
        '        .CustomReport = CustomReport
        '        .ReportPath = ReportPath
        '        .ReportTitle = ReportTitle
        '        .ShowDialog()
        '        ReportName = .ReportName
        '        ReportPath = .ReportPath
        '        ' gsReportPath = ReportPath 'biến toàn cục đang dùng 
        '        ReportTitle = .ReportTitle
        '        SaveOptionReport(.ShowReportPath, ModuleID)
        '        .Dispose()
        '    End With
        'Else 'Không hiển thị thì lấy theo Loại nghiệp vụ (nếu có)
        '    If CustomReport <> "" Then
        '        ReportPath = gsApplicationSetup & "\XCustom\"
        '        ReportName = CustomReport
        '    End If
        'End If
        'ReportPath = ReportPath & ReportName & ".rpt"
        'Return ReportName
    End Function
#End Region
    Public Function ComboValue(ByVal c1Combo As C1.Win.C1List.C1Combo) As String
        If c1Combo.Text = "" Then Return ""
        If c1Combo.SelectedValue IsNot Nothing Then
            Return c1Combo.SelectedValue.ToString
        Else
            Return ""
        End If
    End Function

    Public Sub LoadCaption_7ColOfficalTitle_Grid(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iSplit As Integer, ByVal dtOLSC As DataTable)
        With tdbg
            For i As Integer = 0 To dtOLSC.Rows.Count - 1
                Dim sCaption As String = dtOLSC.Rows(i).Item("Short" & UnicodeJoin(gbUnicode)).ToString
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC1"
                        .Columns("OfficalTitleID").Caption = sCaption

                    Case "OLSC10"
                        .Columns("SalaryLevelID").Caption = sCaption

                    Case "OLSC11"
                        .Columns("SaCoefficient").Caption = sCaption
                        .Splits(iSplit).DisplayColumns("SaCoefficient").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC12"
                        .Columns("SaCoefficient12").Caption = sCaption
                        .Splits(iSplit).DisplayColumns("SaCoefficient12").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient12").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC13"
                        .Columns("SaCoefficient13").Caption = sCaption
                        .Splits(iSplit).DisplayColumns("SaCoefficient13").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient13").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC14"
                        .Columns("SaCoefficient14").Caption = sCaption
                        .Splits(iSplit).DisplayColumns("SaCoefficient14").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient14").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC15"
                        .Columns("SaCoefficient15").Caption = sCaption
                        .Splits(iSplit).DisplayColumns("SaCoefficient15").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient15").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC2"
                        .Columns("OfficalTitleID2").Caption = sCaption

                    Case "OLSC20"
                        .Columns("SalaryLevelID2").Caption = sCaption

                    Case "OLSC21"
                        .Columns("SaCoefficient2").Caption = sCaption
                        .Splits(iSplit).DisplayColumns("SaCoefficient2").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient2").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC22"
                        .Columns("SaCoefficient22").Caption = sCaption
                        .Splits(iSplit).DisplayColumns("SaCoefficient22").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient22").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC23"
                        .Columns("SaCoefficient23").Caption = sCaption
                        .Splits(iSplit).DisplayColumns("SaCoefficient23").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient23").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC24"
                        .Columns("SaCoefficient24").Caption = sCaption
                        .Splits(iSplit).DisplayColumns("SaCoefficient24").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient24").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC25"
                        .Columns("SaCoefficient25").Caption = sCaption
                        .Splits(iSplit).DisplayColumns("SaCoefficient25").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient25").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                End Select
            Next

        End With
    End Sub

End Module
