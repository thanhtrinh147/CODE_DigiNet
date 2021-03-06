'#------------------------------------------------------
'# Title: D09X2222
'# Created User: Đỗ Minh Dũng
'# Created Date: 28/07/2009 01:56:52
'# ModifiedUser: Nguyễn Thị Minh Hòa
'# ModifiedDate: 06/10/2009 01:56:52
'# Description: Các hàm dùng chung cho nhóm G4
'#------------------------------------------------------

Module D09X2222
    'BIỄN GHI NHẬN MAX LENGTH CỦA CAPTION CỘT
    Public giMaxLengthColumnCaption As Integer = 0


#Region "Create table load Grid for .NET"
    ''' <summary>
    ''' Tạo Table Caption cho Grid Export Excel
    ''' </summary>
    ''' <param name="C1Grid">Lưới của form truyền vào</param>
    ''' <param name="ArrColumns">mảng các cột ẩn hiện của lưới có Nút</param>
    ''' <param name="iSplit"> Split chứa cột ẩn hiện của nút trên lưới</param>
    ''' <remarks></remarks>
    Public Function CreateTableForExcel(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, Optional ByVal ArrColumns() As Integer = Nothing, Optional ByVal iSplit As Integer = 0) As DataTable
        giMaxLengthColumnCaption = 0
        Dim bTag As Boolean = False
        If ArrColumns IsNot Nothing Then
            CreateTagToGrid(C1Grid, ArrColumns)
            bTag = True
        End If

        Dim dt As New DataTable
        dt.Columns.Add("FieldName", GetType(System.String))
        dt.Columns.Add("Description", GetType(System.String))
        dt.Columns.Add("OrderNum", GetType(System.Int32))
        dt.Columns.Add("OrderNo", GetType(System.Int32))
        dt.Columns.Add("DataType", GetType(System.String))
        dt.Columns.Add("IsUsed", GetType(System.Boolean))
        dt.Columns.Add("IsUnicode", GetType(System.Boolean))
        dt.Columns.Add("NumberFormat", GetType(System.Byte))
        dt.Columns.Add("Split", GetType(System.Int32))

        Dim dr As DataRow
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim bVisible As Boolean = False
        Dim iCount As Integer = 0
        For Each dc In C1Grid.Columns
            For i As Integer = 0 To C1Grid.Splits.Count - 1
                If C1Grid.Splits(i).SplitSize > 0 Then
                    If bTag Then
                        bVisible = C1Grid.Splits(i).DisplayColumns(dc).Visible OrElse (CBool(dc.Tag) And iSplit = i)
                    Else
                        bVisible = C1Grid.Splits(i).DisplayColumns(dc).Visible
                    End If

                    If bVisible Then
                        iCount += 1
                        dr = dt.NewRow
                        dr(0) = dc.DataField
                        If C1Grid.Splits(i).DisplayColumns(dc).HeadingStyle.Font.Name = "Microsoft Sans Serif" Then
                            dr(1) = ConvertUnicodeToVni(dc.Caption.Trim)
                        Else
                            dr(1) = dc.Caption.Trim
                        End If

                        'Lay do dai max
                        If dr(1).ToString.Length > giMaxLengthColumnCaption Then giMaxLengthColumnCaption = dr(1).ToString.Length

                        dr(2) = iCount
                        dr(3) = 0

                        If dc.DataType.Name.Contains("Decimal") OrElse dc.DataType.Name.Contains("Boolean") OrElse dc.DataType.Name.Contains("Int32") Then 'Kiểu số, có thể bổ sung thêm(...)
                            dr(4) = "N"
                        ElseIf dc.DataType.Name = "DateTime" Then 'Kiểu ngày
                            dr(4) = "D"
                        Else 'Kiểu chuỗi
                            dr(4) = "S"
                        End If
                        dr(5) = 1
                        dr(6) = 0
                        If dc.DataType.Name.Contains("Decimal") Then 'Kiểu số->lấy Format
                            Dim sFormat As String = dc.NumberFormat
                            If sFormat.Contains(".") Then
                                Dim arr() As String = sFormat.Split(CType(".", Char))
                                dr(7) = arr(arr.Length - 1).Length
                            Else
                                dr(7) = 0
                            End If
                        Else
                            dr(7) = 0
                        End If
                        dt.Rows.Add(dr)
                        Exit For
                    End If
                End If
            Next
        Next dc

        Return dt

    End Function

    ''' <summary>
    ''' Gán Tag = True cho các Column có Visible = False
    ''' </summary>
    ''' <param name="C1Grid">Lưới C1</param>
    ''' <param name="arrCol">Mảng chứa các Column cần gán Tag</param>
    ''' <remarks></remarks>
    Private Sub CreateTagToGrid(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, Optional ByVal arrCol() As Integer = Nothing)
        For i As Integer = 0 To arrCol.Length - 1
            For j As Integer = 0 To C1Grid.Columns.Count - 1
                If j = arrCol(i) Then
                    C1Grid.Columns(j).Tag = True
                End If
            Next
        Next
    End Sub
#End Region

    Public Sub VisibleEachColOnSplit(ByVal tdbgO As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sFieldName As String, ByVal bChoose As Boolean)

        'Duyệt trên lưới tìm Column
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn = Nothing
        For i As Integer = 0 To tdbgO.Columns.Count - 1
            If tdbgO.Columns(i).DataField = sFieldName Then
                dc = tdbgO.Columns(i)
                Exit For
            End If
        Next i

        'Duyệt trên split tìm DisplayColumn
        If dc IsNot Nothing Then
            For i As Integer = 0 To tdbgO.Splits.Count - 1
                With tdbgO.Splits(i).DisplayColumns(dc)
                    If .AllowSizing Then
                        .Visible = bChoose
                        Select Case sFieldName
                            Case "DivisionID", "DivisionName", "DepartmentID", "DepartmentName", "TeamID", "TeamName"
                                If .Visible Then
                                    .Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Restricted
                                Else
                                    .Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.None
                                End If
                        End Select
                        Exit For 'Một cột chỉ được hiển thị tại 1 split, nên tìm được cột này thì k cần xét tiếp
                    Else
                        .Visible = False
                    End If
                End With
            Next i
        End If


    End Sub

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


    Public Function IsChoosedOnGrid(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iSplitIndex As Integer, ByVal iCol As Integer) As Boolean
        Dim k As Integer
        Dim b As Boolean = False
        For k = 0 To tdbg.RowCount - 1
            If CBool(tdbg(k, iCol)) Then
                b = True
                Exit For
            End If
        Next k

        'If k >= tdbg.RowCount - 1 Then
        If b = False Then
            D99C0008.MsgL3(r("Ban_phai_chon_du_lieu_tren_luoi"))
            tdbg.Col = iCol
            tdbg.Row = 0
            tdbg.SplitIndex = iSplitIndex
            If tdbg.Splits(iSplitIndex).MarqueeStyle <> C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor Then tdbg.Focus()
            Return False
        End If

        Return True
    End Function
End Module
