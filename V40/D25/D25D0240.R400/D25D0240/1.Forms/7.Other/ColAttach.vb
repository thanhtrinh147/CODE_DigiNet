Module ColAttach

    Public Sub CallD91F4010(ByVal tableName As String, ByVal Key1ID As String, Optional ByVal Key2ID As String = "", Optional ByVal bNotView As Integer = 1)
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "TableName", tableName)
        SetProperties(arrPro, "Key1ID", Key1ID)
        SetProperties(arrPro, "Key2ID", Key2ID)
        SetProperties(arrPro, "Status", Convert.ToByte(bNotView))
        SetProperties(arrPro, "bNewDatabase", True)
        CallFormShowDialog("D91D0340", "D91F4010", arrPro)
    End Sub

    Public Sub CreateColAttach(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn
        dc.Caption = rL3("Dinh_kem")
        dc.DataField = "Button"
        If IsExist(tdbg, dc.DataField) Then Exit Sub
        tdbg.Columns.Add(dc)
        tdbg.Splits(tdbg.Splits.Count - 1).DisplayColumns(dc.DataField).ButtonText = True
        tdbg.Splits(tdbg.Splits.Count - 1).DisplayColumns(dc.DataField).ButtonAlways = True
        tdbg.Splits(tdbg.Splits.Count - 1).DisplayColumns(dc.DataField).Width = 40
        tdbg.Splits(tdbg.Splits.Count - 1).DisplayColumns(dc.DataField).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        tdbg.Splits(tdbg.Splits.Count - 1).DisplayColumns(dc.DataField).Visible = True
    End Sub

    Private Function IsExist(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sDataField As String) As Boolean
        Try
            If tdbg.Columns.IndexOf(tdbg.Columns(sDataField)) = -1 Then
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
End Module
