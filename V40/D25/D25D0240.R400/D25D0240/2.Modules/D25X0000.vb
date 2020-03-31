''' <summary>
''' Sub Main và các vấn đề liên quan đến việc khởi động exe con
''' </summary>
Module D25X0000

    Public Sub Main()
#If DEBUG Then 'Nếu đang ở trạng thái DEBUG thì ...
        'CheckDLL() 'Kiểm tra các DLL tương thích và các file Module hợp lệ
        'MakeVirtualConnection() 'tạo kết nối ảo
        'geLanguage = EnumLanguage.Vietnamese 'Gán mặc định là Vietnamese
        'gsLanguage = "84" 'Gán mặc định là Vietnamese
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
        LoadOptions()
        LoadFormatsNew()
        LoadOthers() 'Các lập trình viên có thể load những thứ khác ở đây

        'Hiển thị form tương ứng
        Select Case PARA_FormID
            'Chỉ cần bổ sung những form có nhận tham số

            Case "D25F2080" 'Nghiệp vụ -> A. Lập kế hoạch tuyển dụng
                Dim f As New D25F2080
                With f
                    .FormState = PARA_FormState
                    .ShowInTaskbar = True
                    .ShowDialog()
                    .Dispose()
                End With

                'Case "D25F2000" 'Nghiệp vụ -> B. LLập đề xuất tuyển dụng
                '    Dim f As New D25F2000
                '    With f
                '        .FormState = PARA_FormState
                '        .ShowInTaskbar = True
                '        .ShowDialog()
                '        .Dispose()
                '    End With

                'Case "D25F2021" 'Nghiệp vụ -> C. Duyệt đề xuất tuyển dụng
                '    Dim f As New D25F2021
                '    With f
                '        .FormState = PARA_FormState
                '        .ShowInTaskbar = True
                '        .ShowDialog()
                '        .Dispose()
                '    End With

            Case "D25F2070" 'Nghiệp vụ -> D. Lập thông báo tuyển dụng
                Dim f As New D25F2070
                With f
                    .FormState = PARA_FormState
                    .ShowInTaskbar = True
                    .ShowDialog()
                    .Dispose()
                End With

                'Case "D25F1040" 'Nghiệp vụ -> E. Lập đợt tuyển dụng
                '    Dim f As New D25F1040
                '    With f
                '        .FormState = PARA_FormState
                '        .ShowInTaskbar = True
                '        .ShowDialog()
                '        .Dispose()
                '    End With

                'Case "D25F2010" 'Nghiệp vụ -> F. Lập lịch phỏng vấn
                '    Dim f As New D25F2010
                '    With f
                '        .FormState = PARA_FormState
                '        .ShowInTaskbar = True
                '        .ShowDialog()
                '        .Dispose()
                '    End With

            Case "D25F3031" 'Nghiệp vụ -> G. Đánh giá kết quả phỏng vấn
                Dim f As New D25F3031
                With f
                    .ShowInTaskbar = True
                    .ShowDialog()
                    .Dispose()
                End With

            Case "D25F2060" 'Nghiệp vụ -> H. Quyết định tuyển dụng
                Dim f As New D25F2060
                With f
                    .FormState = EnumFormState.FormAdd 'PARA_FormState
                    .ShowInTaskbar = True
                    .ShowDialog()
                    .Dispose()
                End With

            Case "D25F2100" 'Nghiệp vụ -> I. Duyệt quyết định tuyển dụng
                Dim f As New D25F2100
                With f
                    .FormState = PARA_FormState
                    .ShowInTaskbar = True
                    .ShowDialog()
                    .Dispose()
                End With

                'Case "D25F2090" 'Nghiệp vụ -> J. Chi phí tuyển dụng
                '    Dim f As New D25F2090
                '    With f
                '        .FormState = PARA_FormState
                '        .ShowInTaskbar = True
                '        .ShowDialog()
                '        .Dispose()
                '    End With

            Case "D25F3060" 'Nghiệp vụ -> J. Chi phí tuyển dụng
                Dim f As New D25F3060
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

        KillChildProcess(MODULED25)
    End Sub

    Private Function CheckOther() As Boolean
        Return True
    End Function

    Private Sub LoadOthers()
        LoadUserKey()
        GetModuleAdmin("D25")
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
            Dim FiVerInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath & "\" & MODULED25 & ".EXE")
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
        PARA_DivisionID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "DivisionID", gsDivisionID)
        PARA_TranMonth = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranMonth", giTranMonth.ToString)
        PARA_TranYear = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "TranYear", giTranYear.ToString)
        PARA_Language = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Language", "84"), EnumLanguage)
        PARA_FormID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", "")
        PARA_FormIDPermission = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", "")
        PARA_Closed = CBool(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "Closed", "False"))
        '-----------------------------------------------------------------------
        gbUnicode = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "CodeTable", "False"), Boolean)
        gsCreateBy = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "CreateBy", "")
        gbLockL3UserID = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "LockL3UserID", ""), Boolean)
        '-----------------------------------------------------------------------
        PARA_FormState = CType(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "FormState", "3"), EnumFormState)
        PARA_ID01 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID01", "")
        PARA_ID02 = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID02", "")
        '-----------------------------------------------------------------------
        AssignToPublicVariable()

#If DEBUG Then
        gbUnicode=True
#Else
        'Xóa Registry
        'D99C0007.RegDeleteExe(EXECHILD)
#End If

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
        gbClosed = PARA_Closed
        '-----------------------------------------------------------------------     
    End Sub

    Private Sub MakeVirtualConnection()
        gsServer = "DRD14"
        gsCompanyID = "drd02"
        gsConnectionUser = "sa"
        gsPassword = ""
        gsUserID = "LEMONADMIN"

        gsServer = "DRD80"
        gsCompanyID = "test01"
        'gsConnectionUser = "sa"
        'gsPassword = ""
        'gsUserID = "LEMONADMIN"
    End Sub

    Private Sub SaveParameter()
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ServerName", gsServer, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DBName", gsCompanyID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", gsConnectionUser, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "UserID", gsUserID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Password", gsPassword, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DivisionID", "THHA")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranMonth", "2")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranYear", "2011")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Language", "0")
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", "D25F3031") 'PARA_FormID
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", "D25F3031") 'PARA_FormIDPermission
    End Sub

End Module