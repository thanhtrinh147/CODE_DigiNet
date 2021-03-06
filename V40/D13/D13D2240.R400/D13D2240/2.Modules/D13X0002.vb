''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D13X0002

    Public Function ComboValue(ByVal c1Combo As C1.Win.C1List.C1Combo) As String
        If c1Combo.Text = "" Then Return ""
        If c1Combo.SelectedValue IsNot Nothing Then
            Return c1Combo.SelectedValue.ToString
        Else
            Return ""
        End If
    End Function

    Public Sub ReLoadImage(pic As PictureBox)
        If geLanguage = EnumLanguage.Vietnamese Then
            pic.Image = Global.D13D2240.My.Resources.Resources.Running_vi
        Else
            pic.Image = Global.D13D2240.My.Resources.Resources.Running_en
        End If
    End Sub
    
    Public Sub LoadResultSalCal(ByVal SalaryVoucherNo As String, _
                                ByVal PayrollVoucherNo As String, ByVal SalaryVoucherID As String, _
                                ByVal PayrollVoucherID As String, ByVal SalCalMethodID As String, _
                                ByVal TransferMethodID As String, ByVal VoucherDate As String, _
                                ByVal Description As String)
        'ANHVU
        Dim f As New D13F2042
        With f
            .SalaryVoucherNo = SalaryVoucherNo
            .PayrollVoucherNo = PayrollVoucherNo
            .SalaryVoucherID = SalaryVoucherID
            .PayrollVoucherID = PayrollVoucherID
            .SalCalMethodID = SalCalMethodID
            .TransferMethodID = TransferMethodID
            .VoucherDate = VoucherDate
            .ShowInTaskbar = True
            .isBringToFront = True

            .ShowDialog()
            .Dispose()
        End With
    End Sub

#Region "Thực hiện AuditLog"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6200
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/09/2011 03:22:34
    '# Modified User:
    '# Modified Date:
    '# Description: 0(Gia tri cũ)/1(Gia tri mới)
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD09P6200(ByVal TableName As String, ByVal ColVoucherID As String, ByVal VoucherID As String, ByVal iMode As Integer, ByVal ColTransID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P6200 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(TableName) & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLString(ColVoucherID) & COMMA 'ColVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(VoucherID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(ColTransID) & COMMA 'ColTransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'ColType, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6210
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 20/10/2011 08:08:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD09P6210(ByVal sAuditCode As String, ByVal sAuditItemID As String, ByVal sEventID As String _
                    , Optional ByVal sDesc01 As String = "", Optional ByVal sDesc02 As String = "", Optional ByVal sDesc03 As String = "" _
                    , Optional ByVal sDesc04 As String = "", Optional ByVal sDesc05 As String = "") As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P6210 "
        sSQL &= SQLDateSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("13") & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL'"03"
        sSQL &= SQLString(sAuditItemID) & COMMA 'AuditItemID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLStringUnicode(sDesc01, gbUnicode, True) & COMMA 'Desc01, nvarchar, NOT NULL
        sSQL &= SQLStringUnicode(sDesc02, gbUnicode, True) & COMMA 'Desc02, nvarchar, NOT NULL
        sSQL &= SQLStringUnicode(sDesc03, gbUnicode, True) & COMMA 'Desc03, nvarchar, NOT NULL
        sSQL &= SQLStringUnicode(sDesc04, gbUnicode, True) & COMMA 'Desc04, nvarchar, NOT NULL
        sSQL &= SQLStringUnicode(sDesc05, gbUnicode, True) 'Desc05, nvarchar, NOT NULL
        Return sSQL
    End Function

#End Region

    ' Update 10/10/2012 id 51772 - Lỗi hiển thị thông báo khi tính lương
    ''' <summary>
    ''' Kiểm tra dữ liệu bằng Store (HÀM MỚI) dạng thông báo do store tự trả ra
    ''' </summary>
    ''' <param name="SQL">Store cần kiểm tra</param>
    ''' <returns>Trả về True nếu kiểm tra không có lỗi, ngược lại trả về False</returns>
    ''' <remarks>Chú ý: Kết quả trả ra của Store phải có dạng là 1 hàng và 4 cột là Status, Message, FontMessage, MsgAsk</remarks>
    Public Function CheckStoreShowMSGVB(ByVal SQL As String) As Boolean
        'Update 1/03/2010: sửa lại hàm checkstore có trả ra field FontMessage
        'Cách kiểm tra của hàm CheckStore này sẽ như sau:
        'Nếu store trả ra Status <> 0 thì xuất Message theo dạng FontMessage
        'Nếu store trả ra MsgAsk = 0 thì xuất Message nút Ok,  MsgAsk = 1 thì xuất Message nút Yes, No

        Dim dt As New DataTable
        Dim sMsg As String
        Dim bMsgAsk As Boolean = False
        dt = ReturnDataTableMSGVB(SQL, "", False)
        If dt Is Nothing Then
            sMsg = rL3("Tinh_luong_bi_loi") & " " & rL3("Vui_long_lien_he_nha_cung_cap")  'TÛnh l§¥ng bÜ læi. Vui lßng li£n hÖ nhª cung cÊp
            MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Status").ToString = "0" Then
                dt = Nothing
                Return True
            End If

            sMsg = dt.Rows(0).Item("Message").ToString
            Dim bFontMessage As Boolean = False
            If dt.Columns.Contains("FontMessage") Then bFontMessage = True
            If dt.Columns.Contains("MsgAsk") Then
                If L3Byte(dt.Rows(0).Item("MsgAsk")) = 1 Then
                    bMsgAsk = True
                End If
            End If

            If Not bMsgAsk Then 'OKOnly
                If Not bFontMessage Then
                    MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Case "1" 'Unicode
                            'D99C0008.MsgL3(sMsg, L3MessageBoxIcon.Exclamation)
                            MessageBox.Show(ConvertVietwareFToUnicode(sMsg), MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
                        Case "2" 'Convert Vni To Unicode
                            D99C0008.MsgL3(ConvertVniToUnicode(sMsg), L3MessageBoxIcon.Exclamation)
                    End Select
                End If
                dt = Nothing
                Return False
            Else 'YesNo
                If Not bFontMessage Then
                    If MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        dt = Nothing
                        Return True
                    Else
                        dt = Nothing
                        Return False
                    End If
                Else
                    Select Case dt.Rows(0).Item("FontMessage").ToString
                        Case "0" 'VietwareF
                            If MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "1" 'Unicode
                            If D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                        Case "2" 'Convert Vni To Unicode
                            If D99C0008.MsgAsk(ConvertVniToUnicode(sMsg), MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                dt = Nothing
                                Return True
                            Else
                                dt = Nothing
                                Return False
                            End If
                    End Select
                End If
            End If
            dt = Nothing
        Else
            D99C0008.MsgL3("Không có dòng nào trả ra từ Store")
            Return False
        End If
        Return True
    End Function

    Private Function ReturnDataTableMSGVB(ByVal SQL As String, ByVal MyMsgErr As String, ByVal bUseClipboard As Boolean, Optional ByVal sConnectionStringNew As String = "") As DataTable
        'Create 30/07/2010: thông báo lỗi được truyền vào
        Dim ds As DataSet = ReturnDataSetMSGVB(SQL, MyMsgErr, bUseClipboard, sConnectionStringNew)
        If ds Is Nothing Then Return Nothing
        Return ds.Tables(0)
    End Function

    Private Function ReturnDataSetMSGVB(ByVal SQL As String, Optional ByVal MyMsgErr As String = "", Optional ByVal bUseClipboard As Boolean = True, Optional ByVal sConnectionStringNew As String = "") As DataSet
        'Minh Hòa Update 10/08/2012: Đếm số lần bị lỗi
        Dim iCountError As Integer = 0

        Dim ds As DataSet = New DataSet()
        'If giAppMode = 0 Then

        Dim conn As SqlConnection
        If sConnectionStringNew <> "" Then
            conn = New SqlConnection(sConnectionStringNew)
        Else
            conn = New SqlConnection(gsConnectionString)
        End If
        Dim cmd As SqlCommand = New SqlCommand(SQL, conn)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Try

ErrorHandles:
            conn.Open()
            'cmd.CommandTimeout = 0
            If iCountError > 0 Then 'Minh Hòa Update 10/08/2012: nếu có lỗi trước đó thi gán CommandTimeout = 30
                cmd.CommandTimeout = 30
            Else
                cmd.CommandTimeout = 0
            End If

            da.Fill(ds)
            conn.Close()

            If iCountError > 0 Then
                'Minh Hòa Update 10/08/2012: Nếu có lỗi trước đó thì trả lại thời gian ConnectionTimeout =0
                conn.ConnectionString = conn.ConnectionString.Replace(gsConnectionTimeout15, gsConnectionTimeout)

            End If

            Return ds
        Catch ex As SqlException
            '******************************************
            'Minh Hòa Update 10/08/2012: Kiểm tra nếu không kết nối được với server thì thông báo để kết nối lại.
            If ex.Number = 10054 OrElse ex.Number = 1231 _
            OrElse ex.Message.Contains("Could not open a connection to SQL Server") _
            OrElse ex.Message.Contains("The server was not found or was not accessible") _
            OrElse ex.Message.Contains("A transport-level error") Then 'Lỗi không kết nối được server
                If CheckConnectFailed(conn, iCountError, "FromDataSet") Then
                    GoTo ErrorHandles
                End If
            Else
                conn.Close()
                If bUseClipboard Then
                    Clipboard.Clear()
                    Clipboard.SetText(SQL)
                End If
                If MyMsgErr <> "" Then
                    MsgErr(MyMsgErr)
                Else
                    '   MsgErr("Error when excute SQL in function ReturnDataSet(). Paste your SQL code from Clipboard" & vbCrLf & ex.Number & "- " & ex.Message)
                    '                    System.Windows.Forms.MessageBox.Show("Test MessageBox by Thread")
                    '                    Dim sMsg As String = "Error when excute SQL in function ReturnDataSet(). Paste your SQL code from Clipboard" & vbCrLf & ex.Number & "- " & ex.Message
                    '                    MessageBox.Show(sMsg, MsgAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                Return Nothing
            End If
            '******************************************
            '            Catch
            '                conn.Close()
            '                Clipboard.Clear()
            '                Clipboard.SetText(SQL)
            '                MsgErr("Error when excute SQL in function ReturnDataSet(). Paste your SQL code from Clipboard")
            '                Return Nothing
        End Try

        'End If

        Return Nothing
    End Function


   

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9106
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 06/03/2007 09:59:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD91P9106(ByVal sAuditCode As String, ByVal sModuleID As String, ByVal sEventID As String, ByVal sDesc1 As String, ByVal sDesc2 As String, ByVal sDesc3 As String, ByVal sDesc4 As String, ByVal sDesc5 As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9106 "
        sSQL &= SQLDateSave(Date.Today) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sModuleID) & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL
        Return sSQL
    End Function


End Module
