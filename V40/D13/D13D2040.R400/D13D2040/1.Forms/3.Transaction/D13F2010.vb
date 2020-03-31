'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:30:20 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:30:20 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Imports System.Text

Public Class D13F2010
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_PayrollVoucherID As Integer = 0 ' Mã ngầm
    Private Const COL_VoucherDate As Integer = 1      ' Ngày phiếu
    Private Const COL_PayrollVoucherNo As Integer = 2 ' Số phiếu
    Private Const COL_Description As Integer = 3      ' Diễn giải
    Private Const COL_CreateUserID As Integer = 4     ' CreateUserID
    Private Const COL_LastModifyUserID As Integer = 5 ' LastModifyUserID
    Private Const COL_CreateDate As Integer = 6       ' CreateDate
    Private Const COL_LastModifyDate As Integer = 7   ' LastModifyDate
#End Region

    Private sPayrollVoucherID As String
    Public bFlagHSL As Boolean

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub D13F2010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        SetShortcutPopupMenu(Me, tbrToolStrip, ContextMenuStrip1, True)
        Loadlanguage()
        ResetColorGrid(tdbg)
        LoadTDBGrid()
        InputDateInTrueDBGrid(tdbg, COL_VoucherDate)

        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ho_so_luong_thang_-_D13F2010") & UnicodeCaption(gbUnicode) 'Hä s¥ l§¥ng thÀng - D13F2010
        '================================================================ 
        tdbg.Columns("PayrollVoucherID").Caption = rl3("Ma_ngam_") 'Mã ngầm
        tdbg.Columns("VoucherDate").Caption = rl3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns("PayrollVoucherNo").Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tsmDetail.Text = rl3("Chi_tiet_1") '&Chi tiết
        mnsDetail.Text = rl3("Chi_tiet_1") '&Chi tiết
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal bFlag As Boolean = False)
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P2011()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt, gbUnicode)
        If bFlag = True Then
            dt.DefaultView.Sort = "PayrollVoucherID"
            tdbg.Bookmark = dt.DefaultView.Find(sPayrollVoucherID)
        End If
        CheckMenu(Me.Name, tbrToolStrip, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        tsmDetail.Enabled = tdbg.RowCount > 0
        mnsDetail.Enabled = tsmDetail.Enabled
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D13F2011
        With f
            .PayrollVoucherID = ""
            bFlagHSL = True
            .bFlagSalOpen = bFlagHSL
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            sPayrollVoucherID = .PayrollVoucherID
            _bSaved = .bSaved
            If .bSaved = True Then
                LoadTDBGrid(True)
            End If
            .Dispose()
        End With
        
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D13F2011
        Dim iBookmark As Integer
        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        With f
            .PayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
            bFlagHSL = False
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            _bSaved = .bSaved
            If .bSaved Then
                LoadTDBGrid()
                If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
            End If
            .Dispose()
        End With
        
    End Sub

    Private Sub tsbView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        bFlagHSL = True
        Dim f As New D13F2011
        With f
            .PayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D29F5558") '  Code cũ truyền là D29F5558
        SetProperties(arrPro, "AuditCode", "MonthlySalaryFile")
        SetProperties(arrPro, "AuditItemID", tdbg.Columns(COL_PayrollVoucherID).Text)
        SetProperties(arrPro, "mode", "1")
        SetProperties(arrPro, "CreateUserID", tdbg.Columns(COL_CreateUserID).Text)
        SetProperties(arrPro, "CreateDate", tdbg.Columns(COL_CreateDate).Text)

        CallFormShow(Me, "D91D0640", "D91F1655", arrPro)

        '        Dim frm As New D91F5558
        '        With frm
        '            .FormName = "D91F1655"
        '            .FormPermission = "D29F5558"  'Màn hình phân quyền
        '            .ID01 = "MonthlySalaryFile" 'AuditCode
        '            .ID02 = tdbg.Columns(COL_PayrollVoucherID).Text 'AuditItemID
        '            .ID03 = "1" 'Mode
        '            .ID04 = tdbg.Columns(COL_CreateUserID).Text 'CreateUserID
        '            .ID05 = tdbg.Columns(COL_CreateDate).Text 'CreateDate
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub tsmDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDetail.Click, mnsDetail.Click
        Dim f As New D13F2012
        Dim sSQL As String = ""
        With f
            .PayrollVoucherID = tdbg.Columns(COL_PayrollVoucherID).Text
            .PayrollVoucherNo = tdbg.Columns(COL_PayrollVoucherNo).Text
            .VoucherDate = Date.Parse(tdbg.Columns(COL_VoucherDate).Text)
            .Description = tdbg.Columns(COL_Description).Text
            .Path = "04"
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        Dim Msg As Windows.Forms.DialogResult
        If AskDelete() = Windows.Forms.DialogResult.Yes Then
            If CheckStore(SQLStoreD13P5555) Then
                If IsExistRecord("D13T0101") Then ' HSL đã mở
                    Msg = D99C0008.MsgAsk(rl3("Ho_so_luong_thang_nay_da_duoc_mo") & " " & rL3("Ban_co_that_su_muon_xoa_ho_so_luong_nay_khong"))
                    '   Msg = D99C0008.MsgAsk(rl3("Ho_so_luong_nay_thang_nay_da_duoc_mo_Ban_co_that_su_muon_xoa_ho_so_luong_nay_khong"), MessageBoxDefaultButton.Button2)
                    If Msg = Windows.Forms.DialogResult.Yes Then
                        DeleteMonthlySalaryFile()
                    End If
                Else 'HSL chưa được mở
                    DeleteMonthlySalaryFile()
                End If
            End If
        End If
    End Sub

    Private Sub DeleteMonthlySalaryFile()
        Dim sSQL As String = ""
        Dim iBookmark As Integer
        Dim bResult As Boolean

        If Not IsDBNull(tdbg.Bookmark) Then iBookmark = tdbg.Bookmark
        sSQL &= "UPDATE D13T0101 SET PayrollVoucherID = '' WHERE PayrollVoucherID = " & SQLString(tdbg.Columns(COL_PayrollVoucherID).Text) & vbCrLf
        sSQL &= "DELETE FROM D13T0100 WHERE PayrollVoucherID = " & SQLString(tdbg.Columns(COL_PayrollVoucherID).Text) & " AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= SQLStoreD09P6210("MonthlySalaryFile", tdbg.Columns(COL_PayrollVoucherID).Text, "03", tdbg.Columns(COL_PayrollVoucherNo).Text, tdbg.Columns(COL_Description).Text)
        bResult = ExecuteSQL(sSQL)
        If bResult = True Then
            DeleteOK()
            LoadTDBGrid()
            If Not IsDBNull(iBookmark) Then tdbg.Bookmark = iBookmark
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.RowCount < 1 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        Else
            tsbView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.RowCount < 1 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            If tsbEdit.Enabled Then
                tsbEdit_Click(sender, Nothing)
            Else
                tsbView_Click(sender, Nothing)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function IsExistRecord(ByVal sTable As String) As Boolean
        Dim sSQL As String = ""
        sSQL = "Select top 1 PayrollVoucherID From " & sTable & " Where PayrollVoucherID = " & SQLString(tdbg.Columns(COL_PayrollVoucherID).Text) & " And DivisionID = " & SQLString(gsDivisionID)
        Return ExistRecord(sSQL)
    End Function

    Private Function CheckExistRecord() As Integer
        Dim sSQL As String = ""
        If IsExistRecord("D13T2600") = True Then
            Return 0
        Else
            If IsExistRecord("D13T0102") = True Then
                Return 0
            Else 'Kiểm tra theo hồ sơ lƯƠNG d45
                If IsExistRecord("D45T2000") = True Then
                    Return 0
                Else
                    If IsExistRecord("D13T0106") = True Then
                        Return 0
                    Else
                        'Kiểm tra trong hồ sơ lương tháng
                        If IsExistRecord("D13T0101") = True Then
                            Return 1 ' HSL đã mở
                        Else
                            Return 2 ' HSL chưa được mở
                        End If
                    End If
                End If
            End If
        End If
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2011
    '# Created User: DUCTRONG
    '# Created Date: 08/06/2009 04:30:27
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2011() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2011 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: DUCTRONG
    '# Created Date: 15/01/2010 10:13:34
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(1) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString("D13F2010") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_PayrollVoucherID).Text) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") 'Key05ID, varchar[20], NOT NULL
        Return sSQL
    End Function

End Class