Imports System.Drawing
''' <summary>
''' Sub Main và các vấn đề liên quan đến việc khởi động exe con
''' </summary>
Module D45X0000

    Public Sub Main()
        SetSysDateTime()
#If DEBUG Then 'Nếu đang ở trạng thái DEBUG thì ...
        ''CheckDLL() 'Kiểm tra các DLL tương thích và các file Module hợp lệ
        'MakeVirtualConnection() 'tạo kết nối ảo
        ''geLanguage = EnumLanguage.Vietnamese 'Gán mặc định là Vietnamese
        ''gsLanguage = "84" 'Gán mặc định là Vietnamese
        'SaveParameter() 'Gán giá trị các thông số vào Registry
#Else 'Đang trong trạng thái thực thi exe
        If PrevInstance() Then End 'Kiểm tra nếu chương trình đã chạy rồi thì END
        ReadLanguage() 'Đọc biến ngôn ngữ ở đây nhằm mục đích để báo lỗi theo ngôn ngữ cho những phần sau
        If Not CheckSecurity() Then End 'Kiểm tra an toàn cho chương trình, nếu không an toàn thì END
#End If
        'giAppMode = Convert.ToInt16(D99C0007.GetOthersSetting(D45, MODULED45, "AppMode", "0"))

        GetAllParameter() 'Đọc các giá trị từ Registry lưu vào biến toàn cục

        If giAppMode = 1 Then 'Kết nối Online
            gsServer = "Remote Access"
            RemoteConnection()
        Else 'Kết nối trực tiếp       
            If Not CheckConnection() Then End 'Kiểm tra nối không kết nối được với Server thì END

            'Update 19/11/2010: Kiểm tra đồng bộ exe và fix 
            If Not CheckExeFixSynchronous(My.Application.Info.AssemblyName) Then End

        End If

        If Not CheckOther() Then End 'Vì lý do gì đó, có thể kiểm tra một điều kiện không hợp lệ và có thể kết thúc chương trình
        'Tới đây quá trình kiểm tra cho modlue đã hoàn thành, không còn lệnh END để kết thúc chương trình nữa
        LoadOptions() 'Load các thông số cho phần tùy chọn
        LoadSystems() 'Load các thông số cho phần thiết lập hệ thống
        'LoadFormats() 'Load các thông số format cho phần format của module
        LoadFormatsNew()
        LoadOthers() 'Các lập trình viên có thể load những thứ khác ở đây

        'Xóa(Registry)'when compile, You must D99C0007.RegDeleteExe
#If DEBUG Then
#Else
        D99C0007.RegDeleteExe(EXECHILD)
#End If

Select Case PARA_FormID
'Gọi form nhận tham số
Case Else
 Try
   'Gọi form không nhận tham số. Default 
   Dim frm As New Form
   Dim frmName As String = PARA_FormID
   frmName = System.Reflection.Assembly.GetEntryAssembly.GetName.Name & "." & frmName
   frm = DirectCast(System.Reflection.Assembly.GetEntryAssembly.CreateInstance(frmName), Form)
   frm.ShowInTaskbar = True
   frm.ShowDialog()
   frm.Dispose()
  Catch ex As Exception
   D99C0008.MsgL3(ex.Message)
  End Try
End Select

        KillChildProcess(MODULED45)
    End Sub

    Private Function CheckOther() As Boolean
        Return True
    End Function

    Private Sub LoadOthers()
        GetModuleAdmin(D45)
        LoadUserKey()
        GeneralItems()
        'UseAuditLog()
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

    Private Function CheckSecurity() As Boolean
        Dim D00_CompanyName As String
        Dim D00_LegalCopyright As String
        Dim CompanyName As String
        Dim LegalCopyright As String
        If Not System.IO.File.Exists(Application.StartupPath & "\D00E0030.EXE") Then
            If gsLanguage = "84" Then
                MessageBox.Show("Thï tóc gãi nèi bè bÊt híp lÖ! (10)", "Th¤ng bÀo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MessageBox.Show("Invalid internal system call! (10)", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Return False
        Else
            Dim D00_FiVerInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath & "\D00E0030.EXE")
            Dim FiVerInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath & "\" & MODULED45 & ".EXE")
            D00_CompanyName = D00_FiVerInfo.CompanyName
            D00_LegalCopyright = D00_FiVerInfo.LegalCopyright
            CompanyName = FiVerInfo.CompanyName
            LegalCopyright = FiVerInfo.LegalCopyright
            If (D00_CompanyName <> CompanyName) OrElse (D00_LegalCopyright <> LegalCopyright) Then
                If gsLanguage = "84" Then
                    MessageBox.Show("Thï tóc gãi nèi bè bÊt híp lÖ! (10)", "Th¤ng bÀo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("Invalid internal system call! (10)", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                Return False
            End If
        End If
        Dim CommandArgs() As String = Environment.GetCommandLineArgs()
        If CommandArgs.Length <> 3 OrElse CommandArgs(1) <> "/DigiNet" OrElse CommandArgs(2) <> "Corporation" Then
            If gsLanguage = "84" Then
                MessageBox.Show("Thï tóc gãi nèi bè bÊt híp lÖ! (12)", "Th¤ng bÀo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MessageBox.Show("Invalid internal system call! (12)", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Return False
        End If
        Return True
    End Function

#If DEBUG Then

    Private Sub MakeVirtualConnection()
        gsServer = "drd14"
        gsCompanyID = "drd02"
        gsPassword = ""
        gsUserID = "LEMONADMIN"
        gsConnectionUser = "sa"
    End Sub

#End If

    Private Sub GetAllParameter()
        PARA_Server = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ServerName", "", CodeOption.lmCode)
        PARA_ConnectionUser = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", "", CodeOption.lmCode)
        PARA_Password = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Password", "", CodeOption.lmCode)
        PARA_Database = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DBName", "", CodeOption.lmCode)
        PARA_UserID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "UserID", "", CodeOption.lmCode)

        PARA_DivisionID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DivisionID", "")
        PARA_TranMonth = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranMonth", CStr(Month(Date.Today)))
        PARA_TranYear = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranYear", CStr(Year(Date.Today)))
        PARA_Language = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Language", "84"), EnumLanguage)

        PARA_FormID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", "")
        PARA_FormIDPermission = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", "")

        PARA_bClosing = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Closed", "False"), Boolean)
        'PARA_Audit = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Audit", "False"), Boolean)
        'Bổ sung 05/12/2007 : quyền khóa phiếu
        'giPerD45F5557 = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "PerD45F5557", "0"))
        PARA_CreateBy = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "CreateBy", "")
        'PARA_HostID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "HostID", "")
        'PARA_FormName = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "FormName", "")
        'PARA_UseWHUnit = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "UseWHUnit", "0"), Int16)

        'PARA_Inherit = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Inherit", "False"), Boolean)
        'PARA_ID01 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID01", "")
        'PARA_ID02 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID02", "")
        'PARA_ID03 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID03", "")
        'PARA_ID04 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID04", "")

        PARA_ModuleID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ModuleID", "07")
        gbUnicode = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "CodeTable", "False"), Boolean)
        'PARA_LanguageReport = L3Int(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "LanguageReport", "0"))
        'PARA_ShowPathReport = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ShowPathReport", "False"), Boolean)

        'Select Case PARA_FormID
        'Case "D99F6666"
        '    PARA_PathReport = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "PathReport", "")
        '    PARA_ReportID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ReportID", "")

        '    Case "D45F2240", "D45F2340", "D45F2341"
        '        'BiÕn dîng ¢Ó load dö liÖu
        '        PARA_TransType = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID01", "")
        '        PARA_reVoucherID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID02", "")
        '        PARA_Mode = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID03", "0"))
        '        PARA_IsDeliveryLocationDefault = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID05", "False"), Boolean) 'Mặc định vị trí xuất theo vị trí nhập gần nhất
        '        PARA_IsReceiptLocationDefault = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID09", "False"), Boolean) 'Mặc định vị trí nhập theo vị trí nhập gần nhất
        '        PARA_CompletedLocationColor = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID06", "0")) 'Mã hàng đã chọn vị trí đầy đủ (dùng cho D45F2240)
        '        PARA_InProgressLocationColor = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID45", "0")) 'Mã hàng đã chọn vị trí còn dỡ dang (dùng cho D45F2240)
        '        PARA_NotInProgressLocationColor = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID08", "0")) 'Mã hàng chưa đợc chọn vị trí (dùng cho D45F2240)

        '        PARA_InfoFormCode = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "InfoFormCode", "")
        '        PARA_HostID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "HostID", "")
        '        PARA_FormName = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "FormName", "")
        '        PARA_Module = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Module", "")
        '        PARA_BatchID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "BatchID", "")
        '        PARA_FormInfo = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "FormInfo", "")
        '    Case "D45F2222", "D45F2233"
        '        PARA_Mode = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID03", "1"))
        '        PARA_WareHouseID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "WareHouseID", "")
        '        PARA_WareHouseID2 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "WareHouseID2", "")
        '        PARA_KindVoucherID = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "KindVoucherID", "0"))
        '    Case "D45F2201", "D45F2200"
        '        PARA_IsDeliveryLocationDefault = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID05", "False"), Boolean) 'Mặc định vị trí xuất theo vị trí nhập gần nhất
        '        PARA_IsReceiptLocationDefault = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID09", "False"), Boolean) 'Mặc định vị trí nhập theo vị trí nhập gần nhất

        '        PARA_CompletedLocationColor = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID06", "0")) 'Mã hàng đã chọn vị trí đầy đủ (dùng cho D45F2240)
        '        PARA_InProgressLocationColor = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID45", "0")) 'Mã hàng đã chọn vị trí còn dỡ dang (dùng cho D45F2240)
        '        PARA_NotInProgressLocationColor = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID08", "0")) 'Mã hàng chưa đợc chọn vị trí (dùng cho D45F2240)

        '        PARA_HostID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "HostID", "")
        '        PARA_FormName = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "FormName", "")
        '    Case "D45F5559"
        '        PARA_InfoFormCode = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "InfoFormCode", "")
        '        PARA_HostID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "HostID", "")
        '        PARA_FormName = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "FormName", "")
        '        PARA_RowIndex = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "RowIndex", "0"))
        '    Case "D45F2250", "D45F2251"
        '        PARA_HostID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "HostID", "")
        '        PARA_FormName = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "FormName", "")
        '    Case "D45F6153"
        '        PARA_InventoryID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "InventoryID", "")
        '        PARA_InventoryName = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "InventoryName", "")
        '        PARA_UnitID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "UnitID", "")
        '        PARA_WareHouseID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "WareHouseID", "")
        '        PARA_Spec01ID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Spec01ID", "")
        '        PARA_Spec02ID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Spec02ID", "")
        '        PARA_Spec03ID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Spec03ID", "")
        '        PARA_Spec04ID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Spec04ID", "")
        '        PARA_Spec05ID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Spec05ID", "")
        '        PARA_Spec06ID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Spec06ID", "")
        '        PARA_Spec07ID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Spec07ID", "")
        '        PARA_Spec08ID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Spec08ID", "")
        '        PARA_Spec09ID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Spec09ID", "")
        '        PARA_Spec10ID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Spec10ID", "")
        '    Case "D45F3500"
        '        PARA_ObjectTypeID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID01", "")
        '        PARA_ObjectID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID02", "")
        '    Case "D45F2350"
        '        PARA_WareHouseID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID01", "")
        '    Case "D45F2015"
        '        PARA_KindVoucherID = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "KindVoucherID", "1"))
        '        PARA_RDVoucherID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "RDVoucherID", "")
        '        PARA_RDVoucherNo = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "RDVoucherNo", "")
        'End Select

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
        D99C0008.Language = geLanguage
        PARA_FormID = PARA_FormID
        PARA_FormIDPermission = PARA_FormIDPermission

        gbClosed = PARA_bClosing
        'gbUseAudit = PARA_Audit
        gsCreateBy = PARA_CreateBy
    End Sub

    Private Sub SaveParameter()
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ServerName", gsServer, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DBName", gsCompanyID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", gsConnectionUser, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "UserID", gsUserID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Password", gsPassword, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DivisionID", "DIGINET")  '"DIGINET"
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranMonth", "10")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranYear", "2011")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Language", "0")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", "D45F2360") 'PARA_FormID'D45F2340
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", "D45F2360") 'PARA_FormIDPermission
        'D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Inherit", "False")
        'D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID01", "07")
        'D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ModuleID", "07")
        'D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "PerD45F5557", "4")
        'D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "D45F5558", "4")
        'D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID02", "07PV0J000001742")
    End Sub

#Region "Hàm dùng cho WEBSERVICE"
    Private Sub RemoteConnection()
        GetInfoWebService()
        If CheckRemoteConnection(gsAppServer) = False Then
            D99C0008.MsgInvalidConnection()
            End
        End If
    End Sub
    ''' <summary>
    ''' Kiểm tra kết nối của Webservice
    ''' </summary>
    ''' <param name="sHttp"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckRemoteConnection(ByVal sHttp As String) As Boolean
        Try
            CallWebService.Url = sHttp & "D91W0000.asmx"
            'CallWebService.Timeout = 10000000
            CallWebService.Timeout = nWSTimeOut
            CallWebService.UserExists("LEMONADMIN", gsWSSPara01, gsWSSPara02, gsWSSPara03, gsWSSPara04, gsWSSPara05)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Lấy thông tin của Webservice
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetInfoWebService()
        gsAppServer = D99C0007.GetOthersSetting(D45, MODULED45, "AppServer")
        gsWSSPara01 = D99C0007.GetOthersSetting(D45, MODULED45, "WSSPara01")
        gsWSSPara02 = D99C0007.GetOthersSetting(D45, MODULED45, "WSSPara02")
        gsWSSPara03 = D99C0007.GetOthersSetting(D45, MODULED45, "WSSPara03")
        gsWSSPara04 = D99C0007.GetOthersSetting(D45, MODULED45, "WSSPara04")
        gsWSSPara05 = D99C0007.GetOthersSetting(D45, MODULED45, "WSSPara05")
    End Sub

    ''' <summary>
    ''' Ghi các thông tin về Webservice để test
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetInfoWS()
        gsAppServer = "http://webservice/ws2005/"
        D99C0007.SaveOthersSetting(D45, MODULED45, "AppMode", "1")
        D99C0007.SaveOthersSetting(D45, MODULED45, "AppServer", gsAppServer)
        D99C0007.SaveOthersSetting(D45, MODULED45, "WSSPara01", gsWSSPara01)
        D99C0007.SaveOthersSetting(D45, MODULED45, "WSSPara02", gsWSSPara02)
        D99C0007.SaveOthersSetting(D45, MODULED45, "WSSPara03", gsWSSPara03)
        D99C0007.SaveOthersSetting(D45, MODULED45, "WSSPara04", gsWSSPara04)
        D99C0007.SaveOthersSetting(D45, MODULED45, "WSSPara05", gsWSSPara05)
    End Sub
#End Region
End Module