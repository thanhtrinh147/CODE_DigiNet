Imports System.Text.RegularExpressions
Imports System.IO

''' <summary>
''' Module này liên quan đến các vấn đề của SUB Main
''' </summary>
''' <remarks></remarks>
Module D13X0000

    ''' <summary>
    ''' Sub khởi động cho Module D13
    ''' </summary>
    Public Sub Main()

        SetSysDateTime()

#If DEBUG Then
        'D99C0008.MsgL3("Warning for Debug!!!")

        '   MakeVirtualConnection() 'Gán các kết nối ảo tạo đây
        'CheckDLL() 'Kiểm tra tính đồng bộ giữa các dll
        Dim frm As New frmConnection
        frm.ShowDialog()
        frm.Dispose()
#End If
        If PrevInstance() Then End 'Kiểm tra nếu chương trình đã chạy rồi thì END
        ReadLanguage() 'Đọc biến ngôn ngữ ở đây nhằm mục đích để báo lỗi theo ngôn ngữ cho những phần sau
#If DEBUG Then
#Else

        If Not CheckSecurity() Then End 'Kiểm tra an toàn cho chương trình, nếu không an toàn thì END
        'D99C0008.Msg("CommandLineArgs(0) = " & CommandLineArgs(1))

        D00C0001.GetInfoFromSystemModule(My.Application.CommandLineArgs(0).ToString, gsCompanyID, gsUserID, gsServer, gsPassword, OptSettings, gsConnectionUser)  'Đọc các giá trị kết nối được truyền vào từ D00
#End If

#If DEBUG Then
        'PARA_FormID = "D13F2040"
#Else
        'Xóa Registry
        D99C0007.RegDeleteExe(EXECHILD)
#End If
        'D99C0008.Msg("gsServer = " & gsServer & " - " & "gsCompanyID= " & gsCompanyID & " - " & "gsConnectionUser = " & gsConnectionUser & " - " & "gsUserID= " & gsUserID & " - " & "gsPassword = " & gsPassword)
        If Not CheckConnection() Then End 'Kiểm tra nối không kết nối được với Server thì END

        If Not CheckPermissionF0000() Then End 'Kiểm tra nếu không được quyền vào module thì END

        'Update 19/11/2010: Kiểm tra đồng bộ exe và fix 
        If Not CheckExeFixSynchronous(My.Application.Info.AssemblyName) Then End

        If Not CheckTableT9999() Then End 'Kiểm tra xem có đơn vị đã đăng ký cho module này chưa, nếu chưa thì END
        If Not CheckTrigger() Then End 'Kiểm tra Trigger cho module này, nếu không được thì END
        If Not CheckOther() Then End 'Vì lý do gì đó, có thể kiểm tra một điều kiện không hợp lệ và có thể kết thúc chương trình
        'Tới đây quá trình kiểm tra cho modlue đã hoàn thành, không còn lệnh END để kết thúc chương trình nữa
        GetCodeTable() 'Load tuỳ chọn Unicode
        LoadInfoGeneral()
#If DEBUG Then
        '      gbUnicode = False
#End If
        LoadOthers() 'Các lập trình viên có thể load những thứ khác ở đây
        'D99C0008.Msg("LOI")

        ViewFormF0000() 'Hiển thị form main D13F0000, form này phải ShowDialog  

        KillChildProcess(MODULED13)
    End Sub

    Private Function PrevInstance() As Boolean
        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub ReadLanguage()
        Dim sLanguage As String = GetSetting("Lemon3 System Module", "Caption Setting", "Language", "0")
        If sLanguage = "0" Then
            geLanguage = EnumLanguage.Vietnamese
            gsLanguage = "84"
        Else
            geLanguage = EnumLanguage.English
            gsLanguage = "01"
        End If
        D99C0008.Language = geLanguage
    End Sub

    'Private Function CheckSecurity() As Boolean
    '    Return D00C0003.SecurityL3R4(MODULED13, CType(geLanguage, D00D0041.EnumLanguage), L3_APP_NAME, L3_HS_SECTION, L3_HS_SECTION1, L3_HS_SECTION2, L3_HS_MODULE, L3_HS_VALUE)
    'End Function

    Private Function CheckPermissionF0000() As Boolean
        'Dim iPer As Integer = D00C0001.GetScreenPermission(gsUserID, gsCompanyID, D13, "D13F0000", gsServer, gsPassword)
        Dim iPer As Integer = ReturnPermission("D13F0000")
        If iPer <= 0 Then
            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_vao_Tien_luong"), L3MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Function CheckTableT9999() As Boolean
        Dim sSQL As String = ""
        sSQL &= "Select Distinct T99.DivisionID, T16.DivisionName "
        sSQL &= "From D09T9999 T99  WITH (NOLOCK) Inner Join D91T0016 T16  WITH (NOLOCK) On T99.DivisionID = T16.DivisionID "
        sSQL &= "Where T16.Disabled = 0 Order By T99.DivisionID"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            Return True
        End If
        'D99C0008.MsgRegisterDivision()
        D99C0008.MsgL3(rL3("Ban_phai_dang_ky_don_vi_o_module_Nhan_su"), L3MessageBoxIcon.Exclamation)
        Return False
    End Function

    Private Function CheckTrigger() As Boolean
        Dim sSQL As String = SQLStoreD91P9101()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("Status").ToString <> "0" Then
                    D99C0008.MsgL3(dt.Rows(i).Item("Message").ToString)
                    Return False
                End If
                Return True
            Next

        End If
        Return False
    End Function

    Private Function CheckOther() As Boolean
        Return True
    End Function

    Private Sub LoadOthers()
        LoadUserKey()
        GetModuleAdmin(D13)
        GeneralItems()
        LoadCreateBy() 'Lấy giá trị mặc định của người lập
        LoadCreateByG4() 'Lấy giá trị mặc định của người lập
        UseModuleD54() 'Kiểm tra có sử dụng D54 không
    End Sub

    Private Sub ViewFormF0000()

        frmD13F0000 = New D13F0000()
        frmD13F0000.ShowDialog()
        frmD13F0000.Dispose()

        System.GC.Collect()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9101
    '# Create User: LE VAN PHUOC
    '# Create Date: 04/05/2006 08:32:16
    '# Modified User: 
    '# Modified Date: 
    '# Description: Kiểm tra bằng Trigger khi module khởi động
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD91P9101() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9101 "
        sSQL &= SQLString(D13.Substring(1, 2)) & COMMA 'ModuleID, VarChar[20], NOT NULL
        sSQL &= SQLNumber(IIf(geLanguage = EnumLanguage.Vietnamese, "0", "1")) 'Language, TinyInt, NOT NULL
        Return sSQL
    End Function

#If DEBUG Then

    Public Sub MakeVirtualConnection()
        gsServer = "10.0.0.252"
        gsCompanyID = "DRD02"
        gsConnectionUser = "sa"
        gsPassword = "2008"
        gsUserID = "LEMONADMIN"
        '
        '        gsServer = "DRD186"
        '        gsCompanyID = "NS"
        '        gsConnectionUser = "sa"
        '        gsPassword = ""
        '        gsUserID = "LEMONADMIN"

        '        gsServer = "DCSSERVER\SQL2008 "
        '        gsCompanyID = "TANCANG1"
        '        gsConnectionUser = "sa"
        '        gsPassword = ""
        '        gsUserID = "LEMONADMIN"


    End Sub

    Private Sub SaveParameter()
        '        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ServerName", "DRD14", CodeOption.lmCode)
        '        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DBName", "drd02", CodeOption.lmCode)
        '        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", "sa", CodeOption.lmCode)
        '        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Password", "", CodeOption.lmCode)

        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "UserID", "LEMONADMIN", CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DivisionID", "THHA")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranMonth", "12")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranYear", "2011")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Language", "0")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", "D13F2040") 'PARA_FormID
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", "D13F2040") 'PARA_FormIDPermission
    End Sub

#End If

    Private Sub GetAllParameter()
        PARA_Server = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ServerName", "", CodeOption.lmCode)
        PARA_Database = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DBName", "", CodeOption.lmCode)
        PARA_ConnectionUser = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", "", CodeOption.lmCode)
        PARA_UserID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "UserID", "", CodeOption.lmCode)
        PARA_Password = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Password", "", CodeOption.lmCode)
        PARA_DivisionID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DivisionID", "")
        PARA_TranMonth = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranMonth", "01")
        PARA_TranYear = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranYear", "2008")
        PARA_Language = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Language", "84"), EnumLanguage)
        PARA_FormID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", "")
        PARA_FormIDPermission = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", "")

        '-----------------------------------------------------------------------
        AssignToPublicVariable()
    End Sub

    Private Sub AssignToPublicVariable()
        gsServer = PARA_Server
        gsCompanyID = PARA_Database
        gsConnectionUser = PARA_ConnectionUser
        gsUserID = PARA_UserID
        gsPassword = PARA_Password
        gsDivisionID = PARA_DivisionID
        giTranMonth = CInt(PARA_TranMonth)
        giTranYear = CInt(PARA_TranYear)
        geLanguage = PARA_Language
        gsLanguage = IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString
        PARA_FormID = PARA_FormID
        PARA_FormIDPermission = PARA_FormIDPermission
        '-----------------------------------------------------------------------        
    End Sub

End Module
