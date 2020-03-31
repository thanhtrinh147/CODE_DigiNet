''' <summary>
''' Module này liên quan đến các vấn đề của SUB Main
''' </summary>
''' <remarks></remarks>
Module D25X0000

    ''' <summary>
    ''' Sub khởi động cho Module D25
    ''' </summary>
    Public Sub Main()

        SetSysDateTime()
#If DEBUG Then
        'CheckDLL() 'Kiểm tra các DLL tương thích và các file Module hợp lệ
        'MakeVirtualConnection() 'Gán các kết nối ảo tạo đây
        'D99C0008.MsgL3("You're doing debug.")
         Dim frm As New frmConnection
        frm.ShowDialog()
        frm.Dispose()
#End If
        If PrevInstance() Then End 'Kiểm tra nếu chương trình đã chạy rồi thì END
        ReadLanguage() 'Đọc biến ngôn ngữ ở đây nhằm mục đích để báo lỗi theo ngôn ngữ cho những phần sau
#If DEBUG Then
#Else
        If Not CheckSecurity() Then End 'Kiểm tra an toàn cho chương trình, nếu không an toàn thì END

        D00C0001.GetInfoFromSystemModule(My.Application.CommandLineArgs(0).ToString, gsCompanyID, gsUserID, gsServer, gsPassword, OptSettings, gsConnectionUser)  'Đọc các giá trị kết nối được truyền vào từ D00

#End If
       
        If Not CheckConnection() Then End 'Kiểm tra nối không kết nối được với Server thì END

        If Not CheckPermissionF0000() Then End 'Kiểm tra nếu không được quyền vào module thì END
        If Not CheckExeFixSynchronous(My.Application.Info.AssemblyName) Then End
        If Not CheckTableT9999() Then End 'Kiểm tra xem có đơn vị đã đăng ký cho module này chưa, nếu chưa thì END
        If Not CheckTrigger() Then End 'Kiểm tra Trigger cho module này, nếu không được thì END
        If Not CheckOther() Then End 'Vì lý do gì đó, có thể kiểm tra một điều kiện không hợp lệ và có thể kết thúc chương trình
        'Tới đây quá trình kiểm tra cho modlue đã hoàn thành, không còn lệnh END để kết thúc chương trình nữa
        LoadOptions() 'Load các thông số cho phần tùy chọn
        GetCodeTable()
        LoadSystems() 'Load các thông số cho phần thiết lập hệ thống
        LoadFormatsNew() 'Load các thông số format cho phần format của module
        LoadOthers() 'Các lập trình viên có thể load những thứ khác ở đây

#If DEBUG Then
        gbUnicode = True
#End If
        ViewFormF0000() 'Hiển thị form main D25F0000, form này phải ShowDialog    

        KillChildProcess(MODULED25)
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
        MsgAnnouncement = IIf(geLanguage = EnumLanguage.Vietnamese, "Th¤ng bÀo", "Announcement").ToString
    End Sub

    'ID 80128 23/9/2015
    'Private Function CheckSecurity() As Boolean
    '    Return D00C0003.SecurityL3R4(MODULED25, CType(geLanguage, D00D0041.EnumLanguage), L3_APP_NAME, L3_HS_SECTION, L3_HS_SECTION1, L3_HS_SECTION2, L3_HS_MODULE, L3_HS_VALUE)
    'End Function


    Private Function CheckPermissionF0000() As Boolean
        'Dim iPer As Integer = D00C0001.GetScreenPermission(gsUserID, gsCompanyID, D25, "D25F0000", gsServer, gsPassword)
        Dim iPer As Integer = ReturnPermission("D25F0000")
        If iPer <= 0 Then
            D99C0008.MsgL3(rl3("Ban_khong_co_quyen_vao_Tuyen_dung"), L3MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Function CheckTableT9999() As Boolean
        Dim sSQL As String = ""
        sSQL = "Select Distinct DivisionID, DivisionName From D91T0016  WITH(NOLOCK) Where Disabled=0 Order by DivisionID"
        Dim dr As DataTable = returnDataTable(sSQL)
        If dr.rows.count > 0 Then
            Return True
        End If
        'D99C0008.MsgRegisterDivision()
        D99C0008.MsgL3(rl3("Ban_phai_dang_ky_don_vi_o_module_Nhan_su"))

        Return False
    End Function

    Private Function CheckTrigger() As Boolean
        Dim sSQL As String = SQLStoreD91P9101()
        Dim dr As DataTable = returnDataTable(sSQL)
        If dr.rows.count > 0 Then
            If dr.Rows(0).Item("Status").ToString <> "0" Then
                D99C0008.MsgL3(dr.Rows(0).Item("Message").ToString)
                Return False
            End If
            Return True
        End If
        Return False
    End Function

    Private Function CheckOther() As Boolean
        Return True
    End Function

    Private Sub LoadCurrencyID()
        'Loai tien mac dinh
        Dim sSQL As String = " SELECT a.BaseCurrencyID,b.ExchangeRate,b.Operator FROM D91T0025 a  WITH(NOLOCK) LEFT JOIN D91T0010 b  WITH(NOLOCK) ON a.BaseCurrencyID = b.CurrencyID  "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            gsCurrencyID = dt.Rows(0).Item("BaseCurrencyID").ToString
        End If

    End Sub

    Private Sub LoadOthers()
        LoadUserKey()
        'UseAuditLog()
        LoadCurrencyID()
        GetModuleAdmin("D25")
        LoadCreateBy()
        LoadCreateByG4()
        GeneralItems()
    End Sub

    Private Sub ViewFormF0000()
        frmD25F0000 = New D25F0000()
        frmD25F0000.ShowDialog()
        frmD25F0000.Dispose()
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
        sSQL &= SQLString(D25.Substring(1, 2)) & COMMA 'ModuleID, VarChar[20], NOT NULL
        sSQL &= SQLNumber(IIf(geLanguage = EnumLanguage.Vietnamese, "0", "1")) 'Language, TinyInt, NOT NULL
        Return sSQL
    End Function

    Public Sub MakeVirtualConnection()
        'gsServer = "10.0.0.252"
        'gsCompanyID = "DRD02"
        'gsConnectionUser = "sa"
        'gsPassword = "2008"
        'gsUserID = "LEMONADMIN"
        '-------------------------
        gsServer = "10.0.0.15"
        gsCompanyID = "DRD02"
        gsConnectionUser = "sa"
        gsPassword = "2008"
        gsUserID = "LEMONADMIN"

    End Sub

End Module