''' <summary>
''' Sub Main và các vấn đề liên quan đến việc khởi động exe con
''' </summary>
Module D13X0000

    Public Sub Main()
        SetSysDateTime()
#If DEBUG Then 'Nếu đang ở trạng thái DEBUG thì ...
        ' ''CheckDLL() 'Kiểm tra các DLL tương thích và các file Module hợp lệ
        'MakeVirtualConnection() 'tạo kết nối ảo
        ''geLanguage = EnumLanguage.Vietnamese 'Gán mặc định là Vietnamese
        ''gsLanguage = "01" 'Gán mặc định là Vietnamese
        'SaveParameter() 'Gán giá trị các thông số vào Registry
#Else 'Đang trong trạng thái thực thi exe
        If PrevInstance() Then End 'Kiểm tra nếu chương trình đã chạy rồi thì END
        ReadLanguage() 'Đọc biến ngôn ngữ ở đây nhằm mục đích để báo lỗi theo ngôn ngữ cho những phần sau
        If Not CheckSecurity() Then End 'Kiểm tra an toàn cho chương trình, nếu không an toàn thì END
#End If

        GetAllParameter() 'Đọc các giá trị từ Registry lưu vào biến toàn cục
        If Not CheckConnection() Then End 'Kiểm tra nối không kết nối được với Server thì END
        'Update 19/11/2010: Kiểm tra đồng bộ exe và fix 
        If Not CheckExeFixSynchronous(My.Application.Info.AssemblyName) Then End

        If Not CheckOther() Then End 'Vì lý do gì đó, có thể kiểm tra một điều kiện không hợp lệ và có thể kết thúc chương trình
        'Tới đây quá trình kiểm tra cho modlue đã hoàn thành, không còn lệnh END để kết thúc chương trình nữa

        LoadSystems()
        LoadFormats()
        LoadCustomFormat()
        LoadOptions() 'Load các thông số cho phần tùy chọn
#If DEBUG Then
        'PARA_FormID = "D13F4200"
        'gbUnicode = True
#Else
''Xóa Registry
        D99C0007.RegDeleteExe(EXECHILD)
#End If
        LoadOthers() 'Các lập trình viên có thể load những thứ khác ở đây
        'Hiển thị form tương ứng
        Select Case PARA_FormID
            'Gọi form nhận tham số
            Case "D13F4200"
                Dim frm As New D13F4200
                frm.ShowInTaskbar = True
                frm.ShowDialog()
                frm.Dispose()
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
        KillChildProcess(MODULED13)
    End Sub

    Private Function CheckOther() As Boolean
        Return True
    End Function

    Private Sub LoadOthers()
        'UseAuditLog()
        LoadUserKey()
        GeneralItems()
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
            Dim FiVerInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath & "\" & MODULED13 & ".EXE")
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

    Private Sub MakeVirtualConnection()
        gsServer = "DRD252"
        gsCompanyID = "DRD02"
        gsConnectionUser = "sa"
        gsPassword = "2008"
        gsUserID = "LEMONADMIN"

        '        gsServer = "DRD40"
        '        gsCompanyID = "TANCANG"
        '        gsConnectionUser = "sa"
        '        gsPassword = "123"
        '        gsUserID = "LEMONADMIN"
    End Sub

    Private Sub GetAllParameter()
        ' Lấy giá trị từ exe cha truyền qua
        ' Giá trị bắt buộc chung cho tất cả các module:
        gsServer = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ServerName", "", CodeOption.lmCode)
        gsCompanyID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DBName", "", CodeOption.lmCode)
        gsConnectionUser = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", "", CodeOption.lmCode)
        gsUserID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "UserID", "", CodeOption.lmCode)
        gsPassword = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Password", "", CodeOption.lmCode)
        gsDivisionID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DivisionID", "")
        giTranMonth = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranMonth", CStr(Month(Date.Today))))
        giTranYear = CInt(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranYear", CStr(Year(Date.Today))))

        geLanguage = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Language", "84"), EnumLanguage)
        gsLanguage = IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString
        D99C0008.Language = geLanguage
        MsgAnnouncement = IIf(geLanguage = EnumLanguage.Vietnamese, "Th¤ng bÀo", "Announcement").ToString

        PARA_FormID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", "")
        PARA_FormIDPermission = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", "")
        'Chú ý: Nếu không có form phân quyền thì lấy form Active
        If PARA_FormIDPermission = "" Then PARA_FormIDPermission = PARA_FormID


        'Update 19/03/2013
        gsCreateBy = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "CreateBy", "")
        gbLockL3UserID = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "LockL3UserID", "False"), Boolean)
        gbClosed = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Closed", "0"), Boolean)
        gbUnicode = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "CodeTable", "False"), Boolean)
        gbUseD54 = L3Bool(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "UseD54", "False"))
        gbPrintVNI = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "IsPrintVNI", "False"), Boolean)

        'Khái báo biến PARA_FormState trong mỗi module: Public PARA_FormState As EnumFormState = EnumFormState.FormAdd
        PARA_FormState = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "FormState", "0"), EnumFormState)
        'Khái báo biến PARA_ModuleID trong mỗi module: Public PARA_ModuleID As String = "08" 'Giá trị là 2 ký tự xx: dùng cho lưu Server
        PARA_ModuleID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ModuleID", "") ' Đặt biến theo hàm GetReportPath đã có trước đó

        'Chú ý: luôn luôn lấy 2 ký tự để xử lý
        If PARA_ModuleID = "" Then ' Nếu ="" thì lấy mặc định module đó
            PARA_ModuleID = "08"
        Else
            PARA_ModuleID = L3Right(PARA_ModuleID, 2)
        End If
        gsModuleID = "D" & PARA_ModuleID 'Khái báo biến gsModuleID trong mỗi module: Public gsModuleID As String = "D08" 'Giá trị là 3 ký tự Dxx: dùng cho truyền biến trên client

        '-----------------------------------------------------------------------------------------------
        ' Giá trị đặc thù của mỗi module được đặt tại đây
        '-----------------------------------------------------------------------------------------------
        'Không dùng hàm này nữa
        'AssignToPublicVariable()
    End Sub

    '    Private Sub AssignToPublicVariable()
    '        gsServer = PARA_Server
    '        gsCompanyID = PARA_Database
    '        gsConnectionUser = PARA_ConnectionUser
    '        gsUserID = PARA_UserID
    '        gsPassword = PARA_Password
    '        gsDivisionID = PARA_DivisionID
    '        giTranMonth = CInt(PARA_TranMonth)
    '        giTranYear = CInt(PARA_TranYear)
    '        geLanguage = PARA_Language
    '        gsLanguage = IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString
    '        D99C0008.Language = geLanguage
    '        PARA_FormID = PARA_FormID
    '        PARA_FormIDPermission = PARA_FormIDPermission
    '        '-----------------------------------------------------------------------        
    '    End Sub

    Private Sub SaveParameter()
        Dim sForm As String = "D13F4200"

        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ServerName", gsServer, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DBName", gsCompanyID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", gsConnectionUser, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "UserID", gsUserID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Password", gsPassword, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DivisionID", "QT")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranMonth", "02")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranYear", "2014")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Language", "0")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", sForm) 'PARA_FormID
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", sForm) 'PARA_FormIDPermission
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "FormState", "1") 'PARA_FormIDPermission
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DepartmentID", "")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TeamID", "PGD")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "EmployeeID", "000001/T/H/2008")

        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID01", "")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID02", "")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID03", "")
    End Sub

End Module
