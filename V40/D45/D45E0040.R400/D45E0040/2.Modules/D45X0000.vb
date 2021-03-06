''' <summary>
''' Module này liên quan đến các vấn đề của SUB Main
''' </summary>
''' <remarks></remarks>

Module D45X0000

    ''' <summary>
    ''' Sub khởi động cho Module D45
    ''' </summary>
    Public Sub Main()
        SetSysDateTime()
#If DEBUG Then
        Dim f As New frmConnection
        f.ShowDialog()
        f.Dispose()
        'MakeVirtualConnection() 'Gán các kết nối ảo tạo đây
        'CheckDLL() 'Kiểm tra tính đồng bộ giữa các dll
#End If
        If PrevInstance() Then End 'Kiểm tra nếu chương trình đã chạy rồi thì END
        ReadLanguage() 'Đọc biến ngôn ngữ ở đây nhằm mục đích để báo lỗi theo ngôn ngữ cho những phần sau
#If DEBUG Then
#Else
        If Not CheckSecurity() Then End 'Kiểm tra an toàn cho chương trình, nếu không an toàn thì END
        'D00C0001.GetInfoFromSystemModule(Environment.CommandLine, gsCompanyID, gsUserID, gsServer, gsPassword, OptSettings, gsConnectionUser)  'Đọc các giá trị kết nối được truyền vào từ D00
        D00C0001.GetInfoFromSystemModule(My.Application.CommandLineArgs(0), gsCompanyID, gsUserID, gsServer, gsPassword, OptSettings, gsConnectionUser)  'Đọc các giá trị kết nối được truyền vào từ D00
#End If
        'Chuẩn hóa theo ID 56600
        'gsConnectionString = "Data Source=" & gsServer & ";Initial Catalog=" & gsCompanyID & ";User ID=" & gsConnectionUser & ";Password=" & gsPassword & ";Connection Timeout=0"  'Tạo chuỗi kết nối dùng cho toàn bộ project
        If Not CheckConnection() Then End 'Kiểm tra nối không kết nối được với Server thì END
        If Not CheckPermissionF0000() Then End 'Kiểm tra nếu không được quyền vào module thì END
        'Update 19/11/2010: Kiểm tra đồng bộ exe và fix 
        If Not CheckExeFixSynchronous(My.Application.Info.AssemblyName) Then End

        If Not CheckTableT9999() Then End 'Kiểm tra xem có đơn vị đã đăng ký cho module này chưa, nếu chưa thì END
        If Not CheckTrigger() Then End 'Kiểm tra Trigger cho module này, nếu không được thì END
        If Not CheckOther() Then End 'Vì lý do gì đó, có thể kiểm tra một điều kiện không hợp lệ và có thể kết thúc chương trình
        'Tới đây quá trình kiểm tra cho modlue đã hoàn thành, không còn lệnh END để kết thúc chương trình nữa
        LoadOptions() 'Load các thông số cho phần tùy chọn
        GetCodeTable() 'Load tuỳ chọn Unicode
        LoadSystems() 'Load các thông số cho phần thiết lập hệ thống
        LoadFormats() 'Load các thông số format cho phần format của module
        LoadOthers() 'Các lập trình viên có thể load những thứ khác ở đây
        ViewFormF0000() 'Hiển thị form main D45F0000, form này phải ShowDialog   
        KillChildProcess(MODULED45)
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
    '    Return D00C0003.SecurityL3R4(MODULED45, CType(geLanguage, D00D0041.EnumLanguage), L3_APP_NAME, L3_HS_SECTION, L3_HS_SECTION1, L3_HS_SECTION2, L3_HS_MODULE, L3_HS_VALUE)
    'End Function

    Private Function CheckPermissionF0000() As Boolean
        'Dim iPer As Integer = D00C0001.GetScreenPermission(gsUserID, gsCompanyID, D45, "D45F0000", gsServer, gsPassword)
        Dim iPer As Integer = ReturnPermission("D45F0000")
        If iPer <= 0 Then
            D99C0008.MsgL3(rl3("Ban_khong_co_quyen_vao_Luong_san_pham"), L3MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Function CheckTableT9999() As Boolean
        Dim sSQL As String = ""
        sSQL &= "Select top 1 1 "
        sSQL &= "From D09T9999 T99  WITH(NOLOCK) Inner Join D91T0016 T16  WITH(NOLOCK) On T99.DivisionID = T16.DivisionID "
        sSQL &= "Where T16.Disabled = 0 Order By T99.DivisionID"
        If ExistRecord(sSQL) Then
            Return True
        End If
        'D99C0008.MsgRegisterDivision()
        D99C0008.MsgL3(rl3("Ban_phai_dang_ky_don_vi_o_module_Nhan_su")) 'Bạn phải đăng ký đơn vị ở module Nhân sự
        Return False
    End Function

    Private Function CheckTrigger() As Boolean
        Dim sSQL As String = SQLStoreD91P9101()
        Return CheckStore(sSQL)
        'Dim dt As New DataTable
        'dt = ReturnDataTable(sSQL)
        'If dt.Rows.Count > 0 Then
        '    If dt.Rows(0).Item("Status").ToString <> "0" Then
        '        MessageBox.Show(dt.Rows(0).Item("Message").ToString, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        dt = Nothing
        '        Return False
        '    End If
        '    dt = Nothing
        '    Return True
        'End If
        'Return False
    End Function

    Private Function CheckOther() As Boolean
        Return True
    End Function

    Private Sub LoadOthers()
        GeneralItems()
        LoadUserKey()
        GetModuleAdmin(D45)
        IsUseBlock()
        LoadCreateBy()
        LoadCreateByG4()
        '  UseAuditLog()
    End Sub

    Private Sub ViewFormF0000()
        frmD45F0000 = New D45F0000()
        frmD45F0000.ShowDialog()
        frmD45F0000.Dispose()
        System.GC.Collect()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9101
    '# Create User: Nguyễn Thị Minh Hòa
    '# Create Date: 04/05/2006 08:32:16
    '# Modified User: 
    '# Modified Date: 
    '# Description: Kiểm tra bằng Trigger khi module khởi động
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD91P9101() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9101 "
        sSQL &= SQLString(D45.Substring(1, 2)) & COMMA 'ModuleID, VarChar[20], NOT NULL
        sSQL &= SQLNumber(IIf(geLanguage = EnumLanguage.Vietnamese, "0", "1")) 'Language, TinyInt, NOT NULL
        Return sSQL
    End Function

    Public Sub MakeVirtualConnection()
        gsServer = "10.0.0.15"
        gsCompanyID = "DRD02"
        gsConnectionUser = "sa"
        gsPassword = "2008"
        gsUserID = "LEMONADMIN"

        'gsServer = "drd247"
        'gsCompanyID = "drd02"
        'gsConnectionUser = "sa"
        'gsPassword = ""
        'gsUserID = "LEMONADMIN"
    End Sub

End Module
