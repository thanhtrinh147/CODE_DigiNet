Imports System
''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
Module D13X0002

    Public Const MaxSmallInt As Int16 = 32767
    
    ''' <summary>
    ''' Tạo caption cho menu Period và kiểm tra tình trạng khóa, mở sổ cho biến gbClosed
    ''' </summary>
    Public Function MakeMenuPeriod() As String
        Dim sRet As String
        sRet = rl3("_Ky_ke_toan") & ":" & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear & Space(3) & rl3("Don_vi") & ":" & Space(1) & gsDivisionID
        Dim sSQL As String = ""
        sSQL = "Select Closing From D09T9999  WITH (NOLOCK) Where TranMonth = " & SQLNumber(giTranMonth) & " And TranYear = " & SQLNumber(giTranYear) & " And DivisionID = " & SQLString(gsDivisionID)
        Dim sClosing As String = ReturnScalar(sSQL)
        gbClosed = Convert.ToBoolean(IIf(sClosing = "0", False, True))
        Return sRet
    End Function
    ''' <summary>
    ''' Ghi chữ Tổng cộng dưới ColumnFooters 
    ''' </summary>
    Public Function TongCong(ByVal iRow As Int32) As String

        Return IIf(geLanguage = EnumLanguage.Vietnamese, "Toång coäng", "Total").ToString & " (" & iRow & ")"
    End Function

    Public Sub TestInputAna(ByVal TDBG As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal TDBDD As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal colAna As Integer, ByVal i As Integer)
        With TDBG
            If gbArrAnaValidate(i) = True Then 'Nhap trong danh sach 
                If .Columns(colAna).Text <> TDBDD.Columns(0).Text Then
                    .Columns(colAna).Text = ""
                End If
            Else
                If .Columns(colAna).Text <> "" And .Columns(colAna).Text.Length > giArrAnaLength(i) Then
                    .Columns(colAna).Text = (.Columns(colAna).Text).Substring(0, giArrAnaLength(i))
                End If
            End If
        End With
    End Sub
    ''' <summary>
    ''' Copy tất cả các cột từ vị trí con trỏ đang đứng khi nhấn phím F9
    ''' </summary>
    Public Sub CopyColumnsF9(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal sValue As String)
        Try
            For i As Integer = RowCopy To c1Grid.RowCount - 1
                c1Grid(i, ColCopy) = sValue
            Next

        Catch ex As Exception
            MsgErr(ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Thông báo cột đã bị khóa khi nhấn phím nóng trên cột này để copy, xóa
    ''' </summary>
    Public Function MsgLockedColumn() As String
        Dim sMsg As String = ""
        sMsg = rl3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay")
        Return sMsg
    End Function

    ''' <summary>
    ''' Thông báo dữ liệu đang được sử dụng , không cho xóa
    ''' </summary>
    Public Function MsgNotDeleteData() As String
        Dim sMsg As String = ""
        sMsg = rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_xoa")
        Return sMsg
    End Function
    ''' <summary>
    ''' Thông báo dữ liệu đang được sử dụng , không cho mở lại hồ sơ lương
    ''' </summary>
    Public Function MsgNotReOpenSalaryFile() As String
        Dim sMsg As String = ""
        sMsg = rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_mo_lai")
        Return sMsg
    End Function

    ''' <summary>
    ''' Thông báo dữ liệu đang được sử dụng , không cho mở hồ sơ lương
    ''' </summary>
    Public Function MsgNotOpenSalaryFile() As String
        Dim sMsg As String = ""
        sMsg = rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_mo_")
        Return sMsg
    End Function
    ''' <summary>
    ''' Kiểm tra tồn tại khóa
    ''' </summary>
    Public Function IsExistPKey(ByVal TableName As String, ByVal Field1 As String, ByVal Field2 As String, ByVal Field3 As String, ByVal Field4 As String, ByVal Text As String) As Boolean
        Dim sSQL As String = ""
        sSQL = "Select Top 1 1 From " & TableName & " Where " & Field1 & " = " & SQLString(Text) & " And " & Field2 & " = " & SQLString(Text) & " And " & Field3 & " = " & SQLString(Text) & " And " & Field4 & " = " & SQLString(Text)
        Return ExistRecord(sSQL)
    End Function
    ''' <summary>
    ''' Kiểm tra tồn tại khóa
    ''' </summary>
    Public Function IsExistPKey1(ByVal TableName As String, ByVal Field1 As String, ByVal Field2 As String, ByVal Text As String) As Boolean
        Dim sSQL As String = ""
        sSQL = "Select Top 1 1 From " & TableName & " Where " & Field1 & " = " & SQLString(Text) & " And " & Field2 & " = " & SQLString(Text)
        Return ExistRecord(sSQL)
    End Function

    Public Function IsAllowEdit_D13F2022(ByVal ID As String) As Boolean
        Dim sSQL As String = "SELECT VoucherID FROM D13T2605  WITH (NOLOCK) " & vbCrLf
        sSQL &= " WHERE Module = 'D13' AND VoucherID = " & SQLString(ID)

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            D99C0008.MsgL3(rl3("Phieu_nay_da_duoc_tinh_luong_Ban_khong_duoc_sua_U"))
            Return False
        End If

        Return True
    End Function

    Public Function InserZero(ByVal NumZero As Byte) As String
        '#------------------------------------------------------
        '#CreateUser: Nguyen Thi Minh Hoa
        '#CreateDate: 04/04/2006
        '#ModifiedUser:  Nguyen Thi Minh Hoa
        '#ModifiedDate:  04/04/2006
        '#Description: Format so theo D91
        '#------------------------------------------------------
        If NumZero = 0 Then
            InserZero = ""
        Else
            InserZero = "."
            InserZero &= StrDup(NumZero, "0")
        End If
    End Function

    Public Function InsertFormat(ByVal sStrFormat As String) As String
        If IsNumeric(sStrFormat) Then
            Return ("#,##0" & InsertZero(Convert.ToInt16(sStrFormat)))
        Else
            Return ("#,##0" & InsertZero(0))
        End If
    End Function

    Private Function InsertZero(ByVal NumZero As Integer) As String
        Dim sRet As String = ""
        If NumZero = 0 Then
            sRet = ""
        Else
            sRet = "."
            For i As Integer = 0 To NumZero - 1
                sRet = sRet & "0"
            Next i
        End If
        Return sRet
    End Function

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

    ''' <summary>
    ''' Lấy chuỗi dữ liệu của những dòng được chọn
    ''' </summary>
    ''' <param name="iCol">Cột lấy dữ liệu</param>
    ''' <param name="Grid">lưới C1</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Function GetDataSelectRows(ByVal iCol As Integer, ByVal Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As String
        Dim sResult As String = ""
        Dim aSelectRows As C1.Win.C1TrueDBGrid.SelectedRowCollection = Grid.SelectedRows
        If aSelectRows.Count > 0 Then
            For i As Integer = 0 To aSelectRows.Count - 2
                sResult &= SQLString(Grid(aSelectRows.Item(i), iCol)) & ","
            Next
            sResult &= SQLString(Grid(aSelectRows.Item(aSelectRows.Count - 1), iCol))
        Else
            sResult = SQLString(Grid.Columns(iCol).Text)
        End If
        Return sResult
    End Function

    Public Function SafeCInt(ByVal obj As Object) As Integer
        If obj Is Nothing Or obj.ToString = "" Then
            Return 0
        Else
            Return CInt(obj)
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

    Public Sub LoadCaption_7ColOfficalTitle_Grid(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iSplit As Integer, ByVal dtOLSC As DataTable)
        With tdbg
            For i As Integer = 0 To dtOLSC.Rows.Count - 1
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC1"
                        .Columns("OfficalTitleID").Caption = dtOLSC.Rows(i).Item("Short").ToString

                    Case "OLSC10"
                        .Columns("SalaryLevelID").Caption = dtOLSC.Rows(i).Item("Short").ToString

                    Case "OLSC11"
                        .Columns("SaCoefficient").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC12"
                        .Columns("SaCoefficient12").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient12").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient12").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC13"
                        .Columns("SaCoefficient13").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient13").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient13").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC14"
                        .Columns("SaCoefficient14").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient14").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient14").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC15"
                        .Columns("SaCoefficient15").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient15").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient15").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC2"
                        .Columns("OfficalTitleID2").Caption = dtOLSC.Rows(i).Item("Short").ToString

                    Case "OLSC20"
                        .Columns("SalaryLevelID2").Caption = dtOLSC.Rows(i).Item("Short").ToString

                    Case "OLSC21"
                        .Columns("SaCoefficient2").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient2").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient2").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC22"
                        .Columns("SaCoefficient22").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient22").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient22").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC23"
                        .Columns("SaCoefficient23").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient23").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient23").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC24"
                        .Columns("SaCoefficient24").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient24").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient24").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC25"
                        .Columns("SaCoefficient25").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient25").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Columns("SaCoefficient25").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                End Select
            Next

        End With
    End Sub

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

    'Bỏ qua lỗi để execute cont - y/c BThảo
    Public Function My_ExecuteSQLNoTransaction(ByVal strSQL As String) As Boolean
        'If giAppMode = 0 Then
        Dim conn As New SqlConnection(gsConnectionString)
        Dim cmd As New SqlCommand(strSQL, conn)
        Try
            conn.Open()
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            conn.Close()
            Return True
        Catch
            conn.Close()
            'Clipboard.Clear()
            'Clipboard.SetText(strSQL)
            'MsgErr("Error when execute SQL in function ExecuteSQLNoTransaction(). Paste your SQL code from Clipboard")
            'WriteLogFile(strSQL)
            'Return False
        End Try
        Return True
    End Function

    Public Function RoundNumber(ByVal num As Double, ByVal num_digit As Int16) As Double
        Dim n As Double
        n = num * Math.Pow(10, num_digit)
        n = Math.Sign(n) * Math.Abs(Math.Floor(n + 0.5))
        Return n / Math.Pow(10, num_digit)
    End Function

    ' đã có tại D99X0007
    '    Public Function FormatRoundNumber(ByVal num As Double, ByVal num_digit As Int16) As String
    '        Return FormatNumber(RoundNumber(num, num_digit))
    '    End Function

    '    Public Sub ResetFilter(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
    '        'Set lại các giá trị FilterText
    '        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
    '        For Each dc In tdbg.Columns
    '            dc.FilterText = ""
    '        Next dc
    '    End Sub


    Public Const MaskFormatPeriod As String = "__/____"
    Public Const MaskFormatPeriodShort As String = "  /"

    Public Function L3PeriodValue(ByVal sPeriod As String) As String
        If sPeriod = MaskFormatDate Then Return MaskFormatPeriod
        If sPeriod.IndexOf("/") = -1 Then Return MaskFormatPeriod

        Dim oPeriod As Object = ConvertPeriod(sPeriod).ToString
        If IsDate(oPeriod) Then
            Return oPeriod.ToString
        Else
            Return MaskFormatPeriod
        End If
    End Function

    Private Function ConvertPeriod(ByVal sPeriod As String) As Object
        Try
            Dim arr() As String
            Dim nMonth As Integer
            Dim byPos As Double
            Dim sResult As String
            Dim sSeparator As String = "/"

            arr = Microsoft.VisualBasic.Split(sPeriod, sSeparator)
            nMonth = Convert.ToInt32(arr(0))

            'Tháng
            If nMonth < 1 Or nMonth > 12 Then
                Return MaskFormatDate
            Else
                sResult = nMonth.ToString("00")
            End If

            'Năm
            byPos = arr(1).IndexOf("_")
            Select Case byPos
                Case -1
                    If CInt(arr(1)) < 1900 Or CInt(arr(1)) > 2079 Then
                        Return MaskFormatDate
                    Else
                        sResult &= sSeparator & arr(1).ToString
                    End If
                Case 2
                    sResult &= sSeparator & (Year(Today.Date)).ToString.Substring(0, 2) & arr(1).Trim.Substring(0, 2)
                Case Else
                    sResult &= sSeparator & Year(Today.Date)
            End Select
            Return sResult

        Catch ex As Exception
            Return MaskFormatPeriod
        End Try
    End Function

    Public Function SQLPeriodSave(ByVal [Period] As String) As String
        If [Period] = "" Then Return "NULL"
        If [Period] = MaskFormatPeriodShort Then Return "NULL"
        If [Period] = MaskFormatPeriod Then Return "NULL"

        Dim sPeriod As String = ""
        sPeriod = [Period].Substring(3, 4) & [Period].Substring(0, 2)
        Return SQLString(sPeriod)

    End Function

    ''' <summary>
    ''' Đánh dấu Cột nào k hiển thị  = thuộc tính AllowSizing
    ''' </summary>
    ''' <param name="tdbg"></param>
    ''' <remarks></remarks> 
    Public Sub MarkInvisibleColumn(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, Optional ByVal iSplit As Integer = -1)
        If iSplit = -1 Then
            For i As Integer = 0 To tdbg.Splits.ColCount - 1
                For j As Integer = 0 To tdbg.Columns.Count - 1
                    tdbg.Splits(i).DisplayColumns(j).AllowSizing = tdbg.Splits(i).DisplayColumns(j).Visible
                Next j
            Next i
        Else
            For j As Integer = 0 To tdbg.Columns.Count - 1
                tdbg.Splits(iSplit).DisplayColumns(j).AllowSizing = tdbg.Splits(iSplit).DisplayColumns(j).Visible
            Next j
        End If
    End Sub

#Region "Màn hình chọn đường dẫn báo cáo"

    Public Function GetReportPath(ByVal ReportTypeID As String, ByVal ReportName As String, ByVal CustomReport As String, ByRef ReportPath As String, Optional ByRef ReportTitle As String = "", Optional ByVal ModuleID As String = "13") As String
        Dim bShowReportPath As Boolean
        Dim iReportLanguage As Byte
        'Lấy giá trị PARA_ModuleID từ module gọi đến
        'Nếu là exe chính (không có biến PARA_ModuleID) thì lấy Dxx 
        bShowReportPath = CType(D99C0007.GetModulesSetting("D" & ModuleID, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
        iReportLanguage = CType(D99C0007.GetModulesSetting("D" & ModuleID, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
        'Lấy đường dẫn báo cáo từ module D99X0004
        ReportPath = UnicodeGetReportPath(gbUnicode, iReportLanguage, "")
        If bShowReportPath Then 'Hiển thị màn hình chọn đường dẫn báo cáo
            Dim frm As New D99F6666
            With frm
                .ModuleID = ModuleID '2 ký tự, tùy theo từng module có thể lấy theo module gốc chứa exe con hoặc module gọi đến.
                .ReportTypeID = ReportTypeID
                .ReportName = ReportName
                .CustomReport = CustomReport
                .ReportPath = ReportPath
                .ReportTitle = ReportTitle
                .ShowDialog()
                ReportName = .ReportName
                ReportPath = .ReportPath
                gsReportPath = ReportPath 'biến toàn cục đang dùng 
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
        'D99C0007.SaveModulesSetting("D" & ModuleID, ModuleOption.lmOptions, "ShowReportPath", bShowReportPath)
        If "D" & ModuleID = D13 Then 'Module gốc
            'Nếu module nào có thêm code VB6 thì lưu thêm nhánh VB6
            'SaveSetting("Lemon3_D05", "Options", "NotShowDirectory", (Not bShowReportPath).ToString) 'Nhánh VB6
            D13Options.ShowReportPath = bShowReportPath 'Biến Tùy chọn
        End If
    End Sub

#End Region

    Public Sub RunEXEDxxExx40(ByVal sExeName As String, ByVal sFormActive As String, Optional ByVal sFormPermission As String = "", Optional ByVal sKey01ID As String = "")
        Dim exe As New DxxExx40(sExeName, gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        With exe
            .FormActive = sFormActive 'Form cần hiển thị
            .FormPermission = IIf(sFormPermission = "", sFormActive, sFormPermission).ToString 'Mã màn hình phân quyền
            If sKey01ID <> "" Then .IDxx("ID01") = sKey01ID
            .Run()
        End With
    End Sub

    Public Sub RunEXEDxxExx40(ByVal sExeName As String, ByVal sFormActive As String, ByVal formState As EnumFormState, Optional ByVal sFormPermission As String = "", Optional ByVal sKey01ID As String = "")
        Dim exe As New DxxExx40(sExeName, gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        With exe
            .FormActive = sFormActive 'Form cần hiển thị
            .FormPermission = IIf(sFormPermission = "", sFormActive, sFormPermission).ToString 'Mã màn hình phân quyền
            .FormState = formState
            If sKey01ID <> "" Then .IDxx("ID01") = sKey01ID
            .Run()
        End With
    End Sub



End Module
