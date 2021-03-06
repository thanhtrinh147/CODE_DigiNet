''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D45X0002

#Region "Màn hình chọn đường dẫn báo cáo"

    Public Function GetReportPath(ByVal ReportTypeID As String, ByVal ReportName As String, ByVal CustomReport As String, ByRef ReportPath As String, Optional ByRef ReportTitle As String = "", Optional ByVal ModuleID As String = "45") As String
        Dim bShowReportPath As Boolean
        Dim iReportLanguage As Byte
        bShowReportPath = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
        iReportLanguage = CType(D99C0007.GetModulesSetting(D45, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
        'Lấy đường dẫn báo cáo từ module D99X0004
        ReportPath = UnicodeGetReportPath(gbUnicode, iReportLanguage, "")
        'Hiển thị màn hình chọn đường dẫn báo cáo
        If bShowReportPath Then

            Dim frm As New D99F6666
            With frm
                .ModuleID = ModuleID '2 ký tự
                .ReportTypeID = ReportTypeID
                .ReportName = ReportName
                .CustomReport = CustomReport
                .ReportPath = ReportPath
                .ReportTitle = ReportTitle
                .ShowDialog()
                ReportName = .ReportName
                ReportPath = .ReportPath
                ReportTitle = .ReportTitle
                SaveOptionReport(.ShowReportPath)
                .Dispose()
            End With
        Else 'Không hiển thị thì lấy theo Loại nghiệp vụ (nếu có)
            If CustomReport <> "" Then
                ReportPath = gsApplicationSetup & "\XCustom\"
                ReportName = CustomReport
            End If
        End If
        ReportPath = ReportPath & ReportName & ".rpt"
        Return ReportName
    End Function

    'Tùy thuộc từng module có biến lưu dưới Registry
    Public Sub SaveOptionReport(ByVal bShowReportPath As Boolean)
        'D99C0007.SaveModulesSetting(D45, ModuleOption.lmOptions, "ShowReportPath", bShowReportPath)
        D45Options.ShowReportPath = bShowReportPath 'Biến Tùy chọn
    End Sub

#End Region


    Public Const EXEMODULE As String = "D45"
    Public Const EXED00 As String = "D00E0030"
    Public Const EXEPARENT As String = "D45E0030"
    Public Const EXECHILD As String = "D45D0240"
    '---------------------------------------------
    Public Const AuditCodePieceworkVouchers45 As String = "PieceworkVouchers45"
    Public Const AuditCodeDetailPiecework As String = "DetailPiecework"
    Public Const AuditCodePSalaryCalculation As String = "PSalaryCalculation"
    Public Const AuditCodePSalaryResultDeletion As String = "PSalaryResultDeletion"

    Public Function CbVal(ByVal tdbc As C1.Win.C1List.C1Combo) As String
        If tdbc.SelectedValue Is Nothing OrElse tdbc.Text = "" Then
            Return ""
        End If
        Return tdbc.SelectedValue.ToString
    End Function

    'Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, Optional ByVal sDesc1 As String = "", Optional ByVal sDesc2 As String = "", Optional ByVal sDesc3 As String = "", Optional ByVal sDesc4 As String = "", Optional ByVal sDesc5 As String = "")
    '    'sEventID = 1: Thêm mới; = 2: Sửa; = 3: Xóa; = 4: In   

    '    ''Module này có dùng Auditlog không
    '    'If Not gbUseAudit Then Exit Sub
    '    ''Mã AuditCode này có sử dụng không
    '    'If Not CheckUseAuditCode(sAuditCode) Then Exit Sub

    '    'Ghi Audit cho mỗi nghiệp vụ
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D91P9106 "
    '    sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
    '    sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    'Test lai Module ID 
    '    sSQL &= SQLString(EXEMODULE) & COMMA 'ModuleID, varchar[2], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL

    '    ExecuteSQLNoTransaction(sSQL)

    'End Sub

    ''' <summary>
    ''' Kiểm tra tồn tại phiếu chấm công
    ''' </summary>
    ''' <param name="sProductVoucherID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TestExist(ByVal sProductVoucherID As String) As Boolean
        Dim sSQL As String = ""
        sSQL = "Select VoucherID From D13T2605  WITH(NOLOCK) Where Module='" & D45 & "' And VoucherID=" & SQLString(sProductVoucherID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            D99C0008.MsgL3(rl3("Phieu_nay_da_duoc_tinh_luong_Ban_khong_duoc_sua"))
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Copy giá trị trong 1 cột có liên quan đến các cột kế trước và kế sau nó (khi nhấn Head_Click hoặc Ctrl + S)
    ''' </summary>
    ''' <param name="c1Grid">lưới</param>
    ''' <param name="ColCopy">cột hiện tại</param>
    ''' <param name="RowCopy">dòng hiện tại</param>
    ''' <param name="ColumnCount_Before">số cột kế trước đó cần copy</param>
    ''' <param name="ColumnCount_After">số cột kế sau đó cần copy</param>
    ''' <param name="sValue">giá trị cần copy hiện hành</param>
    ''' <remarks>Chỉ copy những cột ở vị trí liên tục nhau trước đó</remarks>
    Public Sub CopyColumns_AfterBefore(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal ColumnCount_Before As Integer, ByVal ColumnCount_After As Integer, ByVal sValue As String)
        Dim i, j, k As Integer
        Try
            If c1Grid.RowCount < 2 Then Exit Sub
            ' If ColumnCount_after > 1 Then ' Copy nhieu cot lien quan
            Dim Flag As DialogResult

            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            c1Grid.UpdateData()

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i = RowCopy + 1 To c1Grid.RowCount - 1
                    j = 1
                    k = ColumnCount_Before
                    If c1Grid(i, ColCopy).ToString = "" Then
                        c1Grid(i, ColCopy) = sValue
                        While j <= ColumnCount_After
                            c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                            j += 1
                        End While
                        While k > 0
                            c1Grid(i, ColCopy - k) = c1Grid(RowCopy, ColCopy - k)
                            k -= 1
                        End While
                    End If
                Next
            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy hết

                For i = RowCopy + 1 To c1Grid.RowCount - 1
                    j = 1
                    k = ColumnCount_Before
                    c1Grid(i, ColCopy) = sValue
                    While j <= ColumnCount_After
                        c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                        j += 1
                    End While
                    While k > 0
                        c1Grid(i, ColCopy - k) = c1Grid(RowCopy, ColCopy - k)
                        k -= 1
                    End While
                Next
            Else
                Exit Sub
            End If
            '  End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub IsUseBlock()
        Dim sSQL As String = ""
        sSQL = "Select IsUseBlock From D09T0000 WITH(NOLOCK) "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            D45Systems.IsUseBlock = Convert.ToBoolean(dt.Rows(0).Item("IsUseBlock"))
        Else
            D45Systems.IsUseBlock = False
        End If
    End Sub

#Region "KeyboardCues"

    Private Declare Function SystemParametersInfoSet Lib "user32.dll" Alias "SystemParametersInfoW" (ByVal action As Integer, ByVal param As Integer, ByVal value As Integer, ByVal winini As Boolean) As Boolean
    Private Const SPI_SETKEYBOARDCUES As Integer = &H100B

    Public Sub KeyboardCues()
        SystemParametersInfoSet(SPI_SETKEYBOARDCUES, 0, 1, False)
    End Sub
#End Region

    Public Function InsertFormat(ByVal sStrFormat As String) As String
        If IsNumeric(sStrFormat) Then
            Return ("#,##0" & InsertZero(Convert.ToInt16(sStrFormat)))
        Else
            Return ("#,##0" & InsertZero(0))
        End If
    End Function

    Public Function SQLDeleteD91T9009(Optional ByVal sFormID As String = "", Optional ByVal sKey01 As String = "", Optional ByVal sKey02 As String = "", Optional ByVal sKey03 As String = "", Optional ByVal sKey04 As String = "", Optional ByVal sKey05 As String = "") As String
        Dim sSQL As String = "Delete From D91T9009 Where HostID=" & SQLString(My.Computer.Name) & " And UserID=" & SQLString(gsUserID) & vbCrLf
        If sFormID <> "" Then sSQL &= " And FormID = " & SQLString(sFormID)
        If sKey01 <> "" Then sSQL &= " And Key01ID = " & SQLString(sKey01)
        If sKey02 <> "" Then sSQL &= " And Key02ID = " & SQLString(sKey02)
        If sKey03 <> "" Then sSQL &= " And Key03ID = " & SQLString(sKey03)
        If sKey04 <> "" Then sSQL &= " And Key04ID = " & SQLString(sKey04)
        If sKey05 <> "" Then sSQL &= " And Key05ID = " & SQLString(sKey05)
        Return sSQL & vbCrLf

    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Kim Long
    '# Created Date: 10/05/2018 09:55:43
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLDeleteD09T6666(ByVal sFormID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- DELETE FROM D09T6666 " & vbCrLf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        sSQL &= "FormID = " & SQLString(sFormID)
        Return sSQL
    End Function



    'Public Enum D45E0340Form
    '    D45F4000 = 0
    '    D45F4020 = 1
    'End Enum
End Module
