Module D25X0010
    '''' <summary>
    '''' Các hàm AuditLog
    '''' </summary>
    'Public Sub UseAuditLog()
    '    '#------------------------------------------------------
    '    '#CreateUser:   Nguyen Thi Minh Hoa
    '    '#CreateDate:   21/11/2007
    '    '#ModifiedUser: Nguyen Thi Minh Hoa
    '    '#ModifiedDate: 21/11/2007
    '    '#Description: Kiểm tra module này có dùng Audit không? Có trả ra = True, không = False
    '    '#------------------------------------------------------
    '    Dim sSQL As String
    '    sSQL = "Select top 1 1 From D91T9200 Where Audit=1 And ModuleID= '25'"
    '    gbUseAudit = ExistRecord(sSQL)
    'End Sub

    Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, ByVal sDesc1 As String, ByVal sDesc2 As String, ByVal sDesc3 As String, ByVal sDesc4 As String, ByVal sDesc5 As String)
        ''Module này có dùng Auditlog không
        'If Not gbUseAudit Then Exit Sub
        ''Mã AuditCode này có sử dụng không
        'If Not CheckUseAuditCode(sAuditCode) Then Exit Sub

        'Ghi Audit cho mỗi nghiệp vụ
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9106 "
        sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(D25) & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL
        ExecuteSQLNoTransaction(sSQL)
    End Sub

    Private Function CheckUseAuditCode(ByVal AuditCode As String) As Boolean
        Dim sSQL As String
        sSQL = "Select 1 From D91T9200 WITH(NOLOCK)  Where  Audit =1 And AuditCode= " & SQLString(AuditCode)
        Return ExistRecord(sSQL)
    End Function

End Module
