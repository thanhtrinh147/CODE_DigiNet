''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D13X0002

    ''' <summary>
    ''' Định nghĩa các giá trị boolean của các mã phân tích dùng để cột mã phân tích tiền lương tương ứng hiển thị 
    ''' khi mã phân tích tiền lương đó hiện tại có sử dụng hay ẩn đi khi mã phân tích tiền lương đó hiện tại không sử dụng
    ''' </summary>
    Public Structure ANASALARY
        Public P01 As Boolean
        Public P02 As Boolean
        Public P03 As Boolean
        Public P04 As Boolean
        Public P05 As Boolean
        Public P06 As Boolean
        Public P07 As Boolean
        Public P08 As Boolean
        Public P09 As Boolean
        Public P10 As Boolean
        Public P11 As Boolean
        Public P12 As Boolean
        Public P13 As Boolean
        Public P14 As Boolean
        Public P15 As Boolean
        Public P16 As Boolean
        Public P17 As Boolean
        Public P18 As Boolean
        Public P19 As Boolean
        Public P20 As Boolean
    End Structure

    ''' <summary>
    ''' Định nghĩa các button dùng cho trường hợp nhấn button sẽ cho hiển thị các cột trên lưới tương ứng với button đó 
    ''' </summary>
    Public Enum Button
        SalaryCoefficientBase = 0     ' Lương cơ bản/Hệ số
        Income = 1                    ' Thu nhập
        AnalyseCode = 2               ' Mã phân tích
        SalaryLevelOfficialTitle = 3  ' Ngạch bậc lương
        Debit = 4                     ' Tài khoản nợ
        Credit = 5                    ' Tài khoản có
        Ana = 6                       ' Khoản mục
        AnalyseSalary = 7             ' Mã phân tích tiền lương
        SalaryPaymentMethod = 8       ' Phương pháp trả lương
        InfoCalculated = 9            ' Thông tin quyết toán
        InfoTaxIncome = 10            ' Thông tin khai thuế  
        InfoInsurance = 11            ' Thông tin bảo hiểm
    End Enum

    ''' <summary>
    ''' Thông báo dữ liệu đang được sử dụng , không cho xóa
    ''' </summary>
    Public Function MsgNotDeleteData() As String
        Dim sMsg As String = ""
        sMsg = rL3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_xoa")
        Return sMsg
    End Function

    '    ''' <summary>
    '    ''' Kiểm tra tồn tại khóa
    '    ''' </summary>
    '    Public Function IsExistPKey(ByVal TableName As String, ByVal Field1 As String, ByVal Field2 As String, ByVal Field3 As String, ByVal Field4 As String, ByVal Text As String) As Boolean
    '        Dim sSQL As String = ""
    '        sSQL = "Select Top 1 1 From " & TableName & " Where " & Field1 & " = " & SQLString(Text) & " And " & Field2 & " = " & SQLString(Text) & " And " & Field3 & " = " & SQLString(Text) & " And " & Field4 & " = " & SQLString(Text)
    '        Return ExistRecord(sSQL)
    '    End Function
    '    ''' <summary>
    '    ''' Kiểm tra tồn tại khóa
    '    ''' </summary>
    '    Public Function IsExistPKey1(ByVal TableName As String, ByVal Field1 As String, ByVal Field2 As String, ByVal Text As String) As Boolean
    '        Dim sSQL As String = ""
    '        sSQL = "Select Top 1 1 From " & TableName & " Where " & Field1 & " = " & SQLString(Text) & " And " & Field2 & " = " & SQLString(Text)
    '        Return ExistRecord(sSQL)
    '    End Function

    Public Function SafeCint(ByVal obj As Object) As Integer
        If obj.ToString = "" Then
            Return 0
        Else
            Return CInt(obj)
        End If
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

    Public Sub LoadCaption_7ColOfficalTitle_Grid(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iSplit As Integer, ByVal dtOLSC As DataTable, Optional ByVal bUseUnicode As Boolean = False)
        With tdbg
            For i As Integer = 0 To dtOLSC.Rows.Count - 1
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC1"
                        .Columns("OfficalTitleID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("OfficalTitleID").HeadingStyle.Font = FontUnicode(bUseUnicode)
                    Case "OLSC10"
                        .Columns("SalaryLevelID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SalaryLevelID").HeadingStyle.Font = FontUnicode(bUseUnicode)

                    Case "OLSC11"
                        .Columns("SaCoefficient").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Splits(iSplit).DisplayColumns("SaCoefficient").HeadingStyle.Font = FontUnicode(bUseUnicode)
                        .Columns("SaCoefficient").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC12"
                        .Columns("SaCoefficient12").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient12").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Splits(iSplit).DisplayColumns("SaCoefficient12").HeadingStyle.Font = FontUnicode(bUseUnicode)
                        .Columns("SaCoefficient12").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC13"
                        .Columns("SaCoefficient13").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient13").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Splits(iSplit).DisplayColumns("SaCoefficient13").HeadingStyle.Font = FontUnicode(bUseUnicode)
                        .Columns("SaCoefficient13").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC14"
                        .Columns("SaCoefficient14").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient14").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Splits(iSplit).DisplayColumns("SaCoefficient14").HeadingStyle.Font = FontUnicode(bUseUnicode)
                        .Columns("SaCoefficient14").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC15"
                        .Columns("SaCoefficient15").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient15").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Splits(iSplit).DisplayColumns("SaCoefficient15").HeadingStyle.Font = FontUnicode(bUseUnicode)
                        .Columns("SaCoefficient15").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC2"
                        .Columns("OfficalTitleID2").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("OfficalTitleID2").HeadingStyle.Font = FontUnicode(bUseUnicode)

                    Case "OLSC20"
                        .Columns("SalaryLevelID2").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SalaryLevelID2").HeadingStyle.Font = FontUnicode(bUseUnicode)

                    Case "OLSC21"
                        .Columns("SaCoefficient2").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient2").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Splits(iSplit).DisplayColumns("SaCoefficient2").HeadingStyle.Font = FontUnicode(bUseUnicode)
                        .Columns("SaCoefficient2").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC22"
                        .Columns("SaCoefficient22").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient22").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Splits(iSplit).DisplayColumns("SaCoefficient22").HeadingStyle.Font = FontUnicode(bUseUnicode)
                        .Columns("SaCoefficient22").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                    Case "OLSC23"
                        .Columns("SaCoefficient23").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient23").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Splits(iSplit).DisplayColumns("SaCoefficient23").HeadingStyle.Font = FontUnicode(bUseUnicode)
                        .Columns("SaCoefficient23").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC24"
                        .Columns("SaCoefficient24").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient24").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Splits(iSplit).DisplayColumns("SaCoefficient24").HeadingStyle.Font = FontUnicode(bUseUnicode)
                        .Columns("SaCoefficient24").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)


                    Case "OLSC25"
                        .Columns("SaCoefficient25").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        .Splits(iSplit).DisplayColumns("SaCoefficient25").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        .Splits(iSplit).DisplayColumns("SaCoefficient25").HeadingStyle.Font = FontUnicode(bUseUnicode)
                        .Columns("SaCoefficient25").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)

                End Select
            Next

        End With
    End Sub

    Public Sub LoadCaptiontdbdSalaryLevelID(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal dtOLSC As DataTable, ByVal sType As Integer, Optional ByVal bUseUnicode As Boolean = False)
        If sType = 1 Then
            For i As Integer = 0 To dtOLSC.Rows.Count - 1
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC10"
                        tdbd.Columns("SalaryLevelID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryLevelID").HeadingStyle.Font = FontUnicode(bUseUnicode)
                    Case "OLSC11"
                        tdbd.Columns("SalaryCoefficient").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                        tdbd.DisplayColumns("SalaryCoefficient").HeadingStyle.Font = FontUnicode(bUseUnicode)
                    Case "OLSC12"
                        tdbd.Columns("SalaryCoefficient02").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient02").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient02").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                        tdbd.DisplayColumns("SalaryCoefficient02").HeadingStyle.Font = FontUnicode(bUseUnicode)
                    Case "OLSC13"
                        tdbd.Columns("SalaryCoefficient03").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient03").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient03").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                        tdbd.DisplayColumns("SalaryCoefficient03").HeadingStyle.Font = FontUnicode(bUseUnicode)
                    Case "OLSC14"
                        tdbd.Columns("SalaryCoefficient04").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient04").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient04").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                        tdbd.DisplayColumns("SalaryCoefficient04").HeadingStyle.Font = FontUnicode(bUseUnicode)
                    Case "OLSC15"
                        tdbd.Columns("SalaryCoefficient05").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient05").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient05").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                        tdbd.DisplayColumns("SalaryCoefficient05").HeadingStyle.Font = FontUnicode(bUseUnicode)
                End Select
            Next
        Else
            For i As Integer = 0 To dtOLSC.Rows.Count - 1
                Select Case dtOLSC.Rows(i).Item("Code").ToString
                    Case "OLSC20"
                        tdbd.Columns("SalaryLevelID").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryLevelID").HeadingStyle.Font = FontUnicode(bUseUnicode)
                    Case "OLSC21"
                        tdbd.Columns("SalaryCoefficient").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                        tdbd.DisplayColumns("SalaryCoefficient").HeadingStyle.Font = FontUnicode(bUseUnicode)
                    Case "OLSC22"
                        tdbd.Columns("SalaryCoefficient02").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient02").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient02").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                        tdbd.DisplayColumns("SalaryCoefficient02").HeadingStyle.Font = FontUnicode(bUseUnicode)
                    Case "OLSC23"
                        tdbd.Columns("SalaryCoefficient03").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient03").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient03").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                        tdbd.DisplayColumns("SalaryCoefficient03").HeadingStyle.Font = FontUnicode(bUseUnicode)
                    Case "OLSC24"
                        tdbd.Columns("SalaryCoefficient04").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient04").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient04").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                        tdbd.DisplayColumns("SalaryCoefficient04").HeadingStyle.Font = FontUnicode(bUseUnicode)
                    Case "OLSC25"
                        tdbd.Columns("SalaryCoefficient05").Caption = dtOLSC.Rows(i).Item("Short").ToString
                        tdbd.DisplayColumns("SalaryCoefficient05").Visible = dtOLSC.Rows(i).Item("Disabled").ToString = "0"
                        tdbd.Columns("SalaryCoefficient05").NumberFormat = InsertFormat(dtOLSC.Rows(i).Item("Decimals").ToString)
                        tdbd.DisplayColumns("SalaryCoefficient05").HeadingStyle.Font = FontUnicode(bUseUnicode)
                End Select
            Next
        End If
    End Sub

    ''' <summary>
    ''' Thông báo cột đã bị khóa khi nhấn phím nóng trên cột này để copy, xóa
    ''' </summary>
    Public Function MsgLockedColumn() As String
        Dim sMsg As String = ""
        sMsg = rL3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay") 'rl3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay")
        Return sMsg
    End Function

    Public Function ComboValue(ByVal c1Combo As C1.Win.C1List.C1Combo) As String
        If c1Combo.Text = "" Then Return ""
        If c1Combo.SelectedValue IsNot Nothing Then
            Return c1Combo.SelectedValue.ToString
        Else
            Return ""
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
            If Grid(Grid.Row, iCol).ToString <> Grid(aSelectRows.Item(0), iCol).ToString Then
                sResult &= SQLString(Grid(Grid.Row, iCol).ToString) & ","
            End If
            For i As Integer = 0 To aSelectRows.Count - 2
                sResult &= SQLString(Grid(aSelectRows.Item(i), iCol)) & ","
            Next
            sResult &= SQLString(Grid(aSelectRows.Item(aSelectRows.Count - 1), iCol))
        Else
            sResult = SQLString(Grid.Columns(iCol).Text)
        End If
        Return sResult
    End Function
    Public Sub SetImageButton(ByVal btnSave As System.Windows.Forms.Button, ByVal btnNotSave As System.Windows.Forms.Button, ByVal btnNext As System.Windows.Forms.Button, ByVal imgButton As ImageList)
        btnSave.Size = New System.Drawing.Size(76, 27)
        btnNext.Size = New System.Drawing.Size(130, 27)
        btnNotSave.Size = New System.Drawing.Size(100, 27)

        btnSave.ImageList = imgButton
        btnSave.ImageIndex = 0
        btnSave.ImageAlign = ContentAlignment.MiddleLeft

        btnNext.ImageList = imgButton
        btnNext.ImageIndex = 1
        btnNext.ImageAlign = ContentAlignment.MiddleLeft

        btnNotSave.ImageList = imgButton
        btnNotSave.ImageIndex = 2
        btnNotSave.ImageAlign = ContentAlignment.MiddleLeft

        btnNotSave.Text = rL3("_Khong_luu")
        btnNext.Text = rL3("Luu_va_Nhap__tiep") 'Nhập &tiếp
        btnSave.Text = rL3("_Luu") '&Lưu
    End Sub

End Module
