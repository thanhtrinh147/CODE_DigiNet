''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D13X0002

    ''' <summary>
    ''' Thông báo dữ liệu đang được sử dụng , không cho mở lại hồ sơ lương
    ''' </summary>
    Public Function MsgNotReOpenSalaryFile() As String
        Dim sMsg As String = ""
        sMsg = rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_mo_lai")
        Return sMsg
    End Function

    ''' <summary>
    ''' Thông báo cột đã bị khóa khi nhấn phím nóng trên cột này để copy, xóa
    ''' </summary>
    Public Function MsgLockedColumn() As String
        Dim sMsg As String = ""
        sMsg = rl3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay")
        Return sMsg
    End Function


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
        '        '  gsReportPath = ReportPath 'biến toàn cục đang dùng 
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

    'Tùy thuộc từng module có biến lưu dưới Registry
    Public Sub SaveOptionReport(ByVal bShowReportPath As Boolean, Optional ByVal ModuleID As String = "13")
        'D99C0007.SaveModulesSetting("D" & PARA_ModuleID, ModuleOption.lmOptions, "ShowReportPath", bShowReportPath)
        If "D" & ModuleID = D13 Then 'Module gốc
            'Nếu module nào có thêm code VB6 thì lưu thêm nhánh VB6
            'SaveSetting("Lemon3_D05", "Options", "NotShowDirectory", (Not bShowReportPath).ToString) 'Nhánh VB6
            D13Options.ShowReportPath = bShowReportPath 'Biến Tùy chọn
        End If
    End Sub
#End Region

   

    Public Function Round(ByVal Number As Double, ByVal NumZero As Integer) As Double
        Dim dNumber As Double = CType(Number, Double)
        If NumZero >= 0 Then
            Return Math.Round(dNumber, NumZero)
        End If
        NumZero = -NumZero
        Dim d As Double = Math.Pow(10, NumZero)
        dNumber = Math.Round(dNumber) / d
        Return (Math.Round(dNumber) * d)
    End Function

    Public Function Round(ByVal Number As Object, ByVal NumZero As Object) As Double
        Dim dNumber As Double = CType(Number, Double)
        Dim iNumZero As Integer = CType(NumZero, Integer)
        If iNumZero >= 0 Then
            Return Math.Round(dNumber, iNumZero)
        End If
        iNumZero = -iNumZero
        Dim d As Double = Math.Pow(10, iNumZero)
        dNumber = Math.Round(dNumber) / d
        Return (Math.Round(dNumber) * d)
    End Function

    Public Function SQLNumberD13(ByVal Number As String, ByVal NumZero As String) As String
        If Number = "" Then Return "0"
        If NumZero = "" Then NumZero = "0"
        Dim dNumber As Double = CType(Number, Double)
        Dim iNumZero As Integer = CType(NumZero, Integer)
        If iNumZero >= 0 Then
            Return Format(dNumber, InsertFormat(NumZero))
        Else
            dNumber = Round(dNumber, iNumZero)
            Return Format(dNumber, InsertFormat("0"))
        End If

    End Function

    Public Function SQLNumberD13(ByVal Number As Object, ByVal NumZero As Object) As String
        If Number Is Nothing Then Return "0"
        If IsDBNull(Number) Then Return "0"
        If NumZero Is Nothing Then NumZero = "0"
        If IsDBNull(NumZero) Then NumZero = "0"
        Dim dNumber As Double = CType(Number, Double)
        Dim iNumZero As Integer = CType(NumZero, Integer)
        If iNumZero >= 0 Then
            Return Format(dNumber, InsertFormat(NumZero.ToString))
        Else
            dNumber = Round(dNumber, iNumZero)
            Return Format(dNumber, InsertFormat("0"))
        End If

    End Function

    Public Function ComboValue(ByVal c1Combo As C1.Win.C1List.C1Combo) As String
        If c1Combo.Text = "" Then Return ""
        If c1Combo.SelectedValue IsNot Nothing Then
            Return c1Combo.SelectedValue.ToString
        Else
            Return ""
        End If
    End Function

    Public Const MaskFormatPeriod As String = "__/____"
    Public Const MaskFormatPeriodShort As String = "  /"

    '    Public Function L3PeriodValue(ByVal sPeriod As String) As String
    '        If sPeriod = MaskFormatDate Then Return MaskFormatPeriod
    '        If sPeriod.IndexOf("/") = -1 Then Return MaskFormatPeriod
    '
    '        Dim oPeriod As Object = ConvertPeriod(sPeriod).ToString
    '        If IsDate(oPeriod) Then
    '            Return oPeriod.ToString
    '        Else
    '            Return MaskFormatPeriod
    '        End If
    '    End Function
    '
    '    Private Function ConvertPeriod(ByVal sPeriod As String) As Object
    '        Try
    '            Dim arr() As String
    '            Dim nMonth As Integer
    '            Dim byPos As Double
    '            Dim sResult As String
    '            Dim sSeparator As String = "/"
    '
    '            arr = Microsoft.VisualBasic.Split(sPeriod, sSeparator)
    '            nMonth = Convert.ToInt32(arr(0))
    '
    '            'Tháng
    '            If nMonth < 1 Or nMonth > 12 Then
    '                Return MaskFormatDate
    '            Else
    '                sResult = nMonth.ToString("00")
    '            End If
    '
    '            'Năm
    '            byPos = arr(1).IndexOf("_")
    '            Select Case byPos
    '                Case -1
    '                    If CInt(arr(1)) < 1900 Or CInt(arr(1)) > 2079 Then
    '                        Return MaskFormatDate
    '                    Else
    '                        sResult &= sSeparator & arr(1).ToString
    '                    End If
    '                Case 2
    '                    sResult &= sSeparator & (Year(Today.Date)).ToString.Substring(0, 2) & arr(1).Trim.Substring(0, 2)
    '                Case Else
    '                    sResult &= sSeparator & Year(Today.Date)
    '            End Select
    '            Return sResult
    '
    '        Catch ex As Exception
    '            Return MaskFormatPeriod
    '        End Try
    '    End Function
    '
    '    Public Function SQLPeriodSave(ByVal [Period] As String) As String
    '        If [Period] = "" Then Return "NULL"
    '        If [Period] = MaskFormatPeriodShort Then Return "NULL"
    '        If [Period] = MaskFormatPeriod Then Return "NULL"
    '
    '        Dim sPeriod As String = ""
    '        sPeriod = [Period].Substring(3, 4) & [Period].Substring(0, 2)
    '
    '        Return SQLString(sPeriod)
    '    End Function

    Public Sub LoadTdbcTransTypeID(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sID As String, Optional ByVal sEditTransTypeID As String = "")
        Dim sSQL As String = ""
        sSQL = "SELECT  Distinct TransTypeID,TransTypeName" & UnicodeJoin(gbUnicode) & " as TransTypeName, VoucherTypeID" & vbCrLf
        sSQL &= "FROM   D13T1130 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE  TransactionID = " & SQLString(sID) & vbCrLf
        sSQL &= "   AND Disabled = 0" & vbCrLf
        sSQL &= "   AND (DAGroupID = ''" & vbCrLf
        sSQL &= "           OR  DAGroupID In (  Select  DAGroupID " & vbCrLf
        sSQL &= "                      		    From    LemonSys.dbo.D00V0080" & vbCrLf
        sSQL &= "                       		Where   UserID = " & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "           OR 'LEMONADMIN' = " & SQLString(gsUserID) & ")" & vbCrLf

        If sEditTransTypeID <> "" Then
            sSQL &= " Or TransTypeID = " & SQLString(sEditTransTypeID) & vbCrLf
        End If

        sSQL &= "ORDER BY TransTypeID"
        LoadDataSource(tdbc, sSQL, gbUnicode)
    End Sub

    '    ''' <summary>
    '    ''' Đánh dấu Cột nào k hiển thị  = thuộc tính AllowSizing
    '    ''' </summary>
    '    ''' <param name="tdbg"></param>
    '    ''' <remarks></remarks> 
    '    Public Sub MarkInvisibleColumn(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, Optional ByVal iSplit As Integer = -1)
    '        If iSplit = -1 Then
    '            For i As Integer = 0 To tdbg.Splits.ColCount - 1
    '                For j As Integer = 0 To tdbg.Columns.Count - 1
    '                    tdbg.Splits(i).DisplayColumns(j).AllowSizing = tdbg.Splits(i).DisplayColumns(j).Visible
    '                Next j
    '            Next i
    '        Else
    '            For j As Integer = 0 To tdbg.Columns.Count - 1
    '                tdbg.Splits(iSplit).DisplayColumns(j).AllowSizing = tdbg.Splits(iSplit).DisplayColumns(j).Visible
    '            Next j
    '        End If
    '    End Sub
    '
    '    'Bỏ qua lỗi để execute cont - y/c BThảo
    '    Public Function My_ExecuteSQLNoTransaction(ByVal strSQL As String) As Boolean
    '        Dim conn As New SqlConnection(gsConnectionString)
    '        Dim cmd As New SqlCommand(strSQL, conn)
    '        Try
    '            conn.Open()
    '            cmd.CommandTimeout = 0
    '            cmd.ExecuteNonQuery()
    '            conn.Close()
    '            Return True
    '        Catch
    '            conn.Close()
    '            Return False
    '        End Try
    '        Return True
    '    End Function

#Region "Thực hiện AuditLog"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6200
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/09/2011 03:22:34
    '# Modified User:
    '# Modified Date:
    '# Description: 0(Gia tri cũ)/1(Gia tri mới)
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD09P6200(ByVal TableName As String, ByVal ColVoucherID As String, ByVal VoucherID As String, ByVal iMode As Integer, ByVal ColTransID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P6200 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(TableName) & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLString(ColVoucherID) & COMMA 'ColVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(VoucherID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(ColTransID) & COMMA 'ColTransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'ColType, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6210
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 20/10/2011 08:08:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD09P6210(ByVal sAuditCode As String, ByVal sAuditItemID As String, ByVal sEventID As String _
                    , Optional ByVal sDesc01 As String = "", Optional ByVal sDesc02 As String = "", Optional ByVal sDesc03 As String = "" _
                    , Optional ByVal sDesc04 As String = "", Optional ByVal sDesc05 As String = "") As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P6210 "
        sSQL &= SQLDateSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("13") & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL'"03"
        sSQL &= SQLString(sAuditItemID) & COMMA 'AuditItemID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= "N" & SQLString(sDesc01) & COMMA 'Desc01, nvarchar, NOT NULL
        sSQL &= "N" & SQLString(sDesc02) & COMMA 'Desc02, nvarchar, NOT NULL
        sSQL &= "N" & SQLString(sDesc03) & COMMA 'Desc03, nvarchar, NOT NULL
        sSQL &= "N" & SQLString(sDesc04) & COMMA 'Desc04, nvarchar, NOT NULL
        sSQL &= "N" & SQLString(sDesc05) 'Desc05, nvarchar, NOT NULL
        Return sSQL
    End Function

#End Region

    Public Function CheckPerF5700(ByVal bStatus As Integer, ByVal lblPerF5700 As System.Windows.Forms.Label, ByVal iPerF5700 As Integer, Optional ByVal sCreateUserID As String = "") As Boolean
        Select Case bStatus
            'TH0: Gọi tại Form_load --> CheckPerF5700(0)
            Case 0
                If lblPerF5700 IsNot Nothing Then
                    If iPerF5700 <= 0 Then
                        lblPerF5700.Text = rL3("MSG000005")
                        Return False
                    Else
                        lblPerF5700.Text = ""
                    End If
                End If
                'TH1: Gọi tại menu Sửa, Sửa khác, Sửa số phiếu --> If Not CheckPerF5700(1) Then Exit Sub
            Case 1
                If iPerF5700 = 1 Or iPerF5700 = 2 Then
                    If sCreateUserID <> gsUserID Then
                        D99C0008.MsgL3(rL3("MSG000006"))
                        Return False
                    End If
                End If

                'TH2: Gọi tại menu Xóa --> If Not CheckPerF5700(2) Then Exit Sub
            Case 2 'Xóa
                If iPerF5700 = 1 Or iPerF5700 = 2 Or iPerF5700 = 3 Then
                    If sCreateUserID <> gsUserID Then
                        D99C0008.MsgL3(rL3("MSG000007"))
                        Return False
                    End If
                End If
        End Select
        Return True
    End Function
End Module
