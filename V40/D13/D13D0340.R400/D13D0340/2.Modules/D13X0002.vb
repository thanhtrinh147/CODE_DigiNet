''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D13X0002

    Public Function ComboValue(ByVal c1Combo As C1.Win.C1List.C1Combo) As String
        If c1Combo.Text = "" Then Return ""
        If c1Combo.SelectedValue IsNot Nothing Then
            Return c1Combo.SelectedValue.ToString
        Else
            Return ""
        End If
    End Function

    Public Function HotKeyF2D91F6020(ByVal sSQLSelection As String, ByRef tdbcFrom As C1.Win.C1List.C1Combo, Optional ByRef tdbcTo As C1.Win.C1List.C1Combo = Nothing, Optional ByVal iModeSelect As Integer = 0, Optional ByVal formPer As String = "", Optional ByRef bPressF2 As Boolean = False) As String
        Dim sKeyID As String = ""
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "ModeSelect", L3Byte(iModeSelect))
        SetProperties(arrPro, "SQLSelection", sSQLSelection)
        SetProperties(arrPro, "FormIDPermission", formPer)
        Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6020", arrPro)
        sKeyID = GetProperties(frm, "ReturnField").ToString

        If sKeyID <> "" Then
            If sKeyID.Substring(0, 1) <> "(" And sKeyID <> "True" Then 'Lấy theo giá trị Từ đến: gán lại giá trị cho 2 combo tiêu thức từ đến, chuỗi tiêu thức gán bằng rỗng, sSQLOutput1= ""
                Dim arrResult() As String = sKeyID.Split(";"c)
                tdbcFrom.SelectedValue = arrResult(0)
                If tdbcTo IsNot Nothing Then
                    If arrResult.Length = 1 Then
                        tdbcTo.SelectedValue = arrResult(0)
                    Else : tdbcTo.SelectedValue = arrResult(1)
                    End If
                End If
                sKeyID = ""
            Else 'Lấy theo tập hợp: gán giá trị % cho 2 combo tiêu thức từ đến, chuỗi tiêu thức sSQLOutput1= sResult
                tdbcFrom.SelectedValue = "%"
                If tdbcTo IsNot Nothing Then tdbcTo.SelectedValue = "%"
            End If
            bPressF2 = True
        End If
        Return sKeyID
    End Function

End Module
