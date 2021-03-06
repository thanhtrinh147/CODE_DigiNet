''' <summary>
''' Sub Main và các vấn đề liên quan đến việc khởi động exe con
''' </summary>
Module D13X0000

    Public Sub Main()
        SetSysDateTime()
#If DEBUG Then 'Nếu đang ở trạng thái DEBUG thì ...
        'CheckDLL() 'Kiểm tra các DLL tương thích và các file Module hợp lệ
        '         MakeVirtualConnection() 'tạo kết nối ảo
        '        geLanguage = EnumLanguage.Vietnamese 'Gán mặc định là Vietnamese
        '        gsLanguage = "01" 'Gán mặc định là Vietnamese
        '       SaveParameter() 'Gán giá trị các thông số vào Registry
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
        LoadOptions() 'Load các thông số cho phần tùy chọn
        LoadOthers() 'Các lập trình viên có thể load những thứ khác ở đây

#If DEBUG Then
        '        PARA_FormID = "D13F4020"
        '        PARA_ID02 = "True"
        'gbUnicode = False

#Else
    'Xóa Registry
        D99C0007.RegDeleteExe(EXECHILD)
#End If

        'Hiển thị form tương ứng
        Select Case PARA_FormID
            Case "D13F4010" 'Báo cáo ---> B. Bảng điều chỉnh thu nhập
                Dim f As New D13F4010
                With f
                    .ShowInTaskbar = True
                    .ShowDialog()
                    .Dispose()
                End With

            Case "D13F4020" 'Báo cáo ---> C. Bảng lương công ty  ---> D. Chuyển bảng lương qua Email
                Dim f As New D13F4020
                With f
                    .ShowInTaskbar = True
                    .CallingForm = PARA_ID01
                    .bIsTransferByEmail = CType(IIf(PARA_ID02 = "", False, PARA_ID02), Boolean)
                    .PayrollVoucherNo = PARA_ID03
                    .SalaryVoucherNo = PARA_ID04
                    'Update 19/12/2012: Incident 45383
                    .sFind = PARA_ID06
                    .EmployeeID = PARA_ID07
                    .DepartmentID = PARA_ID08
                    .TeamID = PARA_ID09
                    .EmployeeName = PARA_ID10
                    .BlockID = PARA_ID11
                    .EmpGroupID=PARA_ID12
                    .ShowDialog()
                    .Dispose()
                End With

            Case "D13F4060" 'Báo cáo ---> E. Khai thuế TNCN
                Dim f As New D13F4060
                With f
                    .ShowInTaskbar = True
                    .PITVoucherID = PARA_ID01
                    .BlockID = IIf(PARA_ID02 = "", "%", PARA_ID02).ToString
                    .DepartmentID = IIf(PARA_ID03 = "", "%", PARA_ID03).ToString
                    .TeamID = IIf(PARA_ID04 = "", "%", PARA_ID04).ToString
                    .DeductionLabor = CType(IIf(PARA_ID05 = "", True, PARA_ID05), Boolean)
                    .NonDeductionLabor = CType(IIf(PARA_ID06 = "", False, PARA_ID06), Boolean)
                    .WhereClause = PARA_ID07
                    .ShowDialog()
                    .Dispose()
                End With

            Case "D13F4070" 'Báo cáo ---> E. Khai thuế TNCN
                Dim f As New D13F4070
                With f
                    .ShowInTaskbar = True
                    .PITBalanceVoucherID = PARA_ID01
                    .BlockID = IIf(PARA_ID02 = "", "%", PARA_ID02).ToString
                    .DepartmentID = IIf(PARA_ID03 = "", "%", PARA_ID03).ToString
                    .TeamID = IIf(PARA_ID04 = "", "%", PARA_ID04).ToString
                    .WhereClause = PARA_ID05
                    .PITYear = PARA_ID06
                    .StrEmployeeID = PARA_ID07
                    .StrEmployeeName = PARA_ID08
                    .WorkingStatusID = PARA_ID09
                    .EmployeeID = PARA_ID10
                    .ShowDialog()
                    .Dispose()
                End With

            Case "D13F4040" 'Báo cáo phiếu lương (gọi từ Bảng lương CBCNV- D13F2042)
                Dim f As New D13F4040
                With f
                    .ShowInTaskbar = True
                    .SQLStoreD13P3602 = PARA_ID01
                    .SQLStoreD29P4000 = PARA_ID02
                    .sFind = PARA_ID03
                    .SalCalMethodID = PARA_ID04
                    .sSalaryVoucherID = PARA_ID05
                    .sPayrollVoucherID = PARA_ID06
                    'Update 19/12/2012: Incident 45383
                    .EmployeeID = PARA_ID07
                    .DepartmentID = PARA_ID08
                    .TeamID = PARA_ID09
                    .EmployeeName = PARA_ID10
                    .ShowDialog()
                    .Dispose()
                End With
            Case "D13F4030"
                Dim f As New D13F4030
                With f
                    .ShowInTaskbar = True
                    .ShowDialog()
                    .Dispose()
                End With
            Case Else
                Try
                    Dim frm As New Form
                    Dim frmName As String = PARA_FormID
                    frmName = System.Reflection.Assembly.GetEntryAssembly.GetName.Name & "." & frmName
                    frm = DirectCast(System.Reflection.Assembly.GetEntryAssembly.CreateInstance(frmName), Form)
                    frm.ShowInTaskbar = True
                    frm.ShowDialog()
                    frm.Dispose()
                Catch ex As Exception
                    D99C0008.MsgL3("Can't open form " & PARA_FormID & " at exe " & EXECHILD)
                End Try
        End Select

        'KillChildProcess(MODULED13)
    End Sub

    Private Function CheckOther() As Boolean
        Return True
    End Function

    Private Sub LoadOthers()
        'UseAuditLog()
        LoadUserKey()
        GetModuleAdmin(D13)
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

    Private Sub GetAllParameter()
        PARA_Server = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ServerName", "", CodeOption.lmCode)
        PARA_Database = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DBName", "", CodeOption.lmCode)
        PARA_ConnectionUser = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", "", CodeOption.lmCode)
        PARA_UserID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "UserID", "", CodeOption.lmCode)
        PARA_Password = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Password", "", CodeOption.lmCode)
        PARA_DivisionID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DivisionID", "")
        PARA_TranMonth = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranMonth", "0")
        PARA_TranYear = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranYear", "0")
        PARA_Language = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Language", "84"), EnumLanguage)
        PARA_FormID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", "")
        PARA_FormState = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "FormState", "1"), EnumFormState)
        PARA_FormIDPermission = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", "")

        PARA_ID01 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID01", "")
        PARA_ID02 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID02", "")
        PARA_ID03 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID03", "")
        PARA_ID04 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID04", "")
        PARA_ID05 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID05", "")
        PARA_ID06 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID06", "")
        PARA_ID07 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID07", "")
        PARA_ID08 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID08", "")
        PARA_ID09 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID09", "")
        PARA_ID10 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID10", "")
        PARA_ID11 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID11", "")
        PARA_ID12 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID12", "")

        PARA_ModuleID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ModuleID", "13")
        '-----------------------------------------------------------------------
        gbUnicode = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "CodeTable", "False"), Boolean)
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
        D99C0008.Language = geLanguage
        PARA_FormID = PARA_FormID
        PARA_FormIDPermission = PARA_FormIDPermission
        '-----------------------------------------------------------------------        
    End Sub

    Private Sub MakeVirtualConnection()
        gsServer = "DRD252"
        gsCompanyID = "DRD02"
        gsConnectionUser = "sa"
        gsPassword = "2008"
        gsUserID = "LEMONADMIN"

        'gsServer = "DRD86"
        'gsCompanyID = "MT"
    End Sub

    Private Sub SaveParameter()
        Dim sForm As String = "D13F4020"
        Dim sDivisionID As String = "QT"

        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ServerName", gsServer, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DBName", gsCompanyID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", gsConnectionUser, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "UserID", gsUserID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Password", gsPassword, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DivisionID", sDivisionID)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranMonth", "08")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranYear", "2013")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Language", "0")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", sForm) 'PARA_FormID
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", sForm) 'PARA_FormIDPermission
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "FormState", "1") 'PARA_FormIDPermission
    End Sub

End Module
