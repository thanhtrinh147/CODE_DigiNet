''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D45X0002
    Public Sub SetImageButton(ByVal btnSave As Button, ByVal btnNotSave As Button, ByVal imgButton As ImageList)
        btnSave.Size = New System.Drawing.Size(76, 27)
        'btnNext.Size = New System.Drawing.Size(130, 27)
        btnNotSave.Size = New System.Drawing.Size(100, 27)

        btnSave.ImageList = imgButton
        btnSave.ImageIndex = 0
        btnSave.ImageAlign = ContentAlignment.MiddleLeft

        'btnNext.ImageList = imgButton
        'btnNext.ImageIndex = 1
        'btnNext.ImageAlign = ContentAlignment.MiddleLeft

        btnNotSave.ImageList = imgButton
        btnNotSave.ImageIndex = 1
        btnNotSave.ImageAlign = ContentAlignment.MiddleLeft

        btnSave.Text = rL3("_Luu") '&Lưu
        btnNotSave.Text = rL3("_Khong_luu")
        'btnNext.Text = rL3("Luu_va_Nhap__tiep") 'Nhập &tiếp
    End Sub

    Public Sub InsertD45T5558(ByVal sVoucherIGE As String, ByVal sOldVoucherNo As String, ByVal sNewVoucherNo As String)
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D45T5558(")
        sSQL.Append("PVoucherID, OldVoucherNo, NewVoucherNo, CreateUserID, CreateDate, ")
        sSQL.Append("LastModifyUserID, LastModifyDate, TranMonth, TranYear, DivisionID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(sVoucherIGE) & COMMA) 'PVoucherID, varchar[50], NOT NULL
        sSQL.Append(SQLString(sOldVoucherNo) & COMMA) 'OldVoucherNo, varchar[50], NOT NULL
        sSQL.Append(SQLString(sNewVoucherNo) & COMMA) 'NewVoucherNo, varchar[50], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[50], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[50], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear)) 'TranYear, int, NOT NULL
        sSQL.Append(COMMA & SQLString(gsDivisionID)) 'DivisionID, varchar[50], NOT NULL
        sSQL.Append(")")

        ExecuteSQLNoTransaction(sSQL.ToString)
    End Sub
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