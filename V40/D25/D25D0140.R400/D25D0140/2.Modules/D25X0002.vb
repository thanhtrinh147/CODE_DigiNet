''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
Module D25X0002
    Public Function ReturnImage(ByVal objExpression As Object) As Image
        If IsDBNull(objExpression) = False Then
            Dim ms As New System.IO.MemoryStream(CType(objExpression, Byte()))
            Dim img As Image = Image.FromStream(ms)
            Return img
        Else
            Return Nothing
        End If
    End Function

    Public Sub MsgNoPermissionAdd()
        D99C0008.MsgL3(rl3("Ban_khong_co_quyen_them_moi"))
    End Sub

    ''Kiểm tra trùng CMND: True: thỏa
    Public Function CheckIDCardNo(ByVal FormID As String, ByVal IDCardNo As String, ByVal CandidateID As String) As Boolean
        Dim dtCheckStore As DataTable = Nothing
        Dim bCheck As Boolean = CheckStore("-- Kiem tra trung CMND" & vbCrLf & SQLStoreD25P5555(FormID, IDCardNo, CandidateID, 1, 0), "", dtCheckStore)
        Dim iStatus As Integer = L3Int(dtCheckStore.Rows(0).Item("Status"))
        Select Case iStatus
            Case 0
                Return True
            Case 1 '1: Trùng D25 'Yes: True
                If Not bCheck Then Return False 'chọn No: không cho phép lưu
                'Chọn Yes
                Dim f As New D25F1054
                f.CandidateID = dtCheckStore.Rows(0).Item("CandidateID").ToString
                f.ShowDialog()
                f.Dispose()
                Return False
            Case 2, 3 '2: Trùng ở D09 và D25
                '3: chỉ trùng ở D09
                'Gọi D09F0100 – Exe D09E1040
                If bCheck Then
                    'ID 82836 14/12/2015
                    Dim arrPro() As StructureProperties = Nothing
                    SetProperties(arrPro, "ModuleID", D25)
                    SetProperties(arrPro, "EmployeeID", dtCheckStore.Rows(0).Item("EmployeeID").ToString)
                    CallFormShowDialog("D09D1040", "D09F0100", arrPro)
                End If
                If iStatus = 2 Then
                    Return False
                Else
                    Return True
                End If

        End Select
        Return True
    End Function

    Public Function CalExeAddNew(ByVal sExe As String, ByVal sFormActive As String, ByVal sFormPermission As String, ByVal sID As String) As String
        If ReturnPermission(sFormPermission) < 2 Then
            MsgNoPermissionAdd()
            Return ""
        End If
        Dim sKey As String = ""
        'ID 82836 14/12/2015
        Dim sDLL As String = sExe.Replace("E", "D")
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", sFormPermission)
        Dim frm As Form = CallFormShowDialog(sDLL, sFormActive, arrPro)
        If L3Bool(GetProperties(frm, "bSaved")) Then sKey = GetProperties(frm, sID).ToString
        Return sKey
    End Function

    Public Function ShowFormD09F0129(ByVal tdbc As C1.Win.C1List.C1Combo) As String
        If tdbc.SelectedValue Is Nothing OrElse tdbc.SelectedValue.ToString <> "+" Then Return ""
        tdbc.SelectedValue = ""
        Dim sResult As String = ""
        If ReturnPermission("D09F0128") > 1 Then
            'ID 82836 14/12/2015
            Dim arrPro() As StructureProperties = Nothing
            Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0129", arrPro)
            If L3Bool(GetProperties(frm, "bSaved")) Then sResult = GetProperties(frm, "RelationID").ToString
        Else
            MsgNoPermissionAdd()
            tdbc.Focus()
            Return ""
        End If

        Return sResult
    End Function

    Public Function GetThisFormDate(ByRef c1dateBirthDate As C1.Win.C1Input.C1DateEdit, ByVal sngay As String, ByVal sthang As String, ByVal snam As String) As Boolean
        Dim ngay As Integer = L3Int(sngay)
        Dim thang As Integer = L3Int(sthang)
        Dim nam As Integer = L3Int(snam)

        If ngay = 0 Then ngay = 1
        If thang = 0 Then thang = 1

        If nam <> 0 Then
            If IsDate(nam.ToString & "/" & thang.ToString & "/" & ngay.ToString) = False Then
                c1dateBirthDate.Value = ""
                Return False
            End If

            Dim d As New Date(nam, thang, ngay)
            c1dateBirthDate.Value = SQLDateShow(d)
        Else
            c1dateBirthDate.Value = ""
            Return True
        End If

        Return True
    End Function

    Public Function CheckNumInValid(ByRef c1dateBirthDate As C1.Win.C1Input.C1DateEdit, ByRef txtNum As TextBox, ByVal Min As Integer, ByVal max As Integer, ByVal ngay As String, ByVal thang As String, ByVal nam As String) As Boolean
        If txtNum.Text <> "" Then
            If L3Int(txtNum.Text) < Min OrElse L3Int(txtNum.Text) > max Then
                D99C0008.MsgL3(rl3("MSG000009"), L3MessageBoxIcon.Exclamation)
                txtNum.SelectAll()
                Return True
            End If
        End If

        If GetThisFormDate(c1dateBirthDate, ngay, thang, nam) = False Then txtNum.Text = ""
        Return False
    End Function

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLStoreD25P5555
    ''# Created User: Nguyễn Thị Ánh
    ''# Created Date: 29/02/2012 04:50:54
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: Kiểm tra trước khi lưu
    ''#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD25P5555(ByVal sFormID As String, ByVal skey01ID As String, ByVal skey02ID As String, ByVal iMode As Integer, ByVal iType As Byte) As String
        Dim sSQL As String = ""
        If iType = 1 Then
            sSQL &= ("-- Kiem tra trung so dien thoai" & vbCrLf)
        ElseIf iType = 2 Then
            sSQL &= ("-- Kiem tra trung so di dong" & vbCrLf)
        End If
        sSQL &= "Exec D25P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(sFormID) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLString(skey01ID) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString(skey02ID) & COMMA 'key02ID, varchar[20], NOT NULL 'Them ngay 1/3/2013 theo ID 54204
        sSQL &= SQLString("") & COMMA 'key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(iType) & COMMA 'Type, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P1509
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 11/01/2016 10:56:49
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD09P1509() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Combo do nguon chung cho cac combo (Tinh, Thanh pho, Quan, Huyen, Thi xa, Phuong, Xa, Thi tran)" & vbCrlf)
        sSQL &= "Exec D09P1509 "
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[250], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, ByVal sDesc1 As String, ByVal sDesc2 As String, ByVal sDesc3 As String, ByVal sDesc4 As String, ByVal sDesc5 As String)
        ''Ghi Audit cho mỗi nghiệp vụ
        'Dim sSQL As String = ""
        'sSQL &= "Exec D91P9106 "
        'sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        'sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        'sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        'sSQL &= SQLString(D25) & COMMA 'ModuleID, varchar[2], NOT NULL
        'sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        'sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        'sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL
        'ExecuteSQLNoTransaction(sSQL)
        Lemon3.D91.RunAuditLog("25", sAuditCode, sEventID, sDesc1, sDesc2, sDesc3, sDesc4, sDesc5) 'ID 84813 02/03/2016
    End Sub
End Module
