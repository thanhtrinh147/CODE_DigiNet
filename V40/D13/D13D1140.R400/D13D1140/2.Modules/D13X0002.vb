''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D13X0002



    Public Sub SetImageButton(ByVal btnSave As Button, ByVal btnNotSave As Button, ByVal btnNext As Button, ByVal imgButton As ImageList)
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

        btnNotSave.Text = rl3("_Khong_luu")
        btnNext.Text = rl3("Luu_va_Nhap__tiep") 'Nhập &tiếp
        btnSave.Text = rl3("_Luu") '&Lưu
    End Sub

#Region "Audit log"
    'Duyen sua
    Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, Optional ByVal sDesc1 As String = "", Optional ByVal sDesc2 As String = "", Optional ByVal sDesc3 As String = "", Optional ByVal sDesc4 As String = "", Optional ByVal sDesc5 As String = "")
        'sEventID = 1:Thêm mới;  = 2: Sửa;  = 3: Xóa;  = 4: In   

        'Module này có dùng Auditlog không
        'If Not gbUseAudit Then Exit Sub
        'Mã AuditCode này có sử dụng không
        'If Not CheckUseAuditCode(sAuditCode) Then Exit Sub

        'Ghi Audit cho mỗi nghiệp vụ
        'Dim sSQL As String = ""
        'sSQL &= "Exec D91P9106 "
        'sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        'sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        'sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        'sSQL &= SQLString("03") & COMMA 'ModuleID, varchar[2], NOT NULL
        'sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        'sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        'sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc5) & COMMA 'Desc5, varchar[250], NOT NULL
        'sSQL &= SQLNumber(iIsAuditDetail) & COMMA 'IsAuditDetail, tinyint, NOT NULL
        'sSQL &= SQLString(sAuditItemID) 'AuditItemID, varchar[50], NOT NULL
        'ExecuteSQLNoTransaction(sSQL)

        Lemon3.D91.RunAuditLog("13", sAuditCode, sEventID, sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

    End Sub

#End Region

End Module
