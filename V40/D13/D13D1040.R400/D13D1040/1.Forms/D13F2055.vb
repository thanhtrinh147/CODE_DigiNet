Imports System
Public Class D13F2055
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_SalaryMethodID As Integer = 0 ' SalaryMethodID
    Private Const COL_CalNo As Integer = 1          ' CalNo
    Private Const COL_OrderNo As Integer = 2               ' STT
    Private Const COL_Description As Integer = 3    ' Diễn giải
    Private Const COL_ShortName As Integer = 4      ' Tên tắt
    Private Const COL_SalSystemID As Integer = 5    ' Mã thu nhập hệ thống
    Private Const COL_IsBackPay As Integer = 6      ' Hồi tố lương
    Private Const COL_IsUpdate As Integer = 7       ' IsUpdate
#End Region

    Private dtGrid As DataTable

    Private _salaryMethodID As String = ""
    Public WriteOnly Property SalaryMethodID() As String 
        Set(ByVal Value As String )
            _salaryMethodID = Value
        End Set
    End Property

    Private _salaryMethodName As String =""
    Public WriteOnly Property SalaryMethodName() As String 
        Set(ByVal Value As String )
            _salaryMethodName = Value
        End Set
    End Property
    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdSalSystemID
        sSQL = "SELECT		Code AS SalSystemID, Short" & UnicodeJoin(gbUnicode) & " AS SalSysShortName "
        sSQL &= "FROM		D13T9000 "
        sSQL &= "WHERE		Disabled = 0 and Type = 'PRSYS' "
        sSQL &= "ORDER BY	Code"
        LoadDataSource(tdbdSalSystemID, sSQL, gbUnicode)
    End Sub

    Private Sub D13F2055_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        InputbyUnicode(Me, gbUnicode)
        LoadTDBDropDown()
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        txtSalaryMethodName.Text = _salaryMethodName
        LoadTDBGrid()
        LoadLanguage()

        tdbg_LockedColumns()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Dim bNotInList As Boolean = False
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_SalSystemID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                Else
                    Dim SalSystemID As String
                    SalSystemID = tdbdSalSystemID.Columns("SalSystemID").Text
                    For i As Integer = 0 To tdbg.RowCount - 1
                        If tdbg.Row <> i AndAlso SalSystemID = tdbg(i, COL_SalSystemID).ToString() Then
                            e.Cancel = True
                            D99C0008.MsgDuplicatePKey()
                            tdbg.Focus()
                            tdbg.Col = COL_SalSystemID
                            Exit For
                        End If
                    Next
                End If

        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_SalaryMethodID
            Case COL_CalNo
            Case COL_Description
            Case COL_ShortName
            Case COL_SalSystemID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    Exit Select
                End If
            Case COL_IsBackPay
        End Select
        tdbg.Columns(COL_IsUpdate).Value = "1"
        tdbg.UpdateData()

    End Sub

    Private Sub D13F2055_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
        End Select
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Thiet_lap_hoi_to_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'ThiÕt lËp häi tç l§¥ng
        '================================================================ 
        lblSalaryMethodName.Text = rl3("PP_tinh_luong") 'PP tính lương
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkIsBackPay.Text = rl3("Chi_hien_thi_nhung_khoan_co_hoi_to_luong") 'Chỉ hiển thị những khoản có hồi tố lương
        '================================================================ 
        '================================================================ 
        tdbg.Columns(COL_OrderNo).Caption = rL3("STT") 'STT
        tdbg.Columns(COL_Description).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_ShortName).Caption = rL3("Ten_tat") 'Tên tắt
        tdbg.Columns(COL_SalSystemID).Caption = rL3("Ma_thu_nhap_he_thong") 'Mã thu nhập hệ thống
        tdbg.Columns(COL_IsBackPay).Caption = rL3("Hoi_to_luong") 'Hồi tố lương

    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD13P2055()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        If chkIsBackPay.Checked Then
            dtGrid.DefaultView.RowFilter = "IsBackPay = 1"
        Else
            dtGrid.DefaultView.RowFilter = ""
        End If
        FooterTotalGrid(tdbg, COL_Description)
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Description).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ShortName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub


    Private Sub chkIsBackPay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsBackPay.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        '  dtGrid.AcceptChanges()
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As String = SQLUpdateD13T2501s().ToString
        Dim bRunSQL As Boolean = True
        If sSQL <> "" Then
            bRunSQL = ExecuteSQL(sSQL)
        End If

        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnSave.Focus()
        End If
    End Sub

#Region "tdbg events"


    'DataField của cột ="" nên phải khai báo cột kiểu Integer
    Private Sub tdbg_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg.UnboundColumnFetch
        Select Case e.Col
            Case COL_OrderNo 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                HotKeyEnterGrid(tdbg, COL_IsBackPay, e)
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_IsBackPay
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub

    Dim bSelect As Boolean = False 'Mặc định Uncheck - tùy thuộc dữ liệu database
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_IsBackPay
                L3HeadClick(tdbg, e.ColIndex, bSelect)
        End Select
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2055
    '# Created User: Hoàng Nhân
    '# Created Date: 01/10/2013 01:29:24
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2055() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrlf)
        sSQL &= "Exec D13P2055 "
        sSQL &= SQLString(_salaryMethodID) & COMMA 'SalaryMethodID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2501s
    '# Created User: Hoàng Nhân
    '# Created Date: 01/10/2013 01:22:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2501s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        'Dim dtChanged As DataTable = dtGrid.GetChanges(DataRowState.Modified)
        'If dtChanged Is Nothing Then Return sRet

        'If dtChanged.Rows.Count > 0 Then sSQL.Append("-- Luu du lieu" & vbCrLf)
        'For i As Integer = 0 To dtChanged.Rows.Count - 1
        '    sSQL.Append("Update D13T2501 Set ")
        '    sSQL.Append("IsBackPay = " & SQLNumber(dtChanged.Rows(i).Item("IsBackPay"))) 'tinyint, NOT NULL
        '    sSQL.Append(" Where ")
        '    sSQL.Append("SalCalMethodID = " & SQLString(dtChanged.Rows(i).Item("SalaryMethodID")) & " And ")
        '    sSQL.Append("CalNo = " & SQLString(dtChanged.Rows(i).Item("CalNo")))

        '    sRet.Append(sSQL.ToString & vbCrLf)
        '    sSQL.Remove(0, sSQL.Length)
        'Next
        'Return sRet

        Dim dr() As DataRow = dtGrid.Select("IsUpdate = 1")
        If dr.Length < 1 Then Return sRet

        If dr.Length > 0 Then sSQL.Append("-- Luu du lieu" & vbCrLf)
        For Each datarow As DataRow In dr
            sSQL.Append("Update D13T2501 Set ")
            sSQL.Append("IsBackPay = " & SQLNumber(datarow("IsBackPay"))) 'tinyint, NOT NULL
            sSQL.Append(",SalSystemID  = " & SQLString(datarow("SalSystemID")))
            sSQL.Append(" Where ")
            sSQL.Append("SalCalMethodID = " & SQLString(datarow("SalaryMethodID")) & " And ")
            sSQL.Append("CalNo = " & SQLString(datarow("CalNo")))
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet

    End Function


 
 
End Class